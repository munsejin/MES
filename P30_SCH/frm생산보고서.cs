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

namespace MES.P30_SCH
{
    public partial class frm생산보고서 : Form
    {

        wnGConstant wConst = new wnGConstant();
        private Color ColorBlue = Color.FromArgb(67, 114, 196);
        private Color ColorOrange = Color.FromArgb(237, 125, 49);
        private int btnFlag = 1;
        public frm생산보고서()
        {
            InitializeComponent();
        }

        private void frm생산보고서_Load(object sender, EventArgs e)
        {
            lbl_title.Tag = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[0] + "$" + wnDm.fn_TitleName(this.Name.ToString()).Split('$')[1]; lbl_title.Text = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[2];

            lbl_start_date.Text = DateTime.Now.ToString("yyyy-MM-dd");
            lbl_end_date.Text = DateTime.Now.ToString("yyyy-MM-dd");
            btn_day.BackColor = ColorBlue;
            btn_day.ForeColor = Color.WhiteSmoke;
            set_BtnSetDateValue();

            Print_All_Chart();

        }

        private void Label_Show(System.Windows.Forms.DataVisualization.Charting.Chart c)
        {
            c.Series.SuspendUpdates();

            for (int k = 0; k < c.Series.Count; k++)
            {
                if (c.Series[k].ChartType == System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line)
                {
                    for (int i = 0; i < c.Series[1].Points.Count; i++)
                    {
                        c.Series[k].Points[i].LabelBackColor = ColorOrange;
                        c.Series[k].Points[i].LabelForeColor = Color.WhiteSmoke;
                        c.Series[k].Points[i].LabelBorderColor = ColorOrange;
                    }
                }
                else
                {
                    for (int i = 0; i < c.Series[0].Points.Count; i++)
                    {
                        c.Series[k].Points[i].LabelBackColor = Color.WhiteSmoke;
                        c.Series[k].Points[i].LabelForeColor = Color.FromArgb(64, 64, 64);
                        c.Series[k].Points[i].LabelBorderColor = Color.FromArgb(64, 64, 64);
                    }
                }
            }
            c.Series.ResumeUpdates();
        }

        private void Label_Hide(System.Windows.Forms.DataVisualization.Charting.Chart c)
        {
            
            c.Series.SuspendUpdates();

            foreach (System.Windows.Forms.DataVisualization.Charting.Series s in c.Series)
            {
                for (int i = 0; i < s.Points.Count; i++)
                {
                    s.Points[i].LabelBackColor = Color.Transparent;
                    s.Points[i].LabelForeColor = Color.Transparent;
                    s.Points[i].LabelBorderColor = Color.Transparent;
                }
            }
            c.Series.ResumeUpdates();
        }

        private void btn_SetDate_MouseClick(object sender, MouseEventArgs e)
        {
            Button btnTemp = (Button)sender;
            Popup.popDatePicker msg = new Popup.popDatePicker(lbl_start_date.Text, lbl_end_date.Text, Cursor.Position.X, Cursor.Position.Y);
            //msg.StartPosition = FormStartPosition.
            msg.Location = new Point(btnTemp.Location.X + btnTemp.Width + 7, btnTemp.Location.Y + 152);
            msg.ShowDialog();

            if (!msg.returnS_date.Equals(""))
            {
                lbl_start_date.Text = msg.returnS_date;
                lbl_end_date.Text = msg.returnE_date;
                set_BtnSetDateValue();
                Print_All_Chart();
            }
        }

