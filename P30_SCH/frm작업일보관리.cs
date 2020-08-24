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
using System.Diagnostics;

namespace MES.P30_SCH
{
    public partial class frm작업일보관리 : Form
    {
        wnGConstant wConst = new wnGConstant();

        public frm작업일보관리()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            workGrid.Rows.Clear();
        }
        String old_item_nm = null;
        private void btnitemSrch_Click(object sender, EventArgs e)
        {
            Popup.pop_sf_제품검색 frm = new Popup.pop_sf_제품검색();
            wnDm wDm = new wnDm();
            DataTable dt = new DataTable();
            try
            {
                dt = wDm.fn_Item_List("where ITEM_NM like '%" + txtitemSrch.Text.ToString() + "%' ");
                frm.dt = dt;

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());


            }
           frm.txtSrch.Text = txtITEM.Text.ToString();
            frm.ShowDialog();

            if (frm.sCode != "")
            {
                txtitemSrch.Text = frm.sCode.Trim();
                
                txtITEM.Text = frm.sName.Trim();
                old_item_nm = frm.sName.Trim();           
            }
            else
            {
                txt_item_nm.Text = old_item_nm;
            }          
        }

        private void btncustSrch_Click(object sender, EventArgs e)
        {
            Popup.pop거래처검색 frm = new Popup.pop거래처검색();

            frm.sCustGbn = "1";
            frm.sCustNm = txtcustSrch.Text.ToString();
            frm.ShowDialog();

            if (frm.sCode != "")
            {
                txtcustSrch.Text = frm.sName.Trim();                
            }
            else
            {
                //txt_cust_cd.Text = old_cust_nm;
            }

            frm.Dispose();
            frm = null;

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSrch_Click(object sender, EventArgs e)
        {
            work_logic();
        }

        private void init_ComboBox()
        {
            ComInfo comInfo = new ComInfo();
            string sqlQuery = "";

            cmb_flow_pass.ValueMember = "코드";
            cmb_flow_pass.DisplayMember = "명칭";
            sqlQuery = comInfo.queryFlow();
            wConst.ComboBox_Read_Blank(cmb_flow_pass, sqlQuery);
            cmb_flow_pass.SelectedIndex = 0;
        }

        private void work_logic()
        {
            workGrid.Rows.Clear();

            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = null;
                StringBuilder sb = new StringBuilder();                

                dTP1.Text = dTP1.Value.ToString("yyyy-MM-dd");
                sb.AppendLine("WHERE A.F_SUB_DATE >= '" + dTP1.Value.ToString() + "' ");
                sb.AppendLine("AND A.F_SUB_DATE <= '" + dTP2.Value.ToString() + "' ");
                    
                txtitemSrch.Text = txtitemSrch.Text.ToString() ?? "";
                txtcustSrch.Text = txtcustSrch.Text.ToString() ?? "";
                if (txtitemSrch.Text != "")
                {
                    sb.AppendLine(" AND C.ITEM_NM LIKE '%" + txtITEM.Text.ToString() + "%' ");                    
                }                
                //if (txtcustSrch .Text != "")
                //{
                //    sb.AppendLine(" AND D.CUST_NM LIKE '%" + txtcustSrch.Text.ToString() + "%' ");                    
                //}
                if (txt_flow_nm.Text!="")
                {
                    sb.AppendLine(" AND A.FLOW_CD LIKE '%" + txt_flow_cd.Text.ToString() + "%' ");                    
                    
                }
               
                dt = wDm.fn_work_List(sb.ToString());
                
                
                if (dt != null && dt.Rows.Count > 0)
                {
                    this.workGrid.RowCount = dt.Rows.Count;

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        workGrid.Rows[i].Cells["LOT_NO"].Value = dt.Rows[i]["LOT_NO"].ToString();
                        workGrid.Rows[i].Cells["W_INST_DATE"].Value = dt.Rows[i]["F_SUB_DATE"].ToString();
                        workGrid.Rows[i].Cells["INST_AMT"].Value = decimal.Parse(dt.Rows[i]["INST_AMT"].ToString()).ToString("#,0");
                        workGrid.Rows[i].Cells["SPEC"].Value = dt.Rows[i]["SPEC"].ToString();
                        workGrid.Rows[i].Cells["LINE_NM"].Value = dt.Rows[i]["LINE_NM"].ToString();
                        workGrid.Rows[i].Cells["ITEM_NM"].Value = dt.Rows[i]["ITEM_NM"].ToString();
                        workGrid.Rows[i].Cells["CUST_NM"].Value = dt.Rows[i]["CUST_NM"].ToString();
                        workGrid.Rows[i].Cells["INPUT_AMT"].Value = decimal.Parse(dt.Rows[i]["F_SUB_AMT"].ToString()).ToString("#,0");
                         workGrid.Rows[i].Cells["COMPLETE_AMT"].Value = decimal.Parse(dt.Rows[i]["COMPLETE_AMT"].ToString()).ToString("#,0");                        
                       // workGrid.Rows[i].Cells["INPUT_YN"].Value = dt.Rows[i]["RAW_OUT_YN"].ToString();
                         workGrid.Rows[i].Cells["W_STEP"].Value = dt.Rows[i]["F_STEP"].ToString();
                         workGrid.Rows[i].Cells["잔여량"].Value = decimal.Parse(dt.Rows[i]["남은것"].ToString()).ToString("#,0");   
                       // workGrid.Rows[i].Cells["CHECK_YN"].Value = dt.Rows[i]["COMPLETE_YN"].ToString();
                    }

                    try
                    {

                        wConst.mergeCells(workGrid, 5);
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("병합");

                        Debug.WriteLine(ex.ToString());
                        Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                        msg.ShowDialog();

                    }
                   
                }
                else
                {
                    workGrid.Rows.Clear();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        private void frm작업일보관리_Load(object sender, EventArgs e)
        {
               lbl_title.Tag = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[0] + "$" + wnDm.fn_TitleName(this.Name.ToString()).Split('$')[1]; lbl_title.Text = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[2];
            
            dTP2.Value = DateTime.Now;
            dTP1.Value = dTP2.Value.AddDays(-7);
            work_logic();

            init_ComboBox();
            cmb_flow_pass.SelectedIndex = 0;
            addButton(txtITEM, 0);
            addButton(txt_flow_nm, 1);

      
        }
        Button[] Txtbtn = new Button[2];
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
                    Txtbtn[type].Click += new EventHandler(btnitemSrch_Click);

                    break;
                case 1:
                    Txtbtn[type].Click += new EventHandler(btnflowSrch_Click);

                    break;

                default:
                    break;
            }
            Txtbtn[type].Show();
        }

        private void btnflowSrch_Click(object sender, EventArgs e)
        {
            Popup.pop공정검색 frm = new Popup.pop공정검색();

           
            frm.ShowDialog();

           
         txt_flow_cd.Text=frm.sRetCode;
         txt_flow_nm.Text = frm.sRetName;
            frm.Dispose();
            frm = null;
        }


        private void txtitemSrch_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtITEM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnitemSrch.PerformClick();
            }

            else
            {
                return;
            } 
        }

        private void txt_flow_nm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Popup.pop공정검색 frm = new Popup.pop공정검색();


                frm.ShowDialog();


                txt_flow_cd.Text = frm.sRetCode;
                txt_flow_nm.Text = frm.sRetName;
                frm.Dispose();
                frm = null;
            }

            else
            {
              
                return;
            } 
        }
    }
}
