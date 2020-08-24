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
    public partial class pop재고위치검색 : Form
    {
        private int iCnt;
        private string strCondition = "";
        
        public string sCode = "";
        public string sName = "";
        public string sStorageCd = "";
        public string sCheckValue = "";
        
        

        private bool bSearch = false;
        private int intTotalRecords = 0;
        private int intPageSize = 0;
        private int intPageCount = 0;
        private int intCurrentPage = 1;

        private int nPageSize = int.Parse(Common.p_PageSize);
        public pop재고위치검색()
        {
            InitializeComponent();
        }

        private void pop재고위치검색_Load(object sender, EventArgs e)
        {
            
            bindData("where A.STORAGE_CD = '" + sStorageCd + "' ");
        }

        private void bindData(string condition)
        {
            this.GridRecord.DataSource = null;
            this.GridRecord.RowCount = 0;

            wnDm wDm = new wnDm();
            DataTable dt = null;
            dt = wDm.fn_loc_list(condition);

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

                
                this.lblStatus.Text = (intCurrentPage + 1).ToString() + " / " + intPageCount.ToString();

                if (dt.Rows.Count > 0)
                {
                    GridRecord.RowCount = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        GridRecord.Rows[i].Cells[1].Value = dt.Rows[i]["LOC_NM"].ToString();
                        GridRecord.Rows[i].Cells[2].Value = dt.Rows[i]["LOC_CD"].ToString();
                        
                    }

                    if (sCheckValue != null && !sCheckValue.Equals(""))
                    {
                        string[] CheckValues = sCheckValue.Split('|');
                        for (int i = 0; i < CheckValues.Length; i++)
                        {
                            for (int j = 0; j < GridRecord.Rows.Count; j++)
                            {
                                if(GridRecord.Rows[j].Cells[2].Value.ToString().Equals(CheckValues[i].ToString()))
                                {
                                    GridRecord.Rows[j].Cells[0].Value = true;
                                    break;
                                }
                            }
                        }
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

        

        private void btnExit_Click(object sender, EventArgs e)
        {
            sCode = "";
            sName = "";
            for (int i = 0; i < GridRecord.Rows.Count; i++)
            {
                if (GridRecord.Rows[i].Cells[0].Value != null && (bool)GridRecord.Rows[i].Cells[0].Value == true)
                {
                    if (sCode.Equals(""))
                    {
                        sCode += GridRecord.Rows[i].Cells[2].Value.ToString();
                        sName += GridRecord.Rows[i].Cells[1].Value.ToString();
                    }
                    else
                    {
                        sCode += "|"+GridRecord.Rows[i].Cells[2].Value.ToString();
                        sName += ", "+GridRecord.Rows[i].Cells[1].Value.ToString();
                    }
                    
                }
            }
            this.Close();
        }

        

        

        
    }
}
