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

namespace MES.P50_QUA
{
    public partial class frm생산보고서조회 : Form
    {
        public frm생산보고서조회()
        {
            InitializeComponent();
        }
        public static bool p_IsAuth = true;    // 열람권한
        public static bool p_Isrgstr = true;    //등록/수정 권한
        wnDm wnDm = new wnDm();
        public static bool p_Isdel = true;    // 삭제 권한
        private void frm생산보고서조회_Load(object sender, EventArgs e)
        {

            tabControl1.TabPages.RemoveAt(0);//생산보고서 텝페이지 삭제
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
                chk_srch_day.Checked = true;
                cmb_month.Format = DateTimePickerFormat.Custom;
                cmb_month.CustomFormat = "yyyy-MM";
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

        private void ccpChkGrid_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void ccpChkGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void resetSetting()
        {


            cmb_datetime.Text = DateTime.Now.ToString("yyyy-MM-dd");
            cmb_datetime2.Text = DateTime.Now.ToString("yyyy-MM-dd");
            cmb_month.Text = DateTime.Now.ToString("yyyy-MM");

            

            //getHaccpGrid();
        }

        private void inputPlanGrid(string condition, string condition2)
        {
            wnDm wDm = new wnDm();
            DataTable dt = null;
            //"where A.INPUT_DATE = '" + txt_chk_date.Text.ToString() + "' and A.INPUT_CD = '" + txt_input_cd.Text.ToString() + "'  "
            dt = wDm.fn_GroupByPlanList(condition);
            planGridView.Rows.Clear();
            flowGridView.Rows.Clear();


            if (dt != null && dt.Rows.Count > 0)
            {
                
                planGridView.RowCount = dt.Rows.Count;
                for (int i = 0; i < planGridView.Rows.Count; i++)
                {
                    planGridView.Rows[i].Cells["ITEM_CD"].Value = dt.Rows[i]["ITEM_CD"].ToString();
                    planGridView.Rows[i].Cells["ITEM_NM"].Value = dt.Rows[i]["ITEM_NM"].ToString();
                    planGridView.Rows[i].Cells["SPEC"].Value = dt.Rows[i]["SPEC"].ToString();
                    planGridView.Rows[i].Cells["UNIT_CD"].Value = dt.Rows[i]["UNIT_CD"].ToString();
                    planGridView.Rows[i].Cells["UNIT_NM"].Value = dt.Rows[i]["UNIT_NM"].ToString();
                    planGridView.Rows[i].Cells["SUM_AMT"].Value = decimal.Parse(dt.Rows[i]["SUM_AMT"].ToString()).ToString("#,0");
                    

                    
                }
            }


            dt = null;
            //"where A.INPUT_DATE = '" + txt_chk_date.Text.ToString() + "' and A.INPUT_CD = '" + txt_input_cd.Text.ToString() + "'  "
            dt = wDm.fn_GroupByFlowList(condition2);
            flowGridView.Rows.Clear();


            if (dt != null && dt.Rows.Count > 0)
            {
               
                flowGridView.RowCount = dt.Rows.Count;
                for (int i = 0; i < flowGridView.Rows.Count; i++)
                {
                   


                    flowGridView.Rows[i].Cells["F_ITEM_NM"].Value = dt.Rows[i]["ITEM_NM"].ToString();
                    flowGridView.Rows[i].Cells["F_INST_AMT"].Value = decimal.Parse(dt.Rows[i]["TOTAL_INST_AMT"].ToString()).ToString("#,0");
                    flowGridView.Rows[i].Cells["F_SPEC"].Value = dt.Rows[i]["SPEC"].ToString();
                    flowGridView.Rows[i].Cells["F_ITEM_CD"].Value = dt.Rows[i]["ITEM_CD"].ToString();
                    flowGridView.Rows[i].Cells["F_LOSS"].Value = dt.Rows[i]["LOSS"].ToString();
                    flowGridView.Rows[i].Cells["F_POOR_AMT"].Value = decimal.Parse(dt.Rows[i]["POOR_AMT"].ToString()).ToString("#,0");
                    flowGridView.Rows[i].Cells["F_SUM_AMT"].Value = dt.Rows[i]["SUM_AMT"].ToString();



                }
            }
        }

        private void DetailGrid(string condition)
        {
            dgv_detail_grid.Rows.Clear();
            wnDm wDm = new wnDm();
            DataTable dt = null;
            //"where A.INPUT_DATE = '" + txt_chk_date.Text.ToString() + "' and A.INPUT_CD = '" + txt_input_cd.Text.ToString() + "'  "
            dt = wDm.fn_Detail_List(condition);           

            if (dt != null && dt.Rows.Count > 0)
            {

                dgv_detail_grid.RowCount = dt.Rows.Count;
                for (int i = 0; i < dgv_detail_grid.Rows.Count; i++)
                {
                    dgv_detail_grid.Rows[i].Cells["PLAN_DATE"].Value = dt.Rows[i]["PLAN_DATE"].ToString();
                    dgv_detail_grid.Rows[i].Cells["D_UNIT_NM"].Value = dt.Rows[i]["UNIT_NM"].ToString();
                    dgv_detail_grid.Rows[i].Cells["WORK_YN"].Value = dt.Rows[i]["WORK_YN"].ToString();                 

                }
            }
        }

        private void chk_srch_day_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_srch_day.Checked == true)
            {
                chk_srch_month.Checked = false;
            }
        }

