using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MES.CLS;

namespace MES.P70_STA
{

   /*<Summary>
    * 권솔빈
    * 대양SMT: LON별로 검사에서 불량발생한 정보 조회 부탁
    * 대양은 공정검사 만 실행   제품검사그리드 미작동
    */

     
     
    public partial class frmLOTNO별불랑분석 : Form
    {
        Popup.frmPrint readyPrt = new Popup.frmPrint();
        private wnGConstant wConst = new wnGConstant();

        DataTable adoPrt = null;
        wnAdo wAdo = new wnAdo();
        public Popup.frmPrint frmPrt;

        public string strDay1 = "";
        public string strDay2 = "";
        public string strDate = "";
        public string strDDate = "";
        public string strDay = "";
        public string strCondition = "";

        public frmLOTNO별불랑분석()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            
            //GridList();
            prod_list(null);
        }
        private void prod_list(String strLotno)
        {
            dgv제품.Rows.Clear();

            DataTable dt = 제품별list(dateTimePicker2.Value.ToString().Substring(0, 10), dateTimePicker3.Value.ToString().Substring(0, 10), strLotno);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dgv제품.Rows.Add();
                dgv제품.Rows[i].Cells["cLOT_NO"].Value = dt.Rows[i]["LOT넘버"].ToString();
                dgv제품.Rows[i].Cells["c일자"].Value = dt.Rows[i]["일자"].ToString();
                dgv제품.Rows[i].Cells["c검사명"].Value = dt.Rows[i]["검사명"].ToString();
                dgv제품.Rows[i].Cells["c제품명"].Value = dt.Rows[i]["제품명"].ToString();
                dgv제품.Rows[i].Cells["c규격"].Value = dt.Rows[i]["규격"].ToString();
                dgv제품.Rows[i].Cells["c수량"].Value = (decimal.Parse(dt.Rows[i]["수량"].ToString())).ToString("#,0.######");
                dgv제품.Rows[i].Cells["c거래처"].Value = dt.Rows[i]["CUST_NM"].ToString();
                dgv제품.Rows[i].Cells["c설비명"].Value = dt.Rows[i]["LINE_NM"].ToString();
                dgv제품.Rows[i].Cells["c불량수"].Value = dt.Rows[i]["불량수"].ToString();

            }
            dgv제품.Focus();
        }




        private DataTable 제품별list(string strStrat, String strEnd, String strLotno)
        {

            StringBuilder sb = new StringBuilder();
            //sb.AppendLine("select cv.ITEM_NM as 제품명 ,cv.SPEC as 규격 ,isnull(z.F_SUB_AMT,0) 총수량 ,isnull(z.POOR_AMT,0) 불량수 ,CASE WHEN ISNULL(Z.F_SUB_AMT,'0') = 0 THEN 0 ELSE (ISNULL(Z.POOR_AMT,'0')/ ISNULL(Z.F_SUB_AMT,'0')) END 불량율,ISNULL(z.loss,0) as LOSS량,CASE WHEN ISNULL(Z.F_SUB_AMT,'0') = 0 THEN 0 ELSE (ISNULL(Z.loss,'0')/ ISNULL(Z.F_SUB_AMT,'0')) END LOSS율 from N_ITEM_CODE cv left join (");
            //sb.AppendLine("      SELECT b.ITEM_NM,max(b.SPEC) as spec ,SUM(LOSS) as loss,sum(F_SUB_AMT) F_SUB_AMT ,SUM(POOR_AMT)  as POOR_AMT FROM F_WORK_FLOW_DETAIL  A  ");
            //sb.AppendLine("       left join N_ITEM_CODE b on b.ITEM_CD=A.ITEM_CD ");
            //sb.AppendLine("      group by b.ITEM_NM");
            //sb.AppendLine("       )z on z.ITEM_NM= cv.ITEM_NM ");
            //sb.AppendLine("       where loss>0 or POOR_AMT>0 ");


            sb.AppendLine("      select a.LOT_NO  as LOT넘버 ,a.F_CHK_DATE as 일자 ,b.FLOW_NM as 검사명,C.ITEM_NM as 제품명,C.SPEC as 규격,a.MEASURE_CNT as 수량 ,c.CUST_CD,D.CUST_NM ,ISNULL(E.LINE_NM,'미지정')  AS LINE_NM ,z.불량수 from F_FLOW_CHK as a");
            sb.AppendLine("     inner join N_FLOW_CODE  as B on B.FLOW_CD =a.FLOW_CD  ");
            sb.AppendLine("     inner join N_ITEM_CODE as C on C.ITEM_CD=a.ITEM_CD ");
            sb.AppendLine("    	lefT JOIN N_CUST_CODE AS d ON D.CUST_CD=C.CUST_CD");
            sb.AppendLine("    left JOIN N_LINE_CODE AS E ON E.LINE_CD=C.LINE_CD ");
            sb.AppendLine("   left join (select LOT_NO,SUM(convert(int,CHK_VALUE)) as 불량수 from F_FLOW_CHK_DETAIL group by LOT_NO) z  on  z.LOT_NO=a.LOT_NO ");
            sb.AppendLine("    where  a.F_CHK_DATE>='" + strStrat + "' and  a.F_CHK_DATE<='" + strEnd + "' ");

            if (strLotno!=null)
            {
               sb.AppendLine( "and a.LOT_NO='"+strLotno+"' ");
            }
            
               


            //sb.AppendLine("       select max (b.FLOW_DATE) as 일자 ,a.LOT_NO, sum(poor_amt) as 불량수 , SUM(Loss) as Loss량 , min(F_SUB_AMT) as 총수량 from F_WORK_FLOW_DETAIL as a");
            //sb.AppendLine("          inner join F_WORK_FLOW B on B.LOT_NO=A.LOT_NO  ");

            //sb.AppendLine("       group by a.LOT_NO ");

            //sb.AppendLine("         having SUM(Loss)>0 or sum(poor_amt) >0 ");
            //if (strStrat != null)
            //{
            //    sb.AppendLine("    and  max (B.FLOW_DATE)>='" + strStrat + "' and  max (B.FLOW_DATE)<='" + strEnd + "' ");

            //}
            //sb.AppendLine("       where loss>0 or POOR_AMT>0 ");
            //sb.AppendLine("       where loss>0 or POOR_AMT>0 ");

            Debug.WriteLine(sb);
            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);

        }
        private void GridList()
        {
           
        }
        
        public DataTable fn_LOT분석현황_List(string sDayFrom, string sDayTo, string sItem)
        {
            StringBuilder sb = new StringBuilder();

            //=================== LOT분석현황 ======================

            sb.AppendLine("  SELECT '' AS no, A.ITEM_CD,  MAX(C.ITEM_NM) AS ITEM_NM, MAX(C.SPEC) AS SPEC ");
            sb.AppendLine("  	, SUM(E.F_SUB_AMT) AS F_SUB_AMT, SUM(E.POOR_AMT) AS POOR_AMT, SUM(E.LOSS) AS LOSS  ");
            sb.AppendLine("  FROM F_WORK_INST A   ");
            sb.AppendLine("  LEFT OUTER JOIN N_ITEM_CODE C ON A.ITEM_CD = C.ITEM_CD     ");
            sb.AppendLine("  INNER JOIN  (   ");
            sb.AppendLine("  			SELECT D.LOT_NO, SUM(C.F_SUB_AMT) AS F_SUB_AMT, SUM(C.POOR_AMT) AS POOR_AMT, SUM(C.LOSS) AS LOSS     ");
            sb.AppendLine("  			  FROM F_WORK_FLOW D   ");
            sb.AppendLine("  				LEFT OUTER JOIN F_WORK_FLOW_DETAIL C ON D.LOT_NO = C.LOT_NO   ");
            sb.AppendLine("  			GROUP BY D.LOT_NO)    E ON A.LOT_NO = E.LOT_NO ");
            sb.AppendLine("   WHERE 1=1  ");
            sb.AppendLine("     AND A.COMPLETE_YN = 'Y'   ");
            sb.AppendLine("     AND C.ITEM_NM LIKE '%" + sItem + "%' ");

            sb.AppendLine("     AND A.W_INST_DATE BETWEEN @p_from AND @p_to ");
            sb.AppendLine("  GROUP BY A.ITEM_CD ");
            sb.AppendLine("  ORDER BY A.ITEM_CD ASC ");
            Debug.WriteLine(sb);
            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            sCommand.Parameters.AddWithValue("@p_from", sDayFrom);
            sCommand.Parameters.AddWithValue("@p_to", sDayTo);
            return wAdo.SqlCommandSelect(sCommand);
        }

        private void frmLOTNO별불랑분석_Load(object sender, EventArgs e)
        {
               lbl_title.Tag = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[0] + "$" + wnDm.fn_TitleName(this.Name.ToString()).Split('$')[1]; lbl_title.Text = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[2];

            dateTimePicker2.Text = DateTime.Today.AddMonths(-1).ToString("yyyy-MM-dd");
            dateTimePicker2.Text = DateTime.Today.ToString("yyyy-MM-dd");

            //GridList();
            btnSearch.PerformClick();
        }

        private void clear_Click(object sender, EventArgs e)
        {
           
        }

        private void dataItemGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
           // dgv.Rows[e.RowIndex].Cells[""]
        }


        public DataTable fn_LOT세부내역(string strLOTNO)
        {
            StringBuilder sb = new StringBuilder();

            //=================== LOT분석현황 ======================

            sb.AppendLine("  SELECT '' AS no, A.ITEM_CD,  MAX(C.ITEM_NM) AS ITEM_NM, MAX(C.SPEC) AS SPEC ");
            sb.AppendLine("  SELECT '' AS no, A.ITEM_CD,  MAX(C.ITEM_NM) AS ITEM_NM, MAX(C.SPEC) AS SPEC ");
            sb.AppendLine("  SELECT '' AS no, A.ITEM_CD,  MAX(C.ITEM_NM) AS ITEM_NM, MAX(C.SPEC) AS SPEC ");
            sb.AppendLine("  SELECT '' AS no, A.ITEM_CD,  MAX(C.ITEM_NM) AS ITEM_NM, MAX(C.SPEC) AS SPEC ");
            sb.AppendLine("  SELECT '' AS no, A.ITEM_CD,  MAX(C.ITEM_NM) AS ITEM_NM, MAX(C.SPEC) AS SPEC ");
            sb.AppendLine("  SELECT '' AS no, A.ITEM_CD,  MAX(C.ITEM_NM) AS ITEM_NM, MAX(C.SPEC) AS SPEC ");
            sb.AppendLine("  SELECT '' AS no, A.ITEM_CD,  MAX(C.ITEM_NM) AS ITEM_NM, MAX(C.SPEC) AS SPEC ");
            sb.AppendLine("  SELECT '' AS no, A.ITEM_CD,  MAX(C.ITEM_NM) AS ITEM_NM, MAX(C.SPEC) AS SPEC ");
       
            Debug.WriteLine(sb);
            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

           
            return wAdo.SqlCommandSelect(sCommand);
        }

        private void dgv제품_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                try
                {

                    DataTable dt33 = F_FLOW_CHK_RST(dgv제품.Rows[e.RowIndex].Cells[0].Value.ToString());
                    dataFlowChkGrid.Rows.Clear();
                    for (int i = 0; i < dt33.Rows.Count; i++)
                    {
                        dataFlowChkGrid.Rows.Add();
                        dataFlowChkGrid.Rows[i].Cells["CHK_NM"].Value = dt33.Rows[i]["CHK_NM"].ToString();
                        dataFlowChkGrid.Rows[i].Cells["CHK_ORD"].Value = dt33.Rows[i]["CHK_ORD"].ToString();
                        dataFlowChkGrid.Rows[i].Cells["항목수량"].Value = dt33.Rows[i]["CHK_VALUE"].ToString();
                        dataFlowChkGrid.Rows[i].Cells["항목내용"].Value = dt33.Rows[i]["COMMENT"].ToString(); ;
                        dataFlowChkGrid.Rows[i].Cells["결과"].Value = dt33.Rows[i]["s_code_nm"].ToString();

                    }
                }
                catch
                {
                    Debug.WriteLine(e.ToString());
                }
            }

        }
        private DataTable F_FLOW_CHK_RST(String condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select z.CHK_NM,z.CHK_ORD,s_code_nm,B.CHK_VALUE,A.COMMENT from F_FLOW_CHK_RST as A");
            sb.AppendLine("     inner join  F_FLOW_CHK_DETAIL as B on A.LOT_NO=B.LOT_NO and B.CHK_CD=A.CHK_CD ");
            sb.AppendLine("       inner join N_CHK_CODE as z on z.CHK_CD=A.CHK_CD  ");
            sb.AppendLine("      inner join T_S_CODE  as w on w.s_code=GRADE and  L_CODE='810' ");
            sb.AppendLine("    where A.LOT_NO='" + condition + "'");
            sb.AppendLine("     order by convert(int,z.CHK_ORD) ");


            Debug.WriteLine(sb);
            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }

        private void dateTimePicker3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch.Focus();
            }

            else
            {
                return;
            }
        }

        private void btn_lot_search_Click(object sender, EventArgs e)
        {
            prod_list(txtLotNo.Text);

        }

      

    }
}
