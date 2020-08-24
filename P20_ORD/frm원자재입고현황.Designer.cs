namespace MES.P20_ORD
{
    partial class frm원자재입고현황
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm원자재입고현황));
            this.panel1 = new System.Windows.Forms.Panel();
            this.inputRmGrid = new MES.Controls.myDataGridView();
            this.INPUT_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INPUT_CD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SEQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CUST_NM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RAW_MAT_NM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SPEC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RAW_MAT_GUBUN_NM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UNIT_NM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TEMP_AMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TOTAL_AMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRICE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TOTAL_MONEY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HEAT_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RAW_MAT_CD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UNIT_CD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CUST_CD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RAW_MAT_GUBUN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.end_date = new System.Windows.Forms.DateTimePicker();
            this.btnClose = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.start_date = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmb_cd_srch = new MES.Controls.conComboBox();
            this.txt_srch = new MES.Controls.conTextBox();
            this.btn출력 = new System.Windows.Forms.Button();
            this.lbl_title = new System.Windows.Forms.Label();
            this.txt_srch2 = new MES.Controls.conTextBox();
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
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inputRmGrid)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.inputRmGrid);
            this.panel1.Location = new System.Drawing.Point(2, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1358, 707);
            this.panel1.TabIndex = 18;
            // 
            // inputRmGrid
            // 
            this.inputRmGrid.AllowUserToAddRows = false;
            this.inputRmGrid.AllowUserToDeleteRows = false;
            this.inputRmGrid.AllowUserToOrderColumns = true;
            this.inputRmGrid.AllowUserToResizeColumns = false;
            this.inputRmGrid.AllowUserToResizeRows = false;
            this.inputRmGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputRmGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.inputRmGrid.BackgroundColor = System.Drawing.Color.White;
            this.inputRmGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.PowderBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.inputRmGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.inputRmGrid.ColumnHeadersHeight = 40;
            this.inputRmGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.INPUT_DATE,
            this.INPUT_CD,
            this.SEQ,
            this.CUST_NM,
            this.RAW_MAT_NM,
            this.SPEC,
            this.RAW_MAT_GUBUN_NM,
            this.UNIT_NM,
            this.TEMP_AMT,
            this.TOTAL_AMT,
            this.PRICE,
            this.TOTAL_MONEY,
            this.HEAT_NO,
            this.RAW_MAT_CD,
            this.UNIT_CD,
            this.CUST_CD,
            this.RAW_MAT_GUBUN});
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F);
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.inputRmGrid.DefaultCellStyle = dataGridViewCellStyle13;
            this.inputRmGrid.EnableHeadersVisualStyles = false;
            this.inputRmGrid.GridColor = System.Drawing.Color.PowderBlue;
            this.inputRmGrid.Location = new System.Drawing.Point(1, 1);
            this.inputRmGrid.Name = "inputRmGrid";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.inputRmGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.inputRmGrid.RowHeadersVisible = false;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.Black;
            this.inputRmGrid.RowsDefaultCellStyle = dataGridViewCellStyle15;
            this.inputRmGrid.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F);
            this.inputRmGrid.RowTemplate.Height = 30;
            this.inputRmGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.inputRmGrid.Size = new System.Drawing.Size(1357, 677);
            this.inputRmGrid.TabIndex = 378;
            // 
            // INPUT_DATE
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.INPUT_DATE.DefaultCellStyle = dataGridViewCellStyle2;
            this.INPUT_DATE.HeaderText = "입고일자";
            this.INPUT_DATE.Name = "INPUT_DATE";
            this.INPUT_DATE.Width = 97;
            // 
            // INPUT_CD
            // 
            this.INPUT_CD.HeaderText = "입고번호";
            this.INPUT_CD.Name = "INPUT_CD";
            this.INPUT_CD.Width = 97;
            // 
            // SEQ
            // 
            this.SEQ.HeaderText = "SEQ";
            this.SEQ.Name = "SEQ";
            this.SEQ.Width = 65;
            // 
            // CUST_NM
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.CUST_NM.DefaultCellStyle = dataGridViewCellStyle3;
            this.CUST_NM.HeaderText = "거래처명";
            this.CUST_NM.Name = "CUST_NM";
            this.CUST_NM.Width = 97;
            // 
            // RAW_MAT_NM
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.RAW_MAT_NM.DefaultCellStyle = dataGridViewCellStyle4;
            this.RAW_MAT_NM.HeaderText = "원자재명";
            this.RAW_MAT_NM.Name = "RAW_MAT_NM";
            this.RAW_MAT_NM.ReadOnly = true;
            this.RAW_MAT_NM.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.RAW_MAT_NM.Width = 113;
            // 
            // SPEC
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.SPEC.DefaultCellStyle = dataGridViewCellStyle5;
            this.SPEC.HeaderText = "규격";
            this.SPEC.Name = "SPEC";
            this.SPEC.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SPEC.Width = 65;
            // 
            // RAW_MAT_GUBUN_NM
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.RAW_MAT_GUBUN_NM.DefaultCellStyle = dataGridViewCellStyle6;
            this.RAW_MAT_GUBUN_NM.HeaderText = "구분";
            this.RAW_MAT_GUBUN_NM.Name = "RAW_MAT_GUBUN_NM";
            this.RAW_MAT_GUBUN_NM.Width = 65;
            // 
            // UNIT_NM
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.UNIT_NM.DefaultCellStyle = dataGridViewCellStyle7;
            this.UNIT_NM.HeaderText = "단위";
            this.UNIT_NM.Name = "UNIT_NM";
            this.UNIT_NM.ReadOnly = true;
            this.UNIT_NM.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.UNIT_NM.Width = 65;
            // 
            // TEMP_AMT
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.TEMP_AMT.DefaultCellStyle = dataGridViewCellStyle8;
            this.TEMP_AMT.HeaderText = "입고 수량";
            this.TEMP_AMT.Name = "TEMP_AMT";
            this.TEMP_AMT.Width = 102;
            // 
            // TOTAL_AMT
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.TOTAL_AMT.DefaultCellStyle = dataGridViewCellStyle9;
            this.TOTAL_AMT.HeaderText = "최종수량";
            this.TOTAL_AMT.Name = "TOTAL_AMT";
            this.TOTAL_AMT.ReadOnly = true;
            this.TOTAL_AMT.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.TOTAL_AMT.Width = 97;
            // 
            // PRICE
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.PRICE.DefaultCellStyle = dataGridViewCellStyle10;
            this.PRICE.HeaderText = "단가";
            this.PRICE.Name = "PRICE";
            this.PRICE.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.PRICE.Visible = false;
            this.PRICE.Width = 65;
            // 
            // TOTAL_MONEY
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.TOTAL_MONEY.DefaultCellStyle = dataGridViewCellStyle11;
            this.TOTAL_MONEY.HeaderText = "금액";
            this.TOTAL_MONEY.Name = "TOTAL_MONEY";
            this.TOTAL_MONEY.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.TOTAL_MONEY.Width = 65;
            // 
            // HEAT_NO
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.HEAT_NO.DefaultCellStyle = dataGridViewCellStyle12;
            this.HEAT_NO.HeaderText = "HeatNo";
            this.HEAT_NO.Name = "HEAT_NO";
            this.HEAT_NO.Visible = false;
            this.HEAT_NO.Width = 87;
            // 
            // RAW_MAT_CD
            // 
            this.RAW_MAT_CD.HeaderText = "원자재코드";
            this.RAW_MAT_CD.Name = "RAW_MAT_CD";
            this.RAW_MAT_CD.Visible = false;
            this.RAW_MAT_CD.Width = 129;
            // 
            // UNIT_CD
            // 
            this.UNIT_CD.HeaderText = "단위코드";
            this.UNIT_CD.Name = "UNIT_CD";
            this.UNIT_CD.Visible = false;
            this.UNIT_CD.Width = 97;
            // 
            // CUST_CD
            // 
            this.CUST_CD.HeaderText = "거래처코드";
            this.CUST_CD.Name = "CUST_CD";
            this.CUST_CD.Visible = false;
            this.CUST_CD.Width = 113;
            // 
            // RAW_MAT_GUBUN
            // 
            this.RAW_MAT_GUBUN.HeaderText = "구분코드";
            this.RAW_MAT_GUBUN.Name = "RAW_MAT_GUBUN";
            this.RAW_MAT_GUBUN.Visible = false;
            this.RAW_MAT_GUBUN.Width = 97;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(201, 4);
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
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(1043, 1);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(33, 30);
            this.btnSearch.TabIndex = 378;
            this.btnSearch.Tag = "검색";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // end_date
            // 
            this.end_date.Checked = false;
            this.end_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.end_date.Location = new System.Drawing.Point(448, 6);
            this.end_date.Name = "end_date";
            this.end_date.Size = new System.Drawing.Size(100, 21);
            this.end_date.TabIndex = 377;
            this.end_date.Value = new System.DateTime(2018, 10, 8, 0, 0, 0, 0);
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
            this.btnClose.Location = new System.Drawing.Point(1292, 1);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(65, 29);
            this.btnClose.TabIndex = 10;
            this.btnClose.Tag = "종료";
            this.btnClose.Text = "닫기";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.Location = new System.Drawing.Point(403, 5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 23);
            this.label7.TabIndex = 375;
            this.label7.Text = "~";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // start_date
            // 
            this.start_date.Checked = false;
            this.start_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.start_date.Location = new System.Drawing.Point(293, 6);
            this.start_date.Name = "start_date";
            this.start_date.Size = new System.Drawing.Size(100, 21);
            this.start_date.TabIndex = 376;
            this.start_date.Value = new System.DateTime(2018, 10, 8, 0, 0, 0, 0);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.PaleTurquoise;
            this.panel2.Controls.Add(this.cmb_cd_srch);
            this.panel2.Controls.Add(this.txt_srch);
            this.panel2.Controls.Add(this.btn출력);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btnSearch);
            this.panel2.Controls.Add(this.lbl_title);
            this.panel2.Controls.Add(this.end_date);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.start_date);
            this.panel2.Controls.Add(this.txt_srch2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1360, 33);
            this.panel2.TabIndex = 17;
            // 
            // cmb_cd_srch
            // 
            this.cmb_cd_srch._BorderColor = System.Drawing.Color.Transparent;
            this.cmb_cd_srch._FocusedBackColor = System.Drawing.Color.White;
            this.cmb_cd_srch.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cmb_cd_srch.FormattingEnabled = true;
            this.cmb_cd_srch.Location = new System.Drawing.Point(732, 6);
            this.cmb_cd_srch.Name = "cmb_cd_srch";
            this.cmb_cd_srch.Size = new System.Drawing.Size(128, 20);
            this.cmb_cd_srch.TabIndex = 397;
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
            this.txt_srch.Location = new System.Drawing.Point(866, 5);
            this.txt_srch.MaxLength = 20;
            this.txt_srch.Name = "txt_srch";
            this.txt_srch.Size = new System.Drawing.Size(171, 22);
            this.txt_srch.TabIndex = 396;
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
            this.btn출력.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.btn출력.Image = global::MES.Properties.Resources.newPrintBtn;
            this.btn출력.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn출력.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn출력.Location = new System.Drawing.Point(1217, 2);
            this.btn출력.Name = "btn출력";
            this.btn출력.Size = new System.Drawing.Size(69, 29);
            this.btn출력.TabIndex = 384;
            this.btn출력.Tag = "출력";
            this.btn출력.Text = "출력";
            this.btn출력.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn출력.UseVisualStyleBackColor = false;
            this.btn출력.Click += new System.EventHandler(this.btn출력_Click);
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.lbl_title.Location = new System.Drawing.Point(9, -2); //new System.Drawing.Point(10, 5);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(148, 22);
            this.lbl_title.TabIndex = 93;
            this.lbl_title.Text = "자재입고현황";
            // 
            // txt_srch2
            // 
            this.txt_srch2._AutoTab = true;
            this.txt_srch2._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.txt_srch2._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txt_srch2._WaterMarkColor = System.Drawing.Color.Gray;
            this.txt_srch2._WaterMarkText = "";
            this.txt_srch2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_srch2.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_srch2.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.txt_srch2.Location = new System.Drawing.Point(136, 4);
            this.txt_srch2.MaxLength = 20;
            this.txt_srch2.Name = "txt_srch2";
            this.txt_srch2.Size = new System.Drawing.Size(146, 22);
            this.txt_srch2.TabIndex = 375;
            this.txt_srch2.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "제품코드";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.Width = 200;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "제품명";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn2.Visible = false;
            this.dataGridViewTextBoxColumn2.Width = 500;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "규격";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn3.Visible = false;
            this.dataGridViewTextBoxColumn3.Width = 250;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "기초재고량";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn4.Width = 150;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "포장일자";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn5.Width = 150;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "LOTSUB";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn6.Width = 150;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "바코드";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 200;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "투입량";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn8.Width = 120;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "수량";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn9.Width = 80;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "단가";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn10.Visible = false;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.HeaderText = "금액";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn11.Width = 120;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.HeaderText = "HeatNo";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.Width = 120;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.HeaderText = "원자재코드";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.Visible = false;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.HeaderText = "단위코드";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.Visible = false;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.HeaderText = "거래처코드";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.Visible = false;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.HeaderText = "구분코드";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.Visible = false;
            // 
            // frm원자재입고현황
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1360, 714);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frm원자재입고현황";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frm원자재원장현황";
            this.Load += new System.EventHandler(this.frm원자재입고현황_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.inputRmGrid)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.conTextBox txt_srch2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker end_date;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker start_date;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridView inputRmGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.Button btn출력;
        private Controls.conComboBox cmb_cd_srch;
        private Controls.conTextBox txt_srch;
        private System.Windows.Forms.DataGridViewTextBoxColumn INPUT_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn INPUT_CD;
        private System.Windows.Forms.DataGridViewTextBoxColumn SEQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn CUST_NM;
        private System.Windows.Forms.DataGridViewTextBoxColumn RAW_MAT_NM;
        private System.Windows.Forms.DataGridViewTextBoxColumn SPEC;
        private System.Windows.Forms.DataGridViewTextBoxColumn RAW_MAT_GUBUN_NM;
        private System.Windows.Forms.DataGridViewTextBoxColumn UNIT_NM;
        private System.Windows.Forms.DataGridViewTextBoxColumn TEMP_AMT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TOTAL_AMT;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRICE;
        private System.Windows.Forms.DataGridViewTextBoxColumn TOTAL_MONEY;
        private System.Windows.Forms.DataGridViewTextBoxColumn HEAT_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn RAW_MAT_CD;
        private System.Windows.Forms.DataGridViewTextBoxColumn UNIT_CD;
        private System.Windows.Forms.DataGridViewTextBoxColumn CUST_CD;
        private System.Windows.Forms.DataGridViewTextBoxColumn RAW_MAT_GUBUN;
    }
}