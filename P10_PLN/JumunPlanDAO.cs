using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MES.CLS;
using System.Data;
namespace MES.P10_PLN
{
    class JumunPlanDAO : interfaceJumunPlan
    {
        wnDm wndm = new wnDm();
        wnGConstant wConst = new wnGConstant();
        JumunPlanDTO jdto = new JumunPlanDTO();
        public StringBuilder sb1 = new StringBuilder();
        int chk = 1;

        public JumunPlanDTO save(JumunPlanDTO dto, StringBuilder sb1)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("declare @seq   int ");
            sb.AppendLine("select @seq =ISNULL(MAX(PLAN_CD),0)+1 from F_PLAN ");
            sb.AppendLine("where PLAN_DATE = CONVERT(date,GETDATE()) ");
            

            sb.AppendLine("insert into F_PLAN( PLAN_DATE  ");
            sb.AppendLine("     , PLAN_CD  ");
            sb.AppendLine("     , CUST_CD  ");
            sb.AppendLine("     , STAFF_CD  ");
            sb.AppendLine("     , COMMENT  ");
            sb.AppendLine("     , INTIME  ");

            sb.AppendLine("     , ORDER_YN  ");
            sb.AppendLine("     , PLAN_NUM  ");
            sb.AppendLine("     , WORK_YN  ");
            sb.AppendLine("     ) values(  ");
            sb.AppendLine("     CONVERT(date,GETDATE())  ");
            sb.AppendLine("     ,@seq  ");
            sb.AppendLine("     ,'" + jdto.Plandt.Rows[0]["PUR_CUST_CD"].ToString() + "'  ");
            sb.AppendLine("     ,'" + Common.p_strStaffNo + "'  ");
            sb.AppendLine("     ,''  ");
            sb.AppendLine("     , CONVERT(date,GETDATE())  ");

            sb.AppendLine("     ,'N'  ");
            sb.AppendLine("     ,'P' + '-' +right(replace(convert(nvarchar,CONVERT(nvarchar,GETDATE(),2)),'.',''),4) + '-' + RIGHT('000'+ convert(varchar, @seq), 3)   ");
            sb.AppendLine("     ,'N' ) ");

            for (int i = 0; i < jdto.Plandt.Rows.Count; i++)
            {
                sb.AppendLine("insert into  F_PLAN_DETAIL( PLAN_DATE   ");
                sb.AppendLine("     , PLAN_CD  ");
                sb.AppendLine("     , SEQ  ");
                sb.AppendLine("     , ITEM_CD  ");
                sb.AppendLine("     , UNIT_CD  ");
                sb.AppendLine("     , TOTAL_AMT  ");
                sb.AppendLine("     , PRICE  ");
                sb.AppendLine("     , TOTAL_MONEY  ");
                sb.AppendLine("     , F_LEVEL  ");
                sb.AppendLine("     , DEFAULT_AMT  ");
                sb.AppendLine("     , WORK_YN  ");
                sb.AppendLine("     , INSTAFF  ");
                sb.AppendLine("     , INTIME  ");

                sb.AppendLine("     ) values(  ");
                sb.AppendLine("     CONVERT(date,GETDATE())  ");
                sb.AppendLine("     ,@seq  ");
                sb.AppendLine("     ,"+(i+1)+"  ");
                sb.AppendLine("     ,'"+jdto.Plandt.Rows[i]["PLAN_ITEM_CD"].ToString()+"'  ");
                sb.AppendLine("     ,'" + jdto.Plandt.Rows[i]["UNIT_CD"].ToString().Replace(",", "") + "'  ");
                sb.AppendLine("     ," + jdto.Plandt.Rows[i]["RS_AMT"].ToString().Replace(",", "") + "  ");
                sb.AppendLine("     ," + jdto.Plandt.Rows[i]["PRICE"].ToString().Replace(",", "") + "  ");
                sb.AppendLine("     ," + (decimal.Parse(jdto.Plandt.Rows[i]["RS_AMT"].ToString().Replace(",", "")) * decimal.Parse(jdto.Plandt.Rows[i]["PRICE"].ToString().Replace(",", ""))) + "  ");
                sb.AppendLine("     ,1  ");
                sb.AppendLine("     ,1  ");
                sb.AppendLine("     ,'N'  ");
                sb.AppendLine("     ,'" + Common.p_strStaffNo + "'  ");
                sb.AppendLine("     ,CONVERT(date,GETDATE()))  ");

            }
            chk = wndm.in_up_del_table(sb, "insert_plan_table");
            StringBuilder sb2 = new StringBuilder();

