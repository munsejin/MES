using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MES.CLS;

namespace MES.P85_BAS
{
    public partial class frm원자재등록 : Form
    {
        private wnGConstant wConst = new wnGConstant();
        private ComInfo comInfo = new ComInfo();
        public static bool p_IsAuth = true;    // 열람권한
        public static bool p_Isrgstr = true;    //등록/수정 권한
        wnDm wnDm = new wnDm();
        public static bool p_Isdel = true;    // 삭제 권한
        private DataGridView del_cust = new DataGridView();
        private string cust_nm = "";



        public frm원자재등록()
        {
            InitializeComponent();
        }

        private void chk_manager_yn_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void frm원자재등록_Load(object sender, EventArgs e)
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

            if (Common.p_saupNo.Equals("2878800153"))
            {
                txt_raw_mat_nm.MaxLength = 50;
                txt_spec.MaxLength = 50;
                txt_comment.MaxLength = 50;
            }

            init_ComboBox();
            raw_list();
            chk_stock_yn.Checked = true;

            del_cust.Columns.Add("CUST_CD","CUST_CD");
            del_cust.Columns.Add("SEQ", "SEQ");
        }

        private void init_ComboBox()
        {
            ComInfo comInfo = new ComInfo();
            string sqlQuery = "";
            //불량유형 시작

            cmb_cd_srch.Items.Add("전체 검색");
            cmb_cd_srch.Items.Add("코드별 검색");
            cmb_cd_srch.Items.Add("이름별 검색");
            cmb_cd_srch.SelectedIndex = 0;

            cmb_type.ValueMember = "코드";
            cmb_type.DisplayMember = "명칭";
            sqlQuery = comInfo.queryType("and  L_CODE = '2' ");
            wConst.ComboBox_Read_Blank(cmb_type, sqlQuery);

            cmb_raw_mat_gbn.ValueMember = "코드";
            cmb_raw_mat_gbn.DisplayMember = "명칭";
            sqlQuery = comInfo.queryRawList();
            wConst.ComboBox_Read_NoBlank(cmb_raw_mat_gbn, sqlQuery);

            cmb_raw2.ValueMember = "코드";
            cmb_raw2.DisplayMember = "명칭";
            sqlQuery = comInfo.queryRawList();
            wConst.ComboBox_Read_NoBlank(cmb_raw2, sqlQuery);

            cmb_input_unit.ValueMember = "코드";
            cmb_input_unit.DisplayMember = "명칭";
            sqlQuery = comInfo.queryUnit();
            wConst.ComboBox_Read_Blank(cmb_input_unit, sqlQuery);

            cmb_output_unit.ValueMember = "코드";
            cmb_output_unit.DisplayMember = "명칭";
            wConst.ComboBox_Read_Blank(cmb_output_unit, sqlQuery);

            cmb_used.ValueMember = "코드";
            cmb_used.DisplayMember = "명칭";
            sqlQuery = comInfo.queryUsedYn();
            wConst.ComboBox_Read_NoBlank(cmb_used, sqlQuery);

            cmb_line.ValueMember = "코드";
            cmb_line.DisplayMember = "명칭";
            sqlQuery = comInfo.queryLine();
            wConst.ComboBox_Read_Blank(cmb_line, sqlQuery);

            cmb_cust.ValueMember = "코드";
            cmb_cust.DisplayMember = "명칭";
            sqlQuery = comInfo.queryCustUsed("2"); //구매처
            wConst.ComboBox_Read_Blank(cmb_cust, sqlQuery);

            cmb_raw_chk.ValueMember = "코드";
            cmb_raw_chk.DisplayMember = "명칭";
            sqlQuery = comInfo.queryCode("601"); //수입검사여부
            wConst.ComboBox_Read_Blank(cmb_raw_chk, sqlQuery);

            cmb_used_srch.ValueMember = "코드";
            cmb_used_srch.DisplayMember = "명칭";
            sqlQuery = comInfo.queryCustUsedYnAll(); //사용여부검색
            wConst.ComboBox_Read_NoBlank(cmb_used_srch, sqlQuery);

            cmb_raw_stor.ValueMember = "코드";
            cmb_raw_stor.DisplayMember = "명칭";
            sqlQuery = comInfo.queryStorage(); //창고
            wConst.ComboBox_Read_Blank(cmb_raw_stor, sqlQuery);

            cmb_tax_cd.ValueMember = "코드";
            cmb_tax_cd.DisplayMember = "명칭";
            sqlQuery = comInfo.queryVatAll(); //창고
            wConst.ComboBox_Read_NoBlank(cmb_tax_cd, sqlQuery);

            
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            resetSetting();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (p_Isrgstr)
            {
                raw_mat_logic();

            }
            else
            {
                MessageBox.Show("권한이 없습니다.");
            }
        }

