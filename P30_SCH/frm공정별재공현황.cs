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

namespace MES.P30_SCH
{
    public partial class frm공정별재공현황 : Form
    {
        public frm공정별재공현황()
        {
            InitializeComponent();
        }
        public static bool p_IsAuth = true;    // 열람권한
        public static bool p_Isrgstr = true;    //등록/수정 권한

        public static bool p_Isdel = true;    // 삭제 권한
        wnDm wnDm = new wnDm();
        private void frm공정별재공현황_Load(object sender, EventArgs e)
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
            itemFlowLogic();
        }

        #region button logic

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion button logic

        #region 공정현황 logic

        private void itemFlowLogic() 
        {
            DataTable dt = new DataTable();
            wnDm wDm = new wnDm();
            dt = wDm.fn_Item_Flow_Con_List();

            itemFlowGrid.Rows.Clear();
            if (dt != null && dt.Rows.Count > 0) 
            {
                itemFlowGrid.RowCount = dt.Rows.Count;
                for (int i = 0; i < dt.Rows.Count; i++) 
                {
                    itemFlowGrid.Rows[i].Cells["ITEM_CD"].Value = dt.Rows[i]["ITEM_CD"].ToString();
                    itemFlowGrid.Rows[i].Cells["ITEM_NM"].Value = dt.Rows[i]["ITEM_NM"].ToString();
                    itemFlowGrid.Rows[i].Cells["SPEC"].Value = dt.Rows[i]["SPEC"].ToString();
                    itemFlowGrid.Rows[i].Cells["LOT_NO"].Value = dt.Rows[i]["LOT_NO"].ToString();
                    itemFlowGrid.Rows[i].Cells["W_INST_DATE"].Value = dt.Rows[i]["W_INST_DATE"].ToString();
                    itemFlowGrid.Rows[i].Cells["LOT_TOT_FLOW_NM"].Value = dt.Rows[i]["LOT_TOT_FLOW_NM"].ToString();
                }
                detailLogic(itemFlowGrid, 0);
            }
        }

        private void itemFlowGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridView dgv = (DataGridView)sender;
                detailLogic(dgv, e.RowIndex);
            }
        }

        private void detailLogic(DataGridView dgv, int idx) 
        {
            DataTable dt = new DataTable();
            wnDm wDm = new wnDm();

            dt = wDm.fn_Item_Flow_Con_Dt_List(dgv.Rows[idx].Cells["LOT_NO"].Value.ToString());
            flowDetailGrid.DataSource = dt;

            for (int i = 0; i < flowDetailGrid.Rows.Count; i++) 
            {
                if (int.Parse(flowDetailGrid.Rows[i].Cells[10].Value.ToString()) >= 7 && int.Parse(flowDetailGrid.Rows[i].Cells[10].Value.ToString()) <= 13 ) // 경과일자
                {
                    flowDetailGrid.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                } 
                else if (int.Parse(flowDetailGrid.Rows[i].Cells[10].Value.ToString()) > 14)
                {
                    flowDetailGrid.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                }
            }
        }

        #endregion 공정현황 logic

        private void btnNew_Click(object sender, EventArgs e)
        {
            itemFlowGrid.Rows.Clear();
            flowDetailGrid.Rows.Clear();

            itemFlowLogic();
        }
    }
}
