namespace MES.P90_SYS
{
    partial class frm공지사항
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm공지사항));
            this.noticeGrid = new MES.Controls.myDataGridView();
            this.SEQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CONTENT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INSTAFF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TITLE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INTIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl = new MES.Controls.conTextBox();
            this.lbl_title = new System.Windows.Forms.Label();
            this.textBox1 = new MES.Controls.conTextBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.lbl_flow_cd = new System.Windows.Forms.Label();
            this.pnl_입력 = new System.Windows.Forms.Panel();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new MES.Controls.conTextBox();
            this.chk일정추가 = new MES.Controls.conCheckBox();
            this.dTP1 = new System.Windows.Forms.DateTimePicker();
            this.txt달력 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.lbl간략 = new System.Windows.Forms.Label();
            this.lbl일자 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pnl_검색 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtSrch = new System.Windows.Forms.TextBox();
            this.btnCustSrch2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.noticeGrid)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.pnl_입력.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.pnl_검색.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // noticeGrid
            // 
            this.noticeGrid.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.noticeGrid.AllowUserToAddRows = false;
            this.noticeGrid.AllowUserToDeleteRows = false;
            this.noticeGrid.AllowUserToResizeColumns = false;
            this.noticeGrid.AllowUserToResizeRows = false;
            this.noticeGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.noticeGrid.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.noticeGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.noticeGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.noticeGrid.ColumnHeadersHeight = 40;
            this.noticeGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.noticeGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SEQ,
            this.CONTENT,
            this.INSTAFF,
            this.TITLE,
            this.INTIME});
            this.noticeGrid.EnableHeadersVisualStyles = false;
            this.noticeGrid.GridColor = System.Drawing.Color.PowderBlue;
            this.noticeGrid.Location = new System.Drawing.Point(8, 45);
            this.noticeGrid.Name = "noticeGrid";
            this.noticeGrid.ReadOnly = true;
            this.noticeGrid.RowHeadersVisible = false;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.noticeGrid.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.noticeGrid.RowTemplate.Height = 23;
            this.noticeGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.noticeGrid.Size = new System.Drawing.Size(595, 676);
            this.noticeGrid.TabIndex = 333;
            this.noticeGrid.TabStop = false;
            this.noticeGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.noticeGrid_CellDoubleClick);
            // 
            // SEQ
            // 
            this.SEQ.HeaderText = "No";
            this.SEQ.Name = "SEQ";
            this.SEQ.ReadOnly = true;
            this.SEQ.Width = 40;
            // 
            // CONTENT
            // 
            this.CONTENT.HeaderText = "CONTENT";
            this.CONTENT.Name = "CONTENT";
            this.CONTENT.ReadOnly = true;
            this.CONTENT.Visible = false;
            // 
            // INSTAFF
            // 
            this.INSTAFF.HeaderText = "INSTAFF";
            this.INSTAFF.Name = "INSTAFF";
            this.INSTAFF.ReadOnly = true;
            this.INSTAFF.Visible = false;
            // 
            // TITLE
            // 
            this.TITLE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TITLE.HeaderText = "제목";
            this.TITLE.Name = "TITLE";
            this.TITLE.ReadOnly = true;
            // 
            // INTIME
            // 
            this.INTIME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.INTIME.DefaultCellStyle = dataGridViewCellStyle2;
            this.INTIME.HeaderText = "작성일";
            this.INTIME.Name = "INTIME";
            this.INTIME.ReadOnly = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.lbl);
            this.panel2.Controls.Add(this.lbl_title);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.btnNew);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.btnDelete);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.lbl_flow_cd);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1360, 33);
            this.panel2.TabIndex = 334;
            // 
            // lbl
            // 
            this.lbl._AutoTab = true;
            this.lbl._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.lbl._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lbl._WaterMarkColor = System.Drawing.Color.Gray;
            this.lbl._WaterMarkText = "";
            this.lbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.lbl.Location = new System.Drawing.Point(663, 5);
            this.lbl.MaxLength = 6;
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(166, 22);
            this.lbl.TabIndex = 383;
            this.lbl.Visible = false;
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.Font = new System.Drawing.Font("SpoqaHanSans-Bold", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.lbl_title.Location = new System.Drawing.Point(9, -2); //new System.Drawing.Point(10, 0);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(146, 30);
            this.lbl_title.TabIndex = 93;
            this.lbl_title.Text = "공지사항 관리";
            // 
            // textBox1
            // 
            this.textBox1._AutoTab = true;
            this.textBox1._BorderColor = System.Drawing.Color.White;
            this.textBox1._FocusedBackColor = System.Drawing.Color.White;
            this.textBox1._WaterMarkColor = System.Drawing.Color.Gray;
            this.textBox1._WaterMarkText = "";
            this.textBox1.Location = new System.Drawing.Point(345, 11);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(60, 21);
            this.textBox1.TabIndex = 352;
            this.textBox1.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.Transparent;
            this.btnNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNew.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnNew.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnNew.FlatAppearance.BorderSize = 0;
            this.btnNew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnNew.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.btnNew.Image = global::MES.Properties.Resources.newnewBtn;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNew.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnNew.Location = new System.Drawing.Point(1023, 0);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(74, 33);
            this.btnNew.TabIndex = 20;
            this.btnNew.TabStop = false;
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
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.btnSave.Image = global::MES.Properties.Resources.newSaveBtn;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSave.Location = new System.Drawing.Point(1097, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(74, 33);
            this.btnSave.TabIndex = 0;
            this.btnSave.TabStop = false;
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
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDelete.Enabled = false;
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.btnDelete.Image = global::MES.Properties.Resources.newDelBtn;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDelete.Location = new System.Drawing.Point(1171, 0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(74, 33);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.TabStop = false;
            this.btnDelete.Tag = "삭제";
            this.btnDelete.Text = "삭제";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnClose);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(1245, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(115, 33);
            this.panel3.TabIndex = 384;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.btnClose.Image = global::MES.Properties.Resources.newnewCloseBtn;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(41, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(74, 33);
            this.btnClose.TabIndex = 10;
            this.btnClose.TabStop = false;
            this.btnClose.Tag = "종료";
            this.btnClose.Text = "닫기";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lbl_flow_cd
            // 
            this.lbl_flow_cd.BackColor = System.Drawing.SystemColors.HotTrack;
            this.lbl_flow_cd.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_flow_cd.ForeColor = System.Drawing.Color.White;
            this.lbl_flow_cd.Location = new System.Drawing.Point(239, 11);
            this.lbl_flow_cd.Name = "lbl_flow_cd";
            this.lbl_flow_cd.Size = new System.Drawing.Size(100, 22);
            this.lbl_flow_cd.TabIndex = 340;
            this.lbl_flow_cd.Text = "번호";
            this.lbl_flow_cd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_flow_cd.Visible = false;
            // 
            // pnl_입력
            // 
            this.pnl_입력.BackColor = System.Drawing.Color.White;
            this.pnl_입력.Controls.Add(this.textBox3);
            this.pnl_입력.Controls.Add(this.textBox2);
            this.pnl_입력.Controls.Add(this.chk일정추가);
            this.pnl_입력.Controls.Add(this.dTP1);
            this.pnl_입력.Controls.Add(this.txt달력);
            this.pnl_입력.Controls.Add(this.textBox4);
            this.pnl_입력.Controls.Add(this.lbl간략);
            this.pnl_입력.Controls.Add(this.lbl일자);
            this.pnl_입력.Controls.Add(this.label3);
            this.pnl_입력.Controls.Add(this.label2);
            this.pnl_입력.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_입력.Location = new System.Drawing.Point(0, 0);
            this.pnl_입력.Name = "pnl_입력";
            this.pnl_입력.Size = new System.Drawing.Size(741, 724);
            this.pnl_입력.TabIndex = 341;
            // 
            // textBox3
            // 
            this.textBox3.AcceptsReturn = true;
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.Location = new System.Drawing.Point(117, 43);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(612, 442);
            this.textBox3.TabIndex = 355;
            // 
            // textBox2
            // 
            this.textBox2._AutoTab = true;
            this.textBox2._BorderColor = System.Drawing.Color.White;
            this.textBox2._FocusedBackColor = System.Drawing.Color.White;
            this.textBox2._WaterMarkColor = System.Drawing.Color.Gray;
            this.textBox2._WaterMarkText = "";
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(117, 11);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(612, 21);
            this.textBox2.TabIndex = 353;
            // 
            // chk일정추가
            // 
            this.chk일정추가.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chk일정추가.AutoSize = true;
            this.chk일정추가.Location = new System.Drawing.Point(117, 491);
            this.chk일정추가.Name = "chk일정추가";
            this.chk일정추가.Size = new System.Drawing.Size(108, 16);
            this.chk일정추가.TabIndex = 351;
            this.chk일정추가.Text = "일정에추가하기";
            this.chk일정추가.UseVisualStyleBackColor = true;
            this.chk일정추가.Visible = false;
            this.chk일정추가.CheckedChanged += new System.EventHandler(this.chk일정추가_CheckedChanged);
            // 
            // dTP1
            // 
            this.dTP1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dTP1.Location = new System.Drawing.Point(163, 527);
            this.dTP1.Name = "dTP1";
            this.dTP1.Size = new System.Drawing.Size(37, 21);
            this.dTP1.TabIndex = 350;
            this.dTP1.Visible = false;
            // 
            // txt달력
            // 
            this.txt달력.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt달력.Location = new System.Drawing.Point(195, 561);
            this.txt달력.Name = "txt달력";
            this.txt달력.Size = new System.Drawing.Size(178, 21);
            this.txt달력.TabIndex = 349;
            this.txt달력.Visible = false;
            // 
            // textBox4
            // 
            this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox4.Location = new System.Drawing.Point(339, 561);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(0, 21);
            this.textBox4.TabIndex = 348;
            this.textBox4.Visible = false;
            // 
            // lbl간략
            // 
            this.lbl간략.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.lbl간략.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl간략.ForeColor = System.Drawing.Color.White;
            this.lbl간략.Location = new System.Drawing.Point(57, 561);
            this.lbl간략.Name = "lbl간략";
            this.lbl간략.Size = new System.Drawing.Size(132, 22);
            this.lbl간략.TabIndex = 344;
            this.lbl간략.Text = "달력에 표시할 제목";
            this.lbl간략.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl간략.Visible = false;
            // 
            // lbl일자
            // 
            this.lbl일자.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.lbl일자.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl일자.ForeColor = System.Drawing.Color.White;
            this.lbl일자.Location = new System.Drawing.Point(57, 526);
            this.lbl일자.Name = "lbl일자";
            this.lbl일자.Size = new System.Drawing.Size(100, 22);
            this.lbl일자.TabIndex = 343;
            this.lbl일자.Text = "일자";
            this.lbl일자.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl일자.Visible = false;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.label3.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(11, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 22);
            this.label3.TabIndex = 342;
            this.label3.Text = "내용";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.label2.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(11, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 22);
            this.label2.TabIndex = 341;
            this.label2.Text = "제목";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 33);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pnl_입력);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pnl_검색);
            this.splitContainer1.Size = new System.Drawing.Size(1360, 724);
            this.splitContainer1.SplitterDistance = 741;
            this.splitContainer1.TabIndex = 355;
            this.splitContainer1.TabStop = false;
            // 
            // pnl_검색
            // 
            this.pnl_검색.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnl_검색.Controls.Add(this.panel1);
            this.pnl_검색.Controls.Add(this.noticeGrid);
            this.pnl_검색.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_검색.Location = new System.Drawing.Point(0, 0);
            this.pnl_검색.Name = "pnl_검색";
            this.pnl_검색.Size = new System.Drawing.Size(615, 724);
            this.pnl_검색.TabIndex = 342;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtSrch);
            this.panel1.Controls.Add(this.btnCustSrch2);
            this.panel1.Location = new System.Drawing.Point(31, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(327, 34);
            this.panel1.TabIndex = 394;
            // 
            // txtSrch
            // 
            this.txtSrch.Location = new System.Drawing.Point(3, 10);
            this.txtSrch.Name = "txtSrch";
            this.txtSrch.Size = new System.Drawing.Size(239, 21);
            this.txtSrch.TabIndex = 50;
            this.txtSrch.TabStop = false;
            this.txtSrch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSrch_KeyDown);
            // 
            // btnCustSrch2
            // 
            this.btnCustSrch2.BackColor = System.Drawing.Color.Transparent;
            this.btnCustSrch2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCustSrch2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCustSrch2.FlatAppearance.BorderSize = 0;
            this.btnCustSrch2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btnCustSrch2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustSrch2.Image = ((System.Drawing.Image)(resources.GetObject("btnCustSrch2.Image")));
            this.btnCustSrch2.Location = new System.Drawing.Point(250, 0);
            this.btnCustSrch2.Name = "btnCustSrch2";
            this.btnCustSrch2.Size = new System.Drawing.Size(33, 33);
            this.btnCustSrch2.TabIndex = 393;
            this.btnCustSrch2.TabStop = false;
            this.btnCustSrch2.Tag = "검색";
            this.btnCustSrch2.UseVisualStyleBackColor = false;
            this.btnCustSrch2.Click += new System.EventHandler(this.btnCustSrch2_Click);
            // 
            // frm공지사항
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1360, 757);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel2);
            this.Name = "frm공지사항";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frm공지사항";
            this.Load += new System.EventHandler(this.frm공지사항_Load);
            ((System.ComponentModel.ISupportInitialize)(this.noticeGrid)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.pnl_입력.ResumeLayout(false);
            this.pnl_입력.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.pnl_검색.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView noticeGrid;
        private System.Windows.Forms.Panel panel2;
        private Controls.conTextBox lbl;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lbl_flow_cd;
        private System.Windows.Forms.Panel pnl_입력;
        private System.Windows.Forms.Panel pnl_검색;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSrch;
        private System.Windows.Forms.Button btnCustSrch2;
        private Controls.conCheckBox chk일정추가;
        private System.Windows.Forms.DateTimePicker dTP1;
        private System.Windows.Forms.TextBox txt달력;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label lbl간략;
        private System.Windows.Forms.Label lbl일자;
        private Controls.conTextBox textBox2;
        private Controls.conTextBox textBox1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SEQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn CONTENT;
        private System.Windows.Forms.DataGridViewTextBoxColumn INSTAFF;
        private System.Windows.Forms.DataGridViewTextBoxColumn TITLE;
        private System.Windows.Forms.DataGridViewTextBoxColumn INTIME;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox textBox3;
    }
}