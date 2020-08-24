using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using MES.CLS;

namespace MES.P85_BAS
{
    public partial class frm사용자관리 : Form
    {
        private wnGConstant wConst = new wnGConstant();
        private bool bEditText = false;
        private bool bData = false;
        private bool bData_sub = false;
        private int intTotalRecords = 0;
        private int intPageSize = 0;
        private int intPageCount = 0;
        private int intCurrentPage = 1;
        private int nPageSize = int.Parse(Common.p_PageSize);
        public static bool p_IsAuth = true;    // 열람권한
        public static bool p_Isrgstr = true;    //등록/수정 권한
        wnDm wnDm = new wnDm();
        public static bool p_Isdel = true;    // 삭제 권한
        private string join_cd = "1";  //입사,퇴사 구분


        public frm사용자관리()
        {
            InitializeComponent();
        }

        private void frm사용자관리_Load(object sender, EventArgs e)
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
            tabControl.TabPages.Remove(deptTab);
            tabControl.TabPages.Remove(posTab);
            tabControl.TabPages.Remove(storTab);

            btnDelete.Enabled = false;
            txt_user_cd.Enabled = true;
            init_ComboBox();
            user_list();
            //this.dtp거래개시일.Text = DateTime.Parse(dt.Rows[0]["REG_DATE"].ToString().Trim().Replace(" ", "")).ToString("yyyy-MM-dd");

            cmb_stor.SelectedIndex = -1;
            

        }

        private void init_ComboBox()
        {
            string sqlQuery = "";

            cmb_stor.ValueMember = "코드";
            cmb_stor.DisplayMember = "명칭";
            sqlQuery = " select STORAGE_CD as 코드, STORAGE_NM as 명칭 from N_STORAGE_CODE where 1=1";
            wConst.ComboBox_Read_NoBlank(cmb_stor, sqlQuery);

           
        }

        #region common logic

