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
using System.Diagnostics;

namespace MES.P85_BAS
{
    public partial class frm권한관리 : Form
    {
        int max_cnt = 14;
        int top_cnt = 0;
        private DataGridView[] dgvAuth = new DataGridView[14];
        private CheckBox[] chkAuth = new CheckBox[21];
        private Button[] btnAuth = new Button[21];
        private Panel[] pnlAuth = new Panel[21];
      
        private string[] topCode = new string[21]; 

        public frm권한관리()
        {
           
            
                InitializeComponent();
            
        }

        private void frm권한관리_Load(object sender, EventArgs e)
        {
            
            
               lbl_title.Tag = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[0] + "$" + wnDm.fn_TitleName(this.Name.ToString()).Split('$')[1]; lbl_title.Text = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[2];
            
            user_list();
            getSetting();

            authLogic("1");
            try
            {
                //if (Common.p_strUserAdmin!="5")
                //{
                //    this.BeginInvoke(new MethodInvoker(Close));
                //   /// MessageBox.Show("권한이없습니다.");
                //}

            }
            catch(Exception ex )
            {
            }
        }

        #region button 
        private void btnSave_Click(object sender, EventArgs e)
        {
            saveLogic();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion button 
        

        private void getSetting()
        {
            //서브메뉴의 그리드뷰 
            dgvAuth[0] = grdAuth01;
            dgvAuth[1] = grdAuth02;
            dgvAuth[2] = grdAuth03;
            dgvAuth[3] = grdAuth04;
            dgvAuth[4] = grdAuth05;
            dgvAuth[5] = grdAuth06;
            dgvAuth[6] = grdAuth07;
            dgvAuth[7] = grdAuth08;
            dgvAuth[8] = grdAuth09;
            dgvAuth[9] = grdAuth10;
            dgvAuth[10] = grdAuth11;
            dgvAuth[11] = grdAuth12;
            dgvAuth[12] = grdAuth13;
            dgvAuth[13] = grdAuth14;

            //탑메뉴 체크박스 
            chkAuth[0] = chk_auth01;
            chkAuth[1] = chk_auth02;
            chkAuth[2] = chk_auth03;
            chkAuth[3] = chk_auth04;
            chkAuth[4] = chk_auth05;
            chkAuth[5] = chk_auth06;
            chkAuth[6] = chk_auth07;
            chkAuth[7] = chk_auth08;
            chkAuth[8] = chk_auth09;
            chkAuth[9] = chk_auth10;
            chkAuth[10] = chk_auth11;
            chkAuth[11] = chk_auth12;
            chkAuth[12] = chk_auth13;
            chkAuth[13] = chk_auth14;

            //탑판넬 안에 있는 전체체크 버튼 
            btnAuth[0] = btn전체체크1;
            btnAuth[1] = btn전체체크2;
            btnAuth[2] = btn전체체크3;
            btnAuth[3] = btn전체체크4;
            btnAuth[4] = btn전체체크5;
            btnAuth[5] = btn전체체크6;
            btnAuth[6] = btn전체체크7;
            btnAuth[7] = btn전체체크8;
            btnAuth[8] = btn전체체크9;
            btnAuth[9] = btn전체체크10;
            btnAuth[10] = btn전체체크11;
            btnAuth[11] = btn전체체크12;
            btnAuth[12] = btn전체체크13;
            btnAuth[13] = btn전체체크14;


            //살몬색 탑판넬
            pnlAuth[0] = pnl1;
            pnlAuth[1] = pnl2;
            pnlAuth[2] = pnl3;
            pnlAuth[3] = pnl4;
            pnlAuth[4] = pnl5;
            pnlAuth[5] = pnl6;
            pnlAuth[6] = pnl7;
            pnlAuth[7] = pnl8;
            pnlAuth[8] = pnl9;
            pnlAuth[9] = pnl10;
            pnlAuth[10] = pnl11;
            pnlAuth[11] = pnl12;
            pnlAuth[12] = pnl13;
            pnlAuth[13] = pnl14;




            wnDm wDm = new wnDm();
            DataTable dt = new DataTable();

            dt = wDm.fn_TopMenu_List();

            top_cnt = dt.Rows.Count;
            if (dt != null && dt.Rows.Count > 0) 
            {
                bool chk = false;
                if (dt.Rows.Count > 7) //권한 top메뉴가 8개이상일 경우 밑에 pnl2는 보이지 않도록 설정
                {
                    chk = true;

                    for (int i = dt.Rows.Count; i < max_cnt; i++) //top메뉴가 9개일 경우 10번째 부터는 숨김 
                    {
                        chkAuth[i].Visible = false;
                        dgvAuth[i].Visible = false;
                        btnAuth[i].Visible = false;
                        pnlAuth[i].Visible = false;
                    }
                }
                else
                {
                    for (int i = 7; i < max_cnt; i++)
                    {
                        chkAuth[i].Visible = false;
                        dgvAuth[i].Visible = false;
                        btnAuth[i].Visible = false;
                        pnlAuth[i].Visible = false;
                    }
                }

              //  pnl2.Visible = chk;

                for (int i = 0;i < dt.Rows.Count; i++) 
                {
                    topCode[i] = dt.Rows[i]["TopID"].ToString();
                    chkAuth[i].Text = dt.Rows[i]["TopName"].ToString();
                }
            }

            
            for (int i = 0; i < max_cnt; i++)
            {
                dgvAuth[i].Columns.Add("SubID", "SubID"); //index 0
                dgvAuth[i].Columns.Add("SubName", "SubName"); //1
                DataGridViewCheckBoxColumn chkColumn = new DataGridViewCheckBoxColumn();
                DataGridViewCheckBoxColumn chkColumn1 = new DataGridViewCheckBoxColumn();
                DataGridViewCheckBoxColumn chkColumn2 = new DataGridViewCheckBoxColumn();

                dgvAuth[i].Columns.Add(chkColumn); //index 8
                dgvAuth[i].Columns.Add(chkColumn1); //index 8
                dgvAuth[i].Columns.Add(chkColumn2); //index 8

                chkColumn.HeaderText = "열람";
                chkColumn.Name = "CHK";
                chkColumn1.HeaderText = "입력 ";
                chkColumn1.Name = "CHK1";
                chkColumn2.HeaderText = "삭제 ";
                chkColumn2.Name = "CHK2";

                dgvAuth[i].Columns[0].HeaderText = "메뉴";              
                dgvAuth[i].Columns[0].Visible = false;
                dgvAuth[i].Columns[1].Width = 130;
                dgvAuth[i].Columns[1].HeaderText = "메뉴";
                dgvAuth[i].Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvAuth[i].Columns[1].Frozen = true;
                dgvAuth[i].Columns[2].Width = 40;
                dgvAuth[i].Columns[2].ReadOnly = false;
                dgvAuth[i].Columns[3].Width = 40;
                dgvAuth[i].Columns[3].ReadOnly = false;
                dgvAuth[i].Columns[4].Width = 40;
                dgvAuth[i].Columns[4].ReadOnly = false;

                dgvAuth[i].Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                dgvAuth[i].Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                dgvAuth[i].Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
           



                chkAuth[i].CheckedChanged += new EventHandler(CheckChange);
            }
        
        }
        private void user_list()
        {
            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = null;
                dt = wDm.fn_Staff_List("");

                if (dt != null && dt.Rows.Count > 0)
                {
                    this.dataUserGrid.RowCount = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dataUserGrid.Rows[i].Cells[0].Value = dt.Rows[i]["STAFF_CD"].ToString();
                        dataUserGrid.Rows[i].Cells[1].Value = dt.Rows[i]["STAFF_NM"].ToString();
                        dataUserGrid.Rows[i].Cells[2].Value = dt.Rows[i]["DEPT_NM"].ToString();
                        dataUserGrid.Rows[i].Cells[3].Value = dt.Rows[i]["POS_NM"].ToString();
                        dataUserGrid.Rows[i].Cells[4].Value = dt.Rows[i]["COMMENT"].ToString();
                        if (dt.Rows[i]["AUTH_SET"].ToString() == "5")
                        {
                            dataUserGrid.Rows[i].Cells[5].Value = "관리자";
                        }
                        else
                        {
                            dataUserGrid.Rows[i].Cells[5].Value = "";


                        }
                        dataUserGrid.Rows[i].Cells["ID"].Value = dt.Rows[i]["LOGIN_ID"].ToString();

                      
                    }
                }
                else
                {
                    dataUserGrid.Rows.Clear();
                }
            }
            catch (Exception e)
            {
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(e.Message + " - " + e.ToString());
                msg.ShowDialog();
            }
        }

