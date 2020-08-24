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

namespace MES.S20_BILL
{
    public partial class frm홈텍스엑셀작성 : Form
    {
        
        private wnGConstant wConst = new wnGConstant();

        bool loadFlag = true;


        public frm홈텍스엑셀작성()
        {
            InitializeComponent();
        }

        private void frm홈텍스엑셀작성_Load(object sender, EventArgs e)
        {
            lbl_title.Tag = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[0] + "$" + wnDm.fn_TitleName(this.Name.ToString()).Split('$')[1]; lbl_title.Text = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[2];

            start_date.Text = DateTime.Now.ToString("yyyy-MM-dd").Substring(0, 8) + "01";
            txt_publish_date.Text = DateTime.Now.ToString("yyyy-MM-dd");
            init_combobox();
            resetSetting();
            loadFlag = false;
            //LoadBillGrid();
        }

        private void resetSetting()
        {
            txt_publish_date.Text = DateTime.Now.ToString("yyyy-MM-dd");
            txt_publish_cd.Text = "";
            lbl_input_gubun.Text = "";
            txt_excel_title.Text = "";
            cmb_vat_gubun.Enabled = true;
            LoadBillGrid();
            input_list();
            btnDelete.Enabled = false;
            btn출력.Enabled = false;
            BillGrid.Columns["선택"].Visible = true;
            BillGrid.Columns["참고"].Visible = true;
        }

        private void init_combobox()
        {
            ComInfo comInfo = new ComInfo();
            string sqlQuery = "";
            cmb_vat_gubun.ValueMember = "코드";
            cmb_vat_gubun.DisplayMember = "명칭";
            sqlQuery = comInfo.queryVatAll();
            wConst.ComboBox_Read_NoBlank(cmb_vat_gubun, sqlQuery);
        }

