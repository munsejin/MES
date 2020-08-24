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

namespace MES.P50_QUA
{
    public partial class frm생산보고서 : Form
    {

        wnGConstant wConst = new wnGConstant();
        private Color ColorBlue = Color.FromArgb(67, 114, 196);
        private Color ColorOrange = Color.FromArgb(237, 125, 49);
        public frm생산보고서()
        {
            InitializeComponent();
        }

        private void frm품질분석현황_Load(object sender, EventArgs e)
        {
            lbl_title.Tag = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[0] + "$" + wnDm.fn_TitleName(this.Name.ToString()).Split('$')[1]; lbl_title.Text = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[2];

            lbl_start_date.Text = DateTime.Now.ToString("yyyy-MM-dd");
            lbl_end_date.Text = DateTime.Now.ToString("yyyy-MM-dd");

            set_BtnSetDateValue();

            pnl_all.Dock = DockStyle.Fill;
            pnl_raw.Dock = DockStyle.Fill;
            pnl_flow.Dock = DockStyle.Fill;
            pnl_item.Dock = DockStyle.Fill;
            pnl_raw.Visible = false;
            pnl_flow.Visible = false;
            pnl_item.Visible = false;

            Print_All_Chart();

            SetRawWhite_To_Default();
            SetRawBlack_To_Default();
            SetItemBlack_To_Default();
            SetItemWhite_To_Default();
            SetItemBlack2_To_Default();
            SetItemWhite2_To_Default();

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
       
        #region setDefault
        private void SetRawWhite_To_Default()
        {
            f_pnl_Raw_white.Controls.Clear();

            FlowLayoutPanel pnTemp = new FlowLayoutPanel();
            pnTemp.AutoSize = true;
            pnTemp.Padding = new Padding(0);
            pnTemp.Margin = new Padding(0);
            pnTemp.BackColor = Color.LemonChiffon;
            pnTemp.Tag = null;

            Label labelTemp = new Label();
            labelTemp.Text = "전체";
            labelTemp.AutoSize = false;
            labelTemp.Width = 40;
            labelTemp.Height = 21;
            labelTemp.TextAlign = ContentAlignment.MiddleCenter;
            labelTemp.Margin = new Padding(0, 0, 0, 0);

            Button del_BtnTemp = new Button();
            del_BtnTemp.Text = "X";
            del_BtnTemp.Padding = new Padding(0);
            del_BtnTemp.TextAlign = ContentAlignment.MiddleCenter;
            del_BtnTemp.FlatStyle = FlatStyle.Flat;
            del_BtnTemp.BackColor = Color.Red;
            del_BtnTemp.ForeColor = Color.WhiteSmoke;
            del_BtnTemp.Size = new System.Drawing.Size(15, 15);
            del_BtnTemp.Visible = false;

            pnTemp.BorderStyle = BorderStyle.FixedSingle;
            pnTemp.Controls.Add(labelTemp);
            pnTemp.Controls.Add(del_BtnTemp);

            f_pnl_Raw_white.Controls.Add(pnTemp);
        }
        private void SetRawBlack_To_Default()
        {
            f_pnl_Raw_Black.Controls.Clear();

            FlowLayoutPanel pnTemp = new FlowLayoutPanel();
            pnTemp.AutoSize = true;
            pnTemp.Padding = new Padding(0);
            pnTemp.Margin = new Padding(0);
            pnTemp.BackColor = Color.LemonChiffon;
            pnTemp.Tag = null;

            Label labelTemp = new Label();
            labelTemp.Text = "제외없음";
            labelTemp.AutoSize = false;
            labelTemp.Width = 80;
            labelTemp.Height = 21;
            labelTemp.TextAlign = ContentAlignment.MiddleCenter;
            labelTemp.Margin = new Padding(0, 0, 0, 0);

            Button del_BtnTemp = new Button();
            del_BtnTemp.Text = "X";
            del_BtnTemp.Padding = new Padding(0);
            del_BtnTemp.TextAlign = ContentAlignment.MiddleCenter;
            del_BtnTemp.FlatStyle = FlatStyle.Flat;
            del_BtnTemp.BackColor = Color.Red;
            del_BtnTemp.ForeColor = Color.WhiteSmoke;
            del_BtnTemp.Size = new System.Drawing.Size(15, 15);
            del_BtnTemp.Visible = false;

            pnTemp.BorderStyle = BorderStyle.FixedSingle;
            pnTemp.Controls.Add(labelTemp);
            pnTemp.Controls.Add(del_BtnTemp);

            f_pnl_Raw_Black.Controls.Add(pnTemp);
        }
        private void SetItemBlack_To_Default()
        {
            f_pnl_Item_Black.Controls.Clear();

            FlowLayoutPanel pnTemp = new FlowLayoutPanel();
            pnTemp.AutoSize = true;
            pnTemp.Padding = new Padding(0);
            pnTemp.Margin = new Padding(0);
            pnTemp.BackColor = Color.LemonChiffon;
            pnTemp.Tag = null;

            Label labelTemp = new Label();
            labelTemp.Text = "제외없음";
            labelTemp.AutoSize = false;
            labelTemp.Width = 80;
            labelTemp.Height = 21;
            labelTemp.TextAlign = ContentAlignment.MiddleCenter;
            labelTemp.Margin = new Padding(0, 0, 0, 0);

            Button del_BtnTemp = new Button();
            del_BtnTemp.Text = "X";
            del_BtnTemp.Padding = new Padding(0);
            del_BtnTemp.TextAlign = ContentAlignment.MiddleCenter;
            del_BtnTemp.FlatStyle = FlatStyle.Flat;
            del_BtnTemp.BackColor = Color.Red;
            del_BtnTemp.ForeColor = Color.WhiteSmoke;
            del_BtnTemp.Size = new System.Drawing.Size(15, 15);
            del_BtnTemp.Visible = false;

            pnTemp.BorderStyle = BorderStyle.FixedSingle;
            pnTemp.Controls.Add(labelTemp);
            pnTemp.Controls.Add(del_BtnTemp);

            f_pnl_Item_Black.Controls.Add(pnTemp);
        }
        private void SetItemWhite_To_Default()
        {
            f_pnl_Item_white.Controls.Clear();

            FlowLayoutPanel pnTemp = new FlowLayoutPanel();
            pnTemp.AutoSize = true;
            pnTemp.Padding = new Padding(0);
            pnTemp.Margin = new Padding(0);
            pnTemp.BackColor = Color.LemonChiffon;
            pnTemp.Tag = null;

            Label labelTemp = new Label();
            labelTemp.Text = "전체";
            labelTemp.AutoSize = false;
            labelTemp.Width = 40;
            labelTemp.Height = 21;
            labelTemp.TextAlign = ContentAlignment.MiddleCenter;
            labelTemp.Margin = new Padding(0, 0, 0, 0);

            Button del_BtnTemp = new Button();
            del_BtnTemp.Text = "X";
            del_BtnTemp.Padding = new Padding(0);
            del_BtnTemp.TextAlign = ContentAlignment.MiddleCenter;
            del_BtnTemp.FlatStyle = FlatStyle.Flat;
            del_BtnTemp.BackColor = Color.Red;
            del_BtnTemp.ForeColor = Color.WhiteSmoke;
            del_BtnTemp.Size = new System.Drawing.Size(15, 15);
            del_BtnTemp.Visible = false;

            pnTemp.BorderStyle = BorderStyle.FixedSingle;
            pnTemp.Controls.Add(labelTemp);
            pnTemp.Controls.Add(del_BtnTemp);

            f_pnl_Item_white.Controls.Add(pnTemp);
        }
        private void SetItemBlack2_To_Default()
        {
            f_pnl_Item_Black2.Controls.Clear();
            FlowLayoutPanel pnTemp = new FlowLayoutPanel();
            pnTemp.AutoSize = true;
            pnTemp.Padding = new Padding(0);
            pnTemp.Margin = new Padding(0);
            pnTemp.BackColor = Color.LemonChiffon;
            pnTemp.Tag = null;

            Label labelTemp = new Label();
            labelTemp.Text = "제외없음";
            labelTemp.AutoSize = false;
            labelTemp.Width = 80;
            labelTemp.Height = 21;
            labelTemp.TextAlign = ContentAlignment.MiddleCenter;
            labelTemp.Margin = new Padding(0, 0, 0, 0);

            Button del_BtnTemp = new Button();
            del_BtnTemp.Text = "X";
            del_BtnTemp.Padding = new Padding(0);
            del_BtnTemp.TextAlign = ContentAlignment.MiddleCenter;
            del_BtnTemp.FlatStyle = FlatStyle.Flat;
            del_BtnTemp.BackColor = Color.Red;
            del_BtnTemp.ForeColor = Color.WhiteSmoke;
            del_BtnTemp.Size = new System.Drawing.Size(15, 15);
            del_BtnTemp.Visible = false;

            pnTemp.BorderStyle = BorderStyle.FixedSingle;
            pnTemp.Controls.Add(labelTemp);
            pnTemp.Controls.Add(del_BtnTemp);

            f_pnl_Item_Black2.Controls.Add(pnTemp);
        }
        private void SetItemWhite2_To_Default()
        {
            f_pnl_Item_White2.Controls.Clear();

            FlowLayoutPanel pnTemp = new FlowLayoutPanel();
            pnTemp.AutoSize = true;
            pnTemp.Padding = new Padding(0);
            pnTemp.Margin = new Padding(0);
            pnTemp.BackColor = Color.LemonChiffon;
            pnTemp.Tag = null;

            Label labelTemp = new Label();
            labelTemp.Text = "전체";
            labelTemp.AutoSize = false;
            labelTemp.Width = 40;
            labelTemp.Height = 21;
            labelTemp.TextAlign = ContentAlignment.MiddleCenter;
            labelTemp.Margin = new Padding(0, 0, 0, 0);

            Button del_BtnTemp = new Button();
            del_BtnTemp.Text = "X";
            del_BtnTemp.Padding = new Padding(0);
            del_BtnTemp.TextAlign = ContentAlignment.MiddleCenter;
            del_BtnTemp.FlatStyle = FlatStyle.Flat;
            del_BtnTemp.BackColor = Color.Red;
            del_BtnTemp.ForeColor = Color.WhiteSmoke;
            del_BtnTemp.Size = new System.Drawing.Size(15, 15);
            del_BtnTemp.Visible = false;

            pnTemp.BorderStyle = BorderStyle.FixedSingle;
            pnTemp.Controls.Add(labelTemp);
            pnTemp.Controls.Add(del_BtnTemp);

            f_pnl_Item_White2.Controls.Add(pnTemp);
        }
        #endregion setDefault

        #region PrintChartLogic
        private void Print_All_Chart()
        {
            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = new DataTable();
                ResetChart();

                dt = wDm.fn_Select_Raw_input_Poor_group_by_cd(" and A.INPUT_DATE >= '" + lbl_start_date.Text + "' and A.INPUT_DATE <= '" + lbl_end_date.Text + "'   ");
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        chart_raw.Series[0].Points.AddXY(dt.Rows[i]["RAW_MAT_NM"].ToString(), decimal.Parse(dt.Rows[i]["INPUT_AMT"].ToString()));
                        chart_raw.Series[1].Points.AddY(decimal.Parse(dt.Rows[i]["POOR_AMT"].ToString()));
                        if (decimal.Parse(dt.Rows[i]["INPUT_AMT"].ToString()) != 0)
                        {
                            chart_raw.Series[0].Points[i].Label = decimal.Parse(dt.Rows[i]["INPUT_AMT"].ToString()).ToString("#,0.######");
                        }
                        if (decimal.Parse(dt.Rows[i]["POOR_AMT"].ToString()) != 0 && decimal.Parse(dt.Rows[i]["INPUT_AMT"].ToString()) != 0)
                        {
                            chart_raw.Series[1].Points[i].Label = decimal.Parse(dt.Rows[i]["POOR_AMT"].ToString()).ToString("#,0.######")
                            + " (" + (decimal.Parse(dt.Rows[i]["POOR_AMT"].ToString()) / (decimal.Parse(dt.Rows[i]["INPUT_AMT"].ToString())+decimal.Parse(dt.Rows[i]["POOR_AMT"].ToString())) * 100).ToString("#,0.##") + "%)";
                        }
                    }
                }
                for (int i = 0; i < chart_raw.Series.Count; i++)
                {
                    for (int j = 0; j < chart_raw.Series[i].Points.Count; j++)
                    {
                        chart_raw.Series[i].Points[j].LabelToolTip = chart_raw.Series[i].Points[j].Label;
                    }
                }

