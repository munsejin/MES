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

namespace MES.P50_QUA
{
    public partial class frm제품불량내역 : Form
    {
        string condition = "";
        wnGConstant wConst = new wnGConstant();
        public frm제품불량내역()
        {
            InitializeComponent();
        }
        public static bool p_IsAuth = true;    // 열람권한
        public static bool p_Isrgstr = true;    //등록/수정 권한
        wnDm wnDm = new wnDm();
        
        public static bool p_Isdel = true;    // 삭제 권한

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
        private void frm제품불량내역_Load(object sender, EventArgs e)
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
            addButton(txt_item_nm, 0);
            
            start_date.Text = DateTime.Today.AddMonths(-1).ToString("yyyy-MM-dd");
            txt_item_nm.Text = "";

            condition = "";

            item_list(condition);   
        }    

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSrch_Click(object sender, EventArgs e)
        {
            dgv_item_list.Rows.Clear();

            if (txt_item_nm.Text != null || txt_item_nm.Text != "")
            {
                condition = "AND ITEM_NM LIKE '" + txt_item_nm.Text.ToString() + "%' ";
                item_list(condition);
            }
            else
            {
                condition = "";
                item_list(condition);
            }
        }            

        private void item_list(string condition)
        {
            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = null;
                StringBuilder sb = new StringBuilder();

             
                sb.AppendLine(condition);
                sb.AppendLine(" AND C.F_SUB_DATE >= '" + start_date.Text.ToString() + "'  AND C.F_SUB_DATE <= '" + end_date.Text.ToString() + "'");

                //WNDM 12931번째 줄
             
                dt = wDm.Item_Grid_List(sb.ToString());

                
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgv_item_list.Rows.Add();
                        dgv_item_list.Rows[i].Cells["LOT_NO"].Value = dt.Rows[i]["LOT_NO"].ToString();
                        dgv_item_list.Rows[i].Cells["LOT_SUB"].Value = dt.Rows[i]["LOT_SUB"].ToString();
                        dgv_item_list.Rows[i].Cells["SEQ"].Value = dt.Rows[i]["SEQ"].ToString();
                        dgv_item_list.Rows[i].Cells["제품명"].Value = dt.Rows[i]["ITEM_NM"].ToString();
                        dgv_item_list.Rows[i].Cells["투입수량"].Value = dt.Rows[i]["INPUT_AMT"].ToString();
                        dgv_item_list.Rows[i].Cells["불량"].Value = double.Parse(dt.Rows[i]["POOR_AMT"].ToString()).ToString("#,0");
                        dgv_item_list.Rows[i].Cells["불량율"].Value = ((double)100 * (double.Parse(dt.Rows[i]["POOR_AMT"].ToString()) / double.Parse(dt.Rows[i]["INPUT_AMT"].ToString()))).ToString();
                        dgv_item_list.Rows[i].Cells["LOSS율"].Value = ((double)100 * (double.Parse(dt.Rows[i]["LOSS"].ToString()) / double.Parse(dt.Rows[i]["INPUT_AMT"].ToString()))).ToString();

                        dgv_item_list.Rows[i].Cells["LOSS"].Value = dt.Rows[i]["LOSS"].ToString();
                        if ( dt.Rows[i]["LOT_SUB"].ToString()=="99")
                        {
                            dgv_item_list.Rows[i].Cells["LOT_SUB"].Value = (string)"합계";
                            dgv_item_list.Rows[i].Cells["LOT_NO"].Value = (string)"제품";
                              dgv_item_list.Rows[i].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                            dgv_item_list.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                        }
                    }
                    wConst.mergeCells(dgv_item_list, 1);
                }
                else
                {
                    dgv_item_list.Rows.Clear();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("시스템 에러: " + e.Message.ToString());
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(e.Message + " - " + e.ToString());
                msg.ShowDialog();
            }
        }

        private void item_list_dateail(string condition)
        {
            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = null;
                StringBuilder sb = new StringBuilder();


                sb.AppendLine(condition);
                sb.AppendLine(" AND C.F_SUB_DATE >= '" + start_date.Text.ToString() + "'  AND C.F_SUB_DATE <= '" + end_date.Text.ToString() + "'");

                //WNDM 12931번째 줄

                dt = wDm.Item_Grid_List_Detail(sb.ToString());


                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgv_item_list.Rows.Add();
                        dgv_item_list.Rows[i].Cells["LOT_NO"].Value = dt.Rows[i]["LOT_NO"].ToString();
                        dgv_item_list.Rows[i].Cells["LOT_SUB"].Value = dt.Rows[i]["LOT_SUB"].ToString();
                        dgv_item_list.Rows[i].Cells["SEQ"].Value = dt.Rows[i]["SEQ"].ToString();
                        dgv_item_list.Rows[i].Cells["제품명"].Value = dt.Rows[i]["ITEM_NM"].ToString();
                        dgv_item_list.Rows[i].Cells["투입수량"].Value = dt.Rows[i]["INPUT_AMT"].ToString();
                        dgv_item_list.Rows[i].Cells["불량"].Value = double.Parse(dt.Rows[i]["POOR_AMT"].ToString()).ToString("#,0");
                        dgv_item_list.Rows[i].Cells["불량율"].Value = ((double)100 * double.Parse(dt.Rows[i]["POOR_AMT"].ToString()) / double.Parse(dt.Rows[i]["INPUT_AMT"].ToString())).ToString();
                        dgv_item_list.Rows[i].Cells["LOSS율"].Value = ((double)100 * double.Parse(dt.Rows[i]["LOSS"].ToString()) / double.Parse(dt.Rows[i]["INPUT_AMT"].ToString())).ToString();

                        dgv_item_list.Rows[i].Cells["LOSS"].Value = dt.Rows[i]["LOSS"].ToString();
                        if (dt.Rows[i]["LOT_SUB"].ToString() == "99")
                        {
                            dgv_item_list.Rows[i].Cells["LOT_SUB"].Value = (string)"합계";
                            dgv_item_list.Rows[i].Cells["LOT_NO"].Value = (string)"제품";
                            dgv_item_list.Rows[i].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                            dgv_item_list.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                        }
                    }
                    wConst.mergeCells(dgv_item_list, 1);
                }
                else
                {
                    dgv_item_list.Rows.Clear();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("시스템 에러: " + e.Message.ToString());
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(e.Message + " - " + e.ToString());
                msg.ShowDialog();
            }
        }

        private void clear_Click(object sender, EventArgs e)
        {
            
        }

        String old_item_nm = null;
        private void serch()
        {
            
                    Popup.pop_sf_제품검색 frm = new Popup.pop_sf_제품검색();
                    frm.txtSrch.Text = txt_item_nm.Text.ToString();
                    frm.ShowDialog();
                    if (frm.sCode != "")
                    {
                        txtcode.Text = frm.sCode.Trim();
                        txt_item_nm.Text = frm.sName.Trim();
                        old_item_nm = frm.sCode.Trim();

                    }
                    else
                    {
                        txtcode.Text = old_item_nm;
                    }
                  
              

        }

        private void txttype_DropDown(object sender, EventArgs e)
        {
            serch();
        }

        private void txt_item_nm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                serch();
            }

            else
            {
                return;
            }
        }

        private void txt_item_nm_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
