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

namespace MES.P85_BAS
{
    public partial class frm공정별불량유형 : Form
    {
        private wnGConstant wConst = new wnGConstant();

        public frm공정별불량유형()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm공정별불량유형_Load(object sender, EventArgs e)
        {
               lbl_title.Tag = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[0] + "$" + wnDm.fn_TitleName(this.Name.ToString()).Split('$')[1]; lbl_title.Text = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[2];
            
            start_date.Text = DateTime.Today.AddMonths(-1).ToString("yyyy-MM-dd");

            init_ComboBox();
            //flowProdLogic();
            GridList();

        }

        public void init_ComboBox()
        {
            ComInfo comInfo = new ComInfo();
            string sqlQuery = "";

            cmb_flow.ValueMember = "코드";
            cmb_flow.DisplayMember = "명칭";
            sqlQuery = comInfo.queryFlow();
            wConst.ComboBox_Read_Blank(cmb_flow, sqlQuery);

            cmb_item.ValueMember = "코드";
            cmb_item.DisplayMember = "명칭";
            sqlQuery = comInfo.queryItem();
            wConst.ComboBox_Read_Blank(cmb_item, sqlQuery);


        }

        private void flowProdLogic(string condition, string condition2)
        {
            DataTable dt = new DataTable();
            wnDm wDm = new wnDm();

            if (cmb_flow.SelectedValue == null) cmb_flow.SelectedValue = "";
            if (cmb_item.SelectedValue == null) cmb_item.SelectedValue = "";

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" and (C.INPUT_DATE >= '" + start_date.Text.ToString() + "' and C.INPUT_DATE <= '" + end_date.Text.ToString() + "') ");
                      

            dt = wDm.fn_Flow_Product_List(sb.ToString(), condition, condition2);

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
                    flowProdGrid.Rows[i].Cells["POOR_NM"].Value = dt.Rows[i]["POOR_NM"].ToString();
                    flowProdGrid.Rows[i].Cells["F_SUB_AMT"].Value = dt.Rows[i]["F_SUB_AMT"].ToString();
                    flowProdGrid.Rows[i].Cells["POOR_AMT"].Value = (decimal.Parse(dt.Rows[i]["POOR_AMT"].ToString())).ToString("#,0");                                   
                    flowProdGrid.Rows[i].Cells["LOSS"].Value = dt.Rows[i]["LOSS"].ToString();
                    flowProdGrid.Rows[i].Cells["ITEM_NM"].Value = dt.Rows[i]["ITEM_NM"].ToString();
                    flowProdGrid.Rows[i].Cells["COMMENT"].Value = dt.Rows[i]["COMMENT"].ToString();
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            GridList();
        }
        

        private void GridList()
        {
            string condition = "";
            if (cmb_item.SelectedIndex == 0)
            {
                condition = "";
            }
            else
            {
                condition = "AND K.ITEM_CD = '" + cmb_item.SelectedValue.ToString() + "' ";
            }

            string condition2 = "";
            if (cmb_flow.SelectedIndex == 0)
            {
                condition2 = "";
            }
            else
            {
                condition2 = "AND A.FLOW_CD = '" + cmb_flow.SelectedValue.ToString() + "' ";
            }

            flowProdLogic(condition, condition2);
        }


        private void button1_Click(object sender, EventArgs e)
        {
           
        }
    }
}
