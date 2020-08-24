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
    public partial class frm자재입고현황 : Form
    {

        wnGConstant wConst = new wnGConstant();
        private Color ColorBlue = Color.FromArgb(67, 114, 196);
        private Color ColorOrange = Color.FromArgb(237, 125, 49);
        private int btnFlag = 1;
        public frm자재입고현황()
        {
            InitializeComponent();
        }

        private void frm자재입고현황_Load(object sender, EventArgs e)
        {
            lbl_title.Tag = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[0] + "$" + wnDm.fn_TitleName(this.Name.ToString()).Split('$')[1]; lbl_title.Text = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[2];

            lbl_start_date.Text = DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd");
            lbl_end_date.Text = DateTime.Now.ToString("yyyy-MM-dd");
            btn_N.BackColor = ColorBlue;
            btn_N.ForeColor = Color.WhiteSmoke;
            set_BtnSetDateValue();

            chk_out_yn.Checked = true;
            btnSearch.PerformClick();
        }

        private void btn_SetDate_MouseClick(object sender, MouseEventArgs e)
        {
            Button btnTemp = (Button)sender;
            Popup.popDatePicker msg = new Popup.popDatePicker(lbl_start_date.Text, lbl_end_date.Text, Cursor.Position.X, Cursor.Position.Y);
            //msg.StartPosition = FormStartPosition.
            msg.Location = new Point(btnTemp.Location.X + btnTemp.Width + 7, btnTemp.Location.Y + 152);
            msg.ShowDialog();

            if (!msg.returnS_date.Equals(""))
            {
                lbl_start_date.Text = msg.returnS_date;
                lbl_end_date.Text = msg.returnE_date;
                set_BtnSetDateValue();
            }
        }

        private void set_BtnSetDateValue()
        {
            btn_SetDate.Text = lbl_start_date.Text + " - " + lbl_end_date.Text + " ▼";
        }

        private void btn_N_Click(object sender, EventArgs e)
        {
            btn_N.ForeColor = Color.WhiteSmoke;
            btn_Y.ForeColor = Color.FromArgb(64, 64, 64);
            btn_N.BackColor = ColorBlue;
            btn_Y.BackColor = Color.WhiteSmoke;
            btnFlag = 1;
        }

        private void btn_Y_Click(object sender, EventArgs e)
        {
            btn_N.ForeColor = Color.FromArgb(64, 64, 64);
            btn_Y.ForeColor = Color.WhiteSmoke;
            btn_N.BackColor = Color.WhiteSmoke;
            btn_Y.BackColor = ColorBlue;
            btnFlag = 2;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
           
        }

        private void btn_raw_srch_Click(object sender, EventArgs e)
        {
            
        }

        private void UpdateList()
        {
            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = null;
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("and A.ORDER_DATE >= '"+lbl_start_date.Text+"'  and A.ORDER_DATE <= '"+lbl_end_date.Text+"' ");
                if(btnFlag == 1)
                {
                    sb.AppendLine(" and B.TOTAL_COUNT > B.DONE_COUNT ");
                    sb.AppendLine("  and A.COMPLETE_YN is not null and A.COMPLETE_YN = 'N'  ");
                }
                
                dt = wDm.fn_Order_Status(sb.ToString());

                orderGrid.Rows.Clear();
                inputGrid.Rows.Clear();
                if (dt != null && dt.Rows.Count > 0)
                {
                    orderGrid.RowCount = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        orderGrid.Rows[i].Cells["발주일자"].Value = dt.Rows[i]["ORDER_DATE"].ToString();
                        orderGrid.Rows[i].Cells["발주번호"].Value = dt.Rows[i]["ORDER_CD"].ToString();
                        orderGrid.Rows[i].Cells["발주처"].Value = dt.Rows[i]["CUST_NM"].ToString();
                        orderGrid.Rows[i].Cells["입고요청일"].Value = dt.Rows[i]["INPUT_REQ_DATE"].ToString();
                        orderGrid.Rows[i].Cells["발주자재"].Value = dt.Rows[i]["RAW_MAT_NM"].ToString();
                        orderGrid.Rows[i].Cells["상태"].Value = dt.Rows[i]["완료여부"].ToString();
                        orderGrid.Rows[i].Cells["완료여부"].Value = dt.Rows[i]["FLAG"].ToString();
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception 오류");
            }





        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            UpdateList();
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

        private void orderGrid_VisibleChanged(object sender, EventArgs e)
        {
            ComInfo.gridHeaderSet((DataGridView)sender);

        }

        private void jumunGrid_VisibleChanged(object sender, EventArgs e)
        {
            ComInfo.gridHeaderSet((DataGridView)sender);

        }

        private void orderGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                inputGrid.Rows.Clear();
                wnDm wDm = new wnDm();
                string order_date = orderGrid.Rows[e.RowIndex].Cells["발주일자"].Value.ToString();
                string order_cd = orderGrid.Rows[e.RowIndex].Cells["발주번호"].Value.ToString();
                DataTable dt = wDm.fn_Order_Status_detail(order_date, order_cd);
                if (dt != null && dt.Rows.Count > 0)
                {
                    inputGrid.RowCount = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        inputGrid.Rows[i].Cells["최근입고일자"].Value = dt.Rows[i]["INPUT_DATE"].ToString();
                        inputGrid.Rows[i].Cells["자재명"].Value = dt.Rows[i]["RAW_MAT_NM"].ToString();
                        inputGrid.Rows[i].Cells["규격"].Value = dt.Rows[i]["SPEC"].ToString();
                        inputGrid.Rows[i].Cells["단위"].Value = dt.Rows[i]["UNIT_NM"].ToString();
                        inputGrid.Rows[i].Cells["발주량"].Value = decimal.Parse(dt.Rows[i]["ORDER_AMT"].ToString()).ToString("#,0.######");
                        inputGrid.Rows[i].Cells["입고량"].Value = decimal.Parse(dt.Rows[i]["INPUT_AMT"].ToString()).ToString("#,0.######");
                        if (dt.Rows[i]["comp"].ToString().Equals("N"))
                        {
                            DataGridViewCellStyle st = new DataGridViewCellStyle();
                            st.BackColor = Color.PaleGoldenrod;
                            st.SelectionBackColor = Color.PaleGoldenrod;
                            inputGrid.Rows[i].Cells["입고량"].Style = st;
                        }
                    }
                }
            }
        }

        private void chk_out_yn_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_out_yn.Checked)
            {
                btnFlag = 1;
            }
            else
            {
                btnFlag = 2;
            }
        }

    }
}
