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
    public partial class frm생산목표달성률 : Form
    {
        private wnGConstant wConst = new wnGConstant();

        public frm생산목표달성률()
        {
            InitializeComponent();
        }

        private void frm생산목표달성률_Load(object sender, EventArgs e)
        {
               lbl_title.Tag = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[0] + "$" + wnDm.fn_TitleName(this.Name.ToString()).Split('$')[1]; lbl_title.Text = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[2];
            
            init_ComboBox();
        }

        private void btnSrch_Click(object sender, EventArgs e)
        {
            pic01.Visible = true;
        }

        private void init_ComboBox()
        {
            string sqlQuery = "";
            cmb_year.ValueMember = "코드";
            cmb_year.DisplayMember = "명칭";
            sqlQuery = "select '1' as 코드, DATEPART(YYYY,dateadd(year,0,getdate())) as 명칭";
            //sqlQuery += " union all ";
            //sqlQuery += "select DATEPART(YYYY,dateadd(year,-1,getdate())) as s_year";

            wConst.ComboBox_Read_NoBlank(cmb_year, sqlQuery);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
