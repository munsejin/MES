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


namespace MES.P60_FAC
{
    public partial class frm메탈현황 : Form
    {
        Popup.frmPrint readyPrt = new Popup.frmPrint();
        private wnGConstant wConst = new wnGConstant();

        DataTable adoPrt = null;
        wnAdo wAdo = new wnAdo();
        public Popup.frmPrint frmPrt;

        public string strDay1 = "";
        public string strDay2 = "";
        public string strCondition = "";

        public frm메탈현황()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm메탈현황_Load(object sender, EventArgs e)
        {
            MetalGridList("");
        }

        private void MetalGridList(string condition)
        {
            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = null;
                dt = wDm.Metal_List(condition);

                this.dgv_MetalList.RowCount = dt.Rows.Count;
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgv_MetalList.Rows[i].Cells["METAL_CD"].Value = dt.Rows[i]["METAL_CD"].ToString();
                        dgv_MetalList.Rows[i].Cells["METAL_LOTNO"].Value = dt.Rows[i]["METAL_LOTNO"].ToString();
                        dgv_MetalList.Rows[i].Cells["METAL_MODEL"].Value = dt.Rows[i]["METAL_MODEL"].ToString();
                        dgv_MetalList.Rows[i].Cells["METAL_SPEC"].Value = dt.Rows[i]["METAL_SPEC"].ToString();
                        dgv_MetalList.Rows[i].Cells["METAL_MAKECUST"].Value = dt.Rows[i]["METAL_MAKECUST"].ToString();
                        dgv_MetalList.Rows[i].Cells["METAL_INPUT_DATE"].Value = dt.Rows[i]["METAL_INPUT_DATE"].ToString();
                        dgv_MetalList.Rows[i].Cells["METAL_ORDERCUST"].Value = dt.Rows[i]["METAL_ORDERCUST"].ToString();
                        dgv_MetalList.Rows[i].Cells["METAL_MAKE_DATE"].Value = dt.Rows[i]["METAL_MAKE_DATE"].ToString();
                        dgv_MetalList.Rows[i].Cells["METAL_COMMENT"].Value = dt.Rows[i]["COMMENT"].ToString();
                        dgv_MetalList.Rows[i].Cells[9].Value = false;

                    }
                }
                else
                {
                    dgv_MetalList.Rows.Clear();
                }

                adoPrt = new DataTable();
                adoPrt = dt.Copy();

            }

            catch (Exception ex)
            {
            }
        }

        private void btn출력_Click(object sender, EventArgs e)
        {
            btn출력.Enabled = false;

            strCondition = "";

            if (dgv_MetalList.Rows.Count == 0)
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
                strCondition = "메탈식별표";

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
                dt = wDm.Metal_List("");


                adoPrt = new DataTable();
                adoPrt = dt.Copy();

                int j = 0;
                int k = 0;


                for (int i = 0; i < this.dgv_MetalList.Rows.Count; i++)
                {

            if ((bool)dgv_MetalList.Rows[i].Cells[9].Value == true)  //--- 11= 확인 체크필드
                    {
                        k = 1;
                        string sDate = "" + this.dgv_MetalList.Rows[i].Cells["METAL_MODEL"].Value.ToString();    //모델명
                        string sNUm = "" + this.dgv_MetalList.Rows[i].Cells["METAL_SPEC"].Value.ToString();    //규격                        
                        string sName = "" + this.dgv_MetalList.Rows[i].Cells["METAL_MAKECUST"].Value.ToString();    //제조업체
                        string sSpec = "" + this.dgv_MetalList.Rows[i].Cells["METAL_MAKE_DATE"].Value.ToString();    //제조일자
                        string sUnit = "" + this.dgv_MetalList.Rows[i].Cells["METAL_ORDERCUST"].Value.ToString();    //발주업체                      
                        string nCost = "" + this.dgv_MetalList.Rows[i].Cells["METAL_INPUT_DATE"].Value.ToString(); //입고일자
                        string nAmt = "" + this.dgv_MetalList.Rows[i].Cells["METAL_LOTNO"].Value.ToString(); //바코드

                        dt.Rows[j]["METAL_CD"] = j;
                        dt.Rows[j]["METAL_MODEL"] = sDate;
                        dt.Rows[j]["METAL_SPEC"] = sNUm;
                        dt.Rows[j]["METAL_MAKECUST"] = sName;
                        dt.Rows[j]["METAL_MAKE_DATE"] = sSpec;
                        dt.Rows[j]["METAL_ORDERCUST"] = sUnit;
                        dt.Rows[j]["METAL_INPUT_DATE"] = nCost;
                        dt.Rows[j]["METAL_LOTNO"] = nAmt;
                        dt.Rows[j]["COMMENT"] = "";

                        j = j + 1;

                        adoPrt = dt.Copy();

                    }
                    
                }
                //데이타 끝나고 다시 copy를 써준 이유는 for중에 no에 값을 엏었기 때문에 출력물 데이타테이블(dt)를 다시 복사함

                adoPrt = dt.Copy();

                for (int i = j; i < this.dgv_MetalList.Rows.Count; i++)
                {
                    adoPrt.Rows[i].Delete();
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
            }

        }

        public DataTable fn_원자재입고식별표_List()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SELECT   ");
            sb.AppendLine("METAL_CD,METAL_LOTNO,METAL_MODEL,METAL_SPEC,METAL_MAKECUST,METAL_ORDERCUST,METAL_INPUT_DATE,METAL_MAKE_DATE,COMMENT   ");
            sb.AppendLine("FROM N_METAL_CODE ");
            sb.AppendLine("WHERE 1=1 ");

            sb.AppendLine("ORDER BY METAL_CD  ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            return wAdo.SqlCommandSelect(sCommand);
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            dgv_MetalList.Rows.Clear();
            dgv_MetalList.Rows.Clear();
        }

        private void txt_metalnm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_metalsrch.Focus();
            }

            else
            {
                return;
            }
        }

        private void btn_metalsrch_Click(object sender, EventArgs e)
        {

        }

    }
}
