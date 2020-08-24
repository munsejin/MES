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

namespace MES.P10_PLN
{
    public partial class frm주문서등록 : Form
    {
        private wnGConstant wConst = new wnGConstant();
        private DataTable del_jumunGrid = new DataTable();
        private ComInfo comInfo = new ComInfo();


        public frm주문서등록()
        {
            InitializeComponent();

        }

        private void frm주문서등록_Load(object sender, EventArgs e)
        {
            //DateTime today = DateTime.Today.AddMonths(-1);
            lbl_title.Tag = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[0] + "$" + wnDm.fn_TitleName(this.Name.ToString()).Split('$')[1]; lbl_title.Text = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[2];
            start_date.Text = DateTime.Today.AddMonths(-1).ToString("yyyy-MM-dd");
            req_date.Text = DateTime.Today.AddDays(7).ToString("yyyy-MM-dd");

            txt_jumun_date.Text = DateTime.Today.ToString("yyyy-MM-dd");

            del_jumunGrid.Columns.Add("JUMUN_DATE");
            del_jumunGrid.Columns.Add("JUMUN_CD");
            del_jumunGrid.Columns.Add("SEQ");

            ComInfo.gridHeaderSet(itemJumunGrid);
            ComInfo.gridHeaderSet(JumunGrid);


            jumun_list();
        }


        //private void dataGridView1_AllowUserToAddRowsChanged(object sender, EventArgs e)
        //{

        //}

        private void btnNew_Click(object sender, EventArgs e)
        {
            resetSetting();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            input_logic();
        }

