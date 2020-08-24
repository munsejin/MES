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

namespace MES.P20_ORD
{
    public partial class frm잔재재고현황 : Form
    {
        DataTable adoPrt = null;

        public frm잔재재고현황()
        {
            InitializeComponent();
        }
        private void frm잔재재고현황_Load(object sender, EventArgs e)
        {
            init_ComboBox();
            GridList();
        }
         private void init_ComboBox()
        {
            cmb_cd_srch.Items.Add("전체 검색");
            cmb_cd_srch.Items.Add("코드별 검색");
            cmb_cd_srch.Items.Add("원자재명 검색");
            cmb_cd_srch.Items.Add("규격 검색");
            cmb_cd_srch.SelectedIndex = 0;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            GridList();
        }

      
        private void GridList()
        {
            wnDm wDm = new wnDm();
            DataTable dt = null;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("  where A.CUST_CD = 'dregs' ");
            if (chk_stock.Checked == true)
            {
                sb.AppendLine(" and ISNULL(B.INPUT_AMT,0) - ISNULL(C.OUTPUT_AMT,0) > 0 ");
            }

            if (cmb_cd_srch.SelectedIndex == 0)
            {
                sb.AppendLine("");
            }
            else if (cmb_cd_srch.SelectedIndex == 1)
            {
                if (txt_srch.Text.ToString().Equals(""))
                {
                    MessageBox.Show("코드명을 입력하시기 바랍니다.");
                    return;
                }
                sb.AppendLine("and A.RAW_MAT_CD like '%" + txt_srch.Text.ToString() + "%' ");

            }
            else if (cmb_cd_srch.SelectedIndex == 2)
            {
                if (txt_srch.Text.ToString().Equals(""))
                {
                    MessageBox.Show("원자재명을 입력하시기 바랍니다.");
                    return;
                }
                sb.AppendLine("and A.RAW_MAT_NM like '%" + txt_srch.Text.ToString() + "%' ");
            }
            else
            {
                if (txt_srch.Text.ToString().Equals(""))
                {
                    MessageBox.Show("규격을 입력하시기 바랍니다.");
                    return;
                }
                sb.AppendLine(" and A.SPEC like '%" + txt_srch.Text.ToString() + "%' ");
            }

            dt = wDm.fn_Raw_Stock_List2(srch_date.Text.ToString(), sb.ToString());

            rawStockGrid.Rows.Clear();
            rawDetailGrid.Rows.Clear();
            lbl_raw_nm.Text = "";
            dt = wDm.fn_Raw_Stock_List(srch_date.Text.ToString(), sb.ToString());

            adoPrt = new DataTable();
            adoPrt = dt.Copy();

            if (dt != null && dt.Rows.Count > 0)
            {
                rawStockGrid.RowCount = dt.Rows.Count;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["no"] = (i + 1); //숫자의 경우  문자면 .string : 계산된 값을 READ 한 테이블로 다시 전달한다 - 출력물 사용

                    rawStockGrid.Rows[i].Cells["RAW_MAT_CD"].Value = dt.Rows[i]["원자재코드"].ToString();
                    rawStockGrid.Rows[i].Cells["RAW_MAT_NM"].Value = dt.Rows[i]["원자재명"].ToString();
                    rawStockGrid.Rows[i].Cells["구매처"].Value = dt.Rows[i]["CUST_NM"].ToString();
                    rawStockGrid.Rows[i].Cells["구매처코드"].Value = dt.Rows[i]["CUST_CD"].ToString();
                    rawStockGrid.Rows[i].Cells["SPEC"].Value = dt.Rows[i]["규격"].ToString();
                    rawStockGrid.Rows[i].Cells["INPUT_AMT"].Value = (decimal.Parse(dt.Rows[i]["입고량"].ToString())).ToString("#,0.######");
                    rawStockGrid.Rows[i].Cells["OUTPUT_AMT"].Value = (decimal.Parse(dt.Rows[i]["출고량"].ToString())).ToString("#,0.######");
                    rawStockGrid.Rows[i].Cells["STOCK_AMT"].Value = (decimal.Parse(dt.Rows[i]["재고량"].ToString())).ToString("#,0.######");

                    if (decimal.Parse(dt.Rows[i]["재고량"].ToString()) < 0)
                    {
                        rawStockGrid.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                        rawStockGrid.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                    }
                }

                //데이타 끝나고 다시 copy를 써준 이유는 for중에 no에 값을 엏었기 때문에 출력물 데이타테이블(dt)를 다시 복사함
                adoPrt = dt.Copy();
            }
        }

       
    }
}