            if (chk == 0)
            {
                sb2.AppendLine("declare @seq   int ");
                sb2.AppendLine("declare @date nvarchar(20)");
                sb2.AppendLine("set @date = CONVERT(nvarchar,GETDATE(),23) ");
                sb2.AppendLine("select @seq = MAX(PLAN_CD) from F_PLAN ");
                sb2.AppendLine("where PLAN_DATE = CONVERT(nvarchar,GETDATE(),23) ");

                sb2.AppendLine("update F_JUMUN set ");
                sb2.AppendLine("     PLAN_YN  = 'Y' ");
                sb2.AppendLine("     , PLAN_DATE  = CONVERT(date,GETDATE()) ");
                sb2.AppendLine("     , PLAN_CD  = @seq ");
                sb2.AppendLine("    where (  ");
                sb2.AppendLine(sb1.ToString());

                if (sb1 == null || sb1.ToString().Equals(""))
                {
                    
                }

                sb2.AppendLine("DECLARE	@return_value int ");
                sb2.AppendLine("EXEC	@return_value = [dbo].[SP_PLAN_GROUP] ");
                sb2.AppendLine("@PLAN_DATE = @date ,");
                sb2.AppendLine("@PLAN_CD = @seq, ");
                sb2.AppendLine("@STAFFCD = '" + Common.p_strStaffNo + "' ");
                sb2.AppendLine("SELECT	'RV' = @return_value ");

                chk = wndm.in_up_del_table(sb2, "update_jumun_table");
                jdto.Plandt = null;
            }
         

        

            jdto.Succer = chk;
            plan(jdto);
            formLoad();
            chk = 1;

            return jdto;
        }

        public JumunPlanDTO formLoad()
        {
            StringBuilder sb = new StringBuilder();


            sb.AppendLine("select ");
            sb.AppendLine("     A.JUMUN_DATE ");
            sb.AppendLine("     , A.JUMUN_CD  ");
            sb.AppendLine("     , 'false' as CHK  ");
            sb.AppendLine("     , ROW_NUMBER() OVER( ORDER BY A.JUMUN_DATE ) AS NUMBER ");

            
            // sb.AppendLine("     , C.ITEM_NM ");
            //sb.AppendLine("     , B.ITEM_CD ");
            sb.AppendLine("     , case when ITEM_CNT > 1 then C.ITEM_NM + '외'+CONVERT(nvarchar,B.ITEM_CNT-1)+'개' else C.ITEM_NM end ITEM_CNT");
            //sb.AppendLine("     , B.ITEM_CNT ");
            sb.AppendLine("     , D.CUST_NM ");
            sb.AppendLine("     , D.CUST_CD ");
            sb.AppendLine(" from (select * from F_JUMUN where PLAN_YN = 'N') A ");
            sb.AppendLine(" inner join (select JUMUN_DATE, JUMUN_CD, count(isnull(SEQ,0)) as ITEM_CNT, MAX(ITEM_CD) as ITEM_CD from F_JUMUN_DETAIL group by JUMUN_DATE, JUMUN_CD )B ");
            sb.AppendLine(" on A.JUMUN_DATE = B.JUMUN_DATE ");
            sb.AppendLine(" and A.JUMUN_CD = B.JUMUN_CD ");
            sb.AppendLine(" left outer join N_ITEM_CODE C ");
            sb.AppendLine(" on B.ITEM_CD = C.ITEM_CD ");
            sb.AppendLine(" left outer join N_CUST_CODE D ");
            sb.AppendLine(" on A.CUST_CD = D.CUST_CD ");
            DataTable dt = wndm.selectList(sb);
            jdto.Jumundt = dt;

            return jdto;
        }

        public JumunPlanDTO plan(JumunPlanDTO dto)
        {
            jdto = dto;

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("select ");
            sb.AppendLine("     A.ITEM_CD ");
            sb.AppendLine("     , A.RS_AMT  ");
            sb.AppendLine("     , 'false' as CHK  ");
            sb.AppendLine("     , 0 as PRICE  ");
            sb.AppendLine("     , ROW_NUMBER() OVER( ORDER BY A.ITEM_CD ) AS NUMBER ");
            sb.AppendLine("     , B.ITEM_NM ");
            sb.AppendLine("     , B.UNIT_CD ");
            sb.AppendLine("     , C.UNIT_CD ");
            sb.AppendLine("     , C.UNIT_NM ");
            sb.AppendLine("     , B.BAL_STOCK");
            sb.AppendLine("     , B.SPEC ");
            sb.AppendLine("     , 0 as TOTAL_MONEY ");
            sb.AppendLine(" from (select ITEM_CD, sum(isnull(AMOUNT, 0)) as RS_AMT");
            sb.AppendLine(" from F_JUMUN_DETAIL  ");

            sb.AppendLine("where 1 = "+chk);
            if (chk == 1)
            {
            sb.AppendLine("and(");
            sb1 = new StringBuilder();
            int cnt = 0;
                for (int i = 0; i < dto.Jumundt.Rows.Count; i++)
                {
                    if (dto.Jumundt.Rows[i]["CHK"].ToString() == "true")
                    {
                        if (cnt < 1)
                        {
                            cnt++;
                            sb1.AppendLine("(JUMUN_DATE = '" + dto.Jumundt.Rows[i]["JUMUN_DATE"].ToString() + "' and  JUMUN_CD = '" + dto.Jumundt.Rows[i]["JUMUN_CD"].ToString() + "')");
                        }
                        else
                            sb1.AppendLine("or(JUMUN_DATE = '" + dto.Jumundt.Rows[i]["JUMUN_DATE"].ToString() + "' and  JUMUN_CD = '" + dto.Jumundt.Rows[i]["JUMUN_CD"].ToString() + "')");

                    }


                }
            sb.AppendLine(sb1.ToString());

            sb.AppendLine(")");
            }

            sb.AppendLine(" group by ITEM_CD) as A ");
            sb.AppendLine(" left outer join N_ITEM_CODE B ");
            sb.AppendLine(" on A.ITEM_CD =B.ITEM_CD ");
            sb.AppendLine(" left outer join N_UNIT_CODE C ");
            sb.AppendLine(" on B.UNIT_CD = C.UNIT_CD");


            DataTable dt = wndm.selectList(sb);
            jdto.Plandt = dt;

            return jdto;
        }

