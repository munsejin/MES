using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MES.CLS;
using System.Diagnostics;
using System.Data.OleDb;
using System.Runtime.InteropServices;

namespace MES.P85_BAS
{
    public partial class frm거래처등록 : Form
    {
        private wnGConstant wConst = new wnGConstant();
        private ComInfo comInfo = new ComInfo();
        public static bool p_IsAuth = true;    // 열람권한
        public static bool p_Isrgstr = true;    //등록/수정 권한
        wnDm wnDm = new wnDm();
        public static bool p_Isdel = true;    // 삭제 권한
        public frm거래처등록()
        {
            InitializeComponent();
        }

        private void frm거래처등록_Load(object sender, EventArgs e)
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
            btnDelete.Enabled = false;
            init_ComboBox();
            cust_list();
        }

        #region common 
        private void btnNew_Click(object sender, EventArgs e)
        {
            resetSetting();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (p_Isrgstr)
            {
                cust_logic();

            }
            else
            {
                MessageBox.Show("권한이 없습니다.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (p_Isdel)
            {
                cust_del();

            }
            else
            {
                MessageBox.Show("권한이없습니다.");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void init_ComboBox()
        {
            string sqlQuery = "";
            //불량유형 시작
            cmb_cust_gbn.Items.Add("전체 검색");
            cmb_cust_gbn.Items.Add("매출처");
            cmb_cust_gbn.Items.Add("구매처");
            cmb_cust_gbn.SelectedIndex = 0;

            cmb_used.ValueMember = "코드";
            cmb_used.DisplayMember = "명칭";
            sqlQuery = comInfo.queryCustUsedYn();
            wConst.ComboBox_Read_NoBlank(cmb_used, sqlQuery);

            cmb_used_srch.ValueMember = "코드";
            cmb_used_srch.DisplayMember = "명칭";
            sqlQuery = comInfo.queryCustUsedYnAll();
            wConst.ComboBox_Read_NoBlank(cmb_used_srch, sqlQuery);

            cmb_manager.ValueMember = "코드";
            cmb_manager.DisplayMember = "명칭";
            sqlQuery = comInfo.queryStaff();
            wConst.ComboBox_Read_Blank(cmb_manager, sqlQuery);

            cmb_tax_cd.ValueMember = "코드";
            cmb_tax_cd.DisplayMember = "명칭";
            sqlQuery = comInfo.queryTax();
            wConst.ComboBox_Read_NoBlank(cmb_tax_cd, sqlQuery);

            cmb_type.ValueMember = "코드";
            cmb_type.DisplayMember = "명칭";
            sqlQuery = comInfo.queryUnitType("4");
            wConst.ComboBox_Read_Blank(cmb_type, sqlQuery);

        }

        private void resetSetting()
        {            
            lbl_cust_gbn.Text = "";
            btnDelete.Enabled = false;
            txt_cust_cd.Text = "";
            txt_cust_cd.Enabled = true;
            txt_cust_nm.Text = "";
            txt_owner.Text = "";
            txt_saup_no.Text = "";
            txt_uptae.Text = "";
            txt_jong.Text = "";
            cmb_type.SelectedIndex = 0;
            txt_post_no.Text = "";
            txt_addr.Text = "";
            txt_cust_manager.Text = "";
            txt_email.Text = "";
            txt_comp_phone.Text = "";
            txt_phone.Text = "";
            txt_fax.Text = "";
            cmb_manager.SelectedIndex = 0;
            cmb_used.SelectedIndex = 0;
            txt_comment.Text = "";
            cmb_tax_cd.SelectedIndex = 0;
            //cmb_raw_stor.SelectedIndex = 0;
            //cmb_cust.SelectedIndex = 0;
            txt_cust_cd.Focus();

            lbl중복확인.Text = "중복확인 은 필수입니다.";
            lbl중복확인.ForeColor = Color.Red;
        }

        #endregion common

        #region cust

        private void cust_logic() 
        {
            try
            {
                if (cmb_manager.SelectedValue == null) cmb_manager.SelectedValue = "";
                if (cmb_used.SelectedValue == null) cmb_used.SelectedValue = "";
                
                if (txt_cust_cd.Text.ToString().Equals("")) 
                {
                    MessageBox.Show("거래처코드를 입력하시기 바랍니다.");
                    return;
                }
                if (txt_cust_nm.Text.ToString().Equals("")) 
                {
                    MessageBox.Show("거래처명을 입력하시기 바랍니다.");
                    return;
                }

                if (cmb_manager.SelectedIndex ==0 || cmb_manager == null) 
                {
                    MessageBox.Show("담당자를 선택하시기 바랍니다.");
                    return;
                }

                string cust_gbn = ""; // 매출 1 , 매입 2
                if (radio_pur.Checked == true)
                {
                    cust_gbn = radio_pur.TabIndex.ToString();
                }
                else {
                    cust_gbn = radio_sales.TabIndex.ToString();
                }

                string typeTemp = "";

                if (cmb_type.SelectedValue != null && !cmb_type.SelectedValue.ToString().Equals(""))
                {
                    typeTemp = cmb_type.SelectedValue.ToString();
                }


                if (lbl_cust_gbn.Text != "1")
                {
                    wnDm wDm = new wnDm();
                    int rsNum = wDm.insertCust(
                                      txt_cust_cd.Text.ToString()
                                    , cust_gbn
                                    , txt_cust_nm.Text.ToString()
                                    , txt_owner.Text.ToString()
                                    , txt_saup_no.Text.ToString()
                                    , txt_uptae.Text.ToString()
                                    , txt_jong.Text.ToString()
                                    , typeTemp
                                    , txt_post_no.Text.ToString()
                                    , txt_addr.Text.ToString()
                                    , txt_cust_manager.Text.ToString()
                                    , txt_email.Text.ToString()
                                    , txt_comp_phone.Text.ToString()
                                    , txt_phone.Text.ToString()
                                    , txt_fax.Text.ToString()
                                    , txt_start_date.Text.ToString()
                                    , cmb_manager.SelectedValue.ToString()
                                    , cmb_used.SelectedValue.ToString()
                                    , txt_comment.Text.ToString()
                                    , cmb_tax_cd.SelectedValue.ToString());

                    if (rsNum == 0)
                    {
                        resetSetting();
                        cust_list();
                        MessageBox.Show("성공적으로 등록하였습니다.");
                    }
                    else if (rsNum == 1)
                        MessageBox.Show("저장에 실패하였습니다");
                    else if (rsNum == 2)
                        MessageBox.Show("SQL COMMAND 에러");
                    else if (rsNum == 3)
                        MessageBox.Show("기존 코드가 있으므로 \n 다른 코드로 입력 바랍니다.");
                    else if (rsNum == 5)
                        MessageBox.Show("장터지기 등록 에러.");
                    else
                        MessageBox.Show("Exception 에러1");
                }
                else 
                {
                    wnDm wDm = new wnDm();
                    int rsNum = wDm.updateCust(
                                      txt_cust_cd.Text.ToString()
                                    , cust_gbn
                                    , txt_cust_nm.Text.ToString()
                                    , txt_owner.Text.ToString()
                                    , txt_saup_no.Text.ToString()
                                    , txt_uptae.Text.ToString()
                                    , txt_jong.Text.ToString()
                                    , typeTemp
                                    , txt_post_no.Text.ToString()
                                    , txt_addr.Text.ToString()
                                    , txt_cust_manager.Text.ToString()
                                    , txt_email.Text.ToString()
                                    , txt_comp_phone.Text.ToString()
                                    , txt_phone.Text.ToString()
                                    , txt_fax.Text.ToString()
                                    , txt_start_date.Text.ToString()
                                    , cmb_manager.SelectedValue.ToString()
                                    , cmb_used.SelectedValue.ToString()
                                    , txt_comment.Text.ToString()
                                    , cmb_tax_cd.SelectedValue.ToString()
                                    );

                    if (rsNum == 0)
                    {
                        cust_list();
                        MessageBox.Show("성공적으로 수정하였습니다.");
                    }
                    else if (rsNum == 1)
                        MessageBox.Show("저장에 실패하였습니다");
                    else if (rsNum == 5)
                        MessageBox.Show("장터지기 수정 에러.");
                    else
                        MessageBox.Show("Exception 에러1");
                }
            }
            catch (Exception e) 
            {
                MessageBox.Show("시스템 오류");
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(e.Message + " - " + e.ToString());
                msg.ShowDialog();
            }
        }

        private void cust_list()
        {
            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = null;

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("where 1=1 ");

                if (cmb_used_srch.SelectedIndex > 0)
                {
                    sb.AppendLine("and USED_CD = '" + cmb_used_srch.SelectedValue.ToString() + "' ");
                }

                if (cmb_cust_gbn.SelectedIndex > 0)
                {
                    sb.AppendLine("and CUST_GUBUN = '" + cmb_cust_gbn.SelectedIndex.ToString() + "' ");
                }

                if (txt_srch.Text.ToString().Equals(""))
                {
                    dt = wDm.fn_Cust_List(sb.ToString());
                }
                else
                {
                    sb.AppendLine("and CUST_NM like '%" + txt_srch.Text.ToString() + "%' ");
                    dt = wDm.fn_Cust_List(sb.ToString());
                }

                cust_list_rs(dt);
            }
            catch (Exception e)
            {
                MessageBox.Show("시스템 오류: " + e.ToString());
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(e.Message + " - " + e.ToString());
                msg.ShowDialog();
            }
        }

        private void cust_list_rs(DataTable dt)
        {
            lbl_cnt.Text = dt.Rows.Count.ToString();

            if (dt != null && dt.Rows.Count > 0)
            {
                this.dataCustGrid.RowCount = dt.Rows.Count;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    
                    if(dt.Rows[i]["USED_NM"].ToString().Equals("중지")){
                        dataCustGrid.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                    }else if(dt.Rows[i]["USED_NM"].ToString().Equals("종료")){
                        dataCustGrid.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                    }
                    else if (dt.Rows[i]["USED_NM"].ToString().Equals("사용"))
                    {
                        dataCustGrid.Rows[i].DefaultCellStyle.BackColor = Color.Empty;
                    }

                    dataCustGrid.Rows[i].Cells[0].Value = dt.Rows[i]["CUST_GUBUN_NM"].ToString();
                    dataCustGrid.Rows[i].Cells[1].Value = dt.Rows[i]["CUST_CD"].ToString();
                    dataCustGrid.Rows[i].Cells[2].Value = dt.Rows[i]["CUST_NM"].ToString();
                    dataCustGrid.Rows[i].Cells[3].Value = dt.Rows[i]["JONGMOK"].ToString();
                    dataCustGrid.Rows[i].Cells[4].Value = dt.Rows[i]["USED_NM"].ToString();
                }
            }
            else
            {
                dataCustGrid.Rows.Clear();
            }
        }


        #endregion cust

        private void dataCustGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                btnDelete.Enabled = true;
                lbl_cust_gbn.Text = "1";
                txt_cust_cd.Enabled = false;

                try
                {
                    wnDm wDm = new wnDm();
                    DataTable dt = null;
                    //2019-10-31 이재원
                    //우측 리스트에서 구매처, 매출처가 동일한 코드일때 더블클릭시 매출처만 지정되는 오류 수정
                    string condition = "where cust_cd = '" + dataCustGrid.Rows[e.RowIndex].Cells[1].Value.ToString()
                        + "' and cust_gubun = '" + (dataCustGrid.Rows[e.RowIndex].Cells[0].Value.ToString().Equals("매출처") ? "1" : "2") + "'       ";

                    dt = wDm.fn_Cust_List(condition);

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["CUST_GUBUN"].ToString().Equals("1"))
                        { //매출
                            radio_sales.Checked = true;
                            radio_pur.Checked = false;
                        }
                        else
                        { //매입
                            radio_sales.Checked = false;
                            radio_pur.Checked = true;
                        }
                        txt_cust_cd.Text = dt.Rows[0]["CUST_CD"].ToString();
                        txt_cust_nm.Text = dt.Rows[0]["CUST_NM"].ToString();
                        txt_owner.Text = dt.Rows[0]["OWNER"].ToString();
                        txt_saup_no.Text = dt.Rows[0]["SAUP_NO"].ToString();
                        txt_uptae.Text = dt.Rows[0]["UPTAE"].ToString();
                        txt_jong.Text = dt.Rows[0]["JONGMOK"].ToString();
                        try
                        {
                            cmb_type.SelectedValue = dt.Rows[0]["DEAL_TYPE"].ToString();
                        }
                        catch (Exception ex2)
                        {
                            cmb_type.SelectedIndex = 0;
                        }
                        txt_post_no.Text = dt.Rows[0]["POST_NO"].ToString();
                        txt_addr.Text = dt.Rows[0]["ADDR"].ToString();
                        txt_cust_manager.Text = dt.Rows[0]["CUST_MANAGER"].ToString();
                        txt_email.Text = dt.Rows[0]["CUST_EMAIL"].ToString();
                        txt_comp_phone.Text = dt.Rows[0]["CUST_COMP_PHONE"].ToString();
                        txt_phone.Text = dt.Rows[0]["CUST_PHONE"].ToString();
                        cmb_manager.SelectedValue = dt.Rows[0]["STAFF_CD"].ToString();
                        cmb_used.SelectedValue = int.Parse(dt.Rows[0]["USED_CD"].ToString());
                        txt_comment.Text = dt.Rows[0]["COMMENT"].ToString();
                        cmb_tax_cd.SelectedValue = dt.Rows[0]["TAX_CD"].ToString();

                    }
                    else
                    {
                        dataCustGrid.Rows.Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("시스템 오류: " + ex.ToString());
                    Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                    msg.ShowDialog();
                }
            }
        }

        private void cust_del()
        {

            DataTable dt = new DataTable();
            wnDm wDm = new wnDm();

            dt = wDm.select_all_custCd(txt_cust_cd.Text.ToString());

            if (dt != null && dt.Rows.Count > 0)
            {
                MessageBox.Show("해당 거래처의 활동내역이 남아있어서 삭제할 수 없습니다.");
                return;
            }




            string cust_gbn = ""; // 매출 1 , 매입 2
            if (radio_pur.Checked == true)
            {
                cust_gbn = radio_pur.TabIndex.ToString();
            }
            else
            {
                cust_gbn = radio_sales.TabIndex.ToString();

            }
            int rsNum = wDm.deleteCust(txt_cust_cd.Text.ToString(), cust_gbn);
            if (rsNum == 0)
            {
                resetSetting();

                cust_list();
                MessageBox.Show("성공적으로 삭제하였습니다.");
            }
            else if (rsNum == 1)
            {
                MessageBox.Show("삭제에 실패하였습니다.");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            cust_list();
        }



        //비고다음 엔터는 저장에 포커스 
        private void txt_comment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave.Focus();
            }

            else
            {
                return;
            } 
        }

        private void txt_start_date_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}"); 
            }

            else
            {
                return;
            } 
        }

        private void txt_cust_cd_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComInfo.onlyNum(sender, e);
        }

        private void btn우편번호_Click(object sender, EventArgs e)
        {
            MES.Popup.pop우편번호검색 pop우편검색 = new MES.Popup.pop우편번호검색();
            pop우편검색.ShowDialog();
            Debug.WriteLine(pop우편검색.a + pop우편검색.b);

            txt_post_no.Text = pop우편검색.b;
            txt_addr.Text = pop우편검색.a;
        }

        private void btn중복확인_Click(object sender, EventArgs e)
        {
            if (lbl중복확인.Text == "")
            {
                MessageBox.Show("코드입력해주세요");
                return;
            }
            try
            {
                DataTable dt = wnDm.n테이블_등록_코드중복확인("N_CUST_CODE", "where CUST_CD='" + txt_cust_cd.Text + "'");

                if (dt.Rows[0][0].ToString() == "0")
                {
                    lbl중복확인.ForeColor = Color.Green;
                    lbl중복확인.Text = "중복확인 완료";
                }
                else
                {
                    lbl중복확인.ForeColor = Color.Red;
                    lbl중복확인.Text = "중복입니다.";

                }
            }
            catch
            {
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
                    // 단일키 사용시
                    btnNew.PerformClick();
                    break;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
            return true;
        }

        private void btn_Excel_Click(object sender, EventArgs e)
        {
            Popup.pop거래처엑셀입력 msg = new Popup.pop거래처엑셀입력();
            msg.ShowDialog();
        }

        
    }
}