        private void LoadBillGrid()
        {
            wnDm wDm = new wnDm();
            lblMsg.Visible = true;
            Application.DoEvents();
            try
            {
                DataTable dt = new DataTable();
                string condition = "AND A.BILL_DATE >= '" + start_date.Text + "' and A.BILL_DATE <= '" + end_date.Text + "' and PUBLISH_YN = 'N' and A.VAT_CD = '"+cmb_vat_gubun.SelectedValue.ToString()+"' ";
                dt = wDm.fn_Select_Bill_to_Excel_List(condition);

                BillGrid.Rows.Clear();

                if (dt != null && dt.Rows.Count > 0)
                {
                    BillGrid.RowCount = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //화면출력용
                        BillGrid.Rows[i].Cells["선택"].Value = false;
                        BillGrid.Rows[i].Cells["BILL_DATE"].Value = dt.Rows[i]["BILL_DATE"].ToString();
                        BillGrid.Rows[i].Cells["BILL_CD"].Value = dt.Rows[i]["BILL_CD"].ToString();
                        string supply_saup_no = dt.Rows[i]["공급자등록번호"].ToString().Substring(0,3)
                                                + "-" + dt.Rows[i]["공급자등록번호"].ToString().Substring(3,2)
                                                + "-" + dt.Rows[i]["공급자등록번호"].ToString().Substring(5);
                        string get_saup_no = "";
                        if (dt.Rows[i]["공급받는자등록번호"] != null && !dt.Rows[i]["공급받는자등록번호"].ToString().Equals(""))
                        {
                            get_saup_no = dt.Rows[i]["공급받는자등록번호"].ToString().Substring(0, 3)
                                                + "-" + dt.Rows[i]["공급받는자등록번호"].ToString().Substring(3, 2)
                                                + "-" + dt.Rows[i]["공급받는자등록번호"].ToString().Substring(5);
                        }
                        BillGrid.Rows[i].Cells["SUPPLY_SAUP_NO"].Value = supply_saup_no;
                        BillGrid.Rows[i].Cells["GET_SAUP_NO"].Value = get_saup_no;
                        BillGrid.Rows[i].Cells["SUPPLY_NAME"].Value = dt.Rows[i]["공급자상호"].ToString();
                        BillGrid.Rows[i].Cells["GET_NAME"].Value = dt.Rows[i]["공급받는자상호"].ToString();
                        BillGrid.Rows[i].Cells["PRINT_PRODUCT"].Value = dt.Rows[i]["품목1"].ToString();
                        BillGrid.Rows[i].Cells["ALL_TOTAL_MONEY"].Value = decimal.Parse(dt.Rows[i]["ALL_TOTAL_MONEY"].ToString()).ToString("#,0.######");
                        BillGrid.Rows[i].Cells["SUPPLY_EMAIL"].Value = dt.Rows[i]["공급자이메일"].ToString();
                        BillGrid.Rows[i].Cells["GET_EMAIL"].Value = dt.Rows[i]["공급받는자이메일1"].ToString();
                        BillGrid.Rows[i].Cells["CUST_CD"].Value = dt.Rows[i]["CUST_CD"].ToString();






                        //세금신고용
                        BillGrid.Rows[i].Cells["계산서종류"].Value = dt.Rows[i]["계산서종류"].ToString();
                        BillGrid.Rows[i].Cells["작성일자"].Value = dt.Rows[i]["작성일자"].ToString();
                        BillGrid.Rows[i].Cells["공급자등록번호"].Value = dt.Rows[i]["공급자등록번호"].ToString();
                        BillGrid.Rows[i].Cells["공급자종사업장번호"].Value = dt.Rows[i]["공급자종사업장번호"].ToString();
                        BillGrid.Rows[i].Cells["공급자상호"].Value = dt.Rows[i]["공급자상호"].ToString();
                        BillGrid.Rows[i].Cells["공급자성명"].Value = dt.Rows[i]["공급자성명"].ToString();
                        BillGrid.Rows[i].Cells["공급자사업장주소"].Value = dt.Rows[i]["공급자사업장주소"].ToString();
                        BillGrid.Rows[i].Cells["공급자업태"].Value = dt.Rows[i]["공급자업태"].ToString();
                        BillGrid.Rows[i].Cells["공급자종목"].Value = dt.Rows[i]["공급자종목"].ToString();
                        BillGrid.Rows[i].Cells["공급자이메일"].Value = dt.Rows[i]["공급자이메일"].ToString();
                        BillGrid.Rows[i].Cells["공급받는자등록번호"].Value = dt.Rows[i]["공급받는자등록번호"].ToString();
                        BillGrid.Rows[i].Cells["공급받는자종사업장번호"].Value = dt.Rows[i]["공급받는자종사업장번호"].ToString();
                        BillGrid.Rows[i].Cells["공급받는자상호"].Value = dt.Rows[i]["공급받는자상호"].ToString();
                        BillGrid.Rows[i].Cells["공급받는자성명"].Value = dt.Rows[i]["공급받는자성명"].ToString();
                        BillGrid.Rows[i].Cells["공급받는자사업장주소"].Value = dt.Rows[i]["공급받는자사업장주소"].ToString();
                        BillGrid.Rows[i].Cells["공급받는자업태"].Value = dt.Rows[i]["공급받는자업태"].ToString();
                        BillGrid.Rows[i].Cells["공급받는자종목"].Value = dt.Rows[i]["공급받는자종목"].ToString();
                        BillGrid.Rows[i].Cells["공급받는자이메일1"].Value = dt.Rows[i]["공급받는자이메일1"].ToString();
                        BillGrid.Rows[i].Cells["공급받는자이메일2"].Value = dt.Rows[i]["공급받는자이메일2"].ToString();
                        BillGrid.Rows[i].Cells["공급가액"].Value = decimal.Parse(dt.Rows[i]["공급가액"].ToString()).ToString("0.######");
                        BillGrid.Rows[i].Cells["세액"].Value = decimal.Parse(dt.Rows[i]["세액"].ToString()).ToString("0.######");
                        BillGrid.Rows[i].Cells["비고"].Value = dt.Rows[i]["비고"].ToString();
                        BillGrid.Rows[i].Cells["일자1"].Value = dt.Rows[i]["일자1"].ToString();
                        BillGrid.Rows[i].Cells["품목1"].Value = dt.Rows[i]["품목1"].ToString();
                        BillGrid.Rows[i].Cells["규격1"].Value = dt.Rows[i]["규격1"].ToString();
                        BillGrid.Rows[i].Cells["수량1"].Value = decimal.Parse(dt.Rows[i]["수량1"].ToString()).ToString("0.######");
                        BillGrid.Rows[i].Cells["단가1"].Value = decimal.Parse(dt.Rows[i]["단가1"].ToString()).ToString("0.######");
                        BillGrid.Rows[i].Cells["공급가액1"].Value = decimal.Parse(dt.Rows[i]["공급가액1"].ToString()).ToString("0.######");
                        BillGrid.Rows[i].Cells["세액1"].Value = decimal.Parse(dt.Rows[i]["세액1"].ToString()).ToString("0.######");
                        BillGrid.Rows[i].Cells["품목비고1"].Value = dt.Rows[i]["품목비고1"].ToString();


                        for (int j = 2; j <= 4; j++)
                        {
                            BillGrid.Rows[i].Cells["일자" + j].Value = dt.Rows[i]["일자" + j].ToString();
                            BillGrid.Rows[i].Cells["품목" + j].Value = dt.Rows[i]["품목" + j].ToString();
                            BillGrid.Rows[i].Cells["규격" + j].Value = dt.Rows[i]["규격" + j].ToString();
                            BillGrid.Rows[i].Cells["수량" + j].Value = dt.Rows[i]["수량" + j].ToString();
                            BillGrid.Rows[i].Cells["단가" + j].Value = dt.Rows[i]["단가" + j].ToString();
                            BillGrid.Rows[i].Cells["공급가액" + j].Value = dt.Rows[i]["공급가액" + j].ToString();
                            BillGrid.Rows[i].Cells["세액" + j].Value = dt.Rows[i]["세액" + j].ToString();
                            BillGrid.Rows[i].Cells["품목비고" + j].Value = dt.Rows[i]["품목비고" + j].ToString();
                        }
                        BillGrid.Rows[i].Cells["현금"].Value = dt.Rows[i]["현금"].ToString();
                        BillGrid.Rows[i].Cells["수표"].Value = dt.Rows[i]["수표"].ToString();
                        BillGrid.Rows[i].Cells["어음"].Value = dt.Rows[i]["어음"].ToString();
                        BillGrid.Rows[i].Cells["외상미수금"].Value = dt.Rows[i]["외상미수금"].ToString();
                        BillGrid.Rows[i].Cells["영수청구"].Value = dt.Rows[i]["영수청구"].ToString();

                        if (wConst.checkBisNo(BillGrid.Rows[i].Cells["공급자등록번호"].Value.ToString()))
                        {
                            if (wConst.checkBisNo(BillGrid.Rows[i].Cells["공급받는자등록번호"].Value.ToString()))
                            {
                                BillGrid.Rows[i].Cells["참고"].Value = "정상";
                                DataGridViewCellStyle style = new DataGridViewCellStyle();
                                style.BackColor = Color.PaleGreen;
                                BillGrid.Rows[i].Cells["참고"].Style = style;
                            }
                            else
                            {
                                BillGrid.Rows[i].Cells["참고"].Value = "공급받는자 사업자번호 오류";
                                DataGridViewCellStyle style = new DataGridViewCellStyle();
                                style.BackColor = Color.LightPink;
                                BillGrid.Rows[i].Cells["참고"].Style = style;
                            }
                        }
                        else
                        {
                            BillGrid.Rows[i].Cells["참고"].Value = "공급자 사업자번호 오류";
                            DataGridViewCellStyle style = new DataGridViewCellStyle();
                            style.BackColor = Color.LightPink;
                            BillGrid.Rows[i].Cells["참고"].Style = style;
                        }

                        


                        

                    }
                }
                else
                {
                    //MessageBox.Show("dtisnull");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception 오류"+ ex+"");
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                msg.ShowDialog();

            }

            lblMsg.Visible = false;
        }

