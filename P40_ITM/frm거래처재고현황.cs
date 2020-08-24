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
namespace MES.P40_ITM
{
    public partial class frm거래처재고현황 : Form
    {       

        public frm거래처재고현황()
        {
            InitializeComponent();
        }
     
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public static bool p_IsAuth = true;    // 열람권한
        public static bool p_Isrgstr = true;    //등록/수정 권한

        public static bool p_Isdel = true;    // 삭제 권한
        wnDm wnDm = new wnDm();
        private void frm거래처재고현황_Load(object sender, EventArgs e)
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
            GridList();
        }

        private void GridList()
        {
            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = null;
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("having C.CUST_NM LIKE '%" + txt_Cust.Text.ToString() + "%' ");                
                dt = wDm.fn_Cust_Stock_List(sb.ToString());

                //dataItemGrid.RowCount = dt.Rows.Count;
                dataItemGrid.Rows.Clear();

                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dataItemGrid.Rows.Add();
                        dataItemGrid.Rows[i].Cells["CUST_NM"].Value = dt.Rows[i]["CUST_NM"].ToString();                        
                        //천단위마다 콤마 추가
                        dataItemGrid.Rows[i].Cells["INPUT_AMT"].Value = (decimal.Parse(dt.Rows[i]["입고량"].ToString())).ToString("#,0.######");
                        dataItemGrid.Rows[i].Cells["OUTPUT_AMT"].Value = (decimal.Parse(dt.Rows[i]["출고량"].ToString())).ToString("#,0.######");
                        dataItemGrid.Rows[i].Cells["STOCK_AMT"].Value = (decimal.Parse(dt.Rows[i]["재고량"].ToString())).ToString("#,0.######");
                        //dataItemGrid.Rows[i].Cells[4].Value = "0";
                    }
                }
                else
                {
                    dataItemGrid.Rows.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("시스템 오류" + ex.ToString());
            }

            datadetaiIGrid.Rows.Clear();
        }

        private void dataItemGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                try
                {
                    wnDm wDm = new wnDm();
                    DataTable dt = null;

                    txt_CustNM.Text = dataItemGrid.Rows[e.RowIndex].Cells["CUST_NM"].Value.ToString();

                    dt = wDm.fn_Cust_Detail_Stock_List(txt_CustNM.Text);

                    this.datadetaiIGrid.RowCount = dt.Rows.Count;

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            datadetaiIGrid.Rows[i].Cells["INPUT_DATE"].Value = dt.Rows[i]["INPUT_DATE"].ToString();
                            datadetaiIGrid.Rows[i].Cells["LOTNO"].Value = dt.Rows[i]["LOT_NO"].ToString();
                            datadetaiIGrid.Rows[i].Cells["ITEM_CD"].Value = dt.Rows[i]["ITEM_CD"].ToString();
                            datadetaiIGrid.Rows[i].Cells["ITEM_NM"].Value = dt.Rows[i]["ITEM_NM"].ToString();
                            datadetaiIGrid.Rows[i].Cells["SPEC"].Value = dt.Rows[i]["SPEC"].ToString();
                            datadetaiIGrid.Rows[i].Cells["INPUT"].Value = (decimal.Parse(dt.Rows[i]["입고량"].ToString())).ToString("#,0.######");
                            datadetaiIGrid.Rows[i].Cells["OUTPUT"].Value = (decimal.Parse(dt.Rows[i]["출고량"].ToString())).ToString("#,0.######");
                            datadetaiIGrid.Rows[i].Cells["STOCK"].Value = (decimal.Parse(dt.Rows[i]["재고량"].ToString())).ToString("#,0.######");
                            //datadetaiIGrid.Rows[i].Cells["ETC"].Value = dt.Rows[i]["BAL_STOCK"].ToString();
                        }
                    }
                    else
                    {
                        //dataItemGrid.Rows.Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("시스템 오류" + ex.ToString());
                }
            }
        }

        private void btn_srch_Click(object sender, EventArgs e)
        {           
            GridList();
        }
    }
}
