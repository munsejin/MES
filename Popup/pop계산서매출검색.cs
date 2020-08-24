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

namespace MES.Popup
{
    public partial class pop계산서매출검색 : Form
    {
        private int iCnt;
        private string strCondition = "";
        
        public string sCode = "";
        public string sName = "";
        public string sInUnit = "";
        public string sOutUnit = "";
        public string sInUnitNm = "";
        public string sOutUnitNm = "";
        public string sCustGbn = "";
        public string sCustNm = "";
        public string sVatCd = "";
        public string sStaffCd = "";


        private bool bSearch = false;
        private int intTotalRecords = 0;
        private int intPageSize = 0;
        private int intPageCount = 0;
        private int intCurrentPage = 1;

        public DataTable rsTable = new DataTable();
        public DataGridView compareGrid = new DataGridView();


        private int nPageSize = int.Parse(Common.p_PageSize);
        public pop계산서매출검색()
        {
            InitializeComponent();
        }

        private void pop계산서매출검색_Load(object sender, EventArgs e)
        {
            ComInfo.gridHeaderSet(GridRecord);
            start_date.Text = DateTime.Now.ToString().Substring(0, 8) + "01";
            lbl_cust_nm.Text = sName;

            ComInfo cominfo = new ComInfo();
            wnGConstant wConst = new wnGConstant();
            string sqlQuery = "";

            cmb_vat_cd.ValueMember = "코드";
            cmb_vat_cd.DisplayMember = "명칭";
            sqlQuery = cominfo.queryVatAll();
            wConst.ComboBox_Read_NoBlank(cmb_vat_cd, sqlQuery);

            cmb_vat_cd.SelectedValue = sVatCd;
            rsTable.Columns.Add("매출일자");
            rsTable.Columns.Add("번호");
            rsTable.Columns.Add("순번");
            rsTable.Columns.Add("부가세구분");
            rsTable.Columns.Add("상품명");
            rsTable.Columns.Add("규격");
            rsTable.Columns.Add("총수량");
            rsTable.Columns.Add("단가");
            rsTable.Columns.Add("금액");
            rsTable.Columns.Add("상품코드");
            rsTable.Columns.Add("상품구분");

            bindData("where B.CUST_CD = '"+sCode+"' and A.SALES_DATE >= '"+start_date.Text+"' and A.SALES_DATE <= '"+end_date.Text+"'  and A.ESCALATION_YN = 'N' ");
        }

        private void bindData(string condition)
        {
            this.GridRecord.DataSource = null;
            this.GridRecord.RowCount = 0;

            wnDm wDm = new wnDm();
            DataTable dt = null;
            dt = wDm.fn_Sales_Detail_List(condition, cmb_vat_cd.SelectedValue.ToString());

            // For Page view.
            intPageSize = nPageSize;
            intTotalRecords = getCount(dt);
            intPageCount = intTotalRecords / intPageSize;

            // Adjust page count if the last page contains partial page.
            if (intTotalRecords % intPageSize > 0)
                intPageCount++;

            intCurrentPage = 0;

            cmbPage.Items.Clear();
            if (intTotalRecords == 0)
            {
                cmbPage.Items.Add("1");
            }
            else
            {
                for (int kk = 0; kk < intPageCount; kk++)
                {
                    cmbPage.Items.Add((kk + 1).ToString());
                }
            }
            cmbPage.SelectedIndex = 0;

            loadPage(dt);
        }

        private int getCount(DataTable dt)
        {
            int intCount = 0;

            if (dt != null)
            {
                intCount = dt.Rows.Count;
            }

            return intCount;
        }

