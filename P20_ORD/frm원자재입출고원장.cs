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

namespace MES.P20_ORD
{
    public partial class frm원자재입출고원장 : Form
    {
        Popup.frmPrint readyPrt = new Popup.frmPrint();
        private wnGConstant wConst = new wnGConstant();

        DataTable adoPrt = null;
        wnAdo wAdo = new wnAdo();
        public Popup.frmPrint frmPrt;

        public string strDay1 = "";
        public string strDay2 = "";
        public string strCondition = "";

        public frm원자재입출고원장()
        {
            InitializeComponent();
        }
        public static bool p_IsAuth = true;    // 열람권한
        public static bool p_Isrgstr = true;    //등록/수정 권한

        public static bool p_Isdel = true;    // 삭제 권한
        wnDm wnDm = new wnDm();
        private void frm원자재입출고원장_Load(object sender, EventArgs e)
        {
               lbl_title.Tag = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[0] + "$" + wnDm.fn_TitleName(this.Name.ToString()).Split('$')[1]; lbl_title.Text = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[2];
               if (Common.p_strUserAdmin != "5")
               {
                   DataTable dtcheck = wnDm.fn_auth_check(lbl_title.Tag.ToString().Split('$')[0], lbl_title.Tag.ToString().Split('$')[1]);
                   p_IsAuth = dtcheck.Rows[0]["auth_yn"].ToString() == "Y" ? true : false;
                   p_Isrgstr = dtcheck.Rows[0]["rgstr_yn"].ToString() == "Y" ? true : false;
                   p_Isdel = dtcheck.Rows[0]["del_yn"].ToString() == "Y" ? true : false;
                   try
                   {
                       if (!p_IsAuth)
                       {
                           this.BeginInvoke(new MethodInvoker(Close));
                           /// MessageBox.Show("권한이없습니다.");
                       }

                   }
                   catch (Exception ex)
                   {
                   }
               }
            init_ComboBox();
            grdCellSetting();

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
        #region button logic

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            GridList();
        }
        #endregion button logic

        private void GridList()
        {
            wnDm wDm = new wnDm();
            DataTable dt = null;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" where 1=1 ");
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

            dt = wDm.fn_Raw_Stock_List(srch_date.Text.ToString(), sb.ToString());

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
                    rawStockGrid.Rows[i].Cells["SPEC"].Value = dt.Rows[i]["규격"].ToString();
                    rawStockGrid.Rows[i].Cells["INPUT_AMT"].Value = (decimal.Parse(dt.Rows[i]["입고량"].ToString())).ToString("#,0.######");
                    rawStockGrid.Rows[i].Cells["OUTPUT_AMT"].Value = (decimal.Parse(dt.Rows[i]["출고량"].ToString())).ToString("#,0.######");
                    rawStockGrid.Rows[i].Cells["STOCK_AMT"].Value = (decimal.Parse(dt.Rows[i]["재고량"].ToString())).ToString("#,0.######");

                    if (decimal.Parse(dt.Rows[i]["재고량"].ToString()) < 0)
                    {
                        rawStockGrid.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                    }
                }
                
