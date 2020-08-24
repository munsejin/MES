namespace MES.P20_ORD
{
    partial class frm원자재재고현황
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm원자재재고현황));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn출력 = new System.Windows.Forms.Button();
            this.lbl_title = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_cd_srch = new MES.Controls.conComboBox();
            this.txt_srch = new MES.Controls.conTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.srch_date = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btn_stock_no = new System.Windows.Forms.RadioButton();
            this.btn_stock_ok = new System.Windows.Forms.RadioButton();
            this.rawStockGrid = new MES.Controls.myDataGridView();
            this.RAW_MAT_CD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RAW_MAT_NM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.구매처 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.구매처코드 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SPEC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INPUT_AMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OUTPUT_AMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STOCK_AMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.rawDetailGrid = new MES.Controls.myDataGridView();
            this.INPUT_DATE = new MES.Controls.DataGridViewTextBoxColumnEx();
            this.INPUT_CD = new MES.Controls.DataGridViewTextBoxColumnEx();
            this.구매처명 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INPUT_SEQ = new MES.Controls.DataGridViewTextBoxColumnEx();
            this.dataGridViewTextBoxColumn11 = new MES.Controls.DataGridViewTextBoxColumnEx();
            this.STORAGE_NM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LOC_NM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.R_INPUT_AMT = new MES.Controls.DataGridViewTextBoxColumnEx();
            this.R_OUTPUT_AMT = new MES.Controls.DataGridViewTextBoxColumnEx();
            this.R_STOCK_AMT = new MES.Controls.DataGridViewTextBoxColumnEx();
            this.STORAGE_CD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LOC_CD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label20 = new System.Windows.Forms.Label();
            this.lbl_raw_nm = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rawStockGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rawDetailGrid)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.btn출력);
            this.panel2.Controls.Add(this.lbl_title);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1360, 33);
            this.panel2.TabIndex = 18;
            // 
            // btn출력
            // 
            this.btn출력.BackColor = System.Drawing.Color.Transparent;
            this.btn출력.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn출력.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn출력.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn출력.FlatAppearance.BorderColor = System.Drawing.Color.PaleTurquoise;
            this.btn출력.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn출력.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn출력.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn출력.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.btn출력.Image = global::MES.Properties.Resources.newPrintBtn;
            this.btn출력.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn출력.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn출력.Location = new System.Drawing.Point(1214, 0);
            this.btn출력.Name = "btn출력";
            this.btn출력.Size = new System.Drawing.Size(75, 33);
            this.btn출력.TabIndex = 382;
            this.btn출력.Tag = "출력";
            this.btn출력.Text = "출력";
            this.btn출력.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn출력.UseVisualStyleBackColor = false;
            this.btn출력.Click += new System.EventHandler(this.btn출력_Click);
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.Font = new System.Drawing.Font("SpoqaHanSans-Bold", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.lbl_title.Location = new System.Drawing.Point(9, -2); //new System.Drawing.Point(6, 3);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(138, 28);
            this.lbl_title.TabIndex = 93;
            this.lbl_title.Text = "원자재재고현황";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.btnClose.Image = global::MES.Properties.Resources.newnewCloseBtn;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(1289, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(71, 33);
            this.btnClose.TabIndex = 10;
            this.btnClose.Tag = "종료";
            this.btnClose.Text = "닫기";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.Crimson;
            this.label1.Location = new System.Drawing.Point(1280, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 22);
            this.label1.TabIndex = 384;
            this.label1.Text = "* 재고부족";
            this.label1.Visible = false;
            // 
            // cmb_cd_srch
            // 
            this.cmb_cd_srch._BorderColor = System.Drawing.Color.Transparent;
            this.cmb_cd_srch._FocusedBackColor = System.Drawing.Color.White;
            this.cmb_cd_srch.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cmb_cd_srch.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cmb_cd_srch.FormattingEnabled = true;
            this.cmb_cd_srch.Location = new System.Drawing.Point(198, 5);
            this.cmb_cd_srch.Name = "cmb_cd_srch";
            this.cmb_cd_srch.Size = new System.Drawing.Size(114, 30);
            this.cmb_cd_srch.TabIndex = 383;
            // 
            // txt_srch
            // 
            this.txt_srch._AutoTab = true;
            this.txt_srch._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.txt_srch._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txt_srch._WaterMarkColor = System.Drawing.Color.Gray;
            this.txt_srch._WaterMarkText = "";
            this.txt_srch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_srch.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_srch.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.txt_srch.Location = new System.Drawing.Point(318, 5);
            this.txt_srch.MaxLength = 20;
            this.txt_srch.Name = "txt_srch";
            this.txt_srch.Size = new System.Drawing.Size(171, 30);
            this.txt_srch.TabIndex = 375;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.AliceBlue;
            this.label2.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(1132, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 23);
            this.label2.TabIndex = 379;
            this.label2.Text = "조회일자 :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Visible = false;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Transparent;
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(492, 7);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(32, 25);
            this.btnSearch.TabIndex = 378;
            this.btnSearch.Tag = "검색";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // srch_date
            // 
            this.srch_date.Checked = false;
            this.srch_date.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.srch_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.srch_date.Location = new System.Drawing.Point(1226, 6);
            this.srch_date.Name = "srch_date";
            this.srch_date.Size = new System.Drawing.Size(100, 29);
            this.srch_date.TabIndex = 376;
            this.srch_date.Value = new System.DateTime(2018, 10, 8, 0, 0, 0, 0);
            this.srch_date.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.panel1.Location = new System.Drawing.Point(0, 33);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1360, 681);
            this.panel1.TabIndex = 19;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btn_stock_no);
            this.splitContainer1.Panel1.Controls.Add(this.btn_stock_ok);
            this.splitContainer1.Panel1.Controls.Add(this.srch_date);
            this.splitContainer1.Panel1.Controls.Add(this.rawStockGrid);
            this.splitContainer1.Panel1.Controls.Add(this.cmb_cd_srch);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.btnSearch);
            this.splitContainer1.Panel1.Controls.Add(this.txt_srch);
            this.splitContainer1.Panel1.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.rawDetailGrid);
            this.splitContainer1.Panel2.Controls.Add(this.panel3);
            this.splitContainer1.Panel2.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.splitContainer1.Size = new System.Drawing.Size(1360, 681);
            this.splitContainer1.SplitterDistance = 350;
            this.splitContainer1.TabIndex = 379;
            // 
            // btn_stock_no
            // 
            this.btn_stock_no.AutoSize = true;
            this.btn_stock_no.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_stock_no.Location = new System.Drawing.Point(106, 7);
            this.btn_stock_no.Name = "btn_stock_no";
            this.btn_stock_no.Size = new System.Drawing.Size(89, 26);
            this.btn_stock_no.TabIndex = 386;
            this.btn_stock_no.TabStop = true;
            this.btn_stock_no.Text = "재고 없음";
            this.btn_stock_no.UseVisualStyleBackColor = true;
            // 
            // btn_stock_ok
            // 
            this.btn_stock_ok.AutoSize = true;
            this.btn_stock_ok.Checked = true;
            this.btn_stock_ok.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_stock_ok.Location = new System.Drawing.Point(12, 7);
            this.btn_stock_ok.Name = "btn_stock_ok";
            this.btn_stock_ok.Size = new System.Drawing.Size(89, 26);
            this.btn_stock_ok.TabIndex = 385;
            this.btn_stock_ok.TabStop = true;
            this.btn_stock_ok.Text = "재고 있음";
            this.btn_stock_ok.UseVisualStyleBackColor = true;
            // 
            // rawStockGrid
            // 
            this.rawStockGrid.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.rawStockGrid.AllowUserToAddRows = false;
            this.rawStockGrid.AllowUserToDeleteRows = false;
            this.rawStockGrid.AllowUserToResizeColumns = false;
            this.rawStockGrid.AllowUserToResizeRows = false;
            this.rawStockGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rawStockGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.rawStockGrid.BackgroundColor = System.Drawing.Color.White;
            this.rawStockGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.rawStockGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.rawStockGrid.ColumnHeadersHeight = 35;
            this.rawStockGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RAW_MAT_CD,
            this.RAW_MAT_NM,
            this.구매처,
            this.구매처코드,
            this.SPEC,
            this.INPUT_AMT,
            this.OUTPUT_AMT,
            this.STOCK_AMT});
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.rawStockGrid.DefaultCellStyle = dataGridViewCellStyle19;
            this.rawStockGrid.EnableHeadersVisualStyles = false;
            this.rawStockGrid.GridColor = System.Drawing.Color.PowderBlue;
            this.rawStockGrid.Location = new System.Drawing.Point(0, 37);
            this.rawStockGrid.Name = "rawStockGrid";
            this.rawStockGrid.RowHeadersVisible = false;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.Color.Black;
            this.rawStockGrid.RowsDefaultCellStyle = dataGridViewCellStyle20;
            this.rawStockGrid.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F);
            this.rawStockGrid.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.rawStockGrid.RowTemplate.Height = 30;
            this.rawStockGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.rawStockGrid.Size = new System.Drawing.Size(1360, 317);
            this.rawStockGrid.TabIndex = 375;
            this.rawStockGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.rawStockGrid_CellDoubleClick);
            this.rawStockGrid.VisibleChanged += new System.EventHandler(this.rawStockGrid_VisibleChanged);
            // 
            // RAW_MAT_CD
            // 
            this.RAW_MAT_CD.FillWeight = 190F;
            this.RAW_MAT_CD.HeaderText = "원자재코드";
            this.RAW_MAT_CD.MinimumWidth = 190;
            this.RAW_MAT_CD.Name = "RAW_MAT_CD";
            this.RAW_MAT_CD.ReadOnly = true;
            this.RAW_MAT_CD.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.RAW_MAT_CD.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.RAW_MAT_CD.Visible = false;
            // 
            // RAW_MAT_NM
            // 
            this.RAW_MAT_NM.FillWeight = 855F;
            this.RAW_MAT_NM.HeaderText = "원자재명";
            this.RAW_MAT_NM.MinimumWidth = 72;
            this.RAW_MAT_NM.Name = "RAW_MAT_NM";
            this.RAW_MAT_NM.ReadOnly = true;
            this.RAW_MAT_NM.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.RAW_MAT_NM.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // 구매처
            // 
            this.구매처.HeaderText = "구매처";
            this.구매처.MinimumWidth = 100;
            this.구매처.Name = "구매처";
            this.구매처.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.구매처.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.구매처.Visible = false;
            // 
            // 구매처코드
            // 
            this.구매처코드.HeaderText = "구매처코드";
            this.구매처코드.MinimumWidth = 100;
            this.구매처코드.Name = "구매처코드";
            this.구매처코드.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.구매처코드.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.구매처코드.Visible = false;
            // 
            // SPEC
            // 
            this.SPEC.FillWeight = 157F;
            this.SPEC.HeaderText = "규격";
            this.SPEC.MinimumWidth = 50;
            this.SPEC.Name = "SPEC";
            this.SPEC.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SPEC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // INPUT_AMT
            // 
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.INPUT_AMT.DefaultCellStyle = dataGridViewCellStyle16;
            this.INPUT_AMT.FillWeight = 119F;
            this.INPUT_AMT.HeaderText = "입고량";
            this.INPUT_AMT.MinimumWidth = 58;
            this.INPUT_AMT.Name = "INPUT_AMT";
            this.INPUT_AMT.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.INPUT_AMT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // OUTPUT_AMT
            // 
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.OUTPUT_AMT.DefaultCellStyle = dataGridViewCellStyle17;
            this.OUTPUT_AMT.FillWeight = 115F;
            this.OUTPUT_AMT.HeaderText = "출고량";
            this.OUTPUT_AMT.MinimumWidth = 58;
            this.OUTPUT_AMT.Name = "OUTPUT_AMT";
            this.OUTPUT_AMT.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.OUTPUT_AMT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // STOCK_AMT
            // 
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.STOCK_AMT.DefaultCellStyle = dataGridViewCellStyle18;
            this.STOCK_AMT.FillWeight = 111F;
            this.STOCK_AMT.HeaderText = "재고량";
            this.STOCK_AMT.MinimumWidth = 58;
            this.STOCK_AMT.Name = "STOCK_AMT";
            this.STOCK_AMT.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.STOCK_AMT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 281);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(660, 44);
            this.label3.TabIndex = 380;
            this.label3.Text = "[일자 - 입고번호] 순으로 입고된 원자재들이 등록됩니다. \n입고번호를 더블클릭 하시면 [원자재관리 / 원자재입고등록] 화면에서 세부 현황을 확인" +
    "하실 수 있습니다.";
            // 
            // rawDetailGrid
            // 
            this.rawDetailGrid.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.rawDetailGrid.AllowUserToAddRows = false;
            this.rawDetailGrid.AllowUserToDeleteRows = false;
            this.rawDetailGrid.AllowUserToResizeColumns = false;
            this.rawDetailGrid.AllowUserToResizeRows = false;
            this.rawDetailGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rawDetailGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.rawDetailGrid.BackgroundColor = System.Drawing.Color.White;
            this.rawDetailGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle21.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.rawDetailGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle21;
            this.rawDetailGrid.ColumnHeadersHeight = 35;
            this.rawDetailGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.INPUT_DATE,
            this.INPUT_CD,
            this.구매처명,
            this.INPUT_SEQ,
            this.dataGridViewTextBoxColumn11,
            this.STORAGE_NM,
            this.LOC_NM,
            this.R_INPUT_AMT,
            this.R_OUTPUT_AMT,
            this.R_STOCK_AMT,
            this.STORAGE_CD,
            this.LOC_CD});
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle27.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle27.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle27.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle27.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle27.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.rawDetailGrid.DefaultCellStyle = dataGridViewCellStyle27;
            this.rawDetailGrid.EnableHeadersVisualStyles = false;
            this.rawDetailGrid.GridColor = System.Drawing.Color.PowderBlue;
            this.rawDetailGrid.Location = new System.Drawing.Point(0, 33);
            this.rawDetailGrid.Name = "rawDetailGrid";
            this.rawDetailGrid.RowHeadersVisible = false;
            dataGridViewCellStyle28.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle28.SelectionBackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle28.SelectionForeColor = System.Drawing.Color.Black;
            this.rawDetailGrid.RowsDefaultCellStyle = dataGridViewCellStyle28;
            this.rawDetailGrid.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F);
            this.rawDetailGrid.RowTemplate.Height = 30;
            this.rawDetailGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.rawDetailGrid.Size = new System.Drawing.Size(1360, 248);
            this.rawDetailGrid.TabIndex = 376;
            this.rawDetailGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.rawDetailGrid_CellDoubleClick);
            this.rawDetailGrid.VisibleChanged += new System.EventHandler(this.rawStockGrid_VisibleChanged);
            this.rawDetailGrid.MouseClick += new System.Windows.Forms.MouseEventHandler(this.rawDetailGrid_MouseClick);
            // 
            // INPUT_DATE
            // 
            this.INPUT_DATE.FillWeight = 50F;
            this.INPUT_DATE.HeaderText = "일자";
            this.INPUT_DATE.MinimumWidth = 50;
            this.INPUT_DATE.Name = "INPUT_DATE";
            this.INPUT_DATE.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // INPUT_CD
            // 
            this.INPUT_CD.FillWeight = 94F;
            this.INPUT_CD.HeaderText = "입고번호";
            this.INPUT_CD.MinimumWidth = 72;
            this.INPUT_CD.Name = "INPUT_CD";
            this.INPUT_CD.ReadOnly = true;
            this.INPUT_CD.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // 구매처명
            // 
            this.구매처명.FillWeight = 291F;
            this.구매처명.HeaderText = "구매처명";
            this.구매처명.MinimumWidth = 72;
            this.구매처명.Name = "구매처명";
            this.구매처명.ReadOnly = true;
            this.구매처명.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.구매처명.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // INPUT_SEQ
            // 
            this.INPUT_SEQ.FillWeight = 170F;
            this.INPUT_SEQ.HeaderText = "원자재입고순번";
            this.INPUT_SEQ.MinimumWidth = 170;
            this.INPUT_SEQ.Name = "INPUT_SEQ";
            this.INPUT_SEQ.ReadOnly = true;
            this.INPUT_SEQ.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.INPUT_SEQ.Visible = false;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.HeaderText = "원자재식별표";
            this.dataGridViewTextBoxColumn11.MinimumWidth = 100;
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn11.Visible = false;
            // 
            // STORAGE_NM
            // 
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.STORAGE_NM.DefaultCellStyle = dataGridViewCellStyle22;
            this.STORAGE_NM.FillWeight = 225F;
            this.STORAGE_NM.HeaderText = "보관창고";
            this.STORAGE_NM.MinimumWidth = 72;
            this.STORAGE_NM.Name = "STORAGE_NM";
            this.STORAGE_NM.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.STORAGE_NM.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // LOC_NM
            // 
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.LOC_NM.DefaultCellStyle = dataGridViewCellStyle23;
            this.LOC_NM.FillWeight = 220F;
            this.LOC_NM.HeaderText = "보관위치";
            this.LOC_NM.MinimumWidth = 72;
            this.LOC_NM.Name = "LOC_NM";
            this.LOC_NM.ReadOnly = true;
            this.LOC_NM.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.LOC_NM.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // R_INPUT_AMT
            // 
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.R_INPUT_AMT.DefaultCellStyle = dataGridViewCellStyle24;
            this.R_INPUT_AMT.FillWeight = 192F;
            this.R_INPUT_AMT.HeaderText = "입고량";
            this.R_INPUT_AMT.MinimumWidth = 58;
            this.R_INPUT_AMT.Name = "R_INPUT_AMT";
            this.R_INPUT_AMT.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // R_OUTPUT_AMT
            // 
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.R_OUTPUT_AMT.DefaultCellStyle = dataGridViewCellStyle25;
            this.R_OUTPUT_AMT.FillWeight = 151F;
            this.R_OUTPUT_AMT.HeaderText = "출고량";
            this.R_OUTPUT_AMT.MinimumWidth = 58;
            this.R_OUTPUT_AMT.Name = "R_OUTPUT_AMT";
            this.R_OUTPUT_AMT.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // R_STOCK_AMT
            // 
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.R_STOCK_AMT.DefaultCellStyle = dataGridViewCellStyle26;
            this.R_STOCK_AMT.FillWeight = 134F;
            this.R_STOCK_AMT.HeaderText = "재고량";
            this.R_STOCK_AMT.MinimumWidth = 58;
            this.R_STOCK_AMT.Name = "R_STOCK_AMT";
            this.R_STOCK_AMT.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // STORAGE_CD
            // 
            this.STORAGE_CD.HeaderText = "보관창고코드";
            this.STORAGE_CD.MinimumWidth = 100;
            this.STORAGE_CD.Name = "STORAGE_CD";
            this.STORAGE_CD.ReadOnly = true;
            this.STORAGE_CD.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.STORAGE_CD.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.STORAGE_CD.Visible = false;
            // 
            // LOC_CD
            // 
            this.LOC_CD.HeaderText = "보관위치코드";
            this.LOC_CD.MinimumWidth = 100;
            this.LOC_CD.Name = "LOC_CD";
            this.LOC_CD.ReadOnly = true;
            this.LOC_CD.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.LOC_CD.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.LOC_CD.Visible = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.label20);
            this.panel3.Controls.Add(this.lbl_raw_nm);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1360, 33);
            this.panel3.TabIndex = 379;
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label20.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label20.Location = new System.Drawing.Point(3, 3);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(143, 26);
            this.label20.TabIndex = 377;
            this.label20.Text = "원자재 세부내역";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_raw_nm
            // 
            this.lbl_raw_nm.BackColor = System.Drawing.Color.White;
            this.lbl_raw_nm.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_raw_nm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_raw_nm.Location = new System.Drawing.Point(152, 7);
            this.lbl_raw_nm.Name = "lbl_raw_nm";
            this.lbl_raw_nm.Size = new System.Drawing.Size(284, 21);
            this.lbl_raw_nm.TabIndex = 378;
            this.lbl_raw_nm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "입고번호";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.Width = 150;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "원자재입고순번";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn2.Width = 170;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "원자재식별표";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn3.Width = 220;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "입고일자";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn4.Width = 200;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "입고량";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn5.Width = 200;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "출고량";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 200;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "재고량";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 200;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "원자재코드";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn8.Width = 190;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "원자재명";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn9.Width = 420;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "규격";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn10.Width = 250;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.HeaderText = "출고량";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.Width = 160;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.HeaderText = "재고량";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.Width = 160;
            // 
            // frm원자재재고현황
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1360, 714);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frm원자재재고현황";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frm원자재재고현황";
            this.Load += new System.EventHandler(this.frm원자재재고현황_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rawStockGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rawDetailGrid)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private Controls.conTextBox txt_srch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DateTimePicker srch_date;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lbl_raw_nm;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.Button btn출력;
        private Controls.conComboBox cmb_cd_srch;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton btn_stock_no;
        private System.Windows.Forms.RadioButton btn_stock_ok;
        private System.Windows.Forms.Label label3;
        private Controls.myDataGridView rawStockGrid;
        private Controls.myDataGridView rawDetailGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn RAW_MAT_CD;
        private System.Windows.Forms.DataGridViewTextBoxColumn RAW_MAT_NM;
        private System.Windows.Forms.DataGridViewTextBoxColumn 구매처;
        private System.Windows.Forms.DataGridViewTextBoxColumn 구매처코드;
        private System.Windows.Forms.DataGridViewTextBoxColumn SPEC;
        private System.Windows.Forms.DataGridViewTextBoxColumn INPUT_AMT;
        private System.Windows.Forms.DataGridViewTextBoxColumn OUTPUT_AMT;
        private System.Windows.Forms.DataGridViewTextBoxColumn STOCK_AMT;
        private Controls.DataGridViewTextBoxColumnEx INPUT_DATE;
        private Controls.DataGridViewTextBoxColumnEx INPUT_CD;
        private System.Windows.Forms.DataGridViewTextBoxColumn 구매처명;
        private Controls.DataGridViewTextBoxColumnEx INPUT_SEQ;
        private Controls.DataGridViewTextBoxColumnEx dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn STORAGE_NM;
        private System.Windows.Forms.DataGridViewTextBoxColumn LOC_NM;
        private Controls.DataGridViewTextBoxColumnEx R_INPUT_AMT;
        private Controls.DataGridViewTextBoxColumnEx R_OUTPUT_AMT;
        private Controls.DataGridViewTextBoxColumnEx R_STOCK_AMT;
        private System.Windows.Forms.DataGridViewTextBoxColumn STORAGE_CD;
        private System.Windows.Forms.DataGridViewTextBoxColumn LOC_CD;
    }
}