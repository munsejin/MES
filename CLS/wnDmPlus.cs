using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MES.Controls;
using MES.Popup;
using System.Windows.Forms;

namespace MES.CLS
{
    class wnDmPlus : wnDm
    {
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
            , conDataGridView half_dgv
            , DataGridView 도면등록_dgv)
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
                        sb.AppendLine("     ,ITEM_IDEN_YN ");
                        sb.AppendLine("  )values ( ");
                        sb.AppendLine("     '" + txt_item_cd + "' ");
                        sb.AppendLine("     ,@f_seq" + i + " ");
                        sb.AppendLine("     ,'" + flow_dgv.Rows[i].Cells["FLOW_CD"].Value + "' ");
                        sb.AppendLine("     ,'" + flow_dgv.Rows[i].Cells["FLOW_ETC"].Value + "' ");
                        sb.AppendLine("     ,0 ");
                        sb.AppendLine("     ,0 ");
                        sb.AppendLine("     ,0");
                        if (flow_dgv.Rows[i].Cells["식별표"].Value != null && (bool)flow_dgv.Rows[i].Cells["식별표"].Value)
                        {
                            sb.AppendLine("     ,'Y' ");
                        }
                        else
                        {
                            sb.AppendLine("     ,'N' ");
                        }

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
                string dtp_input_date = DateTime.Now.ToString("yyyy-MM-dd");
                byte[] img;

                if (도면등록_dgv.Rows.Count > 0)
                {
                    sb.AppendLine("declare @INPUT_CD int ");
                    for (int i = 0; i < 도면등록_dgv.Rows.Count; i++)
                    {
                        img = null;

                        sb.AppendLine("select @INPUT_CD=ISNULL(MAX(INPUT_CD),0)+1 from F_DOCUMENT ");
                        sb.AppendLine("where INPUT_DATE = '" + dtp_input_date + "' ");

                        sb.AppendLine("and IMG_GUBUN =  '1' ");

                        sb.AppendLine("insert into F_DOCUMENT(");
                        sb.AppendLine("     INPUT_DATE ");
                        sb.AppendLine("     ,INPUT_CD ");
                        sb.AppendLine("     ,IMG_GUBUN ");
                        sb.AppendLine("     ,STAFF_CD ");
                        sb.AppendLine("     IMG_PATH ");
                        sb.AppendLine("     ,IMG_NAME ");
                        sb.AppendLine("     INTIME ");
                        sb.AppendLine("     ,INSTAFF ");
                        sb.AppendLine("     ,IMG ");
                        sb.AppendLine("     ,ITEM_CD ");
                        sb.AppendLine("  )values ( ");
                        sb.AppendLine("     ,'" + dtp_input_date + "' ");
                        sb.AppendLine("     ,@INPUT_CD ");
                        sb.AppendLine("     ,@IMG_GUBUN ");
                        sb.AppendLine("     ,@STAFF_CD ");
                        sb.AppendLine("     ,'" + 도면등록_dgv.Rows[i].Cells["IMG_SIZE"].Value.ToString() + "' ");
                        sb.AppendLine("     ,'" + 도면등록_dgv.Rows[i].Cells["IMG_NAME"].Value.ToString() + " ");
                        sb.AppendLine("     , convert(varchar,getdate(),120) ");
                        sb.AppendLine("     ,'" + Common.p_strStaffNo + "' ");

                        sb.AppendLine("     ,'" + 도면등록_dgv.Rows[i].Cells["PIC_PATH"].Value.ToString() + "' ");
                        sb.AppendLine("     ,@ITEM_CD ");
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

                    //sb2.AppendLine("DECLARE @LINK INT, @ITEMNM NVARCHAR, @SPEC NVARCHAR  ");
                    //sb2.AppendLine("SET @LINK = (SELECT TOP 1 상품코드   ");
                    //sb2.AppendLine("FROM T_상품정보  ");
                    //sb2.AppendLine("WHERE 사업자번호 = '" + Common.p_saupNo + "'   ");
                    //sb2.AppendLine("ORDER BY 상품코드 DESC) + 1  ");
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
                        return 4;
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

    }
}