        #region button logic

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        
        

        #endregion button logic


        private void input_list()
        {
            try
            {
                wnDm wDm = new wnDm();
                string thisYear = year.Text.ToString().Substring(0, 4);
                string condition = "and PUBLISH_DATE >= '" + thisYear + "-01-01' and PUBLISH_DATE <= '" + thisYear + "-12-32'  ";
                DataTable dt = wDm.fn_Select_Excel_List(condition);

                ExcelGrid.Rows.Clear();
                if (dt != null && dt.Rows.Count > 0)
                {
                    ExcelGrid.RowCount = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ExcelGrid.Rows[i].Cells["생성일자"].Value = dt.Rows[i]["PUBLISH_DATE"].ToString();
                        ExcelGrid.Rows[i].Cells["번호2"].Value = dt.Rows[i]["PUBLISH_CD"].ToString();
                        ExcelGrid.Rows[i].Cells["엑셀제목"].Value = dt.Rows[i]["TITLE"].ToString();
                        ExcelGrid.Rows[i].Cells["VAT_CD"].Value = dt.Rows[i]["VAT_CD"].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception 에러");
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                msg.ShowDialog();
                return;
            }
        }

        

        private void grdCellSetting()
        {
        }

        private void btn출력_Click(object sender, EventArgs e)
        {
            btn출력.Enabled = false;

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Save as Excel File";
            sfd.Filter = "Excel 97 - 2003 통합문서(*.xls)|*.xls";
            
            sfd.FileName = txt_excel_title.Text.ToString();
            
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                lblMsg.Visible = true;
                Application.DoEvents();
                wnGConstant.dataGridView_ExportToExcel_Excel(sfd.FileName, BillGrid, cmb_vat_gubun.SelectedValue.ToString());
                lblMsg.Visible = false;
                MessageBox.Show("엑셀 출력이 완료되었습니다");
            }




            btn출력.Enabled = true;
        }

