using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MES.CLS;
using MES.Controls;

namespace MES.P50_QUA
{

    /*<Summary> 
     * 권솔빈 
    * 대양smt : frm검사성적서등록 에서 공정검사 등록한 LOTNO를 
    *  검사종류로  역추적 
     *  F_FLOW_CHK ,F_FLOW_CHK_DETAIL 
    */
    public partial class frm품질추적현황 : Form
    {
        private wnGConstant wConst = new wnGConstant();
        wnAdo wAdo = new wnAdo();
        public frm품질추적현황()
        {
            InitializeComponent();

         
         
        }
        private void frm품질추적현황_Load(object sender, EventArgs e)
        {
               lbl_title.Tag = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[0] + "$" + wnDm.fn_TitleName(this.Name.ToString()).Split('$')[1]; lbl_title.Text = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[2];
            // string sqlQuery = "";
            
           // cmb검사명.ValueMember = "코드";
           // cmb검사명.DisplayMember = "명칭";

           // sqlQuery = "select CHK_NM as 명칭 , CHK_CD as 코드 from N_CHK_CODE order by CHK_ORD ";
           //wConst.ComboBox_Read_ALL(cmb검사명, sqlQuery);
            
            
            startDate.Text = DateTime.Now.AddDays(-7).ToString();
            prod_list();
          
            Bad();
            btn_cust_srch.PerformClick();

        }

        private void prod_list()
        {
            dgv제품.Rows.Clear();

            DataTable dt = 제품별list(startDate.Value.ToString().Substring(0, 10), EndDate.Value.ToString().Substring(0, 10));

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
        }

        private void Bad()
        {
            DataTable dt = 불량율();

            dgvBadList.DataSource = dt;
        }



        private DataTable 제품별list(string strStrat,String strEnd)
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
        private DataTable 불량율()
        {
               
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SELECT X.POOR_NM as 불량,convert(int,ISNULL(Z.불량갯수,'0'))AS 불량갯수,CASE WHEN ISNULL(Z.전체수,'0') = 0 THEN 0 ELSE (ISNULL(Z.불량갯수,'0')/ ISNULL(Z.전체수,'0')) END 불량율 FROM N_POOR_CODE X");
            sb.AppendLine("       LEFT JOIN( ");
            sb.AppendLine("        select SUM(A.POOR_AMT) AS 불량갯수 ,isnull(B.POOR_NM,'알수없음') as POOR_NM ,SUM(A.F_SUB_AMT) AS 전체수 from F_WORK_FLOW_DETAIL A  ");
            sb.AppendLine("        FULL OUTER join N_POOR_CODE B  on A.POOR_CD=B.POOR_CD");
            sb.AppendLine("        RIGHT join N_FLOW_CODE c  on A.FLOW_CD=c.FLOW_CD ");
            sb.AppendLine("        where A.POOR_AMT>0 ");
            sb.AppendLine("        GROUP BY B.POOR_NM ");
            sb.AppendLine("        )Z ON Z.POOR_NM= X.POOR_NM ");


            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        
        }
        private void btn_srch_Click(object sender, EventArgs e)
        {

            prod_list();
            //string condition = "";
            //string condition2 = "";            

            ////if (cmb_year.SelectedIndex == -1)
            ////{
            ////    MessageBox.Show("년도를 선택하세요");
            ////    if (cmb_month.SelectedIndex == -1)
            ////    {
            ////        MessageBox.Show("월을 선택하세요");
            ////    }
            ////}
            ////else
            ////{
            ////    condition = "AND A.PLAN_DATE LIKE '" + cmb_year.SelectedItem + "-' '" + cmb_month.SelectedItem + "-%'  ";
            ////}                   

            //if (txt_cust_srch.Text != null && txt_cust_srch.Text != "")
            //{
            //    condition2 = "AND B.CUST_NM LIKE '%" + txt_cust_srch.Text + "%' ";
            //}          

            //plan_list(condition, condition2);
        }

