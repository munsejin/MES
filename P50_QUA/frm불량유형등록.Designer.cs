namespace MES.P50_QUA
{
    partial class frm불량유형등록
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm불량유형등록));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_title = new System.Windows.Forms.Label();
            this.lbl_chk_gbn = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_cnt = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.cmb_poor_gubun = new MES.Controls.conComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txt_srch = new MES.Controls.conTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radio_raw = new System.Windows.Forms.RadioButton();
            this.radio_flow = new System.Windows.Forms.RadioButton();
            this.txt_comment = new MES.Controls.conTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_flow_nm = new System.Windows.Forms.Label();
            this.lbl_flow_cd = new System.Windows.Forms.Label();
            this.txt_poor_nm = new MES.Controls.conTextBox();
            this.txt_poor_cd = new MES.Controls.conTextBox();
            this.dataChkGrid = new MES.Controls.myDataGridView();
            this.POOR_CD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.POOR_GUBUN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.POOR_NM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COMMENT = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataChkGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.lbl_title);
            this.panel2.Controls.Add(this.lbl_chk_gbn);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.btnNew);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.btnDelete);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1360, 33);
            this.panel2.TabIndex = 8;
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.Font = new System.Drawing.Font("SpoqaHanSans-Bold", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.lbl_title.Location = new System.Drawing.Point(9, -2); //new System.Drawing.Point(10, 2);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(126, 28);
            this.lbl_title.TabIndex = 386;
            this.lbl_title.Text = "불량유형 등록";
            // 
            // lbl_chk_gbn
            // 
            this.lbl_chk_gbn.BackColor = System.Drawing.Color.PowderBlue;
            this.lbl_chk_gbn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_chk_gbn.Location = new System.Drawing.Point(747, 5);
            this.lbl_chk_gbn.Name = "lbl_chk_gbn";
            this.lbl_chk_gbn.Size = new System.Drawing.Size(100, 22);
            this.lbl_chk_gbn.TabIndex = 338;
            this.lbl_chk_gbn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_chk_gbn.Visible = false;
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
            this.btnClose.Location = new System.Drawing.Point(1282, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(74, 29);
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
            this.btnNew.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Bold);
            this.btnNew.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.btnNew.Image = global::MES.Properties.Resources.newnewBtn;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNew.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnNew.Location = new System.Drawing.Point(858, 3);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(74, 29);
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
            this.btnSave.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.btnSave.Image = global::MES.Properties.Resources.newSaveBtn;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSave.Location = new System.Drawing.Point(938, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(74, 29);
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
            this.btnDelete.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.btnDelete.Image = global::MES.Properties.Resources.newDelBtn;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDelete.Location = new System.Drawing.Point(1017, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(74, 29);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Tag = "삭제";
            this.btnDelete.Text = "삭제";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.lbl_cnt);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.cmb_poor_gubun);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.txt_srch);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.txt_comment);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.lbl_flow_nm);
            this.panel1.Controls.Add(this.lbl_flow_cd);
            this.panel1.Controls.Add(this.txt_poor_nm);
            this.panel1.Controls.Add(this.txt_poor_cd);
            this.panel1.Controls.Add(this.dataChkGrid);
            this.panel1.Location = new System.Drawing.Point(0, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1360, 679);
            this.panel1.TabIndex = 9;
            // 
            // lbl_cnt
            // 
            this.lbl_cnt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_cnt.BackColor = System.Drawing.Color.White;
            this.lbl_cnt.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_cnt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_cnt.Location = new System.Drawing.Point(1294, 13);
            this.lbl_cnt.Name = "lbl_cnt";
            this.lbl_cnt.Size = new System.Drawing.Size(60, 23);
            this.lbl_cnt.TabIndex = 349;
            this.lbl_cnt.Text = "0";
            this.lbl_cnt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.BackColor = System.Drawing.Color.White;
            this.label16.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label16.Location = new System.Drawing.Point(1214, 13);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(70, 23);
            this.label16.TabIndex = 348;
            this.label16.Text = "목록수: ";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmb_poor_gubun
            // 
            this.cmb_poor_gubun._BorderColor = System.Drawing.Color.Transparent;
            this.cmb_poor_gubun._FocusedBackColor = System.Drawing.Color.White;
            this.cmb_poor_gubun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_poor_gubun.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cmb_poor_gubun.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F);
            this.cmb_poor_gubun.FormattingEnabled = true;
            this.cmb_poor_gubun.Location = new System.Drawing.Point(860, 7);
            this.cmb_poor_gubun.Name = "cmb_poor_gubun";
            this.cmb_poor_gubun.Size = new System.Drawing.Size(116, 30);
            this.cmb_poor_gubun.TabIndex = 347;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.BackColor = System.Drawing.Color.Transparent;
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(1143, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(33, 33);
            this.btnSearch.TabIndex = 346;
            this.btnSearch.Tag = "검색";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txt_srch
            // 
            this.txt_srch._AutoTab = true;
            this.txt_srch._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.txt_srch._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txt_srch._WaterMarkColor = System.Drawing.Color.Gray;
            this.txt_srch._WaterMarkText = "";
            this.txt_srch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_srch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_srch.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F);
            this.txt_srch.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.txt_srch.Location = new System.Drawing.Point(982, 7);
            this.txt_srch.MaxLength = 20;
            this.txt_srch.Name = "txt_srch";
            this.txt_srch.Size = new System.Drawing.Size(157, 29);
            this.txt_srch.TabIndex = 345;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radio_raw);
            this.groupBox2.Controls.Add(this.radio_flow);
            this.groupBox2.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox2.Location = new System.Drawing.Point(12, 106);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(289, 61);
            this.groupBox2.TabIndex = 337;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "검사 구분";
            // 
            // radio_raw
            // 
            this.radio_raw.AutoSize = true;
            this.radio_raw.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.radio_raw.Location = new System.Drawing.Point(45, 26);
            this.radio_raw.Name = "radio_raw";
            this.radio_raw.Size = new System.Drawing.Size(102, 26);
            this.radio_raw.TabIndex = 3;
            this.radio_raw.Text = "원자재 수입";
            this.radio_raw.UseVisualStyleBackColor = true;
            // 
            // radio_flow
            // 
            this.radio_flow.AutoSize = true;
            this.radio_flow.Checked = true;
            this.radio_flow.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.radio_flow.Location = new System.Drawing.Point(186, 26);
            this.radio_flow.Name = "radio_flow";
            this.radio_flow.Size = new System.Drawing.Size(56, 26);
            this.radio_flow.TabIndex = 4;
            this.radio_flow.TabStop = true;
            this.radio_flow.Text = "공정";
            this.radio_flow.UseVisualStyleBackColor = true;
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
            this.txt_comment.Location = new System.Drawing.Point(113, 175);
            this.txt_comment.MaxLength = 20;
            this.txt_comment.Multiline = true;
            this.txt_comment.Name = "txt_comment";
            this.txt_comment.Size = new System.Drawing.Size(645, 29);
            this.txt_comment.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label6.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(12, 175);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 29);
            this.label6.TabIndex = 326;
            this.label6.Text = "비고";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_flow_nm
            // 
            this.lbl_flow_nm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.lbl_flow_nm.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_flow_nm.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbl_flow_nm.Location = new System.Drawing.Point(12, 77);
            this.lbl_flow_nm.Name = "lbl_flow_nm";
            this.lbl_flow_nm.Size = new System.Drawing.Size(117, 29);
            this.lbl_flow_nm.TabIndex = 316;
            this.lbl_flow_nm.Text = "불량유형명";
            this.lbl_flow_nm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_flow_cd
            // 
            this.lbl_flow_cd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.lbl_flow_cd.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_flow_cd.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbl_flow_cd.Location = new System.Drawing.Point(12, 43);
            this.lbl_flow_cd.Name = "lbl_flow_cd";
            this.lbl_flow_cd.Size = new System.Drawing.Size(117, 29);
            this.lbl_flow_cd.TabIndex = 314;
            this.lbl_flow_cd.Text = "불량유형 코드";
            this.lbl_flow_cd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_poor_nm
            // 
            this.txt_poor_nm._AutoTab = true;
            this.txt_poor_nm._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.txt_poor_nm._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txt_poor_nm._WaterMarkColor = System.Drawing.Color.Gray;
            this.txt_poor_nm._WaterMarkText = "";
            this.txt_poor_nm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_poor_nm.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_poor_nm.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.txt_poor_nm.Location = new System.Drawing.Point(129, 76);
            this.txt_poor_nm.MaxLength = 20;
            this.txt_poor_nm.Name = "txt_poor_nm";
            this.txt_poor_nm.Size = new System.Drawing.Size(172, 29);
            this.txt_poor_nm.TabIndex = 2;
            // 
            // txt_poor_cd
            // 
            this.txt_poor_cd._AutoTab = true;
            this.txt_poor_cd._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.txt_poor_cd._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txt_poor_cd._WaterMarkColor = System.Drawing.Color.Gray;
            this.txt_poor_cd._WaterMarkText = "";
            this.txt_poor_cd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txt_poor_cd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_poor_cd.Enabled = false;
            this.txt_poor_cd.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_poor_cd.ForeColor = System.Drawing.Color.DarkGray;
            this.txt_poor_cd.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.txt_poor_cd.Location = new System.Drawing.Point(129, 43);
            this.txt_poor_cd.MaxLength = 10;
            this.txt_poor_cd.Name = "txt_poor_cd";
            this.txt_poor_cd.Size = new System.Drawing.Size(172, 29);
            this.txt_poor_cd.TabIndex = 1;
            this.txt_poor_cd.Text = "(자동발급)";
            this.txt_poor_cd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dataChkGrid
            // 
            this.dataChkGrid.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.dataChkGrid.AllowUserToAddRows = false;
            this.dataChkGrid.AllowUserToDeleteRows = false;
            this.dataChkGrid.AllowUserToResizeColumns = false;
            this.dataChkGrid.AllowUserToResizeRows = false;
            this.dataChkGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataChkGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataChkGrid.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataChkGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataChkGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataChkGrid.ColumnHeadersHeight = 35;
            this.dataChkGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.POOR_CD,
            this.POOR_GUBUN,
            this.POOR_NM,
            this.COMMENT});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataChkGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataChkGrid.EnableHeadersVisualStyles = false;
            this.dataChkGrid.GridColor = System.Drawing.Color.PowderBlue;
            this.dataChkGrid.Location = new System.Drawing.Point(860, 43);
            this.dataChkGrid.Name = "dataChkGrid";
            this.dataChkGrid.ReadOnly = true;
            this.dataChkGrid.RowHeadersVisible = false;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.dataChkGrid.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataChkGrid.RowTemplate.Height = 23;
            this.dataChkGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataChkGrid.Size = new System.Drawing.Size(494, 630);
            this.dataChkGrid.TabIndex = 312;
            this.dataChkGrid.TabStop = false;
            this.dataChkGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataChkGrid_CellContentClick);
            this.dataChkGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataChkGrid_CellDoubleClick);
            // 
            // POOR_CD
            // 
            this.POOR_CD.FillWeight = 72F;
            this.POOR_CD.HeaderText = "유형코드";
            this.POOR_CD.MinimumWidth = 72;
            this.POOR_CD.Name = "POOR_CD";
            this.POOR_CD.ReadOnly = true;
            this.POOR_CD.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.POOR_CD.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // POOR_GUBUN
            // 
            this.POOR_GUBUN.FillWeight = 74F;
            this.POOR_GUBUN.HeaderText = "불량형태";
            this.POOR_GUBUN.MinimumWidth = 72;
            this.POOR_GUBUN.Name = "POOR_GUBUN";
            this.POOR_GUBUN.ReadOnly = true;
            this.POOR_GUBUN.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.POOR_GUBUN.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // POOR_NM
            // 
            this.POOR_NM.FillWeight = 177F;
            this.POOR_NM.HeaderText = "불량명";
            this.POOR_NM.MinimumWidth = 58;
            this.POOR_NM.Name = "POOR_NM";
            this.POOR_NM.ReadOnly = true;
            this.POOR_NM.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.POOR_NM.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // COMMENT
            // 
            this.COMMENT.FillWeight = 169F;
            this.COMMENT.HeaderText = "비고";
            this.COMMENT.MinimumWidth = 50;
            this.COMMENT.Name = "COMMENT";
            this.COMMENT.ReadOnly = true;
            this.COMMENT.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.COMMENT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "STAFF_CD";
            this.dataGridViewTextBoxColumn1.HeaderText = "코드";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 160;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn2.HeaderText = "구분";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 50;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn3.HeaderText = "검사항목명";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 150;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "DEPT_NM";
            this.dataGridViewTextBoxColumn4.HeaderText = "검사위치";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 120;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "DEPT_NM";
            this.dataGridViewTextBoxColumn5.HeaderText = "구분코드";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Visible = false;
            this.dataGridViewTextBoxColumn5.Width = 140;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "규정치";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Visible = false;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "채용한계";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Visible = false;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "측정기구";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Visible = false;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "검사주기";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Visible = false;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "검사주기";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Visible = false;
            // 
            // frm불량유형등록
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1360, 714);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "frm불량유형등록";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frm불량유형등록";
            this.Load += new System.EventHandler(this.frm불량유형등록_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataChkGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_flow_nm;
        private System.Windows.Forms.Label lbl_flow_cd;
        private Controls.conTextBox txt_poor_nm;
        private Controls.conTextBox txt_poor_cd;
        private Controls.conTextBox txt_comment;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radio_flow;
        private System.Windows.Forms.Label lbl_chk_gbn;
        private System.Windows.Forms.Label lbl_cnt;
        private System.Windows.Forms.Label label16;
        private Controls.conComboBox cmb_poor_gubun;
        private System.Windows.Forms.Button btnSearch;
        private Controls.conTextBox txt_srch;
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
        private System.Windows.Forms.RadioButton radio_raw;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.DataGridViewTextBoxColumn POOR_CD;
        private System.Windows.Forms.DataGridViewTextBoxColumn POOR_GUBUN;
        private System.Windows.Forms.DataGridViewTextBoxColumn POOR_NM;
        private System.Windows.Forms.DataGridViewTextBoxColumn COMMENT;
        private Controls.myDataGridView dataChkGrid;
    }
}