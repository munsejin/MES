using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MES.CLS;

namespace MES.P20_ORD
{
    public partial class frm원자재원장현황2 : Form
    {
        Popup.frmPrint readyPrt = new Popup.frmPrint();
        private wnGConstant wConst = new wnGConstant();

        DataTable adoPrt = null;
        DataTable adoPrt2 = null;
        DataTable excelDt = null;
        wnAdo wAdo = new wnAdo();
        public Popup.frmPrint frmPrt;

        public string strDay1 = "";
        public string strDay2 = "";
        public string strCondition = "";
        public string raw_mat_temp = "";

        public frm원자재원장현황2()
        {
            InitializeComponent();
        }

        private void frm원자재원장현황2_Load(object sender, EventArgs e)
        {
            lbl_title.Tag = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[0] + "$" + wnDm.fn_TitleName(this.Name.ToString()).Split('$')[1]; lbl_title.Text = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[2];

            ComInfo.gridHeaderSet(inputRmGrid);

            start_date.Text = DateTime.Today.AddMonths(-1).ToString("yyyy-MM-dd");

            grdCellSetting();

            init_ComboBox();

            

        }

        #region button logic


        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (chk_all != null && chk_all.Checked)
            {
                txt_raw_cd.Text = "";
                txt_raw_nm.Text = "";
                txt_raw_gubun.Text = "";
                txt_Check_Yn.Text = "";
                txt_Cust_Nm.Text = "";
                txt_balstock.Text = "";
                txt_srch.Text = "";
                txt_srch2.Text = "";
                txt_item_grade1.Text = "";
                txt_item_grade2.Text = "";
                txt_item_grade3.Text = "";
                txt_grade1.Text = "";
                txt_grade2.Text = "";
                txt_grade3.Text = "";
                in_grid_logic();
            }
            else
            {
                if (txt_srch2.Text == null || txt_srch2.Text.Equals(""))
                {
                    MessageBox.Show("조회할 원자재를 선택해주십시오");
                    return;
                }
                in_grid_logic();
                calBalstock_logic();
                in_Item_grade_logic();
            }
            wnGConstant wng = new wnGConstant();
            wng.mergeCells(inputRmGrid, 3);
        }

        

       

