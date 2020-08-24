using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MES.CLS;

namespace MES.H30_납품관리
{
    public partial class frm매출집계 : Form
    {
        wnDm wnDm = new wnDm();
        wnGConstant wnGConstant = new wnGConstant();
        public static bool p_IsAuth = true;    // 열람권한
        public static bool p_Isrgstr = true;    //등록/수정 권한
        public static bool p_Isdel = true;    // 삭제 권한

        public frm매출집계()
        {
            InitializeComponent();
        }

        private void frm매출집계_Load(object sender, EventArgs e)
        {
            lbl_title.Tag = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[0] + "$" + wnDm.fn_TitleName(this.Name.ToString()).Split('$')[1]; lbl_title.Text = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[2];
            if (Common.p_strUserAdmin != "5")
            {
                DataTable dtcheck = wnDm.fn_auth_check(lbl_title.Tag.ToString().Split('$')[0], lbl_title.Tag.ToString().Split('$')[1]);
                p_IsAuth = dtcheck.Rows[0]["auth_yn"].ToString() == "Y" ? true : false;
                p_Isrgstr = dtcheck.Rows[0]["rgstr_yn"].ToString() == "Y" ? true : false;
                p_Isdel = dtcheck.Rows[0]["del_yn"].ToString() == "Y" ? true : false;
                try
                {
                    if (!p_IsAuth)
                    {
                        this.BeginInvoke(new MethodInvoker(Close));
                        /// MessageBox.Show("권한이없습니다.");
                    }

                }
                catch (Exception ex)
                {
                }
            }
            dtp스타트.Value = DateTime.Now.AddDays(-7);
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void bind매출집계()
    {
        String condition = "and A.sale_DATE>='" + dtp스타트.Value.ToString().Substring(0, 10) + "'and A.sale_DATE<='" + dtp엔드.Value.ToString().Substring(0, 10) + "' and A.SALE_GB<>'3'";

        try
        {
            dgv매출집계.Rows.Clear();
            DataTable dt= wnDm.매출집계list(condition);
            if (dt.Rows.Count>0)
            {
               for (int i = 0; i < dt.Rows.Count; i++)
			{
                dgv매출집계.Rows.Add();
                dgv매출집계.Rows[i].Cells["매출일자"].Value = dt.Rows[i]["SALE_DATE"].ToString();
                dgv매출집계.Rows[i].Cells["매출번호"].Value = dt.Rows[i]["SALE_NUM"].ToString();
                dgv매출집계.Rows[i].Cells["제품명"].Value = dt.Rows[i]["ITEM_NM"].ToString();
                dgv매출집계.Rows[i].Cells["수량"].Value = dt.Rows[i]["SALE_QTY"].ToString();
                dgv매출집계.Rows[i].Cells["단가"].Value = dt.Rows[i]["SALE_PRICE"].ToString();
                dgv매출집계.Rows[i].Cells["금액"].Value = dt.Rows[i]["SALE_AMT"].ToString();
                dgv매출집계.Rows[i].Cells["매출구분"].Value = dt.Rows[i]["매출구분"].ToString();
                dgv매출집계.Rows[i].Cells["거래처"].Value = dt.Rows[i]["CUST_NM"].ToString();

                if ( dt.Rows[i]["SALE_NUM"].ToString()=="99999")
                {
                    dgv매출집계.Rows[i].Cells["매출번호"].Value = "";
                    dgv매출집계.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                }
			 
			}
               wnGConstant.mergeCells(dgv매출집계,1);
            }
        }
        catch
        {
        }
    }

        private void btn검색_Click(object sender, EventArgs e)
        {
            bind매출집계();
        }
    }
}
