namespace MES.H40_공급망_품질관리
{
    partial class frm부적합이력조회
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm부적합이력조회));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_close = new System.Windows.Forms.Button();
            this.lbl_title = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgv부적합 = new MES.Controls.myDataGridView();
            this.F_CHK_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LOT_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LOT_SUB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CHK_NM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CHK_ORD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.F_SUB_AMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MEASURE_CNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FLOW_NM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.F_STEP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PASS_YN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv부적합)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.PaleTurquoise;
            this.panel2.Controls.Add(this.btn_close);
            this.panel2.Controls.Add(this.lbl_title);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1360, 33);
            this.panel2.TabIndex = 22;
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
            this.btn_close.Location = new System.Drawing.Point(1292, 2);
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
            this.lbl_title.Size = new System.Drawing.Size(171, 22);
            this.lbl_title.TabIndex = 93;
            this.lbl_title.Text = "부적합이력조회";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.dgv부적합);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1360, 681);
            this.panel1.TabIndex = 23;
            // 
            // dgv부적합
            // 
            this.dgv부적합.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.dgv부적합.AllowUserToAddRows = false;
            this.dgv부적합.AllowUserToDeleteRows = false;
            this.dgv부적합.AllowUserToOrderColumns = true;
            this.dgv부적합.AllowUserToResizeColumns = false;
            this.dgv부적합.AllowUserToResizeRows = false;
            this.dgv부적합.BackgroundColor = System.Drawing.Color.White;
            this.dgv부적합.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.PowderBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv부적합.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv부적합.ColumnHeadersHeight = 40;
            this.dgv부적합.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.F_CHK_DATE,
            this.LOT_NO,
            this.LOT_SUB,
            this.CHK_NM,
            this.CHK_ORD,
            this.F_SUB_AMT,
            this.MEASURE_CNT,
            this.FLOW_NM,
            this.F_STEP,
            this.PASS_YN});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv부적합.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv부적합.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv부적합.EnableHeadersVisualStyles = false;
            this.dgv부적합.GridColor = System.Drawing.Color.PowderBlue;
            this.dgv부적합.Location = new System.Drawing.Point(0, 0);
            this.dgv부적합.Name = "dgv부적합";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv부적합.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv부적합.RowHeadersVisible = false;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.dgv부적합.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv부적합.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F);
            this.dgv부적합.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgv부적합.RowTemplate.Height = 30;
            this.dgv부적합.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv부적합.Size = new System.Drawing.Size(1360, 681);
            this.dgv부적합.TabIndex = 379;
            // 
            // F_CHK_DATE
            // 
            this.F_CHK_DATE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.F_CHK_DATE.HeaderText = "검사일자";
            this.F_CHK_DATE.Name = "F_CHK_DATE";
            this.F_CHK_DATE.Width = 97;
            // 
            // LOT_NO
            // 
            this.LOT_NO.HeaderText = "LOT_NO";
            this.LOT_NO.Name = "LOT_NO";
            // 
            // LOT_SUB
            // 
            this.LOT_SUB.HeaderText = "LOT_SUB";
            this.LOT_SUB.Name = "LOT_SUB";
            // 
            // CHK_NM
            // 
            this.CHK_NM.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CHK_NM.HeaderText = "검사항목";
            this.CHK_NM.Name = "CHK_NM";
            // 
            // CHK_ORD
            // 
            this.CHK_ORD.HeaderText = "검사순서";
            this.CHK_ORD.Name = "CHK_ORD";
            // 
            // F_SUB_AMT
            // 
            this.F_SUB_AMT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.F_SUB_AMT.HeaderText = "공정SUB수량";
            this.F_SUB_AMT.Name = "F_SUB_AMT";
            this.F_SUB_AMT.Width = 128;
            // 
            // MEASURE_CNT
            // 
            this.MEASURE_CNT.HeaderText = "측정횟수";
            this.MEASURE_CNT.Name = "MEASURE_CNT";
            // 
            // FLOW_NM
            // 
            this.FLOW_NM.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FLOW_NM.HeaderText = "공정명";
            this.FLOW_NM.Name = "FLOW_NM";
            // 
            // F_STEP
            // 
            this.F_STEP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.F_STEP.HeaderText = "공정단계";
            this.F_STEP.Name = "F_STEP";
            this.F_STEP.Width = 97;
            // 
            // PASS_YN
            // 
            this.PASS_YN.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.PASS_YN.HeaderText = "통과여부";
            this.PASS_YN.Name = "PASS_YN";
            this.PASS_YN.Width = 97;
            // 
            // frm부적합이력조회
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1360, 714);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "frm부적합이력조회";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frm부적합이력조회";
            this.Load += new System.EventHandler(this.frm부적합이력조회_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv부적합)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.DataGridView dgv부적합;
        private System.Windows.Forms.DataGridViewTextBoxColumn F_CHK_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn LOT_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn LOT_SUB;
        private System.Windows.Forms.DataGridViewTextBoxColumn CHK_NM;
        private System.Windows.Forms.DataGridViewTextBoxColumn CHK_ORD;
        private System.Windows.Forms.DataGridViewTextBoxColumn F_SUB_AMT;
        private System.Windows.Forms.DataGridViewTextBoxColumn MEASURE_CNT;
        private System.Windows.Forms.DataGridViewTextBoxColumn FLOW_NM;
        private System.Windows.Forms.DataGridViewTextBoxColumn F_STEP;
        private System.Windows.Forms.DataGridViewTextBoxColumn PASS_YN;
    }
}