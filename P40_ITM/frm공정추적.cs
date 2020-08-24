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
using MES.Controls;

namespace MES.P40_ITM
{
    public partial class frm공정추적 : Form
    {
        private wnGConstant wConst = new wnGConstant();
        private DataGridView del_inputGrid = new DataGridView();
        private DateTimePicker dtp = new DateTimePicker();
        private Rectangle _Retangle;

        private string old_cust_nm = "";
        private bool bHeadCheck = false;
        private ComInfo comInfo = new ComInfo();
        private DataGridView copied_dgv = new DataGridView();

        public string SrchValue = "";
        public string s_GUBUN = "";
        public string s_GUBUN2 = "";
        public string s_INPUT_DATE = "";
        public string s_INPUT_CD = "";
        public string s_INPUT_SEQ = "";

        private bool isUserInput = true;

        private bool first_touch = false;
        public string lotno = "";
        private string currunt_column_temp = "";

        public frm공정추적()
        {
            InitializeComponent();

        }

        private void frm공정추적_Load(object sender, EventArgs e)
        {
            lbl_title.Tag = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[0] + "$" + wnDm.fn_TitleName(this.Name.ToString()).Split('$')[1]; lbl_title.Text = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[2];

            ComInfo.gridHeaderSet(inputTraceGrid);
        }

