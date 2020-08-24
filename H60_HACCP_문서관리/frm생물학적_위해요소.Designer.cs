namespace MES.H60_HACCP_문서관리
{
    partial class frm생물학적_위해요소
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm생물학적_위해요소));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_save = new System.Windows.Forms.Button();
            this.lbl_title = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAllSave = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_docs_srch = new MES.Controls.conTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_upper_date = new System.Windows.Forms.DateTimePicker();
            this.txt_lower_date = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_srch1 = new System.Windows.Forms.Button();
            this.lbl_user_gbn = new System.Windows.Forms.Label();
            this.txt_staff_cd = new MES.Controls.conTextBox();
            this.btn_file_srch = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.txt_file_path = new MES.Controls.conTextBox();
            this.btn_Change_p = new System.Windows.Forms.Button();
            this.txt_root_path = new MES.Controls.conTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txt_comment = new MES.Controls.conTextBox();
            this.txt_staff_nm = new MES.Controls.conTextBox();
            this.input_date = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.HaccpGrid2 = new MES.Controls.myDataGridView();
            this.DATE2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STAFF2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COMMENT2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FILENM2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PATH2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INPUT_CD2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HaccpGrid2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.PaleTurquoise;
            this.panel2.Controls.Add(this.btn_save);
            this.panel2.Controls.Add(this.lbl_title);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.btnAllSave);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1360, 33);
            this.panel2.TabIndex = 6;
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.Color.Transparent;
            this.btn_save.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_save.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_save.FlatAppearance.BorderSize = 0;
            this.btn_save.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_save.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F);
            this.btn_save.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.btn_save.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_save.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_save.Location = new System.Drawing.Point(1057, 2);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(92, 29);
            this.btn_save.TabIndex = 94;
            this.btn_save.Tag = "저장";
            this.btn_save.Text = "파일등록";
            this.btn_save.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.lbl_title.Location = new System.Drawing.Point(9, -2); //new System.Drawing.Point(10, 5);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(202, 22);
            this.lbl_title.TabIndex = 93;
            this.lbl_title.Text = "생물학적 위해요소";
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
            this.btnClose.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F);
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
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
            // btnAllSave
            // 
            this.btnAllSave.BackColor = System.Drawing.Color.Transparent;
            this.btnAllSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAllSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAllSave.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAllSave.FlatAppearance.BorderSize = 0;
            this.btnAllSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAllSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAllSave.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F);
            this.btnAllSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.btnAllSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAllSave.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAllSave.Location = new System.Drawing.Point(835, 2);
            this.btnAllSave.Name = "btnAllSave";
            this.btnAllSave.Size = new System.Drawing.Size(150, 29);
            this.btnAllSave.TabIndex = 0;
            this.btnAllSave.Tag = "저장";
            this.btnAllSave.Text = "폴더스캔(일괄등록)";
            this.btnAllSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAllSave.UseVisualStyleBackColor = false;
            this.btnAllSave.Click += new System.EventHandler(this.btnAllSave_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txt_docs_srch);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txt_upper_date);
            this.panel1.Controls.Add(this.txt_lower_date);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.btn_srch1);
            this.panel1.Controls.Add(this.lbl_user_gbn);
            this.panel1.Controls.Add(this.txt_staff_cd);
            this.panel1.Controls.Add(this.btn_file_srch);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.txt_file_path);
            this.panel1.Controls.Add(this.btn_Change_p);
            this.panel1.Controls.Add(this.txt_root_path);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.txt_comment);
            this.panel1.Controls.Add(this.txt_staff_nm);
            this.panel1.Controls.Add(this.input_date);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.HaccpGrid2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1360, 681);
            this.panel1.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(450, 270);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 389;
            this.label8.Text = "파일명";
            // 
            // txt_docs_srch
            // 
            this.txt_docs_srch._AutoTab = true;
            this.txt_docs_srch._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.txt_docs_srch._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txt_docs_srch._WaterMarkColor = System.Drawing.Color.Gray;
            this.txt_docs_srch._WaterMarkText = "";
            this.txt_docs_srch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_docs_srch.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_docs_srch.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.txt_docs_srch.Location = new System.Drawing.Point(507, 265);
            this.txt_docs_srch.MaxLength = 20;
            this.txt_docs_srch.Name = "txt_docs_srch";
            this.txt_docs_srch.Size = new System.Drawing.Size(171, 22);
            this.txt_docs_srch.TabIndex = 388;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(269, 271);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 12);
            this.label5.TabIndex = 387;
            this.label5.Text = "~";
            // 
            // txt_upper_date
            // 
            this.txt_upper_date.Checked = false;
            this.txt_upper_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txt_upper_date.Location = new System.Drawing.Point(298, 266);
            this.txt_upper_date.Name = "txt_upper_date";
            this.txt_upper_date.Size = new System.Drawing.Size(124, 21);
            this.txt_upper_date.TabIndex = 386;
            this.txt_upper_date.Value = new System.DateTime(2018, 9, 16, 20, 27, 55, 0);
            // 
            // txt_lower_date
            // 
            this.txt_lower_date.Checked = false;
            this.txt_lower_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txt_lower_date.Location = new System.Drawing.Point(134, 266);
            this.txt_lower_date.Name = "txt_lower_date";
            this.txt_lower_date.Size = new System.Drawing.Size(124, 21);
            this.txt_lower_date.TabIndex = 385;
            this.txt_lower_date.Value = new System.DateTime(2018, 9, 16, 20, 27, 55, 0);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(64, 270);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 384;
            this.label6.Text = "작성일자";
            // 
            // btn_srch1
            // 
            this.btn_srch1.BackColor = System.Drawing.Color.Transparent;
            this.btn_srch1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_srch1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_srch1.FlatAppearance.BorderSize = 0;
            this.btn_srch1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btn_srch1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_srch1.Image = ((System.Drawing.Image)(resources.GetObject("btn_srch1.Image")));
            this.btn_srch1.Location = new System.Drawing.Point(685, 260);
            this.btn_srch1.Name = "btn_srch1";
            this.btn_srch1.Size = new System.Drawing.Size(33, 33);
            this.btn_srch1.TabIndex = 383;
            this.btn_srch1.Tag = "검색";
            this.btn_srch1.UseVisualStyleBackColor = false;
            this.btn_srch1.Click += new System.EventHandler(this.btn_srch1_Click);
            // 
            // lbl_user_gbn
            // 
            this.lbl_user_gbn.BackColor = System.Drawing.Color.PowderBlue;
            this.lbl_user_gbn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_user_gbn.Location = new System.Drawing.Point(946, 112);
            this.lbl_user_gbn.Name = "lbl_user_gbn";
            this.lbl_user_gbn.Size = new System.Drawing.Size(100, 22);
            this.lbl_user_gbn.TabIndex = 382;
            this.lbl_user_gbn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_user_gbn.Visible = false;
            // 
            // txt_staff_cd
            // 
            this.txt_staff_cd._AutoTab = true;
            this.txt_staff_cd._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.txt_staff_cd._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txt_staff_cd._WaterMarkColor = System.Drawing.Color.Gray;
            this.txt_staff_cd._WaterMarkText = "";
            this.txt_staff_cd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_staff_cd.Enabled = false;
            this.txt_staff_cd.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_staff_cd.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.txt_staff_cd.Location = new System.Drawing.Point(343, 159);
            this.txt_staff_cd.MaxLength = 20;
            this.txt_staff_cd.Name = "txt_staff_cd";
            this.txt_staff_cd.Size = new System.Drawing.Size(171, 22);
            this.txt_staff_cd.TabIndex = 381;
            this.txt_staff_cd.Visible = false;
            // 
            // btn_file_srch
            // 
            this.btn_file_srch.Location = new System.Drawing.Point(735, 225);
            this.btn_file_srch.Name = "btn_file_srch";
            this.btn_file_srch.Size = new System.Drawing.Size(75, 23);
            this.btn_file_srch.TabIndex = 380;
            this.btn_file_srch.Text = "검색";
            this.btn_file_srch.UseVisualStyleBackColor = true;
            this.btn_file_srch.Click += new System.EventHandler(this.btn_file_srch_Click);
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.Color.PowderBlue;
            this.label20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label20.Location = new System.Drawing.Point(65, 226);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(100, 22);
            this.label20.TabIndex = 379;
            this.label20.Text = "파일";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_file_path
            // 
            this.txt_file_path._AutoTab = true;
            this.txt_file_path._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.txt_file_path._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txt_file_path._WaterMarkColor = System.Drawing.Color.Gray;
            this.txt_file_path._WaterMarkText = "";
            this.txt_file_path.BackColor = System.Drawing.SystemColors.Window;
            this.txt_file_path.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_file_path.Enabled = false;
            this.txt_file_path.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_file_path.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.txt_file_path.Location = new System.Drawing.Point(166, 226);
            this.txt_file_path.MaxLength = 20;
            this.txt_file_path.Name = "txt_file_path";
            this.txt_file_path.Size = new System.Drawing.Size(563, 22);
            this.txt_file_path.TabIndex = 378;
            // 
            // btn_Change_p
            // 
            this.btn_Change_p.Location = new System.Drawing.Point(644, 55);
            this.btn_Change_p.Name = "btn_Change_p";
            this.btn_Change_p.Size = new System.Drawing.Size(75, 23);
            this.btn_Change_p.TabIndex = 374;
            this.btn_Change_p.Text = "수정";
            this.btn_Change_p.UseVisualStyleBackColor = true;
            this.btn_Change_p.Click += new System.EventHandler(this.btn_Change_p_Click);
            // 
            // txt_root_path
            // 
            this.txt_root_path._AutoTab = true;
            this.txt_root_path._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.txt_root_path._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txt_root_path._WaterMarkColor = System.Drawing.Color.Gray;
            this.txt_root_path._WaterMarkText = "";
            this.txt_root_path.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_root_path.Enabled = false;
            this.txt_root_path.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_root_path.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.txt_root_path.Location = new System.Drawing.Point(164, 56);
            this.txt_root_path.MaxLength = 20;
            this.txt_root_path.Name = "txt_root_path";
            this.txt_root_path.Size = new System.Drawing.Size(418, 22);
            this.txt_root_path.TabIndex = 373;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.PowderBlue;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(63, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 22);
            this.label3.TabIndex = 372;
            this.label3.Text = "작업경로";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.PowderBlue;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(65, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 22);
            this.label2.TabIndex = 371;
            this.label2.Text = "등록사원";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.PowderBlue;
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label15.Location = new System.Drawing.Point(65, 190);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(100, 22);
            this.label15.TabIndex = 370;
            this.label15.Text = "비고";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.txt_comment.Location = new System.Drawing.Point(166, 190);
            this.txt_comment.MaxLength = 20;
            this.txt_comment.Name = "txt_comment";
            this.txt_comment.Size = new System.Drawing.Size(418, 22);
            this.txt_comment.TabIndex = 369;
            // 
            // txt_staff_nm
            // 
            this.txt_staff_nm._AutoTab = true;
            this.txt_staff_nm._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.txt_staff_nm._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txt_staff_nm._WaterMarkColor = System.Drawing.Color.Gray;
            this.txt_staff_nm._WaterMarkText = "";
            this.txt_staff_nm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_staff_nm.Enabled = false;
            this.txt_staff_nm.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_staff_nm.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.txt_staff_nm.Location = new System.Drawing.Point(166, 159);
            this.txt_staff_nm.MaxLength = 20;
            this.txt_staff_nm.Name = "txt_staff_nm";
            this.txt_staff_nm.Size = new System.Drawing.Size(171, 22);
            this.txt_staff_nm.TabIndex = 368;
            // 
            // input_date
            // 
            this.input_date.Checked = false;
            this.input_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.input_date.Location = new System.Drawing.Point(166, 128);
            this.input_date.Name = "input_date";
            this.input_date.Size = new System.Drawing.Size(171, 21);
            this.input_date.TabIndex = 367;
            this.input_date.Value = new System.DateTime(2018, 9, 16, 20, 27, 55, 0);
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.PowderBlue;
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label11.Location = new System.Drawing.Point(65, 127);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(100, 22);
            this.label11.TabIndex = 366;
            this.label11.Text = "문서작성일자";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // HaccpGrid2
            // 
            this.HaccpGrid2.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.HaccpGrid2.AllowUserToAddRows = false;
            this.HaccpGrid2.AllowUserToDeleteRows = false;
            this.HaccpGrid2.AllowUserToOrderColumns = true;
            this.HaccpGrid2.AllowUserToResizeColumns = false;
            this.HaccpGrid2.AllowUserToResizeRows = false;
            this.HaccpGrid2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HaccpGrid2.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.HaccpGrid2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.HaccpGrid2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.HaccpGrid2.ColumnHeadersHeight = 30;
            this.HaccpGrid2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DATE2,
            this.STAFF2,
            this.COMMENT2,
            this.FILENM2,
            this.PATH2,
            this.INPUT_CD2});
            this.HaccpGrid2.EnableHeadersVisualStyles = false;
            this.HaccpGrid2.GridColor = System.Drawing.Color.PowderBlue;
            this.HaccpGrid2.Location = new System.Drawing.Point(14, 320);
            this.HaccpGrid2.MultiSelect = false;
            this.HaccpGrid2.Name = "HaccpGrid2";
            this.HaccpGrid2.RowHeadersVisible = false;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.HaccpGrid2.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.HaccpGrid2.RowTemplate.Height = 23;
            this.HaccpGrid2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.HaccpGrid2.Size = new System.Drawing.Size(1314, 349);
            this.HaccpGrid2.TabIndex = 365;
            this.HaccpGrid2.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.HaccpGrid2_CellDoubleClick);
            this.HaccpGrid2.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.HaccpGrid2_CellEndEdit);
            // 
            // DATE2
            // 
            this.DATE2.Frozen = true;
            this.DATE2.HeaderText = "작성일자";
            this.DATE2.Name = "DATE2";
            this.DATE2.ReadOnly = true;
            this.DATE2.Width = 150;
            // 
            // STAFF2
            // 
            this.STAFF2.Frozen = true;
            this.STAFF2.HeaderText = "등록사원";
            this.STAFF2.Name = "STAFF2";
            this.STAFF2.ReadOnly = true;
            this.STAFF2.Width = 150;
            // 
            // COMMENT2
            // 
            this.COMMENT2.Frozen = true;
            this.COMMENT2.HeaderText = "비고";
            this.COMMENT2.Name = "COMMENT2";
            this.COMMENT2.ReadOnly = true;
            this.COMMENT2.Width = 300;
            // 
            // FILENM2
            // 
            this.FILENM2.Frozen = true;
            this.FILENM2.HeaderText = "파일명";
            this.FILENM2.Name = "FILENM2";
            this.FILENM2.ReadOnly = true;
            this.FILENM2.Width = 250;
            // 
            // PATH2
            // 
            this.PATH2.Frozen = true;
            this.PATH2.HeaderText = "경로";
            this.PATH2.Name = "PATH2";
            this.PATH2.ReadOnly = true;
            this.PATH2.Width = 460;
            // 
            // INPUT_CD2
            // 
            this.INPUT_CD2.HeaderText = "INPUT_CD2";
            this.INPUT_CD2.Name = "INPUT_CD2";
            this.INPUT_CD2.ReadOnly = true;
            this.INPUT_CD2.Visible = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // frm생물학적_위해요소
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1360, 714);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "frm생물학적_위해요소";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frm생물학적_위해요소";
            this.Load += new System.EventHandler(this.frm생물학적_위해요소_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HaccpGrid2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAllSave;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView HaccpGrid2;
        private System.Windows.Forms.DataGridViewTextBoxColumn DATE2;
        private System.Windows.Forms.DataGridViewTextBoxColumn STAFF2;
        private System.Windows.Forms.DataGridViewTextBoxColumn COMMENT2;
        private System.Windows.Forms.DataGridViewTextBoxColumn FILENM2;
        private System.Windows.Forms.DataGridViewTextBoxColumn PATH2;
        private System.Windows.Forms.DataGridViewTextBoxColumn INPUT_CD2;
        private Controls.conTextBox txt_staff_cd;
        private System.Windows.Forms.Button btn_file_srch;
        private System.Windows.Forms.Label label20;
        private Controls.conTextBox txt_file_path;
        private System.Windows.Forms.Button btn_Change_p;
        private Controls.conTextBox txt_root_path;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label15;
        private Controls.conTextBox txt_comment;
        private Controls.conTextBox txt_staff_nm;
        private System.Windows.Forms.DateTimePicker input_date;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lbl_user_gbn;
        private System.Windows.Forms.Label label8;
        private Controls.conTextBox txt_docs_srch;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker txt_upper_date;
        private System.Windows.Forms.DateTimePicker txt_lower_date;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_srch1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}