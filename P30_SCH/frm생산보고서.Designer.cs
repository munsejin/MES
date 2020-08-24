namespace MES.P30_SCH
{
    partial class frm생산보고서
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm생산보고서));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_title = new System.Windows.Forms.Label();
            this.lbl_end_date = new MES.Controls.conLabel();
            this.lbl_chk_gbn = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.lbl_start_date = new MES.Controls.conLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_SetDate = new System.Windows.Forms.Button();
            this.chart_item_detail2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btn_day = new System.Windows.Forms.Button();
            this.btn_week = new System.Windows.Forms.Button();
            this.btn_month = new System.Windows.Forms.Button();
            this.dataItemGrid2 = new MES.Controls.myDataGridView();
            this.공정일자 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.제품명 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LOTNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.완제품공정명 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.공정코드 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.생산수량 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.불량유형 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.불량건수 = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn26 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_item_detail2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataItemGrid2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.lbl_title);
            this.panel2.Controls.Add(this.lbl_end_date);
            this.panel2.Controls.Add(this.lbl_chk_gbn);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.lbl_start_date);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1360, 33);
            this.panel2.TabIndex = 8;
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.Font = new System.Drawing.Font("SpoqaHanSans-Bold", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.lbl_title.Location = new System.Drawing.Point(9, -2); //new System.Drawing.Point(10, 3);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(108, 29);
            this.lbl_title.TabIndex = 386;
            this.lbl_title.Text = "생산보고서";
            // 
            // lbl_end_date
            // 
            this.lbl_end_date._BorderColor = System.Drawing.Color.Black;
            this.lbl_end_date.AutoSize = true;
            this.lbl_end_date.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F);
            this.lbl_end_date.Location = new System.Drawing.Point(475, 5);
            this.lbl_end_date.Name = "lbl_end_date";
            this.lbl_end_date.Size = new System.Drawing.Size(75, 22);
            this.lbl_end_date.TabIndex = 106;
            this.lbl_end_date.Text = "end_date";
            this.lbl_end_date.Visible = false;
            // 
            // lbl_chk_gbn
            // 
            this.lbl_chk_gbn.BackColor = System.Drawing.Color.PowderBlue;
            this.lbl_chk_gbn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_chk_gbn.Location = new System.Drawing.Point(747, 5);
            this.lbl_chk_gbn.Name = "lbl_chk_gbn";
            this.lbl_chk_gbn.Size = new System.Drawing.Size(100, 22);
            this.lbl_chk_gbn.TabIndex = 338;
            this.lbl_chk_gbn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_chk_gbn.Visible = false;
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
            this.btnClose.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.btnClose.Image = global::MES.Properties.Resources.newnewCloseBtn;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(1283, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(74, 29);
            this.btnClose.TabIndex = 10;
            this.btnClose.TabStop = false;
            this.btnClose.Tag = "종료";
            this.btnClose.Text = "닫기";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lbl_start_date
            // 
            this.lbl_start_date._BorderColor = System.Drawing.Color.Black;
            this.lbl_start_date.AutoSize = true;
            this.lbl_start_date.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F);
            this.lbl_start_date.Location = new System.Drawing.Point(411, 5);
            this.lbl_start_date.Name = "lbl_start_date";
            this.lbl_start_date.Size = new System.Drawing.Size(82, 22);
            this.lbl_start_date.TabIndex = 105;
            this.lbl_start_date.Text = "start_date";
            this.lbl_start_date.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(32, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 22);
            this.label1.TabIndex = 103;
            this.label1.Text = "기간설정";
            // 
            // btn_SetDate
            // 
            this.btn_SetDate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_SetDate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightBlue;
            this.btn_SetDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SetDate.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_SetDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_SetDate.Location = new System.Drawing.Point(34, 58);
            this.btn_SetDate.Name = "btn_SetDate";
            this.btn_SetDate.Size = new System.Drawing.Size(214, 34);
            this.btn_SetDate.TabIndex = 104;
            this.btn_SetDate.Text = "2020-06-09 - 2020-06-30 ▼";
            this.btn_SetDate.UseVisualStyleBackColor = true;
            this.btn_SetDate.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btn_SetDate_MouseClick);
            // 
            // chart_item_detail2
            // 
            this.chart_item_detail2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chart_item_detail2.BorderlineColor = System.Drawing.Color.Black;
            this.chart_item_detail2.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.AxisX.Interval = 1D;
            chartArea1.Name = "ChartArea1";
            this.chart_item_detail2.ChartAreas.Add(chartArea1);
            legend1.Alignment = System.Drawing.StringAlignment.Center;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend1.Name = "Legend1";
            this.chart_item_detail2.Legends.Add(legend1);
            this.chart_item_detail2.Location = new System.Drawing.Point(34, 146);
            this.chart_item_detail2.Name = "chart_item_detail2";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart_item_detail2.Series.Add(series1);
            this.chart_item_detail2.Size = new System.Drawing.Size(1292, 341);
            this.chart_item_detail2.TabIndex = 389;
            this.chart_item_detail2.Text = "원자재";
            // 
            // btn_day
            // 
            this.btn_day.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_day.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_day.FlatAppearance.BorderSize = 2;
            this.btn_day.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_day.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_day.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_day.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_day.Location = new System.Drawing.Point(34, 97);
            this.btn_day.Name = "btn_day";
            this.btn_day.Size = new System.Drawing.Size(112, 43);
            this.btn_day.TabIndex = 390;
            this.btn_day.Text = "일간";
            this.btn_day.UseVisualStyleBackColor = false;
            this.btn_day.Click += new System.EventHandler(this.btn_day_Click);
            // 
            // btn_week
            // 
            this.btn_week.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_week.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_week.FlatAppearance.BorderSize = 2;
            this.btn_week.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_week.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_week.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_week.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_week.Location = new System.Drawing.Point(152, 97);
            this.btn_week.Name = "btn_week";
            this.btn_week.Size = new System.Drawing.Size(112, 43);
            this.btn_week.TabIndex = 391;
            this.btn_week.Text = "주간";
            this.btn_week.UseVisualStyleBackColor = false;
            this.btn_week.Click += new System.EventHandler(this.btn_week_Click);
            // 
            // btn_month
            // 
            this.btn_month.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_month.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_month.FlatAppearance.BorderSize = 2;
            this.btn_month.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_month.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_month.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_month.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_month.Location = new System.Drawing.Point(270, 97);
            this.btn_month.Name = "btn_month";
            this.btn_month.Size = new System.Drawing.Size(112, 43);
            this.btn_month.TabIndex = 392;
            this.btn_month.Text = "월간";
            this.btn_month.UseVisualStyleBackColor = false;
            this.btn_month.Click += new System.EventHandler(this.btn_month_Click);
            // 
            // dataItemGrid2
            // 
            this.dataItemGrid2.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.dataItemGrid2.AllowUserToAddRows = false;
            this.dataItemGrid2.AllowUserToDeleteRows = false;
            this.dataItemGrid2.AllowUserToResizeColumns = false;
            this.dataItemGrid2.AllowUserToResizeRows = false;
            this.dataItemGrid2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataItemGrid2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataItemGrid2.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataItemGrid2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataItemGrid2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataItemGrid2.ColumnHeadersHeight = 30;
            this.dataItemGrid2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.공정일자,
            this.제품명,
            this.LOTNO,
            this.완제품공정명,
            this.공정코드,
            this.생산수량,
            this.불량유형,
            this.불량건수});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataItemGrid2.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataItemGrid2.EnableHeadersVisualStyles = false;
            this.dataItemGrid2.GridColor = System.Drawing.Color.PowderBlue;
            this.dataItemGrid2.Location = new System.Drawing.Point(34, 500);
            this.dataItemGrid2.Name = "dataItemGrid2";
            this.dataItemGrid2.ReadOnly = true;
            this.dataItemGrid2.RowHeadersVisible = false;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.dataItemGrid2.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataItemGrid2.RowTemplate.Height = 23;
            this.dataItemGrid2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataItemGrid2.Size = new System.Drawing.Size(1292, 195);
            this.dataItemGrid2.TabIndex = 393;
            this.dataItemGrid2.TabStop = false;
            // 
            // 공정일자
            // 
            this.공정일자.FillWeight = 72F;
            this.공정일자.HeaderText = "공정일자";
            this.공정일자.MinimumWidth = 72;
            this.공정일자.Name = "공정일자";
            this.공정일자.ReadOnly = true;
            this.공정일자.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.공정일자.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // 제품명
            // 
            this.제품명.FillWeight = 234F;
            this.제품명.HeaderText = "제품명";
            this.제품명.MinimumWidth = 58;
            this.제품명.Name = "제품명";
            this.제품명.ReadOnly = true;
            this.제품명.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.제품명.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // LOTNO
            // 
            this.LOTNO.FillWeight = 196F;
            this.LOTNO.HeaderText = "LOT No.";
            this.LOTNO.MinimumWidth = 75;
            this.LOTNO.Name = "LOTNO";
            this.LOTNO.ReadOnly = true;
            this.LOTNO.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.LOTNO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // 완제품공정명
            // 
            this.완제품공정명.FillWeight = 181F;
            this.완제품공정명.HeaderText = "완제품공정명";
            this.완제품공정명.MinimumWidth = 100;
            this.완제품공정명.Name = "완제품공정명";
            this.완제품공정명.ReadOnly = true;
            this.완제품공정명.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.완제품공정명.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // 공정코드
            // 
            this.공정코드.FillWeight = 164F;
            this.공정코드.HeaderText = "공정코드";
            this.공정코드.MinimumWidth = 72;
            this.공정코드.Name = "공정코드";
            this.공정코드.ReadOnly = true;
            this.공정코드.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.공정코드.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // 생산수량
            // 
            this.생산수량.FillWeight = 155F;
            this.생산수량.HeaderText = "생산수량";
            this.생산수량.MinimumWidth = 72;
            this.생산수량.Name = "생산수량";
            this.생산수량.ReadOnly = true;
            this.생산수량.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.생산수량.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // 불량유형
            // 
            this.불량유형.FillWeight = 148F;
            this.불량유형.HeaderText = "불량유형";
            this.불량유형.MinimumWidth = 72;
            this.불량유형.Name = "불량유형";
            this.불량유형.ReadOnly = true;
            this.불량유형.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.불량유형.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // 불량건수
            // 
            this.불량건수.FillWeight = 139F;
            this.불량건수.HeaderText = "불량건수";
            this.불량건수.MinimumWidth = 72;
            this.불량건수.Name = "불량건수";
            this.불량건수.ReadOnly = true;
            this.불량건수.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.불량건수.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "STAFF_CD";
            this.dataGridViewTextBoxColumn1.FillWeight = 80F;
            this.dataGridViewTextBoxColumn1.HeaderText = "코드";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn2.HeaderText = "구분";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn3.FillWeight = 120F;
            this.dataGridViewTextBoxColumn3.HeaderText = "검사항목명";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "DEPT_NM";
            this.dataGridViewTextBoxColumn4.HeaderText = "검사위치";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "DEPT_NM";
            this.dataGridViewTextBoxColumn5.HeaderText = "구분코드";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Visible = false;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn6.HeaderText = "규정치";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Visible = false;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn7.HeaderText = "채용한계";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Visible = false;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn8.HeaderText = "측정기구";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Visible = false;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn9.HeaderText = "검사주기";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Visible = false;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn10.FillWeight = 80F;
            this.dataGridViewTextBoxColumn10.HeaderText = "검사주기";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Visible = false;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn11.FillWeight = 80F;
            this.dataGridViewTextBoxColumn11.HeaderText = "자재명";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn12.FillWeight = 120F;
            this.dataGridViewTextBoxColumn12.HeaderText = "구매처";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn13.HeaderText = "입고수량";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn14.HeaderText = "불량유형";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn15.HeaderText = "불량수";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn16.HeaderText = "불량률";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn17.HeaderText = "불량유형";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn18.HeaderText = "불량수";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            this.dataGridViewTextBoxColumn18.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn19
            // 
            this.dataGridViewTextBoxColumn19.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn19.HeaderText = "불량률";
            this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            this.dataGridViewTextBoxColumn19.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn20
            // 
            this.dataGridViewTextBoxColumn20.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn20.FillWeight = 80F;
            this.dataGridViewTextBoxColumn20.HeaderText = "입고일자";
            this.dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
            this.dataGridViewTextBoxColumn20.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn21
            // 
            this.dataGridViewTextBoxColumn21.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn21.HeaderText = "자재명";
            this.dataGridViewTextBoxColumn21.Name = "dataGridViewTextBoxColumn21";
            this.dataGridViewTextBoxColumn21.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn22
            // 
            this.dataGridViewTextBoxColumn22.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn22.FillWeight = 120F;
            this.dataGridViewTextBoxColumn22.HeaderText = "구매처";
            this.dataGridViewTextBoxColumn22.Name = "dataGridViewTextBoxColumn22";
            this.dataGridViewTextBoxColumn22.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn23
            // 
            this.dataGridViewTextBoxColumn23.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn23.HeaderText = "입고수량";
            this.dataGridViewTextBoxColumn23.Name = "dataGridViewTextBoxColumn23";
            this.dataGridViewTextBoxColumn23.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn24
            // 
            this.dataGridViewTextBoxColumn24.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn24.HeaderText = "불량유형";
            this.dataGridViewTextBoxColumn24.Name = "dataGridViewTextBoxColumn24";
            this.dataGridViewTextBoxColumn24.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn25
            // 
            this.dataGridViewTextBoxColumn25.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn25.HeaderText = "불량수";
            this.dataGridViewTextBoxColumn25.Name = "dataGridViewTextBoxColumn25";
            this.dataGridViewTextBoxColumn25.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn26
            // 
            this.dataGridViewTextBoxColumn26.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn26.HeaderText = "불량률";
            this.dataGridViewTextBoxColumn26.Name = "dataGridViewTextBoxColumn26";
            this.dataGridViewTextBoxColumn26.ReadOnly = true;
            // 
            // frm생산보고서
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1360, 714);
            this.Controls.Add(this.dataItemGrid2);
            this.Controls.Add(this.btn_month);
            this.Controls.Add(this.btn_week);
            this.Controls.Add(this.btn_day);
            this.Controls.Add(this.chart_item_detail2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_SetDate);
            this.Name = "frm생산보고서";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frm품질분석현황";
            this.Load += new System.EventHandler(this.frm생산보고서_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_item_detail2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataItemGrid2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lbl_chk_gbn;
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
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_SetDate;
        private Controls.conLabel lbl_end_date;
        private Controls.conLabel lbl_start_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn21;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn22;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn23;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn24;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn25;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn26;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_item_detail2;
        private System.Windows.Forms.Button btn_day;
        private System.Windows.Forms.Button btn_week;
        private System.Windows.Forms.Button btn_month;
        private System.Windows.Forms.DataGridViewTextBoxColumn 공정일자;
        private System.Windows.Forms.DataGridViewTextBoxColumn 제품명;
        private System.Windows.Forms.DataGridViewTextBoxColumn LOTNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn 완제품공정명;
        private System.Windows.Forms.DataGridViewTextBoxColumn 공정코드;
        private System.Windows.Forms.DataGridViewTextBoxColumn 생산수량;
        private System.Windows.Forms.DataGridViewTextBoxColumn 불량유형;
        private System.Windows.Forms.DataGridViewTextBoxColumn 불량건수;
        private Controls.myDataGridView dataItemGrid2;
    }
}