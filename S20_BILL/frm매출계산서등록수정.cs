using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MES.CLS;

namespace MES.S20_BILL
{
    public partial class frm매출계산서등록수정 : Form
    {

        private wnGConstant wConst = new wnGConstant();
        private DataTable del_dt = new DataTable();
        private bool isDetailChange = false;


        public frm매출계산서등록수정()
        {
            InitializeComponent();
        }

        private void frm매출계산서등록수정_Load(object sender, EventArgs e)
        {
            lbl_title.Tag = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[0] + "$" + wnDm.fn_TitleName(this.Name.ToString()).Split('$')[1]; lbl_title.Text = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[2];

            txt_cust_start.Text = DateTime.Today.ToString("yyyy-MM-dd").Substring(0, 8) + "01";
            txt_bill_start.Text = DateTime.Today.ToString("yyyy-MM-dd").Substring(0, 8) + "01";

            init_Combobox();

            Select_BillListGrid();
            ResetSetting();

            ComInfo.gridHeaderSet(BillGrid);




            del_dt.Columns.Add("BILL_DATE");
            del_dt.Columns.Add("BILL_CD");
            del_dt.Columns.Add("BILL_SEQ");

        }

        private void ResetSetting()
        {
            BillGrid.Rows.Clear();
            BillGrid.Rows.Add();
            BillGrid.Rows[BillGrid.Rows.Count - 1].Cells["NO"].Value = BillGrid.Rows.Count;
            txt_bill_date.Enabled = true;
            txt_cust_nm.Enabled = true;
            btn_cust_srch.Enabled = true;
            rBtn_vat_Y.Enabled = true;
            rBtn_vat_N.Enabled = true;
            cmb_tax_gubun.Enabled = true;
            cmb_input_gubun.Enabled = true;
            cmb_auto_cal_gubun.Enabled = true;
            cmb_staff.Enabled = false;
            btn_plus.Enabled = true;
            btn_minus.Enabled = true;
            btnDelete.Enabled = false;

            btn_srch_sale_or_soo.Visible = true;

            rBtn_vat_Y.Checked = true;
            txt_bill_date.Text = DateTime.Now.ToString("yyyy-MM-dd");
            txt_cust_nm.Text = "";
            lbl_cust_nm.Text = "";
            txt_cust_cd.Text = "";
            lbl_bill_cd.Text = "";
            lbl_staff.Text = "";
            lbl_intime.Text = "";
            txt_flagship.Text = "";
            txt_supply_money.Text = "0";
            txt_tax_money.Text = "0";
            txt_total_money.Text = "0";
            lbl_sales_total_money.Text = "";
            txt_input_gubun.Text = "";
            cmb_tax_gubun.SelectedIndex = 0;
            cmb_input_gubun.SelectedIndex = 0;
            cmb_auto_cal_gubun.SelectedIndex = 0;
            cmb_staff.SelectedIndex = 0;

            del_dt.Rows.Clear();


        }

        private void init_Combobox()
        {
            ComInfo comInfo = new ComInfo();
            string sqlQuery = "";


            cmb_staff.ValueMember = "코드";
            cmb_staff.DisplayMember = "명칭";
            cmb_bill_staff.ValueMember = "코드";
            cmb_bill_staff.DisplayMember = "명칭";
            sqlQuery = comInfo.queryStaff();
            wConst.ComboBox_Read_Blank(cmb_staff, sqlQuery);
            wConst.ComboBox_Read_Blank(cmb_bill_staff, sqlQuery);

            cmb_tax_gubun.ValueMember = "코드";
            cmb_tax_gubun.DisplayMember = "명칭";
            sqlQuery = comInfo.queryTax();
            wConst.ComboBox_Read_NoBlank(cmb_tax_gubun, sqlQuery);


            cmb_input_gubun.ValueMember = "코드";
            cmb_input_gubun.DisplayMember = "명칭";
            sqlQuery = comInfo.query_Bill_Input_Gubun();
            wConst.ComboBox_Read_NoBlank(cmb_input_gubun, sqlQuery);


            cmb_auto_cal_gubun.ValueMember = "코드";
            cmb_auto_cal_gubun.DisplayMember = "명칭";
            sqlQuery = comInfo.query_Bill_Cal_Gubun();
            wConst.ComboBox_Read_NoBlank(cmb_auto_cal_gubun, sqlQuery);


        }

        private void Select_BillListGrid()
        {
            try
            {
                wnDm wDm = new wnDm();
                string start_date = txt_bill_start.Text;
                string end_date = txt_bill_end.Text;
                string condition = " AND A.BILL_DATE >= '" + start_date + "' and A.BILL_DATE <= '" + end_date + "'  ";

                if (txtSrch2.Text != null && !txtSrch2.Text.ToString().Equals(""))
                {
                    condition += " AND A.CUST_CD = '" + txtSrch2.Text.ToString() + "'   ";
                }

                if (cmb_bill_staff.SelectedIndex != 0)
                {
                    condition += " AND C.STAFF_CD = '" + cmb_bill_staff.SelectedValue.ToString() + "'   ";
                }

                DataTable dt = wDm.fn_Select_Bill_List(condition);

                BillListGrid.Rows.Clear();
                if (dt != null && dt.Rows.Count > 0)
                {
                    BillListGrid.RowCount = dt.Rows.Count;
                    for (int i = 0; i < BillListGrid.Rows.Count; i++)
                    {
                        BillListGrid.Rows[i].Cells["작성일자"].Value = dt.Rows[i]["BILL_DATE"].ToString();
                        BillListGrid.Rows[i].Cells["번호"].Value = dt.Rows[i]["BILL_CD"].ToString();
                        BillListGrid.Rows[i].Cells["매출처명"].Value = dt.Rows[i]["CUST_NM"].ToString();
                        BillListGrid.Rows[i].Cells["매출처코드"].Value = dt.Rows[i]["CUST_CD"].ToString();
                        BillListGrid.Rows[i].Cells["제품수"].Value = dt.Rows[i]["CNT"].ToString();
                        BillListGrid.Rows[i].Cells["공급가액"].Value = decimal.Parse(dt.Rows[i]["ALL_SUPPLY_MONEY"].ToString()).ToString("#,0.######");
                        BillListGrid.Rows[i].Cells["부가세"].Value = decimal.Parse(dt.Rows[i]["ALL_TAX_MONEY"].ToString()).ToString("#,0.######");
                        BillListGrid.Rows[i].Cells["합계액"].Value = decimal.Parse(dt.Rows[i]["ALL_TOTAL_MONEY"].ToString()).ToString("#,0.######");
                        BillListGrid.Rows[i].Cells["카드수금계"].Value = decimal.Parse(dt.Rows[i]["CARD_SOO"].ToString()).ToString("#,0.######");
                        BillListGrid.Rows[i].Cells["발행"].Value = dt.Rows[i]["PUBLISH_YN"].ToString();
                        BillListGrid.Rows[i].Cells["등록자"].Value = dt.Rows[i]["INSTAFF_NM"].ToString();
                        BillListGrid.Rows[i].Cells["등록일시"].Value = dt.Rows[i]["INTIME"].ToString();
                        BillListGrid.Rows[i].Cells["과면세구분"].Value = dt.Rows[i]["VAT_CD"].ToString();
                        BillListGrid.Rows[i].Cells["부가세구분"].Value = dt.Rows[i]["TAX_CD"].ToString();
                        BillListGrid.Rows[i].Cells["작업구분"].Value = dt.Rows[i]["INPUT_GUBUN"].ToString();
                        BillListGrid.Rows[i].Cells["계산구분"].Value = dt.Rows[i]["CAL_AUTO"].ToString();
                        BillListGrid.Rows[i].Cells["이관여부"].Value = dt.Rows[i]["ESCALATION_YN"].ToString();
                        BillListGrid.Rows[i].Cells["출력품목"].Value = dt.Rows[i]["PRINT_PRODUCT"].ToString();
                        BillListGrid.Rows[i].Cells["담당사원"].Value = dt.Rows[i]["STAFF_CD"].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception 오류");
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                msg.ShowDialog();
            }
        }

        #region button logic

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            lblMsg.Visible = true;
            Application.DoEvents();
            input_cust();
            //in_grid_logic();
            lblMsg.Visible = false;

        }




        #endregion button logic


        private void in_grid_logic()
        {





        }



        private void grdCellSetting()
        {
            ComInfo comInfo = new ComInfo();
            comInfo.grdCellSetting2(BillGrid);
        }

        private void btn출력_Click(object sender, EventArgs e)
        {

        }

        private void BillListGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            isDetailChange = true;
            if (e.RowIndex > -1)
            {
                btnDelete.Enabled = true;
                BillListGrid_Cell_DoubleClick(e);
                BillListGrid_Cell_DoubleClick(e);
                input_detail();
                input_cust();
            }

        }

