namespace MES.P60_FAC
{
    partial class frm금형설정등록
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm금형설정등록));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_title = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataRawCdGrid = new MES.Controls.myDataGridView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txt_srch = new MES.Controls.conTextBox();
            this.cmb_cd_srch = new MES.Controls.conComboBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.conTextBox8 = new MES.Controls.conTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.conTextBox7 = new MES.Controls.conTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.conTextBox5 = new MES.Controls.conTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.conTextBox4 = new MES.Controls.conTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.conTextBox3 = new MES.Controls.conTextBox();
            this.conTextBox2 = new MES.Controls.conTextBox();
            this.txt_weight = new MES.Controls.conTextBox();
            this.lbl_raw_mat_gbn = new MES.Controls.conTextBox();
            this.txt_comment = new MES.Controls.conTextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmb_input_unit = new MES.Controls.conComboBox();
            this.lbl_weight = new System.Windows.Forms.Label();
            this.txt_mold_nm = new MES.Controls.conTextBox();
            this.cmb_raw_mat_gbn = new MES.Controls.conComboBox();
            this.lbl_mold_nm = new System.Windows.Forms.Label();
            this.lbl_mold_num = new System.Windows.Forms.Label();
            this.txt_mold_num = new MES.Controls.conTextBox();
            this.MOLD_NUM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MOLD_NM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COMMENT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.conTextBox6 = new MES.Controls.conTextBox();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataRawCdGrid)).BeginInit();
            this.SuspendLayout();
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
            this.panel2.TabIndex = 9;
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.lbl_title.Location = new System.Drawing.Point(9, -2); //new System.Drawing.Point(10, 5);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(156, 22);
            this.lbl_title.TabIndex = 93;
            this.lbl_title.Text = "금형설정 등록";
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
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Controls.Add(this.dataRawCdGrid);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.txt_srch);
            this.panel1.Controls.Add(this.cmb_cd_srch);
            this.panel1.Controls.Add(this.dateTimePicker2);
            this.panel1.Controls.Add(this.conTextBox8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.conTextBox7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.conTextBox5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.conTextBox4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.conTextBox3);
            this.panel1.Controls.Add(this.conTextBox6);
            this.panel1.Controls.Add(this.conTextBox2);
            this.panel1.Controls.Add(this.txt_weight);
            this.panel1.Controls.Add(this.lbl_raw_mat_gbn);
            this.panel1.Controls.Add(this.txt_comment);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cmb_input_unit);
            this.panel1.Controls.Add(this.lbl_weight);
            this.panel1.Controls.Add(this.txt_mold_nm);
            this.panel1.Controls.Add(this.cmb_raw_mat_gbn);
            this.panel1.Controls.Add(this.lbl_mold_nm);
            this.panel1.Controls.Add(this.lbl_mold_num);
            this.panel1.Controls.Add(this.txt_mold_num);
            this.panel1.Location = new System.Drawing.Point(0, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1357, 674);
            this.panel1.TabIndex = 10;
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
            this.MOLD_NUM,
            this.MOLD_NM,
            this.Column10,
            this.COMMENT});
            this.dataRawCdGrid.EnableHeadersVisualStyles = false;
            this.dataRawCdGrid.GridColor = System.Drawing.Color.PowderBlue;
            this.dataRawCdGrid.Location = new System.Drawing.Point(744, 55);
            this.dataRawCdGrid.Name = "dataRawCdGrid";
            this.dataRawCdGrid.ReadOnly = true;
            this.dataRawCdGrid.RowHeadersVisible = false;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dataRawCdGrid.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataRawCdGrid.RowTemplate.Height = 23;
            this.dataRawCdGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataRawCdGrid.Size = new System.Drawing.Size(610, 615);
            this.dataRawCdGrid.TabIndex = 384;
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
            this.btnSearch.Location = new System.Drawing.Point(1256, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(33, 33);
            this.btnSearch.TabIndex = 387;
            this.btnSearch.Tag = "검색";
            this.btnSearch.UseVisualStyleBackColor = false;
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
            this.txt_srch.Location = new System.Drawing.Point(1059, 15);
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
            this.cmb_cd_srch.Location = new System.Drawing.Point(882, 17);
            this.cmb_cd_srch.Name = "cmb_cd_srch";
            this.cmb_cd_srch.Size = new System.Drawing.Size(171, 20);
            this.cmb_cd_srch.TabIndex = 386;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Checked = false;
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(112, 258);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(212, 21);
            this.dateTimePicker2.TabIndex = 383;
            this.dateTimePicker2.Value = new System.DateTime(2018, 10, 8, 0, 0, 0, 0);
            // 
            // conTextBox8
            // 
            this.conTextBox8._AutoTab = true;
            this.conTextBox8._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.conTextBox8._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.conTextBox8._WaterMarkColor = System.Drawing.Color.Gray;
            this.conTextBox8._WaterMarkText = "";
            this.conTextBox8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.conTextBox8.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.conTextBox8.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.conTextBox8.Location = new System.Drawing.Point(113, 568);
            this.conTextBox8.MaxLength = 20;
            this.conTextBox8.Name = "conTextBox8";
            this.conTextBox8.Size = new System.Drawing.Size(211, 22);
            this.conTextBox8.TabIndex = 341;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.PowderBlue;
            this.label7.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.Location = new System.Drawing.Point(12, 567);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 22);
            this.label7.TabIndex = 340;
            this.label7.Text = "E등급 한계";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // conTextBox7
            // 
            this.conTextBox7._AutoTab = true;
            this.conTextBox7._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.conTextBox7._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.conTextBox7._WaterMarkColor = System.Drawing.Color.Gray;
            this.conTextBox7._WaterMarkText = "";
            this.conTextBox7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.conTextBox7.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.conTextBox7.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.conTextBox7.Location = new System.Drawing.Point(113, 522);
            this.conTextBox7.MaxLength = 20;
            this.conTextBox7.Name = "conTextBox7";
            this.conTextBox7.Size = new System.Drawing.Size(211, 22);
            this.conTextBox7.TabIndex = 339;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.PowderBlue;
            this.label6.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(12, 522);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 22);
            this.label6.TabIndex = 338;
            this.label6.Text = "D등급 한계";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // conTextBox5
            // 
            this.conTextBox5._AutoTab = true;
            this.conTextBox5._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.conTextBox5._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.conTextBox5._WaterMarkColor = System.Drawing.Color.Gray;
            this.conTextBox5._WaterMarkText = "";
            this.conTextBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.conTextBox5.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.conTextBox5.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.conTextBox5.Location = new System.Drawing.Point(113, 478);
            this.conTextBox5.MaxLength = 20;
            this.conTextBox5.Name = "conTextBox5";
            this.conTextBox5.Size = new System.Drawing.Size(211, 22);
            this.conTextBox5.TabIndex = 337;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.PowderBlue;
            this.label4.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(12, 477);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 22);
            this.label4.TabIndex = 336;
            this.label4.Text = "C등급 한계";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // conTextBox4
            // 
            this.conTextBox4._AutoTab = true;
            this.conTextBox4._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.conTextBox4._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.conTextBox4._WaterMarkColor = System.Drawing.Color.Gray;
            this.conTextBox4._WaterMarkText = "";
            this.conTextBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.conTextBox4.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.conTextBox4.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.conTextBox4.Location = new System.Drawing.Point(113, 433);
            this.conTextBox4.MaxLength = 20;
            this.conTextBox4.Name = "conTextBox4";
            this.conTextBox4.Size = new System.Drawing.Size(211, 22);
            this.conTextBox4.TabIndex = 335;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.PowderBlue;
            this.label3.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(12, 432);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 22);
            this.label3.TabIndex = 334;
            this.label3.Text = "B등급 한계";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // conTextBox3
            // 
            this.conTextBox3._AutoTab = true;
            this.conTextBox3._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.conTextBox3._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.conTextBox3._WaterMarkColor = System.Drawing.Color.Gray;
            this.conTextBox3._WaterMarkText = "";
            this.conTextBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.conTextBox3.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.conTextBox3.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.conTextBox3.Location = new System.Drawing.Point(113, 344);
            this.conTextBox3.MaxLength = 20;
            this.conTextBox3.Name = "conTextBox3";
            this.conTextBox3.Size = new System.Drawing.Size(212, 22);
            this.conTextBox3.TabIndex = 333;
            // 
            // conTextBox2
            // 
            this.conTextBox2._AutoTab = true;
            this.conTextBox2._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.conTextBox2._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.conTextBox2._WaterMarkColor = System.Drawing.Color.Gray;
            this.conTextBox2._WaterMarkText = "";
            this.conTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.conTextBox2.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.conTextBox2.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.conTextBox2.Location = new System.Drawing.Point(112, 169);
            this.conTextBox2.MaxLength = 20;
            this.conTextBox2.Name = "conTextBox2";
            this.conTextBox2.Size = new System.Drawing.Size(212, 22);
            this.conTextBox2.TabIndex = 332;
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
            this.txt_weight.Location = new System.Drawing.Point(112, 127);
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
            this.lbl_raw_mat_gbn.Location = new System.Drawing.Point(378, 552);
            this.lbl_raw_mat_gbn.MaxLength = 6;
            this.lbl_raw_mat_gbn.Name = "lbl_raw_mat_gbn";
            this.lbl_raw_mat_gbn.Size = new System.Drawing.Size(171, 22);
            this.lbl_raw_mat_gbn.TabIndex = 330;
            this.lbl_raw_mat_gbn.Visible = false;
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
            this.txt_comment.Location = new System.Drawing.Point(113, 388);
            this.txt_comment.MaxLength = 20;
            this.txt_comment.Name = "txt_comment";
            this.txt_comment.Size = new System.Drawing.Size(211, 22);
            this.txt_comment.TabIndex = 327;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.PowderBlue;
            this.label16.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label16.Location = new System.Drawing.Point(12, 387);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(100, 22);
            this.label16.TabIndex = 326;
            this.label16.Text = "A등급 한계";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.PowderBlue;
            this.label14.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label14.Location = new System.Drawing.Point(12, 343);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(100, 22);
            this.label14.TabIndex = 322;
            this.label14.Text = "수명";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.PowderBlue;
            this.label12.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label12.Location = new System.Drawing.Point(11, 168);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(100, 22);
            this.label12.TabIndex = 316;
            this.label12.Text = "최종타수";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.PowderBlue;
            this.label10.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label10.Location = new System.Drawing.Point(11, 256);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 22);
            this.label10.TabIndex = 312;
            this.label10.Text = "금형시작일자";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.PowderBlue;
            this.label9.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label9.Location = new System.Drawing.Point(11, 212);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 22);
            this.label9.TabIndex = 307;
            this.label9.Text = "금형선택";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.PowderBlue;
            this.label5.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(385, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 22);
            this.label5.TabIndex = 300;
            this.label5.Text = "공정선택";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmb_input_unit
            // 
            this.cmb_input_unit._BorderColor = System.Drawing.Color.Transparent;
            this.cmb_input_unit._FocusedBackColor = System.Drawing.Color.White;
            this.cmb_input_unit.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cmb_input_unit.FormattingEnabled = true;
            this.cmb_input_unit.Location = new System.Drawing.Point(112, 214);
            this.cmb_input_unit.Name = "cmb_input_unit";
            this.cmb_input_unit.Size = new System.Drawing.Size(212, 20);
            this.cmb_input_unit.TabIndex = 299;
            // 
            // lbl_weight
            // 
            this.lbl_weight.BackColor = System.Drawing.Color.PowderBlue;
            this.lbl_weight.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_weight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_weight.Location = new System.Drawing.Point(11, 126);
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
            this.txt_mold_nm.Location = new System.Drawing.Point(112, 85);
            this.txt_mold_nm.MaxLength = 20;
            this.txt_mold_nm.Name = "txt_mold_nm";
            this.txt_mold_nm.Size = new System.Drawing.Size(212, 22);
            this.txt_mold_nm.TabIndex = 295;
            // 
            // cmb_raw_mat_gbn
            // 
            this.cmb_raw_mat_gbn._BorderColor = System.Drawing.Color.Transparent;
            this.cmb_raw_mat_gbn._FocusedBackColor = System.Drawing.Color.White;
            this.cmb_raw_mat_gbn.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cmb_raw_mat_gbn.FormattingEnabled = true;
            this.cmb_raw_mat_gbn.Location = new System.Drawing.Point(486, 44);
            this.cmb_raw_mat_gbn.Name = "cmb_raw_mat_gbn";
            this.cmb_raw_mat_gbn.Size = new System.Drawing.Size(212, 20);
            this.cmb_raw_mat_gbn.TabIndex = 292;
            // 
            // lbl_mold_nm
            // 
            this.lbl_mold_nm.BackColor = System.Drawing.Color.PowderBlue;
            this.lbl_mold_nm.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_mold_nm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_mold_nm.Location = new System.Drawing.Point(11, 85);
            this.lbl_mold_nm.Name = "lbl_mold_nm";
            this.lbl_mold_nm.Size = new System.Drawing.Size(100, 22);
            this.lbl_mold_nm.TabIndex = 291;
            this.lbl_mold_nm.Text = "금형명";
            this.lbl_mold_nm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_mold_num
            // 
            this.lbl_mold_num.BackColor = System.Drawing.Color.PowderBlue;
            this.lbl_mold_num.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_mold_num.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_mold_num.Location = new System.Drawing.Point(11, 42);
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
            this.txt_mold_num.Location = new System.Drawing.Point(112, 42);
            this.txt_mold_num.MaxLength = 6;
            this.txt_mold_num.Name = "txt_mold_num";
            this.txt_mold_num.Size = new System.Drawing.Size(212, 22);
            this.txt_mold_num.TabIndex = 287;
            // 
            // MOLD_NUM
            // 
            this.MOLD_NUM.HeaderText = "금형번호";
            this.MOLD_NUM.Name = "MOLD_NUM";
            this.MOLD_NUM.ReadOnly = true;
            this.MOLD_NUM.Width = 120;
            // 
            // MOLD_NM
            // 
            this.MOLD_NM.HeaderText = "금형이름";
            this.MOLD_NM.Name = "MOLD_NM";
            this.MOLD_NM.ReadOnly = true;
            this.MOLD_NM.Width = 250;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "금형";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Visible = false;
            this.Column10.Width = 220;
            // 
            // COMMENT
            // 
            this.COMMENT.HeaderText = "비고";
            this.COMMENT.Name = "COMMENT";
            this.COMMENT.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.PowderBlue;
            this.label1.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(12, 299);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 22);
            this.label1.TabIndex = 316;
            this.label1.Text = "최종타수";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // conTextBox6
            // 
            this.conTextBox6._AutoTab = true;
            this.conTextBox6._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.conTextBox6._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.conTextBox6._WaterMarkColor = System.Drawing.Color.Gray;
            this.conTextBox6._WaterMarkText = "";
            this.conTextBox6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.conTextBox6.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.conTextBox6.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.conTextBox6.Location = new System.Drawing.Point(113, 300);
            this.conTextBox6.MaxLength = 20;
            this.conTextBox6.Name = "conTextBox6";
            this.conTextBox6.Size = new System.Drawing.Size(212, 22);
            this.conTextBox6.TabIndex = 332;
            // 
            // frm금형설정등록
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1360, 714);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frm금형설정등록";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frm금형설정등록";
            this.Load += new System.EventHandler(this.frm금형설정등록_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataRawCdGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Panel panel1;
        private Controls.conTextBox lbl_raw_mat_gbn;
        private Controls.conTextBox txt_comment;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private Controls.conComboBox cmb_input_unit;
        private System.Windows.Forms.Label lbl_weight;
        private Controls.conTextBox txt_mold_nm;
        private Controls.conComboBox cmb_raw_mat_gbn;
        private System.Windows.Forms.Label lbl_mold_nm;
        private System.Windows.Forms.Label lbl_mold_num;
        private Controls.conTextBox txt_mold_num;
        private Controls.conTextBox txt_weight;
        private Controls.conTextBox conTextBox8;
        private System.Windows.Forms.Label label7;
        private Controls.conTextBox conTextBox7;
        private System.Windows.Forms.Label label6;
        private Controls.conTextBox conTextBox5;
        private System.Windows.Forms.Label label4;
        private Controls.conTextBox conTextBox4;
        private System.Windows.Forms.Label label3;
        private Controls.conTextBox conTextBox3;
        private Controls.conTextBox conTextBox2;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DataGridView dataRawCdGrid;
        private System.Windows.Forms.Button btnSearch;
        private Controls.conTextBox txt_srch;
        private Controls.conComboBox cmb_cd_srch;
        private System.Windows.Forms.DataGridViewTextBoxColumn MOLD_NUM;
        private System.Windows.Forms.DataGridViewTextBoxColumn MOLD_NM;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn COMMENT;
        private Controls.conTextBox conTextBox6;
        private System.Windows.Forms.Label label1;

    }
}