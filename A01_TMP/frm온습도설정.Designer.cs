namespace MES.A01_TMP
{
    partial class frm온습도설정
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_title = new System.Windows.Forms.Label();
            this.lbl_chk_gbn = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tmp_allow_high = new MES.Controls.conTextBox();
            this.txt_sensor_nm = new MES.Controls.conTextBox();
            this.lbl_flow_nm = new System.Windows.Forms.Label();
            this.btn_loc_new = new System.Windows.Forms.Button();
            this.humi_allow_low = new MES.Controls.conTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tmp_allow_low = new MES.Controls.conTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.humi_allow_high = new MES.Controls.conTextBox();
            this.txt_tmp_loc = new MES.Controls.conTextBox();
            this.cmb_tmp_loc = new MES.Controls.conComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_device_id = new MES.Controls.conTextBox();
            this.txt_h_key = new MES.Controls.conTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.lbl_flow_cd = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_n_key = new MES.Controls.conTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_c_key = new MES.Controls.conTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_sensor_gubun = new MES.Controls.conTextBox();
            this.dataSensorGrid = new MES.Controls.myDataGridView();
            this.컨트롤러ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.하우스 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.노드 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.채널 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.명칭 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.센서구분 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.설치위치 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.온도허용범위 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.습도허용범위 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.설치위치코드 = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSensorGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.lbl_title);
            this.panel2.Controls.Add(this.lbl_chk_gbn);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.btnNew);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.btnDelete);
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
            this.lbl_title.Location = new System.Drawing.Point(9, -2);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(115, 34);
            this.lbl_title.TabIndex = 386;
            this.lbl_title.Text = "온습도설정";
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
            this.btnClose.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.btnClose.Image = global::MES.Properties.Resources.newnewCloseBtn;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(1289, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(68, 29);
            this.btnClose.TabIndex = 10;
            this.btnClose.TabStop = false;
            this.btnClose.Tag = "종료";
            this.btnClose.Text = "닫기";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.Transparent;
            this.btnNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNew.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnNew.FlatAppearance.BorderSize = 0;
            this.btnNew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Bold);
            this.btnNew.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.btnNew.Image = global::MES.Properties.Resources.newnewBtn;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNew.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnNew.Location = new System.Drawing.Point(867, 3);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 29);
            this.btnNew.TabIndex = 20;
            this.btnNew.TabStop = false;
            this.btnNew.Tag = "추가";
            this.btnNew.Text = "신규";
            this.btnNew.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.btnSave.Image = global::MES.Properties.Resources.newSaveBtn;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSave.Location = new System.Drawing.Point(948, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(65, 29);
            this.btnSave.TabIndex = 0;
            this.btnSave.TabStop = false;
            this.btnSave.Tag = "저장";
            this.btnSave.Text = "저장";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.Enabled = false;
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.btnDelete.Image = global::MES.Properties.Resources.newDelBtn;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDelete.Location = new System.Drawing.Point(1019, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(65, 29);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.TabStop = false;
            this.btnDelete.Tag = "삭제";
            this.btnDelete.Text = "삭제";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.dataSensorGrid);
            this.panel1.Location = new System.Drawing.Point(0, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1360, 679);
            this.panel1.TabIndex = 9;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.tmp_allow_high);
            this.groupBox2.Controls.Add(this.txt_sensor_nm);
            this.groupBox2.Controls.Add(this.lbl_flow_nm);
            this.groupBox2.Controls.Add(this.btn_loc_new);
            this.groupBox2.Controls.Add(this.humi_allow_low);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.tmp_allow_low);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.humi_allow_high);
            this.groupBox2.Controls.Add(this.txt_tmp_loc);
            this.groupBox2.Controls.Add(this.cmb_tmp_loc);
            this.groupBox2.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F);
            this.groupBox2.Location = new System.Drawing.Point(931, 504);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(417, 158);
            this.groupBox2.TabIndex = 374;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "설정항목";
            // 
            // tmp_allow_high
            // 
            this.tmp_allow_high._AutoTab = true;
            this.tmp_allow_high._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.tmp_allow_high._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tmp_allow_high._WaterMarkColor = System.Drawing.Color.Gray;
            this.tmp_allow_high._WaterMarkText = "";
            this.tmp_allow_high.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tmp_allow_high.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tmp_allow_high.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.tmp_allow_high.Location = new System.Drawing.Point(231, 88);
            this.tmp_allow_high.MaxLength = 100;
            this.tmp_allow_high.Name = "tmp_allow_high";
            this.tmp_allow_high.Size = new System.Drawing.Size(67, 22);
            this.tmp_allow_high.TabIndex = 357;
            this.tmp_allow_high.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_sensor_nm
            // 
            this.txt_sensor_nm._AutoTab = true;
            this.txt_sensor_nm._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.txt_sensor_nm._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txt_sensor_nm._WaterMarkColor = System.Drawing.Color.Gray;
            this.txt_sensor_nm._WaterMarkText = "";
            this.txt_sensor_nm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_sensor_nm.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_sensor_nm.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.txt_sensor_nm.Location = new System.Drawing.Point(112, 20);
            this.txt_sensor_nm.MaxLength = 100;
            this.txt_sensor_nm.Name = "txt_sensor_nm";
            this.txt_sensor_nm.Size = new System.Drawing.Size(195, 22);
            this.txt_sensor_nm.TabIndex = 2;
            // 
            // lbl_flow_nm
            // 
            this.lbl_flow_nm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.lbl_flow_nm.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_flow_nm.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbl_flow_nm.Location = new System.Drawing.Point(11, 20);
            this.lbl_flow_nm.Name = "lbl_flow_nm";
            this.lbl_flow_nm.Size = new System.Drawing.Size(100, 22);
            this.lbl_flow_nm.TabIndex = 316;
            this.lbl_flow_nm.Text = "명칭";
            this.lbl_flow_nm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_loc_new
            // 
            this.btn_loc_new.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.btn_loc_new.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_loc_new.ForeColor = System.Drawing.Color.Black;
            this.btn_loc_new.Location = new System.Drawing.Point(312, 48);
            this.btn_loc_new.Name = "btn_loc_new";
            this.btn_loc_new.Size = new System.Drawing.Size(93, 33);
            this.btn_loc_new.TabIndex = 369;
            this.btn_loc_new.Text = "신규등록";
            this.btn_loc_new.UseVisualStyleBackColor = true;
            this.btn_loc_new.Click += new System.EventHandler(this.btn_loc_new_Click);
            // 
            // humi_allow_low
            // 
            this.humi_allow_low._AutoTab = true;
            this.humi_allow_low._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.humi_allow_low._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.humi_allow_low._WaterMarkColor = System.Drawing.Color.Gray;
            this.humi_allow_low._WaterMarkText = "";
            this.humi_allow_low.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.humi_allow_low.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.humi_allow_low.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.humi_allow_low.Location = new System.Drawing.Point(134, 125);
            this.humi_allow_low.MaxLength = 100;
            this.humi_allow_low.Name = "humi_allow_low";
            this.humi_allow_low.Size = new System.Drawing.Size(67, 22);
            this.humi_allow_low.TabIndex = 4;
            this.humi_allow_low.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(302, 86);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 22);
            this.label10.TabIndex = 368;
            this.label10.Text = "( -40 ~ 100 )℃";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(11, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 22);
            this.label1.TabIndex = 351;
            this.label1.Text = "습도 허용범위";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(302, 124);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 22);
            this.label7.TabIndex = 362;
            this.label7.Text = "( 0 ~ 100 )%";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Gold;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(11, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 354;
            this.label3.Text = "설비위치";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(206, 130);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(18, 22);
            this.label6.TabIndex = 361;
            this.label6.Text = "~";
            // 
            // tmp_allow_low
            // 
            this.tmp_allow_low._AutoTab = true;
            this.tmp_allow_low._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.tmp_allow_low._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tmp_allow_low._WaterMarkColor = System.Drawing.Color.Gray;
            this.tmp_allow_low._WaterMarkText = "";
            this.tmp_allow_low.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tmp_allow_low.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tmp_allow_low.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.tmp_allow_low.Location = new System.Drawing.Point(134, 88);
            this.tmp_allow_low.MaxLength = 100;
            this.tmp_allow_low.Name = "tmp_allow_low";
            this.tmp_allow_low.Size = new System.Drawing.Size(67, 22);
            this.tmp_allow_low.TabIndex = 3;
            this.tmp_allow_low.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(206, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 22);
            this.label5.TabIndex = 360;
            this.label5.Text = "~";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(11, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 22);
            this.label4.TabIndex = 356;
            this.label4.Text = "온도 허용범위";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // humi_allow_high
            // 
            this.humi_allow_high._AutoTab = true;
            this.humi_allow_high._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.humi_allow_high._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.humi_allow_high._WaterMarkColor = System.Drawing.Color.Gray;
            this.humi_allow_high._WaterMarkText = "";
            this.humi_allow_high.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.humi_allow_high.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.humi_allow_high.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.humi_allow_high.Location = new System.Drawing.Point(231, 125);
            this.humi_allow_high.MaxLength = 100;
            this.humi_allow_high.Name = "humi_allow_high";
            this.humi_allow_high.Size = new System.Drawing.Size(67, 22);
            this.humi_allow_high.TabIndex = 358;
            this.humi_allow_high.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_tmp_loc
            // 
            this.txt_tmp_loc._AutoTab = true;
            this.txt_tmp_loc._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.txt_tmp_loc._FocusedBackColor = System.Drawing.Color.LemonChiffon;
            this.txt_tmp_loc._WaterMarkColor = System.Drawing.Color.Gray;
            this.txt_tmp_loc._WaterMarkText = "";
            this.txt_tmp_loc.BackColor = System.Drawing.Color.LemonChiffon;
            this.txt_tmp_loc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_tmp_loc.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_tmp_loc.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_tmp_loc.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.txt_tmp_loc.Location = new System.Drawing.Point(112, 54);
            this.txt_tmp_loc.MaxLength = 10;
            this.txt_tmp_loc.Name = "txt_tmp_loc";
            this.txt_tmp_loc.Size = new System.Drawing.Size(195, 23);
            this.txt_tmp_loc.TabIndex = 370;
            this.txt_tmp_loc.TabStop = false;
            this.txt_tmp_loc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_tmp_loc.Visible = false;
            // 
            // cmb_tmp_loc
            // 
            this.cmb_tmp_loc._BorderColor = System.Drawing.Color.Transparent;
            this.cmb_tmp_loc._FocusedBackColor = System.Drawing.Color.White;
            this.cmb_tmp_loc.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cmb_tmp_loc.Font = new System.Drawing.Font("굴림", 11F);
            this.cmb_tmp_loc.FormattingEnabled = true;
            this.cmb_tmp_loc.Location = new System.Drawing.Point(112, 54);
            this.cmb_tmp_loc.Name = "cmb_tmp_loc";
            this.cmb_tmp_loc.Size = new System.Drawing.Size(195, 23);
            this.cmb_tmp_loc.TabIndex = 6;
            this.cmb_tmp_loc.SelectedIndexChanged += new System.EventHandler(this.cmb_tmp_loc_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txt_device_id);
            this.groupBox1.Controls.Add(this.txt_h_key);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.lbl_flow_cd);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txt_n_key);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txt_c_key);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_sensor_gubun);
            this.groupBox1.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F);
            this.groupBox1.Location = new System.Drawing.Point(604, 504);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(316, 116);
            this.groupBox1.TabIndex = 373;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "센서정보";
            // 
            // txt_device_id
            // 
            this.txt_device_id._AutoTab = true;
            this.txt_device_id._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.txt_device_id._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txt_device_id._WaterMarkColor = System.Drawing.Color.Gray;
            this.txt_device_id._WaterMarkText = "";
            this.txt_device_id.BackColor = System.Drawing.Color.White;
            this.txt_device_id.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_device_id.Enabled = false;
            this.txt_device_id.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_device_id.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_device_id.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.txt_device_id.Location = new System.Drawing.Point(111, 20);
            this.txt_device_id.MaxLength = 10;
            this.txt_device_id.Name = "txt_device_id";
            this.txt_device_id.Size = new System.Drawing.Size(195, 22);
            this.txt_device_id.TabIndex = 372;
            this.txt_device_id.TabStop = false;
            this.txt_device_id.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_h_key
            // 
            this.txt_h_key._AutoTab = true;
            this.txt_h_key._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.txt_h_key._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txt_h_key._WaterMarkColor = System.Drawing.Color.Gray;
            this.txt_h_key._WaterMarkText = "";
            this.txt_h_key.BackColor = System.Drawing.Color.White;
            this.txt_h_key.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_h_key.Enabled = false;
            this.txt_h_key.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_h_key.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_h_key.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.txt_h_key.Location = new System.Drawing.Point(111, 51);
            this.txt_h_key.MaxLength = 10;
            this.txt_h_key.Name = "txt_h_key";
            this.txt_h_key.Size = new System.Drawing.Size(33, 22);
            this.txt_h_key.TabIndex = 1;
            this.txt_h_key.TabStop = false;
            this.txt_h_key.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label11.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(10, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(100, 22);
            this.label11.TabIndex = 371;
            this.label11.Text = "컨트롤러 ID";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_flow_cd
            // 
            this.lbl_flow_cd.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lbl_flow_cd.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_flow_cd.ForeColor = System.Drawing.Color.Black;
            this.lbl_flow_cd.Location = new System.Drawing.Point(10, 51);
            this.lbl_flow_cd.Name = "lbl_flow_cd";
            this.lbl_flow_cd.Size = new System.Drawing.Size(100, 22);
            this.lbl_flow_cd.TabIndex = 314;
            this.lbl_flow_cd.Text = "하우스";
            this.lbl_flow_cd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label8.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(150, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 22);
            this.label8.TabIndex = 364;
            this.label8.Text = "노드";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_n_key
            // 
            this.txt_n_key._AutoTab = true;
            this.txt_n_key._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.txt_n_key._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txt_n_key._WaterMarkColor = System.Drawing.Color.Gray;
            this.txt_n_key._WaterMarkText = "";
            this.txt_n_key.BackColor = System.Drawing.Color.White;
            this.txt_n_key.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_n_key.Enabled = false;
            this.txt_n_key.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_n_key.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_n_key.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.txt_n_key.Location = new System.Drawing.Point(191, 51);
            this.txt_n_key.MaxLength = 10;
            this.txt_n_key.Name = "txt_n_key";
            this.txt_n_key.Size = new System.Drawing.Size(33, 22);
            this.txt_n_key.TabIndex = 365;
            this.txt_n_key.TabStop = false;
            this.txt_n_key.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label9.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(232, 51);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 22);
            this.label9.TabIndex = 366;
            this.label9.Text = "채널";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_c_key
            // 
            this.txt_c_key._AutoTab = true;
            this.txt_c_key._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.txt_c_key._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txt_c_key._WaterMarkColor = System.Drawing.Color.Gray;
            this.txt_c_key._WaterMarkText = "";
            this.txt_c_key.BackColor = System.Drawing.Color.White;
            this.txt_c_key.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_c_key.Enabled = false;
            this.txt_c_key.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_c_key.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_c_key.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.txt_c_key.Location = new System.Drawing.Point(273, 51);
            this.txt_c_key.MaxLength = 10;
            this.txt_c_key.Name = "txt_c_key";
            this.txt_c_key.Size = new System.Drawing.Size(33, 22);
            this.txt_c_key.TabIndex = 367;
            this.txt_c_key.TabStop = false;
            this.txt_c_key.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(9, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 22);
            this.label2.TabIndex = 353;
            this.label2.Text = "센서 구분";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_sensor_gubun
            // 
            this.txt_sensor_gubun._AutoTab = true;
            this.txt_sensor_gubun._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.txt_sensor_gubun._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txt_sensor_gubun._WaterMarkColor = System.Drawing.Color.Gray;
            this.txt_sensor_gubun._WaterMarkText = "";
            this.txt_sensor_gubun.BackColor = System.Drawing.Color.White;
            this.txt_sensor_gubun.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_sensor_gubun.Enabled = false;
            this.txt_sensor_gubun.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_sensor_gubun.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.txt_sensor_gubun.Location = new System.Drawing.Point(110, 83);
            this.txt_sensor_gubun.MaxLength = 100;
            this.txt_sensor_gubun.Name = "txt_sensor_gubun";
            this.txt_sensor_gubun.Size = new System.Drawing.Size(195, 22);
            this.txt_sensor_gubun.TabIndex = 5;
            this.txt_sensor_gubun.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dataSensorGrid
            // 
            this.dataSensorGrid.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.dataSensorGrid.AllowUserToAddRows = false;
            this.dataSensorGrid.AllowUserToDeleteRows = false;
            this.dataSensorGrid.AllowUserToResizeColumns = false;
            this.dataSensorGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataSensorGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataSensorGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataSensorGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataSensorGrid.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataSensorGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataSensorGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataSensorGrid.ColumnHeadersHeight = 30;
            this.dataSensorGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.컨트롤러ID,
            this.하우스,
            this.노드,
            this.채널,
            this.명칭,
            this.센서구분,
            this.설치위치,
            this.온도허용범위,
            this.습도허용범위,
            this.설치위치코드});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataSensorGrid.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataSensorGrid.EnableHeadersVisualStyles = false;
            this.dataSensorGrid.GridColor = System.Drawing.Color.PowderBlue;
            this.dataSensorGrid.Location = new System.Drawing.Point(12, 14);
            this.dataSensorGrid.Name = "dataSensorGrid";
            this.dataSensorGrid.ReadOnly = true;
            this.dataSensorGrid.RowHeadersVisible = false;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.dataSensorGrid.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataSensorGrid.RowTemplate.Height = 23;
            this.dataSensorGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataSensorGrid.Size = new System.Drawing.Size(1336, 484);
            this.dataSensorGrid.TabIndex = 312;
            this.dataSensorGrid.TabStop = false;
            this.dataSensorGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataSensorGrid_CellDoubleClick);
            // 
            // 컨트롤러ID
            // 
            this.컨트롤러ID.FillWeight = 86F;
            this.컨트롤러ID.HeaderText = "컨트롤러ID";
            this.컨트롤러ID.MinimumWidth = 86;
            this.컨트롤러ID.Name = "컨트롤러ID";
            this.컨트롤러ID.ReadOnly = true;
            this.컨트롤러ID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.컨트롤러ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // 하우스
            // 
            this.하우스.FillWeight = 137F;
            this.하우스.HeaderText = "하우스";
            this.하우스.MinimumWidth = 58;
            this.하우스.Name = "하우스";
            this.하우스.ReadOnly = true;
            this.하우스.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.하우스.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // 노드
            // 
            this.노드.FillWeight = 122F;
            this.노드.HeaderText = "노드";
            this.노드.MinimumWidth = 50;
            this.노드.Name = "노드";
            this.노드.ReadOnly = true;
            this.노드.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.노드.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // 채널
            // 
            this.채널.FillWeight = 108F;
            this.채널.HeaderText = "채널";
            this.채널.MinimumWidth = 50;
            this.채널.Name = "채널";
            this.채널.ReadOnly = true;
            this.채널.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.채널.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // 명칭
            // 
            this.명칭.FillWeight = 250F;
            this.명칭.HeaderText = "명칭";
            this.명칭.MinimumWidth = 50;
            this.명칭.Name = "명칭";
            this.명칭.ReadOnly = true;
            this.명칭.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.명칭.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // 센서구분
            // 
            this.센서구분.FillWeight = 126F;
            this.센서구분.HeaderText = "센서구분";
            this.센서구분.MinimumWidth = 72;
            this.센서구분.Name = "센서구분";
            this.센서구분.ReadOnly = true;
            this.센서구분.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.센서구분.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // 설치위치
            // 
            this.설치위치.FillWeight = 157F;
            this.설치위치.HeaderText = "설치위치";
            this.설치위치.MinimumWidth = 72;
            this.설치위치.Name = "설치위치";
            this.설치위치.ReadOnly = true;
            this.설치위치.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.설치위치.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // 온도허용범위
            // 
            this.온도허용범위.FillWeight = 181F;
            this.온도허용범위.HeaderText = "온도 혀용범위";
            this.온도허용범위.MinimumWidth = 104;
            this.온도허용범위.Name = "온도허용범위";
            this.온도허용범위.ReadOnly = true;
            this.온도허용범위.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.온도허용범위.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // 습도허용범위
            // 
            this.습도허용범위.FillWeight = 166F;
            this.습도허용범위.HeaderText = "습도 허용범위";
            this.습도허용범위.MinimumWidth = 104;
            this.습도허용범위.Name = "습도허용범위";
            this.습도허용범위.ReadOnly = true;
            this.습도허용범위.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.습도허용범위.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // 설치위치코드
            // 
            this.설치위치코드.HeaderText = "설치위치코드";
            this.설치위치코드.MinimumWidth = 100;
            this.설치위치코드.Name = "설치위치코드";
            this.설치위치코드.ReadOnly = true;
            this.설치위치코드.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.설치위치코드.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.설치위치코드.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "STAFF_CD";
            this.dataGridViewTextBoxColumn1.HeaderText = "코드";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 160;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn2.HeaderText = "구분";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 50;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn3.HeaderText = "검사항목명";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 150;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "DEPT_NM";
            this.dataGridViewTextBoxColumn4.HeaderText = "검사위치";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 120;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "DEPT_NM";
            this.dataGridViewTextBoxColumn5.HeaderText = "구분코드";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Visible = false;
            this.dataGridViewTextBoxColumn5.Width = 140;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "규정치";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Visible = false;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "채용한계";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Visible = false;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "측정기구";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Visible = false;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "검사주기";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Visible = false;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "검사주기";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Visible = false;
            // 
            // frm온습도설정
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1360, 714);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "frm온습도설정";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frm온습도설정";
            this.Load += new System.EventHandler(this.frm온습도설정_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataSensorGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_flow_nm;
        private System.Windows.Forms.Label lbl_flow_cd;
        private Controls.conTextBox txt_sensor_nm;
        private Controls.conTextBox txt_h_key;
        private System.Windows.Forms.Label lbl_chk_gbn;
        private Controls.conComboBox cmb_tmp_loc;
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
        private System.Windows.Forms.Label label2;
        private Controls.conTextBox txt_sensor_gubun;
        private System.Windows.Forms.Label label1;
        private Controls.conTextBox humi_allow_low;
        private System.Windows.Forms.Label label4;
        private Controls.conTextBox tmp_allow_low;
        private System.Windows.Forms.Label label3;
        private Controls.conTextBox humi_allow_high;
        private Controls.conTextBox tmp_allow_high;
        private System.Windows.Forms.Button btn_loc_new;
        private System.Windows.Forms.Label label10;
        private Controls.conTextBox txt_c_key;
        private System.Windows.Forms.Label label9;
        private Controls.conTextBox txt_n_key;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private Controls.conTextBox txt_tmp_loc;
        private Controls.conTextBox txt_device_id;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn 컨트롤러ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn 하우스;
        private System.Windows.Forms.DataGridViewTextBoxColumn 노드;
        private System.Windows.Forms.DataGridViewTextBoxColumn 채널;
        private System.Windows.Forms.DataGridViewTextBoxColumn 명칭;
        private System.Windows.Forms.DataGridViewTextBoxColumn 센서구분;
        private System.Windows.Forms.DataGridViewTextBoxColumn 설치위치;
        private System.Windows.Forms.DataGridViewTextBoxColumn 온도허용범위;
        private System.Windows.Forms.DataGridViewTextBoxColumn 습도허용범위;
        private System.Windows.Forms.DataGridViewTextBoxColumn 설치위치코드;
        private Controls.myDataGridView dataSensorGrid;
    }
}