        private void Print_All_Chart()
        {
            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = new DataTable();
                ResetChart();

                //item
                if (btnFlag == 1)
                {
                    dt = wDm.fn_Select_Item_input_Poor_group_by_date_Day(" and A.INPUT_DATE >= '" + lbl_start_date.Text + "' and A.INPUT_DATE <= '" + lbl_end_date.Text + "'   ", "");
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        if (dt.Rows.Count == 1) chart_item_detail2.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            chart_item_detail2.Series[0].Points.AddXY(dt.Rows[i]["INPUT_DATE"].ToString(), decimal.Parse(dt.Rows[i]["INPUT_AMT"].ToString()));
                            chart_item_detail2.Series[1].Points.AddY(decimal.Parse(dt.Rows[i]["POOR_AMT"].ToString()));
                            if (decimal.Parse(dt.Rows[i]["INPUT_AMT"].ToString()) != 0)
                            {
                                chart_item_detail2.Series[0].Points[i].Label = decimal.Parse(dt.Rows[i]["INPUT_AMT"].ToString()).ToString("#,0.######");
                            }
                            if (decimal.Parse(dt.Rows[i]["POOR_AMT"].ToString()) != 0 && decimal.Parse(dt.Rows[i]["INPUT_AMT"].ToString()) != 0)
                            {
                                chart_item_detail2.Series[1].Points[i].Label = decimal.Parse(dt.Rows[i]["POOR_AMT"].ToString()).ToString("#,0.######")
                                     + " (" + (decimal.Parse(dt.Rows[i]["POOR_AMT"].ToString()) / (decimal.Parse(dt.Rows[i]["INPUT_AMT"].ToString()) + decimal.Parse(dt.Rows[i]["POOR_AMT"].ToString())) * 100).ToString("#,0.##") + "%)";
                            }
                        }
                    }
                }
                else if (btnFlag == 2)
                {
                    dt = wDm.fn_Select_Item_input_Poor_group_by_date_Week(lbl_start_date.Text, lbl_end_date.Text);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        if (dt.Rows.Count == 1) chart_item_detail2.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            chart_item_detail2.Series[0].Points.AddXY(dt.Rows[i]["DATE_RANGE"].ToString(), decimal.Parse(dt.Rows[i]["INPUT_AMT"].ToString()));
                            chart_item_detail2.Series[1].Points.AddY(decimal.Parse(dt.Rows[i]["POOR_AMT"].ToString()));
                            if (decimal.Parse(dt.Rows[i]["INPUT_AMT"].ToString()) != 0)
                            {
                                chart_item_detail2.Series[0].Points[i].Label = decimal.Parse(dt.Rows[i]["INPUT_AMT"].ToString()).ToString("#,0.######");
                            }
                            if (decimal.Parse(dt.Rows[i]["POOR_AMT"].ToString()) != 0 && decimal.Parse(dt.Rows[i]["INPUT_AMT"].ToString()) != 0)
                            {
                                chart_item_detail2.Series[1].Points[i].Label = decimal.Parse(dt.Rows[i]["POOR_AMT"].ToString()).ToString("#,0.######")
                                     + " (" + (decimal.Parse(dt.Rows[i]["POOR_AMT"].ToString()) / (decimal.Parse(dt.Rows[i]["INPUT_AMT"].ToString()) + decimal.Parse(dt.Rows[i]["POOR_AMT"].ToString())) * 100).ToString("#,0.##") + "%)";
                            }
                        }
                    }
                }
                else
                {
                    dt = wDm.fn_Select_Item_input_Poor_group_by_date_Month(lbl_start_date.Text, lbl_end_date.Text);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        if (dt.Rows.Count == 1) chart_item_detail2.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            chart_item_detail2.Series[0].Points.AddXY(dt.Rows[i]["DATE_RANGE"].ToString(), decimal.Parse(dt.Rows[i]["INPUT_AMT"].ToString()));
                            chart_item_detail2.Series[1].Points.AddY(decimal.Parse(dt.Rows[i]["POOR_AMT"].ToString()));
                            if (decimal.Parse(dt.Rows[i]["INPUT_AMT"].ToString()) != 0)
                            {
                                chart_item_detail2.Series[0].Points[i].Label = decimal.Parse(dt.Rows[i]["INPUT_AMT"].ToString()).ToString("#,0.######");
                            }
                            if (decimal.Parse(dt.Rows[i]["POOR_AMT"].ToString()) != 0 && decimal.Parse(dt.Rows[i]["INPUT_AMT"].ToString()) != 0)
                            {
                                chart_item_detail2.Series[1].Points[i].Label = decimal.Parse(dt.Rows[i]["POOR_AMT"].ToString()).ToString("#,0.######")
                                     + " (" + (decimal.Parse(dt.Rows[i]["POOR_AMT"].ToString()) / (decimal.Parse(dt.Rows[i]["INPUT_AMT"].ToString()) + decimal.Parse(dt.Rows[i]["POOR_AMT"].ToString())) * 100).ToString("#,0.##") + "%)";
                            }
                        }
                    }
                }

                for (int i = 0; i < chart_item_detail2.Series.Count; i++)
                {
                    for (int j = 0; j < chart_item_detail2.Series[i].Points.Count; j++)
                    {
                        chart_item_detail2.Series[i].Points[j].LabelToolTip = chart_item_detail2.Series[i].Points[j].Label;
                    }
                }

                SendToBack(chart_item_detail2, chart_item_detail2.Series[1]);

                if (btnFlag == 1)
                {
                    dt = wDm.fn_Select_Item_input_Detail_Poor(" and A.F_SUB_DATE >= '" + lbl_start_date.Text + "' and A.F_SUB_DATE <= '" + lbl_end_date.Text + "'   ", "");
                    dataItemGrid2.Rows.Clear();

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        dataItemGrid2.RowCount = dt.Rows.Count;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            dataItemGrid2.Rows[i].Cells["공정일자"].Value = dt.Rows[i]["FLOW_DATE"].ToString();
                            dataItemGrid2.Rows[i].Cells["제품명"].Value = dt.Rows[i]["ITEM_NM"].ToString();
                            dataItemGrid2.Rows[i].Cells["LOTNO"].Value = dt.Rows[i]["LOT_NO"].ToString();
                            dataItemGrid2.Rows[i].Cells["완제품공정명"].Value = dt.Rows[i]["FLOW_NM"].ToString();
                            dataItemGrid2.Rows[i].Cells["공정코드"].Value = dt.Rows[i]["FLOW_CD"].ToString();
                            dataItemGrid2.Rows[i].Cells["생산수량"].Value = decimal.Parse(dt.Rows[i]["F_SUB_AMT"].ToString()).ToString("#,0.######");
                            dataItemGrid2.Rows[i].Cells["불량유형"].Value = dt.Rows[i]["POOR_NM"].ToString() + " " + dt.Rows[i]["COMMENT"].ToString();
                            if (decimal.Parse(dt.Rows[i]["POOR_AMT"].ToString()) == 0)
                            {
                                dataItemGrid2.Rows[i].Cells["불량건수"].Value = "";
                            }
                            else
                            {
                                dataItemGrid2.Rows[i].Cells["불량건수"].Value = decimal.Parse(dt.Rows[i]["POOR_AMT"].ToString()).ToString("#,0.######");
                            }


                            if (dataItemGrid2.Rows[i].Cells["불량건수"].Value == null || dataItemGrid2.Rows[i].Cells["불량건수"].Value.ToString().Equals("") || dataItemGrid2.Rows[i].Cells["불량건수"].Value.ToString().Equals("0"))
                            {
                                dataItemGrid2.Rows[i].Cells["불량건수"].Value = "";
                            }
                        }
                        dataItemGrid2.Columns["제품명"].Visible = true;
                        dataItemGrid2.Columns["LOTNO"].Visible = true;
                        dataItemGrid2.Columns["완제품공정명"].Visible = true;
                        dataItemGrid2.Columns["공정코드"].Visible = true;
                        dataItemGrid2.Columns["불량유형"].Visible = true;
                    }
                }
                else
                {
                    dataItemGrid2.Rows.Clear();
                    dataItemGrid2.RowCount = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dataItemGrid2.Rows[i].Cells["공정일자"].Value = dt.Rows[i]["DATE_RANGE"].ToString();
                        dataItemGrid2.Rows[i].Cells["생산수량"].Value = decimal.Parse(dt.Rows[i]["INPUT_AMT"].ToString()).ToString("#,0.######");
                        dataItemGrid2.Rows[i].Cells["불량건수"].Value = decimal.Parse(dt.Rows[i]["POOR_AMT"].ToString()).ToString("#,0.######");
                    }
                    dataItemGrid2.Columns["제품명"].Visible = false;
                    dataItemGrid2.Columns["LOTNO"].Visible = false;
                    dataItemGrid2.Columns["완제품공정명"].Visible = false;
                    dataItemGrid2.Columns["공정코드"].Visible = false;
                    dataItemGrid2.Columns["불량유형"].Visible = false;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex + "");
                MessageBox.Show("Exception");
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                msg.ShowDialog();
            }
        }



        private void ResetChart()
        {
            chart_item_detail2.Series.Clear();
            chart_item_detail2.Series.Add("생산량");
            chart_item_detail2.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart_item_detail2.Series[0].Color = ColorBlue;
            chart_item_detail2.Series[0].YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Primary;
            chart_item_detail2.Series[0].BorderWidth = 3;
            chart_item_detail2.BorderlineWidth = 1;
            chart_item_detail2.Series.Add("불량건수");
            chart_item_detail2.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            chart_item_detail2.Series[1].Color = ColorOrange;
            chart_item_detail2.Series[1].ToolTip = "불량건수";
            chart_item_detail2.Series[0].ToolTip = "생산량";
            chart_item_detail2.Series[0].LabelBorderColor = Color.FromArgb(64, 64, 64);
            chart_item_detail2.Series[0].LabelBorderWidth = 1;
            chart_item_detail2.Series[0].LabelBackColor = Color.WhiteSmoke;
            chart_item_detail2.Series[1].LabelBorderColor = Color.FromArgb(64, 64, 64);
            chart_item_detail2.Series[1].LabelBorderWidth = 0;
            chart_item_detail2.Series[1].LabelBackColor = ColorOrange;
            chart_item_detail2.Series[1].LabelForeColor = Color.WhiteSmoke;
        }


        public void SendToBack(System.Windows.Forms.DataVisualization.Charting.Chart c, System.Windows.Forms.DataVisualization.Charting.Series s)
        {
            c.Series.Remove(s);
            c.Series.Insert(0, s);
        }

        public void SendToFront(System.Windows.Forms.DataVisualization.Charting.Chart c, System.Windows.Forms.DataVisualization.Charting.Series s)
        {
            c.Series.Remove(s);
            c.Series.Insert(1, s);
        }

        private void set_BtnSetDateValue()
        {
            btn_SetDate.Text = lbl_start_date.Text + " - " + lbl_end_date.Text + " ▼";
        }

        private void btn_day_Click(object sender, EventArgs e)
        {
            btn_day.ForeColor = Color.WhiteSmoke;
            btn_week.ForeColor = Color.FromArgb(64, 64, 64);
            btn_month.ForeColor = Color.FromArgb(64, 64, 64);
            btn_day.BackColor = ColorBlue;
            btn_week.BackColor = Color.WhiteSmoke;
            btn_month.BackColor = Color.WhiteSmoke;
            btnFlag = 1;
            Print_All_Chart();
        }

        private void btn_week_Click(object sender, EventArgs e)
        {
            btn_day.ForeColor = Color.FromArgb(64, 64, 64);
            btn_week.ForeColor = Color.WhiteSmoke;
            btn_month.ForeColor = Color.FromArgb(64, 64, 64);
            btn_day.BackColor = Color.WhiteSmoke;
            btn_week.BackColor = ColorBlue;
            btn_month.BackColor = Color.WhiteSmoke;
            btnFlag = 2;
            Print_All_Chart();
        }

        private void btn_month_Click(object sender, EventArgs e)
        {
            btn_day.ForeColor = Color.FromArgb(64, 64, 64);
            btn_week.ForeColor = Color.FromArgb(64, 64, 64);
            btn_month.ForeColor = Color.WhiteSmoke;
            btn_day.BackColor = Color.WhiteSmoke;
            btn_week.BackColor = Color.WhiteSmoke;
            btn_month.BackColor = ColorBlue;
            btnFlag = 3;
            Print_All_Chart();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
                    Print_All_Chart();
                    break;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
            return true;
        }


    }
}
