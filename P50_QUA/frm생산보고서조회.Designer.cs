namespace MES.P50_QUA
{
    partial class frm생산보고서조회
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm생산보고서조회));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnPrint = new System.Windows.Forms.Button();
            this.lbl_title = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tab2 = new System.Windows.Forms.TabPage();
            this.split_생산계획보고서 = new System.Windows.Forms.SplitContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label3 = new System.Windows.Forms.Label();
            this.planGridView = new MES.Controls.conDataGridView();
            this.ITEM_NM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SPEC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UNIT_NM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SUM_AMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ITEM_CD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UNIT_CD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.flowGridView = new MES.Controls.conDataGridView();
            this.F_ITEM_NM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.F_SPEC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.F_INST_AMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.F_LOSS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.F_POOR_AMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.F_SUM_AMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.F_UNIT_NM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.F_ITEM_CD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.F_UNIT_CD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_srch = new System.Windows.Forms.Button();
            this.txt_item_cd = new System.Windows.Forms.TextBox();
            this.cmb_datetime = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.cmb_datetime2 = new System.Windows.Forms.DateTimePicker();
            this.chk_srch_month = new System.Windows.Forms.CheckBox();
            this.cmb_month = new System.Windows.Forms.DateTimePicker();
            this.chk_srch_day = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgv_detail_grid = new MES.Controls.conDataGridView();
            this.PLAN_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D_UNIT_NM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WORK_YN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dgv생산증가율 = new MES.Controls.conDataGridView();
            this.월별 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.총생산량 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.생산증가율 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NON4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NON3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INPUT_UNIT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NON5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NON2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NON1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tab2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.split_생산계획보고서)).BeginInit();
            this.split_생산계획보고서.Panel1.SuspendLayout();
            this.split_생산계획보고서.Panel2.SuspendLayout();
            this.split_생산계획보고서.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.planGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.flowGridView)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_detail_grid)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv생산증가율)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.PaleTurquoise;
            this.panel2.Controls.Add(this.btnPrint);
            this.panel2.Controls.Add(this.lbl_title);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1284, 33);
            this.panel2.TabIndex = 18;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.BackColor = System.Drawing.Color.Transparent;
            this.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.PaleTurquoise;
            this.btnPrint.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.btnPrint.Image = global::MES.Properties.Resources.newPrintBtn;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPrint.Location = new System.Drawing.Point(1019, 3);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(69, 29);
            this.btnPrint.TabIndex = 358;
            this.btnPrint.Tag = "출력";
            this.btnPrint.Text = "출력";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Visible = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.lbl_title.Location = new System.Drawing.Point(9, -2); //new System.Drawing.Point(10, 5);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(123, 30);
            this.lbl_title.TabIndex = 93;
            this.lbl_title.Text = "생산보고서";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.btnClose.Image = global::MES.Properties.Resources.newnewCloseBtn;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(1216, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(65, 29);
            this.btnClose.TabIndex = 10;
            this.btnClose.Tag = "종료";
            this.btnClose.Text = "닫기";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1284, 701);
            this.panel1.TabIndex = 19;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tab2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F);
            this.tabControl1.Location = new System.Drawing.Point(0, 30);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1281, 628);
            this.tabControl1.TabIndex = 403;
            // 
            // tab2
            // 
            this.tab2.Controls.Add(this.split_생산계획보고서);
            this.tab2.Location = new System.Drawing.Point(4, 29);
            this.tab2.Name = "tab2";
            this.tab2.Padding = new System.Windows.Forms.Padding(3);
            this.tab2.Size = new System.Drawing.Size(1273, 595);
            this.tab2.TabIndex = 1;
            this.tab2.Text = "생산보고서";
            this.tab2.UseVisualStyleBackColor = true;
            this.tab2.Click += new System.EventHandler(this.tab2_Click);
            // 
            // split_생산계획보고서
            // 
            this.split_생산계획보고서.Dock = System.Windows.Forms.DockStyle.Fill;
            this.split_생산계획보고서.Location = new System.Drawing.Point(3, 3);
            this.split_생산계획보고서.Name = "split_생산계획보고서";
            // 
            // split_생산계획보고서.Panel1
            // 
            this.split_생산계획보고서.Panel1.Controls.Add(this.splitContainer1);
            this.split_생산계획보고서.Panel1.Controls.Add(this.btn_srch);
            this.split_생산계획보고서.Panel1.Controls.Add(this.txt_item_cd);
            this.split_생산계획보고서.Panel1.Controls.Add(this.cmb_datetime);
            this.split_생산계획보고서.Panel1.Controls.Add(this.label4);
            this.split_생산계획보고서.Panel1.Controls.Add(this.cmb_datetime2);
            this.split_생산계획보고서.Panel1.Controls.Add(this.chk_srch_month);
            this.split_생산계획보고서.Panel1.Controls.Add(this.cmb_month);
            this.split_생산계획보고서.Panel1.Controls.Add(this.chk_srch_day);
            // 
            // split_생산계획보고서.Panel2
            // 
            this.split_생산계획보고서.Panel2.Controls.Add(this.groupBox3);
            this.split_생산계획보고서.Size = new System.Drawing.Size(1267, 589);
            this.split_생산계획보고서.SplitterDistance = 831;
            this.split_생산계획보고서.TabIndex = 404;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(3, 59);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.planGridView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.flowGridView);
            this.splitContainer1.Size = new System.Drawing.Size(811, 527);
            this.splitContainer1.SplitterDistance = 263;
            this.splitContainer1.TabIndex = 404;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.PowderBlue;
            this.label3.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(3, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 22);
            this.label3.TabIndex = 396;
            this.label3.Text = "생산 계획";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // planGridView
            // 
            this.planGridView._BorderColor = System.Drawing.Color.Silver;
            this.planGridView._DirKey = "R";
            this.planGridView._KeyboardCmd = "1";
            this.planGridView._KeyInput = "";
            this.planGridView._LastCol = -1;
            this.planGridView._LastRow = -1;
            this.planGridView.AllowUserToAddRows = false;
            this.planGridView.AllowUserToDeleteRows = false;
            this.planGridView.AllowUserToResizeColumns = false;
            this.planGridView.AllowUserToResizeRows = false;
            this.planGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.planGridView.BackgroundColor = System.Drawing.Color.White;
            this.planGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.planGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.planGridView.ColumnHeadersHeight = 35;
            this.planGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.planGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ITEM_NM,
            this.SPEC,
            this.UNIT_NM,
            this.SUM_AMT,
            this.ITEM_CD,
            this.UNIT_CD});
            this.planGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.planGridView.EnableHeadersVisualStyles = false;
            this.planGridView.GridColor = System.Drawing.Color.PowderBlue;
            this.planGridView.Location = new System.Drawing.Point(1, 31);
            this.planGridView.Name = "planGridView";
            this.planGridView.ReadOnly = true;
            this.planGridView.RowHeadersVisible = false;
            this.planGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.LightYellow;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.planGridView.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.planGridView.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.planGridView.RowTemplate.Height = 23;
            this.planGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.planGridView.Size = new System.Drawing.Size(857, 229);
            this.planGridView.TabIndex = 380;
            this.planGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.planGridView_CellDoubleClick);
            // 
            // ITEM_NM
            // 
            this.ITEM_NM.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ITEM_NM.HeaderText = "제품명";
            this.ITEM_NM.Name = "ITEM_NM";
            this.ITEM_NM.ReadOnly = true;
            // 
            // SPEC
            // 
            this.SPEC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SPEC.HeaderText = "규격";
            this.SPEC.Name = "SPEC";
            this.SPEC.ReadOnly = true;
            // 
            // UNIT_NM
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.UNIT_NM.DefaultCellStyle = dataGridViewCellStyle2;
            this.UNIT_NM.HeaderText = "단위";
            this.UNIT_NM.Name = "UNIT_NM";
            this.UNIT_NM.ReadOnly = true;
            this.UNIT_NM.Width = 170;
            // 
            // SUM_AMT
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.SUM_AMT.DefaultCellStyle = dataGridViewCellStyle3;
            this.SUM_AMT.HeaderText = "총 생산계획량";
            this.SUM_AMT.Name = "SUM_AMT";
            this.SUM_AMT.ReadOnly = true;
            this.SUM_AMT.Width = 220;
            // 
            // ITEM_CD
            // 
            this.ITEM_CD.HeaderText = "제품코드";
            this.ITEM_CD.Name = "ITEM_CD";
            this.ITEM_CD.ReadOnly = true;
            this.ITEM_CD.Visible = false;
            // 
            // UNIT_CD
            // 
            this.UNIT_CD.HeaderText = "단위코드";
            this.UNIT_CD.Name = "UNIT_CD";
            this.UNIT_CD.ReadOnly = true;
            this.UNIT_CD.Visible = false;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.PowderBlue;
            this.label2.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 22);
            this.label2.TabIndex = 395;
            this.label2.Text = "작업 공정";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowGridView
            // 
            this.flowGridView._BorderColor = System.Drawing.Color.Silver;
            this.flowGridView._DirKey = "R";
            this.flowGridView._KeyboardCmd = "1";
            this.flowGridView._KeyInput = "";
            this.flowGridView._LastCol = -1;
            this.flowGridView._LastRow = -1;
            this.flowGridView.AllowUserToAddRows = false;
            this.flowGridView.AllowUserToDeleteRows = false;
            this.flowGridView.AllowUserToResizeColumns = false;
            this.flowGridView.AllowUserToResizeRows = false;
            this.flowGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.flowGridView.BackgroundColor = System.Drawing.Color.White;
            this.flowGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.flowGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.flowGridView.ColumnHeadersHeight = 35;
            this.flowGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.flowGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.F_ITEM_NM,
            this.F_SPEC,
            this.F_INST_AMT,
            this.F_LOSS,
            this.F_POOR_AMT,
            this.F_SUM_AMT,
            this.F_UNIT_NM,
            this.F_ITEM_CD,
            this.F_UNIT_CD});
            this.flowGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.flowGridView.EnableHeadersVisualStyles = false;
            this.flowGridView.GridColor = System.Drawing.Color.PowderBlue;
            this.flowGridView.Location = new System.Drawing.Point(1, 28);
            this.flowGridView.Name = "flowGridView";
            this.flowGridView.ReadOnly = true;
            this.flowGridView.RowHeadersVisible = false;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.LightYellow;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black;
            this.flowGridView.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.flowGridView.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.flowGridView.RowTemplate.Height = 23;
            this.flowGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.flowGridView.Size = new System.Drawing.Size(857, 229);
            this.flowGridView.TabIndex = 402;
            this.flowGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.flowGridView_CellDoubleClick);
            // 
            // F_ITEM_NM
            // 
            this.F_ITEM_NM.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.F_ITEM_NM.HeaderText = "제품명";
            this.F_ITEM_NM.Name = "F_ITEM_NM";
            this.F_ITEM_NM.ReadOnly = true;
            // 
            // F_SPEC
            // 
            this.F_SPEC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.F_SPEC.HeaderText = "규격";
            this.F_SPEC.Name = "F_SPEC";
            this.F_SPEC.ReadOnly = true;
            // 
            // F_INST_AMT
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.F_INST_AMT.DefaultCellStyle = dataGridViewCellStyle6;
            this.F_INST_AMT.HeaderText = "목표량";
            this.F_INST_AMT.Name = "F_INST_AMT";
            this.F_INST_AMT.ReadOnly = true;
            this.F_INST_AMT.Width = 98;
            // 
            // F_LOSS
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.F_LOSS.DefaultCellStyle = dataGridViewCellStyle7;
            this.F_LOSS.HeaderText = "LOSS";
            this.F_LOSS.Name = "F_LOSS";
            this.F_LOSS.ReadOnly = true;
            this.F_LOSS.Width = 98;
            // 
            // F_POOR_AMT
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.F_POOR_AMT.DefaultCellStyle = dataGridViewCellStyle8;
            this.F_POOR_AMT.HeaderText = "불량 수";
            this.F_POOR_AMT.Name = "F_POOR_AMT";
            this.F_POOR_AMT.ReadOnly = true;
            this.F_POOR_AMT.Width = 98;
            // 
            // F_SUM_AMT
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.F_SUM_AMT.DefaultCellStyle = dataGridViewCellStyle9;
            this.F_SUM_AMT.HeaderText = "생산량";
            this.F_SUM_AMT.Name = "F_SUM_AMT";
            this.F_SUM_AMT.ReadOnly = true;
            this.F_SUM_AMT.Width = 98;
            // 
            // F_UNIT_NM
            // 
            this.F_UNIT_NM.HeaderText = "단위";
            this.F_UNIT_NM.Name = "F_UNIT_NM";
            this.F_UNIT_NM.ReadOnly = true;
            this.F_UNIT_NM.Visible = false;
            this.F_UNIT_NM.Width = 170;
            // 
            // F_ITEM_CD
            // 
            this.F_ITEM_CD.HeaderText = "제품코드";
            this.F_ITEM_CD.Name = "F_ITEM_CD";
            this.F_ITEM_CD.ReadOnly = true;
            this.F_ITEM_CD.Visible = false;
            // 
            // F_UNIT_CD
            // 
            this.F_UNIT_CD.HeaderText = "단위코드";
            this.F_UNIT_CD.Name = "F_UNIT_CD";
            this.F_UNIT_CD.ReadOnly = true;
            this.F_UNIT_CD.Visible = false;
            // 
            // btn_srch
            // 
            this.btn_srch.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_srch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_srch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_srch.FlatAppearance.BorderSize = 0;
            this.btn_srch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btn_srch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_srch.Image = ((System.Drawing.Image)(resources.GetObject("btn_srch.Image")));
            this.btn_srch.Location = new System.Drawing.Point(3, 3);
            this.btn_srch.Name = "btn_srch";
            this.btn_srch.Size = new System.Drawing.Size(54, 52);
            this.btn_srch.TabIndex = 383;
            this.btn_srch.Tag = "검색";
            this.btn_srch.UseVisualStyleBackColor = false;
            this.btn_srch.Click += new System.EventHandler(this.btn_srch_Click);
            // 
            // txt_item_cd
            // 
            this.txt_item_cd.Location = new System.Drawing.Point(730, 2);
            this.txt_item_cd.Name = "txt_item_cd";
            this.txt_item_cd.Size = new System.Drawing.Size(100, 27);
            this.txt_item_cd.TabIndex = 403;
            this.txt_item_cd.Visible = false;
            // 
            // cmb_datetime
            // 
            this.cmb_datetime.Checked = false;
            this.cmb_datetime.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.cmb_datetime.Location = new System.Drawing.Point(133, 3);
            this.cmb_datetime.Name = "cmb_datetime";
            this.cmb_datetime.Size = new System.Drawing.Size(102, 27);
            this.cmb_datetime.TabIndex = 102;
            this.cmb_datetime.Value = new System.DateTime(2018, 10, 8, 0, 0, 0, 0);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(244, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 23);
            this.label4.TabIndex = 383;
            this.label4.Text = "~";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmb_datetime2
            // 
            this.cmb_datetime2.Checked = false;
            this.cmb_datetime2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.cmb_datetime2.Location = new System.Drawing.Point(286, 2);
            this.cmb_datetime2.Name = "cmb_datetime2";
            this.cmb_datetime2.Size = new System.Drawing.Size(102, 27);
            this.cmb_datetime2.TabIndex = 103;
            this.cmb_datetime2.Value = new System.DateTime(2018, 10, 8, 0, 0, 0, 0);
            // 
            // chk_srch_month
            // 
            this.chk_srch_month.AutoSize = true;
            this.chk_srch_month.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chk_srch_month.Location = new System.Drawing.Point(67, 33);
            this.chk_srch_month.Name = "chk_srch_month";
            this.chk_srch_month.Size = new System.Drawing.Size(61, 25);
            this.chk_srch_month.TabIndex = 201;
            this.chk_srch_month.Text = "월간";
            this.chk_srch_month.UseVisualStyleBackColor = true;
            this.chk_srch_month.CheckedChanged += new System.EventHandler(this.chk_srch_month_CheckedChanged);
            // 
            // cmb_month
            // 
            this.cmb_month.Checked = false;
            this.cmb_month.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.cmb_month.Location = new System.Drawing.Point(133, 32);
            this.cmb_month.MaxDate = new System.DateTime(9998, 12, 1, 0, 0, 0, 0);
            this.cmb_month.Name = "cmb_month";
            this.cmb_month.Size = new System.Drawing.Size(119, 27);
            this.cmb_month.TabIndex = 202;
            this.cmb_month.Value = new System.DateTime(2018, 10, 8, 0, 0, 0, 0);
            // 
            // chk_srch_day
            // 
            this.chk_srch_day.AutoSize = true;
            this.chk_srch_day.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chk_srch_day.Location = new System.Drawing.Point(67, 5);
            this.chk_srch_day.Name = "chk_srch_day";
            this.chk_srch_day.Size = new System.Drawing.Size(61, 25);
            this.chk_srch_day.TabIndex = 101;
            this.chk_srch_day.Text = "일간";
            this.chk_srch_day.UseVisualStyleBackColor = true;
            this.chk_srch_day.CheckedChanged += new System.EventHandler(this.chk_srch_day_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgv_detail_grid);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(432, 589);
            this.groupBox3.TabIndex = 367;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "상세 조회";
            // 
            // dgv_detail_grid
            // 
            this.dgv_detail_grid._BorderColor = System.Drawing.Color.Silver;
            this.dgv_detail_grid._DirKey = "R";
            this.dgv_detail_grid._KeyboardCmd = "1";
            this.dgv_detail_grid._KeyInput = "";
            this.dgv_detail_grid._LastCol = -1;
            this.dgv_detail_grid._LastRow = -1;
            this.dgv_detail_grid.AllowUserToAddRows = false;
            this.dgv_detail_grid.AllowUserToDeleteRows = false;
            this.dgv_detail_grid.AllowUserToResizeColumns = false;
            this.dgv_detail_grid.AllowUserToResizeRows = false;
            this.dgv_detail_grid.BackgroundColor = System.Drawing.Color.White;
            this.dgv_detail_grid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_detail_grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgv_detail_grid.ColumnHeadersHeight = 35;
            this.dgv_detail_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_detail_grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PLAN_DATE,
            this.D_UNIT_NM,
            this.WORK_YN});
            this.dgv_detail_grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_detail_grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgv_detail_grid.EnableHeadersVisualStyles = false;
            this.dgv_detail_grid.GridColor = System.Drawing.Color.PowderBlue;
            this.dgv_detail_grid.Location = new System.Drawing.Point(3, 21);
            this.dgv_detail_grid.Name = "dgv_detail_grid";
            this.dgv_detail_grid.ReadOnly = true;
            this.dgv_detail_grid.RowHeadersVisible = false;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.LightYellow;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.Black;
            this.dgv_detail_grid.RowsDefaultCellStyle = dataGridViewCellStyle15;
            this.dgv_detail_grid.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dgv_detail_grid.RowTemplate.Height = 23;
            this.dgv_detail_grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_detail_grid.Size = new System.Drawing.Size(426, 565);
            this.dgv_detail_grid.TabIndex = 381;
            // 
            // PLAN_DATE
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.PLAN_DATE.DefaultCellStyle = dataGridViewCellStyle12;
            this.PLAN_DATE.HeaderText = "생산일자";
            this.PLAN_DATE.Name = "PLAN_DATE";
            this.PLAN_DATE.ReadOnly = true;
            this.PLAN_DATE.Width = 200;
            // 
            // D_UNIT_NM
            // 
            this.D_UNIT_NM.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.D_UNIT_NM.DefaultCellStyle = dataGridViewCellStyle13;
            this.D_UNIT_NM.HeaderText = "단위명";
            this.D_UNIT_NM.Name = "D_UNIT_NM";
            this.D_UNIT_NM.ReadOnly = true;
            // 
            // WORK_YN
            // 
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.WORK_YN.DefaultCellStyle = dataGridViewCellStyle14;
            this.WORK_YN.HeaderText = "작업여부";
            this.WORK_YN.Name = "WORK_YN";
            this.WORK_YN.ReadOnly = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.chart1);
            this.tabPage1.Controls.Add(this.dgv생산증가율);
            this.tabPage1.Controls.Add(this.btnSearch);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(1273, 595);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "생산율그래프";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.PowderBlue;
            this.label5.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(490, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(145, 22);
            this.label5.TabIndex = 410;
            this.label5.Text = "월별 생산그래프";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.PowderBlue;
            this.label1.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(67, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 22);
            this.label1.TabIndex = 409;
            this.label1.Text = "월별 생산율";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Location = new System.Drawing.Point(453, 55);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.IsVisibleInLegend = false;
            series1.Name = "Series2";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(887, 513);
            this.chart1.TabIndex = 408;
            this.chart1.Text = "chart1";
            // 
            // dgv생산증가율
            // 
            this.dgv생산증가율._BorderColor = System.Drawing.Color.White;
            this.dgv생산증가율._DirKey = "R";
            this.dgv생산증가율._KeyboardCmd = "0";
            this.dgv생산증가율._KeyInput = "";
            this.dgv생산증가율._LastCol = -1;
            this.dgv생산증가율._LastRow = -1;
            this.dgv생산증가율.AllowUserToAddRows = false;
            this.dgv생산증가율.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv생산증가율.BackgroundColor = System.Drawing.Color.White;
            this.dgv생산증가율.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv생산증가율.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.월별,
            this.총생산량,
            this.생산증가율});
            this.dgv생산증가율.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgv생산증가율.Location = new System.Drawing.Point(70, 54);
            this.dgv생산증가율.Name = "dgv생산증가율";
            this.dgv생산증가율.ReadOnly = true;
            this.dgv생산증가율.RowHeadersVisible = false;
            this.dgv생산증가율.RowTemplate.Height = 23;
            this.dgv생산증가율.Size = new System.Drawing.Size(377, 148);
            this.dgv생산증가율.TabIndex = 407;
            // 
            // 월별
            // 
            this.월별.HeaderText = "월별";
            this.월별.Name = "월별";
            this.월별.ReadOnly = true;
            // 
            // 총생산량
            // 
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.총생산량.DefaultCellStyle = dataGridViewCellStyle16;
            this.총생산량.HeaderText = "총생산량";
            this.총생산량.Name = "총생산량";
            this.총생산량.ReadOnly = true;
            // 
            // 생산증가율
            // 
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.생산증가율.DefaultCellStyle = dataGridViewCellStyle17;
            this.생산증가율.HeaderText = "생산증가율";
            this.생산증가율.Name = "생산증가율";
            this.생산증가율.ReadOnly = true;
            this.생산증가율.Width = 150;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(173, 26);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(32, 26);
            this.btnSearch.TabIndex = 406;
            this.btnSearch.Tag = "검색";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.HeaderText = "[ ]";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCheckBoxColumn1.Visible = false;
            this.dataGridViewCheckBoxColumn1.Width = 30;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.HeaderText = "규격";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            this.dataGridViewTextBoxColumn13.Width = 70;
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.HeaderText = "총단량";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            this.dataGridViewTextBoxColumn18.Width = 105;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.HeaderText = "제품코드";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Width = 120;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.HeaderText = "출고단위";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.Width = 80;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.HeaderText = "입고단위";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.Width = 80;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.HeaderText = "거래처명";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.Width = 150;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.HeaderText = "원자재";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.Width = 150;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "규격";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 135;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "규격";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 140;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.HeaderText = "제품명";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.Width = 150;
            // 
            // NON4
            // 
            this.NON4.HeaderText = "공정명";
            this.NON4.Name = "NON4";
            this.NON4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NON4.ToolTipText = "명칭";
            this.NON4.Width = 137;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle18;
            this.dataGridViewTextBoxColumn2.HeaderText = "제품명";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 150;
            // 
            // NON3
            // 
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.NON3.DefaultCellStyle = dataGridViewCellStyle19;
            this.NON3.HeaderText = "특이사항";
            this.NON3.Name = "NON3";
            this.NON3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NON3.Width = 200;
            // 
            // INPUT_UNIT
            // 
            this.INPUT_UNIT.HeaderText = "단위";
            this.INPUT_UNIT.Name = "INPUT_UNIT";
            this.INPUT_UNIT.Width = 80;
            // 
            // NON5
            // 
            this.NON5.HeaderText = "공정여부";
            this.NON5.Name = "NON5";
            this.NON5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // NON2
            // 
            this.NON2.HeaderText = "기존)공정명";
            this.NON2.Name = "NON2";
            this.NON2.Visible = false;
            // 
            // NON1
            // 
            this.NON1.HeaderText = "공정코드";
            this.NON1.Name = "NON1";
            this.NON1.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle20;
            this.dataGridViewTextBoxColumn1.HeaderText = "No.";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 45;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "검색단위";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 120;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "박스수량";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 80;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "비고";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 180;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "포장규격";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 180;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "거래처";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Width = 115;
            // 
            // frm생산보고서조회
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 701);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frm생산보고서조회";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frm생산보고서조회";
            this.Load += new System.EventHandler(this.frm생산보고서조회_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tab2.ResumeLayout(false);
            this.split_생산계획보고서.Panel1.ResumeLayout(false);
            this.split_생산계획보고서.Panel1.PerformLayout();
            this.split_생산계획보고서.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.split_생산계획보고서)).EndInit();
            this.split_생산계획보고서.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.planGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.flowGridView)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_detail_grid)).EndInit();
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv생산증가율)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn NON4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn NON3;
        private System.Windows.Forms.DataGridViewTextBoxColumn INPUT_UNIT;
        private System.Windows.Forms.DataGridViewTextBoxColumn NON5;
        private System.Windows.Forms.DataGridViewTextBoxColumn NON2;
        private System.Windows.Forms.DataGridViewTextBoxColumn NON1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tab2;
        private System.Windows.Forms.TextBox txt_item_cd;
        private Controls.conDataGridView flowGridView;
        private Controls.conDataGridView planGridView;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chk_srch_month;
        private System.Windows.Forms.CheckBox chk_srch_day;
        private System.Windows.Forms.DateTimePicker cmb_month;
        private System.Windows.Forms.DateTimePicker cmb_datetime2;
        private System.Windows.Forms.DateTimePicker cmb_datetime;
        private System.Windows.Forms.Button btn_srch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private Controls.conDataGridView dgv_detail_grid;
        private System.Windows.Forms.DataGridViewTextBoxColumn PLAN_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn D_UNIT_NM;
        private System.Windows.Forms.DataGridViewTextBoxColumn WORK_YN;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private Controls.conDataGridView dgv생산증가율;
        private System.Windows.Forms.DataGridViewTextBoxColumn 월별;
        private System.Windows.Forms.DataGridViewTextBoxColumn 총생산량;
        private System.Windows.Forms.DataGridViewTextBoxColumn 생산증가율;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.SplitContainer split_생산계획보고서;
        private System.Windows.Forms.DataGridViewTextBoxColumn ITEM_NM;
        private System.Windows.Forms.DataGridViewTextBoxColumn SPEC;
        private System.Windows.Forms.DataGridViewTextBoxColumn UNIT_NM;
        private System.Windows.Forms.DataGridViewTextBoxColumn SUM_AMT;
        private System.Windows.Forms.DataGridViewTextBoxColumn ITEM_CD;
        private System.Windows.Forms.DataGridViewTextBoxColumn UNIT_CD;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn F_ITEM_NM;
        private System.Windows.Forms.DataGridViewTextBoxColumn F_SPEC;
        private System.Windows.Forms.DataGridViewTextBoxColumn F_INST_AMT;
        private System.Windows.Forms.DataGridViewTextBoxColumn F_LOSS;
        private System.Windows.Forms.DataGridViewTextBoxColumn F_POOR_AMT;
        private System.Windows.Forms.DataGridViewTextBoxColumn F_SUM_AMT;
        private System.Windows.Forms.DataGridViewTextBoxColumn F_UNIT_NM;
        private System.Windows.Forms.DataGridViewTextBoxColumn F_ITEM_CD;
        private System.Windows.Forms.DataGridViewTextBoxColumn F_UNIT_CD;

    }
}