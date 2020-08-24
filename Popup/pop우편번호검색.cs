
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
    public partial class pop우편번호검색 : Form
    {
        public pop우편번호검색()
        {
            InitializeComponent();
        }

        public string a;
        public string b;

        string searchAddr;
        List<string> APIlist = new List<string>();
        wnDm wDm = new wnDm();

        private void frm우편번호검색_Load(object sender, EventArgs e)
        {
            cmb_addr_type.Text = "지번주소";
        }

        private void btn_frm_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            grdPostNo.Rows.Clear();
            grdPostNo.Refresh();
            searchAddr = txtSearch.Text.ToString();
            APIlist = wDm.postNoAPI(searchAddr);
            for (int i = 4; i < APIlist.Count; i += 3)
            {
                grdPostNo.Rows.Add(APIlist[i + 1] + Environment.NewLine + APIlist[i + 2], APIlist[i]);
            }
        }

        private void grdPostNo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            a = grdPostNo.Rows[e.RowIndex].Cells[0].Value.ToString();
            b = grdPostNo.Rows[e.RowIndex].Cells[1].Value.ToString();
            this.Close();
            //this.Visible = false;
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //to do
                btn_search.PerformClick();
            }

            else
            {
                return;
            } 
        }
    }
}
