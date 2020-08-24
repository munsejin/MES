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
using MES.Controls;

namespace MES.P20_ORD
{
    public partial class frm구매처원장 : Form
    {
        private wnGConstant wConst = new wnGConstant();

        public frm구매처원장()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            cust_Grid.Rows.Clear();

            string condition = "";

            //if (frm.sCode != "")
            //{
            //    txtcustSrch.Text = frm.sName.Trim();
            if (txtcustSrch.Text != null && txtcustSrch.Text != "")
            {
                condition = " AND G.CUST_NM LIKE '%" + txtcustSrch.Text + "%' ";
            }

            //}
            //else
            //{
            //    //txt_cust_cd.Text = old_cust_nm;
            //}

            //frm.Dispose();
            //frm = null;

            cust_list(condition);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
  public static bool p_IsAuth = true;    // 열람권한
        public static bool p_Isrgstr = true;    //등록/수정 권한
        wnDm wnDm = new wnDm();

        public static bool p_Isdel = true;    // 삭제 권한
        private void frm구매처원장_Load(object sender, EventArgs e)
        {
              
            //DateTime today = DateTime.Today.AddMonths(-1);
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
            addButton(txtcustSrch, 0);
            string condition = "";
            cust_list(condition);



            if (Common.p_saupNo == "6968700592")
            {
                start_date.Value = DateTime.Now.Date.AddDays(1 - end_date.Value.Day); //그 달의 첫날 
                
            }
        }

        Button[] Txtbtn = new Button[1];
        public void addButton(conTextBox TextBox, int type)
        {
            Txtbtn[type] = new Button();
            TextBox.Controls.Add(Txtbtn[type]);
            Txtbtn[type].FlatStyle = FlatStyle.Flat;
            Txtbtn[type].FlatAppearance.BorderSize = 0;
            Txtbtn[type].FlatAppearance.MouseDownBackColor = Color.Transparent;
            Txtbtn[type].SetBounds(TextBox.Size.Width - 19, 1, 18, TextBox.Size.Height - 2);
            Txtbtn[type].Text = "▼";
            Txtbtn[type].TabStop = false;
            Txtbtn[type].Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 4, FontStyle.Bold);

            switch (type)
            {
                case 0:
                    Txtbtn[type].Click += new EventHandler(txttype_DropDown);

                    break;

                default:
                    break;
            }
            Txtbtn[type].Show();
        }

     

        private void btnSrch_Click(object sender, EventArgs e)
        {
            //Popup.pop거래처검색 frm = new Popup.pop거래처검색();

            //frm.sCustGbn = "1";
            //frm.sCustNm = txtcustSrch.Text.ToString();
            //frm.ShowDialog();

            string condition = "";

            //if (frm.sCode != "")
            //{
            //    txtcustSrch.Text = frm.sName.Trim();
            if (txtcustSrch.Text != null && txtcustSrch.Text != "")
            {
                condition = " AND G.CUST_NM LIKE '%" + txtcustSrch.Text + "%' ";
            }
               
            //}
            //else
            //{
            //    //txt_cust_cd.Text = old_cust_nm;
            //}

            //frm.Dispose();
            //frm = null;
  
            cust_list(condition);
        }
                


        //private void init_ComboBox()
        //{
        //    ComInfo comInfo = new ComInfo();
        //    string sqlQuery = "";

        //    cmb.ValueMember = "코드";
        //    cmb.DisplayMember = "명칭";
        //    sqlQuery = comInfo.queryCustUsed("1");
        //    wConst.ComboBox_Read_Blank(cmb, sqlQuery);
        //}

