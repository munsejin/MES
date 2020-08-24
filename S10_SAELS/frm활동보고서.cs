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


namespace MES.S10_SALES
{
    public partial class frm활동보고서 : Form
    {

        private int iCnt;
        private string strValue;
        private wnGConstant wConst;
        private wnDm wdm;
        private string[] sProdCode;
        private string strDay_1 = "";
        private string strMan_1 = "";
        private DataTable adoPrt_1 = null;
        private string strDay_2 = "";
        private string strMan_2 = "";
        private DataTable adoPrt_2 = null;
        private string strDay_3 = "";
        private string strMan_3 = "";
        private DataTable adoPrt_3 = null;

        public frm활동보고서()
        {
            InitializeComponent();
            this.set_Panels();
        }

        private void set_Panels()
        {
            this.pnlData1.Visible = true;
            this.pnlData2.Visible = false;
            this.pnlData1.Top = 2;
            this.pnlData1.Left = 12;
            this.pnlData2.Top = this.pnlData1.Top;
            this.pnlData2.Left = this.pnlData1.Left;
            this.pnlData1.Width = base.Width - 30;
            this.pnlData2.Width = this.pnlData1.Width;
            this.pnlData1.Height = base.Height - 120;
            this.pnlData2.Height = this.pnlData1.Height;
        }

        private void frm활동보고서_Load(object sender, EventArgs e)
        {
            lbl_title.Tag = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[0] + "$" + wnDm.fn_TitleName(this.Name.ToString()).Split('$')[1]; lbl_title.Text = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[2];

            this.tBtn_Click(this.btn매출처별, null);
            this.set_Grid_Prod();
        }

