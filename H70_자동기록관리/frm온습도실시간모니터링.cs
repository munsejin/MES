using MES.CLS;
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
using System.Windows.Forms.DataVisualization.Charting;

namespace MES.H70_자동기록관리
{
    public partial class frm온습도실시간모니터링 : Form
    {
        private string NowDateTime;

        public frm온습도실시간모니터링()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void tmRefresh_Tick(object sender, EventArgs e)
        {
            //갱신주기 80초 
            // 그래프 갱신 및 datagridview 갱신.
            this.tmRefresh.Enabled = false;
            this.frm온습도실시간모니터링_Load(this, null);
            this.tmRefresh.Enabled = true;

        }

        private wnGConstant wConst = new wnGConstant();
        private wnAdo wAdo = new wnAdo();

        private void frm온습도실시간모니터링_Load(object sender, EventArgs e)
        {

            lbl_title.Tag = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[0] + "$" + wnDm.fn_TitleName(this.Name.ToString()).Split('$')[1]; lbl_title.Text = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[2];
            
            this.NowDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            this.lblDateTime.Text = NowDateTime + " 기준";
            this.lblDateTime2.Text = NowDateTime;
            
            this.wConst.setCombo_공용코드(this.cbo설비코드, "F_INTER_MST", "ALL");
            bindData();

        }

        private void bindData()
        {
            this.bindChart();
            this.bindData1();
            this.bindData2("");
        }

        private void bindData2(string Mcode)
        {
            this.GridRecord2.RowCount = 0;
            this.GridRecord2.DataSource = (object)null;
            try
            {
                DataTable dataTable = this.fn_설비의온습도_List(Mcode); //new wnDm() >> this
             
                if (dataTable == null || dataTable.Rows.Count <= 0)
                {
                    this.GridRecord2.Rows.Clear();
                    return;
                }
                this.GridRecord2.RowCount = dataTable.Rows.Count;
                for (int index = 0; index < dataTable.Rows.Count; ++index)
                {
                    this.GridRecord2.Rows[index].Cells[0].Value = index + 1;
                    this.GridRecord2.Rows[index].Cells[1].Value = (object)dataTable.Rows[index]["TEMP_VALUE"].ToString();
                    this.GridRecord2.Rows[index].Cells[2].Value = (object)dataTable.Rows[index]["HUM_VALUE"].ToString();
                    this.GridRecord2.Rows[index].Cells[3].Value = (object)dataTable.Rows[index]["INTER_TIME"].ToString();
                }
            }
            catch (Exception ex)
            {
                wnLog.writeLog(100, ex.Message + " - " + ex.ToString());
            }

        }
                                                                                                                                                                                                                                                                                                    
        private DataTable fn_설비의온습도_List(string MCode)
        {
            StringBuilder stringBuilder = new StringBuilder();


            stringBuilder.AppendLine("select* from F_INTER");
            stringBuilder.AppendLine("WHERE M_CODE = @시설코드");
            stringBuilder.AppendLine("AND INTER_TIME >= convert(VARCHAR(8), GETDATE(), 112)");

            SqlCommand sCommand = new SqlCommand(stringBuilder.ToString());
            sCommand.Parameters.AddWithValue("@시설코드", MCode);

            if (!sCommand.CommandText.Equals((string)null))
                return this.wAdo.SqlCommandSelect(sCommand);
            wnLog.writeLog(100, " There is no queryString");
            return (DataTable)null;
        }

        private void bindData1()
        {
            this.GridRecord1.RowCount = 0;
            this.GridRecord1.DataSource = (object)null;
            try
            {
                DataTable dataTable = this.fn_설비별온습도_List(); //new wnDm() >> this
                if (dataTable == null || dataTable.Rows.Count <= 0)
                    return;
                this.GridRecord1.RowCount = dataTable.Rows.Count;
                for (int index = 0; index < dataTable.Rows.Count; ++index)
                {
                    this.GridRecord1.Rows[index].Cells[0].Value = index + 1;
                    this.GridRecord1.Rows[index].Cells[1].Value = (object)dataTable.Rows[index]["M_CODE"].ToString();
                    this.GridRecord1.Rows[index].Cells[2].Value = (object)dataTable.Rows[index]["M_NAME"].ToString();
                    this.GridRecord1.Rows[index].Cells[3].Value = (object)dataTable.Rows[index]["TEMP_VALUE"].ToString();
                    this.GridRecord1.Rows[index].Cells[4].Value = (object)dataTable.Rows[index]["HUM_VALUE"].ToString();
                    this.GridRecord1.Rows[index].Cells[5].Value = (object)dataTable.Rows[index]["INTER_TIME"].ToString();

                }
            }
            catch (Exception ex)
            {
                wnLog.writeLog(100, ex.Message + " - " + ex.ToString());
            }
        }