        private void btn_cust_srch_Click(object sender, EventArgs e)
        {
            //prod_list();
            //Popup.pop거래처검색 frm = new Popup.pop거래처검색();

            //frm.sCustGbn = "1";
            //frm.sCustNm = txt_cust_nm.Text.ToString();
            //frm.ShowDialog();

            //if (frm.sCode != "")
            //{
            //    txt_cust_cd.Text = frm.sCode.Trim();
            //    txt_cust_srch.Text = frm.sName.Trim();
            //    //old_cust_nm = frm.sCode.Trim();

            //    StringBuilder sb = new StringBuilder();
            //    sb.AppendLine(" and D.CUST_CD = '%" + txt_cust_cd.Text.ToString() + "%' ");

            //   // item_out_detail(sb.ToString());
            //}
            //else
            //{
            //    //txt_cust_cd.Text = old_cust_nm;
            //}

            //frm.Dispose();
            //frm = null;

            chk();
          
        }

        private void chk()
        {
            try
            {
                dgvCHK.Rows.Clear();
                DataTable dt2 = 체크리스트(startDate.Value.ToString().Substring(0, 10), EndDate.Value.ToString().Substring(0, 10));
                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    dgvCHK.Rows.Add();
                    dgvCHK.Rows[i].Cells["검사명"].Value = dt2.Rows[i]["CHK_NM"].ToString();
                    dgvCHK.Rows[i].Cells["검사수"].Value = dt2.Rows[i]["불량수"].ToString();
                   
                }
            }
            catch
            {
            }
        }

        private DataTable 체크리스트(String strStrat , String strEnd)
        {
            StringBuilder sb = new StringBuilder();


            sb.AppendLine("  select chk.CHK_NM,SUM(convert(int,CHK_VALUE)) as 불량수 from F_FLOW_CHK_DETAIL as A ");
            sb.AppendLine(" inner join N_CHK_CODE as chk on chk.CHK_CD=a.CHK_CD ");
            sb.AppendLine(" inner join F_FLOW_CHK B on B.LOT_NO =a.LOT_NO ");
            sb.AppendLine("    where  b.F_CHK_DATE>='" + strStrat + "' and  b.F_CHK_DATE<='" + strEnd + "' ");
            sb.AppendLine(" group by CHK_NM ");

            Debug.WriteLine(sb);
            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }


