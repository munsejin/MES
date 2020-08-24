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
    public partial class pop거래처검색 : Form
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
        public string sBalance = "";
        public string sStaffCd = "";

        public string s자재입고 = "";

        private bool bSearch = false;
        private int intTotalRecords = 0;
        private int intPageSize = 0;
        private int intPageCount = 0;
        private int intCurrentPage = 1;
        private string[] autoSelect;
        /// <summary>
        /// 마우스로 폼 움직이도록 하는 코드
        /// </summary>
        private Point mCurrentPosition = new Point(0, 0); //

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
                mCurrentPosition = new Point(-e.X, -e.Y);

        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(
                    this.Location.X + (mCurrentPosition.X + e.X),
                    this.Location.Y + (mCurrentPosition.Y + e.Y));// 마우스의 이동치를 Form Location에 반영한다.
            }
        }
        private int nPageSize = int.Parse(Common.p_PageSize);
        public pop거래처검색()
        {
            InitializeComponent();
        }
        
        public pop거래처검색(String title)
        {
            InitializeComponent();
            lblTitle.Text = title + " 검색";
        }

        public pop거래처검색(String title,String cust_nm)
        {
            InitializeComponent();
            lblTitle.Text = title + " 검색";
            sCustNm = cust_nm;
        }

        private void pop거래처검색_Load(object sender, EventArgs e)
        {
            if (s자재입고.Equals("1"))
            {
                bindData(" INNER JOIN (SELECT CUST_CD, COMPLETE_YN FROM F_ORDER WHERE COMPLETE_YN = 'N' GROUP BY CUST_CD, COMPLETE_YN  ) B ON B.CUST_CD = A.CUST_CD AND B.COMPLETE_YN = 'N' where CUST_GUBUN = '" + sCustGbn + "' and CUST_NM LIKE '%" + sCustNm + "%'   ");
            }
            else
            {
                bindData("where CUST_GUBUN = '" + sCustGbn + "' and CUST_NM LIKE '%" + sCustNm + "%' ");
            }
            if (sCustGbn.Equals("1"))
            {
                lblTitle.Text = "매출처 검색";
            }
            else if (sCustGbn.Equals("2"))
            {
                lblTitle.Text = "구매처 검색";
            }
            else
            {
                lblTitle.Text = "거래처 검색";
            }
        }

        private void bindData(string condition)
        {
            this.GridRecord.DataSource = null;
            this.GridRecord.RowCount = 0;

            condition += " and USED_CD = '1' ";
            wnDm wDm = new wnDm();
            DataTable dt = null;
            dt = wDm.fn_Cust_List(condition);

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

            autoSelect = new string[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string custName = dt.Rows[i]["CUST_NM"].ToString();
                autoSelect[i] = custName;
            }
            var source = new AutoCompleteStringCollection();
            source.AddRange(autoSelect);
            txtSrch.AutoCompleteCustomSource = source;
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

                GridRecord.Columns[0].DefaultCellStyle.ForeColor = Color.Blue;
                GridRecord.Columns[1].DefaultCellStyle.ForeColor = Color.Blue;
                GridRecord.Columns[2].DefaultCellStyle.ForeColor = Color.Blue;

                GridRecord.Columns[0].Frozen = true;
                GridRecord.Columns[1].Frozen = true;
                GridRecord.Columns[2].Frozen = true;

                GridRecord.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                GridRecord.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                GridRecord.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                GridRecord.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                GridRecord.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                GridRecord.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                GridRecord.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                GridRecord.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                GridRecord.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                this.lblStatus.Text = (intCurrentPage + 1).ToString() + " / " + intPageCount.ToString();

                if (dt!= null && dt.Rows.Count > 0)
                {
                    GridRecord.RowCount = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        if (dt.Rows[i]["USED_CD"].ToString().Equals("2"))
                        {
                            GridRecord.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                        }
                        else if (dt.Rows[i]["USED_CD"].ToString().Equals("3"))
                        {
                            GridRecord.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                        }
                        else if (dt.Rows[i]["USED_CD"].ToString().Equals("1"))
                        {
                            GridRecord.Rows[i].DefaultCellStyle.BackColor = Color.Empty;
                        }

                        GridRecord.Rows[i].Cells[0].Value = dt.Rows[i]["CUST_CD"].ToString();
                        GridRecord.Rows[i].Cells[1].Value = dt.Rows[i]["CUST_GUBUN_NM"].ToString();
                        GridRecord.Rows[i].Cells[2].Value = dt.Rows[i]["CUST_NM"].ToString();
                        GridRecord.Rows[i].Cells[3].Value = dt.Rows[i]["SAUP_NO"].ToString();
                        GridRecord.Rows[i].Cells[4].Value = dt.Rows[i]["UPTAE"].ToString();
                        GridRecord.Rows[i].Cells[5].Value = dt.Rows[i]["JONGMOK"].ToString();
                        GridRecord.Rows[i].Cells[6].Value = dt.Rows[i]["CUST_MANAGER"].ToString();
                        GridRecord.Rows[i].Cells[7].Value = dt.Rows[i]["CUST_COMP_PHONE"].ToString();
                        GridRecord.Rows[i].Cells[8].Value = dt.Rows[i]["STAFF_NM"].ToString();
                        GridRecord.Rows[i].Cells[9].Value = dt.Rows[i]["TAX_CD"].ToString();
                        GridRecord.Rows[i].Cells[10].Value = dt.Rows[i]["CUST_EMAIL"].ToString();
                        GridRecord.Rows[i].Cells[11].Value = dt.Rows[i]["BALANCE"].ToString();
                        GridRecord.Rows[i].Cells[12].Value = dt.Rows[i]["STAFF_CD"].ToString();
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
            bindData("where CUST_GUBUN = '" + sCustGbn + "' and  CUST_NM like '%" + txtSrch.Text.ToString() + "%' ");
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GridRecord_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                sCode = GridRecord.Rows[e.RowIndex].Cells[0].Value.ToString();
                sName = GridRecord.Rows[e.RowIndex].Cells[2].Value.ToString();
                sVatCd = GridRecord.Rows[e.RowIndex].Cells[9].Value.ToString();
                sBalance = GridRecord.Rows[e.RowIndex].Cells[11].Value.ToString();
                sStaffCd = GridRecord.Rows[e.RowIndex].Cells[12].Value.ToString();
                this.Close();
            }            
        }
    }
}