        private void bindChart()
        {
            this.Chart1.Series.Clear();
            this.Chart1.DataSource = (object)null;

            this.Chart1.Series.Add("온도");
            this.Chart1.Series.Add("습도");
            this.Chart1.Series["온도"].IsValueShownAsLabel = true;
            this.Chart1.Series["습도"].IsValueShownAsLabel = true;
            this.Chart1.Series["온도"].LegendText = "온도 °C";
            this.Chart1.Series["습도"].LegendText = "습도 %";

            try
            {
                DataTable dataTable = this.fn_설비별온습도_List(); //new wnDm() >> this
                if (dataTable == null || dataTable.Rows.Count <= 0)
                    return;
                
                for (int index = 0; index < dataTable.Rows.Count; ++index)
                {
                    this.Chart1.Series["온도"].Points.AddXY((object)dataTable.Rows[index]["M_NAME"].ToString(), decimal.Parse(dataTable.Rows[index]["TEMP_VALUE"].ToString()));
                    this.Chart1.Series["습도"].Points.AddXY((object)dataTable.Rows[index]["M_NAME"].ToString(), decimal.Parse(dataTable.Rows[index]["HUM_VALUE"].ToString()));
                }
            }
            catch (Exception ex)
            {
                wnLog.writeLog(100, ex.Message + " - " + ex.ToString());
            }
        }


        public DataTable fn_설비별온습도_List()
        {
            StringBuilder stringBuilder = new StringBuilder();
            
            stringBuilder.AppendLine("SELECT*");
            stringBuilder.AppendLine("FROM");
            stringBuilder.AppendLine("(SELECT");
            stringBuilder.AppendLine("A.M_CODE,");
            stringBuilder.AppendLine("B.M_NAME,");
            stringBuilder.AppendLine("A.TEMP_VALUE,");
            stringBuilder.AppendLine("A.HUM_VALUE,");
            stringBuilder.AppendLine("LEFT(CONVERT(NVARCHAR,A.INTIME,120),16) AS INTER_TIME, ");
            stringBuilder.AppendLine("ROW_NUMBER()");
            stringBuilder.AppendLine("OVER(PARTITION BY A.M_CODE ORDER BY CONVERT(NVARCHAR,A.INTIME,120) DESC) AS RANKNO FROM F_INTER A LEFT OUTER JOIN F_INTER_MST B ON A.M_CODE = B.M_CODE) T");
            stringBuilder.AppendLine("WHERE RankNo = 1");
            stringBuilder.AppendLine("ORDER BY M_CODE");

            SqlCommand sCommand = new SqlCommand(stringBuilder.ToString());
            if (!sCommand.CommandText.Equals((string)null))
                return this.wAdo.SqlCommandSelect(sCommand);
            wnLog.writeLog(100, " There is no queryString");
            return (DataTable)null;
        }

        private void GridRecord1_DoubleClick(object sender, EventArgs e)
        {
            int rowIndex = this.GridRecord1.CurrentCell.RowIndex;
            string str_Mcode = (string)this.GridRecord1.Rows[rowIndex].Cells[1].Value ?? "";
            this.lbl오늘기계.Text = "Today " + (string)this.GridRecord1.Rows[rowIndex].Cells[2].Value + " 온-습도 History";

            bindData2(str_Mcode);
            
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.NowDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            this.lblDateTime.Text = NowDateTime + " 기준";
            this.lblDateTime2.Text = NowDateTime;
            
            this.btnRefresh.Enabled = false;
            this.bindData();
            this.btnRefresh.Enabled = true;
        }
    }
}