        private void loadPage(DataTable dt)
        {
            this.lblStatus.Text = "- / -";

            try
            {
                int intSkip = 0;
                intSkip = (intCurrentPage * intPageSize);

                if (dt.Rows.Count > 0)
                {
                    int GridRecord_IndexTemp = 0;
                    GridRecord.Rows.Clear();
                    bool isMatch = false;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        isMatch = false;
                        for (int j = 0; j < compareGrid.Rows.Count; j++)
                        {
                            if (compareGrid.Rows[j].Cells["SALES_DATE"].Value == null || compareGrid.Rows[j].Cells["SALES_DATE"].Value.ToString().Equals(""))
                            {
                                continue;
                            }
                            else if(dt.Rows[i]["SALES_DATE"].ToString().Equals(compareGrid.Rows[j].Cells["SALES_DATE"].Value.ToString())
                                && dt.Rows[i]["SALES_CD"].ToString().Equals(compareGrid.Rows[j].Cells["SALES_CD"].Value.ToString())
                                && dt.Rows[i]["SEQ"].ToString().Equals(compareGrid.Rows[j].Cells["SALES_SEQ"].Value.ToString()))
                            {
                                isMatch = true;
                                break;
                            }
                        }
                        if (isMatch)
                        {
                            continue;
                        }
                        GridRecord.Rows.Add();
                        GridRecord.Rows[GridRecord_IndexTemp].Cells["CHECK"].Value = false;
                        GridRecord.Rows[GridRecord_IndexTemp].Cells["매출일자"].Value = dt.Rows[i]["SALES_DATE"].ToString();
                        GridRecord.Rows[GridRecord_IndexTemp].Cells["번호"].Value = dt.Rows[i]["SALES_CD"].ToString();
                        GridRecord.Rows[GridRecord_IndexTemp].Cells["순번"].Value = dt.Rows[i]["SEQ"].ToString();
                        GridRecord.Rows[GridRecord_IndexTemp].Cells["부가세구분"].Value = dt.Rows[i]["TAX_NM"].ToString();
                        GridRecord.Rows[GridRecord_IndexTemp].Cells["상품명"].Value = dt.Rows[i]["PRODUCT_NM"].ToString();
                        GridRecord.Rows[GridRecord_IndexTemp].Cells["규격"].Value = dt.Rows[i]["SPEC"].ToString();
                        GridRecord.Rows[GridRecord_IndexTemp].Cells["총수량"].Value = decimal.Parse(dt.Rows[i]["TOTAL_AMT"].ToString()).ToString("#,0.######");
                        GridRecord.Rows[GridRecord_IndexTemp].Cells["단가"].Value = decimal.Parse(dt.Rows[i]["TOTAL_PRICE"].ToString()).ToString("#,0.######");
                        GridRecord.Rows[GridRecord_IndexTemp].Cells["금액"].Value = decimal.Parse(dt.Rows[i]["TOTAL_MONEY"].ToString()).ToString("#,0.######");
                        GridRecord.Rows[GridRecord_IndexTemp].Cells["상품코드"].Value = dt.Rows[i]["PRODUCT_CD"].ToString();
                        GridRecord.Rows[GridRecord_IndexTemp].Cells["상품구분"].Value = dt.Rows[i]["PRODUCT_GUBUN"].ToString();
                        GridRecord_IndexTemp++;
                    }
                }
                else 
                {
                    GridRecord.Rows.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("검색중에 오류가 발생했습니다.");
                wnLog.writeLog(wnLog.LOG_ERROR, ex.Message + " - " + ex.ToString());
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                msg.ShowDialog();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            bindData("where B.CUST_CD = '" + sCode + "' and A.SALES_DATE >= '" + start_date.Text + "' and A.SALES_DATE <= '" + end_date.Text + "'  and A.ESCALATION_YN = 'N' ");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_srch_sale_or_soo_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < GridRecord.Rows.Count; i++)
            {
                if ((bool)GridRecord.Rows[i].Cells["CHECK"].Value == true)
                {
                    rsTable.Rows.Add();
                    rsTable.Rows[rsTable.Rows.Count-1]["매출일자"] =  GridRecord.Rows[i].Cells["매출일자"].Value.ToString();
                    rsTable.Rows[rsTable.Rows.Count-1]["번호"]=       GridRecord.Rows[i].Cells["번호"].Value.ToString();
                    rsTable.Rows[rsTable.Rows.Count-1]["순번"]=       GridRecord.Rows[i].Cells["순번"].Value.ToString();  
                    rsTable.Rows[rsTable.Rows.Count-1]["부가세구분"]= GridRecord.Rows[i].Cells["부가세구분"].Value.ToString();
                    rsTable.Rows[rsTable.Rows.Count-1]["상품명"]=     GridRecord.Rows[i].Cells["상품명"].Value.ToString(); 
                    rsTable.Rows[rsTable.Rows.Count-1]["규격"]=       GridRecord.Rows[i].Cells["규격"].Value.ToString();   
                    rsTable.Rows[rsTable.Rows.Count-1]["총수량"]=     GridRecord.Rows[i].Cells["총수량"].Value.ToString();
                    rsTable.Rows[rsTable.Rows.Count-1]["단가"]=       GridRecord.Rows[i].Cells["단가"].Value.ToString();   
                    rsTable.Rows[rsTable.Rows.Count-1]["금액"]=       GridRecord.Rows[i].Cells["금액"].Value.ToString();
                    rsTable.Rows[rsTable.Rows.Count - 1]["상품코드"] = GridRecord.Rows[i].Cells["상품코드"].Value.ToString();
                    rsTable.Rows[rsTable.Rows.Count - 1]["상품구분"] = GridRecord.Rows[i].Cells["상품구분"].Value.ToString();
                }
            }
            this.Close();
        }

        private void GridRecord_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                if (GridRecord.Columns[e.ColumnIndex].Name.Equals("CHECK"))
                {
                    lbl_cust_nm.Focus();
                    if (GridRecord.Columns[e.ColumnIndex].HeaderText.Equals("[ ]"))
                    {
                        GridRecord.Columns[e.ColumnIndex].HeaderText = "[v]";
                        for (int i = 0; i < GridRecord.Rows.Count; i++)
                        {
                            GridRecord.Rows[i].Cells["CHECK"].Value = true;
                        }
                    }
                    else
                    {
                        GridRecord.Columns[e.ColumnIndex].HeaderText = "[ ]";
                        for (int i = 0; i < GridRecord.Rows.Count; i++)
                        {
                            GridRecord.Rows[i].Cells["CHECK"].Value = false;
                        }
                    }

                }
            }
        }





    }
}
