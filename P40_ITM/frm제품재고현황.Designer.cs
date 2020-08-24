namespace MES.P40_ITM
{
    partial class frm제품재고현황
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm제품재고현황));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.clear = new System.Windows.Forms.Button();
            this.txt_bal_stock = new System.Windows.Forms.TextBox();
            this.txt_basic_stock = new System.Windows.Forms.TextBox();
            this.txt_prop_stock = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.txt_item_Cd = new System.Windows.Forms.TextBox();
            this.lbl_title = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btn_stock_no = new System.Windows.Forms.RadioButton();
            this.btn_stock_ok = new System.Windows.Forms.RadioButton();
            this.dataItemGrid = new MES.Controls.myDataGridView();
            this.ITEM_CD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ITEM_NM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SPEC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PROP_STOCK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.POOR_AMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BASIC_STOCK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BAL_STOCK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_srch = new MES.Controls.conTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSrch = new System.Windows.Forms.Button();
            this.lbl_item_nm = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.datadetaiIGrid = new MES.Controls.myDataGridView();
            this.RAW_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LOT_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INPUT_CNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OUTPUT_CNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TOTAL_CNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.불량수 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ETC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataItemGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datadetaiIGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.clear);
            this.panel2.Controls.Add(this.txt_bal_stock);
            this.panel2.Controls.Add(this.txt_basic_stock);
            this.panel2.Controls.Add(this.txt_prop_stock);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.txt_item_Cd);
            this.panel2.Controls.Add(this.lbl_title);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.panel2.ForeColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1360, 33);
            this.panel2.TabIndex = 14;
            // 
            // clear
            // 
            this.clear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.clear.BackColor = System.Drawing.Color.Transparent;
            this.clear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.clear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.clear.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.clear.FlatAppearance.BorderSize = 0;
            this.clear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clear.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.clear.ForeColor = System.Drawing.Color.White;
            this.clear.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.clear.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.clear.Location = new System.Drawing.Point(699, 2);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(65, 29);
            this.clear.TabIndex = 389;
            this.clear.Tag = "종료";
            this.clear.Text = "새로고침";
            this.clear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.clear.UseVisualStyleBackColor = false;
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // txt_bal_stock
            // 
            this.txt_bal_stock.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_bal_stock.ForeColor = System.Drawing.Color.White;
            this.txt_bal_stock.Location = new System.Drawing.Point(880, 7);
            this.txt_bal_stock.Name = "txt_bal_stock";
            this.txt_bal_stock.Size = new System.Drawing.Size(100, 29);
            this.txt_bal_stock.TabIndex = 388;
            this.txt_bal_stock.Visible = false;
            // 
            // txt_basic_stock
            // 
            this.txt_basic_stock.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_basic_stock.ForeColor = System.Drawing.Color.White;
            this.txt_basic_stock.Location = new System.Drawing.Point(774, 7);
            this.txt_basic_stock.Name = "txt_basic_stock";
            this.txt_basic_stock.Size = new System.Drawing.Size(100, 29);
            this.txt_basic_stock.TabIndex = 387;
            this.txt_basic_stock.Visible = false;
            // 
            // txt_prop_stock
            // 
            this.txt_prop_stock.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_prop_stock.ForeColor = System.Drawing.Color.White;
            this.txt_prop_stock.Location = new System.Drawing.Point(668, 7);
            this.txt_prop_stock.Name = "txt_prop_stock";
            this.txt_prop_stock.Size = new System.Drawing.Size(100, 29);
            this.txt_prop_stock.TabIndex = 386;
            this.txt_prop_stock.Visible = false;
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
            this.btnSave.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.btnSave.Image = global::MES.Properties.Resources.newSaveBtn;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSave.Location = new System.Drawing.Point(1182, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(68, 29);
            this.btnSave.TabIndex = 9;
            this.btnSave.Tag = "저장";
            this.btnSave.Text = "저장";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txt_item_Cd
            // 
            this.txt_item_Cd.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_item_Cd.ForeColor = System.Drawing.Color.White;
            this.txt_item_Cd.Location = new System.Drawing.Point(532, 7);
            this.txt_item_Cd.Name = "txt_item_Cd";
            this.txt_item_Cd.Size = new System.Drawing.Size(100, 29);
            this.txt_item_Cd.TabIndex = 383;
            this.txt_item_Cd.Visible = false;
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.Font = new System.Drawing.Font("SpoqaHanSans-Bold", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.lbl_title.Location = new System.Drawing.Point(9, -2); //new System.Drawing.Point(6, 3);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(102, 28);
            this.lbl_title.TabIndex = 93;
            this.lbl_title.Text = "완제품재고";
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
            this.btnClose.Location = new System.Drawing.Point(1289, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(69, 29);
            this.btnClose.TabIndex = 10;
            this.btnClose.Tag = "종료";
            this.btnClose.Text = "닫기";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.panel1.Location = new System.Drawing.Point(0, 33);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1360, 681);
            this.panel1.TabIndex = 15;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btn_stock_no);
            this.splitContainer1.Panel1.Controls.Add(this.btn_stock_ok);
            this.splitContainer1.Panel1.Controls.Add(this.dataItemGrid);
            this.splitContainer1.Panel1.Controls.Add(this.txt_srch);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.btnSrch);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lbl_item_nm);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.datadetaiIGrid);
            this.splitContainer1.Size = new System.Drawing.Size(1360, 681);
            this.splitContainer1.SplitterDistance = 364;
            this.splitContainer1.TabIndex = 387;
            // 
            // btn_stock_no
            // 
            this.btn_stock_no.AutoSize = true;
            this.btn_stock_no.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_stock_no.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_stock_no.Location = new System.Drawing.Point(105, 12);
            this.btn_stock_no.Name = "btn_stock_no";
            this.btn_stock_no.Size = new System.Drawing.Size(89, 26);
            this.btn_stock_no.TabIndex = 386;
            this.btn_stock_no.TabStop = true;
            this.btn_stock_no.Text = "재고 없음";
            this.btn_stock_no.UseVisualStyleBackColor = true;
            // 
            // btn_stock_ok
            // 
            this.btn_stock_ok.AutoSize = true;
            this.btn_stock_ok.Checked = true;
            this.btn_stock_ok.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_stock_ok.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_stock_ok.Location = new System.Drawing.Point(11, 12);
            this.btn_stock_ok.Name = "btn_stock_ok";
            this.btn_stock_ok.Size = new System.Drawing.Size(89, 26);
            this.btn_stock_ok.TabIndex = 385;
            this.btn_stock_ok.TabStop = true;
            this.btn_stock_ok.Text = "재고 있음";
            this.btn_stock_ok.UseVisualStyleBackColor = true;
            // 
            // dataItemGrid
            // 
            this.dataItemGrid.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.dataItemGrid.AllowUserToAddRows = false;
            this.dataItemGrid.AllowUserToDeleteRows = false;
            this.dataItemGrid.AllowUserToResizeColumns = false;
            this.dataItemGrid.AllowUserToResizeRows = false;
            this.dataItemGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataItemGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataItemGrid.BackgroundColor = System.Drawing.Color.White;
            this.dataItemGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataItemGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataItemGrid.ColumnHeadersHeight = 35;
            this.dataItemGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataItemGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ITEM_CD,
            this.ITEM_NM,
            this.SPEC,
            this.PROP_STOCK,
            this.POOR_AMT,
            this.BASIC_STOCK,
            this.BAL_STOCK});
            this.dataItemGrid.EnableHeadersVisualStyles = false;
            this.dataItemGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.dataItemGrid.Location = new System.Drawing.Point(3, 50);
            this.dataItemGrid.Name = "dataItemGrid";
            this.dataItemGrid.ReadOnly = true;
            this.dataItemGrid.RowHeadersVisible = false;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.dataItemGrid.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dataItemGrid.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 12F);
            this.dataItemGrid.RowTemplate.Height = 30;
            this.dataItemGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataItemGrid.Size = new System.Drawing.Size(1354, 311);
            this.dataItemGrid.TabIndex = 386;
            this.dataItemGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataItemGrid_CellDoubleClick);
            // 
            // ITEM_CD
            // 
            this.ITEM_CD.FillWeight = 72F;
            this.ITEM_CD.HeaderText = "제품코드";
            this.ITEM_CD.MinimumWidth = 72;
            this.ITEM_CD.Name = "ITEM_CD";
            this.ITEM_CD.ReadOnly = true;
            this.ITEM_CD.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ITEM_CD.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ITEM_NM
            // 
            this.ITEM_NM.FillWeight = 77F;
            this.ITEM_NM.HeaderText = "제품명";
            this.ITEM_NM.MinimumWidth = 58;
            this.ITEM_NM.Name = "ITEM_NM";
            this.ITEM_NM.ReadOnly = true;
            this.ITEM_NM.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ITEM_NM.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // SPEC
            // 
            this.SPEC.FillWeight = 596F;
            this.SPEC.HeaderText = "규격";
            this.SPEC.MinimumWidth = 50;
            this.SPEC.Name = "SPEC";
            this.SPEC.ReadOnly = true;
            this.SPEC.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SPEC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PROP_STOCK
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.PROP_STOCK.DefaultCellStyle = dataGridViewCellStyle2;
            this.PROP_STOCK.FillWeight = 224F;
            this.PROP_STOCK.HeaderText = "적정재고량";
            this.PROP_STOCK.MinimumWidth = 86;
            this.PROP_STOCK.Name = "PROP_STOCK";
            this.PROP_STOCK.ReadOnly = true;
            this.PROP_STOCK.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PROP_STOCK.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // POOR_AMT
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.POOR_AMT.DefaultCellStyle = dataGridViewCellStyle3;
            this.POOR_AMT.FillWeight = 198F;
            this.POOR_AMT.HeaderText = "총불량수";
            this.POOR_AMT.MinimumWidth = 72;
            this.POOR_AMT.Name = "POOR_AMT";
            this.POOR_AMT.ReadOnly = true;
            this.POOR_AMT.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.POOR_AMT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // BASIC_STOCK
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.BASIC_STOCK.DefaultCellStyle = dataGridViewCellStyle4;
            this.BASIC_STOCK.FillWeight = 140F;
            this.BASIC_STOCK.HeaderText = "재공량";
            this.BASIC_STOCK.MinimumWidth = 140;
            this.BASIC_STOCK.Name = "BASIC_STOCK";
            this.BASIC_STOCK.ReadOnly = true;
            this.BASIC_STOCK.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.BASIC_STOCK.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.BASIC_STOCK.Visible = false;
            // 
            // BAL_STOCK
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.BAL_STOCK.DefaultCellStyle = dataGridViewCellStyle5;
            this.BAL_STOCK.FillWeight = 184F;
            this.BAL_STOCK.HeaderText = "제품재고량";
            this.BAL_STOCK.MinimumWidth = 86;
            this.BAL_STOCK.Name = "BAL_STOCK";
            this.BAL_STOCK.ReadOnly = true;
            this.BAL_STOCK.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.BAL_STOCK.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // txt_srch
            // 
            this.txt_srch._AutoTab = true;
            this.txt_srch._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.txt_srch._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txt_srch._WaterMarkColor = System.Drawing.Color.Gray;
            this.txt_srch._WaterMarkText = "";
            this.txt_srch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txt_srch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_srch.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_srch.ForeColor = System.Drawing.Color.Black;
            this.txt_srch.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.txt_srch.Location = new System.Drawing.Point(280, 13);
            this.txt_srch.MaxLength = 20;
            this.txt_srch.Name = "txt_srch";
            this.txt_srch.Size = new System.Drawing.Size(171, 29);
            this.txt_srch.TabIndex = 380;
            this.txt_srch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_srch_KeyDown);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(203, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 29);
            this.label3.TabIndex = 382;
            this.label3.Text = "제품명";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSrch
            // 
            this.btnSrch.BackColor = System.Drawing.Color.Transparent;
            this.btnSrch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSrch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSrch.FlatAppearance.BorderSize = 0;
            this.btnSrch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btnSrch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSrch.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSrch.ForeColor = System.Drawing.Color.White;
            this.btnSrch.Image = ((System.Drawing.Image)(resources.GetObject("btnSrch.Image")));
            this.btnSrch.Location = new System.Drawing.Point(453, 14);
            this.btnSrch.Name = "btnSrch";
            this.btnSrch.Size = new System.Drawing.Size(33, 26);
            this.btnSrch.TabIndex = 381;
            this.btnSrch.Tag = "검색";
            this.btnSrch.UseVisualStyleBackColor = false;
            this.btnSrch.Click += new System.EventHandler(this.btnSrch_Click);
            // 
            // lbl_item_nm
            // 
            this.lbl_item_nm.AutoSize = true;
            this.lbl_item_nm.Location = new System.Drawing.Point(164, 7);
            this.lbl_item_nm.Name = "lbl_item_nm";
            this.lbl_item_nm.Size = new System.Drawing.Size(0, 22);
            this.lbl_item_nm.TabIndex = 286;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(9, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 22);
            this.label2.TabIndex = 286;
            this.label2.Text = "제품 재고 세부현황";
            // 
            // datadetaiIGrid
            // 
            this.datadetaiIGrid.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.datadetaiIGrid.AllowUserToAddRows = false;
            this.datadetaiIGrid.AllowUserToDeleteRows = false;
            this.datadetaiIGrid.AllowUserToResizeColumns = false;
            this.datadetaiIGrid.AllowUserToResizeRows = false;
            this.datadetaiIGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.datadetaiIGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.datadetaiIGrid.BackgroundColor = System.Drawing.Color.White;
            this.datadetaiIGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.datadetaiIGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.datadetaiIGrid.ColumnHeadersHeight = 35;
            this.datadetaiIGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.datadetaiIGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RAW_DATE,
            this.LOT_NO,
            this.INPUT_CNT,
            this.OUTPUT_CNT,
            this.TOTAL_CNT,
            this.불량수,
            this.ETC});
            this.datadetaiIGrid.EnableHeadersVisualStyles = false;
            this.datadetaiIGrid.GridColor = System.Drawing.Color.PowderBlue;
            this.datadetaiIGrid.Location = new System.Drawing.Point(3, 32);
            this.datadetaiIGrid.Name = "datadetaiIGrid";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datadetaiIGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.datadetaiIGrid.RowHeadersVisible = false;
            this.datadetaiIGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black;
            this.datadetaiIGrid.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.datadetaiIGrid.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.datadetaiIGrid.RowTemplate.Height = 23;
            this.datadetaiIGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datadetaiIGrid.Size = new System.Drawing.Size(1354, 278);
            this.datadetaiIGrid.TabIndex = 285;
            this.datadetaiIGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.datadetaiIGrid_CellEndEdit);
            // 
            // RAW_DATE
            // 
            this.RAW_DATE.FillWeight = 72F;
            this.RAW_DATE.HeaderText = "재고날짜";
            this.RAW_DATE.MinimumWidth = 72;
            this.RAW_DATE.Name = "RAW_DATE";
            this.RAW_DATE.ReadOnly = true;
            this.RAW_DATE.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.RAW_DATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // LOT_NO
            // 
            this.LOT_NO.FillWeight = 211F;
            this.LOT_NO.HeaderText = "LOTNO";
            this.LOT_NO.MinimumWidth = 66;
            this.LOT_NO.Name = "LOT_NO";
            this.LOT_NO.ReadOnly = true;
            this.LOT_NO.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.LOT_NO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // INPUT_CNT
            // 
            this.INPUT_CNT.FillWeight = 209F;
            this.INPUT_CNT.HeaderText = "입고량";
            this.INPUT_CNT.MinimumWidth = 58;
            this.INPUT_CNT.Name = "INPUT_CNT";
            this.INPUT_CNT.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.INPUT_CNT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // OUTPUT_CNT
            // 
            this.OUTPUT_CNT.FillWeight = 211F;
            this.OUTPUT_CNT.HeaderText = "출고량";
            this.OUTPUT_CNT.MinimumWidth = 58;
            this.OUTPUT_CNT.Name = "OUTPUT_CNT";
            this.OUTPUT_CNT.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.OUTPUT_CNT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // TOTAL_CNT
            // 
            this.TOTAL_CNT.FillWeight = 212F;
            this.TOTAL_CNT.HeaderText = "재고량";
            this.TOTAL_CNT.MinimumWidth = 58;
            this.TOTAL_CNT.Name = "TOTAL_CNT";
            this.TOTAL_CNT.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TOTAL_CNT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // 불량수
            // 
            this.불량수.FillWeight = 96F;
            this.불량수.HeaderText = "불량수";
            this.불량수.MinimumWidth = 58;
            this.불량수.Name = "불량수";
            this.불량수.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.불량수.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ETC
            // 
            this.ETC.FillWeight = 340F;
            this.ETC.HeaderText = "기타";
            this.ETC.MinimumWidth = 50;
            this.ETC.Name = "ETC";
            this.ETC.ReadOnly = true;
            this.ETC.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ETC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "제품코드";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.Width = 150;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.HeaderText = "제품명";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "규격";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn3.Width = 310;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridViewTextBoxColumn4.HeaderText = "적정재고량";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 150;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridViewTextBoxColumn5.HeaderText = "재공량";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 140;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridViewTextBoxColumn6.HeaderText = "제품재고량";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 140;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "재고날짜";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "LOTNO";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 220;
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.HeaderText = "4공정";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            this.dataGridViewTextBoxColumn18.ReadOnly = true;
            this.dataGridViewTextBoxColumn18.Width = 110;
            // 
            // dataGridViewTextBoxColumn19
            // 
            this.dataGridViewTextBoxColumn19.HeaderText = "5공정";
            this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            this.dataGridViewTextBoxColumn19.ReadOnly = true;
            this.dataGridViewTextBoxColumn19.Width = 110;
            // 
            // dataGridViewTextBoxColumn20
            // 
            this.dataGridViewTextBoxColumn20.HeaderText = "6공정";
            this.dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
            this.dataGridViewTextBoxColumn20.ReadOnly = true;
            this.dataGridViewTextBoxColumn20.Width = 110;
            // 
            // dataGridViewTextBoxColumn21
            // 
            this.dataGridViewTextBoxColumn21.HeaderText = "7공정";
            this.dataGridViewTextBoxColumn21.Name = "dataGridViewTextBoxColumn21";
            this.dataGridViewTextBoxColumn21.ReadOnly = true;
            this.dataGridViewTextBoxColumn21.Width = 110;
            // 
            // dataGridViewTextBoxColumn22
            // 
            this.dataGridViewTextBoxColumn22.HeaderText = "8공정";
            this.dataGridViewTextBoxColumn22.Name = "dataGridViewTextBoxColumn22";
            this.dataGridViewTextBoxColumn22.ReadOnly = true;
            this.dataGridViewTextBoxColumn22.Width = 110;
            // 
            // dataGridViewTextBoxColumn23
            // 
            this.dataGridViewTextBoxColumn23.HeaderText = "9공정";
            this.dataGridViewTextBoxColumn23.Name = "dataGridViewTextBoxColumn23";
            this.dataGridViewTextBoxColumn23.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn24
            // 
            this.dataGridViewTextBoxColumn24.HeaderText = "10공정";
            this.dataGridViewTextBoxColumn24.Name = "dataGridViewTextBoxColumn24";
            this.dataGridViewTextBoxColumn24.ReadOnly = true;
            // 
            // frm제품재고현황
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1360, 714);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frm제품재고현황";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frm제품재고현황";
            this.Load += new System.EventHandler(this.frm제품재고현황_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataItemGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datadetaiIGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private Controls.conTextBox txt_srch;
        private System.Windows.Forms.Button btnSrch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txt_item_Cd;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txt_bal_stock;
        private System.Windows.Forms.TextBox txt_basic_stock;
        private System.Windows.Forms.TextBox txt_prop_stock;
        private System.Windows.Forms.Button clear;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn21;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn22;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn23;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn24;
        private System.Windows.Forms.DataGridViewTextBoxColumn RAW_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn LOT_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn INPUT_CNT;
        private System.Windows.Forms.DataGridViewTextBoxColumn OUTPUT_CNT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TOTAL_CNT;
        private System.Windows.Forms.DataGridViewTextBoxColumn 불량수;
        private System.Windows.Forms.DataGridViewTextBoxColumn ETC;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ITEM_CD;
        private System.Windows.Forms.DataGridViewTextBoxColumn ITEM_NM;
        private System.Windows.Forms.DataGridViewTextBoxColumn SPEC;
        private System.Windows.Forms.DataGridViewTextBoxColumn PROP_STOCK;
        private System.Windows.Forms.DataGridViewTextBoxColumn POOR_AMT;
        private System.Windows.Forms.DataGridViewTextBoxColumn BASIC_STOCK;
        private System.Windows.Forms.DataGridViewTextBoxColumn BAL_STOCK;
        private System.Windows.Forms.Label lbl_item_nm;
        private System.Windows.Forms.Label label2;
        private Controls.myDataGridView datadetaiIGrid;
        private Controls.myDataGridView dataItemGrid;
        private System.Windows.Forms.RadioButton btn_stock_no;
        private System.Windows.Forms.RadioButton btn_stock_ok;
    }
}