namespace MES.P85_BAS
{
    partial class frm사업자관리
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm사업자관리));
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_title = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label19 = new System.Windows.Forms.Label();
            this.txt_account2 = new MES.Controls.conTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_account = new MES.Controls.conTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btn우편번호 = new System.Windows.Forms.Button();
            this.txt_saup_no = new MES.Controls.conTextBox();
            this.txt_open_date = new MES.Controls.conDateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_homepage = new MES.Controls.conTextBox();
            this.txt_saup_nm = new MES.Controls.conTextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_notice = new MES.Controls.conTextBox();
            this.txt_owner_nm = new MES.Controls.conTextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_mg_phone = new MES.Controls.conTextBox();
            this.txt_uptae = new MES.Controls.conTextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_mg_email = new MES.Controls.conTextBox();
            this.txt_jongmok = new MES.Controls.conTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_fax = new MES.Controls.conTextBox();
            this.txt_post_no = new MES.Controls.conTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_comp_phone = new MES.Controls.conTextBox();
            this.txt_addr = new MES.Controls.conTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_corporate = new MES.Controls.conTextBox();
            this.txt_addr2 = new MES.Controls.conTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btn_직인_del = new System.Windows.Forms.Button();
            this.pic_직인 = new System.Windows.Forms.PictureBox();
            this.label21 = new System.Windows.Forms.Label();
            this.btn_직인_up = new System.Windows.Forms.Button();
            this.btn_del_banner = new System.Windows.Forms.Button();
            this.pic_banner = new System.Windows.Forms.PictureBox();
            this.label20 = new System.Windows.Forms.Label();
            this.btn_banner_up = new System.Windows.Forms.Button();
            this.btn_delLogo = new System.Windows.Forms.Button();
            this.pic_exam = new System.Windows.Forms.PictureBox();
            this.label18 = new System.Windows.Forms.Label();
            this.btn_file_up = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.txt_flagship = new MES.Controls.conTextBox();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_직인)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_banner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_exam)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.lbl_title);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.panel2.ForeColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1360, 33);
            this.panel2.TabIndex = 6;
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.Font = new System.Drawing.Font("SpoqaHanSans-Bold", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.lbl_title.Location = new System.Drawing.Point(9, -2); //new System.Drawing.Point(6, 5);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(107, 25);
            this.lbl_title.TabIndex = 94;
            this.lbl_title.Text = "사업자등록";
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
            this.btnClose.Location = new System.Drawing.Point(1284, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(73, 29);
            this.btnClose.TabIndex = 90;
            this.btnClose.Tag = "종료";
            this.btnClose.Text = "닫기";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
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
            this.btnSave.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.btnSave.Image = global::MES.Properties.Resources.newSaveBtn;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSave.Location = new System.Drawing.Point(1200, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(73, 29);
            this.btnSave.TabIndex = 80;
            this.btnSave.Tag = "저장";
            this.btnSave.Text = "저장";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ofd
            // 
            this.ofd.FileName = "openFileDialog1";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1360, 681);
            this.panel1.TabIndex = 8;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txt_flagship);
            this.splitContainer1.Panel1.Controls.Add(this.label22);
            this.splitContainer1.Panel1.Controls.Add(this.label19);
            this.splitContainer1.Panel1.Controls.Add(this.txt_account2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.txt_account);
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            this.splitContainer1.Panel1.Controls.Add(this.btn우편번호);
            this.splitContainer1.Panel1.Controls.Add(this.txt_saup_no);
            this.splitContainer1.Panel1.Controls.Add(this.txt_open_date);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.txt_homepage);
            this.splitContainer1.Panel1.Controls.Add(this.txt_saup_nm);
            this.splitContainer1.Panel1.Controls.Add(this.label17);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.txt_notice);
            this.splitContainer1.Panel1.Controls.Add(this.txt_owner_nm);
            this.splitContainer1.Panel1.Controls.Add(this.label16);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.txt_mg_phone);
            this.splitContainer1.Panel1.Controls.Add(this.txt_uptae);
            this.splitContainer1.Panel1.Controls.Add(this.label15);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.txt_mg_email);
            this.splitContainer1.Panel1.Controls.Add(this.txt_jongmok);
            this.splitContainer1.Panel1.Controls.Add(this.label14);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.txt_fax);
            this.splitContainer1.Panel1.Controls.Add(this.txt_post_no);
            this.splitContainer1.Panel1.Controls.Add(this.label13);
            this.splitContainer1.Panel1.Controls.Add(this.label8);
            this.splitContainer1.Panel1.Controls.Add(this.txt_comp_phone);
            this.splitContainer1.Panel1.Controls.Add(this.txt_addr);
            this.splitContainer1.Panel1.Controls.Add(this.label12);
            this.splitContainer1.Panel1.Controls.Add(this.label9);
            this.splitContainer1.Panel1.Controls.Add(this.txt_corporate);
            this.splitContainer1.Panel1.Controls.Add(this.txt_addr2);
            this.splitContainer1.Panel1.Controls.Add(this.label11);
            this.splitContainer1.Panel1.Controls.Add(this.label10);
            this.splitContainer1.Panel1.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btn_직인_del);
            this.splitContainer1.Panel2.Controls.Add(this.pic_직인);
            this.splitContainer1.Panel2.Controls.Add(this.label21);
            this.splitContainer1.Panel2.Controls.Add(this.btn_직인_up);
            this.splitContainer1.Panel2.Controls.Add(this.btn_del_banner);
            this.splitContainer1.Panel2.Controls.Add(this.pic_banner);
            this.splitContainer1.Panel2.Controls.Add(this.label20);
            this.splitContainer1.Panel2.Controls.Add(this.btn_banner_up);
            this.splitContainer1.Panel2.Controls.Add(this.btn_delLogo);
            this.splitContainer1.Panel2.Controls.Add(this.pic_exam);
            this.splitContainer1.Panel2.Controls.Add(this.label18);
            this.splitContainer1.Panel2.Controls.Add(this.btn_file_up);
            this.splitContainer1.Size = new System.Drawing.Size(1360, 681);
            this.splitContainer1.SplitterDistance = 737;
            this.splitContainer1.TabIndex = 425;
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.Color.AliceBlue;
            this.label19.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label19.Location = new System.Drawing.Point(3, 302);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(125, 24);
            this.label19.TabIndex = 428;
            this.label19.Text = "입금계좌2";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_account2
            // 
            this.txt_account2._AutoTab = true;
            this.txt_account2._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.txt_account2._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txt_account2._WaterMarkColor = System.Drawing.Color.Gray;
            this.txt_account2._WaterMarkText = "";
            this.txt_account2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_account2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_account2.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_account2.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.txt_account2.Location = new System.Drawing.Point(134, 303);
            this.txt_account2.MaxLength = 70;
            this.txt_account2.Name = "txt_account2";
            this.txt_account2.Size = new System.Drawing.Size(309, 24);
            this.txt_account2.TabIndex = 427;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.AliceBlue;
            this.label1.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(3, 265);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 24);
            this.label1.TabIndex = 426;
            this.label1.Text = "입금계좌";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_account
            // 
            this.txt_account._AutoTab = true;
            this.txt_account._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.txt_account._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txt_account._WaterMarkColor = System.Drawing.Color.Gray;
            this.txt_account._WaterMarkText = "";
            this.txt_account.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_account.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_account.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_account.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.txt_account.Location = new System.Drawing.Point(134, 266);
            this.txt_account.MaxLength = 70;
            this.txt_account.Name = "txt_account";
            this.txt_account.Size = new System.Drawing.Size(309, 24);
            this.txt_account.TabIndex = 425;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.AliceBlue;
            this.label7.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.Location = new System.Drawing.Point(3, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(125, 24);
            this.label7.TabIndex = 391;
            this.label7.Text = "사업자번호";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn우편번호
            // 
            this.btn우편번호.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn우편번호.Location = new System.Drawing.Point(287, 142);
            this.btn우편번호.Name = "btn우편번호";
            this.btn우편번호.Size = new System.Drawing.Size(50, 23);
            this.btn우편번호.TabIndex = 424;
            this.btn우편번호.Text = "검색";
            this.btn우편번호.UseVisualStyleBackColor = true;
            this.btn우편번호.Click += new System.EventHandler(this.btn우편번호_Click);
            // 
            // txt_saup_no
            // 
            this.txt_saup_no._AutoTab = true;
            this.txt_saup_no._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.txt_saup_no._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txt_saup_no._WaterMarkColor = System.Drawing.Color.Gray;
            this.txt_saup_no._WaterMarkText = "";
            this.txt_saup_no.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_saup_no.Enabled = false;
            this.txt_saup_no.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_saup_no.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.txt_saup_no.Location = new System.Drawing.Point(134, 12);
            this.txt_saup_no.MaxLength = 20;
            this.txt_saup_no.Name = "txt_saup_no";
            this.txt_saup_no.ReadOnly = true;
            this.txt_saup_no.Size = new System.Drawing.Size(147, 24);
            this.txt_saup_no.TabIndex = 1;
            // 
            // txt_open_date
            // 
            this.txt_open_date._BorderColor = System.Drawing.Color.White;
            this.txt_open_date._FocusedBackColor = System.Drawing.Color.White;
            this.txt_open_date.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_open_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txt_open_date.Location = new System.Drawing.Point(134, 343);
            this.txt_open_date.Name = "txt_open_date";
            this.txt_open_date.Size = new System.Drawing.Size(109, 24);
            this.txt_open_date.TabIndex = 45;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.AliceBlue;
            this.label2.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(3, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 24);
            this.label2.TabIndex = 393;
            this.label2.Text = "사업자명";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_homepage
            // 
            this.txt_homepage._AutoTab = true;
            this.txt_homepage._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.txt_homepage._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txt_homepage._WaterMarkColor = System.Drawing.Color.Gray;
            this.txt_homepage._WaterMarkText = "";
            this.txt_homepage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_homepage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_homepage.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_homepage.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.txt_homepage.Location = new System.Drawing.Point(134, 526);
            this.txt_homepage.MaxLength = 50;
            this.txt_homepage.Name = "txt_homepage";
            this.txt_homepage.Size = new System.Drawing.Size(309, 24);
            this.txt_homepage.TabIndex = 75;
            // 
            // txt_saup_nm
            // 
            this.txt_saup_nm._AutoTab = true;
            this.txt_saup_nm._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.txt_saup_nm._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txt_saup_nm._WaterMarkColor = System.Drawing.Color.Gray;
            this.txt_saup_nm._WaterMarkText = "";
            this.txt_saup_nm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_saup_nm.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_saup_nm.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.txt_saup_nm.Location = new System.Drawing.Point(134, 54);
            this.txt_saup_nm.MaxLength = 20;
            this.txt_saup_nm.Name = "txt_saup_nm";
            this.txt_saup_nm.Size = new System.Drawing.Size(147, 24);
            this.txt_saup_nm.TabIndex = 10;
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.AliceBlue;
            this.label17.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label17.Location = new System.Drawing.Point(3, 525);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(125, 24);
            this.label17.TabIndex = 421;
            this.label17.Text = "홈페이지";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.AliceBlue;
            this.label3.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(366, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 24);
            this.label3.TabIndex = 395;
            this.label3.Text = "대표자명";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_notice
            // 
            this.txt_notice._AutoTab = true;
            this.txt_notice._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.txt_notice._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txt_notice._WaterMarkColor = System.Drawing.Color.Gray;
            this.txt_notice._WaterMarkText = "";
            this.txt_notice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_notice.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_notice.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.txt_notice.Location = new System.Drawing.Point(134, 479);
            this.txt_notice.MaxLength = 20;
            this.txt_notice.Name = "txt_notice";
            this.txt_notice.Size = new System.Drawing.Size(510, 24);
            this.txt_notice.TabIndex = 70;
            // 
            // txt_owner_nm
            // 
            this.txt_owner_nm._AutoTab = true;
            this.txt_owner_nm._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.txt_owner_nm._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txt_owner_nm._WaterMarkColor = System.Drawing.Color.Gray;
            this.txt_owner_nm._WaterMarkText = "";
            this.txt_owner_nm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_owner_nm.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_owner_nm.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.txt_owner_nm.Location = new System.Drawing.Point(497, 55);
            this.txt_owner_nm.MaxLength = 20;
            this.txt_owner_nm.Name = "txt_owner_nm";
            this.txt_owner_nm.Size = new System.Drawing.Size(147, 24);
            this.txt_owner_nm.TabIndex = 15;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.AliceBlue;
            this.label16.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label16.Location = new System.Drawing.Point(3, 478);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(125, 24);
            this.label16.TabIndex = 419;
            this.label16.Text = "공지사항 (최신)";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.AliceBlue;
            this.label4.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(3, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 24);
            this.label4.TabIndex = 397;
            this.label4.Text = "업태";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_mg_phone
            // 
            this.txt_mg_phone._AutoTab = true;
            this.txt_mg_phone._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.txt_mg_phone._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txt_mg_phone._WaterMarkColor = System.Drawing.Color.Gray;
            this.txt_mg_phone._WaterMarkText = "";
            this.txt_mg_phone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_mg_phone.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_mg_phone.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.txt_mg_phone.Location = new System.Drawing.Point(497, 432);
            this.txt_mg_phone.MaxLength = 20;
            this.txt_mg_phone.Name = "txt_mg_phone";
            this.txt_mg_phone.Size = new System.Drawing.Size(147, 24);
            this.txt_mg_phone.TabIndex = 65;
            // 
            // txt_uptae
            // 
            this.txt_uptae._AutoTab = true;
            this.txt_uptae._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.txt_uptae._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txt_uptae._WaterMarkColor = System.Drawing.Color.Gray;
            this.txt_uptae._WaterMarkText = "";
            this.txt_uptae.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_uptae.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_uptae.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.txt_uptae.Location = new System.Drawing.Point(134, 96);
            this.txt_uptae.MaxLength = 20;
            this.txt_uptae.Name = "txt_uptae";
            this.txt_uptae.Size = new System.Drawing.Size(147, 24);
            this.txt_uptae.TabIndex = 20;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.AliceBlue;
            this.label15.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label15.Location = new System.Drawing.Point(366, 431);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(125, 24);
            this.label15.TabIndex = 417;
            this.label15.Text = "담당자 연락처";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.AliceBlue;
            this.label5.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(366, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 24);
            this.label5.TabIndex = 399;
            this.label5.Text = "종목";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_mg_email
            // 
            this.txt_mg_email._AutoTab = true;
            this.txt_mg_email._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.txt_mg_email._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txt_mg_email._WaterMarkColor = System.Drawing.Color.Gray;
            this.txt_mg_email._WaterMarkText = "";
            this.txt_mg_email.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_mg_email.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_mg_email.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.txt_mg_email.Location = new System.Drawing.Point(134, 432);
            this.txt_mg_email.MaxLength = 20;
            this.txt_mg_email.Name = "txt_mg_email";
            this.txt_mg_email.Size = new System.Drawing.Size(147, 24);
            this.txt_mg_email.TabIndex = 60;
            // 
            // txt_jongmok
            // 
            this.txt_jongmok._AutoTab = true;
            this.txt_jongmok._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.txt_jongmok._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txt_jongmok._WaterMarkColor = System.Drawing.Color.Gray;
            this.txt_jongmok._WaterMarkText = "";
            this.txt_jongmok.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_jongmok.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_jongmok.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.txt_jongmok.Location = new System.Drawing.Point(497, 97);
            this.txt_jongmok.MaxLength = 20;
            this.txt_jongmok.Name = "txt_jongmok";
            this.txt_jongmok.Size = new System.Drawing.Size(147, 24);
            this.txt_jongmok.TabIndex = 25;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.AliceBlue;
            this.label14.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label14.Location = new System.Drawing.Point(3, 431);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(125, 24);
            this.label14.TabIndex = 415;
            this.label14.Text = "담당자 이메일";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.AliceBlue;
            this.label6.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(3, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 24);
            this.label6.TabIndex = 401;
            this.label6.Text = "우편번호";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_fax
            // 
            this.txt_fax._AutoTab = true;
            this.txt_fax._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.txt_fax._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txt_fax._WaterMarkColor = System.Drawing.Color.Gray;
            this.txt_fax._WaterMarkText = "";
            this.txt_fax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_fax.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_fax.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.txt_fax.Location = new System.Drawing.Point(497, 386);
            this.txt_fax.MaxLength = 20;
            this.txt_fax.Name = "txt_fax";
            this.txt_fax.Size = new System.Drawing.Size(147, 24);
            this.txt_fax.TabIndex = 55;
            // 
            // txt_post_no
            // 
            this.txt_post_no._AutoTab = true;
            this.txt_post_no._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.txt_post_no._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txt_post_no._WaterMarkColor = System.Drawing.Color.Gray;
            this.txt_post_no._WaterMarkText = "";
            this.txt_post_no.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_post_no.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_post_no.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.txt_post_no.Location = new System.Drawing.Point(134, 141);
            this.txt_post_no.MaxLength = 20;
            this.txt_post_no.Name = "txt_post_no";
            this.txt_post_no.Size = new System.Drawing.Size(147, 24);
            this.txt_post_no.TabIndex = 30;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.AliceBlue;
            this.label13.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label13.Location = new System.Drawing.Point(366, 385);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(125, 24);
            this.label13.TabIndex = 413;
            this.label13.Text = "팩스번호";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.AliceBlue;
            this.label8.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label8.Location = new System.Drawing.Point(3, 183);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(125, 24);
            this.label8.TabIndex = 403;
            this.label8.Text = "기본주소";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_comp_phone
            // 
            this.txt_comp_phone._AutoTab = true;
            this.txt_comp_phone._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.txt_comp_phone._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txt_comp_phone._WaterMarkColor = System.Drawing.Color.Gray;
            this.txt_comp_phone._WaterMarkText = "";
            this.txt_comp_phone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_comp_phone.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_comp_phone.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.txt_comp_phone.Location = new System.Drawing.Point(134, 385);
            this.txt_comp_phone.MaxLength = 20;
            this.txt_comp_phone.Name = "txt_comp_phone";
            this.txt_comp_phone.Size = new System.Drawing.Size(147, 24);
            this.txt_comp_phone.TabIndex = 50;
            // 
            // txt_addr
            // 
            this.txt_addr._AutoTab = true;
            this.txt_addr._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.txt_addr._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txt_addr._WaterMarkColor = System.Drawing.Color.Gray;
            this.txt_addr._WaterMarkText = "";
            this.txt_addr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_addr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_addr.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_addr.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.txt_addr.Location = new System.Drawing.Point(134, 184);
            this.txt_addr.MaxLength = 20;
            this.txt_addr.Name = "txt_addr";
            this.txt_addr.Size = new System.Drawing.Size(309, 24);
            this.txt_addr.TabIndex = 35;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.AliceBlue;
            this.label12.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label12.Location = new System.Drawing.Point(3, 384);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(125, 24);
            this.label12.TabIndex = 411;
            this.label12.Text = "전화번호";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.AliceBlue;
            this.label9.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label9.Location = new System.Drawing.Point(3, 227);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(125, 24);
            this.label9.TabIndex = 405;
            this.label9.Text = "상세주소";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_corporate
            // 
            this.txt_corporate._AutoTab = true;
            this.txt_corporate._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.txt_corporate._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txt_corporate._WaterMarkColor = System.Drawing.Color.Gray;
            this.txt_corporate._WaterMarkText = "";
            this.txt_corporate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_corporate.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_corporate.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.txt_corporate.Location = new System.Drawing.Point(497, 12);
            this.txt_corporate.MaxLength = 20;
            this.txt_corporate.Name = "txt_corporate";
            this.txt_corporate.Size = new System.Drawing.Size(147, 24);
            this.txt_corporate.TabIndex = 5;
            // 
            // txt_addr2
            // 
            this.txt_addr2._AutoTab = true;
            this.txt_addr2._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.txt_addr2._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txt_addr2._WaterMarkColor = System.Drawing.Color.Gray;
            this.txt_addr2._WaterMarkText = "";
            this.txt_addr2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_addr2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_addr2.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_addr2.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.txt_addr2.Location = new System.Drawing.Point(134, 228);
            this.txt_addr2.MaxLength = 20;
            this.txt_addr2.Name = "txt_addr2";
            this.txt_addr2.Size = new System.Drawing.Size(309, 24);
            this.txt_addr2.TabIndex = 40;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.AliceBlue;
            this.label11.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label11.Location = new System.Drawing.Point(366, 11);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(125, 24);
            this.label11.TabIndex = 409;
            this.label11.Text = "법인번호";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.AliceBlue;
            this.label10.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label10.Location = new System.Drawing.Point(3, 340);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(125, 24);
            this.label10.TabIndex = 407;
            this.label10.Text = "개업년월일";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_직인_del
            // 
            this.btn_직인_del.BackColor = System.Drawing.Color.Transparent;
            this.btn_직인_del.Location = new System.Drawing.Point(118, 455);
            this.btn_직인_del.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_직인_del.Name = "btn_직인_del";
            this.btn_직인_del.Size = new System.Drawing.Size(46, 24);
            this.btn_직인_del.TabIndex = 373;
            this.btn_직인_del.Text = "삭제";
            this.btn_직인_del.UseVisualStyleBackColor = false;
            this.btn_직인_del.Click += new System.EventHandler(this.btn_직인_del_Click);
            // 
            // pic_직인
            // 
            this.pic_직인.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic_직인.Location = new System.Drawing.Point(14, 484);
            this.pic_직인.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pic_직인.Name = "pic_직인";
            this.pic_직인.Size = new System.Drawing.Size(55, 49);
            this.pic_직인.TabIndex = 372;
            this.pic_직인.TabStop = false;
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label21.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label21.Location = new System.Drawing.Point(14, 455);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(44, 24);
            this.label21.TabIndex = 371;
            this.label21.Text = "직인";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_직인_up
            // 
            this.btn_직인_up.BackColor = System.Drawing.Color.Transparent;
            this.btn_직인_up.Location = new System.Drawing.Point(64, 455);
            this.btn_직인_up.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_직인_up.Name = "btn_직인_up";
            this.btn_직인_up.Size = new System.Drawing.Size(48, 24);
            this.btn_직인_up.TabIndex = 370;
            this.btn_직인_up.Text = "첨부";
            this.btn_직인_up.UseVisualStyleBackColor = false;
            this.btn_직인_up.Click += new System.EventHandler(this.btn_직인_up_Click);
            // 
            // btn_del_banner
            // 
            this.btn_del_banner.BackColor = System.Drawing.Color.Transparent;
            this.btn_del_banner.Location = new System.Drawing.Point(210, 222);
            this.btn_del_banner.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_del_banner.Name = "btn_del_banner";
            this.btn_del_banner.Size = new System.Drawing.Size(46, 24);
            this.btn_del_banner.TabIndex = 369;
            this.btn_del_banner.Text = "삭제";
            this.btn_del_banner.UseVisualStyleBackColor = false;
            this.btn_del_banner.Click += new System.EventHandler(this.btn_del_banner_Click);
            // 
            // pic_banner
            // 
            this.pic_banner.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic_banner.Location = new System.Drawing.Point(14, 252);
            this.pic_banner.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pic_banner.Name = "pic_banner";
            this.pic_banner.Size = new System.Drawing.Size(429, 141);
            this.pic_banner.TabIndex = 368;
            this.pic_banner.TabStop = false;
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label20.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label20.Location = new System.Drawing.Point(14, 223);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(134, 24);
            this.label20.TabIndex = 367;
            this.label20.Text = "워터마크 && 배너";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_banner_up
            // 
            this.btn_banner_up.BackColor = System.Drawing.Color.Transparent;
            this.btn_banner_up.Location = new System.Drawing.Point(156, 222);
            this.btn_banner_up.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_banner_up.Name = "btn_banner_up";
            this.btn_banner_up.Size = new System.Drawing.Size(48, 24);
            this.btn_banner_up.TabIndex = 366;
            this.btn_banner_up.Text = "첨부";
            this.btn_banner_up.UseVisualStyleBackColor = false;
            this.btn_banner_up.Click += new System.EventHandler(this.btn_banner_up_Click);
            // 
            // btn_delLogo
            // 
            this.btn_delLogo.BackColor = System.Drawing.Color.Transparent;
            this.btn_delLogo.Location = new System.Drawing.Point(154, 10);
            this.btn_delLogo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_delLogo.Name = "btn_delLogo";
            this.btn_delLogo.Size = new System.Drawing.Size(46, 24);
            this.btn_delLogo.TabIndex = 365;
            this.btn_delLogo.Text = "삭제";
            this.btn_delLogo.UseVisualStyleBackColor = false;
            this.btn_delLogo.Click += new System.EventHandler(this.btn_delLogo_Click);
            // 
            // pic_exam
            // 
            this.pic_exam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic_exam.Location = new System.Drawing.Point(14, 39);
            this.pic_exam.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pic_exam.Name = "pic_exam";
            this.pic_exam.Size = new System.Drawing.Size(206, 141);
            this.pic_exam.TabIndex = 364;
            this.pic_exam.TabStop = false;
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label18.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label18.Location = new System.Drawing.Point(14, 10);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(80, 24);
            this.label18.TabIndex = 363;
            this.label18.Text = "업체로고";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_file_up
            // 
            this.btn_file_up.BackColor = System.Drawing.Color.Transparent;
            this.btn_file_up.Location = new System.Drawing.Point(100, 10);
            this.btn_file_up.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_file_up.Name = "btn_file_up";
            this.btn_file_up.Size = new System.Drawing.Size(48, 24);
            this.btn_file_up.TabIndex = 85;
            this.btn_file_up.Text = "첨부";
            this.btn_file_up.UseVisualStyleBackColor = false;
            this.btn_file_up.Click += new System.EventHandler(this.btn_file_up_Click);
            // 
            // label22
            // 
            this.label22.BackColor = System.Drawing.Color.AliceBlue;
            this.label22.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label22.Location = new System.Drawing.Point(366, 142);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(125, 24);
            this.label22.TabIndex = 429;
            this.label22.Text = "대표품목(계산서)";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_flagship
            // 
            this.txt_flagship._AutoTab = true;
            this.txt_flagship._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.txt_flagship._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txt_flagship._WaterMarkColor = System.Drawing.Color.Gray;
            this.txt_flagship._WaterMarkText = "";
            this.txt_flagship.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_flagship.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_flagship.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.txt_flagship.Location = new System.Drawing.Point(497, 142);
            this.txt_flagship.MaxLength = 20;
            this.txt_flagship.Name = "txt_flagship";
            this.txt_flagship.Size = new System.Drawing.Size(147, 24);
            this.txt_flagship.TabIndex = 430;
            // 
            // frm사업자관리
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1360, 714);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "frm사업자관리";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frm사업자관리";
            this.Load += new System.EventHandler(this.frm사업자관리_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic_직인)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_banner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_exam)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pic_exam;
        private System.Windows.Forms.Button btn_file_up;
        private System.Windows.Forms.Label label18;
        private Controls.conTextBox txt_homepage;
        private System.Windows.Forms.Label label17;
        private Controls.conTextBox txt_notice;
        private System.Windows.Forms.Label label16;
        private Controls.conTextBox txt_mg_phone;
        private System.Windows.Forms.Label label15;
        private Controls.conTextBox txt_mg_email;
        private System.Windows.Forms.Label label14;
        private Controls.conTextBox txt_fax;
        private System.Windows.Forms.Label label13;
        private Controls.conTextBox txt_comp_phone;
        private System.Windows.Forms.Label label12;
        private Controls.conTextBox txt_corporate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private Controls.conTextBox txt_addr2;
        private System.Windows.Forms.Label label9;
        private Controls.conTextBox txt_addr;
        private System.Windows.Forms.Label label8;
        private Controls.conTextBox txt_post_no;
        private System.Windows.Forms.Label label6;
        private Controls.conTextBox txt_jongmok;
        private System.Windows.Forms.Label label5;
        private Controls.conTextBox txt_uptae;
        private System.Windows.Forms.Label label4;
        private Controls.conTextBox txt_owner_nm;
        private System.Windows.Forms.Label label3;
        private Controls.conTextBox txt_saup_nm;
        private System.Windows.Forms.Label label2;
        private Controls.conTextBox txt_saup_no;
        private System.Windows.Forms.Label label7;
        private Controls.conDateTimePicker txt_open_date;
        private System.Windows.Forms.Button btn우편번호;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label19;
        private Controls.conTextBox txt_account2;
        private System.Windows.Forms.Label label1;
        private Controls.conTextBox txt_account;
        private System.Windows.Forms.Button btn_delLogo;
        private System.Windows.Forms.Button btn_직인_del;
        private System.Windows.Forms.PictureBox pic_직인;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button btn_직인_up;
        private System.Windows.Forms.Button btn_del_banner;
        private System.Windows.Forms.PictureBox pic_banner;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button btn_banner_up;
        private Controls.conTextBox txt_flagship;
        private System.Windows.Forms.Label label22;
    }
}