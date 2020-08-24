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
    public partial class pop계산서수금검색 : Form
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
        public pop계산서수금검색()
        {
            InitializeComponent();
        }

        private void pop계산서수금검색_Load(object sender, EventArgs e)
        {
            ComInfo.gridHeaderSet(GridRecord);
            start_date.Text = DateTime.Now.ToString().Substring(0, 8) + "01";
            lbl_cust_nm.Text = sName;

            ComInfo cominfo = new ComInfo();
            wnGConstant wConst = new wnGConstant();
            string sqlQuery = "";

            rsTable.Columns.Add("수금일자");
            rsTable.Columns.Add("번호");
            rsTable.Columns.Add("수금액");
            rsTable.Columns.Add("할인액");
            rsTable.Columns.Add("합계금액");
            rsTable.Columns.Add("비고");
            rsTable.Columns.Add("구분");

            bindData("where A.CUST_CD = '" + sCode + "' and A.SOO_DATE >= '" + start_date.Text + "' and A.SOO_DATE <= '" + end_date.Text + "'  ");
        }

        private void bindData(string condition)
        {
            this.GridRecord.DataSource = null;
            this.GridRecord.RowCount = 0;

            wnDm wDm = new wnDm();
            DataTable dt = new DataTable();
            dt = wDm.fn_Collect_list(condition);

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
                            if (compareGrid.Rows[j].Cells["SOO_DATE"].Value == null || compareGrid.Rows[j].Cells["SOO_DATE"].Value.ToString().Equals(""))
                            {
                                continue;
                            }
                            else if (dt.Rows[i]["SOO_DATE"].ToString().Equals(compareGrid.Rows[j].Cells["SOO_DATE"].Value.ToString())
                                && dt.Rows[i]["SOO_CD"].ToString().Equals(compareGrid.Rows[j].Cells["SOO_CD"].Value.ToString()))
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
                        GridRecord.Rows[GridRecord_IndexTemp].Cells["수금일자"].Value = dt.Rows[i]["SOO_DATE"].ToString();
                        GridRecord.Rows[GridRecord_IndexTemp].Cells["번호"].Value = dt.Rows[i]["SOO_CD"].ToString();
                        GridRecord.Rows[GridRecord_IndexTemp].Cells["수금액"].Value = decimal.Parse(dt.Rows[i]["SOO_MONEY"].ToString()).ToString("#,0.######");
                        GridRecord.Rows[GridRecord_IndexTemp].Cells["할인액"].Value = decimal.Parse(dt.Rows[i]["DC_MONEY"].ToString()).ToString("#,0.######");
                        GridRecord.Rows[GridRecord_IndexTemp].Cells["합계금액"].Value = decimal.Parse(dt.Rows[i]["TOTAL_MONEY"].ToString()).ToString("#,0.######");
                        GridRecord.Rows[GridRecord_IndexTemp].Cells["구분"].Value = dt.Rows[i]["SOO_GUBUN_NM"].ToString();
                        GridRecord.Rows[GridRecord_IndexTemp].Cells["비고"].Value = dt.Rows[i]["COMMENT"].ToString();
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
            bindData("where A.CUST_CD = '" + sCode + "' and A.SOO_DATE >= '" + start_date.Text + "' and A.SOO_DATE <= '" + end_date.Text + "'  ");
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
                    rsTable.Rows[rsTable.Rows.Count - 1]["수금일자"] = GridRecord.Rows[i].Cells["수금일자"].Value.ToString();
                    rsTable.Rows[rsTable.Rows.Count-1]["번호"]=       GridRecord.Rows[i].Cells["번호"].Value.ToString();
                    rsTable.Rows[rsTable.Rows.Count - 1]["구분"] = GridRecord.Rows[i].Cells["구분"].Value.ToString();
                    rsTable.Rows[rsTable.Rows.Count - 1]["비고"] = GridRecord.Rows[i].Cells["비고"].Value.ToString();
                    rsTable.Rows[rsTable.Rows.Count - 1]["수금액"] = GridRecord.Rows[i].Cells["수금액"].Value.ToString();
                    rsTable.Rows[rsTable.Rows.Count - 1]["할인액"] = GridRecord.Rows[i].Cells["할인액"].Value.ToString();
                    rsTable.Rows[rsTable.Rows.Count - 1]["합계금액"] = GridRecord.Rows[i].Cells["합계금액"].Value.ToString();   
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