        private void set_Grid_Prod()
        {
            int num = 30;
            this.sProdCode = new string[num];
                    this.GridRecord2.Columns[1].ReadOnly = true;
                    this.GridRecord2.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
                    this.GridRecord2.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    this.GridRecord2.Columns[2].ReadOnly = true;
                    this.GridRecord2.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
                    this.GridRecord2.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    this.GridRecord2.Columns[this.GridRecord2.ColumnCount - 3].ReadOnly = true;
                    this.GridRecord2.Columns[this.GridRecord2.ColumnCount - 3].SortMode = DataGridViewColumnSortMode.NotSortable;
                    this.GridRecord2.Columns[this.GridRecord2.ColumnCount - 3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    this.GridRecord2.Columns[this.GridRecord2.ColumnCount - 2].ReadOnly = true;
                    this.GridRecord2.Columns[this.GridRecord2.ColumnCount - 2].SortMode = DataGridViewColumnSortMode.NotSortable;
                    this.GridRecord2.Columns[this.GridRecord2.ColumnCount - 2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    this.GridRecord2.Columns[this.GridRecord2.ColumnCount - 1].ReadOnly = true;
                    this.GridRecord2.Columns[this.GridRecord2.ColumnCount - 1].SortMode = DataGridViewColumnSortMode.NotSortable;
                    this.GridRecord2.Columns[this.GridRecord2.ColumnCount - 1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    this.GridRecord2.Columns[this.GridRecord2.ColumnCount - 1].DefaultCellStyle.BackColor = Color.Khaki;


                    this.GridRecord.Columns[1].ReadOnly = true;
                    this.GridRecord.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
                    this.GridRecord.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    this.GridRecord.Columns[this.GridRecord.ColumnCount - 6].ReadOnly = true;
                    this.GridRecord.Columns[this.GridRecord.ColumnCount - 6].SortMode = DataGridViewColumnSortMode.NotSortable;
                    this.GridRecord.Columns[this.GridRecord.ColumnCount - 6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    this.GridRecord.Columns[this.GridRecord.ColumnCount - 5].ReadOnly = true;
                    this.GridRecord.Columns[this.GridRecord.ColumnCount - 5].SortMode = DataGridViewColumnSortMode.NotSortable;
                    this.GridRecord.Columns[this.GridRecord.ColumnCount - 5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    this.GridRecord.Columns[this.GridRecord.ColumnCount - 4].ReadOnly = true;
                    this.GridRecord.Columns[this.GridRecord.ColumnCount - 4].SortMode = DataGridViewColumnSortMode.NotSortable;
                    this.GridRecord.Columns[this.GridRecord.ColumnCount - 4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    this.GridRecord.Columns[this.GridRecord.ColumnCount - 3].ReadOnly = true;
                    this.GridRecord.Columns[this.GridRecord.ColumnCount - 3].SortMode = DataGridViewColumnSortMode.NotSortable;
                    this.GridRecord.Columns[this.GridRecord.ColumnCount - 3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    this.GridRecord.Columns[this.GridRecord.ColumnCount - 3].DefaultCellStyle.BackColor = Color.Khaki;
                    this.GridRecord.Columns[this.GridRecord.ColumnCount - 2].ReadOnly = true;
                    this.GridRecord.Columns[this.GridRecord.ColumnCount - 2].SortMode = DataGridViewColumnSortMode.NotSortable;
                    this.GridRecord.Columns[this.GridRecord.ColumnCount - 2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    this.GridRecord.Columns[this.GridRecord.ColumnCount - 2].DefaultCellStyle.BackColor = Color.Khaki;
                    this.GridRecord.Columns[this.GridRecord.ColumnCount - 1].ReadOnly = true;
                    this.GridRecord.Columns[this.GridRecord.ColumnCount - 1].SortMode = DataGridViewColumnSortMode.NotSortable;
                    this.GridRecord.Columns[this.GridRecord.ColumnCount - 1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    this.GridRecord.Columns[this.GridRecord.ColumnCount - 1].DefaultCellStyle.BackColor = Color.Khaki;
                
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void tBtn_Click(object sender, EventArgs e)
        {
            string str = ((Button)sender).Tag.ToString();
            this.btn매출처별.Visible = true;
            this.btn제품별.Visible = true;
            this.btn매출처별.BackColor = Color.White;
            this.btn제품별.BackColor = Color.White;
            this.btn매출처별.FlatAppearance.BorderColor = Color.FromArgb(44, 98, 180);
            this.btn제품별.FlatAppearance.BorderColor = Color.FromArgb(44, 98, 180);
            this.btn매출처별.ForeColor = Color.Black;
            this.btn제품별.ForeColor = Color.Black;
            this.pnlData1.Visible = false;
            this.pnlData2.Visible = false;
            this.btnPrint.Visible = true;
            this.chkA4Sero.Visible = true;
            //if (Common.p_strBox == "3")
            //{
            //    this.chkA4Sero.Visible = false;
            //}
            string str1 = str;
            if (str1 != null)
            {
                if (str1 == "1")
                {
                    this.btn매출처별.BackColor = Color.FromArgb(44, 98, 180);
                    this.btn매출처별.ForeColor = Color.White;
                    this.btn매출처별.FlatAppearance.BorderColor = Color.FromArgb(44, 98, 180);
                    this.pnlData1.Visible = true;
                    return;
                }
                else if (str1 == "2")
                {
                    this.btn제품별.BackColor = Color.FromArgb(44, 98, 180);
                    this.btn제품별.ForeColor = Color.White;
                    this.btn제품별.FlatAppearance.BorderColor = Color.FromArgb(44, 98, 180);
                    this.pnlData2.Visible = true;
                    this.btnPrint.Visible = false;
                    this.chkA4Sero.Visible = false;
                    return;
                }
            }
            this.btn매출처별.BackColor = Color.FromArgb(44, 98, 180);
            this.btn매출처별.ForeColor = Color.White;
            this.btn매출처별.FlatAppearance.BorderColor = Color.FromArgb(44, 98, 180);
            this.pnlData1.Visible = true;
        }



        private void btnSearch_Click(object sender, EventArgs e)
        {
            Label width = this.lblMsg;
            Size clientSize = base.ClientSize;
            width.Left = clientSize.Width / 2 - this.lblMsg.Width / 2;
            Label height = this.lblMsg;
            clientSize = base.ClientSize;
            height.Top = clientSize.Height / 2 - this.lblMsg.Height / 2;
            this.lblMsg.Visible = true;
            this.lblMsg.BringToFront();
            Application.DoEvents();

            this.bindData_월계();
            if (this.pnlData1.Visible)
            {
                this.bindData();
                this.GridRecord.Focus();
            }
            if (this.pnlData2.Visible)
            {
                this.bindData2();
                this.GridRecord2.Focus();
            }
            this.lblMsg.Visible = false;
        }

      

        private void bindData2()
        {

            this.GridRecord2.DataSource = null;
            this.GridRecord2.RowCount = 0;
            this.adoPrt_2 = new DataTable();
            this.strDay_2 = this.dtpDate.Text;
            try
            {
                wdm = new wnDm();
                wConst = new wnGConstant();
                DataTable dt = null;
                dt = wdm.fn_활동보고서_상품별(this.dtpDate.Text);
                //this.adoPrt_2 = dt.Copy();
                if ((dt == null ? true : dt.Rows.Count <= 0))
                {
                    this.GridRecord2.RowCount = 1;
                }
                else
                {
                    this.GridRecord2.RowCount = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        this.GridRecord2.Rows[i].Cells["P_PRODUCT_NM"].Value = dt.Rows[i]["제품명"].ToString();
                        if (dt.Rows[i]["제품명"].ToString().Equals("=== 합계 ==="))
                        {
                            GridRecord2.Rows[i].DefaultCellStyle.BackColor = Color.Khaki;
                            this.GridRecord2.Rows[i].Cells["P_PRODUCT_GUBUN"].Value = "-";
                            this.GridRecord2.Rows[i].Cells["P_UNIT_NM"].Value = "-";
                            this.GridRecord2.Rows[i].Cells["P_PAST_AMT"].Value = "-";
                            this.GridRecord2.Rows[i].Cells["P_TODAY_INPUT"].Value = "-";
                            this.GridRecord2.Rows[i].Cells["P_TODAY_OUTPUT"].Value = "-";
                            this.GridRecord2.Rows[i].Cells["P_TODAY_SALES"].Value = "-";
                            this.GridRecord2.Rows[i].Cells["P_TODAY_SALES_BACK"].Value = "-";
                            this.GridRecord2.Rows[i].Cells["P_CURR_AMT"].Value = "-";
                            this.GridRecord2.Rows[i].Cells["P_SUPPLY_MONEY"].Value = decimal.Parse(dt.Rows[i]["공급가"].ToString()).ToString("#,0.######");
                            this.GridRecord2.Rows[i].Cells["P_TAX_MONEY"].Value = decimal.Parse(dt.Rows[i]["부가세"].ToString()).ToString("#,0.######");
                            this.GridRecord2.Rows[i].Cells["P_TOTAL_MONEY"].Value = decimal.Parse(dt.Rows[i]["합계액"].ToString()).ToString("#,0.######");

                            return;
                        }
                        if (dt.Rows[i]["구분"].ToString().Equals("1"))
                            this.GridRecord2.Rows[i].Cells["P_PRODUCT_GUBUN"].Value = "상품";
                        else
                            this.GridRecord2.Rows[i].Cells["P_PRODUCT_GUBUN"].Value = "제품";
                        this.GridRecord2.Rows[i].Cells["P_UNIT_NM"].Value = dt.Rows[i]["단위"].ToString();
                        this.GridRecord2.Rows[i].Cells["P_PAST_AMT"].Value = decimal.Parse(dt.Rows[i]["당일재고량"].ToString()).ToString("#,0.######");
                        this.GridRecord2.Rows[i].Cells["P_TODAY_INPUT"].Value = decimal.Parse(dt.Rows[i]["입고량"].ToString()).ToString("#,0.######");
                       // this.GridRecord2.Rows[i].Cells["P_TODAY_OUTPUT"].Value = decimal.Parse(dt.Rows[i]["출고량"].ToString()).ToString("#,0.######");
                        this.GridRecord2.Rows[i].Cells["P_TODAY_SALES"].Value = decimal.Parse(dt.Rows[i]["생산출고량"].ToString()).ToString("#,0.######");
                       // this.GridRecord2.Rows[i].Cells["P_TODAY_SALES_BACK"].Value = decimal.Parse(dt.Rows[i]["반품량"].ToString()).ToString("#,0.######");
                        this.GridRecord2.Rows[i].Cells["P_CURR_AMT"].Value = decimal.Parse(dt.Rows[i]["현재고"].ToString()).ToString("#,0.######");
                        this.GridRecord2.Rows[i].Cells["P_SUPPLY_MONEY"].Value = decimal.Parse(dt.Rows[i]["공급가"].ToString()).ToString("#,0.######");
                        this.GridRecord2.Rows[i].Cells["P_TAX_MONEY"].Value = decimal.Parse(dt.Rows[i]["부가세"].ToString()).ToString("#,0.######");
                        this.GridRecord2.Rows[i].Cells["P_TOTAL_MONEY"].Value = decimal.Parse(dt.Rows[i]["합계액"].ToString()).ToString("#,0.######");
                    }
                }
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                wnLog.writeLog(100, string.Concat(exception.Message, " - ", exception.ToString()));
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(exception1.Message + " - " + exception1.ToString());
                msg.ShowDialog();
            }

        }

        private void bindData()
        {
            this.GridRecord.DataSource = null;
            this.GridRecord.RowCount = 0;

            this.adoPrt_1 = new DataTable();

            try
            {
                wnDm wdm = new wnDm();
                DataTable dt = null;
                dt = wdm.fn_활동보고서_매출처별_List(this.dtpDate.Text);
                this.adoPrt_1 = dt.Copy();
                if ((dt == null ? true : dt.Rows.Count <= 0))
                {
                    this.GridRecord.RowCount = 1;
                }
                else
                {
                    this.GridRecord.RowCount = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        this.GridRecord.Rows[i].Cells["C_SALES_DATE"].Value = dt.Rows[i]["일자명칭"].ToString();
                        if (dt.Rows[i]["일자명칭"].ToString().Equals("=== 합계 ==="))
                        {
                            this.GridRecord.Rows[i].DefaultCellStyle.BackColor = Color.Khaki;

                            this.GridRecord.Rows[i].Cells["C_CUST_NM"].Value = "-";
                            this.GridRecord.Rows[i].Cells["C_PRODUCT_GUBUN"].Value = "-";
                            this.GridRecord.Rows[i].Cells["C_PRODUCT_NM"].Value = "-";
                            this.GridRecord.Rows[i].Cells["C_TAX_NM"].Value = "-";
                            this.GridRecord.Rows[i].Cells["C_VAT_NM"].Value = "-";
                            this.GridRecord.Rows[i].Cells["C_UNION_CD"].Value = "-";
                            this.GridRecord.Rows[i].Cells["C_SUPPLY_MONEY"].Value = decimal.Parse(dt.Rows[i]["SUPPLY_MONEY"].ToString()).ToString("#,0.######"); ;
                            this.GridRecord.Rows[i].Cells["C_TAX_MONEY"].Value = decimal.Parse(dt.Rows[i]["TAX_MONEY"].ToString()).ToString("#,0.######"); ;
                            this.GridRecord.Rows[i].Cells["C_TOTAL_MONEY"].Value = decimal.Parse(dt.Rows[i]["TOTAL_MONEY"].ToString()).ToString("#,0.######"); ;
                            this.GridRecord.Rows[i].Cells["C_SALES_MONEY"].Value = decimal.Parse(dt.Rows[i]["SALES_MONEY"].ToString()).ToString("#,0.######");
                            this.GridRecord.Rows[i].Cells["C_SOO_MONEY"].Value = decimal.Parse(dt.Rows[i]["SOO_MONEY"].ToString()).ToString("#,0.######");
                            this.GridRecord.Rows[i].Cells["C_DC_MONEY"].Value = decimal.Parse(dt.Rows[i]["DC_MONEY"].ToString()).ToString("#,0.######");
                            this.GridRecord.Rows[i].Cells["C_BALANCE"].Value = decimal.Parse(dt.Rows[i]["BALANCE"].ToString()).ToString("#,0.######");

                            return;
                        }
                        this.GridRecord.Rows[i].Cells["C_CUST_NM"].Value = dt.Rows[i]["CUST_NM"].ToString();
                        this.GridRecord.Rows[i].Cells["C_PRODUCT_GUBUN"].Value = dt.Rows[i]["INPUT_GUBUN"].ToString();
                        this.GridRecord.Rows[i].Cells["C_PRODUCT_NM"].Value = dt.Rows[i]["PRODUCT_NM"].ToString();
                        this.GridRecord.Rows[i].Cells["C_TAX_NM"].Value = dt.Rows[i]["TAX_NM"].ToString();
                        this.GridRecord.Rows[i].Cells["C_VAT_NM"].Value = dt.Rows[i]["VAT_NM"].ToString();
                        //this.GridRecord.Rows[i].Cells["C_UNION_CD"].Value = dt.Rows[i]["UNION_CD"].ToString();
                        this.GridRecord.Rows[i].Cells["C_SUPPLY_MONEY"].Value = decimal.Parse(dt.Rows[i]["SUPPLY_MONEY"].ToString()).ToString("#,0.######"); ;
                        this.GridRecord.Rows[i].Cells["C_TAX_MONEY"].Value = decimal.Parse(dt.Rows[i]["TAX_MONEY"].ToString()).ToString("#,0.######"); ;
                        this.GridRecord.Rows[i].Cells["C_TOTAL_MONEY"].Value = decimal.Parse(dt.Rows[i]["TOTAL_MONEY"].ToString()).ToString("#,0.######"); ;
                        this.GridRecord.Rows[i].Cells["C_SALES_MONEY"].Value = decimal.Parse(dt.Rows[i]["SALES_MONEY"].ToString()).ToString("#,0.######");
                        this.GridRecord.Rows[i].Cells["C_SOO_MONEY"].Value = decimal.Parse(dt.Rows[i]["SOO_MONEY"].ToString()).ToString("#,0.######");
                        this.GridRecord.Rows[i].Cells["C_DC_MONEY"].Value = decimal.Parse(dt.Rows[i]["DC_MONEY"].ToString()).ToString("#,0.######");
                        this.GridRecord.Rows[i].Cells["C_BALANCE"].Value = decimal.Parse(dt.Rows[i]["BALANCE"].ToString()).ToString("#,0.######");

                       
                    }
                    wnGConstant wng = new wnGConstant();
                    wng.mergeCells(GridRecord, 2);
                }

            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                wnLog.writeLog(100, string.Concat(exception.Message, " - ", exception.ToString()));
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(exception1.Message + " - " + exception1.ToString());
                msg.ShowDialog();
            }
        }

        private void bindData_월계()
        {
            try
            {
                DateTime dateTime = DateTime.Parse(this.dtpDate.Text);
                string str = dateTime.ToString("yyyy-MM-01");
                DateTime dateTime1 = DateTime.Parse(str);
                dateTime1 = dateTime1.AddMonths(1);
                string str1 = dateTime1.AddDays(-1).ToString("yyyy-MM-dd");
                wdm = new wnDm();
                DataTable dataTable = null;
                dataTable = wdm.fn_일월매출수금할인_List();
                if ((dataTable == null ? false : dataTable.Rows.Count > 0))
                {
                    conLabel _conLabel = this.lbl매출;
                    decimal num = decimal.Parse(dataTable.Rows[0]["매출계"].ToString());
                    _conLabel.Text = num.ToString("#,0.######");
                    conLabel _conLabel1 = this.lbl수금;
                    num = decimal.Parse(dataTable.Rows[0]["수금계"].ToString());
                    _conLabel1.Text = num.ToString("#,0.######");
                    conLabel str2 = this.lbl할인;
                    num = decimal.Parse(dataTable.Rows[0]["할인계"].ToString());
                    str2.Text = num.ToString("#,0.######");
                }
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                wnLog.writeLog(100, string.Concat(exception.Message, " - ", exception.ToString()));
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(exception1.Message + " - " + exception1.ToString());
                msg.ShowDialog();
            }
        }

        private void pnlHead_Paint(object sender, PaintEventArgs e)
        {

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
                    btnSrch.PerformClick();
                    break;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
            return true;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

    }
}