        private void dgv_detail_list_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
                 
        }

        private void btn_move_Click(object sender, EventArgs e)
        {

            cust_list();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cust_list()
        {
            
        }

        private void plan_list(string condition, string condition2 )
        {
           
        }

        private void dgv제품_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                //DataTable dt = fn_Work_Detail_List(dgv제품.Rows[e.RowIndex].Cells["LOT넘버"].Value.ToString());
                //workRmGrid.Rows.Clear();
                //if (dt.Rows.Count > 0)
                //{
                //    for (int i = 0; i < dt.Rows.Count; i++)
                //    {
                //        workRmGrid.Rows.Add();
                //        workRmGrid.Rows[i].Cells["작업일자"].Value = dt.Rows[i]["w_inst_date"].ToString();
                //        workRmGrid.Rows[i].Cells["제품명"].Value = dt.Rows[i]["ITEM_NM"].ToString();
                //        workRmGrid.Rows[i].Cells["원자재명"].Value = dt.Rows[i]["RAW_MAT_NM"].ToString();
                //        workRmGrid.Rows[i].Cells["소요량"].Value = dt.Rows[i]["SOYO_AMT"].ToString().Split('.')[0];
                //        workRmGrid.Rows[i].Cells["총수량"].Value = dt.Rows[i]["TOTAL_AMT"].ToString().Split('.')[0];
                //        workRmGrid.Rows[i].Cells["거래처"].Value = dt.Rows[i]["CUST_NM"].ToString();
                //        workRmGrid.Rows[i].Cells["작업지시자"].Value = dt.Rows[i]["STAFF_NM"].ToString();
                //        workRmGrid.Rows[i].Cells["설비"].Value = dt.Rows[i]["LINE_NM"].ToString();

                //    }
                //}
                //else
                //{

                //}
                this.wConst.mergeCells(this.workRmGrid, 1);
                try
                {
                    dgv공정.Rows.Clear();
                    DataTable dt2 = fn공정(dgv제품.Rows[e.RowIndex].Cells[0].Value.ToString());
                    for (int i = 0; i < dt2.Rows.Count; i++)
                    {
                        dgv공정.Rows.Add();
                        dgv공정.Rows[i].Cells["단계"].Value = dt2.Rows[i]["단계"].ToString();
                        dgv공정.Rows[i].Cells["공정명"].Value = dt2.Rows[i]["공정"].ToString();
                        dgv공정.Rows[i].Cells["불량명"].Value = dt2.Rows[i]["불량명"].ToString();
                        dgv공정.Rows[i].Cells["불량수"].Value = dt2.Rows[i]["불량수"].ToString();
                        dgv공정.Rows[i].Cells["생산량"].Value = dt2.Rows[i]["f_sub_amt"].ToString();
                        if (dt2.Rows[i]["불량명"].ToString() != "정상")
                        {
                            dgv공정.Rows[i].Cells["불량명"].Style.ForeColor = Color.Red;
                        }
                    }
                    //DataTable dt2 = fn_poor(dgv제품.Rows[e.RowIndex].Cells[1].Value.ToString());
                    //txtLotNo.Text = dt2.Rows[0]["LOT_NO"].ToString();
                    //txt일자.Text = dt2.Rows[0]["F_SUB_DATE"].ToString();
                    //conTextBox[] textbox = new conTextBox[dt2.Rows.Count];
                    //conTextBox[] textbox2 = new conTextBox[dt2.Rows.Count];

                    //for (int i = 0; i < dt2.Rows.Count; i++)
                    //{
                    //    textbox[i].Text = dt2.Rows[i]["POOR_NM"].ToString();
                    //    textbox2[i].Text = dt2.Rows[i]["POOR_AMT"].ToString();
                    //    textbox[i].Size = new Size(30, 20);
                    //    textbox2[i].Size = new Size(30, 20);
                    //    textbox[i].Location = new Point(0, 20 * i);
                    //    textbox2[i].Location = new Point(30, 20 * i);
                    //    panel3.Controls.Add(textbox[i]);
                    //    panel3.Controls.Add(textbox2[i]);


                    //}
                }
                catch
                {
                }



            }

            if (e.RowIndex > -1)
            {
                try
                {

                    DataTable dt33 = 품질불량수량(dgv제품.Rows[e.RowIndex].Cells[0].Value.ToString());
                    dataChkGrid.Rows.Clear();
                    for (int i = 0; i < dt33.Rows.Count; i++)
                    {
                        dataChkGrid.Rows.Add();
                        dataChkGrid.Rows[i].Cells["CHK_NM"].Value = dt33.Rows[i]["CHK_NM"].ToString();
                        dataChkGrid.Rows[i].Cells["CHK_ORD"].Value = dt33.Rows[i]["CHK_ORD"].ToString();
                        dataChkGrid.Rows[i].Cells["항목수량"].Value = dt33.Rows[i]["CHK_VALUE"].ToString();
                        dataChkGrid.Rows[i].Cells["항목내용"].Value = dt33.Rows[i]["COMMENT"].ToString(); ;
                        dataChkGrid.Rows[i].Cells["결과"].Value = dt33.Rows[i]["s_code_nm"].ToString();

                    }
                }
                catch
                {
                    Debug.WriteLine(e.ToString());
                }
            }
        }


        private DataTable 상세리스트()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SELECT X.POOR_NM as 불량,convert(int,ISNULL(Z.불량갯수,'0'))AS 불량갯수,CASE WHEN ISNULL(Z.전체수,'0') = 0 THEN 0 ELSE (ISNULL(Z.불량갯수,'0')/ ISNULL(Z.전체수,'0')) END 불량율 FROM N_POOR_CODE X");
            sb.AppendLine("       LEFT JOIN( ");
            sb.AppendLine("        select SUM(A.POOR_AMT) AS 불량갯수 ,isnull(B.POOR_NM,'알수없음') as POOR_NM ,SUM(A.F_SUB_AMT) AS 전체수 from F_WORK_FLOW_DETAIL A  ");
            sb.AppendLine("        FULL OUTER join N_POOR_CODE B  on A.POOR_CD=B.POOR_CD");
            sb.AppendLine("        RIGHT join N_FLOW_CODE c  on A.FLOW_CD=c.FLOW_CD ");
            sb.AppendLine("        where A.POOR_AMT>0 ");
            sb.AppendLine("        GROUP BY B.POOR_NM ");
            sb.AppendLine("        )Z ON Z.POOR_NM= X.POOR_NM ");


            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_Work_Detail_List(string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" select a.LOT_NO,c.RAW_MAT_NM,");
            sb.AppendLine("      a.SOYO_AMT,a.TOTAL_AMT,");
            sb.AppendLine("      isnull(d.ITEM_NM,'알수없음') as ITEM_NM, ");
            sb.AppendLine("      isnull(e.CUST_NM,'알수없음') as CUST_NM,");
            sb.AppendLine("      isnull(b.INST_AMT,0) as INST_AMT, ");
            sb.AppendLine("     isnull(f.STAFF_NM,'알수없음') as STAFF_NM ,");
            sb.AppendLine("      isnull(h.LINE_NM,'알수없음') as LINE_NM,");
            sb.AppendLine("      b.w_inst_date ");
            sb.AppendLine("      from F_WORK_INST_DETAIL a");
            sb.AppendLine("       left join F_WORK_INST as b on b.LOT_NO =a.LOT_NO");
            sb.AppendLine("       left join N_RAW_CODE as c on c.RAW_MAT_CD=a.RAW_MAT_CD");
            sb.AppendLine("      left join N_ITEM_CODE as d on d.ITEM_CD=b.item_CD");
            sb.AppendLine("     left join N_CUST_CODE as e on e.CUST_CD=b.CUST_CD");
            sb.AppendLine("     left join N_STAFF_CODE as f on f.STAFF_CD= b.WORKER_CD");
            sb.AppendLine("      left join N_LINE_CODE as h on h.LINE_CD=b.LINE_CD");
       
            sb.AppendLine(" where a.LOT_NO='" + condition + "'");
            sb.AppendLine(" order by A.W_INST_DATE desc");


            Debug.WriteLine(sb.ToString());

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn공정(string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" select A.F_STEP as 단계, B.FLOW_NM as 공정 ,convert(int, A.F_SUB_AMT) as F_SUB_AMT ,isnull(C.POOR_NM,'정상') as 불량명 ,convert(int,A.POOR_AMT ) as 불량수 from F_WORK_FLOW_DETAIL as A");
            sb.AppendLine("        left join N_FLOW_CODE as B on B.FLOW_CD=A.FLOW_CD ");
            sb.AppendLine("         left join N_POOR_CODE as C on C.POOR_CD=A.POOR_CD");
         
            sb.AppendLine(" where a.LOT_NO='" + condition + "'");
       

            Debug.WriteLine(sb.ToString());

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_poor(string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("   select A.F_SUB_DATE,LOT_NO,b.POOR_NM from F_WORK_FLOW_DETAIL as A");
            sb.AppendLine("        inner join N_POOR_CODE as B on A.POOR_CD=B.POOR_CD");

            sb.AppendLine(" where a.LOT_NO='" + condition + "'");
   


            Debug.WriteLine(sb.ToString());

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }


        private DataTable 품질불량수량(String condition)
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
        String strChkNM = null;
        private void dgvCHK_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dgv상세.Visible = true;
            strChkNM = dgvCHK.Rows[e.RowIndex].Cells["검사명"].Value.ToString();

            DataTable dt = 검사한LOTNO(strChkNM, startDate.Value.ToString().Substring(0, 10), EndDate.Value.ToString().Substring(0, 10));
            dgv상세.Rows.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dgv상세.Rows.Add();
                dgv상세.Rows[i].Cells[0].Value = dt.Rows[i]["LOTNO"].ToString();
                dgv상세.Rows[i].Cells[1].Value = dt.Rows[i]["불량수"].ToString();
            }
       //     dgv상세.Rows.Add(dgvCHK.Rows[e.RowIndex].Cells[0].Value, dgvCHK.Rows[e.RowIndex].Cells[1].Value.ToString());
            


        }


        private DataTable 검사한LOTNO(String condition,String strStrat,String strEnd)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" select a.LOT_NO  as LOTNO, a.CHK_VALUE as 불량수 from F_FLOW_CHK_DETAIL as a");
            sb.AppendLine("     inner join N_CHK_CODE as chk on chk.CHK_CD=a.CHK_CD  ");
            sb.AppendLine("       inner join F_FLOW_CHK B on B.LOT_NO =a.LOT_NO  ");

            sb.AppendLine("    where  b.F_CHK_DATE>='" + strStrat + "' and  b.F_CHK_DATE<='" + strEnd + "' ");
            sb.AppendLine("    and chk.CHK_NM='" + condition + "' and a.CHK_VALUE>0");



            Debug.WriteLine(sb);
            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }

        private void dgv상세_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            검사카드.Visible = true;
            wnDm wDm = new wnDm();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("     and A.LOT_NO = '" + dgv상세.Rows[e.RowIndex].Cells[0].Value.ToString() + "' ");
           
         //   sb.AppendLine("     and B.F_STEP = '3' ");
             DataTable dt = wDm.fn_Flow_Chk_Req_List(sb.ToString());

             if (dt != null && dt.Rows.Count > 0)
             {
                 txt_chk_date.Text = dt.Rows[0]["F_SUB_DATE"].ToString();

                 txt_lot_no.Text = dt.Rows[0]["LOT_NO"].ToString();
                 txt_lot_sub.Text = dt.Rows[0]["LOT_SUB"].ToString();
                 txt_item_cd.Text = dt.Rows[0]["ITEM_CD"].ToString();
                 txt_item_nm.Text = dt.Rows[0]["ITEM_NM"].ToString();
                 txt_spec.Text = dt.Rows[0]["SPEC"].ToString();
                 txt_flow_cd.Text = dt.Rows[0]["FLOW_CD"].ToString();
                 txt_flow_nm.Text = dt.Rows[0]["FLOW_NM"].ToString();

                 txt_item_gubun_nm.Text = dt.Rows[0]["ITEM_GUBUN_NM"].ToString();
                 txt_sub_amt.Text = (decimal.Parse(dt.Rows[0]["F_SUB_AMT"].ToString())).ToString("#,0.######");

                 txt_measure_cnt.Text = (decimal.Parse(dt.Rows[0]["F_SUB_AMT"].ToString())).ToString("#,0.######"); // dt.Rows[0]["MEASURE_CNT"].ToString();
                 //txt_eva_gubun_nm.Text = dt.Rows[0]["EVA_GUBUN_NM"].ToString();
                 txt_check_nm.Text = dt.Rows[0]["CHECK_NM"].ToString();
                 txt_check_yn.Text = dt.Rows[0]["CHECK_YN"].ToString();
                 txt_f_step.Text = dt.Rows[0]["F_STEP"].ToString();
                 txt_exam_test.Text = dt.Rows[0]["EXTERIOR"].ToString();
                 txt_pass.Text = dt.Rows[0]["PASS_YN"].ToString();


                 if (int.Parse(dt.Rows[0]["MAP_SIZE"].ToString()) > 0)
                 {
                     byte[] rs = (byte[])dt.Rows[0]["MAP"]; // byte to string Encoding.UTF8.GetBytes(dt.Rows[0]["MAP"].ToString());
                     MemoryStream ms = new MemoryStream(rs);
                     Image img = Image.FromStream(ms);

                     Image cus_img = ComInfo.pic_resize_logic(pic_exam, img);

                     pic_exam.BackgroundImage = cus_img;
                 }
                 else
                 {
                     pic_exam.BackgroundImage = null;

                 }
                
             }
             else
             {
                 MessageBox.Show("데이터 일시 오류 \n 다시 더블클릭 해주시기 바랍니다. ");
                 return;
             }
        }

        private void btn_FileOpen_Click(object sender, EventArgs e)
        {
            string path = txt_exam_test.Text.ToString();
            if (System.IO.File.Exists(path))
            {
                System.Diagnostics.Process.Start(path);
            }
            else
            {
                MessageBox.Show("문서를 확인해주세요");
            }
        }

        private void frm품질추적현황_Enter(object sender, EventArgs e)
        {

        }

    }
}
