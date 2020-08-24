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

namespace MES.H40_공급망_품질관리
{
    public partial class frm부적합이력조회 : Form
    {
        wnDm wnDm = new wnDm();
        public static bool p_IsAuth = true;    // 열람권한
        public static bool p_Isrgstr = true;    //등록/수정 권한
        public static bool p_Isdel = true;    // 삭제 권한

        public frm부적합이력조회()
        {
            InitializeComponent();
        }

        private void frm부적합이력조회_Load(object sender, EventArgs e)
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
            bind부적합이력조회(condition);
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        String condition = "";
        private void bind부적합이력조회(String condition)
        {

            condition = "and A.PASS_YN='N'";
            dgv부적합.Rows.Clear();
            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = null;
                dt = wDm.fn_부적합이력(condition);

                if (dt != null && dt.Rows.Count > 0)
                {
                    dgv부적합.RowCount = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgv부적합.Rows[i].Cells["LOT_NO"].Value = dt.Rows[i]["LOT_NO"].ToString();
                        dgv부적합.Rows[i].Cells["LOT_SUB"].Value = dt.Rows[i]["LOT_SUB"].ToString();
                        dgv부적합.Rows[i].Cells["F_STEP"].Value = dt.Rows[i]["F_STEP"].ToString();
                        dgv부적합.Rows[i].Cells["F_CHK_DATE"].Value = dt.Rows[i]["F_CHK_DATE"].ToString();
                        dgv부적합.Rows[i].Cells["F_SUB_AMT"].Value = dt.Rows[i]["F_SUB_AMT"].ToString();
                        dgv부적합.Rows[i].Cells["MEASURE_CNT"].Value = dt.Rows[i]["MEASURE_CNT"].ToString();
                        dgv부적합.Rows[i].Cells["PASS_YN"].Value = dt.Rows[i]["PASS_YN"].ToString();
                        dgv부적합.Rows[i].Cells["SPEC"].Value = dt.Rows[i]["SPEC"].ToString();
                        dgv부적합.Rows[i].Cells["ITEM_NM"].Value = dt.Rows[i]["ITEM_NM"].ToString();
                        dgv부적합.Rows[i].Cells["ITEM_GUBUN"].Value = dt.Rows[i]["ITEM_GUBUN_NM"].ToString();
                        dgv부적합.Rows[i].Cells["CHK_ORD"].Value = dt.Rows[i]["CHK_ORD"].ToString();
                        dgv부적합.Rows[i].Cells["CHK_NM"].Value = dt.Rows[i]["CHK_NM"].ToString();
                        dgv부적합.Rows[i].Cells["FLOW_NM"].Value = dt.Rows[i]["FLOW_NM"].ToString();
                        
                    }
                }
                else
                {
                    dgv부적합.Rows.Clear();
                }
            }
            catch (Exception e)
            {
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(e.Message+" - "+e.ToString()); msg.ShowDialog();
            }

        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            bind부적합이력조회(condition);
        }
    }
}