        private void cust_list(string condition)
        {
            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = null;       
                StringBuilder sb = new StringBuilder();

                cust_Grid.Rows.Clear();

                string condition2 = "  c.INPUT_DATE >= '" + start_date.Text.ToString() + "' and  c.INPUT_DATE <= '" + end_date.Text.ToString() + "' ";
                
                //sb.AppendLine(" and C.CUST_CD = cmb.SelectedValue");

                dt = wDm.cust_Grid_List(condition, condition2);
                //if (!txtSrch.Text.ToString().Equals(""))
                //{
                //    sb.AppendLine("and CHK_NM like '%" + txtSrch.Text.ToString() + "%' ");
                //}              

                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        cust_Grid.Rows.Add();
                        cust_Grid.Rows[i].Cells["CUST_NM"].Value = dt.Rows[i]["CUST_NM"].ToString();
                        cust_Grid.Rows[i].Cells["ORDER_DATE"].Value = dt.Rows[i]["ORDER_DATE"].ToString();
                       // cust_Grid.Rows[i].Cells["ORDER_CD"].Value = dt.Rows[i]["ORDER_CD"].ToString();
                        cust_Grid.Rows[i].Cells["INPUT_DATE"].Value = dt.Rows[i]["INPUT_DATE"].ToString();
                        cust_Grid.Rows[i].Cells["RAW_MAT_NM"].Value = dt.Rows[i]["RAW_MAT_NM"].ToString();
                        cust_Grid.Rows[i].Cells["SPEC"].Value = dt.Rows[i]["SPEC"].ToString();
                        cust_Grid.Rows[i].Cells["UNIT_CD"].Value = (decimal.Parse(dt.Rows[i]["TOTAL_AMT"].ToString())).ToString("#,0");
                        cust_Grid.Rows[i].Cells["PRICE"].Value = (decimal.Parse(dt.Rows[i]["PRICE"].ToString())).ToString("#,0");
                        cust_Grid.Rows[i].Cells["TOTAL_AMT"].Value = (decimal.Parse(dt.Rows[i]["TOTAL_MONEY"].ToString())).ToString("#,0");
                        cust_Grid.Rows[i].Cells["COMPLETE_YN"].Value = dt.Rows[i]["COMPLETE_YN"].ToString()??"N";

                        if (dt.Rows[i]["ORDER_DATE"].ToString()=="9999-99-99")
                        {
                            cust_Grid.Rows[i].Cells["ORDER_DATE"].Value = (String)"합계";
                            cust_Grid.Rows[i].Cells["INPUT_DATE"].Value = (String)"합계";
                            this.cust_Grid.Rows[i].DefaultCellStyle.ForeColor = Color.Red;

                        }
                    }
                    wConst.mergeCells(cust_Grid, 1);
                }
                else
                {
                    cust_Grid.Rows.Clear();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("시스템 에러: " + e.Message.ToString());
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(e.Message + " - " + e.ToString());
                msg.ShowDialog();
            }
           
        }

               

        private void save_logic(object sender, EventArgs e)
        {
            if (custGrid.Rows.Count <= 0)
            {
                MessageBox.Show("거래처를 선택하시기 바랍니다.");
                return;
            }

            if (custGrid.Rows.Count > 0)
            {
                int cnt = 0;
                int grid_cnt = custGrid.Rows.Count;
                for (int i = 0; i < grid_cnt; i++)
                {
                    string txt_item_cd = (string)custGrid.Rows[i - cnt].Cells["RAW_MAT_CD"].Value;

                    if (txt_item_cd == "" || txt_item_cd == null)  //마지막 행에 원자재코드가 없을 경우 제거
                    {
                        custGrid.Rows.RemoveAt(i - cnt);
                        cnt++;
                    }
                }
            }

            //string pur_yn = comInfo.resultYn(chk_pur_yn);
            //if (lbl_order_gbn.Text != "1")
            //{
            //    wnDm wDm = new wnDm();
            //    int rsNum = wDm.insertOrder(
            //            txt_order_date.Text.ToString(),
            //            txt_cust_cd.Text.ToString(),
            //            in_req_date.Text.ToString(),
            //            pur_yn,
            //            txt_comment.Text.ToString(),
            //            rmOrderGrid);

            //    if (rsNum == 0)
            //    {
            //        resetSetting();

            //        StringBuilder sb = new StringBuilder();
            //        sb.AppendLine("and A.ORDER_DATE >= '" + start_date.Text.ToString() + "' and  A.ORDER_DATE <= '" + end_date.Text.ToString() + "'");

            //        string str = queryStr(sb.ToString());
            //        order_list(orderGrid, str);

            //        MessageBox.Show("성공적으로 등록하였습니다.");
            //    }
            //    else if (rsNum == 1)
            //        MessageBox.Show("저장에 실패하였습니다");
            //    else
            //        MessageBox.Show("Exception 에러");
            //}
            //else
            //{
            //    wnDm wDm = new wnDm();
            //    int rsNum = wDm.updateOrder(
            //            txt_order_date.Text.ToString(),
            //            txt_order_cd.Text.ToString(),
            //            txt_cust_cd.Text.ToString(),
            //            in_req_date.Text.ToString(),
            //            txt_comment.Text.ToString(),
            //            pur_yn,
            //            rmOrderGrid,
            //            del_orderGrid);

            //    if (rsNum == 0)
            //    {
            //        del_orderGrid.Rows.Clear();
            //        StringBuilder sb = new StringBuilder();
            //        sb.AppendLine("and A.ORDER_DATE >= '" + start_date.Text.ToString() + "' and  A.ORDER_DATE <= '" + end_date.Text.ToString() + "'");

            //        string str = queryStr(sb.ToString());
            //        order_list(orderGrid, str);

            //        orderDetail2();
            //        MessageBox.Show("성공적으로 수정하였습니다.");
            //    }
            //    else if (rsNum == 1)
            //        MessageBox.Show("저장에 실패하였습니다");
            //    else
            //        MessageBox.Show("Exception 에러");
            //}
        }
        private void txttype_DropDown(object sender, EventArgs e)
        {
            Popup.pop거래처검색 frm = new Popup.pop거래처검색("구매처");
            frm.sCustGbn = "2";
            frm.sCustNm = txtcustSrch.Text.ToString();
            frm.ShowDialog();
            custCD = frm.sCode.Trim();
            txtcustSrch.Text = frm.sName.Trim();
        }
        String custCD = null;
        private void txtcustSrch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Popup.pop거래처검색 frm = new Popup.pop거래처검색("구매처");
                frm.sCustGbn = "2";
                frm.sCustNm = txtcustSrch.Text.ToString();
                frm.ShowDialog();
                custCD = frm.sCode.Trim();
                txtcustSrch.Text = frm.sName.Trim();
            }

            else
            {
                return;
            } 
        }

        


           
    }
}
