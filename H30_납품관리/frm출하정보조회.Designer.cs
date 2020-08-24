namespace MES.H30_납품관리
{
    partial class frm출하정보조회
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm출하정보조회));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn검색 = new System.Windows.Forms.Button();
            this.dtp엔드 = new MES.Controls.conDateTimePicker();
            this.dtp스타트 = new MES.Controls.conDateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_close = new System.Windows.Forms.Button();
            this.lbl_title = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.itemGrid = new MES.Controls.myDataGridView();
            this.ITEM_CD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ITEM_NM2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SPEC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.매출처 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ORD_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ORD_NUM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ORD_QTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ORD_PRICE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ORD_AMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.담당사원 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.배송일자 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.배송번호 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DELIVERY_QTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.배송사원 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.배송상태 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.배송완료일자 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.PaleTurquoise;
            this.panel2.Controls.Add(this.btn검색);
            this.panel2.Controls.Add(this.dtp엔드);
            this.panel2.Controls.Add(this.dtp스타트);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btn_close);
            this.panel2.Controls.Add(this.lbl_title);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1360, 33);
            this.panel2.TabIndex = 21;
            // 
            // btn검색
            // 
            this.btn검색.BackColor = System.Drawing.Color.Transparent;
            this.btn검색.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn검색.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn검색.FlatAppearance.BorderSize = 0;
            this.btn검색.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btn검색.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn검색.Image = ((System.Drawing.Image)(resources.GetObject("btn검색.Image")));
            this.btn검색.Location = new System.Drawing.Point(632, 2);
            this.btn검색.Name = "btn검색";
            this.btn검색.Size = new System.Drawing.Size(33, 33);
            this.btn검색.TabIndex = 408;
            this.btn검색.Tag = "검색";
            this.btn검색.UseVisualStyleBackColor = false;
            this.btn검색.Click += new System.EventHandler(this.btn검색_Click);
            // 
            // dtp엔드
            // 
            this.dtp엔드._BorderColor = System.Drawing.Color.DarkTurquoise;
            this.dtp엔드._FocusedBackColor = System.Drawing.Color.White;
            this.dtp엔드.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp엔드.Location = new System.Drawing.Point(511, 7);
            this.dtp엔드.Name = "dtp엔드";
            this.dtp엔드.Size = new System.Drawing.Size(99, 21);
            this.dtp엔드.TabIndex = 407;
            // 
            // dtp스타트
            // 
            this.dtp스타트._BorderColor = System.Drawing.Color.DarkTurquoise;
            this.dtp스타트._FocusedBackColor = System.Drawing.Color.White;
            this.dtp스타트.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp스타트.Location = new System.Drawing.Point(377, 6);
            this.dtp스타트.Name = "dtp스타트";
            this.dtp스타트.Size = new System.Drawing.Size(99, 21);
            this.dtp스타트.TabIndex = 406;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(482, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 23);
            this.label3.TabIndex = 405;
            this.label3.Text = "~";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(289, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 23);
            this.label1.TabIndex = 404;
            this.label1.Text = "조회일자";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.btn_close.Location = new System.Drawing.Point(1288, 2);
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
            this.lbl_title.Size = new System.Drawing.Size(145, 30);
            this.lbl_title.TabIndex = 93;
            this.lbl_title.Text = "출하정보조회";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.itemGrid);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1360, 681);
            this.panel1.TabIndex = 23;
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
            this.ITEM_CD,
            this.ITEM_NM2,
            this.SPEC,
            this.매출처,
            this.ORD_DATE,
            this.ORD_NUM,
            this.ORD_QTY,
            this.ORD_PRICE,
            this.ORD_AMT,
            this.담당사원,
            this.배송일자,
            this.배송번호,
            this.DELIVERY_QTY,
            this.배송사원,
            this.배송상태,
            this.배송완료일자});
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
            this.itemGrid.Size = new System.Drawing.Size(1360, 681);
            this.itemGrid.TabIndex = 380;
            // 
            // ITEM_CD
            // 
            this.ITEM_CD.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ITEM_CD.Frozen = true;
            this.ITEM_CD.HeaderText = "제품코드";
            this.ITEM_CD.Name = "ITEM_CD";
            this.ITEM_CD.ReadOnly = true;
            this.ITEM_CD.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ITEM_CD.Width = 99;
            // 
            // ITEM_NM2
            // 
            this.ITEM_NM2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ITEM_NM2.Frozen = true;
            this.ITEM_NM2.HeaderText = "제품명";
            this.ITEM_NM2.Name = "ITEM_NM2";
            this.ITEM_NM2.ReadOnly = true;
            this.ITEM_NM2.Width = 83;
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
            // 담당사원
            // 
            this.담당사원.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.담당사원.HeaderText = "담당사원";
            this.담당사원.Name = "담당사원";
            this.담당사원.ReadOnly = true;
            this.담당사원.Width = 99;
            // 
            // 배송일자
            // 
            this.배송일자.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.배송일자.HeaderText = "배송일자";
            this.배송일자.Name = "배송일자";
            this.배송일자.ReadOnly = true;
            this.배송일자.Width = 99;
            // 
            // 배송번호
            // 
            this.배송번호.HeaderText = "배송번호";
            this.배송번호.Name = "배송번호";
            this.배송번호.ReadOnly = true;
            // 
            // DELIVERY_QTY
            // 
            this.DELIVERY_QTY.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.DELIVERY_QTY.HeaderText = "배송수량";
            this.DELIVERY_QTY.Name = "DELIVERY_QTY";
            this.DELIVERY_QTY.ReadOnly = true;
            this.DELIVERY_QTY.Width = 99;
            // 
            // 배송사원
            // 
            this.배송사원.HeaderText = "배송사원";
            this.배송사원.Name = "배송사원";
            this.배송사원.ReadOnly = true;
            // 
            // 배송상태
            // 
            this.배송상태.HeaderText = "배송상태";
            this.배송상태.Name = "배송상태";
            this.배송상태.ReadOnly = true;
            // 
            // 배송완료일자
            // 
            this.배송완료일자.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.배송완료일자.HeaderText = "배송완료일자";
            this.배송완료일자.Name = "배송완료일자";
            this.배송완료일자.ReadOnly = true;
            this.배송완료일자.Width = 131;
            // 
            // frm출하정보조회
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1360, 714);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "frm출하정보조회";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frm출하정보조회";
            this.Load += new System.EventHandler(this.frm출하정보조회_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.itemGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Button btn검색;
        private Controls.conDateTimePicker dtp엔드;
        private Controls.conDateTimePicker dtp스타트;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView itemGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn ITEM_CD;
        private System.Windows.Forms.DataGridViewTextBoxColumn ITEM_NM2;
        private System.Windows.Forms.DataGridViewTextBoxColumn SPEC;
        private System.Windows.Forms.DataGridViewTextBoxColumn 매출처;
        private System.Windows.Forms.DataGridViewTextBoxColumn ORD_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn ORD_NUM;
        private System.Windows.Forms.DataGridViewTextBoxColumn ORD_QTY;
        private System.Windows.Forms.DataGridViewTextBoxColumn ORD_PRICE;
        private System.Windows.Forms.DataGridViewTextBoxColumn ORD_AMT;
        private System.Windows.Forms.DataGridViewTextBoxColumn 담당사원;
        private System.Windows.Forms.DataGridViewTextBoxColumn 배송일자;
        private System.Windows.Forms.DataGridViewTextBoxColumn 배송번호;
        private System.Windows.Forms.DataGridViewTextBoxColumn DELIVERY_QTY;
        private System.Windows.Forms.DataGridViewTextBoxColumn 배송사원;
        private System.Windows.Forms.DataGridViewTextBoxColumn 배송상태;
        private System.Windows.Forms.DataGridViewTextBoxColumn 배송완료일자;
    }
}