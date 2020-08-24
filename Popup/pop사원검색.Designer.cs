namespace MES.Popup
{
    partial class pop사원검색
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
            this.dataUserGrid = new MES.Controls.myDataGridView();
            this.dgvUser_cd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvUser_NM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvUser_Dept = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvUser_pos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AUTH_SET = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataUserGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // dataUserGrid
            // 
            this.dataUserGrid.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.dataUserGrid.AllowUserToAddRows = false;
            this.dataUserGrid.AllowUserToDeleteRows = false;
            this.dataUserGrid.AllowUserToOrderColumns = true;
            this.dataUserGrid.AllowUserToResizeColumns = false;
            this.dataUserGrid.AllowUserToResizeRows = false;
            this.dataUserGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataUserGrid.BackgroundColor = System.Drawing.Color.White;
            this.dataUserGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataUserGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(113)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataUserGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataUserGrid.ColumnHeadersHeight = 30;
            this.dataUserGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvUser_cd,
            this.dgvUser_NM,
            this.dgvUser_Dept,
            this.dgvUser_pos,
            this.Column9,
            this.AUTH_SET,
            this.ID});
            this.dataUserGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataUserGrid.EnableHeadersVisualStyles = false;
            this.dataUserGrid.GridColor = System.Drawing.Color.PowderBlue;
            this.dataUserGrid.Location = new System.Drawing.Point(0, 0);
            this.dataUserGrid.Name = "dataUserGrid";
            this.dataUserGrid.ReadOnly = true;
            this.dataUserGrid.RowHeadersVisible = false;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dataUserGrid.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataUserGrid.RowTemplate.Height = 23;
            this.dataUserGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataUserGrid.Size = new System.Drawing.Size(410, 380);
            this.dataUserGrid.TabIndex = 277;
            this.dataUserGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataUserGrid_CellDoubleClick);
            // 
            // dgvUser_cd
            // 
            this.dgvUser_cd.DataPropertyName = "STAFF_CD";
            this.dgvUser_cd.HeaderText = "코드";
            this.dgvUser_cd.Name = "dgvUser_cd";
            this.dgvUser_cd.ReadOnly = true;
            this.dgvUser_cd.Visible = false;
            // 
            // dgvUser_NM
            // 
            this.dgvUser_NM.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgvUser_NM.DataPropertyName = "STAFF_NM";
            this.dgvUser_NM.HeaderText = "사원명";
            this.dgvUser_NM.Name = "dgvUser_NM";
            this.dgvUser_NM.ReadOnly = true;
            // 
            // dgvUser_Dept
            // 
            this.dgvUser_Dept.DataPropertyName = "DEPT_NM";
            this.dgvUser_Dept.HeaderText = "부서명";
            this.dgvUser_Dept.Name = "dgvUser_Dept";
            this.dgvUser_Dept.ReadOnly = true;
            // 
            // dgvUser_pos
            // 
            this.dgvUser_pos.DataPropertyName = "POS_NM";
            this.dgvUser_pos.HeaderText = "직위명";
            this.dgvUser_pos.Name = "dgvUser_pos";
            this.dgvUser_pos.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "COMMENT";
            this.Column9.HeaderText = "비고";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Visible = false;
            // 
            // AUTH_SET
            // 
            this.AUTH_SET.HeaderText = "권한";
            this.AUTH_SET.Name = "AUTH_SET";
            this.AUTH_SET.ReadOnly = true;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // pop사원검색
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 380);
            this.Controls.Add(this.dataUserGrid);
            this.Name = "pop사원검색";
            this.Text = "pop사원검색";
            this.Load += new System.EventHandler(this.pop사원검색_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataUserGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataUserGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvUser_cd;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvUser_NM;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvUser_Dept;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvUser_pos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn AUTH_SET;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
    }
}