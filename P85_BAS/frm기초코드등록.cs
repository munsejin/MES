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
using MES.Controls;
using MES.Popup;


namespace MES.P85_BAS
{
    public partial class frm기초코드등록 : Form
    {
        private wnGConstant wConst = new wnGConstant();
        public static bool p_IsAuth = true;    // 열람권한
        public static bool p_Isrgstr = true;    //등록/수정 권한
        wnDm wnDm = new wnDm();
        public static bool p_Isdel = true;    // 삭제 권한
        public frm기초코드등록()
        {
            InitializeComponent();
         
        }

        private void dgv설비EndEdit3(object sender, DataGridViewCellEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void frm공정코드등록_Load(object sender, EventArgs e)
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


            //tabControl.TabPages.Remove(lineTab);
            //tabControl.TabPages.Remove(chkTab);

            btnDelete.Enabled = false;
            init_ComboBox();           
            //type_list();
            line_list();
            unit_list();
            chk_list();
            
            cbo검사종류.SelectedIndex = -1;
        }

        #region common logic

        private void init_ComboBox()
        {
            ComInfo comInfo = new ComInfo();
            string sqlQuery = "";
           

            //담당자 
            cmb_manager.ValueMember = "코드";
            cmb_manager.DisplayMember = "명칭";
            sqlQuery = comInfo.queryStaff();
            wConst.ComboBox_Read_Blank(cmb_manager, sqlQuery);

            //창고 
            cmb_stor.ValueMember = "코드";
            cmb_stor.DisplayMember = "명칭";
            sqlQuery = comInfo.queryStorage();
            wConst.ComboBox_Read_Blank(cmb_stor, sqlQuery);

            //검사 
            cbo검사종류.ValueMember = "S_CODE";
            cbo검사종류.DisplayMember = "S_CODE_NM";           
            sqlQuery = "SELECT  [S_CODE],[S_CODE_NM] FROM [SM_FACTORY_COM].[dbo].[T_S_CODE] where L_CODE='600'";
            wConst.ComboBox_Read_NoBlank(cbo검사종류, sqlQuery);



            /*
            cmb_type_gb.ValueMember = "S_CODE";
            cmb_type_gb.DisplayMember = "S_CODE_NM";
            sqlQuery = "SELECT  [S_CODE],[S_CODE_NM] FROM T_S_CODE where L_CODE='201'";
            wConst.ComboBox_Read_NoBlank(cmb_type_gb, sqlQuery);
            
             
             */

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            //btnDelete.Enabled = false;
            btnDelete.Enabled = false;
        
            if (tabControl.SelectedTab.Name == "unitTab") //단위 등록
            {
                lbl_unit_gbn.Text = "";
                txt_unit_cd.Text = "";
                txt_unit_cd.Enabled = true;
                txt_unit_nm.Text = "";
                txt_unit_cmt.Text = "";
            }
            else if (tabControl.SelectedTab.Name == "lineTab") //라인 등록
            {
                lbl_line_gbn.Text = "";
                txt_line_cd.Text = "";
                txt_line_cd.Enabled = true;
                txt_line_nm.Text = "";
                txt_line_cmt.Text = "";
                pnl설비.Visible = false;
            }

            else if (tabControl.SelectedTab.Name == "chkTab")
            {
                txt_ChkCode.Text = "";
                txt_ChkCode.Enabled = true;
                txtODR.Text = "";

                txt_chkMemo.Text = "";
                txtChkNM.Text = "";
                lbl_chkGB.Text = "";
                cbo검사종류.SelectedIndex = -1;
            }


            else if (tabControl.SelectedTab.Name == "rawTab")//원자재 등록
            {
                lbl_gbn.Text = "0";
                txt_rawType_cd.Text = "";
                txt_rawType_cd.ReadOnly = false;
                txt_rawType_nm.Text = "";
                txt_rawType_cmt.Text = "";
               
            }
            else if (tabControl.SelectedTab.Name == "itemTab")//제품 등록
            {
                lbl_gbn.Text = "0";
                txt_itemType_cd.Text = "";
                txt_itemType_cd.ReadOnly = false;
                txt_itemType_nm.Text = "";
                txt_itemType_cmt.Text = "";
                
            }
            else if (tabControl.SelectedTab.Name == "custTab")//거래처 등록
            {
                lbl_gbn.Text = "0";
                txt_custType_cd.Text = "";
                txt_custType_cd.ReadOnly = false;
                txt_custType_nm.Text = "";
                txt_custType_cmt.Text = "";
                
            }
            else if (tabControl.SelectedTab.Name == "storageTab")//창고
            {
                lbl_gbn.Text = "";
                txt_stor_cd.Text = "";
                txt_stor_cd.Enabled = true;
                txt_stor_nm.Text = "";
                txt_stor_cmt.Text = "";
            }
            //else if (tabControl.SelectedIndex ==8) //부서 등록
            //{
            //    lbl_gbn.Text = "";
            //    txtDeptCd.Text = "";
            //    txtDeptCd.Enabled = true;
            //    txtDeptNm.Text = "";
            //    txtDeptCmt.Text = "";
            //}
            //else if (tabControl.SelectedIndex ==9) //직위 등록
            //{
            //    lbl_gbn.Text = "";
            //    txt_pos_cd.Text = "";
            //    txt_pos_cd.Enabled = true;
            //    txt_pos_nm.Text = "";
            //    txt_pos_cmt.Text = "";
            //}
            else if (tabControl.SelectedTab.Name == "locationTab") 
            { //보관위치
                lbl_gbn.Text = "0";
                cmb_stor.SelectedIndex = -1;
                txt_loc_cd.Text = "";
                txt_loc_cd.ReadOnly = false;
                txt_loc_nm.Text = "";
                txt_loc_cmt.Text = "";
            }

            else if (tabControl.SelectedTab.Name == "AccountTab")
            { //계정리셋
                lbl_gbn.Text = "";
                txt_accu_cd.Text = "";
                txt_accu_cd.Enabled = true;
                txt_accu_nm.Text = "";

            }
            else if (tabControl.SelectedTab.Name == "tabS_Loc")
            { //계정리셋
                lbl_gbn.Text = "";
                txt_s_loc_cd.Text = "(자동발급)";
                txt_s_loc_nm.Text = "";
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (p_Isdel)
            {
            
                if (tabControl.SelectedTab.Name == "unitTab") //단위 삭제
                {
                    unit_del();
                }
                else if (tabControl.SelectedTab.Name == "lineTab") //라인 삭제
                {
                    line_del();
                }
               
                else if (tabControl.SelectedTab.Name == "chkTab")
                {
                    chk_del();
                }
                else if (tabControl.SelectedTab.Name == "rawTab")
                {
                    unitType_del("2",txt_rawType_cd,txt_rawType_nm,txt_rawType_cmt,dgv_raw);
                }
                else if (tabControl.SelectedTab.Name == "itemTab")
                {
                    unitType_del("3",  txt_itemType_cd, txt_itemType_nm, txt_itemType_cmt,dgv_item);
                }
                else if (tabControl.SelectedTab.Name == "custTab")
                {
                    unitType_del("4",  txt_custType_cd, txt_custType_nm, txt_custType_cmt,dgv_cust);
                }
                else if (tabControl.SelectedTab.Name == "storageTab")
                {
                    stor_del();
                }
                //else if (tabControl.SelectedTab.Name == "tabS_Loc")
                //{
                //    pos_del();
                //}
                else if (tabControl.SelectedTab.Name == "locationTab")
                {
                    loc_del();
                }
                else if (tabControl.SelectedTab.Name == "AccountTab")
                {
                    accu_del();
                }
                else if (tabControl.SelectedTab.Name == "tabS_Loc")
                {
                    SLoc_del();
                }
                else
                {
                }
            }
            else
            {
                MessageBox.Show("권한이 없습니다.");
            }
        }

        private void SLoc_del()
        {
            wnDm wDm = new wnDm();
            int rsNum = wDm.del_sLoc(txt_s_loc_cd.Text);
            if (rsNum == 0)
            {
                lbl_gbn.Text = "";
                txt_s_loc_cd.Text = "(자동발급)";
                txt_accu_nm.Text = "";
                btnDelete.Enabled = false;
                btnNew.PerformClick();


                sLoc_list();

                MessageBox.Show("성공적으로 삭제하였습니다.");
            }
            else if (rsNum == 1)
            {
                MessageBox.Show("삭제에 실패하였습니다.");
            }
        }

        private void sLoc_list()
        {
            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = null;
                dt = wDm.fn_sLoc_List();

                dgv_sLoc.Rows.Clear();
                if (dt != null && dt.Rows.Count > 0)
                {
                    this.dgv_sLoc.RowCount = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgv_sLoc.Rows[i].Cells["S_LOC_CD"].Value = dt.Rows[i]["S_LOC_CD"].ToString();
                        dgv_sLoc.Rows[i].Cells["S_LOC_NM"].Value = dt.Rows[i]["S_LOC_NM"].ToString();
                    }
                }
                else
                {
                    dgv_sLoc.Rows.Clear();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("설비위치 리스트 출력 시 오류 발생");
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(e.Message + " - " + e.ToString());
                msg.ShowDialog();
            } 
        }

