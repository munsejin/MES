using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MES.CLS;
using MES.Controls;
using System.Diagnostics;

namespace MES.P30_SCH
{
    public partial class frm현대공정관리 : Form
    {
        Popup.frmPrint readyPrt = new Popup.frmPrint();
        //private wnGConstant wConst = new wnGConstant();

        DataTable adoPrt = null;
        wnAdo wAdo = new wnAdo();
        public Popup.frmPrint frmPrt;
        public string str현재고 = "";
        public string strCondition = "";

        private wnGConstant wConst = new wnGConstant();
        private ComInfo comInfo = new ComInfo();
        private DataGridView del_compGrid = new DataGridView();
        private DataGridView del_flowGrid = new DataGridView();
        private DataGridView del_halfGrid = new DataGridView();
        public static bool p_IsAuth = true;    // 열람권한
        public static bool p_Isrgstr = true;    //등록/수정 권한
        wnDm wnDm = new wnDm();
        
        string sqlQuery = "";

        public static bool p_Isdel = true;    // 삭제 권한
        public frm현대공정관리()
        {
            InitializeComponent();
        }

        private void frm현대공정관리_Load(object sender, EventArgs e)
        {
            init_ComboBox();
            addButton(txt_item_nm, 0);
            addButton(txt_cust_nm, 1);
            dtp_today.Value = DateTime.Now;
            StringBuilder sb = new StringBuilder();
    
            
            bindData(sb.ToString());
            공정LIST();
        }

        private void init_ComboBox()
        {

            cmb_fac.ValueMember = "코드";
            cmb_fac.DisplayMember = "명칭";
            sqlQuery = comInfo.queryLine();
            wConst.ComboBox_Read_Blank(cmb_fac, sqlQuery);

           

         
           

            cmb_staff.ValueMember = "코드";
            cmb_staff.DisplayMember = "명칭";
            sqlQuery = comInfo.queryStaff();
            wConst.ComboBox_Read_Blank(cmb_staff, sqlQuery);   

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
                    Txtbtn[type].Click += new EventHandler(btnitemsearch);

                    break;
                case 1:
                    Txtbtn[type].Click += new EventHandler(btnCustSrch_Click);

                    break;


                default:
                    break;
            }
            Txtbtn[type].Show();
        }
        string old_cust_nm = "";
        private void btnCustSrch_Click(object sender, EventArgs e)
        {
            Popup.pop거래처검색 frm = new Popup.pop거래처검색("매출처");

            frm.sCustGbn = "1"; //매출처
            frm.sCustNm = txt_cust_nm.Text.ToString();
            frm.ShowDialog();

            if (frm.sCode != "")
            {
                txt_cust_nm.Tag = frm.sCode.Trim();
                txt_cust_nm.Text = frm.sName.Trim();
                old_cust_nm = frm.sCode.Trim();
             
            }
            else
            {
                txt_cust_nm.Tag = old_cust_nm;
            }

            frm.Dispose();
            frm = null;
           
        }

       
        private void resetSetting()
        {
            txt_item_nm.Text = "";
            txt_cust_nm.Text = "";
            txt생산능력.Text = "";
           
            bindData("");

            if ( cmb_fac.SelectedIndex>0)
            {
                cmb_fac.SelectedIndex = 0;
                
            }
            if (cmb_flow.SelectedIndex > 0)
            {
                cmb_flow.SelectedIndex = 0;

            }
            if (cmb_staff.SelectedIndex > 0)
            {
                cmb_staff.SelectedIndex = 0;

            }
         
            lblLotNO.Text = "LOTNO";
         

        }
        string old_item_nm = "";

