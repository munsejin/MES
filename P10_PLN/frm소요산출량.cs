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
using System.Diagnostics;
using MES.Controls;

namespace MES.P10_PLN
{
    public partial class frm소요산출량 : Form
    {
        private wnGConstant wConst = new wnGConstant();
        private int cust_max_num = 0;
        private DataGridView chk_planGrid = new DataGridView();
        wnDm wnDm = new wnDm();
        string order_date_2 = ""; //입고요청일 
        private string saveStr = "";

        private bool firstTouch = false;

      
        private bool[] right = new bool[2];

        /*
        public static bool p_IsAuth = true;    // 열람권한
        public static bool p_Isrgstr = true;    //등록/수정 권한
        public static bool p_Isdel = true;    // 삭제 권한
        */

        public frm소요산출량()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void frm소요산출량_Load(object sender, EventArgs e)
        {

            lbl_title.Tag = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[0] + "$" + wnDm.fn_TitleName(this.Name.ToString()).Split('$')[1]; lbl_title.Text = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[2];
            right = wConst.btnRight(lbl_title.Tag.ToString());

            start_date.Text = DateTime.Today.AddMonths(-1).ToString("yyyy-MM-dd");
            dtp입고요청일.Value = DateTime.Now;
            /*
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
            */

            if (Common.p_saupNo == "1278113487")
            {
                dtp입고요청일.Value = dtp입고요청일.Value.AddDays(14);//화인- 입고요청일 + 2주  

            }
            planGrid.Columns["CHK"].ReadOnly = false;

            grdCellSetting();


            // plan_list(planGrid, "where A.PLAN_DATE >= '" + start_date.Text.ToString() + "' and  A.PLAN_DATE <= '" + end_date.Text.ToString() + "' and ORDER_YN = 'N'");

        }

        #region button logic