        private void accu_del()
        {
            wnDm wDm = new wnDm();
            int rsNum = wDm.del_accu(txt_accu_cd.Text);
            if (rsNum == 0)
            {
                lbl_gbn.Text = "";
                txt_accu_cd.Text = "";
                txt_accu_cd.Enabled = true;
                txt_accu_nm.Text = "";
                btnDelete.Enabled = false;

                accu_list();

                MessageBox.Show("성공적으로 삭제하였습니다.");
            }
            else if (rsNum == 1)
            {
                MessageBox.Show("삭제에 실패하였습니다.");
            }
        }

        private void unitType_del(string L_CODE, conTextBox txt_unitType_cd, conTextBox txt_unitType_nm, conTextBox txt_unitType_cmt, DataGridView dgv)
        {
            wnDm wDm = new wnDm();
            int rsNum = wDm.deleteUnitType(L_CODE, txt_unitType_cd.Text);
            if (rsNum == 0)
            {
                lbl_gbn.Text = "0";
                txt_unitType_cd.Enabled = true;
                txt_unitType_cd.Text= "";
                txt_unitType_nm.Text = "";
                txt_unitType_cmt.Text = "";
                btnDelete.Enabled = false;

                unitTypeList(dgv,L_CODE);
                MessageBox.Show("성공적으로 삭제하였습니다.");
            }
            else if (rsNum == 1)
            {
                MessageBox.Show("삭제에 실패하였습니다.");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (p_Isrgstr)
            {
                if (tabControl.SelectedTab.Name == "unitTab") //단위 등록
                {
                    unit_logic();
                }
                else if (tabControl.SelectedTab.Name == "lineTab") //라인 등록
                {
                    line_logic();
                }
                else if (tabControl.SelectedTab.Name == "chkTab") //검사기준 등록
                {
                    chk_logic();
                }
                else if (tabControl.SelectedTab.Name == "rawTab") //원자재유형등록
                {
                    unitType_logic("2",txt_rawType_cd.Text,txt_rawType_nm.Text,txt_rawType_cmt.Text,dgv_raw);
                }
                else if (tabControl.SelectedTab.Name == "itemTab") //제품유형등록
                {
                    unitType_logic("3", txt_itemType_cd.Text, txt_itemType_nm.Text, txt_itemType_cmt.Text,dgv_item);
                }
                else if (tabControl.SelectedTab.Name == "custTab") //거래처유형등록
                {
                    unitType_logic("4", txt_custType_cd.Text, txt_custType_nm.Text, txt_custType_cmt.Text,dgv_cust);
                }
                else if (tabControl.SelectedTab.Name == "storageTab") //저장장소
                {
                    stor_logic();
                }
                else if (tabControl.SelectedTab.Name == "locationTab") //창고
                { 
                    loc_logic();
                }
                else if (tabControl.SelectedTab.Name == "AccountTab") //계정
                {
                    accu_logic();
                }
                else if (tabControl.SelectedTab.Name == "tabS_Loc") //계정
                {
                    sLoc_logic();
                }
            }
            else
            {

                MessageBox.Show("권한이 없습니다.");
            }
        }

        private void sLoc_logic()
        {
            if (txt_s_loc_nm.Text == null || txt_s_loc_nm.Text.ToString().Equals(""))
            {
                MessageBox.Show("설비위치명을 입력하시기 바랍니다.");
                return;
            }

            if (lbl_gbn.Text != "1")
            {
                wnDm wDm = new wnDm();
                int rsNum = wDm.insertSLoc(txt_s_loc_nm.Text.ToString());

                if (rsNum == 0)
                {
                    lbl_gbn.Text = "";
                    txt_s_loc_cd.Text = "(자동발급)";
                    txt_accu_nm.Text = "";
                    btnNew.PerformClick();

                    sLoc_list();
                    MessageBox.Show("성공적으로 등록하였습니다.");
                }
                else if (rsNum == 1)
                    MessageBox.Show("저장에 실패하였습니다");
                else if (rsNum == 2)
                    MessageBox.Show("SQL COMMAND 에러");
                else if (rsNum == 3)
                    MessageBox.Show("기존 코드가 있으므로 \n 다른 코드로 입력 바랍니다.");
                else
                    MessageBox.Show("Exception 에러1");
            }
            else
            {
                wnDm wDm = new wnDm();
                int rsNum = wDm.updateSLoc(txt_s_loc_cd.Text.ToString(), txt_s_loc_nm.Text.ToString());
                if (rsNum == 0)
                {
                    sLoc_list();
                    btnNew.PerformClick();

                    MessageBox.Show("성공적으로 수정하였습니다.");
                }
                else if (rsNum == 1)
                    MessageBox.Show("저장에 실패하였습니다");
                else
                    MessageBox.Show("Exception 에러");
            }

        }

        private void accu_logic()
        {
            if (txt_accu_cd.Text == null || txt_accu_cd.Text.ToString().Equals(""))
            {
                MessageBox.Show("계정코드를 입력하시기 바랍니다.");
                return;
            }
            if (txt_accu_nm.Text == null || txt_accu_nm.Text.ToString().Equals(""))
            {
                MessageBox.Show("계정명을 입력하시기 바랍니다.");
                return;
            }

            if (lbl_gbn.Text != "1")
            {
                wnDm wDm = new wnDm();
                int rsNum = wDm.insertAccu(txt_accu_cd.Text.ToString(), txt_accu_nm.Text.ToString());

                if (rsNum == 0)
                {
                    lbl_gbn.Text = "";
                    txt_accu_cd.Text = "";
                    txt_accu_cd.Enabled = true;
                    txt_accu_nm.Text = "";

                    accu_list();
                    MessageBox.Show("성공적으로 등록하였습니다.");
                }
                else if (rsNum == 1)
                    MessageBox.Show("저장에 실패하였습니다");
                else if (rsNum == 2)
                    MessageBox.Show("SQL COMMAND 에러");
                else if (rsNum == 3)
                    MessageBox.Show("기존 코드가 있으므로 \n 다른 코드로 입력 바랍니다.");
                else
                    MessageBox.Show("Exception 에러1");
            }
            else
            {
                wnDm wDm = new wnDm();
                int rsNum = wDm.updateAccu(txt_accu_cd.Text.ToString(), txt_accu_nm.Text.ToString());
                if (rsNum == 0)
                {
                    accu_list();
                    MessageBox.Show("성공적으로 수정하였습니다.");
                }
                else if (rsNum == 1)
                    MessageBox.Show("저장에 실패하였습니다");
                else
                    MessageBox.Show("Exception 에러");
            }
        }

        private void accu_list()
        {
            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = null;
                dt = wDm.fn_accu_list();

                dgv_accu.Rows.Clear();
                if (dt != null && dt.Rows.Count > 0)
                {
                    this.dgv_accu.RowCount = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgv_accu.Rows[i].Cells["ACCU_CD"].Value = dt.Rows[i]["ACCU_CD"].ToString();
                        dgv_accu.Rows[i].Cells["ACCU_NM"].Value = dt.Rows[i]["ACCU_NM"].ToString();
                    }
                }
                else
                {
                    dgv_accu.Rows.Clear();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("계정 리스트 출력 시 오류 발생");
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(e.Message + " - " + e.ToString());
                msg.ShowDialog();
            } 
        }

