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

namespace MES.Popup
{
    public partial class pop오류리포트 : Form
    {
        private wnGConstant wConst = new wnGConstant();
        public string Error_log = "";
        bool userClose = false;

        private int nPageSize = int.Parse(Common.p_PageSize);
        public pop오류리포트()
        {
            InitializeComponent();
            userClose = true;
        }

        public pop오류리포트(string e)
        {
            InitializeComponent();
            Error_log = e;
        }

        private void pop오류리포트_Load(object sender, EventArgs e)
        {
            txt_intime.Text = DateTime.Now.ToString();
            txt_saup_nm.Text = Common.p_strCompNm;

            ComInfo comInfo = new ComInfo();
            string sqlQuery = "";
            //불량유형 시작
            cmb_error_gubun.ValueMember = "코드";
            cmb_error_gubun.DisplayMember = "명칭";
            sqlQuery = comInfo.queryErrorGubun();
            wConst.ComboBox_Read_NoBlank(cmb_error_gubun, sqlQuery);

            if (!Error_log.Equals(""))
            {
                cmb_error_gubun.SelectedValue = "ERROR";
                cmb_error_gubun.Enabled = false;
            }
        }

        private void btn_input_Click(object sender, EventArgs e)
        {
            userClose = true;
            try
            {
                string Error_gubun = cmb_error_gubun.SelectedValue.ToString();
                string Error_Report = txt_error_report.Text == null ? "" : txt_error_report.Text.ToString();

                wnDm wDm = new wnDm();
                if (Error_log.Length > 3500) Error_log = Error_log.Substring(0, 3500);
                int rsNum = wDm.fn_Error_Report(Error_gubun, Error_Report, Error_log);

                if (rsNum == 0)
                {
                    MessageBox.Show("성공적으로 전송하였습니다. 감사합니다.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("오류 발생");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("오류 발생");
                return;
            }
        }

        private void pop오류리포트_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!userClose)
            {
                userClose = true;
                try
                {
                    string Error_gubun = cmb_error_gubun.SelectedValue.ToString();
                    string Error_Report = txt_error_report.Text == null ? "" : txt_error_report.Text.ToString();

                    wnDm wDm = new wnDm();
                    if (Error_log.Length > 3500) Error_log = Error_log.Substring(0, 3500);
                    int rsNum = wDm.fn_Error_Report(Error_gubun, Error_Report, Error_log);

                    this.Close();
                    return;
                }
                catch (Exception ex)
                {
                    return;
                }
            }
        }



    }
}