        private void BillListGrid_Cell_DoubleClick(DataGridViewCellEventArgs e)
        {
            del_dt.Rows.Clear();
            cmb_tax_gubun.SelectedValue = BillListGrid.Rows[e.RowIndex].Cells["부가세구분"].Value.ToString();
            cmb_input_gubun.SelectedValue = BillListGrid.Rows[e.RowIndex].Cells["작업구분"].Value.ToString();
            cmb_auto_cal_gubun.SelectedValue = BillListGrid.Rows[e.RowIndex].Cells["계산구분"].Value.ToString();
            cmb_staff.SelectedValue = BillListGrid.Rows[e.RowIndex].Cells["담당사원"].Value.ToString();
            txt_escalation_yn.Text = BillListGrid.Rows[e.RowIndex].Cells["이관여부"].Value.ToString();
            txt_flagship.Text = BillListGrid.Rows[e.RowIndex].Cells["출력품목"].Value.ToString();
            txt_input_gubun.Text = "1";
            txt_bill_date.Text = BillListGrid.Rows[e.RowIndex].Cells["작성일자"].Value.ToString();
            lbl_bill_cd.Text = BillListGrid.Rows[e.RowIndex].Cells["번호"].Value.ToString();
            txt_cust_nm.Text = BillListGrid.Rows[e.RowIndex].Cells["매출처명"].Value.ToString();
            lbl_cust_nm.Text = BillListGrid.Rows[e.RowIndex].Cells["매출처명"].Value.ToString();
            txt_cust_cd.Text = BillListGrid.Rows[e.RowIndex].Cells["매출처코드"].Value.ToString();
            txt_supply_money.Text = BillListGrid.Rows[e.RowIndex].Cells["공급가액"].Value.ToString();
            txt_tax_money.Text = BillListGrid.Rows[e.RowIndex].Cells["부가세"].Value.ToString();
            txt_total_money.Text = BillListGrid.Rows[e.RowIndex].Cells["합계액"].Value.ToString();
            //BillListGrid.Rows[e.RowIndex].Cells["카드수금계"].Value.ToString();
            txt_publish_yn.Text = BillListGrid.Rows[e.RowIndex].Cells["발행"].Value.ToString();
            lbl_staff.Text = BillListGrid.Rows[e.RowIndex].Cells["등록자"].Value.ToString();
            lbl_intime.Text = BillListGrid.Rows[e.RowIndex].Cells["등록일시"].Value.ToString();
            if (BillListGrid.Rows[e.RowIndex].Cells["과면세구분"].Value.ToString().Equals("1"))
            {
                rBtn_vat_Y.Checked = true;
                rBtn_vat_N.Checked = false;
            }
            else
            {
                rBtn_vat_Y.Checked = false;
                rBtn_vat_N.Checked = true;
            }


            txt_bill_date.Enabled = false;

            if (txt_escalation_yn.Text != null && txt_escalation_yn.Text.Equals("Y"))
            {
                txt_cust_nm.Enabled = false;
                btn_cust_srch.Enabled = false;
                rBtn_vat_Y.Enabled = false;
                rBtn_vat_N.Enabled = false;
                cmb_tax_gubun.Enabled = false;
                cmb_input_gubun.Enabled = false;
                cmb_auto_cal_gubun.Enabled = false;
                cmb_staff.Enabled = false;
                btn_plus.Enabled = false;
                btn_minus.Enabled = false;
                btn_srch_sale_or_soo.Visible = false;
            }
            else
            {
                txt_cust_nm.Enabled = false;
                btn_cust_srch.Enabled = false;
                rBtn_vat_Y.Enabled = true;
                rBtn_vat_N.Enabled = true;
                cmb_tax_gubun.Enabled = true;
                cmb_input_gubun.Enabled = true;
                cmb_auto_cal_gubun.Enabled = true;
                cmb_staff.Enabled = true;
                btn_plus.Enabled = true;
                btn_minus.Enabled = true;
                btn_srch_sale_or_soo.Visible = true;
            }
        }

