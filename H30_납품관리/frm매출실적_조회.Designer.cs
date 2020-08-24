namespace MES.H30_납품관리
{
    partial class frm매출실적_조회
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm매출실적_조회));
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgv매출실적 = new MES.Controls.myDataGridView();
            this.담당사원 = new MES.Controls.DataGridViewTextBoxColumnEx();
            this.매출일자 = new MES.Controls.DataGridViewTextBoxColumnEx();
            this.매출번호 = new MES.Controls.DataGridViewTextBoxColumnEx();
            this.제품명 = new MES.Controls.DataGridViewTextBoxColumnEx();
            this.거래처 = new MES.Controls.DataGridViewTextBoxColumnEx();
            this.수량 = new MES.Controls.DataGridViewTextBoxColumnEx();
            this.단가 = new MES.Controls.DataGridViewTextBoxColumnEx();
            this.금액 = new MES.Controls.DataGridViewTextBoxColumnEx();
            this.매출구분 = new MES.Controls.DataGridViewTextBoxColumnEx();
            this.lbl_title = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn검색 = new System.Windows.Forms.Button();
            this.dtp엔드 = new MES.Controls.conDateTimePicker();
            this.dtp스타트 = new MES.Controls.conDateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_close = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv매출실적)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.dgv매출실적);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1360, 681);
            this.panel1.TabIndex = 22;
            // 
            // dgv매출실적
            // 
            this.dgv매출실적.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.dgv매출실적.AllowUserToAddRows = false;
            this.dgv매출실적.AllowUserToDeleteRows = false;
            this.dgv매출실적.AllowUserToOrderColumns = true;
            this.dgv매출실적.AllowUserToResizeColumns = false;
            this.dgv매출실적.AllowUserToResizeRows = false;
            this.dgv매출실적.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv매출실적.BackgroundColor = System.Drawing.Color.White;
            this.dgv매출실적.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.PowderBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv매출실적.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv매출실적.ColumnHeadersHeight = 40;
            this.dgv매출실적.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.담당사원,
            this.매출일자,
            this.매출번호,
            this.제품명,
            this.거래처,
            this.수량,
            this.단가,
            this.금액,
            this.매출구분});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv매출실적.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgv매출실적.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv매출실적.EnableHeadersVisualStyles = false;
            this.dgv매출실적.GridColor = System.Drawing.Color.PowderBlue;
            this.dgv매출실적.Location = new System.Drawing.Point(0, 0);
            this.dgv매출실적.Name = "dgv매출실적";
            this.dgv매출실적.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv매출실적.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgv매출실적.RowHeadersVisible = false;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black;
            this.dgv매출실적.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgv매출실적.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F);
            this.dgv매출실적.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgv매출실적.RowTemplate.Height = 30;
            this.dgv매출실적.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv매출실적.Size = new System.Drawing.Size(1360, 681);
            this.dgv매출실적.TabIndex = 383;
            // 
            // 담당사원
            // 
            this.담당사원.HeaderText = "담당사원";
            this.담당사원.Name = "담당사원";
            this.담당사원.ReadOnly = true;
            this.담당사원.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.담당사원.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // 매출일자
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.매출일자.DefaultCellStyle = dataGridViewCellStyle2;
            this.매출일자.HeaderText = "매출일자";
            this.매출일자.Name = "매출일자";
            this.매출일자.ReadOnly = true;
            this.매출일자.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.매출일자.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // 매출번호
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.매출번호.DefaultCellStyle = dataGridViewCellStyle3;
            this.매출번호.HeaderText = "매출번호";
            this.매출번호.Name = "매출번호";
            this.매출번호.ReadOnly = true;
            this.매출번호.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.매출번호.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // 제품명
            // 
            this.제품명.HeaderText = "제품명";
            this.제품명.Name = "제품명";
            this.제품명.ReadOnly = true;
            this.제품명.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.제품명.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // 거래처
            // 
            this.거래처.HeaderText = "거래처";
            this.거래처.Name = "거래처";
            this.거래처.ReadOnly = true;
            this.거래처.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.거래처.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // 수량
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.수량.DefaultCellStyle = dataGridViewCellStyle4;
            this.수량.HeaderText = "수량";
            this.수량.Name = "수량";
            this.수량.ReadOnly = true;
            this.수량.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.수량.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // 단가
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.단가.DefaultCellStyle = dataGridViewCellStyle5;
            this.단가.HeaderText = "단가";
            this.단가.Name = "단가";
            this.단가.ReadOnly = true;
            this.단가.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.단가.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // 금액
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.금액.DefaultCellStyle = dataGridViewCellStyle6;
            this.금액.HeaderText = "금액";
            this.금액.Name = "금액";
            this.금액.ReadOnly = true;
            this.금액.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.금액.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // 매출구분
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.매출구분.DefaultCellStyle = dataGridViewCellStyle7;
            this.매출구분.HeaderText = "매출구분";
            this.매출구분.Name = "매출구분";
            this.매출구분.ReadOnly = true;
            this.매출구분.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.매출구분.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.lbl_title.Location = new System.Drawing.Point(9, -2); //new System.Drawing.Point(10, 5);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(153, 30);
            this.lbl_title.TabIndex = 93;
            this.lbl_title.Text = "매출실적 조회";
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
            this.btn검색.Location = new System.Drawing.Point(835, 0);
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
            this.dtp엔드.Location = new System.Drawing.Point(714, 5);
            this.dtp엔드.Name = "dtp엔드";
            this.dtp엔드.Size = new System.Drawing.Size(99, 21);
            this.dtp엔드.TabIndex = 407;
            // 
            // dtp스타트
            // 
            this.dtp스타트._BorderColor = System.Drawing.Color.DarkTurquoise;
            this.dtp스타트._FocusedBackColor = System.Drawing.Color.White;
            this.dtp스타트.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp스타트.Location = new System.Drawing.Point(580, 4);
            this.dtp스타트.Name = "dtp스타트";
            this.dtp스타트.Size = new System.Drawing.Size(99, 21);
            this.dtp스타트.TabIndex = 406;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(685, 4);
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
            this.label1.Location = new System.Drawing.Point(492, 3);
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
            // frm매출실적_조회
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1360, 714);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "frm매출실적_조회";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frm매출실적_조회";
            this.Load += new System.EventHandler(this.frm매출실적_조회_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv매출실적)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.DataGridView dgv매출실적;
        private System.Windows.Forms.Button btn검색;
        private Controls.conDateTimePicker dtp엔드;
        private Controls.conDateTimePicker dtp스타트;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private Controls.DataGridViewTextBoxColumnEx 담당사원;
        private Controls.DataGridViewTextBoxColumnEx 매출일자;
        private Controls.DataGridViewTextBoxColumnEx 매출번호;
        private Controls.DataGridViewTextBoxColumnEx 제품명;
        private Controls.DataGridViewTextBoxColumnEx 거래처;
        private Controls.DataGridViewTextBoxColumnEx 수량;
        private Controls.DataGridViewTextBoxColumnEx 단가;
        private Controls.DataGridViewTextBoxColumnEx 금액;
        private Controls.DataGridViewTextBoxColumnEx 매출구분;
    }
}