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
using MES.Popup;
using System.Data.SqlClient;

namespace MES.P50_QUA
{
    public partial class frm원자재수입검사 : Form
    {
        private wnGConstant wConst = new wnGConstant();
        private ComInfo comInfo = new ComInfo();
        private int p_type_idx = 0;
        private int p_num = 0;

        private int MouseClickIdx = -1;
        private int MouseClickRow = -1;
        private int MouseClickCol = -1;
        public Popup.frmPrint frmPrt;
        Popup.frmPrint readyPrt = new Popup.frmPrint();
        public int pop_chk = 0; // 원자재입고페이지에서 넘어온 경우만 체크


        private DataTable del_grd = new DataTable();

        public frm원자재수입검사()
        {
            InitializeComponent();
        }
        public static bool p_IsAuth = true;    // 열람권한
        public static bool p_Isrgstr = true;    //등록/수정 권한
        wnDm wnDm = new wnDm();
        public static bool p_Isdel = true;    // 삭제 권한
        private void frm원자재수입검사_Load(object sender, EventArgs e)
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
                        MessageBox.Show("권한이없습니다.");
                    }

                }
                catch (Exception ex)
                {
                }
            }

         



            start_date.Text = DateTime.Today.AddMonths(-1).ToString("yyyy-MM-dd");
            init_ComboBox();
            chk_req_list();
            if (pop_chk == 1)
            {
                dataChkGrid_Row_Add();
            }
            else if (pop_chk == 0)
            {
                ResetSetting();
            }


            //del_grd.Columns.Clear();

            if (del_grd.Columns.Count == 0)
            {
                del_grd.Columns.Add("INPUT_DATE");
                del_grd.Columns.Add("INPUT_CD");
                del_grd.Columns.Add("INPUT_SEQ");
                del_grd.Columns.Add("SEQ");
            }

           

            omitChkList.Columns[1].Visible = true;
            omitChkList.Columns[2].Visible = true;
            omitChkList.Columns[3].Visible = true;
            omitChkList.Columns[4].Visible = true;
            omitChkList.Columns[6].Visible = true;



        }

        private void ResetSetting() 
        {
            txt_raw_mat_nm.Text = "";
            txt_cust_nm.Text = "";
            txt_input_amt.Text = "";
            txt_input_date.Text = "";
            txt_input_cd.Text = "";
            txt_input_seq.Text = "";
            dataChkGrid.Rows.Clear();
            lbl_input_gubun.Text = "";
            chk_req_list();
            chk_complete_list();
            chk_omit_list();
            del_grd.Columns.Clear();
        }
        private void init_ComboBox()
        {
            string sqlQuery = "";

            //cmb_raw.ValueMember = "코드";
            //cmb_raw.DisplayMember = "명칭";
            //sqlQuery = comInfo.queryRaw();
            //wConst.ComboBox_Read_Blank(cmb_raw, sqlQuery);

            //cmb_raw.ValueMember = "코드";
            //cmb_raw.DisplayMember = "명칭";
            //sqlQuery = comInfo.queryRaw();
            //wConst.ComboBox_Read_Blank(cmb_raw, sqlQuery);

            //cmb_cust.ValueMember = "코드";
            //cmb_cust.DisplayMember = "명칭";
            //sqlQuery = comInfo.queryCust("2");
            //wConst.ComboBox_Read_Blank(cmb_cust, sqlQuery);

            //cmb_raw_pass.ValueMember = "코드";
            //cmb_raw_pass.DisplayMember = "명칭";
            //sqlQuery = comInfo.queryChkPass();
            //wConst.ComboBox_Read_Blank(cmb_raw_pass, sqlQuery);

        }
        #region button logic 
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            
            bool isRow = false;
            for (int i = 0; i < dataChkGrid.Rows.Count; i++)
            {
                if (dataChkGrid.Rows[i].Cells[1].Tag == null) continue;
                else { isRow = true; break; }
            }
            if (!isRow)
            {
                MessageBox.Show("최소 하나이상의 검사를 등록하여 주십시오.\n검사 생략을 원할 시 생략버튼을 눌러주세요.");
                return;
            }
           
            saveLogic();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_plus_Click(object sender, EventArgs e)
        {
            //rawPoorGrid.Rows.Add();

            //rawPoorGrid.Rows[rawPoorGrid.Rows.Count - 1].Cells["PRI_NON_PASS_AMT"].Value = 0;
            //rawPoorGrid.Rows[rawPoorGrid.Rows.Count - 1].Cells["UPD_PASS_AMT"].Value = 0;
        }

        private void btn_minus_Click(object sender, EventArgs e)
        {

        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            //if (txt_check_yn.Text.ToString().Equals("N")) //미완료
            //{
            //    cmb_raw_pass.SelectedValue = "";
            //    lbl_pass_raw.Text = txt_raw_mat_nm.Text.ToString();
            //    lbl_pass_spec.Text = txt_spec.Text.ToString();
            //    lbl_pass_cust.Text = txt_cust_nm.Text.ToString();
            //    tlp_raw.Visible = true;
            //}
            //else if (txt_check_yn.Text.ToString().Equals("Y")) //완료
            //    MessageBox.Show("이미 공정검사가 완료되었습니다. ");
            //else if (txt_check_yn.Text.ToString().Equals("S")) //대기
            //    MessageBox.Show("공정검사가 등록되지 않아 먼저 등록하시기 바랍니다.");
            //else if (txt_check_yn.Text.ToString().Equals("O")) //생략 
            //    MessageBox.Show("생략된 공정검사는 검사완료 할 수 없습니다.");
            //else
            //    MessageBox.Show("데이터가 존재하지 않습니다. ");
        }

        private void btn_pass_Click(object sender, EventArgs e)
        {
            //if (!txt_chk_date.Text.ToString().Equals("")) 
            //{
            //    if (txt_check_yn.Text.ToString().Equals("N")) 
            //    {
            //        if (cmb_raw_pass.SelectedValue == null) cmb_raw_pass.SelectedValue = "";

            //        if ((string)cmb_raw_pass.SelectedValue == "")
            //        {
            //            MessageBox.Show("검사결과를 선택하시기 바랍니다.");
            //            return;
            //        }

            //        wnDm wDm = new wnDm();
            //        int rsNum = wDm.updateRawChkPass(txt_input_date.Text.ToString()
            //                                          , txt_input_cd.Text.ToString()
            //                                          , txt_seq.Text.ToString()
            //                                          , cmb_raw_pass.SelectedValue.ToString()
            //                                          , decimal.Parse(final_pass_amt.Text.ToString().Replace(",","")));
            //        if (rsNum == 0)
            //        {
            //            chk_req_list();
            //            chk_complete_list();

            //            txt_check_nm.Text = "완료";
            //            txt_check_yn.Text = "Y";
            //            MessageBox.Show("검사가 완료되었습니다.");
            //        }
            //        else if (rsNum == 1)
            //            MessageBox.Show("저장에 실패하였습니다");
            //        else
            //            MessageBox.Show("Exception 에러2");
            //        tlp_raw.Visible = false;
            //    }
            //}   
        }

        private void btn_pass_close_Click(object sender, EventArgs e)
        {
            //tlp_raw.Visible = false;
        }

        #endregion button logic

        #region logic 

        private void saveLogic()
        {
            try
            {
                wnDm wDm = new wnDm();

                if (lbl_input_gubun.Text.ToString().Equals("S"))
                { //검사대기
                   
                        Popup.pop수입검사결과 msg = new Popup.pop수입검사결과();
                        msg.chk_amt.Text = txt_input_amt.Text.ToString();

                        msg.ShowDialog();
                    

                    if (msg.pass_yn == null || msg.pass_yn.ToString().Equals(""))
                    {
                        return;
                    }
                   
                    /*원자재입고페이지에서 켰을 시*/
                    if (pop_chk == 1 )
                    {
                        txt_pass_amt.Text = msg.s_pass_amt;
                        txt_non_pass_amt.Text = msg.s_non_pass_amt;
                        txt_pass_yn.Text = msg.pass_yn;
                        pop_chk = 2; //검사완료표시
                        //lbl_input_gubun.Text = "Y";

                        this.Close();
                        return;
                    }
                    if (pop_chk == 2)
                    {
                        txt_pass_amt.Text = msg.s_pass_amt;
                        txt_non_pass_amt.Text = msg.s_non_pass_amt;
                        txt_pass_yn.Text = msg.pass_yn;
                       

                        this.Close();
                        return;
                    }
                    else if (pop_chk ==0)
                    {
                    
                    
                    
                    int rsNum = wDm.Insert_raw_chk(
                        txt_input_date.Text
                        , txt_input_cd.Text
                        , txt_input_seq.Text
                        , txt_input_amt.Text
                        , msg.s_ChkDate
                        , msg.s_pass_amt
                        , msg.s_non_pass_amt
                        , msg.pass_yn
                        , dataChkGrid
                        );

                    if (rsNum == 0)
                    {
                        MessageBox.Show("성공적으로 등록하였습니다");
                      
                        ResetSetting();
                    }
                    else if (rsNum == 1)
                    {
                        MessageBox.Show("저장에 실패하였습니다");
                        return;
                    }
                    else
                    {
                        MessageBox.Show("sql Exception 오류");
                    }

                    }

                }
                else if (lbl_input_gubun.Text.ToString().Equals("Y") || lbl_input_gubun.Text.ToString().Equals("P"))
                { //완료된 검사 수정
                    Popup.pop수입검사결과 msg = new Popup.pop수입검사결과();
                    msg.chk_amt.Text = txt_input_amt.Text.ToString();

                    msg.ShowDialog();

                    if (msg.pass_yn == null || msg.pass_yn.ToString().Equals(""))
                    {
                        return;
                    }


                    int rsNum = wDm.Update_raw_chk(
                        txt_input_date.Text
                        , txt_input_cd.Text
                        , txt_input_seq.Text
                        , txt_input_amt.Text
                        , msg.s_ChkDate
                        , msg.s_pass_amt
                        , msg.s_non_pass_amt
                        , msg.pass_yn
                        , dataChkGrid
                        , lbl_input_gubun.Text
                        );

                    if (rsNum == 0)
                    {
                        MessageBox.Show("성공적으로 수정하였습니다");
                        ResetSetting();
                    }
                    else if (rsNum == 1)
                    {
                        MessageBox.Show("저장에 실패하였습니다");
                        return;
                    }
                    else
                    {
                        MessageBox.Show("sql Exception 오류");
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception 오류");
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                msg.ShowDialog();
                return;
            }
        }

        private void raw_chk_logic(DataGridView dgv, string condition, int chk)
        {
            //rawChkGrid
            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = null;
                StringBuilder sb = new StringBuilder();

                sb.AppendLine("where 1=1 ");
                sb.AppendLine(condition);
                sb.AppendLine(" and A.INPUT_DATE >= '"+start_date.Text+"' and A.INPUT_DATE <= '"+end_date.Text+"' ");
                dt = wDm.fn_Input_Chk_List(sb.ToString());

                dgv.Rows.Clear();
                if (dt != null && dt.Rows.Count > 0)
                {

                    dgv.RowCount = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgv.Rows[i].Cells[0].Value = false;

                        dgv.Rows[i].Cells[1].Value = dt.Rows[i]["INPUT_DATE"].ToString();
                        dgv.Rows[i].Cells[2].Value = dt.Rows[i]["INPUT_CD"].ToString();
                        dgv.Rows[i].Cells[4].Value = dt.Rows[i]["RAW_MAT_NM"].ToString();
                        if(dt.Rows[i]["RAW_MAT_GUBUN"].ToString().Equals("9")){
                            dgv.Rows[i].Cells[3].Value += "("+dt.Rows[i]["RAW_HST_CD"].ToString()+")";
                        }
                        
                        dgv.Rows[i].Cells[3].Value = dt.Rows[i]["CUST_NM"].ToString();
                        dgv.Rows[i].Cells[5].Value = dt.Rows[i]["SPEC"].ToString();
                        if (chk == 1) //대기, 미완료
                        {
                            dgv.Rows[i].Cells[6].Value = decimal.Parse(dt.Rows[i]["TEMP_AMT"].ToString()).ToString("#,0.######"); //가입고수량
                        }
                        else //완료, 생략
                        {
                            dgv.Rows[i].Cells[6].Value = decimal.Parse(dt.Rows[i]["TOTAL_AMT"].ToString()).ToString("#,0.######"); //최종수량
                        }
                        dgv.Rows[i].Cells[7].Value = decimal.Parse(dt.Rows[i]["TOTAL_MONEY"].ToString()).ToString("#,0.######");
                        dgv.Rows[i].Cells[8].Value = dt.Rows[i]["HEAT_NO"].ToString();
                        dgv.Rows[i].Cells[13].Value = dt.Rows[i]["CHECK_NM"].ToString();
                        dgv.Rows[i].Cells[14].Value = dt.Rows[i]["RAW_MAT_CD"].ToString();
                        dgv.Rows[i].Cells[15].Value = dt.Rows[i]["CUST_CD"].ToString();
                        dgv.Rows[i].Cells[16].Value = dt.Rows[i]["CHECK_YN"].ToString();
                        dgv.Rows[i].Cells[17].Value = dt.Rows[i]["SEQ"].ToString();
                        dgv.Rows[i].Cells[18].Value = dt.Rows[i]["CHK_DATE"].ToString();
                        dgv.Rows[i].Cells[19].Value = dt.Rows[i]["PASS_YN"].ToString();

                        if (dt.Rows[0]["PASS_YN"].ToString().Equals("Y"))
                        {
                            dgv.Rows[i].Cells[19].Value = "합격";
                        }
                        else if (dt.Rows[0]["PASS_YN"].ToString().Equals("N"))
                        {
                            dgv.Rows[i].Cells[19].Value = "불합격";
                        }
                        else
                        {
                            dgv.Rows[i].Cells[19].Value = "";
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(e.Message + " - " + e.ToString());
                msg.ShowDialog();
            }
        }

        private void chk_req_list() //검사요청 탭
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("and (A.CHECK_YN = 'S') "); //검사현황 S 대기, N 검사 등록 후 미완료 , Y 검사 완료 , O 검사 생략

            raw_chk_logic(rawChkGrid, sb.ToString(),1); 
        }

        private void chk_complete_list() //완료된 검사현황
        {
            raw_chk_logic_completeOnly(compChkList); 
        }

        private void raw_chk_logic_completeOnly(DataGridView dgv)
        {
            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = null;
                StringBuilder sb = new StringBuilder();


                sb.AppendLine(" and A.INPUT_DATE >= '" + start_date.Text + "' and A.INPUT_DATE <= '" + end_date.Text + "'  ");
                dt = wDm.fn_raw_input_with_complete_Chk(sb.ToString());

                dgv.Rows.Clear();

                if (dt != null && dt.Rows.Count > 0)
                {
                    dgv.RowCount = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgv.Rows[i].Cells[0].Value = dt.Rows[i]["INPUT_DATE"].ToString();
                        dgv.Rows[i].Cells[1].Value = dt.Rows[i]["INPUT_CD"].ToString();
                        dgv.Rows[i].Cells[2].Value = dt.Rows[i]["SEQ"].ToString();
                        dgv.Rows[i].Cells[3].Value = dt.Rows[i]["CUST_NM"].ToString();
                        dgv.Rows[i].Cells[4].Value = dt.Rows[i]["RAW_MAT_NM"].ToString();
                        dgv.Rows[i].Cells[5].Value = decimal.Parse(dt.Rows[i]["CHK_AMT"].ToString()).ToString("#,0.######");
                        dgv.Rows[i].Cells[6].Value = dt.Rows[i]["CHK_DATE"].ToString();
                        dgv.Rows[i].Cells[7].Value = dt.Rows[i]["STAFF_NM"].ToString();
                        dgv.Rows[i].Cells[8].Value = decimal.Parse(dt.Rows[i]["PASS_AMT"].ToString()).ToString("#,0.######");
                        dgv.Rows[i].Cells[9].Value = decimal.Parse(dt.Rows[i]["NON_PASS_AMT"].ToString()).ToString("#,0.######");
                        if (dt.Rows[i]["PASS_YN"].ToString().Equals("Y"))
                        {
                            dgv.Rows[i].Cells[10].Value = "합격";
                        }
                        else
                        {
                            dgv.Rows[i].Cells[10].Value = "불합격";
                        }
                        dgv.Rows[i].Cells[11].Value = dt.Rows[i]["SPEC"].ToString();
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Exception 오류");
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(e.Message + " - " + e.ToString());
                msg.ShowDialog();
            }
        }

        private void chk_omit_list() //생략된 자료
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("and A.CHECK_YN = 'O'  "); //검사현황 S 대기, N 검사 등록 후 미완료 , Y 검사 완료 , O 검사 패스 

            raw_chk_logic(omitChkList, sb.ToString(),3);
        }

        #endregion logic

        #region grid logic
        private void rawChkGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                try
                {
                    btn출력.Enabled = false;
                    txt_raw_mat_nm.Text = rawChkGrid.Rows[e.RowIndex].Cells["RAW_MAT_NM"].Value.ToString();
                    txt_cust_nm.Text = rawChkGrid.Rows[e.RowIndex].Cells["CUST_NM"].Value.ToString();
                    txt_input_date.Text = rawChkGrid.Rows[e.RowIndex].Cells["INPUT_DATE"].Value.ToString();
                    txt_input_cd.Text = rawChkGrid.Rows[e.RowIndex].Cells["INPUT_CD"].Value.ToString();
                    txt_input_seq.Text = rawChkGrid.Rows[e.RowIndex].Cells["SEQ"].Value.ToString();
                    txt_input_amt.Text = rawChkGrid.Rows[e.RowIndex].Cells["TOTAL_AMT"].Value.ToString();

                    txt_chk_date.Text = "";
                    txt_staff_nm.Text = "";
                    txt_pass_amt.Text = "";
                    txt_non_pass_amt.Text = "";
                    txt_pass_yn.Text = "";

                    lbl_input_gubun.Text = "S";

                    dataChkGrid.Rows.Clear();

                    dataChkGrid_Row_Add();

                    dataChkGrid.Rows[0].Cells["CHK_AMT"].Value = txt_input_amt.Text.ToString();
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("시스템 에러" + ex.ToString());
                    Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                    msg.ShowDialog();
                }
            }
        }

        private void dataChkGrid_Row_Add()
        {
            dataChkGrid.Rows.Add();
            dataChkGrid.Rows[dataChkGrid.Rows.Count - 1].Cells[0].Value = dataChkGrid.Rows.Count.ToString();
            dataChkGrid.Rows[dataChkGrid.Rows.Count - 1].Cells["PASS_YN"].Value = false;
            dataChkGrid.Rows[dataChkGrid.Rows.Count - 1].Cells["CHK_NM"].Value = "(검사기준 선택)";
            dataChkGrid.Rows[dataChkGrid.Rows.Count - 1].Cells["CHK_AMT"].Value = txt_input_amt.Text.ToString();
            dataChkGrid.Rows[dataChkGrid.Rows.Count - 1].Cells[1].ReadOnly = true;
            dataChkGrid.Rows[dataChkGrid.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.DarkGray;
            dataChkGrid.Rows[dataChkGrid.Rows.Count - 1].DefaultCellStyle.SelectionForeColor = Color.DarkGray;
        }

        private void compChkList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridView dgv = (DataGridView)sender;

                btnComplete.Enabled = false;
                btn출력.Enabled = true;
                txt_input_date.Text = dgv.Rows[e.RowIndex].Cells[0].Value.ToString();
                txt_input_cd.Text = dgv.Rows[e.RowIndex].Cells[1].Value.ToString();
                txt_input_seq.Text = dgv.Rows[e.RowIndex].Cells[2].Value.ToString();
                txt_cust_nm.Text = dgv.Rows[e.RowIndex].Cells[3].Value.ToString();
                txt_raw_mat_nm.Text = dgv.Rows[e.RowIndex].Cells[4].Value.ToString();
                txt_input_amt.Text = dgv.Rows[e.RowIndex].Cells[5].Value.ToString();
                txt_chk_date.Text = dgv.Rows[e.RowIndex].Cells[6].Value.ToString();
                txt_staff_nm.Text = dgv.Rows[e.RowIndex].Cells[7].Value.ToString();
                txt_pass_amt.Text = dgv.Rows[e.RowIndex].Cells[8].Value.ToString();
                txt_non_pass_amt.Text = dgv.Rows[e.RowIndex].Cells[9].Value.ToString();
                txt_pass_yn.Text = dgv.Rows[e.RowIndex].Cells[10].Value.ToString();
                lbl_spec_temp.Text = dgv.Rows[e.RowIndex].Cells[11].Value.ToString();
                lbl_input_gubun.Text = "Y";

                row_chk_detail();
            }
        }

        #endregion grid logic

        private void row_chk_detail() 
        {
            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = new DataTable();

                dt = wDm.fn_select_raw_chk_detail(
                    txt_input_date.Text
                    , txt_input_cd.Text
                    , txt_input_seq.Text
                    );

                if (dt != null && dt.Rows.Count > 0)
                {
                    dataChkGrid.Rows.Clear();
                    dataChkGrid.RowCount = dt.Rows.Count;

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dataChkGrid.Rows[i].Cells[0].Value = dt.Rows[i]["SEQ"].ToString();
                        dataChkGrid.Rows[i].Cells["del_SEQ"].Value = dt.Rows[i]["SEQ"].ToString();
                        dataChkGrid.Rows[i].Cells[1].Value = dt.Rows[i]["CHK_NM"].ToString();
                        dataChkGrid.Rows[i].Cells[1].Tag = dt.Rows[i]["CHK_CD"].ToString();
                        dataChkGrid.Rows[i].Cells[2].Value = dt.Rows[i]["CHK_CD"].ToString();
                        dataChkGrid.Rows[i].Cells[3].Value = dt.Rows[i]["PASS_VALUE"].ToString();
                        dataChkGrid.Rows[i].Cells[4].Value = dt.Rows[i]["CHK_TOOL"].ToString();
                        dataChkGrid.Rows[i].Cells[5].Value = dt.Rows[i]["CHK_TIME"].ToString();
                        dataChkGrid.Rows[i].Cells[6].Value = decimal.Parse(dt.Rows[i]["CHK_AMT"].ToString()).ToString("#,0.######");
                        if (dt.Rows[i]["PASS_YN"].ToString().Equals("Y"))
                        {
                            dataChkGrid.Rows[i].Cells[7].Value = true;
                        }
                        else
                        {
                            dataChkGrid.Rows[i].Cells[7].Value = false;
                        }
                        dataChkGrid.Rows[i].Cells[8].Value = dt.Rows[i]["POOR_NM"].ToString();
                        dataChkGrid.Rows[i].Cells[9].Value = dt.Rows[i]["POOR_CD"].ToString();
                        dataChkGrid.Rows[i].Cells[10].Value = dt.Rows[i]["COMMENT"].ToString();
                        if (dt.Rows[i]["ADD_PRINT_YN"].ToString().Equals("Y"))
                        {
                            dataChkGrid.Rows[i].Cells[11].Value = true;
                        }
                        else
                        {
                            dataChkGrid.Rows[i].Cells[11].Value = false;
                        }
                    }
                    dataChkGrid_Row_Add();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception 오류");
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                msg.ShowDialog();
            }
            
        }
        #region event logic
        private void chk_total_amt_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComInfo.onlyNum(sender, e);
        }

        private void pass_amt_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComInfo.onlyNum(sender, e);
        }

        private void pri_non_pass_amt_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComInfo.onlyNum(sender, e);
        }

        private void upd_com_amt_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComInfo.onlyNum(sender, e);
        }

        private void final_non_pass_amt_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComInfo.onlyNum(sender, e);
        }

        private void final_pass_amt_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComInfo.onlyNum(sender, e);
        }
        #endregion event lotic

        private void tbRawControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbRawControl.SelectedIndex == 0)
            {
                chk_req_list();
            }
            else if (tbRawControl.SelectedIndex == 1)
            {
                chk_complete_list();
            }
            else
            {
                chk_omit_list();
            }
        }

        private void btnOmit_Click(object sender, EventArgs e)
        {
            if (tbRawControl.SelectedIndex == 0)
            {
                if (rawChkGrid.Rows.Count > 0)
                {
                    StringBuilder sb = new StringBuilder();

                    bool chk = false;                   
                    

                    for (int i = 0; i < rawChkGrid.Rows.Count; i++)
                    {
                        if ((bool)rawChkGrid.Rows[i].Cells[0].Value == true)
                        {
                            if (rawChkGrid.Rows[i].Cells[16].Value.ToString().Equals("S"))
                            {

                                DataTable dt = new DataTable();
                                decimal final_amt = decimal.Parse(rawChkGrid.Rows[i].Cells[6].Value.ToString().Replace(",", ""));
                                sb.AppendLine(" update F_RAW_DETAIL ");
                                sb.AppendLine(" set CHECK_YN = 'O' , TOTAL_AMT = " + final_amt + " , CURR_AMT = " + final_amt + "");
                                sb.AppendLine(" where INPUT_DATE = '" + rawChkGrid.Rows[i].Cells[1].Value.ToString() + "' ");
                                sb.AppendLine("     and INPUT_CD = '" + rawChkGrid.Rows[i].Cells[2].Value.ToString() + "' ");
                                sb.AppendLine("     and SEQ = '" + rawChkGrid.Rows[i].Cells[17].Value.ToString() + "' ");
                                sb.AppendLine(" update N_RAW_CODE ");
                                sb.AppendLine(" set BAL_STOCK = BAL_STOCK +'" + final_amt +"' ");
                                sb.AppendLine(" where RAW_MAT_CD = (select RAW_MAT_CD from F_RAW_DETAIL ");
                                sb.AppendLine(" where INPUT_DATE = '" + rawChkGrid.Rows[i].Cells[1].Value.ToString() + "' ");
                                sb.AppendLine("     and INPUT_CD = '" + rawChkGrid.Rows[i].Cells[2].Value.ToString() + "' ");
                                sb.AppendLine("     and SEQ = '" + rawChkGrid.Rows[i].Cells[17].Value.ToString() + "') ");
                                sb.AppendLine("    ");

                                Console.WriteLine(sb.ToString());

                                chk = true;
                            }
                        }
                    }

                    if (chk == true)
                    {
                        wnDm wDm = new wnDm();
                        int rsNum = wDm.updateChkOmit(sb);

                        if (rsNum == 0)
                        {
                            chk_req_list();
                            MessageBox.Show("생략되었습니다.");
                        }
                        else if (rsNum == 1)
                            MessageBox.Show("저장에 실패하였습니다");
                        else
                            MessageBox.Show("Exception 에러2");
                    }
                }

            }
        }

        private void RawPoorGrid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //DataGridView dgv = (DataGridView)sender;

            //if (dgv.Columns[dgv.CurrentCell.ColumnIndex].Name.Equals("POOR_TYPE"))
            //{
            //    ComboBox cmbprocess = e.Control as ComboBox;

            //    if (p_num > 0) 
            //    {
            //        cmbprocess.Leave -= new EventHandler(cmb_flow_pass_Leave);
            //    }

            //    cmbprocess.Leave += new EventHandler(cmb_flow_pass_Leave);
            //    p_type_idx = dgv.CurrentRow.Index;
            //}
        }

        private void cmb_flow_pass_Leave(object sender, EventArgs e)
        {
            //p_num++;
            //ComboBox cmbprocess = (ComboBox)sender;

            //if (cmbprocess.SelectedValue == null) cmbprocess.SelectedValue = "";
            //if (cmbprocess.SelectedValue != null) 
            //{
            //    wnDm wDm = new wnDm();
            //    DataTable dt = wDm.fn_query_Poor(cmbprocess.SelectedValue.ToString());

            //    ((DataGridViewComboBoxColumn)rawPoorGrid.Columns["POOR_CD"]).DataSource = dt;
            //}
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void start_date_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dataChkGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (dataChkGrid.Columns[e.ColumnIndex].Name == "PASS_YN")
                {
                    if(dataChkGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Equals("합격"))
                    {
                        dataChkGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "불합격";
                        dataChkGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag = "N";
                    }
                    else if (dataChkGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Equals("불합격"))
                    {
                        dataChkGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "합격";
                        dataChkGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag = "Y";
                    }
                }
            }
        }


        private void dataChkGrid_MouseClick(object sender, MouseEventArgs e)
        {
            DataGridView dgvTemp = (DataGridView)sender;

            int currentMouseOverRow = dgvTemp.HitTest(e.X, e.Y).RowIndex;
            int currentMouseOverColumn = dgvTemp.HitTest(e.X, e.Y).ColumnIndex;

            wnDm wDm = new wnDm();



            if (currentMouseOverRow > -1 && currentMouseOverColumn == 1)
            {
                DataTable dt = null;
                MouseClickRow = currentMouseOverRow;
                MouseClickCol = currentMouseOverColumn;
                
                EventHandler eh = new EventHandler(MenuClick);
                ContextMenu m = new ContextMenu();

                dt = wDm.fn_RawChkStan_List(" where 1=1 ");

                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        m.MenuItems.Add(new MenuItem(dt.Rows[i]["CHK_CD"].ToString() + ", " + dt.Rows[i]["CHK_NM"].ToString(), eh));
                    }
                    m.MenuItems.Add(new MenuItem("행 삭제", eh));
                    m.MenuItems.Add(new MenuItem("직접 입력", eh));
                    dgvTemp.CurrentCell = dgvTemp.Rows[currentMouseOverRow].Cells[currentMouseOverColumn];
                    m.Show(dgvTemp, new Point(e.X, e.Y));
                }
            }


        }

        void MenuClick(object obj, EventArgs ea)
        {
            MenuItem mI = (MenuItem)obj;
            String str = mI.Text;

            switch (str)
            {
                
                case "행 삭제":
                    if (dataChkGrid.Rows.Count > 1)
                    {
                        for (int i = dataChkGrid.Rows.Count-1; i >= 0; i--)
                        {
                            if (MouseClickRow != i && dataChkGrid.Rows[MouseClickRow].Cells[1].Tag == dataChkGrid.Rows[i].Cells[1].Tag)
                            {
                                dataChkGrid.Rows[i].Cells["CHK_AMT"].Value =
                                    (decimal.Parse(dataChkGrid.Rows[i].Cells["CHK_AMT"].Value.ToString()) + decimal.Parse(dataChkGrid.Rows[MouseClickRow].Cells["CHK_AMT"].Value.ToString()))
                                    .ToString("#,0.######");
                                break;
                            }
                        }
                        dataChkGrid.Rows.RemoveAt(MouseClickRow);
                    }
                    else
                    {
                        dataChkGrid.Rows[MouseClickRow].Cells[1].ReadOnly = true;
                        dataChkGrid.Rows[MouseClickRow].DefaultCellStyle.ForeColor = Color.DarkGray;
                        dataChkGrid.Rows[MouseClickRow].DefaultCellStyle.SelectionForeColor = Color.DarkGray;
                        dataChkGrid.Rows[MouseClickRow].Cells[1].Tag = null;
                        dataChkGrid.Rows[MouseClickRow].Cells[1].Value = "(검사기준 선택)";
                        dataChkGrid.Rows[MouseClickRow].Cells["PASS_VALUE"].Value = "";
                        dataChkGrid.Rows[MouseClickRow].Cells["CHK_TOOL"].Value = "";
                        dataChkGrid.Rows[MouseClickRow].Cells["CHK_TIME"].Value = "";
                        dataChkGrid.Rows[MouseClickRow].Cells["POOR_CD"].Value = "";
                        dataChkGrid.Rows[MouseClickRow].Cells["POOR_NM"].Value = "";
                        dataChkGrid.Rows[MouseClickRow].Cells["PASS_YN"].Value = false;
                    }
                    dataChkGrid_ReNumbering();
                    break;

                case "직접 입력":

                    pop수입검사기준등록 msg = new pop수입검사기준등록();
                    msg.ShowDialog();

                    if (!msg.s_CHK_CD.Equals(""))
                    {
                        dataChkGrid.Rows[MouseClickRow].Cells["CHK_CD"].Value = msg.s_CHK_CD;
                        dataChkGrid.Rows[MouseClickRow].Cells["CHK_NM"].Value = msg.s_CHK_NM;
                        dataChkGrid.Rows[MouseClickRow].Cells[1].Tag = msg.s_CHK_CD;
                        dataChkGrid.Rows[MouseClickRow].Cells["PASS_VALUE"].Value = msg.s_DEFAULT;
                        dataChkGrid.Rows[MouseClickRow].Cells["CHK_TOOL"].Value = msg.s_TOOLS;
                        dataChkGrid.Rows[MouseClickRow].Cells["CHK_TIME"].Value = msg.s_TIME;
                        dataChkGrid.Rows[MouseClickRow].Cells["COMMENT"].Value = "";
                        dataChkGrid.Rows[MouseClickRow].Cells["PASS_YN"].Value = true;
                        dataChkGrid.Rows[MouseClickRow].Cells["POOR_CD"].Value = msg.s_POOR_CD;
                        dataChkGrid.Rows[MouseClickRow].Cells["POOR_NM"].Value = msg.s_POOR_NM;
                        dataChkGrid.Rows[MouseClickRow].Cells["CHK_AMT"].Value = decimal.Parse(txt_input_amt.Text.ToString()).ToString("#,0.######");
                        dataChkGrid.Rows[MouseClickRow].Cells[1].ReadOnly = true;
                        dataChkGrid.Rows[MouseClickRow].DefaultCellStyle.ForeColor = Color.Black;
                        dataChkGrid.Rows[MouseClickRow].DefaultCellStyle.SelectionForeColor = Color.Black;
                    }
                    break;
                default:
                    for (int i = 0; i < dataChkGrid.Rows.Count; i++)
                    {
                        if (dataChkGrid.Rows[i].Cells[1].Tag == null) continue;
                        else if (dataChkGrid.Rows[i].Cells[1].Tag.ToString().Equals(str.Split(',')[0]))
                        {
                            MessageBox.Show("해당 항목이 이미 리스트에 존재합니다.");
                            return;
                        }
                    }

                    if (dataChkGrid.Rows[MouseClickRow].Cells[1].Tag != null && !dataChkGrid.Rows[MouseClickRow].Cells[1].Tag.ToString().Equals(""))
                    {
                        for (int i = dataChkGrid.Rows.Count - 1; i >= 0; i--)
                        {
                            if (MouseClickRow != i && dataChkGrid.Rows[MouseClickRow].Cells[1].Tag == dataChkGrid.Rows[i].Cells[1].Tag)
                            {
                                dataChkGrid.Rows[i].Cells["CHK_AMT"].Value =
                                    (decimal.Parse(dataChkGrid.Rows[i].Cells["CHK_AMT"].Value.ToString()) + decimal.Parse(dataChkGrid.Rows[MouseClickRow].Cells["CHK_AMT"].Value.ToString()))
                                    .ToString("#,0.######");
                                break;
                            }
                        }
                    }

                    wnDm wDm = new wnDm();
                    DataTable dt = wDm.fn_RawChkStan_List("WHERE A.CHK_CD = '"+str.Split(',')[0]+"'  ");

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        dataChkGrid.Rows[MouseClickRow].Cells["PASS_VALUE"].Value = dt.Rows[0]["PASS_VALUE"].ToString();
                        dataChkGrid.Rows[MouseClickRow].Cells["CHK_TOOL"].Value = dt.Rows[0]["CHK_TOOL"].ToString();
                        dataChkGrid.Rows[MouseClickRow].Cells["CHK_TIME"].Value = dt.Rows[0]["CHK_TIME"].ToString();
                        dataChkGrid.Rows[MouseClickRow].Cells["POOR_CD"].Value = dt.Rows[0]["POOR_CD"].ToString();
                        dataChkGrid.Rows[MouseClickRow].Cells["POOR_NM"].Value = dt.Rows[0]["POOR_NM"].ToString();
                        dataChkGrid.Rows[MouseClickRow].Cells["COMMENT"].Value = "";
                        dataChkGrid.Rows[MouseClickRow].Cells["CHK_AMT"].Value = decimal.Parse(txt_input_amt.Text.ToString()).ToString("#,0.######");
                        dataChkGrid.Rows[MouseClickRow].Cells["PASS_YN"].Value = true;
                        dataChkGrid.Rows[MouseClickRow].Cells[1].ReadOnly = true;
                        dataChkGrid.Rows[MouseClickRow].DefaultCellStyle.ForeColor = Color.Black;
                        dataChkGrid.Rows[MouseClickRow].DefaultCellStyle.SelectionForeColor = Color.Black;
                        dataChkGrid.Rows[MouseClickRow].Cells[1].Tag = str.Split(',')[0];
                        dataChkGrid.Rows[MouseClickRow].Cells[1].Value = str.Split(',')[1].Substring(1);
                    }
                    else
                    {
                        MessageBox.Show("검사기준 선택 오류");
                        return;
                    }
                    break;
            }

            for (int i = 0; i < dataChkGrid.Rows.Count; i++)
            {
                if (dataChkGrid.Rows[i].Cells[1].Tag == null)
                {
                    break;
                }
                else if (i == dataChkGrid.Rows.Count - 1)
                {
                    dataChkGrid_Row_Add();
                    break;
                }
            }

        }

        private void dataChkGrid_ReNumbering()
        {
            for (int i = 0; i < dataChkGrid.Rows.Count; i++)
            {
                dataChkGrid.Rows[i].Cells[0].Value = (i + 1).ToString();
            }
        }


        private void grid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            string name = dataChkGrid.CurrentCell.OwningColumn.Name;

            //if (name == "CHK_AMT")
            //{
            //    e.Control.KeyPress += new KeyPressEventHandler(txtCheckNumeric_KeyPress);
            //}
            //else
            //{
            //    e.Control.KeyPress -= new KeyPressEventHandler(txtCheckNumeric_KeyPress);
            //}
        }

        private void txtCheckNumeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComInfo.onlyNum2(sender, e);
        }

        private void dataChkGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dataChkGrid.Columns[e.ColumnIndex].Name == "CHK_AMT")
            {
                if (dataChkGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null) return;

                string BackupValue = dataChkGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                try
                {
                    decimal.Parse(BackupValue);
                    if (decimal.Parse(BackupValue) <= 0)
                    {
                        decimal chk_amt2 = 0;
                        MessageBox.Show("0 이하는 입력할 수 없습니다.");
                        for (int i = 0; i < dataChkGrid.Rows.Count; i++)
                        {
                            if (dataChkGrid.Rows[e.RowIndex].Cells[1].Tag == null) return;
                            if (dataChkGrid.Rows[i].Cells[1].Tag == null) continue;
                            if (i != e.RowIndex && dataChkGrid.Rows[i].Cells[1].Tag.ToString().Equals(dataChkGrid.Rows[e.RowIndex].Cells[1].Tag.ToString()))
                            {
                                chk_amt2 += decimal.Parse(dataChkGrid.Rows[i].Cells[e.ColumnIndex].Value.ToString().Replace(",", ""));
                            }
                        }
                        dataChkGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = (decimal.Parse(txt_input_amt.Text.ToString().Replace(",", "")) - chk_amt2).ToString("#,0.######");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    decimal chk_amt2 = 0;
                    MessageBox.Show("입력 양식이 잘못 되었습니다( 숫자만 입력 )");
                    for (int i = 0; i < dataChkGrid.Rows.Count; i++)
                    {
                        if (dataChkGrid.Rows[e.RowIndex].Cells[1].Tag == null) return;
                        if (dataChkGrid.Rows[i].Cells[1].Tag == null) continue;
                        if (i!= e.RowIndex && dataChkGrid.Rows[i].Cells[1].Tag.ToString().Equals(dataChkGrid.Rows[e.RowIndex].Cells[1].Tag.ToString()))
                        {
                            chk_amt2 += decimal.Parse(dataChkGrid.Rows[i].Cells[e.ColumnIndex].Value.ToString().Replace(",", ""));
                        }
                    }
                    dataChkGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = (decimal.Parse(txt_input_amt.Text.ToString().Replace(",", "")) - chk_amt2).ToString("#,0.######");
                    return;
                }

                decimal total_chk_amt = decimal.Parse(txt_input_amt.Text.ToString().Replace(",", ""));
                decimal chk_amt = 0;//decimal.Parse(dataChkGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                for (int i = 0; i < dataChkGrid.Rows.Count; i++)
                {
                    if (dataChkGrid.Rows[e.RowIndex].Cells[1].Tag == null) return;
                    if (dataChkGrid.Rows[i].Cells[1].Tag == null) continue;
                    if(dataChkGrid.Rows[i].Cells[1].Tag.ToString().Equals(dataChkGrid.Rows[e.RowIndex].Cells[1].Tag.ToString()))
                    {
                        chk_amt += decimal.Parse(dataChkGrid.Rows[i].Cells[e.ColumnIndex].Value.ToString().Replace(",",""));
                    }
                }
                if (total_chk_amt < chk_amt)
                {
                    MessageBox.Show("검사 수량은 입고 수량을 초과할 수 없습니다.");
                    dataChkGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = (total_chk_amt-chk_amt+decimal.Parse(BackupValue)).ToString("#,0.######");
                    return;
                }
                else if (total_chk_amt > chk_amt)
                {
                    dataChkGrid.Rows.Insert(e.RowIndex+1, 1);
                    for (int i = 0; i < dataChkGrid.Columns.Count; i++)
                    {
                        if (dataChkGrid.Columns[i].Name == "CHK_AMT")
                        {
                            dataChkGrid.Rows[e.RowIndex + 1].Cells[i].Value = (total_chk_amt - chk_amt).ToString("#,0.######");
                        }
                        else if (dataChkGrid.Columns[i].Name == "COMMENT")
                        {
                            dataChkGrid.Rows[e.RowIndex + 1].Cells[i].Value = "";
                        }
                        else if (dataChkGrid.Columns[i].Name == "PASS_YN")
                        {
                            dataChkGrid.Rows[e.RowIndex + 1].Cells[i].Value = true;
                        }
                        else
                        {
                            dataChkGrid.Rows[e.RowIndex + 1].Cells[i].Value = dataChkGrid.Rows[e.RowIndex].Cells[i].Value;
                            dataChkGrid.Rows[e.RowIndex + 1].Cells[i].Tag = dataChkGrid.Rows[e.RowIndex].Cells[i].Tag;
                        }
                    }
                    dataChkGrid_ReNumbering();
                }
            }
        }

        private void DataGridViewInsertRow(DataGridView dgv, int add_Loc)
        {
            List<string> rowValues = new List<string>();

            DataTable dt = (DataTable)(dgv.DataSource);
            DataRow dr = (DataRow)dt.Rows[add_Loc];

            DataRow newDr = null;
            object[] objTemp = dr.ItemArray;

            newDr.ItemArray = objTemp;

            dt.Rows.InsertAt(newDr, add_Loc+1);

            dgv.DataSource = dt.Copy();
        }

        private void dataChkGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataChkGrid.Columns[e.ColumnIndex].Name == "ADD_PRINT")
            {
                for (int i = 0; i < dataChkGrid.Rows.Count; i++)
                {
                    if (dataChkGrid.Rows[i].Cells[1].Tag == null) continue;
                    dataChkGrid.Rows[i].Cells["ADD_PRINT"].Value = true;
                }
            }
        }

        private void btn_research_Click(object sender, EventArgs e)
        {
            chk_req_list();
            chk_complete_list();
            chk_omit_list();
        }

        private void omitChkList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                try
                {
                    btn출력.Enabled = false;
                    txt_raw_mat_nm.Text = omitChkList.Rows[e.RowIndex].Cells["RAW_MAT_NM_S"].Value.ToString();
                    txt_cust_nm.Text = omitChkList.Rows[e.RowIndex].Cells["CUST_NM_S"].Value.ToString();
                    txt_input_date.Text = omitChkList.Rows[e.RowIndex].Cells["INPUT_DATE_S"].Value.ToString();
                    txt_input_cd.Text = omitChkList.Rows[e.RowIndex].Cells["INPUT_CD_S"].Value.ToString();
                    txt_input_seq.Text = omitChkList.Rows[e.RowIndex].Cells["SEQ_S"].Value.ToString();
                    txt_input_amt.Text = omitChkList.Rows[e.RowIndex].Cells["TOTAL_AMT_S"].Value.ToString();

                    txt_chk_date.Text = "";
                    txt_staff_nm.Text = "";
                    txt_pass_amt.Text = "";
                    txt_non_pass_amt.Text = "";
                    txt_pass_yn.Text = "생략";

                    lbl_input_gubun.Text = "P";

                    dataChkGrid.Rows.Clear();

                    dataChkGrid_Row_Add();

                    dataChkGrid.Rows[0].Cells["CHK_AMT"].Value = txt_input_amt.Text.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("시스템 에러" + ex.ToString());
                    Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                    msg.ShowDialog();
                }
            }
        }

        private void btn출력_Click(object sender, EventArgs e)
        {
            btn출력.Enabled = false;

            string strCondition = "";

            if (dataChkGrid.Rows.Count <= 1)
            {
                MessageBox.Show("출력할 자료가 없습니다.");
                btn출력.Enabled = true;
                return;
            }

            DataTable dtTemp = MakeFrmPrt();

            dtTemp.Rows.Clear();

            for (int i = 0; i < dataChkGrid.Rows.Count; i++)
            {
                if (dataChkGrid.Rows[i].Cells[1].Tag != null && dataChkGrid.Rows[i].Cells["ADD_PRINT"].Value != null && (bool)dataChkGrid.Rows[i].Cells["ADD_PRINT"].Value == true)
                {
                    dtTemp.Rows.Add();
                    dtTemp.Rows[dtTemp.Rows.Count - 1]["NO"] = dtTemp.Rows.Count;
                    dtTemp.Rows[dtTemp.Rows.Count - 1]["CHK_NM"] = dataChkGrid.Rows[i].Cells["CHK_NM"].Value.ToString();
                    dtTemp.Rows[dtTemp.Rows.Count - 1]["PASS_VALUE"] = dataChkGrid.Rows[i].Cells["PASS_VALUE"].Value.ToString();
                    dtTemp.Rows[dtTemp.Rows.Count - 1]["CHK_AMT"] = dataChkGrid.Rows[i].Cells["CHK_AMT"].Value.ToString();
                    if(dataChkGrid.Rows[i].Cells["PASS_YN"].Value != null && (bool)dataChkGrid.Rows[i].Cells["PASS_YN"].Value == true)
                    {
                        dtTemp.Rows[dtTemp.Rows.Count - 1]["PASS_YN"] = "통과";
                    }
                    else
                    {
                        dtTemp.Rows[dtTemp.Rows.Count - 1]["PASS_YN"] = "불합격";
                    }
                }
            }

            frmPrt = readyPrt;
            frmPrt.Show();
            frmPrt.BringToFront();
            //frmPrt.prt_원자재재고현황(adoPrt, strDay1, strDay2, strCust, strCondition);
            frmPrt.prt_수입검사성적서(dtTemp
                , txt_chk_date.Text
                , txt_staff_nm.Text
                , txt_raw_mat_nm.Text
                , lbl_spec_temp.Text
                , txt_cust_nm.Text
                , txt_input_date.Text
                , txt_input_cd.Text
                , txt_input_seq.Text
                , txt_input_amt.Text
                , txt_pass_amt.Text
                ,txt_non_pass_amt.Text
                ,txt_pass_yn.Text
                );

            btn출력.Enabled = true;
        }

        private DataTable MakeFrmPrt()
        {
            StringBuilder sb = new StringBuilder();
            wnAdo wAdo = new wnAdo();

            sb.AppendLine("   SELECT           ");

            sb.AppendLine(" '' AS NO             ");
            sb.AppendLine(" ,'' AS CHK_NM             ");
            sb.AppendLine(" ,'' AS PASS_VALUE             ");
            sb.AppendLine(" ,'' AS CHK_AMT             ");
            sb.AppendLine(" ,'' AS PASS_YN             ");


            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
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
                    chk_req_list();
                    
                    break;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
            return true;
        }

    }
}
