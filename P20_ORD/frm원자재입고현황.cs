using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MES.CLS;

namespace MES.P20_ORD
{
    public partial class frm원자재입고현황 : Form
    {
        Popup.frmPrint readyPrt = new Popup.frmPrint();
        private wnGConstant wConst = new wnGConstant();

        DataTable adoPrt = null;
        wnAdo wAdo = new wnAdo();
        public Popup.frmPrint frmPrt;

        public string strDay1 = "";
        public string strDay2 = "";
        public string strCondition = "";

        public frm원자재입고현황()
        {
            InitializeComponent();
        }
        public static bool p_IsAuth = true;    // 열람권한
        public static bool p_Isrgstr = true;    //등록/수정 권한

        public static bool p_Isdel = true;    // 삭제 권한
        wnDm wnDm = new wnDm();
        private void frm원자재입고현황_Load(object sender, EventArgs e)
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
           
            grdCellSetting();

            init_ComboBox();
        }

        #region button logic

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            in_rm_ledger_logic("");
        }

        #endregion button logic

        private void init_ComboBox() 
        {
            ComInfo comInfo = new ComInfo();
            string sqlQuery = "";

            cmb_cd_srch.Items.Add("전체 검색");
            cmb_cd_srch.Items.Add("코드별 검색");
            cmb_cd_srch.Items.Add("원자재명 검색");
            cmb_cd_srch.Items.Add("규격 검색");
            cmb_cd_srch.SelectedIndex = 0;


            //cmb_cust.ValueMember = "코드";
            //cmb_cust.DisplayMember = "명칭";
            //sqlQuery = comInfo.queryCust("2");
            //wConst.ComboBox_Read_Blank(cmb_cust, sqlQuery);

            //cmb_raw.ValueMember = "코드";
            //cmb_raw.DisplayMember = "명칭";
            //sqlQuery = comInfo.queryRaw();
            //wConst.ComboBox_Read_Blank(cmb_raw, sqlQuery);
        }
        private void in_rm_ledger_logic(string barCondition)
        {
            wnDm wDm = new wnDm();
            DataTable dt = null;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("where 1=1 ");
            sb.AppendLine("and A.INPUT_DATE >= '" + start_date.Text.ToString() + "' and  A.INPUT_DATE <= '" + end_date.Text.ToString() + "'");
           
            if (cmb_cd_srch.SelectedIndex == 0)
            {
                sb.AppendLine("");
            }
            else if (cmb_cd_srch.SelectedIndex == 1)
            {
                if (txt_srch.Text.ToString().Equals(""))
                {
                    MessageBox.Show("코드명을 입력하시기 바랍니다.");
                    return;
                }
                sb.AppendLine("and A.RAW_MAT_CD like '%" + txt_srch.Text.ToString() + "%' ");

            }
            else if (cmb_cd_srch.SelectedIndex == 2)
            {
                if (txt_srch.Text.ToString().Equals(""))
                {
                    MessageBox.Show("원자재명을 입력하시기 바랍니다.");
                    return;
                }
                sb.AppendLine("and B.RAW_MAT_NM like '%" + txt_srch.Text.ToString() + "%' ");
            }
            else
            {
                if (txt_srch.Text.ToString().Equals(""))
                {
                    MessageBox.Show("규격을 입력하시기 바랍니다.");
                    return;
                }
                sb.AppendLine(" and B.SPEC like '%" + txt_srch.Text.ToString() + "%' ");
            }

            dt = wDm.fn_Input_Rm_Ledger_List(sb.ToString());

            inputRmGrid.Rows.Clear();

            adoPrt = new DataTable();
            adoPrt = dt.Copy();
            INPUT_CD.Visible = true;
            SEQ.Visible = true;
         
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //string t_amt = string.Format("{0:#.##}", 100.2);
                    inputRmGrid.Rows.Add();

                    dt.Rows[i]["no"] = (i + 1); //숫자의 경우  문자면 .string : 계산된 값을 READ 한 테이블로 다시 전달한다 - 출력물 사용

                    inputRmGrid.Rows[i].Cells["INPUT_DATE"].Value = dt.Rows[i]["입고일자"].ToString();
                    inputRmGrid.Rows[i].Cells["INPUT_CD"].Value = dt.Rows[i]["입고번호"].ToString();
                    inputRmGrid.Rows[i].Cells["SEQ"].Value = dt.Rows[i]["입고순번"].ToString();
                    inputRmGrid.Rows[i].Cells["CUST_CD"].Value = dt.Rows[i]["거래처코드"].ToString();
                    inputRmGrid.Rows[i].Cells["CUST_NM"].Value = dt.Rows[i]["거래처명"].ToString();
                    inputRmGrid.Rows[i].Cells["RAW_MAT_NM"].Value = dt.Rows[i]["원자재명"].ToString();
                    inputRmGrid.Rows[i].Cells["RAW_MAT_CD"].Value = dt.Rows[i]["원자재코드"].ToString();
                    inputRmGrid.Rows[i].Cells["SPEC"].Value = dt.Rows[i]["규격"].ToString();
                    inputRmGrid.Rows[i].Cells["UNIT_CD"].Value = dt.Rows[i]["단위코드"].ToString();
                    inputRmGrid.Rows[i].Cells["UNIT_NM"].Value = dt.Rows[i]["단위명"].ToString();
                    inputRmGrid.Rows[i].Cells["RAW_MAT_GUBUN"].Value = dt.Rows[i]["구분코드"].ToString();
                    inputRmGrid.Rows[i].Cells["RAW_MAT_GUBUN_NM"].Value = dt.Rows[i]["구분명"].ToString();

                    inputRmGrid.Rows[i].Cells["TEMP_AMT"].Value = (decimal.Parse(dt.Rows[i]["가입고수량"].ToString())).ToString("#,0.######");
                    inputRmGrid.Rows[i].Cells["TOTAL_AMT"].Value = (decimal.Parse(dt.Rows[i]["수량"].ToString())).ToString("#,0.######");
                    inputRmGrid.Rows[i].Cells["PRICE"].Value = (decimal.Parse(dt.Rows[i]["단가"].ToString())).ToString("#,0.######");
                    inputRmGrid.Rows[i].Cells["TOTAL_MONEY"].Value = (decimal.Parse(dt.Rows[i]["금액"].ToString())).ToString("#,0.######");

                    inputRmGrid.Rows[i].Cells["HEAT_NO"].Value = dt.Rows[i]["HEATNO"].ToString();
                }
            }

            //데이타 끝나고 다시 copy를 써준 이유는 for중에 no에 값을 엏었기 때문에 출력물 데이타테이블(dt)를 다시 복사함
            adoPrt = dt.Copy();
        }

        private void grdCellSetting()
        {
            ComInfo comInfo = new ComInfo();
            comInfo.grdCellSetting2(inputRmGrid);
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

            strDay1 = start_date.Text;
            strDay2 = end_date.Text;
            strCondition = "원자재원장현황";

            frmPrt = readyPrt;
            frmPrt.Show();
            frmPrt.BringToFront();
            //frmPrt.prt_원자재재고현황(adoPrt, strDay1, strDay2, strCust, strCondition);
            frmPrt.prt_원자재원장현황(adoPrt, strDay1, strDay2, strCondition);

            btn출력.Enabled = true;
        }

        private void btnRaw_Click(object sender, EventArgs e)
        {
            Popup.pop원자재검색 frm = new Popup.pop원자재검색();

            //frm.sUsedYN = sUsedYN;
            frm.ShowDialog();

            if (frm.sRetCode != "")
            {
                //cmb_raw.SelectedValue = frm.sRetCode.Trim();
            }

            frm.Dispose();
            frm = null;
        }

        private void btnCust_Click(object sender, EventArgs e)
        {
            Popup.pop거래처검색 frm = new Popup.pop거래처검색();

            frm.sCustGbn = "2";
            frm.ShowDialog();

            if (frm.sCode != "")
            {
               // cmb_cust.SelectedValue = frm.sCode.Trim();
            }

            frm.Dispose();
            frm = null;
        }

        private void cmb_raw_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComInfo.onlyNum(sender, e);

            //if (cmb_raw.Text.Length >= 14)
            //{
            //    StringBuilder sb = new StringBuilder();
            //    sb.AppendLine(" and CONVERT(NVARCHAR(8),CONVERT (DATE, A.INPUT_DATE),112) ");
            //    sb.AppendLine(" +RIGHT('000'+CONVERT(varchar,A.INPUT_CD),4) ");
            //    sb.AppendLine(" +RIGHT('0'+CONVERT(varchar,A.SEQ),2) = '"+cmb_raw.Text.ToString() +"' ");

            //    in_rm_ledger_logic(sb.ToString());
            //}
        }
    }
}
