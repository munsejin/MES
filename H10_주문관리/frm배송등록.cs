
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
using System.IO;

namespace MES.H10_주문관리
{
    /// <summary>
    /// DB에 추가 
    ///장터지기 연동  에러나면 DB에 추가해주세요 

    //    ALTER TABLE [SM_FACTORY_002].[dbo].[F_ITEM_OUT]
    //ADD J_INPUT_DATE nVARCHAR(20)
    //    ALTER TABLE [SM_FACTORY_002].[dbo].[F_ITEM_OUT]
    //ADD [J_INPUT_CD] int
    //    ALTER TABLE [SM_FACTORY_002].[dbo].[F_ITEM_OUT_DETAIL]
    //ADD J_INPUT_SEQ int
    //    ALTER TABLE [SM_FACTORY_002].[dbo].[F_ITEM_OUT_DETAIL]
    //ADD J_INPUT_CD int
    // ALTER TABLE [SM_FACTORY_002].[dbo].[F_ITEM_OUT_DETAIL]
    //ADD J_INPUT_DATE int     




    ///A거래처에게 출고예정이였던 제품이 B거래처로 수정될수 있게 변경 

    /// </summary>
    public partial class frm배송등록 : Form
    {
        private wnGConstant wConst = new wnGConstant();
        private DataTable del_outGrid = new DataTable();
        wnDm wnDm = new wnDm();
        private bool bHeadCheck = false;
        private string old_cust_nm = "";
        private string str주문일자 = "";
        private string str주문번호 = "";
        private string str항목순번 = "";
        private string str주문시간 = "";
        int a = 0;

        string condition = "";

