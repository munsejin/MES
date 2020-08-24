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

namespace MES.P50_QUA
{
    public partial class frm거래처관리 : Form
    {
        private wnGConstant wConst = new wnGConstant();
        private ComInfo comInfo = new ComInfo();
        public static bool p_IsAuth = true;    // 열람권한
        public static bool p_Isrgstr = true;    //등록/수정 권한
        wnDm wnDm = new wnDm();
        public static bool p_Isdel = true;    // 삭제 권한

        public frm거래처관리()
        {
            InitializeComponent();
        }

        private void frm거래처관리_Load(object sender, EventArgs e)
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
            txt_deal_type.Text = "";
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

                if (cmb_manager.SelectedIndex == 0 || cmb_manager == null)
                {
                    MessageBox.Show("담당자를 선택하시기 바랍니다.");
                    return;
                }

                string cust_gbn = "3"; // 매출 1 , 매입 2 , 외주 3
               
                

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
                                    , txt_deal_type.Text.ToString()
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
                                    , txt_deal_type.Text.ToString()
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

                    if (dt.Rows[i]["USED_NM"].ToString().Equals("중지"))
                    {
                        dataCustGrid.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                    }
                    else if (dt.Rows[i]["USED_NM"].ToString().Equals("종료"))
                    {
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




    }
}
