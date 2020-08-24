namespace MES.H30_납품관리
{
    partial class frm매출관리
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm매출관리));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_out_gbn = new MES.Controls.conTextBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.lbl_title = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.split_그리드 = new System.Windows.Forms.SplitContainer();
            this.dgv제품 = new MES.Controls.conDataGridView();
            this.dataGridViewTextBoxColumn40 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.O_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.O_ITEM_CD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.제품명 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.규격 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.O_UNIT_NM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.O_UNIT_CD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.수량 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.단가 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.금액 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.최종매출일 = new CalendarColumn();
            this.매출구분 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.비고 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.O_주문일자 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.O_주문번호 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.O_부가세 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.O_과세 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.pnl_itemPlanGrid = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_plus = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_minus = new System.Windows.Forms.Button();
            this.dgv주문내역 = new MES.Controls.conDataGridView();
            this.LOT_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.거래처코드 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LOT_SUB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ODR_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ODR_CD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.거래처 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ITEM_NM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.O전표상태 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.O_전표상태코드 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.배송일자 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.배송코드 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.O_배송사원 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.배송사원코드 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STOCK_AMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CHK = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.O_창고코드 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.O_창고 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.부가세 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.부가세코드 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnl_itemHalfGrid = new System.Windows.Forms.Panel();
            this.lbl제품제고 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbo전표상태 = new MES.Controls.conComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt시간 = new MES.Controls.conTextBox();
            this.pnl계산서발행 = new System.Windows.Forms.Panel();
            this.rdo계산서미발행 = new System.Windows.Forms.RadioButton();
            this.rdo계산서발행 = new System.Windows.Forms.RadioButton();
            this.dtp발행일자 = new MES.Controls.conDateTimePicker();
            this.txt입력방식 = new MES.Controls.conTextBox();
            this.cbo부가세 = new MES.Controls.conComboBox();
            this.cbo창고 = new MES.Controls.conComboBox();
            this.cbo담당사원 = new MES.Controls.conComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.lbl발행일자 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_매출일자 = new MES.Controls.conDateTimePicker();
            this.txt_comment = new MES.Controls.conTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_cust_nm = new MES.Controls.conTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt매출번호 = new MES.Controls.conTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_flow_cd = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tab2 = new System.Windows.Forms.TabPage();
            this.dgv매출 = new MES.Controls.conDataGridView();
            this.M_매출일자 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.M_매출번호 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.M_주문일자 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.M_거래처 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.M_거래처코드 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.M_담당사원코드 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.M_계산서발행여부 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.M_발행일자 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.M_부가세코드 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.M_비고 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnSrch = new System.Windows.Forms.Button();
            this.end_date = new System.Windows.Forms.DateTimePicker();
            this.start_date = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.split_그리드)).BeginInit();
            this.split_그리드.Panel1.SuspendLayout();
            this.split_그리드.Panel2.SuspendLayout();
            this.split_그리드.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv제품)).BeginInit();
            this.pnl_itemPlanGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv주문내역)).BeginInit();
            this.pnl_itemHalfGrid.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pnl계산서발행.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tab2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv매출)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.PaleTurquoise;
            this.panel2.Controls.Add(this.lbl_out_gbn);
            this.panel2.Controls.Add(this.btnNew);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.btnDelete);
            this.panel2.Controls.Add(this.btn_close);
            this.panel2.Controls.Add(this.lbl_title);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1360, 33);
            this.panel2.TabIndex = 20;
            // 
            // lbl_out_gbn
            // 
            this.lbl_out_gbn._AutoTab = true;
            this.lbl_out_gbn._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.lbl_out_gbn._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lbl_out_gbn._WaterMarkColor = System.Drawing.Color.Gray;
            this.lbl_out_gbn._WaterMarkText = "";
            this.lbl_out_gbn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lbl_out_gbn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_out_gbn.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_out_gbn.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.lbl_out_gbn.Location = new System.Drawing.Point(597, 5);
            this.lbl_out_gbn.MaxLength = 6;
            this.lbl_out_gbn.Name = "lbl_out_gbn";
            this.lbl_out_gbn.Size = new System.Drawing.Size(166, 22);
            this.lbl_out_gbn.TabIndex = 393;
            this.lbl_out_gbn.Visible = false;
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
            this.btnNew.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F);
            this.btnNew.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.btnNew.Image = global::MES.Properties.Resources.newnewBtn;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNew.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnNew.Location = new System.Drawing.Point(1075, 2);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(65, 29);
            this.btnNew.TabIndex = 392;
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
            this.btnSave.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F);
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.btnSave.Image = global::MES.Properties.Resources.newSaveBtn;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSave.Location = new System.Drawing.Point(1146, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(65, 29);
            this.btnSave.TabIndex = 390;
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
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F);
            this.btnDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.btnDelete.Image = global::MES.Properties.Resources.newDelBtn;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDelete.Location = new System.Drawing.Point(1217, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(65, 29);
            this.btnDelete.TabIndex = 391;
            this.btnDelete.Tag = "삭제";
            this.btnDelete.Text = "삭제";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btn_close
            // 
            this.btn_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_close.BackColor = System.Drawing.Color.Transparent;
            this.btn_close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_close.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_close.FlatAppearance.BorderSize = 0;
            this.btn_close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_close.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F);
            this.btn_close.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.btn_close.Image = ((System.Drawing.Image)(resources.GetObject("btn_close.Image")));
            this.btn_close.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_close.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_close.Location = new System.Drawing.Point(1288, 1);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(65, 29);
            this.btn_close.TabIndex = 389;
            this.btn_close.Tag = "종료";
            this.btn_close.Text = "닫기";
            this.btn_close.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_close.UseVisualStyleBackColor = false;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.lbl_title.Location = new System.Drawing.Point(9, -2); //new System.Drawing.Point(10, 5);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(101, 30);
            this.lbl_title.TabIndex = 93;
            this.lbl_title.Text = "매출관리";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 33);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1360, 681);
            this.panel1.TabIndex = 21;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.Coral;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel1.Controls.Add(this.split_그리드);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1360, 681);
            this.splitContainer1.SplitterDistance = 1025;
            this.splitContainer1.TabIndex = 391;
            // 
            // split_그리드
            // 
            this.split_그리드.BackColor = System.Drawing.Color.Coral;
            this.split_그리드.Dock = System.Windows.Forms.DockStyle.Fill;
            this.split_그리드.Location = new System.Drawing.Point(0, 134);
            this.split_그리드.Name = "split_그리드";
            this.split_그리드.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // split_그리드.Panel1
            // 
            this.split_그리드.Panel1.BackColor = System.Drawing.Color.White;
            this.split_그리드.Panel1.Controls.Add(this.dgv제품);
            this.split_그리드.Panel1.Controls.Add(this.pnl_itemPlanGrid);
            // 
            // split_그리드.Panel2
            // 
            this.split_그리드.Panel2.BackColor = System.Drawing.Color.White;
            this.split_그리드.Panel2.Controls.Add(this.dgv주문내역);
            this.split_그리드.Panel2.Controls.Add(this.pnl_itemHalfGrid);
            this.split_그리드.Size = new System.Drawing.Size(1025, 547);
            this.split_그리드.SplitterDistance = 273;
            this.split_그리드.TabIndex = 391;
            // 
            // dgv제품
            // 
            this.dgv제품._BorderColor = System.Drawing.Color.Silver;
            this.dgv제품._DirKey = "R";
            this.dgv제품._KeyboardCmd = "1";
            this.dgv제품._KeyInput = "";
            this.dgv제품._LastCol = -1;
            this.dgv제품._LastRow = -1;
            this.dgv제품.AllowUserToAddRows = false;
            this.dgv제품.AllowUserToDeleteRows = false;
            this.dgv제품.AllowUserToOrderColumns = true;
            this.dgv제품.AllowUserToResizeRows = false;
            this.dgv제품.BackgroundColor = System.Drawing.Color.White;
            this.dgv제품.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv제품.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv제품.ColumnHeadersHeight = 35;
            this.dgv제품.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv제품.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn40,
            this.O_NO,
            this.Column4,
            this.Column5,
            this.Column6,
            this.O_ITEM_CD,
            this.제품명,
            this.규격,
            this.O_UNIT_NM,
            this.O_UNIT_CD,
            this.수량,
            this.단가,
            this.금액,
            this.최종매출일,
            this.매출구분,
            this.비고,
            this.O_주문일자,
            this.O_주문번호,
            this.O_부가세,
            this.O_과세});
            this.dgv제품.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv제품.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgv제품.EnableHeadersVisualStyles = false;
            this.dgv제품.GridColor = System.Drawing.Color.PowderBlue;
            this.dgv제품.Location = new System.Drawing.Point(0, 30);
            this.dgv제품.Name = "dgv제품";
            this.dgv제품.RowHeadersVisible = false;
            this.dgv제품.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightYellow;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.dgv제품.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv제품.RowTemplate.Height = 23;
            this.dgv제품.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv제품.Size = new System.Drawing.Size(1025, 243);
            this.dgv제품.TabIndex = 381;
            // 
            // dataGridViewTextBoxColumn40
            // 
            this.dataGridViewTextBoxColumn40.HeaderText = "[ ]";
            this.dataGridViewTextBoxColumn40.Name = "dataGridViewTextBoxColumn40";
            this.dataGridViewTextBoxColumn40.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn40.Visible = false;
            this.dataGridViewTextBoxColumn40.Width = 30;
            // 
            // O_NO
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.O_NO.DefaultCellStyle = dataGridViewCellStyle2;
            this.O_NO.HeaderText = "No.";
            this.O_NO.Name = "O_NO";
            this.O_NO.ReadOnly = true;
            this.O_NO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.O_NO.Width = 45;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "매출일자";
            this.Column4.Name = "Column4";
            this.Column4.Visible = false;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "매출번호";
            this.Column5.Name = "Column5";
            this.Column5.Visible = false;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "항목순번";
            this.Column6.Name = "Column6";
            this.Column6.Visible = false;
            // 
            // O_ITEM_CD
            // 
            this.O_ITEM_CD.HeaderText = "제품코드";
            this.O_ITEM_CD.Name = "O_ITEM_CD";
            // 
            // 제품명
            // 
            this.제품명.HeaderText = "제품명";
            this.제품명.Name = "제품명";
            this.제품명.Width = 150;
            // 
            // 규격
            // 
            this.규격.HeaderText = "규격";
            this.규격.Name = "규격";
            // 
            // O_UNIT_NM
            // 
            this.O_UNIT_NM.HeaderText = "단위";
            this.O_UNIT_NM.Name = "O_UNIT_NM";
            // 
            // O_UNIT_CD
            // 
            this.O_UNIT_CD.HeaderText = "단위코드";
            this.O_UNIT_CD.Name = "O_UNIT_CD";
            this.O_UNIT_CD.Visible = false;
            // 
            // 수량
            // 
            this.수량.HeaderText = "수량";
            this.수량.Name = "수량";
            this.수량.Width = 80;
            // 
            // 단가
            // 
            this.단가.HeaderText = "단가";
            this.단가.Name = "단가";
            this.단가.Width = 80;
            // 
            // 금액
            // 
            this.금액.HeaderText = "금액";
            this.금액.Name = "금액";
            // 
            // 최종매출일
            // 
            this.최종매출일.HeaderText = "최종매출일";
            this.최종매출일.Name = "최종매출일";
            this.최종매출일.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.최종매출일.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // 매출구분
            // 
            this.매출구분.HeaderText = "매출구분";
            this.매출구분.Name = "매출구분";
            this.매출구분.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.매출구분.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // 비고
            // 
            this.비고.HeaderText = "비고";
            this.비고.Name = "비고";
            // 
            // O_주문일자
            // 
            this.O_주문일자.HeaderText = "주문일자";
            this.O_주문일자.Name = "O_주문일자";
            // 
            // O_주문번호
            // 
            this.O_주문번호.HeaderText = "주문번호";
            this.O_주문번호.Name = "O_주문번호";
            // 
            // O_부가세
            // 
            this.O_부가세.HeaderText = "부가세구분";
            this.O_부가세.Items.AddRange(new object[] {
            "포함",
            "미포함"});
            this.O_부가세.Name = "O_부가세";
            this.O_부가세.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.O_부가세.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // O_과세
            // 
            this.O_과세.HeaderText = "과세구분";
            this.O_과세.Items.AddRange(new object[] {
            "과세",
            "면세"});
            this.O_과세.Name = "O_과세";
            this.O_과세.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.O_과세.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // pnl_itemPlanGrid
            // 
            this.pnl_itemPlanGrid.Controls.Add(this.label8);
            this.pnl_itemPlanGrid.Controls.Add(this.btn_plus);
            this.pnl_itemPlanGrid.Controls.Add(this.button1);
            this.pnl_itemPlanGrid.Controls.Add(this.btn_minus);
            this.pnl_itemPlanGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_itemPlanGrid.Location = new System.Drawing.Point(0, 0);
            this.pnl_itemPlanGrid.Name = "pnl_itemPlanGrid";
            this.pnl_itemPlanGrid.Size = new System.Drawing.Size(1025, 30);
            this.pnl_itemPlanGrid.TabIndex = 390;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.BackColor = System.Drawing.Color.PowderBlue;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label8.Location = new System.Drawing.Point(3, 4);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 23);
            this.label8.TabIndex = 386;
            this.label8.Text = "제품목록";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_plus
            // 
            this.btn_plus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_plus.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_plus.Location = new System.Drawing.Point(832, 5);
            this.btn_plus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_plus.Name = "btn_plus";
            this.btn_plus.Size = new System.Drawing.Size(52, 22);
            this.btn_plus.TabIndex = 384;
            this.btn_plus.Text = "행추가";
            this.btn_plus.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button1.Location = new System.Drawing.Point(943, 5);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 22);
            this.button1.TabIndex = 389;
            this.button1.Text = "새로고침";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btn_minus
            // 
            this.btn_minus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_minus.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_minus.Location = new System.Drawing.Point(887, 5);
            this.btn_minus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_minus.Name = "btn_minus";
            this.btn_minus.Size = new System.Drawing.Size(52, 22);
            this.btn_minus.TabIndex = 385;
            this.btn_minus.Text = "행삭제";
            this.btn_minus.UseVisualStyleBackColor = true;
            // 
            // dgv주문내역
            // 
            this.dgv주문내역._BorderColor = System.Drawing.Color.White;
            this.dgv주문내역._DirKey = "R";
            this.dgv주문내역._KeyboardCmd = "0";
            this.dgv주문내역._KeyInput = "";
            this.dgv주문내역._LastCol = -1;
            this.dgv주문내역._LastRow = -1;
            this.dgv주문내역.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.dgv주문내역.AllowUserToAddRows = false;
            this.dgv주문내역.AllowUserToDeleteRows = false;
            this.dgv주문내역.AllowUserToOrderColumns = true;
            this.dgv주문내역.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgv주문내역.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv주문내역.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv주문내역.ColumnHeadersHeight = 40;
            this.dgv주문내역.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LOT_NO,
            this.거래처코드,
            this.LOT_SUB,
            this.ODR_DATE,
            this.ODR_CD,
            this.거래처,
            this.ITEM_NM,
            this.O전표상태,
            this.O_전표상태코드,
            this.배송일자,
            this.배송코드,
            this.O_배송사원,
            this.배송사원코드,
            this.STOCK_AMT,
            this.CHK,
            this.O_창고코드,
            this.O_창고,
            this.부가세,
            this.부가세코드});
            this.dgv주문내역.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv주문내역.EnableHeadersVisualStyles = false;
            this.dgv주문내역.GridColor = System.Drawing.Color.PowderBlue;
            this.dgv주문내역.Location = new System.Drawing.Point(0, 34);
            this.dgv주문내역.Name = "dgv주문내역";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv주문내역.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgv주문내역.RowHeadersVisible = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.dgv주문내역.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgv주문내역.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgv주문내역.RowTemplate.Height = 23;
            this.dgv주문내역.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv주문내역.Size = new System.Drawing.Size(1025, 236);
            this.dgv주문내역.TabIndex = 390;
            this.dgv주문내역.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv주문내역_CellDoubleClick);
            // 
            // LOT_NO
            // 
            this.LOT_NO.HeaderText = "LOTNO";
            this.LOT_NO.Name = "LOT_NO";
            this.LOT_NO.Visible = false;
            this.LOT_NO.Width = 120;
            // 
            // 거래처코드
            // 
            this.거래처코드.HeaderText = "납품처코드";
            this.거래처코드.Name = "거래처코드";
            this.거래처코드.Visible = false;
            // 
            // LOT_SUB
            // 
            this.LOT_SUB.HeaderText = "SUB";
            this.LOT_SUB.Name = "LOT_SUB";
            this.LOT_SUB.Visible = false;
            this.LOT_SUB.Width = 50;
            // 
            // ODR_DATE
            // 
            this.ODR_DATE.HeaderText = "주문일자";
            this.ODR_DATE.Name = "ODR_DATE";
            this.ODR_DATE.Width = 120;
            // 
            // ODR_CD
            // 
            this.ODR_CD.HeaderText = "주문번호";
            this.ODR_CD.Name = "ODR_CD";
            this.ODR_CD.Width = 80;
            // 
            // 거래처
            // 
            this.거래처.HeaderText = "거래처";
            this.거래처.Name = "거래처";
            this.거래처.Width = 150;
            // 
            // ITEM_NM
            // 
            this.ITEM_NM.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ITEM_NM.HeaderText = "제품수";
            this.ITEM_NM.Name = "ITEM_NM";
            // 
            // O전표상태
            // 
            this.O전표상태.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.O전표상태.HeaderText = "전표상태";
            this.O전표상태.Name = "O전표상태";
            // 
            // O_전표상태코드
            // 
            this.O_전표상태코드.HeaderText = "전표상태코드";
            this.O_전표상태코드.Name = "O_전표상태코드";
            this.O_전표상태코드.Visible = false;
            // 
            // 배송일자
            // 
            this.배송일자.HeaderText = "배송일자";
            this.배송일자.Name = "배송일자";
            // 
            // 배송코드
            // 
            this.배송코드.HeaderText = "배송코드";
            this.배송코드.Name = "배송코드";
            this.배송코드.Visible = false;
            // 
            // O_배송사원
            // 
            this.O_배송사원.HeaderText = "배송사원";
            this.O_배송사원.Name = "O_배송사원";
            // 
            // 배송사원코드
            // 
            this.배송사원코드.HeaderText = "배송사원코드";
            this.배송사원코드.Name = "배송사원코드";
            this.배송사원코드.Visible = false;
            // 
            // STOCK_AMT
            // 
            this.STOCK_AMT.HeaderText = "비고";
            this.STOCK_AMT.Name = "STOCK_AMT";
            this.STOCK_AMT.Width = 150;
            // 
            // CHK
            // 
            this.CHK.HeaderText = "선택";
            this.CHK.Name = "CHK";
            this.CHK.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CHK.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.CHK.Visible = false;
            this.CHK.Width = 45;
            // 
            // O_창고코드
            // 
            this.O_창고코드.HeaderText = "창고코드";
            this.O_창고코드.Name = "O_창고코드";
            this.O_창고코드.Visible = false;
            // 
            // O_창고
            // 
            this.O_창고.HeaderText = "창고";
            this.O_창고.Name = "O_창고";
            this.O_창고.Visible = false;
            // 
            // 부가세
            // 
            this.부가세.HeaderText = "부가세";
            this.부가세.Name = "부가세";
            // 
            // 부가세코드
            // 
            this.부가세코드.HeaderText = "부가세코드";
            this.부가세코드.Name = "부가세코드";
            this.부가세코드.Visible = false;
            // 
            // pnl_itemHalfGrid
            // 
            this.pnl_itemHalfGrid.Controls.Add(this.lbl제품제고);
            this.pnl_itemHalfGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_itemHalfGrid.Location = new System.Drawing.Point(0, 0);
            this.pnl_itemHalfGrid.Name = "pnl_itemHalfGrid";
            this.pnl_itemHalfGrid.Size = new System.Drawing.Size(1025, 34);
            this.pnl_itemHalfGrid.TabIndex = 389;
            // 
            // lbl제품제고
            // 
            this.lbl제품제고.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl제품제고.BackColor = System.Drawing.Color.White;
            this.lbl제품제고.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl제품제고.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl제품제고.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl제품제고.Location = new System.Drawing.Point(8, 5);
            this.lbl제품제고.Name = "lbl제품제고";
            this.lbl제품제고.Size = new System.Drawing.Size(110, 24);
            this.lbl제품제고.TabIndex = 393;
            this.lbl제품제고.Text = "주문내역";
            this.lbl제품제고.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbo전표상태);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt시간);
            this.groupBox1.Controls.Add(this.pnl계산서발행);
            this.groupBox1.Controls.Add(this.dtp발행일자);
            this.groupBox1.Controls.Add(this.txt입력방식);
            this.groupBox1.Controls.Add(this.cbo부가세);
            this.groupBox1.Controls.Add(this.cbo창고);
            this.groupBox1.Controls.Add(this.cbo담당사원);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.lbl발행일자);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.txt_매출일자);
            this.groupBox1.Controls.Add(this.txt_comment);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txt_cust_nm);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt매출번호);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lbl_flow_cd);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1025, 134);
            this.groupBox1.TabIndex = 352;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "매출입력";
            // 
            // cbo전표상태
            // 
            this.cbo전표상태._BorderColor = System.Drawing.Color.PowderBlue;
            this.cbo전표상태._FocusedBackColor = System.Drawing.Color.White;
            this.cbo전표상태.FormattingEnabled = true;
            this.cbo전표상태.Location = new System.Drawing.Point(844, 14);
            this.cbo전표상태.Name = "cbo전표상태";
            this.cbo전표상태.Size = new System.Drawing.Size(116, 25);
            this.cbo전표상태.TabIndex = 410;
            this.cbo전표상태.SelectedIndexChanged += new System.EventHandler(this.cbo전표상태_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.PowderBlue;
            this.label1.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(738, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 21);
            this.label1.TabIndex = 409;
            this.label1.Text = "전표상태";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt시간
            // 
            this.txt시간._AutoTab = true;
            this.txt시간._BorderColor = System.Drawing.Color.PowderBlue;
            this.txt시간._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txt시간._WaterMarkColor = System.Drawing.Color.Gray;
            this.txt시간._WaterMarkText = "";
            this.txt시간.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt시간.Enabled = false;
            this.txt시간.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt시간.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.txt시간.Location = new System.Drawing.Point(227, 20);
            this.txt시간.MaxLength = 20;
            this.txt시간.Name = "txt시간";
            this.txt시간.Size = new System.Drawing.Size(66, 21);
            this.txt시간.TabIndex = 394;
            this.txt시간.Text = "12:59:46";
            // 
            // pnl계산서발행
            // 
            this.pnl계산서발행.Controls.Add(this.rdo계산서미발행);
            this.pnl계산서발행.Controls.Add(this.rdo계산서발행);
            this.pnl계산서발행.Location = new System.Drawing.Point(342, 74);
            this.pnl계산서발행.Name = "pnl계산서발행";
            this.pnl계산서발행.Size = new System.Drawing.Size(120, 21);
            this.pnl계산서발행.TabIndex = 408;
            // 
            // rdo계산서미발행
            // 
            this.rdo계산서미발행.AutoSize = true;
            this.rdo계산서미발행.Dock = System.Windows.Forms.DockStyle.Left;
            this.rdo계산서미발행.Location = new System.Drawing.Point(55, 0);
            this.rdo계산서미발행.Name = "rdo계산서미발행";
            this.rdo계산서미발행.Size = new System.Drawing.Size(69, 21);
            this.rdo계산서미발행.TabIndex = 407;
            this.rdo계산서미발행.TabStop = true;
            this.rdo계산서미발행.Text = "미발행";
            this.rdo계산서미발행.UseVisualStyleBackColor = true;
            this.rdo계산서미발행.CheckedChanged += new System.EventHandler(this.rdo계산서미발행_CheckedChanged);
            // 
            // rdo계산서발행
            // 
            this.rdo계산서발행.AutoSize = true;
            this.rdo계산서발행.Checked = true;
            this.rdo계산서발행.Dock = System.Windows.Forms.DockStyle.Left;
            this.rdo계산서발행.Location = new System.Drawing.Point(0, 0);
            this.rdo계산서발행.Name = "rdo계산서발행";
            this.rdo계산서발행.Size = new System.Drawing.Size(55, 21);
            this.rdo계산서발행.TabIndex = 406;
            this.rdo계산서발행.TabStop = true;
            this.rdo계산서발행.Text = "발행";
            this.rdo계산서발행.UseVisualStyleBackColor = true;
            this.rdo계산서발행.CheckedChanged += new System.EventHandler(this.rdo계산서발행_CheckedChanged);
            // 
            // dtp발행일자
            // 
            this.dtp발행일자._BorderColor = System.Drawing.Color.PowderBlue;
            this.dtp발행일자._FocusedBackColor = System.Drawing.Color.White;
            this.dtp발행일자.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp발행일자.Location = new System.Drawing.Point(593, 73);
            this.dtp발행일자.Name = "dtp발행일자";
            this.dtp발행일자.Size = new System.Drawing.Size(115, 25);
            this.dtp발행일자.TabIndex = 405;
            // 
            // txt입력방식
            // 
            this.txt입력방식._AutoTab = true;
            this.txt입력방식._BorderColor = System.Drawing.Color.PowderBlue;
            this.txt입력방식._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txt입력방식._WaterMarkColor = System.Drawing.Color.Gray;
            this.txt입력방식._WaterMarkText = "";
            this.txt입력방식.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt입력방식.Enabled = false;
            this.txt입력방식.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt입력방식.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.txt입력방식.Location = new System.Drawing.Point(593, 18);
            this.txt입력방식.MaxLength = 20;
            this.txt입력방식.Name = "txt입력방식";
            this.txt입력방식.Size = new System.Drawing.Size(52, 23);
            this.txt입력방식.TabIndex = 404;
            this.txt입력방식.TabStop = false;
            // 
            // cbo부가세
            // 
            this.cbo부가세._BorderColor = System.Drawing.Color.PowderBlue;
            this.cbo부가세._FocusedBackColor = System.Drawing.Color.White;
            this.cbo부가세.FormattingEnabled = true;
            this.cbo부가세.Location = new System.Drawing.Point(844, 76);
            this.cbo부가세.Name = "cbo부가세";
            this.cbo부가세.Size = new System.Drawing.Size(140, 25);
            this.cbo부가세.TabIndex = 401;
            // 
            // cbo창고
            // 
            this.cbo창고._BorderColor = System.Drawing.Color.PowderBlue;
            this.cbo창고._FocusedBackColor = System.Drawing.Color.White;
            this.cbo창고.FormattingEnabled = true;
            this.cbo창고.Location = new System.Drawing.Point(109, 74);
            this.cbo창고.Name = "cbo창고";
            this.cbo창고.Size = new System.Drawing.Size(117, 25);
            this.cbo창고.TabIndex = 400;
            // 
            // cbo담당사원
            // 
            this.cbo담당사원._BorderColor = System.Drawing.Color.PowderBlue;
            this.cbo담당사원._FocusedBackColor = System.Drawing.Color.White;
            this.cbo담당사원.FormattingEnabled = true;
            this.cbo담당사원.Location = new System.Drawing.Point(591, 45);
            this.cbo담당사원.Name = "cbo담당사원";
            this.cbo담당사원.Size = new System.Drawing.Size(99, 25);
            this.cbo담당사원.TabIndex = 398;
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.Color.PowderBlue;
            this.label19.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label19.ForeColor = System.Drawing.Color.Black;
            this.label19.Location = new System.Drawing.Point(738, 76);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(100, 21);
            this.label19.TabIndex = 397;
            this.label19.Text = "부가세코드";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl발행일자
            // 
            this.lbl발행일자.BackColor = System.Drawing.Color.PowderBlue;
            this.lbl발행일자.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl발행일자.ForeColor = System.Drawing.Color.Black;
            this.lbl발행일자.Location = new System.Drawing.Point(487, 74);
            this.lbl발행일자.Name = "lbl발행일자";
            this.lbl발행일자.Size = new System.Drawing.Size(100, 21);
            this.lbl발행일자.TabIndex = 396;
            this.lbl발행일자.Text = "발행일자";
            this.lbl발행일자.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.PowderBlue;
            this.label17.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(236, 75);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(100, 21);
            this.label17.TabIndex = 395;
            this.label17.Text = "계산서발행";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.PowderBlue;
            this.label11.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(8, 74);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(100, 21);
            this.label11.TabIndex = 394;
            this.label11.Text = "창고코드";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.PowderBlue;
            this.label15.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(487, 46);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(100, 21);
            this.label15.TabIndex = 392;
            this.label15.Text = "담당사원";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.PowderBlue;
            this.label13.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(487, 18);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(100, 21);
            this.label13.TabIndex = 390;
            this.label13.Text = "입력방식";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_매출일자
            // 
            this.txt_매출일자._BorderColor = System.Drawing.Color.PowderBlue;
            this.txt_매출일자._FocusedBackColor = System.Drawing.Color.White;
            this.txt_매출일자.BackColor = System.Drawing.Color.White;
            this.txt_매출일자.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txt_매출일자.Location = new System.Drawing.Point(109, 18);
            this.txt_매출일자.Name = "txt_매출일자";
            this.txt_매출일자.Size = new System.Drawing.Size(116, 25);
            this.txt_매출일자.TabIndex = 1;
            // 
            // txt_comment
            // 
            this.txt_comment._AutoTab = true;
            this.txt_comment._BorderColor = System.Drawing.Color.PowderBlue;
            this.txt_comment._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txt_comment._WaterMarkColor = System.Drawing.Color.Gray;
            this.txt_comment._WaterMarkText = "";
            this.txt_comment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_comment.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_comment.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.txt_comment.Location = new System.Drawing.Point(108, 100);
            this.txt_comment.MaxLength = 20;
            this.txt_comment.Name = "txt_comment";
            this.txt_comment.Size = new System.Drawing.Size(517, 23);
            this.txt_comment.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.PowderBlue;
            this.label5.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(8, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 21);
            this.label5.TabIndex = 337;
            this.label5.Text = "비고";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_cust_nm
            // 
            this.txt_cust_nm._AutoTab = true;
            this.txt_cust_nm._BorderColor = System.Drawing.Color.PowderBlue;
            this.txt_cust_nm._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txt_cust_nm._WaterMarkColor = System.Drawing.Color.Gray;
            this.txt_cust_nm._WaterMarkText = "";
            this.txt_cust_nm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_cust_nm.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_cust_nm.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.txt_cust_nm.Location = new System.Drawing.Point(109, 45);
            this.txt_cust_nm.MaxLength = 20;
            this.txt_cust_nm.Name = "txt_cust_nm";
            this.txt_cust_nm.Size = new System.Drawing.Size(330, 23);
            this.txt_cust_nm.TabIndex = 2;
            this.txt_cust_nm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_cust_nm_KeyDown);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.PowderBlue;
            this.label3.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(8, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 21);
            this.label3.TabIndex = 329;
            this.label3.Text = "거래처";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt매출번호
            // 
            this.txt매출번호._AutoTab = true;
            this.txt매출번호._BorderColor = System.Drawing.Color.PowderBlue;
            this.txt매출번호._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txt매출번호._WaterMarkColor = System.Drawing.Color.Gray;
            this.txt매출번호._WaterMarkText = "";
            this.txt매출번호.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt매출번호.Enabled = false;
            this.txt매출번호.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt매출번호.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.txt매출번호.Location = new System.Drawing.Point(396, 18);
            this.txt매출번호.MaxLength = 20;
            this.txt매출번호.Name = "txt매출번호";
            this.txt매출번호.Size = new System.Drawing.Size(88, 23);
            this.txt매출번호.TabIndex = 328;
            this.txt매출번호.TabStop = false;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.PowderBlue;
            this.label6.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(295, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 21);
            this.label6.TabIndex = 327;
            this.label6.Text = "매출번호";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_flow_cd
            // 
            this.lbl_flow_cd.BackColor = System.Drawing.Color.PowderBlue;
            this.lbl_flow_cd.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_flow_cd.ForeColor = System.Drawing.Color.Black;
            this.lbl_flow_cd.Location = new System.Drawing.Point(8, 19);
            this.lbl_flow_cd.Name = "lbl_flow_cd";
            this.lbl_flow_cd.Size = new System.Drawing.Size(100, 21);
            this.lbl_flow_cd.TabIndex = 289;
            this.lbl_flow_cd.Text = "매출일자";
            this.lbl_flow_cd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tab2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(331, 681);
            this.tabControl1.TabIndex = 353;
            // 
            // tab2
            // 
            this.tab2.Controls.Add(this.dgv매출);
            this.tab2.Controls.Add(this.panel3);
            this.tab2.Location = new System.Drawing.Point(4, 26);
            this.tab2.Name = "tab2";
            this.tab2.Padding = new System.Windows.Forms.Padding(3);
            this.tab2.Size = new System.Drawing.Size(323, 651);
            this.tab2.TabIndex = 1;
            this.tab2.Text = "기간별 조회";
            this.tab2.UseVisualStyleBackColor = true;
            // 
            // dgv매출
            // 
            this.dgv매출._BorderColor = System.Drawing.Color.White;
            this.dgv매출._DirKey = "R";
            this.dgv매출._KeyboardCmd = "0";
            this.dgv매출._KeyInput = "";
            this.dgv매출._LastCol = -1;
            this.dgv매출._LastRow = -1;
            this.dgv매출.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.dgv매출.AllowUserToAddRows = false;
            this.dgv매출.AllowUserToDeleteRows = false;
            this.dgv매출.AllowUserToResizeColumns = false;
            this.dgv매출.AllowUserToResizeRows = false;
            this.dgv매출.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgv매출.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv매출.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgv매출.ColumnHeadersHeight = 40;
            this.dgv매출.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv매출.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.M_매출일자,
            this.M_매출번호,
            this.M_주문일자,
            this.M_거래처,
            this.M_거래처코드,
            this.M_담당사원코드,
            this.M_계산서발행여부,
            this.M_발행일자,
            this.M_부가세코드,
            this.M_비고});
            this.dgv매출.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv매출.EnableHeadersVisualStyles = false;
            this.dgv매출.GridColor = System.Drawing.Color.PowderBlue;
            this.dgv매출.Location = new System.Drawing.Point(3, 41);
            this.dgv매출.Name = "dgv매출";
            this.dgv매출.ReadOnly = true;
            this.dgv매출.RowHeadersVisible = false;
            this.dgv매출.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            this.dgv매출.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgv매출.RowTemplate.Height = 23;
            this.dgv매출.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv매출.Size = new System.Drawing.Size(317, 607);
            this.dgv매출.TabIndex = 332;
            this.dgv매출.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv매출_CellDoubleClick);
            // 
            // M_매출일자
            // 
            this.M_매출일자.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.M_매출일자.HeaderText = "매출일자";
            this.M_매출일자.Name = "M_매출일자";
            this.M_매출일자.ReadOnly = true;
            this.M_매출일자.Width = 85;
            // 
            // M_매출번호
            // 
            this.M_매출번호.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.M_매출번호.HeaderText = "번호";
            this.M_매출번호.Name = "M_매출번호";
            this.M_매출번호.ReadOnly = true;
            this.M_매출번호.Width = 59;
            // 
            // M_주문일자
            // 
            this.M_주문일자.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.M_주문일자.HeaderText = "주문일자";
            this.M_주문일자.Name = "M_주문일자";
            this.M_주문일자.ReadOnly = true;
            // 
            // M_거래처
            // 
            this.M_거래처.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.M_거래처.HeaderText = "거래처";
            this.M_거래처.Name = "M_거래처";
            this.M_거래처.ReadOnly = true;
            // 
            // M_거래처코드
            // 
            this.M_거래처코드.HeaderText = "거래처코드";
            this.M_거래처코드.Name = "M_거래처코드";
            this.M_거래처코드.ReadOnly = true;
            this.M_거래처코드.Visible = false;
            // 
            // M_담당사원코드
            // 
            this.M_담당사원코드.HeaderText = "담당사원코드";
            this.M_담당사원코드.Name = "M_담당사원코드";
            this.M_담당사원코드.ReadOnly = true;
            this.M_담당사원코드.Visible = false;
            // 
            // M_계산서발행여부
            // 
            this.M_계산서발행여부.HeaderText = "계산서발행여부";
            this.M_계산서발행여부.Name = "M_계산서발행여부";
            this.M_계산서발행여부.ReadOnly = true;
            this.M_계산서발행여부.Visible = false;
            // 
            // M_발행일자
            // 
            this.M_발행일자.HeaderText = "발행일자";
            this.M_발행일자.Name = "M_발행일자";
            this.M_발행일자.ReadOnly = true;
            this.M_발행일자.Visible = false;
            // 
            // M_부가세코드
            // 
            this.M_부가세코드.HeaderText = "부가세코드";
            this.M_부가세코드.Name = "M_부가세코드";
            this.M_부가세코드.ReadOnly = true;
            this.M_부가세코드.Visible = false;
            // 
            // M_비고
            // 
            this.M_비고.HeaderText = "비고";
            this.M_비고.Name = "M_비고";
            this.M_비고.ReadOnly = true;
            this.M_비고.Visible = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnSrch);
            this.panel3.Controls.Add(this.end_date);
            this.panel3.Controls.Add(this.start_date);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(317, 38);
            this.panel3.TabIndex = 343;
            // 
            // btnSrch
            // 
            this.btnSrch.BackColor = System.Drawing.Color.Transparent;
            this.btnSrch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSrch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSrch.FlatAppearance.BorderSize = 0;
            this.btnSrch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btnSrch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSrch.Image = ((System.Drawing.Image)(resources.GetObject("btnSrch.Image")));
            this.btnSrch.Location = new System.Drawing.Point(279, 5);
            this.btnSrch.Name = "btnSrch";
            this.btnSrch.Size = new System.Drawing.Size(33, 33);
            this.btnSrch.TabIndex = 339;
            this.btnSrch.Tag = "검색";
            this.btnSrch.UseVisualStyleBackColor = false;
            this.btnSrch.Click += new System.EventHandler(this.btnSrch_Click);
            // 
            // end_date
            // 
            this.end_date.Checked = false;
            this.end_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.end_date.Location = new System.Drawing.Point(155, 12);
            this.end_date.Name = "end_date";
            this.end_date.Size = new System.Drawing.Size(104, 25);
            this.end_date.TabIndex = 340;
            this.end_date.Value = new System.DateTime(2020, 3, 24, 0, 0, 0, 0);
            // 
            // start_date
            // 
            this.start_date.Checked = false;
            this.start_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.start_date.Location = new System.Drawing.Point(3, 11);
            this.start_date.Name = "start_date";
            this.start_date.Size = new System.Drawing.Size(115, 25);
            this.start_date.TabIndex = 339;
            this.start_date.Value = new System.DateTime(2020, 3, 24, 0, 0, 0, 0);
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.White;
            this.label12.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label12.Location = new System.Drawing.Point(119, 12);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 23);
            this.label12.TabIndex = 339;
            this.label12.Text = "~";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frm매출관리
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1360, 714);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "frm매출관리";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frm매출관리";
            this.Load += new System.EventHandler(this.frm매출관리_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.split_그리드.Panel1.ResumeLayout(false);
            this.split_그리드.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.split_그리드)).EndInit();
            this.split_그리드.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv제품)).EndInit();
            this.pnl_itemPlanGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv주문내역)).EndInit();
            this.pnl_itemHalfGrid.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.pnl계산서발행.ResumeLayout(false);
            this.pnl계산서발행.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tab2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv매출)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer split_그리드;
        private Controls.conDataGridView dgv제품;
        private System.Windows.Forms.Panel pnl_itemPlanGrid;
        private System.Windows.Forms.Button btn_plus;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_minus;
        private System.Windows.Forms.Panel pnl_itemHalfGrid;
        private System.Windows.Forms.GroupBox groupBox1;
        private Controls.conDateTimePicker txt_매출일자;
        private Controls.conTextBox txt_comment;
        private System.Windows.Forms.Label label5;
        private Controls.conTextBox txt_cust_nm;
        private System.Windows.Forms.Label label3;
        private Controls.conTextBox txt매출번호;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_flow_cd;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tab2;
        private System.Windows.Forms.Button btnSrch;
        private System.Windows.Forms.DateTimePicker end_date;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker start_date;
        private Controls.conDataGridView dgv매출;
        private System.Windows.Forms.Label label8;
        private Controls.conComboBox cbo창고;
        private Controls.conComboBox cbo담당사원;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lbl발행일자;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btn_close;
        private Controls.conComboBox cbo부가세;
        private System.Windows.Forms.Label lbl제품제고;
        private Controls.conDataGridView dgv주문내역;
        private Controls.conTextBox txt입력방식;
        private Controls.conDateTimePicker dtp발행일자;
        private System.Windows.Forms.Panel pnl계산서발행;
        private System.Windows.Forms.RadioButton rdo계산서미발행;
        private System.Windows.Forms.RadioButton rdo계산서발행;
        private Controls.conTextBox lbl_out_gbn;
        private Controls.conTextBox txt시간;
        private Controls.conComboBox cbo전표상태;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn LOT_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn 거래처코드;
        private System.Windows.Forms.DataGridViewTextBoxColumn LOT_SUB;
        private System.Windows.Forms.DataGridViewTextBoxColumn ODR_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn ODR_CD;
        private System.Windows.Forms.DataGridViewTextBoxColumn 거래처;
        private System.Windows.Forms.DataGridViewTextBoxColumn ITEM_NM;
        private System.Windows.Forms.DataGridViewTextBoxColumn O전표상태;
        private System.Windows.Forms.DataGridViewTextBoxColumn O_전표상태코드;
        private System.Windows.Forms.DataGridViewTextBoxColumn 배송일자;
        private System.Windows.Forms.DataGridViewTextBoxColumn 배송코드;
        private System.Windows.Forms.DataGridViewTextBoxColumn O_배송사원;
        private System.Windows.Forms.DataGridViewTextBoxColumn 배송사원코드;
        private System.Windows.Forms.DataGridViewTextBoxColumn STOCK_AMT;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CHK;
        private System.Windows.Forms.DataGridViewTextBoxColumn O_창고코드;
        private System.Windows.Forms.DataGridViewTextBoxColumn O_창고;
        private System.Windows.Forms.DataGridViewTextBoxColumn 부가세;
        private System.Windows.Forms.DataGridViewTextBoxColumn 부가세코드;
        private System.Windows.Forms.DataGridViewTextBoxColumn M_매출일자;
        private System.Windows.Forms.DataGridViewTextBoxColumn M_매출번호;
        private System.Windows.Forms.DataGridViewTextBoxColumn M_주문일자;
        private System.Windows.Forms.DataGridViewTextBoxColumn M_거래처;
        private System.Windows.Forms.DataGridViewTextBoxColumn M_거래처코드;
        private System.Windows.Forms.DataGridViewTextBoxColumn M_담당사원코드;
        private System.Windows.Forms.DataGridViewTextBoxColumn M_계산서발행여부;
        private System.Windows.Forms.DataGridViewTextBoxColumn M_발행일자;
        private System.Windows.Forms.DataGridViewTextBoxColumn M_부가세코드;
        private System.Windows.Forms.DataGridViewTextBoxColumn M_비고;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewTextBoxColumn40;
        private System.Windows.Forms.DataGridViewTextBoxColumn O_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn O_ITEM_CD;
        private System.Windows.Forms.DataGridViewTextBoxColumn 제품명;
        private System.Windows.Forms.DataGridViewTextBoxColumn 규격;
        private System.Windows.Forms.DataGridViewTextBoxColumn O_UNIT_NM;
        private System.Windows.Forms.DataGridViewTextBoxColumn O_UNIT_CD;
        private System.Windows.Forms.DataGridViewTextBoxColumn 수량;
        private System.Windows.Forms.DataGridViewTextBoxColumn 단가;
        private System.Windows.Forms.DataGridViewTextBoxColumn 금액;
        private CalendarColumn 최종매출일;
        private System.Windows.Forms.DataGridViewComboBoxColumn 매출구분;
        private System.Windows.Forms.DataGridViewTextBoxColumn 비고;
        private System.Windows.Forms.DataGridViewTextBoxColumn O_주문일자;
        private System.Windows.Forms.DataGridViewTextBoxColumn O_주문번호;
        private System.Windows.Forms.DataGridViewComboBoxColumn O_부가세;
        private System.Windows.Forms.DataGridViewComboBoxColumn O_과세;
    }
}