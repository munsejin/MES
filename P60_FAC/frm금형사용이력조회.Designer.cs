namespace MES.P60_FAC
{
    partial class frm금형사용이력조회
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm금형사용이력조회));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnClose = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.conTextBox1 = new MES.Controls.conTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_title = new System.Windows.Forms.Label();
            this.dateTimePicker3 = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.grd_mold_sub = new MES.Controls.myDataGridView();
            this.W_INST_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FLOW_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ITEM_CD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ITEM_NM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INST_AMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COMPLETE_YN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataItemGrid = new MES.Controls.myDataGridView();
            this.MOLD_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MOLD_NM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WEIGHT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MOLD_GUBUN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STORAGE_CD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STORAGE_NM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INPUT_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COMMENT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd_mold_sub)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataItemGrid)).BeginInit();
            this.SuspendLayout();
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
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(31, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 28);
            this.label4.TabIndex = 377;
            this.label4.Text = "금형종류";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel3.Controls.Add(this.label4);
            this.panel3.Location = new System.Drawing.Point(1, 35);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1354, 35);
            this.panel3.TabIndex = 389;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.PaleTurquoise;
            this.panel2.Controls.Add(this.conTextBox1);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.lbl_title);
            this.panel2.Controls.Add(this.dateTimePicker3);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.dateTimePicker2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1360, 33);
            this.panel2.TabIndex = 388;
            // 
            // conTextBox1
            // 
            this.conTextBox1._AutoTab = true;
            this.conTextBox1._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.conTextBox1._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.conTextBox1._WaterMarkColor = System.Drawing.Color.Gray;
            this.conTextBox1._WaterMarkText = "";
            this.conTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.conTextBox1.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.conTextBox1.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.conTextBox1.Location = new System.Drawing.Point(928, 6);
            this.conTextBox1.MaxLength = 20;
            this.conTextBox1.Name = "conTextBox1";
            this.conTextBox1.Size = new System.Drawing.Size(171, 22);
            this.conTextBox1.TabIndex = 380;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(1104, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(33, 30);
            this.button1.TabIndex = 381;
            this.button1.Tag = "검색";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(351, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 23);
            this.label2.TabIndex = 350;
            this.label2.Text = "출고일자";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(813, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 23);
            this.label3.TabIndex = 382;
            this.label3.Text = "제품";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.lbl_title.Location = new System.Drawing.Point(9, -2); //new System.Drawing.Point(10, 5);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(194, 22);
            this.lbl_title.TabIndex = 93;
            this.lbl_title.Text = "금형사용이력조회";
            // 
            // dateTimePicker3
            // 
            this.dateTimePicker3.Checked = false;
            this.dateTimePicker3.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker3.Location = new System.Drawing.Point(654, 6);
            this.dateTimePicker3.Name = "dateTimePicker3";
            this.dateTimePicker3.Size = new System.Drawing.Size(156, 21);
            this.dateTimePicker3.TabIndex = 348;
            this.dateTimePicker3.Value = new System.DateTime(2018, 10, 8, 0, 0, 0, 0);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.Location = new System.Drawing.Point(608, 5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 23);
            this.label7.TabIndex = 346;
            this.label7.Text = "~";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Checked = false;
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(444, 6);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(154, 21);
            this.dateTimePicker2.TabIndex = 347;
            this.dateTimePicker2.Value = new System.DateTime(2018, 10, 8, 0, 0, 0, 0);
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(31, 1);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(170, 28);
            this.label10.TabIndex = 377;
            this.label10.Text = "사용이력";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel4.Controls.Add(this.label10);
            this.panel4.Location = new System.Drawing.Point(2, 408);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1354, 32);
            this.panel4.TabIndex = 391;
            // 
            // grd_mold_sub
            // 
            this.grd_mold_sub.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.grd_mold_sub.AllowUserToAddRows = false;
            this.grd_mold_sub.AllowUserToDeleteRows = false;
            this.grd_mold_sub.AllowUserToOrderColumns = true;
            this.grd_mold_sub.AllowUserToResizeColumns = false;
            this.grd_mold_sub.AllowUserToResizeRows = false;
            this.grd_mold_sub.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grd_mold_sub.BackgroundColor = System.Drawing.Color.White;
            this.grd_mold_sub.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grd_mold_sub.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grd_mold_sub.ColumnHeadersHeight = 40;
            this.grd_mold_sub.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.W_INST_DATE,
            this.FLOW_DATE,
            this.ITEM_CD,
            this.ITEM_NM,
            this.INST_AMT,
            this.COMPLETE_YN});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grd_mold_sub.DefaultCellStyle = dataGridViewCellStyle2;
            this.grd_mold_sub.EnableHeadersVisualStyles = false;
            this.grd_mold_sub.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.grd_mold_sub.Location = new System.Drawing.Point(1, 440);
            this.grd_mold_sub.Name = "grd_mold_sub";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grd_mold_sub.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grd_mold_sub.RowHeadersVisible = false;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.grd_mold_sub.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.grd_mold_sub.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 15F);
            this.grd_mold_sub.RowTemplate.Height = 40;
            this.grd_mold_sub.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grd_mold_sub.Size = new System.Drawing.Size(1354, 272);
            this.grd_mold_sub.TabIndex = 392;
            // 
            // W_INST_DATE
            // 
            this.W_INST_DATE.HeaderText = "작업지시일";
            this.W_INST_DATE.Name = "W_INST_DATE";
            this.W_INST_DATE.ReadOnly = true;
            this.W_INST_DATE.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.W_INST_DATE.Width = 200;
            // 
            // FLOW_DATE
            // 
            this.FLOW_DATE.HeaderText = "공정일";
            this.FLOW_DATE.Name = "FLOW_DATE";
            this.FLOW_DATE.ReadOnly = true;
            this.FLOW_DATE.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.FLOW_DATE.Width = 200;
            // 
            // ITEM_CD
            // 
            this.ITEM_CD.HeaderText = "제품코드";
            this.ITEM_CD.Name = "ITEM_CD";
            this.ITEM_CD.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ITEM_CD.Visible = false;
            this.ITEM_CD.Width = 60;
            // 
            // ITEM_NM
            // 
            this.ITEM_NM.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ITEM_NM.HeaderText = "제품명";
            this.ITEM_NM.Name = "ITEM_NM";
            // 
            // INST_AMT
            // 
            this.INST_AMT.HeaderText = "작업수량";
            this.INST_AMT.Name = "INST_AMT";
            this.INST_AMT.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.INST_AMT.Width = 140;
            // 
            // COMPLETE_YN
            // 
            this.COMPLETE_YN.HeaderText = "완료여부";
            this.COMPLETE_YN.Name = "COMPLETE_YN";
            this.COMPLETE_YN.Width = 140;
            // 
            // dataItemGrid
            // 
            this.dataItemGrid.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.dataItemGrid.AllowUserToAddRows = false;
            this.dataItemGrid.AllowUserToDeleteRows = false;
            this.dataItemGrid.AllowUserToOrderColumns = true;
            this.dataItemGrid.AllowUserToResizeColumns = false;
            this.dataItemGrid.AllowUserToResizeRows = false;
            this.dataItemGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataItemGrid.BackgroundColor = System.Drawing.Color.White;
            this.dataItemGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataItemGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataItemGrid.ColumnHeadersHeight = 40;
            this.dataItemGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MOLD_NO,
            this.MOLD_NM,
            this.WEIGHT,
            this.MOLD_GUBUN,
            this.STORAGE_CD,
            this.STORAGE_NM,
            this.INPUT_DATE,
            this.COMMENT,
            this.Column7});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataItemGrid.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataItemGrid.EnableHeadersVisualStyles = false;
            this.dataItemGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.dataItemGrid.Location = new System.Drawing.Point(0, 68);
            this.dataItemGrid.Name = "dataItemGrid";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataItemGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataItemGrid.RowHeadersVisible = false;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            this.dataItemGrid.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dataItemGrid.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 15F);
            this.dataItemGrid.RowTemplate.Height = 40;
            this.dataItemGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataItemGrid.Size = new System.Drawing.Size(1354, 338);
            this.dataItemGrid.TabIndex = 390;
            this.dataItemGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataItemGrid_CellDoubleClick);
            // 
            // MOLD_NO
            // 
            this.MOLD_NO.HeaderText = "금형번호";
            this.MOLD_NO.Name = "MOLD_NO";
            this.MOLD_NO.ReadOnly = true;
            this.MOLD_NO.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.MOLD_NO.Width = 140;
            // 
            // MOLD_NM
            // 
            this.MOLD_NM.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MOLD_NM.HeaderText = "금형명";
            this.MOLD_NM.Name = "MOLD_NM";
            this.MOLD_NM.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // WEIGHT
            // 
            this.WEIGHT.HeaderText = "중량";
            this.WEIGHT.Name = "WEIGHT";
            this.WEIGHT.ReadOnly = true;
            this.WEIGHT.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.WEIGHT.Width = 150;
            // 
            // MOLD_GUBUN
            // 
            this.MOLD_GUBUN.HeaderText = "금형구분";
            this.MOLD_GUBUN.Name = "MOLD_GUBUN";
            this.MOLD_GUBUN.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.MOLD_GUBUN.Width = 200;
            // 
            // STORAGE_CD
            // 
            this.STORAGE_CD.HeaderText = "보관장소";
            this.STORAGE_CD.Name = "STORAGE_CD";
            this.STORAGE_CD.Width = 200;
            // 
            // STORAGE_NM
            // 
            this.STORAGE_NM.HeaderText = "보관장소";
            this.STORAGE_NM.Name = "STORAGE_NM";
            this.STORAGE_NM.Width = 120;
            // 
            // INPUT_DATE
            // 
            this.INPUT_DATE.HeaderText = "등록";
            this.INPUT_DATE.Name = "INPUT_DATE";
            this.INPUT_DATE.Width = 120;
            // 
            // COMMENT
            // 
            this.COMMENT.HeaderText = "비고";
            this.COMMENT.Name = "COMMENT";
            this.COMMENT.Width = 80;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "금형등급";
            this.Column7.Name = "Column7";
            this.Column7.Visible = false;
            // 
            // frm금형사용이력조회
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1360, 714);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.grd_mold_sub);
            this.Controls.Add(this.dataItemGrid);
            this.Name = "frm금형사용이력조회";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frm금형사용이력조회";
            this.Load += new System.EventHandler(this.frm금형사용이력조회_Load);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd_mold_sub)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataItemGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private Controls.conTextBox conTextBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.DateTimePicker dateTimePicker3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView grd_mold_sub;
        private System.Windows.Forms.DataGridView dataItemGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn W_INST_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn FLOW_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn ITEM_CD;
        private System.Windows.Forms.DataGridViewTextBoxColumn ITEM_NM;
        private System.Windows.Forms.DataGridViewTextBoxColumn INST_AMT;
        private System.Windows.Forms.DataGridViewTextBoxColumn COMPLETE_YN;
        private System.Windows.Forms.DataGridViewTextBoxColumn MOLD_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn MOLD_NM;
        private System.Windows.Forms.DataGridViewTextBoxColumn WEIGHT;
        private System.Windows.Forms.DataGridViewTextBoxColumn MOLD_GUBUN;
        private System.Windows.Forms.DataGridViewTextBoxColumn STORAGE_CD;
        private System.Windows.Forms.DataGridViewTextBoxColumn STORAGE_NM;
        private System.Windows.Forms.DataGridViewTextBoxColumn INPUT_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn COMMENT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
    }
}