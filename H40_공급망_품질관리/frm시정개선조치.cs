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
using MES.CLS;

namespace MES.H40_공급망_품질관리
{
    public partial class frm시정개선조치 : Form
    {
        wnDm wnDm = new wnDm();
        public static bool p_IsAuth = true;    // 열람권한
        public static bool p_Isrgstr = true;    //등록/수정 권한
        public static bool p_Isdel = true;    // 삭제 권한

        public frm시정개선조치()
        {
            InitializeComponent();
        }

        private void frm시정개선조치_Load(object sender, EventArgs e)
        {
            lbl_title.Tag = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[0] + "$" + wnDm.fn_TitleName(this.Name.ToString()).Split('$')[1]; lbl_title.Text = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[2];
            if (Common.p_strUserAdmin != "5")
            {
                DataTable dtcheck = wnDm.fn_auth_check(lbl_title.Tag.ToString().Split('$')[0], lbl_title.Tag.ToString().Split('$')[1]);
                p_IsAuth = dtcheck.Rows[0]["auth_yn"].ToString() == "Y" ? true : false;
                p_Isrgstr = dtcheck.Rows[0]["rgstr_yn"].ToString() == "Y" ? true : false;
                p_Isdel = dtcheck.Rows[0]["del_yn"].ToString() == "Y" ? true : false;
                try
                {
                    if (!p_IsAuth)
                    {
                        this.BeginInvoke(new MethodInvoker(Close));
                        /// MessageBox.Show("권한이없습니다.");
                    }

                }
                catch (Exception ex)
                {
                }
            }

            bind시정개선조치("and c.ISSUE_COMPLETE_MEMO is not null");
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// bin시정개선조치() - S_이슈등록 바인딩함 
        /// </summary>
        private void bind시정개선조치(string condition)
        {

            dgv이슈.Rows.Clear();
            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = null;
                dt = wDm.fn_이슈등록리스트(condition);

                if (dt != null && dt.Rows.Count > 0)
                {
                    dgv이슈.RowCount = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgv이슈.Rows[i].Cells["ISSUE_DATE"].Value = dt.Rows[i]["ISSUE_DATE"].ToString();
                        dgv이슈.Rows[i].Cells["ISSUE_NUM"].Value = dt.Rows[i]["ISSUE_NUM"].ToString();
                        dgv이슈.Rows[i].Cells["CUST_CD"].Value = dt.Rows[i]["CUST_CD"].ToString();
                        dgv이슈.Rows[i].Cells["CUST_NM"].Value = dt.Rows[i]["CUST_NM"].ToString();
                        //  dgv이슈.Rows[i].Cells["STAFF_CD"].Value = dt.Rows[i]["STAFF_CD"].ToString();
                        //  dgv이슈.Rows[i].Cells["STAFF_NM"].Value = dt.Rows[i]["STAFF_NM"].ToString();
                        dgv이슈.Rows[i].Cells["ISSUE_STAFF_CD"].Value = dt.Rows[i]["ISSUE_STAFF_CD"].ToString();
                        dgv이슈.Rows[i].Cells["ISSUE_STAFF_NM"].Value = dt.Rows[i]["ISSUE_STAFF_NM"].ToString();
                        dgv이슈.Rows[i].Cells["ISSUE_CD"].Value = dt.Rows[i]["ISSUE_CD"].ToString();
                        dgv이슈.Rows[i].Cells["ISSUE_MEMO"].Value = dt.Rows[i]["ISSUE_COMPLETE_MEMO"].ToString();
                        // dgv이슈.Rows[i].Cells["COMMENT"].Value = dt.Rows[i]["COMMENT"].ToString();
                        dgv이슈.Rows[i].Cells["STATE_DATE"].Value = dt.Rows[i]["STATE_DATE"].ToString();
                        dgv이슈.Rows[i].Cells["TEL_NO"].Value = dt.Rows[i]["TEL_NO"].ToString();
                        dgv이슈.Rows[i].Cells["O_ORD_DATE"].Value = dt.Rows[i]["ORD_DATE"].ToString();
                        dgv이슈.Rows[i].Cells["O_ORD_NUM"].Value = dt.Rows[i]["ORD_NUM"].ToString();
                        dgv이슈.Rows[i].Cells["ISSUE_NM"].Value = dt.Rows[i]["ISSUE_NM"].ToString()+"완료";
                        //dgv.Rows[i].Cells[4].Value = dt.Rows[i]["COMPLETE_YN"].ToString();
                    }
                }
                else
                {
                    dgv이슈.Rows.Clear();
                }
            }
            catch (Exception e)
            {
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(e.Message+" - "+e.ToString()); msg.ShowDialog();
            }

        }
        /// <summary>
        /// 
        ///  더블클릭시 밑에 이슈처리내용이 나온다 .
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv이슈_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            panel3.Visible = true;
            txt이슈처리내역.Text = dgv이슈.Rows[e.RowIndex].Cells["ISSUE_MEMO"].Value.ToString();
        }
    }
}
