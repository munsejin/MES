﻿using System;
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
    public partial class frm원자재재고현황 : Form
    {
        Popup.frmPrint readyPrt = new Popup.frmPrint();
        private wnGConstant wConst = new wnGConstant();

        DataTable adoPrt = null;
        wnAdo wAdo = new wnAdo();
        public Popup.frmPrint frmPrt;

        public string strDay1 = "";
        public string strDay2 = "";
        public string strCondition = "";
        public static bool p_IsAuth = true;    // 열람권한
        public static bool p_Isrgstr = true;    //등록/수정 권한

        public static bool p_Isdel = true;    // 삭제 권한
        wnDm wnDm = new wnDm();
        public frm원자재재고현황()
        {
            InitializeComponent();
        }
        private void frm원자재재고현황_Load(object sender, EventArgs e)
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
            if (btn_stock_ok.Checked == true)
            {
                sb.AppendLine(" and ISNULL(B.INPUT_AMT,0) - ISNULL(C.OUTPUT_AMT,0) > 0 ");
            }
            else if (btn_stock_no.Checked == true)
            {
                sb.AppendLine(" and ISNULL(B.INPUT_AMT,0) - ISNULL(C.OUTPUT_AMT,0) <= 0 ");
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
           
            dt = wDm.fn_Raw_Stock_List(DateTime.Now.ToString("yyyy-MM-dd"), sb.ToString());

            rawStockGrid.Rows.Clear();
            rawDetailGrid.Rows.Clear();
            lbl_raw_nm.Text = "";

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
                        label1.Visible = true;
                        rawStockGrid.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                        rawStockGrid.Rows[i].DefaultCellStyle.ForeColor = Color.White;
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

            if (e.RowIndex < 0) return;

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



                    rawDetailGrid.Rows[i].Cells["구매처명"].Value = dt.Rows[i]["CUST_NM"].ToString();
                    rawDetailGrid.Rows[i].Cells["INPUT_CD"].Value = dt.Rows[i]["INPUT_CD"].ToString();
                    rawDetailGrid.Rows[i].Cells["INPUT_SEQ"].Value = dt.Rows[i]["SEQ"].ToString();
                    rawDetailGrid.Rows[i].Cells["INPUT_DATE"].Value = dt.Rows[i]["INPUT_DATE"].ToString();
                    rawDetailGrid.Rows[i].Cells["R_INPUT_AMT"].Value = (decimal.Parse(dt.Rows[i]["INPUT_AMT"].ToString())).ToString("#,0.######");
                    rawDetailGrid.Rows[i].Cells["R_OUTPUT_AMT"].Value = (decimal.Parse(dt.Rows[i]["OUTPUT_AMT"].ToString())).ToString("#,0.######");
                    rawDetailGrid.Rows[i].Cells["R_STOCK_AMT"].Value = (decimal.Parse(dt.Rows[i]["STOCK_AMT"].ToString())).ToString("#,0.######");
                    rawDetailGrid.Rows[i].Cells["STORAGE_NM"].Value =dt.Rows[i]["STORAGE_NM"].ToString();
                    rawDetailGrid.Rows[i].Cells["STORAGE_CD"].Value = dt.Rows[i]["STORAGE_CD"].ToString();
                    rawDetailGrid.Rows[i].Cells["LOC_CD"].Value = dt.Rows[i]["LOC_CD"].ToString();
                    rawDetailGrid.Rows[i].Cells["LOC_NM"].Value = dt.Rows[i]["LOC_NM"].ToString();


               
                    if (dt.Rows[i]["INPUT_CD"].ToString() == "합계")
                    {
                        this.rawDetailGrid.Rows[i].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                        this.rawDetailGrid.Rows[i].Cells["INPUT_SEQ"].Value = (object)"";
                        this.rawDetailGrid.Rows[i].DefaultCellStyle.ForeColor = Color.Red;


                    }
                    else
                    {
                        rawDetailGrid.Rows[i].Cells["R_INPUT_AMT"].Style.ForeColor = Color.Blue;
                        rawDetailGrid.Rows[i].Cells["R_OUTPUT_AMT"].Style.ForeColor = Color.Blue;
                        rawDetailGrid.Rows[i].Cells["R_STOCK_AMT"].Style.ForeColor = Color.Blue;
                    }
                    
                    
                    //t_input_amt += decimal.Parse(dt.Rows[i]["INPUT_AMT"].ToString());
                    //t_output_amt += decimal.Parse(dt.Rows[i]["OUTPUT_AMT"].ToString());
                    //t_stock_amt += decimal.Parse(dt.Rows[i]["STOCK_AMT"].ToString());
                }
                wConst.mergeCells(rawDetailGrid, 1);
                //rawDetailGrid.Rows.Add();
                //rawDetailGrid.Rows[rawDetailGrid.Rows.Count - 1].Cells[0].Value = "합계";
                //rawDetailGrid.Rows[rawDetailGrid.Rows.Count - 1].Cells["R_INPUT_AMT"].Value = t_input_amt.ToString("#,0.######");
                //rawDetailGrid.Rows[rawDetailGrid.Rows.Count - 1].Cells["R_OUTPUT_AMT"].Value = t_output_amt.ToString("#,0.######");
                //rawDetailGrid.Rows[rawDetailGrid.Rows.Count - 1].Cells["R_STOCK_AMT"].Value = t_stock_amt.ToString("#,0.######");

                //rawDetailGrid.Rows[rawDetailGrid.Rows.Count - 1].Cells[0].Style.ForeColor = Color.CadetBlue;
                //rawDetailGrid.Rows[rawDetailGrid.Rows.Count - 1].Cells["R_INPUT_AMT"].Style.ForeColor = Color.Red;
                //rawDetailGrid.Rows[rawDetailGrid.Rows.Count - 1].Cells["R_OUTPUT_AMT"].Style.ForeColor = Color.Red;
                //rawDetailGrid.Rows[rawDetailGrid.Rows.Count - 1].Cells["R_STOCK_AMT"].Style.ForeColor = Color.Red;
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

        private void rawDetailGrid_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DataGridView dgvTemp = (DataGridView)sender;

                int currentMouseOverRow = dgvTemp.HitTest(e.X, e.Y).RowIndex;
                int currentMouseOverColumn = dgvTemp.HitTest(e.X, e.Y).ColumnIndex;
                if (currentMouseOverRow >= 0)
                {
                    EventHandler eh = new EventHandler(MenuClick);
                    ContextMenu m = new ContextMenu();
                    m.MenuItems.Add(new MenuItem("입고 수량수정", eh));
                    m.MenuItems.Add(new MenuItem("재고 위치수정", eh));
                    dgvTemp.CurrentCell = dgvTemp.Rows[currentMouseOverRow].Cells[currentMouseOverColumn];
                    m.Show(dgvTemp, new Point(e.X, e.Y));
                }
            }
        }

        void MenuClick(object obj, EventArgs ea)
        {
            MenuItem mI = (MenuItem)obj;
            String str = mI.Text;

            if (str == "입고 수량수정")
            {
                if (rawDetailGrid.CurrentCell.RowIndex > -1 && !rawDetailGrid.Rows[rawDetailGrid.CurrentCell.RowIndex].Cells["INPUT_CD"].Value.ToString().Equals("합계")
                    && !rawDetailGrid.Rows[rawDetailGrid.CurrentCell.RowIndex].Cells["INPUT_CD"].Value.ToString().Equals("미입고"))
                {
                    Popup.pop초기재고수정 msg = new Popup.pop초기재고수정();

                    msg.sInputDate = rawDetailGrid.Rows[rawDetailGrid.CurrentCell.RowIndex].Cells["INPUT_DATE"].Value.ToString();
                    msg.sInputCd = rawDetailGrid.Rows[rawDetailGrid.CurrentCell.RowIndex].Cells["INPUT_CD"].Value.ToString();
                    msg.sInputSeq = rawDetailGrid.Rows[rawDetailGrid.CurrentCell.RowIndex].Cells["INPUT_SEQ"].Value.ToString();
                    msg.sInputLabelNm = lbl_raw_nm.Text;
                    msg.sInputProductGubun = "1";

                    msg.ShowDialog();

                    if (msg.returnValue.Equals("1"))
                    {
                        GridList();
                        rawDetailGrid.Rows.Clear();
                    }
                }
            }
            else if (str == "재고 위치수정")
            {
                if (rawDetailGrid.CurrentCell.RowIndex > -1 && !rawDetailGrid.Rows[rawDetailGrid.CurrentCell.RowIndex].Cells["INPUT_CD"].Value.ToString().Equals("합계")
                    && !rawDetailGrid.Rows[rawDetailGrid.CurrentCell.RowIndex].Cells["INPUT_CD"].Value.ToString().Equals("미입고"))
                {
                    Popup.pop재고위치수정 msg = new Popup.pop재고위치수정();
                    msg.sInputDate = rawDetailGrid.Rows[rawDetailGrid.CurrentCell.RowIndex].Cells["INPUT_DATE"].Value.ToString();
                    msg.sInputCd = rawDetailGrid.Rows[rawDetailGrid.CurrentCell.RowIndex].Cells["INPUT_CD"].Value.ToString();
                    msg.sInputSeq = rawDetailGrid.Rows[rawDetailGrid.CurrentCell.RowIndex].Cells["INPUT_SEQ"].Value.ToString();
                    msg.sInputLabelNm = lbl_raw_nm.Text;
                    msg.sInputProductGubun = "1";
                    msg.sInputCurrLoc = rawDetailGrid.Rows[rawDetailGrid.CurrentCell.RowIndex].Cells["STORAGE_NM"].Value.ToString() + " / " + rawDetailGrid.Rows[rawDetailGrid.CurrentCell.RowIndex].Cells["LOC_NM"].Value.ToString();
                    msg.ShowDialog();
                    GridList();
                    rawDetailGrid.Rows.Clear();
                }
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
                    GridList();
                    break;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
            return true;
        }

        private void rawDetailGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (rawDetailGrid.Rows[e.RowIndex].Cells["INPUT_SEQ"].Value != null && !rawDetailGrid.Rows[e.RowIndex].Cells["INPUT_DATE"].Value.ToString().Equals(""))
                {
                    frm원자재입고등록 msg = new frm원자재입고등록();
                    msg.is_open_from_stock_page = true;
                    msg.input_date_from_stock_page = rawDetailGrid.Rows[e.RowIndex].Cells["INPUT_DATE"].Value.ToString();
                    msg.input_cd_from_stock_page = rawDetailGrid.Rows[e.RowIndex].Cells["INPUT_CD"].Value.ToString();
                    msg.ShowDialog();
                }

            }
        }


        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }



        private void rawStockGrid_VisibleChanged(object sender, EventArgs e)
        {
            ComInfo.gridHeaderSet((DataGridView)sender);
        }


    }
}