        private void input_logic()
        {
            if (chk_complete_yn.Enabled == false)
            {
                MessageBox.Show("이미 납품 완료된 주문서는 수정이 불가능합니다.");
                return;
            }


            del_blank_rows();

            if (txt_cust_cd.Text == null || txt_cust_cd.Text.ToString().Equals(""))
            {
                MessageBox.Show("납품처를 입력해주십시오.");
                return;
            }

            if (itemJumunGrid.Rows.Count < 1)
            {
                MessageBox.Show("최소 하나 이상의 납품 내역을 등록하여주십시오.");
                return;
            }
            wnDm wDm = new wnDm();

            if (lbl_input_gbn.Text != "1")
            {//신규등록

                string complete_yn = "";

                if (chk_complete_yn.Checked)
                {
                    DialogResult msgOk = MessageBox.Show("납품완료 상태로 저장시 출고/매출 등록에서 주문서가 조회되지 않습니다. \n그래도 등록하시겠습니까?", "경고", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (msgOk == DialogResult.No)
                    {
                        return;
                    }
                    complete_yn = "Y";
                }
                else
                {
                    complete_yn = "N";
                }

                

                try
                {
                    int rsNum = wDm.insert_jumun(
                        txt_jumun_date.Text
                        , txt_cust_cd.Text
                        , txt_comment.Text
                        , req_date.Text
                        , complete_yn
                        , itemJumunGrid
                        );

                    if (rsNum == 0)
                    {
                        resetSetting();
                        jumun_list();
                        MessageBox.Show("성공적으로 등록하였습니다.");
                    }
                    else if (rsNum == 1)
                    {
                        MessageBox.Show("저장에 실패하였습니다");
                    }
                    else if (rsNum == 2)
                    {
                        MessageBox.Show("조건 검사 중 에러");
                    }
                    else
                        MessageBox.Show("Exception 에러");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Exception 오류");
                    Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                    msg.ShowDialog();
                }
            }
            else
            {//수정
                try
                {
                    string complete_yn = "";

                    if (chk_complete_yn.Checked)
                    {
                        DialogResult msgOk = MessageBox.Show("납품완료 상태로 저장시 출고/매출 등록에서 주문서가 조회되지 않습니다. \n그래도 수정하시겠습니까?", "경고", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (msgOk == DialogResult.No)
                        {
                            return;
                        }
                        complete_yn = "Y";
                    }
                    else
                    {
                        complete_yn = "N";
                    }


                    int rsNum = wDm.update_jumun(
                        txt_jumun_date.Text
                        , txt_jumun_cd.Text
                        , txt_cust_cd.Text
                        , txt_comment.Text
                        , req_date.Text
                        , complete_yn
                        , itemJumunGrid
                        , del_jumunGrid
                        );

                    if (rsNum == 0)
                    {
                        resetSetting();
                        jumun_list();
                        MessageBox.Show("성공적으로 수정하였습니다.");
                    }
                    else if (rsNum == 1)
                    {
                        MessageBox.Show("저장에 실패하였습니다");
                    }
                    else if (rsNum == 2)
                    {
                        MessageBox.Show("조건 검사 중 에러");
                    }
                    else
                        MessageBox.Show("Exception 에러");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Exception 오류");
                    Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                    msg.ShowDialog();

                }
            }

        }

        private void jumun_list()
        {
            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = new DataTable();

                string condition = " and A.JUMUN_DATE >= '" + start_date.Text + "' and A.JUMUN_DATE <= '" + end_date.Text + "'  ";

                if (chk_isComplete.Checked)
                {
                    condition += " and A.COMPLETE_YN = 'N'  ";
                }

                dt = wDm.select_jumun_list(condition);
                JumunGrid.Rows.Clear();
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        JumunGrid.RowCount = dt.Rows.Count;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            JumunGrid.Rows[i].Cells["JUMUN_DATE"].Value = dt.Rows[i]["JUMUN_DATE"].ToString();
                            JumunGrid.Rows[i].Cells["JUMUN_CD"].Value = dt.Rows[i]["JUMUN_CD"].ToString();
                            JumunGrid.Rows[i].Cells["COMPLETE_YN"].Value = dt.Rows[i]["COMPLETE_YN"].ToString();
                            JumunGrid.Rows[i].Cells["CUST_CD"].Value = dt.Rows[i]["CUST_CD"].ToString();
                            JumunGrid.Rows[i].Cells["CUST_NM"].Value = dt.Rows[i]["CUST_NM"].ToString();
                            JumunGrid.Rows[i].Cells["COMMENT"].Value = dt.Rows[i]["COMMENT"].ToString();
                            JumunGrid.Rows[i].Cells["RQ_DATE"].Value = dt.Rows[i]["RQ_DATE"].ToString();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("주문 리스트 로드시 에러발생 sql");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("주문 리스트 로드시 에러발생 exception ");
                Console.WriteLine(ex + "");
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                msg.ShowDialog();
            }
        }

        private void del_blank_rows()
        {
            for (int i = 0; i < itemJumunGrid.Rows.Count; i++)
            {
                if (itemJumunGrid.Rows[i].Cells["ITEM_CD"].Value == null || itemJumunGrid.Rows[i].Cells["ITEM_CD"].Value.ToString().Equals(""))
                {
                    itemJumunGrid.Rows.RemoveAt(i);
                    i = -1;
                }
            }
            Grid_Setting_ReNumber();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            jumun_del();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void btnSrch_Click(object sender, EventArgs e)
        {
            jumun_list();
        }



        private void resetSetting()
        {
            lbl_input_gbn.Text = "";
            txt_jumun_cd.Text = "";
            txt_cust_cd.Text = "";
            txt_cust_nm.Text = "";
            txt_comment.Text = "";
            chk_complete_yn.Checked = false;
            btnDelete.Enabled = false;
            chk_complete_yn.Enabled = true;
            itemJumunGrid.Rows.Clear();
            del_jumunGrid.Rows.Clear();
        }

        private void jumun_del()
        {
            ComInfo comInfo = new ComInfo();
            DialogResult msgOk = comInfo.deleteConfrim("주문서", txt_jumun_date.Text.ToString() + " - " + txt_jumun_cd.Text.ToString());

            if (msgOk == DialogResult.No)
            {
                return;
            }

            if (chk_complete_yn.Checked == true && chk_complete_yn.Enabled == false)
            {
                MessageBox.Show("이미 납품된 주문서는 삭제할 수 없습니다.");
                return;
            }

            wnDm wDm = new wnDm();
            int rsNum = wDm.deleteJumun(txt_jumun_date.Text.ToString(), txt_jumun_cd.Text.ToString());
            if (rsNum == 0)
            {
                resetSetting();

                jumun_list();

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

        private void grid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            string name = itemJumunGrid.CurrentCell.OwningColumn.Name;

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
                dt = wDm.fn_Item_List("where ITEM_NM like '%" + item_nm + "%' " + sqlcontion, txt_cust_cd.Text.ToString());

                if (dt.Rows.Count > 1)
                { //row가 2줄이 넘을 경우 팝업으로 넘어간다.

                    string sResult = wConst.call_pop_item2(grd, dt, e.RowIndex, item_nm, txt_cust_cd.Text);

                    if (sResult != "")
                    {
                    }
                    //itemPlanGridAdd();
                    itemJumunGridAdd();
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

                    itemJumunGridAdd();
                }
                else
                { //row가 없는 경우
                    MessageBox.Show("데이터가 없습니다.");
                    itemJumunGrid.Rows.RemoveAt(itemJumunGrid.SelectedRows[0].Index);
                    itemJumunGrid.CurrentCell = itemJumunGrid[2, itemJumunGrid.Rows.Count];
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
            }
        }

        private void itemJumunGridAdd()
        {
            bool flag = true;

            for (int i = 0; i < itemJumunGrid.Rows.Count; i++)
            {
                if (itemJumunGrid.Rows[i].Cells["ITEM_CD"].Value == null || itemJumunGrid.Rows[i].Cells["ITEM_CD"].Value.ToString().Equals(""))
                {
                    flag = false;
                }
            }

            if (flag)
            {
                itemJumunGrid.Rows.Add();
                itemJumunGrid.Rows[itemJumunGrid.Rows.Count - 1].Cells["TOTAL_AMT"].Value = "0";
                itemJumunGrid.Rows[itemJumunGrid.Rows.Count - 1].Cells["PRICE"].Value = "0";
                itemJumunGrid.Rows[itemJumunGrid.Rows.Count - 1].Cells["TOTAL_MONEY"].Value = "0";
            }
            Grid_Setting_ReNumber();

        }

        private void Grid_Setting_ReNumber()
        {
            for (int i = 0; i < itemJumunGrid.Rows.Count; i++)
            {
                itemJumunGrid.Rows[i].Cells["NO"].Value = i + 1;
            }
        }



        private void GridAdd()
        {
            itemJumunGrid.Rows.Add();
            itemJumunGrid.Rows[itemJumunGrid.Rows.Count - 1].Cells["TOTAL_AMT"].Value = "0";
            itemJumunGrid.Rows[itemJumunGrid.Rows.Count - 1].Cells["PRICE"].Value = "0";
            itemJumunGrid.Rows[itemJumunGrid.Rows.Count - 1].Cells["TOTAL_MONEY"].Value = "0";
            Grid_Setting_ReNumber();
        }

        private void GridMinus()
        {
            if (itemJumunGrid.CurrentCell != null)
            {
                if (lbl_input_gbn.Text == "1")
                {
                    if (itemJumunGrid.Rows[itemJumunGrid.CurrentCell.RowIndex].Cells["SEQ"].Value != null 
                        && !itemJumunGrid.Rows[itemJumunGrid.CurrentCell.RowIndex].Cells["SEQ"].Value.ToString().Equals(""))
                    {
                        del_jumunGrid.Rows.Add();
                        del_jumunGrid.Rows[del_jumunGrid.Rows.Count - 1]["JUMUN_DATE"] = txt_jumun_date.Text;
                        del_jumunGrid.Rows[del_jumunGrid.Rows.Count - 1]["JUMUN_CD"] = txt_jumun_cd.Text;
                        del_jumunGrid.Rows[del_jumunGrid.Rows.Count - 1]["SEQ"] = itemJumunGrid.Rows[itemJumunGrid.CurrentCell.RowIndex].Cells["SEQ"].Value.ToString();
                    }
                }
                itemJumunGrid.Rows.RemoveAt(itemJumunGrid.CurrentCell.RowIndex);
                Grid_Setting_ReNumber();
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
                    if (itemJumunGrid.Rows.Count == 0) itemJumunGridAdd();
                }
                frm.Dispose();
                frm = null;
            }
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
                if (itemJumunGrid.Rows.Count == 0) itemJumunGridAdd();
            }
            frm.Dispose();
            frm = null;
        }

        private void btn_plus_Click(object sender, EventArgs e)
        {
            GridAdd();
        }

        private void btn_minus_Click(object sender, EventArgs e)
        {
            GridMinus();
        }

        private void JumunGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                int i = e.RowIndex;
                try
                {
                    txt_jumun_date.Text = JumunGrid.Rows[i].Cells["JUMUN_DATE"].Value.ToString();
                    txt_jumun_cd.Text = JumunGrid.Rows[i].Cells["JUMUN_CD"].Value.ToString();
                    txt_cust_nm.Text = JumunGrid.Rows[i].Cells["CUST_NM"].Value.ToString();
                    txt_cust_cd.Text = JumunGrid.Rows[i].Cells["CUST_CD"].Value.ToString();
                    txt_comment.Text = JumunGrid.Rows[i].Cells["COMMENT"].Value.ToString();
                    req_date.Text = JumunGrid.Rows[i].Cells["RQ_DATE"].Value.ToString();
                    if (JumunGrid.Rows[i].Cells["COMPLETE_YN"].Value.ToString().Equals("Y"))
                    {
                        chk_complete_yn.Checked = true;
                        chk_complete_yn.Enabled = false;
                    }
                    else
                    {
                        chk_complete_yn.Checked = false;
                        chk_complete_yn.Enabled = true;
                    }
                    lbl_input_gbn.Text = "1";
                    btnDelete.Enabled = true;
                    del_jumunGrid.Rows.Clear();

                    jumunDetail();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("주문서 load시 오류발생");
                    Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                    msg.ShowDialog();
                }
            }
        }

