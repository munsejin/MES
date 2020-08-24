namespace MES.P70_STA
{
    partial class frm제품공정추적
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm제품공정추적));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_title = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lotGrid = new MES.Controls.myDataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSrch = new System.Windows.Forms.Button();
            this.cmb_공정명 = new MES.Controls.conComboBox();
            this.txt_item_nm = new MES.Controls.conTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_flow_cd = new System.Windows.Forms.Label();
            this.F_SUB_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PUR_CUST_NM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RAW_MAT_CD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RAW_MAT_NM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RAW_SPEC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TOTAL_AMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INPUT_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PUR_CUST_CD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FLOW_CD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.F_STEP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.W_INST_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SALES_CUST_NM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.W_INST_CD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FLOW_NM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.F_SUB_AMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LOSS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.POOR_AMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SALES_CUST_CD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OUTPUT_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lotGrid)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.PaleTurquoise;
            this.panel2.Controls.Add(this.lbl_title);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1360, 33);
            this.panel2.TabIndex = 16;
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.lbl_title.Location = new System.Drawing.Point(9, -2); //new System.Drawing.Point(10, 5);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(148, 22);
            this.lbl_title.TabIndex = 93;
            this.lbl_title.Text = "제품공정추적";
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
            this.btnClose.Location = new System.Drawing.Point(1292, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(65, 29);
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
            this.panel1.Controls.Add(this.lotGrid);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 33);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1360, 681);
            this.panel1.TabIndex = 17;
            // 
            // lotGrid
            // 
            this.lotGrid.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.lotGrid.AllowUserToAddRows = false;
            this.lotGrid.AllowUserToDeleteRows = false;
            this.lotGrid.AllowUserToResizeColumns = false;
            this.lotGrid.AllowUserToResizeRows = false;
            this.lotGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lotGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.lotGrid.BackgroundColor = System.Drawing.Color.White;
            this.lotGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.lotGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.lotGrid.ColumnHeadersHeight = 40;
            this.lotGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.lotGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.F_SUB_DATE,
            this.PUR_CUST_NM,
            this.RAW_MAT_CD,
            this.RAW_MAT_NM,
            this.RAW_SPEC,
            this.TOTAL_AMT,
            this.INPUT_DATE,
            this.PUR_CUST_CD,
            this.Column5,
            this.FLOW_CD,
            this.F_STEP,
            this.W_INST_DATE,
            this.SALES_CUST_NM,
            this.W_INST_CD,
            this.FLOW_NM,
            this.F_SUB_AMT,
            this.LOSS,
            this.POOR_AMT,
            this.Column9,
            this.SALES_CUST_CD,
            this.OUTPUT_DATE,
            this.Column12});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.lotGrid.DefaultCellStyle = dataGridViewCellStyle6;
            this.lotGrid.EnableHeadersVisualStyles = false;
            this.lotGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.lotGrid.Location = new System.Drawing.Point(3, 104);
            this.lotGrid.Name = "lotGrid";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.lotGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.lotGrid.RowHeadersVisible = false;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            this.lotGrid.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.lotGrid.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F);
            this.lotGrid.RowTemplate.Height = 40;
            this.lotGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.lotGrid.Size = new System.Drawing.Size(1354, 574);
            this.lotGrid.TabIndex = 383;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnSrch);
            this.groupBox1.Controls.Add(this.cmb_공정명);
            this.groupBox1.Controls.Add(this.txt_item_nm);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lbl_flow_cd);
            this.groupBox1.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1354, 95);
            this.groupBox1.TabIndex = 354;
            this.groupBox1.TabStop = false;
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
            this.btnSrch.Location = new System.Drawing.Point(290, 52);
            this.btnSrch.Name = "btnSrch";
            this.btnSrch.Size = new System.Drawing.Size(33, 30);
            this.btnSrch.TabIndex = 397;
            this.btnSrch.Tag = "검색";
            this.btnSrch.UseVisualStyleBackColor = false;
            this.btnSrch.Click += new System.EventHandler(this.btnSrch_Click);
            // 
            // cmb_공정명
            // 
            this.cmb_공정명._BorderColor = System.Drawing.Color.White;
            this.cmb_공정명._FocusedBackColor = System.Drawing.Color.White;
            this.cmb_공정명.FormattingEnabled = true;
            this.cmb_공정명.Location = new System.Drawing.Point(90, 19);
            this.cmb_공정명.Name = "cmb_공정명";
            this.cmb_공정명.Size = new System.Drawing.Size(194, 21);
            this.cmb_공정명.TabIndex = 396;
            // 
            // txt_item_nm
            // 
            this.txt_item_nm._AutoTab = true;
            this.txt_item_nm._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.txt_item_nm._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txt_item_nm._WaterMarkColor = System.Drawing.Color.Gray;
            this.txt_item_nm._WaterMarkText = "";
            this.txt_item_nm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_item_nm.Enabled = false;
            this.txt_item_nm.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_item_nm.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.txt_item_nm.Location = new System.Drawing.Point(90, 56);
            this.txt_item_nm.MaxLength = 20;
            this.txt_item_nm.Name = "txt_item_nm";
            this.txt_item_nm.Size = new System.Drawing.Size(194, 24);
            this.txt_item_nm.TabIndex = 332;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.PowderBlue;
            this.label5.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(9, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 23);
            this.label5.TabIndex = 327;
            this.label5.Text = "제품명";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_flow_cd
            // 
            this.lbl_flow_cd.BackColor = System.Drawing.Color.PowderBlue;
            this.lbl_flow_cd.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_flow_cd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_flow_cd.Location = new System.Drawing.Point(8, 18);
            this.lbl_flow_cd.Name = "lbl_flow_cd";
            this.lbl_flow_cd.Size = new System.Drawing.Size(80, 23);
            this.lbl_flow_cd.TabIndex = 289;
            this.lbl_flow_cd.Text = "공정목록";
            this.lbl_flow_cd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // F_SUB_DATE
            // 
            this.F_SUB_DATE.HeaderText = "투입일자";
            this.F_SUB_DATE.Name = "F_SUB_DATE";
            this.F_SUB_DATE.ReadOnly = true;
            this.F_SUB_DATE.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // PUR_CUST_NM
            // 
            this.PUR_CUST_NM.HeaderText = "매입거래처";
            this.PUR_CUST_NM.Name = "PUR_CUST_NM";
            // 
            // RAW_MAT_CD
            // 
            this.RAW_MAT_CD.HeaderText = "원자재코드";
            this.RAW_MAT_CD.Name = "RAW_MAT_CD";
            // 
            // RAW_MAT_NM
            // 
            this.RAW_MAT_NM.HeaderText = "원자재명";
            this.RAW_MAT_NM.Name = "RAW_MAT_NM";
            this.RAW_MAT_NM.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // RAW_SPEC
            // 
            this.RAW_SPEC.HeaderText = "자재규격";
            this.RAW_SPEC.Name = "RAW_SPEC";
            // 
            // TOTAL_AMT
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.TOTAL_AMT.DefaultCellStyle = dataGridViewCellStyle2;
            this.TOTAL_AMT.HeaderText = "소요량";
            this.TOTAL_AMT.Name = "TOTAL_AMT";
            this.TOTAL_AMT.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // INPUT_DATE
            // 
            this.INPUT_DATE.HeaderText = "입고일자";
            this.INPUT_DATE.Name = "INPUT_DATE";
            // 
            // PUR_CUST_CD
            // 
            this.PUR_CUST_CD.HeaderText = "매입거래처코드";
            this.PUR_CUST_CD.Name = "PUR_CUST_CD";
            this.PUR_CUST_CD.Visible = false;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "HEATNO";
            this.Column5.Name = "Column5";
            this.Column5.Visible = false;
            // 
            // FLOW_CD
            // 
            this.FLOW_CD.HeaderText = "공정코드";
            this.FLOW_CD.Name = "FLOW_CD";
            this.FLOW_CD.Visible = false;
            // 
            // F_STEP
            // 
            this.F_STEP.HeaderText = "공정단계";
            this.F_STEP.Name = "F_STEP";
            this.F_STEP.Visible = false;
            // 
            // W_INST_DATE
            // 
            this.W_INST_DATE.HeaderText = "작업일자";
            this.W_INST_DATE.Name = "W_INST_DATE";
            // 
            // SALES_CUST_NM
            // 
            this.SALES_CUST_NM.HeaderText = "납품거래처";
            this.SALES_CUST_NM.Name = "SALES_CUST_NM";
            // 
            // W_INST_CD
            // 
            this.W_INST_CD.HeaderText = "작업코드";
            this.W_INST_CD.Name = "W_INST_CD";
            this.W_INST_CD.Visible = false;
            // 
            // FLOW_NM
            // 
            this.FLOW_NM.HeaderText = "공정명";
            this.FLOW_NM.Name = "FLOW_NM";
            // 
            // F_SUB_AMT
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.F_SUB_AMT.DefaultCellStyle = dataGridViewCellStyle3;
            this.F_SUB_AMT.HeaderText = "제품수량";
            this.F_SUB_AMT.Name = "F_SUB_AMT";
            // 
            // LOSS
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.LOSS.DefaultCellStyle = dataGridViewCellStyle4;
            this.LOSS.HeaderText = "LOSS";
            this.LOSS.Name = "LOSS";
            // 
            // POOR_AMT
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.POOR_AMT.DefaultCellStyle = dataGridViewCellStyle5;
            this.POOR_AMT.HeaderText = "불량";
            this.POOR_AMT.Name = "POOR_AMT";
            // 
            // Column9
            // 
            this.Column9.HeaderText = "검사";
            this.Column9.Name = "Column9";
            this.Column9.Visible = false;
            // 
            // SALES_CUST_CD
            // 
            this.SALES_CUST_CD.HeaderText = "납품거래처코드";
            this.SALES_CUST_CD.Name = "SALES_CUST_CD";
            this.SALES_CUST_CD.Visible = false;
            // 
            // OUTPUT_DATE
            // 
            this.OUTPUT_DATE.HeaderText = "출고일자";
            this.OUTPUT_DATE.Name = "OUTPUT_DATE";
            // 
            // Column12
            // 
            this.Column12.HeaderText = "출고량";
            this.Column12.Name = "Column12";
            this.Column12.Visible = false;
            // 
            // frm제품공정추적
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1360, 714);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "frm제품공정추적";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frm제품공정추적";
            this.Load += new System.EventHandler(this.frm제품공정추적_Load);
            this.Enter += new System.EventHandler(this.frm제품공정추적_Enter);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lotGrid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView lotGrid;
        private System.Windows.Forms.GroupBox groupBox1;
        private Controls.conTextBox txt_item_nm;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_flow_cd;
        private Controls.conComboBox cmb_공정명;
        private System.Windows.Forms.Button btnSrch;
        private System.Windows.Forms.DataGridViewTextBoxColumn F_SUB_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn PUR_CUST_NM;
        private System.Windows.Forms.DataGridViewTextBoxColumn RAW_MAT_CD;
        private System.Windows.Forms.DataGridViewTextBoxColumn RAW_MAT_NM;
        private System.Windows.Forms.DataGridViewTextBoxColumn RAW_SPEC;
        private System.Windows.Forms.DataGridViewTextBoxColumn TOTAL_AMT;
        private System.Windows.Forms.DataGridViewTextBoxColumn INPUT_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn PUR_CUST_CD;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn FLOW_CD;
        private System.Windows.Forms.DataGridViewTextBoxColumn F_STEP;
        private System.Windows.Forms.DataGridViewTextBoxColumn W_INST_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn SALES_CUST_NM;
        private System.Windows.Forms.DataGridViewTextBoxColumn W_INST_CD;
        private System.Windows.Forms.DataGridViewTextBoxColumn FLOW_NM;
        private System.Windows.Forms.DataGridViewTextBoxColumn F_SUB_AMT;
        private System.Windows.Forms.DataGridViewTextBoxColumn LOSS;
        private System.Windows.Forms.DataGridViewTextBoxColumn POOR_AMT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn SALES_CUST_CD;
        private System.Windows.Forms.DataGridViewTextBoxColumn OUTPUT_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;

    }
}