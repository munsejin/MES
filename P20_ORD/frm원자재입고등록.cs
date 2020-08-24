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
using MES.P50_QUA;
using System.Collections;



namespace MES.P20_ORD
{
    public partial class frm원자재입고등록 : Form
    {
        private wnGConstant wConst = new wnGConstant();
        private DataGridView del_inputGrid = new DataGridView();
        private DateTimePicker dtp = new DateTimePicker();
        private Rectangle _Retangle;
        wnDm wnDm = new wnDm();
        private string old_cust_nm = "";
        private bool bHeadCheck = false;
        private ComInfo comInfo = new ComInfo();
        private string[] custLST;
        frm원자재수입검사 frm = new frm원자재수입검사();
        private bool[] right = new bool[2];
        private bool is_give_inputed = false;
        public bool is_open_from_stock_page = false;
        public string input_date_from_stock_page = "";
        public string input_cd_from_stock_page = "";

        private frm원자재수입검사 frm_chk;
        Hashtable hash = new Hashtable();

        public frm원자재입고등록()
        {
            InitializeComponent();

            this.inputRmGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellEndEdit);
            this.inputRmGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grid_KeyDown);
            this.inputRmGrid.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grid_ColumnHeaderMouseClick);
            this.inputRmGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellDoubleClick);

            this.inputRmGrid.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.grid_RowsAdded);
            this.inputRmGrid.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.grid_RowsRemoved);
            this.inputRmGrid.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.grid_EditingControlShowing);

            this.inputRmGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellClick);
            this.inputRmGrid.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.grid_ColumnWidthChanged);
            this.inputRmGrid.Scroll += new System.Windows.Forms.ScrollEventHandler(this.grid_scroll);

            this.inputRmGrid.Controls.Add(dtp);
            dtp.Visible = false;
            dtp.Format = DateTimePickerFormat.Custom;
            dtp.TextChanged += new EventHandler(dtp_TextChange);
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
                    Txtbtn[type].Click += new EventHandler(btnCustSrch_Click);

                    break;
                case 1:
                    Txtbtn[type].Click += new EventHandler(btnRAWSrch_Click);

                    break;

                default:
                    break;
            }
            Txtbtn[type].Show();
        }

        private void btnRAWSrch_Click(object sender, EventArgs e)
        {
            Popup.pop발주원자재검색 frm = new Popup.pop발주원자재검색();
           
            //frm.sUsedYN = sUsedYN;
            frm.s자재입고 = "1";

  
    
            frm.ShowDialog();
            txt원자재cd.Text = frm.sRetCode;
            txt원자재.Text = frm.sRetNM;
        }
        private void frm원자재입고등록_Load(object sender, EventArgs e)
        {
               lbl_title.Tag = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[0] + "$" + wnDm.fn_TitleName(this.Name.ToString()).Split('$')[1]; lbl_title.Text = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[2];
               right = wConst.btnRight(lbl_title.Tag.ToString());

               addButton(txt원자재, 1);
  
            input_list(tdInputGrid, "where convert(varchar(10), A.INTIME, 120) = convert(varchar(10), getDate(), 120) ");
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
            n_in_ord_grid.Columns["CHK"].ReadOnly = false;

            //for (int i = 0; i < n_in_ord_grid.ColumnCount; i++) {
            //    n_in_ord_grid.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //}

            tab_input.TabPages.Remove(tabPage2);

            del_inputGrid.AllowUserToAddRows = false;

            del_inputGrid.Columns.Add("INPUT_DATE", "INPUT_DATE");
            del_inputGrid.Columns.Add("INPUT_CD", "INPUT_CD");
            del_inputGrid.Columns.Add("SEQ", "SEQ");
            del_inputGrid.Columns.Add("ORDER_DATE", "ORDER_SEQ");
            del_inputGrid.Columns.Add("ORDER_CD", "ORDER_CD");
            del_inputGrid.Columns.Add("ORDER_SEQ", "ORDER_SEQ");
            del_inputGrid.Columns.Add("RAW_MAT_CD", "RAW_MAT_CD");
            del_inputGrid.Columns.Add("OLD_TOTAL_AMT", "OLD_TOTAL_AMT");

            dtpStart.Value = DateTime.Now.AddDays(-7);
            dtpEnd.Value = DateTime.Now;
            ni_detail();


            string sqlQuery = "";

            STORAGE_CD.ValueMember = "코드";
            STORAGE_CD.DisplayMember = "명칭";
            sqlQuery = comInfo.queryStorage();
            wConst.ComboBox_Read_Blank(STORAGE_CD, sqlQuery);

            cmb_give_gubun.ValueMember = "코드";
            cmb_give_gubun.DisplayMember = "명칭";
            sqlQuery = comInfo.querySooGubun();
            wConst.ComboBox_Read_Blank(cmb_give_gubun, sqlQuery);

            DataTable dt2 = new DataTable();
            dt2 = wnDm.fn_Cust_Name_List("where CUST_GUBUN = '2'");
            custLST = new string[dt2.Rows.Count];
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                custLST[i] = dt2.Rows[i]["CUST_NM"].ToString();
            }
            var source = new AutoCompleteStringCollection();
            //source.AddRange(custLST);
            //txt_cust_nm.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //txt_cust_nm.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //txt_cust_nm.AutoCompleteCustomSource = source;


            if (is_open_from_stock_page)
            {
                input_list(inputGrid, "where A.INPUT_DATE >= '" + input_date_from_stock_page + "' and  A.INPUT_DATE <= '" + input_date_from_stock_page + "'");

                for (int i = 0; i < inputGrid.Rows.Count; i++)
                {
                    if (inputGrid.Rows[i].Cells["INPUT_DATE"].Value.ToString().Equals(input_date_from_stock_page)
                        && inputGrid.Rows[i].Cells["INPUT_CD"].Value.ToString().Equals(input_cd_from_stock_page))
                    {
                        input_detail(inputGrid, i);
                        break;
                    }
                }
            }

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
                inputLogic();
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
                input_del();
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

        private void btnSrch_Click(object sender, EventArgs e)
        {
            input_list(inputGrid, "where A.INPUT_DATE >= '" + start_date.Text.ToString() + "' and  A.INPUT_DATE <= '" + end_date.Text.ToString() + "'");
             ni_detail();
        }

        String str발주일자 = "";
        String str발주번호 = "";
        String str발주거래처 = "";
        private void btn_move_Click(object sender, EventArgs e)
        {  
            

            if (n_in_ord_grid.Rows.Count > 0)
            {
                int chk = 0;
                for (int i = 0; i < n_in_ord_grid.Rows.Count; i++)
                {
                    if ((bool)n_in_ord_grid.Rows[i].Cells["CHK"].Value == true)
                    {
                        for (int j = 0; j < inputRmGrid.Rows.Count; j++) 
                        {
                            if ((string)n_in_ord_grid.Rows[i].Cells["NI_ORDER_DATE"].Value == (string)inputRmGrid.Rows[j].Cells["ORDER_DATE"].Value
                                && (string)n_in_ord_grid.Rows[i].Cells["NI_ORDER_CD"].Value == (string)inputRmGrid.Rows[j].Cells["ORDER_CD"].Value
                                && (string)n_in_ord_grid.Rows[i].Cells["NI_SEQ"].Value == (string)inputRmGrid.Rows[j].Cells["ORDER_SEQ"].Value) 
                            {
                                MessageBox.Show("해당 발주내용의 원자재가 이미 등록되어있습니다.");
                                
                                return;
                            }
                        }

                        for (int k = 0; k < del_inputGrid.Rows.Count; k++)
                        {
                            if ((string)n_in_ord_grid.Rows[i].Cells["NI_ORDER_DATE"].Value == (string)del_inputGrid.Rows[k].Cells["ORDER_DATE"].Value
                                && (string)n_in_ord_grid.Rows[i].Cells["NI_ORDER_CD"].Value == (string)del_inputGrid.Rows[k].Cells["ORDER_CD"].Value
                                && (string)n_in_ord_grid.Rows[i].Cells["NI_SEQ"].Value == (string)del_inputGrid.Rows[k].Cells["ORDER_SEQ"].Value)
                            {
                                MessageBox.Show("해당 발주내용의 삭제데이터가 있어 등록이 불가능합니다.");
                                return;
                            }
                        }
                        if (txt_cust_nm.Text != "")
                        {
                            if (txt_cust_nm.Text!=n_in_ord_grid.Rows[i].Cells["CUST_NM2"].Value.ToString() )
                            {
                                MessageBox.Show("다른거래처는 등록할수 없습니다.");
                                return;
                                
                            } 
                        }
       
                            
                        
                        n_in_ord_grid.Rows[i].Visible = false;
                        n_in_ord_grid.Rows[i].Cells["CHK"].Value = false;
                        inputRmGrid.Rows.Add();

           

                        int rowNum = inputRmGrid.Rows.Count-1;
                        inputRmGrid.Rows[rowNum].Cells["ORDER_DATE"].Value = n_in_ord_grid.Rows[i].Cells["NI_ORDER_DATE"].Value;
                        inputRmGrid.Rows[rowNum].Cells["ORDER_CD"].Value = n_in_ord_grid.Rows[i].Cells["NI_ORDER_CD"].Value;
                        inputRmGrid.Rows[rowNum].Cells["ORDER_SEQ"].Value = n_in_ord_grid.Rows[i].Cells["NI_SEQ"].Value;
                        inputRmGrid.Rows[rowNum].Cells["RAW_MAT_NM"].Value = n_in_ord_grid.Rows[i].Cells["NI_RAW_MAT_NM"].Value;
                        inputRmGrid.Rows[rowNum].Cells["RAW_MAT_CD"].Value = n_in_ord_grid.Rows[i].Cells["NI_RAW_MAT_CD"].Value;
                        inputRmGrid.Rows[rowNum].Cells["SPEC"].Value = n_in_ord_grid.Rows[i].Cells["NI_SPEC"].Value;
                        inputRmGrid.Rows[rowNum].Cells["UNIT_CD"].Value = n_in_ord_grid.Rows[i].Cells["NI_UNIT_CD"].Value;
                        inputRmGrid.Rows[rowNum].Cells["UNIT_NM"].Value = n_in_ord_grid.Rows[i].Cells["NI_UNIT_NM"].Value;
                        inputRmGrid.Rows[rowNum].Cells["RAW_MAT_GUBUN"].Value = n_in_ord_grid.Rows[i].Cells["NI_RAW_MAT_GUBUN"].Value;
                        inputRmGrid.Rows[rowNum].Cells["RAW_MAT_GUBUN_NM"].Value = n_in_ord_grid.Rows[i].Cells["NI_RAW_MAT_GUBUN_NM"].Value;
                        inputRmGrid.Rows[rowNum].Cells["TOTAL_AMT"].Value = n_in_ord_grid.Rows[i].Cells["NO_INPUT_AMT"].Value;
                        inputRmGrid.Rows[rowNum].Cells["OLD_TOTAL_AMT"].Value = n_in_ord_grid.Rows[i].Cells["NO_INPUT_AMT"].Value;
                        inputRmGrid.Rows[rowNum].Cells["PRICE"].Value = n_in_ord_grid.Rows[i].Cells["NI_PRICE"].Value;
                        inputRmGrid.Rows[rowNum].Cells["TOTAL_MONEY"].Value = n_in_ord_grid.Rows[i].Cells["NI_TOTAL_MONEY"].Value;
                        inputRmGrid.Rows[rowNum].Cells["CHECK_YN"].Value = n_in_ord_grid.Rows[i].Cells["O검사여부"].Value;
                        inputRmGrid.Rows[rowNum].Cells["TAX_CD"].Value = n_in_ord_grid.Rows[i].Cells["B_TAX_CD"].Value;

                        if (n_in_ord_grid.Rows[i].Cells["CUST_NM2"].Value != null && !n_in_ord_grid.Rows[i].Cells["CUST_NM2"].Value.ToString().Equals(""))
                        {
                            txt_cust_nm.Text = n_in_ord_grid.Rows[i].Cells["CUST_NM2"].Value.ToString();
                            txt_cust_cd.Text = n_in_ord_grid.Rows[i].Cells["CUST_CD2"].Value.ToString();
                            txt_vat_cd.Text = n_in_ord_grid.Rows[i].Cells["B_VAT_CD"].Value.ToString();
                        }

                        inputRmGrid.Rows[rowNum].Cells["CUST_NM3"].Value = n_in_ord_grid.Rows[i].Cells["CUST_NM2"].Value;
                        inputRmGrid.Rows[rowNum].Cells["CUST_CD3"].Value = n_in_ord_grid.Rows[i].Cells["CUST_CD2"].Value;
                        try
                        {
                            inputRmGrid.Rows[rowNum].Cells["STORAGE_CD"].Value = n_in_ord_grid.Rows[i].Cells["R_STORAGE_CD"].Value.ToString();
                        }
                        catch
                        {
                            inputRmGrid.Rows[rowNum].Cells["STORAGE_CD"].Value = "";
                        }
                        chk = 1;
                        wConst.f_Calc_Price(inputRmGrid, rowNum, "TOTAL_AMT", "PRICE", "TOTAL_MONEY", "SUPPLY_MONEY", "TAX_MONEY", "ALL_TOTAL_MONEY", txt_vat_cd.Text, inputRmGrid.Rows[rowNum].Cells["TAX_CD"].Value.ToString());

                        wConst.f_Calc_SalesPrice(txt_supply_money
                                            , txt_tax_money
                                            , txt_total_money
                                            , txt_vat_cd.Text
                                            , txt_no_tax_money
                                            , txt_yes_tax_money
                                            , txt_yesno_money
                                            , inputRmGrid
                                            , "SUPPLY_MONEY"
                                            , "TAX_MONEY"
                                            , "ALL_TOTAL_MONEY"
                                            , "TAX_CD"
                                            , false
                                            , ""
                                            );
                    }
                }
                if (chk == 0) 
                {
                    MessageBox.Show("발주서의 원자재를 선택하시기 바랍니다.");
                }
            }
            else 
            {
                MessageBox.Show("발주서 데이터가 없습니다.");
            }
        }

        private void btnCustSrch_Click(object sender, EventArgs e)
        {
            Popup.pop거래처검색 frm = new Popup.pop거래처검색("구매처");
           
            frm.sCustGbn = "2";
            frm.s자재입고 = "1";
            frm.sCustNm = txt_cust_nm.Text.ToString();
            frm.ShowDialog();

            /*거래처 선택 시*/
            if (frm.sCode != "")
            {
                n_in_ord_grid.Rows.Clear();
                //inputRmGrid.Rows.Clear();
               // inputRmGrid.Rows.Add();
               // inputRmGrid.Rows[inputRmGrid.Rows.Count - 1].Cells["LOC_CD"].Value = "선택";
                txt_cust_cd.Text = frm.sCode.Trim();
                txt_cust_nm.Text = frm.sName.Trim();
                txt_vat_cd.Text = frm.sVatCd.Trim();
                old_cust_nm = frm.sCode.Trim();
                ni_detail();
                in_grid_detail();
            }
            else
            {
                txt_cust_cd.Text = old_cust_nm;
            }

            frm.Dispose();
            frm = null;
        }

        private void btn_minus_Click(object sender, EventArgs e)
        {
            minus_logic(inputRmGrid);
        }

        #endregion button logic

        #region input logic
        private void resetSetting()
        {
            lbl_input_gbn.Text = "";
            btnDelete.Enabled = false;

            txt_input_date.Text = DateTime.Now.ToString("yyyy-MM-dd");
            txt_input_date.Enabled = true;
            txt_input_cd.Text = "";
            txt_cust_cd.Text = "";
            txt_cust_nm.Text = "";
            old_cust_nm = "";
            txt_comment.Text = "";
            txt_vat_cd.Text = "";

            txt_supply_money.Text = "";
            txt_tax_money.Text = "";
            txt_total_money.Text = "";

            cmb_give_gubun.SelectedIndex = 0;
            txt_yes_tax_money.Text = "0";
            txt_no_tax_money.Text = "0";
            txt_yesno_money.Text = "0";

            inputRmGrid.Rows.Clear();
            n_in_ord_grid.Rows.Clear();
            ni_detail();
            in_ord_gird.Rows.Clear();
            del_inputGrid.Rows.Clear();

            dtp.Visible = false;
            //orderGridAdd();
            //del_orderGrid.Rows.Clear();
        }

        private void inputLogic() 
        {

            if (txt_cust_cd.Text.ToString().Equals(""))
            {
                MessageBox.Show("거래처를 선택하시기 바랍니다.");
                return;
            }

            if (inputRmGrid.Rows.Count == 0) 
            {
                MessageBox.Show("입고에 들어갈 원자재가 1개 이상 있어야 합니다.");
                return;
            }

            int cnt = 0;
            int grid_cnt = inputRmGrid.Rows.Count;
            for (int i = 0; i < grid_cnt; i++)
            {
                string txt_item_cd = (string)inputRmGrid.Rows[i - cnt].Cells["RAW_MAT_CD"].Value;

                if (txt_item_cd == "" || txt_item_cd == null)  //마지막 행에 원자재코드가 없을 경우 제거
                {
                    inputRmGrid.Rows.RemoveAt(i - cnt);
                    cnt++;
                }
            }

            string give_gubun = "-1";
            if (cmb_give_gubun.SelectedIndex != 0) give_gubun = cmb_give_gubun.SelectedValue.ToString();

            string input_yn = comInfo.resultYn(chk_input_yn);
            if (lbl_input_gbn.Text != "1" )
            {
                wnDm wDm = new wnDm();
                int rsNum = wDm.insertRmInput(
                        txt_input_date.Text.ToString(),
                        txt_cust_cd.Text.ToString(),
                        input_yn,
                        txt_comment.Text.ToString(),
                        txt_vat_cd.Text.ToString(),
                        txt_supply_money.Text.ToString(),
                        txt_tax_money.Text.ToString(),
                        txt_total_money.Text.ToString(),
                        give_gubun,
                        txt_give_money.Text.ToString(),
                        txt_dc_money.Text.ToString(),
                        txt_total_give_money.Text.ToString(),
                        inputRmGrid,
                        hash);

                if (rsNum == 0)
                {
                    int rsNum2 = wDm.updateStRaw(inputRmGrid);

                    if (rsNum2 == 0) 
                    {
                        resetSetting();
                        tdInputGrid.Rows.Clear();
                        inputGrid.Rows.Clear();
                        input_list(tdInputGrid, "where convert(varchar(10), A.INTIME, 120) = convert(varchar(10), getDate(), 120) ");
                        input_list(inputGrid, "where A.INPUT_DATE >= '" + start_date.Text.ToString() + "' and  A.INPUT_DATE <= '" + end_date.Text.ToString() + "'");
                        MessageBox.Show("성공적으로 등록하였습니다.");
                    }
                    else if (rsNum == 1)
                    {
                        MessageBox.Show("저장에 실패하였습니다");
                    }
                    else
                    {
                        MessageBox.Show("Exception 에러");
                    } 
                }
                else if (rsNum == 1)
                {
                    MessageBox.Show("저장에 실패하였습니다");
                }   
                else if (rsNum == 2)
                {
                    MessageBox.Show("조건 검사 중 에러");
                }
                else if (rsNum == 3) 
                {
                    MessageBox.Show("발주수량보다 초과 입력 하셨습니다. \n 확인 후 다시 저장 하시기 바랍니다.");
                }
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
                int rsNum = wDm.updateRmInput(
                        txt_input_date.Text.ToString(),
                        txt_input_cd.Text.ToString(),
                        txt_cust_cd.Text.ToString(),
                        txt_comment.Text.ToString(),
                        txt_vat_cd.Text.ToString(),
                        txt_supply_money.Text.ToString(),
                        txt_tax_money.Text.ToString(),
                        txt_total_money.Text.ToString(),
                        is_give_inputed,
                        give_gubun,
                        txt_give_money.Text.ToString(),
                        txt_dc_money.Text.ToString(),
                        txt_total_give_money.Text.ToString(),
                        input_yn,
                        inputRmGrid,
                        del_inputGrid,
                        hash);

                if (rsNum == 0)
                {
                    int rsNum2 = wDm.updateStRaw(inputRmGrid);

                    if (rsNum2 == 0)
                    {
                        resetSetting();
                        del_inputGrid.Rows.Clear();
                        tdInputGrid.Rows.Clear();
                        inputGrid.Rows.Clear();
                        input_list(tdInputGrid, "where convert(varchar(10), A.INTIME, 120) = convert(varchar(10), getDate(), 120) ");
                        input_list(inputGrid, "where A.INPUT_DATE >= '" + start_date.Text.ToString() + "' and  A.INPUT_DATE <= '" + end_date.Text.ToString() + "'");
                        inputDetail2();
                        ni_detail();
                        in_grid_detail();
                        MessageBox.Show("성공적으로 수정하였습니다.");
                    }
                    else if (rsNum == 1)
                    {
                        MessageBox.Show("저장에 실패하였습니다");
                    }
                    else
                    {
                        MessageBox.Show("Exception 에러");
                    } 
                }
                else if (rsNum == 1)
                    MessageBox.Show("저장에 실패하였습니다");
                else if (rsNum == 2)
                {
                    MessageBox.Show("조건 검사 중 에러");
                }
                else if (rsNum == 3)
                {
                    MessageBox.Show("발주수량보다 초과 입력 하셨습니다. \n 체크 후 다시 저장 하시기 바랍니다.");
                }
                else
                    MessageBox.Show("Exception 에러");
            }

            ni_detail();
        }

        private void input_list(DataGridView dgv, string condition)
        {
            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = null;
                dt = wDm.fn_Rm_Input_List(condition);

                DataGridViewCellStyle styleTemp = new DataGridViewCellStyle();
                styleTemp.BackColor = Color.PaleGoldenrod;
                styleTemp.SelectionBackColor = Color.Khaki;
                if (dt != null && dt.Rows.Count > 0)
                {
                    dgv.RowCount = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //dgv.Rows[i].Cells["INPUT_DATE"].Value = dt.Rows[i]["INPUT_DATE"].ToString();
                        //dgv.Rows[i].Cells["INPUT_CD"].Value = dt.Rows[i]["INPUT_CD"].ToString();
                        //dgv.Rows[i].Cells["CUST_CD"].Value = dt.Rows[i]["CUST_CD"].ToString();
                        //dgv.Rows[i].Cells["CUST_NM"].Value = dt.Rows[i]["CUST_NM"].ToString();
                        //dgv.Rows[i].Cells["RAW_MAT_CNT"].Value = dt.Rows[i]["RAW_MAT_CNT"].ToString();
                        //dgv.Rows[i].Cells["COMPLETE_YN"].Value = dt.Rows[i]["COMPLETE_YN"].ToString();

                        dgv.Rows[i].Cells[0].Value = dt.Rows[i]["INPUT_DATE"].ToString();
                        dgv.Rows[i].Cells[1].Value = dt.Rows[i]["INPUT_CD"].ToString();
                        if (dt.Rows[i]["CUST_NM"].ToString().Equals(""))
                        {
                            for (int j = 0; j < dgv.Columns.Count; j++)
                            {
                                dgv.Rows[i].Cells[j].Style = styleTemp;
                            }
                        }
                        dgv.Rows[i].Cells[2].Value = dt.Rows[i]["CUST_NM"].ToString();
                        dgv.Rows[i].Cells[3].Value = dt.Rows[i]["RAW_MAT_CNT"].ToString();
                        dgv.Rows[i].Cells[4].Value = dt.Rows[i]["COMPLETE_YN"].ToString();
                        dgv.Rows[i].Cells[5].Value = dt.Rows[i]["CUST_CD"].ToString();
                        dgv.Rows[i].Cells[6].Value = dt.Rows[i]["COMMENT"].ToString();
                        dgv.Rows[i].Cells[7].Value = dt.Rows[i]["VAT_CD"].ToString();
                        dgv.Rows[i].Cells[8].Value = dt.Rows[i]["GIVE_GUBUN"].ToString();
                        dgv.Rows[i].Cells[9].Value = dt.Rows[i]["GIVE_MONEY"].ToString();
                        dgv.Rows[i].Cells[10].Value = dt.Rows[i]["DC_MONEY"].ToString();
                        dgv.Rows[i].Cells[11].Value = dt.Rows[i]["TOTAL_MONEY"].ToString();
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

        private void inputGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ComInfo.grdHeaderNoAction(e))
            {
                input_detail(inputGrid, e);
            }
        }

        private void input_detail(DataGridView dgv, DataGridViewCellEventArgs e)
        {
            btnDelete.Enabled = true;
            lbl_input_gbn.Text = "1";
            txt_input_date.Enabled = false;
            txt_input_date.Text = dgv.Rows[e.RowIndex].Cells[0].Value.ToString();

            txt_input_cd.Text = dgv.Rows[e.RowIndex].Cells[1].Value.ToString();
            txt_cust_cd.Text = dgv.Rows[e.RowIndex].Cells[5].Value.ToString();
            txt_cust_nm.Text = dgv.Rows[e.RowIndex].Cells[2].Value.ToString();
            txt_vat_cd.Text = dgv.Rows[e.RowIndex].Cells[7].Value.ToString();
            txt_comment.Text = dgv.Rows[e.RowIndex].Cells[6].Value.ToString();

            if (dgv.Rows[e.RowIndex].Cells[8].Value != null && !dgv.Rows[e.RowIndex].Cells[8].Value.ToString().Equals(""))
            {
                cmb_give_gubun.SelectedValue = dgv.Rows[e.RowIndex].Cells[8].Value.ToString();
                txt_give_money.Text = decimal.Parse(dgv.Rows[e.RowIndex].Cells[9].Value.ToString()).ToString("#,0.######");
                txt_dc_money.Text = decimal.Parse(dgv.Rows[e.RowIndex].Cells[10].Value.ToString()).ToString("#,0.######");
                txt_total_give_money.Text = decimal.Parse(dgv.Rows[e.RowIndex].Cells[11].Value.ToString()).ToString("#,0.######");
                is_give_inputed = true;
            }
            else
            {
                cmb_give_gubun.SelectedIndex = 0;
                is_give_inputed = false;
            }

            if (dgv.Rows[e.RowIndex].Cells[4].Value.ToString().Equals("Y"))
            {
                chk_input_yn.Checked = true;
            }
            else 
            {
                chk_input_yn.Checked = false;
            }
            inputDetail2();
            ni_detail();
            in_grid_detail();
        }

        private void input_detail(DataGridView dgv, int e_RowIndex)
        {
            btnDelete.Enabled = true;
            lbl_input_gbn.Text = "1";
            txt_input_date.Enabled = false;
            txt_input_date.Text = dgv.Rows[e_RowIndex].Cells[0].Value.ToString();

            txt_input_cd.Text = dgv.Rows[e_RowIndex].Cells[1].Value.ToString();
            txt_cust_cd.Text = dgv.Rows[e_RowIndex].Cells[5].Value.ToString();
            txt_cust_nm.Text = dgv.Rows[e_RowIndex].Cells[2].Value.ToString();
            txt_vat_cd.Text = dgv.Rows[e_RowIndex].Cells[7].Value.ToString();
            txt_comment.Text = dgv.Rows[e_RowIndex].Cells[6].Value.ToString();

            if (dgv.Rows[e_RowIndex].Cells[8].Value != null && !dgv.Rows[e_RowIndex].Cells[8].Value.ToString().Equals(""))
            {
                cmb_give_gubun.SelectedValue = dgv.Rows[e_RowIndex].Cells[8].Value.ToString();
                txt_give_money.Text = decimal.Parse(dgv.Rows[e_RowIndex].Cells[9].Value.ToString()).ToString("#,0.######");
                txt_dc_money.Text = decimal.Parse(dgv.Rows[e_RowIndex].Cells[10].Value.ToString()).ToString("#,0.######");
                txt_total_give_money.Text = decimal.Parse(dgv.Rows[e_RowIndex].Cells[11].Value.ToString()).ToString("#,0.######");
                is_give_inputed = true;
            }
            else
            {
                cmb_give_gubun.SelectedIndex = 0;
                is_give_inputed = false;
            }

            if (dgv.Rows[e_RowIndex].Cells[4].Value.ToString().Equals("Y"))
            {
                chk_input_yn.Checked = true;
            }
            else
            {
                chk_input_yn.Checked = false;
            }
            inputDetail2();
            ni_detail();
            in_grid_detail();
        }


        private void inputDetail2() 
        {
            wnDm wDm = new wnDm();
            DataTable dt = null;

            dt = wDm.fn_Input_Detail_List("where A.INPUT_DATE = '" + txt_input_date.Text.ToString() + "' and A.INPUT_CD = '" + txt_input_cd.Text.ToString() + "' ");

            dtp.Visible = false;
            this.inputRmGrid.RowCount = dt.Rows.Count;
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //string t_amt = string.Format("{0:#.##}", 100.2);
                    inputRmGrid.Rows[i].Cells["SEQ"].Value = dt.Rows[i]["SEQ"].ToString();
                    inputRmGrid.Rows[i].Cells["ORDER_DATE"].Value = dt.Rows[i]["ORDER_DATE"].ToString();
                    inputRmGrid.Rows[i].Cells["ORDER_CD"].Value = dt.Rows[i]["ORDER_CD"].ToString();
                    inputRmGrid.Rows[i].Cells["ORDER_SEQ"].Value = dt.Rows[i]["ORDER_SEQ"].ToString();
                    inputRmGrid.Rows[i].Cells["RAW_MAT_NM"].Value = dt.Rows[i]["RAW_MAT_NM"].ToString();
                    inputRmGrid.Rows[i].Cells["RAW_MAT_CD"].Value = dt.Rows[i]["RAW_MAT_CD"].ToString();
                    inputRmGrid.Rows[i].Cells["SPEC"].Value = dt.Rows[i]["SPEC"].ToString();
                    inputRmGrid.Rows[i].Cells["UNIT_CD"].Value = dt.Rows[i]["UNIT_CD"].ToString();
                    inputRmGrid.Rows[i].Cells["UNIT_NM"].Value = dt.Rows[i]["UNIT_NM"].ToString();
                    inputRmGrid.Rows[i].Cells["RAW_MAT_GUBUN"].Value = dt.Rows[i]["RAW_MAT_GUBUN"].ToString();
                    inputRmGrid.Rows[i].Cells["RAW_MAT_GUBUN_NM"].Value = dt.Rows[i]["RAW_MAT_GUBUN_NM"].ToString();

                    inputRmGrid.Rows[i].Cells["TOTAL_AMT"].Value = (decimal.Parse(dt.Rows[i]["TEMP_AMT"].ToString())).ToString("#,0.######"); 
                    inputRmGrid.Rows[i].Cells["OLD_TOTAL_AMT"].Value = dt.Rows[i]["TOTAL_AMT"].ToString();
                    inputRmGrid.Rows[i].Cells["PRICE"].Value = (decimal.Parse(dt.Rows[i]["PRICE"].ToString())).ToString("#,0.######");
                    inputRmGrid.Rows[i].Cells["TOTAL_MONEY"].Value = (decimal.Parse(dt.Rows[i]["TOTAL_MONEY"].ToString())).ToString("#,0.######");
                    
                    inputRmGrid.Rows[i].Cells["HEAT_NO"].Value = dt.Rows[i]["HEAT_NO"].ToString();
                    inputRmGrid.Rows[i].Cells["HEAT_TIME"].Value = dt.Rows[i]["HEAT_TIME"].ToString();
                    inputRmGrid.Rows[i].Cells["비고"].Value = dt.Rows[i]["COMMENT"].ToString();
                    inputRmGrid.Rows[i].Cells["OUT_YN"].Value = dt.Rows[i]["OUTPUT_CD"].ToString().Equals("1") ? "출고" : "미출고";

                    inputRmGrid.Rows[i].Cells["TAX_CD"].Value = dt.Rows[i]["TAX_CD"].ToString();
                    //inputRmGrid.Rows[i].Cells["CHECK_YN"].Value = dt.Rows[i]["CHECK_GUBUN_NM"].ToString();
                    if (dt.Rows[i]["CHECK_YN"].ToString().Equals("S"))
                    {
                        inputRmGrid.Rows[i].Cells["CHECK_YN"].Value = "검사";
                    }
                    else if (dt.Rows[i]["CHECK_YN"].ToString().Equals("Y"))
                    {
                        inputRmGrid.Rows[i].Cells["CHECK_YN"].Value = "검사완료!";
                    }
                    else if (dt.Rows[i]["CHECK_YN"].ToString().Equals("O"))
                    {
                        inputRmGrid.Rows[i].Cells["CHECK_YN"].Value = "생략";
                    }

                    if (dt.Rows[i]["STORAGE_CD"] != null && !dt.Rows[i]["STORAGE_CD"].ToString().Equals(""))
                    {
                        inputRmGrid.Rows[i].Cells["STORAGE_CD"].Value = dt.Rows[i]["STORAGE_CD"].ToString();
                        inputRmGrid.Rows[i].Cells["LOC_CD"].Tag = dt.Rows[i]["STORAGE_CD"].ToString();
                    }
                    if (dt.Rows[i]["LOC_CD"] != null && !dt.Rows[i]["LOC_CD"].ToString().Equals(""))
                    {
                        inputRmGrid.Rows[i].Cells["LOC_CD"].ToolTipText = dt.Rows[i]["LOC_NM"].ToString();
                        inputRmGrid.Rows[i].Cells["STORAGE_CD"].Tag = dt.Rows[i]["LOC_CD"].ToString();
                        inputRmGrid.Rows[i].Cells["LOC_CD"].Value = "선택됨";
                    }
                    else
                    {
                        inputRmGrid.Rows[i].Cells["LOC_CD"].Value = "선택";
                    }

                    wConst.f_Calc_Price(inputRmGrid, i, "TOTAL_AMT", "PRICE", "TOTAL_MONEY", "SUPPLY_MONEY", "TAX_MONEY", "ALL_TOTAL_MONEY", txt_vat_cd.Text, inputRmGrid.Rows[i].Cells["TAX_CD"].Value.ToString());

                    
                }
                wConst.f_Calc_SalesPrice(txt_supply_money
                                        , txt_tax_money
                                        , txt_total_money
                                        , txt_vat_cd.Text
                                        , txt_no_tax_money
                                        , txt_yes_tax_money
                                        , txt_yesno_money
                                        , inputRmGrid
                                        , "SUPPLY_MONEY"
                                        , "TAX_MONEY"
                                        , "ALL_TOTAL_MONEY"
                                        , "TAX_CD"
                                        , false
                                        , ""
                                        );

            }
        }

        private void input_del() 
        {

            ComInfo comInfo = new ComInfo();
            Console.WriteLine(txt_input_date.Text.ToString());
            Console.WriteLine(txt_input_cd.Text.ToString());

            DialogResult msgOk = comInfo.deleteConfrim("원자재입고", txt_input_date.Text.ToString()+ " - "+ txt_input_cd.Text.ToString());

            if (msgOk == DialogResult.No)
            {
                return;
            }

            wnDm wDm = new wnDm();
            DataTable dt = wDm.isRawOut(txt_input_date.Text.ToString(), txt_input_cd.Text.ToString());
            if (dt.Rows.Count > 0)
            {

                MessageBox.Show("이미 출고된 원자재가 존재하므로 삭제할 수 없습니다.");
                return;

            }
            
            int rsNum = wDm.deleteInput(txt_input_date.Text.ToString(), txt_input_cd.Text.ToString(), is_give_inputed);
            if (rsNum == 0)
            {
                int rsNum2 = wDm.updateStRaw(inputRmGrid);

                if (rsNum2 == 0)
                {
                    resetSetting();

                    input_list(tdInputGrid, "where convert(varchar(10), A.INTIME, 120) = convert(varchar(10), getDate(), 120) ");
                    input_list(inputGrid, "where A.INPUT_DATE >= '" + start_date.Text.ToString() + "' and  A.INPUT_DATE <= '" + end_date.Text.ToString() + "'");

                    MessageBox.Show("성공적으로 삭제하였습니다.");
                }
                else if (rsNum == 1)
                {
                    MessageBox.Show("저장에 실패하였습니다");
                }
                else
                {
                    MessageBox.Show("Exception 에러");

                } 
            }
            else if (rsNum == 1)
            {
                MessageBox.Show("삭제에 실패하였습니다.");
            }
        }

        private void ni_detail() 
        {
            ischeck = 0;
            wnDm wDm = new wnDm();
            DataTable dt = null;

            string condition = "where  C.NO_INPUT_AMT > 0 ";
            condition += "and A.ORDER_DATE>='" + dtpStart.Value.ToString().Substring(0, 10) + "' and A.ORDER_DATE<='" + dtpEnd.Value.ToString().Substring(0, 10) + "' ";
            if (txt_cust_cd.Text != "" &txt_cust_nm.Text != "" )
            {
                condition += "and A.CUST_CD = '" + txt_cust_cd.Text.ToString() + "'";

            }
            if (txt원자재cd.Text != "" &txt원자재.Text !="")
            {
                condition += "and B.RAW_MAT_CD  = '" + txt원자재cd.Text.ToString() + "'";
            }
           
            dt = wDm.fn_Input_Order_Detail_List(condition);

            this.n_in_ord_grid.RowCount = dt.Rows.Count;
            if (dt != null && dt.Rows.Count > 0)
            {
               // n_in_ord_grid.RowCount = dt.Rows.Count;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    n_in_ord_grid.Rows[i].Cells["NI_ORDER_DATE"].Value = dt.Rows[i]["ORDER_DATE"].ToString();
                    n_in_ord_grid.Rows[i].Cells["NI_ORDER_CD"].Value = dt.Rows[i]["ORDER_CD"].ToString();
                    n_in_ord_grid.Rows[i].Cells["NI_SEQ"].Value = dt.Rows[i]["SEQ"].ToString();
                    n_in_ord_grid.Rows[i].Cells["NI_RAW_MAT_NM"].Value = dt.Rows[i]["RAW_MAT_NM"].ToString();
                    n_in_ord_grid.Rows[i].Cells["NI_RAW_MAT_CD"].Value = dt.Rows[i]["RAW_MAT_CD"].ToString();
                    n_in_ord_grid.Rows[i].Cells["NI_SPEC"].Value = dt.Rows[i]["SPEC"].ToString();
                    n_in_ord_grid.Rows[i].Cells["NI_RAW_MAT_GUBUN"].Value = dt.Rows[i]["RAW_MAT_GUBUN_NM"].ToString();
                    n_in_ord_grid.Rows[i].Cells["NI_RAW_MAT_GUBUN_NM"].Value = dt.Rows[i]["RAW_MAT_GUBUN_NM"].ToString();
                    n_in_ord_grid.Rows[i].Cells["NI_ORDER_AMT"].Value = (decimal.Parse(dt.Rows[i]["ORDER_AMT"].ToString())).ToString("#,0.######");
                    n_in_ord_grid.Rows[i].Cells["NI_UNIT_CD"].Value = dt.Rows[i]["UNIT_CD"].ToString();
                    n_in_ord_grid.Rows[i].Cells["NI_UNIT_NM"].Value = dt.Rows[i]["UNIT_NM"].ToString();
                    n_in_ord_grid.Rows[i].Cells["INPUT_AMT"].Value = (decimal.Parse(dt.Rows[i]["INPUT_AMT"].ToString())).ToString("#,0.######");
                    n_in_ord_grid.Rows[i].Cells["NO_INPUT_AMT"].Value = (decimal.Parse(dt.Rows[i]["NO_INPUT_AMT"].ToString())).ToString("#,0.######");
                    n_in_ord_grid.Rows[i].Cells["NI_PRICE"].Value = (decimal.Parse(dt.Rows[i]["PRICE"].ToString())).ToString("#,0.######");
                    n_in_ord_grid.Rows[i].Cells["NI_TOTAL_MONEY"].Value = (decimal.Parse(dt.Rows[i]["TOTAL_MONEY"].ToString())).ToString("#,0.######");
                    n_in_ord_grid.Rows[i].Cells["CUST_NM2"].Value = dt.Rows[i]["CUST_NM"].ToString();
                    n_in_ord_grid.Rows[i].Cells["CUST_CD2"].Value = dt.Rows[i]["CUST_CD"].ToString();
                    n_in_ord_grid.Rows[i].Cells["O검사여부"].Value = dt.Rows[i]["검사여부"].ToString();
                    n_in_ord_grid.Rows[i].Cells["R_STORAGE_CD"].Value = dt.Rows[i]["RAW_STORAGE"].ToString();
                    n_in_ord_grid.Rows[i].Cells["B_TAX_CD"].Value = dt.Rows[i]["TAX_CD"].ToString();
                    n_in_ord_grid.Rows[i].Cells["B_VAT_CD"].Value = dt.Rows[i]["VAT_CD"].ToString();
                    n_in_ord_grid.Rows[i].Cells["CHK"].Value = false;
                }
            }
        }

        private void in_grid_detail()
        {
            wnDm wDm = new wnDm();
            DataTable dt = null;

            string condition = "where A.CUST_CD = '" + txt_cust_cd.Text.ToString() + "' and C.INPUT_AMT > 0 ";
            dt = wDm.fn_Input_Order_Detail_List(condition);

            in_ord_gird.RowCount = dt.Rows.Count;
            if (dt != null && dt.Rows.Count > 0)
            {
                
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    in_ord_gird.Rows[i].Cells["IN_ORDER_DATE"].Value = dt.Rows[i]["ORDER_DATE"].ToString();
                    in_ord_gird.Rows[i].Cells["IN_ORDER_CD"].Value = dt.Rows[i]["ORDER_CD"].ToString();
                    in_ord_gird.Rows[i].Cells["IN_RAW_MAT_NM"].Value = dt.Rows[i]["RAW_MAT_NM"].ToString();
                    //in_ord_gird.Rows[i].Cells["IN_RAW_MAT_CD"].Value = dt.Rows[i]["RAW_MAT_CD"].ToString();
                    in_ord_gird.Rows[i].Cells["IN_SPEC"].Value = dt.Rows[i]["SPEC"].ToString();
                    //n_in_ord_grid.Rows[i].Cells["IN_RAW_MAT_GUBUN"].Value = dt.Rows[i]["RAW_MAT_GUBUN"].ToString();
                    in_ord_gird.Rows[i].Cells["IN_RAW_MAT_GUBUN_NM"].Value = dt.Rows[i]["RAW_MAT_GUBUN_NM"].ToString();
                    in_ord_gird.Rows[i].Cells["IN_ORDER_AMT"].Value = dt.Rows[i]["ORDER_AMT"].ToString();
                    //in_ord_gird.Rows[i].Cells["IN_UNIT_CD"].Value = dt.Rows[i]["UNIT_CD"].ToString();
                    //in_ord_gird.Rows[i].Cells["IN_UNIT_NM"].Value = dt.Rows[i]["UNIT_NM"].ToString();
                    in_ord_gird.Rows[i].Cells["IN_INPUT_AMT"].Value = dt.Rows[i]["INPUT_AMT"].ToString();
                    //in_ord_gird.Rows[i].Cells["NO_INPUT_AMT"].Value = dt.Rows[i]["NO_INPUT_AMT"].ToString();
                    in_ord_gird.Rows[i].Cells["IN_PRICE"].Value = dt.Rows[i]["PRICE"].ToString();
                    in_ord_gird.Rows[i].Cells["IN_TOTAL_MONEY"].Value = dt.Rows[i]["TOTAL_MONEY"].ToString();
                }
            }
        }
        #endregion input logic


        #region main grid logic
        private void tab_input_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tab_input.SelectedIndex == 0) //미입고
            {
                btn_move.Visible = true;
            }
            else //입고
            {
                btn_move.Visible = false;
            }
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

            try
            {
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
            catch (Exception ex)
            {

            }
        }

        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (inputRmGrid.Columns[e.ColumnIndex].Name) 
            {
                case "HEAT_TIME" :
                    
                    _Retangle = inputRmGrid.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                    dtp.Size = new Size(_Retangle.Width, _Retangle.Height);
                    dtp.Location = new Point(_Retangle.X, _Retangle.Y);
                    dtp.Visible = true;
                    
                    string heat_time = (string)inputRmGrid.Rows[e.RowIndex].Cells["HEAT_TIME"].Value ;
                    if (heat_time != "" && heat_time != null)
                    {
                        dtp.Text = (string)inputRmGrid.Rows[e.RowIndex].Cells["HEAT_TIME"].Value;
                    }
                    else 
                    {
                        dtp.Text = DateTime.Today.ToString("yyyy-MM-dd");
                    }
                    break;

                default :
                    dtp.Visible = false;
                    break;
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

        private void grid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            string name = inputRmGrid.CurrentCell.OwningColumn.Name;

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

        private void grid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            conDataGridView grd = (conDataGridView)sender;
            DataGridViewCell cell = grd[e.ColumnIndex, e.RowIndex];

            cell.Style.BackColor = Color.White;
            if (grd.Columns[e.ColumnIndex].ToolTipText.IndexOf("명칭") >= 0 && grd._KeyInput == "enter" )
            {
                string rat_mat_nm = (string)grd.Rows[e.RowIndex].Cells["RAW_MAT_NM"].Value;
                wnDm wDm = new wnDm();
                DataTable dt = new DataTable();
                dt = wDm.fn_Raw_List("where A.RAW_MAT_NM like '%" + rat_mat_nm + "%'", "1");


                if (dt.Rows.Count > 1)
                { //row가 2줄이 넘을 경우 팝업으로 넘어간다.

                    wConst.call_pop_raw_mat(grd, dt, e.RowIndex, rat_mat_nm, 2,txt_cust_cd.Text);
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

                    inputGridAdd();
                }
                else
                { //row가 없는 경우
                    MessageBox.Show("데이터가 없습니다.");
                    inputRmGrid.Rows.RemoveAt(inputRmGrid.SelectedRows[0].Index);
                    inputRmGrid.CurrentCell = inputRmGrid[2, inputRmGrid.Rows.Count];
                }

                wConst.f_Calc_Price(grd, e.RowIndex, "TOTAL_AMT", "PRICE", "TOTAL_MONEY", "SUPPLY_MONEY", "TAX_MONEY", "ALL_TOTAL_MONEY", txt_vat_cd.Text, grd.Rows[e.RowIndex].Cells["TAX_CD"].Value.ToString());

                wConst.f_Calc_SalesPrice(txt_supply_money
                                    , txt_tax_money
                                    , txt_total_money
                                    , txt_vat_cd.Text
                                    , txt_no_tax_money
                                    , txt_yes_tax_money
                                    , txt_yesno_money
                                    , grd
                                    , "SUPPLY_MONEY"
                                    , "TAX_MONEY"
                                    , "ALL_TOTAL_MONEY"
                                    , "TAX_CD"
                                    , false
                                    , ""
                                    );
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

                wConst.f_Calc_Price(grd, e.RowIndex, "TOTAL_AMT", "PRICE", "TOTAL_MONEY", "SUPPLY_MONEY", "TAX_MONEY", "ALL_TOTAL_MONEY", txt_vat_cd.Text, grd.Rows[e.RowIndex].Cells["TAX_CD"].Value.ToString());

                wConst.f_Calc_SalesPrice(txt_supply_money
                                    , txt_tax_money
                                    , txt_total_money
                                    , txt_vat_cd.Text
                                    , txt_no_tax_money
                                    , txt_yes_tax_money
                                    , txt_yesno_money
                                    , grd
                                    , "SUPPLY_MONEY"
                                    , "TAX_MONEY"
                                    , "ALL_TOTAL_MONEY"
                                    , "TAX_CD"
                                    , false
                                    , ""
                                    );
            }
            //SendKeys.Send("{TAB}");
            //해당 이벤트가 그리드 클릭시마다 계속 도는데 TAB키를 계속 보내서 이상하게 동작함 따라서 주석 처리하였음 
            //2020-05-08 이재원 

        }

        private void grid_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e) 
        {
            dtp.Visible = false;
        }

        private void grid_scroll(object sender, ScrollEventArgs e)
        {
            dtp.Visible = false;
        }
        #endregion main grid logic

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                input_list(tdInputGrid, "where convert(varchar(10), A.INTIME, 120) = convert(varchar(10), getDate(), 120) ");
            }
            else 
            {
                start_date.Text = DateTime.Today.AddMonths(-1).ToString("yyyy-MM-dd");
                input_list(inputGrid, "where A.INPUT_DATE >= '" + start_date.Text.ToString() + "' and  A.INPUT_DATE <= '" + end_date.Text.ToString() + "'");
            }
        }

        private void tdInputGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ComInfo.grdHeaderNoAction(e))
            {
                input_detail(tdInputGrid, e);
                 ischeck = 0;
            }
        }

        private void minus_logic(conDataGridView dgv)
        {
            if (dgv.Rows.Count > 0)
            {
                for (int i = 0; i < n_in_ord_grid.Rows.Count; i++)
                {
                    if (!n_in_ord_grid.Rows[i].Visible)
                    {
                        if ((String)dgv.SelectedRows[0].Cells["ORDER_DATE"].Value == (String)n_in_ord_grid.Rows[i].Cells["NI_ORDER_DATE"].Value
                       && (String)dgv.SelectedRows[0].Cells["ORDER_CD"].Value == (String)n_in_ord_grid.Rows[i].Cells["NI_ORDER_CD"].Value
                      && (String)dgv.SelectedRows[0].Cells["ORDER_SEQ"].Value == (String)n_in_ord_grid.Rows[i].Cells["NI_SEQ"].Value
                       && (String)dgv.SelectedRows[0].Cells["RAW_MAT_NM"].Value == (String)n_in_ord_grid.Rows[i].Cells["NI_RAW_MAT_NM"].Value
                      && (String)dgv.SelectedRows[0].Cells["RAW_MAT_CD"].Value == (String)n_in_ord_grid.Rows[i].Cells["NI_RAW_MAT_CD"].Value
                       && (String)dgv.SelectedRows[0].Cells["SPEC"].Value == (String)n_in_ord_grid.Rows[i].Cells["NI_SPEC"].Value
                       && (String)dgv.SelectedRows[0].Cells["UNIT_CD"].Value == (String)n_in_ord_grid.Rows[i].Cells["NI_UNIT_CD"].Value
                       && (String)dgv.SelectedRows[0].Cells["UNIT_NM"].Value == (String)n_in_ord_grid.Rows[i].Cells["NI_UNIT_NM"].Value
                      && (String)dgv.SelectedRows[0].Cells["RAW_MAT_GUBUN"].Value == (String)n_in_ord_grid.Rows[i].Cells["NI_RAW_MAT_GUBUN"].Value
                       && (String)dgv.SelectedRows[0].Cells["RAW_MAT_GUBUN_NM"].Value == (String)n_in_ord_grid.Rows[i].Cells["NI_RAW_MAT_GUBUN_NM"].Value
                       && (String)dgv.SelectedRows[0].Cells["TOTAL_AMT"].Value == (String)n_in_ord_grid.Rows[i].Cells["NO_INPUT_AMT"].Value
                       && (String)dgv.SelectedRows[0].Cells["OLD_TOTAL_AMT"].Value == (String)n_in_ord_grid.Rows[i].Cells["NO_INPUT_AMT"].Value
                     && (String)dgv.SelectedRows[0].Cells["PRICE"].Value == (String)n_in_ord_grid.Rows[i].Cells["NI_PRICE"].Value
                      && (String)dgv.SelectedRows[0].Cells["TOTAL_MONEY"].Value == (String)n_in_ord_grid.Rows[i].Cells["NI_TOTAL_MONEY"].Value)
                        {
                            n_in_ord_grid.Rows[i].Visible = true;
                        }
                    }
                   

                }

                if ((string)dgv.SelectedRows[0].Cells["SEQ"].Value != "" && dgv.SelectedRows[0].Cells["SEQ"].Value != null)
                {
                    del_inputGrid.Rows.Add();

                    del_inputGrid.Rows[del_inputGrid.Rows.Count - 1].Cells["INPUT_DATE"].Value = del_inputGrid.Text.ToString();
                    del_inputGrid.Rows[del_inputGrid.Rows.Count - 1].Cells["INPUT_CD"].Value = del_inputGrid.Text.ToString();
                    del_inputGrid.Rows[del_inputGrid.Rows.Count - 1].Cells["SEQ"].Value = dgv.SelectedRows[0].Cells["SEQ"].Value;
                    del_inputGrid.Rows[del_inputGrid.Rows.Count - 1].Cells["ORDER_DATE"].Value = dgv.SelectedRows[0].Cells["ORDER_DATE"].Value;
                    del_inputGrid.Rows[del_inputGrid.Rows.Count - 1].Cells["ORDER_CD"].Value = dgv.SelectedRows[0].Cells["ORDER_CD"].Value;
                    del_inputGrid.Rows[del_inputGrid.Rows.Count - 1].Cells["ORDER_SEQ"].Value = dgv.SelectedRows[0].Cells["ORDER_SEQ"].Value;
                    del_inputGrid.Rows[del_inputGrid.Rows.Count - 1].Cells["RAW_MAT_CD"].Value = dgv.SelectedRows[0].Cells["RAW_MAT_CD"].Value;
                    del_inputGrid.Rows[del_inputGrid.Rows.Count - 1].Cells["OLD_TOTAL_AMT"].Value = dgv.SelectedRows[0].Cells["OLD_TOTAL_AMT"].Value;
                }

                dgv.Rows.RemoveAt(dgv.SelectedRows[0].Index);
                if (dgv.Rows.Count > 0) {
                    dgv.CurrentCell = dgv[2, dgv.Rows.Count - 1];
                }
            }

           
           
            
       
        }

        private void dtp_TextChange(object sender, EventArgs e) 
        {
            inputRmGrid.CurrentCell.Value = dtp.Text.ToString();
        }

        private void btn_plus_Click(object sender, EventArgs e)
        {
            inputGridAdd();
        }

        private void inputGridAdd()
        {
            inputRmGrid.Rows.Add();
            inputRmGrid.Rows[inputRmGrid.Rows.Count - 1].Cells["TOTAL_AMT"].Value = "0";
            inputRmGrid.Rows[inputRmGrid.Rows.Count - 1].Cells["PRICE"].Value = "0";
            inputRmGrid.Rows[inputRmGrid.Rows.Count - 1].Cells["TOTAL_MONEY"].Value = "0";
            inputRmGrid.Rows[inputRmGrid.Rows.Count - 1].Cells["LOC_CD"].Value = "선택";
        }

        private void inputRmGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {           
            if (e.RowIndex > -1)
            {
                switch (inputRmGrid.Columns[e.ColumnIndex].Name)
                {
                    case "RAW_MAT_NM":
                        if (inputRmGrid.Rows[e.RowIndex].Cells["RAW_MAT_NM"].Value == null)
                        {

                            conDataGridView grd = (conDataGridView)sender;
                            DataGridViewCell cell = grd[e.ColumnIndex, e.RowIndex];

                            cell.Style.BackColor = Color.White;
                            if (grd.Columns[e.ColumnIndex].ToolTipText.IndexOf("명칭") >= 0)
                            {
                                string rat_mat_nm = (string)grd.Rows[e.RowIndex].Cells["RAW_MAT_NM"].Value;
                                wnDm wDm = new wnDm();
                                DataTable dt = new DataTable();
                                dt = wDm.fn_Raw_List("where RAW_MAT_NM like '%" + rat_mat_nm + "%' ", "1");

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

                                    inputGridAdd();
                                }
                                else
                                { //row가 없는 경우
                                    MessageBox.Show("데이터가 없습니다.");
                                }

                                wConst.f_Calc_Price(grd, e.RowIndex, "TOTAL_AMT", "PRICE", "TOTAL_MONEY", "SUPPLY_MONEY", "TAX_MONEY", "ALL_TOTAL_MONEY", txt_vat_cd.Text, grd.Rows[e.RowIndex].Cells["TAX_CD"].Value.ToString());

                                wConst.f_Calc_SalesPrice(txt_supply_money
                                                    , txt_tax_money
                                                    , txt_total_money
                                                    , txt_vat_cd.Text
                                                    , txt_no_tax_money
                                                    , txt_yes_tax_money
                                                    , txt_yesno_money
                                                    , grd
                                                    , "SUPPLY_MONEY"
                                                    , "TAX_MONEY"
                                                    , "ALL_TOTAL_MONEY"
                                                    , "TAX_CD"
                                                    , false
                                                    , ""
                                                    );
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

                                wConst.f_Calc_Price(grd, e.RowIndex, "TOTAL_AMT", "PRICE", "TOTAL_MONEY", "SUPPLY_MONEY", "TAX_MONEY", "ALL_TOTAL_MONEY", txt_vat_cd.Text, grd.Rows[e.RowIndex].Cells["TAX_CD"].Value.ToString());

                                wConst.f_Calc_SalesPrice(txt_supply_money
                                                    , txt_tax_money
                                                    , txt_total_money
                                                    , txt_vat_cd.Text
                                                    , txt_no_tax_money
                                                    , txt_yes_tax_money
                                                    , txt_yesno_money
                                                    , grd
                                                    , "SUPPLY_MONEY"
                                                    , "TAX_MONEY"
                                                    , "ALL_TOTAL_MONEY"
                                                    , "TAX_CD"
                                                    , false
                                                    , ""
                                                    );
                            }
                            SendKeys.Send("{TAB}");
                        }
                        else
                        {
                        }
                        break;

                    default:
                        dtp.Visible = false;
                        break;
                }
            }
        }
        int ischeck = 0;
        private void n_in_ord_grid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {



            ischeck++;


            if (ischeck % 2 == 1)
            {
                if (e.ColumnIndex == 9)
                {
                    if (n_in_ord_grid.Rows.Count > 0)
                    {

                        foreach (DataGridViewRow rows in n_in_ord_grid.Rows)
                        {


                            rows.Cells["CHK"].Value = true;


                        }

                        btnSave.Focus();

                    }

                }
            }
            else
            {
                if (e.ColumnIndex == 9)
                {
                    if (n_in_ord_grid.Rows.Count > 0)
                    {

                        foreach (DataGridViewRow rows in n_in_ord_grid.Rows)
                        {


                            rows.Cells["CHK"].Value = false;


                        }

                        btnSave.Focus();

                    }

                }

            }
        }

        private void frm원자재입고등록_Enter(object sender, EventArgs e)
        {
            btnSrch.PerformClick();

        }
      
        private void n_in_ord_grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ni_detail();
        }

        private void txt원자재_TextChanged(object sender, EventArgs e)
        {
            
            if (txt원자재.Text.Length == 14)
            {
                ni_detail();
            }
        }

        private void inputRmGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0 && senderGrid.Columns[e.ColumnIndex].Name.Equals("LOC_CD"))
            {
                SearchLoc(e.RowIndex);
            }
            //else if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
            //    e.RowIndex >= 0 && senderGrid.Columns[e.ColumnIndex].Name.Equals("SRCH_BTN"))
            //{
            //    MessageBox.Show("버튼 클릭!");
            //}

            var eyeGrid = (DataGridView)sender;
            if (eyeGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && eyeGrid.Columns[e.ColumnIndex].Name.Equals("CHECK_YN"))
            {
                if (eyeGrid.Rows[e.RowIndex].Cells["CHECK_YN"].Value.ToString().Equals("검사") || eyeGrid.Rows[e.RowIndex].Cells["CHECK_YN"].Value.ToString().Equals("검사완료"))
                {
                    DataGridViewButtonCell btn = (DataGridViewButtonCell)eyeGrid.Rows[e.RowIndex].Cells["CHECK_YN"];
                    btn.ReadOnly = false;

                    /*검사 일 경우만 수입검사창 띄우기*/
                    raw_inspection(eyeGrid,e.RowIndex);

                }
                else if (eyeGrid.Rows[e.RowIndex].Cells["CHECK_YN"].Value.ToString().Equals("생략"))
                {


                    DataGridViewButtonCell btn = (DataGridViewButtonCell)eyeGrid.Rows[e.RowIndex].Cells["CHECK_YN"];
                    btn.ReadOnly = true;
                }


            }
        }
        private void raw_inspection(DataGridView eyeGrid, int e_RowIndex)
        {
            if (eyeGrid.Rows[e_RowIndex].Cells["CHECK_YN"].Value.ToString().Equals("검사"))
            {
                frm_chk = new frm원자재수입검사();
                frm_chk.pop_chk = 1;
                frm_chk.txt_raw_mat_nm.Text = eyeGrid.Rows[e_RowIndex].Cells["RAW_MAT_NM"].Value.ToString();
                frm_chk.txt_cust_nm.Text = txt_cust_nm.Text;
                frm_chk.txt_input_date.Text = txt_input_date.Text;
                //frm_chk.txt_input_cd.Text = "";
                frm_chk.txt_input_amt.Text = eyeGrid.Rows[e_RowIndex].Cells["TOTAL_AMT"].Value.ToString();
                frm_chk.txt_input_seq.Text = "";
                frm_chk.txt_chk_date.Text = txt_input_date.Text;
                frm_chk.lbl_input_gubun.Text = "S";
                //frm_chk.txt_pass_amt.Text = "";
                //frm_chk.txt_non_pass_amt.Text = "";
                frm_chk.txt_pass_yn.Text = "";

                frm_chk.StartPosition = FormStartPosition.CenterParent;
                frm_chk.ShowDialog(this);

                //원자재수입검사에서 그리드 열추가

                /*수입검사완료시*/
                if (frm_chk.pop_chk == 2)
                {
                    eyeGrid.Rows[e_RowIndex].Cells["CHECK_YN"].Value = "검사완료";
                    hash.Add(e_RowIndex, frm_chk);
                }
            }
            else
            {
                frm_chk.StartPosition = FormStartPosition.CenterParent;
                frm_chk.ShowDialog(this);
                hash[e_RowIndex] = frm_chk; //검사완료시 수정할때
            }
            

            
          
           
            
        }

        private void SearchLoc(int e_RowIndex)
        {
            if (inputRmGrid.Rows[e_RowIndex].Cells["LOC_CD"].Tag == null || inputRmGrid.Rows[e_RowIndex].Cells["LOC_CD"].Tag.ToString().Equals(""))
            {
                MessageBox.Show("먼저 입고 창고를 선택해주십시오.");
            }
            else
            {
                Popup.pop재고위치검색 msg = new Popup.pop재고위치검색();
                msg.sStorageCd = inputRmGrid.Rows[e_RowIndex].Cells["LOC_CD"].Tag.ToString();
                if (inputRmGrid.Rows[e_RowIndex].Cells["STORAGE_CD"].Tag != null && 
                    !inputRmGrid.Rows[e_RowIndex].Cells["STORAGE_CD"].Tag.Equals(""))
                {
                    msg.sCheckValue = inputRmGrid.Rows[e_RowIndex].Cells["STORAGE_CD"].Tag.ToString();
                }
                msg.ShowDialog();

                if (msg.sCode != null && !msg.sCode.Equals(""))
                {
                    inputRmGrid.Rows[e_RowIndex].Cells["STORAGE_CD"].Tag = msg.sCode;
                    inputRmGrid.Rows[e_RowIndex].Cells["LOC_CD"].Value = "선택됨";
                    inputRmGrid.Rows[e_RowIndex].Cells["LOC_CD"].ToolTipText = msg.sName;
                }
                else
                {
                    inputRmGrid.Rows[e_RowIndex].Cells["STORAGE_CD"].Tag = "";
                    inputRmGrid.Rows[e_RowIndex].Cells["LOC_CD"].Value = "선택";
                    inputRmGrid.Rows[e_RowIndex].Cells["LOC_CD"].ToolTipText = null;
                }
            }
        }

        private void inputRmGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            conDataGridView dgv = (conDataGridView)sender;
            if (e.RowIndex > -1)
            {
                if (dgv.Columns[e.ColumnIndex].Name.Equals("STORAGE_CD"))
                {
                    inputRmGrid.Rows[e.RowIndex].Cells["STORAGE_CD"].Tag = "";
                    inputRmGrid.Rows[e.RowIndex].Cells["LOC_CD"].ToolTipText = "";
                    inputRmGrid.Rows[e.RowIndex].Cells["LOC_CD"].Value = "선택";

                    inputRmGrid.Rows[e.RowIndex].Cells["LOC_CD"].Tag = inputRmGrid.Rows[e.RowIndex].Cells["STORAGE_CD"].Value;
                }
            }
        }

        private void btn원자재등록_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("원자재 등록 페이지로 이동하시겠습니까?", "원자재등록 이동", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {


                frmMain pForm = (frmMain)this.MdiParent;
                //P85_BAS.frm제품등록///제품등록
                pForm.sub_Form("P85_BAS.frm원자재등록", "원자재등록");
            }
            else
            {
            }
        }



        //private void inputRmGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{

        //    conDataGridView grd = (conDataGridView)sender;

        //    grd.EndEdit();
        //    //DataGridViewRow Row = grd.SelectedCells[17].OwningRow;
        //    int col = grd.Columns.Count - 1;
        //    if (grd.SelectedCells[col].ColumnIndex == col && grd.SelectedCells[col].Value as bool? == true)
        //    {
        //        grd.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Red;
        //    }
        //    else
        //    {
        //        grd.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;

        //    }
        //}

        private void inputRmGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

        }

        private void cmb_give_gubun_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_give_gubun.SelectedIndex == 0)
            {
                txt_give_money.ReadOnly = true;
                txt_dc_money.ReadOnly = true;
                txt_total_give_money.ReadOnly = true;

                txt_give_money.Enabled = false;
                txt_dc_money.Enabled = false;
                txt_total_give_money.Enabled = false;

                txt_give_money.Text = "0";
                txt_dc_money.Text = "0";
                txt_total_give_money.Text = "0";
            }
            else
            {
                txt_give_money.Enabled = true;
                txt_dc_money.Enabled = true;
                txt_total_give_money.Enabled = true;

                txt_give_money.ReadOnly = false;
                txt_dc_money.ReadOnly = false;
                txt_total_give_money.ReadOnly = true;
            }
        }

        private void soo_money_TextChanged(object sender, EventArgs e)
        {
            TextBox tx = (TextBox)sender;
            if (tx.Text == null || tx.Text.ToString().Equals(""))
            {
                tx.Text = "0";
            }
            else
            {
                if (!tx.Text.ToString().Equals("0"))
                {
                    for (int i = 0; i < tx.Text.Length; i++)
                    {
                        if (tx.Text[0].ToString().Equals("0"))
                        {
                            tx.Text = tx.Text.Substring(1);
                        }
                    }
                }
            }

            wnGConstant.cal_soo_money(txt_give_money, txt_dc_money, txt_total_give_money);
            tx.SelectionStart = tx.Text.Length;
        }

        private void soo_money_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tx = (TextBox)sender;
            tx.SelectionStart = tx.Text.Length;
            ComInfo.onlyNum(sender, e);
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

        private void inputRmGrid_VisibleChanged(object sender, EventArgs e)
        {
            ComInfo.gridHeaderSet((DataGridView)sender);
        }



    }
}
