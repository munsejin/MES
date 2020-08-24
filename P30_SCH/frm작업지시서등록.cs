using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MES.CLS;
using MES.Controls;
using System.Diagnostics;
using System.Net;
using System.IO;
using MES.Popup;

namespace MES.P30_SCH
{
    public partial class frm작업지시서등록 : Form
    {
        private wnGConstant wConst = new wnGConstant();
        private ComInfo comInfo = new ComInfo();

        Popup.frmPrint readyPrt = new Popup.frmPrint();
        public Popup.frmPrint frmPrt;

        DataTable adoPrt = null;
        wnDm wnDm = new wnDm();

        public string strCondition = "";
        private string old_cust_nm = "";
        private string old_item_nm = "";

        private string oldValue = "";

        private DataGridView del_workGrid = new DataGridView();
        private bool[] right = new bool[2];
        string rawchk = "";

        int errorcnt = 0;

        public frm작업지시서등록()
        {
            InitializeComponent();

            this.workRmGrid.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.grid_RowsAdded);
            this.workRmGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellEndEdit);
        }
        public static bool p_IsAuth = true;    // 열람권한
        public static bool p_Isrgstr = true;    //등록/수정 권한

        public static bool p_Isdel = true;    // 삭제 권한
        private void frm작업지시서등록_Load(object sender, EventArgs e)
        {
            lbl_title.Tag = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[0] + "$" + wnDm.fn_TitleName(this.Name.ToString()).Split('$')[1]; lbl_title.Text = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[2];
            right = wConst.btnRight(lbl_title.Tag.ToString());

            txt_work_date.Text = DateTime.Now.ToString("yyyy-MM-dd");

            
            
            del_workGrid.AllowUserToAddRows = false;

            del_workGrid.Columns.Add("WORK_INST_DATE", "WORK_INST_DATE");
            del_workGrid.Columns.Add("WORK_INST_CD", "WORK_INST_CD");
            del_workGrid.Columns.Add("SEQ", "SEQ");

            init_ComboBox();
            grdCellSetting(); // gridview all column center align and read only

            today_logic();
            //srch_logic();
            plan_logic();

            txt_lot_no.Text = "";
        }

        #region button logic

        private void btnNew_Click(object sender, EventArgs e)
        {
            resetSetting();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (right[0])
            {
                work_logic();

            }
            else
            {
                MessageBox.Show("권한이 없습니다.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (right[1])
            {
                work_del();
            }
            else
            {
                MessageBox.Show("권한이 없습니다.");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnItemSrch_Click(object sender, EventArgs e)
        {
            Popup.pop_sf_제품검색 frm = new Popup.pop_sf_제품검색();
            wnDm wDm = new wnDm();
            DataTable dt = new DataTable();
            dt = wDm.fn_Item_List("where ITEM_NM like '%" + txt_item_nm.Text.ToString() + "%' ");

            //frm.sUsedYN = sUsedYN;
            frm.dt = dt;
            frm.txtSrch.Text = txt_item_nm.Text.ToString();
            frm.ShowDialog();

            if (frm.sCode != "")
            {
                txt_item_cd.Text = frm.sCode.Trim();
                txt_item_nm.Text = frm.sName.Trim();
                old_item_nm = frm.sCode.Trim();
                txt_char_amt.Text = frm.sCharge.Trim();
                txt_pack_amt.Text = frm.sPack.Trim();
                if (Common.p_saupNo == "6091692803")
                {
                    cmb_mold.SelectedValue = frm.mold;
                }

                workItemSelectDetail();
            }
            else
            {
                txt_item_nm.Text = old_item_nm;
            }
            txt_inst_amt.Focus();
        }

        private void btnCustSrch_Click(object sender, EventArgs e)
        {
            Popup.pop거래처검색 frm = new Popup.pop거래처검색("납품처");

            frm.sCustGbn = "1";
            frm.sCustNm = txt_cust_nm.Text.ToString();
            frm.ShowDialog();

            if (frm.sCode != "")
            {
                txt_cust_cd.Text = frm.sCode.Trim();
                txt_cust_nm.Text = frm.sName.Trim();
                old_cust_nm = frm.sCode.Trim();
            }
            else
            {
                txt_cust_cd.Text = old_cust_nm;
            }

            frm.Dispose();
            frm = null;
            delivery_req_date.Focus();
        }

        private void btnRawOut_Click(object sender, EventArgs e)
        {
            if (chk_raw.Checked == true)
            {
                chk_raw.Checked = false;
                rawchk = "N";
            }
            else
            {
                chk_raw.Checked = true;
                rawchk = "Y";
            }
        }

        #endregion button logic
        private void resetSetting()
        {
            lbl_work_gbn.Text = "";
            btnDelete.Enabled = false;

            txt_work_date.Text = DateTime.Now.ToString("yyyy-MM-dd");
            txt_work_date.Enabled = true;
            txt_work_cd.Text = "";
            txt_cust_cd.Text = "";
            txt_cust_nm.Text = "";
            old_cust_nm = "";

            txt_item_cd.Text = "";
            txt_item_nm.Text = "";
            old_item_nm = "";

            txt_spec.Text = "";
            txt_inst_amt.Text = "0";
            old_inst_amt.Text = "0";
            delivery_req_date.Text = DateTime.Now.ToString("yyyy-MM-dd");

            txt_inst_notice.Text = "";

            cmb_line.SelectedValue = "";
            cmb_worker.SelectedValue = "";

            txt_plan_num.Text = "";
            txt_plan_item.Text = "";

            txt_char_amt.Text = "";
            txt_pack_amt.Text = "";

            workRmGrid.Rows.Clear();
            workHalfGrid.Rows.Clear();

            txt_lot_no.Text = "";

            btnCustSrch.Enabled = true;
            btnItemSrch.Enabled = true;
            //btnRawOut.Enabled = true;
            //btnRawOut.Visible = true;

            chk_out_yn.Checked = false;
            chk_poor_yn.Checked = false;
            chk_flow_yn.Checked = false;

            btn공정완료.Visible = false;

            chk_raw.Enabled = true;
            chk_raw.Checked = false;

            btn반환.Enabled = true;

            if (Common.p_saupNo == "1278113487")
            {
                pnl_loss.Visible = true;
            }

        }

        private void work_logic()
        {
            if (cmb_line.SelectedValue == null) cmb_line.SelectedValue = "";
            if (cmb_worker.SelectedValue == null) cmb_worker.SelectedValue = "";

            if (txt_item_cd.Text.ToString().Equals(""))
            {
                MessageBox.Show("제품을 선택하시기 바랍니다.");
                return;

            }

            if (txt_cust_cd.Text.ToString().Equals(""))
            {
                txt_cust_cd.Text = "";
                txt_cust_nm.Text = "";
            }

            if (workRmGrid.Rows.Count == 0)
            {
                MessageBox.Show("작업지시에 들어갈 원자재가 1개 이상 필요합니다.");
                return;
            }

            if (btnRawOut.Enabled == false)
            {
                MessageBox.Show("이미 자재를 소요하여 수정이 불가능합니다.");
                return;
            }

            //if (!warning_stock())  //재고부족으로 저장을 안할 경우
            //{
            //    return;
            //}

            if (chk_raw.Checked == false)
            {
                DialogResult msgOk = MessageBox.Show("자재 불출을 생략하고 진행하시겠습니까?\n\n(자재 불출을 생략하시는 경우 생산공정을 진행하실 수 없습니다.)", "불출여부", MessageBoxButtons.YesNo);
                if (msgOk == DialogResult.No)
                {
                    return;
                }
                rawchk = "N";
            }
            else
            {
                rawchk = "Y";
            }

            if (!chk_raw.Checked)
            {
                for (int i = 0; i < workRmGrid.Rows.Count; i++)
                {
                    if (workRmGrid.Rows[i].Cells["CUST_NM"].Value.ToString() == "dregs")
                    {
                        chk_raw.Checked = true;
                        break;
                    }
                }
            }


            if (Common.p_saupNo == "6091692803")
            {
                if (lbl_work_gbn.Text != "1" )
                {
                    string lot_no = txt_work_date.Text.ToString().Replace("-", "");
                    lot_no = lot_no.Substring(2).ToString();

                    //txt_lot_no.Text = lot_no;

                    wnDm wDm = new wnDm();
                    wnProcCon wDmProc = new wnProcCon();
                    int rsNum = 0;

                    rsNum = wDm.insertWork(
                     txt_work_date.Text.ToString(),
                     txt_work_cd.Text.ToString(),
                     lot_no,
                     txt_item_cd.Text.ToString(),
                     txt_cust_cd.Text.ToString(),
                     txt_inst_amt.Text.ToString(),
                     delivery_req_date.Text.ToString(),
                     cmb_line.SelectedValue.ToString(),
                     cmb_worker.SelectedValue.ToString(),
                     txt_plan_num.Text.ToString(),
                     txt_plan_item.Text.ToString(),
                     txt_inst_notice.Text.ToString(),
                     txt_char_amt.Text.ToString(),
                     txt_pack_amt.Text.ToString(),
                     workRmGrid,
                     workHalfGrid,
                     rawchk,
                     cmb_mold.SelectedValue.ToString());




                    if (rsNum == 0)
                    {
                        if (!txt_plan_num.Text.ToString().Equals(""))
                        {
                            wDmProc.prod_pln_work_yn(txt_plan_num.Text.ToString(), txt_plan_item.Text.ToString());
                        }
                        //resetSetting();

                        today_logic();
                        plan_logic();
                        srch_logic();
                        workInstReset();

                        MessageBox.Show("성공적으로 등록하였습니다.");
                    }
                    else if (rsNum == 1)
                        MessageBox.Show("저장에 실패하였습니다");
                    else if (rsNum == 2)
                        MessageBox.Show("SQL COMMAND 에러");
                    else
                        MessageBox.Show("Exception 에러1");
                }
                else
                {
                    if (!right[1])
                    {
                        MessageBox.Show("권한이없습니다.");
                        return;
                    }
                    wnDm wDm = new wnDm();
                    wnProcCon wDmProc = new wnProcCon();

                    int rsNum = wDm.updateWork(
                            txt_work_date.Text.ToString(),
                            txt_work_cd.Text.ToString(),
                            txt_lot_no.Text.ToString(),
                            txt_item_cd.Text.ToString(),
                            txt_cust_cd.Text.ToString(),
                            txt_inst_amt.Text.ToString(),
                            delivery_req_date.Text.ToString(),
                            cmb_line.SelectedValue.ToString(),
                            cmb_worker.SelectedValue.ToString(),
                            txt_plan_num.Text.ToString(),
                            txt_plan_item.Text.ToString(),
                            txt_inst_notice.Text.ToString(),
                            workRmGrid,
                            workHalfGrid,
                            del_workGrid,
                            rawchk,
                            cmb_mold.SelectedValue.ToString());

                    if (rsNum == 0)
                    {
                        if (!txt_plan_num.Text.ToString().Equals(""))
                        {
                            wDmProc.prod_pln_work_yn(txt_plan_num.Text.ToString(), txt_plan_item.Text.ToString());
                        }

                        today_logic();
                        plan_logic();
                        srch_logic();
                        MessageBox.Show("성공적으로 수정하였습니다.");
                    }
                    else if (rsNum == 1)
                        MessageBox.Show("저장에 실패하였습니다");
                    else if (rsNum == 2)
                        MessageBox.Show("SQL COMMAND 에러");
                    else if (rsNum == 3)
                        MessageBox.Show(txt_plan_num.Text.ToString() + "의 " + txt_plan_item.Text.ToString() + "의 작업지시여부가 완료된 상태이므로 \n 수정이 불가능합니다.");
                    else
                        MessageBox.Show("Exception 에러1");
                }

            }
            else
            {
                if (lbl_work_gbn.Text != "1")
                {
                    string lot_no = txt_work_date.Text.ToString().Replace("-", "");
                    lot_no = lot_no.Substring(2).ToString();

                    //txt_lot_no.Text = lot_no;

                    wnDm wDm = new wnDm();
                    wnProcCon wDmProc = new wnProcCon();
                    int rsNum = 0;

                    rsNum = wDm.insertWork(
                     txt_work_date.Text.ToString(),
                     txt_work_cd.Text.ToString(),
                     lot_no,
                     txt_item_cd.Text.ToString(),
                     txt_cust_cd.Text.ToString(),
                     txt_inst_amt.Text.ToString(),
                     delivery_req_date.Text.ToString(),
                     cmb_line.SelectedValue.ToString(),
                     cmb_worker.SelectedValue.ToString(),
                     txt_plan_num.Text.ToString(),
                     txt_plan_item.Text.ToString(),
                     txt_inst_notice.Text.ToString(),
                     txt_char_amt.Text.ToString(),
                     txt_pack_amt.Text.ToString(),
                     workRmGrid,
                     workHalfGrid,
                     rawchk);




                    if (rsNum == 0)
                    {
                        if (!txt_plan_num.Text.ToString().Equals(""))
                        {
                            wDmProc.prod_pln_work_yn(txt_plan_num.Text.ToString(), txt_plan_item.Text.ToString());
                        }
                        //resetSetting();

                        today_logic();
                        plan_logic();
                        srch_logic();
                        workInstReset();

                        MessageBox.Show("성공적으로 등록하였습니다.");
                    }
                    else if (rsNum == 1)
                        MessageBox.Show("저장에 실패하였습니다");
                    else if (rsNum == 2)
                        MessageBox.Show("SQL COMMAND 에러");
                    else
                        MessageBox.Show("Exception 에러1");
                }
                else
                {
                    if (!right[1])
                    {
                        MessageBox.Show("권한이없습니다.");
                        return;
                    }
                    wnDm wDm = new wnDm();
                    wnProcCon wDmProc = new wnProcCon();

                    int rsNum = wDm.updateWork(
                            txt_work_date.Text.ToString(),
                            txt_work_cd.Text.ToString(),
                            txt_lot_no.Text.ToString(),
                            txt_item_cd.Text.ToString(),
                            txt_cust_cd.Text.ToString(),
                            txt_inst_amt.Text.ToString(),
                            delivery_req_date.Text.ToString(),
                            cmb_line.SelectedValue.ToString(),
                            cmb_worker.SelectedValue.ToString(),
                            txt_plan_num.Text.ToString(),
                            txt_plan_item.Text.ToString(),
                            txt_inst_notice.Text.ToString(),
                            workRmGrid,
                            workHalfGrid,
                            del_workGrid,
                            rawchk);

                    if (rsNum == 0)
                    {
                        if (!txt_plan_num.Text.ToString().Equals(""))
                        {
                            wDmProc.prod_pln_work_yn(txt_plan_num.Text.ToString(), txt_plan_item.Text.ToString());
                        }

                        today_logic();
                        plan_logic();
                        srch_logic();
                        MessageBox.Show("성공적으로 수정하였습니다.");
                    }
                    else if (rsNum == 1)
                        MessageBox.Show("저장에 실패하였습니다");
                    else if (rsNum == 2)
                        MessageBox.Show("SQL COMMAND 에러");
                    else if (rsNum == 3)
                        MessageBox.Show(txt_plan_num.Text.ToString() + "의 " + txt_plan_item.Text.ToString() + "의 작업지시여부가 완료된 상태이므로 \n 수정이 불가능합니다.");
                    else
                        MessageBox.Show("Exception 에러1");
                }

            }
            if (chk_raw.Checked == true)
            {
                raw_out();
            }


        }

        public void raw_out()
        {
            wnDm wDm = new wnDm();
            wnProcCon wDmProc = new wnProcCon();
            //if (chk_raw.Checked == true && lbl_work_gbn.Text.Equals("1"))
            //    return;

            if (chk_raw.Enabled == false)
            {
                return;
            }

            if (chk_raw.Checked == true)
            {
                //if (workRmGrid.Rows.Count == 0)
                //{
                //    MessageBox.Show("데이터 없음");
                //    return;
                //}

                //if (!warning_stock())  //재고부족으로 저장을 안할 경우
                //{
                //    return;
                //}

                for (int i = 0; i < workHalfGrid.Rows.Count; i++)
                {
                    if (decimal.Parse(workHalfGrid.Rows[i].Cells["H_EX_STOCK"].Value.ToString()) < 0)
                    {
                        MessageBox.Show("생산을 위한 반제품의 수량이 부족합니다.\n자재가 출고되지 않았습니다.");
                        int rsNum3 = wDm.update_Work_inst_RawOutput_to_N(txt_lot_no.Text);

                        if (rsNum3 == 0)
                        {
                            resetSetting();
                            return;
                        }
                        else if (rsNum3 == 1)
                            MessageBox.Show("저장에 실패하였습니다");
                        else if (rsNum3 == 2)
                            MessageBox.Show("SQL COMMAND 에러");
                        else
                            MessageBox.Show("Exception 에러1");
                        return;
                    }
                }

                for (int i = 0; i < workRmGrid.Rows.Count; i++)
                {
                    if (decimal.Parse(workRmGrid.Rows[i].Cells["EX_STOCK"].Value.ToString()) < 0)
                    {
                        DialogResult msgOk = MessageBox.Show("생산을 위한 자재가 부족합니다. 부족분만큼 자동 구매합니다.\n자동 구매 처리는 0원으로 구매처리합니다.\n"
                            + "그래도 진행하시겠습니까? ", " 재고 부족 ", MessageBoxButtons.YesNo);
                        if (msgOk == DialogResult.No)
                        {
                            int rsNum3 = wDm.update_Work_inst_RawOutput_to_N(txt_lot_no.Text);
                            if (rsNum3 == 0)
                            {
                                MessageBox.Show("자재가 출고되지 않았습니다.");
                            }
                            else
                            {
                                MessageBox.Show("저장에 실패하였습니다");
                            }
                            return;
                        }
                        int RsNum = wnDm.insert_Extra_raw(workRmGrid, txt_work_date.Text);

                        if (RsNum == 0)
                        {
                            MessageBox.Show("부족한 원자재가 입고되었습니다.");
                            break;
                        }
                        else if (RsNum == 1)
                        {
                            MessageBox.Show("저장에 실패하였습니다");
                            return;
                        }
                        else if (RsNum == 2)
                        {
                            MessageBox.Show("SQL COMMAND 에러");
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Exception 에러1");
                            return;
                        }
                    }
                }


                for (int i = 0; i < workRmGrid.Rows.Count; i++)
                {
                    double t_soyo_amt = double.Parse(((string)workRmGrid.Rows[i].Cells["TOTAL_SOYO_AMT"].Value).Replace(",", ""));
                    double cvr_ratio = double.Parse((string)workRmGrid.Rows[i].Cells["CVR_RATIO"].Value);

                    double rst_soyo_amt = t_soyo_amt * cvr_ratio;
                    if (workRmGrid.Rows[i].Cells["CUST_NM"].Value.ToString() == "dregs")
                    {
                        wDm.raw_out(workRmGrid, i, txt_work_date.Text.ToString());
                    }

                    else
                    {
                        wDmProc.prod_raw_out(txt_lot_no.Text.ToString(), (string)workRmGrid.Rows[i].Cells["RAW_MAT_CD"].Value, rst_soyo_amt);
                    }
                }

                if (workHalfGrid.Rows.Count > 0)
                {
                    for (int i = 0; i < workHalfGrid.Rows.Count; i++)//반제품 출고 프로시저 호출 
                    {
                        double rst_soyo_amt = double.Parse(((string)workHalfGrid.Rows[i].Cells["H_TOTAL_SOYO_AMT"].Value).Replace(",", ""));
                        wDmProc.prod_half_out2(txt_lot_no.Text.ToString(), (string)workHalfGrid.Rows[i].Cells["HALF_ITEM_CD"].Value, rst_soyo_amt);
                    }
                }

                int rsNum = wDm.update_Work_Raw_Out_Yn(txt_lot_no.Text.ToString());
                if (rsNum == 0)
                {
                    MessageBox.Show("원자재가 출고되었습니다.");
                    resetSetting();

                }
                else if (rsNum == 1)
                    MessageBox.Show("저장에 실패하였습니다");
                else if (rsNum == 2)
                    MessageBox.Show("SQL COMMAND 에러");
                else
                    MessageBox.Show("Exception 에러1");

                //if (workHalfGrid.Rows.Count > 0)
                //{
                //    //반제품 출고
                //    // 가상의 그리드 생성 이유는 출고 등록 공통 소스 dgv Naming이 같아야 되서 
                //    conDataGridView dgv = new conDataGridView();
                //    dgv.Columns.Add("O_LOT_NO", "O_LOT_NO"); //index 0
                //    dgv.Columns.Add("O_LOT_SUB", "O_LOT_SUB"); //index 0
                //    dgv.Columns.Add("O_ITEM_CD", "O_ITEM_CD"); //1
                //    dgv.Columns.Add("O_UNIT_CD", "O_UNIT_CD"); //2
                //    dgv.Columns.Add("OUTPUT_AMT", "OUTPUT_AMT"); //3
                //    dgv.Columns.Add("PRICE", "PRICE"); //4
                //    dgv.Columns.Add("TOTAL_MONEY", "TOTAL_MONEY"); //5
                //    dgv.Columns.Add("O_INPUT_DATE", "O_INPUT_DATE"); //5
                //    dgv.Columns.Add("O_INPUT_CD", "O_INPUT_CD"); //5

                //    dgv.AllowUserToAddRows = false;

                //    for (int i = 0; i < workHalfGrid.Rows.Count; i++)
                //    {
                //        dgv.Rows.Add();
                //        dgv.Rows[dgv.Rows.Count - 1].Cells["O_LOT_NO"].Value = txt_lot_no.Text.ToString();
                //        dgv.Rows[dgv.Rows.Count - 1].Cells["O_LOT_SUB"].Value = "";
                //        dgv.Rows[dgv.Rows.Count - 1].Cells["O_ITEM_CD"].Value = workHalfGrid.Rows[i].Cells["HALF_ITEM_CD"].Value;
                //        dgv.Rows[dgv.Rows.Count - 1].Cells["O_UNIT_CD"].Value = workHalfGrid.Rows[i].Cells["UNIT_CD"].Value;
                //        dgv.Rows[dgv.Rows.Count - 1].Cells["OUTPUT_AMT"].Value = workHalfGrid.Rows[i].Cells["H_TOTAL_SOYO_AMT"].Value;
                //        dgv.Rows[dgv.Rows.Count - 1].Cells["PRICE"].Value = "0";
                //        dgv.Rows[dgv.Rows.Count - 1].Cells["TOTAL_MONEY"].Value = "0";
                //        dgv.Rows[dgv.Rows.Count - 1].Cells["O_INPUT_DATE"].Value = "";
                //        dgv.Rows[dgv.Rows.Count - 1].Cells["O_INPUT_CD"].Value = "";
                //    }

                //    string out_date = DateTime.Today.ToString("yyyy-MM-dd");

                //    int rsNum2 = wDm.insertHalfOut(
                //       out_date,
                //       "",
                //       "000",
                //       "Y",
                //       dgv);
                //    if (rsNum2 == 0)
                //    {
                //        //MessageBox.Show("원자재 출고가 성공되었습니다.");
                //        //for (int i = 0; i < workHalfGrid.Rows.Count; i++)
                //        //{
                //        //    double t_soyo_amt = double.Parse(((string)workHalfGrid.Rows[i].Cells["H_TOTAL_SOYO_AMT"].Value).Replace(",", ""));
                //        //    //wDmProc.prod_raw_out(txt_lot_no.Text.ToString(), (string)workRmGrid.Rows[i].Cells["RAW_MAT_CD"].Value, rst_soyo_amt);
                //        //}

                //        workHalfDetail();
                //    }
                //    else if (rsNum2 == 1)
                //        MessageBox.Show("저장에 실패하였습니다");
                //    else if (rsNum2 == 2)
                //        MessageBox.Show("SQL COMMAND 에러");
                //    else
                //        MessageBox.Show("Exception 에러2");


                //    //  DataTable dt = new DataTable();
                //    // dt = wDm.fn_Work_Raw_Out_Yn(txt_lot_no.Text.ToString()); //LOT_NO에 대한 작업지시서 출고 여부

                //    //원자재 출고 
                //    //if (dt.Rows.Count > 0)
                //    //{
                //    //    if (dt.Rows[0]["RAW_OUT_YN"].ToString().Equals("N"))
                //    //    {
                //    //        //for (int i = 0; i < workRmGrid.Rows.Count; i++)
                //    //        //{
                //    //        //    double t_soyo_amt = double.Parse(((string)workRmGrid.Rows[i].Cells["TOTAL_SOYO_AMT"].Value).Replace(",", ""));
                //    //        //    double cvr_ratio = double.Parse((string)workRmGrid.Rows[i].Cells["CVR_RATIO"].Value);

                //    //        //    double rst_soyo_amt = t_soyo_amt * cvr_ratio;
                //    //        //    wDmProc.prod_raw_out(txt_lot_no.Text.ToString(), (string)workRmGrid.Rows[i].Cells["RAW_MAT_CD"].Value, rst_soyo_amt);
                //    //        //}

                //    //        int rsNum = wDm.update_Work_Raw_Out_Yn(txt_lot_no.Text.ToString());
                //    //        if (rsNum == 0)
                //    //        {
                //    //            // workRmDetail();
                //    //            btnRawOut.Enabled = false;
                //    //            btnRawOut.Visible = false;
                //    //            MessageBox.Show("원자재가 출고되었습니다.");
                //    //            resetSetting();

                //    //        }
                //    //        else if (rsNum == 1)
                //    //            MessageBox.Show("저장에 실패하였습니다");
                //    //        else if (rsNum == 2)
                //    //            MessageBox.Show("SQL COMMAND 에러");
                //    //        else
                //    //            MessageBox.Show("Exception 에러1");

                //    //        if (workHalfGrid.Rows.Count > 0)
                //    //        {
                //    //            //반제품 출고

                //    //            // 가상의 그리드 생성 이유는 출고 등록 공통 소스 dgv Naming이 같아야 되서 
                //    //            conDataGridView dgv = new conDataGridView();
                //    //            dgv.Columns.Add("O_LOT_NO", "O_LOT_NO"); //index 0
                //    //            dgv.Columns.Add("O_LOT_SUB", "O_LOT_SUB"); //index 0
                //    //            dgv.Columns.Add("O_ITEM_CD", "O_ITEM_CD"); //1
                //    //            dgv.Columns.Add("O_UNIT_CD", "O_UNIT_CD"); //2
                //    //            dgv.Columns.Add("OUTPUT_AMT", "OUTPUT_AMT"); //3
                //    //            dgv.Columns.Add("PRICE", "PRICE"); //4
                //    //            dgv.Columns.Add("TOTAL_MONEY", "TOTAL_MONEY"); //5
                //    //            dgv.Columns.Add("O_INPUT_DATE", "O_INPUT_DATE"); //5
                //    //            dgv.Columns.Add("O_INPUT_CD", "O_INPUT_CD"); //5

                //    //            dgv.AllowUserToAddRows = false;

                //    //            for (int i = 0; i < workHalfGrid.Rows.Count; i++)
                //    //            {
                //    //                dgv.Rows.Add();
                //    //                dgv.Rows[dgv.Rows.Count - 1].Cells["O_LOT_NO"].Value = txt_lot_no.Text.ToString();
                //    //                dgv.Rows[dgv.Rows.Count - 1].Cells["O_LOT_SUB"].Value = "";
                //    //                dgv.Rows[dgv.Rows.Count - 1].Cells["O_ITEM_CD"].Value = workHalfGrid.Rows[i].Cells["HALF_ITEM_CD"].Value;
                //    //                dgv.Rows[dgv.Rows.Count - 1].Cells["O_UNIT_CD"].Value = workHalfGrid.Rows[i].Cells["UNIT_CD"].Value;
                //    //                dgv.Rows[dgv.Rows.Count - 1].Cells["OUTPUT_AMT"].Value = workHalfGrid.Rows[i].Cells["H_TOTAL_SOYO_AMT"].Value;
                //    //                dgv.Rows[dgv.Rows.Count - 1].Cells["PRICE"].Value = "0";
                //    //                dgv.Rows[dgv.Rows.Count - 1].Cells["TOTAL_MONEY"].Value = "0";
                //    //                dgv.Rows[dgv.Rows.Count - 1].Cells["O_INPUT_DATE"].Value = "";
                //    //                dgv.Rows[dgv.Rows.Count - 1].Cells["O_INPUT_CD"].Value = "";
                //    //            }

                //    //            string out_date = DateTime.Today.ToString("yyyy-MM-dd");

                //    //            int rsNum2 = wDm.insertHalfOut(
                //    //               out_date,
                //    //               "",
                //    //               "000",
                //    //               "Y",
                //    //               dgv);
                //    //            if (rsNum2 == 0)
                //    //            {
                //    //                //MessageBox.Show("원자재 출고가 성공되었습니다.");
                //    //                //for (int i = 0; i < workHalfGrid.Rows.Count; i++)
                //    //                //{
                //    //                //    double t_soyo_amt = double.Parse(((string)workHalfGrid.Rows[i].Cells["H_TOTAL_SOYO_AMT"].Value).Replace(",", ""));
                //    //                //    //wDmProc.prod_raw_out(txt_lot_no.Text.ToString(), (string)workRmGrid.Rows[i].Cells["RAW_MAT_CD"].Value, rst_soyo_amt);
                //    //                //}

                //    //                workHalfDetail();
                //    //            }
                //    //            else if (rsNum2 == 1)
                //    //                MessageBox.Show("저장에 실패하였습니다");
                //    //            else if (rsNum2 == 2)
                //    //                MessageBox.Show("SQL COMMAND 에러");
                //    //            else
                //    //                MessageBox.Show("Exception 에러2");
                //    //        }
                //    //    }
                //    //    else
                //    //    {
                //    //        MessageBox.Show("원자재가 이미 출고되었습니다.");
                //    //    }
                //}
            }
            else
            {
                MessageBox.Show("작업지시서 정보가 없습니다.");
                return;
            }
        }

        private bool warning_stock()  //저장 혹은 출고 할 때 재고부족 체크
        {
            int chk = 0;
            StringBuilder sb = new StringBuilder();

            if (workRmGrid != null)
            {
                for (int i = 0; i < workRmGrid.Rows.Count; i++)
                {
                    if (workRmGrid.Rows[i].Cells["RAW_MAT_CD"].Value == null || workRmGrid.Rows[i].Cells["RAW_MAT_CD"].Value.ToString().Equals(""))
                    {
                        workRmGrid.Rows.RemoveAt(i);
                        i = -1;
                    }
                }
            }
            else
            {
                MessageBox.Show("빈 행으로 저장할 수 없습니다.");
                return false;
            }

            if (workRmGrid == null || workRmGrid.Rows.Count == 0)
            {
                MessageBox.Show("빈 행으로 저장할 수 없습니다.");
                return false;
            }


            for (int i = 0; i < workRmGrid.Rows.Count; i++)
            {
                if (double.Parse((string)workRmGrid.Rows[i].Cells["EX_STOCK"].Value) < 0)
                {
                    chk++;
                    // sb.AppendLine(" No." + (string)workRmGrid.Rows[i].Cells[1].Value + ") " + (string)workRmGrid.Rows[i].Cells["RAW_MAT_NM"].Value + " ( " + (string)workRmGrid.Rows[i].Cells["SPEC"].Value + " ) ");
                }

            }

            if (chk > 0)
            {
                //MessageBox.Show("자재재고가 부족하여 진행할 수 없습니다.");
                //return false;

                sb.AppendLine("※ 자재 재고 부족 ");
                sb.AppendLine("총 " + chk.ToString() + "의 재고부족 발생 ");
                sb.AppendLine("계속 진행하시곘습니까? ");
                ComInfo comInfo = new ComInfo();
                DialogResult msgOk = comInfo.warningMessage(sb.ToString());

                if (msgOk == DialogResult.No)
                {
                    return false;
                }
            }

            chk = 0;
            sb = new StringBuilder();


            for (int i = 0; i < workHalfGrid.Rows.Count; i++)
            {
                if (int.Parse((string)workHalfGrid.Rows[i].Cells["H_EX_STOCK"].Value) < 0)
                {
                    chk++;
                    sb.AppendLine(" No." + (string)workHalfGrid.Rows[i].Cells[1].Value + ") " + (string)workHalfGrid.Rows[i].Cells["HALF_ITEM_NM"].Value + " ( " + (string)workHalfGrid.Rows[i].Cells["H_SPEC"].Value + " ) ");
                }

            }

            if (chk > 0)
            {
                sb.AppendLine("※ 반제품 재고 부족 ");
                sb.AppendLine("총 " + chk.ToString() + "의 반제품 재고부족 발생 ");
                sb.AppendLine("그래도 진행하시곘습니까? ");

                DialogResult msgOk = comInfo.warningMessage(sb.ToString());

                if (msgOk == DialogResult.No)
                {
                    return false;
                }

            }

            return true;
        }
        private void init_ComboBox()
        {
            string sqlQuery = "";

            cmb_line.ValueMember = "코드";
            cmb_line.DisplayMember = "명칭";
            sqlQuery = comInfo.queryLine();
            wConst.ComboBox_Read_Blank(cmb_line, sqlQuery);

            cmb_worker.ValueMember = "코드";
            cmb_worker.DisplayMember = "명칭";
            sqlQuery = comInfo.queryStaff();
            wConst.ComboBox_Read_Blank(cmb_worker, sqlQuery);

            cmb_mold.ValueMember = "코드";
            cmb_mold.DisplayMember = "명칭";
            sqlQuery = comInfo.queryMold();
            wConst.ComboBox_Read_Blank(cmb_mold, sqlQuery);

        }

        private void txt_inst_amt_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComInfo.onlyNum(sender, e);
        }

        private void work_list(DataGridView dgv, string condition)
        {
            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = new DataTable();
                dt = wDm.fn_Work_List(condition);

                if (dt != null && dt.Rows.Count > 0)
                {
                    dgv.RowCount = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgv.Rows[i].Cells[0].Value = dt.Rows[i]["W_INST_DATE"].ToString();
                        dgv.Rows[i].Cells[1].Value = dt.Rows[i]["W_INST_CD"].ToString();
                        dgv.Rows[i].Cells[2].Value = dt.Rows[i]["LOT_NO"].ToString();
                        dgv.Rows[i].Cells[4].Value = dt.Rows[i]["ITEM_NM"].ToString();
                        dgv.Rows[i].Cells[7].Value = dt.Rows[i]["ITEM_CD"].ToString();

                        dgv.Rows[i].Cells[6].Value = (decimal.Parse(dt.Rows[i]["INST_AMT"].ToString())).ToString("#,0.######");
                        dgv.Rows[i].Cells[8].Value = dt.Rows[i]["PLAN_NUM"].ToString();
                        dgv.Rows[i].Cells[9].Value = dt.Rows[i]["PLAN_ITEM"].ToString();
                        dgv.Rows[i].Cells[10].Value = dt.Rows[i]["ITEM_GUBUN"].ToString();
                        dgv.Rows[i].Cells[3].Value = dt.Rows[i]["CUST_NM"].ToString();

                        if (dt.Rows[i]["ITEM_GUBUN"].ToString().Equals("1"))
                        {
                            dgv.Rows[i].Cells[5].Value = "완";
                        }
                        else
                        {
                            dgv.Rows[i].DefaultCellStyle.BackColor = Color.PaleGoldenrod;
                            dgv.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                            dgv.Rows[i].DefaultCellStyle.SelectionBackColor = Color.Khaki;
                            dgv.Rows[i].DefaultCellStyle.SelectionForeColor = Color.Black;
                            dgv.Rows[i].Cells[5].Value = "반";
                        }

                    }
                    //txt_lot_no.Text = dt.Rows[dt.Rows.Count - 1]["LOT_NO"].ToString();
                }
                else
                {
                    dgv.Rows.Clear();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("시스템 오류" + e.ToString());
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(e.Message + " - " + e.ToString());
                msg.ShowDialog();
            }
        }

        private void plan_list(DataGridView dgv, string condition)
        {
            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = null;
                dt = wDm.fn_Work_Plan_List(condition);

                if (dt != null && dt.Rows.Count > 0)
                {
                    dgv.RowCount = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgv.Rows[i].Cells["P_PLAN_DATE"].Value = dt.Rows[i]["PLAN_DATE"].ToString();
                        dgv.Rows[i].Cells["P_PLAN_CD"].Value = dt.Rows[i]["PLAN_CD"].ToString();
                        dgv.Rows[i].Cells["P_PLAN_NUM"].Value = dt.Rows[i]["PLAN_NUM"].ToString();
                        //dgv.Rows[i].Cells["P_SEQ"].Value = dt.Rows[i]["SEQ"].ToString();
                        dgv.Rows[i].Cells["P_ITEM_CD"].Value = dt.Rows[i]["ITEM_CD"].ToString();
                        dgv.Rows[i].Cells["P_ITEM_NM"].Value = dt.Rows[i]["ITEM_NM"].ToString();
                        dgv.Rows[i].Cells["P_ITEM_GUBUN"].Value = dt.Rows[i]["ITEM_GUBUN"].ToString();
                        dgv.Rows[i].Cells["REQ_DATE"].Value = dt.Rows[i]["DELIVER_REQ_DATE"].ToString();
                        if (dt.Rows[i]["ITEM_GUBUN"].ToString().Equals("1"))
                        {
                            dgv.Rows[i].Cells["P_ITEM_GUBUN_NM"].Value = "s완";
                        }
                        else
                        {
                            dgv.Rows[i].DefaultCellStyle.BackColor = Color.PaleGoldenrod;
                            dgv.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                            dgv.Rows[i].DefaultCellStyle.SelectionBackColor = Color.Khaki;
                            dgv.Rows[i].DefaultCellStyle.SelectionForeColor = Color.Black;
                            dgv.Rows[i].Cells["P_ITEM_GUBUN_NM"].Value = "반";
                        }
                        dgv.Rows[i].Cells["P_SPEC"].Value = dt.Rows[i]["SPEC"].ToString();
                        dgv.Rows[i].Cells["P_CUST_CD"].Value = dt.Rows[i]["CUST_CD"].ToString();
                        dgv.Rows[i].Cells["P_CUST_NM"].Value = dt.Rows[i]["CUST_NM"].ToString();
                        dgv.Rows[i].Cells["CHAR_AMT"].Value = dt.Rows[i]["CHARGE_AMT"].ToString();
                        dgv.Rows[i].Cells["PACK_AMT"].Value = dt.Rows[i]["PACK_AMT"].ToString();
                        dgv.Rows[i].Cells["P_TOTAL_AMT"].Value = (decimal.Parse(dt.Rows[i]["TOTAL_AMT"].ToString())).ToString("#,0.######");
                        dgv.Rows[i].Cells["RES_QUAN_AMT"].Value = (decimal.Parse(dt.Rows[i]["RES_QUAN_AMT"].ToString())).ToString("#,0.######");
                        dgv.Rows[i].Cells["MOLD_CD"].Value = dt.Rows[i]["MOLD_CD"].ToString();
                        
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
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(e.Message + " - " + e.ToString());
                msg.ShowDialog();
            }

        }
        private void dataWorkGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            matPrinter.Enabled = true;
            butPrinter.Enabled = true;

            btn공정완료.Visible = true;

            btn반환.Enabled = true;

            try
            {
                if (ComInfo.grdHeaderNoAction(e))
                {
                    btnDelete.Enabled = true;
                    lbl_work_gbn.Text = "1";
                    txt_work_date.Enabled = false;

                    workDetail(dataWorkGrid, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("시스템 에러" + ex.ToString());
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                msg.ShowDialog();
            }
        }

        private void workSrchGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            matPrinter.Enabled = true;
            butPrinter.Enabled = true;

            btn반환.Enabled = true;

            try
            {
                if (ComInfo.grdHeaderNoAction(e))
                {
                    btnDelete.Enabled = true;
                    lbl_work_gbn.Text = "1";
                    txt_work_date.Enabled = false;

                    workDetail(workSrchGrid, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("시스템 에러" + ex.ToString());
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                msg.ShowDialog();
            }
        }

        private void workPlanList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //btn공정완료.Visible = true;
            chk_raw.Checked = false;
            chk_raw.Enabled = true;

            //생산계획에서는 출력버튼 안되도록
            matPrinter.Enabled = false;
            butPrinter.Enabled = false;

            btn반환.Enabled = true;


            try
            {
                if (ComInfo.grdHeaderNoAction(e))
                {
                    btnDelete.Enabled = false;
                    lbl_work_gbn.Text = "";
                    txt_work_date.Enabled = true;

                    btnCustSrch.Enabled = false;
                    btnItemSrch.Enabled = false;

                    workPlanDetail(workPlanList, e);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("시스템 에러" + ex.ToString());
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                msg.ShowDialog();
            }
        }

        private void workDetail(DataGridView dgv, DataGridViewCellEventArgs e)
        {
            wnDm wDm = new wnDm();
            DataTable dt = null;

            dt = wDm.fn_Work_Detail_List("where A.W_INST_DATE = '" + dgv.Rows[e.RowIndex].Cells[0].Value.ToString() + "' and A.W_INST_CD = '" + dgv.Rows[e.RowIndex].Cells[1].Value.ToString() + "' ");

            if (dt != null && dt.Rows.Count > 0)
            {
                txt_work_date.Text = dt.Rows[0]["W_INST_DATE"].ToString();
                txt_work_cd.Text = dt.Rows[0]["W_INST_CD"].ToString();
                txt_lot_no.Text = dt.Rows[0]["LOT_NO"].ToString();
                txt_item_nm.Text = dt.Rows[0]["ITEM_NM"].ToString();
                txt_item_cd.Text = dt.Rows[0]["ITEM_CD"].ToString();
                old_item_nm = dt.Rows[0]["ITEM_CD"].ToString();
                txt_spec.Text = dt.Rows[0]["SPEC"].ToString();
                txt_inst_amt.Text = (decimal.Parse(dt.Rows[0]["INST_AMT"].ToString())).ToString("#,0.######");
                delivery_req_date.Text = dt.Rows[0]["DELIVERY_DATE"].ToString();
                cmb_line.SelectedValue = dt.Rows[0]["LINE_CD"].ToString();
                cmb_worker.SelectedValue = dt.Rows[0]["WORKER_CD"].ToString();
                txt_cust_nm.Text = dt.Rows[0]["CUST_NM"].ToString();
                txt_cust_cd.Text = dt.Rows[0]["CUST_CD"].ToString();
                old_cust_nm = dt.Rows[0]["ITEM_CD"].ToString();

                old_inst_amt.Text = dt.Rows[0]["INST_AMT"].ToString();
                txt_plan_num.Text = dt.Rows[0]["PLAN_NUM"].ToString();
                txt_plan_item.Text = dt.Rows[0]["PLAN_ITEM"].ToString(); //PLAN_SEQ
                txt_inst_notice.Text = dt.Rows[0]["INST_NOTICE"].ToString();

                txt_char_amt.Text = dt.Rows[0]["CHARGE_AMT"].ToString();
                txt_pack_amt.Text = dt.Rows[0]["PACK_AMT"].ToString();

                if (dt.Rows[0]["RAW_OUT_YN"].ToString().Equals("Y"))
                {
                    chk_out_yn.Checked = true;
                    //btnRawOut.Enabled = false;
                    // btnRawOut.Visible = false;
                    chk_raw.Checked = true;
                    chk_raw.Enabled = false;
                }
                else
                {
                    chk_raw.Enabled = true;
                    chk_out_yn.Checked = false;
                    //btnRawOut.Enabled = true;
                    // btnRawOut.Visible = true;
                    chk_raw.Checked = false;

                }

                if (dt.Rows[0]["POOR_WORK_YN"].ToString().Equals("Y"))
                {
                    chk_poor_yn.Checked = true;
                }
                else
                {
                    chk_poor_yn.Checked = false;
                }

                if (dt.Rows[0]["FLOW_YN"].ToString().Equals("Y"))
                {
                    chk_flow_yn.Checked = true;
                    btn공정완료.Visible = false;
                }
                else
                {
                    chk_flow_yn.Checked = false;
                    btn공정완료.Visible = true;

                }

                workRmDetail();
                workHalfDetail();
            }
            else
            {
                dgv.Rows.Clear();
            }
        }

        private void workPlanDetail(DataGridView dgv, DataGridViewCellEventArgs e)
        {
            txt_work_date.Text = dgv.Rows[e.RowIndex].Cells["P_PLAN_DATE"].Value.ToString();
            txt_work_cd.Text = dgv.Rows[e.RowIndex].Cells["P_PLAN_CD"].Value.ToString();
            txt_lot_no.Text = "";
            txt_item_nm.Text = dgv.Rows[e.RowIndex].Cells["P_ITEM_NM"].Value.ToString();
            txt_item_cd.Text = dgv.Rows[e.RowIndex].Cells["P_ITEM_CD"].Value.ToString();
            old_item_nm = dgv.Rows[e.RowIndex].Cells["P_ITEM_NM"].Value.ToString();
            txt_spec.Text = dgv.Rows[e.RowIndex].Cells["P_SPEC"].Value.ToString();
            txt_inst_amt.Text = (decimal.Parse(dgv.Rows[e.RowIndex].Cells["RES_QUAN_AMT"].Value.ToString())).ToString("#,0.######");
            old_inst_amt.Text = dgv.Rows[e.RowIndex].Cells["P_TOTAL_AMT"].Value.ToString();
            delivery_req_date.Text = dgv.Rows[e.RowIndex].Cells["REQ_DATE"].Value.ToString();
            //cmb_line.SelectedValue = dt.Rows[0]["LINE_NM"].ToString();
            //cmb_worker.SelectedValue = dt.Rows[0]["WORKER_NM"].ToString();
            txt_cust_nm.Text = dgv.Rows[e.RowIndex].Cells["P_CUST_NM"].Value.ToString();
            txt_cust_cd.Text = dgv.Rows[e.RowIndex].Cells["P_CUST_CD"].Value.ToString();
            old_cust_nm = dgv.Rows[e.RowIndex].Cells["P_CUST_NM"].Value.ToString();

            txt_plan_num.Text = dgv.Rows[e.RowIndex].Cells["P_PLAN_NUM"].Value.ToString();
            txt_plan_item.Text = dgv.Rows[e.RowIndex].Cells["P_ITEM_CD"].Value.ToString();

            txt_char_amt.Text = dgv.Rows[e.RowIndex].Cells["CHAR_AMT"].Value.ToString();
            txt_pack_amt.Text = dgv.Rows[e.RowIndex].Cells["PACK_AMT"].Value.ToString();
            cmb_mold.SelectedValue = dgv.Rows[e.RowIndex].Cells["MOLD_CD"].Value.ToString();
            chk_poor_yn.Checked = false;
            chk_flow_yn.Checked = false;
            chk_out_yn.Checked = false;
            // btnRawOut.Enabled = true;
            // btnRawOut.Visible = true;

            //workPlnRmDetail(dgv.Rows[e.RowIndex].Cells["P_PLAN_DATE"].Value.ToString(),dgv.Rows[e.RowIndex].Cells["P_PLAN_CD"].Value.ToString(),txt_plan_seq.Text.ToString());
            workItemSelectDetail();
        }

        private void workRmDetail()
        {
            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = null;

                string condition = "where A.W_INST_DATE = '" + txt_work_date.Text.ToString() + "' and A.W_INST_CD = '" + txt_work_cd.Text.ToString() + "' ";
                dt = wDm.fn_Work_Rm_Detail_List(condition);

                workRmGrid.Rows.Clear();

                if (dt != null && dt.Rows.Count > 0)
                {
                    workRmGrid.RowCount = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        workRmGrid.Rows[i].Cells["WORK_INST_DATE"].Value = dt.Rows[i]["W_INST_DATE"].ToString();
                        workRmGrid.Rows[i].Cells["WORK_INST_CD"].Value = dt.Rows[i]["W_INST_CD"].ToString();
                        workRmGrid.Rows[i].Cells["SEQ"].Value = dt.Rows[i]["SEQ"].ToString();
                        workRmGrid.Rows[i].Cells["RAW_MAT_CD"].Value = dt.Rows[i]["RAW_MAT_CD"].ToString();
                        workRmGrid.Rows[i].Cells["RAW_MAT_NM"].Value = dt.Rows[i]["RAW_MAT_NM"].ToString();
                        workRmGrid.Rows[i].Cells["SPEC"].Value = dt.Rows[i]["SPEC"].ToString();
                        workRmGrid.Rows[i].Cells["CUST_CD"].Value = dt.Rows[i]["CUST_CD"].ToString();
                        workRmGrid.Rows[i].Cells["CUST_NM"].Value = dt.Rows[i]["CUST_NM"].ToString();
                        workRmGrid.Rows[i].Cells["INPUT_UNIT"].Value = dt.Rows[i]["INPUT_UNIT"].ToString();
                        workRmGrid.Rows[i].Cells["INPUT_UNIT_NM"].Value = dt.Rows[i]["INPUT_UNIT_NM"].ToString();
                        workRmGrid.Rows[i].Cells["OUTPUT_UNIT"].Value = dt.Rows[i]["OUTPUT_UNIT"].ToString();
                        workRmGrid.Rows[i].Cells["OUTPUT_UNIT_NM"].Value = dt.Rows[i]["OUTPUT_UNIT_NM"].ToString();
                        workRmGrid.Rows[i].Cells["SOYO_AMT"].Value = (decimal.Parse(dt.Rows[i]["SOYO_AMT"].ToString())).ToString("#,0.######");
                        workRmGrid.Rows[i].Cells["TOTAL_SOYO_AMT"].Value = (decimal.Parse(dt.Rows[i]["TOTAL_SOYO_AMT"].ToString())).ToString("#,0.######");
                        workRmGrid.Rows[i].Cells["BAL_STOCK"].Value = (decimal.Parse(dt.Rows[i]["BAL_STOCK"].ToString())).ToString("#,0.######");
                        workRmGrid.Rows[i].Cells["CVR_RATIO"].Value = dt.Rows[i]["CVR_RATIO"].ToString();

                        workRmGrid.Rows[i].Cells["EX_STOCK"].Value = ex_stock_cal(dt.Rows[i]["BAL_STOCK"].ToString(), dt.Rows[i]["TOTAL_SOYO_AMT"].ToString(), dt.Rows[i]["CVR_RATIO"].ToString());

                        workRmGrid.Rows[i].Cells["OLD_SOYO_AMT"].Value = (decimal.Parse(dt.Rows[i]["SOYO_AMT"].ToString())).ToString("#,0.######");

                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("원자재 내역 시스템 에러" + e.ToString());
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(e.Message + " - " + e.ToString());
                msg.ShowDialog();
            }
        }

        private void workHalfDetail()
        {
            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = null;

                string condition = "where A.W_INST_DATE = '" + txt_work_date.Text.ToString() + "' and A.W_INST_CD = '" + txt_work_cd.Text.ToString() + "' ";
                dt = wDm.fn_Work_Half_Detail_List(condition);

                workHalfGrid.Rows.Clear();

                if (dt != null && dt.Rows.Count > 0)
                {
                    workHalfGrid.RowCount = dt.Rows.Count;

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        workHalfGrid.Rows[i].Cells[0].Value = (i + 1).ToString();
                        workHalfGrid.Rows[i].Cells["HALF_ITEM_CD"].Value = dt.Rows[i]["HALF_ITEM_CD"].ToString();
                        workHalfGrid.Rows[i].Cells["HALF_ITEM_NM"].Value = dt.Rows[i]["ITEM_NM"].ToString();
                        workHalfGrid.Rows[i].Cells["H_SPEC"].Value = dt.Rows[i]["SPEC"].ToString();
                        workHalfGrid.Rows[i].Cells["H_CUST_CD"].Value = dt.Rows[i]["CUST_CD"].ToString();
                        workHalfGrid.Rows[i].Cells["H_CUST_NM"].Value = dt.Rows[i]["CUST_NM"].ToString();
                        workHalfGrid.Rows[i].Cells["UNIT_CD"].Value = dt.Rows[i]["UNIT_CD"].ToString();
                        workHalfGrid.Rows[i].Cells["UNIT_NM"].Value = dt.Rows[i]["UNIT_NM"].ToString();
                        workHalfGrid.Rows[i].Cells["H_SOYO_AMT"].Value = (decimal.Parse(dt.Rows[i]["SOYO_AMT"].ToString())).ToString("#,0.######");
                        workHalfGrid.Rows[i].Cells["H_TOTAL_SOYO_AMT"].Value = (decimal.Parse(dt.Rows[i]["TOTAL_SOYO_AMT"].ToString())).ToString("#,0.######");
                        workHalfGrid.Rows[i].Cells["H_BAL_STOCK"].Value = (decimal.Parse(dt.Rows[i]["BAL_STOCK"].ToString())).ToString("#,0.######");
                        workHalfGrid.Rows[i].Cells["H_SEQ"].Value = dt.Rows[i]["SEQ"].ToString();

                        workHalfGrid.Rows[i].Cells["H_EX_STOCK"].Value = ex_stock_cal(dt.Rows[i]["BAL_STOCK"].ToString(), dt.Rows[i]["TOTAL_SOYO_AMT"].ToString(), "1");


                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("원자재 내역 시스템 에러" + e.ToString());
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(e.Message + " - " + e.ToString());
                msg.ShowDialog();
            }
        }
        private void workItemSelectDetail()
        {
            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = null;

                string condition = "where A.ITEM_CD = '" + txt_item_cd.Text.ToString() + "' ";
                dt = wDm.fn_Work_Rm_Default_List(double.Parse(txt_inst_amt.Text.ToString()), condition);

                workRmGrid.Rows.Clear();

                if (dt != null && dt.Rows.Count > 0)
                {
                    workRmGrid.RowCount = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        workRmGrid.Rows[i].Cells["RAW_MAT_CD"].Value = dt.Rows[i]["RAW_MAT_CD"].ToString();
                        workRmGrid.Rows[i].Cells["RAW_MAT_NM"].Value = dt.Rows[i]["RAW_MAT_NM"].ToString();
                        workRmGrid.Rows[i].Cells["SPEC"].Value = dt.Rows[i]["SPEC"].ToString();
                        workRmGrid.Rows[i].Cells["CUST_CD"].Value = dt.Rows[i]["CUST_CD"].ToString();
                        workRmGrid.Rows[i].Cells["CUST_NM"].Value = dt.Rows[i]["CUST_NM"].ToString();
                        workRmGrid.Rows[i].Cells["INPUT_UNIT"].Value = dt.Rows[i]["INPUT_UNIT"].ToString();
                        workRmGrid.Rows[i].Cells["INPUT_UNIT_NM"].Value = dt.Rows[i]["INPUT_UNIT_NM"].ToString();
                        workRmGrid.Rows[i].Cells["OUTPUT_UNIT"].Value = dt.Rows[i]["OUTPUT_UNIT"].ToString();
                        workRmGrid.Rows[i].Cells["OUTPUT_UNIT_NM"].Value = dt.Rows[i]["OUTPUT_UNIT_NM"].ToString();
                        workRmGrid.Rows[i].Cells["SOYO_AMT"].Value = (decimal.Parse(dt.Rows[i]["SOYO_AMT"].ToString())).ToString("#,0.######");
                        workRmGrid.Rows[i].Cells["TOTAL_SOYO_AMT"].Value = (decimal.Parse(dt.Rows[i]["TOTAL_SOYO_AMT"].ToString())).ToString("#,0.######");
                        //workRmGrid.Rows[i].Cells["NI_UNIT_CD"].Value = dt.Rows[i]["UNIT_CD"].ToString();
                        workRmGrid.Rows[i].Cells["BAL_STOCK"].Value = (decimal.Parse(dt.Rows[i]["BAL_STOCK"].ToString())).ToString("#,0.######");
                        workRmGrid.Rows[i].Cells["CVR_RATIO"].Value = dt.Rows[i]["CVR_RATIO"].ToString();
                        workRmGrid.Rows[i].Cells["RAW_MAT_GUBUN"].Value = dt.Rows[i]["S_CODE_NM"].ToString();
                        //RAW_MAT_GUBUN
                        workRmGrid.Rows[i].Cells["EX_STOCK"].Value = ex_stock_cal(dt.Rows[i]["BAL_STOCK"].ToString(), dt.Rows[i]["TOTAL_SOYO_AMT"].ToString(), dt.Rows[i]["CVR_RATIO"].ToString());

                        workRmGrid.Rows[i].Cells["OLD_SOYO_AMT"].Value = (decimal.Parse(dt.Rows[i]["SOYO_AMT"].ToString())).ToString("#,0.######");

                    }
                }

                dt = wDm.fn_Work_Half_Default_List(double.Parse(txt_inst_amt.Text.ToString()), condition);
                workHalfGrid.Rows.Clear();

                if (dt != null && dt.Rows.Count > 0)
                {
                    workHalfGrid.RowCount = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        workHalfGrid.Rows[i].Cells[0].Value = (i + 1).ToString();
                        workHalfGrid.Rows[i].Cells["HALF_ITEM_CD"].Value = dt.Rows[i]["HALF_ITEM_CD"].ToString();
                        workHalfGrid.Rows[i].Cells["HALF_ITEM_NM"].Value = dt.Rows[i]["HALF_ITEM_NM"].ToString();
                        workHalfGrid.Rows[i].Cells["H_SPEC"].Value = dt.Rows[i]["SPEC"].ToString();
                        workHalfGrid.Rows[i].Cells["H_CUST_CD"].Value = dt.Rows[i]["CUST_CD"].ToString();
                        workHalfGrid.Rows[i].Cells["H_CUST_NM"].Value = dt.Rows[i]["CUST_NM"].ToString();
                        workHalfGrid.Rows[i].Cells["UNIT_CD"].Value = dt.Rows[i]["UNIT_CD"].ToString();
                        workHalfGrid.Rows[i].Cells["UNIT_NM"].Value = dt.Rows[i]["UNIT_NM"].ToString();
                        workHalfGrid.Rows[i].Cells["H_SOYO_AMT"].Value = (decimal.Parse(dt.Rows[i]["SOYO_AMT"].ToString())).ToString("#,0.######");
                        workHalfGrid.Rows[i].Cells["H_TOTAL_SOYO_AMT"].Value = (decimal.Parse(dt.Rows[i]["TOTAL_SOYO_AMT"].ToString())).ToString("#,0.######");
                        workHalfGrid.Rows[i].Cells["H_BAL_STOCK"].Value = dt.Rows[i]["BAL_STOCK"].ToString();

                        workHalfGrid.Rows[i].Cells["H_EX_STOCK"].Value = ex_stock_cal(dt.Rows[i]["BAL_STOCK"].ToString(), dt.Rows[i]["TOTAL_SOYO_AMT"].ToString(), "1");

                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("원자재 & 반제품 내역 시스템 에러" + e.ToString());
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(e.Message + " - " + e.ToString());
                msg.ShowDialog();
            }
        }

        private void workPlnRmDetail(string plan_date, string plan_cd, string plan_seq) //일단 보류 workItemSelectDetail와 같음 
        {
            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = null;

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("where A.PLAN_DATE = '" + plan_date.ToString() + "' ");
                sb.AppendLine(" and A.PLAN_CD = '" + plan_cd.ToString() + "' ");
                sb.AppendLine(" and B.SEQ = '" + plan_seq.ToString() + "' ");

                dt = wDm.fn_Work_Pln_Rm_Detail_List(sb.ToString());

                workRmGrid.Rows.Clear();

                if (dt != null && dt.Rows.Count > 0)
                {
                    workRmGrid.RowCount = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        workRmGrid.Rows[i].Cells["RAW_MAT_CD"].Value = dt.Rows[i]["RAW_MAT_CD"].ToString();
                        workRmGrid.Rows[i].Cells["RAW_MAT_NM"].Value = dt.Rows[i]["RAW_MAT_NM"].ToString();
                        workRmGrid.Rows[i].Cells["SPEC"].Value = dt.Rows[i]["SPEC"].ToString();
                        workRmGrid.Rows[i].Cells["CUST_CD"].Value = dt.Rows[i]["CUST_CD"].ToString();
                        workRmGrid.Rows[i].Cells["CUST_NM"].Value = dt.Rows[i]["CUST_NM"].ToString();
                        workRmGrid.Rows[i].Cells["INPUT_UNIT"].Value = dt.Rows[i]["INPUT_UNIT"].ToString();
                        workRmGrid.Rows[i].Cells["INPUT_UNIT_NM"].Value = dt.Rows[i]["INPUT_UNIT_NM"].ToString();
                        workRmGrid.Rows[i].Cells["OUTPUT_UNIT"].Value = dt.Rows[i]["OUTPUT_UNIT"].ToString();
                        workRmGrid.Rows[i].Cells["OUTPUT_UNIT_NM"].Value = dt.Rows[i]["OUTPUT_UNIT_NM"].ToString();
                        workRmGrid.Rows[i].Cells["SOYO_AMT"].Value = (decimal.Parse(dt.Rows[i]["SOYO_AMT"].ToString())).ToString("#,0.######");
                        workRmGrid.Rows[i].Cells["TOTAL_SOYO_AMT"].Value = (decimal.Parse(dt.Rows[i]["TOTAL_SOYO_AMT"].ToString())).ToString("#,0.######");
                        //workRmGrid.Rows[i].Cells["NI_UNIT_CD"].Value = dt.Rows[i]["UNIT_CD"].ToString();
                        workRmGrid.Rows[i].Cells["BAL_STOCK"].Value = (decimal.Parse(dt.Rows[i]["BAL_STOCK"].ToString())).ToString("#,0.######");
                        workRmGrid.Rows[i].Cells["CVR_RATIO"].Value = dt.Rows[i]["CVR_RATIO"].ToString();


                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("원자재 내역 시스템 에러" + e.ToString());
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(e.Message + " - " + e.ToString());
                msg.ShowDialog();
            }
        }
        private void work_del()
        {
            ComInfo comInfo = new ComInfo();
            DialogResult msgOk = comInfo.deleteConfrim("작업지시서 ", txt_work_date.Text.ToString() + " - " + txt_work_cd.Text.ToString());

            if (msgOk == DialogResult.No)
            {
                return;
            }
            

            wnDm wDm = new wnDm();

            DataTable dt = wDm.fn_Is_item_output(" and LOT_NO = '"+txt_lot_no.Text+"'  ");
            if (dt != null && dt.Rows.Count > 0)
            {
                MessageBox.Show("이미 해당 작업지시에 생산된 제품이 출고되어 삭제할 수 없습니다. ");
                return;
            }

            dt =wDm.fn_Item_Input_List(" and Z.LOT_NO = '"+txt_lot_no.Text.ToString()+"'  ");
            if (dt != null && dt.Rows.Count > 0)
            {
                msgOk = comInfo.warningMessage("<제품 재고 변동>\n이미 작업이 진행되어 생산된 제품이 있습니다.\n이 작업지시서를 삭제하면 생산된 제품까지 동시에 삭제되게 됩니다.\n\n 그래도 삭제하시겠습니까?");

                if (msgOk == DialogResult.No)
                {
                    return;
                }
            }


            int rsNum = wDm.deleteWork(txt_work_date.Text.ToString(), txt_work_cd.Text.ToString(), txt_lot_no.Text.ToString());
            if (rsNum == 0)
            {
                resetSetting();
                //work_list(dataWorkGrid, "where convert(varchar(10), A.INTIME, 120) = convert(varchar(10), getDate(), 120) ");

                today_logic();
                plan_logic();
                srch_logic();

                MessageBox.Show("성공적으로 삭제하였습니다.");

                //int rsNum2 = wDm.updateStRaw(inputRmGrid);

                //if (rsNum2 == 0)
                //{
                //    resetSetting();

                //    input_list(tdInputGrid, "where convert(varchar(10), A.INTIME, 120) = convert(varchar(10), getDate(), 120) ");
                //    input_list(inputGrid, "where A.INPUT_DATE >= '" + start_date.Text.ToString() + "' and  A.INPUT_DATE <= '" + end_date.Text.ToString() + "'");

                //    MessageBox.Show("성공적으로 삭제하였습니다.");
                //}
                //else if (rsNum == 1)
                //{
                //    MessageBox.Show("저장에 실패하였습니다");
                //}
                //else
                //{
                //    MessageBox.Show("Exception 에러");

                //}
            }
            else
            {
                MessageBox.Show("삭제에 실패하였습니다.");
            }
        }

        private void tbWorkControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbWorkControl.SelectedIndex == 0)
            {
                today_logic();
                txt_lot_no.Text = "";
            }
            else if (tbWorkControl.SelectedIndex == 1)
            {
                plan_logic();
                txt_lot_no.Text = "";
            }
            else
            {
                start_date.Text = DateTime.Today.AddMonths(-1).ToString("yyyy-MM-dd");
                srch_logic();
                txt_lot_no.Text = "";
            }
        }

        private void btnSrch_Click(object sender, EventArgs e)
        {
            srch_logic();
        }

        private void today_logic()
        {
            work_list(dataWorkGrid, "where convert(varchar(10), A.INTIME, 120) = convert(varchar(10), getDate(), 120) ");
        }

        private void plan_logic()
        {
            plan_list(workPlanList, "where B.WORK_YN = 'N' ");
        }

        private void srch_logic()
        {
            work_list(workSrchGrid, "where A.W_INST_DATE >= '" + start_date.Text.ToString() + "' and  A.W_INST_DATE <= '" + end_date.Text.ToString() + "'");
        }

        private void grdCellSetting()
        {
            ComInfo comInfo = new ComInfo();
            //comInfo.grdCellSetting(dataWorkGrid);
            //comInfo.grdCellSetting(workPlanList);
            //comInfo.grdCellSetting(workSrchGrid);

            //comInfo.grdCellSetting(workRmGrid);
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

        private void txt_inst_amt_KeyDown(object sender, KeyEventArgs e)
        {
            //
            // Detect the KeyEventArg's key enumerated constant.
            //
            if (e.KeyCode == Keys.Enter)
            {
                soyo_renewal();
                SendKeys.Send("{TAB}");
            }
        }

        private void txt_inst_amt_TextChanged(object sender, EventArgs e)
        {
            if (txt_inst_amt.Text.ToString().Equals(""))
            {
                txt_inst_amt.Text = "0";
            }
        }

        private void txt_inst_amt_Leave(object sender, EventArgs e)
        {
            soyo_renewal();
        }

        private string ex_stock_cal(string b_stock, string ts_amt, string c_ratio)
        {
            double bal_stock = double.Parse(b_stock);
            double total_soyo_amt = double.Parse(ts_amt);
            double cvr_ratio = double.Parse(c_ratio);

            string rs_ex_stock = (bal_stock - (total_soyo_amt * cvr_ratio)).ToString("#,0.######");

            if (btnRawOut.Enabled == true) //자재소요가 소모 되지 않았을 때
            {
                rs_ex_stock = (bal_stock - (total_soyo_amt * cvr_ratio)).ToString("#,0.######");
            }
            else //자재소요가 소모 되었을 때  
            {
                rs_ex_stock = (bal_stock).ToString("#,0.######"); //이미 자재가 소모되었기 때문에 현 재고로 잡는다.
            }
            return rs_ex_stock;
        }
        private void soyo_renewal()
        {
            for (int i = 0; i < workRmGrid.Rows.Count; i++)
            {
                string rs_soyo_amt = (double.Parse((string)workRmGrid.Rows[i].Cells["SOYO_AMT"].Value) * double.Parse(txt_inst_amt.Text.ToString())).ToString();
                workRmGrid.Rows[i].Cells["TOTAL_SOYO_AMT"].Value = decimal.Parse(rs_soyo_amt).ToString("#,0.######");

                workRmGrid.Rows[i].Cells["EX_STOCK"].Value = ex_stock_cal((string)workRmGrid.Rows[i].Cells["BAL_STOCK"].Value, (string)workRmGrid.Rows[i].Cells["TOTAL_SOYO_AMT"].Value, (string)workRmGrid.Rows[i].Cells["CVR_RATIO"].Value);
            }

            for (int i = 0; i < workHalfGrid.Rows.Count; i++)
            {
                string rs_soyo_amt = (double.Parse((string)workHalfGrid.Rows[i].Cells["H_SOYO_AMT"].Value.ToString().Replace(",","")) * double.Parse(txt_inst_amt.Text.ToString().Replace(",",""))).ToString();
                workHalfGrid.Rows[i].Cells["H_TOTAL_SOYO_AMT"].Value = decimal.Parse(rs_soyo_amt).ToString("#,0.######");
                workHalfGrid.Rows[i].Cells["H_EX_STOCK"].Value = decimal.Parse(workHalfGrid.Rows[i].Cells["H_BAL_STOCK"].Value.ToString()) - decimal.Parse(rs_soyo_amt);
            }
        }

        private void matPrinter_Click(object sender, EventArgs e)
        {
            DialogResult msgOk = MessageBox.Show("자재요청서를 발행하시겠습니까?", "발행여부", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (msgOk == DialogResult.No)
            {
                return;
            }

            this.공정이동표출력("자재요청서");
            //---- 동시에 출력이 안됨 : 마지막거만 진행 --> frmPrt를 바꿔서 해보면 어'떨까?
        }

        private void butPrinter_Click(object sender, EventArgs e)
        {
            DialogResult msgOk = MessageBox.Show("공정이동표를 발행하시겠습니까?", "발행여부", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (msgOk == DialogResult.No)
            {
                return;
            }

            this.공정이동표출력("공정이동표");
            //this.공정이동표출력("자재요청리스트");
            //---- 동시에 출력이 안됨 : 마지막거만 진행 --> frmPrt를 바꿔서 해보면 어'떨까?
        }
        //-------------------------------------------------------------------------//
        public void 공정이동표출력(string strGB)
        {
            string sValue = "" + txt_work_date.Text.Trim();
            //string sValue2 = "" + lbl카운터.Text.Trim();
            string sValue2 = "";
            string sValue3 = "" + txt_work_cd.Text.Trim();

            if (sValue == "") return;

            getDetail공정이동표(sValue, sValue3, strGB);
            if (txt_work_cd.Text.Trim() == "")
            {
                MessageBox.Show("출력할 자료가 없습니다.");
                return;
            }
            else
            {
                if (strGB == "공정이동표")
                {
                    strCondition = "공정이동표";

                    frmPrt = readyPrt;
                    frmPrt.Show();
                    frmPrt.BringToFront();
                    frmPrt.prt_공정이동표(adoPrt, this.txt_work_date.Text, this.txt_work_cd.Text, "공정이동표");
                }
                else
                {
                    strCondition = "자재요청서";

                    frmPrt = readyPrt;
                    frmPrt.Show();
                    frmPrt.BringToFront();
                    frmPrt.prt_공정이동표(adoPrt, this.txt_work_date.Text, this.txt_work_cd.Text, "자재요청서");
                }
            }
        }
        //-------------------------------------------------------------------------//
        private void getDetail공정이동표(string sKey, string sKey3, string strGB)
        {
            //workRmGrid.Rows.Clear();

            try
            {
                wnDm3 wDm = new wnDm3();
                DataTable dt = null;
                if (strGB == "공정이동표")
                {
                    dt = wDm.fn_F_WORK_INST_Print(sKey, sKey3);     //공정이동표
                }
                else
                {
                    dt = wDm.fn_F_WORK_INST_DETAIL_Print(sKey, sKey3);     //자재요청리스트
                }

                //-- 출력을 위한 테이블 --
                adoPrt = new DataTable();
                adoPrt = dt.Copy();
                //------------------------
                //wConst.get_PComp_Info();
                ////------------------------

                if (dt != null && dt.Rows.Count > 0)
                {
                    //bEditText = false;

                    for (int kk = 0; kk < dt.Rows.Count; kk++)
                    {
                        dt.Rows[kk]["SEQ"] = (kk + 1); //숫자의 경우  문자면 .string : 계산된 값을 READ 한 테이블로 다시 전달한다 - 출력물 사용

                        adoPrt = dt.Copy();
                    }
                }

                //-- 출력을 위한 테이블 --
                adoPrt = dt.Copy();
                //------------------------
            }
            catch (Exception ex){
wnLog.writeLog(wnLog.LOG_ERROR, ex.Message + " - " + ex.ToString());Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                msg.ShowDialog();
            }
        }

        private void grid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            conDataGridView grd = (conDataGridView)sender;
            DataGridViewCell cell = grd[e.ColumnIndex, e.RowIndex];

            if (grd.Columns[e.ColumnIndex].ToolTipText.IndexOf("명칭") >= 0 && grd._KeyInput == "enter")
            {

                if (txt_item_cd.Text.ToString().Equals(""))
                {
                    MessageBox.Show("제품을 선택하시기 바랍니다.");
                    return;
                }

                string rat_mat_nm = (string)grd.Rows[e.RowIndex].Cells["RAW_MAT_NM"].Value;
                wnDm wDm = new wnDm();
                DataTable dt = new DataTable();
                dt = wDm.fn_Raw_List("where RAW_MAT_NM like '%" + rat_mat_nm + "%' ", "2");

                if (dt.Rows.Count > 1)
                { //row가 2줄이 넘을 경우 팝업으로 넘어간다.

                    wConst.call_pop_raw_mat(grd, dt, e.RowIndex, rat_mat_nm, 3, "");
                }
                else if (dt.Rows.Count == 1) //row가 1일 경우 해당 row에 값을 자동 입력한다.
                {
                    grd.Rows[e.RowIndex].Cells["RAW_MAT_CD"].Value = dt.Rows[0]["RAW_MAT_CD"].ToString();
                    grd.Rows[e.RowIndex].Cells["RAW_MAT_NM"].Value = dt.Rows[0]["RAW_MAT_NM"].ToString();
                    grd.Rows[e.RowIndex].Cells["SPEC"].Value = dt.Rows[0]["SPEC"].ToString();
                    grd.Rows[e.RowIndex].Cells["INPUT_UNIT"].Value = dt.Rows[0]["INPUT_UNIT"].ToString();
                    grd.Rows[e.RowIndex].Cells["OUTPUT_UNIT"].Value = dt.Rows[0]["OUTPUT_UNIT"].ToString();
                    grd.Rows[e.RowIndex].Cells["INPUT_UNIT_NM"].Value = dt.Rows[0]["INPUT_UNIT_NM"].ToString();
                    grd.Rows[e.RowIndex].Cells["OUTPUT_UNIT_NM"].Value = dt.Rows[0]["OUTPUT_UNIT_NM"].ToString();
                    grd.Rows[e.RowIndex].Cells["BAL_STOCK"].Value = dt.Rows[0]["BAL_STOCK"].ToString();
                    grd.Rows[e.RowIndex].Cells["CUST_CD"].Value = dt.Rows[0]["CUST_CD"].ToString();
                    grd.Rows[e.RowIndex].Cells["CUST_NM"].Value = dt.Rows[0]["CUST_NM"].ToString();
                    grd.Rows[e.RowIndex].Cells["CVR_RATIO"].Value = dt.Rows[0]["CVR_RATIO"].ToString();

                    if (dt.Rows[0]["CUST_CD"].ToString() == "dregs")
                    {
                        grd.Rows[e.RowIndex].Cells["INPUT_DATE"].Value = dt.Rows[0]["INPUT_DATE"].ToString();
                        grd.Rows[e.RowIndex].Cells["INPUT_CD"].Value = dt.Rows[0]["INPUT_CD"].ToString();
                        grd.Rows[e.RowIndex].Cells["INPUT_SEQ"].Value = dt.Rows[0]["SEQ"].ToString();
                    }

                }

                grd.Rows[e.RowIndex].Cells["SOYO_AMT"].Value = "0";
                grd.Rows[e.RowIndex].Cells["TOTAL_SOYO_AMT"].Value = "0";

                string raw_mat_cd = (string)grd.Rows[e.RowIndex].Cells["RAW_MAT_CD"].Value;
                for (int i = 0; i < grd.Rows.Count; i++)
                {
                    if (i != e.RowIndex)
                    {
                        if (raw_mat_cd == (string)grd.Rows[i].Cells["RAW_MAT_CD"].Value && "dregs" != (string)grd.Rows[e.RowIndex].Cells["CUST_NM"].Value)
                        {
                            grd.Rows.RemoveAt(grd.SelectedRows[0].Index);
                            MessageBox.Show("원자재가 이미 존재합니다.");
                            break;
                        }
                    }
                }
            }
            else if (grd.Columns[e.ColumnIndex].ToolTipText.IndexOf("소요량") >= 0)
            {
                if (btnRawOut.Enabled == true)
                {
                    string s소요 = ("" + (string)grd.Rows[e.RowIndex].Cells["SOYO_AMT"].Value).Replace(",", "");
                    string s지시 = txt_inst_amt.Text.ToString().Replace(",", "");

                    string s재고 = ("" + (string)grd.Rows[e.RowIndex].Cells["BAL_STOCK"].Value).Replace(",", "");
                    if (s소요 != "" && s지시 != "")
                    {
                        string s금액 = (decimal.Parse(s소요) * decimal.Parse(s지시)).ToString();

                        grd.Rows[e.RowIndex].Cells["TOTAL_SOYO_AMT"].Value = (decimal.Parse(s금액)).ToString("#,0.######");
                        grd.Rows[e.RowIndex].Cells["EX_STOCK"].Value = (decimal.Parse(s재고) - decimal.Parse(s금액)).ToString("#,0.######");

                        grd.Rows[e.RowIndex].Cells["OLD_SOYO_AMT"].Value = grd.Rows[e.RowIndex].Cells["SOYO_AMT"].Value;
                    }
                    else
                    {
                        grd.Rows[e.RowIndex].Cells["SOYO_AMT"].Value = grd.Rows[e.RowIndex].Cells["OLD_SOYO_AMT"].Value;
                    }
                }
                else
                {
                    grd.Rows[e.RowIndex].Cells["SOYO_AMT"].Value = grd.Rows[e.RowIndex].Cells["OLD_SOYO_AMT"].Value;
                }
            }
        }

        private void btn_plus_Click(object sender, EventArgs e)
        {
            if (btnRawOut.Enabled == true)
            {
                workGridAdd();
            }
        }

        private void btn_minus_Click(object sender, EventArgs e)
        {
            if (btnRawOut.Enabled == true)
            {
                minus_logic(workRmGrid);
            }
        }

        private void minus_logic(conDataGridView dgv)
        {
            if (workRmGrid.Rows.Count > 1)
            {
                if ((string)dgv.SelectedRows[0].Cells["SEQ"].Value != "" && dgv.SelectedRows[0].Cells["SEQ"].Value != null)
                {

                    del_workGrid.Rows.Add();

                    del_workGrid.Rows[del_workGrid.Rows.Count - 1].Cells["WORK_INST_DATE"].Value = txt_work_date.Text.ToString();
                    del_workGrid.Rows[del_workGrid.Rows.Count - 1].Cells["WORK_INST_CD"].Value = txt_work_cd.Text.ToString();
                    del_workGrid.Rows[del_workGrid.Rows.Count - 1].Cells["SEQ"].Value = dgv.SelectedRows[0].Cells["SEQ"].Value;
                }

                dgv.Rows.RemoveAt(dgv.SelectedRows[0].Index);
                dgv.CurrentCell = dgv[5, dgv.Rows.Count - 1];
            }
        }
        private void workGridAdd()
        {
            workRmGrid.Rows.Add();
            //workRmGrid.Rows[workRmGrid.Rows.Count - 1].Cells["TOTAL_AMT"].Value = "0";
            //workRmGrid.Rows[workRmGrid.Rows.Count - 1].Cells["PRICE"].Value = "0";
            //workRmGrid.Rows[workRmGrid.Rows.Count - 1].Cells["TOTAL_MONEY"].Value = "0";
        }

        private void frm작업지시서등록_Enter(object sender, EventArgs e)
        {
            plan_logic();
        }

        private void txt_inst_notice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                workRmGrid.Focus();
            }

            else
            {
                return;
            }
        }

        private void btn공정완료_Click(object sender, EventArgs e)
        {
            chk_flow_yn.Checked = true;
            //txt_work_date.Text.ToString(),
            //            txt_work_cd.Text.ToString(),
            //            lot_no,
            //            txt_item_cd.Text.ToString(),
            //            txt_cust_cd.Text.ToString(),
            //            txt_inst_amt.Text.ToString(),
            //            delivery_req_date.Text.ToString(),
            //            cmb_line.SelectedValue.ToString(),
            //            cmb_worker.SelectedValue.ToString(),
            //            txt_plan_num.Text.ToString(),
            //            txt_plan_item.Text.ToString(),
            //            txt_inst_notice.Text.ToString(),
            //            txt_char_amt.Text.ToString(),
            //            txt_pack_amt.Text.ToString(),

            DialogResult msgOk = MessageBox.Show("공정완료를 확정 하시겠습니까?", "경고여부", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (msgOk == DialogResult.No)
            {
                return;
            }
            //update_Work_Flow2

            int rsNum = wnDm.update_Work_Flow2(txt_lot_no.Text);

            if (rsNum == 0)
            {


                MessageBox.Show("성공적으로 등록하였습니다.");
            }
            else if (rsNum == 1)
                MessageBox.Show("저장에 실패하였습니다");
            else if (rsNum == 2)
                MessageBox.Show("SQL COMMAND 에러");
            else
                MessageBox.Show("Exception 에러1");
        }

        private void btn반환_Click(object sender, EventArgs e)
        {


            if (txtLOSS율.Text == "")
            {
                txtLOSS율.Text = "0";
            }

            if (MessageBox.Show(txtLOSS율.Text + "% 만큼 수량이 더해집니다.", "수량계산", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                double LOSS율 = double.Parse(txtLOSS율.Text.ToString()) / 100;
                for (int i = 0; i < workRmGrid.Rows.Count; i++)
                {
                    //변환버튼 클릭시 총소요량 변화
                    workRmGrid.Rows[i].Cells["TOTAL_SOYO_AMT"].Value = (double.Parse(workRmGrid.Rows[i].Cells["TOTAL_SOYO_AMT"].Value.ToString()) + double.Parse(workRmGrid.Rows[i].Cells["TOTAL_SOYO_AMT"].Value.ToString()) * LOSS율).ToString("#,0.######");

                    //변환버튼 클릭시 예상재고변화(환산단위 적용)
                    workRmGrid.Rows[i].Cells["EX_STOCK"].Value = (double.Parse(workRmGrid.Rows[i].Cells["BAL_STOCK"].Value.ToString()) - double.Parse(workRmGrid.Rows[i].Cells["TOTAL_SOYO_AMT"].Value.ToString()) * double.Parse(workRmGrid.Rows[i].Cells["CVR_RATIO"].Value.ToString())).ToString();
                }

                //   txt_inst_amt.Text = (double.Parse(txt_inst_amt.Text.ToString()) + double.Parse(txt_inst_amt.Text.ToString()) * LOSS율).ToString();

                txtLOSS율.Text = "0";
                errorcnt++;

                btn반환.Enabled = false;


            }
            else
            {

            }


        }

        private void chk_raw_CheckedChanged(object sender, EventArgs e)
        {
            //chk_raw.Enabled = false;
        }

        private void btn_cadAdd_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
        }





        private void workInstReset()
        {
            wnDm wDm = new wnDm();
            DataTable dt = null;

            dt = wDm.fn_Work_Detail_List("where A.W_INST_DATE = '" + txt_work_date.Text.ToString() +"' ");

            if (dt != null && dt.Rows.Count > 0)
            {
                txt_work_date.Text = dt.Rows[0]["W_INST_DATE"].ToString();
                txt_work_cd.Text = dt.Rows[0]["W_INST_CD"].ToString();
                txt_lot_no.Text = dt.Rows[0]["LOT_NO"].ToString();

            }
          
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btn제품등록_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("제품등록 페이지로 이동하시겠습니까?", "제품등록BOM 이동", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {


                frmMain pForm = (frmMain)this.MdiParent;
                //P85_BAS.frm제품등록///제품등록
                pForm.sub_Form("P85_BAS.frm제품등록", "제품등록");
            }
            else
            {
            }
        }

        private void chk_raw_Click(object sender, EventArgs e)
        {
            if (chk_raw.Checked == true)
            {
                btnRawOut.Focus();
            }
            else
            {
                this.Focus();
            }
        }








        //private void btn_file_Click(object sender, EventArgs e)
        //{
        //    string f_fullName;
        //    // f_fullName = OpenFile();

        //    string sourceFile = @"C:\Users\Public\public\test.txt";
        //    string destinationFile = "ftp://119.196.70.80:8097/MES";


        //    string user = "anonymous";
        //    string pwd = "";
        //    string str = DateTime.Today.AddMonths(-1).ToString("yyyy-MM-dd");
        //    MessageBox.Show(str);
        //    // WebRequest.Create로 Http,Ftp,File Request 객체를 모두 생성할 수 있다.

        //    FtpWebRequest req = (FtpWebRequest)WebRequest.Create(destinationFile + str + "/" + fName);
        //    //FtpWebRequest req = (FtpWebRequest)WebRequest.Create(destinationFile + str + fName);
        //    // FTP 업로드한다는 것을 표시
        //    req.Method = WebRequestMethods.Ftp.UploadFile;

        //    // 쓰기 권한이 있는 FTP 사용자 로그인 지정

        //    req.Credentials = new NetworkCredential(user, pwd);



        //    // FTP 업로드
        //    //using (var client = new WebClient())
        //    //{
        //    //    client.Credentials = new NetworkCredential("anonymous", "");
        //    //    client.UploadFile(destinationFile, f_fullName);
        //    //    MessageBox.Show("성공");
        //    //}


        //    //폴더 생성준비
        //    FtpWebRequest requestFTPUploader = (FtpWebRequest)WebRequest.Create(destinationFile + str + "/");
        //    MessageBox.Show(destinationFile + str + "/");
        //    requestFTPUploader.Credentials = new NetworkCredential(user, pwd);

        //    var request = requestFTPUploader;

        //    request.Method = WebRequestMethods.Ftp.MakeDirectory;

        //    try
        //    {

        //        // 폴더생성 
        //        using (var resp = (FtpWebResponse)request.GetResponse())
        //        {
        //            // 입력파일을 바이트 배열로 읽음
        //            byte[] data;
        //            if (!f_fullName.Equals(""))
        //            {
        //                using (StreamReader reader = new StreamReader(f_fullName))
        //                {
        //                    data = Encoding.UTF8.GetBytes(reader.ReadToEnd());
        //                }

        //                // RequestStream에 데이타를 쓴다
        //                req.ContentLength = data.Length;
        //                using (Stream reqStream = req.GetRequestStream())
        //                {
        //                    reqStream.Write(data, 0, data.Length);
        //                }

        //                // FTP Upload 실행
        //                using (FtpWebResponse resp1 = (FtpWebResponse)req.GetResponse())
        //                {
        //                    // FTP 결과 상태 출력
        //                    Console.WriteLine("Upload: {0}", resp1.StatusDescription);
        //                    MessageBox.Show("성공");
        //                }

        //                resp.Close();
        //            }


        //        }
        //    }
        //    catch (WebException ex)
        //    {
        //        //폴더 생성 X
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
        //}

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

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txt_inst_amt_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void delivery_req_date_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTimePicker dtpTemp = (DateTimePicker)sender;
                DateTime dtTemp = dtpTemp.Value;

                if (dtTemp.Date < txt_work_date.Value.Date)
                {
                    MessageBox.Show("납품요구일은 지시일자보다 크거나 같아야합니다.");
                    dtpTemp.Text = txt_work_date.Text;
                }
            }
            catch
            {

            }
        }
    }
}