        private void input_cust()
        {
            try
            {
                wnDm wDm = new wnDm();
                string start_date = txt_cust_start.Text;
                string end_date = txt_cust_end.Text;
                string condition = " AND A.CUST_CD = '" + txt_cust_cd.Text + "' AND A.BILL_DATE >= '" + start_date + "' AND A.BILL_DATE <= '" + end_date + "'  ";
                DataTable dt = wDm.fn_Select_Bill_List(condition);
                CustDetailGrid.Rows.Clear();
                if (dt != null && dt.Rows.Count > 0)
                {
                    CustDetailGrid.RowCount = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        CustDetailGrid.Rows[i].Cells["작성일자2"].Value = dt.Rows[i]["BILL_DATE"].ToString();
                        CustDetailGrid.Rows[i].Cells["번호2"].Value = dt.Rows[i]["BILL_CD"].ToString();
                        CustDetailGrid.Rows[i].Cells["매출처명2"].Value = dt.Rows[i]["CUST_NM"].ToString();
                        CustDetailGrid.Rows[i].Cells["매출처코드2"].Value = dt.Rows[i]["CUST_CD"].ToString();
                        CustDetailGrid.Rows[i].Cells["제품수2"].Value = dt.Rows[i]["CNT"].ToString();
                        CustDetailGrid.Rows[i].Cells["공급가액2"].Value = decimal.Parse(dt.Rows[i]["ALL_SUPPLY_MONEY"].ToString()).ToString("#,0.######");
                        CustDetailGrid.Rows[i].Cells["부가세2"].Value = decimal.Parse(dt.Rows[i]["ALL_TAX_MONEY"].ToString()).ToString("#,0.######");
                        CustDetailGrid.Rows[i].Cells["확정금액2"].Value = decimal.Parse(dt.Rows[i]["ALL_TOTAL_MONEY"].ToString()).ToString("#,0.######");
                        CustDetailGrid.Rows[i].Cells["합계액2"].Value = decimal.Parse(dt.Rows[i]["ALL_TOTAL_MONEY"].ToString()).ToString("#,0.######");
                        CustDetailGrid.Rows[i].Cells["카드수금계2"].Value = decimal.Parse(dt.Rows[i]["CARD_SOO"].ToString()).ToString("#,0.######");
                        CustDetailGrid.Rows[i].Cells["발행2"].Value = dt.Rows[i]["PUBLISH_YN"].ToString();
                        CustDetailGrid.Rows[i].Cells["등록자2"].Value = dt.Rows[i]["INSTAFF_NM"].ToString();
                        CustDetailGrid.Rows[i].Cells["등록일시2"].Value = dt.Rows[i]["INTIME"].ToString();
                        CustDetailGrid.Rows[i].Cells["과면세구분2"].Value = dt.Rows[i]["VAT_CD"].ToString();
                        CustDetailGrid.Rows[i].Cells["부가세구분2"].Value = dt.Rows[i]["TAX_CD"].ToString();
                        CustDetailGrid.Rows[i].Cells["작업구분2"].Value = dt.Rows[i]["INPUT_GUBUN"].ToString();
                        CustDetailGrid.Rows[i].Cells["계산구분2"].Value = dt.Rows[i]["CAL_AUTO"].ToString();
                        CustDetailGrid.Rows[i].Cells["이관여부2"].Value = dt.Rows[i]["ESCALATION_YN"].ToString();
                        CustDetailGrid.Rows[i].Cells["출력품목2"].Value = dt.Rows[i]["PRINT_PRODUCT"].ToString();
                        CustDetailGrid.Rows[i].Cells["담당사원2"].Value = dt.Rows[i]["STAFF_CD"].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception 오류");
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                msg.ShowDialog();
            }
        }

        private void input_detail()
        {
            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = new DataTable();
                string condition = " WHERE A.BILL_DATE = '" + txt_bill_date.Text + "'  AND A.BILL_CD = '" + lbl_bill_cd.Text + "'  ";
                dt = wDm.fn_Select_Bill_Detail_List(condition);

                BillGrid.Rows.Clear();
                if (dt != null && dt.Rows.Count > 0)
                {
                    BillGrid.RowCount = dt.Rows.Count;

                    decimal sumMoney = 0;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        BillGrid.Rows[i].Cells["NO"].Value = i + 1;
                        BillGrid.Rows[i].Cells["상품"].Value = dt.Rows[i]["PRODUCT_NM"].ToString();
                        BillGrid.Rows[i].Cells["규격"].Value = dt.Rows[i]["SPEC"].ToString();
                        BillGrid.Rows[i].Cells["상품코드"].Value = dt.Rows[i]["PRODUCT_CD"].ToString();
                        BillGrid.Rows[i].Cells["총수량"].Value = decimal.Parse(dt.Rows[i]["TOTAL_AMT"].ToString()).ToString("#,0.######");
                        BillGrid.Rows[i].Cells["단가"].Value = decimal.Parse(dt.Rows[i]["TOTAL_PRICE"].ToString()).ToString("#,0.######");
                        BillGrid.Rows[i].Cells["공급가"].Value = (decimal.Parse(dt.Rows[i]["TOTAL_PRICE"].ToString()) * decimal.Parse(dt.Rows[i]["TOTAL_AMT"].ToString())).ToString("#,0.######");
                        BillGrid.Rows[i].Cells["금액"].Value = decimal.Parse(dt.Rows[i]["TOTAL_MONEY"].ToString()).ToString("#,0.######");
                        BillGrid.Rows[i].Cells["과세구분"].Value = dt.Rows[i]["VAT_CD"].ToString();
                        sumMoney += decimal.Parse(dt.Rows[i]["TOTAL_MONEY"].ToString());
                        BillGrid.Rows[i].Cells["SALES_DATE"].Value = dt.Rows[i]["SALES_DATE"].ToString();
                        BillGrid.Rows[i].Cells["SALES_CD"].Value = dt.Rows[i]["SALES_CD"].ToString();
                        BillGrid.Rows[i].Cells["SALES_SEQ"].Value = dt.Rows[i]["SALES_SEQ"].ToString();
                        BillGrid.Rows[i].Cells["SOO_DATE"].Value = dt.Rows[i]["SOO_DATE"].ToString();
                        BillGrid.Rows[i].Cells["SOO_CD"].Value = dt.Rows[i]["SOO_CD"].ToString();
                        BillGrid.Rows[i].Cells["SEQ"].Value = dt.Rows[i]["BILL_SEQ"].ToString();
                    }
                    lbl_sales_total_money.Text = sumMoney.ToString("#,0.######");
                }
                else
                {
                    MessageBox.Show("데이터베이스 오류");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception 오류");
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                msg.ShowDialog();
                return;
            }





        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ResetSetting();
        }

        private void CustDetailGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            isDetailChange = true;

            if (e.RowIndex > -1)
            {
                btnDelete.Enabled = true;
                CustDetailGrid_Cell_DoubleClick(e);
                CustDetailGrid_Cell_DoubleClick(e);
                input_detail();
            }
        }