        private void btnNew_Click(object sender, EventArgs e)
        {
            btnDelete.Enabled = false;
            if (tabControl.SelectedIndex == 0)
            { //사용자 등록
                lbl_user_gbn.Text = "";
                txt_user_cd.Text = "";
                txt_user_cd.Enabled = true;
                txt_user_nm.Text = "";
                cmb_stor.SelectedIndex = -1;
                
                txt_phone.Text = "";
                txt_login.Text = "";
                txt_pw.Text = "";
                txt_user_cmt.Text = "";
            }
            else if (tabControl.SelectedIndex == 1) //부서 등록
            {
                lbl_dept_gbn.Text = "";
                txtDeptCd.Text = "";
                txtDeptCd.Enabled = true;
                txtDeptNm.Text = "";
                txtDeptCmt.Text = "";
            }
            else if (tabControl.SelectedIndex == 2) //직위 등록
            {
                lbl_pos_gbn.Text = "";
                txt_pos_cd.Text = "";
                txt_pos_cd.Enabled = true;
                txt_pos_nm.Text = "";
                txt_pos_cmt.Text = "";
            }
            else
            { //창고등록
                lbl_stor_gbn.Text = "";
                txt_stor_cd.Text = "";
                txt_stor_cd.Enabled = true;
                txt_stor_nm.Text = "";
                txt_stor_cmt.Text = "";
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (p_Isdel)
            {
                if (tabControl.SelectedIndex == 0)
                { //사용자 등록
                    user_del();
                }
                else if (tabControl.SelectedIndex == 1) //부서 등록
                {
                    dept_del();
                }
                else if (tabControl.SelectedIndex == 2) //직위 등록
                {
                    pos_del();
                }
                else
                { //창고등록
                    stor_del();
                }
            }
            else
            {
                MessageBox.Show("권한이 없습니다.");
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (p_Isrgstr)
            {


                if (tabControl.SelectedIndex == 0)
                { //사용자 등록
                    user_logic();
                }
                else if (tabControl.SelectedIndex == 1) //부서 등록
                {
                    dept_logic();
                }
                else if (tabControl.SelectedIndex == 2) //직위 등록
                {
                    pos_logic();
                }
                else
                { //창고등록
                    stor_logic();
                }
            }
            else
            {
                MessageBox.Show("권한이 없습니다.");
            }
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex == 0)
            {
                user_list();
            }
            else if (tabControl.SelectedIndex == 1)
            {
                dept_list();
            }
            else if (tabControl.SelectedIndex == 2)
            {
                pos_list();
            }
            else
            {
                stor_list();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion common logic

        #region user logic

        private void user_logic()
        {
            ////비밀번호 필수조건 특수문자1 알파벳1 숫자1 이상
            Regex rxPassword = new Regex(@"^(?=.*?[A-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{9,}$",
                           RegexOptions.IgnorePatternWhitespace);

            if (txt_user_cd.Text.ToString().Equals(""))
            {
                MessageBox.Show("사원코드를 입력하시기 바랍니다.");
                return;
            }
            if (txt_user_nm.Text.ToString().Equals(""))
            {
                MessageBox.Show("사원명을 입력하시기 바랍니다.");
                return;
            }
            txt_dept.Text = txt_dept.Text ?? "";
            txt_pos.Text = txt_pos.Text ?? "";

            if (Common.p_saupNo.Equals("2878800153"))
            {
                if (!rxPassword.IsMatch(txt_pw.Text))
                {
                    MessageBox.Show("비밀번호에는 하나 이상의 특수문자,알파벳,숫자가 포함되고 8자리 이상으로 입력하여주십시오.");
                    return;
                }
            }
            else
            {
                if (txt_pw.Text.Length < 4)
                {
                    MessageBox.Show("비밀번호는 4자리 이상으로 구성해주십시오.");
                    return;
                }
            }
            

            


            if((bool)btn_join.Checked)
            {
                join_cd = "1";
            }
            else if((bool)btn_resign.Checked)
            {
                join_cd = "2";
            }
            
            string stor = "";
            if (cmb_stor.SelectedValue == null) stor = ""; //cmb_stor.SelectedValue = "";
           

            if (lbl_user_gbn.Text != "1")
            {
                wnDm wDm = new wnDm();
                int rsNum = wDm.insertStaff(txt_user_cd.Text.ToString()
                    , txt_user_nm.Text.ToString()
                    , txt_dept.Text.ToString()
                    , txt_pos.Text.ToString()
                    , stor
                    , input_date.Text.ToString()
                    , txt_phone.Text.ToString()
                    , txt_login.Text.ToString()
                    , txt_pw.Text.ToString()
                    , join_cd
                    , txt_user_cmt.Text.ToString());

                if (rsNum == 0)
                {
                    txt_user_cd.Text = "";
                    txt_user_nm.Text = "";
                    cmb_stor.SelectedIndex = -1;
                    txt_pos.Text = "";
                    txt_dept.Text = "";
                    txt_phone.Text = "";
                    txt_login.Text = "";
                    txt_pw.Text = "";
                    txt_user_cmt.Text = "";

                    user_list();
                    MessageBox.Show("성공적으로 등록하였습니다.");
                }
                else if (rsNum == 1)
                    MessageBox.Show("저장에 실패하였습니다");
                else if (rsNum == 2)
                    MessageBox.Show("SQL COMMAND 에러");
                else if (rsNum == 3)
                    MessageBox.Show("기존 코드가 있으니 \n 다른 코드로 입력 바랍니다.");
                else if (rsNum == 4)
                    MessageBox.Show("기존 아이디가 있으니 \n 다른 아이디로 입력 바랍니다.");
                //else if (rsNum == 5)
                //    MessageBox.Show("기존 가 있으니 \n 다른 코드로 입력 바랍니다.");
                else
                    MessageBox.Show("Exception 에러1");
            }
            else
            {
                wnDm wDm = new wnDm();
                int rsNum = wDm.updateStaff(txt_user_cd.Text.ToString()
                    , txt_user_nm.Text.ToString()
                    , txt_dept.Text.ToString()
                    , txt_pos.Text.ToString()
                    , stor
                    , input_date.Text.ToString()
                    , txt_phone.Text.ToString()
                    , txt_login.Text.ToString()
                    , txt_pw.Text.ToString()
                    , txt_user_cmt.Text.ToString()
                    , join_cd);

                if (rsNum == 0)
                {
                    user_list();
                    MessageBox.Show("성공적으로 수정하였습니다.");
                }
                else if (rsNum == 1)
                    MessageBox.Show("저장에 실패하였습니다");
                else
                    MessageBox.Show("Exception 에러");
            }

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
                        dataUserGrid.Rows[i].Cells["ID"].Value = dt.Rows[i]["LOGIN_ID"].ToString();

                        if (dt.Rows[i]["AUTH_SET"].ToString()=="5")
                        {
                            dataUserGrid.Rows[i].Cells["관리자여부"].Value = "관리자";
                        }
                        
                    }
                }
                else
                {
                    dataUserGrid.Rows.Clear();
                }
            }
            catch (Exception e)
            {
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(e.Message + " - " + e.ToString());
                msg.ShowDialog();
            }
        }

