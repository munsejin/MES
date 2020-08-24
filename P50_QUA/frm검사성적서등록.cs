using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using MetroFramework.Forms;
using MES.CLS;
using MES.Popup;

namespace MES.P50_QUA
{
    public partial class frm검사성적서등록 : Form
    {
        wnGConstant wConst = new wnGConstant();
        Image image;
        string path;
        int startIdx = 0; //실측치 시작 인덱스
        wnDm wnDm = new wnDm();
        private string fileName = "";
        private string fileFullName = "";
        private string filePath = "";
        private string pathTemp = "";
        private string oldEditTemp = "";
        public static bool p_IsAuth = true;    // 열람권한
        public static bool p_Isrgstr = true;    //등록/수정 권한

        public static bool p_Isdel = true;    // 삭제 권한
        public frm검사성적서등록()
        {
            InitializeComponent();
        }

        private void frm검사성적서등록_Load(object sender, EventArgs e)
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
            button3.Enabled = true;
            proSetting();

            DataGridViewComboBoxColumn cmbColumn = new DataGridViewComboBoxColumn();

            wnDm wDm = new wnDm();
            DataTable dt = wDm.fn_query_com_code("810");
            //((DataGridViewComboBoxColumn)dataChkGrid.Columns["GRADE"]).DataSource = dt2;

            cmbColumn.ValueMember = "코드";
            cmbColumn.DisplayMember = "명칭";
            cmbColumn.DataSource = dt;
            cmbColumn.HeaderText = "판정";
            cmbColumn.Name = "GRADE";

            dataChkGrid.Columns.Add(cmbColumn);
            dataChkGrid.Columns[dataChkGrid.Columns.Count - 1].Width = 70;

            startIdx = dataChkGrid.ColumnCount;

            chk_req_list();

            tlp_flow.SetColumnSpan(label17, 2);
            tlp_flow.SetColumnSpan(cmb_flow_pass, 2);
            //tlp_flow.SetColumnSpan(btn_pass, 2);


            init_ComboBox();

            if (Common.sp_code == "300") //대양요청
            {
                cmbColumn.Visible = false;

            }
        }

        private void init_ComboBox()
        {
            ComInfo comInfo = new ComInfo();
            string sqlQuery = "";

            cmb_flow_pass.ValueMember = "코드";
            cmb_flow_pass.DisplayMember = "명칭";
            sqlQuery = comInfo.queryChkPass();
            wConst.ComboBox_Read_Blank(cmb_flow_pass, sqlQuery);
            cmb_flow_pass.SelectedIndex = 0;
        }
        private void proSetting()
        {

        }

        #region button logic

        private void btnComplete_Click(object sender, EventArgs e)
        {
            if (txt_check_yn.Text.ToString().Equals("N")) //미완료
            {
                cmb_flow_pass.SelectedValue = "";
                lbl_pass_lot.Text = txt_lot_no.Text.ToString() + " - " + txt_lot_sub.Text.ToString();
                lbl_pass_item_nm.Text = txt_item_nm.Text.ToString();
                lbl_pass_flow.Text = txt_flow_nm.Text.ToString();
                tlp_flow.Visible = true;
            }
            else if (txt_check_yn.Text.ToString().Equals("Y")) //완료
                MessageBox.Show("이미 공정검사가 완료되었습니다. ");
            else if (txt_check_yn.Text.ToString().Equals("S")) //대기
                MessageBox.Show("공정검사를 먼저 등록하시기 바랍니다.");
            else if (txt_check_yn.Text.ToString().Equals("O")) //생략 
                MessageBox.Show("생략된 공정검사는 검사완료 할 수 없습니다.");
            else
                MessageBox.Show("데이터가 존재하지 않습니다. ");
        }

