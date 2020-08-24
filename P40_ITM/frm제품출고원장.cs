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
    public partial class frm제품출고원장 : Form
    {
        public frm제품출고원장()
        {
            InitializeComponent();
        }
        private wnGConstant wConst = new wnGConstant();
        wnDm wnDm = new wnDm();
        public static bool p_IsAuth = true;    // 열람권한
        public static bool p_Isrgstr = true;    //등록/수정 권한

        public static bool p_Isdel = true;    // 삭제 권한
        private void frm제품출고원장_Load(object sender, EventArgs e)
        {
            addButton(txtType, 0);
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
            cboType.SelectedIndex = 0;
            start_date.Text = DateTime.Today.AddMonths(-1).ToString("yyyy-MM-dd");

            GridList();


            ComInfo.gridHeaderSet(itemOutGrid);
        }

        Button[] Txtbtn = new Button[2];
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
                    Txtbtn[type].Click += new EventHandler(txttype_DropDown);

                    break;

                default:
                    break;
            }
            Txtbtn[type].Show();
        }

      

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSrch_Click(object sender, EventArgs e)
        {
            GridList();
        }

        private void GridList()
        {
            itemOutGrid.Rows.Clear();

            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = null;
                String condition = "where A.OUTPUT_DATE >= '" + start_date.Text.ToString() + "' and  A.OUTPUT_DATE <= '" + end_date.Text.ToString() + "'";
                if (txtType.Text != "")
                {
                    switch (cboType.SelectedIndex)
                    {
                        case 1:
                            condition += "and B.ITEM_CD = '" + txtcode.Text + "' ";
                            break;
                        case 2:
                            condition += "and A.CUST_CD =  '" + txtcode.Text + "' ";

                            break;

                        default:
                            break;
                    }
                }

                dt = wDm.fn_Item_Output_Detail_ledger(condition);

                this.itemOutGrid.RowCount = dt.Rows.Count;
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        itemOutGrid.Rows[i].Cells["OUTPUT_DATE"].Value = dt.Rows[i]["OUTPUT_DATE"].ToString();
                        itemOutGrid.Rows[i].Cells["OUTPUT_CD"].Value = dt.Rows[i]["OUTPUT_CD"].ToString();
                        itemOutGrid.Rows[i].Cells["SEQ"].Value = dt.Rows[i]["SEQ"].ToString();
                        itemOutGrid.Rows[i].Cells["LOT_NO"].Value = dt.Rows[i]["LOT_NO"].ToString();
                        itemOutGrid.Rows[i].Cells["CUST_NM"].Value = dt.Rows[i]["CUST_NM2"].ToString();
                        itemOutGrid.Rows[i].Cells["ITEM_CD"].Value = dt.Rows[i]["ITEM_CD"].ToString();
                        itemOutGrid.Rows[i].Cells["ITEM_NM"].Value = dt.Rows[i]["ITEM_NM"].ToString();
                        itemOutGrid.Rows[i].Cells["SPEC"].Value = dt.Rows[i]["SPEC"].ToString();
                        itemOutGrid.Rows[i].Cells["OUTPUT_AMT"].Value = (decimal.Parse(dt.Rows[i]["OUTPUT_AMT"].ToString())).ToString("#,0.######");
                        itemOutGrid.Rows[i].Cells["PRICE"].Value = (decimal.Parse(dt.Rows[i]["PRICE"].ToString())).ToString("#,0.######");
                        itemOutGrid.Rows[i].Cells["TOTAL_MONEY"].Value = (decimal.Parse(dt.Rows[i]["TOTAL_MONEY"].ToString())).ToString("#,0.######");
                        itemOutGrid.Rows[i].Cells["계획번호"].Value = dt.Rows[i]["PLAN_NUM"].ToString();

                        if (dt.Rows[i]["PLAN_NUM"].ToString()=="합계")
                        {
                            itemOutGrid.Rows[i].Cells["OUTPUT_DATE"].Value = "";
                            itemOutGrid.Rows[i].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                            itemOutGrid.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                        }
                    }
                    wConst.mergeCells(itemOutGrid, 1);

                }
                else
                {
                    itemOutGrid.Rows.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("시스템 오류");
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                msg.ShowDialog();
            }
        }
        String old_item_nm;
        private void clear_Click(object sender, EventArgs e)
        {
            itemOutGrid.Rows.Clear();
        }

        private void serch()
        {
            switch (cboType.SelectedIndex)
            {
                case 1:
                    Popup.pop_sf_제품검색 frm = new Popup.pop_sf_제품검색();
                    frm.txtSrch.Text = txtType.Text.ToString();
                    frm.ShowDialog();
                    if (frm.sCode != "")
                    {
                        txtcode.Text = frm.sCode.Trim();
                        txtType.Text = frm.sName.Trim();
                        old_item_nm = frm.sCode.Trim();

                    }
                    else
                    {
                        txtcode.Text = old_item_nm;
                    }
                    break;
                case 2:
                    Popup.pop거래처검색 frm2 = new Popup.pop거래처검색("납품처");

                    frm2.sCustGbn = "1";
                    frm2.sCustNm = txtType.Text.ToString();
                    frm2.ShowDialog();

                    if (frm2.sCode != "")
                    {
                        txtcode.Text = frm2.sCode.Trim();
                        txtType.Text = frm2.sName.Trim();
                        old_item_nm = frm2.sCode.Trim();

                    }
                    else
                    {
                        txtcode.Text = old_item_nm;
                    }
                    break;

                default:
                    break;
            }

        }
        private void txttype_DropDown(object sender, EventArgs e)
        {
            serch();
        }
        private void txtType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                serch();
            }

            else
            {
                return;
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