        private void saveLogic() 
        {

            if (txt_user.Text.ToString().Equals("")) 
            {
                MessageBox.Show("사원을 선택하시기 바랍니다. ");
                return;
            }

            // 5번 관리 통제자면 다 체크 되게 
            if (txt_auth_set.Text.ToString().Equals("5")) 
            {
                MessageBox.Show("관리통제자는 모든 권한을 허용합니다. ");

                for (int i = 0; i < top_cnt; i++) 
                {
                    chkAuth[i].Checked = true;

                    for (int j = 0; j < dgvAuth[i].Rows.Count; j++) 
                    {
                        dgvAuth[i].Rows[j].Cells["CHK"].Value = true;
                        dgvAuth[i].Rows[j].Cells["CHK1"].Value = true;
                        dgvAuth[i].Rows[j].Cells["CHK2"].Value = true;
                    }
                }
            }
            DataTable dt = new DataTable();
            wnDm wDm = new wnDm();
            StringBuilder sb = new StringBuilder();

            // 체크가 안되어 있으면 null값이다 null 예외처리하기위해 null은 체크안한걸로 변경
            for (int i = 0; i < top_cnt; i++)
            {
               

                for (int j = 0; j < dgvAuth[i].Rows.Count; j++)
                {
                    dgvAuth[i].Rows[j].Cells["CHK"].Value = dgvAuth[i].Rows[j].Cells["CHK"].Value ?? false;
                    dgvAuth[i].Rows[j].Cells["CHK1"].Value = dgvAuth[i].Rows[j].Cells["CHK1"].Value ?? false;
                    dgvAuth[i].Rows[j].Cells["CHK2"].Value = dgvAuth[i].Rows[j].Cells["CHK2"].Value ?? false;
                }
            }
            int rsNum = wDm.inAndUpAuth(
                             txt_user_cd.Text.ToString()
                             , dgvAuth
                             , chkAuth
                             , topCode
                             , top_cnt
                             );

            if (rsNum == 0)
            {
                MessageBox.Show("성공적으로 수정하였습니다.");
            }
            else if (rsNum == 1)
                MessageBox.Show("저장에 실패하였습니다");
            else
                MessageBox.Show("Exception 에러");
        }

