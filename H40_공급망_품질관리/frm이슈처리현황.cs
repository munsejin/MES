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

namespace MES.H40_공급망_품질관리
{
    public partial class frm이슈처리현황 : Form
    {
        public frm이슈처리현황()
        {
            InitializeComponent();
        }
        wnDm wnDm = new wnDm();
        private wnGConstant wConst = new wnGConstant();
        public static bool p_IsAuth = true;    // 열람권한
        public static bool p_Isrgstr = true;    //등록/수정 권한

        public static bool p_Isdel = true;    // 삭제 권한

        public string str이슈일자 = "";
        public string str이슈번호 = "";
        public string str이슈완료 = "";
        private void frm이슈처리현황_Load(object sender, EventArgs e)
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


            bind이슈등록("and c.ISSUE_COMPLETE_MEMO is null");
        }

        private void bind이슈등록(string condition)
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
                        dgv이슈.Rows[i].Cells["ISSUE_MEMO"].Value = dt.Rows[i]["ISSUE_MEMO"].ToString();
                       // dgv이슈.Rows[i].Cells["COMMENT"].Value = dt.Rows[i]["COMMENT"].ToString();
                        dgv이슈.Rows[i].Cells["REQ_DATE"].Value = dt.Rows[i]["REQ_DATE"].ToString();
                        dgv이슈.Rows[i].Cells["TEL_NO"].Value = dt.Rows[i]["TEL_NO"].ToString();
                        dgv이슈.Rows[i].Cells["O_ORD_DATE"].Value = dt.Rows[i]["ORD_DATE"].ToString();
                        dgv이슈.Rows[i].Cells["O_ORD_NUM"].Value = dt.Rows[i]["ORD_NUM"].ToString();
                        dgv이슈.Rows[i].Cells["ISSUE_NM"].Value = dt.Rows[i]["ISSUE_NM"].ToString();
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

        private void dgv이슈_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ComInfo.grdHeaderNoAction(e))
            {
                splitContainer2.Visible = true;
                txt이슈내역.Text = "";
                txt이슈처리내역.ReadOnly = false;
                txt이슈내역.Text = dgv이슈.Rows[e.RowIndex].Cells["ISSUE_MEMO"].Value.ToString();
                str이슈일자 = dgv이슈.Rows[e.RowIndex].Cells["ISSUE_DATE"].Value.ToString();
                str이슈번호 = dgv이슈.Rows[e.RowIndex].Cells["ISSUE_NUM"].Value.ToString();
                str이슈완료 = dgv이슈.Rows[e.RowIndex].Cells["ISSUE_CD"].Value.ToString();
                txt이슈처리내역.BackColor = SystemColors.Control;
            }
        }

        private void btn처리내용_Click(object sender, EventArgs e)
        {
            txt이슈처리내역.ReadOnly = false;
            txt이슈처리내역.BackColor = Color.White;
            label1.Visible = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (p_Isrgstr)
            {
                S_이슈등록();

            }
            else
            {
                MessageBox.Show("권한이 없습니다.");
            } 
        }

        private void S_이슈등록()
        {
             int rsNum=wnDm.update_이슈등록(str이슈완료, txt이슈내역.Text, str이슈일자, str이슈번호
                );
             if (rsNum == 0)
             {

                 MessageBox.Show("성공적으로 등록하였습니다.");
             }
             else if (rsNum == 1)
                 MessageBox.Show("저장에 실패하였습니다");
             else if (rsNum == 2)
                 MessageBox.Show("SQL COMMAND 에러");
             else if (rsNum == 3)
                 MessageBox.Show("기존 코드가 존재하므로 \n 다른 코드로 입력 바랍니다.");
             else
                 MessageBox.Show("Exception 에러");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
    }
}