        private void resetSetting() 
        {
            lbl_raw_mat_gbn.Text = "";
            btnDelete.Enabled = false;
            txt_raw_mat_cd.Text = "";
            txt_raw_mat_cd.Enabled = true;
            txt_raw_mat_nm.Text = "";
            txt_spec.Text = "";
            txt_quality.Text = "";
            cmb_raw_mat_gbn.SelectedIndex = 0;
            cmb_type.SelectedIndex = 0;
            cmb_input_unit.SelectedIndex = 0;
            cmb_output_unit.SelectedIndex = 0;
            txt_input_price.Text = "0";
            txt_output_price.Text = "0";
            txt_conver_ratio.Text = "0";
            cmb_line.SelectedIndex = 0;
            chk_stock_yn.Checked = true;
            txt_bal_stock.Text = "0";


            cmb_raw_chk.SelectedIndex = 0;
            txt_stock.Text = "0";
            txt_comment.Text = "";

            cmb_tax_cd.SelectedIndex = 0;
            //cmb_raw_stor.SelectedIndex = 0;
            cmb_cust.SelectedIndex = 0;
            txt_part_no.Text = "";

            lbl중복확인.Text = "중복확인 은 필수입니다.";
            lbl중복확인.ForeColor = Color.Red;

            dgv_cust.Rows.Clear();
            del_cust.Rows.Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (p_Isdel)
            {
                raw_del();

            }
            else
            {
                MessageBox.Show("권한이 없습니다.");
            }
        }

