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

namespace MES.P70_STA
{
    public partial class frm제품공정추적 : Form
    {
        private wnGConstant wConst = new wnGConstant();
        wnAdo wAdo = new wnAdo();

        public frm제품공정추적()
        {
            InitializeComponent();
        }
        public static bool p_IsAuth = true;    // 열람권한
        public static bool p_Isrgstr = true;    //등록/수정 권한
        wnDm wnDm = new wnDm();
        public static bool p_Isdel = true;    // 삭제 권한
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm제품공정추적_Load(object sender, EventArgs e)
        {
            lbl_title.Tag = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[0] + "$" + wnDm.fn_TitleName(this.Name.ToString()).Split('$')[1]; lbl_title.Text = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[2];

            init_ComboBox();
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
         
        }

        private void frm제품공정추적_Enter(object sender, EventArgs e)
        {

        }

        private void btn_srchItem_Click(object sender, EventArgs e)
        {

        }

        private void dgvItemFlow1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvItemFlow2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void init_ComboBox()
        {
            ComInfo comInfo = new ComInfo();
            string sqlQuery = "";

            //공정
            cmb_공정명.ValueMember = "코드";
            cmb_공정명.DisplayMember = "명칭";
            sqlQuery = comInfo.queryFlow();
            wConst.ComboBox_Read_NoBlank(cmb_공정명, sqlQuery);        
        }

        private void btnSrch_Click(object sender, EventArgs e)
        {
            Popup.pop_sf_제품검색 frm = new Popup.pop_sf_제품검색();
            wnDm wDm = new wnDm();
            DataTable dt = new DataTable();
            dt = wDm.fn_Item_List("where ITEM_NM like '%" + txt_item_nm.Text.ToString() + "%' ");

            //frm.sUsedYN = sUsedYN;
            frm.dt = dt;
            frm.txtSrch.Text = txt_item_nm.Text.ToString();
            frm.ShowDialog();

            if (frm.sCode != "")
            {                
                txt_item_nm.Text = frm.sName.Trim();             
               
            }       

            lot_detail();
        }

        private void lot_detail()
        {
            try
            {
                DataTable dt = new DataTable();
                wnDm wDm = new wnDm();
               
                dt = wDm.fn_Lot_Detail("where C.FLOW_CD = '" + cmb_공정명.SelectedValue.ToString() + "' AND X.ITEM_NM LIKE '%" + txt_item_nm.Text.ToString() + "%'  ");

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

        private void Bad()
        {
           // DataTable dt = 불량율();

          //  dgvBadList.DataSource = dt;
        }

        private void prod_list()
        {
            //dgv제품.Rows.Clear();

            //DataTable dt = 제품List();

            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
                //dgv제품.Rows.Add();
                //dgv제품.Rows[i].Cells["cLOT_NO"].Value = dt.Rows[i]["LOT넘버"].ToString();
                //dgv제품.Rows[i].Cells["c일자"].Value = dt.Rows[i]["일자"].ToString();
                //dgv제품.Rows[i].Cells["c검사명"].Value = dt.Rows[i]["검사명"].ToString();
                //dgv제품.Rows[i].Cells["c제품명"].Value = dt.Rows[i]["제품명"].ToString();
                //dgv제품.Rows[i].Cells["c규격"].Value = dt.Rows[i]["규격"].ToString();
                //dgv제품.Rows[i].Cells["c수량"].Value = (decimal.Parse(dt.Rows[i]["수량"].ToString())).ToString("#,0.######");
                //dgv제품.Rows[i].Cells["c거래처"].Value = dt.Rows[i]["CUST_NM"].ToString();
                //dgv제품.Rows[i].Cells["c설비명"].Value = dt.Rows[i]["LINE_NM"].ToString();
                //dgv제품.Rows[i].Cells["c불량수"].Value = dt.Rows[i]["불량수"].ToString();

            //}
        }

        

        //private DataTable 불량율()
        //{

        //    StringBuilder sb = new StringBuilder();
        //    sb.AppendLine("SELECT X.POOR_NM as 불량,convert(int,ISNULL(Z.불량갯수,'0'))AS 불량갯수,CASE WHEN ISNULL(Z.전체수,'0') = 0 THEN 0 ELSE (ISNULL(Z.불량갯수,'0')/ ISNULL(Z.전체수,'0')) END 불량율 FROM N_POOR_CODE X");
        //    sb.AppendLine("       LEFT JOIN( ");
        //    sb.AppendLine("        select SUM(A.POOR_AMT) AS 불량갯수 ,isnull(B.POOR_NM,'알수없음') as POOR_NM ,SUM(A.F_SUB_AMT) AS 전체수 from F_WORK_FLOW_DETAIL A  ");
        //    sb.AppendLine("        FULL OUTER join N_POOR_CODE B  on A.POOR_CD=B.POOR_CD");
        //    sb.AppendLine("        RIGHT join N_FLOW_CODE c  on A.FLOW_CD=c.FLOW_CD ");
        //    sb.AppendLine("        where A.POOR_AMT>0 ");
        //    sb.AppendLine("        GROUP BY B.POOR_NM ");
        //    sb.AppendLine("        )Z ON Z.POOR_NM= X.POOR_NM ");


        //    //SqlCommand sCommand = new SqlCommand(sb.ToString());
        //    //if (sCommand.CommandText.Equals(null))
        //    //{
        //    //    wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
        //    //    return null;
        //    //}
        //    //return wAdo.SqlCommandSelect(sCommand);

        //}

        //private DataTable 제품List()
        //{

        //    //StringBuilder sb = new StringBuilder();
            
        //    //sb.AppendLine(" SELECT A.ITEM_CD, A.LOT_NO , B.ITEM_NM ");
        //    //sb.AppendLine(" FROM F_WORK_FLOW A  ");
        //    //sb.AppendLine(" LEFT JOIN N_ITEM_CODE B ON A.ITEM_CD = B.ITEM_CD ");
        //    //sb.AppendLine(" WHERE ITEM_NM = "+  +" ");

            
        //    //sb.AppendLine(" GROUP BY A.ITEM_CD,A.LOT_NO,B.ITEM_NM   ");
            
        //    //Debug.WriteLine(sb);
        //    //SqlCommand sCommand = new SqlCommand(sb.ToString());
        //    //if (sCommand.CommandText.Equals(null))
        //    //{
        //    //    wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
        //    //    return null;
        //    //}
        //    //return wAdo.SqlCommandSelect(sCommand);

        //}
    }
}
