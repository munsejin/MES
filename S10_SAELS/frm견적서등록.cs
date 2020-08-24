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

namespace MES.S10_SALES
{
    public partial class frm견적서등록 : Form
    {
        private wnGConstant wConst = new wnGConstant();
        private DataTable del_estiGrid = new DataTable();
        private ComInfo comInfo = new ComInfo();
        private string old_cust_nm = "";

        private DataGridView pHalfGrid = new DataGridView();

        public frm견적서등록()
        {
            InitializeComponent();

            this.itemEstimateGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellEndEdit);
            this.itemEstimateGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grid_KeyDown);
            this.itemEstimateGrid.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grid_ColumnHeaderMouseClick);
            this.itemEstimateGrid.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.grid_RowsAdded);
            this.itemEstimateGrid.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.grid_RowsRemoved);
            this.itemEstimateGrid.CellValueChanged += new DataGridViewCellEventHandler(grid_CellValueChanged);
            this.itemEstimateGrid.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.grid_ColumnWidthChanged);
            this.itemEstimateGrid.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.grid_EditingControlShowing);
        }

        private void frm견적서등록_Load(object sender, EventArgs e)
        {
            //DateTime today = DateTime.Today.AddMonths(-1);
            lbl_title.Tag = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[0] + "$" + wnDm.fn_TitleName(this.Name.ToString()).Split('$')[1]; lbl_title.Text = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[2];

            start_date.Text = DateTime.Today.AddMonths(-1).ToString("yyyy-MM-dd");

            itemEstimateGridAdd();

            esti_list(estiGrid, "where A.ESTI_DATE >= '" + start_date.Text.ToString() + "' and  A.ESTI_DATE <= '" + end_date.Text.ToString() + "'");


            del_estiGrid.Columns.Add("ESTI_DATE");
            del_estiGrid.Columns.Add("ESTI_CD");
            del_estiGrid.Columns.Add("SEQ");


            ComInfo.gridHeaderSet(itemEstimateGrid);
            ComInfo.gridHeaderSet(estiGrid);

            TotalSumGrid.Rows.Add();


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
            plan_logic();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            plan_del();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCustSrch_Click(object sender, EventArgs e)
        {
            Popup.pop거래처검색 frm = new Popup.pop거래처검색();

            frm.sCustGbn = "1"; //매출처
            frm.sCustNm = txt_cust_nm.Text.ToString();
            frm.ShowDialog();

            if (frm.sCode != "")
            {
                txt_cust_cd.Text = frm.sCode.Trim();
                txt_cust_nm.Text = frm.sName.Trim();
               // txt_tax_cd.Text = frm.sTaxCd.Trim();
                old_cust_nm = frm.sCode.Trim();
            }
            else
            {
                txt_cust_cd.Text = old_cust_nm;
            }


            frm.Dispose();
            frm = null;
        }

        private void btnSrch_Click(object sender, EventArgs e)
        {
            esti_list(estiGrid, "where A.ESTI_DATE >= '" + start_date.Text.ToString() + "' and  A.ESTI_DATE <= '" + end_date.Text.ToString() + "'");
        }
        #endregion btn click


        #region prod plan logic

        private void resetSetting()
        {
            lbl_input_gbn.Text = "";
            btnDelete.Enabled = false;

            txt_esti_date.Text = DateTime.Now.ToString("yyyy-MM-dd");
            txt_esti_date.Enabled = true;
            txt_esti_cd.Text = "";
            txt_cust_cd.Text = "";
            txt_cust_nm.Text = "";
            txt_comment.Text = "";
            txt_tax_cd.Text = "";
            old_cust_nm = "";

            itemEstimateGrid.Rows.Clear();
            TotalSumGrid.Rows.Clear();
            TotalSumGrid.Rows.Add();
            pHalfGrid.Rows.Clear();

            itemEstimateGridAdd();
            
            del_estiGrid.Rows.Clear();
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

                if (itemEstimateGrid.Rows.Count > 0)
                {
                    int cnt = 0;
                    int grid_cnt = itemEstimateGrid.Rows.Count;
                    for (int i = 0; i < grid_cnt; i++)
                    {
                        string txt_item_cd = (string)itemEstimateGrid.Rows[i - cnt].Cells["ITEM_CD"].Value;

                        if (txt_item_cd == "" || txt_item_cd == null)  //마지막 행에 원자재코드가 없을 경우 제거
                        {
                            itemEstimateGrid.Rows.RemoveAt(i-cnt);
                            cnt++;
                        }
                    }
                }

                if (lbl_input_gbn.Text != "1")
                {

                    wnDm wDm = new wnDm();
                    int rsNum = wDm.insertEstimate(
                        txt_esti_date.Text.ToString(),
                        txt_cust_cd.Text.ToString(),
                        txt_comment.Text.ToString(),
                        txt_tax_cd.Text.ToString(),
                        itemEstimateGrid,
                        TotalSumGrid
                        );

                    if (rsNum == 0)
                    {
                        resetSetting();
                        esti_list(estiGrid, "where A.ESTI_DATE >= '" + start_date.Text.ToString() + "' and  A.ESTI_DATE <= '" + end_date.Text.ToString() + "'");

                        MessageBox.Show("성공적으로 등록하였습니다.");
                    }
                    else if (rsNum == 1)
                        MessageBox.Show("저장에 실패하였습니다");
                    else if (rsNum == 2)
                        MessageBox.Show("SQL COMMAND 에러");
                    else if (rsNum == 3)
                        MessageBox.Show("기존 코드가 있으니 \n 다른 코드로 입력 바랍니다.");
                    else
                        MessageBox.Show("Exception 에러");
                }
                else 
                {
                    wnDm wDm = new wnDm();
                    int rsNum = wDm.updateEstimate(
                        txt_esti_date.Text.ToString(),
                        txt_esti_cd.Text.ToString(),
                        txt_cust_cd.Text.ToString(),
                        txt_comment.Text.ToString(),
                        txt_tax_cd.Text.ToString(),
                        itemEstimateGrid,
                        TotalSumGrid,
                        del_estiGrid
                        );

                    if (rsNum == 0)
                    {
                        
                        MessageBox.Show("성공적으로 수정하였습니다.");

                        del_estiGrid.Rows.Clear();
                        esti_list(estiGrid, "where A.ESTI_DATE >= '" + start_date.Text.ToString() + "' and  A.ESTI_DATE <= '" + end_date.Text.ToString() + "'");
                        estiDetail2();

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

        private void esti_list(DataGridView dgv,string condition) 
        {
            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = null;
                dt = wDm.fn_Esti_List(condition);

                //lbl_cnt.Text = dt.Rows.Count.ToString();

                if (dt != null && dt.Rows.Count > 0)
                {
                    dgv.RowCount = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgv.Rows[i].Cells[0].Value = dt.Rows[i]["ESTI_DATE"].ToString();
                        dgv.Rows[i].Cells[1].Value = dt.Rows[i]["ESTI_CD"].ToString();
                        dgv.Rows[i].Cells[5].Value = dt.Rows[i]["CUST_CD"].ToString();
                        dgv.Rows[i].Cells[2].Value = dt.Rows[i]["CUST_NM"].ToString();
                        dgv.Rows[i].Cells[8].Value = dt.Rows[i]["ITEM_CNT"].ToString();
                        dgv.Rows[i].Cells["COMMENT"].Value = dt.Rows[i]["COMMENT"].ToString();
                        dgv.Rows[i].Cells["TAX_CD"].Value = dt.Rows[i]["TAX_CD"].ToString();
                    }
                }
                else
                {
                    estiGrid.Rows.Clear();
                }
            }
            catch (Exception e)
            {
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(e.Message+" - "+e.ToString()); msg.ShowDialog();
            }
        }
        #endregion prod plan logic


        private void plan_del() 
        {
            ComInfo comInfo = new ComInfo();
            DialogResult msgOk =  comInfo.deleteConfrim("견적서", txt_esti_date.Text.ToString()+" - "+txt_esti_cd.Text.ToString());

            if (msgOk == DialogResult.No)
            {
                return;
            }

            wnDm wDm = new wnDm();
            int rsNum = wDm.deleteEstimate(txt_esti_date.Text.ToString(), txt_esti_cd.Text.ToString() );
            if (rsNum == 0)
            {
                resetSetting();

                esti_list(estiGrid, "where A.ESTI_DATE >= '" + start_date.Text.ToString() + "' and  A.ESTI_DATE <= '" + end_date.Text.ToString() + "'");

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
            string name = itemEstimateGrid.CurrentCell.OwningColumn.Name;

            if (name == "OUT_AMT" || name == "OUT_PRICE" || name == "TOTAL_MONEY")
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
                //dt = wDm.fn_Raw_Item_List("where A.RAW_MAT_NM like '%" + item_nm + "%'  ","where  B.ITEM_NM like '%" + item_nm + "%'  ");

                if (dt!= null && dt.Rows.Count > 0)
                { //row가 2줄이 넘을 경우 팝업으로 넘어간다.

                    Popup.pop_sf_제품검색 frm = new Popup.pop_sf_제품검색();

                    //frm.sUsedYN = sUsedYN;
                    frm.dt = dt;
                    frm.txtSrch.Text = item_nm;
                    frm.ShowDialog();
                    string sCode = frm.sCode;

                    if (frm.sCode != "")
                    {
                        itemEstimateGrid.Rows[e.RowIndex].Cells["ITEM_CD"].Value = frm.sCode;
                        itemEstimateGrid.Rows[e.RowIndex].Cells["ITEM_NM"].Value = frm.sName;
                        itemEstimateGrid.Rows[e.RowIndex].Cells["UNIT_CD"].Value = frm.sUnitCd;
                        itemEstimateGrid.Rows[e.RowIndex].Cells["UNIT_NM"].Value = frm.sUnitNm;
                        itemEstimateGrid.Rows[e.RowIndex].Cells["VAT_CD"].Value = frm.sVatCd;
                        /* itemEstimateGrid.Rows[e.RowIndex].Cells["LABEL_NM"].Value = frm.sLabelNM;
                         itemEstimateGrid.Rows[e.RowIndex].Cells["CHUGJONG_NM"].Value = frm.sChugjong_NM;
                         itemEstimateGrid.Rows[e.RowIndex].Cells["CLASS_NM"].Value = frm.sClass_nm;
                         itemEstimateGrid.Rows[e.RowIndex].Cells["COUNTRY_NM"].Value = frm.sCountry_nm;
                         itemEstimateGrid.Rows[e.RowIndex].Cells["RAW_ITEM_GUBUN"].Value = frm.sGubun;
                         itemEstimateGrid.Rows[e.RowIndex].Cells["TYPE_NM"].Value = frm.sType_nm;
                         * * */
                        
                        
                    }

                }
                else
                {
                    Popup.pop_sf_제품검색 frm = new Popup.pop_sf_제품검색();
                    //dt = wDm.fn_Raw_Item_List("where 1=1  ", "where  1=1  ");
                    //frm.sUsedYN = sUsedYN;
                    frm.dt = dt;
                    frm.txtSrch.Text = item_nm;
                    frm.ShowDialog();
                    string sCode = frm.sCode;

                        if (frm.sCode != "")
                    {
                        itemEstimateGrid.Rows[e.RowIndex].Cells["ITEM_CD"].Value = frm.sCode;
                        itemEstimateGrid.Rows[e.RowIndex].Cells["ITEM_NM"].Value = frm.sName;
                        itemEstimateGrid.Rows[e.RowIndex].Cells["UNIT_CD"].Value = frm.sUnitCd;
                        itemEstimateGrid.Rows[e.RowIndex].Cells["UNIT_NM"].Value = frm.sUnitNm;
                        itemEstimateGrid.Rows[e.RowIndex].Cells["VAT_CD"].Value = frm.sVatCd;
                       /*
                        itemEstimateGrid.Rows[e.RowIndex].Cells["LABEL_NM"].Value = frm.sLabelNM;
                        itemEstimateGrid.Rows[e.RowIndex].Cells["CHUGJONG_NM"].Value = frm.sChugjong_NM;
                        itemEstimateGrid.Rows[e.RowIndex].Cells["CLASS_NM"].Value = frm.sClass_nm;
                        itemEstimateGrid.Rows[e.RowIndex].Cells["COUNTRY_NM"].Value = frm.sCountry_nm;
                        itemEstimateGrid.Rows[e.RowIndex].Cells["RAW_ITEM_GUBUN"].Value = frm.sGubun;
                        itemEstimateGrid.Rows[e.RowIndex].Cells["TYPE_NM"].Value = frm.sType_nm;
                        
                        * */
                    }
                }


            }

            if (grd.Columns[e.ColumnIndex].ToolTipText.IndexOf("수량") >= 0
                || grd.Columns[e.ColumnIndex].ToolTipText.IndexOf("단가") >= 0
                || grd.Columns[e.ColumnIndex].ToolTipText.IndexOf("금액") >= 0)
            {

                string total_amt = (string)grd.Rows[e.RowIndex].Cells["OUT_AMT"].Value;
                string price = (string)grd.Rows[e.RowIndex].Cells["OUT_PRICE"].Value;

                if (total_amt != null)
                {
                    total_amt = total_amt.ToString().Replace(" ", "");
                    if (total_amt == "")
                    {
                        grd.Rows[e.RowIndex].Cells["OUT_AMT"].Value = "0";
                    }
                }
                else 
                {
                    grd.Rows[e.RowIndex].Cells["OUT_AMT"].Value = "0";
                }

                if (price != null)
                {
                    price = price.ToString().Replace(" ", "");
                    if (price == "")
                    {
                        grd.Rows[e.RowIndex].Cells["OUT_PRICE"].Value = "0";
                    }
                }
                else 
                {
                    grd.Rows[e.RowIndex].Cells["OUT_PRICE"].Value = "0";
                }

                //if (total_amt == "" || total_amt == null)
                //{
                //    grd.Rows[e.RowIndex].Cells["TOTAL_AMT"].Value = "0";
                //}
                //if (price == "" || price == null)
                //{
                //    grd.Rows[e.RowIndex].Cells["PRICE"].Value = "0";
                //}

                cal_tax(e.RowIndex);


                string item_cd_chk = (string)grd.Rows[e.RowIndex].Cells["ITEM_CD"].Value;
                
            }
            #endregion 공통 그리드 체크

            //string sSearchTxt = "" + (string)grd.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

        }

        private void btn_plus_Click(object sender, EventArgs e)
        {
            itemEstimateGridAdd();
        }

        private void btn_minus_Click(object sender, EventArgs e)
        {
            minus_logic(itemEstimateGrid);
        }

        private void itemEstimateGridAdd()
        {
            itemEstimateGrid.Rows.Add();
            itemEstimateGrid.Rows[itemEstimateGrid.Rows.Count - 1].Cells["OUT_AMT"].Value = "0";
            itemEstimateGrid.Rows[itemEstimateGrid.Rows.Count - 1].Cells["OUT_PRICE"].Value = "0";
            itemEstimateGrid.Rows[itemEstimateGrid.Rows.Count - 1].Cells["TOTAL_MONEY"].Value = "0";
            itemEstimateGrid.Rows[itemEstimateGrid.Rows.Count - 1].Cells["OUT_MONEY"].Value = "0";
            itemEstimateGrid.Rows[itemEstimateGrid.Rows.Count - 1].Cells["TAX"].Value = "0";
            itemEstimateGrid.Rows[itemEstimateGrid.Rows.Count - 1].Cells["TOTAL_MONEY"].Value = "0";
        }

        private void minus_logic(conDataGridView dgv) 
        {
            if (dgv.Rows.Count > 1)
            {
                if (dgv.SelectedRows[0].Cells["SEQ"].Value != null && !dgv.SelectedRows[0].Cells["SEQ"].Value.ToString().Equals(""))
                {
                    
                    del_estiGrid.Rows.Add();

                    del_estiGrid.Rows[del_estiGrid.Rows.Count - 1]["ESTI_DATE"] = txt_esti_date.Text.ToString();
                    del_estiGrid.Rows[del_estiGrid.Rows.Count - 1]["ESTI_CD"] = txt_esti_cd.Text.ToString();
                    del_estiGrid.Rows[del_estiGrid.Rows.Count - 1]["SEQ"] = dgv.SelectedRows[0].Cells["SEQ"].Value;
                }

                

                dgv.Rows.RemoveAt(dgv.SelectedRows[0].Index);
                dgv.CurrentCell = dgv[2, dgv.Rows.Count - 1];
            }

        }

        private void planGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ComInfo.grdHeaderNoAction(e)) 
            {
                del_estiGrid.Rows.Clear();
                EstiDetail(estiGrid, e);
            }

        }
        private void EstiDetail(DataGridView dgv, DataGridViewCellEventArgs e) 
        {
            btnDelete.Enabled = true;
            lbl_input_gbn.Text = "1";
            txt_esti_date.Enabled = false;
            txt_esti_date.Text = dgv.Rows[e.RowIndex].Cells[0].Value.ToString();

            txt_esti_cd.Text = dgv.Rows[e.RowIndex].Cells[1].Value.ToString();
            txt_cust_cd.Text = dgv.Rows[e.RowIndex].Cells[5].Value.ToString();
            txt_cust_nm.Text = dgv.Rows[e.RowIndex].Cells[2].Value.ToString();
            txt_comment.Text = dgv.Rows[e.RowIndex].Cells["COMMENT"].Value.ToString();
            txt_tax_cd.Text = dgv.Rows[e.RowIndex].Cells["TAX_CD"].Value.ToString();


            

            estiDetail2();
            }

        private void estiDetail2() 
        {
            wnDm wDm = new wnDm();
            DataTable dt = null;

            dt = wDm.fn_Esti_Detail_List("where A.ESTI_DATE = '" + txt_esti_date.Text.ToString() + "' and A.ESTI_CD = '" + txt_esti_cd.Text.ToString() + "' ");

            if (dt != null && dt.Rows.Count > 0)
            {

                itemEstimateGrid.Rows.Clear();


                for (int i = 0; i < dt.Rows.Count; i++) 
                {
                    itemEstimateGridAdd();
                    itemEstimateGrid.Rows[i].Cells["SEQ"].Value = dt.Rows[i]["SEQ"].ToString();
                    itemEstimateGrid.Rows[i].Cells["ITEM_CD"].Value = dt.Rows[i]["ITEM_CD"].ToString();
                    itemEstimateGrid.Rows[i].Cells["ITEM_NM"].Value = dt.Rows[i]["ITEM_NM"].ToString();
                    itemEstimateGrid.Rows[i].Cells["UNIT_CD"].Value = dt.Rows[i]["UNIT_CD"].ToString();
                    itemEstimateGrid.Rows[i].Cells["UNIT_NM"].Value = dt.Rows[i]["UNIT_NM"].ToString();
                    //itemEstimateGrid.Rows[i].Cells["CLASS_CD"].Value = dt.Rows[i]["CLASS_CD"].ToString();
                    //itemEstimateGrid.Rows[i].Cells["CLASS_NM"].Value = dt.Rows[i]["CLASS_NM"].ToString();
                    //itemEstimateGrid.Rows[i].Cells["COUNTRY_CD"].Value = dt.Rows[i]["COUNTRY_CD"].ToString();
                    //itemEstimateGrid.Rows[i].Cells["COUNTRY_NM"].Value = dt.Rows[i]["COUNTRY_NM"].ToString();
                    //itemEstimateGrid.Rows[i].Cells["CHUGJONG_CD"].Value = dt.Rows[i]["CHUGJONG_CD"].ToString();
                    //itemEstimateGrid.Rows[i].Cells["CHUGJONG_NM"].Value = dt.Rows[i]["CHUGJONG_NM"].ToString();
                    itemEstimateGrid.Rows[i].Cells["TYPE_CD"].Value = dt.Rows[i]["TYPE_CD"].ToString();
                    itemEstimateGrid.Rows[i].Cells["TYPE_NM"].Value = dt.Rows[i]["TYPE_NM"].ToString();
                    //itemEstimateGrid.Rows[i].Cells["LABEL_NM"].Value = dt.Rows[i]["LABEL_NM"].ToString();
                    //itemEstimateGrid.Rows[i].Cells["RAW_ITEM_GUBUN"].Value = dt.Rows[i]["RAW_ITEM_GUBUN"].ToString().Equals("1") ? "상품" : "제품";
                    itemEstimateGrid.Rows[i].Cells["VAT_CD"].Value = dt.Rows[i]["VAT_CD"].ToString();


                    itemEstimateGrid.Rows[i].Cells["OUT_AMT"].Value = (decimal.Parse(dt.Rows[i]["TOTAL_AMT"].ToString())).ToString("#,0.######");
                    itemEstimateGrid.Rows[i].Cells["OUT_PRICE"].Value = (decimal.Parse(dt.Rows[i]["TOTAL_PRICE"].ToString())).ToString("#,0.######");
                    cal_tax(i);

                }
            }
            else
            {
                itemEstimateGrid.RowCount = 0;
                itemEstimateGridAdd(); //데이터가 없을 경우 빈 행 생성
            }
        }

       
        private void txt_cust_nm_Leave(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Popup.pop거래처검색 frm = new Popup.pop거래처검색();

                frm.sCustGbn = "1"; //매출처
                frm.sCustNm = txt_cust_nm.Text.ToString();
                frm.ShowDialog();

                if (frm.sCode != "")
                {
                    txt_cust_cd.Text = frm.sCode.Trim();
                    txt_cust_nm.Text = frm.sName.Trim();
                    //txt_tax_cd.Text = frm.sTaxCd.Trim();
                    old_cust_nm = frm.sCode.Trim();
                }
                else
                {
                    txt_cust_cd.Text = old_cust_nm;
                }


                frm.Dispose();
                frm = null;
            }
        }


        private void cal_tax(int e_RowIndex)
        {
            
            if (itemEstimateGrid.Rows[e_RowIndex].Cells["ITEM_CD"].Value != null && !itemEstimateGrid.Rows[e_RowIndex].Cells["ITEM_CD"].Value.ToString().Equals(""))
            {

                if (itemEstimateGrid.Rows[e_RowIndex].Cells["OUT_AMT"].Value == null || itemEstimateGrid.Rows[e_RowIndex].Cells["OUT_AMT"].Value.ToString().Equals(""))
                {
                    itemEstimateGrid.Rows[e_RowIndex].Cells["OUT_AMT"].Value = "0";
                }
                if (itemEstimateGrid.Rows[e_RowIndex].Cells["OUT_MONEY"].Value == null || itemEstimateGrid.Rows[e_RowIndex].Cells["OUT_MONEY"].Value.ToString().Equals(""))
                {
                    itemEstimateGrid.Rows[e_RowIndex].Cells["OUT_MONEY"].Value = "0";
                }
                if (itemEstimateGrid.Rows[e_RowIndex].Cells["TAX"].Value == null || itemEstimateGrid.Rows[e_RowIndex].Cells["TAX"].Value.ToString().Equals(""))
                {
                    itemEstimateGrid.Rows[e_RowIndex].Cells["TAX"].Value = "0";
                }
                if (itemEstimateGrid.Rows[e_RowIndex].Cells["TOTAL_MONEY"].Value == null || itemEstimateGrid.Rows[e_RowIndex].Cells["TOTAL_MONEY"].Value.ToString().Equals(""))
                {
                    itemEstimateGrid.Rows[e_RowIndex].Cells["TOTAL_MONEY"].Value = "0";
                }
                if (itemEstimateGrid.Rows[e_RowIndex].Cells["OUT_PRICE"].Value == null || itemEstimateGrid.Rows[e_RowIndex].Cells["OUT_PRICE"].Value.ToString().Equals(""))
                {
                    itemEstimateGrid.Rows[e_RowIndex].Cells["OUT_PRICE"].Value = "0";
                }

                if (itemEstimateGrid.Rows[e_RowIndex].Cells["VAT_CD"].Value.ToString().Equals("2")) //면세
                {
                    decimal outmoney = decimal.Parse(itemEstimateGrid.Rows[e_RowIndex].Cells["OUT_AMT"].Value.ToString()) * decimal.Parse(itemEstimateGrid.Rows[e_RowIndex].Cells["OUT_PRICE"].Value.ToString());
                    decimal tax = 0;
                    decimal totalMoney = outmoney + tax;

                    itemEstimateGrid.Rows[e_RowIndex].Cells["OUT_MONEY"].Value = outmoney.ToString("#,0.######");
                    itemEstimateGrid.Rows[e_RowIndex].Cells["TAX"].Value = tax.ToString("#,0.######"); ;
                    itemEstimateGrid.Rows[e_RowIndex].Cells["TOTAL_MONEY"].Value = totalMoney.ToString("#,0.######");
                }
                else //과세일 경우 
                {
                    if (txt_tax_cd.Text.Equals("0")) // 부가세 별도
                    {
                        decimal outmoney = decimal.Parse(itemEstimateGrid.Rows[e_RowIndex].Cells["OUT_AMT"].Value.ToString()) * decimal.Parse(itemEstimateGrid.Rows[e_RowIndex].Cells["OUT_PRICE"].Value.ToString());
                        decimal tax = outmoney * decimal.Parse("0.1");
                        decimal totalMoney = outmoney + tax;

                        itemEstimateGrid.Rows[e_RowIndex].Cells["OUT_MONEY"].Value = outmoney.ToString("#,0.######");
                        itemEstimateGrid.Rows[e_RowIndex].Cells["TAX"].Value = tax.ToString("#,0.######"); ;
                        itemEstimateGrid.Rows[e_RowIndex].Cells["TOTAL_MONEY"].Value = totalMoney.ToString("#,0.######");

                    }
                    else if (txt_tax_cd.Text.Equals("1")) // 부가세 포함
                    {
                        //얘
                        decimal totalMoney = decimal.Parse(itemEstimateGrid.Rows[e_RowIndex].Cells["OUT_AMT"].Value.ToString()) * decimal.Parse(itemEstimateGrid.Rows[e_RowIndex].Cells["OUT_PRICE"].Value.ToString());
                        decimal outmoney = totalMoney / decimal.Parse("1.1");
                        outmoney = decimal.Round(outmoney, 0);
                        decimal tax = totalMoney - outmoney;

                        itemEstimateGrid.Rows[e_RowIndex].Cells["OUT_MONEY"].Value = outmoney.ToString("#,0.######");
                        itemEstimateGrid.Rows[e_RowIndex].Cells["TAX"].Value = tax.ToString("#,0.######"); ;
                        itemEstimateGrid.Rows[e_RowIndex].Cells["TOTAL_MONEY"].Value = totalMoney.ToString("#,0.######");
                    }
                    else
                    { //영세율
                        decimal outmoney = decimal.Parse(itemEstimateGrid.Rows[e_RowIndex].Cells["OUT_AMT"].Value.ToString()) * decimal.Parse(itemEstimateGrid.Rows[e_RowIndex].Cells["OUT_PRICE"].Value.ToString());
                        decimal tax = 0;
                        decimal totalMoney = outmoney + tax;

                        itemEstimateGrid.Rows[e_RowIndex].Cells["OUT_MONEY"].Value = outmoney.ToString("#,0.######");
                        itemEstimateGrid.Rows[e_RowIndex].Cells["TAX"].Value = tax.ToString("#,0.######"); ;
                        itemEstimateGrid.Rows[e_RowIndex].Cells["TOTAL_MONEY"].Value = totalMoney.ToString("#,0.######");
                    }
                }

                if (txt_tax_cd.Text.Equals("1"))
                {
                    decimal sumTotMoney = 0;
                    decimal sum과세OutMoney = 0;
                    decimal sum면세OutMoney = 0;
                    decimal oneDotone = decimal.Parse("1.1");

                    for (int i = 0; i < itemEstimateGrid.Rows.Count; i++)
                    {
                        sumTotMoney += decimal.Parse(itemEstimateGrid.Rows[i].Cells["TOTAL_MONEY"].Value.ToString());
                        if (itemEstimateGrid.Rows[i].Cells["VAT_CD"].Value.ToString().Equals("1"))
                        {
                            sum과세OutMoney += decimal.Parse(itemEstimateGrid.Rows[i].Cells["TOTAL_MONEY"].Value.ToString());
                        }
                        else
                        {
                            sum면세OutMoney += decimal.Parse(itemEstimateGrid.Rows[i].Cells["TOTAL_MONEY"].Value.ToString());
                        }
                    }
                    TotalSumGrid.Rows[0].Cells["SUM_TOTAL_MONEY"].Value = sumTotMoney.ToString("#,0.######");
                    TotalSumGrid.Rows[0].Cells["SUM_OUT_MONEY"].Value = (decimal.Round(((sum과세OutMoney / oneDotone) + sum면세OutMoney), 0)).ToString("#,0.######");
                    TotalSumGrid.Rows[0].Cells["SUM_TAX"].Value = (decimal.Parse(TotalSumGrid.Rows[0].Cells["SUM_TOTAL_MONEY"].Value.ToString()) - decimal.Parse(TotalSumGrid.Rows[0].Cells["SUM_OUT_MONEY"].Value.ToString())).ToString("#,0.######");
                }
                else
                {
                    decimal sumTotMoney = 0;
                    decimal sumOutMoney = 0;
                    for (int i = 0; i < itemEstimateGrid.Rows.Count; i++)
                    {
                        sumTotMoney += decimal.Parse(itemEstimateGrid.Rows[i].Cells["TOTAL_MONEY"].Value.ToString());
                        sumOutMoney += decimal.Parse(itemEstimateGrid.Rows[i].Cells["OUT_MONEY"].Value.ToString());
                    }
                    TotalSumGrid.Rows[0].Cells["SUM_TOTAL_MONEY"].Value = sumTotMoney.ToString("#,0.######");
                    TotalSumGrid.Rows[0].Cells["SUM_OUT_MONEY"].Value = sumOutMoney.ToString("#,0.######");
                    TotalSumGrid.Rows[0].Cells["SUM_TAX"].Value = (decimal.Parse(TotalSumGrid.Rows[0].Cells["SUM_TOTAL_MONEY"].Value.ToString()) - decimal.Parse(TotalSumGrid.Rows[0].Cells["SUM_OUT_MONEY"].Value.ToString())).ToString("#,0.######");

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

        
       
    }
}
