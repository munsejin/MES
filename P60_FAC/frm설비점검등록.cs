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

namespace MES.P60_FAC
{
    public partial class frm설비점검등록 : Form
    {
        private wnGConstant wConst = new wnGConstant();
        public static bool p_IsAuth = true;    // 열람권한
        public static bool p_Isrgstr = true;    //등록/수정 권한
        wnDm wnDm = new wnDm();
        public static bool p_Isdel = true;    // 삭제 권한
        string gubun = "1";

        public frm설비점검등록()
        {
            InitializeComponent();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            wnDm wDm = new wnDm();
            int rsNum = wDm.DeleteFacFix(txt_faccd.Text.ToString(), int.Parse(txt_seq.Text.ToString()));
            if (rsNum == 0)
            {
                resetSetting();

                MessageBox.Show("성공적으로 삭제하였습니다.");
            }
            else if (rsNum == 1)
            {
                MessageBox.Show("삭제에 실패하였습니다.");
            }

            resetSetting();
        }        

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm설비점검등록_Load(object sender, EventArgs e)
        {
               lbl_title.Tag = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[0] + "$" + wnDm.fn_TitleName(this.Name.ToString()).Split('$')[1]; lbl_title.Text = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[2];

               init_ComboBox();

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

               FacChk_List();

        }

        private void init_ComboBox()
        {
            ComInfo comInfo = new ComInfo();
            string sqlQuery = "";
          
            cmb_Staff_NM.ValueMember = "코드";
            cmb_Staff_NM.DisplayMember = "명칭";
            sqlQuery = comInfo.queryStaff();
            wConst.ComboBox_Read_Blank(cmb_Staff_NM, sqlQuery);

            cmb_facnm.ValueMember = "코드";
            cmb_facnm.DisplayMember = "명칭";
            sqlQuery = comInfo.queryFac();
            wConst.ComboBox_Read_Blank(cmb_facnm, sqlQuery);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            resetSetting();
        }

        private void resetSetting()
        {
            txt_model_nm.Text = "";
            cmb_facnm.Text = "";
            txt_FixTime.Text = "";
            cmb_Staff_NM.SelectedIndex = 0;

            txt_FixCust.Text = "";
            txt_FixCost.Text = "";
            txt_FixReport.Text = "";
            txt_seq.Text = "";
            dtp_fix_date.Text = DateTime.Today.ToString();

            txt_model_nm.Enabled = true;
            btnDelete.Enabled = false;


            dgv_FacList.Rows.Clear();
            FacChk_List();
            
        }

