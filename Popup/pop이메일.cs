using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MES.Popup
{
    public partial class pop이메일 : Form
    {
        public pop이메일()
        {
            InitializeComponent();
        }

        private void pop이메일_Load(object sender, EventArgs e)
        {
            txt_ID.Text = Common.p_emailID;
            txt_PW.Text = Common.p_emailPW;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Common.p_emailID = txt_ID.Text;
            Common.p_emailPW = txt_PW.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
