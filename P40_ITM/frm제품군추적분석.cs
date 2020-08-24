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
using System.Runtime.InteropServices;


namespace MES.P40_ITM
{
    public partial class frm제품군추적분석 : Form
    {
        public frm제품군추적분석()
        {
            InitializeComponent();
        }
        [DllImport("user32.dll")]
        private static extern int RegisterHotKey(int hwnd, int id, int fsModifiers, int vk);

        [DllImport("user32.dll")]
        private static extern int UnregisterHotKey(int p1, int p2);



        private void frm제품군추적분석_Load(object sender, EventArgs e)
        {
            lbl_title.Tag = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[0] + "$" + wnDm.fn_TitleName(this.Name.ToString()).Split('$')[1]; lbl_title.Text = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[2];
            RegisterHotKey((int)this.Handle, 0, 0x0, (int)Keys.F2); 
        }

        private void frm제품군추적분석_FormClosed(object sender, FormClosedEventArgs e)
        {
            UnregisterHotKey((int)this.Handle, 0);
        }


        #region button
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSrch_Click(object sender, EventArgs e)
        {
            lotLogic();
        }
        #endregion


        private void lotLogic()
        {
            DataTable dt = new DataTable();
            wnDm wDm = new wnDm();

            StringBuilder sb = new StringBuilder();
            if (txt_lot_bar.Text.ToString().Equals("") || txt_lot_bar.Text.Length < 14)
            {
                MessageBox.Show("바코드를 입력하시기 바랍니다.");
                return;
            }

            string lot_no = txt_lot_bar.Text.ToString().Substring(0, 10);
            string sub_no = txt_lot_bar.Text.ToString().Substring(10);
              sb.AppendLine(" and A.LOT_NO = '" + lot_no + "' and A.LOT_SUB = '" +int.Parse(sub_no)+ "' ");
           // sb.AppendLine(" and A.LOT_NO = '" + lot_no + "'  ");
             
            dt = wDm.fn_Work_Flow_Detail(sb.ToString());

            if (dt != null && dt.Rows.Count > 0)
            {
                lbl_lot_no.Text = dt.Rows[0]["LOT_NO"].ToString();

                //LOTNO 공정 목록
                workFlowGrid.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    workFlowGrid.Rows.Add();
                    workFlowGrid.Rows[i].Cells["F_STEP"].Value = dt.Rows[i]["F_STEP"].ToString();
                    workFlowGrid.Rows[i].Cells["FLOW_DATE"].Value = dt.Rows[i]["F_SUB_DATE"].ToString();
                    workFlowGrid.Rows[i].Cells["FLOW_NM"].Value = dt.Rows[i]["FLOW_NM"].ToString();
                    workFlowGrid.Rows[i].Cells["FLOW_CD"].Value = dt.Rows[i]["FLOW_CD"].ToString();
                    workFlowGrid.Rows[i].Cells["F_SUB_AMT"].Value = decimal.Parse(dt.Rows[i]["F_SUB_AMT"].ToString()).ToString("#,0.######");
                    workFlowGrid.Rows[i].Cells["LOSS"].Value = decimal.Parse(dt.Rows[i]["LOSS"].ToString()).ToString("#,0.######");
                    workFlowGrid.Rows[i].Cells["POOR_AMT"].Value = decimal.Parse(dt.Rows[i]["POOR_AMT"].ToString()).ToString("#,0.######");
                }
            } 
            
            dt = wDm.fn_out_item("and B.LOT_NO = '" + lot_no + "'");

            if (dt != null && dt.Rows.Count > 0)
            {
                lbl_lot_no.Text = dt.Rows[0]["LOT_NO"].ToString();

                //LOTNO 공정 목록
                grd_out_item.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    grd_out_item.Rows.Add();
                    grd_out_item.Rows[i].Cells["OUT_DATE"].Value = dt.Rows[i]["OUTPUT_DATE"].ToString();
                    grd_out_item.Rows[i].Cells["O_ITEM_CD"].Value = dt.Rows[i]["ITEM_CD"].ToString();
                    grd_out_item.Rows[i].Cells["O_ITEM_NM"].Value = dt.Rows[i]["ITEM_NM"].ToString();
                    grd_out_item.Rows[i].Cells["O_LOT_NO"].Value = dt.Rows[i]["LOT_NO"].ToString();
                    grd_out_item.Rows[i].Cells["OUT_AMT"].Value = decimal.Parse(dt.Rows[i]["OUTPUT_AMT"].ToString()).ToString("#,0.######");
                    grd_out_item.Rows[i].Cells["O_CUST_CD"].Value = dt.Rows[i]["CUST_CD"].ToString();
                    grd_out_item.Rows[i].Cells["O_CUST_NM"].Value = dt.Rows[i]["CUST_NM"].ToString();
                }
            }

