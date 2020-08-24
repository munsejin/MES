
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

namespace MES.H10_주문관리
{
    /// <summary>
    /// DB에 추가 
    ///장터지기 연동  에러나면 DB에 추가해주세요 

    //    ALTER TABLE [SM_FACTORY_002].[dbo].[F_ITEM_OUT]
    //ADD J_INPUT_DATE nVARCHAR(20)
    //    ALTER TABLE [SM_FACTORY_002].[dbo].[F_ITEM_OUT]
    //ADD [J_INPUT_CD] int
    //    ALTER TABLE [SM_FACTORY_002].[dbo].[F_ITEM_OUT_DETAIL]
    //ADD J_INPUT_SEQ int
    //    ALTER TABLE [SM_FACTORY_002].[dbo].[F_ITEM_OUT_DETAIL]
    //ADD J_INPUT_CD int
    // ALTER TABLE [SM_FACTORY_002].[dbo].[F_ITEM_OUT_DETAIL]
    //ADD J_INPUT_DATE int     




    ///A거래처에게 출고예정이였던 제품이 B거래처로 수정될수 있게 변경 

    /// </summary>
    public partial class frm주문등록 : Form
    {
        private wnGConstant wConst = new wnGConstant();
        private DataTable del_outGrid = new DataTable();
        wnDm wnDm = new wnDm();
        private bool bHeadCheck = false;
        private string old_cust_nm = "";
        string condition = "";

