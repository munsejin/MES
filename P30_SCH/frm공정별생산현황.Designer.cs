namespace MES.P30_SCH
{
    partial class frm공정별생산현황
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm공정별생산현황));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cmb_item = new MES.Controls.conComboBox();
            this.cmb_flow = new MES.Controls.conComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.end_date = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.start_date = new System.Windows.Forms.DateTimePicker();
            this.lbl_title = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.flowProdGrid = new MES.Controls.myDataGridView();
            this.INPUT_DATE = new MES.Controls.DataGridViewTextBoxColumnEx();
            this.LOT_NO = new MES.Controls.DataGridViewTextBoxColumnEx();
            this.LOT_SUB = new MES.Controls.DataGridViewTextBoxColumnEx();
            this.ITEM_NM = new MES.Controls.DataGridViewTextBoxColumnEx();
            this.F_STEP = new MES.Controls.DataGridViewTextBoxColumnEx();
            this.FLOW_NM = new MES.Controls.DataGridViewTextBoxColumnEx();
            this.F_SUB_AMT = new MES.Controls.DataGridViewTextBoxColumnEx();
            this.POOR_AMT = new MES.Controls.DataGridViewTextBoxColumnEx();
            this.LOSS = new MES.Controls.DataGridViewTextBoxColumnEx();
            this.OUT_COMP = new MES.Controls.DataGridViewTextBoxColumnEx();
            this.EXAM = new MES.Controls.DataGridViewTextBoxColumnEx();
            this.COMMENT = new MES.Controls.DataGridViewTextBoxColumnEx();
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
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flowProdGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.PaleTurquoise;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.cmb_item);
            this.panel2.Controls.Add(this.cmb_flow);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.end_date);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btnSearch);
            this.panel2.Controls.Add(this.start_date);
            this.panel2.Controls.Add(this.lbl_title);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1360, 33);
            this.panel2.TabIndex = 12;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button1.Location = new System.Drawing.Point(931, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(65, 29);
            this.button1.TabIndex = 390;
            this.button1.Tag = "종료";
            this.button1.Text = "새로고침";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(541, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 23);
            this.label4.TabIndex = 389;
            this.label4.Text = "제품명";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmb_item
            // 
            this.cmb_item._BorderColor = System.Drawing.Color.Transparent;
            this.cmb_item._FocusedBackColor = System.Drawing.Color.White;
            this.cmb_item.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cmb_item.FormattingEnabled = true;
            this.cmb_item.Location = new System.Drawing.Point(633, 6);
            this.cmb_item.Name = "cmb_item";
            this.cmb_item.Size = new System.Drawing.Size(208, 20);
            this.cmb_item.TabIndex = 388;
            // 
            // cmb_flow
            // 
            this.cmb_flow._BorderColor = System.Drawing.Color.Transparent;
            this.cmb_flow._FocusedBackColor = System.Drawing.Color.White;
            this.cmb_flow.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cmb_flow.FormattingEnabled = true;
            this.cmb_flow.Location = new System.Drawing.Point(1141, 0);
            this.cmb_flow.Name = "cmb_flow";
            this.cmb_flow.Size = new System.Drawing.Size(156, 20);
            this.cmb_flow.TabIndex = 387;
            this.cmb_flow.Visible = false;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(1138, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 23);
            this.label3.TabIndex = 386;
            this.label3.Text = "공정";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3.Visible = false;
            // 
            // end_date
            // 
            this.end_date.Checked = false;
            this.end_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.end_date.Location = new System.Drawing.Point(405, 7);
            this.end_date.Name = "end_date";
            this.end_date.Size = new System.Drawing.Size(82, 21);
            this.end_date.TabIndex = 385;
            this.end_date.Value = new System.DateTime(2018, 10, 8, 0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(213, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 23);
            this.label2.TabIndex = 383;
            this.label2.Text = "조회일자";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.btnSearch.Location = new System.Drawing.Point(866, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(33, 30);
            this.btnSearch.TabIndex = 382;
            this.btnSearch.Tag = "검색";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // start_date
            // 
            this.start_date.Checked = false;
            this.start_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.start_date.Location = new System.Drawing.Point(298, 7);
            this.start_date.Name = "start_date";
            this.start_date.Size = new System.Drawing.Size(82, 21);
            this.start_date.TabIndex = 381;
            this.start_date.Value = new System.DateTime(2018, 10, 8, 0, 0, 0, 0);
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.lbl_title.Location = new System.Drawing.Point(9, -2); //new System.Drawing.Point(10, 5);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(102, 22);
            this.lbl_title.TabIndex = 93;
            this.lbl_title.Text = "생산현황";
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
            // flowProdGrid
            // 
            this.flowProdGrid.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.flowProdGrid.AllowUserToAddRows = false;
            this.flowProdGrid.AllowUserToDeleteRows = false;
            this.flowProdGrid.AllowUserToOrderColumns = true;
            this.flowProdGrid.AllowUserToResizeColumns = false;
            this.flowProdGrid.AllowUserToResizeRows = false;
            this.flowProdGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowProdGrid.BackgroundColor = System.Drawing.Color.White;
            this.flowProdGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.PowderBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.flowProdGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.flowProdGrid.ColumnHeadersHeight = 40;
            this.flowProdGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.flowProdGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.INPUT_DATE,
            this.LOT_NO,
            this.LOT_SUB,
            this.ITEM_NM,
            this.F_STEP,
            this.FLOW_NM,
            this.F_SUB_AMT,
            this.POOR_AMT,
            this.LOSS,
            this.OUT_COMP,
            this.EXAM,
            this.COMMENT});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.flowProdGrid.DefaultCellStyle = dataGridViewCellStyle9;
            this.flowProdGrid.EnableHeadersVisualStyles = false;
            this.flowProdGrid.GridColor = System.Drawing.Color.PowderBlue;
            this.flowProdGrid.Location = new System.Drawing.Point(2, 33);
            this.flowProdGrid.Name = "flowProdGrid";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.flowProdGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.flowProdGrid.RowHeadersVisible = false;
            this.flowProdGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.Black;
            this.flowProdGrid.RowsDefaultCellStyle = dataGridViewCellStyle11;
            this.flowProdGrid.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 12F);
            this.flowProdGrid.RowTemplate.Height = 30;
            this.flowProdGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.flowProdGrid.Size = new System.Drawing.Size(1357, 677);
            this.flowProdGrid.TabIndex = 376;
            // 
            // INPUT_DATE
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.INPUT_DATE.DefaultCellStyle = dataGridViewCellStyle2;
            this.INPUT_DATE.HeaderText = "생산일자";
            this.INPUT_DATE.Name = "INPUT_DATE";
            this.INPUT_DATE.ReadOnly = true;
            this.INPUT_DATE.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.INPUT_DATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.INPUT_DATE.Width = 140;
            // 
            // LOT_NO
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.LOT_NO.DefaultCellStyle = dataGridViewCellStyle3;
            this.LOT_NO.HeaderText = "LOTNO";
            this.LOT_NO.Name = "LOT_NO";
            this.LOT_NO.ReadOnly = true;
            this.LOT_NO.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.LOT_NO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.LOT_NO.Width = 180;
            // 
            // LOT_SUB
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.LOT_SUB.DefaultCellStyle = dataGridViewCellStyle4;
            this.LOT_SUB.HeaderText = "LOTSUB";
            this.LOT_SUB.Name = "LOT_SUB";
            this.LOT_SUB.ReadOnly = true;
            this.LOT_SUB.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.LOT_SUB.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.LOT_SUB.Width = 120;
            // 
            // ITEM_NM
            // 
            this.ITEM_NM.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ITEM_NM.HeaderText = "제품명";
            this.ITEM_NM.Name = "ITEM_NM";
            this.ITEM_NM.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ITEM_NM.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // F_STEP
            // 
            this.F_STEP.HeaderText = "공정단계";
            this.F_STEP.Name = "F_STEP";
            this.F_STEP.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.F_STEP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.F_STEP.Width = 80;
            // 
            // FLOW_NM
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.FLOW_NM.DefaultCellStyle = dataGridViewCellStyle5;
            this.FLOW_NM.HeaderText = "공정명";
            this.FLOW_NM.Name = "FLOW_NM";
            this.FLOW_NM.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.FLOW_NM.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.FLOW_NM.Width = 180;
            // 
            // F_SUB_AMT
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.F_SUB_AMT.DefaultCellStyle = dataGridViewCellStyle6;
            this.F_SUB_AMT.HeaderText = "수량";
            this.F_SUB_AMT.Name = "F_SUB_AMT";
            this.F_SUB_AMT.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.F_SUB_AMT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.F_SUB_AMT.Width = 120;
            // 
            // POOR_AMT
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.POOR_AMT.DefaultCellStyle = dataGridViewCellStyle7;
            this.POOR_AMT.HeaderText = "불량";
            this.POOR_AMT.Name = "POOR_AMT";
            this.POOR_AMT.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.POOR_AMT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.POOR_AMT.Visible = false;
            this.POOR_AMT.Width = 150;
            // 
            // LOSS
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.LOSS.DefaultCellStyle = dataGridViewCellStyle8;
            this.LOSS.HeaderText = "LOSS";
            this.LOSS.Name = "LOSS";
            this.LOSS.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.LOSS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.LOSS.Width = 150;
            // 
            // OUT_COMP
            // 
            this.OUT_COMP.HeaderText = "외주업체";
            this.OUT_COMP.Name = "OUT_COMP";
            this.OUT_COMP.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.OUT_COMP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.OUT_COMP.Visible = false;
            this.OUT_COMP.Width = 200;
            // 
            // EXAM
            // 
            this.EXAM.HeaderText = "검사";
            this.EXAM.Name = "EXAM";
            this.EXAM.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.EXAM.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.EXAM.Visible = false;
            // 
            // COMMENT
            // 
            this.COMMENT.HeaderText = "비고";
            this.COMMENT.Name = "COMMENT";
            this.COMMENT.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.COMMENT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.COMMENT.Visible = false;
            this.COMMENT.Width = 250;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "생산일자";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.Width = 120;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "LOTNO";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn2.Width = 120;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridViewTextBoxColumn3.HeaderText = "LOTSUB";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn3.Width = 120;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle13;
            this.dataGridViewTextBoxColumn4.HeaderText = "수량";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn4.Width = 120;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle14;
            this.dataGridViewTextBoxColumn5.HeaderText = "불량";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn5.Width = 150;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle15;
            this.dataGridViewTextBoxColumn6.HeaderText = "LOSS";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn6.Width = 150;
            // 
            // dataGridViewTextBoxColumn7
            // 
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle16;
            this.dataGridViewTextBoxColumn7.HeaderText = "외주업체";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn7.Width = 200;
            // 
            // dataGridViewTextBoxColumn8
            // 
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn8.DefaultCellStyle = dataGridViewCellStyle17;
            this.dataGridViewTextBoxColumn8.HeaderText = "검사";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn8.Width = 120;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "비고";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Width = 250;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "비고";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Visible = false;
            this.dataGridViewTextBoxColumn10.Width = 250;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.HeaderText = "비고";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.Visible = false;
            this.dataGridViewTextBoxColumn11.Width = 250;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(383, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 23);
            this.label1.TabIndex = 391;
            this.label1.Text = "~";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frm공정별생산현황
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1360, 714);
            this.Controls.Add(this.flowProdGrid);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frm공정별생산현황";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frm공정별생산현황";
            this.Load += new System.EventHandler(this.frm공정별생산현황_Load);
            this.Enter += new System.EventHandler(this.frm공정별생산현황_Enter);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flowProdGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker start_date;
        private System.Windows.Forms.DateTimePicker end_date;
        private System.Windows.Forms.DataGridView flowProdGrid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private Controls.conComboBox cmb_item;
        private Controls.conComboBox cmb_flow;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.Button button1;
        private Controls.DataGridViewTextBoxColumnEx INPUT_DATE;
        private Controls.DataGridViewTextBoxColumnEx LOT_NO;
        private Controls.DataGridViewTextBoxColumnEx LOT_SUB;
        private Controls.DataGridViewTextBoxColumnEx ITEM_NM;
        private Controls.DataGridViewTextBoxColumnEx F_STEP;
        private Controls.DataGridViewTextBoxColumnEx FLOW_NM;
        private Controls.DataGridViewTextBoxColumnEx F_SUB_AMT;
        private Controls.DataGridViewTextBoxColumnEx POOR_AMT;
        private Controls.DataGridViewTextBoxColumnEx LOSS;
        private Controls.DataGridViewTextBoxColumnEx OUT_COMP;
        private Controls.DataGridViewTextBoxColumnEx EXAM;
        private Controls.DataGridViewTextBoxColumnEx COMMENT;
        private System.Windows.Forms.Label label1;
    }
}