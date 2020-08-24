namespace MES.P85_BAS
{
    partial class frm단가관리
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm단가관리));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txt_cust_nm = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_cnt = new System.Windows.Forms.TextBox();
            this.lbl_cust_gbn = new System.Windows.Forms.TextBox();
            this.grd_ucost = new MES.Controls.conDataGridView();
            this.CUST_CD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PROD_NM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PROD_CD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.B_BOX_PRICE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.S_BOX_PRICE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UNIT_PRICE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INSTAFF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INTIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UPSTAFF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UPTIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbo_cust = new System.Windows.Forms.ComboBox();
            this.btn_sales = new System.Windows.Forms.Button();
            this.txt_cust_cd = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_title = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_del = new System.Windows.Forms.Button();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cust_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd_ucost)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.btnSearch);
            this.panel4.Controls.Add(this.txt_cust_nm);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.lbl_cnt);
            this.panel4.Controls.Add(this.lbl_cust_gbn);
            this.panel4.Controls.Add(this.grd_ucost);
            this.panel4.Controls.Add(this.cbo_cust);
            this.panel4.Controls.Add(this.btn_sales);
            this.panel4.Controls.Add(this.txt_cust_cd);
            this.panel4.Location = new System.Drawing.Point(0, 40);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1233, 615);
            this.panel4.TabIndex = 356;
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
            this.btnSearch.Location = new System.Drawing.Point(232, 1);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(33, 30);
            this.btnSearch.TabIndex = 379;
            this.btnSearch.Tag = "검색";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // txt_cust_nm
            // 
            this.txt_cust_nm.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_cust_nm.Location = new System.Drawing.Point(566, 3);
            this.txt_cust_nm.Name = "txt_cust_nm";
            this.txt_cust_nm.Size = new System.Drawing.Size(267, 29);
            this.txt_cust_nm.TabIndex = 92;
            this.txt_cust_nm.Visible = false;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label5.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(9, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 29);
            this.label5.TabIndex = 13;
            this.label5.Text = "매출처";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_cnt
            // 
            this.lbl_cnt.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.lbl_cnt.Location = new System.Drawing.Point(165, 617);
            this.lbl_cnt.Name = "lbl_cnt";
            this.lbl_cnt.Size = new System.Drawing.Size(100, 21);
            this.lbl_cnt.TabIndex = 89;
            this.lbl_cnt.Text = "lbl_cnt";
            this.lbl_cnt.Visible = false;
            // 
            // lbl_cust_gbn
            // 
            this.lbl_cust_gbn.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.lbl_cust_gbn.Location = new System.Drawing.Point(43, 616);
            this.lbl_cust_gbn.Name = "lbl_cust_gbn";
            this.lbl_cust_gbn.Size = new System.Drawing.Size(116, 21);
            this.lbl_cust_gbn.TabIndex = 83;
            this.lbl_cust_gbn.Text = "lbl_cust_gbn";
            this.lbl_cust_gbn.Visible = false;
            // 
            // grd_ucost
            // 
            this.grd_ucost._BorderColor = System.Drawing.Color.White;
            this.grd_ucost._DirKey = "R";
            this.grd_ucost._KeyboardCmd = "0";
            this.grd_ucost._KeyInput = "";
            this.grd_ucost._LastCol = -1;
            this.grd_ucost._LastRow = -1;
            this.grd_ucost.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.grd_ucost.AllowUserToAddRows = false;
            this.grd_ucost.AllowUserToDeleteRows = false;
            this.grd_ucost.AllowUserToResizeColumns = false;
            this.grd_ucost.AllowUserToResizeRows = false;
            this.grd_ucost.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grd_ucost.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grd_ucost.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.MintCream;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grd_ucost.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grd_ucost.ColumnHeadersHeight = 35;
            this.grd_ucost.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grd_ucost.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CUST_CD,
            this.PROD_NM,
            this.PROD_CD,
            this.B_BOX_PRICE,
            this.S_BOX_PRICE,
            this.UNIT_PRICE,
            this.INSTAFF,
            this.INTIME,
            this.UPSTAFF,
            this.UPTIME,
            this.Column6});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 12F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grd_ucost.DefaultCellStyle = dataGridViewCellStyle11;
            this.grd_ucost.EnableHeadersVisualStyles = false;
            this.grd_ucost.Location = new System.Drawing.Point(7, 36);
            this.grd_ucost.Name = "grd_ucost";
            this.grd_ucost.RowHeadersVisible = false;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.MintCream;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grd_ucost.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.grd_ucost.RowTemplate.Height = 23;
            this.grd_ucost.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grd_ucost.Size = new System.Drawing.Size(1213, 570);
            this.grd_ucost.TabIndex = 79;
            // 
            // CUST_CD
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.CUST_CD.DefaultCellStyle = dataGridViewCellStyle2;
            this.CUST_CD.Frozen = true;
            this.CUST_CD.HeaderText = "거래처코드";
            this.CUST_CD.MinimumWidth = 100;
            this.CUST_CD.Name = "CUST_CD";
            this.CUST_CD.ReadOnly = true;
            this.CUST_CD.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CUST_CD.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CUST_CD.Visible = false;
            // 
            // PROD_NM
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.PROD_NM.DefaultCellStyle = dataGridViewCellStyle3;
            this.PROD_NM.FillWeight = 697F;
            this.PROD_NM.HeaderText = "상품명";
            this.PROD_NM.MinimumWidth = 58;
            this.PROD_NM.Name = "PROD_NM";
            this.PROD_NM.ReadOnly = true;
            this.PROD_NM.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PROD_NM.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PROD_CD
            // 
            this.PROD_CD.FillWeight = 163F;
            this.PROD_CD.HeaderText = "상품코드";
            this.PROD_CD.MinimumWidth = 72;
            this.PROD_CD.Name = "PROD_CD";
            this.PROD_CD.ReadOnly = true;
            this.PROD_CD.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PROD_CD.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // B_BOX_PRICE
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.B_BOX_PRICE.DefaultCellStyle = dataGridViewCellStyle4;
            this.B_BOX_PRICE.FillWeight = 121F;
            this.B_BOX_PRICE.HeaderText = "박스단가";
            this.B_BOX_PRICE.MinimumWidth = 72;
            this.B_BOX_PRICE.Name = "B_BOX_PRICE";
            this.B_BOX_PRICE.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.B_BOX_PRICE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // S_BOX_PRICE
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.S_BOX_PRICE.DefaultCellStyle = dataGridViewCellStyle5;
            this.S_BOX_PRICE.FillWeight = 117F;
            this.S_BOX_PRICE.HeaderText = "중간단가";
            this.S_BOX_PRICE.MinimumWidth = 72;
            this.S_BOX_PRICE.Name = "S_BOX_PRICE";
            this.S_BOX_PRICE.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.S_BOX_PRICE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // UNIT_PRICE
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.UNIT_PRICE.DefaultCellStyle = dataGridViewCellStyle6;
            this.UNIT_PRICE.FillWeight = 112F;
            this.UNIT_PRICE.HeaderText = "낱개단가";
            this.UNIT_PRICE.MinimumWidth = 72;
            this.UNIT_PRICE.Name = "UNIT_PRICE";
            this.UNIT_PRICE.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.UNIT_PRICE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // INSTAFF
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.INSTAFF.DefaultCellStyle = dataGridViewCellStyle7;
            this.INSTAFF.HeaderText = "등록자";
            this.INSTAFF.MinimumWidth = 100;
            this.INSTAFF.Name = "INSTAFF";
            this.INSTAFF.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.INSTAFF.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.INSTAFF.Visible = false;
            // 
            // INTIME
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.INTIME.DefaultCellStyle = dataGridViewCellStyle8;
            this.INTIME.HeaderText = "등록시간";
            this.INTIME.MinimumWidth = 100;
            this.INTIME.Name = "INTIME";
            this.INTIME.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.INTIME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.INTIME.Visible = false;
            // 
            // UPSTAFF
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.UPSTAFF.DefaultCellStyle = dataGridViewCellStyle9;
            this.UPSTAFF.HeaderText = "수정자";
            this.UPSTAFF.MinimumWidth = 100;
            this.UPSTAFF.Name = "UPSTAFF";
            this.UPSTAFF.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.UPSTAFF.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.UPSTAFF.Visible = false;
            // 
            // UPTIME
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.UPTIME.DefaultCellStyle = dataGridViewCellStyle10;
            this.UPTIME.HeaderText = "수정시간";
            this.UPTIME.MinimumWidth = 100;
            this.UPTIME.Name = "UPTIME";
            this.UPTIME.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.UPTIME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.UPTIME.Visible = false;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "inUp";
            this.Column6.MinimumWidth = 100;
            this.Column6.Name = "Column6";
            this.Column6.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column6.Visible = false;
            // 
            // cbo_cust
            // 
            this.cbo_cust.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbo_cust.FormattingEnabled = true;
            this.cbo_cust.Location = new System.Drawing.Point(66, 2);
            this.cbo_cust.Name = "cbo_cust";
            this.cbo_cust.Size = new System.Drawing.Size(160, 30);
            this.cbo_cust.TabIndex = 65;
            // 
            // btn_sales
            // 
            this.btn_sales.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_sales.Location = new System.Drawing.Point(833, 4);
            this.btn_sales.Name = "btn_sales";
            this.btn_sales.Size = new System.Drawing.Size(18, 23);
            this.btn_sales.TabIndex = 91;
            this.btn_sales.Text = "▼";
            this.btn_sales.UseVisualStyleBackColor = true;
            this.btn_sales.Visible = false;
            this.btn_sales.Click += new System.EventHandler(this.btn_sales_Click);
            // 
            // txt_cust_cd
            // 
            this.txt_cust_cd.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_cust_cd.Location = new System.Drawing.Point(1031, 3);
            this.txt_cust_cd.Name = "txt_cust_cd";
            this.txt_cust_cd.Size = new System.Drawing.Size(197, 29);
            this.txt_cust_cd.TabIndex = 2;
            this.txt_cust_cd.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.lbl_title);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.btnNew);
            this.panel2.Controls.Add(this.btn_save);
            this.panel2.Controls.Add(this.btn_del);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.panel2.ForeColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1233, 39);
            this.panel2.TabIndex = 357;
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.Font = new System.Drawing.Font("SpoqaHanSans-Bold", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.lbl_title.Location = new System.Drawing.Point(9, -2); //new System.Drawing.Point(6, 6);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(84, 28);
            this.lbl_title.TabIndex = 93;
            this.lbl_title.Text = "단가정리";
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
            this.btnClose.Location = new System.Drawing.Point(1158, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(72, 29);
            this.btnClose.TabIndex = 10;
            this.btnClose.Tag = "종료";
            this.btnClose.Text = "닫기";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.BackColor = System.Drawing.Color.Transparent;
            this.btnNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNew.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnNew.FlatAppearance.BorderSize = 0;
            this.btnNew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnNew.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.btnNew.Image = global::MES.Properties.Resources.newnewBtn;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNew.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnNew.Location = new System.Drawing.Point(929, 4);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(72, 29);
            this.btnNew.TabIndex = 20;
            this.btnNew.Tag = "추가";
            this.btnNew.Text = "신규";
            this.btnNew.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.UseVisualStyleBackColor = false;
            // 
            // btn_save
            // 
            this.btn_save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_save.BackColor = System.Drawing.Color.Transparent;
            this.btn_save.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_save.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_save.FlatAppearance.BorderSize = 0;
            this.btn_save.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_save.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_save.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.btn_save.Image = global::MES.Properties.Resources.newSaveBtn;
            this.btn_save.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_save.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_save.Location = new System.Drawing.Point(1008, 4);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(72, 29);
            this.btn_save.TabIndex = 1;
            this.btn_save.Tag = "저장";
            this.btn_save.Text = "저장";
            this.btn_save.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_del
            // 
            this.btn_del.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_del.BackColor = System.Drawing.Color.Transparent;
            this.btn_del.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_del.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_del.Enabled = false;
            this.btn_del.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_del.FlatAppearance.BorderSize = 0;
            this.btn_del.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_del.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_del.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_del.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.btn_del.Image = global::MES.Properties.Resources.newDelBtn;
            this.btn_del.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_del.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_del.Location = new System.Drawing.Point(1084, 4);
            this.btn_del.Name = "btn_del";
            this.btn_del.Size = new System.Drawing.Size(72, 29);
            this.btn_del.TabIndex = 2;
            this.btn_del.Tag = "삭제";
            this.btn_del.Text = "삭제";
            this.btn_del.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_del.UseVisualStyleBackColor = false;
            this.btn_del.Click += new System.EventHandler(this.btn_del_Click);
            // 
            // Column9
            // 
            this.Column9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column9.DefaultCellStyle = dataGridViewCellStyle13;
            this.Column9.FillWeight = 70F;
            this.Column9.HeaderText = "코드";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // Column10
            // 
            this.Column10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Column10.DefaultCellStyle = dataGridViewCellStyle14;
            this.Column10.FillWeight = 190F;
            this.Column10.HeaderText = "상품명";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            // 
            // Column11
            // 
            this.Column11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column11.DefaultCellStyle = dataGridViewCellStyle15;
            this.Column11.HeaderText = "규격";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            // 
            // Column12
            // 
            this.Column12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column12.DefaultCellStyle = dataGridViewCellStyle16;
            this.Column12.FillWeight = 80F;
            this.Column12.HeaderText = "박스단가";
            this.Column12.Name = "Column12";
            // 
            // cust_code
            // 
            this.cust_code.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cust_code.FillWeight = 80F;
            this.cust_code.HeaderText = "중간단가";
            this.cust_code.Name = "cust_code";
            this.cust_code.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle17;
            this.Column1.FillWeight = 80F;
            this.Column1.HeaderText = "낱개단가";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // frm단가관리
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1233, 655);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel4);
            this.Name = "frm단가관리";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frm단가관리";
            this.Load += new System.EventHandler(this.frm단가관리_Load);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd_ucost)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox lbl_cnt;
        private System.Windows.Forms.TextBox lbl_cust_gbn;
        private Controls.conDataGridView grd_ucost;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn cust_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.ComboBox cbo_cust;
        private System.Windows.Forms.Button btn_sales;
        private System.Windows.Forms.TextBox txt_cust_cd;
        private System.Windows.Forms.TextBox txt_cust_nm;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_del;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn CUST_CD;
        private System.Windows.Forms.DataGridViewTextBoxColumn PROD_NM;
        private System.Windows.Forms.DataGridViewTextBoxColumn PROD_CD;
        private System.Windows.Forms.DataGridViewTextBoxColumn B_BOX_PRICE;
        private System.Windows.Forms.DataGridViewTextBoxColumn S_BOX_PRICE;
        private System.Windows.Forms.DataGridViewTextBoxColumn UNIT_PRICE;
        private System.Windows.Forms.DataGridViewTextBoxColumn INSTAFF;
        private System.Windows.Forms.DataGridViewTextBoxColumn INTIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn UPSTAFF;
        private System.Windows.Forms.DataGridViewTextBoxColumn UPTIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
    }
}