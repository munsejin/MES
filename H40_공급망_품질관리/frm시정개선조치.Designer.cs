namespace MES.H40_공급망_품질관리
{
    partial class frm시정개선조치
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm시정개선조치));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_close = new System.Windows.Forms.Button();
            this.lbl_title = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnl_main = new System.Windows.Forms.Panel();
            this.dgv이슈 = new MES.Controls.myDataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
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
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt이슈처리내역 = new MES.Controls.conTextBox();
            this.ISSUE_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ISSUE_MEMO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ISSUE_NUM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.상담시각 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CUST_CD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CUST_NM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ISSUE_STAFF_NM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ISSUE_STAFF_CD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ISSUE_NM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ISSUE_CD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STATE_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TEL_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.O_ORD_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.O_ORD_NUM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnl_main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv이슈)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.btn_close);
            this.panel2.Controls.Add(this.lbl_title);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1360, 33);
            this.panel2.TabIndex = 21;
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
            this.btn_close.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.btn_close.Image = ((System.Drawing.Image)(resources.GetObject("btn_close.Image")));
            this.btn_close.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_close.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_close.Location = new System.Drawing.Point(1290, 1);
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
            this.lbl_title.Size = new System.Drawing.Size(148, 22);
            this.lbl_title.TabIndex = 93;
            this.lbl_title.Text = "시정개선조치";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pnl_main);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1360, 681);
            this.panel1.TabIndex = 23;
            // 
            // pnl_main
            // 
            this.pnl_main.BackColor = System.Drawing.Color.White;
            this.pnl_main.Controls.Add(this.panel3);
            this.pnl_main.Controls.Add(this.dgv이슈);
            this.pnl_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_main.Location = new System.Drawing.Point(0, 0);
            this.pnl_main.Name = "pnl_main";
            this.pnl_main.Size = new System.Drawing.Size(1360, 681);
            this.pnl_main.TabIndex = 15;
            // 
            // dgv이슈
            // 
            this.dgv이슈.AllowUserToAddRows = false;
            this.dgv이슈.AllowUserToDeleteRows = false;
            this.dgv이슈.AllowUserToOrderColumns = true;
            this.dgv이슈.AllowUserToResizeColumns = false;
            this.dgv이슈.AllowUserToResizeRows = false;
            this.dgv이슈.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgv이슈.BackgroundColor = System.Drawing.Color.White;
            this.dgv이슈.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.PowderBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv이슈.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv이슈.ColumnHeadersHeight = 40;
            this.dgv이슈.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ISSUE_DATE,
            this.ISSUE_MEMO,
            this.ISSUE_NUM,
            this.상담시각,
            this.CUST_CD,
            this.CUST_NM,
            this.ISSUE_STAFF_NM,
            this.ISSUE_STAFF_CD,
            this.ISSUE_NM,
            this.ISSUE_CD,
            this.STATE_DATE,
            this.TEL_NO,
            this.O_ORD_DATE,
            this.O_ORD_NUM});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv이슈.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv이슈.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv이슈.EnableHeadersVisualStyles = false;
            this.dgv이슈.GridColor = System.Drawing.Color.PowderBlue;
            this.dgv이슈.Location = new System.Drawing.Point(0, 0);
            this.dgv이슈.Name = "dgv이슈";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgv이슈.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv이슈.RowHeadersVisible = false;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.dgv이슈.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv이슈.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F);
            this.dgv이슈.RowTemplate.Height = 30;
            this.dgv이슈.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv이슈.Size = new System.Drawing.Size(1360, 681);
            this.dgv이슈.TabIndex = 380;
            this.dgv이슈.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv이슈_CellDoubleClick);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txt이슈처리내역);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 454);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1360, 227);
            this.panel3.TabIndex = 381;
            this.panel3.Visible = false;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.label1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1360, 27);
            this.panel4.TabIndex = 394;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.PowderBlue;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 27);
            this.label1.TabIndex = 379;
            this.label1.Text = "처리 내용";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn1.HeaderText = "이슈일자";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 97;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "ISSUE_MEMO";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Visible = false;
            this.dataGridViewTextBoxColumn2.Width = 133;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn3.HeaderText = "이슈번호";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 97;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn4.HeaderText = "상담시각";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 97;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "거래처코드";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Visible = false;
            this.dataGridViewTextBoxColumn5.Width = 113;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn6.HeaderText = "거래처";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "상담사원";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 97;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "상담사원코드";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Visible = false;
            this.dataGridViewTextBoxColumn8.Width = 129;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn9.HeaderText = "이슈구분";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Width = 97;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "이슈구분코드";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Visible = false;
            this.dataGridViewTextBoxColumn10.Width = 129;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn11.HeaderText = "발문요청일자";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.Width = 129;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn12.HeaderText = "고객전화번호";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn12.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn12.Width = 110;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.HeaderText = "주문일자";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.Width = 97;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.HeaderText = "주문번호";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.Width = 97;
            // 
            // txt이슈처리내역
            // 
            this.txt이슈처리내역._AutoTab = true;
            this.txt이슈처리내역._BorderColor = System.Drawing.Color.PowderBlue;
            this.txt이슈처리내역._FocusedBackColor = System.Drawing.Color.White;
            this.txt이슈처리내역._WaterMarkColor = System.Drawing.Color.Gray;
            this.txt이슈처리내역._WaterMarkText = "";
            this.txt이슈처리내역.BackColor = System.Drawing.SystemColors.Control;
            this.txt이슈처리내역.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt이슈처리내역.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt이슈처리내역.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt이슈처리내역.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.txt이슈처리내역.Location = new System.Drawing.Point(0, 27);
            this.txt이슈처리내역.MaxLength = 20;
            this.txt이슈처리내역.Name = "txt이슈처리내역";
            this.txt이슈처리내역.ReadOnly = true;
            this.txt이슈처리내역.Size = new System.Drawing.Size(1360, 200);
            this.txt이슈처리내역.TabIndex = 395;
            // 
            // ISSUE_DATE
            // 
            this.ISSUE_DATE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ISSUE_DATE.HeaderText = "이슈일자";
            this.ISSUE_DATE.Name = "ISSUE_DATE";
            this.ISSUE_DATE.Width = 97;
            // 
            // ISSUE_MEMO
            // 
            this.ISSUE_MEMO.HeaderText = "ISSUE_MEMO";
            this.ISSUE_MEMO.Name = "ISSUE_MEMO";
            this.ISSUE_MEMO.Visible = false;
            this.ISSUE_MEMO.Width = 133;
            // 
            // ISSUE_NUM
            // 
            this.ISSUE_NUM.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ISSUE_NUM.HeaderText = "이슈번호";
            this.ISSUE_NUM.Name = "ISSUE_NUM";
            this.ISSUE_NUM.Width = 97;
            // 
            // 상담시각
            // 
            this.상담시각.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.상담시각.HeaderText = "상담시각";
            this.상담시각.Name = "상담시각";
            this.상담시각.Width = 97;
            // 
            // CUST_CD
            // 
            this.CUST_CD.HeaderText = "거래처코드";
            this.CUST_CD.Name = "CUST_CD";
            this.CUST_CD.Visible = false;
            this.CUST_CD.Width = 113;
            // 
            // CUST_NM
            // 
            this.CUST_NM.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CUST_NM.HeaderText = "거래처";
            this.CUST_NM.Name = "CUST_NM";
            // 
            // ISSUE_STAFF_NM
            // 
            this.ISSUE_STAFF_NM.HeaderText = "상담사원";
            this.ISSUE_STAFF_NM.Name = "ISSUE_STAFF_NM";
            this.ISSUE_STAFF_NM.Width = 97;
            // 
            // ISSUE_STAFF_CD
            // 
            this.ISSUE_STAFF_CD.HeaderText = "상담사원코드";
            this.ISSUE_STAFF_CD.Name = "ISSUE_STAFF_CD";
            this.ISSUE_STAFF_CD.Visible = false;
            this.ISSUE_STAFF_CD.Width = 129;
            // 
            // ISSUE_NM
            // 
            this.ISSUE_NM.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ISSUE_NM.HeaderText = "이슈구분";
            this.ISSUE_NM.Name = "ISSUE_NM";
            this.ISSUE_NM.Width = 97;
            // 
            // ISSUE_CD
            // 
            this.ISSUE_CD.HeaderText = "이슈구분코드";
            this.ISSUE_CD.Name = "ISSUE_CD";
            this.ISSUE_CD.Visible = false;
            this.ISSUE_CD.Width = 129;
            // 
            // STATE_DATE
            // 
            this.STATE_DATE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.STATE_DATE.HeaderText = "완료일자";
            this.STATE_DATE.Name = "STATE_DATE";
            this.STATE_DATE.Width = 97;
            // 
            // TEL_NO
            // 
            this.TEL_NO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.TEL_NO.HeaderText = "고객전화번호";
            this.TEL_NO.Name = "TEL_NO";
            this.TEL_NO.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TEL_NO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TEL_NO.Width = 110;
            // 
            // O_ORD_DATE
            // 
            this.O_ORD_DATE.HeaderText = "주문일자";
            this.O_ORD_DATE.Name = "O_ORD_DATE";
            this.O_ORD_DATE.Width = 97;
            // 
            // O_ORD_NUM
            // 
            this.O_ORD_NUM.HeaderText = "주문번호";
            this.O_ORD_NUM.Name = "O_ORD_NUM";
            this.O_ORD_NUM.Width = 97;
            // 
            // frm시정개선조치
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1360, 714);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "frm시정개선조치";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frm시정개선조치";
            this.Load += new System.EventHandler(this.frm시정개선조치_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.pnl_main.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv이슈)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Panel pnl_main;
        private System.Windows.Forms.DataGridView dgv이슈;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.Panel panel3;
        private Controls.conTextBox txt이슈처리내역;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ISSUE_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn ISSUE_MEMO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ISSUE_NUM;
        private System.Windows.Forms.DataGridViewTextBoxColumn 상담시각;
        private System.Windows.Forms.DataGridViewTextBoxColumn CUST_CD;
        private System.Windows.Forms.DataGridViewTextBoxColumn CUST_NM;
        private System.Windows.Forms.DataGridViewTextBoxColumn ISSUE_STAFF_NM;
        private System.Windows.Forms.DataGridViewTextBoxColumn ISSUE_STAFF_CD;
        private System.Windows.Forms.DataGridViewTextBoxColumn ISSUE_NM;
        private System.Windows.Forms.DataGridViewTextBoxColumn ISSUE_CD;
        private System.Windows.Forms.DataGridViewTextBoxColumn STATE_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn TEL_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn O_ORD_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn O_ORD_NUM;
    }
}