        private void btnSave_Click(object sender, EventArgs e)
        {
            order_date_2 = dtp입고요청일.Value.ToString("yyyy-MM-dd");

            if (right[0])
            {
                try
                {
                    if (rs_order_grid.Rows.Count > 0)
                    {
                        int chk = 0;
                        //체크박스 재 정의 
                        for (int i = 0; i < rs_order_grid.Rows.Count; i++)
                        {
                            if ((bool)rs_order_grid.Rows[i].Cells[0].Value == true)
                            {
                                chk++;
                            }
                        }

                        

                        //if (chk < rs_order_grid.Rows.Count)
                        //{
                        //    //재 정의
                        //    for (int i = 0; i < rs_order_grid.Rows.Count; i++)
                        //    {
                        //        if ((bool)rs_order_grid.Rows[i].Cells[0].Value == true)
                        //        {
                        //            if (i == 0)
                        //            {
                        //                cust_max_num = int.Parse(rs_order_grid.Rows[i].Cells["CUST_NUM"].Value.ToString());
                        //            }
                        //            else
                        //            {
                        //                if (cust_max_num < int.Parse(rs_order_grid.Rows[i].Cells["CUST_NUM"].Value.ToString()))
                        //                {
                        //                    cust_max_num = int.Parse(rs_order_grid.Rows[i].Cells["CUST_NUM"].Value.ToString());
                        //                }
                        //            }
                        //        }
                        //    }
                        //}
                        int cnt = 0;
                        StringBuilder w_sb = new StringBuilder();

                        

                        if (chk == 0)
                        {
                            MessageBox.Show("최소 하나의 발주여부를 선택해야 합니다.");
                            return;
                        }

                        if (cnt > 0)
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.AppendLine("발주량이 0인 부분은 저장이 불가능합니다.");
                            sb.AppendLine(w_sb.ToString());

                            MessageBox.Show(sb.ToString());
                            return;
                        }


                        for (int i = 0; i < rs_order_grid.Rows.Count; i++)
                        {
                            if (rs_order_grid.Rows[i].Cells["col_chk"].Value != null && (bool)rs_order_grid.Rows[i].Cells["col_chk"].Value == true)
                            {
                                if (rs_order_grid.Rows[i].Cells["PUR_CUST_CD"].Value == null || rs_order_grid.Rows[i].Cells["PUR_CUST_CD"].Value.ToString().Equals(""))
                                {
                                    DialogResult msgOk = MessageBox.Show(" 일부 구매처가 선택되지 않았습니다.\n 누락된 구매처를 일괄 입력하시겠습니까? ", "발주처 일괄등록 여부", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                                    if (msgOk == System.Windows.Forms.DialogResult.OK || msgOk == System.Windows.Forms.DialogResult.Yes)
                                    {
                                        Popup.pop거래처검색 msg = new Popup.pop거래처검색("발주처를 선택하여주십시오");
                                        msg.sCustGbn = "2";
                                        msg.ShowDialog();

                                        if (msg.sCode == null || msg.sCode.Equals(""))
                                        {
                                            MessageBox.Show("일부 자재의 발주처가 설정되지 않았습니다.");
                                            return;
                                        }
                                        else
                                        {
                                            SetCustCd(msg.sCode, msg.sName);
                                            continue;
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("일부 자재의 발주처가 설정되지 않았습니다.");
                                        return;
                                    }
                                }
                                else if (rs_order_grid.Rows[i].Cells["PUR_CUST_NM"].Value == null || rs_order_grid.Rows[i].Cells["PUR_CUST_NM"].Value.ToString().Equals(""))
                                {
                                    MessageBox.Show("1개 이상의 항목이 구매처가 설정되지 않았습니다.");
                                    return;
                                }
                                else if (rs_order_grid.Rows[i].Cells["RS_AMT"].Value == null || rs_order_grid.Rows[i].Cells["RS_AMT"].Value.ToString().Equals("0"))
                                {
                                    MessageBox.Show("발주량이 0인 부분은 저장이 불가능합니다.");
                                    return;
                                }
                                try
                                {
                                    if (decimal.Parse(rs_order_grid.Rows[i].Cells["RS_AMT"].Value.ToString()) < 0)
                                    {
                                        MessageBox.Show("음수 발주는 불가능합니다.");
                                        return;
                                    }
                                }
                                catch (Exception ex2)
                                {
                                    MessageBox.Show("발주수량 입력 양식이 잘못되었습니다.");
                                    return;
                                }
                            }
                        }


                        if (cust_max_num > 1)
                        {
                            StringBuilder sb = new StringBuilder();

                            sb.AppendLine(chk + "개의 원자재를 선택하셨습니다.");
                            sb.AppendLine("원자재는 각 거래처별로 발주됩니다.");
                            sb.AppendLine("입고요청일은 [" + order_date_2 + "]로 반영됩니다. ");

                            //sb.AppendLine(cust_max_num + "개의 거래처가 있어 발주서가 나눠서 저장됩니다.");
                            sb.AppendLine(" 저장하시겠습니까?");
                            DialogResult msgOk = MessageBox.Show(sb.ToString(), "[발주확인]", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                            if (msgOk == DialogResult.No)
                            {
                                return;
                            }
                        }

                        wnDm wDm = new wnDm();
                        int rsNum = wDm.insertSoyo(
                             rs_order_grid
                            , chk_planGrid

                            , order_date_2);

                        if (rsNum == 0)
                        {
                            plan_list(planGrid, "where PN.PLAN_DATE >= '" + start_date.Text.ToString() + "' and  PN.PLAN_DATE <= '" + end_date.Text.ToString() + "' ");
                            chk_planGrid.Rows.Clear();
                            rs_order_grid.Rows.Clear();
                            itemPlanGrid.Rows.Clear();
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

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("시스템 오류: " + ex.ToString());
                    Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                    msg.ShowDialog();
                }
            }
            else
            {

                MessageBox.Show("권한이없습니다.");
            }
        }

        private void SetCustCd(string cust_cd, string cust_nm)
        {
            for (int i = 0; i < rs_order_grid.Rows.Count; i++)
            {
                if (rs_order_grid.Rows[i].Cells["col_chk"].Value != null && (bool)rs_order_grid.Rows[i].Cells["col_chk"].Value == true)
                {
                    if (rs_order_grid.Rows[i].Cells["PUR_CUST_CD"].Value == null || rs_order_grid.Rows[i].Cells["PUR_CUST_CD"].Value.ToString().Equals(""))
                    {
                        rs_order_grid.Rows[i].Cells["PUR_CUST_CD"].Value = cust_cd;
                        rs_order_grid.Rows[i].Cells["PUR_CUST_NM"].Value = cust_nm;
                    }
                }
            }
        }
        int ischeck = 0;
        private void btn_rs_srch_Click(object sender, EventArgs e)
        {
            planDetail2();
            int ischeck = 0;
        }
        #endregion button logic

        private void btnSrch_Click(object sender, EventArgs e)
        {
            Refresh();
            if (rs_order_grid.Rows.Count > 0)
            {
                DialogResult msgOk = MessageBox.Show("재검색시 기존 데이터 조회는 없어집니다. \n 계속 검색을 진행하시겠습니까?", "확인여부", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msgOk == DialogResult.No)
                {
                    return;
                }
            }

            plan_list(planGrid, "and PN.PLAN_DATE >= '" + start_date.Text.ToString() + "' and  PN.PLAN_DATE <= '" + end_date.Text.ToString() + "' ");
        }

        private void plan_list(DataGridView dgv, string condition)
        {
            try
            {
                firstTouch = true;
                wnDm wDm = new wnDm();
                DataTable dt = null;
                dt = wDm.fn_Plan_List_cal_soyo(condition);

                rs_order_grid.Rows.Clear();
                itemPlanGrid.Rows.Clear();

                lbl_plan_cnt.Text = dt.Rows.Count.ToString();

                if (dt != null && dt.Rows.Count > 0)
                {
                    int count = 1;

                    dgv.RowCount = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgv.Rows[i].Cells[0].Value = count.ToString();
                        dgv.Rows[i].Cells["PLAN_DATE"].Value = dt.Rows[i]["PLAN_DATE"].ToString();
                        dgv.Rows[i].Cells["PLAN_CD"].Value = dt.Rows[i]["PLAN_CD"].ToString();
                        dgv.Rows[i].Cells["CUST_CD"].Value = dt.Rows[i]["CUST_CD"].ToString();
                        dgv.Rows[i].Cells["CUST_NM"].Value = dt.Rows[i]["CUST_NM"].ToString();
                        dgv.Rows[i].Cells["ITEM_CNT"].Value = dt.Rows[i]["ITEM_CNT2"].ToString();
                        dgv.Rows[i].Cells["P_ITEM_CD"].Value = dt.Rows[i]["ITEM_CNT"].ToString();
                        dgv.Rows[i].Cells["CHK"].Value = false;
                        if (!dt.Rows[i]["SEQ"].ToString().Equals("1"))
                        {
                            dgv.Rows[i].Visible = false;
                        }
                        else
                        {
                            dgv.Rows[i].Visible = true;
                            count++;
                        }
                    }
                }
                else
                {
                    planGrid.Rows.Clear();

                }
            }
            catch (Exception e)
            {
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(e.Message+" - "+e.ToString()); msg.ShowDialog();
            }
            firstTouch = false;
        }

        private void planDetail2()
        {
            cust_max_num = 0;
            wnDm wDm = new wnDm();
            DataTable dt = null;

            if (planGrid.Rows.Count > 0)   //row 없이 버튼 누를때 체크 확인
            {
                bool chk = false;
                for (int i = 0; i < planGrid.Rows.Count; i++) //chk 검사
                {
                    if ((bool)planGrid.Rows[i].Cells["CHK"].Value == true)
                    {
                        chk = true;
                        break;
                    }
                }
                chk_planGrid.Rows.Clear();
                if (chk)
                {
                    bool chk2 = false;
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine(" where 1=1 ");
                    for (int i = 0; i < planGrid.Rows.Count; i++)
                    {
                        if ((bool)planGrid.Rows[i].Cells["CHK"].Value == true)
                        {
                            chk_planGrid.Rows.Add();
                            chk_planGrid.Rows[chk_planGrid.Rows.Count - 1].Cells["PLAN_DATE"].Value = planGrid.Rows[i].Cells["PLAN_DATE"].Value;
                            chk_planGrid.Rows[chk_planGrid.Rows.Count - 1].Cells["PLAN_CD"].Value = planGrid.Rows[i].Cells["PLAN_CD"].Value;
                            chk_planGrid.Rows[chk_planGrid.Rows.Count - 1].Cells["CHK"].Value = planGrid.Rows[i].Cells["CHK"].Value;

                            if (chk2 == false) //처음 체크일 경우
                            {
                                sb.AppendLine(" and (A.PLAN_DATE = '" + planGrid.Rows[i].Cells["PLAN_DATE"].Value + "' and A.PLAN_CD = '" + planGrid.Rows[i].Cells["PLAN_CD"].Value + "' and B.ITEM_CD = '"+planGrid.Rows[i].Cells["P_ITEM_CD"].Value+"'  )");
                            }
                            else
                            {
                                sb.AppendLine(" or (A.PLAN_DATE = '" + planGrid.Rows[i].Cells["PLAN_DATE"].Value + "' and A.PLAN_CD = '" + planGrid.Rows[i].Cells["PLAN_CD"].Value + "'  and B.ITEM_CD = '" + planGrid.Rows[i].Cells["P_ITEM_CD"].Value + "' )");
                            }
                            chk2 = true;
                        }
                    }
                    dt = wDm.fn_Plan_Detail_List(sb.ToString());

                    itemPlanGrid.Rows.Clear();
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            itemPlanGrid.Rows.Add();
                            itemPlanGrid.Rows[i].Cells[0].Value = (i + 1).ToString();
                            itemPlanGrid.Rows[i].Cells["P_PLAN_DATE"].Value = dt.Rows[i]["PLAN_DATE"].ToString();
                            itemPlanGrid.Rows[i].Cells["P_PLAN_CD"].Value = dt.Rows[i]["PLAN_CD"].ToString();
                            itemPlanGrid.Rows[i].Cells["P_SEQ"].Value = dt.Rows[i]["SEQ"].ToString();
                            itemPlanGrid.Rows[i].Cells["ITEM_CD"].Value = dt.Rows[i]["ITEM_CD"].ToString();
                            itemPlanGrid.Rows[i].Cells["ITEM_NM"].Value = dt.Rows[i]["ITEM_NM"].ToString();
                            itemPlanGrid.Rows[i].Cells["P_UNIT_CD"].Value = dt.Rows[i]["UNIT_CD"].ToString();
                            itemPlanGrid.Rows[i].Cells["P_UNIT_NM"].Value = dt.Rows[i]["UNIT_NM"].ToString();
                            itemPlanGrid.Rows[i].Cells["P_TOTAL_AMT"].Value = (decimal.Parse(dt.Rows[i]["TOTAL_AMT"].ToString())).ToString("#,0.######");
                            itemPlanGrid.Rows[i].Cells["P_PRICE"].Value = (decimal.Parse(dt.Rows[i]["PRICE"].ToString())).ToString("#,0.######");
                            itemPlanGrid.Rows[i].Cells["P_TOTAL_MONEY"].Value = (decimal.Parse(dt.Rows[i]["TOTAL_MONEY"].ToString())).ToString("#,0.######");
                        }
                    }

                    soyoLogic(sb); //소요산출량
                }
                else
                {
                    itemPlanGrid.Rows.Clear();
                    rs_order_grid.Rows.Clear();
                }
                //MessageBox.Show(cust_max_num.ToString());
            }
            else
            {
                itemPlanGrid.Rows.Clear();
            }
        }

        private void grdCellSetting()
        {
            chk_planGrid.AllowUserToAddRows = false;

            chk_planGrid.Columns.Add("PLAN_DATE", "PLAN_DATE");
            chk_planGrid.Columns.Add("PLAN_CD", "PLAN_CD");
            chk_planGrid.Columns.Add("CHK", "CHK");

            for (int i = 0; i < planGrid.ColumnCount; i++)
            {
                planGrid.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            for (int i = 0; i < rs_order_grid.ColumnCount; i++)
            {
                rs_order_grid.Columns[i].ReadOnly = true;
                //rs_order_grid.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            rs_order_grid.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            rs_order_grid.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            rs_order_grid.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            rs_order_grid.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            rs_order_grid.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            rs_order_grid.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            rs_order_grid.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            rs_order_grid.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


            rs_order_grid.Columns[0].ReadOnly = false; //맨 앞 체크박스
            rs_order_grid.Columns["RS_AMT"].ReadOnly = false;
        }

        private void resetSetting()
        {
            cust_max_num = 0;
            rs_order_grid.Rows.Clear();
            itemPlanGrid.Rows.Clear();

            plan_list(planGrid, "where PN.PLAN_DATE >= '" + start_date.Text.ToString() + "' and  PN.PLAN_DATE <= '" + end_date.Text.ToString() + "' ");
        }

        private void soyoLogic(StringBuilder sb)
        {
            wnDm wDm = new wnDm();
            DataTable dt = new DataTable();
            dt = wDm.fn_Soyo_Result_List(sb.ToString());

            rs_order_grid.Rows.Clear();
            saveStr = sb.ToString(); //저장 (체크박스 해제 사용하기 위한 용도)

            lbl_order_cnt.Text = dt.Rows.Count.ToString();
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    decimal total_amt = decimal.Parse(dt.Rows[i]["TOTAL_AMT"].ToString());
                    decimal bStock = decimal.Parse(dt.Rows[i]["BAL_STOCK"].ToString());
                    decimal realAmt = decimal.Parse(dt.Rows[i]["REAL_AMT"].ToString());

                    decimal rs = (total_amt - realAmt);
                    if (rs < 0)
                    {
                        rs = 0;
                    }

                    rs_order_grid.Rows.Add();
                    rs_order_grid.Rows[i].Cells[0].Value = false;
                    rs_order_grid.Rows[i].Cells[1].Value = (i + 1).ToString();
                    rs_order_grid.Rows[i].Cells["RAW_MAT_CD"].Value = dt.Rows[i]["RAW_MAT_CD"].ToString();
                    rs_order_grid.Rows[i].Cells["RAW_MAT_NM"].Value = dt.Rows[i]["RAW_MAT_NM"].ToString();
                    rs_order_grid.Rows[i].Cells["SPEC"].Value = dt.Rows[i]["SPEC"].ToString();
                    rs_order_grid.Rows[i].Cells["TOTAL_AMT"].Value = (decimal.Parse(dt.Rows[i]["TOTAL_AMT"].ToString())).ToString("#,0.######");
                    //환산단위 적용코드
                    //rs_order_grid.Rows[i].Cells["TOTAL_AMT"].Value = int.Parse((decimal.Parse(dt.Rows[i]["TOTAL_AMT"].ToString())).ToString("#,0.######")) / int.Parse(dt.Rows[i]["CVR_RATIO"].ToString());                    
                    rs_order_grid.Rows[i].Cells["BAL_STOCK"].Value = (decimal.Parse(dt.Rows[i]["BAL_STOCK"].ToString())).ToString("#,0.######");
                    //환산단위 적용코드
                    //rs_order_grid.Rows[i].Cells["BAL_STOCK"].Value = int.Parse((decimal.Parse(dt.Rows[i]["BAL_STOCK"].ToString())).ToString("#,0.######")) / int.Parse(dt.Rows[i]["CVR_RATIO"].ToString());
                    // rs_order_grid.Rows[i].Cells["RS_AMT"].Value = rs.ToString("#,0.######"); //(decimal.Parse(dt.Rows[i]["RS_AMT"].ToString())).ToString("#,0.######");
                    // rs_order_grid.Rows[i].Cells["RS_AMT"].Value = (Math.Ceiling(decimal.Parse(rs.ToString("#,0.######")))).ToString(); //(decimal.Parse(dt.Rows[i]["RS_AMT"].ToString())).ToString("#,0.######");                    
                    // rs_order_grid.Rows[i].Cells["RS_AMT"].Value = (decimal.Parse(dt.Rows[i]["RS_AMT"].ToString())).ToString("#,0.######");
                    //decimal amt = (decimal.Parse(dt.Rows[i]["TOTAL_AMT"].ToString()) - (decimal.Parse(dt.Rows[i]["REAL_AMT"].ToString())));
                    rs_order_grid.Rows[i].Cells["RS_AMT"].Value = decimal.Parse(dt.Rows[i]["RS_AMT"].ToString()).ToString("#,0.######");
                    //환산단위 적용코드
                    //rs_order_grid.Rows[i].Cells["RS_AMT"].Value = amt > 0 ? (int.Parse((decimal.Parse(dt.Rows[i]["TOTAL_AMT"].ToString())).ToString("#,0.######")) / int.Parse(dt.Rows[i]["CVR_RATIO"].ToString())).ToString() : "0";
                    rs_order_grid.Rows[i].Cells["PRICE"].Value = (decimal.Parse(dt.Rows[i]["INPUT_PRICE"].ToString())).ToString("#,0.######");
                    rs_order_grid.Rows[i].Cells["TOTAL_MONEY"].Value = (decimal.Parse(dt.Rows[i]["TOTAL_MONEY"].ToString())).ToString("#,0.######");
                    rs_order_grid.Rows[i].Cells["UNIT_CD"].Value = dt.Rows[i]["INPUT_UNIT"].ToString();
                    rs_order_grid.Rows[i].Cells["입고단위"].Value = dt.Rows[i]["입고단위"].ToString();
                    rs_order_grid.Rows[i].Cells["출고단위"].Value = dt.Rows[i]["사용단위"].ToString();
                    rs_order_grid.Rows[i].Cells["PUR_CUST_CD"].Value = dt.Rows[i]["CUST_CD"].ToString();
                    rs_order_grid.Rows[i].Cells["PUR_CUST_NM"].Value = dt.Rows[i]["CUST_NM"].ToString();
                    rs_order_grid.Rows[i].Cells["CUST_NUM"].Value = dt.Rows[i]["CUST_NUM"].ToString(); // 총 row에서 거래처가 N개일 경우 번호를 1~N번까지 매김 
                    //rs_order_grid.Rows[i].Cells["CUST_GUBUN"].Value = dt.Rows[i]["CUST_GUBUN"].ToString();
                    //rs_order_grid.Rows[i].Cells["CUST_GUBUN_NM"].Value = dt.Rows[i]["CUST_GUBUN_NM"].ToString();
                    rs_order_grid.Rows[i].Cells["CVR_RATIO"].Value = dt.Rows[i]["CVR_RATIO"].ToString();

                    rs_order_grid.Rows[i].Cells["REAL_AMT"].Value = (decimal.Parse(dt.Rows[i]["REAL_AMT"].ToString())).ToString("#,0.######");

                    string rs_amt = ((string)rs_order_grid.Rows[i].Cells["RS_AMT"].Value).Replace(",", "");
                    double d_rs_amt = double.Parse(rs_amt);

                    if (d_rs_amt > 0)
                    {
                        rs_order_grid.Rows[i].DefaultCellStyle.BackColor = Color.White;
                    }
                    else
                    {
                        DataGridViewCellStyle st = new DataGridViewCellStyle();
                        st.BackColor = Color.IndianRed;
                        st.SelectionBackColor = Color.Red;
                        st.ForeColor = Color.White;
                        st.SelectionForeColor = Color.White;
                        rs_order_grid.Rows[i].Cells["RS_AMT"].Value = 0;
                        rs_order_grid.Rows[i].Cells["RS_AMT"].Style = st;
                    }

                    if (i == 0)
                    {
                        cust_max_num = int.Parse(dt.Rows[i]["CUST_NUM"].ToString());
                    }
                    else
                    {
                        if (cust_max_num < int.Parse(dt.Rows[i]["CUST_NUM"].ToString()))
                        {
                            cust_max_num = int.Parse(dt.Rows[i]["CUST_NUM"].ToString());
                        }
                    }
                }
            }
        }

        private void rs_order_grid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ischeck++;

            if (rs_order_grid.Columns[e.ColumnIndex].Name == "col_chk")
            {
                if (ischeck % 2 == 1)
                {
                    if (e.ColumnIndex == 0)
                    {
                        if (rs_order_grid.Rows.Count > 0)
                        {

                            foreach (DataGridViewRow rows in rs_order_grid.Rows)
                            {


                                rows.Cells["col_chk"].Value = true;


                            }

                            btnSave.Focus();

                        }

                    }
                }
                else
                {
                    if (e.ColumnIndex == 0)
                    {
                        if (rs_order_grid.Rows.Count > 0)
                        {

                            foreach (DataGridViewRow rows in rs_order_grid.Rows)
                            {


                                rows.Cells["col_chk"].Value = false;


                            }

                            btnSave.Focus();

                        }

                    }

                }
            }

        }
        int ischeck2 = 0;
        private void planGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ischeck2++;