        private void calBalstock_logic()
        {
            wnDm wDm = new wnDm();
            DataTable dt = null;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("and A.RAW_MAT_CD = '" + txt_srch2.Text.ToString() + "' and A.DATE > '" + end_date.Text.ToString() + "'   ");
            dt = wDm.fn_raw_input_output_list(sb.ToString());

            DataTable dt2 = wDm.fn_Raw_List(" where A.RAW_MAT_CD = '"+txt_srch2.Text.ToString()+"' ","1");
            decimal cvr_ratio = decimal.Parse(dt2.Rows[0]["CVR_RATIO"].ToString());

            decimal lastBalance = decimal.Parse(txt_balstock.Text.ToString().Replace(",", ""));
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lastBalance = (dt.Rows[i]["IO_GUBUN"].ToString().Equals("I") ?
                        lastBalance - decimal.Parse(dt.Rows[i]["AMT"].ToString()) :
                        lastBalance + decimal.Parse(dt.Rows[i]["AMT"].ToString())*cvr_ratio);
                }
            }

            for (int i = inputRmGrid.Rows.Count - 1; i >= 0; i--)
            {
                inputRmGrid.Rows[i].Cells["BALSTOCK"].Value = lastBalance.ToString("#,0.######");
                if (!(inputRmGrid.Rows[i].Cells["INPUT_DATE"].Value.ToString().Equals("--- 일계 ---") ||
                    inputRmGrid.Rows[i].Cells["INPUT_DATE"].Value.ToString().Equals("=== 월계 ===") ||
                    inputRmGrid.Rows[i].Cells["INPUT_DATE"].Value.ToString().Equals("=== 합계 ===") ||
                    inputRmGrid.Rows[i].Cells["INPUT_DATE"].Value.ToString().Equals("== 전잔고 ==")
                    ))
                {
                    string total_input;
                    string total_output;
                    if (inputRmGrid.Rows[i].Cells["INPUT_AMT"].Value == null || inputRmGrid.Rows[i].Cells["INPUT_AMT"].Value.ToString().Equals(""))
                    {
                        total_input = "0";
                    }
                    else
                    {
                        total_input = inputRmGrid.Rows[i].Cells["INPUT_AMT"].Value.ToString();
                    }
                    if (inputRmGrid.Rows[i].Cells["OUTPUT_AMT"].Value == null || inputRmGrid.Rows[i].Cells["OUTPUT_AMT"].Value.ToString().Equals(""))
                    {
                        total_output = "0";
                    }
                    else
                    {
                        total_output = inputRmGrid.Rows[i].Cells["OUTPUT_AMT"].Value.ToString();
                    }
                    lastBalance = lastBalance - decimal.Parse(total_input);
                    lastBalance = lastBalance + decimal.Parse(total_output)*cvr_ratio;
                }

            }

            

        }

        #endregion button logic

        private void init_ComboBox() 
        {


            //cmb_cust.ValueMember = "코드";
            //cmb_cust.DisplayMember = "명칭";
            //sqlQuery = comInfo.queryCust("2");
            //wConst.ComboBox_Read_Blank(cmb_cust, sqlQuery);

            //cmb_raw.ValueMember = "코드";
            //cmb_raw.DisplayMember = "명칭";
            //sqlQuery = comInfo.queryRaw();
            //wConst.ComboBox_Read_Blank(cmb_raw, sqlQuery);
        }
        private void in_grid_logic()
        {
            wnDm wDm = new wnDm();
            DataTable dt = null;

            StringBuilder sb = new StringBuilder();
            StringBuilder sb2 = new StringBuilder();

            if (chk_all.Checked)
            {
                sb.AppendLine("and Z.INPUT_DATE >= '" + start_date.Text.ToString() + "' and  Z.INPUT_DATE <= '" + end_date.Text.ToString() + "' ");
                sb2.AppendLine("and Z.OUTPUT_DATE >= '" + start_date.Text.ToString() + "' and  Z.OUTPUT_DATE <= '" + end_date.Text.ToString() + "' ");
            }
            else
            {
                sb.AppendLine("and Z.INPUT_DATE >= '" + start_date.Text.ToString() + "' and  Z.INPUT_DATE <= '" + end_date.Text.ToString() + "' and Z.RAW_MAT_CD = '" + txt_srch2.Text.ToString() + "'   ");
                sb2.AppendLine("and Z.OUTPUT_DATE >= '" + start_date.Text.ToString() + "' and  Z.OUTPUT_DATE <= '" + end_date.Text.ToString() + "' and Z.RAW_MAT_CD = '" + txt_srch2.Text.ToString() + "'   ");
            }

            dt = wDm.fn_Raw_Ledger_List(sb.ToString(), sb2.ToString());

            inputRmGrid.Rows.Clear();


            if (dt != null && dt.Rows.Count > 0)
            {
                excelDt = dt.Copy();
                inputRmGrid.Rows.Add();
                inputRmGrid.Rows[0].Cells["INPUT_DATE"].Value = "== 전재고 ==";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //string t_amt = string.Format("{0:#.##}", 100.2);
                    inputRmGrid.Rows.Add();


                    inputRmGrid.Rows[i+1].Cells["INPUT_DATE"].Value = dt.Rows[i]["일자명칭"].ToString();
                    if (dt.Rows[i]["일자명칭"].ToString().ToString().Equals("--- 일계 ---")
                        || dt.Rows[i]["일자명칭"].ToString().ToString().Equals("=== 월계 ==="))
                    {
                        DataGridViewCellStyle style = new DataGridViewCellStyle();
                        style.BackColor = Color.Khaki;
                        style.SelectionBackColor = Color.DarkKhaki;
                        if (dt.Rows[i]["일자명칭"].ToString().ToString().Equals("=== 월계 ==="))
                        {
                            style.ForeColor = Color.Blue;
                        }
                        for (int j = 0; j < inputRmGrid.ColumnCount; j++)
                        {
                            inputRmGrid.Rows[i+1].Cells[j].Style = style;
                        }
                    }
                    if (dt.Rows[i]["INPUT_CD"].ToString().Equals("999999"))
                    {
                        inputRmGrid.Rows[i + 1].Cells["INPUT_CD"].Value = "";
                    }
                    else
                    {
                        inputRmGrid.Rows[i + 1].Cells["INPUT_CD"].Value = dt.Rows[i]["INPUT_CD"].ToString();
                    }

                    if (dt.Rows[i]["SEQ"].ToString().Equals("0"))
                    {
                        inputRmGrid.Rows[i + 1].Cells["SEQ"].Value = "";
                    }
                    else
                    {
                        inputRmGrid.Rows[i + 1].Cells["SEQ"].Value = dt.Rows[i]["SEQ"].ToString();
                    }

                    if (dt.Rows[i]["bun"].ToString().Equals("ㅎ"))
                    {
                        inputRmGrid.Rows[i + 1].Cells["NO"].Value = "";
                    }
                    else
                    {
                        inputRmGrid.Rows[i + 1].Cells["NO"].Value = dt.Rows[i]["bun"].ToString();
                    }

                    inputRmGrid.Rows[i + 1].Cells["PRODUCT_NM"].Value = dt.Rows[i]["RAW_MAT_NM"].ToString();
                    inputRmGrid.Rows[i + 1].Cells["CUST_NM"].Value = dt.Rows[i]["CUST_NM"].ToString();

                    inputRmGrid.Rows[i + 1].Cells["UNIT_NM"].Value = dt.Rows[i]["UNIT_NM"].ToString();
                    if (dt.Rows[i]["RAW_MAT_GUBUN"].ToString().Equals("1"))
                    {
                        inputRmGrid.Rows[i + 1].Cells["PRODUCT_GUBUN"].Value = "원자재";
                    }
                    else if (dt.Rows[i]["RAW_MAT_GUBUN"].ToString().Equals("2"))
                    {
                        inputRmGrid.Rows[i + 1].Cells["PRODUCT_GUBUN"].Value = "부자재";
                    }
                    
                    //inputRmGrid.Rows[i + 1].Cells["INPUT_GUBUN"].Value = dt.Rows[i]["INPUT_GUBUN"].ToString();
                    //if (dt.Rows[i]["bun"].ToString().Equals("출고"))
                    //{
                    //    if (dt.Rows[i]["INPUT_GUBUN"].ToString().Equals("생산출고"))
                    //    {
                    //        inputRmGrid.Rows[i + 1].Cells["OUTPUT_LOT"].Value = dt.Rows[i]["OUTPUT_LOT"].ToString();
                    //    }
                    //    else
                    //    {
                    //        inputRmGrid.Rows[i + 1].Cells["OUTPUT_LOT"].Value = "(" + dt.Rows[i]["OUTPUT_LOT"].ToString() + ")";
                    //    }
                    //}


                    inputRmGrid.Rows[i + 1].Cells["SPEC"].Value = dt.Rows[i]["SPEC"].ToString();
                    inputRmGrid.Rows[i + 1].Cells["OUTPUT_LOT"].Value = dt.Rows[i]["LOT_NO"].ToString();


                    inputRmGrid.Rows[i + 1].Cells["INPUT_AMT"].Value = (decimal.Parse(dt.Rows[i]["INPUT_AMT"].ToString())).ToString("#,0.######");
                    inputRmGrid.Rows[i + 1].Cells["OUTPUT_AMT"].Value = (decimal.Parse(dt.Rows[i]["OUTPUT_AMT"].ToString())).ToString("#,0.######");

                    if (inputRmGrid.Rows[i + 1].Cells["INPUT_AMT"].Value == null || inputRmGrid.Rows[i + 1].Cells["INPUT_AMT"].Value.ToString().Equals("0"))
                    {
                        inputRmGrid.Rows[i + 1].Cells["INPUT_AMT"].Value = "";
                    }
                    if (inputRmGrid.Rows[i + 1].Cells["OUTPUT_AMT"].Value == null || inputRmGrid.Rows[i + 1].Cells["OUTPUT_AMT"].Value.ToString().Equals("0"))
                    {
                        inputRmGrid.Rows[i + 1].Cells["OUTPUT_AMT"].Value = "";
                    }
                    

                }
                adoPrt = dt.Copy();

            }

            //데이타 끝나고 다시 copy를 써준 이유는 for중에 no에 값을 엏었기 때문에 출력물 데이타테이블(dt)를 다시 복사함
        }

        private void grdCellSetting()
        {
            ComInfo comInfo = new ComInfo();
            comInfo.grdCellSetting2(inputRmGrid);
        }

        private void btn출력_Click(object sender, EventArgs e)
        {
            //btn출력.Enabled = false;

            //strCondition = "";

            //if (inputRmGrid.Rows.Count == 0)
            //{
            //    MessageBox.Show("출력할 자료가 없습니다.");
            //    btn출력.Enabled = true;
            //    return;
            //}

            //strDay1 = start_date.Text;
            //strDay2 = end_date.Text;
            //strCondition = "원자재원장현황2";

            //frmPrt = readyPrt;
            //frmPrt.Show();
            //frmPrt.BringToFront();
            ////frmPrt.prt_원자재재고현황(adoPrt, strDay1, strDay2, strCust, strCondition);
            //frmPrt.prt_원장현황(adoPrt, inputRmGrid, strDay1, strDay2, strCondition, txt_raw_nm.Text);

            //btn출력.Enabled = true;
        }

        

        private void cmb_raw_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComInfo.onlyNum(sender, e);

            //if (cmb_raw.Text.Length >= 14)
            //{
            //    StringBuilder sb = new StringBuilder();
            //    sb.AppendLine(" and CONVERT(NVARCHAR(8),CONVERT (DATE, A.INPUT_DATE),112) ");
            //    sb.AppendLine(" +RIGHT('000'+CONVERT(varchar,A.INPUT_CD),4) ");
            //    sb.AppendLine(" +RIGHT('0'+CONVERT(varchar,A.SEQ),2) = '"+cmb_raw.Text.ToString() +"' ");

            //    in_rm_ledger_logic(sb.ToString());
            //}
        }

        private void btn_raw_srch_Click(object sender, EventArgs e)
        {
            Popup.pop원자재검색 msg = new Popup.pop원자재검색();
            //msg.txtSrch.Text = txt_srch.Text();
            msg.ShowDialog();

            if (msg.sRetCode != null && !msg.sRetCode.Equals(""))
            {
                txt_srch.Text = msg.sRetNM;
                txt_srch2.Text = msg.sRetCode;
                raw_mat_temp = msg.sRetNM;

                input_raw_list();
                inputRmGrid.Rows.Clear();
                
            }

        }

        private void in_Item_grade_logic()
        {

            txt_item_grade1.Text = "";
            txt_item_grade2.Text = "";
            txt_item_grade3.Text = "";

            wnDm wDm = new wnDm();
            DataTable dt = null;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" WHERE B.RAW_MAT_CD = '" + txt_srch2.Text.ToString() + "' and A.INPUT_DATE >= '" + start_date.Text.ToString() + "'  and A.INPUT_DATE <= '" + end_date.Text.ToString() + "'  ");

            dt = wDm.fn_Input_Detail_List_Order_Count(sb.ToString());

            if (dt != null && dt.Rows.Count > 0)
            {
                ArrayList arr = new ArrayList();
                arr.Add(txt_item_grade1);
                arr.Add(txt_item_grade2);
                arr.Add(txt_item_grade3);


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TextBox tempGrade = (TextBox)arr[i];
                    tempGrade.Text = dt.Rows[i]["ITEM_NM"].ToString();
                    if (i == 2)
                    {
                        break;
                    }
                }
            }
        }

        private void input_raw_list()
        {
            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = wDm.fn_Raw_Stock_List(DateTime.Today.ToString("yyyy-MM-dd"), " WHERE 1=1 AND A.RAW_MAT_CD = '"+txt_srch2.Text.ToString()+"'  ");
                adoPrt2 = dt.Copy();

                if (dt != null && dt.Rows.Count > 0)
                {
                    txt_raw_cd.Text = dt.Rows[0]["원자재코드"].ToString();
                    txt_raw_nm.Text = dt.Rows[0]["원자재명"].ToString();
                    txt_Cust_Nm.Text = dt.Rows[0]["CUST_NM"].ToString();
                    txt_Spec.Text = dt.Rows[0]["규격"].ToString();
                    if (dt.Rows[0]["RAW_MAT_GUBUN"].ToString().Equals("1"))
                    {
                        txt_raw_gubun.Text = "원자재";
                    }
                    else
                    {
                        txt_raw_gubun.Text = "부자재";
                    }
                    if (dt.Rows[0]["CHECK_GUBUN"].ToString().Equals("1"))
                    {
                        txt_Check_Yn.Text = "검사";
                    }
                    else
                    {
                        txt_Check_Yn.Text = "생략";
                    }
                    txt_balstock.Text = decimal.Parse(dt.Rows[0]["재고량"].ToString()).ToString("#,0.######");

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show("원자재 검색 중 오류가 발생했습니다.");
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                msg.ShowDialog();
                return;
            }
        }

        private void inputRmGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (inputRmGrid.Columns[e.ColumnIndex].Name.Equals("OUTPUT_LOT")
                    && inputRmGrid.Rows[e.RowIndex].Cells["OUTPUT_LOT"].Value != null
                    && !inputRmGrid.Rows[e.RowIndex].Cells["OUTPUT_LOT"].Value.ToString().Equals(""))
                {
                    P40_ITM.frm공정추적 form = new P40_ITM.frm공정추적();
                    form.SrchValue = inputRmGrid.Rows[e.RowIndex].Cells["OUTPUT_LOT"].Value.ToString();
                    form.StartPosition = FormStartPosition.CenterParent;
                    form.Show();
                    form.Srch_by_LotNo(form.SrchValue);
                }
            }
        }

        
        


        private SaveFileDialog GetExcelSave()
        {

            //Getting the location and file name of the excel to save from user.

            SaveFileDialog saveDialog = new SaveFileDialog();

            saveDialog.CheckPathExists = true;

            saveDialog.AddExtension = true;

            saveDialog.ValidateNames = true;

            saveDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);



            saveDialog.DefaultExt = ".xlsx";

            saveDialog.Filter = "Microsoft Excel Workbook (*.xls)|*.xlsx";

            saveDialog.FileName = "StudentData".ToString();



            return saveDialog;

        }

        private void txt_srch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Popup.pop원자재검색 msg = new Popup.pop원자재검색();
                msg.txtSrch.Text = txt_srch.Text.ToString();
                msg.ShowDialog();

                if (msg.sRetCode != null && !msg.sRetCode.Equals(""))
                {
                    txt_srch.Text = msg.sRetNM;
                    txt_srch2.Text = msg.sRetCode;
                    raw_mat_temp = msg.sRetNM;

                    input_raw_list();
                    inputRmGrid.Rows.Clear();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
                    break;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
            return true;
        }

        private void inputRmGrid_VisibleChanged(object sender, EventArgs e)
        {
            ComInfo.gridHeaderSet((DataGridView)sender);
        }

        

    }
}
