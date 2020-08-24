namespace MES.P20_ORD
{
    partial class frm원자재입출고원장
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm원자재입출고원장));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.cmb_cd_srch = new MES.Controls.conComboBox();
            this.btn출력 = new System.Windows.Forms.Button();
            this.chk_stock = new System.Windows.Forms.CheckBox();
            this.txt_srch = new MES.Controls.conTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lbl_title = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.srch_date = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_raw_nm = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.rawDetailGrid = new MES.Controls.myDataGridView();
            this.INPUT_DATE = new MES.Controls.DataGridViewTextBoxColumnEx();
            this.INPUT_CD = new MES.Controls.DataGridViewTextBoxColumnEx();
            this.INPUT_SEQ = new MES.Controls.DataGridViewTextBoxColumnEx();
            this.dataGridViewTextBoxColumn11 = new MES.Controls.DataGridViewTextBoxColumnEx();
            this.R_INPUT_AMT = new MES.Controls.DataGridViewTextBoxColumnEx();
            this.R_OUTPUT_AMT = new MES.Controls.DataGridViewTextBoxColumnEx();
            this.R_STOCK_AMT = new MES.Controls.DataGridViewTextBoxColumnEx();
            this.rawStockGrid = new MES.Controls.myDataGridView();
            this.RAW_MAT_CD = new MES.Controls.DataGridViewTextBoxColumnEx();
            this.RAW_MAT_NM = new MES.Controls.DataGridViewTextBoxColumnEx();
            this.SPEC = new MES.Controls.DataGridViewTextBoxColumnEx();
            this.INPUT_AMT = new MES.Controls.DataGridViewTextBoxColumnEx();
            this.OUTPUT_AMT = new MES.Controls.DataGridViewTextBoxColumnEx();
            this.STOCK_AMT = new MES.Controls.DataGridViewTextBoxColumnEx();
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
            ((System.ComponentModel.ISupportInitialize)(this.rawDetailGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rawStockGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.cmb_cd_srch);
            this.panel2.Controls.Add(this.btn출력);
            this.panel2.Controls.Add(this.chk_stock);
            this.panel2.Controls.Add(this.txt_srch);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btnSearch);
            this.panel2.Controls.Add(this.lbl_title);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.srch_date);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.panel2.ForeColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1360, 33);
            this.panel2.TabIndex = 18;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.PaleTurquoise;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button1.Location = new System.Drawing.Point(1148, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 29);
            this.button1.TabIndex = 384;
            this.button1.Tag = "출력";
            this.button1.Text = "새로고침";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmb_cd_srch
            // 
            this.cmb_cd_srch._BorderColor = System.Drawing.Color.Transparent;
            this.cmb_cd_srch._FocusedBackColor = System.Drawing.Color.White;
            this.cmb_cd_srch.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cmb_cd_srch.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cmb_cd_srch.FormattingEnabled = true;
            this.cmb_cd_srch.Location = new System.Drawing.Point(658, 6);
            this.cmb_cd_srch.Name = "cmb_cd_srch";
            this.cmb_cd_srch.Size = new System.Drawing.Size(128, 25);
            this.cmb_cd_srch.TabIndex = 383;
            // 
            // btn출력
            // 
            this.btn출력.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn출력.BackColor = System.Drawing.Color.Transparent;
            this.btn출력.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn출력.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn출력.FlatAppearance.BorderColor = System.Drawing.Color.PaleTurquoise;
            this.btn출력.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn출력.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn출력.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn출력.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.btn출력.Image = global::MES.Properties.Resources.newPrintBtn;
            this.btn출력.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn출력.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn출력.Location = new System.Drawing.Point(1223, 3);
            this.btn출력.Name = "btn출력";
            this.btn출력.Size = new System.Drawing.Size(69, 29);
            this.btn출력.TabIndex = 382;
            this.btn출력.Tag = "출력";
            this.btn출력.Text = "출력";
            this.btn출력.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn출력.UseVisualStyleBackColor = false;
            this.btn출력.Click += new System.EventHandler(this.btn출력_Click);
            // 
            // chk_stock
            // 
            this.chk_stock.AutoSize = true;
            this.chk_stock.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chk_stock.Location = new System.Drawing.Point(474, 7);
            this.chk_stock.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chk_stock.Name = "chk_stock";
            this.chk_stock.Size = new System.Drawing.Size(146, 21);
            this.chk_stock.TabIndex = 381;
            this.chk_stock.Text = "재고 있는 것만 조회";
            this.chk_stock.UseVisualStyleBackColor = true;
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
            this.txt_srch.Location = new System.Drawing.Point(792, 5);
            this.txt_srch.MaxLength = 20;
            this.txt_srch.Name = "txt_srch";
            this.txt_srch.Size = new System.Drawing.Size(171, 22);
            this.txt_srch.TabIndex = 375;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(222, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 23);
            this.label2.TabIndex = 379;
            this.label2.Text = "조회일자";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(968, 1);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(33, 30);
            this.btnSearch.TabIndex = 378;
            this.btnSearch.Tag = "검색";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.Font = new System.Drawing.Font("SpoqaHanSans-Bold", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.lbl_title.Location = new System.Drawing.Point(9, -2); //new System.Drawing.Point(6, 3);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(145, 25);
            this.lbl_title.TabIndex = 93;
            this.lbl_title.Text = "자재입출고원장";
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
            this.btnClose.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.btnClose.Image = global::MES.Properties.Resources.newnewCloseBtn;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(1292, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(65, 29);
            this.btnClose.TabIndex = 10;
            this.btnClose.Tag = "종료";
            this.btnClose.Text = "닫기";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // srch_date
            // 
            this.srch_date.Checked = false;
            this.srch_date.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.srch_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.srch_date.Location = new System.Drawing.Point(314, 4);
            this.srch_date.Name = "srch_date";
            this.srch_date.Size = new System.Drawing.Size(100, 25);
            this.srch_date.TabIndex = 376;
            this.srch_date.Value = new System.DateTime(2018, 10, 8, 0, 0, 0, 0);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.lbl_raw_nm);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.rawDetailGrid);
            this.panel1.Controls.Add(this.rawStockGrid);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.panel1.Location = new System.Drawing.Point(0, 33);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1360, 681);
            this.panel1.TabIndex = 19;
            // 
            // lbl_raw_nm
            // 
            this.lbl_raw_nm.BackColor = System.Drawing.Color.White;
            this.lbl_raw_nm.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_raw_nm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_raw_nm.Location = new System.Drawing.Point(154, 346);
            this.lbl_raw_nm.Name = "lbl_raw_nm";
            this.lbl_raw_nm.Size = new System.Drawing.Size(284, 26);
            this.lbl_raw_nm.TabIndex = 378;
            this.lbl_raw_nm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.Color.AliceBlue;
            this.label20.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label20.Location = new System.Drawing.Point(2, 351);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(143, 26);
            this.label20.TabIndex = 377;
            this.label20.Text = "원자재 세부내역";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rawDetailGrid
            // 
            this.rawDetailGrid.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.rawDetailGrid.AllowUserToAddRows = false;
            this.rawDetailGrid.AllowUserToDeleteRows = false;
            this.rawDetailGrid.AllowUserToOrderColumns = true;
            this.rawDetailGrid.AllowUserToResizeColumns = false;
            this.rawDetailGrid.AllowUserToResizeRows = false;
            this.rawDetailGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rawDetailGrid.BackgroundColor = System.Drawing.Color.White;
            this.rawDetailGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.rawDetailGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.rawDetailGrid.ColumnHeadersHeight = 40;
            this.rawDetailGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.rawDetailGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.INPUT_DATE,
            this.INPUT_CD,
            this.INPUT_SEQ,
            this.dataGridViewTextBoxColumn11,
            this.R_INPUT_AMT,
            this.R_OUTPUT_AMT,
            this.R_STOCK_AMT});
            this.rawDetailGrid.EnableHeadersVisualStyles = false;
            this.rawDetailGrid.GridColor = System.Drawing.Color.PowderBlue;
            this.rawDetailGrid.Location = new System.Drawing.Point(0, 380);
            this.rawDetailGrid.Name = "rawDetailGrid";
            this.rawDetailGrid.ReadOnly = true;
            this.rawDetailGrid.RowHeadersVisible = false;
            this.rawDetailGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.rawDetailGrid.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.rawDetailGrid.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F);
            this.rawDetailGrid.RowTemplate.Height = 30;
            this.rawDetailGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.rawDetailGrid.Size = new System.Drawing.Size(1362, 299);
            this.rawDetailGrid.TabIndex = 376;
            // 
            // INPUT_DATE
            // 
            this.INPUT_DATE.HeaderText = "입고일자";
            this.INPUT_DATE.Name = "INPUT_DATE";
            this.INPUT_DATE.ReadOnly = true;
            this.INPUT_DATE.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.INPUT_DATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.INPUT_DATE.Width = 200;
            // 
            // INPUT_CD
            // 
            this.INPUT_CD.HeaderText = "입고번호";
            this.INPUT_CD.Name = "INPUT_CD";
            this.INPUT_CD.ReadOnly = true;
            this.INPUT_CD.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.INPUT_CD.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.INPUT_CD.Width = 150;
            // 
            // INPUT_SEQ
            // 
            this.INPUT_SEQ.HeaderText = "원자재입고순번";
            this.INPUT_SEQ.Name = "INPUT_SEQ";
            this.INPUT_SEQ.ReadOnly = true;
            this.INPUT_SEQ.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.INPUT_SEQ.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.INPUT_SEQ.Width = 170;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.HeaderText = "원자재식별표";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn11.Width = 220;
            // 
            // R_INPUT_AMT
            // 
            this.R_INPUT_AMT.HeaderText = "입고량";
            this.R_INPUT_AMT.Name = "R_INPUT_AMT";
            this.R_INPUT_AMT.ReadOnly = true;
            this.R_INPUT_AMT.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.R_INPUT_AMT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.R_INPUT_AMT.Width = 200;
            // 
            // R_OUTPUT_AMT
            // 
            this.R_OUTPUT_AMT.HeaderText = "출고량";
            this.R_OUTPUT_AMT.Name = "R_OUTPUT_AMT";
            this.R_OUTPUT_AMT.ReadOnly = true;
            this.R_OUTPUT_AMT.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.R_OUTPUT_AMT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.R_OUTPUT_AMT.Width = 200;
            // 
            // R_STOCK_AMT
            // 
            this.R_STOCK_AMT.HeaderText = "재고량";
            this.R_STOCK_AMT.Name = "R_STOCK_AMT";
            this.R_STOCK_AMT.ReadOnly = true;
            this.R_STOCK_AMT.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.R_STOCK_AMT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.R_STOCK_AMT.Width = 190;
            // 
            // rawStockGrid
            // 
            this.rawStockGrid.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.rawStockGrid.AllowUserToAddRows = false;
            this.rawStockGrid.AllowUserToDeleteRows = false;
            this.rawStockGrid.AllowUserToOrderColumns = true;
            this.rawStockGrid.AllowUserToResizeColumns = false;
            this.rawStockGrid.AllowUserToResizeRows = false;
            this.rawStockGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rawStockGrid.BackgroundColor = System.Drawing.Color.White;
            this.rawStockGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.rawStockGrid.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.rawStockGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.rawStockGrid.ColumnHeadersHeight = 40;
            this.rawStockGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.rawStockGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RAW_MAT_CD,
            this.RAW_MAT_NM,
            this.SPEC,
            this.INPUT_AMT,
            this.OUTPUT_AMT,
            this.STOCK_AMT});
            this.rawStockGrid.EnableHeadersVisualStyles = false;
            this.rawStockGrid.GridColor = System.Drawing.Color.PowderBlue;
            this.rawStockGrid.Location = new System.Drawing.Point(-1, -3);
            this.rawStockGrid.Name = "rawStockGrid";
            this.rawStockGrid.ReadOnly = true;
            this.rawStockGrid.RowHeadersVisible = false;
            this.rawStockGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.rawStockGrid.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.rawStockGrid.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F);
            this.rawStockGrid.RowTemplate.Height = 30;
            this.rawStockGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.rawStockGrid.Size = new System.Drawing.Size(1362, 354);
            this.rawStockGrid.TabIndex = 375;
            this.rawStockGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.rawStockGrid_CellDoubleClick);
            // 
            // RAW_MAT_CD
            // 
            this.RAW_MAT_CD.HeaderText = "원자재코드";
            this.RAW_MAT_CD.Name = "RAW_MAT_CD";
            this.RAW_MAT_CD.ReadOnly = true;
            this.RAW_MAT_CD.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.RAW_MAT_CD.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.RAW_MAT_CD.Width = 190;
            // 
            // RAW_MAT_NM
            // 
            this.RAW_MAT_NM.HeaderText = "원자재명";
            this.RAW_MAT_NM.Name = "RAW_MAT_NM";
            this.RAW_MAT_NM.ReadOnly = true;
            this.RAW_MAT_NM.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.RAW_MAT_NM.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.RAW_MAT_NM.Width = 420;
            // 
            // SPEC
            // 
            this.SPEC.HeaderText = "규격";
            this.SPEC.Name = "SPEC";
            this.SPEC.ReadOnly = true;
            this.SPEC.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.SPEC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.SPEC.Width = 250;
            // 
            // INPUT_AMT
            // 
            this.INPUT_AMT.HeaderText = "입고량";
            this.INPUT_AMT.Name = "INPUT_AMT";
            this.INPUT_AMT.ReadOnly = true;
            this.INPUT_AMT.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.INPUT_AMT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.INPUT_AMT.Width = 160;
            // 
            // OUTPUT_AMT
            // 
            this.OUTPUT_AMT.HeaderText = "출고량";
            this.OUTPUT_AMT.Name = "OUTPUT_AMT";
            this.OUTPUT_AMT.ReadOnly = true;
            this.OUTPUT_AMT.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.OUTPUT_AMT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.OUTPUT_AMT.Width = 160;
            // 
            // STOCK_AMT
            // 
            this.STOCK_AMT.HeaderText = "재고량";
            this.STOCK_AMT.Name = "STOCK_AMT";
            this.STOCK_AMT.ReadOnly = true;
            this.STOCK_AMT.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.STOCK_AMT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.STOCK_AMT.Width = 150;
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
            // frm원자재입출고원장
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1360, 714);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frm원자재입출고원장";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frm원자재재고현황";
            this.Load += new System.EventHandler(this.frm원자재입출고원장_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rawDetailGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rawStockGrid)).EndInit();
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
        private System.Windows.Forms.DataGridView rawStockGrid;
        private System.Windows.Forms.DataGridView rawDetailGrid;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.CheckBox chk_stock;
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
        private System.Windows.Forms.Button button1;
        private Controls.DataGridViewTextBoxColumnEx INPUT_DATE;
        private Controls.DataGridViewTextBoxColumnEx INPUT_CD;
        private Controls.DataGridViewTextBoxColumnEx INPUT_SEQ;
        private Controls.DataGridViewTextBoxColumnEx dataGridViewTextBoxColumn11;
        private Controls.DataGridViewTextBoxColumnEx R_INPUT_AMT;
        private Controls.DataGridViewTextBoxColumnEx R_OUTPUT_AMT;
        private Controls.DataGridViewTextBoxColumnEx R_STOCK_AMT;
        private Controls.DataGridViewTextBoxColumnEx RAW_MAT_CD;
        private Controls.DataGridViewTextBoxColumnEx RAW_MAT_NM;
        private Controls.DataGridViewTextBoxColumnEx SPEC;
        private Controls.DataGridViewTextBoxColumnEx INPUT_AMT;
        private Controls.DataGridViewTextBoxColumnEx OUTPUT_AMT;
        private Controls.DataGridViewTextBoxColumnEx STOCK_AMT;
    }
}