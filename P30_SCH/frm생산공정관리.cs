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
using MES.Controls;
using System.Diagnostics;
using MES.P50_QUA;

namespace MES.P30_SCH
{
    /// <summary>
    /// 
    ///  sql 에러 PRIMARY KEY 제약 조건 'PK_F_FLOW_DETAIL'을(를) 위반했습니다. 개체 'dbo.F_WORK_FLOW_DETAIL'에 중복 키를 삽입할 수 없습니다. 
    ///  프라이머리키 추가  seq 컬럼 
    ///  
    /// 
    /// </summary>
    public partial class frm생산공정관리 : Form
    {
        private wnGConstant wConst = new wnGConstant();
        private Rectangle _Retangle;

        private DateTimePicker[] dtp = new DateTimePicker[12];
        private conDataGridView[] dgv = new conDataGridView[12];
        private Panel[] pnl = new Panel[12];
        private Button[] btn = new Button[12];
        private Label[] lbl_flow_cd = new Label[12];
        private Label[] lbl_flow_nm = new Label[12];
        wnDm wnDm = new wnDm();
        public int MaxSeq = 0;
        private Label[] lbl_flow_pr_type = new Label[12];
        private Label[] lbl_flow_seq = new Label[12]; //공정코드 순서 값
        private Label[] lbl_item_iden = new Label[12]; //제품식별표
        private Label[] lbl_flow_check = new Label[12]; //공정검사
        public String complete_YN = "";
        public static bool p_IsAuth = true;    // 열람권한
        public static bool p_Isrgstr = true;    //등록/수정 권한

        public static bool p_Isdel = true;    // 삭제 권한

        int flow_cnt = 0;//제품 BOM에 저장된 공정 갯수 
        private int max_flow_cnt = 12;

        private string 식별표chk = "";

        private Popup.pop원부재료반환 pop = new Popup.pop원부재료반환();

        public frm생산공정관리()
        {
            InitializeComponent();
        }

          private IfrmInterface parentFrm = null;
        string today = DateTime.Today.ToString("yyyy-MM-dd");

        public frm생산공정관리(IfrmInterface pFrm)
        {
            InitializeComponent();

            parentFrm = pFrm;
        }

        private void main_panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm생산공정관리_Load(object sender, EventArgs e)
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

            getsetting();
            gridList();



        }