        private void Reset()
        {

            Control.ControlCollection myCnt = this.Controls;



            foreach (Control ctl in myCnt)
            {

                if (ctl.GetType().FullName == "System.Windows.Form.TextBox")
                {

                    ctl.Text = "";

                }

            }

        }
        private void dataUserGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.lblMsg2.Text = "Loading...";
            this.lblMsg2.Visible = true;
            this.lblMsg2.BringToFront();
            txt_auth_set.Text = dataUserGrid.Rows[e.RowIndex].Cells["AUTH_SET"].Value.ToString();
        
            
            Application.DoEvents();


            txt_user_cd.Text = dataUserGrid.Rows[e.RowIndex].Cells["dgvUser_cd"].Value.ToString();
            txt_user_nm.Text = dataUserGrid.Rows[e.RowIndex].Cells["ID"].Value.ToString();
            txt_user.Text = dataUserGrid.Rows[e.RowIndex].Cells["dgvUser_nm"].Value.ToString();
            txt_dept_nm.Text = dataUserGrid.Rows[e.RowIndex].Cells["dgvUser_dept"].Value.ToString();
            txt_join_date.Text = dataUserGrid.Rows[e.RowIndex].Cells["dgvUser_pos"].Value.ToString();
         
            authLogic("2");

            
            //원장, 매출항목 뿌려줌.

