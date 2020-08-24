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
    public partial class pop발주원자재검색 : Form
    {
        private int iCnt;
        private string strCondition = "";
        public string sRetCode = "";
        public string sRetNM = "";

        public string s자재입고 = "";

        public DataGridView dgv;
        private bool bSearch = false;
        private int intTotalRecords = 0;
        private int intPageSize = 0;
        private int intPageCount = 0;
        private int intCurrentPage = 1;
        private int nPageSize = int.Parse(Common.p_PageSize);
        private Point mCurrentPosition = new Point(0, 0); //
        private int gubun = 0;

        public String strCUST_CD = "";
        private wnGConstant wConst = new wnGConstant();
        private ComInfo comInfo = new ComInfo();

        public List<int> list = new List<int>();
        string[] autoSelect;
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
        public DataTable dt = new DataTable();

        public pop발주원자재검색()
        {
            InitializeComponent();
            wnDm wndm = new wnDm();
            DataTable dt =  wndm.fn_Raw_Name_List();
            autoSelect = new string[dt.Rows.Count];
            for(int i  = 0 ; i < dt.Rows.Count ;i ++)
            {
                autoSelect[i] = dt.Rows[i]["RAW_MAT_CD"].ToString();
            }
            var source = new AutoCompleteStringCollection();
            source.AddRange(autoSelect);
            txtSrch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtSrch.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtSrch.AutoCompleteCustomSource = source;
        }
        public pop발주원자재검색(String CUST_CD)
        {
            InitializeComponent();
            strCUST_CD = CUST_CD;
        }

        private void pop발주원자재검색_Load(object sender, EventArgs e)
        {
            string sqlQuery = "";
            if (strCUST_CD == null || strCUST_CD == "" && gubun == 2)
                gubun = 1;

            gubun = Properties.Settings.Default.rawSelect;
            cmb_option.SelectedIndex = gubun;
            cbo자재구분.ValueMember = "코드";
            cbo자재구분.DisplayMember = "명칭";
            StringBuilder sb = new StringBuilder();
            sqlQuery = comInfo.queryRawList();
            wConst.ComboBox_Read_ALL(cbo자재구분, sqlQuery);

            //cbo자재구분.range = 2;

            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            // strCondition = this.makeSearchCondition();
            this.bindData();
            
            btnSearch.PerformClick();
        }

        private void bindData()
        {
            this.GridRecord.DataSource = null;
            this.GridRecord.RowCount = 0;

            // For Page view.
            intPageSize = nPageSize;
            intTotalRecords = getCount(strCondition);
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

            loadPage(strCondition);
        }

        private int getCount(string condition)
        {
            int intCount = 0;

            if (dt != null)
            {
                intCount = dt.Rows.Count;
            }

            return intCount;
        }

        private void loadPage(string condition)
        {
            this.lblStatus.Text = "- / -";

            try
            {
                Console.WriteLine("1");
                int intSkip = 0;
                intSkip = (intCurrentPage * intPageSize);
                Console.WriteLine("12");
                //this.GridRecord.DataSource = dt;

                raw_list_rs(dt);
                Console.WriteLine("13");
                GridRecord.Columns[0].DefaultCellStyle.ForeColor = Color.Blue;
                GridRecord.Columns[1].DefaultCellStyle.ForeColor = Color.Blue;
                Console.WriteLine("14");
                GridRecord.Columns[0].Frozen = true;
                GridRecord.Columns[1].Frozen = true;
                Console.WriteLine("15");
                GridRecord.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                GridRecord.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                GridRecord.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                GridRecord.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                GridRecord.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                GridRecord.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                GridRecord.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                GridRecord.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                GridRecord.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                Console.WriteLine("16");
                GridRecord.Columns["INPUT_PRICE"].DefaultCellStyle.Format = "#,0";
                GridRecord.Columns["OUTPUT_PRICE"].DefaultCellStyle.Format = "#,0";
                Console.WriteLine("17");
                this.dgv = GridRecord;
                Console.WriteLine("18");
                this.lblStatus.Text = (intCurrentPage + 1).ToString() + " / " + intPageCount.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("검색중에 오류가 발생했습니다.");
                wnLog.writeLog(wnLog.LOG_ERROR, ex.Message + " - " + ex.ToString());
                Console.WriteLine(ex);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            gubun = cmb_option.SelectedIndex;

            wnDm wDm = new wnDm();
            DataTable dt = new DataTable();
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(" WHERE ((A.RAW_MAT_CD like '%" + txtSrch.Text.ToString() + "%') OR (A.RAW_MAT_NM like '%" + txtSrch.Text.ToString() + "%') OR (A.SPEC like '%" + txtSrch.Text.ToString()+"%'))");
            sb.AppendLine("and A.RAW_MAT_GUBUN like '%" + cbo자재구분.SelectedValue + "%'");
            
            dt = wDm.fn_Raw_List_Only_Order(sb.ToString());

            raw_list_rs(dt);


            Properties.Settings.Default.rawSelect = gubun;
            Properties.Settings.Default.Save();


        }

        private void raw_list_rs(DataTable dt)
        {
            if (dt != null && dt.Rows.Count > 0)
            {
                this.GridRecord.RowCount = dt.Rows.Count;
                bool ck = true;
                for (int i = 0; i < GridRecord.Rows.Count; i++)
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
                    GridRecord.Rows[i].Cells["RAW_MAT_CD"].Value = dt.Rows[i]["RAW_MAT_CD"].ToString();
                    GridRecord.Rows[i].Cells["RAW_MAT_NM"].Value = dt.Rows[i]["RAW_MAT_NM"].ToString();
                    GridRecord.Rows[i].Cells["SPEC"].Value = dt.Rows[i]["SPEC"].ToString();
                    GridRecord.Rows[i].Cells["RAW_MAT_GUBUN_NM"].Value = dt.Rows[i]["RAW_MAT_GUBUN_NM"].ToString();
                    GridRecord.Rows[i].Cells["TYPE_NM"].Value = dt.Rows[i]["TYPE_NM"].ToString();
                    GridRecord.Rows[i].Cells["INPUT_UNIT"].Value = dt.Rows[i]["INPUT_UNIT"].ToString();
                    GridRecord.Rows[i].Cells["OUTPUT_UNIT"].Value = dt.Rows[i]["OUTPUT_UNIT"].ToString();

                    GridRecord.Rows[i].Cells["INPUT_UNIT_NM"].Value = dt.Rows[i]["INPUT_UNIT_NM"].ToString();
                    GridRecord.Rows[i].Cells["OUTPUT_UNIT_NM"].Value = dt.Rows[i]["OUTPUT_UNIT_NM"].ToString();

                    GridRecord.Rows[i].Cells["INPUT_PRICE"].Value = decimal.Parse(dt.Rows[i]["INPUT_PRICE"].ToString()).ToString("#,0.######");

                    GridRecord.Rows[i].Cells["OUTPUT_PRICE"].Value = decimal.Parse(dt.Rows[i]["OUTPUT_PRICE"].ToString()).ToString("#,0.######");
                    if (dt.Rows[i]["BAL_STOCK"].ToString().Equals(""))
                    {
                        dt.Rows[i]["BAL_STOCK"] = 0.000000;
                    }
                    GridRecord.Rows[i].Cells["BAL_STOCK"].Value = decimal.Parse(dt.Rows[i]["BAL_STOCK"].ToString()).ToString("#,0.######"); ;

                    GridRecord.Rows[i].Cells["CUST_CD"].Value = dt.Rows[i]["CUST_CD"].ToString();
                    GridRecord.Rows[i].Cells["CUST_NM"].Value = dt.Rows[i]["CUST_NM"].ToString();

                    GridRecord.Rows[i].Cells["CVR_RATIO"].Value = dt.Rows[i]["CVR_RATIO"].ToString();


                    if (ck)
                    {
                        try
                        {
                            if (dt.Rows[i]["INPUT_DATE"].ToString() != "")
                            {
                                GridRecord.Rows[i].Cells["INPUT_DATE"].Value = dt.Rows[i]["INPUT_DATE"].ToString();
                                GridRecord.Rows[i].Cells["INPUT_CD"].Value = dt.Rows[i]["INPUT_CD"].ToString();
                                GridRecord.Rows[i].Cells["SEQ"].Value = dt.Rows[i]["SEQ"].ToString();
                            }
                            else
                            {
                                GridRecord.Rows[i].Cells["INPUT_DATE"].Value = "";
                                GridRecord.Rows[i].Cells["INPUT_CD"].Value = "";
                                GridRecord.Rows[i].Cells["SEQ"].Value = "";
                            }
                        }
                        catch
                        {
                            ck = false;
                        }
                    }
                }
            }
            else
            {
                //MessageBox.Show("검색된 자료가없습니다. 전체로 다시검색 하겠습니다.");
                cmb_option.SelectedIndex = 0;
                btnSearch.PerformClick();

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

                sRetCode = "" + (string)GridRecord.Rows[iCnt].Cells["RAW_MAT_CD"].Value;
                sRetNM = "" + (string)GridRecord.Rows[iCnt].Cells["RAW_MAT_NM"].Value;

                this.Close();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //list = null;

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
