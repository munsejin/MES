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

namespace MES.P40_ITM
{
    public partial class frmLOT추적분석 : Form
    {

        wnGConstant wConst = new wnGConstant();
        private Color ColorBlue = Color.FromArgb(67, 114, 196);
        private Color ColorOrange = Color.FromArgb(237, 125, 49);
        public frmLOT추적분석()
        {
            InitializeComponent();
        }

        private void frmLOT추적분석_Load(object sender, EventArgs e)
        {
            lbl_title.Tag = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[0] + "$" + wnDm.fn_TitleName(this.Name.ToString()).Split('$')[1]; lbl_title.Text = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[2];
        }

        
       
        
   

        #region PrintChartLogic
        
        private void PrintChart_flow()
        {
            wnDm wDm = new wnDm();
            DataTable dt = new DataTable();
            StringBuilder sb = new StringBuilder();
            
            //flow
            dt = wDm.fn_Select_flow_input_Poor_group_by_cd("  and A.LOT_NO = '"+txt_Srch_White2.Text+"' ");
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
            
            for (int i = 0; i < chart_flow.Series.Count; i++)
            {
                for (int j = 0; j < chart_flow.Series[i].Points.Count; j++)
                {
                    chart_flow.Series[i].Points[j].LabelToolTip = chart_flow.Series[i].Points[j].Label;
                }
            }

            SendToBack(chart_flow, chart_flow.Series[1]);


            dt = wDm.fn_Select_Flow_input_Detail_Poor(" and A.LOT_NO = '"+txt_Srch_White2.Text+"'  ", "");
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
        

        #endregion PrintChartLogic

        

        #region resettingChartLogic
        
        private void ResetChart_Only_flow()
        {
            chart_flow.Series.Clear();
            chart_flow.Series.Add("진행량");
            chart_flow.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart_flow.Series[0].Color = ColorBlue;
            chart_flow.Series[0].YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Primary;
            chart_flow.Series[0].BorderWidth = 3;
            chart_flow.BorderlineWidth = 1;
            chart_flow.Series.Add("불량건수");
            chart_flow.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            chart_flow.Series[1].Color = ColorOrange;
            //chart_item_detailil.Series[1].YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            chart_flow.Series[1].ToolTip = "불량건수";
            chart_flow.Series[0].ToolTip = "진행량";
            chart_flow.Series[0].LabelBorderColor = Color.FromArgb(64, 64, 64);
            chart_flow.Series[0].LabelBorderWidth = 1;
            chart_flow.Series[0].LabelBackColor = Color.WhiteSmoke;
            chart_flow.Series[1].LabelBorderColor = Color.FromArgb(64, 64, 64);
            chart_flow.Series[1].LabelBorderWidth = 0;
            chart_flow.Series[1].LabelBackColor = ColorOrange;
            chart_flow.Series[1].LabelForeColor = Color.WhiteSmoke;
        }
        

        #endregion resettingChartLogic


        

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

        private void btn_SrchLot_Click(object sender, EventArgs e)
        {
            ResetChart_Only_flow();
            PrintChart_flow();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_work_srch_Click(object sender, EventArgs e)
        {
            Popup.pop작업지시검색 frm = new Popup.pop작업지시검색(1);

            frm.ShowDialog();

            if (frm.sCode != "")
            {
                txt_Srch_White2.Text = frm.dgv.Rows[0].Cells["LOT_NO"].Value.ToString();
                btn_SrchLot.PerformClick();
            }

            frm.Dispose();
            frm = null;
        }



        

        

       
    }
}
