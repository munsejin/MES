namespace MES.P50_QUA
{
    partial class frm불량내역조회
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm불량내역조회));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_title = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.RAW = new System.Windows.Forms.TabPage();
            this.dgv_raw_poor = new MES.Controls.myDataGridView();
            this.POOR_NM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RAW_NM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.POOR_AMT1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.POOR_DATE1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CHK_NM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CHK_M = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CHK_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_raw_srch = new MES.Controls.conTextBox();
            this.btn_raw_srch = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dtp_raw_start = new System.Windows.Forms.DateTimePicker();
            this.dtp_raw_end = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.FLOW = new System.Windows.Forms.TabPage();
            this.cmb_cd_srch = new MES.Controls.conComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.inputRmGrid = new MES.Controls.myDataGridView();
            this.LOT_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.POOR_TYPE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FLOW_NM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.POOR_AMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.POOR_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.POOR_CMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FLOW_CD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_srch = new MES.Controls.conTextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.end_date = new System.Windows.Forms.DateTimePicker();
            this.start_date = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
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
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.RAW.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_raw_poor)).BeginInit();
            this.FLOW.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inputRmGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.lbl_title);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.panel2.ForeColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1342, 33);
            this.panel2.TabIndex = 11;
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.Font = new System.Drawing.Font("SpoqaHanSans-Bold", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.lbl_title.Location = new System.Drawing.Point(9, -2); //new System.Drawing.Point(6, 3);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(120, 28);
            this.lbl_title.TabIndex = 93;
            this.lbl_title.Text = "제품불량내역";
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
            this.btnClose.Location = new System.Drawing.Point(1269, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(70, 29);
            this.btnClose.TabIndex = 10;
            this.btnClose.Tag = "종료";
            this.btnClose.Text = "닫기";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1342, 676);
            this.panel1.TabIndex = 94;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.RAW);
            this.tabControl1.Controls.Add(this.FLOW);
            this.tabControl1.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1339, 676);
            this.tabControl1.TabIndex = 0;
            // 
            // RAW
            // 
            this.RAW.Controls.Add(this.dgv_raw_poor);
            this.RAW.Controls.Add(this.label3);
            this.RAW.Controls.Add(this.txt_raw_srch);
            this.RAW.Controls.Add(this.btn_raw_srch);
            this.RAW.Controls.Add(this.label4);
            this.RAW.Controls.Add(this.dtp_raw_start);
            this.RAW.Controls.Add(this.dtp_raw_end);
            this.RAW.Controls.Add(this.label5);
            this.RAW.Location = new System.Drawing.Point(4, 31);
            this.RAW.Name = "RAW";
            this.RAW.Padding = new System.Windows.Forms.Padding(3);
            this.RAW.Size = new System.Drawing.Size(1331, 641);
            this.RAW.TabIndex = 0;
            this.RAW.Text = "원자재불량내역";
            this.RAW.UseVisualStyleBackColor = true;
            // 
            // dgv_raw_poor
            // 
            this.dgv_raw_poor.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.dgv_raw_poor.AllowUserToAddRows = false;
            this.dgv_raw_poor.AllowUserToDeleteRows = false;
            this.dgv_raw_poor.AllowUserToResizeColumns = false;
            this.dgv_raw_poor.AllowUserToResizeRows = false;
            this.dgv_raw_poor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_raw_poor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_raw_poor.BackgroundColor = System.Drawing.Color.White;
            this.dgv_raw_poor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_raw_poor.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_raw_poor.ColumnHeadersHeight = 35;
            this.dgv_raw_poor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_raw_poor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.POOR_NM,
            this.RAW_NM,
            this.POOR_AMT1,
            this.POOR_DATE1,
            this.CHK_NM,
            this.CHK_M,
            this.CHK_DATE});
            this.dgv_raw_poor.EnableHeadersVisualStyles = false;
            this.dgv_raw_poor.GridColor = System.Drawing.Color.PowderBlue;
            this.dgv_raw_poor.Location = new System.Drawing.Point(4, 38);
            this.dgv_raw_poor.Name = "dgv_raw_poor";
            this.dgv_raw_poor.RowHeadersVisible = false;
            this.dgv_raw_poor.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.dgv_raw_poor.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgv_raw_poor.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F);
            this.dgv_raw_poor.RowTemplate.Height = 30;
            this.dgv_raw_poor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_raw_poor.Size = new System.Drawing.Size(1322, 601);
            this.dgv_raw_poor.TabIndex = 417;
            // 
            // POOR_NM
            // 
            this.POOR_NM.FillWeight = 208F;
            this.POOR_NM.HeaderText = "불량형태";
            this.POOR_NM.MinimumWidth = 72;
            this.POOR_NM.Name = "POOR_NM";
            this.POOR_NM.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.POOR_NM.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // RAW_NM
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.RAW_NM.DefaultCellStyle = dataGridViewCellStyle2;
            this.RAW_NM.FillWeight = 106F;
            this.RAW_NM.HeaderText = "원자재/공정명";
            this.RAW_NM.MinimumWidth = 106;
            this.RAW_NM.Name = "RAW_NM";
            this.RAW_NM.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.RAW_NM.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // POOR_AMT1
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.POOR_AMT1.DefaultCellStyle = dataGridViewCellStyle3;
            this.POOR_AMT1.FillWeight = 205F;
            this.POOR_AMT1.HeaderText = "불량수량";
            this.POOR_AMT1.MinimumWidth = 72;
            this.POOR_AMT1.Name = "POOR_AMT1";
            this.POOR_AMT1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.POOR_AMT1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // POOR_DATE1
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.POOR_DATE1.DefaultCellStyle = dataGridViewCellStyle4;
            this.POOR_DATE1.FillWeight = 256F;
            this.POOR_DATE1.HeaderText = "불량등록일시";
            this.POOR_DATE1.MinimumWidth = 100;
            this.POOR_DATE1.Name = "POOR_DATE1";
            this.POOR_DATE1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.POOR_DATE1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // CHK_NM
            // 
            this.CHK_NM.FillWeight = 145F;
            this.CHK_NM.HeaderText = "검사항목";
            this.CHK_NM.MinimumWidth = 72;
            this.CHK_NM.Name = "CHK_NM";
            this.CHK_NM.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CHK_NM.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // CHK_M
            // 
            this.CHK_M.FillWeight = 200F;
            this.CHK_M.HeaderText = "검사기구";
            this.CHK_M.MinimumWidth = 72;
            this.CHK_M.Name = "CHK_M";
            this.CHK_M.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CHK_M.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // CHK_DATE
            // 
            this.CHK_DATE.FillWeight = 199F;
            this.CHK_DATE.HeaderText = "검사시기";
            this.CHK_DATE.MinimumWidth = 72;
            this.CHK_DATE.Name = "CHK_DATE";
            this.CHK_DATE.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CHK_DATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(326, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 29);
            this.label3.TabIndex = 416;
            this.label3.Text = "원자재명 ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_raw_srch
            // 
            this.txt_raw_srch._AutoTab = true;
            this.txt_raw_srch._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.txt_raw_srch._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txt_raw_srch._WaterMarkColor = System.Drawing.Color.Gray;
            this.txt_raw_srch._WaterMarkText = "";
            this.txt_raw_srch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_raw_srch.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_raw_srch.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.txt_raw_srch.Location = new System.Drawing.Point(418, 6);
            this.txt_raw_srch.MaxLength = 20;
            this.txt_raw_srch.Name = "txt_raw_srch";
            this.txt_raw_srch.Size = new System.Drawing.Size(186, 29);
            this.txt_raw_srch.TabIndex = 415;
            this.txt_raw_srch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_raw_srch_KeyDown);
            // 
            // btn_raw_srch
            // 
            this.btn_raw_srch.BackColor = System.Drawing.Color.Transparent;
            this.btn_raw_srch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_raw_srch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_raw_srch.FlatAppearance.BorderSize = 0;
            this.btn_raw_srch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btn_raw_srch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_raw_srch.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_raw_srch.Image = ((System.Drawing.Image)(resources.GetObject("btn_raw_srch.Image")));
            this.btn_raw_srch.Location = new System.Drawing.Point(607, 5);
            this.btn_raw_srch.Name = "btn_raw_srch";
            this.btn_raw_srch.Size = new System.Drawing.Size(33, 30);
            this.btn_raw_srch.TabIndex = 412;
            this.btn_raw_srch.Tag = "검색";
            this.btn_raw_srch.UseVisualStyleBackColor = false;
            this.btn_raw_srch.Click += new System.EventHandler(this.btn_raw_srch_Click);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(5, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 29);
            this.label4.TabIndex = 414;
            this.label4.Text = "조회기간";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtp_raw_start
            // 
            this.dtp_raw_start.Checked = false;
            this.dtp_raw_start.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtp_raw_start.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_raw_start.Location = new System.Drawing.Point(214, 5);
            this.dtp_raw_start.Name = "dtp_raw_start";
            this.dtp_raw_start.Size = new System.Drawing.Size(100, 29);
            this.dtp_raw_start.TabIndex = 411;
            this.dtp_raw_start.Value = new System.DateTime(2018, 10, 8, 0, 0, 0, 0);
            // 
            // dtp_raw_end
            // 
            this.dtp_raw_end.Checked = false;
            this.dtp_raw_end.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtp_raw_end.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_raw_end.Location = new System.Drawing.Point(94, 5);
            this.dtp_raw_end.Name = "dtp_raw_end";
            this.dtp_raw_end.Size = new System.Drawing.Size(100, 29);
            this.dtp_raw_end.TabIndex = 410;
            this.dtp_raw_end.Value = new System.DateTime(2018, 10, 8, 0, 0, 0, 0);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(187, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 23);
            this.label5.TabIndex = 409;
            this.label5.Text = "~";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FLOW
            // 
            this.FLOW.Controls.Add(this.cmb_cd_srch);
            this.FLOW.Controls.Add(this.label1);
            this.FLOW.Controls.Add(this.inputRmGrid);
            this.FLOW.Controls.Add(this.txt_srch);
            this.FLOW.Controls.Add(this.btnSearch);
            this.FLOW.Controls.Add(this.label2);
            this.FLOW.Controls.Add(this.end_date);
            this.FLOW.Controls.Add(this.start_date);
            this.FLOW.Controls.Add(this.label7);
            this.FLOW.Location = new System.Drawing.Point(4, 31);
            this.FLOW.Name = "FLOW";
            this.FLOW.Padding = new System.Windows.Forms.Padding(3);
            this.FLOW.Size = new System.Drawing.Size(1331, 641);
            this.FLOW.TabIndex = 1;
            this.FLOW.Text = "공정불량내역";
            this.FLOW.UseVisualStyleBackColor = true;
            // 
            // cmb_cd_srch
            // 
            this.cmb_cd_srch._BorderColor = System.Drawing.Color.Transparent;
            this.cmb_cd_srch._FocusedBackColor = System.Drawing.Color.White;
            this.cmb_cd_srch.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cmb_cd_srch.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cmb_cd_srch.FormattingEnabled = true;
            this.cmb_cd_srch.Location = new System.Drawing.Point(401, 5);
            this.cmb_cd_srch.Name = "cmb_cd_srch";
            this.cmb_cd_srch.Size = new System.Drawing.Size(88, 30);
            this.cmb_cd_srch.TabIndex = 408;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(329, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 29);
            this.label1.TabIndex = 407;
            this.label1.Text = "검색어";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // inputRmGrid
            // 
            this.inputRmGrid.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.inputRmGrid.AllowUserToAddRows = false;
            this.inputRmGrid.AllowUserToDeleteRows = false;
            this.inputRmGrid.AllowUserToResizeColumns = false;
            this.inputRmGrid.AllowUserToResizeRows = false;
            this.inputRmGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputRmGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.inputRmGrid.BackgroundColor = System.Drawing.Color.White;
            this.inputRmGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.inputRmGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.inputRmGrid.ColumnHeadersHeight = 35;
            this.inputRmGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.inputRmGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LOT_NO,
            this.POOR_TYPE,
            this.FLOW_NM,
            this.POOR_AMT,
            this.POOR_DATE,
            this.POOR_CMT,
            this.FLOW_CD});
            this.inputRmGrid.EnableHeadersVisualStyles = false;
            this.inputRmGrid.GridColor = System.Drawing.Color.PowderBlue;
            this.inputRmGrid.Location = new System.Drawing.Point(4, 39);
            this.inputRmGrid.Name = "inputRmGrid";
            this.inputRmGrid.RowHeadersVisible = false;
            this.inputRmGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            this.inputRmGrid.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.inputRmGrid.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F);
            this.inputRmGrid.RowTemplate.Height = 30;
            this.inputRmGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.inputRmGrid.Size = new System.Drawing.Size(1322, 599);
            this.inputRmGrid.TabIndex = 403;
            this.inputRmGrid.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.inputRmGrid_CellFormatting);
            this.inputRmGrid.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.inputRmGrid_CellPainting);
            // 
            // LOT_NO
            // 
            this.LOT_NO.FillWeight = 133F;
            this.LOT_NO.HeaderText = "LOT_NO";
            this.LOT_NO.MinimumWidth = 74;
            this.LOT_NO.Name = "LOT_NO";
            this.LOT_NO.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.LOT_NO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // POOR_TYPE
            // 
            this.POOR_TYPE.FillWeight = 255F;
            this.POOR_TYPE.HeaderText = "불량형태";
            this.POOR_TYPE.MinimumWidth = 72;
            this.POOR_TYPE.Name = "POOR_TYPE";
            this.POOR_TYPE.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.POOR_TYPE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // FLOW_NM
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.FLOW_NM.DefaultCellStyle = dataGridViewCellStyle7;
            this.FLOW_NM.FillWeight = 58F;
            this.FLOW_NM.HeaderText = "공정명";
            this.FLOW_NM.MinimumWidth = 58;
            this.FLOW_NM.Name = "FLOW_NM";
            this.FLOW_NM.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.FLOW_NM.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // POOR_AMT
            // 
            this.POOR_AMT.FillWeight = 240F;
            this.POOR_AMT.HeaderText = "불량수량";
            this.POOR_AMT.MinimumWidth = 72;
            this.POOR_AMT.Name = "POOR_AMT";
            this.POOR_AMT.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.POOR_AMT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // POOR_DATE
            // 
            this.POOR_DATE.FillWeight = 458F;
            this.POOR_DATE.HeaderText = "불량등록일시";
            this.POOR_DATE.MinimumWidth = 100;
            this.POOR_DATE.Name = "POOR_DATE";
            this.POOR_DATE.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.POOR_DATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // POOR_CMT
            // 
            this.POOR_CMT.FillWeight = 175F;
            this.POOR_CMT.HeaderText = "불량내용";
            this.POOR_CMT.MinimumWidth = 72;
            this.POOR_CMT.Name = "POOR_CMT";
            this.POOR_CMT.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.POOR_CMT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // FLOW_CD
            // 
            this.FLOW_CD.HeaderText = "FLOW_CD";
            this.FLOW_CD.MinimumWidth = 100;
            this.FLOW_CD.Name = "FLOW_CD";
            this.FLOW_CD.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.FLOW_CD.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FLOW_CD.Visible = false;
            // 
            // txt_srch
            // 
            this.txt_srch._AutoTab = true;
            this.txt_srch._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.txt_srch._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txt_srch._WaterMarkColor = System.Drawing.Color.Gray;
            this.txt_srch._WaterMarkText = "";
            this.txt_srch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_srch.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_srch.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.txt_srch.Location = new System.Drawing.Point(495, 5);
            this.txt_srch.MaxLength = 20;
            this.txt_srch.Name = "txt_srch";
            this.txt_srch.Size = new System.Drawing.Size(186, 29);
            this.txt_srch.TabIndex = 405;
            this.txt_srch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_srch_KeyDown);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Transparent;
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(691, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(33, 30);
            this.btnSearch.TabIndex = 402;
            this.btnSearch.Tag = "검색";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(5, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 29);
            this.label2.TabIndex = 404;
            this.label2.Text = "조회기간";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // end_date
            // 
            this.end_date.Checked = false;
            this.end_date.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.end_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.end_date.Location = new System.Drawing.Point(214, 5);
            this.end_date.Name = "end_date";
            this.end_date.Size = new System.Drawing.Size(100, 29);
            this.end_date.TabIndex = 401;
            this.end_date.Value = new System.DateTime(2018, 10, 8, 0, 0, 0, 0);
            // 
            // start_date
            // 
            this.start_date.Checked = false;
            this.start_date.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.start_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.start_date.Location = new System.Drawing.Point(94, 5);
            this.start_date.Name = "start_date";
            this.start_date.Size = new System.Drawing.Size(100, 29);
            this.start_date.TabIndex = 400;
            this.start_date.Value = new System.DateTime(2018, 10, 8, 0, 0, 0, 0);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.Location = new System.Drawing.Point(188, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 23);
            this.label7.TabIndex = 399;
            this.label7.Text = "~";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "불량형태";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 200;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewTextBoxColumn2.HeaderText = "공정명";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridViewTextBoxColumn3.HeaderText = "불량수량";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.HeaderText = "불량등록일시";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn5.HeaderText = "불량내용";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn6.HeaderText = "LOT_NO";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Visible = false;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "FLOW_CD";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Visible = false;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "불량형태";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Width = 200;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn9.DefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridViewTextBoxColumn9.FillWeight = 104.3163F;
            this.dataGridViewTextBoxColumn9.HeaderText = "원자재/공정명";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn10.DefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridViewTextBoxColumn10.FillWeight = 87.05114F;
            this.dataGridViewTextBoxColumn10.HeaderText = "불량수량";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn11.HeaderText = "불량등록일시";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn12.FillWeight = 104.3163F;
            this.dataGridViewTextBoxColumn12.HeaderText = "불량등록일시";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn13.FillWeight = 104.3163F;
            this.dataGridViewTextBoxColumn13.HeaderText = "불량내용";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.HeaderText = "FLOW_CD";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.Visible = false;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "검사항목";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "검사기구";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "검사시기";
            this.Column3.Name = "Column3";
            // 
            // frm불량내역조회
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1342, 709);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "frm불량내역조회";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Tag = "";
            this.Text = "frm불량내역조회";
            this.Load += new System.EventHandler(this.frm불량내역조회_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.RAW.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_raw_poor)).EndInit();
            this.FLOW.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.inputRmGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage RAW;
        private System.Windows.Forms.TabPage FLOW;
        private System.Windows.Forms.Label label1;
        private Controls.conTextBox txt_srch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker end_date;
        private System.Windows.Forms.DateTimePicker start_date;
        private System.Windows.Forms.Label label7;
        private Controls.conComboBox cmb_cd_srch;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.Label label3;
        private Controls.conTextBox txt_raw_srch;
        private System.Windows.Forms.Button btn_raw_srch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtp_raw_start;
        private System.Windows.Forms.DateTimePicker dtp_raw_end;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn LOT_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn POOR_TYPE;
        private System.Windows.Forms.DataGridViewTextBoxColumn FLOW_NM;
        private System.Windows.Forms.DataGridViewTextBoxColumn POOR_AMT;
        private System.Windows.Forms.DataGridViewTextBoxColumn POOR_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn POOR_CMT;
        private System.Windows.Forms.DataGridViewTextBoxColumn FLOW_CD;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn POOR_NM;
        private System.Windows.Forms.DataGridViewTextBoxColumn RAW_NM;
        private System.Windows.Forms.DataGridViewTextBoxColumn POOR_AMT1;
        private System.Windows.Forms.DataGridViewTextBoxColumn POOR_DATE1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CHK_NM;
        private System.Windows.Forms.DataGridViewTextBoxColumn CHK_M;
        private System.Windows.Forms.DataGridViewTextBoxColumn CHK_DATE;
        private Controls.myDataGridView inputRmGrid;
        private Controls.myDataGridView dgv_raw_poor;
    }
}