            if (planGrid.Columns[e.ColumnIndex].Name == "CHK")
            {
                if (ischeck2 % 2 == 1)
                {
                    if (e.RowIndex == -1)
                    {
                        if (planGrid.Rows.Count > 0)
                        {

                            foreach (DataGridViewRow rows in planGrid.Rows)
                            {


                                rows.Cells["CHK"].Value = true;


                            }

                            btnSave.Focus();

                        }

                    }
                }
                else
                {
                    if (e.RowIndex == -1)
                    {
                        if (planGrid.Rows.Count > 0)
                        {

                            foreach (DataGridViewRow rows in planGrid.Rows)
                            {


                                rows.Cells["CHK"].Value = false;


                            }

                            btnSave.Focus();

                        }

                    }

                }
            }

        }

        private void rs_order_grid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView grd = (DataGridView)sender;
            if (grd.Columns[e.ColumnIndex].ToolTipText.IndexOf("발주량") >= 0)
            {
                string rs_amt = (string)grd.Rows[e.RowIndex].Cells["RS_AMT"].Value;

                if (rs_amt != null)
                {
                    rs_amt = rs_amt.ToString().Replace(" ", "");
                    if (rs_amt == "")
                    {
                        grd.Rows[e.RowIndex].Cells["RS_AMT"].Value = "0";
                    }
                }
                else
                {
                    grd.Rows[e.RowIndex].Cells["RS_AMT"].Value = "0";
                }
            }

