namespace MES.H10_주문관리
{
    partial class frm배송등록
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm배송등록));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnl_top = new System.Windows.Forms.Panel();
            this.txt_plan_cd = new MES.Controls.conTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.txt_vat_cd = new MES.Controls.conTextBox();
            this.txt_jang_cd = new MES.Controls.conTextBox();
            this.lbl_out_gbn = new MES.Controls.conTextBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lbl_title = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.pnl_main = new System.Windows.Forms.Panel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.pnl_그리드 = new System.Windows.Forms.SplitContainer();
            this.itemOutGrid = new MES.Controls.conDataGridView();
            this.dataGridViewTextBoxColumn40 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.O_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.O_ITEM_NM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.O_ITEM_CD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.O_SPEC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.O_UNIT_NM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.O_UNIT_CD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TOTAL_AMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRICE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TOTAL_MONEY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.최종매출일 = new CalendarColumn();
            this.매출구분 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.O_WORK_YN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.비고 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conMaskedTextBox1 = new MES.Controls.conMaskedTextBox();
            this.pnl_itemOutGrid = new System.Windows.Forms.Panel();
            this.btn_minus = new System.Windows.Forms.Button();
            this.lbl제품내역 = new System.Windows.Forms.Label();
            this.dgv주문등록 = new MES.Controls.conDataGridView();
            this.H주문일자 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.H주문번호 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.H항목순번 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.H주문시간 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.H거래처 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.H거래처코드 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.H담당사원 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.H담당사원코드 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.H부가세 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.H전표상태 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.H비고 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnl_itemStockGrid = new System.Windows.Forms.Panel();
            this.btn배송완료 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.dtp앤드 = new MES.Controls.conDateTimePicker();
            this.dtp스타트 = new MES.Controls.conDateTimePicker();
            this.lbl제품제고 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn싸인 = new System.Windows.Forms.Button();
            this.pic = new System.Windows.Forms.PictureBox();
            this.txt비고 = new MES.Controls.conTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txt_staff_phone = new MES.Controls.conTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_staff_nm = new MES.Controls.conTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt입력방식 = new MES.Controls.conTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txt시간 = new MES.Controls.conTextBox();
            this.cbo전표상태 = new MES.Controls.conComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbo배송사원 = new MES.Controls.conComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbo담당사원 = new MES.Controls.conComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txt_out_date = new MES.Controls.conDateTimePicker();
            this.txt_cust_nm = new MES.Controls.conTextBox();
            this.btnCustSrch = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_out_cd = new MES.Controls.conTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_flow_cd = new System.Windows.Forms.Label();
            this.txt_cust_cd = new MES.Controls.conTextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tab1 = new System.Windows.Forms.TabPage();
            this.txt_end_date = new MES.Controls.conDateTimePicker();
            this.txt_start_date = new MES.Controls.conDateTimePicker();
            this.btnSrch = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.tdOutGridTemp = new MES.Controls.conDataGridView();
            this.배송배송일 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.배송번호 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.배송거래처 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.배송제품수 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.배송거래처코드 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.배송창고코드 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.배송창고명 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.배송자체여부 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.배송부가세구분 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.담당자 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.전표상태 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.배송사원 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.등록사원 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.등록사원폰 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.배송전표상태 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.싸인 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.주문일자 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tdOutGrid = new MES.Controls.conDataGridView();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn26 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn27 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn28 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn29 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn30 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn31 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn32 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn33 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SELF_YN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.td_VAT_CD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnl_top.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnl_main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnl_그리드)).BeginInit();
            this.pnl_그리드.Panel1.SuspendLayout();
            this.pnl_그리드.Panel2.SuspendLayout();
            this.pnl_그리드.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemOutGrid)).BeginInit();
            this.pnl_itemOutGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv주문등록)).BeginInit();
            this.pnl_itemStockGrid.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tab1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tdOutGridTemp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tdOutGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl_top
            // 
            this.pnl_top.BackColor = System.Drawing.Color.PowderBlue;
            this.pnl_top.Controls.Add(this.txt_plan_cd);
            this.pnl_top.Controls.Add(this.panel1);
            this.pnl_top.Controls.Add(this.txt_vat_cd);
            this.pnl_top.Controls.Add(this.txt_jang_cd);
            this.pnl_top.Controls.Add(this.lbl_out_gbn);
            this.pnl_top.Controls.Add(this.btnNew);
            this.pnl_top.Controls.Add(this.btnSave);
            this.pnl_top.Controls.Add(this.lbl_title);
            this.pnl_top.Controls.Add(this.btnDelete);
            this.pnl_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_top.Location = new System.Drawing.Point(0, 0);
            this.pnl_top.Name = "pnl_top";
            this.pnl_top.Size = new System.Drawing.Size(1284, 33);
            this.pnl_top.TabIndex = 13;
            // 
            // txt_plan_cd
            // 
            this.txt_plan_cd._AutoTab = true;
            this.txt_plan_cd._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.txt_plan_cd._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txt_plan_cd._WaterMarkColor = System.Drawing.Color.Gray;
            this.txt_plan_cd._WaterMarkText = "";
            this.txt_plan_cd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txt_plan_cd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_plan_cd.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_plan_cd.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.txt_plan_cd.Location = new System.Drawing.Point(617, 5);
            this.txt_plan_cd.MaxLength = 6;
            this.txt_plan_cd.Name = "txt_plan_cd";
            this.txt_plan_cd.Size = new System.Drawing.Size(50, 22);
            this.txt_plan_cd.TabIndex = 392;
            this.txt_plan_cd.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(1218, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(66, 33);
            this.panel1.TabIndex = 390;
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
            this.btnClose.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F);
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.btnClose.Image = global::MES.Properties.Resources.newnewCloseBtn;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(1, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(65, 33);
            this.btnClose.TabIndex = 10;
            this.btnClose.Tag = "종료";
            this.btnClose.Text = "닫기";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txt_vat_cd
            // 
            this.txt_vat_cd._AutoTab = true;
            this.txt_vat_cd._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.txt_vat_cd._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txt_vat_cd._WaterMarkColor = System.Drawing.Color.Gray;
            this.txt_vat_cd._WaterMarkText = "";
            this.txt_vat_cd.BackColor = System.Drawing.SystemColors.Window;
            this.txt_vat_cd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_vat_cd.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_vat_cd.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.txt_vat_cd.Location = new System.Drawing.Point(406, 6);
            this.txt_vat_cd.MaxLength = 20;
            this.txt_vat_cd.Name = "txt_vat_cd";
            this.txt_vat_cd.Size = new System.Drawing.Size(103, 24);
            this.txt_vat_cd.TabIndex = 357;
            this.txt_vat_cd.Visible = false;
            // 
            // txt_jang_cd
            // 
            this.txt_jang_cd._AutoTab = true;
            this.txt_jang_cd._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.txt_jang_cd._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txt_jang_cd._WaterMarkColor = System.Drawing.Color.Gray;
            this.txt_jang_cd._WaterMarkText = "";
            this.txt_jang_cd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txt_jang_cd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_jang_cd.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_jang_cd.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.txt_jang_cd.Location = new System.Drawing.Point(175, 7);
            this.txt_jang_cd.MaxLength = 6;
            this.txt_jang_cd.Name = "txt_jang_cd";
            this.txt_jang_cd.Size = new System.Drawing.Size(166, 22);
            this.txt_jang_cd.TabIndex = 389;
            this.txt_jang_cd.Visible = false;
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
            this.lbl_out_gbn.Location = new System.Drawing.Point(672, 7);
            this.lbl_out_gbn.MaxLength = 6;
            this.lbl_out_gbn.Name = "lbl_out_gbn";
            this.lbl_out_gbn.Size = new System.Drawing.Size(166, 22);
            this.lbl_out_gbn.TabIndex = 388;
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
            this.btnNew.Location = new System.Drawing.Point(1006, 3);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(65, 29);
            this.btnNew.TabIndex = 23;
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
            this.btnSave.Location = new System.Drawing.Point(1077, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(65, 29);
            this.btnSave.TabIndex = 21;
            this.btnSave.Tag = "저장";
            this.btnSave.Text = "저장";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
            this.lbl_title.Text = "배송등록";
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
            this.btnDelete.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F);
            this.btnDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.btnDelete.Image = global::MES.Properties.Resources.newDelBtn;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDelete.Location = new System.Drawing.Point(1148, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(65, 29);
            this.btnDelete.TabIndex = 22;
            this.btnDelete.Tag = "삭제";
            this.btnDelete.Text = "삭제";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // pnl_main
            // 
            this.pnl_main.BackColor = System.Drawing.Color.White;
            this.pnl_main.Controls.Add(this.splitContainer2);
            this.pnl_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_main.Location = new System.Drawing.Point(0, 33);
            this.pnl_main.Name = "pnl_main";
            this.pnl_main.Size = new System.Drawing.Size(1284, 681);
            this.pnl_main.TabIndex = 14;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BackColor = System.Drawing.Color.Coral;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(1);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer2.Panel1.Controls.Add(this.pnl_그리드);
            this.splitContainer2.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer2.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer2.Size = new System.Drawing.Size(1284, 681);
            this.splitContainer2.SplitterDistance = 892;
            this.splitContainer2.TabIndex = 392;
            // 
            // pnl_그리드
            // 
            this.pnl_그리드.BackColor = System.Drawing.Color.Coral;
            this.pnl_그리드.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_그리드.Location = new System.Drawing.Point(0, 148);
            this.pnl_그리드.Margin = new System.Windows.Forms.Padding(1);
            this.pnl_그리드.Name = "pnl_그리드";
            this.pnl_그리드.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // pnl_그리드.Panel1
            // 
            this.pnl_그리드.Panel1.BackColor = System.Drawing.Color.White;
            this.pnl_그리드.Panel1.Controls.Add(this.itemOutGrid);
            this.pnl_그리드.Panel1.Controls.Add(this.conMaskedTextBox1);
            this.pnl_그리드.Panel1.Controls.Add(this.pnl_itemOutGrid);
            // 
            // pnl_그리드.Panel2
            // 
            this.pnl_그리드.Panel2.BackColor = System.Drawing.Color.White;
            this.pnl_그리드.Panel2.Controls.Add(this.dgv주문등록);
            this.pnl_그리드.Panel2.Controls.Add(this.pnl_itemStockGrid);
            this.pnl_그리드.Size = new System.Drawing.Size(892, 533);
            this.pnl_그리드.SplitterDistance = 282;
            this.pnl_그리드.TabIndex = 393;
            // 
            // itemOutGrid
            // 
            this.itemOutGrid._BorderColor = System.Drawing.Color.Silver;
            this.itemOutGrid._DirKey = "R";
            this.itemOutGrid._KeyboardCmd = "1";
            this.itemOutGrid._KeyInput = "";
            this.itemOutGrid._LastCol = -1;
            this.itemOutGrid._LastRow = -1;
            this.itemOutGrid.AllowUserToAddRows = false;
            this.itemOutGrid.AllowUserToDeleteRows = false;
            this.itemOutGrid.AllowUserToOrderColumns = true;
            this.itemOutGrid.BackgroundColor = System.Drawing.Color.White;
            this.itemOutGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.itemOutGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.itemOutGrid.ColumnHeadersHeight = 40;
            this.itemOutGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn40,
            this.O_NO,
            this.O_ITEM_NM,
            this.O_ITEM_CD,
            this.O_SPEC,
            this.O_UNIT_NM,
            this.O_UNIT_CD,
            this.TOTAL_AMT,
            this.PRICE,
            this.TOTAL_MONEY,
            this.최종매출일,
            this.매출구분,
            this.O_WORK_YN,
            this.비고});
            this.itemOutGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemOutGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.itemOutGrid.EnableHeadersVisualStyles = false;
            this.itemOutGrid.GridColor = System.Drawing.Color.PowderBlue;
            this.itemOutGrid.Location = new System.Drawing.Point(0, 37);
            this.itemOutGrid.Name = "itemOutGrid";
            this.itemOutGrid.RowHeadersVisible = false;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.LightYellow;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.itemOutGrid.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.itemOutGrid.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.itemOutGrid.RowTemplate.Height = 23;
            this.itemOutGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.itemOutGrid.Size = new System.Drawing.Size(892, 245);
            this.itemOutGrid.TabIndex = 393;
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
            this.O_NO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.O_NO.DefaultCellStyle = dataGridViewCellStyle2;
            this.O_NO.HeaderText = "No.";
            this.O_NO.Name = "O_NO";
            this.O_NO.ReadOnly = true;
            this.O_NO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.O_NO.Width = 32;
            // 
            // O_ITEM_NM
            // 
            this.O_ITEM_NM.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.O_ITEM_NM.HeaderText = "제품명";
            this.O_ITEM_NM.Name = "O_ITEM_NM";
            this.O_ITEM_NM.ReadOnly = true;
            this.O_ITEM_NM.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.O_ITEM_NM.ToolTipText = "명칭";
            // 
            // O_ITEM_CD
            // 
            this.O_ITEM_CD.HeaderText = "O_ITEM_CD";
            this.O_ITEM_CD.Name = "O_ITEM_CD";
            this.O_ITEM_CD.Visible = false;
            // 
            // O_SPEC
            // 
            this.O_SPEC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.O_SPEC.DefaultCellStyle = dataGridViewCellStyle3;
            this.O_SPEC.HeaderText = "규격";
            this.O_SPEC.Name = "O_SPEC";
            this.O_SPEC.ReadOnly = true;
            this.O_SPEC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.O_SPEC.Width = 37;
            // 
            // O_UNIT_NM
            // 
            this.O_UNIT_NM.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.O_UNIT_NM.HeaderText = "단위";
            this.O_UNIT_NM.Name = "O_UNIT_NM";
            this.O_UNIT_NM.ReadOnly = true;
            this.O_UNIT_NM.Width = 56;
            // 
            // O_UNIT_CD
            // 
            this.O_UNIT_CD.HeaderText = "O_UNIT_CD";
            this.O_UNIT_CD.Name = "O_UNIT_CD";
            this.O_UNIT_CD.Visible = false;
            // 
            // TOTAL_AMT
            // 
            this.TOTAL_AMT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.TOTAL_AMT.HeaderText = "수량";
            this.TOTAL_AMT.Name = "TOTAL_AMT";
            this.TOTAL_AMT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TOTAL_AMT.ToolTipText = "수량";
            this.TOTAL_AMT.Width = 37;
            // 
            // PRICE
            // 
            this.PRICE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.PRICE.HeaderText = "단가";
            this.PRICE.Name = "PRICE";
            this.PRICE.ToolTipText = "단가";
            this.PRICE.Width = 56;
            // 
            // TOTAL_MONEY
            // 
            this.TOTAL_MONEY.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.TOTAL_MONEY.HeaderText = "금액";
            this.TOTAL_MONEY.Name = "TOTAL_MONEY";
            this.TOTAL_MONEY.ToolTipText = "금액";
            this.TOTAL_MONEY.Width = 56;
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
            // O_WORK_YN
            // 
            this.O_WORK_YN.HeaderText = "WORK_YN";
            this.O_WORK_YN.Name = "O_WORK_YN";
            this.O_WORK_YN.Visible = false;
            // 
            // 비고
            // 
            this.비고.HeaderText = "비고";
            this.비고.Name = "비고";
            this.비고.Width = 300;
            // 
            // conMaskedTextBox1
            // 
            this.conMaskedTextBox1._BorderColor = System.Drawing.Color.White;
            this.conMaskedTextBox1._FocusedBackColor = System.Drawing.Color.White;
            this.conMaskedTextBox1.Location = new System.Drawing.Point(326, 62);
            this.conMaskedTextBox1.Name = "conMaskedTextBox1";
            this.conMaskedTextBox1.Size = new System.Drawing.Size(100, 21);
            this.conMaskedTextBox1.TabIndex = 392;
            this.conMaskedTextBox1.Visible = false;
            // 
            // pnl_itemOutGrid
            // 
            this.pnl_itemOutGrid.Controls.Add(this.btn_minus);
            this.pnl_itemOutGrid.Controls.Add(this.lbl제품내역);
            this.pnl_itemOutGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_itemOutGrid.Location = new System.Drawing.Point(0, 0);
            this.pnl_itemOutGrid.Name = "pnl_itemOutGrid";
            this.pnl_itemOutGrid.Size = new System.Drawing.Size(892, 37);
            this.pnl_itemOutGrid.TabIndex = 391;
            // 
            // btn_minus
            // 
            this.btn_minus.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btn_minus.Location = new System.Drawing.Point(781, 9);
            this.btn_minus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_minus.Name = "btn_minus";
            this.btn_minus.Size = new System.Drawing.Size(89, 22);
            this.btn_minus.TabIndex = 390;
            this.btn_minus.Text = "목록삭제";
            this.btn_minus.UseVisualStyleBackColor = true;
            this.btn_minus.Click += new System.EventHandler(this.btn_minus_Click);
            // 
            // lbl제품내역
            // 
            this.lbl제품내역.BackColor = System.Drawing.Color.White;
            this.lbl제품내역.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl제품내역.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl제품내역.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl제품내역.Location = new System.Drawing.Point(4, 4);
            this.lbl제품내역.Name = "lbl제품내역";
            this.lbl제품내역.Size = new System.Drawing.Size(110, 24);
            this.lbl제품내역.TabIndex = 382;
            this.lbl제품내역.Text = "제품내역";
            this.lbl제품내역.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgv주문등록
            // 
            this.dgv주문등록._BorderColor = System.Drawing.Color.White;
            this.dgv주문등록._DirKey = "R";
            this.dgv주문등록._KeyboardCmd = "0";
            this.dgv주문등록._KeyInput = "";
            this.dgv주문등록._LastCol = -1;
            this.dgv주문등록._LastRow = -1;
            this.dgv주문등록.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.dgv주문등록.AllowUserToAddRows = false;
            this.dgv주문등록.AllowUserToDeleteRows = false;
            this.dgv주문등록.AllowUserToOrderColumns = true;
            this.dgv주문등록.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgv주문등록.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv주문등록.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgv주문등록.ColumnHeadersHeight = 40;
            this.dgv주문등록.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.H주문일자,
            this.H주문번호,
            this.H항목순번,
            this.H주문시간,
            this.H거래처,
            this.H거래처코드,
            this.H담당사원,
            this.H담당사원코드,
            this.H부가세,
            this.H전표상태,
            this.H비고});
            this.dgv주문등록.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv주문등록.EnableHeadersVisualStyles = false;
            this.dgv주문등록.GridColor = System.Drawing.Color.PowderBlue;
            this.dgv주문등록.Location = new System.Drawing.Point(0, 38);
            this.dgv주문등록.Name = "dgv주문등록";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv주문등록.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgv주문등록.RowHeadersVisible = false;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            this.dgv주문등록.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgv주문등록.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgv주문등록.RowTemplate.Height = 23;
            this.dgv주문등록.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv주문등록.Size = new System.Drawing.Size(892, 209);
            this.dgv주문등록.TabIndex = 386;
            this.dgv주문등록.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv주문등록_CellDoubleClick);
            // 
            // H주문일자
            // 
            this.H주문일자.HeaderText = "주문일자";
            this.H주문일자.Name = "H주문일자";
            // 
            // H주문번호
            // 
            this.H주문번호.HeaderText = "주문번호";
            this.H주문번호.Name = "H주문번호";
            // 
            // H항목순번
            // 
            this.H항목순번.HeaderText = "항목순번";
            this.H항목순번.Name = "H항목순번";
            this.H항목순번.Visible = false;
            // 
            // H주문시간
            // 
            this.H주문시간.HeaderText = "주문시간";
            this.H주문시간.Name = "H주문시간";
            // 
            // H거래처
            // 
            this.H거래처.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.H거래처.HeaderText = "거래처";
            this.H거래처.Name = "H거래처";
            this.H거래처.Width = 5;
            // 
            // H거래처코드
            // 
            this.H거래처코드.HeaderText = "거래처코드";
            this.H거래처코드.Name = "H거래처코드";
            this.H거래처코드.Visible = false;
            // 
            // H담당사원
            // 
            this.H담당사원.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.H담당사원.HeaderText = "담당사원";
            this.H담당사원.Name = "H담당사원";
            this.H담당사원.Width = 80;
            // 
            // H담당사원코드
            // 
            this.H담당사원코드.HeaderText = "담당사원코드";
            this.H담당사원코드.Name = "H담당사원코드";
            this.H담당사원코드.Visible = false;
            // 
            // H부가세
            // 
            this.H부가세.HeaderText = "부가세";
            this.H부가세.Name = "H부가세";
            this.H부가세.Visible = false;
            // 
            // H전표상태
            // 
            this.H전표상태.HeaderText = "전표상태";
            this.H전표상태.Name = "H전표상태";
            // 
            // H비고
            // 
            this.H비고.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.H비고.HeaderText = "비고";
            this.H비고.Name = "H비고";
            // 
            // pnl_itemStockGrid
            // 
            this.pnl_itemStockGrid.BackColor = System.Drawing.Color.White;
            this.pnl_itemStockGrid.Controls.Add(this.btn배송완료);
            this.pnl_itemStockGrid.Controls.Add(this.label9);
            this.pnl_itemStockGrid.Controls.Add(this.dtp앤드);
            this.pnl_itemStockGrid.Controls.Add(this.dtp스타트);
            this.pnl_itemStockGrid.Controls.Add(this.lbl제품제고);
            this.pnl_itemStockGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_itemStockGrid.Location = new System.Drawing.Point(0, 0);
            this.pnl_itemStockGrid.Name = "pnl_itemStockGrid";
            this.pnl_itemStockGrid.Size = new System.Drawing.Size(892, 38);
            this.pnl_itemStockGrid.TabIndex = 390;
            // 
            // btn배송완료
            // 
            this.btn배송완료.BackColor = System.Drawing.Color.Transparent;
            this.btn배송완료.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn배송완료.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn배송완료.FlatAppearance.BorderSize = 0;
            this.btn배송완료.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btn배송완료.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn배송완료.Image = ((System.Drawing.Image)(resources.GetObject("btn배송완료.Image")));
            this.btn배송완료.Location = new System.Drawing.Point(426, 6);
            this.btn배송완료.Name = "btn배송완료";
            this.btn배송완료.Size = new System.Drawing.Size(33, 33);
            this.btn배송완료.TabIndex = 400;
            this.btn배송완료.Tag = "검색";
            this.btn배송완료.UseVisualStyleBackColor = false;
            this.btn배송완료.Click += new System.EventHandler(this.btn배송완료_Click);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label9.Location = new System.Drawing.Point(255, 14);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 23);
            this.label9.TabIndex = 399;
            this.label9.Text = "~";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtp앤드
            // 
            this.dtp앤드._BorderColor = System.Drawing.Color.PowderBlue;
            this.dtp앤드._FocusedBackColor = System.Drawing.Color.White;
            this.dtp앤드.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp앤드.Location = new System.Drawing.Point(295, 15);
            this.dtp앤드.Name = "dtp앤드";
            this.dtp앤드.Size = new System.Drawing.Size(112, 21);
            this.dtp앤드.TabIndex = 398;
            // 
            // dtp스타트
            // 
            this.dtp스타트._BorderColor = System.Drawing.Color.PowderBlue;
            this.dtp스타트._FocusedBackColor = System.Drawing.Color.White;
            this.dtp스타트.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp스타트.Location = new System.Drawing.Point(140, 14);
            this.dtp스타트.Name = "dtp스타트";
            this.dtp스타트.Size = new System.Drawing.Size(112, 21);
            this.dtp스타트.TabIndex = 397;
            // 
            // lbl제품제고
            // 
            this.lbl제품제고.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl제품제고.BackColor = System.Drawing.Color.White;
            this.lbl제품제고.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl제품제고.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl제품제고.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl제품제고.Location = new System.Drawing.Point(4, 12);
            this.lbl제품제고.Name = "lbl제품제고";
            this.lbl제품제고.Size = new System.Drawing.Size(110, 24);
            this.lbl제품제고.TabIndex = 392;
            this.lbl제품제고.Text = "주문내역";
            this.lbl제품제고.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.btn싸인);
            this.groupBox1.Controls.Add(this.pic);
            this.groupBox1.Controls.Add(this.txt비고);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txt_staff_phone);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txt_staff_nm);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt입력방식);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txt시간);
            this.groupBox1.Controls.Add(this.cbo전표상태);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cbo배송사원);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cbo담당사원);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.txt_out_date);
            this.groupBox1.Controls.Add(this.txt_cust_nm);
            this.groupBox1.Controls.Add(this.btnCustSrch);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_out_cd);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lbl_flow_cd);
            this.groupBox1.Controls.Add(this.txt_cust_cd);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(892, 148);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "배송입력";
            // 
            // btn싸인
            // 
            this.btn싸인.Location = new System.Drawing.Point(817, 15);
            this.btn싸인.Name = "btn싸인";
            this.btn싸인.Size = new System.Drawing.Size(75, 23);
            this.btn싸인.TabIndex = 398;
            this.btn싸인.Text = "확인싸인";
            this.btn싸인.UseVisualStyleBackColor = true;
            this.btn싸인.Click += new System.EventHandler(this.btn싸인_Click);
            // 
            // pic
            // 
            this.pic.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pic.Location = new System.Drawing.Point(766, 44);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(126, 81);
            this.pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic.TabIndex = 397;
            this.pic.TabStop = false;
            // 
            // txt비고
            // 
            this.txt비고._AutoTab = true;
            this.txt비고._BorderColor = System.Drawing.Color.PowderBlue;
            this.txt비고._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txt비고._WaterMarkColor = System.Drawing.Color.Gray;
            this.txt비고._WaterMarkText = "";
            this.txt비고.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt비고.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt비고.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.txt비고.Location = new System.Drawing.Point(106, 123);
            this.txt비고.MaxLength = 20;
            this.txt비고.Name = "txt비고";
            this.txt비고.Size = new System.Drawing.Size(339, 21);
            this.txt비고.TabIndex = 395;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.PowderBlue;
            this.label12.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label12.Location = new System.Drawing.Point(6, 123);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(100, 21);
            this.label12.TabIndex = 396;
            this.label12.Text = "비고";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_staff_phone
            // 
            this.txt_staff_phone._AutoTab = true;
            this.txt_staff_phone._BorderColor = System.Drawing.Color.PowderBlue;
            this.txt_staff_phone._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txt_staff_phone._WaterMarkColor = System.Drawing.Color.Gray;
            this.txt_staff_phone._WaterMarkText = "";
            this.txt_staff_phone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_staff_phone.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_staff_phone.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.txt_staff_phone.Location = new System.Drawing.Point(728, 125);
            this.txt_staff_phone.MaxLength = 20;
            this.txt_staff_phone.Name = "txt_staff_phone";
            this.txt_staff_phone.ReadOnly = true;
            this.txt_staff_phone.Size = new System.Drawing.Size(122, 21);
            this.txt_staff_phone.TabIndex = 361;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.PowderBlue;
            this.label4.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(616, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 21);
            this.label4.TabIndex = 362;
            this.label4.Text = "등록사원 폰번호";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_staff_nm
            // 
            this.txt_staff_nm._AutoTab = true;
            this.txt_staff_nm._BorderColor = System.Drawing.Color.PowderBlue;
            this.txt_staff_nm._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txt_staff_nm._WaterMarkColor = System.Drawing.Color.Gray;
            this.txt_staff_nm._WaterMarkText = "";
            this.txt_staff_nm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_staff_nm.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_staff_nm.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.txt_staff_nm.Location = new System.Drawing.Point(516, 125);
            this.txt_staff_nm.MaxLength = 20;
            this.txt_staff_nm.Name = "txt_staff_nm";
            this.txt_staff_nm.ReadOnly = true;
            this.txt_staff_nm.Size = new System.Drawing.Size(94, 21);
            this.txt_staff_nm.TabIndex = 359;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.PowderBlue;
            this.label1.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(448, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 21);
            this.label1.TabIndex = 360;
            this.label1.Text = "등록사원";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.txt입력방식.Location = new System.Drawing.Point(553, 19);
            this.txt입력방식.MaxLength = 20;
            this.txt입력방식.Name = "txt입력방식";
            this.txt입력방식.Size = new System.Drawing.Size(55, 21);
            this.txt입력방식.TabIndex = 358;
            this.txt입력방식.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.PowderBlue;
            this.label10.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label10.Location = new System.Drawing.Point(481, 19);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 21);
            this.label10.TabIndex = 357;
            this.label10.Text = "입력방식";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.txt시간.Location = new System.Drawing.Point(229, 19);
            this.txt시간.MaxLength = 20;
            this.txt시간.Name = "txt시간";
            this.txt시간.Size = new System.Drawing.Size(66, 21);
            this.txt시간.TabIndex = 352;
            this.txt시간.Text = "12:59:46";
            // 
            // cbo전표상태
            // 
            this.cbo전표상태._BorderColor = System.Drawing.Color.PowderBlue;
            this.cbo전표상태._FocusedBackColor = System.Drawing.Color.White;
            this.cbo전표상태.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cbo전표상태.FormattingEnabled = true;
            this.cbo전표상태.Location = new System.Drawing.Point(426, 79);
            this.cbo전표상태.Name = "cbo전표상태";
            this.cbo전표상태.Size = new System.Drawing.Size(135, 25);
            this.cbo전표상태.TabIndex = 350;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label8.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label8.Location = new System.Drawing.Point(353, 79);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 21);
            this.label8.TabIndex = 351;
            this.label8.Text = "전표상태";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbo배송사원
            // 
            this.cbo배송사원._BorderColor = System.Drawing.Color.PowderBlue;
            this.cbo배송사원._FocusedBackColor = System.Drawing.Color.White;
            this.cbo배송사원.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cbo배송사원.FormattingEnabled = true;
            this.cbo배송사원.Location = new System.Drawing.Point(426, 53);
            this.cbo배송사원.Name = "cbo배송사원";
            this.cbo배송사원.Size = new System.Drawing.Size(135, 25);
            this.cbo배송사원.TabIndex = 348;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label6.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(353, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 21);
            this.label6.TabIndex = 349;
            this.label6.Text = "배송사원";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbo담당사원
            // 
            this.cbo담당사원._BorderColor = System.Drawing.Color.PowderBlue;
            this.cbo담당사원._FocusedBackColor = System.Drawing.Color.White;
            this.cbo담당사원.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cbo담당사원.Enabled = false;
            this.cbo담당사원.FormattingEnabled = true;
            this.cbo담당사원.Location = new System.Drawing.Point(689, 17);
            this.cbo담당사원.Name = "cbo담당사원";
            this.cbo담당사원.Size = new System.Drawing.Size(122, 25);
            this.cbo담당사원.TabIndex = 346;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.PowderBlue;
            this.label5.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(616, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 21);
            this.label5.TabIndex = 347;
            this.label5.Text = "담당자";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::MES.Properties.Resources.search2blue;
            this.button1.Location = new System.Drawing.Point(321, 58);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(32, 28);
            this.button1.TabIndex = 345;
            this.button1.Tag = "검색";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.btnCustSrch_Click);
            // 
            // txt_out_date
            // 
            this.txt_out_date._BorderColor = System.Drawing.Color.PowderBlue;
            this.txt_out_date._FocusedBackColor = System.Drawing.Color.White;
            this.txt_out_date.BackColor = System.Drawing.Color.White;
            this.txt_out_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txt_out_date.Location = new System.Drawing.Point(111, 19);
            this.txt_out_date.Name = "txt_out_date";
            this.txt_out_date.Size = new System.Drawing.Size(112, 25);
            this.txt_out_date.TabIndex = 1;
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
            this.txt_cust_nm.Location = new System.Drawing.Point(108, 59);
            this.txt_cust_nm.MaxLength = 20;
            this.txt_cust_nm.Name = "txt_cust_nm";
            this.txt_cust_nm.Size = new System.Drawing.Size(184, 21);
            this.txt_cust_nm.TabIndex = 2;
            // 
            // btnCustSrch
            // 
            this.btnCustSrch.BackColor = System.Drawing.Color.Transparent;
            this.btnCustSrch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCustSrch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCustSrch.FlatAppearance.BorderSize = 0;
            this.btnCustSrch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btnCustSrch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustSrch.Location = new System.Drawing.Point(319, 55);
            this.btnCustSrch.Name = "btnCustSrch";
            this.btnCustSrch.Size = new System.Drawing.Size(33, 33);
            this.btnCustSrch.TabIndex = 3;
            this.btnCustSrch.Tag = "검색";
            this.btnCustSrch.UseVisualStyleBackColor = false;
            this.btnCustSrch.Visible = false;
            this.btnCustSrch.Click += new System.EventHandler(this.btnCustSrch_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.PowderBlue;
            this.label3.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(8, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 21);
            this.label3.TabIndex = 329;
            this.label3.Text = "* 거래처";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_out_cd
            // 
            this.txt_out_cd._AutoTab = true;
            this.txt_out_cd._BorderColor = System.Drawing.Color.PowderBlue;
            this.txt_out_cd._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txt_out_cd._WaterMarkColor = System.Drawing.Color.Gray;
            this.txt_out_cd._WaterMarkText = "";
            this.txt_out_cd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_out_cd.Enabled = false;
            this.txt_out_cd.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_out_cd.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.txt_out_cd.Location = new System.Drawing.Point(426, 19);
            this.txt_out_cd.MaxLength = 20;
            this.txt_out_cd.Name = "txt_out_cd";
            this.txt_out_cd.Size = new System.Drawing.Size(55, 21);
            this.txt_out_cd.TabIndex = 328;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.PowderBlue;
            this.label2.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(353, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 21);
            this.label2.TabIndex = 327;
            this.label2.Text = "배송번호";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_flow_cd
            // 
            this.lbl_flow_cd.BackColor = System.Drawing.Color.PowderBlue;
            this.lbl_flow_cd.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_flow_cd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_flow_cd.Location = new System.Drawing.Point(11, 19);
            this.lbl_flow_cd.Name = "lbl_flow_cd";
            this.lbl_flow_cd.Size = new System.Drawing.Size(100, 23);
            this.lbl_flow_cd.TabIndex = 289;
            this.lbl_flow_cd.Text = "* 배송일자";
            this.lbl_flow_cd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_cust_cd
            // 
            this.txt_cust_cd._AutoTab = true;
            this.txt_cust_cd._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.txt_cust_cd._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txt_cust_cd._WaterMarkColor = System.Drawing.Color.Gray;
            this.txt_cust_cd._WaterMarkText = "";
            this.txt_cust_cd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_cust_cd.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_cust_cd.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.txt_cust_cd.Location = new System.Drawing.Point(250, 63);
            this.txt_cust_cd.MaxLength = 20;
            this.txt_cust_cd.Name = "txt_cust_cd";
            this.txt_cust_cd.Size = new System.Drawing.Size(103, 24);
            this.txt_cust_cd.TabIndex = 342;
            this.txt_cust_cd.Visible = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tab1);
            this.tabControl1.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(385, 681);
            this.tabControl1.TabIndex = 384;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tab1
            // 
            this.tab1.BackColor = System.Drawing.Color.White;
            this.tab1.Controls.Add(this.txt_end_date);
            this.tab1.Controls.Add(this.txt_start_date);
            this.tab1.Controls.Add(this.btnSrch);
            this.tab1.Controls.Add(this.label7);
            this.tab1.Controls.Add(this.tdOutGridTemp);
            this.tab1.Controls.Add(this.tdOutGrid);
            this.tab1.Location = new System.Drawing.Point(4, 30);
            this.tab1.Name = "tab1";
            this.tab1.Padding = new System.Windows.Forms.Padding(3);
            this.tab1.Size = new System.Drawing.Size(377, 647);
            this.tab1.TabIndex = 0;
            this.tab1.Text = "등록된 자료";
            // 
            // txt_end_date
            // 
            this.txt_end_date._BorderColor = System.Drawing.Color.White;
            this.txt_end_date._FocusedBackColor = System.Drawing.Color.White;
            this.txt_end_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txt_end_date.Location = new System.Drawing.Point(175, 8);
            this.txt_end_date.Name = "txt_end_date";
            this.txt_end_date.Size = new System.Drawing.Size(116, 29);
            this.txt_end_date.TabIndex = 350;
            // 
            // txt_start_date
            // 
            this.txt_start_date._BorderColor = System.Drawing.Color.White;
            this.txt_start_date._FocusedBackColor = System.Drawing.Color.White;
            this.txt_start_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txt_start_date.Location = new System.Drawing.Point(6, 8);
            this.txt_start_date.Name = "txt_start_date";
            this.txt_start_date.Size = new System.Drawing.Size(122, 29);
            this.txt_start_date.TabIndex = 349;
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
            this.btnSrch.Location = new System.Drawing.Point(306, 3);
            this.btnSrch.Name = "btnSrch";
            this.btnSrch.Size = new System.Drawing.Size(33, 33);
            this.btnSrch.TabIndex = 347;
            this.btnSrch.Tag = "검색";
            this.btnSrch.UseVisualStyleBackColor = false;
            this.btnSrch.Click += new System.EventHandler(this.btnSerch_Click);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.Location = new System.Drawing.Point(134, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 23);
            this.label7.TabIndex = 344;
            this.label7.Text = "~";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tdOutGridTemp
            // 
            this.tdOutGridTemp._BorderColor = System.Drawing.Color.White;
            this.tdOutGridTemp._DirKey = "R";
            this.tdOutGridTemp._KeyboardCmd = "0";
            this.tdOutGridTemp._KeyInput = "";
            this.tdOutGridTemp._LastCol = -1;
            this.tdOutGridTemp._LastRow = -1;
            this.tdOutGridTemp.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.tdOutGridTemp.AllowUserToAddRows = false;
            this.tdOutGridTemp.AllowUserToDeleteRows = false;
            this.tdOutGridTemp.AllowUserToOrderColumns = true;
            this.tdOutGridTemp.AllowUserToResizeColumns = false;
            this.tdOutGridTemp.AllowUserToResizeRows = false;
            this.tdOutGridTemp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tdOutGridTemp.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.tdOutGridTemp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tdOutGridTemp.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.tdOutGridTemp.ColumnHeadersHeight = 40;
            this.tdOutGridTemp.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.배송배송일,
            this.배송번호,
            this.배송거래처,
            this.배송제품수,
            this.배송거래처코드,
            this.배송창고코드,
            this.배송창고명,
            this.배송자체여부,
            this.배송부가세구분,
            this.담당자,
            this.전표상태,
            this.배송사원,
            this.등록사원,
            this.등록사원폰,
            this.배송전표상태,
            this.싸인,
            this.주문일자});
            this.tdOutGridTemp.EnableHeadersVisualStyles = false;
            this.tdOutGridTemp.GridColor = System.Drawing.Color.PowderBlue;
            this.tdOutGridTemp.Location = new System.Drawing.Point(-1, 43);
            this.tdOutGridTemp.Name = "tdOutGridTemp";
            this.tdOutGridTemp.ReadOnly = true;
            this.tdOutGridTemp.RowHeadersVisible = false;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.Black;
            this.tdOutGridTemp.RowsDefaultCellStyle = dataGridViewCellStyle13;
            this.tdOutGridTemp.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F);
            this.tdOutGridTemp.RowTemplate.Height = 23;
            this.tdOutGridTemp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tdOutGridTemp.Size = new System.Drawing.Size(375, 615);
            this.tdOutGridTemp.TabIndex = 2;
            this.tdOutGridTemp.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tdOutGrid_CellDoubleClick);
            // 
            // 배송배송일
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.배송배송일.DefaultCellStyle = dataGridViewCellStyle9;
            this.배송배송일.HeaderText = "배송일";
            this.배송배송일.Name = "배송배송일";
            this.배송배송일.ReadOnly = true;
            this.배송배송일.Width = 110;
            // 
            // 배송번호
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F);
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black;
            this.배송번호.DefaultCellStyle = dataGridViewCellStyle10;
            this.배송번호.HeaderText = "번호";
            this.배송번호.Name = "배송번호";
            this.배송번호.ReadOnly = true;
            this.배송번호.Width = 50;
            // 
            // 배송거래처
            // 
            this.배송거래처.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.배송거래처.DefaultCellStyle = dataGridViewCellStyle11;
            this.배송거래처.HeaderText = "거래처";
            this.배송거래처.Name = "배송거래처";
            this.배송거래처.ReadOnly = true;
            this.배송거래처.Width = 83;
            // 
            // 배송제품수
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.배송제품수.DefaultCellStyle = dataGridViewCellStyle12;
            this.배송제품수.HeaderText = "제품수";
            this.배송제품수.Name = "배송제품수";
            this.배송제품수.ReadOnly = true;
            this.배송제품수.Visible = false;
            this.배송제품수.Width = 70;
            // 
            // 배송거래처코드
            // 
            this.배송거래처코드.HeaderText = "거래처코드";
            this.배송거래처코드.Name = "배송거래처코드";
            this.배송거래처코드.ReadOnly = true;
            this.배송거래처코드.Visible = false;
            this.배송거래처코드.Width = 140;
            // 
            // 배송창고코드
            // 
            this.배송창고코드.HeaderText = "창고코드";
            this.배송창고코드.Name = "배송창고코드";
            this.배송창고코드.ReadOnly = true;
            this.배송창고코드.Visible = false;
            // 
            // 배송창고명
            // 
            this.배송창고명.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.배송창고명.HeaderText = "창고명";
            this.배송창고명.Name = "배송창고명";
            this.배송창고명.ReadOnly = true;
            this.배송창고명.Visible = false;
            // 
            // 배송자체여부
            // 
            this.배송자체여부.HeaderText = "자체여부";
            this.배송자체여부.Name = "배송자체여부";
            this.배송자체여부.ReadOnly = true;
            this.배송자체여부.Visible = false;
            // 
            // 배송부가세구분
            // 
            this.배송부가세구분.HeaderText = "부가세구분";
            this.배송부가세구분.Name = "배송부가세구분";
            this.배송부가세구분.ReadOnly = true;
            this.배송부가세구분.Visible = false;
            // 
            // 담당자
            // 
            this.담당자.HeaderText = "담당자";
            this.담당자.Name = "담당자";
            this.담당자.ReadOnly = true;
            this.담당자.Visible = false;
            // 
            // 전표상태
            // 
            this.전표상태.HeaderText = "전표상태";
            this.전표상태.Name = "전표상태";
            this.전표상태.ReadOnly = true;
            this.전표상태.Visible = false;
            // 
            // 배송사원
            // 
            this.배송사원.HeaderText = "배송사원";
            this.배송사원.Name = "배송사원";
            this.배송사원.ReadOnly = true;
            this.배송사원.Visible = false;
            // 
            // 등록사원
            // 
            this.등록사원.HeaderText = "등록사원";
            this.등록사원.Name = "등록사원";
            this.등록사원.ReadOnly = true;
            this.등록사원.Visible = false;
            // 
            // 등록사원폰
            // 
            this.등록사원폰.HeaderText = "등록사원폰";
            this.등록사원폰.Name = "등록사원폰";
            this.등록사원폰.ReadOnly = true;
            this.등록사원폰.Visible = false;
            // 
            // 배송전표상태
            // 
            this.배송전표상태.HeaderText = "전표상태";
            this.배송전표상태.Name = "배송전표상태";
            this.배송전표상태.ReadOnly = true;
            // 
            // 싸인
            // 
            this.싸인.HeaderText = "싸인";
            this.싸인.Name = "싸인";
            this.싸인.ReadOnly = true;
            this.싸인.Visible = false;
            // 
            // 주문일자
            // 
            this.주문일자.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.주문일자.HeaderText = "주문일자";
            this.주문일자.Name = "주문일자";
            this.주문일자.ReadOnly = true;
            this.주문일자.Width = 99;
            // 
            // tdOutGrid
            // 
            this.tdOutGrid._BorderColor = System.Drawing.Color.White;
            this.tdOutGrid._DirKey = "R";
            this.tdOutGrid._KeyboardCmd = "0";
            this.tdOutGrid._KeyInput = "";
            this.tdOutGrid._LastCol = -1;
            this.tdOutGrid._LastRow = -1;
            this.tdOutGrid.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.tdOutGrid.AllowUserToAddRows = false;
            this.tdOutGrid.AllowUserToDeleteRows = false;
            this.tdOutGrid.AllowUserToOrderColumns = true;
            this.tdOutGrid.AllowUserToResizeColumns = false;
            this.tdOutGrid.AllowUserToResizeRows = false;
            this.tdOutGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tdOutGrid.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.tdOutGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tdOutGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.tdOutGrid.ColumnHeadersHeight = 40;
            this.tdOutGrid.EnableHeadersVisualStyles = false;
            this.tdOutGrid.GridColor = System.Drawing.Color.PowderBlue;
            this.tdOutGrid.Location = new System.Drawing.Point(2, 0);
            this.tdOutGrid.Name = "tdOutGrid";
            this.tdOutGrid.ReadOnly = true;
            this.tdOutGrid.RowHeadersVisible = false;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F);
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.Black;
            this.tdOutGrid.RowsDefaultCellStyle = dataGridViewCellStyle15;
            this.tdOutGrid.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F);
            this.tdOutGrid.RowTemplate.Height = 23;
            this.tdOutGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tdOutGrid.Size = new System.Drawing.Size(371, 652);
            this.tdOutGrid.TabIndex = 343;
            this.tdOutGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tdOutGrid_CellDoubleClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "LOTNO";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 120;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "입고일자";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 115;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "입고번호";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 115;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "제품명";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 210;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "순서";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Visible = false;
            this.dataGridViewTextBoxColumn9.Width = 60;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "납품처";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Visible = false;
            this.dataGridViewTextBoxColumn10.Width = 190;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.HeaderText = "출고일";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Visible = false;
            this.dataGridViewTextBoxColumn11.Width = 135;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.HeaderText = "비고";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.Visible = false;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.HeaderText = "입고일";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            this.dataGridViewTextBoxColumn13.Visible = false;
            this.dataGridViewTextBoxColumn13.Width = 60;
            // 
            // dataGridViewTextBoxColumn14
            // 
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn14.DefaultCellStyle = dataGridViewCellStyle16;
            this.dataGridViewTextBoxColumn14.HeaderText = "입고No";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            this.dataGridViewTextBoxColumn14.Visible = false;
            this.dataGridViewTextBoxColumn14.Width = 190;
            // 
            // dataGridViewTextBoxColumn15
            // 
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn15.DefaultCellStyle = dataGridViewCellStyle17;
            this.dataGridViewTextBoxColumn15.HeaderText = "원자재명";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            this.dataGridViewTextBoxColumn15.Visible = false;
            this.dataGridViewTextBoxColumn15.Width = 160;
            // 
            // dataGridViewTextBoxColumn16
            // 
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn16.DefaultCellStyle = dataGridViewCellStyle18;
            this.dataGridViewTextBoxColumn16.HeaderText = "비고";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.ReadOnly = true;
            this.dataGridViewTextBoxColumn16.Visible = false;
            this.dataGridViewTextBoxColumn16.Width = 110;
            // 
            // dataGridViewTextBoxColumn17
            // 
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn17.DefaultCellStyle = dataGridViewCellStyle19;
            this.dataGridViewTextBoxColumn17.HeaderText = "입고일";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.ReadOnly = true;
            this.dataGridViewTextBoxColumn17.Visible = false;
            this.dataGridViewTextBoxColumn17.Width = 140;
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dataGridViewTextBoxColumn18.DefaultCellStyle = dataGridViewCellStyle20;
            this.dataGridViewTextBoxColumn18.HeaderText = "입고No";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            this.dataGridViewTextBoxColumn18.ReadOnly = true;
            this.dataGridViewTextBoxColumn18.Visible = false;
            // 
            // dataGridViewTextBoxColumn19
            // 
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn19.DefaultCellStyle = dataGridViewCellStyle21;
            this.dataGridViewTextBoxColumn19.HeaderText = "원자재명";
            this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            this.dataGridViewTextBoxColumn19.ReadOnly = true;
            this.dataGridViewTextBoxColumn19.Visible = false;
            this.dataGridViewTextBoxColumn19.Width = 170;
            // 
            // dataGridViewTextBoxColumn20
            // 
            this.dataGridViewTextBoxColumn20.HeaderText = "비고";
            this.dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
            this.dataGridViewTextBoxColumn20.ReadOnly = true;
            this.dataGridViewTextBoxColumn20.Visible = false;
            this.dataGridViewTextBoxColumn20.Width = 110;
            // 
            // dataGridViewTextBoxColumn21
            // 
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn21.DefaultCellStyle = dataGridViewCellStyle22;
            this.dataGridViewTextBoxColumn21.HeaderText = "비고";
            this.dataGridViewTextBoxColumn21.Name = "dataGridViewTextBoxColumn21";
            this.dataGridViewTextBoxColumn21.ReadOnly = true;
            this.dataGridViewTextBoxColumn21.Visible = false;
            this.dataGridViewTextBoxColumn21.Width = 110;
            // 
            // dataGridViewTextBoxColumn23
            // 
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn23.DefaultCellStyle = dataGridViewCellStyle23;
            this.dataGridViewTextBoxColumn23.HeaderText = "창고코드";
            this.dataGridViewTextBoxColumn23.Name = "dataGridViewTextBoxColumn23";
            this.dataGridViewTextBoxColumn23.ReadOnly = true;
            this.dataGridViewTextBoxColumn23.Visible = false;
            this.dataGridViewTextBoxColumn23.Width = 70;
            // 
            // dataGridViewTextBoxColumn24
            // 
            this.dataGridViewTextBoxColumn24.HeaderText = "창고명";
            this.dataGridViewTextBoxColumn24.Name = "dataGridViewTextBoxColumn24";
            this.dataGridViewTextBoxColumn24.ReadOnly = true;
            this.dataGridViewTextBoxColumn24.Visible = false;
            this.dataGridViewTextBoxColumn24.Width = 140;
            // 
            // dataGridViewTextBoxColumn25
            // 
            this.dataGridViewTextBoxColumn25.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn25.DefaultCellStyle = dataGridViewCellStyle24;
            this.dataGridViewTextBoxColumn25.HeaderText = "창고코드";
            this.dataGridViewTextBoxColumn25.Name = "dataGridViewTextBoxColumn25";
            this.dataGridViewTextBoxColumn25.ReadOnly = true;
            this.dataGridViewTextBoxColumn25.Visible = false;
            // 
            // dataGridViewTextBoxColumn26
            // 
            this.dataGridViewTextBoxColumn26.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle25.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F);
            dataGridViewCellStyle25.SelectionBackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle25.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewTextBoxColumn26.DefaultCellStyle = dataGridViewCellStyle25;
            this.dataGridViewTextBoxColumn26.HeaderText = "창고명";
            this.dataGridViewTextBoxColumn26.Name = "dataGridViewTextBoxColumn26";
            this.dataGridViewTextBoxColumn26.ReadOnly = true;
            this.dataGridViewTextBoxColumn26.Visible = false;
            // 
            // dataGridViewTextBoxColumn27
            // 
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dataGridViewTextBoxColumn27.DefaultCellStyle = dataGridViewCellStyle26;
            this.dataGridViewTextBoxColumn27.HeaderText = "출고일";
            this.dataGridViewTextBoxColumn27.Name = "dataGridViewTextBoxColumn27";
            this.dataGridViewTextBoxColumn27.ReadOnly = true;
            this.dataGridViewTextBoxColumn27.Width = 110;
            // 
            // dataGridViewTextBoxColumn28
            // 
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn28.DefaultCellStyle = dataGridViewCellStyle27;
            this.dataGridViewTextBoxColumn28.HeaderText = "번호";
            this.dataGridViewTextBoxColumn28.Name = "dataGridViewTextBoxColumn28";
            this.dataGridViewTextBoxColumn28.ReadOnly = true;
            this.dataGridViewTextBoxColumn28.Width = 50;
            // 
            // dataGridViewTextBoxColumn29
            // 
            this.dataGridViewTextBoxColumn29.HeaderText = "납품처";
            this.dataGridViewTextBoxColumn29.Name = "dataGridViewTextBoxColumn29";
            this.dataGridViewTextBoxColumn29.ReadOnly = true;
            this.dataGridViewTextBoxColumn29.Visible = false;
            this.dataGridViewTextBoxColumn29.Width = 140;
            // 
            // dataGridViewTextBoxColumn30
            // 
            dataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn30.DefaultCellStyle = dataGridViewCellStyle28;
            this.dataGridViewTextBoxColumn30.HeaderText = "제품수";
            this.dataGridViewTextBoxColumn30.Name = "dataGridViewTextBoxColumn30";
            this.dataGridViewTextBoxColumn30.ReadOnly = true;
            this.dataGridViewTextBoxColumn30.Visible = false;
            this.dataGridViewTextBoxColumn30.Width = 70;
            // 
            // dataGridViewTextBoxColumn31
            // 
            this.dataGridViewTextBoxColumn31.HeaderText = "납품처코드";
            this.dataGridViewTextBoxColumn31.Name = "dataGridViewTextBoxColumn31";
            this.dataGridViewTextBoxColumn31.ReadOnly = true;
            this.dataGridViewTextBoxColumn31.Visible = false;
            this.dataGridViewTextBoxColumn31.Width = 140;
            // 
            // dataGridViewTextBoxColumn32
            // 
            this.dataGridViewTextBoxColumn32.HeaderText = "창고코드";
            this.dataGridViewTextBoxColumn32.Name = "dataGridViewTextBoxColumn32";
            this.dataGridViewTextBoxColumn32.ReadOnly = true;
            this.dataGridViewTextBoxColumn32.Visible = false;
            // 
            // dataGridViewTextBoxColumn33
            // 
            this.dataGridViewTextBoxColumn33.HeaderText = "창고명";
            this.dataGridViewTextBoxColumn33.Name = "dataGridViewTextBoxColumn33";
            this.dataGridViewTextBoxColumn33.ReadOnly = true;
            this.dataGridViewTextBoxColumn33.Visible = false;
            // 
            // SELF_YN
            // 
            this.SELF_YN.HeaderText = "자체여부";
            this.SELF_YN.Name = "SELF_YN";
            this.SELF_YN.ReadOnly = true;
            this.SELF_YN.Visible = false;
            // 
            // td_VAT_CD
            // 
            this.td_VAT_CD.HeaderText = "부가세구분";
            this.td_VAT_CD.Name = "td_VAT_CD";
            this.td_VAT_CD.ReadOnly = true;
            this.td_VAT_CD.Visible = false;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "출고일";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Width = 110;
            // 
            // Column1
            // 
            dataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle29;
            this.Column1.HeaderText = "번호";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 50;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "납품처";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 140;
            // 
            // Column2
            // 
            dataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle30;
            this.Column2.HeaderText = "제품수";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 70;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "납품처코드";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Visible = false;
            // 
            // frm배송등록
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 714);
            this.Controls.Add(this.pnl_main);
            this.Controls.Add(this.pnl_top);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frm배송등록";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frm배송등록";
            this.Load += new System.EventHandler(this.frm배송등록_Load);
            this.Enter += new System.EventHandler(this.frm배송등록_Enter);
            this.pnl_top.ResumeLayout(false);
            this.pnl_top.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.pnl_main.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.pnl_그리드.Panel1.ResumeLayout(false);
            this.pnl_그리드.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnl_그리드)).EndInit();
            this.pnl_그리드.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.itemOutGrid)).EndInit();
            this.pnl_itemOutGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv주문등록)).EndInit();
            this.pnl_itemStockGrid.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tab1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tdOutGridTemp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tdOutGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_top;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel pnl_main;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private Controls.conTextBox lbl_out_gbn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn21;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn23;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn24;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn25;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn26;
        private Controls.conTextBox txt_vat_cd;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn27;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn28;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn29;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn30;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn31;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn32;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn33;
        private System.Windows.Forms.DataGridViewTextBoxColumn SELF_YN;
        private System.Windows.Forms.DataGridViewTextBoxColumn td_VAT_CD;
        private Controls.conTextBox txt_jang_cd;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer pnl_그리드;
        private System.Windows.Forms.Label lbl제품내역;
        private System.Windows.Forms.Button btn_minus;
        private System.Windows.Forms.Panel pnl_itemStockGrid;
        private System.Windows.Forms.Label lbl제품제고;
        private Controls.conDataGridView dgv주문등록;
        private System.Windows.Forms.Panel pnl_itemOutGrid;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private Controls.conTextBox txt_cust_nm;
        private System.Windows.Forms.Button btnCustSrch;
        private System.Windows.Forms.Label label3;
        private Controls.conTextBox txt_out_cd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_flow_cd;
        private Controls.conTextBox txt_cust_cd;
        private Controls.conDateTimePicker txt_out_date;
        private Controls.conMaskedTextBox conMaskedTextBox1;
        private System.Windows.Forms.Button button1;
        private Controls.conTextBox txt시간;
        private Controls.conComboBox cbo전표상태;
        private System.Windows.Forms.Label label8;
        private Controls.conComboBox cbo배송사원;
        private System.Windows.Forms.Label label6;
        private Controls.conComboBox cbo담당사원;
        private System.Windows.Forms.Label label5;
        private Controls.conTextBox txt입력방식;
        private System.Windows.Forms.Label label10;
        private Controls.conTextBox txt_staff_phone;
        private System.Windows.Forms.Label label4;
        private Controls.conTextBox txt_staff_nm;
        private System.Windows.Forms.Label label1;
        private Controls.conTextBox txt비고;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.PictureBox pic;
        private Controls.conDataGridView itemOutGrid;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewTextBoxColumn40;
        private System.Windows.Forms.DataGridViewTextBoxColumn O_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn O_ITEM_NM;
        private System.Windows.Forms.DataGridViewTextBoxColumn O_ITEM_CD;
        private System.Windows.Forms.DataGridViewTextBoxColumn O_SPEC;
        private System.Windows.Forms.DataGridViewTextBoxColumn O_UNIT_NM;
        private System.Windows.Forms.DataGridViewTextBoxColumn O_UNIT_CD;
        private System.Windows.Forms.DataGridViewTextBoxColumn TOTAL_AMT;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRICE;
        private System.Windows.Forms.DataGridViewTextBoxColumn TOTAL_MONEY;
        private CalendarColumn 최종매출일;
        private System.Windows.Forms.DataGridViewComboBoxColumn 매출구분;
        private System.Windows.Forms.DataGridViewTextBoxColumn O_WORK_YN;
        private System.Windows.Forms.DataGridViewTextBoxColumn 비고;
        private System.Windows.Forms.Button btn싸인;
        private System.Windows.Forms.OpenFileDialog ofd;
        private Controls.conTextBox txt_plan_cd;
        private System.Windows.Forms.Button btn배송완료;
        private System.Windows.Forms.Label label9;
        private Controls.conDateTimePicker dtp앤드;
        private Controls.conDateTimePicker dtp스타트;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tab1;
        private Controls.conDataGridView tdOutGridTemp;
        private Controls.conDataGridView tdOutGrid;
        private System.Windows.Forms.Button btnSrch;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn 배송배송일;
        private System.Windows.Forms.DataGridViewTextBoxColumn 배송번호;
        private System.Windows.Forms.DataGridViewTextBoxColumn 배송거래처;
        private System.Windows.Forms.DataGridViewTextBoxColumn 배송제품수;
        private System.Windows.Forms.DataGridViewTextBoxColumn 배송거래처코드;
        private System.Windows.Forms.DataGridViewTextBoxColumn 배송창고코드;
        private System.Windows.Forms.DataGridViewTextBoxColumn 배송창고명;
        private System.Windows.Forms.DataGridViewTextBoxColumn 배송자체여부;
        private System.Windows.Forms.DataGridViewTextBoxColumn 배송부가세구분;
        private System.Windows.Forms.DataGridViewTextBoxColumn 담당자;
        private System.Windows.Forms.DataGridViewTextBoxColumn 전표상태;
        private System.Windows.Forms.DataGridViewTextBoxColumn 배송사원;
        private System.Windows.Forms.DataGridViewTextBoxColumn 등록사원;
        private System.Windows.Forms.DataGridViewTextBoxColumn 등록사원폰;
        private System.Windows.Forms.DataGridViewTextBoxColumn 배송전표상태;
        private System.Windows.Forms.DataGridViewTextBoxColumn 싸인;
        private System.Windows.Forms.DataGridViewTextBoxColumn 주문일자;
        private Controls.conDateTimePicker txt_start_date;
        private Controls.conDateTimePicker txt_end_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn H주문일자;
        private System.Windows.Forms.DataGridViewTextBoxColumn H주문번호;
        private System.Windows.Forms.DataGridViewTextBoxColumn H항목순번;
        private System.Windows.Forms.DataGridViewTextBoxColumn H주문시간;
        private System.Windows.Forms.DataGridViewTextBoxColumn H거래처;
        private System.Windows.Forms.DataGridViewTextBoxColumn H거래처코드;
        private System.Windows.Forms.DataGridViewTextBoxColumn H담당사원;
        private System.Windows.Forms.DataGridViewTextBoxColumn H담당사원코드;
        private System.Windows.Forms.DataGridViewTextBoxColumn H부가세;
        private System.Windows.Forms.DataGridViewTextBoxColumn H전표상태;
        private System.Windows.Forms.DataGridViewTextBoxColumn H비고;
    }
}