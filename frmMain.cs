using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MES.CLS;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Drawing2D;

namespace MES
{
    public partial class frmMain : Form, IfrmInterface
    {
        private Point mousePoint;
        //private int nWidth = 1380;
        //private int nHeight = 801;
        private int nWidth = 1600;
        private int nHeight = 900;
        private Form savForm = null;
        private Form savBack = null;
        private Form savManager = null;
        private bool bManager = false;
        private wnGConstant wConst = new wnGConstant();
        private bool bDBcheck = true;
        public List<string> tabStack = new List<string>();
        private Color COLOR_FONT = Color.WhiteSmoke;
        private Color COLOR_BACK = Colors.COLOR_MAIN_BLUE;
        wnDm wndm = new wnDm();


        Popup.pop공지사항 p_notece;
       
        public frmMain()
        {

          
			
            InitializeComponent();
            if (Common.p_tablet)
            {
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

                lblUserName.Visible = false;

            }

 
        }





        private void frmMain_Load(object sender, EventArgs e)
        {
            Debug.WriteLine(System.Windows.Forms.SystemInformation.VirtualScreen.Width +"///"+ System.Windows.Forms.SystemInformation.VirtualScreen.Height);
            pnl_treeView.Dock = DockStyle.Left;

            //btn_open_treeView.Top = this.Height / 2;

          
            Debug.WriteLine(Common.p_tablet+"tablet");

            dt_메뉴바.Columns.Add(new DataColumn("SubName", typeof(string)));
            dt_메뉴바.Columns.Add(new DataColumn("AsmName", typeof(string)));
            //솔빈 
            try
            {  //포용이면 게시 버전 
                this.Text = Application.ProductName + "-"+Common.p_strCompNm + "(" + Common.p_strUserName + ")ver." + System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
            }
            catch (System.Deployment.Application.DeploymentException ex)
            {
            //배포가 아니면  어셈블리버전

                this.Text = Application.ProductName + "-"+Common.p_strCompNm + "(" + Common.p_strUserName + ")ver." + Assembly.GetExecutingAssembly().GetName().Version.ToString();

            }
            catch
            {  
                this.Text = Application.ProductName +"ver.TEST";
            }

            pnl열린창탭.AutoScroll = false;
            pnl열린창탭.HorizontalScroll.Maximum = 0;
            pnl열린창탭.HorizontalScroll.Visible = false;
            pnl열린창탭.VerticalScroll.Maximum = 0;
            pnl열린창탭.VerticalScroll.Visible = false;
            pnl열린창탭.AutoScroll = true;
           
            toolMenu.Visible = false;
            toolMenu.Items.Clear();

            this.Width = nWidth + 1;
            this.Height = nHeight + 1;
            this.Top = 1;
            this.Left = 1;

            
            init_FrameBorder();  // 반드시 최우선으로 실행.
              
            show_MainScreen();

            lblUserName.Text = "";
            lblCompName.Text = "";

            //string sVersion = getAppVer();
            //this.Text = this.Text + " ver " + sVersion;

            tmDelFile.Enabled = true;
            tmLogin.Enabled = true;
            dt_메뉴바.Rows.Add("메뉴검색","");

            DataTable dt_submenu_cnt=wndm.fn_SubMenu_count();

           int submenu_cnt=int.Parse(dt_submenu_cnt.Rows[0]["cnt"].ToString());


           llbl = new Button[submenu_cnt];
           picLogo.BackColor = Color.Transparent;
           DataTable dt = new wnDm().logoImage();
           if (dt != null)
           {
               if (dt.Rows.Count > 0)
               {
                   if (dt.Rows[0]["SAUP_LOGO"] != null && dt.Rows[0]["SAUP_LOGO"].ToString() != "")
                   {
                       byte[] rs = (byte[])dt.Rows[0]["SAUP_LOGO"];
                       MemoryStream ms = new MemoryStream(rs);
                       Image img = Image.FromStream(ms);
                       picLogo.BackgroundImage = img;
                       picLogo.BackgroundImageLayout = ImageLayout.Zoom;
                       picLogo.Image = null;
                       picLogo.BackColor = Color.White;
                   }
               }
           }




           //p_notece = new Popup.pop공지사항();
           //if (p_notece.dt != null)
           //    if (p_notece.dt.Rows.Count > 0)
           //        p_notece.ShowDialog();





        }



        public void noteOpen()
        {
            //p_notece = new Popup.pop공지사항();
            //p_notece.Show();
        }

        //private string getAppVer()
        //{
        //    string sRet = "";
        //    try
        //    {
        //        FileStream fs = new FileStream("check_update.ini", FileMode.Open, FileAccess.Read, FileShare.Read);
        //        StreamReader sr = new StreamReader(fs);

        //        string sTxt = "";
        //        sTxt = sr.ReadLine();
        //        sRet = sTxt.Replace("\r", "").Replace("\n", "");

        //        sr.Close();
        //        fs.Close();
        //    }
        //    catch
        //    {
        //    }
        //    return sRet;
        //}

        private void init_FrameBorder()
        {
            //panBackLeft.SetBounds(0, panTopBorder.Height + panMenu.Height + 2, 4, this.Height);
            //panBackRight.SetBounds(this.Width - 20, panTopBorder.Height + panMenu.Height + 2, 20, this.Height);
            //panBackBottom.SetBounds(0, this.Height - 44, 2000, 20);

            panTopBorder.Height = Screen.PrimaryScreen.Bounds.Height / 12;
            //picLogo.Height = panTopBorder.Height / 2; ;

            if (!Common.p_tablet)
            {
                panBackTop.SetBounds(0, panTopBorder.Height - 7, panTopBorder.Width + 100, 10);
                panBackLeft.SetBounds(0, panTopBorder.Height + 2, 4, this.Height);
                panBackRight.SetBounds(this.Width - 20, panTopBorder.Height + 2, 20, this.Height);
                panBackBottom.SetBounds(0, this.Height - 45, panTopBorder.Width + 100, 20);
            }
            else
            {
                panBackTop.Visible=false;

                    panBackLeft.Visible=false;
                    panBackRight.Visible=false;
                    panBackBottom.Visible = false;

            }
       
        }

