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
    public partial class frm계산서이관 : Form
    {
        
        private wnGConstant wConst = new wnGConstant();



        public frm계산서이관()
        {
            InitializeComponent();
        }

        private void frm계산서이관_Load(object sender, EventArgs e)
        {
            lbl_title.Tag = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[0] + "$" + wnDm.fn_TitleName(this.Name.ToString()).Split('$')[1]; lbl_title.Text = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[2];
            
            start_date.Text = DateTime.Today.ToString("yyyy-MM-dd").Substring(0, 8) + "01";
            init_Combobox();
            

        }

        private void init_Combobox()
        {
            ComInfo comInfo = new ComInfo();
            string sqlQuery = "";

            cmb_staff.ValueMember = "코드";
            cmb_staff.DisplayMember = "명칭";
            sqlQuery = comInfo.queryStaff();
            wConst.ComboBox_Read_ALL(cmb_staff, sqlQuery);

            cmb_vat.ValueMember = "코드";
            cmb_vat.DisplayMember = "명칭";
            sqlQuery = comInfo.queryVatAll();
            wConst.ComboBox_Read_ALL(cmb_vat, sqlQuery);
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
            in_grid_logic();
            lblMsg.Visible = false;



        }

        
        

        #endregion button logic


        private void in_grid_logic()
        {
            try
            {
                SalesGrid.Rows.Clear();
                wnDm wDm = new wnDm();
                DataTable dt = new DataTable();
                string s_date = start_date.Text.ToString();
                string e_date = end_date.Text.ToString();
                string condition = "";

                if (!chk_Srch_all.Checked && txt_srch2.Text != null && !txt_srch2.Text.ToString().Equals(""))
                {
                    condition += " and S.CUST_CD = '" + txt_srch2.Text.ToString() + "'  ";
                }
                else
                {
                    txt_srch2.Text = "";
                    txt_srch.Text = "";
                }

                if (cmb_staff.SelectedIndex != 0)
                {
                    condition += " and (SELECT STAFF_CD FROM N_CUST_CODE WHERE S.CUST_CD = CUST_CD) = '"+cmb_staff.SelectedValue.ToString()+"'   ";
                }

                

                dt = wDm.fn_Select_Bill_Escalation(s_date, e_date, condition);

                if (dt != null && dt.Rows.Count > 0)
                {
                    SalesGrid.RowCount = dt.Rows.Count;
                    decimal cardSooTemp = 0;
                    bool isCardSoo = false;
                    string custTemp = "";
                    decimal sum_card_supply = 0;
                    decimal sum_card_tax = 0;
                    decimal sum_card_total = 0;
                    decimal sum_card_Accept = 0;
                    decimal sum_card_soo = 0;

                    decimal All_sum_supply_money = 0;
                    decimal All_sum_tax_money = 0;
                    decimal All_sum_total_money = 0;


                    bool isCardCheck = chk_card_accept.Checked;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataGridViewCellStyle style = new DataGridViewCellStyle();
                        style.BackColor = Color.Khaki;
                        SalesGrid.Rows[i].Cells["공급가액"].Style = style;
                        SalesGrid.Rows[i].Cells["부가세"].Style = style;
                        SalesGrid.Rows[i].Cells["합계금액"].Style = style;


                        style = new DataGridViewCellStyle();
                        style.BackColor = Color.WhiteSmoke;
                        SalesGrid.Rows[i].Cells["카드적용액"].Style = style;
                        style.ForeColor = Color.Blue;
                        SalesGrid.Rows[i].Cells["공급가액2"].Style = style;
                        SalesGrid.Rows[i].Cells["부가세2"].Style = style;
                        SalesGrid.Rows[i].Cells["합계금액2"].Style = style;

                        if (dt.Rows[i]["CUST_CD"].ToString().Equals("9999999999"))
                        {
                            SalesGrid.Rows[i].Cells["코드"].Value = "";
                            SalesGrid.Rows[i].Cells["거래처명"].Value = dt.Rows[i]["CUST_NM"].ToString();
                            SalesGrid.Rows[i].Cells["매출금액"].Value = decimal.Parse(dt.Rows[i]["TOTAL_SALES_MONEY"].ToString()).ToString("#,0.######");
                            SalesGrid.Rows[i].Cells["발행율"].Value = "";
                            SalesGrid.Rows[i].Cells["구분"].Value = "";
                            SalesGrid.Rows[i].Cells["공급가액"].Value = decimal.Parse(dt.Rows[i]["TOTAL_SUPPLY_MONEY"].ToString()).ToString("#,0.######");
                            SalesGrid.Rows[i].Cells["부가세"].Value = decimal.Parse(dt.Rows[i]["TOTAL_TAX_MONEY"].ToString()).ToString("#,0.######");
                            SalesGrid.Rows[i].Cells["합계금액"].Value = decimal.Parse(dt.Rows[i]["TOTAL_MONEY"].ToString()).ToString("#,0.######");
                            All_sum_supply_money += decimal.Parse(dt.Rows[i]["TOTAL_SUPPLY_MONEY"].ToString());
                            All_sum_tax_money += decimal.Parse(dt.Rows[i]["TOTAL_TAX_MONEY"].ToString());
                            All_sum_total_money += decimal.Parse(dt.Rows[i]["TOTAL_MONEY"].ToString());
                                
                            SalesGrid.Rows[i].Cells["건수"].Value = dt.Rows[i]["COUNT"].ToString();
                            if (!isCardCheck)
                            {
                                if (sum_card_soo == 0)
                                {
                                    SalesGrid.Rows[i].Cells["카드수금액"].Value = "";
                                }
                                else
                                {
                                    SalesGrid.Rows[i].Cells["카드수금액"].Value = sum_card_soo.ToString("#,0.######");
                                }
                                SalesGrid.Rows[i].Cells["카드적용액"].Value = "";
                                SalesGrid.Rows[i].Cells["공급가액2"].Value = "";
                                SalesGrid.Rows[i].Cells["부가세2"].Value = "";
                                SalesGrid.Rows[i].Cells["합계금액2"].Value = "";
                            }
                            else
                            {
                                SalesGrid.Rows[i].Cells["카드수금액"].Value = sum_card_soo.ToString("#,0.######");
                                SalesGrid.Rows[i].Cells["카드적용액"].Value = sum_card_Accept.ToString("#,0.######");
                                SalesGrid.Rows[i].Cells["공급가액2"].Value = sum_card_supply.ToString("#,0.######");
                                SalesGrid.Rows[i].Cells["부가세2"].Value = sum_card_tax.ToString("#,0.######");
                                SalesGrid.Rows[i].Cells["합계금액2"].Value = sum_card_total.ToString("#,0.######");
                            }
                            break;

                        }

                        if (custTemp.Equals(dt.Rows[i]["CUST_CD"].ToString()) && isCardSoo)
                        {
                            isCardSoo = false;
                            SalesGrid.Rows[i].Cells["코드"].Value = dt.Rows[i]["CUST_CD"].ToString();
                            SalesGrid.Rows[i].Cells["거래처명"].Value = dt.Rows[i]["CUST_NM"].ToString();
                            SalesGrid.Rows[i].Cells["부가세코드"].Value = dt.Rows[i]["TAX_CD"].ToString();
                            SalesGrid.Rows[i].Cells["과면세코드"].Value = dt.Rows[i]["VAT_CD"].ToString();
                            SalesGrid.Rows[i].Cells["대표자"].Value = dt.Rows[i]["OWNER"].ToString();
                            SalesGrid.Rows[i].Cells["사업자번호"].Value = dt.Rows[i]["SAUP_NO"].ToString();
                            SalesGrid.Rows[i].Cells["매출금액"].Value = decimal.Parse(dt.Rows[i]["TOTAL_SALES_MONEY"].ToString()).ToString("#,0.######");
                            if (dt.Rows[i]["ISSUE_RATIO"] == null || dt.Rows[i]["ISSUE_RATIO"].ToString().Equals(""))
                            {
                                SalesGrid.Rows[i].Cells["발행율"].Value = "100";
                            }
                            SalesGrid.Rows[i].Cells["발행율"].Value = dt.Rows[i]["ISSUE_RATIO"].ToString();
                            SalesGrid.Rows[i].Cells["구분"].Value = dt.Rows[i]["VAT_NM"].ToString();
                            if (dt.Rows[i]["VAT_NM"].ToString().Equals("면세"))
                            {
                                SalesGrid.Rows[i].Cells["구분"].Style.ForeColor = Color.Red;
                            }
                            SalesGrid.Rows[i].Cells["공급가액"].Value = decimal.Parse(dt.Rows[i]["TOTAL_SUPPLY_MONEY"].ToString()).ToString("#,0.######");
                            SalesGrid.Rows[i].Cells["부가세"].Value = decimal.Parse(dt.Rows[i]["TOTAL_TAX_MONEY"].ToString()).ToString("#,0.######");
                            SalesGrid.Rows[i].Cells["합계금액"].Value = decimal.Parse(dt.Rows[i]["TOTAL_MONEY"].ToString()).ToString("#,0.######");
                            All_sum_supply_money += decimal.Parse(dt.Rows[i]["TOTAL_SUPPLY_MONEY"].ToString());
                            All_sum_tax_money += decimal.Parse(dt.Rows[i]["TOTAL_TAX_MONEY"].ToString());
                            All_sum_total_money += decimal.Parse(dt.Rows[i]["TOTAL_MONEY"].ToString());
                            SalesGrid.Rows[i].Cells["건수"].Value = dt.Rows[i]["COUNT"].ToString();
                            SalesGrid.Rows[i].Cells["카드수금액"].Value = "";
                            if (cardSooTemp.ToString().Equals("0"))
                            {
                                SalesGrid.Rows[i].Cells["카드적용액"].Value = "";
                            }
                            else
                            {
                                if (cardSooTemp > decimal.Parse(dt.Rows[i]["TOTAL_MONEY"].ToString()))
                                {
                                    cardSooTemp = decimal.Parse(dt.Rows[i]["TOTAL_MONEY"].ToString());
                                }
                                if (isCardCheck)
                                {
                                    SalesGrid.Rows[i].Cells["카드적용액"].Value = cardSooTemp.ToString("#,0.######");
                                    sum_card_Accept += cardSooTemp;
                                }
                            }

                            if (isCardCheck)
                            {
                                SalesGrid.Rows[i].Cells["공급가액2"].Value = (decimal.Parse(dt.Rows[i]["TOTAL_SUPPLY_MONEY"].ToString()) - cardSooTemp).ToString("#,0.######");
                                SalesGrid.Rows[i].Cells["부가세2"].Value = "0";
                                SalesGrid.Rows[i].Cells["합계금액2"].Value = (decimal.Parse(dt.Rows[i]["TOTAL_SUPPLY_MONEY"].ToString()) - cardSooTemp).ToString("#,0.######");
                                sum_card_supply += (decimal.Parse(dt.Rows[i]["TOTAL_SUPPLY_MONEY"].ToString()) - cardSooTemp);
                                sum_card_tax += 0;
                                sum_card_total += (decimal.Parse(dt.Rows[i]["TOTAL_SUPPLY_MONEY"].ToString()) - cardSooTemp);
                            }
                        }
                        else
                        {
                            SalesGrid.Rows[i].Cells["코드"].Value = dt.Rows[i]["CUST_CD"].ToString();
                            SalesGrid.Rows[i].Cells["거래처명"].Value = dt.Rows[i]["CUST_NM"].ToString();
                            SalesGrid.Rows[i].Cells["부가세코드"].Value = dt.Rows[i]["TAX_CD"].ToString();
                            SalesGrid.Rows[i].Cells["과면세코드"].Value = dt.Rows[i]["VAT_CD"].ToString();
                            SalesGrid.Rows[i].Cells["대표자"].Value = dt.Rows[i]["OWNER"].ToString();
                            SalesGrid.Rows[i].Cells["사업자번호"].Value = dt.Rows[i]["SAUP_NO"].ToString();
                            SalesGrid.Rows[i].Cells["매출금액"].Value = decimal.Parse(dt.Rows[i]["TOTAL_SALES_MONEY"].ToString()).ToString("#,0.######");
                            SalesGrid.Rows[i].Cells["발행율"].Value = dt.Rows[i]["ISSUE_RATIO"].ToString();
                            if (dt.Rows[i]["ISSUE_RATIO"] == null || dt.Rows[i]["ISSUE_RATIO"].ToString().Equals(""))
                            {
                                SalesGrid.Rows[i].Cells["발행율"].Value = "100";
                            }
                            SalesGrid.Rows[i].Cells["구분"].Value = dt.Rows[i]["VAT_NM"].ToString();
                            if (dt.Rows[i]["VAT_NM"].ToString().Equals("면세"))
                            {
                                SalesGrid.Rows[i].Cells["구분"].Style.ForeColor = Color.Red;
                            }
                            SalesGrid.Rows[i].Cells["공급가액"].Value = decimal.Parse(dt.Rows[i]["TOTAL_SUPPLY_MONEY"].ToString()).ToString("#,0.######");
                            SalesGrid.Rows[i].Cells["부가세"].Value = decimal.Parse(dt.Rows[i]["TOTAL_TAX_MONEY"].ToString()).ToString("#,0.######");
                            SalesGrid.Rows[i].Cells["합계금액"].Value = decimal.Parse(dt.Rows[i]["TOTAL_MONEY"].ToString()).ToString("#,0.######");
                            All_sum_supply_money += decimal.Parse(dt.Rows[i]["TOTAL_SUPPLY_MONEY"].ToString());
                            All_sum_tax_money += decimal.Parse(dt.Rows[i]["TOTAL_TAX_MONEY"].ToString());
                            All_sum_total_money += decimal.Parse(dt.Rows[i]["TOTAL_MONEY"].ToString());
                            SalesGrid.Rows[i].Cells["건수"].Value = dt.Rows[i]["COUNT"].ToString();
                            if (decimal.Parse(dt.Rows[i]["SOO_CARD"].ToString()) == 0)
                            {
                                SalesGrid.Rows[i].Cells["카드수금액"].Value = "";
                                SalesGrid.Rows[i].Cells["카드적용액"].Value = "";
                                isCardSoo = false;
                                cardSooTemp = 0;
                            }
                            else
                            {
                                SalesGrid.Rows[i].Cells["카드수금액"].Value = decimal.Parse(dt.Rows[i]["SOO_CARD"].ToString()).ToString("#,0.######");
                                sum_card_soo += decimal.Parse(dt.Rows[i]["SOO_CARD"].ToString());
                                isCardSoo = true;
                                cardSooTemp = decimal.Parse(dt.Rows[i]["SOO_CARD"].ToString()) - decimal.Parse(dt.Rows[i]["TOTAL_MONEY"].ToString());
                                if (cardSooTemp < 0)
                                {
                                    cardSooTemp = 0;
                                }
                                if (isCardCheck)
                                {
                                    SalesGrid.Rows[i].Cells["카드적용액"].Value = decimal.Parse(dt.Rows[i]["SOO_ACCEPT_CARD"].ToString()).ToString("#,0.######");
                                    sum_card_Accept += decimal.Parse(dt.Rows[i]["SOO_ACCEPT_CARD"].ToString());
                                }
                            }
                            if (isCardCheck)
                            {
                                SalesGrid.Rows[i].Cells["공급가액2"].Value = decimal.Parse(dt.Rows[i]["CARD_SUPPLY_MONEY"].ToString()).ToString("#,0.######");
                                SalesGrid.Rows[i].Cells["부가세2"].Value = decimal.Parse(dt.Rows[i]["CARD_TAX_MONEY"].ToString()).ToString("#,0.######");
                                SalesGrid.Rows[i].Cells["합계금액2"].Value = decimal.Parse(dt.Rows[i]["CARD_TOTAL_MONEY"].ToString()).ToString("#,0.######");
                                sum_card_supply += decimal.Parse(dt.Rows[i]["CARD_SUPPLY_MONEY"].ToString());
                                sum_card_tax += decimal.Parse(dt.Rows[i]["CARD_TAX_MONEY"].ToString());
                                sum_card_total += decimal.Parse(dt.Rows[i]["CARD_TOTAL_MONEY"].ToString());
                            }
                              

                            custTemp = dt.Rows[i]["CUST_CD"].ToString();
                        }
                    }

                    SalesGrid.Columns["선택"].HeaderText = "[ ]";

                    for (int i = 0; i < SalesGrid.Rows.Count; i++)
                    {
                        SalesGrid.Rows[i].Cells["선택"].Value = false;
                    }


                    SalesGrid.Rows[SalesGrid.Rows.Count - 1].Cells["공급가액"].Value = All_sum_supply_money.ToString("#,0.######");
                    SalesGrid.Rows[SalesGrid.Rows.Count - 1].Cells["부가세"].Value = All_sum_tax_money.ToString("#,0.######");
                    SalesGrid.Rows[SalesGrid.Rows.Count - 1].Cells["합계금액"].Value = All_sum_total_money.ToString("#,0.######");


                    //과세 면세 구분해서 날리기 

                    if (cmb_vat.SelectedIndex != 0)
                    {
                        decimal SumSlaesMoney = 0;
                        decimal SumSupplyMoney = 0;
                        decimal SumTaxMoney = 0;
                        decimal SumTotalMoney = 0;
                        decimal SumCardSoo = 0;
                        decimal SumCardAccept = 0;
                        decimal SumSupplyCard = 0;
                        decimal SumTaxCard = 0;
                        decimal SumTotalCard = 0;
                        decimal SumCount = 0;
                        if (cmb_vat.SelectedValue.ToString().Equals("1"))
                        {
                            for (int i = 0; i < SalesGrid.Rows.Count; i++)
                            {
                                if (SalesGrid.Rows[i].Cells["구분"].Value.ToString().Equals("면세"))
                                {
                                    SumSlaesMoney += decimal.Parse(SalesGrid.Rows[i].Cells["매출금액"].Value.ToString());
                                    SumSupplyMoney  += decimal.Parse(SalesGrid.Rows[i].Cells["공급가액"].Value.ToString());
                                    SumTaxMoney  += decimal.Parse(SalesGrid.Rows[i].Cells["부가세"].Value.ToString());
                                    SumTotalMoney  += decimal.Parse(SalesGrid.Rows[i].Cells["합계금액"].Value.ToString());
                                    if (SalesGrid.Rows[i].Cells["카드수금액"].Value != null && !SalesGrid.Rows[i].Cells["카드수금액"].Value.ToString().Equals(""))
                                    {
                                        SumCardSoo += decimal.Parse(SalesGrid.Rows[i].Cells["카드수금액"].Value.ToString());
                                    }
                                    if (SalesGrid.Rows[i].Cells["카드적용액"].Value != null && !SalesGrid.Rows[i].Cells["카드적용액"].Value.ToString().Equals(""))
                                    {
                                        SumCardAccept += decimal.Parse(SalesGrid.Rows[i].Cells["카드적용액"].Value.ToString());
                                    }


                                    if (SalesGrid.Rows[i].Cells["공급가액2"].Value == null || SalesGrid.Rows[i].Cells["공급가액2"].Value.ToString().Equals(""))
                                    {
                                        SumSupplyCard += 0;
                                    }
                                    else
                                    {
                                        SumSupplyCard += decimal.Parse(SalesGrid.Rows[i].Cells["공급가액2"].Value.ToString());
                                    }
                                    if (SalesGrid.Rows[i].Cells["부가세2"].Value == null || SalesGrid.Rows[i].Cells["부가세2"].Value.ToString().Equals(""))
                                    {
                                        SumTaxCard += 0;
                                    }
                                    else
                                    {
                                        SumTaxCard += decimal.Parse(SalesGrid.Rows[i].Cells["부가세2"].Value.ToString());
                                    }
                                    if (SalesGrid.Rows[i].Cells["합계금액2"].Value == null || SalesGrid.Rows[i].Cells["합계금액2"].Value.ToString().Equals(""))
                                    {
                                        SumTotalCard += 0;
                                    }
                                    else
                                    {
                                        SumTotalCard += decimal.Parse(SalesGrid.Rows[i].Cells["합계금액2"].Value.ToString());
                                    }

                                    SumCount += decimal.Parse(SalesGrid.Rows[i].Cells["건수"].Value.ToString());
                                    SalesGrid.Rows.RemoveAt(i);
                                    i--;
                                }
                            }
                        }
                        else
                        {
                            for (int i = 0; i < SalesGrid.Rows.Count; i++)
                            {
                                if (SalesGrid.Rows[i].Cells["구분"].Value.ToString().Equals("과세"))
                                {
                                    SumSlaesMoney += decimal.Parse(SalesGrid.Rows[i].Cells["매출금액"].Value.ToString());
                                    SumSupplyMoney += decimal.Parse(SalesGrid.Rows[i].Cells["공급가액"].Value.ToString());
                                    SumTaxMoney += decimal.Parse(SalesGrid.Rows[i].Cells["부가세"].Value.ToString());
                                    SumTotalMoney += decimal.Parse(SalesGrid.Rows[i].Cells["합계금액"].Value.ToString());
                                    if (SalesGrid.Rows[i].Cells["카드수금액"].Value != null && !SalesGrid.Rows[i].Cells["카드수금액"].Value.ToString().Equals(""))
                                    {
                                        SumCardSoo += decimal.Parse(SalesGrid.Rows[i].Cells["카드수금액"].Value.ToString());
                                    }
                                    if (SalesGrid.Rows[i].Cells["카드적용액"].Value != null && !SalesGrid.Rows[i].Cells["카드적용액"].Value.ToString().Equals(""))
                                    {
                                        SumCardAccept += decimal.Parse(SalesGrid.Rows[i].Cells["카드적용액"].Value.ToString());
                                    }

                                    if (SalesGrid.Rows[i].Cells["공급가액2"].Value == null || SalesGrid.Rows[i].Cells["공급가액2"].Value.ToString().Equals(""))
                                    {
                                        SumSupplyCard += 0;
                                    }
                                    else
                                    {
                                        SumSupplyCard += decimal.Parse(SalesGrid.Rows[i].Cells["공급가액2"].Value.ToString());
                                    }
                                    if (SalesGrid.Rows[i].Cells["부가세2"].Value == null || SalesGrid.Rows[i].Cells["부가세2"].Value.ToString().Equals(""))
                                    {
                                        SumTaxCard += 0;
                                    }
                                    else
                                    {
                                        SumTaxCard += decimal.Parse(SalesGrid.Rows[i].Cells["부가세2"].Value.ToString());
                                    }
                                    if (SalesGrid.Rows[i].Cells["합계금액2"].Value == null || SalesGrid.Rows[i].Cells["합계금액2"].Value.ToString().Equals(""))
                                    {
                                        SumTotalCard += 0;
                                    }
                                    else
                                    {
                                        SumTotalCard += decimal.Parse(SalesGrid.Rows[i].Cells["합계금액2"].Value.ToString());
                                    }

                                    SumCount += decimal.Parse(SalesGrid.Rows[i].Cells["건수"].Value.ToString());
                                    SalesGrid.Rows.RemoveAt(i);
                                    i--;
                                }
                            }
                        }
                        SalesGrid.Rows[SalesGrid.Rows.Count - 1].Cells["매출금액"].Value = (decimal.Parse(SalesGrid.Rows[SalesGrid.Rows.Count - 1].Cells["매출금액"].Value.ToString().Replace(",", "")) - SumSlaesMoney).ToString("#,0.######");
                        SalesGrid.Rows[SalesGrid.Rows.Count - 1].Cells["공급가액"].Value = (decimal.Parse(SalesGrid.Rows[SalesGrid.Rows.Count - 1].Cells["공급가액"].Value.ToString().Replace(",", "")) - SumSupplyMoney).ToString("#,0.######");
                        SalesGrid.Rows[SalesGrid.Rows.Count - 1].Cells["부가세"].Value = (decimal.Parse(SalesGrid.Rows[SalesGrid.Rows.Count - 1].Cells["부가세"].Value.ToString().Replace(",", "")) - SumTaxMoney).ToString("#,0.######");
                        SalesGrid.Rows[SalesGrid.Rows.Count - 1].Cells["합계금액"].Value = (decimal.Parse(SalesGrid.Rows[SalesGrid.Rows.Count - 1].Cells["합계금액"].Value.ToString().Replace(",", "")) - SumTotalMoney).ToString("#,0.######");
                        SalesGrid.Rows[SalesGrid.Rows.Count - 1].Cells["카드수금액"].Value = (decimal.Parse(SalesGrid.Rows[SalesGrid.Rows.Count - 1].Cells["카드수금액"].Value.ToString().Replace(",", "")) - SumCardSoo).ToString("#,0.######");
                        SalesGrid.Rows[SalesGrid.Rows.Count - 1].Cells["카드적용액"].Value = (decimal.Parse(SalesGrid.Rows[SalesGrid.Rows.Count - 1].Cells["카드적용액"].Value.ToString().Replace(",", "")) - SumCardAccept).ToString("#,0.######");
                        SalesGrid.Rows[SalesGrid.Rows.Count - 1].Cells["공급가액2"].Value = (decimal.Parse(SalesGrid.Rows[SalesGrid.Rows.Count - 1].Cells["공급가액2"].Value.ToString().Replace(",", "")) - SumSupplyCard).ToString("#,0.######");
                        SalesGrid.Rows[SalesGrid.Rows.Count - 1].Cells["부가세2"].Value = (decimal.Parse(SalesGrid.Rows[SalesGrid.Rows.Count - 1].Cells["부가세2"].Value.ToString().Replace(",", "")) - SumTaxCard).ToString("#,0.######");
                        SalesGrid.Rows[SalesGrid.Rows.Count - 1].Cells["합계금액2"].Value = (decimal.Parse(SalesGrid.Rows[SalesGrid.Rows.Count - 1].Cells["합계금액2"].Value.ToString().Replace(",", "")) - SumTotalCard).ToString("#,0.######");
                        SalesGrid.Rows[SalesGrid.Rows.Count - 1].Cells["건수"].Value = (decimal.Parse(SalesGrid.Rows[SalesGrid.Rows.Count - 1].Cells["건수"].Value.ToString().Replace(",", "")) - SumCount).ToString("#,0.######");
                    }
                }
                else
                {
                    MessageBox.Show("검색된 내용이 없습니다.");
                    return;
                }


            }
            catch (Exception ex)
            {
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                msg.ShowDialog();
            }

            


        }

        

        private void grdCellSetting()
        {
            ComInfo comInfo = new ComInfo();
            comInfo.grdCellSetting2(SalesGrid);
        }

        private void btn출력_Click(object sender, EventArgs e)
        {
           
        }

        private void SalesGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                try
                {
                    string cust_cd = SalesGrid.Rows[e.RowIndex].Cells["코드"].Value.ToString();
                    string vat_cd = "";
                    if(SalesGrid.Rows[e.RowIndex].Cells["구분"].Value.ToString().Equals("면세"))
                    {
                        vat_cd = "2";
                    }else{
                        vat_cd = "1";
                    }
                    string condition = "WHERE SALES_DATE >= '"+start_date.Text+"' AND SALES_DATE <= '"+end_date.Text+"' AND A.CUST_CD = '"+cust_cd+"' AND A.VAT_CD = '"+vat_cd+"' ";
                    wnDm wDm = new wnDm();
                    DataTable dt = wDm.fn_Select_Bill_Escalation_Detail(condition);
                    SalesDetailGrid.Rows.Clear();
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        SalesDetailGrid.RowCount = dt.Rows.Count;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            SalesDetailGrid.Rows[i].Cells["매출일자"].Value = dt.Rows[i]["SALES_DATE"].ToString();
                            SalesDetailGrid.Rows[i].Cells["번호"].Value = dt.Rows[i]["SALES_CD"].ToString();
                            SalesDetailGrid.Rows[i].Cells["상품코드"].Value = dt.Rows[i]["ITEM_CD"].ToString();
                            SalesDetailGrid.Rows[i].Cells["상품명"].Value = dt.Rows[i]["PRODUCT_NM"].ToString();
                            SalesDetailGrid.Rows[i].Cells["규격"].Value = dt.Rows[i]["SPEC"].ToString();
                            SalesDetailGrid.Rows[i].Cells["총수량"].Value = decimal.Parse(dt.Rows[i]["TOTAL_AMT"].ToString()).ToString("#,0.######");
                            SalesDetailGrid.Rows[i].Cells["단위"].Value = dt.Rows[i]["UNIT_NM"].ToString();
                            SalesDetailGrid.Rows[i].Cells["금액"].Value = decimal.Parse(dt.Rows[i]["TOTAL_MONEY"].ToString()).ToString("#,0.######");
                            if (dt.Rows[i]["VAT_CD"].ToString().Equals("2"))
                            {
                                SalesDetailGrid.Rows[i].Cells["부가세구분"].Value = "면세";
                            }
                            else
                            {
                                if (!dt.Rows[i]["TAX_CD"].ToString().Equals("0"))
                                {
                                    SalesDetailGrid.Rows[i].Cells["부가세구분"].Value = dt.Rows[i]["TAX_NM"].ToString();
                                }
                                else
                                {
                                    SalesDetailGrid.Rows[i].Cells["부가세구분"].Value = "";
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Exceptiion 오류");
                    Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                    msg.ShowDialog();
                    return;
                }


            }
        }

        private void txt_srch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Popup.pop거래처검색 msg = new Popup.pop거래처검색();
                msg.sCustGbn = "1";
                msg.sCustNm = txt_srch.Text.ToString();

                msg.ShowDialog();

                if (msg.sCode != null && !msg.sCode.Equals(""))
                {
                    txt_srch.Text = msg.sName;
                    txt_srch2.Text = msg.sCode;
                }
            }
        }

        private void btn_cust_srch_Click(object sender, EventArgs e)
        {
            Popup.pop거래처검색 msg = new Popup.pop거래처검색();
            msg.sCustGbn = "1";
            msg.sCustNm = txt_srch.Text.ToString();

            msg.ShowDialog();

            if (msg.sCode != null && !msg.sCode.Equals(""))
            {
                txt_srch.Text = msg.sName;
                txt_srch2.Text = msg.sCode;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                wnDm wDm = new wnDm();
                int rsNum = -1;

                DataTable dt = wDm.fn_Saup_List(Common.p_saupNo);
                string flagship = "";
                if (dt != null && dt.Rows.Count > 0)
                {
                    flagship = dt.Rows[0]["FLAGSHIP"].ToString();
                }
                else
                {
                    MessageBox.Show("사업자관리에서 사업자 정보를 먼저 작성해주십시오.");
                    return;
                }

                if (SalesGrid.Rows[0].Cells["공급가액"].Value == null || SalesGrid.Rows[0].Cells["공급가액"].Value.ToString().Equals(""))
                {
                    lblMsg.Visible = true;
                    Application.DoEvents();
                    rsNum = wDm.Insert_Escalation_Card_Soo(txt_Escalation_date.Text, start_date.Text, end_date.Text, SalesGrid, flagship);
                    lblMsg.Visible = false;

                }
                else
                {
                    lblMsg.Visible = true;
                    Application.DoEvents();
                    rsNum = wDm.Insert_Escalation_Not_Card_Soo(txt_Escalation_date.Text, start_date.Text, end_date.Text, SalesGrid,flagship);
                    lblMsg.Visible = false;
                }

                if (rsNum == 0)
                {
                    MessageBox.Show("성공적으로 등록하였습니다.");
                    SalesGrid.Rows.Clear();
                    SalesDetailGrid.Rows.Clear();
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
            catch (Exception ex)
            {
                MessageBox.Show("Exception 오류");
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                msg.ShowDialog();
            }
        }

        private void SalesGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                if (SalesGrid.Columns[e.ColumnIndex].Name.Equals("선택"))
                {
                    if (SalesGrid.Columns[e.ColumnIndex].HeaderText.Equals("[ ]"))
                    {
                        SalesGrid.Columns[e.ColumnIndex].HeaderText = "[v]";
                        for (int i = 0; i < SalesGrid.Rows.Count; i++)
                        {
                            SalesGrid.Rows[i].Cells["선택"].Value = true;
                        }
                    }
                    else
                    {
                        SalesGrid.Columns[e.ColumnIndex].HeaderText = "[ ]";
                        for (int i = 0; i < SalesGrid.Rows.Count; i++)
                        {
                            SalesGrid.Rows[i].Cells["선택"].Value = false;
                        }
                    }
                    
                }
            }
        }

        private void end_date_ValueChanged(object sender, EventArgs e)
        {
            txt_Escalation_date.Text = end_date.Text;
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
                    in_grid_logic();
                    break;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
            return true;
        }
        

       
       
        
    }
}
