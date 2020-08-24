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

namespace MES.P40_ITM
{
    public partial class frm제품입고확정 : Form
    {
        public frm제품입고확정()
        {
            InitializeComponent();
        }
        wnDm wnDm = new wnDm();
        public static bool p_IsAuth = true;    // 열람권한
        public static bool p_Isrgstr = true;    //등록/수정 권한

        public static bool p_Isdel = true;    // 삭제 권한
        private void frm제품입고확정_Load(object sender, EventArgs e)
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



        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

         private void btnSearch_Click(object sender, EventArgs e)
        {
            GridList();
        }

         private void GridList()
         {
             DataTable dt = new DataTable();

             StringBuilder sb = new StringBuilder();
             //sb.AppendLine(" and B.F_SUB_DATE >= '" + start_date.Text.ToString() + "' and  B.F_SUB_DATE <= '" + end_date.Text.ToString() + "' ");
             sb.AppendLine(" and D.ITEM_IDEN_YN = 'Y' ");
             sb.AppendLine(" and A.COMPLETE_YN = 'Y' ");
             sb.AppendLine(" and (C.LINK_CD is not null or C.LINK_CD != '')");
             if (chk미확정.Checked)
             {
                 sb.AppendLine(" and Z.COMPLETE_YN = 'N' ");

             }

             dt = wnDm.fn_Item_Input_List(sb.ToString());

             //if (dt != null && dt.Rows.Count > 0)
             //{
             //    InputTabGrid.DataSource = dt;

             //inputRmGrid.Rows.Clear();
             this.InputTabGrid.DataSource = null;
             this.InputTabGrid.RowCount = 0;

             if (dt != null && dt.Rows.Count > 0)
             {
                 for (int i = 0; i < dt.Rows.Count; i++)


                 //for (int i = 0; i < InputTabGrid.Rows.Count; i++) 
                 {

                     InputTabGrid.Rows.Add();
                     //InputTabGrid.Rows[i].Cells["CHK"].Value = false;
                     InputTabGrid.Rows[i].Cells["LOT_NO"].Value = dt.Rows[i]["LOT_NO"].ToString();
                     InputTabGrid.Rows[i].Cells["LOT_SUB"].Value = dt.Rows[i]["LOT_SUB"].ToString();
                     InputTabGrid.Rows[i].Cells["수주계획"].Value = dt.Rows[i]["PLAN_NUM"].ToString();
                     InputTabGrid.Rows[i].Cells["LOT_식별표"].Value = dt.Rows[i]["LOT_BAR"].ToString();
                     InputTabGrid.Rows[i].Cells["포장일자"].Value = dt.Rows[i]["PACK_DATE"].ToString();
                     InputTabGrid.Rows[i].Cells["제품코드"].Value = dt.Rows[i]["ITEM_CD"].ToString();
                     InputTabGrid.Rows[i].Cells["제품명"].Value = dt.Rows[i]["ITEM_NM"].ToString();
                     InputTabGrid.Rows[i].Cells["규격"].Value = dt.Rows[i]["SPEC"].ToString();
                     InputTabGrid.Rows[i].Cells["단위코드"].Value = dt.Rows[i]["UNIT_CD"].ToString();
                     InputTabGrid.Rows[i].Cells["단위"].Value = dt.Rows[i]["UNIT_NM"].ToString();
                     InputTabGrid.Rows[i].Cells["입고확정여부"].Value = dt.Rows[i]["COMPLETE_YN"].ToString();
                     InputTabGrid.Rows[i].Cells["LINK_CD"].Value = dt.Rows[i]["LINK_CD"].ToString();
                     InputTabGrid.Rows[i].Cells["CHK"].Value = false;
                     if (InputTabGrid.Rows[i].Cells["입고확정여부"].Value.ToString().Equals("Y"))
                     {
                         InputTabGrid.Rows[i].Cells["CHK"].ReadOnly = true;
                     }
                     InputTabGrid.Rows[i].Cells["입고가격"].Value = dt.Rows[i]["INPUT_PRICE"].ToString();


                     InputTabGrid.Rows[i].Cells["수량"].Value = (decimal.Parse(dt.Rows[i]["F_SUB_AMT"].ToString())).ToString("#,0");

                     InputTabGrid.Rows[i].Cells["박스수량"].Value = "1";
                     InputTabGrid.Rows[i].Cells["업체명"].Value = dt.Rows[i]["CUST_NM"].ToString();
                     InputTabGrid.Rows[i].Cells["업체코드"].Value = dt.Rows[i]["cust_CD"].ToString();

                 }
             }
         }

    
         private void resetsetting()
         {
             wnDm wDm = new wnDm();
             DataTable dt = new DataTable();

             StringBuilder sb = new StringBuilder();
             //sb.AppendLine(" and B.F_SUB_DATE >= '" + start_date.Text.ToString() + "' and  B.F_SUB_DATE <= '" + end_date.Text.ToString() + "' ");
             sb.AppendLine(" and D.ITEM_IDEN_YN = 'Y' ");
             sb.AppendLine(" and A.COMPLETE_YN = 'Y' ");
             sb.AppendLine(" and (C.LINK_CD is not null or C.LINK_CD != '')");

             if (chk미확정.Checked)
             {
             sb.AppendLine(" and Z.COMPLETE_YN = 'N' ");
                 
             }

             dt = wDm.fn_Item_Input_List(sb.ToString());

             //if (dt != null && dt.Rows.Count > 0)
             //{
             //    InputTabGrid.DataSource = dt;

             //inputRmGrid.Rows.Clear();
             this.InputTabGrid.DataSource = null;
             this.InputTabGrid.RowCount = 0;

             if (dt != null && dt.Rows.Count > 0)
             {
                 for (int i = 0; i < dt.Rows.Count; i++)


                 //for (int i = 0; i < InputTabGrid.Rows.Count; i++) 
                 {
                     InputTabGrid.Rows.Add();
                     InputTabGrid.Rows[i].Cells["LOT_NO"].Value = dt.Rows[i]["LOT_NO"].ToString();
                     InputTabGrid.Rows[i].Cells["LOT_SUB"].Value = dt.Rows[i]["LOT_SUB"].ToString();
                     InputTabGrid.Rows[i].Cells["LOT_식별표"].Value = dt.Rows[i]["LOT_BAR"].ToString();
                     InputTabGrid.Rows[i].Cells["포장일자"].Value = dt.Rows[i]["PACK_DATE"].ToString();
                     InputTabGrid.Rows[i].Cells["제품코드"].Value = dt.Rows[i]["ITEM_CD"].ToString();
                     InputTabGrid.Rows[i].Cells["제품명"].Value = dt.Rows[i]["ITEM_NM"].ToString();
                     InputTabGrid.Rows[i].Cells["규격"].Value = dt.Rows[i]["SPEC"].ToString();
                     InputTabGrid.Rows[i].Cells["단위코드"].Value = dt.Rows[i]["UNIT_CD"].ToString();
                     InputTabGrid.Rows[i].Cells["단위"].Value = dt.Rows[i]["UNIT_NM"].ToString();
                     InputTabGrid.Rows[i].Cells["입고확정여부"].Value = dt.Rows[i]["COMPLETE_YN"].ToString();
                     InputTabGrid.Rows[i].Cells["LINK_CD"].Value = dt.Rows[i]["LINK_CD"].ToString();
               
                     InputTabGrid.Rows[i].Cells["CHK"].Value = false;
                     if (InputTabGrid.Rows[i].Cells["입고확정여부"].Value.ToString().Equals("Y"))
                     {
                         
                         InputTabGrid.Rows[i].Cells["CHK"].ReadOnly = true;
                     }
                     InputTabGrid.Rows[i].Cells["입고가격"].Value = dt.Rows[i]["INPUT_PRICE"].ToString();


                     InputTabGrid.Rows[i].Cells["수량"].Value = (decimal.Parse(dt.Rows[i]["F_SUB_AMT"].ToString())).ToString("#,0.00");

                     InputTabGrid.Rows[i].Cells["박스수량"].Value = "1";
                     InputTabGrid.Rows[i].Cells["업체명"].Value = dt.Rows[i]["CUST_NM"].ToString();
                     InputTabGrid.Rows[i].Cells["업체코드"].Value = dt.Rows[i]["cust_CD"].ToString();
                 }
             }
         }