        private void loc_logic()
        {
            if (txt_loc_cd.Text.ToString().Equals(""))
            {
                MessageBox.Show("보관위치코드를 입력하시기 바랍니다.");
                return;
            }
            if (txt_loc_nm.Text.ToString().Equals(""))
            {
                MessageBox.Show("보관위치명을 입력하시기 바랍니다.");
                return;
            }
            if (lbl_gbn.Text != "1")
            {
                wnDm wDm = new wnDm();

                int rsNum = wDm.insertLoc(cmb_stor.SelectedValue.ToString(), txt_loc_cd.Text, txt_loc_nm.Text, txt_loc_cmt.Text);

                if (rsNum == 0)
                {
                    txt_loc_cd.Text = "";
                    txt_loc_nm.Text = "";
                    txt_loc_cmt.Text = "";
                    //chk_type.Checked = false;

                    location_list();
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

                int rsNum = wDm.updatetLoc(cmb_stor.SelectedValue.ToString(), txt_loc_cd.Text, txt_loc_nm.Text, txt_loc_cmt.Text);
                //if (rsNum == 0)
                if (true)
                {
                    location_list();
                    MessageBox.Show("성공적으로 수정하였습니다.");
                }
                else if (true)
                    MessageBox.Show("저장에 실패하였습니다");
                else
                    MessageBox.Show("Exception 에러");
            }
        }

       
        private void chk_logic()
        {
            wnAdo wAdo = new wnAdo();
            wnDm wDm = new wnDm();
           

            if (txt_ChkCode.Text.ToString().Equals(""))
            {
                MessageBox.Show("검사기준코드를 입력하시기 바랍니다.");
                return;
            }
            if (txtChkNM.Text.ToString().Equals(""))
            {
                MessageBox.Show("검사기준명을 입력하시기 바랍니다.");
                return;
            }
            StringBuilder sb = new StringBuilder();
           
            if (lbl_chkGB.Text != "1")
            {

                sb.AppendLine(" 	insert  into N_CHK_CODE (CHK_CD,CHK_GUBUN,CHK_NM,CHK_ORD,COMMENT,instaff,intime) values ('" + txt_ChkCode.Text + "','"+ (String)cbo검사종류.SelectedValue +"','" + txtChkNM.Text + "','" + txtODR.Text + "','" + txt_chkMemo.Text + "','" + Common.p_strStaffNo + "',GETDATE())");
                MessageBox.Show("저장되었습니다.");
            }
            else
            {

                sb.AppendLine(" 	update N_CHK_CODE set CHK_NM='" + txtChkNM.Text + "' , COMMENT='" + txt_chkMemo.Text + "' ,CHK_GUBUN='" + (String)cbo검사종류.SelectedValue + "' ,UPSTAFF='" + Common.p_strStaffNo + "',UPTIME=GETDATE() where CHK_CD='" + txt_ChkCode.Text + "'");
                MessageBox.Show("수정되었습니다.");

           
            }

            Debug.WriteLine(sb);

            SqlCommand sCommand = new SqlCommand(sb.ToString());

            int qResult = wAdo.SqlCommandEtc(sCommand, "insert_RAW_CHK_EXAM_TB");
            chk_list();
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbl_gbn.Text = "0";

            if (tabControl.SelectedTab.Name == "unitTab") //단위 등록
            {
                unit_list();
            }
            else if (tabControl.SelectedTab.Name == "lineTab") //라인 등록
            {
                line_list();
            }
            else if (tabControl.SelectedTab.Name == "chkTab") //검사기준 등록
            {
                chk_list();
            }
            else if (tabControl.SelectedTab.Name == "rawTab") //원자재유형등록
            {
                unitTypeList(dgv_raw,"2");
            }
            else if (tabControl.SelectedTab.Name == "itemTab") //제품유형등록
            {
                unitTypeList(dgv_item,"3");
            }
            else if (tabControl.SelectedTab.Name == "custTab") //거래처유형등록
            {
                unitTypeList(dgv_cust,"4");
            }
            else if (tabControl.SelectedTab.Name == "storageTab") 
            {
                stor_list();
            }
            else if (tabControl.SelectedTab.Name == "locationTab")
            {
                location_list();
            }
            else if (tabControl.SelectedTab.Name == "AccountTab")
            {
                accu_list();
            }
            else if (tabControl.SelectedTab.Name == "tabS_Loc")
            {
                sLoc_list();
            }
            else
            {

            }
        }

        
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion common logic

        #region type logic
        /*
        private void type_logic()
        {
            if (txt_type_cd.Text.ToString().Equals(""))
            {
                MessageBox.Show("유형코드를 입력하시기 바랍니다.");
                return;
            }
            if (txt_type_nm.Text.ToString().Equals(""))
            {
                MessageBox.Show("유형명을 입력하시기 바랍니다.");
                return;
            }
            if (lbl_type_gbn.Text != "1")
            {
                wnDm wDm = new wnDm();
                string chk_type_yn = cmb_type_gb.SelectedValue.ToString();
                //if (chk_type.Checked == true)
                //{
                //    chk_type_yn = "Y";
                //}
                //else
                //{
                //    chk_type_yn = "N";
                //}
                int rsNum = wDm.insertType(txt_type_cd.Text.ToString(), txt_type_nm.Text.ToString(), chk_type_yn, txt_type_cmt.Text.ToString());

                if (rsNum == 0)
                {
                    txt_type_cd.Text = "";
                    txt_type_nm.Text = "";
                    txt_type_cmt.Text = "";
                    //chk_type.Checked = false;

                    type_list();
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
                string chk_type_yn = cmb_type_gb.SelectedValue.ToString();

                //if (chk_type.Checked == true)
                //{
                //    chk_type_yn = "Y";
                //}
                //else
                //{
                //    chk_type_yn = "N";
                //}
                int rsNum = wDm.updateType(txt_type_cd.Text.ToString(), txt_type_nm.Text.ToString(), chk_type_yn, txt_type_cmt.Text.ToString());
                if (rsNum == 0)
                {
                    type_list();
                    MessageBox.Show("성공적으로 수정하였습니다.");
                }
                else if (rsNum == 1)
                    MessageBox.Show("저장에 실패하였습니다");
                else
                    MessageBox.Show("Exception 에러");
            }
        }
        */
        /*
        private void type_del()
        {
            wnDm wDm = new wnDm();
            int rsNum = wDm.deleteType(txt_type_cd.Text.ToString());
            if (rsNum == 0)
            {
                lbl_type_gbn.Text = "";
                txt_type_cd.Enabled = true;
                txt_type_cd.Text = "";
                txt_type_nm.Text = "";
                txt_type_cmt.Text = "";
                //chk_type.Checked = false;

                btnDelete.Enabled = false;

                type_list();
                MessageBox.Show("성공적으로 삭제하였습니다.");
            }
            else if (rsNum == 1)
            {
                MessageBox.Show("삭제에 실패하였습니다.");
            }
        }
        */
        //private void type_list()
        //{
        //    try
        //    {
        //        wnDm wDm = new wnDm();
        //        DataTable dt = null;
        //        dt = wDm.fn_Type_List();

        //        if (dt != null && dt.Rows.Count > 0)
        //        {
        //            this.dataTypeGrid.RowCount = dt.Rows.Count;
        //            for (int i = 0; i < dt.Rows.Count; i++)
        //            {
        //                dataTypeGrid.Rows[i].Cells[0].Value = dt.Rows[i]["TYPE_CD"].ToString();
        //                dataTypeGrid.Rows[i].Cells[1].Value = dt.Rows[i]["TYPE_NM"].ToString();
        //                dataTypeGrid.Rows[i].Cells[2].Value = dt.Rows[i]["POOR_TYPE_YN"].ToString();
        //                dataTypeGrid.Rows[i].Cells[3].Value = dt.Rows[i]["COMMENT"].ToString();
        //            }
        //        }
        //        else
        //        {
        //            dataTypeGrid.Rows.Clear();
        //        }
        //    }
        //    catch (Exception e)
        //    {

        //    }
        //}
        private void location_list()
        {
            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = null;
                dt = wDm.fn_loc_List();

                if (dt != null && dt.Rows.Count > 0)
                {
                    this.dgv_loc.RowCount = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgv_loc.Rows[i].Cells["locCd"].Value = dt.Rows[i]["LOC_CD"].ToString();
                        dgv_loc.Rows[i].Cells["locNm"].Value = dt.Rows[i]["LOC_NM"].ToString();
                        dgv_loc.Rows[i].Cells["locCmt"].Value = dt.Rows[i]["COMMENT"].ToString();
                        dgv_loc.Rows[i].Cells["STOR"].Value = dt.Rows[i]["STORAGE_NM"].ToString();
                        dgv_loc.Rows[i].Cells["STOR_CD"].Value = dt.Rows[i]["STORAGE_CD"].ToString();
                    }
                }
                else
                {
                    dgv_loc.Rows.Clear();
                }
            }
            catch (Exception e)
            {
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(e.Message + " - " + e.ToString());
                msg.ShowDialog();
            }
        }

