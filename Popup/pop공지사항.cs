using MES.CLS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MES.Popup
{
    public partial class pop공지사항 : Form
    {
        public DataTable dt = null;
        public pop공지사항(String intime )
        {
            InitializeComponent();
            this.intime = intime;
        }
        public pop공지사항()
        {
            InitializeComponent();
            dt = notice2(intime);
        }
        String intime;
        private void pop공지사항_Load(object sender, EventArgs e)
        {
            notice();
        }

        private void notice()
        {
            try
            {
                wnDm wDm = new wnDm();
                dt = notice2(intime);
                //sb.AppendLine("where A.ORDER_DATE >= '" + start_date.Text.ToString() + "' and  A.ORDER_DATE <= '" + end_date.Text.ToString() + "' ");
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        label1.Text = dt.Rows[i]["TITLE"].ToString();
                        richTextBox1.Text = dt.Rows[i]["CONTENT"].ToString();
                        label2.Text = dt.Rows[i]["STAFF_NM"].ToString();
                        label3.Text = dt.Rows[i]["intime"].ToString();
                        //textBox1.Text = noticeGrid.Rows[e.RowIndex].Cells["SEQ"].Value.ToString();
                    }
                }
            
            }
            catch (Exception ex)
            {
                MessageBox.Show("시스템 오류" + ex.ToString());
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                msg.ShowDialog();
            }
        }

        public DataTable notice2(String condition)
        {
            wnAdo wAdo = new wnAdo();

            StringBuilder sb = new StringBuilder();


            sb.AppendLine("select A.TITLE,A.CONTENT,A.INTIME,B.STAFF_NM from n_notice  as A  ");
            sb.AppendLine("inner join N_STAFF_CODE as B  on A.INSTAFF=B.STAFF_CD");

            sb.AppendLine("where INTIME like '%"+condition+"%' ");


            Debug.WriteLine(sb);
            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            return wAdo.SqlCommandSelect(sCommand);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