        private void getsetting()
        {


            lbl_flow_cd[0] = lbl_flow_cd_01;
            lbl_flow_cd[1] = lbl_flow_cd_02;
            lbl_flow_cd[2] = lbl_flow_cd_03;
            lbl_flow_cd[3] = lbl_flow_cd_04;
            lbl_flow_cd[4] = lbl_flow_cd_05;
            lbl_flow_cd[5] = lbl_flow_cd_06;
            lbl_flow_cd[6] = lbl_flow_cd_07;
            lbl_flow_cd[7] = lbl_flow_cd_08;
            lbl_flow_cd[8] = lbl_flow_cd_09;
            lbl_flow_cd[9] = lbl_flow_cd_10;
            lbl_flow_cd[10] = lbl_flow_cd_11;
            lbl_flow_cd[11] = lbl_flow_cd_12;

            lbl_flow_nm[0] = lbl_flow_nm_01;
            lbl_flow_nm[1] = lbl_flow_nm_02;
            lbl_flow_nm[2] = lbl_flow_nm_03;
            lbl_flow_nm[3] = lbl_flow_nm_04;
            lbl_flow_nm[4] = lbl_flow_nm_05;
            lbl_flow_nm[5] = lbl_flow_nm_06;
            lbl_flow_nm[6] = lbl_flow_nm_07;
            lbl_flow_nm[7] = lbl_flow_nm_08;
            lbl_flow_nm[8] = lbl_flow_nm_09;
            lbl_flow_nm[9] = lbl_flow_nm_10;
            lbl_flow_nm[10] = lbl_flow_nm_11;
            lbl_flow_nm[11] = lbl_flow_nm_12;

            pnl[0] = panel_comp_01;
            pnl[1] = panel_comp_02;
            pnl[2] = panel_comp_03;
            pnl[3] = panel_comp_04;
            pnl[4] = panel_comp_05;
            pnl[5] = panel_comp_06;
            pnl[6] = panel_comp_07;
            pnl[7] = panel_comp_08;
            pnl[8] = panel_comp_09;
            pnl[9] = panel_comp_10;
            pnl[10] = panel_comp_11;
            pnl[11] = panel_comp_12;

            dgv[0] = workComp01;
            dgv[1] = workComp02;
            dgv[2] = workComp03;
            dgv[3] = workComp04;
            dgv[4] = workComp05;
            dgv[5] = workComp06;
            dgv[6] = workComp07;
            dgv[7] = workComp08;
            dgv[8] = workComp09;
            dgv[9] = workComp10;
            dgv[10] = workComp11;
            dgv[11] = workComp12;

            btn[0] = btn_comp_01;
            btn[1] = btn_comp_02;
            btn[2] = btn_comp_03;
            btn[3] = btn_comp_04;
            btn[4] = btn_comp_05;
            btn[5] = btn_comp_06;
            btn[6] = btn_comp_07;
            btn[7] = btn_comp_08;
            btn[8] = btn_comp_09;
            btn[9] = btn_comp_10;
            btn[10] = btn_comp_11;
            btn[11] = btn_comp_12;

            for (int i = 0; i < 12; i++)
            {

                dtp[i] = new DateTimePicker();
                dtp[i].Value = DateTime.Now;
                this.dgv[i].Controls.Add(dtp[i]);
                dtp[i].Visible = false;
                dtp[i].Name = "FLOW_DATE" + (i + 1).ToString("00");
                dtp[i].Format = DateTimePickerFormat.Custom;
                dtp[i].TextChanged += new EventHandler(dtp_TextChange);

                dgv[i].CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellClick);
                dgv[i].ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.grid_ColumnWidthChanged);
                dgv[i].Scroll += new System.Windows.Forms.ScrollEventHandler(this.grid_scroll);
                dgv[i].Leave += new EventHandler(this.grid_leave);
                dgv[i].EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.grid_EditingControlShowing);
                dgv[i].RowsAdded += new DataGridViewRowsAddedEventHandler(this.rowadd);

                dgv[i].Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv[i].Columns[0].Width = 30;

                dgv[i].Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv[i].Columns[1].HeaderText = "SEQ";
                dgv[i].Columns[2].Width = 70;
                dgv[i].Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgv[i].Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgv[i].Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv[i].Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgv[i].Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                dgv[i].Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgv[i].Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                dgv[i].Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgv[i].Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            }



        }

        private void gridList()
        {
            workLogic(); //작업지시서 목록 
            flowLogic(); //공정 목록
        }







        #region button logic

        private void btnFlow_Click(object sender, EventArgs e)
        {


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (workComp01.Rows.Count == 0)
            {
                MessageBox.Show("작업을 진행할 제품을 선택하세요.");
                return;
            }

            double AMT_SUM = 0;
            double POOR_SUM = 0;
            double LOSS_SUM = 0;

            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < dgv[i].Rows.Count; j++)
                {

                    dgv[i].Rows[j].Cells[3].Value = dgv[i].Rows[j].Cells[3].Value ?? "0";
                    dgv[i].Rows[j].Cells[4].Value = dgv[i].Rows[j].Cells[4].Value ?? "0";
                    dgv[i].Rows[j].Cells[5].Value = dgv[i].Rows[j].Cells[5].Value ?? "0";

                    if (!(bool)(dgv[i].Rows[j].Cells[0].Value ?? false))
                    {
                        dgv[i].Rows.Remove(dgv[i].Rows[j]);
                        j--;

                    }

                }
            }
            for (int i = 0; i < flow_cnt; i++)
            {
                for (int j = 0; j < dgv[i].Rows.Count; j++)
                {

                    POOR_SUM += double.Parse(dgv[i].Rows[j].Cells[5].Value.ToString());
                    LOSS_SUM += double.Parse(dgv[i].Rows[j].Cells[4].Value.ToString());
                    if (i == flow_cnt - 1)
                    {
                        AMT_SUM += double.Parse(dgv[i].Rows[j].Cells[3].Value.ToString());

                    }

                }



            }

            if (p_Isrgstr) //저장할 권한 true 면 
            {
                if (lbl미완료.Text.ToString() == "미완료")
                {



                    int rsNum = wnDm.insert_Work_Flow2(
                                txt_lot_no.Text.ToString()
                                , txt_item_cd.Text.ToString()
                                , dgv
                                , lbl_flow_cd
                                , lbl_flow_seq
                                , lbl_item_iden
                                , flow_cnt
                                , strCustCD
                                , MaxSeq
                                , txt_BAL_STOCK.Text.ToString().Replace(",", "")
                                , 식별표chk
                                    );
                    if (rsNum == 0)
                    {
                        wnProcCon wDmProc = new wnProcCon();
                        int rsNum2 = wDmProc.prod_item_stock_upd(txt_item_cd.Text.ToString());

                        btnSave.Enabled = false;
                        btnDelete.Enabled = true;



                        MessageBox.Show("성공적으로 등록하였습니다.");

                        if (rsNum2 == -9)
                        {
                            MessageBox.Show("제품재고조정 실패");
                        }

                    }
                    else if (rsNum == 1)
                        MessageBox.Show("저장에 실패하였습니다");
                    else
                        MessageBox.Show("Exception 에러");
                }
                else //진행중
                {


                    int rsNum = wnDm.insert_Work_Flow3(
                                txt_lot_no.Text.ToString()
                                , txt_item_cd.Text.ToString()
                                , dgv
                                , lbl_flow_cd
                                , lbl_flow_seq
                                , lbl_item_iden
                                , flow_cnt
                                , strCustCD
                                , MaxSeq
                                  , txt_BAL_STOCK.Text.ToString().Replace(",", "")
                                  , 식별표chk);

                    if (rsNum == 0)
                    {
                        wnProcCon wDmProc = new wnProcCon();
                        int rsNum2 = wDmProc.prod_item_stock_upd(txt_item_cd.Text.ToString());


                        btnDelete.Enabled = true;



                        MessageBox.Show("성공적으로 등록하였습니다.");

                        if (rsNum2 == -9)
                        {
                            MessageBox.Show("제품재고조정 실패");
                        }

                    }
                    else if (rsNum == 1)
                        MessageBox.Show("저장에 실패하였습니다");
                    else
                        MessageBox.Show("Exception 에러");

                }
            }


            MessageBox.Show("완제품" + AMT_SUM + "개 생성 " + "불량" + POOR_SUM + "개 발생 \n LOSS  " + LOSS_SUM + "개 발생");

            if (AMT_SUM + POOR_SUM + LOSS_SUM == double.Parse(txt_inst_amt.Text.ToString()))
            {
                MessageBox.Show("완제품갯수 불량 갯수 LOSS 갯수 합이 " + txt_inst_amt.Text.ToString() + "입니다. 작업이 끝났습니다.");
                wnDm.공정완료(txt_lot_no.Text.ToString());
                if (Common.p_saupNo.ToString() == "6061660355")
                {
                    if (MessageBox.Show("공정중 원부재료가 남았습니까?", "원부재료", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {


                        pop.lot_no = txt_lot_no.Text.ToString();
                        pop.w_inst_date = txt_work_date.Text.ToString();
                        pop.ShowDialog();

                        //int rsNum = wnDm.insertRmInput(
                        //""//input_date
                        //, "return"// txt_cust_cd
                        //,  ""//input_yn
                        //,  ""//comment
                        //    );

                        //if (rsNum == 0)
                        //{
                        //}

                    }
                }

            }

        }


        /// pop up에서 작업지시서 클릭후 
        /// 공정 그리드에 순서대로 뿌려줌

        private void flow_detail_logic()
        {

            // 클리어 
            for (int i = 0; i < 12; i++)
            {
                dgv[i].Visible = true;
                pnl[i].Visible = true;
                btn[i].Visible = true;
                dgv[i].Rows.Clear();
            }

            DataTable dt = new DataTable();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" where A.ITEM_CD = '" + txt_item_cd.Text.ToString() + "' ");
            sb.AppendLine(" and B.FLOW_INSERT_YN = 'Y' ");
            dt = wnDm.fn_Item_Flow_List(sb.ToString());
            flow_cnt = dt.Rows.Count;  //제품 BOM에 저장된 공정 갯수 

            if (dt.Rows.Count > 0)
            {
                식별표chk = "";

                for (int i = 11; i >= dt.Rows.Count; i--) // 11부터 등록 된 공정 수만큼 빼면서 그리드 버튼 판넬 숨김   ex 5개 - 11부터 ~5까지 숨김 
                {
                    dgv[i].Visible = false;
                    pnl[i].Visible = false;
                    btn[i].Visible = false;
                }

                btn[dt.Rows.Count - 1].Visible = false;
                for (int i = 0; i < dt.Rows.Count; i++)  // 첫번째 공정부터 공정수만큼 그리드에 공정명 공정 코드 부여해줌  ex 5개-  0부터 4그리드까지 
                {
                    lbl_flow_cd[i].Text = dt.Rows[i]["FLOW_CD"].ToString();
                   
                    lbl_flow_nm[i].Text = dt.Rows[i]["FLOW_NM"].ToString();
             
                    lbl_flow_cd[i].Tag = dt.Rows[i]["FLOW_CHK_YN"].ToString(); // 각 공정에 검사하는지 TAG에 넣겠습니다.
                    if (dt.Rows[i]["ITEM_IDEN_YN"] != null && dt.Rows[i]["ITEM_IDEN_YN"].ToString().Equals("Y"))
                    {
                        식별표chk = i.ToString();
                    }


                }
                DataTable flow_seq = new DataTable();
                sb = new StringBuilder();
                sb.AppendLine("and A.LOT_NO = '" + txt_lot_no.Text.ToString() + "' ");
                flow_seq = wnDm.fn_Work_Flow_seq(sb.ToString());

                MaxSeq = int.Parse(flow_seq.Rows[0][0].ToString());

                if (lbl미완료.Text.ToString() == "미완료")  //처음 할 때 
                {
                    dgv[0].Rows.Add();
                    //  dgv[0].Rows[0].Cells[1].Value = "1";
                    dgv[0].Rows[0].Cells[3].Value = txt_inst_amt.Text;
                    dgv[0].Rows[0].Cells[4].Value = 0;
                    dgv[0].Rows[0].Cells[5].Value = 0;
                }
                else if (true)  // 두번 이상 할 때 
                {



                    try  //진행중인 (한번 저장한거 다시 불러오는 ) 예외 처리 
                    {



                        sb = new StringBuilder();
                        sb.AppendLine("and A.LOT_NO = '" + txt_lot_no.Text.ToString() + "' ");



                        DataTable flow_dt = new DataTable();
                        flow_dt = wnDm.fn_Work_Flow_Detail(sb.ToString());
                        //여기서부터 
                        int idx = 0;
                        int rowIdx = 0;

                        if (flow_dt.Rows.Count > 0)
                        {
                            idx = 0;
                            rowIdx = 0;
                            for (int i = 0; i < flow_dt.Rows.Count; i++)
                            {
                                idx = int.Parse(flow_dt.Rows[i]["F_STEP"].ToString()) - 1;
                                rowIdx = int.Parse(flow_dt.Rows[i]["SEQ"].ToString()) - 1;

                                dgv[idx].Rows.Add();


                                //  dgv[idx].Rows[rowIdx].Cells[1].Value = (i + 1);

                                dgv[idx].Rows[rowIdx].Cells[2].Value = flow_dt.Rows[i]["F_SUB_DATE"].ToString();
                                dgv[idx].Rows[rowIdx].Cells[3].Value = (decimal.Parse(flow_dt.Rows[i]["F_SUB_AMT"].ToString())).ToString("#,0.######");
                                dgv[idx].Rows[rowIdx].Cells[4].Value = (decimal.Parse(flow_dt.Rows[i]["LOSS"].ToString())).ToString("#,0.######");

                                dgv[idx].Rows[rowIdx].Cells[5].Value = (decimal.Parse(flow_dt.Rows[i]["POOR_AMT"].ToString())).ToString("#,0.######");


                                if (flow_dt.Rows[i]["INPUT_YN"].ToString() == "Y")
                                {
                                    dgv[idx].Rows[rowIdx].Cells[0].Value = true;

                                }
                                else
                                {
                                    dgv[idx].Rows[rowIdx].Cells[0].Value = false;
                                }

                                /// 공정을 불러오는데 이미 작업한 공정은  7번컬럼에 clear 추가해준다
                                /// 그리고 색깔을 넣어주면서 공정 표기 
                                /// 완료된 공정은 수정불가하게 만듬
                                dgv[idx].Rows[rowIdx].Cells[7].Value = "clear";
                                Debug.WriteLine(idx + "/" + rowIdx + "/" + dgv[idx].Rows[rowIdx].Cells[7].Value.ToString() ?? "미완");

                                dgv[idx].Rows[rowIdx].DefaultCellStyle.BackColor = Color.Red;
                                dgv[idx].Rows[rowIdx].ReadOnly = true;


                                double 투입량 = double.Parse(dgv[idx].Rows[rowIdx].Cells[3].Value.ToString() ?? "0") + double.Parse(dgv[idx].Rows[rowIdx].Cells[4].Value.ToString() ?? "0") + double.Parse(dgv[idx].Rows[rowIdx].Cells[5].Value.ToString() ?? "0");  //4 loss 5 불량


                                if (idx == 0) // 첫번째 공정일때  지시량에서 투입량 을ㅇ 빼야함 
                                {
                                    if (rowIdx == 0)//
                                    {
                                        dgv[idx].Rows[rowIdx].Cells[6].Value = double.Parse(txt_inst_amt.Text.ToString() ?? "0") - 투입량;

                                    }
                                    else
                                    {
                                        dgv[idx].Rows[rowIdx - 1].Cells[6].Value = dgv[idx].Rows[rowIdx - 1].Cells[6].Value ?? "0";

                                        dgv[idx].Rows[rowIdx].Cells[6].Value = double.Parse(dgv[idx].Rows[rowIdx - 1].Cells[6].Value.ToString()) - 투입량;
                                    }


                                }
                                else   //두번째 이상부터는 그전 공정 투입량에서 현재 공정 투입량을 빼야함 
                                {
                                    if (rowIdx == 0)//
                                    {

                                        dgv[idx].Rows[rowIdx].Cells[6].Value = double.Parse(dgv[idx - 1].Rows[rowIdx].Cells[3].Value.ToString()) - 투입량;
                                    }
                                    else
                                    {
                                        dgv[idx].Rows[rowIdx - 1].Cells[6].Value = dgv[idx].Rows[rowIdx - 1].Cells[6].Value ?? "0";
                                        dgv[idx].Rows[rowIdx].Cells[6].Value = double.Parse(dgv[idx - 1].Rows[rowIdx].Cells[3].Value.ToString() ?? "0") - 투입량 + double.Parse(dgv[idx].Rows[rowIdx - 1].Cells[6].Value.ToString() ?? "0");

                                    }
                                }










                            }
                            /// 공정이 끝이나고 재고가 쌓였을때
                            /// 첫공정에 미완료값이 있으면
                            /// 첫공정 에 포커스 맞추면서 첫공정 시작
                            /// 첫공정에 rowadd 그리고 첫공정 seq-1 작업 미완료 값을 이번 seq 에 넣어준다 
                            /// ex 공정이 3개인데 3공정까지 끝났다 하지만 1공정에 미완료값(30)이 있으면 
                            /// 첫공정 30이 생겨야한다 

                            if (dgv[0].Rows[dgv[0].Rows.Count - 1].Cells[6].Value.ToString() != "0")
                            {
                                dgv[0].Rows.Add();


                                dgv[0].Rows[dgv[0].Rows.Count - 1].Cells[2].Value = flow_dt.Rows[dgv[0].Rows.Count - 2]["F_SUB_DATE"].ToString();
                                dgv[0].Rows[dgv[0].Rows.Count - 1].Cells[3].Value = dgv[0].Rows[dgv[0].Rows.Count - 2].Cells[6].Value;
                            }



                            ///전에한 공정을 불러오는데 그게 마지막공정을 한게아니라 중간에 그만한거라면 
                            ///그다음공정부터 시작해야하므로 공정더하고 
                            ///전공정의 완료값과 이번 공정에 미완료 값을 더해주면 시작해야할 값이 나온다 
                            ///    (ex 공정이 3개 인데 1공정만했을떄  1공정까지 불러오고 2공정부터 시작  - rows.add   )
                            ///    (1공정 완료한값 과  2공정 미완료값을 더해주면   2공정에 시작할 값이 나옴 )
                            if (idx != flow_cnt - 1)
                            {
                                dgv[idx + 1].Rows.Add();
                                dgv[idx + 1].Rows[dgv[idx + 1].Rows.Count - 1].Cells[2].Value = flow_dt.Rows[dgv[idx + 1].Rows.Count - 2]["F_SUB_DATE"].ToString();
                                dgv[idx + 1].Rows[dgv[idx + 1].Rows.Count - 1].Cells[3].Value = double.Parse(dgv[idx + 1].Rows[dgv[idx + 1].Rows.Count - 2].Cells[6].Value.ToString()) + double.Parse(dgv[idx].Rows[dgv[idx + 1].Rows.Count - 1].Cells[3].Value.ToString());


                            }
                            /// 공정이 끝이나고 재고가 쌓였을때
                            /// 공정에 미완료값이 있으면
                            /// 공정 에 포커스 맞추면서 공정 시작
                            /// 첫공정에 rowadd 그리고 첫공정 seq-1 작업 미완료 값을 이번 seq 에 넣어준다 
                            /// ex 공정이 3개인데 3공정까지 끝났다 하지만 1공정에 미완료값(30)이 있으면 
                            /// 첫공정 30이 생겨야한다 
                            else if (idx == flow_cnt - 1)
                            {
                                for (int i = 0; i < flow_cnt; i++)
                                {

                                    if (dgv[i].Rows[dgv[i].Rows.Count - 1].Cells[6].Value.ToString() != "0")
                                    {
                                        dgv[i].Rows.Add();


                                        dgv[i].Rows[dgv[i].Rows.Count - 1].Cells[2].Value = flow_dt.Rows[dgv[i].Rows.Count - 2]["F_SUB_DATE"].ToString();
                                        dgv[i].Rows[dgv[i].Rows.Count - 1].Cells[3].Value = dgv[i].Rows[dgv[i].Rows.Count - 2].Cells[6].Value;
                                    }

                                }


                            }



                        }

                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                    }
                    //첫번째 공정에 리스트 뿌려주자 
                    if (lbl미완료.Text.ToString() != "진행중")
                    {
                        MessageBox.Show("완료 된 공정입니다.");
                    }

                }

            }
            else
            {
                MessageBox.Show("제품 BOM에 공정이 등록 되어 있지 않습니다. 공정을 등록해주세요");
            }

        }
        String strCustCD = null;
        //작업 지시 코드 가져 올 경우 
        private void btn_work_srch_Click(object sender, EventArgs e)
        {
            Popup.pop작업지시검색 frm = new Popup.pop작업지시검색();

            frm.ShowDialog();

            if (frm.sCode != "")
            {
                txt_lot_no.Text = frm.dgv.Rows[0].Cells["LOT_NO"].Value.ToString();
                txt_item_nm.Text = frm.dgv.Rows[0].Cells["ITEM_NM"].Value.ToString();
                txt_item_cd.Text = frm.dgv.Rows[0].Cells["ITEM_CD"].Value.ToString();
                txt_spec.Text = frm.dgv.Rows[0].Cells["SPEC"].Value.ToString();
                txt_work_date.Text = frm.dgv.Rows[0].Cells["W_INST_DATE"].Value.ToString();
                strCustCD = frm.dgv.Rows[0].Cells["거래처코드"].Value.ToString();
                lbl미완료.Text = frm.dgv.Rows[0].Cells["complete_YN"].Value.ToString();
                txt_inst_amt.Text = (decimal.Parse(frm.dgv.Rows[0].Cells["INST_AMT"].Value.ToString())).ToString("#,0.######");
                txt_char_amt.Text = (decimal.Parse(frm.dgv.Rows[0].Cells["CHARGE_AMT"].Value.ToString())).ToString("#,0.######");
                txt_pack_amt.Text = (decimal.Parse(frm.dgv.Rows[0].Cells["PACK_AMT"].Value.ToString())).ToString("#,0.######");
                txt_BAL_STOCK.Text = (decimal.Parse(frm.dgv.Rows[0].Cells["현재고"].Value.ToString())).ToString("#,0.######");

                flow_detail_logic();
            }
            else
            {
                //txt_lot_no.Text = "";   
            }

            frm.Dispose();
            frm = null;
            btnSave.Enabled = true;

            if (Common.p_saupNo.ToString() == "6061660355" && lbl미완료.Text.Equals("완료"))
            {
                btn_자재반환.Visible = true;
                pop = new Popup.pop원부재료반환();
            }

        }

        private void btn_comp_01_Click(object sender, EventArgs e)
        {
            Button 넘기는버튼 = sender as Button;

            
            btn_logic(0);
        }

        private void btn_comp_02_Click(object sender, EventArgs e)
        {

          
            btn_logic(1);
        }

        private void btn_comp_03_Click(object sender, EventArgs e)
        {
          
            btn_logic(2);
        }

        private void btn_comp_04_Click(object sender, EventArgs e)
        {
           
            btn_logic(3);
        }

        private void btn_comp_05_Click(object sender, EventArgs e)
        {
            
            btn_logic(4);
        }

        private void btn_comp_06_Click(object sender, EventArgs e)
        {
           
            btn_logic(5);
        }

        private void btn_comp_07_Click(object sender, EventArgs e)
        {
           
            btn_logic(6);
        }

        private void btn_comp_08_Click(object sender, EventArgs e)
        {
            
            btn_logic(7);
        }

        private void btn_comp_09_Click(object sender, EventArgs e)
        {
           
            btn_logic(8);
        }

        private void btn_comp_10_Click(object sender, EventArgs e)
        {
          
            btn_logic(9);
        }

        private void btn_comp_11_Click(object sender, EventArgs e)
        {
           
            btn_logic(10);
        }

        private void btn_comp_12_Click(object sender, EventArgs e)
        {
            btn_logic(11);
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            ComInfo comInfo = new ComInfo();
            DialogResult msgOk = comInfo.deleteConfrim("공정등록", txt_lot_no.Text.ToString());

            if (msgOk == DialogResult.No)
            {
                return;
            }

            wnDm wDm = new wnDm();
            int rsNum = wDm.deleteWorkFlow(txt_lot_no.Text.ToString());

            if (rsNum == 0)
            {
                flow_cnt = 0; //해당 공정 카운트 리셋


                btnDelete.Enabled = false;

                txt_lot_no.Text = "";
                txt_item_nm.Text = "";
                txt_item_cd.Text = "";
                txt_spec.Text = "";
                txt_work_date.Text = "";

                txt_inst_amt.Text = "0";
                txt_char_amt.Text = "0";
                txt_pack_amt.Text = "0";

                for (int i = 0; i < flow_cnt; i++)
                {
                    lbl_flow_cd[i].Text = "";
                    lbl_flow_nm[i].Text = "";
                    lbl_flow_pr_type[i].Text = "";
                    lbl_flow_seq[i].Text = "";
                }
                //btn[flow_cnt - 1].Visible = false;

                for (int i = 0; i < max_flow_cnt; i++)
                {
                    dgv[i].Rows.Clear(); //GridView 초기화
                }

                gridList();

                MessageBox.Show("성공적으로 삭제하였습니다.");
            }
        }

        #endregion button logic

        #region data logic

        private void btn_logic(int idx)
        {

            Debug.WriteLine(lbl_flow_cd[idx].Tag.ToString());
            if (lbl_flow_cd[idx].Tag.ToString()=="Y")
	{
        DialogResult DR = CustomMessageBox.Show("검사가 필요한 공정입니다. ", "정지", "검사", "생략", "취소");

   


           if (DR == DialogResult.Yes)
           {
               Debug.WriteLine("검사");
           }
           else
           {


           }
	}


            for (int j = 0; j < dgv[idx].Rows.Count; j++)
            {
                if (!(bool)(dgv[idx].Rows[j].Cells[0].Value ?? false))
                {
                    dgv[idx].Rows.Remove(dgv[idx].Rows[j]);
                    j--;
                }
            }

            //seq 하나씩 다시 수정 오류 날것들 다시수정    : null이면 0 으로 시퀀스 잘들어가는지  
            for (int i = 0; i < dgv[idx].Rows.Count; i++)
            {
                dgv[idx].Rows[i].Cells[1].Value = i + 1;
                dgv[idx].Rows[i].Cells[4].Value = dgv[idx].Rows[i].Cells[4].Value ?? "0";
                dgv[idx].Rows[i].Cells[2].Value = dgv[idx].Rows[i].Cells[2].Value ?? DateTime.Now.ToString().Substring(0, 10);
                dgv[idx].Rows[i].Cells[5].Value = dgv[idx].Rows[i].Cells[5].Value ?? "0";
            }





            if (dgv[idx].Rows.Count - 1 == 0)
            {


                try  // 첫번째 컬럼 체크박스에 체크가 되어 있으면 의 제외 처리 
                {
                    dgv[idx].Rows[dgv[idx].Rows.Count - 1].Cells[0].Value = dgv[idx].Rows[dgv[idx].Rows.Count - 1].Cells[0].Value ?? false;  //체크 안하면 널값이다 널값을 때는 false 로 변경 
                    if ((bool)dgv[idx].Rows[dgv[idx].Rows.Count - 1].Cells[0].Value)  // 첫번째 컬럼 체크박스에 체크가 되어 있으면 
                    {
                        dgv[idx + 1].Rows.Add();
                        dgv[idx + 1].Rows[dgv[idx].Rows.Count - 1].Cells[1].Value = dgv[idx].Rows[dgv[idx].Rows.Count - 1].Cells[1].Value; //시퀀스,
                        dgv[idx + 1].Rows[dgv[idx].Rows.Count - 1].Cells[2].Value = dgv[idx].Rows[dgv[idx].Rows.Count - 1].Cells[2].Value; // 일자 
                        dgv[idx + 1].Rows[dgv[idx].Rows.Count - 1].Cells[3].Value = dgv[idx].Rows[dgv[idx].Rows.Count - 1].Cells[3].Value;  //완료량

                        double 투입량 = double.Parse(dgv[idx].Rows[dgv[idx].Rows.Count - 1].Cells[3].Value.ToString()) + double.Parse(dgv[idx].Rows[dgv[idx].Rows.Count - 1].Cells[4].Value.ToString()) + double.Parse(dgv[idx].Rows[dgv[idx].Rows.Count - 1].Cells[5].Value.ToString());  //4 loss 5 불량
                        dgv[idx + 1].Rows[dgv[idx].Rows.Count - 1].Cells[4].Value = 0;
                        dgv[idx + 1].Rows[dgv[idx].Rows.Count - 1].Cells[5].Value = 0;

                        //하지않은 미투입량을 구하기위함
                        if (idx == 0) // 첫번째 공정일때  지시량에서 투입량 을ㅇ 빼야함 
                        {
                            dgv[idx].Rows[dgv[idx].Rows.Count - 1].Cells[6].Value = double.Parse(txt_inst_amt.Text.ToString()) - 투입량;
                        }
                        else   //두번째 이상부터는 그전 공정 투입량에서 현재 공정 투입량을 빼야함 
                        {
                            dgv[idx].Rows[dgv[idx].Rows.Count - 1].Cells[6].Value = double.Parse(dgv[idx - 1].Rows[dgv[idx].Rows.Count - 1].Cells[3].Value.ToString()) - 투입량;
                        }

                        if (dgv[idx].Rows[dgv[idx].Rows.Count - 1].Cells[6].Value.ToString() != "0")
                        {
                            dgv[idx].Columns[6].Visible = true;
                        }

                    }
                    else
                    {

                    }
                }
                catch (Exception ex)
                {
                }
            }
            else  // 한번 끝나고 다시 공정을 시작할때  and 그 이상 
            {
                dgv[idx].Columns[6].Visible = true;
                try  // 첫번째 컬럼 체크박스에 체크가 되어 있으면 의 제외 처리 
                {
                    for (int i = 0; i < dgv[idx].Rows.Count; i++)
                    {

                    }
                    dgv[idx].Rows[dgv[idx].Rows.Count - 1].Cells[0].Value = dgv[idx].Rows[dgv[idx].Rows.Count - 1].Cells[0].Value ?? false;  //체크 안하면 널값이다 널값을 때는 false 로 변경 
                    if ((bool)dgv[idx].Rows[dgv[idx].Rows.Count - 1].Cells[0].Value)  // 첫번째 컬럼 체크박스에 체크가 되어 있으면 
                    {
                        dgv[idx + 1].Rows.Add();
                        dgv[idx + 1].Rows[dgv[idx].Rows.Count - 1].Cells[1].Value = dgv[idx].Rows[dgv[idx].Rows.Count - 1].Cells[1].Value; //시퀀스,
                        dgv[idx + 1].Rows[dgv[idx].Rows.Count - 1].Cells[2].Value = dgv[idx].Rows[dgv[idx].Rows.Count - 1].Cells[2].Value; // 일자 


                        double 투입량 = double.Parse(dgv[idx].Rows[dgv[idx].Rows.Count - 1].Cells[3].Value.ToString()) + double.Parse(dgv[idx].Rows[dgv[idx].Rows.Count - 1].Cells[4].Value.ToString()) + double.Parse(dgv[idx].Rows[dgv[idx].Rows.Count - 1].Cells[5].Value.ToString());  //4 loss 5 불량
                        dgv[idx + 1].Rows[dgv[idx].Rows.Count - 1].Cells[4].Value = 0;
                        dgv[idx + 1].Rows[dgv[idx].Rows.Count - 1].Cells[5].Value = 0;

                        //하지않은 미투입량을 구하기위함

                        if (idx == 0) // 첫번째 공정일때  지시량에서 투입량 을ㅇ 빼야함 
                        {
                            dgv[idx].Rows[dgv[idx].Rows.Count - 1].Cells[6].Value = double.Parse(dgv[idx].Rows[dgv[idx].Rows.Count - 1 - 1].Cells[6].Value.ToString()) - 투입량;
                            dgv[idx + 1].Rows[dgv[idx].Rows.Count - 1].Cells[3].Value = double.Parse(dgv[idx].Rows[dgv[idx].Rows.Count - 1].Cells[3].Value.ToString()) + double.Parse(dgv[idx + 1].Rows[dgv[idx].Rows.Count - 1 - 1].Cells[6].Value.ToString());
                        }
                        else   //두번째 이상부터는 그전 공정 투입량에서 현재 공정 투입량을 빼야함 
                        {
                            try//두번째 이상부터는 그전 공정 투입량에서 현재 공정 투입량을 빼야함 
                            {
                                dgv[idx].Rows[dgv[idx].Rows.Count - 1].Cells[6].Value = double.Parse(dgv[idx - 1].Rows[dgv[idx].Rows.Count - 1].Cells[3].Value.ToString()) + double.Parse(dgv[idx].Rows[dgv[idx].Rows.Count - 1 - 1].Cells[6].Value.ToString()) - 투입량;
                                dgv[idx + 1].Rows[dgv[idx].Rows.Count - 1].Cells[3].Value = double.Parse(dgv[idx].Rows[dgv[idx].Rows.Count - 1].Cells[3].Value.ToString()) + double.Parse(dgv[idx + 1].Rows[dgv[idx].Rows.Count - 1 - 1].Cells[6].Value.ToString());

                            }
                            catch  //그전 공정 이 현재 공정보다 seq 가 적으면 인덱스 에러가남 그럴때는 그 현재 공정이 첫번째라고 생각한다.
                            {
                                dgv[idx].Rows[dgv[idx].Rows.Count - 1].Cells[6].Value = double.Parse(dgv[idx].Rows[dgv[idx].Rows.Count - 1 - 1].Cells[6].Value.ToString()) - 투입량;
                                dgv[idx + 1].Rows[dgv[idx].Rows.Count - 1].Cells[3].Value = double.Parse(dgv[idx].Rows[dgv[idx].Rows.Count - 1].Cells[3].Value.ToString()) + double.Parse(dgv[idx + 1].Rows[dgv[idx].Rows.Count - 1 - 1].Cells[6].Value.ToString());

                            }
                        }

                        if (dgv[idx].Rows[dgv[idx].Rows.Count - 1].Cells[6].Value.ToString() != "0")
                        {
                            dgv[idx].Columns[6].Visible = true;
                        }

                    }
                    else
                    {

                    }

                    if (dgv[idx].Rows[dgv[idx].Rows.Count - 1].Cells[6].Value.ToString() != "0")
                    {
                        dgv[idx].Rows.Add();
                        dgv[idx].Rows[dgv[idx].Rows.Count - 1].Cells[3].Value = dgv[idx].Rows[dgv[idx].Rows.Count - 1].Cells[6].Value;
                    }
                }
                catch (Exception ex)
                {
                }
            }

        }

        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                conDataGridView grd = (conDataGridView)sender;
                int idx = int.Parse(grd.Name.Substring(grd.Name.Length - 2)) - 1; //그리드뷰 명칭의 끝 가져오기, workComp01 ~ workComp12 까지 지정되어 있음

                switch (grd.Columns[e.ColumnIndex].HeaderText)
                {
                    case "일자":

                        _Retangle = grd.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                        dtp[idx].Size = new Size(_Retangle.Width, _Retangle.Height);
                        dtp[idx].Location = new Point(_Retangle.X, _Retangle.Y);
                        dtp[idx].Visible = true;

                        string flow_time = (string)grd.Rows[e.RowIndex].Cells[2].Value;
                        if (flow_time != "" && flow_time != null)
                        {
                            dtp[idx].Text = (string)grd.Rows[e.RowIndex].Cells[2].Value;
                        }
                        else
                        {
                            dtp[idx].Text = DateTime.Today.ToString("yyyy-MM-dd");
                        }
                        break;

                    default:
                        dtp[idx].Visible = false;
                        break;
                }
            }
        }

        private void grid_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            dtpVisible(sender, false);

        }

        private void grid_scroll(object sender, ScrollEventArgs e)
        {
            dtpVisible(sender, false);
        }

        private void grid_leave(object sender, EventArgs e)
        {
            dtpVisible(sender, false);
        }

        private void dtp_TextChange(object sender, EventArgs e)
        {
            DateTimePicker dtp = (DateTimePicker)sender;
            int idx = int.Parse(dtp.Name.Substring(dtp.Name.Length - 2)) - 1; //그리드뷰 명칭의 끝 가져오기, workComp01 ~ workComp09 까지 지정되어 있음
            //MessageBox.Show(dgv[idx].Text.ToString());
            dgv[idx].CurrentCell.Value = dtp.Text.ToString();

            //grd.CurrentCell.Value = dtp[idx].Text.ToString();
        }

        private void dtpVisible(object sender, bool chk)
        {
            conDataGridView grd = (conDataGridView)sender;
            int idx = int.Parse(grd.Name.Substring(grd.Name.Length - 2)) - 1; //그리드뷰 명칭의 끝 가져오기, workComp01 ~ workComp09 까지 지정되어 있음

            dtp[idx].Visible = chk;
        }

        #endregion data logic

        //숫자만 입력
        private void grid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            conDataGridView grd = (conDataGridView)sender;
            int idx = grd.CurrentCell.ColumnIndex;

            if (idx == 3 || idx == 4 || idx == 6)
            {
                e.Control.KeyPress += new KeyPressEventHandler(txtCheckNumeric_KeyPress);
            }
            else
            {
                e.Control.KeyPress -= new KeyPressEventHandler(txtCheckNumeric_KeyPress);
            }
        }

        private void workLogic()
        {
            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = null;
                dt = wDm.fn_Work_List("INNER JOIN F_WORK_INST E ON A.W_INST_DATE = E.W_INST_DATE AND A.W_INST_CD = E.W_INST_CD WHERE E.RAW_OUT_YN = 'Y' AND ISNULL(C.COMPLETE_YN,'N') = 'N' ");


                if (dt.Rows.Count > 0)
                {
                    dataWorkGrid.RowCount = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dataWorkGrid.Rows[i].Cells[0].Value = dt.Rows[i]["LOT_NO"].ToString();
                        dataWorkGrid.Rows[i].Cells[1].Value = dt.Rows[i]["ITEM_NM"].ToString();
                        dataWorkGrid.Rows[i].Cells[2].Value = dt.Rows[i]["INST_AMT"].ToString();
                        dataWorkGrid.Rows[i].Cells[3].Value = dt.Rows[i]["ITEM_CD"].ToString();
                        dataWorkGrid.Rows[i].Cells[4].Value = dt.Rows[i]["SPEC"].ToString();
                        dataWorkGrid.Rows[i].Cells[5].Value = dt.Rows[i]["W_INST_DATE"].ToString();
                        dataWorkGrid.Rows[i].Cells[6].Value = dt.Rows[i]["W_INST_CD"].ToString();
                        dataWorkGrid.Rows[i].Cells[7].Value = dt.Rows[i]["CHARGE_AMT"].ToString();
                        dataWorkGrid.Rows[i].Cells[8].Value = dt.Rows[i]["PACK_AMT"].ToString();
                        dataWorkGrid.Rows[i].Cells[9].Value = dt.Rows[i]["COMPLETE_YN"].ToString();
                        dataWorkGrid.Rows[i].Cells["CUST_NM"].Value = dt.Rows[i]["CUST_NM"].ToString();
                        dataWorkGrid.Rows[i].Cells["ITEM_NM_SEE"].Value = dt.Rows[i]["ITEM_NM"].ToString();
                    }
                }
                else
                {
                    dataWorkGrid.Rows.Clear();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("error" + e.ToString());
            }
        }

        private void flowLogic()
        {
            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = null;
                dt = wDm.fn_Work_Flow_List("and A.FLOW_DATE >= '" + start_date.Text.ToString() + "' and  A.FLOW_DATE <= '" + end_date.Text.ToString() + "'");

                dataFlowGrid.RowCount = dt.Rows.Count;

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dataFlowGrid.Rows[i].Cells[0].Value = dt.Rows[i]["LOT_NO"].ToString();
                        dataFlowGrid.Rows[i].Cells[1].Value = dt.Rows[i]["ITEM_NM"].ToString();
                        dataFlowGrid.Rows[i].Cells[2].Value = dt.Rows[i]["INST_AMT"].ToString();
                        dataFlowGrid.Rows[i].Cells[3].Value = dt.Rows[i]["ITEM_CD"].ToString();
                        dataFlowGrid.Rows[i].Cells[4].Value = dt.Rows[i]["SPEC"].ToString();
                        dataFlowGrid.Rows[i].Cells[5].Value = dt.Rows[i]["W_INST_DATE"].ToString();
                        dataFlowGrid.Rows[i].Cells[6].Value = dt.Rows[i]["W_INST_CD"].ToString();
                        dataFlowGrid.Rows[i].Cells[7].Value = dt.Rows[i]["CHARGE_AMT"].ToString();
                        dataFlowGrid.Rows[i].Cells[8].Value = dt.Rows[i]["PACK_AMT"].ToString();
                        dataFlowGrid.Rows[i].Cells[10].Value = dt.Rows[i]["COMPLETE_YN"].ToString();
                        dataFlowGrid.Rows[i].Cells[9].Value = dt.Rows[i]["FLOW_DATE"].ToString();
                    }
                }
                else
                {
                    dataWorkGrid.Rows.Clear();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("error" + e.ToString());
            }
        }
        #region 공통 그리드 체크

        #endregion 공통 그리드 체크
        private void txtCheckNumeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComInfo.onlyNum(sender, e);
        }

        private void dataWorkGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView grd = (DataGridView)sender;
            txt_lot_no.Text = grd.Rows[e.RowIndex].Cells[0].Value.ToString();
            txt_item_nm.Text = grd.Rows[e.RowIndex].Cells[1].Value.ToString();
            txt_item_cd.Text = grd.Rows[e.RowIndex].Cells[3].Value.ToString();
            txt_spec.Text = grd.Rows[e.RowIndex].Cells[4].Value.ToString();
            txt_work_date.Text = grd.Rows[e.RowIndex].Cells[5].Value.ToString();

            txt_inst_amt.Text = (decimal.Parse(grd.Rows[e.RowIndex].Cells[2].Value.ToString())).ToString("#,0.######");
            txt_char_amt.Text = (decimal.Parse(grd.Rows[e.RowIndex].Cells[7].Value.ToString())).ToString("#,0.######");
            txt_pack_amt.Text = (decimal.Parse(grd.Rows[e.RowIndex].Cells[8].Value.ToString())).ToString("#,0.######");

            flow_detail_logic(); //작업
            grd.CurrentCell = grd[0, e.RowIndex];
        }

        private void dataFlowGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView grd = (DataGridView)sender;
            txt_lot_no.Text = grd.Rows[e.RowIndex].Cells[0].Value.ToString();
            txt_item_nm.Text = grd.Rows[e.RowIndex].Cells[1].Value.ToString();
            txt_item_cd.Text = grd.Rows[e.RowIndex].Cells[3].Value.ToString();
            txt_spec.Text = grd.Rows[e.RowIndex].Cells[4].Value.ToString();
            txt_work_date.Text = grd.Rows[e.RowIndex].Cells[5].Value.ToString();

            txt_inst_amt.Text = (decimal.Parse(grd.Rows[e.RowIndex].Cells[2].Value.ToString())).ToString("#,0.######");
            txt_char_amt.Text = (decimal.Parse(grd.Rows[e.RowIndex].Cells[7].Value.ToString())).ToString("#,0.######");
            txt_pack_amt.Text = (decimal.Parse(grd.Rows[e.RowIndex].Cells[8].Value.ToString())).ToString("#,0.######");

            flow_detail_logic();
            grd.CurrentCell = grd[0, e.RowIndex];

        }

        private void btnSrch_Click(object sender, EventArgs e)
        {
            flowLogic();
        }


        private void checkboxHeader_CheckedChanged(object sender, EventArgs e)
        {

            CheckBox chk = (CheckBox)sender;
            string str = chk.Name;
            int idx = int.Parse(chk.Name.Substring(chk.Name.Length - 2)) - 1;

            if (dgv[idx].Rows.Count > 0)
            {
                for (int i = 0; i < dgv[idx].RowCount; i++)
                {
                    dgv[idx].Rows[i].Cells[dgv[idx].ColumnCount - 1].Value = chk.Checked;
                }
                dgv[idx].EndEdit();
            }
            else
            {
                MessageBox.Show("데이터가 없습니다.");
            }
        }

        private void subLogic()
        {
            double d_inst_amt = double.Parse(txt_inst_amt.Text.ToString());
            double d_char_amt = double.Parse(txt_char_amt.Text.ToString());

            double rs_div = 0.0; //나누기 결과 값 -> 13(수량)/2(포장수량) = 6(결과 값)
            double rs_remain = 0.0; // 나누기 나머지 값 -> 13(수량)% 6(포장수량) = 1 (나머지 값)

            if (d_char_amt == 0) //장입수량이 0일 경우 
            {
                rs_div = 0;
                rs_remain = d_inst_amt;
            }
            else
            {
                rs_div = d_inst_amt / d_char_amt;
                rs_remain = d_inst_amt % d_char_amt;
            }

            if (rs_remain > 0)
            {
                for (int i = 0; i < rs_div - 1; i++) //나누기 결과 값이 6이면 6번을 돌린다. 
                {
                    dgv[0].Rows.Add();
                    dgv[0].Rows[dgv[0].Rows.Count - 1].Cells[dgv[0].ColumnCount - 1].Value = false; //체크 값 초기화

                    dgv[0].Rows[i].Cells[0].Value = txt_lot_no.Text;
                    dgv[0].Rows[i].Cells[1].Value = (i + 1).ToString();
                    dgv[0].Rows[i].Cells[2].Value = DateTime.Today.ToString("yyyy-MM-dd");
                    dgv[0].Rows[i].Cells[3].Value = d_char_amt.ToString("#,0.######"); //장입 수량
                    dgv[0].Rows[i].Cells[4].Value = "0"; //장입 수량
                    dgv[0].Rows[i].Cells[6].Value = "0"; //장입 수량
                }
                if (rs_remain > 0)
                {
                    dgv[0].Rows.Add();
                    dgv[0].Rows[dgv[0].Rows.Count - 1].Cells[dgv[0].ColumnCount - 1].Value = false;

                    dgv[0].Rows[dgv[0].Rows.Count - 1].Cells[0].Value = txt_lot_no.Text;
                    dgv[0].Rows[dgv[0].Rows.Count - 1].Cells[1].Value = dgv[0].Rows.Count.ToString();
                    dgv[0].Rows[dgv[0].Rows.Count - 1].Cells[2].Value = DateTime.Today.ToString("yyyy-MM-dd");
                    dgv[0].Rows[dgv[0].Rows.Count - 1].Cells[3].Value = rs_remain.ToString("#,0.######"); //나머지 수량
                    dgv[0].Rows[dgv[0].Rows.Count - 1].Cells[4].Value = "0"; //나머지 수량
                    dgv[0].Rows[dgv[0].Rows.Count - 1].Cells[6].Value = "0"; //나머지 수량
                }
                else
                {
                    dgv[0].Rows.Add();
                    dgv[0].Rows[dgv[0].Rows.Count - 1].Cells[dgv[0].ColumnCount - 1].Value = false;

                    dgv[0].Rows[dgv[0].Rows.Count - 1].Cells[0].Value = txt_lot_no.Text;
                    dgv[0].Rows[dgv[0].Rows.Count - 1].Cells[1].Value = dgv[0].Rows.Count.ToString();
                    dgv[0].Rows[dgv[0].Rows.Count - 1].Cells[2].Value = DateTime.Today.ToString("yyyy-MM-dd");
                    dgv[0].Rows[dgv[0].Rows.Count - 1].Cells[3].Value = d_char_amt.ToString("#,0.######"); //장입 수량
                    dgv[0].Rows[dgv[0].Rows.Count - 1].Cells[4].Value = "0"; //나머지 수량
                    dgv[0].Rows[dgv[0].Rows.Count - 1].Cells[6].Value = "0"; //나머지 수량
                }
            }
            else
            {
                if (rs_div > 1)
                {
                    for (int i = 0; i < rs_div; i++) //나누기 결과 값이 6이면 6번을 돌린다. 
                    {
                        dgv[0].Rows.Add();
                        dgv[0].Rows[dgv[0].Rows.Count - 1].Cells[dgv[0].ColumnCount - 1].Value = false; //체크 값 초기화

                        dgv[0].Rows[i].Cells[0].Value = txt_lot_no.Text;
                        dgv[0].Rows[i].Cells[1].Value = (i + 1).ToString();
                        dgv[0].Rows[i].Cells[2].Value = DateTime.Today.ToString("yyyy-MM-dd");
                        dgv[0].Rows[i].Cells[3].Value = d_char_amt.ToString("#,0.######"); //장입 수량
                        dgv[0].Rows[i].Cells[4].Value = "0"; //장입 수량
                        dgv[0].Rows[i].Cells[6].Value = "0"; //장입 수량
                    }
                }
                else
                {
                    dgv[0].Rows.Add();
                    dgv[0].Rows[dgv[0].Rows.Count - 1].Cells[dgv[0].ColumnCount - 1].Value = false;

                    dgv[0].Rows[dgv[0].Rows.Count - 1].Cells[0].Value = txt_lot_no.Text;
                    dgv[0].Rows[dgv[0].Rows.Count - 1].Cells[1].Value = dgv[0].Rows.Count.ToString();
                    dgv[0].Rows[dgv[0].Rows.Count - 1].Cells[2].Value = DateTime.Today.ToString("yyyy-MM-dd");
                    dgv[0].Rows[dgv[0].Rows.Count - 1].Cells[3].Value = d_inst_amt.ToString("#,0.######"); //전체 수량
                    dgv[0].Rows[dgv[0].Rows.Count - 1].Cells[4].Value = "0"; //나머지 수량
                    dgv[0].Rows[dgv[0].Rows.Count - 1].Cells[6].Value = "0"; //나머지 수량
                }
            }
        }

        private void rowadd(object sender, DataGridViewRowsAddedEventArgs e)
        {
            DataGridView sub_dgv = sender as DataGridView;

            for (int i = 0; i < sub_dgv.Rows.Count; i++)
            {
                sub_dgv.Rows[i].Cells[1].Value = (i + 1);

            }
        }

        private void btn작업지시현황_Click(object sender, EventArgs e)
        {
            tbFlowControl.Visible = !tbFlowControl.Visible;
            workLogic();
        }
        private void 자재내역(int idx)
        {
            idx = idx;
            if (txt_lot_no.Text != "")
            {


                StringBuilder sb = new StringBuilder();
                sb.AppendLine("공정명: " + lbl_flow_nm[idx].Text);

                try
                {
                    DataTable dt_자재내역 = wnDm.fn_자재내역(txt_lot_no.Text.ToString());

                    if (idx == 0)
                    {
                        for (int i = 0; i < dt_자재내역.Rows.Count; i++)
                        {
                            sb.AppendLine(
                            " 소요량: " +
                           double.Parse(dt_자재내역.Rows[i]["SOYO_AMT"].ToString()) + " 총소요량: " + double.Parse(dt_자재내역.Rows[i]["SOYO_AMT"].ToString())
                           );



                        }
                    }
                    else
                    {
                        for (int j = 0; j < dgv[idx].Rows.Count; j++)
                        {
                            sb.AppendLine("순번: " + j + 1);
                            double a = double.Parse(
                                dgv[idx].Rows[j].Cells[3].Value.ToString() ?? "0") +
                                double.Parse(dgv[idx].Rows[j].Cells[4].Value.ToString() ?? "0")
                                + double.Parse(dgv[idx].Rows[j].Cells[5].Value.ToString() ?? "0");

                            for (int i = 0; i < dt_자재내역.Rows.Count; i++)
                            {
                                sb.AppendLine(
                               " 자재명: " +
                                dt_자재내역.Rows[i]["RAW_MAT_NM"].ToString() + " 소요량: " +
                               double.Parse(dt_자재내역.Rows[i]["SOYO_AMT"].ToString()) + " 총소요량: " + double.Parse(dt_자재내역.Rows[i]["SOYO_AMT"].ToString()) * a
                               );



                            }
                        }
                    }
                }
                catch
                {

                }

                MessageBox.Show(sb.ToString());
            }
        }
        #region d자재내역이벤트
        private void btn자재내역0_Click(object sender, EventArgs e)
        {
            자재내역(0);

        }
        private void btn자재내역1_Click(object sender, EventArgs e)
        {
            자재내역(1);
        }

        private void btn자재내역2_Click(object sender, EventArgs e)
        {
            자재내역(2);
        }

        private void btn자재내역3_Click(object sender, EventArgs e)
        {
            자재내역(3);

        }

        private void btn자재내역4_Click(object sender, EventArgs e)
        {
            자재내역(4);

        }

        private void btn자재내역5_Click(object sender, EventArgs e)
        {
            자재내역(5);

        }

        private void btn자재내역6_Click(object sender, EventArgs e)
        {
            자재내역(6);

        }

        private void btn자재내역7_Click(object sender, EventArgs e)
        {
            자재내역(7);

        }

        private void btn자재내역8_Click(object sender, EventArgs e)
        {
            자재내역(8);

        }

        private void btn자재내역9_Click(object sender, EventArgs e)
        {
            자재내역(9);

        }

        private void btn자재내역10_Click(object sender, EventArgs e)
        {
            자재내역(10);

        }

        private void btn자재내역11_Click(object sender, EventArgs e)
        {
            자재내역(11);

        }

        private void btn자재내역12_Click(object sender, EventArgs e)
        {
            자재내역(12);

        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            Kiosk작업공정등록 form1 = new Kiosk작업공정등록();
            form1.Show();
        }

        private void btn_자재반환_Click(object sender, EventArgs e)
        {
            try
            {
                pop.chk = 1;
                pop.lot_no = txt_lot_no.Text.ToString();
                pop.w_inst_date = txt_work_date.Text.ToString();
                pop.ShowDialog();
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
            
        }



    }
}