            sb = new StringBuilder();
             sb.AppendLine(" where A.LOT_NO = '" + lbl_lot_no.Text.ToString() +"' ");
           // sb.AppendLine(" where A.LOT_NO = '" + lot_no + "' ");

            dt = wDm.fn_Work_List(sb.ToString());

            if (dt != null && dt.Rows.Count > 0)
            {
                lbl_item_nm.Text = dt.Rows[0]["ITEM_NM"].ToString();
                txt_item_cd.Text = dt.Rows[0]["ITEM_CD"].ToString();
                lbl_spec.Text = dt.Rows[0]["SPEC"].ToString();
                lbl_work_date.Text = dt.Rows[0]["W_INST_DATE"].ToString();
                lbl_plan_num.Text = dt.Rows[0]["PLAN_NUM"].ToString();
                lbl_req_date.Text = dt.Rows[0]["DELIVERY_DATE"].ToString();

                lbl_inst_amt.Text = decimal.Parse(dt.Rows[0]["INST_AMT"].ToString()).ToString("#,0.######");
            }

            dt = wDm.fn_Work_Rm_Detail_List(" and A.LOT_NO = '" + lbl_lot_no.Text.ToString() + "' ");

            lbl_raw_mat_nm.Text = "";
            workRmGrid.Rows.Clear();
            rawOutGrid.Rows.Clear();

            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    workRmGrid.Rows.Add();
                    workRmGrid.Rows[i].Cells[1].Value = (i + 1).ToString();
                    workRmGrid.Rows[i].Cells["WORK_INST_DATE"].Value = dt.Rows[i]["W_INST_DATE"].ToString();
                    workRmGrid.Rows[i].Cells["WORK_INST_CD"].Value = dt.Rows[i]["W_INST_CD"].ToString();
                    workRmGrid.Rows[i].Cells["SEQ"].Value = dt.Rows[i]["SEQ"].ToString();
                    //workRmGrid.Rows[i].Cells["LOT_NO"].Value = dt.Rows[i]["LOT_NO"].ToString();
                    workRmGrid.Rows[i].Cells["RAW_MAT_CD"].Value = dt.Rows[i]["RAW_MAT_CD"].ToString();
                    workRmGrid.Rows[i].Cells["RAW_MAT_NM"].Value = dt.Rows[i]["RAW_MAT_NM"].ToString();
                    workRmGrid.Rows[i].Cells["SPEC"].Value = dt.Rows[i]["SPEC"].ToString();
                    workRmGrid.Rows[i].Cells["INPUT_UNIT"].Value = dt.Rows[i]["INPUT_UNIT"].ToString();
                    workRmGrid.Rows[i].Cells["INPUT_UNIT_NM"].Value = dt.Rows[i]["INPUT_UNIT_NM"].ToString();
                    workRmGrid.Rows[i].Cells["OUTPUT_UNIT"].Value = dt.Rows[i]["OUTPUT_UNIT"].ToString();
                    workRmGrid.Rows[i].Cells["OUTPUT_UNIT_NM"].Value = dt.Rows[i]["OUTPUT_UNIT_NM"].ToString();

                    workRmGrid.Rows[i].Cells["CUST_CD"].Value = dt.Rows[i]["CUST_CD"].ToString();
                    workRmGrid.Rows[i].Cells["CUST_NM"].Value = dt.Rows[i]["CUST_NM"].ToString();

                    decimal inst_amt = decimal.Parse(lbl_inst_amt.Text.ToString());
                    decimal soyo_amt = decimal.Parse(dt.Rows[i]["SOYO_AMT"].ToString());

