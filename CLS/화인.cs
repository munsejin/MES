using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MES.Controls;
using MES.Popup;
using System.Collections;

namespace MES.CLS
{
    public class 화인
    {
        wnAdo wAdo = new wnAdo();

        public int insertOrd(
             string txt_user_cd
            , string txt_user_nm
            , string dept_cd
            , string pos_cd
            , string stor_cd
            , string join_date
            , string txt_phone
            , string txt_login
            , string txt_pw
            , string auth_cd
            , string comment)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();



                sb.AppendLine(" select ");
                sb.AppendLine("(select COUNT(*) from N_STAFF_CODE where STAFF_CD = '" + txt_user_cd + "' ) as cnt ");
                sb.AppendLine(",(select COUNT(*) from N_STAFF_CODE where LOGIN_ID = '" + txt_login + "') as id ");
                //sb.AppendLine(",(select COUNT(*) from N_STAFF_CODE where PW = 1) as pw ");
                sb.AppendLine("from N_STAFF_CODE  ");


                SqlCommand sCommand = new SqlCommand(sb.ToString());
                if (sCommand.CommandText.Equals(null))
                {
                    wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                    return 2;
                }

                DataTable dt = wAdo.SqlCommandSelect(sCommand);

                if (!dt.Rows[0]["cnt"].ToString().Equals("0"))
                {
                    return 3;
                }
                if (!dt.Rows[0]["id"].ToString().Equals("0"))
                {
                    return 4;
                }
                //if (!dt.Rows[0]["pw"].ToString().Equals("0"))
                //{
                //    return 5;
                //}

                sb = new StringBuilder();
                sb.AppendLine("insert into N_STAFF_CODE(");
                sb.AppendLine("     STAFF_CD ");
                sb.AppendLine("     ,STAFF_NM ");
                sb.AppendLine("     ,JOIN_DATE ");
                sb.AppendLine("     ,PHONE_NUM ");
                sb.AppendLine("     ,DEPT_CD ");
                sb.AppendLine("     ,POS_CD ");
                sb.AppendLine("     ,STORAGE_CD ");
                sb.AppendLine("     ,LOGIN_ID ");
                sb.AppendLine("     ,PW ");
                sb.AppendLine("     ,AUTH_SET ");
                sb.AppendLine("     ,COMMENT ");
                sb.AppendLine(" ) values ( ");
                sb.AppendLine("  @STAFF_CD ");
                sb.AppendLine(" ,@STAFF_NM ");
                sb.AppendLine(" ,@JOIN_DATE ");
                sb.AppendLine(" ,@PHONE_NUM ");
                sb.AppendLine(" ,@DEPT_CD ");
                sb.AppendLine(" ,@POS_CD ");
                sb.AppendLine(" ,@STORAGE_CD ");
                sb.AppendLine(" ,@LOGIN_ID ");
                sb.AppendLine(" ,@PW ");//HASHBYTES('SHA2_512' , '123456')
                sb.AppendLine(" ,@AUTH_SET ");
                sb.AppendLine(" ,@COMMENT ");
                sb.AppendLine(" ) ");

                sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@STAFF_CD", txt_user_cd);
                sCommand.Parameters.AddWithValue("@STAFF_NM", txt_user_nm);
                sCommand.Parameters.AddWithValue("@JOIN_DATE", join_date);
                sCommand.Parameters.AddWithValue("@PHONE_NUM", txt_phone);
                sCommand.Parameters.AddWithValue("@DEPT_CD", dept_cd);
                sCommand.Parameters.AddWithValue("@POS_CD", pos_cd);
                sCommand.Parameters.AddWithValue("@STORAGE_CD", stor_cd);
                sCommand.Parameters.AddWithValue("@LOGIN_ID", txt_login);
                sCommand.Parameters.AddWithValue("@PW", txt_pw);
                sCommand.Parameters.AddWithValue("@AUTH_SET", auth_cd);
                sCommand.Parameters.AddWithValue("@COMMENT", comment);

                int qResult = wAdo.SqlCommandEtc(sCommand, "insert_USER_TB");
                if (qResult > 0)
                {
                    return 0;  // 0 true, 1 false
                }
                else return 1;
            }
            catch (Exception e)
            {
                wnLog.writeLog(wnLog.LOG_ERROR, e.Message + " - " + e.ToString());
                Popup.pop오류리포트 msg = new pop오류리포트(e.Message + " - " + e.ToString());
                msg.ShowDialog();
                return 9;
            }
        }


    }
}
