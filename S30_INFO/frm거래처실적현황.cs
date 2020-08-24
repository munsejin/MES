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

namespace MES.S30_INFO
{
    public partial class frm거래처실적현황 : Form
    {
        
        private wnGConstant wConst = new wnGConstant();



        public frm거래처실적현황()
        {
            InitializeComponent();
        }

        private void frm거래처실적현황_Load(object sender, EventArgs e)
        {
            lbl_title.Tag = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[0] + "$" + wnDm.fn_TitleName(this.Name.ToString()).Split('$')[1]; lbl_title.Text = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[2];
            
            start_date.Text = DateTime.Today.ToString("yyyy-MM-dd").Substring(0, 8) + "01";

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
            wnDm wDm = new wnDm();
            DataTable dt = null;



            ArrayList locationSum = new ArrayList();
            dt = wDm.fn_Cust_Info_List(start_date.Text, end_date.Text, chk_not_Zero.Checked, chk_not_Activity.Checked);

            if (dt != null && dt.Rows.Count > 0)
            {
                staffGrid.Rows.Clear();
                staffGrid.RowCount = dt.Rows.Count;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["STAFF_NM"].ToString().ToString().Equals("--- 소계 ---")
                      )
                    {
                        locationSum.Add(i);
                        DataGridViewCellStyle style = new DataGridViewCellStyle();
                        style.BackColor = Color.Khaki;
                        style.SelectionBackColor = Color.DarkKhaki;

                        for (int j = 0; j < staffGrid.ColumnCount; j++)
                        {
                            staffGrid.Rows[i].Cells[j].Style = style;
                        }
                    }else if(dt.Rows[i]["STAFF_NM"].ToString().ToString().Equals("=== 합계 ===")
                      )
                    {
                        DataGridViewCellStyle style = new DataGridViewCellStyle();
                        style.BackColor = Color.IndianRed;
                        style.SelectionBackColor = Color.DarkRed;
                        style.ForeColor = Color.White;
                        style.SelectionForeColor = Color.White;

                        for (int j = 0; j < staffGrid.ColumnCount; j++)
                        {
                            staffGrid.Rows[i].Cells[j].Style = style;
                        }
                    }
                    staffGrid.Rows[i].Cells["사원번호"].Value = dt.Rows[i]["사원명칭"].ToString();
                    staffGrid.Rows[i].Cells["담당사원"].Value = dt.Rows[i]["STAFF_NM"].ToString();
                    staffGrid.Rows[i].Cells["코드"].Value = dt.Rows[i]["CUST_CD"].ToString();
                    staffGrid.Rows[i].Cells["거래처명"].Value = dt.Rows[i]["CUST_NM"].ToString();
                    staffGrid.Rows[i].Cells["이월잔고"].Value = decimal.Parse(dt.Rows[i]["이월잔고"].ToString()).ToString("#,0.######");
                    staffGrid.Rows[i].Cells["매출액"].Value = decimal.Parse(dt.Rows[i]["매출"].ToString()).ToString("#,0.######");
                    staffGrid.Rows[i].Cells["수금액"].Value = decimal.Parse(dt.Rows[i]["수금"].ToString()).ToString("#,0.######");
                    staffGrid.Rows[i].Cells["할인액"].Value = decimal.Parse(dt.Rows[i]["할인"].ToString()).ToString("#,0.######");
                    staffGrid.Rows[i].Cells["현잔고"].Value = decimal.Parse(dt.Rows[i]["현잔고"].ToString()).ToString("#,0.######");
                    staffGrid.Rows[i].Cells["매입액"].Value = decimal.Parse(dt.Rows[i]["매입"].ToString()).ToString("#,0.######");
                    staffGrid.Rows[i].Cells["이익금액"].Value = decimal.Parse(dt.Rows[i]["이익금"].ToString()).ToString("#,0.######");
                    staffGrid.Rows[i].Cells["이익율"].Value = decimal.Parse(dt.Rows[i]["이익율"].ToString()).ToString("#,0.##");
                }
            }

            Cal_Balance_Logic(locationSum);

            if (chk_not_Activity.Checked)
            {
                for (int i = 0; i < staffGrid.Rows.Count; i++)
                {
                    if (staffGrid.Rows[i].Cells["매출액"].Value.ToString().Equals("0") &&
                        staffGrid.Rows[i].Cells["수금액"].Value.ToString().Equals("0") &&
                        staffGrid.Rows[i].Cells["할인액"].Value.ToString().Equals("0"))
                    {
                        staffGrid.Rows.RemoveAt(i);
                        i--;
                    }
                }
            }

            if (chk_not_Zero.Checked)
            {
                for (int i = 0; i < staffGrid.Rows.Count; i++)
                {
                    if (staffGrid.Rows[i].Cells["현잔고"].Value.ToString().Equals("0"))
                    {
                        staffGrid.Rows.RemoveAt(i);
                        i--;
                    }
                }
            }

            wnGConstant wng = new wnGConstant();
            //wng.mergeCells(staffGrid, 2);






            


        }

        private void Cal_Balance_Logic(ArrayList locSum)
        {
            if (staffGrid.Rows.Count > 0)
            {
                decimal 이월잔고 = 0;
                decimal 현잔고 = 0;

                for (int i = 0; i < locSum.Count ; i++)
                {
                    이월잔고 += decimal.Parse(staffGrid.Rows[(int)locSum[i]].Cells["이월잔고"].Value.ToString());
                    현잔고 += decimal.Parse(staffGrid.Rows[(int)locSum[i]].Cells["현잔고"].Value.ToString());
                }
                staffGrid.Rows[staffGrid.RowCount - 1].Cells["이월잔고"].Value = 이월잔고.ToString("#,0.######");
                staffGrid.Rows[staffGrid.RowCount - 1].Cells["현잔고"].Value = 현잔고.ToString("#,0.######");
                
            }
        }

        private void grdCellSetting()
        {
            ComInfo comInfo = new ComInfo();
            comInfo.grdCellSetting2(staffGrid);
        }

        private void btn출력_Click(object sender, EventArgs e)
        {
            if (this.staffGrid.Rows.Count != 0)
            {
                btn출력.Enabled = false;

                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Title = "Save as Excel File";
                sfd.Filter = "Excel 통합 문서 (*.xlsx)|*.xlsx|Excel 97 - 2003 통합문서(*.xls)|*.xls";
                if (start_date.Text.ToString().Equals(end_date.Text.ToString()))
                {
                    sfd.FileName = start_date.Text + " 거래처 실적현황";
                }
                else
                {
                    sfd.FileName = start_date.Text + " ~ " + end_date.Text + " 거래처 실적현황 ";
                }
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    lblMsg.Visible = true;
                    Application.DoEvents();
                    //wnGConstant.dataGridView_ExportToExcel_CustProfit(sfd.FileName, staffGrid);
                    lblMsg.Visible = false;
                    MessageBox.Show("엑셀 출력이 완료되었습니다");
                }


                btn출력.Enabled = true;
            }
            else
            {
                MessageBox.Show("다운받을 자료가 없습니다.");
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
       
       

       
       
        
    }
}
