namespace MES.S10_SALES
{
    partial class frm활동보고서
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm활동보고서));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHead = new System.Windows.Forms.Panel();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lbl_title = new System.Windows.Forms.Label();
            this.chkA4Sero = new MES.Controls.conCheckBox();
            this.pnlSubFrm = new System.Windows.Forms.Panel();
            this.btn제품별 = new System.Windows.Forms.Button();
            this.btn매출처별 = new System.Windows.Forms.Button();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlData2 = new System.Windows.Forms.Panel();
            this.GridRecord2 = new MES.Controls.conDataGridView();
            this.P_PRODUCT_NM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P_PRODUCT_GUBUN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P_UNIT_NM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P_PAST_AMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P_TODAY_INPUT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P_TODAY_OUTPUT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P_TODAY_SALES = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P_TODAY_SALES_BACK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P_CURR_AMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P_SUPPLY_MONEY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P_TAX_MONEY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P_TOTAL_MONEY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlData1 = new System.Windows.Forms.Panel();
            this.GridRecord = new MES.Controls.conDataGridView();
            this.C_SALES_DATE = new MES.Controls.DataGridViewTextBoxColumnEx();
            this.C_CUST_NM = new MES.Controls.DataGridViewTextBoxColumnEx();
            this.C_PRODUCT_NM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C_UNION_CD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C_PRODUCT_GUBUN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C_TAX_NM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C_VAT_NM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C_SUPPLY_MONEY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C_TAX_MONEY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C_TOTAL_MONEY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C_SALES_MONEY = new MES.Controls.DataGridViewTextBoxColumnEx();
            this.C_SOO_MONEY = new MES.Controls.DataGridViewTextBoxColumnEx();
            this.C_DC_MONEY = new MES.Controls.DataGridViewTextBoxColumnEx();
            this.C_BALANCE = new MES.Controls.DataGridViewTextBoxColumnEx();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.lbl검색일자 = new System.Windows.Forms.Label();
            this.dtpDate = new MES.Controls.conDateTimePicker();
            this.btnSrch = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbl월계 = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.lbl할인 = new MES.Controls.conLabel();
            this.lbl수금 = new MES.Controls.conLabel();
            this.lbl매출 = new MES.Controls.conLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblMsg = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumnEx2 = new MES.Controls.DataGridViewTextBoxColumnEx();
            this.dataGridViewTextBoxColumnEx1 = new MES.Controls.DataGridViewTextBoxColumnEx();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlHead.SuspendLayout();
            this.pnlSubFrm.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlData2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridRecord2)).BeginInit();
            this.pnlData1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridRecord)).BeginInit();
            this.pnlMenu.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHead
            // 
            this.pnlHead.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlHead.Controls.Add(this.btnPrint);
            this.pnlHead.Controls.Add(this.btnClose);
            this.pnlHead.Controls.Add(this.lbl_title);
            this.pnlHead.Controls.Add(this.chkA4Sero);
            this.pnlHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHead.ForeColor = System.Drawing.Color.White;
            this.pnlHead.Location = new System.Drawing.Point(0, 0);
            this.pnlHead.Name = "pnlHead";
            this.pnlHead.Size = new System.Drawing.Size(1360, 32);
            this.pnlHead.TabIndex = 125;
            this.pnlHead.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlHead_Paint);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.BackColor = System.Drawing.Color.Transparent;
            this.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPrint.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnPrint.Image = global::MES.Properties.Resources.newPrintBtn;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPrint.Location = new System.Drawing.Point(1204, 2);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(74, 29);
            this.btnPrint.TabIndex = 358;
            this.btnPrint.Tag = "출력";
            this.btnPrint.Text = "출력";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Visible = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
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
            this.btnClose.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnClose.Image = global::MES.Properties.Resources.newnewCloseBtn;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(1279, 1);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(70, 29);
            this.btnClose.TabIndex = 22;
            this.btnClose.Tag = "종료";
            this.btnClose.Text = "닫기";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.Font = new System.Drawing.Font("SpoqaHanSans-Bold", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.lbl_title.Location = new System.Drawing.Point(9, -2); //new System.Drawing.Point(10, 1);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(114, 31);
            this.lbl_title.TabIndex = 21;
            this.lbl_title.Text = "활동보고서";
            // 
            // chkA4Sero
            // 
            this.chkA4Sero.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkA4Sero.AutoSize = true;
            this.chkA4Sero.ForeColor = System.Drawing.Color.Black;
            this.chkA4Sero.Location = new System.Drawing.Point(1119, 10);
            this.chkA4Sero.Name = "chkA4Sero";
            this.chkA4Sero.Size = new System.Drawing.Size(66, 16);
            this.chkA4Sero.TabIndex = 20;
            this.chkA4Sero.Text = "A4 세로";
            this.chkA4Sero.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkA4Sero.UseVisualStyleBackColor = true;
            this.chkA4Sero.Visible = false;
            // 
            // pnlSubFrm
            // 
            this.pnlSubFrm.BackColor = System.Drawing.Color.White;
            this.pnlSubFrm.Controls.Add(this.btn제품별);
            this.pnlSubFrm.Controls.Add(this.btn매출처별);
            this.pnlSubFrm.Controls.Add(this.pnlContent);
            this.pnlSubFrm.Controls.Add(this.pnlMenu);
            this.pnlSubFrm.Controls.Add(this.panel1);
            this.pnlSubFrm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSubFrm.Location = new System.Drawing.Point(0, 0);
            this.pnlSubFrm.Name = "pnlSubFrm";
            this.pnlSubFrm.Size = new System.Drawing.Size(1360, 714);
            this.pnlSubFrm.TabIndex = 126;
            // 
            // btn제품별
            // 
            this.btn제품별.BackColor = System.Drawing.Color.White;
            this.btn제품별.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btn제품별.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn제품별.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F);
            this.btn제품별.Location = new System.Drawing.Point(144, 39);
            this.btn제품별.Name = "btn제품별";
            this.btn제품별.Size = new System.Drawing.Size(135, 31);
            this.btn제품별.TabIndex = 2;
            this.btn제품별.Tag = "2";
            this.btn제품별.Text = "제품별";
            this.btn제품별.UseVisualStyleBackColor = false;
            this.btn제품별.Click += new System.EventHandler(this.tBtn_Click);
            // 
            // btn매출처별
            // 
            this.btn매출처별.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.btn매출처별.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btn매출처별.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn매출처별.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F);
            this.btn매출처별.ForeColor = System.Drawing.Color.White;
            this.btn매출처별.Location = new System.Drawing.Point(11, 39);
            this.btn매출처별.Name = "btn매출처별";
            this.btn매출처별.Size = new System.Drawing.Size(135, 31);
            this.btn매출처별.TabIndex = 1;
            this.btn매출처별.Tag = "1";
            this.btn매출처별.Text = "매출처별";
            this.btn매출처별.UseVisualStyleBackColor = false;
            this.btn매출처별.Click += new System.EventHandler(this.tBtn_Click);
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.White;
            this.pnlContent.Controls.Add(this.pnlData2);
            this.pnlContent.Controls.Add(this.pnlData1);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.pnlContent.Location = new System.Drawing.Point(0, 70);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1360, 644);
            this.pnlContent.TabIndex = 141;
            this.pnlContent.Tag = "1";
            // 
            // pnlData2
            // 
            this.pnlData2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlData2.Controls.Add(this.GridRecord2);
            this.pnlData2.Location = new System.Drawing.Point(445, 108);
            this.pnlData2.Name = "pnlData2";
            this.pnlData2.Size = new System.Drawing.Size(722, 269);
            this.pnlData2.TabIndex = 3;
            // 
            // GridRecord2
            // 
            this.GridRecord2._BorderColor = System.Drawing.Color.White;
            this.GridRecord2._DirKey = "R";
            this.GridRecord2._KeyboardCmd = "0";
            this.GridRecord2._KeyInput = "";
            this.GridRecord2._LastCol = -1;
            this.GridRecord2._LastRow = -1;
            this.GridRecord2.AllowUserToAddRows = false;
            this.GridRecord2.AllowUserToDeleteRows = false;
            this.GridRecord2.AllowUserToResizeRows = false;
            this.GridRecord2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridRecord2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.GridRecord2.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.GridRecord2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GridRecord2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.GridRecord2.ColumnHeadersHeight = 30;
            this.GridRecord2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.GridRecord2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.P_PRODUCT_NM,
            this.P_PRODUCT_GUBUN,
            this.P_UNIT_NM,
            this.P_PAST_AMT,
            this.P_TODAY_INPUT,
            this.P_TODAY_OUTPUT,
            this.P_TODAY_SALES,
            this.P_TODAY_SALES_BACK,
            this.P_CURR_AMT,
            this.P_SUPPLY_MONEY,
            this.P_TAX_MONEY,
            this.P_TOTAL_MONEY});
            this.GridRecord2.EnableHeadersVisualStyles = false;
            this.GridRecord2.GridColor = System.Drawing.Color.Black;
            this.GridRecord2.Location = new System.Drawing.Point(3, 3);
            this.GridRecord2.Name = "GridRecord2";
            this.GridRecord2.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridRecord2.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.GridRecord2.RowHeadersVisible = false;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black;
            this.GridRecord2.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.GridRecord2.RowTemplate.Height = 23;
            this.GridRecord2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridRecord2.Size = new System.Drawing.Size(704, 269);
            this.GridRecord2.TabIndex = 5;
            // 
            // P_PRODUCT_NM
            // 
            this.P_PRODUCT_NM.FillWeight = 58F;
            this.P_PRODUCT_NM.Frozen = true;
            this.P_PRODUCT_NM.HeaderText = "상품명";
            this.P_PRODUCT_NM.MinimumWidth = 58;
            this.P_PRODUCT_NM.Name = "P_PRODUCT_NM";
            this.P_PRODUCT_NM.ReadOnly = true;
            this.P_PRODUCT_NM.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.P_PRODUCT_NM.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.P_PRODUCT_NM.Width = 58;
            // 
            // P_PRODUCT_GUBUN
            // 
            this.P_PRODUCT_GUBUN.FillWeight = 50F;
            this.P_PRODUCT_GUBUN.Frozen = true;
            this.P_PRODUCT_GUBUN.HeaderText = "구분";
            this.P_PRODUCT_GUBUN.MinimumWidth = 50;
            this.P_PRODUCT_GUBUN.Name = "P_PRODUCT_GUBUN";
            this.P_PRODUCT_GUBUN.ReadOnly = true;
            this.P_PRODUCT_GUBUN.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.P_PRODUCT_GUBUN.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.P_PRODUCT_GUBUN.Width = 50;
            // 
            // P_UNIT_NM
            // 
            this.P_UNIT_NM.FillWeight = 50F;
            this.P_UNIT_NM.Frozen = true;
            this.P_UNIT_NM.HeaderText = "단위";
            this.P_UNIT_NM.MinimumWidth = 50;
            this.P_UNIT_NM.Name = "P_UNIT_NM";
            this.P_UNIT_NM.ReadOnly = true;
            this.P_UNIT_NM.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.P_UNIT_NM.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.P_UNIT_NM.Width = 50;
            // 
            // P_PAST_AMT
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Khaki;
            this.P_PAST_AMT.DefaultCellStyle = dataGridViewCellStyle2;
            this.P_PAST_AMT.FillWeight = 72F;
            this.P_PAST_AMT.HeaderText = "당일재고";
            this.P_PAST_AMT.MinimumWidth = 72;
            this.P_PAST_AMT.Name = "P_PAST_AMT";
            this.P_PAST_AMT.ReadOnly = true;
            this.P_PAST_AMT.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.P_PAST_AMT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.P_PAST_AMT.Width = 72;
            // 
            // P_TODAY_INPUT
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.P_TODAY_INPUT.DefaultCellStyle = dataGridViewCellStyle3;
            this.P_TODAY_INPUT.FillWeight = 72F;
            this.P_TODAY_INPUT.HeaderText = "금일입고";
            this.P_TODAY_INPUT.MinimumWidth = 72;
            this.P_TODAY_INPUT.Name = "P_TODAY_INPUT";
            this.P_TODAY_INPUT.ReadOnly = true;
            this.P_TODAY_INPUT.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.P_TODAY_INPUT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.P_TODAY_INPUT.Width = 72;
            // 
            // P_TODAY_OUTPUT
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.P_TODAY_OUTPUT.DefaultCellStyle = dataGridViewCellStyle4;
            this.P_TODAY_OUTPUT.HeaderText = "금일출고";
            this.P_TODAY_OUTPUT.MinimumWidth = 100;
            this.P_TODAY_OUTPUT.Name = "P_TODAY_OUTPUT";
            this.P_TODAY_OUTPUT.ReadOnly = true;
            this.P_TODAY_OUTPUT.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.P_TODAY_OUTPUT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.P_TODAY_OUTPUT.Visible = false;
            // 
            // P_TODAY_SALES
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.P_TODAY_SALES.DefaultCellStyle = dataGridViewCellStyle5;
            this.P_TODAY_SALES.FillWeight = 72F;
            this.P_TODAY_SALES.HeaderText = "금일판매";
            this.P_TODAY_SALES.MinimumWidth = 72;
            this.P_TODAY_SALES.Name = "P_TODAY_SALES";
            this.P_TODAY_SALES.ReadOnly = true;
            this.P_TODAY_SALES.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.P_TODAY_SALES.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.P_TODAY_SALES.Width = 72;
            // 
            // P_TODAY_SALES_BACK
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.P_TODAY_SALES_BACK.DefaultCellStyle = dataGridViewCellStyle6;
            this.P_TODAY_SALES_BACK.HeaderText = "금일정상반품";
            this.P_TODAY_SALES_BACK.MinimumWidth = 100;
            this.P_TODAY_SALES_BACK.Name = "P_TODAY_SALES_BACK";
            this.P_TODAY_SALES_BACK.ReadOnly = true;
            this.P_TODAY_SALES_BACK.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.P_TODAY_SALES_BACK.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.P_TODAY_SALES_BACK.Visible = false;
            // 
            // P_CURR_AMT
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Khaki;
            this.P_CURR_AMT.DefaultCellStyle = dataGridViewCellStyle7;
            this.P_CURR_AMT.FillWeight = 58F;
            this.P_CURR_AMT.HeaderText = "현재고";
            this.P_CURR_AMT.MinimumWidth = 58;
            this.P_CURR_AMT.Name = "P_CURR_AMT";
            this.P_CURR_AMT.ReadOnly = true;
            this.P_CURR_AMT.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.P_CURR_AMT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.P_CURR_AMT.Width = 58;
            // 
            // P_SUPPLY_MONEY
            // 
            this.P_SUPPLY_MONEY.FillWeight = 58F;
            this.P_SUPPLY_MONEY.HeaderText = "공급가";
            this.P_SUPPLY_MONEY.MinimumWidth = 58;
            this.P_SUPPLY_MONEY.Name = "P_SUPPLY_MONEY";
            this.P_SUPPLY_MONEY.ReadOnly = true;
            this.P_SUPPLY_MONEY.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.P_SUPPLY_MONEY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.P_SUPPLY_MONEY.Width = 58;
            // 
            // P_TAX_MONEY
            // 
            this.P_TAX_MONEY.FillWeight = 58F;
            this.P_TAX_MONEY.HeaderText = "부가세";
            this.P_TAX_MONEY.MinimumWidth = 58;
            this.P_TAX_MONEY.Name = "P_TAX_MONEY";
            this.P_TAX_MONEY.ReadOnly = true;
            this.P_TAX_MONEY.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.P_TAX_MONEY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.P_TAX_MONEY.Width = 58;
            // 
            // P_TOTAL_MONEY
            // 
            this.P_TOTAL_MONEY.FillWeight = 58F;
            this.P_TOTAL_MONEY.HeaderText = "합계액";
            this.P_TOTAL_MONEY.MinimumWidth = 58;
            this.P_TOTAL_MONEY.Name = "P_TOTAL_MONEY";
            this.P_TOTAL_MONEY.ReadOnly = true;
            this.P_TOTAL_MONEY.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.P_TOTAL_MONEY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.P_TOTAL_MONEY.Width = 58;
            // 
            // pnlData1
            // 
            this.pnlData1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlData1.Controls.Add(this.GridRecord);
            this.pnlData1.Location = new System.Drawing.Point(12, 6);
            this.pnlData1.Name = "pnlData1";
            this.pnlData1.Size = new System.Drawing.Size(1336, 296);
            this.pnlData1.TabIndex = 0;
            // 
            // GridRecord
            // 
            this.GridRecord._BorderColor = System.Drawing.Color.White;
            this.GridRecord._DirKey = "R";
            this.GridRecord._KeyboardCmd = "0";
            this.GridRecord._KeyInput = "";
            this.GridRecord._LastCol = -1;
            this.GridRecord._LastRow = -1;
            this.GridRecord.AllowUserToAddRows = false;
            this.GridRecord.AllowUserToDeleteRows = false;
            this.GridRecord.AllowUserToResizeRows = false;
            this.GridRecord.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridRecord.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridRecord.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.GridRecord.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GridRecord.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.GridRecord.ColumnHeadersHeight = 30;
            this.GridRecord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.GridRecord.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.C_SALES_DATE,
            this.C_CUST_NM,
            this.C_PRODUCT_NM,
            this.C_UNION_CD,
            this.C_PRODUCT_GUBUN,
            this.C_TAX_NM,
            this.C_VAT_NM,
            this.C_SUPPLY_MONEY,
            this.C_TAX_MONEY,
            this.C_TOTAL_MONEY,
            this.C_SALES_MONEY,
            this.C_SOO_MONEY,
            this.C_DC_MONEY,
            this.C_BALANCE});
            this.GridRecord.EnableHeadersVisualStyles = false;
            this.GridRecord.Location = new System.Drawing.Point(0, 0);
            this.GridRecord.Name = "GridRecord";
            this.GridRecord.ReadOnly = true;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridRecord.RowHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.GridRecord.RowHeadersVisible = false;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.Color.Black;
            this.GridRecord.RowsDefaultCellStyle = dataGridViewCellStyle17;
            this.GridRecord.RowTemplate.Height = 23;
            this.GridRecord.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridRecord.Size = new System.Drawing.Size(1336, 296);
            this.GridRecord.TabIndex = 0;
            // 
            // C_SALES_DATE
            // 
            this.C_SALES_DATE.FillWeight = 72F;
            this.C_SALES_DATE.HeaderText = "등록일자";
            this.C_SALES_DATE.MinimumWidth = 72;
            this.C_SALES_DATE.Name = "C_SALES_DATE";
            this.C_SALES_DATE.ReadOnly = true;
            this.C_SALES_DATE.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // C_CUST_NM
            // 
            this.C_CUST_NM.FillWeight = 75F;
            this.C_CUST_NM.HeaderText = "거래처명";
            this.C_CUST_NM.MinimumWidth = 72;
            this.C_CUST_NM.Name = "C_CUST_NM";
            this.C_CUST_NM.ReadOnly = true;
            this.C_CUST_NM.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // C_PRODUCT_NM
            // 
            this.C_PRODUCT_NM.FillWeight = 600F;
            this.C_PRODUCT_NM.HeaderText = "제품명";
            this.C_PRODUCT_NM.MinimumWidth = 58;
            this.C_PRODUCT_NM.Name = "C_PRODUCT_NM";
            this.C_PRODUCT_NM.ReadOnly = true;
            this.C_PRODUCT_NM.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.C_PRODUCT_NM.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // C_UNION_CD
            // 
            this.C_UNION_CD.HeaderText = "개체번호";
            this.C_UNION_CD.MinimumWidth = 100;
            this.C_UNION_CD.Name = "C_UNION_CD";
            this.C_UNION_CD.ReadOnly = true;
            this.C_UNION_CD.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.C_UNION_CD.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.C_UNION_CD.Visible = false;
            // 
            // C_PRODUCT_GUBUN
            // 
            this.C_PRODUCT_GUBUN.HeaderText = "품목구분";
            this.C_PRODUCT_GUBUN.MinimumWidth = 100;
            this.C_PRODUCT_GUBUN.Name = "C_PRODUCT_GUBUN";
            this.C_PRODUCT_GUBUN.ReadOnly = true;
            this.C_PRODUCT_GUBUN.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.C_PRODUCT_GUBUN.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.C_PRODUCT_GUBUN.Visible = false;
            // 
            // C_TAX_NM
            // 
            this.C_TAX_NM.HeaderText = "세금구분";
            this.C_TAX_NM.MinimumWidth = 100;
            this.C_TAX_NM.Name = "C_TAX_NM";
            this.C_TAX_NM.ReadOnly = true;
            this.C_TAX_NM.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.C_TAX_NM.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.C_TAX_NM.Visible = false;
            // 
            // C_VAT_NM
            // 
            this.C_VAT_NM.HeaderText = "과세구분";
            this.C_VAT_NM.MinimumWidth = 100;
            this.C_VAT_NM.Name = "C_VAT_NM";
            this.C_VAT_NM.ReadOnly = true;
            this.C_VAT_NM.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.C_VAT_NM.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.C_VAT_NM.Visible = false;
            // 
            // C_SUPPLY_MONEY
            // 
            this.C_SUPPLY_MONEY.HeaderText = "공급가";
            this.C_SUPPLY_MONEY.MinimumWidth = 58;
            this.C_SUPPLY_MONEY.Name = "C_SUPPLY_MONEY";
            this.C_SUPPLY_MONEY.ReadOnly = true;
            this.C_SUPPLY_MONEY.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.C_SUPPLY_MONEY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // C_TAX_MONEY
            // 
            this.C_TAX_MONEY.FillWeight = 96F;
            this.C_TAX_MONEY.HeaderText = "부가세";
            this.C_TAX_MONEY.MinimumWidth = 58;
            this.C_TAX_MONEY.Name = "C_TAX_MONEY";
            this.C_TAX_MONEY.ReadOnly = true;
            this.C_TAX_MONEY.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.C_TAX_MONEY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // C_TOTAL_MONEY
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.C_TOTAL_MONEY.DefaultCellStyle = dataGridViewCellStyle11;
            this.C_TOTAL_MONEY.FillWeight = 77F;
            this.C_TOTAL_MONEY.HeaderText = "합계액";
            this.C_TOTAL_MONEY.MinimumWidth = 58;
            this.C_TOTAL_MONEY.Name = "C_TOTAL_MONEY";
            this.C_TOTAL_MONEY.ReadOnly = true;
            this.C_TOTAL_MONEY.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.C_TOTAL_MONEY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // C_SALES_MONEY
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.C_SALES_MONEY.DefaultCellStyle = dataGridViewCellStyle12;
            this.C_SALES_MONEY.FillWeight = 79F;
            this.C_SALES_MONEY.HeaderText = "매출";
            this.C_SALES_MONEY.MinimumWidth = 50;
            this.C_SALES_MONEY.Name = "C_SALES_MONEY";
            this.C_SALES_MONEY.ReadOnly = true;
            this.C_SALES_MONEY.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // C_SOO_MONEY
            // 
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.C_SOO_MONEY.DefaultCellStyle = dataGridViewCellStyle13;
            this.C_SOO_MONEY.FillWeight = 80F;
            this.C_SOO_MONEY.HeaderText = "수금";
            this.C_SOO_MONEY.MinimumWidth = 50;
            this.C_SOO_MONEY.Name = "C_SOO_MONEY";
            this.C_SOO_MONEY.ReadOnly = true;
            this.C_SOO_MONEY.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // C_DC_MONEY
            // 
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.C_DC_MONEY.DefaultCellStyle = dataGridViewCellStyle14;
            this.C_DC_MONEY.FillWeight = 77F;
            this.C_DC_MONEY.HeaderText = "할인";
            this.C_DC_MONEY.MinimumWidth = 50;
            this.C_DC_MONEY.Name = "C_DC_MONEY";
            this.C_DC_MONEY.ReadOnly = true;
            this.C_DC_MONEY.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // C_BALANCE
            // 
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.C_BALANCE.DefaultCellStyle = dataGridViewCellStyle15;
            this.C_BALANCE.FillWeight = 79F;
            this.C_BALANCE.HeaderText = "잔고";
            this.C_BALANCE.MinimumWidth = 50;
            this.C_BALANCE.Name = "C_BALANCE";
            this.C_BALANCE.ReadOnly = true;
            this.C_BALANCE.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.White;
            this.pnlMenu.Controls.Add(this.lbl검색일자);
            this.pnlMenu.Controls.Add(this.dtpDate);
            this.pnlMenu.Controls.Add(this.btnSrch);
            this.pnlMenu.Controls.Add(this.panel3);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMenu.Location = new System.Drawing.Point(0, 32);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(1360, 38);
            this.pnlMenu.TabIndex = 140;
            // 
            // lbl검색일자
            // 
            this.lbl검색일자.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.lbl검색일자.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl검색일자.ForeColor = System.Drawing.Color.White;
            this.lbl검색일자.Location = new System.Drawing.Point(285, 7);
            this.lbl검색일자.Name = "lbl검색일자";
            this.lbl검색일자.Size = new System.Drawing.Size(81, 29);
            this.lbl검색일자.TabIndex = 342;
            this.lbl검색일자.Text = "검색일자";
            this.lbl검색일자.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpDate
            // 
            this.dtpDate._BorderColor = System.Drawing.Color.DarkGreen;
            this.dtpDate._FocusedBackColor = System.Drawing.Color.White;
            this.dtpDate.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F);
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(371, 7);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(117, 29);
            this.dtpDate.TabIndex = 341;
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
            this.btnSrch.Location = new System.Drawing.Point(492, 5);
            this.btnSrch.Name = "btnSrch";
            this.btnSrch.Size = new System.Drawing.Size(33, 33);
            this.btnSrch.TabIndex = 340;
            this.btnSrch.Tag = "검색";
            this.btnSrch.UseVisualStyleBackColor = false;
            this.btnSrch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.lbl월계);
            this.panel3.Controls.Add(this.lbl3);
            this.panel3.Controls.Add(this.lbl2);
            this.panel3.Controls.Add(this.lbl1);
            this.panel3.Controls.Add(this.lbl할인);
            this.panel3.Controls.Add(this.lbl수금);
            this.panel3.Controls.Add(this.lbl매출);
            this.panel3.Location = new System.Drawing.Point(737, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(623, 38);
            this.panel3.TabIndex = 96;
            // 
            // lbl월계
            // 
            this.lbl월계.AutoSize = true;
            this.lbl월계.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lbl월계.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.lbl월계.Location = new System.Drawing.Point(48, 4);
            this.lbl월계.Name = "lbl월계";
            this.lbl월계.Size = new System.Drawing.Size(64, 25);
            this.lbl월계.TabIndex = 184;
            this.lbl월계.Text = "[ 월계 ]";
            this.lbl월계.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl월계.Visible = false;
            // 
            // lbl3
            // 
            this.lbl3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.lbl3.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F);
            this.lbl3.ForeColor = System.Drawing.Color.White;
            this.lbl3.Location = new System.Drawing.Point(436, 9);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(53, 21);
            this.lbl3.TabIndex = 181;
            this.lbl3.Text = "할인";
            this.lbl3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl3.Visible = false;
            // 
            // lbl2
            // 
            this.lbl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.lbl2.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F);
            this.lbl2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbl2.Location = new System.Drawing.Point(277, 9);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(53, 21);
            this.lbl2.TabIndex = 182;
            this.lbl2.Text = "수금";
            this.lbl2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl2.Visible = false;
            // 
            // lbl1
            // 
            this.lbl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.lbl1.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F);
            this.lbl1.ForeColor = System.Drawing.Color.White;
            this.lbl1.Location = new System.Drawing.Point(118, 9);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(53, 21);
            this.lbl1.TabIndex = 183;
            this.lbl1.Text = "매출";
            this.lbl1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl1.Visible = false;
            // 
            // lbl할인
            // 
            this.lbl할인._BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(89)))), ((int)(((byte)(80)))));
            this.lbl할인.BackColor = System.Drawing.Color.White;
            this.lbl할인.Enabled = false;
            this.lbl할인.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl할인.Location = new System.Drawing.Point(489, 9);
            this.lbl할인.Name = "lbl할인";
            this.lbl할인.Size = new System.Drawing.Size(100, 21);
            this.lbl할인.TabIndex = 178;
            this.lbl할인.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl할인.Visible = false;
            // 
            // lbl수금
            // 
            this.lbl수금._BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(89)))), ((int)(((byte)(80)))));
            this.lbl수금.BackColor = System.Drawing.Color.White;
            this.lbl수금.Enabled = false;
            this.lbl수금.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl수금.Location = new System.Drawing.Point(330, 9);
            this.lbl수금.Name = "lbl수금";
            this.lbl수금.Size = new System.Drawing.Size(100, 21);
            this.lbl수금.TabIndex = 179;
            this.lbl수금.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl수금.Visible = false;
            // 
            // lbl매출
            // 
            this.lbl매출._BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(89)))), ((int)(((byte)(80)))));
            this.lbl매출.BackColor = System.Drawing.Color.White;
            this.lbl매출.Enabled = false;
            this.lbl매출.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl매출.Location = new System.Drawing.Point(171, 9);
            this.lbl매출.Name = "lbl매출";
            this.lbl매출.Size = new System.Drawing.Size(100, 21);
            this.lbl매출.TabIndex = 180;
            this.lbl매출.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl매출.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1360, 32);
            this.panel1.TabIndex = 139;
            // 
            // lblMsg
            // 
            this.lblMsg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblMsg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 45F);
            this.lblMsg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.lblMsg.Location = new System.Drawing.Point(467, 268);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(400, 100);
            this.lblMsg.TabIndex = 172;
            this.lblMsg.Text = "Searching....";
            this.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMsg.Visible = false;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle18;
            this.dataGridViewTextBoxColumn4.Frozen = true;
            this.dataGridViewTextBoxColumn4.HeaderText = "구분";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumnEx2
            // 
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumnEx2.DefaultCellStyle = dataGridViewCellStyle19;
            this.dataGridViewTextBoxColumnEx2.Frozen = true;
            this.dataGridViewTextBoxColumnEx2.HeaderText = "구분";
            this.dataGridViewTextBoxColumnEx2.Name = "dataGridViewTextBoxColumnEx2";
            this.dataGridViewTextBoxColumnEx2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumnEx2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumnEx1
            // 
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumnEx1.DefaultCellStyle = dataGridViewCellStyle20;
            this.dataGridViewTextBoxColumnEx1.Frozen = true;
            this.dataGridViewTextBoxColumnEx1.HeaderText = "관리";
            this.dataGridViewTextBoxColumnEx1.Name = "dataGridViewTextBoxColumnEx1";
            this.dataGridViewTextBoxColumnEx1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumnEx1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.Frozen = true;
            this.dataGridViewTextBoxColumn2.HeaderText = "거래처명";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 130;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle21;
            this.dataGridViewTextBoxColumn1.Frozen = true;
            this.dataGridViewTextBoxColumn1.HeaderText = "등록일시";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle22;
            this.dataGridViewTextBoxColumn3.Frozen = true;
            this.dataGridViewTextBoxColumn3.HeaderText = "관리";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // frm활동보고서
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1360, 714);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.pnlHead);
            this.Controls.Add(this.pnlSubFrm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frm활동보고서";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frm활동보고서";
            this.Load += new System.EventHandler(this.frm활동보고서_Load);
            this.pnlHead.ResumeLayout(false);
            this.pnlHead.PerformLayout();
            this.pnlSubFrm.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.pnlData2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridRecord2)).EndInit();
            this.pnlData1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridRecord)).EndInit();
            this.pnlMenu.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHead;
        private System.Windows.Forms.Panel pnlSubFrm;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Button btn제품별;
        private System.Windows.Forms.Button btn매출처별;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlData1;
        private Controls.conCheckBox chkA4Sero;
        private System.Windows.Forms.Label lbl월계;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label lbl1;
        private Controls.conLabel lbl할인;
        private Controls.conLabel lbl수금;
        private Controls.conLabel lbl매출;
        private Controls.conDataGridView GridRecord;
        private System.Windows.Forms.Panel pnlData2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private Controls.DataGridViewTextBoxColumnEx dataGridViewTextBoxColumnEx2;
        private Controls.DataGridViewTextBoxColumnEx dataGridViewTextBoxColumnEx1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private Controls.conDataGridView GridRecord2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Button btnSrch;
        private System.Windows.Forms.Label lbl검색일자;
        private Controls.conDateTimePicker dtpDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn P_PRODUCT_NM;
        private System.Windows.Forms.DataGridViewTextBoxColumn P_PRODUCT_GUBUN;
        private System.Windows.Forms.DataGridViewTextBoxColumn P_UNIT_NM;
        private System.Windows.Forms.DataGridViewTextBoxColumn P_PAST_AMT;
        private System.Windows.Forms.DataGridViewTextBoxColumn P_TODAY_INPUT;
        private System.Windows.Forms.DataGridViewTextBoxColumn P_TODAY_OUTPUT;
        private System.Windows.Forms.DataGridViewTextBoxColumn P_TODAY_SALES;
        private System.Windows.Forms.DataGridViewTextBoxColumn P_TODAY_SALES_BACK;
        private System.Windows.Forms.DataGridViewTextBoxColumn P_CURR_AMT;
        private System.Windows.Forms.DataGridViewTextBoxColumn P_SUPPLY_MONEY;
        private System.Windows.Forms.DataGridViewTextBoxColumn P_TAX_MONEY;
        private System.Windows.Forms.DataGridViewTextBoxColumn P_TOTAL_MONEY;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnPrint;
        private Controls.DataGridViewTextBoxColumnEx C_SALES_DATE;
        private Controls.DataGridViewTextBoxColumnEx C_CUST_NM;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_PRODUCT_NM;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_UNION_CD;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_PRODUCT_GUBUN;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_TAX_NM;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_VAT_NM;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_SUPPLY_MONEY;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_TAX_MONEY;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_TOTAL_MONEY;
        private Controls.DataGridViewTextBoxColumnEx C_SALES_MONEY;
        private Controls.DataGridViewTextBoxColumnEx C_SOO_MONEY;
        private Controls.DataGridViewTextBoxColumnEx C_DC_MONEY;
        private Controls.DataGridViewTextBoxColumnEx C_BALANCE;
    }
}