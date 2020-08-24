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

namespace MES.H70_자동기록관리
{
    public partial class frm온습도기준등록 : Form
    {
        private bool bData = false;
        private int iCnt;
        private string strValue;

        private wnGConstant wConst = new wnGConstant();
        private wnAdo wAdo = new wnAdo();

        public frm온습도기준등록()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.btnSave.Enabled = false;
            if (this.bData ? this.updatePost() : this.insertPost())
            {
                this.btnSearch_Click((object)this, (EventArgs)null);
                this.btnNew_Click((object)this, (EventArgs)null);
            }
            this.btnSave.Enabled = true;
        }

        private bool updatePost()
        {
            if (!this.validate_InputBox())
                return false;
            bool flag = false;
            try
            {
                wnAdo wnAdo = new wnAdo();
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendLine(" UPDATE F_INTER_MST ");
                stringBuilder.AppendLine("SET M_CODE = @M_CODE");
                stringBuilder.AppendLine(", M_NAME = @M_NAME");
                stringBuilder.AppendLine(", STD_TEMP = @STD_TEMP");
                stringBuilder.AppendLine(", STD_HUM = @STD_HUM");
                stringBuilder.AppendLine(", ERROR_TEMP = @ERROR_TEMP");
                stringBuilder.AppendLine(", ERROR_HUM = @ERROR_HUM");
                stringBuilder.AppendLine(", MEMO = @MEMO");
                stringBuilder.AppendLine(", UPDATE_STAFF = @UPDATE_STAFF");
                stringBuilder.AppendLine(", UPDATE_DATE = getDate()");
                stringBuilder.AppendLine("  WHERE 1 = 1");
                stringBuilder.AppendLine("  AND M_CODE = @OLD_M_CODE");

                SqlCommand sCommand = new SqlCommand(stringBuilder.ToString());

                sCommand.Parameters.AddWithValue("@M_CODE",this.txtCode.Text);
                sCommand.Parameters.AddWithValue("@M_NAME",this.txtName.Text);
                sCommand.Parameters.AddWithValue("@STD_TEMP",this.txtStdTemp.Text);
                sCommand.Parameters.AddWithValue("@STD_HUM", this.txtStdHum.Text);
                sCommand.Parameters.AddWithValue("@ERROR_TEMP", this.txtErrTemp.Text);
                sCommand.Parameters.AddWithValue("@ERROR_HUM", this.txtErrHum.Text);
                sCommand.Parameters.AddWithValue("@MEMO", this.txtMemo.Text);
                sCommand.Parameters.AddWithValue("@UPDATE_STAFF", (object)Common.p_strStaffNo);
                sCommand.Parameters.AddWithValue("@OLD_M_CODE", this.txtOldCode.Text);

                flag = wnAdo.SqlCommandEtc(sCommand, "Save_F_INTER_MST_Table") > 0;
                if (!flag)
                {
                    int num = (int)MessageBox.Show("저장 중에 오류가 발생했습니다.");
                }
            }
            catch (Exception ex)
            {
                wnLog.writeLog(100, ex.Message + " - " + ex.ToString());
                int num = (int)MessageBox.Show("데이터베이스에 문제가 발생했습니다.");
            }
            return flag;
        }

        private void btnSearch_Click(object v, EventArgs eventArgs)
        {
            this.init_InputBox(true);
            this.bindData(this.makeSearchCondition());
        }

