using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MES.CLS;
using MES.Controls;
using System.Diagnostics;

namespace MES.P85_BAS
{
    public partial class frm제품등록 : Form
    {
        Popup.frmPrint readyPrt = new Popup.frmPrint();
        //private wnGConstant wConst = new wnGConstant();

        DataTable adoPrt = null;
        wnAdo wAdo = new wnAdo();
        public Popup.frmPrint frmPrt;

        public string strCondition = "";

        Popup.pop도면등록 도면등록 = new Popup.pop도면등록();
        private Image cus_img;
        private wnGConstant wConst = new wnGConstant();
        private ComInfo comInfo = new ComInfo();
        private DataGridView del_compGrid = new DataGridView();
        private DataGridView del_flowGrid = new DataGridView();
        private DataGridView del_halfGrid = new DataGridView();
        public static bool p_IsAuth = true;    // 열람권한
        public static bool p_Isrgstr = true;    //등록/수정 권한
        wnDm wnDm = new wnDm();
        public static bool p_Isdel = true;    // 삭제 권한
        private string[] autoSelect;
        private bool[] right = new bool[2];
        
        public frm제품등록()
        {
            InitializeComponent();

            this.itemRawGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellEndEdit);
            this.itemRawGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grid_KeyDown);
            this.itemRawGrid.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grid_ColumnHeaderMouseClick);
            this.itemRawGrid.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.grid_RowsAdded);
            this.itemRawGrid.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.grid_RowsRemoved);
            this.itemRawGrid.CellValueChanged += new DataGridViewCellEventHandler(grid_CellValueChanged);
            this.itemRawGrid.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.grid_ColumnWidthChanged);
            this.itemRawGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellDoubleClick);

            this.itemFlowGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellEndEdit2);
            this.itemFlowGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grid_KeyDown);
            this.itemFlowGrid.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grid_ColumnHeaderMouseClick);
            //this.itemFlowGrid.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.grid_RowsAdded);
            this.itemFlowGrid.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.grid_RowsRemoved);
            this.itemFlowGrid.CellValueChanged += new DataGridViewCellEventHandler(grid_CellValueChanged);
            this.itemFlowGrid.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.grid_ColumnWidthChanged);
            this.itemFlowGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellDoubleClick2);

            this.itemHalfGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellEndEdit3);
            this.itemHalfGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grid_KeyDown);
            this.itemHalfGrid.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grid_ColumnHeaderMouseClick);
            this.itemHalfGrid.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.grid_RowsAdded);
            this.itemHalfGrid.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.grid_RowsRemoved);
            this.itemHalfGrid.CellValueChanged += new DataGridViewCellEventHandler(grid_CellValueChanged);
            this.itemHalfGrid.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.grid_ColumnWidthChanged);
            this.itemHalfGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellDoubleClick3);
        }

        private void frm제품등록_Load(object sender, EventArgs e)
        {
            lbl_title.Tag = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[0] + "$" + wnDm.fn_TitleName(this.Name.ToString()).Split('$')[1]; lbl_title.Text = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[2];

            right = wConst.btnRight(lbl_title.Tag.ToString());
            init_ComboBox();
            item_list();

            itemCompGridAdd();

            //this.itemRawGrid = new ItemGrid();

            itemFlowGridAdd();
            itemHalfGridAdd();

            del_compGrid.AllowUserToAddRows = false;
            del_flowGrid.AllowUserToAddRows = false;
            del_halfGrid.AllowUserToAddRows = false;

            del_compGrid.Columns.Add("ITEM_CD", "ITEM_CD");
            del_compGrid.Columns.Add("SEQ", "SEQ");
            del_flowGrid.Columns.Add("F_ITEM_CD", "F_ITEM_CD");
            del_flowGrid.Columns.Add("F_SEQ", "F_SEQ");

            del_halfGrid.Columns.Add("MAIN_ITEM_CD", "MAIN_ITEM_CD");
            del_halfGrid.Columns.Add("H_SEQ", "H_SEQ");


            if (Common.sp_code == "800")
            /// 품번, 적정재고, 제품중량, 장입수량, 포장수량, 설비.
            /// 동명,드림아트 메뉴삭제 요청 
            {
                lbl품번.Visible = false;
                conTextBox3.Visible = false;
                lbl설비.Visible = false;
                cmb_line.Visible = false;
                lbl적정재고.Visible = false;
                txt_prop_stock.Visible = false;
                lbl제품중량.Visible = false;
                lbl장입수량.Visible = false;
                txt_item_weight.Visible = false;
                txt_char_amt.Visible = false;
                lbl포장수량.Visible = false;
                txt_pack_amt.Visible = false;

            }

            //DataTable dt = wnDm.fn_Raw_Name_List();
            //autoSelect = new string[dt.Rows.Count];
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    autoSelect[i] = dt.Rows[i]["RAW_MAT_NM"].ToString();
            //}


        }

        #region top menu
        private void btnNew_Click(object sender, EventArgs e)
        {
            resetSetting();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (right[0])
            {
                item_logic();

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
                item_del();

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
        #endregion top menu

        #region item logic
        private void init_ComboBox()
        {
            ComInfo comInfo = new ComInfo();
            string sqlQuery = "";

            cmb_type.ValueMember = "코드";
            cmb_type.DisplayMember = "명칭";
            sqlQuery = comInfo.queryType("and  L_CODE = '3'");
            wConst.ComboBox_Read_Blank(cmb_type, sqlQuery);

            cmb_line.ValueMember = "코드";
            cmb_line.DisplayMember = "명칭";
            sqlQuery = comInfo.queryLine();
            wConst.ComboBox_Read_Blank(cmb_line, sqlQuery);

            cmb_unit.ValueMember = "코드";
            cmb_unit.DisplayMember = "명칭";
            sqlQuery = comInfo.queryUnit();
            wConst.ComboBox_Read_Blank(cmb_unit, sqlQuery);

            cmb_cust.ValueMember = "코드";
            cmb_cust.DisplayMember = "명칭";
            sqlQuery = comInfo.queryCustUsed("1");
            wConst.ComboBox_Read_Blank(cmb_cust, sqlQuery);

            cmb_used.ValueMember = "코드";
            cmb_used.DisplayMember = "명칭";
            sqlQuery = comInfo.queryUsedYn();
            wConst.ComboBox_Read_NoBlank(cmb_used, sqlQuery);

            cmb_item_gbn.ValueMember = "코드";
            cmb_item_gbn.DisplayMember = "명칭";
            sqlQuery = comInfo.queryCode("400");
            wConst.ComboBox_Read_Blank(cmb_item_gbn, sqlQuery);

            cmb_srch_gbn.ValueMember = "코드";
            cmb_srch_gbn.DisplayMember = "명칭";
            sqlQuery = comInfo.queryItemGbnAll();
            wConst.ComboBox_Read_NoBlank(cmb_srch_gbn, sqlQuery);

            cmb_used_srch.ValueMember = "코드";
            cmb_used_srch.DisplayMember = "명칭";
            sqlQuery = comInfo.queryCustUsedYnAll(); //사용여부검색
            wConst.ComboBox_Read_NoBlank(cmb_used_srch, sqlQuery);

            cmb_vat_cd.ValueMember = "코드";
            cmb_vat_cd.DisplayMember = "명칭";
            sqlQuery = comInfo.queryCode("900");
            wConst.ComboBox_Read_NoBlank(cmb_vat_cd, sqlQuery);


            cmb_stor_loc.ValueMember = "코드";
            cmb_stor_loc.DisplayMember = "명칭";
            sqlQuery = comInfo.queryStorage(); //창고
            wConst.ComboBox_Read_Blank(cmb_stor_loc, sqlQuery);


            cmb_mold.ValueMember = "코드";
            cmb_mold.DisplayMember = "명칭";
            sqlQuery = comInfo.queryMold(); //창고
            wConst.ComboBox_Read_Blank(cmb_mold, sqlQuery);

        }

        private void resetSetting()
        {
            lbl_item_gbn.Text = "";
            btnDelete.Enabled = false;
            txt_item_cd.Text = "";
            txt_item_cd.Enabled = true;
            txt_item_nm.Text = "";
            txt_spec.Text = "";
            cmb_item_gbn.SelectedIndex = 0;
            cmb_type.SelectedIndex = 0;
            cmb_line.SelectedIndex = 0;
            cmb_unit.SelectedIndex = 0;
            txt_prop_stock.Text = "0";
            txt_item_weight.Text = "0";
            txt_input_price.Text = "0";
            txt_output_price.Text = "0";
            txt_char_amt.Text = "0";
            txt_pack_amt.Text = "0";
            cmb_cust.SelectedIndex = 0;
            chk_print_yn.Checked = false;
            cmb_used.SelectedIndex = 0;
            txt_link_inpaut_nm.Text = "";
            conTextBox3.Text = "";

            txt_box_bar_cd.Text = "";
            txt_box_amt.Text = "";
            txt_unit_bar_cd.Text = "";
            txt_link_input.Text = "";

            itemRawGrid.Rows.Clear();
            itemFlowGrid.Rows.Clear();
            itemHalfGrid.Rows.Clear();

            itemCompGridAdd();
            itemFlowGridAdd();
            itemHalfGridAdd();

            del_compGrid.Rows.Clear();
            del_flowGrid.Rows.Clear();
            del_halfGrid.Rows.Clear();
            txt_item_cd.Focus();

            lbl중복확인.Text = "중복확인 은 필수입니다.";
            lbl중복확인.ForeColor = Color.Red;

            도면등록.dgv_picture.Rows.Clear();
        }

        private bool CheckFlowGridOrder()
        {
            for (int i = 0; i < itemFlowGrid.Rows.Count; i++)
            {
                if (itemFlowGrid.Rows[i].Cells["FLOW_CD"].Value != null && !itemFlowGrid.Rows[i].Cells["FLOW_CD"].Value.ToString().Equals(""))
                {
                    if (itemFlowGrid.Rows[i].Cells["FLOW_SEQ"].Value == null || itemFlowGrid.Rows[i].Cells["FLOW_SEQ"].Value.ToString().Equals(""))
                    {
                        int maxTemp = 0;
                        for (int j = 0; j < itemFlowGrid.Rows.Count; j++)
                        {
                            try
                            {
                                if (itemFlowGrid.Rows[j].Cells["FLOW_SEQ"].Value == null
                                    || itemFlowGrid.Rows[j].Cells["FLOW_SEQ"].Value.ToString().Equals("")) continue;
                                else
                                {
                                    if (maxTemp < int.Parse(itemFlowGrid.Rows[j].Cells["FLOW_SEQ"].Value.ToString()))
                                    {
                                        maxTemp = int.Parse(itemFlowGrid.Rows[j].Cells["FLOW_SEQ"].Value.ToString());
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("공정 순서는 반드시 정수로 입력하여주십시오");
                                return false;
                            }
                        }
                        itemFlowGrid.Rows[i].Cells["FLOW_SEQ"].Value = (maxTemp + 1).ToString();
                    }
                }
            }
            return true;
        }



        private void item_logic()
        {

            /// 제품 식별표 체크가 하나도 안 돼있을 때
            ///마지막에 체크 걸어주겠다. 
            ///
            int 제품식별표_체크갯수=0;
            for (int i = 0; i < itemFlowGrid.Rows.Count; i++)
            {
                bool 제품식별표체크확인 = Convert.ToBoolean(itemFlowGrid.Rows[i].Cells["식별표"].Value);
                if (제품식별표체크확인==true)
                {
                    제품식별표_체크갯수++;
                }
            }
            if (itemFlowGrid.Rows.Count > 0 && 제품식별표_체크갯수==0) 
            {
                MessageBox.Show("제품식별 공정을 체크 하지 않아 마지막공정에 제품식별표를 출력하겠습니다.");
                itemFlowGrid.Rows[itemFlowGrid.Rows.Count - 1].Cells["식별표"].Value = true;
            }

            try
            {
                if (cmb_type.SelectedValue == null) cmb_type.SelectedValue = "";
                if (cmb_line.SelectedValue == null) cmb_line.SelectedValue = "";
                if (cmb_unit.SelectedValue == null) cmb_unit.SelectedValue = "";
                if (cmb_line.SelectedValue == null) cmb_line.SelectedValue = "";
                if (cmb_cust.SelectedValue == null) cmb_cust.SelectedValue = "";
                if (cmb_used.SelectedValue == null) cmb_used.SelectedValue = "";
                if (cmb_item_gbn.SelectedValue == null) cmb_item_gbn.SelectedValue = "";

                if (txt_item_cd.Text.ToString().Equals(""))
                {
                    MessageBox.Show("제품코드를 입력하시기 바랍니다.");
                    return;
                }
                if (txt_item_nm.Text.ToString().Equals(""))
                {
                    MessageBox.Show("제품명을 입력하시기 바랍니다.");
                    return;
                }
                if (cmb_unit.SelectedIndex == 0 || cmb_unit == null)
                {
                    MessageBox.Show("단위코드를 선택하시기 바랍니다.");
                    return;
                }
                //if (cmb_cust.SelectedIndex == 0 || cmb_cust == null)
                //{
                //    MessageBox.Show("거래처명을 선택하시기 바랍니다.");
                //    return;
                //}
                if (cmb_item_gbn.SelectedIndex == 0 || cmb_item_gbn == null)
                {
                    MessageBox.Show("제품구분을 선택하시기 바랍니다.");
                    return;
                }
                if (cmb_vat_cd.SelectedIndex == -1 || cmb_vat_cd == null)
                {
                    MessageBox.Show("과세구분을 선택하시기 바랍니다.");
                    return;
                }

                if (itemRawGrid.Rows.Count > 0)
                {
                    int cnt = 0;
                    int grid_cnt = itemRawGrid.Rows.Count;
                    for (int i = 0; i < grid_cnt; i++)
                    {
                        string txt_raw_mat_cd = (string)itemRawGrid.Rows[i - cnt].Cells["RAW_MAT_CD"].Value;

                        if (txt_raw_mat_cd == "" || txt_raw_mat_cd == null)  //마지막 행에 원자재코드가 없을 경우 제거
                        {
                            itemRawGrid.Rows.RemoveAt(i - cnt);
                            cnt++;
                        }
                    }
                }
                //if (itemRawGrid.Rows.Count <= 0)
                //{
                //    MessageBox.Show("제품에 필요한 원자재가 하나 이상 등록하세요.");
                //    return;
                //}

                if (itemFlowGrid.Rows.Count > 0)
                {
                    int cnt = 0;
                    int grid_cnt = itemFlowGrid.Rows.Count;
                    for (int i = 0; i < grid_cnt; i++)
                    {
                        string txt_flow_cd = (string)itemFlowGrid.Rows[i - cnt].Cells["FLOW_CD"].Value;

                        if (txt_flow_cd == "" || txt_flow_cd == null)  //마지막 행에 원자재코드가 없을 경우 제거
                        {
                            itemFlowGrid.Rows.RemoveAt(i - cnt);
                            cnt++;
                        }
                    }
                }

                if (itemHalfGrid.Rows.Count > 0)
                {
                    int cnt = 0;
                    int grid_cnt = itemHalfGrid.Rows.Count;
                    for (int i = 0; i < grid_cnt; i++)
                    {
                        string txt_half_item_cd = (string)itemHalfGrid.Rows[i - cnt].Cells["HALF_ITEM_CD"].Value;

                        if (txt_half_item_cd == "" || txt_half_item_cd == null)  //마지막 행에 원자재코드가 없을 경우 제거
                        {
                            itemHalfGrid.Rows.RemoveAt(i - cnt);
                            cnt++;
                        }
                    }

                }

                if (itemFlowGrid.Rows.Count > 0)
                {
                    int cnt = 0;
                    for (int i = 0; i < itemFlowGrid.Rows.Count; i++)
                    {

                        if (itemFlowGrid.Rows[i].Cells["식별표"].Value != null && (bool)itemFlowGrid.Rows[i].Cells["식별표"].Value)
                        {
                            cnt++;
                        }

                    }
                    if (cnt == 0)
                    {
                        MessageBox.Show(" 완제품식별표가 나오는 공정을 체크해주세요. ");
                        return;
                    }


                }

                if (!CheckFlowGridOrder())
                {
                    return;
                }

                for (int i = 0; i < itemFlowGrid.Rows.Count; i++)
                {
                    for (int j = i+1; j < itemFlowGrid.Rows.Count; j++)
                    {
                        if (itemFlowGrid.Rows[i].Cells["FLOW_CD"].Value.ToString().Equals(itemFlowGrid.Rows[j].Cells["FLOW_CD"].Value.ToString()))
                        {
                            MessageBox.Show("동일 공정이 중복입력되었습니다.");
                            return;
                        }
                    }
                }

                for (int i = 0; i < itemRawGrid.Rows.Count; i++)
                {
                    if (itemRawGrid.Rows[i].Cells["TOTAL_AMT"].Value == null
                        || itemRawGrid.Rows[i].Cells["TOTAL_AMT"].Value.ToString().Equals("0")
                        || itemRawGrid.Rows[i].Cells["TOTAL_AMT"].Value.ToString().Equals(""))
                    {
                        DataGridViewCellStyle st = new DataGridViewCellStyle();
                        st.BackColor = Color.Red;
                        st.SelectionBackColor = Color.Red;
                        itemRawGrid.Rows[i].Cells["TOTAL_AMT"].Style = st;
                        MessageBox.Show("원부재료 소요량값이 0입니다.");
                        st.BackColor = SystemColors.Window;
                        st.SelectionBackColor = Color.LightYellow;
                        itemRawGrid.Rows[i].Cells["TOTAL_AMT"].Style = st;
                        return;
                    }
                }

                /*
               if (도면등록.dgv_picture.Rows.Count > 0) //등록된 도면이 있을때
               {
                   for (int i = 0; i < 도면등록.dgv_picture.Rows.Count; i++)
                   {
                       if (도면등록.dgv_picture.Rows[i].Cells["PICTURE"].Value == null)
                       {
                           도면등록.dgv_picture.Rows.Remove(도면등록.dgv_picture.Rows[i]);
                       }
                   }
               }
               */

                string print_yn = comInfo.resultYn(chk_print_yn);
                if (Common.p_saupNo != "6091692803")
                {
                    if (lbl_item_gbn.Text != "1")
                    {

                        wnDm wDm = new wnDm();

                        int rsNum = wDm.insertItem(
                                        txt_item_cd.Text.ToString()
                                        , txt_item_nm.Text.ToString()
                                        , cmb_item_gbn.SelectedValue.ToString()
                                        , txt_spec.Text.ToString()
                                        , cmb_type.SelectedValue.ToString()
                                        , cmb_line.SelectedValue.ToString()
                                        , cmb_unit.SelectedValue.ToString()
                                        , ""
                                        , double.Parse(txt_prop_stock.Text.ToString())
                                        , double.Parse(txt_item_weight.Text.ToString())
                                        , double.Parse(txt_input_price.Text.ToString())
                                        , double.Parse(txt_output_price.Text.ToString())
                                        , double.Parse(txt_char_amt.Text.ToString())
                                        , double.Parse(txt_pack_amt.Text.ToString())
                                        , cmb_cust.SelectedValue.ToString()
                                        , print_yn
                                        , cmb_used.SelectedValue.ToString()
                                        , input_date.Text.ToString()
                                        , txt_box_bar_cd.Text.ToString()
                                        , txt_box_amt.Text.ToString()
                                        , txt_unit_bar_cd.Text.ToString()
                                        , txt_unit_amt.Text.ToString()
                                        , txt_comment.Text.ToString()
                                        , (txt_link_input.Text != null ? txt_link_input.Text.ToString() : "")
                                        , (string)cmb_vat_cd.SelectedValue ?? ""  //0115
                                        , itemRawGrid
                                        , itemFlowGrid
                                        , itemHalfGrid
                                        , 도면등록.dgv_picture
                                        );

                        if (rsNum == 0)
                        {
                            resetSetting();
                            item_list();
                            MessageBox.Show("성공적으로 등록하였습니다.");
                        }
                        else if (rsNum == 1)
                            MessageBox.Show("저장에 실패하였습니다");
                        else if (rsNum == 2)
                            MessageBox.Show("SQL COMMAND 에러");
                        else if (rsNum == 3)
                            MessageBox.Show("기존 코드가 있으니 \n 다른 코드로 입력 바랍니다.");
                        else if (rsNum == 4)
                            MessageBox.Show("장터지기 등록에러.");
                        else
                            MessageBox.Show("Exception 에러");
                    }
                    else
                    {
                        if (!right[1])
                        {
                            MessageBox.Show("권한이 없습니다.");
                            return;
                        }

                        wnDm wDm = new wnDm();
                        int rsNum = wDm.updateItem(
                                        txt_item_cd.Text.ToString()
                                        , txt_item_nm.Text.ToString()
                                        , cmb_item_gbn.SelectedValue.ToString()
                                        , txt_spec.Text.ToString()
                                        , cmb_type.SelectedValue.ToString()
                                        , cmb_line.SelectedValue.ToString()
                                        , cmb_unit.SelectedValue.ToString()
                                        , ""
                                        , double.Parse(txt_prop_stock.Text.ToString())
                                        , double.Parse(txt_item_weight.Text.ToString())
                                        , double.Parse(txt_input_price.Text.ToString())
                                        , double.Parse(txt_output_price.Text.ToString())
                                        , double.Parse(txt_char_amt.Text.ToString())
                                        , double.Parse(txt_pack_amt.Text.ToString())
                                        , cmb_cust.SelectedValue.ToString()
                                        , print_yn
                                        , cmb_used.SelectedValue.ToString()
                                        , input_date.Text.ToString()
                                        , txt_box_bar_cd.Text.ToString()
                                        , txt_box_amt.Text.ToString()
                                        , txt_unit_bar_cd.Text.ToString()
                                        , txt_unit_amt.Text.ToString()
                                        , txt_comment.Text.ToString()
                                        , (txt_link_input.Text != null ? txt_link_input.Text.ToString() : "")
                                       , (string)cmb_vat_cd.SelectedValue ?? ""//0115
                                        , itemRawGrid
                                        , itemFlowGrid
                                        , itemHalfGrid
                                        , del_compGrid
                                        , del_flowGrid
                                        , del_halfGrid
                                        , 도면등록.dgv_picture
                                        , 도면등록.del_dgv_picture);

                        if (rsNum == 0)
                        {
                            del_compGrid.Rows.Clear(); //기존 삭제 데이터할 제품구성 리스트 초기화
                            del_flowGrid.Rows.Clear();
                            del_halfGrid.Rows.Clear();
                            item_list();
                            gridDetail("where A.item_cd = '" + txt_item_cd.Text.ToString() + "'");
                            MessageBox.Show("성공적으로 수정하였습니다.");
                        }
                        else if (rsNum == 1)
                            MessageBox.Show("저장에 실패하였습니다");
                        else
                            MessageBox.Show("Exception 에러");
                    }
                }
                else
                {
                    if (lbl_item_gbn.Text != "1")
                    {

                        wnDm wDm = new wnDm();

                        int rsNum = wDm.insertItem(
                                        txt_item_cd.Text.ToString()
                                        , txt_item_nm.Text.ToString()
                                        , cmb_item_gbn.SelectedValue.ToString()
                                        , txt_spec.Text.ToString()
                                        , cmb_type.SelectedValue.ToString()
                                        , cmb_line.SelectedValue.ToString()
                                        , cmb_unit.SelectedValue.ToString()
                                        , ""
                                        , double.Parse(txt_prop_stock.Text.ToString())
                                        , double.Parse(txt_item_weight.Text.ToString())
                                        , double.Parse(txt_input_price.Text.ToString())
                                        , double.Parse(txt_output_price.Text.ToString())
                                        , double.Parse(txt_char_amt.Text.ToString())
                                        , double.Parse(txt_pack_amt.Text.ToString())
                                        , cmb_cust.SelectedValue.ToString()
                                        , print_yn
                                        , cmb_used.SelectedValue.ToString()
                                        , input_date.Text.ToString()
                                        , txt_box_bar_cd.Text.ToString()
                                        , txt_box_amt.Text.ToString()
                                        , txt_unit_bar_cd.Text.ToString()
                                        , txt_unit_amt.Text.ToString()
                                        , txt_comment.Text.ToString()
                                        , (txt_link_input.Text != null ? txt_link_input.Text.ToString() : "")
                                        , (string)cmb_vat_cd.SelectedValue ?? ""  //0115
                                        , itemRawGrid
                                        , itemFlowGrid
                                        , itemHalfGrid
                                        , 도면등록.dgv_picture
                                        , cmb_mold.SelectedValue.ToString()
                                        );


                        if (rsNum == 0)
                        {
                            resetSetting();
                            item_list();
                            MessageBox.Show("성공적으로 등록하였습니다.");
                        }
                        else if (rsNum == 1)
                            MessageBox.Show("저장에 실패하였습니다");
                        else if (rsNum == 2)
                            MessageBox.Show("SQL COMMAND 에러");
                        else if (rsNum == 3)
                            MessageBox.Show("기존 코드가 있으니 \n 다른 코드로 입력 바랍니다.");
                        else if (rsNum == 4)
                            MessageBox.Show("장터지기 등록에러.");
                        else
                            MessageBox.Show("Exception 에러");
                    }
                    else
                    {
                        wnDm wDm = new wnDm();
                        int rsNum = wDm.updateItem(
                                        txt_item_cd.Text.ToString()
                                        , txt_item_nm.Text.ToString()
                                        , cmb_item_gbn.SelectedValue.ToString()
                                        , txt_spec.Text.ToString()
                                        , cmb_type.SelectedValue.ToString()
                                        , cmb_line.SelectedValue.ToString()
                                        , cmb_unit.SelectedValue.ToString()
                                        , ""
                                        , double.Parse(txt_prop_stock.Text.ToString())
                                        , double.Parse(txt_item_weight.Text.ToString())
                                        , double.Parse(txt_input_price.Text.ToString())
                                        , double.Parse(txt_output_price.Text.ToString())
                                        , double.Parse(txt_char_amt.Text.ToString())
                                        , double.Parse(txt_pack_amt.Text.ToString())
                                        , cmb_cust.SelectedValue.ToString()
                                        , print_yn
                                        , cmb_used.SelectedValue.ToString()
                                        , input_date.Text.ToString()
                                        , txt_box_bar_cd.Text.ToString()
                                        , txt_box_amt.Text.ToString()
                                        , txt_unit_bar_cd.Text.ToString()
                                        , txt_unit_amt.Text.ToString()
                                        , txt_comment.Text.ToString()
                                        , (txt_link_input.Text != null ? txt_link_input.Text.ToString() : "")
                                       , (string)cmb_vat_cd.SelectedValue ?? ""//0115
                                        , itemRawGrid
                                        , itemFlowGrid
                                        , itemHalfGrid
                                        , del_compGrid
                                        , del_flowGrid
                                        , del_halfGrid
                                        , 도면등록.dgv_picture
                                        , 도면등록.del_dgv_picture
                                        , cmb_mold.SelectedValue.ToString());
                        if (rsNum == 0)
                        {
                            del_compGrid.Rows.Clear(); //기존 삭제 데이터할 제품구성 리스트 초기화
                            del_flowGrid.Rows.Clear();
                            del_halfGrid.Rows.Clear();
                            item_list();
                            gridDetail("where A.item_cd = '" + txt_item_cd.Text.ToString() + "'");
                            MessageBox.Show("성공적으로 수정하였습니다.");
                        }
                        else if (rsNum == 1)
                            MessageBox.Show("저장에 실패하였습니다");
                        else
                            MessageBox.Show("Exception 에러");
                    }

                }

            }
            catch (Exception e)
            {
                MessageBox.Show("시스템 에러: " + e.Message.ToString());
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(e.Message + " - " + e.ToString());
                msg.ShowDialog();
            }

        }

        private void item_list()
        {
            try
            {

                wnDm wDm = new wnDm();
                DataTable dt = null;

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("where 1=1 ");

                if (cmb_srch_gbn.SelectedIndex > 0)
                {
                    sb.AppendLine("and A.ITEM_GUBUN = '" + cmb_srch_gbn.SelectedValue.ToString() + "' ");
                }

                if (!txt_srch.Text.ToString().Equals(""))
                {
                    sb.AppendLine("and A.ITEM_NM like '%" + txt_srch.Text.ToString() + "%' ");
                }

                if (cmb_used_srch.SelectedIndex == 1)
                {
                    sb.AppendLine(" and A.USED_CD = 1 ");
                }
                else if (cmb_used_srch.SelectedIndex == 2)
                {
                    sb.AppendLine(" and A.USED_CD = 2 ");
                }
                else if (cmb_used_srch.SelectedIndex == 3)
                {
                    sb.AppendLine(" and A.USED_CD = 3 ");
                }


                dt = wDm.fn_Item_List(sb.ToString());

                if (dt != null && dt.Rows.Count > 0)
                {
                    this.dataItemGrid.RowCount = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        if (dt.Rows[i]["USED_CD"].ToString().Equals("2"))
                        {
                            dataItemGrid.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                        }
                        else if (dt.Rows[i]["USED_CD"].ToString().Equals("3"))
                        {
                            dataItemGrid.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                        }
                        else if (dt.Rows[i]["USED_CD"].ToString().Equals("1"))
                        {
                            dataItemGrid.Rows[i].DefaultCellStyle.BackColor = Color.Empty;
                        }
                        dataItemGrid.Rows[i].Cells["g제품코드"].Value = dt.Rows[i]["ITEM_CD"].ToString();
                        dataItemGrid.Rows[i].Cells["g제품명"].Value = dt.Rows[i]["ITEM_NM"].ToString();
                        dataItemGrid.Rows[i].Cells["g규격"].Value = dt.Rows[i]["SPEC"].ToString();
                        dataItemGrid.Rows[i].Cells["g구분"].Value = dt.Rows[i]["ITEM_GUBUN_NM"].ToString();
                    }
                }
                else
                {
                    dataItemGrid.Rows.Clear();
                }

                if (Common.sp_code == "300")
                {
                    g구분.Visible = false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("시스템 에러: " + e.Message.ToString());
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(e.Message + " - " + e.ToString());
                msg.ShowDialog();
            }
        }

        private void dataItemGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
               
                btnDelete.Enabled = true;
                lbl_item_gbn.Text = "1";
                txt_item_cd.Enabled = false;

                del_compGrid.Rows.Clear(); //더블클릭 시 기존 삭제 데이터할 제품구성 리스트 초기화
                del_flowGrid.Rows.Clear();
                도면등록.dgv_picture.Rows.Clear();
                도면등록.lbl_item_gbn = "1";
                try
                {
                    wnDm wDm = new wnDm();
                    DataTable dt = null;

                    string condition = "where A.item_cd = '" + dataItemGrid.Rows[e.RowIndex].Cells[0].Value.ToString() + "'";
                    Console.WriteLine(dataItemGrid.Rows[e.RowIndex].Cells[0].Value.ToString());
                    if (Common.p_saupNo != "6091692803")
                    {
                        try
                        {
                            dt = wDm.fn_Item_List(condition);
                        }
                        catch (Exception e3)
                        {
                            Console.WriteLine(e3);
                        }

                        if (dt != null && dt.Rows.Count > 0)
                        {

                            txt_item_cd.Text = dt.Rows[0]["ITEM_CD"].ToString();
                            txt_item_nm.Text = dt.Rows[0]["ITEM_NM"].ToString();
                            cmb_item_gbn.SelectedValue = dt.Rows[0]["ITEM_GUBUN"].ToString();
                            txt_spec.Text = dt.Rows[0]["SPEC"].ToString();

                            try
                            {
                                cmb_type.SelectedValue = dt.Rows[0]["TYPE_CD"].ToString();
                            }
                            catch
                            {
                            }
                            try
                            {
                                cmb_line.SelectedValue = dt.Rows[0]["LINE_CD"].ToString();
                            }
                            catch
                            {
                            }
                            try
                            {
                                cmb_unit.SelectedValue = dt.Rows[0]["UNIT_CD"].ToString();
                            }
                            catch
                            {
                            }
                            
                          
                          
                            txt_prop_stock.Text = dt.Rows[0]["PROP_STOCK"].ToString();
                            txt_item_weight.Text = decimal.Parse(dt.Rows[0]["ITEM_WEIGHT"].ToString()).ToString("#,0.######");
                            txt_input_price.Text = decimal.Parse(dt.Rows[0]["INPUT_PRICE"].ToString()).ToString("#,0.######");
                            txt_output_price.Text = decimal.Parse(dt.Rows[0]["OUTPUT_PRICE"].ToString()).ToString("#,0.######");
                            txt_char_amt.Text = dt.Rows[0]["CHARGE_AMT"].ToString();
                            txt_pack_amt.Text = dt.Rows[0]["PACK_AMT"].ToString();

                            txt_box_bar_cd.Text = dt.Rows[0]["BOX_BAR_CD"].ToString();
                            txt_box_amt.Text = dt.Rows[0]["BOX_AMT"].ToString();
                            txt_unit_bar_cd.Text = dt.Rows[0]["UNIT_BAR_CD"].ToString();
                            txt_unit_amt.Text = dt.Rows[0]["UNIT_AMT"].ToString();


                            try
                            {
                                cmb_vat_cd.SelectedValue = dt.Rows[0]["VAT_CD"].ToString();
                            }
                            catch
                            {
                            }

                                try
                            {
                                cmb_cust.SelectedValue = dt.Rows[0]["CUST_CD"].ToString();
                            }
                            catch
                            {
                            }


                            if (dt.Rows[0]["CUST_CD"].ToString() != "")
                            {
                               

                            }

                           
                            if (dt.Rows[0]["PRINT_YN"].ToString().Equals("Y"))
                            {
                                chk_print_yn.Checked = true;
                            }
                            else
                            {
                                chk_print_yn.Checked = false;
                            }

                            string input_dateTemp = dt.Rows[0]["INPUT_DATE"].ToString();
                            input_dateTemp = input_dateTemp.Replace("(", "");
                            input_dateTemp = input_dateTemp.Replace(")", "");
                            input_dateTemp = input_dateTemp.Replace("월", "");
                            input_dateTemp = input_dateTemp.Replace("화", "");
                            input_dateTemp = input_dateTemp.Replace("수", "");
                            input_dateTemp = input_dateTemp.Replace("목", "");
                            input_dateTemp = input_dateTemp.Replace("금", "");
                            input_dateTemp = input_dateTemp.Replace("토", "");
                            input_dateTemp = input_dateTemp.Replace("일", "");
                            input_date.Text = input_dateTemp;
                            cmb_used.SelectedValue = int.Parse(dt.Rows[0]["USED_CD"].ToString());
                            txt_comment.Text = dt.Rows[0]["COMMENT"].ToString();
                            txt_link_input.Text = (dt.Rows[0]["LINK_CD"] != null ? dt.Rows[0]["LINK_CD"].ToString() : "");
                            txt_link_inpaut_nm.Text = (dt.Rows[0]["ITEM_NM"] != null ? dt.Rows[0]["ITEM_NM"].ToString() : "");
                        }
                    }
                    else
                    {
                        try
                        {
                            dt = wDm.fn_Item_List2(condition);
                        }
                        catch (Exception e3)
                        {
                            Console.WriteLine(e3);
                        }

                        if (dt != null && dt.Rows.Count > 0)
                        {

                            txt_item_cd.Text = dt.Rows[0]["ITEM_CD"].ToString();
                            txt_item_nm.Text = dt.Rows[0]["ITEM_NM"].ToString();
                            cmb_item_gbn.SelectedValue = dt.Rows[0]["ITEM_GUBUN"].ToString();
                            txt_spec.Text = dt.Rows[0]["SPEC"].ToString();
                            try
                            {
                                cmb_type.SelectedValue = dt.Rows[0]["TYPE_CD"].ToString();
                            }
                            catch
                            {
                            }
                            try
                            {
                                cmb_line.SelectedValue = dt.Rows[0]["LINE_CD"].ToString();
                            }
                            catch
                            {
                            }
                            try
                            {
                                cmb_unit.SelectedValue = dt.Rows[0]["UNIT_CD"].ToString();
                            }
                            catch
                            {
                            }
                            txt_prop_stock.Text = dt.Rows[0]["PROP_STOCK"].ToString();
                            txt_item_weight.Text = decimal.Parse(dt.Rows[0]["ITEM_WEIGHT"].ToString()).ToString("#,0.######");
                            txt_input_price.Text = decimal.Parse(dt.Rows[0]["INPUT_PRICE"].ToString()).ToString("#,0.######");
                            txt_output_price.Text = decimal.Parse(dt.Rows[0]["OUTPUT_PRICE"].ToString()).ToString("#,0.######");
                            txt_char_amt.Text = dt.Rows[0]["CHARGE_AMT"].ToString();
                            txt_pack_amt.Text = dt.Rows[0]["PACK_AMT"].ToString();

                            txt_box_bar_cd.Text = dt.Rows[0]["BOX_BAR_CD"].ToString();
                            txt_box_amt.Text = dt.Rows[0]["BOX_AMT"].ToString();
                            txt_unit_bar_cd.Text = dt.Rows[0]["UNIT_BAR_CD"].ToString();
                            txt_unit_amt.Text = dt.Rows[0]["UNIT_AMT"].ToString();
                            try
                            {
                                cmb_vat_cd.SelectedValue = dt.Rows[0]["VAT_CD"].ToString();

                            }
                            catch
                            {
                            }
                            try
                            {
                                cmb_mold.SelectedValue = dt.Rows[0]["MOLD_CD"].ToString();
                            }
                            catch
                            {
                            }
                            try
                            {

                                cmb_cust.SelectedValue = dt.Rows[0]["CUST_CD"].ToString();
                            }
                            catch
                            {
                            }
                                if (dt.Rows[0]["PRINT_YN"].ToString().Equals("Y"))
                            {
                                chk_print_yn.Checked = true;
                            }
                            else
                            {
                                chk_print_yn.Checked = false;
                            }
                                try
                                {

                                    cmb_used.SelectedValue = int.Parse(dt.Rows[0]["USED_CD"].ToString());
                                }
                                catch
                                {
                                }
                            string input_dateTemp = dt.Rows[0]["INPUT_DATE"].ToString();
                            input_dateTemp = input_dateTemp.Replace("(", "");
                            input_dateTemp = input_dateTemp.Replace(")", "");
                            input_dateTemp = input_dateTemp.Replace("월", "");
                            input_dateTemp = input_dateTemp.Replace("화", "");
                            input_dateTemp = input_dateTemp.Replace("수", "");
                            input_dateTemp = input_dateTemp.Replace("목", "");
                            input_dateTemp = input_dateTemp.Replace("금", "");
                            input_dateTemp = input_dateTemp.Replace("토", "");
                            input_dateTemp = input_dateTemp.Replace("일", "");
                            input_date.Text = input_dateTemp;
                            txt_comment.Text = dt.Rows[0]["COMMENT"].ToString();
                            txt_link_input.Text = (dt.Rows[0]["LINK_CD"] != null ? dt.Rows[0]["LINK_CD"].ToString() : "");
                            txt_link_inpaut_nm.Text = (dt.Rows[0]["ITEM_NM"] != null ? dt.Rows[0]["ITEM_NM"].ToString() : "");
                        }
                    }
                    gridDetail(condition);
                    selectLogic();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("시스템 에러: " + ex.Message.ToString());
                }
            }
        }
        private void selectLogic()
        {
            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = null;
                dt = wDm.SelectFloorPlan(txt_item_cd.Text);

                if (dt != null && dt.Rows.Count > 0)
                {
                    도면등록.dgv_picture.RowCount = dt.Rows.Count;

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        도면등록.dgv_picture.Rows[i].Cells["IMG_NAME"].Value = dt.Rows[i]["IMG_NAME"].ToString();
                        도면등록.dgv_picture.Rows[i].Cells["SEQ"].Value = dt.Rows[i]["INPUT_CD"].ToString();
                        도면등록.dgv_picture.Rows[i].Cells["INPUT_DATE"].Value = dt.Rows[i]["INPUT_DATE"].ToString();
                        도면등록.dgv_picture.Rows[i].Cells[2].Value = "사진추가";


                        byte[] ip = (byte[])dt.Rows[i]["IMG"];
                        Image a = ByteImg(ip);
                        Image cus_img = pic_resize_logic(도면등록.dgv_picture, a);
                        도면등록.dgv_picture.Rows[i].Height = 194;
                        도면등록.dgv_picture.Columns[1].Width = 300;


                        //dgv_picture.Rows[i].Cells["IMG_SIZE"].Value = "0";
                        도면등록.dgv_picture.Rows[i].Cells["PICTURE"].Value = cus_img;
                        도면등록.dgv_picture.Rows[i].Cells["IMG_SIZE"].Value = dt.Rows[i]["IMG_PATH"].ToString();
                        도면등록.dgv_picture.Rows[i].Cells["PIC_PATH"].Value = ip;

                        //dgv_picture.Rows[e.RowIndex].Cells["PIC_PATH"].Value = img;
                    }

                }

                else
                {
                    //MessageBox.Show("데이터가 없습니다");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public Image ByteImg(byte[] b)
        {
            ImageConverter imgcvt = new ImageConverter();
            Image img = (Image)imgcvt.ConvertFrom(b);
            return img;
        }
        private Image pic_resize_logic(DataGridView dgv_fac_picture, Image image)
        {
            cus_img = new Bitmap(300, 194, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            using (Graphics g = Graphics.FromImage(cus_img))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.DrawImage(image,
                    new RectangleF(0, 0, 300, 194),
                    new RectangleF(new PointF(0, 0), image.Size), GraphicsUnit.Pixel);
            }
            return cus_img;
        }
        private void gridDetail(string condition)
        {
            wnDm wDm = new wnDm();
            DataTable dt = null;

            dt = wDm.fn_Item_Comp_List(condition);

            this.itemRawGrid.RowCount = dt.Rows.Count;
            //itemRawGrid.Rows.Clear();
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //itemRawGrid.Rows.Add();
                    itemRawGrid.Rows[i].Cells["ITEM_CD"].Value = dt.Rows[i]["ITEM_CD"].ToString();
                    itemRawGrid.Rows[i].Cells["SEQ"].Value = dt.Rows[i]["SEQ"].ToString();
                    itemRawGrid.Rows[i].Cells["RAW_MAT_CD"].Value = dt.Rows[i]["RAW_MAT_CD"].ToString();
                    itemRawGrid.Rows[i].Cells["RAW_MAT_NM"].Value = dt.Rows[i]["RAW_MAT_NM"].ToString();
                    itemRawGrid.Rows[i].Cells["SPEC"].Value = dt.Rows[i]["SPEC"].ToString();
                    itemRawGrid.Rows[i].Cells["OLD_RAW_MAT_NM"].Value = dt.Rows[i]["RAW_MAT_NM"].ToString();

                    itemRawGrid.Rows[i].Cells["IN_UNIT"].Value = dt.Rows[i]["INPUT_UNIT"].ToString();
                    itemRawGrid.Rows[i].Cells["OUT_UNIT"].Value = dt.Rows[i]["OUTPUT_UNIT"].ToString();
                    itemRawGrid.Rows[i].Cells["IN_UNIT_NM"].Value = dt.Rows[i]["INPUT_UNIT_NM"].ToString();
                    itemRawGrid.Rows[i].Cells["OUT_UNIT_NM"].Value = dt.Rows[i]["OUTPUT_UNIT_NM"].ToString();
                    //환산단위적용코드
                    //itemRawGrid.Rows[i].Cells["OUT_UNIT_NM"].Value = int.Parse(dt.Rows[i]["OUTPUT_UNIT_NM"].ToString()) / int.Parse(dt.Rows[i]["CVR_RATIO"].ToString());
                    itemRawGrid.Rows[i].Cells["TOTAL_AMT"].Value = (decimal.Parse(dt.Rows[i]["TOTAL_AMT"].ToString())).ToString("#,0.######");


                }
            }
            else
            {
                itemCompGridAdd(); //데이터가 없을 경우 빈 행 생성
            }

            dt = wDm.fn_Item_Flow_List(condition);

            this.itemFlowGrid.RowCount = dt.Rows.Count;
            //itemFlowGrid.Rows.Clear();
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //itemFlowGrid.Rows.Add();
                    itemFlowGrid.Rows[i].Cells["F_ITEM_CD"].Value = dt.Rows[i]["ITEM_CD"].ToString();
                    itemFlowGrid.Rows[i].Cells["F_SEQ"].Value = dt.Rows[i]["SEQ"].ToString();
                    itemFlowGrid.Rows[i].Cells["FLOW_CD"].Value = dt.Rows[i]["FLOW_CD"].ToString();
                    itemFlowGrid.Rows[i].Cells["FLOW_NM"].Value = dt.Rows[i]["FLOW_NM"].ToString();
                    itemFlowGrid.Rows[i].Cells["FLOW_ETC"].Value = dt.Rows[i]["COMMENT"].ToString();
                    itemFlowGrid.Rows[i].Cells["FLOW_SEQ"].Value = dt.Rows[i]["FLOW_SEQ"].ToString();
                   // itemFlowGrid.Rows[i].Cells["식별표"].Value = dt.Rows[i]["식별표"].ToString();
                    if (dt.Rows[i]["FLOW_INSERT_YN"].ToString().Equals("Y"))
                    {
                        itemFlowGrid.Rows[i].Cells["FLOW_YN"].Value = true;
                    }
                    else
                    {
                        itemFlowGrid.Rows[i].Cells["FLOW_YN"].Value = false;
                    }
                    if (dt.Rows[i]["ITEM_IDEN_YN"].ToString().Equals("Y"))
                    {
                        itemFlowGrid.Rows[i].Cells["식별표"].Value = true;
                    }
                    else
                    {
                        itemFlowGrid.Rows[i].Cells["식별표"].Value = false;
                    }
                }
            }
            else
            {
                itemFlowGridAdd();
            }

            dt = wDm.fn_Item_Half_List(condition, 1);

            this.itemHalfGrid.RowCount = dt.Rows.Count;
            //itemFlowGrid.Rows.Clear();
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //itemFlowGrid.Rows.Add();
                    itemHalfGrid.Rows[i].Cells["MAIN_ITEM_CD"].Value = dt.Rows[i]["ITEM_CD"].ToString();
                    itemHalfGrid.Rows[i].Cells["H_SEQ"].Value = dt.Rows[i]["SEQ"].ToString();
                    itemHalfGrid.Rows[i].Cells["HALF_ITEM_CD"].Value = dt.Rows[i]["HALF_ITEM_CD"].ToString();
                    itemHalfGrid.Rows[i].Cells["HALF_ITEM_NM"].Value = dt.Rows[i]["HALF_ITEM_NM"].ToString();
                    itemHalfGrid.Rows[i].Cells["H_UNIT_CD"].Value = dt.Rows[i]["UNIT_CD"].ToString();
                    itemHalfGrid.Rows[i].Cells["H_UNIT_NM"].Value = dt.Rows[i]["UNIT_NM"].ToString();
                    itemHalfGrid.Rows[i].Cells["OLD_HALF_ITEM_NM"].Value = dt.Rows[i]["HALF_ITEM_NM"].ToString();
                    itemHalfGrid.Rows[i].Cells["H_TOTAL_AMT"].Value = (decimal.Parse(dt.Rows[i]["TOTAL_AMT"].ToString())).ToString("#,0.######");
                }
            }
            else
            {
                itemHalfGridAdd();
            }
        }
        private void item_del()
        {
            wnDm wDm = new wnDm();

            DataTable dt = wDm.select_all_itemCd(txt_item_cd.Text.ToString());
            if (dt != null && dt.Rows.Count > 0)
            {
                MessageBox.Show("해당 제품의 사용내역이 남아있어서 삭제할 수 없습니다.");
                return;
            }

            ComInfo comInfo = new ComInfo();
            DialogResult msgOk = comInfo.deleteConfrim("제품등록", txt_item_nm.Text.ToString());

            if (msgOk == DialogResult.No)
            {
                return;
            }
            StringBuilder sb = new StringBuilder();
            if (cmb_item_gbn.SelectedValue.ToString() == "1")
            {
                sb.AppendLine("");
            }
            else
            {
                sb.AppendLine("delete from N_ITEM_COMP_HALF "); //반제품일경후 삭제
                sb.AppendLine("    where HALF_ITEM_CD = @ITEM_CD ");
            }

            int rsNum = wDm.deleteItem(txt_item_cd.Text.ToString(), txt_link_input.Text.ToString(), sb.ToString());
            if (rsNum == 0)
            {
                resetSetting();

                item_list();
                MessageBox.Show("성공적으로 삭제하였습니다.");
            }
            else if (rsNum == 1)
            {
                MessageBox.Show("삭제에 실패하였습니다.");
            }

        }

        #endregion item logic

        private void txt_bs_stock_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComInfo.onlyNum2(sender, e);
        }

        private void txt_item_weight_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComInfo.onlyNum2(sender, e);
        }

        private void txt_input_price_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComInfo.onlyNum2(sender, e);
        }

        private void txt_output_price_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComInfo.onlyNum2(sender, e);
        }

        private void txt_char_amt_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComInfo.onlyNum2(sender, e);
        }

        private void txt_pack_amt_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComInfo.onlyNum2(sender, e);
        }

        private void txt_box_bar_cd_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComInfo.onlyNum2(sender, e);
        }

        private void txt_unit_bar_cd_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComInfo.onlyNum2(sender, e);
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            item_list();
        }

        #region input grid logic

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

            //wConst.init_RowText(grd, e.RowIndex);

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
            //     폼 로딩시에는, 저장 안함.
            //    if (bSetFirst == true) return;

            //    conDataGridView grd = (conDataGridView)sender;

            //    sColumnsWW = "";
            //    for (int kk = 0; kk < grd.Columns.Count; kk++)
            //    {
            //        if (kk > 0)
            //        {
            //            sColumnsWW += ",";
            //        }
            //        sColumnsWW += grd.Columns[kk].Width.ToString();
            //    }
            //    Save_Layout();
        }

        private void grid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
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
                dt = wDm.fn_Raw_List("where RAW_MAT_NM like '%" + rat_mat_nm + "%' ","1");

                if (dt.Rows.Count > 1)
                { //row가 2줄이 넘을 경우 팝업으로 넘어간다.

                    wConst.call_pop_raw_mat(grd, dt, e.RowIndex, rat_mat_nm, 1, "");
                    //itemCompGridAdd();
                }
                else if (dt.Rows.Count == 1) //row가 1일 경우 해당 row에 값을 자동 입력한다.
                {
                    grd.Rows[e.RowIndex].Cells["RAW_MAT_CD"].Value = dt.Rows[0]["RAW_MAT_CD"].ToString();
                    grd.Rows[e.RowIndex].Cells["RAW_MAT_NM"].Value = dt.Rows[0]["RAW_MAT_NM"].ToString();
                    grd.Rows[e.RowIndex].Cells["OLD_RAW_MAT_NM"].Value = dt.Rows[0]["RAW_MAT_NM"].ToString(); //백업 키워드 
                    grd.Rows[e.RowIndex].Cells["SPEC"].Value = dt.Rows[0]["SPEC"].ToString();
                    grd.Rows[e.RowIndex].Cells["IN_UNIT"].Value = dt.Rows[0]["INPUT_UNIT"].ToString();
                    grd.Rows[e.RowIndex].Cells["OUT_UNIT"].Value = dt.Rows[0]["OUTPUT_UNIT"].ToString();
                    grd.Rows[e.RowIndex].Cells["IN_UNIT_NM"].Value = dt.Rows[0]["INPUT_UNIT_NM"].ToString();
                    grd.Rows[e.RowIndex].Cells["OUT_UNIT_NM"].Value = dt.Rows[0]["OUTPUT_UNIT_NM"].ToString();
                    grd.Rows[e.RowIndex].Cells["TOTAL_AMT"].Value = "0";

                    itemCompGridAdd();
                }
                else
                { //row가 없는 경우
                    MessageBox.Show("데이터가 없습니다.");
                    itemRawGrid.Rows.RemoveAt(itemRawGrid.SelectedRows[0].Index);
                    itemRawGrid.CurrentCell = itemRawGrid[2, itemRawGrid.Rows.Count];
                }
            }
            #endregion 공통 그리드 체크

            //string sSearchTxt = "" + (string)grd.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

        }

        private void grid_CellEndEdit2(object sender, DataGridViewCellEventArgs e)
        {
            conDataGridView grd = (conDataGridView)sender;
            DataGridViewCell cell = grd[e.ColumnIndex, e.RowIndex];

            cell.Style.BackColor = Color.White;

            #region 공통 그리드 체크
            if (grd.Columns[e.ColumnIndex].ToolTipText.IndexOf("명칭") >= 0 && grd._KeyInput == "enter")
            {
                string flow_nm = (string)grd.Rows[e.RowIndex].Cells["FLOW_NM"].Value;
                wnDm wDm = new wnDm();
                DataTable dt = new DataTable();
                dt = wDm.fn_Flow_List("where FLOW_NM like '%" + flow_nm + "%' ");

                if (dt.Rows.Count > 1)
                { //row가 2줄이 넘을 경우 팝업으로 넘어간다.

                    wConst.call_pop_flow(grd, dt, e.RowIndex, flow_nm);
                    //itemFlowGridAdd();
                }
                else if (dt.Rows.Count == 1) //row가 1일 경우 해당 row에 값을 자동 입력한다.
                {
                    grd.Rows[e.RowIndex].Cells["FLOW_CD"].Value = dt.Rows[0]["FLOW_CD"].ToString();
                    grd.Rows[e.RowIndex].Cells["FLOW_NM"].Value = dt.Rows[0]["FLOW_NM"].ToString();
                    grd.Rows[e.RowIndex].Cells["OLD_FLOW_NM"].Value = dt.Rows[0]["FLOW_NM"].ToString(); //백업 키워드 
                    if (dt.Rows[0]["FLOW_INSERT_YN"].ToString().Equals("Y"))
                    {
                        grd.Rows[e.RowIndex].Cells["FLOW_YN"].Value = true;
                    }
                    else
                    {
                        grd.Rows[e.RowIndex].Cells["FLOW_YN"].Value = false;
                    }

                    itemFlowGridAdd();
                }
                else
                { //row가 없는 경우
                    MessageBox.Show("데이터가 없습니다.");
                    itemFlowGrid.Rows.RemoveAt(itemFlowGrid.SelectedRows[0].Index);
                    itemFlowGrid.CurrentCell = itemFlowGrid[2, itemFlowGrid.Rows.Count];
                }
            }
            #endregion 공통 그리드 체크

            //string sSearchTxt = "" + (string)grd.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
        }

        private void grid_CellEndEdit3(object sender, DataGridViewCellEventArgs e)
        {
            conDataGridView grd = (conDataGridView)sender;
            DataGridViewCell cell = grd[e.ColumnIndex, e.RowIndex];

            cell.Style.BackColor = Color.White;

            #region 공통 그리드 체크
            if (grd.Columns[e.ColumnIndex].ToolTipText.IndexOf("명칭") >= 0 && grd._KeyInput == "enter")
            {
                string half_item_nm = (string)grd.Rows[e.RowIndex].Cells["HALF_ITEM_NM"].Value;
                wnDm wDm = new wnDm();
                DataTable dt = new DataTable();

                StringBuilder sb = new StringBuilder();
                if (txt_item_cd.Text != null && !txt_item_cd.Text.ToString().Equals(""))
                {
                    sb.AppendLine("and A.ITEM_CD != '" + txt_item_cd.Text.ToString() + "' ");
                }
                sb.AppendLine("and A.ITEM_NM like '%" + half_item_nm + "%' ");
                dt = wDm.fn_Half_List(sb.ToString());

                if (dt.Rows.Count > 1)
                { //row가 2줄이 넘을 경우 팝업으로 넘어간다.

                    wConst.call_pop_item_half(grd, dt, e.RowIndex, half_item_nm);
                    //itemHalfGridAdd();
                }
                else if (dt.Rows.Count == 1) //row가 1일 경우 해당 row에 값을 자동 입력한다.
                {
                    grd.Rows[e.RowIndex].Cells["HALF_ITEM_CD"].Value = dt.Rows[0]["ITEM_CD"].ToString();
                    grd.Rows[e.RowIndex].Cells["HALF_ITEM_NM"].Value = dt.Rows[0]["ITEM_NM"].ToString();
                    grd.Rows[e.RowIndex].Cells["OLD_HALF_ITEM_NM"].Value = dt.Rows[0]["ITEM_NM"].ToString(); //백업 키워드 
                    grd.Rows[e.RowIndex].Cells["H_UNIT_CD"].Value = dt.Rows[0]["UNIT_CD"].ToString();
                    grd.Rows[e.RowIndex].Cells["H_UNIT_NM"].Value = dt.Rows[0]["UNIT_NM"].ToString();
                    grd.Rows[e.RowIndex].Cells["H_TOTAL_AMT"].Value = "0";

                    itemHalfGridAdd();

                }
                else
                { //row가 없는 경우
                    MessageBox.Show("데이터가 없습니다.");
                    itemHalfGrid.Rows.RemoveAt(itemHalfGrid.SelectedRows[0].Index);
                    itemHalfGrid.CurrentCell = itemHalfGrid[2, itemHalfGrid.Rows.Count];
                }
            }
            #endregion 공통 그리드 체크

            //string sSearchTxt = "" + (string)grd.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
        }
        #endregion input grid logic

        private void btn_raw_plus_Click(object sender, EventArgs e)
        {
            plus_logic(itemRawGrid);
        }

        private void btn_raw_minus_Click(object sender, EventArgs e)
        {
            minus_logic(itemRawGrid, 1); //1 제품구성
        }

        private void btn_flow_plus_Click(object sender, EventArgs e)
        {
            plus_logic(itemFlowGrid);
        }

        private void btn_flow_minus_Click(object sender, EventArgs e)
        {
            minus_logic(itemFlowGrid, 2); //2 공정구성
        }

        private void btn_half_plus_Click(object sender, EventArgs e)
        {
            plus_logic(itemHalfGrid);
        }

        private void btn_half_minus_Click(object sender, EventArgs e)
        {
            minus_logic(itemHalfGrid, 3); //2 반제품구성
        }

        private void plus_logic(DataGridView dgv)
        {
            //0115
            //대양을 제외한 
            if (Common.sp_code != "300")
            {
                if (dgv.Rows.Count < 50)
                {
                    dgv.Rows.Add();
                    dgv.CurrentCell = dgv[2, dgv.Rows.Count - 1];
                }
                else
                {
                    MessageBox.Show("최대 50행까지 가능합니다.");
                }
            }
            //대양에서원하는 
            if (Common.sp_code == "300")
            {
                dgv.Rows.Add();
            }

        }

        private void minus_logic(DataGridView dgv, int num)
        {
            if (dgv.Rows.Count > 0)
            {
                if (num == 1)
                {
                    if ((string)dgv.SelectedRows[0].Cells["SEQ"].Value != "" && dgv.SelectedRows[0].Cells["SEQ"].Value != null)
                    {
                        del_compGrid.Rows.Add();

                        del_compGrid.Rows[del_compGrid.Rows.Count - 1].Cells["ITEM_CD"].Value = dgv.SelectedRows[0].Cells["ITEM_CD"].Value;
                        del_compGrid.Rows[del_compGrid.Rows.Count - 1].Cells["SEQ"].Value = dgv.SelectedRows[0].Cells["SEQ"].Value;
                    }
                }
                else if (num == 2)
                {
                    if ((string)dgv.SelectedRows[0].Cells["F_SEQ"].Value != "" && dgv.SelectedRows[0].Cells["F_SEQ"].Value != null)
                    {
                        del_flowGrid.Rows.Add();

                        del_flowGrid.Rows[del_flowGrid.Rows.Count - 1].Cells["F_ITEM_CD"].Value = dgv.SelectedRows[0].Cells["F_ITEM_CD"].Value;
                        del_flowGrid.Rows[del_flowGrid.Rows.Count - 1].Cells["F_SEQ"].Value = dgv.SelectedRows[0].Cells["F_SEQ"].Value;
                    }
                }
                else
                {
                    if ((string)dgv.SelectedRows[0].Cells["H_SEQ"].Value != "" && dgv.SelectedRows[0].Cells["H_SEQ"].Value != null)
                    {
                        del_halfGrid.Rows.Add();

                        del_halfGrid.Rows[del_halfGrid.Rows.Count - 1].Cells["MAIN_ITEM_CD"].Value = dgv.SelectedRows[0].Cells["MAIN_ITEM_CD"].Value;
                        del_halfGrid.Rows[del_halfGrid.Rows.Count - 1].Cells["H_SEQ"].Value = dgv.SelectedRows[0].Cells["H_SEQ"].Value;
                    }
                }

                dgv.Rows.RemoveAt(dgv.SelectedRows[0].Index);
                //dgv.CurrentCell = dgv[2, dgv.Rows.Count - 1];
            }
        }

        private void itemCompGridAdd()
        {
            itemRawGrid.Rows.Add();
            itemRawGrid.Rows[itemRawGrid.Rows.Count - 1].Cells["TOTAL_AMT"].Value = "0";
        }

        private void itemFlowGridAdd()
        {
            itemFlowGrid.Rows.Add();
        }

        private void itemHalfGridAdd()
        {
            itemHalfGrid.Rows.Add();
            itemHalfGrid.Rows[itemHalfGrid.Rows.Count - 1].Cells["H_TOTAL_AMT"].Value = "0";
        }

        private void btn_Cust_Click(object sender, EventArgs e)
        {
            Refresh();
            Popup.pop거래처검색 frm = new Popup.pop거래처검색();

            frm.sCustGbn = "1";
            frm.ShowDialog();

            if (frm.sCode != "")
            {
                cmb_cust.SelectedValue = frm.sCode.Trim();
            }
            else
            {
                // txt_cust_cd.Text = old_cust_nm;
            }

            frm.Dispose();
            frm = null;
            cmb_vat_cd.Focus();
        }

        private void btnBoxBar_Click(object sender, EventArgs e)
        {
            btnBoxBar.Enabled = false;
            strCondition = "";

            if (txt_item_cd.Text.Trim() == "")
            {
                MessageBox.Show("제품을 선택하세요.");
                btnBoxBar.Enabled = true;
                return;
            }

            if (txt_box_bar_cd.Text.ToString().Equals(""))
            {
                MessageBox.Show("박스바코드를 입력하시기 바랍니다.");
                btnBoxBar.Enabled = true;
                return;
            }

            //bindData_Print();
            //----------------------------------------
            bindData(txt_box_bar_cd, txt_box_amt);

            if (strCondition == "No")
            {
                MessageBox.Show("출력할 자료가 없습니다.");
                btnBoxBar.Enabled = true;
                return;
            }

            if (strCondition != "ERROR")
            {
                strCondition = "제품바코드";

                frmPrt = readyPrt;
                frmPrt.Show();
                frmPrt.BringToFront();
                frmPrt.prt_바코드(adoPrt, strCondition, "제품박스바코드");
            }

            btnBoxBar.Enabled = true;
        }

        private void btnUnitBar_Click(object sender, EventArgs e)
        {
            btnUnitBar.Enabled = false;
            strCondition = "";

            if (txt_item_cd.Text.Trim() == "")
            {
                MessageBox.Show("제품을 선택하세요.");
                btnUnitBar.Enabled = true;
                return;
            }

            if (txt_unit_bar_cd.Text.ToString().Equals(""))
            {
                MessageBox.Show("낱개바코드를 입력하시기 바랍니다.");
                btnUnitBar.Enabled = true;
                return;
            }

            bindData(txt_unit_bar_cd, txt_unit_amt);

            if (strCondition == "No")
            {
                MessageBox.Show("출력할 자료가 없습니다.");
                btnUnitBar.Enabled = true;
                return;
            }

            if (strCondition != "ERROR")
            {
                strCondition = "제품바코드";

                frmPrt = readyPrt;
                frmPrt.Show();
                frmPrt.BringToFront();
                frmPrt.prt_바코드(adoPrt, strCondition, "제품낱개바코드");
            }

            btnUnitBar.Enabled = true;
        }

        public void bindData(TextBox txt_bar_cd, TextBox txt_amt)
        {
            Application.DoEvents();

            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = null;
                dt = fn_제품바코드_List();

                adoPrt = new DataTable();
                adoPrt = dt.Copy();

                int j = 0;
                int k = 0;

                string sCode = "" + this.txt_item_cd.Text.Trim();    //제품코드
                string sName = "" + this.txt_item_nm.Text.Trim();    //제품명
                string sSpec = "" + this.txt_spec.Text.Trim();    //규격
                string sBarcode = "" + txt_bar_cd.Text.Trim();    //박스바코드
                //string sBarcode = "" + this.txt_item_cd.Text.Trim();    //박스바코드

                string nQty = "" + txt_amt.Text.Trim(); //수량
                string nQtyS = "" + txt_amt.Text.Trim(); //수량

                //--- 수량은 6자리(100,000) 까지 하고 제품코드+수량으로 한다
                int nLength = 6 - nQtyS.Length;
                for (k = 0; k < nLength; k++)
                {
                    nQtyS = "0" + nQtyS;
                }
                //sBarcode = txt_box_bar_cd.Text.ToString(); //sBarcode + nQtyS;
                //----- end

                int nCnt = 1; //출력수량...나중에 출력수량 입력받아 출력한다

                for (int i = 0; i < nCnt; i++)
                {

                    dt.Rows[j]["no"] = j;

                    dt.Rows[j]["제조처"] = Common.p_strCompNm;

                    dt.Rows[j]["제품코드"] = sCode;
                    dt.Rows[j]["제품명"] = sName;
                    dt.Rows[j]["규격"] = sSpec;
                    dt.Rows[j]["수량"] = nQty;

                    dt.Rows[j]["바코드제조번호"] = "*" + sBarcode + "*";

                    j = j + 1;

                    adoPrt = dt.Copy();

                }

                //데이타 끝나고 다시 copy를 써준 이유는 for중에 no에 값을 엏었기 때문에 출력물 데이타테이블(dt)를 다시 복사함
                adoPrt = dt.Copy();

                //for (int i = j + 1; i < this.InputTabGrid.Rows.Count; i++)
                //{
                //    adoPrt.Rows[i].Delete();
                //}
                //adoPrt.AcceptChanges(); //--삭제확정

                if (k == 0)
                {
                    strCondition = "No";
                }

            }
            catch (Exception ex)
            {
                strCondition = "ERROR";
                MessageBox.Show("검색중에 오류가 발생했습니다.");
                wnLog.writeLog(wnLog.LOG_ERROR, ex.Message + " - " + ex.ToString());
            }
        }

        public DataTable fn_제품바코드_List()
        {
            StringBuilder sb = new StringBuilder();

            //sb.AppendLine("SELECT A.INPUT_DATE, '' AS no, '' AS 입고일자, '' AS 입고번호, ''  AS 입고순번, '' AS 원자재코드, '' 원자재명, '' AS 규격    ");
            //sb.AppendLine(", '' AS HEAT_NO, '' AS HEAT_TIME, '' AS ORDER_DATE, '' AS ORDER_CD, '' AS ORDER_SEQ, '' AS RAW_MAT_GUBUN ");
            //sb.AppendLine(", '' AS S_CODE_NM, '' AS 단위코드, '' AS 단위명  ");
            //sb.AppendLine(", '' AS 수량, '' AS 단가, '' AS 금액, '' AS 제조번호, '' AS 바코드제조번호 ");

            //sb.AppendLine("  FROM F_RAW_DETAIL         AS A  ");
            //sb.AppendLine(" WHERE A.INPUT_DATE >= '" + start_date.Text.ToString() + "' AND  A.INPUT_DATE <= '" + end_date.Text.ToString() + "'");

            sb.AppendLine(" SELECT '' AS no ");
            sb.AppendLine(", '' AS 제품코드, '' 제품명, '' AS 규격    ");
            sb.AppendLine(", '' AS 바코드제조번호, '' AS 수량, '' AS 제조처 ");
            sb.AppendLine("  FROM N_ITEM_CODE A  ");
            sb.AppendLine(" WHERE 1=1  ");
            sb.AppendLine("   AND A.ITEM_CD = '" + txt_item_cd.Text.ToString() + "'  ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            return wAdo.SqlCommandSelect(sCommand);
        }

        private void btn_link_srch_Click(object sender, EventArgs e)
        {
            Popup.pop_sf_장터지기제품 frm = new Popup.pop_sf_장터지기제품();

            //frm.sCustGbn = "1";
            frm.ShowDialog();

            if (frm.sCode != "")
            {
                txt_link_input.Text = frm.sCode.Trim();
                txt_link_inpaut_nm.Text = frm.sName.Trim();
            }

            frm.Dispose();
            frm = null;
        }

        private void grid_CellDoubleClick3(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                switch (itemHalfGrid.Columns[e.ColumnIndex].Name)
                {
                    case "HALF_ITEM_NM":
                        if (itemHalfGrid.Rows[e.RowIndex].Cells["HALF_ITEM_NM"].Value == null)
                        {

                            conDataGridView grd = (conDataGridView)sender;
                            DataGridViewCell cell = grd[e.ColumnIndex, e.RowIndex];

                            cell.Style.BackColor = Color.White;


                            if (grd.Columns[e.ColumnIndex].ToolTipText.IndexOf("명칭") >= 0)
                            {
                                string half_item_nm = (string)grd.Rows[e.RowIndex].Cells["HALF_ITEM_NM"].Value;
                                wnDm wDm = new wnDm();
                                DataTable dt = new DataTable();

                                StringBuilder sb = new StringBuilder();
                                if (txt_item_cd.Text != null && !txt_item_cd.Text.ToString().Equals(""))
                                {
                                    sb.AppendLine("and A.ITEM_CD != '" + txt_item_cd.Text.ToString() + "' ");
                                }
                                sb.AppendLine("and A.ITEM_NM like '%" + half_item_nm + "%' ");
                                dt = wDm.fn_Half_List(sb.ToString());

                                if (dt.Rows.Count > 1)
                                { //row가 2줄이 넘을 경우 팝업으로 넘어간다.
                                    grd.Rows.Clear();
                                    wConst.call_pop_item_half(grd, dt, e.RowIndex, half_item_nm);


                                    //itemHalfGridAdd();
                                }
                                else if (dt.Rows.Count == 1) //row가 1일 경우 해당 row에 값을 자동 입력한다.
                                {
                                    grd.Rows[e.RowIndex].Cells["HALF_ITEM_CD"].Value = dt.Rows[0]["ITEM_CD"].ToString();
                                    grd.Rows[e.RowIndex].Cells["HALF_ITEM_NM"].Value = dt.Rows[0]["ITEM_NM"].ToString();
                                    grd.Rows[e.RowIndex].Cells["OLD_HALF_ITEM_NM"].Value = dt.Rows[0]["ITEM_NM"].ToString(); //백업 키워드 
                                    grd.Rows[e.RowIndex].Cells["H_UNIT_CD"].Value = dt.Rows[0]["UNIT_CD"].ToString();
                                    grd.Rows[e.RowIndex].Cells["H_UNIT_NM"].Value = dt.Rows[0]["UNIT_NM"].ToString();
                                    grd.Rows[e.RowIndex].Cells["H_TOTAL_AMT"].Value = "0";

                                    itemHalfGridAdd();

                                }
                                else
                                { //row가 없는 경우
                                    MessageBox.Show("데이터가 없습니다.");
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

        private void grid_CellDoubleClick2(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                switch (itemFlowGrid.Columns[e.ColumnIndex].Name)
                {
                    case "FLOW_NM":
                        if (itemFlowGrid.Rows[e.RowIndex].Cells["FLOW_NM"].Value == null)
                        {

                            conDataGridView grd = (conDataGridView)sender;
                            DataGridViewCell cell = grd[e.ColumnIndex, e.RowIndex];

                            cell.Style.BackColor = Color.White;

                            if (grd.Columns[e.ColumnIndex].ToolTipText.IndexOf("명칭") >= 0)
                            {
                                string flow_nm = (string)grd.Rows[e.RowIndex].Cells["FLOW_NM"].Value;
                                wnDm wDm = new wnDm();
                                DataTable dt = new DataTable();
                                dt = wDm.fn_Flow_List("where FLOW_NM like '%" + flow_nm + "%' ");

                                if (dt.Rows.Count > 1)
                                { //row가 2줄이 넘을 경우 팝업으로 넘어간다.

                                    wConst.call_pop_flow(grd, dt, e.RowIndex, flow_nm);
                                    //itemFlowGridAdd();
                                }
                                else if (dt.Rows.Count == 1) //row가 1일 경우 해당 row에 값을 자동 입력한다.
                                {
                                    grd.Rows[e.RowIndex].Cells["FLOW_CD"].Value = dt.Rows[0]["FLOW_CD"].ToString();
                                    grd.Rows[e.RowIndex].Cells["FLOW_NM"].Value = dt.Rows[0]["FLOW_NM"].ToString();
                                    grd.Rows[e.RowIndex].Cells["OLD_FLOW_NM"].Value = dt.Rows[0]["FLOW_NM"].ToString(); //백업 키워드 
                                    grd.Rows[e.RowIndex].Cells["식별표"].Value = dt.Rows[0]["ITEM_IDEN_NM"].ToString(); //백업 키워드 
                                    if (dt.Rows[0]["FLOW_INSERT_YN"].ToString().Equals("Y"))
                                    {
                                        grd.Rows[e.RowIndex].Cells["FLOW_YN"].Value = true;
                                    }
                                    else
                                    {
                                        grd.Rows[e.RowIndex].Cells["FLOW_YN"].Value = false;
                                    }

                                    itemFlowGridAdd();
                                }
                                else
                                { //row가 없는 경우
                                    MessageBox.Show("데이터가 없습니다.");
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

        private void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                switch (itemRawGrid.Columns[e.ColumnIndex].Name)
                {
                    case "RAW_MAT_NM":
                        if (itemRawGrid.Rows[e.RowIndex].Cells["RAW_MAT_NM"].Value == null)
                        {

                            conDataGridView grd = (conDataGridView)sender;
                            DataGridViewCell cell = grd[e.ColumnIndex, e.RowIndex];

                            cell.Style.BackColor = Color.White;

                            if (grd.Columns[e.ColumnIndex].ToolTipText.IndexOf("명칭") >= 0)
                            {
                                string rat_mat_nm = (string)grd.Rows[e.RowIndex].Cells["RAW_MAT_NM"].Value;
                                wnDm wDm = new wnDm();
                                DataTable dt = new DataTable();
                                dt = wDm.fn_Raw_List("where RAW_MAT_NM like '%" + rat_mat_nm + "%' ","1");

                                if (dt.Rows.Count > 1)
                                { //row가 2줄이 넘을 경우 팝업으로 넘어간다.

                                    wConst.call_pop_raw_mat(grd, dt, e.RowIndex, rat_mat_nm, 1, "");
                                    //itemCompGridAdd();
                                }
                                else if (dt.Rows.Count == 1) //row가 1일 경우 해당 row에 값을 자동 입력한다.
                                {
                                    grd.Rows[e.RowIndex].Cells["RAW_MAT_CD"].Value = dt.Rows[0]["RAW_MAT_CD"].ToString();
                                    grd.Rows[e.RowIndex].Cells["RAW_MAT_NM"].Value = dt.Rows[0]["RAW_MAT_NM"].ToString();
                                    grd.Rows[e.RowIndex].Cells["OLD_RAW_MAT_NM"].Value = dt.Rows[0]["RAW_MAT_NM"].ToString(); //백업 키워드 
                                    grd.Rows[e.RowIndex].Cells["SPEC"].Value = dt.Rows[0]["SPEC"].ToString();
                                    grd.Rows[e.RowIndex].Cells["IN_UNIT"].Value = dt.Rows[0]["INPUT_UNIT"].ToString();
                                    grd.Rows[e.RowIndex].Cells["OUT_UNIT"].Value = dt.Rows[0]["OUTPUT_UNIT"].ToString();
                                    grd.Rows[e.RowIndex].Cells["IN_UNIT_NM"].Value = dt.Rows[0]["INPUT_UNIT_NM"].ToString();
                                    grd.Rows[e.RowIndex].Cells["OUT_UNIT_NM"].Value = dt.Rows[0]["OUTPUT_UNIT_NM"].ToString();
                                    grd.Rows[e.RowIndex].Cells["TOTAL_AMT"].Value = "0";

                                    itemCompGridAdd();
                                }
                                else
                                { //row가 없는 경우
                                    MessageBox.Show("데이터가 없습니다.");
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

        private void frm제품등록_Resize(object sender, EventArgs e)
        {

        }

        private void txt_comment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave.Focus();
            }

            else
            {
                return;
            }
        }

        private void txt_item_cd_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComInfo.onlyNum(sender, e);
        }

        private void cmb_line_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn중복확인_Click(object sender, EventArgs e)
        {
            if (lbl중복확인.Text == "")
            {
                MessageBox.Show("코드입력해주세요");
                return;
            }
            try
            {
                DataTable dt = wnDm.n테이블_등록_코드중복확인("N_ITEM_CODE", "where ITEM_CD='" + txt_item_cd.Text + "'");

                if (dt.Rows[0][0].ToString() == "0")
                {
                    lbl중복확인.ForeColor = Color.Green;
                    lbl중복확인.Text = "중복확인 완료";
                }
                else
                {
                    lbl중복확인.ForeColor = Color.Red;
                    lbl중복확인.Text = "중복입니다.";

                }
            }
            catch
            {
            }
        }

        private void itemFlowGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            String columnName = this.itemFlowGrid.Columns[e.ColumnIndex].Name;
            if (e.RowIndex>-1 && columnName == "식별표")
            {
                for (int i = 0; i < itemFlowGrid.Rows.Count; i++)
                {
                    if (itemFlowGrid.Rows[i].Cells["식별표"].Value != null && (bool)itemFlowGrid.Rows[i].Cells["식별표"].Value)
                    {
                        itemFlowGrid.Rows[i].Cells["식별표"].Value = false;
                    }

                }
                itemFlowGrid.Rows[e.RowIndex].Cells["식별표"].Value = true;
            }
        }

        private void btn_img_Click(object sender, EventArgs e)
        {
            if (txt_item_cd.Text.Equals(""))
            {
                MessageBox.Show("제품코드를 입력하세요.");
            }
            else
            {
                도면등록.item_cd.Text = txt_item_cd.Text;
                도면등록.ShowDialog();
            }
        }

        private void itemRawGrid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //var source = new AutoCompleteStringCollection();
            //source.AddRange(autoSelect);
            //DataGridViewTextBoxEditingControl rawName = (DataGridViewTextBoxEditingControl)e.Control;

            //rawName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //rawName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //rawName.AutoCompleteCustomSource = source;
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

        private void btn_Excel_Click(object sender, EventArgs e)
        {
            Popup.pop제품엑셀입력 msg = new Popup.pop제품엑셀입력();
            msg.ShowDialog();
        }
    }
}
