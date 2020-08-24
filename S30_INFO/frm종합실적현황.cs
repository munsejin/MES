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

namespace MES.S30_INFO
{
    public partial class frm종합실적현황 : Form
    {
        
        private wnGConstant wConst = new wnGConstant();



        public frm종합실적현황()
        {
            InitializeComponent();
        }

        private void frm종합실적현황_Load(object sender, EventArgs e)
        {
            lbl_title.Tag = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[0] + "$" + wnDm.fn_TitleName(this.Name.ToString()).Split('$')[1]; lbl_title.Text = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[2];
            
            start_date.Text = DateTime.Today.ToString("yyyy-MM-dd").Substring(0, 8) + "01";


            DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();
            cellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            cellStyle.BackColor = Color.WhiteSmoke;
            cellStyle.ForeColor = Color.FromArgb(64, 64, 64);

            for (int i = 1; i < 9; i++)
            {
                staffGrid.Columns[i].HeaderCell.Style = cellStyle;
            }

        }

        #region button logic

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            in_grid_logic();
        }

        
        

        #endregion button logic


        private void in_grid_logic()
        {
            wnDm wDm = new wnDm();
            DataTable dt = null;

            StringBuilder sb = new StringBuilder();
            

            dt = wDm.fn_Info_Date_List(start_date.Text, end_date.Text);

            if (dt != null && dt.Rows.Count > 0)
            {
                dateGrid.Rows.Clear();
                dateGrid.RowCount = dt.Rows.Count;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["GUBUN"].ToString().ToString().Equals("(전체)매출")
                      )
                    {
                        DataGridViewCellStyle style = new DataGridViewCellStyle();
                        style.BackColor = Color.Khaki;
                        style.SelectionBackColor = Color.DarkKhaki;

                        for (int j = 0; j < dateGrid.ColumnCount; j++)
                        {
                            dateGrid.Rows[i].Cells[j].Style = style;
                        }
                    }
                    dateGrid.Rows[i].Cells["DATE_GUBUN"].Value = dt.Rows[i]["GUBUN"].ToString();
                    dateGrid.Rows[i].Cells["DATE_SUM"].Value = decimal.Parse(dt.Rows[i]["TOTAL_MONEY"].ToString()).ToString("#,0.######");
                    Console.WriteLine(dateGrid.Rows[i].Cells["DATE_GUBUN"].Value);
                    Console.WriteLine(dateGrid.Rows[i].Cells["DATE_SUM"].Value);
                }
            }

            dt = wDm.fn_Info_Date_List(end_date.Text, end_date.Text);

            if (dt != null && dt.Rows.Count > 0)
            {
                dayGrid.Rows.Clear();
                dayGrid.RowCount = dt.Rows.Count;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["GUBUN"].ToString().ToString().Equals("(전체)매출")
                      )
                    {
                        DataGridViewCellStyle style = new DataGridViewCellStyle();
                        style.BackColor = Color.Khaki;
                        style.SelectionBackColor = Color.DarkKhaki;

                        for (int j = 0; j < dayGrid.ColumnCount; j++)
                        {
                            dayGrid.Rows[i].Cells[j].Style = style;
                        }
                    }
                    dayGrid.Rows[i].Cells["DAY_GUBUN"].Value = dt.Rows[i]["GUBUN"].ToString();
                    dayGrid.Rows[i].Cells["DAY_SUM"].Value = decimal.Parse(dt.Rows[i]["TOTAL_MONEY"].ToString()).ToString("#,0.######");
                }
            }

            dt = wDm.fn_Info_Profit_List(start_date.Text, end_date.Text);

            if (dt != null && dt.Rows.Count > 0)
            {
                dateProfitGrid.Rows.Clear();
                dateProfitGrid.Rows.Add();
                dateProfitGrid.Rows[0].Cells["DATE_SALES"].Value = decimal.Parse(dt.Rows[0]["매출액"].ToString()).ToString("#,0.######");
                dateProfitGrid.Rows[0].Cells["DATE_BUY"].Value = decimal.Parse(dt.Rows[0]["매입액"].ToString()).ToString("#,0.######");
                dateProfitGrid.Rows[0].Cells["DATE_PAY"].Value = decimal.Parse(dt.Rows[0]["지출액"].ToString()).ToString("#,0.######");
                dateProfitGrid.Rows[0].Cells["DATE_DC"].Value = decimal.Parse(dt.Rows[0]["할인액"].ToString()).ToString("#,0.######");
                dateProfitGrid.Rows[0].Cells["DATE_PROFIT"].Value = decimal.Parse(dt.Rows[0]["이익금"].ToString()).ToString("#,0.######");
                dateProfitGrid.Rows[0].Cells["DATE_PROFIT_P"].Value = decimal.Parse(dt.Rows[0]["이익율"].ToString()).ToString("#,0.##");
                DataGridViewCellStyle style = new DataGridViewCellStyle();
                style.BackColor = Color.Khaki;
                style.SelectionBackColor = Color.Khaki;
                dateProfitGrid.Rows[0].Cells["DATE_PROFIT_P"].Style = style;
            }
            else
            {
                dateProfitGrid.Rows.Clear();
                dateProfitGrid.Rows.Add();
                dateProfitGrid.Rows[0].Cells["DATE_SALES"].Value = "0";
                dateProfitGrid.Rows[0].Cells["DATE_BUY"].Value = "0";
                dateProfitGrid.Rows[0].Cells["DATE_PAY"].Value = "0";
                dateProfitGrid.Rows[0].Cells["DATE_DC"].Value = "0";
                dateProfitGrid.Rows[0].Cells["DATE_PROFIT"].Value = "0";
                dateProfitGrid.Rows[0].Cells["DATE_PROFIT_P"].Value = "0";
            }

            dt = wDm.fn_Info_Profit_List(end_date.Text, end_date.Text);

            if (dt != null && dt.Rows.Count > 0)
            {
                dayProfitGrid.Rows.Clear();
                dayProfitGrid.Rows.Add();
                dayProfitGrid.Rows[0].Cells["DAY_SALES"].Value = decimal.Parse(dt.Rows[0]["매출액"].ToString()).ToString("#,0.######");
                dayProfitGrid.Rows[0].Cells["DAY_BUY"].Value = decimal.Parse(dt.Rows[0]["매입액"].ToString()).ToString("#,0.######");
                dayProfitGrid.Rows[0].Cells["DAY_PAY"].Value = decimal.Parse(dt.Rows[0]["지출액"].ToString()).ToString("#,0.######");
                dayProfitGrid.Rows[0].Cells["DAY_DC"].Value = decimal.Parse(dt.Rows[0]["할인액"].ToString()).ToString("#,0.######");
                dayProfitGrid.Rows[0].Cells["DAY_PROFIT"].Value = decimal.Parse(dt.Rows[0]["이익금"].ToString()).ToString("#,0.######");
                dayProfitGrid.Rows[0].Cells["DAY_PROFIT_P"].Value = decimal.Parse(dt.Rows[0]["이익율"].ToString()).ToString("#,0.##");
                DataGridViewCellStyle style = new DataGridViewCellStyle();
                style.BackColor = Color.Khaki;
                style.SelectionBackColor = Color.Khaki;
                dayProfitGrid.Rows[0].Cells["DAY_PROFIT_P"].Style = style;
            }
            else
            {
                dayProfitGrid.Rows.Clear();
                dayProfitGrid.Rows.Add();
                dayProfitGrid.Rows[0].Cells["DAY_SALES"].Value = "0";
                dayProfitGrid.Rows[0].Cells["DAY_BUY"].Value = "0";
                dayProfitGrid.Rows[0].Cells["DAY_PAY"].Value = "0";
                dayProfitGrid.Rows[0].Cells["DAY_DC"].Value = "0";
                dayProfitGrid.Rows[0].Cells["DAY_PROFIT"].Value = "0";
                dayProfitGrid.Rows[0].Cells["DAY_PROFIT_P"].Value = "0";
            }

            dt = wDm.fn_Info_Group_By_Staff(start_date.Text, end_date.Text, " INPUT_DATE < '" + end_date.Text + "'   ");

            if (dt != null && dt.Rows.Count > 0)
            {
                staffGrid.Rows.Clear();
                staffGrid2.Rows.Clear();
                staffGrid.RowCount = dt.Rows.Count;
                staffGrid2.RowCount = dt.Rows.Count;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    staffGrid.Rows[i].Cells["거래처"].Value = dt.Rows[i]["CUST_NM"].ToString();
                    staffGrid2.Rows[i].Cells["거래처2"].Value = dt.Rows[i]["CUST_NM"].ToString();
                    staffGrid.Rows[i].Cells["기간매출"].Value = decimal.Parse(dt.Rows[i]["매출"].ToString()).ToString("#,0.######");
                    staffGrid.Rows[i].Cells["기간현금"].Value = decimal.Parse(dt.Rows[i]["현금"].ToString()).ToString("#,0.######");
                    staffGrid.Rows[i].Cells["기간무통장"].Value = decimal.Parse(dt.Rows[i]["무통장"].ToString()).ToString("#,0.######");
                    staffGrid.Rows[i].Cells["기간카드"].Value = decimal.Parse(dt.Rows[i]["카드"].ToString()).ToString("#,0.######");
                    staffGrid.Rows[i].Cells["기간어음"].Value = decimal.Parse(dt.Rows[i]["어음"].ToString()).ToString("#,0.######");
                    staffGrid.Rows[i].Cells["기간할인"].Value = decimal.Parse(dt.Rows[i]["할인"].ToString()).ToString("#,0.######");
                    staffGrid.Rows[i].Cells["기간매입"].Value = decimal.Parse(dt.Rows[i]["매입"].ToString()).ToString("#,0.######");
                    staffGrid.Rows[i].Cells["기간지급"].Value = decimal.Parse(dt.Rows[i]["지급"].ToString()).ToString("#,0.######");
                    staffGrid.Rows[i].Cells["전일잔고"].Value = decimal.Parse(dt.Rows[i]["잔고"].ToString()).ToString("#,0.######");
                }
            }

            dt = wDm.fn_Info_Group_By_Staff(end_date.Text, end_date.Text, " INPUT_DATE <= '" + end_date.Text + "'   ");

            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    staffGrid2.Rows[i].Cells["일매출2"].Value = decimal.Parse(dt.Rows[i]["매출"].ToString()).ToString("#,0.######");
                    staffGrid2.Rows[i].Cells["일현금2"].Value = decimal.Parse(dt.Rows[i]["현금"].ToString()).ToString("#,0.######");
                    staffGrid2.Rows[i].Cells["일무통장2"].Value = decimal.Parse(dt.Rows[i]["무통장"].ToString()).ToString("#,0.######");
                    staffGrid2.Rows[i].Cells["일카드2"].Value = decimal.Parse(dt.Rows[i]["카드"].ToString()).ToString("#,0.######");
                    staffGrid2.Rows[i].Cells["일어음2"].Value = decimal.Parse(dt.Rows[i]["어음"].ToString()).ToString("#,0.######");
                    staffGrid2.Rows[i].Cells["일할인2"].Value = decimal.Parse(dt.Rows[i]["할인"].ToString()).ToString("#,0.######");
                    staffGrid2.Rows[i].Cells["일매입2"].Value = decimal.Parse(dt.Rows[i]["매입"].ToString()).ToString("#,0.######");
                    staffGrid2.Rows[i].Cells["일지급2"].Value = decimal.Parse(dt.Rows[i]["지급"].ToString()).ToString("#,0.######");
                    staffGrid2.Rows[i].Cells["현잔고2"].Value = decimal.Parse(dt.Rows[i]["잔고"].ToString()).ToString("#,0.######");
                }
            }
        }

        private void grdCellSetting()
        {
            ComInfo comInfo = new ComInfo();
            comInfo.grdCellSetting2(dateGrid);
        }

        private void btn출력_Click(object sender, EventArgs e)
        {
           
        }

        private void btn출력_SizeChanged(object sender, EventArgs e)
        {
        

        }

        private void frm종합실적현황_SizeChanged(object sender, EventArgs e)
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
                    btnSearch.PerformClick();
                    break;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
            return true;
        }
       
       
        
    }
}
