using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MES.CLS;
using MES.Controls;
using System.Diagnostics;
using MES.Popup;

namespace MES.P20_ORD
{
    public partial class frm발주서등록 : Form
    {
        private wnGConstant wConst = new wnGConstant();
        private DataGridView del_orderGrid = new DataGridView();
        private string old_cust_nm = "";
        private ComInfo comInfo = new ComInfo();
        private DataTable adoPrt = new DataTable();
        private DataTable adoPrt2 = new DataTable();
        private DataTable dt_회사정보 = new DataTable();
        wnDm wnDm = new wnDm();
        private Popup.frmPrint readyPrt = new Popup.frmPrint();
        private Popup.frmPrint frmPrt;
        private String strCustEmail = "";
      
        private bool[] right = new bool[2];

        private string[] custLST;
        public frm발주서등록()
        {
            InitializeComponent();

            this.rmOrderGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellEndEdit);
            this.rmOrderGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grid_KeyDown);
            this.rmOrderGrid.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grid_ColumnHeaderMouseClick);
            this.rmOrderGrid.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.grid_RowsAdded);
            this.rmOrderGrid.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.grid_RowsRemoved);
            this.rmOrderGrid.CellValueChanged += new DataGridViewCellEventHandler(grid_CellValueChanged);
            this.rmOrderGrid.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.grid_ColumnWidthChanged);
            this.rmOrderGrid.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.grid_EditingControlShowing);
        }
        public static bool p_IsAuth = true;    // 열람권한
        public static bool p_Isrgstr = true;    //등록/수정 권한

        public static bool p_Isdel = true;    // 삭제 권한
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
                    Txtbtn[type].Click += new EventHandler(btn거래처검색);

                    break;
                case 1:
                    Txtbtn[type].Click += new EventHandler(btnCustSrch_Click);
                    break;
                default:
                    break;
            }
            Txtbtn[type].Show();
        }

        private void btn거래처검색(object sender, EventArgs e)
        {
            Popup.pop거래처검색 frm = new Popup.pop거래처검색("구매처");

            frm.sCustGbn = "2";
            frm.sCustNm = txt구매처.Text.ToString();
            frm.ShowDialog();

            if (frm.sCode != "")
            {
                txt거래처코드.Text = frm.sCode.Trim();
                txt구매처.Text = frm.sName.Trim();
                old_cust_nm = frm.sCode.Trim();
            }
            else
            {
                txt_cust_cd.Text = old_cust_nm;
            }

            frm.Dispose();
            frm = null;
           
        }
        private void frm발주서등록_Load(object sender, EventArgs e)
        {
               lbl_title.Tag = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[0] + "$" + wnDm.fn_TitleName(this.Name.ToString()).Split('$')[1]; lbl_title.Text = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[2];
               right = wConst.btnRight(lbl_title.Tag.ToString());

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
               addButton(txt구매처, 0); Debug.WriteLine(p_IsAuth);
               addButton(txt_cust_nm, 1);
               Debug.WriteLine(p_Isrgstr);
               Debug.WriteLine(p_Isdel);
            
            start_date.Text = DateTime.Today.AddMonths(-1).ToString("yyyy-MM-dd");

            orderGridAdd();

            init_ComboBox(); //combobox 세팅

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("and A.ORDER_DATE >= '" + start_date.Text.ToString() + "' and  A.ORDER_DATE <= '" + end_date.Text.ToString() + "'");

            string str = queryStr(sb.ToString());

            //order_list(orderGrid,str);

            del_orderGrid.AllowUserToAddRows = false;

            del_orderGrid.Columns.Add("ORDER_DATE", "ORDER_DATE");
            del_orderGrid.Columns.Add("ORDER_CD", "ORDER_CD");
            del_orderGrid.Columns.Add("SEQ", "SEQ");

            cmb_comp_yn.SelectedIndex = 2; //첫 로드시 거래처 검색 구분이 미완료로 되어 있어서 


            DataTable dt2 = new DataTable();
            dt2 = wnDm.fn_Cust_Name_List("where CUST_GUBUN = '2'");
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

        #region btn click

        private void btnNew_Click(object sender, EventArgs e)
        {
            resetSetting();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (right[0])
                save_logic();
            else
                MessageBox.Show("권한이없습니다.");
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (right[1])
                order_del();
            else
                MessageBox.Show("권한이없습니다.");
        }

        private void btnCustSrch_Click(object sender, EventArgs e)
        {
            Popup.pop거래처검색 frm = new Popup.pop거래처검색("구매처");

            frm.sCustGbn = "2";
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
            in_req_date.Focus();

        }

        private void btnSrch_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("and A.ORDER_DATE >= '" + start_date.Text.ToString() + "' and  A.ORDER_DATE <= '" + end_date.Text.ToString() + "'");
            if (txt구매처.Text!="")
            {
                sb.AppendLine("and A.CUST_CD  = '" + txt거래처코드.Text.ToString() + "'");
                
            }

            string str = queryStr(sb.ToString());
            order_list(orderGrid, str);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DialogResult msgOk = MessageBox.Show("발주서를 발행하시겠습니까?", "발행여부", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (msgOk == DialogResult.No)
            {
                return;
            }
            발주현황표출력();
            Debug.WriteLine(strCustEmail);
        }

        #endregion btn click

        public void 발주현황표출력()
        {
            try
            {
                string sValue = "" + txt_order_date.Text.Trim();
                string sValue2 = "" + txt_order_cd.Text.Trim();

                if (sValue == "")
                {
                    MessageBox.Show("출력할 자료가 없습니다."); 
                    return;
                }
                getOrderMain(sValue, sValue2);

                frmPrt = readyPrt;
                frmPrt.Show();
                frmPrt.BringToFront();
                frmPrt.prt_발주현황표(adoPrt, adoPrt2, dt_회사정보, sValue, sValue2, "발주서");
                frmPrt.email = strCustEmail;
            }
            catch (Exception ex){
wnLog.writeLog(wnLog.LOG_ERROR, ex.Message + " - " + ex.ToString());Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                msg.ShowDialog();
            }
        }

        private void getOrderMain(string sKey, string sKey2)
        {
            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = new DataTable();
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("where 1=1 ");
                sb.AppendLine(" and A.ORDER_DATE = '" + sKey + "' ");
                sb.AppendLine(" and A.ORDER_CD = '" + sKey2 + "' ");
                dt = wDm.fn_Order_List_forPrint(sb.ToString());

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
                        //dt.Rows[kk]["SEQ"] = (kk + 1); //숫자의 경우  문자면 .string : 계산된 값을 READ 한 테이블로 다시 전달한다 - 출력물 사용

                        adoPrt = dt.Copy();
                    }

                    DataTable dt2 = new DataTable();
                    dt2 = wDm.fn_Order_Detail_List(sb.ToString());

                    if (dt2 != null && dt2.Rows.Count > 0) 
                    {
                        for (int i = 0; i < dt2.Rows.Count; i++) 
                        {
                            adoPrt2 = dt2.Copy();
                        }
                    }
                }

                //-- 출력을 위한 테이블 --
                adoPrt = dt.Copy();
                //------------------------
                dt_회사정보 = wDm.fn_Saup_List(Common.p_saupNo);
             

            }
            catch (Exception ex){
wnLog.writeLog(wnLog.LOG_ERROR, ex.Message + " - " + ex.ToString());Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                msg.ShowDialog();
            }
        }

        private void resetSetting()
        {
            lbl_order_gbn.Text = "";
            btnDelete.Enabled = false;

            txt_order_date.Text = DateTime.Now.ToString("yyyy-MM-dd");
            txt_order_date.Enabled = true;
            txt_order_cd.Text = "";
            txt_cust_cd.Text = "";
            txt_cust_nm.Text = "";
            old_cust_nm = "";
            txt_comment.Text = "";
            chk_pur_yn.Checked = false;
            in_req_date.Text = DateTime.Now.ToString("yyyy-MM-dd");

            rmOrderGrid.Rows.Clear();
            orderGridAdd();
            del_orderGrid.Rows.Clear();
        }

        private void orderGridAdd() 
        {

                rmOrderGrid.Rows.Add();
                rmOrderGrid.Rows[rmOrderGrid.Rows.Count - 1].Cells["TOTAL_AMT"].Value = "0";
                rmOrderGrid.Rows[rmOrderGrid.Rows.Count - 1].Cells["PRICE"].Value = "0";
                rmOrderGrid.Rows[rmOrderGrid.Rows.Count - 1].Cells["TOTAL_MONEY"].Value = "0";
        
        }

        private void order_list(DataGridView dgv, string condition)
        {
            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = null;
                dt = wDm.fn_Order_List(condition);

                if (dt != null && dt.Rows.Count > 0)
                {
                    dgv.RowCount = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgv.Rows[i].Cells["ORDER_DATE"].Value = dt.Rows[i]["ORDER_DATE"].ToString();
                        dgv.Rows[i].Cells["O_일자번호"].Value = dt.Rows[i]["일자"].ToString();
                        dgv.Rows[i].Cells["ORDER_CD"].Value = dt.Rows[i]["ORDER_CD"].ToString();
                        dgv.Rows[i].Cells["CUST_CD"].Value = dt.Rows[i]["CUST_CD"].ToString();
                        dgv.Rows[i].Cells["CUST_NM"].Value = dt.Rows[i]["CUST_NM"].ToString();
                        dgv.Rows[i].Cells["CUST_EMAIL"].Value = dt.Rows[i]["CUST_EMAIL"].ToString();
                        dgv.Rows[i].Cells["RAW_MAT_CNT"].Value = dt.Rows[i]["RAW_MAT_CNT"].ToString();
                        dgv.Rows[i].Cells["O_원자재명"].Value = dt.Rows[i]["원자재명"].ToString();
                        dgv.Rows[i].Cells["COMPLETE_YN"].Value = dt.Rows[i]["COMPLETE_YN"].ToString();
                        dgv.Rows[i].Cells["INPUT_REQ_DATE"].Value = dt.Rows[i]["INPUT_REQ_DATE"].ToString();
                        dgv.Rows[i].Cells["COMMENT"].Value = dt.Rows[i]["COMMENT"].ToString();
                    }
                }
                else
                {
                    orderGrid.Rows.Clear();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("시스템 오류" + e.ToString());
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(e.Message + " - " + e.ToString());
                msg.ShowDialog();
            }
        }

        private void orderGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (ComInfo.grdHeaderNoAction(e))
                {
                    orderDetail(orderGrid, e);
                }
            }
        }

        private void orderDetail(DataGridView dgv, DataGridViewCellEventArgs e)
        {
            btnDelete.Enabled = true;
            lbl_order_gbn.Text = "1";
            txt_order_date.Enabled = false;
            txt_order_date.Text = dgv.Rows[e.RowIndex].Cells["ORDER_DATE"].Value.ToString();

            txt_order_cd.Text = dgv.Rows[e.RowIndex].Cells["ORDER_CD"].Value.ToString();
            txt_cust_cd.Text = dgv.Rows[e.RowIndex].Cells["CUST_CD"].Value.ToString();
            txt_cust_nm.Text = dgv.Rows[e.RowIndex].Cells["CUST_NM"].Value.ToString();
            in_req_date.Text = dgv.Rows[e.RowIndex].Cells["INPUT_REQ_DATE"].Value.ToString();

            txt_comment.Text = dgv.Rows[e.RowIndex].Cells["COMMENT"].Value.ToString();
            strCustEmail = dgv.Rows[e.RowIndex].Cells["CUST_EMAIL"].Value.ToString();
            

            if (dgv.Rows[e.RowIndex].Cells["COMPLETE_YN"].Value.ToString().Equals("Y"))
            {
                chk_pur_yn.Checked = true;
            }
            else
            {
                chk_pur_yn.Checked = false;
            }

            orderDetail2();
        }

        private void orderDetail2() 
        {
            wnDm wDm = new wnDm();
            DataTable dt = null;

            dt = wDm.fn_Order_Detail_List("where A.ORDER_DATE = '" + txt_order_date.Text.ToString() + "' and A.ORDER_CD = '" + txt_order_cd.Text.ToString() + "' ");

            this.rmOrderGrid.RowCount = dt.Rows.Count;
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //string t_amt = string.Format("{0:#.##}", 100.2);
                    //rmOrderGrid.Rows.Add();
                    rmOrderGrid.Rows[i].Cells["O_ORDER_DATE"].Value = dt.Rows[i]["ORDER_DATE"].ToString();
                    rmOrderGrid.Rows[i].Cells["O_ORDER_CD"].Value = dt.Rows[i]["ORDER_CD"].ToString();
                    rmOrderGrid.Rows[i].Cells["SEQ"].Value = dt.Rows[i]["SEQ"].ToString();
                    rmOrderGrid.Rows[i].Cells["SPEC"].Value = dt.Rows[i]["SPEC"].ToString();
                    rmOrderGrid.Rows[i].Cells["RAW_MAT_CD"].Value = dt.Rows[i]["RAW_MAT_CD"].ToString();
                    rmOrderGrid.Rows[i].Cells["RAW_MAT_NM"].Value = dt.Rows[i]["RAW_MAT_NM"].ToString();
                    rmOrderGrid.Rows[i].Cells["UNIT_CD"].Value = dt.Rows[i]["UNIT_CD"].ToString();
                    rmOrderGrid.Rows[i].Cells["UNIT_NM"].Value = dt.Rows[i]["UNIT_NM"].ToString();
                    rmOrderGrid.Rows[i].Cells["TOTAL_AMT"].Value = (decimal.Parse(dt.Rows[i]["TOTAL_AMT"].ToString())).ToString("#,0.######");
                    rmOrderGrid.Rows[i].Cells["PRICE"].Value = (decimal.Parse(dt.Rows[i]["PRICE"].ToString())).ToString("#,0.######");
                    rmOrderGrid.Rows[i].Cells["TOTAL_MONEY"].Value = (decimal.Parse(dt.Rows[i]["TOTAL_MONEY"].ToString())).ToString("#,0.######");
                    rmOrderGrid.Rows[i].Cells["비고"].Value = dt.Rows[i]["COMMENT"].ToString();

                   // rmOrderGrid.Rows[i].Cells["sign"].Value = Convert.ToBase64String((byte[])dt.Rows[i]["SIGN"]);            
                }
            }
            else
            {
               orderGridAdd(); //데이터가 없을 경우 빈 행 생성
            }
        }
        private void save_logic()
        {
            if (txt_cust_cd.Text.ToString().Equals(""))
            {
                MessageBox.Show("거래처를 선택하시기 바랍니다.");
                return;
            }

            if (rmOrderGrid.Rows.Count > 0)
            {
                int cnt = 0;
                int grid_cnt = rmOrderGrid.Rows.Count;
                for (int i = 0; i < grid_cnt; i++)
                {
                    string txt_item_cd = (string)rmOrderGrid.Rows[i - cnt].Cells["RAW_MAT_CD"].Value;

                    if (txt_item_cd == "" || txt_item_cd == null)  //마지막 행에 원자재코드가 없을 경우 제거
                    {
                        rmOrderGrid.Rows.RemoveAt(i - cnt);
                        cnt++;
                    }
                }
            }

            string pur_yn = comInfo.resultYn(chk_pur_yn);
            if (lbl_order_gbn.Text != "1" )
            {
                wnDm wDm = new wnDm();
                int rsNum = wDm.insertOrder(
                        txt_order_date.Text.ToString(),
                        txt_cust_cd.Text.ToString(),
                        in_req_date.Text.ToString(),
                        pur_yn,
                        txt_comment.Text.ToString(),
                        rmOrderGrid);

                if (rsNum == 0)
                {
                    resetSetting();

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("and A.ORDER_DATE >= '" + start_date.Text.ToString() + "' and  A.ORDER_DATE <= '" + end_date.Text.ToString() + "'");

                    string str = queryStr(sb.ToString());
                    order_list(orderGrid, str);

                    MessageBox.Show("성공적으로 등록하였습니다.");
                }
                else if (rsNum == 1)
                    MessageBox.Show("저장에 실패하였습니다");
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
                int rsNum = wDm.updateOrder(
                        txt_order_date.Text.ToString(),
                        txt_order_cd.Text.ToString(),
                        txt_cust_cd.Text.ToString(),
                        in_req_date.Text.ToString(),
                        txt_comment.Text.ToString(),
                        pur_yn,
                        rmOrderGrid,
                        del_orderGrid);

                if (rsNum == 0)
                {
                    del_orderGrid.Rows.Clear();
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("and A.ORDER_DATE >= '" + start_date.Text.ToString() + "' and  A.ORDER_DATE <= '" + end_date.Text.ToString() + "'");

                    string str = queryStr(sb.ToString());
                    order_list(orderGrid, str);

                    orderDetail2();
                    MessageBox.Show("성공적으로 수정하였습니다.");
                }
                else if (rsNum == 1)
                    MessageBox.Show("저장에 실패하였습니다");
                else
                    MessageBox.Show("Exception 에러");
            }
        }

        private void order_del()
        {
            ComInfo comInfo = new ComInfo();
            DialogResult msgOk = comInfo.deleteConfrim("발주서", txt_order_date.Text.ToString()+" - " + txt_order_cd.Text.ToString());

            if (msgOk == DialogResult.No)
            {
                return;
            }

            wnDm wDm = new wnDm();
            int rsNum = wDm.deleteOrder(txt_order_date.Text.ToString(), txt_order_cd.Text.ToString());
            if (rsNum == 0)
            {
                resetSetting();
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("and A.ORDER_DATE >= '" + start_date.Text.ToString() + "' and  A.ORDER_DATE <= '" + end_date.Text.ToString() + "'");

                string str = queryStr(sb.ToString());
                order_list(orderGrid, str);

                MessageBox.Show("성공적으로 삭제하였습니다.");
            }
            else if (rsNum == 1)
            {
                MessageBox.Show("삭제에 실패하였습니다.");
            }
        }


        #region multi row grid logic

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
            //grd.Rows[e.RowIndex].Cells[4].Style.BackColor = Color.WhiteSmoke;
            //grd.Rows[e.RowIndex].Cells[4].Style.SelectionBackColor = Color.Khaki;


            //wConst.init_RowText(grd, e.RowIndex);

            for (int kk = 0; kk < grd.Rows.Count; kk++)
            {
                grd.Rows[kk].Cells[1].Value = (kk + 1).ToString();
            }
        }

        private void grid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
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
            popupLogic(sender, e);
 
        }


        private void popupLogic(object sender, DataGridViewCellEventArgs e)
        {
            conDataGridView grd = (conDataGridView)sender;
            DataGridViewCell cell = grd[e.ColumnIndex, e.RowIndex];

            cell.Style.BackColor = Color.White;


            #region 공통 그리드 체크
            if (grd.Columns[e.ColumnIndex].ToolTipText.IndexOf("명칭") >= 0 && grd._KeyInput == "enter")
            {
                string rat_mat_nm = (string)grd.Rows[e.RowIndex].Cells["RAW_MAT_NM"].Value;
                wnDm wDm = new wnDm();
                DataTable dt = new DataTable();
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("where RAW_MAT_NM like '%" + rat_mat_nm + "%' ");
                 if (chk구매처.Checked==true)
                {
                       sb.AppendLine(" and cust_cd = '" + txt_cust_cd.Text + "' ");
                   
                }
                dt = wDm.fn_Raw_List(sb.ToString(), "1");
               
                if (dt.Rows.Count > 1)
                { //row가 2줄이 넘을 경우 팝업으로 넘어간다.

                    wConst.call_pop_raw_mat(grd, dt, e.RowIndex, rat_mat_nm, 2, txt_cust_cd.Text);
                    //orderGridAdd();
                }
                else if (dt.Rows.Count == 1) //row가 1일 경우 해당 row에 값을 자동 입력한다.
                {

                    grd.Rows[e.RowIndex].Cells["RAW_MAT_CD"].Value = dt.Rows[0]["RAW_MAT_CD"].ToString();
                    grd.Rows[e.RowIndex].Cells["RAW_MAT_NM"].Value = dt.Rows[0]["RAW_MAT_NM"].ToString();
                    grd.Rows[e.RowIndex].Cells["OLD_RAW_MAT_NM"].Value = dt.Rows[0]["RAW_MAT_NM"].ToString();
                    grd.Rows[e.RowIndex].Cells["SPEC"].Value = dt.Rows[0]["SPEC"].ToString();
                    grd.Rows[e.RowIndex].Cells["UNIT_CD"].Value = dt.Rows[0]["INPUT_UNIT"].ToString();
                    grd.Rows[e.RowIndex].Cells["UNIT_NM"].Value = dt.Rows[0]["INPUT_UNIT_NM"].ToString();
                    grd.Rows[e.RowIndex].Cells["PRICE"].Value = dt.Rows[0]["INPUT_PRICE"].ToString();
                    if (rmOrderGrid.Rows[rmOrderGrid.Rows.Count - 1].Cells[2].Value != null)
                    {
                        orderGridAdd();
                    }
                }
                else
                { //row가 없는 경우
                    MessageBox.Show("데이터가 없습니다.");
                    rmOrderGrid.Rows.RemoveAt(rmOrderGrid.SelectedRows[0].Index);
                    rmOrderGrid.CurrentCell = rmOrderGrid[2, rmOrderGrid.Rows.Count];

                    //minus_logic(rmOrderGrid);
                }

                wConst.f_Calc_Price(grd, e.RowIndex, "TOTAL_AMT", "PRICE");
            }

            if (grd.Columns[e.ColumnIndex].ToolTipText.IndexOf("수량") >= 0
                || grd.Columns[e.ColumnIndex].ToolTipText.IndexOf("단가") >= 0
                || grd.Columns[e.ColumnIndex].ToolTipText.IndexOf("금액") >= 0)
            {

                string total_amt = (string)grd.Rows[e.RowIndex].Cells["TOTAL_AMT"].Value;
                string input_price = (string)grd.Rows[e.RowIndex].Cells["PRICE"].Value;

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


                if (input_price != null)
                {
                    input_price = input_price.ToString().Replace(" ", "");
                    if (input_price == "")
                    {
                        grd.Rows[e.RowIndex].Cells["PRICE"].Value = "0";
                    }
                }
                else
                {
                    grd.Rows[e.RowIndex].Cells["PRICE"].Value = "0";
                }

                wConst.f_Calc_Price(grd, e.RowIndex, "TOTAL_AMT", "PRICE");
            }
            #endregion 공통 그리드 체크

            //string sSearchTxt = "" + (string)grd.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
        }

        private void grid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            string name = rmOrderGrid.CurrentCell.OwningColumn.Name;

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

        #endregion multi row grid logic

        private void btn_plus_Click(object sender, EventArgs e)
        {
            orderGridAdd();
        }

        private void btn_minus_Click(object sender, EventArgs e)
        {
            minus_logic(rmOrderGrid);
        }

        private void minus_logic(conDataGridView dgv)
        {
            if (dgv.Rows.Count > 1)
            {
                if ((string)dgv.SelectedRows[0].Cells["SEQ"].Value != "" && dgv.SelectedRows[0].Cells["SEQ"].Value != null)
                {
                    del_orderGrid.Rows.Add();

                    del_orderGrid.Rows[del_orderGrid.Rows.Count - 1].Cells["ORDER_DATE"].Value = txt_order_date.Text.ToString();
                    del_orderGrid.Rows[del_orderGrid.Rows.Count - 1].Cells["ORDER_CD"].Value = txt_order_cd.Text.ToString();
                    del_orderGrid.Rows[del_orderGrid.Rows.Count - 1].Cells["SEQ"].Value = dgv.SelectedRows[0].Cells["SEQ"].Value;
                    
                }

                dgv.Rows.RemoveAt(dgv.SelectedRows[0].Index);
                dgv.CurrentCell = dgv[2, dgv.Rows.Count - 1];
            }
        }

        private void init_ComboBox()
        {
            string sqlQuery = "";

            cmb_comp_yn.ValueMember = "코드";
            cmb_comp_yn.DisplayMember = "명칭";
            sqlQuery = comInfo.queryCompYnAll();
            wConst.ComboBox_Read_NoBlank(cmb_comp_yn, sqlQuery);
        }

        private string queryStr(string condition) 
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("where 1=1 ");
            if (!cmb_comp_yn.SelectedValue.ToString().Equals("0"))
            {
                sb.AppendLine(" and A.COMPLETE_YN = '" + cmb_comp_yn.SelectedValue.ToString() + "' ");
            }
            sb.AppendLine(condition);
            
            return sb.ToString();
        }
               

        private void clear_Click(object sender, EventArgs e)
        {
            rmOrderGrid.Rows.Clear();
        }

        private void frm발주서등록_Enter(object sender, EventArgs e)
        {
            btnSrch.PerformClick();
        }

        private void btnDate_Click(object sender, EventArgs e)
        {
            Popup.frm일정관리 일정관리 = new Popup.frm일정관리(in_req_date.Value.ToString());
            일정관리.ShowDialog();
        }

        private void rmOrderGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                popupLogic(sender, e);
            }
        }

        private void rmOrderGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                conDataGridView grd = (conDataGridView)sender;
                DataGridViewCell cell = grd[e.ColumnIndex, e.RowIndex];
                var senderGrid = (DataGridView)sender;
                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                    e.RowIndex >= 0 && senderGrid.Columns[e.ColumnIndex].Name.Equals("SRCH_BTN"))
                {
                    string rat_mat_nm = (string)grd.Rows[e.RowIndex].Cells["RAW_MAT_NM"].Value;
                    wnDm wDm = new wnDm();
                    DataTable dt = new DataTable();
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("where RAW_MAT_NM like '%" + rat_mat_nm + "%' ");
                    if (chk구매처.Checked == true)
                    {
                        sb.AppendLine(" and cust_cd = '" + txt_cust_cd.Text + "' ");

                    }
                    dt = wDm.fn_Raw_List(sb.ToString(), "1");

                    if (dt.Rows.Count > 1)
                    { //row가 2줄이 넘을 경우 팝업으로 넘어간다.

                        wConst.call_pop_raw_mat(grd, dt, e.RowIndex, rat_mat_nm, 2, txt_cust_cd.Text);
                        //orderGridAdd();
                    }
                    else if (dt.Rows.Count == 1) //row가 1일 경우 해당 row에 값을 자동 입력한다.
                    {

                        grd.Rows[e.RowIndex].Cells["RAW_MAT_CD"].Value = dt.Rows[0]["RAW_MAT_CD"].ToString();
                        grd.Rows[e.RowIndex].Cells["RAW_MAT_NM"].Value = dt.Rows[0]["RAW_MAT_NM"].ToString();
                        grd.Rows[e.RowIndex].Cells["OLD_RAW_MAT_NM"].Value = dt.Rows[0]["RAW_MAT_NM"].ToString();
                        grd.Rows[e.RowIndex].Cells["SPEC"].Value = dt.Rows[0]["SPEC"].ToString();
                        grd.Rows[e.RowIndex].Cells["UNIT_CD"].Value = dt.Rows[0]["INPUT_UNIT"].ToString();
                        grd.Rows[e.RowIndex].Cells["UNIT_NM"].Value = dt.Rows[0]["INPUT_UNIT_NM"].ToString();
                        grd.Rows[e.RowIndex].Cells["PRICE"].Value = dt.Rows[0]["INPUT_PRICE"].ToString();
                        if (grd.Rows[grd.Rows.Count - 1].Cells[2].Value != null)
                        {
                            orderGridAdd();
                        }
                    }
                    else
                    { //row가 없는 경우
                        MessageBox.Show("데이터가 없습니다.");
                        rmOrderGrid.Rows.RemoveAt(rmOrderGrid.SelectedRows[0].Index);
                        //rmOrderGrid.CurrentCell = rmOrderGrid[2, rmOrderGrid.Rows.Count];

                        //minus_logic(rmOrderGrid);
                        return;
                    }
                    wConst.f_Calc_Price(grd, e.RowIndex, "TOTAL_AMT", "PRICE");


                }

                if (grd.Columns[e.ColumnIndex].ToolTipText.IndexOf("수량") >= 0
                    || grd.Columns[e.ColumnIndex].ToolTipText.IndexOf("단가") >= 0
                    || grd.Columns[e.ColumnIndex].ToolTipText.IndexOf("금액") >= 0)
                {

                    string total_amt = (string)grd.Rows[e.RowIndex].Cells["TOTAL_AMT"].Value;
                    string input_price = (string)grd.Rows[e.RowIndex].Cells["PRICE"].Value;

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


                    if (input_price != null)
                    {
                        input_price = input_price.ToString().Replace(" ", "");
                        if (input_price == "")
                        {
                            grd.Rows[e.RowIndex].Cells["PRICE"].Value = "0";
                        }
                    }
                    else
                    {
                        grd.Rows[e.RowIndex].Cells["PRICE"].Value = "0";
                    }

                    wConst.f_Calc_Price(grd, e.RowIndex, "TOTAL_AMT", "PRICE");
                }
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

        private void orderGrid_VisibleChanged(object sender, EventArgs e)
        {
            ComInfo.gridHeaderSet((DataGridView)sender);

        }

        private void rmOrderGrid_VisibleChanged(object sender, EventArgs e)
        {
            ComInfo.gridHeaderSet((DataGridView)sender);

        }

        private void in_req_date_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTimePicker dtpTemp = (DateTimePicker)sender;
                DateTime dtTemp = dtpTemp.Value;

                if (dtTemp.Date < txt_order_date.Value.Date)
                {
                    MessageBox.Show("입고 요청일은 구매일자보다 크거나 같아야합니다.");
                    dtpTemp.Text = txt_order_date.Text;
                }
            }
            catch
            {

            }
        }
    }
}
