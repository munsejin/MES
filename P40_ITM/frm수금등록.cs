﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MES.CLS;


namespace MES.P40_ITM
{
    public partial class frm수금등록 : Form
    {

        bool isFirstTouch = false;
        wnGConstant wConst = new wnGConstant();
        public frm수금등록()
        {
            InitializeComponent();

        }
        bool ck = true;


        private void splitContainer2_Panel1_Resize(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbo매출처_DropDown(object sender, EventArgs e)
        {

        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        

        private void btn_cust_search_Click(object sender, EventArgs e)
        {
             Popup.pop거래처검색 frm = new Popup.pop거래처검색();

             frm.sCustGbn = "1";
             frm.sCustNm = txt_cust_nm.Text.ToString();
             frm.ShowDialog();

             if (frm.sCode != "")
             {
                 txt_cust_cd.Text = frm.sCode.Trim();
                 txt_cust_nm.Text = frm.sName.Trim();
                 txt_balance.Text = decimal.Parse(frm.sBalance.Trim().Replace(",", "")).ToString("#,0.######");
             }
         
             frm.Dispose();
             frm = null;

             try
             {
                 wnDm wDm = new wnDm();
                 DataTable dt = new DataTable();
                // dt = sc.selectSalesList(txt_cust_cd.Text.ToString());

                 
             }
             catch (Exception ex)
             {
                 MessageBox.Show("시스템 오류" + ex.ToString());
                 Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                 msg.ShowDialog();
             }



        }

        private void txt_cust_cd_TextChanged(object sender, EventArgs e)
        {
            collectGrid_Cust_Select(txt_cust_cd.Text.ToString());
        }

        private void collectGrid_Cust_Select(string txt_cust_cd)
        {
            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = new DataTable();
                dt = wDm.fn_Collect_list("where A.CUST_CD = '" + txt_cust_cd + "'   ");

                if (dt != null && dt.Rows.Count > 0)
                {
                    collectGrid.RowCount = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        collectGrid.Rows[i].Cells["NO"].Value = dt.Rows.Count - i;
                        collectGrid.Rows[i].Cells["COLLECT_DATE"].Value = dt.Rows[i]["SOO_DATE"].ToString();
                        collectGrid.Rows[i].Cells["COLLECT_CD"].Value = dt.Rows[i]["SOO_CD"].ToString();
                        collectGrid.Rows[i].Cells["SOO_GUBUN_CD"].Value = dt.Rows[i]["SOO_GUBUN"].ToString();
                        collectGrid.Rows[i].Cells["SOO_GUBUN_NM"].Value = dt.Rows[i]["SOO_GUBUN_NM"].ToString();
                        collectGrid.Rows[i].Cells["CUST_CD"].Value = dt.Rows[i]["CUST_CD"].ToString();
                        collectGrid.Rows[i].Cells["CUST_NM"].Value = dt.Rows[i]["CUST_NM"].ToString();
                        collectGrid.Rows[i].Cells["SOO_MONEY"].Value = decimal.Parse(dt.Rows[i]["SOO_MONEY"].ToString()).ToString("#,0.######");
                        collectGrid.Rows[i].Cells["DC_MONEY"].Value = decimal.Parse(dt.Rows[i]["DC_MONEY"].ToString()).ToString("#,0.######");
                        collectGrid.Rows[i].Cells["TOTAL_MONEY"].Value = decimal.Parse(dt.Rows[i]["TOTAL_MONEY"].ToString()).ToString("#,0.######");
                        collectGrid.Rows[i].Cells["COMMENT"].Value = dt.Rows[i]["COMMENT"].ToString();
                    }
                }
                else
                {
                    collectGrid.Rows.Clear();
                }

                txt_soo.ReadOnly = false;
                txt_dc.ReadOnly = false;
                txt_total_money.ReadOnly = false;


            }
            catch (Exception ex)
            {
                MessageBox.Show("시스템 오류" + ex.ToString());
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                msg.ShowDialog();
            }
        }

