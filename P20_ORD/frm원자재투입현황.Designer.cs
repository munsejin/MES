namespace MES.P20_ORD
{
    partial class frm원자재투입현황
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm원자재투입현황));
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_lot = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chk_all2 = new System.Windows.Forms.CheckBox();
            this.btn_item_srch = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Srch_item = new MES.Controls.conTextBox();
            this.chk_all = new System.Windows.Forms.CheckBox();
            this.btn_raw_srch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.rawOutGrid = new MES.Controls.myDataGridView();
            this.no = new MES.Controls.DataGridViewTextBoxColumnEx();
            this.OUTPUT_DATE = new MES.Controls.DataGridViewTextBoxColumnEx();
            this.RAW_MAT_CD = new MES.Controls.DataGridViewTextBoxColumnEx();
            this.RAW_MAT_NM = new MES.Controls.DataGridViewTextBoxColumnEx();
            this.SPEC = new MES.Controls.DataGridViewTextBoxColumnEx();
            this.제품명 = new MES.Controls.DataGridViewTextBoxColumnEx();
            this.제품규격 = new MES.Controls.DataGridViewTextBoxColumnEx();
            this.TOTAL_AMT = new MES.Controls.DataGridViewTextBoxColumnEx();
            this.LOT_NO = new MES.Controls.DataGridViewTextBoxColumnEx();
            this.LOT_SUB = new MES.Controls.DataGridViewTextBoxColumnEx();
            this.수주계획 = new MES.Controls.DataGridViewTextBoxColumnEx();
            this.BAR_NUM = new MES.Controls.DataGridViewTextBoxColumnEx();
            this.txt_srch_raw = new MES.Controls.conTextBox();
            this.end_date = new System.Windows.Forms.DateTimePicker();
            this.start_date = new System.Windows.Forms.DateTimePicker();
            this.btnSrch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txt_Srch_item_cd = new MES.Controls.conTextBox();
            this.txt_srch_raw_cd = new MES.Controls.conTextBox();
            this.btn출력 = new System.Windows.Forms.Button();
            this.lbl_title = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rawOutGrid)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.txt_lot);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.chk_all2);
            this.panel1.Controls.Add(this.btn_item_srch);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txt_Srch_item);
            this.panel1.Controls.Add(this.chk_all);
            this.panel1.Controls.Add(this.btn_raw_srch);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.rawOutGrid);
            this.panel1.Controls.Add(this.txt_srch_raw);
            this.panel1.Controls.Add(this.end_date);
            this.panel1.Controls.Add(this.start_date);
            this.panel1.Controls.Add(this.btnSrch);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.panel1.Location = new System.Drawing.Point(0, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1360, 681);
            this.panel1.TabIndex = 14;
            // 
            // txt_lot
            // 
            this.txt_lot.Location = new System.Drawing.Point(913, 4);
            this.txt_lot.Name = "txt_lot";
            this.txt_lot.Size = new System.Drawing.Size(200, 29);
            this.txt_lot.TabIndex = 405;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(827, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 22);
            this.label4.TabIndex = 404;
            this.label4.Text = "LOT 필터링";
            // 
            // chk_all2
            // 
            this.chk_all2.AutoSize = true;
            this.chk_all2.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chk_all2.Location = new System.Drawing.Point(764, 5);
            this.chk_all2.Name = "chk_all2";
            this.chk_all2.Size = new System.Drawing.Size(57, 26);
            this.chk_all2.TabIndex = 402;
            this.chk_all2.Text = "전체";
            this.chk_all2.UseVisualStyleBackColor = true;
            this.chk_all2.CheckedChanged += new System.EventHandler(this.chk_all2_CheckedChanged);
            // 
            // btn_item_srch
            // 
            this.btn_item_srch.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_item_srch.Location = new System.Drawing.Point(732, 3);
            this.btn_item_srch.Margin = new System.Windows.Forms.Padding(0);
            this.btn_item_srch.Name = "btn_item_srch";
            this.btn_item_srch.Size = new System.Drawing.Size(26, 29);
            this.btn_item_srch.TabIndex = 403;
            this.btn_item_srch.Text = "▼";
            this.btn_item_srch.UseVisualStyleBackColor = true;
            this.btn_item_srch.Click += new System.EventHandler(this.btn_item_srch_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(579, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 22);
            this.label3.TabIndex = 401;
            this.label3.Text = "제품";
            // 
            // txt_Srch_item
            // 
            this.txt_Srch_item._AutoTab = true;
            this.txt_Srch_item._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.txt_Srch_item._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txt_Srch_item._WaterMarkColor = System.Drawing.Color.Gray;
            this.txt_Srch_item._WaterMarkText = "";
            this.txt_Srch_item.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Srch_item.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_Srch_item.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.txt_Srch_item.Location = new System.Drawing.Point(618, 4);
            this.txt_Srch_item.MaxLength = 20;
            this.txt_Srch_item.Name = "txt_Srch_item";
            this.txt_Srch_item.Size = new System.Drawing.Size(115, 27);
            this.txt_Srch_item.TabIndex = 400;
            // 
            // chk_all
            // 
            this.chk_all.AutoSize = true;
            this.chk_all.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chk_all.Location = new System.Drawing.Point(516, 5);
            this.chk_all.Name = "chk_all";
            this.chk_all.Size = new System.Drawing.Size(57, 26);
            this.chk_all.TabIndex = 398;
            this.chk_all.Text = "전체";
            this.chk_all.UseVisualStyleBackColor = true;
            this.chk_all.CheckedChanged += new System.EventHandler(this.chk_all_CheckedChanged);
            // 
            // btn_raw_srch
            // 
            this.btn_raw_srch.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_raw_srch.Location = new System.Drawing.Point(486, 3);
            this.btn_raw_srch.Margin = new System.Windows.Forms.Padding(0);
            this.btn_raw_srch.Name = "btn_raw_srch";
            this.btn_raw_srch.Size = new System.Drawing.Size(26, 29);
            this.btn_raw_srch.TabIndex = 399;
            this.btn_raw_srch.Text = "▼";
            this.btn_raw_srch.UseVisualStyleBackColor = true;
            this.btn_raw_srch.Click += new System.EventHandler(this.btn_raw_srch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(324, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 22);
            this.label1.TabIndex = 395;
            this.label1.Text = "자재";
            // 
            // rawOutGrid
            // 
            this.rawOutGrid.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.rawOutGrid.AllowUserToAddRows = false;
            this.rawOutGrid.AllowUserToDeleteRows = false;
            this.rawOutGrid.AllowUserToResizeColumns = false;
            this.rawOutGrid.AllowUserToResizeRows = false;
            this.rawOutGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rawOutGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.rawOutGrid.BackgroundColor = System.Drawing.Color.White;
            this.rawOutGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.rawOutGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.rawOutGrid.ColumnHeadersHeight = 35;
            this.rawOutGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.rawOutGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.no,
            this.OUTPUT_DATE,
            this.RAW_MAT_CD,
            this.RAW_MAT_NM,
            this.SPEC,
            this.제품명,
            this.제품규격,
            this.TOTAL_AMT,
            this.LOT_NO,
            this.LOT_SUB,
            this.수주계획,
            this.BAR_NUM});
            this.rawOutGrid.EnableHeadersVisualStyles = false;
            this.rawOutGrid.GridColor = System.Drawing.Color.PowderBlue;
            this.rawOutGrid.Location = new System.Drawing.Point(-1, 34);
            this.rawOutGrid.Name = "rawOutGrid";
            this.rawOutGrid.RowHeadersVisible = false;
            this.rawOutGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.Black;
            this.rawOutGrid.RowsDefaultCellStyle = dataGridViewCellStyle14;
            this.rawOutGrid.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 12F);
            this.rawOutGrid.RowTemplate.Height = 30;
            this.rawOutGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.rawOutGrid.Size = new System.Drawing.Size(1359, 644);
            this.rawOutGrid.TabIndex = 374;
            this.rawOutGrid.VisibleChanged += new System.EventHandler(this.rawOutGrid_VisibleChanged);
            // 
            // no
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.no.DefaultCellStyle = dataGridViewCellStyle2;
            this.no.HeaderText = "No.";
            this.no.MinimumWidth = 100;
            this.no.Name = "no";
            this.no.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.no.Visible = false;
            // 
            // OUTPUT_DATE
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.OUTPUT_DATE.DefaultCellStyle = dataGridViewCellStyle3;
            this.OUTPUT_DATE.FillWeight = 259F;
            this.OUTPUT_DATE.HeaderText = "출고일자";
            this.OUTPUT_DATE.MinimumWidth = 72;
            this.OUTPUT_DATE.Name = "OUTPUT_DATE";
            this.OUTPUT_DATE.ReadOnly = true;
            this.OUTPUT_DATE.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // RAW_MAT_CD
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.RAW_MAT_CD.DefaultCellStyle = dataGridViewCellStyle4;
            this.RAW_MAT_CD.FillWeight = 170F;
            this.RAW_MAT_CD.HeaderText = "원자재코드";
            this.RAW_MAT_CD.MinimumWidth = 170;
            this.RAW_MAT_CD.Name = "RAW_MAT_CD";
            this.RAW_MAT_CD.ReadOnly = true;
            this.RAW_MAT_CD.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.RAW_MAT_CD.Visible = false;
            // 
            // RAW_MAT_NM
            // 
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.RAW_MAT_NM.DefaultCellStyle = dataGridViewCellStyle5;
            this.RAW_MAT_NM.FillWeight = 59F;
            this.RAW_MAT_NM.HeaderText = "원자재";
            this.RAW_MAT_NM.MinimumWidth = 58;
            this.RAW_MAT_NM.Name = "RAW_MAT_NM";
            this.RAW_MAT_NM.ReadOnly = true;
            this.RAW_MAT_NM.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // SPEC
            // 
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.SPEC.DefaultCellStyle = dataGridViewCellStyle6;
            this.SPEC.FillWeight = 323F;
            this.SPEC.HeaderText = "규격";
            this.SPEC.MinimumWidth = 50;
            this.SPEC.Name = "SPEC";
            this.SPEC.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // 제품명
            // 
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.제품명.DefaultCellStyle = dataGridViewCellStyle7;
            this.제품명.FillWeight = 134F;
            this.제품명.HeaderText = "투입제품명";
            this.제품명.MinimumWidth = 86;
            this.제품명.Name = "제품명";
            this.제품명.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // 제품규격
            // 
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.제품규격.DefaultCellStyle = dataGridViewCellStyle8;
            this.제품규격.FillWeight = 110F;
            this.제품규격.HeaderText = "제품규격";
            this.제품규격.MinimumWidth = 72;
            this.제품규격.Name = "제품규격";
            this.제품규격.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // TOTAL_AMT
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TOTAL_AMT.DefaultCellStyle = dataGridViewCellStyle9;
            this.TOTAL_AMT.FillWeight = 134F;
            this.TOTAL_AMT.HeaderText = "투입량";
            this.TOTAL_AMT.MinimumWidth = 58;
            this.TOTAL_AMT.Name = "TOTAL_AMT";
            this.TOTAL_AMT.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // LOT_NO
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LOT_NO.DefaultCellStyle = dataGridViewCellStyle10;
            this.LOT_NO.FillWeight = 227F;
            this.LOT_NO.HeaderText = "LOT_NO";
            this.LOT_NO.MinimumWidth = 74;
            this.LOT_NO.Name = "LOT_NO";
            this.LOT_NO.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // LOT_SUB
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.LOT_SUB.DefaultCellStyle = dataGridViewCellStyle11;
            this.LOT_SUB.HeaderText = "LOT_SUB ";
            this.LOT_SUB.MinimumWidth = 100;
            this.LOT_SUB.Name = "LOT_SUB";
            this.LOT_SUB.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.LOT_SUB.Visible = false;
            // 
            // 수주계획
            // 
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.수주계획.DefaultCellStyle = dataGridViewCellStyle12;
            this.수주계획.FillWeight = 110F;
            this.수주계획.HeaderText = "계획";
            this.수주계획.MinimumWidth = 50;
            this.수주계획.Name = "수주계획";
            this.수주계획.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // BAR_NUM
            // 
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.BAR_NUM.DefaultCellStyle = dataGridViewCellStyle13;
            this.BAR_NUM.FillWeight = 170F;
            this.BAR_NUM.HeaderText = "바코드";
            this.BAR_NUM.MinimumWidth = 170;
            this.BAR_NUM.Name = "BAR_NUM";
            this.BAR_NUM.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.BAR_NUM.Visible = false;
            // 
            // txt_srch_raw
            // 
            this.txt_srch_raw._AutoTab = true;
            this.txt_srch_raw._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.txt_srch_raw._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txt_srch_raw._WaterMarkColor = System.Drawing.Color.Gray;
            this.txt_srch_raw._WaterMarkText = "";
            this.txt_srch_raw.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_srch_raw.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_srch_raw.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.txt_srch_raw.Location = new System.Drawing.Point(366, 4);
            this.txt_srch_raw.MaxLength = 20;
            this.txt_srch_raw.Name = "txt_srch_raw";
            this.txt_srch_raw.Size = new System.Drawing.Size(121, 27);
            this.txt_srch_raw.TabIndex = 394;
            // 
            // end_date
            // 
            this.end_date.Checked = false;
            this.end_date.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.end_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.end_date.Location = new System.Drawing.Point(206, 3);
            this.end_date.Name = "end_date";
            this.end_date.Size = new System.Drawing.Size(100, 29);
            this.end_date.TabIndex = 377;
            this.end_date.Value = new System.DateTime(2018, 10, 8, 0, 0, 0, 0);
            // 
            // start_date
            // 
            this.start_date.Checked = false;
            this.start_date.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.start_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.start_date.Location = new System.Drawing.Point(86, 3);
            this.start_date.Name = "start_date";
            this.start_date.Size = new System.Drawing.Size(100, 29);
            this.start_date.TabIndex = 376;
            this.start_date.Value = new System.DateTime(2018, 10, 8, 0, 0, 0, 0);
            // 
            // btnSrch
            // 
            this.btnSrch.BackColor = System.Drawing.Color.Transparent;
            this.btnSrch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSrch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSrch.FlatAppearance.BorderSize = 0;
            this.btnSrch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btnSrch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSrch.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSrch.Image = ((System.Drawing.Image)(resources.GetObject("btnSrch.Image")));
            this.btnSrch.Location = new System.Drawing.Point(1116, 3);
            this.btnSrch.Name = "btnSrch";
            this.btnSrch.Size = new System.Drawing.Size(33, 30);
            this.btnSrch.TabIndex = 378;
            this.btnSrch.Tag = "검색";
            this.btnSrch.UseVisualStyleBackColor = false;
            this.btnSrch.Click += new System.EventHandler(this.btnSrch_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 29);
            this.label2.TabIndex = 379;
            this.label2.Text = "조회기간";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.Location = new System.Drawing.Point(179, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 23);
            this.label7.TabIndex = 375;
            this.label7.Text = "~";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.btnClose.Location = new System.Drawing.Point(1285, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(72, 29);
            this.btnClose.TabIndex = 10;
            this.btnClose.Tag = "종료";
            this.btnClose.Text = "닫기";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.txt_Srch_item_cd);
            this.panel2.Controls.Add(this.txt_srch_raw_cd);
            this.panel2.Controls.Add(this.btn출력);
            this.panel2.Controls.Add(this.lbl_title);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.panel2.ForeColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1360, 33);
            this.panel2.TabIndex = 13;
            // 
            // txt_Srch_item_cd
            // 
            this.txt_Srch_item_cd._AutoTab = true;
            this.txt_Srch_item_cd._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.txt_Srch_item_cd._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txt_Srch_item_cd._WaterMarkColor = System.Drawing.Color.Gray;
            this.txt_Srch_item_cd._WaterMarkText = "";
            this.txt_Srch_item_cd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Srch_item_cd.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_Srch_item_cd.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.txt_Srch_item_cd.Location = new System.Drawing.Point(629, 7);
            this.txt_Srch_item_cd.MaxLength = 20;
            this.txt_Srch_item_cd.Name = "txt_Srch_item_cd";
            this.txt_Srch_item_cd.Size = new System.Drawing.Size(105, 22);
            this.txt_Srch_item_cd.TabIndex = 406;
            this.txt_Srch_item_cd.Visible = false;
            // 
            // txt_srch_raw_cd
            // 
            this.txt_srch_raw_cd._AutoTab = true;
            this.txt_srch_raw_cd._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.txt_srch_raw_cd._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txt_srch_raw_cd._WaterMarkColor = System.Drawing.Color.Gray;
            this.txt_srch_raw_cd._WaterMarkText = "";
            this.txt_srch_raw_cd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_srch_raw_cd.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_srch_raw_cd.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.txt_srch_raw_cd.Location = new System.Drawing.Point(390, 10);
            this.txt_srch_raw_cd.MaxLength = 20;
            this.txt_srch_raw_cd.Name = "txt_srch_raw_cd";
            this.txt_srch_raw_cd.Size = new System.Drawing.Size(105, 22);
            this.txt_srch_raw_cd.TabIndex = 406;
            this.txt_srch_raw_cd.Visible = false;
            // 
            // btn출력
            // 
            this.btn출력.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn출력.BackColor = System.Drawing.Color.Transparent;
            this.btn출력.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn출력.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn출력.FlatAppearance.BorderColor = System.Drawing.Color.PaleTurquoise;
            this.btn출력.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn출력.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn출력.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn출력.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.btn출력.Image = global::MES.Properties.Resources.newPrintBtn;
            this.btn출력.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn출력.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn출력.Location = new System.Drawing.Point(1211, 3);
            this.btn출력.Name = "btn출력";
            this.btn출력.Size = new System.Drawing.Size(75, 29);
            this.btn출력.TabIndex = 383;
            this.btn출력.Tag = "출력";
            this.btn출력.Text = "출력";
            this.btn출력.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn출력.UseVisualStyleBackColor = false;
            this.btn출력.Click += new System.EventHandler(this.btn출력_Click);
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
            this.lbl_title.Text = "자재소요현황";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "제품코드";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.Width = 200;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "제품명";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn2.Width = 500;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "규격";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn3.Width = 250;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "기초재고량";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn4.Width = 150;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "포장일자";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn5.Width = 150;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "LOT_SUB ";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 150;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "바코드";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 200;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "투입량";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Width = 120;
            // 
            // frm원자재투입현황
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1360, 714);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frm원자재투입현황";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frm원자재투입현황";
            this.Load += new System.EventHandler(this.frm원자재투입현황_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rawOutGrid)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSrch;
        private System.Windows.Forms.DateTimePicker end_date;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker start_date;
        private System.Windows.Forms.Button btn출력;
        private Controls.conTextBox txt_srch_raw;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chk_all2;
        private System.Windows.Forms.Button btn_item_srch;
        private System.Windows.Forms.Label label3;
        private Controls.conTextBox txt_Srch_item;
        private System.Windows.Forms.CheckBox chk_all;
        private System.Windows.Forms.Button btn_raw_srch;
        private System.Windows.Forms.TextBox txt_lot;
        private System.Windows.Forms.Label label4;
        private Controls.conTextBox txt_srch_raw_cd;
        private Controls.conTextBox txt_Srch_item_cd;
        private Controls.DataGridViewTextBoxColumnEx no;
        private Controls.DataGridViewTextBoxColumnEx OUTPUT_DATE;
        private Controls.DataGridViewTextBoxColumnEx RAW_MAT_CD;
        private Controls.DataGridViewTextBoxColumnEx RAW_MAT_NM;
        private Controls.DataGridViewTextBoxColumnEx SPEC;
        private Controls.DataGridViewTextBoxColumnEx 제품명;
        private Controls.DataGridViewTextBoxColumnEx 제품규격;
        private Controls.DataGridViewTextBoxColumnEx TOTAL_AMT;
        private Controls.DataGridViewTextBoxColumnEx LOT_NO;
        private Controls.DataGridViewTextBoxColumnEx LOT_SUB;
        private Controls.DataGridViewTextBoxColumnEx 수주계획;
        private Controls.DataGridViewTextBoxColumnEx BAR_NUM;
        private Controls.myDataGridView rawOutGrid;

    }
}