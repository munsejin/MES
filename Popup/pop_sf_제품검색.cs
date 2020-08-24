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
    public partial class pop_sf_제품검색 : Form
    {
        private int iCnt;
        private string strCondition = "";
        public string sCode = "";
        public string sName = "";
        public string sSpec = "";
        public string sUnitCd = "";
        public string sUnitNm = "";
        public string sCharge = "";
        public string sPack = "";
        public string sInputPrice = "";
        public string sOutputPrice = "";
        public string sRetFlowYN = "";
        public string sBAL_STOCK = "";
        public string mold = "";
        public string sVatCd = "";
        private bool bSearch = false;
        private int intTotalRecords = 0;
        private int intPageSize = 0;
        private int intPageCount = 0;
        private int intCurrentPage = 1;
        private string strCUST_cd;
        private int nPageSize = int.Parse(Common.p_PageSize);

        public string HalfItemSearch = "";
        public List<int> list = new List<int>();
        public DataTable dt = new DataTable();
        public pop_sf_제품검색()

        {
            InitializeComponent();
           
        }

        public pop_sf_제품검색(String CUST_cd)
        {
            InitializeComponent();
            this.strCUST_cd = CUST_cd;

        }
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
        private void pop_sf_제품검색_Load(object sender, EventArgs e)
        {            
           // bindData("");
            if (HalfItemSearch.Equals("0"))
            {
                HalfItem();
            }
            else
            {
                 btnSearch.PerformClick();
            }
        }

        private void HalfItem()
        {
            if (dt.Rows.Count > 0)
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
                    GridRecord.Rows[i].Cells[0].Value = dt.Rows[i]["ITEM_CD"].ToString();
                    GridRecord.Rows[i].Cells[1].Value = dt.Rows[i]["ITEM_NM"].ToString();
                    GridRecord.Rows[i].Cells[2].Value = dt.Rows[i]["ITEM_GUBUN_NM"].ToString();
                    GridRecord.Rows[i].Cells[3].Value = dt.Rows[i]["SPEC"].ToString();
                    GridRecord.Rows[i].Cells[4].Value = dt.Rows[i]["TYPE_NM"].ToString();
                    GridRecord.Rows[i].Cells[5].Value = dt.Rows[i]["UNIT_NM"].ToString();
                    GridRecord.Rows[i].Cells[6].Value = dt.Rows[i]["LINE_NM"].ToString();
                    GridRecord.Rows[i].Cells[7].Value = decimal.Parse(dt.Rows[i]["INPUT_PRICE"].ToString()).ToString("#,0.######");
                    GridRecord.Rows[i].Cells[8].Value = decimal.Parse(dt.Rows[i]["OUTPUT_PRICE"].ToString()).ToString("#,0.######");
                    GridRecord.Rows[i].Cells[9].Value = dt.Rows[i]["BAL_STOCK"].ToString();
                    GridRecord.Rows[i].Cells[10].Value = dt.Rows[i]["UNIT_CD"].ToString();
                    GridRecord.Rows[i].Cells[11].Value = dt.Rows[i]["CHARGE_AMT"].ToString();
                    GridRecord.Rows[i].Cells[12].Value = dt.Rows[i]["PACK_AMT"].ToString();
                   // GridRecord.Rows[i].Cells["CUST_CD"].Value = dt.Rows[i]["CUST_CD"].ToString();
                    //GridRecord.Rows[i].Cells["CUST_NM"].Value = dt.Rows[i]["CUST_NM"].ToString();
                }
            }
            else
            {
                GridRecord.Rows.Clear();
            }
        }

        private void bindData(string condition)
        {
            this.GridRecord.DataSource = null;
            this.GridRecord.RowCount = 0;

            if (Common.p_saupNo=="1278113487")
            {
                
                condition += "and A.CUST_CD like '%" + strCUST_cd + "%'";
                
            }

            condition += " and A.USED_CD = '1' ";
            
            wnDm wDm = new wnDm();
            DataTable dt = null;
                  
            dt = wDm.fn_Item_List(condition, strCUST_cd);

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

                GridRecord.Columns[0].Frozen = true;
                GridRecord.Columns[1].Frozen = true;

                GridRecord.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                GridRecord.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                GridRecord.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
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
                        GridRecord.Rows[i].Cells[0].Value = dt.Rows[i]["ITEM_CD"].ToString();
                        GridRecord.Rows[i].Cells[1].Value = dt.Rows[i]["ITEM_NM"].ToString();
                        GridRecord.Rows[i].Cells[2].Value = dt.Rows[i]["ITEM_GUBUN_NM"].ToString();
                        GridRecord.Rows[i].Cells[3].Value = dt.Rows[i]["SPEC"].ToString();
                        GridRecord.Rows[i].Cells[4].Value = dt.Rows[i]["TYPE_NM"].ToString();
                        GridRecord.Rows[i].Cells[5].Value = dt.Rows[i]["UNIT_NM"].ToString();
                        GridRecord.Rows[i].Cells[6].Value = dt.Rows[i]["LINE_NM"].ToString();
                        GridRecord.Rows[i].Cells[7].Value = decimal.Parse(dt.Rows[i]["INPUT_PRICE"].ToString()).ToString("#,0.######");
                        GridRecord.Rows[i].Cells[8].Value = decimal.Parse(dt.Rows[i]["OUTPUT_PRICE"].ToString()).ToString("#,0.######");
                        GridRecord.Rows[i].Cells[9].Value = dt.Rows[i]["BAL_STOCK"].ToString();
                        GridRecord.Rows[i].Cells[10].Value = dt.Rows[i]["UNIT_CD"].ToString();
                        GridRecord.Rows[i].Cells[11].Value = dt.Rows[i]["CHARGE_AMT"].ToString();
                        GridRecord.Rows[i].Cells[12].Value = dt.Rows[i]["PACK_AMT"].ToString();
                        GridRecord.Rows[i].Cells["CUST_CD"].Value = dt.Rows[i]["CUST_CD"].ToString();
                        GridRecord.Rows[i].Cells["CUST_NM"].Value = dt.Rows[i]["CUST_NM"].ToString();
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
                Console.WriteLine(ex);
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                msg.ShowDialog();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            bindData("where ITEM_NM like  '%" + txtSrch.Text.ToString() + "%'");
            

        }

        private void GridRecord_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                sCode = GridRecord.Rows[e.RowIndex].Cells["ITEM_CD"].Value.ToString();
                sName = GridRecord.Rows[e.RowIndex].Cells["ITEM_NM"].Value.ToString();
                sSpec = GridRecord.Rows[e.RowIndex].Cells["SPEC"].Value.ToString();
                sUnitCd = GridRecord.Rows[e.RowIndex].Cells["UNIT_CD"].Value.ToString();
                sUnitNm = GridRecord.Rows[e.RowIndex].Cells["UNIT_NM"].Value.ToString();
                sOutputPrice = GridRecord.Rows[e.RowIndex].Cells["OUTPUT_PRICE"].Value.ToString();
                sCharge = GridRecord.Rows[e.RowIndex].Cells["CHARGE_AMT"].Value.ToString();
                sPack = GridRecord.Rows[e.RowIndex].Cells["PACK_AMT"].Value.ToString();
                sBAL_STOCK = GridRecord.Rows[e.RowIndex].Cells["BAL_STOCK"].Value.ToString();
                if (GridRecord.Rows[e.RowIndex].Cells["VAT_CD"].Value == null) GridRecord.Rows[e.RowIndex].Cells["VAT_CD"].Value = "1";
                sVatCd = GridRecord.Rows[e.RowIndex].Cells["VAT_CD"].Value.ToString();
                //mold = dt.Rows[e.RowIndex]["MOLD_CD"].ToString() ?? "";

                SendKeys.Send("{TAB}");
                this.Close();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GridRecord_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtSrch_TextChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void GridRecord_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (GridRecord.SelectedRows.Count > 1)
            {
                for (int i = 0; i < GridRecord.SelectedRows.Count; i++)
                {
                    list.Add(GridRecord.SelectedRows[i].Index);
                }
            }

            else
            {
                for (int idx = 0; idx < GridRecord.Rows.Count; idx++)
                {
                    if (GridRecord.Rows[idx].Cells["CHK"].Value != null && (bool)GridRecord.Rows[idx].Cells["CHK"].Value)
                    {
                        list.Add(idx);
                    }
                }
            }

            this.Close();
        }

        private void GridRecord_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (GridRecord.Columns[e.ColumnIndex].Name.ToString().Equals("CHK"))
            {
                if (GridRecord.Columns[e.ColumnIndex].HeaderText.ToString().Equals("[ ]"))
                {
                    for (int i = 0; i < GridRecord.Rows.Count; i++)
                    {
                        GridRecord.Rows[i].Cells["CHK"].Value = (bool)true;
                    }
                    GridRecord.Columns[e.ColumnIndex].HeaderText = "[v]";
                }
                else
                {
                    for (int i = 0; i < GridRecord.Rows.Count; i++)
                    {
                        GridRecord.Rows[i].Cells["CHK"].Value = (bool)false;
                    }
                    GridRecord.Columns[e.ColumnIndex].HeaderText = "[ ]";
                }
            }
        }
    }
}
