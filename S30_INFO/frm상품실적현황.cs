using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MES.CLS;

namespace MES.S30_INFO
{
    public partial class frm상품실적현황 : Form
    {
        
        private wnGConstant wConst = new wnGConstant();

        

        public frm상품실적현황()
        {
            InitializeComponent();
        }

        private void frm상품실적현황_Load(object sender, EventArgs e)
        {
            lbl_title.Tag = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[0] + "$" + wnDm.fn_TitleName(this.Name.ToString()).Split('$')[1]; lbl_title.Text = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[2];
            
            start_date.Text = DateTime.Today.ToString("yyyy-MM-dd").Substring(0, 8) + "01";
            
        }

        #region button logic

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            lblMsg.Visible = true;
            Application.DoEvents();
            in_grid_logic();
            lblMsg.Visible = false;

        }

        
        

        #endregion button logic


        private void in_grid_logic()
        {
            wnDm wDm = new wnDm();
            DataTable dt = null;

            dt = wDm.fn_Product_Info_Sales_List(start_date.Text, end_date.Text,chk_grade.Checked,chk_not_Activity.Checked);

            if (dt != null && dt.Rows.Count > 0)
            {
                ItemGrid.Rows.Clear();
                ItemGrid.RowCount = dt.Rows.Count;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["ITEM_CD"].ToString().ToString().Equals("=== 합계 ==="))
                    {
                        DataGridViewCellStyle style = new DataGridViewCellStyle();
                        style.BackColor = Color.Khaki;
                        style.SelectionBackColor = Color.DarkKhaki;
                        for (int j = 0; j < ItemGrid.ColumnCount; j++)
                        {
                            ItemGrid.Rows[i].Cells[j].Style = style;
                        }
                    }
                    ItemGrid.Rows[i].Cells["상품코드"].Value = dt.Rows[i]["ITEM_CD"].ToString();
                 
                    ItemGrid.Rows[i].Cells["상품명"].Value = dt.Rows[i]["ITEM_NM"].ToString();
                    
                    ItemGrid.Rows[i].Cells["규격"].Value = dt.Rows[i]["SPEC"].ToString();
                    ItemGrid.Rows[i].Cells["단위"].Value = dt.Rows[i]["UNIT_NM"].ToString();
                    ItemGrid.Rows[i].Cells["수량"].Value = decimal.Parse(dt.Rows[i]["TOTAL_AMT"].ToString()).ToString("#,0.######");
                    ItemGrid.Rows[i].Cells["금액"].Value = decimal.Parse(dt.Rows[i]["TOTAL_MONEY"].ToString()).ToString("#,0.######");
                    ItemGrid.Rows[i].Cells["평균단가"].Value = decimal.Parse(dt.Rows[i]["평균단가"].ToString()).ToString("#,0.######");

                }
            }

            
            


        }

        
        private void grdCellSetting()
        {
            ComInfo comInfo = new ComInfo();
            comInfo.grdCellSetting2(ItemGrid);
        }

        private void btn출력_Click(object sender, EventArgs e)
        {
           
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

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
                    btnSearch.PerformClick();
                    break;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
            return true;
        }
       
       
        
    }
}