        public frm주문등록()
        {
            InitializeComponent();

            this.dgv주문등록.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellEndEdit);
            this.dgv주문등록.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grid_KeyDown);
            this.dgv주문등록.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grid_ColumnHeaderMouseClick);

            this.dgv주문등록.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.grid_RowsAdded);
            this.dgv주문등록.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.grid_RowsRemoved);
            this.dgv주문등록.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.grid_EditingControlShowing);

        }
        public static bool p_IsAuth = true;    // 열람권한
        public static bool p_Isrgstr = true;    //등록/수정 권한

        public static bool p_Isdel = true;    // 삭제 권한
        private void frm주문등록_Load(object sender, EventArgs e)
        {
               lbl_title.Tag = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[0] + "$" + wnDm.fn_TitleName(this.Name.ToString()).Split('$')[1]; lbl_title.Text = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[2];
               txt입력방식.Text = Common.p_HW;
               dtp스타트.Value = dtp엔드.Value.AddDays(-7);
               txt_end_date.Value = DateTime.Now;
               txt_start_date.Value = DateTime.Now.AddDays(-3);
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

            init_ComboBox();
            txt_start_date.Value = DateTime.Now.AddDays(-7);

            btnSrch.PerformClick();
               plan_list(planGrid, "where A.PLAN_DATE >= '" + dtp스타트.Text.ToString() + "' and  A.PLAN_DATE <= '" + dtp엔드.Text.ToString() + "'");
               resetSetting();
        }

        #region item out button logic

        private void btnNew_Click(object sender, EventArgs e)
        {
            resetSetting();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("선택하신 정보가 저장됩니다", "YesOrNo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (p_Isrgstr)
                {
                    saveLogic();
                    plan_list(planGrid, "where A.PLAN_DATE >= '" + dtp스타트.Text.ToString() + "' and  A.PLAN_DATE <= '" + dtp엔드.Text.ToString() + "'");
                }
                else
                {
                    MessageBox.Show("권한이 없습니다.");
                }
            }
            else
            {
            }

            btnSrch.PerformClick();
            
        }

        private void saveLogic()
        {
            try
            {
                if (txt_cust_cd.Text.ToString().Equals(""))
                {
                    MessageBox.Show("거래처를 선택하시기 바랍니다.");
                    return;
                }

                if (dgv주문등록.Rows.Count > 0)
                {
                    int cnt = 0;
                    int grid_cnt = dgv주문등록.Rows.Count;
                    for (int i = 0; i < grid_cnt; i++)
                    {
                        string txt_item_cd = (string)dgv주문등록.Rows[i - cnt].Cells["O_ITEM_CD"].Value;

                        if (txt_item_cd == "" || txt_item_cd == null)  //마지막 행에 원자재코드가 없을 경우 제거
                        {
                            dgv주문등록.Rows.RemoveAt(i - cnt);
                            cnt++;
                        }
                    }
                }

              

            //     string txt_ord_date
            //, string txt_ord_num
            //, string cmb_staff
            //, string cmb_stor
            //, string cmb_vat
            //, string cmb_delivery_staff
            //, string txt_comment
            //, string txt_cust_nm
            //, string txt_cust_cd
                if (lbl_plan_gbn.Text == "1")
                {
                    string plan_num = txt_plan_date.Text.ToString().Replace("-", "");
                    plan_num = plan_num.Substring(4, 4).ToString();

                    wnDm wDm = new wnDm();
                    int rsNum = wDm.insertOrdGrid(
                        txt_plan_date.Value.ToString().Substring(0,10)
                        ,txt_ord_num.Text.ToString()
                        ,txt입력방식.Text.ToString()
                            , cbo담당사원.SelectedValue.ToString()
                            , cmb_stor.SelectedValue.ToString()
                            , cbo부가세.SelectedValue.ToString()
                            , str계획일자
                            ,str계획번호                                         
                            , txt비고.Text.ToString()
                            ,txt_cust_nm.Text.ToString()
                            ,txt_cust_cd.Text.ToString()
                            ,dgv주문등록
                        );

                    if (rsNum == 0)
                    {
                        

                    

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
                    wnDm wDm = new wnDm();
                    int rsNum = wDm.updateOrdGrid(
                          txt_plan_date.Value.ToString().Substring(0, 10)
                        , txt_ord_num.Text.ToString()
                        , txt입력방식.Text.ToString()
                            , cbo담당사원.SelectedValue.ToString()
                            , cmb_stor.SelectedValue.ToString()
                            , cbo부가세.SelectedValue.ToString()
                            , cbo배송사원.SelectedValue.ToString()
                            , cbo전표상태.SelectedValue.ToString()
                            , txt비고.Text.ToString()
                            , txt_cust_nm.Text.ToString()
                            , txt_cust_cd.Text.ToString()
                            , dgv주문등록
                        );

                    if (rsNum == 0)
                    {
                        wnProcCon wDmProc = new wnProcCon();
                       

                        if (rsNum == -9)
                        {
                            wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                        }

                    
                     

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
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(e.Message+" - "+e.ToString()); msg.ShowDialog();
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("선택하신 정보가 삭제됩니다", "YesOrNo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                if (p_Isrgstr)
                {
                    output_del();


                }
                else
                {
                    MessageBox.Show("권한이 없습니다.");
                }
            }
            else
            {
            }



          
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
                txt_vat_cd.Text = frm.sVatCd.Trim();
                old_cust_nm = frm.sCode.Trim();
                item_out_detail("");
            }
            else
            {
                txt_cust_cd.Text = old_cust_nm;
            }

            frm.Dispose();
            frm = null;
            cmb_stor.Focus();
        }
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
                    Txtbtn[type].Click += new EventHandler(btnItemSrch_Click);

                    break;

                default:
                    break;
            }
            Txtbtn[type].Show();
        }
        String old_item_nm;
        private void btnItemSrch_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_move_Click(object sender, EventArgs e)
        {

           


          
        }

        private void btnSrch_Click(object sender, EventArgs e)
        {
            bind_등록자료(dgv주문LIST, "where A.ORD_DATE >= '" + txt_start_date.Value.ToString().Substring(0, 10) + "' and  A.ORD_DATE <= '" + txt_end_date.Value.ToString().Substring(0, 10) + "'");
            
        }

        #endregion item out button logic

        #region item out local logic

        private void init_ComboBox()
        {
            ComInfo comInfo = new ComInfo();
            string sqlQuery = "";

            //창고 
            cmb_stor.ValueMember = "코드";
            cmb_stor.DisplayMember = "명칭";
            sqlQuery = comInfo.queryStorage();
            wConst.ComboBox_Read_Blank(cmb_stor, sqlQuery);

            sqlQuery = "";

            cbo부가세.ValueMember = "코드";
            cbo부가세.DisplayMember = "명칭";
            sqlQuery = comInfo.queryCode("910");
            wConst.ComboBox_Read_Blank(cbo부가세, sqlQuery);


            sqlQuery = "";

            cbo담당사원.ValueMember = "코드";
            cbo담당사원.DisplayMember = "명칭";
            sqlQuery = comInfo.queryStaff();
            wConst.ComboBox_Read_Blank(cbo담당사원, sqlQuery);


            sqlQuery = "";

            cbo배송사원.ValueMember = "코드";
            cbo배송사원.DisplayMember = "명칭";
            sqlQuery = comInfo.queryStaff();
            wConst.ComboBox_Read_Blank(cbo배송사원, sqlQuery);


            cbo전표상태.ValueMember = "코드";
            cbo전표상태.DisplayMember = "명칭";
            sqlQuery = comInfo.queryCode("640");
            wConst.ComboBox_Read_Blank(cbo전표상태, sqlQuery);

            매출구분.DataSource = wnDm.매출구분();
            매출구분.ValueMember = "코드";
            매출구분.DisplayMember = "명칭";
           
        }

        private void item_out_detail(string condition)
        {
           

         
            
        }

        private void outputLogic()
        {

           
        }

        private void resetSetting()
        {
            lbl_plan_gbn.Text = "";
            txt_ord_num.Text = "";
         
            txt_plan_date.Value = DateTime.Now;
            txt_cust_cd.Text = "";
            txt_cust_nm.Text = "";
            cbo부가세.SelectedIndex = 1;
            cbo배송사원.SelectedIndex = 0;
            cbo담당사원.SelectedIndex = 0;
            cbo전표상태.SelectedIndex = 1;
            cmb_stor.SelectedIndex = 0;
            dgv주문등록.Rows.Clear();
            txt입력시간.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void output_list(DataGridView dgv, string condition)
        {
            
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            

                bind_등록자료(dgv주문LIST, "where A.ORD_DATE >= '" + txt_start_date.Value.ToString().Substring(0, 10) + "' and  A.ORD_DATE <= '" + txt_end_date.Value.ToString().Substring(0, 10) + "'");
            
        }





        private void tdOutGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void outputGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void out_detail(DataGridView dgv, DataGridViewCellEventArgs e)
        {
           
        }

        private void outputDetail2()
        {
           
        }
       

        private void output_del()
        {

            try
            {
                int rsNum = 2;
                wnDm wdm = new wnDm();
                rsNum = wdm.Delete_s_주문등록(txt_plan_date.Text, txt_ord_num.Text);

                if (rsNum == 0)
                {

                    resetSetting();
                  

                }
                else if (rsNum == 1)
                    MessageBox.Show("삭제에 실패하였습니다");
                else
                    MessageBox.Show("Exception 에러");
            }

            catch (Exception e2)
            {
                MessageBox.Show("시스템 에러: " + e2.Message.ToString());
            }
        }
        #endregion item out local logic


        #region grid control

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

        private void grid_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            conDataGridView grd = (conDataGridView)sender;

            for (int kk = 0; kk < grd.Rows.Count; kk++)
            {
                grd.Rows[kk].Cells[1].Value = (kk + 1).ToString();
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
            string name = dgv주문등록.CurrentCell.OwningColumn.Name;

            if (name == "TOTAL_AMT" || name == "PRICE" || name == "TOTAL_MONEY")
            {
                e.Control.KeyPress += new KeyPressEventHandler(txtCheckNumeric_KeyPress);
            }
            else
            {
                e.Control.KeyPress -= new KeyPressEventHandler(txtCheckNumeric_KeyPress);
            }
        }

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

        private void txtCheckNumeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComInfo.onlyNum(sender, e);
        }

        private void grid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            conDataGridView grd = (conDataGridView)sender;
            DataGridViewCell cell = grd[e.ColumnIndex, e.RowIndex];

            //cell.Style.BackColor = Color.White;

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

                wConst.f_Calc_Price(grd, e.RowIndex, "TOTAL_AMT", "PRICE");
            }
        }
        #endregion grid control


        private void btn_minus_Click(object sender, EventArgs e)
        {
            ///행삭제 했을때 선택삭제되는 데이터와 
            ///출고예정리스트와 비교하여 
            ///visible =true 해주어서   false였던 데이터를  다시생기는것처럼 보여주게한다 
            
           
            




           
        }

        private void plan_list(DataGridView dgv, string condition)
        {
            dgv.Rows.Clear();
            condition += "and isnull(D.ORD_DATE,'x')='x'";
            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = null;
                dt = wDm.fn_수주_List(condition);

               

                if (dt != null && dt.Rows.Count > 0)
                {
                   
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        
                            dgv.Rows.Add();
                    dgv.Rows[i].Cells["S_DATE"].Value = dt.Rows[i]["PLAN_DATE"].ToString();
                        dgv.Rows[i].Cells["S_SEQ"].Value = dt.Rows[i]["PLAN_CD"].ToString();
                        dgv.Rows[i].Cells["S_매출처"].Value = dt.Rows[i]["CUST_NM"].ToString();
                        dgv.Rows[i].Cells["S_납품일"].Value = dt.Rows[i]["DELIVER_REQ_DATE"].ToString();
                        dgv.Rows[i].Cells["S_비고"].Value = dt.Rows[i]["COMMENT"].ToString();
                        dgv.Rows[i].Cells["S_매출처코드"].Value = dt.Rows[i]["CUST_CD"].ToString();
                        dgv.Rows[i].Cells["S_계획번호"].Value = dt.Rows[i]["PLAN_NUM"].ToString();

                     
                            
                        
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
        }

        private void bind_등록자료(DataGridView dgv, string condition)
        {
            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = null;
                dt = wDm.fn_주문_List(condition);
                dgv.Rows.Clear();

                    //                
                    //A.ORD_DATE
                    //,A.ORD_NUM
                    //,A.ORD_INPUT
                    //,A.ORD_TIME
                    //,A.STAFF_CD
                    //,C.STAFF_NM
                    //,A.CUST_CD
                    //,B.CUST_NM
                    //,A.DELIVERY_CD
                    //,D.STAFF_NM
                    //,A.STORAGE_CD
                    //,f.STORAGE_NM
                    //,A.VAT_CD
                    //,G.S_CODE_NM as VAT_NM
                    //,A.COMMENT

                if (dt != null && dt.Rows.Count > 0)
                {
                    dgv.RowCount = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgv.Rows[i].Cells["ORD_주문일자"].Value = dt.Rows[i]["ORD_DATE"].ToString();
                        dgv.Rows[i].Cells["ORD_주문번호"].Value = dt.Rows[i]["ORD_NUM"].ToString();
                        dgv.Rows[i].Cells["ORD_입력방식"].Value = dt.Rows[i]["ORD_INPUT"].ToString();
                        dgv.Rows[i].Cells["ORD_주문시간"].Value = dt.Rows[i]["ORD_TIME"].ToString();
                        dgv.Rows[i].Cells["ORD_담당사원코드"].Value = dt.Rows[i]["STAFF_CD"].ToString();
                        dgv.Rows[i].Cells["ORD_담당사원"].Value = dt.Rows[i]["STAFF_NM"].ToString();
                        dgv.Rows[i].Cells["ORD_거래처코드"].Value = dt.Rows[i]["CUST_CD"].ToString();
                        dgv.Rows[i].Cells["ORD_거래처명"].Value = dt.Rows[i]["CUST_NM"].ToString();
                        dgv.Rows[i].Cells["ORD_배송사원코드"].Value = dt.Rows[i]["DELIVERY_CD"].ToString();
                        dgv.Rows[i].Cells["ORD_배송사원"].Value = dt.Rows[i]["DELIVERY_NM"].ToString();
                        dgv.Rows[i].Cells["ORD_창고코드"].Value = dt.Rows[i]["STORAGE_CD"].ToString();
                        dgv.Rows[i].Cells["ORD_창고"].Value = dt.Rows[i]["STORAGE_NM"].ToString();
                        dgv.Rows[i].Cells["ORD_부가세코드"].Value = dt.Rows[i]["VAT_CD"].ToString();
                        dgv.Rows[i].Cells["ORD_부가세"].Value = dt.Rows[i]["VAT_NM"].ToString();
                        dgv.Rows[i].Cells["ORD_비고"].Value = dt.Rows[i]["COMMENT"].ToString();
                        dgv.Rows[i].Cells["SALE_STATE"].Value = dt.Rows[i]["SALE_STATE"].ToString();
                      dgv.Rows[i].Cells["전표상태"].Value = dt.Rows[i]["SALE_STATE_NM"].ToString();
                        //SALE_STATE

                    }
                }
                else
                {
                    dgv.Rows.Clear();
                }
            }
            catch (Exception e)
            {
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(e.Message+" - "+e.ToString()); msg.ShowDialog();
            }
        }

        private void txt_cust_nm_TextChanged(object sender, EventArgs e)
        {

        }

        private void frm주문등록_Enter(object sender, EventArgs e)
        {
            plan_list(planGrid, "where A.PLAN_DATE >= '" + dtp스타트.Text.ToString() + "' and  A.PLAN_DATE <= '" + dtp엔드.Text.ToString() + "'");
        }

        private void btnSerch_Click(object sender, EventArgs e)
        {
          
        }

        private void btn수주검색_Click(object sender, EventArgs e)
        {
            plan_list(planGrid, "where A.PLAN_DATE >= '" + dtp스타트.Text.ToString() + "' and  A.PLAN_DATE <= '" + dtp엔드.Text.ToString() + "'");
        }

        private void planGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
            DataGridView dgv = sender as DataGridView;
            if (ComInfo.grdHeaderNoAction(e))
            {
                planDetail(planGrid, e);
               
            }

            planDetail2(e);
            lbl_plan_gbn.Text = "1";

        }

       

        private void planDetail2(DataGridViewCellEventArgs e)
        {
            wnDm wDm = new wnDm();
            DataTable dt = null;
            dgv주문등록.Rows.Clear();
            dt = wDm.fn_Plan_Detail_List("where A.PLAN_DATE = '" + str계획일자 + "' and A.PLAN_CD = '" + str계획번호 + "' ");
            try
            {
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

                    //itemPlanGrid.RowCount = itemChk;



                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgv주문등록.Rows.Add();
                        //dgv주문등록.Rows[i].Cells["P_PLAN_DATE"].Value = dt.Rows[i]["PLAN_DATE"].ToString();
                        //dgv주문등록.Rows[i].Cells["P_PLAN_CD"].Value = dt.Rows[i]["PLAN_CD"].ToString();
                        dgv주문등록.Rows[i].Cells["O_SPEC"].Value = dt.Rows[i]["SPEC"].ToString();
                        dgv주문등록.Rows[i].Cells["O_NO"].Value = dt.Rows[i]["SEQ"].ToString();
                        dgv주문등록.Rows[i].Cells["O_ITEM_CD"].Value = dt.Rows[i]["ITEM_CD"].ToString();
                        dgv주문등록.Rows[i].Cells["O_ITEM_NM"].Value = dt.Rows[i]["ITEM_NM"].ToString();
                        dgv주문등록.Rows[i].Cells["O_UNIT_CD"].Value = dt.Rows[i]["UNIT_CD"].ToString();
                        dgv주문등록.Rows[i].Cells["O_UNIT_NM"].Value = dt.Rows[i]["UNIT_NM"].ToString();
                        dgv주문등록.Rows[i].Cells["최종매출일"].Value = DateTime.Parse(planGrid.Rows[e.RowIndex].Cells["S_납품일"].Value.ToString());

                        if (dt.Rows[i]["WORK_YN"].ToString().Equals("Y"))
                        {
                            dgv주문등록.Rows[i].Cells["O_WORK_YN"].Value = true;
                        }
                        else
                        {
                            dgv주문등록.Rows[i].Cells["O_WORK_YN"].Value = false;
                        }

                        dgv주문등록.Rows[i].Cells["TOTAL_AMT"].Value = (decimal.Parse(dt.Rows[i]["TOTAL_AMT"].ToString())).ToString("#,0.######");
                        dgv주문등록.Rows[i].Cells["PRICE"].Value = (decimal.Parse(dt.Rows[i]["PRICE"].ToString())).ToString("#,0.######");
                        dgv주문등록.Rows[i].Cells["TOTAL_MONEY"].Value = (decimal.Parse(dt.Rows[i]["TOTAL_MONEY"].ToString())).ToString("#,0.######");

                    }

                    int j = 0;
                }
            }
            catch
            {

            }
              
        }
        private String str계획일자 = "";
        private String str계획번호 = "";
        private void planDetail(DataGridView dgv, DataGridViewCellEventArgs e)
        {
          
         
            //txt_plan_date.Enabled = false;
            str계획일자 = dgv.Rows[e.RowIndex].Cells["S_DATE"].Value.ToString();

            str계획번호 = dgv.Rows[e.RowIndex].Cells["S_SEQ"].Value.ToString();
            txt_cust_cd.Text = dgv.Rows[e.RowIndex].Cells["S_매출처코드"].Value.ToString();
            txt_cust_nm.Text = dgv.Rows[e.RowIndex].Cells["S_매출처"].Value.ToString();


            lbl_plan_gbn.Text = "";
          

          
          
            cbo부가세.SelectedIndex = 1;
            cbo배송사원.SelectedIndex = 0;
            cbo담당사원.SelectedIndex = 0;
            cbo전표상태.SelectedIndex = 0;
            cmb_stor.SelectedIndex = 0;
            txt입력시간.Text = DateTime.Now.ToString("HH:mm:ss");
            
        }

        private void dgv주문LIST_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnDelete.Enabled = true;
            dgv주문등록.Rows.Clear();
            if (e.RowIndex >= 0)
            {
                try
                {

                    lbl_plan_gbn.Text = "수정";
                    DataGridView dgv = sender as DataGridView;
         
                    txt_ord_num.Text = dgv.Rows[e.RowIndex].Cells["ORD_주문번호"].Value.ToString();
                    txt입력방식.Text = dgv.Rows[e.RowIndex].Cells["ORD_입력방식"].Value.ToString();
                    txt_plan_date.Value = DateTime.Parse(dgv.Rows[e.RowIndex].Cells["ORD_주문일자"].Value.ToString());
                    txt_cust_cd.Text = dgv.Rows[e.RowIndex].Cells["ORD_거래처코드"].Value.ToString();
                    txt_cust_nm.Text = dgv.Rows[e.RowIndex].Cells["ORD_거래처명"].Value.ToString();
                    cbo부가세.SelectedValue = dgv.Rows[e.RowIndex].Cells["ORD_부가세코드"].Value.ToString();
                    cbo배송사원.SelectedValue = dgv.Rows[e.RowIndex].Cells["ORD_배송사원코드"].Value.ToString();
                    cbo담당사원.SelectedValue = dgv.Rows[e.RowIndex].Cells["ORD_담당사원코드"].Value.ToString();
                    cbo전표상태.SelectedValue = dgv.Rows[e.RowIndex].Cells["SALE_STATE"].Value.ToString();
                    cmb_stor.SelectedValue = dgv.Rows[e.RowIndex].Cells["ORD_창고코드"].Value.ToString();
                    txt입력시간.Text = dgv.Rows[e.RowIndex].Cells["ORD_주문시간"].Value.ToString();
                }
                catch(Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                    Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                    msg.ShowDialog();
                }
                DataTable dt = wnDm.fn_주문항목_List(" where A.ORD_DATE='" + txt_plan_date.Value.ToString().Substring(0, 10) + "' and A.ORD_NUM='" + txt_ord_num.Text.ToString() + "'");
                try{
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dgv주문등록.Rows.Add();
                 //   dgv주문등록.Rows[i].Cells["P_PLAN_DATE"].Value = dt.Rows[i]["ORD_DATE"].ToString();
                  //  dgv주문등록.Rows[i].Cells["P_PLAN_CD"].Value = dt.Rows[i]["ORD_NUM"].ToString();
                        dgv주문등록.Rows[i].Cells["O_SPEC"].Value = dt.Rows[i]["SPEC"].ToString();
                    dgv주문등록.Rows[i].Cells["O_NO"].Value = dt.Rows[i]["ORD_SEQ"].ToString();
                    dgv주문등록.Rows[i].Cells["O_ITEM_CD"].Value = dt.Rows[i]["ITEM_CD"].ToString();
                    dgv주문등록.Rows[i].Cells["O_ITEM_NM"].Value = dt.Rows[i]["ITEM_NM"].ToString();
                    dgv주문등록.Rows[i].Cells["O_UNIT_CD"].Value = dt.Rows[i]["UNIT_CD"].ToString();
                    dgv주문등록.Rows[i].Cells["O_UNIT_NM"].Value = dt.Rows[i]["UNIT_NM"].ToString();
                    dgv주문등록.Rows[i].Cells["최종매출일"].Value = DateTime.Parse(dt.Rows[i]["LAST_DATE"].ToString());
                    dgv주문등록.Rows[i].Cells["비고"].Value = dt.Rows[i]["COMMENT"].ToString();
                    dgv주문등록.Rows[i].Cells["매출구분"].Value = dt.Rows[i]["SALE_GB"].ToString();

                   

                    dgv주문등록.Rows[i].Cells["TOTAL_AMT"].Value = (decimal.Parse(dt.Rows[i]["ORD_QTY"].ToString())).ToString("#,0.######");
                    dgv주문등록.Rows[i].Cells["PRICE"].Value = (decimal.Parse(dt.Rows[i]["ORD_PRICE"].ToString())).ToString("#,0.######");
                    dgv주문등록.Rows[i].Cells["TOTAL_MONEY"].Value = (decimal.Parse(dt.Rows[i]["ORD_AMT"].ToString())).ToString("#,0.######");

                }
                }
                 catch(Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                    Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                    msg.ShowDialog();
                }
            }
        }

        private void pnl_top_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