        public JumunPlanDTO plan2(JumunPlanDTO dto)
        {
            jdto = dto;

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("select ");
            sb.AppendLine("     A.ITEM_CD ");
            sb.AppendLine("     , A.RS_AMT  ");
            sb.AppendLine("     , 'false' as CHK  ");
            sb.AppendLine("     , 0 as PRICE  ");
            sb.AppendLine("     , ROW_NUMBER() OVER( ORDER BY A.ITEM_CD ) AS NUMBER ");
            sb.AppendLine("     , B.ITEM_NM ");
            sb.AppendLine("     , B.UNIT_CD ");
            sb.AppendLine("     , C.UNIT_CD ");
            sb.AppendLine("     , C.UNIT_NM ");
            sb.AppendLine("     , B.BAL_STOCK");
            sb.AppendLine("     , B.SPEC ");
            sb.AppendLine("     , A.CUST_CD ");
            sb.AppendLine("     , 0 as TOTAL_MONEY ");
            sb.AppendLine(" from (select ITEM_CD, sum(isnull(AMOUNT, 0)) as RS_AMT, B.CUST_CD ");
            sb.AppendLine(" from F_JUMUN_DETAIL A  ");
            sb.AppendLine("  left outer join F_JUMUN B ");
            sb.AppendLine("  on A.JUMUN_DATE = B.JUMUN_DATE ");
            sb.AppendLine("  and A.JUMUN_CD = B.JUMUN_CD ");
            sb.AppendLine("where 1 = " + chk);
            if (chk == 1)
            {
                sb.AppendLine("and(");
                sb1 = new StringBuilder();
                int cnt = 0;
                for (int i = 0; i < dto.Jumundt.Rows.Count; i++)
                {
                    if (dto.Jumundt.Rows[i]["CHK"].ToString() == "true")
                    {
                        if (cnt < 1)
                        {
                            cnt++;
                            sb1.AppendLine("(A.JUMUN_DATE = '" + dto.Jumundt.Rows[i]["JUMUN_DATE"].ToString() + "' and  A.JUMUN_CD = '" + dto.Jumundt.Rows[i]["JUMUN_CD"].ToString() + "')");
                        }
                        else
                            sb1.AppendLine("or(A.JUMUN_DATE = '" + dto.Jumundt.Rows[i]["JUMUN_DATE"].ToString() + "' and  A.JUMUN_CD = '" + dto.Jumundt.Rows[i]["JUMUN_CD"].ToString() + "')");

                    }


                }
                sb.AppendLine(sb1.ToString());

                sb.AppendLine(")");
            }

            sb.AppendLine(" group by ITEM_CD) as A ");
            sb.AppendLine(" left outer join N_ITEM_CODE B ");
            sb.AppendLine(" on A.ITEM_CD =B.ITEM_CD ");
            sb.AppendLine(" left outer join N_UNIT_CODE C ");
            sb.AppendLine(" on B.UNIT_CD = C.UNIT_CD");


            DataTable dt = wndm.selectList(sb);
            jdto.Plandt = dt;

            return jdto;
        }


        public JumunPlanDTO update()
        {
            return jdto;

        }

        public JumunPlanDTO delete()
        {
            return jdto;

        }


        public decimal totalMoney(decimal amt, decimal price)
        {

            decimal a = amt >= 0 ? amt : 0;
            decimal b = price >= 0 ? price : 0;
            

            return a*b;
        }

        public decimal price(decimal amt, decimal money)
        {

            decimal a = amt >= 0 ? amt : 0;
            decimal b = money >= 0 ? money : 0;


            return b / a;
        }

    }
}