        private void raw_mat_logic() 
        {
            try
            {
                if (cmb_raw_mat_gbn.SelectedValue == null) cmb_raw_mat_gbn.SelectedValue = "";
                if (cmb_type.SelectedValue == null) cmb_type.SelectedValue = "";
                if (cmb_input_unit.SelectedValue == null) cmb_input_unit.SelectedValue = "";
                if (cmb_output_unit.SelectedValue == null) cmb_output_unit.SelectedValue = "";
                if (cmb_line.SelectedValue == null) cmb_line.SelectedValue = "";
                if (cmb_raw_stor.SelectedValue == null) cmb_raw_stor.SelectedValue = "";
                if (cmb_cust.SelectedValue == null) cmb_cust.SelectedValue = "";
                if (cmb_used.SelectedValue == null) cmb_used.SelectedValue = "";
                if (cmb_raw_chk.SelectedValue == null) cmb_raw_chk.SelectedValue = "";


                if (txt_raw_mat_cd.Text.ToString().Equals(""))
                {
                    MessageBox.Show("원자재코드를 입력하시기 바랍니다.");
                    return;
                }
                if (txt_raw_mat_nm.Text.ToString().Equals(""))
                {
                    MessageBox.Show("원자재명을 입력하시기 바랍니다.");
                    return;
                }
                if (cmb_input_unit.SelectedValue.ToString().Equals("")) 
                {
                    MessageBox.Show("입고단위를 입력하시기 바랍니다.");
                    return;
                }
                if (cmb_output_unit.SelectedValue.ToString().Equals("")) 
                {
                    MessageBox.Show("사용단위를 입력하시기 바랍니다. ");
                    return;
                }
                if (cmb_raw_chk.SelectedValue.ToString().Equals(""))
                {
                    MessageBox.Show("수입검사여부를 입력하시기 바랍니다. ");
                    return;
                }
                /*
                if (cmb_cust.SelectedValue.ToString().Equals(""))
                {
                    MessageBox.Show("구매처를 선택하시기 바랍니다. ");
                    return;
                }
                 */
                if (dgv_cust.Rows.Count > 0)
                {
                    /* 거래처 없으면 행 제거*/
                    for (int i = 0; i < dgv_cust.Rows.Count; i++)
                    {
                        if (dgv_cust.Rows[i].Cells["CUST_NAME"].Value == null || dgv_cust.Rows[i].Cells["CUST_NAME"].Value.ToString().Equals(""))
                        {
                            dgv_cust.Rows.Remove(dgv_cust.Rows[i]);
                        }
                    }
                    int chk = 0;
                    for (int i = 0; i < dgv_cust.Rows.Count; i++)
                    {

                        if (dgv_cust.Rows[i].Cells["CHK"].Value != null && (bool)dgv_cust.Rows[i].Cells["CHK"].Value)
                        {
                            chk = 1;
                        }
                    }
                    if (chk != 1)
                    {
                        MessageBox.Show("주 거래처를 선택해주세요.");
                        return;
                    }
                }
                
                string st_status_yn = comInfo.resultYn(chk_stock_yn);

                if (lbl_raw_mat_gbn.Text != "1")
                {
                    wnDm wDm = new wnDm();
                    int rsNum = wDm.insertRawMat(
                                      txt_raw_mat_cd.Text.ToString()
                                    , txt_raw_mat_nm.Text.ToString()
                                    , txt_spec.Text.ToString()
                                    , txt_quality.Text.ToString()
                                    , cmb_raw_mat_gbn.SelectedValue.ToString()
                                    , cmb_type.SelectedValue.ToString()
                                    , cmb_input_unit.SelectedValue.ToString()
                                    , cmb_output_unit.SelectedValue.ToString()
                                    , double.Parse(txt_conver_ratio.Text.ToString().Replace(",",""))
                                    , double.Parse(txt_input_price.Text.ToString().Replace(",", ""))
                                    , double.Parse(txt_output_price.Text.ToString().Replace(",", ""))
                                    , cmb_line.SelectedValue.ToString()
                                    , st_status_yn
                                    , txt_stock.Text.ToString()
                                    , cmb_used.SelectedValue.ToString()
                                    , cmb_cust.SelectedValue.ToString()
                                    , cmb_raw_chk.SelectedValue.ToString()
                                    , txt_part_no.Text.ToString()
                                    , txt_comment.Text.ToString()
                                    , cmb_raw_stor.SelectedValue.ToString()
                                    , cmb_tax_cd.SelectedValue.ToString()
                                    , dgv_cust );

                    if (rsNum == 0)
                    {
                        resetSetting();
                        raw_list();
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
                    int rsNum = wDm.updateRawMat(
                                      txt_raw_mat_cd.Text.ToString()
                                    , txt_raw_mat_nm.Text.ToString()
                                    , txt_spec.Text.ToString()
                                    , txt_quality.Text.ToString()
                                    , cmb_raw_mat_gbn.SelectedValue.ToString()
                                    , cmb_type.SelectedValue.ToString()
                                    , cmb_input_unit.SelectedValue.ToString()
                                    , cmb_output_unit.SelectedValue.ToString()
                                    , double.Parse(txt_conver_ratio.Text.ToString().Replace(",", ""))
                                    , double.Parse(txt_input_price.Text.ToString().Replace(",", ""))
                                    , double.Parse(txt_output_price.Text.ToString().Replace(",", ""))
                                    , cmb_line.SelectedValue.ToString()
                                    , st_status_yn
                                    , txt_stock.Text.ToString()
                                    , cmb_used.SelectedValue.ToString()
                                    , cmb_cust.SelectedValue.ToString()
                                    , cmb_raw_chk.SelectedValue.ToString()
                                    , txt_part_no.Text.ToString()
                                    , txt_comment.Text.ToString()
                                    , cmb_raw_stor.SelectedValue.ToString()
                                    , cmb_tax_cd.SelectedValue.ToString()
                                    , dgv_cust
                                    , del_cust 
                                    );

                    if (rsNum == 0)
                    {
                        raw_list();
                        del_cust.Rows.Clear();
                        MessageBox.Show("성공적으로 수정하였습니다.");
                    }
                    else if (rsNum == 1)
                        MessageBox.Show("저장에 실패하였습니다");
                    else
                        MessageBox.Show("Exception 에러");

                }
            }
            catch (Exception e) {
                MessageBox.Show(e.ToString());
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(e.Message + " - " + e.ToString());
                msg.ShowDialog();
            }
        }

        private void raw_list()
        {
            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = null;
                dt = wDm.fn_Raw_List("","1");

                raw_list_rs(dataRawCdGrid,dt,lbl_cnt);
            }
            catch (Exception e)
            {

            }
        }