        private void bindData(string condition)
        {
            this.GridRecord.RowCount = 0;
            this.GridRecord.DataSource = (object)null;
            try
            {
                DataTable dataTable = this.fn_분류코드_List("F_INTER_MST", condition, Common.p_sConn); //new wnDm() >> this
                if (dataTable == null || dataTable.Rows.Count <= 0)
                    return;
                this.GridRecord.RowCount = dataTable.Rows.Count;
                for (int index = 0; index < dataTable.Rows.Count; ++index)
                {
                    this.GridRecord.Rows[index].Cells[0].Value = (object)dataTable.Rows[index]["M_CODE"].ToString();
                    this.GridRecord.Rows[index].Cells[1].Value = (object)dataTable.Rows[index]["M_NAME"].ToString();
                    this.GridRecord.Rows[index].Cells[2].Value = (object)dataTable.Rows[index]["STD_TEMP"].ToString();
                    this.GridRecord.Rows[index].Cells[3].Value = (object)dataTable.Rows[index]["STD_HUM"].ToString();
                    this.GridRecord.Rows[index].Cells[4].Value = (object)dataTable.Rows[index]["ERROR_TEMP"].ToString();
                    this.GridRecord.Rows[index].Cells[5].Value = (object)dataTable.Rows[index]["ERROR_HUM"].ToString();
                    this.GridRecord.Rows[index].Cells[6].Value = (object)dataTable.Rows[index]["MEMO"].ToString();
                }
            }
            catch (Exception ex)
            {
                wnLog.writeLog(100, ex.Message + " - " + ex.ToString());
            }
        }

