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
    public partial class frm매출계산서현황 : Form
    {
        
        private wnGConstant wConst = new wnGConstant();



        public frm매출계산서현황()
        {
            InitializeComponent();
        }

        private void frm매출계산서현황_Load(object sender, EventArgs e)
        {
            lbl_title.Tag = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[0] + "$" + wnDm.fn_TitleName(this.Name.ToString()).Split('$')[1]; lbl_title.Text = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[2];
            
            start_date.Text = DateTime.Today.ToString("yyyy-MM-dd").Substring(0, 8) + "01";
            total_in_grid_logic();
        }

        #region button logic

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            in_grid_logic();
        }

        
        

        #endregion button logic


        private void in_grid_logic()
        {
            try
            {
                if (TabControl.SelectedIndex == 0)
                {
                    wnDm wDm = new wnDm();
                    string condition = " WHERE B.BILL_DATE >= '" + start_date.Text + "' and B.BILL_DATE <= '" + end_date.Text + "'   ";

                    if (txtSrch2.Text != null && !txtSrch2.Text.ToString().Equals(""))
                    {
                        condition += " AND B.CUST_CD = '" + txtSrch2.Text + "' ";
                    }
                    DataTable dt = wDm.select_Bill_List_CustOrder(condition);

                    CustGrid.Rows.Clear();
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        CustGrid.RowCount = dt.Rows.Count;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            CustGrid.Rows[i].Cells["코드"].Value = (dt.Rows[i]["코드"].ToString().Equals("9999999999") ? "" : dt.Rows[i]["코드"].ToString());
                            CustGrid.Rows[i].Cells["매출처명"].Value = dt.Rows[i]["매출처명"].ToString();
                            CustGrid.Rows[i].Cells["사업자번호"].Value = dt.Rows[i]["사업자번호"].ToString();
                            CustGrid.Rows[i].Cells["발행일자"].Value = dt.Rows[i]["발행일자"].ToString();
                            CustGrid.Rows[i].Cells["발행번호"].Value = dt.Rows[i]["발행번호"].ToString();
                            CustGrid.Rows[i].Cells["구분"].Value = dt.Rows[i]["구분"].ToString();
                            CustGrid.Rows[i].Cells["공급가액"].Value = decimal.Parse(dt.Rows[i]["공급가액"].ToString()).ToString("#,0.######");
                            CustGrid.Rows[i].Cells["부가세"].Value = decimal.Parse(dt.Rows[i]["부가세"].ToString()).ToString("#,0.######");
                            CustGrid.Rows[i].Cells["합계금액"].Value = decimal.Parse(dt.Rows[i]["합계금액"].ToString()).ToString("#,0.######");

                            if (dt.Rows[i]["발행번호"].ToString().Equals("0")) CustGrid.Rows[i].Cells["발행번호"].Value = "";
                            if (dt.Rows[i]["순서"].ToString().Equals("2"))
                            {
                                DataGridViewCellStyle style = new DataGridViewCellStyle();
                                style.BackColor = Color.PaleGoldenrod;
                                style.SelectionBackColor = Color.DarkKhaki;

                                for (int j = 0; j < CustGrid.ColumnCount; j++)
                                {
                                    CustGrid.Rows[i].Cells[j].Style = style;
                                }
                            }
                            
                        }
                    }
                }
                else if (TabControl.SelectedIndex == 1)
                {
                    wnDm wDm = new wnDm();
                    string condition = " WHERE B.BILL_DATE >= '" + start_date.Text + "' and B.BILL_DATE <= '" + end_date.Text + "'   ";

                    if (txtSrch2.Text != null && !txtSrch2.Text.ToString().Equals(""))
                    {
                        condition += " AND B.CUST_CD = '" + txtSrch2.Text + "' ";
                    }
                    DataTable dt = wDm.select_Bill_List_DayOrder(condition);

                    DayGrid.Rows.Clear();
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        DayGrid.RowCount = dt.Rows.Count;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            DayGrid.Rows[i].Cells["코드2"].Value = (dt.Rows[i]["코드"].ToString().Equals("9999999999") ? "" : dt.Rows[i]["코드"].ToString());
                            DayGrid.Rows[i].Cells["매출처명2"].Value = dt.Rows[i]["매출처명"].ToString();
                            DayGrid.Rows[i].Cells["사업자번호2"].Value = dt.Rows[i]["사업자번호"].ToString();
                            DayGrid.Rows[i].Cells["발행일자2"].Value = dt.Rows[i]["발행일자2"].ToString();
                            DayGrid.Rows[i].Cells["발행번호2"].Value = dt.Rows[i]["발행번호"].ToString();
                            DayGrid.Rows[i].Cells["구분2"].Value = dt.Rows[i]["구분"].ToString();
                            DayGrid.Rows[i].Cells["공급가액2"].Value = decimal.Parse(dt.Rows[i]["공급가액"].ToString()).ToString("#,0.######");
                            DayGrid.Rows[i].Cells["부가세2"].Value = decimal.Parse(dt.Rows[i]["부가세"].ToString()).ToString("#,0.######");
                            DayGrid.Rows[i].Cells["합계금액2"].Value = decimal.Parse(dt.Rows[i]["합계금액"].ToString()).ToString("#,0.######");

                            if (dt.Rows[i]["발행번호"].ToString().Equals("0")) DayGrid.Rows[i].Cells["발행번호2"].Value = "";
                            if (dt.Rows[i]["순서"].ToString().Equals("2"))
                            {
                                DataGridViewCellStyle style = new DataGridViewCellStyle();
                                style.BackColor = Color.PaleGoldenrod;
                                style.SelectionBackColor = Color.DarkKhaki;

                                for (int j = 0; j < DayGrid.ColumnCount; j++)
                                {
                                    DayGrid.Rows[i].Cells[j].Style = style;
                                }
                            }

                        }
                    }
                }
                else if (TabControl.SelectedIndex == 2)
                {
                    wnDm wDm = new wnDm();
                    string condition = " WHERE A.SALES_DATE >= '" + start_date.Text + "' and A.SALES_DATE <= '" + end_date.Text + "'   ";

                    if (txtSrch2.Text != null && !txtSrch2.Text.ToString().Equals(""))
                    {
                        condition += " AND B.CUST_CD = '" + txtSrch2.Text + "' ";
                    }
                    DataTable dt = wDm.select_Bill_List_NotEscalation(condition);

                    PublishGrid.Rows.Clear();
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        PublishGrid.RowCount = dt.Rows.Count;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            PublishGrid.Rows[i].Cells["매출일자3"].Value = dt.Rows[i]["매출일자"].ToString();
                            PublishGrid.Rows[i].Cells["번호3"].Value = dt.Rows[i]["번호"].ToString();
                            PublishGrid.Rows[i].Cells["매출처명3"].Value = dt.Rows[i]["매출처명"].ToString();
                            PublishGrid.Rows[i].Cells["상품코드3"].Value = dt.Rows[i]["상품코드"].ToString();
                            PublishGrid.Rows[i].Cells["상품구분3"].Value = dt.Rows[i]["상품구분"].ToString();
                            PublishGrid.Rows[i].Cells["상품명3"].Value = dt.Rows[i]["상품명"].ToString();
                            PublishGrid.Rows[i].Cells["규격3"].Value = dt.Rows[i]["규격"].ToString();
                            PublishGrid.Rows[i].Cells["수량3"].Value = decimal.Parse(dt.Rows[i]["수량"].ToString()).ToString("#,0.######");
                            PublishGrid.Rows[i].Cells["단가3"].Value = decimal.Parse(dt.Rows[i]["단가"].ToString()).ToString("#,0.######");
                            PublishGrid.Rows[i].Cells["금액3"].Value = decimal.Parse(dt.Rows[i]["금액"].ToString()).ToString("#,0.######");
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Exception 오류발생");
            }
        }

        private void total_in_grid_logic()
        {
            try
            {
                wnDm wDm = new wnDm();
                string condition = " WHERE B.BILL_DATE >= '" + start_date.Text + "' and B.BILL_DATE <= '" + end_date.Text + "'   ";

                if (txtSrch2.Text != null && !txtSrch2.Text.ToString().Equals(""))
                {
                    condition += " AND B.CUST_CD = '" + txtSrch2.Text + "' ";
                }
                DataTable dt = wDm.select_Bill_List_CustOrder(condition);

                CustGrid.Rows.Clear();
                if (dt != null && dt.Rows.Count > 0)
                {
                    CustGrid.RowCount = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        CustGrid.Rows[i].Cells["코드"].Value = (dt.Rows[i]["코드"].ToString().Equals("9999999999") ? "" : dt.Rows[i]["코드"].ToString());
                        CustGrid.Rows[i].Cells["매출처명"].Value = dt.Rows[i]["매출처명"].ToString();
                        CustGrid.Rows[i].Cells["사업자번호"].Value = dt.Rows[i]["사업자번호"].ToString();
                        CustGrid.Rows[i].Cells["발행일자"].Value = dt.Rows[i]["발행일자"].ToString();
                        CustGrid.Rows[i].Cells["발행번호"].Value = dt.Rows[i]["발행번호"].ToString();
                        CustGrid.Rows[i].Cells["구분"].Value = dt.Rows[i]["구분"].ToString();
                        CustGrid.Rows[i].Cells["공급가액"].Value = decimal.Parse(dt.Rows[i]["공급가액"].ToString()).ToString("#,0.######");
                        CustGrid.Rows[i].Cells["부가세"].Value = decimal.Parse(dt.Rows[i]["부가세"].ToString()).ToString("#,0.######");
                        CustGrid.Rows[i].Cells["합계금액"].Value = decimal.Parse(dt.Rows[i]["합계금액"].ToString()).ToString("#,0.######");

                        if (dt.Rows[i]["발행번호"].ToString().Equals("0")) CustGrid.Rows[i].Cells["발행번호"].Value = "";
                        if (dt.Rows[i]["순서"].ToString().Equals("2"))
                        {
                            DataGridViewCellStyle style = new DataGridViewCellStyle();
                            style.BackColor = Color.PaleGoldenrod;
                            style.SelectionBackColor = Color.DarkKhaki;

                            for (int j = 0; j < CustGrid.ColumnCount; j++)
                            {
                                CustGrid.Rows[i].Cells[j].Style = style;
                            }
                        }

                    }
                }
                

                condition = " WHERE B.BILL_DATE >= '" + start_date.Text + "' and B.BILL_DATE <= '" + end_date.Text + "'   ";

                if (txtSrch2.Text != null && !txtSrch2.Text.ToString().Equals(""))
                {
                    condition += " AND B.CUST_CD = '" + txtSrch2.Text + "' ";
                }
                dt = wDm.select_Bill_List_DayOrder(condition);

                DayGrid.Rows.Clear();
                if (dt != null && dt.Rows.Count > 0)
                {
                    DayGrid.RowCount = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DayGrid.Rows[i].Cells["코드2"].Value = (dt.Rows[i]["코드"].ToString().Equals("9999999999") ? "" : dt.Rows[i]["코드"].ToString());
                        DayGrid.Rows[i].Cells["매출처명2"].Value = dt.Rows[i]["매출처명"].ToString();
                        DayGrid.Rows[i].Cells["사업자번호2"].Value = dt.Rows[i]["사업자번호"].ToString();
                        DayGrid.Rows[i].Cells["발행일자2"].Value = dt.Rows[i]["발행일자2"].ToString();
                        DayGrid.Rows[i].Cells["발행번호2"].Value = dt.Rows[i]["발행번호"].ToString();
                        DayGrid.Rows[i].Cells["구분2"].Value = dt.Rows[i]["구분"].ToString();
                        DayGrid.Rows[i].Cells["공급가액2"].Value = decimal.Parse(dt.Rows[i]["공급가액"].ToString()).ToString("#,0.######");
                        DayGrid.Rows[i].Cells["부가세2"].Value = decimal.Parse(dt.Rows[i]["부가세"].ToString()).ToString("#,0.######");
                        DayGrid.Rows[i].Cells["합계금액2"].Value = decimal.Parse(dt.Rows[i]["합계금액"].ToString()).ToString("#,0.######");

                        if (dt.Rows[i]["발행번호"].ToString().Equals("0")) DayGrid.Rows[i].Cells["발행번호2"].Value = "";
                        if (dt.Rows[i]["순서"].ToString().Equals("2"))
                        {
                            DataGridViewCellStyle style = new DataGridViewCellStyle();
                            style.BackColor = Color.PaleGoldenrod;
                            style.SelectionBackColor = Color.DarkKhaki;

                            for (int j = 0; j < DayGrid.ColumnCount; j++)
                            {
                                DayGrid.Rows[i].Cells[j].Style = style;
                            }
                        }

                    }
                }
                

                condition = " WHERE A.SALES_DATE >= '" + start_date.Text + "' and A.SALES_DATE <= '" + end_date.Text + "'   ";

                if (txtSrch2.Text != null && !txtSrch2.Text.ToString().Equals(""))
                {
                    condition += " AND B.CUST_CD = '" + txtSrch2.Text + "' ";
                }
                dt = wDm.select_Bill_List_NotEscalation(condition);

                PublishGrid.Rows.Clear();
                if (dt != null && dt.Rows.Count > 0)
                {
                    PublishGrid.RowCount = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        PublishGrid.Rows[i].Cells["매출일자3"].Value = dt.Rows[i]["매출일자"].ToString();
                        PublishGrid.Rows[i].Cells["번호3"].Value = dt.Rows[i]["번호"].ToString();
                        PublishGrid.Rows[i].Cells["매출처명3"].Value = dt.Rows[i]["매출처명"].ToString();
                        PublishGrid.Rows[i].Cells["상품코드3"].Value = dt.Rows[i]["상품코드"].ToString();
                        PublishGrid.Rows[i].Cells["상품구분3"].Value = dt.Rows[i]["상품구분"].ToString();
                        PublishGrid.Rows[i].Cells["상품명3"].Value = dt.Rows[i]["상품명"].ToString();
                        PublishGrid.Rows[i].Cells["규격3"].Value = dt.Rows[i]["규격"].ToString();
                        PublishGrid.Rows[i].Cells["수량3"].Value = decimal.Parse(dt.Rows[i]["수량"].ToString()).ToString("#,0.######");
                        PublishGrid.Rows[i].Cells["단가3"].Value = decimal.Parse(dt.Rows[i]["단가"].ToString()).ToString("#,0.######");
                        PublishGrid.Rows[i].Cells["금액3"].Value = decimal.Parse(dt.Rows[i]["금액"].ToString()).ToString("#,0.######");
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception 오류발생");
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                msg.ShowDialog();
            }
        }

        

        private void grdCellSetting()
        {
            ComInfo comInfo = new ComInfo();
            comInfo.grdCellSetting2(CustGrid);
        }

        private void btn출력_Click(object sender, EventArgs e)
        {
           
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

        private void txt_Srch_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtSrch_KeyDown(object sender, KeyEventArgs e)
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
                    }
                    else return base.ProcessCmdKey(ref msg, keyData);
                    break;
                case Keys.F5:
                    // 단일키 사용시
                    btnSearch.PerformClick();
                    break;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
            return true;
        }

        private void btn_chk_all_Click(object sender, EventArgs e)
        {
            txtSrch.Text = "";
            txtSrch2.Text = "";
            chk_all.Checked = false;
        }
        

       
       
        
    }
}