            wConst.f_Calc_Price(grd, e.RowIndex, "RS_AMT", "PRICE");
        }

        private void frm소요산출량_Enter(object sender, EventArgs e)
        {
            btnSrch.PerformClick();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < rs_order_grid.Rows.Count; i++)
            {
                rs_order_grid.Rows[i].Cells["TOTAL_AMT"].Value = int.Parse(rs_order_grid.Rows[i].Cells["TOTAL_AMT"].Value.ToString()) / int.Parse(rs_order_grid.Rows[i].Cells["CVR_RATIO"].ToString());
                rs_order_grid.Rows[i].Cells["BAL_STOCK"].Value = int.Parse(rs_order_grid.Rows[i].Cells["BAL_STOCK"].Value.ToString()) / int.Parse(rs_order_grid.Rows[i].Cells["CVR_RATIO"].ToString());
                rs_order_grid.Rows[i].Cells["RS_AMT"].Value = int.Parse(rs_order_grid.Rows[i].Cells["RS_AMT"].Value.ToString()) / int.Parse(rs_order_grid.Rows[i].Cells["CVR_RATIO"].ToString());
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
                    plan_list(planGrid, "where PN.PLAN_DATE >= '" + start_date.Text.ToString() + "' and  PN.PLAN_DATE <= '" + end_date.Text.ToString() + "' ");

                    break;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
            return true;
        }

        private void rs_order_grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridView grd = (DataGridView)sender;
                DataGridViewCell cell = grd[e.ColumnIndex, e.RowIndex];
                var senderGrid = (DataGridView)sender;
                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                    e.RowIndex >= 0 && senderGrid.Columns[e.ColumnIndex].Name.Equals("검색"))
                {
                    Popup.pop거래처검색 frm = new Popup.pop거래처검색();

                    frm.sCustGbn = "2"; //구매처
                    frm.ShowDialog();

                    if (frm.sCode != "")
                    {
                        rs_order_grid.Rows[e.RowIndex].Cells["PUR_CUST_CD"].Value = frm.sCode.Trim();
                        rs_order_grid.Rows[e.RowIndex].Cells["PUR_CUST_NM"].Value = frm.sName.Trim();
                        SendKeys.Send("{Tab}");
                    }
                    frm.Dispose();
                    frm = null;
                }
            }
        }

        private void rs_order_grid_VisibleChanged(object sender, EventArgs e)
        {
            ComInfo.gridHeaderSet((DataGridView)sender);

        }

        private void planGrid_VisibleChanged(object sender, EventArgs e)
        {
            ComInfo.gridHeaderSet((DataGridView)sender);

        }

        private void itemPlanGrid_VisibleChanged(object sender, EventArgs e)
        {
            ComInfo.gridHeaderSet((DataGridView)sender);

        }

        private void planGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex == 5)
            {
                if (firstTouch) return;
                for (int i = 0; i < planGrid.Rows.Count; i++)
                {
                    if (planGrid.Rows[i].Cells["PLAN_DATE"].Value.ToString().Equals(planGrid.Rows[e.RowIndex].Cells["PLAN_DATE"].Value.ToString())
                        && planGrid.Rows[i].Cells["PLAN_CD"].Value.ToString().Equals(planGrid.Rows[e.RowIndex].Cells["PLAN_CD"].Value.ToString()))
                    {
                        planGrid.Rows[i].Cells["CHK"].Value = planGrid.Rows[e.RowIndex].Cells["CHK"].Value;
                    }
                } 
            }
        }
    }
}