        private void user_del()
        {
           
            if (MessageBox.Show("삭제하려는 계정으로 등록된 데이터들이 손상될 수 있습니다. 정말로 삭제하시겠습니까?", "YesOrNo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                wnDm wDm = new wnDm();
                int rsNum = wDm.deleteStaff(txt_user_cd.Text.ToString());
                if (rsNum == 0)
                {
                    lbl_user_gbn.Text = "";
                    btnDelete.Enabled = false;
                    txt_user_cd.Enabled = true;
                    txt_user_cd.Text = "";
                    txt_user_nm.Text = "";
                    txt_dept.Text = "";
                    txt_pos.Text = "";
                    cmb_stor.SelectedIndex = -1;
                    
                    txt_phone.Text = "";
                    txt_login.Text = "";
                    txt_pw.Text = "";

                    txt_user_cmt.Text = "";
                    user_list();
                    MessageBox.Show("성공적으로 삭제하였습니다.");
                }
                else if (rsNum == 1)
                    MessageBox.Show("삭제에 실패하였습니다");
                else
                    MessageBox.Show("Exception 에러");
            }
            else
            {
            }

          
        }

        private void dataUserGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            btnDelete.Enabled = true;
            lbl_user_gbn.Text = "1";
            txt_user_cd.Enabled = false;

            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = null;
                string condition = "where staff_cd = '" + dataUserGrid.Rows[e.RowIndex].Cells[0].Value.ToString() + "'";
                dt = wDm.fn_Staff_List(condition);

                if (dt != null && dt.Rows.Count > 0)
                {

                    txt_user_cd.Text = dt.Rows[0]["STAFF_CD"].ToString();
                    txt_user_nm.Text = dt.Rows[0]["STAFF_NM"].ToString();
                    txt_dept.Text = dt.Rows[0]["DEPT_CD"].ToString();
                    txt_pos.Text = dt.Rows[0]["POS_CD"].ToString();
                    cmb_stor.SelectedValue = dt.Rows[0]["STORAGE_CD"].ToString();
                    txt_phone.Text = dt.Rows[0]["PHONE_NUM"].ToString();
                    txt_login.Text = dt.Rows[0]["LOGIN_ID"].ToString();
                    txt_pw.Text = dt.Rows[0]["PW"].ToString();
                    
                    txt_user_cmt.Text = dt.Rows[0]["COMMENT"].ToString();
                }
                else
                {
                    //MessageBox.Show("존재하지 않는 자료입니다.");
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void txt_user_cd_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComInfo.onlyNum(sender, e);
        }

        #endregion user logic

        #region dept logic

        private void dept_logic()
        {
            if (txtDeptCd.Text.ToString().Equals(""))
            {
                MessageBox.Show("부서코드를 입력하시기 바랍니다.");
                return;
            }
            if (txtDeptNm.Text.ToString().Equals(""))
            {
                MessageBox.Show("부서명을 입력하시기 바랍니다.");
                return;
            }
            if (lbl_dept_gbn.Text != "1")
            {
                wnDm wDm = new wnDm();
                int rsNum = wDm.insertDept(txtDeptCd.Text.ToString(), txtDeptNm.Text.ToString(), txtDeptCmt.Text.ToString());

                if (rsNum == 0)
                {
                    txtDeptCd.Text = "";
                    txtDeptNm.Text = "";
                    txtDeptCmt.Text = "";

                    dept_list();
                    MessageBox.Show("성공적으로 등록하였습니다.");
                }
                else if (rsNum == 1)
                    MessageBox.Show("저장에 실패하였습니다");
                else if (rsNum == 2)
                    MessageBox.Show("SQL COMMAND 에러");
                else if (rsNum == 3)
                    MessageBox.Show("기존 코드가 있으니 \n 다른 코드로 입력 바랍니다.");
                else
                    MessageBox.Show("Exception 에러1");
            }
            else
            {
                wnDm wDm = new wnDm();
                int rsNum = wDm.updateDept(txtDeptCd.Text.ToString(), txtDeptNm.Text.ToString(), txtDeptCmt.Text.ToString());
                if (rsNum == 0)
                {
                    dept_list();
                    MessageBox.Show("성공적으로 수정하였습니다.");
                }
                else if (rsNum == 1)
                    MessageBox.Show("저장에 실패하였습니다");
                else
                    MessageBox.Show("Exception 에러");
            }

        }

        private void dept_del()
        {
            wnDm wDm = new wnDm();
            int rsNum = wDm.deleteDept(txtDeptCd.Text.ToString());
            if (rsNum == 0)
            {
                btnDelete.Enabled = false;
                txtDeptCd.Enabled = true;
                txtDeptCd.Text = "";
                txtDeptNm.Text = "";
                txtDeptCmt.Text = "";
                lbl_dept_gbn.Text = "";

                dept_list();
                MessageBox.Show("성공적으로 삭제하였습니다.");
            }
            else if (rsNum == 1)
                MessageBox.Show("삭제에 실패하였습니다");
            else
                MessageBox.Show("Exception 에러");
        }
        private void dept_list()
        {
            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = null;
                dt = wDm.fn_Dept_List();

                if (dt != null && dt.Rows.Count > 0)
                {
                    this.dataDeptGrid.RowCount = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dataDeptGrid.Rows[i].Cells[0].Value = dt.Rows[i]["DEPT_CD"].ToString();
                        dataDeptGrid.Rows[i].Cells[1].Value = dt.Rows[i]["DEPT_NM"].ToString();
                        dataDeptGrid.Rows[i].Cells[2].Value = dt.Rows[i]["COMMENT"].ToString();
                    }
                }
                else
                {
                    dataDeptGrid.Rows.Clear();
                }
            }
            catch (Exception e)
            {
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(e.Message + " - " + e.ToString());
                msg.ShowDialog();
            }
        }

        private void dataDeptGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnDelete.Enabled = true;
            lbl_dept_gbn.Text = "1";
            txtDeptCd.Enabled = false;
            txtDeptCd.Text = dataDeptGrid.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtDeptNm.Text = dataDeptGrid.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtDeptCmt.Text = dataDeptGrid.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void txtDeptCd_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComInfo.onlyNum(sender, e);
        }

        #endregion dept logic

        #region pos logic
        private void pos_logic()
        {
            if (txt_pos_cd.Text.ToString().Equals(""))
            {
                MessageBox.Show("직위코드를 입력하시기 바랍니다.");
                return;
            }
            if (txt_pos_nm.Text.ToString().Equals(""))
            {
                MessageBox.Show("직위명을 입력하시기 바랍니다.");
                return;
            }

            if (lbl_pos_gbn.Text != "1")
            {
                wnDm wDm = new wnDm();
                int rsNum = wDm.insertPos(txt_pos_cd.Text.ToString(), txt_pos_nm.Text.ToString(), txt_pos_cmt.Text.ToString());

                if (rsNum == 0)
                {
                    txt_pos_cd.Text = "";
                    txt_pos_nm.Text = "";
                    txt_pos_cmt.Text = "";

                    pos_list();
                    MessageBox.Show("성공적으로 등록하였습니다.");
                }
                else if (rsNum == 1)
                    MessageBox.Show("저장에 실패하였습니다");
                else if (rsNum == 2)
                    MessageBox.Show("SQL COMMAND 에러");
                else if (rsNum == 3)
                    MessageBox.Show("기존 코드가 있으니 \n 다른 코드로 입력 바랍니다.");
                else
                    MessageBox.Show("Exception 에러1");
            }
            else
            {
                wnDm wDm = new wnDm();
                int rsNum = wDm.updatePos(txt_pos_cd.Text.ToString(), txt_pos_nm.Text.ToString(), txt_pos_cmt.Text.ToString());
                if (rsNum == 0)
                {
                    pos_list();
                    MessageBox.Show("성공적으로 수정하였습니다.");
                }
                else if (rsNum == 1)
                    MessageBox.Show("저장에 실패하였습니다");
                else
                    MessageBox.Show("Exception 에러2");
            }
        }
        private void pos_del()
        {
            wnDm wDm = new wnDm();
            int rsNum = wDm.deletePos(txt_pos_cd.Text.ToString());
            if (rsNum == 0)
            {
                lbl_pos_gbn.Text = "";
                txt_pos_cd.Enabled = true;
                txt_pos_cd.Text = "";
                txt_pos_nm.Text = "";
                txt_pos_cmt.Text = "";
                btnDelete.Enabled = false;
                pos_list();
                MessageBox.Show("성공적으로 삭제하였습니다.");
            }
            else if (rsNum == 1)
                MessageBox.Show("삭제에 실패하였습니다");
            else
                MessageBox.Show("Exception 에러");
        }
        private void pos_list()
        {
            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = null;
                dt = wDm.fn_Pos_List();

                if (dt != null && dt.Rows.Count > 0)
                {
                    this.dataPosGrid.RowCount = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dataPosGrid.Rows[i].Cells[0].Value = dt.Rows[i]["POS_CD"].ToString();
                        dataPosGrid.Rows[i].Cells[1].Value = dt.Rows[i]["POS_NM"].ToString();
                        dataPosGrid.Rows[i].Cells[2].Value = dt.Rows[i]["COMMENT"].ToString();
                    }
                }
                else
                {
                    dataPosGrid.Rows.Clear();
                }
            }
            catch (Exception e)
            {
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(e.Message + " - " + e.ToString());
                msg.ShowDialog();
            }
        }
        private void dataPosGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnDelete.Enabled = true;
            lbl_pos_gbn.Text = "1";
            txt_pos_cd.Enabled = false;
            txt_pos_cd.Text = dataPosGrid.Rows[e.RowIndex].Cells[0].Value.ToString();
            txt_pos_nm.Text = dataPosGrid.Rows[e.RowIndex].Cells[1].Value.ToString();
            txt_pos_cmt.Text = dataPosGrid.Rows[e.RowIndex].Cells[2].Value.ToString();
        }
        private void txt_pos_cd_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComInfo.onlyNum(sender, e);
        }
        #endregion pos logic

        #region storage logic
        private void stor_logic()
        {
            if (txt_stor_cd.Text.ToString().Equals(""))
            {
                MessageBox.Show("창고코드를 입력하시기 바랍니다.");
                return;
            }
            if (txt_stor_nm.Text.ToString().Equals(""))
            {
                MessageBox.Show("창고명을 입력하시기 바랍니다.");
                return;
            }

            if (lbl_stor_gbn.Text != "1")
            {
                wnDm wDm = new wnDm();
                int rsNum = wDm.insertStor(txt_stor_cd.Text.ToString(), txt_stor_nm.Text.ToString(), txt_stor_cmt.Text.ToString());

                if (rsNum == 0)
                {
                    txt_stor_cd.Text = "";
                    txt_stor_nm.Text = "";
                    txt_stor_cmt.Text = "";

                    stor_list();
                    MessageBox.Show("성공적으로 등록하였습니다.");
                }
                else if (rsNum == 1)
                    MessageBox.Show("저장에 실패하였습니다");
                else if (rsNum == 2)
                    MessageBox.Show("SQL COMMAND 에러");
                else if (rsNum == 3)
                    MessageBox.Show("기존 코드가 있으니 \n 다른 코드로 입력 바랍니다.");
                else
                    MessageBox.Show("Exception 에러1");
            }
            else
            {
                wnDm wDm = new wnDm();
                int rsNum = wDm.updateStor(txt_stor_cd.Text.ToString(), txt_stor_nm.Text.ToString(), txt_stor_cmt.Text.ToString());
                if (rsNum == 0)
                {
                    stor_list();
                    MessageBox.Show("성공적으로 수정하였습니다.");
                }
                else if (rsNum == 1)
                    MessageBox.Show("저장에 실패하였습니다");
                else
                    MessageBox.Show("Exception 에러");
            }
        }

        private void stor_del()
        {
            wnDm wDm = new wnDm();
            int rsNum = wDm.deleteStor(txt_stor_cd.Text.ToString());
            if (rsNum == 0)
            {
                lbl_stor_gbn.Text = "";
                txt_stor_cd.Enabled = true;
                txt_stor_cd.Text = "";
                txt_stor_nm.Text = "";
                txt_stor_cmt.Text = "";
                btnDelete.Enabled = true;
                stor_list();
                MessageBox.Show("성공적으로 삭제하였습니다.");
            }
            else if (rsNum == 1)
                MessageBox.Show("삭제에 실패하였습니다");
            else
                MessageBox.Show("Exception 에러");
        }
        private void stor_list()
        {
            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = null;
                dt = wDm.fn_Stor_List();

                if (dt != null && dt.Rows.Count > 0)
                {
                    this.dataStorGrid.RowCount = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dataStorGrid.Rows[i].Cells[0].Value = dt.Rows[i]["STORAGE_CD"].ToString();
                        dataStorGrid.Rows[i].Cells[1].Value = dt.Rows[i]["STORAGE_NM"].ToString();
                        dataStorGrid.Rows[i].Cells[2].Value = dt.Rows[i]["COMMENT"].ToString();
                    }
                }
                else
                {
                    dataStorGrid.Rows.Clear();
                }
            }
            catch (Exception e)
            {
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(e.Message + " - " + e.ToString());
                msg.ShowDialog();
            }
        }


        private void conTextBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComInfo.onlyNum(sender, e);
        }

        private void dataStorGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnDelete.Enabled = true;
            lbl_stor_gbn.Text = "1";
            txt_stor_cd.Enabled = false;
            txt_stor_cd.Text = dataStorGrid.Rows[e.RowIndex].Cells[0].Value.ToString();
            txt_stor_nm.Text = dataStorGrid.Rows[e.RowIndex].Cells[1].Value.ToString();
            txt_stor_cmt.Text = dataStorGrid.Rows[e.RowIndex].Cells[2].Value.ToString();
        }
        #endregion storage logic

        private void tabControl_TabIndexChanged(object sender, EventArgs e)
        {

        }

        private void txt_user_cmt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                btnSave.Focus();
            }

            else
            {
                return;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            Keys key = keyData & ~(Keys.Shift | Keys.Control);
            switch (key)
            {
                case Keys.W:
                    // 조합키 사용 시
                    if ((keyData & Keys.Control) != 0)
                    {
                        this.Close();
                    }
                    else return base.ProcessCmdKey(ref msg, keyData);
                    break;
                case Keys.S:
                    // 조합키 사용 시
                    if ((keyData & Keys.Control) != 0)
                    {
                        btnSave.PerformClick();
                    }
                    else return base.ProcessCmdKey(ref msg, keyData);
                    break;
                case Keys.F5:
                    btnNew.PerformClick();
                    // 단일키 사용시
                    break;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
            return true;
        }

    }
}