        private void btnOmit_Click(object sender, EventArgs e)
        {

            txt_exam_test.Enabled = true;
            button3.Enabled = true;

            if (tbFlowControl.SelectedIndex == 0)
            {
                if (ReqChkList.Rows.Count > 0)
                {
                    StringBuilder sb = new StringBuilder();
                    bool chk = false;

                    for (int i = 0; i < ReqChkList.Rows.Count; i++)
                    {
                        if ((bool)ReqChkList.Rows[i].Cells[0].Value == true)
                        {
                            if (ReqChkList.Rows[i].Cells[11].Value.ToString().Equals("S"))
                            {
                                sb.AppendLine(" update F_WORK_FLOW_DETAIL ");
                                sb.AppendLine(" set CHECK_YN = 'O' ");
                                sb.AppendLine(" where LOT_NO = '" + ReqChkList.Rows[i].Cells[2].Value + "' ");
                                sb.AppendLine("     and LOT_SUB = '" + ReqChkList.Rows[i].Cells[3].Value + "' ");
                                sb.AppendLine("     and F_STEP = '" + ReqChkList.Rows[i].Cells[10].Value + "' ");
                                chk = true;
                            }
                        }
                    }

                    if (chk == true)
                    {
                        DataTable dt = new DataTable();
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
                    else
                    {
                        MessageBox.Show("생략데이터가 없습니다. (대기중일 경우에만 생략 가능)");
                    }

                    for (int i = 0; i < ReqChkList.Rows.Count; i++)
                    {
                        ReqChkList.Rows[i].Cells[0].Value = false;
                    }
                }
            }
        }
        int amt = 0;
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (p_Isrgstr)
            {



                if (dataChkGrid.Rows.Count == 0)
                {
                    MessageBox.Show("검사항목이 없으므로 저장이 불가능합니다.");
                    return;
                }
                saveLogic();
                try
                {
                    if (Common.sp_code == "300")
                    {

                        for (int i = 0; i < dataChkGrid.Rows.Count; i++)
                        {

                            if (dataChkGrid.Rows[i].Cells["CHK1"].Value != "" | dataChkGrid.Rows[i].Cells["CHK1"].Value != null)
                            {
                                amt += int.Parse(dataChkGrid.Rows[i].Cells["CHK1"].Value.ToString());
                            }
                        }
                        updateFlowChkExam(amt);
                    }
                }
                catch
                {

                }
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
                if (dataChkGrid.Rows.Count > 0)
                {
                    DialogResult msgOk = MessageBox.Show("데이터가 존재합니다. \n 창을 닫으시겠습니까?", "확인여부", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (msgOk == DialogResult.No)
                    {
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show("권한이 없습니다.");
            }
                
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (dataChkGrid.Rows.Count > 0)
            {
                DialogResult msgOk = MessageBox.Show("데이터가 존재합니다. \n 창을 닫으시겠습니까?", "확인여부", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msgOk == DialogResult.No)
                {
                    return;
                }
            }
            this.Close();
        }

        private void btn_pass_Click(object sender, EventArgs e)
        {
            if (cmb_flow_pass.SelectedValue == null) cmb_flow_pass.SelectedValue = "";

            if ((string)cmb_flow_pass.SelectedValue == "")
            {
                MessageBox.Show("검사결과를 선택하시기 바랍니다.");
                return;
            }

            wnDm wDm = new wnDm();
            int rsNum = wDm.updateFlowChkPass(txt_lot_no.Text.ToString()
                                              , txt_lot_sub.Text.ToString()
                                              , txt_f_step.Text.ToString()
                                              , cmb_flow_pass.SelectedValue.ToString());
            if (rsNum == 0)
            {
                chk_req_list();
                chk_complete_list();

                txt_check_nm.Text = "완료";
                txt_check_yn.Text = "Y";
                MessageBox.Show("검사가 완료되었습니다.");
            }
            else if (rsNum == 1)
                MessageBox.Show("저장에 실패하였습니다");
            else
                MessageBox.Show("Exception 에러2");

            tlp_flow.Visible = false;
        }

        private void btn_pass_close_Click(object sender, EventArgs e)
        {
            tlp_flow.Visible = false;
        }

        private void btn_file_up_Click(object sender, EventArgs e)
        {
            pic_logic(pic_exam);
        }

        #endregion button logic

        #region flow chk logic
        private void chk_req_list()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("and (B.CHECK_YN = 'S' or B.CHECK_YN = 'N') "); //검사현황 S 대기, N 검사 등록 후 미완료 , Y 검사 완료 , O 검사 생략

            flow_chk_logic(ReqChkList, sb.ToString());
        }

        private void chk_complete_list()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("and B.CHECK_YN = 'Y'  "); //검사현황 S 대기, N 검사 등록 후 미완료 , Y 검사 완료 , O 검사 패스 

            flow_chk_logic(compChkList, sb.ToString());
            Debug.WriteLine("완료합니다..");
        }

        private void chk_omit_list()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("and B.CHECK_YN = 'O'  "); //검사현황 S 대기, N 검사 등록 후 미완료 , Y 검사 완료 , O 검사 패스 

            flow_chk_logic(omitChkList, sb.ToString());
        }

