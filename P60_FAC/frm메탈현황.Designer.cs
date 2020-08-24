namespace MES.P60_FAC
{
    partial class frm메탈현황
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm메탈현황));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn출력 = new System.Windows.Forms.Button();
            this.btn_clear = new System.Windows.Forms.Button();
            this.lbl_title = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_metalsrch = new System.Windows.Forms.Button();
            this.txt_metalnm = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgv_MetalList = new MES.Controls.myDataGridView();
            this.METAL_CD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.METAL_LOTNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.METAL_MODEL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.METAL_SPEC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.METAL_MAKECUST = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.METAL_ORDERCUST = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.METAL_INPUT_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.METAL_MAKE_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.METAL_COMMENT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CHK = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_MetalList)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.PaleTurquoise;
            this.panel2.Controls.Add(this.btn출력);
            this.panel2.Controls.Add(this.btn_clear);
            this.panel2.Controls.Add(this.lbl_title);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1360, 33);
            this.panel2.TabIndex = 17;
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
            this.btn출력.Location = new System.Drawing.Point(1214, 2);
            this.btn출력.Name = "btn출력";
            this.btn출력.Size = new System.Drawing.Size(69, 29);
            this.btn출력.TabIndex = 383;
            this.btn출력.Tag = "출력";
            this.btn출력.Text = "출력";
            this.btn출력.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn출력.UseVisualStyleBackColor = false;
            this.btn출력.Click += new System.EventHandler(this.btn출력_Click);
            // 
            // btn_clear
            // 
            this.btn_clear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_clear.BackColor = System.Drawing.Color.Transparent;
            this.btn_clear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_clear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_clear.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_clear.FlatAppearance.BorderSize = 0;
            this.btn_clear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_clear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.btn_clear.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_clear.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_clear.Location = new System.Drawing.Point(972, 2);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(65, 29);
            this.btn_clear.TabIndex = 94;
            this.btn_clear.Tag = "종료";
            this.btn_clear.Text = "새로고침";
            this.btn_clear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_clear.UseVisualStyleBackColor = false;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.lbl_title.Location = new System.Drawing.Point(9, -2); //new System.Drawing.Point(10, 5);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(102, 22);
            this.lbl_title.TabIndex = 93;
            this.lbl_title.Text = "메탈현황";
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
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.btn_metalsrch);
            this.panel3.Controls.Add(this.txt_metalnm);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.dgv_MetalList);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 33);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1360, 681);
            this.panel3.TabIndex = 390;
            // 
            // btn_metalsrch
            // 
            this.btn_metalsrch.BackColor = System.Drawing.Color.Transparent;
            this.btn_metalsrch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_metalsrch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_metalsrch.FlatAppearance.BorderSize = 0;
            this.btn_metalsrch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btn_metalsrch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_metalsrch.Image = ((System.Drawing.Image)(resources.GetObject("btn_metalsrch.Image")));
            this.btn_metalsrch.Location = new System.Drawing.Point(489, 9);
            this.btn_metalsrch.Name = "btn_metalsrch";
            this.btn_metalsrch.Size = new System.Drawing.Size(33, 33);
            this.btn_metalsrch.TabIndex = 394;
            this.btn_metalsrch.Tag = "검색";
            this.btn_metalsrch.UseVisualStyleBackColor = false;
            this.btn_metalsrch.Click += new System.EventHandler(this.btn_metalsrch_Click);
            // 
            // txt_metalnm
            // 
            this.txt_metalnm.Location = new System.Drawing.Point(326, 18);
            this.txt_metalnm.Name = "txt_metalnm";
            this.txt_metalnm.Size = new System.Drawing.Size(158, 21);
            this.txt_metalnm.TabIndex = 393;
            this.txt_metalnm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_metalnm_KeyDown);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(237, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 23);
            this.label3.TabIndex = 391;
            this.label3.Text = "메탈모델명";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgv_MetalList
            // 
            this.dgv_MetalList.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.dgv_MetalList.AllowUserToAddRows = false;
            this.dgv_MetalList.AllowUserToDeleteRows = false;
            this.dgv_MetalList.AllowUserToOrderColumns = true;
            this.dgv_MetalList.AllowUserToResizeColumns = false;
            this.dgv_MetalList.AllowUserToResizeRows = false;
            this.dgv_MetalList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_MetalList.BackgroundColor = System.Drawing.Color.White;
            this.dgv_MetalList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_MetalList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle21;
            this.dgv_MetalList.ColumnHeadersHeight = 35;
            this.dgv_MetalList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_MetalList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.METAL_CD,
            this.METAL_LOTNO,
            this.METAL_MODEL,
            this.METAL_SPEC,
            this.METAL_MAKECUST,
            this.METAL_ORDERCUST,
            this.METAL_INPUT_DATE,
            this.METAL_MAKE_DATE,
            this.METAL_COMMENT,
            this.CHK});
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle25.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle25.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle25.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle25.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle25.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_MetalList.DefaultCellStyle = dataGridViewCellStyle25;
            this.dgv_MetalList.EnableHeadersVisualStyles = false;
            this.dgv_MetalList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.dgv_MetalList.Location = new System.Drawing.Point(18, 46);
            this.dgv_MetalList.Name = "dgv_MetalList";
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle26.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle26.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle26.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle26.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle26.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_MetalList.RowHeadersDefaultCellStyle = dataGridViewCellStyle26;
            this.dgv_MetalList.RowHeadersVisible = false;
            this.dgv_MetalList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle27.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle27.SelectionBackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle27.SelectionForeColor = System.Drawing.Color.Black;
            this.dgv_MetalList.RowsDefaultCellStyle = dataGridViewCellStyle27;
            this.dgv_MetalList.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 12F);
            this.dgv_MetalList.RowTemplate.Height = 40;
            this.dgv_MetalList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_MetalList.Size = new System.Drawing.Size(1325, 632);
            this.dgv_MetalList.TabIndex = 390;
            // 
            // METAL_CD
            // 
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.METAL_CD.DefaultCellStyle = dataGridViewCellStyle22;
            this.METAL_CD.Frozen = true;
            this.METAL_CD.HeaderText = "메탈번호";
            this.METAL_CD.Name = "METAL_CD";
            this.METAL_CD.ReadOnly = true;
            this.METAL_CD.Width = 80;
            // 
            // METAL_LOTNO
            // 
            this.METAL_LOTNO.HeaderText = "메탈바코드";
            this.METAL_LOTNO.Name = "METAL_LOTNO";
            this.METAL_LOTNO.ReadOnly = true;
            this.METAL_LOTNO.Width = 130;
            // 
            // METAL_MODEL
            // 
            this.METAL_MODEL.HeaderText = "모델명";
            this.METAL_MODEL.Name = "METAL_MODEL";
            this.METAL_MODEL.ReadOnly = true;
            this.METAL_MODEL.Width = 200;
            // 
            // METAL_SPEC
            // 
            this.METAL_SPEC.HeaderText = "규격";
            this.METAL_SPEC.Name = "METAL_SPEC";
            this.METAL_SPEC.ReadOnly = true;
            // 
            // METAL_MAKECUST
            // 
            this.METAL_MAKECUST.HeaderText = "제작업체";
            this.METAL_MAKECUST.Name = "METAL_MAKECUST";
            this.METAL_MAKECUST.ReadOnly = true;
            this.METAL_MAKECUST.Width = 150;
            // 
            // METAL_ORDERCUST
            // 
            this.METAL_ORDERCUST.HeaderText = "발주업체";
            this.METAL_ORDERCUST.Name = "METAL_ORDERCUST";
            this.METAL_ORDERCUST.ReadOnly = true;
            this.METAL_ORDERCUST.Width = 150;
            // 
            // METAL_INPUT_DATE
            // 
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.METAL_INPUT_DATE.DefaultCellStyle = dataGridViewCellStyle23;
            this.METAL_INPUT_DATE.HeaderText = "입고일";
            this.METAL_INPUT_DATE.Name = "METAL_INPUT_DATE";
            this.METAL_INPUT_DATE.ReadOnly = true;
            this.METAL_INPUT_DATE.Width = 120;
            // 
            // METAL_MAKE_DATE
            // 
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.METAL_MAKE_DATE.DefaultCellStyle = dataGridViewCellStyle24;
            this.METAL_MAKE_DATE.HeaderText = "제조일자";
            this.METAL_MAKE_DATE.Name = "METAL_MAKE_DATE";
            this.METAL_MAKE_DATE.ReadOnly = true;
            this.METAL_MAKE_DATE.Width = 120;
            // 
            // METAL_COMMENT
            // 
            this.METAL_COMMENT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.METAL_COMMENT.HeaderText = "비고";
            this.METAL_COMMENT.Name = "METAL_COMMENT";
            this.METAL_COMMENT.ReadOnly = true;
            // 
            // CHK
            // 
            this.CHK.HeaderText = "확인";
            this.CHK.Name = "CHK";
            this.CHK.Width = 60;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(18, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(204, 28);
            this.label4.TabIndex = 389;
            this.label4.Text = "등록된 메탈목록";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle28;
            this.dataGridViewTextBoxColumn1.Frozen = true;
            this.dataGridViewTextBoxColumn1.HeaderText = "메탈번호";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 80;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.Frozen = true;
            this.dataGridViewTextBoxColumn2.HeaderText = "메탈바코드";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 130;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.Frozen = true;
            this.dataGridViewTextBoxColumn3.HeaderText = "모델명";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 200;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.Frozen = true;
            this.dataGridViewTextBoxColumn4.HeaderText = "규격";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 200;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.Frozen = true;
            this.dataGridViewTextBoxColumn5.HeaderText = "제작업체";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 150;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.Frozen = true;
            this.dataGridViewTextBoxColumn6.HeaderText = "발주업체";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 150;
            // 
            // dataGridViewTextBoxColumn7
            // 
            dataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle29;
            this.dataGridViewTextBoxColumn7.Frozen = true;
            this.dataGridViewTextBoxColumn7.HeaderText = "입고일";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 150;
            // 
            // dataGridViewTextBoxColumn8
            // 
            dataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn8.DefaultCellStyle = dataGridViewCellStyle30;
            this.dataGridViewTextBoxColumn8.Frozen = true;
            this.dataGridViewTextBoxColumn8.HeaderText = "제조일자";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 150;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn9.Frozen = true;
            this.dataGridViewTextBoxColumn9.HeaderText = "비고";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // frm메탈현황
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1360, 714);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Name = "frm메탈현황";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frm메탈현황";
            this.Load += new System.EventHandler(this.frm메탈현황_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_MetalList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btn_metalsrch;
        private System.Windows.Forms.TextBox txt_metalnm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgv_MetalList;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn출력;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn METAL_CD;
        private System.Windows.Forms.DataGridViewTextBoxColumn METAL_LOTNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn METAL_MODEL;
        private System.Windows.Forms.DataGridViewTextBoxColumn METAL_SPEC;
        private System.Windows.Forms.DataGridViewTextBoxColumn METAL_MAKECUST;
        private System.Windows.Forms.DataGridViewTextBoxColumn METAL_ORDERCUST;
        private System.Windows.Forms.DataGridViewTextBoxColumn METAL_INPUT_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn METAL_MAKE_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn METAL_COMMENT;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CHK;
    }
}