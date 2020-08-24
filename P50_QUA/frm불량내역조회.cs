using MES.CLS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MES.P50_QUA
{
    public partial class frm불량내역조회 : Form
    {
        private string gubun = "0"; //원자재,공정 구분자

        public frm불량내역조회()
        {
            InitializeComponent();
        }
        private void frm불량내역조회_Load(object sender, EventArgs e)
        {
            lbl_title.Tag = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[0] + "$" + wnDm.fn_TitleName(this.Name.ToString()).Split('$')[1]; lbl_title.Text = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[2];

            cmb_cd_srch.Items.Add("LOT번호");
            cmb_cd_srch.Items.Add("공정명");
            cmb_cd_srch.SelectedIndex = 0;

        }
        private void txt_raw_srch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_raw_srch_Click(sender, e);
            }
        }
        private void txt_srch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(sender, e);
                //SendKeys.Send("{TAB}");
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            /*공정불량내역*/
            if (tabControl1.SelectedIndex == 1) { flow_poor_search(); }
        }
        private void btn_raw_srch_Click(object sender, EventArgs e)
        {
            /*원자재불량내역*/
            if (tabControl1.SelectedIndex == 0) { raw_poor_search(); }
        }
        private void raw_poor_search()
        {
            wnDm wDm = new wnDm();
            DataTable dt = null;
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("and A.CHK_DATE <= '" + dtp_raw_start.Text.ToString() + "' and A.CHK_DATE >= '" + dtp_raw_end.Text.ToString() + "'");
            if (txt_raw_srch.Text.ToString().Equals(""))
            {
                sb.AppendLine("");
            }
            else
            {
                sb.AppendLine(" AND E.RAW_MAT_NM LIKE '%" + txt_raw_srch.Text + "%'");
            }



            dt = wDm.fn_raw_poor_List(sb.ToString());

            dgv_raw_poor.Rows.Clear();

            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dgv_raw_poor.Rows.Add();

                    dgv_raw_poor.Rows[i].Cells["POOR_NM"].Value = dt.Rows[i]["POOR_NM"].ToString();
                    dgv_raw_poor.Rows[i].Cells["RAW_NM"].Value = dt.Rows[i]["RAW_MAT_NM"].ToString();
                    dgv_raw_poor.Rows[i].Cells["POOR_AMT1"].Value = (decimal.Parse(dt.Rows[i]["불량수량"].ToString())).ToString("#,0.######");
                    dgv_raw_poor.Rows[i].Cells["POOR_DATE1"].Value = dt.Rows[i]["불량등록일시"].ToString();
                    dgv_raw_poor.Rows[i].Cells["CHK_NM"].Value = dt.Rows[i]["검사항목"].ToString(); //검사항목
                    dgv_raw_poor.Rows[i].Cells["CHK_M"].Value = dt.Rows[i]["검사기구"].ToString(); //검사기구
                    dgv_raw_poor.Rows[i].Cells["CHK_DATE"].Value = dt.Rows[i]["검사시기"].ToString(); //검사시기

                }
            }



        }
        private void flow_poor_search()
        {
            wnDm wDm = new wnDm();
            DataTable dt = null;
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("and SUBSTRING(CONVERT(VARCHAR,INTIME,112),1,10) >= '" + start_date.Text.ToString() + "' and SUBSTRING(CONVERT(VARCHAR,INTIME,112),1,10) <= '" + end_date.Text.ToString() + "'");
            if (txt_srch.Text.ToString().Equals(""))
            {
                sb.AppendLine("");
            }
            else
            {
                if (cmb_cd_srch.SelectedIndex == 0)
                {
                    sb.AppendLine("AND A.LOT_NO = '" + txt_srch.Text + "'");
                }
                else if (cmb_cd_srch.SelectedIndex == 1)
                {
                    sb.AppendLine("AND FLOW_NM like '%" + txt_srch.Text.ToString() + "%' ");
                }
            }


            dt = wDm.fn_flow_poor_List(sb.ToString());

            inputRmGrid.Rows.Clear();



            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //string t_amt = string.Format("{0:#.##}", 100.2);
                    inputRmGrid.Rows.Add();


                    inputRmGrid.Rows[i].Cells["POOR_TYPE"].Value = dt.Rows[i]["POOR_NM"].ToString();
                    inputRmGrid.Rows[i].Cells["FLOW_NM"].Value = dt.Rows[i]["FLOW_NM"].ToString();
                    inputRmGrid.Rows[i].Cells["POOR_AMT"].Value = (decimal.Parse(dt.Rows[i]["불량수량"].ToString())).ToString("#,0.######");
                    inputRmGrid.Rows[i].Cells["POOR_DATE"].Value = dt.Rows[i]["불량등록일시"].ToString();
                    inputRmGrid.Rows[i].Cells["POOR_CMT"].Value = dt.Rows[i]["POOR_NM"].ToString();
                    inputRmGrid.Rows[i].Cells["LOT_NO"].Value = dt.Rows[i]["LOT_NO"].ToString();


                }
            }



        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void inputRmGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 1)
                return;

            if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex))
            {
                e.Value = "";
                e.FormattingApplied = true;
            }
        }

        private void inputRmGrid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
            if (e.RowIndex == inputRmGrid.Rows.Count - 1)
            {
                e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.Single;
            }
            if (e.RowIndex < 1)
            {
                e.AdvancedBorderStyle.Top = inputRmGrid.AdvancedCellBorderStyle.Top;
                return;
            }
            else if (e.ColumnIndex != 0 && e.ColumnIndex != 4)
            {
                e.AdvancedBorderStyle.Top = inputRmGrid.AdvancedCellBorderStyle.Top;
                return;
            }

            if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex))
            {
                e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
            }
            else
            {
                e.AdvancedBorderStyle.Top = inputRmGrid.AdvancedCellBorderStyle.Top;
            }
        }
        private bool IsTheSameCellValue(int column, int row)
        {

            DataGridViewCell cell1 = inputRmGrid[column, row];
            DataGridViewCell cell2 = inputRmGrid[column, row - 1];
            if (cell1.Value == null || cell2.Value == null)
            {
                return false;
            }
            return cell1.Value.ToString() == cell2.Value.ToString();
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
                    btn_raw_srch.PerformClick();
                    break;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
            return true;
        }



    }
}
