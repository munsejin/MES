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
    public class wnDm
    {
        wnAdo wAdo = new wnAdo();

        public DataTable fn_TopMenu_List()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("     a.TopID ");
            sb.AppendLine("     , a.TopName ");
            sb.AppendLine(" from T_TopMenu a ");
            sb.AppendLine(" inner join (  select TopID from T_SubMenu where VIEW_YN = 'Y' group by TopID)b ");
            sb.AppendLine(" on a.TopID = b.TopID ");
            sb.AppendLine(" order by a.SortNo asc ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }

        //유정훈 추가 (권한)
        public DataTable fn_TopMenu_Auth_List()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("     a.TopID ");
            sb.AppendLine("     , a.TopName ");
            sb.AppendLine(" from T_TopMenu a ");
            sb.AppendLine(" inner join N_AUTH_TOP b  ");
            sb.AppendLine(" on a.TopID = b.TopID   ");
            sb.AppendLine("     and b.AUTH_YN  = 'Y'   ");
            sb.AppendLine(" where b.STAFF_CD = '" + Common.p_strStaffNo + "' ");
            sb.AppendLine(" order by a.SortNo asc ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_SubMenu_List(string sID)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("     a.TopID ");
            sb.AppendLine("     , a.SubID ");
            sb.AppendLine("     , a.SubName ");
            sb.AppendLine("     , a.AsmName ");
            sb.AppendLine(" from T_SubMenu a ");
            sb.AppendLine(" where a.TopID = @TopID ");
            sb.AppendLine("     and a.VIEW_YN = 'Y'  ");
            sb.AppendLine(" order by a.SortNo asc ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            sCommand.Parameters.AddWithValue("@TopID", sID);
            return wAdo.SqlCommandSelect(sCommand);
        }
        //유정훈 추가 
        public DataTable fn_SubMenu_Auth_List(string sID)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("     a.TopID ");
            sb.AppendLine("     , a.SubID ");
            sb.AppendLine("     , a.SubName ");
            sb.AppendLine("     , a.AsmName ");
            sb.AppendLine(" from T_SubMenu a ");
            sb.AppendLine(" inner join N_AUTH_SUB b ");
            sb.AppendLine(" on a.TopID = b.TopID ");
            sb.AppendLine("     and a.SubID = b.SubID ");
            sb.AppendLine(" where a.TopID = @TopID ");
            sb.AppendLine("     and b.AUTH_YN = 'Y'  ");
            sb.AppendLine("     and b.STAFF_CD = '" + Common.p_strStaffNo + "' ");

            sb.AppendLine(" order by a.SortNo asc ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            sCommand.Parameters.AddWithValue("@TopID", sID);
            return wAdo.SqlCommandSelect(sCommand);
        }
        public DataTable fn_Group_List(string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("     a.GrpID ");
            sb.AppendLine("     , a.GrpName ");
            sb.AppendLine(" from T_Group a ");
            sb.AppendLine(" where 1=1 ");
            sb.AppendLine("     " + condition + " ");
            sb.AppendLine(" order by a.GrpName asc ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            //sCommand.Parameters.AddWithValue("@p_Level", userLevel);
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_Group_Detail(string sID)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("     a.GrpID ");
            sb.AppendLine("     , a.GrpName ");
            sb.AppendLine(" from T_Group a ");
            sb.AppendLine(" where 1=1 ");
            sb.AppendLine("     and a.GrpID = @GrpID  ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            sCommand.Parameters.AddWithValue("@GrpID", sID);
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_AllMenu_CheckList(string sGrp)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(" select ");
            sb.AppendLine("     z.* ");
            sb.AppendLine(" from ( ");
            sb.AppendLine(" select ");
            sb.AppendLine("     a.TopID ");
            sb.AppendLine("     , '' as SubID ");
            sb.AppendLine("     , a.TopName as MenuName");
            sb.AppendLine("     , a.SortNo as TopSort ");
            sb.AppendLine("     , 0 as SubSort ");
            sb.AppendLine("     , '' as ChkYN ");
            sb.AppendLine("     , (select count(*) from T_GroupSub where TopID = a.TopID and GrpID = @GrpID) as SubCnt ");
            sb.AppendLine(" from T_TopMenu a ");
            sb.AppendLine("     left outer join T_GroupTop g1 on g1.TopID = a.TopID and g1.GrpID = @GrpID ");

            sb.AppendLine(" union all ");

            sb.AppendLine(" select ");
            sb.AppendLine("     a.TopID ");
            sb.AppendLine("     , b.SubID ");
            sb.AppendLine("     , b.SubName as MenuName");
            sb.AppendLine("     , a.SortNo as TopSort ");
            sb.AppendLine("     , b.SortNo as SubSort ");
            sb.AppendLine("     , case when isnull(g2.GrpID, '') = '' then 'N' else 'Y' end as ChkYN ");
            sb.AppendLine("     , 0 as SubCnt ");
            sb.AppendLine(" from T_TopMenu a ");
            sb.AppendLine("     inner join T_SubMenu b on b.TopID = a.TopID ");
            sb.AppendLine("     left outer join T_GroupSub g2 on g2.TopID = b.TopID and g2.SubID = b.SubID and g2.GrpID = @GrpID ");

            sb.AppendLine(" ) z ");
            sb.AppendLine(" order by z.TopSort asc, z.SubSort asc ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            sCommand.Parameters.AddWithValue("@GrpID", sGrp);
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_User_UnCheckList()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(" select ");
            sb.AppendLine("     a.USER_CODE ");
            sb.AppendLine("     , a.USER_ID ");
            sb.AppendLine("     , a.USER_NAME ");
            sb.AppendLine("     , a.FlgWrite ");
            sb.AppendLine("     , a.FlgPrint ");
            sb.AppendLine("     , isnull(b.GrpID, -1) as GrpID ");
            sb.AppendLine(" from USER_PASSWD a ");
            sb.AppendLine("     left outer join T_GroupUser b on b.USER_CODE = a.USER_CODE ");
            sb.AppendLine(" where 1=1 ");
            sb.AppendLine("     and isnull(b.GrpID, -1) = -1 ");
            sb.AppendLine(" order by a.USER_NAME asc ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            //sCommand.Parameters.AddWithValue("@GrpID", sGrp);
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_GroupUser_List(string sGrp)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(" select ");
            sb.AppendLine("     a.USER_CODE ");
            sb.AppendLine("     , a.USER_ID ");
            sb.AppendLine("     , a.USER_NAME ");
            sb.AppendLine("     , a.FlgWrite ");
            sb.AppendLine("     , a.FlgPrint ");
            sb.AppendLine("     , isnull(b.GrpID, -1) as GrpID ");
            sb.AppendLine(" from USER_PASSWD a ");
            sb.AppendLine("     left outer join T_GroupUser b on b.USER_CODE = a.USER_CODE ");
            sb.AppendLine(" where 1=1 ");
            sb.AppendLine("     and isnull(b.GrpID, -1) = @GrpID ");
            sb.AppendLine(" order by a.USER_NAME asc ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            sCommand.Parameters.AddWithValue("@GrpID", sGrp);
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_User_List(string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("     a.* ");
            sb.AppendLine("     , (case when a.USER_SELECT = '1' then '부서별' when a.USER_SELECT = '2' then '담당자별' else '전체' end) as USER_SELECT_NM ");
            sb.AppendLine("     , c.CODE_DESC as USER_DEPT_NM ");
            sb.AppendLine("     , d.CODE_DESC as USER_MAN_NM ");
            sb.AppendLine(" from USER_PASSWD a ");
            sb.AppendLine("     left outer join DEPTCODE c on c.DEPT_CODE = a.USER_DEPT ");
            sb.AppendLine("     left outer join MANCODE d on d.MAN_CODE = a.USER_MAN ");
            sb.AppendLine(" where 1=1 ");
            sb.AppendLine("     " + condition + " ");
            sb.AppendLine(" order by a.USER_CODE asc ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_User_Detail(string sID)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("     a.* ");
            sb.AppendLine("     , b.GrpID ");
            sb.AppendLine("     , d.CODE_DESC ");
            sb.AppendLine(" from USER_PASSWD a ");
            sb.AppendLine("     left outer join T_GroupUser b on b.USER_CODE = a.USER_CODE ");
            sb.AppendLine("     left outer join DEPTCODE d on d.DEPT_CODE = a.USER_DEPT ");
            sb.AppendLine(" where 1=1 ");
            sb.AppendLine("     and a.USER_CODE = @USER_CODE  ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            sCommand.Parameters.AddWithValue("@USER_CODE", sID);
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_UserID_Detail(string sID)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("     a.* ");
            sb.AppendLine("     , b.GrpID ");
            sb.AppendLine(" from USER_PASSWD a ");
            sb.AppendLine("     left outer join T_GroupUser b on b.USER_CODE = a.USER_CODE ");
            sb.AppendLine(" where 1=1 ");
            sb.AppendLine("     and a.USER_ID = @USER_ID  ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            sCommand.Parameters.AddWithValue("@USER_ID", sID);
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_DEPTCODE_List(string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("     a.* ");
            sb.AppendLine("     , b.AreaName ");
            sb.AppendLine(" from DEPTCODE a ");
            sb.AppendLine("     left outer join T_Area b on b.AreaCode = a.AreaCode ");
            sb.AppendLine(" where 1=1 ");
            sb.AppendLine("     " + condition + " ");
            sb.AppendLine(" order by a.DEPT_CODE asc ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_DEPTCODE_Detail(string sID)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("     a.* ");
            sb.AppendLine("     , b.AreaName ");
            sb.AppendLine(" from DEPTCODE a ");
            sb.AppendLine("     left outer join T_Area b on b.AreaCode = a.AreaCode ");
            sb.AppendLine(" where 1=1 ");
            sb.AppendLine("     and a.DEPT_CODE = @p_1  ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            sCommand.Parameters.AddWithValue("@p_1", sID);
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_MANCODE_List(string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("     a.* ");
            sb.AppendLine("     , d.CODE_DESC as DEPT_NM ");
            sb.AppendLine(" from MANCODE a ");
            sb.AppendLine("     left outer join DEPTCODE d on d.DEPT_CODE = a.DEPT_CODE ");
            sb.AppendLine(" where 1=1 ");
            sb.AppendLine("     " + condition + " ");
            sb.AppendLine(" order by a.MAN_CODE asc ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_MANCODE_Detail(string sID)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("     a.* ");
            sb.AppendLine(" from MANCODE a ");
            sb.AppendLine(" where 1=1 ");
            sb.AppendLine("     and a.MAN_CODE = @p_1  ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            sCommand.Parameters.AddWithValue("@p_1", sID);
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_MAJORCODE_List(string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("     a.* ");
            sb.AppendLine(" from MAJORCODE a ");
            sb.AppendLine(" where 1=1 ");
            sb.AppendLine("     " + condition + " ");
            sb.AppendLine(" order by a.MAJOR_CODE asc ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_MAJORCODE_Detail(string sID)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("     a.* ");
            sb.AppendLine(" from MAJORCODE a ");
            sb.AppendLine(" where 1=1 ");
            sb.AppendLine("     and a.MAJOR_CODE = @p_1  ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            sCommand.Parameters.AddWithValue("@p_1", sID);
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_DEALKIND_List(string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("     a.* ");
            sb.AppendLine(" from DEALKIND a ");
            sb.AppendLine(" where 1=1 ");
            sb.AppendLine("     " + condition + " ");
            sb.AppendLine(" order by a.DEAL_KIND asc ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_DEALKIND_Detail(string sID)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("     a.* ");
            sb.AppendLine(" from DEALKIND a ");
            sb.AppendLine(" where 1=1 ");
            sb.AppendLine("     and a.DEAL_KIND = @p_1  ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            sCommand.Parameters.AddWithValue("@p_1", sID);
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_STORECODE_List(string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("     a.* ");
            sb.AppendLine(" from STORECODE a ");
            sb.AppendLine(" where 1=1 ");
            sb.AppendLine("     " + condition + " ");
            sb.AppendLine(" order by a.STORE_CODE asc ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_STORECODE_Detail(string sID)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("     a.* ");
            sb.AppendLine(" from STORECODE a ");
            sb.AppendLine(" where 1=1 ");
            sb.AppendLine("     and a.STORE_CODE = @p_1  ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            sCommand.Parameters.AddWithValue("@p_1", sID);
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_PRODUCTKIND_List(string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("     a.* ");
            sb.AppendLine(" from PRODUCTKIND a ");
            sb.AppendLine(" where 1=1 ");
            sb.AppendLine("     " + condition + " ");
            sb.AppendLine(" order by a.PRODUCT_KIND asc ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_PRODUCTKIND_Detail(string sID)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("     a.* ");
            sb.AppendLine(" from PRODUCTKIND a ");
            sb.AppendLine(" where 1=1 ");
            sb.AppendLine("     and a.PRODUCT_KIND = @p_1  ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            sCommand.Parameters.AddWithValue("@p_1", sID);
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_PRODUCTTYPE_List(string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("     a.* ");
            sb.AppendLine(" from PRODUCTTYPE a ");
            sb.AppendLine(" where 1=1 ");
            sb.AppendLine("     " + condition + " ");
            sb.AppendLine(" order by a.PRODUCT_TYPE asc ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_PRODUCTTYPE_Detail(string sID)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("     a.* ");
            sb.AppendLine(" from PRODUCTTYPE a ");
            sb.AppendLine(" where 1=1 ");
            sb.AppendLine("     and a.PRODUCT_TYPE = @p_1  ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            sCommand.Parameters.AddWithValue("@p_1", sID);
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_PRODUCTCLASS_List(string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("     a.* ");
            sb.AppendLine(" from PRODUCTCLASS a ");
            sb.AppendLine(" where 1=1 ");
            sb.AppendLine("     " + condition + " ");
            sb.AppendLine(" order by a.PRODUCT_CLASS asc ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_PRODUCTCLASS_Detail(string sID)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("     a.* ");
            sb.AppendLine(" from PRODUCTCLASS a ");
            sb.AppendLine(" where 1=1 ");
            sb.AppendLine("     and a.PRODUCT_CLASS = @p_1  ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            sCommand.Parameters.AddWithValue("@p_1", sID);
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_UnitCode_List(string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("     a.* ");
            sb.AppendLine(" from UnitCode a ");
            sb.AppendLine(" where 1=1 ");
            sb.AppendLine("     " + condition + " ");
            sb.AppendLine(" order by a.UNIT_CODE asc ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_UnitCode_Detail(string sID)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("     a.* ");
            sb.AppendLine(" from UnitCode a ");
            sb.AppendLine(" where 1=1 ");
            sb.AppendLine("     and a.UNIT_CODE = @p_1  ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            sCommand.Parameters.AddWithValue("@p_1", sID);
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_CUSTOMER_List_pop(string condition, int pageSize, int skipSize)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select TOP " + pageSize.ToString() + " ");
            sb.AppendLine("     a.CUST_CODE as 코드");
            sb.AppendLine("     , a.CUST_NAME as 거래처명 ");
            sb.AppendLine("     , a.REP_NAME as 대표자 ");
            sb.AppendLine("     , a.COMP_NUM as 사업자번호 ");
            sb.AppendLine("     , a.RES_NUM as 주민번호 ");
            sb.AppendLine("     , a.ZIP_CODE1 as 우편번호 ");
            sb.AppendLine("     , a.ZIP_AREA1 as 주소지역명 ");
            sb.AppendLine("     , a.ZIP_ADDR1 as 주소상세 ");
            sb.AppendLine("     , a.TEL_NUM1 as 전화번호 ");
            sb.AppendLine(" from CUSTOMER a ");
            sb.AppendLine(" where 1=1 ");
            sb.AppendLine("     " + condition + " ");
            sb.AppendLine("     and a.CUST_CODE not in (select TOP " + skipSize.ToString() + " a.CUST_CODE ");
            sb.AppendLine("                                 from CUSTOMER a ");
            sb.AppendLine("                                 where 1=1 ");
            sb.AppendLine("                                     " + condition + " ");
            sb.AppendLine("                             ) ");
            sb.AppendLine(" order by a.CUST_CODE asc ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_CUSTOMER_List(string condition, int pageSize, int skipSize)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select TOP " + pageSize.ToString() + " ");
            sb.AppendLine("     a.* ");
            //sb.AppendLine("     , b.AreaName ");
            sb.AppendLine(" from CUSTOMER a ");
            //sb.AppendLine("     left outer join T_Area b on b.AreaCode = a.AreaCode ");
            sb.AppendLine(" where 1=1 ");
            sb.AppendLine("     " + condition + " ");
            sb.AppendLine("     and a.CUST_CODE not in (select TOP " + skipSize.ToString() + " a.CUST_CODE ");
            sb.AppendLine("                                 from CUSTOMER a ");
            sb.AppendLine("                                 where 1=1 ");
            sb.AppendLine("                                     " + condition + " ");
            sb.AppendLine("                             ) ");
            sb.AppendLine(" order by a.CUST_CODE asc ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_CUSTOMER_List_Count(string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select count(*) as CNT ");
            sb.AppendLine(" from CUSTOMER a ");
            sb.AppendLine(" where 1=1 ");
            sb.AppendLine("     " + condition + " ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_CUSTOMER_Detail(string sID)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("     a.* ");
            sb.AppendLine("     , b.CODE_DESC as 담당자명 ");
            sb.AppendLine("     , b.DEPT_CODE ");
            sb.AppendLine("     , d.CODE_DESC as 부서명 ");
            sb.AppendLine(" from CUSTOMER a ");
            sb.AppendLine("     left outer join MANCODE b on b.MAN_CODE = a.MAN_CODE ");
            sb.AppendLine("     left outer join DEPTCODE d on d.DEPT_CODE = b.DEPT_CODE ");
            sb.AppendLine(" where 1=1 ");
            sb.AppendLine("     and a.CUST_CODE = @p_1  ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            sCommand.Parameters.AddWithValue("@p_1", sID);
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_MANCODE_List_pop(string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select  ");
            sb.AppendLine("     a.MAN_CODE as 코드");
            sb.AppendLine("     , a.CODE_DESC as 사원명 ");
            sb.AppendLine("     , b.CODE_DESC as 부서명 ");
            sb.AppendLine("     , case when isnull(a.MAN_OUTCHK, '0') = '1' then '퇴사' else '' end as 퇴사구분 ");
            sb.AppendLine(" from MANCODE a ");
            sb.AppendLine("     left outer join DEPTCODE b on b.DEPT_CODE = a.DEPT_CODE ");
            sb.AppendLine(" where 1=1 ");
            sb.AppendLine("     " + condition + " ");
            sb.AppendLine(" order by isnull(a.MAN_OUTCHK, '0') asc, a.MAN_CODE asc ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_PRODUCT_List_Count(string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select count(*) as CNT ");
            sb.AppendLine(" from PRODUCT a ");
            sb.AppendLine(" where 1=1 ");
            sb.AppendLine("     " + condition + " ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_PRODUCT_List_pop(string condition, int pageSize, int skipSize)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select TOP " + pageSize.ToString() + " ");
            sb.AppendLine("     a.PRODUCT_CODE as 코드");
            sb.AppendLine("     , a.PRODUCT_NAME as 제품명 ");
            sb.AppendLine("     , a.PRODUCT_SPEC as 규격 ");
            sb.AppendLine("     , a.PRODUCT_NAME_SHORT as 약칭 ");
            sb.AppendLine("     , a.VALID_NUM as 유효기간 ");
            sb.AppendLine("     , isnull(a.PRODUCT_PRICE1, 0) as 표준원가 ");
            sb.AppendLine("     , isnull(a.PRODUCT_PRICE2, 0) as 기준약가 ");

            sb.AppendLine("     , isnull(a.SELLING_PRICE1, 0) as 도매단가 ");
            sb.AppendLine("     , isnull(a.SELLING_PRICE2, 0) as 약국단가 ");
            sb.AppendLine("     , isnull(a.SELLING_PRICE3, 0) as 의원단가 ");
            sb.AppendLine("     , isnull(a.SELLING_PRICE4, 0) as 병원단가 ");
            sb.AppendLine("     , isnull(a.SELLING_PRICE5, 0) as 기타단가 ");
            sb.AppendLine("     , isnull(a.SELLING_PRICE6, 0) as 표준단가 ");

            sb.AppendLine("     , a.HSP_CODE as 의료보험코드 ");
            sb.AppendLine("     , a.의약품표준코드 ");
            sb.AppendLine("     , a.의약품대표코드 ");
            sb.AppendLine("     , a.의약품품목코드 ");
            sb.AppendLine("     , a.의약품제품명 ");
            sb.AppendLine(" from PRODUCT a ");
            sb.AppendLine(" where 1=1 ");
            sb.AppendLine("     " + condition + " ");
            sb.AppendLine("     and a.PRODUCT_CODE not in (select TOP " + skipSize.ToString() + " a.PRODUCT_CODE ");
            sb.AppendLine("                                 from PRODUCT a ");
            sb.AppendLine("                                 where 1=1 ");
            sb.AppendLine("                                     " + condition + " ");
            sb.AppendLine("                             ) ");
            sb.AppendLine(" order by a.PRODUCT_CODE asc ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_PRODUCT_Detail_Cust(string sCode, string sCust)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select a.* ");
            sb.AppendLine("     , isnull(b.할인율, 0) as 계약율 ");
            sb.AppendLine(" from PRODUCT a ");
            sb.AppendLine("     left outer join CUST_DISCOUNT b on b.거래처코드 = @p_2 and b.제품코드 = a.PRODUCT_CODE ");
            sb.AppendLine(" where a.PRODUCT_CODE = @p_1 ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            sCommand.Parameters.AddWithValue("@p_1", sCode);
            sCommand.Parameters.AddWithValue("@p_2", sCust);
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_CUST_CHANGE_List(string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("     a.* ");
            //sb.AppendLine("     , b.AreaName ");
            sb.AppendLine(" from CUST_CHANGE a ");
            //sb.AppendLine("     left outer join T_Area b on b.AreaCode = a.AreaCode ");
            sb.AppendLine(" where 1=1 ");
            sb.AppendLine("     " + condition + " ");
            sb.AppendLine(" order by a.일련번호 asc ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_CUST_CHANGE_Detail(string sID)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("     a.* ");
            //sb.AppendLine("     , b.AreaName ");
            sb.AppendLine(" from CUST_CHANGE a ");
            //sb.AppendLine("     left outer join T_Area b on b.AreaCode = a.AreaCode ");
            sb.AppendLine(" where 1=1 ");
            sb.AppendLine("     and a.일련번호 = @p_1  ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            sCommand.Parameters.AddWithValue("@p_1", sID);
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_PRODUCT_STOCK_DEPT_List(string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("     a.STOCK_DATE ");
            sb.AppendLine("     , a.STOCK_NUM ");
            sb.AppendLine("     , max(a.STOCK_KIND) as STOCK_KIND ");
            sb.AppendLine("     , max(a.CUST_CODE1) as CUST_CODE1 ");
            sb.AppendLine("     , max(a.CUST_NAME1) as CUST_NAME1 ");
            sb.AppendLine("     , max(a.MAN_CODE1) as MAN_CODE1 ");
            sb.AppendLine("     , max(a.MAN_NAME1) as MAN_NAME1 ");
            sb.AppendLine("     , case when isnull(max(a.STOCK_LAST1), '0') = '1' then 'Y' else '' end as STOCK_LAST1 ");
            sb.AppendLine("     , replace(max(a.TAX_DATE), '/', '-') as TAX_DATE ");
            sb.AppendLine(" from PRODUCT_STOCK_DEPT a ");
            sb.AppendLine(" where 1=1 ");
            sb.AppendLine("     " + condition + " ");
            sb.AppendLine(" group by a.STOCK_DATE, a.STOCK_NUM ");
            sb.AppendLine(" order by a.STOCK_DATE asc, a.STOCK_NUM asc ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_PRODUCT_STOCK_DEPT_Detail(string sDay, string sNum)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("     a.* ");
            sb.AppendLine("     , isnull(b.할인율, 0) as 계약율 ");
            sb.AppendLine("     , isnull(c.EMAIL, '') as EMAIL ");
            sb.AppendLine("     , c.DEAL_KIND ");
            sb.AppendLine("     , isnull(c.특매처, 0) as 특매처 ");
            sb.AppendLine(" from PRODUCT_STOCK_DEPT a ");
            sb.AppendLine("     left outer join CUST_DISCOUNT b on b.거래처코드 = a.CUST_CODE1 and b.제품코드 = a.STOCK_CODE ");
            sb.AppendLine("     left outer join CUSTOMER c on c.CUST_CODE = a.CUST_CODE1 ");
            sb.AppendLine(" where 1=1 ");
            sb.AppendLine("     and a.STOCK_DATE = @p_1  ");
            sb.AppendLine("     and a.STOCK_NUM = @p_2  ");
            sb.AppendLine(" order by a.STOCK_ILNUM asc ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            sCommand.Parameters.AddWithValue("@p_1", sDay);
            sCommand.Parameters.AddWithValue("@p_2", sNum);
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_PRODUCT_STOCK_DEPT_Detail_결재조건(string sDay, string sNum)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(" exec dbo.proc_영업소주문서결재조건2 @p_1, @p_2, '' ");

            sb.AppendLine(" select ");
            sb.AppendLine("     a.* ");
            sb.AppendLine("     , isnull(b.할인율, 0) as 계약율 ");
            sb.AppendLine("     , isnull(c.EMAIL, '') as EMAIL ");
            sb.AppendLine("     , c.DEAL_KIND ");
            sb.AppendLine("     , isnull(c.특매처, 0) as 특매처 ");
            sb.AppendLine("     , case when isnull(a.STOCK_DIS, 0) = 1 then 'V' else '' end as 할증체크 ");
            sb.AppendLine("     , case when isnull(a.STOCK_DAN, 0) = 1 then 'V' else '' end as 단가체크 ");
            sb.AppendLine("     , case when isnull(a.STOCK_HWOI, 0) = 1 then 'V' else '' end as 회전일체크 ");
            sb.AppendLine(" from PRODUCT_STOCK_DEPT a ");
            sb.AppendLine("     left outer join CUST_DISCOUNT b on b.거래처코드 = a.CUST_CODE1 and b.제품코드 = a.STOCK_CODE ");
            sb.AppendLine("     left outer join CUSTOMER c on c.CUST_CODE = a.CUST_CODE1 ");
            sb.AppendLine(" where 1=1 ");
            sb.AppendLine("     and a.STOCK_DATE = @p_1  ");
            sb.AppendLine("     and a.STOCK_NUM = @p_2  ");
            sb.AppendLine(" order by a.STOCK_DATE asc, a.STOCK_NUM asc, a.STOCK_ILNUM asc ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            sCommand.Parameters.AddWithValue("@p_1", sDay);
            sCommand.Parameters.AddWithValue("@p_2", sNum);
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_PRODUCT_STOCK_DEPT_Detail_결재대상들(string sDay, string sCust)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(" exec dbo.proc_영업소주문서결재조건2 @p_1, '', '" + sCust + "' ");

            sb.AppendLine(" select ");
            sb.AppendLine("     a.* ");
            sb.AppendLine("     , isnull(b.할인율, 0) as 계약율 ");
            sb.AppendLine("     , isnull(c.EMAIL, '') as EMAIL ");
            sb.AppendLine("     , c.DEAL_KIND ");
            sb.AppendLine("     , isnull(c.특매처, 0) as 특매처 ");
            sb.AppendLine("     , case when isnull(a.STOCK_DIS, 0) = 1 then 'V' else '' end as 할증체크 ");
            sb.AppendLine("     , case when isnull(a.STOCK_DAN, 0) = 1 then 'V' else '' end as 단가체크 ");
            sb.AppendLine("     , case when isnull(a.STOCK_HWOI, 0) = 1 then 'V' else '' end as 회전일체크 ");
            sb.AppendLine(" from PRODUCT_STOCK_DEPT a ");
            sb.AppendLine("     left outer join CUST_DISCOUNT b on b.거래처코드 = a.CUST_CODE1 and b.제품코드 = a.STOCK_CODE ");
            sb.AppendLine("     left outer join CUSTOMER c on c.CUST_CODE = a.CUST_CODE1 ");
            sb.AppendLine(" where 1=1 ");
            sb.AppendLine("     and a.STOCK_DATE = @p_1  ");
            sb.AppendLine("     and isnull(a.STOCK_LAST1, '') <> '1'  "); //미결 건만
            if (sCust != "")
            {
                sb.AppendLine("     and a.CUST_CODE1 = '" + sCust + "'  ");
            }
            sb.AppendLine(" order by a.STOCK_DATE asc, a.STOCK_NUM asc, a.STOCK_ILNUM asc ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            sCommand.Parameters.AddWithValue("@p_1", sDay);
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_PRODUCT_STORE_List(string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("     a.STOCK_DATE ");
            sb.AppendLine("     , a.STOCK_NUM ");
            sb.AppendLine("     , max(a.STOCK_KIND) as STOCK_KIND ");
            sb.AppendLine("     , max(a.CUST_CODE1) as CUST_CODE1 ");
            sb.AppendLine("     , max(a.CUST_NAME1) as CUST_NAME1 ");
            sb.AppendLine("     , max(a.MAN_CODE1) as MAN_CODE1 ");
            sb.AppendLine("     , max(a.MAN_NAME1) as MAN_NAME1 ");
            sb.AppendLine("     , max(a.STOCK_AMOUNT) as STOCK_AMOUNT ");
            sb.AppendLine("     , max(a.STOCK_VAT) as STOCK_VAT ");
            //sb.AppendLine("     , case when isnull(max(a.STOCK_LAST1), '0') = '1' then 'Y' else '' end as STOCK_LAST1 ");
            //sb.AppendLine("     , replace(max(a.TAX_DATE), '/', '-') as TAX_DATE ");
            sb.AppendLine(" from PRODUCT_STORE a ");
            sb.AppendLine(" where 1=1 ");
            sb.AppendLine("     " + condition + " ");
            sb.AppendLine(" group by a.STOCK_DATE, a.STOCK_NUM ");
            sb.AppendLine(" order by a.STOCK_DATE asc, a.STOCK_NUM asc ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_PRODUCT_STORE_Detail(string sDay, string sNum)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("     a.* ");
            sb.AppendLine("     , isnull(b.할인율, 0) as 계약율 ");
            sb.AppendLine("     , isnull(c.EMAIL, '') as EMAIL ");
            sb.AppendLine("     , c.DEAL_KIND ");
            sb.AppendLine("     , isnull(c.특매처, 0) as 특매처 ");
            sb.AppendLine(" from PRODUCT_STORE a ");
            sb.AppendLine("     left outer join CUST_DISCOUNT b on b.거래처코드 = a.CUST_CODE1 and b.제품코드 = a.STOCK_CODE ");
            sb.AppendLine("     left outer join CUSTOMER c on c.CUST_CODE = a.CUST_CODE1 ");
            sb.AppendLine(" where 1=1 ");
            sb.AppendLine("     and a.STOCK_DATE = @p_1  ");
            sb.AppendLine("     and a.STOCK_NUM = @p_2  ");
            sb.AppendLine(" order by a.STOCK_ILNUM asc ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            sCommand.Parameters.AddWithValue("@p_1", sDay);
            sCommand.Parameters.AddWithValue("@p_2", sNum);
            return wAdo.SqlCommandSelect(sCommand);
        }




        public DataTable fn_PRODUCT_STOCK_List(string sDay1, string sDay2, string sCust)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("     a.* ");
            sb.AppendLine(" from PRODUCT_STOCK a ");
            sb.AppendLine(" where 1=1 ");
            sb.AppendLine("     and a.STOCK_DATE >= @p_1 ");
            sb.AppendLine("     and a.STOCK_DATE <= @p_2 ");
            if (sCust != "")
            {
                sb.AppendLine("     and a.CUST_CODE1 = '" + sCust + "' ");
            }
            sb.AppendLine(" order by a.STOCK_DATE asc, a.STOCK_NUM asc ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            sCommand.Parameters.AddWithValue("@p_1", sDay1);
            sCommand.Parameters.AddWithValue("@p_2", sDay2);
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_거래처잔고_Summary(string sCust, string sDay)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(" select sum(z.전월잔고) as 현잔고 ");
            sb.AppendLine(" from ( ");

            sb.AppendLine(" select isnull(SUM(MAN_PREAMOUNT), 0) as 전월잔고 ");
            sb.AppendLine(" from CUST_YEARMMAMOUNT  ");
            sb.AppendLine(" where CUST_CODE = @p_1 ");
            sb.AppendLine("     and JAN_YEARMM = @pYM ");

            sb.AppendLine(" union all ");

            sb.AppendLine(" select isnull(SUM(STOCK_AMOUNT), 0) - isnull(SUM(STOCK_VAT), 0) as 판매액계 ");
            sb.AppendLine(" from PRODUCT_STOCK  ");
            sb.AppendLine(" where CUST_CODE1 = @p_1 ");
            sb.AppendLine("     and STOCK_DATE >= @p_from ");
            sb.AppendLine("     and STOCK_DATE <= @p_to ");

            sb.AppendLine(" union all ");

            sb.AppendLine(" select -1 * isnull(SUM(COLLECT_AMOUNT), 0) as 수금액계 ");
            sb.AppendLine(" from PRODUCT_COLLECT  ");
            sb.AppendLine(" where CUST_CODE1 = @p_1 ");
            sb.AppendLine("     and COLLECT_DATE >= @p_from ");
            sb.AppendLine("     and COLLECT_DATE <= @p_to ");

            sb.AppendLine(" ) z ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            sCommand.Parameters.AddWithValue("@p_1", sCust);
            sCommand.Parameters.AddWithValue("@pYM", sDay.Substring(0, 7));
            sCommand.Parameters.AddWithValue("@p_from", sDay.Substring(0, 7) + "-01");
            sCommand.Parameters.AddWithValue("@p_to", sDay);
            return wAdo.SqlCommandSelect(sCommand);
        }


        public DataTable fn_PRODUCT_STOCK_Detail(string sDay, string sNum)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("     a.* ");
            sb.AppendLine("     , isnull(b.할인율, 0) as 계약율 ");
            sb.AppendLine("     , isnull(c.EMAIL, '') as EMAIL ");
            sb.AppendLine("     , c.DEAL_KIND ");
            sb.AppendLine("     , isnull(c.특매처, 0) as 특매처 ");
            sb.AppendLine(" from PRODUCT_STOCK a ");
            sb.AppendLine("     left outer join CUST_DISCOUNT b on b.거래처코드 = a.CUST_CODE1 and b.제품코드 = a.STOCK_CODE ");
            sb.AppendLine("     left outer join CUSTOMER c on c.CUST_CODE = a.CUST_CODE1 ");
            sb.AppendLine(" where 1=1 ");
            sb.AppendLine("     and a.STOCK_DATE = @p_1  ");
            sb.AppendLine("     and a.STOCK_NUM = @p_2  ");
            sb.AppendLine(" order by a.STOCK_ILNUM asc ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            sCommand.Parameters.AddWithValue("@p_1", sDay);
            sCommand.Parameters.AddWithValue("@p_2", sNum);
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_PRODUCT_STOCK_List(string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("     a.STOCK_DATE ");
            sb.AppendLine("     , a.STOCK_NUM ");
            sb.AppendLine("     , max(a.STOCK_KIND) as STOCK_KIND ");
            sb.AppendLine("     , max(a.CUST_CODE1) as CUST_CODE1 ");
            sb.AppendLine("     , max(a.CUST_NAME1) as CUST_NAME1 ");
            sb.AppendLine("     , max(a.MAN_CODE1) as MAN_CODE1 ");
            sb.AppendLine("     , max(a.MAN_NAME1) as MAN_NAME1 ");
            sb.AppendLine("     , replace(max(a.TAX_DATE), '/', '-') as TAX_DATE ");
            sb.AppendLine(" from PRODUCT_STOCK a ");
            sb.AppendLine(" where 1=1 ");
            sb.AppendLine("     " + condition + " ");
            sb.AppendLine(" group by a.STOCK_DATE, a.STOCK_NUM ");
            sb.AppendLine(" order by a.STOCK_DATE asc, a.STOCK_NUM asc ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_PRODUCT_COLLECT_DEPT_List(string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("     a.COLLECT_DATE ");
            sb.AppendLine("     , a.COLLECT_NUM ");
            sb.AppendLine("     , a.COLLECT_KIND ");
            sb.AppendLine("     , a.CUST_CODE1 ");
            sb.AppendLine("     , a.CUST_NAME1 ");
            sb.AppendLine("     , a.REP_NAME1 ");
            sb.AppendLine("     , a.COMP_NUM1 ");
            sb.AppendLine("     , a.MAN_CODE1 ");
            sb.AppendLine("     , a.MAN_NAME1 ");
            sb.AppendLine("     , a.COLLECT_AMOUNT ");
            sb.AppendLine("     , a.BILL_NUMBER ");
            sb.AppendLine("     , isnull(a.COLLECT_LAST, '0') as COLLECT_LAST ");
            sb.AppendLine("     , case when isnull(a.COLLECT_LAST, '0') = '1' then 'Y' else '' end as COLLECT_LAST2 ");
            sb.AppendLine("     , replace(a.TAX_DATE, '/', '-') as TAX_DATE ");
            sb.AppendLine("     , a.KIND_AB ");
            sb.AppendLine(" from PRODUCT_COLLECT_DEPT a ");
            sb.AppendLine(" where 1=1 ");
            sb.AppendLine("     " + condition + " ");
            sb.AppendLine(" order by a.COLLECT_DATE asc, a.COLLECT_NUM asc ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_PRODUCT_COLLECT_DEPT_Detail(string sDay, string sNum)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("     a.* ");
            sb.AppendLine("     , isnull(c.EMAIL, '') as EMAIL ");
            sb.AppendLine("     , c.DEAL_KIND ");
            sb.AppendLine("     , isnull(c.특매처, 0) as 특매처 ");
            sb.AppendLine(" from PRODUCT_COLLECT_DEPT a ");
            sb.AppendLine("     left outer join CUSTOMER c on c.CUST_CODE = a.CUST_CODE1 ");
            sb.AppendLine(" where 1=1 ");
            sb.AppendLine("     and a.COLLECT_DATE = @p_1  ");
            sb.AppendLine("     and a.COLLECT_NUM = @p_2  ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            sCommand.Parameters.AddWithValue("@p_1", sDay);
            sCommand.Parameters.AddWithValue("@p_2", sNum);
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_PRODUCT_COLLECT_List(string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("     a.* ");
            sb.AppendLine(" from PRODUCT_COLLECT a ");
            sb.AppendLine(" where 1=1 ");
            sb.AppendLine("     " + condition + " ");
            sb.AppendLine(" order by a.COLLECT_DATE asc, a.COLLECT_NUM asc ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_PRODUCT_COLLECT_Detail(string sDay, string sNum)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("     a.* ");
            sb.AppendLine("     , isnull(c.EMAIL, '') as EMAIL ");
            sb.AppendLine("     , c.DEAL_KIND ");
            sb.AppendLine("     , isnull(c.특매처, 0) as 특매처 ");
            sb.AppendLine(" from PRODUCT_COLLECT a ");
            sb.AppendLine("     left outer join CUSTOMER c on c.CUST_CODE = a.CUST_CODE1 ");
            sb.AppendLine(" where 1=1 ");
            sb.AppendLine("     and a.COLLECT_DATE = @p_1  ");
            sb.AppendLine("     and a.COLLECT_NUM = @p_2  ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            sCommand.Parameters.AddWithValue("@p_1", sDay);
            sCommand.Parameters.AddWithValue("@p_2", sNum);
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_PRODUCT_RETURN_List(string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("     a.반품일자 ");
            sb.AppendLine("     , a.반품번호 ");
            sb.AppendLine("     , max(a.구분) as 구분 ");
            sb.AppendLine("     , max(a.거래처코드) as 거래처코드 ");
            sb.AppendLine("     , max(a.거래처명) as 거래처명 ");
            sb.AppendLine("     , max(a.담당자코드) as 담당자코드 ");
            sb.AppendLine("     , max(a.담당자명) as 담당자명 ");
            sb.AppendLine("     , isnull(min(a.창고확인), '미확인') as 창고확인 ");
            sb.AppendLine("     , isnull(min(a.관리부확인), '미확인') as 관리부확인 ");
            sb.AppendLine("     , isnull(convert(nvarchar(10), max(a.주문일자), 120), '') as 주문일자 ");
            sb.AppendLine("     , isnull(max(a.주문번호), '') as 주문번호 ");
            sb.AppendLine(" from PRODUCT_RETURN a ");
            sb.AppendLine(" where 1=1 ");
            sb.AppendLine("     " + condition + " ");
            sb.AppendLine(" group by a.반품일자, a.반품번호 ");
            sb.AppendLine(" order by a.반품일자 asc, a.반품번호 asc ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_PRODUCT_RETURN_Detail(string sDay, string sNum)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("     a.* ");
            sb.AppendLine("     , isnull(b.할인율, 0) as 계약율 ");
            sb.AppendLine("     , isnull(c.EMAIL, '') as EMAIL ");
            sb.AppendLine("     , c.DEAL_KIND ");
            sb.AppendLine("     , isnull(c.특매처, 0) as 특매처 ");
            sb.AppendLine("     , isnull(p.PRODUCT_NAME, '') as 제품명확인 ");
            sb.AppendLine(" from PRODUCT_RETURN a ");
            sb.AppendLine("     left outer join CUST_DISCOUNT b on b.거래처코드 = a.거래처코드 and b.제품코드 = a.제품코드 ");
            sb.AppendLine("     left outer join CUSTOMER c on c.CUST_CODE = a.거래처코드 ");
            sb.AppendLine("     left outer join PRODUCT p on p.PRODUCT_CODE = a.제품코드 ");
            sb.AppendLine(" where 1=1 ");
            sb.AppendLine("     and a.반품일자 = @p_1  ");
            sb.AppendLine("     and a.반품번호 = @p_2  ");
            sb.AppendLine(" order by a.순서 asc ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            sCommand.Parameters.AddWithValue("@p_1", sDay);
            sCommand.Parameters.AddWithValue("@p_2", sNum);
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_ZIPCODE_N15_List_pop(string condition, int pageSize, int skipSize)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select TOP " + pageSize.ToString() + " ");
            sb.AppendLine("     a.우편번호 as 우편번호 ");
            sb.AppendLine("     , a.ZIP_AREA as 검색주소 ");
            sb.AppendLine(" from ZIPCODE_N15 a ");
            sb.AppendLine(" where 1=1 ");
            sb.AppendLine("     " + condition + " ");
            sb.AppendLine("     and a.SEQ not in (select TOP " + skipSize.ToString() + " a.SEQ ");
            sb.AppendLine("                                 from ZIPCODE_N15 a ");
            sb.AppendLine("                                 where 1=1 ");
            sb.AppendLine("                                     " + condition + " ");
            sb.AppendLine("                             ) ");
            sb.AppendLine(" order by a.ZIP_AREA asc ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_ZIPCODE_N15_List_Count(string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select count(*) as CNT ");
            sb.AppendLine(" from ZIPCODE_N15 a ");
            sb.AppendLine(" where 1=1 ");
            sb.AppendLine("     " + condition + " ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_ZIPCODE_NEW_List_pop(string condition, int pageSize, int skipSize)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select TOP " + pageSize.ToString() + " ");
            sb.AppendLine("     a.ZIP_CODE as 우편번호 ");
            sb.AppendLine("     , a.ZIP_AREA as 검색주소 ");
            sb.AppendLine(" from ZIPCODE_NEW a ");
            sb.AppendLine(" where 1=1 ");
            sb.AppendLine("     " + condition + " ");
            sb.AppendLine("     and a.ZIP_AREA not in (select TOP " + skipSize.ToString() + " a.ZIP_AREA ");
            sb.AppendLine("                                 from ZIPCODE_NEW a ");
            sb.AppendLine("                                 where 1=1 ");
            sb.AppendLine("                                     " + condition + " ");
            sb.AppendLine("                             ) ");
            sb.AppendLine(" order by a.ZIP_AREA asc ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_ZIPCODE_NEW_List_Count(string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select count(*) as CNT ");
            sb.AppendLine(" from ZIPCODE_NEW a ");
            sb.AppendLine(" where 1=1 ");
            sb.AppendLine("     " + condition + " ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_PRODUCT_List(string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("     a.* ");
            sb.AppendLine("     , b.CODE_DESC as 단위명 ");
            sb.AppendLine("     , c.CODE_DESC as 제품구분명 ");
            sb.AppendLine("     , d.CODE_DESC as 제형구분명 ");
            sb.AppendLine("     , e.CODE_DESC as 관리구분명 ");
            sb.AppendLine("     , case when isnull(a.TAX_KIND, '0') = '1' then '해당' else '비해당' end as 특소세명 ");
            sb.AppendLine(" from PRODUCT a ");
            sb.AppendLine("     left outer join UNITCODE b on b.UNIT_CODE = a.UNIT_CODE ");
            sb.AppendLine("     left outer join PRODUCTKIND c on c.PRODUCT_KIND = a.PRODUCT_KIND ");
            sb.AppendLine("     left outer join PRODUCTTYPE d on d.PRODUCT_TYPE = a.PRODUCT_TYPE ");
            sb.AppendLine("     left outer join PRODUCTCLASS e on e.PRODUCT_CLASS = a.PRODUCT_CLASS ");
            sb.AppendLine(" where 1=1 ");
            sb.AppendLine("     " + condition + " ");
            sb.AppendLine(" order by a.PRODUCT_CODE asc ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_PRODUCT_Detail(string sID)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("     a.* ");
            //sb.AppendLine("     , b.AreaName ");
            sb.AppendLine(" from PRODUCT a ");
            //sb.AppendLine("     left outer join T_Area b on b.AreaCode = a.AreaCode ");
            sb.AppendLine(" where 1=1 ");
            sb.AppendLine("     and a.PRODUCT_CODE = @p_1  ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            sCommand.Parameters.AddWithValue("@p_1", sID);
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_CUST_DISCOUNT_List(string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("     a.* ");
            sb.AppendLine("     , b.CODE_DESC as 담당자명 ");
            sb.AppendLine(" from CUSTOMER a ");
            sb.AppendLine("     left outer join MANCODE b on b.MAN_CODE = a.MAN_CODE ");
            sb.AppendLine(" where 1=1 ");
            sb.AppendLine("     " + condition + " ");
            sb.AppendLine("     and a.CUST_CODE in (select distinct 거래처코드 from CUST_DISCOUNT) ");
            sb.AppendLine(" order by a.CUST_CODE asc ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_CUST_DISCOUNT_Detail(string sID)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("     a.* ");
            sb.AppendLine("     , c.REP_NAME ");
            sb.AppendLine("     , c.COMP_NUM ");
            sb.AppendLine("     , c.MAN_CODE ");
            sb.AppendLine("     , b.CODE_DESC as 담당자명 ");
            sb.AppendLine(" from CUST_DISCOUNT a ");
            sb.AppendLine("     left outer join CUSTOMER c on c.CUST_CODE = a.거래처코드 ");
            sb.AppendLine("     left outer join MANCODE b on b.MAN_CODE = c.MAN_CODE ");
            sb.AppendLine(" where 1=1 ");
            sb.AppendLine("     and a.거래처코드 = @p_1  ");
            sb.AppendLine(" order by a.거래처코드 asc, a.제품코드 asc ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            sCommand.Parameters.AddWithValue("@p_1", sID);
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_STOCK_GOAL_List(string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("     a.* ");
            sb.AppendLine("     , case when a.GOAL_CODE = '1' then '판매' ");
            sb.AppendLine("             when a.GOAL_CODE = '2' then '수금' ");
            sb.AppendLine("             else '현금' end as 구분명 ");
            sb.AppendLine("     , b.CODE_DESC as 담당자명 ");
            sb.AppendLine(" from STOCK_GOAL a ");
            sb.AppendLine("     left outer join MANCODE b on b.MAN_CODE = a.MAN_CODE ");
            sb.AppendLine(" where 1=1 ");
            sb.AppendLine("     " + condition + " ");
            sb.AppendLine(" order by a.GOAL_YEAR asc, a.MAN_CODE asc, a.GOAL_CODE asc ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_STOCK_GOAL_Detail(string sYYYY, string sGubun, string sMan)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("     a.* ");
            sb.AppendLine("     , b.CODE_DESC as 담당자명 ");
            sb.AppendLine(" from STOCK_GOAL a ");
            sb.AppendLine("     left outer join MANCODE b on b.MAN_CODE = a.MAN_CODE ");
            sb.AppendLine(" where 1=1 ");
            sb.AppendLine("     and a.GOAL_YEAR = @p_1  ");
            sb.AppendLine("     and a.GOAL_CODE = @p_2  ");
            sb.AppendLine("     and a.MAN_CODE = @p_3  ");
            sb.AppendLine(" order by a.GOAL_YEAR asc, a.MAN_CODE asc, a.GOAL_CODE asc ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            sCommand.Parameters.AddWithValue("@p_1", sYYYY);
            sCommand.Parameters.AddWithValue("@p_2", sGubun);
            sCommand.Parameters.AddWithValue("@p_3", sMan);
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_PRODUCT_STOCK_Magam(string sDay1, string sDay2, string sCust)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select a.CUST_CODE1, max(CUST_NAME1) as CUST_NAME1 ");
            sb.AppendLine(" from PRODUCT_STOCK a ");
            sb.AppendLine(" where 1=1 ");
            sb.AppendLine("     and a.STOCK_DATE >= @p_1  ");
            sb.AppendLine("     and a.STOCK_DATE <= @p_2  ");
            sb.AppendLine("     and a.퍼센트마감 = 'N' ");
            sb.AppendLine("     and isnull(a.할인율, 0) <> 0 ");
            if (sCust != "")
            {
                sb.AppendLine("     and a.CUST_CODE1 = '" + sCust + "' ");
            }
            sb.AppendLine(" group by a.CUST_CODE1 ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            sCommand.Parameters.AddWithValue("@p_1", sDay1);
            sCommand.Parameters.AddWithValue("@p_2", sDay2);
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_CUSTOMER_PRE_List(string condition, int pageSize, int skipSize)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select TOP " + pageSize.ToString() + " ");
            sb.AppendLine("     a.* ");
            //sb.AppendLine("     , b.AreaName ");
            sb.AppendLine(" from CUSTOMER_PRE a ");
            //sb.AppendLine("     left outer join T_Area b on b.AreaCode = a.AreaCode ");
            sb.AppendLine(" where 1=1 ");
            sb.AppendLine("     " + condition + " ");
            sb.AppendLine("     and a.CUST_CODE not in (select TOP " + skipSize.ToString() + " a.CUST_CODE ");
            sb.AppendLine("                                 from CUSTOMER_PRE a ");
            sb.AppendLine("                                 where 1=1 ");
            sb.AppendLine("                                     " + condition + " ");
            sb.AppendLine("                             ) ");
            sb.AppendLine(" order by a.CUST_CODE asc ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_CUSTOMER_PRE_List_Count(string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select count(*) as CNT ");
            sb.AppendLine(" from CUSTOMER_PRE a ");
            sb.AppendLine(" where 1=1 ");
            sb.AppendLine("     " + condition + " ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_CUSTOMER_PRE_Detail(string sID)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("     a.* ");
            sb.AppendLine("     , b.CODE_DESC as 담당자명 ");
            sb.AppendLine("     , b.DEPT_CODE ");
            sb.AppendLine("     , d.CODE_DESC as 부서명 ");
            sb.AppendLine(" from CUSTOMER_PRE a ");
            sb.AppendLine("     left outer join MANCODE b on b.MAN_CODE = a.MAN_CODE ");
            sb.AppendLine("     left outer join DEPTCODE d on d.DEPT_CODE = b.DEPT_CODE ");
            sb.AppendLine(" where 1=1 ");
            sb.AppendLine("     and a.CUST_CODE = @p_1  ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            sCommand.Parameters.AddWithValue("@p_1", sID);
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_반품조회_List(string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("     a.* ");
            //sb.AppendLine("     , b.AreaName ");
            sb.AppendLine(" from PRODUCT_RETURN a ");
            //sb.AppendLine("     left outer join T_Area b on b.AreaCode = a.AreaCode ");
            sb.AppendLine(" where 1=1 ");
            sb.AppendLine("     " + condition + " ");
            sb.AppendLine(" order by a.반품일자 asc, a.반품번호 asc ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_LoginUser(string userId, string userPw, string sConn)
        {
            StringBuilder sb = new StringBuilder();
            //sb.AppendLine("select               ");
            //sb.AppendLine("     u.UserID        ");
            //sb.AppendLine("     , u.UserPW      ");
            //sb.AppendLine("     , u.UserName    ");
            //sb.AppendLine("     , isnull(u.AuthLevel, 9) AuthLevel  ");
            //sb.AppendLine("     , u.EmailAddr   ");
            //sb.AppendLine("     , u.ActiveYN    ");
            //sb.AppendLine(" from tbUser u       ");
            //sb.AppendLine(" where u.UserID = @wuId      ");
            //sb.AppendLine("     and u.UserPW = @wuPw    ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            sCommand.Parameters.AddWithValue("@wuId", userId);
            sCommand.Parameters.AddWithValue("@wuPw", userPw);
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_데이터베이스_List(string condition, string sConn)
        {
            StringBuilder sb = new StringBuilder();
            //sb.AppendLine("select               ");
            //sb.AppendLine("     a.*             ");
            //sb.AppendLine(" from T_데이터베이스 a ");
            //sb.AppendLine(" where 1=1 ");
            //sb.AppendLine(" " + condition + "   ");
            //sb.AppendLine(" order by a.디비순번 asc ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            //sCommand.Parameters.AddWithValue("@p_Level", userLevel);
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_데이터베이스_Detail(string p1, string sConn)
        {
            StringBuilder sb = new StringBuilder();
            //sb.AppendLine("select               ");
            //sb.AppendLine("     a.*             ");
            //sb.AppendLine(" from T_데이터베이스 a ");
            //sb.AppendLine(" where 1=1 ");
            //sb.AppendLine("     and a.디비순번 = @p_1 ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            sCommand.Parameters.AddWithValue("@p_1", p1);
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable root_업체정보_List(string condition, string sConn)
        {
            StringBuilder sb = new StringBuilder();
            //sb.AppendLine("select a.* ");
            //sb.AppendLine("     , substring(a.사업자번호, 1, 3) + '-' + substring(a.사업자번호, 4, 2) + '-' + substring(a.사업자번호, 6, 5) as V사업자번호 ");
            //sb.AppendLine(" from T_업체정보 a   ");
            //sb.AppendLine(" where 1=1 ");
            //sb.AppendLine(" " + condition + "   ");
            //sb.AppendLine(" order by a.상호명 asc ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable root_업체정보_Detail(string p1, string sConn)
        {
            StringBuilder sb = new StringBuilder();
            //sb.AppendLine("select a.* ");
            //sb.AppendLine("     , s.명칭 as 수량등록방식 ");
            //sb.AppendLine("     , db.디비주소 ");
            //sb.AppendLine("     , db.디비명 ");
            //sb.AppendLine("     , db.디비계정 ");
            //sb.AppendLine("     , db.디비암호 ");
            //sb.AppendLine(" from T_업체정보 a   ");
            //sb.AppendLine("      left outer join C_수량등록방식 s on s.코드 = a.수량등록방식코드 ");
            //sb.AppendLine("      left outer join T_데이터베이스 db on db.디비순번 = a.디비순번 ");
            //sb.AppendLine(" where 1=1 ");
            //sb.AppendLine("     and a.사업자번호 = @p_1 ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            sCommand.Parameters.AddWithValue("@p_1", p1);
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_업체정보_Detail(string sConn)
        {
            StringBuilder sb = new StringBuilder();
            //sb.AppendLine("select a.* ");
            //sb.AppendLine("     , substring(a.사업자번호, 1, 3) + '-' + substring(a.사업자번호, 4, 2) + '-' + substring(a.사업자번호, 6, 5) as 사업자번호2 ");
            ////sb.AppendLine("     , t.명칭 as 전화번호지역 ");
            ////sb.AppendLine("     , t2.명칭 as 담당자번호통신사 ");
            //sb.AppendLine(" from T_업체정보 a   ");
            //////sb.AppendLine("      left outer join C_전화지역 t on t.코드 = a.전화번호코드 ");
            //////sb.AppendLine("      left outer join C_폰통신사 t2 on t2.코드 = a.담당자번호코드 ");
            ////sb.AppendLine(" where a.사업자번호 = '" + Common.p_strCompID + "' ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_업체자기정보_Check(string condition, string sConn)
        {
            StringBuilder sb = new StringBuilder();
            //sb.AppendLine("select               ");
            //sb.AppendLine("     a.사업자번호    ");
            //sb.AppendLine("     , a.상호명      ");
            //sb.AppendLine("     , a.대표자      ");
            //sb.AppendLine("     , a.업태        ");
            //sb.AppendLine("     , a.종목        ");
            //sb.AppendLine("     , a.계좌순번    ");
            //sb.AppendLine("     , a.사용여부    ");
            //sb.AppendLine(" from T_업체정보 a   ");
            ////sb.AppendLine(" where a.사업자번호 = '" + Common.p_strCompID + "' ");
            //sb.AppendLine(" " + condition + "   ");
            //sb.AppendLine(" order by a.사업자번호 asc ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            //sCommand.Parameters.AddWithValue("@p_Level", userLevel);
            return wAdo.SqlCommandSelect(sCommand);
        }



        // *********************************************************

        public DataTable fn_Staff_List(string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select A.STAFF_CD");
            sb.AppendLine(" ,A.STAFF_NM");
            sb.AppendLine(" ,A.JOIN_DATE");
            sb.AppendLine(" ,A.CALL_NUM");
            sb.AppendLine(" ,A.PHONE_NUM");
            sb.AppendLine(" ,A.DEPT_CD");
            sb.AppendLine(" ,(SELECT DEPT_NM FROM N_DEPT_CODE WHERE DEPT_CD = A.DEPT_CD) AS DEPT_NM");
            sb.AppendLine(" ,A.POS_CD");
            sb.AppendLine(" ,(SELECT POS_NM FROM N_POS_CODE WHERE POS_CD = A.POS_CD) AS POS_NM");
            sb.AppendLine(" ,A.STORAGE_CD");
            sb.AppendLine(" ,(SELECT STORAGE_NM FROM N_STORAGE_CODE WHERE STORAGE_CD = A.STORAGE_CD) AS STORAGE_NM");
            sb.AppendLine(" ,A.LOGIN_ID");
            sb.AppendLine(" ,A.PW");
            sb.AppendLine(" ,A.AUTH_SET");
            sb.AppendLine(" ,A.JOIN_DATE");
            sb.AppendLine(" ,A.COMMENT");
            sb.AppendLine(" from N_STAFF_CODE A ");
            sb.AppendLine(condition);
            sb.AppendLine(" order by CAST(A.STAFF_CD as int) ");


            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_Dept_List()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select DEPT_CD,DEPT_NM,COMMENT");
            sb.AppendLine(" from N_DEPT_CODE ");
            sb.AppendLine(" order by CAST(DEPT_CD as int) ");


            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_Pos_List()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select POS_CD,POS_NM,COMMENT");
            sb.AppendLine(" from N_POS_CODE ");
            sb.AppendLine(" order by CAST(POS_CD as int)  ");


            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_Stor_List()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("select STORAGE_CD,STORAGE_NM,COMMENT");
            sb.AppendLine(" from N_STORAGE_CODE ");
            sb.AppendLine(" order by CAST(STORAGE_CD as int) ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            return wAdo.SqlCommandSelect(sCommand);
        }


        public DataTable fn_Type_List()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select TYPE_CD,TYPE_NM,POOR_TYPE_YN,COMMENT");
            sb.AppendLine(" from N_TYPE_CODE ");
            sb.AppendLine(" order by TYPE_CD ");


            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_Unit_List()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select UNIT_CD,UNIT_NM,COMMENT");
            sb.AppendLine(" from N_UNIT_CODE ");
            sb.AppendLine(" order by UNIT_CD ");


            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_Line_List()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select LINE_CD,LINE_NM,COMMENT");
            sb.AppendLine(" from N_LINE_CODE ");
            sb.AppendLine(" order by LINE_CD ");


            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_Flow_List(string condition)
        {
            StringBuilder sb = new StringBuilder();
            //sb.AppendLine("select A.FLOW_CD");
            //sb.AppendLine(" , A.FLOW_NM");
            //sb.AppendLine(" , A.STORAGE_CD");
            //sb.AppendLine(" , (SELECT STORAGE_NM FROM N_STORAGE_CODE WHERE STORAGE_CD = A.STORAGE_CD) AS STORAGE_NM");
            //sb.AppendLine(" , FLOW_INSERT_YN ");
            //sb.AppendLine(" , ITEM_IDEN_YN ");
            //sb.AppendLine(" , FLOW_CHK_YN ");
            //sb.AppendLine(" , TEMP_TIME_YN ");
            //sb.AppendLine(" , MOLD_YN ");
            //sb.AppendLine(" , POOR_TYPE_CD ");
            //sb.AppendLine(" , (SELECT TYPE_NM FROM N_TYPE_CODE WHERE TYPE_CD = A.POOR_TYPE_CD) AS POOR_TYPE_NM ");
            //sb.AppendLine(" , STAFF_YN ");
            //sb.AppendLine(" , STAFF_CD ");
            //sb.AppendLine(" , (SELECT STAFF_NM FROM N_STAFF_CODE WHERE STAFF_CD = A.STAFF_CD) AS STAFF_NM ");
            //sb.AppendLine(" , A.COMMENT");
            //sb.AppendLine(" from N_FLOW_CODE A ");
            //sb.AppendLine(condition);
            //sb.AppendLine(" order by A.FLOW_CD ");

            sb.AppendLine("select a.*,B.STORAGE_NM,C.STAFF_NM,d.TYPE_NM from N_FLOW_CODE as a  ");
            sb.AppendLine("left join N_STORAGE_CODE As B on B.STORAGE_CD=a.STORAGE_CD ");
            sb.AppendLine("left join N_STAFF_CODE As C on C.STAFF_CD=a.STAFF_CD ");
            sb.AppendLine("left join N_TYPE_CODE As D on D.POOR_TYPE_YN=a.POOR_TYPE_CD ");
            sb.AppendLine(condition);

            Debug.WriteLine(sb);
            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_Poor_List()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select A.POOR_CD");
            sb.AppendLine(" , A.POOR_NM");
            sb.AppendLine(" , A.TYPE_CD");
            sb.AppendLine(" , (select TYPE_NM from N_TYPE_CODE where TYPE_CD = A.TYPE_CD) AS TYPE_NM ");
            sb.AppendLine(" , A.COMMENT");
            sb.AppendLine(" from N_POOR_CODE A ");
            sb.AppendLine(" order by POOR_CD ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_chk_List()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" select CHK_CD,CHK_NM,CHK_ORD,COMMENT,B.S_CODE_NM from  N_CHK_CODE as A");
            sb.AppendLine(" inner join [SM_FACTORY_COM].[dbo].[T_S_CODE] as B on B.S_CODE= A.CHK_GUBUN and B.L_CODE='600'");

            Debug.WriteLine(sb);
            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            return wAdo.SqlCommandSelect(sCommand);
        }
        public DataTable fn_query_Poor(string p_type_cd)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select A.POOR_CD as 코드");
            sb.AppendLine(" , A.POOR_NM as 명칭");
            sb.AppendLine(" from N_POOR_CODE A ");
            sb.AppendLine(" where 1=1 ");
            sb.AppendLine(" and TYPE_CD = '" + p_type_cd + "' ");
            sb.AppendLine(" order by POOR_CD ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_query_Type()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select A.TYPE_CD as 코드");
            sb.AppendLine(" , A.TYPE_NM as 명칭");
            sb.AppendLine(" from N_TYPE_CODE A ");
            sb.AppendLine(" where 1=1 ");
            sb.AppendLine(" and POOR_TYPE_YN = 'Y' ");
            sb.AppendLine(" order by TYPE_CD ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_query_com_code(string l_code)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("    select S_CODE as 코드 ");
            sb.AppendLine("        , S_CODE_NM as 명칭 ");
            sb.AppendLine("         from T_S_CODE ");
            sb.AppendLine("         where L_CODE = '" + l_code + "'");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_Raw_List(string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select RAW_MAT_CD");
            sb.AppendLine(" , RAW_MAT_NM");
            sb.AppendLine(" , SPEC");
            sb.AppendLine(" , RAW_MAT_GUBUN");
            sb.AppendLine(" , (select S_CODE_NM ");
            sb.AppendLine("    from [SM_FACTORY_COM].[dbo].[T_S_CODE] ");
            sb.AppendLine("    where L_CODE = '300' and S_CODE = A.RAW_MAT_GUBUN) AS RAW_MAT_GUBUN_NM ");
            //sb.AppendLine("     , case when RAW_MAT_GUBUN = '1' then '원재료' ");
            //sb.AppendLine("             when RAW_MAT_GUBUN = '2' then '부재료' ");
            //sb.AppendLine("             else '포장재료' end as RAW_MAT_GUBUN_NM ");
            sb.AppendLine(" , TYPE_CD ");
            sb.AppendLine(" , (select TYPE_NM from N_TYPE_CODE where TYPE_CD = A.TYPE_CD) AS TYPE_NM  ");
            sb.AppendLine(" , INPUT_UNIT ");
            sb.AppendLine(" , (select UNIT_NM from N_UNIT_CODE where UNIT_CD = A.INPUT_UNIT) AS INPUT_UNIT_NM  ");
            sb.AppendLine(" , OUTPUT_UNIT ");
            sb.AppendLine(" , (select UNIT_NM from N_UNIT_CODE where UNIT_CD = A.OUTPUT_UNIT) AS OUTPUT_UNIT_NM  ");
            sb.AppendLine(" , LINE_CD ");
            sb.AppendLine(" , CVR_RATIO ");
            sb.AppendLine(" , INPUT_PRICE ");
            sb.AppendLine(" , OUTPUT_PRICE ");
            sb.AppendLine(" , RAW_STORAGE ");
            sb.AppendLine(" , EX_STAN_QUALITY ");
            sb.AppendLine(" , USED_CD ");
            sb.AppendLine(" , CUST_CD ");
            sb.AppendLine(" , (select CUST_NM from N_CUST_CODE where CUST_CD = A.CUST_CD and CUST_GUBUN ='2') AS CUST_NM ");
            sb.AppendLine(" , BASIC_STOCK ");
            sb.AppendLine(" , CHECK_GUBUN ");
            sb.AppendLine(" , PART_NO ");
            sb.AppendLine(" , BAL_STOCK ");
            sb.AppendLine(" , COMMENT");
            sb.AppendLine(" from N_RAW_CODE A ");
            sb.AppendLine(condition);
            sb.AppendLine(" order by RAW_MAT_CD ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_Raw_Meat_List(string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select A.RAW_MAT_CD");
            sb.AppendLine(" , B.SEQ");
            sb.AppendLine(" , A.RAW_MAT_NM");
            sb.AppendLine(" , B.RAW_MAT_CD");
            sb.AppendLine(" , A.SPEC");
            sb.AppendLine(" , A.RAW_MAT_GUBUN");
            sb.AppendLine(" , (select S_CODE_NM ");
            sb.AppendLine("    from [SM_FACTORY_COM].[dbo].[T_S_CODE] ");
            sb.AppendLine("    where L_CODE = '300' and S_CODE = A.RAW_MAT_GUBUN) AS RAW_MAT_GUBUN_NM ");
            sb.AppendLine(" , A.TYPE_CD ");
            sb.AppendLine(" , (select TYPE_NM from N_TYPE_CODE where TYPE_CD = A.TYPE_CD) AS TYPE_NM  ");
            sb.AppendLine(" , A.INPUT_UNIT ");
            sb.AppendLine(" , (select UNIT_NM from N_UNIT_CODE where UNIT_CD = A.INPUT_UNIT) AS INPUT_UNIT_NM  ");
            sb.AppendLine(" , A.OUTPUT_UNIT ");
            sb.AppendLine(" , (select UNIT_NM from N_UNIT_CODE where UNIT_CD = A.OUTPUT_UNIT) AS OUTPUT_UNIT_NM  ");
            sb.AppendLine(" , A.CHECK_GUBUN   ");
            sb.AppendLine(" from N_RAW_CODE A ");
            sb.AppendLine(" left outer join N_RAW_MEAT_SOURCE B");
            sb.AppendLine(" ON A.RAW_MAT_CD = B.RAW_MAT_CD");
            sb.AppendLine(condition);
            sb.AppendLine(" order by B.SEQ ");

            Console.WriteLine(sb.ToString());

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            return wAdo.SqlCommandSelect(sCommand);
        }


        public DataTable fn_Raw_Chk_List(string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select A.RAW_MAT_CD");
            sb.AppendLine(" , A.RAW_MAT_NM");
            sb.AppendLine(" , A.SPEC");
            sb.AppendLine(" , A.RAW_MAT_GUBUN");
            sb.AppendLine(" , (select S_CODE_NM ");
            sb.AppendLine("    from [SM_FACTORY_COM].[dbo].[T_S_CODE] ");
            sb.AppendLine("    where L_CODE = '300' and S_CODE = A.RAW_MAT_GUBUN) AS RAW_MAT_GUBUN_NM ");
            sb.AppendLine(" , A.USED_CD ");
            sb.AppendLine(" , A.CUST_CD ");
            sb.AppendLine(" , A.BASIC_STOCK ");
            sb.AppendLine(" , A.PART_NO ");
            sb.AppendLine(" , B.CONTROL_NO "); //시험기준 외관
            sb.AppendLine(" , B.RAW_MAT_CD AS RAW_MAT_CHK");
            sb.AppendLine("  ,case when isnull(B.RAW_MAT_CD,'N')<>'N' then 'Y' else 'N' end RAW_MAT_YN"); //원자재수입검사 기준 있는지 체크 (RAW_MAT_CD가 NULL체크로 구별)
            sb.AppendLine(" , A.COMMENT");
            sb.AppendLine(" from N_RAW_CODE A ");
            sb.AppendLine(" left outer join N_RAW_CHK B ");
            sb.AppendLine(" on A.RAW_MAT_CD = B.RAW_MAT_CD ");
            sb.AppendLine(" where 1=1  and A.CHECK_GUBUN='1'");

            sb.AppendLine(condition);
            sb.AppendLine(" order by RAW_MAT_CD ");
            Debug.WriteLine(sb);
            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            return wAdo.SqlCommandSelect(sCommand);            
        }

        public DataTable fn_Half_List(string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" select A.ITEM_CD ");
            sb.AppendLine(" , A.ITEM_NM ");
            sb.AppendLine(" , (select S_CODE_NM ");
            sb.AppendLine("    from [SM_FACTORY_COM].[dbo].[T_S_CODE] ");
            sb.AppendLine("    where L_CODE = '400' and S_CODE = A.ITEM_GUBUN) AS ITEM_GUBUN_NM ");
            sb.AppendLine(" , A.SPEC");
            sb.AppendLine(" , A.UNIT_CD");
            sb.AppendLine(" , (select UNIT_NM from N_UNIT_CODE where UNIT_CD = A.UNIT_CD) AS INPUT_UNIT_NM ");
            sb.AppendLine(" ,A.TYPE_CD ");
            sb.AppendLine(" , (select TYPE_NM from N_TYPE_CODE where TYPE_CD = A.TYPE_CD) AS TYPE_NM  ");
            sb.AppendLine(" ,A.LINE_CD ");
            sb.AppendLine(" , (select LINE_NM from N_LINE_CODE where LINE_CD = A.LINE_CD) AS LINE_NM  ");
            sb.AppendLine(" ,A.UNIT_CD ");
            sb.AppendLine(" , (select UNIT_NM from N_UNIT_CODE where UNIT_CD = A.UNIT_CD) AS UNIT_NM  ");
            sb.AppendLine(" ,A.STOCK_LOC ");
            sb.AppendLine(" ,A.PROP_STOCK ");
            sb.AppendLine(" ,A.BAL_STOCK ");
            sb.AppendLine(" ,A.BASIC_STOCK ");
            sb.AppendLine(" ,FLOOR(INPUT_PRICE) AS INPUT_PRICE ");
            sb.AppendLine(" ,OUTPUT_PRICE ");
            sb.AppendLine(" ,A.CHARGE_AMT ");
            sb.AppendLine(" ,A.PACK_AMT ");
            sb.AppendLine(" ,A.USED_CD ");
            sb.AppendLine(" from N_ITEM_CODE A ");
            sb.AppendLine(" where A.ITEM_GUBUN = '2' ");
            sb.AppendLine(condition);
            sb.AppendLine(" order by ITEM_CD ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_Cust_List(string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select CUST_CD");
            sb.AppendLine("     ,CUST_GUBUN ");
            sb.AppendLine(" , (select S_CODE_NM ");
            sb.AppendLine("    from [SM_FACTORY_COM].[dbo].[T_S_CODE] ");
            sb.AppendLine("    where L_CODE = '200' and S_CODE = A.CUST_GUBUN) AS CUST_GUBUN_NM ");
            sb.AppendLine("     ,CUST_NM ");
            sb.AppendLine("     ,OWNER ");
            sb.AppendLine("     ,SAUP_NO ");
            sb.AppendLine("     ,UPTAE ");
            sb.AppendLine("     ,JONGMOK ");
            sb.AppendLine("     ,DEAL_TYPE ");
            sb.AppendLine("     ,POST_NO ");
            sb.AppendLine("     ,ADDR ");
            sb.AppendLine("     ,CUST_MANAGER ");
            sb.AppendLine("     ,CUST_EMAIL ");
            sb.AppendLine("     ,CUST_COMP_PHONE ");
            sb.AppendLine("     ,CUST_PHONE ");
            sb.AppendLine("     ,CUST_FAX ");
            sb.AppendLine("     ,CUST_OPEN ");
            sb.AppendLine("     ,STAFF_CD ");
            sb.AppendLine("     ,TAX_CD ");
            sb.AppendLine(" , (SELECT STAFF_NM FROM N_STAFF_CODE WHERE STAFF_CD = A.STAFF_CD) AS STAFF_NM ");
            sb.AppendLine("     ,USED_CD ");
            sb.AppendLine(" , (select S_CODE_NM ");
            sb.AppendLine("    from [SM_FACTORY_COM].[dbo].[T_S_CODE] ");
            sb.AppendLine("    where L_CODE = '500' and S_CODE = A.USED_CD) AS USED_NM ");
            sb.AppendLine("     ,COMMENT ");
            sb.AppendLine(" from N_CUST_CODE A ");
            sb.AppendLine(condition);
            sb.AppendLine(" order by CUST_CD ");

            Console.WriteLine(sb.ToString());


            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_Chk_List(string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select CHK_CD");
            sb.AppendLine("     ,CHK_GUBUN ");
            sb.AppendLine(" , (select S_CODE_NM ");
            sb.AppendLine("    from [SM_FACTORY_COM].[dbo].[T_S_CODE] ");
            sb.AppendLine("    where L_CODE = '600' and S_CODE = A.CHK_GUBUN) AS CHK_GUBUN_NM ");
            sb.AppendLine("     ,CHK_ORD ");
            sb.AppendLine("     ,CHK_NM ");
            sb.AppendLine("     ,COMMENT ");
            sb.AppendLine(" from N_CHK_CODE A ");
            sb.AppendLine(condition);
            sb.AppendLine(" order by CHK_GUBUN,CHK_ORD ");
            Console.WriteLine(sb.ToString());


            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_Item_List(string condition)
        {
            StringBuilder sb = new StringBuilder();




         

            sb.AppendLine("select ITEM_CD");
            sb.AppendLine("     ,ITEM_NM ");
            sb.AppendLine("     ,ITEM_GUBUN ");
            sb.AppendLine("     ,CUST_CD ");
            sb.AppendLine("     ,SPEC ");
            sb.AppendLine("     ,TYPE_CD ");
            sb.AppendLine("     , (select TYPE_NM from N_TYPE_CODE where TYPE_CD = A.TYPE_CD) AS TYPE_NM  ");
            sb.AppendLine("     ,LINE_CD ");
            sb.AppendLine("     , (select LINE_NM from N_LINE_CODE where LINE_CD = A.LINE_CD) AS LINE_NM  ");
            sb.AppendLine("     ,UNIT_CD ");
            sb.AppendLine("     , (select UNIT_NM from N_UNIT_CODE where UNIT_CD = A.UNIT_CD) AS UNIT_NM  ");
            sb.AppendLine("     ,STOCK_LOC ");
            sb.AppendLine("     ,PROP_STOCK ");
            sb.AppendLine("     ,BAL_STOCK ");
            sb.AppendLine("     ,BASIC_STOCK ");
            sb.AppendLine("     ,ITEM_WEIGHT ");
            sb.AppendLine("     ,FLOOR(INPUT_PRICE) AS INPUT_PRICE ");
            sb.AppendLine("     ,OUTPUT_PRICE ");
            sb.AppendLine("     ,CHARGE_AMT ");
            sb.AppendLine("     ,PACK_AMT ");
            sb.AppendLine("     ,PRINT_YN ");
            sb.AppendLine("     ,USED_CD ");
            sb.AppendLine("     ,INPUT_DATE ");
            sb.AppendLine("     ,BOX_BAR_CD ");
            sb.AppendLine("     ,BOX_AMT ");
            sb.AppendLine("     ,UNIT_BAR_CD ");
            sb.AppendLine("     ,UNIT_AMT ");
            sb.AppendLine("     ,VAT_CD ");
            sb.AppendLine("     ,COMMENT ");
            sb.AppendLine("     , (select S_CODE_NM ");
            sb.AppendLine("         from [SM_FACTORY_COM].[dbo].[T_S_CODE] ");
            sb.AppendLine("         where L_CODE = '400' and S_CODE = ITEM_GUBUN) AS ITEM_GUBUN_NM ");
            sb.AppendLine("     , (select COUNT(*) from N_ITEM_CHK where ITEM_CD = A.ITEM_CD) AS ITEM_CHK_YN ");
            sb.AppendLine("     ,LINK_CD ");
            sb.AppendLine(" from N_ITEM_CODE A ");
            sb.AppendLine(condition);
            sb.AppendLine(" order by ITEM_GUBUN,ITEM_CD");

            Debug.WriteLine("팝업 킨다 ");
            Debug.WriteLine(sb.ToString());



            SqlCommand sCommand = new SqlCommand(sb.ToString());


            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            return wAdo.SqlCommandSelect(sCommand);

        }


        //공정검사 항목 리스트 

        public DataTable fn_Flow_Chk_List(string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select A.ITEM_CD");
            sb.AppendLine("     ,C.ITEM_NM ");
            sb.AppendLine("     ,B.SEQ ");
            sb.AppendLine("     ,A.FLOW_CD ");
            sb.AppendLine("     ,D.FLOW_NM ");
            sb.AppendLine("     ,C.SPEC ");
            sb.AppendLine("     ,C.ITEM_GUBUN ");
            sb.AppendLine("     ,A.MEASURE_CNT ");
            sb.AppendLine("     ,A.EVA_GUBUN ");
            sb.AppendLine("     , (select S_CODE_NM ");
            sb.AppendLine("         from [SM_FACTORY_COM].[dbo].[T_S_CODE] ");
            sb.AppendLine("         where L_CODE = '400' and S_CODE = C.ITEM_GUBUN) AS ITEM_GUBUN_NM ");
            sb.AppendLine(" from N_FLOW_CHK A ");
            sb.AppendLine(" inner join N_ITEM_FLOW B ");
            sb.AppendLine(" on A.ITEM_CD = B.ITEM_CD ");
            sb.AppendLine("     and A.FLOW_CD = B.FLOW_CD ");
            sb.AppendLine(" inner join N_ITEM_CODE C ");
            sb.AppendLine(" on A.ITEM_CD = C.ITEM_CD ");
            sb.AppendLine(" inner join N_FLOW_CODE D ");
            sb.AppendLine(" on A.FLOW_CD = D.FLOW_CD ");
            sb.AppendLine(condition);
            sb.AppendLine(" order by A.ITEM_CD,B.SEQ");
            Debug.WriteLine("공정검사 항목 리스트");

            Debug.WriteLine(sb.ToString());

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_rC_List(string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select A.RAW_MAT_CD, D.SPEC, D.RAW_MAT_NM from N_RAW_CHK A INNER JOIN N_RAW_CODE D ON A.RAW_MAT_CD = D.RAW_MAT_CD ");           

            Debug.WriteLine(sb.ToString());

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            return wAdo.SqlCommandSelect(sCommand);
        }


        public DataTable fn_rChk_List(string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select			A.RAW_MAT_CD,			B.CHK_CD,			C.CHK_NM, ");
            sb.AppendLine("C.CHK_ORD,			C.CHK_GUBUN			,C.COMMENT	 ");
            sb.AppendLine(",D.SPEC, D.RAW_MAT_NM , A.CONTROL_NO , B.CHK_STAN_VALUE	 ");
            sb.AppendLine("from N_RAW_CHK A ");
            sb.AppendLine("INNER JOIN N_RAW_CHK_STAN B ON A.RAW_MAT_CD = B.RAW_MAT_CD ");
            sb.AppendLine("LEFT OUTER JOIN N_CHK_CODE C ON B.CHK_CD = C.CHK_CD     ");
            sb.AppendLine("INNER JOIN N_RAW_CODE D ON A.RAW_MAT_CD = D.RAW_MAT_CD     ");              

            Debug.WriteLine(sb.ToString());

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            return wAdo.SqlCommandSelect(sCommand);
        }

        // 제품 검사기준 상세 가져오기 
        public DataTable fn_Item_Chk_List(string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select A.ITEM_CD");
            sb.AppendLine("     ,C.ITEM_NM ");
            sb.AppendLine("     ,C.SPEC ");
            sb.AppendLine("     ,C.ITEM_GUBUN ");
            sb.AppendLine("     ,A.MEASURE_CNT ");
            sb.AppendLine("     ,A.EVA_GUBUN ");
            sb.AppendLine("     , (select S_CODE_NM ");
            sb.AppendLine("         from [SM_FACTORY_COM].[dbo].[T_S_CODE] ");
            sb.AppendLine("         where L_CODE = '400' and S_CODE = C.ITEM_GUBUN) AS ITEM_GUBUN_NM ");
            sb.AppendLine(" from N_ITEM_CHK A ");
            sb.AppendLine(" inner join N_ITEM_CODE C ");
            sb.AppendLine(" on A.ITEM_CD = C.ITEM_CD ");
            sb.AppendLine(condition);
            sb.AppendLine(" order by A.ITEM_CD");

            Debug.WriteLine("제품 검사기준 상세 가져오기 ");

            Debug.WriteLine(sb.ToString());
            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            return wAdo.SqlCommandSelect(sCommand);
        }


        public DataTable fn_Flow_Chk_Detail_List(string condition, int gbn)
        {
            StringBuilder sb = new StringBuilder();

            if (gbn == 1) //공정검사 대기 혹은 공정검사기준 목록 가져올 때 
            {
                sb.AppendLine("select A.ITEM_CD");
                sb.AppendLine("     ,A.FLOW_CD ");
                sb.AppendLine("     ,A.CHK_CD ");
                sb.AppendLine("     ,B.CHK_ORD ");
                sb.AppendLine("     ,B.CHK_NM ");
                sb.AppendLine("     ,A.EVA_GUBUN ");
                sb.AppendLine("     , (select S_CODE_NM ");
                sb.AppendLine("         from [SM_FACTORY_COM].[dbo].[T_S_CODE] ");
                sb.AppendLine("         where L_CODE = '620' and S_CODE = A.EVA_GUBUN) AS EVA_GUBUN_NM ");
                sb.AppendLine("     ,A.CHK_LOC ");
                sb.AppendLine("     ,A.RULE_SIZE ");
                sb.AppendLine("     ,A.RULE_LIMIT ");
                sb.AppendLine("     ,A.MEASURE_APP ");
                sb.AppendLine("     ,A.CHK_METHOD ");
                sb.AppendLine("     ,A.LOWER_SIZE ");
                sb.AppendLine("     ,A.UPPER_SIZE ");
                sb.AppendLine("     ,A.LOWER_SELF ");
                sb.AppendLine("     ,A.UPPER_SELF ");
                sb.AppendLine("         ,B.COMMENT ");
                sb.AppendLine(" from N_FLOW_CHK_STAN A  ");
                sb.AppendLine(" inner join N_CHK_CODE B ");
                sb.AppendLine(" on A.CHK_CD = B.CHK_CD ");
                sb.AppendLine("     and B.CHK_GUBUN = '1' ");
                sb.AppendLine(" inner join N_ITEM_CODE C ");
                sb.AppendLine(" on A.ITEM_CD = C.ITEM_CD ");
                sb.AppendLine(" inner join N_FLOW_CODE D ");
                sb.AppendLine(" on A.FLOW_CD = D.FLOW_CD ");
                sb.AppendLine(condition);
                sb.AppendLine(" order by B.CHK_ORD");
                Debug.WriteLine("//공정검사 대기 혹은 공정검사기준 목록 가져올 때 ");
            }
            else
            {
                sb.AppendLine("select A.ITEM_CD");
                sb.AppendLine("     ,A.FLOW_CD ");
                sb.AppendLine("     ,B.CHK_CD ");
                sb.AppendLine("     ,B.CHK_ORD ");
                sb.AppendLine("     ,D.CHK_NM ");
                sb.AppendLine("     ,C.EVA_GUBUN ");
                sb.AppendLine("     , (select S_CODE_NM ");
                sb.AppendLine("         from [SM_FACTORY_COM].[dbo].[T_S_CODE] ");
                sb.AppendLine("         where L_CODE = '620' and S_CODE = C.EVA_GUBUN) AS EVA_GUBUN_NM ");
                sb.AppendLine("     ,C.CHK_LOC ");
                sb.AppendLine("     ,C.RULE_SIZE ");
                sb.AppendLine("     ,C.RULE_LIMIT ");
                sb.AppendLine("     ,C.MEASURE_APP ");
                sb.AppendLine("     ,C.CHK_METHOD ");
                sb.AppendLine("     ,C.LOWER_SIZE ");
                sb.AppendLine("     ,C.UPPER_SIZE ");
                sb.AppendLine("     ,C.LOWER_SELF ");
                sb.AppendLine("     ,C.UPPER_SELF ");
                sb.AppendLine("     ,B.GRADE ");
                sb.AppendLine("         ,B.COMMENT ");
                sb.AppendLine(" from F_FLOW_CHK A  ");
                sb.AppendLine(" inner join F_FLOW_CHK_RST B ");
                sb.AppendLine(" on A.LOT_NO = B.LOT_NO ");
                sb.AppendLine("     and A.LOT_SUB = B.LOT_SUB ");
                sb.AppendLine("     and A.F_STEP = B.F_STEP ");
                sb.AppendLine(" inner join N_FLOW_CHK_STAN C ");
                sb.AppendLine(" on A.ITEM_CD = C.ITEM_CD ");
                sb.AppendLine(" and A.FLOW_CD = C.FLOW_CD ");
                sb.AppendLine(" and B.CHK_CD = C.CHK_CD ");
                sb.AppendLine(" inner join N_CHK_CODE D ");
                sb.AppendLine(" on B.CHK_CD = D.CHK_CD ");
                sb.AppendLine("     and D.CHK_GUBUN = '1' ");
                sb.AppendLine(condition);
                sb.AppendLine(" order by B.CHK_ORD");
            }
            Debug.WriteLine(sb);
            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_Item_Chk_Detail_List(string condition, int gbn)
        {
            StringBuilder sb = new StringBuilder();

            if (gbn == 1) //공정검사 대기 혹은 공정검사기준 목록 가져올 때 
            {
                sb.AppendLine("select A.ITEM_CD");
                sb.AppendLine("     ,A.CHK_CD ");
                sb.AppendLine("     ,B.CHK_ORD ");
                sb.AppendLine("     ,B.CHK_NM ");
                sb.AppendLine("     ,A.EVA_GUBUN ");
                sb.AppendLine("     , (select S_CODE_NM ");
                sb.AppendLine("         from [SM_FACTORY_COM].[dbo].[T_S_CODE] ");
                sb.AppendLine("         where L_CODE = '620' and S_CODE = A.EVA_GUBUN) AS EVA_GUBUN_NM ");
                sb.AppendLine("     ,A.CHK_LOC ");
                sb.AppendLine("     ,A.RULE_SIZE ");
                sb.AppendLine("     ,A.RULE_LIMIT ");
                sb.AppendLine("     ,A.MEASURE_APP ");
                sb.AppendLine("     ,A.CHK_INTERVAL ");
                sb.AppendLine("     ,A.LOWER_SIZE ");
                sb.AppendLine("     ,A.UPPER_SIZE ");
                sb.AppendLine("     ,A.LOWER_SELF ");
                sb.AppendLine("     ,A.UPPER_SELF ");
                sb.AppendLine(" from N_ITEM_CHK_STAN A  ");
                sb.AppendLine(" inner join N_CHK_CODE B ");
                sb.AppendLine(" on A.CHK_CD = B.CHK_CD ");
                sb.AppendLine("     and B.CHK_GUBUN = '2' ");
                sb.AppendLine(" inner join N_ITEM_CODE C ");
                sb.AppendLine(" on A.ITEM_CD = C.ITEM_CD ");
                sb.AppendLine(condition);
                sb.AppendLine(" order by B.CHK_ORD");
            }
            else
            {
                sb.AppendLine("select A.ITEM_CD");
                sb.AppendLine("     ,B.CHK_CD ");
                sb.AppendLine("     ,B.CHK_ORD ");
                sb.AppendLine("     ,D.CHK_NM ");
                sb.AppendLine("     ,C.EVA_GUBUN ");
                sb.AppendLine("     , (select S_CODE_NM ");
                sb.AppendLine("         from [SM_FACTORY_COM].[dbo].[T_S_CODE] ");
                sb.AppendLine("         where L_CODE = '620' and S_CODE = C.EVA_GUBUN) AS EVA_GUBUN_NM ");
                sb.AppendLine("     ,C.CHK_LOC ");
                sb.AppendLine("     ,C.RULE_SIZE ");
                sb.AppendLine("     ,C.RULE_LIMIT ");
                sb.AppendLine("     ,C.MEASURE_APP ");
                sb.AppendLine("     ,C.CHK_INTERVAL ");
                sb.AppendLine("     ,C.LOWER_SIZE ");
                sb.AppendLine("     ,C.UPPER_SIZE ");
                sb.AppendLine("     ,C.LOWER_SELF ");
                sb.AppendLine("     ,C.UPPER_SELF ");
                sb.AppendLine("     ,B.GRADE ");
                sb.AppendLine(" from F_ITEM_CHK A  ");
                sb.AppendLine(" inner join F_ITEM_CHK_RST B ");
                sb.AppendLine(" on A.LOT_NO = B.LOT_NO ");
                sb.AppendLine("     and A.LOT_SUB = B.LOT_SUB ");
                sb.AppendLine("     and A.F_STEP = B.F_STEP ");
                sb.AppendLine(" inner join N_ITEM_CHK_STAN C ");
                sb.AppendLine(" on A.ITEM_CD = C.ITEM_CD ");
                sb.AppendLine(" and B.CHK_CD = C.CHK_CD ");
                sb.AppendLine(" inner join N_CHK_CODE D ");
                sb.AppendLine(" on B.CHK_CD = D.CHK_CD ");
                sb.AppendLine("     and D.CHK_GUBUN = '2' ");
                sb.AppendLine(condition);
                sb.AppendLine(" order by B.CHK_ORD");
            }

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_Raw_Chk_Detail_List(string condition)
        {
            StringBuilder sb = new StringBuilder();                        

            sb.AppendLine(" order by B.CHK_ORD");
            sb.AppendLine("select A.RAW_MAT_CD");
            sb.AppendLine("     ,A.CHK_CD ");
            sb.AppendLine("     ,B.CHK_ORD ");
            sb.AppendLine("     ,B.CHK_NM ");
            sb.AppendLine("     ,A.CHK_STAN_VALUE ");
            sb.AppendLine(" from N_RAW_CHK_STAN A  ");
            sb.AppendLine(" inner join N_CHK_CODE B ");
            sb.AppendLine(" on A.CHK_CD = B.CHK_CD ");
            sb.AppendLine("     and B.CHK_GUBUN = '3' ");
            sb.AppendLine(condition);
            sb.AppendLine(" order by B.CHK_ORD");


            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_Flow_Chk_Exam_Value(string condition) //공정검사 성적서 
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("select A.CHK_VALUE");
            sb.AppendLine(" from F_FLOW_CHK_DETAIL A  ");
            sb.AppendLine("where 1=1 ");
            sb.AppendLine(condition);

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_Item_Chk_Exam_Value(string condition) //제품검사 성적서 
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("select A.CHK_VALUE");
            sb.AppendLine(" from F_ITEM_CHK_DETAIL A  ");
            sb.AppendLine("where 1=1 ");
            sb.AppendLine(condition);

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            return wAdo.SqlCommandSelect(sCommand);
        }
        public DataTable fn_Item_Comp_List(string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ITEM_CD");
            sb.AppendLine("     ,A.SEQ ");
            sb.AppendLine("     ,A.RAW_MAT_CD");
            sb.AppendLine("     ,B.RAW_MAT_NM");
            sb.AppendLine("     ,B.SPEC");
            sb.AppendLine("     ,B.INPUT_UNIT ");
            sb.AppendLine("     ,B.OUTPUT_UNIT ");
            sb.AppendLine("     ,(SELECT UNIT_NM FROM N_UNIT_CODE WHERE UNIT_CD = B.INPUT_UNIT) AS INPUT_UNIT_NM  ");
            sb.AppendLine("     ,(SELECT UNIT_NM FROM N_UNIT_CODE WHERE UNIT_CD = B.OUTPUT_UNIT) AS OUTPUT_UNIT_NM ");
            sb.AppendLine("     ,A.TOTAL_AMT ");
            sb.AppendLine(" from N_ITEM_COMP A ");
            sb.AppendLine(" LEFT OUTER JOIN N_RAW_CODE B ");
            sb.AppendLine(" ON A.RAW_MAT_CD = B.RAW_MAT_CD ");
            sb.AppendLine(condition);
            sb.AppendLine(" order by A.ITEM_CD ,A.SEQ");


            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_Item_Flow_List(string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ITEM_CD");
            sb.AppendLine("     ,A.SEQ ");
            sb.AppendLine("     ,A.FLOW_CD");
            sb.AppendLine("     ,B.FLOW_INSERT_YN");
            sb.AppendLine("     ,B.ITEM_IDEN_YN");
            //sb.AppendLine("     ,(SELECT FLOW_INSERT_YN FROM N_FLOW_CODE WHERE FLOW_CD = A.FLOW_CD)AS FLOW_INSERT_YN");
            sb.AppendLine("     ,A.COMMENT");
            sb.AppendLine("     ,B.FLOW_NM");
            sb.AppendLine("     ,C.TYPE_CD");
            sb.AppendLine(" from N_ITEM_FLOW A ");
            sb.AppendLine(" LEFT OUTER JOIN N_FLOW_CODE B ");
            sb.AppendLine(" ON A.FLOW_CD = B.FLOW_CD ");
            sb.AppendLine(" LEFT OUTER JOIN N_TYPE_CODE C  ");
            sb.AppendLine(" ON B.POOR_TYPE_CD = C.TYPE_CD ");
            //sb.AppendLine("     and C.POOR_TYPE_YN = 'Y' ");
            sb.AppendLine(condition);
            sb.AppendLine(" order by A.ITEM_CD,A.SEQ ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_Item_Half_List(string condition, double total_amt)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select A.ITEM_CD");
            sb.AppendLine("     ,A.SEQ ");
            sb.AppendLine("     ,A.HALF_ITEM_CD ");
            sb.AppendLine("     ,B.ITEM_NM AS HALF_ITEM_NM");
            sb.AppendLine("     ,B.UNIT_CD  ");
            sb.AppendLine("     ,(SELECT UNIT_NM FROM N_UNIT_CODE WHERE UNIT_CD = B.UNIT_CD) AS UNIT_NM   ");
            sb.AppendLine("     ,A.TOTAL_AMT as HALF_AMT ");
            sb.AppendLine("     ," + total_amt + " * A.TOTAL_AMT as TOTAL_AMT ");
            sb.AppendLine("     ,B.SPEC ");
            sb.AppendLine("     ,B.OUTPUT_PRICE AS PRICE ");
            sb.AppendLine(" from N_ITEM_COMP_HALF A  ");
            sb.AppendLine(" INNER JOIN N_ITEM_CODE B  ");
            sb.AppendLine(" ON A.HALF_ITEM_CD = B.ITEM_CD  ");
            sb.AppendLine(condition);
            sb.AppendLine(" order by A.ITEM_CD ");


            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_Fac_List(string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select FAC_CD");
            sb.AppendLine("     ,FAC_NM ");
            sb.AppendLine("     ,SPEC ");
            sb.AppendLine("     ,MODEL_NM ");
            sb.AppendLine("     ,MANU_COMPANY ");
            sb.AppendLine("     ,ACQ_DATE ");
            sb.AppendLine("     ,ACQ_PRICE ");
            sb.AppendLine("     ,A.DEPT_CD ");
            sb.AppendLine("     ,(SELECT DEPT_CD FROM N_DEPT_CODE WHERE DEPT_CD = A.DEPT_CD) AS DEPT_NM ");
            sb.AppendLine("     ,USED ");
            sb.AppendLine("     ,PRO_CAPA ");
            sb.AppendLine("     ,POWER_NUMBER ");
            sb.AppendLine("     ,MAINTEN_CLASS ");
            sb.AppendLine("     ,COMMENT ");
            sb.AppendLine(" from N_FAC_CODE A ");
            sb.AppendLine(condition);
            sb.AppendLine(" order by FAC_CD ");


            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            return wAdo.SqlCommandSelect(sCommand);
        }

        // 생산계획 등록 조회

        public DataTable fn_Plan_List(string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" select A.PLAN_DATE");
            sb.AppendLine("     ,A.PLAN_CD ");
            sb.AppendLine("     ,A.PLAN_NUM ");
            sb.AppendLine("     ,ISNULL(B.ITEM_CD,0) AS ITEM_CNT ");
            sb.AppendLine("     , a.CUST_CD  ");
            sb.AppendLine("      ,it.ITEM_NM   ");
            sb.AppendLine("        ,CASE WHEN ITEM_CNT>1 THEN it.ITEM_NM+' 외' +convert(nvarchar,ITEM_CNT-1) ELSE it.ITEM_NM END ITEM_CNT2     ");
            sb.AppendLine("     ,(select CUST_NM from N_CUST_CODE where CUST_GUBUN = '1' and CUST_CD = A.CUST_CD) as CUST_NM  ");
            sb.AppendLine("     ,DELIVER_REQ_DATE ");
            sb.AppendLine("       ,CASE WHEN ORDER_YN='Y' THEN '산출' ELSE '미산출' END ORDER_YN    ");
            sb.AppendLine("     ,a.COMMENT ");
            sb.AppendLine(" from F_PLAN A ");
            sb.AppendLine(" LEFT OUTER JOIN ( ");
            sb.AppendLine("  SELECT PLAN_DATE,PLAN_CD,COUNT(ITEM_CD) AS ITEM_cnt ,max(ITEM_CD) as ITEM_CD FROM F_PLAN_DETAIL  ");
            sb.AppendLine(" WHERE F_LEVEL = 1 ");
            sb.AppendLine(" GROUP BY PLAN_DATE,PLAN_CD) B ");
            sb.AppendLine("  ON A.PLAN_DATE = B.PLAN_DATE  ");
            sb.AppendLine(" AND A.PLAN_CD = B.PLAN_CD   ");
            sb.AppendLine("   left outer join N_ITEM_CODE  as it on it.ITEM_CD=B.ITEM_CD  ");
            sb.AppendLine(condition);
            sb.AppendLine("  order by A.PLAN_DATE desc, A.PLAN_CD desc ");
            Debug.WriteLine(sb);
            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            return wAdo.SqlCommandSelect(sCommand);
        }

        // 발주서 등록 조회

        public DataTable fn_Order_List(string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select A.ORDER_DATE");
            sb.AppendLine("     ,A.ORDER_CD ");
            sb.AppendLine("     ,ISNULL(B.RAW_MAT_CNT,0) AS RAW_MAT_CNT ");
            sb.AppendLine("     ,A.CUST_CD ");
            sb.AppendLine("     ,(select CUST_NM from N_CUST_CODE where CUST_GUBUN = '2' and CUST_CD = A.CUST_CD) as CUST_NM  ");
            sb.AppendLine("     ,A.INPUT_REQ_DATE ");
            sb.AppendLine("     ,A.COMPLETE_YN ");
            sb.AppendLine("     ,A.STAFF_CD ");
            sb.AppendLine("     ,(select STAFF_NM from N_STAFF_CODE where STAFF_NM = '" + Common.p_strUserName + "') as STAFF_NM ");
            sb.AppendLine("     ,COMMENT ");
            sb.AppendLine(" from F_ORDER A ");
            sb.AppendLine(" LEFT OUTER JOIN ( ");
            sb.AppendLine(" SELECT ORDER_DATE,ORDER_CD,COUNT(RAW_MAT_CD) AS RAW_MAT_CNT FROM F_ORDER_DETAIL ");
            sb.AppendLine(" GROUP BY ORDER_DATE,ORDER_CD) B ");
            sb.AppendLine(" ON A.ORDER_DATE = B.ORDER_DATE ");
            sb.AppendLine(" AND A.ORDER_CD = B.ORDER_CD  ");
            sb.AppendLine(condition);
            sb.AppendLine(" order by A.ORDER_DATE desc, A.ORDER_CD desc ");
            Debug.WriteLine("발주서 오더 리슽");
            Debug.WriteLine(sb.ToString());
            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            return wAdo.SqlCommandSelect(sCommand);

        }

        // 원자재 입고 등록 조회

        public DataTable fn_Rm_Input_List(string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select A.INPUT_DATE");
            sb.AppendLine("     ,A.INPUT_CD ");
            sb.AppendLine("     ,ISNULL(B.RAW_MAT_CNT,0) AS RAW_MAT_CNT ");
            sb.AppendLine("     ,A.CUST_CD ");
            sb.AppendLine("     ,(select CUST_NM from N_CUST_CODE where CUST_GUBUN = '2' and CUST_CD = A.CUST_CD) as CUST_NM  ");
            sb.AppendLine("     ,A.COMPLETE_YN ");
            sb.AppendLine("     ,A.INSTAFF ");
            sb.AppendLine("     ,(select STAFF_NM from N_STAFF_CODE where STAFF_CD = A.INSTAFF) as STAFF_NM ");
            sb.AppendLine("     ,COMMENT ");
            sb.AppendLine(" from F_RAW_INPUT A ");
            sb.AppendLine(" LEFT OUTER JOIN ( ");
            sb.AppendLine(" SELECT INPUT_DATE,INPUT_CD,COUNT(RAW_MAT_CD) AS RAW_MAT_CNT FROM F_RAW_DETAIL ");
            sb.AppendLine(" GROUP BY INPUT_DATE,INPUT_CD) B ");
            sb.AppendLine(" ON A.INPUT_DATE = B.INPUT_DATE ");
            sb.AppendLine(" AND A.INPUT_CD = B.INPUT_CD  ");
            sb.AppendLine(condition);
            sb.AppendLine(" order by A.INPUT_DATE desc, A.INPUT_CD desc ");
            Debug.WriteLine("원자재 인풋 리슽");
            Debug.WriteLine(sb.ToString());
            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            return wAdo.SqlCommandSelect(sCommand);

        }







        public DataTable fn_Plan_Detail_List(string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select A.PLAN_DATE");
            sb.AppendLine("     ,A.PLAN_CD ");
            sb.AppendLine("     ,A.SEQ ");
            sb.AppendLine("     ,A.ITEM_CD ");
            sb.AppendLine("     ,A.WORK_YN ");
            sb.AppendLine("     ,B.ITEM_NM  ");
            sb.AppendLine("     ,B.SPEC    ");
            sb.AppendLine("     ,A.UNIT_CD ");
            sb.AppendLine("     , (select UNIT_NM from N_UNIT_CODE where UNIT_CD = A.UNIT_CD) AS UNIT_NM  ");
            sb.AppendLine("     , A.TOTAL_AMT ");
            sb.AppendLine("     , A.PRICE ");
            sb.AppendLine("     , A.TOTAL_MONEY ");
            sb.AppendLine("     , A.F_LEVEL ");
            sb.AppendLine("     , A.TOP_ITEM_CD ");
            sb.AppendLine("     , (select ITEM_NM from N_ITEM_CODE where ITEM_CD = A.TOP_ITEM_CD) AS TOP_ITEM_NM");
            sb.AppendLine("     , A.P_ITEM_CD ");
            sb.AppendLine("     , (select ITEM_NM from N_ITEM_CODE where ITEM_CD = A.P_ITEM_CD) AS P_ITEM_NM ");
            sb.AppendLine("     , A.DEFAULT_AMT ");
            sb.AppendLine(" from F_PLAN_DETAIL A ");
            sb.AppendLine(" LEFT OUTER JOIN N_ITEM_CODE B ");
            sb.AppendLine(" ON A.ITEM_CD = B.ITEM_CD ");
            sb.AppendLine(condition);
            sb.AppendLine(" order by A.PLAN_DATE,A.PLAN_CD,A.F_LEVEL,A.SEQ ");

            Debug.WriteLine("플랜 디테일 리슽");
            Debug.WriteLine(sb.ToString());

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_Soyo_Result_List(string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SELECT U.RAW_MAT_CD");
            sb.AppendLine("     , K.RAW_MAT_NM ");
            sb.AppendLine("     , K.SPEC ");
            sb.AppendLine("     , U.TOTAL_AMT * K.CVR_RATIO AS TOTAL_AMT ");
            sb.AppendLine("     , ISNULL(K.BAL_STOCK,0) AS BAL_STOCK  ");
            sb.AppendLine("   , isnull(((U.TOTAL_AMT * K.CVR_RATIO)-K.BAL_STOCK),0) as RS_AMT      ");
            sb.AppendLine("     , K.INPUT_PRICE    ");
            sb.AppendLine("    , isnull(((U.TOTAL_AMT * K.CVR_RATIO)-K.BAL_STOCK) * K.INPUT_PRICE,0) AS TOTAL_MONEY   ");
            sb.AppendLine("     , K.OUTPUT_PRICE    ");
            sb.AppendLine("     , K.INPUT_UNIT ");
            sb.AppendLine("     , K.OUTPUT_UNIT ");
            sb.AppendLine("     , K.CUST_CD ");
            sb.AppendLine("     ,P.CUST_NM ");
            sb.AppendLine("     ,P.CUST_GUBUN ");
            sb.AppendLine("     ,DENSE_RANK() OVER(ORDER BY K.CUST_CD) AS CUST_NUM ");
            sb.AppendLine("     , (select S_CODE_NM ");
            sb.AppendLine("         from [SM_FACTORY_COM].[dbo].[T_S_CODE] ");
            sb.AppendLine("         where L_CODE = '200' and S_CODE = P.CUST_GUBUN) AS CUST_GUBUN_NM ");
            sb.AppendLine("     , (ISNULL(K.BAL_STOCK,0) - ISNULL(W.INST_RAW_AMT,0) * CVR_RATIO ) as REAL_AMT ");
            sb.AppendLine("     FROM ");
            sb.AppendLine("     ( ");
            sb.AppendLine("         select RAW_MAT_CD, SUM(TOTAL_AMT) AS TOTAL_AMT ");
            sb.AppendLine("         from ( ");
            sb.AppendLine("         select A.PLAN_DATE   ");
            sb.AppendLine("                 , A.PLAN_CD ");
            sb.AppendLine("                 , B.SEQ ");
            sb.AppendLine("                 , B.ITEM_CD ");
            sb.AppendLine("                 , C.RAW_MAT_CD ");
            sb.AppendLine("                 , ISNULL(C.TOTAL_AMT*B.TOTAL_AMT,0) AS TOTAL_AMT ");
            sb.AppendLine("         from F_PLAN A  ");
            sb.AppendLine("         left outer join F_PLAN_DETAIL B ");
            sb.AppendLine("         on A.PLAN_DATE = B.PLAN_DATE ");
            sb.AppendLine("             and A.PLAN_CD = B.PLAN_CD ");
            sb.AppendLine("             and B.F_LEVEL = '1' ");
            sb.AppendLine("         left outer join N_ITEM_COMP C ");
            sb.AppendLine("         on B.ITEM_CD = C.ITEM_CD ");
            sb.AppendLine("         inner join N_RAW_CODE D ");
            sb.AppendLine("         on C.RAW_MAT_CD = D.RAW_MAT_CD ");
            sb.AppendLine(condition);
            sb.AppendLine("         ) Z ");
            sb.AppendLine("         group by RAW_MAT_CD ");
            sb.AppendLine("     ) U ");
            sb.AppendLine(" left outer join N_RAW_CODE K ");
            sb.AppendLine(" on U.RAW_MAT_CD = K.RAW_MAT_CD ");
            sb.AppendLine(" left outer join N_CUST_CODE P ");
            sb.AppendLine(" on K.CUST_CD = P.CUST_CD ");

            sb.AppendLine(" left outer join ( ");
            sb.AppendLine("     select ZZ.RAW_MAT_CD,SUM(TOTAL_AMT)AS INST_RAW_AMT ");
            sb.AppendLine("     from F_WORK_INST KK  ");
            sb.AppendLine("     inner join F_WORK_INST_DETAIL ZZ ");
            sb.AppendLine("     on KK.W_INST_DATE = ZZ.W_INST_DATE ");
            sb.AppendLine("         and KK.W_INST_CD = ZZ.W_INST_CD  ");
            sb.AppendLine("     where COMPLETE_YN = 'N'  ");
            sb.AppendLine("     group by ZZ.RAW_MAT_CD ");
            sb.AppendLine(" )W  ");
            sb.AppendLine(" on U.RAW_MAT_CD = W.RAW_MAT_CD  ");
            sb.AppendLine(" order by K.CUST_CD,U.RAW_MAT_CD ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_Order_Detail_List(string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select A.ORDER_DATE");
            sb.AppendLine("     ,A.ORDER_CD ");
            sb.AppendLine("     ,A.SEQ ");
            sb.AppendLine("     ,A.RAW_MAT_CD ");
            sb.AppendLine("     ,B.RAW_MAT_NM  ");
            sb.AppendLine("     ,B.SPEC    ");
            sb.AppendLine("     ,A.UNIT_CD ");
            sb.AppendLine("     , (select UNIT_NM from N_UNIT_CODE where UNIT_CD = A.UNIT_CD) AS UNIT_NM  ");
            //sb.AppendLine("     ,FLOOR(A.TOTAL_AMT) AS TOTAL_AMT ");
            //sb.AppendLine("     ,FLOOR(A.PRICE) AS PRICE ");
            //sb.AppendLine("     ,FLOOR(A.TOTAL_MONEY) AS TOTAL_MONEY ");
            sb.AppendLine("     , A.TOTAL_AMT ");
            sb.AppendLine("     , A.PRICE ");
            sb.AppendLine("     , A.TOTAL_MONEY ");
            sb.AppendLine("     ,(SELECT SAUP_LOGO FROM SM_FACTORY_COM.dbo.T_SAUP_CODE WHERE SAUP_NO = '6968700592') AS SIGN ");            
            sb.AppendLine(" from F_ORDER_DETAIL A ");
            sb.AppendLine(" LEFT OUTER JOIN N_RAW_CODE B ");
            sb.AppendLine(" ON A.RAW_MAT_CD = B.RAW_MAT_CD ");
            sb.AppendLine(condition);
            sb.AppendLine(" order by A.SEQ ");

            Debug.WriteLine("오더 디테일 리슽");
            Debug.WriteLine(sb);
            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_Input_Detail_List(string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select A.INPUT_DATE");
            sb.AppendLine("     ,A.INPUT_CD ");
            sb.AppendLine("     ,A.SEQ ");
            sb.AppendLine("     ,A.RAW_MAT_CD ");
            sb.AppendLine("     ,B.RAW_MAT_NM  ");
            sb.AppendLine("     ,B.SPEC    ");
            sb.AppendLine("     ,A.HEAT_NO ");
            sb.AppendLine("     ,A.HEAT_TIME ");
            sb.AppendLine("     ,A.ORDER_DATE ");
            sb.AppendLine("     ,A.ORDER_CD ");
            sb.AppendLine("     ,A.ORDER_SEQ ");
            sb.AppendLine("     ,B.RAW_MAT_GUBUN ");
            sb.AppendLine("     , (select S_CODE_NM from [SM_FACTORY_COM].[dbo].[T_S_CODE] where L_CODE = '300' and S_CODE = B.RAW_MAT_GUBUN) AS RAW_MAT_GUBUN_NM ");
            sb.AppendLine("     ,A.UNIT_CD ");
            sb.AppendLine("     , (select UNIT_NM from N_UNIT_CODE where UNIT_CD = A.UNIT_CD) AS UNIT_NM  ");
            //sb.AppendLine("     ,FLOOR(A.TOTAL_AMT) AS TOTAL_AMT ");
            //sb.AppendLine("     ,FLOOR(A.PRICE) AS PRICE ");
            //sb.AppendLine("     ,FLOOR(A.TOTAL_MONEY) AS TOTAL_MONEY ");
            sb.AppendLine("     , A.TEMP_AMT ");
            sb.AppendLine("     , A.TOTAL_AMT ");
            sb.AppendLine("     , ISNULL(A.PRICE,0) AS PRICE");
            sb.AppendLine("     , A.TOTAL_MONEY ");
            sb.AppendLine("     , A.CHECK_YN ");
            sb.AppendLine("     , (select S_CODE_NM from [SM_FACTORY_COM].[dbo].[T_S_CODE] A where L_CODE= '601'  and S_CODE = B.CHECK_GUBUN) AS CHECK_GUBUN_NM ");
            sb.AppendLine("     , case when ( SELECT count(D.OUTPUT_CD) FROM F_RAW_OUTPUT D LEFT OUTER JOIN F_RAW_DETAIL A ON A.INPUT_DATE = D.INPUT_DATE and A.INPUT_CD = D.INPUT_CD and A.SEQ = D.INPUT_SEQ " + condition + " and D.TOTAL_AMT != 0  ) = 0 THEN 0 ELSE 1 END AS OUTPUT_CD ");

            //---hsp 출력을위해 추가
            sb.AppendLine("     , right('000' + convert(varchar(4), isnull(convert(int, A.INPUT_CD), 0)), 4) AS 번호");
            sb.AppendLine("     , right('0' + convert(varchar(2), isnull(convert(int, A.SEQ), 0)), 2) AS 순번");

            //2019-10-25 유정훈 수정 (바코드 출력물에 거래처명 표시
            sb.AppendLine("     , K.CUST_CD ");
            sb.AppendLine("     , D.CUST_NM ");

            sb.AppendLine(" from F_RAW_INPUT K ");
            sb.AppendLine(" inner join F_RAW_DETAIL A ");
            sb.AppendLine(" on K.INPUT_DATE = A.INPUT_DATE ");
            sb.AppendLine("     and K.INPUT_CD = A.INPUT_CD ");
            // 수정 끝

            sb.AppendLine(" LEFT OUTER JOIN N_RAW_CODE B ");
            sb.AppendLine(" ON A.RAW_MAT_CD = B.RAW_MAT_CD ");
            sb.AppendLine(" LEFT OUTER JOIN F_RAW_CHK C");
            sb.AppendLine(" on A.INPUT_DATE = C.INPUT_DATE");
            sb.AppendLine(" and A.INPUT_CD = C.INPUT_CD");

            //2019-10-25 유정훈 바코드 출력물에 거래처명 표시 
            sb.AppendLine(" LEFT OUTER JOIN N_CUST_CODE D ");
            sb.AppendLine(" on K.CUST_CD = D.CUST_CD ");
            sb.AppendLine(" AND D.CUST_GUBUN = '2' ");
            //수정 끝 
            sb.AppendLine(condition);

            sb.AppendLine(" order by A.INPUT_DATE desc, A.INPUT_CD desc, A.SEQ ");

           
            Debug.WriteLine("인풋 디테일 리슽");
            Debug.WriteLine(sb.ToString());


            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }

        //원자재 수입검사 리스트 

        public DataTable fn_Input_Chk_List(string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select A.INPUT_DATE");
            sb.AppendLine("     ,A.INPUT_CD ");
            sb.AppendLine("     ,A.SEQ ");
            sb.AppendLine("     ,A.RAW_MAT_CD ");
            sb.AppendLine("     ,B.RAW_MAT_NM  ");
            sb.AppendLine("     ,B.SPEC    ");
            sb.AppendLine("     ,C.CUST_CD    ");
            sb.AppendLine("     ,C.CUST_NM    ");
            sb.AppendLine("     ,A.HEAT_NO ");
            sb.AppendLine("     ,A.HEAT_TIME ");
            sb.AppendLine("     ,A.ORDER_DATE ");
            sb.AppendLine("     ,A.ORDER_CD ");
            sb.AppendLine("     ,A.ORDER_SEQ ");
            sb.AppendLine("     ,B.RAW_MAT_GUBUN ");
            sb.AppendLine("     ,A.CHECK_YN ");
            sb.AppendLine("     , (select S_CODE_NM from [SM_FACTORY_COM].[dbo].[T_S_CODE] where L_CODE = '300' and S_CODE = B.RAW_MAT_GUBUN) AS RAW_MAT_GUBUN_NM ");
            sb.AppendLine("     , (select S_CODE_NM from [SM_FACTORY_COM].[dbo].[T_S_CODE] where L_CODE = '610' and S_CODE = A.CHECK_YN)  AS CHECK_NM ");
            sb.AppendLine("     ,A.UNIT_CD ");
            sb.AppendLine("     , (select UNIT_NM from N_UNIT_CODE where UNIT_CD = A.UNIT_CD) AS UNIT_NM  ");
            sb.AppendLine("     , A.TEMP_AMT ");
            sb.AppendLine("     , A.TOTAL_AMT ");
            sb.AppendLine("     , A.PRICE ");
            //sb.AppendLine("     , A.RAW_HST_CD ");
            sb.AppendLine("     , A.TOTAL_MONEY ");
            sb.AppendLine("     , F.CHK_DATE ");
            sb.AppendLine("     , F.PASS_YN ");
            //---hsp 출력을위해 추가
            sb.AppendLine("     , right('000' + convert(varchar(4), isnull(convert(int, A.INPUT_CD), 0)), 4) AS 번호");
            sb.AppendLine("     , right('0' + convert(varchar(2), isnull(convert(int, A.SEQ), 0)), 2) AS 순번");

            sb.AppendLine(" from F_RAW_INPUT Z ");
            sb.AppendLine(" inner join F_RAW_DETAIL A ");
            sb.AppendLine(" on Z.INPUT_DATE = A.INPUT_DATE");
            sb.AppendLine("     and Z.INPUT_CD = A.INPUT_CD");
            sb.AppendLine(" inner join N_RAW_CODE B ");
            sb.AppendLine(" on A.RAW_MAT_CD = B.RAW_MAT_CD ");
            sb.AppendLine("     and B.CHECK_GUBUN = '1' ");
            sb.AppendLine(" inner join N_CUST_CODE C ");
            sb.AppendLine(" on Z.CUST_CD = C.CUST_CD ");
            sb.AppendLine("     and C.CUST_GUBUN = '2' ");
            sb.AppendLine(" left outer join F_RAW_CHK F ");
            sb.AppendLine(" on Z.INPUT_DATE = F.INPUT_DATE");
            sb.AppendLine("     and Z.INPUT_CD = F.INPUT_CD");
            sb.AppendLine("     and A.SEQ = F.SEQ");
            sb.AppendLine(condition);
            sb.AppendLine(" order by Z.INPUT_DATE desc,Z.INPUT_CD desc,A.SEQ ");


            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }

        //원자재 수입검사 리스트 

        public DataTable fn_Input_Chk_Detail_List(string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select A.INPUT_DATE");
            sb.AppendLine("     ,A.INPUT_CD ");
            sb.AppendLine("     ,A.SEQ ");
            sb.AppendLine("     ,A.CONTROL_NO ");
            sb.AppendLine("     ,A.PART_NO ");
            sb.AppendLine("     ,A.CHK_TOTAL_AMT ");
            sb.AppendLine("     ,A.PASS_AMT ");
            sb.AppendLine("     ,A.PRI_NON_PASS_AMT ");
            sb.AppendLine("     ,A.UPD_COM_AMT ");
            sb.AppendLine("     ,A.FINAL_NON_PASS_AMT ");
            sb.AppendLine("     ,A.FINAL_PASS_AMT ");
            sb.AppendLine("     ,A.COMMENT ");
            sb.AppendLine("from F_RAW_CHK A ");
            sb.AppendLine("where 1=1 ");
            sb.AppendLine(condition);
            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);

        }

        public DataTable fn_Input_Chk_Poor_List(string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select A.INPUT_DATE");
            sb.AppendLine("     ,A.INPUT_CD ");
            sb.AppendLine("     ,A.SEQ ");
            sb.AppendLine("     ,A.POOR_SEQ ");
            sb.AppendLine("     ,A.TYPE_CD ");
            sb.AppendLine("     ,A.POOR_NM ");
            sb.AppendLine("     ,A.PRI_NON_PASS_AMT ");
            sb.AppendLine("     ,A.UPD_DETAIL ");
            sb.AppendLine("     ,A.UPD_PASS_AMT ");
            sb.AppendLine("     ,A.COMMENT ");
            sb.AppendLine("from F_RAW_CHK_POOR A ");
            sb.AppendLine("where 1=1 ");
            sb.AppendLine(condition);
            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);

        }
        //원자재 원장 리스트 

        public DataTable fn_Input_Rm_Ledger_List(string condition)
        {
            StringBuilder sb = new StringBuilder();
            //sb.AppendLine("select A.INPUT_DATE");
            //sb.AppendLine("     ,A.INPUT_CD ");
            //sb.AppendLine("     ,A.SEQ ");
            //sb.AppendLine("     ,Z.CUST_CD ");
            //sb.AppendLine("     ,C.CUST_NM ");
            //sb.AppendLine("     ,A.RAW_MAT_CD ");
            //sb.AppendLine("     ,B.RAW_MAT_NM  ");
            //sb.AppendLine("     ,B.SPEC    ");
            //sb.AppendLine("     ,A.HEAT_NO ");
            //sb.AppendLine("     ,A.HEAT_TIME ");
            //sb.AppendLine("     ,A.ORDER_DATE ");
            //sb.AppendLine("     ,A.ORDER_CD ");
            //sb.AppendLine("     ,A.ORDER_SEQ ");
            //sb.AppendLine("     ,B.RAW_MAT_GUBUN ");
            //sb.AppendLine("     , (select S_CODE_NM from [SM_FACTORY_COM].[dbo].[T_S_CODE] where L_CODE = '300' and S_CODE = B.RAW_MAT_GUBUN) AS RAW_MAT_GUBUN_NM ");
            //sb.AppendLine("     ,A.UNIT_CD ");
            //sb.AppendLine("     , (select UNIT_NM from N_UNIT_CODE where UNIT_CD = A.UNIT_CD) AS UNIT_NM  ");
            //sb.AppendLine("     , A.TOTAL_AMT ");
            //sb.AppendLine("     , A.PRICE ");
            //sb.AppendLine("     , A.TOTAL_MONEY ");

            //---hsp 출력물하면서 수정
            sb.AppendLine("select '' as no,  A.INPUT_DATE AS 입고일자 ");
            sb.AppendLine("     ,A.INPUT_CD AS 입고번호 ");
            sb.AppendLine("     ,A.SEQ AS 입고순번 ");
            sb.AppendLine("     ,Z.CUST_CD AS 거래처코드 ");
            sb.AppendLine("     ,C.CUST_NM AS 거래처명 ");
            sb.AppendLine("     ,A.RAW_MAT_CD AS 원부재료코드 ");
            sb.AppendLine("     ,B.RAW_MAT_NM AS 원부재료명   ");
            sb.AppendLine("     ,B.SPEC AS  규격    ");
            sb.AppendLine("     ,A.HEAT_NO AS HEATNO ");
            sb.AppendLine("     ,A.HEAT_TIME AS HEATTIME ");
            sb.AppendLine("     ,A.ORDER_DATE AS 주문일자 ");
            sb.AppendLine("     ,A.ORDER_CD AS 주문번호 ");
            sb.AppendLine("     ,A.ORDER_SEQ AS 주문순번 ");
            sb.AppendLine("     ,B.RAW_MAT_GUBUN AS 구분코드 ");
            sb.AppendLine("     , (select S_CODE_NM from [SM_FACTORY_COM].[dbo].[T_S_CODE] where L_CODE = '300' and S_CODE = B.RAW_MAT_GUBUN) AS 구분명 ");
            sb.AppendLine("     ,A.UNIT_CD AS 단위코드 ");
            sb.AppendLine("     , (select UNIT_NM from N_UNIT_CODE where UNIT_CD = A.UNIT_CD) AS 단위명");
            sb.AppendLine("     , ISNULL(A.TEMP_AMT,0) AS 가입고수량 ");
            sb.AppendLine("     , ISNULL(A.TOTAL_AMT,0) AS 수량 ");
            sb.AppendLine("     , ISNULL(A.PRICE,0) AS 단가 ");
            sb.AppendLine("     , ISNULL(A.TOTAL_MONEY,0) AS 금액 ");
            sb.AppendLine(" from F_RAW_INPUT Z  ");
            sb.AppendLine(" left outer join F_RAW_DETAIL A  ");
            sb.AppendLine(" on Z.INPUT_DATE = A.INPUT_DATE  ");
            sb.AppendLine("     and Z.INPUT_CD = A.INPUT_CD   ");

            sb.AppendLine(" left outer join N_RAW_CODE B ");
            sb.AppendLine(" on A.RAW_MAT_CD = B.RAW_MAT_CD ");
            sb.AppendLine(" left outer join N_CUST_CODE C");
            sb.AppendLine(" on Z.CUST_CD = C.CUST_CD ");
            sb.AppendLine(condition);
            sb.AppendLine(" order by a.INPUT_DATE DESC,a.INPUT_CD");

            Debug.WriteLine(sb);
            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_work_List(string condition)
        //작업일보관리
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("select A.F_SUB_DATE,convert(nvarchar,A.F_STEP)+'단계 '+w.FLOW_NM as F_STEP,A.LOT_NO,A.ITEM_CD,c.SPEC,c.ITEM_NM,c.LINE_CD,isnull(z.LINE_NM,'X') as LINE_NM,A.CUST_CD,d.CUST_NM,A.F_SUB_AMT,(A.F_SUB_AMT - A.LOSS - A.POOR_AMT) AS COMPLETE_AMT ");
            sb.AppendLine("	,isnull('0',x.inst_AMT)as INST_AMT,isnull(0,x.INST_AMT-(A.F_SUB_AMT - A.LOSS - A.POOR_AMT)) as 남은것");
            
            sb.AppendLine("from F_WORK_FLOW_DETAIL A");
            sb.AppendLine("inner join F_WORK_FLOW B on B.LOT_NO=A.LOT_NO");
            sb.AppendLine("inner join N_ITEM_CODE c on c.ITEM_CD=A.ITEM_CD");
            sb.AppendLine("inner join N_CUST_CODE D on D.CUST_CD=A.CUST_CD");
            sb.AppendLine("LEFT OUTER JOIN N_FLOW_CODE w ON A.FLOW_CD = w.FLOW_CD  ");
            sb.AppendLine("LEFT OUTER join N_LINE_CODE z on z.LINE_CD=c.LINE_CD ");
            sb.AppendLine(" left outer join f_work_inst x on x.lot_no=a.LOT_NO");

            sb.AppendLine(condition);
            //sb.AppendLine("and w.FLOW_CD='0005' ");

            //sb.AppendLine("SELECT A.LOT_NO, ");
            //sb.AppendLine("A.W_INST_DATE, ");
            //sb.AppendLine("(SELECT ITEM_NM FROM N_ITEM_CODE WHERE ITEM_CD = A.ITEM_CD) AS ITEM_NM ,  ");
            //sb.AppendLine("A.SPEC ,  ");
            //sb.AppendLine("(SELECT CUST_NM FROM N_CUST_CODE WHERE CUST_CD = A.CUST_CD) AS CUST_NM,  ");
            //sb.AppendLine("A.INST_AMT, ");
            //sb.AppendLine("A.RAW_OUT_YN,  ");
            //sb.AppendLine("B.F_STEP,  ");
            //sb.AppendLine("A.COMPLETE_YN ");
            //sb.AppendLine("FROM F_WORK_INST A ");
            //sb.AppendLine("LEFT OUTER JOIN F_WORK_FLOW_DETAIL B ");
            //sb.AppendLine("ON A.LOT_NO = B.LOT_NO ");
            //sb.AppendLine(condition);
            //sb.AppendLine(" order by A.LOT_NO ");
            Debug.WriteLine("작업일보관리");
            Debug.WriteLine(sb);
            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            return wAdo.SqlCommandSelect(sCommand);

        }
        public DataTable fn_Input_Order_Detail_List(string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select A.ORDER_DATE");
            sb.AppendLine("     ,A.ORDER_CD ");
            sb.AppendLine("     ,B.SEQ ");
            sb.AppendLine("     ,A.INPUT_REQ_DATE ");
            sb.AppendLine("     ,A.COMPLETE_YN  ");
            sb.AppendLine("     ,B.RAW_MAT_CD    ");
            sb.AppendLine("     ,D.RAW_MAT_NM ");
            sb.AppendLine("     ,D.SPEC ");
            sb.AppendLine("     ,B.UNIT_CD ");
            sb.AppendLine("     ,(select UNIT_NM from N_UNIT_CODE where UNIT_CD = B.UNIT_CD) AS UNIT_NM  ");
            sb.AppendLine("     ,D.RAW_MAT_GUBUN ");
            sb.AppendLine("     ,X.CUST_CD ");
            sb.AppendLine("     ,X.CUST_NM ");

            //sb.AppendLine("     ,FLOOR(ISNULL(TOTAL_AMT,0)) AS ORDER_AMT  ");
            //sb.AppendLine("     ,FLOOR(B.PRICE) AS PRICE  ");
            //sb.AppendLine("     ,FLOOR(B.TOTAL_MONEY) TOTAL_MONEY  ");
            sb.AppendLine("     ,ISNULL(TOTAL_AMT,0) AS ORDER_AMT  ");
            sb.AppendLine("     ,B.PRICE  ");
            sb.AppendLine("     ,B.TOTAL_MONEY ");
            sb.AppendLine("     ,(select S_CODE_NM from [SM_FACTORY_COM].[dbo].[T_S_CODE] where L_CODE = '300' and S_CODE = D.RAW_MAT_GUBUN) AS RAW_MAT_GUBUN_NM ");
            sb.AppendLine("     , C.INPUT_AMT ");
            sb.AppendLine("     , C.NO_INPUT_AMT");
            sb.AppendLine(" FROM F_ORDER A ");
            sb.AppendLine(" LEFT OUTER JOIN N_CUST_CODE X ON A.CUST_CD = X.CUST_CD ");
            sb.AppendLine(" LEFT OUTER JOIN F_ORDER_DETAIL B ");
            sb.AppendLine(" ON A.ORDER_DATE = B.ORDER_DATE ");
            sb.AppendLine(" AND A.ORDER_CD = B.ORDER_CD  ");
            sb.AppendLine(" LEFT OUTER JOIN(	 ");
            sb.AppendLine("                     SELECT AA.ORDER_DATE	 ");
            sb.AppendLine("                           ,AA.ORDER_CD       ");
            sb.AppendLine("                           ,AA.SEQ ");
            sb.AppendLine("                           ,ISNULL(SUM(BB.TEMP_AMT),0) AS INPUT_AMT ");
            sb.AppendLine("                           , ISNULL(AA.TOTAL_AMT,0)-ISNULL(SUM(BB.TEMP_AMT),0) AS NO_INPUT_AMT ");
            sb.AppendLine("                     FROM F_ORDER_DETAIL AA ");
            sb.AppendLine("                     LEFT OUTER JOIN F_RAW_DETAIL BB ");
            sb.AppendLine("                     ON AA.ORDER_DATE = BB.ORDER_DATE ");
            sb.AppendLine("                         AND AA.ORDER_CD = BB.ORDER_CD ");
            sb.AppendLine("                         AND AA.SEQ = BB.ORDER_SEQ ");
            sb.AppendLine("                     GROUP BY AA.ORDER_DATE,AA.ORDER_CD,AA.SEQ,AA.TOTAL_AMT)C ");
            sb.AppendLine(" ON A.ORDER_DATE = C.ORDER_DATE  ");
            sb.AppendLine(" AND A.ORDER_CD = C.ORDER_CD ");
            sb.AppendLine(" AND B.SEQ = C.SEQ  ");

            sb.AppendLine(" LEFT OUTER JOIN N_RAW_CODE D	 ");
            sb.AppendLine(" ON B.RAW_MAT_CD = D.RAW_MAT_CD  ");
            sb.AppendLine("WHERE NO_INPUT_AMT > 0 ");
            //sb.AppendLine(condition);
            sb.AppendLine(" order by A.ORDER_DATE desc, A.ORDER_CD desc, B.SEQ desc ");


            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }


        public DataTable fn_Raw_Stock_List(string srch_date, string condition)
        {
            StringBuilder sb = new StringBuilder();

            //sb.AppendLine("select A.RAW_MAT_CD ");
            //sb.AppendLine("      , A.RAW_MAT_NM ");
            //sb.AppendLine("      , A.SPEC ");
            //sb.AppendLine("      , ISNULL(B.INPUT_AMT,0) AS INPUT_AMT ");
            //sb.AppendLine("      , ISNULL(C.OUTPUT_AMT,0) AS OUTPUT_AMT ");
            //sb.AppendLine("      , ISNULL(B.INPUT_AMT,0) - ISNULL(C.OUTPUT_AMT,0) AS STOCK_AMT ");
            //sb.AppendLine("      , A.BAL_STOCK ");

            //---hsp 출력물하면서 수정
            sb.AppendLine("select '' as no, A.RAW_MAT_CD AS 원부재료코드 ");
            sb.AppendLine("      , A.RAW_MAT_NM AS 원부재료명 ");
            sb.AppendLine("      , A.SPEC AS  규격 ");
            sb.AppendLine("      , ISNULL(B.INPUT_AMT,0) AS 입고량 ");
            sb.AppendLine("      , ISNULL(C.OUTPUT_AMT,0) AS 출고량 ");
            sb.AppendLine("      , ISNULL(B.INPUT_AMT,0) - ISNULL(C.OUTPUT_AMT,0) AS 재고량 ");
            sb.AppendLine("      , ISNULL(A.BAL_STOCK,0) AS BAL_STOCK ");
            sb.AppendLine("      , ISNULL(A.BASIC_STOCK,0) AS BASIC_STOCK ");

            sb.AppendLine("from N_RAW_CODE A ");
            sb.AppendLine("LEFT OUTER JOIN( ");
            sb.AppendLine("                 select RAW_MAT_CD");
            sb.AppendLine("                      , SUM(ISNULL(TOTAL_AMT,0)) as INPUT_AMT ");
            sb.AppendLine("                 from F_RAW_DETAIL ");
            sb.AppendLine("                 where INPUT_DATE <= '" + srch_date + "'  ");
            sb.AppendLine("                 group by RAW_MAT_CD) B ");
            sb.AppendLine("ON A.RAW_MAT_CD = B.RAW_MAT_CD ");
            sb.AppendLine("LEFT OUTER JOIN( ");
            sb.AppendLine("                 select RAW_MAT_CD");
            sb.AppendLine("                      , SUM(ISNULL(TOTAL_AMT,0)) as OUTPUT_AMT ");
            sb.AppendLine("                 from F_RAW_OUTPUT ");
            sb.AppendLine("                 where OUTPUT_DATE <= '" + srch_date + "'  ");
            sb.AppendLine("                 group by RAW_MAT_CD) C ");
            sb.AppendLine("ON A.RAW_MAT_CD = C.RAW_MAT_CD  ");
            sb.AppendLine(condition);

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_Raw_Want_Stock(string condition)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("select A.RAW_MAT_CD ");
            sb.AppendLine("      ,A.RAW_MAT_NM ");
            sb.AppendLine("      ,A.SPEC ");
            sb.AppendLine("      ,A.RAW_MAT_GUBUN ");
            sb.AppendLine("      , (select S_CODE_NM  ");
            sb.AppendLine("         from [SM_FACTORY_COM].[dbo].[T_S_CODE]   ");
            sb.AppendLine("         where L_CODE = '300' and S_CODE = A.RAW_MAT_GUBUN) AS RAW_MAT_GUBUN_NM    ");
            sb.AppendLine("      , A.TYPE_CD  ");
            sb.AppendLine("      , (select TYPE_NM from N_TYPE_CODE where TYPE_CD = A.TYPE_CD) AS TYPE_NM    ");
            sb.AppendLine("      , A.INPUT_UNIT    ");
            sb.AppendLine("      , (select UNIT_NM from N_UNIT_CODE where UNIT_CD = A.INPUT_UNIT) AS INPUT_UNIT_NM    ");
            sb.AppendLine("      , A.OUTPUT_UNIT  ");
            sb.AppendLine("      , (select UNIT_NM from N_UNIT_CODE where UNIT_CD = A.OUTPUT_UNIT) AS OUTPUT_UNIT_NM    ");
            sb.AppendLine("      , A.CUST_CD  ");
            sb.AppendLine("      , (select CUST_NM from N_CUST_CODE where CUST_CD = A.CUST_CD and CUST_GUBUN ='2') AS CUST_NM   ");
            sb.AppendLine("      , A.BASIC_STOCK  ");
            sb.AppendLine("      , A.CHECK_GUBUN   ");
            sb.AppendLine("      , A.BAL_STOCK   ");
            sb.AppendLine("      , (ISNULL(A.BAL_STOCK,0) - ISNULL(B.INST_RAW_AMT,0)) as REAL_AMT    ");

            sb.AppendLine("from N_RAW_CODE A ");
            sb.AppendLine("left outer join ( ");
            sb.AppendLine("     select ZZ.RAW_MAT_CD,SUM(TOTAL_AMT)AS INST_RAW_AMT");
            sb.AppendLine("     from F_WORK_INST KK  ");
            sb.AppendLine("     inner join F_WORK_INST_DETAIL ZZ  ");
            sb.AppendLine("     on KK.W_INST_DATE = ZZ.W_INST_DATE  ");
            sb.AppendLine("     and KK.W_INST_CD = ZZ.W_INST_CD   ");
            sb.AppendLine("     where COMPLETE_YN = 'N'   ");
            sb.AppendLine("     group by ZZ.RAW_MAT_CD   ");
            sb.AppendLine("    )B ");
            sb.AppendLine(" on A.RAW_MAT_CD = B.RAW_MAT_CD ");
            sb.AppendLine("WHERE 1=1 ");
            sb.AppendLine(condition);
            Debug.WriteLine("fn_Raw_Want_Stock");
            Debug.WriteLine(sb);
            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_Raw_St_Detail_List(string srch_date, string raw_mat_cd)
        {
            StringBuilder sb = new StringBuilder();

            //sb.AppendLine("select  ");
            //sb.AppendLine("      A.INPUT_DATE ");
            //sb.AppendLine("      , A.INPUT_CD ");
            //sb.AppendLine("      , Z.SEQ ");
            //sb.AppendLine("      , Z.RAW_MAT_CD ");
            //sb.AppendLine("      , SUM(ISNULL(Z.TOTAL_AMT,0)) as INPUT_AMT ");
            //sb.AppendLine("      , SUM(ISNULL(K.TOTAL_AMT,0)) as OUTPUT_AMT ");
            //sb.AppendLine("      , SUM(ISNULL(Z.TOTAL_AMT,0)) - SUM(ISNULL(K.TOTAL_AMT,0)) as STOCK_AMT ");
            //sb.AppendLine("      from F_RAW_INPUT A ");
            //sb.AppendLine("left outer join F_RAW_DETAIL Z  ");
            //sb.AppendLine("on A.INPUT_DATE = Z.INPUT_DATE");
            //sb.AppendLine("    and A.INPUT_CD = Z.INPUT_CD");
            //sb.AppendLine("left outer join (  ");
            //sb.AppendLine("                 select INPUT_DATE,INPUT_CD,INPUT_SEQ,SUM(TOTAL_AMT)AS TOTAL_AMT from F_RAW_OUTPUT   ");
            //sb.AppendLine("                 where 1=1   ");
            //sb.AppendLine("                     and RAW_MAT_CD = '" + raw_mat_cd + "'   ");
            //sb.AppendLine("                     and INPUT_DATE <= '" + srch_date + "'   ");
            //sb.AppendLine("                 group by INPUT_DATE,INPUT_CD,INPUT_SEQ   ");
            //sb.AppendLine("                )K ");

            //sb.AppendLine("on A.INPUT_DATE = K.INPUT_DATE");
            //sb.AppendLine("    and A.INPUT_CD = K.INPUT_CD");
            //sb.AppendLine("    and Z.SEQ = K.INPUT_SEQ");
            //sb.AppendLine("where 1=1  ");
            //sb.AppendLine("     and Z.RAW_MAT_CD = '" + raw_mat_cd + "' ");
            //sb.AppendLine("     and A.INPUT_DATE <= '" + srch_date + "' ");
            //sb.AppendLine("group by A.INPUT_DATE,A.INPUT_CD,Z.SEQ,Z.RAW_MAT_CD ");
            //sb.AppendLine("order by A.INPUT_DATE,A.INPUT_CD,Z.SEQ ");


            sb.AppendLine("     select   ISNULL(A.INPUT_DATE,OUTPUT_DATE) as INPUT_DATE");
            sb.AppendLine("        , isnull(convert(nvarchar,A.INPUT_CD),'미입고') as INPUT_CD");
            sb.AppendLine("         , isnull(convert(nvarchar,Z.SEQ),'미입고') as SEQ ");
            sb.AppendLine("     , isnull(Z.RAW_MAT_CD,k.RAW_MAT_CD) as RAW_MAT_CD ");
            sb.AppendLine("       , SUM(ISNULL(Z.TOTAL_AMT,0)) as INPUT_AMT  ");
            sb.AppendLine("        , SUM(ISNULL(K.TOTAL_AMT,0)) as OUTPUT_AMT  ");
            sb.AppendLine("      , SUM(ISNULL(Z.TOTAL_AMT,0)) - SUM(ISNULL(K.TOTAL_AMT,0)) as STOCK_AMT ");
            sb.AppendLine("      from F_RAW_INPUT A ");
            sb.AppendLine("left outer join F_RAW_DETAIL Z   ");
            sb.AppendLine("on A.INPUT_DATE = Z.INPUT_DATE");
            sb.AppendLine("    and A.INPUT_CD = Z.INPUT_CD");
            sb.AppendLine("full outer join (  ");
            sb.AppendLine("                    select MAX(OUTPUT_DATE) as OUTPUT_DATE ,INPUT_DATE,INPUT_CD,INPUT_SEQ,SUM(TOTAL_AMT)AS TOTAL_AMT,RAW_MAT_CD from F_RAW_OUTPUT       ");
            sb.AppendLine("                 where 1=1   ");
            sb.AppendLine("                     and RAW_MAT_CD = '" + raw_mat_cd + "'   ");
            sb.AppendLine("                     and INPUT_DATE <= '" + srch_date + "'   ");
            sb.AppendLine("                 group by INPUT_DATE,INPUT_CD,INPUT_SEQ  , RAW_MAT_CD ");
            sb.AppendLine("                )K ");

            sb.AppendLine("on A.INPUT_DATE = K.INPUT_DATE");
            sb.AppendLine("     and A.INPUT_CD = K.INPUT_CD");
            sb.AppendLine("    and Z.SEQ = K.INPUT_SEQ");
            sb.AppendLine("where 1=1  ");
            sb.AppendLine("    and isnull(Z.RAW_MAT_CD,k.RAW_MAT_CD) = '" + raw_mat_cd + "' ");
            sb.AppendLine(" and ISNULL(A.INPUT_DATE,OUTPUT_DATE)  <=  '" + srch_date + "' ");
            sb.AppendLine("  group by ISNULL(A.INPUT_DATE,OUTPUT_DATE)  ,A.INPUT_CD,Z.SEQ,isnull(Z.RAW_MAT_CD,k.RAW_MAT_CD)");
            sb.AppendLine("union all");
            sb.AppendLine("select   ISNULL(A.INPUT_DATE,OUTPUT_DATE) as INPUT_DATE");
            sb.AppendLine("   , '합계'");
            sb.AppendLine("   , '합계'");
            sb.AppendLine("   , '합계'");
            sb.AppendLine("  , SUM(ISNULL(Z.TOTAL_AMT,0)) as INPUT_AMT");
            sb.AppendLine("     , SUM(ISNULL(K.TOTAL_AMT,0)) as OUTPUT_AMT ");
            sb.AppendLine(" , SUM(ISNULL(Z.TOTAL_AMT,0)) - SUM(ISNULL(K.TOTAL_AMT,0)) as STOCK_AMT ");
            sb.AppendLine("from F_RAW_INPUT A ");
            sb.AppendLine("left outer join F_RAW_DETAIL Z  ");
            sb.AppendLine("on A.INPUT_DATE = Z.INPUT_DATE");
            sb.AppendLine("    and A.INPUT_CD = Z.INPUT_CD");
            sb.AppendLine("full outer join (  ");
            sb.AppendLine("                   select MAX(OUTPUT_DATE) as OUTPUT_DATE ,INPUT_DATE,INPUT_CD,INPUT_SEQ,SUM(TOTAL_AMT)AS TOTAL_AMT,RAW_MAT_CD from F_RAW_OUTPUT     ");
            sb.AppendLine("                 where 1=1   ");
            sb.AppendLine("                     and RAW_MAT_CD = '" + raw_mat_cd + "'   ");
            sb.AppendLine("                     and INPUT_DATE <= '" + srch_date + "'   ");
            sb.AppendLine("                 group by INPUT_DATE,INPUT_CD,INPUT_SEQ  , RAW_MAT_CD ");
            sb.AppendLine("                )K ");
            sb.AppendLine("on A.INPUT_DATE = K.INPUT_DATE");
            sb.AppendLine("    and A.INPUT_CD = K.INPUT_CD");
            sb.AppendLine("    and Z.SEQ = K.INPUT_SEQ");
            sb.AppendLine("where 1=1  ");
            sb.AppendLine("    and isnull(Z.RAW_MAT_CD,k.RAW_MAT_CD) = '" + raw_mat_cd + "' ");
            sb.AppendLine("   and ISNULL(A.INPUT_DATE,OUTPUT_DATE)  <=  '" + srch_date + "' ");
           sb.AppendLine("  group by ISNULL(A.INPUT_DATE,OUTPUT_DATE)  ");
            sb.AppendLine("order by ISNULL(A.INPUT_DATE,OUTPUT_DATE) ,isnull(convert(nvarchar,A.INPUT_CD),'미입고') ");


            Debug.WriteLine("선택한 원자재 디테일내역");

            Debug.WriteLine(sb);
            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            return wAdo.SqlCommandSelect(sCommand);
        }
        //솔빈수정 inner join 추가 
        public DataTable fn_Work_List(string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select A.W_INST_DATE");
            sb.AppendLine("     ,A.W_INST_CD ");
            sb.AppendLine("     ,A.LOT_NO ");
            sb.AppendLine("     ,A.ITEM_CD ");
            sb.AppendLine("     ,B.ITEM_NM ");
            sb.AppendLine("     ,B.ITEM_GUBUN ");
            sb.AppendLine("     ,B.SPEC ");
            sb.AppendLine("     ,A.INST_AMT");
            sb.AppendLine("     ,A.CHARGE_AMT ");
            sb.AppendLine("     ,A.PACK_AMT ");
            sb.AppendLine("     ,A.PLAN_NUM");
            sb.AppendLine("     ,A.PLAN_ITEM");
            sb.AppendLine("     ,A.INSTAFF ");
            sb.AppendLine("     ,A.INST_NOTICE ");
          //  sb.AppendLine("     ,(SELECT CUST_NM FROM N_CUST_CODE WHERE A.CUST_CD = CUST_CD) AS CUST_NM ");
            sb.AppendLine("     ,A.CUST_CD ");
            sb.AppendLine("        ,D.CUST_NM ");
            sb.AppendLine("     ,CASE WHEN ISNULL(C.COMPLETE_YN,'N')='Y' THEN '완료' ELSE '미완료' END COMPLETE_YN   ");
            sb.AppendLine(" from F_WORK_INST A ");
            sb.AppendLine(" LEFT OUTER JOIN N_ITEM_CODE B ");
            sb.AppendLine(" ON A.ITEM_CD = B.ITEM_CD ");
            sb.AppendLine(" LEFT OUTER JOIN F_WORK_FLOW C ");
            sb.AppendLine(" ON A.LOT_NO = C.LOT_NO ");
            sb.AppendLine(" left join N_CUST_CODE as D on D.CUST_CD=A.CUST_CD  ");
            sb.AppendLine(condition);
            sb.AppendLine(" order by A.W_INST_DATE desc, A.W_INST_CD desc ");

            Debug.WriteLine("작업지시서등록 fn_Work_List");

            Debug.WriteLine(sb.ToString());

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
            sb.AppendLine("select A.W_INST_DATE");
            sb.AppendLine("     ,A.W_INST_CD ");
            sb.AppendLine("     ,A.LOT_NO ");
            sb.AppendLine("     ,A.CUST_CD ");
            sb.AppendLine("     ,(select CUST_NM from N_CUST_CODE where CUST_GUBUN = '1' and CUST_CD = A.CUST_CD) as CUST_NM  ");
            sb.AppendLine("     ,A.ITEM_CD ");
            sb.AppendLine("     ,B.ITEM_NM ");
            sb.AppendLine("     ,B.SPEC ");
            sb.AppendLine("     ,A.UNIT_CD ");
            sb.AppendLine("     ,A.INST_AMT");
            sb.AppendLine("     ,A.WORKER_CD");
            sb.AppendLine("     ,(select STAFF_NM from N_STAFF_CODE where STAFF_CD = A.WORKER_CD) as WORKER_NM ");
            sb.AppendLine("     ,A.COMPLETE_YN");
            sb.AppendLine("     ,A.LINE_CD");
            sb.AppendLine("     ,(select LINE_NM from N_LINE_CODE where LINE_CD = A.LINE_CD) as LINE_NM  ");
            sb.AppendLine("     ,A.DELIVERY_DATE");
            sb.AppendLine("     ,A.PLAN_NUM");
            sb.AppendLine("     ,A.PLAN_ITEM");
            sb.AppendLine("     ,A.INSTAFF ");
            sb.AppendLine("     ,A.INST_NOTICE ");
            sb.AppendLine("     ,B.CHARGE_AMT ");
            sb.AppendLine("     ,B.PACK_AMT ");
            sb.AppendLine("     ,A.RAW_OUT_YN ");
            sb.AppendLine("     ,A.POOR_WORK_YN ");
            sb.AppendLine("     ,C.COMPLETE_YN AS FLOW_YN ");
            sb.AppendLine("     ,(SELECT DELIVER_REQ_DATE FROM F_PLAN F WHERE A.PLAN_NUM = F.PLAN_NUM) AS REQ_DATE ");
            sb.AppendLine(" from F_WORK_INST A ");
            sb.AppendLine(" LEFT OUTER JOIN N_ITEM_CODE B ");
            sb.AppendLine(" on A.ITEM_CD = B.ITEM_CD ");
            sb.AppendLine(" LEFT OUTER JOIN F_WORK_FLOW C");
            sb.AppendLine(" on A.LOT_NO = C.LOT_NO ");
            sb.AppendLine(condition);
            sb.AppendLine(" order by A.W_INST_DATE desc, A.W_INST_CD desc ");


            Console.WriteLine(sb.ToString());

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_Work_Plan_List(string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select A.PLAN_DATE");
            sb.AppendLine("     ,A.PLAN_CD ");
            sb.AppendLine("     ,A.PLAN_NUM ");
            sb.AppendLine("     ,A.CUST_CD ");
            sb.AppendLine("     ,(select CUST_NM from N_CUST_CODE where CUST_GUBUN = '1' and CUST_CD = A.CUST_CD) as CUST_NM  ");
            sb.AppendLine("     ,B.ITEM_CD ");
            sb.AppendLine("     ,C.ITEM_NM  ");
            sb.AppendLine("     ,C.ITEM_GUBUN  ");
            sb.AppendLine("     ,C.SPEC    ");
            sb.AppendLine("     ,C.CHARGE_AMT    ");
            sb.AppendLine("     ,C.PACK_AMT    ");
            sb.AppendLine("     ,B.UNIT_CD ");
            sb.AppendLine("     , (select UNIT_NM from N_UNIT_CODE where UNIT_CD = B.UNIT_CD) AS UNIT_NM  ");
            sb.AppendLine("     , B.TOTAL_AMT ");
            sb.AppendLine("     , B.TOTAL_AMT - ISNULL(INST_AMT,0) AS RES_QUAN_AMT ");
            sb.AppendLine("     , A.DELIVER_REQ_DATE ");
            sb.AppendLine(" from F_PLAN A ");
            sb.AppendLine(" left outer join F_PLAN_GROUP B ");
            sb.AppendLine(" on A.PLAN_DATE = B.PLAN_DATE ");
            sb.AppendLine("     and A.PLAN_CD = B.PLAN_CD ");
            sb.AppendLine(" left outer join N_ITEM_CODE C ");
            sb.AppendLine(" on B.ITEM_CD = C.ITEM_CD ");

            sb.AppendLine(" left outer join (   ");
            sb.AppendLine("                     select Z.PLAN_NUM ");
            sb.AppendLine("                     ,Z.ITEM_CD ");
            sb.AppendLine("                     ,SUM(ISNULL(Z.INST_AMT,0))AS INST_AMT ");
            sb.AppendLine("                     from F_WORK_INST Z ");
            sb.AppendLine("                     where PLAN_NUM != '' ");
            sb.AppendLine("                     group by PLAN_NUM,ITEM_CD) D ");
            sb.AppendLine(" on A.PLAN_NUM = D.PLAN_NUM ");
            sb.AppendLine(" and B.ITEM_CD = D.ITEM_CD ");
            sb.AppendLine(condition);
            sb.AppendLine(" order by A.PLAN_DATE desc,A.PLAN_CD desc,B.ITEM_CD ");
            Debug.WriteLine(sb);
            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            return wAdo.SqlCommandSelect(sCommand);
        }

        //작업지시서에서 제품선택 및 생산계획 클릭 시 나타나는 원부재료 
        public DataTable fn_Work_Rm_Default_List(double inst_amt, string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select A.ITEM_CD");
            sb.AppendLine("     ,A.ITEM_NM ");
            sb.AppendLine("     ,C.RAW_MAT_CD ");
            sb.AppendLine("     ,C.RAW_MAT_NM ");
            sb.AppendLine("     ,C.SPEC  ");
            sb.AppendLine("     ,C.CUST_CD    ");
            sb.AppendLine("     ,D.CUST_NM ");
            sb.AppendLine("     ,C.INPUT_UNIT ");
            sb.AppendLine("     ,(select UNIT_NM from N_UNIT_CODE where UNIT_CD = C.INPUT_UNIT) as INPUT_UNIT_NM  ");
            sb.AppendLine("     ,C.OUTPUT_UNIT ");
            sb.AppendLine("     ,(select UNIT_NM from N_UNIT_CODE where UNIT_CD = C.OUTPUT_UNIT) as OUTPUT_UNIT_NM   ");
            sb.AppendLine("     ,ISNULL(B.TOTAL_AMT,0) AS SOYO_AMT ");
            sb.AppendLine("     ,ISNULL(" + inst_amt + "*B.TOTAL_AMT,0) AS TOTAL_SOYO_AMT ");
            sb.AppendLine("     ,ISNULL(C.BAL_STOCK,0) AS BAL_STOCK  ");
            sb.AppendLine("     ,ISNULL(C.CVR_RATIO,0) AS CVR_RATIO  ");
            sb.AppendLine(" FROM N_ITEM_CODE A ");
            sb.AppendLine(" inner join N_ITEM_COMP B ");
            sb.AppendLine(" on A.ITEM_CD = B.ITEM_CD ");
            sb.AppendLine(" left outer join N_RAW_CODE C   ");
            sb.AppendLine(" on B.RAW_MAT_CD = C.RAW_MAT_CD	 ");
            sb.AppendLine(" left outer join N_CUST_CODE D	 ");
            sb.AppendLine(" on C.CUST_CD = D.CUST_CD	 ");
            sb.AppendLine(condition);


            Console.WriteLine(sb.ToString());

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }

        //작업지시서에서 제품선택 및 생산계획 클릭 시 나타나는 반제품
        public DataTable fn_Work_Half_Default_List(double inst_amt, string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select A.ITEM_CD");
            sb.AppendLine("     ,A.ITEM_NM ");
            sb.AppendLine("     ,B.HALF_ITEM_CD  ");
            sb.AppendLine("     ,C.ITEM_NM AS HALF_ITEM_NM  ");
            sb.AppendLine("     ,C.SPEC  ");
            sb.AppendLine("     ,C.CUST_CD    ");
            sb.AppendLine("     ,D.CUST_NM ");
            sb.AppendLine("     ,C.UNIT_CD ");
            sb.AppendLine("     ,(select UNIT_NM from N_UNIT_CODE where UNIT_CD = C.UNIT_CD) as UNIT_NM    ");
            sb.AppendLine("     ,B.TOTAL_AMT AS SOYO_AMT ");
            sb.AppendLine("     ," + inst_amt + "*B.TOTAL_AMT AS TOTAL_SOYO_AMT ");
            sb.AppendLine("     ,C.BAL_STOCK  ");
            sb.AppendLine(" FROM N_ITEM_CODE A ");
            sb.AppendLine(" left outer join N_ITEM_COMP_HALF B ");
            sb.AppendLine(" on A.ITEM_CD = B.ITEM_CD ");
            sb.AppendLine(" inner join N_ITEM_CODE C   ");
            sb.AppendLine(" on B.HALF_ITEM_CD = C.ITEM_CD	 ");
            sb.AppendLine(" left outer join N_CUST_CODE D	 ");
            sb.AppendLine(" on C.CUST_CD = D.CUST_CD	 ");
            sb.AppendLine(condition);

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_Work_Pln_Rm_Detail_List(string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select B.ITEM_CD");
            sb.AppendLine("     ,C.RAW_MAT_CD ");
            sb.AppendLine("     ,D.RAW_MAT_NM ");
            sb.AppendLine("     ,D.SPEC ");
            sb.AppendLine("     ,D.CUST_CD  ");
            sb.AppendLine("     ,E.CUST_NM   ");
            sb.AppendLine("     ,D.INPUT_UNIT ");
            sb.AppendLine("     ,(select UNIT_NM from N_UNIT_CODE where UNIT_CD = D.INPUT_UNIT) as INPUT_UNIT_NM  ");
            sb.AppendLine("     ,D.OUTPUT_UNIT ");
            sb.AppendLine("     ,(select UNIT_NM from N_UNIT_CODE where UNIT_CD = D.OUTPUT_UNIT) as OUTPUT_UNIT_NM   ");
            sb.AppendLine("     ,C.TOTAL_AMT AS SOYO_AMT ");
            sb.AppendLine("     ,B.TOTAL_AMT * C.TOTAL_AMT AS TOTAL_SOYO_AMT ");
            sb.AppendLine("     ,D.BAL_STOCK ");
            sb.AppendLine("     ,D.CVR_RATIO ");
            sb.AppendLine(" from F_PLAN A ");
            sb.AppendLine(" inner join F_PLAN_DETAIL B");
            sb.AppendLine(" on A.PLAN_DATE = B.PLAN_DATE ");
            sb.AppendLine("     and A.PLAN_CD = B.PLAN_CD   ");
            sb.AppendLine(" left outer join N_ITEM_COMP C  ");
            sb.AppendLine(" on B.ITEM_CD = C.ITEM_CD ");
            sb.AppendLine(" inner join N_RAW_CODE D   ");
            sb.AppendLine(" on C.RAW_MAT_CD = D.RAW_MAT_CD 	 ");
            sb.AppendLine(" left join N_CUST_CODE E	 ");
            sb.AppendLine(" on D.CUST_CD = E.CUST_CD	 ");
            sb.AppendLine(condition);

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }

        //작업지시서 원부재료 산출
        public DataTable fn_Work_Rm_Detail_List(string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select A.W_INST_DATE");
            sb.AppendLine("     ,A.W_INST_CD ");
            sb.AppendLine("     ,A.SEQ ");
            sb.AppendLine("     ,A.LOT_NO ");
            sb.AppendLine("     ,A.RAW_MAT_CD  ");
            sb.AppendLine("     ,B.RAW_MAT_NM   ");
            sb.AppendLine("     ,B.SPEC   ");
            sb.AppendLine("     ,B.CUST_CD ");
            sb.AppendLine("     ,C.CUST_NM ");
            sb.AppendLine("     ,B.INPUT_UNIT ");
            sb.AppendLine("     ,(select UNIT_NM from N_UNIT_CODE where UNIT_CD = B.INPUT_UNIT) as INPUT_UNIT_NM  ");
            sb.AppendLine("     ,B.OUTPUT_UNIT");
            sb.AppendLine("     ,(select UNIT_NM from N_UNIT_CODE where UNIT_CD = B.OUTPUT_UNIT) as OUTPUT_UNIT_NM   ");
            sb.AppendLine("     ,A.SOYO_AMT  ");
            sb.AppendLine("     ,A.TOTAL_AMT as TOTAL_SOYO_AMT");
            sb.AppendLine("     ,ISNULL(B.BAL_STOCK,0) AS BAL_STOCK  ");
            sb.AppendLine("     ,B.CVR_RATIO  ");
            sb.AppendLine("     ,F.LOT_NO  ");
            sb.AppendLine(" from F_WORK_INST_DETAIL A ");
            sb.AppendLine(" left outer join N_RAW_CODE B");
            sb.AppendLine(" on A.RAW_MAT_CD = B.RAW_MAT_CD");
            sb.AppendLine(" left outer join N_CUST_CODE C  ");
            sb.AppendLine(" on B.CUST_CD = C.CUST_CD	 ");
            sb.AppendLine(" inner join F_WORK_INST F ");
            sb.AppendLine(" on A.W_INST_DATE = F.W_INST_DATE ");
            sb.AppendLine("     and A.W_INST_CD = F.W_INST_CD ");
            sb.AppendLine(condition);
            sb.AppendLine(" order by A.SEQ ");
            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }

        //작업지시서 반제품 산출
        public DataTable fn_Work_Half_Detail_List(string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select A.W_INST_DATE");
            sb.AppendLine("     ,A.W_INST_CD ");
            sb.AppendLine("     ,A.SEQ ");
            sb.AppendLine("     ,A.LOT_NO ");
            sb.AppendLine("     ,A.HALF_ITEM_CD  ");
            sb.AppendLine("     ,B.ITEM_NM   ");
            sb.AppendLine("     ,B.SPEC   ");
            sb.AppendLine("     ,B.CUST_CD ");
            sb.AppendLine("     ,C.CUST_NM ");
            sb.AppendLine("     ,B.UNIT_CD ");
            sb.AppendLine("     ,(select UNIT_NM from N_UNIT_CODE where UNIT_CD = B.UNIT_CD) as UNIT_NM   ");
            sb.AppendLine("     ,A.SOYO_AMT  ");
            sb.AppendLine("     ,A.TOTAL_AMT as TOTAL_SOYO_AMT");
            sb.AppendLine("     ,ISNULL(B.BAL_STOCK,0) AS BAL_STOCK   ");
            sb.AppendLine(" from F_WORK_INST_HALF_DETAIL A  ");
            sb.AppendLine(" left outer join N_ITEM_CODE B");
            sb.AppendLine(" on A.HALF_ITEM_CD = B.ITEM_CD");
            sb.AppendLine("     and B.ITEM_GUBUN = '2'");
            sb.AppendLine(" left outer join N_CUST_CODE C  ");
            sb.AppendLine(" on B.CUST_CD = C.CUST_CD	 ");
            sb.AppendLine(condition);
            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_Work_Flow_Cnt(string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select count(*) as cnt");
            sb.AppendLine("from F_WORK_FLOW ");
            sb.AppendLine("where 1=1 ");
            sb.AppendLine(condition);

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }

        //작업지시 LOT_NO 여부 체크
        public DataTable fn_Work_Inst_Cnt(string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select count(*) as cnt");
            sb.AppendLine("from F_WORK_INST ");
            sb.AppendLine("where 1=1 ");
            sb.AppendLine(condition);

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_Work_Flow_List(string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("         A.LOT_NO ");
            sb.AppendLine("        ,A.FLOW_DATE ");
            sb.AppendLine("        ,B.W_INST_DATE ");
            sb.AppendLine("        ,B.W_INST_CD ");
            sb.AppendLine("        ,B.ITEM_CD ");
            sb.AppendLine("        ,C.ITEM_NM ");
            sb.AppendLine("        ,C.SPEC ");
            sb.AppendLine("        ,C.CHARGE_AMT ");
            sb.AppendLine("        ,B.INST_AMT ");
            sb.AppendLine("        ,C.PACK_AMT ");
            sb.AppendLine("        ,A.COMPLETE_YN ");
            sb.AppendLine("        ,B.RAW_OUT_YN ");
            sb.AppendLine("        ,B.POOR_WORK_YN ");
            sb.AppendLine("from F_WORK_FLOW A ");
            sb.AppendLine("left outer join F_WORK_INST B ");
            sb.AppendLine("on A.LOT_NO = B.LOT_NO ");
            sb.AppendLine("left outer join N_ITEM_CODE C ");
            sb.AppendLine("on B.ITEM_CD = C.ITEM_CD ");
            sb.AppendLine("where 1=1 ");
            sb.AppendLine(condition);
            sb.AppendLine("order by A.LOT_NO ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_Work_Flow_Detail(string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("         A.LOT_NO ");
            sb.AppendLine("        ,A.LOT_SUB ");
            sb.AppendLine("        ,A.F_STEP ");
            sb.AppendLine("        ,A.FLOW_CD ");
            sb.AppendLine("        ,A.SEQ ");
            sb.AppendLine("        ,A.F_SUB_DATE ");
            sb.AppendLine("        ,A.LOSS ");
            sb.AppendLine("        ,A.F_SUB_AMT ");
            sb.AppendLine("        ,A.POOR_CD ");
            sb.AppendLine("        ,A.POOR_AMT ");
            sb.AppendLine("        ,A.COMPLETE_YN ");
            sb.AppendLine("        ,A.CHECK_YN ");
            sb.AppendLine("        ,A.INPUT_YN ");
            sb.AppendLine("        ,C.FLOW_NM ");
            sb.AppendLine("from F_WORK_FLOW_DETAIL A ");
            sb.AppendLine("left outer join N_POOR_CODE B ");
            sb.AppendLine("on A.POOR_CD = B.POOR_CD ");
            sb.AppendLine("left outer join N_FLOW_CODE C ");
            sb.AppendLine("on A.FLOW_CD = C.FLOW_CD ");
            sb.AppendLine("where 1=1 ");
            sb.AppendLine(condition);
            sb.AppendLine("order by A.LOT_NO,A.F_STEP,A.LOT_SUB ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }

        // 제품입고식별표 리스트 
        public DataTable fn_Item_Input_List(string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("         A.LOT_NO ");
            sb.AppendLine("        ,B.LOT_SUB ");
            sb.AppendLine("        ,A.LOT_NO + RIGHT('00'+ convert(varchar, B.LOT_SUB), 3) as LOT_BAR ");
            sb.AppendLine("        ,B.F_SUB_DATE AS PACK_DATE ");
            sb.AppendLine("        ,A.ITEM_CD ");
            sb.AppendLine("        ,C.ITEM_NM");
            sb.AppendLine("        ,C.SPEC ");
            sb.AppendLine("        ,C.UNIT_CD ");
            sb.AppendLine("        ,(select UNIT_NM from N_UNIT_CODE where UNIT_CD = C.UNIT_CD) AS UNIT_NM ");
            sb.AppendLine("        ,B.F_SUB_AMT ");
            sb.AppendLine("        ,J.CUST_NM ");
            sb.AppendLine("        ,j.cust_CD ");
            //2019-11-04 이재원 : 제품입고 확정페이지를 위한 가격 출력 쿼리 생성
            sb.AppendLine("        ,(SELECT INPUT_PRICE from N_ITEM_CODE where Z.ITEM_CD = ITEM_CD) AS INPUT_PRICE");
            //2019-11-04 이재원 : 제품입고 확정 페이지를 위한 입고 여부를 확인하는 쿼리 생성
            sb.AppendLine("        ,Z.COMPLETE_YN");
            sb.AppendLine("        ,(SELECT LINK_CD from N_ITEM_CODE where Z.ITEM_CD = ITEM_CD) AS LINK_CD");

            sb.AppendLine("from F_WORK_FLOW A ");
            sb.AppendLine("left outer join F_WORK_FLOW_DETAIL B");
            sb.AppendLine("on A.LOT_NO = B.LOT_NO ");
            sb.AppendLine("inner join N_ITEM_CODE C  "); //유정훈 수정
            sb.AppendLine("on A.ITEM_CD = C.ITEM_CD   ");
            sb.AppendLine("left outer join N_FLOW_CODE D   ");
            sb.AppendLine("on B.FLOW_CD = D.FLOW_CD   ");
            sb.AppendLine("left outer join F_WORK_INST AS K on A.LOT_NO = K.LOT_NO ");
            sb.AppendLine("left outer join N_CUST_CODE AS J on C.CUST_CD = J.CUST_CD AND J.CUST_GUBUN = '1' ");
            sb.AppendLine("inner  join F_ITEM_INPUT Z    ");
            sb.AppendLine("on A.LOT_NO = Z.LOT_NO   ");
            sb.AppendLine(" and B.LOT_SUB = Z.LOT_SUB ");
            sb.AppendLine(" and B.F_STEP = Z.F_STEP  ");

            sb.AppendLine("where 1=1 ");
            sb.AppendLine(condition);
            sb.AppendLine("order by B.F_SUB_DATE");
            Debug.WriteLine("제품입고식별표 리스트 ");
            Debug.WriteLine(sb);
            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }

        //공정별 재공 현황
        public DataTable fn_Item_Flow_Con_List()  //condition = 현황
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("         A.ITEM_CD ");
            sb.AppendLine("         ,C.ITEM_NM ");
            sb.AppendLine("         ,C.SPEC ");
            sb.AppendLine("         ,A.LOT_NO ");
            sb.AppendLine("         ,B.W_INST_DATE ");
            sb.AppendLine("         ,STUFF(( ");
            sb.AppendLine("             select ',' + FLOW_NM+' '+ CONVERT(nvarchar(20),FLOOR(SUM(F_SUB_AMT))) +' '    ");
            sb.AppendLine("             from F_WORK_FLOW_DETAIL A  ");
            sb.AppendLine("             left outer join N_FLOW_CODE B  ");
            sb.AppendLine("             on A.FLOW_CD = B.FLOW_CD ");
            sb.AppendLine("             where A.LOT_NO = A.LOT_NO  ");
            sb.AppendLine("             group by A.LOT_NO,A.F_STEP,B.FLOW_CD,B.FLOW_NM  ");
            sb.AppendLine("             FOR XML PATH('')),1,1,'')as LOT_TOT_FLOW_NM  ");
            sb.AppendLine("from F_WORK_FLOW A ");
            sb.AppendLine("left outer join F_WORK_INST B ");
            sb.AppendLine("on A.LOT_NO = B.LOT_NO ");
            sb.AppendLine("left outer join N_ITEM_CODE C ");
            sb.AppendLine("on A.ITEM_CD = C.ITEM_CD ");
            sb.AppendLine("order by A.ITEM_CD,A.LOT_NO ");


            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }

        //공정별 재공 현황
        public DataTable fn_Item_Flow_Con_Dt_List(string txt_lot_no)  //condition = 현황 , dt = detail
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("         A.F_SUB_DATE ");
            sb.AppendLine("         ,A.LOT_NO ");
            sb.AppendLine("         ,A.LOT_NO + RIGHT('00'+ convert(varchar, A.LOT_SUB), 3) as LOT_BAR ");
            sb.AppendLine("         ,A.F_STEP ");
            sb.AppendLine("         ,A.LOT_SUB ");
            sb.AppendLine("         ,A.FLOW_CD ");
            sb.AppendLine("         ,B.FLOW_NM ");
            sb.AppendLine("         ,A.F_SUB_AMT ");
            sb.AppendLine("         ,A.LOSS ");
            sb.AppendLine("         ,A.POOR_AMT ");
            sb.AppendLine("         ,DATEDIFF(DD,F_SUB_DATE,GETDATE()) as OVER_DATE ");
            sb.AppendLine("         ,A.COMMENT ");
            sb.AppendLine("from F_WORK_FLOW_DETAIL A ");
            sb.AppendLine("left outer join N_FLOW_CODE B");
            sb.AppendLine("on A.FLOW_CD = B.FLOW_CD ");
            sb.AppendLine("where A.LOT_NO = '" + txt_lot_no + " '");
            sb.AppendLine("order by A.LOT_NO,A.F_STEP,A.LOT_SUB ");


            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }

        //공정별 기간 현황
        public DataTable fn_Flow_Product_List(string sba, string condition, string condition2)  //condition = 현황 , dt = detail
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("         A.F_SUB_DATE ");
            sb.AppendLine("         ,A.LOT_NO ");
            sb.AppendLine("         ,A.LOT_NO + RIGHT('00'+ convert(varchar, A.LOT_SUB), 3) as LOT_BAR ");
            sb.AppendLine("         ,A.F_STEP ");
            sb.AppendLine("         ,A.LOT_SUB ");
            sb.AppendLine("         ,A.FLOW_CD ");
            sb.AppendLine("         ,B.FLOW_NM ");
            sb.AppendLine("         ,A.F_SUB_AMT ");
            sb.AppendLine("         ,A.LOSS ");
            sb.AppendLine("         ,A.POOR_AMT ");
            sb.AppendLine("         ,DATEDIFF(DD,F_SUB_DATE,GETDATE()) as OVER_DATE ");
            sb.AppendLine("         ,C.INPUT_DATE ");
            sb.AppendLine("         ,A.COMMENT ");
            sb.AppendLine("         ,D.ITEM_NM ");
            sb.AppendLine("         ,F.POOR_NM");
            sb.AppendLine("         ,A.POOR_CD");
            sb.AppendLine("from  F_WORK_FLOW K ");
            sb.AppendLine("left outer join F_WORK_FLOW_DETAIL A  ");
            sb.AppendLine("on K.LOT_NO = A.LOT_NO ");
            sb.AppendLine("left outer join N_FLOW_CODE B");
            sb.AppendLine("on A.FLOW_CD = B.FLOW_CD ");
            sb.AppendLine("left outer join F_ITEM_INPUT C");
            sb.AppendLine("on A.LOT_NO = C.LOT_NO ");
            sb.AppendLine("LEFT OUTER JOIN N_ITEM_CODE D  ");
            sb.AppendLine("ON K.ITEM_CD = D.ITEM_CD ");

            sb.AppendLine("LEFT OUTER JOIN N_UNIT_CODE E   ");
            sb.AppendLine("ON B.POOR_TYPE_CD = E.UNIT_CD ");
            sb.AppendLine("left outer join N_POOR_CODE F    ");
            sb.AppendLine("on A.POOR_CD = F.POOR_CD ");

            sb.AppendLine("where 1=1");
            sb.AppendLine(sba);
            sb.AppendLine(condition);
            sb.AppendLine(condition2);
            sb.AppendLine(" and A.POOR_AMT > 0 ");
            sb.AppendLine("order by A.F_SUB_DATE ");
            //sb.AppendLine("order by A.LOT_NO,A.F_STEP,A.LOT_SUB ");


            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_Flow_Product_List(string condition)  //condition = 현황 , dt = detail
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("         A.F_SUB_DATE ");
            sb.AppendLine("         ,A.LOT_NO ");
            sb.AppendLine("         ,A.LOT_NO + RIGHT('00'+ convert(varchar, A.LOT_SUB), 3) as LOT_BAR ");
            sb.AppendLine("         ,A.F_STEP ");
            sb.AppendLine("         ,A.LOT_SUB ");
            sb.AppendLine("         ,A.FLOW_CD ");
            sb.AppendLine("         ,B.FLOW_NM ");
            sb.AppendLine("         ,A.F_SUB_AMT ");
            sb.AppendLine("         ,A.LOSS ");
            sb.AppendLine("         ,A.POOR_AMT ");
            sb.AppendLine("         ,DATEDIFF(DD,F_SUB_DATE,GETDATE()) as OVER_DATE ");
            sb.AppendLine("         ,C.INPUT_DATE ");
            sb.AppendLine("         ,A.COMMENT ");
            sb.AppendLine("         ,D.ITEM_NM ");
            sb.AppendLine("from  F_WORK_FLOW K ");
            sb.AppendLine("left outer join F_WORK_FLOW_DETAIL A  ");
            sb.AppendLine("on K.LOT_NO = A.LOT_NO ");
            sb.AppendLine("left outer join N_FLOW_CODE B");
            sb.AppendLine("on A.FLOW_CD = B.FLOW_CD ");
            sb.AppendLine("left outer join F_ITEM_INPUT C");
            sb.AppendLine("on A.LOT_NO = C.LOT_NO ");
            sb.AppendLine("LEFT OUTER JOIN N_ITEM_CODE D  ");
            sb.AppendLine("ON K.ITEM_CD = D.ITEM_CD ");
            sb.AppendLine("where 1=1");
            sb.AppendLine(condition);
            //sb.AppendLine("and A.FLOW_CD='0005' ");
            sb.AppendLine("order by A.F_SUB_DATE, A.LOT_NO,A.F_STEP,A.LOT_SUB ");
            Debug.WriteLine("생산현황");
            Debug.WriteLine(sb);

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }

        //작업지시서 원자재 출고 여부
        public DataTable fn_Work_Raw_Out_Yn(string txt_lot_no)  //condition = 현황 , dt = detail
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("         RAW_OUT_YN ");
            sb.AppendLine("from F_WORK_INST  ");
            sb.AppendLine("where LOT_NO = '" + txt_lot_no + "' ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }

        //제품 출고에서 제품재고 검색 

        //public DataTable fn_Item_In_Stock_List(string condition)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    sb.AppendLine("select A.LOT_NO,");
        //    sb.AppendLine("       A.LOT_SUB, ");
        //    sb.AppendLine("       A.INPUT_DATE, ");
        //    sb.AppendLine("       A.INPUT_CD, ");
        //    sb.AppendLine("       A.ITEM_CD, ");
        //    sb.AppendLine("       C.ITEM_NM,  ");
        //    sb.AppendLine("       C.SPEC,  ");
        //    sb.AppendLine("       ISNULL(C.OUTPUT_PRICE,0) AS OUTPUT_PRICE,  ");
        //    sb.AppendLine("       C.UNIT_CD,  ");
        //    sb.AppendLine("       (select UNIT_NM from N_UNIT_CODE where UNIT_CD = C.UNIT_CD) as UNIT_NM,  ");
        //    sb.AppendLine("       A.INPUT_AMT,    ");
        //    sb.AppendLine("       ISNULL(B.OUTPUT_AMT,0) AS OUTPUT_AMT, ");
        //    sb.AppendLine("       A.INPUT_AMT - ISNULL(B.OUTPUT_AMT,0) AS STOCK_AMT, ");
        //    sb.AppendLine("       D.CUST_CD, ");
        //    sb.AppendLine("       E.CUST_NM ");
        //    sb.AppendLine("from F_ITEM_INPUT A ");
        //    sb.AppendLine("left outer join (   ");
        //    sb.AppendLine("                 select BB.LOT_NO,BB.LOT_SUB,ISNULL(SUM(OUTPUT_AMT),0) AS OUTPUT_AMT ");
        //    sb.AppendLine("                 from F_ITEM_OUT AA  ");
        //    sb.AppendLine("                 inner join F_ITEM_OUT_DETAIL BB ");
        //    sb.AppendLine("                 on AA.OUTPUT_DATE = BB.OUTPUT_DATE ");
        //    sb.AppendLine("                     and AA.OUTPUT_CD = BB.OUTPUT_CD ");
        //    //sb.AppendLine("                     where AA.CUST_CD = '" + cust_cd + "' ");
        //    sb.AppendLine("                    group by LOT_NO,LOT_SUB) B ");
        //    sb.AppendLine(" on A.LOT_NO = B.LOT_NO ");
        //    sb.AppendLine("     and A.LOT_SUB = B.LOT_SUB ");
        //    sb.AppendLine(" left outer join N_ITEM_CODE C ");
        //    sb.AppendLine(" on A.ITEM_CD = C.ITEM_CD");
        //    sb.AppendLine(" left outer join F_WORK_INST D ");
        //    sb.AppendLine(" on A.LOT_NO = D.LOT_NO ");
        //    sb.AppendLine(" left outer join N_CUST_CODE E ");
        //    sb.AppendLine(" on D.CUST_CD = E.CUST_CD ");
        //    sb.AppendLine(" where 1=1 ");
        //    sb.AppendLine(condition);
        //    sb.AppendLine("     and A.INPUT_AMT - ISNULL(B.OUTPUT_AMT,0) > 0 ");
        //    //sb.AppendLine(" where D.CUST_CD = '" + cust_cd + "' ");
        //    //sb.AppendLine("     and A.INPUT_AMT - ISNULL(B.OUTPUT_AMT,0) > 0 ");

        //    //sb.AppendLine(condition);
        //    sb.AppendLine(" order by A.INPUT_DATE ");
        //    // sb.AppendLine(" order by A.LOT_NO,A.LOT_SUB ");


        //    SqlCommand sCommand = new SqlCommand(sb.ToString());
        //    if (sCommand.CommandText.Equals(null))
        //    {
        //        wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
        //        return null;
        //    }
        //    return wAdo.SqlCommandSelect(sCommand);
        //}


        public DataTable fn_Item_In_Stock_List(string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select A.LOT_NO,");
            sb.AppendLine("       A.LOT_SUB, ");
            sb.AppendLine("       A.INPUT_DATE, ");
            sb.AppendLine("       A.INPUT_CD, ");
            sb.AppendLine("       A.ITEM_CD, ");
            //이재원 과세구분 추가 + LINK_CD추가
            sb.AppendLine("       (SELECT VAT_CD FROM N_ITEM_CODE WHERE A.ITEM_CD = ITEM_CD) AS TAX_CD , ");
            sb.AppendLine("       (SELECT LINK_CD FROM N_ITEM_CODE WHERE A.ITEM_CD = ITEM_CD) AS LINK_CD , ");
            //
            sb.AppendLine("       C.ITEM_NM,  ");
            sb.AppendLine("       C.SPEC,  ");
            sb.AppendLine("       ISNULL(C.OUTPUT_PRICE,0) AS OUTPUT_PRICE,  ");
            sb.AppendLine("       C.UNIT_CD,  ");
            sb.AppendLine("       (select UNIT_NM from N_UNIT_CODE where UNIT_CD = C.UNIT_CD) as UNIT_NM,  ");
            sb.AppendLine("       A.INPUT_AMT,    ");
            sb.AppendLine("       ISNULL(B.OUTPUT_AMT,0) AS OUTPUT_AMT, ");
            sb.AppendLine("       A.INPUT_AMT - ISNULL(B.OUTPUT_AMT,0) AS STOCK_AMT, ");
            sb.AppendLine("       D.CUST_CD, ");
            sb.AppendLine("       E.CUST_NM ");
            sb.AppendLine("from F_ITEM_INPUT A ");
            sb.AppendLine("left outer join (   ");
            sb.AppendLine("                 select BB.LOT_NO,BB.LOT_SUB,ISNULL(SUM(OUTPUT_AMT),0) AS OUTPUT_AMT ");
            sb.AppendLine("                 from F_ITEM_OUT AA  ");
            sb.AppendLine("                 inner join F_ITEM_OUT_DETAIL BB ");
            sb.AppendLine("                 on AA.OUTPUT_DATE = BB.OUTPUT_DATE ");
            sb.AppendLine("                     and AA.OUTPUT_CD = BB.OUTPUT_CD ");
            //sb.AppendLine("                     where AA.CUST_CD = '" + cust_cd + "' ");
            sb.AppendLine("                    group by LOT_NO,LOT_SUB) B ");
            sb.AppendLine(" on A.LOT_NO = B.LOT_NO ");
            sb.AppendLine("     and A.LOT_SUB = B.LOT_SUB ");
            sb.AppendLine(" left outer join N_ITEM_CODE C ");
            sb.AppendLine(" on A.ITEM_CD = C.ITEM_CD");
            sb.AppendLine(" left outer join F_WORK_INST D ");
            sb.AppendLine(" on A.LOT_NO = D.LOT_NO ");
            sb.AppendLine(" left outer join N_CUST_CODE E ");
            sb.AppendLine(" on D.CUST_CD = E.CUST_CD ");
            sb.AppendLine(" where 1=1 ");
            sb.AppendLine(condition);
            sb.AppendLine("     and A.INPUT_AMT - ISNULL(B.OUTPUT_AMT,0) > 0 ");

            //if (Common.sp_pack_gubun.Equals("1")) // 장터지기 연동 업체의 경우 제품입고 확정이 수행된 이후의 제품만 노출되도록 
            //{
            //    sb.AppendLine("   and A.COMPLETE_YN = 'Y' ");
            //}

            //sb.AppendLine(" where D.CUST_CD = '" + cust_cd + "' ");
            //sb.AppendLine("     and A.INPUT_AMT - ISNULL(B.OUTPUT_AMT,0) > 0 ");

            //sb.AppendLine(condition);
            sb.AppendLine(" order by A.INPUT_DATE ");
            // sb.AppendLine(" order by A.LOT_NO,A.LOT_SUB ");

            Debug.WriteLine(sb);
            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }

        // 제품 출고 조회

        public DataTable fn_Item_Output_List(string condition, string condition2)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select A.OUTPUT_DATE,");
            sb.AppendLine("       A.OUTPUT_CD, ");
            sb.AppendLine("       A.CUST_CD, ");
            sb.AppendLine("       C.CUST_NM, ");
            sb.AppendLine("       A.STORAGE_CD, ");
            sb.AppendLine("       D.STORAGE_NM, ");
            sb.AppendLine("       B.ITEM_CNT, ");
            sb.AppendLine("       A.SELF_YN ");
            sb.AppendLine(" from F_ITEM_OUT A ");
            sb.AppendLine(" inner join(  ");
            sb.AppendLine("                 select OUTPUT_DATE,OUTPUT_CD,COUNT(*) AS ITEM_CNT ");
            sb.AppendLine("                 from F_ITEM_OUT_DETAIL A ");
            // 2019-09-06 유정훈 추가 
            sb.AppendLine("                 left outer join N_ITEM_CODE B ");
            sb.AppendLine("                 on A.ITEM_CD = B.ITEM_CD ");
            sb.AppendLine("                 left outer join N_CUST_CODE C ");
            sb.AppendLine("                 on A.CUST_CD = C.CUST_CD ");
            sb.AppendLine("                     and C.CUST_GUBUN = '1' ");
            // 2019-09-06 유정훈 끝 
            sb.AppendLine(condition);
            sb.AppendLine(condition2);
            sb.AppendLine("                 group by OUTPUT_DATE,OUTPUT_CD)B  ");
            sb.AppendLine(" on A.OUTPUT_DATE = B.OUTPUT_DATE  ");
            sb.AppendLine(" and A.OUTPUT_CD = B.OUTPUT_CD   ");
            sb.AppendLine(" left outer join N_CUST_CODE C  ");
            sb.AppendLine(" on A.CUST_CD = C.CUST_CD ");
            sb.AppendLine(" left outer join N_STORAGE_CODE D ");
            sb.AppendLine(" on A.STORAGE_CD = D.STORAGE_CD ");

            sb.AppendLine(condition);
            sb.AppendLine(" order by A.OUTPUT_DATE desc, A.OUTPUT_CD desc ");
            Debug.WriteLine(sb);
            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            return wAdo.SqlCommandSelect(sCommand);

        }
        public DataTable fn_Item_Output_Detail_List(string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select A.OUTPUT_DATE,");
            sb.AppendLine("       A.OUTPUT_CD, ");
            sb.AppendLine("       B.SEQ, ");
            sb.AppendLine("       A.CUST_CD, ");
            sb.AppendLine("       E.CUST_NM, ");
            sb.AppendLine("       B.LOT_NO, ");
            sb.AppendLine("       B.LOT_SUB, ");
            sb.AppendLine("       B.ITEM_CD, ");
            sb.AppendLine("       C.ITEM_NM, ");
            sb.AppendLine("       C.SPEC, ");
            sb.AppendLine("       B.UNIT_CD, ");
            sb.AppendLine("       D.UNIT_NM, ");
            sb.AppendLine("       B.OUTPUT_AMT, ");
            sb.AppendLine("       B.PRICE, ");
            sb.AppendLine("       B.TOTAL_MONEY, ");
            sb.AppendLine("       B.INPUT_DATE,");
            sb.AppendLine("       B.INPUT_CD, ");
            //이재원 VAT 불러오도록 수정
            sb.AppendLine("       ISNULL(B.TAX_CD, 0) AS TAX_CD, ");
            //
            sb.AppendLine("       B.CUST_CD AS CUST_CD2,");
            sb.AppendLine("       F.OUT_INST_YN, ");
            sb.AppendLine("       (select CUST_NM from N_CUST_CODE where CUST_CD = B.CUST_CD) AS CUST_NM2, ");
            sb.AppendLine("       B.J_INPUT_DATE, ");
            sb.AppendLine("       B.J_INPUT_CD, ");
            sb.AppendLine("       B.J_INPUT_SEQ ");
            sb.AppendLine(" from F_ITEM_OUT A");
            sb.AppendLine(" inner join F_ITEM_OUT_DETAIL B  ");
            sb.AppendLine(" on A.OUTPUT_DATE = B.OUTPUT_DATE  ");
            sb.AppendLine(" and A.OUTPUT_CD = B.OUTPUT_CD   ");
            sb.AppendLine(" left outer join N_ITEM_CODE C  ");
            sb.AppendLine(" on B.ITEM_CD = C.ITEM_CD ");
            sb.AppendLine(" left outer join N_UNIT_CODE D ");
            sb.AppendLine(" on B.UNIT_CD = D.UNIT_CD ");
            sb.AppendLine(" left outer join N_CUST_CODE E ");
            sb.AppendLine(" on A.CUST_CD = E.CUST_CD ");
            sb.AppendLine(" left outer join F_ITEM_OUT_INST F ");
            sb.AppendLine(" on B.OUTPUT_DATE = F.OUTPUT_DATE ");
            sb.AppendLine("     and B.OUTPUT_CD = F.OUTPUT_CD ");
            sb.AppendLine("     and B.SEQ = F.SEQ");

            sb.AppendLine(condition);
            sb.AppendLine(" order by ITEM_CD");
            Debug.WriteLine(sb);
            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            return wAdo.SqlCommandSelect(sCommand);

        }

        public DataTable fn_Item_Output_Detail_List(string condition, string condition2)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select A.OUTPUT_DATE,");
            sb.AppendLine("       A.OUTPUT_CD, ");
            sb.AppendLine("       B.SEQ, ");
            sb.AppendLine("       A.CUST_CD, ");
            sb.AppendLine("       E.CUST_NM, ");
            sb.AppendLine("       B.LOT_NO, ");
            sb.AppendLine("       B.LOT_SUB, ");
            sb.AppendLine("       B.ITEM_CD, ");
            sb.AppendLine("       C.ITEM_NM, ");
            sb.AppendLine("       C.SPEC, ");
            sb.AppendLine("       B.UNIT_CD, ");
            sb.AppendLine("       D.UNIT_NM, ");
            sb.AppendLine("       B.OUTPUT_AMT, ");
            sb.AppendLine("       B.PRICE, ");
            sb.AppendLine("       B.TOTAL_MONEY, ");
            sb.AppendLine("       B.INPUT_DATE,");
            sb.AppendLine("       B.INPUT_CD, ");
            sb.AppendLine("       B.CUST_CD AS CUST_CD2,");
            sb.AppendLine("       F.OUT_INST_YN, ");
            sb.AppendLine("       (select CUST_NM from N_CUST_CODE where CUST_CD = B.CUST_CD) AS CUST_NM2 ");
            sb.AppendLine(" from F_ITEM_OUT A");
            sb.AppendLine(" inner join F_ITEM_OUT_DETAIL B  ");
            sb.AppendLine(" on A.OUTPUT_DATE = B.OUTPUT_DATE  ");
            sb.AppendLine(" and A.OUTPUT_CD = B.OUTPUT_CD   ");
            sb.AppendLine(" left outer join N_ITEM_CODE C  ");
            sb.AppendLine(" on B.ITEM_CD = C.ITEM_CD ");
            sb.AppendLine(" left outer join N_UNIT_CODE D ");
            sb.AppendLine(" on B.UNIT_CD = D.UNIT_CD ");
            sb.AppendLine(" left outer join N_CUST_CODE E ");
            sb.AppendLine(" on A.CUST_CD = E.CUST_CD ");
            sb.AppendLine(" left outer join F_ITEM_OUT_INST F ");
            sb.AppendLine(" on B.OUTPUT_DATE = F.OUTPUT_DATE ");
            sb.AppendLine("     and B.OUTPUT_CD = F.OUTPUT_CD ");
            sb.AppendLine("     and B.SEQ = F.SEQ");

            sb.AppendLine(condition);
            sb.AppendLine(condition2);
            sb.AppendLine(" order by A.OUTPUT_DATE, A.OUTPUT_CD, B.SEQ");
            Debug.WriteLine(sb);

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            return wAdo.SqlCommandSelect(sCommand);

        }

        //제품재고현황 
        public DataTable fn_Item_Stock_List(string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select A.ITEM_CD,");
            sb.AppendLine("       A.ITEM_NM, ");
            sb.AppendLine("       A.SPEC, ");
            sb.AppendLine("        isnull(A.BASIC_STOCK,0) as BASIC_STOCK,  ");
            sb.AppendLine("        isnull(A.BAL_STOCK,0) as BAL_STOCK,  ");
            sb.AppendLine("       isnull(A.PROP_STOCK,0) as PROP_STOCK ");
            sb.AppendLine(" from N_ITEM_CODE A");
            sb.AppendLine(condition);
            sb.AppendLine(" order by A.ITEM_CD ");
            Debug.WriteLine(sb);
            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            return wAdo.SqlCommandSelect(sCommand);
        }

        //제품재고 상세현황
        public DataTable fn_Item_Detail_Stock_List(string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select A.INPUT_DATE, A.LOT_NO, ISNULL(A.INPUT_AMT,0) AS 입고량, ISNULL(B.OUTPUT_AMT,0) AS 출고량,  ISNULL(A.INPUT_AMT,0)- ISNULL(B.OUTPUT_AMT,0) AS 재고량   ");
            sb.AppendLine("from F_ITEM_INPUT A  ");
            sb.AppendLine("left outer join F_ITEM_OUT_DETAIL B  ");
            sb.AppendLine("on A.LOT_NO = B.LOT_NO");
            sb.AppendLine("    and A.LOT_SUB = B.LOT_SUB  ");
            sb.AppendLine("where A.ITEM_CD = '" + condition + "' ");
            sb.AppendLine("order by A.LOT_NO");
            Debug.WriteLine("제품 재고 상세현황");
            
            Debug.WriteLine(sb);

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            return wAdo.SqlCommandSelect(sCommand);
        }

        //거래처별제품재고현황 
        public DataTable fn_Cust_Stock_List(string condition)
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SELECT C.CUST_NM,  ");
            sb.AppendLine("SUM(ISNULL(A.INPUT_AMT,0)) AS 입고량, SUM(ISNULL(B.OUTPUT_AMT,0)) AS 출고량,  SUM(ISNULL(A.INPUT_AMT,0)- ISNULL(B.OUTPUT_AMT,0)) AS 재고량  ");
            sb.AppendLine("from F_ITEM_INPUT A  ");
            sb.AppendLine("left outer join F_ITEM_OUT_DETAIL B  ");
            sb.AppendLine("on A.LOT_NO = B.LOT_NO and A.LOT_SUB = B.LOT_SUB    ");
            sb.AppendLine("right JOIN N_CUST_CODE C ON B.CUST_CD = C.CUST_CD  ");
            sb.AppendLine("GROUP BY CUST_NM  ");
            sb.AppendLine(condition);

            Debug.WriteLine(sb);
            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            return wAdo.SqlCommandSelect(sCommand);

        }

        //거래처별제품재고 상세현황
        public DataTable fn_Cust_Detail_Stock_List(string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select A.INPUT_DATE, A.LOT_NO, D.ITEM_CD,ISNULL(A.INPUT_AMT,0) AS 입고량,  ");
            sb.AppendLine("ISNULL(B.OUTPUT_AMT,0) AS 출고량,  ISNULL(A.INPUT_AMT,0)- ISNULL(B.OUTPUT_AMT,0) AS 재고량  ");
            sb.AppendLine(" ,C.CUST_NM,D.ITEM_NM,D.SPEC  ");
            sb.AppendLine("from F_ITEM_INPUT A  ");
            sb.AppendLine("left outer join F_ITEM_OUT_DETAIL B    ");
            sb.AppendLine("on A.LOT_NO = B.LOT_NO and A.LOT_SUB = B.LOT_SUB   ");
            sb.AppendLine("INNER JOIN N_CUST_CODE C ON B.CUST_CD = C.CUST_CD  ");
            sb.AppendLine("INNER JOIN N_ITEM_CODE D ON A.ITEM_CD = D.ITEM_CD  ");
            sb.AppendLine("WHERE C.CUST_NM = '" + condition + "' ");
            sb.AppendLine("order by A.LOT_NO");
            Debug.WriteLine(sb);
            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            return wAdo.SqlCommandSelect(sCommand);
        }

        //원자재 출고 현황
        public DataTable fn_Raw_Output_List(string condition)
        {
            StringBuilder sb = new StringBuilder();

            //---hsp 출력물하면서 수정
            sb.AppendLine("select '' as no, A.OUTPUT_DATE AS 출고일자,");
            sb.AppendLine("       A.RAW_MAT_CD AS 원부재료코드, ");
            sb.AppendLine("       A.LOT_NO AS 제조번호, ");
            sb.AppendLine("       B.RAW_MAT_NM AS 원부재료명, ");
            sb.AppendLine("       B.SPEC AS  규격, ");
            sb.AppendLine("       ISNULL(A.TOTAL_AMT,0) AS 투입량 ");

            sb.AppendLine(" from F_RAW_OUTPUT A");
            sb.AppendLine(" left outer join N_RAW_CODE B ");
            sb.AppendLine(" on A.RAW_MAT_CD = B.RAW_MAT_CD  ");
            sb.AppendLine(condition);
            sb.AppendLine(" order by A.OUTPUT_DATE ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            return wAdo.SqlCommandSelect(sCommand);

        }

        // LOT추적조회 
        public DataTable fn_Lot_Item_Srch_List(string txt_lot_bar)  //condition = 현황
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("         A.ITEM_CD ");
            sb.AppendLine("         ,A.FLOW_DATE ");
            sb.AppendLine("         ,A.ITEM_CD ");
            sb.AppendLine("         ,D.ITEM_NM ");
            sb.AppendLine("         ,D.SPEC ");
            sb.AppendLine("         ,A.COMPLETE_YN ");
            sb.AppendLine("         ,C.W_INST_DATE ");
            sb.AppendLine("         ,C.W_INST_CD ");
            sb.AppendLine("         ,C.INST_AMT ");
            sb.AppendLine("from F_WORK_FLOW A ");
            sb.AppendLine("inner join ( ");
            sb.AppendLine("    select LOT_NO  ");
            sb.AppendLine("    from F_WORK_FLOW_DETAIL  ");
            sb.AppendLine("    where LOT_NO + RIGHT('00'+ convert(varchar, LOT_SUB), 3) like '" + txt_lot_bar + "%'    ");
            sb.AppendLine("    group by LOT_NO  ");
            sb.AppendLine("    )B  ");
            sb.AppendLine("on A.LOT_NO = B.LOT_NO ");
            sb.AppendLine("left outer join F_WORK_INST C ");
            sb.AppendLine("on A.LOT_NO = C.LOT_NO ");
            sb.AppendLine("left outer join N_ITEM_CODE D ");
            sb.AppendLine("on A.ITEM_CD = D.ITEM_CD ");
            Debug.WriteLine("라트 추적조회 ");
            Debug.WriteLine(sb);
            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }

        //LOT 추적조회 상세 
        public DataTable fn_Lot_Detail(string txt_lot_bar)  //condition = 현황
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("          C.F_SUB_DATE ");
            sb.AppendLine("         ,D.RAW_MAT_CD ");
            sb.AppendLine("         ,D.RAW_MAT_NM ");
            sb.AppendLine("         ,D.SPEC ");
            sb.AppendLine("         ,B.TOTAL_AMT ");
            sb.AppendLine("         ,A.W_INST_DATE ");
            sb.AppendLine("         ,A.W_INST_CD ");
            sb.AppendLine("         ,C.FLOW_CD ");
            sb.AppendLine("         ,E.FLOW_NM ");
            sb.AppendLine("         ,C.F_SUB_AMT ");
            sb.AppendLine("         ,C.LOSS ");
            sb.AppendLine("         ,C.POOR_AMT ");
            sb.AppendLine("         ,A.LOT_NO ");
            sb.AppendLine("         ,A.ITEM_CD ");
            sb.AppendLine("         ,A.CUST_CD AS SALES_CUST_CD ");
            sb.AppendLine("         ,A.INST_AMT");
            sb.AppendLine("         ,(select CUST_NM from N_CUST_CODE where CUST_CD = A.CUST_CD and CUST_GUBUN = '1') AS SALES_CUST_NM ");
            sb.AppendLine("         ,C.F_STEP ");
            sb.AppendLine("         ,C.F_SUB_AMT ");
            sb.AppendLine("         ,F.OUTPUT_DATE ");
            sb.AppendLine("         ,G.INPUT_DATE ");
            sb.AppendLine("         ,G.CUST_CD AS PUR_CUST_CD ");
            sb.AppendLine("         ,G.INPUT_DATE ");
            sb.AppendLine("         ,X.ITEM_NM ");
            sb.AppendLine("         ,(select CUST_NM from N_CUST_CODE where CUST_CD = G.CUST_CD and CUST_GUBUN = '2') AS PUR_CUST_NM");
            sb.AppendLine("from F_WORK_INST A ");
            sb.AppendLine("inner join F_WORK_INST_DETAIL B");
            sb.AppendLine("on A.W_INST_DATE = B.W_INST_DATE ");
            sb.AppendLine("     and A.W_INST_CD = B.W_INST_CD ");
            sb.AppendLine("inner join F_WORK_FLOW_DETAIL C");
            sb.AppendLine("on A.LOT_NO = C.LOT_NO");
            sb.AppendLine("inner join N_RAW_CODE D ");
            sb.AppendLine("on B.RAW_MAT_CD = D.RAW_MAT_CD ");
            sb.AppendLine("left outer join N_FLOW_CODE E ");
            sb.AppendLine("on C.FLOW_CD = E.FLOW_CD ");
            sb.AppendLine("left outer join F_RAW_OUTPUT F ");
            sb.AppendLine("on A.LOT_NO = F.LOT_NO ");
            sb.AppendLine(" and B.RAW_MAT_CD = F.RAW_MAT_CD ");
            sb.AppendLine("left outer join F_RAW_INPUT G ");
            sb.AppendLine("on F.INPUT_DATE = G.INPUT_DATE ");
            sb.AppendLine("     and F.INPUT_CD = G.INPUT_CD ");
            sb.AppendLine("left outer join F_RAW_DETAIL H ");
            sb.AppendLine("on F.INPUT_DATE = H.INPUT_DATE ");
            sb.AppendLine("     and F.INPUT_CD = H.INPUT_CD ");
            sb.AppendLine("     and F.INPUT_SEQ = H.SEQ ");
            sb.AppendLine("left outer join N_ITEM_CODE X ON A.ITEM_CD = X.ITEM_CD ");            
            sb.AppendLine(" where A.LOT_NO = '" +txt_lot_bar + "' ");
            sb.AppendLine("    ORDER BY E.FLOW_CD,B.RAW_MAT_CD  ");
            Debug.WriteLine("라트추적조회 상세 !~");
            Debug.WriteLine(sb);
            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable Lot_List(
           string dtp_start_date,
           string dtp_end_date,
           string txt_item_nm

           )  //condition = 현황
        {
            StringBuilder sb = new StringBuilder();
            //sb.AppendLine("SELECT C.ITEM_CD,C.ITEM_NM,C.SPEC,A.F_SUB_DATE,A.LOT_NO ");
            //sb.AppendLine(",SUM(A.F_SUB_AMT) AS '생산량' ");
            //sb.AppendLine(",SUM(A.LOSS) AS LOSS  ");
            //sb.AppendLine(",SUM(A.POOR_AMT) AS '불량'  ");
            //sb.AppendLine("FROM F_WORK_FLOW_DETAIL A  ");
            //sb.AppendLine("INNER JOIN F_WORK_FLOW B ON A.LOT_NO = B.LOT_NO  ");
            //sb.AppendLine("INNER JOIN N_ITEM_CODE C ON B.ITEM_CD = C.ITEM_CD  ");
            //sb.AppendLine("WHERE A.F_SUB_DATE > '" + dtp_start_date + "' AND A.F_SUB_DATE < '" + dtp_end_date + "'  ");

            //sb.AppendLine("GROUP BY A.LOT_NO, A.F_SUB_DATE,C.ITEM_CD, C.ITEM_NM,C.SPEC    ");
            //sb.AppendLine("ORDER BY F_SUB_DATE  ");

            //sb.AppendLine("  SELECT '' AS no, A.ITEM_CD,  MAX(C.ITEM_NM) AS ITEM_NM, MAX(C.SPEC) AS SPEC ");
            //sb.AppendLine("  	, SUM(E.F_SUB_AMT) AS F_SUB_AMT, SUM(E.POOR_AMT) AS POOR_AMT, SUM(E.LOSS) AS LOSS  ");
            //sb.AppendLine("  FROM F_WORK_INST A   ");
            //sb.AppendLine("  LEFT OUTER JOIN N_ITEM_CODE C ON A.ITEM_CD = C.ITEM_CD     ");
            //sb.AppendLine("  INNER JOIN  (   ");
            //sb.AppendLine("  			SELECT D.LOT_NO, SUM(C.F_SUB_AMT) AS F_SUB_AMT, SUM(C.POOR_AMT) AS POOR_AMT, SUM(C.LOSS) AS LOSS     ");
            //sb.AppendLine("  			  FROM F_WORK_FLOW D   ");
            //sb.AppendLine("  				LEFT OUTER JOIN F_WORK_FLOW_DETAIL C ON D.LOT_NO = C.LOT_NO   ");
            //sb.AppendLine("  			GROUP BY D.LOT_NO)    E ON A.LOT_NO = E.LOT_NO ");
            //sb.AppendLine("   WHERE 1=1  ");
            //sb.AppendLine("     AND A.COMPLETE_YN = 'Y'   ");
            //sb.AppendLine("     AND C.ITEM_NM LIKE '%" + sItem + "%' ");

            //sb.AppendLine("     AND A.W_INST_DATE BETWEEN @p_from AND @p_to ");
            //sb.AppendLine("  GROUP BY A.ITEM_CD ");
            //sb.AppendLine("  ORDER BY A.ITEM_CD ASC ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }

        // 공정검사 요청현황  
        public DataTable fn_Flow_Chk_Req_List(string condition)  //condition = 현황
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("         A.LOT_NO ");
            sb.AppendLine("         ,A.ITEM_CD ");
            sb.AppendLine("         ,C.ITEM_NM ");
            sb.AppendLine("         ,C.SPEC ");
            sb.AppendLine("         ,B.F_SUB_DATE ");
            sb.AppendLine("         ,B.LOT_SUB ");
            sb.AppendLine("         ,B.FLOW_CD ");
            sb.AppendLine("         ,D.FLOW_NM ");
            sb.AppendLine("         ,B.F_STEP ");
            sb.AppendLine("         ,B.F_SUB_AMT ");
            sb.AppendLine("         ,B.COMPLETE_YN ");
            sb.AppendLine("         ,B.CHECK_YN ");
            sb.AppendLine("         ,B.ITEM_CHECK_YN ");
            sb.AppendLine("         ,C.ITEM_GUBUN ");
            sb.AppendLine("         ,f.MAP ");
            sb.AppendLine("         ,isnull(f.MAP_SIZE,0) as MAP_SIZE ");
            sb.AppendLine("         ,F.EXTERIOR ");            //sb.AppendLine("         ,E.MEASURE_CNT ");
            //sb.AppendLine("         ,E.EVA_GUBUN ");
            sb.AppendLine("         ,(select S_CODE_NM from [SM_FACTORY_COM].[dbo].[T_S_CODE] where L_CODE = '400' and S_CODE = C.ITEM_GUBUN)  AS ITEM_GUBUN_NM "); //제품구분 코드 600
            sb.AppendLine("         ,(select S_CODE_NM from [SM_FACTORY_COM].[dbo].[T_S_CODE] where L_CODE = '620' and S_CODE = E.EVA_GUBUN)  AS EVA_GUBUN_NM "); //평가구분 코드 620
            sb.AppendLine("         ,(select S_CODE_NM from [SM_FACTORY_COM].[dbo].[T_S_CODE] where L_CODE = '610' and S_CODE = B.CHECK_YN)  AS CHECK_NM "); //평가구분 코드 620
            sb.AppendLine("         , case when isnull(F.PASS_YN,'N') ='Y' then '합격' else '불합격' end PASS_YN ");
            sb.AppendLine("from F_WORK_FLOW A ");
            sb.AppendLine("inner join F_WORK_FLOW_DETAIL B  ");
            sb.AppendLine("on A.LOT_NO = B.LOT_NO");
            sb.AppendLine("left outer join N_ITEM_CODE C  ");
            sb.AppendLine("on A.ITEM_CD = C.ITEM_CD");
            sb.AppendLine("left outer join N_FLOW_CODE D ");
            sb.AppendLine("on B.FLOW_CD = D.FLOW_CD ");
            sb.AppendLine("left outer join N_FLOW_CHK E ");
            sb.AppendLine("on A.ITEM_CD = E.ITEM_CD ");
            sb.AppendLine(" and B.FLOW_CD = E.FLOW_CD ");
            sb.AppendLine("left outer join F_FLOW_CHK F ");
            sb.AppendLine("on A.LOT_NO = F.LOT_NO ");
            sb.AppendLine(" and B.LOT_SUB = F.LOT_SUB ");
            sb.AppendLine(" and B.F_STEP = F.F_STEP ");
            sb.AppendLine("where 1=1 ");
            sb.AppendLine(condition);
            sb.AppendLine("order by A.LOT_NO desc,B.LOT_SUB ");
            Debug.WriteLine("공정검사 요청현황 ");

            Debug.WriteLine(sb);
            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }


        // 제품검사 요청현황 쿼리가 같음
        public DataTable fn_Item_Chk_Req_List(string condition)  //condition = 현황
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("         A.LOT_NO ");
            sb.AppendLine("         ,A.ITEM_CD ");
            sb.AppendLine("         ,C.ITEM_NM ");
            sb.AppendLine("         ,C.SPEC ");
            sb.AppendLine("         ,B.F_SUB_DATE ");
            sb.AppendLine("         ,B.LOT_SUB ");
            sb.AppendLine("         ,B.FLOW_CD ");
            sb.AppendLine("         ,D.FLOW_NM ");
            sb.AppendLine("         ,B.F_STEP ");
            sb.AppendLine("         ,B.F_SUB_AMT ");
            sb.AppendLine("         ,B.COMPLETE_YN ");
            sb.AppendLine("         ,B.CHECK_YN ");
            sb.AppendLine("         ,B.ITEM_CHECK_YN ");
            sb.AppendLine("         ,C.ITEM_GUBUN ");
            //sb.AppendLine("         ,E.MEASURE_CNT ");
            //sb.AppendLine("         ,E.EVA_GUBUN ");
            sb.AppendLine("         ,(select S_CODE_NM from [SM_FACTORY_COM].[dbo].[T_S_CODE] where L_CODE = '400' and S_CODE = C.ITEM_GUBUN)  AS ITEM_GUBUN_NM "); //제품구분 코드 600
            sb.AppendLine("         ,(select S_CODE_NM from [SM_FACTORY_COM].[dbo].[T_S_CODE] where L_CODE = '620' and S_CODE = E.EVA_GUBUN)  AS EVA_GUBUN_NM "); //평가구분 코드 620
            sb.AppendLine("         ,(select S_CODE_NM from [SM_FACTORY_COM].[dbo].[T_S_CODE] where L_CODE = '610' and S_CODE = B.ITEM_CHECK_YN)  AS ITEM_CHECK_NM "); //평가구분 코드 620
           // sb.AppendLine("         ,Case when A.PASS_YN ='Y' then '합격' else '불합격' end PASS_YN ");
            sb.AppendLine("from F_WORK_FLOW A ");
            sb.AppendLine("inner join F_WORK_FLOW_DETAIL B  ");
            sb.AppendLine("on A.LOT_NO = B.LOT_NO");
            sb.AppendLine("left outer join N_ITEM_CODE C  ");
            sb.AppendLine("on A.ITEM_CD = C.ITEM_CD");
            sb.AppendLine("left outer join N_FLOW_CODE D ");
            sb.AppendLine("on B.FLOW_CD = D.FLOW_CD ");
            sb.AppendLine("left outer join N_ITEM_CHK E ");
            sb.AppendLine("on A.ITEM_CD = E.ITEM_CD ");
            sb.AppendLine("left outer join F_ITEM_CHK F ");
            sb.AppendLine("on A.LOT_NO = F.LOT_NO ");
            sb.AppendLine(" and B.LOT_SUB = F.LOT_SUB ");
            sb.AppendLine(" and B.F_STEP = F.F_STEP ");
            sb.AppendLine("where 1=1 ");
            sb.AppendLine(condition);
            sb.AppendLine("order by A.LOT_NO desc,B.LOT_SUB ");
            Debug.WriteLine("제품검사");
            Debug.WriteLine(sb);
            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }

        // 공정검사 현황이 요청이 아닌 미완료 혹은 완료일 경우
        public DataTable fn_Flow_Chk_Main_List(string condition)  //condition = 현황
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("          A.F_CHK_DATE ");
            sb.AppendLine("         ,A.LOT_NO ");
            sb.AppendLine("         ,A.LOT_SUB ");
            sb.AppendLine("         ,A.ITEM_CD ");
            sb.AppendLine("         ,C.ITEM_NM ");
            sb.AppendLine("         ,C.SPEC ");

            sb.AppendLine("         ,A.FLOW_CD ");
            sb.AppendLine("         ,D.FLOW_NM ");
            sb.AppendLine("         ,A.F_STEP ");
            sb.AppendLine("         ,A.F_SUB_AMT ");
            sb.AppendLine("         ,B.COMPLETE_YN ");
            sb.AppendLine("         ,B.CHECK_YN ");
            sb.AppendLine("         ,C.ITEM_GUBUN ");
            sb.AppendLine("         ,A.MEASURE_CNT ");
            //sb.AppendLine("         ,A.EVA_GUBUN ");
            sb.AppendLine("         ,(select S_CODE_NM from [SM_FACTORY_COM].[dbo].[T_S_CODE] where L_CODE = '400' and S_CODE = C.ITEM_GUBUN)  AS ITEM_GUBUN_NM "); //제품구분 코드 600
            sb.AppendLine("         ,(select S_CODE_NM from [SM_FACTORY_COM].[dbo].[T_S_CODE] where L_CODE = '620' and S_CODE = E.EVA_GUBUN)  AS EVA_GUBUN_NM "); //평가구분 코드 620
            sb.AppendLine("         ,(select S_CODE_NM from [SM_FACTORY_COM].[dbo].[T_S_CODE] where L_CODE = '610' and S_CODE = B.CHECK_YN)  AS CHECK_NM "); //평가구분 코드 620
            sb.AppendLine("         ,A.MAP ");
            sb.AppendLine("         ,A.MAP_SIZE ");
            sb.AppendLine("         ,Case when A.PASS_YN ='Y' then '합격' else '불합격' end PASS_YN ");
            sb.AppendLine("         ,A.EXTERIOR");
            sb.AppendLine("from F_FLOW_CHK A ");
            sb.AppendLine("left outer join F_WORK_FLOW_DETAIL B  ");
            sb.AppendLine("on A.LOT_NO = B.LOT_NO");
            sb.AppendLine(" and A.LOT_SUB = B.LOT_SUB");
            sb.AppendLine(" and A.F_STEP = B.F_STEP");
            sb.AppendLine("left outer join N_ITEM_CODE C  ");
            sb.AppendLine("on A.ITEM_CD = C.ITEM_CD");
            sb.AppendLine("left outer join N_FLOW_CODE D ");
            sb.AppendLine("on A.FLOW_CD = D.FLOW_CD ");
            sb.AppendLine("left outer join N_FLOW_CHK E ");
            sb.AppendLine("on A.ITEM_CD = E.ITEM_CD ");
            sb.AppendLine(" and B.FLOW_CD = E.FLOW_CD ");
            sb.AppendLine(" where 1=1 ");
            sb.AppendLine(condition);
            Debug.WriteLine("공정검사 현황이 요청이 아닌 미완료 혹은 완료일 경우");
            Debug.WriteLine(sb);
            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }

        // 제품 현황이 요청이 아닌 미완료 혹은 완료일 경우
        public DataTable fn_Item_Chk_Main_List(string condition)  //condition = 현황
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("          A.F_CHK_DATE ");
            sb.AppendLine("         ,A.LOT_NO ");
            sb.AppendLine("         ,A.ITEM_CD ");
            sb.AppendLine("         ,C.ITEM_NM ");
            sb.AppendLine("         ,C.SPEC ");
            sb.AppendLine("         ,A.LOT_SUB ");
            sb.AppendLine("         ,B.FLOW_CD ");
            sb.AppendLine("         ,D.FLOW_NM ");
            sb.AppendLine("         ,A.F_STEP ");
            sb.AppendLine("         ,A.F_SUB_AMT ");
            sb.AppendLine("         ,B.COMPLETE_YN ");
            sb.AppendLine("         ,B.ITEM_CHECK_YN ");
            sb.AppendLine("         ,C.ITEM_GUBUN ");
            sb.AppendLine("         ,A.MEASURE_CNT ");
            //sb.AppendLine("         ,A.EVA_GUBUN ");
            sb.AppendLine("         ,(select S_CODE_NM from [SM_FACTORY_COM].[dbo].[T_S_CODE] where L_CODE = '400' and S_CODE = C.ITEM_GUBUN)  AS ITEM_GUBUN_NM "); //제품구분 코드 600
            sb.AppendLine("         ,(select S_CODE_NM from [SM_FACTORY_COM].[dbo].[T_S_CODE] where L_CODE = '620' and S_CODE = E.EVA_GUBUN)  AS EVA_GUBUN_NM "); //평가구분 코드 620
            sb.AppendLine("         ,(select S_CODE_NM from [SM_FACTORY_COM].[dbo].[T_S_CODE] where L_CODE = '610' and S_CODE = B.ITEM_CHECK_YN)  AS ITEM_CHECK_NM "); //평가구분 코드 620
            sb.AppendLine("         ,A.MAP ");
            sb.AppendLine("         ,A.MAP_SIZE ");
            sb.AppendLine("         ,A.PASS_YN ");
            sb.AppendLine("from F_ITEM_CHK A ");
            sb.AppendLine("left outer join F_WORK_FLOW_DETAIL B  ");
            sb.AppendLine("on A.LOT_NO = B.LOT_NO");
            sb.AppendLine(" and A.LOT_SUB = B.LOT_SUB");
            sb.AppendLine(" and A.F_STEP = B.F_STEP");
            sb.AppendLine("left outer join N_ITEM_CODE C  ");
            sb.AppendLine("on A.ITEM_CD = C.ITEM_CD");
            sb.AppendLine("left outer join N_FLOW_CODE D  ");
            sb.AppendLine("on B.FLOW_CD = D.FLOW_CD");
            sb.AppendLine("left outer join N_ITEM_CHK E ");
            sb.AppendLine("on A.ITEM_CD = E.ITEM_CD ");
            sb.AppendLine(" where 1=1 ");
            sb.AppendLine(condition);

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }

        // 공정검사 시작 전 공정검사 기준등록 확인했는지 체크 
        public DataTable fn_Flow_Chk_Cnt(string condition)  //condition = 현황
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select count(*) as cnt ");
            sb.AppendLine("from N_FLOW_CHK  ");
            sb.AppendLine("where 1=1 ");
            sb.AppendLine(condition);

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }

        //제품검사 Count
        public DataTable fn_Item_Chk_Cnt(string condition)  //condition = 현황
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select count(*) as cnt ");
            sb.AppendLine("from N_ITEM_CHK  ");
            sb.AppendLine("where 1=1 ");
            sb.AppendLine(condition);

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }

        //공정이동표 제품 SUB_NO의 현재 공정진행 데이터 추출
        public DataTable fn_wf_LotNo_Sub_Status(string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select A.LOT_NO,A.LOT_SUB,ISNULL(A.F_STEP,0)AS F_STEP,A.FLOW_CD,C.FLOW_NM,A.F_SUB_AMT,A.F_SUB_DATE");
            sb.AppendLine(" from F_WORK_FLOW_DETAIL A ");
            sb.AppendLine(" inner join ( ");
            sb.AppendLine("             select LOT_NO,LOT_SUB,MAX(F_STEP)AS F_STEP ");
            sb.AppendLine("             from F_WORK_FLOW_DETAIL ");
            sb.AppendLine("             group by LOT_NO,LOT_SUB ");
            sb.AppendLine("             )B ");
            sb.AppendLine(" on A.LOT_NO = B.LOT_NO ");
            sb.AppendLine("     and A.LOT_SUB = B.LOT_SUB ");
            sb.AppendLine("     and A.F_STEP=  B.F_STEP ");
            sb.AppendLine(" left outer join N_FLOW_CODE C  ");
            sb.AppendLine(" on A.FLOW_CD = C.FLOW_CD  ");

            //sb.AppendLine("     and C.POOR_TYPE_YN = 'Y' ");
            sb.AppendLine("where 1=1");
            sb.AppendLine(condition);
            sb.AppendLine(" order by A.LOT_NO,A.LOT_SUB");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            return wAdo.SqlCommandSelect(sCommand);
        }

        //작업지시 진행 될 또는 진행된 제품 찾기 
        public DataTable fn_wf_item_srch(string lot_no)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select A.ITEM_CD,B.ITEM_NM,B.SPEC");
            sb.AppendLine(" from F_WORK_INST A ");
            sb.AppendLine("inner join N_ITEM_CODE B ");
            sb.AppendLine(" on A.ITEM_CD = B.ITEM_CD ");

            //sb.AppendLine("     and C.POOR_TYPE_YN = 'Y' ");
            sb.AppendLine("where 1=1");
            sb.AppendLine("     and A.LOT_NO = '" + lot_no + "' ");
            sb.AppendLine(" order by A.LOT_NO ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_Flow_Step_Curr(string lot_no, string lot_sub)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select A.LOT_NO,C.LOT_SUB,B.FLOW_SEQ,C.F_STEP ");
            sb.AppendLine("from F_WORK_FLOW A ");
            sb.AppendLine("left outer join ( ");
            sb.AppendLine("     select ITEM_CD,MAX(SEQ)AS FLOW_SEQ  ");
            sb.AppendLine("     from N_ITEM_FLOW ");
            sb.AppendLine("     group by ITEM_CD)B ");
            sb.AppendLine("on A.ITEM_CD = B.ITEM_CD ");
            sb.AppendLine("inner join ( ");
            sb.AppendLine("     select LOT_NO,LOT_SUB,MAX(F_STEP) AS F_STEP ");
            sb.AppendLine("     from F_WORK_FLOW_DETAIL ");
            sb.AppendLine("     group by LOT_NO,LOT_SUB)C ");
            sb.AppendLine("on A.LOT_NO = C.LOT_NO ");
            sb.AppendLine("and C.LOT_SUB = '" + lot_sub + "' ");
            sb.AppendLine("where 1=1 ");
            sb.AppendLine("and C.LOT_NO = '" + lot_no + "' ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }

        //수입검사기준 등록과 결과값 뿌려주기
        public DataTable fn_Raw_Chk_Rst_List(string condition)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("select A.RAW_MAT_CD");
            sb.AppendLine("       ,A.CHK_CD ");
            sb.AppendLine("       ,A.CHK_STAN_VALUE ");
            sb.AppendLine("       ,B.RAW_MAT_CD AS RAW_MAT_CD_RST ");
            sb.AppendLine("       ,B.CHK_CD AS CHK_CD_RST");
            sb.AppendLine("       ,B.CHK_VALUE  ");
            sb.AppendLine("       ,C.CHK_NM  ");
            sb.AppendLine("       ,C.CHK_ORD  ");

            sb.AppendLine(" from N_RAW_CHK_STAN A");
            sb.AppendLine(" left outer join F_RAW_CHK_RST B ");
            sb.AppendLine(" on A.RAW_MAT_CD = B.RAW_MAT_CD   ");
            sb.AppendLine("     and A.CHK_CD = B.CHK_CD   ");
            sb.AppendLine(" left outer join N_CHK_CODE C ");
            sb.AppendLine(" on A.CHK_CD = C.CHK_CD   ");
            sb.AppendLine("     and C.CHK_GUBUN = '3'   ");
            sb.AppendLine(" where 1=1 ");
            sb.AppendLine(condition);
            sb.AppendLine(" order by A.RAW_MAT_CD,C.CHK_ORD  ");

            Console.WriteLine(sb.ToString());


            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            return wAdo.SqlCommandSelect(sCommand);

        }
        #region insert

        public int insertStaff(
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

        public int insertDept(string txtDeptCd, string txtDeptNm, string comment)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb.AppendLine(" select count(*) as cnt");
                sb.AppendLine(" from n_dept_code");
                sb.AppendLine(" where dept_cd = '" + txtDeptCd + "'");

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

                sb = new StringBuilder();
                sb.AppendLine("insert into N_DEPT_CODE(");
                sb.AppendLine("     DEPT_CD ");
                sb.AppendLine("     ,DEPT_NM ");
                sb.AppendLine("     ,COMMENT ");
                sb.AppendLine(" ) values ( ");
                sb.AppendLine("  @DEPT_CD ");
                sb.AppendLine(" ,@DEPT_NM ");
                sb.AppendLine(" ,@COMMENT ");
                sb.AppendLine(" ) ");

                sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@DEPT_CD", txtDeptCd);
                sCommand.Parameters.AddWithValue("@DEPT_NM", txtDeptNm);
                sCommand.Parameters.AddWithValue("@COMMENT", comment);

                int qResult = wAdo.SqlCommandEtc(sCommand, "insert_DEPT_TB");
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

        public int insertPos(string txt_pos_cd, string txt_pos_nm, string comment)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb.AppendLine(" select count(*) as cnt");
                sb.AppendLine(" from n_pos_code");
                sb.AppendLine(" where pos_cd = '" + txt_pos_cd + "'");

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

                sb = new StringBuilder();
                sb.AppendLine("insert into N_POS_CODE(");
                sb.AppendLine("     POS_CD ");
                sb.AppendLine("     ,POS_NM ");
                sb.AppendLine("     ,COMMENT ");
                sb.AppendLine(" ) values ( ");
                sb.AppendLine("  @POS_CD ");
                sb.AppendLine(" ,@POS_NM ");
                sb.AppendLine(" ,@COMMENT ");
                sb.AppendLine(" ) ");

                sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@POS_CD", txt_pos_cd);
                sCommand.Parameters.AddWithValue("@POS_NM", txt_pos_nm);
                sCommand.Parameters.AddWithValue("@COMMENT", comment);

                int qResult = wAdo.SqlCommandEtc(sCommand, "insert_POS_TB");
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

        public int insertStor(string txt_stor_cd, string txt_stor_nm, string comment)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb.AppendLine(" select count(*) as cnt");
                sb.AppendLine(" from N_STORAGE_CODE");
                sb.AppendLine(" where STORAGE_CD = '" + txt_stor_cd + "'");

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

                sb = new StringBuilder();
                sb.AppendLine("insert into N_STORAGE_CODE(");
                sb.AppendLine("     STORAGE_CD ");
                sb.AppendLine("     ,STORAGE_NM ");
                sb.AppendLine("     ,COMMENT ");
                sb.AppendLine(" ) values ( ");
                sb.AppendLine("  @STORAGE_CD ");
                sb.AppendLine(" ,@STORAGE_NM ");
                sb.AppendLine(" ,@COMMENT ");
                sb.AppendLine(" ) ");

                sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@STORAGE_CD", txt_stor_cd);
                sCommand.Parameters.AddWithValue("@STORAGE_NM", txt_stor_nm);
                sCommand.Parameters.AddWithValue("@COMMENT", comment);

                int qResult = wAdo.SqlCommandEtc(sCommand, "insert_STOR_TB");
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

        // 유형 코드 

        public int insertType(string txt_type_cd, string txt_type_nm, string chk_poor_yn, string comment)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb.AppendLine(" select count(*) as cnt");
                sb.AppendLine(" from n_type_code");
                sb.AppendLine(" where type_cd = '" + txt_type_cd + "'");

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

                sb = new StringBuilder();
                sb.AppendLine("insert into N_TYPE_CODE(");
                sb.AppendLine("     TYPE_CD ");
                sb.AppendLine("     ,TYPE_NM ");
                sb.AppendLine("     ,POOR_TYPE_YN ");
                sb.AppendLine("     ,COMMENT ");
                sb.AppendLine(" ) values ( ");
                sb.AppendLine("  @TYPE_CD ");
                sb.AppendLine(" ,@TYPE_NM ");
                sb.AppendLine(" ,@POOR_TYPE_YN ");
                sb.AppendLine(" ,@COMMENT ");
                sb.AppendLine(" ) ");

                sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@TYPE_CD", txt_type_cd);
                sCommand.Parameters.AddWithValue("@TYPE_NM", txt_type_nm);
                sCommand.Parameters.AddWithValue("@POOR_TYPE_YN", chk_poor_yn);
                sCommand.Parameters.AddWithValue("@COMMENT", comment);

                int qResult = wAdo.SqlCommandEtc(sCommand, "insert_TYPE_TB");
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

        public int insertUnit(string txt_unit_cd, string txt_unit_nm, string comment)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb.AppendLine(" select count(*) as cnt");
                sb.AppendLine(" from n_unit_code");
                sb.AppendLine(" where unit_cd = '" + txt_unit_cd + "'");

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

                sb = new StringBuilder();
                sb.AppendLine("insert into N_UNIT_CODE(");
                sb.AppendLine("     UNIT_CD ");
                sb.AppendLine("     ,UNIT_NM ");
                sb.AppendLine("     ,COMMENT ");
                sb.AppendLine(" ) values ( ");
                sb.AppendLine("  @UNIT_CD ");
                sb.AppendLine(" ,@UNIT_NM ");
                sb.AppendLine(" ,@COMMENT ");
                sb.AppendLine(" ) ");

                sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@UNIT_CD", txt_unit_cd);
                sCommand.Parameters.AddWithValue("@UNIT_NM", txt_unit_nm);
                sCommand.Parameters.AddWithValue("@COMMENT", comment);

                int qResult = wAdo.SqlCommandEtc(sCommand, "insert_UNIT_TB");
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

        public int insertLine(string txt_line_cd, string txt_line_nm, string comment)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb.AppendLine(" select count(*) as cnt");
                sb.AppendLine(" from n_line_code");
                sb.AppendLine(" where line_cd = '" + txt_line_cd + "'");

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

                sb = new StringBuilder();
                sb.AppendLine("insert into N_LINE_CODE(");
                sb.AppendLine("     LINE_CD ");
                sb.AppendLine("     ,LINE_NM ");
                sb.AppendLine("     ,COMMENT ");
                sb.AppendLine(" ) values ( ");
                sb.AppendLine("  @LINE_CD ");
                sb.AppendLine(" ,@LINE_NM ");
                sb.AppendLine(" ,@COMMENT ");
                sb.AppendLine(" ) ");

                sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@LINE_CD", txt_line_cd);
                sCommand.Parameters.AddWithValue("@LINE_NM", txt_line_nm);
                sCommand.Parameters.AddWithValue("@COMMENT", comment);

                int qResult = wAdo.SqlCommandEtc(sCommand, "insert_LINE_TB");
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

        public int insertPoor(string txt_poor_cd, string txt_poor_nm, string chk_poor_cd, string comment)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb.AppendLine(" select count(*) as cnt");
                sb.AppendLine(" from n_poor_code");
                sb.AppendLine(" where poor_cd = '" + txt_poor_cd + "'");

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

                sb = new StringBuilder();
                sb.AppendLine("insert into N_POOR_CODE(");
                sb.AppendLine("     POOR_CD ");
                sb.AppendLine("     ,POOR_NM ");
                sb.AppendLine("     ,TYPE_CD ");
                sb.AppendLine("     ,COMMENT ");
                sb.AppendLine(" ) values ( ");
                sb.AppendLine("  @POOR_CD ");
                sb.AppendLine(" ,@POOR_NM ");
                sb.AppendLine(" ,@TYPE_CD ");
                sb.AppendLine(" ,@COMMENT ");
                sb.AppendLine(" ) ");

                sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@POOR_CD", txt_poor_cd);
                sCommand.Parameters.AddWithValue("@POOR_NM", txt_poor_nm);
                sCommand.Parameters.AddWithValue("@TYPE_CD", chk_poor_cd);

                sCommand.Parameters.AddWithValue("@COMMENT", comment);

                int qResult = wAdo.SqlCommandEtc(sCommand, "insert_POOR_TB");
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

        public int insertFlow(string txt_flow_cd
            , string txt_flow_nm
            , string cmb_stor
            , string chk_flow_yn
            , string chk_item_gbn
            , string chk_flow_chk_yn
            , string chk_temp_yn
            , string chk_mold_yn
            , string cmb_poor
            , string chk_manager_yn
            , string manager_cd
            , string comment)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb.AppendLine(" select count(*) as cnt");
                sb.AppendLine(" from n_flow_code");
                sb.AppendLine(" where flow_cd = '" + txt_flow_cd + "'");

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

                sb = new StringBuilder();
                sb.AppendLine("insert into N_FLOW_CODE(");
                sb.AppendLine("     FLOW_CD ");
                sb.AppendLine("     ,FLOW_NM ");
                sb.AppendLine("     ,STORAGE_CD ");
                sb.AppendLine("     ,FLOW_INSERT_YN ");
                sb.AppendLine("     ,ITEM_IDEN_YN ");
                sb.AppendLine("     ,FLOW_CHK_YN ");
                sb.AppendLine("     ,TEMP_TIME_YN ");
                sb.AppendLine("     ,MOLD_YN ");
                sb.AppendLine("     ,POOR_TYPE_CD ");
                sb.AppendLine("     ,STAFF_YN ");
                sb.AppendLine("     ,STAFF_CD ");
                sb.AppendLine("     ,COMMENT ");
                sb.AppendLine(" ) values ( ");
                sb.AppendLine("     @FLOW_CD ");
                sb.AppendLine("     ,@FLOW_NM ");
                sb.AppendLine("     ,@STORAGE_CD ");
                sb.AppendLine("     ,@FLOW_INSERT_YN ");
                sb.AppendLine("     ,@ITEM_IDEN_YN ");
                sb.AppendLine("     ,@FLOW_CHK_YN ");
                sb.AppendLine("     ,@TEMP_TIME_YN ");
                sb.AppendLine("     ,@MOLD_YN ");
                sb.AppendLine("     ,@POOR_TYPE_CD ");
                sb.AppendLine("     ,@STAFF_YN ");
                sb.AppendLine("     ,@STAFF_CD ");
                sb.AppendLine("     ,@COMMENT ");
                sb.AppendLine(" ) ");

                sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@FLOW_CD", txt_flow_cd);
                sCommand.Parameters.AddWithValue("@FLOW_NM", txt_flow_nm);
                sCommand.Parameters.AddWithValue("@STORAGE_CD", cmb_stor);
                sCommand.Parameters.AddWithValue("@FLOW_INSERT_YN", chk_flow_yn);
                sCommand.Parameters.AddWithValue("@ITEM_IDEN_YN", chk_item_gbn);
                sCommand.Parameters.AddWithValue("@FLOW_CHK_YN", chk_flow_chk_yn);
                sCommand.Parameters.AddWithValue("@TEMP_TIME_YN", chk_temp_yn);
                sCommand.Parameters.AddWithValue("@MOLD_YN", chk_mold_yn);
                sCommand.Parameters.AddWithValue("@POOR_TYPE_CD", cmb_poor);
                sCommand.Parameters.AddWithValue("@STAFF_YN", chk_manager_yn);
                sCommand.Parameters.AddWithValue("@STAFF_CD", manager_cd);

                sCommand.Parameters.AddWithValue("@COMMENT", comment);

                int qResult = wAdo.SqlCommandEtc(sCommand, "insert_FLOW_TB");
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

        public int insertRawMat(
              string txt_raw_mat_cd
            , string txt_raw_mat_nm
            , string txt_spec
            , string txt_quality
            , string cmb_rat_mat_gbn
            , string cmb_type
            , string cmb_input_unit
            , string cmb_output_unit
            , double txt_conver_ratio
            , double txt_input_price
            , double txt_output_price
            , string cmb_line
            , string st_status_yn
            , string cmb_raw_stor
            , string cmb_used
            , string cmb_cust
            , string cmb_raw_chk
            , string txt_part_no
            , string comment)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb.AppendLine(" select count(*) as cnt");
                sb.AppendLine(" from N_RAW_CODE");
                sb.AppendLine(" where RAW_MAT_CD = '" + txt_raw_mat_cd + "'");

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

                sb = new StringBuilder();
                sb.AppendLine("insert into N_RAW_CODE(");
                sb.AppendLine("     RAW_MAT_CD ");
                sb.AppendLine("     ,RAW_MAT_NM ");
                sb.AppendLine("     ,SPEC ");
                sb.AppendLine("     ,RAW_MAT_GUBUN ");
                sb.AppendLine("     ,TYPE_CD ");
                sb.AppendLine("     ,INPUT_UNIT ");
                sb.AppendLine("     ,OUTPUT_UNIT ");
                sb.AppendLine("     ,LINE_CD ");
                sb.AppendLine("     ,CVR_RATIO ");
                sb.AppendLine("     ,INPUT_PRICE ");
                sb.AppendLine("     ,OUTPUT_PRICE ");
                sb.AppendLine("     ,ST_STATUS_YN ");
                sb.AppendLine("     ,RAW_STORAGE ");
                sb.AppendLine("     ,EX_STAN_QUALITY ");
                sb.AppendLine("     ,USED_CD ");
                sb.AppendLine("     ,CUST_CD ");
                sb.AppendLine("     ,BASIC_STOCK ");
                sb.AppendLine("     ,BAL_STOCK ");
                sb.AppendLine("     ,CHECK_GUBUN ");
                sb.AppendLine("     ,PART_NO ");
                sb.AppendLine("     ,COMMENT ");
                sb.AppendLine(" ) values ( ");
                sb.AppendLine("     @RAW_MAT_CD ");
                sb.AppendLine("     ,@RAW_MAT_NM ");
                sb.AppendLine("     ,@SPEC ");
                sb.AppendLine("     ,@RAW_MAT_GUBUN ");
                sb.AppendLine("     ,@TYPE_CD ");
                sb.AppendLine("     ,@INPUT_UNIT ");
                sb.AppendLine("     ,@OUTPUT_UNIT ");
                sb.AppendLine("     ,@LINE_CD ");
                sb.AppendLine("     ,@CVR_RATIO ");
                sb.AppendLine("     ,@INPUT_PRICE ");
                sb.AppendLine("     ,@OUTPUT_PRICE ");
                sb.AppendLine("     ,@ST_STATUS_YN ");
                sb.AppendLine("     ,@RAW_STORAGE ");
                sb.AppendLine("     ,@EX_STAN_QUALITY ");
                sb.AppendLine("     ,@USED_CD ");
                sb.AppendLine("     ,@CUST_CD ");
                sb.AppendLine("     ,'0' ");
                sb.AppendLine("     ,'0' ");
                sb.AppendLine("     ,@CHECK_GUBUN ");
                sb.AppendLine("     ,@PART_NO ");
                sb.AppendLine("     ,@COMMENT ");
                sb.AppendLine(" ) ");

                sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@RAW_MAT_CD", txt_raw_mat_cd);
                sCommand.Parameters.AddWithValue("@RAW_MAT_NM", txt_raw_mat_nm);
                sCommand.Parameters.AddWithValue("@SPEC", txt_spec);
                sCommand.Parameters.AddWithValue("@RAW_MAT_GUBUN", cmb_rat_mat_gbn);
                sCommand.Parameters.AddWithValue("@TYPE_CD", cmb_type);
                sCommand.Parameters.AddWithValue("@INPUT_UNIT", cmb_input_unit);
                sCommand.Parameters.AddWithValue("@OUTPUT_UNIT", cmb_output_unit);
                sCommand.Parameters.AddWithValue("@LINE_CD", cmb_line);
                sCommand.Parameters.AddWithValue("@CVR_RATIO", txt_conver_ratio);
                sCommand.Parameters.AddWithValue("@INPUT_PRICE", txt_input_price);
                sCommand.Parameters.AddWithValue("@OUTPUT_PRICE", txt_output_price);
                sCommand.Parameters.AddWithValue("@ST_STATUS_YN", st_status_yn);
                sCommand.Parameters.AddWithValue("@RAW_STORAGE", "");
                sCommand.Parameters.AddWithValue("@EX_STAN_QUALITY", txt_quality);
                sCommand.Parameters.AddWithValue("@USED_CD", cmb_used);
                sCommand.Parameters.AddWithValue("@CUST_CD", cmb_cust);
                sCommand.Parameters.AddWithValue("@CHECK_GUBUN", cmb_raw_chk);
                sCommand.Parameters.AddWithValue("@PART_NO", txt_part_no);

                sCommand.Parameters.AddWithValue("@COMMENT", comment);

                int qResult = wAdo.SqlCommandEtc(sCommand, "insert_RAW_MAT_TB");
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
                Console.WriteLine(e.Message + "/" + e.ToString());
                return 9;
            }
        }

        public int insertFac(
              string txt_fac_cd
            , string txt_fac_nm
            , string txt_model_nm
            , string txt_spec
            , string txt_manu_comp
            , string txt_acq_date
            , string txt_acq_price
            , string cmb_dept
            , string txt_used
            , string txt_pro_capa
            , string txt_power_num
            , string cmb_mainten)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb.AppendLine(" select count(*) as cnt");
                sb.AppendLine(" from N_FAC_CODE");
                sb.AppendLine(" where FAC_CD = '" + txt_fac_cd + "'");

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

                sb = new StringBuilder();
                sb.AppendLine("insert into N_FAC_CODE(");
                sb.AppendLine("     FAC_CD ");
                sb.AppendLine("     ,FAC_NM ");
                sb.AppendLine("     ,MODEL_NM ");
                sb.AppendLine("     ,SPEC ");
                sb.AppendLine("     ,MANU_COMPANY ");
                sb.AppendLine("     ,ACQ_DATE ");
                sb.AppendLine("     ,ACQ_PRICE ");
                sb.AppendLine("     ,DEPT_CD ");
                sb.AppendLine("     ,USED ");
                sb.AppendLine("     ,PRO_CAPA ");
                sb.AppendLine("     ,POWER_NUMBER ");
                sb.AppendLine("     ,MAINTEN_CLASS ");
                sb.AppendLine("     ,COMMENT ");
                sb.AppendLine(" ) values ( ");
                sb.AppendLine("     @FAC_CD ");
                sb.AppendLine("     ,@FAC_NM ");
                sb.AppendLine("     ,@MODEL_NM ");
                sb.AppendLine("     ,@SPEC ");
                sb.AppendLine("     ,@MANU_COMPANY ");
                sb.AppendLine("     ,@ACQ_DATE ");
                sb.AppendLine("     ,@ACQ_PRICE ");
                sb.AppendLine("     ,@DEPT_CD ");
                sb.AppendLine("     ,@USED ");
                sb.AppendLine("     ,@PRO_CAPA ");
                sb.AppendLine("     ,@POWER_NUMBER ");
                sb.AppendLine("     ,@MAINTEN_CLASS ");
                sb.AppendLine("     ,'' ");
                sb.AppendLine(" ) ");

                sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@FAC_CD", txt_fac_cd);
                sCommand.Parameters.AddWithValue("@FAC_NM", txt_fac_nm);
                sCommand.Parameters.AddWithValue("@MODEL_NM", txt_model_nm);
                sCommand.Parameters.AddWithValue("@SPEC", txt_spec);
                sCommand.Parameters.AddWithValue("@MANU_COMPANY", txt_manu_comp);
                sCommand.Parameters.AddWithValue("@ACQ_DATE", txt_acq_date);
                sCommand.Parameters.AddWithValue("@ACQ_PRICE", txt_acq_price);
                sCommand.Parameters.AddWithValue("@DEPT_CD", cmb_dept);
                sCommand.Parameters.AddWithValue("@USED", txt_used);
                sCommand.Parameters.AddWithValue("@PRO_CAPA", txt_pro_capa);
                sCommand.Parameters.AddWithValue("@POWER_NUMBER", txt_power_num);
                sCommand.Parameters.AddWithValue("@MAINTEN_CLASS", cmb_mainten);

                int qResult = wAdo.SqlCommandEtc(sCommand, "insert_FAC_TB");
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


        //거래처 등록 

        //거래처 등록 

        public int insertCust(
              string txt_cust_cd
            , string cust_gbn
            , string txt_cust_nm
            , string txt_owner
            , string txt_saup_no
            , string txt_uptae
            , string txt_jong
            , string txt_deal_type
            , string txt_post_no
            , string txt_addr
            , string txt_cust_manager
            , string txt_email
            , string txt_comp_phone
            , string txt_phone
            , string txt_fax
            , string txt_start_date
            , string cmb_manager
            , string cmb_used
            , string comment
            , string tax_cd
            )
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb.AppendLine(" select count(*) as cnt");
                sb.AppendLine(" from N_CUST_CODE");
                sb.AppendLine(" where CUST_CD = '" + txt_cust_cd + "'");
                sb.AppendLine(" and CUST_GUBUN = '" + cust_gbn + "'");

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

                sb = new StringBuilder();
                sb.AppendLine("insert into N_CUST_CODE(");
                sb.AppendLine("     CUST_CD ");
                sb.AppendLine("     ,CUST_GUBUN ");
                sb.AppendLine("     ,CUST_NM ");
                sb.AppendLine("     ,OWNER ");
                sb.AppendLine("     ,SAUP_NO ");
                sb.AppendLine("     ,UPTAE ");
                sb.AppendLine("     ,JONGMOK ");
                sb.AppendLine("     ,DEAL_TYPE ");
                sb.AppendLine("     ,POST_NO ");
                sb.AppendLine("     ,ADDR ");
                sb.AppendLine("     ,CUST_MANAGER ");
                sb.AppendLine("     ,CUST_EMAIL ");
                sb.AppendLine("     ,CUST_COMP_PHONE ");
                sb.AppendLine("     ,CUST_PHONE ");
                sb.AppendLine("     ,CUST_FAX ");
                sb.AppendLine("     ,CUST_OPEN ");
                sb.AppendLine("     ,STAFF_CD ");
                sb.AppendLine("     ,USED_CD ");
                sb.AppendLine("     ,COMMENT ");
                sb.AppendLine("     ,TAX_CD ");
                sb.AppendLine(" ) values ( ");
                sb.AppendLine("     @CUST_CD ");
                sb.AppendLine("     ,@CUST_GUBUN ");
                sb.AppendLine("     ,@CUST_NM ");
                sb.AppendLine("     ,@OWNER ");
                sb.AppendLine("     ,@SAUP_NO ");
                sb.AppendLine("     ,@UPTAE ");
                sb.AppendLine("     ,@JONGMOK ");
                sb.AppendLine("     ,@DEAL_TYPE ");
                sb.AppendLine("     ,@POST_NO ");
                sb.AppendLine("     ,@ADDR ");
                sb.AppendLine("     ,@CUST_MANAGER ");
                sb.AppendLine("     ,@CUST_EMAIL ");
                sb.AppendLine("     ,@CUST_COMP_PHONE ");
                sb.AppendLine("     ,@CUST_PHONE ");
                sb.AppendLine("     ,@CUST_FAX ");
                sb.AppendLine("     ,@CUST_OPEN ");
                sb.AppendLine("     ,@STAFF_CD ");
                sb.AppendLine("     ,@USED_CD ");
                sb.AppendLine("     ,@COMMENT ");
                sb.AppendLine("     ,@TAX_CD ");
                sb.AppendLine(" ) ");

                sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@CUST_CD", txt_cust_cd);
                sCommand.Parameters.AddWithValue("@CUST_GUBUN", cust_gbn);
                sCommand.Parameters.AddWithValue("@CUST_NM", txt_cust_nm);
                sCommand.Parameters.AddWithValue("@OWNER", txt_owner);
                sCommand.Parameters.AddWithValue("@SAUP_NO", txt_saup_no);
                sCommand.Parameters.AddWithValue("@UPTAE", txt_uptae);
                sCommand.Parameters.AddWithValue("@JONGMOK", txt_jong);
                sCommand.Parameters.AddWithValue("@DEAL_TYPE", txt_deal_type);
                sCommand.Parameters.AddWithValue("@POST_NO", txt_post_no);
                sCommand.Parameters.AddWithValue("@ADDR", txt_addr);
                sCommand.Parameters.AddWithValue("@CUST_MANAGER", txt_cust_manager);
                sCommand.Parameters.AddWithValue("@CUST_EMAIL", txt_email);
                sCommand.Parameters.AddWithValue("@CUST_COMP_PHONE", txt_comp_phone);
                sCommand.Parameters.AddWithValue("@CUST_PHONE", txt_phone);
                sCommand.Parameters.AddWithValue("@CUST_FAX", txt_fax);
                sCommand.Parameters.AddWithValue("@CUST_OPEN", txt_start_date);
                sCommand.Parameters.AddWithValue("@STAFF_cD", cmb_manager);
                sCommand.Parameters.AddWithValue("@USED_CD", cmb_used);
                sCommand.Parameters.AddWithValue("@COMMENT", comment);
                sCommand.Parameters.AddWithValue("@TAX_CD", tax_cd);

                sep sp = new sep();


                if (Common.sp_pack_gubun.ToString().Equals("1"))  //mes, 장터지기 다 사용 
                {
                    //mes만 사용 
                    StringBuilder sb2 = new StringBuilder();

                    sb2.AppendLine("DECLARE @CUST INT SET @CUST =  ");
                    sb2.AppendLine("(SELECT TOP 1 거래처코드   ");
                    sb2.AppendLine("FROM T_거래처정보   ");
                    sb2.AppendLine("WHERE 사업자번호 = '" + Common.p_saupNo + "'  ");
                    sb2.AppendLine("ORDER BY 거래처코드 DESC) +1  ");
                    sb2.AppendLine("  INSERT INTO T_거래처정보 ( ");
                    sb2.AppendLine("       사업자번호           ");
                    sb2.AppendLine("       ,지점코드            ");
                    sb2.AppendLine("       ,거래처코드          ");
                    sb2.AppendLine("       ,중상여부            ");
                    sb2.AppendLine("       ,거래처구분          ");
                    sb2.AppendLine("       ,거래처명            ");
                    sb2.AppendLine("       ,정식명칭            ");
                    sb2.AppendLine("       ,거래처담당자        ");
                    sb2.AppendLine("       ,대표자명            ");
                    sb2.AppendLine("       ,거래처사업자번호    ");
                    sb2.AppendLine("       ,업태                ");
                    sb2.AppendLine("       ,종목                ");
                    sb2.AppendLine("       ,사원번호            ");
                    sb2.AppendLine("       ,배송사원            ");
                    sb2.AppendLine("       ,거래개시일          ");
                    sb2.AppendLine("       ,유형코드            ");
                    sb2.AppendLine("       ,지역코드            ");
                    sb2.AppendLine("       ,우편번호            ");
                    sb2.AppendLine("       ,주소                ");
                    sb2.AppendLine("       ,상세주소            ");
                    sb2.AppendLine("       ,이메일              ");
                    sb2.AppendLine("       ,폰번호              ");
                    sb2.AppendLine("       ,전화번호            ");
                    sb2.AppendLine("       ,팩스번호            ");
                    sb2.AppendLine("       ,비고1               ");
                    sb2.AppendLine("       ,비고2               ");
                    sb2.AppendLine("       ,비고3               ");
                    sb2.AppendLine("       ,단가구분            ");
                    sb2.AppendLine("       ,부가세코드          ");
                    sb2.AppendLine("       ,계산서여부          ");
                    sb2.AppendLine("       ,발행율              ");
                    sb2.AppendLine("       ,계좌순번            ");
                    sb2.AppendLine("       ,월                  ");
                    sb2.AppendLine("       ,화                  ");
                    sb2.AppendLine("       ,수                  ");
                    sb2.AppendLine("       ,목                  ");
                    sb2.AppendLine("       ,금                  ");
                    sb2.AppendLine("       ,토                  ");
                    sb2.AppendLine("       ,일                  ");
                    sb2.AppendLine("       ,여신                ");
                    sb2.AppendLine("       ,현재잔고            ");
                    sb2.AppendLine("       ,잔고수정여부        ");
                    sb2.AppendLine("       ,초기잔고            ");
                    sb2.AppendLine("       ,잔고수정일자        ");
                    sb2.AppendLine("       ,수정당일잔고        ");
                    sb2.AppendLine("       ,수정잔고            ");
                    sb2.AppendLine("       ,사용여부            ");
                    sb2.AppendLine("       ,거래처명칭주소      ");
                    sb2.AppendLine("       ,초성명칭            ");
                    sb2.AppendLine("       ,등록사원번호        ");
                    sb2.AppendLine("       ,등록일시            ");
                    sb2.AppendLine("  ) values (  ");
                    sb2.AppendLine("  '" + Common.p_saupNo + "'  ");
                    sb2.AppendLine("  , '0'  ");
                   // sb2.AppendLine("  , @CUST  ");
                    sb2.AppendLine("  , '" + txt_cust_cd + "'  ");
                    sb2.AppendLine("  , '0'  ");
                    sb2.AppendLine("  , '" + cust_gbn + "'  ");
                    sb2.AppendLine("  , '" + txt_cust_nm + "'  ");
                    sb2.AppendLine("  , '" + txt_cust_nm + "'  ");
                    sb2.AppendLine("  , '" + txt_cust_manager + "'  ");
                    sb2.AppendLine("  , '" + txt_owner + "'  ");
                    sb2.AppendLine("  , '" + txt_saup_no + "'  ");
                    sb2.AppendLine("  , '" + txt_uptae + "'  ");
                    sb2.AppendLine("  , '" + txt_jong + "'  ");
                    sb2.AppendLine("  , '100'  ");
                    sb2.AppendLine("  , ''  ");
                    sb2.AppendLine("  , '" + txt_start_date + "'  ");
                    sb2.AppendLine("  , ''  ");
                    sb2.AppendLine("  , ''  ");
                    sb2.AppendLine("  , '" + txt_post_no + "'  ");
                    sb2.AppendLine("  , '" + txt_addr + "'  ");
                    sb2.AppendLine("  , '" + txt_addr + "'  ");
                    sb2.AppendLine("  , '" + txt_email + "'  ");
                    sb2.AppendLine("  , '" + txt_phone + "'  ");
                    sb2.AppendLine("  , '" + txt_comp_phone + "'  ");
                    sb2.AppendLine("  , '" + txt_fax + "'  ");
                    sb2.AppendLine("  , '" + comment + "'  ");
                    sb2.AppendLine("  , ''  ");
                    sb2.AppendLine("  , ''  ");
                    sb2.AppendLine("  , ''  ");
                    sb2.AppendLine("  , '" + tax_cd + "'  ");
                    sb2.AppendLine("  , 'Y'  ");
                    sb2.AppendLine("  , '100'  ");
                    sb2.AppendLine("  , '1'  ");
                    sb2.AppendLine("  , 'N'  ");
                    sb2.AppendLine("  , 'N'  ");
                    sb2.AppendLine("  , 'N'  ");
                    sb2.AppendLine("  , 'N'  ");
                    sb2.AppendLine("  , 'N'  ");
                    sb2.AppendLine("  , 'N'  ");
                    sb2.AppendLine("  , 'N'  ");
                    sb2.AppendLine("  , 0  ");
                    sb2.AppendLine("  , 0  ");
                    sb2.AppendLine("  , 0  ");
                    sb2.AppendLine("  , 0  ");
                    sb2.AppendLine("  , ''  ");
                    sb2.AppendLine("  , 0  ");
                    sb2.AppendLine("  , 0  ");
                    sb2.AppendLine("  ,'" + (int.Parse(cmb_used) - 1).ToString() + "'  ");
                    sb2.AppendLine("  , '" + txt_cust_nm + "'  ");
                    sb2.AppendLine("  , '" + txt_cust_nm + ":" + sp.Seperate(txt_cust_nm).Substring(1) + txt_cust_nm + ":" + sp.Seperate(txt_cust_nm).Substring(1) + "'  ");
                    sb2.AppendLine("  , '" + Common.p_strUserNo + "'  ");
                    sb2.AppendLine("  , convert(varchar, getdate(), 120)   ");
                    sb2.AppendLine(" )  ");
                    Debug.WriteLine("장터지기 거래처 등록 한다!!!~");
                    Debug.WriteLine(sb2);
                    SqlCommand sCommand2 = new SqlCommand(sb2.ToString());

                    int qResult = wAdo.SqlCommandEtc_Jang(sCommand2, "insert_CUST_TB_JANG");
                    if (qResult > 0)
                    {
                        int qResult2 = wAdo.SqlCommandEtc(sCommand, "insert_CUST_TB");
                        if (qResult2 > 0)
                        {
                            return 0;  // 0 true, 1 false
                        }
                        else return 5;
                    }
                    else return 5;
                }
                else
                {
                    int qResult2 = wAdo.SqlCommandEtc(sCommand, "insert_CUST_TB");
                    if (qResult2 > 0)
                    {
                        return 0;  // 0 true, 1 false
                    }
                    else return 1;
                }
            }
            catch (Exception e)
            {
                wnLog.writeLog(wnLog.LOG_ERROR, e.Message + " - " + e.ToString());
                Popup.pop오류리포트 msg = new pop오류리포트(e.Message + " - " + e.ToString());
                msg.ShowDialog();
                return 9;
            }
        }





        public int insertItem(
              string txt_item_cd
            , string txt_item_nm
            , string cmb_item_gbn
            , string txt_spec
            , string cmb_type
            , string cmb_line
            , string cmb_unit
            , string cmb_stor_loc
            , double txt_prop_stock
            , double txt_item_weight
            , double txt_input_price
            , double txt_output_price
            , double txt_char_amt
            , double txt_pack_amt
            , string cmb_cust
            , string chk_print_yn
            , string cmb_used
            , string input_date
            , string box_bar_cd
            , string box_amt
            , string unit_bar_cd
            , string unit_amt
            , string comment
            , string txt_link
            , string txt_vat_cd
            , conDataGridView comp_dgv
            , conDataGridView flow_dgv
            , conDataGridView half_dgv)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb.AppendLine(" select count(*) as cnt");
                sb.AppendLine(" from N_ITEM_CODE");
                sb.AppendLine(" where ITEM_CD = '" + txt_item_cd + "'");

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

                sb = new StringBuilder();
                                
                sb.AppendLine("insert into N_ITEM_CODE(");
                sb.AppendLine("     ITEM_CD ");
                sb.AppendLine("     ,ITEM_NM ");
                sb.AppendLine("     ,ITEM_GUBUN ");
                sb.AppendLine("     ,SPEC ");
                sb.AppendLine("     ,TYPE_CD ");
                sb.AppendLine("     ,UNIT_CD ");
                sb.AppendLine("     ,LINE_CD ");
                sb.AppendLine("     ,STOCK_LOC ");
                sb.AppendLine("     ,PROP_STOCK ");
                sb.AppendLine("     ,BAL_STOCK ");
                sb.AppendLine("     ,BASIC_STOCK ");
                sb.AppendLine("     ,ITEM_WEIGHT ");
                sb.AppendLine("     ,INPUT_PRICE ");
                sb.AppendLine("     ,OUTPUT_PRICE ");
                sb.AppendLine("     ,CHARGE_AMT ");
                sb.AppendLine("     ,PACK_AMT ");
                sb.AppendLine("     ,CUST_CD ");
                sb.AppendLine("     ,PRINT_YN ");
                sb.AppendLine("     ,USED_CD ");
                sb.AppendLine("     ,INPUT_DATE ");
                sb.AppendLine("     ,BOX_BAR_CD ");
                sb.AppendLine("     ,BOX_AMT ");
                sb.AppendLine("     ,UNIT_BAR_CD ");
                sb.AppendLine("     ,UNIT_AMT ");
                sb.AppendLine("     ,COMMENT ");
                sb.AppendLine("     ,LINK_CD ");
                sb.AppendLine("     ,VAT_CD ");
                sb.AppendLine(" ) values ( ");
                sb.AppendLine("     @ITEM_CD ");
                sb.AppendLine("     ,@ITEM_NM ");
                sb.AppendLine("     ,@ITEM_GUBUN ");
                sb.AppendLine("     ,@SPEC ");
                sb.AppendLine("     ,@TYPE_CD ");
                sb.AppendLine("     ,@UNIT_CD ");
                sb.AppendLine("     ,@LINE_CD ");
                sb.AppendLine("     ,@STOCK_LOC ");
                sb.AppendLine("     ,@PROP_STOCK ");
                sb.AppendLine("     ,0 ");
                sb.AppendLine("     ,0 ");
                sb.AppendLine("     ,@ITEM_WEIGHT ");
                sb.AppendLine("     ,@INPUT_PRICE ");
                sb.AppendLine("     ,@OUTPUT_PRICE ");
                sb.AppendLine("     ,@CHARGE_AMT ");
                sb.AppendLine("     ,@PACK_AMT ");
                sb.AppendLine("     ,@CUST_CD ");
                sb.AppendLine("     ,@PRINT_YN ");
                sb.AppendLine("     ,@USED_CD ");
                sb.AppendLine("     ,@INPUT_DATE ");
                sb.AppendLine("     ,@BOX_BAR_CD ");
                sb.AppendLine("     ,@BOX_AMT ");
                sb.AppendLine("     ,@UNIT_BAR_CD ");
                sb.AppendLine("     ,@UNIT_AMT ");
                sb.AppendLine("     ,@COMMENT ");
                sb.AppendLine("     ,@LINK_CD ");
                sb.AppendLine("     ,@VAT_CD ");
                sb.AppendLine(" ) ");

                if (comp_dgv.Rows.Count > 0)
                {
                    for (int i = 0; i < comp_dgv.Rows.Count; i++)
                    {
                        sb.AppendLine("declare @seq" + i + " int ");
                        sb.AppendLine("select @seq" + i + " =ISNULL(MAX(SEQ),0)+1 from N_ITEM_COMP ");
                        sb.AppendLine("where ITEM_CD = '" + txt_item_cd + "' ");

                        sb.AppendLine("insert into N_ITEM_COMP(");
                        sb.AppendLine("     ITEM_CD ");
                        sb.AppendLine("     ,SEQ ");
                        sb.AppendLine("     ,RAW_MAT_CD ");
                        sb.AppendLine("     ,TOTAL_AMT ");
                        sb.AppendLine("  )values ( ");
                        sb.AppendLine("     '" + txt_item_cd + "' ");
                        sb.AppendLine("     ,@seq" + i + " ");
                        sb.AppendLine("     ,'" + comp_dgv.Rows[i].Cells["RAW_MAT_CD"].Value + "' ");
                        sb.AppendLine("     ,'" + ((string)comp_dgv.Rows[i].Cells["TOTAL_AMT"].Value).Replace(",", "") + "' ");
                        sb.AppendLine("  )");
                    }
                }

                if (flow_dgv.Rows.Count > 0)
                {
                    for (int i = 0; i < flow_dgv.Rows.Count; i++)
                    {
                        sb.AppendLine("declare @f_seq" + i + " int ");
                        sb.AppendLine("select @f_seq" + i + " =ISNULL(MAX(SEQ),0)+1 from N_ITEM_FLOW ");
                        sb.AppendLine("where ITEM_CD = '" + txt_item_cd + "' ");

                        sb.AppendLine("insert into N_ITEM_FLOW(");
                        sb.AppendLine("     ITEM_CD ");
                        sb.AppendLine("     ,SEQ ");
                        sb.AppendLine("     ,FLOW_CD ");
                        sb.AppendLine("     ,COMMENT ");
                        sb.AppendLine("     ,BOX_AMT ");
                        sb.AppendLine("     ,CVR_RATIO ");
                        sb.AppendLine("     ,CHARGE_AMT ");
                        sb.AppendLine("  )values ( ");
                        sb.AppendLine("     '" + txt_item_cd + "' ");
                        sb.AppendLine("     ,@f_seq" + i + " ");
                        sb.AppendLine("     ,'" + flow_dgv.Rows[i].Cells["FLOW_CD"].Value + "' ");
                        sb.AppendLine("     ,'" + flow_dgv.Rows[i].Cells["FLOW_ETC"].Value + "' ");
                        sb.AppendLine("     ,0 ");
                        sb.AppendLine("     ,0 ");
                        sb.AppendLine("     ,0");

                        sb.AppendLine("  )");
                    }
                }

                if (half_dgv.Rows.Count > 0)
                {
                    for (int i = 0; i < half_dgv.Rows.Count; i++)
                    {
                        sb.AppendLine("declare @h_seq" + i + " int ");
                        sb.AppendLine("select @h_seq" + i + " =ISNULL(MAX(SEQ),0)+1 from N_ITEM_COMP_HALF ");
                        sb.AppendLine("where ITEM_CD = '" + txt_item_cd + "' ");

                        sb.AppendLine("insert into N_ITEM_COMP_HALF(");
                        sb.AppendLine("     ITEM_CD ");
                        sb.AppendLine("     ,SEQ ");
                        sb.AppendLine("     ,HALF_ITEM_CD ");
                        sb.AppendLine("     ,TOTAL_AMT ");
                        sb.AppendLine("  )values ( ");
                        sb.AppendLine("     '" + txt_item_cd + "' ");
                        sb.AppendLine("     ,@h_seq" + i + " ");
                        sb.AppendLine("     ,'" + half_dgv.Rows[i].Cells["HALF_ITEM_CD"].Value + "' ");
                        sb.AppendLine("     ,'" + ((string)half_dgv.Rows[i].Cells["H_TOTAL_AMT"].Value).Replace(",", "") + "' ");
                        sb.AppendLine("  )");
                    }
                }

                sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@ITEM_CD", txt_item_cd);
                sCommand.Parameters.AddWithValue("@ITEM_NM", txt_item_nm);
                sCommand.Parameters.AddWithValue("@ITEM_GUBUN", cmb_item_gbn);
                sCommand.Parameters.AddWithValue("@SPEC", txt_spec);
                sCommand.Parameters.AddWithValue("@TYPE_CD", cmb_type);
                sCommand.Parameters.AddWithValue("@UNIT_CD", cmb_unit);
                sCommand.Parameters.AddWithValue("@LINE_CD", cmb_line);
                sCommand.Parameters.AddWithValue("@STOCK_LOC", "");
                sCommand.Parameters.AddWithValue("@PROP_STOCK", txt_prop_stock);
                sCommand.Parameters.AddWithValue("@ITEM_WEIGHT", txt_item_weight);
                sCommand.Parameters.AddWithValue("@INPUT_PRICE", txt_input_price);
                sCommand.Parameters.AddWithValue("@OUTPUT_PRICE", txt_output_price);
                sCommand.Parameters.AddWithValue("@CHARGE_AMT", txt_char_amt);
                sCommand.Parameters.AddWithValue("@PACK_AMT", txt_pack_amt);
                sCommand.Parameters.AddWithValue("@CUST_CD", cmb_cust);
                sCommand.Parameters.AddWithValue("@PRINT_YN", chk_print_yn);
                sCommand.Parameters.AddWithValue("@USED_CD", cmb_used);
                sCommand.Parameters.AddWithValue("@INPUT_DATE", input_date);

                sCommand.Parameters.AddWithValue("@BOX_BAR_CD", box_bar_cd);
                sCommand.Parameters.AddWithValue("@BOX_AMT", box_amt);
                sCommand.Parameters.AddWithValue("@UNIT_BAR_CD", unit_bar_cd);
                sCommand.Parameters.AddWithValue("@UNIT_AMT", unit_amt);

                sCommand.Parameters.AddWithValue("@COMMENT", comment);
                sCommand.Parameters.AddWithValue("@LINK_CD", txt_item_cd);
                sCommand.Parameters.AddWithValue("@VAT_CD", txt_vat_cd);

                if (Common.sp_pack_gubun.ToString().Equals("1"))
                {
                    sep sp = new sep();

                    StringBuilder sb2 = new StringBuilder();

                    sb2.AppendLine("DECLARE @LINK INT, @ITEMNM NVARCHAR, @SPEC NVARCHAR  ");
                    sb2.AppendLine("SET @LINK = (SELECT TOP 1 상품코드   ");
                    sb2.AppendLine("FROM T_상품정보  ");
                    sb2.AppendLine("WHERE 사업자번호 = '" + Common.p_saupNo + "'   ");
                    sb2.AppendLine("ORDER BY 상품코드 DESC) + 1  ");
                    //sb2.AppendLine("SET @ITEMNM = ");
                    //sb2.AppendLine(" REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE('" + txt_item_nm + "','!','ㄱ'),'@','ㄴ'),'#','ㄷ'),'$','ㄹ'),'%','ㅁ'),'^','ㅂ'),'&','ㅅ'),'*','ㅇ'),'(','ㅈ'),')','ㅊ'),'-','ㅋ'),'+','ㅌ') ");
                    //sb2.AppendLine("SET @SPEC =  ");
                    //sb2.AppendLine("REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE('" + txt_spec + "','!','ㄱ'),'@','ㄴ'),'#','ㄷ'),'$','ㄹ'),'%','ㅁ'),'^','ㅂ'),'&','ㅅ'),'*','ㅇ'),'(','ㅈ'),')','ㅊ'),'-','ㅋ'),'+','ㅌ') ");
                    
                    sb2.AppendLine("  insert into T_상품정보 ( ");
                    sb2.AppendLine("  사업자번호 ");
                    sb2.AppendLine("  ,지점코드 ");
                    sb2.AppendLine("  ,상품코드 ");
                    sb2.AppendLine("  ,상품명 ");
                    sb2.AppendLine("  ,규격 ");
                    sb2.AppendLine("  ,사입품 ");
                    sb2.AppendLine("  ,정렬순서 ");
                    sb2.AppendLine("  ,낱개기본판매수량 ");
                    sb2.AppendLine("  ,낱개입고단가 ");
                    sb2.AppendLine("  ,낱개판매단가 ");
                    sb2.AppendLine("  ,낱개도매단가 ");
                    sb2.AppendLine("  ,낱개바코드 ");
                    sb2.AppendLine("  ,입수수량 ");
                    sb2.AppendLine("  ,박스기본판매수량 ");
                    sb2.AppendLine("  ,박스입고단가 ");
                    sb2.AppendLine("  ,박스판매단가 ");
                    sb2.AppendLine("  ,박스도매단가 ");
                    sb2.AppendLine("  ,박스바코드 ");
                    sb2.AppendLine("  ,중간입수수량 ");
                    sb2.AppendLine("  ,중간기본판매수량 ");
                    sb2.AppendLine("  ,중간입고단가 ");
                    sb2.AppendLine("  ,중간판매단가 ");
                    sb2.AppendLine("  ,중간도매단가 ");
                    sb2.AppendLine("  ,중간바코드 ");
                    sb2.AppendLine("  ,상품구분 ");
                    sb2.AppendLine("  ,과세구분 ");
                    sb2.AppendLine("  ,상품유형코드 ");
                    sb2.AppendLine("  ,제조사코드 ");
                    sb2.AppendLine("  ,주매입처코드 ");
                    sb2.AppendLine("  ,유통기간 ");
                    sb2.AppendLine("  ,비고 ");
                    sb2.AppendLine("  ,현재재고 ");
                    sb2.AppendLine("  ,안전재고 ");
                    sb2.AppendLine("  ,사용여부 ");
                    sb2.AppendLine("  ,상품규격 ");
                    sb2.AppendLine("  ,초성명칭 ");
                    sb2.AppendLine("  ,등록사원번호 ");
                    sb2.AppendLine("  ,등록일시 ");
                    sb2.AppendLine("  ,Old_Code ");
                    sb2.AppendLine("  ,출고위치 ");
                    sb2.AppendLine("  ,기준이익율여부 ");
                    sb2.AppendLine("  ,기준이익율 ");
                    sb2.AppendLine("  ,기준단가 ");
                    sb2.AppendLine("  ,중상기준이익율 ");
                    sb2.AppendLine("  ,중상기준단가 ");
                    sb2.AppendLine("  ,수량별단가여부 ");
                    sb2.AppendLine("  ) values ( ");
                    sb2.AppendLine("  '" + Common.p_saupNo + "' ");
                    sb2.AppendLine("  ,'" + 0 + "' ");
                    //sb2.AppendLine("  ,@LINK ");
                    //sb2.AppendLine("  ,@ITEMNM ");
                    //sb2.AppendLine("  ,@SPEC ");                    
                    sb2.AppendLine("  ,'" + txt_item_cd + "' ");
                    sb2.AppendLine("  ,'" + txt_item_nm + "' ");
                    sb2.AppendLine("  ,'" + txt_spec + "' ");
                    sb2.AppendLine("  ,'N' ");
                    sb2.AppendLine("  ,'999999' ");
                    sb2.AppendLine("  ,1 ");
                    sb2.AppendLine("  ," + txt_input_price + " ");
                    sb2.AppendLine("  ," + txt_output_price + " ");
                    sb2.AppendLine("  ,0 ");
                    sb2.AppendLine("  ,'' ");
                    sb2.AppendLine("  ,0 ");
                    sb2.AppendLine("  ,0 ");
                    sb2.AppendLine("  ,0 ");
                    sb2.AppendLine("  ,0 ");
                    sb2.AppendLine("  ,0 ");
                    sb2.AppendLine("  ,'" + box_bar_cd + "' ");
                    sb2.AppendLine("  ,0 ");
                    sb2.AppendLine("  ,0 ");
                    sb2.AppendLine("  ,0 ");
                    sb2.AppendLine("  ,0 ");
                    sb2.AppendLine("  ,0 ");
                    sb2.AppendLine("  ,'' ");
                    sb2.AppendLine("  ,'1' ");
                    sb2.AppendLine("  ,'" + txt_vat_cd + "' ");
                    sb2.AppendLine("  ,'' ");
                    sb2.AppendLine("  ,'' ");
                    sb2.AppendLine("  ,'' ");
                    sb2.AppendLine("  ,0 ");
                    sb2.AppendLine("  ,'' ");
                    sb2.AppendLine("  ,0 ");
                    sb2.AppendLine("  ,0 ");
                    sb2.AppendLine("  ,0 ");
                    sb2.AppendLine("  ,'" + txt_item_nm + txt_spec + "'  ");
                    sb2.AppendLine("  ,'" + txt_item_nm + ":" + sp.Seperate(txt_item_nm).Substring(1) + "'  ");
                    sb2.AppendLine("  ,'" + Common.p_strUserNo + "'  ");
                    sb2.AppendLine("     ,convert(varchar, getdate(), 120) ");
                    sb2.AppendLine("  ,'' ");
                    sb2.AppendLine("  ,'' ");
                    sb2.AppendLine("  ,'N' ");
                    sb2.AppendLine("  ,0 ");
                    sb2.AppendLine("  ,0 ");
                    sb2.AppendLine("  ,0 ");
                    sb2.AppendLine("  ,0 ");
                    sb2.AppendLine("  ,'N' ");
                    sb2.AppendLine(" )  ");

                    SqlCommand sCommand2 = new SqlCommand(sb2.ToString());

                    int qResult = wAdo.SqlCommandEtc_Jang(sCommand2, "insert_ITEM_TB_JANG");
                    if (qResult > 0)
                    {


                        int qResult2 = wAdo.SqlCommandEtc(sCommand, "insert_ITEM_TB");
                        if (qResult2 > 0)
                        {
                            return 0;  // 0 true, 1 false
                        }
                        else return 1;
                    }
                    else
                    {
                        return 1;
                    }
                }
                else
                {
                    int qResult2 = wAdo.SqlCommandEtc(sCommand, "insert_ITEM_TB");
                    if (qResult2 > 0)
                    {
                        return 0;  // 0 true, 1 false
                    }
                    else
                    {
                        return 1;
                    }
                }
            }
            catch (Exception e)
            {
                wnLog.writeLog(wnLog.LOG_ERROR, e.Message + " - " + e.ToString());
                Popup.pop오류리포트 msg = new pop오류리포트(e.Message + " - " + e.ToString());
                msg.ShowDialog();
                return 9;
            }
        }

        //공정검사 항목 
        public int insertRawChk(
              string txt_raw_mat_cd
            , string txt_control_no
            , conDataGridView raw_chk_dgv)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb.AppendLine(" select count(*) as cnt");
                sb.AppendLine(" from N_RAW_CHK");
                sb.AppendLine(" where RAW_MAT_CD = '" + txt_raw_mat_cd + "'");

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

                sb = new StringBuilder();
                sb.AppendLine("insert into N_RAW_CHK(");
                sb.AppendLine("     RAW_MAT_CD ");
                sb.AppendLine("     ,CONTROL_NO ");
                sb.AppendLine("     ,INSTAFF ");
                sb.AppendLine("     ,INTIME ");
                sb.AppendLine(" ) values ( ");
                sb.AppendLine("      @RAW_MAT_CD ");
                sb.AppendLine("     ,@CONTROL_NO ");
                sb.AppendLine("     ,'" + Common.p_strStaffNo + "' ");
                sb.AppendLine("     ,convert(varchar, getdate(), 120) ");
                sb.AppendLine(" ) ");

                if (raw_chk_dgv.Rows.Count > 0)
                {
                    for (int i = 0; i < raw_chk_dgv.Rows.Count; i++)
                    {

                        sb.AppendLine("insert into N_RAW_CHK_STAN(");
                        sb.AppendLine("     RAW_MAT_CD ");
                        sb.AppendLine("     ,CHK_CD ");
                        sb.AppendLine("     ,CHK_STAN_VALUE ");
                        sb.AppendLine("     ,INSTAFF ");
                        sb.AppendLine("     ,INTIME ");
                        sb.AppendLine("  )values ( ");
                        sb.AppendLine("     '" + txt_raw_mat_cd + "' ");
                        sb.AppendLine("     ,'" + raw_chk_dgv.Rows[i].Cells["CHK_CD"].Value + "' ");
                        sb.AppendLine("     ,'" + raw_chk_dgv.Rows[i].Cells["CHK_STAN_VALUE"].Value + "' ");
                        sb.AppendLine("     ,'" + Common.p_strStaffNo + "' ");
                        sb.AppendLine("     ,convert(varchar, getdate(), 120) ");
                        sb.AppendLine("  )");
                    }
                }

                sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@RAW_MAT_CD", txt_raw_mat_cd);
                sCommand.Parameters.AddWithValue("@CONTROL_NO", txt_control_no);

                int qResult = wAdo.SqlCommandEtc(sCommand, "insert_RAW_CHK_TB");
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

        //공정검사 항목 
        public int insertFlowChk(
              string txt_item_cd
            , string txt_flow_cd
            , string txt_item_img
            , string txt_measure_cnt
            , conDataGridView flow_chk_dgv)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb.AppendLine(" select count(*) as cnt");
                sb.AppendLine(" from N_FLOW_CHK");
                sb.AppendLine(" where ITEM_CD = '" + txt_item_cd + "'");
                sb.AppendLine("     and FLOW_CD = '" + txt_flow_cd + "' ");

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

                sb = new StringBuilder();
                sb.AppendLine("insert into N_FLOW_CHK(");
                sb.AppendLine("     ITEM_CD ");
                sb.AppendLine("     ,FLOW_CD ");
                sb.AppendLine("     ,MEASURE_CNT ");
                //sb.AppendLine("     ,ITEM_IMG ");
                sb.AppendLine("     ,INSTAFF ");
                sb.AppendLine("     ,INTIME ");
                sb.AppendLine(" ) values ( ");
                sb.AppendLine("      @ITEM_CD ");
                sb.AppendLine("     ,@FLOW_CD ");
                sb.AppendLine("     ,@MEASURE_CNT ");
                //sb.AppendLine("     ,@ITEM_IMG ");
                sb.AppendLine("     ,'" + Common.p_strStaffNo + "' ");
                sb.AppendLine("     ,convert(varchar, getdate(), 120) ");
                sb.AppendLine(" ) ");

                if (flow_chk_dgv.Rows.Count > 0)
                {
                    for (int i = 0; i < flow_chk_dgv.Rows.Count; i++)
                    {
                        sb.AppendLine("declare @chk" + i + " int ");
                        sb.AppendLine("select @chk" + i + " = count(*) from N_FLOW_CHK_STAN ");
                        sb.AppendLine("where ITEM_CD = '" + txt_item_cd + "' ");
                        sb.AppendLine(" and FLOW_CD = '" + txt_flow_cd + "' ");
                        sb.AppendLine(" and CHK_CD = '" + flow_chk_dgv.Rows[i].Cells["CHK_CD"].Value + "' ");

                        sb.AppendLine("IF(@chk" + i + " > 0)");
                        sb.AppendLine("update N_FLOW_CHK_STAN ");
                        sb.AppendLine("set CHK_LOC = '" + (string)flow_chk_dgv.Rows[i].Cells["CHK_LOC"].Value + "' ");
                        sb.AppendLine("   ,EVA_GUBUN = '" + (string)flow_chk_dgv.Rows[i].Cells["EVA_GUBUN"].Value + "' ");
                        sb.AppendLine("   ,RULE_SIZE = '" + (string)flow_chk_dgv.Rows[i].Cells["RULE_SIZE"].Value + "' ");
                        sb.AppendLine("   ,RULE_LIMIT = '" + (string)flow_chk_dgv.Rows[i].Cells["RULE_LIMIT"].Value + "' ");
                        sb.AppendLine("   ,MEASURE_APP = '" + (string)flow_chk_dgv.Rows[i].Cells["MEASURE_APP"].Value + "' ");
                        sb.AppendLine("   ,CHK_METHOD = '" + (string)flow_chk_dgv.Rows[i].Cells["CHK_METHOD"].Value + "' ");
                        sb.AppendLine("   ,LOWER_SIZE = " + ((string)flow_chk_dgv.Rows[i].Cells["LOWER_SIZE"].Value).Replace(",", "") + " ");
                        sb.AppendLine("   ,UPPER_SIZE = " + ((string)flow_chk_dgv.Rows[i].Cells["UPPER_SIZE"].Value).Replace(",", "") + " ");
                        sb.AppendLine("   ,LOWER_SELF = " + ((string)flow_chk_dgv.Rows[i].Cells["LOWER_SELF"].Value).Replace(",", "") + " ");
                        sb.AppendLine("   ,UPPER_SELF = " + ((string)flow_chk_dgv.Rows[i].Cells["UPPER_SELF"].Value).Replace(",", "") + " ");
                        sb.AppendLine("where ITEM_CD = '" + txt_item_cd + "' ");
                        sb.AppendLine(" and FLOW_CD = '" + txt_flow_cd + "' ");
                        sb.AppendLine(" and CHK_CD = '" + flow_chk_dgv.Rows[i].Cells["CHK_CD"].Value + "' ");

                        sb.AppendLine("ELSE ");
                        sb.AppendLine("insert into N_FLOW_CHK_STAN(");
                        sb.AppendLine("     ITEM_CD ");
                        sb.AppendLine("     ,FLOW_CD ");
                        sb.AppendLine("     ,CHK_CD ");
                        sb.AppendLine("     ,EVA_GUBUN ");
                        sb.AppendLine("     ,CHK_LOC ");
                        sb.AppendLine("     ,RULE_SIZE ");
                        sb.AppendLine("     ,RULE_LIMIT ");
                        sb.AppendLine("     ,MEASURE_APP ");
                        sb.AppendLine("     ,CHK_METHOD ");
                        sb.AppendLine("     ,LOWER_SIZE ");
                        sb.AppendLine("     ,UPPER_SIZE ");
                        sb.AppendLine("     ,LOWER_SELF ");
                        sb.AppendLine("     ,UPPER_SELF ");
                        sb.AppendLine("     ,INSTAFF ");
                        sb.AppendLine("     ,INTIME ");
                        sb.AppendLine("  )values ( ");
                        sb.AppendLine("     '" + txt_item_cd + "' ");
                        sb.AppendLine("     ,'" + txt_flow_cd + "' ");
                        sb.AppendLine("     ,'" + flow_chk_dgv.Rows[i].Cells["CHK_CD"].Value + "' ");
                        sb.AppendLine("     ,'" + (string)flow_chk_dgv.Rows[i].Cells["EVA_GUBUN"].Value + "' ");
                        sb.AppendLine("     ,'" + flow_chk_dgv.Rows[i].Cells["CHK_LOC"].Value + "' ");
                        sb.AppendLine("     ,'" + flow_chk_dgv.Rows[i].Cells["RULE_SIZE"].Value + "' ");
                        sb.AppendLine("     ,'" + flow_chk_dgv.Rows[i].Cells["RULE_LIMIT"].Value + "' ");
                        sb.AppendLine("     ,'" + flow_chk_dgv.Rows[i].Cells["MEASURE_APP"].Value + "' ");
                        sb.AppendLine("     ,'" + flow_chk_dgv.Rows[i].Cells["CHK_METHOD"].Value + "' ");
                        sb.AppendLine("     ," + ((string)flow_chk_dgv.Rows[i].Cells["LOWER_SIZE"].Value).Replace(",", "") + " ");
                        sb.AppendLine("     ," + ((string)flow_chk_dgv.Rows[i].Cells["UPPER_SIZE"].Value).Replace(",", "") + " ");
                        sb.AppendLine("     ," + ((string)flow_chk_dgv.Rows[i].Cells["LOWER_SELF"].Value).Replace(",", "") + " ");
                        sb.AppendLine("     ," + ((string)flow_chk_dgv.Rows[i].Cells["UPPER_SELF"].Value).Replace(",", "") + " ");
                        sb.AppendLine("     ,'" + Common.p_strStaffNo + "' ");
                        sb.AppendLine("     ,convert(varchar, getdate(), 120) ");
                        sb.AppendLine("  )");
                    }
                }

                sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@ITEM_CD", txt_item_cd);
                sCommand.Parameters.AddWithValue("@FLOW_CD", txt_flow_cd);
                sCommand.Parameters.AddWithValue("@MEASURE_CNT", txt_measure_cnt);
                //sCommand.Parameters.AddWithValue("@ITEM_IMG", txt_item_img);

                int qResult = wAdo.SqlCommandEtc(sCommand, "insert_FLOW_CHK_TB");
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

        public int insertFlowChkExam(
             string txt_lot_no
           , string txt_lot_sub
           , string txt_f_step
           , string txt_item_cd
           , string txt_flow_cd
           , string txt_sub_amt
           , string txt_measure_cnt
           , int startIdx
           , Label lblSearch
           , byte[] img
           , int img_size
           , DataGridView flow_chk_dgv
            , string path
        )
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb.AppendLine(" select count(*) as cnt");
                sb.AppendLine(" from F_FLOW_CHK");
                sb.AppendLine(" where LOT_NO = '" + txt_lot_no + "'");
                sb.AppendLine("     and LOT_SUB = '" + txt_lot_sub + "' ");
                sb.AppendLine("     and F_STEP = '" + txt_f_step + "' ");
                Debug.WriteLine(sb);
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

                string f_chk_date = DateTime.Today.ToString("yyyy-MM-dd");
                sb = new StringBuilder();
                sb.AppendLine("insert into F_FLOW_CHK(");
                sb.AppendLine("     LOT_NO ");
                sb.AppendLine("     ,LOT_SUB ");
                sb.AppendLine("     ,F_STEP ");
                sb.AppendLine("     ,F_CHK_DATE ");
                sb.AppendLine("     ,ITEM_CD ");
                sb.AppendLine("     ,FLOW_CD ");
                sb.AppendLine("     ,F_SUB_AMT ");
                sb.AppendLine("     ,MEASURE_CNT ");
                sb.AppendLine("     ,MAP ");
                sb.AppendLine("     ,MAP_SIZE ");
                sb.AppendLine("     ,INSTAFF ");
                sb.AppendLine("     ,INTIME ");
                sb.AppendLine("     ,EXTERIOR ");
                sb.AppendLine(" ) values ( ");
                sb.AppendLine("      '" + txt_lot_no + "' ");
                sb.AppendLine("      ,'" + txt_lot_sub + "' ");
                sb.AppendLine("      ,'" + txt_f_step + "' ");
                sb.AppendLine("      ,'" + f_chk_date + "' ");
                sb.AppendLine("      ,'" + txt_item_cd + "' ");
                sb.AppendLine("      ,'" + txt_flow_cd + "' ");
                sb.AppendLine("      ,'" + txt_sub_amt.Replace(",", "") + "' ");
                sb.AppendLine("      ,'" + txt_measure_cnt.Replace(",", "") + "' ");

                if (img_size > 0)
                {
                    sb.AppendLine("     ,@MAP ");
                    sb.AppendLine("     ,@MAP_SIZE ");

                }
                else
                {
                    sb.AppendLine("     ,null ");
                    sb.AppendLine("     ,0 ");
                }

                sb.AppendLine("     ,'" + Common.p_strStaffNo + "' ");
                sb.AppendLine("     ,convert(varchar, getdate(), 120) ");
                sb.AppendLine("     ,'" + path + "' ");
                sb.AppendLine(" ) ");



                for (int i = 0; i < flow_chk_dgv.Rows.Count; i++)
                {
                    sb.AppendLine("insert into F_FLOW_CHK_RST(");
                    sb.AppendLine("     LOT_NO ");
                    sb.AppendLine("     ,LOT_SUB ");
                    sb.AppendLine("     ,F_STEP ");
                    sb.AppendLine("     ,CHK_CD ");
                    sb.AppendLine("     ,CHK_ORD ");
                    sb.AppendLine("     ,GRADE ");
                    sb.AppendLine("     ,INSTAFF ");
                    sb.AppendLine("     ,INTIME ");
                    sb.AppendLine("     ,COMMENT ");
                    sb.AppendLine(" ) values ( ");
                    sb.AppendLine("     '" + txt_lot_no + "' ");
                    sb.AppendLine("     ,'" + txt_lot_sub + "' ");
                    sb.AppendLine("     ,'" + txt_f_step + "' ");

                    sb.AppendLine("     ,'" + flow_chk_dgv.Rows[i].Cells["CHK_CD"].Value + "'  ");
                    sb.AppendLine("     ,'" + flow_chk_dgv.Rows[i].Cells["CHK_ORD"].Value + "'  ");
                    if (flow_chk_dgv.Rows[i].Cells["GRADE"].Value == null)
                    {
                        flow_chk_dgv.Rows[i].Cells["GRADE"].Value = "";
                    }
                    if ((string)flow_chk_dgv.Rows[i].Cells["GRADE"].Value == "")
                    {
                        flow_chk_dgv.Rows[i].Cells["GRADE"].Value = "1";
                    }
                    sb.AppendLine("      , '" + (string)flow_chk_dgv.Rows[i].Cells["GRADE"].Value + "' ");
                    sb.AppendLine("      ,'" + Common.p_strStaffNo + "' ");
                    sb.AppendLine("     ,convert(varchar, getdate(), 120) ");
                    sb.AppendLine("      , '" + (string)flow_chk_dgv.Rows[i].Cells["comment"].Value + "' ");
                    sb.AppendLine(" ) ");

                    int k = 1;


                    for (int j = startIdx; j < flow_chk_dgv.Columns.Count; j++)
                    {
                        sb.AppendLine("insert into F_FLOW_CHK_DETAIL(");
                        sb.AppendLine("     LOT_NO ");
                        sb.AppendLine("     ,LOT_SUB ");
                        sb.AppendLine("     ,F_STEP ");
                        sb.AppendLine("     ,CHK_CD ");
                        sb.AppendLine("     ,SEQ ");
                        sb.AppendLine("     ,CHK_VALUE ");
                        sb.AppendLine("     ,INSTAFF ");
                        sb.AppendLine("     ,INTIME ");
                        sb.AppendLine(" ) values ( ");
                        sb.AppendLine("     '" + txt_lot_no + "' ");
                        sb.AppendLine("     ,'" + txt_lot_sub + "' ");
                        sb.AppendLine("     ,'" + txt_f_step + "' ");

                        sb.AppendLine("     ,'" + flow_chk_dgv.Rows[i].Cells["CHK_CD"].Value + "'  ");
                        sb.AppendLine("     , " + k + " "); //flow_chk_dgv.Columns[j].HeaderText.ToString()
                        sb.AppendLine("     ,'" + flow_chk_dgv.Rows[i].Cells["CHK" + k.ToString()].Value + "'  ");
                        sb.AppendLine("      ,'" + Common.p_strStaffNo + "' ");
                        sb.AppendLine("     ,convert(varchar, getdate(), 120) ");
                        sb.AppendLine(" ) ");

                        k++;
                    }
                }


                sb.AppendLine(" update F_WORK_FLOW_DETAIL ");
                sb.AppendLine(" set CHECK_YN = 'N' ");
                sb.AppendLine(" where LOT_NO = '" + txt_lot_no + "' ");
                sb.AppendLine("     and LOT_SUB = '" + txt_lot_sub + "' ");
                sb.AppendLine("     and F_STEP = '" + txt_f_step + "' ");
                Debug.WriteLine(sb);

                sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@LOT_NO", txt_lot_no);
                sCommand.Parameters.AddWithValue("@LOT_SUB", txt_lot_sub);
                sCommand.Parameters.AddWithValue("@F_STEP", txt_f_step);
                sCommand.Parameters.AddWithValue("@F_CHK_DATE", f_chk_date);
                sCommand.Parameters.AddWithValue("@ITEM_CD", txt_item_cd);
                sCommand.Parameters.AddWithValue("@FLOW_CD", txt_flow_cd);
                sCommand.Parameters.AddWithValue("@F_SUB_AMT", txt_sub_amt.Replace(",", ""));
                sCommand.Parameters.AddWithValue("@MEASURE_CNT", txt_measure_cnt.Replace(",", ""));

                if (img_size > 0)
                {
                    sCommand.Parameters.AddWithValue("@MAP", img);
                    sCommand.Parameters.AddWithValue("@MAP_SIZE", img_size);
                }

                int qResult = wAdo.SqlCommandEtc(sCommand, "insert_FLOW_CHK_TB");
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


        //수입검사 등록 
        public int insertRawChkExam(
              string txt_input_date
            , string txt_input_cd
            , string txt_seq
            , string txt_raw_mat_cd
            , string txt_control_cd
            , string txt_part_no
            , string txt_chk_total_amt
            , string txt_pass_amt
            , string pri_non_pass_amt
            , string upd_com_amt
            , string final_non_pass_amt
            , string final_pass_amt
            , string comment
            , DataGridView rawStanGrid
            , DataGridView rawPoorGrid)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb.AppendLine(" select count(*) as cnt");
                sb.AppendLine(" from F_RAW_CHK");
                sb.AppendLine(" where INPUT_DATE = '" + txt_input_date + "'");
                sb.AppendLine("     and INPUT_CD = '" + txt_input_cd + "' ");
                sb.AppendLine("     and SEQ = '" + txt_seq + "' ");

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
                string r_chk_date = DateTime.Today.ToString("yyyy-MM-dd");
                sb = new StringBuilder();
                sb.AppendLine("insert into F_RAW_CHK(");
                sb.AppendLine("     INPUT_DATE ");
                sb.AppendLine("     ,INPUT_CD ");
                sb.AppendLine("     ,SEQ ");
                sb.AppendLine("     ,RAW_MAT_CD ");
                sb.AppendLine("     ,CHK_DATE ");
                sb.AppendLine("     ,CONTROL_NO ");
                sb.AppendLine("     ,PART_NO ");
                sb.AppendLine("     ,CHK_TOTAL_AMT ");
                sb.AppendLine("     ,PASS_AMT ");
                sb.AppendLine("     ,PRI_NON_PASS_AMT ");
                sb.AppendLine("     ,UPD_COM_AMT ");
                sb.AppendLine("     ,FINAL_NON_PASS_AMT ");
                sb.AppendLine("     ,FINAL_PASS_AMT ");
                sb.AppendLine("     ,INSTAFF ");
                sb.AppendLine("     ,INTIME ");
                sb.AppendLine(" ) values ( ");
                sb.AppendLine("      @INPUT_DATE ");
                sb.AppendLine("     ,@INPUT_CD ");
                sb.AppendLine("     ,@SEQ ");
                sb.AppendLine("     ,@RAW_MAT_CD ");
                sb.AppendLine("     ,@CHK_DATE ");
                sb.AppendLine("     ,@CONTROL_NO ");
                sb.AppendLine("     ,@PART_NO ");
                sb.AppendLine("     ,@CHK_TOTAL_AMT ");
                sb.AppendLine("     ,@PASS_AMT ");
                sb.AppendLine("     ,@PRI_NON_PASS_AMT ");
                sb.AppendLine("     ,@UPD_COM_AMT ");
                sb.AppendLine("     ,@FINAL_NON_PASS_AMT ");
                sb.AppendLine("     ,@FINAL_PASS_AMT ");
                sb.AppendLine("     ,'" + Common.p_strStaffNo + "' ");
                sb.AppendLine("     ,convert(varchar, getdate(), 120) ");
                sb.AppendLine(" ) ");


                if (rawStanGrid.Rows.Count > 0)
                {
                    for (int i = 0; i < rawStanGrid.Rows.Count; i++)
                    {
                        sb.AppendLine("insert into F_RAW_CHK_RST(");
                        sb.AppendLine("     INPUT_DATE ");
                        sb.AppendLine("     ,INPUT_CD ");
                        sb.AppendLine("     ,SEQ ");
                        sb.AppendLine("     ,RAW_MAT_CD ");
                        sb.AppendLine("     ,CHK_CD ");
                        sb.AppendLine("     ,CHK_VALUE ");
                        sb.AppendLine("     ,INSTAFF ");
                        sb.AppendLine("     ,INTIME ");
                        sb.AppendLine(" ) values ( ");
                        sb.AppendLine("      '" + txt_input_date + "' ");
                        sb.AppendLine("      ," + txt_input_cd + " ");
                        sb.AppendLine("      ," + txt_seq + " ");
                        sb.AppendLine("      ,'" + txt_raw_mat_cd + "' ");
                        sb.AppendLine("      ,'" + rawStanGrid.Rows[i].Cells["CHK_CD"].Value.ToString() + "' ");
                        sb.AppendLine("      ,'" + rawStanGrid.Rows[i].Cells["CHK_VALUE"].Value.ToString() + "' ");
                        sb.AppendLine("      ,'" + Common.p_strStaffNo + "' ");
                        sb.AppendLine("      ,convert(varchar, getdate(), 120) ");
                        sb.AppendLine(" )");
                    }
                }

                if (rawPoorGrid.Rows.Count > 0)
                {
                    for (int i = 0; i < rawPoorGrid.Rows.Count; i++)
                    {

                        sb.AppendLine("declare @p_seq" + i + " int ");
                        sb.AppendLine("select @p_seq" + i + " =ISNULL(MAX(POOR_SEQ),0)+1 from F_RAW_CHK_POOR ");
                        sb.AppendLine("where INPUT_DATE = '" + txt_input_date + "' ");
                        sb.AppendLine("     and INPUT_CD = '" + txt_input_cd + "' ");
                        sb.AppendLine("     and SEQ = '" + txt_seq + "' ");

                        sb.AppendLine("insert into F_RAW_CHK_POOR(");
                        sb.AppendLine("     INPUT_DATE ");
                        sb.AppendLine("     ,INPUT_CD ");
                        sb.AppendLine("     ,SEQ ");
                        sb.AppendLine("     ,POOR_SEQ ");
                        sb.AppendLine("     ,TYPE_CD ");
                        sb.AppendLine("     ,POOR_NM ");
                        sb.AppendLine("     ,PRI_NON_PASS_AMT ");
                        sb.AppendLine("     ,UPD_DETAIL ");
                        sb.AppendLine("     ,UPD_PASS_AMT ");
                        //sb.AppendLine("     ,COMMENT ");
                        sb.AppendLine("     ,INSTAFF ");
                        sb.AppendLine("     ,INTIME ");
                        sb.AppendLine(" ) values ( ");
                        sb.AppendLine("      '" + txt_input_date + "' ");
                        sb.AppendLine("      ," + txt_input_cd + " ");
                        sb.AppendLine("      ," + txt_seq + " ");
                        sb.AppendLine("      ,@p_seq" + i + " ");
                        sb.AppendLine("      ,'" + rawPoorGrid.Rows[i].Cells["POOR_TYPE"].Value.ToString() + "' ");
                        sb.AppendLine("      ,'" + rawPoorGrid.Rows[i].Cells["POOR_NM"].Value.ToString() + "' ");
                        sb.AppendLine("      ,'" + ((string)rawPoorGrid.Rows[i].Cells["PRI_NON_PASS_AMT"].Value).Replace(",", "") + "' ");
                        sb.AppendLine("      ,'" + rawPoorGrid.Rows[i].Cells["UPD_DETAIL"].Value.ToString() + "' ");
                        sb.AppendLine("      ,'" + ((string)rawPoorGrid.Rows[i].Cells["UPD_PASS_AMT"].Value).Replace(",", "") + "' ");
                        // sb.AppendLine("      ,'" + rawPoorGrid.Rows[i].Cells["COMMENT"].Value.ToString() + "' ");
                        sb.AppendLine("     ,'" + Common.p_strStaffNo + "' ");
                        sb.AppendLine("     ,convert(varchar, getdate(), 120) ");
                        sb.AppendLine(" ) ");

                    }
                }

                sb.AppendLine(" update F_RAW_DETAIL ");
                sb.AppendLine(" set CHECK_YN = 'N' ");
                sb.AppendLine(" where INPUT_DATE = @INPUT_DATE ");
                sb.AppendLine("     and INPUT_CD = @INPUT_CD ");
                sb.AppendLine("     and SEQ = @SEQ ");

                sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@INPUT_DATE", txt_input_date);
                sCommand.Parameters.AddWithValue("@INPUT_CD", txt_input_cd);
                sCommand.Parameters.AddWithValue("@SEQ", txt_seq);
                sCommand.Parameters.AddWithValue("@RAW_MAT_CD", txt_raw_mat_cd);
                sCommand.Parameters.AddWithValue("@CHK_DATE", r_chk_date);
                sCommand.Parameters.AddWithValue("@CONTROL_NO", txt_control_cd);
                sCommand.Parameters.AddWithValue("@PART_NO", txt_part_no);
                sCommand.Parameters.AddWithValue("@CHK_TOTAL_AMT", txt_chk_total_amt.Replace(",", ""));
                sCommand.Parameters.AddWithValue("@PASS_AMT", txt_pass_amt.Replace(",", ""));
                sCommand.Parameters.AddWithValue("@PRI_NON_PASS_AMT", pri_non_pass_amt.Replace(",", ""));
                sCommand.Parameters.AddWithValue("@UPD_COM_AMT", upd_com_amt.Replace(",", ""));
                sCommand.Parameters.AddWithValue("@FINAL_NON_PASS_AMT", final_non_pass_amt.Replace(",", ""));
                sCommand.Parameters.AddWithValue("@FINAL_PASS_AMT", final_pass_amt.Replace(",", ""));

                int qResult = wAdo.SqlCommandEtc(sCommand, "insert_RAW_CHK_EXAM_TB");
                if (qResult > 0)
                {
                    return 0;  // 0 true, 1 false
                }
                else return 1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                wnLog.writeLog(wnLog.LOG_ERROR, e.Message + " - " + e.ToString());
                return 9;
            }
        }







        //제품검사 등록 
        public int insertItemChkExam(
              string txt_lot_no
            , string txt_lot_sub
            , string txt_f_step
            , string txt_item_cd
            , string txt_sub_amt
            , string txt_measure_cnt
            , int startIdx
            , Label lblSearch
            , byte[] img
            , int img_size
            , DataGridView flow_chk_dgv)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb.AppendLine(" select count(*) as cnt");
                sb.AppendLine(" from F_ITEM_CHK");
                sb.AppendLine(" where LOT_NO = '" + txt_lot_no + "'");
                sb.AppendLine("     and LOT_SUB = '" + txt_lot_sub + "' ");
                sb.AppendLine("     and F_STEP = '" + txt_f_step + "' ");

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
                string f_chk_date = DateTime.Today.ToString("yyyy-MM-dd");
                sb = new StringBuilder();
                sb.AppendLine("insert into F_ITEM_CHK(");
                sb.AppendLine("     LOT_NO ");
                sb.AppendLine("     ,LOT_SUB ");
                sb.AppendLine("     ,F_STEP ");
                sb.AppendLine("     ,F_CHK_DATE ");
                sb.AppendLine("     ,ITEM_CD ");
                sb.AppendLine("     ,F_SUB_AMT ");
                sb.AppendLine("     ,MEASURE_CNT ");
                sb.AppendLine("     ,PASS_YN ");
                sb.AppendLine("     ,MAP ");
                sb.AppendLine("     ,MAP_SIZE ");
                sb.AppendLine("     ,INSTAFF ");
                sb.AppendLine("     ,INTIME ");
                sb.AppendLine(" ) values ( ");
                sb.AppendLine("      @LOT_NO ");
                sb.AppendLine("     ,@LOT_SUB ");
                sb.AppendLine("     ,@F_STEP ");
                sb.AppendLine("     ,@F_CHK_DATE ");
                sb.AppendLine("     ,@ITEM_CD ");
                sb.AppendLine("     ,@F_SUB_AMT ");
                sb.AppendLine("     ,@MEASURE_CNT ");
                sb.AppendLine("     ,'N' ");
                if (img_size > 0)
                {
                    sb.AppendLine("     ,@MAP ");
                    sb.AppendLine("     ,@MAP_SIZE ");

                }
                else
                {
                    sb.AppendLine("     ,null ");
                    sb.AppendLine("     ,0 ");
                }

                sb.AppendLine("     ,'" + Common.p_strStaffNo + "' ");
                sb.AppendLine("     ,convert(varchar, getdate(), 120) ");
                sb.AppendLine(" ) ");

                for (int i = 0; i < flow_chk_dgv.Rows.Count; i++)
                {
                    sb.AppendLine("insert into F_ITEM_CHK_RST(");
                    sb.AppendLine("     LOT_NO ");
                    sb.AppendLine("     ,LOT_SUB ");
                    sb.AppendLine("     ,F_STEP ");
                    sb.AppendLine("     ,CHK_CD ");
                    sb.AppendLine("     ,CHK_ORD ");
                    sb.AppendLine("     ,GRADE ");
                    sb.AppendLine("     ,INSTAFF ");
                    sb.AppendLine("     ,INTIME ");
                    sb.AppendLine(" ) values ( ");
                    sb.AppendLine("      @LOT_NO ");
                    sb.AppendLine("     ,@LOT_SUB ");
                    sb.AppendLine("     ,@F_STEP ");
                    sb.AppendLine("     ,'" + flow_chk_dgv.Rows[i].Cells["CHK_CD"].Value + "'  ");
                    sb.AppendLine("     ,'" + flow_chk_dgv.Rows[i].Cells["CHK_ORD"].Value + "'  ");
                    if (flow_chk_dgv.Rows[i].Cells["GRADE"].Value == null)
                    {
                        flow_chk_dgv.Rows[i].Cells["GRADE"].Value = "";
                    }
                    sb.AppendLine("      , '" + (string)flow_chk_dgv.Rows[i].Cells["GRADE"].Value + "' ");
                    sb.AppendLine("      ,'" + Common.p_strStaffNo + "' ");
                    sb.AppendLine("     ,convert(varchar, getdate(), 120) ");
                    sb.AppendLine(" ) ");

                    int k = 1;
                    for (int j = startIdx; j < flow_chk_dgv.Columns.Count; j++)
                    {
                        sb.AppendLine("insert into F_ITEM_CHK_DETAIL(");
                        sb.AppendLine("     LOT_NO ");
                        sb.AppendLine("     ,LOT_SUB ");
                        sb.AppendLine("     ,F_STEP ");
                        sb.AppendLine("     ,CHK_CD ");
                        sb.AppendLine("     ,SEQ ");
                        sb.AppendLine("     ,CHK_VALUE ");
                        sb.AppendLine("     ,INSTAFF ");
                        sb.AppendLine("     ,INTIME ");
                        sb.AppendLine(" ) values ( ");
                        sb.AppendLine("      @LOT_NO ");
                        sb.AppendLine("     ,@LOT_SUB ");
                        sb.AppendLine("     ,@F_STEP ");
                        sb.AppendLine("     ,'" + flow_chk_dgv.Rows[i].Cells["CHK_CD"].Value + "'  ");
                        sb.AppendLine("     , " + k + " "); //flow_chk_dgv.Columns[j].HeaderText.ToString()
                        sb.AppendLine("     ,'" + flow_chk_dgv.Rows[i].Cells["CHK" + k.ToString()].Value + "'  ");
                        sb.AppendLine("      ,'" + Common.p_strStaffNo + "' ");
                        sb.AppendLine("     ,convert(varchar, getdate(), 120) ");
                        sb.AppendLine(" ) ");

                        k++;
                    }
                }

                sb.AppendLine(" update F_WORK_FLOW_DETAIL ");
                sb.AppendLine(" set ITEM_CHECK_YN = 'N' ");
                sb.AppendLine(" where LOT_NO = @LOT_NO ");
                sb.AppendLine("     and LOT_SUB = @LOT_SUB ");
                sb.AppendLine("     and F_STEP = @F_STEP ");

                sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@LOT_NO", txt_lot_no);
                sCommand.Parameters.AddWithValue("@LOT_SUB", txt_lot_sub);
                sCommand.Parameters.AddWithValue("@F_STEP", txt_f_step);
                sCommand.Parameters.AddWithValue("@F_CHK_DATE", f_chk_date);
                sCommand.Parameters.AddWithValue("@ITEM_CD", txt_item_cd);
                sCommand.Parameters.AddWithValue("@F_SUB_AMT", txt_sub_amt);
                sCommand.Parameters.AddWithValue("@MEASURE_CNT", txt_measure_cnt);

                if (img_size > 0)
                {
                    sCommand.Parameters.AddWithValue("@MAP", img);
                    sCommand.Parameters.AddWithValue("@MAP_SIZE", img_size);
                }

                int qResult = wAdo.SqlCommandEtc(sCommand, "insert_ITEM_CHK_TB");
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
        //공정검사 항목 
        public int insertItemChk(
              string txt_item_cd
            , string txt_item_img
            , string txt_measure_cnt
            , conDataGridView item_chk_dgv)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb.AppendLine(" select count(*) as cnt");
                sb.AppendLine(" from N_ITEM_CHK");
                sb.AppendLine(" where ITEM_CD = '" + txt_item_cd + "'");

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

                sb = new StringBuilder();
                sb.AppendLine("insert into N_ITEM_CHK(");
                sb.AppendLine("     ITEM_CD ");
                sb.AppendLine("     ,MEASURE_CNT ");
                //sb.AppendLine("     ,ITEM_IMG ");
                sb.AppendLine("     ,INSTAFF ");
                sb.AppendLine("     ,INTIME ");
                sb.AppendLine(" ) values ( ");
                sb.AppendLine("      @ITEM_CD ");
                sb.AppendLine("     ,@MEASURE_CNT ");
                //sb.AppendLine("     ,@ITEM_IMG ");
                sb.AppendLine("     ,'" + Common.p_strStaffNo + "' ");
                sb.AppendLine("     ,convert(varchar, getdate(), 120) ");
                sb.AppendLine(" ) ");

                if (item_chk_dgv.Rows.Count > 0)
                {
                    for (int i = 0; i < item_chk_dgv.Rows.Count; i++)
                    {
                        sb.AppendLine("declare @chk" + i + " int ");
                        sb.AppendLine("select @chk" + i + " = count(*) from N_ITEM_CHK_STAN ");
                        sb.AppendLine("where ITEM_CD = '" + txt_item_cd + "' ");
                        sb.AppendLine(" and CHK_CD = '" + item_chk_dgv.Rows[i].Cells["CHK_CD"].Value + "' ");

                        sb.AppendLine("IF(@chk" + i + " > 0)");
                        sb.AppendLine("update N_ITEM_CHK_STAN ");
                        sb.AppendLine("set CHK_LOC = '" + (string)item_chk_dgv.Rows[i].Cells["CHK_LOC"].Value + "' ");
                        sb.AppendLine("   ,EVA_GUBUN = '" + (string)item_chk_dgv.Rows[i].Cells["EVA_GUBUN"].Value + "' ");
                        sb.AppendLine("   ,RULE_SIZE = '" + (string)item_chk_dgv.Rows[i].Cells["RULE_SIZE"].Value + "' ");
                        sb.AppendLine("   ,RULE_LIMIT = '" + (string)item_chk_dgv.Rows[i].Cells["RULE_LIMIT"].Value + "' ");
                        sb.AppendLine("   ,MEASURE_APP = '" + (string)item_chk_dgv.Rows[i].Cells["MEASURE_APP"].Value + "' ");
                        sb.AppendLine("   ,CHK_INTERVAL = '" + (string)item_chk_dgv.Rows[i].Cells["CHK_INTERVAL"].Value + "' ");
                        sb.AppendLine("   ,LOWER_SIZE = " + ((string)item_chk_dgv.Rows[i].Cells["LOWER_SIZE"].Value).Replace(",", "") + " ");
                        sb.AppendLine("   ,UPPER_SIZE = " + ((string)item_chk_dgv.Rows[i].Cells["UPPER_SIZE"].Value).Replace(",", "") + " ");
                        sb.AppendLine("   ,LOWER_SELF = " + ((string)item_chk_dgv.Rows[i].Cells["LOWER_SELF"].Value).Replace(",", "") + " ");
                        sb.AppendLine("   ,UPPER_SELF = " + ((string)item_chk_dgv.Rows[i].Cells["UPPER_SELF"].Value).Replace(",", "") + " ");
                        sb.AppendLine("where ITEM_CD = '" + txt_item_cd + "' ");
                        sb.AppendLine(" and CHK_CD = '" + item_chk_dgv.Rows[i].Cells["CHK_CD"].Value + "' ");

                        sb.AppendLine("ELSE ");
                        sb.AppendLine("insert into N_ITEM_CHK_STAN(");
                        sb.AppendLine("     ITEM_CD ");
                        sb.AppendLine("     ,CHK_CD ");
                        sb.AppendLine("     ,EVA_GUBUN ");
                        sb.AppendLine("     ,CHK_LOC ");
                        sb.AppendLine("     ,RULE_SIZE ");
                        sb.AppendLine("     ,RULE_LIMIT ");
                        sb.AppendLine("     ,MEASURE_APP ");
                        sb.AppendLine("     ,CHK_INTERVAL ");
                        sb.AppendLine("     ,LOWER_SIZE ");
                        sb.AppendLine("     ,UPPER_SIZE ");
                        sb.AppendLine("     ,LOWER_SELF ");
                        sb.AppendLine("     ,UPPER_SELF ");
                        sb.AppendLine("     ,INSTAFF ");
                        sb.AppendLine("     ,INTIME ");
                        sb.AppendLine("  )values ( ");
                        sb.AppendLine("     '" + txt_item_cd + "' ");
                        sb.AppendLine("     ,'" + item_chk_dgv.Rows[i].Cells["CHK_CD"].Value + "' ");
                        sb.AppendLine("     ,'" + (string)item_chk_dgv.Rows[i].Cells["EVA_GUBUN"].Value + "' ");
                        sb.AppendLine("     ,'" + item_chk_dgv.Rows[i].Cells["CHK_LOC"].Value + "' ");
                        sb.AppendLine("     ,'" + item_chk_dgv.Rows[i].Cells["RULE_SIZE"].Value + "' ");
                        sb.AppendLine("     ,'" + item_chk_dgv.Rows[i].Cells["RULE_LIMIT"].Value + "' ");
                        sb.AppendLine("     ,'" + item_chk_dgv.Rows[i].Cells["MEASURE_APP"].Value + "' ");
                        sb.AppendLine("     ,'" + item_chk_dgv.Rows[i].Cells["CHK_INTERVAL"].Value + "' ");
                        sb.AppendLine("     ," + ((string)item_chk_dgv.Rows[i].Cells["LOWER_SIZE"].Value).Replace(",", "") + " ");
                        sb.AppendLine("     ," + ((string)item_chk_dgv.Rows[i].Cells["UPPER_SIZE"].Value).Replace(",", "") + " ");
                        sb.AppendLine("     ," + ((string)item_chk_dgv.Rows[i].Cells["LOWER_SELF"].Value).Replace(",", "") + " ");
                        sb.AppendLine("     ," + ((string)item_chk_dgv.Rows[i].Cells["UPPER_SELF"].Value).Replace(",", "") + " ");
                        sb.AppendLine("     ,'" + Common.p_strStaffNo + "' ");
                        sb.AppendLine("     ,convert(varchar, getdate(), 120) ");
                        sb.AppendLine("  )");
                    }
                }

                sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@ITEM_CD", txt_item_cd);
                sCommand.Parameters.AddWithValue("@MEASURE_CNT", txt_measure_cnt);
                //sCommand.Parameters.AddWithValue("@ITEM_IMG", txt_item_img);

                int qResult = wAdo.SqlCommandEtc(sCommand, "insert_FLOW_CHK_TB");
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

        #region 검사항목 마스터 코드
        public int insertChk(
              string txt_chk_cd
            , string chk_gbn
            , string txt_chk_nm
            , string txt_chk_ord
            , string comment)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(" select count(*) as cnt");
                sb.AppendLine(" from N_CHK_CODE");
                sb.AppendLine(" where CHK_CD = '" + txt_chk_cd + "'");
                sb.AppendLine(" and CHK_GUBUN = '" + chk_gbn + "'");
                sb.AppendLine(" and CHK_ORD = '" + txt_chk_ord + "'");

                SqlCommand sCommand = new SqlCommand(sb.ToString());
                if (sCommand.CommandText.Equals(null))
                {
                    //wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                }
                else
                {
                    wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                    return 4;
                }

                //---------------------------
                sb = new StringBuilder();

                sb.AppendLine(" select count(*) as cnt");
                sb.AppendLine(" from N_CHK_CODE");
                sb.AppendLine(" where CHK_CD = '" + txt_chk_cd + "'");
                sb.AppendLine(" and CHK_GUBUN = '" + chk_gbn + "'");

                sCommand = new SqlCommand(sb.ToString());
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

                sb = new StringBuilder();
                sb.AppendLine("insert into N_CHK_CODE(");
                sb.AppendLine("      CHK_CD ");
                sb.AppendLine("     ,CHK_GUBUN ");
                sb.AppendLine("     ,CHK_ORD ");
                sb.AppendLine("     ,CHK_NM ");
                sb.AppendLine("     ,COMMENT ");
                sb.AppendLine("     ,INSTAFF ");
                sb.AppendLine("     ,INTIME ");
                sb.AppendLine(" ) values ( ");
                sb.AppendLine("     @CHK_CD ");
                sb.AppendLine("     ,@CHK_GUBUN ");
                sb.AppendLine("     ,@CHK_ORD ");
                sb.AppendLine("     ,@CHK_NM ");
                sb.AppendLine("     ,@COMMENT ");
                sb.AppendLine("     ,'" + Common.p_strStaffNo + "' ");
                sb.AppendLine("     ,convert(varchar, getdate(), 120) ");
                sb.AppendLine(" ) ");

                sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@CHK_CD", txt_chk_cd);
                sCommand.Parameters.AddWithValue("@CHK_GUBUN", chk_gbn);
                sCommand.Parameters.AddWithValue("@CHK_ORD", txt_chk_ord);
                sCommand.Parameters.AddWithValue("@CHK_NM", txt_chk_nm);

                sCommand.Parameters.AddWithValue("@COMMENT", comment);

                int qResult = wAdo.SqlCommandEtc(sCommand, "insert_CHK_TB");
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
        #endregion 검사항목 마스터 코드

        public int insertPlan(
              string plan_date
            , string txt_cust_cd
            , string deliver_req_date
            , string order_yn
            , string txt_plan_num
            , string comment
            , conDataGridView p_item_dgv
            , DataGridView p_half_dgv)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb = new StringBuilder();
                sb.AppendLine("declare @seq int ");
                sb.AppendLine("select @seq =ISNULL(MAX(PLAN_CD),0)+1 from F_PLAN ");
                sb.AppendLine("where PLAN_DATE = '" + plan_date + "' ");

                sb.AppendLine("insert into F_PLAN(");
                sb.AppendLine("     PLAN_DATE");
                sb.AppendLine("     ,PLAN_CD ");
                sb.AppendLine("     ,CUST_CD ");
                sb.AppendLine("     ,DELIVER_REQ_DATE ");
                sb.AppendLine("     ,STAFF_CD");
                sb.AppendLine("     ,ORDER_YN");
                sb.AppendLine("     ,PLAN_NUM");
                sb.AppendLine("     ,COMMENT ");
                sb.AppendLine("     ,INTIME ");
                sb.AppendLine(" ) values ( ");
                sb.AppendLine("      @PLAN_DATE ");
                sb.AppendLine("     ,@seq");
                sb.AppendLine("     ,@CUST_CD ");
                sb.AppendLine("     ,@DELIVER_REQ_DATE ");
                sb.AppendLine("     ,'" + Common.p_strStaffNo + "' ");
                sb.AppendLine("     ,@ORDER_YN ");
                sb.AppendLine("     ,'" + txt_plan_num + "'+RIGHT('000'+ convert(varchar, @seq), 4) "); //yyMMdd000n
                sb.AppendLine("     ,@COMMENT ");
                sb.AppendLine("     ,convert(varchar, getdate(), 120) ");
                sb.AppendLine(" ) ");

                if (p_item_dgv.Rows.Count > 0)
                {
                    for (int i = 0; i < p_item_dgv.Rows.Count; i++)
                    {
                        sb.AppendLine("declare @item_seq" + i + " int ");
                        sb.AppendLine("select @item_seq" + i + " =ISNULL(MAX(SEQ),0)+1 from F_PLAN_DETAIL ");
                        sb.AppendLine("where PLAN_DATE = '" + plan_date + "' ");
                        sb.AppendLine("and PLAN_CD =  @seq ");

                        sb.AppendLine("insert into F_PLAN_DETAIL(");
                        sb.AppendLine("     PLAN_DATE ");
                        sb.AppendLine("     ,PLAN_CD ");
                        sb.AppendLine("     ,SEQ ");
                        sb.AppendLine("     ,ITEM_CD ");
                        sb.AppendLine("     ,UNIT_CD ");
                        sb.AppendLine("     ,TOTAL_AMT ");
                        sb.AppendLine("     ,PRICE ");
                        sb.AppendLine("     ,TOTAL_MONEY ");
                        sb.AppendLine("     ,WORK_YN ");
                        sb.AppendLine("     ,F_LEVEL ");
                        sb.AppendLine("     ,DEFAULT_AMT ");
                        sb.AppendLine("     ,INSTAFF");
                        sb.AppendLine("     ,INTIME");
                        sb.AppendLine("  )values ( ");
                        sb.AppendLine("     '" + plan_date + "' ");
                        sb.AppendLine("      ,@seq ");
                        sb.AppendLine("     ,@item_seq" + i + " ");
                        sb.AppendLine("     ,'" + p_item_dgv.Rows[i].Cells["ITEM_CD"].Value + "' ");
                        sb.AppendLine("     ,'" + p_item_dgv.Rows[i].Cells["UNIT_CD"].Value + "' ");
                        sb.AppendLine("     ,'" + ((string)p_item_dgv.Rows[i].Cells["TOTAL_AMT"].Value).Replace(",", "") + "' ");
                        sb.AppendLine("     ,'" + ((string)p_item_dgv.Rows[i].Cells["PRICE"].Value).Replace(",", "") + "' ");
                        sb.AppendLine("     ,'" + ((string)p_item_dgv.Rows[i].Cells["TOTAL_MONEY"].Value).Replace(",", "") + "' ");
                        sb.AppendLine("      ,'N' ");
                        sb.AppendLine("      , 1 ");
                        sb.AppendLine("      , 1  ");
                        sb.AppendLine("     ,'" + Common.p_strStaffNo + "' ");
                        sb.AppendLine("     ,convert(varchar, getdate(), 120) ");
                        sb.AppendLine("  )");
                    }
                }

                if (p_half_dgv.Rows.Count > 0)
                {
                    for (int i = 0; i < p_half_dgv.Rows.Count; i++)
                    {
                        sb.AppendLine("declare @half_seq" + i + " int ");
                        sb.AppendLine("select @half_seq" + i + " =ISNULL(MAX(SEQ),0)+1 from F_PLAN_DETAIL ");
                        sb.AppendLine("where PLAN_DATE = '" + plan_date + "' ");
                        sb.AppendLine("and PLAN_CD =  @seq ");

                        sb.AppendLine("insert into F_PLAN_DETAIL(");
                        sb.AppendLine("     PLAN_DATE ");
                        sb.AppendLine("     ,PLAN_CD ");
                        sb.AppendLine("     ,SEQ ");
                        sb.AppendLine("     ,ITEM_CD ");
                        sb.AppendLine("     ,UNIT_CD ");
                        sb.AppendLine("     ,TOTAL_AMT ");
                        sb.AppendLine("     ,PRICE ");
                        sb.AppendLine("     ,TOTAL_MONEY ");
                        sb.AppendLine("     ,WORK_YN ");
                        sb.AppendLine("     ,F_LEVEL ");
                        sb.AppendLine("     ,TOP_ITEM_CD ");
                        sb.AppendLine("     ,P_ITEM_CD ");
                        sb.AppendLine("     ,DEFAULT_AMT ");
                        sb.AppendLine("     ,INSTAFF");
                        sb.AppendLine("     ,INTIME");
                        sb.AppendLine("  )values ( ");
                        sb.AppendLine("     '" + plan_date + "' ");
                        sb.AppendLine("      ,@seq ");
                        sb.AppendLine("     ,@half_seq" + i + " ");
                        sb.AppendLine("     ,'" + p_half_dgv.Rows[i].Cells["HALF_ITEM_CD"].Value + "' ");
                        sb.AppendLine("     ,'" + p_half_dgv.Rows[i].Cells["H_UNIT_CD"].Value + "' ");
                        sb.AppendLine("     ,'" + ((string)p_half_dgv.Rows[i].Cells["H_TOTAL_AMT"].Value).Replace(",", "") + "' ");
                        sb.AppendLine("     ,'" + ((string)p_half_dgv.Rows[i].Cells["H_PRICE"].Value).Replace(",", "") + "' ");
                        sb.AppendLine("     ,'" + ((string)p_half_dgv.Rows[i].Cells["H_TOTAL_MONEY"].Value).Replace(",", "") + "' ");
                        sb.AppendLine("      ,'N' ");
                        sb.AppendLine("      ,'" + ((string)p_half_dgv.Rows[i].Cells["F_LEVEL"].Value).Replace(",", "") + "'  ");
                        sb.AppendLine("      ,'" + p_half_dgv.Rows[i].Cells["TOP_ITEM_CD"].Value + "'  ");
                        sb.AppendLine("      ,'" + p_half_dgv.Rows[i].Cells["P_ITEM_CD"].Value + "'  ");
                        sb.AppendLine("      ,'" + ((string)p_half_dgv.Rows[i].Cells["DEFAULT_AMT"].Value).Replace(",", "") + "' ");
                        sb.AppendLine("     ,'" + Common.p_strStaffNo + "' ");
                        sb.AppendLine("     ,convert(varchar, getdate(), 120) ");
                        sb.AppendLine("  )");
                    }
                }


                SqlCommand sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@PLAN_DATE", plan_date);
                sCommand.Parameters.AddWithValue("@CUST_CD", txt_cust_cd);
                sCommand.Parameters.AddWithValue("@DELIVER_REQ_DATE", deliver_req_date);
                sCommand.Parameters.AddWithValue("@ORDER_YN", order_yn);
                sCommand.Parameters.AddWithValue("@COMMENT", comment);

                int qResult = wAdo.SqlCommandEtc(sCommand, "insert_PLAN_TB");
                if (qResult > 0)
                {
                    sb = new StringBuilder();
                    sb.AppendLine("declare @seq int ");
                    sb.AppendLine("select @seq =ISNULL(MAX(PLAN_CD),0) from F_PLAN ");
                    sb.AppendLine("where PLAN_DATE = '" + plan_date + "' ");

                    sb.AppendLine("DECLARE	@return_value int ");
                    sb.AppendLine("EXEC	@return_value = [dbo].[SP_PLAN_GROUP] ");
                    sb.AppendLine("@PLAN_DATE = '" + plan_date + "',");
                    sb.AppendLine("@PLAN_CD = @seq, ");
                    sb.AppendLine("@STAFFCD = '" + Common.p_strStaffNo + "' ");
                    sb.AppendLine("SELECT	'RV' = @return_value ");

                    sCommand = new SqlCommand(sb.ToString());

                    DataTable dt = wAdo.SqlCommandSelect(sCommand);
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["RV"].ToString().Equals("0"))
                        {
                            return 0;
                        }
                        else return 1;
                    }
                    else return 1;
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

        #region 지육 관련

        //지육 입고 테이블 출력
        public DataTable fn_Meat_Input_List(string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select INPUT_DATE");
            sb.AppendLine("     ,INPUT_CD ");
            sb.AppendLine("     ,CUST_CD ");
            sb.AppendLine("     ,RAW_MAT_NM ");
            sb.AppendLine("     ,RAW_MAT_AMOUNT ");
            sb.AppendLine("     ,COMMENT ");
            sb.AppendLine("     ,INPUT_PRICE ");
            sb.AppendLine("     ,(select CUST_NM from N_CUST_CODE where CUST_GUBUN = '2' and CUST_CD = A.CUST_CD) as CUST_NM  ");
            sb.AppendLine("     ,RAW_MAT_WEIGHT ");
            sb.AppendLine("     ,OUTPUT_YN ");
            sb.AppendLine("     ,MF_DATE ");
            sb.AppendLine("     ,COUNTRY_ORIGIN ");
            sb.AppendLine("     ,(select FROZEN_NM from N_FROZEN_CODE where FROZEN_CD = A.FROZEN_GUBUN) as FROZEN_GUBUN ");
            sb.AppendLine("     ,EXPRT_DATE ");
            sb.AppendLine("     ,(select GRADE_NM from N_GRADE_CODE where GRADE_CD = A.GRADE) as GRADE ");
            sb.AppendLine("     ,UNION_CD ");
            sb.AppendLine(" from F_RAW_MEAT_INPUT A");
            sb.AppendLine(condition);
            sb.AppendLine(" order by INPUT_DATE desc, INPUT_CD desc ");

            Console.WriteLine(sb.ToString());

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            return wAdo.SqlCommandSelect(sCommand);

        }

        public DataTable fn_Meat_Detail_List(string condition)
        {
            //2019-10-31 이재원 컬럼 명칭을 수정하였음
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select A.GRADE");
            sb.AppendLine("     ,A.SEQ");
            sb.AppendLine("     ,A.INPUT_PRICE ");
            sb.AppendLine("     ,A.RAW_MAT_WEIGHT ");
            sb.AppendLine("     ,A.OUTPUT_YN ");
            sb.AppendLine("     ,A.UNION_CD ");
            sb.AppendLine(" from F_RAW_MEAT_DETAIL A");
            sb.AppendLine(condition);
            sb.AppendLine(" order by A.SEQ ");



            Console.WriteLine(sb.ToString());

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            return wAdo.SqlCommandSelect(sCommand);

        }

        public int insertMeatOutCome(
            string txt_source_cd
           , conDataGridView comp_dgv
          )
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb.AppendLine(" select count(*) as cnt");
                sb.AppendLine(" from N_RAW_MEAT_SOURCE");
                sb.AppendLine(" where RAW_SOURCE_CD = '" + txt_source_cd + "'");

                SqlCommand sCommand = new SqlCommand(sb.ToString());
                if (sCommand.CommandText.Equals(null))
                {
                    wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                    return 2;
                }
                DataTable dt = wAdo.SqlCommandSelect(sCommand);

                sb = new StringBuilder();

                if (!dt.Rows[0]["cnt"].ToString().Equals("0"))
                {
                    sb.AppendLine("delete from N_RAW_MEAT_SOURCE    ");
                    sb.AppendLine("  where RAW_SOURCE_CD = '" + txt_source_cd + "' ");

                }




                if (comp_dgv.Rows.Count > 0)
                {
                    for (int i = 0; i < comp_dgv.Rows.Count; i++)
                    {
                        sb.AppendLine("declare @seq" + i + " int ");
                        sb.AppendLine("select @seq" + i + " =ISNULL(MAX(SEQ),0)+1 from N_RAW_MEAT_SOURCE ");
                        sb.AppendLine("where RAW_SOURCE_CD = '" + txt_source_cd + "' ");

                        sb.AppendLine("insert into N_RAW_MEAT_SOURCE(");
                        sb.AppendLine("     RAW_SOURCE_CD ");
                        sb.AppendLine("     ,SEQ ");
                        sb.AppendLine("     ,RAW_MAT_CD ");
                        sb.AppendLine("     ,RAW_MAT_NM ");
                        sb.AppendLine("  )values ( ");
                        sb.AppendLine("     '" + txt_source_cd + "' ");
                        sb.AppendLine("     ,@seq" + i + " ");
                        sb.AppendLine("     ,'" + comp_dgv.Rows[i].Cells["RAW_MAT_CD"].Value + "' ");
                        sb.AppendLine("     ,'" + ((string)comp_dgv.Rows[i].Cells["RAW_MAT_NM"].Value).Replace(",", "") + "' ");
                        sb.AppendLine("  )");
                    }
                }



                sCommand = new SqlCommand(sb.ToString());


                int qResult = wAdo.SqlCommandEtc(sCommand, "insert_MEAT_SOURCE");
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

        public int insert_Meat_Input(
              string meat_cd
            , string meat_nm
            , string meat_amount
            , string meat_weight
            , string meat_price
            , string input_date
            , string comment
            , string cust_cd
            , string complete_yn
            , string mf_date
            , string unioin_cd
            , string grade_gubun
            , string frozen_gubun
            , string country_origin
            , DataGridView sourceRawGrid
            )
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb = new StringBuilder();
                sb.AppendLine("declare @seq int ");
                sb.AppendLine("select @seq =ISNULL(MAX(INPUT_CD),0)+1 from F_RAW_MEAT_INPUT ");
                sb.AppendLine("where INPUT_DATE = '" + input_date + "' ");

                Console.WriteLine(sb.ToString());

                sb.AppendLine("insert into F_RAW_MEAT_INPUT(");
                sb.AppendLine("     INPUT_DATE");
                sb.AppendLine("     ,INPUT_CD ");
                sb.AppendLine("     ,CUST_CD ");
                sb.AppendLine("     ,RAW_MAT_CD ");
                sb.AppendLine("     ,RAW_MAT_NM");
                sb.AppendLine("     ,INPUT_PRICE");
                sb.AppendLine("     ,RAW_MAT_AMOUNT");
                sb.AppendLine("     ,RAW_MAT_WEIGHT ");
                sb.AppendLine("     ,COMMENT ");
                sb.AppendLine("     ,OUTPUT_YN ");
                sb.AppendLine("     ,MF_DATE ");
                sb.AppendLine("     ,EXPRT_DATE ");
                sb.AppendLine("     ,COUNTRY_ORIGIN ");
                sb.AppendLine("     ,FROZEN_GUBUN ");
                sb.AppendLine("     ,UNION_CD ");
                sb.AppendLine("     ,GRADE ");
                sb.AppendLine("     ,INSTAFF ");
                sb.AppendLine("     ,INTIME ");
                sb.AppendLine(" ) values ( ");
                sb.AppendLine("      @INPUT_DATE ");
                sb.AppendLine("     ,@seq");
                sb.AppendLine("     ,@CUST_CD ");
                sb.AppendLine("     ,@RAW_MAT_CD ");
                sb.AppendLine("     ,@RAW_MAT_NM ");
                sb.AppendLine("     ,@INPUT_PRICE ");
                sb.AppendLine("     ,@RAW_MAT_AMOUNT ");
                sb.AppendLine("     ,@RAW_MAT_WEIGHT ");
                sb.AppendLine("     ,@COMMENT ");
                sb.AppendLine("     ,@OUTPUT_YN ");
                sb.AppendLine("     ,@MF_DATE ");
                sb.AppendLine("     ,REPLACE(CONVERT(NVARCHAR(10),DATEADD(DAY, ");
                sb.AppendLine("     (select EXPRT_COUNT from N_FROZEN_CODE where FROZEN_CD = @FROZEN_GUBUN ) ");
                sb.AppendLine("     ,@MF_DATE),120),'/','-') ");
                sb.AppendLine("     ,@COUNTRY_ORIGIN ");
                sb.AppendLine("     ,@FROZEN_GUBUN ");
                sb.AppendLine("     ,@UNION_CD ");
                sb.AppendLine("     ,@GRADE ");
                sb.AppendLine("     ,'" + Common.p_strStaffNo + "' ");
                sb.AppendLine("     ,convert(varchar, getdate(), 120) ");
                sb.AppendLine(" ) ");



                //2019-10-31 이재원 도입기업의 요구에 따라 테이블 구조를 수정하였음
                // 그에 따른 로직 변경
                if (sourceRawGrid.Rows.Count > 0)
                {
                    StringBuilder sb2 = new StringBuilder();
                    int count = 50;
                    for (int i = 0; i < sourceRawGrid.Rows.Count; i++)
                    {
                        if (sourceRawGrid.Rows[i].Cells["source_price"].Value == null)
                            sourceRawGrid.Rows[i].Cells["source_price"].Value = "0";
                        if (sourceRawGrid.Rows[i].Cells["source_weight"].Value == null)
                            sourceRawGrid.Rows[i].Cells["source_price"].Value = "0";


                        sb.AppendLine("declare @item_seq" + (count) + " int ");
                        sb.AppendLine("select @item_seq" + (count) + " =ISNULL(MAX(SEQ),0)+1 from F_RAW_MEAT_DETAIL ");
                        sb.AppendLine("where INPUT_DATE = '" + input_date + "' ");
                        sb.AppendLine("and INPUT_CD =  @seq ");
                        sb.AppendLine("insert into F_RAW_MEAT_DETAIL(");
                        sb.AppendLine("     INPUT_DATE");
                        sb.AppendLine("     ,INPUT_CD ");
                        sb.AppendLine("     ,SEQ ");
                        sb.AppendLine("     ,GRADE ");
                        sb.AppendLine("     ,RAW_MAT_CD ");
                        sb.AppendLine("     ,CUST_CD ");
                        sb.AppendLine("     ,INPUT_PRICE");
                        sb.AppendLine("     ,RAW_MAT_NM");
                        sb.AppendLine("     ,RAW_MAT_WEIGHT ");
                        sb.AppendLine("     ,INSTAFF ");
                        sb.AppendLine("     ,INTIME ");
                        sb.AppendLine("     ,UNION_CD ");
                        sb.AppendLine("     ,MF_DATE ");
                        sb.AppendLine("     ,COUNTRY_ORIGIN ");
                        sb.AppendLine("     ,FROZEN_GUBUN ");
                        sb.AppendLine("     ,EXPRT_DATE ");
                        sb.AppendLine("     ,OUTPUT_YN ");
                        sb.AppendLine(" ) values ( ");
                        sb.AppendLine("      @INPUT_DATE ");
                        sb.AppendLine("     ,@seq ");
                        sb.AppendLine("     ,@item_seq" + (count++) + "  ");
                        sb.AppendLine("     ,@GRADE    ");
                        sb.AppendLine("     ,'" + sourceRawGrid.Rows[i].Cells["RAW_CD"].Value + "' ");
                        sb.AppendLine("     ,@CUST_CD ");
                        sb.AppendLine("     ," + sourceRawGrid.Rows[i].Cells["source_price"].Value + " ");
                        sb.AppendLine("     ,'" + sourceRawGrid.Rows[i].Cells["RAW_NM"].Value + "' ");
                        sb.AppendLine("     ," + sourceRawGrid.Rows[i].Cells["source_weight"].Value + " ");
                        sb.AppendLine("     ,'" + Common.p_strStaffNo + "' ");
                        sb.AppendLine("     ,convert(varchar, getdate(), 120) ");
                        sb.AppendLine("     ,@UNION_CD  ");
                        sb.AppendLine("     ,@MF_DATE  ");
                        sb.AppendLine("     ,@COUNTRY_ORIGIN  ");
                        sb.AppendLine("     ,@FROZEN_GUBUN  ");
                        sb.AppendLine("     ,REPLACE(CONVERT(NVARCHAR(10),DATEADD(DAY, ");
                        sb.AppendLine("     (select EXPRT_COUNT from N_FROZEN_CODE where FROZEN_CD = @FROZEN_GUBUN ) ");
                        sb.AppendLine("     ,@MF_DATE),120),'/','-') ");
                        sb.AppendLine("     ,@OUTPUT_YN ");

                        sb.AppendLine(" ) ");

                    }
                    if (complete_yn.Equals("1"))
                    {
                        sb.AppendLine("    declare @seqDetail int    ");
                        sb.AppendLine("    select @seqDetail = ISNULL(MAX(INPUT_CD),0)+1 from F_RAW_INPUT ");
                        sb.AppendLine("    where INPUT_DATE = @INPUT_DATE ");


                        sb.AppendLine("     insert into F_RAW_INPUT(  ");
                        sb.AppendLine("     INPUT_DATE ");
                        sb.AppendLine("     ,INPUT_CD ");
                        sb.AppendLine("     ,CUST_CD ");
                        sb.AppendLine("     ,COMPLETE_YN ");
                        sb.AppendLine("     ,COMMENT ");
                        sb.AppendLine("     ,INSTAFF ");
                        sb.AppendLine("     ,INTIME ");
                        sb.AppendLine("     ) values ( ");
                        sb.AppendLine("     @INPUT_DATE ");
                        sb.AppendLine("     ,@seqDetail ");
                        sb.AppendLine("     ,@CUST_CD ");
                        sb.AppendLine("     ,@OUTPUT_YN ");
                        sb.AppendLine("     ,@COMMENT ");
                        sb.AppendLine("     ,'" + Common.p_strStaffNo + "' ");
                        sb.AppendLine("     ,convert(varchar, getdate(), 120) ");
                        sb.AppendLine("     ) ");


                        sb.AppendLine(" insert into F_RAW_DETAIL( ");
                        sb.AppendLine(" INPUT_DATE ");
                        sb.AppendLine(" ,INPUT_CD  ");
                        sb.AppendLine(" ,SEQ  ");
                        sb.AppendLine(" ,RAW_MAT_CD  ");
                        sb.AppendLine(" ,UNIT_CD  ");
                        sb.AppendLine(" ,TEMP_AMT  ");
                        sb.AppendLine(" ,TOTAL_AMT  ");
                        sb.AppendLine(" ,CURR_AMT  ");
                        sb.AppendLine(" ,PRICE  ");
                        sb.AppendLine(" ,TOTAL_MONEY  ");
                        sb.AppendLine(" ,INSTAFF  ");
                        sb.AppendLine(" ,INTIME  ");
                        sb.AppendLine(" ,CHECK_YN  ");
                        sb.AppendLine(" ,COMPLETE_YN  ");

                        sb.AppendLine("     ,UNION_CD ");
                        sb.AppendLine("     ,MF_DATE ");
                        sb.AppendLine("     ,COUNTRY_ORIGIN ");
                        sb.AppendLine("     ,FROZEN_GUBUN ");
                        sb.AppendLine("     ,EXPRT_DATE ");
                        sb.AppendLine("     ,GRADE ");

                        sb.AppendLine(" )  ");
                        sb.AppendLine(" select INPUT_DATE   ");
                        sb.AppendLine(" ,@seqDetail  ");
                        sb.AppendLine(" ,ROW_NUMBER() over(order by seq)  ");
                        sb.AppendLine(" ,RAW_MAT_CD  ");
                        sb.AppendLine(" ,(select INPUT_UNIT from N_RAW_CODE where RAW_MAT_CD = A.RAW_MAT_CD)  ");
                        sb.AppendLine(" , case when (select CHECK_GUBUN from N_RAW_CODE where RAW_MAT_CD = A.RAW_MAT_CD) = '0' THEN 0 else A.RAW_MAT_WEIGHT end  ");
                        sb.AppendLine(" , case when (select CHECK_GUBUN from N_RAW_CODE where RAW_MAT_CD = A.RAW_MAT_CD) = '1' THEN 0 else A.RAW_MAT_WEIGHT end  ");
                        sb.AppendLine(" , case when (select CHECK_GUBUN from N_RAW_CODE where RAW_MAT_CD = A.RAW_MAT_CD) = '1' THEN 0 else A.RAW_MAT_WEIGHT end  ");
                        sb.AppendLine(" , INPUT_PRICE  ");
                        sb.AppendLine(" , ((INPUT_PRICE/100) * RAW_MAT_WEIGHT) AS TOTAL_MONEY  ");
                        sb.AppendLine(" , INSTAFF  ");
                        sb.AppendLine(" , INTIME  ");
                        sb.AppendLine(" , (select case when CHECK_GUBUN = '1' then (select S_CODE from SM_FACTORY_COM.dbo.T_S_CODE where L_CODE = '610' and ORD = '1') else (select S_CODE from SM_FACTORY_COM.dbo.T_S_CODE where L_CODE = '610' and ORD = '4') end  from N_RAW_CODE where RAW_MAT_CD = A.RAW_MAT_CD)  ");
                        sb.AppendLine(" , 'N'  ");
                        sb.AppendLine("     ,@UNION_CD  ");
                        sb.AppendLine("     ,@MF_DATE  ");
                        sb.AppendLine("     ,@COUNTRY_ORIGIN  ");
                        sb.AppendLine("     ,@FROZEN_GUBUN  ");
                        sb.AppendLine("     ,REPLACE(CONVERT(NVARCHAR(10),DATEADD(DAY, ");
                        sb.AppendLine("     (select EXPRT_COUNT from N_FROZEN_CODE where FROZEN_CD = @FROZEN_GUBUN ) ");
                        sb.AppendLine("     ,@MF_DATE),120),'/','-') ");
                        sb.AppendLine("     ,@GRADE ");
                        sb.AppendLine("  from F_RAW_MEAT_DETAIL A  ");
                        sb.AppendLine("  where INPUT_DATE = @INPUT_DATE and INPUT_CD = @seq and RAW_MAT_WEIGHT != 0  ");
                    }


                }

                SqlCommand sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@INPUT_DATE", input_date);
                sCommand.Parameters.AddWithValue("@CUST_CD", cust_cd);
                sCommand.Parameters.AddWithValue("@RAW_MAT_CD", meat_cd);
                sCommand.Parameters.AddWithValue("@RAW_MAT_NM", meat_nm);
                sCommand.Parameters.AddWithValue("@INPUT_PRICE", meat_price);
                sCommand.Parameters.AddWithValue("@RAW_MAT_AMOUNT", meat_amount);
                sCommand.Parameters.AddWithValue("@RAW_MAT_WEIGHT", meat_weight);
                sCommand.Parameters.AddWithValue("@COMMENT", comment);
                sCommand.Parameters.AddWithValue("@OUTPUT_YN", complete_yn);
                sCommand.Parameters.AddWithValue("@MF_DATE", mf_date);
                sCommand.Parameters.AddWithValue("@COUNTRY_ORIGIN", country_origin);
                sCommand.Parameters.AddWithValue("@FROZEN_GUBUN", frozen_gubun);
                sCommand.Parameters.AddWithValue("@UNION_CD", unioin_cd);
                sCommand.Parameters.AddWithValue("@GRADE", grade_gubun);


                int qResult = wAdo.SqlCommandEtc(sCommand, "insert_meat_INPUT");
                if (qResult > 0)
                {
                    return 0;
                }
                else return 1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + " - " + e.ToString());
                wnLog.writeLog(wnLog.LOG_ERROR, e.Message + " - " + e.ToString());
                return 9;
            }
        }


        public int Update_Meat_Input(
             string meat_cd
            , string meat_nm
            , string meat_amount
            , string meat_weight
            , string meat_price
            , string input_date
            , string input_cd
            , string comment
            , string cust_cd
            , string complete_yn
            , string mf_date
            , string unioin_cd
            , string grade_gubun
            , string frozen_gubun
            , string country_origin
            , DataGridView sourceRawGrid
            )
        {
            try
            {

                //2019-10-31 이재원 도입기업의 요구에 따라 테이블 구조를 수정하였음
                // 그에 따른 로직 변경

                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb = new StringBuilder();

                sb.AppendLine("Update F_RAW_MEAT_INPUT SET ");
                sb.AppendLine("     CUST_CD =  @CUST_CD   ");
                sb.AppendLine("     ,INPUT_PRICE = @INPUT_PRICE   ");
                sb.AppendLine("     ,RAW_MAT_CD = @RAW_MAT_CD   ");
                sb.AppendLine("     ,RAW_MAT_NM = @RAW_MAT_NM   ");
                sb.AppendLine("     ,RAW_MAT_AMOUNT = @RAW_MAT_AMOUNT   ");
                sb.AppendLine("     ,RAW_MAT_WEIGHT = @RAW_MAT_WEIGHT   ");
                sb.AppendLine("     ,COMMENT = @COMMENT   ");
                sb.AppendLine("     ,MF_DATE = @MF_DATE   ");
                sb.AppendLine("     ,COUNTRY_ORIGIN = @COUNTRY_ORIGIN   ");
                sb.AppendLine("     ,FROZEN_GUBUN = @FROZEN_GUBUN   ");
                sb.AppendLine("     ,UNION_CD = @UNION_CD   ");
                sb.AppendLine("     ,GRADE = @GRADE   ");
                sb.AppendLine("     ,OUTPUT_YN  =  @OUTPUT_YN");
                sb.AppendLine("     ,EXPRT_DATE  =  REPLACE(CONVERT(NVARCHAR(10),DATEADD(DAY, (select EXPRT_COUNT from N_FROZEN_CODE where FROZEN_CD = @FROZEN_GUBUN ) ,@MF_DATE),120),'/','-')");
                sb.AppendLine("     ,UPSTAFF = '" + Common.p_strStaffNo + "' ");
                sb.AppendLine("     ,UPTIME = convert(varchar, getdate(), 120)  ");
                sb.AppendLine("     WHERE INPUT_DATE = '" + input_date + "'    ");
                sb.AppendLine("     and INPUT_CD = '" + input_cd + "'   ");


                if (sourceRawGrid.Rows.Count > 0)
                {
                    StringBuilder sb2 = new StringBuilder();
                    int count = 50;
                    for (int i = 0; i < sourceRawGrid.Rows.Count; i++)
                    {
                        sb.AppendLine("Update F_RAW_MEAT_DETAIL set  ");
                        sb.AppendLine("     CUST_CD = '" + cust_cd + "'   ");
                        sb.AppendLine("     ,INPUT_PRICE = " + sourceRawGrid.Rows[i].Cells["source_price"].Value.ToString().Replace(",", "") + "  ");
                        sb.AppendLine("     ,RAW_MAT_WEIGHT = " + sourceRawGrid.Rows[i].Cells["source_weight"].Value + "  ");
                        sb.AppendLine("     ,UPSTAFF = '" + Common.p_strStaffNo + "' ");
                        sb.AppendLine("     ,UPTIME = convert(varchar, getdate(), 120)  ");
                        sb.AppendLine("     ,UNION_CD = @UNION_CD   ");


                        sb.AppendLine("     ,MF_DATE = @MF_DATE   ");
                        sb.AppendLine("     ,COUNTRY_ORIGIN = @COUNTRY_ORIGIN   ");
                        sb.AppendLine("     ,FROZEN_GUBUN = @FROZEN_GUBUN   ");
                        sb.AppendLine("     ,GRADE = @GRADE   ");
                        sb.AppendLine("     ,OUTPUT_YN = @OUTPUT_YN   ");
                        sb.AppendLine("     ,EXPRT_DATE = REPLACE(CONVERT(NVARCHAR(10),DATEADD(DAY, (select EXPRT_COUNT from N_FROZEN_CODE where FROZEN_CD = @FROZEN_GUBUN ) ,@MF_DATE),120),'/','-')   ");



                        sb.AppendLine("     WHERE INPUT_DATE = '" + input_date + "'    ");
                        sb.AppendLine("     and INPUT_CD = '" + input_cd + "'   ");
                        sb.AppendLine("     and RAW_MAT_CD = '" + sourceRawGrid.Rows[i].Cells["RAW_CD"].Value + "'  ");
                    }
                }

                if (complete_yn.Equals("1"))
                {
                    sb.AppendLine("    declare @seqDetail int    ");
                    sb.AppendLine("    select @seqDetail = ISNULL(MAX(INPUT_CD),0)+1 from F_RAW_INPUT ");
                    sb.AppendLine("    where INPUT_DATE = @INPUT_DATE ");


                    sb.AppendLine("     insert into F_RAW_INPUT(  ");
                    sb.AppendLine("     INPUT_DATE ");
                    sb.AppendLine("     ,INPUT_CD ");
                    sb.AppendLine("     ,CUST_CD ");
                    sb.AppendLine("     ,COMPLETE_YN ");
                    sb.AppendLine("     ,COMMENT ");
                    sb.AppendLine("     ,INSTAFF ");
                    sb.AppendLine("     ,INTIME ");
                    sb.AppendLine("     ) values ( ");
                    sb.AppendLine("     @INPUT_DATE ");
                    sb.AppendLine("     ,@seqDetail ");
                    sb.AppendLine("     ,@CUST_CD ");
                    sb.AppendLine("     ,@OUTPUT_YN ");
                    sb.AppendLine("     ,@COMMENT ");
                    sb.AppendLine("     ,'" + Common.p_strStaffNo + "' ");
                    sb.AppendLine("     ,convert(varchar, getdate(), 120) ");
                    sb.AppendLine("     ) ");


                    sb.AppendLine(" insert into F_RAW_DETAIL( ");
                    sb.AppendLine(" INPUT_DATE ");
                    sb.AppendLine(" ,INPUT_CD  ");
                    sb.AppendLine(" ,SEQ  ");
                    sb.AppendLine(" ,RAW_MAT_CD  ");
                    sb.AppendLine(" ,UNIT_CD  ");
                    sb.AppendLine(" ,TEMP_AMT  ");
                    sb.AppendLine(" ,TOTAL_AMT  ");
                    sb.AppendLine(" ,CURR_AMT  ");
                    sb.AppendLine(" ,PRICE  ");
                    sb.AppendLine(" ,TOTAL_MONEY  ");
                    sb.AppendLine(" ,INSTAFF  ");
                    sb.AppendLine(" ,INTIME  ");
                    sb.AppendLine(" ,CHECK_YN  ");
                    sb.AppendLine(" ,COMPLETE_YN  ");

                    sb.AppendLine("     ,UNION_CD ");
                    sb.AppendLine("     ,MF_DATE ");
                    sb.AppendLine("     ,COUNTRY_ORIGIN ");
                    sb.AppendLine("     ,FROZEN_GUBUN ");
                    sb.AppendLine("     ,EXPRT_DATE ");
                    sb.AppendLine("     ,GRADE ");

                    sb.AppendLine(" )  ");
                    sb.AppendLine(" select INPUT_DATE   ");
                    sb.AppendLine(" ,@seqDetail  ");
                    sb.AppendLine(" ,ROW_NUMBER() over(order by seq)  ");
                    sb.AppendLine(" ,RAW_MAT_CD  ");
                    sb.AppendLine(" ,(select INPUT_UNIT from N_RAW_CODE where RAW_MAT_CD = A.RAW_MAT_CD)  ");
                    sb.AppendLine(" , case when (select CHECK_GUBUN from N_RAW_CODE where RAW_MAT_CD = A.RAW_MAT_CD) = '0' THEN 0 else A.RAW_MAT_WEIGHT end  ");
                    sb.AppendLine(" , case when (select CHECK_GUBUN from N_RAW_CODE where RAW_MAT_CD = A.RAW_MAT_CD) = '1' THEN 0 else A.RAW_MAT_WEIGHT end  ");
                    sb.AppendLine(" , case when (select CHECK_GUBUN from N_RAW_CODE where RAW_MAT_CD = A.RAW_MAT_CD) = '1' THEN 0 else A.RAW_MAT_WEIGHT end  ");
                    sb.AppendLine(" , INPUT_PRICE  ");
                    sb.AppendLine(" , ((INPUT_PRICE/100) * RAW_MAT_WEIGHT) AS TOTAL_MONEY  ");
                    sb.AppendLine(" , INSTAFF  ");
                    sb.AppendLine(" , INTIME  ");
                    sb.AppendLine(" , (select case when CHECK_GUBUN = '1' then (select S_CODE from SM_FACTORY_COM.dbo.T_S_CODE where L_CODE = '610' and ORD = '1') else (select S_CODE from SM_FACTORY_COM.dbo.T_S_CODE where L_CODE = '610' and ORD = '4') end  from N_RAW_CODE where RAW_MAT_CD = A.RAW_MAT_CD)  ");
                    sb.AppendLine(" , 'N'  ");
                    sb.AppendLine("     ,@UNION_CD  ");
                    sb.AppendLine("     ,@MF_DATE  ");
                    sb.AppendLine("     ,@COUNTRY_ORIGIN  ");
                    sb.AppendLine("     ,@FROZEN_GUBUN  ");
                    sb.AppendLine("     ,REPLACE(CONVERT(NVARCHAR(10),DATEADD(DAY, ");
                    sb.AppendLine("     (select EXPRT_COUNT from N_FROZEN_CODE where FROZEN_CD = @FROZEN_GUBUN ) ");
                    sb.AppendLine("     ,@MF_DATE),120),'/','-') ");
                    sb.AppendLine("     ,@GRADE ");
                    sb.AppendLine("  from F_RAW_MEAT_DETAIL A  ");
                    sb.AppendLine("  where INPUT_DATE = @INPUT_DATE and INPUT_CD = @INPUT_CD and RAW_MAT_WEIGHT != 0  ");
                }




                SqlCommand sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@INPUT_DATE", input_date);
                sCommand.Parameters.AddWithValue("@INPUT_CD", input_cd);
                sCommand.Parameters.AddWithValue("@CUST_CD", cust_cd);
                sCommand.Parameters.AddWithValue("@RAW_MAT_CD", meat_cd);
                sCommand.Parameters.AddWithValue("@RAW_MAT_NM", meat_nm);
                sCommand.Parameters.AddWithValue("@INPUT_PRICE", meat_price);
                sCommand.Parameters.AddWithValue("@RAW_MAT_AMOUNT", meat_amount);
                sCommand.Parameters.AddWithValue("@RAW_MAT_WEIGHT", meat_weight);
                sCommand.Parameters.AddWithValue("@COMMENT", comment);
                sCommand.Parameters.AddWithValue("@OUTPUT_YN", complete_yn);
                sCommand.Parameters.AddWithValue("@MF_DATE", mf_date);
                sCommand.Parameters.AddWithValue("@COUNTRY_ORIGIN", country_origin);
                sCommand.Parameters.AddWithValue("@FROZEN_GUBUN", frozen_gubun);
                sCommand.Parameters.AddWithValue("@UNION_CD", unioin_cd);
                sCommand.Parameters.AddWithValue("@GRADE", grade_gubun);

                int qResult = wAdo.SqlCommandEtc(sCommand, "insert_meat_INPUT");
                if (qResult > 0)
                {
                    return 0;
                }
                else return 1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + " - " + e.ToString());
                wnLog.writeLog(wnLog.LOG_ERROR, e.Message + " - " + e.ToString());
                return 9;
            }
        }

        public int Delete_Meat_Input(
            string input_date
            , string input_cd
            )
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb = new StringBuilder();

                sb.AppendLine("DELETE FROM F_RAW_MEAT_INPUT  ");
                sb.AppendLine("WHERE INPUT_DATE = @INPUT_DATE ");
                sb.AppendLine("AND INPUT_CD = @INPUT_CD");

                sb.AppendLine("DELETE FROM F_RAW_MEAT_DETAIL  ");
                sb.AppendLine("WHERE INPUT_DATE = @INPUT_DATE ");
                sb.AppendLine("AND INPUT_CD = @INPUT_CD");

                SqlCommand sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@INPUT_DATE", input_date);
                sCommand.Parameters.AddWithValue("@INPUT_CD", input_cd);


                int qResult = wAdo.SqlCommandEtc(sCommand, "delete_meat_INPUT");
                if (qResult > 0)
                {
                    return 0;
                }
                else return 1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + " - " + e.ToString());
                wnLog.writeLog(wnLog.LOG_ERROR, e.Message + " - " + e.ToString());
                return 9;
            }
        }
        #endregion


        #region 발주서
        public int insertOrder(
          string order_date
        , string txt_cust_cd
        , string in_req_date
        , string pur_yn
        , string comment
        , conDataGridView o_rm_dgv)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb = new StringBuilder();
                sb.AppendLine("declare @seq int ");
                sb.AppendLine("select @seq =ISNULL(MAX(ORDER_CD),0)+1 from F_ORDER ");
                sb.AppendLine("where ORDER_DATE = '" + order_date + "' ");

                sb.AppendLine("insert into F_ORDER(");
                sb.AppendLine("     ORDER_DATE");
                sb.AppendLine("     ,ORDER_CD ");
                sb.AppendLine("     ,CUST_CD ");
                sb.AppendLine("     ,INPUT_REQ_DATE ");
                sb.AppendLine("     ,COMPLETE_YN ");
                sb.AppendLine("     ,STAFF_CD ");
                sb.AppendLine("     ,COMMENT ");
                sb.AppendLine("     ,INTIME ");
                sb.AppendLine(" ) values ( ");
                sb.AppendLine("      @ORDER_DATE ");
                sb.AppendLine("     ,@seq");
                sb.AppendLine("     ,@CUST_CD ");
                sb.AppendLine("     ,@INPUT_REQ_DATE ");
                sb.AppendLine("     ,'" + pur_yn + "' ");
                sb.AppendLine("     ,'" + Common.p_strStaffNo + "' ");
                sb.AppendLine("     ,@COMMENT ");
                sb.AppendLine("     ,convert(varchar, getdate(), 120) ");
                sb.AppendLine(" ) ");

                if (o_rm_dgv.Rows.Count > 0)
                {
                    for (int i = 0; i < o_rm_dgv.Rows.Count; i++)
                    {
                        sb.AppendLine("declare @order_seq" + i + " int ");
                        sb.AppendLine("select @order_seq" + i + " =ISNULL(MAX(SEQ),0)+1 from F_ORDER_DETAIL ");
                        sb.AppendLine("where ORDER_DATE = '" + order_date + "' ");
                        sb.AppendLine("and ORDER_CD =  @seq ");

                        sb.AppendLine("insert into F_ORDER_DETAIL(");
                        sb.AppendLine("     ORDER_DATE ");
                        sb.AppendLine("     ,ORDER_CD ");
                        sb.AppendLine("     ,SEQ ");
                        sb.AppendLine("     ,SPEC ");
                        sb.AppendLine("     ,RAW_MAT_CD ");
                        sb.AppendLine("     ,UNIT_CD ");
                        sb.AppendLine("     ,TOTAL_AMT ");
                        sb.AppendLine("     ,PRICE ");
                        sb.AppendLine("     ,TOTAL_MONEY ");
                        sb.AppendLine("     ,INSTAFF ");
                        sb.AppendLine("     ,INTIME ");
                        sb.AppendLine("  )values ( ");
                        sb.AppendLine("     '" + order_date + "' ");
                        sb.AppendLine("      ,@seq ");
                        sb.AppendLine("     ,@order_seq" + i + " ");
                        sb.AppendLine("     ,'" + o_rm_dgv.Rows[i].Cells["SPEC"].Value + "' ");
                        sb.AppendLine("     ,'" + o_rm_dgv.Rows[i].Cells["RAW_MAT_CD"].Value + "' ");
                        sb.AppendLine("     ,'" + o_rm_dgv.Rows[i].Cells["UNIT_CD"].Value + "' ");
                        sb.AppendLine("     ,'" + ((string)o_rm_dgv.Rows[i].Cells["TOTAL_AMT"].Value).Replace(",", "") + "' ");
                        sb.AppendLine("     ,'" + ((string)o_rm_dgv.Rows[i].Cells["PRICE"].Value).Replace(",", "") + "' ");
                        sb.AppendLine("     ,'" + ((string)o_rm_dgv.Rows[i].Cells["TOTAL_MONEY"].Value).Replace(",", "") + "' ");
                        sb.AppendLine("     ,'" + Common.p_strStaffNo + "' ");
                        sb.AppendLine("     ,convert(varchar, getdate(), 120)  ");
                        sb.AppendLine("  )");
                    }
                }
                //Common.p_strStaffNo 

                SqlCommand sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@ORDER_DATE", order_date);
                sCommand.Parameters.AddWithValue("@CUST_CD", txt_cust_cd);
                sCommand.Parameters.AddWithValue("@INPUT_REQ_DATE", in_req_date);
                sCommand.Parameters.AddWithValue("@COMMENT", comment);

                int qResult = wAdo.SqlCommandEtc(sCommand, "insert_ORDER_TB");
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
        #endregion 발주서

        #region 원자재입고등록

        public int insertRmInput(
          string input_date
        , string txt_cust_cd
        , string input_yn
        , string comment
        , conDataGridView in_rm_dgv)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb;
                SqlCommand sCommand;
                for (int i = 0; i < in_rm_dgv.Rows.Count; i++)
                {
                    if ((string)in_rm_dgv.Rows[i].Cells["ORDER_DATE"].Value != null && (string)in_rm_dgv.Rows[i].Cells["ORDER_DATE"].Value != "")
                    {
                        sb = new StringBuilder();
                        sb.AppendLine(" select A.ORDER_DATE,A.ORDER_CD,B.SEQ,C.ORDER_AMT, C.INPUT_AMT");
                        sb.AppendLine(" FROM F_ORDER A ");
                        sb.AppendLine(" LEFT OUTER JOIN F_ORDER_DETAIL B  ");
                        sb.AppendLine(" ON A.ORDER_DATE = B.ORDER_DATE ");
                        sb.AppendLine("     AND A.ORDER_CD = B.ORDER_CD ");
                        sb.AppendLine(" LEFT OUTER JOIN(	 ");
                        sb.AppendLine("                     SELECT AA.ORDER_DATE	 ");
                        sb.AppendLine("                           ,AA.ORDER_CD       ");
                        sb.AppendLine("                           ,AA.SEQ ");
                        sb.AppendLine("                           ,FLOOR(ISNULL(AA.TOTAL_AMT,0)) AS ORDER_AMT ");
                        sb.AppendLine("                           ,ISNULL(SUM(BB.TOTAL_AMT),0) AS INPUT_AMT ");
                        sb.AppendLine("                           , ISNULL(AA.TOTAL_AMT,0)-ISNULL(SUM(BB.TOTAL_AMT),0) AS NO_INPUT_AMT ");
                        sb.AppendLine("                     FROM F_ORDER_DETAIL AA ");
                        sb.AppendLine("                     LEFT OUTER JOIN F_RAW_DETAIL BB ");
                        sb.AppendLine("                     ON AA.ORDER_DATE = BB.ORDER_DATE ");
                        sb.AppendLine("                         AND AA.ORDER_CD = BB.ORDER_CD ");
                        sb.AppendLine("                         AND AA.SEQ = BB.ORDER_SEQ ");
                        sb.AppendLine("                     GROUP BY AA.ORDER_DATE,AA.ORDER_CD,AA.SEQ,AA.TOTAL_AMT)C ");
                        sb.AppendLine(" ON A.ORDER_DATE = C.ORDER_DATE  ");
                        sb.AppendLine("     AND A.ORDER_CD = C.ORDER_CD ");
                        sb.AppendLine("     AND B.SEQ = C.SEQ  ");
                        sb.AppendLine(" WHERE A.ORDER_DATE = '" + in_rm_dgv.Rows[i].Cells["ORDER_DATE"].Value + "' ");
                        sb.AppendLine("      AND A.ORDER_CD = '" + in_rm_dgv.Rows[i].Cells["ORDER_CD"].Value + "' ");
                        sb.AppendLine("      AND B.SEQ = '" + in_rm_dgv.Rows[i].Cells["ORDER_SEQ"].Value + "' ");

                        sCommand = new SqlCommand(sb.ToString());
                        if (sCommand.CommandText.Equals(null))
                        {
                            wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                            return 2;
                        }

                        DataTable dt = wAdo.SqlCommandSelect(sCommand);

                        double order_amt = double.Parse(dt.Rows[0]["ORDER_AMT"].ToString());
                        double input_amt = double.Parse(dt.Rows[0]["INPUT_AMT"].ToString());
                        double grd_total_amt = double.Parse(((string)in_rm_dgv.Rows[i].Cells["TOTAL_AMT"].Value).Replace(",", ""));
                        double grd_ord_total_amt = double.Parse(((string)in_rm_dgv.Rows[i].Cells["OLD_TOTAL_AMT"].Value)); //백업은 콤마 정의 안함

                        // 발주수량 - 입고수량 - 입력한 수량 값 = 결과값

                        double rs_num = order_amt - input_amt - grd_total_amt;
                        if (rs_num < 0)
                        {
                            StringBuilder alert_sb = new StringBuilder();
                            alert_sb.AppendLine(i + 1 + "번째 줄 원부재료에 포함된 발주번호 \n ");
                            alert_sb.AppendLine(in_rm_dgv.Rows[i].Cells["ORDER_DATE"].Value + " [" + in_rm_dgv.Rows[i].Cells["ORDER_CD"].Value + "] 의 발주수량보다 더 많게 입력하셨습니다. \n");
                            alert_sb.AppendLine("그대로 저장하시겠습니까? (저장:예 / 취소:아니오)");

                            DialogResult msgOk = MessageBox.Show(alert_sb.ToString(), "삭제여부", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (msgOk == DialogResult.No)
                            {
                                return 3;
                            }
                        }
                    }
                }

                sb = new StringBuilder();
                sb.AppendLine("declare @seq int ");
                sb.AppendLine("select @seq =ISNULL(MAX(INPUT_CD),0)+1 from F_RAW_INPUT ");
                sb.AppendLine("where INPUT_DATE = '" + input_date + "' ");

                sb.AppendLine("insert into F_RAW_INPUT(");
                sb.AppendLine("     INPUT_DATE");
                sb.AppendLine("     ,INPUT_CD ");
                sb.AppendLine("     ,CUST_CD ");
                sb.AppendLine("     ,COMPLETE_YN ");
                sb.AppendLine("     ,COMMENT ");
                sb.AppendLine("     ,INSTAFF ");
                sb.AppendLine("     ,INTIME ");

                sb.AppendLine(" ) values ( ");
                sb.AppendLine("      @INPUT_DATE ");
                sb.AppendLine("     ,@seq");
                sb.AppendLine("     ,@CUST_CD ");
                sb.AppendLine("     ,'" + input_yn + "' ");
                sb.AppendLine("     ,@COMMENT ");
                sb.AppendLine("     ,'" + Common.p_strStaffNo + "' ");
                sb.AppendLine("     ,convert(varchar, getdate(), 120) ");
                sb.AppendLine(" ) ");

                if (in_rm_dgv.Rows.Count > 0)
                {
                    for (int i = 0; i < in_rm_dgv.Rows.Count; i++)
                    {

                        sb.AppendLine("declare @input_seq" + i + " int, @chk_gbn" + i + "  nvarchar(1), @chk_yn" + i + " nvarchar(1), @final_amt" + i + " nvarchar(20) ");
                        sb.AppendLine("select @input_seq" + i + " =ISNULL(MAX(SEQ),0)+1 from F_RAW_DETAIL ");
                        sb.AppendLine("where INPUT_DATE = '" + input_date + "' ");
                        sb.AppendLine("and INPUT_CD =  @seq ");

                        sb.AppendLine("select @chk_gbn" + i + " = check_gubun from N_RAW_CODE ");
                        sb.AppendLine("where RAW_MAT_CD = '" + in_rm_dgv.Rows[i].Cells["RAW_MAT_CD"].Value + "' ");

                        sb.AppendLine("IF @chk_gbn" + i + " = '1' BEGIN set @chk_yn" + i + " = 'S' set @final_amt" + i + " = '0' END "); //원자재 검사여부가 검사일 경우 'S' 대기 
                        sb.AppendLine("ELSE BEGIN set @chk_yn" + i + " = 'O' set @final_amt" + i + " = '" + ((string)in_rm_dgv.Rows[i].Cells["TOTAL_AMT"].Value).Replace(",", "") + "' END "); //원자재 검사여부가 생략일 경우 'O'

                        sb.AppendLine("insert into F_RAW_DETAIL(");
                        sb.AppendLine("     INPUT_DATE ");
                        sb.AppendLine("     ,INPUT_CD ");
                        sb.AppendLine("     ,SEQ ");
                        sb.AppendLine("     ,RAW_MAT_CD ");
                        sb.AppendLine("     ,SPEC ");
                        sb.AppendLine("     ,UNIT_CD ");
                        sb.AppendLine("     ,TEMP_AMT ");
                        sb.AppendLine("     ,TOTAL_AMT ");
                        sb.AppendLine("     ,CURR_AMT ");
                        sb.AppendLine("     ,PRICE ");
                        sb.AppendLine("     ,TOTAL_MONEY ");
                        sb.AppendLine("     ,HEAT_NO ");
                        sb.AppendLine("     ,HEAT_TIME ");
                        sb.AppendLine("     ,ORDER_DATE ");
                        sb.AppendLine("     ,ORDER_CD ");
                        sb.AppendLine("     ,ORDER_SEQ ");
                        sb.AppendLine("     ,COMPLETE_YN ");
                        sb.AppendLine("     ,CHECK_YN ");
                        sb.AppendLine("     ,INSTAFF ");
                        sb.AppendLine("     ,INTIME ");
                        sb.AppendLine("  )values ( ");
                        sb.AppendLine("     '" + input_date + "' ");
                        sb.AppendLine("      ,@seq ");
                        sb.AppendLine("     ,@input_seq" + i + " ");
                        sb.AppendLine("     ,'" + in_rm_dgv.Rows[i].Cells["RAW_MAT_CD"].Value + "' ");
                        sb.AppendLine("     ,'" + in_rm_dgv.Rows[i].Cells["SPEC"].Value + "' ");
                        sb.AppendLine("     ,'" + in_rm_dgv.Rows[i].Cells["UNIT_CD"].Value + "' ");
                        sb.AppendLine("     ,'" + ((string)in_rm_dgv.Rows[i].Cells["TOTAL_AMT"].Value).Replace(",", "") + "' "); //가입고
                        sb.AppendLine("     ,@final_amt" + i + " "); //최종입고
                        sb.AppendLine("     ,@final_amt" + i + " "); //현재입고
                        sb.AppendLine("     ,'" + ((string)in_rm_dgv.Rows[i].Cells["PRICE"].Value).Replace(",", "") + "' ");
                        sb.AppendLine("     ,'" + ((string)in_rm_dgv.Rows[i].Cells["TOTAL_MONEY"].Value).Replace(",", "") + "' ");
                        sb.AppendLine("     ,'" + in_rm_dgv.Rows[i].Cells["HEAT_NO"].Value + "' ");
                        sb.AppendLine("     ,'" + in_rm_dgv.Rows[i].Cells["HEAT_TIME"].Value + "' ");
                        sb.AppendLine("     ,'" + in_rm_dgv.Rows[i].Cells["ORDER_DATE"].Value + "' ");
                        sb.AppendLine("     ,'" + in_rm_dgv.Rows[i].Cells["ORDER_CD"].Value + "' ");
                        sb.AppendLine("     ,'" + in_rm_dgv.Rows[i].Cells["ORDER_SEQ"].Value + "' ");
                        sb.AppendLine("     ,'" + input_yn + "' ");

                        sb.AppendLine("     , @chk_yn" + i + "  "); //BE
                        sb.AppendLine("     ,'" + Common.p_strStaffNo + "' ");
                        sb.AppendLine("     ,convert(varchar, getdate(), 120)  ");
                        sb.AppendLine("  )");


                        //sb.AppendLine(" update N_RAW_CODE set ");
                        //sb.AppendLine("     BAL_STOCK = ISNULL(BAL_STOCK,0) +" + double.Parse(((string)in_rm_dgv.Rows[i].Cells["TOTAL_AMT"].Value).Replace(",", "") + " ") );
                        //sb.AppendLine(" where RAW_MAT_CD = '" +in_rm_dgv.Rows[i].Cells["RAW_MAT_CD"].Value + "' ");
                    }
                }

                sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@INPUT_DATE", input_date);
                sCommand.Parameters.AddWithValue("@CUST_CD", txt_cust_cd);
                sCommand.Parameters.AddWithValue("@COMMENT", comment);

                int qResult = wAdo.SqlCommandEtc(sCommand, "insert_RAW_INPUT_TB");
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

        #endregion 원자재입고등록


        #region 소요산출량 발주서 일괄 등록

        public int insertSoyo(
              DataGridView dgv
            , DataGridView chk_dgv
            , int cust_max_num)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                //2019-07-29 유정훈
                //거래처를 GROUP으로 나눠 번호 순을 매김..  

                for (int i = 1; i <= cust_max_num; i++)
                {
                    string cust_cd = "";
                    for (int j = 0; j < dgv.Rows.Count; j++)
                    {
                        if (int.Parse(dgv.Rows[j].Cells["CUST_NUM"].Value.ToString()) == i)
                        {
                            cust_cd = dgv.Rows[j].Cells["PUR_CUST_CD"].Value.ToString(); //거래처 번호가 맞으면 cust_cd를 변수에 저장
                            break;
                        }
                    }

                    string order_date = DateTime.Now.ToString("yyyy-MM-dd");
                    sb.AppendLine("declare @seq" + i + " int ");
                    sb.AppendLine("select  @seq" + i + " =ISNULL(MAX(ORDER_CD),0)+1 from F_ORDER ");
                    sb.AppendLine("where ORDER_DATE = '" + order_date + "' ");

                    sb.AppendLine("insert into F_ORDER(");
                    sb.AppendLine("     ORDER_DATE");
                    sb.AppendLine("     ,ORDER_CD ");
                    sb.AppendLine("     ,CUST_CD ");
                    sb.AppendLine("     ,INPUT_REQ_DATE ");
                    sb.AppendLine("     ,COMPLETE_YN ");
                    sb.AppendLine("     ,STAFF_CD ");
                    sb.AppendLine("     ,COMMENT ");
                    sb.AppendLine("     ,INTIME ");
                    sb.AppendLine(" ) values ( ");
                    sb.AppendLine("      '" + order_date + "' ");
                    sb.AppendLine("     ,@seq" + i + " ");
                    sb.AppendLine("     ,'" + cust_cd + "' ");
                    sb.AppendLine("     ,convert(varchar, getdate(), 23) ");
                    sb.AppendLine("     ,'N' ");
                    sb.AppendLine("     ,'" + Common.p_strStaffNo + "' ");
                    sb.AppendLine("     ,'' ");
                    sb.AppendLine("     ,convert(varchar, getdate(), 120) ");
                    sb.AppendLine(" ) ");

                    for (int j = 0; j < dgv.Rows.Count; j++)
                    {
                        string rs_amt = ((string)dgv.Rows[j].Cells["RS_AMT"].Value).Replace(",", "");
                        double d_rs_amt = double.Parse(rs_amt);
                        if (cust_cd.ToString().Equals(dgv.Rows[j].Cells["PUR_CUST_CD"].Value.ToString()) && d_rs_amt >= 0)
                        {
                            sb.AppendLine("declare @order_seq" + j + " int ");
                            sb.AppendLine("select @order_seq" + j + " =ISNULL(MAX(SEQ),0)+1 from F_ORDER_DETAIL ");
                            sb.AppendLine("where ORDER_DATE = '" + order_date + "' ");
                            sb.AppendLine("and ORDER_CD =  @seq" + i + " ");

                            sb.AppendLine("insert into F_ORDER_DETAIL(");
                            sb.AppendLine("     ORDER_DATE ");
                            sb.AppendLine("     ,ORDER_CD ");
                            sb.AppendLine("     ,SEQ ");
                            sb.AppendLine("     ,RAW_MAT_CD ");
                            sb.AppendLine("     ,UNIT_CD ");
                            sb.AppendLine("     ,TOTAL_AMT ");
                            sb.AppendLine("     ,PRICE ");
                            sb.AppendLine("     ,TOTAL_MONEY ");
                            sb.AppendLine("     ,INSTAFF ");
                            sb.AppendLine("     ,INTIME ");
                            sb.AppendLine("  )values ( ");
                            sb.AppendLine("     '" + order_date + "' ");
                            sb.AppendLine("      ,@seq" + i + " ");
                            sb.AppendLine("     ,@order_seq" + j + " ");
                            sb.AppendLine("     ,'" + dgv.Rows[j].Cells["RAW_MAT_CD"].Value + "' ");
                            sb.AppendLine("     ,'" + dgv.Rows[j].Cells["UNIT_CD"].Value + "' ");
                            sb.AppendLine("     ,'" + ((string)dgv.Rows[j].Cells["RS_AMT"].Value).Replace(",", "") + "' ");
                            sb.AppendLine("     ,'" + ((string)dgv.Rows[j].Cells["PRICE"].Value).Replace(",", "") + "' ");
                            sb.AppendLine("     ,'" + ((string)dgv.Rows[j].Cells["TOTAL_MONEY"].Value).Replace(",", "") + "' ");
                            sb.AppendLine("     ,'" + Common.p_strStaffNo + "' ");
                            sb.AppendLine("     ,convert(varchar, getdate(), 120)  ");
                            sb.AppendLine("  )");
                        }
                    }
                }

                for (int i = 0; i < chk_dgv.Rows.Count; i++)
                {
                    sb.AppendLine("update F_PLAN set");
                    sb.AppendLine("      ORDER_YN = 'Y'");
                    sb.AppendLine("     ,UPSTAFF = '" + Common.p_strStaffNo + "' ");
                    sb.AppendLine("     ,UPTIME = convert(varchar, getdate(), 120) ");

                    sb.AppendLine(" where PLAN_DATE = '" + chk_dgv.Rows[i].Cells["PLAN_DATE"].Value + "'  and PLAN_CD= '" + chk_dgv.Rows[i].Cells["PLAN_CD"].Value + "' ");
                }

                SqlCommand sCommand = new SqlCommand(sb.ToString());

                int qResult = wAdo.SqlCommandEtc(sCommand, "insert_SOYO_ORDER_TB");
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

        #endregion 소요산출량 발주서 일괄 등록

        #region 작업지시서 등록

        public int insertWork(
              string work_date
            , string txt_work_cd
            , string txt_lot_no
            , string txt_item_cd
            , string txt_cust_cd
            , string txt_inst_amt
            , string deliver_req_date
            , string cmb_line
            , string cmb_worker
            , string txt_plan_num
            , string txt_plan_item
            , string txt_inst_notice
            , string txt_char_amt
            , string txt_pack_amt
            , conDataGridView w_rm_dgv
            , DataGridView w_half_dgv)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb = new StringBuilder();
                sb.AppendLine("declare @seq int ");
                sb.AppendLine("select @seq =ISNULL(MAX(RIGHT(LOT_NO,4)),0)+1 from F_WORK_INST "); //0001 이면 1+1 = 2로 SEQ에 저장
                sb.AppendLine("where W_INST_DATE LIKE '" + work_date.Substring(0, 7).ToString() + "%'"); //2019-05

                sb.AppendLine("declare @seq1 int ");
                sb.AppendLine("select @seq1 =ISNULL(MAX(W_INST_CD),0)+1 from F_WORK_INST ");
                sb.AppendLine("where W_INST_DATE = '" + work_date + "' "); //일별 체크 

                sb.AppendLine("insert into F_WORK_INST(");
                sb.AppendLine("     W_INST_DATE");
                sb.AppendLine("     ,W_INST_CD ");
                sb.AppendLine("     ,LOT_NO ");
                sb.AppendLine("     ,ITEM_CD ");
                sb.AppendLine("     ,CUST_CD ");
                sb.AppendLine("     ,INST_AMT ");
                sb.AppendLine("     ,DELIVERY_DATE ");
                sb.AppendLine("     ,LINE_CD ");
                sb.AppendLine("     ,WORKER_CD");
                sb.AppendLine("     ,PLAN_NUM");
                sb.AppendLine("     ,PLAN_ITEM");
                sb.AppendLine("     ,CHARGE_AMT ");
                sb.AppendLine("     ,PACK_AMT ");
                sb.AppendLine("     ,COMPLETE_YN ");
                sb.AppendLine("     ,RAW_OUT_YN ");
                sb.AppendLine("     ,INST_NOTICE ");
                sb.AppendLine("     ,INSTAFF ");
                sb.AppendLine("     ,INTIME ");
                sb.AppendLine(" ) values ( ");
                sb.AppendLine("      @W_INST_DATE ");
                sb.AppendLine("     ,@seq1");
                sb.AppendLine("     ,'" + txt_lot_no + "'+RIGHT('000'+ convert(varchar, @seq), 4) "); //yyMMdd000n
                sb.AppendLine("     ,@ITEM_CD ");
                sb.AppendLine("     ,@CUST_CD ");
                sb.AppendLine("     ,@INST_AMT ");
                sb.AppendLine("     ,@DELIVERY_DATE ");
                sb.AppendLine("     ,@LINE_CD ");
                sb.AppendLine("     ,@WORKER_CD ");
                sb.AppendLine("     ,@PLAN_NUM ");
                sb.AppendLine("     ,@PLAN_ITEM ");
                sb.AppendLine("     ,@CHARGE_AMT ");
                sb.AppendLine("     ,@PACK_AMT ");
                sb.AppendLine("     ,'N' ");
                sb.AppendLine("     ,'N' ");
                sb.AppendLine("     ,@INST_NOTICE ");
                sb.AppendLine("     ,'" + Common.p_strStaffNo + "' ");
                sb.AppendLine("     ,convert(varchar, getdate(), 120) ");
                sb.AppendLine(" ) ");

                if (w_rm_dgv.Rows.Count > 0)
                {
                    for (int i = 0; i < w_rm_dgv.Rows.Count; i++)
                    {
                        sb.AppendLine("declare @work_seq" + i + " int ");
                        sb.AppendLine("select @work_seq" + i + " =ISNULL(MAX(SEQ),0)+1 from F_WORK_INST_DETAIL ");
                        sb.AppendLine("where W_INST_DATE = '" + work_date + "' ");
                        sb.AppendLine("and W_INST_CD =  @seq1 ");

                        sb.AppendLine("insert into F_WORK_INST_DETAIL(");
                        sb.AppendLine("     W_INST_DATE ");
                        sb.AppendLine("     ,W_INST_CD ");
                        sb.AppendLine("     ,SEQ ");
                        sb.AppendLine("     ,LOT_NO ");
                        sb.AppendLine("     ,RAW_MAT_CD ");
                        sb.AppendLine("     ,SOYO_AMT ");
                        sb.AppendLine("     ,TOTAL_AMT ");
                        sb.AppendLine("     ,INSTAFF");
                        sb.AppendLine("     ,INTIME");
                        sb.AppendLine("  )values ( ");
                        sb.AppendLine("     '" + work_date + "' ");
                        sb.AppendLine("      ,@seq1 ");
                        sb.AppendLine("     ,@work_seq" + i + " ");
                        sb.AppendLine("     ,'" + txt_lot_no + "'+RIGHT('000'+ convert(varchar, @seq), 4) ");
                        sb.AppendLine("     ,'" + ((string)w_rm_dgv.Rows[i].Cells["RAW_MAT_CD"].Value).Replace(",", "") + "' ");
                        sb.AppendLine("     ,'" + ((string)w_rm_dgv.Rows[i].Cells["SOYO_AMT"].Value).Replace(",", "") + "' ");
                        sb.AppendLine("     ,'" + ((string)w_rm_dgv.Rows[i].Cells["TOTAL_SOYO_AMT"].Value).Replace(",", "") + "' ");
                        sb.AppendLine("     ,'" + Common.p_strStaffNo + "' ");
                        sb.AppendLine("     ,convert(varchar, getdate(), 120) ");

                        sb.AppendLine("  )");
                    }
                }

                if (w_half_dgv.Rows.Count > 0)
                {
                    for (int i = 0; i < w_half_dgv.Rows.Count; i++)
                    {
                        sb.AppendLine("declare @half_seq" + i + " int ");
                        sb.AppendLine("select @half_seq" + i + " =ISNULL(MAX(SEQ),0)+1 from F_WORK_INST_HALF_DETAIL ");
                        sb.AppendLine("where W_INST_DATE = '" + work_date + "' ");
                        sb.AppendLine("and W_INST_CD =  @seq1 ");

                        sb.AppendLine("insert into F_WORK_INST_HALF_DETAIL(");
                        sb.AppendLine("     W_INST_DATE ");
                        sb.AppendLine("     ,W_INST_CD ");
                        sb.AppendLine("     ,SEQ ");
                        sb.AppendLine("     ,LOT_NO ");
                        sb.AppendLine("     ,HALF_ITEM_CD ");
                        sb.AppendLine("     ,SOYO_AMT ");
                        sb.AppendLine("     ,TOTAL_AMT ");
                        sb.AppendLine("     ,INSTAFF");
                        sb.AppendLine("     ,INTIME");
                        sb.AppendLine("  )values ( ");
                        sb.AppendLine("     '" + work_date + "' ");
                        sb.AppendLine("      ,@seq1 ");
                        sb.AppendLine("     ,@half_seq" + i + " ");
                        sb.AppendLine("     ,'" + txt_lot_no + "'+RIGHT('000'+ convert(varchar, @seq), 4) ");
                        sb.AppendLine("     ,'" + ((string)w_half_dgv.Rows[i].Cells["HALF_ITEM_CD"].Value).Replace(",", "") + "' ");
                        sb.AppendLine("     ,'" + ((string)w_half_dgv.Rows[i].Cells["H_SOYO_AMT"].Value).Replace(",", "") + "' ");
                        sb.AppendLine("     ,'" + ((string)w_half_dgv.Rows[i].Cells["H_TOTAL_SOYO_AMT"].Value).Replace(",", "") + "' ");
                        sb.AppendLine("     ,'" + Common.p_strStaffNo + "' ");
                        sb.AppendLine("     ,convert(varchar, getdate(), 120) ");

                        sb.AppendLine("  )");
                    }
                }


                SqlCommand sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@W_INST_DATE", work_date);
                sCommand.Parameters.AddWithValue("@ITEM_CD", txt_item_cd);
                sCommand.Parameters.AddWithValue("@CUST_CD", txt_cust_cd);
                sCommand.Parameters.AddWithValue("@INST_AMT", txt_inst_amt.Replace(",", ""));
                sCommand.Parameters.AddWithValue("@DELIVERY_DATE", deliver_req_date);
                sCommand.Parameters.AddWithValue("@LINE_CD", cmb_line);
                sCommand.Parameters.AddWithValue("@WORKER_CD", cmb_worker);
                sCommand.Parameters.AddWithValue("@PLAN_NUM", txt_plan_num);
                sCommand.Parameters.AddWithValue("@PLAN_ITEM", txt_plan_item);
                sCommand.Parameters.AddWithValue("@CHARGE_AMT", txt_char_amt.Replace(",", ""));
                sCommand.Parameters.AddWithValue("@PACK_AMT", txt_pack_amt.Replace(",", ""));
                sCommand.Parameters.AddWithValue("@INST_NOTICE", txt_inst_notice);
                int qResult = wAdo.SqlCommandEtc(sCommand, "insert_WORK_TB");
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

        #endregion 작업지시서 등록


        #region 작업공정 등록
        public int insert_Work_Flow(
             string txt_lot_no
           , string txt_item_cd
           , conDataGridView[] dgv
           , Label[] lbl_flow_cd
           , Label[] lbl_flow_seq
           , Label[] lbl_item_iden
           , int flow_cnt
           , String strCustCD)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();
                string flow_date = DateTime.Today.ToString("yyyy-MM-dd");
                sb = new StringBuilder();
                //sb.AppendLine("declare @seq int ");
                //sb.AppendLine("select @seq =ISNULL(MAX(FLOW_CD),0)+1 from F_FLOW ");
                //sb.AppendLine("where FLOW_DATE = '" + flow_date + "' ");

                sb.AppendLine("insert into F_WORK_FLOW(");
                //sb.AppendLine("     ,FLOW_CD ");
                sb.AppendLine("      LOT_NO ");
                sb.AppendLine("     ,FLOW_DATE");
                sb.AppendLine("     ,ITEM_CD");
                sb.AppendLine("     ,COMPLETE_YN ");
                sb.AppendLine("     ,INSTAFF ");
                sb.AppendLine("     ,INTIME ");
                sb.AppendLine(" ) values ( ");
                //sb.AppendLine("     ,@seq");
                sb.AppendLine("      @LOT_NO");
                sb.AppendLine("      ,@FLOW_DATE ");
                sb.AppendLine("      ,@ITEM_CD ");
                sb.AppendLine("     ,'N'");
                sb.AppendLine("     ,'" + Common.p_strStaffNo + "' ");
                sb.AppendLine("     ,convert(varchar, getdate(), 120) ");
                sb.AppendLine(" ) ");

                for (int i = 0; i < flow_cnt; i++) //제품 공정 마지막 단계까지 ..  
                {
                    if (dgv[i].Rows.Count > 0)
                    {
                        for (int j = 0; j < dgv[i].Rows.Count; j++)
                        {
                            sb.AppendLine("insert into F_WORK_FLOW_DETAIL(");
                            sb.AppendLine("      LOT_NO ");
                            sb.AppendLine("      ,ITEM_CD ");
                            sb.AppendLine("      ,CUST_CD");
                            sb.AppendLine("      ,LOT_SUB ");
                            sb.AppendLine("      ,F_STEP ");
                            sb.AppendLine("      ,FLOW_CD ");
                            sb.AppendLine("      ,SEQ ");
                            sb.AppendLine("      ,F_SUB_DATE ");
                            sb.AppendLine("      ,F_SUB_AMT ");
                            sb.AppendLine("      ,LOSS ");
                            sb.AppendLine("      ,POOR_CD ");
                            sb.AppendLine("      ,POOR_AMT ");
                            sb.AppendLine("      ,COMPLETE_YN ");
                            sb.AppendLine("      ,CHECK_YN ");
                            sb.AppendLine("      ,ITEM_CHECK_YN ");
                            sb.AppendLine("      ,INSTAFF ");
                            sb.AppendLine("      ,INTIME ");
                            sb.AppendLine("      ,COMMENT ");
                            sb.AppendLine(" ) values ( ");
                            sb.AppendLine("      '" + (string)dgv[i].Rows[j].Cells[0].Value + "' ");
                            sb.AppendLine("      ,@ITEM_CD ");
                            sb.AppendLine("      ,'" + strCustCD + "'");
                            sb.AppendLine("      , '" + (string)dgv[i].Rows[j].Cells[1].Value + "' ");
                            sb.AppendLine("      , '" + (i + 1) + "' ");
                            sb.AppendLine("      , '" + lbl_flow_cd[i].Text.ToString() + "' ");
                            sb.AppendLine("      , '" + lbl_flow_seq[i].Text.ToString() + "' ");
                            sb.AppendLine("      , '" + (string)dgv[i].Rows[j].Cells[2].Value + "' ");
                            sb.AppendLine("      , '" + ((string)dgv[i].Rows[j].Cells[3].Value).Replace(",", "") + "' ");
                            sb.AppendLine("      , '" + ((string)dgv[i].Rows[j].Cells[4].Value).Replace(",", "") + "' ");
                            if (dgv[i].Rows[j].Cells[5].Value == null)
                            {
                                dgv[i].Rows[j].Cells[5].Value = "";
                            }
                            sb.AppendLine("      , '" + (string)dgv[i].Rows[j].Cells[5].Value + "' "); //POOR_CD
                            sb.AppendLine("      , '" + ((string)dgv[i].Rows[j].Cells[6].Value).Replace(",", "") + "' "); //POOR_AMT
                            sb.AppendLine("      , 'N' ");
                            sb.AppendLine("      , 'S' "); //S -> 대기 
                            sb.AppendLine("      , 'S' "); //S -> 대기 
                            //sb.AppendLine("      , (select FLOW_CHK_YN from N_FLOW_CODE where FLOW_CD = '"+ lbl_flow_cd[i].Text.ToString()+"') ");
                            sb.AppendLine("      , '" + Common.p_strStaffNo + "' ");
                            sb.AppendLine("      , convert(varchar, getdate(), 120) ");
                            sb.AppendLine("      ,'' ");
                            sb.AppendLine("      ) ");
                        }
                    }
                }

                bool chk = false;
                //int input_amt = 0;
                for (int i = 0; i < flow_cnt; i++)
                {
                    if (lbl_item_iden[i].Text.ToString().Equals("Y"))
                    {
                        chk = true;
                        break;
                    }
                }

                if (chk)  //제품식별표가 Y
                {
                    for (int i = 0; i < dgv[flow_cnt - 1].Rows.Count; i++)
                    {
                        string item_date = flow_date;

                        sb.AppendLine("declare @seq" + i + " int ");
                        sb.AppendLine("select @seq" + i + " =ISNULL(MAX(INPUT_CD),0)+1 from F_ITEM_INPUT ");
                        sb.AppendLine("where INPUT_DATE = '" + flow_date + "' ");

                        sb.AppendLine("insert into F_ITEM_INPUT(");
                        sb.AppendLine("      INPUT_DATE ");
                        sb.AppendLine("      ,INPUT_CD ");
                        sb.AppendLine("      ,ITEM_CD ");
                        sb.AppendLine("      ,LOT_NO ");
                        sb.AppendLine("      ,LOT_SUB ");
                        sb.AppendLine("      ,F_STEP ");
                        sb.AppendLine("      ,FLOW_CD ");
                        sb.AppendLine("      ,INPUT_AMT ");
                        sb.AppendLine("      ,INSTAFF ");
                        sb.AppendLine("      ,INTIME ");
                        sb.AppendLine("      ,CURR_AMT ");
                        sb.AppendLine("      ,COMPLETE_YN ");
                        sb.AppendLine(" ) values ( ");
                        sb.AppendLine("       '" + item_date + "' ");
                        sb.AppendLine("      ,@seq" + i + " ");
                        sb.AppendLine("      ,'" + txt_item_cd + "' ");
                        sb.AppendLine("      ,'" + txt_lot_no + "' ");
                        sb.AppendLine("      , '" + (string)dgv[flow_cnt - 1].Rows[i].Cells[1].Value + "' ");
                        sb.AppendLine("      , '" + (flow_cnt).ToString() + "' "); //f_step
                        sb.AppendLine("      , '" + lbl_flow_cd[flow_cnt - 1].Text.ToString() + "' "); //flow_cd
                        sb.AppendLine("      , '" + ((string)dgv[flow_cnt - 1].Rows[i].Cells[3].Value).Replace(",", "") + "' ");
                        sb.AppendLine("      , '" + Common.p_strStaffNo + "' ");
                        sb.AppendLine("      , convert(varchar, getdate(), 120) ");
                        sb.AppendLine("      , '" + ((string)dgv[flow_cnt - 1].Rows[i].Cells[3].Value).Replace(",", "") + "' ");
                        sb.AppendLine("      , 'N' ");
                        sb.AppendLine("      ) ");
                        //input_amt += int.Parse(((string)dgv[flow_cnt - 1].Rows[i].Cells[3].Value).Replace(",", ""));
                    }

                    //string item_date = flow_date;

                    //sb.AppendLine("declare @seq int ");
                    //sb.AppendLine("select @seq =ISNULL(MAX(INPUT_CD),0)+1 from F_ITEM_INPUT ");
                    //sb.AppendLine("where INPUT_DATE = '" + flow_date + "' ");

                    //sb.AppendLine("insert into F_ITEM_INPUT(");
                    //sb.AppendLine("      INPUT_DATE ");
                    //sb.AppendLine("      ,INPUT_CD ");
                    //sb.AppendLine("      ,ITEM_CD ");
                    //sb.AppendLine("      ,LOT_NO ");
                    //sb.AppendLine("      ,INPUT_AMT ");
                    //sb.AppendLine("      ,INSTAFF ");
                    //sb.AppendLine("      ,INTIME ");
                    //sb.AppendLine(" ) values ( ");
                    //sb.AppendLine("       '" + item_date + "' ");
                    //sb.AppendLine("      ,@seq ");
                    //sb.AppendLine("      ,'" + txt_item_cd + "' ");
                    //sb.AppendLine("      ,'" + txt_lot_no + "' ");
                    //sb.AppendLine("      ,'" + input_amt + "' ");
                    //sb.AppendLine("      , '" + Common.p_strStaffNo + "' ");
                    //sb.AppendLine("      , convert(varchar, getdate(), 120) ");
                    //sb.AppendLine("      ) ");
                }
                SqlCommand sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@FLOW_DATE", flow_date);
                sCommand.Parameters.AddWithValue("@LOT_NO", txt_lot_no);
                sCommand.Parameters.AddWithValue("@ITEM_CD", txt_item_cd);

                int qResult = wAdo.SqlCommandEtc(sCommand, "insert_F_WORK_FLOW_TB");
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
        #endregion 작업공정 등록


        #region 제품출고 등록
        public int insertItemOut(
          string out_date
        , string txt_cust_cd
        , string cmb_stor
        , string self_yn
        , string vat_cd
        , conDataGridView item_out_dgv)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();
                SqlCommand sCommand = new SqlCommand(sb.ToString());

                sb = new StringBuilder();
                sb.AppendLine("declare @seq int ");
                sb.AppendLine("select @seq =ISNULL(convert(int,MAX(OUTPUT_CD)),0)+1 from F_ITEM_OUT ");
                sb.AppendLine("where OUTPUT_DATE = '" + out_date + "' ");

                sb.AppendLine("insert into F_ITEM_OUT(");
                sb.AppendLine("     OUTPUT_DATE");
                sb.AppendLine("     ,OUTPUT_CD ");
                sb.AppendLine("     ,CUST_CD ");
                sb.AppendLine("     ,STORAGE_CD ");
                sb.AppendLine("     ,COMPLETE_YN ");
                sb.AppendLine("     ,SELF_YN ");
                sb.AppendLine("     ,STAFF_CD ");
                sb.AppendLine("     ,INSTAFF ");
                sb.AppendLine("     ,INTIME ");

                sb.AppendLine(" ) values ( ");
                sb.AppendLine("      '" + out_date + "' ");
                sb.AppendLine("     ,@seq");
                sb.AppendLine("     ,'" + txt_cust_cd + "' ");
                sb.AppendLine("     ,'" + cmb_stor + "' ");
                sb.AppendLine("     ,'N' ");
                sb.AppendLine("     ,'" + self_yn + "' ");
                sb.AppendLine("     ,'" + Common.p_strStaffNo + "' ");
                sb.AppendLine("     ,'" + Common.p_strStaffNo + "' ");
                sb.AppendLine("     ,convert(varchar, getdate(), 120) ");
                sb.AppendLine(" ) ");

                if (item_out_dgv.Rows.Count > 0)
                {
                    for (int i = 0; i < item_out_dgv.Rows.Count; i++)
                    {
                        sb.AppendLine("declare @out_seq" + i + " int ");
                        sb.AppendLine("select @out_seq" + i + " =ISNULL(convert(int,MAX(SEQ)),0)+1 from F_ITEM_OUT_DETAIL ");
                        sb.AppendLine("where OUTPUT_DATE = '" + out_date + "' ");
                        sb.AppendLine("and OUTPUT_CD =  @seq ");

                        sb.AppendLine("insert into F_ITEM_OUT_DETAIL(");
                        sb.AppendLine("     OUTPUT_DATE ");
                        sb.AppendLine("     ,OUTPUT_CD ");
                        sb.AppendLine("     ,SEQ ");
                        sb.AppendLine("     ,LOT_NO ");
                        sb.AppendLine("     ,LOT_SUB ");
                        sb.AppendLine("     ,ITEM_CD ");
                        sb.AppendLine("     ,UNIT_CD ");
                        sb.AppendLine("     ,OUTPUT_AMT ");
                        sb.AppendLine("     ,PRICE ");
                        sb.AppendLine("     ,TOTAL_MONEY ");
                        sb.AppendLine("     ,INPUT_DATE ");
                        sb.AppendLine("     ,INPUT_CD ");
                        sb.AppendLine("     ,TAX_CD ");
                        sb.AppendLine("     ,CUST_CD ");
                        sb.AppendLine("     ,INSTAFF ");
                        sb.AppendLine("     ,INTIME ");
                        sb.AppendLine("  )values ( ");
                        sb.AppendLine("     '" + out_date + "' ");
                        sb.AppendLine("      ,@seq ");
                        sb.AppendLine("     ,@out_seq" + i + " ");
                        sb.AppendLine("     ,'" + item_out_dgv.Rows[i].Cells["O_LOT_NO"].Value + "' ");
                        sb.AppendLine("     ,'" + item_out_dgv.Rows[i].Cells["O_LOT_SUB"].Value + "' ");
                        sb.AppendLine("     ,'" + item_out_dgv.Rows[i].Cells["O_ITEM_CD"].Value + "' ");
                        sb.AppendLine("     ,'" + item_out_dgv.Rows[i].Cells["O_UNIT_CD"].Value + "' ");
                        sb.AppendLine("     ,'" + ((string)item_out_dgv.Rows[i].Cells["OUTPUT_AMT"].Value).Replace(",", "") + "' ");
                        sb.AppendLine("     ,'" + ((string)item_out_dgv.Rows[i].Cells["PRICE"].Value).Replace(",", "") + "' ");
                        sb.AppendLine("     ,'" + ((string)item_out_dgv.Rows[i].Cells["TOTAL_MONEY"].Value).Replace(",", "") + "' ");
                        sb.AppendLine("     ,'" + item_out_dgv.Rows[i].Cells["O_INPUT_DATE"].Value + "' ");
                        sb.AppendLine("     ,'" + item_out_dgv.Rows[i].Cells["O_INPUT_CD"].Value + "' ");
                        sb.AppendLine("     ,'" + item_out_dgv.Rows[i].Cells["O_TAX_CD"].Value + "' ");
                        sb.AppendLine("     ,'" + item_out_dgv.Rows[i].Cells["O_CUST_CD"].Value + "' ");
                        sb.AppendLine("     ,'" + Common.p_strStaffNo + "' ");
                        sb.AppendLine("     ,convert(varchar, getdate(), 120)  ");
                        sb.AppendLine("  )");

                        //sb.AppendLine(" update N_RAW_CODE set ");
                        //sb.AppendLine("     BAL_STOCK = ISNULL(BAL_STOCK,0) +" + double.Parse(((string)in_rm_dgv.Rows[i].Cells["TOTAL_AMT"].Value).Replace(",", "") + " ") );
                        //sb.AppendLine(" where RAW_MAT_CD = '" +in_rm_dgv.Rows[i].Cells["RAW_MAT_CD"].Value + "' ");
                    }
                }
                Debug.WriteLine(sb);
                sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@OUTPUT_DATE", out_date);
                sCommand.Parameters.AddWithValue("@CUST_CD", txt_cust_cd);
                sCommand.Parameters.AddWithValue("@STORAGE_CD", cmb_stor);


                    if (Common.sp_pack_gubun.ToString().Equals("1"))
                    {
                        StringBuilder sb2 = new StringBuilder();

                        string JangCd = "";
                        ArrayList JangSeq = new ArrayList();

                        sb2.AppendLine("declare @seq int ");
                        sb2.AppendLine("select @seq =ISNULL(MAX(convert(int,전표번호)),0)+1 from T_매출 ");
                        sb2.AppendLine("where 사업자번호 = '" + Common.p_saupNo + "' ");
                        sb2.AppendLine("and 매출일자 = '" + out_date + "' ");


                        sb2.AppendLine("SELECT @seq AS JANG_CD ");


                        SqlCommand sCommandTemp = new SqlCommand(sb2.ToString());
                        if (sCommand.CommandText.Equals(null))
                        {
                            wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                            return -1;
                        }
                        DataTable dtTempCd = wAdo.SqlCommandSelect_Jang(sCommandTemp);

                        if (dtTempCd != null && dtTempCd.Rows.Count > 0)
                        {
                            JangCd = dtTempCd.Rows[0]["JANG_CD"].ToString();
                        }
                        else
                        {
                            return -1;
                        }

                        sb2.AppendLine(" INSERT INTO T_매출 ( ");
                        sb2.AppendLine(" 사업자번호 ");
                        sb2.AppendLine(" ,지점코드 ");
                        sb2.AppendLine(" ,매출일자 ");
                        sb2.AppendLine(" ,전표번호 ");
                        sb2.AppendLine(" ,입력방법 ");
                        sb2.AppendLine(" ,매출시각 ");
                        sb2.AppendLine(" ,거래처코드 ");
                        sb2.AppendLine(" ,담당사원 ");
                        sb2.AppendLine(" ,창고코드 ");
                        sb2.AppendLine(" ,발행여부 ");
                        sb2.AppendLine(" ,부가세코드 ");
                        sb2.AppendLine(" ,비고 ");
                        sb2.AppendLine(" ,등록사원번호 ");
                        sb2.AppendLine(" ,등록일시 ");
                        sb2.AppendLine(" ) VALUES ( ");
                        sb2.AppendLine(" '" + Common.p_saupNo + "' ");
                        sb2.AppendLine(" ,'0' ");
                        sb2.AppendLine(" ,'" + out_date + "' ");
                        sb2.AppendLine(" ,@seq ");
                        sb2.AppendLine(" ,'C' ");
                        sb2.AppendLine(" ,'00:00:01' ");
                        sb2.AppendLine(" ,'" + txt_cust_cd + "' ");
                        sb2.AppendLine(" ,'100' ");
                        sb2.AppendLine(" ,'000' ");
                        sb2.AppendLine(" ,'N' ");
                        sb2.AppendLine(" ,'" + vat_cd + "' ");
                        sb2.AppendLine(" ,'' ");
                        sb2.AppendLine(" ,'100' ");
                        sb2.AppendLine(" ,convert(varchar, getdate(), 120)  ");
                        sb2.AppendLine(" )  ");

                        if (item_out_dgv.Rows.Count > 0)
                        {
                            for (int i = 0; i < item_out_dgv.Rows.Count; i++)
                            {
                                sb2.AppendLine("declare @out_seq" + i + " int ");
                                sb2.AppendLine("select @out_seq" + i + " =ISNULL(convert(int,MAX(항목순번)),0)+1 from T_매출항목 ");
                                sb2.AppendLine("where 사업자번호 = '" + Common.p_saupNo + "' ");
                                sb2.AppendLine("and 매출일자 = '" + out_date + "' ");
                                sb2.AppendLine("and 전표번호 =  @seq ");

                                sb2.AppendLine("INSERT INTO T_매출항목 ( ");
                                sb2.AppendLine(" 사업자번호 ");
                                sb2.AppendLine(" ,지점코드 ");
                                sb2.AppendLine(" ,매출일자 ");
                                sb2.AppendLine(" ,전표번호 ");
                                sb2.AppendLine(" ,항목순번 ");
                                sb2.AppendLine(" ,상품코드 ");
                                sb2.AppendLine(" ,박스수량 ");
                                sb2.AppendLine(" ,중간수량 ");
                                sb2.AppendLine(" ,낱개수량 ");
                                sb2.AppendLine(" ,총수량 ");
                                sb2.AppendLine(" ,박스단가 ");
                                sb2.AppendLine(" ,낱개단가 ");
                                sb2.AppendLine(" ,금액 ");
                                sb2.AppendLine(" ,서비스박스 ");
                                sb2.AppendLine(" ,서비스낱개 ");
                                sb2.AppendLine(" ,서비스총수량 ");
                                sb2.AppendLine(" ,최종매출일 ");
                                sb2.AppendLine(" ,매출구분 ");
                                sb2.AppendLine(" ,비고 ");
                                sb2.AppendLine(" ,과세구분 ");
                                sb2.AppendLine(" ,박스입고단가 ");
                                sb2.AppendLine(" ,낱개입고단가 ");
                                sb2.AppendLine(" ,매출일자와번호 ");
                                sb2.AppendLine(" ) VALUES ( ");
                                sb2.AppendLine(" '" + Common.p_saupNo + "' ");
                                sb2.AppendLine(" ,'0' ");
                                sb2.AppendLine(" ,'" + out_date + "' ");
                                sb2.AppendLine(" ,@seq ");
                                sb2.AppendLine(" ,@out_seq" + i + "  ");
                                sb2.AppendLine(" ,'" + item_out_dgv.Rows[i].Cells["O_LINK_CD"].Value.ToString() + "' ");
                                sb2.AppendLine(" ,0 ");
                                sb2.AppendLine(" ,0 ");
                                sb2.AppendLine(" ," + ((string)item_out_dgv.Rows[i].Cells["OUTPUT_AMT"].Value).Replace(",", "") + " ");
                                sb2.AppendLine(" ," + ((string)item_out_dgv.Rows[i].Cells["OUTPUT_AMT"].Value).Replace(",", "") + " ");
                                sb2.AppendLine(" ,0 ");
                                sb2.AppendLine(" ," + ((string)item_out_dgv.Rows[i].Cells["PRICE"].Value).Replace(",", "") + " ");
                                sb2.AppendLine(" ," + ((string)item_out_dgv.Rows[i].Cells["TOTAL_MONEY"].Value).Replace(",", "") + " ");
                                sb2.AppendLine(" ,0 ");
                                sb2.AppendLine(" ,0 ");
                                sb2.AppendLine(" ,0 ");
                                sb2.AppendLine(" ,'' ");
                                sb2.AppendLine(" ,'1' ");
                                sb2.AppendLine(" ,'' ");
                                sb2.AppendLine(" ,'" + ((String)item_out_dgv.Rows[i].Cells["O_TAX_CD"].Value??"") +"'");
                                sb2.AppendLine(" ,0 ");
                                sb2.AppendLine(" ,0 ");
                                sb2.AppendLine(" ,'" + out_date + "'+'_'+CONVERT(nvarchar,@seq) ");
                                sb2.AppendLine(" ) ");
                            }
                        }

                        Debug.WriteLine(sb2);
                        SqlCommand sCommand2 = new SqlCommand(sb2.ToString());

                        int qResult = wAdo.SqlCommandEtc_Jang(sCommand2, "insert_SALES_JANG");
                        if (qResult > 0)
                        {
                            sb2.Clear();
                            for (int i = 0; i < item_out_dgv.Rows.Count; i++)
                            {
                                sb2.AppendLine("SELECT 항목순번 FROM T_매출항목 WHERE 사업자번호 = '" + Common.p_saupNo + "' and 지점코드 = '0' and 매출일자 ='" + out_date + "' and 전표번호 = '" + JangCd + "' ");
                            }
                            Debug.WriteLine("장터지기 매출 있는지보자");
                            Debug.WriteLine(sb2);
                            SqlCommand sCommandTemp2 = new SqlCommand(sb2.ToString());
                            if (sCommand.CommandText.Equals(null))
                            {
                                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                                return -1;
                            }
                            DataTable dtTempSeq = wAdo.SqlCommandSelect_Jang(sCommandTemp2);

                            if (dtTempSeq != null && dtTempSeq.Rows.Count > 0)
                            {
                                sb.AppendLine(" UPDATE F_ITEM_OUT SET J_INPUT_DATE = '" + out_date + "' , J_INPUT_CD = '" + JangCd + "' WHERE OUTPUT_DATE = '" + out_date + "' and  OUTPUT_CD = @seq  ");

                                for (int i = 0; i < dtTempSeq.Rows.Count; i++)
                                {
                                    sb.AppendLine(" UPDATE F_ITEM_OUT_DETAIL SET J_INPUT_DATE = '" + out_date + "' , J_INPUT_CD = '" + JangCd + "' , J_INPUT_SEQ = '" + dtTempSeq.Rows[i]["항목순번"].ToString() + "' ");
                                    sb.AppendLine(" WHERE OUTPUT_DATE = '" + out_date + "' and  OUTPUT_CD = @seq and SEQ = @out_seq" + i + " ");
                                }

                                sCommand = new SqlCommand(sb.ToString());
                            }
                            else
                            {
                                return -1;
                            }

                            int qResult2 = wAdo.SqlCommandEtc(sCommand, "insert_SALES_MES");
                            if (qResult2 > 0)
                            {
                                return 0;  // 0 true, 1 false
                            }
                            else return 5;
                        }
                        else
                        {
                            return 1;
                        }
                    }
                    else
                    {
                        int qResult2 = wAdo.SqlCommandEtc(sCommand, "insert_SALES_MES");
                        if (qResult2 > 0)
                        {
                            return 0;  // 0 true, 1 false
                        }
                        else
                        {
                            return 1;
                        }
                    }
            }
            catch (Exception e)
            {
                wnLog.writeLog(wnLog.LOG_ERROR, e.Message + " - " + e.ToString());
                Popup.pop오류리포트 msg = new pop오류리포트(e.Message + " - " + e.ToString());
                msg.ShowDialog();
                return 9;
            }
        }
        //제품 출하 지시 

        public int insertItemOutInst(
          string out_date
        , string out_cd
        , string out_seq)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();
                SqlCommand sCommand = new SqlCommand(sb.ToString());

                sb = new StringBuilder();

                sb.AppendLine("insert into F_ITEM_OUT_INST(");
                sb.AppendLine("     OUTPUT_DATE");
                sb.AppendLine("     ,OUTPUT_CD ");
                sb.AppendLine("     ,SEQ ");
                sb.AppendLine("     ,OUT_INST_YN ");
                sb.AppendLine("     ,INSTAFF ");
                sb.AppendLine("     ,INTIME ");
                sb.AppendLine(" ) values ( ");
                sb.AppendLine("      '" + out_date + "' ");
                sb.AppendLine("     ,'" + out_cd + "'");
                sb.AppendLine("     ,'" + out_seq + "'");
                sb.AppendLine("     ,'Y' ");
                sb.AppendLine("     ,'" + Common.p_strStaffNo + "' ");
                sb.AppendLine("     ,convert(varchar, getdate(), 120) ");
                sb.AppendLine(" ) ");


                sCommand = new SqlCommand(sb.ToString());

                int qResult = wAdo.SqlCommandEtc(sCommand, "insert_ITEM_OUT_INST_TB");
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

        public int insertHalfOut(
          string out_date
        , string txt_cust_cd
        , string cmb_stor
        , string self_yn
        , conDataGridView item_out_dgv)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();
                SqlCommand sCommand = new SqlCommand(sb.ToString());

                sb = new StringBuilder();
                sb.AppendLine("declare @seq int ");
                sb.AppendLine("select @seq =ISNULL(MAX(OUTPUT_CD),0)+1 from F_ITEM_OUT ");
                sb.AppendLine("where OUTPUT_DATE = '" + out_date + "' ");

                sb.AppendLine("insert into F_ITEM_OUT(");
                sb.AppendLine("     OUTPUT_DATE");
                sb.AppendLine("     ,OUTPUT_CD ");
                sb.AppendLine("     ,CUST_CD ");
                sb.AppendLine("     ,STORAGE_CD ");
                sb.AppendLine("     ,COMPLETE_YN ");
                sb.AppendLine("     ,SELF_YN ");
                sb.AppendLine("     ,STAFF_CD ");
                sb.AppendLine("     ,INSTAFF ");
                sb.AppendLine("     ,INTIME ");

                sb.AppendLine(" ) values ( ");
                sb.AppendLine("      @OUTPUT_DATE ");
                sb.AppendLine("     ,@seq");
                sb.AppendLine("     ,@CUST_CD ");
                sb.AppendLine("     ,@STORAGE_CD ");
                sb.AppendLine("     ,'N' ");
                sb.AppendLine("     ,'" + self_yn + "' ");
                sb.AppendLine("     ,'" + Common.p_strStaffNo + "' ");
                sb.AppendLine("     ,'" + Common.p_strStaffNo + "' ");
                sb.AppendLine("     ,convert(varchar, getdate(), 120) ");
                sb.AppendLine(" ) ");

                sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@OUTPUT_DATE", out_date);
                sCommand.Parameters.AddWithValue("@CUST_CD", txt_cust_cd);
                sCommand.Parameters.AddWithValue("@STORAGE_CD", cmb_stor);

                int qResult = wAdo.SqlCommandEtc(sCommand, "insert_ITEM_HALF_OUT_TB");
                if (qResult > 0)
                {
                    sb = new StringBuilder();
                    sb.AppendLine("declare @OUT_CD int ");
                    sb.AppendLine("select @OUT_CD =ISNULL(MAX(OUTPUT_CD),0) from F_ITEM_OUT ");
                    sb.AppendLine("where OUTPUT_DATE = '" + out_date + "' ");

                    for (int i = 0; i < item_out_dgv.Rows.Count; i++)
                    {
                        sb.AppendLine("DECLARE	@return_value" + i + " int ");
                        sb.AppendLine("EXEC	@return_value" + i + " = [dbo].[SP_HALF_OUT] ");
                        sb.AppendLine("@OUTPUT_DATE = '" + out_date + "',");
                        sb.AppendLine("@OUTPUT_CD = @OUT_CD, ");
                        sb.AppendLine("@LOT_NO = '" + item_out_dgv.Rows[i].Cells["O_LOT_NO"].Value + "' , ");
                        sb.AppendLine("@LOT_SUB = '" + item_out_dgv.Rows[i].Cells["O_LOT_SUB"].Value + "' , ");
                        sb.AppendLine("@ITEM_CD = '" + item_out_dgv.Rows[i].Cells["O_ITEM_CD"].Value + "' , ");
                        sb.AppendLine("@OUT_AMT = '" + ((string)item_out_dgv.Rows[i].Cells["OUTPUT_AMT"].Value).Replace(",", "") + "' , ");
                        sb.AppendLine("@STAFF_CD = '" + Common.p_strStaffNo + "'  ");
                        sb.AppendLine("SELECT	'RV' = @return_value" + i + " ");
                    }

                    sCommand = new SqlCommand(sb.ToString());

                    DataTable dt = wAdo.SqlCommandSelect(sCommand);
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["RV"].ToString().Equals("0"))
                        {
                            return 0;
                        }
                        else return 1;
                    }
                    else return 1;
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
        #endregion 제품출고 등록


        #region 공정이동표 자동 설정
        public int insert_Work_Flow_Move(
              string txt_lot_no
            , string txt_lot_sub
            , int f_step
            , int f_sub_amt)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();
                string f_sub_date = DateTime.Today.ToString("yyyy-MM-dd");
                sb = new StringBuilder();
                sb.AppendLine("declare @item_cd nvarchar(20), @flow_cd nvarchar(20) ,@n_step int, @f_sub_amt numeric(18,0)");
                sb.AppendLine("select @item_cd = ITEM_CD ");
                sb.AppendLine("from F_WORK_FLOW ");
                sb.AppendLine("where LOT_NO = '" + txt_lot_no + "' ");

                int n_step = f_step + 1;
                sb.AppendLine("select @flow_cd =  FLOW_CD, @n_step = SEQ ");
                sb.AppendLine(" from N_ITEM_FLOW ");
                sb.AppendLine("where ITEM_CD =@item_cd  ");
                sb.AppendLine("and SEQ = " + n_step + " "); //다음단계의 공정

                if (f_step > 0)
                {
                    sb.AppendLine("select @f_sub_amt = ISNULL(f_sub_amt,0)  ");
                    sb.AppendLine("from F_WORK_FLOW_DETAIL ");
                    sb.AppendLine("where LOT_NO = '" + txt_lot_no + "' and LOT_SUB = '" + txt_lot_sub + "' and F_STEP = " + f_step + "  "); //공정 이동 전 마지막 단계의 수량 가져오기 
                }
                else
                {
                    sb.AppendLine("select @f_sub_amt = " + f_sub_amt + "  ");
                }

                sb.AppendLine("insert into F_WORK_FLOW_DETAIL(");
                sb.AppendLine("      LOT_NO ");
                sb.AppendLine("      ,LOT_SUB ");
                sb.AppendLine("      ,F_STEP ");
                sb.AppendLine("      ,FLOW_CD ");
                sb.AppendLine("      ,SEQ ");
                sb.AppendLine("      ,F_SUB_DATE ");
                sb.AppendLine("      ,F_SUB_AMT ");
                sb.AppendLine("      ,LOSS ");
                sb.AppendLine("      ,POOR_CD ");
                sb.AppendLine("      ,POOR_AMT ");
                sb.AppendLine("      ,COMPLETE_YN ");
                sb.AppendLine("      ,CHECK_YN ");
                sb.AppendLine("      ,ITEM_CHECK_YN ");
                sb.AppendLine("      ,INSTAFF ");
                sb.AppendLine("      ,INTIME ");
                sb.AppendLine("      ,COMMENT ");
                sb.AppendLine(" ) values ( ");
                sb.AppendLine("      '" + txt_lot_no + "' ");
                sb.AppendLine("      , '" + txt_lot_sub + "' ");
                sb.AppendLine("      , '" + n_step + "' ");
                sb.AppendLine("      , @flow_cd ");
                sb.AppendLine("      , @n_step ");
                sb.AppendLine("      , '" + f_sub_date + "' ");
                sb.AppendLine("      , @f_sub_amt");
                sb.AppendLine("      , '0' ");
                sb.AppendLine("      , '' ");
                sb.AppendLine("      , '0' ");
                sb.AppendLine("      , 'N' ");
                sb.AppendLine("      , 'S' "); //S -> 대기 
                sb.AppendLine("      , 'S' "); //S -> 대기 
                sb.AppendLine("      , '" + Common.p_strStaffNo + "' ");
                sb.AppendLine("      , convert(varchar, getdate(), 120) ");
                sb.AppendLine("      ,'' ");
                sb.AppendLine("      ) ");
                SqlCommand sCommand = new SqlCommand(sb.ToString());

                int qResult = wAdo.SqlCommandEtc(sCommand, "insert_F_WORK_FLOW_MOVE_TB");
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


        public int insert_Work_Flow_Move_First(
              string txt_lot_no
            , string txt_lot_sub
            , string txt_item_cd
            , int txt_f_sub_amt
            , int f_step)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();
                string f_date = DateTime.Today.ToString("yyyy-MM-dd");
                string f_sub_date = f_date;

                sb.AppendLine("insert into F_WORK_FLOW(");
                sb.AppendLine("      LOT_NO ");
                sb.AppendLine("      ,FLOW_DATE ");
                sb.AppendLine("      ,ITEM_CD ");
                sb.AppendLine("      ,COMPLETE_YN ");
                sb.AppendLine("      ,INSTAFF ");
                sb.AppendLine("      ,INTIME ");
                sb.AppendLine(" ) values ( ");
                sb.AppendLine("      '" + txt_lot_no + "' ");
                sb.AppendLine("      , '" + f_date + "' ");
                sb.AppendLine("      , '" + txt_item_cd + "' ");
                sb.AppendLine("      , 'N' ");
                sb.AppendLine("      , '" + Common.p_strStaffNo + "' ");
                sb.AppendLine("      , convert(varchar, getdate(), 120) ");
                sb.AppendLine(" ) ");

                int n_step = f_step + 1;
                sb.AppendLine("declare @flow_cd nvarchar(20) ,@n_step int");
                sb.AppendLine("select @flow_cd =  FLOW_CD, @n_step = SEQ ");
                sb.AppendLine(" from N_ITEM_FLOW ");
                sb.AppendLine("where ITEM_CD ='" + txt_item_cd + "'  ");
                sb.AppendLine("and SEQ = " + n_step + " "); //다음단계의 공정

                sb.AppendLine("insert into F_WORK_FLOW_DETAIL(");
                sb.AppendLine("      LOT_NO ");
                sb.AppendLine("      ,LOT_SUB ");
                sb.AppendLine("      ,F_STEP ");
                sb.AppendLine("      ,FLOW_CD ");
                sb.AppendLine("      ,SEQ ");
                sb.AppendLine("      ,F_SUB_DATE ");
                sb.AppendLine("      ,F_SUB_AMT ");
                sb.AppendLine("      ,LOSS ");
                sb.AppendLine("      ,POOR_CD ");
                sb.AppendLine("      ,POOR_AMT ");
                sb.AppendLine("      ,COMPLETE_YN ");
                sb.AppendLine("      ,CHECK_YN ");
                sb.AppendLine("      ,ITEM_CHECK_YN ");
                sb.AppendLine("      ,INSTAFF ");
                sb.AppendLine("      ,INTIME ");
                sb.AppendLine("      ,COMMENT ");
                sb.AppendLine(" ) values ( ");
                sb.AppendLine("      '" + txt_lot_no + "' ");
                sb.AppendLine("      , '" + txt_lot_sub + "' ");
                sb.AppendLine("      , '" + n_step + "' ");
                sb.AppendLine("      , @flow_cd ");
                sb.AppendLine("      , @n_step ");
                sb.AppendLine("      , '" + f_sub_date + "' ");
                sb.AppendLine("      , " + txt_f_sub_amt + " ");
                sb.AppendLine("      , '0' ");
                sb.AppendLine("      , '' ");
                sb.AppendLine("      , '0' ");
                sb.AppendLine("      , 'N' ");
                sb.AppendLine("      , 'S' "); //S -> 대기 
                sb.AppendLine("      , 'S' "); //S -> 대기 
                sb.AppendLine("      , '" + Common.p_strStaffNo + "' ");
                sb.AppendLine("      , convert(varchar, getdate(), 120) ");
                sb.AppendLine("      ,'' ");
                sb.AppendLine("      ) ");
                SqlCommand sCommand = new SqlCommand(sb.ToString());

                int qResult = wAdo.SqlCommandEtc(sCommand, "insert_F_WORK_FLOW_MOVE_TB");
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
        #endregion 공정이동표 자동 설정
        #endregion insert

        #region update

        public int updateStaff(
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

                sb = new StringBuilder();
                sb.AppendLine("update N_STAFF_CODE set");
                sb.AppendLine("     STAFF_CD = @STAFF_CD ");
                sb.AppendLine("     ,STAFF_NM = @STAFF_NM ");
                sb.AppendLine("     ,JOIN_DATE  =@JOIN_DATE");
                sb.AppendLine("     ,PHONE_NUM = @PHONE_NUM ");
                sb.AppendLine("     ,DEPT_CD = @DEPT_CD ");
                sb.AppendLine("     ,POS_CD = @POS_CD");
                sb.AppendLine("     ,STORAGE_CD = @STORAGE_CD ");
                sb.AppendLine("     ,LOGIN_ID = @LOGIN_ID ");
                sb.AppendLine("     ,PW = @PW");
                sb.AppendLine("     ,AUTH_SET = @AUTH_SET ");
                sb.AppendLine("     ,COMMENT = @COMMENT ");
                sb.AppendLine(" where STAFF_CD = @STAFF_CD");

                SqlCommand sCommand = new SqlCommand(sb.ToString());

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
                int qResult = wAdo.SqlCommandEtc(sCommand, "update_USER_TB");
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

        public int updateDept(string txtDeptCd, string txtDeptNm, string comment)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb = new StringBuilder();
                sb.AppendLine("update N_DEPT_CODE set");
                sb.AppendLine("    DEPT_CD  = @DEPT_CD  ");
                sb.AppendLine("    ,DEPT_NM  = @DEPT_NM  ");
                sb.AppendLine("    ,COMMENT  = @COMMENT  ");
                sb.AppendLine("    where DEPT_CD =@DEPT_CD  ");


                SqlCommand sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@DEPT_CD", txtDeptCd);
                sCommand.Parameters.AddWithValue("@DEPT_NM", txtDeptNm);
                sCommand.Parameters.AddWithValue("@COMMENT", comment);

                int qResult = wAdo.SqlCommandEtc(sCommand, "update_DEPT_TB");
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

        public int updatePos(string txt_pos_cd, string txt_pos_nm, string comment)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb = new StringBuilder();
                sb.AppendLine("update N_POS_CODE set");
                sb.AppendLine("    POS_CD  = @POS_CD  ");
                sb.AppendLine("    ,POS_NM  = @POS_NM  ");
                sb.AppendLine("    ,COMMENT  = @COMMENT  ");
                sb.AppendLine("    where POS_CD =@POS_CD  ");


                SqlCommand sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@POS_CD", txt_pos_cd);
                sCommand.Parameters.AddWithValue("@POS_NM", txt_pos_nm);
                sCommand.Parameters.AddWithValue("@COMMENT", comment);

                int qResult = wAdo.SqlCommandEtc(sCommand, "update_POS_TB");
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

        public int updateStor(string txt_stor_cd, string txt_stor_nm, string comment)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb = new StringBuilder();
                sb.AppendLine("update N_STORAGE_CODE set");
                sb.AppendLine("    STORAGE_CD  = @STORAGE_CD  ");
                sb.AppendLine("    ,STORAGE_NM  = @STORAGE_NM  ");
                sb.AppendLine("    ,COMMENT  = @COMMENT  ");
                sb.AppendLine("    where STORAGE_CD =@STORAGE_CD  ");


                SqlCommand sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@STORAGE_CD", txt_stor_cd);
                sCommand.Parameters.AddWithValue("@STORAGE_NM", txt_stor_nm);
                sCommand.Parameters.AddWithValue("@COMMENT", comment);

                int qResult = wAdo.SqlCommandEtc(sCommand, "update_STOR_TB");
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

        public int updateType(string txt_type_cd, string txt_type_nm, string chk_poor_yn, string comment)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb = new StringBuilder();
                sb.AppendLine("update N_TYPE_CODE set");
                sb.AppendLine("    TYPE_CD  = @TYPE_CD  ");
                sb.AppendLine("    ,TYPE_NM  = @TYPE_NM  ");
                sb.AppendLine("    ,POOR_TYPE_YN  = @POOR_TYPE_YN  ");
                sb.AppendLine("    ,COMMENT  = @COMMENT  ");
                sb.AppendLine("    where TYPE_CD = @TYPE_CD  ");


                SqlCommand sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@TYPE_CD", txt_type_cd);
                sCommand.Parameters.AddWithValue("@TYPE_NM", txt_type_nm);
                sCommand.Parameters.AddWithValue("@POOR_TYPE_YN", chk_poor_yn);
                sCommand.Parameters.AddWithValue("@COMMENT", comment);

                int qResult = wAdo.SqlCommandEtc(sCommand, "update_TYPE_TB");
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

        public int updateUnit(string txt_unit_cd, string txt_unit_nm, string comment)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb = new StringBuilder();
                sb.AppendLine("update N_UNIT_CODE set");
                sb.AppendLine("    UNIT_CD  = @UNIT_CD  ");
                sb.AppendLine("    ,UNIT_NM  = @UNIT_NM  ");
                sb.AppendLine("    ,COMMENT  = @COMMENT  ");
                sb.AppendLine("    where UNIT_CD =@UNIT_CD  ");


                SqlCommand sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@UNIT_CD", txt_unit_cd);
                sCommand.Parameters.AddWithValue("@UNIT_NM", txt_unit_nm);
                sCommand.Parameters.AddWithValue("@COMMENT", comment);

                int qResult = wAdo.SqlCommandEtc(sCommand, "update_UNIT_TB");
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

        public int updateLine(string txt_line_cd, string txt_line_nm, string comment)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb = new StringBuilder();
                sb.AppendLine("update N_LINE_CODE set");
                sb.AppendLine("    LINE_CD  = @LINE_CD  ");
                sb.AppendLine("    ,LINE_NM  = @LINE_NM  ");
                sb.AppendLine("    ,COMMENT  = @COMMENT  ");
                sb.AppendLine("    where LINE_CD =@LINE_CD  ");


                SqlCommand sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@LINE_CD", txt_line_cd);
                sCommand.Parameters.AddWithValue("@LINE_NM", txt_line_nm);
                sCommand.Parameters.AddWithValue("@COMMENT", comment);

                int qResult = wAdo.SqlCommandEtc(sCommand, "update_LINE_TB");
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

        public int updatePoor(string txt_poor_cd, string txt_poor_nm, string chk_poor_cd, string comment)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb = new StringBuilder();
                sb.AppendLine("update N_POOR_CODE set");
                sb.AppendLine("    POOR_CD  = @POOR_CD  ");
                sb.AppendLine("    ,POOR_NM  = @POOR_NM  ");
                sb.AppendLine("    ,TYPE_CD  = @TYPE_CD  ");
                sb.AppendLine("    ,COMMENT  = @COMMENT  ");
                sb.AppendLine("    where POOR_CD =@POOR_CD  ");

                SqlCommand sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@POOR_CD", txt_poor_cd);
                sCommand.Parameters.AddWithValue("@POOR_NM", txt_poor_nm);
                sCommand.Parameters.AddWithValue("@TYPE_CD", chk_poor_cd);
                sCommand.Parameters.AddWithValue("@COMMENT", comment);

                int qResult = wAdo.SqlCommandEtc(sCommand, "update_POOR_TB");
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

        public int updateFlow(string txt_flow_cd
            , string txt_flow_nm
            , string cmb_stor
            , string chk_flow_yn
            , string chk_item_gbn
            , string chk_flow_chk_yn
            , string chk_temp_yn
            , string chk_mold_yn
            , string cmb_poor
            , string chk_manager_yn
            , string manager_cd
            , string comment)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb = new StringBuilder();
                sb.AppendLine(" update N_FLOW_CODE set");
                sb.AppendLine("     FLOW_CD = @FLOW_CD ");
                sb.AppendLine("     ,FLOW_NM = @FLOW_NM ");
                sb.AppendLine("     ,STORAGE_CD = @STORAGE_CD ");
                sb.AppendLine("     ,FLOW_INSERT_YN = @FLOW_INSERT_YN");
                sb.AppendLine("     ,ITEM_IDEN_YN = @ITEM_IDEN_YN ");
                sb.AppendLine("     ,FLOW_CHK_YN = @FLOW_CHK_YN ");
                sb.AppendLine("     ,TEMP_TIME_YN  = @TEMP_TIME_YN");
                sb.AppendLine("     ,MOLD_YN = @MOLD_YN");
                sb.AppendLine("     ,POOR_TYPE_CD = @POOR_TYPE_CD");
                sb.AppendLine("     ,STAFF_YN = @STAFF_YN ");
                sb.AppendLine("     ,STAFF_CD = @STAFF_CD ");
                sb.AppendLine("     ,COMMENT = @COMMENT");
                sb.AppendLine(" where FLOW_CD = @FLOW_CD ");

                SqlCommand sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@FLOW_CD", txt_flow_cd);
                sCommand.Parameters.AddWithValue("@FLOW_NM", txt_flow_nm);
                sCommand.Parameters.AddWithValue("@STORAGE_CD", cmb_stor);
                sCommand.Parameters.AddWithValue("@FLOW_INSERT_YN", chk_flow_yn);
                sCommand.Parameters.AddWithValue("@ITEM_IDEN_YN", chk_item_gbn);
                sCommand.Parameters.AddWithValue("@FLOW_CHK_YN", chk_flow_chk_yn);
                sCommand.Parameters.AddWithValue("@TEMP_TIME_YN", chk_temp_yn);
                sCommand.Parameters.AddWithValue("@MOLD_YN", chk_mold_yn);
                sCommand.Parameters.AddWithValue("@POOR_TYPE_CD", cmb_poor);
                sCommand.Parameters.AddWithValue("@STAFF_YN", chk_manager_yn);
                sCommand.Parameters.AddWithValue("@STAFF_CD", manager_cd);

                sCommand.Parameters.AddWithValue("@COMMENT", comment);

                int qResult = wAdo.SqlCommandEtc(sCommand, "update_FLOW_TB");
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

        public int updateRawMat(
              string txt_raw_mat_cd
            , string txt_raw_mat_nm
            , string txt_spec
            , string txt_quality
            , string cmb_rat_mat_gbn
            , string cmb_type
            , string cmb_input_unit
            , string cmb_output_unit
            , double txt_conver_ratio
            , double txt_input_price
            , double txt_output_price
            , string cmb_line
            , string st_status_yn
            , string cmb_raw_stor
            , string cmb_used
            , string cmb_cust
            , string cmb_raw_chk
            , string part_no
            , string comment)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb.AppendLine(" update N_RAW_CODE set");
                sb.AppendLine("     RAW_MAT_CD = @RAW_MAT_CD");
                sb.AppendLine("     ,RAW_MAT_NM = @RAW_MAT_NM ");
                sb.AppendLine("     ,SPEC = @SPEC ");
                sb.AppendLine("     ,RAW_MAT_GUBUN = @RAW_MAT_GUBUN ");
                sb.AppendLine("     ,TYPE_CD = @TYPE_CD ");
                sb.AppendLine("     ,INPUT_UNIT = @INPUT_UNIT ");
                sb.AppendLine("     ,OUTPUT_UNIT = @OUTPUT_UNIT ");
                sb.AppendLine("     ,LINE_CD = @LINE_CD ");
                sb.AppendLine("     ,CVR_RATIO = @CVR_RATIO ");
                sb.AppendLine("     ,INPUT_PRICE = @INPUT_PRICE ");
                sb.AppendLine("     ,OUTPUT_PRICE = @OUTPUT_PRICE ");
                sb.AppendLine("     ,ST_STATUS_YN = @ST_STATUS_YN ");
                sb.AppendLine("     ,RAW_STORAGE = @RAW_STORAGE ");
                sb.AppendLine("     ,EX_STAN_QUALITY = @EX_STAN_QUALITY ");
                sb.AppendLine("     ,USED_CD = @USED_CD ");
                sb.AppendLine("     ,CUST_CD = @CUST_CD ");
                sb.AppendLine("     ,CHECK_GUBUN = @CHECK_GUBUN ");
                sb.AppendLine("     ,PART_NO = @PART_NO ");
                sb.AppendLine("     ,COMMENT = @COMMENT ");

                sb.AppendLine(" where RAW_MAT_CD = @RAW_MAT_CD ");

                SqlCommand sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@RAW_MAT_CD", txt_raw_mat_cd);
                sCommand.Parameters.AddWithValue("@RAW_MAT_NM", txt_raw_mat_nm);
                sCommand.Parameters.AddWithValue("@SPEC", txt_spec);
                sCommand.Parameters.AddWithValue("@RAW_MAT_GUBUN", cmb_rat_mat_gbn);
                sCommand.Parameters.AddWithValue("@TYPE_CD", cmb_type);
                sCommand.Parameters.AddWithValue("@INPUT_UNIT", cmb_input_unit);
                sCommand.Parameters.AddWithValue("@OUTPUT_UNIT", cmb_output_unit);
                sCommand.Parameters.AddWithValue("@LINE_CD", cmb_line);
                sCommand.Parameters.AddWithValue("@CVR_RATIO", txt_conver_ratio);
                sCommand.Parameters.AddWithValue("@INPUT_PRICE", txt_input_price);
                sCommand.Parameters.AddWithValue("@OUTPUT_PRICE", txt_output_price);
                sCommand.Parameters.AddWithValue("@ST_STATUS_YN", st_status_yn);
                sCommand.Parameters.AddWithValue("@RAW_STORAGE", "");
                sCommand.Parameters.AddWithValue("@EX_STAN_QUALITY", txt_quality);
                sCommand.Parameters.AddWithValue("@USED_CD", cmb_used);
                sCommand.Parameters.AddWithValue("@CUST_CD", cmb_cust);
                sCommand.Parameters.AddWithValue("@CHECK_GUBUN", cmb_raw_chk);
                sCommand.Parameters.AddWithValue("@PART_NO", part_no);

                sCommand.Parameters.AddWithValue("@COMMENT", comment);

                int qResult = wAdo.SqlCommandEtc(sCommand, "update_RAW_MAT_TB");
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

        public int updateCust(
              string txt_cust_cd
            , string cust_gbn
            , string txt_cust_nm
            , string txt_owner
            , string txt_saup_no
            , string txt_uptae
            , string txt_jong
            , string txt_deal_type
            , string txt_post_no
            , string txt_addr
            , string txt_cust_manager
            , string txt_email
            , string txt_comp_phone
            , string txt_phone
            , string txt_fax
            , string txt_start_date
            , string cmb_manager
            , string cmb_used
            , string comment
            , string tax_cd
            )
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb = new StringBuilder();
                sb.AppendLine("update N_CUST_CODE set");
                sb.AppendLine("      CUST_GUBUN = @CUST_GUBUN ");
                sb.AppendLine("     ,CUST_NM = @CUST_NM");
                sb.AppendLine("     ,OWNER = @OWNER ");
                sb.AppendLine("     ,SAUP_NO = @SAUP_NO ");
                sb.AppendLine("     ,UPTAE = @UPTAE ");
                sb.AppendLine("     ,JONGMOK = @JONGMOK ");
                sb.AppendLine("     ,DEAL_TYPE  = @DEAL_TYPE");
                sb.AppendLine("     ,POST_NO = @POST_NO ");
                sb.AppendLine("     ,ADDR = @ADDR");
                sb.AppendLine("     ,CUST_MANAGER = @CUST_MANAGER ");
                sb.AppendLine("     ,CUST_EMAIL = @CUST_EMAIL ");
                sb.AppendLine("     ,CUST_COMP_PHONE = @CUST_COMP_PHONE");
                sb.AppendLine("     ,CUST_PHONE = @CUST_PHONE");
                sb.AppendLine("     ,CUST_FAX = @CUST_FAX ");
                sb.AppendLine("     ,CUST_OPEN = @CUST_OPEN ");
                sb.AppendLine("     ,STAFF_CD  = @STAFF_CD");
                sb.AppendLine("     ,USED_CD = @USED_CD ");
                sb.AppendLine("     ,COMMENT = @COMMENT ");
                sb.AppendLine("     ,TAX_CD = @TAX_CD ");

                sb.AppendLine(" where CUST_CD = @CUST_CD ");

                SqlCommand sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@CUST_GUBUN", cust_gbn);
                sCommand.Parameters.AddWithValue("@CUST_NM", txt_cust_nm);
                sCommand.Parameters.AddWithValue("@OWNER", txt_owner);
                sCommand.Parameters.AddWithValue("@SAUP_NO", txt_saup_no);
                sCommand.Parameters.AddWithValue("@UPTAE", txt_uptae);
                sCommand.Parameters.AddWithValue("@JONGMOK", txt_jong);
                sCommand.Parameters.AddWithValue("@DEAL_TYPE", txt_deal_type);
                sCommand.Parameters.AddWithValue("@POST_NO", txt_post_no);
                sCommand.Parameters.AddWithValue("@ADDR", txt_addr);
                sCommand.Parameters.AddWithValue("@CUST_MANAGER", txt_cust_manager);
                sCommand.Parameters.AddWithValue("@CUST_EMAIL", txt_email);
                sCommand.Parameters.AddWithValue("@CUST_COMP_PHONE", txt_comp_phone);
                sCommand.Parameters.AddWithValue("@CUST_PHONE", txt_phone);
                sCommand.Parameters.AddWithValue("@CUST_FAX", txt_fax);
                sCommand.Parameters.AddWithValue("@CUST_OPEN", txt_start_date);
                sCommand.Parameters.AddWithValue("@STAFF_CD", cmb_manager);
                sCommand.Parameters.AddWithValue("@USED_CD", cmb_used);
                sCommand.Parameters.AddWithValue("@TAX_CD", tax_cd);

                sCommand.Parameters.AddWithValue("@COMMENT", comment);

                sCommand.Parameters.AddWithValue("@CUST_CD", txt_cust_cd);

                if (Common.sp_pack_gubun.ToString().Equals("1"))
                {
                    DataTable dtTemp = fn_Cust_List_Jang(" and 거래처코드 = '" + txt_cust_cd + "'  "); //장터지기에 거래처 등록 되어 있는지 찾고 있으면 업데이트 없으면 인설트 
                   // DataTable dtTemp = new DataTable();

                    sep sp = new sep();



                    StringBuilder sb2 = new StringBuilder();
                    if (dtTemp != null && dtTemp.Rows.Count > 0)
                    {                                             
                        sb2.AppendLine("  UPDATE T_거래처정보 SET ");
                        sb2.AppendLine("       중상여부       =  '0'  ");
                        sb2.AppendLine("       ,거래처구분          =  '" + cust_gbn + "'  ");
                        sb2.AppendLine("       ,거래처명            =  '" + txt_cust_nm + "'  ");
                        sb2.AppendLine("       ,정식명칭            =  '" + txt_cust_nm + "'  ");
                        sb2.AppendLine("       ,거래처담당자        =  '" + txt_cust_manager + "'  ");
                        sb2.AppendLine("       ,대표자명            =  '" + txt_owner + "'  ");
                        sb2.AppendLine("       ,거래처사업자번호    =  '" + txt_saup_no + "'  ");
                        sb2.AppendLine("       ,업태                =  '" + txt_uptae + "'  ");
                        sb2.AppendLine("       ,종목                =  '" + txt_jong + "'  ");
                        sb2.AppendLine("       ,사원번호            =  '100'  ");
                        sb2.AppendLine("       ,배송사원            =  ''  ");
                        sb2.AppendLine("       ,거래개시일          =  '" + txt_start_date + "'  ");
                        sb2.AppendLine("       ,유형코드            =  ''  ");
                        sb2.AppendLine("       ,지역코드            =  ''  ");
                        sb2.AppendLine("       ,우편번호            =  '" + txt_post_no + "'  ");
                        sb2.AppendLine("       ,주소                =  '" + txt_addr + "'  ");
                        sb2.AppendLine("       ,상세주소            =  '" + txt_addr + "'  ");
                        sb2.AppendLine("       ,이메일              =  '" + txt_email + "'  ");
                        sb2.AppendLine("       ,폰번호              =  '" + txt_phone + "'  ");
                        sb2.AppendLine("       ,전화번호            =  '" + txt_comp_phone + "'  ");
                        sb2.AppendLine("       ,팩스번호            =  '" + txt_fax + "'  ");
                        sb2.AppendLine("       ,비고1               =  '" + comment + "'  ");
                        sb2.AppendLine("       ,비고2               =  ''  ");
                        sb2.AppendLine("       ,비고3               =  ''  ");
                        sb2.AppendLine("       ,단가구분            =  ''  ");
                        sb2.AppendLine("       ,부가세코드          =  '" + tax_cd + "'  ");
                        sb2.AppendLine("       ,계산서여부          =  'Y'  ");
                        sb2.AppendLine("       ,발행율              =  '100'  ");
                        sb2.AppendLine("       ,계좌순번            =  '1'  ");
                        sb2.AppendLine("       ,월                  =  'N'  ");
                        sb2.AppendLine("       ,화                  =  'N'  ");
                        sb2.AppendLine("       ,수                  =  'N'  ");
                        sb2.AppendLine("       ,목                  =  'N'  ");
                        sb2.AppendLine("       ,금                  =  'N'  ");
                        sb2.AppendLine("       ,토                  =  'N'  ");
                        sb2.AppendLine("       ,일                  =  'N'  ");
                        sb2.AppendLine("       ,여신                =  0  ");
                        sb2.AppendLine("       ,현재잔고            =  0  ");
                        sb2.AppendLine("       ,잔고수정여부        =  0  ");
                        sb2.AppendLine("       ,초기잔고            =  0  ");
                        sb2.AppendLine("       ,잔고수정일자        =  ''  ");
                        sb2.AppendLine("       ,수정당일잔고        =  0  ");
                        sb2.AppendLine("       ,수정잔고            =  0  ");
                        sb2.AppendLine("       ,사용여부            = '" + (int.Parse(cmb_used) - 1).ToString() + "'  ");
                        sb2.AppendLine("       ,거래처명칭주소      =  '" + txt_cust_nm + "'  ");
                        sb2.AppendLine("       ,초성명칭            =  '" + txt_cust_nm + ":" + sp.Seperate(txt_cust_nm).Substring(1) + txt_cust_nm + ":" + sp.Seperate(txt_cust_nm).Substring(1) + "'  ");
                        sb2.AppendLine("       ,수정사원번호        =  '" + Common.p_strUserNo + "'  ");
                        sb2.AppendLine("       ,수정일시            =  convert(varchar, getdate(), 120)   ");
                        sb2.AppendLine("  WHERE 사업자번호 = '" + Common.p_saupNo + "'  ");
                        sb2.AppendLine("  AND 거래처코드 =  '" + txt_cust_cd+ "' ");
                    }
                    else
                    {
                        sb2.AppendLine("  INSERT INTO T_거래처정보 ( ");
                        sb2.AppendLine("       사업자번호           ");
                        sb2.AppendLine("       ,지점코드            ");
                        sb2.AppendLine("       ,거래처코드          ");
                        sb2.AppendLine("       ,중상여부            ");
                        sb2.AppendLine("       ,거래처구분          ");
                        sb2.AppendLine("       ,거래처명            ");
                        sb2.AppendLine("       ,정식명칭            ");
                        sb2.AppendLine("       ,거래처담당자        ");
                        sb2.AppendLine("       ,대표자명            ");
                        sb2.AppendLine("       ,거래처사업자번호    ");
                        sb2.AppendLine("       ,업태                ");
                        sb2.AppendLine("       ,종목                ");
                        sb2.AppendLine("       ,사원번호            ");
                        sb2.AppendLine("       ,배송사원            ");
                        sb2.AppendLine("       ,거래개시일          ");
                        sb2.AppendLine("       ,유형코드            ");
                        sb2.AppendLine("       ,지역코드            ");
                        sb2.AppendLine("       ,우편번호            ");
                        sb2.AppendLine("       ,주소                ");
                        sb2.AppendLine("       ,상세주소            ");
                        sb2.AppendLine("       ,이메일              ");
                        sb2.AppendLine("       ,폰번호              ");
                        sb2.AppendLine("       ,전화번호            ");
                        sb2.AppendLine("       ,팩스번호            ");
                        sb2.AppendLine("       ,비고1               ");
                        sb2.AppendLine("       ,비고2               ");
                        sb2.AppendLine("       ,비고3               ");
                        sb2.AppendLine("       ,단가구분            ");
                        sb2.AppendLine("       ,부가세코드          ");
                        sb2.AppendLine("       ,계산서여부          ");
                        sb2.AppendLine("       ,발행율              ");
                        sb2.AppendLine("       ,계좌순번            ");
                        sb2.AppendLine("       ,월                  ");
                        sb2.AppendLine("       ,화                  ");
                        sb2.AppendLine("       ,수                  ");
                        sb2.AppendLine("       ,목                  ");
                        sb2.AppendLine("       ,금                  ");
                        sb2.AppendLine("       ,토                  ");
                        sb2.AppendLine("       ,일                  ");
                        sb2.AppendLine("       ,여신                ");
                        sb2.AppendLine("       ,현재잔고            ");
                        sb2.AppendLine("       ,잔고수정여부        ");
                        sb2.AppendLine("       ,초기잔고            ");
                        sb2.AppendLine("       ,잔고수정일자        ");
                        sb2.AppendLine("       ,수정당일잔고        ");
                        sb2.AppendLine("       ,수정잔고            ");
                        sb2.AppendLine("       ,사용여부            ");
                        sb2.AppendLine("       ,거래처명칭주소      ");
                        sb2.AppendLine("       ,초성명칭            ");
                        sb2.AppendLine("       ,등록사원번호        ");
                        sb2.AppendLine("       ,등록일시            ");
                        sb2.AppendLine("  ) values (  ");
                        sb2.AppendLine("  '" + Common.p_saupNo + "'  ");
                        sb2.AppendLine("  , '0'  ");
                        sb2.AppendLine("  , '" + txt_cust_cd + "'  ");
                        sb2.AppendLine("  , '0'  ");
                        sb2.AppendLine("  , '" + cust_gbn + "'  ");
                        sb2.AppendLine("  , '" + txt_cust_nm + "'  ");
                        sb2.AppendLine("  , '" + txt_cust_nm + "'  ");
                        sb2.AppendLine("  , '" + txt_cust_manager + "'  ");
                        sb2.AppendLine("  , '" + txt_owner + "'  ");
                        sb2.AppendLine("  , '" + txt_saup_no + "'  ");
                        sb2.AppendLine("  , '" + txt_uptae + "'  ");
                        sb2.AppendLine("  , '" + txt_jong + "'  ");
                        sb2.AppendLine("  , '100'  ");
                        sb2.AppendLine("  , ''  ");
                        sb2.AppendLine("  , '" + txt_start_date + "'  ");
                        sb2.AppendLine("  , ''  ");
                        sb2.AppendLine("  , ''  ");
                        sb2.AppendLine("  , '" + txt_post_no + "'  ");
                        sb2.AppendLine("  , '" + txt_addr + "'  ");
                        sb2.AppendLine("  , '" + txt_addr + "'  ");
                        sb2.AppendLine("  , '" + txt_email + "'  ");
                        sb2.AppendLine("  , '" + txt_phone + "'  ");
                        sb2.AppendLine("  , '" + txt_comp_phone + "'  ");
                        sb2.AppendLine("  , '" + txt_fax + "'  ");
                        sb2.AppendLine("  , '" + comment + "'  ");
                        sb2.AppendLine("  , ''  ");
                        sb2.AppendLine("  , ''  ");
                        sb2.AppendLine("  , ''  ");
                        sb2.AppendLine("  , '" + tax_cd + "'  ");
                        sb2.AppendLine("  , 'Y'  ");
                        sb2.AppendLine("  , '100'  ");
                        sb2.AppendLine("  , '1'  ");
                        sb2.AppendLine("  , 'N'  ");
                        sb2.AppendLine("  , 'N'  ");
                        sb2.AppendLine("  , 'N'  ");
                        sb2.AppendLine("  , 'N'  ");
                        sb2.AppendLine("  , 'N'  ");
                        sb2.AppendLine("  , 'N'  ");
                        sb2.AppendLine("  , 'N'  ");
                        sb2.AppendLine("  , 0  ");
                        sb2.AppendLine("  , 0  ");
                        sb2.AppendLine("  , 0  ");
                        sb2.AppendLine("  , 0  ");
                        sb2.AppendLine("  , ''  ");
                        sb2.AppendLine("  , 0  ");
                        sb2.AppendLine("  , 0  ");
                        sb2.AppendLine("  ,'" + (int.Parse(cmb_used) - 1).ToString() + "'  ");
                        sb2.AppendLine("  , '" + txt_cust_nm + "'  ");
                        sb2.AppendLine("  , '" + txt_cust_nm + ":" + sp.Seperate(txt_cust_nm).Substring(1) + txt_cust_nm + ":" + sp.Seperate(txt_cust_nm).Substring(1) + "'  ");
                        sb2.AppendLine("  , '" + Common.p_strUserNo + "'  ");
                        sb2.AppendLine("  , convert(varchar, getdate(), 120)   ");
                        sb2.AppendLine(" )  ");
                    }


                    Debug.WriteLine("장터지기 거래처 수정한다~!!");
                    Debug.WriteLine(sb2);
                    SqlCommand sCommand2 = new SqlCommand(sb2.ToString());

                    int qResult = wAdo.SqlCommandEtc_Jang(sCommand2, "insert_CUST_TB_JANG");
                    if (qResult > 0)
                    {
                        int qResult2 = wAdo.SqlCommandEtc(sCommand, "update_CUST_TB");
                        if (qResult2 > 0)
                        {
                            return 0;  // 0 true, 1 false
                        }
                        else return 5;
                    }
                    else return 5;
                }
                else
                {
                    int qResult2 = wAdo.SqlCommandEtc(sCommand, "update_CUST_TB");
                    if (qResult2 > 0)
                    {
                        return 0;  // 0 true, 1 false
                    }
                    else return 1;
                }
            }
            catch (Exception e)
            {
                wnLog.writeLog(wnLog.LOG_ERROR, e.Message + " - " + e.ToString());
                Popup.pop오류리포트 msg = new pop오류리포트(e.Message + " - " + e.ToString());
                msg.ShowDialog();
                return 9;
            }
        }

        public DataTable fn_Cust_List_Jang(string condition)
        {
            wnAdo wAdo = new wnAdo();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("    SELECT * ");
            sb.AppendLine("   FROM T_거래처정보 ");
            sb.AppendLine("   where 사업자번호='"+Common.p_saupNo+"'");
            sb.AppendLine(condition);
            Debug.WriteLine(sb);
            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect_Jang(sCommand);
        }

        public int updateChk(
              string txt_chk_cd
            , string chk_gbn
            , string txt_chk_nm
            , string txt_chk_ord
            , string comment)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb = new StringBuilder();
                sb.AppendLine("update N_CHK_CODE set");
                sb.AppendLine("      CHK_GUBUN = @CHK_GUBUN ");
                sb.AppendLine("     ,CHK_ORD = @CHK_ORD");
                sb.AppendLine("     ,CHK_NM = @CHK_NM");
                sb.AppendLine("     ,COMMENT = @COMMENT ");
                sb.AppendLine("     ,UPSTAFF = '" + Common.p_strStaffNo + "' ");
                sb.AppendLine("     ,UPTIME = convert(varchar, getdate(), 120) ");

                sb.AppendLine(" where CHK_CD = @CHK_CD ");

                SqlCommand sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@CHK_GUBUN", chk_gbn);
                sCommand.Parameters.AddWithValue("@CHK_ORD", txt_chk_ord);
                sCommand.Parameters.AddWithValue("@CHK_NM", txt_chk_nm);
                sCommand.Parameters.AddWithValue("@COMMENT", comment);
                sCommand.Parameters.AddWithValue("@CHK_CD", txt_chk_cd);

                int qResult = wAdo.SqlCommandEtc(sCommand, "update_CHK_TB");
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

        public int updateItem(
              string txt_item_cd
            , string txt_item_nm
            , string cmb_item_gbn
            , string txt_spec
            , string cmb_type
            , string cmb_line
            , string cmb_unit
            , string cmb_stor_loc
            , double txt_prop_stock
            , double txt_item_weight
            , double txt_input_price
            , double txt_output_price
            , double txt_char_amt
            , double txt_pack_amt
            , string cmb_cust
            , string chk_print_yn
            , string cmb_used
            , string input_date
            , string box_bar_cd
            , string box_amt
            , string unit_bar_cd
            , string unit_amt
            , string comment
            , string txt_link
            , string txt_vat_cd
            , conDataGridView comp_dgv
            , conDataGridView flow_dgv
            , conDataGridView half_dgv
            , DataGridView del_comp_dgv
            , DataGridView del_flow_dgv
            , DataGridView del_half_dgv)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb.AppendLine("update N_ITEM_CODE set");
                sb.AppendLine("      ITEM_NM = @ITEM_NM ");
                sb.AppendLine("     ,ITEM_GUBUN = @ITEM_GUBUN ");
                sb.AppendLine("     ,SPEC = @SPEC ");
                sb.AppendLine("     ,TYPE_CD = @TYPE_CD ");
                sb.AppendLine("     ,UNIT_CD = @UNIT_CD ");
                sb.AppendLine("     ,LINE_CD = @LINE_CD ");
                sb.AppendLine("     ,PROP_STOCK = @PROP_STOCK ");
                sb.AppendLine("     ,ITEM_WEIGHT = @ITEM_WEIGHT ");
                sb.AppendLine("     ,INPUT_PRICE = @INPUT_PRICE ");
                sb.AppendLine("     ,OUTPUT_PRICE = @OUTPUT_PRICE ");
                sb.AppendLine("     ,CHARGE_AMT = @CHARGE_AMT ");
                sb.AppendLine("     ,PACK_AMT = @PACK_AMT ");
                sb.AppendLine("     ,CUST_CD = @CUST_CD ");
                sb.AppendLine("     ,PRINT_YN = @PRINT_YN ");
                sb.AppendLine("     ,USED_CD = @USED_CD ");
                sb.AppendLine("     ,INPUT_DATE = @INPUT_DATE ");
                sb.AppendLine("     ,BOX_BAR_CD = @BOX_BAR_CD ");
                sb.AppendLine("     ,BOX_AMT = @BOX_AMT ");
                sb.AppendLine("     ,UNIT_BAR_CD = @UNIT_BAR_CD ");
                sb.AppendLine("     ,UNIT_AMT = @UNIT_AMT ");
                sb.AppendLine("     ,COMMENT = @COMMENT ");
                sb.AppendLine("     ,LINK_CD = " + (txt_link.Equals("") ? txt_item_cd : "'" + txt_link + "'"));
                sb.AppendLine("     ,VAT_CD =  @VAT_CD ");

                sb.AppendLine(" where ITEM_CD = @ITEM_CD ");

                if (comp_dgv.Rows.Count > 0)
                {
                    for (int i = 0; i < comp_dgv.Rows.Count; i++)
                    {
                        string txt_seq = (string)comp_dgv.Rows[i].Cells["SEQ"].Value;
                        if (txt_seq == "" || txt_seq == null)
                        {
                            sb.AppendLine("declare @seq" + i + " int ");
                            sb.AppendLine("select @seq" + i + " =ISNULL(MAX(SEQ),0)+1 from N_ITEM_COMP ");
                            sb.AppendLine("where ITEM_CD = '" + txt_item_cd + "' ");

                            sb.AppendLine("insert into N_ITEM_COMP(");
                            sb.AppendLine("     ITEM_CD ");
                            sb.AppendLine("     ,SEQ ");
                            sb.AppendLine("     ,RAW_MAT_CD ");
                            sb.AppendLine("     ,TOTAL_AMT ");
                            sb.AppendLine("  )values ( ");
                            sb.AppendLine("     '" + txt_item_cd + "' ");
                            sb.AppendLine("     ,@seq" + i + " ");
                            sb.AppendLine("     ,'" + comp_dgv.Rows[i].Cells["RAW_MAT_CD"].Value + "' ");
                            sb.AppendLine("     ,'" + comp_dgv.Rows[i].Cells["TOTAL_AMT"].Value + "' ");
                            sb.AppendLine("  )");
                        }
                        else
                        {
                            sb.AppendLine("update N_ITEM_COMP set");
                            sb.AppendLine("      RAW_MAT_CD =  '" + comp_dgv.Rows[i].Cells["RAW_MAT_CD"].Value + "' ");
                            sb.AppendLine("     ,TOTAL_AMT =  '" + comp_dgv.Rows[i].Cells["TOTAL_AMT"].Value + "' ");
                            sb.AppendLine(" where ITEM_CD = '" + txt_item_cd + "' ");
                            sb.AppendLine(" and SEQ = '" + comp_dgv.Rows[i].Cells["SEQ"].Value + "'");
                        }
                    }
                }

                if (flow_dgv.Rows.Count > 0)
                {
                    for (int i = 0; i < flow_dgv.Rows.Count; i++)
                    {
                        string txt_seq = (string)flow_dgv.Rows[i].Cells["F_SEQ"].Value;
                        if (txt_seq == "" || txt_seq == null)
                        {
                            sb.AppendLine("declare @f_seq" + i + " int ");
                            sb.AppendLine("select @f_seq" + i + " =ISNULL(MAX(SEQ),0)+1 from N_ITEM_FLOW ");
                            sb.AppendLine("where ITEM_CD = '" + txt_item_cd + "' ");

                            sb.AppendLine("insert into N_ITEM_FLOW(");
                            sb.AppendLine("     ITEM_CD ");
                            sb.AppendLine("     ,SEQ ");
                            sb.AppendLine("     ,FLOW_CD ");
                            sb.AppendLine("     ,COMMENT ");
                            sb.AppendLine("     ,BOX_AMT ");
                            sb.AppendLine("     ,CVR_RATIO ");
                            sb.AppendLine("     ,CHARGE_AMT ");
                            sb.AppendLine("  )values ( ");
                            sb.AppendLine("     '" + txt_item_cd + "' ");
                            sb.AppendLine("     ,@f_seq" + i + " ");
                            sb.AppendLine("     ,'" + flow_dgv.Rows[i].Cells["FLOW_CD"].Value + "' ");
                            sb.AppendLine("     ,'" + flow_dgv.Rows[i].Cells["FLOW_ETC"].Value + "' ");
                            sb.AppendLine("     ,0 ");
                            sb.AppendLine("     ,0 ");
                            sb.AppendLine("     ,0");

                            sb.AppendLine("  )");
                        }
                        else
                        {
                            sb.AppendLine("update N_ITEM_FLOW set");
                            sb.AppendLine("      FLOW_CD =  '" + flow_dgv.Rows[i].Cells["FLOW_CD"].Value + "' ");
                            sb.AppendLine("     ,COMMENT =  '" + flow_dgv.Rows[i].Cells["FLOW_ETC"].Value + "' ");
                            sb.AppendLine(" where ITEM_CD = '" + txt_item_cd + "' ");
                            sb.AppendLine(" and SEQ = '" + flow_dgv.Rows[i].Cells["F_SEQ"].Value + "'");
                        }
                    }
                }

                if (half_dgv.Rows.Count > 0)
                {
                    for (int i = 0; i < half_dgv.Rows.Count; i++)
                    {
                        string txt_seq = (string)half_dgv.Rows[i].Cells["H_SEQ"].Value;
                        if (txt_seq == "" || txt_seq == null)
                        {
                            sb.AppendLine("declare @h_seq" + i + " int ");
                            sb.AppendLine("select @h_seq" + i + " =ISNULL(MAX(SEQ),0)+1 from N_ITEM_COMP_HALF ");
                            sb.AppendLine("where ITEM_CD = '" + txt_item_cd + "' ");

                            sb.AppendLine("insert into N_ITEM_COMP_HALF(");
                            sb.AppendLine("     ITEM_CD ");
                            sb.AppendLine("     ,SEQ ");
                            sb.AppendLine("     ,HALF_ITEM_CD ");
                            sb.AppendLine("     ,TOTAL_AMT ");
                            sb.AppendLine("  )values ( ");
                            sb.AppendLine("     '" + txt_item_cd + "' ");
                            sb.AppendLine("     ,@h_seq" + i + " ");
                            sb.AppendLine("     ,'" + half_dgv.Rows[i].Cells["HALF_ITEM_CD"].Value + "' ");
                            sb.AppendLine("     ,'" + half_dgv.Rows[i].Cells["H_TOTAL_AMT"].Value + "' ");
                            sb.AppendLine("  )");
                        }
                        else
                        {
                            sb.AppendLine("update N_ITEM_COMP_HALF set");
                            sb.AppendLine("      HALF_ITEM_CD =  '" + half_dgv.Rows[i].Cells["HALF_ITEM_CD"].Value + "' ");
                            sb.AppendLine("     ,TOTAL_AMT =  '" + half_dgv.Rows[i].Cells["H_TOTAL_AMT"].Value + "' ");
                            sb.AppendLine(" where ITEM_CD = '" + txt_item_cd + "' ");
                            sb.AppendLine(" and SEQ = '" + half_dgv.Rows[i].Cells["H_SEQ"].Value + "'");
                        }
                    }
                }

                if (del_comp_dgv.Rows.Count > 0)
                {
                    for (int i = 0; i < del_comp_dgv.Rows.Count; i++)
                    {
                        sb.AppendLine("delete from N_ITEM_COMP ");
                        sb.AppendLine("    where ITEM_CD = '" + txt_item_cd + "' ");
                        sb.AppendLine("     and SEQ = '" + del_comp_dgv.Rows[i].Cells["SEQ"].Value + "' ");
                    }
                }
                if (del_flow_dgv.Rows.Count > 0)
                {
                    for (int i = 0; i < del_flow_dgv.Rows.Count; i++)
                    {
                        sb.AppendLine("delete from N_ITEM_FLOW ");
                        sb.AppendLine("    where ITEM_CD = '" + txt_item_cd + "' ");
                        sb.AppendLine("     and SEQ = '" + del_flow_dgv.Rows[i].Cells["F_SEQ"].Value + "' ");
                    }
                }

                if (del_half_dgv.Rows.Count > 0)
                {
                    for (int i = 0; i < del_half_dgv.Rows.Count; i++)
                    {
                        sb.AppendLine("delete from N_ITEM_COMP_HALF ");
                        sb.AppendLine("    where ITEM_CD = '" + txt_item_cd + "' ");
                        sb.AppendLine("     and SEQ = '" + del_half_dgv.Rows[i].Cells["H_SEQ"].Value + "' ");
                    }
                }

                SqlCommand sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@ITEM_NM", txt_item_nm);
                sCommand.Parameters.AddWithValue("@ITEM_GUBUN", cmb_item_gbn);
                sCommand.Parameters.AddWithValue("@SPEC", txt_spec);
                sCommand.Parameters.AddWithValue("@TYPE_CD", cmb_type);
                sCommand.Parameters.AddWithValue("@UNIT_CD", cmb_unit);
                sCommand.Parameters.AddWithValue("@LINE_CD", cmb_line);
                //sCommand.Parameters.AddWithValue("@STOCK_LOC", "");
                sCommand.Parameters.AddWithValue("@PROP_STOCK", txt_prop_stock);
                sCommand.Parameters.AddWithValue("@ITEM_WEIGHT", txt_item_weight);
                sCommand.Parameters.AddWithValue("@INPUT_PRICE", txt_input_price);
                sCommand.Parameters.AddWithValue("@OUTPUT_PRICE", txt_output_price);
                sCommand.Parameters.AddWithValue("@CHARGE_AMT", txt_char_amt);
                sCommand.Parameters.AddWithValue("@PACK_AMT", txt_pack_amt);
                sCommand.Parameters.AddWithValue("@CUST_CD", cmb_cust);
                sCommand.Parameters.AddWithValue("@PRINT_YN", chk_print_yn);
                sCommand.Parameters.AddWithValue("@USED_CD", cmb_used);
                sCommand.Parameters.AddWithValue("@INPUT_DATE", input_date);
                sCommand.Parameters.AddWithValue("@BOX_BAR_CD", box_bar_cd);
                sCommand.Parameters.AddWithValue("@BOX_AMT", box_amt);
                sCommand.Parameters.AddWithValue("@UNIT_BAR_CD", unit_bar_cd);
                sCommand.Parameters.AddWithValue("@UNIT_AMT", unit_amt);
                sCommand.Parameters.AddWithValue("@COMMENT", comment);
                sCommand.Parameters.AddWithValue("@VAT_CD", txt_vat_cd);


                sCommand.Parameters.AddWithValue("@ITEM_CD", txt_item_cd);


                if (Common.sp_pack_gubun.ToString().Equals("1"))
                {
                    sep sp = new sep();
                    StringBuilder sb2 = new StringBuilder();
                    if (txt_link == null || txt_link.Equals(""))
                    {
                        sb2 = new StringBuilder();

                        sb2.AppendLine("DECLARE @LINK INT, @ITEMNM NVARCHAR, @SPEC NVARCHAR  ");
                        sb2.AppendLine("SET @LINK = (SELECT TOP 1 상품코드   ");
                        sb2.AppendLine("FROM T_상품정보  ");
                        sb2.AppendLine("WHERE 사업자번호 = '" + Common.p_saupNo + "'   ");
                        sb2.AppendLine("ORDER BY 상품코드 DESC) + 1  ");
                        //sb2.AppendLine("SET @ITEMNM = ");
                        //sb2.AppendLine(" REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE('" + txt_item_nm + "','!','ㄱ'),'@','ㄴ'),'#','ㄷ'),'$','ㄹ'),'%','ㅁ'),'^','ㅂ'),'&','ㅅ'),'*','ㅇ'),'(','ㅈ'),')','ㅊ'),'-','ㅋ'),'+','ㅌ') ");
                        //sb2.AppendLine("SET @SPEC =  ");
                        //sb2.AppendLine("REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE('" + txt_spec + "','!','ㄱ'),'@','ㄴ'),'#','ㄷ'),'$','ㄹ'),'%','ㅁ'),'^','ㅂ'),'&','ㅅ'),'*','ㅇ'),'(','ㅈ'),')','ㅊ'),'-','ㅋ'),'+','ㅌ') ");
                    
                        sb2.AppendLine("  insert into T_상품정보 ( ");
                        sb2.AppendLine("  사업자번호 ");
                        sb2.AppendLine("  ,지점코드 ");
                        sb2.AppendLine("  ,상품코드 ");
                        sb2.AppendLine("  ,상품명 ");
                        sb2.AppendLine("  ,규격 ");
                        sb2.AppendLine("  ,사입품 ");
                        sb2.AppendLine("  ,정렬순서 ");
                        sb2.AppendLine("  ,낱개기본판매수량 ");
                        sb2.AppendLine("  ,낱개입고단가 ");
                        sb2.AppendLine("  ,낱개판매단가 ");
                        sb2.AppendLine("  ,낱개도매단가 ");
                        sb2.AppendLine("  ,낱개바코드 ");
                        sb2.AppendLine("  ,입수수량 ");
                        sb2.AppendLine("  ,박스기본판매수량 ");
                        sb2.AppendLine("  ,박스입고단가 ");
                        sb2.AppendLine("  ,박스판매단가 ");
                        sb2.AppendLine("  ,박스도매단가 ");
                        sb2.AppendLine("  ,박스바코드 ");
                        sb2.AppendLine("  ,중간입수수량 ");
                        sb2.AppendLine("  ,중간기본판매수량 ");
                        sb2.AppendLine("  ,중간입고단가 ");
                        sb2.AppendLine("  ,중간판매단가 ");
                        sb2.AppendLine("  ,중간도매단가 ");
                        sb2.AppendLine("  ,중간바코드 ");
                        sb2.AppendLine("  ,상품구분 ");
                        sb2.AppendLine("  ,과세구분 ");
                        sb2.AppendLine("  ,상품유형코드 ");
                        sb2.AppendLine("  ,제조사코드 ");
                        sb2.AppendLine("  ,주매입처코드 ");
                        sb2.AppendLine("  ,유통기간 ");
                        sb2.AppendLine("  ,비고 ");
                        sb2.AppendLine("  ,현재재고 ");
                        sb2.AppendLine("  ,안전재고 ");
                        sb2.AppendLine("  ,사용여부 ");
                        sb2.AppendLine("  ,상품규격 ");
                        sb2.AppendLine("  ,초성명칭 ");
                        sb2.AppendLine("  ,등록사원번호 ");
                        sb2.AppendLine("  ,등록일시 ");
                        sb2.AppendLine("  ,Old_Code ");
                        sb2.AppendLine("  ,출고위치 ");
                        sb2.AppendLine("  ,기준이익율여부 ");
                        sb2.AppendLine("  ,기준이익율 ");
                        sb2.AppendLine("  ,기준단가 ");
                        sb2.AppendLine("  ,중상기준이익율 ");
                        sb2.AppendLine("  ,중상기준단가 ");
                        sb2.AppendLine("  ,수량별단가여부 ");
                        sb2.AppendLine("  ) values ( ");
                        sb2.AppendLine("  '" + Common.p_saupNo + "' ");
                        sb2.AppendLine("  ,'" + 0 + "' ");
                        sb2.AppendLine("  ,@LINK ");
                       // sb2.AppendLine("  ,@ITEMNM ");
                       // sb2.AppendLine("  ,@SPEC ");       
                        sb2.AppendLine("  ,'" + txt_item_cd + "' ");
                        sb2.AppendLine("  ,'" + txt_item_nm + "' ");
                        sb2.AppendLine("  ,'" + txt_spec + "' ");
                        sb2.AppendLine("  ,'N' ");
                        sb2.AppendLine("  ,'999999' ");
                        sb2.AppendLine("  ,1 ");
                        sb2.AppendLine("  ," + txt_input_price + " ");
                        sb2.AppendLine("  ," + txt_output_price + " ");
                        sb2.AppendLine("  ,0 ");
                        sb2.AppendLine("  ,'' ");
                        sb2.AppendLine("  ,0 ");
                        sb2.AppendLine("  ,0 ");
                        sb2.AppendLine("  ,0 ");
                        sb2.AppendLine("  ,0 ");
                        sb2.AppendLine("  ,0 ");
                        sb2.AppendLine("  ,'" + box_bar_cd + "' ");
                        sb2.AppendLine("  ,0 ");
                        sb2.AppendLine("  ,0 ");
                        sb2.AppendLine("  ,0 ");
                        sb2.AppendLine("  ,0 ");
                        sb2.AppendLine("  ,0 ");
                        sb2.AppendLine("  ,'' ");
                        sb2.AppendLine("  ,'1' ");
                        sb2.AppendLine("  ,'" + txt_vat_cd + "' ");
                        sb2.AppendLine("  ,'' ");
                        sb2.AppendLine("  ,'' ");
                        sb2.AppendLine("  ,'' ");
                        sb2.AppendLine("  ,0 ");
                        sb2.AppendLine("  ,'' ");
                        sb2.AppendLine("  ,0 ");
                        sb2.AppendLine("  ,0 ");
                        sb2.AppendLine("  ,0 ");
                        sb2.AppendLine("  ,'" + txt_item_nm + txt_spec + "'  ");
                        sb2.AppendLine("  ,'" + txt_item_nm + ":" + sp.Seperate(txt_item_nm).Substring(1) + "'  ");
                        sb2.AppendLine("  ,'" + Common.p_strUserNo + "'  ");
                        sb2.AppendLine("     ,convert(varchar, getdate(), 120) ");
                        sb2.AppendLine("  ,'' ");
                        sb2.AppendLine("  ,'' ");
                        sb2.AppendLine("  ,'N' ");
                        sb2.AppendLine("  ,0 ");
                        sb2.AppendLine("  ,0 ");
                        sb2.AppendLine("  ,0 ");
                        sb2.AppendLine("  ,0 ");
                        sb2.AppendLine("  ,'N' ");
                        sb2.AppendLine(" )  ");
                    }
                    else
                    {
                        sb2 = new StringBuilder();
                        sb2.AppendLine("  update T_상품정보 SET ");
                        sb2.AppendLine("  상품명 =           '" + txt_item_nm + "' ");
                        sb2.AppendLine("  ,규격 =             '" + txt_spec + "' ");
                        //sb2.AppendLine("  상품명 =    ");
                        //sb2.AppendLine(" REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE('" + txt_item_nm + "','!','ㄱ'),'@','ㄴ'),'#','ㄷ'),'$','ㄹ'),'%','ㅁ'),'^','ㅂ'),'&','ㅅ'),'*','ㅇ'),'(','ㅈ'),')','ㅊ'),'-','ㅋ'),'+','ㅌ') ");
                        //sb2.AppendLine("  ,규격 =     ");
                        //sb2.AppendLine("REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE('" + txt_spec + "','!','ㄱ'),'@','ㄴ'),'#','ㄷ'),'$','ㄹ'),'%','ㅁ'),'^','ㅂ'),'&','ㅅ'),'*','ㅇ'),'(','ㅈ'),')','ㅊ'),'-','ㅋ'),'+','ㅌ') ");
                        sb2.AppendLine("  ,사입품 =           'N' ");
                        sb2.AppendLine("  ,정렬순서 =         '999999' ");
                        sb2.AppendLine("  ,낱개기본판매수량 = 1 ");
                        sb2.AppendLine("  ,낱개입고단가 =     " + txt_input_price + " ");
                        sb2.AppendLine("  ,낱개판매단가 =     " + txt_output_price + " ");
                        sb2.AppendLine("  ,낱개도매단가 =     0 ");
                        sb2.AppendLine("  ,낱개바코드 =       '' ");
                        sb2.AppendLine("  ,입수수량 =         0 ");
                        sb2.AppendLine("  ,박스기본판매수량 = 0 ");
                        sb2.AppendLine("  ,박스입고단가 =     0 ");
                        sb2.AppendLine("  ,박스판매단가 =     0 ");
                        sb2.AppendLine("  ,박스도매단가 =     0 ");
                        sb2.AppendLine("  ,박스바코드 =       '" + box_bar_cd + "' ");
                        sb2.AppendLine("  ,중간입수수량 =     0 ");
                        sb2.AppendLine("  ,중간기본판매수량 = 0 ");
                        sb2.AppendLine("  ,중간입고단가 =     0 ");
                        sb2.AppendLine("  ,중간판매단가 =     0 ");
                        sb2.AppendLine("  ,중간도매단가 =     0 ");
                        sb2.AppendLine("  ,중간바코드 =       '' ");
                        sb2.AppendLine("  ,상품구분 =         '1' ");
                        sb2.AppendLine("  ,과세구분 =         '" + txt_vat_cd + "' ");
                        sb2.AppendLine("  ,상품유형코드 =     '' ");
                        sb2.AppendLine("  ,제조사코드 =       '' ");
                        sb2.AppendLine("  ,주매입처코드 =     '' ");
                        sb2.AppendLine("  ,유통기간 =         0 ");
                        sb2.AppendLine("  ,비고 =             '' ");
                        sb2.AppendLine("  ,현재재고 =         0 ");
                        sb2.AppendLine("  ,안전재고 =         0 ");
                        sb2.AppendLine("  ,사용여부 =         0 ");
                        sb2.AppendLine("  ,상품규격 =         '" + txt_item_nm + txt_spec + "'  ");
                        sb2.AppendLine("  ,초성명칭 =         '" + txt_item_nm + ":" + sp.Seperate(txt_item_nm).Substring(1) + "'  ");
                        sb2.AppendLine("  ,수정사원번호 =     '" + Common.p_strUserNo + "'  ");
                        sb2.AppendLine("  ,수정일시 =         convert(varchar, getdate(), 120) ");
                        sb2.AppendLine("  ,Old_Code =         '' ");
                        sb2.AppendLine("  ,출고위치 =         '' ");
                        sb2.AppendLine("  ,기준이익율여부 =   'N' ");
                        sb2.AppendLine("  ,기준이익율 =       0 ");
                        sb2.AppendLine("  ,기준단가 =         0 ");
                        sb2.AppendLine("  ,중상기준이익율 =   0 ");
                        sb2.AppendLine("  ,중상기준단가 =     0 ");
                        sb2.AppendLine("  ,수량별단가여부 =   'N' ");
                        sb2.AppendLine("  WHERE 사업자번호 =   '" + Common.p_saupNo + "' AND 상품코드 =  '" + txt_item_cd + "' ");
                 
                    }

                    SqlCommand sCommand2 = new SqlCommand(sb2.ToString());

                    int qResult = wAdo.SqlCommandEtc_Jang(sCommand2, "update_ITEM_TB_JANG");
                    if (qResult > 0)
                    {
                        int qResult2 = wAdo.SqlCommandEtc(sCommand, "update_ITEM_TB");
                        if (qResult2 > 0)
                        {
                            return 0;  // 0 true, 1 false
                        }
                        else return 1;
                    }
                    else return 1;
                }
                else
                {
                    int qResult2 = wAdo.SqlCommandEtc(sCommand, "update_ITEM_TB");
                    if (qResult2 > 0)
                    {
                        return 0;  // 0 true, 1 false
                    }
                    else return 1;
                }
            }
            catch (Exception e)
            {
                wnLog.writeLog(wnLog.LOG_ERROR, e.Message + " - " + e.ToString());
                Popup.pop오류리포트 msg = new pop오류리포트(e.Message + " - " + e.ToString());
                msg.ShowDialog();
                return 9;
            }
        }

        public int updateBsItem(
              System.Windows.Forms.DataGridView dgv)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    string printYn = "";
                    if ((bool)dgv.Rows[i].Cells["PRINT_YN"].Value == true)
                        printYn = "Y";
                    else
                        printYn = "N";
                    sb.AppendLine("update N_ITEM_CODE set");
                    sb.AppendLine("      BASIC_STOCK =  " + int.Parse(dgv.Rows[i].Cells["BASIC_STOCK"].Value.ToString()) + " ");
                    sb.AppendLine("     ,PRINT_YN = '" + printYn + "' ");

                    sb.AppendLine(" where ITEM_CD = '" + dgv.Rows[i].Cells["ITEM_CD"].Value.ToString() + "' ");

                }

                SqlCommand sCommand = new SqlCommand(sb.ToString());

                int qResult = wAdo.SqlCommandEtc(sCommand, "update_BS_ITEM_TB");
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

        public int updateBsRaw(System.Windows.Forms.DataGridView dgv)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < dgv.Rows.Count; i++)
                {

                    sb.AppendLine("update N_RAW_CODE set");
                    sb.AppendLine("      BASIC_STOCK =  " + int.Parse(dgv.Rows[i].Cells["BASIC_STOCK"].Value.ToString()) + " ");

                    sb.AppendLine(" where RAW_MAT_CD = '" + dgv.Rows[i].Cells["RAW_MAT_CD"].Value.ToString() + "' ");

                }

                SqlCommand sCommand = new SqlCommand(sb.ToString());

                int qResult = wAdo.SqlCommandEtc(sCommand, "update_BS_RAW_TB");
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

        public int updateFac(
              string txt_fac_cd
            , string txt_fac_nm
            , string txt_model_nm
            , string txt_spec
            , string txt_manu_comp
            , string txt_acq_date
            , string txt_acq_price
            , string cmb_dept
            , string txt_used
            , string txt_pro_capa
            , string txt_power_num
            , string cmb_mainten)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb = new StringBuilder();
                sb.AppendLine("update N_FAC_CODE set");
                sb.AppendLine("      FAC_NM = @FAC_NM ");
                sb.AppendLine("     ,MODEL_NM = @MODEL_NM ");
                sb.AppendLine("     ,SPEC = @SPEC ");
                sb.AppendLine("     ,MANU_COMPANY = @MANU_COMPANY ");
                sb.AppendLine("     ,ACQ_DATE = @ACQ_DATE ");
                sb.AppendLine("     ,ACQ_PRICE = @ACQ_PRICE ");
                sb.AppendLine("     ,DEPT_CD = @DEPT_CD ");
                sb.AppendLine("     ,USED = @USED ");
                sb.AppendLine("     ,PRO_CAPA = @PRO_CAPA ");
                sb.AppendLine("     ,POWER_NUMBER = @POWER_NUMBER ");
                sb.AppendLine("     ,MAINTEN_CLASS = @MAINTEN_CLASS ");

                sb.AppendLine(" where FAC_CD = @FAC_CD ");

                SqlCommand sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@FAC_CD", txt_fac_cd);
                sCommand.Parameters.AddWithValue("@FAC_NM", txt_fac_nm);
                sCommand.Parameters.AddWithValue("@MODEL_NM", txt_model_nm);
                sCommand.Parameters.AddWithValue("@SPEC", txt_spec);
                sCommand.Parameters.AddWithValue("@MANU_COMPANY", txt_manu_comp);
                sCommand.Parameters.AddWithValue("@ACQ_DATE", txt_acq_date);
                sCommand.Parameters.AddWithValue("@ACQ_PRICE", txt_acq_price);
                sCommand.Parameters.AddWithValue("@DEPT_CD", cmb_dept);
                sCommand.Parameters.AddWithValue("@USED", txt_used);
                sCommand.Parameters.AddWithValue("@PRO_CAPA", txt_pro_capa);
                sCommand.Parameters.AddWithValue("@POWER_NUMBER", txt_power_num);
                sCommand.Parameters.AddWithValue("@MAINTEN_CLASS", cmb_mainten);

                int qResult = wAdo.SqlCommandEtc(sCommand, "update_FAC_TB");
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

        public int updatePlan(
              string plan_date
            , string txt_plan_cd
            , string txt_cust_cd
            , string deliver_req_date
            , string order_yn
            , string comment
            , conDataGridView p_item_dgv
            , DataGridView p_half_dgv
            , DataGridView del_dgv
            , DataGridView del_half_dgv)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb = new StringBuilder();
                sb.AppendLine("update F_PLAN set");
                sb.AppendLine("      CUST_CD = @CUST_CD ");
                sb.AppendLine("     ,DELIVER_REQ_DATE = @DELIVER_REQ_DATE ");
                sb.AppendLine("     ,ORDER_YN = @ORDER_YN ");
                sb.AppendLine("     ,UPSTAFF = '" + Common.p_strStaffNo + "' ");
                sb.AppendLine("     ,UPTIME = convert(varchar, getdate(), 120) ");
                sb.AppendLine("     ,COMMENT = @COMMENT ");

                sb.AppendLine(" where PLAN_DATE = @PLAN_DATE and PLAN_CD= @PLAN_CD ");

                if (p_item_dgv.Rows.Count > 0)
                {
                    for (int i = 0; i < p_item_dgv.Rows.Count; i++)
                    {
                        string txt_seq = (string)p_item_dgv.Rows[i].Cells["SEQ"].Value;
                        if (txt_seq == "" || txt_seq == null)
                        {
                            sb.AppendLine("declare @item_seq" + i + " int ");
                            sb.AppendLine("select @item_seq" + i + " =ISNULL(MAX(SEQ),0)+1 from F_PLAN_DETAIL ");
                            sb.AppendLine("where PLAN_DATE = '" + plan_date + "' ");
                            sb.AppendLine("and PLAN_CD =  '" + txt_plan_cd + "' ");

                            sb.AppendLine("insert into F_PLAN_DETAIL(");
                            sb.AppendLine("     PLAN_DATE ");
                            sb.AppendLine("     ,PLAN_CD ");
                            sb.AppendLine("     ,SEQ ");
                            sb.AppendLine("     ,ITEM_CD ");
                            sb.AppendLine("     ,UNIT_CD ");
                            sb.AppendLine("     ,TOTAL_AMT ");
                            sb.AppendLine("     ,PRICE ");
                            sb.AppendLine("     ,TOTAL_MONEY ");
                            sb.AppendLine("     ,WORK_YN ");
                            sb.AppendLine("     ,F_LEVEL ");
                            sb.AppendLine("     ,DEFAULT_AMT ");
                            sb.AppendLine("     ,INSTAFF ");
                            sb.AppendLine("     ,INTIME ");
                            sb.AppendLine("  )values ( ");
                            sb.AppendLine("       '" + plan_date + "' ");
                            sb.AppendLine("      ,'" + txt_plan_cd + "' ");
                            sb.AppendLine("     ,@item_seq" + i + " ");
                            sb.AppendLine("     ,'" + p_item_dgv.Rows[i].Cells["ITEM_CD"].Value + "' ");
                            sb.AppendLine("     ,'" + p_item_dgv.Rows[i].Cells["UNIT_CD"].Value + "' ");
                            sb.AppendLine("     ,'" + ((string)p_item_dgv.Rows[i].Cells["TOTAL_AMT"].Value).Replace(",", "") + "' ");
                            sb.AppendLine("     ,'" + ((string)p_item_dgv.Rows[i].Cells["PRICE"].Value).Replace(",", "") + "' ");
                            sb.AppendLine("     ,'" + ((string)p_item_dgv.Rows[i].Cells["TOTAL_MONEY"].Value).Replace(",", "") + "' ");
                            sb.AppendLine("     ,'N' ");
                            sb.AppendLine("     , 1 ");
                            sb.AppendLine("     , 1  ");
                            sb.AppendLine("     ,'" + Common.p_strStaffNo + "' ");
                            sb.AppendLine("     ,convert(varchar, getdate(), 120) ");
                            sb.AppendLine("  )");

                        }
                        else
                        {
                            sb.AppendLine("update F_PLAN_DETAIL set");
                            sb.AppendLine("      ITEM_CD =  '" + p_item_dgv.Rows[i].Cells["ITEM_CD"].Value + "' ");
                            sb.AppendLine("      ,TOTAL_AMT =  '" + ((string)p_item_dgv.Rows[i].Cells["TOTAL_AMT"].Value).Replace(",", "") + "' ");
                            sb.AppendLine("      ,PRICE =  '" + ((string)p_item_dgv.Rows[i].Cells["PRICE"].Value).Replace(",", "") + "' ");
                            sb.AppendLine("      ,TOTAL_MONEY =  '" + ((string)p_item_dgv.Rows[i].Cells["TOTAL_MONEY"].Value).Replace(",", "") + "' ");

                            if ((bool)p_item_dgv.Rows[i].Cells["WORK_YN"].Value == true)
                            {
                                sb.AppendLine("      ,WORK_YN =  'Y' ");
                            }
                            else
                            {
                                sb.AppendLine("      ,WORK_YN =  'N' ");
                            }

                            sb.AppendLine("      ,UPSTAFF =  '" + Common.p_strStaffNo + "' ");
                            sb.AppendLine("      ,UPTIME =  convert(varchar, getdate(), 120) ");
                            sb.AppendLine(" where PLAN_DATE = '" + plan_date + "' ");
                            sb.AppendLine(" and PLAN_CD = '" + txt_plan_cd + "' ");
                            sb.AppendLine(" and SEQ = '" + p_item_dgv.Rows[i].Cells["SEQ"].Value + "'");
                        }
                    }
                }

                if (p_half_dgv.Rows.Count > 0)
                {
                    for (int i = 0; i < p_half_dgv.Rows.Count; i++)
                    {
                        string txt_seq = (string)p_half_dgv.Rows[i].Cells["H_SEQ"].Value;
                        if (txt_seq == "" || txt_seq == null)
                        {

                            sb.AppendLine("declare @half_seq" + i + " int ");
                            sb.AppendLine("select @half_seq" + i + " =ISNULL(MAX(SEQ),0)+1 from F_PLAN_DETAIL ");
                            sb.AppendLine("where PLAN_DATE = '" + plan_date + "' ");
                            sb.AppendLine("and PLAN_CD =  '" + txt_plan_cd + "' ");

                            sb.AppendLine("insert into F_PLAN_DETAIL(");
                            sb.AppendLine("     PLAN_DATE ");
                            sb.AppendLine("     ,PLAN_CD ");
                            sb.AppendLine("     ,SEQ ");
                            sb.AppendLine("     ,ITEM_CD ");
                            sb.AppendLine("     ,UNIT_CD ");
                            sb.AppendLine("     ,TOTAL_AMT ");
                            sb.AppendLine("     ,PRICE ");
                            sb.AppendLine("     ,TOTAL_MONEY ");
                            sb.AppendLine("     ,WORK_YN ");
                            sb.AppendLine("     ,F_LEVEL ");
                            sb.AppendLine("     ,TOP_ITEM_CD ");
                            sb.AppendLine("     ,P_ITEM_CD ");
                            sb.AppendLine("     ,DEFAULT_AMT ");
                            sb.AppendLine("     ,INSTAFF");
                            sb.AppendLine("     ,INTIME");
                            sb.AppendLine("  )values ( ");
                            sb.AppendLine("      '" + plan_date + "' ");
                            sb.AppendLine("     ,'" + txt_plan_cd + "' ");
                            sb.AppendLine("     ,@half_seq" + i + " ");
                            sb.AppendLine("     ,'" + p_half_dgv.Rows[i].Cells["HALF_ITEM_CD"].Value + "' ");
                            sb.AppendLine("     ,'" + p_half_dgv.Rows[i].Cells["H_UNIT_CD"].Value + "' ");
                            sb.AppendLine("     ,'" + ((string)p_half_dgv.Rows[i].Cells["H_TOTAL_AMT"].Value).Replace(",", "") + "' ");
                            sb.AppendLine("     ,'" + ((string)p_half_dgv.Rows[i].Cells["H_PRICE"].Value).Replace(",", "") + "' ");
                            sb.AppendLine("     ,'" + ((string)p_half_dgv.Rows[i].Cells["H_TOTAL_MONEY"].Value).Replace(",", "") + "' ");
                            sb.AppendLine("      ,'N' ");
                            sb.AppendLine("      ,'" + ((string)p_half_dgv.Rows[i].Cells["F_LEVEL"].Value).Replace(",", "") + "'  ");
                            sb.AppendLine("      ,'" + p_half_dgv.Rows[i].Cells["TOP_ITEM_CD"].Value + "'  ");
                            sb.AppendLine("      ,'" + p_half_dgv.Rows[i].Cells["P_ITEM_CD"].Value + "'  ");
                            sb.AppendLine("      ,'" + ((string)p_half_dgv.Rows[i].Cells["DEFAULT_AMT"].Value).Replace(",", "") + "' ");
                            sb.AppendLine("     ,'" + Common.p_strStaffNo + "' ");
                            sb.AppendLine("     ,convert(varchar, getdate(), 120) ");
                            sb.AppendLine("  )");
                        }
                        else
                        {
                            sb.AppendLine("update F_PLAN_DETAIL set");
                            sb.AppendLine("      ITEM_CD =  '" + p_half_dgv.Rows[i].Cells["HALF_ITEM_CD"].Value + "' ");
                            sb.AppendLine("      ,TOTAL_AMT =  '" + ((string)p_half_dgv.Rows[i].Cells["H_TOTAL_AMT"].Value).Replace(",", "") + "' ");

                            if ((bool)p_half_dgv.Rows[i].Cells["H_WORK_YN"].Value == true)
                            {
                                sb.AppendLine("      ,WORK_YN =  'Y' ");
                            }
                            else
                            {
                                sb.AppendLine("      ,WORK_YN =  'N' ");
                            }

                            sb.AppendLine("      ,UPSTAFF =  '" + Common.p_strStaffNo + "' ");
                            sb.AppendLine("      ,UPTIME =  convert(varchar, getdate(), 120) ");
                            sb.AppendLine(" where PLAN_DATE = '" + plan_date + "' ");
                            sb.AppendLine(" and PLAN_CD = '" + txt_plan_cd + "' ");
                            sb.AppendLine(" and SEQ = '" + p_half_dgv.Rows[i].Cells["H_SEQ"].Value + "'");
                        }
                    }
                }

                if (del_dgv.Rows.Count > 0)
                {
                    for (int i = 0; i < del_dgv.Rows.Count; i++)
                    {
                        sb.AppendLine("delete from F_PLAN_DETAIL ");
                        sb.AppendLine("    where PLAN_DATE = '" + del_dgv.Rows[i].Cells["PLAN_DATE"].Value + "' ");
                        sb.AppendLine("     and PLAN_CD = '" + del_dgv.Rows[i].Cells["PLAN_CD"].Value + "' ");
                        sb.AppendLine("     and SEQ = '" + del_dgv.Rows[i].Cells["SEQ"].Value + "' ");
                    }
                }
                if (del_half_dgv.Rows.Count > 0)
                {
                    for (int i = 0; i < del_half_dgv.Rows.Count; i++)
                    {
                        sb.AppendLine("delete from F_PLAN_DETAIL ");
                        sb.AppendLine("    where PLAN_DATE = '" + del_half_dgv.Rows[i].Cells["PLAN_DATE"].Value + "' ");
                        sb.AppendLine("     and PLAN_CD = '" + del_half_dgv.Rows[i].Cells["PLAN_CD"].Value + "' ");
                        sb.AppendLine("     and SEQ = '" + del_half_dgv.Rows[i].Cells["SEQ"].Value + "' ");
                    }
                }
                SqlCommand sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@CUST_CD", txt_cust_cd);
                sCommand.Parameters.AddWithValue("@DELIVER_REQ_DATE", deliver_req_date);
                sCommand.Parameters.AddWithValue("@ORDER_YN", order_yn);
                sCommand.Parameters.AddWithValue("@COMMENT", comment);

                sCommand.Parameters.AddWithValue("@PLAN_DATE", plan_date);
                sCommand.Parameters.AddWithValue("@PLAN_CD", txt_plan_cd);

                int qResult = wAdo.SqlCommandEtc(sCommand, "update_PLAN_TB");
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

        public int updateOrder(
              string order_date
            , string txt_order_cd
            , string txt_cust_cd
            , string in_req_date
            , string comment
            , string pur_yn
            , conDataGridView o_rm_dgv
            , DataGridView del_dgv)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb = new StringBuilder();
                sb.AppendLine("update F_ORDER set");
                sb.AppendLine("      CUST_CD = @CUST_CD ");
                sb.AppendLine("     ,INPUT_REQ_DATE = @INPUT_REQ_DATE ");
                sb.AppendLine("     ,COMPLETE_YN = '" + pur_yn + "' ");
                sb.AppendLine("     ,UPSTAFF = '" + Common.p_strStaffNo + "' ");
                sb.AppendLine("     ,UPTIME = convert(varchar, getdate(), 120) ");
                sb.AppendLine("     ,COMMENT = @COMMENT ");

                sb.AppendLine(" where ORDER_DATE = @ORDER_DATE and ORDER_CD= @ORDER_CD ");

                if (o_rm_dgv.Rows.Count > 0)
                {
                    for (int i = 0; i < o_rm_dgv.Rows.Count; i++)
                    {
                        string txt_seq = (string)o_rm_dgv.Rows[i].Cells["SEQ"].Value;
                        if (txt_seq == "" || txt_seq == null)
                        {
                            sb.AppendLine("declare @order_seq" + i + " int ");
                            sb.AppendLine("select @order_seq" + i + " =ISNULL(MAX(SEQ),0)+1 from F_ORDER_DETAIL ");
                            sb.AppendLine("where ORDER_DATE = '" + order_date + "' ");
                            sb.AppendLine("and ORDER_CD = '" + txt_order_cd + "' ");

                            sb.AppendLine("insert into F_ORDER_DETAIL(");
                            sb.AppendLine("     ORDER_DATE ");
                            sb.AppendLine("     ,ORDER_CD ");
                            sb.AppendLine("     ,SEQ ");
                            sb.AppendLine("     ,RAW_MAT_CD ");
                            sb.AppendLine("     ,UNIT_CD ");
                            sb.AppendLine("     ,TOTAL_AMT ");
                            sb.AppendLine("     ,PRICE ");
                            sb.AppendLine("     ,TOTAL_MONEY ");
                            sb.AppendLine("     ,INSTAFF ");
                            sb.AppendLine("     ,INTIME ");
                            sb.AppendLine("  )values ( ");
                            sb.AppendLine("     '" + order_date + "' ");
                            sb.AppendLine("     ,'" + txt_order_cd + "' ");
                            sb.AppendLine("     ,@order_seq" + i + " ");
                            sb.AppendLine("     ,'" + o_rm_dgv.Rows[i].Cells["RAW_MAT_CD"].Value + "' ");
                            sb.AppendLine("     ,'" + o_rm_dgv.Rows[i].Cells["UNIT_CD"].Value + "' ");
                            sb.AppendLine("     ,'" + ((string)o_rm_dgv.Rows[i].Cells["TOTAL_AMT"].Value).Replace(",", "") + "' ");
                            sb.AppendLine("     ,'" + ((string)o_rm_dgv.Rows[i].Cells["PRICE"].Value).Replace(",", "") + "' ");
                            sb.AppendLine("     ,'" + ((string)o_rm_dgv.Rows[i].Cells["TOTAL_MONEY"].Value).Replace(",", "") + "' ");
                            sb.AppendLine("     ,'" + Common.p_strStaffNo + "' ");
                            sb.AppendLine("     ,convert(varchar, getdate(), 120)  ");
                            sb.AppendLine("  )");
                        }
                        else
                        {
                            sb.AppendLine("update F_ORDER_DETAIL set");
                            sb.AppendLine("       RAW_MAT_CD =  '" + o_rm_dgv.Rows[i].Cells["RAW_MAT_CD"].Value + "' ");
                            sb.AppendLine("      ,TOTAL_AMT =  '" + ((string)o_rm_dgv.Rows[i].Cells["TOTAL_AMT"].Value).Replace(",", "") + "' ");
                            sb.AppendLine("      ,PRICE =  '" + ((string)o_rm_dgv.Rows[i].Cells["PRICE"].Value).Replace(",", "") + "' ");
                            sb.AppendLine("      ,TOTAL_MONEY =  '" + ((string)o_rm_dgv.Rows[i].Cells["TOTAL_MONEY"].Value).Replace(",", "") + "' ");
                            sb.AppendLine("      ,UPSTAFF =  '" + Common.p_strStaffNo + "' ");
                            sb.AppendLine("      ,UPTIME =  convert(varchar, getdate(), 120) ");
                            sb.AppendLine(" where ORDER_DATE = '" + order_date + "' ");
                            sb.AppendLine(" and ORDER_CD = '" + txt_order_cd + "' ");
                            sb.AppendLine(" and SEQ = '" + o_rm_dgv.Rows[i].Cells["SEQ"].Value + "'");
                        }
                    }
                }

                if (del_dgv.Rows.Count > 0)
                {
                    for (int i = 0; i < del_dgv.Rows.Count; i++)
                    {
                        sb.AppendLine("delete from F_ORDER_DETAIL ");
                        sb.AppendLine("    where ORDER_DATE = '" + del_dgv.Rows[i].Cells["ORDER_DATE"].Value + "' ");
                        sb.AppendLine("     and ORDER_CD = '" + del_dgv.Rows[i].Cells["ORDER_CD"].Value + "' ");
                        sb.AppendLine("     and SEQ = '" + del_dgv.Rows[i].Cells["SEQ"].Value + "' ");
                    }
                }
                SqlCommand sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@CUST_CD", txt_cust_cd);
                sCommand.Parameters.AddWithValue("@INPUT_REQ_DATE", in_req_date);
                sCommand.Parameters.AddWithValue("@COMMENT", comment);

                sCommand.Parameters.AddWithValue("@ORDER_DATE", order_date);
                sCommand.Parameters.AddWithValue("@ORDER_CD", txt_order_cd);

                int qResult = wAdo.SqlCommandEtc(sCommand, "update_PLAN_TB");
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

        public int updateRmInput(
              string input_date
            , string txt_input_cd
            , string txt_cust_cd
            , string comment
            , string input_yn
            , conDataGridView in_rm_dgv
            , DataGridView del_dgv)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                SqlCommand sCommand = new SqlCommand(sb.ToString());
                for (int i = 0; i < in_rm_dgv.Rows.Count; i++)
                {
                    if ((string)in_rm_dgv.Rows[i].Cells["ORDER_DATE"].Value != null && (string)in_rm_dgv.Rows[i].Cells["ORDER_DATE"].Value != "")
                    {
                        sb.AppendLine(" select A.ORDER_DATE,A.ORDER_CD,B.SEQ,C.ORDER_AMT, C.INPUT_AMT");
                        sb.AppendLine(" FROM F_ORDER A ");
                        sb.AppendLine(" LEFT OUTER JOIN F_ORDER_DETAIL B  ");
                        sb.AppendLine(" ON A.ORDER_DATE = B.ORDER_DATE ");
                        sb.AppendLine("     AND A.ORDER_CD = B.ORDER_CD ");
                        sb.AppendLine(" LEFT OUTER JOIN(	 ");
                        sb.AppendLine("                     SELECT AA.ORDER_DATE	 ");
                        sb.AppendLine("                           ,AA.ORDER_CD       ");
                        sb.AppendLine("                           ,AA.SEQ ");
                        sb.AppendLine("                           ,FLOOR(ISNULL(AA.TOTAL_AMT,0)) AS ORDER_AMT ");
                        sb.AppendLine("                           ,ISNULL(SUM(BB.TOTAL_AMT),0) AS INPUT_AMT ");
                        sb.AppendLine("                           , ISNULL(AA.TOTAL_AMT,0)-ISNULL(SUM(BB.TOTAL_AMT),0) AS NO_INPUT_AMT ");
                        sb.AppendLine("                     FROM F_ORDER_DETAIL AA ");
                        sb.AppendLine("                     LEFT OUTER JOIN F_RAW_DETAIL BB ");
                        sb.AppendLine("                     ON AA.ORDER_DATE = BB.ORDER_DATE ");
                        sb.AppendLine("                         AND AA.ORDER_CD = BB.ORDER_CD ");
                        sb.AppendLine("                         AND AA.SEQ = BB.ORDER_SEQ ");
                        sb.AppendLine("                     GROUP BY AA.ORDER_DATE,AA.ORDER_CD,AA.SEQ,AA.TOTAL_AMT)C ");
                        sb.AppendLine(" ON A.ORDER_DATE = C.ORDER_DATE  ");
                        sb.AppendLine("     AND A.ORDER_CD = C.ORDER_CD ");
                        sb.AppendLine("     AND B.SEQ = C.SEQ  ");
                        sb.AppendLine(" WHERE A.ORDER_DATE = '" + in_rm_dgv.Rows[i].Cells["ORDER_DATE"].Value + "' ");
                        sb.AppendLine("      AND A.ORDER_CD = '" + in_rm_dgv.Rows[i].Cells["ORDER_CD"].Value + "' ");
                        sb.AppendLine("      AND B.SEQ = '" + in_rm_dgv.Rows[i].Cells["ORDER_SEQ"].Value + "' ");

                        sCommand = new SqlCommand(sb.ToString());
                        if (sCommand.CommandText.Equals(null))
                        {
                            wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                            return 2;
                        }
                        DataTable dt = wAdo.SqlCommandSelect(sCommand);

                        double order_amt = double.Parse(dt.Rows[0]["ORDER_AMT"].ToString());
                        double input_amt = double.Parse(dt.Rows[0]["INPUT_AMT"].ToString());
                        double grd_total_amt = double.Parse(((string)in_rm_dgv.Rows[i].Cells["TOTAL_AMT"].Value).Replace(",", ""));
                        double grd_ord_total_amt = double.Parse(((string)in_rm_dgv.Rows[i].Cells["OLD_TOTAL_AMT"].Value)); //백업은 콤마 정의 안함

                        // 발주수량 + 입력하기 전 수량백업 값 - 입고수량 - 입력한 수량 값 = 결과값

                        double rs_num = order_amt + grd_ord_total_amt - input_amt - grd_total_amt;
                        if (rs_num < 0)
                        {
                            StringBuilder alert_sb = new StringBuilder();
                            alert_sb.AppendLine(i + 1 + "번째 줄 원부재료에 포함된 발주번호 \n ");
                            alert_sb.AppendLine(in_rm_dgv.Rows[i].Cells["ORDER_DATE"].Value + " [" + in_rm_dgv.Rows[i].Cells["ORDER_CD"].Value + "] 의 발주수량보다 더 많게 입력하셨습니다. \n");
                            alert_sb.AppendLine("그대로 저장하시겠습니까? (저장:예 / 취소:아니오)");

                            DialogResult msgOk = MessageBox.Show(alert_sb.ToString(), "삭제여부", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (msgOk == DialogResult.No)
                            {
                                return 3;
                            }
                        }
                    }
                }

                sb = new StringBuilder();
                sb.AppendLine("update F_RAW_INPUT set");
                sb.AppendLine("      CUST_CD = @CUST_CD ");
                sb.AppendLine("     ,COMPLETE_YN = '" + input_yn + "' ");
                sb.AppendLine("     ,UPSTAFF = '" + Common.p_strStaffNo + "' ");
                sb.AppendLine("     ,UPTIME = convert(varchar, getdate(), 120) ");
                sb.AppendLine("     ,COMMENT = @COMMENT ");

                sb.AppendLine(" where INPUT_DATE = @INPUT_DATE and INPUT_CD= @INPUT_CD ");

                if (in_rm_dgv.Rows.Count > 0)
                {
                    for (int i = 0; i < in_rm_dgv.Rows.Count; i++)
                    {
                        string txt_seq = (string)in_rm_dgv.Rows[i].Cells["SEQ"].Value;
                        if (txt_seq == "" || txt_seq == null)
                        {
                            sb.AppendLine("declare @input_seq" + i + " int, @chk_gbn" + i + "  nvarchar(1), @chk_yn" + i + " nvarchar(1), @final_amt" + i + " nvarchar(20) ");
                            sb.AppendLine("select @input_seq" + i + " =ISNULL(MAX(SEQ),0)+1 from F_RAW_DETAIL ");
                            sb.AppendLine("where INPUT_DATE = '" + input_date + "' ");
                            sb.AppendLine("and INPUT_CD = '" + txt_input_cd + "' ");

                            sb.AppendLine("select @chk_gbn" + i + " = check_gubun from N_RAW_CODE ");
                            sb.AppendLine("where RAW_MAT_CD = '" + in_rm_dgv.Rows[i].Cells["RAW_MAT_CD"].Value + "' ");

                            sb.AppendLine("IF @chk_gbn" + i + " = '1' BEGIN set @chk_yn" + i + " = 'S' set @final_amt" + i + " = '0' END "); //원자재 검사여부가 검사일 경우 'S' 대기 
                            sb.AppendLine("ELSE BEGIN set @chk_yn" + i + " = 'O' set @final_amt" + i + " = '" + ((string)in_rm_dgv.Rows[i].Cells["TOTAL_AMT"].Value).Replace(",", "") + "' END "); //원자재 검사여부가 생략일 경우 'O'

                            sb.AppendLine("insert into F_RAW_DETAIL(");
                            sb.AppendLine("     INPUT_DATE ");
                            sb.AppendLine("     ,INPUT_CD ");
                            sb.AppendLine("     ,SEQ ");
                            sb.AppendLine("     ,RAW_MAT_CD ");
                            sb.AppendLine("     ,UNIT_CD ");
                            sb.AppendLine("     ,TEMP_AMT ");
                            sb.AppendLine("     ,TOTAL_AMT ");
                            sb.AppendLine("     ,CURR_AMT ");
                            sb.AppendLine("     ,PRICE ");
                            sb.AppendLine("     ,TOTAL_MONEY ");
                            sb.AppendLine("     ,HEAT_NO ");
                            sb.AppendLine("     ,HEAT_TIME ");
                            sb.AppendLine("     ,ORDER_DATE ");
                            sb.AppendLine("     ,ORDER_CD ");
                            sb.AppendLine("     ,ORDER_SEQ ");
                            sb.AppendLine("     ,COMPLETE_YN ");
                            sb.AppendLine("     ,CHECK_YN ");
                            sb.AppendLine("     ,INSTAFF ");
                            sb.AppendLine("     ,INTIME ");
                            sb.AppendLine("  )values ( ");
                            sb.AppendLine("     '" + input_date + "' ");
                            sb.AppendLine("      ,'" + txt_input_cd + "'  ");
                            sb.AppendLine("     ,@input_seq" + i + " ");
                            sb.AppendLine("     ,'" + in_rm_dgv.Rows[i].Cells["RAW_MAT_CD"].Value + "' ");
                            sb.AppendLine("     ,'" + in_rm_dgv.Rows[i].Cells["UNIT_CD"].Value + "' ");
                            sb.AppendLine("     ,'" + ((string)in_rm_dgv.Rows[i].Cells["TOTAL_AMT"].Value).Replace(",", "") + "' ");
                            sb.AppendLine("     ,@final_amt" + i + " ");
                            sb.AppendLine("     ,@final_amt" + i + " ");
                            sb.AppendLine("     ,'" + ((string)in_rm_dgv.Rows[i].Cells["PRICE"].Value).Replace(",", "") + "' ");
                            sb.AppendLine("     ,'" + ((string)in_rm_dgv.Rows[i].Cells["TOTAL_MONEY"].Value).Replace(",", "") + "' ");
                            sb.AppendLine("     ,'" + in_rm_dgv.Rows[i].Cells["HEAT_NO"].Value + "' ");
                            sb.AppendLine("     ,'" + in_rm_dgv.Rows[i].Cells["HEAT_TIME"].Value + "' ");
                            sb.AppendLine("     ,'" + in_rm_dgv.Rows[i].Cells["ORDER_DATE"].Value + "' ");
                            sb.AppendLine("     ,'" + in_rm_dgv.Rows[i].Cells["ORDER_CD"].Value + "' ");
                            sb.AppendLine("     ,'" + in_rm_dgv.Rows[i].Cells["ORDER_SEQ"].Value + "' ");
                            sb.AppendLine("     ,'N' ");
                            sb.AppendLine("     ,@chk_yn" + i + " ");
                            sb.AppendLine("     ,'" + Common.p_strStaffNo + "' ");
                            sb.AppendLine("     ,convert(varchar, getdate(), 120)  ");

                            sb.AppendLine("  )");
                        }
                        else
                        {
                            sb.AppendLine("update F_RAW_DETAIL set");
                            sb.AppendLine("       TEMP_AMT =  '" + ((string)in_rm_dgv.Rows[i].Cells["TOTAL_AMT"].Value).Replace(",", "") + "' ");
                            sb.AppendLine("      ,PRICE =  '" + ((string)in_rm_dgv.Rows[i].Cells["PRICE"].Value).Replace(",", "") + "' ");
                            sb.AppendLine("      ,TOTAL_MONEY =  '" + ((string)in_rm_dgv.Rows[i].Cells["TOTAL_MONEY"].Value).Replace(",", "") + "' ");
                            sb.AppendLine("      ,HEAT_NO =  '" + in_rm_dgv.Rows[i].Cells["HEAT_NO"].Value + "' ");
                            sb.AppendLine("      ,HEAT_TIME =  '" + in_rm_dgv.Rows[i].Cells["HEAT_TIME"].Value + "' ");
                            sb.AppendLine("      ,UPSTAFF =  '" + Common.p_strStaffNo + "' ");
                            sb.AppendLine("      ,UPTIME =  convert(varchar, getdate(), 120) ");
                            sb.AppendLine(" where INPUT_DATE = '" + input_date + "' ");
                            sb.AppendLine(" and INPUT_CD = '" + txt_input_cd + "' ");
                            sb.AppendLine(" and SEQ = '" + in_rm_dgv.Rows[i].Cells["SEQ"].Value + "'");
                        }
                    }
                }

                if (del_dgv.Rows.Count > 0)
                {
                    for (int i = 0; i < del_dgv.Rows.Count; i++)
                    {
                        sb.AppendLine("delete from F_RAW_DETAIL ");
                        sb.AppendLine("    where INPUT_DATE = '" + input_date + "' ");
                        sb.AppendLine("     and INPUT_CD = '" + txt_input_cd + "' ");
                        sb.AppendLine("     and SEQ = '" + del_dgv.Rows[i].Cells["SEQ"].Value + "' ");
                    }
                }

                sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@CUST_CD", txt_cust_cd);
                sCommand.Parameters.AddWithValue("@COMMENT", comment);

                sCommand.Parameters.AddWithValue("@INPUT_DATE", input_date);
                sCommand.Parameters.AddWithValue("@INPUT_CD", txt_input_cd);

                int qResult = wAdo.SqlCommandEtc(sCommand, "update_INPUT_TB");
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

        public int updateStRaw(conDataGridView dgv)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    sb.AppendLine("update N_RAW_CODE set ");
                    sb.AppendLine("      BAL_STOCK = (select	  ");
                    sb.AppendLine("                         ISNULL((");
                    sb.AppendLine("                             select SUM(ISNULL(TOTAL_AMT,0)) from F_RAW_DETAIL ");
                    sb.AppendLine("                             where RAW_MAT_CD = '" + dgv.Rows[i].Cells["RAW_MAT_CD"].Value + "'  ");
                    sb.AppendLine("                                 and (CHECK_YN = 'Y' or CHECK_YN = 'O') ");
                    sb.AppendLine("                     group by RAW_MAT_CD),0)  ");
                    sb.AppendLine("                    -  ");
                    sb.AppendLine("                     ISNULL((  ");
                    sb.AppendLine("                     select SUM(ISNULL(TOTAL_AMT,0)) from F_RAW_OUTPUT ");
                    sb.AppendLine("                     where RAW_MAT_CD = '" + dgv.Rows[i].Cells["RAW_MAT_CD"].Value + "'   ");
                    sb.AppendLine("                     group by RAW_MAT_CD),0))");
                    sb.AppendLine("where RAW_MAT_CD = '" + dgv.Rows[i].Cells["RAW_MAT_CD"].Value + "' ");
                }

                SqlCommand sCommand = new SqlCommand(sb.ToString());

                int qResult = wAdo.SqlCommandEtc(sCommand, "update_RAW_STOCK_TB");
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

        public int updateWork(
              string work_date
            , string txt_work_cd
            , string txt_lot_no
            , string txt_item_cd
            , string txt_cust_cd
            , string txt_inst_amt
            , string deliver_req_date
            , string cmb_line
            , string cmb_worker
            , string txt_plan_num
            , string txt_plan_item
            , string txt_inst_notice
            , conDataGridView w_rm_dgv
            , DataGridView w_half_dgv
            , DataGridView del_dgv)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                //sb.AppendLine(" select * ");
                //sb.AppendLine(" from F_PLAN A ");
                //sb.AppendLine(" left outer join F_PLAN_GROUP B  ");
                //sb.AppendLine(" on A.PLAN_DATE = B.PLAN_DATE ");
                //sb.AppendLine("     and A.PLAN_CD = B.PLAN_CD  ");
                //sb.AppendLine(" where A.PLAN_NUM = '" + txt_plan_num + "' 	 ");
                //sb.AppendLine("     and B.ITEM_CD = '" + txt_plan_item + "' ");
                //sb.AppendLine("     and B.WORK_YN = 'Y'       ");

                sb.AppendLine(" select * ");
                sb.AppendLine(" from F_WORK_FLOW ");
                sb.AppendLine(" where LOT_NO = '" + txt_lot_no + "' ");

                SqlCommand sCommand = new SqlCommand(sb.ToString());

                if (sCommand.CommandText.Equals(null))
                {
                    wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                    return 2;
                }
                DataTable dt = wAdo.SqlCommandSelect(sCommand);

                if (dt != null && dt.Rows.Count > 0)
                {
                    return 3;
                }

                sb = new StringBuilder();

                sb.AppendLine("update F_WORK_INST set");
                sb.AppendLine("      LOT_NO = @LOT_NO ");
                sb.AppendLine("     ,ITEM_CD = @ITEM_CD ");
                sb.AppendLine("     ,CUST_CD = @CUST_CD ");
                sb.AppendLine("     ,INST_AMT = @INST_AMT ");
                sb.AppendLine("     ,DELIVERY_DATE = @DELIVERY_DATE ");
                sb.AppendLine("     ,LINE_CD = @LINE_CD ");
                sb.AppendLine("     ,WORKER_CD = @WORKER_CD");
                sb.AppendLine("     ,INST_NOTICE = @INST_NOTICE ");
                sb.AppendLine("     ,UPSTAFF = '" + Common.p_strStaffNo + "' ");
                sb.AppendLine("     ,UPTIME = convert(varchar, getdate(), 120) ");
                sb.AppendLine("where W_INST_DATE = '" + work_date + "' and W_INST_CD = '" + txt_work_cd + "' ");

                if (w_rm_dgv.Rows.Count > 0)
                {
                    for (int i = 0; i < w_rm_dgv.Rows.Count; i++)
                    {
                        string txt_seq = (string)w_rm_dgv.Rows[i].Cells["SEQ"].Value;
                        if (txt_seq == "" || txt_seq == null)
                        {
                            sb.AppendLine("declare @work_seq" + i + " int ");
                            sb.AppendLine("select @work_seq" + i + " =ISNULL(MAX(SEQ),0)+1 from F_WORK_INST_DETAIL ");
                            sb.AppendLine("where W_INST_DATE = '" + work_date + "' ");
                            sb.AppendLine("and W_INST_CD = '" + txt_work_cd + "' ");

                            sb.AppendLine("insert into F_WORK_INST_DETAIL(");
                            sb.AppendLine("     W_INST_DATE ");
                            sb.AppendLine("     ,W_INST_CD ");
                            sb.AppendLine("     ,SEQ ");
                            sb.AppendLine("     ,LOT_NO ");
                            sb.AppendLine("     ,RAW_MAT_CD ");
                            sb.AppendLine("     ,SOYO_AMT ");
                            sb.AppendLine("     ,TOTAL_AMT ");
                            sb.AppendLine("     ,INSTAFF");
                            sb.AppendLine("     ,INTIME");
                            sb.AppendLine("  )values ( ");
                            sb.AppendLine("     '" + work_date + "' ");
                            sb.AppendLine("     ,'" + txt_work_cd + "' ");
                            sb.AppendLine("     ,@work_seq" + i + " ");
                            sb.AppendLine("     ,'" + txt_lot_no + "' ");
                            sb.AppendLine("     ,'" + ((string)w_rm_dgv.Rows[i].Cells["RAW_MAT_CD"].Value).Replace(",", "") + "' ");
                            sb.AppendLine("     ,'" + ((string)w_rm_dgv.Rows[i].Cells["SOYO_AMT"].Value).Replace(",", "") + "' ");
                            sb.AppendLine("     ,'" + ((string)w_rm_dgv.Rows[i].Cells["TOTAL_SOYO_AMT"].Value).Replace(",", "") + "' ");
                            sb.AppendLine("     ,'" + Common.p_strStaffNo + "' ");
                            sb.AppendLine("     ,convert(varchar, getdate(), 120) ");

                            sb.AppendLine("  )");
                        }
                        else
                        {
                            sb.AppendLine("update F_WORK_INST_DETAIL set");
                            sb.AppendLine("       SOYO_AMT =  '" + ((string)w_rm_dgv.Rows[i].Cells["SOYO_AMT"].Value).Replace(",", "") + "' ");
                            sb.AppendLine("      ,TOTAL_AMT =  '" + ((string)w_rm_dgv.Rows[i].Cells["TOTAL_SOYO_AMT"].Value).Replace(",", "") + "' ");
                            sb.AppendLine("      ,UPSTAFF =  '" + Common.p_strStaffNo + "' ");
                            sb.AppendLine("      ,UPTIME =  convert(varchar, getdate(), 120) ");
                            sb.AppendLine(" where W_INST_DATE = '" + work_date + "' ");
                            sb.AppendLine(" and W_INST_CD = '" + txt_work_cd + "' ");
                            sb.AppendLine(" and SEQ = '" + w_rm_dgv.Rows[i].Cells["SEQ"].Value + "'");
                        }
                    }
                }

                if (w_half_dgv.Rows.Count > 0)
                {
                    for (int i = 0; i < w_half_dgv.Rows.Count; i++)
                    {
                        sb.AppendLine("update F_WORK_INST_HALF_DETAIL set");
                        sb.AppendLine("       SOYO_AMT =  '" + ((string)w_half_dgv.Rows[i].Cells["H_SOYO_AMT"].Value).Replace(",", "") + "' ");
                        sb.AppendLine("      ,TOTAL_AMT =  '" + ((string)w_half_dgv.Rows[i].Cells["H_TOTAL_SOYO_AMT"].Value).Replace(",", "") + "' ");
                        sb.AppendLine("      ,UPSTAFF =  '" + Common.p_strStaffNo + "' ");
                        sb.AppendLine("      ,UPTIME =  convert(varchar, getdate(), 120) ");
                        sb.AppendLine(" where W_INST_DATE = '" + work_date + "' ");
                        sb.AppendLine(" and W_INST_CD = '" + txt_work_cd + "' ");
                        sb.AppendLine(" and SEQ = '" + w_half_dgv.Rows[i].Cells["H_SEQ"].Value + "'");
                    }
                }

                if (del_dgv.Rows.Count > 0)
                {
                    for (int i = 0; i < del_dgv.Rows.Count; i++)
                    {
                        sb.AppendLine("delete from F_WORK_INST_DETAIL ");
                        sb.AppendLine("    where W_INST_DATE = '" + work_date + "' ");
                        sb.AppendLine("     and W_INST_CD = '" + txt_work_cd + "' ");
                        sb.AppendLine("     and SEQ = '" + del_dgv.Rows[i].Cells["SEQ"].Value + "' ");
                    }
                }

                sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@W_INST_DATE", work_date);
                sCommand.Parameters.AddWithValue("@LOT_NO", txt_lot_no);
                sCommand.Parameters.AddWithValue("@ITEM_CD", txt_item_cd);
                sCommand.Parameters.AddWithValue("@CUST_CD", txt_cust_cd);
                sCommand.Parameters.AddWithValue("@INST_AMT", txt_inst_amt);
                sCommand.Parameters.AddWithValue("@DELIVERY_DATE", deliver_req_date);
                sCommand.Parameters.AddWithValue("@LINE_CD", cmb_line);
                sCommand.Parameters.AddWithValue("@WORKER_CD", cmb_worker);
                sCommand.Parameters.AddWithValue("@INST_NOTICE", txt_inst_notice);
                int qResult = wAdo.SqlCommandEtc(sCommand, "insert_WORK_TB");
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

        public int update_Work_Flow(
              string txt_lot_no
            , string txt_item_cd
            , conDataGridView[] dgv
            , Label[] lbl_flow_cd
            , Label[] lbl_flow_seq
            , Label[] lbl_item_iden
            , int flow_cnt)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();
                string flow_date = DateTime.Today.ToString("yyyy-MM-dd");
                sb = new StringBuilder();

                sb.AppendLine("update F_WORK_FLOW set");
                sb.AppendLine("       UPSTAFF = '" + Common.p_strStaffNo + "' ");
                sb.AppendLine("      ,UPTIME = convert(varchar, getdate(), 120) ");
                sb.AppendLine("where LOT_NO = '" + txt_lot_no + "' ");

                for (int i = 0; i < flow_cnt; i++) //제품 공정 마지막 단계까지 ..  
                {
                    if (dgv[i].Rows.Count > 0)
                    {
                        for (int j = 0; j < dgv[i].Rows.Count; j++)
                        {
                            string txt_f_step = (string)dgv[i].Rows[j].Cells[7].Value;
                            if (txt_f_step == "" || txt_f_step == null)
                            {
                                sb.AppendLine("insert into F_WORK_FLOW_DETAIL(");
                                sb.AppendLine("      LOT_NO ");
                                sb.AppendLine("      ,LOT_SUB ");
                                sb.AppendLine("      ,F_STEP ");
                                sb.AppendLine("      ,FLOW_CD ");
                                sb.AppendLine("      ,SEQ ");
                                sb.AppendLine("      ,F_SUB_DATE ");
                                sb.AppendLine("      ,F_SUB_AMT ");
                                sb.AppendLine("      ,LOSS ");
                                sb.AppendLine("      ,POOR_CD ");
                                sb.AppendLine("      ,POOR_AMT ");
                                sb.AppendLine("      ,COMPLETE_YN ");
                                sb.AppendLine("      ,CHECK_YN ");
                                sb.AppendLine("      ,ITEM_CHECK_YN ");
                                sb.AppendLine("      ,INSTAFF ");
                                sb.AppendLine("      ,INTIME ");
                                sb.AppendLine("      ,COMMENT ");
                                sb.AppendLine(" ) values ( ");
                                sb.AppendLine("      '" + (string)dgv[i].Rows[j].Cells[0].Value + "' ");
                                sb.AppendLine("      , '" + (string)dgv[i].Rows[j].Cells[1].Value + "' ");
                                sb.AppendLine("      , '" + (i + 1) + "' ");
                                sb.AppendLine("      , '" + lbl_flow_cd[i].Text.ToString() + "' ");
                                sb.AppendLine("      , '" + lbl_flow_seq[i].Text.ToString() + "' ");
                                sb.AppendLine("      , '" + (string)dgv[i].Rows[j].Cells[2].Value + "' ");
                                sb.AppendLine("      , '" + ((string)dgv[i].Rows[j].Cells[3].Value).Replace(",", "") + "' ");
                                sb.AppendLine("      , '" + ((string)dgv[i].Rows[j].Cells[4].Value).Replace(",", "") + "' ");
                                if (dgv[i].Rows[j].Cells[5].Value == null)
                                {
                                    dgv[i].Rows[j].Cells[5].Value = "";
                                }
                                sb.AppendLine("      , '" + (string)dgv[i].Rows[j].Cells[5].Value + "' "); //POOR_CD
                                sb.AppendLine("      , '" + ((string)dgv[i].Rows[j].Cells[6].Value).Replace(",", "") + "' "); //POOR_AMT
                                sb.AppendLine("      , 'N' ");
                                sb.AppendLine("      , 'S' "); //S-> 대기 
                                sb.AppendLine("      , 'S' "); //S-> 대기 
                                //sb.AppendLine("      , (select FLOW_CHK_YN from N_FLOW_CODE where FLOW_CD = '" + lbl_flow_cd[i].Text.ToString() + "') ");
                                sb.AppendLine("      , '" + Common.p_strStaffNo + "' ");
                                sb.AppendLine("      , convert(varchar, getdate(), 120) ");
                                sb.AppendLine("      ,'' ");
                                sb.AppendLine("      ) ");
                            }
                            else
                            {
                                sb.AppendLine("update F_WORK_FLOW_DETAIL set");
                                sb.AppendLine("       F_SUB_DATE = '" + (string)dgv[i].Rows[j].Cells[2].Value + "' ");
                                sb.AppendLine("      ,F_SUB_AMT = '" + ((string)dgv[i].Rows[j].Cells[3].Value).Replace(",", "") + "' ");
                                sb.AppendLine("      ,LOSS = '" + ((string)dgv[i].Rows[j].Cells[4].Value).Replace(",", "") + "' ");
                                if (dgv[i].Rows[j].Cells[5].Value == null)
                                {
                                    dgv[i].Rows[j].Cells[5].Value = "";
                                }
                                sb.AppendLine("      ,POOR_CD = '" + (string)dgv[i].Rows[j].Cells[5].Value + "' ");
                                sb.AppendLine("      ,POOR_AMT = '" + ((string)dgv[i].Rows[j].Cells[6].Value).Replace(",", "") + "' "); //POOR_AMT
                                //sb.AppendLine("      ,CHECK_YN = (select FLOW_CHK_YN from N_FLOW_CODE where FLOW_CD = '" + lbl_flow_cd[i].Text.ToString() + "') ");
                                sb.AppendLine("      ,UPSTAFF = '" + Common.p_strStaffNo + "' ");
                                sb.AppendLine("      ,UPTIME = convert(varchar, getdate(), 120) ");
                                sb.AppendLine("where LOT_NO = '" + txt_lot_no + "' ");
                                sb.AppendLine(" and LOT_SUB = '" + (string)dgv[i].Rows[j].Cells[1].Value + "' ");
                                sb.AppendLine(" and F_STEP = '" + (i + 1) + "' ");
                            }
                        }
                    }
                }

                bool chk = false;
                int input_amt = 0;
                for (int i = 0; i < flow_cnt; i++)
                {
                    if (lbl_item_iden[i].Text.ToString().Equals("Y"))
                    {
                        chk = true;
                        break;
                    }

                }

                if (chk)  //제품식별표가 Y
                {
                    string item_date = flow_date;
                    for (int i = 0; i < dgv[flow_cnt - 1].Rows.Count; i++)
                    {
                        sb.AppendLine("declare @seq" + i + " int ");
                        sb.AppendLine("select @seq" + i + " =ISNULL(MAX(INPUT_CD),0)+1 from F_ITEM_INPUT ");
                        sb.AppendLine("where INPUT_DATE = '" + item_date + "' ");

                        sb.AppendLine("declare @chk" + i + " int ");
                        sb.AppendLine("select @chk" + i + " =count(*) from F_ITEM_INPUT ");
                        sb.AppendLine("where LOT_NO = '" + txt_lot_no + "' ");
                        sb.AppendLine("     and LOT_SUB = '" + (string)dgv[flow_cnt - 1].Rows[i].Cells[1].Value + "' ");

                        sb.AppendLine("IF(@chk" + i + " = 0)");
                        sb.AppendLine("     insert into F_ITEM_INPUT(");
                        sb.AppendLine("         INPUT_DATE ");
                        sb.AppendLine("         ,INPUT_CD ");
                        sb.AppendLine("         ,ITEM_CD ");
                        sb.AppendLine("         ,LOT_NO ");
                        sb.AppendLine("         ,LOT_SUB ");
                        sb.AppendLine("         ,F_STEP ");
                        sb.AppendLine("         ,FLOW_CD ");
                        sb.AppendLine("         ,INPUT_AMT ");
                        sb.AppendLine("         ,INSTAFF ");
                        sb.AppendLine("         ,INTIME ");
                        sb.AppendLine("         ,CURR_AMT ");
                        sb.AppendLine("         ,COMPLETE_YN ");
                        sb.AppendLine("     ) values ( ");
                        sb.AppendLine("         '" + item_date + "' ");
                        sb.AppendLine("         ,@seq" + i + " ");
                        sb.AppendLine("         , '" + txt_item_cd + "' ");
                        sb.AppendLine("         , '" + txt_lot_no + "' ");
                        sb.AppendLine("         , '" + (string)dgv[flow_cnt - 1].Rows[i].Cells[1].Value + "' ");
                        sb.AppendLine("         , '" + (flow_cnt).ToString() + "' "); //f_step
                        sb.AppendLine("         , '" + lbl_flow_cd[flow_cnt - 1].Text.ToString() + "' "); //flow_cd
                        sb.AppendLine("         , '" + ((string)dgv[flow_cnt - 1].Rows[i].Cells[3].Value).Replace(",", "") + "' ");
                        //sb.AppendLine("         ," + input_amt + " ");
                        sb.AppendLine("         , '" + Common.p_strStaffNo + "' ");
                        sb.AppendLine("         , convert(varchar, getdate(), 120) ");
                        sb.AppendLine("         , '" + ((string)dgv[flow_cnt - 1].Rows[i].Cells[3].Value).Replace(",", "") + "' ");
                        sb.AppendLine("         , 'N'");
                        sb.AppendLine("      ) ");
                        sb.AppendLine("ELSE ");
                        sb.AppendLine("     update F_ITEM_INPUT ");
                        sb.AppendLine("     set INPUT_AMT = '" + ((string)dgv[flow_cnt - 1].Rows[i].Cells[3].Value).Replace(",", "") + "' ");
                        sb.AppendLine("         ,F_STEP = '" + (flow_cnt).ToString() + "', FLOW_CD = '" + lbl_flow_cd[flow_cnt - 1].Text.ToString() + "' ");
                        sb.AppendLine("     where LOT_NO = '" + txt_lot_no + "' ");
                        sb.AppendLine("     and LOT_SUB = '" + (string)dgv[flow_cnt - 1].Rows[i].Cells[1].Value + "' ");

                        //input_amt += int.Parse(((string)dgv[flow_cnt - 1].Rows[i].Cells[3].Value).Replace(",", ""));
                    }

                    //string item_date = flow_date;

                    //sb.AppendLine("declare @seq int ");
                    //sb.AppendLine("select @seq =ISNULL(MAX(INPUT_CD),0)+1 from F_ITEM_INPUT ");
                    //sb.AppendLine("where INPUT_DATE = '" + item_date + "' ");

                    //sb.AppendLine("declare @chk int ");
                    //sb.AppendLine("select @chk =count(*) from F_ITEM_INPUT ");
                    //sb.AppendLine("where LOT_NO = '" + txt_lot_no + "' ");

                    //sb.AppendLine("IF(@chk = 0)");
                    //sb.AppendLine("     insert into F_ITEM_INPUT(");
                    //sb.AppendLine("         INPUT_DATE ");
                    //sb.AppendLine("         ,INPUT_CD ");
                    //sb.AppendLine("         ,ITEM_CD ");
                    //sb.AppendLine("         ,LOT_NO ");
                    //sb.AppendLine("         ,INPUT_AMT ");
                    //sb.AppendLine("         ,INSTAFF ");
                    //sb.AppendLine("         ,INTIME ");
                    //sb.AppendLine("     ) values ( ");
                    //sb.AppendLine("         '" + item_date + "' ");
                    //sb.AppendLine("         ,@seq ");
                    //sb.AppendLine("         ,'" + txt_item_cd + "' ");
                    //sb.AppendLine("         ,'" + txt_lot_no + "' ");
                    //sb.AppendLine("         ," + input_amt + " ");
                    //sb.AppendLine("         , '" + Common.p_strStaffNo + "' ");
                    //sb.AppendLine("         , convert(varchar, getdate(), 120) ");
                    //sb.AppendLine("      ) ");
                    //sb.AppendLine("ELSE ");
                    //sb.AppendLine("     update F_ITEM_INPUT ");
                    //sb.AppendLine("     set INPUT_AMT = " + input_amt + " ");
                    //sb.AppendLine("     where LOT_NO = '" + txt_lot_no +"' ");

                }
                SqlCommand sCommand = new SqlCommand(sb.ToString());

                int qResult = wAdo.SqlCommandEtc(sCommand, "update_F_WORK_FLOW_TB");
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

        public int update_Work_Flow_Complete(string txt_lot_no, double poor_cnt)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();
                string flow_date = DateTime.Today.ToString("yyyy-MM-dd");
                sb = new StringBuilder();

                sb.AppendLine("update F_WORK_FLOW set");
                sb.AppendLine("       COMPLETE_YN = 'Y' ");
                sb.AppendLine("where LOT_NO = '" + txt_lot_no + "' ");

                sb.AppendLine("update F_WORK_FLOW_DETAIL set");
                sb.AppendLine("       COMPLETE_YN = 'Y' ");
                sb.AppendLine("where LOT_NO = '" + txt_lot_no + "' ");

                sb.AppendLine("update F_WORK_INST set");
                sb.AppendLine("       COMPLETE_YN = 'Y' ");
                sb.AppendLine("where LOT_NO = '" + txt_lot_no + "' ");

                //불량 작업지시서 
                if (poor_cnt > 0)
                {
                    string curr_lot_no = flow_date.ToString().Replace("-", "");
                    curr_lot_no = curr_lot_no.Substring(2).ToString();


                    sb.AppendLine(" declare @seq int ");
                    sb.AppendLine(" select @seq = ISNULL(MAX(W_INST_CD),0)+1 from F_WORK_INST ");
                    sb.AppendLine(" where W_INST_DATE = '" + flow_date + "' ");

                    sb.AppendLine(" insert into F_WORK_INST(");
                    sb.AppendLine("         W_INST_DATE ");
                    sb.AppendLine("        ,W_INST_CD ");
                    sb.AppendLine("        ,LOT_NO ");
                    sb.AppendLine("        ,ITEM_CD ");
                    sb.AppendLine("        ,CUST_CD ");
                    sb.AppendLine("        ,INST_AMT ");
                    sb.AppendLine("        ,COMPLETE_YN ");
                    sb.AppendLine("        ,DELIVERY_DATE ");
                    sb.AppendLine("        ,PLAN_NUM ");
                    sb.AppendLine("        ,PLAN_ITEM ");
                    sb.AppendLine("        ,CHARGE_AMT ");
                    sb.AppendLine("        ,PACK_AMT ");
                    sb.AppendLine("        ,RAW_OUT_YN ");
                    sb.AppendLine("        ,POOR_WORK_YN ");
                    sb.AppendLine("        ,TOP_LOT_NO ");
                    sb.AppendLine("        ,INSTAFF ");
                    sb.AppendLine("        ,INTIME ");
                    sb.AppendLine("        )");

                    sb.AppendLine(" select '" + flow_date + "' ");

                    sb.AppendLine("        ,@seq      ");
                    sb.AppendLine("        ,'" + curr_lot_no + "'+RIGHT('000'+ convert(varchar, @seq), 4) ");
                    sb.AppendLine("        ,ITEM_CD      ");
                    sb.AppendLine("        ,CUST_CD ");
                    sb.AppendLine("        ," + poor_cnt + " ");
                    sb.AppendLine("        ,'N' ");
                    sb.AppendLine("        ,DELIVERY_DATE ");
                    sb.AppendLine("        ,PLAN_NUM ");
                    sb.AppendLine("        ,PLAN_ITEM ");
                    sb.AppendLine("        ,CHARGE_AMT ");
                    sb.AppendLine("        ,PACK_AMT ");
                    sb.AppendLine("        ,'Y' ");
                    sb.AppendLine("        ,'Y' ");
                    sb.AppendLine("        ,'" + txt_lot_no + "' ");
                    sb.AppendLine("         , '" + Common.p_strStaffNo + "' ");
                    sb.AppendLine("         , convert(varchar, getdate(), 120) ");
                    sb.AppendLine(" from F_WORK_INST ");
                    sb.AppendLine(" where LOT_NO ='" + txt_lot_no + "' ");

                    //작업지시 상세 내역 

                    sb.AppendLine(" insert into F_WORK_INST_DETAIL(");
                    sb.AppendLine("         W_INST_DATE ");
                    sb.AppendLine("        ,W_INST_CD ");
                    sb.AppendLine("        ,SEQ ");
                    sb.AppendLine("        ,LOT_NO ");
                    sb.AppendLine("        ,RAW_MAT_CD ");
                    sb.AppendLine("        ,SOYO_AMT ");
                    sb.AppendLine("        ,TOTAL_AMT ");
                    sb.AppendLine("        ,INSTAFF ");
                    sb.AppendLine("        ,INTIME ");
                    sb.AppendLine("        ) ");

                    sb.AppendLine(" select '" + flow_date + "' ");
                    sb.AppendLine("        ,@seq      ");
                    sb.AppendLine("        ,SEQ      ");
                    sb.AppendLine("        ,'" + curr_lot_no + "'+RIGHT('000'+ convert(varchar, @seq), 4) ");
                    sb.AppendLine("        ,RAW_MAT_CD ");
                    sb.AppendLine("        ,SOYO_AMT ");
                    sb.AppendLine("        ," + poor_cnt + " * SOYO_AMT");
                    sb.AppendLine("         , '" + Common.p_strStaffNo + "' ");
                    sb.AppendLine("         , convert(varchar, getdate(), 120) ");
                    sb.AppendLine(" from F_WORK_INST_DETAIL ");
                    sb.AppendLine(" where LOT_NO ='" + txt_lot_no + "' ");

                    sb.AppendLine(" declare @chk int ");
                    sb.AppendLine(" select @chk =count(*) from F_WORK_INST_HALF_DETAIL  ");
                    sb.AppendLine(" where LOT_NO ='" + txt_lot_no + "' ");

                    sb.AppendLine(" IF(@chk > 0) ");
                    sb.AppendLine(" insert into F_WORK_INST_HALF_DETAIL(W_INST_DATE,W_INST_CD,SEQ,LOT_NO,HALF_ITEM_CD,SOYO_AMT,TOTAL_AMT,INSTAFF,INTIME) ");
                    sb.AppendLine(" select '" + flow_date + "' ");
                    sb.AppendLine("        ,@seq ");
                    sb.AppendLine("        ,SEQ ");
                    sb.AppendLine("        ,'" + curr_lot_no + "'+RIGHT('000'+ convert(varchar, @seq), 4) ");
                    sb.AppendLine("        ,HALF_ITEM_CD ");
                    sb.AppendLine("        ,SOYO_AMT ");
                    sb.AppendLine("        ," + poor_cnt + " * SOYO_AMT");
                    sb.AppendLine("         , '" + Common.p_strStaffNo + "' ");
                    sb.AppendLine("         , convert(varchar, getdate(), 120) ");
                    sb.AppendLine(" from F_WORK_INST_HALF_DETAIL ");
                    sb.AppendLine(" where LOT_NO ='" + txt_lot_no + "' ");
                }

                SqlCommand sCommand = new SqlCommand(sb.ToString());

                int qResult = wAdo.SqlCommandEtc(sCommand, "update_F_WORK_FLOW_COMPLETE_TB");
                if (qResult > 0)
                {
                    return 0;  // 0 true, 1 false
                }
                else return 1;
            }
            catch (Exception e)
            {
                Console.WriteLine("error" + e.ToString());
                return 9;
            }
        }

        public int update_Work_Raw_Out_Yn(string txt_lot_no)  //condition = 현황 , dt = detail
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();
                sb = new StringBuilder();

                sb.AppendLine("update F_WORK_INST set");
                sb.AppendLine("       RAW_OUT_YN = 'Y' ");
                sb.AppendLine("where LOT_NO = '" + txt_lot_no + "' ");

                SqlCommand sCommand = new SqlCommand(sb.ToString());

                int qResult = wAdo.SqlCommandEtc(sCommand, "update_WORK_INST_RAW_OUT");
                if (qResult > 0)
                {
                    return 0;  // 0 true, 1 false
                }
                else return 1;
            }
            catch (Exception e)
            {
                Console.WriteLine("error" + e.ToString());
                return 9;
            }
        }        

        /*
        public int updateItemOut(
              string out_date
            , string out_cd
            , string jang_cd
            , conDataGridView item_out_dgv
            , DataTable del_dgv)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                SqlCommand sCommand = new SqlCommand(sb.ToString());

                sb = new StringBuilder();
                sb.AppendLine("update F_ITEM_OUT set");
                sb.AppendLine("      UPSTAFF = '" + Common.p_strStaffNo + "' ");
                sb.AppendLine("     ,UPTIME = convert(varchar, getdate(), 120) ");

                sb.AppendLine(" where OUTPUT_DATE = '" + out_date + "' and OUTPUT_CD= '" + out_cd + "' ");

                if (item_out_dgv.Rows.Count > 0)
                {
                    for (int i = 0; i < item_out_dgv.Rows.Count; i++)
                    {
                        string txt_seq = (string)item_out_dgv.Rows[i].Cells["SEQ"].Value;
                        if (txt_seq == "" || txt_seq == null)
                        {

                            sb.AppendLine("declare @out_seq" + i + " int ");
                            sb.AppendLine("select @out_seq" + i + " =ISNULL(MAX(SEQ),0)+1 from F_ITEM_OUT_DETAIL ");
                            sb.AppendLine("where OUTPUT_DATE = '" + out_date + "' ");
                            sb.AppendLine("and OUTPUT_CD = '" + out_cd + "' ");

                            sb.AppendLine("insert into F_ITEM_OUT_DETAIL(");
                            sb.AppendLine("     OUTPUT_DATE ");
                            sb.AppendLine("     ,OUTPUT_CD ");
                            sb.AppendLine("     ,SEQ ");
                            sb.AppendLine("     ,LOT_NO ");
                            sb.AppendLine("     ,LOT_SUB ");
                            sb.AppendLine("     ,ITEM_CD ");
                            sb.AppendLine("     ,UNIT_CD ");
                            sb.AppendLine("     ,OUTPUT_AMT ");
                            sb.AppendLine("     ,PRICE ");
                            sb.AppendLine("     ,TOTAL_MONEY ");
                            sb.AppendLine("     ,INPUT_DATE ");
                            sb.AppendLine("     ,INPUT_CD ");
                            sb.AppendLine("     ,TAX_CD ");
                            sb.AppendLine("     ,CUST_CD ");
                            sb.AppendLine("     ,INSTAFF ");
                            sb.AppendLine("     ,INTIME ");
                            sb.AppendLine("  )values ( ");
                            sb.AppendLine("     '" + out_date + "' ");
                            sb.AppendLine("     ,'" + out_cd + "' ");
                            sb.AppendLine("     ,@out_seq" + i + " ");
                            sb.AppendLine("     ,'" + item_out_dgv.Rows[i].Cells["O_LOT_NO"].Value + "' ");
                            sb.AppendLine("     ,'" + item_out_dgv.Rows[i].Cells["O_LOT_SUB"].Value + "' ");
                            sb.AppendLine("     ,'" + item_out_dgv.Rows[i].Cells["O_ITEM_CD"].Value + "' ");
                            sb.AppendLine("     ,'" + item_out_dgv.Rows[i].Cells["O_UNIT_CD"].Value + "' ");
                            sb.AppendLine("     ,'" + ((string)item_out_dgv.Rows[i].Cells["OUTPUT_AMT"].Value).Replace(",", "") + "' ");
                            sb.AppendLine("     ,'" + ((string)item_out_dgv.Rows[i].Cells["PRICE"].Value).Replace(",", "") + "' ");
                            sb.AppendLine("     ,'" + ((string)item_out_dgv.Rows[i].Cells["TOTAL_MONEY"].Value).Replace(",", "") + "' ");
                            sb.AppendLine("     ,'" + item_out_dgv.Rows[i].Cells["O_INPUT_DATE"].Value + "' ");
                            sb.AppendLine("     ,'" + item_out_dgv.Rows[i].Cells["O_INPUT_CD"].Value + "' ");
                            sb.AppendLine("     ,'" + item_out_dgv.Rows[i].Cells["O_TAX_CD"].Value + "' ");
                            sb.AppendLine("     ,'" + item_out_dgv.Rows[i].Cells["O_CUST_CD"].Value + "' ");
                            sb.AppendLine("     ,'" + Common.p_strStaffNo + "' ");
                            sb.AppendLine("     ,convert(varchar, getdate(), 120)  ");
                            sb.AppendLine("  )");
                        }
                        else
                        {
                            sb.AppendLine("update F_ITEM_OUT_DETAIL set");
                            sb.AppendLine("       OUTPUT_AMT =  '" + ((string)item_out_dgv.Rows[i].Cells["OUTPUT_AMT"].Value).Replace(",", "") + "' ");
                            sb.AppendLine("      ,PRICE =  '" + ((string)item_out_dgv.Rows[i].Cells["PRICE"].Value).Replace(",", "") + "' ");
                            sb.AppendLine("      ,TOTAL_MONEY =  '" + ((string)item_out_dgv.Rows[i].Cells["TOTAL_MONEY"].Value).Replace(",", "") + "' ");
                            sb.AppendLine("      ,UPSTAFF =  '" + Common.p_strStaffNo + "' ");
                            sb.AppendLine("      ,UPTIME =  convert(varchar, getdate(), 120) ");
                            sb.AppendLine(" where OUTPUT_DATE = '" + out_date + "' ");
                            sb.AppendLine(" and OUTPUT_CD = '" + out_cd + "' ");
                            sb.AppendLine(" and SEQ = '" + item_out_dgv.Rows[i].Cells["SEQ"].Value + "'");
                        }
                    }
                }

                if (del_dgv.Rows.Count > 0)
                {
                    for (int i = 0; i < del_dgv.Rows.Count; i++)
                    {
                        sb.AppendLine("delete from F_ITEM_OUT_DETAIL ");
                        sb.AppendLine("    where OUTPUT_DATE = '" + out_date + "' ");
                        sb.AppendLine("     and OUTPUT_CD = '" + out_cd + "' ");
                        sb.AppendLine("     and SEQ = '" + del_dgv.Rows[i]["SEQ"].ToString() + "' ");
                    }
                }

                sCommand = new SqlCommand(sb.ToString());


                sCommand.Parameters.AddWithValue("@OUTPUT_DATE", out_date);
                sCommand.Parameters.AddWithValue("@OUTPUT_CD", out_cd);

                if (Common.sp_pack_gubun.Equals("1"))
                {
                    StringBuilder sb2 = new StringBuilder();

                    sb2.AppendLine(" UPDATE T_매출 SET ");
                    sb2.AppendLine(" 수정사원번호 = '100' ");
                    sb2.AppendLine(" ,수정일시 =  convert(varchar, getdate(), 120) ");
                    sb2.AppendLine(" WHERE 사업자번호 = '" + Common.p_saupNo + "' ");
                    sb2.AppendLine(" and 지점코드 = '0' ");
                    sb2.AppendLine(" and 매출일자 = '" + out_date + "' ");
                    sb2.AppendLine(" and 전표번호 = '" + jang_cd + "' ");

                    if (item_out_dgv.Rows.Count > 0)
                    {
                        for (int i = 0; i < item_out_dgv.Rows.Count; i++)
                        {
                            string txt_seq = (string)item_out_dgv.Rows[i].Cells["SEQ"].Value;
                            if (txt_seq == "" || txt_seq == null)
                            {
                                sb2.AppendLine("declare @out_seq" + i + " int ");
                                sb2.AppendLine("select @out_seq" + i + " =ISNULL(MAX(항목순번),0)+1 from T_매출항목 ");
                                sb2.AppendLine("where 사업자번호 = '" + Common.p_saupNo + "' ");
                                sb2.AppendLine("and 매출일자 = '" + out_date + "' ");
                                sb2.AppendLine("and 전표번호 =  '" + jang_cd + "' ");

                                sb2.AppendLine("INSERT INTO T_매출항목 ( ");
                                sb2.AppendLine(" 사업자번호 ");
                                sb2.AppendLine(" ,지점코드 ");
                                sb2.AppendLine(" ,매출일자 ");
                                sb2.AppendLine(" ,전표번호 ");
                                sb2.AppendLine(" ,항목순번 ");
                                sb2.AppendLine(" ,상품코드 ");
                                sb2.AppendLine(" ,박스수량 ");
                                sb2.AppendLine(" ,중간수량 ");
                                sb2.AppendLine(" ,낱개수량 ");
                                sb2.AppendLine(" ,총수량 ");
                                sb2.AppendLine(" ,박스단가 ");
                                sb2.AppendLine(" ,낱개단가 ");
                                sb2.AppendLine(" ,금액 ");
                                sb2.AppendLine(" ,서비스박스 ");
                                sb2.AppendLine(" ,서비스낱개 ");
                                sb2.AppendLine(" ,서비스총수량 ");
                                sb2.AppendLine(" ,최종매출일 ");
                                sb2.AppendLine(" ,매출구분 ");
                                sb2.AppendLine(" ,비고 ");
                                sb2.AppendLine(" ,과세구분 ");
                                sb2.AppendLine(" ,박스입고단가 ");
                                sb2.AppendLine(" ,낱개입고단가 ");
                                sb2.AppendLine(" ,매출일자와번호 ");
                                sb2.AppendLine(" ) VALUES ( ");
                                sb2.AppendLine(" '" + Common.p_saupNo + "' ");
                                sb2.AppendLine(" ,'0' ");
                                sb2.AppendLine(" ,'" + out_date + "' ");
                                sb2.AppendLine(" ,'" + jang_cd + "' ");
                                sb2.AppendLine(" ,@out_seq" + i + "  ");
                                sb2.AppendLine(" ,'" + item_out_dgv.Rows[i].Cells["O_LINK_CD"].Value.ToString() + "' ");
                                sb2.AppendLine(" ,0 ");
                                sb2.AppendLine(" ,0 ");
                                sb2.AppendLine(" ," + ((string)item_out_dgv.Rows[i].Cells["OUTPUT_AMT"].Value).Replace(",", "") + " ");
                                sb2.AppendLine(" ," + ((string)item_out_dgv.Rows[i].Cells["OUTPUT_AMT"].Value).Replace(",", "") + " ");
                                sb2.AppendLine(" ,0 ");
                                sb2.AppendLine(" ," + ((string)item_out_dgv.Rows[i].Cells["PRICE"].Value).Replace(",", "") + " ");
                                sb2.AppendLine(" ," + ((string)item_out_dgv.Rows[i].Cells["TOTAL_MONEY"].Value).Replace(",", "") + " ");
                                sb2.AppendLine(" ,0 ");
                                sb2.AppendLine(" ,0 ");
                                sb2.AppendLine(" ,0 ");
                                sb2.AppendLine(" ,'' ");
                                sb2.AppendLine(" ,'1' ");
                                sb2.AppendLine(" ,'' ");
                                sb2.AppendLine(" ,'" + item_out_dgv.Rows[i].Cells["O_TAX_CD"].Value.ToString() + "' ");
                                sb2.AppendLine(" ,0 ");
                                sb2.AppendLine(" ,0 ");
                                sb2.AppendLine(" ,'" + out_date + "'+'_'+'" + out_cd + "' ");
                                sb2.AppendLine(" ) ");
                            }
                            else
                            {
                                sb2.AppendLine("update T_매출항목 set");
                                sb2.AppendLine("       낱개수량 =  '" + ((string)item_out_dgv.Rows[i].Cells["OUTPUT_AMT"].Value).Replace(",", "") + "' ");
                                sb2.AppendLine("      ,총수량 =  '" + ((string)item_out_dgv.Rows[i].Cells["OUTPUT_AMT"].Value).Replace(",", "") + "' ");
                                sb2.AppendLine("      ,낱개단가 =  '" + ((string)item_out_dgv.Rows[i].Cells["PRICE"].Value).Replace(",", "") + "' ");
                                sb2.AppendLine("      ,금액 =  '" + ((string)item_out_dgv.Rows[i].Cells["TOTAL_MONEY"].Value).Replace(",", "") + "' ");
                                sb2.AppendLine(" WHERE 사업자번호 = '" + Common.p_saupNo + "' ");
                                sb2.AppendLine(" and 지점코드 = '0' ");
                                sb2.AppendLine(" and 매출일자 = '" + out_date + "' ");
                                sb2.AppendLine(" and 전표번호 = '" + jang_cd + "' ");
                                sb2.AppendLine(" and 항목순번 = '" + item_out_dgv.Rows[i].Cells["J_INPUT_SEQ"].Value.ToString() + "' ");
                            }
                        }
                    }

                    if (del_dgv.Rows.Count > 0)
                    {
                        for (int i = 0; i < del_dgv.Rows.Count; i++)
                        {
                            sb2.AppendLine("delete from T_매출항목 ");
                            sb2.AppendLine(" WHERE 사업자번호 = '" + Common.p_saupNo + "' ");
                            sb2.AppendLine(" and 지점코드 = '0' ");
                            sb2.AppendLine(" and 매출일자 = '" + out_date + "' ");
                            sb2.AppendLine(" and 전표번호 = '" + jang_cd + "' ");
                            sb2.AppendLine(" and 항목순번 = '" + del_dgv.Rows[i]["J_SEQ"].ToString() + "' ");
                        }
                    }

                    SqlCommand sCommand2 = new SqlCommand(sb2.ToString());

                    int qResult = wAdo.SqlCommandEtc_Jang(sCommand2, "update_ITEM_OUTPUT_JANG_TB");
                    if (qResult > 0)
                    {

                        sb2.Clear();
                        for (int i = 0; i < item_out_dgv.Rows.Count; i++)
                        {
                            sb2.AppendLine("SELECT 항목순번 FROM T_매출항목 WHERE 사업자번호 = '" + Common.p_saupNo + "' and 지점코드 = '0' and 매출일자 ='" + out_date + "' and 전표번호 = '" + jang_cd + "' ");
                        }

                        SqlCommand sCommandTemp2 = new SqlCommand(sb2.ToString());
                        if (sCommand.CommandText.Equals(null))
                        {
                            wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                            return -1;
                        }
                        DataTable dtTempSeq = wAdo.SqlCommandSelect_Jang(sCommandTemp2);

                        if (dtTempSeq != null && dtTempSeq.Rows.Count > 0)
                        {
                            for (int i = 0; i < dtTempSeq.Rows.Count; i++)
                            {
                                string txt_seq = (string)item_out_dgv.Rows[i].Cells["SEQ"].Value;
                                if (txt_seq == "" || txt_seq == null)
                                {
                                    sb.AppendLine(" UPDATE F_ITEM_OUT_DETAIL SET J_INPUT_DATE = '" + out_date + "' , J_INPUT_CD = '" + jang_cd + "' , J_INPUT_SEQ = '" + dtTempSeq.Rows[i]["항목순번"].ToString() + "' ");
                                    sb.AppendLine(" WHERE OUTPUT_DATE = '" + out_date + "' and  OUTPUT_CD = '" + out_cd + "' and SEQ = @out_seq" + i + " ");
                                }
                            }

                            sCommand = new SqlCommand(sb.ToString());
                        }
                        else
                        {
                            return -1;
                        }


                        int qResult2 = wAdo.SqlCommandEtc(sCommand, "update_ITEM_OUTPUT_TB");
                        if (qResult2 > 0)
                        {
                            return 0;  // 0 true, 1 false
                        }
                        else return 1;
                    }
                    else return 1;

                }
                else
                {
                    int qResult = wAdo.SqlCommandEtc(sCommand, "update_ITEM_OUTPUT_TB");
                    if (qResult > 0)
                    {
                        return 0;  // 0 true, 1 false
                    }
                    else return 1;
                }

            }
            catch (Exception e)
            {
                wnLog.writeLog(wnLog.LOG_ERROR, e.Message + " - " + e.ToString());
                Popup.pop오류리포트 msg = new pop오류리포트(e.Message + " - " + e.ToString());
                msg.ShowDialog();
                return 9;
            }
        }
         */

        //공정검사 항목 수정 

        //공정검사 항목 
        public int updateFlowChk(
              string txt_item_cd
            , string txt_flow_cd
            , string txt_item_img
            , string txt_measure_cnt
            , conDataGridView flow_chk_dgv
            , DataGridView del_dgv)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb.AppendLine("update N_FLOW_CHK ");
                sb.AppendLine("set MEASURE_CNT = " + txt_measure_cnt + "  ");
                sb.AppendLine("     ,UPSTAFF = '" + Common.p_strStaffNo + "' ");
                sb.AppendLine("     ,UPTIME = convert(varchar, getdate(), 120) ");
                sb.AppendLine("where ITEM_CD = '" + txt_item_cd + "' ");
                sb.AppendLine("     and FLOW_CD = '" + txt_flow_cd + "' ");

                if (del_dgv.Rows.Count > 0)
                {
                    for (int i = 0; i < del_dgv.Rows.Count; i++)
                    {
                        sb.AppendLine("delete from N_FLOW_CHK_STAN ");
                        sb.AppendLine("where ITEM_CD = '" + txt_item_cd + "' ");
                        sb.AppendLine("     and FLOW_CD = '" + txt_flow_cd + "' ");
                        sb.AppendLine("     and CHK_CD = '" + del_dgv.Rows[i].Cells["CHK_CD"].Value + "' ");
                    }
                }

                if (flow_chk_dgv.Rows.Count > 0)
                {
                    for (int i = 0; i < flow_chk_dgv.Rows.Count; i++)
                    {
                        sb.AppendLine("declare @chk" + i + " int ");
                        sb.AppendLine("select @chk" + i + " = count(*) from N_FLOW_CHK_STAN ");
                        sb.AppendLine("where ITEM_CD = '" + txt_item_cd + "' ");
                        sb.AppendLine(" and FLOW_CD = '" + txt_flow_cd + "' ");
                        sb.AppendLine(" and CHK_CD = '" + flow_chk_dgv.Rows[i].Cells["CHK_CD"].Value + "' ");

                        sb.AppendLine("IF(@chk" + i + " > 0)");
                        sb.AppendLine("update N_FLOW_CHK_STAN ");
                        sb.AppendLine("set CHK_LOC = '" + (string)flow_chk_dgv.Rows[i].Cells["CHK_LOC"].Value + "' ");
                        sb.AppendLine("   ,EVA_GUBUN = '" + (string)flow_chk_dgv.Rows[i].Cells["EVA_GUBUN"].Value + "' ");
                        sb.AppendLine("   ,RULE_SIZE = '" + (string)flow_chk_dgv.Rows[i].Cells["RULE_SIZE"].Value + "' ");
                        sb.AppendLine("   ,RULE_LIMIT = '" + (string)flow_chk_dgv.Rows[i].Cells["RULE_LIMIT"].Value + "' ");
                        sb.AppendLine("   ,MEASURE_APP = '" + (string)flow_chk_dgv.Rows[i].Cells["MEASURE_APP"].Value + "' ");
                        sb.AppendLine("   ,CHK_METHOD = '" + (string)flow_chk_dgv.Rows[i].Cells["CHK_METHOD"].Value + "' ");
                        sb.AppendLine("   ,LOWER_SIZE = " + ((string)flow_chk_dgv.Rows[i].Cells["LOWER_SIZE"].Value).Replace(",", "") + " ");
                        sb.AppendLine("   ,UPPER_SIZE = " + ((string)flow_chk_dgv.Rows[i].Cells["UPPER_SIZE"].Value).Replace(",", "") + " ");
                        sb.AppendLine("   ,LOWER_SELF = " + ((string)flow_chk_dgv.Rows[i].Cells["LOWER_SELF"].Value).Replace(",", "") + " ");
                        sb.AppendLine("   ,UPPER_SELF = " + ((string)flow_chk_dgv.Rows[i].Cells["UPPER_SELF"].Value).Replace(",", "") + " ");
                        sb.AppendLine("where ITEM_CD = '" + txt_item_cd + "' ");
                        sb.AppendLine(" and FLOW_CD = '" + txt_flow_cd + "' ");
                        sb.AppendLine(" and CHK_CD = '" + flow_chk_dgv.Rows[i].Cells["CHK_CD"].Value + "' ");

                        sb.AppendLine("ELSE ");
                        sb.AppendLine("insert into N_FLOW_CHK_STAN(");
                        sb.AppendLine("     ITEM_CD ");
                        sb.AppendLine("     ,FLOW_CD ");
                        sb.AppendLine("     ,CHK_CD ");
                        sb.AppendLine("     ,EVA_GUBUN ");
                        sb.AppendLine("     ,CHK_LOC ");
                        sb.AppendLine("     ,RULE_SIZE ");
                        sb.AppendLine("     ,RULE_LIMIT ");
                        sb.AppendLine("     ,MEASURE_APP ");
                        sb.AppendLine("     ,CHK_METHOD ");
                        sb.AppendLine("     ,LOWER_SIZE ");
                        sb.AppendLine("     ,UPPER_SIZE ");
                        sb.AppendLine("     ,LOWER_SELF ");
                        sb.AppendLine("     ,UPPER_SELF ");
                        sb.AppendLine("     ,INSTAFF ");
                        sb.AppendLine("     ,INTIME ");
                        sb.AppendLine("  )values ( ");
                        sb.AppendLine("     '" + txt_item_cd + "' ");
                        sb.AppendLine("     ,'" + txt_flow_cd + "' ");
                        sb.AppendLine("     ,'" + flow_chk_dgv.Rows[i].Cells["CHK_CD"].Value + "' ");
                        sb.AppendLine("     ,'" + (string)flow_chk_dgv.Rows[i].Cells["EVA_GUBUN"].Value + "' ");
                        sb.AppendLine("     ,'" + flow_chk_dgv.Rows[i].Cells["CHK_LOC"].Value + "' ");
                        sb.AppendLine("     ,'" + flow_chk_dgv.Rows[i].Cells["RULE_SIZE"].Value + "' ");
                        sb.AppendLine("     ,'" + flow_chk_dgv.Rows[i].Cells["RULE_LIMIT"].Value + "' ");
                        sb.AppendLine("     ,'" + flow_chk_dgv.Rows[i].Cells["MEASURE_APP"].Value + "' ");
                        sb.AppendLine("     ,'" + flow_chk_dgv.Rows[i].Cells["CHK_METHOD"].Value + "' ");
                        sb.AppendLine("     ," + ((string)flow_chk_dgv.Rows[i].Cells["LOWER_SIZE"].Value).Replace(",", "") + " ");
                        sb.AppendLine("     ," + ((string)flow_chk_dgv.Rows[i].Cells["UPPER_SIZE"].Value).Replace(",", "") + " ");
                        sb.AppendLine("     ," + ((string)flow_chk_dgv.Rows[i].Cells["LOWER_SELF"].Value).Replace(",", "") + " ");
                        sb.AppendLine("     ," + ((string)flow_chk_dgv.Rows[i].Cells["UPPER_SELF"].Value).Replace(",", "") + " ");
                        sb.AppendLine("     ,'" + Common.p_strStaffNo + "' ");
                        sb.AppendLine("     ,convert(varchar, getdate(), 120) ");
                        sb.AppendLine("  )");
                    }
                }

                SqlCommand sCommand = new SqlCommand(sb.ToString());

                int qResult = wAdo.SqlCommandEtc(sCommand, "update_FLOW_CHK_TB");
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

        //제품검사기준 항목 
        public int updateItemChk(
              string txt_item_cd
            , string txt_item_img
            , string txt_measure_cnt
            , conDataGridView item_chk_dgv
            , DataGridView del_dgv)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb.AppendLine("update N_ITEM_CHK ");
                sb.AppendLine("set MEASURE_CNT = " + txt_measure_cnt + "  ");
                sb.AppendLine("     ,UPSTAFF = '" + Common.p_strStaffNo + "' ");
                sb.AppendLine("     ,UPTIME = convert(varchar, getdate(), 120) ");
                sb.AppendLine("where ITEM_CD = '" + txt_item_cd + "' ");

                if (del_dgv.Rows.Count > 0)
                {
                    for (int i = 0; i < del_dgv.Rows.Count; i++)
                    {
                        sb.AppendLine("delete from N_ITEM_CHK_STAN ");
                        sb.AppendLine("where ITEM_CD = '" + txt_item_cd + "' ");
                        sb.AppendLine("     and CHK_CD = '" + del_dgv.Rows[i].Cells["CHK_CD"].Value + "' ");
                    }
                }

                if (item_chk_dgv.Rows.Count > 0)
                {
                    for (int i = 0; i < item_chk_dgv.Rows.Count; i++)
                    {
                        sb.AppendLine("declare @chk" + i + " int ");
                        sb.AppendLine("select @chk" + i + " = count(*) from N_ITEM_CHK_STAN ");
                        sb.AppendLine("where ITEM_CD = '" + txt_item_cd + "' ");
                        sb.AppendLine(" and CHK_CD = '" + item_chk_dgv.Rows[i].Cells["CHK_CD"].Value + "' ");

                        sb.AppendLine("IF(@chk" + i + " > 0)");
                        sb.AppendLine("update N_ITEM_CHK_STAN ");
                        sb.AppendLine("set CHK_LOC = '" + (string)item_chk_dgv.Rows[i].Cells["CHK_LOC"].Value + "' ");
                        sb.AppendLine("   ,EVA_GUBUN = '" + (string)item_chk_dgv.Rows[i].Cells["EVA_GUBUN"].Value + "' ");
                        sb.AppendLine("   ,RULE_SIZE = '" + (string)item_chk_dgv.Rows[i].Cells["RULE_SIZE"].Value + "' ");
                        sb.AppendLine("   ,RULE_LIMIT = '" + (string)item_chk_dgv.Rows[i].Cells["RULE_LIMIT"].Value + "' ");
                        sb.AppendLine("   ,MEASURE_APP = '" + (string)item_chk_dgv.Rows[i].Cells["MEASURE_APP"].Value + "' ");
                        sb.AppendLine("   ,CHK_INTERVAL = '" + (string)item_chk_dgv.Rows[i].Cells["CHK_INTERVAL"].Value + "' ");
                        sb.AppendLine("   ,LOWER_SIZE = " + ((string)item_chk_dgv.Rows[i].Cells["LOWER_SIZE"].Value).Replace(",", "") + " ");
                        sb.AppendLine("   ,UPPER_SIZE = " + ((string)item_chk_dgv.Rows[i].Cells["UPPER_SIZE"].Value).Replace(",", "") + " ");
                        sb.AppendLine("   ,LOWER_SELF = " + ((string)item_chk_dgv.Rows[i].Cells["LOWER_SELF"].Value).Replace(",", "") + " ");
                        sb.AppendLine("   ,UPPER_SELF = " + ((string)item_chk_dgv.Rows[i].Cells["UPPER_SELF"].Value).Replace(",", "") + " ");
                        sb.AppendLine("where ITEM_CD = '" + txt_item_cd + "' ");
                        sb.AppendLine(" and CHK_CD = '" + item_chk_dgv.Rows[i].Cells["CHK_CD"].Value + "' ");

                        sb.AppendLine("ELSE ");
                        sb.AppendLine("insert into N_ITEM_CHK_STAN(");
                        sb.AppendLine("     ITEM_CD ");
                        sb.AppendLine("     ,CHK_CD ");
                        sb.AppendLine("     ,EVA_GUBUN ");
                        sb.AppendLine("     ,CHK_LOC ");
                        sb.AppendLine("     ,RULE_SIZE ");
                        sb.AppendLine("     ,RULE_LIMIT ");
                        sb.AppendLine("     ,MEASURE_APP ");
                        sb.AppendLine("     ,CHK_INTERVAL ");
                        sb.AppendLine("     ,LOWER_SIZE ");
                        sb.AppendLine("     ,UPPER_SIZE ");
                        sb.AppendLine("     ,LOWER_SELF ");
                        sb.AppendLine("     ,UPPER_SELF ");
                        sb.AppendLine("     ,INSTAFF ");
                        sb.AppendLine("     ,INTIME ");
                        sb.AppendLine("  )values ( ");
                        sb.AppendLine("     '" + txt_item_cd + "' ");
                        sb.AppendLine("     ,'" + item_chk_dgv.Rows[i].Cells["CHK_CD"].Value + "' ");
                        sb.AppendLine("     ,'" + (string)item_chk_dgv.Rows[i].Cells["EVA_GUBUN"].Value + "' ");
                        sb.AppendLine("     ,'" + item_chk_dgv.Rows[i].Cells["CHK_LOC"].Value + "' ");
                        sb.AppendLine("     ,'" + item_chk_dgv.Rows[i].Cells["RULE_SIZE"].Value + "' ");
                        sb.AppendLine("     ,'" + item_chk_dgv.Rows[i].Cells["RULE_LIMIT"].Value + "' ");
                        sb.AppendLine("     ,'" + item_chk_dgv.Rows[i].Cells["MEASURE_APP"].Value + "' ");
                        sb.AppendLine("     ,'" + item_chk_dgv.Rows[i].Cells["CHK_INTERVAL"].Value + "' ");
                        sb.AppendLine("     ," + ((string)item_chk_dgv.Rows[i].Cells["LOWER_SIZE"].Value).Replace(",", "") + " ");
                        sb.AppendLine("     ," + ((string)item_chk_dgv.Rows[i].Cells["UPPER_SIZE"].Value).Replace(",", "") + " ");
                        sb.AppendLine("     ," + ((string)item_chk_dgv.Rows[i].Cells["LOWER_SELF"].Value).Replace(",", "") + " ");
                        sb.AppendLine("     ," + ((string)item_chk_dgv.Rows[i].Cells["UPPER_SELF"].Value).Replace(",", "") + " ");
                        sb.AppendLine("     ,'" + Common.p_strStaffNo + "' ");
                        sb.AppendLine("     ,convert(varchar, getdate(), 120) ");
                        sb.AppendLine("  )");
                    }
                }

                SqlCommand sCommand = new SqlCommand(sb.ToString());

                int qResult = wAdo.SqlCommandEtc(sCommand, "update_ITEM_CHK_TB");
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

        //수입검사 항목 
        public int updateRawChk(
              string txt_raw_mat_cd
            , string txt_control_no
            , conDataGridView raw_chk_dgv
            , DataGridView del_dgv)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb.AppendLine("update N_RAW_CHK ");
                sb.AppendLine("set CONTROL_NO = '" + txt_control_no + "'  ");
                sb.AppendLine("     ,UPSTAFF = '" + Common.p_strStaffNo + "' ");
                sb.AppendLine("     ,UPTIME = convert(varchar, getdate(), 120) ");
                sb.AppendLine("where RAW_MAT_CD = '" + txt_raw_mat_cd + "' ");

                if (del_dgv.Rows.Count > 0)
                {
                    for (int i = 0; i < del_dgv.Rows.Count; i++)
                    {
                        sb.AppendLine("delete from N_RAW_CHK_STAN ");
                        sb.AppendLine("    where RAW_MAT_CD = '" + txt_raw_mat_cd + "' ");
                        sb.AppendLine("     and CHK_CD = '" + del_dgv.Rows[i].Cells["CHK_CD"].Value + "' ");
                    }
                }

                if (raw_chk_dgv.Rows.Count > 0)
                {
                    for (int i = 0; i < raw_chk_dgv.Rows.Count; i++)
                    {
                        sb.AppendLine("declare @chk" + i + " int ");
                        sb.AppendLine("select @chk" + i + " = count(*) from N_RAW_CHK_STAN ");
                        sb.AppendLine("where RAW_MAT_CD = '" + txt_raw_mat_cd + "' ");
                        sb.AppendLine(" and CHK_CD = '" + raw_chk_dgv.Rows[i].Cells["CHK_CD"].Value + "' ");

                        sb.AppendLine("IF(@chk" + i + " > 0)");
                        sb.AppendLine("update N_RAW_CHK_STAN ");
                        sb.AppendLine("set CHK_STAN_VALUE = '" + (string)raw_chk_dgv.Rows[i].Cells["CHK_STAN_VALUE"].Value + "' ");
                        sb.AppendLine("where RAW_MAT_CD = '" + txt_raw_mat_cd + "' ");
                        sb.AppendLine(" and CHK_CD = '" + raw_chk_dgv.Rows[i].Cells["CHK_CD"].Value + "' ");

                        sb.AppendLine("ELSE ");
                        sb.AppendLine("insert into N_RAW_CHK_STAN(");
                        sb.AppendLine("     RAW_MAT_CD ");
                        sb.AppendLine("     ,CHK_CD ");
                        sb.AppendLine("     ,CHK_STAN_VALUE ");
                        sb.AppendLine("     ,INSTAFF ");
                        sb.AppendLine("     ,INTIME ");
                        sb.AppendLine("  )values ( ");
                        sb.AppendLine("     '" + txt_raw_mat_cd + "' ");
                        sb.AppendLine("     ,'" + raw_chk_dgv.Rows[i].Cells["CHK_CD"].Value + "' ");
                        sb.AppendLine("     ,'" + raw_chk_dgv.Rows[i].Cells["CHK_STAN_VALUE"].Value + "' ");
                        sb.AppendLine("     ,'" + Common.p_strStaffNo + "' ");
                        sb.AppendLine("     ,convert(varchar, getdate(), 120) ");
                        sb.AppendLine("  )");
                    }
                }

                SqlCommand sCommand = new SqlCommand(sb.ToString());

                int qResult = wAdo.SqlCommandEtc(sCommand, "update_RAW_CHK_TB");
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

        //공정검사성적서 수정
        public int updateFlowChkExam(
              string txt_lot_no
            , string txt_lot_sub
            , string txt_f_step
            , int startIdx
            , Label lblSearch
            , byte[] img
            , int img_size
            , DataGridView flow_chk_dgv
            , string path)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb = new StringBuilder();

                if (img_size > 0)
                {
                    sb.AppendLine(" update F_FLOW_CHK ");
                    sb.AppendLine(" set MAP = @MAP , MAP_SIZE = @MAP_SIZE ,EXTERIOR = @EXTERIOR ");
                    sb.AppendLine(" where LOT_NO = @LOT_NO ");
                    sb.AppendLine("     and LOT_SUB = @LOT_SUB ");
                    sb.AppendLine("     and F_STEP = @F_STEP ");
                }
                //else 
                //{
                //    sb.AppendLine(" set MAP = null , MAP_SIZE = 0 ");
                //}

                for (int i = 0; i < flow_chk_dgv.Rows.Count; i++)
                {
                    if (flow_chk_dgv.Rows[i].Cells["GRADE"].Value == null)
                    {
                        flow_chk_dgv.Rows[i].Cells["GRADE"].Value = "";
                    }

                    sb.AppendLine("update F_FLOW_CHK_RST ");
                    sb.AppendLine("set GRADE = '" + (string)flow_chk_dgv.Rows[i].Cells["GRADE"].Value + "' ");
                    sb.AppendLine("     ,UPSTAFF = '" + Common.p_strStaffNo + "' ");
                    sb.AppendLine("     ,UPTIME = convert(varchar, getdate(), 120) ");

                    sb.AppendLine(" where LOT_NO = @LOT_NO ");
                    sb.AppendLine("     and LOT_SUB = @LOT_SUB ");
                    sb.AppendLine("     and F_STEP = @F_STEP ");
                    sb.AppendLine("     and CHK_CD = '" + flow_chk_dgv.Rows[i].Cells["CHK_CD"].Value + "' ");

                    int k = 1;
                    for (int j = startIdx; j < flow_chk_dgv.Columns.Count; j++)
                    {
                        sb.AppendLine("update F_FLOW_CHK_DETAIL");
                        sb.AppendLine("set   CHK_VALUE = '" + flow_chk_dgv.Rows[i].Cells["CHK" + k.ToString()].Value + "'  ");
                        sb.AppendLine("     ,UPSTAFF = '" + Common.p_strStaffNo + "' ");
                        sb.AppendLine("     ,UPTIME = convert(varchar, getdate(), 120) ");
                        sb.AppendLine(" where LOT_NO = @LOT_NO ");
                        sb.AppendLine("     and LOT_SUB = @LOT_SUB ");
                        sb.AppendLine("     and F_STEP = @F_STEP ");
                        sb.AppendLine("     and CHK_CD = '" + flow_chk_dgv.Rows[i].Cells["CHK_CD"].Value + "' ");
                        sb.AppendLine("     and SEQ = " + k + " ");
                        k++;
                    }
                }

                SqlCommand sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@LOT_NO", txt_lot_no);
                sCommand.Parameters.AddWithValue("@LOT_SUB", txt_lot_sub);
                sCommand.Parameters.AddWithValue("@F_STEP", txt_f_step);
                sCommand.Parameters.AddWithValue("@EXTERIOR", path);
                if (img_size > 0)
                {
                    sCommand.Parameters.AddWithValue("@MAP", img);
                    sCommand.Parameters.AddWithValue("@MAP_SIZE", img_size);
                }

                int qResult = wAdo.SqlCommandEtc(sCommand, "update_FLOW_CHK_EXAM_TB");
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

        //제품검사성적서 수정
        public int updateItemChkExam(
              string txt_lot_no
            , string txt_lot_sub
            , string txt_f_step
            , int startIdx
            , Label lblSearch
            , byte[] img
            , int img_size
            , DataGridView item_chk_dgv)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb = new StringBuilder();

                if (img_size > 0)
                {
                    sb.AppendLine(" update F_ITEM_CHK ");
                    sb.AppendLine(" set MAP = @MAP , MAP_SIZE = @MAP_SIZE ");
                    sb.AppendLine(" where LOT_NO = @LOT_NO ");
                    sb.AppendLine("     and LOT_SUB = @LOT_SUB ");
                    sb.AppendLine("     and F_STEP = @F_STEP ");
                }
                //else
                //{
                //    sb.AppendLine(" set MAP = null , MAP_SIZE = 0 ");
                //}

                for (int i = 0; i < item_chk_dgv.Rows.Count; i++)
                {
                    if (item_chk_dgv.Rows[i].Cells["GRADE"].Value == null)
                    {
                        item_chk_dgv.Rows[i].Cells["GRADE"].Value = "";
                    }

                    sb.AppendLine("update F_ITEM_CHK_RST ");
                    sb.AppendLine("set GRADE = '" + (string)item_chk_dgv.Rows[i].Cells["GRADE"].Value + "' ");
                    sb.AppendLine("     ,UPSTAFF = '" + Common.p_strStaffNo + "' ");
                    sb.AppendLine("     ,UPTIME = convert(varchar, getdate(), 120) ");

                    sb.AppendLine(" where LOT_NO = @LOT_NO ");
                    sb.AppendLine("     and LOT_SUB = @LOT_SUB ");
                    sb.AppendLine("     and F_STEP = @F_STEP ");
                    sb.AppendLine("     and CHK_CD = '" + item_chk_dgv.Rows[i].Cells["CHK_CD"].Value + "' ");

                    int k = 1;
                    for (int j = startIdx; j < item_chk_dgv.Columns.Count; j++)
                    {
                        sb.AppendLine("update F_ITEM_CHK_DETAIL");
                        sb.AppendLine("set   CHK_VALUE = '" + item_chk_dgv.Rows[i].Cells["CHK" + k.ToString()].Value + "'  ");
                        sb.AppendLine("     ,UPSTAFF = '" + Common.p_strStaffNo + "' ");
                        sb.AppendLine("     ,UPTIME = convert(varchar, getdate(), 120) ");
                        sb.AppendLine(" where LOT_NO = @LOT_NO ");
                        sb.AppendLine("     and LOT_SUB = @LOT_SUB ");
                        sb.AppendLine("     and F_STEP = @F_STEP ");
                        sb.AppendLine("     and CHK_CD = '" + item_chk_dgv.Rows[i].Cells["CHK_CD"].Value + "' ");
                        sb.AppendLine("     and SEQ = " + k + " ");
                        k++;
                    }
                }

                SqlCommand sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@LOT_NO", txt_lot_no);
                sCommand.Parameters.AddWithValue("@LOT_SUB", txt_lot_sub);
                sCommand.Parameters.AddWithValue("@F_STEP", txt_f_step);
                if (img_size > 0)
                {
                    sCommand.Parameters.AddWithValue("@MAP", img);
                    sCommand.Parameters.AddWithValue("@MAP_SIZE", img_size);
                }

                int qResult = wAdo.SqlCommandEtc(sCommand, "update_ITEM_CHK_EXAM_TB");
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

        //공정검사성적서 합격여부
        public int updateFlowChkPass(
              string txt_lot_no
            , string txt_lot_sub
            , string txt_f_step
            , string pass_yn)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb = new StringBuilder();

                sb.AppendLine(" update F_FLOW_CHK ");
                sb.AppendLine(" set PASS_YN = @PASS_YN ");
                sb.AppendLine(" where LOT_NO = @LOT_NO ");
                sb.AppendLine("     and LOT_SUB = @LOT_SUB ");
                sb.AppendLine("     and F_STEP = @F_STEP ");

                sb.AppendLine(" update F_WORK_FLOW_DETAIL ");
                sb.AppendLine(" set CHECK_YN = 'Y' ");
                sb.AppendLine(" where LOT_NO = @LOT_NO ");
                sb.AppendLine("     and LOT_SUB = @LOT_SUB ");
                sb.AppendLine("     and F_STEP = @F_STEP ");

                SqlCommand sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@LOT_NO", txt_lot_no);
                sCommand.Parameters.AddWithValue("@LOT_SUB", txt_lot_sub);
                sCommand.Parameters.AddWithValue("@F_STEP", txt_f_step);
                sCommand.Parameters.AddWithValue("@PASS_YN", pass_yn);

                int qResult = wAdo.SqlCommandEtc(sCommand, "update_FLOW_CHK_EXAM_TB");
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

        //제품검사성적서 합격여부
        public int updateItemChkPass(
              string txt_lot_no
            , string txt_lot_sub
            , string txt_f_step
            , string pass_yn)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb = new StringBuilder();

                sb.AppendLine(" update F_ITEM_CHK ");
                sb.AppendLine(" set PASS_YN = @PASS_YN ");
                sb.AppendLine(" where LOT_NO = @LOT_NO ");
                sb.AppendLine("     and LOT_SUB = @LOT_SUB ");
                sb.AppendLine("     and F_STEP = @F_STEP ");

                sb.AppendLine(" update F_WORK_FLOW_DETAIL ");
                sb.AppendLine(" set ITEM_CHECK_YN = 'Y' ");
                sb.AppendLine(" where LOT_NO = @LOT_NO ");
                sb.AppendLine("     and LOT_SUB = @LOT_SUB ");
                sb.AppendLine("     and F_STEP = @F_STEP ");

                SqlCommand sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@LOT_NO", txt_lot_no);
                sCommand.Parameters.AddWithValue("@LOT_SUB", txt_lot_sub);
                sCommand.Parameters.AddWithValue("@F_STEP", txt_f_step);
                sCommand.Parameters.AddWithValue("@PASS_YN", pass_yn);

                int qResult = wAdo.SqlCommandEtc(sCommand, "update_ITEM_CHK_EXAM_TB");
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

        //수입검사 합격여부
        public int updateRawChkPass(
              string txt_input_date
            , string txt_input_cd
            , string txt_seq
            , string pass_yn
            , decimal final_amt)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb = new StringBuilder();

                sb.AppendLine(" update F_RAW_CHK ");
                sb.AppendLine(" set PASS_YN = @PASS_YN  ");
                sb.AppendLine(" where INPUT_DATE = @INPUT_DATE ");
                sb.AppendLine("     and INPUT_CD = @INPUT_CD ");
                sb.AppendLine("     and SEQ = @SEQ ");

                sb.AppendLine(" update F_RAW_DETAIL ");
                sb.AppendLine(" set CHECK_YN = 'Y' , TOTAL_AMT = " + final_amt + ", CURR_AMT = " + final_amt + "");
                sb.AppendLine(" where INPUT_DATE = @INPUT_DATE ");
                sb.AppendLine("     and INPUT_CD = @INPUT_CD ");
                sb.AppendLine("     and SEQ = @SEQ ");

                SqlCommand sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@INPUT_DATE", txt_input_date);
                sCommand.Parameters.AddWithValue("@INPUT_CD", txt_input_cd);
                sCommand.Parameters.AddWithValue("@SEQ", txt_seq);
                sCommand.Parameters.AddWithValue("@PASS_YN", pass_yn);

                int qResult = wAdo.SqlCommandEtc(sCommand, "update_RAW_CHK_EXAM_TB");
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

        //공정검사성적서 수정
        public int updateRawChkExam(
              string txt_input_date
            , string txt_input_cd
            , string txt_seq
            , string txt_raw_mat_cd
            , string txt_control_cd
            , string txt_part_no
            , string txt_chk_total_amt
            , string txt_pass_amt
            , string pri_non_pass_amt
            , string upd_com_amt
            , string final_non_pass_amt
            , string final_pass_amt
            , string comment
            , DataGridView rawStanGrid
            , DataGridView rawPoorGrid)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb = new StringBuilder();

                sb.AppendLine("update F_RAW_CHK ");
                sb.AppendLine("set CONTROL_NO = @CONTROL_NO ");
                sb.AppendLine("     ,PART_NO = @PART_NO ");
                sb.AppendLine("     ,CHK_TOTAL_AMT = @CHK_TOTAL_AMT ");
                sb.AppendLine("     ,PASS_AMT = @PASS_AMT ");
                sb.AppendLine("     ,PRI_NON_PASS_AMT = @PRI_NON_PASS_AMT ");
                sb.AppendLine("     ,UPD_COM_AMT = @UPD_COM_AMT ");
                sb.AppendLine("     ,FINAL_NON_PASS_AMT = @FINAL_NON_PASS_AMT ");
                sb.AppendLine("     ,FINAL_PASS_AMT = @FINAL_PASS_AMT ");
                sb.AppendLine("     ,UPSTAFF = '" + Common.p_strStaffNo + "' ");
                sb.AppendLine("     ,UPTIME = convert(varchar, getdate(), 120) ");
                sb.AppendLine("where INPUT_DATE = @INPUT_DATE ");
                sb.AppendLine(" and INPUT_CD = @INPUT_CD ");
                sb.AppendLine(" and SEQ = @SEQ ");

                if (rawStanGrid.Rows.Count > 0)
                {
                    for (int i = 0; i < rawStanGrid.Rows.Count; i++)
                    {
                        sb.AppendLine("update F_RAW_CHK_RST ");
                        sb.AppendLine("set CHK_VALUE =  '" + rawStanGrid.Rows[i].Cells["CHK_VALUE"].Value.ToString() + "' ");
                        sb.AppendLine("where INPUT_DATE = '" + txt_input_date + "' ");
                        sb.AppendLine(" and INPUT_CD = '" + txt_input_cd + "' ");
                        sb.AppendLine(" and SEQ = '" + txt_seq + "' ");
                        sb.AppendLine(" and CHK_CD = '" + rawStanGrid.Rows[i].Cells["CHK_CD"].Value.ToString() + "' ");
                    }
                }

                if (rawPoorGrid.Rows.Count > 0)
                {
                    for (int i = 0; i < rawPoorGrid.Rows.Count; i++)
                    {
                        if (rawPoorGrid.Rows[i].Cells["POOR_SEQ"] == null) Console.WriteLine(rawPoorGrid.Rows[i].Cells["POOR_SEQ"]);
                        if (rawPoorGrid.Rows[i].Cells["POOR_SEQ"].Value != null && (string)rawPoorGrid.Rows[i].Cells["POOR_SEQ"].Value != "")
                        {
                            sb.AppendLine("update F_RAW_CHK_POOR");
                            sb.AppendLine(" set  ");
                            if (rawPoorGrid.Rows[i].Cells["POOR_TYPE"].Value == null)
                            {
                                rawPoorGrid.Rows[i].Cells["POOR_TYPE"].Value = "";
                            }
                            if (rawPoorGrid.Rows[i].Cells["POOR_NM"].Value.ToString() == null)
                            {
                                rawPoorGrid.Rows[i].Cells["POOR_NM"].Value = "";
                            }
                            sb.AppendLine("     TYPE_CD = '" + rawPoorGrid.Rows[i].Cells["POOR_TYPE"].Value.ToString() + "' ");
                            sb.AppendLine("     ,POOR_NM = '" + rawPoorGrid.Rows[i].Cells["POOR_NM"].Value.ToString() + "' ");
                            sb.AppendLine("     ,PRI_NON_PASS_AMT = '" + ((string)rawPoorGrid.Rows[i].Cells["PRI_NON_PASS_AMT"].Value).Replace(",", "") + "'");
                            sb.AppendLine("     ,UPD_DETAIL = '" + rawPoorGrid.Rows[i].Cells["UPD_DETAIL"].Value.ToString() + "' ");
                            sb.AppendLine("     ,UPD_PASS_AMT = '" + ((string)rawPoorGrid.Rows[i].Cells["UPD_PASS_AMT"].Value).Replace(",", "") + "' ");
                            //sb.AppendLine("     ,COMMENT ");
                            sb.AppendLine("     ,UPSTAFF = '" + Common.p_strStaffNo + "' ");
                            sb.AppendLine("     ,UPTIME = convert(varchar, getdate(), 120) ");
                            sb.AppendLine("where INPUT_DATE = '" + txt_input_date + "' ");
                            sb.AppendLine(" and INPUT_CD = '" + txt_input_cd + "' ");
                            sb.AppendLine(" and SEQ = '" + txt_seq + "' ");
                            sb.AppendLine(" and POOR_SEQ = '" + rawPoorGrid.Rows[i].Cells["POOR_SEQ"].Value.ToString() + "' ");
                        }
                        else  //신규일 경우
                        {
                            sb.AppendLine("declare @p_seq" + i + " int ");
                            sb.AppendLine("select @p_seq" + i + " =ISNULL(MAX(POOR_SEQ),0)+1 from F_RAW_CHK_POOR ");
                            sb.AppendLine("where INPUT_DATE = '" + txt_input_date + "' ");
                            sb.AppendLine("     and INPUT_CD = '" + txt_input_cd + "' ");
                            sb.AppendLine("     and SEQ = '" + txt_seq + "' ");

                            sb.AppendLine("insert into F_RAW_CHK_POOR(");
                            sb.AppendLine("     INPUT_DATE ");
                            sb.AppendLine("     ,INPUT_CD ");
                            sb.AppendLine("     ,SEQ ");
                            sb.AppendLine("     ,POOR_SEQ ");
                            sb.AppendLine("     ,TYPE_CD ");
                            sb.AppendLine("     ,POOR_NM ");
                            sb.AppendLine("     ,PRI_NON_PASS_AMT ");
                            sb.AppendLine("     ,UPD_DETAIL ");
                            sb.AppendLine("     ,UPD_PASS_AMT ");
                            //sb.AppendLine("     ,COMMENT ");
                            sb.AppendLine("     ,INSTAFF ");
                            sb.AppendLine("     ,INTIME ");
                            sb.AppendLine(" ) values ( ");
                            sb.AppendLine("      '" + txt_input_date + "' ");
                            sb.AppendLine("      ," + txt_input_cd + " ");
                            sb.AppendLine("      ," + txt_seq + " ");
                            sb.AppendLine("      ,@p_seq" + i + " ");
                            sb.AppendLine("      ,'" + rawPoorGrid.Rows[i].Cells["POOR_TYPE"].Value.ToString() + "' ");
                            sb.AppendLine("      ,'" + rawPoorGrid.Rows[i].Cells["POOR_NM"].Value.ToString() + "' ");
                            sb.AppendLine("      ,'" + ((string)rawPoorGrid.Rows[i].Cells["PRI_NON_PASS_AMT"].Value).Replace(",", "") + "' ");
                            sb.AppendLine("      ,'" + rawPoorGrid.Rows[i].Cells["UPD_DETAIL"].Value.ToString() + "' ");
                            sb.AppendLine("      ,'" + ((string)rawPoorGrid.Rows[i].Cells["UPD_PASS_AMT"].Value).Replace(",", "") + "' ");
                            // sb.AppendLine("      ,'" + rawPoorGrid.Rows[i].Cells["COMMENT"].Value.ToString() + "' ");
                            sb.AppendLine("     ,'" + Common.p_strStaffNo + "' ");
                            sb.AppendLine("     ,convert(varchar, getdate(), 120) ");
                            sb.AppendLine(" ) ");
                        }
                    }
                }

                SqlCommand sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@INPUT_DATE", txt_input_date);
                sCommand.Parameters.AddWithValue("@INPUT_CD", txt_input_cd);
                sCommand.Parameters.AddWithValue("@SEQ", txt_seq);
                sCommand.Parameters.AddWithValue("@CONTROL_NO", txt_control_cd);
                sCommand.Parameters.AddWithValue("@PART_NO", txt_part_no);
                sCommand.Parameters.AddWithValue("@CHK_TOTAL_AMT", txt_chk_total_amt.Replace(",", ""));
                sCommand.Parameters.AddWithValue("@PASS_AMT", txt_pass_amt.Replace(",", ""));
                sCommand.Parameters.AddWithValue("@PRI_NON_PASS_AMT", pri_non_pass_amt.Replace(",", ""));
                sCommand.Parameters.AddWithValue("@UPD_COM_AMT", upd_com_amt.Replace(",", ""));
                sCommand.Parameters.AddWithValue("@FINAL_NON_PASS_AMT", final_non_pass_amt.Replace(",", ""));
                sCommand.Parameters.AddWithValue("@FINAL_PASS_AMT", final_pass_amt.Replace(",", ""));


                int qResult = wAdo.SqlCommandEtc(sCommand, "update_FLOW_CHK_EXAM_TB");
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

        public int updateChkOmit(StringBuilder sb)  //condition = 현황 , dt = detail
        {
            try
            {
                wnAdo wAdo = new wnAdo();


                SqlCommand sCommand = new SqlCommand(sb.ToString());

                int qResult = wAdo.SqlCommandEtc(sCommand, "update_CHK_OMIT");
                if (qResult > 0)
                {
                    return 0;  // 0 true, 1 false
                }
                else return 1;
            }
            catch (Exception e)
            {
                Console.WriteLine("error" + e.ToString());
                return 9;
            }
        }

        #endregion update
        public int deleteStaff(string txt_user_cd)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb = new StringBuilder();
                sb.AppendLine("delete from N_STAFF_CODE ");
                sb.AppendLine("    where STAFF_CD =@STAFF_CD  ");

                SqlCommand sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@STAFF_CD", txt_user_cd);

                int qResult = wAdo.SqlCommandEtc(sCommand, "delete_USER_TB");
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

        public int deleteDept(string txtDeptCd)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb = new StringBuilder();
                sb.AppendLine("delete from N_DEPT_CODE ");
                sb.AppendLine("    where DEPT_CD =@DEPT_CD  ");

                SqlCommand sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@DEPT_CD", txtDeptCd);

                int qResult = wAdo.SqlCommandEtc(sCommand, "delete_DEPT_TB");
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

        public int deletePos(string txt_pos_cd)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb = new StringBuilder();
                sb.AppendLine("delete from N_POS_CODE ");
                sb.AppendLine("    where POS_CD =@POS_CD  ");

                SqlCommand sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@POS_CD", txt_pos_cd);

                int qResult = wAdo.SqlCommandEtc(sCommand, "delete_POS_TB");
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

        public int deleteStor(string txt_stor_cd)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb = new StringBuilder();
                sb.AppendLine("delete from N_STORAGE_CODE ");
                sb.AppendLine("    where STORAGE_CD =@STORAGE_CD  ");

                SqlCommand sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@STORAGE_CD", txt_stor_cd);

                int qResult = wAdo.SqlCommandEtc(sCommand, "delete_STOR_TB");
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

        public int deleteType(string txt_type_cd)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb = new StringBuilder();
                sb.AppendLine("delete from N_TYPE_CODE ");
                sb.AppendLine("    where TYPE_CD =@TYPE_CD  ");

                SqlCommand sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@TYPE_CD", txt_type_cd);

                int qResult = wAdo.SqlCommandEtc(sCommand, "delete_TYPE_TB");
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

        public int deleteUnit(string txt_unit_cd)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb = new StringBuilder();
                sb.AppendLine("delete from N_UNIT_CODE ");
                sb.AppendLine("    where UNIT_CD =@UNIT_CD  ");

                SqlCommand sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@UNIT_CD", txt_unit_cd);

                int qResult = wAdo.SqlCommandEtc(sCommand, "delete_UNIT_TB");
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

        public int deleteLine(string txt_line_cd)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb = new StringBuilder();
                sb.AppendLine("delete from N_LINE_CODE ");
                sb.AppendLine("    where LINE_CD =@LINE_CD  ");

                SqlCommand sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@LINE_CD", txt_line_cd);

                int qResult = wAdo.SqlCommandEtc(sCommand, "delete_LINE_TB");
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

        public int deletePoor(string txt_poor_cd)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb = new StringBuilder();
                sb.AppendLine("delete from N_POOR_CODE ");
                sb.AppendLine("    where POOR_CD = @POOR_CD  ");

                SqlCommand sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@POOR_CD", txt_poor_cd);

                int qResult = wAdo.SqlCommandEtc(sCommand, "delete_POOR_TB");
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
        public void deleteCHK(string txt_chkCD)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb = new StringBuilder();
                sb.AppendLine("delete from N_CHK_CODE ");
                sb.AppendLine("    where CHK_CD = '" + txt_chkCD + "'  ");

                SqlCommand sCommand = new SqlCommand(sb.ToString());
                int qResult = wAdo.SqlCommandEtc(sCommand, "delete_POOR_TB");

                Debug.WriteLine(sb);
                return;
            }
            catch (Exception e)
            {
                wnLog.writeLog(wnLog.LOG_ERROR, e.Message + " - " + e.ToString());
                Popup.pop오류리포트 msg = new pop오류리포트(e.Message + " - " + e.ToString());
                msg.ShowDialog();
                return;
            }
        }
        public int deleteFlow(string txt_flow_cd)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb = new StringBuilder();
                sb.AppendLine("delete from N_FLOW_CODE ");
                sb.AppendLine("    where FLOW_CD = @FLOW_CD  ");

                SqlCommand sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@FLOW_CD", txt_flow_cd);

                int qResult = wAdo.SqlCommandEtc(sCommand, "delete_FLOW_TB");
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

        public int deleteRaw(string txt_raw_cd)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb = new StringBuilder();
                sb.AppendLine("delete from N_RAW_CODE ");
                sb.AppendLine("    where RAW_MAT_CD = @RAW_MAT_CD  ");

                SqlCommand sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@RAW_MAT_CD", txt_raw_cd);

                int qResult = wAdo.SqlCommandEtc(sCommand, "delete_RAW_TB");
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

        public int deleteCust(string txt_cust_cd, string cust_gbn)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb = new StringBuilder();
                sb.AppendLine("delete from N_CUST_CODE ");
                sb.AppendLine("    where CUST_CD = @CUST_CD ");
                sb.AppendLine("    and CUST_GUBUN = @CUST_GUBUN ");

                SqlCommand sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@CUST_CD", txt_cust_cd);
                sCommand.Parameters.AddWithValue("@CUST_GUBUN", cust_gbn);


                StringBuilder sb2 = new StringBuilder();
                sb2.AppendLine("  DELETE FROM T_거래처정보 ");
                sb2.AppendLine("  WHERE 사업자번호 = '" + Common.p_saupNo + "'  ");
                sb2.AppendLine("  AND 거래처코드 = '" + txt_cust_cd + "'  ");


                if (Common.sp_pack_gubun.Equals("1"))
                {
                    SqlCommand sCommand2 = new SqlCommand(sb2.ToString());

                    int qResult = wAdo.SqlCommandEtc_Jang(sCommand2, "insert_CUST_TB_JANG");
                    if (qResult > 0)
                    {

                        //cd랑 gubun이 주키 // 여기선 완전 삭제
                        int qResult2 = wAdo.SqlCommandEtc(sCommand, "delete_CUST_TB");
                        if (qResult2 > 0)
                        {
                            return 0;  // 0 true, 1 false
                        }
                        else return 1;
                    }
                    else
                    {
                        return 1;
                    }
                }
                else
                {
                    //cd랑 gubun이 주키 // 여기선 완전 삭제
                    int qResult2 = wAdo.SqlCommandEtc(sCommand, "delete_CUST_TB");
                    if (qResult2 > 0)
                    {
                        return 0;  // 0 true, 1 false
                    }
                    else return 1;
                }
            }
            catch (Exception e)
            {
                wnLog.writeLog(wnLog.LOG_ERROR, e.Message + " - " + e.ToString());
                Popup.pop오류리포트 msg = new pop오류리포트(e.Message + " - " + e.ToString());
                msg.ShowDialog();
                return 9;
            }
        }

        public int deleteChk(string txt_chk_cd, string chk_gbn)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb = new StringBuilder();
                sb.AppendLine("delete from N_CHK_CODE ");
                sb.AppendLine("    where CHK_CD = @CHK_CD ");
                sb.AppendLine("    and CHK_GUBUN = @CHK_GUBUN ");

                SqlCommand sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@CHK_CD", txt_chk_cd);
                sCommand.Parameters.AddWithValue("@CHK_GUBUN", chk_gbn);

                int qResult = wAdo.SqlCommandEtc(sCommand, "delete_CHK_TB");
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

        public int deleteItem(string txt_item_cd, string txt_link_cd)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb = new StringBuilder();
                sb.AppendLine("delete from N_ITEM_CODE ");
                sb.AppendLine("    where ITEM_CD = @ITEM_CD ");

                sb.AppendLine("delete from N_ITEM_COMP "); //제품구성
                sb.AppendLine("    where ITEM_CD = @ITEM_CD ");

                sb.AppendLine("delete from N_ITEM_FLOW "); //공정구성
                sb.AppendLine("    where ITEM_CD = @ITEM_CD ");

                sb.AppendLine("delete from N_ITEM_COMP_HALF "); //반제품구성
                sb.AppendLine("    where ITEM_CD = @ITEM_CD ");

                if (Common.sp_pack_gubun.Equals("1"))
                {
                    StringBuilder sb2 = new StringBuilder();
                    sb2.AppendLine("  DELETE FROM T_상품정보 ");
                    sb2.AppendLine("  WHERE 사업자번호 =   '" + Common.p_saupNo + "' ");
                    sb2.AppendLine("  AND 상품코드 =  '" + txt_link_cd + "' ");

                    SqlCommand sCommand2 = new SqlCommand(sb2.ToString());

                    int qResult = wAdo.SqlCommandEtc_Jang(sCommand2, "update_ITEM_TB_JANG");
                }
                

                SqlCommand sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@ITEM_CD", txt_item_cd);

                int qResult2 = wAdo.SqlCommandEtc(sCommand, "delete_ITEM_TB");
                if (qResult2 > 0)
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

        public int deleteFac(string txt_raw_cd)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb = new StringBuilder();
                sb.AppendLine("delete from N_FAC_CODE ");
                sb.AppendLine("    where FAC_CD = @FAC_CD  ");

                SqlCommand sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@FAC_CD", txt_raw_cd);

                int qResult = wAdo.SqlCommandEtc(sCommand, "delete_FAC_TB");
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


        public int deletePlan(string txt_plan_date, string plan_cd)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb = new StringBuilder();
                sb.AppendLine("delete from F_PLAN ");
                sb.AppendLine("    where PLAN_DATE = @PLAN_DATE ");
                sb.AppendLine("    and PLAN_CD = @PLAN_CD ");

                sb.AppendLine("delete from F_PLAN_DETAIL ");
                sb.AppendLine("    where PLAN_DATE = @PLAN_DATE ");
                sb.AppendLine("    and PLAN_CD = @PLAN_CD ");

                sb.AppendLine("delete from F_PLAN_GROUP ");
                sb.AppendLine("    where PLAN_DATE = @PLAN_DATE ");
                sb.AppendLine("    and PLAN_CD = @PLAN_CD ");

                SqlCommand sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@PLAN_DATE", txt_plan_date);
                sCommand.Parameters.AddWithValue("@PLAN_CD", plan_cd);

                int qResult = wAdo.SqlCommandEtc(sCommand, "delete_PLAN_TB");
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

        public int deleteOrder(string txt_plan_date, string plan_cd)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb = new StringBuilder();
                sb.AppendLine("delete from F_ORDER ");
                sb.AppendLine("    where ORDER_DATE = @ORDER_DATE ");
                sb.AppendLine("    and ORDER_CD = @ORDER_CD ");

                sb.AppendLine("delete from F_ORDER_DETAIL ");
                sb.AppendLine("    where ORDER_DATE = @ORDER_DATE ");
                sb.AppendLine("    and ORDER_CD = @ORDER_CD ");

                //sb.AppendLine("delete from F_PLAN_DETAIL ");
                //sb.AppendLine("    where PLAN_DATE = @PLAN_DATE ");
                //sb.AppendLine("    and PLAN_CD = @PLAN_CD ");

                SqlCommand sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@ORDER_DATE", txt_plan_date);
                sCommand.Parameters.AddWithValue("@ORDER_CD", plan_cd);

                int qResult = wAdo.SqlCommandEtc(sCommand, "delete_ORDER_TB");
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

        public int deleteInput(string txt_input_date, string txt_input_cd)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb = new StringBuilder();
                sb.AppendLine("delete from F_RAW_INPUT ");
                sb.AppendLine("    where INPUT_DATE = @INPUT_DATE ");
                sb.AppendLine("    and INPUT_CD = @INPUT_CD ");


                sb.AppendLine("delete from F_RAW_DETAIL ");
                sb.AppendLine("    where INPUT_DATE = @INPUT_DATE ");
                sb.AppendLine("    and INPUT_CD = @INPUT_CD ");


                SqlCommand sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@INPUT_DATE", txt_input_date);
                sCommand.Parameters.AddWithValue("@INPUT_CD", txt_input_cd);

                int qResult = wAdo.SqlCommandEtc(sCommand, "delete_RAW_INPUT_TB");
                if (qResult > 0)
                {
                    return 0;  // 0 true, 1 false
                }
                else return 1;
            }
            catch (Exception ex)
            {
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message +" - "+ex.ToString());
                msg.ShowDialog();
                wnLog.writeLog(wnLog.LOG_ERROR, ex.Message + " - " + ex.ToString());
                return 9;
            }
        }

        public DataTable isRawOut(string txt_input_date, string txt_input_cd)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb = new StringBuilder();
                sb.AppendLine("SELECT * FROM F_RAW_OUTPUT ");
                sb.AppendLine("    where INPUT_DATE = @INPUT_DATE ");
                sb.AppendLine("    and INPUT_CD = @INPUT_CD ");

                SqlCommand sCommand = new SqlCommand(sb.ToString());
                if (sCommand.CommandText.Equals(null))
                {
                    wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                    return null;
                }


                sCommand.Parameters.AddWithValue("@INPUT_DATE", txt_input_date);
                sCommand.Parameters.AddWithValue("@INPUT_CD", txt_input_cd);


                return wAdo.SqlCommandSelect(sCommand);


            }
            catch (Exception ex)
            {
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message +" - "+ex.ToString());
                msg.ShowDialog();
                wnLog.writeLog(wnLog.LOG_ERROR, ex.Message + " - " + ex.ToString());
                return null;
            }
        }

        public int deleteWork(string txt_work_date, string txt_work_cd)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb = new StringBuilder();
                sb.AppendLine("delete from F_WORK_INST ");
                sb.AppendLine("    where W_INST_DATE = @W_INST_DATE ");
                sb.AppendLine("    and W_INST_CD = @W_INST_CD ");


                sb.AppendLine("delete from F_WORK_INST_DETAIL ");
                sb.AppendLine("    where W_INST_DATE = @W_INST_DATE ");
                sb.AppendLine("    and W_INST_CD = @W_INST_CD ");

                sb.AppendLine("delete from F_WORK_INST_HALF_DETAIL ");
                sb.AppendLine("    where W_INST_DATE = @W_INST_DATE ");
                sb.AppendLine("    and W_INST_CD = @W_INST_CD ");
                SqlCommand sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@W_INST_DATE", txt_work_date);
                sCommand.Parameters.AddWithValue("@W_INST_CD", txt_work_cd);

                int qResult = wAdo.SqlCommandEtc(sCommand, "delete_RAW_WORK_TB");
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

        public int deleteWorkFlow(string txt_lot_no)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb = new StringBuilder();
                sb.AppendLine("delete from F_WORK_FLOW ");
                sb.AppendLine("    where LOT_NO = @LOT_NO ");


                sb.AppendLine("delete from F_WORK_FLOW_DETAIL ");
                sb.AppendLine("    where LOT_NO = @LOT_NO ");

                sb.AppendLine("delete from F_ITEM_INPUT ");
                sb.AppendLine("    where LOT_NO = @LOT_NO ");


                SqlCommand sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@LOT_NO", txt_lot_no);

                int qResult = wAdo.SqlCommandEtc(sCommand, "delete_WORK_FLOW_TB");
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

        public int deleteItemOut(string out_date, string out_cd, string jang_cd)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb = new StringBuilder();
                sb.AppendLine("delete from F_ITEM_OUT ");
                sb.AppendLine("    where OUTPUT_DATE = @OUTPUT_DATE ");
                sb.AppendLine("    and OUTPUT_CD = @OUTPUT_CD ");


                sb.AppendLine("delete from F_ITEM_OUT_DETAIL ");
                sb.AppendLine("    where OUTPUT_DATE = @OUTPUT_DATE ");
                sb.AppendLine("    and OUTPUT_CD = @OUTPUT_CD ");

                SqlCommand sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@OUTPUT_DATE", out_date);
                sCommand.Parameters.AddWithValue("@OUTPUT_CD", out_cd);


                if (Common.sp_pack_gubun.Equals("1"))
                {
                    StringBuilder sb2 = new StringBuilder();

                    sb2.AppendLine(" DELETE FROM T_매출 ");
                    sb2.AppendLine(" WHERE 사업자번호 = '" + Common.p_saupNo + "' ");
                    sb2.AppendLine(" and 지점코드 = '0' ");
                    sb2.AppendLine(" and 매출일자 = '" + out_date + "' ");
                    sb2.AppendLine(" and 전표번호 = '" + jang_cd + "' ");

                    sb2.AppendLine(" DELETE FROM T_매출항목 ");
                    sb2.AppendLine(" WHERE 사업자번호 = '" + Common.p_saupNo + "' ");
                    sb2.AppendLine(" and 지점코드 = '0' ");
                    sb2.AppendLine(" and 매출일자 = '" + out_date + "' ");
                    sb2.AppendLine(" and 전표번호 = '" + jang_cd + "' ");


                    SqlCommand sCommand2 = new SqlCommand(sb2.ToString());
                    int qResult = wAdo.SqlCommandEtc_Jang(sCommand2, "delete_ITEM_OUTPUT_JANG_TB");
                    if (qResult > 0)
                    {
                        int qResult2 = wAdo.SqlCommandEtc(sCommand, "delete_ITEM_OUTPUT_TB");
                        if (qResult2 > 0)
                        {
                            return 0;  // 0 true, 1 false
                        }
                        else return 1;
                    }
                    else return 1;


                }
                else
                {
                    int qResult = wAdo.SqlCommandEtc(sCommand, "delete_ITEM_OUTPUT_TB");
                    if (qResult > 0)
                    {
                        return 0;  // 0 true, 1 false
                    }
                    else return 1;
                }
            }
            catch (Exception e)
            {
                wnLog.writeLog(wnLog.LOG_ERROR, e.Message + " - " + e.ToString());
                Popup.pop오류리포트 msg = new pop오류리포트(e.Message + " - " + e.ToString());
                msg.ShowDialog();
                return 9;
            }
        }

        public int deleteFlowChk(string txt_item_cd, string txt_flow_cd)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb = new StringBuilder();
                sb.AppendLine("delete from N_FLOW_CHK ");
                sb.AppendLine("    where ITEM_CD = @ITEM_CD ");
                sb.AppendLine("     and FLOW_CD = @FLOW_CD ");

                sb.AppendLine("delete from N_FLOW_CHK_STAN "); //공정항목 상세
                sb.AppendLine("    where ITEM_CD = @ITEM_CD ");
                sb.AppendLine("     and FLOW_CD = @FLOW_CD ");


                SqlCommand sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@ITEM_CD", txt_item_cd);
                sCommand.Parameters.AddWithValue("@FLOW_CD", txt_flow_cd);

                int qResult = wAdo.SqlCommandEtc(sCommand, "delete_FLOW_CHK_TB");
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

        public int deleteItemChk(string txt_item_cd)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb = new StringBuilder();
                sb.AppendLine("delete from N_ITEM_CHK ");
                sb.AppendLine("    where ITEM_CD = @ITEM_CD ");

                sb.AppendLine("delete from N_ITEM_CHK_STAN "); //제품항목 상세
                sb.AppendLine("    where ITEM_CD = @ITEM_CD ");


                SqlCommand sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@ITEM_CD", txt_item_cd);

                int qResult = wAdo.SqlCommandEtc(sCommand, "delete_ITEM_CHK_TB");
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

        #region haccp
        public int haccp_flow(
              string cmb_cd
            , string txt_nm
            , string txt_cd
            , string haccp_yn)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                SqlCommand sCommand = new SqlCommand(sb.ToString());
                if (sCommand.CommandText.Equals(null))
                {
                    wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                    return 2;
                }
                DataTable dt = wAdo.SqlCommandSelect(sCommand);

                sb.AppendLine("declare @seq int ");
                sb.AppendLine("select @seq =ISNULL(MAX(CHK_ORD),0)+1 from N_HACCP_CHK ");
                sb.AppendLine("WHERE FLOW_CD = @FLOW_CD ");

                sb.AppendLine("insert into N_HACCP_CHK(");
                sb.AppendLine("     FLOW_CD ");
                sb.AppendLine("     ,CHK_CD ");
                sb.AppendLine("     ,CHK_ORD ");
                sb.AppendLine("     ,CHK_NM ");
                sb.AppendLine("     ,USE_YN ");
                sb.AppendLine(" ) values ( ");
                sb.AppendLine("     @FLOW_CD ");
                sb.AppendLine("     ,@CHK_CD ");
                sb.AppendLine("     ,@seq ");
                sb.AppendLine("     ,@CHK_NM ");
                sb.AppendLine("     ,@USE_YN ");
                sb.AppendLine(" ) ");

                sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@FLOW_CD", cmb_cd);
                sCommand.Parameters.AddWithValue("@CHK_CD", txt_cd);
                sCommand.Parameters.AddWithValue("@CHK_NM", txt_nm);
                sCommand.Parameters.AddWithValue("@USE_YN", haccp_yn);

                int qResult = wAdo.SqlCommandEtc(sCommand, "insert_HACCP_TB");
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

        public int haccp_update(
        string cmb_cd
    , string txt_nm
    , string txt_cd
    , string haccp_yn)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                SqlCommand sCommand = new SqlCommand(sb.ToString());
                if (sCommand.CommandText.Equals(null))
                {
                    wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                    return 2;
                }
                DataTable dt = wAdo.SqlCommandSelect(sCommand);

                sb.AppendLine(" update N_HACCP_CHK ");
                sb.AppendLine(" set ");
                sb.AppendLine(" CHK_NM = @CHK_NM ");
                sb.AppendLine(" , USE_YN = @USE_YN ");
                sb.AppendLine(" WHERE FLOW_CD = @FLOW_CD AND CHK_CD = @CHK_CD ");

                sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@FLOW_CD", cmb_cd);
                sCommand.Parameters.AddWithValue("@CHK_CD", txt_cd);
                sCommand.Parameters.AddWithValue("@CHK_NM", txt_nm);
                sCommand.Parameters.AddWithValue("@USE_YN", haccp_yn);

                int qResult = wAdo.SqlCommandEtc(sCommand, "insert_HACCP_TB");
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

        public DataTable haccp_Grid_List(string condition)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("select FLOW_CD");
            sb.AppendLine("     ,CHK_CD ");
            sb.AppendLine("     ,CHK_ORD ");
            sb.AppendLine("     ,CHK_NM ");
            sb.AppendLine("     ,USE_YN ");
            sb.AppendLine("     ,(SELECT FLOW_NM FROM N_FLOW_CODE WHERE FLOW_CD = A.FLOW_CD) AS FLOW_NM  ");
            sb.AppendLine(" from N_HACCP_CHK A");
            sb.AppendLine(condition);
            sb.AppendLine(" order by FLOW_CD");

            Console.WriteLine(sb.ToString());

            SqlCommand sCommand = new SqlCommand(sb.ToString());

            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable cust_Grid_List(string condition, string condition2)
        //구매처원장 검색
        {

            StringBuilder sb = new StringBuilder();

            //sb.AppendLine("select A.ORDER_DATE, A.ORDER_CD, A.SEQ, A.RAW_MAT_CD, A.SPEC, A.UNIT_CD, A.TOTAL_AMT, A.PRICE, B.COMPLETE_YN ");
            //sb.AppendLine("from F_ORDER_DETAIL A ");
            //sb.AppendLine("LEFT OUTER JOIN F_ORDER B  ON A.ORDER_DATE = B.ORDER_DATE ");
            //sb.AppendLine("LEFT OUTER JOIN F_ORDER C ON C.CUST_CD = B.CUST_CD  ");
            //sb.AppendLine("WHERE B.COMPLETE_YN = 'Y' ");
            //sb.AppendLine(condition);
            //sb.AppendLine(condition2);
            //sb.AppendLine("order by ORDER_DATE ");

            sb.AppendLine(" select  (CASE WHEN ORDER_DATE='' THEN '미발주' ELSE ORDER_DATE end) as ORDER_DATE,    ");
            sb.AppendLine(" 		c.INPUT_DATE, ");
            sb.AppendLine(" 		D.RAW_MAT_NM,   ");
            sb.AppendLine("		C.SEQ, ");
            sb.AppendLine("		C.SPEC, ");
            sb.AppendLine(" 		C.RAW_MAT_CD,  ");
            sb.AppendLine(" 	CONVERT(INT,c.TOTAL_AMT) as TOTAL_AMT,  ");
            sb.AppendLine(" 	 	CONVERT(INT,c.PRICE) as PRICE,  ");
            sb.AppendLine(" 		CONVERT(INT,c.TOTAL_MONEY) as TOTAL_MONEY,  ");
            sb.AppendLine(" 		G.CUST_NM,  ");
            sb.AppendLine(" 		g.cust_CD, ");
            sb.AppendLine("c.COMPLETE_YN ");
            sb.AppendLine(" from F_RAW_DETAIL C  ");
            sb.AppendLine(" inner join N_RAW_CODE D on D.RAW_MAT_CD=C.RAW_MAT_CD  ");
            sb.AppendLine(" left join F_RAW_INPUT as F on f.INPUT_CD=C.INPUT_CD and f.INPUT_DATE=C.INPUT_DATE ");
            sb.AppendLine("  inner join N_CUST_CODE as G on G.CUST_CD=F.CUST_CD ");
            sb.Append("where ");
            sb.AppendLine(condition2);

            sb.AppendLine(condition);
            sb.AppendLine("    union all  ");
            sb.AppendLine("   select '9999-99-99' as ORDER_DATE ,'9999-99-99' as INPUT_DATE,'','','','',sum(C.TOTAL_AMT) as TOTAL_AMT ,'',SUM(C.TOTAL_MONEY) as TOTAL_MONEY ,G.CUST_NM,g.cust_CD,''  ");
            sb.AppendLine("  from F_RAW_DETAIL as C  ");
            sb.AppendLine("   left join F_RAW_INPUT as F on f.INPUT_CD=C.INPUT_CD and f.INPUT_DATE=C.INPUT_DATE ");
            sb.AppendLine("    inner join N_CUST_CODE as G on G.CUST_CD=F.CUST_CD  ");
            sb.Append("where ");

            sb.AppendLine(condition2);

            sb.AppendLine(condition);
            sb.AppendLine("   group by G.cust_CD ,G.CUST_NM ");

            sb.AppendLine("  order by G.CUST_CD,c.INPUT_DATE,c.SEQ  ");



            //sb.AppendLine("select A.ORDER_DATE, A.ORDER_CD, A.SEQ, c.RAW_MAT_NM,A.RAW_MAT_CD, c.SPEC, A.UNIT_CD, A.TOTAL_AMT, A.PRICE, B.COMPLETE_YN    ");
            //sb.AppendLine("from F_ORDER_DETAIL A    ");
            //sb.AppendLine("inner JOIN F_ORDER B  ON A.ORDER_DATE = B.ORDER_DATE  and A.ORDER_CD=B.ORDER_CD   ");
            //sb.AppendLine("inner join N_RAW_CODE c on c.RAW_MAT_CD=A.RAW_MAT_CD   ");
            //sb.AppendLine("WHERE B.COMPLETE_YN = 'Y'    ");
            //sb.AppendLine("order by ORDER_DATE    ");
            //sb.AppendLine(condition);
            //sb.AppendLine(condition2);


            Debug.WriteLine(sb.ToString());

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable noticeList(string condition)
        //공지사항 검색
        {

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("select * ");
            sb.AppendLine("from N_NOTICE ");
            //sb.AppendLine("LEFT OUTER JOIN F_ORDER B  ON A.ORDER_DATE = B.ORDER_DATE ");
            //sb.AppendLine("LEFT OUTER JOIN F_ORDER C ON C.CUST_CD = sCode ");
            //sb.AppendLine("WHERE B.COMPLETE_YN = 'Y' ");                    
            sb.AppendLine(condition);
            sb.AppendLine("    order by intime DESC ");

            Debug.WriteLine(sb.ToString());

            SqlCommand sCommand = new SqlCommand(sb.ToString());

            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            return wAdo.SqlCommandSelect(sCommand);
        }

        public int insertNotice(string textBox2, string textBox3)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb.AppendLine(" select count(*) as cnt");
                sb.AppendLine(" from N_NOTICE");
                // sb.AppendLine(" where poor_cd = '" + txt_poor_cd + "'");

                SqlCommand sCommand = new SqlCommand(sb.ToString());
                if (sCommand.CommandText.Equals(null))
                {
                    wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                    return 2;
                }
                DataTable dt = wAdo.SqlCommandSelect(sCommand);

                //if (!dt.Rows[0]["cnt"].ToString().Equals("0"))
                //{
                //    return 3;
                //}

                sb = new StringBuilder();

                sb.AppendLine("declare @SEQ int ");
                sb.AppendLine("select @SEQ = ISNULL(MAX(SEQ),0)+1 from N_NOTICE ");
                //sb.AppendLine("where ITEM_CD = '" + txt_item_cd + "' ");

                sb.AppendLine("insert into N_NOTICE(");
                sb.AppendLine("     SEQ ");
                sb.AppendLine("     ,TITLE ");
                sb.AppendLine("     ,CONTENT ");
                sb.AppendLine("     ,INTIME ");
                sb.AppendLine("     ,INSTAFF ");
                sb.AppendLine(" ) values ( ");
                sb.AppendLine("  @SEQ ");
                sb.AppendLine(" ,@TITLE ");
                sb.AppendLine(" ,@CONTENT ");
                sb.AppendLine("     ,convert(varchar, getdate(), 120) ");
                sb.AppendLine("     ,'" + Common.p_strStaffNo + "' ");
                //sb.AppendLine(" ,@INTIME ");
                //sb.AppendLine(" ,@INSTAFF ");
                sb.AppendLine(" ) ");




                sCommand = new SqlCommand(sb.ToString());

                //sCommand.Parameters.AddWithValue("@SEQ", textBox1);
                sCommand.Parameters.AddWithValue("@TITLE", textBox2);
                sCommand.Parameters.AddWithValue("@CONTENT", textBox3);
                //sCommand.Parameters.AddWithValue("@INTIME", dTP1);
                //sCommand.Parameters.AddWithValue("@INSTAFF", textBox5);                

                int qResult = wAdo.SqlCommandEtc(sCommand, "insertNOTICE");
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
        public int deleteNotice(string textBox1)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb = new StringBuilder();

                sb.AppendLine("DELETE FROM N_NOTICE  ");
                sb.AppendLine("WHERE SEQ = @SEQ ");
                //sb.AppendLine("AND INSTAFF = @INSTAFF");              

                SqlCommand sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@SEQ", textBox1);
                //sCommand.Parameters.AddWithValue("@INSTAFF", input_cd);

                int qResult = wAdo.SqlCommandEtc(sCommand, "deleteNotice");
                if (qResult > 0)
                {
                    return 0;
                }
                else return 1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + " - " + e.ToString());
                wnLog.writeLog(wnLog.LOG_ERROR, e.Message + " - " + e.ToString());
                return 9;
            }
        }

        public int updateNotice(string textBox1, string textBox2, string textBox3)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                //sb.AppendLine(" select *");
                //sb.AppendLine(" from N_NOTICE");
                //sb.AppendLine(" where poor_cd = '" + txt_poor_cd + "'");

                SqlCommand sCommand = new SqlCommand(sb.ToString());
                if (sCommand.CommandText.Equals(null))
                {
                    wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                    return 2;
                }
                DataTable dt = wAdo.SqlCommandSelect(sCommand);


                sb = new StringBuilder();
                sb.AppendLine("update N_NOTICE SET ");
                // sb.AppendLine("     SEQ = @SEQ ");
                sb.AppendLine("     TITLE = @sTITLE ");
                sb.AppendLine("     ,CONTENT = @sCONTENT ");

                sb.AppendLine("    where SEQ = @SEQ  ");

                sb.AppendLine("  ");

                //sb.AppendLine("Update F_HACCP_CHK SET ");
                //sb.AppendLine("     COMMENT = @COMMENT ");
                //sb.AppendLine("     ,UPSTAFF =  '" + Common.p_strStaffNo + "' ");
                //sb.AppendLine("     ,UPTIME =  convert(varchar, getdate(), 120)");
                //sb.AppendLine("     WHERE INPUT_DATE = @INPUT_DATE and INPUT_CD = @seq");

                sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@SEQ", textBox1);
                sCommand.Parameters.AddWithValue("@sTITLE", textBox2);
                sCommand.Parameters.AddWithValue("@sCONTENT", textBox3);

                int qResult = wAdo.SqlCommandEtc(sCommand, "updateNotice");
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


        public int getStaffName(string staff_cd, TextBox staff_nm)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb = new StringBuilder();
                sb.AppendLine("SELECT STAFF_NM FROM N_STAFF_CODE ");
                sb.AppendLine("WHERE STAFF_CD = @STAFF_CD");



                SqlCommand sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@STAFF_CD", staff_cd);

                DataTable dt = wAdo.SqlCommandSelect(sCommand);

                if (dt.Rows.Count == 1)
                {

                    staff_nm.Text = dt.Rows[0][0].ToString();

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

        public DataTable getHaccpGrid()
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb = new StringBuilder();
                sb.AppendLine("SELECT *  ");
                sb.AppendLine("  ,  (SELECT FLOW_NM FROM N_FLOW_CODE where FLOW_CD = A.FLOW_CD) AS FLOW_NM  ");
                sb.AppendLine(" FROM N_HACCP_CHK A ");
                sb.AppendLine("WHERE USE_YN = 'Y' ");
                sb.AppendLine("ORDER BY FLOW_CD, CHK_ORD ");



                SqlCommand sCommand = new SqlCommand(sb.ToString());

                DataTable dt = wAdo.SqlCommandSelect(sCommand);

                if (dt.Rows.Count > 0)
                {
                    return wAdo.SqlCommandSelect(sCommand);
                }
                else return null;
            }
            catch (Exception e)
            {
                wnLog.writeLog(wnLog.LOG_ERROR, e.Message + " - " + e.ToString());
                Popup.pop오류리포트 msg = new pop오류리포트(e.Message + " - " + e.ToString());
                msg.ShowDialog();
                return null;
            }
        }


        public int Insert_Haccp_Input(
              string input_date
            , string comment
            , DataGridView ccpChkGrid
            )
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb = new StringBuilder();
                sb.AppendLine("declare @seq int ");
                sb.AppendLine("select @seq =ISNULL(MAX(INPUT_CD),0)+1 from F_HACCP_CHK ");
                sb.AppendLine("where INPUT_DATE = '" + input_date + "' ");

                Console.WriteLine(sb.ToString());

                sb.AppendLine("insert into F_HACCP_CHK(");
                sb.AppendLine("     INPUT_DATE");
                sb.AppendLine("     ,INPUT_CD ");
                sb.AppendLine("     ,COMMENT ");
                sb.AppendLine("     ,INSTAFF ");
                sb.AppendLine("     ,INTIME ");
                sb.AppendLine(" ) values ( ");
                sb.AppendLine("      @INPUT_DATE ");
                sb.AppendLine("     ,@seq");
                sb.AppendLine("     ,@COMMENT ");
                sb.AppendLine("     ,'" + Common.p_strStaffNo + "' ");
                sb.AppendLine("     ,convert(varchar, getdate(), 120) ");
                sb.AppendLine(" ) ");

                if (ccpChkGrid.Rows.Count > 0)
                {
                    for (int i = 0; i < ccpChkGrid.Rows.Count; i++)
                    {
                        sb.AppendLine("declare @item_seq" + (i) + " int ");
                        sb.AppendLine("select @item_seq" + (i) + " =ISNULL(MAX(SEQ),0)+1 from F_HACCP_DETAIL ");
                        sb.AppendLine("where INPUT_DATE = '" + input_date + "' ");
                        sb.AppendLine("and INPUT_CD =  @seq ");


                        sb.AppendLine("insert into F_HACCP_DETAIL(  ");
                        sb.AppendLine("     INPUT_DATE  ");
                        sb.AppendLine("     ,INPUT_CD  ");
                        sb.AppendLine("     ,SEQ  ");
                        sb.AppendLine("     ,FLOW_CD  ");
                        sb.AppendLine("     ,CHK_CD  ");
                        sb.AppendLine("     ,CHK_ORD  ");
                        sb.AppendLine("     ,CHK_NM  ");
                        sb.AppendLine("     ,CHK_VALUE  ");
                        sb.AppendLine("     ,INSTAFF  ");
                        sb.AppendLine("     ,INTIME  ");
                        sb.AppendLine(" ) values ( ");
                        sb.AppendLine("      @INPUT_DATE ");
                        sb.AppendLine("      ,@seq ");
                        sb.AppendLine("      ,@item_seq" + (i) + "   ");
                        sb.AppendLine("      ,'" + ccpChkGrid.Rows[i].Cells["FLOW_CD"].Value + "'    ");
                        sb.AppendLine("      ,'" + ccpChkGrid.Rows[i].Cells["CHK_CD"].Value + "'    ");
                        sb.AppendLine("      ,'" + ccpChkGrid.Rows[i].Cells["CHK_ORD"].Value + "'    ");
                        sb.AppendLine("      ,'" + ccpChkGrid.Rows[i].Cells["CHK_NM"].Value + "'    ");
                        sb.AppendLine("      ,'" + (ccpChkGrid.Rows[i].Cells["YES"].Value.ToString().Equals("True") ? "Y" : "N") + "'    ");
                        sb.AppendLine("     ,'" + Common.p_strStaffNo + "' ");
                        sb.AppendLine("     ,convert(varchar, getdate(), 120) ");
                        sb.AppendLine(" ) ");




                    }
                }


                SqlCommand sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@INPUT_DATE", input_date);
                sCommand.Parameters.AddWithValue("@COMMENT", comment);


                int qResult = wAdo.SqlCommandEtc(sCommand, "insert_Haccp_INPUT");
                if (qResult > 0)
                {
                    return 0;
                }
                else return 1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + " - " + e.ToString());
                wnLog.writeLog(wnLog.LOG_ERROR, e.Message + " - " + e.ToString());
                return 9;
            }
        }


        public int Update_Haccp_Input(
              string input_date
            , string input_cd
            , string comment
            , DataGridView ccpChkGrid
            )
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb = new StringBuilder();



                Console.WriteLine(sb.ToString());


                sb.AppendLine("Update F_HACCP_CHK SET ");
                sb.AppendLine("     COMMENT = @COMMENT ");
                sb.AppendLine("     ,UPSTAFF =  '" + Common.p_strStaffNo + "' ");
                sb.AppendLine("     ,UPTIME =  convert(varchar, getdate(), 120)");
                sb.AppendLine("     WHERE INPUT_DATE = @INPUT_DATE and INPUT_CD = @seq");


                if (ccpChkGrid.Rows.Count > 0)
                {
                    for (int i = 0; i < ccpChkGrid.Rows.Count; i++)
                    {

                        sb.AppendLine("Update F_HACCP_DETAIL SET ");
                        sb.AppendLine("      CHK_VALUE = '" + (ccpChkGrid.Rows[i].Cells["YES"].Value.ToString().Equals("True") ? "Y" : "N") + "'    ");
                        sb.AppendLine("     ,UPSTAFF =  '" + Common.p_strStaffNo + "' ");
                        sb.AppendLine("     ,UPTIME =  convert(varchar, getdate(), 120)");
                        sb.AppendLine("     WHERE INPUT_DATE = @INPUT_DATE and INPUT_CD = @seq and CHK_CD = '" + ccpChkGrid.Rows[i].Cells["CHK_CD"].Value + "'");

                    }
                }


                SqlCommand sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@INPUT_DATE", input_date);
                sCommand.Parameters.AddWithValue("@seq", input_cd);
                sCommand.Parameters.AddWithValue("@COMMENT", comment);


                int qResult = wAdo.SqlCommandEtc(sCommand, "update_Haccp_INPUT");
                if (qResult > 0)
                {
                    return 0;
                }
                else return 1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + " - " + e.ToString());
                wnLog.writeLog(wnLog.LOG_ERROR, e.Message + " - " + e.ToString());
                return 9;
            }
        }


        public DataTable fn_Haccp_input_list(string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select INPUT_DATE");
            sb.AppendLine("     ,INPUT_CD ");
            sb.AppendLine("     ,(select STAFF_NM from N_STAFF_CODE where STAFF_CD = A.INSTAFF) as STAFF_NM  ");
            sb.AppendLine("     ,INSTAFF AS STAFF_CD ");
            sb.AppendLine("     ,COMMENT ");
            sb.AppendLine(" from F_HACCP_CHK A");
            sb.AppendLine(condition);
            sb.AppendLine(" order by INPUT_DATE desc, INPUT_CD desc ");

            Console.WriteLine(sb.ToString());

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            return wAdo.SqlCommandSelect(sCommand);

        }

        public DataTable fn_Haccp_Detail_List(string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select A.INPUT_DATE");
            sb.AppendLine("     ,A.INPUT_CD");
            sb.AppendLine("     ,A.FLOW_CD ");
            sb.AppendLine("     ,(SELECT FLOW_NM FROM N_FLOW_CODE where FLOW_CD = A.FLOW_CD) AS FLOW_NM ");
            sb.AppendLine("     ,A.CHK_CD");
            sb.AppendLine("     ,A.CHK_NM ");
            sb.AppendLine("     ,A.CHK_ORD ");
            sb.AppendLine("     ,A.CHK_VALUE ");
            sb.AppendLine("     ,CASE WHEN A.CHK_VALUE = 'Y' THEN 'V' ELSE ' ' end AS YES ");
            sb.AppendLine("     ,CASE WHEN A.CHK_VALUE = 'N' THEN 'V' ELSE ' ' end AS NO ");
            sb.AppendLine("     ,A.INSTAFF ");
            sb.AppendLine("     ,(select STAFF_NM from N_STAFF_CODE where STAFF_CD = A.INSTAFF) as STAFF_NM");
            sb.AppendLine(" from F_HACCP_DETAIL A");
            sb.AppendLine(condition);
            sb.AppendLine(" order by A.SEQ ");



            Console.WriteLine(sb.ToString());

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            return wAdo.SqlCommandSelect(sCommand);

        }

        public int Delete_Haccp_Input(
           string input_date
           , string input_cd
           )
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb = new StringBuilder();

                sb.AppendLine("DELETE FROM F_HACCP_CHK  ");
                sb.AppendLine("WHERE INPUT_DATE = @INPUT_DATE ");
                sb.AppendLine("AND INPUT_CD = @INPUT_CD");

                sb.AppendLine("DELETE FROM F_HACCP_DETAIL  ");
                sb.AppendLine("WHERE INPUT_DATE = @INPUT_DATE ");
                sb.AppendLine("AND INPUT_CD = @INPUT_CD");

                SqlCommand sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@INPUT_DATE", input_date);
                sCommand.Parameters.AddWithValue("@INPUT_CD", input_cd);


                int qResult = wAdo.SqlCommandEtc(sCommand, "delete_haccp_INPUT");
                if (qResult > 0)
                {
                    return 0;
                }
                else return 1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + " - " + e.ToString());
                wnLog.writeLog(wnLog.LOG_ERROR, e.Message + " - " + e.ToString());
                return 9;
            }
        }

        #endregion haccp

        #region 사업자관리
        // 사업자정보 조회

        public DataTable fn_Saup_List(string saup_no)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select A.SAUP_NO");
            sb.AppendLine("     ,B.COMPANY_NM ");
            sb.AppendLine("     ,A.CORPORATE_NO");
            sb.AppendLine("     ,A.UPTAE ");
            sb.AppendLine("     ,A.JONGMOK ");
            sb.AppendLine("     ,A.POST_NO ");
            sb.AppendLine("     ,A.ADDR ");
            sb.AppendLine("     ,A.ADDR2 ");
            sb.AppendLine("     ,A.OPEN_DATE ");
            sb.AppendLine("     ,A.COMP_PHONE ");
            sb.AppendLine("     ,A.FAX ");
            sb.AppendLine("     ,A.MANAGER_EMAIL ");
            sb.AppendLine("     ,A.MANAGER_PHONE ");
            sb.AppendLine("     ,A.HOMEPAGE ");
            sb.AppendLine("     ,A.SAUP_LOGO ");
            sb.AppendLine("     ,A.LOGO_SIZE ");
            sb.AppendLine(" from [SM_FACTORY_COM].[dbo].[T_SAUP_CODE] A");
            sb.AppendLine(" inner join [SM_FACTORY_COM].[dbo].[T_COMP_LOGIN] B ");
            sb.AppendLine(" on A.SAUP_NO = B.COM_SAUP_NO ");
            sb.AppendLine("where A.SAUP_NO = '" + saup_no + "' ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            return wAdo.SqlCommandSelect(sCommand);
        }

        public int updateSaup(string saup_no
                , string saup_nm
                , string corporate_no
                , string uptae
                , string jongmok
                , string open_date
                , string post_no
                , string addr
                , string addr2
                , string comp_phone
                , string fax
                , string mg_email
                , string mg_phone
                , string homepage
                , byte[] img
                , int img_size
                , string ori_saup_nm)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb = new StringBuilder();
                sb.AppendLine("declare @chk int  ");
                sb.AppendLine("select @chk = COUNT(*) from [SM_FACTORY_COM].[dbo].[T_SAUP_CODE] ");
                sb.AppendLine("where SAUP_NO = '" + saup_no + "' ");

                sb.AppendLine("IF(@chk > 0)"); //공정항목 상세
                sb.AppendLine(" update [SM_FACTORY_COM].[dbo].[T_SAUP_CODE] ");
                sb.AppendLine(" set CORPORATE_NO = @CORPORATE_NO");
                sb.AppendLine("    ,UPTAE = @UPTAE ");
                sb.AppendLine("    ,JONGMOK = @JONGMOK ");
                sb.AppendLine("    ,POST_NO = @POST_NO ");
                sb.AppendLine("    ,ADDR = @ADDR ");
                sb.AppendLine("    ,ADDR2 = @ADDR2 ");
                sb.AppendLine("    ,OPEN_DATE = @OPEN_DATE ");
                sb.AppendLine("    ,COMP_PHONE = @COMP_PHONE ");
                sb.AppendLine("    ,FAX = @FAX ");
                sb.AppendLine("    ,MANAGER_EMAIL = @MANAGER_EMAIL ");
                sb.AppendLine("    ,MANAGER_PHONE = @MANAGER_PHONE ");
                sb.AppendLine("    ,HOMEPAGE = @HOMEPAGE ");
                if (img_size > 0)
                {
                    sb.AppendLine("    ,SAUP_LOGO = @SAUP_LOGO ");
                    sb.AppendLine("    ,LOGO_SIZE = @LOGO_SIZE ");
                }
                else
                {
                    sb.AppendLine("     ,SAUP_LOGO=null ");
                    sb.AppendLine("     ,LOGO_SIZE=0 ");
                }
                sb.AppendLine("where SAUP_NO = '" + saup_no + "' ");

                sb.AppendLine("ELSE ");
                sb.AppendLine(" insert into [SM_FACTORY_COM].[dbo].[T_SAUP_CODE] ( ");
                sb.AppendLine("      SAUP_NO ");
                sb.AppendLine("     ,CORPORATE_NO ");
                sb.AppendLine("     ,UPTAE ");
                sb.AppendLine("     ,JONGMOK ");
                sb.AppendLine("     ,POST_NO ");
                sb.AppendLine("     ,ADDR ");
                sb.AppendLine("     ,ADDR2 ");
                sb.AppendLine("     ,OPEN_DATE ");
                sb.AppendLine("     ,COMP_PHONE ");
                sb.AppendLine("     ,FAX ");
                sb.AppendLine("     ,MANAGER_EMAIL ");
                sb.AppendLine("     ,MANAGER_PHONE ");
                sb.AppendLine("     ,HOMEPAGE ");
                sb.AppendLine("     ,SAUP_LOGO ");
                sb.AppendLine("     ,LOGO_SIZE ");
                sb.AppendLine(" )VALUES( ");
                sb.AppendLine("      @SAUP_NO ");
                sb.AppendLine("     ,@CORPORATE_NO ");
                sb.AppendLine("     ,@UPTAE ");
                sb.AppendLine("     ,@JONGMOK ");
                sb.AppendLine("     ,@POST_NO ");
                sb.AppendLine("     ,@ADDR ");
                sb.AppendLine("     ,@ADDR2 ");
                sb.AppendLine("     ,@OPEN_DATE ");
                sb.AppendLine("     ,@COMP_PHONE ");
                sb.AppendLine("     ,@FAX ");
                sb.AppendLine("     ,@MANAGER_EMAIL ");
                sb.AppendLine("     ,@MANAGER_PHONE ");
                sb.AppendLine("     ,@HOMEPAGE ");
                if (img_size > 0)
                {
                    sb.AppendLine("     ,@SAUP_LOGO ");
                    sb.AppendLine("     ,@LOGO_SIZE ");
                }
                else
                {
                    sb.AppendLine("     ,null ");
                    sb.AppendLine("     ,0 ");
                }
                sb.AppendLine("  )  ");

                if (!saup_nm.Trim().ToString().Equals(ori_saup_nm.Trim().ToString()))
                {
                    sb.AppendLine(" update [SM_FACTORY_COM].[dbo].[T_COMP_LOGIN] ");
                    sb.AppendLine(" set COMPANY_NM = '" + saup_nm.Trim().ToString() + "' ");
                    sb.AppendLine("where COM_SAUP_NO = '" + saup_no + "' ");

                    Common.p_strCompNm = saup_no.Trim().ToString();
                }

                SqlCommand sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@SAUP_NO", saup_no);
                //sCommand.Parameters.AddWithValue("@SAUP_NM", saup_nm);
                sCommand.Parameters.AddWithValue("@CORPORATE_NO", corporate_no);
                sCommand.Parameters.AddWithValue("@UPTAE", uptae);
                sCommand.Parameters.AddWithValue("@JONGMOK", jongmok);
                sCommand.Parameters.AddWithValue("@POST_NO", post_no);
                sCommand.Parameters.AddWithValue("@ADDR", addr);
                sCommand.Parameters.AddWithValue("@ADDR2", addr2);
                sCommand.Parameters.AddWithValue("@OPEN_DATE", open_date);
                sCommand.Parameters.AddWithValue("@COMP_PHONE", comp_phone);
                sCommand.Parameters.AddWithValue("@FAX", fax);
                sCommand.Parameters.AddWithValue("@MANAGER_EMAIL", mg_email);
                sCommand.Parameters.AddWithValue("@MANAGER_PHONE", mg_phone);
                sCommand.Parameters.AddWithValue("@HOMEPAGE", homepage);
                if (img_size > 0)
                {
                    sCommand.Parameters.AddWithValue("@SAUP_LOGO", img);
                    sCommand.Parameters.AddWithValue("@LOGO_SIZE", img_size);
                }

                int qResult = wAdo.SqlCommandEtc(sCommand, "update_Saup_TB");
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
        #endregion 사업자관리

        #region 생산보고서


        //2019-10-31 이재원 생산보고서 Group by Query 
        public DataTable fn_GroupByPlanList(string condition)
        {
            StringBuilder sb = new StringBuilder();


            sb.AppendLine("select ITEM_CD  ");
            sb.AppendLine("     ,(select ITEM_NM from N_ITEM_CODE where ITEM_CD = A.ITEM_CD) as ITEM_NM  ");
            sb.AppendLine("     ,(select SPEC from N_ITEM_CODE where ITEM_CD = A.ITEM_CD) as SPEC ");
            sb.AppendLine("     ,UNIT_CD   ");
            sb.AppendLine("     ,(select UNIT_NM from N_UNIT_CODE where UNIT_CD = A.UNIT_CD) as UNIT_NM ");
            sb.AppendLine("     ,SUM(total_amt) as SUM_AMT ");
            sb.AppendLine("     from F_PLAN_DETAIL A ");
            sb.AppendLine(condition);
            sb.AppendLine("     group by item_cd , UNIT_CD");
            sb.AppendLine(" order by item_cd");



            Debug.WriteLine(sb.ToString());

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            return wAdo.SqlCommandSelect(sCommand);

        }
        //2019-10-31 이재원 생산보고서 Group by Query 
        public DataTable fn_GroupByFlowList(string condition)
        {
            StringBuilder sb = new StringBuilder();


            sb.AppendLine("select A.ITEM_CD  ");
            sb.AppendLine("      ,(select ITEM_NM from N_ITEM_CODE where A.ITEM_CD = ITEM_CD) as ITEM_NM   ");
            sb.AppendLine("      ,(select SPEC from N_ITEM_CODE where A.ITEM_CD = ITEM_CD) as SPEC   ");
            sb.AppendLine("      , SUM(INST_AMT) AS TOTAL_INST_AMT   ");
            sb.AppendLine("      , SUM(LOSS) AS LOSS   ");
            sb.AppendLine("      ,SUM(POOR_AMT) AS POOR_AMT   ");
            sb.AppendLine("      ,SUM(INST_AMT)-SUM(LOSS)-SUM(POOR_AMT) AS SUM_AMT   ");
            sb.AppendLine("      from F_WORK_INST A    ");
            sb.AppendLine("      join (select LOT_NO, sum(LOSS) as LOSS   ");
            sb.AppendLine("      , sum(POOR_AMT) as POOR_AMT    ");
            sb.AppendLine("      from F_WORK_FLOW_DETAIL group by LOT_NO) B    ");
            sb.AppendLine("      on A.LOT_NO = B.LOT_NO    ");
            sb.AppendLine(condition);
            sb.AppendLine("      and (A.POOR_WORK_YN is null or A.POOR_WORK_YN = 'N')  ");
            sb.AppendLine("      group by A.ITEM_CD   ");

            Console.WriteLine(sb.ToString());

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_Detail_List(string condition)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SELECT A.PLAN_DATE,  ");
            sb.AppendLine("B.UNIT_NM,   ");
            sb.AppendLine("A.WORK_YN   ");
            sb.AppendLine("FROM F_PLAN_DETAIL A   ");
            sb.AppendLine("LEFT OUTER JOIN N_UNIT_CODE B ON A.UNIT_CD = B.UNIT_CD   ");
            sb.AppendLine(condition);

            Debug.WriteLine(sb.ToString());

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }



        #endregion 생산보고서

        #region 원산지등록
        //2019-11-01 이재원 축산 특화를 위한 원산지 기초코드 조회 
        public DataTable fn_Country_List(string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select COUNTRY_CD");
            sb.AppendLine(" , COUNTRY_NM  ");
            sb.AppendLine(" , COMMENT  ");
            sb.AppendLine(" , USED_CD  ");
            sb.AppendLine(" , (select S_CODE_NM  ");
            sb.AppendLine("    from [SM_FACTORY_COM].[dbo].[T_S_CODE] ");
            sb.AppendLine("    where L_CODE = '500' and S_CODE = A.USED_CD) AS USED_NM ");
            sb.AppendLine(" from N_RAW_COUNTRY_CODE A ");
            sb.AppendLine(condition);
            sb.AppendLine(" order by COUNTRY_CD ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            return wAdo.SqlCommandSelect(sCommand);
        }

        //2019-11-01 이재원 축산 특화를 위한 원산지 기초코드 등록 
        public int insertCountryCode(
              string txt_country_cd
            , string txt_country_nm
            , string comment
            , string used_cd
         )
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();


                sb.AppendLine(" select count(*) as cnt");
                sb.AppendLine(" from N_RAW_COUNTRY_CODE");
                sb.AppendLine(" where COUNTRY_CD = '" + txt_country_cd + "'");

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

                sb = new StringBuilder();


                sb.AppendLine("insert into N_RAW_COUNTRY_CODE(");
                sb.AppendLine("     COUNTRY_CD ");
                sb.AppendLine("     ,COUNTRY_NM ");
                sb.AppendLine("     ,COMMENT ");
                sb.AppendLine("     ,USED_CD ");
                sb.AppendLine("  )values ( ");
                sb.AppendLine("     @COUNTRY_CD ");
                sb.AppendLine("     ,@COUNTRY_NM ");
                sb.AppendLine("     ,@COMMENT ");
                sb.AppendLine("     ,@USED_CD ");

                sb.AppendLine("  )");



                sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@COUNTRY_CD", txt_country_cd);
                sCommand.Parameters.AddWithValue("@COUNTRY_NM", txt_country_nm);
                sCommand.Parameters.AddWithValue("@COMMENT", comment);
                sCommand.Parameters.AddWithValue("@USED_CD", used_cd);


                int qResult = wAdo.SqlCommandEtc(sCommand, "insert_COUNTRY_CODE");
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

        //2019-11-01 이재원 축산 특화를 위한 원산지 기초코드 수정
        public int UpdateCountryCode(
              string txt_country_cd
            , string txt_country_nm
            , string comment
            , string used_cd
         )
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb.AppendLine("Update N_RAW_COUNTRY_CODE SET");
                sb.AppendLine("     COUNTRY_NM = @COUNTRY_NM ");
                sb.AppendLine("     ,COMMENT = @COMMENT ");
                sb.AppendLine("     ,USED_CD = @USED_CD ");
                sb.AppendLine("     WHERE COUNTRY_CD = @COUNTRY_CD ");



                SqlCommand sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@COUNTRY_CD", txt_country_cd);
                sCommand.Parameters.AddWithValue("@COUNTRY_NM", txt_country_nm);
                sCommand.Parameters.AddWithValue("@COMMENT", comment);
                sCommand.Parameters.AddWithValue("@USED_CD", used_cd);


                int qResult = wAdo.SqlCommandEtc(sCommand, "insert_COUNTRY_CODE");
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

        //2019-11-01 이재원 축산 특화를 위한 원산지 기초코드 삭제
        public int DeleteCountryCode(
              string txt_country_cd
         )
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb.AppendLine("Delete from N_RAW_COUNTRY_CODE ");
                sb.AppendLine("     WHERE COUNTRY_CD = @COUNTRY_CD ");



                SqlCommand sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@COUNTRY_CD", txt_country_cd);

                int qResult = wAdo.SqlCommandEtc(sCommand, "insert_COUNTRY_CODE");
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

        #endregion 원산지등록


        public DataTable fn_Jang_Item_List(string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select * ");
            sb.AppendLine(" from T_상품정보 ");
            sb.AppendLine(condition);
            sb.AppendLine(" order by 상품코드 ");

            Console.WriteLine(sb.ToString());


            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            return wAdo.SqlCommandSelect_Jang(sCommand);
        }



        public int fn_Item_Update_Complete(string sLotno, string sLotsub)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb = new StringBuilder();

                sb.AppendLine("Update F_ITEM_INPUT SET ");
                sb.AppendLine("     COMPLETE_YN =  'Y'   ");
                sb.AppendLine("     WHERE LOT_NO = @LOT_NO and LOT_SUB = @LOT_SUB   ");




                SqlCommand sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@LOT_NO", sLotno);
                sCommand.Parameters.AddWithValue("@LOT_SUB", sLotsub);


                int qResult = wAdo.SqlCommandEtc(sCommand, "Update_Item_Complete");
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

        public DataTable ITEM_LINK(string condition)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("select LINK_CD from N_ITEM_CODE where ITEM_CD='" + condition + "' ");


            Debug.WriteLine(sb.ToString());

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }


        public int fn_Insert_Item_To_Jang(DataGridView InputTabGrid)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb = new StringBuilder();




                for (int i = 0; i < InputTabGrid.Rows.Count; i++)
                {
                    if (InputTabGrid.Rows[i].Cells["CHK"].Value != null && (bool)InputTabGrid.Rows[i].Cells["CHK"].Value == true)
                    {
                        DataTable strLink = ITEM_LINK(InputTabGrid.Rows[i].Cells["제품코드"].Value.ToString());

                        sb.AppendLine("declare @seq" + InputTabGrid.Rows[i].Cells["LOT_NO"].Value + " int ");
                        sb.AppendLine("select @seq" + InputTabGrid.Rows[i].Cells["LOT_NO"].Value + " =ISNULL(MAX(전표번호),0)+1 from T_매입 ");
                        sb.AppendLine("where 매입일자 = '" + DateTime.Now.ToString("yyyy-MM-dd") + "' ");
                        sb.AppendLine("and 사업자번호 = '" + Common.p_saupNo + "' ");

                        sb.AppendLine("insert into  T_매입 (사업자번호, 지점코드, 매입일자, 전표번호, 입력방법, 거래처코드, 담당사원, 부가세코드, 등록사원번호, 등록일시, 창고코드 )");
                        sb.AppendLine(" values ( '" + Common.p_saupNo + "' ");
                        sb.AppendLine(" ,'0'  ");
                        sb.AppendLine(" ,'" + DateTime.Now.ToString("yyyy-MM-dd") + "'  ");
                        sb.AppendLine(" ,@seq" + InputTabGrid.Rows[i].Cells["LOT_NO"].Value + "");
                        sb.AppendLine(" ,'C'  ");
                        sb.AppendLine(" ,'" + InputTabGrid.Rows[i].Cells["업체코드"].Value + "' ");
                        sb.AppendLine(" ,(select 사원번호 from T_사용자정보 where 사업자번호 ='" + Common.p_saupNo + "' and uid = '" + Common.p_strUserID + "'  )  ");
                        sb.AppendLine(" ,'1'  ");
                        sb.AppendLine(" ,(select 사원번호 from T_사용자정보 where 사업자번호 ='" + Common.p_saupNo + "' and uid = '" + Common.p_strUserID + "'  )  ");
                        sb.AppendLine(" ,convert(varchar, getdate(), 120)  ");
                        sb.AppendLine(" ,'000'");
                        sb.AppendLine(" )");
                        sb.AppendLine("declare @seq" + i + " int ");
                        sb.AppendLine("select @seq" + i + "  =ISNULL(MAX(항목순번),0)+1 from T_매입항목 ");
                        sb.AppendLine("where 매입일자 = '" + DateTime.Now.ToString("yyyy-MM-dd") + "' ");
                        sb.AppendLine("and 사업자번호 = '" + Common.p_saupNo + "' ");
                        sb.AppendLine("and 전표번호 =  @seq" + InputTabGrid.Rows[i].Cells["LOT_NO"].Value);

                        sb.AppendLine("insert into  T_매입항목 (사업자번호, 지점코드, 매입일자, 전표번호, 항목순번, 상품코드, 박스수량, 중간수량, 낱개수량, 총수량, 박스단가, 낱개단가, 금액");
                        sb.AppendLine(",서비스박스,서비스낱개,서비스총수량, 매입구분, 비고, 과세구분 )");
                        sb.AppendLine(" values ( '" + Common.p_saupNo + "' ");
                        sb.AppendLine(" ,   '0'  ");
                        sb.AppendLine(" ,   '" + DateTime.Now.ToString("yyyy-MM-dd") + "'  ");
                        sb.AppendLine(" ,   @seq" + InputTabGrid.Rows[i].Cells["LOT_NO"].Value + "");
                        sb.AppendLine(" ,   @seq" + i + "  ");
                        sb.AppendLine(" ,'" + strLink.Rows[0][0].ToString() + "' ");
                        sb.AppendLine(" ,   0 ");
                        sb.AppendLine(" ,   0 ");
                        sb.AppendLine(" ,   " + InputTabGrid.Rows[i].Cells["수량"].Value.ToString().Replace(",", "") + " ");
                        sb.AppendLine(" ,   " + InputTabGrid.Rows[i].Cells["수량"].Value.ToString().Replace(",", "") + " ");
                        sb.AppendLine(" ,   0 ");
                        sb.AppendLine(" ,   " + InputTabGrid.Rows[i].Cells["입고가격"].Value.ToString() + " ");
                        sb.AppendLine(" ,   " + double.Parse(InputTabGrid.Rows[i].Cells["입고가격"].Value.ToString()) * double.Parse(InputTabGrid.Rows[i].Cells["수량"].Value.ToString().Replace(",", "")) + " ");
                        sb.AppendLine(" ,   0 ");
                        sb.AppendLine(" ,   0 ");
                        sb.AppendLine(" ,   0 ");
                        sb.AppendLine(" ,   '1' ");
                        sb.AppendLine(" ,   '' ");
                        sb.AppendLine(" ,   '1'  ");
                        sb.AppendLine(" )");
                        Debug.WriteLine(i);

                        Debug.WriteLine(sb);
                    }

                }

                SqlCommand sCommand = new SqlCommand(sb.ToString());
                Debug.WriteLine(sb);


                int qResult = wAdo.SqlCommandEtc_Jang(sCommand, "Update_Item_Complete");
                if (qResult > 0)
                {
                    StringBuilder sb2 = new StringBuilder();
                    for (int i = 0; i < InputTabGrid.RowCount; i++)
                    {
                        if (InputTabGrid.Rows[i].Cells["CHK"].Value != null && (bool)InputTabGrid.Rows[i].Cells["CHK"].Value == true)
                        {
                            sb2.AppendLine("Update F_ITEM_INPUT SET ");
                            sb2.AppendLine("     COMPLETE_YN =  'Y'   ");
                            sb2.AppendLine("     WHERE LOT_NO = '" + InputTabGrid.Rows[i].Cells["LOT_NO"].Value.ToString() + "' and LOT_SUB = '" + InputTabGrid.Rows[i].Cells["LOT_SUB"].Value.ToString() + "'   ");

                        }

                    }

                    sCommand = new SqlCommand(sb2.ToString());
                    Debug.WriteLine(sb2);

                    qResult = wAdo.SqlCommandEtc(sCommand, "Update_Item_Complete2");


                    if (qResult > 0)
                    {
                        return 0;
                    }
                    else return 1;


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

        public DataTable fn_tscode_list()
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select * ");
            sb.AppendLine(" from SM_FACTORY_COM.dbo.T_S_CODE ");


            Console.WriteLine(sb.ToString());


            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            return wAdo.SqlCommandSelect(sCommand);

        }

        //2019-11-05 이재원 HACCP문서 관리 페이지를 만들기 위한 메소드

        public int insert_Haccp_Doc_Root(string rootPath, string staff_cd)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb.AppendLine("Select * from N_HACCP_DOCPATH ");
                sb.AppendLine("     WHERE STAFF_CD = '" + staff_cd + "' ");



                SqlCommand sCommand = new SqlCommand(sb.ToString());

                if (sCommand.CommandText.Equals(null))
                {
                    wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                    return 1;
                }
                DataTable dtTemp = wAdo.SqlCommandSelect(sCommand);

                if (dtTemp.Rows != null && dtTemp.Rows.Count > 0)
                {
                    sb = new StringBuilder();
                    sb.AppendLine("update N_HACCP_DOCPATH ");
                    sb.AppendLine("SET DOCPATH = '" + rootPath + "'  ");
                    sb.AppendLine("   where  STAFF_CD ='" + staff_cd + "' ");

                }
                else
                {
                    sb = new StringBuilder();
                    sb.AppendLine("insert into N_HACCP_DOCPATH(STAFF_CD,DOCPATH) ");
                    sb.AppendLine("   values ('" + staff_cd + "' , '" + rootPath + "') ");

                }

                sCommand = new SqlCommand(sb.ToString());

                int qResult = wAdo.SqlCommandEtc(sCommand, "insert or update HACCP root path");
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

        public string select_Haccp_Doc_Root(string staff_cd)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb.AppendLine("Select * from N_HACCP_DOCPATH ");
                sb.AppendLine("     WHERE STAFF_CD = '" + staff_cd + "' ");



                SqlCommand sCommand = new SqlCommand(sb.ToString());

                if (sCommand.CommandText.Equals(null))
                {
                    wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                    return "failed";
                }

                DataTable dtTemp = wAdo.SqlCommandSelect(sCommand);

                if (dtTemp.Rows != null && dtTemp.Rows.Count > 0)
                {
                    String[] strArrTemp = dtTemp.Rows[0]["DOCPATH"].ToString().Split('/');
                    string ReturnTemp = "";
                    for (int i = 0; i < strArrTemp.Length - 2; i++)
                    {
                        ReturnTemp += strArrTemp[i];
                    }
                    return ReturnTemp;

                }
                else
                {
                    return "미등록";

                }
            }
            catch (Exception e)
            {
                wnLog.writeLog(wnLog.LOG_ERROR, e.Message + " - " + e.ToString());
                Popup.pop오류리포트 msg = new pop오류리포트(e.Message + " - " + e.ToString());
                msg.ShowDialog();
                return "failed";
            }
        }

        public int insert_Haccp_Doc_File(string destFile, string fileName, string staff_cd, string input_date, string txt_comment, string gubun)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb.AppendLine("Select * from F_HACCP_DOCS ");
                sb.AppendLine("     WHERE DOCPATH = '" + destFile + "' and STAFF_CD = '" + staff_cd + "'  ");



                SqlCommand sCommand = new SqlCommand(sb.ToString());

                if (sCommand.CommandText.Equals(null))
                {
                    wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                    return 1;
                }

                DataTable dtTemp = wAdo.SqlCommandSelect(sCommand);

                if (dtTemp.Rows != null && dtTemp.Rows.Count > 0)
                {
                    return 7;
                }

                sb = new StringBuilder();



                sb.AppendLine("declare @seq int ");
                sb.AppendLine("select @seq =ISNULL(MAX(INPUT_CD),0)+1 from F_HACCP_DOCS ");
                sb.AppendLine("where INPUT_DATE = '" + input_date + "' and STAFF_CD = '" + staff_cd + "'  ");

                sb.AppendLine("INSERT INTO F_HACCP_DOCS ( ");
                sb.AppendLine("  INPUT_DATE  ");
                sb.AppendLine("  ,INPUT_CD  ");
                sb.AppendLine("  ,DOC_GUBUN  ");
                sb.AppendLine("  ,STAFF_CD  ");
                sb.AppendLine("  ,DOCPATH  ");
                sb.AppendLine("  ,FNAME  ");
                sb.AppendLine("  ,COMMENT  ");
                sb.AppendLine("  ,INTIME  ");
                sb.AppendLine("  ,INSTAFF  ");
                sb.AppendLine("  ) VALUES (  ");
                sb.AppendLine("  @INPUT_DATE  ");
                sb.AppendLine("  ,@seq  ");
                sb.AppendLine("  ,@DOC_GUBUN  ");
                sb.AppendLine("  ,@STAFF_CD  ");
                sb.AppendLine("  ,@DOCPATH  ");
                sb.AppendLine("  ,@FNAME  ");
                sb.AppendLine("  ,@COMMENT  ");
                sb.AppendLine("  ,convert(varchar, getdate(), 120)");
                sb.AppendLine("  ,'" + Common.p_strStaffNo + "'  ");
                sb.AppendLine("  )  ");




                sCommand = new SqlCommand(sb.ToString());
                sCommand.Parameters.AddWithValue("@INPUT_DATE", input_date);
                sCommand.Parameters.AddWithValue("@DOC_GUBUN", gubun);
                sCommand.Parameters.AddWithValue("@STAFF_CD", staff_cd);
                sCommand.Parameters.AddWithValue("@DOCPATH", destFile);
                sCommand.Parameters.AddWithValue("@FNAME", fileName);
                sCommand.Parameters.AddWithValue("@COMMENT", txt_comment);


                int qResult = wAdo.SqlCommandEtc(sCommand, "insert HACCP_DOCS");
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

        public DataTable select_Haccp_Docs(string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select INPUT_DATE ");
            sb.AppendLine("  ,INPUT_CD ");
            sb.AppendLine("  ,DOC_GUBUN ");
            sb.AppendLine("  ,STAFF_CD ");
            sb.AppendLine("  ,(SELECT STAFF_NM FROM N_STAFF_CODE WHERE A.STAFF_CD = STAFF_CD) AS STAFF_NM ");
            sb.AppendLine("  ,DOCPATH ");
            sb.AppendLine("  ,FNAME ");
            sb.AppendLine("  ,COMMENT ");
            sb.AppendLine(" from F_HACCP_DOCS A");
            sb.AppendLine(condition);


            Console.WriteLine(sb.ToString());


            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            return wAdo.SqlCommandSelect(sCommand);
        }

        public int Delete_Haccp_Doc(string path, string staff_cd)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb = new StringBuilder();

                sb.AppendLine("DELETE FROM F_HACCP_DOCS  ");
                sb.AppendLine("WHERE DOCPATH = @DOCPATH AND STAFF_CD = '" + staff_cd + "'  ");


                SqlCommand sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@DOCPATH", path);


                int qResult = wAdo.SqlCommandEtc(sCommand, "delete_HACCP_DOCS");
                if (qResult > 0)
                {
                    return 0;
                }
                else return 1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + " - " + e.ToString());
                wnLog.writeLog(wnLog.LOG_ERROR, e.Message + " - " + e.ToString());
                return 9;
            }
        }

        public int Update_Haccp_Docs(string columnName, string changeValue, string docPath, string staff_cd)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb = new StringBuilder();
                if (columnName.Equals("INPUT_DATE"))
                {
                    sb.AppendLine("declare @seq int ");
                    sb.AppendLine("select @seq =ISNULL(MAX(INPUT_CD),0)+1 from F_HACCP_DOCS ");
                    sb.AppendLine("where INPUT_DATE = '" + changeValue + "' and STAFF_CD = '" + staff_cd + "'   ");

                    sb.AppendLine("UPDATE F_HACCP_DOCS  ");
                    sb.AppendLine("SET " + columnName + " = '" + changeValue + "'  ");
                    sb.AppendLine(", INPUT_CD = @seq ");
                    sb.AppendLine(", UPTIME = convert(varchar, getdate(), 120)  ");
                    sb.AppendLine(", UPSTAFF = '" + Common.p_strStaffNo + "' ");
                    sb.AppendLine("  WHERE DOCPATH = @DOCPATH ");
                    sb.AppendLine("  and STAFF_CD = '" + staff_cd + "'   ");

                }
                else
                {
                    sb.AppendLine("UPDATE F_HACCP_DOCS  ");
                    sb.AppendLine("SET " + columnName + " = '" + changeValue + "'  ");
                    sb.AppendLine(", UPTIME = convert(varchar, getdate(), 120)  ");
                    sb.AppendLine(", UPSTAFF = '" + Common.p_strStaffNo + "' ");
                    sb.AppendLine("WHERE DOCPATH = @DOCPATH ");
                    sb.AppendLine("  and STAFF_CD = '" + staff_cd + "'   ");
                }

                SqlCommand sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@DOCPATH", docPath);


                int qResult = wAdo.SqlCommandEtc(sCommand, "update_HACCP_DOCS");
                if (qResult > 0)
                {
                    return 0;
                }
                else return 1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + " - " + e.ToString());
                wnLog.writeLog(wnLog.LOG_ERROR, e.Message + " - " + e.ToString());
                return 9;
            }
        }

        public DataTable fn_cust_list()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SELECT A.CUST_NM ");
            sb.AppendLine(",COUNT(F.ITEM_NM) AS ITEM_CNT ");
            sb.AppendLine(",SUM(D.INPUT_AMT) AS INPUT_AMT ");
            sb.AppendLine(",SUM(E.OUTPUT_AMT) AS OUTPUT_AMT ");
            sb.AppendLine("FROM N_CUST_CODE A ");
            sb.AppendLine("LEFT OUTER JOIN F_PLAN B ON A.CUST_CD = B.CUST_CD ");
            sb.AppendLine("LEFT OUTER JOIN F_PLAN_DETAIL C ON B.PLAN_DATE = C.PLAN_DATE AND B.PLAN_CD = C.PLAN_CD ");
            sb.AppendLine("LEFT OUTER JOIN F_ITEM_INPUT D ON C.ITEM_CD = D.ITEM_CD ");
            sb.AppendLine("LEFT OUTER JOIN F_ITEM_OUT_DETAIL E ON B.CUST_CD = E.CUST_CD ");
            sb.AppendLine("LEFT OUTER JOIN N_ITEM_CODE F ON C.ITEM_CD = F.ITEM_CD ");
            sb.AppendLine("GROUP BY CUST_NM ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable Plan_List(string condition, string condition2)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SELECT  ");
            sb.AppendLine("A.PLAN_DATE  ");
            sb.AppendLine(",A.PLAN_CD  ");
            sb.AppendLine(",B.CUST_NM  ");
            sb.AppendLine(",COUNT(D.ITEM_NM) AS ITEM_CNT  ");
            sb.AppendLine("FROM F_PLAN A  ");
            sb.AppendLine("LEFT OUTER JOIN N_CUST_CODE B ON A.CUST_CD = B.CUST_CD  ");
            sb.AppendLine("LEFT OUTER JOIN F_PLAN_DETAIL C ON A.PLAN_DATE = C.PLAN_DATE AND A.PLAN_CD = C.PLAN_CD  ");
            sb.AppendLine("LEFT OUTER JOIN N_ITEM_CODE D ON C.ITEM_CD = D.ITEM_CD  ");
            sb.AppendLine("WHERE 1=1  ");
            sb.AppendLine(condition);
            sb.AppendLine(condition2);
            sb.AppendLine("GROUP BY A.PLAN_DATE,A.PLAN_CD,B.CUST_NM  ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }

        //품질 추적현황 리스트
        public DataTable fn_item_list(string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SELECT ");
            sb.AppendLine(",F.CUST_NM ");
            sb.AppendLine("C.ITEM_NM ");
            sb.AppendLine(",SUM(D.INPUT_AMT) AS INPUT_AMT ");
            sb.AppendLine(",SUM(E.OUTPUT_AMT) AS OUTPUT_AMT ");
            sb.AppendLine("FROM F_PLAN A ");
            sb.AppendLine("LEFT OUTER JOIN F_PLAN_DETAIL B ON A.PLAN_DATE = B.PLAN_DATE AND A.PLAN_CD = B.PLAN_CD ");
            sb.AppendLine("LEFT OUTER JOIN N_ITEM_CODE C ON B.ITEM_CD = C.ITEM_CD ");
            sb.AppendLine("LEFT OUTER JOIN F_ITEM_INPUT D ON C.ITEM_CD = D.ITEM_CD ");
            sb.AppendLine("LEFT OUTER JOIN F_ITEM_OUT_DETAIL E ON A.CUST_CD = E.CUST_CD ");
            sb.AppendLine("LEFT OUTER JOIN N_CUST_CODE F ON F.CUST_CD = C.CUST_CD ");
            sb.AppendLine(condition);
            sb.AppendLine("GROUP BY ITEM_NM, CUST_NM ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_mipgo_List(string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SELECT ");
            sb.AppendLine("A.RAW_MAT_CD, B.RAW_MAT_NM, B.SPEC,  TEMP_AMT, TOTAL_AMT, CURR_AMT ");
            sb.AppendLine("FROM F_RAW_DETAIL A ");
            sb.AppendLine("LEFT OUTER JOIN N_RAW_CODE B ON A.RAW_MAT_CD = B.RAW_MAT_CD ");
            sb.AppendLine(" where 1=1 ");
            sb.AppendLine("     " + condition + " ");
            sb.AppendLine(" order by a.CUST_CODE asc ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_Item_Flow_Iden_Cnt(string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" select COUNT(*)as cnt from N_ITEM_FLOW A ");
            sb.AppendLine(" inner join N_FLOW_CODE B ");
            sb.AppendLine(" on A.FLOW_CD = B.FLOW_CD ");
            sb.AppendLine(" where 1=1 ");
            sb.AppendLine(condition);

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable Item_Grid_List(string condition)
        //제품불량내역 검색
        {

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(" select  item.ITEM_NM as 제품명, item.SPEC as 규격 ,convert(int,isnull(z.총수량,0)) as 총수량,isnull(z.LOSS량,0) as LOSS량, isnull(convert(decimal(18,2),z.LOSS율),0.00) as LOSS율,convert(int,isnull(z.불량수,0)) as 불량수 ,isnull(convert(decimal(18,2),z.불량율),0.00) as 불량율  from N_ITEM_CODE as item    ");
            sb.AppendLine(" left outer join(  ");

            sb.AppendLine("select cv.ITEM_NM as 제품명 ,cv.SPEC as 규격 ,isnull(z.F_SUB_AMT,0) 총수량 ,isnull(z.POOR_AMT,0) 불량수 ,CASE WHEN ISNULL(Z.F_SUB_AMT,'0') = 0 THEN 0 ELSE (ISNULL(Z.POOR_AMT,'0')/ ISNULL(Z.F_SUB_AMT,'0')) END 불량율,ISNULL(z.loss,0) as LOSS량,CASE WHEN ISNULL(Z.F_SUB_AMT,'0') = 0 THEN 0 ELSE (ISNULL(Z.loss,'0')/ ISNULL(Z.F_SUB_AMT,'0')) END LOSS율 from N_ITEM_CODE cv left join (");
            sb.AppendLine("      SELECT b.ITEM_NM,max(b.SPEC) as spec ,SUM(LOSS) as loss,sum(F_SUB_AMT) F_SUB_AMT ,SUM(POOR_AMT)  as POOR_AMT FROM F_WORK_FLOW_DETAIL  A  ");
            sb.AppendLine("       left join N_ITEM_CODE b on b.ITEM_CD=A.ITEM_CD ");
            sb.AppendLine(condition);
            sb.AppendLine("      group by b.ITEM_NM");
            sb.AppendLine("       )z on z.ITEM_NM= cv.ITEM_NM ");
            sb.AppendLine("       where loss>0 or POOR_AMT>0 ");
            sb.AppendLine("          ) z on z.제품명=item.ITEM_NM and z.규격=item.SPEC ");


            Debug.WriteLine(sb.ToString());

            SqlCommand sCommand = new SqlCommand(sb.ToString());

            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            return wAdo.SqlCommandSelect(sCommand);
        }

        //2019-12-24 계획관리에서 제품에 대한 원부재료 리스트
        public DataTable Items_Raw_List(string condition)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SELECT A.ITEM_CD, B.RAW_MAT_NM, B.SPEC  ");
            sb.AppendLine("FROM N_ITEM_COMP A  ");
            sb.AppendLine("LEFT OUTER JOIN N_RAW_CODE B ON A.RAW_MAT_CD = B.RAW_MAT_CD  ");
            sb.AppendLine("WHERE 1=1 ");
            sb.AppendLine(condition);
            sb.AppendLine("ORDER BY A.ITEM_CD  ");

            //Console.WriteLine(sb.ToString());

            SqlCommand sCommand = new SqlCommand(sb.ToString());

            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            return wAdo.SqlCommandSelect(sCommand);
        }
        //메탈카드등록        
        public int Insert_Metal(
              string txt_metalcd
            , string txt_modelnm
            , string dtp_makedate
            , string txt_spec
            , string txt_ordercust
            , string txt_makecust
            , string dtp_inputdate
            , string txt_comment
            , string lot_no
            )
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb.AppendLine(" select count(*) as cnt");
                sb.AppendLine(" from N_METAL_CODE");
                sb.AppendLine(" where METAL_CD = '" + txt_metalcd + "'");
                Debug.WriteLine(sb);
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
                sb = new StringBuilder();
                sb.AppendLine("declare @seq int ");
                sb.AppendLine("select @seq =ISNULL(MAX(RIGHT(METAL_LOTNO,4)),0)+1 from N_METAL_CODE "); //0001 이면 1+1 = 2로 SEQ에 저장
                // sb.AppendLine("where METAL_LOTNO LIKE '" + dtp_inputdate.Substring(0, 7).ToString() + "%'"); //2019-05

                //sb.AppendLine("declare @seq1 int ");
                //sb.AppendLine("select @seq1 =ISNULL(MAX(W_INST_CD),0)+1 from F_WORK_INST ");
                //sb.AppendLine("where W_INST_DATE = '" + work_date + "' "); //일별 체크 


                sb.AppendLine("INSERT INTO N_METAL_CODE(  ");
                sb.AppendLine("METAL_CD, METAL_MODEL, METAL_MAKE_DATE, METAL_SPEC,   ");
                sb.AppendLine("METAL_ORDERCUST, METAL_MAKECUST, METAL_INPUT_DATE, METAL_LOTNO, COMMENT)  ");
                sb.AppendLine("VALUES (  ");
                sb.AppendLine("'" + txt_metalcd + "', '" + txt_modelnm + "', '" + dtp_makedate + "', '" + txt_spec + "',   ");
                sb.AppendLine("'" + txt_ordercust + "', '" + txt_makecust + "', '" + dtp_inputdate + "', ");
                sb.AppendLine(" '" + lot_no + "'+ RIGHT('000'+ convert(varchar, @seq), 4)   ");
                sb.AppendLine(" , '" + txt_comment + "'  )    ");

                sCommand = new SqlCommand(sb.ToString());

                //sCommand.Parameters.AddWithValue("@FAC_CD", txt_metal_cd);
                //sCommand.Parameters.AddWithValue("@FAC_MM", txt_metal_nm);
                //sCommand.Parameters.AddWithValue("@MODEL_NM", txt_model_nm);
                //sCommand.Parameters.AddWithValue("@SPEC", txt_spec);
                //sCommand.Parameters.AddWithValue("@MANU_COMPANY", txt_cust_nm);
                //sCommand.Parameters.AddWithValue("@ACQ_DATE", dtp_input_date);
                //sCommand.Parameters.AddWithValue("@ACQ_PRICE", txt_price);
                //sCommand.Parameters.AddWithValue("@IMG", img);

                Debug.WriteLine(sb);

                int qResult = wAdo.SqlCommandEtc(sCommand, "insert_FAC_TB");
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

        //메탈카드 수정
        public int Update_Metal(
              string txt_metalcd
            , string txt_modelnm
            , string dtp_makedate
            , string txt_spec
            , string txt_ordercust
            , string txt_makecust
            , string dtp_inputdate
            , string txt_comment

            )
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb = new StringBuilder();
                sb.AppendLine("update N_METAL_CODE set");
                sb.AppendLine("      METAL_MODEL = @METAL_MODEL ");
                sb.AppendLine("     ,METAL_MAKE_DATE = @METAL_MAKE_DATE ");
                sb.AppendLine("     ,METAL_SPEC = @METAL_SPEC ");
                sb.AppendLine("     ,METAL_ORDERCUST = @METAL_ORDERCUST ");
                sb.AppendLine("     ,METAL_MAKECUST = @METAL_MAKECUST ");
                sb.AppendLine("     ,METAL_INPUT_DATE = @METAL_INPUT_DATE ");
                sb.AppendLine("     ,METAL_LOTNO = @METAL_LOTNO ");
                sb.AppendLine("     ,COMMENT = @COMMENT ");

                sb.AppendLine(" WHERE METAL_CD = @METAL_CD ");
                Debug.WriteLine(sb);

                SqlCommand sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@METAL_CD", txt_metalcd);
                sCommand.Parameters.AddWithValue("@METAL_MODEL", txt_modelnm);
                sCommand.Parameters.AddWithValue("@METAL_MAKE_DATE", dtp_makedate);
                sCommand.Parameters.AddWithValue("@METAL_SPEC", txt_spec);
                sCommand.Parameters.AddWithValue("@METAL_ORDERCUST", txt_ordercust);
                sCommand.Parameters.AddWithValue("@METAL_MAKECUST", txt_makecust);
                sCommand.Parameters.AddWithValue("@METAL_INPUT_DATE", dtp_inputdate);

                sCommand.Parameters.AddWithValue("@COMMENT", txt_comment);
                // sCommand.Parameters.AddWithValue("@IMG", img);                             

                int qResult = wAdo.SqlCommandEtc(sCommand, "update_FAC_TB");
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

        //메탈카드 삭제
        public int Delete_Metal(string txt_raw_cd)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb = new StringBuilder();
                sb.AppendLine("delete from N_METAL_CODE ");
                sb.AppendLine("    where METAL_CD = @METAL_CD  ");

                SqlCommand sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@METAL_CD", txt_raw_cd);

                int qResult = wAdo.SqlCommandEtc(sCommand, "delete_FAC_TB");
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

        //메탈카드 로드
        public DataTable Metal_List()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SELECT *  ");
            sb.AppendLine("FROM N_METAL_CODE ");
            sb.AppendLine("ORDER BY METAL_CD ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            return wAdo.SqlCommandSelect(sCommand);

        }

        public int InsertFac(
              string txt_faccd
            , string txt_facnm
            , string txt_sn
            , string txt_spec
            , int txt_amount
            , string dtp_makedate
            , string dtp_buydate
            , int txt_price
            , string txt_makecust
            , string txt_comment
            )
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb.AppendLine(" select count(*) as cnt");
                sb.AppendLine(" from N_FAC_CODE");
                sb.AppendLine(" where fac_cd = '" + txt_faccd + "'");
                Debug.WriteLine(sb);
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

                sb = new StringBuilder();
                sb.AppendLine("INSERT INTO N_FAC_CODE(  ");
                sb.AppendLine("FAC_CD, FAC_NM, MODEL_NM, SPEC,");
                sb.AppendLine("INPUT_DATE, BUY_DATE, ");
                sb.AppendLine("ACQ_PRICE, AMOUNT,  ");
                sb.AppendLine("MAKE_CUST, COMMENT )");
                sb.AppendLine("VALUES(");
                sb.AppendLine(" '" + txt_faccd + "','" + txt_facnm + "','" + txt_sn + "','" + txt_spec + "', ");
                sb.AppendLine(" '" + dtp_makedate + "','" + dtp_buydate + "', ");
                sb.AppendLine(" '" + txt_price + "','" + txt_amount + "', ");
                sb.AppendLine(" '" + txt_makecust + "','" + txt_comment + "', ");
                sb.AppendLine("  ");

                sCommand = new SqlCommand(sb.ToString());

                //sCommand.Parameters.AddWithValue("@FAC_CD", txt_metal_cd);
                //sCommand.Parameters.AddWithValue("@FAC_MM", txt_metal_nm);
                //sCommand.Parameters.AddWithValue("@MODEL_NM", txt_model_nm);
                //sCommand.Parameters.AddWithValue("@SPEC", txt_spec);
                //sCommand.Parameters.AddWithValue("@MANU_COMPANY", txt_cust_nm);
                //sCommand.Parameters.AddWithValue("@ACQ_DATE", dtp_input_date);
                //sCommand.Parameters.AddWithValue("@ACQ_PRICE", txt_price);
                //sCommand.Parameters.AddWithValue("@IMG", img);

                Debug.WriteLine(sb);

                int qResult = wAdo.SqlCommandEtc(sCommand, "insert_FAC_TB");
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


        public int UpdateFac(
              string txt_faccd
            , string txt_facnm
            , string txt_sn
            , string txt_spec
            , int txt_amount
            , string dtp_makedate
            , string dtp_buydate
            , int txt_price
            , string txt_makecust
            , string txt_comment
            )
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb = new StringBuilder();
                sb.AppendLine("UPDATE N_FAC_CODE SET");
                sb.AppendLine("      FAC_NM = @FAC_NM ");
                sb.AppendLine("     ,MODEL_NM = @MODEL_NM ");
                sb.AppendLine("     ,SPEC = @SPEC ");
                sb.AppendLine("     ,INPUT_DATE = @INPUT_DATE ");
                sb.AppendLine("     ,BUY_DATE = @BUY_DATE ");
                sb.AppendLine("     ,ACQ_PRICE = @ACQ_PRICE ");
                sb.AppendLine("     ,AMOUNT = @AMOUNT ");
                sb.AppendLine("     ,MAKE_CUST = @MAKE_CUST ");
                sb.AppendLine("     ,COMMENT = @COMMENT ");

                sb.AppendLine(" WHERE FAC_CD = @FAC_CD ");
                Debug.WriteLine(sb);

                SqlCommand sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@FAC_CD", txt_faccd);
                sCommand.Parameters.AddWithValue("@FAC_NM", txt_facnm);
                sCommand.Parameters.AddWithValue("@MODEL_NM", txt_sn);
                sCommand.Parameters.AddWithValue("@SPEC", txt_spec);
                sCommand.Parameters.AddWithValue("@ACQ_DATE", dtp_makedate);
                sCommand.Parameters.AddWithValue("@BUY_DATE", dtp_buydate);
                sCommand.Parameters.AddWithValue("@ACQ_PRICE", txt_price);
                sCommand.Parameters.AddWithValue("@AMOUNT", txt_amount);
                sCommand.Parameters.AddWithValue("@MAKE_CUST", txt_makecust);
                sCommand.Parameters.AddWithValue("@COMMENT", txt_comment);
                // sCommand.Parameters.AddWithValue("@IMG", img);

                int qResult = wAdo.SqlCommandEtc(sCommand, "update_FAC_TB");
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

        public int DeleteFac(string txt_raw_cd)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb = new StringBuilder();
                sb.AppendLine("DELETE FROM N_FAC_CODE ");
                sb.AppendLine("    WHERE FAC_CD = @FAC_CD  ");

                SqlCommand sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@FAC_CD", txt_raw_cd);

                int qResult = wAdo.SqlCommandEtc(sCommand, "delete_FAC_TB");
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

        public DataTable Fac_Grid_List()
        {
            StringBuilder sb = new StringBuilder();
            //sb.AppendLine("SELECT FAC_CD, FAC_NM, MODEL_NM, SPEC, MANU_COMPANY, ACQ_DATE, ACQ_PRICE,  ");
            //sb.AppendLine(" PRO_CAPA, MAINTEN_CLASS, COMMENT  ");
            sb.AppendLine("SELECT FAC_CD, FAC_NM, MODEL_NM, SPEC, MAKE_CUST, INPUT_DATE, ACQ_PRICE, AMOUNT, BUY_DATE, COMMENT ");
            sb.AppendLine("FROM N_FAC_CODE ");
            sb.AppendLine("ORDER BY FAC_CD");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            return wAdo.SqlCommandSelect(sCommand);

        }

        //제품재고업데이트
        public int UpdateStock(string item_cd, string bal_stock, string input, string output)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb = new StringBuilder();
                sb.AppendLine("  BEGIN TRAN ");
                sb.AppendLine("  UPDATE N_ITEM_CODE SET ");
                sb.AppendLine("  BAL_STOCK = '" + bal_stock + "'     ");
                sb.AppendLine("  WHERE ITEM_CD = '" + item_cd + "'    ");
                sb.AppendLine("  COMMIT TRAN   ");

                sb.AppendLine("  BEGIN TRAN ");
                sb.AppendLine("  UPDATE F_ITEM_INPUT SET ");
                sb.AppendLine("  INPUT_AMT = '" + input + "' , ");
                sb.AppendLine("  WHERE ITEM_CD = '" + item_cd + "'    ");
                sb.AppendLine("  COMMIT TRAN   ");

                sb.AppendLine("  BEGIN TRAN ");
                sb.AppendLine("  UPDATE F_ITEM_OUT_DETAIL SET ");
                sb.AppendLine("  OUTPUT_AMT = '" + output + "' , ");
                sb.AppendLine("  WHERE ITEM_CD = '" + item_cd + "'    ");
                sb.AppendLine("  COMMIT TRAN   ");


                SqlCommand sCommand = new SqlCommand(sb.ToString());

                int qResult = wAdo.SqlCommandEtc(sCommand, "update_DEPT_TB");
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

        public DataTable Fac_Grid_List(string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SELECT FAC_CD, FAC_NM, MODEL_NM, SPEC, MAKE_CUST, INPUT_DATE, ACQ_PRICE, AMOUNT, BUY_DATE, COMMENT  ");
            sb.AppendLine("FROM N_FAC_CODE ");
            sb.AppendLine("WHERE 1=1  ");
            sb.AppendLine("AND FAC_NM LIKE '%" + condition + "%'  ");
            sb.AppendLine("ORDER BY FAC_CD  ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable Metal_List(string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SELECT *  ");
            sb.AppendLine("FROM N_METAL_CODE ");
            sb.AppendLine("WHERE 1=1 ");
            sb.AppendLine("AND METAL_MODEL LIKE '%" + condition + "%'  ");
            sb.AppendLine("ORDER BY METAL_CD  ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            return wAdo.SqlCommandSelect(sCommand);

        }


        public DataTable fn_AuthTopCodeUser(string tCode, string staff_cd)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select TopID ");
            sb.AppendLine("     , STAFF_CD ");
            sb.AppendLine("     , AUTH_YN ");
            sb.AppendLine("from N_AUTH_TOP ");
            sb.AppendLine("where 1=1 ");
            sb.AppendLine("and TopID = '" + tCode + "'  ");
            sb.AppendLine("and STAFF_CD = '" + staff_cd + "' ");
            Debug.WriteLine("fn_AuthTopCodeUser");
            Debug.WriteLine(sb);

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable fn_AuthSubCodeUser(string tCode, string staff_cd)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SELECT A.TopID ");
            sb.AppendLine("     , B.SubID ");
            sb.AppendLine("     , B.SubName ");
            sb.AppendLine("     , C.AUTH_YN ");
            sb.AppendLine("     , C.rgstr_yn ");
            sb.AppendLine("     , C.del_yn ");
            sb.AppendLine("from T_TopMenu A ");
            sb.AppendLine("inner join T_SubMenu B ");
            sb.AppendLine("on A.TopID = B.TopID ");
            sb.AppendLine(" and B.VIEW_YN = 'Y'");
            sb.AppendLine("left outer join N_AUTH_SUB C  ");
            sb.AppendLine("on A.TopID = C.TopID ");
            sb.AppendLine(" and B.SubID = C.SubID ");
            sb.AppendLine("where 1=1  ");
            sb.AppendLine(" and A.TopID = '" + tCode + "'  ");
            sb.AppendLine(" and C.STAFF_CD = '" + staff_cd + "' ");
            sb.AppendLine("order by A.TopID,B.SubID ,B.SortNo ");
            Debug.WriteLine("fn_AuthSubCodeUser");

            Debug.WriteLine(sb);
            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            return wAdo.SqlCommandSelect(sCommand);
        }



        public DataTable fn_AuthSubCode(string tCode)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select TopID ");
            sb.AppendLine("     , SubID ");
            sb.AppendLine("     , SubName ");
            sb.AppendLine("     , SortNo ");
            sb.AppendLine("from T_SubMenu ");
            sb.AppendLine("where 1=1 ");
            sb.AppendLine("and TopID = '" + tCode + "'  ");
            sb.AppendLine("and VIEW_YN = 'Y' ");
            sb.AppendLine("order by SortNo  ");
            Debug.WriteLine("fn_AuthSubCode");
            Debug.WriteLine(sb);
            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            return wAdo.SqlCommandSelect(sCommand);

        }

        public int inAndUpAuth(string staff_cd, DataGridView[] dgv, CheckBox[] chk, string[] topCd, int max_cnt)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb = new StringBuilder();

                for (int i = 0; i < max_cnt; i++)
                {
                    sb.AppendLine("declare @chk" + i + " int ");
                    sb.AppendLine("select @chk" + i + " = count(*) from N_AUTH_TOP ");
                    sb.AppendLine("where TopID = '" + topCd[i] + "' and STAFF_CD = '" + staff_cd + "' ");
                    sb.AppendLine("IF(@chk" + i + " > 0)");
                    sb.AppendLine(" update N_AUTH_TOP  ");
                    sb.AppendLine(" set AUTH_YN = '" + (chk[i].Checked.ToString().Equals("True") ? "Y" : "N") + "' ");
                   
                    sb.AppendLine("    ,UPSTAFF = '" + Common.p_strStaffNo + "' ");
                    sb.AppendLine("    ,UPTIME = convert(varchar, getdate(), 120) ");
                    sb.AppendLine(" where TopID = '" + topCd[i].ToString() + "' ");
                    sb.AppendLine("     and STAFF_CD = '" + staff_cd + "' ");
                    sb.AppendLine("ELSE ");
                    sb.AppendLine(" insert into N_AUTH_TOP( ");
                    sb.AppendLine("      TopID ");
                    sb.AppendLine("     ,STAFF_CD ");
                    sb.AppendLine("     ,AUTH_YN ");
                    sb.AppendLine("     ,INSTAFF ");
                    sb.AppendLine("     ,INTIME ");
                    sb.AppendLine("     ) ");
                    sb.AppendLine(" VALUES( ");
                    sb.AppendLine("     '" + topCd[i].ToString() + "' ");
                    sb.AppendLine("     ,'" + staff_cd + "' ");
                    sb.AppendLine("     , '" + (chk[i].Checked.ToString().Equals("True") ? "Y" : "N") + "' ");
                    sb.AppendLine("     ,'" + Common.p_strStaffNo + "' ");
                    sb.AppendLine("     ,convert(varchar, getdate(), 120) ");
                    sb.AppendLine(" ) ");
                    Debug.WriteLine("권한관리탑"+i);
                    Debug.WriteLine(sb);
                    for (int j = 0; j < dgv[i].Rows.Count; j++)
                    {
                        sb.AppendLine("declare @chk_sub" + i + "_" + j + " int ");
                        sb.AppendLine("select @chk_sub" + i + "_" + j + " = count(*) from N_AUTH_SUB ");
                        sb.AppendLine("where TopID = '" + topCd[i] + "' and SubID = '" + dgv[i].Rows[j].Cells["SubID"].Value.ToString() + "'  and STAFF_CD = '" + staff_cd + "' ");

                        sb.AppendLine("IF(@chk_sub" + i + "_" + j + " > 0)");
                        sb.AppendLine(" update N_AUTH_SUB  ");
                        sb.AppendLine(" set AUTH_YN = '" + (dgv[i].Rows[j].Cells["CHK"].Value.ToString().Equals("True") ? "Y" : "N") + "' ");
                        sb.AppendLine("  ,rgstr_yn = '" + (dgv[i].Rows[j].Cells["CHK1"].Value.ToString().Equals("True") ? "Y" : "N") + "' ");
                        sb.AppendLine("  ,del_yn = '" + (dgv[i].Rows[j].Cells["CHK2"].Value.ToString().Equals("True") ? "Y" : "N") + "' ");
                        sb.AppendLine("    ,UPSTAFF = '" + Common.p_strStaffNo + "' ");
                        sb.AppendLine("    ,UPTIME = convert(varchar, getdate(), 120) ");
                        sb.AppendLine(" where TopID = '" + topCd[i].ToString() + "' ");
                        sb.AppendLine("     and SubID = '" + dgv[i].Rows[j].Cells["SubID"].Value + "' ");
                        sb.AppendLine("     and STAFF_CD = '" + staff_cd + "' ");
                        sb.AppendLine("ELSE ");
                        sb.AppendLine(" insert into N_AUTH_SUB( ");
                        sb.AppendLine("      TopID ");
                        sb.AppendLine("     ,SubID ");
                        sb.AppendLine("     ,STAFF_CD ");
                        sb.AppendLine("     ,AUTH_YN ");
                        sb.AppendLine("     ,rgstr_yn ");
                        sb.AppendLine("     ,del_yn ");
                        sb.AppendLine("     ,INSTAFF ");
                        sb.AppendLine("     ,INTIME ");
                        sb.AppendLine("     ) ");
                        sb.AppendLine(" VALUES( ");
                        sb.AppendLine("     '" + topCd[i].ToString() + "' ");
                        sb.AppendLine("     ,'" + dgv[i].Rows[j].Cells["SubID"].Value.ToString() + "' ");
                        sb.AppendLine("     ,'" + staff_cd + "' ");
                        sb.AppendLine("     , '" + (dgv[i].Rows[j].Cells["CHK"].Value.ToString().Equals("True") ? "Y" : "N") + "' ");
                        sb.AppendLine("     , '" + (dgv[i].Rows[j].Cells["CHK1"].Value.ToString().Equals("True") ? "Y" : "N") + "' ");
                        sb.AppendLine("     , '" + (dgv[i].Rows[j].Cells["CHK2"].Value.ToString().Equals("True") ? "Y" : "N") + "' ");
                        sb.AppendLine("     ,'" + Common.p_strStaffNo + "' ");
                        sb.AppendLine("     ,convert(varchar, getdate(), 120) ");
                        sb.AppendLine(" ) ");

                        Debug.WriteLine("권한관리서브");
                        Debug.WriteLine(sb);
                    }
                }

                Debug.WriteLine("권한관리");
                Debug.WriteLine(sb);
                SqlCommand sCommand = new SqlCommand(sb.ToString());

                int qResult = wAdo.SqlCommandEtc(sCommand, "update_DEPT_TB");
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
      
        public static string fn_TitleName(string sName)
        {
            string tName = "";

            wnAdo wAdo = new wnAdo();

            DataTable dt = new DataTable();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select TopID ");
            sb.AppendLine("     , SubID ");
            sb.AppendLine("     , SubName ");
            sb.AppendLine("     , SortNo ");
            sb.AppendLine("from T_SubMenu ");
            sb.AppendLine("where 1=1 ");
            sb.AppendLine(" and VIEW_YN = 'Y'");
            sb.AppendLine(" and AsmName LIKE'%" + sName + "' ");
        
            Debug.WriteLine(sb);
            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            dt = wAdo.SqlCommandSelect(sCommand);

            if (dt != null && dt.Rows.Count > 0)
            {
                tName = dt.Rows[0]["TopID"].ToString() + "$" + dt.Rows[0]["SubID"].ToString() + "$" + dt.Rows[0]["SubName"].ToString();
                ;            }
            else tName = "";

            return tName;
        }

        public  DataTable fn_auth_check(string topid, string subid)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select auth_yn,rgstr_yn,del_yn from n_auth_sub");
            sb.AppendLine("where staff_cd='" + Common.p_strStaffNo + "' and topid='" + topid + "' and subid='" + subid + "'");
           

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            return wAdo.SqlCommandSelect(sCommand);

        }
        //유정훈 시작 

        // 제품 출고 조회

        public DataTable fn_Item_Output_List(string condition)
        {
            StringBuilder sb = new StringBuilder();
        sb.AppendLine("select A.OUTPUT_DATE,");
        sb.AppendLine("       A.OUTPUT_CD, ");
        sb.AppendLine("       C.CUST_CD, ");
        sb.AppendLine("       C.CUST_NM, ");
        sb.AppendLine("       C.TAX_CD AS VAT_CD, ");
        sb.AppendLine("       A.STORAGE_CD, ");
        sb.AppendLine("       D.STORAGE_NM, ");
        sb.AppendLine("       B.ITEM_CNT, ");
        sb.AppendLine("       A.SELF_YN ");
        sb.AppendLine(" from F_ITEM_OUT A ");
        sb.AppendLine(" left outer join(  ");
        sb.AppendLine("                 select OUTPUT_DATE,OUTPUT_CD,COUNT(*) AS ITEM_CNT ");
        sb.AppendLine("                 from F_ITEM_OUT_DETAIL A ");
        sb.AppendLine(condition);
        sb.AppendLine("                 group by OUTPUT_DATE,OUTPUT_CD)B  ");
        sb.AppendLine(" on A.OUTPUT_DATE = B.OUTPUT_DATE  ");
        sb.AppendLine(" and A.OUTPUT_CD = B.OUTPUT_CD   ");
        sb.AppendLine(" left outer join N_CUST_CODE C  ");
        sb.AppendLine(" on A.CUST_CD = C.CUST_CD ");
        sb.AppendLine(" left outer join N_STORAGE_CODE D ");
        sb.AppendLine(" on A.STORAGE_CD = D.STORAGE_CD ");

        sb.AppendLine(condition);
        sb.AppendLine(" order by A.OUTPUT_DATE desc, A.OUTPUT_CD desc ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            return wAdo.SqlCommandSelect(sCommand);

        }



        public DataTable bookmarkList()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("select SubID,SubName from T_SubMenu where BOOKMARK_YN ='Y'");
            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            return wAdo.SqlCommandSelect(sCommand);
        }

        public void updatebookmark(CheckedListBox chk)
        {
            try
            {          
                SqlConnection dbConn = new SqlConnection(Common.p_strConn);
            
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("    UPDATE T_SubMenu SET BOOKMARK_YN = 'N'  ");
                sb.AppendLine("   UPDATE T_SubMenu SET BOOKMARK_YN = 'Y' WHERE SubName in (");
                 sb.Append("'"+chk.Items[0].ToString()+"'");
                for (int i = 1; i < chk.Items.Count; i++)
                {
                    sb.Append(",'" + chk.Items[i].ToString() + "'");
                }
                sb.Append(")");
                Debug.WriteLine(sb);
                SqlCommand sCommand = new SqlCommand(sb.ToString(), dbConn);
                int qResult = wAdo.SqlCommandEtc(sCommand, "insert_meat_INPUT");
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + " - " + e.ToString());
                wnLog.writeLog(wnLog.LOG_ERROR, e.Message + " - " + e.ToString());
               
            }
        }

        public DataTable fn_Item_List_검사용(string condition) //솔빈추가  frm공정검사기준등록 에 제품 list 가져옴
        {
            StringBuilder sb = new StringBuilder();





            sb.AppendLine("select A.ITEM_CD");
            sb.AppendLine("     ,ITEM_NM ");
            sb.AppendLine("     ,ITEM_GUBUN ");
            sb.AppendLine("     ,A.CUST_CD ");
            sb.AppendLine("     ,SPEC ");
            sb.AppendLine("     ,TYPE_CD ");
            sb.AppendLine("     , (select TYPE_NM from N_TYPE_CODE where TYPE_CD = A.TYPE_CD) AS TYPE_NM  ");
            sb.AppendLine("     ,LINE_CD ");
            sb.AppendLine("     , (select LINE_NM from N_LINE_CODE where LINE_CD = A.LINE_CD) AS LINE_NM  ");
            sb.AppendLine("     ,A.UNIT_CD ");
            sb.AppendLine("     , (select UNIT_NM from N_UNIT_CODE where UNIT_CD = A.UNIT_CD) AS UNIT_NM  ");
            sb.AppendLine("     ,STOCK_LOC ");
            sb.AppendLine("     ,PROP_STOCK ");
            sb.AppendLine("     ,BAL_STOCK ");
            sb.AppendLine("     ,BASIC_STOCK ");
            sb.AppendLine("     ,ITEM_WEIGHT ");
            sb.AppendLine("     ,FLOOR(INPUT_PRICE) AS INPUT_PRICE ");
            sb.AppendLine("     ,OUTPUT_PRICE ");
            sb.AppendLine("     ,PACK_AMT ");
            sb.AppendLine("     ,PRINT_YN ");
            sb.AppendLine("     ,USED_CD ");
            sb.AppendLine("     ,INPUT_DATE ");
            sb.AppendLine("     ,UNIT_BAR_CD ");
            sb.AppendLine("     ,UNIT_AMT ");
            sb.AppendLine("     ,VAT_CD ");
            sb.AppendLine("     , (select S_CODE_NM ");
            sb.AppendLine("         from [SM_FACTORY_COM].[dbo].[T_S_CODE] ");
            sb.AppendLine("         where L_CODE = '400' and S_CODE = ITEM_GUBUN) AS ITEM_GUBUN_NM ");
            sb.AppendLine("     , (select COUNT(*) from N_ITEM_CHK where ITEM_CD = A.ITEM_CD) AS ITEM_CHK_YN ");
            sb.AppendLine("     ,LINK_CD ");
            sb.AppendLine("      ,c.FLOW_NM ");
            sb.AppendLine("      ,c.FLOW_CD as 공정코드 ");
        
            sb.AppendLine("    ,case when   D.FLOW_CD IS NULL then '미등록' else '등록' end 등록 ");

            sb.AppendLine(" from N_ITEM_CODE A ");
            sb.AppendLine(" left join n_item_flow as B on B.ITEM_CD=A.ITEM_CD ");
            sb.AppendLine(" inner join N_FLOW_CODE as c on c.FLOW_CD=B.FLOW_CD and c.FLOW_CHK_YN='Y'");
            sb.AppendLine("  left join N_FLOW_CHK as D on D.ITEM_CD=A.ITEM_CD and  D.FLOW_CD =c.FLOW_CD");
        
            sb.AppendLine(condition);
            sb.AppendLine(" order by ITEM_GUBUN,A.ITEM_CD");

            Debug.WriteLine("frm공정검사기준등록 에 제품 list 가져옴");

            Debug.WriteLine(sb.ToString());



            SqlCommand sCommand = new SqlCommand(sb.ToString());


            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            return wAdo.SqlCommandSelect(sCommand);

        }

        public DataTable 납품추적_List(string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SELECT   A.OUTPUT_DATE,   B.ITEM_CD,  B.ITEM_NM,  B.SPEC, ");
            sb.AppendLine("C.CUST_NM,    A.OUTPUT_AMT,  A.PRICE,  A.TOTAL_MONEY,  A.LOT_NO ");
            sb.AppendLine("FROM F_ITEM_OUT_DETAIL A ");
            sb.AppendLine("LEFT OUTER JOIN N_ITEM_CODE B ON A.ITEM_CD = B.ITEM_CD ");
            sb.AppendLine("LEFT OUTER JOIN N_CUST_CODE C ON A.CUST_CD = C.CUST_CD ");
            sb.AppendLine(condition);
            //sb.AppendLine(" order by A.OUTPUT_DATE, A.OUTPUT_CD, B.SEQ");
            Debug.WriteLine(sb);
            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            return wAdo.SqlCommandSelect(sCommand);

        }


        public DataTable 납품추적_Detail_List(string condition)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SELECT   A.LOT_NO,  A.FLOW_DATE,  A.ITEM_CD,  B.F_STEP,  B.SEQ,    ");
            sb.AppendLine("D.ITEM_NM,  D.ITEM_WEIGHT,  C.FLOW_NM,  E.UNIT_NM,   ");
            sb.AppendLine("ISNULL(F.OUTPUT_AMT, 0) AS OUTPUT_AMT  ");
            sb.AppendLine("FROM F_WORK_FLOW A  ");
            sb.AppendLine("INNER JOIN F_WORK_FLOW_DETAIL B ON A.LOT_NO = B.LOT_NO  ");
            sb.AppendLine("LEFT OUTER JOIN N_FLOW_CODE C ON B.FLOW_CD = C.FLOW_CD  ");
            sb.AppendLine("LEFT OUTER JOIN N_ITEM_CODE D ON A.ITEM_CD = D.ITEM_CD  ");
            sb.AppendLine("LEFT OUTER JOIN N_UNIT_CODE E ON D.UNIT_CD = E.UNIT_CD  ");
            sb.AppendLine("LEFT OUTER JOIN F_ITEM_OUT_DETAIL F ON A.LOT_NO = F.LOT_NO  ");

            sb.AppendLine(condition);

            Debug.WriteLine(sb.ToString());

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }

        public int updateItemOut(
              string out_date
            , string out_cd
            , conDataGridView item_out_dgv
            , DataTable del_dgv)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                SqlCommand sCommand = new SqlCommand(sb.ToString());
                //for (int i = 0; i < in_rm_dgv.Rows.Count; i++)
                //{
                //    sb.AppendLine(" select A.ORDER_DATE,A.ORDER_CD,B.SEQ,C.ORDER_AMT, C.INPUT_AMT");
                //    sb.AppendLine(" FROM F_ORDER A ");
                //    sb.AppendLine(" LEFT OUTER JOIN F_ORDER_DETAIL B  ");
                //    sb.AppendLine(" ON A.ORDER_DATE = B.ORDER_DATE ");
                //    sb.AppendLine("     AND A.ORDER_CD = B.ORDER_CD ");
                //    sb.AppendLine(" LEFT OUTER JOIN(	 ");
                //    sb.AppendLine("                     SELECT AA.ORDER_DATE	 ");
                //    sb.AppendLine("                           ,AA.ORDER_CD       ");
                //    sb.AppendLine("                           ,AA.SEQ ");
                //    sb.AppendLine("                           ,FLOOR(ISNULL(AA.TOTAL_AMT,0)) AS ORDER_AMT ");
                //    sb.AppendLine("                           ,ISNULL(SUM(BB.TOTAL_AMT),0) AS INPUT_AMT ");
                //    sb.AppendLine("                           , ISNULL(AA.TOTAL_AMT,0)-ISNULL(SUM(BB.TOTAL_AMT),0) AS NO_INPUT_AMT ");
                //    sb.AppendLine("                     FROM F_ORDER_DETAIL AA ");
                //    sb.AppendLine("                     LEFT OUTER JOIN F_RAW_DETAIL BB ");
                //    sb.AppendLine("                     ON AA.ORDER_DATE = BB.ORDER_DATE ");
                //    sb.AppendLine("                         AND AA.ORDER_CD = BB.ORDER_CD ");
                //    sb.AppendLine("                         AND AA.SEQ = BB.ORDER_SEQ ");
                //    sb.AppendLine("                     GROUP BY AA.ORDER_DATE,AA.ORDER_CD,AA.SEQ,AA.TOTAL_AMT)C ");
                //    sb.AppendLine(" ON A.ORDER_DATE = C.ORDER_DATE  ");
                //    sb.AppendLine("     AND A.ORDER_CD = C.ORDER_CD ");
                //    sb.AppendLine("     AND B.SEQ = C.SEQ  ");
                //    sb.AppendLine(" WHERE A.ORDER_DATE = '" + in_rm_dgv.Rows[i].Cells["ORDER_DATE"].Value + "' ");
                //    sb.AppendLine("      AND A.ORDER_CD = '" + in_rm_dgv.Rows[i].Cells["ORDER_CD"].Value + "' ");
                //    sb.AppendLine("      AND B.SEQ = '" + in_rm_dgv.Rows[i].Cells["ORDER_SEQ"].Value + "' ");

                //    sCommand = new SqlCommand(sb.ToString());
                //    if (sCommand.CommandText.Equals(null))
                //    {
                //        wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                //        return 2;
                //    }
                //    DataTable dt = wAdo.SqlCommandSelect(sCommand);

                //    double order_amt = double.Parse(dt.Rows[0]["ORDER_AMT"].ToString());
                //    double input_amt = double.Parse(dt.Rows[0]["INPUT_AMT"].ToString());
                //    double grd_total_amt = double.Parse(((string)in_rm_dgv.Rows[i].Cells["TOTAL_AMT"].Value).Replace(",", ""));
                //    double grd_ord_total_amt = double.Parse(((string)in_rm_dgv.Rows[i].Cells["OLD_TOTAL_AMT"].Value)); //백업은 콤마 정의 안함

                //    // 발주수량 + 입력하기 전 수량백업 값 - 입고수량 - 입력한 수량 값 = 결과값

                //    double rs_num = order_amt + grd_ord_total_amt - input_amt - grd_total_amt;
                //    if (rs_num < 0)
                //    {
                //        StringBuilder alert_sb = new StringBuilder();
                //        alert_sb.AppendLine(i + 1 + "번째 줄 원부재료에 포함된 발주번호 \n ");
                //        alert_sb.AppendLine(in_rm_dgv.Rows[i].Cells["ORDER_DATE"].Value + " [" + in_rm_dgv.Rows[i].Cells["ORDER_CD"].Value + "] 의 발주수량보다 더 많게 입력하셨습니다. \n");
                //        alert_sb.AppendLine("그대로 저장하시겠습니까? (저장:예 / 취소:아니오)");

                //        DialogResult msgOk = MessageBox.Show(alert_sb.ToString(), "삭제여부", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //        if (msgOk == DialogResult.No)
                //        {
                //            return 3;
                //        }
                //    }
                //}

                sb = new StringBuilder();
                sb.AppendLine("update F_ITEM_OUT set");
                sb.AppendLine("      UPSTAFF = '" + Common.p_strStaffNo + "' ");
                sb.AppendLine("     ,UPTIME = convert(varchar, getdate(), 120) ");

                sb.AppendLine(" where OUTPUT_DATE = @OUTPUT_DATE and OUTPUT_CD= @OUTPUT_CD ");

                if (item_out_dgv.Rows.Count > 0)
                {
                    for (int i = 0; i < item_out_dgv.Rows.Count; i++)
                    {
                        string txt_seq = (string)item_out_dgv.Rows[i].Cells["SEQ"].Value;
                        if (txt_seq == "" || txt_seq == null)
                        {

                            sb.AppendLine("declare @out_seq" + i + " int ");
                            sb.AppendLine("select @out_seq" + i + " =ISNULL(MAX(SEQ),0)+1 from F_ITEM_OUT_DETAIL ");
                            sb.AppendLine("where OUTPUT_DATE = '" + out_date + "' ");
                            sb.AppendLine("and OUTPUT_CD = '" + out_cd + "' ");

                            sb.AppendLine("insert into F_ITEM_OUT_DETAIL(");
                            sb.AppendLine("     OUTPUT_DATE ");
                            sb.AppendLine("     ,OUTPUT_CD ");
                            sb.AppendLine("     ,SEQ ");
                            sb.AppendLine("     ,LOT_NO ");
                            sb.AppendLine("     ,LOT_SUB ");
                            sb.AppendLine("     ,ITEM_CD ");
                            sb.AppendLine("     ,UNIT_CD ");
                            sb.AppendLine("     ,OUTPUT_AMT ");
                            sb.AppendLine("     ,PRICE ");
                            sb.AppendLine("     ,TOTAL_MONEY ");
                            sb.AppendLine("     ,INPUT_DATE ");
                            sb.AppendLine("     ,INPUT_CD ");
                            sb.AppendLine("     ,CUST_CD ");
                            sb.AppendLine("     ,INSTAFF ");
                            sb.AppendLine("     ,INTIME ");
                            sb.AppendLine("  )values ( ");
                            sb.AppendLine("     '" + out_date + "' ");
                            sb.AppendLine("     ,'" + out_cd + "' ");
                            sb.AppendLine("     ,@out_seq" + i + " ");
                            sb.AppendLine("     ,'" + item_out_dgv.Rows[i].Cells["O_LOT_NO"].Value + "' ");
                            sb.AppendLine("     ,'" + item_out_dgv.Rows[i].Cells["O_LOT_SUB"].Value + "' ");
                            sb.AppendLine("     ,'" + item_out_dgv.Rows[i].Cells["O_ITEM_CD"].Value + "' ");
                            sb.AppendLine("     ,'" + item_out_dgv.Rows[i].Cells["O_UNIT_CD"].Value + "' ");
                            sb.AppendLine("     ,'" + ((string)item_out_dgv.Rows[i].Cells["OUTPUT_AMT"].Value).Replace(",", "") + "' ");
                            sb.AppendLine("     ,'" + ((string)item_out_dgv.Rows[i].Cells["PRICE"].Value).Replace(",", "") + "' ");
                            sb.AppendLine("     ,'" + ((string)item_out_dgv.Rows[i].Cells["TOTAL_MONEY"].Value).Replace(",", "") + "' ");
                            sb.AppendLine("     ,'" + item_out_dgv.Rows[i].Cells["O_INPUT_DATE"].Value + "' ");
                            sb.AppendLine("     ,'" + item_out_dgv.Rows[i].Cells["O_INPUT_CD"].Value + "' ");
                            sb.AppendLine("     ,'" + item_out_dgv.Rows[i].Cells["O_CUST_CD"].Value + "' ");
                            sb.AppendLine("     ,'" + Common.p_strStaffNo + "' ");
                            sb.AppendLine("     ,convert(varchar, getdate(), 120)  ");
                            sb.AppendLine("  )");
                        }
                        else
                        {
                            sb.AppendLine("update F_ITEM_OUT_DETAIL set");
                            sb.AppendLine("       OUTPUT_AMT =  '" + ((string)item_out_dgv.Rows[i].Cells["OUTPUT_AMT"].Value).Replace(",", "") + "' ");
                            sb.AppendLine("      ,PRICE =  '" + ((string)item_out_dgv.Rows[i].Cells["PRICE"].Value).Replace(",", "") + "' ");
                            sb.AppendLine("      ,TOTAL_MONEY =  '" + ((string)item_out_dgv.Rows[i].Cells["TOTAL_MONEY"].Value).Replace(",", "") + "' ");
                            sb.AppendLine("      ,UPSTAFF =  '" + Common.p_strStaffNo + "' ");
                            sb.AppendLine("      ,UPTIME =  convert(varchar, getdate(), 120) ");
                            sb.AppendLine(" where OUTPUT_DATE = '" + out_date + "' ");
                            sb.AppendLine(" and OUTPUT_CD = '" + out_cd + "' ");
                            sb.AppendLine(" and SEQ = '" + item_out_dgv.Rows[i].Cells["SEQ"].Value + "'");
                        }
                    }
                }

                if (del_dgv.Rows.Count > 0)
                {
                    for (int i = 0; i < del_dgv.Rows.Count; i++)
                    {
                        sb.AppendLine("delete from F_ITEM_OUT_DETAIL ");
                        sb.AppendLine("    where OUTPUT_DATE = '" + out_date + "' ");
                        sb.AppendLine("     and OUTPUT_CD = '" + out_cd + "' ");
                        sb.AppendLine("     and SEQ = '" + del_dgv.Rows[i]["SEQ"].ToString() + "' ");
                    }
                }

                sCommand = new SqlCommand(sb.ToString());


                sCommand.Parameters.AddWithValue("@OUTPUT_DATE", out_date);
                sCommand.Parameters.AddWithValue("@OUTPUT_CD", out_cd);

                int qResult = wAdo.SqlCommandEtc(sCommand, "update_ITEM_OUTPUT_TB");
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

        public int insertItemOut(
          string out_date
        , string txt_cust_cd
        , string cmb_stor
        , string self_yn
        , conDataGridView item_out_dgv)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();
                SqlCommand sCommand = new SqlCommand(sb.ToString());
                //for (int i = 0; i < in_rm_dgv.Rows.Count; i++)
                //{
                //    sb.AppendLine(" select A.ORDER_DATE,A.ORDER_CD,B.SEQ,C.ORDER_AMT, C.INPUT_AMT");
                //    sb.AppendLine(" FROM F_ORDER A ");
                //    sb.AppendLine(" LEFT OUTER JOIN F_ORDER_DETAIL B  ");
                //    sb.AppendLine(" ON A.ORDER_DATE = B.ORDER_DATE ");
                //    sb.AppendLine("     AND A.ORDER_CD = B.ORDER_CD ");
                //    sb.AppendLine(" LEFT OUTER JOIN(	 ");
                //    sb.AppendLine("                     SELECT AA.ORDER_DATE	 ");
                //    sb.AppendLine("                           ,AA.ORDER_CD       ");
                //    sb.AppendLine("                           ,AA.SEQ ");
                //    sb.AppendLine("                           ,FLOOR(ISNULL(AA.TOTAL_AMT,0)) AS ORDER_AMT ");
                //    sb.AppendLine("                           ,ISNULL(SUM(BB.TOTAL_AMT),0) AS INPUT_AMT ");
                //    sb.AppendLine("                           , ISNULL(AA.TOTAL_AMT,0)-ISNULL(SUM(BB.TOTAL_AMT),0) AS NO_INPUT_AMT ");
                //    sb.AppendLine("                     FROM F_ORDER_DETAIL AA ");
                //    sb.AppendLine("                     LEFT OUTER JOIN F_RAW_DETAIL BB ");
                //    sb.AppendLine("                     ON AA.ORDER_DATE = BB.ORDER_DATE ");
                //    sb.AppendLine("                         AND AA.ORDER_CD = BB.ORDER_CD ");
                //    sb.AppendLine("                         AND AA.SEQ = BB.ORDER_SEQ ");
                //    sb.AppendLine("                     GROUP BY AA.ORDER_DATE,AA.ORDER_CD,AA.SEQ,AA.TOTAL_AMT)C ");
                //    sb.AppendLine(" ON A.ORDER_DATE = C.ORDER_DATE  ");
                //    sb.AppendLine("     AND A.ORDER_CD = C.ORDER_CD ");
                //    sb.AppendLine("     AND B.SEQ = C.SEQ  ");
                //    sb.AppendLine(" WHERE A.ORDER_DATE = '" + in_rm_dgv.Rows[i].Cells["ORDER_DATE"].Value + "' ");
                //    sb.AppendLine("      AND A.ORDER_CD = '" + in_rm_dgv.Rows[i].Cells["ORDER_CD"].Value + "' ");
                //    sb.AppendLine("      AND B.SEQ = '" + in_rm_dgv.Rows[i].Cells["ORDER_SEQ"].Value + "' ");

                //    sCommand = new SqlCommand(sb.ToString());
                //    if (sCommand.CommandText.Equals(null))
                //    {
                //        wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                //        return 2;
                //    }

                //    DataTable dt = wAdo.SqlCommandSelect(sCommand);

                //    double order_amt = double.Parse(dt.Rows[0]["ORDER_AMT"].ToString());
                //    double input_amt = double.Parse(dt.Rows[0]["INPUT_AMT"].ToString());
                //    double grd_total_amt = double.Parse(((string)in_rm_dgv.Rows[i].Cells["TOTAL_AMT"].Value).Replace(",", ""));
                //    double grd_ord_total_amt = double.Parse(((string)in_rm_dgv.Rows[i].Cells["OLD_TOTAL_AMT"].Value)); //백업은 콤마 정의 안함

                //    // 발주수량 - 입고수량 - 입력한 수량 값 = 결과값

                //    double rs_num = order_amt - input_amt - grd_total_amt;
                //    if (rs_num < 0)
                //    {
                //        StringBuilder alert_sb = new StringBuilder();
                //        alert_sb.AppendLine(i + 1 + "번째 줄 원부재료에 포함된 발주번호 \n ");
                //        alert_sb.AppendLine(in_rm_dgv.Rows[i].Cells["ORDER_DATE"].Value + " [" + in_rm_dgv.Rows[i].Cells["ORDER_CD"].Value + "] 의 발주수량보다 더 많게 입력하셨습니다. \n");
                //        alert_sb.AppendLine("그대로 저장하시겠습니까? (저장:예 / 취소:아니오)");

                //        DialogResult msgOk = MessageBox.Show(alert_sb.ToString(), "삭제여부", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //        if (msgOk == DialogResult.No)
                //        {
                //            return 3;
                //        }
                //    }
                //}

                sb = new StringBuilder();
                sb.AppendLine("declare @seq int ");
                sb.AppendLine("select @seq =ISNULL(MAX(OUTPUT_CD),0)+1 from F_ITEM_OUT ");
                sb.AppendLine("where OUTPUT_DATE = '" + out_date + "' ");

                sb.AppendLine("insert into F_ITEM_OUT(");
                sb.AppendLine("     OUTPUT_DATE");
                sb.AppendLine("     ,OUTPUT_CD ");
                sb.AppendLine("     ,CUST_CD ");
                sb.AppendLine("     ,STORAGE_CD ");
                sb.AppendLine("     ,COMPLETE_YN ");
                sb.AppendLine("     ,SELF_YN ");
                sb.AppendLine("     ,STAFF_CD ");
                sb.AppendLine("     ,INSTAFF ");
                sb.AppendLine("     ,INTIME ");

                sb.AppendLine(" ) values ( ");
                sb.AppendLine("      @OUTPUT_DATE ");
                sb.AppendLine("     ,@seq");
                sb.AppendLine("     ,@CUST_CD ");
                sb.AppendLine("     ,@STORAGE_CD ");
                sb.AppendLine("     ,'N' ");
                sb.AppendLine("     ,'" + self_yn + "' ");
                sb.AppendLine("     ,'" + Common.p_strStaffNo + "' ");
                sb.AppendLine("     ,'" + Common.p_strStaffNo + "' ");
                sb.AppendLine("     ,convert(varchar, getdate(), 120) ");
                sb.AppendLine(" ) ");

                if (item_out_dgv.Rows.Count > 0)
                {
                    for (int i = 0; i < item_out_dgv.Rows.Count; i++)
                    {
                        sb.AppendLine("declare @out_seq" + i + " int ");
                        sb.AppendLine("select @out_seq" + i + " =ISNULL(MAX(SEQ),0)+1 from F_ITEM_OUT_DETAIL ");
                        sb.AppendLine("where OUTPUT_DATE = '" + out_date + "' ");
                        sb.AppendLine("and OUTPUT_CD =  @seq ");

                        sb.AppendLine("insert into F_ITEM_OUT_DETAIL(");
                        sb.AppendLine("     OUTPUT_DATE ");
                        sb.AppendLine("     ,OUTPUT_CD ");
                        sb.AppendLine("     ,SEQ ");
                        sb.AppendLine("     ,LOT_NO ");
                        sb.AppendLine("     ,LOT_SUB ");
                        sb.AppendLine("     ,ITEM_CD ");
                        sb.AppendLine("     ,UNIT_CD ");
                        sb.AppendLine("     ,OUTPUT_AMT ");
                        sb.AppendLine("     ,PRICE ");
                        sb.AppendLine("     ,TOTAL_MONEY ");
                        sb.AppendLine("     ,INPUT_DATE ");
                        sb.AppendLine("     ,INPUT_CD ");
                        sb.AppendLine("     ,CUST_CD ");
                        sb.AppendLine("     ,INSTAFF ");
                        sb.AppendLine("     ,INTIME ");
                        sb.AppendLine("  )values ( ");
                        sb.AppendLine("     '" + out_date + "' ");
                        sb.AppendLine("      ,@seq ");
                        sb.AppendLine("     ,@out_seq" + i + " ");
                        sb.AppendLine("     ,'" + item_out_dgv.Rows[i].Cells["O_LOT_NO"].Value + "' ");
                        sb.AppendLine("     ,'" + item_out_dgv.Rows[i].Cells["O_LOT_SUB"].Value + "' ");
                        sb.AppendLine("     ,'" + item_out_dgv.Rows[i].Cells["O_ITEM_CD"].Value + "' ");
                        sb.AppendLine("     ,'" + item_out_dgv.Rows[i].Cells["O_UNIT_CD"].Value + "' ");
                        sb.AppendLine("     ,'" + ((string)item_out_dgv.Rows[i].Cells["OUTPUT_AMT"].Value).Replace(",", "") + "' ");
                        sb.AppendLine("     ,'" + ((string)item_out_dgv.Rows[i].Cells["PRICE"].Value).Replace(",", "") + "' ");
                        sb.AppendLine("     ,'" + ((string)item_out_dgv.Rows[i].Cells["TOTAL_MONEY"].Value).Replace(",", "") + "' ");
                        sb.AppendLine("     ,'" + item_out_dgv.Rows[i].Cells["O_INPUT_DATE"].Value + "' ");
                        sb.AppendLine("     ,'" + item_out_dgv.Rows[i].Cells["O_INPUT_CD"].Value + "' ");
                        sb.AppendLine("     ,'" + item_out_dgv.Rows[i].Cells["O_CUST_CD"].Value + "' ");
                        sb.AppendLine("     ,'" + Common.p_strStaffNo + "' ");
                        sb.AppendLine("     ,convert(varchar, getdate(), 120)  ");
                        sb.AppendLine("  )");

                        //sb.AppendLine(" update N_RAW_CODE set ");
                        //sb.AppendLine("     BAL_STOCK = ISNULL(BAL_STOCK,0) +" + double.Parse(((string)in_rm_dgv.Rows[i].Cells["TOTAL_AMT"].Value).Replace(",", "") + " ") );
                        //sb.AppendLine(" where RAW_MAT_CD = '" +in_rm_dgv.Rows[i].Cells["RAW_MAT_CD"].Value + "' ");
                    }
                }

                sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@OUTPUT_DATE", out_date);
                sCommand.Parameters.AddWithValue("@CUST_CD", txt_cust_cd);
                sCommand.Parameters.AddWithValue("@STORAGE_CD", cmb_stor);

                int qResult = wAdo.SqlCommandEtc(sCommand, "insert_ITEM_OUT_TB");
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

        public int deleteItemOut(string out_date, string out_cd)
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb = new StringBuilder();
                sb.AppendLine("delete from F_ITEM_OUT ");
                sb.AppendLine("    where OUTPUT_DATE = @OUTPUT_DATE ");
                sb.AppendLine("    and OUTPUT_CD = @OUTPUT_CD ");


                sb.AppendLine("delete from F_ITEM_OUT_DETAIL ");
                sb.AppendLine("    where OUTPUT_DATE = @OUTPUT_DATE ");
                sb.AppendLine("    and OUTPUT_CD = @OUTPUT_CD ");

                SqlCommand sCommand = new SqlCommand(sb.ToString());

                sCommand.Parameters.AddWithValue("@OUTPUT_DATE", out_date);
                sCommand.Parameters.AddWithValue("@OUTPUT_CD", out_cd);

                int qResult = wAdo.SqlCommandEtc(sCommand, "delete_ITEM_OUTPUT_TB");
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

        public DataTable cucust(string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select b.cust_nm from f_order a   ");
            sb.AppendLine(" left outer join N_CUST_CODE b on a.CUST_CD = b.CUST_CD   ");
            sb.AppendLine("group by b.cust_nm   ");
            
            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            return wAdo.SqlCommandSelect(sCommand);

        }


        #region 화인
        //화인 제품이력관리
        public DataTable hwa_item_list(string condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SELECT  ");
            sb.AppendLine("A.ITEM_CD, A.ITEM_NM, A.SPEC  ");
            sb.AppendLine(", B.SALE_DATE AS '매출일자'  ");
            sb.AppendLine(", B.SALE_NUM AS '매출번호'  ");
            sb.AppendLine(", B.SALE_QTY AS '매출수량'  ");
            sb.AppendLine(", B.SALE_PRICE AS '매출단가'  ");
            sb.AppendLine(", B.SALE_AMT AS '매출금액'  ");
            sb.AppendLine(", B.LAST_DATE AS '최종매출일'  ");
            sb.AppendLine(", C.RETURN_DATE AS '반품일자'  ");
            sb.AppendLine(", C.RETURN_NUM AS '반품번호'  ");
            sb.AppendLine(", C.RETURN_QTY AS '반품수량'  ");
            sb.AppendLine(", C.RETURN_PRICE AS '반품단가'  ");
            sb.AppendLine(", C.RETURN_AMT AS '반품금액'  ");
            sb.AppendLine(", D.ORD_DATE AS '주문일자'  ");
            sb.AppendLine(", D.ORD_NUM AS '주문번호'  ");
            sb.AppendLine(", D.ORD_QTY AS '주문수량'  ");
            sb.AppendLine(", D.ORD_PRICE AS '주문단가'  ");
            sb.AppendLine(", D.ORD_AMT AS '주문금액'  ");
            sb.AppendLine(", E.DELIVERY_QTY AS '배송수량'  ");
            sb.AppendLine("FROM N_ITEM_CODE A  ");
            sb.AppendLine("LEFT OUTER JOIN S_매출등록_D B ON A.ITEM_CD = B.ITEM_CD  ");
            sb.AppendLine("LEFT OUTER JOIN S_반품등록_D C ON A.ITEM_CD = C.ITEM_CD  ");
            sb.AppendLine("LEFT OUTER JOIN S_주문등록_D D ON A.ITEM_CD = D.ITEM_CD  ");
            sb.AppendLine("LEFT OUTER JOIN S_배송등록_D E ON A.ITEM_CD = E.ITEM_CD  ");
            sb.AppendLine(condition);                   
    
            Debug.WriteLine(sb);
            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }

        public DataTable useGrid(string condition)
        {
            StringBuilder sb = new StringBuilder(); 
            
            sb.AppendLine("SELECT   ");
            sb.AppendLine("ORD_DATE, ORD_NUM, ORD_INPUT, ORD_TIME, C.CUST_NM, B.STAFF_NM, VAT_CD, A.COMMENT, A.CUST_CD, A.STORAGE_CD,  A.STAFF_CD, A.DELIVERY_CD, ");
            sb.AppendLine("(SELECT STAFF_NM FROM N_STAFF_CODE WHERE A.DELIVERY_CD = STAFF_CD) AS DELIVERY_NM   ");
            sb.AppendLine("FROM S_주문등록_H A    ");
            sb.AppendLine("LEFT OUTER JOIN N_STAFF_CODE B ON A.STAFF_CD = B.STAFF_CD      ");
            sb.AppendLine("LEFT OUTER JOIN N_CUST_CODE C ON A.CUST_CD = C.CUST_CD  ");            
            sb.AppendLine("WHERE 1=1 ");
            sb.AppendLine(condition);

            Debug.WriteLine(sb);
            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);
        }
   
        public int insertOrdGrid(
            string txt_ord_date
            , string txt_ord_num
            , string cmb_staff
            , string cmb_stor
            , string cmb_vat
            , string cmb_delivery_staff
            , string txt_comment
            , string txt_cust_nm
            , string txt_cust_cd
            )
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                //sb.AppendLine(" select ");
                //sb.AppendLine("(select COUNT(*) from N_STAFF_CODE where STAFF_CD = '" + txt_user_cd + "' ) as cnt ");
                //sb.AppendLine(",(select COUNT(*) from N_STAFF_CODE where LOGIN_ID = '" + txt_login + "') as id ");
                ////sb.AppendLine(",(select COUNT(*) from N_STAFF_CODE where PW = 1) as pw ");
                //sb.AppendLine("from N_STAFF_CODE  ");


                SqlCommand sCommand = new SqlCommand(sb.ToString());
                if (sCommand.CommandText.Equals(null))
                {
                    wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                    return 2;
                }

                DataTable dt = wAdo.SqlCommandSelect(sCommand);

                //if (!dt.Rows[0]["cnt"].ToString().Equals("0"))
                //{
                //    return 3;
                //}
                //if (!dt.Rows[0]["id"].ToString().Equals("0"))
                //{
                //    return 4;
                //}
                //if (!dt.Rows[0]["pw"].ToString().Equals("0"))
                //{
                //    return 5;
                //}

                sb = new StringBuilder();
                sb.AppendLine("INSERT INTO S_주문등록_H( ");
                sb.AppendLine("ORD_DATE, ORD_NUM,  ORD_TIME, CUST_CD, STAFF_CD, DELIVERY_CD, STORAGE_CD, VAT_CD, COMMENT, INSERT_STAFF, INSERT_DATE) ");
                sb.AppendLine("VALUES(@ORD_DATE, @ORD_NUM,  @ORD_TIME, @CUST_CD ,@STAFF_CD, @DELIVERY_CD, @STORAGE_CD, @VAT_CD , @COMMENT, @INSERT_STAFF, @INSERT_DATE) ");
          
                sCommand = new SqlCommand(sb.ToString());    
                sCommand.Parameters.AddWithValue("@ORD_DATE", txt_ord_date);
                sCommand.Parameters.AddWithValue("@ORD_NUM", txt_ord_num);        
                sCommand.Parameters.AddWithValue("@ORD_TIME", DateTime.Now);
                sCommand.Parameters.AddWithValue("@CUST_CD", txt_cust_cd);
                sCommand.Parameters.AddWithValue("@STAFF_CD", cmb_staff);
                sCommand.Parameters.AddWithValue("@DELIVERY_CD", cmb_delivery_staff);
                sCommand.Parameters.AddWithValue("@STORAGE_CD", cmb_stor);
                sCommand.Parameters.AddWithValue("@VAT_CD", cmb_vat);
                sCommand.Parameters.AddWithValue("@COMMENT", txt_comment);     
                sCommand.Parameters.AddWithValue("@INSERT_STAFF", Common.p_strUserName);     
                sCommand.Parameters.AddWithValue("@INSERT_DATE", DateTime.Now);               
                
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

        public int updateOrdGrid(
            string txt_ord_date
            , string txt_ord_num
            , string cmb_staff
            , string cmb_stor
            , string cmb_vat
            , string cmb_delivery_staff
            , string txt_comment
            , string txt_cust_nm
            , string txt_cust_cd
            )
        {
            try
            {
                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                //sb.AppendLine(" select ");
                //sb.AppendLine("(select COUNT(*) from N_STAFF_CODE where STAFF_CD = '" + txt_user_cd + "' ) as cnt ");
                //sb.AppendLine(",(select COUNT(*) from N_STAFF_CODE where LOGIN_ID = '" + txt_login + "') as id ");
                ////sb.AppendLine(",(select COUNT(*) from N_STAFF_CODE where PW = 1) as pw ");
                //sb.AppendLine("from N_STAFF_CODE  ");


                SqlCommand sCommand = new SqlCommand(sb.ToString());
                if (sCommand.CommandText.Equals(null))
                {
                    wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                    return 2;
                }

                DataTable dt = wAdo.SqlCommandSelect(sCommand);

                //if (!dt.Rows[0]["cnt"].ToString().Equals("0"))
                //{
                //    return 3;
                //}
                //if (!dt.Rows[0]["id"].ToString().Equals("0"))
                //{
                //    return 4;
                //}
                //if (!dt.Rows[0]["pw"].ToString().Equals("0"))
                //{
                //    return 5;
                //}

                sb = new StringBuilder();
                sb.AppendLine("UPDATE S_주문등록_H SET ");
                sb.AppendLine("ORD_TIME = @ORD_TIME  ");
                sb.AppendLine(",CUST_CD = @CUST_CD , STAFF_CD = @STAFF_CD, DELIVERY_CD = @DELIVERY_CD ");
                sb.AppendLine(",  STORAGE_CD = @STORAGE_CD , VAT_CD = @VAT_CD ,COMMENT = @COMMENT ");
                sb.AppendLine(",  UPDATE_STAFF = @UPDATE_STAFF , UPDATE_DATE = @UPDATE_DATE  ");
                sb.AppendLine(" where ORD_DATE = @ORD_DATE ");
                sb.AppendLine(" AND ORD_NUM = @ORD_NUM ");      

                sCommand = new SqlCommand(sb.ToString());
                sCommand.Parameters.AddWithValue("@ORD_DATE", txt_ord_date);
                sCommand.Parameters.AddWithValue("@ORD_NUM", txt_ord_num);
                sCommand.Parameters.AddWithValue("@ORD_TIME", DateTime.Now);
                sCommand.Parameters.AddWithValue("@CUST_CD", txt_cust_cd);
                sCommand.Parameters.AddWithValue("@STAFF_CD", cmb_staff);
                sCommand.Parameters.AddWithValue("@DELIVERY_CD", cmb_delivery_staff);
                sCommand.Parameters.AddWithValue("@STORAGE_CD", cmb_stor);
                sCommand.Parameters.AddWithValue("@VAT_CD", cmb_vat);
                sCommand.Parameters.AddWithValue("@COMMENT", txt_comment);
                sCommand.Parameters.AddWithValue("@UPDATE_STAFF", Common.p_strUserName);
                sCommand.Parameters.AddWithValue("@UPDATE_DATE", DateTime.Now);

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




        #endregion 화인


    }
    
}
