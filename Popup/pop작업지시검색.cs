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
    public partial class pop작업지시검색 : Form
    {
        public DataGridView dgv;

        private int iCnt;
        private string strCondition = "";

        public string sCode = "";
        public string sName = "";

        private bool bSearch = false;
        private int intTotalRecords = 0;
        private int intPageSize = 0;
        private int intPageCount = 0;
        private int intCurrentPage = 1;

        private int nPageSize = int.Parse(Common.p_PageSize);

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
        public pop작업지시검색()
        {
            InitializeComponent();
        }
        public pop작업지시검색(int flag)
        {
            InitializeComponent();
            chk미완료.Checked = false;
        }


        private void pop작업지시검색_Load(object sender, EventArgs e)
        {
            getSetting();
            btnSrch.PerformClick();
        }

        private void getSetting() 
        {
            start_date.Text = DateTime.Today.AddMonths(-1).ToString("yyyy-MM-dd");
        }

        private void btnSrch_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" WHERE A.RAW_OUT_YN = 'Y' "); //작업지시관리에서 자재소요가 된것만 생산공정에서 목록에 뜨도록
            sb.AppendLine("AND A.W_INST_DATE >= '" + start_date.Text.ToString() + "' and  A.W_INST_DATE <= '" + end_date.Text.ToString() + "'");
            if (chk미완료.Checked)
            {
                sb.AppendLine("and ISNULL(C.COMPLETE_YN,'N') <> 'Y' ");
            }
            bindData(sb.ToString());
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bindData(string condition)
        {
            this.GridRecord.DataSource = null;
            this.GridRecord.RowCount = 0;

            wnDm wDm = new wnDm();
            DataTable dt = null;
            dt = wDm.fn_Work_List(condition);

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

                GridRecord.Columns[0].DefaultCellStyle.ForeColor = Color.Blue;
                GridRecord.Columns[1].DefaultCellStyle.ForeColor = Color.Blue;
                GridRecord.Columns[2].DefaultCellStyle.ForeColor = Color.Blue;

                GridRecord.Columns[0].Frozen = true;
                GridRecord.Columns[1].Frozen = true;
                GridRecord.Columns[2].Frozen = true;

                GridRecord.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                GridRecord.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                GridRecord.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                GridRecord.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //GridRecord.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                this.dgv = GridRecord;
                this.lblStatus.Text = (intCurrentPage + 1).ToString() + " / " + intPageCount.ToString();

                if (dt.Rows.Count > 0)
                {
                    GridRecord.RowCount = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["CUST_NM"].ToString().Equals("")) GridRecord.Rows[i].Cells[0].Value = "자체생산";
                        else GridRecord.Rows[i].Cells[0].Value = dt.Rows[i]["CUST_NM"].ToString();
                        GridRecord.Rows[i].Cells[1].Value = dt.Rows[i]["LOT_NO"].ToString();
                        GridRecord.Rows[i].Cells[2].Value = dt.Rows[i]["ITEM_NM"].ToString();
                        GridRecord.Rows[i].Cells[3].Value = decimal.Parse(dt.Rows[i]["INST_AMT"].ToString()).ToString("#,0");
                        GridRecord.Rows[i].Cells[4].Value = dt.Rows[i]["ITEM_CD"].ToString();
                        GridRecord.Rows[i].Cells[5].Value = dt.Rows[i]["SPEC"].ToString();
                        GridRecord.Rows[i].Cells[6].Value = dt.Rows[i]["W_INST_DATE"].ToString();
                        GridRecord.Rows[i].Cells[7].Value = dt.Rows[i]["W_INST_CD"].ToString();
                        GridRecord.Rows[i].Cells[8].Value = dt.Rows[i]["CHARGE_AMT"].ToString();
                        GridRecord.Rows[i].Cells[9].Value = dt.Rows[i]["PACK_AMT"].ToString();
                        GridRecord.Rows[i].Cells[10].Value = dt.Rows[i]["COMPLETE_YN"].ToString();
                        GridRecord.Rows[i].Cells[11].Value = dt.Rows[i]["CUST_CD"].ToString();
                        GridRecord.Rows[i].Cells["현재고"].Value = dt.Rows[i]["BAL_STOCK"].ToString();
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

        private void GridRecord_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (GridRecord.CurrentCell == null) return;

                iCnt = GridRecord.CurrentCell.RowIndex;

                dgv.Rows.Add();

                for (int j = 0; j < dgv.ColumnCount; j++)
                {
                    dgv.Rows[0].Cells[j].Value = GridRecord.Rows[iCnt].Cells[j].Value;
                }

                sCode = "" + (string)GridRecord.Rows[iCnt].Cells[0].Value;

                this.Close();
            }
        }
    }
}
