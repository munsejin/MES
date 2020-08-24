using System;
using System.Collections;
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
    public partial class frm일일매입원장 : Form
    {
        Popup.frmPrint readyPrt = new Popup.frmPrint();
        private wnGConstant wConst = new wnGConstant();

        DataTable adoPrt = null;
        DataTable adoPrt2 = null;
        wnAdo wAdo = new wnAdo();
        public Popup.frmPrint frmPrt;

        public string strDay1 = "";
        public string strDay2 = "";
        public string strCondition = "";

        public frm일일매입원장()
        {
            InitializeComponent();
        }

        private void frm일일매입원장_Load(object sender, EventArgs e)
        {
            lbl_title.Tag = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[0] + "$" + wnDm.fn_TitleName(this.Name.ToString()).Split('$')[1]; lbl_title.Text = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[2];

            ComInfo.gridHeaderSet(inputRmGrid);

            start_date.Text = DateTime.Today.AddMonths(-1).ToString("yyyy-MM-dd");

            grdCellSetting();


            

        }

        #region button logic

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            lblMsg.Visible = true;
            Application.DoEvents();
            in_grid_logic();
            //in_grade_logic();
            calBalance_logic();
            wnGConstant wng = new wnGConstant();
            wng.mergeCells(inputRmGrid, 3);
            lblMsg.Visible = false;

        }

        private void calBalance_logic()
        {
            decimal lastBalance = 0;

            for (int i = 1; i < inputRmGrid.Rows.Count; i++)
            {
                switch (inputRmGrid.Rows[i].Cells["SALES_DATE"].Value.ToString())
                {
                    case "-- 전잔고 --" :
                        lastBalance = decimal.Parse(inputRmGrid.Rows[i].Cells["BALANCE"].Value.ToString().Replace(",", ""));
                        break;
                    case "=== 소계 ===" :
                        lastBalance = 0;
                        break;
                    case "=== 합계 ===" :
                        lastBalance = 0;
                        inputRmGrid.Rows[i].Cells["BALANCE"].Value = "";
                        break;
                    default :
                        decimal temp = 0;
                        if (inputRmGrid.Rows[i].Cells["TOTAL_MONEY"].Value != null && !inputRmGrid.Rows[i].Cells["TOTAL_MONEY"].Value.ToString().Equals(""))
                        {
                            if (inputRmGrid.Rows[i].Cells["INPUT_GUBUN"].Value.ToString().Contains("반품"))
                            {
                                temp = decimal.Parse(inputRmGrid.Rows[i].Cells["TOTAL_MONEY"].Value.ToString().Replace(",", ""));
                                inputRmGrid.Rows[i].Cells["BALANCE"].Value = (lastBalance - temp).ToString("#,0.######");
                                lastBalance -= temp;
                            }
                            else
                            {
                                temp = decimal.Parse(inputRmGrid.Rows[i].Cells["TOTAL_MONEY"].Value.ToString().Replace(",", ""));
                                inputRmGrid.Rows[i].Cells["BALANCE"].Value = (lastBalance + temp).ToString("#,0.######");
                                lastBalance += temp;
                            }
                        }
                        else if (inputRmGrid.Rows[i].Cells["TOTAL_SOO_MONEY"].Value != null && !inputRmGrid.Rows[i].Cells["TOTAL_SOO_MONEY"].Value.ToString().Equals(""))
                        {
                            temp = decimal.Parse(inputRmGrid.Rows[i].Cells["TOTAL_SOO_MONEY"].Value.ToString().Replace(",", ""));
                            inputRmGrid.Rows[i].Cells["BALANCE"].Value = (lastBalance - temp).ToString("#,0.######");
                            lastBalance -= temp;
                        }
                        else
                        {
                            inputRmGrid.Rows[i].Cells["BALANCE"].Value = (lastBalance + temp).ToString("#,0.######");
                            lastBalance += temp;
                        }
                        break;
                        
                }            
            }
        }

        #endregion button logic

       
           
        private void in_grid_logic()
        {
            wnDm wDm = new wnDm();
            DataTable dt = null;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("and Z.BUY_DATE >= '" + start_date.Text.ToString() + "' and  Z.BUY_DATE <= '" + end_date.Text.ToString() + "'   ");


            dt = wDm.fn_Buy_Day_Ledger_List(sb.ToString(), start_date.Text.ToString(), end_date.Text.ToString());

            inputRmGrid.Rows.Clear();

            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //string t_amt = string.Format("{0:#.##}", 100.2);
                    inputRmGrid.Rows.Add();

                    inputRmGrid.Rows[i].Cells["SALES_DATE"].Value = dt.Rows[i]["일자명칭"].ToString();
                    if (dt.Rows[i]["일자명칭"].ToString().ToString().Equals("=== 소계 ==="))
                    {
                        DataGridViewCellStyle style = new DataGridViewCellStyle();
                        style.BackColor = Color.DarkTurquoise;
                        style.SelectionBackColor = Color.DarkCyan;
                        style.ForeColor = Color.Black;
                        style.SelectionForeColor = Color.White;
                        //style.BackColor = Color.DarkGray;
                        //style.SelectionBackColor = Color.Gray;
                        //style.ForeColor = Color.Black;
                        //style.SelectionForeColor = Color.Black;
                        for (int j = 4; j < inputRmGrid.ColumnCount; j++)
                        {
                            inputRmGrid.Rows[i].Cells[j].Style = style;
                        }
                    }
                    else if (dt.Rows[i]["일자명칭"].ToString().ToString().Equals("=== 합계 ==="))
                    {
                        DataGridViewCellStyle style = new DataGridViewCellStyle();
                        style.BackColor = Color.Khaki;
                        style.SelectionBackColor = Color.DarkKhaki;
                        style.ForeColor = Color.Blue;
                        for (int j = 0; j < inputRmGrid.ColumnCount; j++)
                        {
                            inputRmGrid.Rows[i].Cells[j].Style = style;
                        }
                    }

                    if (dt.Rows[i]["SALES_CD"].ToString().Equals("999999") || dt.Rows[i]["SALES_CD"].ToString().Equals("0"))
                    {
                        inputRmGrid.Rows[i].Cells["SALES_CD"].Value = "";
                    }
                    else
                    {
                        inputRmGrid.Rows[i].Cells["SALES_CD"].Value = dt.Rows[i]["SALES_CD"].ToString();
                    }
                    inputRmGrid.Rows[i].Cells["NO"].Value = (dt.Rows[i]["bun"].ToString().Equals("ㅎ") || dt.Rows[i]["bun"].ToString().Equals("ㄱ") ? "" : dt.Rows[i]["bun"].ToString());
                    if (dt.Rows[i]["VAT_CD"].ToString().Equals("2"))
                    {
                        inputRmGrid.Rows[i].Cells["INPUT_GUBUN"].Value = "(" + dt.Rows[i]["INPUT_GUBUN"].ToString() + ")";
                    }
                    else
                    {
                        inputRmGrid.Rows[i].Cells["INPUT_GUBUN"].Value = dt.Rows[i]["INPUT_GUBUN"].ToString();
                    }
                    inputRmGrid.Rows[i].Cells["PRODUCT_NM"].Value = dt.Rows[i]["PRODUCT_NM"].ToString();
                    inputRmGrid.Rows[i].Cells["CUST_NM"].Value = dt.Rows[i]["CUST_NM"].ToString();
                    

                    inputRmGrid.Rows[i].Cells["LABEL_NM"].Value = dt.Rows[i]["SPEC"].ToString();

                    inputRmGrid.Rows[i].Cells["TOTAL_AMT"].Value = (decimal.Parse(dt.Rows[i]["TOTAL_AMT"].ToString())).ToString("#,0.######");
                    inputRmGrid.Rows[i].Cells["TOTAL_PRICE"].Value = (decimal.Parse(dt.Rows[i]["TOTAL_PRICE"].ToString())).ToString("#,0.######");
                    inputRmGrid.Rows[i].Cells["TOTAL_SUPPLY_MONEY"].Value = (decimal.Parse(dt.Rows[i]["TOTAL_SUPPLY_MONEY"].ToString())).ToString("#,0.######");
                    inputRmGrid.Rows[i].Cells["TOTAL_TAX_MONEY"].Value = (decimal.Parse(dt.Rows[i]["TOTAL_TAX_MONEY"].ToString())).ToString("#,0.######");
                    inputRmGrid.Rows[i].Cells["TOTAL_MONEY"].Value = (decimal.Parse(dt.Rows[i]["TOTAL_MONEY"].ToString())).ToString("#,0.######");
                    inputRmGrid.Rows[i].Cells["SOO_MONEY"].Value = (decimal.Parse(dt.Rows[i]["SOO_MONEY"].ToString())).ToString("#,0.######");
                    inputRmGrid.Rows[i].Cells["DC_MONEY"].Value = (decimal.Parse(dt.Rows[i]["DC_MONEY"].ToString())).ToString("#,0.######");
                    inputRmGrid.Rows[i].Cells["TOTAL_SOO_MONEY"].Value = (decimal.Parse(dt.Rows[i]["TOTAL_SOO_MONEY"].ToString())).ToString("#,0.######");
                    inputRmGrid.Rows[i].Cells["BALANCE"].Value = (decimal.Parse(dt.Rows[i]["BALANCE"].ToString())).ToString("#,0.######");

                    if (inputRmGrid.Rows[i].Cells["TOTAL_AMT"].Value == null || inputRmGrid.Rows[i].Cells["TOTAL_AMT"].Value.ToString().Equals("0"))
                    {
                        inputRmGrid.Rows[i].Cells["TOTAL_AMT"].Value = "";
                    }
                    if (inputRmGrid.Rows[i].Cells["TOTAL_PRICE"].Value == null || inputRmGrid.Rows[i].Cells["TOTAL_PRICE"].Value.ToString().Equals("0"))
                    {
                        inputRmGrid.Rows[i].Cells["TOTAL_PRICE"].Value = "";
                    }
                    if (inputRmGrid.Rows[i].Cells["TOTAL_SUPPLY_MONEY"].Value == null || inputRmGrid.Rows[i].Cells["TOTAL_SUPPLY_MONEY"].Value.ToString().Equals("0"))
                    {
                        inputRmGrid.Rows[i].Cells["TOTAL_SUPPLY_MONEY"].Value = "";
                    }
                    if (inputRmGrid.Rows[i].Cells["TOTAL_TAX_MONEY"].Value == null || inputRmGrid.Rows[i].Cells["TOTAL_TAX_MONEY"].Value.ToString().Equals("0"))
                    {
                        inputRmGrid.Rows[i].Cells["TOTAL_TAX_MONEY"].Value = "";
                    }
                    if (inputRmGrid.Rows[i].Cells["TOTAL_MONEY"].Value == null || inputRmGrid.Rows[i].Cells["TOTAL_MONEY"].Value.ToString().Equals("0"))
                    {
                        inputRmGrid.Rows[i].Cells["TOTAL_MONEY"].Value = "";
                    }
                    if (inputRmGrid.Rows[i].Cells["SOO_MONEY"].Value == null || inputRmGrid.Rows[i].Cells["SOO_MONEY"].Value.ToString().Equals("0"))
                    {
                        inputRmGrid.Rows[i].Cells["SOO_MONEY"].Value = "";
                    }
                    if (inputRmGrid.Rows[i].Cells["DC_MONEY"].Value == null || inputRmGrid.Rows[i].Cells["DC_MONEY"].Value.ToString().Equals("0"))
                    {
                        inputRmGrid.Rows[i].Cells["DC_MONEY"].Value = "";
                    }
                    if (inputRmGrid.Rows[i].Cells["TOTAL_SOO_MONEY"].Value == null || inputRmGrid.Rows[i].Cells["TOTAL_SOO_MONEY"].Value.ToString().Equals("0"))
                    {
                        inputRmGrid.Rows[i].Cells["TOTAL_SOO_MONEY"].Value = "";
                    }

                }
            }

            //데이타 끝나고 다시 copy를 써준 이유는 for중에 no에 값을 엏었기 때문에 출력물 데이타테이블(dt)를 다시 복사함
        }

        private void grdCellSetting()
        {
            ComInfo comInfo = new ComInfo();
            comInfo.grdCellSetting2(inputRmGrid);
        }

        private void btn출력_Click(object sender, EventArgs e)
        {
            
            btn출력.Enabled = false;

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Save as Excel File";
            sfd.Filter = "Excel 통합 문서 (*.xlsx)|*.xlsx|Excel 97 - 2003 통합문서(*.xls)|*.xls";
            if (start_date.Text.ToString().Equals(end_date.Text.ToString()))
            {
                sfd.FileName = start_date.Text + " 매입일지";
            }
            else
            {
                sfd.FileName = start_date.Text + " ~ " + end_date.Text + " 매입일지";
            }
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                lblMsg.Visible = true;
                Application.DoEvents();
                wnGConstant.dataGridView_ExportToExcel_Day(sfd.FileName, inputRmGrid);
                lblMsg.Visible = false;
                MessageBox.Show("엑셀 출력이 완료되었습니다");
            }




            btn출력.Enabled = true;

        }

        private void btnRaw_Click(object sender, EventArgs e)
        {
            Popup.pop원자재검색 frm = new Popup.pop원자재검색();

            //frm.sUsedYN = sUsedYN;
            frm.ShowDialog();

            if (frm.sRetCode != "")
            {
                //cmb_raw.SelectedValue = frm.sRetCode.Trim();
            }

            frm.Dispose();
            frm = null;
        }

        private void btnCust_Click(object sender, EventArgs e)
        {
            Popup.pop거래처검색 frm = new Popup.pop거래처검색();

            frm.sCustGbn = "2";
            frm.ShowDialog();

            if (frm.sCode != "")
            {
               // cmb_cust.SelectedValue = frm.sCode.Trim();
            }

            frm.Dispose();
            frm = null;
        }

        private void cmb_raw_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComInfo.onlyNum(sender, e);

            //if (cmb_raw.Text.Length >= 14)
            //{
            //    StringBuilder sb = new StringBuilder();
            //    sb.AppendLine(" and CONVERT(NVARCHAR(8),CONVERT (DATE, A.INPUT_DATE),112) ");
            //    sb.AppendLine(" +RIGHT('000'+CONVERT(varchar,A.INPUT_CD),4) ");
            //    sb.AppendLine(" +RIGHT('0'+CONVERT(varchar,A.SEQ),2) = '"+cmb_raw.Text.ToString() +"' ");

            //    in_rm_ledger_logic(sb.ToString());
            //}
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
                    break;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
            return true;
        }

        

       
    }
}
