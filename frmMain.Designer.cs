using MES.Controls;

namespace MES
{
    partial class frmMain
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.lbl업체명 = new System.Windows.Forms.Label();
            this.panBackRight = new System.Windows.Forms.Panel();
            this.panBackBottom = new System.Windows.Forms.Panel();
            this.panBackLeft = new System.Windows.Forms.Panel();
            this.tmLogin = new System.Windows.Forms.Timer(this.components);
            this.panMenu = new System.Windows.Forms.Panel();
            this.miniToolStrip = new System.Windows.Forms.ToolStrip();
            this.panBackTop = new System.Windows.Forms.Panel();
            this.tmSelected = new System.Windows.Forms.Timer(this.components);
            this.tmDelFile = new System.Windows.Forms.Timer(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.toolMenu = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.lblCompName = new System.Windows.Forms.Label();
            this.pnl_exit = new System.Windows.Forms.Panel();
            this.cbo메뉴바 = new MES.Controls.conComboBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.butSetting = new System.Windows.Forms.Button();
            this.lblUserName = new System.Windows.Forms.Label();
            this.panTopBorder = new System.Windows.Forms.Panel();
            this.pnl열린창탭 = new System.Windows.Forms.FlowLayoutPanel();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnl_treeView = new System.Windows.Forms.Panel();
            this.btn_Bookmark_set = new System.Windows.Forms.Button();
            this.myTreeView = new System.Windows.Forms.TreeView();
            this.lbl_title = new System.Windows.Forms.Label();
            this.btn_treeViewExit = new System.Windows.Forms.Button();
            this.picMain = new System.Windows.Forms.PictureBox();
            this.toolMenu.SuspendLayout();
            this.pnl_exit.SuspendLayout();
            this.panTopBorder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.pnl_treeView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMain)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl업체명
            // 
            this.lbl업체명.AutoSize = true;
            this.lbl업체명.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl업체명.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl업체명.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.lbl업체명.Location = new System.Drawing.Point(321, 131);
            this.lbl업체명.Name = "lbl업체명";
            this.lbl업체명.Size = new System.Drawing.Size(90, 28);
            this.lbl업체명.TabIndex = 46;
            this.lbl업체명.Text = "lbl업체명";
            this.lbl업체명.Visible = false;
            this.lbl업체명.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lbl업체명_MouseClick);
            // 
            // panBackRight
            // 
            this.panBackRight.BackColor = System.Drawing.Color.White;
            this.panBackRight.Location = new System.Drawing.Point(148, 108);
            this.panBackRight.Name = "panBackRight";
            this.panBackRight.Size = new System.Drawing.Size(27, 42);
            this.panBackRight.TabIndex = 22;
            // 
            // panBackBottom
            // 
            this.panBackBottom.BackColor = System.Drawing.Color.White;
            this.panBackBottom.Location = new System.Drawing.Point(50, 156);
            this.panBackBottom.Name = "panBackBottom";
            this.panBackBottom.Size = new System.Drawing.Size(125, 16);
            this.panBackBottom.TabIndex = 23;
            // 
            // panBackLeft
            // 
            this.panBackLeft.BackColor = System.Drawing.Color.White;
            this.panBackLeft.Location = new System.Drawing.Point(50, 108);
            this.panBackLeft.Name = "panBackLeft";
            this.panBackLeft.Size = new System.Drawing.Size(23, 42);
            this.panBackLeft.TabIndex = 24;
            // 
            // tmLogin
            // 
            this.tmLogin.Tick += new System.EventHandler(this.tmLogin_Tick);
            // 
            // panMenu
            // 
            this.panMenu.BackColor = System.Drawing.Color.LightBlue;
            this.panMenu.Location = new System.Drawing.Point(106, 329);
            this.panMenu.Name = "panMenu";
            this.panMenu.Size = new System.Drawing.Size(984, 43);
            this.panMenu.TabIndex = 26;
            this.panMenu.Visible = false;
            // 
            // miniToolStrip
            // 
            this.miniToolStrip.AutoSize = false;
            this.miniToolStrip.BackColor = System.Drawing.SystemColors.HotTrack;
            this.miniToolStrip.CanOverflow = false;
            this.miniToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.miniToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.miniToolStrip.ImageScalingSize = new System.Drawing.Size(16, 30);
            this.miniToolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.miniToolStrip.Location = new System.Drawing.Point(813, 0);
            this.miniToolStrip.Name = "miniToolStrip";
            this.miniToolStrip.Padding = new System.Windows.Forms.Padding(0);
            this.miniToolStrip.ShowItemToolTips = false;
            this.miniToolStrip.Size = new System.Drawing.Size(813, 35);
            this.miniToolStrip.Stretch = true;
            this.miniToolStrip.TabIndex = 37;
            // 
            // panBackTop
            // 
            this.panBackTop.BackColor = System.Drawing.Color.White;
            this.panBackTop.Location = new System.Drawing.Point(50, 83);
            this.panBackTop.Name = "panBackTop";
            this.panBackTop.Size = new System.Drawing.Size(125, 19);
            this.panBackTop.TabIndex = 24;
            // 
            // tmSelected
            // 
            this.tmSelected.Tick += new System.EventHandler(this.tmSelected_Tick);
            // 
            // tmDelFile
            // 
            this.tmDelFile.Interval = 1000;
            this.tmDelFile.Tick += new System.EventHandler(this.tmDelFile_Tick);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(1155, 127);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(42, 45);
            this.button2.TabIndex = 41;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            // 
            // toolMenu
            // 
            this.toolMenu.BackColor = System.Drawing.Color.Transparent;
            this.toolMenu.Dock = System.Windows.Forms.DockStyle.None;
            this.toolMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolMenu.ImageScalingSize = new System.Drawing.Size(16, 30);
            this.toolMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton2});
            this.toolMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolMenu.Location = new System.Drawing.Point(84, 1);
            this.toolMenu.Name = "toolMenu";
            this.toolMenu.Padding = new System.Windows.Forms.Padding(0);
            this.toolMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolMenu.ShowItemToolTips = false;
            this.toolMenu.Size = new System.Drawing.Size(67, 35);
            this.toolMenu.Stretch = true;
            this.toolMenu.TabIndex = 41;
            this.toolMenu.ItemAdded += new System.Windows.Forms.ToolStripItemEventHandler(this.toolMenu_ItemAdded);
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.AutoSize = false;
            this.toolStripDropDownButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(237)))), ((int)(((byte)(249)))));
            this.toolStripDropDownButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.toolStripDropDownButton2.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F);
            this.toolStripDropDownButton2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.toolStripDropDownButton2.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.ShowDropDownArrow = false;
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(65, 35);
            this.toolStripDropDownButton2.Text = " 열린창 ";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.BackColor = System.Drawing.Color.White;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(143, 26);
            this.toolStripMenuItem1.Tag = "P1매출관리.frm매출등록";
            this.toolStripMenuItem1.Text = "매출 등록";
            // 
            // lblCompName
            // 
            this.lblCompName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCompName.AutoSize = true;
            this.lblCompName.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCompName.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblCompName.Location = new System.Drawing.Point(1015, 15);
            this.lblCompName.Name = "lblCompName";
            this.lblCompName.Size = new System.Drawing.Size(52, 22);
            this.lblCompName.TabIndex = 48;
            this.lblCompName.Text = "회사명";
            this.lblCompName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCompName.Visible = false;
            // 
            // pnl_exit
            // 
            this.pnl_exit.BackColor = System.Drawing.Color.Transparent;
            this.pnl_exit.Controls.Add(this.cbo메뉴바);
            this.pnl_exit.Controls.Add(this.toolStrip1);
            this.pnl_exit.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnl_exit.Location = new System.Drawing.Point(1115, 0);
            this.pnl_exit.Name = "pnl_exit";
            this.pnl_exit.Size = new System.Drawing.Size(179, 65);
            this.pnl_exit.TabIndex = 49;
            // 
            // cbo메뉴바
            // 
            this.cbo메뉴바._BorderColor = System.Drawing.Color.Gray;
            this.cbo메뉴바._FocusedBackColor = System.Drawing.Color.White;
            this.cbo메뉴바.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbo메뉴바.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbo메뉴바.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbo메뉴바.ForeColor = System.Drawing.Color.Black;
            this.cbo메뉴바.FormattingEnabled = true;
            this.cbo메뉴바.Location = new System.Drawing.Point(0, 36);
            this.cbo메뉴바.Name = "cbo메뉴바";
            this.cbo메뉴바.Size = new System.Drawing.Size(179, 30);
            this.cbo메뉴바.TabIndex = 52;
            this.cbo메뉴바.Text = "메뉴검색";
            this.cbo메뉴바.SelectedIndexChanged += new System.EventHandler(this.cbo메뉴바_SelectedIndexChanged);
            this.cbo메뉴바.Click += new System.EventHandler(this.cbo메뉴바_Click);
            this.cbo메뉴바.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbo메뉴바_KeyDown);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(16, 30);
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(70, 5);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.ShowItemToolTips = false;
            this.toolStrip1.Size = new System.Drawing.Size(102, 25);
            this.toolStrip1.Stretch = true;
            this.toolStrip1.TabIndex = 50;
            this.toolStrip1.Visible = false;
            // 
            // butSetting
            // 
            this.butSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butSetting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.butSetting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butSetting.FlatAppearance.BorderSize = 0;
            this.butSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butSetting.Location = new System.Drawing.Point(1214, 83);
            this.butSetting.Name = "butSetting";
            this.butSetting.Size = new System.Drawing.Size(35, 35);
            this.butSetting.TabIndex = 42;
            this.butSetting.Tag = "frmSetting";
            this.butSetting.UseVisualStyleBackColor = true;
            this.butSetting.Visible = false;
            this.butSetting.Click += new System.EventHandler(this.butSetting_Click);
            // 
            // lblUserName
            // 
            this.lblUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblUserName.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblUserName.Location = new System.Drawing.Point(946, 14);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblUserName.Size = new System.Drawing.Size(52, 22);
            this.lblUserName.TabIndex = 45;
            this.lblUserName.Text = "아무게";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblUserName.Visible = false;
            this.lblUserName.Click += new System.EventHandler(this.lblUserName_Click);
            // 
            // panTopBorder
            // 
            this.panTopBorder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.panTopBorder.Controls.Add(this.pnl열린창탭);
            this.panTopBorder.Controls.Add(this.lblUserName);
            this.panTopBorder.Controls.Add(this.lblCompName);
            this.panTopBorder.Controls.Add(this.picLogo);
            this.panTopBorder.Controls.Add(this.pnl_exit);
            this.panTopBorder.Controls.Add(this.toolMenu);
            this.panTopBorder.Controls.Add(this.button1);
            this.panTopBorder.Controls.Add(this.panel1);
            this.panTopBorder.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTopBorder.Location = new System.Drawing.Point(0, 0);
            this.panTopBorder.Name = "panTopBorder";
            this.panTopBorder.Size = new System.Drawing.Size(1294, 65);
            this.panTopBorder.TabIndex = 1;
            this.panTopBorder.DragEnter += new System.Windows.Forms.DragEventHandler(this.panTopBorder_DragEnter);
            this.panTopBorder.Paint += new System.Windows.Forms.PaintEventHandler(this.panTopBorder_Paint);
            this.panTopBorder.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panTopBorder_MouseDown);
            this.panTopBorder.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panTopBorder_MouseMove);
            // 
            // pnl열린창탭
            // 
            this.pnl열린창탭.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl열린창탭.AutoScroll = true;
            this.pnl열린창탭.BackColor = System.Drawing.Color.Lavender;
            this.pnl열린창탭.Location = new System.Drawing.Point(80, 37);
            this.pnl열린창탭.Margin = new System.Windows.Forms.Padding(0);
            this.pnl열린창탭.Name = "pnl열린창탭";
            this.pnl열린창탭.Size = new System.Drawing.Size(1035, 28);
            this.pnl열린창탭.TabIndex = 51;
            this.pnl열린창탭.WrapContents = false;
            // 
            // picLogo
            // 
            this.picLogo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.picLogo.BackColor = System.Drawing.Color.White;
            this.picLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picLogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picLogo.Image = global::MES.Properties.Resources.lologo;
            this.picLogo.Location = new System.Drawing.Point(0, 0);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(81, 37);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogo.TabIndex = 44;
            this.picLogo.TabStop = false;
            this.picLogo.Click += new System.EventHandler(this.picMain_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.BackColor = System.Drawing.Color.Lavender;
            this.button1.BackgroundImage = global::MES.Properties.Resources.btnSwitch_3x_off;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.Location = new System.Drawing.Point(3, 39);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(78, 25);
            this.button1.TabIndex = 52;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.Color.Lavender;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Location = new System.Drawing.Point(-5, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(92, 32);
            this.panel1.TabIndex = 53;
            // 
            // pnl_treeView
            // 
            this.pnl_treeView.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnl_treeView.Controls.Add(this.btn_Bookmark_set);
            this.pnl_treeView.Controls.Add(this.myTreeView);
            this.pnl_treeView.Controls.Add(this.lbl_title);
            this.pnl_treeView.Controls.Add(this.btn_treeViewExit);
            this.pnl_treeView.Location = new System.Drawing.Point(1, 67);
            this.pnl_treeView.Name = "pnl_treeView";
            this.pnl_treeView.Size = new System.Drawing.Size(282, 562);
            this.pnl_treeView.TabIndex = 48;
            this.pnl_treeView.Visible = false;
            // 
            // btn_Bookmark_set
            // 
            this.btn_Bookmark_set.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btn_Bookmark_set.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_Bookmark_set.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Bookmark_set.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Bold);
            this.btn_Bookmark_set.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_Bookmark_set.Location = new System.Drawing.Point(172, 7);
            this.btn_Bookmark_set.Name = "btn_Bookmark_set";
            this.btn_Bookmark_set.Size = new System.Drawing.Size(99, 33);
            this.btn_Bookmark_set.TabIndex = 393;
            this.btn_Bookmark_set.Text = "북마크 설정";
            this.btn_Bookmark_set.UseVisualStyleBackColor = true;
            this.btn_Bookmark_set.Click += new System.EventHandler(this.btn_Bookmark_set_Click);
            // 
            // myTreeView
            // 
            this.myTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.myTreeView.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.myTreeView.Location = new System.Drawing.Point(10, 46);
            this.myTreeView.Name = "myTreeView";
            this.myTreeView.Size = new System.Drawing.Size(262, 505);
            this.myTreeView.TabIndex = 95;
            this.myTreeView.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.myTreeView_AfterCheck);
            this.myTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.myTreeView_AfterSelect);
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.Font = new System.Drawing.Font("SpoqaHanSans-Bold", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.lbl_title.Location = new System.Drawing.Point(9, 4);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(100, 34);
            this.lbl_title.TabIndex = 94;
            this.lbl_title.Text = "전체 메뉴";
            // 
            // btn_treeViewExit
            // 
            this.btn_treeViewExit.BackColor = System.Drawing.Color.IndianRed;
            this.btn_treeViewExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_treeViewExit.FlatAppearance.BorderSize = 0;
            this.btn_treeViewExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_treeViewExit.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_treeViewExit.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_treeViewExit.Location = new System.Drawing.Point(235, 7);
            this.btn_treeViewExit.Margin = new System.Windows.Forms.Padding(0);
            this.btn_treeViewExit.Name = "btn_treeViewExit";
            this.btn_treeViewExit.Size = new System.Drawing.Size(35, 33);
            this.btn_treeViewExit.TabIndex = 53;
            this.btn_treeViewExit.Text = "X";
            this.btn_treeViewExit.UseVisualStyleBackColor = false;
            this.btn_treeViewExit.Visible = false;
            this.btn_treeViewExit.Click += new System.EventHandler(this.treeViewExit_Click);
            // 
            // picMain
            // 
            this.picMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picMain.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picMain.Location = new System.Drawing.Point(387, 242);
            this.picMain.Name = "picMain";
            this.picMain.Size = new System.Drawing.Size(69, 43);
            this.picMain.TabIndex = 39;
            this.picMain.TabStop = false;
            this.picMain.Visible = false;
            this.picMain.Click += new System.EventHandler(this.picMain_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1294, 628);
            this.Controls.Add(this.pnl_treeView);
            this.Controls.Add(this.butSetting);
            this.Controls.Add(this.panMenu);
            this.Controls.Add(this.panBackRight);
            this.Controls.Add(this.panBackBottom);
            this.Controls.Add(this.lbl업체명);
            this.Controls.Add(this.panBackLeft);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.picMain);
            this.Controls.Add(this.panTopBorder);
            this.Controls.Add(this.panBackTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "스마트 팩토리 (1.0.2.0)";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.SizeChanged += new System.EventHandler(this.frmMain_SizeChanged);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.toolMenu.ResumeLayout(false);
            this.toolMenu.PerformLayout();
            this.pnl_exit.ResumeLayout(false);
            this.pnl_exit.PerformLayout();
            this.panTopBorder.ResumeLayout(false);
            this.panTopBorder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.pnl_treeView.ResumeLayout(false);
            this.pnl_treeView.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox picMain;
        internal System.Windows.Forms.Panel panBackRight;
        internal System.Windows.Forms.Panel panBackBottom;
        internal System.Windows.Forms.Panel panBackLeft;
        private System.Windows.Forms.Timer tmLogin;
        public System.Windows.Forms.Panel panMenu;
        public System.Windows.Forms.ToolStrip miniToolStrip;
        internal System.Windows.Forms.Panel panBackTop;
        public System.Windows.Forms.Timer tmSelected;
        public System.Windows.Forms.Label lbl업체명;
        public System.Windows.Forms.Timer tmDelFile;
        public System.Windows.Forms.ToolStripDropDownButton tsOpenWin;
        public System.Windows.Forms.ToolStrip toolMenu;
        private System.Windows.Forms.PictureBox picLogo;
        public System.Windows.Forms.Label lblCompName;
        private System.Windows.Forms.Panel pnl_exit;
        public System.Windows.Forms.Button butSetting;
        public System.Windows.Forms.Label lblUserName;
        public System.Windows.Forms.Panel panTopBorder;
        public System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        public System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        public System.Windows.Forms.ToolStrip toolStrip1;
        private Controls.conComboBox cbo메뉴바;
        public System.Windows.Forms.FlowLayoutPanel pnl열린창탭;
        private System.Windows.Forms.Panel pnl_treeView;
        private System.Windows.Forms.Button btn_treeViewExit;
        private System.Windows.Forms.TreeView myTreeView;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Button btn_Bookmark_set;
        private System.Windows.Forms.Panel button1;
        private System.Windows.Forms.Panel panel1;
    }
}

