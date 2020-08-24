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
    public partial class frm원자재투입현황 : Form
    {
        Popup.frmPrint readyPrt = new Popup.frmPrint();
        private wnGConstant wConst = new wnGConstant();

        DataTable adoPrt = null;
        wnAdo wAdo = new wnAdo();
        public Popup.frmPrint frmPrt;

        public string strDay1 = "";
        public string strDay2 = "";
        public string strCondition = "";
        public static bool p_IsAuth = true;    // 열람권한
        public static bool p_Isrgstr = true;    //등록/수정 권한

        public static bool p_Isdel = true;    // 삭제 권한
        wnDm wnDm = new wnDm();
        public frm원자재투입현황()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm원자재투입현황_Load(object sender, EventArgs e)
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

            init_ComboBox();

            GridList();

        }

        private void init_ComboBox()
        {
        }

        private void btnSrch_Click(object sender, EventArgs e)
        {
            GridList();
        }

        private void GridList()
        {
            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = null;

                StringBuilder sb = new StringBuilder();



                sb.AppendLine("where 1=1 ");
                sb.AppendLine("and A.OUTPUT_DATE >= '" + start_date.Text.ToString() + "' and  A.OUTPUT_DATE <= '" + end_date.Text.ToString() + "'");

                if (txt_srch_raw_cd.Text != null && !txt_srch_raw_cd.Text.ToString().Equals(""))
                {
                    sb.AppendLine(" and B.RAW_MAT_CD = '"+txt_srch_raw_cd.Text.ToString()+"'  ");
                }

                if (txt_Srch_item_cd.Text != null && !txt_Srch_item_cd.Text.ToString().Equals(""))
                {
                    sb.AppendLine(" and D.ITEM_CD = '" + txt_Srch_item_cd.Text.ToString() + "'  ");
                }

                if (txt_lot.Text != null && !txt_lot.Text.ToString().Equals(""))
                {
                    sb.AppendLine(" and C.LOT_NO = '" + txt_lot.Text.ToString() + "'  ");
                }

                

                dt = wDm.fn_Raw_Output_List(sb.ToString());

                adoPrt = new DataTable();
                adoPrt = dt.Copy();

                this.rawOutGrid.RowCount = dt.Rows.Count;
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        rawOutGrid.Rows[i].Cells["OUTPUT_DATE"].Value = dt.Rows[i]["출고일자"].ToString();
                        rawOutGrid.Rows[i].Cells["RAW_MAT_CD"].Value = dt.Rows[i]["원자재코드"].ToString();
                        rawOutGrid.Rows[i].Cells["RAW_MAT_NM"].Value = dt.Rows[i]["원자재명"].ToString();
                        rawOutGrid.Rows[i].Cells["SPEC"].Value = dt.Rows[i]["규격"].ToString();
                        rawOutGrid.Rows[i].Cells["LOT_NO"].Value = dt.Rows[i]["제조번호"].ToString();
                        rawOutGrid.Rows[i].Cells["제품명"].Value = dt.Rows[i]["제품명"].ToString();
                        rawOutGrid.Rows[i].Cells["제품규격"].Value = dt.Rows[i]["제품규격"].ToString();
                        rawOutGrid.Rows[i].Cells["수주계획"].Value = dt.Rows[i]["PLAN_NUM"].ToString();
                    
                        rawOutGrid.Rows[i].Cells["TOTAL_AMT"].Value = (decimal.Parse(dt.Rows[i]["투입량"].ToString())).ToString("#,0.######");
                    }
                    no.Visible = false;
                    //wConst.mergeCells(rawOutGrid, 5);
                }
                else
                {
                    rawOutGrid.Rows.Clear();
                }

                //데이타 끝나고 다시 copy를 써준 이유는 for중에 no에 값을 엏었기 때문에 출력물 데이타테이블(dt)를 다시 복사함
                adoPrt = dt.Copy();
            }
            catch (Exception ex)
            {
                MessageBox.Show("시스템 오류" + ex.ToString());
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                msg.ShowDialog();
            }
        }


        private void btn출력_Click(object sender, EventArgs e)
        {
            btn출력.Enabled = false;

            strCondition = "";

            if (rawOutGrid.Rows.Count == 0)
            {
                MessageBox.Show("출력할 자료가 없습니다.");
                btn출력.Enabled = true;
                return;
            }

            strDay1 = start_date.Text;
            strDay2 = end_date.Text;
            strCondition = "원자재투입현황";

            frmPrt = readyPrt;
            frmPrt.Show();
            frmPrt.BringToFront();
            //frmPrt.prt_원자재재고현황(adoPrt, strDay1, strDay2, strCust, strCondition);
            frmPrt.prt_원자재투입현황(adoPrt, strDay1, strDay2, strCondition);

            btn출력.Enabled = true;
        }

        private void btn_raw_srch_Click(object sender, EventArgs e)
        {
            Popup.pop원자재검색 msg = new Popup.pop원자재검색();
            msg.txtSrch.Text = txt_srch_raw.Text;
            msg.ShowDialog();

            if (msg.sRetCode != null && !msg.sRetCode.Equals(""))
            {
                txt_srch_raw.Text = msg.sRetNM;
                txt_srch_raw_cd.Text = msg.sRetCode;
            }
        }

        private void chk_all_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_all.Checked)
            {
                chk_all.Checked = false;
                txt_srch_raw.Text = "";
                txt_srch_raw_cd.Text = "";
            }
        }

        private void chk_all2_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_all2.Checked)
            {
                chk_all2.Checked = false;
                txt_Srch_item.Text = "";
                txt_Srch_item_cd.Text = "";
            }
        }

        private void btn_item_srch_Click(object sender, EventArgs e)
        {
            wnDm wDm = new wnDm();
            Popup.pop_sf_제품검색 msg = new Popup.pop_sf_제품검색();
            msg.dt = wDm.fn_Item_List("where 1=1  ");
            msg.ShowDialog();

            if (msg.sCode != null && !msg.sCode.Equals(""))
            {
                txt_Srch_item.Text = msg.sName;
                txt_Srch_item_cd.Text = msg.sCode;
            }
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
                    GridList();
                    break;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
            return true;
        }

        private void rawOutGrid_VisibleChanged(object sender, EventArgs e)
        {
            ComInfo.gridHeaderSet((DataGridView)sender);
        }
    }
}
