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

namespace MES.P10_PLN
{
    public partial class frm발주서등록현황 : Form
    {

        wnGConstant wConst = new wnGConstant();
        private Color ColorBlue = Color.FromArgb(67, 114, 196);
        private Color ColorOrange = Color.FromArgb(237, 125, 49);
        private int btnFlag = 1;
        public frm발주서등록현황()
        {
            InitializeComponent();
        }

        private void frm발주서등록현황_Load(object sender, EventArgs e)
        {
            lbl_title.Tag = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[0] + "$" + wnDm.fn_TitleName(this.Name.ToString()).Split('$')[1]; lbl_title.Text = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[2];

            lbl_start_date.Text = DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd");
            lbl_end_date.Text = DateTime.Now.ToString("yyyy-MM-dd");
            btn_N.BackColor = ColorBlue;
            btn_N.ForeColor = Color.WhiteSmoke;
            set_BtnSetDateValue();


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
            Popup.pop원자재검색 msg = new Popup.pop원자재검색();
            //msg.txtSrch.Text = txt_srch.Text();
            msg.ShowDialog();

            if (msg.sRetCode != null && !msg.sRetCode.Equals(""))
            {
                txt_srch.Text = msg.sRetNM;
                txt_srch2.Text = msg.sRetCode;
            }
        }

        private void UpdateList()
        {
            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = null;
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("WHERE A.ORDER_DATE >= '"+lbl_start_date.Text+"'  and A.ORDER_DATE <= '"+lbl_end_date.Text+"' ");
                if(btnFlag == 1)
                {
                    sb.AppendLine(" and C.ORDER_DATE is null ");
                }
                else
                {
                    sb.AppendLine(" and C.ORDER_DATE is not null ");
                }

                if(txt_srch2.Text != null && !txt_srch2.Text.ToString().Equals("")) sb.AppendLine(" and A.RAW_MAT_CD = '"+txt_srch2.Text.ToString()+"' ");
                dt = wDm.fn_Order_Detail_List(sb.ToString());

                orderGrid.Rows.Clear();
                if (dt != null && dt.Rows.Count > 0)
                {
                    orderGrid.RowCount = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        orderGrid.Rows[i].Cells["입고요청일"].Value = dt.Rows[i]["INPUT_REQ_DATE"].ToString();
                        orderGrid.Rows[i].Cells["자재명"].Value = dt.Rows[i]["RAW_MAT_NM"].ToString();
                        orderGrid.Rows[i].Cells["발주일자"].Value = dt.Rows[i]["ORDER_DATE"].ToString();
                        orderGrid.Rows[i].Cells["발주처"].Value = dt.Rows[i]["CUST_NM"].ToString();
                        orderGrid.Rows[i].Cells["수량"].Value = decimal.Parse(dt.Rows[i]["TOTAL_AMT"].ToString()).ToString("#,0.######");
                        orderGrid.Rows[i].Cells["단가"].Value = decimal.Parse(dt.Rows[i]["PRICE"].ToString()).ToString("#,0.######");
                        orderGrid.Rows[i].Cells["가격"].Value = decimal.Parse(dt.Rows[i]["TOTAL_MONEY"].ToString()).ToString("#,0.######");
                    }
                }
                sb.Clear();
                sb.AppendLine(" and J.JUMUN_DATE >= '"+lbl_start_date.Text+"'  and J.JUMUN_DATE <= '"+lbl_end_date.Text+"'  ");
                dt = wDm.fn_Order_Detail_List_notCompleted(sb.ToString());

                jumunGrid.Rows.Clear();
                string 수주일자 = "";
                string 수주번호 = "";
                string 수주순번 = "";
                if (dt != null && dt.Rows.Count > 0)
                {
                    
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (수주일자.Equals(dt.Rows[i]["수주일자"].ToString()) &&
                           수주번호.Equals(dt.Rows[i]["수주번호"].ToString()) &&
                            수주순번.Equals(dt.Rows[i]["수주순번"].ToString()))
                        {
                            if (decimal.Parse(dt.Rows[i]["자재재고"].ToString()) - decimal.Parse(dt.Rows[i]["예상소요량"].ToString()) < 0)
                            {
                                jumunGrid.Rows[jumunGrid.Rows.Count - 1].Cells["발주필요자재"].Value = jumunGrid.Rows[jumunGrid.Rows.Count - 1].Cells["발주필요자재"].Value
                                    + ", " + dt.Rows[i]["자재명"].ToString() + " (" + decimal.Parse(dt.Rows[i]["자재재고"].ToString()).ToString("#,0.######") + "/"
                                    + decimal.Parse(dt.Rows[i]["예상소요량"].ToString()).ToString("#,0.######") + "/" + (decimal.Parse(dt.Rows[i]["예상소요량"].ToString()) - decimal.Parse(dt.Rows[i]["자재재고"].ToString())).ToString("#,0.######")
                                    + ")";
                            }
                            continue;
                        }
                        jumunGrid.Rows.Add();
                        jumunGrid.Rows[jumunGrid.Rows.Count -1].Cells["납품요구일"].Value = dt.Rows[i]["납품요구일"].ToString();
                        jumunGrid.Rows[jumunGrid.Rows.Count -1].Cells["제품명"].Value = dt.Rows[i]["제품명"].ToString();
                        jumunGrid.Rows[jumunGrid.Rows.Count -1].Cells["수주일자"].Value = dt.Rows[i]["수주일자"].ToString();
                        jumunGrid.Rows[jumunGrid.Rows.Count -1].Cells["매출처"].Value = dt.Rows[i]["매출처"].ToString();
                        jumunGrid.Rows[jumunGrid.Rows.Count -1].Cells["수량2"].Value = decimal.Parse(dt.Rows[i]["수주수량"].ToString()).ToString("#,0.######");
                        if (decimal.Parse(dt.Rows[i]["자재재고"].ToString()) - decimal.Parse(dt.Rows[i]["예상소요량"].ToString()) < 0)
                        {
                            jumunGrid.Rows[jumunGrid.Rows.Count - 1].Cells["발주필요자재"].Value =
                                dt.Rows[i]["자재명"].ToString() + " (" + decimal.Parse(dt.Rows[i]["자재재고"].ToString()).ToString("#,0.######") + "/"
                                + decimal.Parse(dt.Rows[i]["예상소요량"].ToString()).ToString("#,0.######") + "/" + (decimal.Parse(dt.Rows[i]["예상소요량"].ToString()) - decimal.Parse(dt.Rows[i]["자재재고"].ToString())).ToString("#,0.######")
                                + ")";
                        }
                        else
                        {
                            jumunGrid.Rows[jumunGrid.Rows.Count - 1].Cells["발주필요자재"].Value = "";
                        }
                        jumunGrid.Rows[jumunGrid.Rows.Count - 1].Cells["상태"].Value = dt.Rows[i]["STATE_FLAG"].ToString();
                        수주일자 = dt.Rows[i]["수주일자"].ToString();
                        수주번호 = dt.Rows[i]["수주번호"].ToString();
                        수주순번 = dt.Rows[i]["수주순번"].ToString();
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

    }
}
