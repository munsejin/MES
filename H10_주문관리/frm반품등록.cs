
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
    public partial class frm반품등록 : Form
    {
        private wnGConstant wConst = new wnGConstant();
        private DataTable del_outGrid = new DataTable();
        wnDm wnDm = new wnDm();
        private bool bHeadCheck = false;
        private string old_cust_nm = "";
        string condition = "";
        string str주문일자 = "";
        string str주문번호 = "";
        string str배송일자 = "";
        string str배송번호 = "";
        public frm반품등록()
        {
            InitializeComponent();

            this.itemOutGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellEndEdit);
            this.itemOutGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grid_KeyDown);
            this.itemOutGrid.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grid_ColumnHeaderMouseClick);

            this.itemOutGrid.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.grid_RowsAdded);
            this.itemOutGrid.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.grid_RowsRemoved);
            this.itemOutGrid.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.grid_EditingControlShowing);

        }
        public static bool p_IsAuth = true;    // 열람권한
        public static bool p_Isrgstr = true;    //등록/수정 권한

        public static bool p_Isdel = true;    // 삭제 권한
        private void frm반품등록_Load(object sender, EventArgs e)
        {
            txt입력방식.Text = Common.p_HW;
         
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
            init_ComboBox();
            addButton(txt_cust_nm, 0);
            txt_start_date.Value = DateTime.Now.AddDays(-7);
            dtp스타트.Value = DateTime.Now.AddDays(-7);
           
  

            for (int i = 0; i < dgv배송완료.ColumnCount; i++)
            {
                dgv배송완료.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            del_outGrid.Columns.Add("LOT_NO");
            del_outGrid.Columns.Add("LOT_SUB");
            del_outGrid.Columns.Add("SEQ");
            del_outGrid.Columns.Add("J_SEQ");
            del_outGrid.Columns.Add("OLD_TOTAL_AMT");

            output_list(dgv반품등록, "where convert(varchar(10), A.INTIME, 120) = convert(varchar(10), getDate(), 120) ");

            item_out_detail("and A.ORD_DATE >= '" + dtp스타트.Text.ToString() + "' and  A.ORD_DATE <= '" + dtp앤드.Text.ToString() + "'");

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
                    반품등록저장();

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
        private void btnDelete_Click(object sender, EventArgs e)
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
                    Txtbtn[type].Click += new EventHandler(btnCustSrch_Click);

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

           


            if (dgv배송완료.Rows.Count > 0)
            {
                int chk = 0;
                for (int i = 0; i < dgv배송완료.Rows.Count; i++)
                {
                    

                    if ((bool)dgv배송완료.Rows[i].Cells["CHK"].Value == true)
                    {
                        for (int j = 0; j < itemOutGrid.Rows.Count; j++)
                        {
                            if ((string)dgv배송완료.Rows[i].Cells["LOT_NO"].Value == (string)itemOutGrid.Rows[j].Cells["O_LOT_NO"].Value
                                && (string)dgv배송완료.Rows[i].Cells["LOT_SUB"].Value == (string)itemOutGrid.Rows[j].Cells["O_LOT_SUB"].Value)
                            {
                                MessageBox.Show("해당 출고할 제품이 이미 등록되어있습니다.");
                                return;
                            }
                        }

                        for (int k = 0; k < del_outGrid.Rows.Count; k++)
                        {
                            if ((string)dgv배송완료.Rows[i].Cells["LOT_NO"].Value == (string)del_outGrid.Rows[k]["LOT_NO"].ToString()
                                && (string)dgv배송완료.Rows[i].Cells["LOT_SUB"].Value == (string)del_outGrid.Rows[k]["LOT_SUB"].ToString())
                            {
                                MessageBox.Show("해당 제품출고의 삭제데이터가 있어서 등록이 불가합니다.");
                                return;
                            }
                        }


                       
                       
                        itemOutGrid.Rows.Add();
                        int rowNum = itemOutGrid.Rows.Count - 1;
                        txt_cust_nm.Text = (String)dgv배송완료.Rows[i].Cells["납품처"].Value;
                        txt_cust_cd.Text = (String)dgv배송완료.Rows[i].Cells["납품처코드"].Value;
                        itemOutGrid.Rows[rowNum].Cells["O_LOT_NO"].Value = dgv배송완료.Rows[i].Cells["LOT_NO"].Value;
                        itemOutGrid.Rows[rowNum].Cells["O_LOT_SUB"].Value = dgv배송완료.Rows[i].Cells["LOT_SUB"].Value;
                        itemOutGrid.Rows[rowNum].Cells["O_ITEM_CD"].Value = dgv배송완료.Rows[i].Cells["ITEM_CD"].Value;
                        itemOutGrid.Rows[rowNum].Cells["O_ITEM_NM"].Value = dgv배송완료.Rows[i].Cells["ITEM_NM"].Value;
                        itemOutGrid.Rows[rowNum].Cells["OUTPUT_AMT"].Value = dgv배송완료.Rows[i].Cells["STOCK_AMT"].Value;
                        itemOutGrid.Rows[rowNum].Cells["O_SPEC"].Value = dgv배송완료.Rows[i].Cells["SPEC"].Value;
                        itemOutGrid.Rows[rowNum].Cells["PRICE"].Value = dgv배송완료.Rows[i].Cells["OUTPUT_PRICE"].Value;
                        itemOutGrid.Rows[rowNum].Cells["O_UNIT_CD"].Value = dgv배송완료.Rows[i].Cells["UNIT_CD"].Value;
                        itemOutGrid.Rows[rowNum].Cells["O_UNIT_NM"].Value = dgv배송완료.Rows[i].Cells["UNIT_NM"].Value;
                        itemOutGrid.Rows[rowNum].Cells["OLD_OUT_AMT"].Value = dgv배송완료.Rows[i].Cells["STOCK_AMT"].Value;
                        double total_money = double.Parse(dgv배송완료.Rows[i].Cells["STOCK_AMT"].Value.ToString()) * double.Parse(dgv배송완료.Rows[i].Cells["OUTPUT_PRICE"].Value.ToString());
                        itemOutGrid.Rows[rowNum].Cells["TOTAL_MONEY"].Value = total_money.ToString("#,0.###");
                        itemOutGrid.Rows[rowNum].Cells["O_INPUT_DATE"].Value = dgv배송완료.Rows[i].Cells["INPUT_DATE"].Value;
                        itemOutGrid.Rows[rowNum].Cells["O_INPUT_CD"].Value = dgv배송완료.Rows[i].Cells["INPUT_CD"].Value;
                        itemOutGrid.Rows[rowNum].Cells["O_CUST_CD"].Value = txt_cust_cd.Text.ToString();
                        itemOutGrid.Rows[rowNum].Cells["O_TAX_CD"].Value = dgv배송완료.Rows[i].Cells["TAX_CD"].Value;
                        itemOutGrid.Rows[rowNum].Cells["O_LINK_CD"].Value = dgv배송완료.Rows[i].Cells["LINK_CD"].Value;

                        chk = 1;
                        wConst.f_Calc_Price(itemOutGrid, rowNum, "OUTPUT_AMT", "PRICE");
                        itemOutGrid.Focus();
                        dgv배송완료.Rows[i].Visible = false;
                        dgv배송완료.Rows[i].Cells["CHK"].Value = false;
                    }
                }
                if (chk == 0)
                {
                    MessageBox.Show("발주서의 원자재를 선택하십시기 바랍니다.");
                }
            }
            else
            {
                MessageBox.Show("입고 데이터가 없습니다.");
            }
        }

        private void btnSrch_Click(object sender, EventArgs e)
        {
            output_list(dgv반품등록, "and  A.RETURN_DATE>='" + txt_start_date.Value.ToString().Substring(0, 10) + "' and  A.RETURN_DATE<='" + txt_end_date.Value.ToString().Substring(0, 10) + "' ");
           
        
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
            wConst.ComboBox_Read_NoBlank(cmb_stor, sqlQuery);

            //반품상태
            cbo반품상태.ValueMember = "코드";
            cbo반품상태.DisplayMember = "명칭";
            sqlQuery = comInfo.queryCode("905");
            wConst.ComboBox_Read_NoBlank(cbo반품상태, sqlQuery);


            //담당자
            cbo담당자.ValueMember = "코드";
            cbo담당자.DisplayMember = "명칭";
            sqlQuery = comInfo.queryStaff();
            wConst.ComboBox_Read_Blank(cbo담당자, sqlQuery);


            ////배송사원
            //cbo배송사원.ValueMember = "코드";
            //cbo배송사원.DisplayMember = "명칭";
            //sqlQuery = comInfo.queryStaff();
            //wConst.ComboBox_Read_Blank(cbo배송사원, sqlQuery);

            //cbo완료사원
            cbo완료사원.ValueMember = "코드";
            cbo완료사원.DisplayMember = "명칭";
            sqlQuery = comInfo.queryStaff();
            wConst.ComboBox_Read_Blank(cbo완료사원, sqlQuery);

            //cbo회수사원
            cbo회수사원.ValueMember = "코드";
            cbo회수사원.DisplayMember = "명칭";
            sqlQuery = comInfo.queryStaff();
            wConst.ComboBox_Read_Blank(cbo회수사원, sqlQuery);


         
            매출구분.DataSource = wnDm.매출구분();
            매출구분.ValueMember = "코드";
            매출구분.DisplayMember = "명칭";
        }

        private void item_out_detail(string condition)
        {
            wnDm wDm = new wnDm();
            DataTable dt = null;
            dgv배송완료.Rows.Clear();
            dt = wDm.fn_반품등록배송_List(condition);

           
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    

                        dgv배송완료.Rows.Add();
                        dgv배송완료.Rows[i].Cells["D배송일자"].Value = dt.Rows[i]["DELIVERY_DATE"].ToString();
                        dgv배송완료.Rows[i].Cells["D배송번호"].Value = dt.Rows[i]["DELIVERY_CD"].ToString();
                        dgv배송완료.Rows[i].Cells["D거래처코드"].Value = dt.Rows[i]["CUST_CD"].ToString();
                        dgv배송완료.Rows[i].Cells["D거래처"].Value = dt.Rows[i]["CUST_NM"].ToString();
                        dgv배송완료.Rows[i].Cells["D주문번호"].Value = dt.Rows[i]["ORD_NUM"].ToString();
                        dgv배송완료.Rows[i].Cells["D주문일자"].Value = dt.Rows[i]["ORD_DATE"].ToString();
                        dgv배송완료.Rows[i].Cells["D배송사원"].Value = dt.Rows[i]["배송사원"].ToString();
                        dgv배송완료.Rows[i].Cells["D담당사원"].Value = dt.Rows[i]["담당사원"].ToString();
                        dgv배송완료.Rows[i].Cells["D담당사원코드"].Value = dt.Rows[i]["STAFF_CD"].ToString();
                        dgv배송완료.Rows[i].Cells["D배송사원코드"].Value = dt.Rows[i]["DELIVERY_STAFF_CD"].ToString();
                        dgv배송완료.Rows[i].Cells["D전표상태"].Value = dt.Rows[i]["전표상태"].ToString();
                  

                    
                  
                }
            }
        }

        private void 반품등록저장()
        {
            if (lbl_out_gbn.Text == "")
            {
                try
                {
                    if (txt_cust_cd.Text.ToString().Equals(""))
                    {
                        MessageBox.Show("거래처를 선택하시기 바랍니다.");
                        return;
                    }








                    wnDm wDm = new wnDm();
                    int rsNum = wDm.insert반품등록(
                        txt_return_date.Value.ToString().Substring(0, 10)

                        , txt입력방식.Text.ToString()
                            , cbo담당자.SelectedValue.ToString()
                            , txt_cust_cd.Text.ToString()

                            , cbo반품상태.SelectedValue.ToString()
                            , txt비고.Text.ToString()

                            , itemOutGrid
                            , str주문일자
                            , str주문번호
                          , cmb_stor.SelectedValue.ToString()
                            , txt입력시간.Text
                            , str배송일자
                            , str배송번호
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
                catch (Exception e)
                {
                    Popup.pop오류리포트 msg = new Popup.pop오류리포트(e.Message+" - "+e.ToString()); msg.ShowDialog();
                }
            }
            else if (lbl_out_gbn.Text == "1")
            {

                try
                {
                    wnDm wDm = new wnDm();
                    int rsNum = wDm.update반품등록(
                        txt_return_date.Value.ToString().Substring(0, 10)
                        ,txt_retrun_cd.Text.ToString()
                        , txt입력방식.Text.ToString()
                            , cbo담당자.SelectedValue.ToString()
                            , txt_cust_cd.Text.ToString()

                            , cbo반품상태.SelectedValue.ToString()
                            , txt비고.Text.ToString()

                            , itemOutGrid
                            , dtp회수일자.Value.ToString().Substring(0, 10)
                            , cbo회수사원.SelectedValue.ToString()
                          , cmb_stor.SelectedValue.ToString()
                            , txt입력시간.Text
                            , dtp완료일자.Value.ToString().Substring(0, 10)
                            , cbo완료사원.SelectedValue.ToString()
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
                catch (Exception e)
                {
                    Popup.pop오류리포트 msg = new Popup.pop오류리포트(e.Message+" - "+e.ToString()); msg.ShowDialog();
                }
            }
            output_list(dgv반품등록, "");
            item_out_detail("");
        }

        private void resetSetting()
        {
            lbl_out_gbn.Text = "";
            btnDelete.Enabled = false;

            txt_return_date.Text = DateTime.Now.ToString("yyyy-MM-dd");
            txt_return_date.Enabled = true;
            btnCustSrch.Enabled = true;
            txt_retrun_cd.Text = "";
            txt_cust_cd.Text = "";
            txt_cust_nm.Text = "";
            old_cust_nm = "";
            txt_vat_cd.Text = "";
            txt입력시간.Text = DateTime.Now.ToString("HH:mm:ss");
            txt_cust_nm.Enabled = true;

            //chk_self_yn.Checked = false;
            cbo회수사원.SelectedIndex = 1;
            cbo완료사원.SelectedIndex = 1;
            itemOutGrid.Rows.Clear();
            dgv배송완료.Rows.Clear();
            del_outGrid.Rows.Clear();
            item_out_detail("");
        }

        private void output_list(DataGridView dgv, string condition)
        {
            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = null;
                dt = wDm.fn_등록반품_List(condition);

                if (dt != null && dt.Rows.Count > 0)
                {
                    dgv.RowCount = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgv.Rows[i].Cells["R_반품일자"].Value = dt.Rows[i]["RETURN_DATE"].ToString();
                        dgv.Rows[i].Cells["R_번호"].Value = dt.Rows[i]["RETURN_NUM"].ToString();
                        dgv.Rows[i].Cells["R_거래처코드"].Value = dt.Rows[i]["CUST_CD"].ToString();
                        dgv.Rows[i].Cells["R_거래처"].Value = dt.Rows[i]["CUST_NM"].ToString();
                        dgv.Rows[i].Cells["R_배송일자"].Value = dt.Rows[i]["DELIVERY_DATE"].ToString();
                        dgv.Rows[i].Cells["R_배송번호"].Value = dt.Rows[i]["DELIVERY_CD"].ToString();
                        dgv.Rows[i].Cells["R_창고코드"].Value = dt.Rows[i]["STORAGE_CD"].ToString();
                        dgv.Rows[i].Cells["R_창고"].Value = dt.Rows[i]["STORAGE_NM"].ToString();
                        dgv.Rows[i].Cells["R_비고"].Value = dt.Rows[i]["COMMENT"].ToString();
                        dgv.Rows[i].Cells["R_담당사원코드"].Value = dt.Rows[i]["STAFF_CD"].ToString();
                        
                        dgv.Rows[i].Cells["R_회수사원"].Value = dt.Rows[i]["RECALL_STAFF"].ToString();
                        dgv.Rows[i].Cells["R_회수일자"].Value = dt.Rows[i]["RECALL_DATE"].ToString();
                        dgv.Rows[i].Cells["R_완료사원"].Value = dt.Rows[i]["COMPLETE_STAFF"].ToString();
                        dgv.Rows[i].Cells["R_완료일자"].Value = dt.Rows[i]["COMPLETE_DATE"].ToString();
                        dgv.Rows[i].Cells["R_전표상태코드"].Value = dt.Rows[i]["SALE_STATE"].ToString();
                        dgv.Rows[i].Cells["R_상태변경일자"].Value = dt.Rows[i]["STATE_DATE"].ToString();
                        dgv.Rows[i].Cells["R_전표상태"].Value = dt.Rows[i]["S_CODE_NM"].ToString();
                        //dgv.Rows[i].Cells[4].Value = dt.Rows[i]["COMPLETE_YN"].ToString();
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

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

            output_list(dgv반품등록, "and  A.RETURN_DATE>='" + txt_start_date.Value.ToString().Substring(0, 10) + "' and  A.RETURN_DATE<='" + txt_end_date.Value.ToString().Substring(0, 10) + "' ");
            
            
        }

        private void tdOutGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            resetSetting();
            if (ComInfo.grdHeaderNoAction(e))
            {
                lbl_out_gbn.Text = "1";
                out_detail(dgv반품등록, e);
                btnDelete.Enabled = true;
            }
        }

        private void outputGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            


        }

        private void out_detail(DataGridView dgv, DataGridViewCellEventArgs e)
        {
         
           txt_return_date.Value=DateTime.Parse (dgv.Rows[e.RowIndex].Cells["R_반품일자"].Value.ToString());
           txt_retrun_cd.Text = dgv.Rows[e.RowIndex].Cells["R_번호"].Value.ToString();
           txt_cust_nm.Text = dgv.Rows[e.RowIndex].Cells["R_거래처"].Value.ToString();
           txt_cust_cd.Text = dgv.Rows[e.RowIndex].Cells["R_거래처코드"].Value.ToString();
           cbo담당자.SelectedValue = dgv.Rows[e.RowIndex].Cells["R_담당사원코드"].Value.ToString();
           cbo반품상태.SelectedValue = dgv.Rows[e.RowIndex].Cells["R_전표상태코드"].Value.ToString();
           cmb_stor.SelectedValue = dgv.Rows[e.RowIndex].Cells["R_창고코드"].Value.ToString();

           if (dgv.Rows[e.RowIndex].Cells["R_전표상태"].Value.ToString()=="반품회수")
           {
               cbo회수사원.SelectedValue= dgv.Rows[e.RowIndex].Cells["R_회수사원"].Value.ToString();
               dtp회수일자.Value=DateTime.Parse(dgv.Rows[e.RowIndex].Cells["R_회수일자"].Value.ToString());

           }
           else if (dgv.Rows[e.RowIndex].Cells["R_전표상태"].Value.ToString() == "반품완료")
           {
               cbo완료사원.SelectedValue = dgv.Rows[e.RowIndex].Cells["R_완료사원"].Value.ToString();
               dtp완료일자.Value = DateTime.Parse(dgv.Rows[e.RowIndex].Cells["R_완료일자"].Value.ToString());
           }
           outputDetail2();
         
        }

        private void outputDetail2()
        {
            itemOutGrid.Rows.Clear();
            wnDm wDm = new wnDm();
            DataTable dt = null;
            dt = wDm.fn_반품디테일_List("where A.RETURN_DATE = '" + txt_return_date.Text.ToString() + "' and A.RETURN_NUM = '" + txt_retrun_cd.Text.ToString() + "' ");

            this.itemOutGrid.RowCount = dt.Rows.Count;
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    itemOutGrid.Rows[i].Cells["O_SPEC"].Value = dt.Rows[i]["SPEC"].ToString();
                    itemOutGrid.Rows[i].Cells["O_NO"].Value = dt.Rows[i]["SALE_SEQ"].ToString();
                    itemOutGrid.Rows[i].Cells["O_ITEM_CD"].Value = dt.Rows[i]["ITEM_CD"].ToString();
                    itemOutGrid.Rows[i].Cells["O_ITEM_NM"].Value = dt.Rows[i]["ITEM_NM"].ToString();
                    itemOutGrid.Rows[i].Cells["O_UNIT_CD"].Value = dt.Rows[i]["UNIT_CD"].ToString();
                    itemOutGrid.Rows[i].Cells["O_UNIT_NM"].Value = dt.Rows[i]["UNIT_NM"].ToString();
                    itemOutGrid.Rows[i].Cells["최종매출일"].Value = DateTime.Parse(dt.Rows[i]["LAST_DATE"].ToString());
                    itemOutGrid.Rows[i].Cells["비고"].Value = dt.Rows[i]["COMMENT"].ToString();
                    itemOutGrid.Rows[i].Cells["매출구분"].Value = dt.Rows[i]["SALE_GB"].ToString();

                    itemOutGrid.Rows[i].Cells["TOTAL_AMT"].Value = (decimal.Parse(dt.Rows[i]["SALE_QTY"].ToString())).ToString("#,0.######");
                    itemOutGrid.Rows[i].Cells["PRICE"].Value = (decimal.Parse(dt.Rows[i]["SALE_PRICE"].ToString())).ToString("#,0.######");
                    itemOutGrid.Rows[i].Cells["TOTAL_MONEY"].Value = (decimal.Parse(dt.Rows[i]["SALE_AMT"].ToString())).ToString("#,0.######");
                }
            }
        }
        public static bool grdHeaderNoAction(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return false;
            }
            else return true;
        }

        private void output_del()
        {

            ComInfo comInfo = new ComInfo();
            DialogResult msgOk = comInfo.deleteConfrim("반품등록삭제", txt_return_date.Text.ToString() + " - " + txt_retrun_cd.Text.ToString());

            if (msgOk == DialogResult.No)
            {
                return;
            }

        

            wnDm wDm = new wnDm();
            int rsNum = wDm.반품등록삭제(txt_return_date.Text.ToString(), txt_retrun_cd.Text.ToString());
            if (rsNum == 0)
            {
                resetSetting();
               
                MessageBox.Show("성공적으로 삭제하였습니다.");

               
            }
            else if (rsNum == 1)
            {
                MessageBox.Show("삭제에 실패하였습니다.");
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
            string name = itemOutGrid.CurrentCell.OwningColumn.Name;

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

        private void txt_bar_KeyPress(object sender, KeyPressEventArgs e)
        {
           

               
        }

        private void btn_minus_Click(object sender, EventArgs e)
        {
            ///행삭제 했을때 선택삭제되는 데이터와 
            ///출고예정리스트와 비교하여 
            ///visible =true 해주어서   false였던 데이터를  다시생기는것처럼 보여주게한다 
            
            for (int i = 0; i < itemOutGrid.Rows.Count; i++)
            {
                if (
                      (String)itemOutGrid.SelectedRows[0].Cells["O_LOT_NO"].Value == (String)dgv배송완료.Rows[i].Cells["LOT_NO"].Value
                      && (String)itemOutGrid.SelectedRows[0].Cells["O_LOT_SUB"].Value == (String)dgv배송완료.Rows[i].Cells["LOT_SUB"].Value
                      && (String)itemOutGrid.SelectedRows[0].Cells["O_ITEM_CD"].Value == (String)dgv배송완료.Rows[i].Cells["ITEM_CD"].Value
                      && (String)itemOutGrid.SelectedRows[0].Cells["O_ITEM_NM"].Value == (String)dgv배송완료.Rows[i].Cells["ITEM_NM"].Value
                      && (String)itemOutGrid.SelectedRows[0].Cells["OUTPUT_AMT"].Value == (String)dgv배송완료.Rows[i].Cells["STOCK_AMT"].Value
                    )
                {


                    dgv배송완료.Rows[i].Visible = true;

                }
            }




            if (itemOutGrid.Rows.Count > 0)
            {
                if (itemOutGrid.Rows[itemOutGrid.CurrentCell.RowIndex].Cells["SEQ"].Value != null && !itemOutGrid.Rows[itemOutGrid.CurrentCell.RowIndex].Cells["SEQ"].Value.ToString().Equals(""))
                {
                    del_outGrid.Rows.Add();
                    del_outGrid.Rows[del_outGrid.Rows.Count - 1]["SEQ"] = itemOutGrid.Rows[itemOutGrid.CurrentCell.RowIndex].Cells["SEQ"].Value;
                    del_outGrid.Rows[del_outGrid.Rows.Count - 1]["J_SEQ"] = itemOutGrid.Rows[itemOutGrid.CurrentCell.RowIndex].Cells["J_INPUT_SEQ"].Value;
                    del_outGrid.Rows[del_outGrid.Rows.Count - 1]["LOT_NO"] = itemOutGrid.Rows[itemOutGrid.CurrentCell.RowIndex].Cells["O_LOT_NO"].Value;
                    del_outGrid.Rows[del_outGrid.Rows.Count - 1]["LOT_SUB"] = itemOutGrid.Rows[itemOutGrid.CurrentCell.RowIndex].Cells["O_LOT_SUB"].Value;
                }


                itemOutGrid.Rows.RemoveAt(itemOutGrid.CurrentCell.RowIndex);
            }
        }

        private void txt_cust_nm_TextChanged(object sender, EventArgs e)
        {

        }

        private void frm반품등록_Enter(object sender, EventArgs e)
        {
            btnSrch.PerformClick();
        }

        private void btnSerch_Click(object sender, EventArgs e)
        {
            item_out_detail("");
        }

        private void cbo반품상태_SelectedValueChanged(object sender, EventArgs e)
        {
           

          
        }

        private void dgv배송완료_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            resetSetting();
            txt_cust_cd.Text = dgv배송완료.Rows[e.RowIndex].Cells["D거래처코드"].Value.ToString();
            txt_cust_nm.Text = dgv배송완료.Rows[e.RowIndex].Cells["D거래처"].Value.ToString();

            itemOutGrid.Rows.Clear();
            str주문일자 = dgv배송완료.Rows[e.RowIndex].Cells["D주문일자"].Value.ToString();
            str주문번호 = dgv배송완료.Rows[e.RowIndex].Cells["D주문번호"].Value.ToString();
            str배송일자 = dgv배송완료.Rows[e.RowIndex].Cells["D배송일자"].Value.ToString();
            str배송번호 = dgv배송완료.Rows[e.RowIndex].Cells["D배송번호"].Value.ToString();
           // str항목순번 = dgv배송완료.Rows[e.RowIndex].Cells["H항목순번"].Value.ToString();
            //str주문시간 = dgv배송완료.Rows[e.RowIndex].Cells["D주문시간"].Value.ToString();

            cbo담당자.SelectedValue = dgv배송완료.Rows[e.RowIndex].Cells["D담당사원코드"].Value.ToString();
           // cbo배송사원.SelectedValue = dgv배송완료.Rows[e.RowIndex].Cells["D배송사원코드"].Value.ToString();
            

          
         


            DataTable dt = wnDm.fn_주문항목_List(" where A.ORD_DATE='" + str주문일자 + "' and A.ORD_NUM='" + str주문번호 + "'");
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    itemOutGrid.Rows.Add();
                    //   dgv주문등록.Rows[i].Cells["P_PLAN_DATE"].Value = dt.Rows[i]["ORD_DATE"].ToString();
                    //  dgv주문등록.Rows[i].Cells["P_PLAN_CD"].Value = dt.Rows[i]["ORD_NUM"].ToString();
                    itemOutGrid.Rows[i].Cells["O_SPEC"].Value = dt.Rows[i]["SPEC"].ToString();
                    itemOutGrid.Rows[i].Cells["O_NO"].Value = dt.Rows[i]["ORD_SEQ"].ToString();
                    itemOutGrid.Rows[i].Cells["O_ITEM_CD"].Value = dt.Rows[i]["ITEM_CD"].ToString();
                    itemOutGrid.Rows[i].Cells["O_ITEM_NM"].Value = dt.Rows[i]["ITEM_NM"].ToString();
                    itemOutGrid.Rows[i].Cells["O_UNIT_CD"].Value = dt.Rows[i]["UNIT_CD"].ToString();
                    itemOutGrid.Rows[i].Cells["O_UNIT_NM"].Value = dt.Rows[i]["UNIT_NM"].ToString();
                    itemOutGrid.Rows[i].Cells["최종매출일"].Value = DateTime.Parse(dt.Rows[i]["LAST_DATE"].ToString());
                    itemOutGrid.Rows[i].Cells["비고"].Value = dt.Rows[i]["COMMENT"].ToString();
                    itemOutGrid.Rows[i].Cells["매출구분"].Value = dt.Rows[i]["SALE_GB"].ToString();



                    itemOutGrid.Rows[i].Cells["TOTAL_AMT"].Value = (decimal.Parse(dt.Rows[i]["ORD_QTY"].ToString())).ToString("#,0.######");
                    itemOutGrid.Rows[i].Cells["PRICE"].Value = (decimal.Parse(dt.Rows[i]["ORD_PRICE"].ToString())).ToString("#,0.######");
                    itemOutGrid.Rows[i].Cells["TOTAL_MONEY"].Value = (decimal.Parse(dt.Rows[i]["ORD_AMT"].ToString())).ToString("#,0.######");

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        private void cbo반품상태_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbo반품상태.SelectedValue.ToString())
            {

                case "3":

                    lbl완료사원.Visible = true;
                    cbo완료사원.Visible = true;
                    dtp완료일자.Visible = true;
                    lbl완료일자.Visible = true;
                     lbl회수사원.Visible = true;
                    cbo회수사원.Visible = true;
                    dtp회수일자.Visible = true;
                    lbl회수일자.Visible = true;
                    break;
                case "2":
                    lbl회수사원.Visible = true;
                    cbo회수사원.Visible = true;
                    dtp회수일자.Visible = true;
                    lbl회수일자.Visible = true;
                    break;
               
                default:

                    lbl완료사원.Visible = false;
                    cbo완료사원.Visible = false;
                    dtp완료일자.Visible = false;
                    lbl완료일자.Visible = false;
                    lbl회수사원.Visible = false;
                    cbo회수사원.Visible = false;
                    dtp회수일자.Visible = false;
                    lbl회수일자.Visible = false;
                    break;
            }
        }

        private void btn배송완료_Click(object sender, EventArgs e)
        {
            item_out_detail("and A.ORD_DATE >= '" + dtp스타트.Text.ToString() + "' and  A.ORD_DATE <= '" + dtp앤드.Text.ToString() + "'");
        }
    }
}