        public frm배송등록()
        {
            InitializeComponent();

            this.itemOutGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellEndEdit);
            this.itemOutGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grid_KeyDown);
            this.itemOutGrid.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grid_ColumnHeaderMouseClick);

            this.itemOutGrid.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.grid_RowsAdded);
            this.itemOutGrid.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.grid_RowsRemoved);
            this.itemOutGrid.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.grid_EditingControlShowing);

        }
        public static bool p_IsAuth = true;    // 열람권한
        public static bool p_Isrgstr = true;    //등록/수정 권한

        public static bool p_Isdel = true;    // 삭제 권한
        private void frm배송등록_Load(object sender, EventArgs e)
        {
            txt입력방식.Text = Common.p_HW;
            txt시간.Text = DateTime.Now.ToString("HHmmss");
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
            init_ComboBox();
            addButton(txt_cust_nm, 0);
            txt_start_date.Value = DateTime.Now.AddDays(-7);
                       

            del_outGrid.Columns.Add("LOT_NO");
            del_outGrid.Columns.Add("LOT_SUB");
            del_outGrid.Columns.Add("SEQ");
            del_outGrid.Columns.Add("J_SEQ");
            del_outGrid.Columns.Add("OLD_TOTAL_AMT");

       
            item_out_detail("");


        }

        #region item out button logic

        private void btnNew_Click(object sender, EventArgs e)
        {
            resetSetting();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            txt시간.Text = DateTime.Now.ToString("HHmmss");
          
            

                if (MessageBox.Show("선택하신 정보가 저장됩니다", "YesOrNo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                      if (cbo배송사원.SelectedIndex == 0)
            {
                MessageBox.Show("배송사원을 선택하세요");
                return;

            }
                      if (cbo전표상태.SelectedIndex == 0)
                      {
                          MessageBox.Show("전표상태를 배송 또는 배송완료로 선택해주세요");
                          return;
                      }
                    if (p_Isrgstr)
                    {
                        outputLogic();
                        resetSetting();
                        item_out_detail("");
                        output_list(dgv주문등록, "");

                    }
                    else
                    {
                        MessageBox.Show("권한이 없습니다.");
                    }

                }
            
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (p_Isrgstr)
            {
                output_del();
                output_list(dgv주문등록, "");
                item_out_detail("");
            }
            else
            {
                MessageBox.Show("권한이 없습니다.");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCustSrch_Click(object sender, EventArgs e)
        {
            Popup.pop거래처검색 frm = new Popup.pop거래처검색("납품처");

            frm.sCustGbn = "1";
            frm.sCustNm = txt_cust_nm.Text.ToString();
            frm.ShowDialog();

            if (frm.sCode != "")
            {
                txt_cust_cd.Text = frm.sCode.Trim();
                txt_cust_nm.Text = frm.sName.Trim();
                txt_vat_cd.Text = frm.sVatCd.Trim();
                old_cust_nm = frm.sCode.Trim();
                item_out_detail("");
            }
            else
            {
                txt_cust_cd.Text = old_cust_nm;
            }

            frm.Dispose();
            frm = null;
           
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
                    Txtbtn[type].Click += new EventHandler(btnCustSrch_Click);

                    break;
                case 1:
                    Txtbtn[type].Click += new EventHandler(btnItemSrch_Click);

                    break;

                default:
                    break;
            }
            Txtbtn[type].Show();
        }
        String old_item_nm;
        private void btnItemSrch_Click(object sender, EventArgs e)
        {
          
        }

        private void btn_move_Click(object sender, EventArgs e)
        {

           


        }

        private void btnSrch_Click(object sender, EventArgs e)
        {
            
        }

        #endregion item out button logic

        #region item out local logic


        //콤보박스 바인딩 모음
        private void init_ComboBox()
        {
            ComInfo comInfo = new ComInfo();
            string sqlQuery = "";
            매출구분.DataSource = wnDm.매출구분();
            매출구분.ValueMember = "코드";
            매출구분.DisplayMember = "명칭";

            sqlQuery = "";
            cbo배송사원.ValueMember = "코드";
            cbo배송사원.DisplayMember = "명칭";
            sqlQuery = comInfo.queryStaff();
            wConst.ComboBox_Read_Blank(cbo배송사원, sqlQuery);

            sqlQuery = "";
            cbo전표상태.ValueMember = "코드";
            cbo전표상태.DisplayMember = "명칭";
            sqlQuery = comInfo.queryCode("640");
            sqlQuery += "and B.S_CODE in('2','3') ";  //2: 배송 3:배송완료 

            wConst.ComboBox_Read_Blank(cbo전표상태, sqlQuery);

            sqlQuery = "";

            cbo담당사원.ValueMember = "코드";
            cbo담당사원.DisplayMember = "명칭";
            sqlQuery = comInfo.queryStaff();
            wConst.ComboBox_Read_Blank(cbo담당사원, sqlQuery);
        }

        private void item_out_detail(string condition)
        {
            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = null;
                dt = wDm.fn_배송_List(condition);

                if (dt != null && dt.Rows.Count > 0)
                {
                    tdOutGridTemp.RowCount = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        tdOutGridTemp.Rows[i].Cells["배송배송일"].Value = dt.Rows[i]["DELIVERY_DATE"].ToString();
                        tdOutGridTemp.Rows[i].Cells["배송번호"].Value = dt.Rows[i]["DELIVERY_CD"].ToString();
                        tdOutGridTemp.Rows[i].Cells["배송거래처"].Value = dt.Rows[i]["CUST_NM"].ToString();
                        tdOutGridTemp.Rows[i].Cells["배송제품수"].Value = dt.Rows[i]["ORD_QTY"].ToString();
                        tdOutGridTemp.Rows[i].Cells["배송거래처코드"].Value = dt.Rows[i]["CUST_CD"].ToString();
                        tdOutGridTemp.Rows[i].Cells["배송창고코드"].Value = dt.Rows[i]["STORAGE_CD"].ToString();
                        tdOutGridTemp.Rows[i].Cells["배송창고명"].Value = dt.Rows[i]["STORAGE_NM"].ToString();
                        tdOutGridTemp.Rows[i].Cells["배송자체여부"].Value = dt.Rows[i]["SALE_GB"].ToString();
                        tdOutGridTemp.Rows[i].Cells["배송부가세구분"].Value = dt.Rows[i]["VAT_CD"].ToString();
                        tdOutGridTemp.Rows[i].Cells["담당자"].Value = dt.Rows[i]["STAFF_NM"].ToString();
                        tdOutGridTemp.Rows[i].Cells["전표상태"].Value = dt.Rows[i]["SALE_STATE"].ToString();
                        tdOutGridTemp.Rows[i].Cells["배송사원"].Value = dt.Rows[i]["DELIVERY_STAFF_NM"].ToString();
                        tdOutGridTemp.Rows[i].Cells["등록사원"].Value = dt.Rows[i]["등록자"].ToString();
                        tdOutGridTemp.Rows[i].Cells["등록사원폰"].Value = dt.Rows[i]["INSERT_MOBIL"].ToString();
                        tdOutGridTemp.Rows[i].Cells["배송전표상태"].Value = dt.Rows[i]["S_CODE_NM"].ToString();
                        tdOutGridTemp.Rows[i].Cells["싸인"].Value = dt.Rows[i]["RECIPIENT_SIGN"].ToString();
                        tdOutGridTemp.Rows[i].Cells["주문일자"].Value = dt.Rows[i]["ORD_DATE"].ToString();
                        //tdOutGridTemp.Rows[i].Cells["배송부가세구분"].Value = dt.Rows[i]["ORD_DATE"].ToString();
                        //tdOutGridTemp.Rows[i].Cells["배송부가세구분"].Value = dt.Rows[i]["ORD_DATE"].ToString();
                        //tdOutGridTemp.Rows[i].Cells["배송부가세구분"].Value = dt.Rows[i]["ORD_DATE"].ToString();
                        //tdOutGridTemp.Rows[i].Cells["배송부가세구분"].Value = dt.Rows[i]["ORD_DATE"].ToString();                        
                    }
                }
                else
                {
                    tdOutGridTemp.Rows.Clear();
                }
            }
            catch (Exception e)
            {
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(e.Message+" - "+e.ToString()); msg.ShowDialog();
            }
        }

        private void outputLogic()
        {
            try
            {
                if (txt_cust_cd.Text.ToString().Equals(""))
                {
                    MessageBox.Show("거래처를 선택하시기 바랍니다.");
                    return;
                }

                byte[] saup_img;
                int saup_img_size = 0;
                if (path != null && path != "")
                {
                    saup_img = ComInfo.GetImage(path);
                    saup_img_size = saup_img.Length;
                }
                else
                {
                    saup_img = null;
                    saup_img_size = 0;
                }


               
                    if (cbo전표상태.SelectedIndex == 1 && a == 0)
                    {
                        wnDm wDm = new wnDm();
                        int rsNum = wDm.insert배송등록(
                            txt_out_date.Value.ToString().Substring(0, 10)

                            , txt입력방식.Text.ToString()
                                , cbo담당사원.SelectedValue.ToString()
                                , txt_cust_cd.Text.ToString()
                                , cbo배송사원.SelectedValue.ToString()
                                , cbo전표상태.SelectedValue.ToString()
                                , txt비고.Text.ToString()
                                , txt_staff_nm.Text.ToString()
                                , txt_staff_phone.Text.ToString()
                                , itemOutGrid
                                , str주문일자
                                , str주문번호
                                , str항목순번
                                , str주문시간
                            );

                        if (rsNum == 0)
                        {

                            MessageBox.Show("성공적으로 등록하였습니다.");
                        }
                        else if (rsNum == 1)
                            MessageBox.Show("저장에 실패하였습니다");
                        else if (rsNum == 2)
                            MessageBox.Show("SQL COMMAND 에러");
                        else if (rsNum == 3)
                            MessageBox.Show("기존 코드가 존재하므로 \n 다른 코드로 입력 바랍니다.");
                        else
                            MessageBox.Show("Exception 에러");
                    }
                    else if (cbo전표상태.SelectedIndex == 1 || a == 1)
                    {
                        wnDm wDm = new wnDm();
                        int rsNum = wDm.update배송등록(
                            txt_out_date.Value.ToString().Substring(0, 10)
                            , txt_out_cd.Text.ToString()
                            , txt입력방식.Text.ToString()
                                , cbo담당사원.SelectedValue.ToString()
                                , txt_cust_nm.Text.ToString()
                                , cbo배송사원.SelectedValue.ToString()
                                , cbo전표상태.SelectedValue.ToString()
                                , txt비고.Text.ToString()
                                , txt_staff_nm.Text.ToString()
                                , txt_staff_phone.Text.ToString()
                                , itemOutGrid
                                , saup_img
                                ,saup_img_size
                            );

                        if (rsNum == 0)
                        {

                            MessageBox.Show("성공적으로 수정하였습니다.");
                        }
                        else if (rsNum == 1)
                            MessageBox.Show("저장에 실패하였습니다");
                        else if (rsNum == 2)
                            MessageBox.Show("SQL COMMAND 에러");
                        else if (rsNum == 3)
                            MessageBox.Show("기존 코드가 존재하므로 \n 다른 코드로 입력 바랍니다.");
                        else
                            MessageBox.Show("Exception 에러");
                    }

                    else if (cbo전표상태.SelectedIndex == 2 || a == 1)
                    {
                        if (pic.BackgroundImage == null)
                        {
                            MessageBox.Show("확인싸인을 입력하세요");
                            return;
                        }

                        wnDm wDm = new wnDm();
                        int rsNum = wDm.update배송등록(
                            txt_out_date.Value.ToString().Substring(0, 10)
                            , txt_out_cd.Text.ToString()
                            , txt입력방식.Text.ToString()
                                , cbo담당사원.SelectedValue.ToString()
                                , txt_cust_nm.Text.ToString()
                                , cbo배송사원.SelectedValue.ToString()
                                , cbo전표상태.SelectedValue.ToString()
                                , txt비고.Text.ToString()
                                , txt_staff_nm.Text.ToString()
                                , txt_staff_phone.Text.ToString()
                                , itemOutGrid
                                , saup_img
                                ,saup_img_size
                            );

                        if (rsNum == 0)
                        {

                            MessageBox.Show("성공적으로 수정하였습니다.");
                        }
                        else if (rsNum == 1)
                            MessageBox.Show("저장에 실패하였습니다");
                        else if (rsNum == 2)
                            MessageBox.Show("SQL COMMAND 에러");
                        else if (rsNum == 3)
                            MessageBox.Show("기존 코드가 존재하므로 \n 다른 코드로 입력 바랍니다.");
                        else
                            MessageBox.Show("Exception 에러");
                    }
                
            }
            catch (Exception e)
            {
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(e.Message+" - "+e.ToString()); msg.ShowDialog();
            }
        
        }

        private void resetSetting()
        {
            txt_out_date.Text = "";
            txt_out_cd.Text = "";
            txt_vat_cd.Text = "";
            txt_plan_cd.Text = "";
            txt_jang_cd.Text = "";
            txt입력방식.Text = "";
            cbo담당사원.SelectedIndex = 0;
            cbo배송사원.SelectedIndex = 0;
            cbo전표상태.SelectedIndex = 0;        
            txt_cust_cd.Text = "";
            txt_cust_nm.Text = "";
            txt비고.Text = "";
            txt_staff_nm.Text = "";
            txt_staff_phone.Text = "";
            a = 0;
            itemOutGrid.Rows.Clear();
            pic.BackgroundImage = null;
            //lbl_out_gbn.Text = "";
            //btnDelete.Enabled = false;

            //txt_out_date.Text = DateTime.Now.ToString("yyyy-MM-dd");
            //txt_out_date.Enabled = true;
            //btnCustSrch.Enabled = true;
            //txt_out_cd.Text = "";
            //txt_cust_cd.Text = "";
            //txt_cust_nm.Text = "";
            //old_cust_nm = "";
            //txt_vat_cd.Text = "";

            //txt_cust_nm.Enabled = true;

            ////chk_self_yn.Checked = false;

            //itemOutGrid.Rows.Clear();
          
            //del_outGrid.Rows.Clear();
            //item_out_detail("");
        }

        private void output_list(DataGridView dgv, string condition)
        {
            try
            {
                dgv주문등록.Rows.Clear();
                wnDm wDm = new wnDm();
                DataTable dt = null;
                dt = wDm.fn_배송주문_List(condition);

                if (dt != null && dt.Rows.Count > 0)
                {
                    dgv.RowCount = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        dgv.Rows[i].Cells["H주문일자"].Value = dt.Rows[i]["ORD_DATE"].ToString();
                        dgv.Rows[i].Cells["H주문번호"].Value = dt.Rows[i]["ORD_NUM"].ToString();
                       // dgv.Rows[i].Cells["H항목순번"].Value = dt.Rows[i]["ORD_SEQ"].ToString();
                        dgv.Rows[i].Cells["H주문시간"].Value = dt.Rows[i]["ORD_TIME"].ToString();
                        dgv.Rows[i].Cells["H거래처코드"].Value = dt.Rows[i]["CUST_CD"].ToString();
                        dgv.Rows[i].Cells["H거래처"].Value = dt.Rows[i]["CUST_NM"].ToString();
                        // dgv.Rows[i].Cells[3].Value = dt.Rows[i]["ITEM_CNT"].ToString();
                        dgv.Rows[i].Cells["H담당사원코드"].Value = dt.Rows[i]["STAFF_CD"].ToString();
                        dgv.Rows[i].Cells["H담당사원"].Value = dt.Rows[i]["STAFF_NM"].ToString();
                        //   dgv.Rows[i].Cells[7].Value = dt.Rows[i]["SELF_YN"].ToString();
                        dgv.Rows[i].Cells["H부가세"].Value = dt.Rows[i]["VAT_CD"].ToString();
                        //if (dt.Rows[i]["SALE_STATE"].ToString().Equals("1"))
                        //{
                        //    dgv.Rows[i].Cells["H전표상태"].Value = "배송";
                        //}
                        //else
                        //{
                        //    dgv.Rows[i].Cells["H전표상태"].Value = "배송완료";
                        //}
                        dgv.Rows[i].Cells["H전표상태"].Value = dt.Rows[i]["SALE_STATE_NM"].ToString();
                        dgv.Rows[i].Cells["H비고"].Value = dt.Rows[i]["COMMENT"].ToString();
                        //dgv.Rows[i].Cells[4].Value = dt.Rows[i]["COMPLETE_YN"].ToString();

                        //dgv.Rows[i].Cells["배송배송일"].Value = dt.Rows[i]["ORD_DATE"].ToString();
                        //dgv.Rows[i].Cells["배송번호"].Value = dt.Rows[i]["ORD_DATE"].ToString();
                        //dgv.Rows[i].Cells["배송거래처"].Value = dt.Rows[i]["ORD_DATE"].ToString();
                        //dgv.Rows[i].Cells["배송제품수"].Value = dt.Rows[i]["ORD_DATE"].ToString();
                        //dgv.Rows[i].Cells["배송거래처코드"].Value = dt.Rows[i]["ORD_DATE"].ToString();
                        //dgv.Rows[i].Cells["배송창고코드"].Value = dt.Rows[i]["ORD_DATE"].ToString();
                        //dgv.Rows[i].Cells["배송창고명"].Value = dt.Rows[i]["ORD_DATE"].ToString();
                        //dgv.Rows[i].Cells["배송자체여부"].Value = dt.Rows[i]["ORD_DATE"].ToString();
                        //dgv.Rows[i].Cells["배송부가세구분"].Value = dt.Rows[i]["ORD_DATE"].ToString();                        
                    }
                }
                else
                {
                    dgv.Rows.Clear();
                }
            }
            catch (Exception e)
            {
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(e.Message+" - "+e.ToString()); msg.ShowDialog();
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
                //output_list(tdOutGridTemp, "where convert(varchar(10), A.INTIME, 120) = convert(varchar(10), getDate(), 120) ");
                item_out_detail("");
          
        }

        private void tdOutGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            a = 1;
            if (ComInfo.grdHeaderNoAction(e))
            {
                out_detail(tdOutGridTemp, e);
            }
        }

        private void outputGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void out_detail(DataGridView dgv, DataGridViewCellEventArgs e)
        {
            btnDelete.Enabled = true;
            lbl_out_gbn.Text = "1";
            txt_out_date.Enabled = false;
            txt_cust_nm.Enabled = false;
            btnCustSrch.Enabled = false;
            txt_out_date.Text = dgv.Rows[e.RowIndex].Cells[0].Value.ToString();

            txt_out_cd.Text = dgv.Rows[e.RowIndex].Cells[1].Value.ToString();
            txt_cust_cd.Text = dgv.Rows[e.RowIndex].Cells[4].Value.ToString();
            txt_cust_nm.Text = dgv.Rows[e.RowIndex].Cells[2].Value.ToString();
            old_cust_nm = dgv.Rows[e.RowIndex].Cells[4].Value.ToString();
          
            txt_vat_cd.Text = dgv.Rows[e.RowIndex].Cells[8].Value.ToString();

            cbo담당사원.Text = dgv.Rows[e.RowIndex].Cells[9].Value.ToString();             
            cbo전표상태.SelectedIndex = int.Parse(dgv.Rows[e.RowIndex].Cells[10].Value.ToString()) -1 ;
            cbo배송사원.Text = dgv.Rows[e.RowIndex].Cells[11].Value.ToString(); 

            str주문일자 = dgv.Rows[e.RowIndex].Cells[0].Value.ToString();
            str주문번호 = dgv.Rows[e.RowIndex].Cells[1].Value.ToString();

            txt_staff_nm.Text = dgv.Rows[e.RowIndex].Cells["등록사원"].Value.ToString();
            txt_staff_phone.Text = dgv.Rows[e.RowIndex].Cells["등록사원폰"].Value.ToString();
            try
            {
                
                 
                
            }
            catch( Exception ex )
            {
                Debug.WriteLine(ex.ToString());
            }
           

            outputDetail2();
            item_out_detail("");
        }

        private void outputDetail2()
        {
            itemOutGrid.Rows.Clear();            

            DataTable dt = wnDm.fn_주문항목_List(" where A.ORD_DATE='" + str주문일자 + "' and A.ORD_NUM='" + str주문번호 + "'");
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    itemOutGrid.Rows.Add();
                    //   dgv주문등록.Rows[i].Cells["P_PLAN_DATE"].Value = dt.Rows[i]["ORD_DATE"].ToString();
                    //  dgv주문등록.Rows[i].Cells["P_PLAN_CD"].Value = dt.Rows[i]["ORD_NUM"].ToString();
                    itemOutGrid.Rows[i].Cells["O_SPEC"].Value = dt.Rows[i]["SPEC"].ToString();
                    itemOutGrid.Rows[i].Cells["O_NO"].Value = dt.Rows[i]["ORD_SEQ"].ToString();
                    itemOutGrid.Rows[i].Cells["O_ITEM_CD"].Value = dt.Rows[i]["ITEM_CD"].ToString();
                    itemOutGrid.Rows[i].Cells["O_ITEM_NM"].Value = dt.Rows[i]["ITEM_NM"].ToString();
                    itemOutGrid.Rows[i].Cells["O_UNIT_CD"].Value = dt.Rows[i]["UNIT_CD"].ToString();
                    itemOutGrid.Rows[i].Cells["O_UNIT_NM"].Value = dt.Rows[i]["UNIT_NM"].ToString();
                    itemOutGrid.Rows[i].Cells["최종매출일"].Value = DateTime.Parse(dt.Rows[i]["LAST_DATE"].ToString());
                    itemOutGrid.Rows[i].Cells["비고"].Value = dt.Rows[i]["COMMENT"].ToString();
                    itemOutGrid.Rows[i].Cells["매출구분"].Value = dt.Rows[i]["SALE_GB"].ToString();



                    itemOutGrid.Rows[i].Cells["TOTAL_AMT"].Value = (decimal.Parse(dt.Rows[i]["ORD_QTY"].ToString())).ToString("#,0.######");
                    itemOutGrid.Rows[i].Cells["PRICE"].Value = (decimal.Parse(dt.Rows[i]["ORD_PRICE"].ToString())).ToString("#,0.######");
                    itemOutGrid.Rows[i].Cells["TOTAL_MONEY"].Value = (decimal.Parse(dt.Rows[i]["ORD_AMT"].ToString())).ToString("#,0.######");

                }

                byte[] rs = (byte[])dt.Rows[0]["RECIPIENT_SIGN"];
                MemoryStream ms = new MemoryStream(rs);
                Image img = Image.FromStream(ms);

                Image cus_img = ComInfo.pic_resize_logic(pic, img);

                pic.BackgroundImage = cus_img;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                msg.ShowDialog();
            }
        }
        public static bool grdHeaderNoAction(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return false;
            }
            else return true;
        }

        private void output_del()
        {
            try
            {
                int rsNum = 2;
                wnDm wdm = new wnDm();
                rsNum = wdm.Delete_s_배송등록(txt_out_date.Text, txt_out_cd.Text);

                if (rsNum == 0)
                {
                    MessageBox.Show("삭제되었습니다.");
                    resetSetting();
                }
                else if (rsNum == 1)
                    MessageBox.Show("삭제에 실패하였습니다");
                else
                    MessageBox.Show("Exception 에러");
            }

            catch (Exception e2)
            {
                MessageBox.Show("시스템 에러: " + e2.Message.ToString());
            }
         
        }
        #endregion item out local logic


        #region grid control

        private void grid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            conDataGridView grd = (conDataGridView)sender;

            grd.Rows[e.RowIndex].Cells[0].Value = false;

            //wConst.init_RowText(grd, e.RowIndex);

            for (int kk = 0; kk < grd.Rows.Count; kk++)
            {
                grd.Rows[kk].Cells[1].Value = (kk + 1).ToString();
            }
        }

        private void grid_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            conDataGridView grd = (conDataGridView)sender;

            for (int kk = 0; kk < grd.Rows.Count; kk++)
            {
                grd.Rows[kk].Cells[1].Value = (kk + 1).ToString();
            }
        }

        private void grid_KeyDown(object sender, KeyEventArgs e)
        {
            // Edit 모드가 아닐때, 작동함.

            conDataGridView grd = (conDataGridView)sender;
            DataGridViewCell cell = grd[grd.CurrentCell.ColumnIndex, grd.CurrentCell.RowIndex];

            if (grd.CurrentCell == null) return;
            if (grd.CurrentCell.RowIndex < 0) return;
            if (grd.CurrentCell.ColumnIndex < 0) return;

            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }
        }

        private void grid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            conDataGridView grd = (conDataGridView)sender;

            // 헤더 첫 컬럼 클릭시
            if (e.ColumnIndex != 0) return;

            if (bHeadCheck == false)
            {
                grd.Columns[0].HeaderText = "[v]";
                bHeadCheck = true;
                select_Check(grd, bHeadCheck);
            }
            else
            {
                grd.Columns[0].HeaderText = "[ ]";
                bHeadCheck = false;
                select_Check(grd, bHeadCheck);
            }
            grd.RefreshEdit();
            grd.Refresh();
        }

        private void grid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            string name = itemOutGrid.CurrentCell.OwningColumn.Name;

            if (name == "TOTAL_AMT" || name == "PRICE" || name == "TOTAL_MONEY")
            {
                e.Control.KeyPress += new KeyPressEventHandler(txtCheckNumeric_KeyPress);
            }
            else
            {
                e.Control.KeyPress -= new KeyPressEventHandler(txtCheckNumeric_KeyPress);
            }
        }

        private void select_Check(conDataGridView grd, bool bCheck)
        {
            for (int kk = 0; kk < grd.Rows.Count; kk++)
            {
                if (bCheck == true)
                {
                    grd.Rows[kk].Cells[0].Value = true;
                }
                else
                {
                    grd.Rows[kk].Cells[0].Value = false;
                }
            }
        }

        private void txtCheckNumeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComInfo.onlyNum(sender, e);
        }

        private void grid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            conDataGridView grd = (conDataGridView)sender;
            DataGridViewCell cell = grd[e.ColumnIndex, e.RowIndex];

            //cell.Style.BackColor = Color.White;

            if (grd.Columns[e.ColumnIndex].ToolTipText.IndexOf("수량") >= 0
                || grd.Columns[e.ColumnIndex].ToolTipText.IndexOf("단가") >= 0
                || grd.Columns[e.ColumnIndex].ToolTipText.IndexOf("금액") >= 0)
            {

                string total_amt = (string)grd.Rows[e.RowIndex].Cells["TOTAL_AMT"].Value;
                string price = (string)grd.Rows[e.RowIndex].Cells["PRICE"].Value;

                if (total_amt != null)
                {
                    total_amt = total_amt.ToString().Replace(" ", "");
                    if (total_amt == "")
                    {
                        grd.Rows[e.RowIndex].Cells["TOTAL_AMT"].Value = "0";
                    }
                }
                else
                {
                    grd.Rows[e.RowIndex].Cells["TOTAL_AMT"].Value = "0";
                }

                if (price != null)
                {
                    price = price.ToString().Replace(" ", "");
                    if (price == "")
                    {
                        grd.Rows[e.RowIndex].Cells["PRICE"].Value = "0";
                    }
                }
                else
                {
                    grd.Rows[e.RowIndex].Cells["PRICE"].Value = "0";
                }

                wConst.f_Calc_Price(grd, e.RowIndex, "TOTAL_AMT", "PRICE");
            }
        }
        #endregion grid control

        private void txt_bar_KeyPress(object sender, KeyPressEventArgs e)
        {
            

            
        }

        private void btn_minus_Click(object sender, EventArgs e)
        {
            ///행삭제 했을때 선택삭제되는 데이터와 
            ///출고예정리스트와 비교하여 
            ///visible =true 해주어서   false였던 데이터를  다시생기는것처럼 보여주게한다 
            
            for (int i = 0; i < itemOutGrid.Rows.Count; i++)
            {
                if (
                      (String)itemOutGrid.SelectedRows[0].Cells["O_LOT_NO"].Value == (String)dgv주문등록.Rows[i].Cells["LOT_NO"].Value
                      && (String)itemOutGrid.SelectedRows[0].Cells["O_LOT_SUB"].Value == (String)dgv주문등록.Rows[i].Cells["LOT_SUB"].Value
                      && (String)itemOutGrid.SelectedRows[0].Cells["O_ITEM_CD"].Value == (String)dgv주문등록.Rows[i].Cells["ITEM_CD"].Value
                      && (String)itemOutGrid.SelectedRows[0].Cells["O_ITEM_NM"].Value == (String)dgv주문등록.Rows[i].Cells["ITEM_NM"].Value
                      && (String)itemOutGrid.SelectedRows[0].Cells["OUTPUT_AMT"].Value == (String)dgv주문등록.Rows[i].Cells["STOCK_AMT"].Value
                    )
                {


                    dgv주문등록.Rows[i].Visible = true;

                }
            }




            if (itemOutGrid.Rows.Count > 0)
            {
                if (itemOutGrid.Rows[itemOutGrid.CurrentCell.RowIndex].Cells["SEQ"].Value != null && !itemOutGrid.Rows[itemOutGrid.CurrentCell.RowIndex].Cells["SEQ"].Value.ToString().Equals(""))
                {
                    del_outGrid.Rows.Add();
                    del_outGrid.Rows[del_outGrid.Rows.Count - 1]["SEQ"] = itemOutGrid.Rows[itemOutGrid.CurrentCell.RowIndex].Cells["SEQ"].Value;
                    del_outGrid.Rows[del_outGrid.Rows.Count - 1]["J_SEQ"] = itemOutGrid.Rows[itemOutGrid.CurrentCell.RowIndex].Cells["J_INPUT_SEQ"].Value;
                    del_outGrid.Rows[del_outGrid.Rows.Count - 1]["LOT_NO"] = itemOutGrid.Rows[itemOutGrid.CurrentCell.RowIndex].Cells["O_LOT_NO"].Value;
                    del_outGrid.Rows[del_outGrid.Rows.Count - 1]["LOT_SUB"] = itemOutGrid.Rows[itemOutGrid.CurrentCell.RowIndex].Cells["O_LOT_SUB"].Value;
                }


                itemOutGrid.Rows.RemoveAt(itemOutGrid.CurrentCell.RowIndex);
            }
        }

        private void txt_cust_nm_TextChanged(object sender, EventArgs e)
        {

        }

        private void frm배송등록_Enter(object sender, EventArgs e)
        {
          
            output_list(dgv주문등록, "");
        }

        private void btnSerch_Click(object sender, EventArgs e)
        {
            item_out_detail("and 배송H.DELIVERY_DATE>='" + txt_start_date.Value.ToString().Substring(0, 10) + "' and 배송H.DELIVERY_DATE<='" + txt_end_date.Value.ToString().Substring(0, 10) + "'");
        }

        private void dgv주문등록_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            resetSetting();
            itemOutGrid.Rows.Clear();
            str주문일자=dgv주문등록.Rows[e.RowIndex].Cells["H주문일자"].Value.ToString();
            str주문번호 = dgv주문등록.Rows[e.RowIndex].Cells["H주문번호"].Value.ToString();
       //     str항목순번 = dgv주문등록.Rows[e.RowIndex].Cells["H항목순번"].Value.ToString();
            str주문시간 = dgv주문등록.Rows[e.RowIndex].Cells["H주문시간"].Value.ToString();

           cbo담당사원.SelectedValue = dgv주문등록.Rows[e.RowIndex].Cells["H담당사원코드"].Value.ToString();
           cbo전표상태.Text = dgv주문등록.Rows[e.RowIndex].Cells["H전표상태"].Value.ToString();

           txt_cust_nm.Text = dgv주문등록.Rows[e.RowIndex].Cells["H거래처"].Value.ToString();
           txt_cust_cd.Text = dgv주문등록.Rows[e.RowIndex].Cells["H거래처코드"].Value.ToString();
           txt비고.Text = dgv주문등록.Rows[e.RowIndex].Cells["H비고"].Value.ToString();


           DataTable dt = wnDm.fn_배송항목_List(" where A.ORD_DATE='" + str주문일자 + "' and ORD_NUM='" + str주문번호 + "'");
           try
           {
               for (int i = 0; i < dt.Rows.Count; i++)
               {
                   itemOutGrid.Rows.Add();
                   //   dgv주문등록.Rows[i].Cells["P_PLAN_DATE"].Value = dt.Rows[i]["ORD_DATE"].ToString();
                   //  dgv주문등록.Rows[i].Cells["P_PLAN_CD"].Value = dt.Rows[i]["ORD_NUM"].ToString();
                   itemOutGrid.Rows[i].Cells["O_SPEC"].Value = dt.Rows[i]["SPEC"].ToString();
                   itemOutGrid.Rows[i].Cells["O_NO"].Value = dt.Rows[i]["ORD_SEQ"].ToString();
                   itemOutGrid.Rows[i].Cells["O_ITEM_CD"].Value = dt.Rows[i]["ITEM_CD"].ToString();
                   itemOutGrid.Rows[i].Cells["O_ITEM_NM"].Value = dt.Rows[i]["ITEM_NM"].ToString();
                   itemOutGrid.Rows[i].Cells["O_UNIT_CD"].Value = dt.Rows[i]["UNIT_CD"].ToString();
                   itemOutGrid.Rows[i].Cells["O_UNIT_NM"].Value = dt.Rows[i]["UNIT_NM"].ToString();
                   itemOutGrid.Rows[i].Cells["최종매출일"].Value = DateTime.Parse(dt.Rows[i]["LAST_DATE"].ToString());
                   itemOutGrid.Rows[i].Cells["비고"].Value = dt.Rows[i]["COMMENT"].ToString();
                   itemOutGrid.Rows[i].Cells["매출구분"].Value = dt.Rows[i]["SALE_GB"].ToString();



                   itemOutGrid.Rows[i].Cells["TOTAL_AMT"].Value = (decimal.Parse(dt.Rows[i]["ORD_QTY"].ToString())).ToString("#,0.######");
                   itemOutGrid.Rows[i].Cells["PRICE"].Value = (decimal.Parse(dt.Rows[i]["ORD_PRICE"].ToString())).ToString("#,0.######");
                   itemOutGrid.Rows[i].Cells["TOTAL_MONEY"].Value = (decimal.Parse(dt.Rows[i]["ORD_AMT"].ToString())).ToString("#,0.######");

               }
           }
           catch (Exception ex)
           {
               Debug.WriteLine(ex.ToString());
               Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
               msg.ShowDialog();
           }
        }


        //싸인 그림불러오기
        string path;
        Image image;
        private void btn싸인_Click(object sender, EventArgs e)
        {
            ofd.FileName = "";
            ofd.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //이미지 
                image = Image.FromFile(ofd.FileName);
                //이미지 경로 
                path = ofd.FileName;

                /* 이미지 리사이즈 */
                Image sign_img = ComInfo.pic_resize_logic(pic, image);
                //픽쳐박스에 이미지를 띄운다
                pic.BackgroundImage = sign_img;
            }
            else
            {
                pic.BackgroundImage = null;

            }
        }

        private void btn배송완료_Click(object sender, EventArgs e)
        {
            output_list(dgv주문등록,"and A.ORD_DATE >= '" + dtp스타트.Text.ToString() + "' and  A.ORD_DATE <= '" + dtp앤드.Text.ToString() + "'");
        }
    }
}
