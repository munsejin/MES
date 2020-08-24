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

namespace MES.P30_SCH
{
    public partial class frm구매요청현황 : Form
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

        public static bool p_IsAuth = true;    // 열람권한
        public static bool p_Isrgstr = true;    //등록/수정 권한

        public static bool p_Isdel = true;    // 삭제 권한
        wnDm wnDm = new wnDm();
        public frm구매요청현황()
        {
            InitializeComponent();
        }

        private void frm구매요청현황_Load(object sender, EventArgs e)
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
            start_date.Text = DateTime.Today.AddMonths(-1).ToString("yyyy-MM-dd");

            btnlist();
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSrch_Click(object sender, EventArgs e)
        {
            btnlist();
        }

        private void btnlist()
        {
            try
            {
                strDay1 = start_date.Text.ToString();
                strDay2 = end_date.Text.ToString();

                strDate = DateTime.Today.AddMonths(-1).ToString("yyyy-MM-dd");
                strDate = DateTime.Today.ToString("yyyy-MM-dd");

                DateTime T1 = DateTime.Parse(strDate);

                wnDm wDm = new wnDm();
                DataTable dt = null;
                dt = fn_구매요청현황_List(strDay1, strDay2);

                adoPrt = new DataTable();
                adoPrt = dt.Copy();

                this.itemOutGrid.RowCount = dt.Rows.Count;
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dt.Rows[i]["no"] = (i + 1); //숫자의 경우  문자면 .string : 계산된 값을 READ 한 테이블로 다시 전달한다 - 출력물 사용

                        itemOutGrid.Rows[i].Cells["발주일자"].Value = dt.Rows[i]["ORDER_DATE"].ToString();
                        itemOutGrid.Rows[i].Cells["번호"].Value = dt.Rows[i]["ORDER_CD"].ToString();

                        itemOutGrid.Rows[i].Cells["발주번호"].Value = dt.Rows[i]["ORDER_NUM"].ToString();
                        itemOutGrid.Rows[i].Cells["CUST_CD"].Value = dt.Rows[i]["CUST_CD"].ToString();
                        itemOutGrid.Rows[i].Cells["CUST_NM"].Value = dt.Rows[i]["CUST_NM"].ToString();
                        itemOutGrid.Rows[i].Cells["입고요청일"].Value = dt.Rows[i]["INPUT_REQ_DATE"].ToString();
                        itemOutGrid.Rows[i].Cells["완료여부"].Value = dt.Rows[i]["COMPLETE_YN"].ToString();

                        itemOutGrid.Rows[i].Cells["원자재수"].Value = (decimal.Parse(dt.Rows[i]["품목수량"].ToString())).ToString("#,0");
                        itemOutGrid.Rows[i].Cells["전체수량"].Value = (decimal.Parse(dt.Rows[i]["전체수량"].ToString())).ToString("#,#");

                        itemOutGrid.Rows[i].Cells["MEMO"].Value = dt.Rows[i]["COMMENT"].ToString();
                        itemOutGrid.Rows[i].Cells["담당자명"].Value = dt.Rows[i]["STAFF_NM"].ToString();

                        //DateTime T2 = DateTime.Parse(strDDate);

                        //TimeSpan TS = T2 - T1;
                        //int diffDay = TS.Days;

                        //if (diffDay > 2)
                        //{
                        //    itemOutGrid.Rows[i].Cells["ITEM_CD"].Style.BackColor = Color.Green;
                        //    itemOutGrid.Rows[i].Cells["ITEM_NM"].Style.BackColor = Color.Green;
                        //}
                        //else if (diffDay > 0)
                        //{
                        //    itemOutGrid.Rows[i].Cells["ITEM_CD"].Style.BackColor = Color.Yellow;
                        //    itemOutGrid.Rows[i].Cells["ITEM_NM"].Style.BackColor = Color.Yellow;
                        //}
                        //else
                        //{
                        //    itemOutGrid.Rows[i].Cells["ITEM_CD"].Style.BackColor = Color.Red;
                        //    itemOutGrid.Rows[i].Cells["ITEM_NM"].Style.BackColor = Color.Red;
                        //}

                    }

                    //데이타 끝나고 다시 copy를 써준 이유는 for중에 no에 값을 엏었기 때문에 출력물 데이타테이블(dt)를 다시 복사함
                    adoPrt = dt.Copy();
                }
                else
                {
                    itemOutGrid.Rows.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("시스템 오류");
                wnLog.writeLog(wnLog.LOG_ERROR, ex.Message + " - " + ex.ToString());
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                msg.ShowDialog();
            }
        }


        public DataTable fn_구매요청현황_List(string sDayFrom, string sDayTo)
        {
            StringBuilder sb = new StringBuilder();

            //=================== 구매요청현황 ======================

            sb.AppendLine(" SELECT '' AS no, A.ORDER_DATE ");
            sb.AppendLine("      ,A.ORDER_CD  ");
            sb.AppendLine("      ,A.ORDER_DATE + '-' + CONVERT(CHAR(4),A.ORDER_CD ) AS  ORDER_NUM ");
            sb.AppendLine("      ,A.CUST_CD  ");
            sb.AppendLine("      ,D.CUST_NM  ");
            sb.AppendLine("      ,A.INPUT_REQ_DATE  ");
            sb.AppendLine("      ,A.STAFF_CD ");
            sb.AppendLine("      ,A.COMMENT ");
            sb.AppendLine("      ,E.STAFF_NM ");
            sb.AppendLine("      ,ISNULL(A.COMPLETE_YN,'N') AS COMPLETE_YN  ");
            sb.AppendLine("      ,ISNULL((SELECT COUNT(SEQ)		FROM F_ORDER_DETAIL AS K WHERE A.ORDER_DATE = K.ORDER_DATE AND A.ORDER_CD = K.ORDER_CD), 0) AS 품목수량  ");
            sb.AppendLine("      ,ISNULL((SELECT SUM(TOTAL_AMT) FROM F_ORDER_DETAIL AS K WHERE A.ORDER_DATE = K.ORDER_DATE AND A.ORDER_CD = K.ORDER_CD), 0) AS 전체수량  ");
            sb.AppendLine("  FROM  F_ORDER AS A  ");
        
            sb.AppendLine("  LEFT OUTER JOIN N_CUST_CODE	AS D ON A.CUST_CD = D.CUST_CD  ");
            sb.AppendLine("  LEFT OUTER JOIN N_STAFF_CODE	AS E ON A.STAFF_CD = E.STAFF_CD ");

            sb.AppendLine("  WHERE A.ORDER_DATE BETWEEN @p_from AND @p_to   ");

            sb.AppendLine("  ORDER BY A.ORDER_DATE DESC, A.ORDER_CD ASC  ");

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

        private void itemOutGrid_DoubleClick(object sender, EventArgs e)
        {
            if (itemOutGrid.CurrentCell == null) return;
            if (itemOutGrid.CurrentCell.RowIndex < 0) return;
            if (itemOutGrid.CurrentCell.ColumnIndex < 0) return;

            int nCnt = itemOutGrid.CurrentCell.RowIndex;

            // int nKeyCol = 2;
            // int nKeyCol2 = 3;
            // string sValue = "" + GridRecord.Rows[nCnt].Cells[nKeyCol].Value.ToString();
            // string sValue2 = "" + GridRecord.Rows[nCnt].Cells[nKeyCol2].Value.ToString();
            string sValue = "" + itemOutGrid.Rows[nCnt].Cells["발주일자"].Value.ToString();
            string sValue2 = "" + itemOutGrid.Rows[nCnt].Cells["번호"].Value.ToString();

//========================
            if (sValue2 == "") return;

            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = null;
                dt = fn_원자재현황_List(sValue, sValue2);
                
                adoPrt = new DataTable();
                adoPrt = dt.Copy();

                this.rawGrid.RowCount = dt.Rows.Count;
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //dt.Rows[i]["no"] = (i + 1); //숫자의 경우  문자면 .string : 계산된 값을 READ 한 테이블로 다시 전달한다 - 출력물 사용

                        rawGrid.Rows[i].Cells["no"].Value = dt.Rows[i]["no"].ToString();
                        rawGrid.Rows[i].Cells["원자재코드"].Value = dt.Rows[i]["RAW_MAT_CD"].ToString();
                        rawGrid.Rows[i].Cells["원자재명"].Value = dt.Rows[i]["RAW_MAT_NM"].ToString();
                        rawGrid.Rows[i].Cells["규격"].Value = dt.Rows[i]["SPEC"].ToString();
                        rawGrid.Rows[i].Cells["단위"].Value = dt.Rows[i]["UNIT_NM"].ToString();
                        rawGrid.Rows[i].Cells["CUST_NM2"].Value = dt.Rows[i]["CUST_NM"].ToString();

                        decimal decQty = (decimal.Parse(dt.Rows[i]["TOTAL_AMT"].ToString()));
                        if (decQty == 0)
                        {
                            rawGrid.Rows[i].Cells["수량"].Value = "";
                        }
                        else
                        {
                            rawGrid.Rows[i].Cells["수량"].Value = (decimal.Parse(dt.Rows[i]["TOTAL_AMT"].ToString())).ToString("#,0");
                        }

                        decimal decPrice = (decimal.Parse(dt.Rows[i]["PRICE"].ToString()));
                        if (decPrice == 0)
                        {
                            rawGrid.Rows[i].Cells["단가"].Value = "";
                        }
                        else
                        {
                            rawGrid.Rows[i].Cells["단가"].Value = (decimal.Parse(dt.Rows[i]["PRICE"].ToString())).ToString("#,0");
                        }

                        decimal decAmt = (decimal.Parse(dt.Rows[i]["TOTAL_MONEY"].ToString()));
                        if (decAmt == 0)
                        {
                            rawGrid.Rows[i].Cells["금액"].Value = "";
                        }
                        else
                        {
                            rawGrid.Rows[i].Cells["금액"].Value = (decimal.Parse(dt.Rows[i]["TOTAL_MONEY"].ToString())).ToString("#,0");
                        }

                        //DateTime T2 = DateTime.Parse(strDDate);

                        //TimeSpan TS = T2 - T1;
                        //int diffDay = TS.Days;

                        //if (diffDay > 2)
                        //{
                        //    rawGrid.Rows[i].Cells["ITEM_CD"].Style.BackColor = Color.Green;
                        //    rawGrid.Rows[i].Cells["ITEM_NM"].Style.BackColor = Color.Green;
                        //}
                        //else if (diffDay > 0)
                        //{
                        //    rawGrid.Rows[i].Cells["ITEM_CD"].Style.BackColor = Color.Yellow;
                        //    rawGrid.Rows[i].Cells["ITEM_NM"].Style.BackColor = Color.Yellow;
                        //}
                        //else
                        //{
                        //    rawGrid.Rows[i].Cells["ITEM_CD"].Style.BackColor = Color.Red;
                        //    rawGrid.Rows[i].Cells["ITEM_NM"].Style.BackColor = Color.Red;
                        //}



                    }

                    //데이타 끝나고 다시 copy를 써준 이유는 for중에 no에 값을 엏었기 때문에 출력물 데이타테이블(dt)를 다시 복사함
                    adoPrt = dt.Copy();
                }
                else
                {
                    rawGrid.Rows.Clear();
                }
            }
            catch (Exception ex)
            {
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message+" - "+ex.ToString()); msg.ShowDialog();
                wnLog.writeLog(wnLog.LOG_ERROR, ex.Message + " - " + ex.ToString());
            }
        }

        public DataTable fn_원자재현황_List(string sValue, string sValue2)
        {
            StringBuilder sb = new StringBuilder();


            //=================== 구매요청 : 원자재 현황 ======================

            sb.AppendLine(" SELECT '' AS no, A.ORDER_DATE ");
            sb.AppendLine("     , A.ORDER_CD, A.SEQ, A.RAW_MAT_CD, A.UNIT_CD ");
            sb.AppendLine(" 	, A.TOTAL_AMT, A.PRICE, A.TOTAL_MONEY  ");
            sb.AppendLine(" 	, B.RAW_MAT_NM, B.SPEC, C.UNIT_NM,D.CUST_NM      ");
            sb.AppendLine("  FROM F_ORDER_DETAIL AS A  ");
            sb.AppendLine("  LEFT OUTER JOIN N_RAW_CODE		AS B ON A.RAW_MAT_CD = B.RAW_MAT_CD   ");
            sb.AppendLine("  LEFT OUTER JOIN N_UNIT_CODE	AS C ON A.UNIT_CD = C.UNIT_CD   ");
            sb.AppendLine("  LEFT OUTER JOIN N_CUST_CODE	AS D ON B.CUST_CD = D.CUST_CD   ");

            sb.AppendLine("  WHERE A.ORDER_DATE = @value AND A.ORDER_CD = @value2   ");

            sb.AppendLine("  ORDER BY A.SEQ ASC  ");


            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            sCommand.Parameters.AddWithValue("@value", sValue);
            sCommand.Parameters.AddWithValue("@value2", sValue2);
            return wAdo.SqlCommandSelect(sCommand);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            btnPrint.Enabled = false;

            strCondition = "";

            if (itemOutGrid.Rows.Count == 0)
            {
                MessageBox.Show("출력할 자료가 없습니다.");
                btnPrint.Enabled = true;
                return;
            }

            strDay1 = start_date.Text;
            strDay2 = end_date.Text;
            strCondition = "원자재원장현황";

            frmPrt = readyPrt;
            frmPrt.Show();
            frmPrt.BringToFront();
            //frmPrt.prt_원자재재고현황(adoPrt, strDay1, strDay2, strCust, strCondition);
            frmPrt.prt_원자재원장현황(adoPrt, strDay1, strDay2, strCondition);

            btnPrint.Enabled = true;
        }

        private void clear_Click(object sender, EventArgs e)
        {
            itemOutGrid.Rows.Clear();
            rawGrid.Rows.Clear();
        }
    }
}
