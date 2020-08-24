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
    public partial class frm납기준수율분석 : Form
    {
        private wnGConstant wConst = new wnGConstant();
        wnAdo wAdo = new wnAdo();

        public frm납기준수율분석()
        {
            InitializeComponent();
    

        }

        public static bool p_IsAuth = true;    // 열람권한
        public static bool p_Isrgstr = true;    //등록/수정 권한
        wnDm wnDm = new wnDm();
        public static bool p_Isdel = true;    // 삭제 권한
        private void frm납기준수율분석_Load(object sender, EventArgs e)
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
            chart1.Visible = false;
            try
            {
                DataTable dt = fn_납기지연_List(cmb_year.SelectedValue.ToString());



                dgv납기율.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dgv납기율.Rows.Add();
                    dgv납기율.Rows[i].Cells["월별"].Value = dt.Rows[i]["월"].ToString();
                    dgv납기율.Rows[i].Cells["율"].Value = dt.Rows[i]["납기준수율"].ToString();
                    dgv납기율.Rows[i].Cells["율"].Value = Math.Round(double.Parse(dgv납기율.Rows[i].Cells["율"].Value.ToString()), 2);
                }

                chart1.ChartAreas[0].AxisY.Maximum = 100;
                chart1.ChartAreas[0].AxisY.Minimum = 0;
            }
            catch
            {

            }
        
        }

        private void btnSrch_Click(object sender, EventArgs e)
        {
            try
            {
                chart1.Visible = true;
                DataTable dt = fn_납기지연_List(cmb_year.SelectedValue.ToString());
                dgv납기율.Rows.Clear();
                chart1.Series[0].Points.Clear();

                for (int i = 0; i <= 11; i++)
                {
                    dgv납기율.Rows.Add();
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //dgv납기율.Rows.Add();
                    dgv납기율.Rows[i].Cells["월별"].Value = dt.Rows[i]["월"].ToString();
                    dgv납기율.Rows[i].Cells["율"].Value = dt.Rows[i]["납기준수율"].ToString();
                    dgv납기율.Rows[i].Cells["율"].Value = Math.Round(double.Parse(dgv납기율.Rows[i].Cells["율"].Value.ToString()), 2);
                }


                for (int i = 0; i <= 11; i++)
                {
                    chart1.Series[0].Points.AddXY((i + 1) + "월", double.Parse((dgv납기율.Rows[i].Cells["율"].Value ?? 0).ToString()));
                }


                for (int i = 0; i <= dgv납기율.Rows.Count; i++)
                {
                    //chart1.Series[0].Points.DataBindY(double.Parse(dgv납기율.Rows[i].Cells["율"].Value.ToString()), Poin[i]);
                }


                //chart1.DataSource = dt;
                //chart1.Series[0].XValueMember = "월";
                //chart1.Series[0].YValueMembers = "납기준수율";
                //chart1.DataBind();

                //chartB.ChartAreas[0].AxisY.Maximum = 100;
                //chartB.ChartAreas[0].AxisY.Minimum = 0;


                //chartB.Series[0].Points.Clear();
                //chart1.Series[0].Points.AddXY(10, 400);
                //chart1.Series[0].Points.AddXY(20, 500);
                //chart1.Series[0].Points.AddXY(30, 100);
                //chart1.Series[0].Points.AddXY(40, 400);

                //for (int i = 0; i < dgv납기율.Rows.Count; i++)
                //{
                //    chartB.Series[0].Points.AddXY("1월", double.Parse(dgv납기율.Rows[i].Cells["율"].Value.ToString()));
                //    chartB.Series[0].Points.AddXY(int.Parse(dgv납기율.Rows[i].Cells["월별"].Value.ToString()), double.Parse(dgv납기율.Rows[i].Cells["율"].Value.ToString()));
                //    chartB.Series[0].Points.AddXY(int.Parse(dgv납기율.Rows[i].Cells["월별"].Value.ToString()), double.Parse(dgv납기율.Rows[i].Cells["율"].Value.ToString()));
                //    chartB.Series[0].Points.AddXY(int.Parse(dgv납기율.Rows[i].Cells["월별"].Value.ToString()), double.Parse(dgv납기율.Rows[i].Cells["율"].Value.ToString()));
                //}

                //chartB.Series[0].Points.AddXY(3, 0);
                //chartB.Series[0].Points.AddXY(4, 0);
                //chartB.Series[0].Points.AddXY(5, 3);
                //chartB.Series[0].Points.AddXY(6, 0);

                //for (int j = 0; j <= 11; j++)
                //{
                //    chartB.Series[0].Points.AddXY(j + 1 + " 월", null);
                //}

                //for (int i = 0; i <= dgv납기율.Rows.Count; i++)
                //{              
                //    chartB.Series[0].Points.InsertY(i, double.Parse(dgv납기율.Rows[i].Cells["율"].Value.ToString()));               
                //}        
            }
            catch
            {
            }
        }

        public DataTable fn_납기지연_List(String condition)
        {
            StringBuilder sb = new StringBuilder();

            //==================ㅈ납기지연율==
            sb.AppendLine("Create Table #TEST1( Name   Varchar(50))");
            sb.AppendLine("   Insert Into #TEST1 (Name) values ('01') Insert Into #TEST1 (Name) values ('02')Insert Into #TEST1 (Name) values ('03') Insert Into #TEST1 (Name) values ('04')Insert Into #TEST1 (Name) values ('05')  Insert Into #TEST1 (Name) values ('06') Insert Into #TEST1 (Name) values ('07') Insert Into #TEST1 (Name) values ('08') Insert Into #TEST1 (Name) values ('09')  Insert Into #TEST1 (Name) values ('10') Insert Into #TEST1 (Name) values ('11') Insert Into #TEST1 (Name) values ('12')");
          
            sb.AppendLine("      select substring(c.OUTPUT_DATE,6,2)as 월 ,sum(c.OUTPUT_AMT) as 율  into #Tmp총수량 from F_ITEM_OUT_DETAIL c  ");
            if (condition != "")
            {
                sb.AppendLine("     where c.OUTPUT_DATE like '" + condition + "%' ");
            }
            sb.AppendLine("      group by substring(c.OUTPUT_DATE,6,2) ");
            sb.AppendLine("     select  substring(a.w_inst_date,6,2) as 월, SUM(b.OUTPUT_AMT) as 율 into #Tmp납기량 from F_WORK_INST a    ");
            sb.AppendLine("      inner join F_ITEM_OUT_DETAIL b on A.LOT_NO =B.LOT_NO and  a.DELIVERY_DATE<b.OUTPUT_DATE ");
            if (condition != "")
            {
                sb.AppendLine("        where a.w_inst_date like '" + condition + "%' ");
            }
            sb.AppendLine("     group by substring(a.w_inst_date,6,2)  ");

            sb.AppendLine("       select test.Name as 월, isnull(z.납기준수율,0) as 납기준수율  from #Test1  as test  ");
            sb.AppendLine("        left join( ");

            sb.AppendLine("      select a.월,isnull(100-(b.율/a.율)*100,100) as 납기준수율 from #Tmp총수량 a  ");
            sb.AppendLine("        left join #tmp납기량 b on a.월=b.월 ");
            sb.AppendLine("        ) as z on z.월= test.Name ");
        
         
       //select  substring(a.w_inst_date,6,2) as 월, SUM(b.OUTPUT_AMT) as 율 from F_WORK_INST a
       //   inner join F_ITEM_OUT_DETAIL b on A.LOT_NO =B.LOT_NO and  a.DELIVERY_DATE<b.OUTPUT_DATE 
       //    where a.W_INST_DATe like '2020%'
       //    group by substring(a.w_inst_date,6,2) 


            Debug.WriteLine("납기준율");

            Debug.WriteLine(sb);
            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

         
            return wAdo.SqlCommandSelect(sCommand);
        }
        private void init_ComboBox()
        {
            string sqlQuery = "";
            cmb_year.ValueMember = "월";
            cmb_year.DisplayMember = "월";
            sqlQuery = "  select substring(w_inst_date,0,5) as 월 from F_WORK_INST group by substring(w_inst_date,0,5) order by  월 desc";
            //sqlQuery += " union all ";
            //sqlQuery += "select DATEPART(YYYY,dateadd(year,-1,getdate())) as s_year";

            wConst.ComboBox_Read_NoBlank(cmb_year, sqlQuery);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
