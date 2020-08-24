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

namespace MES.P20_ORD
{
    public partial class frm원자재입고식별표 : Form
    {
        Popup.frmPrint readyPrt = new Popup.frmPrint();
        private wnGConstant wConst = new wnGConstant();
       
        DataTable adoPrt = null;
        wnAdo wAdo = new wnAdo();
        public Popup.frmPrint frmPrt;

        public string strCondition = "";

        public frm원자재입고식별표()
        {
            InitializeComponent();
        }

        public static bool p_IsAuth = true;    // 열람권한
        public static bool p_Isrgstr = true;    //등록/수정 권한

        public static bool p_Isdel = true;    // 삭제 권한
        wnDm wnDm = new wnDm();

        private void frm원자재입고식별표_Load(object sender, EventArgs e)
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
           
            input_rm_logic();
            
            //grdCellSetting();
        }

        #region button logic

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSrch_Click(object sender, EventArgs e)
        {
            input_rm_logic();
        }

        #endregion button logic


        private void input_rm_logic() 
        {
            string sDate, sNum, sSeq;
            string sLotno;
            wnDm wDm = new wnDm();
            DataTable dt = null;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("where 1=1 ");
            sb.AppendLine("and A.INPUT_DATE >= '" + start_date.Text.ToString() + "' and  A.INPUT_DATE <= '" + end_date.Text.ToString() + "'");
            sb.AppendLine("and ((A.CHECK_YN = 'Y' and C.PASS_YN = 'Y') or A.CHECK_YN = 'O')"); // 검사 승인 혹은 생략

            dt = wDm.fn_Input_Detail_List(sb.ToString());

            //inputRmGrid.Rows.Clear();
            this.inputRmGrid.DataSource = null;
            this.inputRmGrid.RowCount = 0;

            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //string t_amt = string.Format("{0:#.##}", 100.2);
                    inputRmGrid.Rows.Add();
                    inputRmGrid.Rows[i].Cells["INPUT_DATE"].Value = dt.Rows[i]["INPUT_DATE"].ToString();
                    inputRmGrid.Rows[i].Cells["INPUT_CD"].Value = dt.Rows[i]["INPUT_CD"].ToString();
                    //inputRmGrid.Rows[i].Cells["SEQ"].Value = dt.Rows[i]["SEQ"].ToString();
                    //inputRmGrid.Rows[i].Cells["ORDER_DATE"].Value = dt.Rows[i]["ORDER_DATE"].ToString();
                    //inputRmGrid.Rows[i].Cells["ORDER_CD"].Value = dt.Rows[i]["ORDER_CD"].ToString();
                    //inputRmGrid.Rows[i].Cells["ORDER_SEQ"].Value = dt.Rows[i]["ORDER_SEQ"].ToString();
                    inputRmGrid.Rows[i].Cells["RAW_MAT_NM"].Value = dt.Rows[i]["RAW_MAT_NM"].ToString();
                    inputRmGrid.Rows[i].Cells["RAW_MAT_CD"].Value = dt.Rows[i]["RAW_MAT_CD"].ToString();
                    inputRmGrid.Rows[i].Cells["SPEC"].Value = dt.Rows[i]["SPEC"].ToString();
                    inputRmGrid.Rows[i].Cells["UNIT_CD"].Value = dt.Rows[i]["UNIT_CD"].ToString();
                    inputRmGrid.Rows[i].Cells["UNIT_NM"].Value = dt.Rows[i]["UNIT_NM"].ToString();
                    //inputRmGrid.Rows[i].Cells["RAW_MAT_GUBUN"].Value = dt.Rows[i]["RAW_MAT_GUBUN"].ToString();
                    //inputRmGrid.Rows[i].Cells["RAW_MAT_GUBUN_NM"].Value = dt.Rows[i]["RAW_MAT_GUBUN_NM"].ToString();

                    inputRmGrid.Rows[i].Cells["TOTAL_AMT"].Value = (decimal.Parse(dt.Rows[i]["TOTAL_AMT"].ToString())).ToString("#,0.######");
                    //inputRmGrid.Rows[i].Cells["OLD_TOTAL_AMT"].Value = dt.Rows[i]["TOTAL_AMT"].ToString();
                    inputRmGrid.Rows[i].Cells["PRICE"].Value = (decimal.Parse(dt.Rows[i]["PRICE"].ToString())).ToString("#,0.######");
                    inputRmGrid.Rows[i].Cells["TOTAL_MONEY"].Value = (decimal.Parse(dt.Rows[i]["TOTAL_MONEY"].ToString())).ToString("#,0.######");

                    inputRmGrid.Rows[i].Cells["HEAT_NO"].Value = dt.Rows[i]["HEAT_NO"].ToString();
                    //inputRmGrid.Rows[i].Cells["HEAT_TIME"].Value = dt.Rows[i]["HEAT_TIME"].ToString();

                    inputRmGrid.Rows[i].Cells[11].Value = false ;

                    sDate = DateTime.Parse("" + inputRmGrid.Rows[i].Cells["INPUT_DATE"].Value.ToString()).ToString("yyyyMMdd");
                    sNum = "" + dt.Rows[i]["번호"].ToString();
                    sSeq = "" + dt.Rows[i]["순번"].ToString();
                    sLotno = sDate + sNum + sSeq;

                    //inputRmGrid.Rows[i].Cells["INPUT_CD"].Value = sDate + sNum;
                    inputRmGrid.Rows[i].Cells["LOTNO"].Value = sLotno.ToString();
                    inputRmGrid.Rows[i].Cells["CUST_CD"].Value = dt.Rows[i]["CUST_CD"].ToString();
                    inputRmGrid.Rows[i].Cells["CUST_NM"].Value = dt.Rows[i]["CUST_NM"].ToString();
                }
            }
        }

        private void grdCellSetting()
        {
            ComInfo comInfo = new ComInfo();
            comInfo.grdCellSetting(inputRmGrid);
        }

        private void btn출력_Click(object sender, EventArgs e)
        {
            btn출력.Enabled = false;

            strCondition = "";

            if (inputRmGrid.Rows.Count == 0)
            {
                MessageBox.Show("출력할 자료가 없습니다.");
                btn출력.Enabled = true;
                return;
            }

            bindData();

            if (strCondition == "No")
            {
                MessageBox.Show("출력할 자료가 없습니다.");
                btn출력.Enabled = true;
                return;
            }

            if (strCondition != "ERROR")
            {
                strCondition = "원자재입고식별표";

                frmPrt = readyPrt;
                frmPrt.Show();
                frmPrt.BringToFront();
                frmPrt.prt_식별표(adoPrt, strCondition);
            }

            btn출력.Enabled = true;
        }

        public void bindData()
        {
            Application.DoEvents();

            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = null;
                dt = fn_원자재입고식별표_List();

                adoPrt = new DataTable();
                adoPrt = dt.Copy();

                int j = 0;
                int k = 0;

                for (int i = 0; i < this.inputRmGrid.Rows.Count; i++)
                {
                    if ((bool)inputRmGrid.Rows[i].Cells[11].Value == true)  //--- 11= 확인 체크필드
                    {
                        k = 1;
                        string sDate = "" + this.inputRmGrid.Rows[i].Cells[0].Value.ToString();    //입고일자
                        string sNUm = "" + this.inputRmGrid.Rows[i].Cells[1].Value.ToString();    //입고번호
                        //string sSeq = "" + this.inputRmGrid.Rows[i].Cells[2].Value.ToString();    //입고순번
                        string sName = "" + this.inputRmGrid.Rows[i].Cells[2].Value.ToString();    //원자재명
                        string sSpec = "" + this.inputRmGrid.Rows[i].Cells[3].Value.ToString();    //규격
                        string sUnit = "" + this.inputRmGrid.Rows[i].Cells[4].Value.ToString();    //단위
                        //string sODate = "" + this.inputRmGrid.Rows[i].Cells[1].Value.ToString();    //주문일자
                        //string sONUm = "" + this.inputRmGrid.Rows[i].Cells[2].Value.ToString();    //주문번호
                        //string sOSeq = "" + this.inputRmGrid.Rows[i].Cells[2].Value.ToString();    //주문순번

                        string nQty = "" + decimal.Parse(this.inputRmGrid.Rows[i].Cells[5].Value.ToString().Trim()).ToString("#,0.######"); //수량
                        string nCost = "" + this.inputRmGrid.Rows[i].Cells[6].Value.ToString().Trim(); //단가
                        string nAmt = "" + this.inputRmGrid.Rows[i].Cells[7].Value.ToString().Trim(); //금액

                        string sHeat = "" + this.inputRmGrid.Rows[i].Cells[8].Value.ToString();    //heat no
                        //string sHeatTime = "" + this.inputRmGrid.Rows[i].Cells[6].Value.ToString();    //heat no
                        string sCode = "" + this.inputRmGrid.Rows[i].Cells[9].Value.ToString();    //원자재코드
                        string sUcode = "" + this.inputRmGrid.Rows[i].Cells[10].Value.ToString();    //단위코드

                        //string sIsbn = "*" + this.inputRmGrid.Rows[i].Cells[5].Value.ToString() + "*";    //단위

                        string sLotno = "" + this.inputRmGrid.Rows[i].Cells[12].Value.ToString();    //lot no
                        string sCustcd = "" + this.inputRmGrid.Rows[i].Cells[13].Value.ToString();    //cust_cd
                        string sCustnm = "" + this.inputRmGrid.Rows[i].Cells[14].Value.ToString();    //cust_nm 

                        sNUm = sLotno.Substring(0, 12); //--- 입고번호 = 입고일자+번호(yyyyMMdd0000)

                        dt.Rows[j]["no"] = j;

                        dt.Rows[j]["입고일자"] = sDate;
                        dt.Rows[j]["입고번호"] = sNUm;
                        dt.Rows[j]["입고순번"] = "";
                        dt.Rows[j]["원자재코드"] = sCode;
                        dt.Rows[j]["원자재명"] = sName;
                        dt.Rows[j]["규격"] = sSpec;
                        dt.Rows[j]["HEAT_NO"] = sHeat;
                        dt.Rows[j]["HEAT_TIME"] = "";
                        dt.Rows[j]["ORDER_DATE"] = "";
                        dt.Rows[j]["ORDER_CD"] = "";
                        dt.Rows[j]["ORDER_SEQ"] = "";
                        dt.Rows[j]["RAW_MAT_GUBUN"] = "";
                        dt.Rows[j]["S_CODE_NM"] = "";
                        dt.Rows[j]["단위코드"] = sUcode;
                        dt.Rows[j]["단위명"] = sUnit;
                        dt.Rows[j]["수량"] = nQty;
                        dt.Rows[j]["단가"] = nCost;
                        dt.Rows[j]["금액"] = nAmt;
                        dt.Rows[j]["제조번호"] = sLotno;
                        dt.Rows[j]["바코드제조번호"] = "*" + sLotno + "*";
                        dt.Rows[j]["제조번호"] = sLotno;
                        dt.Rows[j]["공급처"] = sCustnm;

                        j = j+1;

                        adoPrt = dt.Copy();
                    }
                }

                //데이타 끝나고 다시 copy를 써준 이유는 for중에 no에 값을 엏었기 때문에 출력물 데이타테이블(dt)를 다시 복사함
                adoPrt = dt.Copy();

                //for (int i = j; i < this.inputRmGrid.Rows.Count; i++)
                //{
                //    adoPrt.Rows[i].Delete();
                //}
                for (int i = 0; i < adoPrt.Rows.Count; i++)
                {
                    if (adoPrt.Rows[i]["no"] == null || adoPrt.Rows[i]["no"].ToString().Equals(""))
                    {
                        adoPrt.Rows[i].Delete();
                    }
                }
                adoPrt.AcceptChanges(); //--삭제확정

                if (k == 0)
                {
                    strCondition = "No";
                }

            }
            catch (Exception ex)
            {
                strCondition = "ERROR";
                MessageBox.Show("검색중에 오류가 발생했습니다.");
                wnLog.writeLog(wnLog.LOG_ERROR, ex.Message + " - " + ex.ToString());
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                msg.ShowDialog();
            }

        }

        public DataTable fn_원자재입고식별표_List()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SELECT A.INPUT_DATE, '' AS no, '' AS 입고일자, '' AS 입고번호, ''  AS 입고순번, '' AS 원자재코드, '' 원자재명, '' AS 규격    ");
            sb.AppendLine(", '' AS HEAT_NO, '' AS HEAT_TIME, '' AS ORDER_DATE, '' AS ORDER_CD, '' AS ORDER_SEQ, '' AS RAW_MAT_GUBUN ");
            sb.AppendLine(", '' AS S_CODE_NM, '' AS 단위코드, '' AS 단위명  ");
            sb.AppendLine(", '' AS 수량, '' AS 단가, '' AS 금액, '' AS 제조번호, '' AS 바코드제조번호, '' AS 공급처");

            sb.AppendLine("  FROM F_RAW_DETAIL			AS A  ");
            sb.AppendLine(" WHERE A.INPUT_DATE >= '" + start_date.Text.ToString() + "' AND  A.INPUT_DATE <= '" + end_date.Text.ToString() + "'");
            sb.AppendLine(" AND (A.CHECK_YN = 'Y' OR A.CHECK_YN = 'O') ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            return wAdo.SqlCommandSelect(sCommand);
        }

        private void clear_Click(object sender, EventArgs e)
        {
            inputRmGrid.Rows.Clear();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            Keys key = keyData & ~(Keys.Shift | Keys.Control);
            switch (key)
            {
                case Keys.W:
                    // 조합키 사용 시
                    if ((keyData & Keys.Control) != 0)
                    {
                        this.Close();
                    }
                    else return base.ProcessCmdKey(ref msg, keyData);
                    break;
                case Keys.S:
                    // 조합키 사용 시
                    if ((keyData & Keys.Control) != 0)
                    {
                        
                    }
                    else return base.ProcessCmdKey(ref msg, keyData);
                    break;
                case Keys.F5:
                    // 단일키 사용시
                    input_rm_logic();
                    break;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
            return true;
        }

        private void inputRmGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (inputRmGrid.Columns[e.ColumnIndex].Name.ToString().Equals("CHK"))
            {
                if (inputRmGrid.Columns[e.ColumnIndex].HeaderText.ToString().Equals("[ ]"))
                {
                    for (int i = 0; i < inputRmGrid.Rows.Count; i++)
                    {
                        inputRmGrid.Rows[i].Cells["CHK"].Value = (bool)true;
                    }
                    inputRmGrid.Columns[e.ColumnIndex].HeaderText = "[v]";
                }
                else
                {
                    for (int i = 0; i < inputRmGrid.Rows.Count; i++)
                    {
                        inputRmGrid.Rows[i].Cells["CHK"].Value = (bool)false;
                    }
                    inputRmGrid.Columns[e.ColumnIndex].HeaderText = "[ ]";
                }
            }
        }

        private void inputRmGrid_VisibleChanged(object sender, EventArgs e)
        {
            ComInfo.gridHeaderSet((DataGridView)sender);
        }

    }
}