         private void btnSave_Click(object sender, EventArgs e)
         {
             if (p_Isrgstr)
             {


                 StringBuilder sb = new StringBuilder();
                 sb.AppendLine("※ 입고 확정 ※");
                 sb.AppendLine("입고일자는 현재 날짜로 저장됩니다.");
                 sb.AppendLine("정말로 저장하시겠습니까? ");
                 ComInfo comInfo = new ComInfo();
                 DialogResult msgOk = comInfo.warningMessage(sb.ToString());

                 if (msgOk == DialogResult.No)
                 {
                     return;
                 }


                 if (InputTabGrid.Rows.Count == 0)
                 {
                     MessageBox.Show("입고확정할 자료가 없습니다.");
                     return;
                 }

                 Boolean chkflag = false;
                 for (int i = 0; i < InputTabGrid.Rows.Count; i++)
                 {
                     if (InputTabGrid.Rows[i].Cells["CHK"].Value == null || (bool)InputTabGrid.Rows[i].Cells["CHK"].Value == true)
                     {
                         chkflag = true;
                         break;
                     }
                 }

                 if (chkflag == false)
                 {
                     MessageBox.Show("입고확정할 자료가 없습니다.");
                     return;
                 }


                 bindData();

             }
             else
             {
                 MessageBox.Show("권한이 없습니다.");
             }

         }