        private void btn_srch1_Click(object sender, EventArgs e)
        {
            LoadBillGrid();
        }

        private void BillGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                if (BillGrid.Columns[e.ColumnIndex].Name.Equals("선택"))
                {
                    lbl_title.Focus();
                    if (BillGrid.Columns[e.ColumnIndex].HeaderText.Equals("[ ]"))
                    {
                        BillGrid.Columns[e.ColumnIndex].HeaderText = "[v]";
                        for (int i = 0; i < BillGrid.Rows.Count; i++)
                        {
                            BillGrid.Rows[i].Cells["선택"].Value = true;
                        }
                    }
                    else
                    {
                        BillGrid.Columns[e.ColumnIndex].HeaderText = "[ ]";
                        for (int i = 0; i < BillGrid.Rows.Count; i++)
                        {
                            BillGrid.Rows[i].Cells["선택"].Value = false;
                        }
                    }

                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_excel_title.Text == null || txt_excel_title.ToString().Equals("") || txt_excel_title.Text.ToString().Length ==0)
                {
                    MessageBox.Show("[엑셀제목] 을 입력해주세요.");
                    return;
                }




                if (lbl_input_gubun.Text == null || !lbl_input_gubun.Text.ToString().Equals("1") || lbl_input_gubun.Text.ToString().Length == 0)
                {
                    bool isValue = false;
                    for (int i = 0; i < BillGrid.Rows.Count; i++)
                    {
                        if ((bool)BillGrid.Rows[i].Cells["선택"].Value == true)
                        {
                            isValue = true;
                        }
                        else
                        {
                            BillGrid.Rows.RemoveAt(i);
                            i--;
                        }
                    }
                    if (!isValue)
                    {
                        MessageBox.Show("최소 하나이상의 항목을 선택하여주십시오.");
                        return;
                    }

                    wnDm wDm = new wnDm();
                    int rsNum = wDm.insert_Excel_input(
                        txt_publish_date.Text.ToString()
                        , txt_excel_title.Text.ToString()
                        , cmb_vat_gubun.SelectedValue.ToString()
                        , BillGrid
                        );

                    if (rsNum == 0)
                    {
                        resetSetting();
                    }
                    else if (rsNum == 1)
                    {
                        MessageBox.Show("저장에 실패하였습니다");
                        LoadBillGrid();
                    }
                    else MessageBox.Show("sql 에러");

                }

