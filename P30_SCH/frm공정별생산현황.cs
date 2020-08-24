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
    public partial class frm공정별생산현황 : Form
    {
        private wnGConstant wConst = new wnGConstant();

        public frm공정별생산현황()
        {
            InitializeComponent();
        }
        public static bool p_IsAuth = true;    // 열람권한
        public static bool p_Isrgstr = true;    //등록/수정 권한

        public static bool p_Isdel = true;    // 삭제 권한
        wnDm wnDm = new wnDm();
        private void frm공정별생산현황_Load(object sender, EventArgs e)
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
           // flowProdLogic();
        }

        public void init_ComboBox() 
        {
            ComInfo comInfo = new ComInfo();
            string sqlQuery = "";

            //cmb_flow.ValueMember = "코드";
            //cmb_flow.DisplayMember = "명칭";
            //sqlQuery = comInfo.queryFlow();
            //wConst.ComboBox_Read_Blank(cmb_flow, sqlQuery);

            cmb_item.ValueMember = "코드";
            cmb_item.DisplayMember = "명칭";
            sqlQuery = comInfo.queryItemSpec();
            wConst.ComboBox_Read_Blank(cmb_item, sqlQuery);


        }
        #region button logic
        
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            flowProdLogic();
        }

        #endregion button logic

        #region logic 
        private void flowProdLogic()
        {
            flowProdGrid.Rows.Clear();

            DataTable dt = new DataTable();
            wnDm wDm = new wnDm();

           // if (cmb_flow.SelectedValue == null) cmb_flow.SelectedValue = "";
            if (cmb_item.SelectedValue == null) cmb_item.SelectedValue = "";

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" and (C.INPUT_DATE >= '" + start_date.Text.ToString() + "' and C.INPUT_DATE <= '" + end_date.Text.ToString() + "') ");

            //if (cmb_flow.SelectedValue.ToString() != "")
            //{
            //    sb.AppendLine(" and A.FLOW_CD = '" + cmb_flow.SelectedValue + "' ");
            //}

            if (cmb_item.SelectedValue.ToString() != "") 
            {
                sb.AppendLine(" and K.ITEM_CD = '" + cmb_item.SelectedValue + "' ");
            }

            dt = wDm.fn_Flow_Product_List(sb.ToString());

            flowProdGrid.RowCount = dt.Rows.Count;
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    flowProdGrid.Rows[i].Cells["INPUT_DATE"].Value = dt.Rows[i]["INPUT_DATE"].ToString();
                    flowProdGrid.Rows[i].Cells["LOT_NO"].Value = dt.Rows[i]["LOT_NO"].ToString();
                    flowProdGrid.Rows[i].Cells["LOT_SUB"].Value = dt.Rows[i]["LOT_SUB"].ToString();
                    flowProdGrid.Rows[i].Cells["F_STEP"].Value = dt.Rows[i]["F_STEP"].ToString() + "차";
                    flowProdGrid.Rows[i].Cells["FLOW_NM"].Value = dt.Rows[i]["FLOW_NM"].ToString();
                    flowProdGrid.Rows[i].Cells["F_SUB_AMT"].Value = (decimal.Parse(dt.Rows[i]["F_SUB_AMT"].ToString())).ToString("#,0");
                    flowProdGrid.Rows[i].Cells["POOR_AMT"].Value = dt.Rows[i]["POOR_AMT"].ToString();
                    flowProdGrid.Rows[i].Cells["LOSS"].Value = dt.Rows[i]["LOSS"].ToString();
                    flowProdGrid.Rows[i].Cells["COMMENT"].Value = dt.Rows[i]["COMMENT"].ToString();
                    flowProdGrid.Rows[i].Cells["ITEM_NM"].Value = dt.Rows[i]["ITEM_NM"].ToString();
                }
            }
            wConst.mergeCells(flowProdGrid, 4);

        }
        #endregion logic

        private void button1_Click(object sender, EventArgs e)
        {
            flowProdGrid.Rows.Clear();
        }

        private void frm공정별생산현황_Enter(object sender, EventArgs e)
        {
            flowProdLogic();
        }

    }
}
