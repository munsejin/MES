using MES.CLS;
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
    public partial class pop사원검색 : Form
    {
        public string str사원명 = "";
        public string str사원코드 = "";
        public string str부서명 = "";
        public string str직위명 = "";
        public string str아이디 = "";
        public string str권한 = "";
        
        public pop사원검색()
        {
            InitializeComponent();
        }

        private void pop사원검색_Load(object sender, EventArgs e)
        {
            user_list();
        }

        private void user_list()
        {
            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = null;
                dt = wDm.fn_Staff_List("");

                if (dt != null && dt.Rows.Count > 0)
                {
                    this.dataUserGrid.RowCount = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dataUserGrid.Rows[i].Cells[0].Value = dt.Rows[i]["STAFF_CD"].ToString();
                        dataUserGrid.Rows[i].Cells[1].Value = dt.Rows[i]["STAFF_NM"].ToString();
                        dataUserGrid.Rows[i].Cells[2].Value = dt.Rows[i]["DEPT_NM"].ToString();
                        dataUserGrid.Rows[i].Cells[3].Value = dt.Rows[i]["POS_NM"].ToString();
                        dataUserGrid.Rows[i].Cells[4].Value = dt.Rows[i]["COMMENT"].ToString();
                        if (dt.Rows[i]["AUTH_SET"].ToString() == "5")
                        {
                            dataUserGrid.Rows[i].Cells[5].Value = "관리자";
                        }
                        else
                        {
                            dataUserGrid.Rows[i].Cells[5].Value = "";


                        }
                        dataUserGrid.Rows[i].Cells["ID"].Value = dt.Rows[i]["LOGIN_ID"].ToString();


                    }
                }
                else
                {
                    dataUserGrid.Rows.Clear();
                }
            }
            catch (Exception e)
            {

            }
        }

        private void dataUserGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex>-1)
            {
                str사원코드 = dataUserGrid.Rows[e.RowIndex].Cells["dgvUser_cd"].Value.ToString();
                str사원명 = dataUserGrid.Rows[e.RowIndex].Cells["dgvUser_nm"].Value.ToString();
                str부서명 = dataUserGrid.Rows[e.RowIndex].Cells["dgvUser_dept"].Value.ToString();
                str직위명 = dataUserGrid.Rows[e.RowIndex].Cells["dgvUser_pos"].Value.ToString();
                str권한 = dataUserGrid.Rows[e.RowIndex].Cells["AUTH_SET"].Value.ToString();
                str아이디 = dataUserGrid.Rows[e.RowIndex].Cells["ID"].Value.ToString();
                this.Close();

                //txt_auth_set.Text = dataUserGrid.Rows[e.RowIndex].Cells["AUTH_SET"].Value.ToString();


                //Application.DoEvents();


                //txt_user_cd.Text = dataUserGrid.Rows[e.RowIndex].Cells["dgvUser_cd"].Value.ToString();
                //txt_user_nm.Text = dataUserGrid.Rows[e.RowIndex].Cells["ID"].Value.ToString();
                //txt_user.Text = dataUserGrid.Rows[e.RowIndex].Cells["dgvUser_nm"].Value.ToString();
                //txt_dept_nm.Text = dataUserGrid.Rows[e.RowIndex].Cells["dgvUser_dept"].Value.ToString();
                //txt_join_date.Text = dataUserGrid.Rows[e.RowIndex].Cells["dgvUser_pos"].Value.ToString();
            }
           
        }
    }
}
