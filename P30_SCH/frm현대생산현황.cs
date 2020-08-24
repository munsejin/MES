using MES.CLS;
using MES.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MES.P30_SCH
{
    public partial class frm현대생산현황 : Form
    {
        wnDm wDm = new wnDm();
        private wnGConstant wConst = new wnGConstant();


        public frm현대생산현황()
        {
            InitializeComponent();
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
                    Txtbtn[type].Click += new EventHandler(btnCustSrch_Click);

                    break;
                case 1:
                    Txtbtn[type].Click += new EventHandler(btnItemSrch_Click);

                    break;

                default:
                    break;
            }
            Txtbtn[type].Show();
        }

        private void btnItemSrch_Click(object sender, EventArgs e)
        {
            Popup.pop_sf_제품검색 frm = new Popup.pop_sf_제품검색();
            wnDm wDm = new wnDm();
            DataTable dt = new DataTable();
            dt = wDm.fn_Item_List("where ITEM_NM like '%" + txt_Item.Text.ToString() + "%'  and ITEM_GUBUN='2'");

            //frm.sUsedYN = sUsedYN;
            frm.dt = dt;
            frm.txtSrch.Text = txt_Item.Text.ToString();
            frm.ShowDialog();

            if (frm.sCode != "")
            {
                txt_Item.Tag = frm.sCode.Trim();
                txt_Item.Text = frm.sName.Trim();
                old_item_nm = frm.sCode.Trim();



            }
            else
            {
                txt_Item.Tag = old_item_nm;
            }
            txt_Item.Focus();
        }
        string old_cust_nm = "";

        private void btnCustSrch_Click(object sender, EventArgs e)
        {
            Popup.pop거래처검색 frm = new Popup.pop거래처검색("납품처");

            frm.sCustGbn = "1";
            frm.sCustNm = txt_Cust.Text.ToString();
            frm.ShowDialog();

            if (frm.sCode != "")
            {
                txt_Cust.Tag = frm.sCode.Trim();
                txt_Cust.Text = frm.sName.Trim();
                
                old_cust_nm = frm.sCode.Trim();
               
            }
            else
            {
                txt_Item.Tag = old_cust_nm;
            }

            frm.Dispose();
            frm = null;
        }
        String old_item_nm;
        private void frm현대생산현황_Load(object sender, EventArgs e)
        {
         


            end_date.Value = DateTime.Now;



            start_date.Value = DateTime.Now.Date.AddDays(1 - end_date.Value.Day); //그 달의 첫날 
            addButton(txt_Item, 1);
            addButton(txt_Cust, 0);
            txt_Item.Tag = "";

            bind("");
        }


        private void bind(String condition)
        {
            flowProdGrid.Rows.Clear();

            DataTable dt = new DataTable();
            wnDm wDm = new wnDm();

            
            

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" and (A.F_SUB_DATE >= '" + start_date.Text.ToString() + "' and A.F_SUB_DATE <= '" + end_date.Text.ToString() + "') ");

            sb.AppendLine(condition);
            dt = wDm.현대생산현황(sb.ToString());
            flowProdGrid.Rows.Clear();
            flowProdGrid.RowCount = dt.Rows.Count;
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {



                    flowProdGrid.Rows[i].Cells["FLOW_NM"].Value = dt.Rows[i]["FLOW_NM"].ToString();
                    flowProdGrid.Rows[i].Cells["지시수량"].Value = (decimal.Parse(dt.Rows[i]["INST_AMT"].ToString())).ToString("#,0");
                    
                    flowProdGrid.Rows[i].Cells["F_SUB_AMT"].Value = (decimal.Parse(dt.Rows[i]["F_SUB_AMT"].ToString())).ToString("#,0");

                    flowProdGrid.Rows[i].Cells["ITEM_NM"].Value = dt.Rows[i]["ITEM_NM"].ToString();
                    flowProdGrid.Rows[i].Cells["납품처"].Value = dt.Rows[i]["CUST_NM"].ToString();
                    flowProdGrid.Rows[i].Cells["잔여수량"].Value = decimal.Parse(flowProdGrid.Rows[i].Cells["지시수량"].Value.ToString()) - decimal.Parse(flowProdGrid.Rows[i].Cells["F_SUB_AMT"].Value.ToString());

                    if (decimal.Parse(flowProdGrid.Rows[i].Cells["잔여수량"].Value.ToString())<0)
                    {
                        flowProdGrid.Rows[i].Cells["잔여수량"].Value = decimal.Parse(flowProdGrid.Rows[i].Cells["잔여수량"].Value.ToString()) * -1;

                        flowProdGrid.Rows[i].Cells["잔여수량"].Style.BackColor = Color.Red;
                        flowProdGrid.Rows[i].Cells["잔여수량"].Style.ForeColor = Color.White;
                    }
                }
                wConst.mergeCells(flowProdGrid,2);
            }
           
        }

        private void flowProdGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            String condition2 = "";
            if (txt_Item.Text!="")
            {
                condition2 += "and  A.ITEM_CD ='" + txt_Item.Tag.ToString() + "'";
            }
            if (txt_Cust.Text != "")
            {
                condition2 += "and  A.CUST_CD ='" + txt_Cust.Tag.ToString() + "'";
            }
           
            bind(condition2);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