        private void show_MainScreen()
        {
            int nW = this.ClientSize.Width - 5;
            //int nH = this.ClientSize.Height - panTopBorder.Height - panMenu.Height - 7;
            int nH = this.ClientSize.Height - panTopBorder.Height - 7;

            frmBack frm = new frmBack(this as IfrmInterface);

            frm.MdiParent = this;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.SetBounds(0, 0, nW, nH);
            frm.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;  //솔빈추가ㅓ
            frm.Show();

            savBack = frm;
        }

        private void tmLogin_Tick(object sender, EventArgs e)
        {

            
           


            tmLogin.Enabled = false;

            ////bool bDBcheck = Check_DBConnection();
            show_FormCheck();
            if (bDBcheck != true)
            {
                MessageBox.Show("DB 연결에 문제가 있습니다." + "\r\n" + "또는, 사용자 컴퓨터의 인터넷 연결을 확인하세요.");
                this.Close();
            }

            //show_FormLogin();

            //// 로그인시...
            //// 상황에 따른 연결자 변경
            //Common.p_strConn = Common.p_strConnMain;

            get_Menu_Info();
            //get_Comp_Info();

            lblUserName.Text = Common.p_strUserName+"  " +Common.p_strCompNm;
            
            //if (Common.p_strUserAdmin == "Y")
            //{
            //    tsSystem.Visible = true;
            //}

            if (Common.p_strRoot == "Y")
            {
                butSetting.Visible = true;
            }
        }