        private void inputRmSoyoGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_work_inst_srch_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_lot.Text == null) txt_lot.Text = "";
                SrchValue = txt_lot.Text;
                ResetSetting();
                Srch_by_LotNo(SrchValue);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("검색중 오류가 발생했습니다");
                Console.WriteLine(ex);
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                msg.ShowDialog();
                return;
            }
        }

        private void ResetSetting()
        {
            s_GUBUN = "";
            s_GUBUN2 = "";
            s_INPUT_DATE = "";
            s_INPUT_CD = "";
            s_INPUT_SEQ = "";

            txt_amt.Text = "";
            txt_seq.Text = "";
            txt_date.Text = "";
            txt_cd.Text = "";
            txt_label_nm.Text = "";

            lbl_amt.Text = "수량";
            lbl_date.Text = "일자";
        }

        private void ClearGrids()
        {
            txt_input_date.Text = "";
            txt_input_cd.Text = "";
            txt_lot_number.Text = "";
            txt_work_date.Text = "";
            txt_work_cd.Text = "";
            end_req_date.Text = "";
            txt_inst_notice.Text = "";
            txt_complete_yn.Text = "";

            inputTraceGrid.Rows.Clear();

        }

        public void Srch_by_LotNo(string LotNo)
        {
            try
            {
                // 생산 & 지시정보 + 지시 원료육
                wnDm wDm = new wnDm();
                DataTable dt = wDm.fn_flow_trace_list_info_By_Lot(LotNo);
                if (dt != null && dt.Rows.Count > 0)
                {
                    inputTraceGrid.Rows.Clear();

                    txt_input_date.Text = dt.Rows[0]["INPUT_DATE"].ToString();
                    txt_input_cd.Text = dt.Rows[0]["INPUT_CD"].ToString();
                    txt_lot_number.Text = dt.Rows[0]["LOT_NO"].ToString();
                    txt_work_date.Text = dt.Rows[0]["W_INST_DATE"].ToString();
                    txt_work_cd.Text = dt.Rows[0]["W_INST_CD"].ToString();
                    end_req_date.Text = dt.Rows[0]["DELIVERY_DATE"].ToString();
                    txt_inst_notice.Text = dt.Rows[0]["INST_NOTICE"].ToString();

                    if (dt.Rows[0]["COMPLETE_YN"].ToString().Equals("Y"))
                    {
                        txt_complete_yn.Text = "완료";
                    }
                    else
                    {
                        txt_complete_yn.Text = "미완료";
                    }

                    //TRACE GRID
                    dt = wDm.fn_flow_trace_list_By_LotNo(LotNo);

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        inputTraceGrid.RowCount = dt.Rows.Count;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            inputTraceGrid.Rows[i].Cells["GUBUN"].Value = dt.Rows[i]["GUBUN"].ToString();
                            inputTraceGrid.Rows[i].Cells["INPUT_DATE"].Value = dt.Rows[i]["INPUT_DATE"].ToString();
                            inputTraceGrid.Rows[i].Cells["INPUT_CD"].Value = dt.Rows[i]["INPUT_CD"].ToString();
                            inputTraceGrid.Rows[i].Cells["INPUT_SEQ"].Value = dt.Rows[i]["INPUT_SEQ"].ToString();
                            inputTraceGrid.Rows[i].Cells["CUST_NM"].Value = dt.Rows[i]["CUST_NM"].ToString();
                            inputTraceGrid.Rows[i].Cells["RAW_MAT_NM"].Value = dt.Rows[i]["RAW_MAT_NM"].ToString();
                            inputTraceGrid.Rows[i].Cells["SPEC"].Value = dt.Rows[i]["SPEC"].ToString();
                            inputTraceGrid.Rows[i].Cells["UNIT_NM"].Value = dt.Rows[i]["UNIT_NM"].ToString();
                            inputTraceGrid.Rows[i].Cells["INTIME"].Value = dt.Rows[i]["시각"].ToString();
                            inputTraceGrid.Rows[i].Cells["LOT_NO"].Value = dt.Rows[i]["LOT_NO"].ToString();
                            inputTraceGrid.Rows[i].Cells["LOT_SUB"].Value = dt.Rows[i]["LOT_SUB"].ToString();
                            if (dt.Rows[i]["TOTAL_AMT"].ToString().Contains("/"))
                            {
                                string[] sTemp = dt.Rows[i]["TOTAL_AMT"].ToString().Split('/');
                                string sTemp2 = decimal.Parse(sTemp[0]).ToString("#,0.######");
                                sTemp2 += " / " + decimal.Parse(sTemp[1]).ToString("#,0.######");
                                inputTraceGrid.Rows[i].Cells["TOTAL_AMT"].Value = sTemp2;

                            }
                            else if (dt.Rows[i]["TOTAL_AMT"].ToString().Contains("x"))
                            {
                                string[] sTemp = dt.Rows[i]["TOTAL_AMT"].ToString().Split('x');
                                string sTemp2 = decimal.Parse(sTemp[0]).ToString("#,0.######");
                                string[] sTemp3 = sTemp[1].Split('=');
                                sTemp2 += " x " + decimal.Parse(sTemp3[0]).ToString("#,0.######");
                                sTemp2 += " = " + decimal.Parse(sTemp3[1]).ToString("#,0.######");
                                inputTraceGrid.Rows[i].Cells["TOTAL_AMT"].Value = sTemp2;
                            }
                            else
                            {
                                inputTraceGrid.Rows[i].Cells["TOTAL_AMT"].Value = decimal.Parse(dt.Rows[i]["TOTAL_AMT"].ToString()).ToString("#,0.######");
                            }

                            if (dt.Rows[i]["LOSS_AMT"] == null || dt.Rows[i]["LOSS_AMT"].ToString().Equals(""))
                            {
                                inputTraceGrid.Rows[i].Cells["LOSS_AMT"].Value = "";
                            }
                            else
                            {
                                inputTraceGrid.Rows[i].Cells["LOSS_AMT"].Value = decimal.Parse(dt.Rows[i]["LOSS_AMT"].ToString()).ToString("#,0.######");
                                if (inputTraceGrid.Rows[i].Cells["LOSS_AMT"].Value.Equals("0"))
                                {
                                    inputTraceGrid.Rows[i].Cells["LOSS_AMT"].Value = "";
                                }
                            }
                            if (dt.Rows[i]["POOR"] == null || dt.Rows[i]["POOR"].ToString().Equals(""))
                            {
                                inputTraceGrid.Rows[i].Cells["POOR_AMT"].Value = "";
                            }
                            else
                            {
                                inputTraceGrid.Rows[i].Cells["POOR_AMT"].Value = decimal.Parse(dt.Rows[i]["POOR"].ToString()).ToString("#,0.######");
                                if (inputTraceGrid.Rows[i].Cells["POOR_AMT"].Value.Equals("0"))
                                {
                                    inputTraceGrid.Rows[i].Cells["POOR_AMT"].Value = "";
                                }
                            }

                            if (inputTraceGrid.Rows[i].Cells[1].Value.ToString().Contains("음수"))
                            {
                                DataGridViewCellStyle style = new DataGridViewCellStyle();
                                style.BackColor = Color.IndianRed;
                                style.SelectionBackColor = Color.DarkRed;
                                style.ForeColor = Color.White;
                                style.SelectionForeColor = Color.White;
                                for (int j = 1; j < inputTraceGrid.ColumnCount; j++)
                                {
                                    inputTraceGrid.Rows[i].Cells[j].Style = style;
                                }
                            }

                            if (inputTraceGrid.Rows[i].Cells["CUST_NM"].Value.ToString().Contains("합계"))
                            {
                                inputTraceGrid.Rows[i].Cells["INTIME"].Value = "";
                                if (inputTraceGrid.Rows[i].Cells["CUST_NM"].Value.ToString().Contains("총"))
                                {
                                    DataGridViewCellStyle style = new DataGridViewCellStyle();
                                    style.BackColor = Color.Khaki;
                                    style.SelectionBackColor = Color.DarkKhaki;
                                    style.ForeColor = Color.Blue;
                                    for (int j = 5; j < inputTraceGrid.ColumnCount; j++)
                                    {
                                        inputTraceGrid.Rows[i].Cells[j].Style = style;
                                    }
                                }
                                else
                                {
                                    DataGridViewCellStyle style = new DataGridViewCellStyle();
                                    style.BackColor = Color.DarkTurquoise;
                                    style.SelectionBackColor = Color.DarkCyan;
                                    style.ForeColor = Color.Black;
                                    style.SelectionForeColor = Color.White;
                                    //style.BackColor = Color.DarkGray;
                                    //style.SelectionBackColor = Color.Gray;
                                    //style.ForeColor = Color.Black;
                                    //style.SelectionForeColor = Color.Black;
                                    for (int j = 5; j < inputTraceGrid.ColumnCount; j++)
                                    {
                                        inputTraceGrid.Rows[i].Cells[j].Style = style;
                                    }
                                }
                            }

                            //if (dt.Rows[i]["INPUT_DATE"].ToString().Equals("===합계==="))
                            //{
                            //    DataGridViewCellStyle style = new DataGridViewCellStyle();
                            //    style.BackColor = Color.Khaki;
                            //    style.SelectionBackColor = Color.DarkKhaki;
                            //    for (int j = 0; j < inputTraceGrid.ColumnCount; j++)
                            //    {
                            //        inputTraceGrid.Rows[i].Cells[j].Style = style;
                            //    }
                            //}

                            //if ((dt.Rows[i]["GUBUN"].ToString().Equals(s_GUBUN) || dt.Rows[i]["GUBUN"].ToString().Equals(s_GUBUN2))
                            //    && dt.Rows[i]["INPUT_DATE"].ToString().Equals(s_INPUT_DATE)
                            //    && dt.Rows[i]["INPUT_CD"].ToString().Equals(s_INPUT_CD)
                            //    && dt.Rows[i]["INPUT_SEQ"].ToString().Equals(s_INPUT_SEQ))
                            //{

                            //    txt_amt.Text = inputTraceGrid.Rows[i].Cells["TOTAL_AMT"].Value.ToString();
                            //    txt_seq.Text = inputTraceGrid.Rows[i].Cells["INPUT_SEQ"].Value.ToString();
                            //    txt_date.Text = inputTraceGrid.Rows[i].Cells["INPUT_DATE"].Value.ToString();
                            //    txt_cd.Text = inputTraceGrid.Rows[i].Cells["INPUT_CD"].Value.ToString();
                            //    txt_label_nm.Text = inputTraceGrid.Rows[i].Cells["LABEL_NM"].Value.ToString();

                            //    lbl_amt.Text = inputTraceGrid.Rows[i].Cells["GUBUN"].Value.ToString() + "수량";
                            //    lbl_date.Text = inputTraceGrid.Rows[i].Cells["GUBUN"].Value.ToString() + "일자";

                            //    DataGridViewCellStyle style = new DataGridViewCellStyle();
                            //    style.BackColor = Color.IndianRed;
                            //    style.SelectionBackColor = Color.DarkRed;
                            //    style.ForeColor = Color.White;
                            //    style.SelectionForeColor = Color.White;
                            //    for (int j = 3; j < inputTraceGrid.ColumnCount; j++)
                            //    {
                            //        inputTraceGrid.Rows[i].Cells[j].Style = style;
                            //    }
                            //}


                            //if (dt.Rows[i]["GUBUN"].ToString().Equals(txt_search_gubun.Text.ToString())
                            //   && dt.Rows[i]["INPUT_DATE"].ToString().Equals(txt_search_date.Text.ToString())
                            //   && dt.Rows[i]["INPUT_CD"].ToString().Equals(txt_search_cd.Text.ToString())
                            //   && dt.Rows[i]["INPUT_SEQ"].ToString().Equals(txt_search_seq.Text.ToString()))
                            //{

                            //    txt_amt.Text = inputTraceGrid.Rows[i].Cells["TOTAL_AMT"].Value.ToString();
                            //    txt_seq.Text = inputTraceGrid.Rows[i].Cells["INPUT_SEQ"].Value.ToString();
                            //    txt_date.Text = inputTraceGrid.Rows[i].Cells["INPUT_DATE"].Value.ToString();
                            //    txt_cd.Text = inputTraceGrid.Rows[i].Cells["INPUT_CD"].Value.ToString();
                            //    txt_label_nm.Text = inputTraceGrid.Rows[i].Cells["LABEL_NM"].Value.ToString();

                            //    lbl_amt.Text = inputTraceGrid.Rows[i].Cells["GUBUN"].Value.ToString() + "수량";
                            //    lbl_date.Text = inputTraceGrid.Rows[i].Cells["GUBUN"].Value.ToString() + "일자";

                            //    DataGridViewCellStyle style = new DataGridViewCellStyle();
                            //    style.BackColor = Color.IndianRed;
                            //    style.SelectionBackColor = Color.DarkRed;
                            //    style.ForeColor = Color.White;
                            //    style.SelectionForeColor = Color.White;
                            //    for (int j = 3; j < inputTraceGrid.ColumnCount; j++)
                            //    {
                            //        inputTraceGrid.Rows[i].Cells[j].Style = style;
                            //    }
                            //}

                        }
                        wnGConstant wng = new wnGConstant();
                        wng.mergeCells(inputTraceGrid, 3);
                    }
                    else
                    {
                        MessageBox.Show("조회중 오류가 발생하였습니다");
                        return;
                    }


                }
                else
                {
                    if (dt == null || dt.Rows.Count <= 0)
                    {
                        MessageBox.Show("입력된 LOT번호가 존재하지 않습니다.");
                        ClearGrids();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("하나 이상의 LOT번호가 검색됩니다. <오류> ");
                        ClearGrids();
                        return;
                    }
                }


   


            }
            catch (Exception ex)
            {
                MessageBox.Show("검색중 오류가 발생했습니다");
                MessageBox.Show(ex.StackTrace);
                MessageBox.Show(ex+"");
                Console.WriteLine(ex);
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                msg.ShowDialog();
                return;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void inputTraceGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (true)
                {
                    txt_amt.Text = "";
                    txt_date.Text = "";
                    txt_cd.Text = "";
                    txt_seq.Text = "";
                    txt_label_nm.Text = "";

                    if (inputTraceGrid.Rows[e.RowIndex].Cells["GUBUN"].Value.ToString().Equals("지시"))
                    {
                        txt_amt.Text = inputTraceGrid.Rows[e.RowIndex].Cells["TOTAL_AMT"].Value.ToString();
                        txt_date.Text = inputTraceGrid.Rows[e.RowIndex].Cells["INPUT_DATE"].Value.ToString();
                        txt_cd.Text = inputTraceGrid.Rows[e.RowIndex].Cells["INPUT_CD"].Value.ToString();
                        txt_label_nm.Text = inputTraceGrid.Rows[e.RowIndex].Cells["RAW_MAT_NM"].Value.ToString();
                    }
                    else
                    {
                        txt_amt.Text = inputTraceGrid.Rows[e.RowIndex].Cells["TOTAL_AMT"].Value.ToString();
                        txt_seq.Text = inputTraceGrid.Rows[e.RowIndex].Cells["INPUT_SEQ"].Value.ToString();
                        txt_date.Text = inputTraceGrid.Rows[e.RowIndex].Cells["INPUT_DATE"].Value.ToString();
                        txt_cd.Text = inputTraceGrid.Rows[e.RowIndex].Cells["INPUT_CD"].Value.ToString();
                        txt_label_nm.Text = inputTraceGrid.Rows[e.RowIndex].Cells["RAW_MAT_NM"].Value.ToString();
                    }
                }
            }
        }

        //private void inputRmGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{

        //    conDataGridView grd = (conDataGridView)sender;

        //    grd.EndEdit();
        //    //DataGridViewRow Row = grd.SelectedCells[17].OwningRow;
        //    int col = grd.Columns.Count - 1;
        //    if (grd.SelectedCells[col].ColumnIndex == col && grd.SelectedCells[col].Value as bool? == true)
        //    {
        //        grd.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Red;
        //    }
        //    else
        //    {
        //        grd.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;

        //    }
        //}

        public void startsearch(object sender, EventArgs e)
        {
            sender = (Button)sender;
            btn_work_inst_srch_Click(sender, e);
        }

        private void txt_lotno_TextChanged(object sender, EventArgs e)
        {
            if (!txt_lotno.Text.ToString().Equals("") || (txt_lotno.Text != null) &&
                !txt_search_date.Text.ToString().Equals("") || (txt_search_date.Text != null) &&
                !txt_search_cd.Text.ToString().Equals("") || (txt_search_cd.Text != null) &&
                !txt_search_seq.Text.ToString().Equals("") || (txt_search_seq.Text != null) &&
                !txt_search_gubun.Text.ToString().Equals("") || (txt_search_gubun.Text != null))
            {
                ResetSetting();
                Srch_by_LotNo(txt_lotno.Text.ToString());
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
                    btn_work_inst_srch.PerformClick();
                    break;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
            return true;
        }

        private void btn_work_srch_Click(object sender, EventArgs e)
        {
            Popup.pop작업지시검색 frm = new Popup.pop작업지시검색(1);

            frm.ShowDialog();

            if (frm.sCode != "")
            {
                txt_lot.Text = frm.dgv.Rows[0].Cells["LOT_NO"].Value.ToString();
                btn_work_inst_srch.PerformClick();
            }

            frm.Dispose();
            frm = null;
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
