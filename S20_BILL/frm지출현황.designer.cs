namespace MES.S20_BILL
{
    partial class frm지출현황
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm지출현황));
            this.btn_excel = new System.Windows.Forms.Button();
            this.grd_pay = new MES.Controls.myDataGridView();
            this.PAY_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PAY_CD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PAY_GUBUN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ACCU_CD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ACCU_NM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STAFF_NM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JUKYO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MONEY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn출력 = new System.Windows.Forms.Button();
            this.lbl_title = new System.Windows.Forms.Label();
            this.pnl_top = new System.Windows.Forms.Panel();
            this.lbl_tab1_date = new System.Windows.Forms.Label();
            this.lbl_tab1_type = new System.Windows.Forms.Label();
            this.cmb_accu = new System.Windows.Forms.ComboBox();
            this.btn_search = new System.Windows.Forms.Button();
            this.lbl_date2_tab1 = new System.Windows.Forms.Label();
            this.start_date = new System.Windows.Forms.DateTimePicker();
            this.end_date = new System.Windows.Forms.DateTimePicker();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblMsg = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grd_pay)).BeginInit();
            this.panel2.SuspendLayout();
            this.pnl_top.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_excel
            // 
            this.btn_excel.BackColor = System.Drawing.Color.White;
            this.btn_excel.FlatAppearance.BorderSize = 0;
            this.btn_excel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_excel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.btn_excel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_excel.Location = new System.Drawing.Point(1081, 5);
            this.btn_excel.Name = "btn_excel";
            this.btn_excel.Size = new System.Drawing.Size(70, 26);
            this.btn_excel.TabIndex = 1;
            this.btn_excel.Text = "엑셀";
            this.btn_excel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_excel.UseVisualStyleBackColor = false;
            this.btn_excel.Visible = false;
            // 
            // grd_pay
            // 
            this.grd_pay.AllowUserToAddRows = false;
            this.grd_pay.AllowUserToDeleteRows = false;
            this.grd_pay.AllowUserToResizeColumns = false;
            this.grd_pay.AllowUserToResizeRows = false;
            this.grd_pay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grd_pay.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grd_pay.BackgroundColor = System.Drawing.Color.White;
            this.grd_pay.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grd_pay.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grd_pay.ColumnHeadersHeight = 35;
            this.grd_pay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grd_pay.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PAY_DATE,
            this.PAY_CD,
            this.PAY_GUBUN,
            this.ACCU_CD,
            this.ACCU_NM,
            this.STAFF_NM,
            this.JUKYO,
            this.MONEY});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grd_pay.DefaultCellStyle = dataGridViewCellStyle7;
            this.grd_pay.EnableHeadersVisualStyles = false;
            this.grd_pay.GridColor = System.Drawing.Color.Silver;
            this.grd_pay.Location = new System.Drawing.Point(0, 66);
            this.grd_pay.Name = "grd_pay";
            this.grd_pay.ReadOnly = true;
            this.grd_pay.RowHeadersVisible = false;
            this.grd_pay.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grd_pay.RowTemplate.Height = 23;
            this.grd_pay.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grd_pay.Size = new System.Drawing.Size(1360, 648);
            this.grd_pay.TabIndex = 5;
            // 
            // PAY_DATE
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.PAY_DATE.DefaultCellStyle = dataGridViewCellStyle2;
            this.PAY_DATE.FillWeight = 72F;
            this.PAY_DATE.HeaderText = "지출일자";
            this.PAY_DATE.MinimumWidth = 72;
            this.PAY_DATE.Name = "PAY_DATE";
            this.PAY_DATE.ReadOnly = true;
            this.PAY_DATE.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PAY_DATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PAY_CD
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.PAY_CD.DefaultCellStyle = dataGridViewCellStyle3;
            this.PAY_CD.FillWeight = 132F;
            this.PAY_CD.HeaderText = "지출번호";
            this.PAY_CD.MinimumWidth = 72;
            this.PAY_CD.Name = "PAY_CD";
            this.PAY_CD.ReadOnly = true;
            this.PAY_CD.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PAY_CD.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PAY_GUBUN
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.PAY_GUBUN.DefaultCellStyle = dataGridViewCellStyle4;
            this.PAY_GUBUN.FillWeight = 157F;
            this.PAY_GUBUN.HeaderText = "지급구분";
            this.PAY_GUBUN.MinimumWidth = 72;
            this.PAY_GUBUN.Name = "PAY_GUBUN";
            this.PAY_GUBUN.ReadOnly = true;
            this.PAY_GUBUN.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PAY_GUBUN.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ACCU_CD
            // 
            this.ACCU_CD.HeaderText = "계정코드";
            this.ACCU_CD.MinimumWidth = 100;
            this.ACCU_CD.Name = "ACCU_CD";
            this.ACCU_CD.ReadOnly = true;
            this.ACCU_CD.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ACCU_CD.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ACCU_CD.Visible = false;
            // 
            // ACCU_NM
            // 
            this.ACCU_NM.FillWeight = 269F;
            this.ACCU_NM.HeaderText = "계정명";
            this.ACCU_NM.MinimumWidth = 58;
            this.ACCU_NM.Name = "ACCU_NM";
            this.ACCU_NM.ReadOnly = true;
            this.ACCU_NM.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ACCU_NM.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // STAFF_NM
            // 
            this.STAFF_NM.FillWeight = 278F;
            this.STAFF_NM.HeaderText = "지급사원";
            this.STAFF_NM.MinimumWidth = 72;
            this.STAFF_NM.Name = "STAFF_NM";
            this.STAFF_NM.ReadOnly = true;
            this.STAFF_NM.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.STAFF_NM.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // JUKYO
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.JUKYO.DefaultCellStyle = dataGridViewCellStyle5;
            this.JUKYO.FillWeight = 389F;
            this.JUKYO.HeaderText = "적요";
            this.JUKYO.MinimumWidth = 50;
            this.JUKYO.Name = "JUKYO";
            this.JUKYO.ReadOnly = true;
            this.JUKYO.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.JUKYO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // MONEY
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.MONEY.DefaultCellStyle = dataGridViewCellStyle6;
            this.MONEY.FillWeight = 62F;
            this.MONEY.HeaderText = "지급액";
            this.MONEY.MinimumWidth = 58;
            this.MONEY.Name = "MONEY";
            this.MONEY.ReadOnly = true;
            this.MONEY.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.MONEY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
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
            this.btnClose.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.btnClose.Image = global::MES.Properties.Resources.newnewCloseBtn;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(1285, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(72, 29);
            this.btnClose.TabIndex = 455;
            this.btnClose.Tag = "종료";
            this.btnClose.Text = "닫기";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.btn출력);
            this.panel2.Controls.Add(this.lbl_title);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.btn_excel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1360, 33);
            this.panel2.TabIndex = 456;
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
            this.btn출력.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Bold);
            this.btn출력.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.btn출력.Image = global::MES.Properties.Resources.newDownloadBtn;
            this.btn출력.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn출력.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn출력.Location = new System.Drawing.Point(1205, 3);
            this.btn출력.Name = "btn출력";
            this.btn출력.Size = new System.Drawing.Size(71, 29);
            this.btn출력.TabIndex = 456;
            this.btn출력.TabStop = false;
            this.btn출력.Tag = "출력";
            this.btn출력.Text = "엑셀";
            this.btn출력.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn출력.UseVisualStyleBackColor = false;
            this.btn출력.Click += new System.EventHandler(this.btn출력_Click);
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.Font = new System.Drawing.Font("SpoqaHanSans-Bold", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.lbl_title.Location = new System.Drawing.Point(9, -2); //new System.Drawing.Point(16, 2);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(94, 31);
            this.lbl_title.TabIndex = 385;
            this.lbl_title.Text = "지출현황";
            // 
            // pnl_top
            // 
            this.pnl_top.Controls.Add(this.lbl_tab1_date);
            this.pnl_top.Controls.Add(this.lbl_tab1_type);
            this.pnl_top.Controls.Add(this.cmb_accu);
            this.pnl_top.Controls.Add(this.btn_search);
            this.pnl_top.Controls.Add(this.lbl_date2_tab1);
            this.pnl_top.Controls.Add(this.start_date);
            this.pnl_top.Controls.Add(this.end_date);
            this.pnl_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_top.Location = new System.Drawing.Point(0, 33);
            this.pnl_top.Name = "pnl_top";
            this.pnl_top.Size = new System.Drawing.Size(1360, 33);
            this.pnl_top.TabIndex = 457;
            // 
            // lbl_tab1_date
            // 
            this.lbl_tab1_date.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lbl_tab1_date.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F);
            this.lbl_tab1_date.Location = new System.Drawing.Point(5, 3);
            this.lbl_tab1_date.Name = "lbl_tab1_date";
            this.lbl_tab1_date.Size = new System.Drawing.Size(72, 29);
            this.lbl_tab1_date.TabIndex = 61;
            this.lbl_tab1_date.Text = "검색기간";
            this.lbl_tab1_date.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_tab1_type
            // 
            this.lbl_tab1_type.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lbl_tab1_type.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F);
            this.lbl_tab1_type.Location = new System.Drawing.Point(346, 3);
            this.lbl_tab1_type.Name = "lbl_tab1_type";
            this.lbl_tab1_type.Size = new System.Drawing.Size(63, 29);
            this.lbl_tab1_type.TabIndex = 63;
            this.lbl_tab1_type.Text = "계정명";
            this.lbl_tab1_type.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmb_accu
            // 
            this.cmb_accu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_accu.FormattingEnabled = true;
            this.cmb_accu.Items.AddRange(new object[] {
            "전체선택"});
            this.cmb_accu.Location = new System.Drawing.Point(411, 2);
            this.cmb_accu.Name = "cmb_accu";
            this.cmb_accu.Size = new System.Drawing.Size(142, 30);
            this.cmb_accu.TabIndex = 3;
            // 
            // btn_search
            // 
            this.btn_search.BackColor = System.Drawing.Color.White;
            this.btn_search.FlatAppearance.BorderSize = 0;
            this.btn_search.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_search.Image = ((System.Drawing.Image)(resources.GetObject("btn_search.Image")));
            this.btn_search.Location = new System.Drawing.Point(553, 3);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(31, 26);
            this.btn_search.TabIndex = 4;
            this.btn_search.UseVisualStyleBackColor = false;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // lbl_date2_tab1
            // 
            this.lbl_date2_tab1.AutoSize = true;
            this.lbl_date2_tab1.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F);
            this.lbl_date2_tab1.Location = new System.Drawing.Point(200, 6);
            this.lbl_date2_tab1.Name = "lbl_date2_tab1";
            this.lbl_date2_tab1.Size = new System.Drawing.Size(18, 22);
            this.lbl_date2_tab1.TabIndex = 65;
            this.lbl_date2_tab1.Text = "~";
            // 
            // start_date
            // 
            this.start_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.start_date.Location = new System.Drawing.Point(79, 3);
            this.start_date.Name = "start_date";
            this.start_date.Size = new System.Drawing.Size(114, 29);
            this.start_date.TabIndex = 1;
            this.start_date.Value = new System.DateTime(2019, 11, 18, 0, 0, 0, 0);
            // 
            // end_date
            // 
            this.end_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.end_date.Location = new System.Drawing.Point(224, 3);
            this.end_date.Name = "end_date";
            this.end_date.Size = new System.Drawing.Size(115, 29);
            this.end_date.TabIndex = 2;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.FillWeight = 90F;
            this.dataGridViewTextBoxColumn1.HeaderText = "계정코드";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 90;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "계정명";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 180;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "담당사원";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 200;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.FillWeight = 90F;
            this.dataGridViewTextBoxColumn4.HeaderText = "지출일자";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Visible = false;
            this.dataGridViewTextBoxColumn4.Width = 200;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "적요";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 400;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "금액";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 200;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "적요";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 300;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn8.HeaderText = "지급액";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // lblMsg
            // 
            this.lblMsg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblMsg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMsg.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 12F, System.Drawing.FontStyle.Bold);
            this.lblMsg.ForeColor = System.Drawing.Color.Green;
            this.lblMsg.Location = new System.Drawing.Point(524, 329);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(313, 57);
            this.lblMsg.TabIndex = 458;
            this.lblMsg.Text = "Loading ...";
            this.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMsg.Visible = false;
            // 
            // frm지출현황
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1360, 714);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.pnl_top);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.grd_pay);
            this.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frm지출현황";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frm지출현황";
            this.Load += new System.EventHandler(this.frm지출현황_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grd_pay)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnl_top.ResumeLayout(false);
            this.pnl_top.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_excel;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Panel pnl_top;
        private System.Windows.Forms.Label lbl_tab1_date;
        private System.Windows.Forms.Label lbl_tab1_type;
        private System.Windows.Forms.ComboBox cmb_accu;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.Label lbl_date2_tab1;
        private System.Windows.Forms.DateTimePicker start_date;
        private System.Windows.Forms.DateTimePicker end_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.Button btn출력;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.DataGridViewTextBoxColumn PAY_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn PAY_CD;
        private System.Windows.Forms.DataGridViewTextBoxColumn PAY_GUBUN;
        private System.Windows.Forms.DataGridViewTextBoxColumn ACCU_CD;
        private System.Windows.Forms.DataGridViewTextBoxColumn ACCU_NM;
        private System.Windows.Forms.DataGridViewTextBoxColumn STAFF_NM;
        private System.Windows.Forms.DataGridViewTextBoxColumn JUKYO;
        private System.Windows.Forms.DataGridViewTextBoxColumn MONEY;
        private Controls.myDataGridView grd_pay;
    }
}