        private void jumunDetail()
        {
            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = new DataTable();

                itemJumunGrid.Rows.Clear();

                dt = wDm.select_jumun_detail_list(txt_jumun_date.Text , txt_jumun_cd.Text);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        itemJumunGrid.RowCount = dt.Rows.Count;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            itemJumunGrid.Rows[i].Cells["NO"].Value = i+1;
                            itemJumunGrid.Rows[i].Cells["ITEM_CD"].Value = dt.Rows[i]["ITEM_CD"].ToString();
                            itemJumunGrid.Rows[i].Cells["ITEM_NM"].Value = dt.Rows[i]["ITEM_NM"].ToString();
                            itemJumunGrid.Rows[i].Cells["SEQ"].Value = dt.Rows[i]["SEQ"].ToString();
                            itemJumunGrid.Rows[i].Cells["SPEC"].Value = dt.Rows[i]["SPEC"].ToString();
                            itemJumunGrid.Rows[i].Cells["UNIT_CD"].Value = dt.Rows[i]["UNIT_CD"].ToString();
                            itemJumunGrid.Rows[i].Cells["UNIT_NM"].Value = dt.Rows[i]["UNIT_NM"].ToString();
                            itemJumunGrid.Rows[i].Cells["PRICE"].Value = decimal.Parse(dt.Rows[i]["PRICE"].ToString()).ToString("#,0.######");
                            itemJumunGrid.Rows[i].Cells["TOTAL_AMT"].Value = decimal.Parse(dt.Rows[i]["AMOUNT"].ToString()).ToString("#,0.######");
                            itemJumunGrid.Rows[i].Cells["TOTAL_MONEY"].Value = decimal.Parse(dt.Rows[i]["MONEY"].ToString()).ToString("#,0.######");
                        }
                    }
                    else
                    {
                        MessageBox.Show("주문 상품 리스트를 불러오는 과정에서 오류 발생(sql)");
                    }
                }
                else
                {
                    MessageBox.Show("주문 상품 리스트를 불러오는 과정에서 오류 발생(sql)");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("주문 상품 리스트를 불러오는 과정에서 오류 발생");
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                msg.ShowDialog();
            }
        }

        private void itemJumunGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >-1)
            {
                conDataGridView grd = (conDataGridView)sender;
                DataGridViewCell cell = grd[e.ColumnIndex, e.RowIndex];
                var senderGrid = (DataGridView)sender;
                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                    e.RowIndex >= 0 && senderGrid.Columns[e.ColumnIndex].Name.Equals("SRCH_BTN"))
                {


                    cell.Style.BackColor = Color.White;


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
                    dt = wDm.fn_Item_List("where ITEM_NM like '%" + item_nm + "%' " + sqlcontion, txt_cust_cd.Text.ToString());

                    if (dt.Rows.Count > 1)
                    { //row가 2줄이 넘을 경우 팝업으로 넘어간다.

                        string sResult = wConst.call_pop_item2(grd, dt, e.RowIndex, item_nm, txt_cust_cd.Text);

                        if (sResult != "")
                        {
                        }
                        //itemPlanGridAdd();
                        itemJumunGridAdd();
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

                        itemJumunGridAdd();
                    }
                    else
                    { //row가 없는 경우
                        MessageBox.Show("데이터가 없습니다.");
                        itemJumunGrid.Rows.RemoveAt(itemJumunGrid.SelectedRows[0].Index);
                        itemJumunGrid.CurrentCell = itemJumunGrid[2, itemJumunGrid.Rows.Count];
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
                    else
                    {
                        return base.ProcessCmdKey(ref msg, keyData);
                    }
                    break;
                case Keys.S:
                    // 조합키 사용 시
                    if ((keyData & Keys.Control) != 0)
                    {
                        btnSave.PerformClick();
                    }
                    else
                    {
                        return base.ProcessCmdKey(ref msg, keyData);
                    }
                    break;
                case Keys.F5:
                    // 단일키 사용시
                    btnNew.PerformClick();
                    jumun_list();
                    break;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
            return true;
        }

        private void req_date_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTimePicker dtpTemp = (DateTimePicker)sender;
                DateTime dtTemp = dtpTemp.Value;

                if (dtTemp.Date < txt_jumun_date.Value.Date)
                {
                    MessageBox.Show("납품요구일은 수주일자보다 크거나 같아야합니다.");
                    dtpTemp.Text = txt_jumun_date.Text;
                }
            }
            catch
            {

            }
        }

    }
}
