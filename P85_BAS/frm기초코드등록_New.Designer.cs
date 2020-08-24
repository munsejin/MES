namespace MES.P85_BAS
{
    partial class frm기초코드등록_New
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm기초코드등록_New));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHead = new System.Windows.Forms.Panel();
            this.lbl_title = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lbl_remark = new System.Windows.Forms.Label();
            this.lbl_name = new System.Windows.Forms.Label();
            this.lbl_code = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.grdType = new System.Windows.Forms.DataGridView();
            this.btnLoc = new System.Windows.Forms.Button();
            this.btnStorage = new System.Windows.Forms.Button();
            this.btnRawType = new System.Windows.Forms.Button();
            this.btnItemType = new System.Windows.Forms.Button();
            this.btnUnit = new System.Windows.Forms.Button();
            this.btnCustType = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtCode = new MES.Controls.conTextBox();
            this.txtCmt = new MES.Controls.conTextBox();
            this.txtName = new MES.Controls.conTextBox();
            this.txtSearch = new MES.Controls.conTextBox();
            this.lbl_gbn = new MES.Controls.conTextBox();
            this.code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlHead.SuspendLayout();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdType)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHead
            // 
            this.pnlHead.BackColor = System.Drawing.SystemColors.HotTrack;
            this.pnlHead.Controls.Add(this.lbl_gbn);
            this.pnlHead.Controls.Add(this.lbl_title);
            this.pnlHead.Controls.Add(this.btnClose);
            this.pnlHead.Controls.Add(this.btnNew);
            this.pnlHead.Controls.Add(this.btnSave);
            this.pnlHead.Controls.Add(this.btnDelete);
            this.pnlHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHead.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.pnlHead.ForeColor = System.Drawing.Color.White;
            this.pnlHead.Location = new System.Drawing.Point(0, 0);
            this.pnlHead.Name = "pnlHead";
            this.pnlHead.Size = new System.Drawing.Size(1342, 37);
            this.pnlHead.TabIndex = 11;
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold);
            this.lbl_title.ForeColor = System.Drawing.Color.White;
            this.lbl_title.Location = new System.Drawing.Point(3, 9);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(174, 25);
            this.lbl_title.TabIndex = 93;
            this.lbl_title.Tag = "";
            this.lbl_title.Text = "기초코드등록_New";
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
            this.btnClose.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(1274, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(65, 29);
            this.btnClose.TabIndex = 10;
            this.btnClose.Tag = "종료";
            this.btnClose.Text = "닫기";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.BackColor = System.Drawing.Color.Transparent;
            this.btnNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNew.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnNew.FlatAppearance.BorderSize = 0;
            this.btnNew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnNew.ForeColor = System.Drawing.Color.White;
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNew.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnNew.Location = new System.Drawing.Point(1061, 3);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(65, 29);
            this.btnNew.TabIndex = 20;
            this.btnNew.Tag = "추가";
            this.btnNew.Text = "신규";
            this.btnNew.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSave.Location = new System.Drawing.Point(1132, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(65, 29);
            this.btnSave.TabIndex = 0;
            this.btnSave.Tag = "저장";
            this.btnSave.Text = "저장";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.Enabled = false;
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDelete.Location = new System.Drawing.Point(1203, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(65, 29);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Tag = "삭제";
            this.btnDelete.Text = "삭제";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMain.AutoSize = true;
            this.pnlMain.Controls.Add(this.splitContainer1);
            this.pnlMain.Controls.Add(this.btnLoc);
            this.pnlMain.Controls.Add(this.btnStorage);
            this.pnlMain.Controls.Add(this.btnRawType);
            this.pnlMain.Controls.Add(this.btnItemType);
            this.pnlMain.Controls.Add(this.btnUnit);
            this.pnlMain.Controls.Add(this.btnCustType);
            this.pnlMain.Location = new System.Drawing.Point(0, 38);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1342, 671);
            this.pnlMain.TabIndex = 96;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(3, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel1.Controls.Add(this.txtCode);
            this.splitContainer1.Panel1.Controls.Add(this.txtCmt);
            this.splitContainer1.Panel1.Controls.Add(this.lbl_remark);
            this.splitContainer1.Panel1.Controls.Add(this.txtName);
            this.splitContainer1.Panel1.Controls.Add(this.lbl_name);
            this.splitContainer1.Panel1.Controls.Add(this.lbl_code);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel2.Controls.Add(this.btnSearch);
            this.splitContainer1.Panel2.Controls.Add(this.grdType);
            this.splitContainer1.Panel2.Controls.Add(this.txtSearch);
            this.splitContainer1.Size = new System.Drawing.Size(1336, 643);
            this.splitContainer1.SplitterDistance = 576;
            this.splitContainer1.TabIndex = 337;
            // 
            // lbl_remark
            // 
            this.lbl_remark.BackColor = System.Drawing.Color.Gainsboro;
            this.lbl_remark.Location = new System.Drawing.Point(67, 135);
            this.lbl_remark.Name = "lbl_remark";
            this.lbl_remark.Size = new System.Drawing.Size(107, 21);
            this.lbl_remark.TabIndex = 89;
            this.lbl_remark.Text = "비고";
            this.lbl_remark.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_name
            // 
            this.lbl_name.BackColor = System.Drawing.Color.Gainsboro;
            this.lbl_name.Location = new System.Drawing.Point(67, 91);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(107, 21);
            this.lbl_name.TabIndex = 88;
            this.lbl_name.Text = "명칭";
            this.lbl_name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_code
            // 
            this.lbl_code.BackColor = System.Drawing.Color.Gainsboro;
            this.lbl_code.Location = new System.Drawing.Point(67, 47);
            this.lbl_code.Name = "lbl_code";
            this.lbl_code.Size = new System.Drawing.Size(107, 21);
            this.lbl_code.TabIndex = 87;
            this.lbl_code.Text = "코드";
            this.lbl_code.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Transparent;
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(231, 8);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(33, 33);
            this.btnSearch.TabIndex = 516;
            this.btnSearch.Tag = "검색";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // grdType
            // 
            this.grdType.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.grdType.AllowDrop = true;
            this.grdType.AllowUserToAddRows = false;
            this.grdType.AllowUserToDeleteRows = false;
            this.grdType.AllowUserToOrderColumns = true;
            this.grdType.AllowUserToResizeColumns = false;
            this.grdType.AllowUserToResizeRows = false;
            this.grdType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdType.BackgroundColor = System.Drawing.Color.White;
            this.grdType.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdType.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grdType.ColumnHeadersHeight = 40;
            this.grdType.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.code,
            this.name,
            this.comment});
            this.grdType.EnableHeadersVisualStyles = false;
            this.grdType.GridColor = System.Drawing.Color.PowderBlue;
            this.grdType.Location = new System.Drawing.Point(3, 52);
            this.grdType.Name = "grdType";
            this.grdType.ReadOnly = true;
            this.grdType.RowHeadersVisible = false;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.grdType.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.grdType.RowTemplate.Height = 23;
            this.grdType.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdType.Size = new System.Drawing.Size(750, 599);
            this.grdType.TabIndex = 288;
            this.grdType.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdType_CellDoubleClick);
            // 
            // btnLoc
            // 
            this.btnLoc.BackColor = System.Drawing.Color.Gainsboro;
            this.btnLoc.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLoc.Location = new System.Drawing.Point(480, 3);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(96, 21);
            this.btnLoc.TabIndex = 21;
            this.btnLoc.Tag = "N_LOC_CODE";
            this.btnLoc.Text = "창고위치등록";
            this.btnLoc.UseVisualStyleBackColor = false;
            // 
            // btnStorage
            // 
            this.btnStorage.BackColor = System.Drawing.Color.Gainsboro;
            this.btnStorage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnStorage.Location = new System.Drawing.Point(384, 3);
            this.btnStorage.Name = "btnStorage";
            this.btnStorage.Size = new System.Drawing.Size(96, 21);
            this.btnStorage.TabIndex = 20;
            this.btnStorage.Tag = "N_STORAGE_CODE";
            this.btnStorage.Text = "창고등록";
            this.btnStorage.UseVisualStyleBackColor = false;
            // 
            // btnRawType
            // 
            this.btnRawType.BackColor = System.Drawing.Color.Gainsboro;
            this.btnRawType.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRawType.Location = new System.Drawing.Point(96, 3);
            this.btnRawType.Name = "btnRawType";
            this.btnRawType.Size = new System.Drawing.Size(96, 21);
            this.btnRawType.TabIndex = 2;
            this.btnRawType.Tag = "N_RAW_TYPE_CODE";
            this.btnRawType.Text = "원자재유형";
            this.btnRawType.UseVisualStyleBackColor = false;
            // 
            // btnItemType
            // 
            this.btnItemType.BackColor = System.Drawing.Color.Gainsboro;
            this.btnItemType.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnItemType.Location = new System.Drawing.Point(192, 3);
            this.btnItemType.Name = "btnItemType";
            this.btnItemType.Size = new System.Drawing.Size(96, 21);
            this.btnItemType.TabIndex = 3;
            this.btnItemType.Tag = "N_ITEM_TYPE_CODE";
            this.btnItemType.Text = "제품유형";
            this.btnItemType.UseVisualStyleBackColor = false;
            // 
            // btnUnit
            // 
            this.btnUnit.BackColor = System.Drawing.Color.White;
            this.btnUnit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUnit.Location = new System.Drawing.Point(0, 3);
            this.btnUnit.Name = "btnUnit";
            this.btnUnit.Size = new System.Drawing.Size(96, 21);
            this.btnUnit.TabIndex = 19;
            this.btnUnit.Tag = "N_UNIT_CODE";
            this.btnUnit.Text = "단위";
            this.btnUnit.UseVisualStyleBackColor = false;
            // 
            // btnCustType
            // 
            this.btnCustType.BackColor = System.Drawing.Color.Gainsboro;
            this.btnCustType.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCustType.Location = new System.Drawing.Point(288, 3);
            this.btnCustType.Name = "btnCustType";
            this.btnCustType.Size = new System.Drawing.Size(96, 21);
            this.btnCustType.TabIndex = 17;
            this.btnCustType.Tag = "N_CUST_TYPE_CODE";
            this.btnCustType.Text = "거래처유형";
            this.btnCustType.UseVisualStyleBackColor = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "코드";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "명칭";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "비고";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // txtCode
            // 
            this.txtCode._AutoTab = true;
            this.txtCode._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.txtCode._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtCode._WaterMarkColor = System.Drawing.Color.Gray;
            this.txtCode._WaterMarkText = "";
            this.txtCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCode.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtCode.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.txtCode.Location = new System.Drawing.Point(189, 47);
            this.txtCode.MaxLength = 3;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(175, 22);
            this.txtCode.TabIndex = 334;
            this.txtCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCode_KeyPress);
            // 
            // txtCmt
            // 
            this.txtCmt._AutoTab = true;
            this.txtCmt._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.txtCmt._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtCmt._WaterMarkColor = System.Drawing.Color.Gray;
            this.txtCmt._WaterMarkText = "";
            this.txtCmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCmt.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtCmt.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.txtCmt.Location = new System.Drawing.Point(189, 135);
            this.txtCmt.MaxLength = 20;
            this.txtCmt.Name = "txtCmt";
            this.txtCmt.Size = new System.Drawing.Size(175, 22);
            this.txtCmt.TabIndex = 336;
            // 
            // txtName
            // 
            this.txtName._AutoTab = true;
            this.txtName._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.txtName._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtName._WaterMarkColor = System.Drawing.Color.Gray;
            this.txtName._WaterMarkText = "";
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtName.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.txtName.Location = new System.Drawing.Point(189, 92);
            this.txtName.MaxLength = 20;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(175, 22);
            this.txtName.TabIndex = 335;
            // 
            // txtSearch
            // 
            this.txtSearch._AutoTab = true;
            this.txtSearch._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.txtSearch._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtSearch._WaterMarkColor = System.Drawing.Color.Gray;
            this.txtSearch._WaterMarkText = "";
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtSearch.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.txtSearch.Location = new System.Drawing.Point(39, 14);
            this.txtSearch.MaxLength = 20;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(171, 22);
            this.txtSearch.TabIndex = 515;
            // 
            // lbl_gbn
            // 
            this.lbl_gbn._AutoTab = true;
            this.lbl_gbn._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.lbl_gbn._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lbl_gbn._WaterMarkColor = System.Drawing.Color.Gray;
            this.lbl_gbn._WaterMarkText = "";
            this.lbl_gbn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lbl_gbn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_gbn.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_gbn.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.lbl_gbn.Location = new System.Drawing.Point(874, 6);
            this.lbl_gbn.MaxLength = 6;
            this.lbl_gbn.Name = "lbl_gbn";
            this.lbl_gbn.Size = new System.Drawing.Size(91, 22);
            this.lbl_gbn.TabIndex = 340;
            this.lbl_gbn.Text = "0";
            this.lbl_gbn.Visible = false;
            // 
            // code
            // 
            this.code.HeaderText = "코드";
            this.code.Name = "code";
            this.code.ReadOnly = true;
            // 
            // name
            // 
            this.name.HeaderText = "명칭";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // comment
            // 
            this.comment.HeaderText = "비고";
            this.comment.Name = "comment";
            this.comment.ReadOnly = true;
            // 
            // frm기초코드등록_New
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1342, 709);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlHead);
            this.Name = "frm기초코드등록_New";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frm기로코드등록_New";
            this.Load += new System.EventHandler(this.frm기로코드등록_New_Load);
            this.pnlHead.ResumeLayout(false);
            this.pnlHead.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdType)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlHead;
        private Controls.conTextBox lbl_gbn;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Controls.conTextBox txtCode;
        private Controls.conTextBox txtCmt;
        private System.Windows.Forms.Label lbl_remark;
        private Controls.conTextBox txtName;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.Label lbl_code;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView grdType;
        private Controls.conTextBox txtSearch;
        private System.Windows.Forms.Button btnLoc;
        private System.Windows.Forms.Button btnStorage;
        private System.Windows.Forms.Button btnRawType;
        private System.Windows.Forms.Button btnItemType;
        private System.Windows.Forms.Button btnUnit;
        private System.Windows.Forms.Button btnCustType;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn code;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn comment;
    }
}