        private void chk_srch_month_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_srch_month.Checked == true)
            {
                chk_srch_day.Checked = false;
            }
        }

        private void btn_srch_Click(object sender, EventArgs e)
        {
            string condition = "";
            string condition2 = "";
            if (chk_srch_day.Checked == true)
            {
                condition = "where A.PLAN_DATE >= '" + cmb_datetime.Text.ToString() + "' and A.PLAN_DATE <= '" + cmb_datetime2.Text.ToString() + "'  ";
                condition2 = "   where A.W_INST_DATE >= '" + cmb_datetime.Text.ToString() + "' and A.W_INST_DATE <= '" + cmb_datetime2.Text.ToString() + "'    ";
            }
            else 
            {
                condition = "where A.PLAN_DATE like '" + cmb_month.Text.ToString() + "%'  ";
                condition2 = "where A.W_INST_DATE like '" + cmb_month.Text.ToString() + "%'  ";
                
             
            }
                

            inputPlanGrid(condition, condition2);
        }

        private DataTable 월별수량( )
        {
            wnAdo wAdo = new wnAdo();

            StringBuilder sb = new StringBuilder();

            //==================ㅈ납기지연율==

            //임시테이블  셀프조인할려고 만듬
            sb.AppendLine("   select ROW_NUMBER() OVER(ORDER BY substring(W_INST_DATE,0,8) ) AS ROWNUM  ,substring(W_INST_DATE,0,8) as 월별 ,convert(int,SUM(INST_AMT)) as 총생산량 ");
            sb.AppendLine("   into #월별생산량 ");
            sb.AppendLine("  from F_WORK_INST as A   ");
            sb.AppendLine("   group by substring(W_INST_DATE,0,8) ");
            

            //셀프조인하여 전로우값 을 가져옴 
            sb.AppendLine("     select A.월별,convert(int,isnull(a.총생산량,0)) as 올해총생산량,convert(int,isnull(prev.총생산량,0)) as 전년도총생산량  , case when isnull(prev.총생산량,0)=0 then 0 else    ");
            sb.AppendLine("     (convert(decimal,isnull(a.총생산량,0) - isnull(prev.총생산량,0))) / isnull(prev.총생산량,0)*100  end 율  ");
            sb.AppendLine("    from #월별생산량 as A ");
            sb.AppendLine("   LEFT JOIN #월별생산량 as  prev ON prev.ROWNUM = A.ROWNUM - 1");
           
        



            Debug.WriteLine(sb);
            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

         
            return wAdo.SqlCommandSelect(sCommand);
        
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void planGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                txt_item_cd.Text = planGridView.Rows[e.RowIndex].Cells["ITEM_CD"].Value.ToString();
                string condition = "WHERE A.ITEM_CD = '" + txt_item_cd.Text + "' ";
                DetailGrid(condition);
            }
        }

        private void flowGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                txt_item_cd.Text = flowGridView.Rows[e.RowIndex].Cells["F_ITEM_CD"].Value.ToString();
                string condition = "WHERE A.ITEM_CD = '" + txt_item_cd.Text + "' ";
                DetailGrid(condition);
            }
        }

        private void tab2_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgv생산증가율.Rows.Clear();
            DataTable dt = 월별수량();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dgv생산증가율.Rows.Add();
                dgv생산증가율.Rows[i].Cells[0].Value = dt.Rows[i]["월별"].ToString();
                dgv생산증가율.Rows[i].Cells[1].Value = dt.Rows[i]["올해총생산량"].ToString();
                dgv생산증가율.Rows[i].Cells[2].Value = Math.Round(double.Parse(dt.Rows[i]["율"].ToString()),2)+"%";
              
            }


            chart1.DataSource = dt;
            chart1.Series[0].XValueMember = "월별";
            chart1.Series[0].YValueMembers = "올해총생산량";
       
            chart1.DataBind();

        }

        
    }
}