        private void flow_chk_logic(DataGridView dgv, string condition)
        {
            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = new DataTable();
                StringBuilder sb = new StringBuilder();

                sb.AppendLine("and B.COMPLETE_YN = 'N' ");
                sb.AppendLine("and D.FLOW_CHK_YN = 'Y' "); //공정검사 여부
                sb.AppendLine(condition);
                Debug.WriteLine("완료");
                dt = wDm.fn_Flow_Chk_Req_List(sb.ToString());

                if (dt != null && dt.Rows.Count > 0)
                {
                    dgv.RowCount = dt.Rows.Count;
                    for (int i = 0; i < dgv.Rows.Count; i++)
                    {
                        dgv.Rows[i].Cells[0].Value = false;

                        dgv.Rows[i].Cells[1].Value = dt.Rows[i]["F_SUB_DATE"].ToString();
                        dgv.Rows[i].Cells[2].Value = dt.Rows[i]["LOT_NO"].ToString();
                        dgv.Rows[i].Cells[3].Value = dt.Rows[i]["LOT_SUB"].ToString();
                        dgv.Rows[i].Cells[4].Value = dt.Rows[i]["ITEM_NM"].ToString();
                        dgv.Rows[i].Cells[5].Value = dt.Rows[i]["FLOW_NM"].ToString();

                        dgv.Rows[i].Cells[6].Value = (decimal.Parse(dt.Rows[i]["F_SUB_AMT"].ToString())).ToString("#,0.######");
                        dgv.Rows[i].Cells[7].Value = dt.Rows[i]["CHECK_NM"].ToString();
                        dgv.Rows[i].Cells[8].Value = dt.Rows[i]["ITEM_CD"].ToString();
                        dgv.Rows[i].Cells[9].Value = dt.Rows[i]["FLOW_CD"].ToString();
                        dgv.Rows[i].Cells[10].Value = dt.Rows[i]["F_STEP"].ToString();
                        dgv.Rows[i].Cells[11].Value = dt.Rows[i]["CHECK_YN"].ToString();
                        dgv.Rows[i].Cells[12].Value = dt.Rows[i]["PASS_YN"].ToString();

                        dgv.Rows[i].Cells[13].Value = dt.Rows[i]["PASS_YN"].ToString();
                    }
                }
                else
                {
                    dgv.Rows.Clear();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("시스템 에러" + e.ToString());
            }
        }

        private void resetSetting()
        {

        }

