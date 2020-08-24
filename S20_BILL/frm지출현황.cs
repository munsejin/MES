
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

namespace MES.S20_BILL
{
    public partial class frm지출현황 : Form
    {

        private wnGConstant wConst = new wnGConstant();


        public frm지출현황()
        {
            InitializeComponent();

        }   

        

        
        private void frm지출현황_Load(object sender, EventArgs e)
        {
            lbl_title.Tag = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[0] + "$" + wnDm.fn_TitleName(this.Name.ToString()).Split('$')[1]; lbl_title.Text = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[2];

            start_date.Text = DateTime.Today.AddMonths(-1).ToString("yyyy-MM-dd");
            end_date.Text = DateTime.Today.ToString("yyyy-MM-dd");

            ComInfo comInfo = new ComInfo();


            string sqlQuery = "";

            cmb_accu.ValueMember = "코드";
            cmb_accu.DisplayMember = "명칭";
            sqlQuery = comInfo.queryAccu();
            wConst.ComboBox_Read_ALL(cmb_accu, sqlQuery);

        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            SelectList();
        }

        private void SelectList()
        {
            try
            {

                wnDm wDm = new wnDm();
                DataTable dt = null;
                if (cmb_accu.SelectedIndex != 0)
                {
                    dt = wDm.fn_Pay_Ledger_List("WHERE ACCU_CD = '" + cmb_accu.SelectedValue.ToString() + "' AND A.PAY_DATE >= '" + start_date.Text + "' AND A.PAY_DATE <= '" + end_date.Text + "'  ");
                }
                else
                {
                    dt = wDm.fn_Pay_Ledger_List("WHERE  A.PAY_DATE >= '" + start_date.Text + "' AND A.PAY_DATE <= '" + end_date.Text + "'  ");
                }

                if (dt != null && dt.Rows.Count > 0)
                {
                    grd_pay.Rows.Clear();
                    grd_pay.RowCount = dt.Rows.Count;

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        grd_pay.Rows[i].Cells["PAY_DATE"].Value = dt.Rows[i]["일자명칭"].ToString();

                        if (dt.Rows[i]["일자명칭"].ToString().ToString().Equals("----- 소계 -----")
                        || dt.Rows[i]["일자명칭"].ToString().ToString().Equals("==== 합계 ===="))
                        {
                            DataGridViewCellStyle style = new DataGridViewCellStyle();
                            style.BackColor = Color.Khaki;
                            style.SelectionBackColor = Color.DarkKhaki;
                            if (dt.Rows[i]["일자명칭"].ToString().ToString().Equals("----- 소계 -----"))
                            {
                                style.ForeColor = Color.Blue;
                            }
                            for (int j = 0; j < grd_pay.ColumnCount; j++)
                            {
                                grd_pay.Rows[i].Cells[j].Style = style;
                            }
                        }

                        if (dt.Rows[i]["PAY_CD"].ToString().Equals("999"))
                        {
                            grd_pay.Rows[i].Cells["PAY_CD"].Value = "";
                        }
                        else
                        {
                            grd_pay.Rows[i].Cells["PAY_CD"].Value = dt.Rows[i]["PAY_CD"].ToString();
                        }
                        grd_pay.Rows[i].Cells["STAFF_NM"].Value = dt.Rows[i]["STAFF_NM"].ToString();
                        grd_pay.Rows[i].Cells["ACCU_CD"].Value = dt.Rows[i]["ACCU_CD"].ToString();
                        grd_pay.Rows[i].Cells["ACCU_NM"].Value = dt.Rows[i]["ACCU_NM"].ToString();
                        grd_pay.Rows[i].Cells["PAY_GUBUN"].Value = dt.Rows[i]["PAY_GUBUN"].ToString();
                        grd_pay.Rows[i].Cells["JUKYO"].Value = dt.Rows[i]["JUKYO"].ToString();
                        grd_pay.Rows[i].Cells["MONEY"].Value = decimal.Parse(dt.Rows[i]["MONEY"].ToString()).ToString("#,0.######");

                    }
                }
                else
                {
                    MessageBox.Show("검색결과가 없습니다.");
                    return;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex + "");
                MessageBox.Show("조회에 오류가 발생했습니다");
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                msg.ShowDialog();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn출력_Click(object sender, EventArgs e)
        {
            if (this.grd_pay.Rows.Count != 0)
            {
                btn출력.Enabled = false;

                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Title = "Save as Excel File";
                sfd.Filter = "Excel 통합 문서 (*.xlsx)|*.xlsx|Excel 97 - 2003 통합문서(*.xls)|*.xls";
                if (start_date.Text.ToString().Equals(end_date.Text.ToString()))
                {
                    sfd.FileName = start_date.Text + " 지출현황";
                }
                else
                {
                    sfd.FileName = start_date.Text + " ~ " + end_date.Text + " 지출현황";
                }
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    lblMsg.Visible = true;
                    Application.DoEvents();
                    wnGConstant.dataGridView_ExportToExcel_Pay(sfd.FileName, grd_pay);
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
                    btn_search.PerformClick();
                    break;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
            return true;
        }
        
      

      

    }
}
