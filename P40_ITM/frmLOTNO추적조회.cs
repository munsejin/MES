using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MES.CLS;
using System.Diagnostics;

namespace MES.P40_ITM
{
    public partial class frmLOTNO추적조회 : Form
    {       
        private wnGConstant wConst = new wnGConstant();
                
        wnAdo wAdo = new wnAdo();
        public static bool p_IsAuth = true;    // 열람권한
        public static bool p_Isrgstr = true;    //등록/수정 권한

        public static bool p_Isdel = true;    // 삭제 권한
        wnDm wnDm = new wnDm();
        public frmLOTNO추적조회()
        {
            InitializeComponent();
        }

        #region button logic

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSrch_Click(object sender, EventArgs e)
        {
            lot_logic();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            allClear();
        }
        #endregion button logic

        private void lot_logic()
        {
            try
            {
                if (txt_lot_bar.Text.ToString().Equals(""))
                {
                    MessageBox.Show("LOT_NO를 입력하시기 바랍니다.");
                    return;
                }

                DataTable dt = new DataTable();
                wnDm wDm = new wnDm();
                dt = wDm.fn_Lot_Item_Srch_List(txt_lot_bar.Text.ToString());

                if (dt != null && dt.Rows.Count > 0)
                {
                    txt_item_cd.Text = dt.Rows[0]["ITEM_CD"].ToString();
                    txt_item_nm.Text = dt.Rows[0]["ITEM_NM"].ToString();
                    txt_spec.Text = dt.Rows[0]["SPEC"].ToString();
                  // txt_work_date.Text = dt.Rows[0]["W_INST_DATE"].ToString();
                    //txt_inst_amt.Text = (decimal.Parse(dt.Rows[0]["INST_AMT"].ToString())).ToString("#,0");
                    lot_detail();
                }
                else
                {
                    MessageBox.Show("데이터가 없습니다.");
                    return;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("시스템 에러: " + e.Message.ToString());
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(e.Message + " - " + e.ToString());
                msg.ShowDialog();
            }
        }

        private void lot_detail()
        {
            try
            {
                DataTable dt = new DataTable();
                wnDm wDm = new wnDm();
                dt = wDm.fn_Lot_Detail(txt_lot_bar.Text.ToString());

                lotGrid.Rows.Clear();
                if (dt != null && dt.Rows.Count > 0)
                {
                   lotGrid.RowCount = dt.Rows.Count;
                   for (int i = 0; i < dt.Rows.Count; i++) 
                   {
                       lotGrid.Rows[i].Cells["F_SUB_DATE"].Value = dt.Rows[i]["F_SUB_DATE"].ToString();
                       lotGrid.Rows[i].Cells["RAW_MAT_CD"].Value = dt.Rows[i]["RAW_MAT_CD"].ToString();
                       lotGrid.Rows[i].Cells["RAW_MAT_NM"].Value = dt.Rows[i]["RAW_MAT_NM"].ToString();
                       lotGrid.Rows[i].Cells["RAW_SPEC"].Value = dt.Rows[i]["SPEC"].ToString();
                       lotGrid.Rows[i].Cells["TOTAL_AMT"].Value = (decimal.Parse(dt.Rows[i]["TOTAL_AMT"].ToString())).ToString("#,0.######");
                       lotGrid.Rows[i].Cells["W_INST_DATE"].Value = dt.Rows[i]["W_INST_DATE"].ToString();
                       lotGrid.Rows[i].Cells["W_INST_CD"].Value = dt.Rows[i]["W_INST_CD"].ToString();
                       //lotGrid.Rows[i].Cells["FLOW_CD"].Value = dt.Rows[i]["FLOW_CD"].ToString();
                       lotGrid.Rows[i].Cells["FLOW_NM"].Value = dt.Rows[i]["FLOW_NM"].ToString();
                       lotGrid.Rows[i].Cells["F_SUB_AMT"].Value = (decimal.Parse(dt.Rows[i]["F_SUB_AMT"].ToString())).ToString("#,0.######");
                       lotGrid.Rows[i].Cells["LOSS"].Value = dt.Rows[i]["LOSS"].ToString();
                       lotGrid.Rows[i].Cells["POOR_AMT"].Value = (decimal.Parse(dt.Rows[i]["POOR_AMT"].ToString())).ToString("#,0.######");
                       //lotGrid.Rows[i].Cells["LOT_NO"].Value = dt.Rows[i]["LOT_NO"].ToString();
                       //lotGrid.Rows[i].Cells["ITEM_CD"].Value = dt.Rows[i]["ITEM_CD"].ToString();
                       lotGrid.Rows[i].Cells["SALES_CUST_CD"].Value = dt.Rows[i]["SALES_CUST_CD"].ToString();
                       lotGrid.Rows[i].Cells["SALES_CUST_NM"].Value = dt.Rows[i]["SALES_CUST_NM"].ToString();
                       lotGrid.Rows[i].Cells["F_STEP"].Value = dt.Rows[i]["F_STEP"].ToString();
                       lotGrid.Rows[i].Cells["OUTPUT_DATE"].Value = dt.Rows[i]["OUTPUT_DATE"].ToString();
                       lotGrid.Rows[i].Cells["INPUT_DATE"].Value = dt.Rows[i]["INPUT_DATE"].ToString();
                       lotGrid.Rows[i].Cells["PUR_CUST_CD"].Value = dt.Rows[i]["PUR_CUST_CD"].ToString();
                       lotGrid.Rows[i].Cells["PUR_CUST_NM"].Value = dt.Rows[i]["PUR_CUST_NM"].ToString();

                   }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("lot 조회 상세 에러: " + e.Message.ToString());
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(e.Message + " - " + e.ToString());
                msg.ShowDialog();
            }
        }

       

        private void allClear()
        {
            txt_lot_bar.Text = "";
            txt_item_cd.Text = "";
            txt_item_nm.Text = "";
            txt_spec.Text = "";
            lotGrid.Rows.Clear();
        }

        public DataTable LotGrid()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(" select A.LOT_NO from F_WORK_INST A inner join F_WORK_INST_DETAIL B ");
            sb.AppendLine(" on A.W_INST_DATE = B.W_INST_DATE  and A.W_INST_CD = B.W_INST_CD ");
            sb.AppendLine(" inner join F_WORK_FLOW_DETAIL C on A.LOT_NO = C.LOT_NO ");
            sb.AppendLine(" inner join N_RAW_CODE D on B.RAW_MAT_CD = D.RAW_MAT_CD  ");
            sb.AppendLine(" WHERE A.W_INST_DATE >= '" + dtp_date1.Text.ToString().Substring(0, 10) + "' AND A.W_INST_DATE <= '" + dtp_date2.Text.ToString().Substring(0, 10) + "' ");            
            
            sb.AppendLine(" GROUP BY A.LOT_NO  ");
            Debug.WriteLine(sb); 
            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            return wAdo.SqlCommandSelect(sCommand);
        }

            
        private void frmLOTNO추적조회_Load(object sender, EventArgs e)
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
            
            dtp_date1.Text = DateTime.Now.AddDays(-7).ToString();
            dtp_date2.Text = DateTime.Now.ToString();

            DataTable dt = null;
            dt = LotGrid();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dgvlot.Rows.Add();
                    dgvlot.Rows[i].Cells["LOT_NO"].Value = dt.Rows[i]["LOT_NO"].ToString();
                }
            }
            catch
            {

            }
        }


        private void dgvlot_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int nCnt = dgvlot.CurrentCell.RowIndex;

            txt_lot_bar.Text = dgvlot.Rows[nCnt].Cells["LOT_NO"].Value.ToString();

            if (txt_lot_bar.Text.Length == 10)
            {
                lot_logic();
                lot_detail();
            }
        }
                  
    }
}
