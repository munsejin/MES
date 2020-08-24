namespace MES.H20_생산관리
{
    partial class frm원자재이력관리
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm원자재이력관리));
            this.panel1 = new System.Windows.Forms.Panel();
            this.itemGrid = new MES.Controls.myDataGridView();
            this.RAW_CD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RAW_NM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SPEC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.매출처 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ORD_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ORD_NUM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ORD_QTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ORD_PRICE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ORD_AMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.주문사원 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.배송일자 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DELIVERY_QTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.배송완료일자 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.배송사원 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SALE_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SALE_NUM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SALE_QTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SALE_PRICE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SALE_AMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.매출담당사원 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RETURN_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RETURN_NUM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RETURN_QTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RETURN_PRICE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RETURN_AMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.반품담당사원 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.회수일자 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.회수사원 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.완료일자 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.완료사원 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbl_title = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtp엔드 = new MES.Controls.conDateTimePicker();
            this.dtp스타트 = new MES.Controls.conDateTimePicker();
            this.btn_close = new System.Windows.Forms.Button();
            this.btnSrch = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_원자재검색 = new MES.Controls.conTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemGrid)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.itemGrid);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 33);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1360, 673);
            this.panel1.TabIndex = 20;
            // 
            // itemGrid
            // 
            this.itemGrid.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.itemGrid.AllowUserToAddRows = false;
            this.itemGrid.AllowUserToDeleteRows = false;
            this.itemGrid.AllowUserToOrderColumns = true;
            this.itemGrid.AllowUserToResizeColumns = false;
            this.itemGrid.AllowUserToResizeRows = false;
            this.itemGrid.BackgroundColor = System.Drawing.Color.White;
            this.itemGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.PowderBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.itemGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.itemGrid.ColumnHeadersHeight = 40;
            this.itemGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RAW_CD,
            this.RAW_NM,
            this.SPEC,
            this.매출처,
            this.ORD_DATE,
            this.ORD_NUM,
            this.ORD_QTY,
            this.ORD_PRICE,
            this.ORD_AMT,
            this.주문사원,
            this.배송일자,
            this.DELIVERY_QTY,
            this.배송완료일자,
            this.배송사원,
            this.SALE_DATE,
            this.SALE_NUM,
            this.SALE_QTY,
            this.SALE_PRICE,
            this.SALE_AMT,
            this.매출담당사원,
            this.RETURN_DATE,
            this.RETURN_NUM,
            this.RETURN_QTY,
            this.RETURN_PRICE,
            this.RETURN_AMT,
            this.반품담당사원,
            this.회수일자,
            this.회수사원,
            this.완료일자,
            this.완료사원});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.itemGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.itemGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemGrid.EnableHeadersVisualStyles = false;
            this.itemGrid.GridColor = System.Drawing.Color.PowderBlue;
            this.itemGrid.Location = new System.Drawing.Point(0, 0);
            this.itemGrid.Name = "itemGrid";
            this.itemGrid.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.itemGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.itemGrid.RowHeadersVisible = false;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.itemGrid.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.itemGrid.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F);
            this.itemGrid.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.itemGrid.RowTemplate.Height = 30;
            this.itemGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.itemGrid.Size = new System.Drawing.Size(1360, 673);
            this.itemGrid.TabIndex = 380;
            // 
            // RAW_CD
            // 
            this.RAW_CD.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.RAW_CD.Frozen = true;
            this.RAW_CD.HeaderText = "원자재코드";
            this.RAW_CD.Name = "RAW_CD";
            this.RAW_CD.ReadOnly = true;
            this.RAW_CD.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.RAW_CD.Width = 115;
            // 
            // RAW_NM
            // 
            this.RAW_NM.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.RAW_NM.Frozen = true;
            this.RAW_NM.HeaderText = "원자재명";
            this.RAW_NM.Name = "RAW_NM";
            this.RAW_NM.ReadOnly = true;
            this.RAW_NM.Width = 99;
            // 
            // SPEC
            // 
            this.SPEC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.SPEC.Frozen = true;
            this.SPEC.HeaderText = "규격";
            this.SPEC.Name = "SPEC";
            this.SPEC.ReadOnly = true;
            this.SPEC.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.SPEC.Width = 67;
            // 
            // 매출처
            // 
            this.매출처.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.매출처.Frozen = true;
            this.매출처.HeaderText = "매출처";
            this.매출처.Name = "매출처";
            this.매출처.ReadOnly = true;
            this.매출처.Width = 83;
            // 
            // ORD_DATE
            // 
            this.ORD_DATE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ORD_DATE.HeaderText = "주문일자";
            this.ORD_DATE.Name = "ORD_DATE";
            this.ORD_DATE.ReadOnly = true;
            this.ORD_DATE.Width = 99;
            // 
            // ORD_NUM
            // 
            this.ORD_NUM.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ORD_NUM.HeaderText = "주문번호";
            this.ORD_NUM.Name = "ORD_NUM";
            this.ORD_NUM.ReadOnly = true;
            this.ORD_NUM.Width = 99;
            // 
            // ORD_QTY
            // 
            this.ORD_QTY.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ORD_QTY.HeaderText = "주문수량";
            this.ORD_QTY.Name = "ORD_QTY";
            this.ORD_QTY.ReadOnly = true;
            this.ORD_QTY.Width = 99;
            // 
            // ORD_PRICE
            // 
            this.ORD_PRICE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ORD_PRICE.HeaderText = "주문단가";
            this.ORD_PRICE.Name = "ORD_PRICE";
            this.ORD_PRICE.ReadOnly = true;
            this.ORD_PRICE.Visible = false;
            this.ORD_PRICE.Width = 99;
            // 
            // ORD_AMT
            // 
            this.ORD_AMT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ORD_AMT.HeaderText = "주문금액";
            this.ORD_AMT.Name = "ORD_AMT";
            this.ORD_AMT.ReadOnly = true;
            this.ORD_AMT.Width = 99;
            // 
            // 주문사원
            // 
            this.주문사원.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.주문사원.HeaderText = "주문사원";
            this.주문사원.Name = "주문사원";
            this.주문사원.ReadOnly = true;
            this.주문사원.Width = 99;
            // 
            // 배송일자
            // 
            this.배송일자.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.배송일자.HeaderText = "배송일자";
            this.배송일자.Name = "배송일자";
            this.배송일자.ReadOnly = true;
            this.배송일자.Width = 99;
            // 
            // DELIVERY_QTY
            // 
            this.DELIVERY_QTY.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.DELIVERY_QTY.HeaderText = "배송수량";
            this.DELIVERY_QTY.Name = "DELIVERY_QTY";
            this.DELIVERY_QTY.ReadOnly = true;
            this.DELIVERY_QTY.Width = 99;
            // 
            // 배송완료일자
            // 
            this.배송완료일자.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.배송완료일자.HeaderText = "배송완료일자";
            this.배송완료일자.Name = "배송완료일자";
            this.배송완료일자.ReadOnly = true;
            this.배송완료일자.Width = 131;
            // 
            // 배송사원
            // 
            this.배송사원.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.배송사원.HeaderText = "배송사원";
            this.배송사원.Name = "배송사원";
            this.배송사원.ReadOnly = true;
            this.배송사원.Width = 99;
            // 
            // SALE_DATE
            // 
            this.SALE_DATE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.SALE_DATE.HeaderText = "매출일자";
            this.SALE_DATE.Name = "SALE_DATE";
            this.SALE_DATE.ReadOnly = true;
            this.SALE_DATE.Width = 99;
            // 
            // SALE_NUM
            // 
            this.SALE_NUM.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.SALE_NUM.HeaderText = "매출번호";
            this.SALE_NUM.Name = "SALE_NUM";
            this.SALE_NUM.ReadOnly = true;
            this.SALE_NUM.Width = 99;
            // 
            // SALE_QTY
            // 
            this.SALE_QTY.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.SALE_QTY.HeaderText = "매출수량";
            this.SALE_QTY.Name = "SALE_QTY";
            this.SALE_QTY.ReadOnly = true;
            this.SALE_QTY.Width = 99;
            // 
            // SALE_PRICE
            // 
            this.SALE_PRICE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.SALE_PRICE.HeaderText = "매출단가";
            this.SALE_PRICE.Name = "SALE_PRICE";
            this.SALE_PRICE.ReadOnly = true;
            this.SALE_PRICE.Visible = false;
            this.SALE_PRICE.Width = 99;
            // 
            // SALE_AMT
            // 
            this.SALE_AMT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.SALE_AMT.HeaderText = "매출금액";
            this.SALE_AMT.Name = "SALE_AMT";
            this.SALE_AMT.ReadOnly = true;
            this.SALE_AMT.Visible = false;
            this.SALE_AMT.Width = 99;
            // 
            // 매출담당사원
            // 
            this.매출담당사원.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.매출담당사원.HeaderText = "매출담당사원";
            this.매출담당사원.Name = "매출담당사원";
            this.매출담당사원.ReadOnly = true;
            this.매출담당사원.Width = 131;
            // 
            // RETURN_DATE
            // 
            this.RETURN_DATE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.RETURN_DATE.HeaderText = "반품일자";
            this.RETURN_DATE.Name = "RETURN_DATE";
            this.RETURN_DATE.ReadOnly = true;
            this.RETURN_DATE.Width = 99;
            // 
            // RETURN_NUM
            // 
            this.RETURN_NUM.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.RETURN_NUM.HeaderText = "반품번호";
            this.RETURN_NUM.Name = "RETURN_NUM";
            this.RETURN_NUM.ReadOnly = true;
            this.RETURN_NUM.Width = 99;
            // 
            // RETURN_QTY
            // 
            this.RETURN_QTY.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.RETURN_QTY.HeaderText = "반품수량";
            this.RETURN_QTY.Name = "RETURN_QTY";
            this.RETURN_QTY.ReadOnly = true;
            this.RETURN_QTY.Width = 99;
            // 
            // RETURN_PRICE
            // 
            this.RETURN_PRICE.HeaderText = "반품단가";
            this.RETURN_PRICE.Name = "RETURN_PRICE";
            this.RETURN_PRICE.ReadOnly = true;
            this.RETURN_PRICE.Visible = false;
            // 
            // RETURN_AMT
            // 
            this.RETURN_AMT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.RETURN_AMT.HeaderText = "반품금액";
            this.RETURN_AMT.Name = "RETURN_AMT";
            this.RETURN_AMT.ReadOnly = true;
            this.RETURN_AMT.Visible = false;
            this.RETURN_AMT.Width = 99;
            // 
            // 반품담당사원
            // 
            this.반품담당사원.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.반품담당사원.HeaderText = "반품담당사원";
            this.반품담당사원.Name = "반품담당사원";
            this.반품담당사원.ReadOnly = true;
            this.반품담당사원.Width = 5;
            // 
            // 회수일자
            // 
            this.회수일자.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.회수일자.HeaderText = "회수일자";
            this.회수일자.Name = "회수일자";
            this.회수일자.ReadOnly = true;
            this.회수일자.Width = 99;
            // 
            // 회수사원
            // 
            this.회수사원.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.회수사원.HeaderText = "회수사원";
            this.회수사원.Name = "회수사원";
            this.회수사원.ReadOnly = true;
            this.회수사원.Width = 99;
            // 
            // 완료일자
            // 
            this.완료일자.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.완료일자.HeaderText = "완료일자";
            this.완료일자.Name = "완료일자";
            this.완료일자.ReadOnly = true;
            this.완료일자.Width = 99;
            // 
            // 완료사원
            // 
            this.완료사원.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.완료사원.HeaderText = "완료사원";
            this.완료사원.Name = "완료사원";
            this.완료사원.ReadOnly = true;
            this.완료사원.Width = 99;
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.lbl_title.Location = new System.Drawing.Point(9, -2); //new System.Drawing.Point(10, 5);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(167, 30);
            this.lbl_title.TabIndex = 93;
            this.lbl_title.Text = "원자재이력관리";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.PaleTurquoise;
            this.panel2.Controls.Add(this.dtp엔드);
            this.panel2.Controls.Add(this.dtp스타트);
            this.panel2.Controls.Add(this.btn_close);
            this.panel2.Controls.Add(this.btnSrch);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txt_원자재검색);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.lbl_title);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1360, 33);
            this.panel2.TabIndex = 19;
            // 
            // dtp엔드
            // 
            this.dtp엔드._BorderColor = System.Drawing.Color.DarkTurquoise;
            this.dtp엔드._FocusedBackColor = System.Drawing.Color.White;
            this.dtp엔드.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp엔드.Location = new System.Drawing.Point(444, 7);
            this.dtp엔드.Name = "dtp엔드";
            this.dtp엔드.Size = new System.Drawing.Size(99, 21);
            this.dtp엔드.TabIndex = 394;
            // 
            // dtp스타트
            // 
            this.dtp스타트._BorderColor = System.Drawing.Color.DarkTurquoise;
            this.dtp스타트._FocusedBackColor = System.Drawing.Color.White;
            this.dtp스타트.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp스타트.Location = new System.Drawing.Point(310, 6);
            this.dtp스타트.Name = "dtp스타트";
            this.dtp스타트.Size = new System.Drawing.Size(99, 21);
            this.dtp스타트.TabIndex = 393;
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
            this.btn_close.Location = new System.Drawing.Point(1291, 2);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(65, 29);
            this.btn_close.TabIndex = 392;
            this.btn_close.Tag = "종료";
            this.btn_close.Text = "닫기";
            this.btn_close.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_close.UseVisualStyleBackColor = false;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
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
            this.btnSrch.Location = new System.Drawing.Point(818, 2);
            this.btnSrch.Name = "btnSrch";
            this.btnSrch.Size = new System.Drawing.Size(33, 30);
            this.btnSrch.TabIndex = 391;
            this.btnSrch.Tag = "검색";
            this.btnSrch.UseVisualStyleBackColor = false;
            this.btnSrch.Click += new System.EventHandler(this.btnSrch_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(415, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 23);
            this.label3.TabIndex = 390;
            this.label3.Text = "~";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(551, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 23);
            this.label1.TabIndex = 388;
            this.label1.Text = "원자재명";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_원자재검색
            // 
            this.txt_원자재검색._AutoTab = true;
            this.txt_원자재검색._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.txt_원자재검색._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txt_원자재검색._WaterMarkColor = System.Drawing.Color.Gray;
            this.txt_원자재검색._WaterMarkText = "";
            this.txt_원자재검색.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_원자재검색.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_원자재검색.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.txt_원자재검색.Location = new System.Drawing.Point(641, 5);
            this.txt_원자재검색.MaxLength = 20;
            this.txt_원자재검색.Name = "txt_원자재검색";
            this.txt_원자재검색.Size = new System.Drawing.Size(171, 22);
            this.txt_원자재검색.TabIndex = 385;
            this.txt_원자재검색.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_원자재검색_KeyDown);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(222, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 23);
            this.label2.TabIndex = 387;
            this.label2.Text = "조회일자";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frm원자재이력관리
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1360, 706);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "frm원자재이력관리";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frm원자재이력관리";
            this.Load += new System.EventHandler(this.frm원자재이력관리_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.itemGrid)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSrch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private Controls.conTextBox txt_원자재검색;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.DataGridView itemGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn RAW_CD;
        private System.Windows.Forms.DataGridViewTextBoxColumn RAW_NM;
        private System.Windows.Forms.DataGridViewTextBoxColumn SPEC;
        private System.Windows.Forms.DataGridViewTextBoxColumn 매출처;
        private System.Windows.Forms.DataGridViewTextBoxColumn ORD_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn ORD_NUM;
        private System.Windows.Forms.DataGridViewTextBoxColumn ORD_QTY;
        private System.Windows.Forms.DataGridViewTextBoxColumn ORD_PRICE;
        private System.Windows.Forms.DataGridViewTextBoxColumn ORD_AMT;
        private System.Windows.Forms.DataGridViewTextBoxColumn 주문사원;
        private System.Windows.Forms.DataGridViewTextBoxColumn 배송일자;
        private System.Windows.Forms.DataGridViewTextBoxColumn DELIVERY_QTY;
        private System.Windows.Forms.DataGridViewTextBoxColumn 배송완료일자;
        private System.Windows.Forms.DataGridViewTextBoxColumn 배송사원;
        private System.Windows.Forms.DataGridViewTextBoxColumn SALE_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn SALE_NUM;
        private System.Windows.Forms.DataGridViewTextBoxColumn SALE_QTY;
        private System.Windows.Forms.DataGridViewTextBoxColumn SALE_PRICE;
        private System.Windows.Forms.DataGridViewTextBoxColumn SALE_AMT;
        private System.Windows.Forms.DataGridViewTextBoxColumn 매출담당사원;
        private System.Windows.Forms.DataGridViewTextBoxColumn RETURN_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn RETURN_NUM;
        private System.Windows.Forms.DataGridViewTextBoxColumn RETURN_QTY;
        private System.Windows.Forms.DataGridViewTextBoxColumn RETURN_PRICE;
        private System.Windows.Forms.DataGridViewTextBoxColumn RETURN_AMT;
        private System.Windows.Forms.DataGridViewTextBoxColumn 반품담당사원;
        private System.Windows.Forms.DataGridViewTextBoxColumn 회수일자;
        private System.Windows.Forms.DataGridViewTextBoxColumn 회수사원;
        private System.Windows.Forms.DataGridViewTextBoxColumn 완료일자;
        private System.Windows.Forms.DataGridViewTextBoxColumn 완료사원;
        private Controls.conDateTimePicker dtp엔드;
        private Controls.conDateTimePicker dtp스타트;
    }
}