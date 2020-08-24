using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MES.Controls;
using MES.CLS;
using System.Net;
using System.IO;

namespace MES.P50_QUA
{
    public partial class frm주문서등록 : Form
    {
        string fName;
        private wnGConstant wConst = new wnGConstant();
        private ComInfo comInfo = new ComInfo();
        private string pojang = "";
        private string jumun_gbn = "1";
        private string old_cust_nm = "";
        private string vat = "";
        private double talMoney;
        //private string old_item_nm = "";
        //private string oldValue = "";
        //private string txt_totalamt;
        //private string txt_price;
        //private string txt_totalmoney;
        private DataGridView del_conItemGrid = new DataGridView();
        private string input_date = "";

        private string f_fullName = "";
        private string user = "anonymous";
        private string pwd = "";




        public frm주문서등록()
        {
            InitializeComponent();

            this.conItemGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grid_KeyDown);
            this.conItemGrid.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.grid_RowsRemoved);
            this.conItemGrid.CellValueChanged += new DataGridViewCellEventHandler(grid_CellValueChanged);
            this.conItemGrid.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.grid_RowsAdded);
            this.conItemGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellEndEdit);
            this.conItemGrid.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.grid_EditingControlShowing);

        }

        private void frm주문서등록_Load(object sender, EventArgs e)
        {
            start_date.Text = DateTime.Today.AddMonths(-1).ToString("yyyy-MM-dd");

            txt_cust_nm.TabIndex = 1;
            delivery_proc_cd.TabIndex = 2;
            txt_comment.TabIndex = 3;
            init_ComboBox();
            srch_logic();
            del_conItemGrid.AllowUserToAddRows = false;
            del_conItemGrid.Columns.Add("JUMUN_DATE", "JUMUN_DATE");
            del_conItemGrid.Columns.Add("JUMUN_CD", "JUMUN_CD");
            del_conItemGrid.Columns.Add("SEQ", "SEQ");

            conItemGrid.Rows.Add();

            ComInfo.gridHeaderSet(dataJumunGrid); //grid header setting 참고 바람 . (유정훈)
            ComInfo.gridHeaderSet(conItemGrid); //grid header setting 참고 바람 . (유정훈)
            resetSetting();
            onlyView();

            //TAX_I.ValueMember = "코드";
            //TAX_I.DisplayMember = "명칭";
            //string sqlQuery = new scQuery().queryTSCode("410");
            //wConst.ComboBox_Read_NoBlank(TAX_I, sqlQuery);


        }

        private void srch_logic()
        {
            jumun_list(dataJumunGrid, "and A.INPUT_DATE >= '" + start_date.Text.ToString() + "' and  A.INPUT_DATE <= '" + end_date.Text.ToString() + "'");
        }


        private void grid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            conDataGridView grd = (conDataGridView)sender;

            grd.Rows[e.RowIndex].Cells[0].Value = false;

            //wConst.init_RowText(grd, e.RowIndex);

            for (int kk = 0; kk < grd.Rows.Count; kk++)
            {
                grd.Rows[kk].Cells[1].Value = (kk + 1).ToString();
            }
        }

        //제품등록그리드 셀 이벤트 (나중에)
        private void grid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            conDataGridView grd = (conDataGridView)sender;
            DataGridViewCell cell = grd[e.ColumnIndex, e.RowIndex];
            ComInfo cInfo = new ComInfo();
            cell.Style.BackColor = Color.White;

            if (conItemGrid.Rows[e.RowIndex].Cells["TOTAL_AMT"].Value != null && conItemGrid.Rows[e.RowIndex].Cells["PRICE"].Value != null)
            {
                decimal price = decimal.Parse((decimal.Parse(conItemGrid.Rows[e.RowIndex].Cells["PRICE"].Value.ToString())).ToString("#,0.######"));
                decimal amount = decimal.Parse((decimal.Parse(conItemGrid.Rows[e.RowIndex].Cells["TOTAL_AMT"].Value.ToString())).ToString("#,0.######"));
                decimal total = Math.Floor(amount) * Math.Floor(price);
                conItemGrid.Rows[e.RowIndex].Cells["TOTAL_MONEY"].Value = total.ToString("#,0.######");

                //decimal.Parse(conItemGrid.Rows[e.RowIndex].Cells["TOTAL_MONEY"].ToString()).ToString("#,0.######");
            }

            if (e.RowIndex > -1)
            {
                #region 공통 그리드 체크
                if (grd.Columns[e.ColumnIndex].ToolTipText.IndexOf("명칭") >= 0 && grd._KeyInput == "enter")
                {
                    itemSrchRsLogic(grd, e); //제품 팝업 검색 공통 로직 

                }
                #endregion 공통 그리드 체크
            }

        }

        #region btn Logic
        private void btn_NEW_Click(object sender, EventArgs e)
        {
            resetSetting();
        }
        private void btn_plus_Click(object sender, EventArgs e)
        {
            ItemJumunGridAdd();
        }

        private void btn_minus_Click(object sender, EventArgs e)
        {

            minus_logic(conItemGrid);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion btn_Logic

        private void init_ComboBox()
        {
            string sqlQuery = "";

            //납품처리방법
            delivery_proc_cd.ValueMember = "코드";
            delivery_proc_cd.DisplayMember = "명칭";
            //sqlQuery = comInfo.querydelivery_proc();
            //wConst.ComboBox_Read_NoBlank(delivery_proc_cd, sqlQuery);

            cmb_comp_yn.ValueMember = "코드";
            cmb_comp_yn.DisplayMember = "명칭";
            //sqlQuery = comInfo.queryCompYnAll();
            //wConst.ComboBox_Read_NoBlank(cmb_comp_yn, sqlQuery);

            //포장방법 
            cmb_pojang.ValueMember = "코드";
            cmb_pojang.DisplayMember = "명칭";
            //sqlQuery = comInfo.queryPojang_way();
            //wConst.ComboBox_Read_NoBlank(cmb_pojang, sqlQuery);

            //주문구분
            cmb_jumun_gubun.ValueMember = "코드";
            cmb_jumun_gubun.DisplayMember = "명칭";
            //sqlQuery = comInfo.queryJumun_gubun();
            //wConst.ComboBox_Read_NoBlank(cmb_jumun_gubun, sqlQuery);


        }

        private void today_logic()
        {
            jumun_list(dataJumunGrid, "and convert(varchar(10), A.INTIME, 120) = convert(varchar(10), getDate(), 120) ");
        }

        private void jumun_list(DataGridView dgv, string condition)
        {
            try
            {
                DataTable dt = new DataTable();
                //dt = qCtrl.fn_Jumun_List(condition);

                if (dt != null && dt.Rows.Count > 0)
                {
                    dgv.RowCount = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgv.Rows[i].Cells[0].Value = dt.Rows[i]["INPUT_DATE"].ToString();
                        dgv.Rows[i].Cells[1].Value = dt.Rows[i]["INPUT_CD"].ToString();
                        dgv.Rows[i].Cells[2].Value = dt.Rows[i]["CUST_NM"].ToString();
                        dgv.Rows[i].Cells[3].Value = (decimal.Parse(dt.Rows[i]["TOTAL_AMT"].ToString())).ToString("#,0.######");
                        dgv.Rows[i].Cells[4].Value = dt.Rows[i]["COMPLETE_YN"].ToString();
                        dgv.Rows[i].Cells[5].Value = dt.Rows[i]["JUMUN_DATE"].ToString();
                        if (dt.Rows[i]["COM_COUNT"] != null && dt.Rows[i]["COM_COUNT"].ToString() != "")
                        {
                            dgv.Rows[i].Cells["COM_YN"].Value = "Y";
                        }
                        else
                        {
                            dgv.Rows[i].Cells["COM_YN"].Value = "N";
                        }

                        // dgv.Rows[i].Cells["INSTAFF"].Value = dt.Rows[i]["INSTAFF"].ToString();
                        // dgv.Rows[i].Cells["UPSTAFF"].Value = dt.Rows[i]["UPSTAFF"].ToString();
                    }
                }
                else
                {
                    dgv.Rows.Clear();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("시스템 오류" + e.ToString());
            }
        }

        private void btnCustSrch_Click_Click(object sender, EventArgs e)
        {

        }




        private void resetSetting()
        {
            btnSave.Text = "저장";
            btnDelete.Enabled = false;
            lbl_jumun_gbn.Text = "";
            btnDelete.Enabled = false;
            dtp_input_date.Text = DateTime.Now.ToString("yyyy-MM-dd");
            dtp_jumun_date.Text = DateTime.Now.ToString("yyyy-MM-dd");
            lbl_input_cd.Text = "";
            txt_cust_cd.Text = "";
            txt_cust_nm.Text = "";
            txt_comment.Text = "";
            delivery_req_date.Text = DateTime.Today.AddDays(+3).ToString("yyyy-MM-dd");
            delivery_proc_cd.SelectedIndex = 0;
            conItemGrid.Rows.Clear();
            del_conItemGrid.Rows.Clear();
            btn_out.Enabled = false;
            lbl_jumun_num.Text = "";
            vat = "";
            lbl_upstaff.Text = "";
            lbl_instaff.Text = "";
            input_date = "";
        }

        private void ItemJumunGridAdd()
        {
            conItemGrid.Rows.Add();
            //conItemGrid.Rows[conItemGrid.Rows.Count - 1].Cells["TOTAL_AMT"].Value = "0";
            //conItemGrid.Rows[conItemGrid.Rows.Count - 1].Cells["PRICE"].Value = "0";
            //conItemGrid.Rows[conItemGrid.Rows.Count - 1].Cells["TOTAL_MONEY"].Value = "0";
        }

        private void minus_logic(conDataGridView dgv)
        {
            if (dgv.Rows.Count > 0)
            {

                if ((string)dgv.SelectedRows[0].Cells["SEQ"].Value != "" && dgv.SelectedRows[0].Cells["SEQ"].Value != null)
                {

                    int cnt = del_conItemGrid.Rows.Count;


                    del_conItemGrid.Rows.Add();


                    del_conItemGrid.Rows[del_conItemGrid.Rows.Count - 1].Cells["JUMUN_DATE"].Value = dtp_input_date.Text.ToString();
                    del_conItemGrid.Rows[del_conItemGrid.Rows.Count - 1].Cells["JUMUN_CD"].Value = lbl_input_cd.Text.ToString();
                    del_conItemGrid.Rows[del_conItemGrid.Rows.Count - 1].Cells["SEQ"].Value = dgv.SelectedRows[0].Cells["SEQ"].Value;



                    //del_conItemGrid.Rows[del_conItemGrid.Rows.Count - 1].Cells["JUMUN_DATE"].Value = conItemGrid.Rows[i].Cells["JUMUN_DATE"].Value.ToString();
                    //del_conItemGrid.Rows[del_conItemGrid.Rows.Count - 1].Cells["JUMUN_CD"].Value = conItemGrid.Rows[i].Cells["JUMUN_CD"].Value.ToString();
                    //del_conItemGrid.Rows[del_conItemGrid.Rows.Count - 1].Cells["SEQ"].Value = conItemGrid.Rows[i].Cells["SEQ"].Value;


                }


            }
            if (dgv.Rows.Count > 0)
            {
                dgv.Rows.RemoveAt(dgv.SelectedRows[0].Index);
            }
            if (dgv.Rows.Count > 0)
            {
                dgv.CurrentCell = dgv[1, dgv.Rows.Count - 1];
            }
        }


        private void btnNew_Click(object sender, EventArgs e)
        {
            if (!txt_cust_cd.Text.ToString().Equals(""))
            {
                ComInfo cInfo = new ComInfo();
                //DialogResult msgOk = cInfo.resetConfirm();
                //if (msgOk == DialogResult.No)
                //{
                //    return;
                //}
            }
            resetSetting();
            NoonlyView();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (btnSave.Text.Equals("수정"))
            {
                if (MessageBox.Show("수정하시겠습니까??", "수정알림", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    btnSave.Text = "저장";
                    btnDelete.Enabled = true;
                    NoonlyView();
                }
            }
            else
            {
                save_logic();

            }


        }


        private void save_logic()
        {
            //if (lbl_item_nm.Text.ToString().Equals(""))
            //{
            //    MessageBox.Show("제품을 선택하시기 바랍니다.");
            //    return;

            //}
            if (input_date.Equals(""))
            {
                input_date = DateTime.Today.ToString("yyyy-MM-dd");
            }

            if (txt_cust_nm.Text.ToString().Equals(""))
            {
                MessageBox.Show("거래처를 선택하시기 바랍니다.");
                return;
            }
            if (delivery_proc_cd.SelectedValue == null) delivery_proc_cd.SelectedValue = "";
            if ((string)delivery_proc_cd.SelectedValue == "")
            {
                MessageBox.Show("납품처리방법을 선택해주세요:");
                return;
            }
            if (conItemGrid.Rows.Count == 0)
            {
                MessageBox.Show("주문서 등록에 들어 갈 제품이 1개 이상은 있어야 합니다.");
                return;
            }
            if (delivery_proc_cd.SelectedValue.ToString().Equals("2"))
            {
                for (int i = 0; i > conItemGrid.Rows.Count; i++)
                {
                    if (int.Parse(conItemGrid.Rows[i].Cells["STOCK"].Value.ToString().Replace(",", "")) < int.Parse(conItemGrid.Rows[i].Cells["EA_AMT"].Value.ToString().Replace(",", "")))
                    {
                        MessageBox.Show("재고량이 부족합니다.");
                        return;
                    }
                }
            }

            if (conItemGrid.Rows.Count > 0)
            {
                int cnt = 0;
                int grid_cnt = conItemGrid.Rows.Count;
                for (int i = 0; i < grid_cnt; i++)
                {
                    string txt_raw_mat_cd = (string)conItemGrid.Rows[i - cnt].Cells[2].Value;


                    if (txt_raw_mat_cd == "" || txt_raw_mat_cd == null)  //마지막 행에 원부재료코드가 없을 경우 제거
                    {
                        conItemGrid.Rows.RemoveAt(i - cnt);
                        cnt++;
                    }

                }

                if (conItemGrid.Rows.Count == 0)
                {
                    MessageBox.Show("주문서 등록에 들어 갈 제품이 1개 이상은 있어야 합니다.");
                    return;
                }
            }
            if (cmb_pojang.SelectedValue == null)
            {
                pojang = "";
            }
            else
            {
                pojang = cmb_pojang.SelectedValue.ToString();
            }



            if (lbl_jumun_gbn.Text != "1")
            {
                //string lot_no = dtp_input_date.Text.ToString().Replace("-", "");
                ////input_date = DateTime.Today.ToString("yyyy-MM-dd");
                ////lot_no = lot_no.Substring(2).ToString();
                
                //int rsNum = qCtrl.insertJumun(
                //        input_date,
                //        lbl_input_cd.Text.ToString(),
                //        txt_cust_cd.Text.ToString(),
                //        delivery_req_date.Text.ToString(),
                //        dtp_jumun_date.Text.ToString(),
                //        jumun_gbn,
                //        delivery_proc_cd.SelectedValue.ToString(),
                //        pojang,
                //        txt_comment.Text.ToString(),
                //        conItemGrid,
                //        fName
                //       );

                //if (rsNum == 0)
                //{
                //    if (!f_fullName.Equals(""))
                //    {
                //        ftpSaveLogic();
                //    }

                //    StringBuilder sb = new StringBuilder();
                //    sb.AppendLine("and A.INPUT_DATE >= '" + start_date.Text.ToString() + "' and  A.INPUT_DATE <= '" + end_date.Text.ToString() + "'");

                //    jumun_list(dataJumunGrid, sb.ToString());

                //    btnSave.Text = "수정";
                //    btnDelete.Enabled = false;
                //    onlyView();

                //    if (lbl_input_cd.Text == null || lbl_input_cd.Text.Equals(""))
                //    {
                //        int max = 0;
                //        for (int i = 0; i < dataJumunGrid.Rows.Count; i++)
                //        {
                //            if (dtp_input_date.Text.Equals(dataJumunGrid.Rows[i].Cells[0].Value.ToString()))
                //            {
                //                if (max < int.Parse(dataJumunGrid.Rows[i].Cells[1].Value.ToString()))
                //                {
                //                    max = int.Parse(dataJumunGrid.Rows[i].Cells[1].Value.ToString());
                //                }
                //            }
                //        }
                //        lbl_input_cd.Text = max.ToString();

                //    }
                //    JumunDetail2();
                //    MessageBox.Show("성공적으로 등록하였습니다.");


                //}
                //else if (rsNum == 1)
                //    MessageBox.Show("저장에 실패하였습니다");
                //else if (rsNum == 2)
                //    MessageBox.Show("SQL COMMAND 에러");
                //else
                //    MessageBox.Show("Exception 에러1");
            }
            else
            {

                //string change;
                //change = Input.ShowDialog("수정사유를 입력하세요", "수정사유입력", null, 500, 500);

                //if (change == null || change == "")
                //{
                //    MessageBox.Show("수정사유를 입력해주세요");
                //}
                //else
                //{

                //    //int rsNum = qCtrl.updateJumun(
                //    //        input_date,
                //    //        lbl_input_cd.Text.ToString(),
                //    //        txt_cust_cd.Text.ToString(),
                //    //        delivery_req_date.Text.ToString(),
                //    //        dtp_jumun_date.Text,
                //    //        jumun_gbn,
                //    //        delivery_proc_cd.SelectedValue.ToString(),
                //    //        pojang,
                //    //        txt_comment.Text.ToString(),
                //    //        dataJumunGrid,
                //    //        conItemGrid,
                //    //        del_conItemGrid,
                //    //        change,
                //    //        fName
                //    //        );

                //    if (rsNum == 0)
                //    {
                //        if (!f_fullName.Equals(""))
                //        {
                //            ftpSaveLogic();
                //        }
                //        StringBuilder sb = new StringBuilder();
                //        sb.AppendLine("and A.INPUT_DATE >= '" + start_date.Text.ToString() + "' and  A.INPUT_DATE <= '" + end_date.Text.ToString() + "'");

                //        jumun_list(dataJumunGrid, sb.ToString());
                //        btnSave.Text = "수정";
                //        btnDelete.Enabled = false;
                //        onlyView();
                //        MessageBox.Show("성공적으로 수정하였습니다.");
                //    }
                //    else if (rsNum == 1)
                //        MessageBox.Show("저장에 실패하였습니다");
                //    else if (rsNum == 2)
                //        MessageBox.Show("SQL COMMAND 에러");
                //    else
                //        MessageBox.Show("Exception 에러1");
                //}
            }
        }


        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            jumun_del();
        }

        private void jumun_del()
        {
            //  MessageBox.Show(dataJumunGrid.SelectedRows.ToString());


            ComInfo comInfo = new ComInfo();
            DialogResult msgOk = comInfo.deleteConfrim("주문서 등록 ", dataJumunGrid.SelectedRows[0].Cells[0].Value.ToString() + " - " + dataJumunGrid.SelectedRows[0].Cells[1].Value.ToString());

            if (msgOk == DialogResult.No)
            {
                return;
            }

            string delete;
            //delete = Input.ShowDialog("삭제사유를 입력하세요", "삭제사유입력", null, 500, 500);
            //if (delete == null || delete == "")
            //{
            //    MessageBox.Show("수정사유를 입력해주세요");
            //}
            //else
            //{

                //int rsNum = qCtrl.deleteJumun(dataJumunGrid.SelectedRows[0].Cells[0].Value.ToString(), dataJumunGrid.SelectedRows[0].Cells[1].Value.ToString(), delete);
                //if (rsNum == 0)
                //{
                //    resetSetting();

                //    jumun_list(dataJumunGrid, "and A.INPUT_DATE >= '" + start_date.Text.ToString() + "' and  A.INPUT_DATE <= '" + end_date.Text.ToString() + "'");

                //    //work_list(dataWorkGrid, "where convert(varchar(10), A.INTIME, 120) = convert(varchar(10), getDate(), 120) ");

                //    //today_logic();


                //    MessageBox.Show("성공적으로 삭제하였습니다.");


                //}
                //else
                //{
                //    MessageBox.Show("삭제에 실패하였습니다.");
                //}
            //}
        }

        private void itemGridAdd()
        {
            conItemGrid.Rows.Add();
            conItemGrid.Rows[conItemGrid.Rows.Count - 1].Cells["TOTAL_AMT"].Value = "0";
            conItemGrid.Rows[conItemGrid.Rows.Count - 1].Cells["PRICE"].Value = "0";
            conItemGrid.Rows[conItemGrid.Rows.Count - 1].Cells["TOTAL_MONEY"].Value = "0";
        }

        private void grid_KeyDown(object sender, KeyEventArgs e)
        {
            // Edit 모드가 아닐때, 작동함.

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
        private void grid_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            conDataGridView grd = (conDataGridView)sender;

            for (int kk = 0; kk < grd.Rows.Count; kk++)
            {
                grd.Rows[kk].Cells[1].Value = (kk + 1).ToString();
            }
        }
        private void grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex < 0) return;

            conDataGridView grd = (conDataGridView)sender;

            // 수량, 금액 = 0 자료 구분
            grd.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Gray;
            grd.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Gray;

            if (conItemGrid.Columns[e.ColumnIndex].Name == "PRICE")
            {
                conItemGrid.Rows[e.RowIndex].Cells["PRICE"].Value = (decimal.Parse(conItemGrid.Rows[e.RowIndex].Cells["PRICE"].Value.ToString())).ToString("#,0.######");
            }
        }

        private void dataJumunGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                onlyView();
                btnSave.Text = "수정";
                btnDelete.Enabled = false;
                del_conItemGrid.Rows.Clear();
                JumunDetail(dataJumunGrid, e);
            }
        }

        private void JumunDetail(DataGridView dgv, DataGridViewCellEventArgs e)
        {
            //등록일,발주여부,제품수,순서
            //btnDelete.Enabled = true;
            //lbl_gbn = "1";

            lbl_jumun_gbn.Text = "1";
           // dtp_input_date.Enabled = false;

            JumunMain(dgv, e.RowIndex); //메인 뿌리기 
            JumunDetail2(); //제품 상세 뿌리기 
        }

        private void JumunMain(DataGridView dgv, int idx)
        {
            //wnDm wDm = new wnDm();
            DataTable dt = null;
            //dt = qCtrl.fn_Jumun_List("and A.INPUT_DATE = '" + dgv.Rows[idx].Cells[0].Value.ToString() + "' and  A.INPUT_CD = '" + dgv.Rows[idx].Cells[1].Value.ToString() + "' ");

            if (dt != null && dt.Rows.Count > 0)
            {
                dtp_input_date.Text = dt.Rows[0]["INPUT_DATE"].ToString();
                input_date = dt.Rows[0]["INPUT_DATE"].ToString();
                lbl_input_cd.Text = dt.Rows[0]["INPUT_CD"].ToString();
                dtp_jumun_date.Text = dt.Rows[0]["JUMUN_DATE"].ToString();
                txt_cust_cd.Text = dt.Rows[0]["CUST_CD"].ToString();
                txt_cust_nm.Text = dt.Rows[0]["CUST_NM"].ToString();
                delivery_proc_cd.SelectedValue = dt.Rows[0]["DELIVERY_PROC_CD"].ToString();
                delivery_req_date.Text = dt.Rows[0]["DELIVERY_REQ_DATE"].ToString();
                cmb_jumun_gubun.SelectedValue = dt.Rows[0]["JUMUN_GUBUN"].ToString();
                cmb_pojang.SelectedValue = dt.Rows[0]["PACK_CD"].ToString();
                vat = dt.Rows[0]["VAT_CD"].ToString();
                lbl_vat_nm.Text = dt.Rows[0]["VAT_NM"].ToString();
                lbl_jumun_num.Text = "주문번호 :" + dt.Rows[0]["JUMUN_NUM"].ToString();
                txt_comment.Text = dt.Rows[0]["COMMENT"].ToString();
                if (dt.Rows[0]["JUMUN_FILE"] != null)
                {
                    txt_file.Text = dt.Rows[0]["JUMUN_FILE"].ToString();
                    txt_file.Visible = true;
                }
                //if (vat == "0")
                //    lbl_vat.Text = "부가세별도";
                //else if (vat == "1")
                //    lbl_vat.Text = "부가세포함";
                //else if (vat == "2")
                //    lbl_vat.Text = "영세율";

                //this.cmb_base_unit.GetItemText(this.cmb_base_unit.SelectedItem);
                onlyView();

                chk_complete_yn.Checked = dt.Rows[0]["COMPLETE_YN"].ToString().Equals("Y") ? true : false;

                lbl_instaff.Visible = true;
                lbl_instaff.Text = "동록자 :" + dt.Rows[0]["INSTAFF"].ToString();

                if (!dt.Rows[0]["UPSTAFF"].ToString().Equals("") && dt.Rows[0]["UPSTAFF"] != null)
                {
                    lbl_upstaff.Visible = true;
                    lbl_upstaff.Text = "수정자 :" + dt.Rows[0]["UPSTAFF"].ToString();
                }

            }
        }
        private void JumunDetail2()
        {
            DataTable dt = null;

            //dt = wDm.fn_Work_Rm_Default_List("where A.JUMUN_DATE = '" + txt_jumun_date.Text.ToString() + "' and A.JUMUN_CD = '" + lbl_jumun_cd.Text.ToString() + "' ");
            //dt = qCtrl.fn_Jumun_Rm_Default_List("where A.INPUT_DATE = '" + input_date + "' and A.INPUT_CD = '" + lbl_input_cd.Text.ToString() + "' ");
            if (dt != null && dt.Rows.Count > 0)
            {

                this.conItemGrid.RowCount = dt.Rows.Count;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //제품명,규격,단위,수량,단가,금액
                    //string t_amt = string.Format("{0:#.##}", 100.2);
                    //rmOrderGrid.Rows.Add();
                    delivery_proc_cd.Text = dt.Rows[i]["DELIVERY_PROC_GUBUN"].ToString();
                    conItemGrid.Rows[i].Cells[2].Value = dt.Rows[i]["ITEM_NM"].ToString(); //제품명
                    conItemGrid.Rows[i].Cells[3].Value = dt.Rows[i]["SPEC"].ToString(); //규격
                    //conItemGrid.Rows[i].Cells[4].Value = dt.Rows[i]["UNIT_CD"].ToString(); //대박스,소박스,낱개인지 단위
                    conItemGrid.Rows[i].Cells["UNIT_CD"].Value = dt.Rows[i]["UNIT_CD"].ToString();
                    conItemGrid.Rows[i].Cells["ITEM_CD"].Value = dt.Rows[i]["ITEM_CD"].ToString(); //제품명
                    conItemGrid.Rows[i].Cells["SEQ"].Value = dt.Rows[i]["SEQ"].ToString(); //제품명
                    conItemGrid.Rows[i].Cells["TAX_CD"].Value = dt.Rows[i]["TAX_CD"].ToString();
                    conItemGrid.Rows[i].Cells["TAX_NM"].Value = dt.Rows[i]["TAX_NM"].ToString(); //2020-02-19 유정훈 S_CODE_NM 금지.. 이유 -> 가독성 떨어짐 
                    conItemGrid.Rows[i].Cells["INPUT_AMT"].Value = dt.Rows[i]["INPUT_AMT"].ToString();
                    DataGridViewComboBoxCell unit = (DataGridViewComboBoxCell)conItemGrid.Rows[i].Cells["UNIT_NM"];
                    //단위
                    unit.ValueMember = "코드";
                    unit.DisplayMember = "명칭";
                    //string sqlQuery = comInfo.queryItemUnit(dt.Rows[i]["ITEM_CD"].ToString());
                    //wConst.ComboBox_Read_NoBlank(unit, sqlQuery);

                    //conItemGrid.Rows[i].Cells[5].Value = "123";
                    //conItemGrid.Rows[i].Cells[6].Value = "1000";
                    //conItemGrid.Rows[i].Cells[7].Value = "123000";
                    conItemGrid.Rows[i].Cells["UNIT_NM"].Value = int.Parse(dt.Rows[i]["UNIT_CD"].ToString()); //대박스,소박스,낱개인지 단위
                    //unit.Value = dt.Rows[i]["UNIT_CD"].ToString(); //대박스,소박스,낱개인지 단위
                    conItemGrid.Rows[i].Cells["STOCK"].Value = (decimal.Parse(dt.Rows[i]["NO_JUMUN_STOCK"].ToString())).ToString("#,0.######");

                    conItemGrid.Rows[i].Cells["TOTAL_AMT"].Value = (decimal.Parse(dt.Rows[i]["TOTAL_AMT"].ToString())).ToString("#,0.######");
                    conItemGrid.Rows[i].Cells["PRICE"].Value = (decimal.Parse(dt.Rows[i]["PRICE"].ToString())).ToString("#,0.######");
                    conItemGrid.Rows[i].Cells["TOTAL_MONEY"].Value = (decimal.Parse(dt.Rows[i]["TOTAL_MONEY"].ToString())).ToString("#,0.######");
                    conItemGrid.Rows[i].Cells["COMMENT"].Value = dt.Rows[i]["COMMENT"].ToString();

                    conItemGrid.Rows[i].Cells["OLD_ITEM_CD"].Value = dt.Rows[i]["ITEM_CD"].ToString(); //검색어 위한 COLUMN 설정
                    conItemGrid.Rows[i].Cells["OLD_ITEM_NM"].Value = dt.Rows[i]["ITEM_NM"].ToString(); //검색어 위한 COLUMN 설정

                }
            }
            else
            {
                //dataJumunGridAdd(); //데이터가 없을 경우 빈 행 생성
            }

            conItemGrid.ReadOnly = true;
            conItemGrid.Columns["STOCK"].ReadOnly = true;


        }
        private void conItemGridAdd()
        {
            conItemGrid.Rows.Add();
            conItemGrid.Rows[conItemGrid.Rows.Count - 1].Cells["TOTAL_AMT"].Value = "0";
            conItemGrid.Rows[conItemGrid.Rows.Count - 1].Cells["PRICE"].Value = "0";
            conItemGrid.Rows[conItemGrid.Rows.Count - 1].Cells["TOTAL_MONEY"].Value = "0";
        }

        private void conItemGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2 && btnSave.Text.Equals("저장"))
            {
                itemSrchRsLogic((conDataGridView)sender, e);

            }
            conItemGrid.EndEdit();
        }

        private void btn_Custsearch_Click(object sender, EventArgs e)
        {
            Popup.pop거래처검색 frm = new Popup.pop거래처검색();

            frm.sCustGbn = "1";
            //frm.sCustNm = txt_cust_nm.Text.ToString();
            frm.ShowDialog();

            if (frm.sCode != "")
            {
                txt_cust_cd.Text = frm.sCode.Trim();
                txt_cust_nm.Text = frm.sName.Trim();
                old_cust_nm = frm.sCode.Trim();
                //vat = frm.sVat;
                //lbl_vat_nm.Text = frm.sVatNm;
                //if (vat == "0")
                //    lbl_vat.Text = "부가세별도";
                //else if (vat == "1")
                //    lbl_vat.Text = "부가세포함";
                //else if (vat == "2")
                //    lbl_vat.Text = "영세율";
            }
            else
            {
                txt_cust_cd.Text = old_cust_nm;
            }

            frm.Dispose();
            frm = null;
        }

        private void btn_file_Click(object sender, EventArgs e)
        {

            f_fullName = OpenFile();

            // string sourceFile = @"C:\Users\Public\public\test.txt";



        }




        private string OpenFile()
        {

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.DefaultExt = "jpg";  //openFile.DefaultExt = "기본확장자";
            //ofd.Filter = "Images Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png; *pdf)|*.jpg;*.jpeg;*.gif;*.bmp;*.png; *pdf"; //"항목이름정의1|확장자1;확장자2;  … 확장자n;|   … 항목이름정의n|확장자1;확장자2;  … 확장자n;";
            ofd.Filter = "HWP File|*.hwp";
            DialogResult dr = ofd.ShowDialog();
            if (ofd.FileNames.Length > 0)
            {
                foreach (string filename in ofd.FileNames)
                {
                    this.txt_file.Text = "파일명 :" + Path.GetFileName(filename);
                    txt_file.Visible = true;
                }
            }

            if (dr == DialogResult.OK)
            {
                //File명과 확장자를 가지고 온다.
                string fileName = ofd.SafeFileName;
                fName = ofd.SafeFileName;
                //File경로와 File명을 모두 가지고 온다.
                string fileFullName = ofd.FileName;
                //File경로만 가지고 온다.
                string filePath = fileFullName.Replace(fileName, "");

                //출력 예제용 로직
                //label1.Text = "File Name  : " + fileName;
                //label2.Text = "Full Name  : " + fileFullName;
                //label3.Text = "File Path  : " + filePath;
                //File경로 + 파일명 리턴
                return fileFullName;
            }
            //취소버튼 클릭시 또는 ESC키로 파일창을 종료 했을경우
            else if (dr == DialogResult.Cancel)
            {
                return "";
            }

            return "";
        }

        private void btnSrch_Click(object sender, EventArgs e)
        {
            jumun_list(dataJumunGrid, "and A.INPUT_DATE >= '" + start_date.Text.ToString() + "' and  A.INPUT_DATE <= '" + end_date.Text.ToString() + "'");
        }

        private void dataJumunGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            resetSetting();
            btnDelete.Enabled = true;
        }
        private void onlyView()
        {
            //dtp_input_date.Enabled = false;
            txt_cust_nm.ReadOnly = true;
            delivery_proc_cd.Enabled = false;
            delivery_req_date.Enabled = false;
            cmb_jumun_gubun.Enabled = false;
            cmb_pojang.Enabled = false;
            txt_comment.ReadOnly = true;
            dtp_jumun_date.Enabled = false;
            btn_plus.Enabled = false;
            btn_minus.Enabled = false;
            btn_file.Enabled = false;
            btn_Custsearch.Enabled = false;


            conItemGrid.ReadOnly = true;

        }

        private void NoonlyView()
        {
            //dtp_jumun_date.Enabled = true;
            txt_cust_nm.ReadOnly = false;
            delivery_proc_cd.Enabled = true;
            delivery_req_date.Enabled = true;
            cmb_jumun_gubun.Enabled = true;
            cmb_pojang.Enabled = true;
            txt_comment.ReadOnly = false;
            dtp_jumun_date.Enabled = true;
            btn_plus.Enabled = true;
            btn_minus.Enabled = true;
            btn_file.Enabled = true;
            btn_Custsearch.Enabled = true;
            //btnDelete.Enabled = false;
            conItemGrid.ReadOnly = false;
            conItemGrid.Columns["ITEM_NM"].ReadOnly = true;
            conItemGrid.Columns["STOCK"].ReadOnly = true;
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void complete_yn_Paint(object sender, PaintEventArgs e)
        {

        }


        private void itemSrchRsLogic(conDataGridView grd, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                string item_nm = (string)grd.Rows[e.RowIndex].Cells["ITEM_NM"].Value;

                DataTable dt = new DataTable();
                // dt = qCtrl.fn_item_List("where ITEM_NM like '%" + item_nm + "%'");
                //dt = qCtrl.fn_item_List("where 1=1");

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        string sResult = wConst.call_pop_item(grd, dt, e.RowIndex, item_nm);
                    }
                    else if (dt.Rows.Count == 1) //row가 1일 경우 해당 row에 값을 자동 입력한다.
                    {

                    }
                    else
                    { //row가 없는 경우
                        MessageBox.Show("데이터가 없습니다.");
                    }
                    wConst.f_Calc_Price(grd, e.RowIndex, "TOTAL_AMT", "PRICE");
                }
            }
        }

        private void conItemGrid_KeyPress(object sender, KeyPressEventArgs e)
        {


        }
        private void grid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            string name = conItemGrid.CurrentCell.OwningColumn.Name;

            if (name == "TOTAL_AMT" || name == "PRICE" || name == "TOTAL_MONEY")
            {
                e.Control.KeyPress += new KeyPressEventHandler(txtCheckNumeric_KeyPress);
            }

            else
            {
                e.Control.KeyPress -= new KeyPressEventHandler(txtCheckNumeric_KeyPress);
            }
        }
        private void txtCheckNumeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComInfo.onlyNum(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if (lbl_input_cd.Text != null && lbl_input_cd.Text != "")
            //{

                //DataTable dtyn = qCtrl.planYN(dtp_input_date.Text.ToString(), lbl_input_cd.Text.ToString());

                //if (dtyn != null)
                //{
                //    if (dtyn.Rows.Count > 0)
                //    {
                //        DataTable dt = null;


                //        StringBuilder sb = new StringBuilder();
                //        for (int i = 0; i < conItemGrid.Rows.Count; i++)
                //        {
                //            sb.AppendLine("'" + conItemGrid.Rows[i].Cells["ITEM_CD"].Value.ToString() + "'");
                //        }
                //        //dt = qCtrl.fn_sub_materialItem(sb.ToString());
                //        DataGridView grd_sub = new DataGridView();
                //        grd_sub.DataSource = dt;

                //        DataTable dt_cust = null;

                //        //우측 리스트에서 구매처, 매출처가 동일한 코드일때 더블클릭시 매출처만 지정되는 오류 수정
                //        string condition = "where A.cust_cd = '" + txt_cust_cd.Text.ToString() + "'    ";

                        //dt_cust = qCtrl.fn_Cust_select(condition);

                        //MessageBox.Show(dt_cust.Rows.Count.ToString());
                        //if (new SF_NEW.Controller.QueryCtrl().selectItemOutYN(dtp_jumun_date.Value.ToString(), lbl_input_cd.Text.ToString()))
                        //{
                        //    int rsNum = new SF_NEW.Controller.QueryCtrl().insertItemOut(
                        //    dtp_input_date.Text.ToString()
                        //    , ""
                        //    , dt_cust.Rows[0]["CUST_MANAGER"].ToString()
                        //    , dt_cust.Rows[0]["NUMBER"].ToString()
                        //    , ""
                        //    , txt_cust_cd.Text.ToString()
                        //    , dt_cust.Rows[0]["ADDR1"].ToString()
                        //    , dt_cust.Rows[0]["NUMBER"].ToString()
                        //    , Common.p_strStaffNo
                        //    , dtp_input_date.Text.ToString()
                        //    , "N"
                        //    , ""
                        //    , dtp_input_date.Text.ToString()
                        //    , "N"
                        //    , ""
                        //    , dtp_input_date.Text.ToString()
                        //    , "N"
                        //    , ""
                        //    , ""
                        //    , ""
                        //    , dtp_input_date.Text.ToString()
                        //    , lbl_input_cd.Text.ToString()
                        //    , delivery_proc_cd.SelectedValue.ToString()
                        //    , conItemGrid
                        //    , grd_sub
                        //    );

                        //    if (rsNum == 0)
                        //    {
                        //        MessageBox.Show("성공적으로 등록하였습니다.");
                        //    }
                        //    else if (rsNum == 1)
                        //        MessageBox.Show("저장에 실패하였습니다");
                        //    else
                        //        MessageBox.Show("Exception 에러");
                        //}
                        //else
                        //{
                        //    MessageBox.Show("이미등록된 주문서입니다.");
                        //}
                //    }
                //    else
                //    {
                //        MessageBox.Show("생산계획을 완료해주세요");
                //    }
                //}

            //}



            //else
            //{
            //    MessageBox.Show("저장을 먼저 하셔야 합니다.");
            //}




        }

        private void conItemGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (conItemGrid.Columns[e.ColumnIndex].Name.ToString().Equals("TOTAL_AMT"))
            {
                if (conItemGrid.Rows[e.RowIndex].Cells["UNIT_NM"].Value != null)
                {
                    //유정훈 수정 -> 에러: s_input_amt 소수점 형식인데 int로 형변환해서 에러 -> 수정완료 2020-02-21
                    string s_total_amt = conItemGrid.Rows[e.RowIndex].Cells["TOTAL_AMT"].Value.ToString().Replace(",", "");
                    string s_input_amt = conItemGrid.Rows[e.RowIndex].Cells["INPUT_AMT"].Value.ToString().Replace(",", "");
                    conItemGrid.Rows[e.RowIndex].Cells["EA_AMT"].Value = (int.Parse(s_total_amt) * double.Parse(s_input_amt)).ToString("#,0");
                    //유정훈 수정 끝

                    //if (conItemGrid.Rows[e.RowIndex].Cells["STOCK"].Value != null)
                    //{
                    //    if (int.Parse(conItemGrid.Rows[e.RowIndex].Cells["STOCK"].Value.ToString()) < int.Parse(conItemGrid.Rows[e.RowIndex].Cells["TOTAL_AMT"].Value.ToString()))
                    //    {
                    //        MessageBox.Show("재고량이 부족합니다.");
                    //    }
                    //}
                }
                else
                {
                    MessageBox.Show("제품의 단위를 선택하세요");
                }

            }
            else if (conItemGrid.Columns[e.ColumnIndex].Name.ToString().Equals("EA_AMT"))
            {
                if (conItemGrid.Rows[e.RowIndex].Cells["STOCK"].Value != null && conItemGrid.Rows[e.RowIndex].Cells["EA_AMT"].Value != null)
                {
                    if (delivery_proc_cd.SelectedValue.ToString().Equals("2"))
                    {
                        if (int.Parse(conItemGrid.Rows[e.RowIndex].Cells["STOCK"].Value.ToString().Replace(",", "")) < int.Parse(conItemGrid.Rows[e.RowIndex].Cells["EA_AMT"].Value.ToString().Replace(",", "")))
                        {
                            MessageBox.Show("재고량이 부족합니다.");
                        }
                    }
                }
            }
            else if (conItemGrid.Columns[e.ColumnIndex].Name.ToString().Equals("TOTAL_MONEY"))
            {
                if (conItemGrid.Rows[e.RowIndex].Cells["TOTAL_MONEY"].Value != null)
                {
                    if (txt_cust_cd.Text != null && !txt_cust_cd.Text.ToString().Equals(""))
                    {
                        talMoney = 0;
                        if (conItemGrid.Rows != null)
                        {
                            if (conItemGrid.Rows.Count > 0)
                            {
                                if (conItemGrid.Rows.Count - 1 == e.RowIndex)
                                {
                                    //comInfo.totalMoney(conItemGrid, vat.ToString(), lbl_supply_money, lbl_tax_money, lbl_total_money, "TOTAL_MONEY");
                                }
                            }
                        }

                    }

                }
                else
                {
                    MessageBox.Show("거래처를 선택하세요");
                }
            }
            else if (conItemGrid.Columns[e.ColumnIndex].Name.ToString().Equals("UNIT_NM"))
            {
                //DataTable dtEa = qCtrl.itemUnitSelect(conItemGrid.Rows[e.RowIndex].Cells["ITEM_CD"].Value.ToString(), conItemGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                //conItemGrid.Rows[e.RowIndex].Cells["INPUT_AMT"].Value = dtEa.Rows[0]["INPUT_AMT"].ToString();
                if (conItemGrid.Rows[e.RowIndex].Cells["TOTAL_AMT"].Value != null)
                {
                    if (int.Parse(conItemGrid.Rows[e.RowIndex].Cells["TOTAL_AMT"].Value.ToString()) > 0)
                    {
                        //conItemGrid.Rows[e.RowIndex].Cells["EA_AMT"].Value = (int.Parse(conItemGrid.Rows[e.RowIndex].Cells["TOTAL_AMT"].Value.ToString()) * int.Parse(comInfo.decimalOmit(conItemGrid.Rows[e.RowIndex].Cells["INPUT_AMT"].Value.ToString()))).ToString("#,0");
                    }
                    else
                    {
                        conItemGrid.Rows[e.RowIndex].Cells["EA_AMT"].Value = "0";
                    }
                }
            }

        }

        private void delivery_proc_cd_SelectedValueChanged(object sender, EventArgs e)
        {
            if (delivery_proc_cd.SelectedValue != null)
            {
                if (delivery_proc_cd.SelectedValue.ToString().Equals("2"))
                {
                    btn_out.Enabled = true;
                }
                else
                {
                    btn_out.Enabled = false;
                }
            }
                    }
        private void ftpSaveLogic()
        {
            string destinationFile = "ftp://119.196.70.80:8101/EYN/";





            FtpWebRequest req = (FtpWebRequest)WebRequest.Create(destinationFile + "/" + fName);
            req.Method = WebRequestMethods.Ftp.UploadFile;
            req.Credentials = new NetworkCredential(user, pwd);
            FileInfo fileInfo  = new FileInfo(f_fullName);
            FileStream fileStream =  fileInfo.OpenRead();
            int bufferLength = 2048;
            byte[]  buffer  = new byte[bufferLength];
            Stream us =  req.GetRequestStream();
            int cl = fileStream.Read(buffer, 0, bufferLength);
            while(cl != 0)
            {
             us.Write(buffer, 0 , cl);
             cl = fileStream.Read(buffer, 0, bufferLength);
             }

            us.Close();
            fileStream.Close();


            req = null;




            //try
            //{

            //    // 입력파일을 바이트 배열로 읽음
            //    byte[] data;
            //    if (!f_fullName.Equals(""))
            //    {
            //        using (StreamReader reader = new StreamReader(f_fullName))
            //        {
            //            data = Encoding.UTF8.GetBytes(reader.ReadToEnd());
            //        }

            //        // RequestStream에 데이타를 쓴다
            //        req.ContentLength = data.Length;
            //        using (Stream reqStream = req.GetRequestStream())
            //        {
            //            reqStream.Write(data, 0, data.Length);
            //        }

            //        // FTP Upload 실행
            //        using (FtpWebResponse resp1 = (FtpWebResponse)req.GetResponse())
            //        {
            //            // FTP 결과 상태 출력
            //            Console.WriteLine("Upload: {0}", resp1.StatusDescription);
            //            MessageBox.Show("성공");
            //        }

            //    }
            //}
            //catch (WebException ex)
            //{
            //    try
            //    {
            //        // 입력파일을 바이트 배열로 읽음
            //        byte[] data;
            //        if (!f_fullName.Equals(""))
            //        {
            //            using (StreamReader reader = new StreamReader(f_fullName))
            //            {
            //                data = Encoding.UTF8.GetBytes(reader.ReadToEnd());
            //            }

            //            // RequestStream에 데이타를 쓴다
            //            req.ContentLength = data.Length;
            //            using (Stream reqStream = req.GetRequestStream())
            //            {
            //                reqStream.Write(data, 0, data.Length);
            //            }

            //            // FTP Upload 실행
            //            using (FtpWebResponse resp1 = (FtpWebResponse)req.GetResponse())
            //            {
            //                // FTP 결과 상태 출력
            //                Console.WriteLine("Upload: {0}", resp1.StatusDescription);
            //                MessageBox.Show("성공");
            //            }
            //            // MessageBox.Show("실패");
            //        }
            //    }
            //    catch (IOException)
            //    {
            //        MessageBox.Show("현재 파일이 열려있습니다.");
            //        return;
            //    }
            //}
        }

        private void txt_file_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string localPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+"\\";
            string fileName = txt_file.Text;

            try
            {
                FtpWebRequest reqFileDownload = (FtpWebRequest)WebRequest.Create("ftp://119.196.70.80:8101/EYN/" + fileName);
                reqFileDownload.Credentials = new NetworkCredential(user, pwd);
                reqFileDownload.Method = WebRequestMethods.Ftp.DownloadFile;
                FtpWebResponse responseFileDownload = (FtpWebResponse)reqFileDownload.GetResponse();
                Stream responseStream = responseFileDownload.GetResponseStream();

                FileStream writeStream = new FileStream(localPath + fileName, FileMode.Create);
                StreamReader sr = new StreamReader(writeStream, Encoding.Default);
                System.Text.Encoding code = sr.CurrentEncoding;
                StreamWriter sw = new StreamWriter(writeStream, code);




                int Length = 2048;

                byte[] buffer = new byte[Length];
                string DownloadedFilePath = "ftp://119.196.70.80:8101/EYN/" + fileName;

                int bytesRead = responseStream.Read(buffer, 0, Length);

                while (bytesRead > 0)
                {
                    writeStream.Write(buffer, 0, bytesRead);
                    bytesRead = responseStream.Read(buffer, 0, Length);
                }

                responseStream.Close();
                sw.Close();

                reqFileDownload = null;
                responseFileDownload = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }


        }

    }



}
