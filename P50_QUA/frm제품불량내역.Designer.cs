namespace MES.P50_QUA
{
    partial class frm제품불량내역
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm제품불량내역));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtcode = new MES.Controls.conTextBox();
            this.clear = new System.Windows.Forms.Button();
            this.btnSrch = new System.Windows.Forms.Button();
            this.txt_item_nm = new MES.Controls.conTextBox();
            this.lbl_title = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.end_date = new System.Windows.Forms.DateTimePicker();
            this.start_date = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgv_item_list = new MES.Controls.conDataGridView();
            this.제품명 = new MES.Controls.DataGridViewTextBoxColumnEx();
            this.LOT_NO = new MES.Controls.DataGridViewTextBoxColumnEx();
            this.LOT_SUB = new MES.Controls.DataGridViewTextBoxColumnEx();
            this.SEQ = new MES.Controls.DataGridViewTextBoxColumnEx();
            this.투입수량 = new MES.Controls.DataGridViewTextBoxColumnEx();
            this.불량율 = new MES.Controls.DataGridViewTextBoxColumnEx();
            this.불량 = new MES.Controls.DataGridViewTextBoxColumnEx();
            this.LOSS = new MES.Controls.DataGridViewTextBoxColumnEx();
            this.LOSS율 = new MES.Controls.DataGridViewTextBoxColumnEx();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_item_list)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.PaleTurquoise;
            this.panel2.Controls.Add(this.txtcode);
            this.panel2.Controls.Add(this.clear);
            this.panel2.Controls.Add(this.btnSrch);
            this.panel2.Controls.Add(this.txt_item_nm);
            this.panel2.Controls.Add(this.lbl_title);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.end_date);
            this.panel2.Controls.Add(this.start_date);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1360, 33);
            this.panel2.TabIndex = 12;
            // 
            // txtcode
            // 
            this.txtcode._AutoTab = true;
            this.txtcode._BorderColor = System.Drawing.Color.White;
            this.txtcode._FocusedBackColor = System.Drawing.Color.White;
            this.txtcode._WaterMarkColor = System.Drawing.Color.Gray;
            this.txtcode._WaterMarkText = "";
            this.txtcode.Location = new System.Drawing.Point(1009, 6);
            this.txtcode.Name = "txtcode";
            this.txtcode.Size = new System.Drawing.Size(53, 21);
            this.txtcode.TabIndex = 390;
            this.txtcode.Visible = false;
            // 
            // clear
            // 
            this.clear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.clear.BackColor = System.Drawing.Color.Transparent;
            this.clear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.clear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.clear.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.clear.FlatAppearance.BorderSize = 0;
            this.clear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.clear.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.clear.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.clear.Location = new System.Drawing.Point(897, 3);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(65, 29);
            this.clear.TabIndex = 104;
            this.clear.Tag = "종료";
            this.clear.Text = "새로고침";
            this.clear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.clear.UseVisualStyleBackColor = false;
            this.clear.Visible = false;
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // btnSrch
            // 
            this.btnSrch.BackColor = System.Drawing.Color.Transparent;
            this.btnSrch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSrch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSrch.FlatAppearance.BorderSize = 0;
            this.btnSrch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btnSrch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSrch.Image = ((System.Drawing.Image)(resources.GetObject("btnSrch.Image")));
            this.btnSrch.Location = new System.Drawing.Point(836, 2);
            this.btnSrch.Name = "btnSrch";
            this.btnSrch.Size = new System.Drawing.Size(33, 30);
            this.btnSrch.TabIndex = 103;
            this.btnSrch.Tag = "검색";
            this.btnSrch.UseVisualStyleBackColor = false;
            this.btnSrch.Click += new System.EventHandler(this.btnSrch_Click);
            // 
            // txt_item_nm
            // 
            this.txt_item_nm._AutoTab = true;
            this.txt_item_nm._BorderColor = System.Drawing.Color.White;
            this.txt_item_nm._FocusedBackColor = System.Drawing.Color.White;
            this.txt_item_nm._WaterMarkColor = System.Drawing.Color.Gray;
            this.txt_item_nm._WaterMarkText = "";
            this.txt_item_nm.Location = new System.Drawing.Point(588, 7);
            this.txt_item_nm.Name = "txt_item_nm";
            this.txt_item_nm.Size = new System.Drawing.Size(242, 21);
            this.txt_item_nm.TabIndex = 102;
            this.txt_item_nm.TextChanged += new System.EventHandler(this.txt_item_nm_TextChanged);
            this.txt_item_nm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_item_nm_KeyDown);
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
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(315, 11);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(14, 12);
            this.label13.TabIndex = 387;
            this.label13.Text = "~";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.PowderBlue;
            this.label2.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(482, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 22);
            this.label2.TabIndex = 383;
            this.label2.Text = "제품명";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // end_date
            // 
            this.end_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.end_date.Location = new System.Drawing.Point(335, 7);
            this.end_date.Name = "end_date";
            this.end_date.Size = new System.Drawing.Size(111, 21);
            this.end_date.TabIndex = 101;
            // 
            // start_date
            // 
            this.start_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.start_date.Location = new System.Drawing.Point(198, 7);
            this.start_date.Name = "start_date";
            this.start_date.Size = new System.Drawing.Size(111, 21);
            this.start_date.TabIndex = 100;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.dgv_item_list);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1360, 681);
            this.panel1.TabIndex = 13;
            // 
            // dgv_item_list
            // 
            this.dgv_item_list._BorderColor = System.Drawing.Color.Silver;
            this.dgv_item_list._DirKey = "R";
            this.dgv_item_list._KeyboardCmd = "1";
            this.dgv_item_list._KeyInput = "";
            this.dgv_item_list._LastCol = -1;
            this.dgv_item_list._LastRow = -1;
            this.dgv_item_list.AllowUserToAddRows = false;
            this.dgv_item_list.AllowUserToDeleteRows = false;
            this.dgv_item_list.AllowUserToResizeColumns = false;
            this.dgv_item_list.AllowUserToResizeRows = false;
            this.dgv_item_list.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_item_list.BackgroundColor = System.Drawing.Color.White;
            this.dgv_item_list.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_item_list.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_item_list.ColumnHeadersHeight = 40;
            this.dgv_item_list.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.제품명,
            this.LOT_NO,
            this.LOT_SUB,
            this.SEQ,
            this.투입수량,
            this.불량율,
            this.불량,
            this.LOSS,
            this.LOSS율});
            this.dgv_item_list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_item_list.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgv_item_list.EnableHeadersVisualStyles = false;
            this.dgv_item_list.GridColor = System.Drawing.Color.PowderBlue;
            this.dgv_item_list.Location = new System.Drawing.Point(0, 0);
            this.dgv_item_list.Name = "dgv_item_list";
            this.dgv_item_list.ReadOnly = true;
            this.dgv_item_list.RowHeadersVisible = false;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.LightYellow;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.dgv_item_list.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgv_item_list.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgv_item_list.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dgv_item_list.RowTemplate.Height = 23;
            this.dgv_item_list.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_item_list.Size = new System.Drawing.Size(1360, 681);
            this.dgv_item_list.TabIndex = 110;
            // 
            // 제품명
            // 
            this.제품명.HeaderText = "제품명";
            this.제품명.Name = "제품명";
            this.제품명.ReadOnly = true;
            this.제품명.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.제품명.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // LOT_NO
            // 
            this.LOT_NO.HeaderText = "LOT_no";
            this.LOT_NO.Name = "LOT_NO";
            this.LOT_NO.ReadOnly = true;
            this.LOT_NO.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.LOT_NO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // LOT_SUB
            // 
            this.LOT_SUB.HeaderText = "LOT_SUB";
            this.LOT_SUB.Name = "LOT_SUB";
            this.LOT_SUB.ReadOnly = true;
            this.LOT_SUB.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.LOT_SUB.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // SEQ
            // 
            this.SEQ.HeaderText = "SEQ";
            this.SEQ.Name = "SEQ";
            this.SEQ.ReadOnly = true;
            // 
            // 투입수량
            // 
            this.투입수량.HeaderText = "투입수량";
            this.투입수량.Name = "투입수량";
            this.투입수량.ReadOnly = true;
            this.투입수량.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.투입수량.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // 불량율
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.불량율.DefaultCellStyle = dataGridViewCellStyle2;
            this.불량율.HeaderText = "불량율";
            this.불량율.Name = "불량율";
            this.불량율.ReadOnly = true;
            this.불량율.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.불량율.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // 불량
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.불량.DefaultCellStyle = dataGridViewCellStyle3;
            this.불량.HeaderText = "불량";
            this.불량.Name = "불량";
            this.불량.ReadOnly = true;
            this.불량.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.불량.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // LOSS
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.LOSS.DefaultCellStyle = dataGridViewCellStyle4;
            this.LOSS.HeaderText = "LOSS";
            this.LOSS.Name = "LOSS";
            this.LOSS.ReadOnly = true;
            this.LOSS.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.LOSS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // LOSS율
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.LOSS율.DefaultCellStyle = dataGridViewCellStyle5;
            this.LOSS율.HeaderText = "LOSS율";
            this.LOSS율.Name = "LOSS율";
            this.LOSS율.ReadOnly = true;
            this.LOSS율.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.LOSS율.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // frm제품불량내역
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1360, 714);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "frm제품불량내역";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frm제품불량내역";
            this.Load += new System.EventHandler(this.frm제품불량내역_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_item_list)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSrch;
        private Controls.conTextBox txt_item_nm;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker end_date;
        private System.Windows.Forms.DateTimePicker start_date;
        private System.Windows.Forms.Panel panel1;
        private Controls.conDataGridView dgv_item_list;
        private System.Windows.Forms.Button clear;
        private Controls.conTextBox txtcode;
        private Controls.DataGridViewTextBoxColumnEx 제품명;
        private Controls.DataGridViewTextBoxColumnEx LOT_NO;
        private Controls.DataGridViewTextBoxColumnEx LOT_SUB;
        private Controls.DataGridViewTextBoxColumnEx SEQ;
        private Controls.DataGridViewTextBoxColumnEx 투입수량;
        private Controls.DataGridViewTextBoxColumnEx 불량율;
        private Controls.DataGridViewTextBoxColumnEx 불량;
        private Controls.DataGridViewTextBoxColumnEx LOSS;
        private Controls.DataGridViewTextBoxColumnEx LOSS율;

    }
}