                else
                {
                    wnDm wDm = new wnDm();
                    int rsNum = wDm.Update_Excel_input(
                        txt_publish_date.Text.ToString()
                        , txt_publish_cd.Text.ToString()
                        , txt_excel_title.Text.ToString()
                        );

                    if (rsNum == 0)
                    {
                        resetSetting();
                    }
                    else if (rsNum == 1)
                    {
                        MessageBox.Show("저장에 실패하였습니다");
                        
                    }
                    else MessageBox.Show("sql 에러");


                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception 오류");
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                msg.ShowDialog();
                return;
            }


        }

        private void ExcelGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                input_detail(
                    ExcelGrid.Rows[e.RowIndex].Cells["생성일자"].Value.ToString()
                    ,ExcelGrid.Rows[e.RowIndex].Cells["번호2"].Value.ToString()
                    , ExcelGrid.Rows[e.RowIndex].Cells["엑셀제목"].Value.ToString()
                    , ExcelGrid.Rows[e.RowIndex].Cells["VAT_CD"].Value.ToString()
                    );
            }
        }

        private void input_detail(string publish_date, string publish_cd, string title, string vat_cd)
        {
            try
            {
                lbl_input_gubun.Text = "1";
                btn출력.Enabled = true;
                btnDelete.Enabled = true;
                BillGrid.Columns["선택"].Visible = false;
                BillGrid.Columns["참고"].Visible = false;
                cmb_vat_gubun.SelectedValue = vat_cd;
                cmb_vat_gubun.Enabled = false;
                txt_publish_date.Text = publish_date;
                txt_publish_cd.Text = publish_cd;
                txt_excel_title.Text = title;
                wnDm wDm = new wnDm();
                DataTable dt = wDm.fn_Select_Excel_Detail_List(" and X.PUBLISH_DATE = '" + publish_date + "' and X.PUBLISH_CD = '" + publish_cd + "'  ");
                BillGrid.Rows.Clear();
                if (dt != null && dt.Rows.Count > 0)
                {
                    BillGrid.RowCount = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //화면출력용
                        BillGrid.Rows[i].Cells["선택"].Value = false;
                        BillGrid.Rows[i].Cells["BILL_DATE"].Value = dt.Rows[i]["BILL_DATE"].ToString();
                        BillGrid.Rows[i].Cells["BILL_CD"].Value = dt.Rows[i]["BILL_CD"].ToString();
                        string supply_saup_no = dt.Rows[i]["공급자등록번호"].ToString().Substring(0,3)
                                                + "-" + dt.Rows[i]["공급자등록번호"].ToString().Substring(3,2)
                                                + "-" + dt.Rows[i]["공급자등록번호"].ToString().Substring(5);
                        string get_saup_no = "";
                        if (dt.Rows[i]["공급받는자등록번호"] != null && !dt.Rows[i]["공급받는자등록번호"].ToString().Equals(""))
                        {
                            get_saup_no = dt.Rows[i]["공급받는자등록번호"].ToString().Substring(0, 3)
                                                + "-" + dt.Rows[i]["공급받는자등록번호"].ToString().Substring(3, 2)
                                                + "-" + dt.Rows[i]["공급받는자등록번호"].ToString().Substring(5);
                        }
                        BillGrid.Rows[i].Cells["SUPPLY_SAUP_NO"].Value = supply_saup_no;
                        BillGrid.Rows[i].Cells["GET_SAUP_NO"].Value = get_saup_no;
                        BillGrid.Rows[i].Cells["SUPPLY_NAME"].Value = dt.Rows[i]["공급자상호"].ToString();
                        BillGrid.Rows[i].Cells["GET_NAME"].Value = dt.Rows[i]["공급받는자상호"].ToString();
                        BillGrid.Rows[i].Cells["PRINT_PRODUCT"].Value = dt.Rows[i]["품목1"].ToString();
                        BillGrid.Rows[i].Cells["ALL_TOTAL_MONEY"].Value = decimal.Parse(dt.Rows[i]["ALL_TOTAL_MONEY"].ToString()).ToString("#,0.######");
                        BillGrid.Rows[i].Cells["SUPPLY_EMAIL"].Value = dt.Rows[i]["공급자이메일"].ToString();
                        BillGrid.Rows[i].Cells["GET_EMAIL"].Value = dt.Rows[i]["공급받는자이메일1"].ToString();
                        BillGrid.Rows[i].Cells["CUST_CD"].Value = dt.Rows[i]["CUST_CD"].ToString();

                        //세금신고용
                        BillGrid.Rows[i].Cells["계산서종류"].Value = dt.Rows[i]["계산서종류"].ToString();
                        BillGrid.Rows[i].Cells["작성일자"].Value = dt.Rows[i]["작성일자"].ToString();
                        BillGrid.Rows[i].Cells["공급자등록번호"].Value = dt.Rows[i]["공급자등록번호"].ToString();
                        BillGrid.Rows[i].Cells["공급자종사업장번호"].Value = dt.Rows[i]["공급자종사업장번호"].ToString();
                        BillGrid.Rows[i].Cells["공급자상호"].Value = dt.Rows[i]["공급자상호"].ToString();
                        BillGrid.Rows[i].Cells["공급자성명"].Value = dt.Rows[i]["공급자성명"].ToString();
                        BillGrid.Rows[i].Cells["공급자사업장주소"].Value = dt.Rows[i]["공급자사업장주소"].ToString();
                        BillGrid.Rows[i].Cells["공급자업태"].Value = dt.Rows[i]["공급자업태"].ToString();
                        BillGrid.Rows[i].Cells["공급자종목"].Value = dt.Rows[i]["공급자종목"].ToString();
                        BillGrid.Rows[i].Cells["공급자이메일"].Value = dt.Rows[i]["공급자이메일"].ToString();
                        BillGrid.Rows[i].Cells["공급받는자등록번호"].Value = dt.Rows[i]["공급받는자등록번호"].ToString();
                        BillGrid.Rows[i].Cells["공급받는자종사업장번호"].Value = dt.Rows[i]["공급받는자종사업장번호"].ToString();
                        BillGrid.Rows[i].Cells["공급받는자상호"].Value = dt.Rows[i]["공급받는자상호"].ToString();
                        BillGrid.Rows[i].Cells["공급받는자성명"].Value = dt.Rows[i]["공급받는자성명"].ToString();
                        BillGrid.Rows[i].Cells["공급받는자사업장주소"].Value = dt.Rows[i]["공급받는자사업장주소"].ToString();
                        BillGrid.Rows[i].Cells["공급받는자업태"].Value = dt.Rows[i]["공급받는자업태"].ToString();
                        BillGrid.Rows[i].Cells["공급받는자종목"].Value = dt.Rows[i]["공급받는자종목"].ToString();
                        BillGrid.Rows[i].Cells["공급받는자이메일1"].Value = dt.Rows[i]["공급받는자이메일1"].ToString();
                        BillGrid.Rows[i].Cells["공급받는자이메일2"].Value = dt.Rows[i]["공급받는자이메일2"].ToString();
                        BillGrid.Rows[i].Cells["공급가액"].Value = decimal.Parse(dt.Rows[i]["공급가액"].ToString()).ToString("0.######");
                        BillGrid.Rows[i].Cells["세액"].Value = decimal.Parse(dt.Rows[i]["세액"].ToString()).ToString("0.######");
                        BillGrid.Rows[i].Cells["비고"].Value = dt.Rows[i]["비고"].ToString();
                        BillGrid.Rows[i].Cells["일자1"].Value = dt.Rows[i]["일자1"].ToString();
                        BillGrid.Rows[i].Cells["품목1"].Value = dt.Rows[i]["품목1"].ToString();
                        BillGrid.Rows[i].Cells["규격1"].Value = dt.Rows[i]["규격1"].ToString();
                        BillGrid.Rows[i].Cells["수량1"].Value = decimal.Parse(dt.Rows[i]["수량1"].ToString()).ToString("0.######");
                        BillGrid.Rows[i].Cells["단가1"].Value = decimal.Parse(dt.Rows[i]["단가1"].ToString()).ToString("0.######");
                        BillGrid.Rows[i].Cells["공급가액1"].Value = decimal.Parse(dt.Rows[i]["공급가액1"].ToString()).ToString("0.######");
                        BillGrid.Rows[i].Cells["세액1"].Value = decimal.Parse(dt.Rows[i]["세액1"].ToString()).ToString("0.######");
                        BillGrid.Rows[i].Cells["품목비고1"].Value = dt.Rows[i]["품목비고1"].ToString();


                        for (int j = 2; j <= 4; j++)
                        {
                            BillGrid.Rows[i].Cells["일자" + j].Value = dt.Rows[i]["일자" + j].ToString();
                            BillGrid.Rows[i].Cells["품목" + j].Value = dt.Rows[i]["품목" + j].ToString();
                            BillGrid.Rows[i].Cells["규격" + j].Value = dt.Rows[i]["규격" + j].ToString();
                            BillGrid.Rows[i].Cells["수량" + j].Value = dt.Rows[i]["수량" + j].ToString();
                            BillGrid.Rows[i].Cells["단가" + j].Value = dt.Rows[i]["단가" + j].ToString();
                            BillGrid.Rows[i].Cells["공급가액" + j].Value = dt.Rows[i]["공급가액" + j].ToString();
                            BillGrid.Rows[i].Cells["세액" + j].Value = dt.Rows[i]["세액" + j].ToString();
                            BillGrid.Rows[i].Cells["품목비고" + j].Value = dt.Rows[i]["품목비고" + j].ToString();
                        }
                        BillGrid.Rows[i].Cells["현금"].Value = dt.Rows[i]["현금"].ToString();
                        BillGrid.Rows[i].Cells["수표"].Value = dt.Rows[i]["수표"].ToString();
                        BillGrid.Rows[i].Cells["어음"].Value = dt.Rows[i]["어음"].ToString();
                        BillGrid.Rows[i].Cells["외상미수금"].Value = dt.Rows[i]["외상미수금"].ToString();
                        BillGrid.Rows[i].Cells["영수청구"].Value = dt.Rows[i]["영수청구"].ToString();

                        if (wConst.checkBisNo(BillGrid.Rows[i].Cells["공급자등록번호"].Value.ToString()))
                        {
                            if (wConst.checkBisNo(BillGrid.Rows[i].Cells["공급받는자등록번호"].Value.ToString()))
                            {
                                BillGrid.Rows[i].Cells["참고"].Value = "정상";
                                DataGridViewCellStyle style = new DataGridViewCellStyle();
                                style.BackColor = Color.PaleGreen;
                                BillGrid.Rows[i].Cells["참고"].Style = style;
                            }
                            else
                            {
                                BillGrid.Rows[i].Cells["참고"].Value = "공급받는자 사업자번호 오류";
                                DataGridViewCellStyle style = new DataGridViewCellStyle();
                                style.BackColor = Color.LightPink;
                                BillGrid.Rows[i].Cells["참고"].Style = style;
                            }
                        }
                        else
                        {
                            BillGrid.Rows[i].Cells["참고"].Value = "공급자 사업자번호 오류";
                            DataGridViewCellStyle style = new DataGridViewCellStyle();
                            style.BackColor = Color.LightPink;
                            BillGrid.Rows[i].Cells["참고"].Style = style;
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception 발생");
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                msg.ShowDialog();
            }


        }

        private void cmb_vat_gubun_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!loadFlag)
            {
                LoadBillGrid();
            }
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            resetSetting();
        }

        private void btn_srch2_Click(object sender, EventArgs e)
        {
            input_list();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                wnDm wDm = new wnDm();
                int rsNum = wDm.Delete_Excel_Input(txt_publish_date.Text.ToString(), txt_publish_cd.Text.ToString(),BillGrid);

                if (rsNum == 0)
                {
                    resetSetting();
                }
                else if (rsNum == 1)
                {
                    MessageBox.Show("삭제에 실패하였습니다");
                }
                else
                {
                    MessageBox.Show("sql 에러");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception 오류");
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                msg.ShowDialog();

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
                    else
                    {
                        return base.ProcessCmdKey(ref msg, keyData);
                    }
                    break;
                case Keys.S:
                    // 조합키 사용 시
                    if ((keyData & Keys.Control) != 0)
                    {
                        btnSave.PerformClick();
                    }
                    else
                    {
                        return base.ProcessCmdKey(ref msg, keyData);
                    }
                    break;
                case Keys.F5:
                    // 단일키 사용시
                    btnNew.PerformClick();
                    break;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
            return true;
        }

       
       
        
    }
}
