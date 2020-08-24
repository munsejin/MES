using MES.CLS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MES.P30_SCH
{
    public partial class frm공정관리 : Form
    {
        private wnGConstant wConst = new wnGConstant();
        private ComInfo comInfo = new ComInfo();
        wnDm wnDm = new wnDm();


        public frm공정관리()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private String strLOTNO = "";
        private String strITM_NM = "";
        private String strITM_CD = "";
        private String strSPEC = "";
        private String strwork_date = "";
        private String strCustCD = "";
        private String strinst_amt = "";
        private String strchar_amt = "";
        private String strpack_amt = "";
        private int Intstep = 0;
        private bool Is완료 = false;
        private void btn_work_srch_Click(object sender, EventArgs e)
        {
            Popup.pop작업지시검색 frm = new Popup.pop작업지시검색();

            frm.ShowDialog();
            dgv_FLOW.Rows.Clear();
            txt_Staff.Text= Common.p_strUserName;
            if (frm.sCode != "")
            {
                strLOTNO = frm.dgv.Rows[0].Cells["LOT_NO"].Value.ToString();
                strITM_NM = frm.dgv.Rows[0].Cells["ITEM_NM"].Value.ToString();
                txt_lotNO.Text = strLOTNO;
                strITM_CD = frm.dgv.Rows[0].Cells["ITEM_CD"].Value.ToString();
                strSPEC = frm.dgv.Rows[0].Cells["SPEC"].Value.ToString();
                strwork_date = frm.dgv.Rows[0].Cells["W_INST_DATE"].Value.ToString();
                strCustCD = frm.dgv.Rows[0].Cells["거래처코드"].Value.ToString();

                strinst_amt = (decimal.Parse(frm.dgv.Rows[0].Cells["INST_AMT"].Value.ToString())).ToString("#,0.######");
                strchar_amt = (decimal.Parse(frm.dgv.Rows[0].Cells["CHARGE_AMT"].Value.ToString())).ToString("#,0.######");
                strpack_amt = (decimal.Parse(frm.dgv.Rows[0].Cells["PACK_AMT"].Value.ToString())).ToString("#,0.######");
                Intstep = 1;
                flow_detail_logic();
            }
            else
            {
                //txt_lot_no.Text = "";   
            }

            

            frm.Dispose();
            frm = null;
        }

        private void flow_detail_logic()
        {
            DataTable dt = new DataTable();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" where A.ITEM_CD = '" + strITM_CD.ToString() + "' ");
            sb.AppendLine(" and B.FLOW_INSERT_YN = 'Y' ");

            dt = wnDm.fn_Item_Flow_List(sb.ToString());

            txt_item_NM.Text = strITM_NM;
            txt_ODR.Text = strinst_amt;
            txt_INP.Text = strinst_amt;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dgv_FLOW.Rows.Add();
                dgv_FLOW.Rows[i].Cells["D_LOTNO"].Value = strLOTNO;
                dgv_FLOW.Rows[i].Cells["D_LOT_SUB"].Value = "1";
               //D_LOT_SUB
                dgv_FLOW.Rows[i].Cells["D_F_STEP"].Value = dt.Rows[i]["SEQ"].ToString();
                dgv_FLOW.Rows[i].Cells["D_FLOW_NM"].Value=dt.Rows[i]["FLOW_NM"].ToString();
            
            }


        }

        private void dgv_FLOW_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_FLOW_NM.Text = dgv_FLOW.Rows[e.RowIndex].Cells["D_FLOW_NM"].Value.ToString();
            txt_STEP.Text = dgv_FLOW.Rows[e.RowIndex].Cells["D_F_STEP"].Value.ToString();
        }

        private void frm공정관리_Load(object sender, EventArgs e)
        {
            string sqlQuery = "";
            cmb_line.ValueMember = "코드";
            cmb_line.DisplayMember = "명칭";
            sqlQuery = comInfo.queryLine();
            wConst.ComboBox_Read_Blank(cmb_line, sqlQuery);
        }

        private void btn_NEXT_Click(object sender, EventArgs e)
        {

            //현단계  데이터 저장 
            Debug.WriteLine(txt_STEP.Text+"공정완료");
            int input = int.Parse(txt_INP.Text.ToString()); //투입량
            int LOSS = int.Parse(txtLOSS.Value.ToString()); // 로스 
            var POOR2 = txtPOOR1.Value + txtPOOR2.Value + txtPOOR3.Value;  //불량
            int POOR = (int)POOR2;

            int Remain= input - LOSS - POOR;  //완료 
           dgv_FLOW.Rows[Intstep].Cells["D_투입량"].Value = input;
           dgv_FLOW.Rows[Intstep].Cells["D_LOSS"].Value = LOSS;
           dgv_FLOW.Rows[Intstep].Cells["D_POOR"].Value = POOR;
           dgv_FLOW.Rows[Intstep].Cells["D_완료수량"].Value = Remain;

         int 필요수량=  int.Parse(txt_ODR.Text.ToString()) - Remain;
         dgv_FLOW.Rows[Intstep].Cells["D_미완료량"].Value = 필요수량;
             //다음 단계
         if (dgv_FLOW.Rows[Intstep].Cells["D_미완료량"].Value.ToString() != "0")
         {
             dgv_FLOW.Rows[Intstep].Cells["D_진행상황"].Value = "미완료";
         }
        
         else
         {
             dgv_FLOW.Rows[Intstep].Cells["D_진행상황"].Value = "완료";
         }
         if (Is완료)
         {
             dgv_FLOW.Rows[Intstep].Cells["D_진행상황"].Value = "완료";
         }
          

           Intstep++;

           txt_INP.Text = Remain.ToString();
           txtLOSS.Value = 0;
            txtPOOR1.Value=0;
                txtPOOR2.Value=0;
                txtPOOR3.Value = 0;
           txt_FLOW_NM.Text = dgv_FLOW.Rows[Intstep].Cells["D_FLOW_NM"].Value.ToString();
           txt_STEP.Text = dgv_FLOW.Rows[Intstep].Cells["D_F_STEP"].Value.ToString();
        }
       
        
        //강제 완료 
        private void btn_완료_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
                btn.BackColor= Color.White;
            Is완료=true;
        }

        
    }
}
