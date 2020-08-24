namespace MES.P30_SCH
{
    partial class frm현대생산현황
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm현대생산현황));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txt_Cust = new MES.Controls.conTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_Item = new MES.Controls.conTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cmb_flow = new MES.Controls.conComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.end_date = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.start_date = new System.Windows.Forms.DateTimePicker();
            this.lbl_title = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.flowProdGrid = new MES.Controls.myDataGridView();
            this.납품처 = new MES.Controls.DataGridViewTextBoxColumnEx();
            this.ITEM_NM = new MES.Controls.DataGridViewTextBoxColumnEx();
            this.FLOW_NM = new MES.Controls.DataGridViewTextBoxColumnEx();
            this.지시수량 = new MES.Controls.DataGridViewTextBoxColumnEx();
            this.F_SUB_AMT = new MES.Controls.DataGridViewTextBoxColumnEx();
            this.잔여수량 = new MES.Controls.DataGridViewTextBoxColumnEx();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flowProdGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.PaleTurquoise;
            this.panel2.Controls.Add(this.txt_Cust);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txt_Item);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.label4);
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
            this.panel2.TabIndex = 14;
            // 
            // txt_Cust
            // 
            this.txt_Cust._AutoTab = true;
            this.txt_Cust._BorderColor = System.Drawing.Color.White;
            this.txt_Cust._FocusedBackColor = System.Drawing.Color.White;
            this.txt_Cust._WaterMarkColor = System.Drawing.Color.Gray;
            this.txt_Cust._WaterMarkText = "";
            this.txt_Cust.Location = new System.Drawing.Point(728, 4);
            this.txt_Cust.Name = "txt_Cust";
            this.txt_Cust.Size = new System.Drawing.Size(119, 21);
            this.txt_Cust.TabIndex = 394;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(669, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 23);
            this.label5.TabIndex = 393;
            this.label5.Text = "발주처";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_Item
            // 
            this.txt_Item._AutoTab = true;
            this.txt_Item._BorderColor = System.Drawing.Color.White;
            this.txt_Item._FocusedBackColor = System.Drawing.Color.White;
            this.txt_Item._WaterMarkColor = System.Drawing.Color.Gray;
            this.txt_Item._WaterMarkText = "";
            this.txt_Item.Location = new System.Drawing.Point(552, 4);
            this.txt_Item.Name = "txt_Item";
            this.txt_Item.Size = new System.Drawing.Size(111, 21);
            this.txt_Item.TabIndex = 392;
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
            this.button1.Location = new System.Drawing.Point(982, -1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(65, 29);
            this.button1.TabIndex = 390;
            this.button1.Tag = "종료";
            this.button1.Text = "새로고침";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(493, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 23);
            this.label4.TabIndex = 389;
            this.label4.Text = "제품명";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.btnSearch.Location = new System.Drawing.Point(862, -3);
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
            this.납품처,
            this.ITEM_NM,
            this.FLOW_NM,
            this.지시수량,
            this.F_SUB_AMT,
            this.잔여수량});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.flowProdGrid.DefaultCellStyle = dataGridViewCellStyle6;
            this.flowProdGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowProdGrid.EnableHeadersVisualStyles = false;
            this.flowProdGrid.GridColor = System.Drawing.Color.PowderBlue;
            this.flowProdGrid.Location = new System.Drawing.Point(0, 33);
            this.flowProdGrid.Name = "flowProdGrid";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.flowProdGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.flowProdGrid.RowHeadersVisible = false;
            this.flowProdGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            this.flowProdGrid.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.flowProdGrid.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 12F);
            this.flowProdGrid.RowTemplate.Height = 30;
            this.flowProdGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.flowProdGrid.Size = new System.Drawing.Size(1360, 681);
            this.flowProdGrid.TabIndex = 378;
            this.flowProdGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.flowProdGrid_CellContentClick);
            // 
            // 납품처
            // 
            this.납품처.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.납품처.HeaderText = "납품처";
            this.납품처.Name = "납품처";
            this.납품처.Width = 62;
            // 
            // ITEM_NM
            // 
            this.ITEM_NM.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ITEM_NM.HeaderText = "제품명";
            this.ITEM_NM.Name = "ITEM_NM";
            this.ITEM_NM.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ITEM_NM.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // FLOW_NM
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.FLOW_NM.DefaultCellStyle = dataGridViewCellStyle2;
            this.FLOW_NM.HeaderText = "공정명";
            this.FLOW_NM.Name = "FLOW_NM";
            this.FLOW_NM.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.FLOW_NM.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.FLOW_NM.Width = 180;
            // 
            // 지시수량
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.지시수량.DefaultCellStyle = dataGridViewCellStyle3;
            this.지시수량.HeaderText = "지시수량";
            this.지시수량.Name = "지시수량";
            // 
            // F_SUB_AMT
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.F_SUB_AMT.DefaultCellStyle = dataGridViewCellStyle4;
            this.F_SUB_AMT.HeaderText = "완료수량";
            this.F_SUB_AMT.Name = "F_SUB_AMT";
            this.F_SUB_AMT.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.F_SUB_AMT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.F_SUB_AMT.Width = 120;
            // 
            // 잔여수량
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.잔여수량.DefaultCellStyle = dataGridViewCellStyle5;
            this.잔여수량.HeaderText = "잔여수량";
            this.잔여수량.Name = "잔여수량";
            // 
            // frm현대생산현황
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1360, 714);
            this.Controls.Add(this.flowProdGrid);
            this.Controls.Add(this.panel2);
            this.Name = "frm현대생산현황";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frm현대생산현황";
            this.Load += new System.EventHandler(this.frm현대생산현황_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flowProdGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private Controls.conComboBox cmb_flow;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker end_date;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker start_date;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView flowProdGrid;
        private Controls.conTextBox txt_Cust;
        private System.Windows.Forms.Label label5;
        private Controls.conTextBox txt_Item;
        private Controls.DataGridViewTextBoxColumnEx 납품처;
        private Controls.DataGridViewTextBoxColumnEx ITEM_NM;
        private Controls.DataGridViewTextBoxColumnEx FLOW_NM;
        private Controls.DataGridViewTextBoxColumnEx 지시수량;
        private Controls.DataGridViewTextBoxColumnEx F_SUB_AMT;
        private Controls.DataGridViewTextBoxColumnEx 잔여수량;
    }
}