        private void CustDetailGrid_Cell_DoubleClick(DataGridViewCellEventArgs e)
        {
            cmb_tax_gubun.SelectedValue = CustDetailGrid.Rows[e.RowIndex].Cells["부가세구분2"].Value.ToString();
            cmb_input_gubun.SelectedValue = CustDetailGrid.Rows[e.RowIndex].Cells["작업구분2"].Value.ToString();
            cmb_auto_cal_gubun.SelectedValue = CustDetailGrid.Rows[e.RowIndex].Cells["계산구분2"].Value.ToString();
            cmb_staff.SelectedValue = CustDetailGrid.Rows[e.RowIndex].Cells["담당사원2"].Value.ToString();
            txt_input_gubun.Text = "1";
            txt_bill_date.Text = CustDetailGrid.Rows[e.RowIndex].Cells["작성일자2"].Value.ToString();
            lbl_bill_cd.Text = CustDetailGrid.Rows[e.RowIndex].Cells["번호2"].Value.ToString();
            txt_cust_nm.Text = CustDetailGrid.Rows[e.RowIndex].Cells["매출처명2"].Value.ToString();
            lbl_cust_nm.Text = CustDetailGrid.Rows[e.RowIndex].Cells["매출처명2"].Value.ToString();
            txt_cust_cd.Text = CustDetailGrid.Rows[e.RowIndex].Cells["매출처코드2"].Value.ToString();
            txt_supply_money.Text = CustDetailGrid.Rows[e.RowIndex].Cells["공급가액2"].Value.ToString();
            txt_tax_money.Text = CustDetailGrid.Rows[e.RowIndex].Cells["부가세2"].Value.ToString();
            txt_total_money.Text = CustDetailGrid.Rows[e.RowIndex].Cells["합계액2"].Value.ToString();
            //CustDetailGrid.Rows[e.RowIndex].Cells["카드수금계"].Value.ToString();
            txt_publish_yn.Text = CustDetailGrid.Rows[e.RowIndex].Cells["발행2"].Value.ToString();
            lbl_staff.Text = CustDetailGrid.Rows[e.RowIndex].Cells["등록자2"].Value.ToString();
            lbl_intime.Text = CustDetailGrid.Rows[e.RowIndex].Cells["등록일시2"].Value.ToString();
            if (CustDetailGrid.Rows[e.RowIndex].Cells["과면세구분2"].Value.ToString().Equals("1"))
            {
                rBtn_vat_Y.Checked = true;
                rBtn_vat_N.Checked = false;
            }
            else
            {
                rBtn_vat_Y.Checked = false;
                rBtn_vat_N.Checked = true;
            }

            txt_escalation_yn.Text = CustDetailGrid.Rows[e.RowIndex].Cells["이관여부2"].Value.ToString();
            txt_flagship.Text = CustDetailGrid.Rows[e.RowIndex].Cells["출력품목2"].Value.ToString();

            txt_bill_date.Enabled = false;

            if (txt_escalation_yn.Text != null && txt_escalation_yn.Text.Equals("Y"))
            {
                txt_cust_nm.Enabled = false;
                btn_cust_srch.Enabled = false;
                rBtn_vat_Y.Enabled = false;
                rBtn_vat_N.Enabled = false;
                cmb_tax_gubun.Enabled = false;
                cmb_input_gubun.Enabled = false;
                cmb_auto_cal_gubun.Enabled = false;
                cmb_staff.Enabled = false;
                btn_plus.Enabled = false;
                btn_minus.Enabled = false;
                btn_srch_sale_or_soo.Visible = false;
            }
        }