        private void btnitemsearch(object sender, EventArgs e)
        {
            Popup.pop_sf_제품검색 frm = new Popup.pop_sf_제품검색();
            wnDm wDm = new wnDm();
            DataTable dt = new DataTable();
            dt = wDm.fn_Item_List("where ITEM_NM like '%" + txt_item_nm.Text.ToString() + "%' ");

            //frm.sUsedYN = sUsedYN;
            frm.dt = dt;
            frm.txtSrch.Text = txt_item_nm.Text.ToString();
            frm.ShowDialog();

            if (frm.sCode != "")
            {
                txt_item_nm.Tag = frm.sCode.Trim();
                txt_item_nm.Text = frm.sName.Trim();
                old_item_nm = frm.sCode.Trim();

                str현재고 = frm.sBAL_STOCK;
                Debug.WriteLine(str현재고);

             
            }
            else
            {
                txt_item_nm.Tag = "";
                txt_item_nm.Text = old_item_nm;
            }

            cmb_flow.ValueMember = "코드";
            cmb_flow.DisplayMember = "명칭";
            sqlQuery = comInfo.queryItem2Flow(txt_item_nm.Tag.ToString());
            wConst.ComboBox_Read_Blank(cmb_flow, sqlQuery);

        }
        int 생산량 = 0;
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmb_fac.SelectedIndex == 0)
            {
                MessageBox.Show("작업한 설비를 입력하세요");
                return;
            }

           

           

            if (cmb_flow.SelectedIndex == 0)
            {
                MessageBox.Show("진행한 공정을 입력하세요");
                return;
            }

            if (cmb_staff.SelectedIndex == 0)
            {
                MessageBox.Show("작업자를 선택하세요");
                return;
            }
            생산량 = int.Parse(txt생산능력.Text.ToString().Replace(",", ""));

            LOT_NO적용(GridRecord);

            공정LIST();
        }
        /// <summary>
        /// 그리드뷰 의 미완료량 와 수량 비교 
        /// 수량이 미완료량보다  적거나 같으면 그리드 첫번째로우   끝남
        /// 수량이 더많으면 다음 그리드 두번째 로우 , 더  많으면 세번째까지 넘어감
        /// 수량이 더많은데 마지막 로우를 넘어갔을땐 새로  LOTNO를 만들어 주어야함 
        /// </summary>
        /// <param name="dgv"></param>
        private void LOT_NO적용(DataGridView dgv)
        {
            btnSrch.PerformClick();// 강제로 검색해서 밑에 그리드뷰 변경 


            if (lbl공정.Text == "마지막공정")
            {
                bindData("");
                int 공정끝났다확인 = 0;
                for (int i = 0; i < GridRecord.Rows.Count; i++)
                {
                    if (GridRecord.Rows[i].Cells["LOT_NO"].Value.ToString() == lblLotNO.Text.ToString())
                    {

                        공정끝났다확인++;
                    }
                }
                
                    if (공정끝났다확인 > 1)
                    {
                        MessageBox.Show("공정이 다 끝나지 않아서 FINAL 공정을 시작 할 수 없습니다.");
                        return;
                    }
                
                btnSrch.PerformClick();// 강제로 검색해서 밑에 그리드뷰 변경 
            }
            
           

                if (GridRecord.Rows.Count > 0)
                {


                    int 미완료투입량 = int.Parse(GridRecord.Rows[0].Cells["미완료량"].Value.ToString().Replace(",", ""));

                    if (미완료투입량 >= 생산량)
                    {

                        dateSave(GridRecord.Rows[0].Cells["LOT_NO"].Value.ToString(), 생산량.ToString());
                        if (lbl공정.Text == "마지막공정")
                        {
                            item_input(GridRecord.Rows[0].Cells["LOT_NO"].Value.ToString(), 생산량.ToString());
                        }
                        btnSrch.PerformClick();// 강제로 검색해서 밑에 그리드뷰 변경 

                    }
                    else if (미완료투입량 < 생산량)
                    {
                        생산량 = 생산량 - 미완료투입량;

                        dateSave(GridRecord.Rows[0].Cells["LOT_NO"].Value.ToString(), 미완료투입량.ToString());
                        if (lbl공정.Text == "마지막공정")
                        {
                            item_input(GridRecord.Rows[0].Cells["LOT_NO"].Value.ToString(), 미완료투입량.ToString());
                        }
                        LOT_NO적용(GridRecord);

                    }

                }
                else
                {
                    MessageBox.Show(생산량 + "수량 만큼의 작업지시가 없습니다. 작업지시 없이 생산 하겠습니다..");



                    string LOTNO부여 = "";

                    string lot_no = dtp_today.Value.ToString("yyMMdd").Replace("-", "");
                    lot_no = lot_no.Replace(",", "");




                    if (lbl공정.Text != "마지막공정")
                    {


                        int rsNum = wnDm.현대Lotno부여(

                        dtp_today.Value.ToString().Substring(0, 10)
                        , lot_no
                        , txt_item_nm.Tag.ToString()
                        , txt_cust_nm.Tag.ToString()
                        , 생산량.ToString()
                            , cmb_fac.SelectedValue.ToString()
                            , cmb_staff.SelectedValue.ToString()
                        );



                        if (rsNum == 0)
                        {
                            LOT_NO적용(GridRecord);

                        }
                        else
                        {
                            MessageBox.Show("저장에 실패하였습니다");

                        }
                    }
                    else
                    {

                        MessageBox.Show("마지막 공정에는 작업지시를 내릴 수 없습니다.");
                    }

                }


            
        }
       

        private void btnNew_Click(object sender, EventArgs e)
        {
            resetSetting();
        }

        private void tab1_Click(object sender, EventArgs e)
        {

        }


        private void bindData(string condition)
        {
            this.GridRecord.DataSource = null;
            this.GridRecord.RowCount = 0;
            GridRecord.Rows.Clear();
            DataTable dt = null;
            dt = wnDm.현대fn_Work_List(condition);

            // For Page view.



            if (dt.Rows.Count > 0)
            {
                GridRecord.RowCount = dt.Rows.Count;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    GridRecord.Rows[i].Cells["CUST_NM"].Value = dt.Rows[i]["CUST_NM"].ToString();
                    GridRecord.Rows[i].Cells["LOT_NO"].Value = dt.Rows[i]["LOT_NO"].ToString();
                    GridRecord.Rows[i].Cells["ITEM_NM"].Value = dt.Rows[i]["ITEM_NM"].ToString();
                    GridRecord.Rows[i].Cells["INST_AMT"].Value = decimal.Parse(dt.Rows[i]["INST_AMT"].ToString()).ToString("#,0");
                    GridRecord.Rows[i].Cells["ITEM_CD"].Value = dt.Rows[i]["ITEM_CD"].ToString();
                    GridRecord.Rows[i].Cells["SPEC"].Value = dt.Rows[i]["SPEC"].ToString();
                    GridRecord.Rows[i].Cells["미완료량"].Value = decimal.Parse(dt.Rows[i]["남은수량"].ToString()).ToString("#,0");
                    //GridRecord.Rows[i].Cells["W_INST_DATE"].Value = dt.Rows[i]["W_INST_DATE"].ToString();
                    //GridRecord.Rows[i].Cells["W_INST_CD"].Value = dt.Rows[i]["W_INST_CD"].ToString();
                    //GridRecord.Rows[i].Cells["CHARGE_AMT"].Value = dt.Rows[i]["CHARGE_AMT"].ToString();
                    //GridRecord.Rows[i].Cells["O_PACK"].Value = dt.Rows[i]["PACK_AMT"].ToString();
                    //GridRecord.Rows[i].Cells["COMPLETE_YN"].Value = dt.Rows[i]["COMPLETE_YN"].ToString();
                    GridRecord.Rows[i].Cells["거래처코드"].Value = dt.Rows[i]["CUST_CD"].ToString();
                    //GridRecord.Rows[i].Cells["현재고"].Value = dt.Rows[i]["BAL_STOCK"].ToString();
                    GridRecord.Rows[i].Cells["공정명"].Value = dt.Rows[i]["FLOW_NM"].ToString();
                    GridRecord.Rows[i].Cells["공정코드"].Value = dt.Rows[i]["FLOW_CD"].ToString();
                    GridRecord.Rows[i].Cells["작업자코드"].Value = dt.Rows[i]["WORKER_CD"].ToString();
                    GridRecord.Rows[i].Cells["설비코드"].Value = dt.Rows[i]["LINE_CD"].ToString();
            
                }
            }
            else
            {
                GridRecord.Rows.Clear();
            }
        }

        private void GridRecord_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
         
            
           lblLotNO.Text=   GridRecord.Rows[e.RowIndex].Cells["LOT_NO"].Value.ToString();
           txt_item_nm.Text= GridRecord.Rows[e.RowIndex].Cells["ITEM_NM"].Value.ToString();
           txt_item_nm.Tag= GridRecord.Rows[e.RowIndex].Cells["ITEM_CD"].Value.ToString();

           txt_cust_nm.Text = GridRecord.Rows[e.RowIndex].Cells["CUST_NM"].Value.ToString();
           txt_cust_nm.Tag = GridRecord.Rows[e.RowIndex].Cells["거래처코드"].Value.ToString();

           cmb_flow.ValueMember = "코드";
           cmb_flow.DisplayMember = "명칭";
           sqlQuery = comInfo.queryItem2Flow(txt_item_nm.Tag.ToString());
           wConst.ComboBox_Read_Blank(cmb_flow, sqlQuery);

           cmb_flow.SelectedValue = GridRecord.Rows[e.RowIndex].Cells["공정코드"].Value.ToString();
           cmb_fac.SelectedValue = GridRecord.Rows[e.RowIndex].Cells["설비코드"].Value.ToString();
           cmb_staff.SelectedValue = GridRecord.Rows[e.RowIndex].Cells["작업자코드"].Value.ToString();
           txt생산능력.Text = GridRecord.Rows[e.RowIndex].Cells["미완료량"].Value.ToString();

           btnSrch.PerformClick();
        }

        private void dateSave(String lot_no,String complete_amt)
        {
            int rsNum = wnDm.insert현대(
                lot_no
                ,txt_item_nm.Tag.ToString()
                , txt_cust_nm.Tag.ToString()
                , cmb_flow.SelectedValue.ToString()
, cmb_fac.SelectedValue.ToString()
, dtp_today.Value.ToString().Substring(0,10)
, cmb_staff.SelectedValue.ToString()
, complete_amt
, (cmb_flow.SelectedIndex ).ToString()

                    );


            if (rsNum == 0)
            {
                wnProcCon wDmProc = new wnProcCon();
                int rsNum2 = wDmProc.prod_item_stock_upd(txt_item_nm.Tag.ToString());

           


                MessageBox.Show("성공적으로 등록하였습니다.");

                if (rsNum2 == -9)
                {
                    MessageBox.Show("제품재고조정 실패");
                }

                MessageBox.Show("성공적으로 등록하였습니다.");
                공정LIST();

            }
            else if (rsNum == 1)
                MessageBox.Show("저장에 실패하였습니다");
            else if (rsNum == 2)
                MessageBox.Show("SQL COMMAND 에러");
            else
                MessageBox.Show("Exception 에러1");
        }

        private void btnSrch_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();



            if (txt_item_nm.Tag.ToString() != "")
            {
                sb.AppendLine("and A.ITEM_CD='" + txt_item_nm.Tag.ToString() + "' ");
                

            }
            else
            {
                MessageBox.Show("제품을 입력해주세요");
                return;
            }
            if (txt_cust_nm.Tag.ToString() != "")
            {
                sb.AppendLine("and A.CUST_CD='" + txt_cust_nm.Tag.ToString() + "' ");

            }
            else
            {
                MessageBox.Show("매출처을 입력해주세요");

                return;
            }

            if (cmb_flow.SelectedValue.ToString() != "")
            {
                sb.AppendLine("and B.FLOW_CD='" + cmb_flow.SelectedValue.ToString() + "' ");

            }
            else
            {
                MessageBox.Show("공정을 입력해주세요");

                return;
            }
            if (cmb_flow.SelectedValue.ToString() != "" & txt_cust_nm.Tag.ToString() != "" & txt_item_nm.Tag.ToString() != "")
            {
                bindData(sb.ToString());
                
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmb_flow_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_flow.SelectedIndex == cmb_flow.Items.Count - 1)
            {

                lbl공정.Text = "마지막공정";
            }
            else
            {
                Debug.WriteLine("not");
                lbl공정.Text = "공정";

            }

            if (lbl공정.Text == "마지막공정")
            {
                txt생산능력.ReadOnly = true;
            }
            else
            {

                txt생산능력.ReadOnly = false;

            }
        }


        private void item_input(String lot_no, String complete_amt)
        {

            int rsNum = wnDm.input_item현대(
                lot_no
                , txt_item_nm.Tag.ToString()
                , txt_cust_nm.Tag.ToString()
                , cmb_flow.SelectedValue.ToString()
, cmb_fac.SelectedValue.ToString()
, dtp_today.Value.ToString().Substring(0, 10)
, cmb_staff.SelectedValue.ToString()
, complete_amt
, (cmb_flow.SelectedIndex).ToString()
, str현재고.ToString()

                    );


            if (rsNum == 0)
            {

                wnProcCon wDmProc = new wnProcCon();
                int rsNum2 = wDmProc.prod_item_stock_upd(txt_item_nm.Tag.ToString());
                MessageBox.Show("재고 저장 성공.");
            }
            else if (rsNum == 1)
                MessageBox.Show("재고 저장에 실패");
            else if (rsNum == 2)
                MessageBox.Show("SQL COMMAND 에러");
            else
                MessageBox.Show("Exception 에러1");
        }



        private void 공정LIST()
        {

            //         sb.AppendLine("         A.LOT_NO ");
            
            //sb.AppendLine("           ,E.INST_AMT-A.INPUT_AMT as 미투입량 ");
            try
            {
                dgv공정.Rows.Clear();
                DataTable dt = wnDm.fn_work_List현대("where a.F_SUB_DATE>='" + dtp시작.Value.ToString().Substring(0, 10) + "' and a.F_SUB_DATE<='" + dtp끝.Value.ToString().Substring(0, 10) + "'");

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgv공정.Rows.Add();
                        dgv공정.Rows[i].Cells["W_공정"].Value = dt.Rows[i]["FLOW_NM"].ToString();
                        dgv공정.Rows[i].Cells["W_LOT_NO"].Value = dt.Rows[i]["LOT_NO"].ToString();
                        dgv공정.Rows[i].Cells["W_공정코드"].Value = dt.Rows[i]["FLOW_CD"].ToString();
                        dgv공정.Rows[i].Cells["W_제품"].Value = dt.Rows[i]["ITEM_NM"].ToString();
                        dgv공정.Rows[i].Cells["W_제품코드"].Value = dt.Rows[i]["ITEM_CD"].ToString();
                        dgv공정.Rows[i].Cells["W_설비"].Value = dt.Rows[i]["LINE_NM"].ToString();
                        dgv공정.Rows[i].Cells["W_설비코드"].Value = dt.Rows[i]["LINE_CD"].ToString();
                        dgv공정.Rows[i].Cells["W_거래처"].Value = dt.Rows[i]["CUST_NM"].ToString();
                        dgv공정.Rows[i].Cells["W_거래처코드"].Value = dt.Rows[i]["CUST_CD"].ToString();
                        dgv공정.Rows[i].Cells["W_작업자코드"].Value = dt.Rows[i]["WORKER_CD"].ToString();
                        dgv공정.Rows[i].Cells["W_작업자"].Value = dt.Rows[i]["WORKER_NM"].ToString();
                        dgv공정.Rows[i].Cells["W_완료수량"].Value = decimal.Parse(dt.Rows[i]["F_SUB_AMT"].ToString()).ToString("#,0");
                    }
                }
            }
            catch
            {
            }
        }

        private void btn완료검색_Click(object sender, EventArgs e)
        {
            공정LIST();
        }

        private void dgv공정_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            lblLotNO.Text = dgv공정.Rows[e.RowIndex].Cells["W_LOT_NO"].Value.ToString();
           txt_item_nm.Text = dgv공정.Rows[e.RowIndex].Cells["W_제품"].Value.ToString();
           txt_item_nm.Tag = dgv공정.Rows[e.RowIndex].Cells["W_제품코드"].Value.ToString();

           txt_cust_nm.Text = dgv공정.Rows[e.RowIndex].Cells["W_거래처"].Value.ToString();
           txt_cust_nm.Tag = dgv공정.Rows[e.RowIndex].Cells["W_거래처코드"].Value.ToString();

            cmb_flow.ValueMember = "코드";
            cmb_flow.DisplayMember = "명칭";
            sqlQuery = comInfo.queryItem2Flow(txt_item_nm.Tag.ToString());
            wConst.ComboBox_Read_Blank(cmb_flow, sqlQuery);

            cmb_flow.SelectedValue = dgv공정.Rows[e.RowIndex].Cells["W_공정코드"].Value.ToString();
            cmb_fac.SelectedValue = dgv공정.Rows[e.RowIndex].Cells["W_설비코드"].Value.ToString();
            cmb_staff.SelectedValue = dgv공정.Rows[e.RowIndex].Cells["W_작업자코드"].Value.ToString();
            txt생산능력.Text = dgv공정.Rows[e.RowIndex].Cells["W_완료수량"].Value.ToString();

            
        }
    }
}