                dt = wDm.fn_Select_Raw_input_Poor_group_by_date_Day(" and A.INPUT_DATE >= '" + lbl_start_date.Text + "' and A.INPUT_DATE <= '" + lbl_end_date.Text + "'   ");
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        chart_raw_date.Series[0].Points.AddXY(dt.Rows[i]["INPUT_DATE"].ToString(), decimal.Parse(dt.Rows[i]["INPUT_AMT"].ToString()));
                        chart_raw_date.Series[1].Points.AddY(decimal.Parse(dt.Rows[i]["POOR_AMT"].ToString()));
                        if (decimal.Parse(dt.Rows[i]["INPUT_AMT"].ToString()) != 0)
                        {
                            chart_raw_date.Series[0].Points[i].Label = decimal.Parse(dt.Rows[i]["INPUT_AMT"].ToString()).ToString("#,0.######");
                        }
                        if (decimal.Parse(dt.Rows[i]["POOR_AMT"].ToString()) != 0 && decimal.Parse(dt.Rows[i]["INPUT_AMT"].ToString()) != 0)
                        {
                            chart_raw_date.Series[1].Points[i].Label = decimal.Parse(dt.Rows[i]["POOR_AMT"].ToString()).ToString("#,0.######")
                                 + " (" + (decimal.Parse(dt.Rows[i]["POOR_AMT"].ToString()) / (decimal.Parse(dt.Rows[i]["INPUT_AMT"].ToString())+decimal.Parse(dt.Rows[i]["POOR_AMT"].ToString())) * 100).ToString("#,0.##") + "%)";
                        }
                    }
                }
                for (int i = 0; i < chart_raw_date.Series.Count; i++)
                {
                    for (int j = 0; j < chart_raw_date.Series[i].Points.Count; j++)
                    {
                        chart_raw_date.Series[i].Points[j].LabelToolTip = chart_raw_date.Series[i].Points[j].Label;
                    }
                }


                dt = wDm.fn_Select_Item_input_Poor_group_by_cd(" and A.INPUT_DATE >= '" + lbl_start_date.Text + "' and A.INPUT_DATE <= '" + lbl_end_date.Text + "'   ");
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        chart_item.Series[0].Points.AddXY(dt.Rows[i]["ITEM_NM"].ToString(), decimal.Parse(dt.Rows[i]["INPUT_AMT"].ToString()));
                        chart_item.Series[1].Points.AddY(decimal.Parse(dt.Rows[i]["POOR_AMT"].ToString()));
                        if (decimal.Parse(dt.Rows[i]["INPUT_AMT"].ToString()) != 0)
                        {
                            chart_item.Series[0].Points[i].Label = decimal.Parse(dt.Rows[i]["INPUT_AMT"].ToString()).ToString("#,0.######");
                        }
                        if (decimal.Parse(dt.Rows[i]["POOR_AMT"].ToString()) != 0 && decimal.Parse(dt.Rows[i]["INPUT_AMT"].ToString()) != 0)
                        {
                            chart_item.Series[1].Points[i].Label = decimal.Parse(dt.Rows[i]["POOR_AMT"].ToString()).ToString("#,0.######")
                            + " (" + (decimal.Parse(dt.Rows[i]["POOR_AMT"].ToString()) / (decimal.Parse(dt.Rows[i]["INPUT_AMT"].ToString()) + decimal.Parse(dt.Rows[i]["POOR_AMT"].ToString())) * 100).ToString("#,0.##") + "%)";
                        }
                    }
                }

                dt = wDm.fn_Select_Item_input_Poor_group_by_date_Day(" and A.INPUT_DATE >= '" + lbl_start_date.Text + "' and A.INPUT_DATE <= '" + lbl_end_date.Text + "'   ", "");
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        chart_item_date.Series[0].Points.AddXY(dt.Rows[i]["INPUT_DATE"].ToString(), decimal.Parse(dt.Rows[i]["INPUT_AMT"].ToString()));
                        chart_item_date.Series[1].Points.AddY(decimal.Parse(dt.Rows[i]["POOR_AMT"].ToString()));
                        if (decimal.Parse(dt.Rows[i]["INPUT_AMT"].ToString()) != 0)
                        {
                            chart_item_date.Series[0].Points[i].Label = decimal.Parse(dt.Rows[i]["INPUT_AMT"].ToString()).ToString("#,0.######");
                        }
                        if (decimal.Parse(dt.Rows[i]["POOR_AMT"].ToString()) != 0 && decimal.Parse(dt.Rows[i]["INPUT_AMT"].ToString()) != 0)
                        {
                            chart_item_date.Series[1].Points[i].Label = decimal.Parse(dt.Rows[i]["POOR_AMT"].ToString()).ToString("#,0.######")
                            + " (" + (decimal.Parse(dt.Rows[i]["POOR_AMT"].ToString()) / (decimal.Parse(dt.Rows[i]["INPUT_AMT"].ToString()) + decimal.Parse(dt.Rows[i]["POOR_AMT"].ToString())) * 100).ToString("#,0.##") + "%)";
                        }
                    }
                }

                dt = wDm.fn_Select_flow_input_Poor_group_by_cd(" and A.F_SUB_DATE >= '" + lbl_start_date.Text + "' and A.F_SUB_DATE <= '" + lbl_end_date.Text + "'   ");
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        chart_flow.Series[0].Points.AddXY(dt.Rows[i]["FLOW_NM"].ToString(), decimal.Parse(dt.Rows[i]["INPUT_AMT"].ToString()));
                        chart_flow.Series[1].Points.AddY(decimal.Parse(dt.Rows[i]["POOR_AMT"].ToString()));
                        if (decimal.Parse(dt.Rows[i]["INPUT_AMT"].ToString()) != 0)
                        {
                            chart_flow.Series[0].Points[i].Label = decimal.Parse(dt.Rows[i]["INPUT_AMT"].ToString()).ToString("#,0.######");
                        }
                        if (decimal.Parse(dt.Rows[i]["POOR_AMT"].ToString()) != 0 && decimal.Parse(dt.Rows[i]["INPUT_AMT"].ToString()) != 0)
                        {
                            chart_flow.Series[1].Points[i].Label = decimal.Parse(dt.Rows[i]["POOR_AMT"].ToString()).ToString("#,0.######")
                            + " (" + (decimal.Parse(dt.Rows[i]["POOR_AMT"].ToString()) / (decimal.Parse(dt.Rows[i]["INPUT_AMT"].ToString()) + decimal.Parse(dt.Rows[i]["POOR_AMT"].ToString())) * 100).ToString("#,0.##") + "%)";
                        }
                    }
                }


                dt = wDm.fn_Select_flow_input_Poor_group_by_date_Day(" and A.INPUT_DATE >= '" + lbl_start_date.Text + "' and A.INPUT_DATE <= '" + lbl_end_date.Text + "'   ", "");
                if (dt != null && dt.Rows.Count > 0)
                {
                    if (dt.Rows.Count == 1) chart_flow_date.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        chart_flow_date.Series[0].Points.AddXY(dt.Rows[i]["INPUT_DATE"].ToString(), decimal.Parse(dt.Rows[i]["INPUT_AMT"].ToString()));
                        chart_flow_date.Series[1].Points.AddY(decimal.Parse(dt.Rows[i]["POOR_AMT"].ToString()));
                        if (decimal.Parse(dt.Rows[i]["INPUT_AMT"].ToString()) != 0)
                        {
                            chart_flow_date.Series[0].Points[i].Label = decimal.Parse(dt.Rows[i]["INPUT_AMT"].ToString()).ToString("#,0.######");
                        }
                        if (decimal.Parse(dt.Rows[i]["POOR_AMT"].ToString()) != 0 && decimal.Parse(dt.Rows[i]["INPUT_AMT"].ToString()) != 0)
                        {
                            chart_flow_date.Series[1].Points[i].Label = decimal.Parse(dt.Rows[i]["POOR_AMT"].ToString()).ToString("#,0.######")
                                 + " (" + (decimal.Parse(dt.Rows[i]["POOR_AMT"].ToString()) / (decimal.Parse(dt.Rows[i]["INPUT_AMT"].ToString()) + decimal.Parse(dt.Rows[i]["POOR_AMT"].ToString())) * 100).ToString("#,0.##") + "%)";
                        }
                    }
                }



                foreach (System.Windows.Forms.DataVisualization.Charting.Chart c in tb_all.Controls)
                {
                    Label_Hide(c);
                }

                



                PrintChart_Raw();

                PrintChart_flow();

                PrintChart_Item();


                for (int i = 0; i < chart_item.Series.Count; i++)
                {
                    for (int j = 0; j < chart_item.Series[i].Points.Count; j++)
                    {
                        chart_item.Series[i].Points[j].LabelToolTip = chart_item.Series[i].Points[j].Label;
                    }
                }
                for (int i = 0; i < chart_item_date.Series.Count; i++)
                {
                    for (int j = 0; j < chart_item_date.Series[i].Points.Count; j++)
                    {
                        chart_item_date.Series[i].Points[j].LabelToolTip = chart_item_date.Series[i].Points[j].Label;
                    }
                }
                for (int i = 0; i < chart_flow_date.Series.Count; i++)
                {
                    for (int j = 0; j < chart_flow_date.Series[i].Points.Count; j++)
                    {
                        chart_flow_date.Series[i].Points[j].LabelToolTip = chart_flow_date.Series[i].Points[j].Label;
                    }
                }
                for (int i = 0; i < chart_flow.Series.Count; i++)
                {
                    for (int j = 0; j < chart_flow.Series[i].Points.Count; j++)
                    {
                        chart_flow.Series[i].Points[j].LabelToolTip = chart_flow.Series[i].Points[j].Label;
                    }
                }

                for (int i = 0; i < chart_raw_detail.Series.Count; i++)
                {
                    for (int j = 0; j < chart_raw_detail.Series[i].Points.Count; j++)
                    {
                        chart_raw_detail.Series[i].Points[j].LabelToolTip = chart_raw_detail.Series[i].Points[j].Label;
                    }
                }

                for (int i = 0; i < chart_item_detail.Series.Count; i++)
                {
                    for (int j = 0; j < chart_item_detail.Series[i].Points.Count; j++)
                    {
                        chart_item_detail.Series[i].Points[j].LabelToolTip = chart_item_detail.Series[i].Points[j].Label;
                    }
                }

                for (int i = 0; i < chart_item_detail2.Series.Count; i++)
                {
                    for (int j = 0; j < chart_item_detail2.Series[i].Points.Count; j++)
                    {
                        chart_item_detail2.Series[i].Points[j].LabelToolTip = chart_item_detail2.Series[i].Points[j].Label;
                    }
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex + "");
            }
        }
        private void PrintChart_flow()
        {
            wnDm wDm = new wnDm();
            DataTable dt = new DataTable();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < f_pnl_Item_white.Controls.Count; i++)
            {
                if (f_pnl_Item_white.Controls[0].Tag == null) break;
                if (i == 0)
                    sb.AppendLine(" and A.FLOW_CD in ( ");

                sb.AppendLine(" '" + f_pnl_Item_white.Controls[i].Tag.ToString() + "'  ");


                if (i == f_pnl_Item_white.Controls.Count - 1)
                    sb.AppendLine(" ) ");
                else
                {
                    sb.AppendLine(",");
                }
            }
            for (int i = 0; i < f_pnl_Item_Black.Controls.Count; i++)
            {
                if (f_pnl_Item_Black.Controls[0].Tag == null) break;
                if (i == 0)
                    sb.AppendLine(" and A.FLOW_CD not in ( ");

                sb.AppendLine(" '" + f_pnl_Item_Black.Controls[i].Tag.ToString() + "'  ");

                if (i == f_pnl_Item_Black.Controls.Count - 1)
                    sb.AppendLine(" ) ");
                else
                {
                    sb.AppendLine(", ");
                }
            }



            //flow
            dt = wDm.fn_Select_flow_input_Poor_group_by_date_Day(" and A.INPUT_DATE >= '" + lbl_start_date.Text + "' and A.INPUT_DATE <= '" + lbl_end_date.Text + "'   ", sb.ToString());
            if (dt != null && dt.Rows.Count > 0)
            {
                if (dt.Rows.Count == 1) chart_item_detail.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    chart_item_detail.Series[0].Points.AddXY(dt.Rows[i]["INPUT_DATE"].ToString(), decimal.Parse(dt.Rows[i]["INPUT_AMT"].ToString()));
                    chart_item_detail.Series[1].Points.AddY(decimal.Parse(dt.Rows[i]["POOR_AMT"].ToString()));
                    if (decimal.Parse(dt.Rows[i]["INPUT_AMT"].ToString()) != 0)
                    {
                        chart_item_detail.Series[0].Points[i].Label = decimal.Parse(dt.Rows[i]["INPUT_AMT"].ToString()).ToString("#,0.######");
                    }
                    if (decimal.Parse(dt.Rows[i]["POOR_AMT"].ToString()) != 0 && decimal.Parse(dt.Rows[i]["INPUT_AMT"].ToString()) != 0)
                    {
                        chart_item_detail.Series[1].Points[i].Label = decimal.Parse(dt.Rows[i]["POOR_AMT"].ToString()).ToString("#,0.######")
                             + " (" + (decimal.Parse(dt.Rows[i]["POOR_AMT"].ToString()) / (decimal.Parse(dt.Rows[i]["INPUT_AMT"].ToString()) + decimal.Parse(dt.Rows[i]["POOR_AMT"].ToString())) * 100).ToString("#,0.##") + "%)";
                    }
                }
            }
            for (int i = 0; i < chart_item_detail.Series.Count; i++)
            {
                for (int j = 0; j < chart_item_detail.Series[i].Points.Count; j++)
                {
                    chart_item_detail.Series[i].Points[j].LabelToolTip = chart_item_detail.Series[i].Points[j].Label;
                }
            }

            SendToBack(chart_item_detail, chart_item_detail.Series[1]);


            dt = wDm.fn_Select_Flow_input_Detail_Poor(" and A.F_SUB_DATE >= '" + lbl_start_date.Text + "' and A.F_SUB_DATE <= '" + lbl_end_date.Text + "'   ", sb.ToString());
            dataItemGrid.Rows.Clear();
            if (dt != null && dt.Rows.Count > 0)
            {
                dataItemGrid.RowCount = dt.Rows.Count;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dataItemGrid.Rows[i].Cells["공정일자2"].Value = dt.Rows[i]["FLOW_DATE"].ToString();
                    dataItemGrid.Rows[i].Cells["제품명2"].Value = dt.Rows[i]["ITEM_NM"].ToString();
                    dataItemGrid.Rows[i].Cells["LOTNO2"].Value = dt.Rows[i]["LOT_NO"].ToString();
                    dataItemGrid.Rows[i].Cells["공정명2"].Value = dt.Rows[i]["FLOW_NM"].ToString();
                    dataItemGrid.Rows[i].Cells["공정코드2"].Value = dt.Rows[i]["FLOW_CD"].ToString();
                    dataItemGrid.Rows[i].Cells["진행수량2"].Value = decimal.Parse(dt.Rows[i]["F_SUB_AMT"].ToString()).ToString("#,0.######");
                    dataItemGrid.Rows[i].Cells["불량유형2"].Value = dt.Rows[i]["POOR_NM"].ToString() + " " + dt.Rows[i]["COMMENT"].ToString();
                    if (decimal.Parse(dt.Rows[i]["POOR_AMT"].ToString()) == 0)
                    {
                        dataItemGrid.Rows[i].Cells["불량수2"].Value = "";
                    }
                    else
                    {
                        dataItemGrid.Rows[i].Cells["불량수2"].Value = decimal.Parse(dt.Rows[i]["POOR_AMT"].ToString()).ToString("#,0.######");
                    }
                    if (decimal.Parse(dt.Rows[i]["POOR_PER"].ToString()) != 0)
                    {
                        dataItemGrid.Rows[i].Cells["불량률2"].Value = decimal.Parse(dt.Rows[i]["POOR_PER"].ToString()).ToString("#,0.######") + "%";
                        if (decimal.Parse(dt.Rows[i]["POOR_PER"].ToString()) > 10)
                        {
                            DataGridViewCellStyle Style = new DataGridViewCellStyle();
                            Style.ForeColor = Color.Red;
                            Style.SelectionForeColor = Color.Red;
                            dataItemGrid.Rows[i].Cells["불량률2"].Style = Style;
                        }
                    }
                    else
                    {
                        dataItemGrid.Rows[i].Cells["불량률2"].Value = "";
                    }

                    if (dataItemGrid.Rows[i].Cells["불량수2"].Value == null || dataItemGrid.Rows[i].Cells["불량수2"].Value.ToString().Equals("") || dataItemGrid.Rows[i].Cells["불량수2"].Value.ToString().Equals("0"))
                    {
                        dataItemGrid.Rows[i].Cells["불량수2"].Value = "";
                    }
                }
            }
        }
        private void PrintChart_Raw()
        {
            wnDm wDm = new wnDm();
            DataTable dt = new DataTable();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < f_pnl_Raw_white.Controls.Count; i++)
            {
                if (f_pnl_Raw_white.Controls[0].Tag == null) break;
                if (i == 0)
                    sb.AppendLine(" and A.RAW_MAT_CD in ( ");

                sb.AppendLine(" '" + f_pnl_Raw_white.Controls[i].Tag.ToString() + "'  ");


                if (i == f_pnl_Raw_white.Controls.Count - 1)
                    sb.AppendLine(" ) ");
                else
                {
                    sb.AppendLine(",");
                }
            }
            for (int i = 0; i < f_pnl_Raw_Black.Controls.Count; i++)
            {
                if (f_pnl_Raw_Black.Controls[0].Tag == null) break;
                if (i == 0)
                    sb.AppendLine(" and A.RAW_MAT_CD not in ( ");

                sb.AppendLine(" '" + f_pnl_Raw_Black.Controls[i].Tag.ToString() + "'  ");

                if (i == f_pnl_Raw_Black.Controls.Count - 1)
                    sb.AppendLine(" ) ");
                else
                {
                    sb.AppendLine(", ");
                }
            }

            dt = wDm.fn_Select_Raw_input_Poor_group_by_date_Day(" and A.INPUT_DATE >= '" + lbl_start_date.Text + "' and A.INPUT_DATE <= '" + lbl_end_date.Text + "' " + sb.ToString() + "  ");
            if (dt != null && dt.Rows.Count > 0)
            {
                if (dt.Rows.Count == 1) chart_raw_detail.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    chart_raw_detail.Series[0].Points.AddXY(dt.Rows[i]["INPUT_DATE"].ToString(), decimal.Parse(dt.Rows[i]["INPUT_AMT"].ToString()));
                    chart_raw_detail.Series[1].Points.AddY(decimal.Parse(dt.Rows[i]["POOR_AMT"].ToString()));
                    if (decimal.Parse(dt.Rows[i]["INPUT_AMT"].ToString()) != 0)
                    {
                        chart_raw_detail.Series[0].Points[i].Label = decimal.Parse(dt.Rows[i]["INPUT_AMT"].ToString()).ToString("#,0.######");
                    }
                    if (decimal.Parse(dt.Rows[i]["POOR_AMT"].ToString()) != 0 && decimal.Parse(dt.Rows[i]["INPUT_AMT"].ToString()) != 0)
                    {
                        chart_raw_detail.Series[1].Points[i].Label = decimal.Parse(dt.Rows[i]["POOR_AMT"].ToString()).ToString("#,0.######")
                             + " (" + (decimal.Parse(dt.Rows[i]["POOR_AMT"].ToString()) / (decimal.Parse(dt.Rows[i]["INPUT_AMT"].ToString())+decimal.Parse(dt.Rows[i]["POOR_AMT"].ToString())) * 100).ToString("#,0.##") + "%)";
                    }
                }
            }

            for (int i = 0; i < chart_raw_detail.Series.Count; i++)
            {
                for (int j = 0; j < chart_raw_detail.Series[i].Points.Count; j++)
                {
                    chart_raw_detail.Series[i].Points[j].LabelToolTip = chart_raw_detail.Series[i].Points[j].Label;
                }
            }

            SendToBack(chart_raw_detail, chart_raw_detail.Series[1]);



            dt = wDm.fn_Select_Raw_input_Detail_Poor(" and A.INPUT_DATE >= '" + lbl_start_date.Text + "' and A.INPUT_DATE <= '" + lbl_end_date.Text + "' " + sb.ToString() + "  ");
            dataRawGrid.Rows.Clear();
            if (dt != null && dt.Rows.Count > 0)
            {
                dataRawGrid.RowCount = dt.Rows.Count;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dataRawGrid.Rows[i].Cells["입고일자"].Value = dt.Rows[i]["INPUT_DATE"].ToString();
                    dataRawGrid.Rows[i].Cells["자재명"].Value = dt.Rows[i]["RAW_MAT_NM"].ToString();
                    dataRawGrid.Rows[i].Cells["구매처"].Value = dt.Rows[i]["CUST_NM"].ToString();
                    dataRawGrid.Rows[i].Cells["입고수량"].Value = decimal.Parse(dt.Rows[i]["INPUT_AMT"].ToString()).ToString("#,0.######");
                    dataRawGrid.Rows[i].Cells["불량유형"].Value = dt.Rows[i]["POOR_NM"].ToString() + " " + dt.Rows[i]["POOR_COUNT"].ToString();
                    if (dt.Rows[i]["POOR_AMT"].ToString().Equals("") || dt.Rows[i]["POOR_AMT"].ToString().Equals("0"))
                    {
                        dataRawGrid.Rows[i].Cells["불량수"].Value = "";
                    }
                    else
                    {
                        dataRawGrid.Rows[i].Cells["불량수"].Value = decimal.Parse(dt.Rows[i]["POOR_AMT"].ToString()).ToString("#,0.######");
                    }
                    if (!dt.Rows[i]["POOR_PER"].ToString().Equals(""))
                    {
                        dataRawGrid.Rows[i].Cells["불량률"].Value = decimal.Parse(dt.Rows[i]["POOR_PER"].ToString()).ToString("#,0.######") + "%";
                        if (decimal.Parse(dt.Rows[i]["POOR_PER"].ToString()) > 10)
                        {
                            DataGridViewCellStyle Style = new DataGridViewCellStyle();
                            Style.ForeColor = Color.Red;
                            Style.SelectionForeColor = Color.Red;
                            dataRawGrid.Rows[i].Cells["구매처"].Style = Style;
                            dataRawGrid.Rows[i].Cells["불량률"].Style = Style;
                        }
                    }
                    else
                    {
                        dataRawGrid.Rows[i].Cells["불량률"].Value = "";
                    }
                }
            }
        }
        private void PrintChart_Item()
        {
            wnDm wDm = new wnDm();
            DataTable dt = new DataTable();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < f_pnl_Item_White2.Controls.Count; i++)
            {
                if (f_pnl_Item_White2.Controls[0].Tag == null) break;
                if (i == 0)
                    sb.AppendLine(" and A.ITEM_CD in ( ");

                sb.AppendLine(" '" + f_pnl_Item_White2.Controls[i].Tag.ToString() + "'  ");


                if (i == f_pnl_Item_White2.Controls.Count - 1)
                    sb.AppendLine(" ) ");
                else
                {
                    sb.AppendLine(",");
                }
            }
            for (int i = 0; i < f_pnl_Item_Black2.Controls.Count; i++)
            {
                if (f_pnl_Item_Black2.Controls[0].Tag == null) break;
                if (i == 0)
                    sb.AppendLine(" and A.ITEM_CD not in ( ");

                sb.AppendLine(" '" + f_pnl_Item_Black2.Controls[i].Tag.ToString() + "'  ");

                if (i == f_pnl_Item_Black2.Controls.Count - 1)
                    sb.AppendLine(" ) ");
                else
                {
                    sb.AppendLine(", ");
                }
            }

            //item
            dt = wDm.fn_Select_Item_input_Poor_group_by_date_Day(" and A.INPUT_DATE >= '" + lbl_start_date.Text + "' and A.INPUT_DATE <= '" + lbl_end_date.Text + "'   ", sb.ToString());
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
                             + " (" + (decimal.Parse(dt.Rows[i]["POOR_AMT"].ToString()) / (decimal.Parse(dt.Rows[i]["INPUT_AMT"].ToString())+decimal.Parse(dt.Rows[i]["POOR_AMT"].ToString())) * 100).ToString("#,0.##") + "%)";
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

            dt = wDm.fn_Select_Item_input_Detail_Poor(" and A.F_SUB_DATE >= '" + lbl_start_date.Text + "' and A.F_SUB_DATE <= '" + lbl_end_date.Text + "'   ", sb.ToString());
            dataItemGrid2.Rows.Clear();

            if (dt != null && dt.Rows.Count > 0)
            {
                dataItemGrid2.RowCount = dt.Rows.Count;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dataItemGrid2.Rows[i].Cells["생산일자3"].Value = dt.Rows[i]["FLOW_DATE"].ToString();
                    dataItemGrid2.Rows[i].Cells["제품명3"].Value = dt.Rows[i]["ITEM_NM"].ToString();
                    dataItemGrid2.Rows[i].Cells["LOT_NO3"].Value = dt.Rows[i]["LOT_NO"].ToString();
                    dataItemGrid2.Rows[i].Cells["LOT_SUB3"].Value = dt.Rows[i]["LOT_SUB"].ToString();
                    dataItemGrid2.Rows[i].Cells["완제품공정명3"].Value = dt.Rows[i]["FLOW_NM"].ToString();
                    dataItemGrid2.Rows[i].Cells["공정코드3"].Value = dt.Rows[i]["FLOW_CD"].ToString();
                    dataItemGrid2.Rows[i].Cells["생산수량3"].Value = decimal.Parse(dt.Rows[i]["F_SUB_AMT"].ToString()).ToString("#,0.######");
                    dataItemGrid2.Rows[i].Cells["불량유형3"].Value = dt.Rows[i]["POOR_NM"].ToString() + " " + dt.Rows[i]["COMMENT"].ToString();
                    if (decimal.Parse(dt.Rows[i]["POOR_AMT"].ToString()) == 0)
                    {
                        dataItemGrid2.Rows[i].Cells["불량수3"].Value = "";
                    }
                    else
                    {
                        dataItemGrid2.Rows[i].Cells["불량수3"].Value = decimal.Parse(dt.Rows[i]["POOR_AMT"].ToString()).ToString("#,0.######");
                    }
                    if (decimal.Parse(dt.Rows[i]["POOR_PER"].ToString()) != 0)
                    {
                        dataItemGrid2.Rows[i].Cells["불량률3"].Value = decimal.Parse(dt.Rows[i]["POOR_PER"].ToString()).ToString("#,0.######") + "%";
                        if (decimal.Parse(dt.Rows[i]["POOR_PER"].ToString()) > 10)
                        {
                            DataGridViewCellStyle Style = new DataGridViewCellStyle();
                            Style.ForeColor = Color.Red;
                            Style.SelectionForeColor = Color.Red;
                            dataItemGrid2.Rows[i].Cells["불량률3"].Style = Style;
                        }
                    }
                    else
                    {
                        dataItemGrid2.Rows[i].Cells["불량률3"].Value = "";
                    }

                    if (dataItemGrid2.Rows[i].Cells["불량수3"].Value == null || dataItemGrid2.Rows[i].Cells["불량수3"].Value.ToString().Equals("") || dataItemGrid2.Rows[i].Cells["불량수3"].Value.ToString().Equals("0"))
                    {
                        dataItemGrid2.Rows[i].Cells["불량수3"].Value = "";
                    }
                }
            }
        }

        #endregion PrintChartLogic

        #region SetDateLogic
        private void set_BtnSetDateValue()
        {
            btn_SetDate.Text = lbl_start_date.Text + " - " + lbl_end_date.Text + " ▼";
        }
        private void btn_SetDate_Click(object sender, EventArgs e)
        {

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
        #endregion SetDateLogic

        #region resettingChartLogic
        private void ResetChart()
        {
            chart_raw.Series.Clear();
            chart_raw.Series.Add("입고량");
            chart_raw.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            chart_raw.Series[0].Color = ColorBlue;
            chart_raw.Series[0].YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Primary;
            chart_raw.BorderlineWidth = 1;
            chart_raw.Series.Add("불량건수");
            chart_raw.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart_raw.Series[1].Color = ColorOrange;
            chart_raw.Series[1].BorderWidth = 3;
            chart_raw.Series[1].YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            chart_raw.Series[1].ToolTip = "불량건수";
            chart_raw.Series[0].ToolTip = "입고량";
            chart_raw.Series[0].LabelBorderColor = Color.FromArgb(64, 64, 64);
            chart_raw.Series[0].LabelBorderWidth = 1;
            chart_raw.Series[0].LabelBackColor = Color.WhiteSmoke;
            chart_raw.Series[1].LabelBorderColor = Color.FromArgb(64, 64, 64);
            chart_raw.Series[1].LabelBorderWidth = 0;
            chart_raw.Series[1].LabelBackColor = ColorOrange;
            chart_raw.Series[1].LabelForeColor = Color.WhiteSmoke;

            chart_item.Series.Clear();
            chart_item.Series.Add("생산량");
            chart_item.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            chart_item.Series[0].Color = ColorBlue;
            chart_item.Series[0].YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Primary;
            chart_item.BorderlineWidth = 1;
            chart_item.Series.Add("불량건수");
            chart_item.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart_item.Series[1].Color = ColorOrange;
            chart_item.Series[1].YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            chart_item.Series[1].ToolTip = "불량건수";
            chart_item.Series[0].ToolTip = "생산량";
            chart_item.Series[1].BorderWidth = 3;
            chart_item.Series[0].LabelBorderColor = Color.FromArgb(64, 64, 64);
            chart_item.Series[0].LabelBorderWidth = 1;
            chart_item.Series[0].LabelBackColor = Color.WhiteSmoke;
            chart_item.Series[1].LabelBorderColor = Color.FromArgb(64, 64, 64);
            chart_item.Series[1].LabelBorderWidth = 0;
            chart_item.Series[1].LabelBackColor = ColorOrange;
            chart_item.Series[1].LabelForeColor = Color.WhiteSmoke;

            chart_raw_date.Series.Clear();
            chart_raw_date.Series.Add("입고량");
            chart_raw_date.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            chart_raw_date.Series[0].Color = ColorBlue;
            chart_raw_date.Series[0].YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Primary;
            chart_raw_date.BorderlineWidth = 1;
            chart_raw_date.Series.Add("불량건수");
            chart_raw_date.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart_raw_date.Series[1].Color = ColorOrange;
            chart_raw_date.Series[1].YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            chart_raw_date.Series[1].ToolTip = "불량건수";
            chart_raw_date.Series[0].ToolTip = "입고량";
            chart_raw_date.Series[1].BorderWidth = 3;
            chart_raw_date.Series[0].LabelBorderColor = Color.FromArgb(64, 64, 64);
            chart_raw_date.Series[0].LabelBorderWidth = 1;
            chart_raw_date.Series[0].LabelBackColor = Color.WhiteSmoke;
            chart_raw_date.Series[1].LabelBorderColor = Color.FromArgb(64, 64, 64);
            chart_raw_date.Series[1].LabelBorderWidth = 0;
            chart_raw_date.Series[1].LabelBackColor = ColorOrange;
            chart_raw_date.Series[1].LabelForeColor = Color.WhiteSmoke;

            chart_flow.Series.Clear();
            chart_flow.Series.Add("진행량");
            chart_flow.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            chart_flow.Series[0].Color = ColorBlue;
            chart_flow.Series[0].YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Primary;
            chart_flow.BorderlineWidth = 1;
            chart_flow.Series.Add("불량건수");
            chart_flow.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart_flow.Series[1].Color = ColorOrange;
            chart_flow.Series[1].YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            chart_flow.Series[1].ToolTip = "불량건수";
            chart_flow.Series[0].ToolTip = "진행량";
            chart_flow.Series[1].BorderWidth = 3;
            chart_flow.Series[0].LabelBorderColor = Color.FromArgb(64, 64, 64);
            chart_flow.Series[0].LabelBorderWidth = 1;
            chart_flow.Series[0].LabelBackColor = Color.WhiteSmoke;
            chart_flow.Series[1].LabelBorderColor = Color.FromArgb(64, 64, 64);
            chart_flow.Series[1].LabelBorderWidth = 0;
            chart_flow.Series[1].LabelBackColor = ColorOrange;
            chart_flow.Series[1].LabelForeColor = Color.WhiteSmoke;

            chart_item_date.Series.Clear();
            chart_item_date.Series.Add("생산량");
            chart_item_date.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            chart_item_date.Series[0].Color = ColorBlue;
            chart_item_date.Series[0].YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Primary;
            chart_item_date.BorderlineWidth = 1;
            chart_item_date.Series.Add("불량건수");
            chart_item_date.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart_item_date.Series[1].Color = ColorOrange;
            chart_item_date.Series[1].YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            chart_item_date.Series[1].ToolTip = "불량건수";
            chart_item_date.Series[0].ToolTip = "생산량";
            chart_item_date.Series[1].BorderWidth = 3;
            chart_item_date.Series[0].LabelBorderColor = Color.FromArgb(64, 64, 64);
            chart_item_date.Series[0].LabelBorderWidth = 1;
            chart_item_date.Series[0].LabelBackColor = Color.WhiteSmoke;
            chart_item_date.Series[1].LabelBorderColor = Color.FromArgb(64, 64, 64);
            chart_item_date.Series[1].LabelBorderWidth = 0;
            chart_item_date.Series[1].LabelBackColor = ColorOrange;
            chart_item_date.Series[1].LabelForeColor = Color.WhiteSmoke;




            chart_flow_date.Series.Clear();
            chart_flow_date.Series.Add("진행량");
            chart_flow_date.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            chart_flow_date.Series[0].Color = ColorBlue;
            chart_flow_date.Series[0].YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Primary;
            chart_flow_date.BorderlineWidth = 1;
            chart_flow_date.Series.Add("불량건수");
            chart_flow_date.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart_flow_date.Series[1].Color = ColorOrange;
            chart_flow_date.Series[1].YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            chart_flow_date.Series[1].ToolTip = "불량건수";
            chart_flow_date.Series[0].ToolTip = "진행량";
            chart_flow_date.Series[1].BorderWidth = 3;
            chart_flow_date.Series[0].LabelBorderColor = Color.FromArgb(64, 64, 64);
            chart_flow_date.Series[0].LabelBorderWidth = 1;
            chart_flow_date.Series[0].LabelBackColor = Color.WhiteSmoke;
            chart_flow_date.Series[1].LabelBorderColor = Color.FromArgb(64, 64, 64);
            chart_flow_date.Series[1].LabelBorderWidth = 0;
            chart_flow_date.Series[1].LabelBackColor = ColorOrange;
            chart_flow_date.Series[1].LabelForeColor = Color.WhiteSmoke;



            chart_raw_detail.Series.Clear();
            chart_raw_detail.Series.Add("입고량");
            chart_raw_detail.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart_raw_detail.Series[0].Color = ColorBlue;
            chart_raw_detail.Series[0].YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Primary;
            chart_raw_detail.Series[0].BorderWidth = 3;
            chart_raw_detail.BorderlineWidth = 1;
            chart_raw_detail.Series.Add("불량건수");
            chart_raw_detail.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            chart_raw_detail.Series[1].Color = ColorOrange;
            //chart_raw_detail.Series[1].YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            chart_raw_detail.Series[1].ToolTip = "불량건수";
            chart_raw_detail.Series[0].ToolTip = "입고량";
            chart_raw_detail.Series[0].LabelBorderColor = Color.FromArgb(64, 64, 64);
            chart_raw_detail.Series[0].LabelBorderWidth = 1;
            chart_raw_detail.Series[0].LabelBackColor = Color.WhiteSmoke;
            chart_raw_detail.Series[1].LabelBorderColor = Color.FromArgb(64, 64, 64);
            chart_raw_detail.Series[1].LabelBorderWidth = 0;
            chart_raw_detail.Series[1].LabelBackColor = ColorOrange;
            chart_raw_detail.Series[1].LabelForeColor = Color.WhiteSmoke;

            chart_item_detail.Series.Clear();
            chart_item_detail.Series.Add("진행량");
            chart_item_detail.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart_item_detail.Series[0].Color = ColorBlue;
            chart_item_detail.Series[0].YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Primary;
            chart_item_detail.Series[0].BorderWidth = 3;
            chart_item_detail.BorderlineWidth = 1;
            chart_item_detail.Series.Add("불량건수");
            chart_item_detail.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            chart_item_detail.Series[1].Color = ColorOrange;
            //chart_item_detailil.Series[1].YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            chart_item_detail.Series[1].ToolTip = "불량건수";
            chart_item_detail.Series[0].ToolTip = "진행량";
            chart_item_detail.Series[0].LabelBorderColor = Color.FromArgb(64, 64, 64);
            chart_item_detail.Series[0].LabelBorderWidth = 1;
            chart_item_detail.Series[0].LabelBackColor = Color.WhiteSmoke;
            chart_item_detail.Series[1].LabelBorderColor = Color.FromArgb(64, 64, 64);
            chart_item_detail.Series[1].LabelBorderWidth = 0;
            chart_item_detail.Series[1].LabelBackColor = ColorOrange;
            chart_item_detail.Series[1].LabelForeColor = Color.WhiteSmoke;

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
        private void ResetChart_Only_flow()
        {
            chart_item_detail.Series.Clear();
            chart_item_detail.Series.Add("진행량");
            chart_item_detail.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart_item_detail.Series[0].Color = ColorBlue;
            chart_item_detail.Series[0].YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Primary;
            chart_item_detail.Series[0].BorderWidth = 3;
            chart_item_detail.BorderlineWidth = 1;
            chart_item_detail.Series.Add("불량건수");
            chart_item_detail.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            chart_item_detail.Series[1].Color = ColorOrange;
            //chart_item_detailil.Series[1].YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            chart_item_detail.Series[1].ToolTip = "불량건수";
            chart_item_detail.Series[0].ToolTip = "진행량";
            chart_item_detail.Series[0].LabelBorderColor = Color.FromArgb(64, 64, 64);
            chart_item_detail.Series[0].LabelBorderWidth = 1;
            chart_item_detail.Series[0].LabelBackColor = Color.WhiteSmoke;
            chart_item_detail.Series[1].LabelBorderColor = Color.FromArgb(64, 64, 64);
            chart_item_detail.Series[1].LabelBorderWidth = 0;
            chart_item_detail.Series[1].LabelBackColor = ColorOrange;
            chart_item_detail.Series[1].LabelForeColor = Color.WhiteSmoke;
        }
        private void ResetChart_Only_Raw()
        {
            chart_raw_detail.Series.Clear();
            chart_raw_detail.Series.Add("입고량");
            chart_raw_detail.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart_raw_detail.Series[0].Color = ColorBlue;
            chart_raw_detail.Series[0].YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Primary;
            chart_raw_detail.Series[0].BorderWidth = 3;
            chart_raw_detail.BorderlineWidth = 1;
            chart_raw_detail.Series.Add("불량건수");
            chart_raw_detail.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            chart_raw_detail.Series[1].Color = ColorOrange;
            //chart_raw_detail.Series[1].YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            chart_raw_detail.Series[1].ToolTip = "불량건수";
            chart_raw_detail.Series[0].ToolTip = "입고량";
            chart_raw_detail.Series[0].LabelBorderColor = Color.FromArgb(64, 64, 64);
            chart_raw_detail.Series[0].LabelBorderWidth = 1;
            chart_raw_detail.Series[0].LabelBackColor = Color.WhiteSmoke;
            chart_raw_detail.Series[1].LabelBorderColor = Color.FromArgb(64, 64, 64);
            chart_raw_detail.Series[1].LabelBorderWidth = 0;
            chart_raw_detail.Series[1].LabelBackColor = ColorOrange;
            chart_raw_detail.Series[1].LabelForeColor = Color.WhiteSmoke;
        }
        private void ResetChart_Only_Item()
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

        #endregion resettingChartLogic

        #region tabControl Logic
        private void btn_all_Click(object sender, EventArgs e)
        {
            if (!pnl_all.Visible)
            {
                pnl_all.Visible = true;
                pnl_raw.Visible = false;
                pnl_flow.Visible = false;
                pnl_item.Visible = false;
                btn_all.BackColor = Color.White;
                btn_raw.BackColor = Color.Gainsboro;
                btn_flow.BackColor = Color.Gainsboro;
                btn_item.BackColor = Color.Gainsboro;

                btn_flow.Location = new Point(btn_flow.Location.X, 8);
                btn_raw.Location = new Point(btn_raw.Location.X, 8);
                btn_item.Location = new Point(btn_item.Location.X, 8);
                btn_all.Location = new Point(btn_all.Location.X, btn_all.Location.Y + 3);
            }
        }
        private void btn_raw_Click(object sender, EventArgs e)
        {
            if (!pnl_raw.Visible)
            {
                pnl_all.Visible = false;
                pnl_raw.Visible = true;
                pnl_flow.Visible = false;
                pnl_item.Visible = false;

                btn_all.BackColor = Color.Gainsboro;
                btn_raw.BackColor = Color.White;
                btn_flow.BackColor = Color.Gainsboro;
                btn_item.BackColor = Color.Gainsboro;

                btn_flow.Location = new Point(btn_flow.Location.X, 8);
                btn_raw.Location = new Point(btn_raw.Location.X, btn_raw.Location.Y + 3);
                btn_all.Location = new Point(btn_all.Location.X, 8);
                btn_item.Location = new Point(btn_item.Location.X, 8);
            }
        }
        private void btn_flow_Click(object sender, EventArgs e)
        {
            if (!pnl_flow.Visible)
            {
                pnl_all.Visible = false;
                pnl_raw.Visible = false;
                pnl_flow.Visible = true;
                pnl_item.Visible = false;

                btn_all.BackColor = Color.Gainsboro;
                btn_raw.BackColor = Color.Gainsboro;
                btn_flow.BackColor = Color.White;
                btn_item.BackColor = Color.Gainsboro;

                btn_flow.Location = new Point(btn_flow.Location.X, btn_flow.Location.Y + 3);
                btn_raw.Location = new Point(btn_raw.Location.X, 8);
                btn_all.Location = new Point(btn_all.Location.X, 8);
                btn_item.Location = new Point(btn_item.Location.X, 8);
            }
        }
        private void btn_item_Click(object sender, EventArgs e)
        {
            if (!pnl_item.Visible)
            {
                pnl_all.Visible = false;
                pnl_raw.Visible = false;
                pnl_flow.Visible = false;
                pnl_item.Visible = true;

                btn_all.BackColor = Color.Gainsboro;
                btn_raw.BackColor = Color.Gainsboro;
                btn_flow.BackColor = Color.Gainsboro;
                btn_item.BackColor = Color.White;

                btn_item.Location = new Point(btn_item.Location.X, btn_item.Location.Y + 3);
                btn_raw.Location = new Point(btn_raw.Location.X, 8);
                btn_all.Location = new Point(btn_all.Location.X, 8);
                btn_flow.Location = new Point(btn_flow.Location.X, 8);
            }
        }
        #endregion tabControl Logic

        #region Static Button Logic
        private void btn_raw_filter_BlackList_Click(object sender, EventArgs e)
        {
            Popup.pop원부재료검색 frm = new Popup.pop원부재료검색();
            //frm.sUsedYN = sUsedYN;
            //frm.dt = dt;
            if (txt_Srch_Black.Text == null) txt_Srch_Black.Text = "";
            frm.txtSrch.Text = txt_Srch_Black.Text;
            frm.ShowDialog();

            if (frm.sRetCode != "")
            {

                if (f_pnl_Raw_Black.Controls[0].Tag == null)
                {
                    f_pnl_Raw_Black.Controls.Clear();
                    SetRawWhite_To_Default();
                    btn_raw_filter_WhiteList.Enabled = false;
                    txt_Srch_White.Enabled = false;
                }

                if (f_pnl_Raw_Black.Controls.Count > 9) { MessageBox.Show("필터는 10개이상 등록할 수 없습니다"); return; }
                FlowLayoutPanel pnTemp = new FlowLayoutPanel();
                pnTemp.AutoSize = true;
                pnTemp.Padding = new Padding(0);
                pnTemp.Margin = new Padding(0);
                pnTemp.BackColor = Color.LemonChiffon;
                pnTemp.Tag = frm.dgv.Rows[0].Cells["RAW_MAT_CD"].Value.ToString();

                Label labelTemp = new Label();
                labelTemp.Text = frm.dgv.Rows[0].Cells["RAW_MAT_NM"].Value.ToString();
                labelTemp.Tag = frm.dgv.Rows[0].Cells["RAW_MAT_CD"].Value.ToString();
                labelTemp.AutoSize = true;
                labelTemp.TextAlign = ContentAlignment.MiddleCenter;
                labelTemp.Margin = new Padding(0, 5, 0, 0);

                Button del_BtnTemp = new Button();
                del_BtnTemp.Text = "X";
                del_BtnTemp.Padding = new Padding(0);
                del_BtnTemp.TextAlign = ContentAlignment.MiddleCenter;
                del_BtnTemp.FlatStyle = FlatStyle.Flat;
                del_BtnTemp.BackColor = Color.Red;
                del_BtnTemp.ForeColor = Color.WhiteSmoke;
                del_BtnTemp.Size = new System.Drawing.Size(15, 15);
                del_BtnTemp.Click += del_BtnTempBlack_Click;

                pnTemp.BorderStyle = BorderStyle.FixedSingle;
                pnTemp.Controls.Add(labelTemp);
                pnTemp.Controls.Add(del_BtnTemp);

                f_pnl_Raw_Black.Controls.Add(pnTemp);


            }
            else
            {

                if (f_pnl_Raw_Black.Controls[0].Tag == null)
                {
                    f_pnl_Raw_Black.Controls.Clear();
                    SetRawWhite_To_Default();
                    btn_raw_filter_WhiteList.Enabled = false;
                    txt_Srch_White.Enabled = false;
                }

                if (frm.list.Count > 0) /*선택된 셀이 1개 이상일 때 */
                {
                    for (int i = 0; i < frm.list.Count; i++)
                    {
                        //dgv.Rows[nRow].Cells["RAW_MAT_CD"].Value = frm.dgv.Rows[frm.list[i]].Cells["RAW_MAT_CD"].Value;
                        if (f_pnl_Raw_Black.Controls.Count > 9) { MessageBox.Show("필터는 10개이상 등록할 수 없습니다"); break; }
                        FlowLayoutPanel pnTemp = new FlowLayoutPanel();
                        pnTemp.AutoSize = true;
                        pnTemp.Padding = new Padding(0);
                        pnTemp.Margin = new Padding(0);
                        pnTemp.BackColor = Color.LemonChiffon;
                        pnTemp.Tag = frm.dgv.Rows[frm.list[i]].Cells["RAW_MAT_CD"].Value.ToString();

                        Label labelTemp = new Label();
                        labelTemp.Text = frm.dgv.Rows[frm.list[i]].Cells["RAW_MAT_NM"].Value.ToString();
                        labelTemp.Tag = frm.dgv.Rows[frm.list[i]].Cells["RAW_MAT_CD"].Value.ToString();
                        labelTemp.AutoSize = true;
                        labelTemp.TextAlign = ContentAlignment.MiddleCenter;
                        labelTemp.Margin = new Padding(0, 5, 0, 0);

                        Button del_BtnTemp = new Button();
                        del_BtnTemp.Text = "X";
                        del_BtnTemp.Padding = new Padding(0);
                        del_BtnTemp.TextAlign = ContentAlignment.MiddleCenter;
                        del_BtnTemp.FlatStyle = FlatStyle.Flat;
                        del_BtnTemp.BackColor = Color.Red;
                        del_BtnTemp.ForeColor = Color.WhiteSmoke;
                        del_BtnTemp.Click += del_BtnTempBlack_Click;
                        del_BtnTemp.Size = new System.Drawing.Size(15, 15);

                        pnTemp.BorderStyle = BorderStyle.FixedSingle;
                        pnTemp.Controls.Add(labelTemp);
                        pnTemp.Controls.Add(del_BtnTemp);

                        f_pnl_Raw_Black.Controls.Add(pnTemp);

                        if (i == frm.list.Count - 1)
                        {
                            break;
                        }
                    }
                }
            }

            ResetChart_Only_Raw();
            PrintChart_Raw();
        }
        private void btn_raw_filter_WhiteList_Click(object sender, EventArgs e)
        {
            Popup.pop원부재료검색 frm = new Popup.pop원부재료검색();
            //frm.sUsedYN = sUsedYN;
            //frm.dt = dt;
            if (txt_Srch_White.Text == null) txt_Srch_White.Text = "";
            frm.txtSrch.Text = txt_Srch_White.Text;
            frm.ShowDialog();

            if (frm.sRetCode != "")
            {

                if (f_pnl_Raw_white.Controls[0].Tag == null)
                {
                    f_pnl_Raw_white.Controls.Clear();
                    SetRawBlack_To_Default();
                    btn_raw_filter_BlackList.Enabled = false;
                    txt_Srch_Black.Enabled = false;
                }

                if (f_pnl_Raw_white.Controls.Count > 9) { MessageBox.Show("필터는 10개이상 등록할 수 없습니다"); return; }
                FlowLayoutPanel pnTemp = new FlowLayoutPanel();
                pnTemp.AutoSize = true;
                pnTemp.Padding = new Padding(0);
                pnTemp.Margin = new Padding(0);
                pnTemp.BackColor = Color.LemonChiffon;
                pnTemp.Tag = frm.dgv.Rows[0].Cells["RAW_MAT_CD"].Value.ToString();

                Label labelTemp = new Label();
                labelTemp.Text = frm.dgv.Rows[0].Cells["RAW_MAT_NM"].Value.ToString();
                labelTemp.Tag = frm.dgv.Rows[0].Cells["RAW_MAT_CD"].Value.ToString();
                labelTemp.AutoSize = true;
                labelTemp.TextAlign = ContentAlignment.MiddleCenter;
                labelTemp.Margin = new Padding(0, 5, 0, 0);

                Button del_BtnTemp = new Button();
                del_BtnTemp.Text = "X";
                del_BtnTemp.Padding = new Padding(0);
                del_BtnTemp.TextAlign = ContentAlignment.MiddleCenter;
                del_BtnTemp.FlatStyle = FlatStyle.Flat;
                del_BtnTemp.BackColor = Color.Red;
                del_BtnTemp.ForeColor = Color.WhiteSmoke;
                del_BtnTemp.Size = new System.Drawing.Size(15, 15);
                del_BtnTemp.Click += del_BtnTempWhite_Click;

                pnTemp.BorderStyle = BorderStyle.FixedSingle;
                pnTemp.Controls.Add(labelTemp);
                pnTemp.Controls.Add(del_BtnTemp);

                f_pnl_Raw_white.Controls.Add(pnTemp);


            }
            else
            {
                if (frm.list.Count > 0) /*선택된 셀이 1개 이상일 때 */
                {
                    if (f_pnl_Raw_white.Controls[0].Tag == null)
                    {
                        f_pnl_Raw_white.Controls.Clear();
                        SetRawBlack_To_Default();
                        btn_raw_filter_BlackList.Enabled = false;
                        txt_Srch_Black.Enabled = false;
                    }

                    for (int i = 0; i < frm.list.Count; i++)
                    {
                        //dgv.Rows[nRow].Cells["RAW_MAT_CD"].Value = frm.dgv.Rows[frm.list[i]].Cells["RAW_MAT_CD"].Value;
                        if (f_pnl_Raw_white.Controls.Count > 9) { MessageBox.Show("필터는 10개이상 등록할 수 없습니다"); break; }
                        FlowLayoutPanel pnTemp = new FlowLayoutPanel();
                        pnTemp.AutoSize = true;
                        pnTemp.Padding = new Padding(0);
                        pnTemp.Margin = new Padding(0);
                        pnTemp.BackColor = Color.LemonChiffon;
                        pnTemp.Tag = frm.dgv.Rows[frm.list[i]].Cells["RAW_MAT_CD"].Value.ToString();

                        Label labelTemp = new Label();
                        labelTemp.Text = frm.dgv.Rows[frm.list[i]].Cells["RAW_MAT_NM"].Value.ToString();
                        labelTemp.Tag = frm.dgv.Rows[frm.list[i]].Cells["RAW_MAT_CD"].Value.ToString();
                        labelTemp.AutoSize = true;
                        labelTemp.TextAlign = ContentAlignment.MiddleCenter;
                        labelTemp.Margin = new Padding(0, 5, 0, 0);

                        Button del_BtnTemp = new Button();
                        del_BtnTemp.Text = "X";
                        del_BtnTemp.Padding = new Padding(0);
                        del_BtnTemp.TextAlign = ContentAlignment.MiddleCenter;
                        del_BtnTemp.FlatStyle = FlatStyle.Flat;
                        del_BtnTemp.BackColor = Color.Red;
                        del_BtnTemp.ForeColor = Color.WhiteSmoke;
                        del_BtnTemp.Size = new System.Drawing.Size(15, 15);
                        del_BtnTemp.Click += del_BtnTempWhite_Click;

                        pnTemp.BorderStyle = BorderStyle.FixedSingle;
                        pnTemp.Controls.Add(labelTemp);
                        pnTemp.Controls.Add(del_BtnTemp);

                        f_pnl_Raw_white.Controls.Add(pnTemp);

                        if (i == frm.list.Count - 1)
                        {
                            break;
                        }
                    }
                }
            }

            ResetChart_Only_Raw();
            PrintChart_Raw();

        }
        private void btn_flow_filter_BlackList_Click(object sender, EventArgs e)
        {
            Popup.pop공정검색 frm = new Popup.pop공정검색();
            //frm.sUsedYN = sUsedYN;
            //frm.dt = dt;
            if (txt_Srch_Black2.Text == null) txt_Srch_Black2.Text = "";
            frm.txtSrch.Text = txt_Srch_Black2.Text;
            frm.ShowDialog();

            if (frm.sRetCode != "")
            {
                if (f_pnl_Item_Black.Controls[0].Tag == null)
                {
                    f_pnl_Item_Black.Controls.Clear();
                    SetItemWhite_To_Default();
                    btn_Item_filter_WhiteList.Enabled = false;
                    txt_Srch_White2.Enabled = false;
                }

                if (f_pnl_Item_Black.Controls.Count > 9) { MessageBox.Show("필터는 10개이상 등록할 수 없습니다"); return; }
                FlowLayoutPanel pnTemp = new FlowLayoutPanel();
                pnTemp.AutoSize = true;
                pnTemp.Padding = new Padding(0);
                pnTemp.Margin = new Padding(0);
                pnTemp.BackColor = Color.LemonChiffon;
                pnTemp.Tag = frm.sRetCode;

                Label labelTemp = new Label();
                labelTemp.Text = frm.sRetName;
                labelTemp.Tag = frm.sRetCode;
                labelTemp.AutoSize = true;
                labelTemp.TextAlign = ContentAlignment.MiddleCenter;
                labelTemp.Margin = new Padding(0, 5, 0, 0);

                Button del_BtnTemp = new Button();
                del_BtnTemp.Text = "X";
                del_BtnTemp.Padding = new Padding(0);
                del_BtnTemp.TextAlign = ContentAlignment.MiddleCenter;
                del_BtnTemp.FlatStyle = FlatStyle.Flat;
                del_BtnTemp.BackColor = Color.Red;
                del_BtnTemp.ForeColor = Color.WhiteSmoke;
                del_BtnTemp.Size = new System.Drawing.Size(15, 15);
                del_BtnTemp.Click += del_BtnTempBlack_Click2;

                pnTemp.BorderStyle = BorderStyle.FixedSingle;
                pnTemp.Controls.Add(labelTemp);
                pnTemp.Controls.Add(del_BtnTemp);

                f_pnl_Item_Black.Controls.Add(pnTemp);
            }
            else
            {
                if (frm.list.Count > 0) /*선택된 셀이 1개 이상일 때 */
                {
                    if (f_pnl_Item_Black.Controls[0].Tag == null)
                    {
                        f_pnl_Item_Black.Controls.Clear();
                        SetItemWhite_To_Default();
                        btn_Item_filter_WhiteList.Enabled = false;
                        txt_Srch_White2.Enabled = false;
                    }

                    for (int i = 0; i < frm.list.Count; i++)
                    {
                        //dgv.Rows[nRow].Cells["Item_MAT_CD"].Value = frm.dgv.Rows[frm.list[i]].Cells["Item_MAT_CD"].Value;
                        if (f_pnl_Item_Black.Controls.Count > 9) { MessageBox.Show("필터는 10개이상 등록할 수 없습니다"); break; }
                        FlowLayoutPanel pnTemp = new FlowLayoutPanel();
                        pnTemp.AutoSize = true;
                        pnTemp.Padding = new Padding(0);
                        pnTemp.Margin = new Padding(0);
                        pnTemp.BackColor = Color.LemonChiffon;
                        pnTemp.Tag = frm.GridRecord.Rows[frm.list[i]].Cells["FLOW_CD"].Value.ToString();

                        Label labelTemp = new Label();
                        labelTemp.Text = frm.GridRecord.Rows[frm.list[i]].Cells["FLOW_NM"].Value.ToString();
                        labelTemp.Tag = frm.GridRecord.Rows[frm.list[i]].Cells["FLOW_CD"].Value.ToString();
                        labelTemp.AutoSize = true;
                        labelTemp.TextAlign = ContentAlignment.MiddleCenter;
                        labelTemp.Margin = new Padding(0, 5, 0, 0);

                        Button del_BtnTemp = new Button();
                        del_BtnTemp.Text = "X";
                        del_BtnTemp.Padding = new Padding(0);
                        del_BtnTemp.TextAlign = ContentAlignment.MiddleCenter;
                        del_BtnTemp.FlatStyle = FlatStyle.Flat;
                        del_BtnTemp.BackColor = Color.Red;
                        del_BtnTemp.ForeColor = Color.WhiteSmoke;
                        del_BtnTemp.Size = new System.Drawing.Size(15, 15);
                        del_BtnTemp.Click += del_BtnTempBlack_Click2;

                        pnTemp.BorderStyle = BorderStyle.FixedSingle;
                        pnTemp.Controls.Add(labelTemp);
                        pnTemp.Controls.Add(del_BtnTemp);

                        f_pnl_Item_Black.Controls.Add(pnTemp);

                        if (i == frm.list.Count - 1)
                        {
                            break;
                        }
                    }
                }
            }

            ResetChart_Only_flow();
            PrintChart_flow();
        }
        private void btn_flow_filter_WhiteList_Click(object sender, EventArgs e)
        {
            Popup.pop공정검색 frm = new Popup.pop공정검색();
            //frm.sUsedYN = sUsedYN;
            //frm.dt = dt;
            if (txt_Srch_White2.Text == null) txt_Srch_White2.Text = "";
            frm.txtSrch.Text = txt_Srch_White2.Text;
            frm.ShowDialog();

            if (frm.sRetCode != "")
            {
                if (f_pnl_Item_white.Controls[0].Tag == null)
                {
                    f_pnl_Item_white.Controls.Clear();
                    SetItemBlack_To_Default();
                    btn_Item_filter_BlackList.Enabled = false;
                    txt_Srch_Black2.Enabled = false;
                }

                if (f_pnl_Item_white.Controls.Count > 9) { MessageBox.Show("필터는 10개이상 등록할 수 없습니다"); return; }
                FlowLayoutPanel pnTemp = new FlowLayoutPanel();
                pnTemp.AutoSize = true;
                pnTemp.Padding = new Padding(0);
                pnTemp.Margin = new Padding(0);
                pnTemp.BackColor = Color.LemonChiffon;
                pnTemp.Tag = frm.sRetCode;

                Label labelTemp = new Label();
                labelTemp.Text = frm.sRetName;
                labelTemp.Tag = frm.sRetCode;
                labelTemp.AutoSize = true;
                labelTemp.TextAlign = ContentAlignment.MiddleCenter;
                labelTemp.Margin = new Padding(0, 5, 0, 0);

                Button del_BtnTemp = new Button();
                del_BtnTemp.Text = "X";
                del_BtnTemp.Padding = new Padding(0);
                del_BtnTemp.TextAlign = ContentAlignment.MiddleCenter;
                del_BtnTemp.FlatStyle = FlatStyle.Flat;
                del_BtnTemp.BackColor = Color.Red;
                del_BtnTemp.ForeColor = Color.WhiteSmoke;
                del_BtnTemp.Size = new System.Drawing.Size(15, 15);
                del_BtnTemp.Click += del_BtnTempWhite_Click2;

                pnTemp.BorderStyle = BorderStyle.FixedSingle;
                pnTemp.Controls.Add(labelTemp);
                pnTemp.Controls.Add(del_BtnTemp);

                f_pnl_Item_white.Controls.Add(pnTemp);


            }
            else
            {
                if (frm.list.Count > 0) /*선택된 셀이 1개 이상일 때 */
                {
                    if (f_pnl_Item_white.Controls[0].Tag == null)
                    {
                        f_pnl_Item_white.Controls.Clear();
                        SetItemBlack_To_Default();
                        btn_Item_filter_BlackList.Enabled = false;
                        txt_Srch_Black2.Enabled = false;
                    }

                    for (int i = 0; i < frm.list.Count; i++)
                    {
                        //dgv.Rows[nRow].Cells["Item_MAT_CD"].Value = frm.dgv.Rows[frm.list[i]].Cells["Item_MAT_CD"].Value;
                        if (f_pnl_Item_white.Controls.Count > 9) { MessageBox.Show("필터는 10개이상 등록할 수 없습니다"); break; }
                        FlowLayoutPanel pnTemp = new FlowLayoutPanel();
                        pnTemp.AutoSize = true;
                        pnTemp.Padding = new Padding(0);
                        pnTemp.Margin = new Padding(0);
                        pnTemp.BackColor = Color.LemonChiffon;
                        pnTemp.Tag = frm.GridRecord.Rows[frm.list[i]].Cells["FLOW_CD"].Value.ToString();

                        Label labelTemp = new Label();
                        labelTemp.Text = frm.GridRecord.Rows[frm.list[i]].Cells["FLOW_NM"].Value.ToString();
                        labelTemp.Tag = frm.GridRecord.Rows[frm.list[i]].Cells["FLOW_CD"].Value.ToString();
                        labelTemp.AutoSize = true;
                        labelTemp.TextAlign = ContentAlignment.MiddleCenter;
                        labelTemp.Margin = new Padding(0, 5, 0, 0);

                        Button del_BtnTemp = new Button();
                        del_BtnTemp.Text = "X";
                        del_BtnTemp.Padding = new Padding(0);
                        del_BtnTemp.TextAlign = ContentAlignment.MiddleCenter;
                        del_BtnTemp.FlatStyle = FlatStyle.Flat;
                        del_BtnTemp.BackColor = Color.Red;
                        del_BtnTemp.ForeColor = Color.WhiteSmoke;
                        del_BtnTemp.Size = new System.Drawing.Size(15, 15);
                        del_BtnTemp.Click += del_BtnTempWhite_Click2;

                        pnTemp.BorderStyle = BorderStyle.FixedSingle;
                        pnTemp.Controls.Add(labelTemp);
                        pnTemp.Controls.Add(del_BtnTemp);

                        f_pnl_Item_white.Controls.Add(pnTemp);

                        if (i == frm.list.Count - 1)
                        {
                            break;
                        }
                    }
                }
            }

            ResetChart_Only_flow();
            PrintChart_flow();
        }

        private void btn_flow_filter_BlackList_Click2(object sender, EventArgs e)
        {
            Popup.pop_sf_제품검색 frm = new Popup.pop_sf_제품검색();
            //frm.sUsedYN = sUsedYN;
            //frm.dt = dt;
            if (txt_Srch_Black3.Text == null) txt_Srch_Black3.Text = "";
            frm.txtSrch.Text = txt_Srch_Black3.Text;
            frm.ShowDialog();

            if (frm.sCode != "")
            {
                if (f_pnl_Item_Black2.Controls[0].Tag == null)
                {
                    f_pnl_Item_Black2.Controls.Clear();
                    SetItemWhite2_To_Default();
                    btn_Item_filter_WhiteList2.Enabled = false;
                    txt_Srch_White3.Enabled = false;
                }

                if (f_pnl_Item_Black2.Controls.Count > 9) { MessageBox.Show("필터는 10개이상 등록할 수 없습니다"); return; }
                FlowLayoutPanel pnTemp = new FlowLayoutPanel();
                pnTemp.AutoSize = true;
                pnTemp.Padding = new Padding(0);
                pnTemp.Margin = new Padding(0);
                pnTemp.BackColor = Color.LemonChiffon;
                pnTemp.Tag = frm.sCode;

                Label labelTemp = new Label();
                labelTemp.Text = frm.sName;
                labelTemp.Tag = frm.sCode;
                labelTemp.AutoSize = true;
                labelTemp.TextAlign = ContentAlignment.MiddleCenter;
                labelTemp.Margin = new Padding(0, 5, 0, 0);

                Button del_BtnTemp = new Button();
                del_BtnTemp.Text = "X";
                del_BtnTemp.Padding = new Padding(0);
                del_BtnTemp.TextAlign = ContentAlignment.MiddleCenter;
                del_BtnTemp.FlatStyle = FlatStyle.Flat;
                del_BtnTemp.BackColor = Color.Red;
                del_BtnTemp.ForeColor = Color.WhiteSmoke;
                del_BtnTemp.Size = new System.Drawing.Size(15, 15);
                del_BtnTemp.Click += del_BtnTempBlack_Click3;

                pnTemp.BorderStyle = BorderStyle.FixedSingle;
                pnTemp.Controls.Add(labelTemp);
                pnTemp.Controls.Add(del_BtnTemp);

                f_pnl_Item_Black2.Controls.Add(pnTemp);
            }
            else
            {
                if (frm.list.Count > 0) /*선택된 셀이 1개 이상일 때 */
                {
                    if (f_pnl_Item_Black2.Controls[0].Tag == null)
                    {
                        f_pnl_Item_Black2.Controls.Clear();
                        SetItemWhite2_To_Default();
                        btn_Item_filter_WhiteList2.Enabled = false;
                        txt_Srch_White3.Enabled = false;
                    }

                    for (int i = 0; i < frm.list.Count; i++)
                    {
                        //dgv.Rows[nRow].Cells["Item_MAT_CD"].Value = frm.dgv.Rows[frm.list[i]].Cells["Item_MAT_CD"].Value;
                        if (f_pnl_Item_Black2.Controls.Count > 9) { MessageBox.Show("필터는 10개이상 등록할 수 없습니다"); break; }
                        FlowLayoutPanel pnTemp = new FlowLayoutPanel();
                        pnTemp.AutoSize = true;
                        pnTemp.Padding = new Padding(0);
                        pnTemp.Margin = new Padding(0);
                        pnTemp.BackColor = Color.LemonChiffon;
                        pnTemp.Tag = frm.GridRecord.Rows[frm.list[i]].Cells["ITEM_CD"].Value.ToString();

                        Label labelTemp = new Label();
                        labelTemp.Text = frm.GridRecord.Rows[frm.list[i]].Cells["ITEM_NM"].Value.ToString();
                        labelTemp.Tag = frm.GridRecord.Rows[frm.list[i]].Cells["ITEM_CD"].Value.ToString();
                        labelTemp.AutoSize = true;
                        labelTemp.TextAlign = ContentAlignment.MiddleCenter;
                        labelTemp.Margin = new Padding(0, 5, 0, 0);

                        Button del_BtnTemp = new Button();
                        del_BtnTemp.Text = "X";
                        del_BtnTemp.Padding = new Padding(0);
                        del_BtnTemp.TextAlign = ContentAlignment.MiddleCenter;
                        del_BtnTemp.FlatStyle = FlatStyle.Flat;
                        del_BtnTemp.BackColor = Color.Red;
                        del_BtnTemp.ForeColor = Color.WhiteSmoke;
                        del_BtnTemp.Size = new System.Drawing.Size(15, 15);
                        del_BtnTemp.Click += del_BtnTempBlack_Click3;

                        pnTemp.BorderStyle = BorderStyle.FixedSingle;
                        pnTemp.Controls.Add(labelTemp);
                        pnTemp.Controls.Add(del_BtnTemp);

                        f_pnl_Item_Black2.Controls.Add(pnTemp);

                        if (i == frm.list.Count - 1)
                        {
                            break;
                        }
                    }
                }
            }

            ResetChart_Only_Item();
            PrintChart_Item();
        }
        private void btn_flow_filter_WhiteList_Click2(object sender, EventArgs e)
        {
            Popup.pop_sf_제품검색 frm = new Popup.pop_sf_제품검색();
            //frm.sUsedYN = sUsedYN;
            //frm.dt = dt;
            if (txt_Srch_White3.Text == null) txt_Srch_White3.Text = "";
            frm.txtSrch.Text = txt_Srch_White3.Text;
            frm.ShowDialog();

            if (frm.sCode != "")
            {
                if (f_pnl_Item_White2.Controls[0].Tag == null)
                {
                    f_pnl_Item_White2.Controls.Clear();
                    SetItemBlack2_To_Default();
                    btn_Item_filter_BlackList2.Enabled = false;
                    txt_Srch_Black3.Enabled = false;
                }

                if (f_pnl_Item_White2.Controls.Count > 9) { MessageBox.Show("필터는 10개이상 등록할 수 없습니다"); return; }
                FlowLayoutPanel pnTemp = new FlowLayoutPanel();
                pnTemp.AutoSize = true;
                pnTemp.Padding = new Padding(0);
                pnTemp.Margin = new Padding(0);
                pnTemp.BackColor = Color.LemonChiffon;
                pnTemp.Tag = frm.sCode;

                Label labelTemp = new Label();
                labelTemp.Text = frm.sName;
                labelTemp.Tag = frm.sCode;
                labelTemp.AutoSize = true;
                labelTemp.TextAlign = ContentAlignment.MiddleCenter;
                labelTemp.Margin = new Padding(0, 5, 0, 0);

                Button del_BtnTemp = new Button();
                del_BtnTemp.Text = "X";
                del_BtnTemp.Padding = new Padding(0);
                del_BtnTemp.TextAlign = ContentAlignment.MiddleCenter;
                del_BtnTemp.FlatStyle = FlatStyle.Flat;
                del_BtnTemp.BackColor = Color.Red;
                del_BtnTemp.ForeColor = Color.WhiteSmoke;
                del_BtnTemp.Size = new System.Drawing.Size(15, 15);
                del_BtnTemp.Click += del_BtnTempWhite_Click3;

                pnTemp.BorderStyle = BorderStyle.FixedSingle;
                pnTemp.Controls.Add(labelTemp);
                pnTemp.Controls.Add(del_BtnTemp);

                f_pnl_Item_White2.Controls.Add(pnTemp);


            }
            else
            {
                if (frm.list.Count > 0) /*선택된 셀이 1개 이상일 때 */
                {
                    if (f_pnl_Item_White2.Controls[0].Tag == null)
                    {
                        f_pnl_Item_White2.Controls.Clear();
                        SetItemBlack2_To_Default();
                        btn_Item_filter_BlackList2.Enabled = false;
                        txt_Srch_Black3.Enabled = false;
                    }

                    for (int i = 0; i < frm.list.Count; i++)
                    {
                        //dgv.Rows[nRow].Cells["Item_MAT_CD"].Value = frm.dgv.Rows[frm.list[i]].Cells["Item_MAT_CD"].Value;
                        if (f_pnl_Item_White2.Controls.Count > 9) { MessageBox.Show("필터는 10개이상 등록할 수 없습니다"); break; }
                        FlowLayoutPanel pnTemp = new FlowLayoutPanel();
                        pnTemp.AutoSize = true;
                        pnTemp.Padding = new Padding(0);
                        pnTemp.Margin = new Padding(0);
                        pnTemp.BackColor = Color.LemonChiffon;
                        pnTemp.Tag = frm.GridRecord.Rows[frm.list[i]].Cells["ITEM_CD"].Value.ToString();

                        Label labelTemp = new Label();
                        labelTemp.Text = frm.GridRecord.Rows[frm.list[i]].Cells["ITEM_NM"].Value.ToString();
                        labelTemp.Tag = frm.GridRecord.Rows[frm.list[i]].Cells["ITEM_CD"].Value.ToString();
                        labelTemp.AutoSize = true;
                        labelTemp.TextAlign = ContentAlignment.MiddleCenter;
                        labelTemp.Margin = new Padding(0, 5, 0, 0);

                        Button del_BtnTemp = new Button();
                        del_BtnTemp.Text = "X";
                        del_BtnTemp.Padding = new Padding(0);
                        del_BtnTemp.TextAlign = ContentAlignment.MiddleCenter;
                        del_BtnTemp.FlatStyle = FlatStyle.Flat;
                        del_BtnTemp.BackColor = Color.Red;
                        del_BtnTemp.ForeColor = Color.WhiteSmoke;
                        del_BtnTemp.Size = new System.Drawing.Size(15, 15);
                        del_BtnTemp.Click += del_BtnTempWhite_Click3;

                        pnTemp.BorderStyle = BorderStyle.FixedSingle;
                        pnTemp.Controls.Add(labelTemp);
                        pnTemp.Controls.Add(del_BtnTemp);

                        f_pnl_Item_White2.Controls.Add(pnTemp);

                        if (i == frm.list.Count - 1)
                        {
                            break;
                        }
                    }
                }
            }

            ResetChart_Only_Item();
            PrintChart_Item();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion Static Button Logic

        #region Dynamic Button Logic
        private void del_BtnTempWhite_Click(object sender, EventArgs e)
        {
            Button btnTemp = (Button)sender;
            btnTemp.Parent.Parent.Controls.Remove(btnTemp.Parent);
            if (f_pnl_Raw_white.Controls.Count == 0)
            {
                SetRawWhite_To_Default();
                btn_raw_filter_BlackList.Enabled = true;
                txt_Srch_Black.Enabled = true;
            }
            ResetChart_Only_Raw();
            PrintChart_Raw();
        }
        private void del_BtnTempBlack_Click(object sender, EventArgs e)
        {
            Button btnTemp = (Button)sender;
            btnTemp.Parent.Parent.Controls.Remove(btnTemp.Parent);
            if (f_pnl_Raw_Black.Controls.Count == 0)
            {
                SetRawBlack_To_Default();
                btn_raw_filter_WhiteList.Enabled = true;
                txt_Srch_White.Enabled = true;
            }
            ResetChart_Only_Raw();
            PrintChart_Raw();
        }
        private void del_BtnTempWhite_Click2(object sender, EventArgs e)
        {
            Button btnTemp = (Button)sender;
            btnTemp.Parent.Parent.Controls.Remove(btnTemp.Parent);
            if (f_pnl_Item_white.Controls.Count == 0)
            {
                SetItemWhite_To_Default();
                btn_Item_filter_BlackList.Enabled = true;
                txt_Srch_Black2.Enabled = true;
            }
            ResetChart_Only_flow();
            PrintChart_flow();
        }
        private void del_BtnTempBlack_Click2(object sender, EventArgs e)
        {
            Button btnTemp = (Button)sender;
            btnTemp.Parent.Parent.Controls.Remove(btnTemp.Parent);
            if (f_pnl_Item_Black.Controls.Count == 0)
            {
                SetItemBlack_To_Default();
                btn_Item_filter_WhiteList.Enabled = true;
                txt_Srch_White2.Enabled = true;
            }
            ResetChart_Only_flow();
            PrintChart_flow();
        }
        private void del_BtnTempWhite_Click3(object sender, EventArgs e)
        {
            Button btnTemp = (Button)sender;
            btnTemp.Parent.Parent.Controls.Remove(btnTemp.Parent);
            if (f_pnl_Item_White2.Controls.Count == 0)
            {
                SetItemWhite2_To_Default();
                btn_Item_filter_BlackList2.Enabled = true;
                txt_Srch_Black3.Enabled = true;
            }
            ResetChart_Only_Item();
            PrintChart_Item();
        }
        private void del_BtnTempBlack_Click3(object sender, EventArgs e)
        {
            Button btnTemp = (Button)sender;
            btnTemp.Parent.Parent.Controls.Remove(btnTemp.Parent);
            if (f_pnl_Item_Black2.Controls.Count == 0)
            {
                SetItemBlack2_To_Default();
                btn_Item_filter_WhiteList2.Enabled = true;
                txt_Srch_White3.Enabled = true;
            }
            ResetChart_Only_Item();
            PrintChart_Item();
        }
        #endregion Dynamic Button Logic

        private void chart_Click(object sender, EventArgs e)
        {
           

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

        private void chart_all_MouseClick(object sender, MouseEventArgs e)
        {
            System.Windows.Forms.DataVisualization.Charting.Chart chTemp = (System.Windows.Forms.DataVisualization.Charting.Chart)sender;
            System.Windows.Forms.DataVisualization.Charting.HitTestResult hit = chTemp.HitTest(e.X, e.Y);
            System.Windows.Forms.DataVisualization.Charting.Series s = null;
            if (hit != null) s = hit.Series;
            if (s != null)
            {
                SendToFront(chTemp, s);
            }
            else
            {
                if (pnl_all.Controls.IndexOf(chTemp) == -1)
                {
                    pnl_all.Controls.Add(chTemp);
                    chTemp.BringToFront();
                    Label_Show(chTemp);
                }
                else
                {
                    tb_all.Controls.Add(chTemp);
                    Label_Hide(chTemp);
                    //tb_all.Visible = true;
                }
            }
        }

        private void chart_detail_MouseClick(object sender, MouseEventArgs e)
        {
            System.Windows.Forms.DataVisualization.Charting.Chart chTemp = (System.Windows.Forms.DataVisualization.Charting.Chart)sender;
            System.Windows.Forms.DataVisualization.Charting.HitTestResult hit = chTemp.HitTest(e.X, e.Y);
            System.Windows.Forms.DataVisualization.Charting.Series s = null;
            if (hit != null) s = hit.Series;
            if (s != null)
            {
                SendToFront(chTemp, s);
            }
        }

        





        

        

       
    }
}
