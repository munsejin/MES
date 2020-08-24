namespace MES.Popup
{
    partial class pop우편번호검색
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_frm_close = new System.Windows.Forms.Button();
            this.lbl_search_postNum = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cmb_addr_type = new System.Windows.Forms.ComboBox();
            this.grdPostNo = new MES.Controls.myDataGridView();
            this.addr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.postNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_search = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPostNo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btn_frm_close);
            this.panel1.Controls.Add(this.lbl_search_postNum);
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(5, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(820, 32);
            this.panel1.TabIndex = 1;
            // 
            // btn_frm_close
            // 
            this.btn_frm_close.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_frm_close.FlatAppearance.BorderSize = 0;
            this.btn_frm_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_frm_close.ForeColor = System.Drawing.Color.Black;
            this.btn_frm_close.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_frm_close.Location = new System.Drawing.Point(746, 0);
            this.btn_frm_close.Name = "btn_frm_close";
            this.btn_frm_close.Size = new System.Drawing.Size(74, 32);
            this.btn_frm_close.TabIndex = 1;
            this.btn_frm_close.Text = "닫기";
            this.btn_frm_close.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_frm_close.UseVisualStyleBackColor = true;
            this.btn_frm_close.Click += new System.EventHandler(this.btn_frm_close_Click);
            // 
            // lbl_search_postNum
            // 
            this.lbl_search_postNum.AutoSize = true;
            this.lbl_search_postNum.Font = new System.Drawing.Font("돋움", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_search_postNum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.lbl_search_postNum.Location = new System.Drawing.Point(3, 6);
            this.lbl_search_postNum.Name = "lbl_search_postNum";
            this.lbl_search_postNum.Size = new System.Drawing.Size(136, 19);
            this.lbl_search_postNum.TabIndex = 0;
            this.lbl_search_postNum.Text = "우편번호 검색";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.txtSearch);
            this.panel2.Controls.Add(this.cmb_addr_type);
            this.panel2.Controls.Add(this.grdPostNo);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btn_search);
            this.panel2.Location = new System.Drawing.Point(6, 51);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(819, 453);
            this.panel2.TabIndex = 2;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(126, 25);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(651, 21);
            this.txtSearch.TabIndex = 18;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // cmb_addr_type
            // 
            this.cmb_addr_type.FormattingEnabled = true;
            this.cmb_addr_type.Items.AddRange(new object[] {
            "지번주소",
            "도로명주소"});
            this.cmb_addr_type.Location = new System.Drawing.Point(6, 26);
            this.cmb_addr_type.Name = "cmb_addr_type";
            this.cmb_addr_type.Size = new System.Drawing.Size(114, 20);
            this.cmb_addr_type.TabIndex = 16;
            // 
            // grdPostNo
            // 
            this.grdPostNo.AllowUserToAddRows = false;
            this.grdPostNo.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdPostNo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdPostNo.ColumnHeadersHeight = 30;
            this.grdPostNo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdPostNo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.addr,
            this.postNo});
            this.grdPostNo.Location = new System.Drawing.Point(6, 59);
            this.grdPostNo.Name = "grdPostNo";
            this.grdPostNo.RowHeadersVisible = false;
            this.grdPostNo.RowTemplate.Height = 23;
            this.grdPostNo.Size = new System.Drawing.Size(798, 356);
            this.grdPostNo.TabIndex = 15;
            this.grdPostNo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdPostNo_CellDoubleClick);
            // 
            // addr
            // 
            this.addr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.addr.HeaderText = "주소";
            this.addr.Name = "addr";
            // 
            // postNo
            // 
            this.postNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.postNo.HeaderText = "우편번호";
            this.postNo.Name = "postNo";
            this.postNo.Width = 84;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 423);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 12);
            this.label1.TabIndex = 14;
            this.label1.Text = "*도로명 예시 : 광양9길 10";
            // 
            // btn_search
            // 
            this.btn_search.FlatAppearance.BorderSize = 0;
            this.btn_search.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_search.Image = global::MES.Properties.Resources.search2blue;
            this.btn_search.Location = new System.Drawing.Point(783, 19);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(21, 27);
            this.btn_search.TabIndex = 12;
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn1.HeaderText = "주소";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "우편번호";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 150;
            // 
            // pop우편번호검색
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ClientSize = new System.Drawing.Size(837, 507);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "pop우편번호검색";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frm우편번호검색";
            this.Load += new System.EventHandler(this.frm우편번호검색_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPostNo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_frm_close;
        private System.Windows.Forms.Label lbl_search_postNum;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.DataGridView grdPostNo;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cmb_addr_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn addr;
        private System.Windows.Forms.DataGridViewTextBoxColumn postNo;
    }
}