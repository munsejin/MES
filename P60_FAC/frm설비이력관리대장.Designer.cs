namespace MES.P60_FAC
{
    partial class frm설비이력관리대장
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm설비이력관리대장));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dtp_eDate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.dtp_sDate = new System.Windows.Forms.DateTimePicker();
            this.cmb_facnm = new MES.Controls.conComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_title = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.dgv_FacList = new MES.Controls.myDataGridView();
            this.FIX_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FIX_TIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FIX_GUBUN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FIX_CUST = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STAFF_NM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FIX_REPORT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_FacList)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.PaleTurquoise;
            this.panel2.Controls.Add(this.btnSearch);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.dtp_eDate);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.dtp_sDate);
            this.panel2.Controls.Add(this.cmb_facnm);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.lbl_title);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1360, 33);
            this.panel2.TabIndex = 15;
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
            this.btnSearch.Location = new System.Drawing.Point(1080, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(33, 30);
            this.btnSearch.TabIndex = 385;
            this.btnSearch.Tag = "검색";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(615, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 23);
            this.label3.TabIndex = 384;
            this.label3.Text = "조회일자";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtp_eDate
            // 
            this.dtp_eDate.Checked = false;
            this.dtp_eDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_eDate.Location = new System.Drawing.Point(918, 6);
            this.dtp_eDate.Name = "dtp_eDate";
            this.dtp_eDate.Size = new System.Drawing.Size(156, 21);
            this.dtp_eDate.TabIndex = 383;
            this.dtp_eDate.Value = new System.DateTime(2018, 10, 8, 0, 0, 0, 0);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.Location = new System.Drawing.Point(872, 5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 23);
            this.label7.TabIndex = 381;
            this.label7.Text = "~";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtp_sDate
            // 
            this.dtp_sDate.Checked = false;
            this.dtp_sDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_sDate.Location = new System.Drawing.Point(708, 6);
            this.dtp_sDate.Name = "dtp_sDate";
            this.dtp_sDate.Size = new System.Drawing.Size(154, 21);
            this.dtp_sDate.TabIndex = 382;
            this.dtp_sDate.Value = new System.DateTime(2018, 10, 8, 0, 0, 0, 0);
            // 
            // cmb_facnm
            // 
            this.cmb_facnm._BorderColor = System.Drawing.Color.Transparent;
            this.cmb_facnm._FocusedBackColor = System.Drawing.Color.White;
            this.cmb_facnm.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cmb_facnm.FormattingEnabled = true;
            this.cmb_facnm.Location = new System.Drawing.Point(371, 6);
            this.cmb_facnm.Name = "cmb_facnm";
            this.cmb_facnm.Size = new System.Drawing.Size(220, 20);
            this.cmb_facnm.TabIndex = 298;
            this.cmb_facnm.SelectedIndexChanged += new System.EventHandler(this.cmb_facnm_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(278, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 23);
            this.label2.TabIndex = 380;
            this.label2.Text = "설비명";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.lbl_title.Location = new System.Drawing.Point(9, -2); //new System.Drawing.Point(10, 5);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(202, 22);
            this.lbl_title.TabIndex = 93;
            this.lbl_title.Text = "설비이력 관리대장";
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
            // dgv_FacList
            // 
            this.dgv_FacList.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.dgv_FacList.AllowUserToAddRows = false;
            this.dgv_FacList.AllowUserToDeleteRows = false;
            this.dgv_FacList.AllowUserToOrderColumns = true;
            this.dgv_FacList.AllowUserToResizeColumns = false;
            this.dgv_FacList.AllowUserToResizeRows = false;
            this.dgv_FacList.BackgroundColor = System.Drawing.Color.White;
            this.dgv_FacList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.PowderBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_FacList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_FacList.ColumnHeadersHeight = 40;
            this.dgv_FacList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FIX_DATE,
            this.FIX_TIME,
            this.FIX_GUBUN,
            this.FIX_CUST,
            this.STAFF_NM,
            this.FIX_REPORT});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_FacList.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgv_FacList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_FacList.EnableHeadersVisualStyles = false;
            this.dgv_FacList.GridColor = System.Drawing.Color.PowderBlue;
            this.dgv_FacList.Location = new System.Drawing.Point(0, 33);
            this.dgv_FacList.Name = "dgv_FacList";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_FacList.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgv_FacList.RowHeadersVisible = false;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            this.dgv_FacList.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgv_FacList.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 15F);
            this.dgv_FacList.RowTemplate.Height = 40;
            this.dgv_FacList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_FacList.Size = new System.Drawing.Size(1360, 681);
            this.dgv_FacList.TabIndex = 379;
            // 
            // FIX_DATE
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.FIX_DATE.DefaultCellStyle = dataGridViewCellStyle2;
            this.FIX_DATE.HeaderText = "점검일자";
            this.FIX_DATE.Name = "FIX_DATE";
            this.FIX_DATE.ReadOnly = true;
            this.FIX_DATE.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.FIX_DATE.Width = 150;
            // 
            // FIX_TIME
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.FIX_TIME.DefaultCellStyle = dataGridViewCellStyle3;
            this.FIX_TIME.HeaderText = "점검시간";
            this.FIX_TIME.Name = "FIX_TIME";
            this.FIX_TIME.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.FIX_TIME.Width = 120;
            // 
            // FIX_GUBUN
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.FIX_GUBUN.DefaultCellStyle = dataGridViewCellStyle4;
            this.FIX_GUBUN.HeaderText = "구분";
            this.FIX_GUBUN.Name = "FIX_GUBUN";
            this.FIX_GUBUN.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // FIX_CUST
            // 
            this.FIX_CUST.HeaderText = "수리업체";
            this.FIX_CUST.Name = "FIX_CUST";
            this.FIX_CUST.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.FIX_CUST.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FIX_CUST.Width = 150;
            // 
            // STAFF_NM
            // 
            this.STAFF_NM.HeaderText = "작업자";
            this.STAFF_NM.Name = "STAFF_NM";
            // 
            // FIX_REPORT
            // 
            this.FIX_REPORT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FIX_REPORT.HeaderText = "작업내역";
            this.FIX_REPORT.Name = "FIX_REPORT";
            // 
            // frm설비이력관리대장
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1360, 714);
            this.Controls.Add(this.dgv_FacList);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frm설비이력관리대장";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frm설비이력관리대장";
            this.Load += new System.EventHandler(this.frm설비이력관리대장_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_FacList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtp_eDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtp_sDate;
        private Controls.conComboBox cmb_facnm;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgv_FacList;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn FIX_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn FIX_TIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn FIX_GUBUN;
        private System.Windows.Forms.DataGridViewTextBoxColumn FIX_CUST;
        private System.Windows.Forms.DataGridViewTextBoxColumn STAFF_NM;
        private System.Windows.Forms.DataGridViewTextBoxColumn FIX_REPORT;
    }
}