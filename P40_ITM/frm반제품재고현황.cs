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
using MES.Controls;

namespace MES.P40_ITM
{
    public partial class frm반제품재고현황 : Form
    {
        public frm반제품재고현황()
        {
            InitializeComponent();
        }
        public static bool p_IsAuth = true;    // 열람권한
        public static bool p_Isrgstr = true;    //등록/수정 권한

        public static bool p_Isdel = true;    // 삭제 권한
        wnDm wnDm = new wnDm();

        private void frm반제품재고현황_Load(object sender, EventArgs e)
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
            addButton(txt_srch, 0);
            
            tabControl2.TabPages.Remove(tabPage2);

            GridList();
        }



        Button[] Txtbtn = new Button[1];
        public void addButton(conTextBox TextBox, int type)
        {
            Txtbtn[type] = new Button();
            TextBox.Controls.Add(Txtbtn[type]);
            Txtbtn[type].FlatStyle = FlatStyle.Flat;
            Txtbtn[type].FlatAppearance.BorderSize = 0;
            Txtbtn[type].FlatAppearance.MouseDownBackColor = Color.Transparent;
            Txtbtn[type].SetBounds(TextBox.Size.Width - 19, 1, 18, TextBox.Size.Height - 2);
            Txtbtn[type].Text = "▼";
            Txtbtn[type].TabStop = false;
            Txtbtn[type].Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 4, FontStyle.Bold);

            switch (type)
            {
                case 0:
                    Txtbtn[type].Click += new EventHandler(txt_srch_DropDown);

                    break;

                default:
                    break;
            }
            Txtbtn[type].Show();
        }
        String old_item_nm;
        private void txt_srch_DropDown(object sender, EventArgs e)
        {
            Popup.pop_sf_제품검색 frm = new Popup.pop_sf_제품검색();
            wnDm wDm = new wnDm();
            DataTable dt = new DataTable();
            dt = wDm.fn_Item_List("where ITEM_NM like '%" + txt_srch.Text.ToString() + "%'  and ITEM_GUBUN = '2'");


            frm.dt = dt;
            frm.txtSrch.Text = txt_srch.Text.ToString();
            frm.ShowDialog();

            if (frm.sCode != "")
            {
                txt_item_Cd.Text = frm.sCode.Trim();

                txt_srch.Text = frm.sName.Trim();
                old_item_nm = frm.sName.Trim();
            }
            else
            {
                txt_item_Cd.Text = old_item_nm;
            }      
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        wnDm wDm = new wnDm();
        private void btnSrch_Click(object sender, EventArgs e)
        {
            GridList();
        }

        private void GridList()
        {
            try
            {

                DataTable dt = null;
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("where A.ITEM_NM LIKE '%" + txt_srch.Text.ToString() + "%' ");
                sb.AppendLine(" and A.ITEM_GUBUN = '2' ");
                dt = wDm.fn_Item_Stock_List(sb.ToString());

                this.dataItemGrid.RowCount = dt.Rows.Count;
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dataItemGrid.Rows[i].Cells["ITEM_CD"].Value = dt.Rows[i]["ITEM_CD"].ToString();
                        dataItemGrid.Rows[i].Cells["ITEM_NM"].Value = dt.Rows[i]["ITEM_NM"].ToString();
                        dataItemGrid.Rows[i].Cells["SPEC"].Value = dt.Rows[i]["SPEC"].ToString();
                        dataItemGrid.Rows[i].Cells["BASIC_STOCK"].Value = dt.Rows[i]["BASIC_STOCK"].ToString();
                        dataItemGrid.Rows[i].Cells["BAL_STOCK"].Value = dt.Rows[i]["BAL_STOCK"].ToString();
                        dataItemGrid.Rows[i].Cells["PROP_STOCK"].Value = dt.Rows[i]["PROP_STOCK"].ToString();
                        dataItemGrid.Rows[i].Cells[4].Value = "0";
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
        }

        private void dataItemGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = null;

                txt_item_Cd.Text = dataItemGrid.Rows[e.RowIndex].Cells["ITEM_CD"].Value.ToString();

                dt = wDm.fn_Item_Detail_Stock_List(txt_item_Cd.Text);

                this.datadetaiIGrid.RowCount = dt.Rows.Count;

                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        datadetaiIGrid.Rows[i].Cells["RAW_DATE"].Value = dt.Rows[i]["INPUT_DATE"].ToString();
                        datadetaiIGrid.Rows[i].Cells["LOT_NO"].Value = dt.Rows[i]["LOT_NO"].ToString();
                        datadetaiIGrid.Rows[i].Cells["INPUT_CNT"].Value = (decimal.Parse(dt.Rows[i]["입고량"].ToString())).ToString("#,0.######");
                        datadetaiIGrid.Rows[i].Cells["OUTPUT_CNT"].Value = (decimal.Parse(dt.Rows[i]["출고량"].ToString())).ToString("#,0.######");
                        datadetaiIGrid.Rows[i].Cells["TOTAL_CNT"].Value = (decimal.Parse(dt.Rows[i]["재고량"].ToString())).ToString("#,0.######");
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

        private void clear_Click(object sender, EventArgs e)
        {
            dataItemGrid.Rows.Clear();
            datadetaiIGrid.Rows.Clear();
        }
    }
}
