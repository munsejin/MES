using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MES.CLS;

namespace MES.P20_ORD
{
    public partial class frm필요자재현황 : Form
    {
        DataTable adoPrt = null;
        wnAdo wAdo = new wnAdo();
        public static bool p_IsAuth = true;    // 열람권한
        public static bool p_Isrgstr = true;    //등록/수정 권한

        public static bool p_Isdel = true;    // 삭제 권한
        wnDm wnDm = new wnDm();
        public frm필요자재현황()
        {
            InitializeComponent();
        }

        private void frm필요자재현황_Load(object sender, EventArgs e)
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
            init_ComboBox();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void init_ComboBox()
        {
            cmb_cd_srch.Items.Add("전체 검색");
            cmb_cd_srch.Items.Add("코드별 검색");
            cmb_cd_srch.Items.Add("원자재명 검색");
            cmb_cd_srch.Items.Add("규격 검색");
            cmb_cd_srch.SelectedIndex = 0;
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            wnDm wDm = new wnDm();
            DataTable dt = null;

            StringBuilder sb = new StringBuilder();
              
            if (txt_srch.Text != null)
            {
                sb.AppendLine("AND RAW_MAT_NM like '%" + txt_srch.Text + "%' ");
            }
            if (true)
            {
                sb.AppendLine("AND ISNULL(A.BAL_STOCK,0) - ISNULL(B.INST_RAW_AMT,0)<0");
                
            }

            dt = wDm.fn_Raw_Want_Stock(sb.ToString());
                                   
            if (dt != null && dt.Rows.Count > 0)
            {
                rawStockGrid.RowCount = dt.Rows.Count;

                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    rawStockGrid.Rows[i].Cells["RAW_MAT_CD"].Value = dt.Rows[i]["RAW_MAT_CD"].ToString();
                    rawStockGrid.Rows[i].Cells["RAW_MAT_NM"].Value = dt.Rows[i]["RAW_MAT_NM"].ToString();
                    rawStockGrid.Rows[i].Cells["SPEC"].Value = dt.Rows[i]["SPEC"].ToString();
                    rawStockGrid.Rows[i].Cells["BASIC_STOCK"].Value = (decimal.Parse(dt.Rows[i]["BASIC_STOCK"].ToString())).ToString("#,0.######");
                    rawStockGrid.Rows[i].Cells["REAL_STOCK"].Value = (decimal.Parse(dt.Rows[i]["REAL_AMT"].ToString())).ToString("#,0.######");
                    rawStockGrid.Rows[i].Cells["BAL_STOCK"].Value = (decimal.Parse(dt.Rows[i]["BAL_STOCK"].ToString())).ToString("#,0.######");
                    double BASIC_STOCK = double.Parse(dt.Rows[i]["BASIC_STOCK"].ToString());
                    double REAL_STOCK = double.Parse(dt.Rows[i]["REAL_AMT"].ToString());
                    double rs = BASIC_STOCK - REAL_STOCK;
                    if (rs > 0)
                    {
                        rawStockGrid.Rows[i].Cells["WANT_STOCK"].Value = rs.ToString("#,0.######");
                    }
                    else 
                    {
                        rawStockGrid.Rows[i].Cells["WANT_STOCK"].Value = "0";
                    }
                   
                    


                    if (decimal.Parse(dt.Rows[i]["REAL_AMT"].ToString()) < 0)
                    {
                        rawStockGrid.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                    }
                }
            }
            else
            {
                MessageBox.Show("필요자재현황이 현재 없습니다. ");
            } 
        }
    }
}
