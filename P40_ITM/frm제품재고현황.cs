using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MES.CLS;
using MES.Controls;

namespace MES.P40_ITM
{
    public partial class frm제품재고현황 : Form
    {
        DataTable adoPrt = null;
        wnAdo wAdo = new wnAdo();
        public Popup.frmPrint frmPrt;

        public frm제품재고현황()
        {
            InitializeComponent();

           // this.dataItemGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellEndEdit);

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
        wnDm wnDm = new wnDm();
        public static bool p_IsAuth = true;    // 열람권한
        public static bool p_Isrgstr = true;    //등록/수정 권한

        public static bool p_Isdel = true;    // 삭제 권한
        private void frm제품재고현황_Load(object sender, EventArgs e)
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

            GridList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSrch_Click(object sender, EventArgs e)
        {
            GridList();
            lbl_item_nm.Text = "";
        }

        private void GridList()
        {
            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = null;
                StringBuilder sb = new StringBuilder();
                if (txt_srch.Text != null && !txt_srch.Text.ToString().Equals(""))
                {
                    sb.AppendLine("and A.ITEM_NM LIKE '%" + txt_srch.Text.ToString() + "%' ");
                }
                else
                {
                    txt_item_Cd.Text = "";
                }

                if (txt_item_Cd.Text != null && !txt_item_Cd.Text.ToString().Equals(""))
                {
                    sb.AppendLine("and A.ITEM_CD = '"+txt_item_Cd.Text.ToString() + "' ");
                }

                if (btn_stock_ok.Checked)
                {
                    sb.AppendLine(" and A.BAL_STOCK > 0 ");
                }
                else
                {
                    sb.AppendLine(" and A.BAL_STOCK <= 0 ");
                }

                dt = wDm.fn_Item_Stock_List(sb.ToString());

                txt_item_Cd.Text = "";
                dataItemGrid.Rows.Clear();
                if (dt != null && dt.Rows.Count > 0)
                {
                    this.dataItemGrid.RowCount = dt.Rows.Count;

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dataItemGrid.Rows[i].Cells["ITEM_CD"].Value = dt.Rows[i]["ITEM_CD"].ToString();
                        dataItemGrid.Rows[i].Cells["ITEM_NM"].Value = dt.Rows[i]["ITEM_NM"].ToString();
                        dataItemGrid.Rows[i].Cells["SPEC"].Value = dt.Rows[i]["SPEC"].ToString();
                        //천단위마다 콤마 추가
                        dataItemGrid.Rows[i].Cells["BASIC_STOCK"].Value = (decimal.Parse(dt.Rows[i]["BASIC_STOCK"].ToString())).ToString("#,0.######");
                        dataItemGrid.Rows[i].Cells["BAL_STOCK"].Value = (decimal.Parse(dt.Rows[i]["BAL_STOCK"].ToString())).ToString("#,0.######");
                        dataItemGrid.Rows[i].Cells["PROP_STOCK"].Value = (decimal.Parse(dt.Rows[i]["PROP_STOCK"].ToString())).ToString("#,0.######");
                        dataItemGrid.Rows[i].Cells["POOR_AMT"].Value = (decimal.Parse(dt.Rows[i]["POOR_AMT"].ToString())).ToString("#,0.######");
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
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                msg.ShowDialog();
            }

            datadetaiIGrid.Rows.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
                  

            wnDm wDm = new wnDm();
            int rsNum = wDm.UpdateStock(
                            txt_item_Cd.Text.ToString()
                            , txt_bal_stock.Text.ToString()
                            , txt_prop_stock.Text.ToString()
                            , txt_basic_stock.Text.ToString()                           
                            );

            if (rsNum == 0)
            {                
                MessageBox.Show("성공적으로 수정하였습니다.");
            }
            else if (rsNum == 1)
                MessageBox.Show("저장에 실패하였습니다");
            else
                MessageBox.Show("Exception 에러");

            dataItemGrid.Rows.Clear();
            datadetaiIGrid.Rows.Clear();
        }      

        private void datadetaiIGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            txt_prop_stock.Text = datadetaiIGrid.Rows[e.RowIndex].Cells["INPUT_CNT"].Value.ToString();
            txt_basic_stock.Text = datadetaiIGrid.Rows[e.RowIndex].Cells["OUTPUT_CNT"].Value.ToString();
            txt_bal_stock.Text = datadetaiIGrid.Rows[e.RowIndex].Cells["TOTAL_CNT"].Value.ToString();
        }

        private void clear_Click(object sender, EventArgs e)
        {
            dataItemGrid.Rows.Clear();
            datadetaiIGrid.Rows.Clear();
            GridList();
        }

        private void txt_srch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
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

            else
            {
                return;
            } 
        }

        private void dataItemGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                try
                {
                    wnDm wDm = new wnDm();
                    DataTable dt = null;

                    txt_item_Cd.Text = dataItemGrid.Rows[e.RowIndex].Cells["ITEM_CD"].Value.ToString();
                    lbl_item_nm.Text = dataItemGrid.Rows[e.RowIndex].Cells["ITEM_NM"].Value.ToString();

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
                            datadetaiIGrid.Rows[i].Cells["불량수"].Value = (decimal.Parse(dt.Rows[i]["POOR_AMT"].ToString())).ToString("#,0.######");
                            //datadetaiIGrid.Rows[i].Cells["ETC"].Value = dt.Rows[i]["BAL_STOCK"].ToString();

                            if (dt.Rows[i]["LOT_NO"].ToString() == "합계")
                            {
                                datadetaiIGrid.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                            }
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
                    Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                    msg.ShowDialog();
                }
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            Keys key = keyData & ~(Keys.Shift | Keys.Control);
            switch (key)
            {
                case Keys.W:
                    // 조합키 사용 시
                    if ((keyData & Keys.Control) != 0)
                    {
                        this.Close();
                    }
                    else return base.ProcessCmdKey(ref msg, keyData);
                    break;
                case Keys.S:
                    // 조합키 사용 시
                    if ((keyData & Keys.Control) != 0)
                    {
                    }
                    else return base.ProcessCmdKey(ref msg, keyData);
                    break;
                case Keys.F5:
                    // 단일키 사용시
                    GridList();
                    break;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
            return true;
        }
    }
}
