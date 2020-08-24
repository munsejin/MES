namespace MES.Popup
{
    partial class pop계산서수금검색
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pop계산서수금검색));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblStatus = new MES.Controls.conLabel();
            this.cmbPage = new MES.Controls.conComboBox();
            this.btnFirst = new System.Windows.Forms.Button();
            this.lblPage = new System.Windows.Forms.Label();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.GridRecord = new MES.Controls.myDataGridView();
            this.CHECK = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.수금일자 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.번호 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.구분 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.수금액 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.할인액 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.합계금액 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.비고 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label15 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.start_date = new System.Windows.Forms.DateTimePicker();
            this.label21 = new System.Windows.Forms.Label();
            this.end_date = new System.Windows.Forms.DateTimePicker();
            this.lbl_cust_nm = new System.Windows.Forms.Label();
            this.btn_srch_sale_or_soo = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridRecord)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.btnExit);
            this.panel2.Controls.Add(this.lblTitle);
            this.panel2.Controls.Add(this.lblStatus);
            this.panel2.Controls.Add(this.cmbPage);
            this.panel2.Controls.Add(this.btnFirst);
            this.panel2.Controls.Add(this.lblPage);
            this.panel2.Controls.Add(this.btnPrevious);
            this.panel2.Controls.Add(this.btnLast);
            this.panel2.Controls.Add(this.btnNext);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1034, 33);
            this.panel2.TabIndex = 108;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Bold);
            this.btnExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnExit.Location = new System.Drawing.Point(952, 1);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(70, 29);
            this.btnExit.TabIndex = 2;
            this.btnExit.TabStop = false;
            this.btnExit.Tag = "종료";
            this.btnExit.Text = "닫기";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("SpoqaHanSans-Bold", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.lblTitle.Location = new System.Drawing.Point(11, 1);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(100, 31);
            this.lblTitle.TabIndex = 95;
            this.lblTitle.Text = "수금 검색";
            // 
            // lblStatus
            // 
            this.lblStatus._BorderColor = System.Drawing.Color.LightGray;
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblStatus.Location = new System.Drawing.Point(737, 9);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(94, 22);
            this.lblStatus.TabIndex = 301;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStatus.Visible = false;
            // 
            // cmbPage
            // 
            this.cmbPage._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.cmbPage._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmbPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPage.FormattingEnabled = true;
            this.cmbPage.Location = new System.Drawing.Point(591, 12);
            this.cmbPage.Name = "cmbPage";
            this.cmbPage.Size = new System.Drawing.Size(77, 20);
            this.cmbPage.TabIndex = 295;
            this.cmbPage.TabStop = false;
            this.cmbPage.Visible = false;
            // 
            // btnFirst
            // 
            this.btnFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFirst.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnFirst.Location = new System.Drawing.Point(674, 9);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(28, 22);
            this.btnFirst.TabIndex = 296;
            this.btnFirst.TabStop = false;
            this.btnFirst.Text = "|<";
            this.btnFirst.Visible = false;
            // 
            // lblPage
            // 
            this.lblPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPage.AutoSize = true;
            this.lblPage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lblPage.Location = new System.Drawing.Point(516, 16);
            this.lblPage.Name = "lblPage";
            this.lblPage.Size = new System.Drawing.Size(69, 12);
            this.lblPage.TabIndex = 300;
            this.lblPage.Text = "페이지 이동";
            this.lblPage.Visible = false;
            // 
            // btnPrevious
            // 
            this.btnPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnPrevious.Location = new System.Drawing.Point(702, 9);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(29, 22);
            this.btnPrevious.TabIndex = 297;
            this.btnPrevious.TabStop = false;
            this.btnPrevious.Text = "<";
            this.btnPrevious.Visible = false;
            // 
            // btnLast
            // 
            this.btnLast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLast.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnLast.Location = new System.Drawing.Point(866, 9);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(28, 22);
            this.btnLast.TabIndex = 299;
            this.btnLast.TabStop = false;
            this.btnLast.Text = ">|";
            this.btnLast.Visible = false;
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnNext.Location = new System.Drawing.Point(837, 9);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(29, 22);
            this.btnNext.TabIndex = 298;
            this.btnNext.TabStop = false;
            this.btnNext.Text = ">";
            this.btnNext.Visible = false;
            // 
            // GridRecord
            // 
            this.GridRecord.AllowUserToAddRows = false;
            this.GridRecord.AllowUserToDeleteRows = false;
            this.GridRecord.AllowUserToResizeRows = false;
            this.GridRecord.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridRecord.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridRecord.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.GridRecord.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GridRecord.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.GridRecord.ColumnHeadersHeight = 30;
            this.GridRecord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.GridRecord.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CHECK,
            this.수금일자,
            this.번호,
            this.구분,
            this.수금액,
            this.할인액,
            this.합계금액,
            this.비고});
            this.GridRecord.EnableHeadersVisualStyles = false;
            this.GridRecord.GridColor = System.Drawing.Color.PowderBlue;
            this.GridRecord.Location = new System.Drawing.Point(10, 109);
            this.GridRecord.Name = "GridRecord";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridRecord.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.GridRecord.RowHeadersVisible = false;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.GridRecord.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.GridRecord.RowTemplate.Height = 23;
            this.GridRecord.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.GridRecord.Size = new System.Drawing.Size(1015, 398);
            this.GridRecord.TabIndex = 111;
            this.GridRecord.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridRecord_CellClick);
            // 
            // CHECK
            // 
            this.CHECK.FillWeight = 89F;
            this.CHECK.HeaderText = "[ ]";
            this.CHECK.MinimumWidth = 50;
            this.CHECK.Name = "CHECK";
            this.CHECK.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // 수금일자
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.수금일자.DefaultCellStyle = dataGridViewCellStyle2;
            this.수금일자.FillWeight = 165F;
            this.수금일자.HeaderText = "수금일자";
            this.수금일자.MinimumWidth = 72;
            this.수금일자.Name = "수금일자";
            this.수금일자.ReadOnly = true;
            this.수금일자.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.수금일자.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // 번호
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.번호.DefaultCellStyle = dataGridViewCellStyle3;
            this.번호.FillWeight = 92F;
            this.번호.HeaderText = "번호";
            this.번호.MinimumWidth = 50;
            this.번호.Name = "번호";
            this.번호.ReadOnly = true;
            this.번호.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.번호.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // 구분
            // 
            this.구분.FillWeight = 170F;
            this.구분.HeaderText = "구분";
            this.구분.MinimumWidth = 50;
            this.구분.Name = "구분";
            this.구분.ReadOnly = true;
            this.구분.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.구분.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // 수금액
            // 
            this.수금액.FillWeight = 155F;
            this.수금액.HeaderText = "수금액";
            this.수금액.MinimumWidth = 58;
            this.수금액.Name = "수금액";
            this.수금액.ReadOnly = true;
            this.수금액.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.수금액.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // 할인액
            // 
            this.할인액.FillWeight = 144F;
            this.할인액.HeaderText = "할인액";
            this.할인액.MinimumWidth = 58;
            this.할인액.Name = "할인액";
            this.할인액.ReadOnly = true;
            this.할인액.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.할인액.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // 합계금액
            // 
            this.합계금액.FillWeight = 136F;
            this.합계금액.HeaderText = "합계금액";
            this.합계금액.MinimumWidth = 72;
            this.합계금액.Name = "합계금액";
            this.합계금액.ReadOnly = true;
            this.합계금액.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.합계금액.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // 비고
            // 
            this.비고.FillWeight = 54F;
            this.비고.HeaderText = "비고";
            this.비고.MinimumWidth = 50;
            this.비고.Name = "비고";
            this.비고.ReadOnly = true;
            this.비고.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.비고.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.Gainsboro;
            this.label15.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F);
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label15.Location = new System.Drawing.Point(10, 40);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(82, 29);
            this.label15.TabIndex = 112;
            this.label15.Text = "거래처";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "거래처코드";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 120;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "거래처명";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 220;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "사업자번호";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "업태";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 80;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "종목";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 80;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "거래처담당자명";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 120;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "전화번호";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 140;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "담당사원";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 140;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Gainsboro;
            this.label1.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(10, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 29);
            this.label1.TabIndex = 113;
            this.label1.Text = "수금기간";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // start_date
            // 
            this.start_date.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F);
            this.start_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.start_date.Location = new System.Drawing.Point(98, 76);
            this.start_date.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.start_date.Name = "start_date";
            this.start_date.Size = new System.Drawing.Size(102, 29);
            this.start_date.TabIndex = 116;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label21.Location = new System.Drawing.Point(203, 80);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(19, 22);
            this.label21.TabIndex = 117;
            this.label21.Text = "~";
            // 
            // end_date
            // 
            this.end_date.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F);
            this.end_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.end_date.Location = new System.Drawing.Point(223, 76);
            this.end_date.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.end_date.Name = "end_date";
            this.end_date.Size = new System.Drawing.Size(100, 29);
            this.end_date.TabIndex = 115;
            // 
            // lbl_cust_nm
            // 
            this.lbl_cust_nm.AutoSize = true;
            this.lbl_cust_nm.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F);
            this.lbl_cust_nm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbl_cust_nm.Location = new System.Drawing.Point(101, 44);
            this.lbl_cust_nm.Name = "lbl_cust_nm";
            this.lbl_cust_nm.Size = new System.Drawing.Size(13, 22);
            this.lbl_cust_nm.TabIndex = 445;
            this.lbl_cust_nm.Text = " ";
            // 
            // btn_srch_sale_or_soo
            // 
            this.btn_srch_sale_or_soo.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btn_srch_sale_or_soo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_srch_sale_or_soo.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F);
            this.btn_srch_sale_or_soo.Location = new System.Drawing.Point(463, 510);
            this.btn_srch_sale_or_soo.Name = "btn_srch_sale_or_soo";
            this.btn_srch_sale_or_soo.Size = new System.Drawing.Size(107, 33);
            this.btn_srch_sale_or_soo.TabIndex = 446;
            this.btn_srch_sale_or_soo.Text = "적 용";
            this.btn_srch_sale_or_soo.UseVisualStyleBackColor = true;
            this.btn_srch_sale_or_soo.Click += new System.EventHandler(this.btn_srch_sale_or_soo_Click);
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
            this.btnSearch.Location = new System.Drawing.Point(329, 75);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(33, 33);
            this.btnSearch.TabIndex = 110;
            this.btnSearch.TabStop = false;
            this.btnSearch.Tag = "검색";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // pop계산서수금검색
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 545);
            this.Controls.Add(this.btn_srch_sale_or_soo);
            this.Controls.Add(this.lbl_cust_nm);
            this.Controls.Add(this.start_date);
            this.Controls.Add(this.end_date);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GridRecord);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label21);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "pop계산서수금검색";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.pop계산서수금검색_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridRecord)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnSearch;
        private Controls.conLabel lblStatus;
        private Controls.conComboBox cmbPage;
        private System.Windows.Forms.Label lblPage;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker start_date;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.DateTimePicker end_date;
        private System.Windows.Forms.Label lbl_cust_nm;
        private System.Windows.Forms.Button btn_srch_sale_or_soo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CHECK;
        private System.Windows.Forms.DataGridViewTextBoxColumn 수금일자;
        private System.Windows.Forms.DataGridViewTextBoxColumn 번호;
        private System.Windows.Forms.DataGridViewTextBoxColumn 구분;
        private System.Windows.Forms.DataGridViewTextBoxColumn 수금액;
        private System.Windows.Forms.DataGridViewTextBoxColumn 할인액;
        private System.Windows.Forms.DataGridViewTextBoxColumn 합계금액;
        private System.Windows.Forms.DataGridViewTextBoxColumn 비고;
        private Controls.myDataGridView GridRecord;

    }
}