        private void saveLogic()
        {

            wnDm wDm = new wnDm();
            if (txt_check_yn.Text.ToString().Equals("S")) //대기
            {
                lblSearch.Text = "등록중";
                lblSearch.Visible = true;
                Application.DoEvents();

                byte[] flow_img;
                int flow_img_size = 0;
                if (path != null && path != "")
                {
                    flow_img = ComInfo.GetImage(path);
                    flow_img_size = flow_img.Length;
                }
                else
                {
                    flow_img = null;
                    flow_img_size = 0;
                }

                int rsNum = wDm.insertFlowChkExam(txt_lot_no.Text.ToString()
                                                          , txt_lot_sub.Text.ToString()
                                                          , txt_f_step.Text.ToString()
                                                          , txt_item_cd.Text.ToString()
                                                          , txt_flow_cd.Text.ToString()
                                                          , txt_sub_amt.Text.ToString()
                                                          , txt_measure_cnt.Text.ToString()
                                                          , startIdx
                                                          , lblSearch
                                                          , flow_img
                                                          , flow_img_size
                                                          , dataChkGrid
                                                          , txt_exam_test.Text.ToString()
                                                          );
                if (rsNum == 0)
                {
                    chk_req_list();

                    txt_check_nm.Text = "미완료";
                    txt_check_yn.Text = "N";

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

                lblSearch.Visible = false;
            }
            else if (txt_check_yn.Text.ToString().Equals("N"))  // 미완료
            {
                if (!p_Isdel)
                {
                    MessageBox.Show("권한이없습니다.");
                    return;
                }
                byte[] flow_img;
                int flow_img_size = 0;
                if (path != null && path != "")
                {
                    flow_img = ComInfo.GetImage(path);
                    flow_img_size = flow_img.Length;
                }
                else
                {
                    flow_img = null;
                    flow_img_size = 0;
                }

                lblSearch.Text = "등록중";
                lblSearch.Visible = true;
                Application.DoEvents();


                int rsNum = wDm.updateFlowChkExam(txt_lot_no.Text.ToString()
                                                  , txt_lot_sub.Text.ToString()
                                                  , txt_f_step.Text.ToString()
                                                  , startIdx
                                                  , lblSearch
                                                  , flow_img
                                                  , flow_img_size
                                                  , dataChkGrid
                                                  , txt_exam_test.Text.ToString()
                                                  );
                if (rsNum == 0)
                {
                    chk_req_list();

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

                lblSearch.Visible = false;


            }
        }
        #region 공정검사 더블클릭시 로직
        //공정검사 더블클릭 시 로직
        private void flow_chk_data_logic(DataGridView dgv, DataGridViewCellEventArgs e, bool change_chk)
        {
           // txt_exam_test.Text = "";
            wnDm wDm = new wnDm();
            DataTable dt = new DataTable();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("     and A.LOT_NO = '" + dgv.Rows[e.RowIndex].Cells[2].Value.ToString() + "' ");
            sb.AppendLine("     and B.LOT_SUB = '" + dgv.Rows[e.RowIndex].Cells[3].Value.ToString() + "' ");
            sb.AppendLine("     and B.F_STEP = '" + dgv.Rows[e.RowIndex].Cells[10].Value.ToString() + "' ");
            //sb.AppendLine("     and B.FLOW_CD = '" + dgv.Rows[e.RowIndex].Cells[9].Value.ToString() + "' ");

            dt = wDm.fn_Flow_Chk_Main_List(sb.ToString());


            //sb.AppendLine("select ");
            //sb.AppendLine("          A.F_CHK_DATE ");1
            //sb.AppendLine("         ,A.LOT_NO ");2
            //sb.AppendLine("         ,A.LOT_SUB ");3
            //sb.AppendLine("         ,A.ITEM_CD ");4
            //sb.AppendLine("         ,C.ITEM_NM ");5
            //sb.AppendLine("         ,C.SPEC ");6

            //sb.AppendLine("         ,A.FLOW_CD ");7
            //sb.AppendLine("         ,D.FLOW_NM ");8
            //sb.AppendLine("         ,A.F_STEP ");9
            //sb.AppendLine("         ,A.F_SUB_AMT ");10
            //sb.AppendLine("         ,B.COMPLETE_YN ");11
            //sb.AppendLine("         ,B.CHECK_YN ");12
            //sb.AppendLine("         ,C.ITEM_GUBUN ");13
            //sb.AppendLine("         ,A.MEASURE_CNT ");
            ////sb.AppendLine("         ,A.EVA_GUBUN ");
            //sb.AppendLine("         ,(select S_CODE_NM from [SM_FACTORY_COM].[dbo].[T_S_CODE] where L_CODE = '400' and S_CODE = C.ITEM_GUBUN)  AS ITEM_GUBUN_NM "); //제품구분 코드 600
            //sb.AppendLine("         ,(select S_CODE_NM from [SM_FACTORY_COM].[dbo].[T_S_CODE] where L_CODE = '620' and S_CODE = E.EVA_GUBUN)  AS EVA_GUBUN_NM "); //평가구분 코드 620
            //sb.AppendLine("         ,(select S_CODE_NM from [SM_FACTORY_COM].[dbo].[T_S_CODE] where L_CODE = '610' and S_CODE = B.CHECK_YN)  AS CHECK_NM "); //평가구분 코드 620
            //sb.AppendLine("         ,A.MAP ");
            //sb.AppendLine("         ,A.MAP_SIZE ");
            //sb.AppendLine("         ,A.PASS_YN ");
            if (dt != null && dt.Rows.Count > 0)
            {
                txt_chk_date.Text = dt.Rows[0][0].ToString();
                txt_lot_no.Text = dt.Rows[0][1].ToString();
                txt_lot_sub.Text = dt.Rows[0][2].ToString();
                txt_item_cd.Text = dt.Rows[0][3].ToString();
                txt_item_nm.Text = dt.Rows[0][4].ToString();
                txt_spec.Text = dt.Rows[0][5].ToString();
                txt_flow_cd.Text = dt.Rows[0][6].ToString();
                txt_flow_nm.Text = dt.Rows[0][7].ToString();

                txt_item_gubun_nm.Text = dt.Rows[0]["ITEM_GUBUN_NM"].ToString();
                txt_sub_amt.Text = (decimal.Parse(dt.Rows[0]["F_SUB_AMT"].ToString())).ToString("#,0.######");

                txt_measure_cnt.Text = dt.Rows[0]["MEASURE_CNT"].ToString();
                //txt_eva_gubun_nm.Text = dt.Rows[0]["EVA_GUBUN_NM"].ToString();
                txt_check_nm.Text = dt.Rows[0]["CHECK_NM"].ToString();
                txt_check_yn.Text = dt.Rows[0]["CHECK_YN"].ToString();
                txt_f_step.Text = dt.Rows[0]["F_STEP"].ToString();
                txt_exam_test.Text = dt.Rows[0]["EXTERIOR"].ToString();
                //txt_exam_test.Enabled = false;
                if (dt.Rows[0]["PASS_YN"].ToString().Equals("Y"))
                {
                    txt_pass.Text = "합격";
                }
                else if (dt.Rows[0]["PASS_YN"].ToString().Equals("N"))
                {
                    txt_pass.Text = "불합격";
                }
                else
                {
                    txt_pass.Text = "";
                }

                if (txt_exam_test != null || txt_exam_test.Text == "")
                {
                    //button3.Enabled = false;

                }

                if (int.Parse(dt.Rows[0]["MAP_SIZE"].ToString()) > 0)
                {
                    byte[] rs = (byte[])dt.Rows[0]["MAP"]; // byte to string Encoding.UTF8.GetBytes(dt.Rows[0]["MAP"].ToString());
                    MemoryStream ms = new MemoryStream(rs);
                    Image img = Image.FromStream(ms);

                    Image cus_img = ComInfo.pic_resize_logic(pic_exam, img);

                    pic_exam.BackgroundImage = cus_img;
                }
                else
                {
                    pic_exam.BackgroundImage = null;

                }

                flow_chk_detail(dataChkGrid, dgv.Rows[e.RowIndex].Cells[2].Value.ToString(), dgv.Rows[e.RowIndex].Cells[8].Value.ToString(), dgv.Rows[e.RowIndex].Cells[9].Value.ToString(), change_chk, 2);
            }
            else
            {
                MessageBox.Show("데이터 일시 오류 \n 다시 더블클릭 해주시기 바랍니다. ");
                return;
            }
        }
        #endregion 공정검사 더블클릭시 로직


        private void tableLayoutPanel1_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            if (e.Row == 0)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.MediumSeaGreen), e.CellBounds);
            }
        }

        private void tbFlowControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbFlowControl.SelectedIndex == 0)
            {
                chk_req_list();
            }
            else if (tbFlowControl.SelectedIndex == 1)
            {
                     
                chk_complete_list();
            }
            else
            {
                chk_omit_list();
            }
        }
        #endregion flow chk logic


        #region grid logic
        private void ReqChkList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {            
            if (e.RowIndex > -1)
            {


                if (ReqChkList.Rows[e.RowIndex].Cells[14].Value != null)
                    txt_exam_test.Text = ReqChkList.Rows[e.RowIndex].Cells[14].Value.ToString();
                //for (int i = 0; i < dataChkGrid.Rows.Count; i++)
                //{
                //    dataChkGrid.Rows[i].Cells["GRADE"].i = (dataChkGrid.Rows[i].Cells["GRADE"] as DataGridViewComboBoxCell).Items[0];
                //}
                //row.Cells[col.Name].Value = (row.Cells[col.Name] as DataGridViewComboBoxCell).Items[0];
                DataGridView dgv = (DataGridView)sender;
                if (Common.sp_code == "300") //e대양요청사항 (항목 빼주라)
                {
                    dataChkGrid.Columns["GRADE"].Visible = false;

                }

                for (int i = 0; i < dataChkGrid.Rows.Count; i++)
                {


                }
                try
                {
                    bool change_chk = false;
                    string ord_lot_no = txt_lot_no.Text.ToString();
                    string ord_lot_sub = txt_lot_sub.Text.ToString();
                    string ord_f_step = txt_f_step.Text.ToString();

                    if (dgv.Rows[e.RowIndex].Cells[2].Value.ToString().Equals(ord_lot_no)
                        && dgv.Rows[e.RowIndex].Cells[3].Value.ToString().Equals(ord_lot_sub)
                        && dgv.Rows[e.RowIndex].Cells[10].Value.ToString().Equals(ord_f_step)) //같은 내용을 더블클릭 했을 시 
                    {
                        change_chk = false;
                    }
                    else
                    {
                        change_chk = true;
                    }

                    if (dgv.Rows[e.RowIndex].Cells[11].Value.ToString().Equals("S")) //대기
                    {
                        wnDm wDm = new wnDm();
                        DataTable dt = new DataTable();

                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine(" and ITEM_CD = '" + dgv.Rows[e.RowIndex].Cells[8].Value.ToString() + "' ");
                        sb.AppendLine(" and FLOW_CD = '" + dgv.Rows[e.RowIndex].Cells[9].Value.ToString() + "' ");

                        dt = wDm.fn_Flow_Chk_Cnt(sb.ToString());

                        if (dt != null && dt.Rows.Count > 0)
                        {
                            if (int.Parse(dt.Rows[0]["cnt"].ToString()) == 0)
                            {
                                MessageBox.Show("공정검사기준에 등록되지 않았습니다. \n 등록 후 다시 시도하시기 바랍니다. ");
                                return;
                            }
                            sb = new StringBuilder();
                            sb.AppendLine("     and A.LOT_NO = '" + dgv.Rows[e.RowIndex].Cells[2].Value.ToString() + "' ");
                            sb.AppendLine("     and B.LOT_SUB = '" + dgv.Rows[e.RowIndex].Cells[3].Value.ToString() + "' ");
                            sb.AppendLine("     and B.F_STEP = '" + dgv.Rows[e.RowIndex].Cells[10].Value.ToString() + "' ");
                            //sb.AppendLine("     and B.FLOW_CD = '" + dgv.Rows[e.RowIndex].Cells[9].Value.ToString() + "' ");
                            dt = wDm.fn_Flow_Chk_Req_List(sb.ToString());

                            if (dt != null && dt.Rows.Count > 0)
                            {
                                txt_lot_no.Text = dt.Rows[0]["LOT_NO"].ToString();
                                txt_lot_sub.Text = dt.Rows[0]["LOT_SUB"].ToString();
                                txt_item_cd.Text = dt.Rows[0]["ITEM_CD"].ToString();
                                txt_item_nm.Text = dt.Rows[0]["ITEM_NM"].ToString();
                                txt_spec.Text = dt.Rows[0]["SPEC"].ToString();
                                txt_flow_cd.Text = dt.Rows[0]["FLOW_CD"].ToString();
                                txt_flow_nm.Text = dt.Rows[0]["FLOW_NM"].ToString();

                                txt_item_gubun_nm.Text = dt.Rows[0]["ITEM_GUBUN_NM"].ToString();
                                txt_sub_amt.Text = (decimal.Parse(dt.Rows[0]["F_SUB_AMT"].ToString())).ToString("#,0.######");

                                txt_measure_cnt.Text = (decimal.Parse(dt.Rows[0]["F_SUB_AMT"].ToString())).ToString("#,0.######"); // dt.Rows[0]["MEASURE_CNT"].ToString();
                                //txt_eva_gubun_nm.Text = dt.Rows[0]["EVA_GUBUN_NM"].ToString();
                                txt_check_nm.Text = dt.Rows[0]["CHECK_NM"].ToString();
                                txt_check_yn.Text = dt.Rows[0]["CHECK_YN"].ToString();
                                txt_exam_test.Text = dt.Rows[0]["EXTERIOR"].ToString();
                                // txt_exam_test.Enabled = false;

                                if (txt_exam_test != null || txt_exam_test.Text == "")
                                {
                                    //button3.Enabled = false;

                                }
                                txt_f_step.Text = dt.Rows[0]["F_STEP"].ToString();



                                if (int.Parse(dt.Rows[0]["MAP_SIZE"].ToString()) > 0)
                                {
                                    byte[] rs = (byte[])dt.Rows[0]["MAP"]; // byte to string Encoding.UTF8.GetBytes(dt.Rows[0]["MAP"].ToString());
                                    MemoryStream ms = new MemoryStream(rs);
                                    Image img = Image.FromStream(ms);

                                    Image cus_img = ComInfo.pic_resize_logic(pic_exam, img);

                                    pic_exam.BackgroundImage = cus_img;
                                }
                                else
                                {
                                    pic_exam.BackgroundImage = null;

                                }

                                flow_chk_detail(dataChkGrid, dgv.Rows[e.RowIndex].Cells[2].Value.ToString(), dgv.Rows[e.RowIndex].Cells[8].Value.ToString(), dgv.Rows[e.RowIndex].Cells[9].Value.ToString(), change_chk, 1); // 1 -> 대기 , 2-> 미완료 혹은 완료
                            }
                            else
                            {
                                MessageBox.Show("데이터 일시 오류 \n 다시 더블클릭 해주시기 바랍니다. ");
                                return;
                            }
                        }
                    }
                    else //미완료
                    {
                        flow_chk_data_logic(dgv, e, change_chk);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("시스템 에러" + ex.ToString());
                    Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                    msg.ShowDialog();
                }
            }
        }

        private void CompChkList_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (compChkList.Rows[e.RowIndex].Cells[14].Value != null)
            txt_exam_test.Text = compChkList.Rows[e.RowIndex].Cells[14].Value.ToString();

            DataGridView dgv = (DataGridView)sender;

            bool change_chk = false;
            string ord_lot_no = txt_lot_no.Text.ToString();
            string ord_lot_sub = txt_lot_sub.Text.ToString();

            if (dgv.Rows[e.RowIndex].Cells[2].Value.ToString().Equals(ord_lot_no)
                && dgv.Rows[e.RowIndex].Cells[3].Value.ToString().Equals(ord_lot_sub)) //같은 내용을 더블클릭 했을 시 
            {
                change_chk = false;
            }
            else
            {
                change_chk = true;
            }

            flow_chk_data_logic(dgv, e, change_chk);
        }

        private void omitChkList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        // 더블클릭 후 검사성적서 로직 

        private void flow_chk_detail(DataGridView main_dgv, String strLOT, string item_cd, string flow_cd, bool change_chk, int gbn)  // 1 -> 대기 , 2-> 미완료 혹은 완료
        {
            if (change_chk == true)
            {

                for (int i = 0; i < main_dgv.Rows.Count; i++)
                {
                    main_dgv.Rows[i].Cells[startIdx - 1].Value = "";
                }

                if (main_dgv.Columns.Count > startIdx)  //실측치 수 컬럼이 있을 때 제거 후 다시 생성
                {
                    for (int i = main_dgv.Columns.Count - 1; i >= startIdx; i--)
                    {
                        main_dgv.Columns.RemoveAt(main_dgv.Columns.Count - 1);
                    }
                }
                //int measure_cnt = int.Parse(txt_measure_cnt.Text.ToString().Replace(",",""));
                //if (measure_cnt >0)
                //{
                //    for (int j = 0; j < measure_cnt; j++)
                //    {
                //        main_dgv.Columns.Add("CHK" + (j + 1).ToString(), (j + 1).ToString());
                //        main_dgv.Columns[j + startIdx].Width = 40;
                //    }
                //}
                main_dgv.Columns.Add("CHK" + 1.ToString(), "수량");
                main_dgv.Columns["CHK1"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //main_dgv.Columns.Add("memo" + 1.ToString(), "비고");
                //main_dgv.Columns["memo"].Width = 200;

            }

            if (gbn == 1) //대기
            {
                //쿼리 시작 
                wnDm wDm = new wnDm();
                DataTable dt = new DataTable();

                StringBuilder sb = new StringBuilder();
                sb.AppendLine(" and A.ITEM_CD = '" + item_cd + "' ");
                sb.AppendLine(" and A.FLOW_CD = '" + flow_cd + "' ");
                dt = wDm.fn_Flow_Chk_Detail_List(sb.ToString(), gbn);

                main_dgv.RowCount = dt.Rows.Count;
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        main_dgv.Rows[i].Cells["CHK_CD"].Value = dt.Rows[i]["CHK_CD"].ToString();
                        main_dgv.Rows[i].Cells["CHK_ORD"].Value = (i + 1).ToString(); //dt.Rows[i]["CHK_ORD"].ToString();
                        main_dgv.Rows[i].Cells["CHK_NM"].Value = dt.Rows[i]["CHK_NM"].ToString();
                        main_dgv.Rows[i].Cells["CHK_LOC"].Value = dt.Rows[i]["CHK_LOC"].ToString();
                        main_dgv.Rows[i].Cells["RULE_SIZE"].Value = dt.Rows[i]["RULE_SIZE"].ToString();
                        main_dgv.Rows[i].Cells["RULE_LIMIT"].Value = dt.Rows[i]["RULE_LIMIT"].ToString();
                        main_dgv.Rows[i].Cells["MEASURE_APP"].Value = dt.Rows[i]["MEASURE_APP"].ToString();
                        main_dgv.Rows[i].Cells["EVA_GUBUN_NM"].Value = dt.Rows[i]["EVA_GUBUN_NM"].ToString();
                        main_dgv.Rows[i].Cells["comment"].Value = dt.Rows[i]["COMMENT"].ToString();

                        //main_dgv.Rows[i].Cells["LOWER_SIZE"].Value = (decimal.Parse(dt.Rows[i]["LOWER_SIZE"].ToString())).ToString("#,0.######");
                        //main_dgv.Rows[i].Cells["UPPER_SIZE"].Value = (decimal.Parse(dt.Rows[i]["UPPER_SIZE"].ToString())).ToString("#,0.######");
                        //main_dgv.Rows[i].Cells["LOWER_SELF"].Value = (decimal.Parse(dt.Rows[i]["LOWER_SELF"].ToString())).ToString("#,0.######");
                        //main_dgv.Rows[i].Cells["UPPER_SELF"].Value = (decimal.Parse(dt.Rows[i]["UPPER_SELF"].ToString())).ToString("#,0.######");
                    }
                }
                else
                {
                    MessageBox.Show("데이터 일시 오류");
                }
            }
            else
            {
                lblSearch.Text = "Searching ...";
                lblSearch.Visible = true;
                Application.DoEvents();

                //쿼리 시작 
                wnDm wDm = new wnDm();
                DataTable dt = new DataTable();

                StringBuilder sb = new StringBuilder();
                sb.AppendLine(" and A.LOT_NO = '" + txt_lot_no.Text.ToString() + "' ");
                sb.AppendLine(" and A.LOT_SUB = '" + txt_lot_sub.Text.ToString() + "' ");
                sb.AppendLine(" and A.F_STEP = '" + txt_f_step.Text.ToString() + "' ");
                dt = wDm.fn_Flow_Chk_Detail_List(sb.ToString(), gbn);

                main_dgv.RowCount = dt.Rows.Count;
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        main_dgv.Rows[i].Cells["CHK_CD"].Value = dt.Rows[i]["CHK_CD"].ToString();
                        main_dgv.Rows[i].Cells["CHK_ORD"].Value = (i + 1).ToString(); // dt.Rows[i]["CHK_ORD"].ToString();
                        main_dgv.Rows[i].Cells["CHK_NM"].Value = dt.Rows[i]["CHK_NM"].ToString();
                        main_dgv.Rows[i].Cells["CHK_LOC"].Value = dt.Rows[i]["CHK_LOC"].ToString();
                        main_dgv.Rows[i].Cells["RULE_SIZE"].Value = dt.Rows[i]["RULE_SIZE"].ToString();
                        main_dgv.Rows[i].Cells["RULE_LIMIT"].Value = dt.Rows[i]["RULE_LIMIT"].ToString();
                        main_dgv.Rows[i].Cells["MEASURE_APP"].Value = dt.Rows[i]["MEASURE_APP"].ToString();
                        main_dgv.Rows[i].Cells["EVA_GUBUN_NM"].Value = dt.Rows[i]["EVA_GUBUN_NM"].ToString();

                        main_dgv.Rows[i].Cells["GRADE"].Value = dt.Rows[i]["GRADE"].ToString();

                        sb = new StringBuilder();

                        sb.AppendLine(" and A.LOT_NO = '" + txt_lot_no.Text.ToString() + "' ");
                        sb.AppendLine(" and A.LOT_SUB = '" + txt_lot_sub.Text.ToString() + "' ");
                        sb.AppendLine(" and A.F_STEP = '" + txt_f_step.Text.ToString() + "' ");
                        sb.AppendLine(" and A.CHK_CD = '" + main_dgv.Rows[i].Cells["CHK_CD"].Value.ToString() + "' ");

                        DataTable dt3 = new DataTable();
                        dt3 = wDm.fn_Flow_Chk_Exam_Value(sb.ToString());

                        if (dt != null && dt.Rows.Count > 0)
                        {
                            int k = 0;
                            for (int j = startIdx; j < main_dgv.ColumnCount; j++)
                            {
                                main_dgv.Rows[i].Cells[j].Value = dt3.Rows[k]["CHK_VALUE"].ToString();
                                k++;
                            }
                        }

                        //main_dgv.Rows[i].Cells["LOWER_SIZE"].Value = (decimal.Parse(dt.Rows[i]["LOWER_SIZE"].ToString())).ToString("#,0.######");
                        //main_dgv.Rows[i].Cells["UPPER_SIZE"].Value = (decimal.Parse(dt.Rows[i]["UPPER_SIZE"].ToString())).ToString("#,0.######");
                        //main_dgv.Rows[i].Cells["LOWER_SELF"].Value = (decimal.Parse(dt.Rows[i]["LOWER_SELF"].ToString())).ToString("#,0.######");
                        //main_dgv.Rows[i].Cells["UPPER_SELF"].Value = (decimal.Parse(dt.Rows[i]["UPPER_SELF"].ToString())).ToString("#,0.######");
                    }

                }
                else
                {
                    MessageBox.Show("데이터 일시 오류");
                }
                lblSearch.Visible = false;
            }
        }


        #endregion grid logic

        #region common logic

        private void pic_logic(PictureBox pic)
        {
            ofd.Filter = "*.png|*.jpg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //이미지 
                image = Image.FromFile(ofd.FileName);
                //이미지 경로 
                path = ofd.FileName;

                string sTxt = path.Substring(path.Length - 3, 3);

                if (sTxt != "jpg" && sTxt != "JPG" && sTxt != "png" && sTxt != "PNG" && sTxt != "pdf" && sTxt != "PDF")
                {
                    MessageBox.Show("이미지 파일만 선택 가능합니다..");
                    return;
                }

                /* 이미지 리사이즈 */
                Image cus_img = ComInfo.pic_resize_logic(pic, image);
                //픽쳐박스에 이미지를 띄운다
                pic.BackgroundImage = cus_img;
            }
        }

        private void compChkList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            //if (decimal.Parse(dgv.Rows[e.RowIndex].Cells["E_CNT"].Value.ToString()) > 26)
            //{
            //    MessageBox.Show("수량이 너무 많습니다. 문의바람");
            //    return;
            //}


            bool change_chk = false;
            string ord_lot_no = txt_lot_no.Text.ToString();
            string ord_lot_sub = txt_lot_sub.Text.ToString();

            if (dgv.Rows[e.RowIndex].Cells[2].Value.ToString().Equals(ord_lot_no)
                && dgv.Rows[e.RowIndex].Cells[3].Value.ToString().Equals(ord_lot_sub)) //같은 내용을 더블클릭 했을 시 
            {
                change_chk = false;
            }
            else
            {
                change_chk = true;
            }

            flow_chk_data_logic(dgv, e, change_chk);
        }

        //private byte[] GetImage(string path)
        //{

        //    FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read);
        //    BinaryReader reader = new BinaryReader(stream);

        //    byte[] image = reader.ReadBytes((int)stream.Length);
        //    reader.Close();
        //    stream.Close();

        //    return image;
        //}

        #endregion common logic




        public void updateFlowChkExam(int amt)
        {
            String LLotNo = txt_lot_no.Text.ToString();
            try
            {
                wnDm wDm = new wnDm();

                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb.AppendLine("update F_WORK_FLOW_DETAIL set POOR_AMT = "+amt+" where LOT_NO='" + LLotNo + "' and FLOW_CD='0006'");

                SqlCommand sCommand = new SqlCommand(sb.ToString());

                int qResult = wAdo.SqlCommandEtc(sCommand, "insert_RAW_CHK_EXAM_TB");

          
            }
            catch (Exception e)
            {
                wnLog.writeLog(wnLog.LOG_ERROR, e.Message + " - " + e.ToString());
                Popup.pop오류리포트 msg = new pop오류리포트(e.Message + " - " + e.ToString());
                msg.ShowDialog();
                return ;
            }
        }

        private void frm검사성적서등록_Enter(object sender, EventArgs e)
        {
            chk_req_list();
          //  tbFlowControl.sele

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //파일오픈창 생성 및 설정
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "업로드 파일 선택";
            ofd.FileName = "Upload_File";
            ofd.Filter = "모든 파일 (*.*) | *.*";
            //파일 오픈창 로드
            DialogResult dr = ofd.ShowDialog();
            //OK버튼 클릭시
            if (dr == DialogResult.OK)
            {
                //if (txt_root_path.Text.Equals("미등록"))
                //{
                //    MessageBox.Show("작업 경로를 먼저 등록해주시기 바랍니다");
                //    return;
                //}

                fileName = ofd.SafeFileName;
                fileFullName = ofd.FileName;
                filePath = fileFullName.Replace(fileName, "");

                txt_exam_test.Text = fileFullName;
            }
            else if (dr == DialogResult.Cancel)
            {
                return;
            }
            return;
        }

        private void txt_exam_test_DoubleClick(object sender, EventArgs e)
        {

            
        }

        private void btn_FileOpen_Click(object sender, EventArgs e)
        {
            string path = txt_exam_test.Text.ToString();
            if (System.IO.File.Exists(path))
            {
                System.Diagnostics.Process.Start(path);
            }
            else
            {
                MessageBox.Show("문서를 확인해주세요");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataChkGrid.Rows.Clear();
        }
    }
}