        private void FacChk_List()
        {
            btnDelete.Enabled = false;

            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = null;
                dt = wDm.Fac_Chk_List("");

                this.dgv_FacList.RowCount = dt.Rows.Count;
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgv_FacList.Rows[i].Cells["FAC_NM"].Value = dt.Rows[i]["FAC_NM"].ToString();
                        dgv_FacList.Rows[i].Cells["FIX_GUBUN"].Value = dt.Rows[i]["FIX_GUBUN"].ToString();
                        dgv_FacList.Rows[i].Cells["STAFF_NM"].Value = dt.Rows[i]["STAFF_NM"].ToString();
                        dgv_FacList.Rows[i].Cells["FAC_CD"].Value = dt.Rows[i]["FAC_CD"].ToString();
                        dgv_FacList.Rows[i].Cells["STAFF_CD"].Value = dt.Rows[i]["STAFF_CD"].ToString();
                        dgv_FacList.Rows[i].Cells["FIX_TIME"].Value = dt.Rows[i]["FIX_TIME"].ToString();
                        dgv_FacList.Rows[i].Cells["FIX_COST"].Value = dt.Rows[i]["FIX_COST"].ToString();
                        dgv_FacList.Rows[i].Cells["FIX_CUST"].Value = dt.Rows[i]["FIX_CUST"].ToString();
                        dgv_FacList.Rows[i].Cells["FIX_REPORT"].Value = dt.Rows[i]["FIX_REPORT"].ToString();
                        dgv_FacList.Rows[i].Cells["FIX_SEQ"].Value = dt.Rows[i]["FIX_SEQ"].ToString();
                        dgv_FacList.Rows[i].Cells["MODEL_NM"].Value = dt.Rows[i]["MODEL_NM"].ToString();
                        dgv_FacList.Rows[i].Cells["FIX_DATE"].Value = dt.Rows[i]["FIX_DATE"].ToString();                               
                    }
                }
                else
                {
                    dgv_FacList.Rows.Clear();
                }
            }
            catch (Exception ex)
            {
            }


        }



        private void btnSave_Click(object sender, EventArgs e)
        { 
            FacChkLogic();
            resetSetting();
        }

        private void FacChkLogic()
        {
            try
            {
                if (cmb_facnm.SelectedIndex == 0)
                {
                    MessageBox.Show("설비를 선택하시기 바랍니다.");
                    return;
                }

                if (txt_model_nm.Text == "" && txt_model_nm.Text == null)
                {
                    MessageBox.Show("모델명을 입력하시기 바랍니다.");
                    return;
                }

                if (radioButton1.Checked == true)
                {
                    gubun = "1";
                }
                if (radioButton2.Checked == true)
                {
                    gubun = "2";
                }


                if (txt_model_nm.Enabled == true)
                {
                    wnDm wDm = new wnDm();
                    int rsNum = wDm.InsertFacFix(                        
                                     txt_model_nm.Text.ToString()
                                    , cmb_Staff_NM.SelectedValue.ToString()
                                    , txt_FixTime.Text.ToString()
                                    , gubun
                                    , cmb_facnm.SelectedValue.ToString()
                                    , txt_FixCust.Text.ToString()
                                    , txt_FixCost.Text.ToString()
                                    , txt_FixReport.Text.ToString()
                                    , dtp_fix_date.Text.ToString()
                                    
                                    );
                    if (rsNum == 0)
                    {
                        resetSetting();
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
                    if (!p_Isdel)
                    {
                        MessageBox.Show("권한이없습니다.");
                        return;
                    }
                    wnDm wDm = new wnDm();
                    int rsNum = wDm.UpdateFacFix(                        
                                     txt_model_nm.Text.ToString()
                                    , cmb_Staff_NM.SelectedValue.ToString()
                                    , txt_FixTime.Text.ToString()
                                    , gubun
                                    , cmb_facnm.SelectedValue.ToString()
                                    , txt_FixCust.Text.ToString()
                                    , txt_FixCost.Text.ToString()
                                    , txt_FixReport.Text.ToString()  
                                    , dtp_fix_date.Text.ToString()
                                    , int.Parse(txt_seq.Text.ToString())
                                    );
                    if (rsNum == 0)
                    {
                        MessageBox.Show("성공적으로 수정하였습니다.");
                    }
                    else if (rsNum == 1)
                        MessageBox.Show("저장에 실패하였습니다");
                    else
                        MessageBox.Show("Exception 에러");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void txt_FixTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComInfo.onlyNum(sender, e); 
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dgv_FacList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            cmb_facnm.SelectedValue = dgv_FacList.Rows[e.RowIndex].Cells["FAC_CD"].Value.ToString();
            txt_model_nm.Text = dgv_FacList.Rows[e.RowIndex].Cells["MODEL_NM"].Value.ToString();
            cmb_Staff_NM.SelectedValue = dgv_FacList.Rows[e.RowIndex].Cells["STAFF_CD"].Value.ToString();
            txt_FixTime.Text = dgv_FacList.Rows[e.RowIndex].Cells["FIX_TIME"].Value.ToString();
            txt_FixCust.Text = dgv_FacList.Rows[e.RowIndex].Cells["FIX_CUST"].Value.ToString();
            txt_FixCost.Text = dgv_FacList.Rows[e.RowIndex].Cells["FIX_COST"].Value.ToString();
            txt_FixReport.Text = dgv_FacList.Rows[e.RowIndex].Cells["FIX_REPORT"].Value.ToString();
            dtp_fix_date.Text = dgv_FacList.Rows[e.RowIndex].Cells["FIX_DATE"].Value.ToString();            
            txt_seq.Text = dgv_FacList.Rows[e.RowIndex].Cells["FIX_SEQ"].Value.ToString();
            txt_faccd.Text = dgv_FacList.Rows[e.RowIndex].Cells["FAC_CD"].Value.ToString();           

            if (dgv_FacList.Rows[e.RowIndex].Cells["FIX_GUBUN"].Value.ToString().Equals("1"))
            {
                radioButton1.Checked = true;
                radioButton2.Checked = false;
            }
            else if (dgv_FacList.Rows[e.RowIndex].Cells["FIX_GUBUN"].Value.ToString().Equals("2"))
            {
                radioButton1.Checked = false;
                radioButton2.Checked = true;
            }

            txt_model_nm.Enabled = false;

            btnDelete.Enabled = true;

         
           
        }

        private void radioButton2_Enter(object sender, EventArgs e)
        {

        }     
    }
}
