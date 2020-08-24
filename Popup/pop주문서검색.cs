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
using System.Collections;

namespace MES.Popup
{
    public partial class pop주문서검색 : Form
    {
        private int iCnt;

        public string sjumun_date = "";
        public string sjumun_cd = "";
        public string sjumun_comment = "";
        public string scust_cd = "";
        public string scust_nm = "";
        public string svat_cd = "";
        public string sreq_date = "";

        private bool bSearch = false;
        private int intTotalRecords = 0;
        private int intPageSize = 0;
        private int intPageCount = 0;
        private int intCurrentPage = 1;
        public ArrayList rowIndexArr = new ArrayList();
        private string[] autoSelect;
        /// <summary>
        /// 마우스로 폼 움직이도록 하는 코드
        /// </summary>
        private Point mCurrentPosition = new Point(0, 0); //


        public string plan_gubun = "";

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
        public pop주문서검색()
        {
            InitializeComponent();
        }

        public pop주문서검색(bool flag)
        {
            InitializeComponent();
            if (flag)
            {
                btnSave.Visible = true;
                GridRecord.Columns["CHK"].Visible = true;
            }
        }
        
        public pop주문서검색(String title)
        {
            InitializeComponent();
            
        }

        public pop주문서검색(String title,String cust_nm)
        {
            InitializeComponent();
        }

        private void pop주문서검색_Load(object sender, EventArgs e)
        {
            bindData("where 1=1 ");
        }

        private void bindData(string condition)
        {
            this.GridRecord.DataSource = null;
            this.GridRecord.RowCount = 0;

            wnDm wDm = new wnDm();
            DataTable dt = null;
            /*생산계획등록에서 주문서 검색 시*/
            if (plan_gubun.Equals("1"))
            {
                dt = wDm.select_jumun_list(" AND A.COMPLETE_YN is not null and A.COMPLETE_YN = 'N' AND A.PLAN_DATE IS NULL ");
            }
            else
            {
                dt = wDm.select_jumun_list(" AND A.COMPLETE_YN is not null and A.COMPLETE_YN = 'N' ");

            }

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

                this.lblStatus.Text = (intCurrentPage + 1).ToString() + " / " + intPageCount.ToString();

                if (dt.Rows.Count > 0)
                {
                    GridRecord.RowCount = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        GridRecord.Rows[i].Cells["JUMUN_DATE"].Value = dt.Rows[i]["JUMUN_DATE"].ToString();
                        GridRecord.Rows[i].Cells["JUMUN_CD"].Value = dt.Rows[i]["JUMUN_CD"].ToString();
                        GridRecord.Rows[i].Cells["CUST_CD"].Value = dt.Rows[i]["CUST_CD"].ToString();
                        GridRecord.Rows[i].Cells["CUST_NM"].Value = dt.Rows[i]["CUST_NM"].ToString();
                        GridRecord.Rows[i].Cells["RQ_DATE"].Value = dt.Rows[i]["RQ_DATE"].ToString();
                        GridRecord.Rows[i].Cells["COMMENT"].Value = dt.Rows[i]["COMMENT"].ToString();
                        GridRecord.Rows[i].Cells["ITEM_NM"].Value = dt.Rows[i]["ITEM_NM"].ToString();
                        GridRecord.Rows[i].Cells["VAT_CD"].Value = dt.Rows[i]["VAT_CD"].ToString();
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
            bindData("where 1=1 ");
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            plan_gubun = "";
            this.Close();
        }

        private void GridRecord_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                sjumun_date = GridRecord.Rows[e.RowIndex].Cells["JUMUN_DATE"].Value.ToString();
                sjumun_cd = GridRecord.Rows[e.RowIndex].Cells["JUMUN_CD"].Value.ToString();
                sjumun_comment = GridRecord.Rows[e.RowIndex].Cells["COMMENT"].Value.ToString();
                scust_cd = GridRecord.Rows[e.RowIndex].Cells["CUST_CD"].Value.ToString();
                scust_nm = GridRecord.Rows[e.RowIndex].Cells["CUST_NM"].Value.ToString();
                svat_cd = GridRecord.Rows[e.RowIndex].Cells["VAT_CD"].Value.ToString();
                sreq_date = GridRecord.Rows[e.RowIndex].Cells["RQ_DATE"].Value.ToString();

                plan_gubun = "";

                this.Close();
            }            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < GridRecord.Rows.Count; i++)
            {
                if (GridRecord.Rows[i].Cells["CHK"].Value != null && (bool)GridRecord.Rows[i].Cells["CHK"].Value == true)
                {
                    rowIndexArr.Add(i);
                }
            }
            this.Close();
            //return;
        }

        private void GridRecord_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex == 8)
            {
                if (GridRecord.Columns["CHK"].HeaderText.ToString().Equals("[ ]"))
                {
                    for (int i = 0; i < GridRecord.Rows.Count; i++)
                    {
                        GridRecord.Rows[i].Cells["CHK"].Value = true;
                    }
                    GridRecord.Columns["CHK"].HeaderText = "[v]";
                }
                else
                {
                    for (int i = 0; i < GridRecord.Rows.Count; i++)
                    {
                        GridRecord.Rows[i].Cells["CHK"].Value = false;
                    }
                    GridRecord.Columns["CHK"].HeaderText = "[ ]";
                }
            }
        }
    }
}
