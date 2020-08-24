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
    public partial class frm제품출고현황 : Form
    {
        public frm제품출고현황()
        {
            InitializeComponent();
        }
        public static bool p_IsAuth = true;    // 열람권한
        public static bool p_Isrgstr = true;    //등록/수정 권한
        wnDm wnDm = new wnDm();

        public static bool p_Isdel = true;    // 삭제 권한
        private void frm제품출고현황_Load(object sender, EventArgs e)
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
            addButton(txt_Itemcd, 0);
            start_date.Text = DateTime.Today.AddMonths(-1).ToString("yyyy-MM-dd");
        }

        #region button logic 
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void btnSrch_Click(object sender, EventArgs e)
        {
            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = null;
                dt = wDm.납품추적_List("where A.OUTPUT_DATE >= '" + start_date.Text.ToString() + "' and  A.OUTPUT_DATE <= '" + end_date.Text.ToString() + "' AND B.ITEM_NM LIKE '%" + txt_Itemcd.Text.ToString() + "%' ");

                itemOutGrid.Rows.Clear();

                if (dt != null && dt.Rows.Count > 0)
                {
                    this.itemOutGrid.RowCount = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        itemOutGrid.Rows[i].Cells["OUTPUT_DATE"].Value = dt.Rows[i]["OUTPUT_DATE"].ToString();
                       // itemOutGrid.Rows[i].Cells["OUTPUT_CD"].Value = dt.Rows[i]["OUTPUT_CD"].ToString();
                        //itemOutGrid.Rows[i].Cells["SEQ"].Value = dt.Rows[i]["SEQ"].ToString();
                        itemOutGrid.Rows[i].Cells["LOT_NO"].Value = dt.Rows[i]["LOT_NO"].ToString();
                        itemOutGrid.Rows[i].Cells["CUST_NM"].Value = dt.Rows[i]["CUST_NM"].ToString();
                        itemOutGrid.Rows[i].Cells["ITEM_CD"].Value = dt.Rows[i]["ITEM_CD"].ToString();
                        itemOutGrid.Rows[i].Cells["ITEM_NM"].Value = dt.Rows[i]["ITEM_NM"].ToString();
                        itemOutGrid.Rows[i].Cells["SPEC"].Value = dt.Rows[i]["SPEC"].ToString();
                        itemOutGrid.Rows[i].Cells["OUTPUT_AMT"].Value = (decimal.Parse(dt.Rows[i]["OUTPUT_AMT"].ToString())).ToString("#,0.######");
                        itemOutGrid.Rows[i].Cells["PRICE"].Value = (decimal.Parse(dt.Rows[i]["PRICE"].ToString())).ToString("#,0.######");
                        itemOutGrid.Rows[i].Cells["TOTAL_MONEY"].Value = (decimal.Parse(dt.Rows[i]["TOTAL_MONEY"].ToString())).ToString("#,0.######");
                    }
                }
                else
                {
                    itemOutGrid.Rows.Clear();
                }
            }
            catch (Exception ex)
            {
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message+" - "+ex.ToString()); msg.ShowDialog();
            }
        }

        #endregion button logic

        private void itemOutGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                txt_Itemcd.Text = itemOutGrid.Rows[e.RowIndex].Cells["ITEM_NM"].Value.ToString();
                String strLOT_NO = itemOutGrid.Rows[e.RowIndex].Cells["LOT_NO"].Value.ToString();
                string condition = "WHERE D.ITEM_NM = '" + txt_Itemcd.Text + "' and  A.LOT_NO='" + strLOT_NO + "'";
                //DetailGrid(condition);            
            }
        }

        /*
        private void DetailGrid(string condition)
        {
            wnDm wDm = new wnDm();
            DataTable dt = null;        
            dt = wDm.납품추적_Detail_List(condition);

            if (dt != null && dt.Rows.Count > 0)
            {
                outDetailGrid.RowCount = dt.Rows.Count;
                for (int i = 0; i < outDetailGrid.Rows.Count; i++)
                {
                    outDetailGrid.Rows[i].Cells["FLOW_NM"].Value = dt.Rows[i]["FLOW_NM"].ToString();
                    outDetailGrid.Rows[i].Cells["공정순서"].Value = dt.Rows[i]["F_STEP"].ToString();
                    outDetailGrid.Rows[i].Cells["FLOW_DATE"].Value = dt.Rows[i]["FLOW_DATE"].ToString();
                    outDetailGrid.Rows[i].Cells["NO"].Value = dt.Rows[i]["SEQ"].ToString();
                    outDetailGrid.Rows[i].Cells["AMT"].Value = (decimal.Parse(dt.Rows[i]["OUTPUT_AMT"].ToString())).ToString("#,0.######");
                    outDetailGrid.Rows[i].Cells["WEIGHT"].Value = (decimal.Parse(dt.Rows[i]["ITEM_WEIGHT"].ToString())).ToString("#,0.######");
                   // outDetailGrid.Rows[i].Cells["COMMENT"].Value = dt.Rows[i]["PLAN_DATE"].ToString();                       
                    
                }
            }
        }
        */

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
                    Txtbtn[type].Click += new EventHandler(txttype_DropDown);

                    break;

                default:
                    break;
            }
            Txtbtn[type].Show();
        }

        private void txttype_DropDown(object sender, EventArgs e)
        {
            serch();
        }

        private void txt_Itemcd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                serch();
            }
            else
            {

            }
        }
        String old_item_nm;
        private void serch()
        {
            Popup.pop_sf_제품검색 frm = new Popup.pop_sf_제품검색();
            frm.txtSrch.Text = txt_Itemcd.Text.ToString();
            frm.ShowDialog();
            if (frm.sCode != "")
            {
                itemccc.Text = frm.sCode.Trim();
                txt_Itemcd.Text = frm.sName.Trim();
                old_item_nm = frm.sCode.Trim();

            }
            else
            {
                itemccc.Text = old_item_nm;
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
                    brnSrch.PerformClick();
                    break;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
            return true;
        }
     
    }
}
