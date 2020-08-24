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
using MES.Controls;
using System.Diagnostics;
using System.Collections;

namespace MES.P10_PLN
{
    public partial class frm생산계획등록 : Form
    {
        private wnGConstant wConst = new wnGConstant();
        private DataGridView del_planGrid = new DataGridView();
        private DataGridView del_HalfGrid = new DataGridView();
        private ComInfo comInfo = new ComInfo();
        private string old_cust_nm = "";

        private DataGridView pHalfGrid = new DataGridView();
        string[] itemLST;
        string[] custLST;

        ArrayList Jumun_date_array = new ArrayList();
        ArrayList Jumun_cd_array = new ArrayList();



        private bool[] right = new bool[2];

        public frm생산계획등록()
        {
            InitializeComponent();

            this.itemPlanGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellEndEdit);
            this.itemPlanGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grid_KeyDown);
            this.itemPlanGrid.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grid_ColumnHeaderMouseClick);
            this.itemPlanGrid.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.grid_RowsAdded);
            this.itemPlanGrid.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.grid_RowsRemoved);
            this.itemPlanGrid.CellValueChanged += new DataGridViewCellEventHandler(grid_CellValueChanged);
            this.itemPlanGrid.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.grid_ColumnWidthChanged);
            this.itemPlanGrid.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.grid_EditingControlShowing);
            this.itemPlanGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellDoubleClick);
        }

        wnDm wnDm = new wnDm();


        Button[] Txtbtn = new Button[2];
        public void addButton(conTextBox TextBox, int type)
        {
            Txtbtn[type] = new Button();
            TextBox.Controls.Add(Txtbtn[type]);
            Txtbtn[type].FlatStyle = FlatStyle.Flat;
            Txtbtn[type].FlatAppearance.BorderSize = 0;
            Txtbtn[type].FlatAppearance.MouseDownBackColor = Color.Transparent;
            Txtbtn[type].SetBounds(TextBox.Size.Width - 19, 1, 18, TextBox.Size.Height - 2);
            Txtbtn[type].Text = "▼";
            Txtbtn[type].TabStop = false;
            Txtbtn[type].Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 4, FontStyle.Bold);

            switch (type)
            {
                case 0:
                    Txtbtn[type].Click += new EventHandler(btnCustSrch_Click);

                    break;
                case 1:
                    Txtbtn[type].Click += new EventHandler(btnCustSrch_Click);

                    break;

                default:
                    break;
            }
            Txtbtn[type].Show();
        }
        private void frm생산계획등록_Load(object sender, EventArgs e)
        {
            lbl_title.Tag = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[0] + "$" + wnDm.fn_TitleName(this.Name.ToString()).Split('$')[1]; lbl_title.Text = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[2];
            right = wConst.btnRight(lbl_title.Tag.ToString());

            //if (Common.p_strUserAdmin != "5")
            //{
            //    DataTable dtcheck = wnDm.fn_auth_check(lbl_title.Tag.ToString().Split('$')[0], lbl_title.Tag.ToString().Split('$')[1]);
            //    p_IsAuth = dtcheck.Rows[0]["auth_yn"].ToString() == "Y" ? true : false;
            //    p_Isrgstr = dtcheck.Rows[0]["rgstr_yn"].ToString() == "Y" ? true : false;
            //    p_Isdel = dtcheck.Rows[0]["del_yn"].ToString() == "Y" ? true : false;
            //    try
            //    {
            //        if (!p_IsAuth)
            //        {
            //            this.BeginInvoke(new MethodInvoker(Close));
            //            /// MessageBox.Show("권한이없습니다.");
            //        }

            //    }
            //    catch (Exception ex)
            //    {
            //    }


            //}
            Initialization();

            addButton(txt_cust_nm, 0);

            start_date.Text = DateTime.Today.AddMonths(-1).ToString("yyyy-MM-dd");

            itemPlanGridAdd();

            plan_list(planGrid, "where A.PLAN_DATE >= '" + start_date.Text.ToString() + "' and  A.PLAN_DATE <= '" + end_date.Text.ToString() + "'");

            del_planGrid.AllowUserToAddRows = false;

            del_planGrid.Columns.Add("PLAN_DATE", "PLAN_DATE");
            del_planGrid.Columns.Add("PLAN_CD", "PLAN_CD");
            del_planGrid.Columns.Add("SEQ", "SEQ");

            del_HalfGrid.AllowUserToAddRows = false;

            del_HalfGrid.Columns.Add("PLAN_DATE", "PLAN_DATE");
            del_HalfGrid.Columns.Add("PLAN_CD", "PLAN_CD");
            del_HalfGrid.Columns.Add("SEQ", "SEQ");

            pHalfGrid.AllowUserToAddRows = false;
            for (int i = 0; i < itemHalfGrid.Columns.Count; i++)
            {
                pHalfGrid.Columns.Add(itemHalfGrid.Columns[i].Name.ToString(), itemHalfGrid.Columns[i].Name.ToString());
            }
            pHalfGrid.Columns.Add("F_LEVEL", "F_LEVEL");
            pHalfGrid.Columns.Add("TOP_ITEM_CD", "TOP_ITEM_CD");
            DataTable dt1 = new DataTable();

            dt1 = wnDm.fn_ItemLst();
            itemLST = new string[dt1.Rows.Count];
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                itemLST[i] = dt1.Rows[i]["ITEM_NM"].ToString();
            }

            DataTable dt2 = new DataTable();
            dt2 = wnDm.fn_Cust_Name_List("where CUST_GUBUN = '1'");
            custLST = new string[dt2.Rows.Count];
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                custLST[i] = dt2.Rows[i]["CUST_NM"].ToString();
            }
            //var source = new AutoCompleteStringCollection();
            //source.AddRange(custLST);
            //txt_cust_nm.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //txt_cust_nm.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //txt_cust_nm.AutoCompleteCustomSource = source;
        }

        private void Initialization()
        {
            if (Common.p_saupNo == "1278113487")
            {
                pnl_LOSS율추가.Visible = true;
                btn반환.Visible = true;
                txtLOSS율.Visible = true;
                lblLOSS.Visible = true;
            }
        }

        #region btn click

        //private void dataGridView1_AllowUserToAddRowsChanged(object sender, EventArgs e)
        //{

        //}

        private void btnNew_Click(object sender, EventArgs e)
        {
            resetSetting();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            //true면 권한 O , false면 권한 X
            if (right[0])
            {
                plan_logic();
            }
            else
            {
                MessageBox.Show("권한이없습니다.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (right[1])
            {
                plan_del();
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

        private void btnCustSrch_Click(object sender, EventArgs e)
        {
            Refresh();
            Popup.pop거래처검색 frm = new Popup.pop거래처검색("매출처");

            frm.sCustGbn = "1"; //매출처
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
            req_date.Focus();
        }

        private void btnSrch_Click(object sender, EventArgs e)
        {
            plan_list(planGrid, "where A.PLAN_DATE >= '" + start_date.Text.ToString() + "' and  A.PLAN_DATE <= '" + end_date.Text.ToString() + "'");
        }
        #endregion btn click


        #region prod plan logic

        private void resetSetting()
        {
            lbl_plan_gbn.Text = "";
            btnDelete.Enabled = false;

            txt_jumun_date.Text = "";
            txt_jumun_cd.Text = "";
            txt_plan_date.Text = DateTime.Now.ToString("yyyy-MM-dd");
            txt_plan_date.Enabled = true;
            txt_plan_cd.Text = "";
            txt_cust_cd.Text = "";
            txt_cust_nm.Text = "";
            txt_comment.Text = "";
            old_cust_nm = "";
            chk_order_yn.Checked = false;
            req_date.Text = DateTime.Now.ToString("yyyy-MM-dd");
            txt_planNum.Text = "";
            btn_jumun_select.Enabled = true;

            itemPlanGrid.Rows.Clear();
            itemHalfGrid.Rows.Clear();
            pHalfGrid.Rows.Clear();

            itemPlanGridAdd();
            del_planGrid.Rows.Clear();
            del_HalfGrid.Rows.Clear();

            Jumun_date_array.Clear();
            Jumun_cd_array.Clear();

            btn반환.Enabled = true;

        }

        private void resetSetting_NotCustSetting()
        {
            lbl_plan_gbn.Text = "";
            btnDelete.Enabled = false;

            txt_jumun_date.Text = "";
            txt_jumun_cd.Text = "";
            txt_plan_date.Enabled = true;
            txt_plan_cd.Text = "";
            txt_comment.Text = "";
            old_cust_nm = "";
            chk_order_yn.Checked = false;
            txt_planNum.Text = "";

            itemPlanGrid.Rows.Clear();
            itemHalfGrid.Rows.Clear();
            pHalfGrid.Rows.Clear();

            itemPlanGridAdd();
            del_planGrid.Rows.Clear();
            del_HalfGrid.Rows.Clear();

            Jumun_date_array.Clear();
            Jumun_cd_array.Clear();

            btn반환.Enabled = true;
        }

        private void plan_logic()
        {
            try
            {
                if (txt_cust_cd.Text.ToString().Equals(""))
                {
                    MessageBox.Show("거래처를 선택하시기 바랍니다.");
                    return;
                }
                if (txt_plan_date.Value.ToOADate() >= req_date.Value.ToOADate())
                {
                    if (MessageBox.Show("납기일이 입력일과 같거나 이전입니다. 그대로 진행하시겠습니까?", "납풉요구일 안내", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        return;
                    }
                }


                if (itemPlanGrid.Rows.Count > 0)
                {
                    int cnt = 0;
                    int grid_cnt = itemPlanGrid.Rows.Count;
                    for (int i = 0; i < grid_cnt; i++)
                    {
                        string txt_item_cd = (string)itemPlanGrid.Rows[i - cnt].Cells["ITEM_CD"].Value;

                        if (txt_item_cd == "" || txt_item_cd == null)  //마지막 행에 원자재코드가 없을 경우 제거
                        {
                            itemPlanGrid.Rows.RemoveAt(i - cnt);
                            cnt++;
                        }
                    }
                }
                if (itemPlanGrid.Rows.Count == 0)
                {
                    MessageBox.Show("제품을 하나이상 등록하세요.");
                    return;
                }

                string order_yn = comInfo.resultYn(chk_order_yn);
                if (lbl_plan_gbn.Text != "1")
                {

                    string plan_num = txt_plan_date.Text.ToString().Replace("-", "");
                    plan_num = plan_num.Substring(4, 4).ToString();

                    wnDm wDm = new wnDm();
                    int rsNum = wDm.insertPlan(
                        txt_plan_date.Text.ToString(),
                        txt_cust_cd.Text.ToString(),
                        req_date.Text.ToString(),
                        order_yn,
                        plan_num,
                        txt_comment.Text.ToString(),
                        itemPlanGrid,
                        itemHalfGrid,
                        txt_jumun_date.Text,
                        txt_jumun_cd.Text,
                        Jumun_date_array,
                        Jumun_cd_array);

                    if (rsNum == 0)
                    {
                        //wnProcCon wDmProc = new wnProcCon();
                        //int rsNum2 = wDmProc.prod_plan_group(txt_plan_date.Text.ToString(), txt_plan_cd.Text.ToString(), Common.p_strStaffNo);

                        //if (rsNum2 == -9)
                        //{
                        //    wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                        //}

                        resetSetting();
                        plan_list(planGrid, "where A.PLAN_DATE >= '" + start_date.Text.ToString() + "' and  A.PLAN_DATE <= '" + end_date.Text.ToString() + "'");

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
                }
                else
                {
                    if (!right[1])
                    {
                        MessageBox.Show("권한이없습니다.");
                        return;
                    }
                    wnDm wDm = new wnDm();
                    int rsNum = wDm.updatePlan(
                        txt_plan_date.Text.ToString(),
                        txt_plan_cd.Text.ToString(),
                        txt_cust_cd.Text.ToString(),
                        req_date.Text.ToString(),
                        order_yn,
                        txt_comment.Text.ToString(),
                        itemPlanGrid,
                        itemHalfGrid,
                        del_planGrid,
                        del_HalfGrid,
                        txt_jumun_date.Text,
                        txt_jumun_cd.Text,
                        Jumun_date_array,
                        Jumun_cd_array);

                    if (rsNum == 0)
                    {
                        wnProcCon wDmProc = new wnProcCon();
                        int rsNum2 = wDmProc.prod_plan_group(txt_plan_date.Text.ToString(), txt_plan_cd.Text.ToString(), Common.p_strStaffNo);

                        if (rsNum2 == -9)
                        {
                            wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                        }

                        Jumun_date_array.Clear();
                        Jumun_cd_array.Clear();
                        del_planGrid.Rows.Clear();
                        del_HalfGrid.Rows.Clear();
                        plan_list(planGrid, "where A.PLAN_DATE >= '" + start_date.Text.ToString() + "' and  A.PLAN_DATE <= '" + end_date.Text.ToString() + "'");
                        planDetail2();

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
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(e.Message + " - " + e.ToString()); msg.ShowDialog();
            }
        }

        private void plan_list(DataGridView dgv, string condition)
        {
            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = null;
                dt = wDm.fn_Plan_List(condition);

                lbl_cnt.Text = dt.Rows.Count.ToString();

                if (dt != null && dt.Rows.Count > 0)
                {
                    dgv.RowCount = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgv.Rows[i].Cells[0].Value = dt.Rows[i]["PLAN_DATE"].ToString();
                        dgv.Rows[i].Cells[1].Value = dt.Rows[i]["PLAN_CD"].ToString();
                        dgv.Rows[i].Cells[5].Value = dt.Rows[i]["CUST_CD"].ToString();
                        dgv.Rows[i].Cells[2].Value = dt.Rows[i]["CUST_NM"].ToString();
                        dgv.Rows[i].Cells[3].Value = dt.Rows[i]["DELIVER_REQ_DATE"].ToString();
                        dgv.Rows[i].Cells[7].Value = dt.Rows[i]["ORDER_YN"].ToString();
                        dgv.Rows[i].Cells[8].Value = dt.Rows[i]["PLAN_NUM"].ToString();
                        dgv.Rows[i].Cells[6].Value = dt.Rows[i]["ITEM_CNT2"].ToString();
                    }
                }
                else
                {
                    planGrid.Rows.Clear();
                }
            }
            catch (Exception e)
            {
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(e.Message + " - " + e.ToString()); msg.ShowDialog();
            }
        }
        #endregion prod plan logic


        private void plan_del()
        {
            ComInfo comInfo = new ComInfo();
            DialogResult msgOk = comInfo.deleteConfrim("계획/수주", txt_plan_date.Text.ToString() + " - " + txt_plan_cd.Text.ToString());

            if (msgOk == DialogResult.No)
            {
                return;
            }

            wnDm wDm = new wnDm();
            int rsNum = wDm.deletePlan(txt_plan_date.Text.ToString(), txt_plan_cd.Text.ToString());
            if (rsNum == 0)
            {
                resetSetting();

                plan_list(planGrid, "where A.PLAN_DATE >= '" + start_date.Text.ToString() + "' and  A.PLAN_DATE <= '" + end_date.Text.ToString() + "'");

                MessageBox.Show("성공적으로 삭제하였습니다.");
            }
            else if (rsNum == 1)
            {
                MessageBox.Show("삭제에 실패하였습니다.");
            }
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

        private void grid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            conDataGridView grd = (conDataGridView)sender;

            grd.Rows[e.RowIndex].Cells[0].Value = false;

            // No.
            grd.Rows[e.RowIndex].Cells[1].Style.BackColor = Color.WhiteSmoke;
            grd.Rows[e.RowIndex].Cells[1].Style.SelectionBackColor = Color.Khaki;

            // 코드

            for (int kk = 0; kk < grd.Rows.Count; kk++)
            {
                grd.Rows[kk].Cells[1].Value = (kk + 1).ToString();
            }
        }

        private void grid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            conDataGridView grd = (conDataGridView)sender;

            // 헤더 첫 컬럼 클릭시
            if (e.ColumnIndex != 0) return;

            if (bHeadCheck == false)
            {
                grd.Columns[0].HeaderText = "[v]";
                bHeadCheck = true;
                select_Check(grd, bHeadCheck);
            }
            else
            {
                grd.Columns[0].HeaderText = "[ ]";
                bHeadCheck = false;
                select_Check(grd, bHeadCheck);
            }
            grd.RefreshEdit();
            grd.Refresh();
        }

        private void grid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            string name = itemPlanGrid.CurrentCell.OwningColumn.Name;

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
            //if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            //    e.Handled = true;
        }

        private bool bHeadCheck = false;
        private void select_Check(conDataGridView grd, bool bCheck)
        {
            for (int kk = 0; kk < grd.Rows.Count; kk++)
            {
                if (bCheck == true)
                {
                    grd.Rows[kk].Cells[0].Value = true;
                }
                else
                {
                    grd.Rows[kk].Cells[0].Value = false;
                }
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

            //// 수량, 금액 != 0 자료 구분
            //if (grd.Rows[e.RowIndex].Cells[7].Value != null && grd.Rows[e.RowIndex].Cells[9].Value != null)
            //{
            //    if (decimal.Parse("" + (string)grd.Rows[e.RowIndex].Cells[7].Value) > 0 && decimal.Parse("" + (string)grd.Rows[e.RowIndex].Cells[9].Value) > 0)
            //    {
            //        grd.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
            //        grd.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Black;
            //    }
            //}
        }

        private void grid_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {

        }

        private void grid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            conDataGridView grd = (conDataGridView)sender;
            DataGridViewCell cell = grd[e.ColumnIndex, e.RowIndex];

            cell.Style.BackColor = Color.White;


            #region 공통 그리드 체크
            if (grd.Columns[e.ColumnIndex].ToolTipText.IndexOf("명칭") >= 0 && grd._KeyInput == "enter")
            {
                string item_nm = (string)grd.Rows[e.RowIndex].Cells["ITEM_NM"].Value;
                wnDm wDm = new wnDm();
                DataTable dt = new DataTable();
                String sqlcontion = "";
                if (txt_cust_cd.Text != "" & Common.p_saupNo == "1278113487")
                {
                    sqlcontion += "and A.cust_CD = '" + txt_cust_cd.Text + "'";

                }
                else
                {
                    txt_cust_cd.Tag = "NOT매출제품";

                }
                dt = wDm.fn_Item_List("where ITEM_NM like '%" + item_nm + "%' " + sqlcontion, txt_cust_cd.Text);

                if (dt.Rows.Count > 1)
                { //row가 2줄이 넘을 경우 팝업으로 넘어간다.

                    string sResult = wConst.call_pop_item2(grd, dt, e.RowIndex, item_nm, txt_cust_cd.Text);

                    if (sResult != "")
                    {
                        halfLogic(grd); //반제품 로직 
                    }
                    //itemPlanGridAdd();
                }
                else if (dt.Rows.Count == 1) //row가 1일 경우 해당 row에 값을 자동 입력한다.
                {
                    grd.Rows[e.RowIndex].Cells["ITEM_NM"].Value = dt.Rows[0]["ITEM_NM"].ToString();
                    grd.Rows[e.RowIndex].Cells["ITEM_CD"].Value = dt.Rows[0]["ITEM_CD"].ToString();
                    grd.Rows[e.RowIndex].Cells["SPEC"].Value = dt.Rows[0]["SPEC"].ToString();

                    grd.Rows[e.RowIndex].Cells["UNIT_CD"].Value = dt.Rows[0]["UNIT_CD"].ToString();
                    grd.Rows[e.RowIndex].Cells["UNIT_NM"].Value = dt.Rows[0]["UNIT_NM"].ToString();
                    grd.Rows[e.RowIndex].Cells["TOTAL_AMT"].Value = "1";
                    grd.Rows[e.RowIndex].Cells["UNIT_AMT"].Value = "1";

                    grd.Rows[e.RowIndex].Cells["PRICE"].Value = dt.Rows[0]["OUTPUT_PRICE"].ToString();

                    grd.Rows[e.RowIndex].Cells["OLD_ITEM_NM"].Value = dt.Rows[0]["ITEM_NM"].ToString(); //백업 키워드 
                    itemPlanGridAdd();

                    halfLogic(grd);
                }
                else
                { //row가 없는 경우
                    MessageBox.Show("데이터가 없습니다.");
                    itemPlanGrid.Rows.RemoveAt(itemPlanGrid.SelectedRows[0].Index);
                    itemPlanGrid.CurrentCell = itemPlanGrid[2, itemPlanGrid.Rows.Count];
                }

                wConst.f_Calc_Price(grd, e.RowIndex, "TOTAL_AMT", "PRICE");
            }

            if (grd.Columns[e.ColumnIndex].ToolTipText.IndexOf("수량") >= 0
                || grd.Columns[e.ColumnIndex].ToolTipText.IndexOf("단가") >= 0
                || grd.Columns[e.ColumnIndex].ToolTipText.IndexOf("금액") >= 0)
            {

                string total_amt = (string)grd.Rows[e.RowIndex].Cells["TOTAL_AMT"].Value;
                string price = (string)grd.Rows[e.RowIndex].Cells["PRICE"].Value;

                if (total_amt != null)
                {
                    total_amt = total_amt.ToString().Replace(" ", "");
                    if (total_amt == "")
                    {
                        grd.Rows[e.RowIndex].Cells["TOTAL_AMT"].Value = "0";
                    }
                }
                else
                {
                    grd.Rows[e.RowIndex].Cells["TOTAL_AMT"].Value = "0";
                }

                if (price != null)
                {
                    price = price.ToString().Replace(" ", "");
                    if (price == "")
                    {
                        grd.Rows[e.RowIndex].Cells["PRICE"].Value = "0";
                    }
                }
                else
                {
                    grd.Rows[e.RowIndex].Cells["PRICE"].Value = "0";
                }

                //if (total_amt == "" || total_amt == null)
                //{
                //    grd.Rows[e.RowIndex].Cells["TOTAL_AMT"].Value = "0";
                //}
                //if (price == "" || price == null)
                //{
                //    grd.Rows[e.RowIndex].Cells["PRICE"].Value = "0";
                //}

                wConst.f_Calc_Price(grd, e.RowIndex, "TOTAL_AMT", "PRICE");

                int rowIndexTemp = e.RowIndex;
                Cal_Half_Amt(grd, rowIndexTemp);
            }
            #endregion 공통 그리드 체크

            //string sSearchTxt = "" + (string)grd.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

        }

        private void Cal_Half_Amt(conDataGridView grd, int rowIndexTemp)
        {
            string item_cd_chk = (string)grd.Rows[rowIndexTemp].Cells["ITEM_CD"].Value;
            if (item_cd_chk != null)
            {
                if (itemHalfGrid.Rows.Count > 0)
                {
                    double t_total_amt = double.Parse(((string)grd.Rows[rowIndexTemp].Cells["TOTAL_AMT"].Value).Replace(",", ""));
                    for (int i = 0; i < itemHalfGrid.Rows.Count; i++)
                    {
                        if (itemHalfGrid.Rows[i].Cells["TOP_ITEM_CD"].Value.ToString().Equals(item_cd_chk))
                        {
                            double d_rst = t_total_amt * double.Parse(itemHalfGrid.Rows[i].Cells["DEFAULT_AMT"].Value.ToString());

                            itemHalfGrid.Rows[i].Cells["H_TOTAL_AMT"].Value = (decimal.Parse(d_rst.ToString())).ToString("#,0.######");
                        }
                    }
                }
            }
        }

        private void btn_plus_Click(object sender, EventArgs e)
        {
            itemPlanGridAdd();
        }

        private void btn_minus_Click(object sender, EventArgs e)
        {
            minus_logic(itemPlanGrid);
        }

        private void itemPlanGridAdd()
        {
            itemPlanGrid.Rows.Add();
            itemPlanGrid.Rows[itemPlanGrid.Rows.Count - 1].Cells["TOTAL_AMT"].Value = "0";
            itemPlanGrid.Rows[itemPlanGrid.Rows.Count - 1].Cells["PRICE"].Value = "0";
            itemPlanGrid.Rows[itemPlanGrid.Rows.Count - 1].Cells["TOTAL_MONEY"].Value = "0";
        }

        private void minus_logic(conDataGridView dgv)
        {
            if (dgv.Rows.Count > 1)
            {
                if ((string)dgv.SelectedRows[0].Cells["SEQ"].Value != "" && dgv.SelectedRows[0].Cells["SEQ"].Value != null)
                {

                    int cnt = del_planGrid.Rows.Count;
                    del_planGrid.Rows.Add();

                    del_planGrid.Rows[del_planGrid.Rows.Count - 1].Cells["PLAN_DATE"].Value = txt_plan_date.Text.ToString();
                    del_planGrid.Rows[del_planGrid.Rows.Count - 1].Cells["PLAN_CD"].Value = txt_plan_cd.Text.ToString();
                    del_planGrid.Rows[del_planGrid.Rows.Count - 1].Cells["SEQ"].Value = dgv.SelectedRows[0].Cells["SEQ"].Value;

                    //제품의 하위제품들 제거 (계획번호가 있을 경우)
                    for (int i = 0; i < itemHalfGrid.Rows.Count; i++)
                    {
                        if ((string)dgv.SelectedRows[0].Cells["ITEM_CD"].Value == itemHalfGrid.Rows[i].Cells["TOP_ITEM_CD"].Value.ToString())
                        {
                            del_HalfGrid.Rows.Add();

                            del_HalfGrid.Rows[del_HalfGrid.Rows.Count - 1].Cells["PLAN_DATE"].Value = txt_plan_date.Text.ToString();
                            del_HalfGrid.Rows[del_HalfGrid.Rows.Count - 1].Cells["PLAN_CD"].Value = txt_plan_cd.Text.ToString();
                            del_HalfGrid.Rows[del_HalfGrid.Rows.Count - 1].Cells["SEQ"].Value = itemHalfGrid.Rows[i].Cells["H_SEQ"].Value;
                        }
                    }

                    for (int j = itemHalfGrid.Rows.Count - 1; j >= 0; j--)
                    {
                        if ((string)dgv.SelectedRows[0].Cells["ITEM_CD"].Value == itemHalfGrid.Rows[j].Cells["TOP_ITEM_CD"].Value.ToString())
                        {
                            itemHalfGrid.Rows.RemoveAt(j);
                        }
                    }
                }

                //제품의 하위제품들 제거
                for (int j = itemHalfGrid.Rows.Count - 1; j >= 0; j--)
                {
                    if ((string)dgv.SelectedRows[0].Cells["ITEM_CD"].Value == itemHalfGrid.Rows[j].Cells["TOP_ITEM_CD"].Value.ToString())
                    {
                        itemHalfGrid.Rows.RemoveAt(j);
                    }
                }

                dgv.Rows.RemoveAt(dgv.SelectedRows[0].Index);
                dgv.CurrentCell = dgv[2, dgv.Rows.Count - 1];
            }
        }

        private void planGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Refresh();
            btn반환.Enabled = true;

            if (ComInfo.grdHeaderNoAction(e))
            {
                planDetail(planGrid, e);
                itemPlanGrid.Focus();
            }

        }
        private void planDetail(DataGridView dgv, DataGridViewCellEventArgs e)
        {
            btnDelete.Enabled = true;
            lbl_plan_gbn.Text = "1";
            txt_plan_date.Enabled = false;
            btn_jumun_select.Enabled = false;
            txt_plan_date.Text = dgv.Rows[e.RowIndex].Cells[0].Value.ToString();

            txt_plan_cd.Text = dgv.Rows[e.RowIndex].Cells[1].Value.ToString();
            txt_cust_cd.Text = dgv.Rows[e.RowIndex].Cells[5].Value.ToString();
            txt_cust_nm.Text = dgv.Rows[e.RowIndex].Cells[2].Value.ToString();
            req_date.Text = dgv.Rows[e.RowIndex].Cells[3].Value.ToString();
            txt_planNum.Text = dgv.Rows[e.RowIndex].Cells[8].Value.ToString();


            if (dgv.Rows[e.RowIndex].Cells["ORDER_YN"].Value.ToString().Equals("Y") | dgv.Rows[e.RowIndex].Cells["ORDER_YN"].Value.ToString().Equals("산출"))
            {
                chk_order_yn.Checked = true;
            }
            else
            {
                chk_order_yn.Checked = false;
            }

            planDetail2();
        }

        private void planDetail2()
        {
            wnDm wDm = new wnDm();
            DataTable dt = null;

            dt = wDm.fn_Plan_Detail_List("where A.PLAN_DATE = '" + txt_plan_date.Text.ToString() + "' and A.PLAN_CD = '" + txt_plan_cd.Text.ToString() + "' ");

            if (dt != null && dt.Rows.Count > 0)
            {
                int itemChk = 0;
                int halfChk = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["F_LEVEL"].ToString().Equals("1"))
                    {
                        itemChk++;
                    }
                    else
                    {
                        halfChk++;
                    }
                }

                itemPlanGrid.RowCount = itemChk;
                itemHalfGrid.RowCount = halfChk;


                for (int i = 0; i < itemPlanGrid.Rows.Count; i++)
                {
                    //itemPlanGrid.Rows.Add();
                    itemPlanGrid.Rows[i].Cells["P_PLAN_DATE"].Value = dt.Rows[i]["PLAN_DATE"].ToString();
                    itemPlanGrid.Rows[i].Cells["P_PLAN_CD"].Value = dt.Rows[i]["PLAN_CD"].ToString();
                    itemPlanGrid.Rows[i].Cells["SPEC"].Value = dt.Rows[i]["SPEC"].ToString();
                    itemPlanGrid.Rows[i].Cells["SEQ"].Value = dt.Rows[i]["SEQ"].ToString();
                    itemPlanGrid.Rows[i].Cells["ITEM_CD"].Value = dt.Rows[i]["ITEM_CD"].ToString();
                    itemPlanGrid.Rows[i].Cells["ITEM_NM"].Value = dt.Rows[i]["ITEM_NM"].ToString();
                    itemPlanGrid.Rows[i].Cells["UNIT_CD"].Value = dt.Rows[i]["UNIT_CD"].ToString();
                    itemPlanGrid.Rows[i].Cells["UNIT_NM"].Value = dt.Rows[i]["UNIT_NM"].ToString();

                    if (dt.Rows[i]["WORK_YN"].ToString().Equals("Y"))
                    {
                        itemPlanGrid.Rows[i].Cells["WORK_YN"].Value = true;
                    }
                    else
                    {
                        itemPlanGrid.Rows[i].Cells["WORK_YN"].Value = false;
                    }

                    itemPlanGrid.Rows[i].Cells["TOTAL_AMT"].Value = (decimal.Parse(dt.Rows[i]["TOTAL_AMT"].ToString())).ToString("#,0.######");
                    itemPlanGrid.Rows[i].Cells["PRICE"].Value = (decimal.Parse(dt.Rows[i]["PRICE"].ToString())).ToString("#,0.######");
                    itemPlanGrid.Rows[i].Cells["TOTAL_MONEY"].Value = (decimal.Parse(dt.Rows[i]["TOTAL_MONEY"].ToString())).ToString("#,0.######");
                }

                int j = 0;
                for (int i = itemChk; i < dt.Rows.Count; i++)
                {
                    //itemPlanGrid.Rows.Add();
                    itemHalfGrid.Rows[j].Cells[0].Value = (j + 1).ToString();
                    itemHalfGrid.Rows[j].Cells["H_PLAN_DATE"].Value = dt.Rows[i]["PLAN_DATE"].ToString();
                    itemHalfGrid.Rows[j].Cells["H_PLAN_CD"].Value = dt.Rows[i]["PLAN_CD"].ToString();
                    itemHalfGrid.Rows[j].Cells["H_SPEC"].Value = dt.Rows[i]["SPEC"].ToString();
                    itemHalfGrid.Rows[j].Cells["H_SEQ"].Value = dt.Rows[i]["SEQ"].ToString();
                    itemHalfGrid.Rows[j].Cells["HALF_ITEM_CD"].Value = dt.Rows[i]["ITEM_CD"].ToString();
                    itemHalfGrid.Rows[j].Cells["HALF_ITEM_NM"].Value = dt.Rows[i]["ITEM_NM"].ToString();
                    itemHalfGrid.Rows[j].Cells["H_UNIT_CD"].Value = dt.Rows[i]["UNIT_CD"].ToString();
                    itemHalfGrid.Rows[j].Cells["H_UNIT_NM"].Value = dt.Rows[i]["UNIT_NM"].ToString();
                    itemHalfGrid.Rows[j].Cells["F_LEVEL"].Value = dt.Rows[i]["F_LEVEL"].ToString();
                    itemHalfGrid.Rows[j].Cells["TOP_ITEM_CD"].Value = dt.Rows[i]["TOP_ITEM_CD"].ToString();
                    itemHalfGrid.Rows[j].Cells["TOP_ITEM_NM"].Value = dt.Rows[i]["TOP_ITEM_NM"].ToString();
                    itemHalfGrid.Rows[j].Cells["P_ITEM_CD"].Value = dt.Rows[i]["P_ITEM_CD"].ToString();
                    itemHalfGrid.Rows[j].Cells["P_ITEM_NM"].Value = dt.Rows[i]["P_ITEM_NM"].ToString();
                    itemHalfGrid.Rows[j].Cells["DEFAULT_AMT"].Value = dt.Rows[i]["DEFAULT_AMT"].ToString();

                    if (dt.Rows[i]["WORK_YN"].ToString().Equals("Y"))
                    {
                        itemHalfGrid.Rows[j].Cells["H_WORK_YN"].Value = true;
                    }
                    else
                    {
                        itemHalfGrid.Rows[j].Cells["H_WORK_YN"].Value = false;
                    }

                    itemHalfGrid.Rows[j].Cells["H_TOTAL_AMT"].Value = (decimal.Parse(dt.Rows[i]["TOTAL_AMT"].ToString())).ToString("#,0.######");
                    itemHalfGrid.Rows[j].Cells["H_PRICE"].Value = (decimal.Parse(dt.Rows[i]["PRICE"].ToString())).ToString("#,0.######");
                    itemHalfGrid.Rows[j].Cells["H_TOTAL_MONEY"].Value = (decimal.Parse(dt.Rows[i]["TOTAL_MONEY"].ToString())).ToString("#,0.######");

                    j++;
                }
            }
            else
            {
                itemPlanGrid.RowCount = 0;
                itemPlanGridAdd(); //데이터가 없을 경우 빈 행 생성
            }
        }

        private void halfLogic(conDataGridView grd)
        {
            wnDm wDm = new wnDm();
            DataTable dt2 = new DataTable();
            dt2 = wDm.fn_Item_Half_List("WHERE A.ITEM_CD = '" + grd.Rows[grd.Rows.Count - 2].Cells["ITEM_CD"].Value.ToString() + "' ", 1);

            if (dt2.Rows.Count > 0)
            {
                //halfgrid는 2단계부터 시작됩니다.

                string item_cd = grd.Rows[grd.Rows.Count - 2].Cells["ITEM_CD"].Value.ToString();
                string item_nm = grd.Rows[grd.Rows.Count - 2].Cells["ITEM_NM"].Value.ToString();

                // LEVEL 2 
                stepHalfGrid(pHalfGrid, dt2, item_cd, item_cd, item_nm, item_nm, "2");
                int start_lv3_idx = pHalfGrid.Rows.Count;

                //LEVEL 3
                //string sWhere = "";
                StringBuilder sb = new StringBuilder();

                int chk = 0;
                int eRow = pHalfGrid.Rows.Count;
                for (int i = 0; i < eRow; i++)
                {
                    string total_amt = (string)pHalfGrid.Rows[i].Cells["H_TOTAL_AMT"].Value.ToString();
                    sb.Clear();
                    sb.AppendLine("where 1=1 ");
                    sb.AppendLine(" and A.ITEM_CD = '" + pHalfGrid.Rows[i].Cells["HALF_ITEM_CD"].Value.ToString() + "' ");

                    DataTable dt3 = new DataTable();
                    dt3 = wDm.fn_Item_Half_List(sb.ToString(), double.Parse(total_amt));

                    if (dt3 != null && dt3.Rows.Count > 0)
                    {
                        string top_item_cd = grd.Rows[grd.Rows.Count - 2].Cells["ITEM_CD"].Value.ToString();
                        string top_item_nm = grd.Rows[grd.Rows.Count - 2].Cells["ITEM_NM"].Value.ToString();

                        string p_item_cd = pHalfGrid.Rows[i].Cells["HALF_ITEM_CD"].Value.ToString();
                        string p_item_nm = pHalfGrid.Rows[i].Cells["HALF_ITEM_NM"].Value.ToString();
                        stepHalfGrid(pHalfGrid, dt3, top_item_cd, p_item_cd, top_item_nm, p_item_nm, "3");
                        chk++;
                    }
                }
                if (chk > 0)
                {
                    chk = 0; //초기화 

                    eRow = pHalfGrid.Rows.Count;
                    for (int i = start_lv3_idx; i < eRow; i++)
                    {
                        string total_amt = (string)pHalfGrid.Rows[i].Cells["H_TOTAL_AMT"].Value.ToString();

                        sb.AppendLine("where 1=1 ");
                        sb.AppendLine(" and A.ITEM_CD = '" + pHalfGrid.Rows[i].Cells["HALF_ITEM_CD"].Value.ToString() + "' ");

                        DataTable dt4 = new DataTable();
                        dt4 = wDm.fn_Item_Half_List(sb.ToString(), double.Parse(total_amt));

                        if (dt4 != null && dt4.Rows.Count > 0)
                        {
                            string top_item_cd = grd.Rows[grd.Rows.Count - 2].Cells["ITEM_CD"].Value.ToString();
                            string top_item_nm = grd.Rows[grd.Rows.Count - 2].Cells["ITEM_NM"].Value.ToString();

                            string p_item_cd = pHalfGrid.Rows[i].Cells["HALF_ITEM_CD"].Value.ToString();
                            string p_item_nm = pHalfGrid.Rows[i].Cells["HALF_ITEM_NM"].Value.ToString();

                            stepHalfGrid(pHalfGrid, dt4, top_item_cd, p_item_cd, top_item_nm, p_item_nm, "4");
                            chk++;
                        }
                    }
                }

                for (int i = 0; i < pHalfGrid.Rows.Count; i++)
                {
                    itemHalfGrid.Rows.Add();

                    itemHalfGrid.Rows[itemHalfGrid.Rows.Count - 1].Cells[0].Value = itemHalfGrid.Rows.Count.ToString();
                    itemHalfGrid.Rows[itemHalfGrid.Rows.Count - 1].Cells["HALF_ITEM_NM"].Value = pHalfGrid.Rows[i].Cells["HALF_ITEM_NM"].Value;
                    itemHalfGrid.Rows[itemHalfGrid.Rows.Count - 1].Cells["HALF_ITEM_CD"].Value = pHalfGrid.Rows[i].Cells["HALF_ITEM_CD"].Value;
                    itemHalfGrid.Rows[itemHalfGrid.Rows.Count - 1].Cells["H_SPEC"].Value = pHalfGrid.Rows[i].Cells["H_SPEC"].Value;

                    itemHalfGrid.Rows[itemHalfGrid.Rows.Count - 1].Cells["H_UNIT_CD"].Value = pHalfGrid.Rows[i].Cells["H_UNIT_CD"].Value;
                    itemHalfGrid.Rows[itemHalfGrid.Rows.Count - 1].Cells["H_UNIT_NM"].Value = pHalfGrid.Rows[i].Cells["H_UNIT_NM"].Value;
                    itemHalfGrid.Rows[itemHalfGrid.Rows.Count - 1].Cells["H_TOTAL_AMT"].Value = pHalfGrid.Rows[i].Cells["H_TOTAL_AMT"].Value;
                    itemHalfGrid.Rows[itemHalfGrid.Rows.Count - 1].Cells["H_PRICE"].Value = pHalfGrid.Rows[i].Cells["H_PRICE"].Value;
                    itemHalfGrid.Rows[itemHalfGrid.Rows.Count - 1].Cells["H_TOTAL_MONEY"].Value = pHalfGrid.Rows[i].Cells["H_TOTAL_MONEY"].Value;

                    itemHalfGrid.Rows[itemHalfGrid.Rows.Count - 1].Cells["F_LEVEL"].Value = pHalfGrid.Rows[i].Cells["F_LEVEL"].Value;
                    itemHalfGrid.Rows[itemHalfGrid.Rows.Count - 1].Cells["TOP_ITEM_CD"].Value = pHalfGrid.Rows[i].Cells["TOP_ITEM_CD"].Value;
                    itemHalfGrid.Rows[itemHalfGrid.Rows.Count - 1].Cells["P_ITEM_CD"].Value = pHalfGrid.Rows[i].Cells["P_ITEM_CD"].Value;

                    itemHalfGrid.Rows[itemHalfGrid.Rows.Count - 1].Cells["TOP_ITEM_NM"].Value = pHalfGrid.Rows[i].Cells["TOP_ITEM_NM"].Value;
                    itemHalfGrid.Rows[itemHalfGrid.Rows.Count - 1].Cells["P_ITEM_NM"].Value = pHalfGrid.Rows[i].Cells["P_ITEM_NM"].Value;

                    itemHalfGrid.Rows[itemHalfGrid.Rows.Count - 1].Cells["H_WORK_YN"].Value = false;

                    itemHalfGrid.Rows[itemHalfGrid.Rows.Count - 1].Cells["DEFAULT_AMT"].Value = pHalfGrid.Rows[i].Cells["DEFAULT_AMT"].Value;
                }

                pHalfGrid.Rows.Clear();
            }
        }

        private void stepHalfGrid(DataGridView dgv, DataTable dt, string item_cd, string parent_item_cd, string item_nm, string parent_item_nm, string f_level)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dgv.Rows.Add();

                dgv.Rows[dgv.Rows.Count - 1].Cells["HALF_ITEM_NM"].Value = dt.Rows[i]["HALF_ITEM_NM"].ToString();
                dgv.Rows[dgv.Rows.Count - 1].Cells["HALF_ITEM_CD"].Value = dt.Rows[i]["HALF_ITEM_CD"].ToString();
                dgv.Rows[dgv.Rows.Count - 1].Cells["H_SPEC"].Value = dt.Rows[i]["SPEC"].ToString();

                dgv.Rows[dgv.Rows.Count - 1].Cells["H_UNIT_CD"].Value = dt.Rows[i]["UNIT_CD"].ToString();
                dgv.Rows[dgv.Rows.Count - 1].Cells["H_UNIT_NM"].Value = dt.Rows[i]["UNIT_NM"].ToString();
                dgv.Rows[dgv.Rows.Count - 1].Cells["H_TOTAL_AMT"].Value = (decimal.Parse(dt.Rows[i]["TOTAL_AMT"].ToString())).ToString("#,0.######");
                dgv.Rows[dgv.Rows.Count - 1].Cells["DEFAULT_AMT"].Value = dt.Rows[i]["TOTAL_AMT"].ToString();
                dgv.Rows[dgv.Rows.Count - 1].Cells["H_PRICE"].Value = (decimal.Parse(dt.Rows[i]["PRICE"].ToString())).ToString("#,0.######");
                dgv.Rows[dgv.Rows.Count - 1].Cells["H_TOTAL_MONEY"].Value = (double.Parse(dt.Rows[i]["TOTAL_AMT"].ToString()) * double.Parse(dt.Rows[i]["PRICE"].ToString())).ToString("#,0.######");
                dgv.Rows[dgv.Rows.Count - 1].Cells["F_LEVEL"].Value = f_level;
                dgv.Rows[dgv.Rows.Count - 1].Cells["TOP_ITEM_CD"].Value = item_cd;
                dgv.Rows[dgv.Rows.Count - 1].Cells["P_ITEM_CD"].Value = parent_item_cd;
                dgv.Rows[dgv.Rows.Count - 1].Cells["TOP_ITEM_NM"].Value = item_nm;
                dgv.Rows[dgv.Rows.Count - 1].Cells["P_ITEM_NM"].Value = parent_item_nm;
            }
        }

        private string stepWhere(DataGridView dgv, int sRow, int eRow)
        {
            DataTable dt3 = new DataTable();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" where 1=1 ");
            for (int i = sRow; i < eRow; i++)
            {
                if (i == 0)
                {
                    sb.AppendLine(" and (A.ITEM_CD = '" + dgv.Rows[i].Cells["HALF_ITEM_CD"].Value.ToString() + "' ");
                }
                else
                {
                    sb.AppendLine("     or A.ITEM_CD = '" + dgv.Rows[i].Cells["HALF_ITEM_CD"].Value.ToString() + "' ");
                }
            }
            sb.AppendLine("      ) ");

            return sb.ToString();
        }

        private void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                switch (itemPlanGrid.Columns[e.ColumnIndex].Name)
                {
                    case "ITEM_NM":
                        if (itemPlanGrid.Rows[e.RowIndex].Cells["ITEM_NM"].Value == null)
                        {

                            conDataGridView grd = (conDataGridView)sender;
                            DataGridViewCell cell = grd[e.ColumnIndex, e.RowIndex];

                            cell.Style.BackColor = Color.White;
                            String sqlcontion = "";
                            if (txt_cust_cd.Text != "")
                            {
                                sqlcontion += "and A.cust_CD = '" + txt_cust_cd.Text + "'";
                            }

                            if (grd.Columns[e.ColumnIndex].ToolTipText.IndexOf("명칭") >= 0)
                            {
                                string item_nm = (string)grd.Rows[e.RowIndex].Cells["ITEM_NM"].Value;
                                wnDm wDm = new wnDm();
                                DataTable dt = new DataTable();
                                dt = wDm.fn_Item_List("where ITEM_NM like '%" + item_nm + "%' " + sqlcontion, txt_cust_cd.Text);

                                if (dt.Rows.Count > 1)
                                { //row가 2줄이 넘을 경우 팝업으로 넘어간다.

                                    string sResult = wConst.call_pop_item2(grd, dt, e.RowIndex, item_nm, txt_cust_cd.Text);

                                    if (sResult != "")
                                    {
                                        halfLogic(grd); //반제품 로직 
                                    }
                                    //itemPlanGridAdd();
                                }
                                else if (dt.Rows.Count == 1) //row가 1일 경우 해당 row에 값을 자동 입력한다.
                                {
                                    grd.Rows[e.RowIndex].Cells["ITEM_NM"].Value = dt.Rows[0]["ITEM_NM"].ToString();
                                    grd.Rows[e.RowIndex].Cells["ITEM_CD"].Value = dt.Rows[0]["ITEM_CD"].ToString();
                                    grd.Rows[e.RowIndex].Cells["SPEC"].Value = dt.Rows[0]["SPEC"].ToString();

                                    grd.Rows[e.RowIndex].Cells["UNIT_CD"].Value = dt.Rows[0]["UNIT_CD"].ToString();
                                    grd.Rows[e.RowIndex].Cells["UNIT_NM"].Value = dt.Rows[0]["UNIT_NM"].ToString();
                                    grd.Rows[e.RowIndex].Cells["TOTAL_AMT"].Value = "1";
                                    grd.Rows[e.RowIndex].Cells["UNIT_AMT"].Value = "1";

                                    grd.Rows[e.RowIndex].Cells["PRICE"].Value = dt.Rows[0]["OUTPUT_PRICE"].ToString();

                                    grd.Rows[e.RowIndex].Cells["OLD_ITEM_NM"].Value = dt.Rows[0]["ITEM_NM"].ToString(); //백업 키워드 
                                    itemPlanGridAdd();

                                    halfLogic(grd);
                                }
                                else
                                { //row가 없는 경우
                                    MessageBox.Show("데이터가 없습니다.");
                                }

                                wConst.f_Calc_Price(grd, e.RowIndex, "TOTAL_AMT", "PRICE");
                            }

                            if (grd.Columns[e.ColumnIndex].ToolTipText.IndexOf("수량") >= 0
                                || grd.Columns[e.ColumnIndex].ToolTipText.IndexOf("단가") >= 0
                                || grd.Columns[e.ColumnIndex].ToolTipText.IndexOf("금액") >= 0)
                            {

                                string total_amt = (string)grd.Rows[e.RowIndex].Cells["TOTAL_AMT"].Value;
                                string price = (string)grd.Rows[e.RowIndex].Cells["PRICE"].Value;

                                if (total_amt != null)
                                {
                                    total_amt = total_amt.ToString().Replace(" ", "");
                                    if (total_amt == "")
                                    {
                                        grd.Rows[e.RowIndex].Cells["TOTAL_AMT"].Value = "0";
                                    }
                                }
                                else
                                {
                                    grd.Rows[e.RowIndex].Cells["TOTAL_AMT"].Value = "0";
                                }

                                if (price != null)
                                {
                                    price = price.ToString().Replace(" ", "");
                                    if (price == "")
                                    {
                                        grd.Rows[e.RowIndex].Cells["PRICE"].Value = "0";
                                    }
                                }
                                else
                                {
                                    grd.Rows[e.RowIndex].Cells["PRICE"].Value = "0";
                                }

                                //if (total_amt == "" || total_amt == null)
                                //{
                                //    grd.Rows[e.RowIndex].Cells["TOTAL_AMT"].Value = "0";
                                //}
                                //if (price == "" || price == null)
                                //{
                                //    grd.Rows[e.RowIndex].Cells["PRICE"].Value = "0";
                                //}

                                wConst.f_Calc_Price(grd, e.RowIndex, "TOTAL_AMT", "PRICE");

                                string item_cd_chk = (string)grd.Rows[e.RowIndex].Cells["ITEM_CD"].Value;
                                if (item_cd_chk != null)
                                {
                                    if (itemPlanGrid.Rows.Count > 0)
                                    {
                                        double t_total_amt = double.Parse(((string)grd.Rows[e.RowIndex].Cells["TOTAL_AMT"].Value).Replace(",", ""));
                                        for (int i = 0; i < itemPlanGrid.Rows.Count; i++)
                                        {
                                            if (itemPlanGrid.Rows[i].Cells["TOP_ITEM_CD"].Value.ToString().Equals(item_cd_chk))
                                            {
                                                double d_rst = t_total_amt * double.Parse(itemHalfGrid.Rows[i].Cells["DEFAULT_AMT"].Value.ToString());

                                                itemPlanGrid.Rows[i].Cells["H_TOTAL_AMT"].Value = (decimal.Parse(d_rst.ToString())).ToString("#,0.######");
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                        }
                        break;
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("자재발주를 체크하지 않은 상태에서 저장을 하면 정보가 소요산출량으로 이동되며 소요산출량에서 정보를 저장하면 자동으로 자재발주가 체크됩니다.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            itemPlanGrid.Rows.Clear();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txt_comment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //to do
                itemPlanGrid.Focus();
            }

            else
            {
                return;
            }
        }

        private void itemPlanGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            itemPlanGrid.Rows[e.RowIndex].Cells["TOTAL_AMT"].Value = (decimal.Parse(itemPlanGrid.Rows[e.RowIndex].Cells["TOTAL_AMT"].Value.ToString()) + (decimal.Parse(itemPlanGrid.Rows[e.RowIndex].Cells["TOTAL_AMT"].Value.ToString()) * (decimal)0.05)).ToString();
        }

        private void CHKLOSS율_CheckedChanged(object sender, EventArgs e)
        {


        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (txtLOSS율.Text == "")
            {
                txtLOSS율.Text = "0";
            }



            if (MessageBox.Show(txtLOSS율.Text + "% 만큼 수량이 더해집니다.", "수량계산", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                double LOSS율 = double.Parse(txtLOSS율.Text.ToString()) / 100;
                for (int i = 0; i < itemPlanGrid.Rows.Count; i++)
                {
                    itemPlanGrid.Rows[i].Cells["TOTAL_AMT"].Value = (double.Parse(itemPlanGrid.Rows[i].Cells["TOTAL_AMT"].Value.ToString()) + double.Parse(itemPlanGrid.Rows[i].Cells["TOTAL_AMT"].Value.ToString()) * LOSS율).ToString("#,0.######");
                    itemPlanGrid.Rows[i].Cells["TOTAL_MONEY"].Value = (double.Parse(itemPlanGrid.Rows[i].Cells["TOTAL_MONEY"].Value.ToString()) + double.Parse(itemPlanGrid.Rows[i].Cells["TOTAL_MONEY"].Value.ToString()) * LOSS율).ToString("#,0.######");
                }
                txtLOSS율.Text = "0";

                btn반환.Enabled = false;

            }
            else
            {

            }


        }

        private void txt_cust_nm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Txtbtn[0].PerformClick();
            }

            else
            {
                return;
            }
        }

        private void txt_cust_nm_TextChanged(object sender, EventArgs e)
        {
            itemPlanGrid.Rows.Clear();
            itemHalfGrid.Rows.Clear();

            btn_plus_Click(sender, e);
        }

        private void itemPlanGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void itemPlanGrid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //var source = new AutoCompleteStringCollection();
            //source.AddRange(itemLST);
            //DataGridViewTextBoxEditingControl itemName = (DataGridViewTextBoxEditingControl)e.Control;
            //itemName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //itemName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //itemName.AutoCompleteCustomSource = source;
        }

        private void btn_jumun_select_Click(object sender, EventArgs e)
        {
            try
            {
                Popup.pop주문서검색 msg = new Popup.pop주문서검색(true);
                msg.plan_gubun = "1";
                msg.ShowDialog();

                if (msg.sjumun_date != null && !msg.sjumun_date.Equals(""))
                {
                    resetSetting_NotCustSetting();
                    txt_jumun_date.Text = msg.sjumun_date;
                    txt_jumun_cd.Text = msg.sjumun_cd;
                    txt_cust_cd.Text = msg.scust_cd;
                    txt_cust_nm.Text = msg.scust_nm;
                    req_date.Text = msg.sreq_date;

                    Jumun_detail();
                    //halfLogic(itemPlanGrid);
                    for (int i = 0; i < itemPlanGrid.Rows.Count; i++)
                    {
                        if (itemPlanGrid.Rows[i].Cells["ITEM_CD"].Value != null && !itemPlanGrid.Rows[i].Cells["ITEM_CD"].Value.ToString().Equals(""))
                        {
                            Cal_Half_Amt(itemPlanGrid, i);
                        }
                    }
                }
                else if (msg.rowIndexArr.Count > 0)
                {
                    resetSetting_NotCustSetting();

                    itemPlanGrid.Rows.Clear();
                    Jumun_date_array.Clear();
                    Jumun_cd_array.Clear();
                    itemPlanGrid.Rows.Add();
                    for (int i = 0; i < msg.rowIndexArr.Count; i++)
                    {
                        string soojoo_date = msg.GridRecord.Rows[(int)msg.rowIndexArr[i]].Cells["JUMUN_DATE"].Value.ToString();
                        string soojoo_cd = msg.GridRecord.Rows[(int)msg.rowIndexArr[i]].Cells["JUMUN_CD"].Value.ToString();
                        Jumun_date_array.Add(soojoo_date);
                        Jumun_cd_array.Add(soojoo_cd);
                        Jumun_detail_array(soojoo_date, soojoo_cd);
                        //halfLogic(itemPlanGrid);
                        //itemPlanGrid.Rows.Add
                    }
                    for (int i = 0; i < itemPlanGrid.Rows.Count; i++)
                    {
                        if (itemPlanGrid.Rows[i].Cells["ITEM_CD"].Value != null && !itemPlanGrid.Rows[i].Cells["ITEM_CD"].Value.ToString().Equals(""))
                        {
                            Cal_Half_Amt(itemPlanGrid, i);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("주문서 검색 중 오류발생. (Exception)");
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                msg.ShowDialog();
            }
        }
        private void Jumun_detail()
        {
            wnDm wDm = new wnDm();
            DataTable dt = new DataTable();
            try
            {
                dt = wDm.select_jumun_detail_list(txt_jumun_date.Text, txt_jumun_cd.Text);
                if (dt != null)
                {
                    itemPlanGrid.Rows.Clear();
                    //itemPlanGrid.RowCount = dt.Rows.Count;
                    itemPlanGrid.Rows.Add();

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        itemPlanGrid.Rows[i].DefaultCellStyle.BackColor = Color.MistyRose;
                        itemPlanGrid.Rows[i].DefaultCellStyle.SelectionBackColor = Color.MistyRose;
                        itemPlanGrid.Rows[i].Cells["ITEM_CD"].Value = dt.Rows[i]["ITEM_CD"].ToString();
                        itemPlanGrid.Rows[i].Cells["ITEM_NM"].Value = dt.Rows[i]["ITEM_NM"].ToString();
                        itemPlanGrid.Rows[i].Cells["SPEC"].Value = dt.Rows[i]["SPEC"].ToString();
                        itemPlanGrid.Rows[i].Cells["UNIT_CD"].Value = dt.Rows[i]["UNIT_CD"].ToString();
                        itemPlanGrid.Rows[i].Cells["UNIT_NM"].Value = dt.Rows[i]["UNIT_NM"].ToString();
                        itemPlanGrid.Rows[i].Cells["TOTAL_AMT"].Value = decimal.Parse(dt.Rows[i]["AMOUNT"].ToString()).ToString("#,0.######");
                        itemPlanGrid.Rows[i].Cells["PRICE"].Value = decimal.Parse(dt.Rows[i]["PRICE"].ToString()).ToString("#,0.######");
                        itemPlanGrid.Rows[i].Cells["TOTAL_MONEY"].Value = decimal.Parse(dt.Rows[i]["MONEY"].ToString()).ToString("#,0.######");
                        itemPlanGrid.Rows.Add();
                        halfLogic(itemPlanGrid);
                    }
                    //itemPlanGrid.Rows.Add();
                    // halfLogic(itemPlanGrid);
                }
                else
                {
                    MessageBox.Show("주문서 상세 항목을 불러오는 중 오류발생(dataTable is null)");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("주문서 상세 항목을 불러오는 중 오류발생(Exception)");
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                msg.ShowDialog();
            }


            //itemOutGrid.Rows[rowNum].Cells["O_LOT_NO"].Value = 
            //itemOutGrid.Rows[rowNum].Cells["O_LOT_SUB"].Value = 
            //itemOutGrid.Rows[rowNum].Cells["O_ITEM_CD"].Value = 
            //itemOutGrid.Rows[rowNum].Cells["O_ITEM_NM"].Value = 
            //itemOutGrid.Rows[rowNum].Cells["OUTPUT_AMT"].Value =
            //itemOutGrid.Rows[rowNum].Cells["O_SPEC"].Value = 
            //itemOutGrid.Rows[rowNum].Cells["PRICE"].Value = 
            //itemOutGrid.Rows[rowNum].Cells["O_UNIT_CD"].Value = 
            //itemOutGrid.Rows[rowNum].Cells["O_UNIT_NM"].Value = 
            //itemOutGrid.Rows[rowNum].Cells["OLD_OUT_AMT"].Value =
            //itemOutGrid.Rows[rowNum].Cells["TOTAL_MONEY"].Value =
            //itemOutGrid.Rows[rowNum].Cells["O_INPUT_DATE"].Value =
            //itemOutGrid.Rows[rowNum].Cells["O_INPUT_CD"].Value =
            //itemOutGrid.Rows[rowNum].Cells["O_CUST_CD"].Value = 
            //itemOutGrid.Rows[rowNum].Cells["O_TAX_CD"].Value = 
            //itemOutGrid.Rows[rowNum].Cells["O_LINK_CD"].Value = 
            //itemOutGrid.Rows[rowNum].Cells["O_INPUT_SEQ"].Value =
        }

        private void Jumun_detail_array(string jumun_date, string jumun_cd)
        {
            wnDm wDm = new wnDm();
            DataTable dt = new DataTable();
            try
            {
                dt = wDm.select_jumun_detail_list(jumun_date, jumun_cd);
                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //itemPlanGrid.Rows.Add();
                        bool isAlreadyOnTheGrid = false;
                        for (int j = 0; j < itemPlanGrid.Rows.Count; j++)
                        {
                            if (itemPlanGrid.Rows[j].Cells["ITEM_CD"].Value != null && itemPlanGrid.Rows[j].Cells["ITEM_CD"].Value.ToString().Equals(dt.Rows[i]["ITEM_CD"].ToString()))
                            {
                                itemPlanGrid.Rows[j].Cells["TOTAL_AMT"].Value = (decimal.Parse(itemPlanGrid.Rows[j].Cells["TOTAL_AMT"].Value.ToString()) + decimal.Parse(dt.Rows[i]["AMOUNT"].ToString())).ToString("#,0.######");
                                isAlreadyOnTheGrid = true;
                                break;
                            }
                        }
                        if (isAlreadyOnTheGrid) continue;
                        itemPlanGrid.Rows[itemPlanGrid.Rows.Count - 1].DefaultCellStyle.BackColor = Color.MistyRose;
                        itemPlanGrid.Rows[itemPlanGrid.Rows.Count - 1].DefaultCellStyle.SelectionBackColor = Color.MistyRose;
                        itemPlanGrid.Rows[itemPlanGrid.Rows.Count - 1].Cells["ITEM_CD"].Value = dt.Rows[i]["ITEM_CD"].ToString();
                        itemPlanGrid.Rows[itemPlanGrid.Rows.Count - 1].Cells["ITEM_NM"].Value = dt.Rows[i]["ITEM_NM"].ToString();
                        itemPlanGrid.Rows[itemPlanGrid.Rows.Count - 1].Cells["SPEC"].Value = dt.Rows[i]["SPEC"].ToString();
                        itemPlanGrid.Rows[itemPlanGrid.Rows.Count - 1].Cells["UNIT_CD"].Value = dt.Rows[i]["UNIT_CD"].ToString();
                        itemPlanGrid.Rows[itemPlanGrid.Rows.Count - 1].Cells["UNIT_NM"].Value = dt.Rows[i]["UNIT_NM"].ToString();
                        itemPlanGrid.Rows[itemPlanGrid.Rows.Count - 1].Cells["TOTAL_AMT"].Value = decimal.Parse(dt.Rows[i]["AMOUNT"].ToString()).ToString("#,0.######");
                        itemPlanGrid.Rows[itemPlanGrid.Rows.Count - 1].Cells["PRICE"].Value = decimal.Parse(dt.Rows[i]["PRICE"].ToString()).ToString("#,0.######");
                        itemPlanGrid.Rows[itemPlanGrid.Rows.Count - 1].Cells["TOTAL_MONEY"].Value = decimal.Parse(dt.Rows[i]["MONEY"].ToString()).ToString("#,0.######");
                        itemPlanGrid.Rows.Add();
                        halfLogic(itemPlanGrid);
                    }
                    //itemPlanGrid.Rows.Add();
                    //itemPlanGrid.Rows.Add();

                }
                else
                {
                    MessageBox.Show("주문서 상세 항목을 불러오는 중 오류발생(dataTable is null)");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("주문서 상세 항목을 불러오는 중 오류발생(Exception)");
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                msg.ShowDialog();
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

        private void planGrid_VisibleChanged(object sender, EventArgs e)
        {
            ComInfo.gridHeaderSet((DataGridView)sender);

        }

        private void itemPlanGrid_VisibleChanged(object sender, EventArgs e)
        {
            ComInfo.gridHeaderSet((DataGridView)sender);

        }

        private void itemHalfGrid_VisibleChanged(object sender, EventArgs e)
        {
            ComInfo.gridHeaderSet((DataGridView)sender);

        }

        private void req_date_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTimePicker dtpTemp = (DateTimePicker)sender;
                DateTime dtTemp = dtpTemp.Value;

                if (dtTemp.Date < txt_plan_date.Value.Date)
                {
                    MessageBox.Show("납품요구일은 입력일자보다 크거나 같아야합니다.");
                    dtpTemp.Text = txt_plan_date.Text;
                }
            }
            catch
            {

            }
        }
    }
}