        private void txt_type_cd_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComInfo.onlyNum(sender, e);
        }
        #endregion type logic

        #region unit logic
        private void unit_logic()
        {
            if (txt_unit_cd.Text.ToString().Equals(""))
            {
                MessageBox.Show("단위코드를 입력하시기 바랍니다.");
                return;
            }
            if (txt_unit_nm.Text.ToString().Equals(""))
            {
                MessageBox.Show("단위명을 입력하시기 바랍니다.");
                return;
            }
            if (lbl_unit_gbn.Text != "1")
            {
                wnDm wDm = new wnDm();
                int rsNum = wDm.insertUnit(txt_unit_cd.Text.ToString(), txt_unit_nm.Text.ToString(), txt_unit_cmt.Text.ToString());

                if (rsNum == 0)
                {
                    txt_unit_cd.Text = "";
                    txt_unit_nm.Text = "";
                    txt_unit_cmt.Text = "";

                    unit_list();
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
                int rsNum = wDm.updateUnit(txt_unit_cd.Text.ToString(), txt_unit_nm.Text.ToString(), txt_unit_cmt.Text.ToString());
                if (rsNum == 0)
                {
                    unit_list();
                    MessageBox.Show("성공적으로 수정하였습니다.");
                }
                else if (rsNum == 1)
                    MessageBox.Show("저장에 실패하였습니다");
                else
                    MessageBox.Show("Exception 에러2");
            }
        }

        private void unit_del()
        {
            wnDm wDm = new wnDm();
            int rsNum = wDm.deleteUnit(txt_unit_cd.Text.ToString());
            if (rsNum == 0)
            {
                lbl_unit_gbn.Text = "";
                txt_unit_cd.Enabled = true;
                txt_unit_cd.Text = "";
                txt_unit_nm.Text = "";
                txt_unit_cmt.Text = "";
                btnDelete.Enabled = false;

                unit_list();
                MessageBox.Show("성공적으로 삭제하였습니다.");
            }
            else if (rsNum == 1)
            {
                MessageBox.Show("삭제에 실패하였습니다.");
            }
        }

        private void unit_list()
        {
            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = null;
                dt = wDm.fn_Unit_List();

                if (dt != null && dt.Rows.Count > 0)
                {
                    this.dataUnitGrid.RowCount = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dataUnitGrid.Rows[i].Cells[0].Value = dt.Rows[i]["UNIT_CD"].ToString();
                        dataUnitGrid.Rows[i].Cells[1].Value = dt.Rows[i]["UNIT_NM"].ToString();
                        dataUnitGrid.Rows[i].Cells[2].Value = dt.Rows[i]["COMMENT"].ToString();
                    }
                }
                else
                {
                    dataUnitGrid.Rows.Clear();
                }
            }
            catch (Exception e)
            {
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(e.Message + " - " + e.ToString());
                msg.ShowDialog();
            }
        }

        private void dataUnitGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnDelete.Enabled = true;
            lbl_unit_gbn.Text = "1";
            txt_unit_cd.Enabled = false;
            txt_unit_cd.Text = dataUnitGrid.Rows[e.RowIndex].Cells[0].Value.ToString();
            txt_unit_nm.Text = dataUnitGrid.Rows[e.RowIndex].Cells[1].Value.ToString();
            txt_unit_cmt.Text = dataUnitGrid.Rows[e.RowIndex].Cells[2].Value.ToString();

        }

        private void txt_unit_cd_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComInfo.onlyNum(sender, e);
        }

        #endregion unit logic

        #region line logic
        private void line_logic()
        {
            if (txt_line_cd.Text.ToString().Equals(""))
            {
                MessageBox.Show("라인코드를 입력하시기 바랍니다.");
                return;
            }
            if (txt_line_nm.Text.ToString().Equals(""))
            {
                MessageBox.Show("라인명을 입력하시기 바랍니다.");
                return;
            }
            if (lbl_line_gbn.Text != "1")
            {
                wnDm wDm = new wnDm();
                int rsNum = wDm.insertLine(txt_line_cd.Text.ToString(), txt_line_nm.Text.ToString(), txt_line_cmt.Text.ToString());

                if (rsNum == 0)
                {
                    txt_line_cd.Text = "";
                    txt_line_nm.Text = "";
                    txt_line_cmt.Text = "";

                    line_list();
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
                int rsNum = wDm.updateLine(txt_line_cd.Text.ToString(), txt_line_nm.Text.ToString(), txt_line_cmt.Text.ToString());
                if (rsNum == 0)
                {
                    line_list();
                    MessageBox.Show("성공적으로 수정하였습니다.");
                }
                else if (rsNum == 1)
                    MessageBox.Show("저장에 실패하였습니다");
                else
                    MessageBox.Show("Exception 에러2");
            }
        }

        private void line_del()
        {
            wnDm wDm = new wnDm();
            int rsNum = wDm.deleteLine(txt_line_cd.Text.ToString());
            if (rsNum == 0)
            {
                lbl_line_gbn.Text = "";
                txt_line_cd.Enabled = true;
                txt_line_cd.Text = "";
                txt_line_nm.Text = "";
                txt_line_cmt.Text = "";
                btnDelete.Enabled = false;

                line_list();
                MessageBox.Show("성공적으로 삭제하였습니다.");
            }
            else if (rsNum == 1)
            {
                MessageBox.Show("삭제에 실패하였습니다.");
            }
        }

        private void line_list()
        {
            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = null;
                dt = wDm.fn_Line_List();

                if (dt != null && dt.Rows.Count > 0)
                {
                    this.dataLineGrid.RowCount = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dataLineGrid.Rows[i].Cells[0].Value = dt.Rows[i]["LINE_CD"].ToString();
                        dataLineGrid.Rows[i].Cells[1].Value = dt.Rows[i]["LINE_NM"].ToString();
                        dataLineGrid.Rows[i].Cells[2].Value = dt.Rows[i]["COMMENT"].ToString();
                    }
                }
                else
                {
                    dataLineGrid.Rows.Clear();
                }
            }
            catch (Exception e)
            {
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(e.Message + " - " + e.ToString());
                msg.ShowDialog();
            }
        }
        /// <summary>
        /// 라인 그리드뷰 더블클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataLineGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnDelete.Enabled = true;
            lbl_line_gbn.Text = "1";
            txt_line_cd.Enabled = false;
            txt_line_cd.Text = dataLineGrid.Rows[e.RowIndex].Cells[0].Value.ToString();
            txt_line_nm.Text = dataLineGrid.Rows[e.RowIndex].Cells[1].Value.ToString();
            txt_line_cmt.Text = dataLineGrid.Rows[e.RowIndex].Cells[2].Value.ToString();
            pnl설비.Visible = true;
            lbl라인명.Text = dataLineGrid.Rows[e.RowIndex].Cells["라인명"].Value.ToString();
            lbl라인명.Tag = dataLineGrid.Rows[e.RowIndex].Cells["라인코드"].Value.ToString();
        }

        private void txt_line_cd_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComInfo.onlyNum(sender, e);
        }

        #endregion line logic
       
       
        

        

        
    
        private void label1_Click(object sender, EventArgs e)
        {

        }





        private void chk_list()
        {
            dgvCHK.Rows.Clear();

            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = null;
                dt = wDm.fn_chk_List();

                if (dt != null && dt.Rows.Count > 0)
                {
                    this.dgvCHK.RowCount = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgvCHK.Rows[i].Cells[0].Value = dt.Rows[i]["CHK_CD"].ToString();
                        dgvCHK.Rows[i].Cells[1].Value = dt.Rows[i]["S_CODE_NM"].ToString();
                        dgvCHK.Rows[i].Cells[2].Value = dt.Rows[i]["CHK_ORD"].ToString();
                        dgvCHK.Rows[i].Cells[3].Value = dt.Rows[i]["CHK_NM"].ToString();
                        dgvCHK.Rows[i].Cells[4].Value = dt.Rows[i]["COMMENT"].ToString();
                        //CHK_ORD

                      
                    }
                }
                else
                {
                    dgvCHK.Rows.Clear();
                }
            }
            catch (Exception e)
            {
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(e.Message + " - " + e.ToString());
                msg.ShowDialog();
            }
        }

        private void chk_del()
        {
         
            wnDm wDm = new wnDm();
            try
            {
                wDm.deleteCHK(txt_ChkCode.Text.ToString());
                MessageBox.Show("성공하였습니다.");

            }
            catch
            {
                MessageBox.Show("실패하였습니다.");
                    
            }
            chk_list();
        }

        private void dgvCHK_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnDelete.Enabled = true;
            lbl_chkGB .Text = "1";
            txt_ChkCode.Enabled = false;
            txt_ChkCode.Text = dgvCHK.Rows[e.RowIndex].Cells[0].Value.ToString();       
            if(dgvCHK.Rows[e.RowIndex].Cells[1].Value.ToString().Equals("공정"))
               cbo검사종류.SelectedIndex = 0;
            else if(dgvCHK.Rows[e.RowIndex].Cells[1].Value.ToString().Equals("제품"))
               cbo검사종류.SelectedIndex = 1;
            else if (dgvCHK.Rows[e.RowIndex].Cells[1].Value.ToString().Equals("원자재 수입"))
                cbo검사종류.SelectedIndex = 2;
            //cbo검사종류.SelectedValue = dgvCHK.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtODR.Text = dgvCHK.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtChkNM.Text = dgvCHK.Rows[e.RowIndex].Cells[3].Value.ToString();

            txt_chkMemo.Text = dgvCHK.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void txt_type_cmt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //to do
                btnSave.Focus();
            }

            else
            {
                return;
            } 
        }

        private void txt_unit_cmt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //to do
                btnSave.Focus();
            }

            else
            {
                return;
            } 
        }

        private void txt_line_cmt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //to do
                btnSave.Focus();
            }

            else
            {
                return;
            } 
        }

        private void txt_poor_cmt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //to do
                btnSave.Focus();
            }

            else
            {
                return;
            } 
        }

        private void txt_chkMemo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //to do
                btnSave.Focus();
            }

            else
            {
                return;
            } 
        }

        private void lineTab_Click(object sender, EventArgs e)
        {

        }

    
     
       

        private void btn_half_plus_Click(object sender, EventArgs e)
        {
            dgv설비.Rows.Add();
        }

        private void dgv설비_KeyDown(object sender, KeyEventArgs e)
        {
            conDataGridView grd = (conDataGridView)sender;
            DataGridViewCell cell = grd[grd.CurrentCell.ColumnIndex, grd.CurrentCell.RowIndex];

            if (grd.CurrentCell == null) return;
            if (grd.CurrentCell.RowIndex < 0) return;
            if (grd.CurrentCell.ColumnIndex < 0) return;

            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }
        }

        private void dgv설비_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            conDataGridView grd = (conDataGridView)sender;
            DataGridViewCell cell = grd[e.ColumnIndex, e.RowIndex];

            cell.Style.BackColor = Color.White;

            DataTable dt = null;
            if ( grd._KeyInput == "enter")
            {

                pop설비검색 pop설비검색 = new pop설비검색();
                pop설비검색.ShowDialog();
                dt = pop설비검색.dt;

                //dgv설비.Rows[e.RowIndex].Cells["설비_설비명"].Value = dt.Rows[0]["FAC_NM"].ToString();
                //dgv설비.Rows[e.RowIndex].Cells["설비_모델명"].Value = dt.Rows[0]["MODEL_NM"].ToString();
                //dgv설비.Rows[e.RowIndex].Cells["설비_관리코드"].Value = dt.Rows[0]["FAC_CD"].ToString();
            }
          
        }


        private void unitType_logic(string L_CODE, string txt_unitType_cd, string txt_unitType_nm, string txt_unitType_cmt , DataGridView dgv)
        {
         
            if (txt_unitType_nm.Equals(""))
            {
                MessageBox.Show("유형타입명을 입력하시기 바랍니다.");
                return;
            }
           
            if (lbl_gbn.Text != "1")
            {
                
                wnDm wDm = new wnDm();
                int rsNum = -1;
                if (L_CODE.Equals("1"))
                {
                    rsNum = wDm.insert_PoorType(
                        txt_unitType_nm,
                        txt_unitType_cmt);
                }
                else
                {
                    rsNum = wDm.insert_UnitType(
                        L_CODE,
                        txt_unitType_cd,
                        txt_unitType_nm,
                        txt_unitType_cmt);
                }

                if (rsNum == 0)
                {
                    MessageBox.Show("성공적으로 등록하였습니다.");
                    unitTypeList(dgv,L_CODE);
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
                int rsNum = wDm.update_UnitType(
                    L_CODE,
                    txt_unitType_cd,
                    txt_unitType_nm,
                    txt_unitType_cmt);

                if (rsNum == 0)
                {
                    unitTypeList(dgv,L_CODE);
                    MessageBox.Show("성공적으로 수정하였습니다.");
                }
                else if (rsNum == 1)
                    MessageBox.Show("저장에 실패하였습니다");
                else
                    MessageBox.Show("Exception 에러2");
            }
        }

        private void unitTypeList(DataGridView dgv, string L_CODE)
        {
            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = null;
                dt = wDm.fn_UnitType_List(L_CODE);
                dgv.Rows.Clear();
                if (dt != null && dt.Rows.Count > 0)
                {
                    dgv.RowCount = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgv.Rows[i].Cells[0].Value = L_CODE;
                        dgv.Rows[i].Cells[1].Value = dt.Rows[i]["UNIT_TYPE_CD"].ToString();
                        dgv.Rows[i].Cells[2].Value = dt.Rows[i]["UNIT_TYPE_NM"].ToString();
                        dgv.Rows[i].Cells[3].Value = dt.Rows[i]["COMMENT"].ToString();
                    }
                }
                else
                {
                    dgv.Rows.Clear();
                }
            }
            catch (Exception e)
            {
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(e.Message + " - " + e.ToString());
                msg.ShowDialog();
            }
        }

        private void dgv_raw_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            lbl_gbn.Text = "1";
            btnDelete.Enabled = true;
            txt_rawType_cd.ReadOnly = true;
            txt_rawType_cd.Text = dgv_raw.Rows[e.RowIndex].Cells[1].Value.ToString();
            txt_rawType_nm.Text = dgv_raw.Rows[e.RowIndex].Cells[2].Value.ToString();
            txt_rawType_cmt.Text = dgv_raw.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void dgv_item_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            lbl_gbn.Text = "1";
            btnDelete.Enabled = true;
            txt_itemType_cd.ReadOnly = true;
            txt_itemType_cd.Text = dgv_item.Rows[e.RowIndex].Cells[1].Value.ToString();
            txt_itemType_nm.Text = dgv_item.Rows[e.RowIndex].Cells[2].Value.ToString();
            txt_itemType_cmt.Text = dgv_item.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void dgv_cust_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            lbl_gbn.Text = "1";
            btnDelete.Enabled = true;
            txt_custType_cd.ReadOnly = true;
            txt_custType_cd.Text = dgv_cust.Rows[e.RowIndex].Cells[1].Value.ToString();
            txt_custType_nm.Text = dgv_cust.Rows[e.RowIndex].Cells[2].Value.ToString();
            txt_custType_cmt.Text = dgv_cust.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void dgv_storage_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            lbl_gbn.Text = "1";
            btnDelete.Enabled = true;
            txt_loc_cd.ReadOnly = true;
            txt_loc_cd.Text = dgv_loc.Rows[e.RowIndex].Cells["locCd"].Value.ToString();
            txt_loc_nm.Text = dgv_loc.Rows[e.RowIndex].Cells["locNm"].Value.ToString();
            txt_loc_cmt.Text = dgv_loc.Rows[e.RowIndex].Cells["locCmt"].Value.ToString();
            cmb_stor.SelectedValue = dgv_loc.Rows[e.RowIndex].Cells["STOR_CD"].Value.ToString();
        }

        private void loc_del()
        {
            wnDm wDm = new wnDm();
            int rsNum = wDm.deleteLoc(txt_loc_cd.Text.ToString());
            if (rsNum == 0)
            {
                lbl_gbn.Text = "0";
                txt_loc_cd.ReadOnly = false;
                txt_loc_cd.Text = "";
                txt_loc_nm.Text = "";
                txt_loc_cmt.Text = "";
                btnDelete.Enabled = false;

                line_list();
                MessageBox.Show("성공적으로 삭제하였습니다.");
                location_list();
            }
            else if (rsNum == 1)
            {
                MessageBox.Show("삭제에 실패하였습니다.");
            }
        }

        #region dept logic

        //private void dept_logic()
        //{
        //    if (txtDeptCd.Text.ToString().Equals(""))
        //    {
        //        MessageBox.Show("부서코드를 입력하시기 바랍니다.");
        //        return;
        //    }
        //    if (txtDeptNm.Text.ToString().Equals(""))
        //    {
        //        MessageBox.Show("부서명을 입력하시기 바랍니다.");
        //        return;
        //    }
        //    if (lbl_gbn.Text != "1")
        //    {
        //        wnDm wDm = new wnDm();
        //        int rsNum = wDm.insertDept(txtDeptCd.Text.ToString(), txtDeptNm.Text.ToString(), txtDeptCmt.Text.ToString());

        //        if (rsNum == 0)
        //        {
        //            txtDeptCd.Text = "";
        //            txtDeptNm.Text = "";
        //            txtDeptCmt.Text = "";

        //            dept_list();
        //            MessageBox.Show("성공적으로 등록하였습니다.");
        //        }
        //        else if (rsNum == 1)
        //            MessageBox.Show("저장에 실패하였습니다");
        //        else if (rsNum == 2)
        //            MessageBox.Show("SQL COMMAND 에러");
        //        else if (rsNum == 3)
        //            MessageBox.Show("기존 코드가 있으므로 \n 다른 코드로 입력 바랍니다.");
        //        else
        //            MessageBox.Show("Exception 에러1");
        //    }
        //    else
        //    {
        //        wnDm wDm = new wnDm();
        //        int rsNum = wDm.updateDept(txtDeptCd.Text.ToString(), txtDeptNm.Text.ToString(), txtDeptCmt.Text.ToString());
        //        if (rsNum == 0)
        //        {
        //            dept_list();
        //            MessageBox.Show("성공적으로 수정하였습니다.");
        //        }
        //        else if (rsNum == 1)
        //            MessageBox.Show("저장에 실패하였습니다");
        //        else
        //            MessageBox.Show("Exception 에러");
        //    }

        //}

        //private void dept_del()
        //{
        //    wnDm wDm = new wnDm();
        //    int rsNum = wDm.deleteDept(txtDeptCd.Text.ToString());
        //    if (rsNum == 0)
        //    {
        //        btnDelete.Enabled = false;
        //        txtDeptCd.Enabled = true;
        //        txtDeptCd.Text = "";
        //        txtDeptNm.Text = "";
        //        txtDeptCmt.Text = "";
        //        lbl_gbn.Text = "0";

        //        dept_list();
        //        MessageBox.Show("성공적으로 삭제하였습니다.");
        //    }
        //    else if (rsNum == 1)
        //        MessageBox.Show("삭제에 실패하였습니다");
        //    else
        //        MessageBox.Show("Exception 에러");
        //}
        //private void dept_list()
        //{
        //    try
        //    {
        //        wnDm wDm = new wnDm();
        //        DataTable dt = null;
        //        dt = wDm.fn_Dept_List();

        //        if (dt != null && dt.Rows.Count > 0)
        //        {
        //            this.dataDeptGrid.RowCount = dt.Rows.Count;
        //            for (int i = 0; i < dt.Rows.Count; i++)
        //            {
        //                dataDeptGrid.Rows[i].Cells[0].Value = dt.Rows[i]["DEPT_CD"].ToString();
        //                dataDeptGrid.Rows[i].Cells[1].Value = dt.Rows[i]["DEPT_NM"].ToString();
        //                dataDeptGrid.Rows[i].Cells[2].Value = dt.Rows[i]["COMMENT"].ToString();
        //            }
        //        }
        //        else
        //        {
        //            dataDeptGrid.Rows.Clear();
        //        }
        //    }
        //    catch (Exception e)
        //    {

        //    }
        //}

        private void dataDeptGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnDelete.Enabled = true;
            lbl_gbn.Text = "1";
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
        //private void pos_logic()
        //{
        //    if (txt_pos_cd.Text.ToString().Equals(""))
        //    {
        //        MessageBox.Show("직위코드를 입력하시기 바랍니다.");
        //        return;
        //    }
        //    if (txt_pos_nm.Text.ToString().Equals(""))
        //    {
        //        MessageBox.Show("직위명을 입력하시기 바랍니다.");
        //        return;
        //    }

        //    if (lbl_gbn.Text != "1")
        //    {
        //        wnDm wDm = new wnDm();
        //        int rsNum = wDm.insertPos(txt_pos_cd.Text.ToString(), txt_pos_nm.Text.ToString(), txt_pos_cmt.Text.ToString());

        //        if (rsNum == 0)
        //        {
        //            txt_pos_cd.Text = "";
        //            txt_pos_nm.Text = "";
        //            txt_pos_cmt.Text = "";

        //            pos_list();
        //            MessageBox.Show("성공적으로 등록하였습니다.");
        //        }
        //        else if (rsNum == 1)
        //            MessageBox.Show("저장에 실패하였습니다");
        //        else if (rsNum == 2)
        //            MessageBox.Show("SQL COMMAND 에러");
        //        else if (rsNum == 3)
        //            MessageBox.Show("기존 코드가 있으므로 \n 다른 코드로 입력 바랍니다.");
        //        else
        //            MessageBox.Show("Exception 에러1");
        //    }
        //    else
        //    {
        //        wnDm wDm = new wnDm();
        //        int rsNum = wDm.updatePos(txt_pos_cd.Text.ToString(), txt_pos_nm.Text.ToString(), txt_pos_cmt.Text.ToString());
        //        if (rsNum == 0)
        //        {
        //            pos_list();
        //            MessageBox.Show("성공적으로 수정하였습니다.");
        //        }
        //        else if (rsNum == 1)
        //            MessageBox.Show("저장에 실패하였습니다");
        //        else
        //            MessageBox.Show("Exception 에러2");
        //    }
        //}
        //private void pos_del()
        //{
        //    wnDm wDm = new wnDm();
        //    int rsNum = wDm.deletePos(txt_pos_cd.Text.ToString());
        //    if (rsNum == 0)
        //    {
        //        lbl_gbn.Text = "0";
        //        txt_pos_cd.Enabled = true;
        //        txt_pos_cd.Text = "";
        //        txt_pos_nm.Text = "";
        //        txt_pos_cmt.Text = "";
        //        btnDelete.Enabled = false;
        //        pos_list();
        //        MessageBox.Show("성공적으로 삭제하였습니다.");
        //    }
        //    else if (rsNum == 1)
        //        MessageBox.Show("삭제에 실패하였습니다");
        //    else
        //        MessageBox.Show("Exception 에러");
        //}
        //private void pos_list()
        //{
        //    try
        //    {
        //        wnDm wDm = new wnDm();
        //        DataTable dt = null;
        //        dt = wDm.fn_Pos_List();

        //        if (dt != null && dt.Rows.Count > 0)
        //        {
        //            this.dataPosGrid.RowCount = dt.Rows.Count;
        //            for (int i = 0; i < dt.Rows.Count; i++)
        //            {
        //                dataPosGrid.Rows[i].Cells[0].Value = dt.Rows[i]["POS_CD"].ToString();
        //                dataPosGrid.Rows[i].Cells[1].Value = dt.Rows[i]["POS_NM"].ToString();
        //                dataPosGrid.Rows[i].Cells[2].Value = dt.Rows[i]["COMMENT"].ToString();
        //            }
        //        }
        //        else
        //        {
        //            dataPosGrid.Rows.Clear();
        //        }
        //    }
        //    catch (Exception e)
        //    {

        //    }
        //}
        //private void dataPosGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    btnDelete.Enabled = true;
        //    lbl_gbn.Text = "1";
        //    txt_pos_cd.Enabled = false;
        //    txt_pos_cd.Text = dataPosGrid.Rows[e.RowIndex].Cells[0].Value.ToString();
        //    txt_pos_nm.Text = dataPosGrid.Rows[e.RowIndex].Cells[1].Value.ToString();
        //    txt_pos_cmt.Text = dataPosGrid.Rows[e.RowIndex].Cells[2].Value.ToString();
        //}
        //private void txt_pos_cd_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    ComInfo.onlyNum(sender, e);
        //}
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

            if (lbl_gbn.Text != "1")
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
                    MessageBox.Show("기존 코드가 있으므로 \n 다른 코드로 입력 바랍니다.");
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
                lbl_gbn.Text = "0";
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
            lbl_gbn.Text = "1";
            txt_stor_cd.Enabled = false;
            txt_stor_cd.Text = dataStorGrid.Rows[e.RowIndex].Cells[0].Value.ToString();
            txt_stor_nm.Text = dataStorGrid.Rows[e.RowIndex].Cells[1].Value.ToString();
            txt_stor_cmt.Text = dataStorGrid.Rows[e.RowIndex].Cells[2].Value.ToString();
        }
        #endregion storage logic



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
                    // 단일키 사용시
                    btnNew.PerformClick();
                    break;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
            return true;
        }

        private void dgv_accu_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                lbl_gbn.Text = "1";
                btnDelete.Enabled = true;
                txt_accu_cd.Enabled = false;

                txt_accu_cd.Text = dgv_accu.Rows[e.RowIndex].Cells["ACCU_CD"].Value.ToString();
                txt_accu_nm.Text = dgv_accu.Rows[e.RowIndex].Cells["ACCU_NM"].Value.ToString();
            }
        }

        private void dgv_sLoc_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                lbl_gbn.Text = "1";
                btnDelete.Enabled = true;

                txt_s_loc_cd.Text = dgv_sLoc.Rows[e.RowIndex].Cells["S_LOC_CD"].Value.ToString();
                txt_s_loc_nm.Text = dgv_sLoc.Rows[e.RowIndex].Cells["S_LOC_NM"].Value.ToString();
            }
        }

        private void btn_half_minus_Click(object sender, EventArgs e)
        {
            if (dgv설비.CurrentCell != null)
            {
                dgv설비.Rows.RemoveAt(dgv설비.CurrentCell.RowIndex);
            }
        }

    }
}