            if (txt_auth_set.Text == "관리자")
            {
                //  this.lblMsg2.Visible = false;
                MessageBox.Show("관리 통제자입니다.");

                for (int i = 0; i < top_cnt; i++)
                {
                    chkAuth[i].Checked = true;

                    for (int j = 0; j < dgvAuth[i].Rows.Count; j++)
                    {
                        dgvAuth[i].Rows[j].Cells[2].Value = true;
                        dgvAuth[i].Rows[j].Cells[3].Value = true;
                        dgvAuth[i].Rows[j].Cells[4].Value = true;
                    }
                }
                //return;
            }
            dataUserGrid.Visible = false;

            this.lblMsg2.Visible = false;

        }

        private void authLogic(string gubun) 
        {
            try
            {
                if (gubun == "1")
                {
                    authDefaultLogic();
                }
                else 
                {
                    for (int i = 0; i < top_cnt; i++)
                    {
                        wnDm wDm = new wnDm();
                        DataTable dt = new DataTable();
                        DataTable dt_sub = new DataTable();

                        dt = wDm.fn_AuthTopCodeUser(topCode[i], txt_user_cd.Text.ToString());

                        if (dt != null && dt.Rows.Count > 0)
                        {
                            chkAuth[i].Checked = dt.Rows[0]["AUTH_YN"].ToString().Equals("Y") ? true : false;
                        }
                        else 
                        {
                            chkAuth[i].Checked = false;
                        }

                        dt_sub = wDm.fn_AuthSubCodeUser(topCode[i], txt_user_cd.Text.ToString());
                        dgvAuth[i].Rows.Clear();

                        if (dt_sub != null && dt_sub.Rows.Count > 0)
                        {
                            for (int j = 0; j < dt_sub.Rows.Count; j++)
                            {
                                dgvAuth[i].Rows.Add();
                                dgvAuth[i].Rows[j].Cells[0].Value = dt_sub.Rows[j]["SubID"].ToString();
                                dgvAuth[i].Rows[j].Cells[1].Value = dt_sub.Rows[j]["SubName"].ToString();
                                dgvAuth[i].Rows[j].Cells[2].Value = dt_sub.Rows[j]["AUTH_YN"].ToString().Equals("Y") ? true : false;
                                dgvAuth[i].Rows[j].Cells[3].Value = dt_sub.Rows[j]["rgstr_yn"].ToString().Equals("Y") ? true : false;
                                dgvAuth[i].Rows[j].Cells[4].Value = dt_sub.Rows[j]["del_yn"].ToString().Equals("Y") ? true : false;
                            }
                        }
                        else 
                        {
                            authDefaultLogic();
                        }
                    }
                }
            }
            catch (Exception e) 
            {
                MessageBox.Show("시스템 오류 ", e.ToString());
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(e.Message + " - " + e.ToString());
                msg.ShowDialog();
            }
        }


        private void authDefaultLogic()
        {
            for (int i = 0; i < top_cnt; i++)
            {
                wnDm wDm = new wnDm();
                DataTable dt = new DataTable();

                dt = wDm.fn_AuthSubCode(topCode[i]);

                dgvAuth[i].Rows.Clear();

                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        dgvAuth[i].Rows.Add();
                        dgvAuth[i].Rows[j].Cells[0].Value = dt.Rows[j]["SubID"].ToString();
                        dgvAuth[i].Rows[j].Cells[1].Value = dt.Rows[j]["SubName"].ToString();
                        dgvAuth[i].Rows[j].Cells[2].Value = false;
                    }
                }
            }
        
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CheckChange(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;

            int idx = int.Parse(cb.Name.Substring(cb.Name.Length - 2)) - 1; //그리드뷰 명칭의 끝 가져오기, workComp01 ~ workComp12 까지 지정되어 있음

        }
        int chkgrdAuth01=0;
        private void grdAuth01_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            bool istrue = true;
            if (chkgrdAuth01%2==0)
            {
                istrue = true;

            }
            else
            {
                istrue = false;
            }
            chkgrdAuth01++;


            전체체크(e.ColumnIndex,sender as DataGridView ,istrue);
        }
        int chkbtn전체체크1 = 0;
        private void btn전체체크1_Click(object sender, EventArgs e)
        {
            bool istrue = true;
            if (chkbtn전체체크1 % 2 == 0)
            {
                istrue = true;

            }
            else
            {
                istrue = false;
            }
            chkbtn전체체크1++;

            chk_auth01.Checked = istrue;
            foreach (DataGridViewRow row in grdAuth01.Rows)
            {
                row.Cells["chk"].Value = istrue;
                row.Cells["chk1"].Value = istrue;
                row.Cells["chk2"].Value = istrue;
                Debug.WriteLine(row.Cells["chk2"].ToString());
                
            }
        }
        int chkgrdAuth02 = 0;

        private void grdAuth02_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            bool istrue = true;
            if (chkgrdAuth02 % 2 == 0)
            {
                istrue = true;

            }
            else
            {
                istrue = false;
            }
            chkgrdAuth02++;


            전체체크(e.ColumnIndex, sender as DataGridView, istrue);
        }
        int chkbtn전체체크2 = 0;
        private void btn전체체크2_Click(object sender, EventArgs e)
        {
            bool istrue = true;
            if (chkbtn전체체크2 % 2 == 0)
            {
                istrue = true;

            }
            else
            {
                istrue = false;
            }
            chkbtn전체체크2++;

            chk_auth02.Checked = istrue;
            foreach (DataGridViewRow row in grdAuth02.Rows)
            {
                row.Cells["chk"].Value = istrue;
                row.Cells["chk1"].Value = istrue;
                row.Cells["chk2"].Value = istrue;
            }
        }




        private void 전체체크(int col_num,DataGridView dgv,bool trueNfalse)
        {

            #region 체크
            if (col_num == 2)
            {
                if (dgv.Rows.Count > 0)
                {

                    foreach (DataGridViewRow rows in dgv.Rows)
                    {


                        rows.Cells["chk"].Value = trueNfalse;


                    }



                }

            }
            else if (col_num == 3)
            {
                if (dgv.Rows.Count > 0)
                {

                    foreach (DataGridViewRow rows in dgv.Rows)
                    {


                        rows.Cells["chk1"].Value = trueNfalse;


                    }



                }
            }
            else if (col_num == 4)
            {
                if (dgv.Rows.Count > 0)
                {

                    foreach (DataGridViewRow rows in dgv.Rows)
                    {


                        rows.Cells["chk2"].Value = trueNfalse;


                    }



                }
            }
            #endregion

        }
        int chkgrdAuth03 = 0;

        #region 헤드
        private void grdAuth03_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            bool istrue = true;
            if (chkgrdAuth03 % 2 == 0)
            {
                istrue = true;

            }
            else
            {
                istrue = false;
            }
            chkgrdAuth03++;


            전체체크(e.ColumnIndex, sender as DataGridView, istrue);
        }
        int chkgrdAuth04 = 0;
        private void grdAuth04_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            bool istrue = true;
            if (chkgrdAuth04 % 2 == 0)
            {
                istrue = true;

            }
            else
            {
                istrue = false;
            }
            chkgrdAuth04++;


            전체체크(e.ColumnIndex, sender as DataGridView, istrue);
        }
        int chkgrdAuth05 = 0;

        private void grdAuth05_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            bool istrue = true;
            if (chkgrdAuth05 % 2 == 0)
            {
                istrue = true;

            }
            else
            {
                istrue = false;
            }
            chkgrdAuth05++;


            전체체크(e.ColumnIndex, sender as DataGridView, istrue);
        }
        int chkgrdAuth06 = 0;

        private void grdAuth06_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            bool istrue = true;
            if (chkgrdAuth06 % 2 == 0)
            {
                istrue = true;

            }
            else
            {
                istrue = false;
            }
            chkgrdAuth06++;


            전체체크(e.ColumnIndex, sender as DataGridView, istrue);
        }
        int chkgrdAuth07 = 0;

        private void grdAuth07_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            bool istrue = true;
            if (chkgrdAuth07 % 2 == 0)
            {
                istrue = true;

            }
            else
            {
                istrue = false;
            }
            chkgrdAuth07++;


            전체체크(e.ColumnIndex, sender as DataGridView, istrue);
        }
        int chkgrdAuth08 = 0;

        private void grdAuth08_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            bool istrue = true;
            if (chkgrdAuth08 % 2 == 0)
            {
                istrue = true;

            }
            else
            {
                istrue = false;
            }
            chkgrdAuth08++;


            전체체크(e.ColumnIndex, sender as DataGridView, istrue);
        }
        int chkgrdAuth09 = 0;

        private void grdAuth09_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            bool istrue = true;
            if (chkgrdAuth09 % 2 == 0)
            {
                istrue = true;

            }
            else
            {
                istrue = false;
            }
            chkgrdAuth09++;


            전체체크(e.ColumnIndex, sender as DataGridView, istrue);
        }
        int chkgrdAuth10 = 0;

        private void grdAuth10_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            bool istrue = true;
            if (chkgrdAuth10 % 2 == 0)
            {
                istrue = true;

            }
            else
            {
                istrue = false;
            }
            chkgrdAuth10++;


            전체체크(e.ColumnIndex, sender as DataGridView, istrue);
        }
        int chkgrdAuth11 = 0;

        private void grdAuth11_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            bool istrue = true;
            if (chkgrdAuth11 % 2 == 0)
            {
                istrue = true;

            }
            else
            {
                istrue = false;
            }
            chkgrdAuth11++;


            전체체크(e.ColumnIndex, sender as DataGridView, istrue);
        }
        int chkgrdAuth12 = 0;

        private void grdAuth12_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            bool istrue = true;
            if (chkgrdAuth12 % 2 == 0)
            {
                istrue = true;

            }
            else
            {
                istrue = false;
            }
            chkgrdAuth12++;


            전체체크(e.ColumnIndex, sender as DataGridView, istrue);
        }
        int chkgrdAuth13 = 0;

        private void grdAuth13_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            bool istrue = true;
            if (chkgrdAuth13 % 2 == 0)
            {
                istrue = true;

            }
            else
            {
                istrue = false;
            }
            chkgrdAuth13++;


            전체체크(e.ColumnIndex, sender as DataGridView, istrue);
        }
        int chkgrdAuth14 = 0;

        private void grdAuth14_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            bool istrue = true;
            if (chkgrdAuth14 % 2 == 0)
            {
                istrue = true;

            }
            else
            {
                istrue = false;
            }
            chkgrdAuth14++;


            전체체크(e.ColumnIndex, sender as DataGridView, istrue);
        }
        #endregion
        int chkbtn전체체크3 = 0;
        private void btn전체체크3_Click(object sender, EventArgs e)
        {
            bool istrue = true;
            if (chkbtn전체체크3 % 2 == 0)
            {
                istrue = true;

            }
            else
            {
                istrue = false;
            }
            chkbtn전체체크3++;

            chk_auth03.Checked = istrue;
            foreach (DataGridViewRow row in grdAuth03.Rows)
            {
                row.Cells["chk"].Value = istrue;
                row.Cells["chk1"].Value = istrue;
                row.Cells["chk2"].Value = istrue;
            }
        }
        int chkbtn전체체크4 = 0;
        private void btn전체체크4_Click(object sender, EventArgs e)
        {
            bool istrue = true;
            if (chkbtn전체체크4 % 2 == 0)
            {
                istrue = true;

            }
            else
            {
                istrue = false;
            }
            chkbtn전체체크4++;

            chk_auth04.Checked = istrue;
            foreach (DataGridViewRow row in grdAuth04.Rows)
            {
                row.Cells["chk"].Value = istrue;
                row.Cells["chk1"].Value = istrue;
                row.Cells["chk2"].Value = istrue;
            }
        }
        int chkbtn전체체크5 = 0;
        private void btn전체체크5_Click(object sender, EventArgs e)
        {
            bool istrue = true;
            if (chkbtn전체체크5 % 2 == 0)
            {
                istrue = true;

            }
            else
            {
                istrue = false;
            }
            chkbtn전체체크5++;

            chk_auth05.Checked = istrue;
            foreach (DataGridViewRow row in grdAuth05.Rows)
            {
                row.Cells["chk"].Value = istrue;
                row.Cells["chk1"].Value = istrue;
                row.Cells["chk2"].Value = istrue;
            }
        }
        int chkbtn전체체크6 = 0;
        private void btn전체체크6_Click(object sender, EventArgs e)
        {
            bool istrue = true;
            if (chkbtn전체체크6 % 2 == 0)
            {
                istrue = true;

            }
            else
            {
                istrue = false;
            }
            chkbtn전체체크6++;

            chk_auth06.Checked = istrue;
            foreach (DataGridViewRow row in grdAuth06.Rows)
            {
                row.Cells["chk"].Value = istrue;
                row.Cells["chk1"].Value = istrue;
                row.Cells["chk2"].Value = istrue;
            }
        }
        int chkbtn전체체크7 = 0;

        private void btn전체체크7_Click(object sender, EventArgs e)
        {
            bool istrue = true;
            if (chkbtn전체체크7 % 2 == 0)
            {
                istrue = true;

            }
            else
            {
                istrue = false;
            }
            chkbtn전체체크7++;

            chk_auth07.Checked = istrue;
            foreach (DataGridViewRow row in grdAuth07.Rows)
            {
                row.Cells["chk"].Value = istrue;
                row.Cells["chk1"].Value = istrue;
                row.Cells["chk2"].Value = istrue;
            }
        }
        int chkbtn전체체크8 = 0;

        private void btn전체체크8_Click(object sender, EventArgs e)
        {
            bool istrue = true;
            if (chkbtn전체체크8 % 2 == 0)
            {
                istrue = true;

            }
            else
            {
                istrue = false;
            }
            chkbtn전체체크8++;

            chk_auth08.Checked = istrue;
            foreach (DataGridViewRow row in grdAuth08.Rows)
            {
                row.Cells["chk"].Value = istrue;
                row.Cells["chk1"].Value = istrue;
                row.Cells["chk2"].Value = istrue;
            }
        }
        int chkbtn전체체크9 = 0;

        private void btn전체체크9_Click(object sender, EventArgs e)
        {
            bool istrue = true;
            if (chkbtn전체체크9 % 2 == 0)
            {
                istrue = true;

            }
            else
            {
                istrue = false;
            }
            chkbtn전체체크9++;

            chk_auth09.Checked = istrue;
            foreach (DataGridViewRow row in grdAuth09.Rows)
            {
                row.Cells["chk"].Value = istrue;
                row.Cells["chk1"].Value = istrue;
                row.Cells["chk2"].Value = istrue;
            }
        }
        int chkbtn전체체크10 = 0;

        private void btn전체체크10_Click(object sender, EventArgs e)
        {
            bool istrue = true;
            if (chkbtn전체체크10 % 2 == 0)
            {
                istrue = true;

            }
            else
            {
                istrue = false;
            }
            chkbtn전체체크10++;

            chk_auth10.Checked = istrue;
            foreach (DataGridViewRow row in grdAuth10.Rows)
            {
                row.Cells["chk"].Value = istrue;
                row.Cells["chk1"].Value = istrue;
                row.Cells["chk2"].Value = istrue;
            }
        }
        int chkbtn전체체크11 = 0;

        private void btn전체체크11_Click(object sender, EventArgs e)
        {
            bool istrue = true;
            if (chkbtn전체체크11 % 2 == 0)
            {
                istrue = true;

            }
            else
            {
                istrue = false;
            }
            chkbtn전체체크11++;

            chk_auth11.Checked = istrue;
            foreach (DataGridViewRow row in grdAuth11.Rows)
            {
                row.Cells["chk"].Value = istrue;
                row.Cells["chk1"].Value = istrue;
                row.Cells["chk2"].Value = istrue;
            }
        }
        int chkbtn전체체크12 = 0;

        private void btn전체체크12_Click(object sender, EventArgs e)
        {
            bool istrue = true;
            if (chkbtn전체체크12 % 2 == 0)
            {
                istrue = true;

            }
            else
            {
                istrue = false;
            }
            chkbtn전체체크12++;

            chk_auth12.Checked = istrue;
            foreach (DataGridViewRow row in grdAuth12.Rows)
            {
                row.Cells["chk"].Value = istrue;
                row.Cells["chk1"].Value = istrue;
                row.Cells["chk2"].Value = istrue;
            }
        }
        int chkbtn전체체크13 = 0;

        private void btn전체체크13_Click(object sender, EventArgs e)
        {
            bool istrue = true;
            if (chkbtn전체체크13 % 2 == 0)
            {
                istrue = true;

            }
            else
            {
                istrue = false;
            }
            chkbtn전체체크13++;

            chk_auth13.Checked = istrue;
            foreach (DataGridViewRow row in grdAuth13.Rows)
            {
                row.Cells["chk"].Value = istrue;
                row.Cells["chk1"].Value = istrue;
                row.Cells["chk2"].Value = istrue;
            }
        }
        int chkbtn전체체크14 = 0;
        private void btn전체체크14_Click(object sender, EventArgs e)
        {
            bool istrue = true;
            if (chkbtn전체체크14 % 2 == 0)
            {
                istrue = true;

            }
            else
            {
                istrue = false;
            }
            chkbtn전체체크14++;

            chk_auth14.Checked = istrue;
            foreach (DataGridViewRow row in grdAuth14.Rows)
            {
                row.Cells["chk"].Value = istrue;
                row.Cells["chk1"].Value = istrue;
                row.Cells["chk2"].Value = istrue;
            }
        }

        private void frm권한관리_Activated(object sender, EventArgs e)
        {
            
        }

        private void frm권한관리_Enter(object sender, EventArgs e)
        {
           
        }

        private void btn사원조회_Click(object sender, EventArgs e)
        {
           // dataUserGrid.Visible = !dataUserGrid.Visible;
            Popup.pop사원검색 pop사원검색 = new Popup.pop사원검색();
            pop사원검색.ShowDialog();
            txt_user_cd.Text = pop사원검색.str사원코드;
            txt_join_date.Text = pop사원검색.str직위명;
            txt_dept_nm.Text = pop사원검색.str부서명;
            txt_auth_set.Text = pop사원검색.str권한;
            txt_user_nm.Text = pop사원검색.str아이디;
            txt_user.Text = pop사원검색.str사원명;
            authLogic("2");


            //txt_auth_set.Text = dataUserGrid.Rows[e.RowIndex].Cells["AUTH_SET"].Value.ToString();


            //Application.DoEvents();


            //txt_user_cd.Text = dataUserGrid.Rows[e.RowIndex].Cells["dgvUser_cd"].Value.ToString();
            //txt_user_nm.Text = dataUserGrid.Rows[e.RowIndex].Cells["ID"].Value.ToString();
            //txt_user.Text = dataUserGrid.Rows[e.RowIndex].Cells["dgvUser_nm"].Value.ToString();
            //txt_dept_nm.Text = dataUserGrid.Rows[e.RowIndex].Cells["dgvUser_dept"].Value.ToString();
            //txt_join_date.Text = dataUserGrid.Rows[e.RowIndex].Cells["dgvUser_pos"].Value.ToString();
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
                        btnSave.PerformClick();
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


      

    }
}