        private void txt_total_money_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txt_total_money != null && !txt_total_money.Text.Equals(""))
                {
                    if (cmb_tax_gubun.SelectedValue != null)
                    {
                        if (!cmb_tax_gubun.SelectedValue.ToString().Equals("2") && rBtn_vat_Y.Checked)
                        {
                            decimal oneDotone = decimal.Parse("1.1");
                            txt_total_money.Text = decimal.Parse(txt_total_money.Text.ToString().Replace(",", "")).ToString("#,0.######");
                            txt_supply_money.Text = decimal.Round(decimal.Parse(txt_total_money.Text.ToString().Replace(",", "")) / oneDotone).ToString("#,0.######");
                            txt_tax_money.Text = (decimal.Parse(txt_total_money.Text.ToString().Replace(",", "")) - decimal.Round(decimal.Parse(txt_total_money.Text.ToString().Replace(",", "")) / oneDotone)).ToString("#,0.######");
                        }
                        else
                        {
                            txt_tax_money.Text = "0";
                            txt_total_money.Text = decimal.Parse(txt_total_money.Text.ToString().Replace(",", "")).ToString("#,0.######");
                            txt_supply_money.Text = txt_total_money.Text;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void txt_supply_money_Leave(object sender, EventArgs e)
        {
            if (txt_supply_money.Text == null || txt_supply_money.Text.ToString().Equals("") || txt_tax_money.Text == null || txt_tax_money.Text.ToString().Equals(""))
            {
                return;
            }
            else
            {
                txt_supply_money.Text = decimal.Parse(txt_supply_money.Text.ToString()).ToString("#,0.######");
                txt_total_money.Text = (decimal.Parse(txt_supply_money.Text.ToString()) + decimal.Parse(txt_tax_money.Text.ToString())).ToString("#,0.######");
                lbl_staff.Focus();

            }
        }


        private void txt_tax_money_Leave(object sender, EventArgs e)
        {
            if (txt_supply_money.Text == null || txt_supply_money.Text.ToString().Equals("") || txt_tax_money.Text == null || txt_tax_money.Text.ToString().Equals(""))
            {
                return;
            }
            else
            {
                txt_tax_money.Text = decimal.Parse(txt_tax_money.Text.ToString()).ToString("#,0.######");
                txt_total_money.Text = (decimal.Parse(txt_supply_money.Text.ToString()) + decimal.Parse(txt_tax_money.Text.ToString())).ToString("#,0.######");
                lbl_staff.Focus();
            }
        }

        private void btn_plus_Click(object sender, EventArgs e)
        {
            BillGrid.Rows.Add();
            BillGrid.Rows[BillGrid.Rows.Count - 1].Cells["NO"].Value = BillGrid.Rows.Count;
            if (cmb_input_gubun.SelectedValue.ToString().Equals("2"))
            {
                BillGrid.Rows[BillGrid.Rows.Count - 1].Cells["품목구분"].Value = "직접";
                if (txt_flagship.Text != null && !txt_flagship.Text.ToString().Equals(""))
                {
                    BillGrid.Rows[BillGrid.Rows.Count - 1].Cells["상품"].Value = txt_flagship.Text;
                    BillGrid.Rows[BillGrid.Rows.Count - 1].Cells["상품코드"].Value = txt_flagship.Text;
                }
            }
        }

        private void btn_minus_Click(object sender, EventArgs e)
        {
            if (BillGrid.CurrentCell == null) return;

            if (BillGrid.Rows[BillGrid.CurrentCell.RowIndex].Cells["SEQ"].Value != null && !BillGrid.Rows[BillGrid.CurrentCell.RowIndex].Cells["SEQ"].Value.ToString().Equals(""))
            {
                del_dt.Rows.Add();
                del_dt.Rows[del_dt.Rows.Count - 1]["BILL_DATE"] = txt_bill_date.Text;
                del_dt.Rows[del_dt.Rows.Count - 1]["BILL_CD"] = lbl_bill_cd.Text;
                del_dt.Rows[del_dt.Rows.Count - 1]["BILL_SEQ"] = BillGrid.Rows[BillGrid.CurrentCell.RowIndex].Cells["SEQ"].Value.ToString();
            }

            BillGrid.Rows.RemoveAt(BillGrid.CurrentCell.RowIndex);
            for (int i = 0; i < BillGrid.Rows.Count; i++)
            {
                BillGrid.Rows[i].Cells["NO"].Value = i + 1;
            }

            Cal_Money();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                wnDm wDm = new wnDm();

                if (txt_cust_cd.Text == null || txt_cust_cd.Text.ToString().Equals(""))
                {
                    MessageBox.Show("거래처를 선택해주십시오.");
                    return;
                }
                if (txt_flagship.Text == null || txt_flagship.Text.ToString().Equals(""))
                {
                    MessageBox.Show("출력품목을 입력해주십시오.");
                    return;
                }
                if (BillGrid.Rows.Count <= 0)
                {
                    MessageBox.Show("계산서 항목을 최소 1줄 이상 입력해주십시오");
                    return;
                }
                if (txt_supply_money.Text == null || txt_supply_money.Text.ToString().Equals(""))
                {
                    MessageBox.Show("공급가는 공백일 수 없습니다");
                    return;
                }
                if (txt_tax_money.Text == null || txt_tax_money.Text.ToString().Equals(""))
                {
                    MessageBox.Show("부가세는 공백일 수 없습니다");
                    return;
                }
                if (txt_total_money.Text == null || txt_total_money.Text.ToString().Equals(""))
                {
                    MessageBox.Show("확정금액은 공백일 수 없습니다");
                    return;
                }


                for (int i = 0; i < BillGrid.Rows.Count; i++)
                {
                    if (BillGrid.Rows[i].Cells["상품코드"].Value == null || BillGrid.Rows[i].Cells["상품코드"].Value.ToString().Equals("") || BillGrid.Rows[i].Cells["총수량"].Value == null || BillGrid.Rows[i].Cells["총수량"].Value.ToString().Equals(""))
                    {
                        BillGrid.Rows.RemoveAt(i);
                        i = -1;
                    }
                }

                if (BillGrid.Rows.Count <= 0)
                {
                    MessageBox.Show("계산서 항목을 최소 1줄 이상 입력해주십시오");
                    return;
                }


                if (!txt_input_gubun.Text.Equals("1"))
                {
                    string vat_cd;
                    if(rBtn_vat_Y.Checked){
                        vat_cd = "1";
                    }else{
                        vat_cd = "2";
                    }
                    string bill_date     =   txt_bill_date.Text.ToString();
                    string cust_cd       =   txt_cust_cd.Text.ToString();
                    string input_gubun   =   cmb_input_gubun.SelectedValue.ToString();
                    string tax_gubun     =   cmb_tax_gubun.SelectedValue.ToString();
                    string flagship      =   txt_flagship.Text.ToString();
                    string auto_cal      =   cmb_auto_cal_gubun.SelectedValue.ToString();
                    string supply_money  =   txt_supply_money.Text.ToString();
                    string tax_money     =   txt_tax_money.Text.ToString();
                    string total_money   =   txt_total_money.Text.ToString();
                                            

                    int rsNum = wDm.insert_Bill_Input(
                          bill_date   
                        , cust_cd     
                        , input_gubun 
                        , tax_gubun   
                        , flagship    
                        , auto_cal    
                        , supply_money
                        , tax_money   
                        , total_money 
                        , vat_cd
                        , BillGrid
                        );

                    if (rsNum == 0)
                    {
                        MessageBox.Show("성공적으로 저장하였습니다.");
                        ResetSetting();
                        Select_BillListGrid();
                        return;
                    }
                    else if (rsNum == 1)
                    {
                        MessageBox.Show("저장에 실패하였습니다");
                        return;
                    }
                    else
                    {
                        MessageBox.Show("데이터베이스 에러");
                        return;
                    }
                }
                else
                {

                    string vat_cd;
                    if (rBtn_vat_Y.Checked)
                    {
                        vat_cd = "1";
                    }
                    else
                    {
                        vat_cd = "2";
                    }
                    string bill_date = txt_bill_date.Text.ToString();
                    string bill_cd = lbl_bill_cd.Text.ToString();
                    string cust_cd = txt_cust_cd.Text.ToString();
                    string input_gubun = cmb_input_gubun.SelectedValue.ToString();
                    string tax_gubun = cmb_tax_gubun.SelectedValue.ToString();
                    string flagship = txt_flagship.Text.ToString();
                    string auto_cal = cmb_auto_cal_gubun.SelectedValue.ToString();
                    string supply_money = txt_supply_money.Text.ToString();
                    string tax_money = txt_tax_money.Text.ToString();
                    string total_money = txt_total_money.Text.ToString();


                    int rsNum = wDm.update_Bill_Input(
                          bill_date
                        , bill_cd
                        , cust_cd
                        , input_gubun
                        , tax_gubun
                        , flagship
                        , auto_cal
                        , supply_money
                        , tax_money
                        , total_money
                        , vat_cd
                        , BillGrid
                        , del_dt
                        );

                    if (rsNum == 0)
                    {
                        MessageBox.Show("성공적으로 수정하였습니다.");
                        ResetSetting();
                        Select_BillListGrid();
                        return;
                    }
                    else if (rsNum == 1)
                    {
                        MessageBox.Show("수정에 실패하였습니다");
                        return;
                    }
                    else
                    {
                        MessageBox.Show("데이터베이스 에러");
                        return;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception 에러");
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                msg.ShowDialog();
                return;
            }
        }

        private void cmb_input_gubun_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox cmbTemp = (ComboBox)sender;
            if (cmbTemp.SelectedValue != null)
            {
                if (cmbTemp.SelectedValue.ToString().Equals("1"))
                {
                    BillGrid.Columns["규격"].Visible = true;
                    btn_srch_sale_or_soo.Text = "매출찾기...";
                    BillGrid.Rows.Clear();
                    BillGrid.Rows.Add();
                    BillGrid.Rows[BillGrid.Rows.Count - 1].Cells["NO"].Value = BillGrid.Rows.Count;
                    BillGrid.Columns["상품"].HeaderText = "상품";
                }
                else
                {
                    BillGrid.Columns["규격"].Visible = false;
                    btn_srch_sale_or_soo.Text = "수금찾기...";
                    BillGrid.Rows.Clear();
                    BillGrid.Rows.Add();
                    BillGrid.Rows[BillGrid.Rows.Count - 1].Cells["NO"].Value = BillGrid.Rows.Count;
                    BillGrid.Columns["상품"].HeaderText = "품명";
                    BillGrid.Rows[BillGrid.Rows.Count - 1].Cells["품목구분"].Value = "직접";
                    if(txt_flagship.Text != null && !txt_flagship.Text.ToString().Equals(""))
                    {
                        BillGrid.Rows[BillGrid.Rows.Count - 1].Cells["상품"].Value = txt_flagship.Text;
                        BillGrid.Rows[BillGrid.Rows.Count - 1].Cells["상품코드"].Value = txt_flagship.Text;
                    }
                }
                txt_supply_money.Text = "0";
                txt_tax_money.Text = "0";
                txt_total_money.Text = "0";
            }
        }

        private void rBtn_vat_N_CheckedChanged(object sender, EventArgs e)
        {
            if (rBtn_vat_N.Checked)
            {
                cmb_tax_gubun.Visible = false;
            }
            else
            {
                cmb_tax_gubun.Visible = true;
            }
            if (txt_input_gubun.Text.Equals("1"))
            {
                for (int i = 0; i < BillGrid.Rows.Count; i++)
                {
                    if (BillGrid.Rows[i].Cells["SEQ"].Value != null && !BillGrid.Rows[i].Cells["SEQ"].Value.ToString().Equals(""))
                    {
                        del_dt.Rows.Add();
                        del_dt.Rows[del_dt.Rows.Count-1]["BILL_DATE"] = txt_bill_date.Text.ToString();
                        del_dt.Rows[del_dt.Rows.Count-1]["BILL_CD"] = lbl_bill_cd.Text.ToString();
                        del_dt.Rows[del_dt.Rows.Count-1]["BILL_SEQ"] = BillGrid.Rows[i].Cells["SEQ"].Value.ToString();
                    }
                }
            }
            BillGrid.Rows.Clear();
            BillGrid.Rows.Add();
            BillGrid.Rows[BillGrid.Rows.Count - 1].Cells["NO"].Value = BillGrid.Rows.Count;
            if (cmb_input_gubun.SelectedValue.ToString().Equals("2"))
            {
                BillGrid.Rows[BillGrid.Rows.Count - 1].Cells["품목구분"].Value = "직접";
            }
            
            Cal_Money();
        }

        private void txt_cust_nm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Popup.pop거래처검색 msg = new Popup.pop거래처검색();
                msg.sCustGbn = "1";
                msg.txtSrch.Text = txt_cust_nm.Text.ToString();
                msg.sCustNm = txt_cust_nm.Text.ToString();

                msg.ShowDialog();

                if (msg.sCode != null && !msg.sCode.Equals(""))
                {
                    txt_cust_nm.Text = msg.sName;
                    txt_cust_cd.Text = msg.sCode;
                    lbl_cust_nm.Text = msg.sName;
                    input_cust();
                    cmb_staff.SelectedValue = msg.sStaffCd;
                }
            }
        }

        private void txt_Srch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Popup.pop거래처검색 msg = new Popup.pop거래처검색();
                msg.sCustGbn = "1";
                msg.txtSrch.Text = txtSrch.Text.ToString();
                msg.sCustNm = txtSrch.Text.ToString();

                msg.ShowDialog();

                if (msg.sCode != null && !msg.sCode.Equals(""))
                {
                    txtSrch.Text = msg.sName;
                    txtSrch2.Text = msg.sCode;
                }
            }
        }

        private void chk_all_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_all.Checked)
            {
                txtSrch.Text = "";
                txtSrch2.Text = "";
                chk_all.Checked = false;
            }
        }

        private void btn_cust_srch_Click(object sender, EventArgs e)
        {
            Popup.pop거래처검색 msg = new Popup.pop거래처검색();
            msg.sCustGbn = "1";
            //msg.sCustNm = txt_srch.Text.ToString();

            msg.ShowDialog();

            if (msg.sCode != null && !msg.sCode.Equals(""))
            {
                txt_cust_nm.Text = msg.sName;
                txt_cust_cd.Text = msg.sCode;
                cmb_staff.SelectedValue = msg.sStaffCd;
                lbl_cust_nm.Text = msg.sName;
                input_cust();

            }
        }

        private void btn_bill_cust_srch_Click(object sender, EventArgs e)
        {
            Popup.pop거래처검색 msg = new Popup.pop거래처검색();
            msg.sCustGbn = "1";
            //msg.sCustNm = txt_srch.Text.ToString();

            msg.ShowDialog();

            if (msg.sCode != null && !msg.sCode.Equals(""))
            {
                txtSrch.Text = msg.sName;
                txtSrch2.Text = msg.sCode;
            }
        }

        private void btn_billGrid_Srch_Click(object sender, EventArgs e)
        {
            Select_BillListGrid();
        }





        private void BillGrid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            string name = BillGrid.CurrentCell.OwningColumn.Name;

            if (name.Equals("상품"))
            {
                e.Control.PreviewKeyDown -= BillGrid_PreviewKeyDown;
                e.Control.PreviewKeyDown += BillGrid_PreviewKeyDown;
            }
            //if (name.Equals("총수량") || name.Equals("단가") || name.Equals("금액"))
            //{
            //    e.Control.KeyPress += new KeyPressEventHandler(txtCheckNumeric_KeyPress);
            //}

        }

        private void txtCheckNumeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            //ComInfo.onlyNum2(sender, e);
        }


        private void BillGrid_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{tab}");
               
            }
        }

        private void Cal_Money()
        {
            //if (isDetailChange)
            //{
            //    isDetailChange = false;
            //    return;
            //}

            decimal vatYtotalMoney = 0;
            decimal vatNtotalMoney = 0;
            for (int i = 0; i < BillGrid.Rows.Count; i++)
            {
                if (BillGrid.Rows[i].Cells["상품코드"].Value != null && !BillGrid.Rows[i].Cells["상품코드"].Value.ToString().Equals(""))
                {

                    if (BillGrid.Rows[i].Cells["총수량"].Value == null || BillGrid.Rows[i].Cells["총수량"].Value.ToString().Equals("")) BillGrid.Rows[i].Cells["총수량"].Value = "0";
                    if (BillGrid.Rows[i].Cells["단가"].Value == null || BillGrid.Rows[i].Cells["단가"].Value.ToString().Equals("")) BillGrid.Rows[i].Cells["단가"].Value = "0";
                    if (BillGrid.Rows[i].Cells["금액"].Value == null || BillGrid.Rows[i].Cells["금액"].Value.ToString().Equals("")) BillGrid.Rows[i].Cells["금액"].Value = "0";

                    BillGrid.Rows[i].Cells["공급가"].Value = (decimal.Parse(BillGrid.Rows[i].Cells["총수량"].Value.ToString()) * decimal.Parse(BillGrid.Rows[i].Cells["단가"].Value.ToString())).ToString("#,0.######");

                    if (cmb_input_gubun.SelectedValue.ToString().Equals("2"))
                    {
                        if (rBtn_vat_N.Checked)
                        {
                            BillGrid.Rows[i].Cells["과세구분"].Value = "2";
                        }
                        else
                        {
                            BillGrid.Rows[i].Cells["과세구분"].Value = "1";
                        }
                    }

                    if (BillGrid.Rows[i].Cells["과세구분"].Value == null || BillGrid.Rows[i].Cells["과세구분"].Value.ToString().Equals("") || BillGrid.Rows[i].Cells["과세구분"].Value.ToString().Equals("2")) //면세
                    {
                        decimal outmoney = decimal.Parse(BillGrid.Rows[i].Cells["총수량"].Value.ToString()) * decimal.Parse(BillGrid.Rows[i].Cells["단가"].Value.ToString());
                        decimal tax = 0;
                        decimal totalMoney = outmoney + tax;

                        BillGrid.Rows[i].Cells["금액"].Value = totalMoney.ToString("#,0.######");

                        vatNtotalMoney += outmoney;
                    }
                    else //과세일 경우 
                    {
                        if (cmb_tax_gubun.SelectedValue.ToString().Equals("0")) // 부가세 별도
                        {
                            decimal outmoney = decimal.Parse(BillGrid.Rows[i].Cells["총수량"].Value.ToString()) * decimal.Parse(BillGrid.Rows[i].Cells["단가"].Value.ToString());
                            decimal tax = outmoney * decimal.Parse("0.1");
                            decimal totalMoney = outmoney + tax;

                            BillGrid.Rows[i].Cells["금액"].Value = totalMoney.ToString("#,0.######");

                            vatYtotalMoney += totalMoney;
                        }
                        else if (cmb_tax_gubun.SelectedValue.ToString().Equals("1")) // 부가세 포함
                        {
                            //얘
                            decimal totalMoney = decimal.Parse(BillGrid.Rows[i].Cells["총수량"].Value.ToString()) * decimal.Parse(BillGrid.Rows[i].Cells["단가"].Value.ToString());
                            decimal outmoney = totalMoney / decimal.Parse("1.1");
                            outmoney = decimal.Round(outmoney, 0);
                            decimal tax = totalMoney - outmoney;

                            BillGrid.Rows[i].Cells["금액"].Value = totalMoney.ToString("#,0.######");

                            vatYtotalMoney += totalMoney;
                        }
                        else
                        { //영세율
                            decimal outmoney = decimal.Parse(BillGrid.Rows[i].Cells["총수량"].Value.ToString()) * decimal.Parse(BillGrid.Rows[i].Cells["단가"].Value.ToString());
                            decimal tax = 0;
                            decimal totalMoney = outmoney + tax;

                            BillGrid.Rows[i].Cells["금액"].Value = totalMoney.ToString("#,0.######");

                            vatNtotalMoney += totalMoney;
                        }
                    }
                }
            }

            if (cmb_auto_cal_gubun.SelectedValue == null) return;
            decimal oneDotone = decimal.Parse("1.1");
            decimal allSupplyMoney = 0;
            decimal allTaxMoney = 0;
            decimal allTotalMoney = 0;
            allSupplyMoney = decimal.Round(vatYtotalMoney / oneDotone,0);
            allTaxMoney = vatYtotalMoney - allSupplyMoney;
            allTotalMoney = vatYtotalMoney;
            allSupplyMoney += vatNtotalMoney;
            allTotalMoney += vatNtotalMoney;

            lbl_sales_total_money.Text = allTotalMoney.ToString("#,0.######");

            if (cmb_auto_cal_gubun.SelectedValue.ToString().Equals("Y"))
            {
                txt_supply_money.Text = allSupplyMoney.ToString("#,0.######");
                txt_tax_money.Text = allTaxMoney.ToString("#,0.######");
                txt_total_money.Text = allTotalMoney.ToString("#,0.######");
            }





        }

        private void BillGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (BillGrid.Columns[e.ColumnIndex].Name.ToString().Equals("총수량") ||
                    BillGrid.Columns[e.ColumnIndex].Name.ToString().Equals("단가"))
                {
                    if (BillGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null || BillGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Equals(""))
                    {
                        BillGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "0";
                    }
                    try { decimal.Parse(BillGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()); }
                    catch (Exception ex)
                    {
                        MessageBox.Show("올바른 숫자양식으로 입력해주십시오.");
                        BillGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "0";
                    }
                    Cal_Money();
                }
                if (BillGrid.Columns[e.ColumnIndex].Name.ToString().Equals("상품") && cmb_input_gubun.SelectedValue.ToString().Equals("2"))
                {
                    BillGrid.Rows[e.RowIndex].Cells["상품코드"].Value = BillGrid.Rows[e.RowIndex].Cells["상품"].Value;
                }

                if (BillGrid.CurrentCell == null || BillGrid.CurrentCell.RowIndex < 0) return;

                if (BillGrid.Columns[BillGrid.CurrentCell.ColumnIndex].Name.ToString().Equals("상품") && cmb_input_gubun.SelectedValue.ToString().Equals("1") && BillGrid._KeyInput == "enter" )
                {
                    string item_nm = (string)BillGrid.Rows[e.RowIndex].Cells["상품"].Value;
                    wnDm wDm = new wnDm();
                    
                    lbl_bill_cd.Focus();

                    Popup.pop_sf_제품검색 frm = new Popup.pop_sf_제품검색();
                    frm.txtSrch.Text = item_nm;
                    frm.ShowDialog();

                    string sCode = frm.sCode;

                    if (frm.sCode != "")
                    {
                        string sName = frm.sName;
                        string sSpec = frm.sSpec;
                        string sUnitCd = frm.sUnitCd;
                        string sUnitNm = frm.sUnitNm;
                        string sTaxCd = frm.sVatCd;
                        //MessageBox.Show("hit");
                        BillGrid.Rows[BillGrid.CurrentCell.RowIndex].Cells["상품"].Value = frm.sName;
                        BillGrid.Rows[BillGrid.CurrentCell.RowIndex].Cells["상품코드"].Value = frm.sCode;
                        BillGrid.Rows[BillGrid.CurrentCell.RowIndex].Cells["규격"].Value = frm.sSpec;
                        BillGrid.Rows[BillGrid.CurrentCell.RowIndex].Cells["총수량"].Value = "0";
                        BillGrid.Rows[BillGrid.CurrentCell.RowIndex].Cells["단가"].Value = "0";
                        BillGrid.Rows[BillGrid.CurrentCell.RowIndex].Cells["금액"].Value = "0";
                        BillGrid.Rows[BillGrid.CurrentCell.RowIndex].Cells["과세구분"].Value = frm.sVatCd;
                        BillGrid.Rows[BillGrid.CurrentCell.RowIndex].Cells["품목구분"].Value = "제품";

                        bool isNullRow = false;

                        for (int i = 0; i < BillGrid.Rows.Count; i++)
                        {
                            if (BillGrid.Rows[i].Cells["상품코드"].Value == null || BillGrid.Rows[i].Cells["상품코드"].Value.ToString().Equals(""))
                            {
                                isNullRow = true;
                                break;
                            }
                        }

                        if (!isNullRow)
                        {
                            BillGrid.Rows.Add();
                            BillGrid.Rows[BillGrid.Rows.Count - 1].Cells["NO"].Value = BillGrid.Rows.Count;
                        }

                        frm.Dispose();
                        frm = null;

                        Cal_Money();

                    }

                }



            }
        }

        private void cmb_tax_gubun_SelectedValueChanged(object sender, EventArgs e)
        {
            Cal_Money();
        }

        private void cmb_auto_cal_gubun_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmb_auto_cal_gubun.SelectedValue == null)
            {
                return;
            }
            
                if (cmb_auto_cal_gubun.SelectedValue.ToString().Equals("Y"))
                {
                    txt_supply_money.ReadOnly = true;
                    txt_tax_money.ReadOnly = true;
                    txt_total_money.ReadOnly = true;
                    Cal_Money();
                }
                else
                {
                    txt_supply_money.ReadOnly = false;
                    txt_tax_money.ReadOnly = false;
                    txt_total_money.ReadOnly = false;
                }
            
        }

        private void btn_srch_sale_or_soo_Click(object sender, EventArgs e)
        {
            if (txt_cust_cd.Text == null || txt_cust_cd.Text.ToString().Equals(""))
            {
                MessageBox.Show("먼저 매출처를 선택해주십시오.");
                return;
            }

            if (cmb_input_gubun.SelectedValue.ToString().Equals("1")) //매출기준
            {
                Popup.pop계산서매출검색 msg = new Popup.pop계산서매출검색();
                msg.sCode = txt_cust_cd.Text.ToString();
                msg.sName = txt_cust_nm.Text.ToString();
                msg.sVatCd = (rBtn_vat_Y.Checked) ? "1" : "2";
                msg.compareGrid = BillGrid;

                msg.ShowDialog();

                if (msg.rsTable != null && msg.rsTable.Rows.Count > 0)
                {
                    DataTable rsTemp = msg.rsTable;
                    if (BillGrid.Rows.Count == 0)
                    {
                        BillGrid.Rows.Add();
                    }
                    if (BillGrid.Rows[BillGrid.Rows.Count - 1].Cells["상품코드"].Value == null || BillGrid.Rows[BillGrid.Rows.Count - 1].Cells["상품코드"].Value.ToString().Equals(""))
                    {
                        BillGrid.Rows.RemoveAt(BillGrid.Rows.Count - 1);
                    }
                    for (int i = 0; i < rsTemp.Rows.Count; i++)
                    {
                        BillGrid.Rows.Add();
                        BillGrid.Rows[BillGrid.Rows.Count - 1].Cells["NO"].Value = BillGrid.Rows.Count;

                        if (rsTemp.Rows[i]["상품구분"].ToString().Equals("1"))
                        {
                            BillGrid.Rows[BillGrid.Rows.Count - 1].Cells["품목구분"].Value = "상품";
                        }
                        else if (rsTemp.Rows[i]["상품구분"].ToString().Equals("2"))
                        {
                            BillGrid.Rows[BillGrid.Rows.Count - 1].Cells["품목구분"].Value = "제품";
                        }
                        else
                        {
                            BillGrid.Rows[BillGrid.Rows.Count - 1].Cells["품목구분"].Value = "직접";
                        }

                        BillGrid.Rows[BillGrid.Rows.Count - 1].Cells["상품"].Value = rsTemp.Rows[i]["상품명"].ToString();
                        BillGrid.Rows[BillGrid.Rows.Count - 1].Cells["상품코드"].Value = rsTemp.Rows[i]["상품코드"].ToString();
                        BillGrid.Rows[BillGrid.Rows.Count - 1].Cells["규격"].Value = rsTemp.Rows[i]["규격"].ToString();
                        BillGrid.Rows[BillGrid.Rows.Count - 1].Cells["총수량"].Value = rsTemp.Rows[i]["총수량"].ToString();
                        BillGrid.Rows[BillGrid.Rows.Count - 1].Cells["단가"].Value = rsTemp.Rows[i]["단가"].ToString();
                        BillGrid.Rows[BillGrid.Rows.Count - 1].Cells["상품코드"].Value = rsTemp.Rows[i]["상품코드"].ToString();
                        BillGrid.Rows[BillGrid.Rows.Count - 1].Cells["SALES_DATE"].Value = rsTemp.Rows[i]["매출일자"].ToString();
                        BillGrid.Rows[BillGrid.Rows.Count - 1].Cells["SALES_CD"].Value = rsTemp.Rows[i]["번호"].ToString();
                        BillGrid.Rows[BillGrid.Rows.Count - 1].Cells["SALES_SEQ"].Value = rsTemp.Rows[i]["순번"].ToString();
                        BillGrid.Rows[BillGrid.Rows.Count - 1].Cells["과세구분"].Value = msg.sVatCd;

                    }
                    Cal_Money();
                }
            }
            else //직접입력
            {
                Popup.pop계산서수금검색 msg = new Popup.pop계산서수금검색();
                msg.sCode = txt_cust_cd.Text.ToString();
                msg.sName = txt_cust_nm.Text.ToString();
                msg.sVatCd = (rBtn_vat_Y.Checked) ? "1" : "2";
                msg.compareGrid = BillGrid;

                msg.ShowDialog();

                if (msg.rsTable != null && msg.rsTable.Rows.Count > 0)
                {
                    DataTable rsTemp = msg.rsTable;
                    if (BillGrid.Rows.Count == 0)
                    {
                        BillGrid.Rows.Add();
                    }
                    if (BillGrid.Rows[BillGrid.Rows.Count - 1].Cells["상품코드"].Value == null || BillGrid.Rows[BillGrid.Rows.Count - 1].Cells["상품코드"].Value.ToString().Equals(""))
                    {
                        BillGrid.Rows.RemoveAt(BillGrid.Rows.Count - 1);
                    }
                    for (int i = 0; i < rsTemp.Rows.Count; i++)
                    {
                        BillGrid.Rows.Add();
                        BillGrid.Rows[BillGrid.Rows.Count - 1].Cells["NO"].Value = BillGrid.Rows.Count;

                        BillGrid.Rows[BillGrid.Rows.Count - 1].Cells["품목구분"].Value = "직접";


                        BillGrid.Rows[BillGrid.Rows.Count - 1].Cells["상품"].Value = "수금 " + rsTemp.Rows[i]["수금일자"].ToString() + " #" + rsTemp.Rows[i]["번호"].ToString() + " [" + rsTemp.Rows[i]["구분"].ToString() + "]";
                        BillGrid.Rows[BillGrid.Rows.Count - 1].Cells["상품코드"].Value = "수금 " + rsTemp.Rows[i]["수금일자"].ToString() + " #" + rsTemp.Rows[i]["번호"].ToString() + " [" + rsTemp.Rows[i]["구분"].ToString() + "]";
                        BillGrid.Rows[BillGrid.Rows.Count - 1].Cells["총수량"].Value = "1";
                        BillGrid.Rows[BillGrid.Rows.Count - 1].Cells["단가"].Value = rsTemp.Rows[i]["수금액"].ToString();
                        BillGrid.Rows[BillGrid.Rows.Count - 1].Cells["SOO_DATE"].Value = rsTemp.Rows[i]["수금일자"].ToString();
                        BillGrid.Rows[BillGrid.Rows.Count - 1].Cells["SOO_CD"].Value = rsTemp.Rows[i]["번호"].ToString();
                        BillGrid.Rows[BillGrid.Rows.Count - 1].Cells["과세구분"].Value = msg.sVatCd;

                    }
                    Cal_Money();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                ComInfo comInfo = new ComInfo();

                DialogResult msgOk = comInfo.deleteConfrim("계산서 삭제", txt_bill_date.Text.ToString()+ " - "+ lbl_bill_cd.Text.ToString());

                if (msgOk == DialogResult.No)
                {
                    return;
                }


                wnDm wDm = new wnDm();
                int rsNum = wDm.Delete_Bill_Input(
                          txt_bill_date.Text
                        , lbl_bill_cd.Text
                        );

                if (rsNum == 0)
                {
                    MessageBox.Show("성공적으로 삭제하였습니다.");
                    ResetSetting();
                    Select_BillListGrid();
                    return;
                }
                else if (rsNum == 1)
                {
                    MessageBox.Show("삭제에 실패하였습니다");
                    return;
                }
                else
                {
                    MessageBox.Show("데이터베이스 에러");
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception 오류");
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                msg.ShowDialog();
                return;
            }
        }

        private void BillGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{up}");

                BillGrid.CurrentCell = BillGrid.Rows[BillGrid.CurrentCell.RowIndex].Cells[BillGrid.CurrentCell.ColumnIndex];
                BillGrid.Rows[BillGrid.CurrentCell.RowIndex].Cells[BillGrid.CurrentCell.ColumnIndex + 1].Selected = true;
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
                    in_grid_logic();
                    break;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
            return true;
        }
        
    }
}