        private void grd_sales_detail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txt_cust_cd.Text.ToString().Equals(""))
            {
                MessageBox.Show("거래처를 선택하시기 바랍니다.");
                return;
            }



            if (ck)
            {
                wnDm wDm = new wnDm();

                int rsNum = wDm.insertSoo(
                        dtp_date_soo.Text.ToString()
                        , txt_cust_cd.Text.ToString()
                        , txt_soo.Text.ToString()
                        , txt_dc.Text.ToString()
                        , txt_comm.Text.ToString()
                        , txt_total_money.Text.ToString()
                        , cmb_gubun.SelectedValue.ToString()
                        );

                if (rsNum == 0)
                {
                    //resetSetting();

                    StringBuilder sb = new StringBuilder();
                    //sb.AppendLine("and A.ORDER_DATE >= '" + dtp_start.Text.ToString() + "' and  A.ORDER_DATE <= '" + dtp_end.Text.ToString() + "'");

                    //string str = queryStr(sb.ToString());
                    //order_list(grd_order, str);
                    reSetting();
                    MessageBox.Show("성공적으로 등록하였습니다.");
                }
                else if (rsNum == 1)
                    MessageBox.Show("저장에 실패하였습니다");
                else
                    MessageBox.Show("Exception 에러");
            }
            else
            {
                wnDm wDm = new wnDm();
                int rsNum = wDm.updateSoo(
                        dtp_date_soo.Text.ToString()
                        , lbl_cd.Text.ToString()
                        , txt_cust_cd.Text.ToString()
                        , txt_soo.Text.ToString()
                        , txt_dc.Text.ToString()
                        , txt_comm.Text.ToString()
                        , txt_balance.Text.ToString()
                        , txt_total_money.Text.ToString()
                        , cmb_gubun.SelectedValue.ToString()
                        , txt_total_amt_Temp.Text.ToString()
                        , txt_soo_temp.Text.ToString()
                        , txt_dc_temp.Text.ToString()
                        );
                if (rsNum == 0)
                {
                    reSetting();
                    MessageBox.Show("성공적으로 수정하였습니다.");
                }
                else if (rsNum == 1)
                    MessageBox.Show("저장에 실패하였습니다");
                else
                    MessageBox.Show("Exception 에러");
            }
            grd_soo.Rows.Clear();
            grdSooLoad();
        }

        private void frm수금등록_Load(object sender, EventArgs e)
        {
            lbl_title.Tag = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[0] + "$" + wnDm.fn_TitleName(this.Name.ToString()).Split('$')[1]; lbl_title.Text = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[2];

            string sqlQuery = "";
            ComInfo comInfo = new ComInfo();
            //납품처리방법
            cmb_gubun.ValueMember = "코드";
            cmb_gubun.DisplayMember = "명칭";
            
            sqlQuery = cmb_gubun.ValueMember = "코드";
            cmb_gubun.DisplayMember = "명칭";
            sqlQuery = comInfo.querySooGubun();
            wConst.ComboBox_Read_NoBlank(cmb_gubun, sqlQuery);


            grdSooLoad();

            ComInfo.gridHeaderSet(grd_soo);
            ComInfo.gridHeaderSet(collectGrid);
        }

        private void grdSooLoad()
        {
            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = new DataTable();
                dt = wDm.selectSooList(txt_cust_cd.Text.ToString());

                if (dt != null && dt.Rows.Count > 0)
                {
                    grd_soo.RowCount = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        grd_soo.Rows[i].Cells["SOO_DATE"].Value = dt.Rows[i]["SOO_DATE"].ToString();
                        grd_soo.Rows[i].Cells["SOO_CD"].Value = dt.Rows[i]["SOO_CD"].ToString();
                        grd_soo.Rows[i].Cells["CUST_NM_SOO"].Value = dt.Rows[i]["CUST_NM"].ToString();
                        grd_soo.Rows[i].Cells["CUST_CD_SOO"].Value = dt.Rows[i]["CUST_CD"].ToString();
                        grd_soo.Rows[i].Cells["TOTAL_MONEY_SOO"].Value = (decimal.Parse(dt.Rows[i]["TOTAL_MONEY"].ToString())).ToString("#,0.######");
                        grd_soo.Rows[i].Cells["SOO_GUBUN"].Value = dt.Rows[i]["SOO_GUBUN"].ToString();
                        grd_soo.Rows[i].Cells["BALANCE"].Value = dt.Rows[i]["BALANCE"].ToString();
                    }
                }
                else
                {
                    grd_soo.Rows.Clear();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("시스템 오류" + ex.ToString());
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                msg.ShowDialog();
            }
        }

        private void grd_soo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return ;
            }

            //reSetting();
            
            try
            {
                txt_balance.Text = decimal.Parse(grd_soo.Rows[e.RowIndex].Cells["BALANCE"].Value.ToString()).ToString("#,0.######");
                txt_cust_cd.Text = grd_soo.Rows[e.RowIndex].Cells["CUST_CD_SOO"].Value.ToString();
                wnDm wDm = new wnDm();
                collectGrid_Cust_Select(grd_soo.Rows[e.RowIndex].Cells["CUST_CD_SOO"].Value.ToString());

                for (int i = 0; i < collectGrid.Rows.Count; i++)
                {
                    if(collectGrid.Rows[i].Cells["COLLECT_DATE"].Value.ToString().Equals(grd_soo.Rows[e.RowIndex].Cells["SOO_DATE"].Value.ToString())
                        && collectGrid.Rows[i].Cells["COLLECT_CD"].Value.ToString().Equals(grd_soo.Rows[e.RowIndex].Cells["SOO_CD"].Value.ToString()))
                    {
                        collectGrid_SelectRow(i);
                        collectGrid.Rows[i].Selected = true;
                        return;
                    }
                }

                

            }
            catch (Exception ex)
            {
                MessageBox.Show("시스템 오류" + ex.ToString());
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                msg.ShowDialog();
            }
        }

        private void reSetting()
        {
            dtp_start.Text = DateTime.Today.AddMonths(-1).ToString("yyyy-MM-dd");
            dtp_end.Text = DateTime.Today.ToString("yyyy-MM-dd");
            dtp_date_soo.Text = DateTime.Today.ToString("yyyy-MM-dd");
            lbl_cd.Text = null;
            cmb_gubun.SelectedIndex = 0;
            txt_cust_nm.Text = "";
            txt_balance.Text = "0";
            txt_total_money.Text = "0";
            txt_dc.Text = "0";
            txt_soo.Text = "0";
            txt_comm.Text = "";
            txt_cust_cd.Text = "";
            grd_soo.Rows.Clear();
            collectGrid.Rows.Clear();
            grdSooLoad();
            txt_soo.ReadOnly = true;
            txt_dc.ReadOnly = true;
            txt_total_money.ReadOnly = true;
            btnDelete.Enabled = false;
            ck = true;

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            reSetting();
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();

        }

        private void cal_Total_money()
        {
            if (isFirstTouch)
            {
                isFirstTouch = false;
                return;
            }

            if (txt_soo.Text.ToString().Equals("-") || txt_dc.Text.ToString().Equals("-"))
            {
                return;
            }
            try
            {
                txt_total_money.Text = (decimal.Parse(txt_soo.Text.ToString()) + decimal.Parse(txt_dc.Text.ToString())).ToString("#,0.######");
            }
            catch (OverflowException ex)
            {
                MessageBox.Show("숫자 허용범위가 초과되었습니다.");
                if (txt_soo.Text == null || txt_soo.Text.ToString().Equals(""))
                {
                    txt_soo.Text = "0";
                }
                if (txt_dc.Text == null || txt_dc.Text.ToString().Equals(""))
                {
                    txt_dc.Text = "0";
                }
            }
            catch (Exception ex)
            {
                if (txt_soo.Text == null || txt_soo.Text.ToString().Equals(""))
                {
                    txt_soo.Text = "0";
                }
                if (txt_dc.Text == null || txt_dc.Text.ToString().Equals(""))
                {
                    txt_dc.Text = "0";
                }
            }
        }

        private void txt_soo_dc_TextChanged(object sender, EventArgs e)
        {
            cal_Total_money();
        }

        private void collectGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            collectGrid_SelectRow(e.RowIndex);
        }

        private void collectGrid_SelectRow(int e_RowIndex)
        {
            txt_cust_cd.Text = collectGrid.Rows[e_RowIndex].Cells["CUST_CD"].Value.ToString();
            txt_cust_nm.Text = collectGrid.Rows[e_RowIndex].Cells["CUST_NM"].Value.ToString();
            txt_soo.Text = collectGrid.Rows[e_RowIndex].Cells["SOO_MONEY"].Value.ToString();
            txt_soo_temp.Text = collectGrid.Rows[e_RowIndex].Cells["SOO_MONEY"].Value.ToString();
            txt_dc.Text = collectGrid.Rows[e_RowIndex].Cells["DC_MONEY"].Value.ToString();
            txt_dc_temp.Text = collectGrid.Rows[e_RowIndex].Cells["DC_MONEY"].Value.ToString();
            //txt_total_money.Text = collectGrid.Rows[e_RowIndex].Cells["TOTAL_MONEY"].Value.ToString();
            txt_total_amt_Temp.Text = collectGrid.Rows[e_RowIndex].Cells["TOTAL_MONEY"].Value.ToString().Replace(",", "");
            txt_comm.Text = collectGrid.Rows[e_RowIndex].Cells["COMMENT"].Value.ToString();
            cmb_gubun.SelectedValue = collectGrid.Rows[e_RowIndex].Cells["SOO_GUBUN_CD"].Value.ToString();
            dtp_date_soo.Text = collectGrid.Rows[e_RowIndex].Cells["COLLECT_DATE"].Value.ToString();
            lbl_cd.Text = collectGrid.Rows[e_RowIndex].Cells["COLLECT_CD"].Value.ToString();

            txt_soo.ReadOnly = false;
            txt_dc.ReadOnly = false;
            btnDelete.Enabled = true;

            ck = false;
        }



        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!ck)
            {
                wnDm wDm = new wnDm();
                int rsNum = wDm.deleteSoo(
                        dtp_date_soo.Text.ToString()
                        , lbl_cd.Text.ToString()
                        , txt_cust_cd.Text.ToString()
                        , txt_total_amt_Temp.Text.ToString()
                        , txt_soo_temp.Text.ToString()
                        , txt_dc_temp.Text.ToString()
                        );
                if (rsNum == 0)
                {
                    reSetting();
                    MessageBox.Show("성공적으로 삭제하였습니다.");
                }
                else if (rsNum == 1)
                    MessageBox.Show("삭제에 실패하였습니다");
                else
                    MessageBox.Show("Exception 에러");
            }
            grd_soo.Rows.Clear();
            grdSooLoad();

            reSetting();
        }

        private void pnlRightSideView_Paint(object sender, PaintEventArgs e)
        {

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


        private void txt_soo_KeyDown(object sender, KeyEventArgs e)
        {
            if (txt_soo.Text != null && txt_soo.Text.ToString().Equals("0"))
            {
                isFirstTouch = true;
                txt_soo.Text = "";
            }

        }

        private void txt_dc_KeyDown(object sender, KeyEventArgs e)
        {
            if (txt_dc.Text != null && txt_dc.Text.ToString().Equals("0"))
            {
                isFirstTouch = true;
                txt_dc.Text = "";
            }
        }

    }
}
