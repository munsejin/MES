
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
using System.Collections;
using System.Data.SqlClient;

namespace MES.P40_ITM
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
    public partial class frm제품출고등록 : Form
    {
        private wnGConstant wConst = new wnGConstant();
        private DataTable del_outGrid = new DataTable();
        wnDm wnDm = new wnDm();
        private bool bHeadCheck = false;
        private string old_cust_nm = "";
        string condition = "";
        private bool[] right = new bool[2];

        Popup.frmPrint readyPrt = new Popup.frmPrint();

        DataTable adoPrt = null;
        DataTable adoPrt2 = null;
        wnAdo wAdo = new wnAdo();
        public Popup.frmPrint frmPrt;


        private bool is_soo_inserted = false;


        public frm제품출고등록()
        {
            InitializeComponent();

            this.itemOutGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellEndEdit);
            this.itemOutGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grid_KeyDown);
            this.itemOutGrid.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grid_ColumnHeaderMouseClick);

            this.itemOutGrid.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.grid_RowsAdded);
            this.itemOutGrid.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.grid_RowsRemoved);
            this.itemOutGrid.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.grid_EditingControlShowing);

        }

        private void frm제품출고등록_Load(object sender, EventArgs e)
        {
            lbl_title.Tag = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[0] + "$" + wnDm.fn_TitleName(this.Name.ToString()).Split('$')[1]; 
            lbl_title.Text = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[2];
            right = wConst.btnRight(lbl_title.Tag.ToString());
            init_ComboBox();
            addButton(txt_cust_nm, 0);
            addButton(txtITEM, 1);
            itemStockGrid.Columns["CHK"].ReadOnly = false;

            SendKeys.Send("{TAB}");
            SendKeys.Send("{TAB}");
            SendKeys.Send("{TAB}");
            SendKeys.Send("{TAB}");
            SendKeys.Send("{TAB}");
            SendKeys.Send("{TAB}");
            SendKeys.Send("{TAB}");
            SendKeys.Send("{TAB}");
            SendKeys.Send("{TAB}");
            SendKeys.Send("{TAB}");
            SendKeys.Send("{TAB}");
            SendKeys.Send("{TAB}");
            SendKeys.Send("{TAB}");



            for (int i = 0; i < itemStockGrid.ColumnCount; i++)
            {
                itemStockGrid.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }


            del_outGrid.Columns.Add("LOT_NO");
            del_outGrid.Columns.Add("LOT_SUB");
            del_outGrid.Columns.Add("SEQ");
            del_outGrid.Columns.Add("J_SEQ");
            del_outGrid.Columns.Add("OLD_TOTAL_AMT");

            output_list(tdOutGridTemp, "where convert(varchar(10), A.INTIME, 120) = convert(varchar(10), getDate(), 120) ");

            item_out_detail("");


        }

        #region item out button logic

        private void btnNew_Click(object sender, EventArgs e)
        {
            resetSetting();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (right[0])
            {
                outputLogic();

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
                resetSetting();
                txt_cust_cd.Text = frm.sCode.Trim();
                txt_cust_nm.Text = frm.sName.Trim();
                txt_vat_cd.Text = frm.sVatCd.Trim();
                old_cust_nm = frm.sCode.Trim();
                txt_jumun_date.Text = "";
                txt_jumun_cd.Text = "";
                txt_jumun_comment.Text = "";
                lbl_jumun_date.Enabled = false;
                lbl_jumun_cd.Enabled = false;
                lbl_jumun_comment.Enabled = false;
                lbl_cust_nm.BackColor = Color.AliceBlue;
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
            Popup.pop_sf_제품검색 frm = new Popup.pop_sf_제품검색();
            wnDm wDm = new wnDm();
            DataTable dt = new DataTable();
            dt = wDm.fn_Item_List("where ITEM_NM like '%" + txtitemSrch.Text.ToString() + "%' ");


            frm.dt = dt;
            frm.txtSrch.Text = txtITEM.Text.ToString();
            frm.ShowDialog();

            if (frm.sCode != "")
            {
                txtitemSrch.Text = frm.sCode.Trim();

                txtITEM.Text = frm.sName.Trim();
                old_item_nm = frm.sName.Trim();
            }
            else
            {
                // txt_item_nm.Text = old_item_nm;
            }
        }

        private void btn_move_Click(object sender, EventArgs e)
        {
            if (itemStockGrid.Rows.Count > 0)
            {
                int chk = 0;
                for (int i = 0; i < itemStockGrid.Rows.Count; i++)
                {
                    if ((bool)itemStockGrid.Rows[i].Cells["CHK"].Value == true)
                    {
                        for (int j = 0; j < itemOutGrid.Rows.Count; j++)
                        {
                            //if ((string)itemStockGrid.Rows[i].Cells["LOT_NO"].Value == (string)itemOutGrid.Rows[j].Cells["O_LOT_NO"].Value
                            //    && (string)itemStockGrid.Rows[i].Cells["LOT_SUB"].Value == (string)itemOutGrid.Rows[j].Cells["O_LOT_SUB"].Value
                            //    && (string)itemStockGrid.Rows[i].Cells["INPUT_SEQ"].Value == (string)itemOutGrid.Rows[j].Cells["O_INPUT_SEQ"].Value)
                            //{
                            //    MessageBox.Show("해당 출고할 제품이 이미 등록되어있습니다.");
                            //    return;
                            //}
                        }

                        for (int k = 0; k < del_outGrid.Rows.Count; k++)
                        {
                            if ((string)itemStockGrid.Rows[i].Cells["LOT_NO"].Value == (string)del_outGrid.Rows[k]["LOT_NO"].ToString()
                                && (string)itemStockGrid.Rows[i].Cells["LOT_SUB"].Value == (string)del_outGrid.Rows[k]["LOT_SUB"].ToString())
                            {
                                MessageBox.Show("해당 제품출고의 삭제데이터가 있어서 등록이 불가합니다.");
                                return;
                            }
                        }

                        if (txt_cust_nm.Text != "")
                        {
                            if (txt_cust_nm.Text != itemStockGrid.Rows[i].Cells["납품처"].Value.ToString() && 
                                (itemStockGrid.Rows[i].Cells["납품처"].Value != null && !itemStockGrid.Rows[i].Cells["납품처"].Value.ToString().Equals(""))
                                )
                            {
                                //MessageBox.Show("다른거래처는 등록할수 없습니다.");
                                //return;
                            }
                        }

                        if (txt_jumun_cd.Text != null && txt_jumun_cd.Text != "")
                        {
                            int row_index = -1;
                            for (int j = 0; j < itemOutGrid.Rows.Count; j++)
                            {
                                if (itemStockGrid.Rows[i].Cells["ITEM_CD"].Value.ToString().Equals(itemOutGrid.Rows[j].Cells["O_ITEM_CD"].Value.ToString()))
                                {
                                    if (itemOutGrid.Rows[j].Cells["O_LOT_NO"].Value == null || itemOutGrid.Rows[j].Cells["O_LOT_NO"].Value.ToString().Equals(""))
                                    {
                                        row_index = j;
                                        break;
                                    }
                                }
                            } 

                            if (row_index != -1)
                            {
                                decimal Jumun_amt = decimal.Parse(itemOutGrid.Rows[row_index].Cells["OUTPUT_AMT"].Value.ToString().Replace(",", ""));
                                decimal stock_amt = decimal.Parse(itemStockGrid.Rows[i].Cells["STOCK_AMT"].Value.ToString().Replace(",", ""));

                                itemOutGrid.Rows[row_index].DefaultCellStyle.BackColor = Color.White;
                                itemOutGrid.Rows[row_index].DefaultCellStyle.SelectionBackColor = Color.LightYellow;
                                itemOutGrid.Rows[row_index].Cells["O_LOT_NO"].Value = itemStockGrid.Rows[i].Cells["LOT_NO"].Value.ToString();
                                itemOutGrid.Rows[row_index].Cells["O_LOT_SUB"].Value = itemStockGrid.Rows[i].Cells["LOT_SUB"].Value.ToString();
                                itemOutGrid.Rows[row_index].Cells["O_INPUT_DATE"].Value = itemStockGrid.Rows[i].Cells["INPUT_DATE"].Value.ToString();
                                itemOutGrid.Rows[row_index].Cells["O_INPUT_CD"].Value = itemStockGrid.Rows[i].Cells["INPUT_CD"].Value.ToString();
                                itemOutGrid.Rows[row_index].Cells["O_INPUT_SEQ"].Value = itemStockGrid.Rows[i].Cells["INPUT_SEQ"].Value.ToString();
                                itemOutGrid.Rows[row_index].Cells["OLD_OUT_AMT"].Value = itemStockGrid.Rows[i].Cells["STOCK_AMT"].Value.ToString();

                                chk = 1;

                                if (Jumun_amt > stock_amt)
                                {
                                    itemOutGrid.Rows[row_index].Cells["OUTPUT_AMT"].Value = stock_amt.ToString("#,0.######");
                                    wConst.f_Calc_Price(itemOutGrid, row_index, "OUTPUT_AMT", "PRICE");
                                    wConst.f_Calc_Price(itemOutGrid, row_index, "OUTPUT_AMT", "PRICE", "TOTAL_MONEY", "O_SUPPLY_MONEY", "O_TAX_MONEY", "O_TOTAL_MONEY", txt_vat_cd.Text, itemOutGrid.Rows[row_index].Cells["O_TAX_CD"].Value.ToString());
                                    wConst.f_Calc_SalesPrice(txt_supply_money
                                    , txt_tax_money
                                    , txt_total_money
                                    , txt_vat_cd.Text
                                    , txt_no_tax_money
                                    , txt_yes_tax_money
                                    , txt_yesno_money
                                    , itemOutGrid
                                    , "O_SUPPLY_MONEY"
                                    , "O_TAX_MONEY"
                                    , "O_TOTAL_MONEY"
                                    , "O_TAX_CD"
                                    , true
                                    , "O_LOT_NO"
                                    );
                                    string new_row_amt = (Jumun_amt - stock_amt).ToString("#,0.######");

                                    itemOutGrid.Rows.Insert(row_index + 1, 1);

                                    for (int k = 0; k < itemOutGrid.ColumnCount; k++)
                                    {
                                        itemOutGrid.Rows[row_index + 1].Cells[k].Value = itemOutGrid.Rows[row_index].Cells[k].Value;
                                    }

                                    itemOutGrid.Rows[row_index + 1].Cells[1].Value = row_index + 2;
                                    itemOutGrid.Rows[row_index + 1].Cells["O_LOT_NO"].Value = "";
                                    itemOutGrid.Rows[row_index + 1].Cells["O_LOT_SUB"].Value = "";
                                    itemOutGrid.Rows[row_index + 1].Cells["O_INPUT_DATE"].Value = "";
                                    itemOutGrid.Rows[row_index + 1].Cells["O_INPUT_CD"].Value = "";
                                    itemOutGrid.Rows[row_index + 1].Cells["O_INPUT_SEQ"].Value = "";
                                    itemOutGrid.Rows[row_index + 1].Cells["OUTPUT_AMT"].Value = (Jumun_amt - stock_amt).ToString("#,0.######");
                                    itemOutGrid.Rows[row_index + 1].Cells["OLD_OUT_AMT"].Value = "";
                                    itemOutGrid.Rows[row_index + 1].DefaultCellStyle.BackColor = Color.MistyRose;
                                    itemOutGrid.Rows[row_index + 1].DefaultCellStyle.SelectionBackColor = Color.MistyRose;

                                    wConst.f_Calc_Price(itemOutGrid, row_index + 1, "OUTPUT_AMT", "PRICE");
                                    wConst.f_Calc_Price(itemOutGrid, row_index + 1, "OUTPUT_AMT", "PRICE", "TOTAL_MONEY", "O_SUPPLY_MONEY", "O_TAX_MONEY", "O_TOTAL_MONEY", txt_vat_cd.Text, itemOutGrid.Rows[row_index + 1].Cells["O_TAX_CD"].Value.ToString());
                                    wConst.f_Calc_SalesPrice(txt_supply_money
                                    , txt_tax_money
                                    , txt_total_money
                                    , txt_vat_cd.Text
                                    , txt_no_tax_money
                                    , txt_yes_tax_money
                                    , txt_yesno_money
                                    , itemOutGrid
                                    , "O_SUPPLY_MONEY"
                                    , "O_TAX_MONEY"
                                    , "O_TOTAL_MONEY"
                                    , "O_TAX_CD"
                                    , true
                                    , "O_LOT_NO"
                                    );


                                    itemOutGrid.Focus();
                                    itemStockGrid.Rows[i].Visible = false;
                                    itemStockGrid.Rows[i].Cells["CHK"].Value = false;
                                }
                                else
                                {
                                    itemOutGrid.Focus();
                                    itemStockGrid.Rows[i].Visible = false;
                                    itemStockGrid.Rows[i].Cells["CHK"].Value = false;
                                }
                                
                            }
                            else
                            {
                                chk = Up_Stock_to_OutGrid(chk, i);
                            }
                        }
                        else
                        {
                            chk = Up_Stock_to_OutGrid(chk, i);
                        }
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



        private int Up_Stock_to_OutGrid(int chk, int i)
        {
            itemOutGrid.Rows.Add();
            int rowNum = itemOutGrid.Rows.Count - 1;
            if (!itemStockGrid.Rows[i].Cells["납품처"].Value.ToString().Equals("자체생산"))
            {
                txt_cust_nm.Text = (String)itemStockGrid.Rows[i].Cells["납품처"].Value;
                txt_cust_cd.Text = (String)itemStockGrid.Rows[i].Cells["납품처코드"].Value;
            }
            itemOutGrid.Rows[rowNum].Cells["O_LOT_NO"].Value = itemStockGrid.Rows[i].Cells["LOT_NO"].Value;
            itemOutGrid.Rows[rowNum].Cells["O_LOT_SUB"].Value = itemStockGrid.Rows[i].Cells["LOT_SUB"].Value;
            itemOutGrid.Rows[rowNum].Cells["O_ITEM_CD"].Value = itemStockGrid.Rows[i].Cells["ITEM_CD"].Value;
            itemOutGrid.Rows[rowNum].Cells["O_ITEM_NM"].Value = itemStockGrid.Rows[i].Cells["ITEM_NM"].Value;
            itemOutGrid.Rows[rowNum].Cells["OUTPUT_AMT"].Value = itemStockGrid.Rows[i].Cells["STOCK_AMT"].Value;
            itemOutGrid.Rows[rowNum].Cells["O_SPEC"].Value = itemStockGrid.Rows[i].Cells["SPEC"].Value;
            itemOutGrid.Rows[rowNum].Cells["PRICE"].Value = itemStockGrid.Rows[i].Cells["OUTPUT_PRICE"].Value;
            itemOutGrid.Rows[rowNum].Cells["O_UNIT_CD"].Value = itemStockGrid.Rows[i].Cells["UNIT_CD"].Value;
            itemOutGrid.Rows[rowNum].Cells["O_UNIT_NM"].Value = itemStockGrid.Rows[i].Cells["UNIT_NM"].Value;
            itemOutGrid.Rows[rowNum].Cells["OLD_OUT_AMT"].Value = itemStockGrid.Rows[i].Cells["STOCK_AMT"].Value;
            double total_money = double.Parse(itemStockGrid.Rows[i].Cells["STOCK_AMT"].Value.ToString()) * double.Parse(itemStockGrid.Rows[i].Cells["OUTPUT_PRICE"].Value.ToString());
            itemOutGrid.Rows[rowNum].Cells["TOTAL_MONEY"].Value = total_money.ToString("#,0.###");
            itemOutGrid.Rows[rowNum].Cells["O_INPUT_DATE"].Value = itemStockGrid.Rows[i].Cells["INPUT_DATE"].Value;
            itemOutGrid.Rows[rowNum].Cells["O_INPUT_CD"].Value = itemStockGrid.Rows[i].Cells["INPUT_CD"].Value;
            itemOutGrid.Rows[rowNum].Cells["O_CUST_CD"].Value = txt_cust_cd.Text.ToString();
            itemOutGrid.Rows[rowNum].Cells["O_TAX_CD"].Value = itemStockGrid.Rows[i].Cells["TAX_CD"].Value;
            txt_vat_cd.Text = itemStockGrid.Rows[i].Cells["부가세코드"].Value.ToString();
            itemOutGrid.Rows[rowNum].Cells["O_LINK_CD"].Value = itemStockGrid.Rows[i].Cells["LINK_CD"].Value;
            itemOutGrid.Rows[rowNum].Cells["O_INPUT_SEQ"].Value = itemStockGrid.Rows[i].Cells["INPUT_SEQ"].Value;

            chk = 1;
            wConst.f_Calc_Price(itemOutGrid, rowNum, "OUTPUT_AMT", "PRICE");
            wConst.f_Calc_Price(itemOutGrid, rowNum, "OUTPUT_AMT", "PRICE", "TOTAL_MONEY", "O_SUPPLY_MONEY", "O_TAX_MONEY", "O_TOTAL_MONEY", txt_vat_cd.Text, itemOutGrid.Rows[rowNum].Cells["O_TAX_CD"].Value.ToString());
            wConst.f_Calc_SalesPrice(txt_supply_money
                                    , txt_tax_money
                                    , txt_total_money
                                    , txt_vat_cd.Text
                                    , txt_no_tax_money
                                    , txt_yes_tax_money
                                    , txt_yesno_money
                                    , itemOutGrid
                                    , "O_SUPPLY_MONEY"
                                    , "O_TAX_MONEY"
                                    , "O_TOTAL_MONEY"
                                    , "O_TAX_CD"
                                    , true
                                    , "O_LOT_NO"
                                    );

            itemOutGrid.Focus();
            itemStockGrid.Rows[i].Visible = false;
            itemStockGrid.Rows[i].Cells["CHK"].Value = false;
            btnSerch.PerformClick();

            return chk;
        }

        private void DataGridViewAddRow(DataGridView dgv, int add_Loc)
        {
            List<string> rowValues = new List<string>();

            DataTable dt = (DataTable)(itemOutGrid.DataSource);

            if (dgv.SelectedRows.Count > 0)
            {
                for (int i = 0; i <= dgv.ColumnCount - 1; i++)
                {
                    rowValues.Add(dgv[i, add_Loc].Value.ToString());
                }

                DataRow dr = dt.NewRow();

                dr.ItemArray = rowValues.ToArray();
                dt.Rows.InsertAt(dr, add_Loc);
            }
            dgv.DataSource = dt;
        }

        private void btnSrch_Click(object sender, EventArgs e)
        {
            output_list(outputGrid, "where A.OUTPUT_DATE >= '" + txt_start_date.Text.ToString() + "' and  A.OUTPUT_DATE <= '" + txt_end_date.Text.ToString() + "'");
            item_out_detail("");
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

            cmb_soo_gubun.ValueMember = "코드";
            cmb_soo_gubun.DisplayMember = "명칭";
            sqlQuery = comInfo.querySooGubun();
            wConst.ComboBox_Read_Blank(cmb_soo_gubun, sqlQuery);

        }

        private void item_out_detail(string condition)
        {
            wnDm wDm = new wnDm();
            DataTable dt = null;

            //if (txt_cust_cd.Text != null && txt_cust_cd.Text != "")
            //{
            //    condition += " and (D.CUST_CD = '" + txt_cust_cd.Text.ToString() + "' OR D.CUST_CD is null OR D.CUST_CD = '') "; //2020 정훈 조건절 추가 -> 입고확정된 것만 표시
            //}

            if (condition.Equals("1")) condition = "";

            if (txtITEM.Text != "")
            {
                condition += " and A.ITEM_CD = '" + txtitemSrch.Text.ToString() + "'  "; 
            }

            if (!txt_cust_cd.Text.ToString().Equals(""))
            {
                condition += " and (D.CUST_CD = '"+txt_cust_cd.Text.ToString()+"' or D.CUST_CD = '' ) ";
            }

            if (txt_jumun_cd.Text != null && txt_jumun_cd.Text != "" && btn_jumun_select.Enabled == true)
            {
                if (itemOutGrid.Rows.Count > 0)
                {
                    condition += " and ( ";
                    for (int i = 0; i < itemOutGrid.Rows.Count; i++)
                    {
                        if (i == 0)
                        {
                            condition += " A.ITEM_CD = '" + itemOutGrid.Rows[i].Cells["O_ITEM_CD"].Value.ToString() + "' ";
                        }
                        else
                        {
                            condition += " or A.ITEM_CD = '" + itemOutGrid.Rows[i].Cells["O_ITEM_CD"].Value.ToString() + "' ";
                        }
                    }
                    condition += " ) ";
                }
            }

            

            dt = wDm.fn_Item_In_Stock_List(condition);

            itemStockGrid.Rows.Clear();
            if (dt != null && dt.Rows.Count > 0)
            {
                itemStockGrid.RowCount = dt.Rows.Count;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    itemStockGrid.Rows[i].Cells["LOT_NO"].Value = dt.Rows[i]["LOT_NO"].ToString();
                    itemStockGrid.Rows[i].Cells["수주번호"].Value = dt.Rows[i]["PLAN_NUM"].ToString();
                    itemStockGrid.Rows[i].Cells["LOT_SUB"].Value = dt.Rows[i]["LOT_SUB"].ToString();
                    itemStockGrid.Rows[i].Cells["INPUT_DATE"].Value = dt.Rows[i]["INPUT_DATE"].ToString();
                    itemStockGrid.Rows[i].Cells["INPUT_CD"].Value = dt.Rows[i]["INPUT_CD"].ToString();
                    itemStockGrid.Rows[i].Cells["ITEM_CD"].Value = dt.Rows[i]["ITEM_CD"].ToString();
                    itemStockGrid.Rows[i].Cells["ITEM_NM"].Value = dt.Rows[i]["ITEM_NM"].ToString();
                    itemStockGrid.Rows[i].Cells["INPUT_AMT"].Value = dt.Rows[i]["INPUT_AMT"].ToString();
                    itemStockGrid.Rows[i].Cells["OUT_AMT"].Value = (decimal.Parse(dt.Rows[i]["OUTPUT_AMT"].ToString())).ToString("#,0.###");
                    itemStockGrid.Rows[i].Cells["STOCK_AMT"].Value = (decimal.Parse(dt.Rows[i]["STOCK_AMT"].ToString())).ToString("#,0.###");
                    itemStockGrid.Rows[i].Cells["SPEC"].Value = dt.Rows[i]["SPEC"].ToString();
                    itemStockGrid.Rows[i].Cells["OUTPUT_PRICE"].Value = (decimal.Parse(dt.Rows[i]["OUTPUT_PRICE"].ToString())).ToString("#,0.###");
                    itemStockGrid.Rows[i].Cells["UNIT_CD"].Value = dt.Rows[i]["UNIT_CD"].ToString();
                    itemStockGrid.Rows[i].Cells["UNIT_NM"].Value = dt.Rows[i]["UNIT_NM"].ToString();
                    itemStockGrid.Rows[i].Cells["TAX_CD"].Value = dt.Rows[i]["TAX_CD"].ToString();
                    itemStockGrid.Rows[i].Cells["부가세코드"].Value = dt.Rows[i]["VAT_CD"].ToString();
                    itemStockGrid.Rows[i].Cells["LINK_CD"].Value = dt.Rows[i]["LINK_CD"].ToString();
                    if (dt.Rows[i]["CUST_CD"].ToString().Equals(""))
                    {
                        itemStockGrid.Rows[i].Cells["납품처"].Value = "자체생산";
                        itemStockGrid.Rows[i].Cells["납품처코드"].Value = "";
                    }
                    else
                    {
                        itemStockGrid.Rows[i].Cells["납품처"].Value = dt.Rows[i]["CUST_NM"].ToString();
                        itemStockGrid.Rows[i].Cells["납품처코드"].Value = dt.Rows[i]["CUST_CD"].ToString();
                    }
                    itemStockGrid.Rows[i].Cells["INPUT_SEQ"].Value = dt.Rows[i]["INPUT_SEQ"].ToString();

                    itemStockGrid.Rows[i].Cells["CHK"].Value = false;

                    for (int j = 0; j < itemOutGrid.Rows.Count; j++)
                    {
                        if (itemOutGrid.Rows[j].Cells["O_INPUT_DATE"].Value.ToString().Equals(itemStockGrid.Rows[i].Cells["INPUT_DATE"].Value.ToString())
                            && itemOutGrid.Rows[j].Cells["O_INPUT_CD"].Value.ToString().Equals(itemStockGrid.Rows[i].Cells["INPUT_CD"].Value.ToString())
                            && itemOutGrid.Rows[j].Cells["O_LOT_NO"].Value.ToString().Equals(itemStockGrid.Rows[i].Cells["LOT_NO"].Value.ToString())
                            && itemOutGrid.Rows[j].Cells["O_LOT_SUB"].Value.ToString().Equals(itemStockGrid.Rows[i].Cells["LOT_SUB"].Value.ToString())
                            )
                        {
                            itemStockGrid.Rows[i].Visible = false;
                        }
                    }


                }
            }
        }

        private void outputLogic()
        {

            try
            {
                if (cmb_stor.SelectedValue == null) cmb_stor.SelectedValue = "";

                if (chk_self_yn.Checked == false)
                {
                    if (txt_cust_cd.Text.ToString().Equals(""))
                    {
                        MessageBox.Show("거래처를 선택하시기 바랍니다.");
                        return;
                    }
                }

                //if (cmb_stor.SelectedValue.ToString().Equals("")) 
                //{
                //    MessageBox.Show("창고를 선택하시기 바랍니다.");
                //    return;
                //}

                //if(txt_jumun_date.Text != null && !txt_jumun_date.Text.ToString().Equals(""))
                //{
                    ArrayList underRow = new ArrayList();
                    ArrayList overRow = new ArrayList();

                    for (int i = 0; i < itemOutGrid.Rows.Count; i++)
                    {
                        if (itemOutGrid.Rows[i].Cells["O_LOT_NO"].Value == null || itemOutGrid.Rows[i].Cells["O_LOT_NO"].Value.ToString().Equals(""))
                        {
                            underRow.Add(i);
                        }
                        else
                        {
                            decimal oldamt = 0;
                            if (itemOutGrid.Rows[i].Cells["OLD_OUT_AMT"].Value == null || itemOutGrid.Rows[i].Cells["OLD_OUT_AMT"].Value.ToString().Equals(""))
                            {
                                oldamt = 0;
                            }
                            else
                            {
                                oldamt = decimal.Parse(itemOutGrid.Rows[i].Cells["OLD_OUT_AMT"].Value.ToString());
                            }
                            if (decimal.Parse(itemOutGrid.Rows[i].Cells["OUTPUT_AMT"].Value.ToString()) > oldamt)
                            {
                                overRow.Add(i);
                            }
                        }
                    }

                    if (overRow.Count > 0)
                    {
                        string warningMsg = "출고 가능수량보다 초과 입력하였습니다.\n\n";
                        for (int i = 0; i < overRow.Count; i++)
                        {
                            if (i == 0)
                            {
                                warningMsg += "<초과입력 항목>\n";
                            }
                            decimal oldamt = 0;

                            if (itemOutGrid.Rows[(int)overRow[i]].Cells["OLD_OUT_AMT"].Value == null || itemOutGrid.Rows[(int)overRow[i]].Cells["OLD_OUT_AMT"].Value.ToString().Equals(""))
                            {
                                oldamt = 0;
                            }
                            else
                            {
                                oldamt = decimal.Parse(itemOutGrid.Rows[(int)overRow[i]].Cells["OLD_OUT_AMT"].Value.ToString());
                            }

                            string overAmt = (decimal.Parse(itemOutGrid.Rows[(int)overRow[i]].Cells["OUTPUT_AMT"].Value.ToString()) - oldamt).ToString("#,0.######");
                            warningMsg += ((int)overRow[i]+1)+"행 "+itemOutGrid.Rows[(int)overRow[i]].Cells["O_ITEM_NM"].Value.ToString()
                                + " (" + overAmt + itemOutGrid.Rows[(int)overRow[i]].Cells["O_UNIT_NM"].Value.ToString() + " 초과)\n";

                            itemOutGrid.Rows[(int)overRow[i]].DefaultCellStyle.BackColor = Color.Red;
                            itemOutGrid.Rows[(int)overRow[i]].DefaultCellStyle.ForeColor = Color.Black;
                            itemOutGrid.Rows[(int)overRow[i]].DefaultCellStyle.SelectionBackColor = Color.Red;
                            itemOutGrid.Rows[(int)overRow[i]].DefaultCellStyle.SelectionForeColor = Color.Black;
                        }
                        warningMsg += "\n\n 재고수량을 확인해주십시오.";

                        MessageBox.Show(warningMsg, "출고수량 초과입력");
                        return;
                    }

                    if (underRow.Count > 0)
                    {
                        string warningMsg = "주문서의 주문 수량보다 출고수량이 적습니다.\n\n";
                        for (int i = 0; i < underRow.Count; i++)
                        {
                            if (i == 0)
                            {
                                warningMsg += "<수량부족 항목>\n";
                            }
                            warningMsg += itemOutGrid.Rows[(int)underRow[i]].Cells["O_ITEM_NM"].Value.ToString()
                                + " (" + itemOutGrid.Rows[(int)underRow[i]].Cells["OUTPUT_AMT"].Value.ToString() + itemOutGrid.Rows[(int)underRow[i]].Cells["O_UNIT_NM"].Value.ToString() + " 부족)\n";
                        }
                        
                        warningMsg += "\n\n그래도 등록 하시겠습니까?";

                        DialogResult reMessage = MessageBox.Show(warningMsg, "수량 불일치 경고", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (reMessage == DialogResult.No)
                        {
                            return;
                        }
                    }

                for (int i = 0; i < itemOutGrid.Rows.Count; i++)
                {
                    if (itemOutGrid.Rows[i].Cells["O_LOT_NO"].Value == null || itemOutGrid.Rows[i].Cells["O_LOT_NO"].Value.ToString().Equals(""))
                    {
                        itemOutGrid.Rows.RemoveAt(i);
                        i = -1;
                    }
                }

                if (itemOutGrid.Rows.Count == 0)
                {
                    MessageBox.Show("출고에 들어갈 제품이 1개 이상은 있어야 합니다.");
                    return;
                }

                if (lbl_out_gbn.Text != "1")
                {
                    wnDm wDm = new wnDm();

                    int rsNum = 1;
                    if (txt_jumun_date.Text != null && !txt_jumun_date.Text.ToString().Equals(""))
                    {
                        if (cmb_soo_gubun.SelectedIndex == 0)
                        {
                            rsNum = wDm.insertItemOut(
                                txt_out_date.Text.ToString(),
                                txt_cust_cd.Text.ToString(),
                                cmb_stor.SelectedValue.ToString(),
                                "N",
                                txt_vat_cd.Text.ToString(),
                                txt_jumun_date.Text.ToString(),
                                txt_jumun_cd.Text.ToString(),
                                txt_supply_money.Text.ToString(),
                                txt_tax_money.Text.ToString(),
                                txt_total_money.Text.ToString(),
                                itemOutGrid);
                        }
                        else
                        {
                            rsNum = wDm.insertItemOut_with_Collect(
                                txt_out_date.Text.ToString(),
                                txt_cust_cd.Text.ToString(),
                                cmb_stor.SelectedValue.ToString(),
                                "N",
                                txt_vat_cd.Text.ToString(),
                                txt_jumun_date.Text.ToString(),
                                txt_jumun_cd.Text.ToString(),
                                txt_supply_money.Text.ToString(),
                                txt_tax_money.Text.ToString(),
                                txt_total_money.Text.ToString(),
                                cmb_soo_gubun.SelectedValue.ToString(),
                                txt_soo_money.Text.ToString(),
                                txt_dc_money.Text.ToString(),
                                txt_total_soo_money.Text.ToString(),
                                itemOutGrid);
                        }
                    }
                    else
                    {
                        if (cmb_soo_gubun.SelectedIndex == 0)
                        {
                            rsNum = wDm.insertItemOut(
                                txt_out_date.Text.ToString(),
                                txt_cust_cd.Text.ToString(),
                                cmb_stor.SelectedValue.ToString(),
                                "N",
                                txt_vat_cd.Text.ToString(),
                                txt_supply_money.Text.ToString(),
                                txt_tax_money.Text.ToString(),
                                txt_total_money.Text.ToString(),
                                itemOutGrid);
                        }
                        else
                        {
                            rsNum = wDm.insertItemOut_with_Collect(
                                txt_out_date.Text.ToString(),
                                txt_cust_cd.Text.ToString(),
                                cmb_stor.SelectedValue.ToString(),
                                "N",
                                txt_vat_cd.Text.ToString(),
                                txt_supply_money.Text.ToString(),
                                txt_tax_money.Text.ToString(),
                                txt_total_money.Text.ToString(),
                                cmb_soo_gubun.SelectedValue.ToString(),
                                txt_soo_money.Text.ToString(),
                                txt_dc_money.Text.ToString(),
                                txt_total_soo_money.Text.ToString(),
                                itemOutGrid);
                        }
                    }


                    if (rsNum == 0)
                    {
                        for (int i = 0; i < itemOutGrid.Rows.Count; i++)
                        {
                            wnProcCon wDmProc = new wnProcCon();
                            int rsNum2 = wDmProc.prod_item_stock_upd((string)itemOutGrid.Rows[i].Cells["O_ITEM_CD"].Value);

                            if (rsNum2 == -9)
                            {
                                MessageBox.Show("재고 조정 실패: " + (string)itemOutGrid.Rows[i].Cells["O_ITEM_NM"].Value + " ");
                            }
                        }

                        resetSetting();
                        output_list(tdOutGridTemp, "where convert(varchar(10), A.INTIME, 120) = convert(varchar(10), getDate(), 120) ");
                        output_list(outputGrid, "where A.OUTPUT_DATE >= '" + txt_start_date.Text.ToString() + "' and  A.OUTPUT_DATE <= '" + txt_end_date.Text.ToString() + "'");

                        MessageBox.Show("저장에 성공하였습니다.");

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
                        MessageBox.Show("재고수량 초과 입력 하셨습니다. \n 체크 후 다시 저장 하시기 바랍니다.");
                    }
                    else if (rsNum == 5)
                    {
                        MessageBox.Show("장터지기 등록 에러.");
                    }
                    else
                        MessageBox.Show("Exception 에러");
                }
                else
                {

                    if (txt_jang_cd == null || txt_jang_cd.Text == null)
                    {
                        txt_jang_cd.Text = "";
                    }
                    if (!right[1])
                    {
                        MessageBox.Show("권한이없습니다.");
                        return;
                    }

                    string soo_gubun_value = "-1";
                    if (cmb_soo_gubun.SelectedIndex != 0) soo_gubun_value = cmb_soo_gubun.SelectedValue.ToString();

                    wnDm wDm = new wnDm();
                    int rsNum = wDm.updateItemOut(
                            txt_out_date.Text.ToString(),
                            txt_out_cd.Text.ToString(),
                            txt_cust_cd.Text.ToString(),
                            txt_supply_money.Text.ToString(),
                            txt_tax_money.Text.ToString(),
                            txt_total_money.Text.ToString(),
                            txt_vat_cd.Text.ToString(),
                            is_soo_inserted,
                            soo_gubun_value,
                            txt_soo_money.Text.ToString(),
                            txt_dc_money.Text.ToString(),
                            txt_total_soo_money.Text.ToString(),
                            itemOutGrid,
                            del_outGrid);

                    //int rsNum = wDm.updateItemOut(
                    //        txt_out_date.Text.ToString(),
                    //        txt_out_cd.Text.ToString(),
                    //        txt_jang_cd.Text.ToString(),
                    //        itemOutGrid,
                    //        del_outGrid);

                    if (rsNum == 0)
                    {

                        for (int i = 0; i < itemOutGrid.Rows.Count; i++)
                        {
                            wnProcCon wDmProc = new wnProcCon();
                            int rsNum2 = wDmProc.prod_item_stock_upd((string)itemOutGrid.Rows[i].Cells["O_ITEM_CD"].Value);

                            if (rsNum2 == -9)
                            {
                                MessageBox.Show("재고 조정 실패: " + (string)itemOutGrid.Rows[i].Cells["O_ITEM_NM"].Value + " ");
                            }
                        }

                        del_outGrid.Rows.Clear();
                        resetSetting();
                        output_list(tdOutGridTemp, "where convert(varchar(10), A.INTIME, 120) = convert(varchar(10), getDate(), 120) ");
                        output_list(outputGrid, "where A.OUTPUT_DATE >= '" + txt_start_date.Text.ToString() + "' and  A.OUTPUT_DATE <= '" + txt_end_date.Text.ToString() + "'");

                        outputDetail2();
                        item_out_detail("");

                        MessageBox.Show("성공적으로 수정하였습니다.");
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
            }
            catch (Exception e)
            {
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(e.Message + " - " + e.ToString());
                msg.ShowDialog();
            }
        }

        private void resetSetting()
        {
            lbl_out_gbn.Text = "";
            btnDelete.Enabled = false;

            txt_out_date.Text = DateTime.Now.ToString("yyyy-MM-dd");
            txt_out_date.Enabled = true;
            btnCustSrch.Enabled = true;
            txt_out_cd.Text = "";
            txt_cust_cd.Text = "";
            txt_cust_nm.Text = "";
            old_cust_nm = "";
            txt_vat_cd.Text = "";

            is_soo_inserted = false;

            txt_no_tax_money.Text = "0";
            txt_yes_tax_money.Text = "0";
            txt_yesno_money.Text = "0";

            txt_supply_money.Text = "0";
            txt_tax_money.Text = "0";
            txt_total_money.Text = "0";

            lbl_cust_nm.BackColor = Color.AliceBlue;

            btn_jumun_select.Enabled = true;
            lbl_jumun_date.Enabled = false;
            lbl_jumun_cd.Enabled = false;
            lbl_jumun_comment.Enabled = false;

            txt_jumun_cd.Text = "";
            txt_jumun_date.Text = "";
            txt_jumun_comment.Text = "";

            txt_cust_nm.Enabled = true;

            chk_self_yn.Checked = false;


            cmb_soo_gubun.SelectedIndex = 0;

            itemOutGrid.Rows.Clear();
            itemStockGrid.Rows.Clear();
            del_outGrid.Rows.Clear();
            item_out_detail("");
        }

        private void output_list(DataGridView dgv, string condition)
        {
            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = null;
                dt = wDm.fn_Item_Output_List(condition);

                if (dt != null && dt.Rows.Count > 0)
                {
                    dgv.RowCount = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgv.Rows[i].Cells[0].Value = dt.Rows[i]["OUTPUT_DATE"].ToString();
                        dgv.Rows[i].Cells[1].Value = dt.Rows[i]["OUTPUT_CD"].ToString();
                        dgv.Rows[i].Cells[4].Value = dt.Rows[i]["CUST_CD"].ToString();
                        dgv.Rows[i].Cells[2].Value = dt.Rows[i]["CUST_NM"].ToString();
                        dgv.Rows[i].Cells[3].Value = dt.Rows[i]["ITEM_CNT"].ToString();
                        dgv.Rows[i].Cells[5].Value = dt.Rows[i]["STORAGE_CD"].ToString();
                        dgv.Rows[i].Cells[6].Value = dt.Rows[i]["STORAGE_NM"].ToString();
                        dgv.Rows[i].Cells[7].Value = dt.Rows[i]["SELF_YN"].ToString();
                        dgv.Rows[i].Cells[8].Value = dt.Rows[i]["VAT_CD"].ToString();

                        dgv.Rows[i].Cells[9].Value = dt.Rows[i]["JUMUN_DATE"].ToString();
                        dgv.Rows[i].Cells[10].Value = dt.Rows[i]["JUMUN_CD"].ToString();
                        dgv.Rows[i].Cells[11].Value = dt.Rows[i]["J_COMMENT"].ToString();

                        dgv.Rows[i].Cells[12].Value = dt.Rows[i]["SOO_GUBUN"].ToString();
                        dgv.Rows[i].Cells[13].Value = dt.Rows[i]["SOO_MONEY"].ToString();
                        dgv.Rows[i].Cells[14].Value = dt.Rows[i]["DC_MONEY"].ToString();
                        dgv.Rows[i].Cells[15].Value = dt.Rows[i]["TOTAL_SOO_MONEY"].ToString();

                        dgv.Rows[i].Cells[16].Value = decimal.Parse(dt.Rows[i]["BALANCE_BEFORE"].ToString()).ToString("#,0.######");
                        dgv.Rows[i].Cells[17].Value = decimal.Parse(dt.Rows[i]["S_RS_TOTAL_MONEY"].ToString()).ToString("#,0.######");
                        dgv.Rows[i].Cells[18].Value = decimal.Parse(dt.Rows[i]["COL_TOTAL_MONEY"].ToString()).ToString("#,0.######");
                        dgv.Rows[i].Cells[19].Value = decimal.Parse(dt.Rows[i]["BALANCE_DAY"].ToString()).ToString("#,0.######");


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
            if (tabControl1.SelectedIndex == 0)
            {
                output_list(tdOutGridTemp, "where convert(varchar(10), A.INTIME, 120) = convert(varchar(10), getDate(), 120) ");
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                txt_start_date.Text = DateTime.Today.AddMonths(-1).ToString("yyyy-MM-dd");
                output_list(outputGrid, "where A.OUTPUT_DATE >= '" + txt_start_date.Text.ToString() + "' and  A.OUTPUT_DATE <= '" + txt_end_date.Text.ToString() + "'");
            }
           
        }

     

        private void tdOutGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ComInfo.grdHeaderNoAction(e))
            {
                out_detail(tdOutGridTemp, e);
            }
        }

        private void outputGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ComInfo.grdHeaderNoAction(e))
            {
                out_detail(outputGrid, e);
            }
        }

        private void out_detail(DataGridView dgv, DataGridViewCellEventArgs e)
        {
            btnDelete.Enabled = true;
            lbl_out_gbn.Text = "1";
            txt_out_date.Enabled = false;
            txt_cust_nm.Enabled = false;
            btnCustSrch.Enabled = false;
            btn_jumun_select.Enabled = false;
            txt_out_date.Text = dgv.Rows[e.RowIndex].Cells[0].Value.ToString();

            txt_out_cd.Text = dgv.Rows[e.RowIndex].Cells[1].Value.ToString();
            txt_cust_cd.Text = dgv.Rows[e.RowIndex].Cells[4].Value.ToString();
            txt_cust_nm.Text = dgv.Rows[e.RowIndex].Cells[2].Value.ToString();
            old_cust_nm = dgv.Rows[e.RowIndex].Cells[4].Value.ToString();
            cmb_stor.SelectedValue = dgv.Rows[e.RowIndex].Cells[5].Value.ToString();
            txt_vat_cd.Text = dgv.Rows[e.RowIndex].Cells[8].Value.ToString();

            txt_yesterBal.Text = dgv.Rows[e.RowIndex].Cells[16].Value.ToString();
            txt_DaySalesMoney.Text = dgv.Rows[e.RowIndex].Cells[17].Value.ToString();
            txt_DaySooMoney.Text = dgv.Rows[e.RowIndex].Cells[18].Value.ToString();
            txt_Day_jango.Text = dgv.Rows[e.RowIndex].Cells[19].Value.ToString();

            if (dgv.Rows[e.RowIndex].Cells[7].Value.ToString().Equals("Y"))
            {
                chk_self_yn.Checked = true;
            }
            else
            {
                chk_self_yn.Checked = false;
            }


            if (dgv.Rows[e.RowIndex].Cells[9].Value != null)
            {
                txt_jumun_date.Text = dgv.Rows[e.RowIndex].Cells[9].Value.ToString();
                txt_jumun_cd.Text = dgv.Rows[e.RowIndex].Cells[10].Value.ToString();
                if (dgv.Rows[e.RowIndex].Cells[11].Value != null)
                {
                    txt_jumun_comment.Text = dgv.Rows[e.RowIndex].Cells[11].Value.ToString();
                }
            }

            if (dgv.Rows[e.RowIndex].Cells[12].Value != null && !dgv.Rows[e.RowIndex].Cells[12].Value.ToString().Equals(""))
            {
                cmb_soo_gubun.SelectedValue = dgv.Rows[e.RowIndex].Cells[12].Value.ToString();
                txt_soo_money.Text = decimal.Parse(dgv.Rows[e.RowIndex].Cells[13].Value.ToString().Replace(",", "")).ToString("#,0.######");
                txt_dc_money.Text = decimal.Parse(dgv.Rows[e.RowIndex].Cells[14].Value.ToString().Replace(",", "")).ToString("#,0.######");
                txt_total_soo_money.Text = decimal.Parse(dgv.Rows[e.RowIndex].Cells[15].Value.ToString().Replace(",", "")).ToString("#,0.######");
                is_soo_inserted = true;
            }
            else
            {
                is_soo_inserted = false;
            }

            //btnCustSrch.Enabled = false;

            //if (dgv.Rows[e.RowIndex].Cells[4].Value.ToString().Equals("Y"))
            //{
            //    chk_input_yn.Checked = true;
            //}
            //else
            //{
            //    chk_input_yn.Checked = false;
            //}
            //inputDetail2();
            //ni_detail();
            //in_grid_detail();
            del_outGrid.Rows.Clear();

            outputDetail2();
            item_out_detail("");


            btnSerch.PerformClick();

        }

        private void outputDetail2()
        {
            wnDm wDm = new wnDm();
            DataTable dt = null;
            dt = wDm.fn_Item_Output_Detail_List("where A.OUTPUT_DATE = '" + txt_out_date.Text.ToString() + "' and A.OUTPUT_CD = '" + txt_out_cd.Text.ToString() + "' ");

            itemOutGrid.Rows.Clear();
            if (dt != null && dt.Rows.Count > 0)
            {
                this.itemOutGrid.RowCount = dt.Rows.Count;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    itemOutGrid.Rows[i].Cells["SEQ"].Value = dt.Rows[i]["SEQ"].ToString();
                    itemOutGrid.Rows[i].Cells["O_LOT_NO"].Value = dt.Rows[i]["LOT_NO"].ToString();
                    itemOutGrid.Rows[i].Cells["O_LOT_SUB"].Value = dt.Rows[i]["LOT_SUB"].ToString();
                    itemOutGrid.Rows[i].Cells["O_ITEM_CD"].Value = dt.Rows[i]["ITEM_CD"].ToString();
                    itemOutGrid.Rows[i].Cells["O_ITEM_NM"].Value = dt.Rows[i]["ITEM_NM"].ToString();
                    itemOutGrid.Rows[i].Cells["O_TAX_CD"].Value = dt.Rows[i]["TAX_CD"].ToString();
                    itemOutGrid.Rows[i].Cells["OUTPUT_AMT"].Value = (decimal.Parse(dt.Rows[i]["OUTPUT_AMT"].ToString())).ToString("#,0.###");
                    itemOutGrid.Rows[i].Cells["O_SPEC"].Value = dt.Rows[i]["SPEC"].ToString();
                    itemOutGrid.Rows[i].Cells["PRICE"].Value = (decimal.Parse(dt.Rows[i]["PRICE"].ToString())).ToString("#,0.###");
                    itemOutGrid.Rows[i].Cells["O_UNIT_CD"].Value = dt.Rows[i]["UNIT_CD"].ToString();
                    itemOutGrid.Rows[i].Cells["O_UNIT_NM"].Value = dt.Rows[i]["UNIT_NM"].ToString();
                    itemOutGrid.Rows[i].Cells["OLD_OUT_AMT"].Value = (decimal.Parse(dt.Rows[i]["OUTPUT_AMT"].ToString()) + decimal.Parse(dt.Rows[i]["CURR_AMT"].ToString())).ToString("#,0.######");
                    itemOutGrid.Rows[i].Cells["TOTAL_MONEY"].Value = (decimal.Parse(dt.Rows[i]["TOTAL_MONEY"].ToString())).ToString("#,0.###");
                    itemOutGrid.Rows[i].Cells["O_INPUT_DATE"].Value = dt.Rows[i]["INPUT_DATE"].ToString();
                    itemOutGrid.Rows[i].Cells["O_INPUT_CD"].Value = dt.Rows[i]["INPUT_CD"].ToString();
                    itemOutGrid.Rows[i].Cells["J_INPUT_DATE"].Value = dt.Rows[i]["J_INPUT_DATE"].ToString();
                    itemOutGrid.Rows[i].Cells["J_INPUT_CD"].Value = dt.Rows[i]["J_INPUT_CD"].ToString();
                    txt_jang_cd.Text = dt.Rows[i]["J_INPUT_CD"].ToString();
                    itemOutGrid.Rows[i].Cells["J_INPUT_SEQ"].Value = dt.Rows[i]["J_INPUT_SEQ"].ToString();


                    




                    wConst.f_Calc_Price(itemOutGrid, i, "OUTPUT_AMT", "PRICE", "TOTAL_MONEY", "O_SUPPLY_MONEY", "O_TAX_MONEY", "O_TOTAL_MONEY", txt_vat_cd.Text, itemOutGrid.Rows[i].Cells["O_TAX_CD"].Value.ToString());
                    wConst.f_Calc_SalesPrice(txt_supply_money
                                    , txt_tax_money
                                    , txt_total_money
                                    , txt_vat_cd.Text
                                    , txt_no_tax_money
                                    , txt_yes_tax_money
                                    , txt_yesno_money
                                    , itemOutGrid
                                    , "O_SUPPLY_MONEY"
                                    , "O_TAX_MONEY"
                                    , "O_TOTAL_MONEY"
                                    , "O_TAX_CD"
                                    , true
                                    , "O_LOT_NO"
                                    );
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
            DialogResult msgOk = comInfo.deleteConfrim("제품 출고", txt_out_date.Text.ToString() + " - " + txt_out_cd.Text.ToString());

            if (msgOk == DialogResult.No)
            {
                return;
            }

            if (txt_jang_cd == null || txt_jang_cd.Text == null)
            {
                txt_jang_cd.Text = "";
            }

            wnDm wDm = new wnDm();
            int rsNum = 1;
            if (txt_jumun_date.Text != null && !txt_jumun_date.Text.ToString().Equals(""))
            {
                rsNum = wDm.deleteItemOut(txt_out_date.Text.ToString(), txt_out_cd.Text.ToString(), txt_jang_cd.Text.ToString(), txt_jumun_date.Text, txt_jumun_cd.Text, is_soo_inserted);
            }
            else
            {
                rsNum = wDm.deleteItemOut(txt_out_date.Text.ToString(), txt_out_cd.Text.ToString(), txt_jang_cd.Text.ToString(), is_soo_inserted);
            }
            if (rsNum == 0)
            {
                resetSetting();
                output_list(tdOutGridTemp, "where convert(varchar(10), A.INTIME, 120) = convert(varchar(10), getDate(), 120) ");
                output_list(outputGrid, "where A.OUTPUT_DATE >= '" + txt_start_date.Text.ToString() + "' and  A.OUTPUT_DATE <= '" + txt_end_date.Text.ToString() + "'");
                MessageBox.Show("성공적으로 삭제하였습니다.");

                //int rsNum2 = wDm.updateStRaw(inputRmGrid);

                //if (rsNum2 == 0)
                //{
                //    resetSetting();

                //    input_list(tdInputGrid, "where convert(varchar(10), A.INTIME, 120) = convert(varchar(10), getDate(), 120) ");
                //    input_list(inputGrid, "where A.INPUT_DATE >= '" + start_date.Text.ToString() + "' and  A.INPUT_DATE <= '" + end_date.Text.ToString() + "'");


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
                MessageBox.Show(ex + "");
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                msg.ShowDialog();
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

            if (name == "OUTPUT_AMT" || name == "PRICE" || name == "TOTAL_MONEY")
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

            Color colorTempOne = cell.Style.BackColor;
            Color colorTempTwo = cell.Style.SelectionBackColor;

            if (grd.Columns[e.ColumnIndex].ToolTipText.IndexOf("수량") >= 0
                || grd.Columns[e.ColumnIndex].ToolTipText.IndexOf("단가") >= 0
                || grd.Columns[e.ColumnIndex].ToolTipText.IndexOf("금액") >= 0)
            {

                string total_amt = (string)grd.Rows[e.RowIndex].Cells["OUTPUT_AMT"].Value;
                string price = (string)grd.Rows[e.RowIndex].Cells["PRICE"].Value;

                if (total_amt != null)
                {
                    total_amt = total_amt.ToString().Replace(" ", "");
                    if (total_amt == "")
                    {
                        grd.Rows[e.RowIndex].Cells["OUTPUT_AMT"].Value = "0";
                    }
                }
                else
                {
                    grd.Rows[e.RowIndex].Cells["OUTPUT_AMT"].Value = "0";
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

                if (grd.Rows[e.RowIndex].Cells["OLD_OUT_AMT"].Value != null && !grd.Rows[e.RowIndex].Cells["OLD_OUT_AMT"].Value.ToString().Equals(""))
                {
                    if (decimal.Parse(total_amt.Replace(",", "")) <= decimal.Parse(grd.Rows[e.RowIndex].Cells["OLD_OUT_AMT"].Value.ToString()))
                    {
                        grd.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                        grd.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Black;
                        grd.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                        grd.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.LightYellow;
                    }
                }



                wConst.f_Calc_Price(grd, e.RowIndex, "OUTPUT_AMT", "PRICE");
                wConst.f_Calc_Price(grd, e.RowIndex, "OUTPUT_AMT", "PRICE", "TOTAL_MONEY", "O_SUPPLY_MONEY", "O_TAX_MONEY", "O_TOTAL_MONEY", txt_vat_cd.Text, grd.Rows[e.RowIndex].Cells["O_TAX_CD"].Value.ToString());
                wConst.f_Calc_SalesPrice(txt_supply_money
                                    , txt_tax_money
                                    , txt_total_money
                                    , txt_vat_cd.Text
                                    , txt_no_tax_money
                                    , txt_yes_tax_money
                                    , txt_yesno_money
                                    , itemOutGrid
                                    , "O_SUPPLY_MONEY"
                                    , "O_TAX_MONEY"
                                    , "O_TOTAL_MONEY"
                                    , "O_TAX_CD"
                                    , true
                                    , "O_LOT_NO"
                                    );

                cell.Style.BackColor = colorTempOne;
                cell.Style.SelectionBackColor = colorTempTwo;
            }
        }
        #endregion grid control

        private void txt_bar_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComInfo.onlyNum(sender, e);       
   
         
        }

        private void btn_minus_Click(object sender, EventArgs e)
        {
            ///행삭제 했을때 선택삭제되는 데이터와 
            ///출고예정리스트와 비교하여 
            ///visible =true 해주어서   false였던 데이터를  다시생기는것처럼 보여주게한다 


            if (itemOutGrid.CurrentCell != null && btn_jumun_select.Enabled == true)
            {
                if (itemOutGrid.Rows[itemOutGrid.CurrentCell.RowIndex].Cells["O_LOT_NO"].Value == null || itemOutGrid.Rows[itemOutGrid.CurrentCell.RowIndex].Cells["O_LOT_NO"].Value.ToString().Equals(""))
                {
                    MessageBox.Show("주문서항목 행은 삭제할 수 업습니다.");
                    return;
                }else
                {
                    if (txt_jumun_date.Text != null && !txt_jumun_date.Text.ToString().Equals(""))
                    {
                        string thisItemCd = itemOutGrid.Rows[itemOutGrid.CurrentCell.RowIndex].Cells["O_ITEM_CD"].Value.ToString();
                        int thisIndex = itemOutGrid.CurrentCell.RowIndex;
                        for (int i = 0; i < itemOutGrid.Rows.Count; i++)
                        {
                            if (i != itemOutGrid.CurrentCell.RowIndex)
                            {
                                if (itemOutGrid.Rows[i].Cells["O_ITEM_CD"].Value.ToString().Equals(thisItemCd))
                                {
                                    thisIndex = -1;
                                    break;
                                }
                            }
                        }

                        if (thisIndex != -1)
                        {
                            for (int i = 0; i < itemStockGrid.Rows.Count; i++)
                            {
                                if (
                                      (String)itemOutGrid.SelectedRows[0].Cells["O_LOT_NO"].Value == (String)itemStockGrid.Rows[i].Cells["LOT_NO"].Value
                                      && (String)itemOutGrid.SelectedRows[0].Cells["O_LOT_SUB"].Value == (String)itemStockGrid.Rows[i].Cells["LOT_SUB"].Value
                                      && (String)itemOutGrid.SelectedRows[0].Cells["O_INPUT_DATE"].Value == (String)itemStockGrid.Rows[i].Cells["INPUT_DATE"].Value
                                      && (String)itemOutGrid.SelectedRows[0].Cells["O_INPUT_CD"].Value == (String)itemStockGrid.Rows[i].Cells["INPUT_CD"].Value
                                    )
                                {
                                    itemStockGrid.Rows[i].Visible = true;
                                }
                            }

                            itemOutGrid.Rows[thisIndex].Cells["OLD_OUT_AMT"].Value = "";
                            itemOutGrid.Rows[thisIndex].Cells["O_LOT_NO"].Value = "";
                            itemOutGrid.Rows[thisIndex].Cells["O_LOT_SUB"].Value = "";
                            itemOutGrid.Rows[thisIndex].Cells["O_INPUT_DATE"].Value = "";
                            itemOutGrid.Rows[thisIndex].Cells["O_INPUT_CD"].Value = "";
                            itemOutGrid.Rows[thisIndex].Cells["O_INPUT_SEQ"].Value = "";

                            itemOutGrid.Rows[thisIndex].DefaultCellStyle.BackColor = Color.MistyRose;
                            itemOutGrid.Rows[thisIndex].DefaultCellStyle.SelectionBackColor = Color.MistyRose;

                            wConst.f_Calc_SalesPrice(txt_supply_money
                                    , txt_tax_money
                                    , txt_total_money
                                    , txt_vat_cd.Text
                                    , txt_no_tax_money
                                    , txt_yes_tax_money
                                    , txt_yesno_money
                                    , itemOutGrid
                                    , "O_SUPPLY_MONEY"
                                    , "O_TAX_MONEY"
                                    , "O_TOTAL_MONEY"
                                    , "O_TAX_CD"
                                    , true
                                    , "O_LOT_NO"
                                    );
                            return;
                        }
                    }
                }
            }

            



            for (int i = 0; i < itemStockGrid.Rows.Count; i++)
            {
                if (
                      (String)itemOutGrid.SelectedRows[0].Cells["O_LOT_NO"].Value == (String)itemStockGrid.Rows[i].Cells["LOT_NO"].Value
                      && (String)itemOutGrid.SelectedRows[0].Cells["O_LOT_SUB"].Value == (String)itemStockGrid.Rows[i].Cells["LOT_SUB"].Value
                      && (String)itemOutGrid.SelectedRows[0].Cells["O_ITEM_CD"].Value == (String)itemStockGrid.Rows[i].Cells["ITEM_CD"].Value
                      && (String)itemOutGrid.SelectedRows[0].Cells["O_INPUT_DATE"].Value == (String)itemStockGrid.Rows[i].Cells["INPUT_DATE"].Value
                      && (String)itemOutGrid.SelectedRows[0].Cells["O_INPUT_CD"].Value == (String)itemStockGrid.Rows[i].Cells["INPUT_CD"].Value
                    )
                {
                    itemStockGrid.Rows[i].Visible = true;
                }
            }

            for (int i = 0; i < itemOutGrid.Rows.Count; i++)
            {
                if(itemOutGrid.CurrentCell.RowIndex == i) continue;
                if (itemOutGrid.SelectedRows[0].Cells["O_ITEM_CD"].Value == itemOutGrid.Rows[i].Cells["O_ITEM_CD"].Value)
                {
                    if (itemOutGrid.Rows[i].Cells["O_LOT_NO"].Value == null || itemOutGrid.Rows[i].Cells["O_LOT_NO"].Value.ToString().Equals(""))
                    {
                        itemOutGrid.Rows[i].Cells["OUTPUT_AMT"].Value = (decimal.Parse(itemOutGrid.Rows[i].Cells["OUTPUT_AMT"].Value.ToString())
                            + decimal.Parse(itemOutGrid.SelectedRows[0].Cells["OUTPUT_AMT"].Value.ToString())).ToString("#,0.######");
                        wConst.f_Calc_Price(itemOutGrid, i, "OUTPUT_AMT", "PRICE");
                        wConst.f_Calc_Price(itemOutGrid, i, "OUTPUT_AMT", "PRICE", "TOTAL_MONEY", "O_SUPPLY_MONEY", "O_TAX_MONEY", "O_TOTAL_MONEY", txt_vat_cd.Text, itemOutGrid.Rows[i].Cells["O_TAX_CD"].Value.ToString());
                        wConst.f_Calc_SalesPrice(txt_supply_money
                                    , txt_tax_money
                                    , txt_total_money
                                    , txt_vat_cd.Text
                                    , txt_no_tax_money
                                    , txt_yes_tax_money
                                    , txt_yesno_money
                                    , itemOutGrid
                                    , "O_SUPPLY_MONEY"
                                    , "O_TAX_MONEY"
                                    , "O_TOTAL_MONEY"
                                    , "O_TAX_CD"
                                    , true
                                    , "O_LOT_NO"
                                    );
                    }
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
                wConst.f_Calc_SalesPrice(txt_supply_money
                                    , txt_tax_money
                                    , txt_total_money
                                    , txt_vat_cd.Text
                                    , txt_no_tax_money
                                    , txt_yes_tax_money
                                    , txt_yesno_money
                                    , itemOutGrid
                                    , "O_SUPPLY_MONEY"
                                    , "O_TAX_MONEY"
                                    , "O_TOTAL_MONEY"
                                    , "O_TAX_CD"
                                    , true
                                    , "O_LOT_NO"
                                    );
            }
        }

        private void txt_cust_nm_TextChanged(object sender, EventArgs e)
        {

        }

        private void frm제품출고등록_Enter(object sender, EventArgs e)
        {
            btnSrch.PerformClick();
            item_out_detail("");
        }

        private void btnSerch_Click(object sender, EventArgs e)
        {
            item_out_detail("");
        }

        private void txt_bar_KeyUp(object sender, KeyEventArgs e)
        {
            int lotchk = 0;

            if (txt_bar.Text.Length == 10)
            {
                string lots = txt_bar.Text;

                if (itemStockGrid.Rows.Count > 0)
                {
                    bool isInTheRow = false;
                    for (int i = 0; i < itemStockGrid.Rows.Count; i++)
                    {
                        string lotno = itemStockGrid.Rows[i].Cells["LOT_NO"].Value.ToString();

                        if (lots == lotno)
                        {

                            for (int j = 0; j < itemOutGrid.Rows.Count; j++)
                            {
                                //if (lots == (string)itemOutGrid.Rows[j].Cells["O_LOT_NO"].Value)
                                //{
                                //    MessageBox.Show("해당 출고할 제품이 이미 등록되어있습니다.");
                                //    txt_bar.Text = "";
                                //    return;
                                //}
                            }

                            for (int k = 0; k < del_outGrid.Rows.Count; k++)
                            {
                                if (lots == (string)del_outGrid.Rows[k]["LOT_NO"].ToString())
                                {
                                    MessageBox.Show("해당 제품출고의 삭제데이터가 있어서 등록이 불가합니다.");
                                    txt_bar.Text = "";
                                    return;
                                }
                            }

                            if (txt_cust_nm.Text != "")
                            {
                                if (txt_cust_nm.Text != itemStockGrid.Rows[i].Cells["납품처"].Value.ToString() && (itemStockGrid.Rows[i].Cells["납품처코드"].Value != null && !itemStockGrid.Rows[i].Cells["납품처코드"].Value.ToString().Equals("")))
                                {
                                    //MessageBox.Show("다른거래처는 등록할수 없습니다.");
                                    //txt_bar.Text = "";
                                    //return;
                                }
                            }


                            itemOutGrid.Rows.Add();
                            int rowNum = itemOutGrid.Rows.Count - 1;
                            if (!itemStockGrid.Rows[i].Cells["납품처코드"].Value.ToString().Equals(""))
                            {
                                txt_cust_nm.Text = (String)itemStockGrid.Rows[i].Cells["납품처"].Value;
                                txt_cust_cd.Text = (String)itemStockGrid.Rows[i].Cells["납품처코드"].Value;
                            }
                            itemOutGrid.Rows[rowNum].Cells["O_LOT_NO"].Value = itemStockGrid.Rows[i].Cells["LOT_NO"].Value;
                            itemOutGrid.Rows[rowNum].Cells["O_LOT_SUB"].Value = itemStockGrid.Rows[i].Cells["LOT_SUB"].Value;
                            itemOutGrid.Rows[rowNum].Cells["O_ITEM_CD"].Value = itemStockGrid.Rows[i].Cells["ITEM_CD"].Value;
                            itemOutGrid.Rows[rowNum].Cells["O_ITEM_NM"].Value = itemStockGrid.Rows[i].Cells["ITEM_NM"].Value;
                            itemOutGrid.Rows[rowNum].Cells["OUTPUT_AMT"].Value = itemStockGrid.Rows[i].Cells["STOCK_AMT"].Value;
                            itemOutGrid.Rows[rowNum].Cells["O_SPEC"].Value = itemStockGrid.Rows[i].Cells["SPEC"].Value;
                            itemOutGrid.Rows[rowNum].Cells["PRICE"].Value = itemStockGrid.Rows[i].Cells["OUTPUT_PRICE"].Value;
                            itemOutGrid.Rows[rowNum].Cells["O_UNIT_CD"].Value = itemStockGrid.Rows[i].Cells["UNIT_CD"].Value;
                            itemOutGrid.Rows[rowNum].Cells["O_UNIT_NM"].Value = itemStockGrid.Rows[i].Cells["UNIT_NM"].Value;
                            itemOutGrid.Rows[rowNum].Cells["OLD_OUT_AMT"].Value = itemStockGrid.Rows[i].Cells["STOCK_AMT"].Value;
                            double total_money = double.Parse(itemStockGrid.Rows[i].Cells["STOCK_AMT"].Value.ToString()) * double.Parse(itemStockGrid.Rows[i].Cells["OUTPUT_PRICE"].Value.ToString());
                            itemOutGrid.Rows[rowNum].Cells["TOTAL_MONEY"].Value = total_money.ToString("#,0.###");
                            itemOutGrid.Rows[rowNum].Cells["O_INPUT_DATE"].Value = itemStockGrid.Rows[i].Cells["INPUT_DATE"].Value;
                            itemOutGrid.Rows[rowNum].Cells["O_INPUT_CD"].Value = itemStockGrid.Rows[i].Cells["INPUT_CD"].Value;
                            itemOutGrid.Rows[rowNum].Cells["O_CUST_CD"].Value = txt_cust_cd.Text.ToString();
                            itemOutGrid.Rows[rowNum].Cells["O_TAX_CD"].Value = itemStockGrid.Rows[i].Cells["TAX_CD"].Value;
                            itemOutGrid.Rows[rowNum].Cells["O_LINK_CD"].Value = itemStockGrid.Rows[i].Cells["LINK_CD"].Value;
                            itemOutGrid.Rows[rowNum].Cells["O_INPUT_SEQ"].Value = itemStockGrid.Rows[i].Cells["INPUT_SEQ"].Value;

                            //chk = 1;
                            wConst.f_Calc_Price(itemOutGrid, rowNum, "OUTPUT_AMT", "PRICE");
                            wConst.f_Calc_Price(itemOutGrid, rowNum, "OUTPUT_AMT", "PRICE", "TOTAL_MONEY", "O_SUPPLY_MONEY", "O_TAX_MONEY", "O_TOTAL_MONEY", txt_vat_cd.Text, itemOutGrid.Rows[rowNum].Cells["O_TAX_CD"].Value.ToString());
                            wConst.f_Calc_SalesPrice(txt_supply_money
                                    , txt_tax_money
                                    , txt_total_money
                                    , txt_vat_cd.Text
                                    , txt_no_tax_money
                                    , txt_yes_tax_money
                                    , txt_yesno_money
                                    , itemOutGrid
                                    , "O_SUPPLY_MONEY"
                                    , "O_TAX_MONEY"
                                    , "O_TOTAL_MONEY"
                                    , "O_TAX_CD"
                                    , true
                                    , "O_LOT_NO"
                                    );
                            itemOutGrid.Focus();
                            itemStockGrid.Rows[i].Visible = false;
                            itemStockGrid.Rows[i].Cells["CHK"].Value = false;

                            lotchk = 1;
                            txt_bar.Text = "";

                            //if (!isInTheRow)
                            //{
                            //    MessageBox.Show("현 거래처에 입고 데이터가 없습니다. 재확인해주십시오.");
                            //    txt_bar.Text = "";
                            //}
                        }




                        //if (txt_bar.Text.Length == 10)
                        //{
                        //    if (itemStockGrid.Rows.Count > 0)
                        //    {
                        //        bool isInTheRow = false;
                        //        for (int i = 0; i < itemStockGrid.Rows.Count; i++)
                        //        {
                        //            string lotno = itemStockGrid.Rows[i].Cells["LOT_NO"].Value.ToString();
                        //            string lotsub = int.Parse(itemStockGrid.Rows[i].Cells["LOT_SUB"].Value.ToString()).ToString("000");

                        //            if (txt_bar.Text.ToString().Equals(lotno + lotsub))
                        //            {
                        //                for (int j = 0; j < itemOutGrid.Rows.Count; j++)
                        //                {
                        //                    if ((string)itemStockGrid.Rows[i].Cells["LOT_NO"].Value == (string)itemOutGrid.Rows[j].Cells["O_LOT_NO"].Value
                        //                        && (string)itemStockGrid.Rows[i].Cells["LOT_SUB"].Value == (string)itemOutGrid.Rows[j].Cells["O_LOT_SUB"].Value)
                        //                    {
                        //                        MessageBox.Show("해당 출고할 제품이 이미 등록되어있습니다.");
                        //                        txt_bar.Text = "";
                        //                        return;
                        //                    }
                        //                }

                        //                for (int k = 0; k < del_outGrid.Rows.Count; k++)
                        //                {
                        //                    if ((string)itemStockGrid.Rows[i].Cells["LOT_NO"].Value == (string)del_outGrid.Rows[k]["LOT_NO"].ToString()
                        //                        && (string)itemStockGrid.Rows[i].Cells["LOT_SUB"].Value == (string)del_outGrid.Rows[k]["LOT_SUB"].ToString())
                        //                    {
                        //                        MessageBox.Show("해당 제품출고의 삭제데이터가 있어서 등록이 불가합니다.");
                        //                        txt_bar.Text = "";
                        //                        return;
                        //                    }
                        //                }
                        //                isInTheRow = true;
                        //                itemOutGrid.Rows.Add();
                        //                int rowNum = itemOutGrid.Rows.Count - 1;
                        //                itemOutGrid.Rows[rowNum].Cells["O_LOT_NO"].Value = itemStockGrid.Rows[i].Cells["LOT_NO"].Value;
                        //                itemOutGrid.Rows[rowNum].Cells["O_LOT_SUB"].Value = itemStockGrid.Rows[i].Cells["LOT_SUB"].Value;
                        //                itemOutGrid.Rows[rowNum].Cells["O_ITEM_CD"].Value = itemStockGrid.Rows[i].Cells["ITEM_CD"].Value;
                        //                itemOutGrid.Rows[rowNum].Cells["O_ITEM_NM"].Value = itemStockGrid.Rows[i].Cells["ITEM_NM"].Value;
                        //                itemOutGrid.Rows[rowNum].Cells["OUTPUT_AMT"].Value = itemStockGrid.Rows[i].Cells["STOCK_AMT"].Value;
                        //                itemOutGrid.Rows[rowNum].Cells["O_SPEC"].Value = itemStockGrid.Rows[i].Cells["SPEC"].Value;
                        //                itemOutGrid.Rows[rowNum].Cells["PRICE"].Value = itemStockGrid.Rows[i].Cells["OUTPUT_PRICE"].Value;
                        //                itemOutGrid.Rows[rowNum].Cells["O_UNIT_CD"].Value = itemStockGrid.Rows[i].Cells["UNIT_CD"].Value;
                        //                itemOutGrid.Rows[rowNum].Cells["O_UNIT_NM"].Value = itemStockGrid.Rows[i].Cells["UNIT_NM"].Value;
                        //                itemOutGrid.Rows[rowNum].Cells["OLD_OUT_AMT"].Value = itemStockGrid.Rows[i].Cells["STOCK_AMT"].Value;
                        //                double total_money = double.Parse(itemStockGrid.Rows[i].Cells["STOCK_AMT"].Value.ToString()) * double.Parse(itemStockGrid.Rows[i].Cells["OUTPUT_PRICE"].Value.ToString());
                        //                itemOutGrid.Rows[rowNum].Cells["TOTAL_MONEY"].Value = total_money.ToString("#,0.###");

                        //                itemOutGrid.Rows[rowNum].Cells["O_INPUT_DATE"].Value = itemStockGrid.Rows[i].Cells["INPUT_DATE"].Value;
                        //                itemOutGrid.Rows[rowNum].Cells["O_INPUT_CD"].Value = itemStockGrid.Rows[i].Cells["INPUT_CD"].Value;
                        //                itemOutGrid.Rows[rowNum].Cells["O_TAX_CD"].Value = itemStockGrid.Rows[i].Cells["TAX_CD"].Value;
                        //                itemOutGrid.Rows[rowNum].Cells["O_LINK_CD"].Value = itemStockGrid.Rows[i].Cells["LINK_CD"].Value;
                        //                // chk = 1;
                        //                wConst.f_Calc_Price(itemOutGrid, rowNum, "OUTPUT_AMT", "PRICE");
                        //                itemStockGrid.Focus();
                        //                txt_bar.Text = "";
                        //                break;
                        //            }
                        //        }

                        //        if (!isInTheRow)
                        //        {
                        //            MessageBox.Show("현 거래처에 입고 데이터가 없습니다. 재확인해주십시오.");
                        //            txt_bar.Text = "";
                        //        }

                        //    }
                        //    else
                        //    {
                        //        MessageBox.Show("입고 데이터가 없습니다.");
                        //        txt_bar.Text = "";
                        //    }

                        //}
                    }
                    if (lotchk == 0)
                    {
                        MessageBox.Show("입고 데이터가 없습니다.");
                        txt_bar.Text = "";
                        return;

                    }
                    lotchk = 0;
                }
            }
        }

        private void btn_jumun_select_Click(object sender, EventArgs e)
        {
            try
            {
                Popup.pop주문서검색 msg = new Popup.pop주문서검색();
                msg.ShowDialog();

                if (msg.sjumun_date != null && !msg.sjumun_date.Equals(""))
                {
                    resetSetting();
                    lbl_jumun_date.Enabled = true;
                    lbl_jumun_cd.Enabled = true;
                    lbl_jumun_comment.Enabled = true;
                    lbl_cust_nm.BackColor = Color.MistyRose;
                    txt_jumun_date.Text = msg.sjumun_date;
                    txt_jumun_cd.Text = msg.sjumun_cd;
                    txt_jumun_comment.Text = msg.sjumun_comment;
                    txt_vat_cd.Text = msg.svat_cd;
                    txt_cust_cd.Text = msg.scust_cd;
                    txt_cust_nm.Text = msg.scust_nm;

                    Jumun_detail();
                    btnSerch.PerformClick();
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
                /*
                   A.JUMUN_DATE  ");
                  ,A.JUMUN_CD ");
                  ,A.SEQ ");
                  ,A.ITEM_CD ");
                  ,(SELECT ITEM_NM FROM N_ITEM_CODE WHERE ITEM_CD = A.ITEM_CD ) AS ITEM_NM ");
                  ,A.SPEC ");
                  ,A.UNIT_CD ");
                  ,(SELECT UNIT_NM FROM N_UNIT_CODE WHERE UNIT_CD = A.UNIT_CD) AS UNIT_NM ");
                  ,A.PRICE ");
                  ,A.AMOUNT ");
                  ,A.MONEY ");
                 */
                dt = wDm.select_jumun_detail_list(txt_jumun_date.Text, txt_jumun_cd.Text);
                if (dt != null)
                {
                    itemOutGrid.Rows.Clear();
                    itemOutGrid.RowCount = dt.Rows.Count;

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        itemOutGrid.Rows[i].DefaultCellStyle.BackColor = Color.MistyRose;
                        itemOutGrid.Rows[i].DefaultCellStyle.SelectionBackColor = Color.MistyRose;
                        itemOutGrid.Rows[i].Cells["O_LOT_NO"].Value = "";
                        itemOutGrid.Rows[i].Cells["O_LOT_SUB"].Value = "";
                        itemOutGrid.Rows[i].Cells["O_ITEM_CD"].Value = dt.Rows[i]["ITEM_CD"].ToString();
                        itemOutGrid.Rows[i].Cells["O_ITEM_NM"].Value = dt.Rows[i]["ITEM_NM"].ToString();
                        itemOutGrid.Rows[i].Cells["OUTPUT_AMT"].Value =  decimal.Parse(dt.Rows[i]["AMOUNT"].ToString()).ToString("#,0.######");
                        itemOutGrid.Rows[i].Cells["O_SPEC"].Value =  dt.Rows[i]["SPEC"].ToString();
                        itemOutGrid.Rows[i].Cells["PRICE"].Value = decimal.Parse(dt.Rows[i]["PRICE"].ToString()).ToString("#,0.######");
                        itemOutGrid.Rows[i].Cells["O_UNIT_CD"].Value =  dt.Rows[i]["UNIT_CD"].ToString();
                        itemOutGrid.Rows[i].Cells["O_UNIT_NM"].Value =  dt.Rows[i]["UNIT_NM"].ToString();
                        itemOutGrid.Rows[i].Cells["TOTAL_MONEY"].Value = decimal.Parse(dt.Rows[i]["MONEY"].ToString()).ToString("#,0.######");
                        itemOutGrid.Rows[i].Cells["O_INPUT_DATE"].Value = "";
                        itemOutGrid.Rows[i].Cells["O_INPUT_CD"].Value = "";
                        itemOutGrid.Rows[i].Cells["O_INPUT_SEQ"].Value = "";
                        itemOutGrid.Rows[i].Cells["O_CUST_CD"].Value = "";
                        itemOutGrid.Rows[i].Cells["O_TAX_CD"].Value = dt.Rows[i]["TAX_CD"].ToString();

                        wConst.f_Calc_Price(itemOutGrid, i, "OUTPUT_AMT", "PRICE", "TOTAL_MONEY", "O_SUPPLY_MONEY", "O_TAX_MONEY", "O_TOTAL_MONEY", txt_vat_cd.Text, itemOutGrid.Rows[i].Cells["O_TAX_CD"].Value.ToString());
                        wConst.f_Calc_SalesPrice(txt_supply_money
                            , txt_tax_money
                            , txt_total_money
                            , txt_vat_cd.Text
                            , txt_no_tax_money
                            , txt_yes_tax_money
                            , txt_yesno_money
                            , itemOutGrid
                            , "O_SUPPLY_MONEY"
                            , "O_TAX_MONEY"
                            , "O_TOTAL_MONEY"
                            , "O_TAX_CD"
                            , true
                            , "O_LOT_NO"
                            );


                    }
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

        private void cmb_soo_gubun_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_soo_gubun.SelectedIndex == 0)
            {
                txt_soo_money.ReadOnly = true;
                txt_dc_money.ReadOnly = true;
                txt_total_soo_money.ReadOnly = true;

                txt_soo_money.Enabled = false;
                txt_dc_money.Enabled = false;
                txt_total_soo_money.Enabled = false;

                txt_soo_money.Text = "0";
                txt_dc_money.Text = "0";
                txt_total_soo_money.Text = "0";
            }
            else
            {
                txt_soo_money.Enabled = true;
                txt_dc_money.Enabled = true;
                txt_total_soo_money.Enabled = true;

                txt_soo_money.ReadOnly = false;
                txt_dc_money.ReadOnly = false;
                txt_total_soo_money.ReadOnly = true;
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

            wnGConstant.cal_soo_money(txt_soo_money,txt_dc_money,txt_total_soo_money);
            tx.SelectionStart = tx.Text.Length;
        }

        private void soo_money_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tx = (TextBox)sender;
            tx.SelectionStart = tx.Text.Length;
            ComInfo.onlyNum(sender, e);
        }

        private void itemStockGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > -1)
            {
                if (itemStockGrid.Columns[e.ColumnIndex].Name == "SELECT")
                {
                    if (itemStockGrid.Rows.Count > 0)
                    {
                        int chk = 0;

                        for (int j = 0; j < itemOutGrid.Rows.Count; j++)
                        {
                            //if ((string)itemStockGrid.Rows[i].Cells["LOT_NO"].Value == (string)itemOutGrid.Rows[j].Cells["O_LOT_NO"].Value
                            //    && (string)itemStockGrid.Rows[i].Cells["LOT_SUB"].Value == (string)itemOutGrid.Rows[j].Cells["O_LOT_SUB"].Value
                            //    && (string)itemStockGrid.Rows[i].Cells["INPUT_SEQ"].Value == (string)itemOutGrid.Rows[j].Cells["O_INPUT_SEQ"].Value)
                            //{
                            //    MessageBox.Show("해당 출고할 제품이 이미 등록되어있습니다.");
                            //    return;
                            //}
                        }

                        for (int k = 0; k < del_outGrid.Rows.Count; k++)
                        {
                            if ((string)itemStockGrid.Rows[e.RowIndex].Cells["LOT_NO"].Value == (string)del_outGrid.Rows[k]["LOT_NO"].ToString()
                                && (string)itemStockGrid.Rows[e.RowIndex].Cells["LOT_SUB"].Value == (string)del_outGrid.Rows[k]["LOT_SUB"].ToString())
                            {
                                MessageBox.Show("해당 제품출고의 삭제데이터가 있어서 등록이 불가합니다.");
                                return;
                            }
                        }

                        if (itemOutGrid.Rows.Count > 0)
                        {
                            if (txt_cust_cd.Text != itemStockGrid.Rows[e.RowIndex].Cells["납품처코드"].Value.ToString() &&
                                (itemStockGrid.Rows[e.RowIndex].Cells["납품처코드"].Value != null && !itemStockGrid.Rows[e.RowIndex].Cells["납품처코드"].Value.ToString().Equals(""))
                                )
                            {
                                //MessageBox.Show("다른거래처는 등록할수 없습니다.");
                                //return;
                            }
                        }

                        if (txt_jumun_cd.Text != null && txt_jumun_cd.Text != "")
                        {
                            int row_index = -1;
                            for (int j = 0; j < itemOutGrid.Rows.Count; j++)
                            {
                                if (itemStockGrid.Rows[e.RowIndex].Cells["ITEM_CD"].Value.ToString().Equals(itemOutGrid.Rows[j].Cells["O_ITEM_CD"].Value.ToString()))
                                {
                                    if (itemOutGrid.Rows[j].Cells["O_LOT_NO"].Value == null || itemOutGrid.Rows[j].Cells["O_LOT_NO"].Value.ToString().Equals(""))
                                    {
                                        row_index = j;
                                        break;
                                    }
                                }
                            }

                            if (row_index != -1)
                            {
                                decimal Jumun_amt = decimal.Parse(itemOutGrid.Rows[row_index].Cells["OUTPUT_AMT"].Value.ToString().Replace(",", ""));
                                decimal stock_amt = decimal.Parse(itemStockGrid.Rows[e.RowIndex].Cells["STOCK_AMT"].Value.ToString().Replace(",", ""));

                                itemOutGrid.Rows[row_index].DefaultCellStyle.BackColor = Color.White;
                                itemOutGrid.Rows[row_index].DefaultCellStyle.SelectionBackColor = Color.LightYellow;
                                itemOutGrid.Rows[row_index].Cells["O_LOT_NO"].Value = itemStockGrid.Rows[e.RowIndex].Cells["LOT_NO"].Value.ToString();
                                itemOutGrid.Rows[row_index].Cells["O_LOT_SUB"].Value = itemStockGrid.Rows[e.RowIndex].Cells["LOT_SUB"].Value.ToString();
                                itemOutGrid.Rows[row_index].Cells["O_INPUT_DATE"].Value = itemStockGrid.Rows[e.RowIndex].Cells["INPUT_DATE"].Value.ToString();
                                itemOutGrid.Rows[row_index].Cells["O_INPUT_CD"].Value = itemStockGrid.Rows[e.RowIndex].Cells["INPUT_CD"].Value.ToString();
                                itemOutGrid.Rows[row_index].Cells["O_INPUT_SEQ"].Value = itemStockGrid.Rows[e.RowIndex].Cells["INPUT_SEQ"].Value.ToString();
                                itemOutGrid.Rows[row_index].Cells["OLD_OUT_AMT"].Value = itemStockGrid.Rows[e.RowIndex].Cells["STOCK_AMT"].Value.ToString();

                                chk = 1;

                                if (Jumun_amt > stock_amt)
                                {
                                    itemOutGrid.Rows[row_index].Cells["OUTPUT_AMT"].Value = stock_amt.ToString("#,0.######");
                                    wConst.f_Calc_Price(itemOutGrid, row_index, "OUTPUT_AMT", "PRICE");
                                    wConst.f_Calc_Price(itemOutGrid, row_index, "OUTPUT_AMT", "PRICE", "TOTAL_MONEY", "O_SUPPLY_MONEY", "O_TAX_MONEY", "O_TOTAL_MONEY", txt_vat_cd.Text, itemOutGrid.Rows[row_index].Cells["O_TAX_CD"].Value.ToString());
                                    wConst.f_Calc_SalesPrice(txt_supply_money
                                    , txt_tax_money
                                    , txt_total_money
                                    , txt_vat_cd.Text
                                    , txt_no_tax_money
                                    , txt_yes_tax_money
                                    , txt_yesno_money
                                    , itemOutGrid
                                    , "O_SUPPLY_MONEY"
                                    , "O_TAX_MONEY"
                                    , "O_TOTAL_MONEY"
                                    , "O_TAX_CD"
                                    , true
                                    , "O_LOT_NO"
                                    );
                                    string new_row_amt = (Jumun_amt - stock_amt).ToString("#,0.######");

                                    itemOutGrid.Rows.Insert(row_index + 1, 1);

                                    for (int k = 0; k < itemOutGrid.ColumnCount; k++)
                                    {
                                        itemOutGrid.Rows[row_index + 1].Cells[k].Value = itemOutGrid.Rows[row_index].Cells[k].Value;
                                    }

                                    itemOutGrid.Rows[row_index + 1].Cells[1].Value = row_index + 2;
                                    itemOutGrid.Rows[row_index + 1].Cells["O_LOT_NO"].Value = "";
                                    itemOutGrid.Rows[row_index + 1].Cells["O_LOT_SUB"].Value = "";
                                    itemOutGrid.Rows[row_index + 1].Cells["O_INPUT_DATE"].Value = "";
                                    itemOutGrid.Rows[row_index + 1].Cells["O_INPUT_CD"].Value = "";
                                    itemOutGrid.Rows[row_index + 1].Cells["O_INPUT_SEQ"].Value = "";
                                    itemOutGrid.Rows[row_index + 1].Cells["OUTPUT_AMT"].Value = (Jumun_amt - stock_amt).ToString("#,0.######");
                                    itemOutGrid.Rows[row_index + 1].Cells["OLD_OUT_AMT"].Value = "";
                                    itemOutGrid.Rows[row_index + 1].DefaultCellStyle.BackColor = Color.MistyRose;
                                    itemOutGrid.Rows[row_index + 1].DefaultCellStyle.SelectionBackColor = Color.MistyRose;
                                    wConst.f_Calc_Price(itemOutGrid, row_index + 1, "OUTPUT_AMT", "PRICE");
                                    wConst.f_Calc_Price(itemOutGrid, row_index + 1, "OUTPUT_AMT", "PRICE", "TOTAL_MONEY", "O_SUPPLY_MONEY", "O_TAX_MONEY", "O_TOTAL_MONEY", txt_vat_cd.Text, itemOutGrid.Rows[row_index + 1].Cells["O_TAX_CD"].Value.ToString());
                                    wConst.f_Calc_SalesPrice(txt_supply_money
                                    , txt_tax_money
                                    , txt_total_money
                                    , txt_vat_cd.Text
                                    , txt_no_tax_money
                                    , txt_yes_tax_money
                                    , txt_yesno_money
                                    , itemOutGrid
                                    , "O_SUPPLY_MONEY"
                                    , "O_TAX_MONEY"
                                    , "O_TOTAL_MONEY"
                                    , "O_TAX_CD"
                                    , true
                                    , "O_LOT_NO"
                                    );


                                    itemOutGrid.Focus();
                                    itemStockGrid.Rows[e.RowIndex].Visible = false;
                                    itemStockGrid.Rows[e.RowIndex].Cells["CHK"].Value = false;
                                }
                                else
                                {
                                    itemOutGrid.Focus();
                                    itemStockGrid.Rows[e.RowIndex].Visible = false;
                                    itemStockGrid.Rows[e.RowIndex].Cells["CHK"].Value = false;
                                }

                            }
                            else
                            {
                                chk = Up_Stock_to_OutGrid(chk, e.RowIndex);
                            }
                        }
                        else
                        {
                            chk = Up_Stock_to_OutGrid(chk, e.RowIndex);
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
            }
        }

        private void itemOutGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            conDataGridView grd = (conDataGridView)sender;
            DataGridViewCell cell = grd[e.ColumnIndex, e.RowIndex];
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0 && senderGrid.Columns[e.ColumnIndex].Name.Equals("DELETE"))
            {
                if (itemOutGrid.CurrentCell != null && btn_jumun_select.Enabled == true)
                {
                    if (itemOutGrid.Rows[e.RowIndex].Cells["O_LOT_NO"].Value == null || itemOutGrid.Rows[e.RowIndex].Cells["O_LOT_NO"].Value.ToString().Equals(""))
                    {
                        MessageBox.Show("주문서항목 행은 삭제할 수 업습니다.");
                        return;
                    }
                    else
                    {
                        if (txt_jumun_date.Text != null && !txt_jumun_date.Text.ToString().Equals(""))
                        {
                            string thisItemCd = itemOutGrid.Rows[e.RowIndex].Cells["O_ITEM_CD"].Value.ToString();
                            int thisIndex = e.RowIndex;
                            for (int i = 0; i < itemOutGrid.Rows.Count; i++)
                            {
                                if (i != e.RowIndex)
                                {
                                    if (itemOutGrid.Rows[i].Cells["O_ITEM_CD"].Value.ToString().Equals(thisItemCd))
                                    {
                                        thisIndex = -1;
                                        break;
                                    }
                                }
                            }

                            if (thisIndex != -1)
                            {
                                for (int i = 0; i < itemStockGrid.Rows.Count; i++)
                                {
                                    if (
                                          (String)itemOutGrid.SelectedRows[0].Cells["O_LOT_NO"].Value == (String)itemStockGrid.Rows[i].Cells["LOT_NO"].Value
                                          && (String)itemOutGrid.SelectedRows[0].Cells["O_LOT_SUB"].Value == (String)itemStockGrid.Rows[i].Cells["LOT_SUB"].Value
                                          && (String)itemOutGrid.SelectedRows[0].Cells["O_INPUT_DATE"].Value == (String)itemStockGrid.Rows[i].Cells["INPUT_DATE"].Value
                                          && (String)itemOutGrid.SelectedRows[0].Cells["O_INPUT_CD"].Value == (String)itemStockGrid.Rows[i].Cells["INPUT_CD"].Value
                                        )
                                    {
                                        itemStockGrid.Rows[i].Visible = true;
                                    }
                                }

                                itemOutGrid.Rows[thisIndex].Cells["OLD_OUT_AMT"].Value = "";
                                itemOutGrid.Rows[thisIndex].Cells["O_LOT_NO"].Value = "";
                                itemOutGrid.Rows[thisIndex].Cells["O_LOT_SUB"].Value = "";
                                itemOutGrid.Rows[thisIndex].Cells["O_INPUT_DATE"].Value = "";
                                itemOutGrid.Rows[thisIndex].Cells["O_INPUT_CD"].Value = "";
                                itemOutGrid.Rows[thisIndex].Cells["O_INPUT_SEQ"].Value = "";

                                itemOutGrid.Rows[thisIndex].DefaultCellStyle.BackColor = Color.MistyRose;
                                itemOutGrid.Rows[thisIndex].DefaultCellStyle.SelectionBackColor = Color.MistyRose;

                                wConst.f_Calc_SalesPrice(txt_supply_money
                                        , txt_tax_money
                                        , txt_total_money
                                        , txt_vat_cd.Text
                                        , txt_no_tax_money
                                        , txt_yes_tax_money
                                        , txt_yesno_money
                                        , itemOutGrid
                                        , "O_SUPPLY_MONEY"
                                        , "O_TAX_MONEY"
                                        , "O_TOTAL_MONEY"
                                        , "O_TAX_CD"
                                        , true
                                        , "O_LOT_NO"
                                        );
                                return;
                            }
                        }
                    }
                }





                for (int i = 0; i < itemStockGrid.Rows.Count; i++)
                {
                    if (
                          (String)itemOutGrid.SelectedRows[0].Cells["O_LOT_NO"].Value == (String)itemStockGrid.Rows[i].Cells["LOT_NO"].Value
                          && (String)itemOutGrid.SelectedRows[0].Cells["O_LOT_SUB"].Value == (String)itemStockGrid.Rows[i].Cells["LOT_SUB"].Value
                          && (String)itemOutGrid.SelectedRows[0].Cells["O_ITEM_CD"].Value == (String)itemStockGrid.Rows[i].Cells["ITEM_CD"].Value
                          && (String)itemOutGrid.SelectedRows[0].Cells["O_INPUT_DATE"].Value == (String)itemStockGrid.Rows[i].Cells["INPUT_DATE"].Value
                          && (String)itemOutGrid.SelectedRows[0].Cells["O_INPUT_CD"].Value == (String)itemStockGrid.Rows[i].Cells["INPUT_CD"].Value
                        )
                    {
                        itemStockGrid.Rows[i].Visible = true;
                    }
                }

                for (int i = 0; i < itemOutGrid.Rows.Count; i++)
                {
                    if (e.RowIndex == i) continue;
                    if (itemOutGrid.SelectedRows[0].Cells["O_ITEM_CD"].Value == itemOutGrid.Rows[i].Cells["O_ITEM_CD"].Value)
                    {
                        if (itemOutGrid.Rows[i].Cells["O_LOT_NO"].Value == null || itemOutGrid.Rows[i].Cells["O_LOT_NO"].Value.ToString().Equals(""))
                        {
                            itemOutGrid.Rows[i].Cells["OUTPUT_AMT"].Value = (decimal.Parse(itemOutGrid.Rows[i].Cells["OUTPUT_AMT"].Value.ToString())
                                + decimal.Parse(itemOutGrid.SelectedRows[0].Cells["OUTPUT_AMT"].Value.ToString())).ToString("#,0.######");
                            wConst.f_Calc_Price(itemOutGrid, i, "OUTPUT_AMT", "PRICE");
                            wConst.f_Calc_Price(itemOutGrid, i, "OUTPUT_AMT", "PRICE", "TOTAL_MONEY", "O_SUPPLY_MONEY", "O_TAX_MONEY", "O_TOTAL_MONEY", txt_vat_cd.Text, itemOutGrid.Rows[i].Cells["O_TAX_CD"].Value.ToString());
                            wConst.f_Calc_SalesPrice(txt_supply_money
                                        , txt_tax_money
                                        , txt_total_money
                                        , txt_vat_cd.Text
                                        , txt_no_tax_money
                                        , txt_yes_tax_money
                                        , txt_yesno_money
                                        , itemOutGrid
                                        , "O_SUPPLY_MONEY"
                                        , "O_TAX_MONEY"
                                        , "O_TOTAL_MONEY"
                                        , "O_TAX_CD"
                                        , true
                                        , "O_LOT_NO"
                                        );
                        }
                    }
                }




                if (itemOutGrid.Rows.Count > 0)
                {
                    if (itemOutGrid.Rows[e.RowIndex].Cells["SEQ"].Value != null && !itemOutGrid.Rows[e.RowIndex].Cells["SEQ"].Value.ToString().Equals(""))
                    {
                        del_outGrid.Rows.Add();
                        del_outGrid.Rows[del_outGrid.Rows.Count - 1]["SEQ"] = itemOutGrid.Rows[e.RowIndex].Cells["SEQ"].Value;
                        del_outGrid.Rows[del_outGrid.Rows.Count - 1]["J_SEQ"] = itemOutGrid.Rows[e.RowIndex].Cells["J_INPUT_SEQ"].Value;
                        del_outGrid.Rows[del_outGrid.Rows.Count - 1]["LOT_NO"] = itemOutGrid.Rows[e.RowIndex].Cells["O_LOT_NO"].Value;
                        del_outGrid.Rows[del_outGrid.Rows.Count - 1]["LOT_SUB"] = itemOutGrid.Rows[e.RowIndex].Cells["O_LOT_SUB"].Value;
                    }
                    itemOutGrid.Rows.RemoveAt(e.RowIndex);
                    wConst.f_Calc_SalesPrice(txt_supply_money
                                        , txt_tax_money
                                        , txt_total_money
                                        , txt_vat_cd.Text
                                        , txt_no_tax_money
                                        , txt_yes_tax_money
                                        , txt_yesno_money
                                        , itemOutGrid
                                        , "O_SUPPLY_MONEY"
                                        , "O_TAX_MONEY"
                                        , "O_TOTAL_MONEY"
                                        , "O_TAX_CD"
                                        , true
                                        , "O_LOT_NO"
                                        );
                }
            }

        }
        private void btn출력_Click(object sender, EventArgs e)
        {
            btn출력.Enabled = false;

            string strCondition = "";

            if (itemOutGrid.Rows.Count == 0)
            {
                MessageBox.Show("출력할 자료가 없습니다.");
                btn출력.Enabled = true;
                return;
            }


            strCondition = "매출처원장";

            wnDm wDm = new wnDm();


            DataTable myinfo = wDm.fn_Saup_List(Common.p_saupNo);
            DataTable custInfo = wDm.fn_Cust_List("WHERE A.CUST_CD = '" + txt_cust_cd.Text + "'  ");

            DataTable dtTemp = MakeFrmPrt();

            dtTemp.Rows.Clear();

            int countTemp = 7;
            int countTempPlusOne = countTemp + 1;
            for (int i = 0; i < itemOutGrid.Rows.Count; i++)
            {
                dtTemp.Rows.Add();

                dtTemp.Rows[i]["표시페이지"] = i / countTempPlusOne + 1;
                dtTemp.Rows[i]["표시순번"] = (i + 1).ToString();
                dtTemp.Rows[i]["매출일자"] = txt_out_date.Text;
                dtTemp.Rows[i]["전표번호"] = txt_out_cd.Text + "-" + (i / countTempPlusOne + 1).ToString();
                dtTemp.Rows[i]["거래처사업자번호"] = custInfo.Rows[0]["SAUP_NO"].ToString();
                dtTemp.Rows[i]["거래처명"] = custInfo.Rows[0]["CUST_NM"].ToString();
                dtTemp.Rows[i]["거래처대표자명"] = custInfo.Rows[0]["OWNER"].ToString();
                dtTemp.Rows[i]["주소"] = custInfo.Rows[0]["ADDR"].ToString();
                dtTemp.Rows[i]["배송사원명"] = custInfo.Rows[0]["CUST_PHONE"].ToString(); //상대거래처 전화번호
                dtTemp.Rows[i]["매출년월"] = custInfo.Rows[0]["CUST_FAX"].ToString(); //상대거래처 팩스
                dtTemp.Rows[i]["대체우편번호"] = myinfo.Rows[0]["COMP_PHONE"].ToString(); //사업자 전화번호
                dtTemp.Rows[i]["대체이메일"] = myinfo.Rows[0]["FAX"].ToString(); //사업자 팩스
                dtTemp.Rows[i]["대체사업자번호2"] = myinfo.Rows[0]["SAUP_NO"].ToString().Substring(0, 3) + "-" + myinfo.Rows[0]["SAUP_NO"].ToString().Substring(3, 2) + "-" + myinfo.Rows[0]["SAUP_NO"].ToString().Substring(5);
                //dtTemp.Rows[i]["대체사업자번호2"] = myinfo.Rows[0]["SAUP_NO"].ToString();
                dtTemp.Rows[i]["대체대표자"] = myinfo.Rows[0]["CEO_NAME"].ToString();
                dtTemp.Rows[i]["대체상호명"] = myinfo.Rows[0]["COMPANY_NM"].ToString();
                dtTemp.Rows[i]["대체종목"] = myinfo.Rows[0]["JONGMOK"].ToString();
                dtTemp.Rows[i]["대체주소"] = myinfo.Rows[0]["ADDR"].ToString() + myinfo.Rows[0]["ADDR2"].ToString();
                dtTemp.Rows[i]["입력금액계"] = txt_supply_money.Text;
                dtTemp.Rows[i]["부가세액계"] = txt_tax_money.Text;
                dtTemp.Rows[i]["포함금액계"] = txt_total_money.Text;

                dtTemp.Rows[i]["박스바코드"] = txt_yesterBal.Text;
                dtTemp.Rows[i]["중간바코드"] = txt_DaySalesMoney.Text;
                dtTemp.Rows[i]["낱개바코드"] = txt_DaySooMoney.Text;
                dtTemp.Rows[i]["상품비고"] = txt_Day_jango.Text;

                if (int.Parse(myinfo.Rows[0]["LOGO_SIZE"].ToString()) > 0)
                {
                    byte[] rs = (byte[])myinfo.Rows[0]["SAUP_LOGO"];
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(rs);
                    Image img = Image.FromStream(ms);

                    dtTemp.Rows[i]["입력방법"] = rs.ToString();
                }



                dtTemp.Rows[i]["상품명"] = itemOutGrid.Rows[i].Cells["O_ITEM_NM"].Value.ToString();
                dtTemp.Rows[i]["규격"] = itemOutGrid.Rows[i].Cells["O_SPEC"].Value.ToString();
                dtTemp.Rows[i]["낱개수량"] = itemOutGrid.Rows[i].Cells["OUTPUT_AMT"].Value.ToString() + itemOutGrid.Rows[i].Cells["O_UNIT_NM"].Value.ToString();
                dtTemp.Rows[i]["낱개단가"] = itemOutGrid.Rows[i].Cells["PRICE"].Value.ToString();
                dtTemp.Rows[i]["포함금액"] = itemOutGrid.Rows[i].Cells["TOTAL_MONEY"].Value.ToString();
                //dtTemp.Rows[i]["박스수량"] = itemOutGrid.Rows[i].Cells["PAC_AMT"].Value.ToString();
                dtTemp.Rows[i]["비고"] = itemOutGrid.Rows[i].Cells["O_LOT_NO"].Value.ToString() + "-" + itemOutGrid.Rows[i].Cells["O_LOT_SUB"].Value.ToString(); ;
                //dtTemp.Rows[i]["상품폰트"] = itemOutGrid.Rows[i].Cells["COUNTRY_NM"].Value.ToString();
                //dtTemp.Rows[i]["규격폰트"] = itemOutGrid.Rows[i].Cells["FROZEN_NM"].Value.ToString();
                if(!myinfo.Rows[0]["ACCOUNT"].ToString().Equals(""))
                {
                    dtTemp.Rows[i]["박스수량계"] = myinfo.Rows[0]["ACCOUNT"].ToString();
                    if (!myinfo.Rows[0]["ACCOUNT2"].ToString().Equals(""))
                    {
                        dtTemp.Rows[i]["박스수량계"] = myinfo.Rows[0]["ACCOUNT"] + "\n◎" + myinfo.Rows[0]["ACCOUNT2"];
                    }
                }

            }

            if (dtTemp.Rows.Count % countTemp > 0)
            {
                int temp = dtTemp.Rows.Count;
                for (int i = 0; i < countTemp - temp % countTemp; i++)
                {
                    dtTemp.Rows.Add();

                    dtTemp.Rows[i + temp]["표시페이지"] = (i + temp) / countTempPlusOne + 1;
                    dtTemp.Rows[i + temp]["표시순번"] = ((i + temp) + 1).ToString();
                    dtTemp.Rows[i + temp]["매출일자"] = txt_out_date.Text;
                    dtTemp.Rows[i + temp]["전표번호"] = txt_out_cd.Text + "-" + ((i + temp) / countTempPlusOne + 1).ToString();
                    dtTemp.Rows[i + temp]["거래처사업자번호"] = custInfo.Rows[0]["SAUP_NO"].ToString();
                    dtTemp.Rows[i + temp]["거래처명"] = custInfo.Rows[0]["CUST_NM"].ToString();
                    dtTemp.Rows[i + temp]["주소"] = custInfo.Rows[0]["ADDR"].ToString();
                    dtTemp.Rows[i + temp]["대체사업자번호2"] = myinfo.Rows[0]["SAUP_NO"].ToString().Substring(0, 3) + "-" + myinfo.Rows[0]["SAUP_NO"].ToString().Substring(3, 2) + "-" + myinfo.Rows[0]["SAUP_NO"].ToString().Substring(5);
                    dtTemp.Rows[i + temp]["대체대표자"] = myinfo.Rows[0]["CEO_NAME"].ToString();
                    dtTemp.Rows[i + temp]["대체상호명"] = myinfo.Rows[0]["COMPANY_NM"].ToString();
                    dtTemp.Rows[i + temp]["대체종목"] = myinfo.Rows[0]["JONGMOK"].ToString();
                    dtTemp.Rows[i + temp]["대체주소"] = myinfo.Rows[0]["ADDR"].ToString() + myinfo.Rows[0]["ADDR2"].ToString();
                    dtTemp.Rows[i + temp]["입력금액계"] = txt_supply_money.Text;
                    dtTemp.Rows[i + temp]["부가세액계"] = txt_tax_money.Text;
                    dtTemp.Rows[i + temp]["포함금액계"] = txt_total_money.Text;

                    dtTemp.Rows[i]["박스바코드"] = txt_yesterBal.Text;
                    dtTemp.Rows[i]["중간바코드"] = txt_DaySalesMoney.Text;
                    dtTemp.Rows[i]["낱개바코드"] = txt_DaySooMoney.Text;
                    dtTemp.Rows[i]["상품비고"] = txt_Day_jango.Text;

                    dtTemp.Rows[i + temp]["상품명"] = "";
                    dtTemp.Rows[i + temp]["규격"] = "";
                    dtTemp.Rows[i + temp]["낱개수량"] = "";
                    dtTemp.Rows[i + temp]["낱개단가"] = "";
                    dtTemp.Rows[i + temp]["포함금액"] = "";
                    dtTemp.Rows[i + temp]["박스수량"] = "";
                    dtTemp.Rows[i + temp]["비고"] = "";
                    dtTemp.Rows[i + temp]["상품폰트"] = "";
                    dtTemp.Rows[i + temp]["규격폰트"] = "";
                }

            }
            frmPrt = readyPrt;
            frmPrt.Show();
            frmPrt.BringToFront();
            //frmPrt.prt_원자재재고현황(adoPrt, strDay1, strDay2, strCust, strCondition);
            frmPrt.prt_거래명세표(dtTemp, itemOutGrid, strCondition);

            btn출력.Enabled = true;
        }


        private DataTable MakeFrmPrt()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("   SELECT           ");

            sb.AppendLine(" '' AS 매출일자             ");
            sb.AppendLine(",'' AS 전표번호             ");
            sb.AppendLine(",'' AS 항목번호             ");
            sb.AppendLine(",'' AS 입력방법             ");
            sb.AppendLine(",'' AS 매출구분명           ");
            sb.AppendLine(",'' AS 매출시각             ");
            sb.AppendLine(",'' AS 서명일시             ");
            sb.AppendLine(",'' AS 거래처명             ");
            sb.AppendLine(",'' AS 거래처사업자번호     ");
            sb.AppendLine(",'' AS 거래처대표자명       ");
            sb.AppendLine(",'' AS 계좌별칭             ");
            sb.AppendLine(",'' AS 주소                 ");
            sb.AppendLine(",'' AS 전잔고               ");
            sb.AppendLine(",'' AS 당일매출액           ");
            sb.AppendLine(",'' AS 당일수금액           ");
            sb.AppendLine(",'' AS 잔고                 ");
            sb.AppendLine(",'' AS 상품코드             ");
            sb.AppendLine(",'' AS 상품명               ");
            sb.AppendLine(",'' AS 규격                 ");
            sb.AppendLine(",'' AS 낱개수량계           ");
            sb.AppendLine(",'' AS 입력금액계           ");
            sb.AppendLine(",'' AS 부가세액계           ");
            sb.AppendLine(",'' AS 총수량계             ");
            sb.AppendLine(",'' AS 포함금액계           ");
            sb.AppendLine(",'' AS 대체사업자번호       ");
            sb.AppendLine(",'' AS 대체사업자번호2      ");
            sb.AppendLine(",'' AS 대체대표자           ");
            sb.AppendLine(",'' AS 대체상호명           ");
            sb.AppendLine(",'' AS 대체연락처           ");
            sb.AppendLine(",'' AS 대체이메일           ");
            sb.AppendLine(",'' AS 대체업태             ");
            sb.AppendLine(",'' AS 대체종목             ");
            sb.AppendLine(",'' AS 대체우편번호         ");
            sb.AppendLine(",'' AS 대체주소             ");
            sb.AppendLine(",'' AS 대체직인파일         ");
            sb.AppendLine(",'' AS 대체공지컴퓨터       ");
            sb.AppendLine(",'' AS 상품폰트             ");
            sb.AppendLine(",'' AS 규격폰트             ");
            sb.AppendLine(",'' AS 상품상세명           ");
            sb.AppendLine(",'' AS 박스수량             ");
            sb.AppendLine(",'' AS 중간수량             ");
            sb.AppendLine(",'' AS 낱개수량             ");
            sb.AppendLine(",'' AS 박스표시             ");
            sb.AppendLine(",'' AS 총수량               ");
            sb.AppendLine(",'' AS 박스단가             ");
            sb.AppendLine(",'' AS 낱개단가             ");
            sb.AppendLine(",'' AS 금액                 ");
            sb.AppendLine(",'' AS 부가세액             ");
            sb.AppendLine(",'' AS 포함금액             ");
            sb.AppendLine(",'' AS 서비스박스           ");
            sb.AppendLine(",'' AS 서비스낱개           ");
            sb.AppendLine(",'' AS 배송사원명           ");
            sb.AppendLine(",'' AS 비고                 ");
            sb.AppendLine(",'' AS 표시순번             ");
            sb.AppendLine(",'' AS 페이지그룹           ");
            sb.AppendLine(",'' AS 표시페이지           ");
            sb.AppendLine(",'' AS 박스바코드           ");
            sb.AppendLine(",'' AS 중간바코드           ");
            sb.AppendLine(",'' AS 낱개바코드           ");
            sb.AppendLine(",'' AS 상품비고             ");
            sb.AppendLine(",'' AS 매출년월             ");
            sb.AppendLine(",'' AS 박스수량계           ");
            sb.AppendLine(",'' AS 중간수량계           ");
            

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
                    btnNew.PerformClick();
                    break;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
            return true;
        }
    }
}
