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
using MES.Popup;

namespace MES.P30_SCH
{
    /// <summary>
    /// 
    ///  sql 에러 PRIMARY KEY 제약 조건 'PK_F_FLOW_DETAIL'을(를) 위반했습니다. 개체 'dbo.F_WORK_FLOW_DETAIL'에 중복 키를 삽입할 수 없습니다. 
    ///  프라이머리키 추가  seq 컬럼 
    ///  
    /// 
    /// </summary>
    public partial class Kiosk작업공정등록 : Form
    {
        int max;
        string results = "";
        wnDm wnDm = new wnDm();

        private conDataGridView[] dgv = new conDataGridView[12];

        private Label[] lbl_flow_cd = new Label[12];
        private Label[] lbl_flow_nm = new Label[12];

        private Button[] btn = new Button[12];

        private Label[] lbl_F = new Label[12];
        public int MaxSeq = 0;

        private wnGConstant wConst = new wnGConstant();

        int flow_cnt = 0;//제품 BOM에 저장된 공정 갯수 
        private int max_flow_cnt = 12;
        private Label[] lbl_flow_seq = new Label[12]; //공정코드 순서 값
        private Label[] lbl_item_iden = new Label[12]; //제품식별표

        public Kiosk작업공정등록()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region 넘버키보드 by 문세진
        private void btn_number_Click(object sender, EventArgs e)
        {
            Button senderTemp = (Button)sender;


        }

        private void btn_enter_Click(object sender, EventArgs e)
        {

            Close();
        }

        #endregion 넘버키보드 by 문세진

        private void lbl_work_inst_Click(object sender, EventArgs e)
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

                list_logic();

                //flow_detail_logic();
            }
            else
            {
                txt_lot_no.Text = "";
            }

