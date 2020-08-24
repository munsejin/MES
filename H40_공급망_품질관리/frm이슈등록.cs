
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

namespace MES.H40_공급망_품질관리
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
    public partial class frm이슈등록 : Form
    {
        private wnGConstant wConst = new wnGConstant();
        private DataTable del_outGrid = new DataTable();
        wnDm wnDm = new wnDm();
        private bool bHeadCheck = false;
        private string old_cust_nm = "";
        string condition = "";

        public frm이슈등록()
        {
            InitializeComponent();

            //this.itemOutGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellEndEdit);
            //this.itemOutGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grid_KeyDown);
            //this.itemOutGrid.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grid_ColumnHeaderMouseClick);

            //this.itemOutGrid.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.grid_RowsAdded);
            //this.itemOutGrid.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.grid_RowsRemoved);
            //this.itemOutGrid.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.grid_EditingControlShowing);

        }
        public static bool p_IsAuth = true;    // 열람권한
        public static bool p_Isrgstr = true;    //등록/수정 권한

        public static bool p_Isdel = true;    // 삭제 권한
        private void frm이슈등록_Load(object sender, EventArgs e)
        {
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
            addButton(txtITEM, 1);
           

            for (int i = 0; i < dgv주문내역.ColumnCount; i++)
            {
                dgv주문내역.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            del_outGrid.Columns.Add("LOT_NO");
            del_outGrid.Columns.Add("LOT_SUB");
            del_outGrid.Columns.Add("SEQ");
            del_outGrid.Columns.Add("J_SEQ");
            del_outGrid.Columns.Add("OLD_TOTAL_AMT");

            output_list(dgv등록이슈,"");

            item_out_detail("");


        }

        #region item out button logic

        private void btnNew_Click(object sender, EventArgs e)
        {
            resetSetting();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (p_Isrgstr)
            {
                outputLogic();
                output_list(dgv등록이슈, "");
                item_out_detail("");

            }
            else
            {
                MessageBox.Show("권한이 없습니다.");
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






            //배송사원
            cbo배송사원.ValueMember = "코드";
            cbo배송사원.DisplayMember = "명칭";
            sqlQuery = comInfo.queryStaff();
            wConst.ComboBox_Read_NoBlank(cbo배송사원, sqlQuery);

            //배송사원
         

           

            //담당사원
            cbo담당사원.ValueMember = "코드";
            cbo담당사원.DisplayMember = "명칭";
            sqlQuery = comInfo.queryStaff();
            wConst.ComboBox_Read_NoBlank(cbo담당사원, sqlQuery);


            //상담사원
            cbo상담사원.ValueMember = "코드";
            cbo상담사원.DisplayMember = "명칭";
            sqlQuery = comInfo.queryStaff();
            wConst.ComboBox_Read_NoBlank(cbo상담사원, sqlQuery);


        

            cbo전표상태.ValueMember = "코드";
            cbo전표상태.DisplayMember = "명칭";
            sqlQuery = comInfo.queryLCode("640");
            wConst.ComboBox_Read_NoBlank(cbo전표상태, sqlQuery);
        }

        private void item_out_detail(string condition)
        {
            wnDm wDm = new wnDm();
            DataTable dt = null;
            if (txt_cust_cd.Text != null && txt_cust_cd.Text != "")
            {
                condition = "and D.CUST_CD = '" + txt_cust_cd.Text.ToString() + "'  ";
            }
            if (txtITEM.Text != "")
            {
                condition = "and A.ITEM_CD = '" + txtitemSrch.Text.ToString() + "'  ";

            }
            dt = wDm.fn_이슈주문_List(condition);

            dgv주문내역.Rows.Clear();
            if (dt != null&dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dgv주문내역.Rows.Add();
                    dgv주문내역.Rows[i].Cells["ORD_DATE"].Value = dt.Rows[i]["ORD_DATE"].ToString();
                    dgv주문내역.Rows[i].Cells["ORD_CD"].Value = dt.Rows[i]["ORD_NUM"].ToString();
                    dgv주문내역.Rows[i].Cells["O전표상태"].Value = dt.Rows[i]["SALE_STATE_NM"].ToString();
                    dgv주문내역.Rows[i].Cells["거래처"].Value = dt.Rows[i]["CUST_NM"].ToString();
                    dgv주문내역.Rows[i].Cells["거래처코드"].Value = dt.Rows[i]["CUST_CD"].ToString();
                    
                    dgv주문내역.Rows[i].Cells["O_배송사원"].Value = dt.Rows[i]["STAFF_NM"].ToString();
                    dgv주문내역.Rows[i].Cells["O_전표상태코드"].Value = dt.Rows[i]["SALE_STATE"].ToString();
                    dgv주문내역.Rows[i].Cells["O_창고코드"].Value = dt.Rows[i]["STORAGE_CD"].ToString();
                    dgv주문내역.Rows[i].Cells["O_창고"].Value = dt.Rows[i]["STORAGE_NM"].ToString();
                    dgv주문내역.Rows[i].Cells["부가세"].Value = dt.Rows[i]["VAT_NM"].ToString();
                    dgv주문내역.Rows[i].Cells["부가세코드"].Value = dt.Rows[i]["VAT_CD"].ToString();
                    dgv주문내역.Rows[i].Cells["배송일자"].Value = dt.Rows[i]["DELIVERY_DATE"].ToString();
                    dgv주문내역.Rows[i].Cells["배송사원코드"].Value = dt.Rows[i]["STAFF_CD"].ToString();

                    dgv주문내역.Rows[i].Cells["배송코드"].Value = dt.Rows[i]["DELIVERY_CD"].ToString();
                }
            }
        }

        private void outputLogic()
        {

            txt시간.Text = DateTime.Now.ToString("HHmmss");
            if (lbl_out_gbn.Text == "")
            {
                try
                {
                    if (거래처코드.ToString().Equals(""))
                    {
                        MessageBox.Show("거래처를 선택하시기 바랍니다.");
                        return;
                    }








                    wnDm wDm = new wnDm();
                    int rsNum = wDm.insert이슈등록(
                       txt_이슈일자.Value.ToString().Substring(0, 10)
                      , str거래처코드
                      , cbo담당사원.SelectedValue.ToString()

                  
                
                    , cbo상담사원.SelectedValue.ToString()
                    , txt비고.Text

                    , txt이슈내역.Text
               , txt전화번호.Text
                  
                    , cbo전표상태.SelectedValue.ToString()
                    , dtp발문요청일자.Value.ToString().Substring(0, 10)
                    , str주문일자
                    , str주문번호
                   



                   
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
              

            }
        }

        private void resetSetting()
        {
            lbl_out_gbn.Text = "";
            btnDelete.Enabled = false;

            txt_이슈일자.Text = DateTime.Now.ToString("yyyy-MM-dd");
            txt_이슈일자.Enabled = true;
            btnCustSrch.Enabled = true;
            txt_out_cd.Text = "";
            txt_cust_cd.Text = "";
            txt_cust_nm.Text = "";
            old_cust_nm = "";
            txt_vat_cd.Text = "";

            txt_cust_nm.Enabled = true;
            txt이슈내역.Text = "";
            txt전화번호.Text = "";
            //chk_self_yn.Checked = false;

            
            del_outGrid.Rows.Clear();
            item_out_detail("");
        }

        private void output_list(DataGridView dgv, string condition)
        {
            dgv.Rows.Clear();
            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = null;
                dt = wDm.fn_이슈등록리스트(condition);

                if (dt != null && dt.Rows.Count > 0)
                {
                    dgv.RowCount = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgv.Rows[i].Cells["ISSUE_DATE"].Value = dt.Rows[i]["ISSUE_DATE"].ToString();
                        dgv.Rows[i].Cells["ISSUE_NUM"].Value = dt.Rows[i]["ISSUE_NUM"].ToString();
                        dgv.Rows[i].Cells["CUST_CD"].Value = dt.Rows[i]["CUST_CD"].ToString();
                        dgv.Rows[i].Cells["CUST_NM"].Value = dt.Rows[i]["CUST_NM"].ToString();
                        dgv.Rows[i].Cells["STAFF_CD"].Value = dt.Rows[i]["STAFF_CD"].ToString();
                        dgv.Rows[i].Cells["STAFF_NM"].Value = dt.Rows[i]["STAFF_NM"].ToString();
                        dgv.Rows[i].Cells["ISSUE_STAFF_CD"].Value = dt.Rows[i]["ISSUE_STAFF_CD"].ToString();
                        dgv.Rows[i].Cells["ISSUE_STAFF_NM"].Value = dt.Rows[i]["ISSUE_STAFF_NM"].ToString();
                        dgv.Rows[i].Cells["ISSUE_CD"].Value = dt.Rows[i]["ISSUE_CD"].ToString();
                        dgv.Rows[i].Cells["ISSUE_MEMO"].Value = dt.Rows[i]["ISSUE_MEMO"].ToString();
                        dgv.Rows[i].Cells["COMMENT"].Value = dt.Rows[i]["COMMENT"].ToString();
                        dgv.Rows[i].Cells["REQ_DATE"].Value = dt.Rows[i]["REQ_DATE"].ToString();
                        dgv.Rows[i].Cells["TEL_NO"].Value = dt.Rows[i]["TEL_NO"].ToString();
                        dgv.Rows[i].Cells["O_ORD_DATE"].Value = dt.Rows[i]["ORD_DATE"].ToString();
                        dgv.Rows[i].Cells["O_ORD_NUM"].Value = dt.Rows[i]["ORD_NUM"].ToString();
                        dgv.Rows[i].Cells["ISSUE_NM"].Value = dt.Rows[i]["ISSUE_NM"].ToString();
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
                output_list(dgv등록이슈, "where convert(varchar(10), A.INTIME, 120) = convert(varchar(10), getDate(), 120) ");
            }
            else
            {
                txt_start_date.Text = DateTime.Today.AddMonths(-1).ToString("yyyy-MM-dd");
                output_list(outputGrid, "where A.OUTPUT_DATE >= '" + txt_start_date.Text.ToString() + "' and  A.OUTPUT_DATE <= '" + txt_end_date.Text.ToString() + "'");
            }
        }

        private void tdOutGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ComInfo.grdHeaderNoAction(e))
            {
                out_detail(dgv등록이슈, e);
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
            txt_이슈일자.Enabled = false;
            txt_cust_nm.Enabled = false;
            btnCustSrch.Enabled = false;
            txt_이슈일자.Text = dgv.Rows[e.RowIndex].Cells["ISSUE_DATE"].Value.ToString();

            txt_out_cd.Text = dgv.Rows[e.RowIndex].Cells["ISSUE_NUM"].Value.ToString();
            txt_cust_cd.Text = dgv.Rows[e.RowIndex].Cells["CUST_CD"].Value.ToString();
            txt_cust_nm.Text = dgv.Rows[e.RowIndex].Cells["CUST_NM"].Value.ToString();
            old_cust_nm = dgv.Rows[e.RowIndex].Cells["CUST_NM"].Value.ToString();
            txt이슈내역.Text = dgv.Rows[e.RowIndex].Cells["ISSUE_MEMO"].Value.ToString();
            txt비고.Text = dgv.Rows[e.RowIndex].Cells["COMMENT"].Value.ToString();
            cbo상담사원.SelectedValue = dgv.Rows[e.RowIndex].Cells["ISSUE_STAFF_CD"].Value.ToString();
            cbo담당사원.SelectedValue = dgv.Rows[e.RowIndex].Cells["STAFF_CD"].Value.ToString();
            txt전화번호.Text = dgv.Rows[e.RowIndex].Cells["TEL_NO"].Value.ToString();
            cbo전표상태.SelectedValue = dgv.Rows[e.RowIndex].Cells["ISSUE_CD"].Value.ToString();
            cbo전표상태.SelectedValue = dgv.Rows[e.RowIndex].Cells["ISSUE_CD"].Value.ToString();

            dtp발문요청일자.Text = dgv.Rows[e.RowIndex].Cells["REQ_DATE"].Value.ToString();


            //dgv.Rows[i].Cells["ISSUE_DATE"].Value = dt.Rows[i]["ISSUE_DATE"].ToString();
            //dgv.Rows[i].Cells["ISSUE_NUM"].Value = dt.Rows[i]["ISSUE_NUM"].ToString();
            //dgv.Rows[i].Cells["CUST_CD"].Value = dt.Rows[i]["CUST_CD"].ToString();
            //dgv.Rows[i].Cells["CUST_NM"].Value = dt.Rows[i]["CUST_NM"].ToString();
            //dgv.Rows[i].Cells["STAFF_CD"].Value = dt.Rows[i]["STAFF_CD"].ToString();
            //dgv.Rows[i].Cells["STAFF_NM"].Value = dt.Rows[i]["STAFF_NM"].ToString();
            //dgv.Rows[i].Cells["ISSUE_STAFF_CD"].Value = dt.Rows[i]["ISSUE_STAFF_CD"].ToString();
            //dgv.Rows[i].Cells["ISSUE_STAFF_NM"].Value = dt.Rows[i]["ISSUE_STAFF_NM"].ToString();
            //dgv.Rows[i].Cells["ISSUE_CD"].Value = dt.Rows[i]["ISSUE_CD"].ToString();
            //dgv.Rows[i].Cells["ISSUE_MEMO"].Value = dt.Rows[i]["ISSUE_MEMO"].ToString();
            //dgv.Rows[i].Cells["COMMENT"].Value = dt.Rows[i]["COMMENT"].ToString();
            //dgv.Rows[i].Cells["REQ_DATE"].Value = dt.Rows[i]["REQ_DATE"].ToString();
            //dgv.Rows[i].Cells["TEL_NO"].Value = dt.Rows[i]["TEL_NO"].ToString();
            //dgv.Rows[i].Cells["O_ORD_DATE"].Value = dt.Rows[i]["ORD_DATE"].ToString();
            //dgv.Rows[i].Cells["O_ORD_NUM"].Value = dt.Rows[i]["ORD_NUM"].ToString();

           
        }

        private void outputDetail2()
        {
          
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
            DialogResult msgOk = comInfo.deleteConfrim("이슈", txt_이슈일자.Text.ToString() + " - " + txt_out_cd.Text.ToString());

            if (msgOk == DialogResult.No)
            {
                return;
            }

            if (txt_jang_cd == null || txt_jang_cd.Text == null)
            {
                txt_jang_cd.Text = "";
            }

            wnDm wDm = new wnDm();
            int rsNum = wDm.delete이슈(txt_이슈일자.Text.ToString(), txt_out_cd.Text.ToString());
            if (rsNum == 0)
            {
                resetSetting();
                output_list(dgv등록이슈, "where convert(varchar(10), A.INTIME, 120) = convert(varchar(10), getDate(), 120) ");
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
            //string name = itemOutGrid.CurrentCell.OwningColumn.Name;

            //if (name == "OUTPUT_AMT" || name == "PRICE" || name == "TOTAL_MONEY")
            //{
            //    e.Control.KeyPress += new KeyPressEventHandler(txtCheckNumeric_KeyPress);
            //}
            //else
            //{
            //    e.Control.KeyPress -= new KeyPressEventHandler(txtCheckNumeric_KeyPress);
            //}
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

                wConst.f_Calc_Price(grd, e.RowIndex, "OUTPUT_AMT", "PRICE");
            }
        }
        #endregion grid control

        private void txt_bar_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComInfo.onlyNum(sender, e);

            if (txt_bar.Text.Length == 13)
            {
                

            }
        }

        private void txt_cust_nm_TextChanged(object sender, EventArgs e)
        {

        }

        private void frm이슈등록_Enter(object sender, EventArgs e)
        {
            btnSrch.PerformClick();
        }

        private void btnSerch_Click(object sender, EventArgs e)
        {
            item_out_detail("");
        }


        String str주문일자 = "";
        String str주문번호 = "";
        String str배송일자 = "";
        String str배송번호 = "";
        String str거래처코드 = "";

        private void dgv주문내역_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {


                resetSetting();
                str주문일자 = dgv주문내역.Rows[e.RowIndex].Cells["ORD_DATE"].Value.ToString();
                str주문번호 = dgv주문내역.Rows[e.RowIndex].Cells["ORD_CD"].Value.ToString();

                str배송일자 = dgv주문내역.Rows[e.RowIndex].Cells["배송일자"].Value.ToString();
                str배송번호 = dgv주문내역.Rows[e.RowIndex].Cells["배송코드"].Value.ToString();
             

               
                str거래처코드 = dgv주문내역.Rows[e.RowIndex].Cells["거래처코드"].Value.ToString();
                txt_cust_nm.Text = dgv주문내역.Rows[e.RowIndex].Cells["거래처"].Value.ToString();

                cbo담당사원.SelectedValue = dgv주문내역.Rows[e.RowIndex].Cells["배송사원코드"].Value.ToString();
              //  cbo전표상태.SelectedValue = dgv주문내역.Rows[e.RowIndex].Cells["O_전표상태코드"].Value.ToString();

                //dgv주문내역.Rows[i].Cells["ORD_DATE"].Value = dt.Rows[i]["ORD_DATE"].ToString();
                //dgv주문내역.Rows[i].Cells["ORD_CD"].Value = dt.Rows[i]["ORD_NUM"].ToString();
                //dgv주문내역.Rows[i].Cells["O전표상태"].Value = dt.Rows[i]["SALE_STATE_NM"].ToString();
                //dgv주문내역.Rows[i].Cells["거래처"].Value = dt.Rows[i]["CUST_NM"].ToString();
                //dgv주문내역.Rows[i].Cells["거래처코드"].Value = dt.Rows[i]["CUST_CD"].ToString();
                //dgv주문내역.Rows[i].Cells["거래처코드"].Value = dt.Rows[i]["CUST_CD"].ToString();
                //dgv주문내역.Rows[i].Cells["O_배송사원"].Value = dt.Rows[i]["DELIVERY_NM"].ToString();
                //dgv주문내역.Rows[i].Cells["O_전표상태코드"].Value = dt.Rows[i]["SALE_STATE"].ToString();
                //dgv주문내역.Rows[i].Cells["O_창고코드"].Value = dt.Rows[i]["STORAGE_CD"].ToString();
                //dgv주문내역.Rows[i].Cells["O_창고"].Value = dt.Rows[i]["STORAGE_NM"].ToString();
                //dgv주문내역.Rows[i].Cells["부가세"].Value = dt.Rows[i]["VAT_NM"].ToString();
                //dgv주문내역.Rows[i].Cells["부가세코드"].Value = dt.Rows[i]["VAT_CD"].ToString();
                //dgv주문내역.Rows[i].Cells["배송일자"].Value = dt.Rows[i]["DELIVERY_DATE"].ToString();
                //dgv주문내역.Rows[i].Cells["배송사원코드"].Value = dt.Rows[i]["DELIVERY_STAFF_CD"].ToString();


            }
        }
    }
}
