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
using MES.CLS;

namespace MES.Popup
{
    public partial class pop수입검사결과 : Form
    {
        private Point mCurrentPosition = new Point(0, 0); //

        public string s_ChkDate = "";
        public string s_pass_amt = "";
        public string s_non_pass_amt = "";
        public string pass_yn = "";

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
                mCurrentPosition = new Point(-e.X, -e.Y);

        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(
                    this.Location.X + (mCurrentPosition.X + e.X),
                    this.Location.Y + (mCurrentPosition.Y + e.Y));// 마우스의 이동치를 Form Location에 반영한다.
            }
        }
      
        public pop수입검사결과()
        {
            InitializeComponent();
        }

        private void pop수입검사결과_Load(object sender, EventArgs e)
        {

            chk_date.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        private void btn_Y_Click(object sender, EventArgs e)
        {
            returnValue("Y");   
        }

        private void btn_N_Click(object sender, EventArgs e)
        {
            returnValue("N");
        }

        private void returnValue(string yn)
        {
            try
            {
                decimal pAmt = decimal.Parse(pass_amt.Text.ToString().Replace(",",""));
                decimal npAmt = decimal.Parse(non_pass_amt.Text.ToString().Replace(",",""));
                decimal proAmt = decimal.Parse(chk_amt.Text.ToString().Replace(",", ""));

                if (proAmt != pAmt + npAmt)
                {
                    MessageBox.Show("통과수량과 불합격수량의 합은 검사 수량과 같아야합니다. ");
                    return;
                }

                s_ChkDate = chk_date.Text;
                s_pass_amt = pAmt.ToString("#,0.######");
                s_non_pass_amt = npAmt.ToString("#,0.######");
                pass_yn = yn;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("수량 입력 양식이 잘못되었습니다.");
                return;
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