            frm.Dispose();
            frm = null;
        }

        private void getsetting()
        {


            lbl_F[0] = F0;
            lbl_F[1] = F1;
            lbl_F[2] = F2;
            lbl_F[3] = F3;
            lbl_F[4] = F4;
            lbl_F[5] = F5;
            lbl_F[6] = F6;
            lbl_F[7] = F7;
            lbl_F[8] = F8;
            lbl_F[9] = F9;
            lbl_F[10] = F10;
            lbl_F[11] = F11;




        }

        #region 공정단계클릭
        string str공정단계 = "";
        private void 공정단계클릭(object sender, EventArgs e)
        {


            workComp.Rows.Clear();
            Label 공정단계 = sender as Label;
            str공정단계 = 공정단계.Tag.ToString();


            try
            {
                DataTable dt_공정정보 = wnDm.fn_Item_Flow_List("where A.ITEM_CD ='" + txt_item_cd.Text + "' and A.SEQ='" + str공정단계 + "'");
                lbl공정명.Text = dt_공정정보.Rows[0]["FLOW_NM"].ToString();

                if (dt_공정정보.Rows[0]["FLOW_CHK_YN"].ToString() == "Y")
                {
                    lbl검사.Text = "검사";
                    lbl검사.Tag = "Y";
                }
                else
                {
                    lbl검사.Text = "미검사";
                    lbl검사.Tag = "N";


                }
                txt공정코드.Text = dt_공정정보.Rows[0]["FLOW_CD"].ToString();
                if (dt_공정정보.Rows[0]["ITEM_IDEN_YN"].ToString() == "Y")
                {
                    lbl식별표.Text = "식별표 발행";
                    lbl식별표.Tag = "Y";
                }
                else
                {
                    lbl식별표.Text = "식별표 미발행";
                    lbl식별표.Tag = "N";


                }

            }
            catch
            {
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("and A.LOT_NO = '" + txt_lot_no.Text.ToString() + "' ");
            sb.AppendLine("and A.F_STEP = '" + 공정단계.Tag.ToString() + "' ");

            try
            {
                DataTable flow_dt = new DataTable();
                flow_dt = wnDm.fn_Work_Flow_Detail(sb.ToString());

                if (flow_dt.Rows.Count > 0)
                {
                    lbl공정명.Text = flow_dt.Rows[0]["FLOW_NM"].ToString();
                    MessageBox.Show("진행중인 공정입니다. 이전 데이터를 가져오겠습니다.");
                    for (int i = 0; i < flow_dt.Rows.Count; i++)
                    {
                        workComp.Rows.Add();
                        workComp.Rows[i].Cells["W_SEQ"].Value = flow_dt.Rows[i]["SEQ"].ToString();
                        workComp.Rows[i].Cells["W_DATE"].Value = flow_dt.Rows[i]["F_SUB_DATE"].ToString();
                        workComp.Rows[i].Cells["W_완료"].Value = Math.Round(Decimal.Parse(flow_dt.Rows[i]["F_SUB_AMT"].ToString()));
                        workComp.Rows[i].Cells["W_불량"].Value = Math.Round(Decimal.Parse(flow_dt.Rows[i]["POOR_AMT"].ToString()));
                        workComp.Rows[i].Cells["W_LOSS"].Value = Math.Round(Decimal.Parse(flow_dt.Rows[i]["LOSS"].ToString()));

                        if (i >= 1)
                        {
                            workComp.Rows[i].Cells["W_미투입량"].Value = double.Parse(workComp.Rows[i - 1].Cells["W_완료"].Value.ToString()) - double.Parse(workComp.Rows[i].Cells["W_완료"].Value.ToString()) - double.Parse(workComp.Rows[i].Cells["W_불량"].Value.ToString()) - double.Parse(workComp.Rows[i].Cells["W_LOSS"].Value.ToString());
                        }
                        else if (i == 0)
                        {
                            workComp.Rows[i].Cells["W_미투입량"].Value = double.Parse(txt_inst_amt.Text.ToString()) - double.Parse(workComp.Rows[i].Cells["W_완료"].Value.ToString()) - double.Parse(workComp.Rows[i].Cells["W_불량"].Value.ToString()) - double.Parse(workComp.Rows[i].Cells["W_LOSS"].Value.ToString());

                        }
                    }
                }
                else
                {

                    MessageBox.Show("공정을 시작하겠습니다..");

                }

                workComp.Rows.Add();



            }
            catch
            {

            }
        }






        #endregion 공정단계클릭

        private void list_logic()
        {
            for (int i = 0; i < 12; i++)
            {
                lbl_F[i].Enabled = true;
                workComp.DataSource = null;

                //dgv[i].Visible = true;
                //pnl[i].Visible = true;
                //btn[i].Visible = true;
                //dgv[i].Rows.Clear();
            }

            DataTable dt = new DataTable();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" where A.ITEM_CD = '" + txt_item_cd.Text.ToString() + "' ");
            sb.AppendLine(" and B.FLOW_INSERT_YN = 'Y' ");
            dt = wnDm.fn_Item_Flow_List(sb.ToString());
            flow_cnt = dt.Rows.Count;  //제품 BOM에 저장된 공정 갯수 

            if (dt.Rows.Count > 0)
            {
                for (int i = 11; i >= dt.Rows.Count; i--) // 11부터 등록 된 공정 수만큼 빼면서 그리드 버튼 판넬 숨김   ex 5개 - 11부터 ~5까지 숨김 
                {
                    //dgv[i].Visible = false;
                    //pnl[i].Visible = false;
                    lbl_F[i].Enabled = false;
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lbl_F[i].Text = i.ToString();
                    lbl_F[i].Text += "-" + dt.Rows[i]["FLOW_NM"].ToString();
                }

                //btn[dt.Rows.Count - 1].Visible = false;
                //for (int i = 0; i < dt.Rows.Count; i++)  // 첫번째 공정부터 공정수만큼 그리드에 공정명 공정 코드 부여해줌  ex 5개-  0부터 4그리드까지 
                //{
                //    lbl_flow_cd[i].Text = dt.Rows[i]["FLOW_CD"].ToString();
                //    lbl_flow_nm[i].Text = dt.Rows[i]["FLOW_NM"].ToString();
                //}
            }

            DataTable flow_seq = new DataTable();
            sb = new StringBuilder();
            sb.AppendLine("and A.LOT_NO = '" + txt_lot_no.Text.ToString() + "' ");
            flow_seq = wnDm.fn_Work_Flow_seq(sb.ToString());

            MaxSeq = int.Parse(flow_seq.Rows[0][0].ToString());

            if (lbl미완료.Text.ToString() == "미완료")  //처음 할 때 
            {
                //workComp.Rows.Add();
                ////  dgv[0].Rows[0].Cells[1].Value = "1";
                //workComp.Rows[0].Cells[3].Value = txt_inst_amt.Text;
                //workComp.Rows[0].Cells[4].Value = 0;
                //workComp.Rows[0].Cells[5].Value = 0;
            }
        }

        private void flow_detail_logic(int Fchk)
        {
            for (int i = 0; i < 12; i++)
            {
                lbl_F[i].BackColor = Color.Blue;
            }


            DataTable dt = new DataTable();
            StringBuilder sb = new StringBuilder();
            //sb.AppendLine(" where A.ITEM_CD = '" + txt_item_cd.Text.ToString() + "' ");
            //sb.AppendLine(" and B.FLOW_INSERT_YN = 'Y' ");
            dt = wnDm.fn_Item_Flow_List(sb.ToString());
            //flow_cnt = dt.Rows.Count;  //제품 BOM에 저장된 공정 갯수 
            lbl_F[Fchk].BackColor = Color.Red;



        }
        String strCustCD = null;

        private void Kiosk작업공정등록_Enter(object sender, EventArgs e)
        {

        }

        private void Kiosk작업공정등록_Load(object sender, EventArgs e)
        {

            getsetting();
        }

        private void lbl_before_Click(object sender, EventArgs e)
        {

        }

        private void lbl_after_Click(object sender, EventArgs e)
        {

        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (workComp.Rows.Count == 0)
            {
                MessageBox.Show("작업을 진행할 제품을 선택하세요.");
                return;
            }

            double AMT_SUM = 0;
            double POOR_SUM = 0;
            double LOSS_SUM = 0;


            for (int j = 0; j < workComp.Rows.Count; j++)
            {

                workComp.Rows[j].Cells[3].Value = workComp.Rows[j].Cells[3].Value ?? "0";
                workComp.Rows[j].Cells[4].Value = workComp.Rows[j].Cells[4].Value ?? "0";
                workComp.Rows[j].Cells[5].Value = workComp.Rows[j].Cells[5].Value ?? "0";

                if (!(bool)(workComp.Rows[j].Cells[0].Value ?? false))
                {
                    workComp.Rows.Remove(workComp.Rows[j]);
                    j--;

                }

            }


            for (int j = 0; j < workComp.Rows.Count; j++)
            {

                POOR_SUM += double.Parse(workComp.Rows[j].Cells[5].Value.ToString());
                LOSS_SUM += double.Parse(workComp.Rows[j].Cells[4].Value.ToString());

                AMT_SUM += double.Parse(workComp.Rows[j].Cells[3].Value.ToString());

            }










            int rsNum = wnDm.insert_Work_Flow3_K(
                txt_lot_no.Text.ToString()
                , txt_item_cd.Text.ToString()
                , txt_lotsub.Text.ToString()
                , str공정단계
                , txt공정코드.Text.ToString()
                , txt투입량.Text.ToString()
                , txt로스.Text.ToString()
                , txt불량.Text.ToString()
                , txt완료량.Text.ToString()
                , workComp
                , lbl검사.Tag.ToString()
                , lbl식별표.Tag.ToString()
                , txt_BAL_STOCK.Text.ToString()


                       );

            if (rsNum == 0)
            {
                wnProcCon wDmProc = new wnProcCon();
                int rsNum2 = wDmProc.prod_item_stock_upd(txt_item_cd.Text.ToString());
                //btnDelete.Enabled = true;
                MessageBox.Show("성공적으로 등록하였습니다.");

                kiosk원자재반환 k_원자재반환 = new kiosk원자재반환();
                /*잔재추가*/
                if (Common.p_saupNo.Equals("6061660355"))
                {
                    if (MessageBox.Show("공정중 원자재가 남았습니까?", "원자재", MessageBoxButtons.YesNo) == DialogResult.Yes) 
                    {
                        k_원자재반환.ShowDialog();
                    }
                }


                if (rsNum2 == -9)
                {
                    MessageBox.Show("제품재고조정 실패");
                }

            }
            else if (rsNum == 1)
                MessageBox.Show("저장에 실패하였습니다");
            else
                MessageBox.Show("Exception 에러");





            if (lbl식별표.Tag == "Y")
            {
                MessageBox.Show("제품이 완성되었습니다. -재고입고-");

                for (int i = 0; i < workComp.Rows.Count; i++)
                {
                    AMT_SUM += double.Parse(workComp.Rows[i].Cells["W_완료"].Value.ToString());
                    POOR_SUM += double.Parse(workComp.Rows[i].Cells["W_완료"].Value.ToString());
                    LOSS_SUM += double.Parse(workComp.Rows[i].Cells["W_완료"].Value.ToString());


                }

                AMT_SUM += double.Parse(txt완료량.Text.ToString());
                POOR_SUM += double.Parse(txt불량.Text.ToString());
                LOSS_SUM += double.Parse(txt로스.Text.ToString());

            }

            if (AMT_SUM + POOR_SUM + LOSS_SUM == double.Parse(txt_inst_amt.Text.ToString()))
            {
                MessageBox.Show("작업이 끝났습니다.");

                wnDm.공정완료(txt_lot_no.Text.ToString());
            }

        }



        //작업 지시 코드 가져 올 경우 


        #region 화상키보드


        private void btn_1_Click(object sender, EventArgs e)
        {

            Button btn = sender as Button;
            focuseText.Text += btn.Text.ToString();
            focuseText.Focus();
        }



        private void btn_ac_Click(object sender, EventArgs e)
        {
            focuseText.Text = "";
            focuseText.Focus();
        }

        #endregion

        private void txt투입량_TextChanged(object sender, EventArgs e)
        {
            //txt완료량.Text = (double)txt투입량.Text.ToString().Replace(",", "") - txt로스.Text.ToString().Replace(",", "") - txt불량.Text.ToString().Replace(",", "");



        }
        conTextNumber focuseText = new conTextNumber();


        private void 텍스트포커스(object sender, EventArgs e)
        {
            focuseText = sender as conTextNumber;
        }

        private void btn_투입_Click(object sender, EventArgs e)
        {
            if (txt투입량.Text != "" & txt로스.Text != "" & txt불량.Text != "" & txt완료량.Text != "")
            {
                workComp.Rows[workComp.Rows.Count - 1].Cells["W_완료"].Value = txt완료량.Text;
                workComp.Rows[workComp.Rows.Count - 1].Cells["W_불량"].Value = txt불량.Text;
                workComp.Rows[workComp.Rows.Count - 1].Cells["W_LOSS"].Value = txt로스.Text;

            }

        }





    }
}
