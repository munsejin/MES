namespace MES.P60_FAC
{
    partial class frm메탈마스크등록
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm메탈마스크등록));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_fac_gbn = new MES.Controls.conTextBox();
            this.lbl_title = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvMetalList = new MES.Controls.myDataGridView();
            this.METAL_CD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.METAL_MAKECUST = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.METAL_MODEL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.METAL_SPEC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.METAL_ORDERCUST = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.METAL_INPUT_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.METAL_MAKE_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COMMENT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label27 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dtp_inputdate = new MES.Controls.conDateTimePicker();
            this.dtp_makedate = new MES.Controls.conDateTimePicker();
            this.txt_makecust = new MES.Controls.conTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_flow_cd = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pic_fac_img = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txt_metalcd = new MES.Controls.conTextBox();
            this.txt_comment = new MES.Controls.conTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_stor_nm2 = new System.Windows.Forms.Label();
            this.txt_modelnm = new MES.Controls.conTextBox();
            this.txt_ordercust = new MES.Controls.conTextBox();
            this.lbl_dd = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_spec = new MES.Controls.conTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMetalList)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_fac_img)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.PaleTurquoise;
            this.panel2.Controls.Add(this.lbl_fac_gbn);
            this.panel2.Controls.Add(this.lbl_title);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.btnNew);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.btnDelete);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1360, 33);
            this.panel2.TabIndex = 11;
            // 
            // lbl_fac_gbn
            // 
            this.lbl_fac_gbn._AutoTab = true;
            this.lbl_fac_gbn._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.lbl_fac_gbn._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lbl_fac_gbn._WaterMarkColor = System.Drawing.Color.Gray;
            this.lbl_fac_gbn._WaterMarkText = "";
            this.lbl_fac_gbn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lbl_fac_gbn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_fac_gbn.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_fac_gbn.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.lbl_fac_gbn.Location = new System.Drawing.Point(456, 7);
            this.lbl_fac_gbn.MaxLength = 6;
            this.lbl_fac_gbn.Name = "lbl_fac_gbn";
            this.lbl_fac_gbn.Size = new System.Drawing.Size(171, 22);
            this.lbl_fac_gbn.TabIndex = 382;
            this.lbl_fac_gbn.Visible = false;
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.lbl_title.Location = new System.Drawing.Point(9, -2); //new System.Drawing.Point(10, 5);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(171, 22);
            this.lbl_title.TabIndex = 93;
            this.lbl_title.Text = "메탈마스크등록";
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
            this.btnClose.Location = new System.Drawing.Point(1292, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(65, 29);
            this.btnClose.TabIndex = 10;
            this.btnClose.Tag = "종료";
            this.btnClose.Text = "닫기";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.Transparent;
            this.btnNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNew.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnNew.FlatAppearance.BorderSize = 0;
            this.btnNew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.btnNew.Image = global::MES.Properties.Resources.newnewBtn;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNew.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnNew.Location = new System.Drawing.Point(1074, 2);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(65, 29);
            this.btnNew.TabIndex = 20;
            this.btnNew.Tag = "추가";
            this.btnNew.Text = "신규";
            this.btnNew.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.btnSave.Image = global::MES.Properties.Resources.newSaveBtn;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSave.Location = new System.Drawing.Point(1145, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(65, 29);
            this.btnSave.TabIndex = 0;
            this.btnSave.Tag = "저장";
            this.btnSave.Text = "저장";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.Enabled = false;
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.btnDelete.Image = global::MES.Properties.Resources.newDelBtn;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDelete.Location = new System.Drawing.Point(1217, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(65, 29);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Tag = "삭제";
            this.btnDelete.Text = "삭제";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.dgvMetalList);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 33);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1360, 681);
            this.panel1.TabIndex = 12;
            // 
            // dgvMetalList
            // 
            this.dgvMetalList.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.dgvMetalList.AllowUserToAddRows = false;
            this.dgvMetalList.AllowUserToDeleteRows = false;
            this.dgvMetalList.AllowUserToOrderColumns = true;
            this.dgvMetalList.AllowUserToResizeColumns = false;
            this.dgvMetalList.AllowUserToResizeRows = false;
            this.dgvMetalList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMetalList.BackgroundColor = System.Drawing.Color.White;
            this.dgvMetalList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMetalList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMetalList.ColumnHeadersHeight = 35;
            this.dgvMetalList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvMetalList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.METAL_CD,
            this.METAL_MAKECUST,
            this.METAL_MODEL,
            this.METAL_SPEC,
            this.METAL_ORDERCUST,
            this.METAL_INPUT_DATE,
            this.METAL_MAKE_DATE,
            this.COMMENT});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMetalList.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvMetalList.EnableHeadersVisualStyles = false;
            this.dgvMetalList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.dgvMetalList.Location = new System.Drawing.Point(514, 51);
            this.dgvMetalList.Name = "dgvMetalList";
            this.dgvMetalList.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMetalList.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvMetalList.RowHeadersVisible = false;
            this.dgvMetalList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvMetalList.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvMetalList.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dgvMetalList.RowTemplate.Height = 30;
            this.dgvMetalList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMetalList.Size = new System.Drawing.Size(834, 616);
            this.dgvMetalList.TabIndex = 389;
            this.dgvMetalList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMetalList_CellDoubleClick);
            // 
            // METAL_CD
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.METAL_CD.DefaultCellStyle = dataGridViewCellStyle2;
            this.METAL_CD.HeaderText = "메탈번호";
            this.METAL_CD.Name = "METAL_CD";
            this.METAL_CD.ReadOnly = true;
            // 
            // METAL_MAKECUST
            // 
            this.METAL_MAKECUST.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.METAL_MAKECUST.HeaderText = "제작업체";
            this.METAL_MAKECUST.Name = "METAL_MAKECUST";
            this.METAL_MAKECUST.ReadOnly = true;
            this.METAL_MAKECUST.Visible = false;
            // 
            // METAL_MODEL
            // 
            this.METAL_MODEL.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.METAL_MODEL.HeaderText = "모델명";
            this.METAL_MODEL.Name = "METAL_MODEL";
            this.METAL_MODEL.ReadOnly = true;
            // 
            // METAL_SPEC
            // 
            this.METAL_SPEC.HeaderText = "규격";
            this.METAL_SPEC.Name = "METAL_SPEC";
            this.METAL_SPEC.ReadOnly = true;
            this.METAL_SPEC.Width = 150;
            // 
            // METAL_ORDERCUST
            // 
            this.METAL_ORDERCUST.HeaderText = "발주업체";
            this.METAL_ORDERCUST.Name = "METAL_ORDERCUST";
            this.METAL_ORDERCUST.ReadOnly = true;
            this.METAL_ORDERCUST.Visible = false;
            // 
            // METAL_INPUT_DATE
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.METAL_INPUT_DATE.DefaultCellStyle = dataGridViewCellStyle3;
            this.METAL_INPUT_DATE.HeaderText = "입고일";
            this.METAL_INPUT_DATE.Name = "METAL_INPUT_DATE";
            this.METAL_INPUT_DATE.ReadOnly = true;
            this.METAL_INPUT_DATE.Visible = false;
            this.METAL_INPUT_DATE.Width = 150;
            // 
            // METAL_MAKE_DATE
            // 
            this.METAL_MAKE_DATE.HeaderText = "제조일자";
            this.METAL_MAKE_DATE.Name = "METAL_MAKE_DATE";
            this.METAL_MAKE_DATE.ReadOnly = true;
            this.METAL_MAKE_DATE.Visible = false;
            // 
            // COMMENT
            // 
            this.COMMENT.HeaderText = "비고";
            this.COMMENT.Name = "COMMENT";
            this.COMMENT.ReadOnly = true;
            this.COMMENT.Visible = false;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label11.Location = new System.Drawing.Point(514, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(123, 28);
            this.label11.TabIndex = 388;
            this.label11.Text = "메탈목록";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label27);
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Location = new System.Drawing.Point(13, 14);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(495, 652);
            this.groupBox1.TabIndex = 342;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "메탈카드";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label27.ForeColor = System.Drawing.Color.Black;
            this.label27.Location = new System.Drawing.Point(30, 20);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(157, 12);
            this.label27.TabIndex = 431;
            this.label27.Text = "*은 필수입력 항목입니다.";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dtp_inputdate);
            this.panel3.Controls.Add(this.dtp_makedate);
            this.panel3.Controls.Add(this.txt_makecust);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.lbl_flow_cd);
            this.panel3.Controls.Add(this.groupBox2);
            this.panel3.Controls.Add(this.txt_metalcd);
            this.panel3.Controls.Add(this.txt_comment);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.lbl_stor_nm2);
            this.panel3.Controls.Add(this.txt_modelnm);
            this.panel3.Controls.Add(this.txt_ordercust);
            this.panel3.Controls.Add(this.lbl_dd);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.txt_spec);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(6, 37);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(489, 610);
            this.panel3.TabIndex = 426;
            // 
            // dtp_inputdate
            // 
            this.dtp_inputdate._BorderColor = System.Drawing.Color.White;
            this.dtp_inputdate._FocusedBackColor = System.Drawing.Color.White;
            this.dtp_inputdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_inputdate.Location = new System.Drawing.Point(129, 321);
            this.dtp_inputdate.Name = "dtp_inputdate";
            this.dtp_inputdate.Size = new System.Drawing.Size(104, 21);
            this.dtp_inputdate.TabIndex = 30;
            // 
            // dtp_makedate
            // 
            this.dtp_makedate._BorderColor = System.Drawing.Color.White;
            this.dtp_makedate._FocusedBackColor = System.Drawing.Color.White;
            this.dtp_makedate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_makedate.Location = new System.Drawing.Point(129, 121);
            this.dtp_makedate.Name = "dtp_makedate";
            this.dtp_makedate.Size = new System.Drawing.Size(104, 21);
            this.dtp_makedate.TabIndex = 10;
            // 
            // txt_makecust
            // 
            this.txt_makecust._AutoTab = true;
            this.txt_makecust._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.txt_makecust._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txt_makecust._WaterMarkColor = System.Drawing.Color.Gray;
            this.txt_makecust._WaterMarkText = "";
            this.txt_makecust.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_makecust.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_makecust.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.txt_makecust.Location = new System.Drawing.Point(123, 270);
            this.txt_makecust.MaxLength = 20;
            this.txt_makecust.Name = "txt_makecust";
            this.txt_makecust.Size = new System.Drawing.Size(350, 22);
            this.txt_makecust.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.PowderBlue;
            this.label6.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(23, 270);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 22);
            this.label6.TabIndex = 427;
            this.label6.Text = "제작업체";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.PowderBlue;
            this.label5.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(23, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 22);
            this.label5.TabIndex = 425;
            this.label5.Text = "제조일자";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_flow_cd
            // 
            this.lbl_flow_cd.BackColor = System.Drawing.Color.PowderBlue;
            this.lbl_flow_cd.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_flow_cd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_flow_cd.Location = new System.Drawing.Point(23, 20);
            this.lbl_flow_cd.Name = "lbl_flow_cd";
            this.lbl_flow_cd.Size = new System.Drawing.Size(100, 22);
            this.lbl_flow_cd.TabIndex = 410;
            this.lbl_flow_cd.Text = "*메탈번호";
            this.lbl_flow_cd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pic_fac_img);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Location = new System.Drawing.Point(156, 422);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(123, 61);
            this.groupBox2.TabIndex = 343;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "메탈사진";
            this.groupBox2.Visible = false;
            // 
            // pic_fac_img
            // 
            this.pic_fac_img.Location = new System.Drawing.Point(5, 48);
            this.pic_fac_img.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pic_fac_img.Name = "pic_fac_img";
            this.pic_fac_img.Size = new System.Drawing.Size(446, 201);
            this.pic_fac_img.TabIndex = 392;
            this.pic_fac_img.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(5, 17);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 27);
            this.button1.TabIndex = 389;
            this.button1.Text = "사진첨부";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txt_metalcd
            // 
            this.txt_metalcd._AutoTab = true;
            this.txt_metalcd._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.txt_metalcd._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txt_metalcd._WaterMarkColor = System.Drawing.Color.Gray;
            this.txt_metalcd._WaterMarkText = "";
            this.txt_metalcd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txt_metalcd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_metalcd.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_metalcd.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.txt_metalcd.Location = new System.Drawing.Point(124, 20);
            this.txt_metalcd.MaxLength = 20;
            this.txt_metalcd.Name = "txt_metalcd";
            this.txt_metalcd.Size = new System.Drawing.Size(350, 22);
            this.txt_metalcd.TabIndex = 1;
            // 
            // txt_comment
            // 
            this.txt_comment._AutoTab = true;
            this.txt_comment._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.txt_comment._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txt_comment._WaterMarkColor = System.Drawing.Color.Gray;
            this.txt_comment._WaterMarkText = "";
            this.txt_comment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_comment.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_comment.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.txt_comment.Location = new System.Drawing.Point(124, 370);
            this.txt_comment.MaxLength = 20;
            this.txt_comment.Name = "txt_comment";
            this.txt_comment.Size = new System.Drawing.Size(171, 22);
            this.txt_comment.TabIndex = 35;
            this.txt_comment.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_comment_KeyDown);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.PowderBlue;
            this.label4.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(23, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 22);
            this.label4.TabIndex = 423;
            this.label4.Text = "*모델명";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_stor_nm2
            // 
            this.lbl_stor_nm2.BackColor = System.Drawing.Color.PowderBlue;
            this.lbl_stor_nm2.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_stor_nm2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_stor_nm2.Location = new System.Drawing.Point(23, 170);
            this.lbl_stor_nm2.Name = "lbl_stor_nm2";
            this.lbl_stor_nm2.Size = new System.Drawing.Size(100, 22);
            this.lbl_stor_nm2.TabIndex = 413;
            this.lbl_stor_nm2.Text = "규격";
            this.lbl_stor_nm2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_modelnm
            // 
            this.txt_modelnm._AutoTab = true;
            this.txt_modelnm._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.txt_modelnm._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txt_modelnm._WaterMarkColor = System.Drawing.Color.Gray;
            this.txt_modelnm._WaterMarkText = "";
            this.txt_modelnm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_modelnm.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_modelnm.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.txt_modelnm.Location = new System.Drawing.Point(124, 70);
            this.txt_modelnm.MaxLength = 20;
            this.txt_modelnm.Name = "txt_modelnm";
            this.txt_modelnm.Size = new System.Drawing.Size(350, 22);
            this.txt_modelnm.TabIndex = 5;
            // 
            // txt_ordercust
            // 
            this.txt_ordercust._AutoTab = true;
            this.txt_ordercust._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.txt_ordercust._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txt_ordercust._WaterMarkColor = System.Drawing.Color.Gray;
            this.txt_ordercust._WaterMarkText = "";
            this.txt_ordercust.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_ordercust.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_ordercust.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.txt_ordercust.Location = new System.Drawing.Point(124, 220);
            this.txt_ordercust.MaxLength = 20;
            this.txt_ordercust.Name = "txt_ordercust";
            this.txt_ordercust.Size = new System.Drawing.Size(350, 22);
            this.txt_ordercust.TabIndex = 20;
            // 
            // lbl_dd
            // 
            this.lbl_dd.BackColor = System.Drawing.Color.PowderBlue;
            this.lbl_dd.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_dd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_dd.Location = new System.Drawing.Point(23, 220);
            this.lbl_dd.Name = "lbl_dd";
            this.lbl_dd.Size = new System.Drawing.Size(100, 22);
            this.lbl_dd.TabIndex = 416;
            this.lbl_dd.Text = "발주업체";
            this.lbl_dd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.PowderBlue;
            this.label3.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(23, 370);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 22);
            this.label3.TabIndex = 420;
            this.label3.Text = "비고";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_spec
            // 
            this.txt_spec._AutoTab = true;
            this.txt_spec._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.txt_spec._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txt_spec._WaterMarkColor = System.Drawing.Color.Gray;
            this.txt_spec._WaterMarkText = "";
            this.txt_spec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_spec.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_spec.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.txt_spec.Location = new System.Drawing.Point(124, 170);
            this.txt_spec.MaxLength = 20;
            this.txt_spec.Name = "txt_spec";
            this.txt_spec.Size = new System.Drawing.Size(350, 22);
            this.txt_spec.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.PowderBlue;
            this.label2.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(23, 320);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 22);
            this.label2.TabIndex = 418;
            this.label2.Text = "입고일";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ofd
            // 
            this.ofd.FileName = "ofd";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "메탈코드";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.HeaderText = "제품명";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.HeaderText = "업체명";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "모델명";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 200;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "규격";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Visible = false;
            this.dataGridViewTextBoxColumn5.Width = 200;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn6.HeaderText = "취득일자";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Visible = false;
            this.dataGridViewTextBoxColumn6.Width = 150;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "취득가격";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Visible = false;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "비고";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Visible = false;
            // 
            // frm메탈마스크등록
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1360, 714);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "frm메탈마스크등록";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frm메탈마스크등록";
            this.Load += new System.EventHandler(this.frm메탈마스크등록_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMetalList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic_fac_img)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private Controls.conTextBox lbl_fac_gbn;
        public System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvMetalList;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbl_flow_cd;
        private Controls.conTextBox txt_metalcd;
        private Controls.conTextBox txt_comment;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_stor_nm2;
        private Controls.conTextBox txt_modelnm;
        private Controls.conTextBox txt_ordercust;
        private System.Windows.Forms.Label lbl_dd;
        private System.Windows.Forms.Label label3;
        private Controls.conTextBox txt_spec;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pic_fac_img;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.Label label5;
        private Controls.conTextBox txt_makecust;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn METAL_CD;
        private System.Windows.Forms.DataGridViewTextBoxColumn METAL_MAKECUST;
        private System.Windows.Forms.DataGridViewTextBoxColumn METAL_MODEL;
        private System.Windows.Forms.DataGridViewTextBoxColumn METAL_SPEC;
        private System.Windows.Forms.DataGridViewTextBoxColumn METAL_ORDERCUST;
        private System.Windows.Forms.DataGridViewTextBoxColumn METAL_INPUT_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn METAL_MAKE_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn COMMENT;
        private System.Windows.Forms.Label label27;
        private Controls.conDateTimePicker dtp_inputdate;
        private Controls.conDateTimePicker dtp_makedate;
    }
}