        public void get_Menu_Info()
        {
            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = null;

                if (Common.p_strUserAdmin.Equals("5")) //권한통제자는 무조건 모든 메뉴 보여줌
                {
                    dt = wDm.fn_TopMenu_List();
                    
                }
                else 
                {
                    dt = wDm.fn_TopMenu_Auth_List();
                }

                TreeNode BookMarkNode = new TreeNode("북마크", 0, 0);
                BookMarkNode.NodeFont = new Font("Noto Sans CJK KR Regular", 11, FontStyle.Bold);
                BookMarkNode.Tag = false;
                myTreeView.Nodes.Add(BookMarkNode);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int kk = 0; kk < dt.Rows.Count; kk++)
                    {
                        //이재원 treeview 추가 
                        TreeNode TopNode = new TreeNode(dt.Rows[kk]["TopName"].ToString(), 0, 0);
                        TopNode.Tag = false;
                        
                        TopNode.NodeFont = new Font("Noto Sans CJK KR Regular",11, FontStyle.Bold);

                        //

                        ToolStripDropDownButton top_01 = new ToolStripDropDownButton(dt.Rows[kk]["TopName"].ToString());
                        top_01.AutoSize = false;
                        top_01.BackColor = COLOR_BACK;
                        top_01.ForeColor = COLOR_FONT;
                        top_01.Font = new Font("경기천년제목V", 11, FontStyle.Bold);
                        top_01.BackgroundImageLayout = ImageLayout.None;
                        top_01.DisplayStyle = ToolStripItemDisplayStyle.Text;
                        top_01.ShowDropDownArrow = false;
                        top_01.Width = 80;
                        top_01.Height = panTopBorder.Height / 2;
                        top_01.MouseEnter += mainMenu_MouseEnter;
                        top_01.MouseLeave += mainMenu_MouseLeave;
                        toolMenu.Items.Add(top_01);
                        if (dt.Rows[kk]["TopName"].ToString().Length > 7)
                        {
                            top_01.Width = 105;

                        }
                        else if (dt.Rows[kk]["TopName"].ToString().Length > 6)
                        {

                            top_01.Width = 95;
                        }
                        else if (dt.Rows[kk]["TopName"].ToString().Length > 5)
                        {

                            top_01.Width = 85;
                        }
                        
                        ToolStripSeparator mainSep = new ToolStripSeparator();
                        mainSep.AutoSize = false;
                        mainSep.Width = 6;
                        mainSep.Height = 10;
                        toolMenu.Items.Add(mainSep);

                        // Sub Menu 붙이기
                        get_SubMenu_Info(dt.Rows[kk]["TopID"].ToString(), top_01, TopNode, BookMarkNode);
                    }
                    //myTreeView.CheckBoxes = true;
                    //myTreeView.ExpandAll();
                }
                
            }
            catch (Exception ex){
wnLog.writeLog(wnLog.LOG_ERROR, ex.Message + " - " + ex.ToString());Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                msg.ShowDialog();
            }

            tsOpenWin = new ToolStripDropDownButton("열린창");
            tsOpenWin.AutoSize = false;
            tsOpenWin.BackColor = COLOR_BACK;
            tsOpenWin.ForeColor = COLOR_FONT;
            tsOpenWin.BackgroundImageLayout = ImageLayout.None;
            tsOpenWin.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tsOpenWin.ShowDropDownArrow = false;
            tsOpenWin.Width = 55;
            tsOpenWin.Height = 35;
            tsOpenWin.MouseEnter += mainMenu_MouseEnter;
            tsOpenWin.MouseLeave += mainMenu_MouseLeave;
         
            toolStrip1.Items.Add(tsOpenWin);

            toolMenu.Visible = true;

           // toolMenu.Refresh(); // 열린창도 실시간 갱신 원하는 경우 주석제거
           

            ///메뉴검색기능바인딩
            ///
            if (dt_메뉴바.Rows.Count > 0)
            {
                cbo메뉴바.DataSource = wndm.fn_SubMenu_List가나다순();
                cbo메뉴바.DisplayMember = "SubName";
                cbo메뉴바.ValueMember = "AsmName";
            }

            //STORAGE_CD.ValueMember = "코드";
            //STORAGE_CD.DisplayMember = "명칭";
            //sqlQuery = comInfo.queryStorage();
            //wConst.ComboBox_Read_Blank(STORAGE_CD, sqlQuery);
        }

        void top_TreeViewOpen_Click(object sender, EventArgs e)
        {
            pnl_treeView.Visible = true;
        }

        public void get_SubMenu_Info(string sTopID, ToolStripDropDownButton top_Menu, TreeNode top_tree, TreeNode BookMarkNode)
        {
            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = null;

                if (Common.p_strUserAdmin.Equals("5"))
                {
                    dt = wDm.fn_SubMenu_List(sTopID);
                }
                else 
                {
                    dt = wDm.fn_SubMenu_Auth_List(sTopID);
                
                }

                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int kk = 0; kk < dt.Rows.Count; kk++)
                    {
                        ToolStripMenuItem subMenu = new ToolStripMenuItem(dt.Rows[kk]["SubName"].ToString());
                        subMenu.Tag =dt.Rows[kk]["AsmName"].ToString();
                        Debug.WriteLine(subMenu.Tag);
                        subMenu.Font = new Font("경기천년제목V", 10, FontStyle.Regular);
                        subMenu.Click += mainMemu_Click;
                        top_Menu.DropDownItems.Add(subMenu);
                        dr_메뉴바 = dt_메뉴바.NewRow();
                        dr_메뉴바["SubName"]=dt.Rows[kk]["SubName"].ToString();
                        dr_메뉴바["AsmName"] = dt.Rows[kk]["AsmName"].ToString();
                        dt_메뉴바.Rows.Add(dr_메뉴바);
                        Debug.WriteLine("확인~" + dt_메뉴바.Rows[kk]["SubName"].ToString());
                        Debug.WriteLine("확인~" + dt_메뉴바.Rows[kk]["AsmName"].ToString());
                        top_tree.Nodes.Add(dt.Rows[kk]["AsmName"].ToString(), dt.Rows[kk]["SubName"].ToString(), 0, 0);
                        top_tree.Nodes[top_tree.Nodes.Count - 1].NodeFont = new Font("Noto Sans CJK KR Regular", 11, FontStyle.Regular);
                        top_tree.Nodes[top_tree.Nodes.Count - 1].Tag = false;


                        if (dt.Rows[kk]["BOOKMARK"].ToString().Equals("Y"))
                        {
                            top_tree.Nodes[top_tree.Nodes.Count - 1].Tag = true;
                            BookMarkNode.Nodes.Add(dt.Rows[kk]["AsmName"].ToString(), dt.Rows[kk]["SubName"].ToString(), 0, 0);
                            BookMarkNode.Nodes[BookMarkNode.Nodes.Count - 1].NodeFont = new Font("Noto Sans CJK KR Regular", 11, FontStyle.Regular);
                        }
                    }
                    myTreeView.Nodes.Add(top_tree);
                }      
            }
            catch (Exception ex){
wnLog.writeLog(wnLog.LOG_ERROR, ex.Message + " - " + ex.ToString());Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                msg.ShowDialog();
            }
        }

        public void get_Comp_Info()
        {
            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = null;
                dt = wDm.fn_업체정보_Detail(Common.p_strConn);

                if (dt != null && dt.Rows.Count > 0)
                {
                    this.Text = this.Text + " - " + dt.Rows[0]["상호명"].ToString();
                    lbl업체명.Text = dt.Rows[0]["상호명"].ToString();
                }
            }
            catch (Exception ex){
wnLog.writeLog(wnLog.LOG_ERROR, ex.Message + " - " + ex.ToString());Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                msg.ShowDialog();
            }
        }

        //public bool Check_DBConnection()
        //{
        //    try
        //    {
        //        using (SqlConnection dbConn = new SqlConnection())
        //        {
        //            dbConn.ConnectionString = Common.p_strConnMain;
        //            dbConn.Open();
        //            dbConn.Close();
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        return false;
        //    }
        //    return true;
        //}

        private void show_FormCheck()
        {
            frmCheck frm = new frmCheck();

            frm.ShowDialog();
            bDBcheck = frm.bRet;

            frm.Dispose();
            frm = null;
        }

        private void show_FormLogin()
        {
            bool bLogin = false;

            frmLogin frm = new frmLogin();

            frm.ShowDialog();
            bLogin = frm.bRet;

            frm.Dispose();
            frm = null;

            if (bLogin == false)
            {
                this.Close();
            }
        }
        
        private void frmMain_Resize(object sender, EventArgs e)
        {
            if (this.Width < nWidth)
            {
                this.Width = nWidth;
                return;
            }
            if (this.Height < nHeight)
            {
                this.Height = nHeight;
                return;
            }

            
             init_FrameBorder();

            
                

            int nW = this.ClientSize.Width - 5;
            //int nH = this.ClientSize.Height - panTopBorder.Height - panMenu.Height - 7;
            int nH = this.ClientSize.Height - panTopBorder.Height - 7;

            foreach (Form frm in this.MdiChildren)
            {
                frm.Width = nW;
                frm.Height = nH;
            }

            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            //this.WindowState = FormWindowState.Maximized;

            if (230 > this.Size.Width - toolMenu.Size.Width)
            {
                Debug.WriteLine(this.Size.ToString());
                //toolStripDropDownButton2
                Debug.WriteLine(toolMenu.Size.ToString());
                
            }
            else
            {
              

            }
        }


        int Wchk = Screen.PrimaryScreen.Bounds.Width;
        int Hchk = Screen.PrimaryScreen.Bounds.Height;


        private void mainMemu_Click(object sender, EventArgs e)
        {
            string sFrmName = ((ToolStripMenuItem)sender).Tag.ToString();
            string sMnuName = ((ToolStripMenuItem)sender).Text.ToString();

            if (sMnuName == "frm작업지시서_모니터링")
            {
                this.WindowState = Maximized;
            }


         

         

            sub_Form(sFrmName, sMnuName);
            Debug.WriteLine(sFrmName + "///" + sMnuName);
            sub_Form(sFrmName, sMnuName);
            Debug.WriteLine(sFrmName + "///" + sMnuName);


        }
        public DataTable dt_메뉴바 = new DataTable();
        DataRow dr_메뉴바 = null;
    
        public void sub_Form(string sFrmName, string sMemuName)
        {
            // frmBack frm = new frmBack(this as IfrmInterface);

            //자주사용한 메뉴 추가위한 로그 찍기 

            try
            {
                wnDm wDm = new wnDm();
                int rsNum = wDm.insert_menu_click_log(sFrmName);
            }
            catch (Exception ex2){}

            Cursor.Current = Cursors.WaitCursor;
            sFrmName = Regex.Replace(sFrmName, " ", "");
            Assembly ExAss = Assembly.GetExecutingAssembly();

            Form frmCall = (Form)ExAss.CreateInstance(string.Concat(ExAss.GetName().Name, ".", sFrmName));
            if (frmCall != null)
            {
                //foreach (ToolStripMenuItem sub in tsOpenWin.DropDownItems)
                //{
                //    //sub.BackColor = Color.White;
                //    //sub.ForeColor = Color.RoyalBlue;
                //}

                bool bExistFrm = false;
                foreach (Form frm in this.MdiChildren)
                {
                    if (frm.Name != "frmBack" && frm.Name != "frmBackRoot")
                    {
                        if (frm.Name == frmCall.Name)
                        {
                            bExistFrm = true;
                            frm.Activate();
                            foreach (ToolStripMenuItem sub in tsOpenWin.DropDownItems)
                            {
                                string sSubName = "";
                                if (sub.Tag.ToString().LastIndexOf('.') > 0)
                                {
                                    sSubName = sub.Tag.ToString().Substring(sub.Tag.ToString().LastIndexOf('.') + 1);
                                }
                                else
                                {
                                    sSubName = sub.Tag.ToString();
                                }
                                if (sSubName == frmCall.Name)
                                {
                                    //sub.BackColor = SystemColors.MenuHighlight;
                                    //sub.ForeColor = Color.Yellow;
                                    break;
                                }
                            }

                            for(int i = 0 ; i < pnl열린창탭.Controls.Count; i ++)
                            {
                                if (pnl열린창탭.Controls[i].Tag.ToString().Equals(sFrmName))
                                {
                                    tabStack.Remove(sFrmName);
                                    tabStack.Add(sFrmName);
                                    foreach (Control ctrl in pnl열린창탭.Controls)
                                    {
                                        if (ctrl.GetType().ToString() == "System.Windows.Forms.Button")
                                        {
                                            ctrl.BackColor = Color.LightGray;
                                            ctrl.Controls[0].BackColor = Color.LightGray;
                                            Button btnTemp = (Button)ctrl.Controls[0];
                                            btnTemp.FlatAppearance.MouseOverBackColor = Color.LightGray;
                                        }
                                    }
                                    pnl열린창탭.Controls[i].BackColor = Color.WhiteSmoke;
                                    pnl열린창탭.Controls[i].Controls[0].BackColor = Color.WhiteSmoke;
                                    Button btnTemp2 = (Button)pnl열린창탭.Controls[i].Controls[0];
                                    btnTemp2.FlatAppearance.MouseOverBackColor = Color.WhiteSmoke;
                                    break;
                                }
                            }
                            break;
                        }
                    }
                }

                if (bExistFrm == false)
                {
                    int nW = this.ClientSize.Width - 5;
                    //int nH = this.ClientSize.Height - panTopBorder.Height - panMenu.Height - 7;
                    int nH = this.ClientSize.Height - panTopBorder.Height - 7;

                    frmCall.MdiParent = this;
                    frmCall.FormBorderStyle = FormBorderStyle.None;
                    frmCall.SetBounds(0, 0, nW, nH);
                    frmCall.FormClosed += new FormClosedEventHandler(ChildFormClosed);
                    frmCall.Tag = sFrmName;
                    frmCall.Show();

                    ToolStripMenuItem sub = new ToolStripMenuItem();
                    sub.Text = sMemuName;
                    sub.Tag = sFrmName;
                    //sub.BackColor = SystemColors.MenuHighlight;
                    //sub.ForeColor = Color.Yellow;
                    sub.Click += mainMemu_Click;
                    tsOpenWin.DropDownItems.Add(sub);

                    lstChild.Items.Add(sMemuName);
                    lstChild2.Items.Add(sFrmName);
                    lstChild_del.Items.Add("0");

                    foreach (var item in lstChild.Items)
                    {
                        Debug.WriteLine("open form: " + item.ToString());
                        
                    }
                    Debug.WriteLine(lstChild.Items.Count);


                    열린창탭추가(sMemuName,sFrmName);
                }
            }

            ExAss = null;

            Cursor.Current = Cursors.Arrow;
        }


        private void 열린창탭추가(string sMemuName,string sFrmName )
        {
            Button llbl_1 = new Button();

            //   llbl_1.Location = new Point(30+110*(lstChild.Items.Count-1), 48);
            //pnl열린창탭.Height = panTopBorder.Height / 3;
            //pnl열린창탭.HorizontalScroll.Visible = false;

            //cbo메뉴바.Height = panTopBorder.Height / 3;
            Button exit = new Button();
            pnl열린창탭.Controls.Add(llbl_1);
            llbl_1.Text = sMemuName;
            llbl_1.Tag = sFrmName;
            llbl_1.Font = new Font("경기천년제목V", 10, FontStyle.Bold);
            llbl_1.Margin = new Padding(0);
            llbl_1.Padding = new Padding(0);
            llbl_1.AutoSize = false;
            llbl_1.Width = 180;
            llbl_1.Height = pnl열린창탭.Height;
            //  llbl_1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Left)));
            llbl_1.FlatStyle = FlatStyle.Flat;
            llbl_1.FlatAppearance.BorderSize = 0;
            llbl_1.BackColor = Color.WhiteSmoke;
            llbl_1.ForeColor = Color.FromArgb(40,40,40) ;
            llbl_1.Padding = new Padding(5, 0, 25, 0);
            llbl_1.TextAlign = ContentAlignment.MiddleLeft;
            llbl_1.FlatAppearance.BorderColor = Color.WhiteSmoke;
            llbl[lstChild.Items.Count - 1] = llbl_1;
            llbl_1.Click += linkclicekd;


            llbl_1.Controls.Add(exit);
            exit.Text = "X";
            exit.Tag = sFrmName;
            exit.Font = new Font("경기천년제목V", 7, FontStyle.Bold);
            exit.Margin = new Padding(0);
            exit.Padding = new Padding(0);
            exit.FlatStyle = FlatStyle.Flat;
            exit.ForeColor = Color.FromArgb(80,80,80);
            exit.FlatAppearance.MouseOverBackColor = Color.WhiteSmoke;
            exit.BackColor = Color.WhiteSmoke;
            exit.FlatAppearance.BorderSize = 0;
            exit.FlatAppearance.BorderColor = Color.WhiteSmoke;
            exit.Height = pnl열린창탭.Height-10;
            exit.Width = 20;
            exit.Dock = DockStyle.Right;

            exit.Click += exit_Click;

            //exit.Margin = new Padding(-5,-5,-5,-5);
            //exit.Padding = new Padding(-2, -2, -2, -2);

            tabStack.Add(llbl_1.Tag.ToString());

            foreach (Control ctrl in pnl열린창탭.Controls)
            {
                if (ctrl.GetType().ToString() == "System.Windows.Forms.Button")
                {
                    ctrl.BackColor = Color.LightGray;
                    ctrl.Controls[0].BackColor = Color.LightGray;
                    Button btnTemp = (Button)ctrl.Controls[0];
                    btnTemp.FlatAppearance.MouseOverBackColor = Color.LightGray;
                }
            }

            llbl_1.Controls[0].BackColor = Color.WhiteSmoke;
            llbl_1.BackColor = Color.WhiteSmoke;
            Button btnTemp2 = (Button)llbl_1.Controls[0];
            btnTemp2.FlatAppearance.MouseOverBackColor = Color.WhiteSmoke;

        }

        void exit_Click(object sender, EventArgs e)
        {
            Button btnTemp = (Button)sender;
            string frmNameTemp = btnTemp.Tag.ToString();
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name != "frmBack" && frm.Name != "frmBackRoot")
                {
                    if (frm.Tag.ToString().Equals(frmNameTemp))
                    {
                        frm.Close();
                        break;
                    }
                }
            }
        }

        

        

        //private void 열린창탭초기화()
        //{
        //    pnl열린창탭.Controls.Clear();
        //    for (int i = 0; i < tsOpenWin.DropDownItems.Count; i++)
        //    {
        //        Button llbl_1 = new Button();
        //        pnl열린창탭.Controls.Add(llbl_1);
        //        llbl_1.Text = tsOpenWin.DropDownItems[i].Text;
        //        llbl_1.Tag = tsOpenWin.DropDownItems[i].Tag;
        //        llbl_1.Font = new Font("Verdana", 10, FontStyle.Bold);
        //        llbl_1.AutoSize = true;
        //        //  llbl_1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Left)));
        //        llbl_1.Dock = DockStyle.Left;
        //        llbl_1.FlatStyle = FlatStyle.Flat;
        //        llbl_1.BackColor = Color.White;
        //        llbl_1.FlatAppearance.BorderColor = Color.Gray;
        //        llbl[lstChild.Items.Count - 1] = llbl_1;
        //        llbl_1.Click += linkclicekd;
        //    }
        //}


        private void linkclicekd(object sender, EventArgs e)
        {
            Button clickedLink = sender as Button;
            sub_Form(clickedLink.Tag.ToString(), clickedLink.Text.ToString());

            for (int i = 0; i < tabStack.Count; i++)
            {
                if (tabStack[i].ToString().Equals(clickedLink.Tag.ToString()))
                {
                    tabStack.RemoveAt(i);
                }
            }
            tabStack.Add(clickedLink.Tag.ToString());

            foreach (Control ctrl in pnl열린창탭.Controls)
            {
                if (ctrl.GetType().ToString() == "System.Windows.Forms.Button")
                {
                    ctrl.BackColor = Color.LightGray;
                    ctrl.Controls[0].BackColor = Color.LightGray;
                    Button btnTemp = (Button)ctrl.Controls[0];
                    btnTemp.FlatAppearance.MouseOverBackColor = Color.LightGray;
                }
            }
            clickedLink.Controls[0].BackColor = Color.WhiteSmoke;
            clickedLink.BackColor = Color.WhiteSmoke;
            Button btnTemp2 = (Button)clickedLink.Controls[0];
            btnTemp2.FlatAppearance.MouseOverBackColor = Color.WhiteSmoke;
        }

        private ListBox lstChild = new ListBox();
        private ListBox lstChild2 = new ListBox();
        private ListBox lstChild_del = new ListBox();

        private Button[] llbl;
        ArrayList list열린창 = new ArrayList();
        private void ChildFormClosed(object sender, FormClosedEventArgs e)
        {
            Form f = (Form)sender;


            try
            {
                //for (int i = 0; i < pnl열린창탭.Controls.Count; i++)
                //{
                //    if (pnl열린창탭.Controls[i].Tag == f.Tag)
                //    {
                //        pnl열린창탭.Controls.RemoveAt(i);
                //    }
                //}
               
            }
            catch
            {
            }

            

            Debug.WriteLine("tag" + f.Tag.ToString());
            Debug.WriteLine("name" + f.Name.ToString());
            Debug.WriteLine("text" + f.Text.ToString());

           // 열린창탭초기화();
            열린창탭삭제(f.Tag.ToString());


            tsOpenWin.DropDownItems.Clear();
            
            Debug.WriteLine(lstChild.Items.Count);
            for (int kk = 0; kk < lstChild2.Items.Count; kk++)
            {
                if (lstChild2.Items[kk].ToString() == f.Tag.ToString())
                {
                    lstChild_del.Items[kk] = "1";
                }
                else
                {
                    ToolStripMenuItem sub = new ToolStripMenuItem();
                    sub.Text = lstChild.Items[kk].ToString();
                    sub.Tag = lstChild2.Items[kk].ToString();
                    //sub.BackColor = Color.White;
                    //sub.ForeColor = Color.RoyalBlue;
                    sub.Click += mainMemu_Click;
                    tsOpenWin.DropDownItems.Add(sub);
                    list열린창.Add(sub.Text.ToString());
                  //  열린창탭추가(sub.Text.ToString(), sub.Tag.ToString());
                }
            }

            int nCnt = lstChild_del.Items.Count;
            for (int kk = 0; kk < nCnt; kk++)
            {
                if (lstChild_del.Items[nCnt - 1 - kk].ToString() == "1")
                {
                    foreach (var item in lstChild.Items)
                    {
                        Debug.WriteLine("open form: " + item.ToString());
                    }
                    try
                    {
                        list열린창.RemoveAt(nCnt - 1 - kk);
                        //pnl열린창탭.Controls.Remove(llbl[nCnt - 1 - kk]);
                        //llbl[nCnt - 1 - kk].Dispose();
                        lstChild.Items.RemoveAt(nCnt - 1 - kk); 
                        lstChild2.Items.RemoveAt(nCnt - 1 - kk); 
                        lstChild_del.Items.RemoveAt(nCnt - 1 - kk); 
                        //열린창탭삭제(list열린창[nCnt - 1 - kk].ToString());
                    }
                    catch
                    {
                    }
                    //MessageBox.Show(list열린창[nCnt - 1].ToString());
                }
            }

           
            tmSelected.Enabled = true;
        } 

        private void 열린창탭삭제(string sub)
        {

            string frmNameTemp = "";
            for (int i = 0; i < pnl열린창탭.Controls.Count; i++)
            {
                if (pnl열린창탭.Controls[i].BackColor == Color.WhiteSmoke)
                {
                    frmNameTemp = pnl열린창탭.Controls[i].Tag.ToString();
                    break;
                }
            }

            if (sub.ToString().Equals(frmNameTemp))
            {
                if (pnl열린창탭.Controls.Count > 0)
                {
                    for (int i = 0; i < pnl열린창탭.Controls.Count; i++)
                    {
                        if (pnl열린창탭.Controls[i].Tag.ToString().Equals(sub) && pnl열린창탭.Controls.Count > 1)
                        {
                            if (i == pnl열린창탭.Controls.Count - 1)
                            {
                                Button btnTemp = (Button)pnl열린창탭.Controls[i - 1];
                                btnTemp.PerformClick();
                            }
                            else
                            {
                                Button btnTemp = (Button)pnl열린창탭.Controls[i + 1];
                                btnTemp.PerformClick();
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < pnl열린창탭.Controls.Count; i++)
            {
                if ((string)pnl열린창탭.Controls[i].Tag == sub)
                {
                    pnl열린창탭.Controls.RemoveAt(i);
                    break;
                }
            }

            for (int i = 0; i < tabStack.Count; i++)
            {
                if (tabStack[i].ToString().Equals(sub))
                {
                    tabStack.RemoveAt(i);
                    break;
                }
            }

            

            //foreach (Control ctrl in pnl열린창탭.Controls)
            //{
            //    if (ctrl.GetType().ToString() == "System.Windows.Forms.Button")
            //    {
            //        ctrl.BackColor = Color.LightGray;
            //    }
            //}

            //for (int i = 0; i < pnl열린창탭.Controls.Count; i++)
            //{
            //    if (pnl열린창탭.Controls[i].Tag.ToString().Equals(tabStack[tabStack.Count - 1].ToString()))
            //    {
            //        pnl열린창탭.Controls[i].BackColor = Color.WhiteSmoke;
            //        break;
            //    }
            //}

            //MessageBox.Show(sub);
        }


        private void butSetting_Click(object sender, EventArgs e)
        {
            bool bChk = false;
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == "frmBackRoot")
                {
                    bChk = true;
                    frm.Activate();
                    break;
                }
            }
            if (bChk == false)
            {
                int nW = this.ClientSize.Width - 5;
                int nH = this.ClientSize.Height - panTopBorder.Height - 7;

                frmBackRoot frm = new frmBackRoot(this as IfrmInterface);

                frm.MdiParent = this;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.SetBounds(0, 0, nW, nH);
                frm.Show();
            }
        }

        private void butExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("프로그램을 종료 하시겠습니까?.", "스마트팩토리 종료", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
                this.Close();
            }
            else
            {
                return;
            }
          
        }

        private void picMain_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == "frmBack")
                {
                    frm.Activate();
                   
                    break;
                }
            }
        }

        private void tmSelected_Tick(object sender, EventArgs e)
        {
            tmSelected.Enabled = false;

            //foreach (ToolStripMenuItem sub in tsOpenWin.DropDownItems)
            //{
            //    if (this.ActiveMdiChild != null)
            //    {
            //        if (this.ActiveMdiChild.Tag != null)
            //        {
            //            if (sub.Tag.ToString() == this.ActiveMdiChild.Tag.ToString())
            //            {
            //                sub.BackColor = SystemColors.MenuHighlight;
            //                sub.ForeColor = Color.Yellow;
            //                break;
            //            }
            //        }
            //    }
            //}
        }

        private void lbl업체명_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == "frmBack")
                {
                    frm.Activate();
                    break;
                }
            }
        }

        private void mainMenu_MouseEnter(object sender, EventArgs e)
        {
            //ToolStripDropDownButton p = (ToolStripDropDownButton)sender;
            //if (p != null)
            //{
            //    p.ForeColor = Color.Yellow;
            //    p.DropDown.BackColor = Color.LightGreen;
            //    p.ShowDropDown();
            //}
        }

        private void mainMenu_MouseLeave(object sender, EventArgs e)
        {
            //ToolStripDropDownButton p = (ToolStripDropDownButton)sender;
            //if (p != null)
            //{
            //    p.ForeColor = Color.White;
            //}
        }

        private void tmDelFile_Tick(object sender, EventArgs e)
        {
            tmDelFile.Enabled = false;

            change_AutoUpdateFile();
        }

        private void change_AutoUpdateFile()
        {
            string p_strFolder = Path.GetDirectoryName(System.Environment.GetCommandLineArgs()[0]);

            if (File.Exists(p_strFolder + "\\" + "smartSales2r.exe") == true)
            {
                File.Delete(p_strFolder + "\\" + "smartSales2.exe");
                File.Move(p_strFolder + "\\" + "smartSales2r.exe", p_strFolder + "\\" + "smartSales2.exe");
            }
        }


        public FormWindowState Maximized { get; set; }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.UserClosing)
                return;

            if (MessageBox.Show("프로그램을 종료 하시겠습니까?.", "스마트팩토리 종료", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void panTopBorder_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblUserName_Click(object sender, EventArgs e)
        {

        }
        private Point mCurrentPosition = new Point(0, 0);

        private void panTopBorder_MouseMove(object sender, MouseEventArgs e)
        {
           



        }

        private void panTopBorder_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void panTopBorder_DragEnter(object sender, DragEventArgs e)
        {
          
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMini_Click(object sender, EventArgs e)
        {
           this.WindowState=FormWindowState.Minimized;
        }

        private void cbo메뉴바_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo메뉴바.SelectedIndex>0)
            {

            

                sub_Form(cbo메뉴바.SelectedValue.ToString(), cbo메뉴바.Text.ToString());
            }
        
        }

        private void cbo메뉴바_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //to do

            

                cbo메뉴바.SelectedIndex = cbo메뉴바.FindString(cbo메뉴바.Text.ToString());
            }

            else
            {
                return;
            } 
        }

        private void toolMenu_ItemAdded(object sender, ToolStripItemEventArgs e)
        {
       
                
        }

        private void cbo메뉴바_Click(object sender, EventArgs e)
        {
            cbo메뉴바.Select();
            cbo메뉴바.DroppedDown = true;
        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            Keys key = keyData & ~(Keys.Shift | Keys.Control);
            switch (key)
            {
                case Keys.W:
                    if ((keyData & Keys.Control) != 0)
                    {
                        bool isClosed = false;
                        string frmNameTemp = "";
                        for (int i = 0; i < pnl열린창탭.Controls.Count; i++)
                        {
                            if (pnl열린창탭.Controls[i].BackColor == Color.WhiteSmoke)
                            {
                                frmNameTemp = pnl열린창탭.Controls[i].Tag.ToString();
                                break;
                            }
                        }
                        foreach (Form frm in this.MdiChildren)
                        {
                            if (frm.Name != "frmBack" && frm.Name != "frmBackRoot")
                            {
                                if (frm.Tag.ToString().Equals(frmNameTemp))
                                {
                                    frm.Close();
                                    isClosed = true;
                                    break;
                                }
                            }
                        }
                        if (isClosed == false)
                        {
                            return base.ProcessCmdKey(ref msg, keyData);
                        }
                    }
                    else return base.ProcessCmdKey(ref msg, keyData);
                    break;
                case Keys.Left:
                    // 조합키 사용 시
                    if ((keyData & Keys.Control) != 0)
                    {
                        if (pnl열린창탭.Controls.Count > 0)
                        {
                            for (int i = 0; i < pnl열린창탭.Controls.Count; i++)
                            {
                                if (pnl열린창탭.Controls[i].Tag.ToString().Equals(tabStack[tabStack.Count - 1].ToString()))
                                {
                                    if (i == 0) break;
                                    else
                                    {
                                        Button btnTemp = (Button)pnl열린창탭.Controls[i - 1];
                                        btnTemp.PerformClick();
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        return base.ProcessCmdKey(ref msg, keyData);
                    }
                    break;
                case Keys.Right:
                    // 조합키 사용 시
                    if ((keyData & Keys.Control) != 0)
                    {
                        if (pnl열린창탭.Controls.Count > 0)
                        {
                            for (int i = 0; i < pnl열린창탭.Controls.Count; i++)
                            {
                                if (pnl열린창탭.Controls[i].Tag.ToString().Equals(tabStack[tabStack.Count - 1].ToString()))
                                {
                                    if (i == pnl열린창탭.Controls.Count-1) break;
                                    else
                                    {
                                        Button btnTemp = (Button)pnl열린창탭.Controls[i + 1];
                                        btnTemp.PerformClick();
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        return base.ProcessCmdKey(ref msg, keyData);
                    }
                    break;
                
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pnl_treeView.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pnl_treeView.Visible = false;
        }

        private void button1_DragDrop(object sender, DragEventArgs e)
        {
            MessageBox.Show("");
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            mousePoint = new Point(e.X, e.Y); //현재 마우스 좌표 저장
        }

        

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            //if ((e.Button & MouseButtons.Left) == MouseButtons.Left) //마우스 왼쪽 클릭 시에만 실행
            //{
            //    //폼의 위치를 드래그중인 마우스의 좌표로 이동 
            //    label1.Left = e.X + label1.Left - mousePoint.X;
            //    if (label1.Left > 200)
            //    {
            //        MessageBox.Show("over 200");
            //        label1.Left = 100;
            //    }
            //}
        }

        private void btn_open_treeView_MouseDown(object sender, MouseEventArgs e)
        {
            mousePoint = new Point(e.X, e.Y); //현재 마우스 좌표 저장
        }

        private void btn_open_treeView_MouseMove(object sender, MouseEventArgs e)
        {
            //if ((e.Button & MouseButtons.Left) == MouseButtons.Left) //마우스 왼쪽 클릭 시에만 실행
            //{
            //    //폼의 위치를 드래그중인 마우스의 좌표로 이동 
            //    btn_open_treeView.Left = e.X + btn_open_treeView.Left - mousePoint.X;

            //    if (btn_open_treeView.Left > 15)
            //    {
            //        btn_open_treeView.Left = -55;
            //        pnl_treeView.Visible = true;
            //        //btn_open_treeView.Visible = false;
            //    }

            //    if (btn_open_treeView.Left < -55)
            //    {
            //        btn_open_treeView.Left = -55;
            //    }
            //}
        }

        private void treeViewExit_Click(object sender, EventArgs e)
        {
            pnl_treeView.Visible = false;
            //btn_open_treeView.Visible = true;
        }

        private void myRoundButton1_Click(object sender, EventArgs e)
        {

        }

        private void frmMain_SizeChanged(object sender, EventArgs e)
        {
           // btn_open_treeView.Top = this.Height / 2;
        }

        private void myTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string nodeKey = e.Node.Name;
            if (!string.IsNullOrEmpty(nodeKey))
            {
                sub_Form(e.Node.Name,e.Node.Text );
            }
        }

        private void ChildNodeChecking(TreeNode selectNode) 
        { 
            foreach (TreeNode tn in selectNode.Nodes) 
            { 
                tn.Checked = selectNode.Checked; 
                ChildNodeChecking(tn);
                BookMarkNodeChecking(tn);
                BookMarkNodeChecking2(tn);
            } 
            return; 
        }


        public void ParentNodeChecking(TreeNode selectNode) 
        {
            TreeNode t = selectNode.Parent;
            if (t != null) 
            { 
                t.Checked = true; 
                foreach (TreeNode tn in t.Nodes) 
                { 
                    if (!tn.Checked) 
                    { 
                        t.Checked = false; 
                        break;
                    } 
                } 
                ParentNodeChecking(t);
            }
        }

        private void myTreeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            myTreeView.AfterCheck -= myTreeView_AfterCheck;
            e.Node.Tag = e.Node.Checked;
            ChildNodeChecking(e.Node); 
            ParentNodeChecking(e.Node);
            BookMarkNodeChecking(e.Node);
            BookMarkNodeChecking2(e.Node);
            myTreeView.AfterCheck += myTreeView_AfterCheck;
        }

        private void BookMarkNodeChecking(TreeNode selectNode)
        {
            for (int i = 0; i < myTreeView.Nodes[0].Nodes.Count; i++)
            {
                if (myTreeView.Nodes[0].Nodes[i].Name.ToString().Equals(selectNode.Name.ToString()))
                {
                    myTreeView.Nodes[0].Nodes[i].Checked = selectNode.Checked;
                }
            }
        }

        private void BookMarkNodeChecking2(TreeNode selectNode)
        {
            bool flag = false;
            for (int i = 0; i < myTreeView.Nodes[0].Nodes.Count; i++)
            {
                if (myTreeView.Nodes[0].Nodes[i].Name.ToString().Equals(selectNode.Name))
                {
                    flag = true;
                    break;
                }
            }

            if (!flag) return;

            for (int i = 1; i < myTreeView.Nodes.Count; i++)
            {
                for (int j = 0; j < myTreeView.Nodes[i].Nodes.Count; j++)
                {
                    if (myTreeView.Nodes[i].Nodes[j].Name.ToString().Equals(selectNode.Name.ToString()))
                    {
                        myTreeView.Nodes[i].Nodes[j].Tag = selectNode.Tag;
                        myTreeView.Nodes[i].Nodes[j].Checked = selectNode.Checked;
                        return;
                    }
                }
            }
        }

        private void btn_Bookmark_set_Click(object sender, EventArgs e)
        {
            if (btn_Bookmark_set.Text.ToString().Equals("북마크 설정"))
            {
                myTreeView.CheckBoxes = true;
                btn_Bookmark_set.Text = "저장";
                for (int i = 0; i < myTreeView.Nodes.Count; i++)
                {
                    for (int j = 0; j < myTreeView.Nodes[i].Nodes.Count; j++)
                    {
                        if (myTreeView.Nodes[i].Nodes[j].Tag != null && (bool)myTreeView.Nodes[i].Nodes[j].Tag == true)
                        {
                            myTreeView.Nodes[i].Nodes[j].Checked = true;
                            BookMarkNodeChecking(myTreeView.Nodes[i].Nodes[j]);
                        }
                    }
                }
            }
            else
            {
                try
                {
                    wnDm wDm = new wnDm();
                    int rsNum = wDm.fn_updateBookMark(myTreeView);
                    rePrint_BookMark();
                    myTreeView.CheckBoxes = false;

                }
                catch(Exception ex)
                {

                }
                //myTreeView.ExpandAll();
                btn_Bookmark_set.Text = "북마크 설정";

            }
        }

        private void rePrint_BookMark()
        {
            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = null;
                if (Common.p_strUserAdmin.Equals("5")) //권한통제자는 무조건 모든 메뉴 보여줌
                {
                    dt = wDm.selectBookMarkMenu_admin();

                }
                else
                {
                    dt = wDm.selectBookMarkMenu();
                }

                myTreeView.Nodes[0].Nodes.Clear();

                for (int k = 1; k < myTreeView.Nodes.Count; k++)
                {
                    for (int j = 0; j < myTreeView.Nodes[k].Nodes.Count; j++)
                    {
                        myTreeView.Nodes[k].Nodes[j].Checked = false;
                        myTreeView.Nodes[k].Nodes[j].Tag = false;
                    }
                }


                if (dt != null && dt.Rows.Count > 0)
                {
                    for(int i = 0 ; i < dt.Rows.Count ; i++)
                    {
                        myTreeView.Nodes[0].Nodes.Add(dt.Rows[i]["AsmName"].ToString(), dt.Rows[i]["SubName"].ToString(), 0, 0);
                        myTreeView.Nodes[0].Nodes[myTreeView.Nodes[0].Nodes.Count - 1].NodeFont = new Font("Noto Sans CJK KR Regular", 11, FontStyle.Regular);
                        myTreeView.Nodes[0].Nodes[myTreeView.Nodes[0].Nodes.Count - 1].Tag = true;

                        for (int k = 1; k < myTreeView.Nodes.Count; k++)
                        {
                            bool flag2 = false;
                            for (int j = 0; j < myTreeView.Nodes[k].Nodes.Count; j++)
                            {
                                if (myTreeView.Nodes[k].Nodes[j].Name.ToString().Equals(dt.Rows[i]["AsmName"].ToString()))
                                {
                                    myTreeView.Nodes[k].Nodes[j].Checked = true;
                                    myTreeView.Nodes[k].Nodes[j].Tag = true;
                                    flag2 = true;
                                    break;
                                }
                            }
                            if (flag2) break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                msg.ShowDialog();
            }
        }

        private void btn_open_treeView_MouseLeave(object sender, EventArgs e)
        {
            //btn_open_treeView.Left = -55;
        }

        private void btn_open_treeView_MouseUp(object sender, MouseEventArgs e)
        {
            //btn_open_treeView.Left = -55;
        }

        private void btn_open_treeView_Click(object sender, EventArgs e)
        {
            pnl_treeView.Visible = true;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (pnl_treeView.Visible)
            {
                pnl_treeView.Visible = false;
                button1.BackgroundImage = global::MES.Properties.Resources.btnSwitch_3x_off;
            }
            else
            {
                pnl_treeView.Visible = true;
                button1.BackgroundImage = global::MES.Properties.Resources.btnSwitch_3x_on;
            }
        }





    }
}