                    workRmGrid.Rows[i].Cells["TOTAL_SOYO_AMT"].Value = (inst_amt * soyo_amt).ToString("#,0.######");
                }

            }



            dt = wDm.fn_work_raw_output_list(lbl_lot_no.Text.ToString());

            lbl_raw_mat_nm.Text = "";

            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    rawOutGrid.Rows.Add();
                    rawOutGrid.Rows[i].Cells["O_RAW_MAT_NM"].Value = dt.Rows[i]["RAW_MAT_NM"].ToString();
                    rawOutGrid.Rows[i].Cells["O_RAW_MAT_CD"].Value = dt.Rows[i]["RAW_MAT_CD"].ToString();
                    rawOutGrid.Rows[i].Cells["OUTPUT_DATE"].Value = dt.Rows[i]["OUTPUT_DATE"].ToString();
                    rawOutGrid.Rows[i].Cells["OUTPUT_CD"].Value = dt.Rows[i]["OUTPUT_CD"].ToString();
                   // rawOutGrid.Rows[i].Cells["SEQ"].Value = dt.Rows[i]["SEQ"].ToString();
                    rawOutGrid.Rows[i].Cells["OUTPUT_AMT"].Value = dt.Rows[i]["OUTPUT_AMT"].ToString();
                    rawOutGrid.Rows[i].Cells["INPUT_DATE"].Value = dt.Rows[i]["INPUT_DATE"].ToString();
                    rawOutGrid.Rows[i].Cells["INPUT_CD"].Value = dt.Rows[i]["INPUT_CD"].ToString();
                   // rawOutGrid.Rows[i].Cells["SEQ"].Value = dt.Rows[i]["SEQ"].ToString();
                    rawOutGrid.Rows[i].Cells["INPUT_AMT"].Value = dt.Rows[i]["INPUT_AMT"].ToString();
                   // rawOutGrid.Rows[i].Cells["RAW_INPUT_NUM"].Value = dt.Rows[i]["RAW_INPUT_NUM"].ToString();
                    rawOutGrid.Rows[i].Cells["ORDER_DATE"].Value = dt.Rows[i]["ORDER_DATE"].ToString();

                }

            }



            //제품 입고 정보 
            sb = new StringBuilder();
               sb.AppendLine(" and A.LOT_NO = '" + lot_no + "' and A.LOT_SUB = '" + sub_no + "' ");
          //  sb.AppendLine(" and A.LOT_NO = '" + lot_no + "' ");

            dt = wDm.fn_Item_Input_List2(sb.ToString());


            if (dt != null && dt.Rows.Count > 0)
            {

                lbl_input_date.Text = dt.Rows[0]["INPUT_DATE"].ToString();
            }

            //제품 출고 정보 
            sb = new StringBuilder();
                sb.AppendLine(" where B.LOT_NO = '" + lot_no + "' and B.LOT_SUB = '" + sub_no + "' ");
           // sb.AppendLine(" where B.LOT_NO = '" + lot_no + "'  ");

            dt = wDm.fn_Item_Output_Detail_List(sb.ToString());


            if (dt != null && dt.Rows.Count > 0)
            {
                lbl_out_date.Text = dt.Rows[0]["OUTPUT_DATE"].ToString();
                lbl_out_cnt.Text = decimal.Parse(dt.Rows[0]["OUTPUT_AMT"].ToString()).ToString("#,0.######");
                lbl_out_price.Text = decimal.Parse(dt.Rows[0]["PRICE"].ToString()).ToString("#,0.######");
                lbl_total_money.Text = decimal.Parse(dt.Rows[0]["TOTAL_MONEY"].ToString()).ToString("#,0.######");
            }

            txt_lot_bar.Text = "";
        }

        private void workRmGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                DataGridView dgv = (DataGridView)sender;

                lbl_raw_mat_nm.Text = (string)workRmGrid.Rows[e.RowIndex].Cells["RAW_MAT_NM"].Value;

                wnDm wDm = new wnDm();
                DataTable dt = new DataTable();

                StringBuilder sb = new StringBuilder();
                sb.AppendLine(" and A.LOT_NO = '" + lbl_lot_no.Text.ToString() + "' ");
                sb.AppendLine(" and A.RAW_MAT_CD = '" + (string)workRmGrid.Rows[e.RowIndex].Cells["RAW_MAT_CD"].Value + "' ");
                dt = wDm.fn_자재선입선출_List(sb.ToString());

                this.rawOutGrid.RowCount = dt.Rows.Count;
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < rawOutGrid.Rows.Count; i++)
                    {
                        string sDate, sNum, sSeq;
                        string sInputBar;

                        rawOutGrid.Rows[i].Cells["OUT_DATE"].Value = dt.Rows[i]["OUTPUT_DATE"].ToString();
                        rawOutGrid.Rows[i].Cells["OUT_CD"].Value = dt.Rows[i]["OUTPUT_CD"].ToString();
                        rawOutGrid.Rows[i].Cells["입고번호"].Value = dt.Rows[i]["INPUT_CD"].ToString();
                        rawOutGrid.Rows[i].Cells["입고일자"].Value = dt.Rows[i]["INPUT_DATE"].ToString();
                        rawOutGrid.Rows[i].Cells["발주일자"].Value = dt.Rows[i]["ORDER_DATE"].ToString();
                        rawOutGrid.Rows[i].Cells["입고량"].Value = decimal.Parse(dt.Rows[i]["TOTAL_AMT"].ToString()).ToString("#,0");
                        rawOutGrid.Rows[i].Cells["OUT_AMT"].Value = decimal.Parse(dt.Rows[i]["OUT_AMT"].ToString()).ToString("#,0");

                        if (!dt.Rows[i]["INPUT_DATE"].ToString().Equals(""))
                        {
                            sDate = DateTime.Parse("" + dt.Rows[i]["INPUT_DATE"].ToString()).ToString("yyyyMMdd");
                            sNum = "" + dt.Rows[i]["INPUT_CD"].ToString();
                            sSeq = "" + dt.Rows[i]["INPUT_SEQ"].ToString();
                            sInputBar = sDate + sNum + sSeq;
                            rawOutGrid.Rows[i].Cells["INPUT_BAR"].Value = sInputBar;
                        }
                        else rawOutGrid.Rows[i].Cells["INPUT_BAR"].Value = "";
                    }
                }
            }
            catch (Exception ex)
            {
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message+" - "+ex.ToString()); msg.ShowDialog();
                wnLog.writeLog(wnLog.LOG_ERROR, ex.Message + " - " + ex.ToString());
            }
        }


        private void txt_lot_bar_KeyUp(object sender, KeyEventArgs e)
        {
            if (txt_lot_bar.Text.Length > 13)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    return;
                }

                if (e.KeyCode == Keys.Tab)
                {
                    return;
                }

                if (e.KeyCode == Keys.CapsLock) return;
                if (e.KeyCode == Keys.Space) return;
                if (e.KeyCode == Keys.Alt) return;
                if (e.KeyCode == Keys.ControlKey) return;

                lotLogic();
            }
        }

        private void btn출고리스트_Click(object sender, EventArgs e)
        {
            output_list(outputGrid, "");
            tbFOUTControl.Visible = !tbFOUTControl.Visible;

        }

        private void output_list(DataGridView dgv, string condition)
        {
            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = null;
                dt = wDm.납품추적_List(condition);

                if (dt != null && dt.Rows.Count > 0)
                {
                    dgv.RowCount = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {


                        dgv.Rows[i].Cells["제품"].Value = dt.Rows[i]["ITEM_NM"].ToString();
                        dgv.Rows[i].Cells["LOTNO"].Value = dt.Rows[i]["LOT_NO"].ToString();
                        dgv.Rows[i].Cells["납품처"].Value = dt.Rows[i]["CUST_NM"].ToString();
                        dgv.Rows[i].Cells["LOTSUB"].Value = dt.Rows[i]["LOT_SUB"].ToString();
                    }
                }
                else
                {
                    dgv.Rows.Clear();
                }
            }
            catch (Exception e)
            {
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(e.Message+" - "+e.ToString()); msg.ShowDialog();
            }
        }

        private void outputGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           txt_lot_bar.Text = outputGrid.Rows[e.RowIndex].Cells["LOTNO"].Value.ToString() +"000"+ outputGrid.Rows[e.RowIndex].Cells["LOTSUB"].Value.ToString();
           btnSrch.PerformClick();
           tbFOUTControl.Visible = false;

        }

        private void frm제품군추적분석_KeyDown(object sender, KeyEventArgs e)
        {


        }



           // 윈도우프로시저 콜백함수

        protected override void WndProc(ref Message m) 

        {

            base.WndProc(ref m);



            switch(m.Msg )

            {
                case (int)0x312 :
                    switch (m.WParam.ToInt32())
                    {
                        case (int)0x0:
                                output_list(outputGrid, "");
                                tbFOUTControl.Visible = !tbFOUTControl.Visible;
                            break;
                    }
                    break;
            }

        }

        private void conDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            pnl_flow_item.Visible = false;
        }

        private void workFlowGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = null;
                string condition = "where B.F_SUB_DATE = '"+workFlowGrid.Rows[e.RowIndex].Cells["FLOW_DATE"].Value.ToString()+"' and B.FLOW_CD = '"+ workFlowGrid.Rows[e.RowIndex].Cells["FLOW_CD"].Value.ToString()+"' ";
                dt = wDm.flowTracking(condition);

                if (dt != null && dt.Rows.Count > 0)
                {
                    grd_flow_item.RowCount = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        grd_flow_item.Rows[i].Cells["T_FLOW_DATE"].Value = dt.Rows[i]["F_SUB_DATE"].ToString();
                        grd_flow_item.Rows[i].Cells["ITEM_CD"].Value = dt.Rows[i]["ITEM_CD"].ToString();
                        grd_flow_item.Rows[i].Cells["ITEM_NM"].Value = dt.Rows[i]["ITEM_NM"].ToString();
                        grd_flow_item.Rows[i].Cells["T_FLOW_CD"].Value = dt.Rows[i]["FLOW_CD"].ToString();
                        grd_flow_item.Rows[i].Cells["T_FLOW_NM"].Value = dt.Rows[i]["FLOW_NM"].ToString();
                        grd_flow_item.Rows[i].Cells["LOT_NO"].Value = dt.Rows[i]["LOT_NO"].ToString();

                    }
                    pnl_flow_item.Visible = true;
                }
                else
                {
                    grd_flow_item.Rows.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("시스템 오류" + ex.ToString());
            }
        }

        private void grd_flow_item_DoubleClick(object sender, EventArgs e)
        {
            pnl_flow_item.Visible = false;
        }





    }
}