        public DataTable fn_분류코드_List(string sTable, string condition, string sConn)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("select               ");
            stringBuilder.AppendLine("     a.*             ");
            stringBuilder.AppendLine(" from " + sTable + " a ");
            stringBuilder.AppendLine(" where 1 = 1");
            stringBuilder.AppendLine(" " + condition + "   ");
            stringBuilder.AppendLine(" order by a.M_CODE asc ");
            SqlCommand sCommand = new SqlCommand(stringBuilder.ToString());
            if (!sCommand.CommandText.Equals((string)null))
                return this.wAdo.SqlCommandSelect(sCommand);
            wnLog.writeLog(100, " There is no queryString");
            return (DataTable)null;
        }

        private string makeSearchCondition()
        {
            StringBuilder stringBuilder = new StringBuilder();
            switch (this.txt검색어.Text)
            {
                case "":
                    stringBuilder.Append("");
                    break;
                default:
                    stringBuilder.Append(" and (a.M_CODE like '%" + this.txt검색어.Text + "%' ");
                    stringBuilder.Append(" OR a.M_NAME like '%" + this.txt검색어.Text + "%' )");
                    break;
            }
            return stringBuilder.ToString();
        }

        private bool insertPost()
        {
            if (!this.validate_InputBox())
                return false;
            bool flag = false;
            try
            {
                wnAdo wnAdo = new wnAdo();
                if (this.get_Dup_Check(this.txtCode.Text, ""))
                {
                    int num = (int)MessageBox.Show("이미 존재하는 코드입니다. [ " + this.txtCode.Text + " ]");
                    return flag;
                }
                StringBuilder stringBuilder = new StringBuilder();
                //
                stringBuilder.AppendLine(" INSERT INTO F_INTER_MST (");
                stringBuilder.AppendLine("           M_CODE");
                stringBuilder.AppendLine("          , M_NAME");
                stringBuilder.AppendLine("          , STD_TEMP");
                stringBuilder.AppendLine("          , STD_HUM");
                stringBuilder.AppendLine("          , ERROR_TEMP");
                stringBuilder.AppendLine("          , ERROR_HUM");
                stringBuilder.AppendLine("          , MEMO");
                stringBuilder.AppendLine("          , INSERT_STAFF");
                stringBuilder.AppendLine("          , INSERT_DATE");
                stringBuilder.AppendLine(" ) VALUES ( ");
                stringBuilder.AppendLine("          @설비코드");
                stringBuilder.AppendLine("          , @설비명");
                stringBuilder.AppendLine("          , @기준온도");
                stringBuilder.AppendLine("          , @기준습도");
                stringBuilder.AppendLine("          , @온도허용오차");
                stringBuilder.AppendLine("          , @습도허용오차");
                stringBuilder.AppendLine("          , @비고");
                stringBuilder.AppendLine("          , @등록사원번호");
                stringBuilder.AppendLine("          , getdate())");
                SqlCommand sCommand = new SqlCommand(stringBuilder.ToString());
                sCommand.Parameters.AddWithValue("@설비코드", (object)this.txtCode.Text);
                sCommand.Parameters.AddWithValue("@설비명", (object)this.txtName.Text);
                
                sCommand.Parameters.AddWithValue("@기준온도", (object)this.txtStdTemp.Text);
                sCommand.Parameters.AddWithValue("@기준습도", (object)this.txtStdHum.Text);
                sCommand.Parameters.AddWithValue("@온도허용오차", (object)this.txtErrTemp.Text);
                sCommand.Parameters.AddWithValue("@습도허용오차", (object)this.txtErrHum.Text);
                sCommand.Parameters.AddWithValue("@비고", (object)this.txtMemo.Text);
                sCommand.Parameters.AddWithValue("@등록사원번호", (object)Common.p_strStaffNo);

                //           ,UPDATE_STAFF
                //           ,UPDATE_DATE)
                //      ,@수정사원번호 
                //      ,getdate())
              

                flag =wnAdo.SqlCommandEtc(sCommand, "Insert_F_INTER_MST_Table") > 0; 
                if (!flag)
                {
                    int num1 = (int)MessageBox.Show("저장 중에 오류가 발생했습니다.");
                }
            }
            catch (Exception ex)
            {
                wnLog.writeLog(100, ex.Message + " - " + ex.ToString());
                int num = (int)MessageBox.Show("데이터베이스에 문제가 발생했습니다.");
            }
            return flag;
        }


        private bool get_Dup_Check(string sNew, string sOld)
        {
            try
            {
                if (!(sNew != sOld))
                    return false;
                DataTable dataTable = this.fn_분류코드_Detail("F_INTER_MST", sNew, Common.p_sConn); //new wnDm() >> this 2020-03-04 이규빈 추후 배치 변경.
                return dataTable != null && dataTable.Rows.Count > 0;
            }
            catch (Exception ex)
            {
                wnLog.writeLog(100, ex.Message + " - " + ex.ToString());
                return true;
            }
        }

        public DataTable fn_분류코드_Detail(string sTable, string p1, string sConn)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("select               ");
            stringBuilder.AppendLine("     a.*             ");
            stringBuilder.AppendLine(" from " + sTable + " a ");
            stringBuilder.AppendLine(" where 1 = 1 ");
            stringBuilder.AppendLine("     and a.M_CODE= @p_1 ");
            SqlCommand sCommand = new SqlCommand(stringBuilder.ToString());
            if (sCommand.CommandText.Equals((string)null))
            {
                wnLog.writeLog(100, " There is no queryString");
                return (DataTable)null;
            }
            sCommand.Parameters.AddWithValue("@p_1", (object)p1);
            return this.wAdo.SqlCommandSelect(sCommand);
        }

        private bool validate_InputBox()
        {
            bool flag = true;
            try
            {
                if (this.txtCode.Text == "")
                {
                    int num = (int)MessageBox.Show("[ 설비코드 ] 을 입력하세요.");
                    return false;
                }
                if (this.txtName.Text == "")
                {
                    int num = (int)MessageBox.Show("[ 설비명 ] 을 입력하세요.");
                    return false;
                }
                if (this.txtStdTemp.Text == "")
                {
                    int num = (int)MessageBox.Show("[ 기준온도 ] 을 입력하세요.");
                    return false;
                }
                if (this.txtStdHum.Text == "")
                {
                    int num = (int)MessageBox.Show("[ 기준습도 ] 을 입력하세요.");
                    return false;
                }
                if (this.txtErrTemp.Text == "")
                {
                    int num = (int)MessageBox.Show("[ 온도 허용오차 ] 을 입력하세요.");
                    return false;
                }
                if (this.txtErrHum.Text == "")
                {
                    int num = (int)MessageBox.Show("[ 습도 허용오차] 을 입력하세요.");
                    return false;
                }

            }
            catch (Exception ex)
            {
                flag = false;
                wnLog.writeLog(100, ex.Message + " - " + ex.ToString());
                int num = (int)MessageBox.Show("입력 데이터 확인 중에 오류가 있습니다.");
            }
            return flag;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            this.init_InputBox(true);
            this.txt검색어.Text = "";
        }

        private void init_InputBox(bool bNew)
        {
            this.wConst.Form_Clear(this.splitContainer1.Panel1.Controls);
            //this.wConst.Form_Clear(this.splitContainer1.Panel2.Controls);

            if (bNew)
            {
                this.bData = false;
                this.btnDelete.Enabled = false;
            }
            else
            {
                this.bData = true;
                this.btnDelete.Enabled = true;
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (this.GridRecord.CurrentCell == null || this.GridRecord.CurrentCell.RowIndex < 0 || this.GridRecord.CurrentCell.ColumnIndex < 0)
                return;
            this.iCnt = this.GridRecord.CurrentCell.RowIndex;
            this.strValue = (string)this.GridRecord.Rows[this.iCnt].Cells[0].Value ?? "";
            this.getDetailPost(this.strValue);
        }

        private void getDetailPost(string sKey)
        {
            this.init_InputBox(false);
            try
            {
                DataTable dataTable = this.fn_분류코드_Detail("F_INTER_MST", sKey, Common.p_sConn); //new wnDm()
                if (dataTable == null || dataTable.Rows.Count <= 0)
                    return;
                this.txtCode.Text = dataTable.Rows[0]["M_CODE"].ToString();
                this.txtName.Text = dataTable.Rows[0]["M_NAME"].ToString();
                this.txtStdTemp.Text = dataTable.Rows[0]["STD_TEMP"].ToString();
                this.txtStdHum.Text = dataTable.Rows[0]["STD_HUM"].ToString();
                this.txtErrTemp.Text = dataTable.Rows[0]["ERROR_TEMP"].ToString();
                this.txtErrHum.Text = dataTable.Rows[0]["ERROR_HUM"].ToString();
                this.txtMemo.Text = dataTable.Rows[0]["MEMO"].ToString();
                this.txtOldCode.Text = this.txtCode.Text;
            }
            catch (Exception ex)
            {
                wnLog.writeLog(100, ex.Message + " - " + ex.ToString());
            }
        }

        private void frm온습도기준등록_Load(object sender, EventArgs e)
        {
            lbl_title.Tag = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[0] + "$" + wnDm.fn_TitleName(this.Name.ToString()).Split('$')[1]; lbl_title.Text = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[2];
            
            this.init_InputBox(true);
            this.bindData(this.makeSearchCondition());
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("자료를 삭제하시겠습니까?", "삭제여부", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel || !this.deletePost())
                return;
            this.init_InputBox(true);
            this.bindData(this.makeSearchCondition());
        }

        private bool deletePost()
        {
            bool flag = false;
            try
            {
                wnDm wnDm = new wnDm();
                wnAdo wnAdo = new wnAdo();
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendLine(" delete from F_INTER_MST");
                stringBuilder.AppendLine(" where 1 = 1");
                stringBuilder.AppendLine("     AND M_CODE = @M_CODE");
                stringBuilder.AppendLine("     AND M_NAME = @M_NAME");
                stringBuilder.AppendLine("     AND INSERT_STAFF = @INSERT_STAFF");

                SqlCommand sCommand = new SqlCommand(stringBuilder.ToString());
                sCommand.Parameters.AddWithValue("@M_CODE", (object)this.txtCode.Text);
                sCommand.Parameters.AddWithValue("@M_NAME", (object)this.txtName.Text);
                sCommand.Parameters.AddWithValue("@INSERT_STAFF", (object)Common.p_strStaffNo);

                flag = wnAdo.SqlCommandEtc(sCommand, "Delete_F_INTER_MST_Table") > 0;
                if (!flag)
                {
                    int num = (int)MessageBox.Show("삭제 중에 오류가 발생했습니다.");
                }
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show("데이터베이스에 문제가 발생했습니다.");
                wnLog.writeLog(100, ex.Message + " - " + ex.ToString());
            }
            return flag;
        }
    }
}