                //데이타 끝나고 다시 copy를 써준 이유는 for중에 no에 값을 엏었기 때문에 출력물 데이타테이블(dt)를 다시 복사함
                adoPrt = dt.Copy();
            }
        }

        private void grdCellSetting()
        {
            ComInfo comInfo = new ComInfo();
            comInfo.grdCellSetting(rawStockGrid);
            comInfo.grdCellSetting(rawDetailGrid);

            //for (int i = 0; i < rawStockGrid.ColumnCount; i++)
            //{
            //    rawStockGrid.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //    rawStockGrid.Columns[i].ReadOnly = true;
            //}

            //for (int i = 0; i < rawDetailGrid.ColumnCount; i++) 
            //{
            //    rawDetailGrid.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //    rawDetailGrid.Columns[i].ReadOnly = true;
            //}
        }

        private void rawStockGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            wnDm wDm = new wnDm();
            DataTable dt = null;

            lbl_raw_nm.Text = rawStockGrid.Rows[e.RowIndex].Cells["RAW_MAT_NM"].Value.ToString();
            dt = wDm.fn_Raw_St_Detail_List(srch_date.Text.ToString(),rawStockGrid.Rows[e.RowIndex].Cells["RAW_MAT_CD"].Value.ToString());

            rawDetailGrid.Rows.Clear();
            if (dt != null && dt.Rows.Count > 0)
            {
                rawDetailGrid.RowCount = dt.Rows.Count;

                decimal t_input_amt = 0;
                decimal t_output_amt = 0;
                decimal t_stock_amt = 0;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    rawDetailGrid.Rows[i].Cells["INPUT_CD"].Value = dt.Rows[i]["INPUT_CD"].ToString();
                    rawDetailGrid.Rows[i].Cells["INPUT_SEQ"].Value = dt.Rows[i]["SEQ"].ToString();
                    rawDetailGrid.Rows[i].Cells["INPUT_DATE"].Value = dt.Rows[i]["INPUT_DATE"].ToString();
                    rawDetailGrid.Rows[i].Cells["R_INPUT_AMT"].Value = (decimal.Parse(dt.Rows[i]["INPUT_AMT"].ToString())).ToString("#,0.######");
                    rawDetailGrid.Rows[i].Cells["R_OUTPUT_AMT"].Value = (decimal.Parse(dt.Rows[i]["OUTPUT_AMT"].ToString())).ToString("#,0.######");
                    rawDetailGrid.Rows[i].Cells["R_STOCK_AMT"].Value = (decimal.Parse(dt.Rows[i]["STOCK_AMT"].ToString())).ToString("#,0.######");


                    rawDetailGrid.Rows[i].Cells["R_INPUT_AMT"].Style.ForeColor = Color.Blue;
                    rawDetailGrid.Rows[i].Cells["R_OUTPUT_AMT"].Style.ForeColor = Color.Blue;
                    rawDetailGrid.Rows[i].Cells["R_STOCK_AMT"].Style.ForeColor = Color.Blue;

                    t_input_amt += decimal.Parse(dt.Rows[i]["INPUT_AMT"].ToString());
                    t_output_amt += decimal.Parse(dt.Rows[i]["OUTPUT_AMT"].ToString());
                    t_stock_amt += decimal.Parse(dt.Rows[i]["STOCK_AMT"].ToString());
                }

                rawDetailGrid.Rows.Add();
                rawDetailGrid.Rows[rawDetailGrid.Rows.Count - 1].Cells[0].Value = "합계";
                rawDetailGrid.Rows[rawDetailGrid.Rows.Count - 1].Cells["R_INPUT_AMT"].Value = t_input_amt.ToString("#,0.######");
                rawDetailGrid.Rows[rawDetailGrid.Rows.Count - 1].Cells["R_OUTPUT_AMT"].Value = t_output_amt.ToString("#,0.######");
                rawDetailGrid.Rows[rawDetailGrid.Rows.Count - 1].Cells["R_STOCK_AMT"].Value = t_stock_amt.ToString("#,0.######");

                rawDetailGrid.Rows[rawDetailGrid.Rows.Count - 1].Cells[0].Style.ForeColor = Color.CadetBlue;
                rawDetailGrid.Rows[rawDetailGrid.Rows.Count - 1].Cells["R_INPUT_AMT"].Style.ForeColor = Color.Red;
                rawDetailGrid.Rows[rawDetailGrid.Rows.Count - 1].Cells["R_OUTPUT_AMT"].Style.ForeColor = Color.Red;
                rawDetailGrid.Rows[rawDetailGrid.Rows.Count - 1].Cells["R_STOCK_AMT"].Style.ForeColor = Color.Red;
                wConst.mergeCells(rawDetailGrid, 1);

            }
        }

        private void btn출력_Click(object sender, EventArgs e)
        {
            btn출력.Enabled = false;

            strCondition = "";

            if (rawStockGrid.Rows.Count == 0)
            {
                MessageBox.Show("출력할 자료가 없습니다.");
                btn출력.Enabled = true;
                return;
            }

            strDay1 = srch_date.Text;
            strCondition = "원자재재고현황";

            frmPrt = readyPrt;
            frmPrt.Show();
            frmPrt.BringToFront();
            //frmPrt.prt_원자재재고현황(adoPrt, strDay1, strDay2, strCust, strCondition);
            frmPrt.prt_원자재재고현황(adoPrt, strDay1, strCondition);

            btn출력.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            rawStockGrid.Rows.Clear();
            rawDetailGrid.Rows.Clear();
        }


    }
}
