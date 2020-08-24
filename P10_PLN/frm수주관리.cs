using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MES.P10_PLN
{
    public partial class frm수주관리 : Form
    {
        public frm수주관리()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm수주관리_Load(object sender, EventArgs e)
        {
           

        }

        private void btnCustSrch_Click(object sender, EventArgs e)
        {
            Popup.pop거래처검색 frm = new Popup.pop거래처검색();
    

            frm.sCustGbn = "1"; //매출처
            frm.sCustNm = txt_cust_nm.Text.ToString();
            frm.ShowDialog();

            //if (frm.sCode != "")
            //{
            //    txt_cust_cd.Text = frm.sCode.Trim();
            //    txt_cust_nm.Text = frm.sName.Trim();
            //    old_cust_nm = frm.sCode.Trim();
            //}
            //else
            //{
            //    txt_cust_cd.Text = old_cust_nm;
            //}

            frm.Dispose();
            frm = null;
        }
    }
}