        private void dataRawCdGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            raw_detail_logic(dataRawCdGrid, e);
        }

        private void raw_list_rs(DataGridView dg, DataTable dt,Label lbl_cnt) 
        {
            if (dt != null && dt.Rows.Count > 0)
            {
                lbl_cnt.Text = dt.Rows.Count.ToString();
                dg.RowCount = dt.Rows.Count;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["USED_CD"].ToString().Equals("2"))
                    {
                        dg.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                    }
                    else if (dt.Rows[i]["USED_CD"].ToString().Equals("3"))
                    {
                        dg.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                    }
                    else if (dt.Rows[i]["USED_CD"].ToString().Equals("1"))
                    {
                        dg.Rows[i].DefaultCellStyle.BackColor = Color.Empty;
                    }

                    dg.Rows[i].Cells[0].Value = dt.Rows[i]["RAW_MAT_CD"].ToString();
                    dg.Rows[i].Cells[1].Value = dt.Rows[i]["RAW_MAT_NM"].ToString();
                    dg.Rows[i].Cells[2].Value = dt.Rows[i]["SPEC"].ToString();
                    dg.Rows[i].Cells[3].Value = dt.Rows[i]["COMMENT"].ToString();
                }
            }
            else
            {
                dg.Rows.Clear();
            }
        }
        private void raw_del() 
        {

            wnDm wDm = new wnDm();
            DataTable dt = wDm.select_all_rawCd(txt_raw_mat_cd.Text.ToString());

            if (dt != null && dt.Rows.Count > 0)
            {
                MessageBox.Show("해당 자재의 사용내역이 남아있어서 삭제할 수 없습니다.");
                return;
            }

            ComInfo comInfo = new ComInfo();
            DialogResult msgOk = comInfo.deleteConfrim("원자재", txt_raw_mat_nm.Text.ToString());

            if (msgOk == DialogResult.No)
            {
                return;

            }
            int rsNum = wDm.deleteRaw(txt_raw_mat_cd.Text.ToString());
            if (rsNum == 0)
            {
                resetSetting();

                raw_list();
                MessageBox.Show("성공적으로 삭제하였습니다.");
            }
            else if (rsNum == 1)
            {
                MessageBox.Show("삭제에 실패하였습니다.");
            }
        }
        private void txt_conver_ratio_TextChanged(object sender, EventArgs e)
        {
            if (txt_conver_ratio.Text.ToString().Equals("")) {
                txt_conver_ratio.Text = "0";
            }
        }

        private void txt_output_price_TextChanged(object sender, EventArgs e)
        {
            if (txt_output_price.Text.ToString().Equals(""))
            {
                txt_output_price.Text = "0";
            }
        }

        private void txt_input_price_TextChanged(object sender, EventArgs e)
        {
            if (txt_input_price.Text.ToString().Equals(""))
            {
                txt_input_price.Text = "0";
            }
        }

        private void txt_output_price_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComInfo.onlyNum(sender, e);
        }

        private void txt_input_price_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComInfo.onlyNum(sender, e);
        }

        private void txt_conver_ratio_KeyPress(object sender, KeyPressEventArgs e)
        {
           // ComInfo.onlyNum(sender, e);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            wnDm wDm = new wnDm();
            DataTable dt = null;
            if (cmb_cd_srch.SelectedIndex == 0) 
            {
                
                if (cmb_used_srch.SelectedIndex == 0)
                {
                    dt = wDm.fn_Raw_List(" WHERE RAW_MAT_CD like '%" + txt_srch.Text.ToString() + "%' or RAW_MAT_NM like '%" + txt_srch.Text.ToString() + "%' ", "1");
                }
                else if (cmb_used_srch.SelectedIndex == 1)
                {
                    dt = wDm.fn_Raw_List(" where USED_CD = 1 and (RAW_MAT_CD like '%" + txt_srch.Text.ToString() + "%' or RAW_MAT_NM like '%" + txt_srch.Text.ToString() + "%') ", "1");
                }
                else if (cmb_used_srch.SelectedIndex == 2)
                {
                    dt = wDm.fn_Raw_List(" where USED_CD = 2 and (RAW_MAT_CD like '%" + txt_srch.Text.ToString() + "%' or RAW_MAT_NM like '%" + txt_srch.Text.ToString() + "%') ", "1");
                }
                else if (cmb_used_srch.SelectedIndex == 3)
                {
                    dt = wDm.fn_Raw_List(" where USED_CD = 3 and (RAW_MAT_CD like '%" + txt_srch.Text.ToString() + "%' or RAW_MAT_NM like '%" + txt_srch.Text.ToString() + "%') ", "1");
                }
            }
            else if (cmb_cd_srch.SelectedIndex == 1)
            {
                if (txt_srch.Text.ToString().Equals("")) 
                {
                    MessageBox.Show("코드명을 입력하시기 바랍니다.");
                    return;
                }
                if (cmb_used_srch.SelectedIndex == 0)
                {
                    dt = wDm.fn_Raw_List("where RAW_MAT_CD like '%" + txt_srch.Text.ToString() + "%' ", "1");
                }
                else if (cmb_used_srch.SelectedIndex == 1) {
                    dt = wDm.fn_Raw_List("where RAW_MAT_CD like '%" + txt_srch.Text.ToString() + "%' AND USED_CD = 1 ", "1");
                }
                else if (cmb_used_srch.SelectedIndex == 2)
                {
                    dt = wDm.fn_Raw_List("where RAW_MAT_CD like '%" + txt_srch.Text.ToString() + "%' AND USED_CD = 2 ", "1");
                }
                else if (cmb_used_srch.SelectedIndex == 3)
                {
                    dt = wDm.fn_Raw_List("where RAW_MAT_CD like '%" + txt_srch.Text.ToString() + "%' AND USED_CD = 3 ", "1");
                }
                //dt = wDm.fn_Raw_List("where RAW_MAT_CD like '%" + txt_srch.Text.ToString() + "%' ");
            }
            else
            {
                if (txt_srch.Text.ToString().Equals(""))
                {
                    MessageBox.Show("원자재명을 입력하시기 바랍니다.");
                    return;
                }

                if (cmb_used_srch.SelectedIndex == 0)
                {
                    dt = wDm.fn_Raw_List("where RAW_MAT_NM like '%" + txt_srch.Text.ToString() + "%' ", "1");
                }
                else if (cmb_used_srch.SelectedIndex == 1)
                {
                    dt = wDm.fn_Raw_List("where RAW_MAT_NM like '%" + txt_srch.Text.ToString() + "%' AND USED_CD = 1 ", "1");
                }
                else if (cmb_used_srch.SelectedIndex == 2)
                {
                    dt = wDm.fn_Raw_List("where RAW_MAT_NM like '%" + txt_srch.Text.ToString() + "%' AND USED_CD = 2 ", "1");
                }
                else if (cmb_used_srch.SelectedIndex == 3)
                {
                    dt = wDm.fn_Raw_List("where RAW_MAT_NM like '%" + txt_srch.Text.ToString() + "%' AND USED_CD = 3 ", "1");
                }
                
            }
             raw_list_rs(dataRawCdGrid, dt,lbl_cnt);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSearch2_Click(object sender, EventArgs e)
        {
            wnDm wDm = new wnDm();
            DataTable dt = null;

            dt = wDm.fn_Raw_List("where RAW_MAT_GUBUN = '" + cmb_raw2.SelectedValue.ToString() + "' ", "1");

            raw_list_rs(dataRawCdGrid2, dt,lbl_cnt2);
        }

        private void dataRawCdGrid2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            raw_detail_logic(dataRawCdGrid2, e);
        }

        private void raw_detail_logic(DataGridView dg, DataGridViewCellEventArgs e) 
        {
            btnDelete.Enabled = true;
            lbl_raw_mat_gbn.Text = "1";
            txt_raw_mat_cd.Enabled = false;

            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = null;
                string condition = "where a.raw_mat_cd = '" + dg.Rows[e.RowIndex].Cells[0].Value.ToString() + "'";
                dt = wDm.fn_Raw_List(condition, "1");

                if (dt != null && dt.Rows.Count > 0)
                {

                    txt_raw_mat_cd.Text = dt.Rows[0]["RAW_MAT_CD"].ToString();
                    txt_raw_mat_nm.Text = dt.Rows[0]["RAW_MAT_NM"].ToString();
                    txt_spec.Text = dt.Rows[0]["SPEC"].ToString();
                    txt_quality.Text = dt.Rows[0]["EX_STAN_QUALITY"].ToString();
                    cmb_raw_mat_gbn.SelectedValue = dt.Rows[0]["RAW_MAT_GUBUN"].ToString();
                    cmb_type.SelectedValue = dt.Rows[0]["TYPE_CD"].ToString();
                    cmb_input_unit.SelectedValue = dt.Rows[0]["INPUT_UNIT"].ToString();
                    cmb_output_unit.SelectedValue = dt.Rows[0]["OUTPUT_UNIT"].ToString();
                    txt_input_price.Text = (decimal.Parse(dt.Rows[0]["INPUT_PRICE"].ToString())).ToString("#,0.######");
                    txt_output_price.Text = (decimal.Parse(dt.Rows[0]["OUTPUT_PRICE"].ToString())).ToString("#,0.######");
                    txt_conver_ratio.Text = (decimal.Parse(dt.Rows[0]["CVR_RATIO"].ToString())).ToString("#,0.######");


                    txt_bal_stock.Text = decimal.Parse(dt.Rows[0]["BAL_STOCK"].ToString()).ToString("#,0.######") + dt.Rows[0]["INPUT_UNIT_NM"].ToString();


                    cmb_line.SelectedValue = dt.Rows[0]["LINE_CD"].ToString();
                    txt_comment.Text = dt.Rows[0]["COMMENT"].ToString();
                    cmb_used.SelectedValue = dt.Rows[0]["USED_CD"].ToString();
                    cmb_cust.SelectedValue = dt.Rows[0]["CUST_CD"].ToString();
                    cmb_raw_chk.SelectedValue = dt.Rows[0]["CHECK_GUBUN"].ToString();
                    txt_part_no.Text = dt.Rows[0]["PART_NO"].ToString();
                    cmb_raw_stor.SelectedValue = dt.Rows[0]["RAW_STORAGE"].ToString();
                    cmb_tax_cd.SelectedValue = dt.Rows[0]["TAX_CD"].ToString();
                    int count = cmb_raw_stor.Items.Count;
                    
                    //공정체크 
                    if (dt.Rows[0]["ST_STATUS_YN"].ToString().Equals("Y"))
                        chk_stock_yn.Checked = true;
                    else
                        chk_stock_yn.Checked = false;

                    /*거래처*/
                    dt = wDm.fn_Raw_Cust_List("WHERE A.RAW_MAT_CD = '" + dg.Rows[e.RowIndex].Cells[0].Value.ToString() + "'");
                    dgv_cust.Rows.Clear();
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            dgv_cust.Rows.Add();
                            dgv_cust.Rows[i].Cells["CUST_CD"].Value = dt.Rows[i]["CUST_CD"].ToString();
                            dgv_cust.Rows[i].Cells["CUST_NAME"].Value = dt.Rows[i]["CUST_NM"].ToString();
                            dgv_cust.Rows[i].Cells["COMMENT"].Value = dt.Rows[i]["COMMENT"].ToString();
                            dgv_cust.Rows[i].Cells["SEQ"].Value = dt.Rows[i]["SEQ"].ToString();
                            if (dt.Rows[i]["MAIN_YN"].ToString().Equals("Y"))
                                dgv_cust.Rows[i].Cells["CHK"].Value = true;
                            else
                                dgv_cust.Rows[i].Cells["CHK"].Value = false;
                        }
                    }

                    dt = wDm.fn_item_CompList_SearchByRaw("WHERE A.RAW_MAT_CD = '" + dg.Rows[e.RowIndex].Cells[0].Value.ToString() + "'");
                    CompGrid.Rows.Clear();
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        CompGrid.RowCount = dt.Rows.Count;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            CompGrid.Rows[i].Cells["제품코드"].Value = dt.Rows[i]["ITEM_CD"].ToString();
                            CompGrid.Rows[i].Cells["제품명"].Value = dt.Rows[i]["ITEM_NM"].ToString();
                            CompGrid.Rows[i].Cells["규격"].Value = dt.Rows[i]["SPEC"].ToString();
                            CompGrid.Rows[i].Cells["소요량"].Value = decimal.Parse(dt.Rows[i]["TOTAL_AMT"].ToString()).ToString("#,0.######");
                            CompGrid.Rows[i].Cells["단위"].Value = dt.Rows[i]["UNIT_NM"].ToString();
                        }
                    }


                    
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void cmb_input_unit_SelectedIndexChanged(object sender, EventArgs e)
        {
           u_change_logic();
        }

        private void cmb_output_unit_SelectedIndexChanged(object sender, EventArgs e)
        {
            u_change_logic();
        }

        private void u_change_logic() 
        {
            if (((string)cmb_output_unit.SelectedValue == "" || cmb_output_unit.SelectedValue == null) || (string)cmb_input_unit.SelectedValue == "" || cmb_input_unit.SelectedValue == null)
            {
                txt_conver_ratio.Text = "0";
            }
            else 
            {
                string out_unit = cmb_output_unit.SelectedValue.ToString().ToLower();
                string in_unit = cmb_input_unit.SelectedValue.ToString().ToLower();
                string out_unit_nm = cmb_output_unit.Text.ToLower();
                string in_unit_nm = cmb_input_unit.Text.ToLower();

                if (cmb_input_unit.SelectedValue.ToString().Equals(cmb_output_unit.SelectedValue.ToString()))
                {
                    txt_conver_ratio.Text = "1";
                }
                else
                {
                    if (in_unit_nm.ToString().Equals("kg") && out_unit_nm.ToString().Equals("g"))
                    {
                        txt_conver_ratio.Text = "0.001";
                    }
                    else if (in_unit_nm.ToString().Equals("g") && out_unit_nm.ToString().Equals("kg"))
                    {
                        txt_conver_ratio.Text = "1,000"; 
                    }
                    else if (in_unit_nm.ToString().Equals("l") && out_unit_nm.ToString().Equals("ml"))
                    {
                        txt_conver_ratio.Text = "0.001";
                    }
                    else if (in_unit_nm.ToString().Equals("ml") && out_unit_nm.ToString().Equals("l"))
                    {
                        txt_conver_ratio.Text = "1,000";
                    }
                    else
                    {
                        txt_conver_ratio.Text = "1";
                    }
                }
            }
        }

        private void btn_Cust_Click(object sender, EventArgs e)
        {
            Popup.pop거래처검색 frm = new Popup.pop거래처검색();

            frm.sCustGbn = "2";
            frm.ShowDialog();

            if (frm.sCode != "")
            {
                cmb_cust.SelectedValue = frm.sCode.Trim();
            }
            else
            {
               // txt_cust_cd.Text = old_cust_nm;
            }

            frm.Dispose();
            frm = null;

            cmb_used.Focus();
        }

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

        private void btn환산단위설명_Click(object sender, EventArgs e)
        {
            MessageBox.Show("입고단위 / 출고단위 " + "\n" + "ex) 입고단위 1m=100cm 출고단위 1cm  환산단위 0.01\n   입고단위 1BOX = 25EA 출고단위 1EA 환산단위 0.04 \n !!환산 단위는 유한소수여야합니다. ");
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
                DataTable dt = wnDm.n테이블_등록_코드중복확인("N_RAW_CODE", "where RAW_MAT_CD='" + txt_raw_mat_cd .Text+ "'");

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

        private void btn_flow_plus_Click(object sender, EventArgs e)
        {
            dgv_cust.Rows.Add();
            dgv_cust.Rows[dgv_cust.Rows.Count - 1].Cells["COMMENT"].Value = "";
        }

        private void btn_flow_minus_Click(object sender, EventArgs e)
        {
            minus_logic(dgv_cust);
        }

        private void minus_logic(DataGridView dgv)
        {
            if (dgv.Rows.Count > 1)
            {

                if ((string)dgv.SelectedRows[0].Cells["SEQ"].Value != "" && dgv.SelectedRows[0].Cells["SEQ"].Value != null)
                {
                    del_cust.Rows.Add();

                    del_cust.Rows[del_cust.Rows.Count - 1].Cells["CUST_CD"].Value = dgv.SelectedRows[0].Cells["CUST_CD"].Value;
                    del_cust.Rows[del_cust.Rows.Count - 1].Cells["SEQ"].Value = dgv.SelectedRows[0].Cells["SEQ"].Value;
                }
                
               
                dgv.Rows.RemoveAt(dgv.SelectedRows[0].Index);
                dgv.CurrentCell = dgv[2, dgv.Rows.Count - 1];
            }
            else
            {
                MessageBox.Show("마지막 행은 삭제할 수 없습니다.");
            }
        }

        private void dgv_cust_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                for (int i = 0; i < dgv_cust.Rows.Count; i++)
                {
                    dgv_cust.Rows[i].Cells["CHK"].Value = false;
                }
                dgv_cust.Rows[e.RowIndex].Cells["CHK"].Value = true;
            }
        }

     

        private void CustSrchRsLogic(DataGridView grd, DataGridViewCellEventArgs e)
        {
            Popup.pop거래처검색 frm = new Popup.pop거래처검색();

            frm.sCustGbn = "2";
            frm.sCustNm = cust_nm;
            frm.ShowDialog();

            if (frm.sCode != "")
            {
                // txt_cust_cd.Text = frm.sCode.Trim();
                grd.SelectedRows[0].Cells["CUST_CD"].Value = frm.sCode.Trim();
                grd.SelectedRows[0].Cells["CUST_NAME"].Value = frm.sName.Trim();
            }
            else
            {
                // txt_cust_cd.Text = old_cust_nm;
            }

            frm.Dispose();
            frm = null;
        }

        private void dgv_cust_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                CustSrchRsLogic(dgv_cust, e);
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

        private void dgv_cust_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex == 3)
            {
                CustSrchRsLogic(dgv_cust, e);
            }
        }

        private void btn_Excel_Click(object sender, EventArgs e)
        {
            Popup.pop원자재엑셀입력 msg = new Popup.pop원자재엑셀입력();
            msg.ShowDialog();
        }

    }
}
