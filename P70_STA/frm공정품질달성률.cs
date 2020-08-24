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

namespace MES.P70_STA
{
    public partial class frm공정품질달성률 : Form
    {
        private wnGConstant wConst = new wnGConstant();

        public frm공정품질달성률()
        {
            InitializeComponent();
        }

        private void frm공정품질달성률_Load(object sender, EventArgs e)
        {
               lbl_title.Tag = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[0] + "$" + wnDm.fn_TitleName(this.Name.ToString()).Split('$')[1]; lbl_title.Text = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[2];
            
            init_ComboBox();
        }
        private void btnSrch_Click(object sender, EventArgs e)
        {
        }

        private void init_ComboBox()
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
