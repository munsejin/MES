using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MES.Popup;
using MES.CLS;
namespace MES.P85_BAS
{
    public partial class frm단가관리 : Form
    {
        public frm단가관리()
        {
            InitializeComponent();
        }
        private string cust;
        private string item;
        ComInfo comInfo = new ComInfo();
        wnGConstant wConst = new wnGConstant();
        wnDm wDm = new wnDm();

        int ckQuery;
        pop거래처검색 pop;
        DataTable dt;
        private void frm단가관리_Load(object sender, EventArgs e)
        {
            //dt = new MES.Model.Query.scQuery().selectPriceInfoSearch();
            //grdLoad(dt);
            string sqlQuery = "";
            cbo_cust.ValueMember = "코드";
            cbo_cust.DisplayMember = "명칭";
            sqlQuery = comInfo.queryCustSell();
            wConst.ComboBox_Read_NoBlank(cbo_cust, sqlQuery);

            //cbo_cust.SelectedIndex = 0;



            ComInfo.gridHeaderSet(grd_ucost);
        }


        private void btn_sales_Click(object sender, EventArgs e)
        {

            Button btnselect = sender as Button;
            buttonOff(btnselect);
            pop = new pop거래처검색();

            pop.sCustGbn = "1";
            pop.FormClosing += new FormClosingEventHandler(closeing);
            pop.ShowDialog();

        }

        private void closeing(object sender, FormClosingEventArgs e)
        {
            txt_cust_nm.Text = pop.sName;
            txt_cust_cd.Text = pop.sCode;
        }

        private void buttonOff(Button btn)
        {

            foreach (Control crtl in this.Controls)
            {
                Console.Write(crtl.GetType().ToString() + "//");

                if (crtl.GetType().ToString() == "System.Windows.Forms.Button")
                {
                    Console.Write(crtl.GetType().ToString());
                    crtl.BackColor = Color.Silver;

                }
                btn.BackColor = Color.White;
            }

        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            if (cbo_cust.SelectedValue == null) return;
            
           
            grdLoad();
            btn_save.Enabled = true;
            
        }

        private void grdLoad()
        {
            dt = wDm.selectPriceInfoSearch(cbo_cust.SelectedValue.ToString());
            grd_ucost.Rows.Clear();
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    grd_ucost.Rows.Add();
                    grd_ucost.Rows[i].Cells["CUST_CD"].Value =  cbo_cust.SelectedValue.ToString();
                    grd_ucost.Rows[i].Cells["B_BOX_PRICE"].Value = (decimal.Parse(dt.Rows[i]["B_BOX_PRICE"].ToString())).ToString("#,0.######");
                    grd_ucost.Rows[i].Cells["S_BOX_PRICE"].Value = (decimal.Parse(dt.Rows[i]["S_BOX_PRICE"].ToString())).ToString("#,0.######");
                    grd_ucost.Rows[i].Cells["UNIT_PRICE"].Value = (decimal.Parse(dt.Rows[i]["UNIT_PRICE"].ToString())).ToString("#,0.######");
                    grd_ucost.Rows[i].Cells["UPSTAFF"].Value = dt.Rows[i]["UPSTAFF"].ToString();
                    grd_ucost.Rows[i].Cells["UPTIME"].Value = dt.Rows[i]["UPTIME"].ToString();
                    if (dt.Rows[i]["P_GUBUN"].ToString().Equals("1"))
                    {
                        grd_ucost.Rows[i].Cells["PROD_NM"].Value = dt.Rows[i]["RAW_MAT_NM"].ToString();
                        grd_ucost.Rows[i].Cells["PROD_CD"].Value = dt.Rows[i]["RAW_MAT_CD"].ToString();
                    }
                    else
                    {
                        grd_ucost.Rows[i].Cells["PROD_NM"].Value = dt.Rows[i]["ITEM_NM"].ToString();
                        grd_ucost.Rows[i].Cells["PROD_CD"].Value = dt.Rows[i]["ITEM_CD"].ToString();
                    }
                }
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (cbo_cust.SelectedValue != null)
            {
                //삽입 수정 확인

                // 체크박스 선택 유무에따라 y 또는 f로 변환
                ckQuery = wDm.inUpPriceInfo(
                    grd_ucost
                    ,cbo_cust.SelectedValue.ToString());
                if (ckQuery == 0)
                {
                    MessageBox.Show("성공");
             
                }
                else
                {
                    MessageBox.Show("실패");
                }
            }
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("정말 삭제 하시겠습니까?", "삭제경고", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int rowIndex = grd_ucost.CurrentRow.Index;
                cust = grd_ucost.Rows[rowIndex].Cells[0].Value.ToString();
                item = grd_ucost.Rows[rowIndex].Cells[1].Value.ToString();


                ckQuery = wDm.deletePriceInfo(cust, item);
                grdLoad();
            }
            else
            {

            }

     
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