         public void bindData()
         {

             try
             {
                 wnDm wDm = new wnDm();


                         int result = wDm.fn_Insert_Item_To_Jang(InputTabGrid);

                         if (result == 0)
                         {
                             MessageBox.Show("입고 확정 성공");
                             resetsetting();
                             
                         }
                         else
                         {
                             MessageBox.Show("입고 확정 실패");

                         }
                     
                 

                 //데이타 끝나고 다시 copy를 써준 이유는 for중에 no에 값을 엏었기 때문에 출력물 데이타테이블(dt)를 다시 복사함
                 

             }
             catch (Exception ex)
             {
                 MessageBox.Show("검색중에 오류가 발생했습니다.");
                 wnLog.writeLog(wnLog.LOG_ERROR, ex.Message + " - " + ex.ToString());
                 Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                 msg.ShowDialog();
             }
         }

         private void InputTabGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
         {
             //int ischeck = 0;
             //if (e.ColumnIndex==15)
             //{
             //    for (int i = 0; i < InputTabGrid.Rows.Count; i++)
             //    {
             //        if ((bool)InputTabGrid.Rows[i].Cells[15].Value)
             //        {
             //            ischeck = i;
                        
             //        }
             //    }

             //    for (int i = 0; i < InputTabGrid.Rows.Count; i++)
             //    {
             //        InputTabGrid.Rows[i].Cells[15].Value = false;
             //    }
             //    InputTabGrid.Rows[ischeck].Cells[15].Value = true;
                 
             //}
         }

         private void InputTabGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
         {
             //int ischeck = 0;
             //if (e.ColumnIndex == 15)
             //{
             //    for (int i = 0; i < InputTabGrid.Rows.Count; i++)
             //    {
             //        if ((bool)InputTabGrid.Rows[i].Cells[15].Value)
             //        {
             //            ischeck = i;

             //        }
             //    }

             //    for (int i = 0; i < InputTabGrid.Rows.Count; i++)
             //    {
             //        InputTabGrid.Rows[i].Cells[15].Value = false;
             //    }
             //    InputTabGrid.Rows[ischeck].Cells[15].Value = true;

             //}
         }

         private void button1_Click(object sender, EventArgs e)
         {
             InputTabGrid.Rows.Clear();
         }

         private void frm제품입고확정_Enter(object sender, EventArgs e)
         {
             GridList();
         }

        
    }
}
