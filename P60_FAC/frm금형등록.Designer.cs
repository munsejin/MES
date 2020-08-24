namespace MES.P60_FAC
{
    partial class frm금형등록
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm금형등록));
            this.dataRawCdGrid = new MES.Controls.myDataGridView();
            this.MOLD_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MOLD_NM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INPUT_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STORAGE_CD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STORAGE_NM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MOLD_GUBUN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WEIGHT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COMMENT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_srch = new MES.Controls.conTextBox();
            this.cmb_cd_srch = new MES.Controls.conComboBox();
            this.dtp_start_date = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_title = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txt_weight = new MES.Controls.conTextBox();
            this.lbl_raw_mat_gbn = new MES.Controls.conTextBox();
            this.lbl_start_date = new System.Windows.Forms.Label();
            this.lbl_weight = new System.Windows.Forms.Label();
            this.txt_mold_nm = new MES.Controls.conTextBox();
            this.lbl_mold_num = new System.Windows.Forms.Label();
            this.txt_mold_num = new MES.Controls.conTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lbl_storage = new System.Windows.Forms.Label();
            this.cmb_storage = new MES.Controls.conComboBox();
            this.lbl_gubun = new System.Windows.Forms.Label();
            this.cmb_gubun = new MES.Controls.conComboBox();
            this.lbl_mold_nm = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataRawCdGrid)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataRawCdGrid
            // 
            this.dataRawCdGrid.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.dataRawCdGrid.AllowUserToAddRows = false;
            this.dataRawCdGrid.AllowUserToDeleteRows = false;
            this.dataRawCdGrid.AllowUserToOrderColumns = true;
            this.dataRawCdGrid.AllowUserToResizeColumns = false;
            this.dataRawCdGrid.AllowUserToResizeRows = false;
            this.dataRawCdGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataRawCdGrid.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataRawCdGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataRawCdGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataRawCdGrid.ColumnHeadersHeight = 40;
            this.dataRawCdGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MOLD_NO,
            this.MOLD_NM,
            this.INPUT_DATE,
            this.STORAGE_CD,
            this.STORAGE_NM,
            this.MOLD_GUBUN,
            this.WEIGHT,
            this.COMMENT});
            this.dataRawCdGrid.EnableHeadersVisualStyles = false;
            this.dataRawCdGrid.GridColor = System.Drawing.Color.PowderBlue;
            this.dataRawCdGrid.Location = new System.Drawing.Point(482, 55);
            this.dataRawCdGrid.Name = "dataRawCdGrid";
            this.dataRawCdGrid.ReadOnly = true;
            this.dataRawCdGrid.RowHeadersVisible = false;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dataRawCdGrid.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataRawCdGrid.RowTemplate.Height = 23;
            this.dataRawCdGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataRawCdGrid.Size = new System.Drawing.Size(872, 625);
            this.dataRawCdGrid.TabIndex = 384;
            this.dataRawCdGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataRawCdGrid_CellContentClick);
            this.dataRawCdGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataRawCdGrid_CellDoubleClick);
            // 
            // MOLD_NO
            // 
            this.MOLD_NO.HeaderText = "금형번호";
            this.MOLD_NO.Name = "MOLD_NO";
            this.MOLD_NO.ReadOnly = true;
            this.MOLD_NO.Width = 120;
            // 
            // MOLD_NM
            // 
            this.MOLD_NM.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MOLD_NM.HeaderText = "금형이름";
            this.MOLD_NM.Name = "MOLD_NM";
            this.MOLD_NM.ReadOnly = true;
            // 
            // INPUT_DATE
            // 
            this.INPUT_DATE.HeaderText = "등록일";
            this.INPUT_DATE.Name = "INPUT_DATE";
            this.INPUT_DATE.ReadOnly = true;
            this.INPUT_DATE.Width = 150;
            // 
            // STORAGE_CD
            // 
            this.STORAGE_CD.HeaderText = "보관위치코드";
            this.STORAGE_CD.Name = "STORAGE_CD";
            this.STORAGE_CD.ReadOnly = true;
            this.STORAGE_CD.Visible = false;
            // 
            // STORAGE_NM
            // 
            this.STORAGE_NM.HeaderText = "보관위치";
            this.STORAGE_NM.Name = "STORAGE_NM";
            this.STORAGE_NM.ReadOnly = true;
            // 
            // MOLD_GUBUN
            // 
            this.MOLD_GUBUN.HeaderText = "금형";
            this.MOLD_GUBUN.Name = "MOLD_GUBUN";
            this.MOLD_GUBUN.ReadOnly = true;
            this.MOLD_GUBUN.Visible = false;
            this.MOLD_GUBUN.Width = 220;
            // 
            // WEIGHT
            // 
            this.WEIGHT.HeaderText = "중량";
            this.WEIGHT.Name = "WEIGHT";
            this.WEIGHT.ReadOnly = true;
            // 
            // COMMENT
            // 
            this.COMMENT.HeaderText = "비고";
            this.COMMENT.Name = "COMMENT";
            this.COMMENT.ReadOnly = true;
            this.COMMENT.Width = 140;
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
            this.txt_srch.Location = new System.Drawing.Point(659, 15);
            this.txt_srch.MaxLength = 20;
            this.txt_srch.Name = "txt_srch";
            this.txt_srch.Size = new System.Drawing.Size(192, 24);
            this.txt_srch.TabIndex = 385;
            // 
            // cmb_cd_srch
            // 
            this.cmb_cd_srch._BorderColor = System.Drawing.Color.Transparent;
            this.cmb_cd_srch._FocusedBackColor = System.Drawing.Color.White;
            this.cmb_cd_srch.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cmb_cd_srch.FormattingEnabled = true;
            this.cmb_cd_srch.Location = new System.Drawing.Point(482, 17);
            this.cmb_cd_srch.Name = "cmb_cd_srch";
            this.cmb_cd_srch.Size = new System.Drawing.Size(171, 20);
            this.cmb_cd_srch.TabIndex = 386;
            // 
            // dtp_start_date
            // 
            this.dtp_start_date.Checked = false;
            this.dtp_start_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_start_date.Location = new System.Drawing.Point(113, 258);
            this.dtp_start_date.Name = "dtp_start_date";
            this.dtp_start_date.Size = new System.Drawing.Size(212, 21);
            this.dtp_start_date.TabIndex = 383;
            this.dtp_start_date.Value = new System.DateTime(2018, 10, 8, 0, 0, 0, 0);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.PaleTurquoise;
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
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.lbl_title.Location = new System.Drawing.Point(9, -2); //new System.Drawing.Point(10, 5);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(102, 22);
            this.lbl_title.TabIndex = 93;
            this.lbl_title.Text = "금형등록";
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
            this.btnNew.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.btnNew.Image = global::MES.Properties.Resources.newnewBtn;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNew.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnNew.Location = new System.Drawing.Point(1079, 3);
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
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.btnSave.Location = new System.Drawing.Point(1150, 3);
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
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.btnDelete.Location = new System.Drawing.Point(1221, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(65, 29);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Tag = "삭제";
            this.btnDelete.Text = "삭제";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txt_weight
            // 
            this.txt_weight._AutoTab = true;
            this.txt_weight._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.txt_weight._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txt_weight._WaterMarkColor = System.Drawing.Color.Gray;
            this.txt_weight._WaterMarkText = "";
            this.txt_weight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_weight.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_weight.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.txt_weight.Location = new System.Drawing.Point(113, 127);
            this.txt_weight.MaxLength = 20;
            this.txt_weight.Name = "txt_weight";
            this.txt_weight.Size = new System.Drawing.Size(212, 22);
            this.txt_weight.TabIndex = 331;
            // 
            // lbl_raw_mat_gbn
            // 
            this.lbl_raw_mat_gbn._AutoTab = true;
            this.lbl_raw_mat_gbn._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.lbl_raw_mat_gbn._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lbl_raw_mat_gbn._WaterMarkColor = System.Drawing.Color.Gray;
            this.lbl_raw_mat_gbn._WaterMarkText = "";
            this.lbl_raw_mat_gbn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lbl_raw_mat_gbn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_raw_mat_gbn.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_raw_mat_gbn.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.lbl_raw_mat_gbn.Location = new System.Drawing.Point(232, 544);
            this.lbl_raw_mat_gbn.MaxLength = 6;
            this.lbl_raw_mat_gbn.Name = "lbl_raw_mat_gbn";
            this.lbl_raw_mat_gbn.Size = new System.Drawing.Size(171, 22);
            this.lbl_raw_mat_gbn.TabIndex = 330;
            this.lbl_raw_mat_gbn.Visible = false;
            // 
            // lbl_start_date
            // 
            this.lbl_start_date.BackColor = System.Drawing.Color.PowderBlue;
            this.lbl_start_date.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_start_date.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_start_date.Location = new System.Drawing.Point(12, 256);
            this.lbl_start_date.Name = "lbl_start_date";
            this.lbl_start_date.Size = new System.Drawing.Size(100, 22);
            this.lbl_start_date.TabIndex = 312;
            this.lbl_start_date.Text = "금형시작일자";
            this.lbl_start_date.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_weight
            // 
            this.lbl_weight.BackColor = System.Drawing.Color.PowderBlue;
            this.lbl_weight.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_weight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_weight.Location = new System.Drawing.Point(12, 126);
            this.lbl_weight.Name = "lbl_weight";
            this.lbl_weight.Size = new System.Drawing.Size(100, 22);
            this.lbl_weight.TabIndex = 296;
            this.lbl_weight.Text = "중량";
            this.lbl_weight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_mold_nm
            // 
            this.txt_mold_nm._AutoTab = true;
            this.txt_mold_nm._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.txt_mold_nm._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txt_mold_nm._WaterMarkColor = System.Drawing.Color.Gray;
            this.txt_mold_nm._WaterMarkText = "";
            this.txt_mold_nm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_mold_nm.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_mold_nm.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.txt_mold_nm.Location = new System.Drawing.Point(113, 85);
            this.txt_mold_nm.MaxLength = 20;
            this.txt_mold_nm.Name = "txt_mold_nm";
            this.txt_mold_nm.Size = new System.Drawing.Size(212, 22);
            this.txt_mold_nm.TabIndex = 295;
            // 
            // lbl_mold_num
            // 
            this.lbl_mold_num.BackColor = System.Drawing.Color.PowderBlue;
            this.lbl_mold_num.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_mold_num.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_mold_num.Location = new System.Drawing.Point(12, 42);
            this.lbl_mold_num.Name = "lbl_mold_num";
            this.lbl_mold_num.Size = new System.Drawing.Size(100, 22);
            this.lbl_mold_num.TabIndex = 288;
            this.lbl_mold_num.Text = "금형번호";
            this.lbl_mold_num.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_mold_num
            // 
            this.txt_mold_num._AutoTab = true;
            this.txt_mold_num._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.txt_mold_num._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txt_mold_num._WaterMarkColor = System.Drawing.Color.Gray;
            this.txt_mold_num._WaterMarkText = "";
            this.txt_mold_num.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txt_mold_num.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_mold_num.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_mold_num.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.txt_mold_num.Location = new System.Drawing.Point(113, 42);
            this.txt_mold_num.MaxLength = 6;
            this.txt_mold_num.Name = "txt_mold_num";
            this.txt_mold_num.Size = new System.Drawing.Size(212, 22);
            this.txt_mold_num.TabIndex = 287;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Controls.Add(this.dataRawCdGrid);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.txt_srch);
            this.panel1.Controls.Add(this.cmb_cd_srch);
            this.panel1.Controls.Add(this.dtp_start_date);
            this.panel1.Controls.Add(this.txt_weight);
            this.panel1.Controls.Add(this.lbl_raw_mat_gbn);
            this.panel1.Controls.Add(this.lbl_start_date);
            this.panel1.Controls.Add(this.lbl_storage);
            this.panel1.Controls.Add(this.cmb_storage);
            this.panel1.Controls.Add(this.lbl_gubun);
            this.panel1.Controls.Add(this.lbl_weight);
            this.panel1.Controls.Add(this.cmb_gubun);
            this.panel1.Controls.Add(this.txt_mold_nm);
            this.panel1.Controls.Add(this.lbl_mold_nm);
            this.panel1.Controls.Add(this.lbl_mold_num);
            this.panel1.Controls.Add(this.txt_mold_num);
            this.panel1.Location = new System.Drawing.Point(0, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1357, 684);
            this.panel1.TabIndex = 12;
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
            this.btnSearch.Location = new System.Drawing.Point(856, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(33, 33);
            this.btnSearch.TabIndex = 387;
            this.btnSearch.Tag = "검색";
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // lbl_storage
            // 
            this.lbl_storage.BackColor = System.Drawing.Color.PowderBlue;
            this.lbl_storage.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_storage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_storage.Location = new System.Drawing.Point(12, 210);
            this.lbl_storage.Name = "lbl_storage";
            this.lbl_storage.Size = new System.Drawing.Size(100, 22);
            this.lbl_storage.TabIndex = 307;
            this.lbl_storage.Text = "보관위치";
            this.lbl_storage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmb_storage
            // 
            this.cmb_storage._BorderColor = System.Drawing.Color.Transparent;
            this.cmb_storage._FocusedBackColor = System.Drawing.Color.White;
            this.cmb_storage.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cmb_storage.FormattingEnabled = true;
            this.cmb_storage.Location = new System.Drawing.Point(113, 212);
            this.cmb_storage.Name = "cmb_storage";
            this.cmb_storage.Size = new System.Drawing.Size(212, 20);
            this.cmb_storage.TabIndex = 299;
            // 
            // lbl_gubun
            // 
            this.lbl_gubun.BackColor = System.Drawing.Color.PowderBlue;
            this.lbl_gubun.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_gubun.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_gubun.Location = new System.Drawing.Point(12, 167);
            this.lbl_gubun.Name = "lbl_gubun";
            this.lbl_gubun.Size = new System.Drawing.Size(100, 22);
            this.lbl_gubun.TabIndex = 300;
            this.lbl_gubun.Text = "구분";
            this.lbl_gubun.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmb_gubun
            // 
            this.cmb_gubun._BorderColor = System.Drawing.Color.Transparent;
            this.cmb_gubun._FocusedBackColor = System.Drawing.Color.White;
            this.cmb_gubun.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cmb_gubun.FormattingEnabled = true;
            this.cmb_gubun.Location = new System.Drawing.Point(113, 169);
            this.cmb_gubun.Name = "cmb_gubun";
            this.cmb_gubun.Size = new System.Drawing.Size(212, 20);
            this.cmb_gubun.TabIndex = 292;
            // 
            // lbl_mold_nm
            // 
            this.lbl_mold_nm.BackColor = System.Drawing.Color.PowderBlue;
            this.lbl_mold_nm.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_mold_nm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_mold_nm.Location = new System.Drawing.Point(12, 85);
            this.lbl_mold_nm.Name = "lbl_mold_nm";
            this.lbl_mold_nm.Size = new System.Drawing.Size(100, 22);
            this.lbl_mold_nm.TabIndex = 291;
            this.lbl_mold_nm.Text = "금형명";
            this.lbl_mold_nm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frm금형등록
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1360, 714);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frm금형등록";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frm금형등록";
            this.Load += new System.EventHandler(this.frm금형등록_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataRawCdGrid)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataRawCdGrid;
        private System.Windows.Forms.Button btnSearch;
        private Controls.conTextBox txt_srch;
        private Controls.conComboBox cmb_cd_srch;
        private System.Windows.Forms.DateTimePicker dtp_start_date;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private Controls.conTextBox txt_weight;
        private Controls.conTextBox lbl_raw_mat_gbn;
        private System.Windows.Forms.Label lbl_start_date;
        private System.Windows.Forms.Label lbl_weight;
        private Controls.conTextBox txt_mold_nm;
        private System.Windows.Forms.Label lbl_mold_num;
        private Controls.conTextBox txt_mold_num;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_mold_nm;
        private System.Windows.Forms.Label lbl_gubun;
        private Controls.conComboBox cmb_gubun;
        private System.Windows.Forms.Label lbl_storage;
        private Controls.conComboBox cmb_storage;
        private System.Windows.Forms.DataGridViewTextBoxColumn MOLD_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn MOLD_NM;
        private System.Windows.Forms.DataGridViewTextBoxColumn INPUT_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn STORAGE_CD;
        private System.Windows.Forms.DataGridViewTextBoxColumn STORAGE_NM;
        private System.Windows.Forms.DataGridViewTextBoxColumn MOLD_GUBUN;
        private System.Windows.Forms.DataGridViewTextBoxColumn WEIGHT;
        private System.Windows.Forms.DataGridViewTextBoxColumn COMMENT;
    }
}