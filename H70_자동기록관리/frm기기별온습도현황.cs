using MES.CLS;
using MES.Controls;
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

namespace MES.H70_자동기록관리
{
    public partial class frm기기별온습도현황 : Form
    {
        private wnAdo wAdo = new wnAdo();
        private wnGConstant wConst = new wnGConstant();

        public frm기기별온습도현황()
        {
            InitializeComponent();
        }

        private void frm기기별온습도현황_Load(object sender, EventArgs e)
        {
            lbl_title.Tag = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[0] + "$" + wnDm.fn_TitleName(this.Name.ToString()).Split('$')[1]; lbl_title.Text = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[2];
            
            this.wConst.setCombo_공용코드(this.cbo설비명, "F_INTER_MST", "ALL");
            this.bindData(this.makeSearchCondition());

        }



        private string makeSearchCondition()
        {
            StringBuilder stringBuilder = new StringBuilder();

            if (!(this.cbo설비명.SelectedValue == ""))
            {
                stringBuilder.Append(" and A.M_CODE = '" + this.cbo설비명.SelectedValue + "' ");
            }
            stringBuilder.Append(" and CONVERT(NVARCHAR,A.INTIME,120) like '%" + this.dtpInputTime.Value.ToString("yyyy-MM-dd") + "%' ");
            return stringBuilder.ToString();
        }

        private void bindData(string condition)
        {
            this.GridRecord.RowCount = 0;
            this.GridRecord.DataSource = (object)null;
            try
            {
                DataTable dataTable = this.fn_분류코드_List("F_INTER", condition, Common.p_sConn); //new wnDm() >> this
                if (dataTable == null || dataTable.Rows.Count <= 0)
                    return;
                this.GridRecord.RowCount = dataTable.Rows.Count;
                for (int index = 0; index < dataTable.Rows.Count; ++index)
                {
                    this.GridRecord.Rows[index].Cells[0].Value = (object)dataTable.Rows[index]["INTER_CD"].ToString();
                    this.GridRecord.Rows[index].Cells[1].Value = (object)dataTable.Rows[index]["INTER_TIME"].ToString();
                    this.GridRecord.Rows[index].Cells[2].Value = (object)dataTable.Rows[index]["TEMP_VALUE"].ToString();
                    this.GridRecord.Rows[index].Cells[3].Value = (object)dataTable.Rows[index]["HUM_VALUE"].ToString();
                    this.GridRecord.Rows[index].Cells[4].Value = (object)dataTable.Rows[index]["M_CODE"].ToString();
                    this.GridRecord.Rows[index].Cells[5].Value = (object)dataTable.Rows[index]["M_NAME"].ToString();
                }
            }
            catch (Exception ex)
            {
                wnLog.writeLog(100, ex.Message + " - " + ex.ToString());
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        public DataTable fn_분류코드_List(string sTable, string condition, string sConn)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(" SELECT A.INTER_DATE ");
            stringBuilder.AppendLine("      , A.INTER_CD ");
            stringBuilder.AppendLine("      , CONVERT(NVARCHAR,A.INTIME,120) AS INTER_TIME ");
            stringBuilder.AppendLine("      , A.M_CODE ");
            stringBuilder.AppendLine("      , A.TEMP_VALUE ");
            stringBuilder.AppendLine("      , A.HUM_VALUE ");
            stringBuilder.AppendLine("      , B.M_NAME ");
            stringBuilder.AppendLine("FROM F_INTER A");
            stringBuilder.AppendLine("      INNER JOIN F_INTER_MST B ON B.M_CODE = A.M_CODE ");
            stringBuilder.AppendLine(" where 1 = 1");
            stringBuilder.AppendLine(" " + condition + "   ");
            stringBuilder.AppendLine(" order by A.INTER_CD DESC, CONVERT(NVARCHAR,A.INTIME,120) DESC ");

            SqlCommand sCommand = new SqlCommand(stringBuilder.ToString());
            if (!sCommand.CommandText.Equals((string)null))
                return this.wAdo.SqlCommandSelect(sCommand);
            wnLog.writeLog(100, " There is no queryString");
            return (DataTable)null;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.bindData(makeSearchCondition());
        }
    }
}
