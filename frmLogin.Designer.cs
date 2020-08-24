namespace MES
{
    partial class frmLogin
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
            this.components = new System.ComponentModel.Container();
            this.panMain = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnl_check = new System.Windows.Forms.Panel();
            this.Label12 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tmFocus = new System.Windows.Forms.Timer(this.components);
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.lblToday = new System.Windows.Forms.Label();
            this.txtPW = new MES.Controls.conTextBox();
            this.txtID = new MES.Controls.conTextBox();
            this.txtCompID = new MES.Controls.conMaskedTextBox();
            this.conLabel1 = new MES.Controls.conLabel();
            this.panMain.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnl_check.SuspendLayout();
            this.Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panMain
            // 
            this.panMain.BackColor = System.Drawing.Color.Gray;
            this.panMain.Controls.Add(this.panel1);
            this.panMain.Controls.Add(this.Panel2);
            this.panMain.Dock = System.Windows.Forms.DockStyle.Left;
            this.panMain.Location = new System.Drawing.Point(0, 0);
            this.panMain.Name = "panMain";
            this.panMain.Size = new System.Drawing.Size(308, 208);
            this.panMain.TabIndex = 46;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pnl_check);
            this.panel1.Location = new System.Drawing.Point(-1, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(309, 198);
            this.panel1.TabIndex = 47;
            // 
            // pnl_check
            // 
            this.pnl_check.BackColor = System.Drawing.Color.White;
            this.pnl_check.Controls.Add(this.Label12);
            this.pnl_check.Controls.Add(this.Label3);
            this.pnl_check.Controls.Add(this.txtPW);
            this.pnl_check.Controls.Add(this.btnClose);
            this.pnl_check.Controls.Add(this.btnOK);
            this.pnl_check.Controls.Add(this.txtID);
            this.pnl_check.Controls.Add(this.label1);
            this.pnl_check.Controls.Add(this.txtCompID);
            this.pnl_check.Location = new System.Drawing.Point(0, 0);
            this.pnl_check.Name = "pnl_check";
            this.pnl_check.Size = new System.Drawing.Size(308, 188);
            this.pnl_check.TabIndex = 42;
            // 
            // Label12
            // 
            this.Label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            this.Label12.Font = new System.Drawing.Font("Noto Sans CJK KR Black", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.Label12.Location = new System.Drawing.Point(13, 47);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(137, 28);
            this.Label12.TabIndex = 41;
            this.Label12.Text = "아이디";
            this.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label3
            // 
            this.Label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            this.Label3.Font = new System.Drawing.Font("Noto Sans CJK KR Black", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.Label3.Location = new System.Drawing.Point(13, 84);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(137, 28);
            this.Label3.TabIndex = 40;
            this.Label3.Text = "암호";
            this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            this.label1.Font = new System.Drawing.Font("Noto Sans CJK KR Black", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 28);
            this.label1.TabIndex = 41;
            this.label1.Text = "사업자번호";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tmFocus
            // 
            this.tmFocus.Tick += new System.EventHandler(this.tmFocus_Tick);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Noto Sans CJK KR Black", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnClose.Image = global::MES.Properties.Resources.NNN_login_canclle_button;
            this.btnClose.Location = new System.Drawing.Point(160, 125);
            this.btnClose.Margin = new System.Windows.Forms.Padding(0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(125, 40);
            this.btnClose.TabIndex = 4;
            this.btnClose.Tag = "";
            this.btnClose.Text = "취소";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnClose_MouseDown);
            this.btnClose.MouseEnter += new System.EventHandler(this.btnClose_MouseEnter);
            this.btnClose.MouseLeave += new System.EventHandler(this.btnClose_MouseLeave);
            this.btnClose.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnClose_MouseUp);
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.White;
            this.btnOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnOK.FlatAppearance.BorderSize = 0;
            this.btnOK.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnOK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("Noto Sans CJK KR Black", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnOK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(153)))), ((int)(((byte)(251)))));
            this.btnOK.Image = global::MES.Properties.Resources.NN_Button_Primary;
            this.btnOK.Location = new System.Drawing.Point(26, 125);
            this.btnOK.Margin = new System.Windows.Forms.Padding(0);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(124, 40);
            this.btnOK.TabIndex = 3;
            this.btnOK.Tag = "";
            this.btnOK.Text = "로그인";
            this.btnOK.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            this.btnOK.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnOK_MouseDown);
            this.btnOK.MouseEnter += new System.EventHandler(this.btnOK_MouseEnter);
            this.btnOK.MouseLeave += new System.EventHandler(this.btnOK_MouseLeave);
            this.btnOK.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnOK_MouseUp);
            // 
            // Panel2
            // 
            this.Panel2.BackColor = System.Drawing.Color.White;
            this.Panel2.BackgroundImage = global::MES.Properties.Resources.NNN_login_header;
            this.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Panel2.Controls.Add(this.conLabel1);
            this.Panel2.Controls.Add(this.lblToday);
            this.Panel2.Location = new System.Drawing.Point(1, -12);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(307, 56);
            this.Panel2.TabIndex = 46;
            // 
            // lblToday
            // 
            this.lblToday.BackColor = System.Drawing.Color.Transparent;
            this.lblToday.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToday.ForeColor = System.Drawing.Color.White;
            this.lblToday.Location = new System.Drawing.Point(191, 18);
            this.lblToday.Name = "lblToday";
            this.lblToday.Size = new System.Drawing.Size(110, 19);
            this.lblToday.TabIndex = 39;
            this.lblToday.Text = "2006-01-01";
            this.lblToday.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // txtPW
            // 
            this.txtPW._AutoTab = true;
            this.txtPW._BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(169)))), ((int)(((byte)(246)))));
            this.txtPW._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(237)))), ((int)(((byte)(255)))));
            this.txtPW._WaterMarkColor = System.Drawing.Color.Gray;
            this.txtPW._WaterMarkText = "";
            this.txtPW.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPW.Font = new System.Drawing.Font("Noto Sans Mono CJK KR Bold", 15.75F, System.Drawing.FontStyle.Bold);
            this.txtPW.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.txtPW.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.txtPW.Location = new System.Drawing.Point(160, 84);
            this.txtPW.MaxLength = 20;
            this.txtPW.Name = "txtPW";
            this.txtPW.PasswordChar = '*';
            this.txtPW.Size = new System.Drawing.Size(137, 28);
            this.txtPW.TabIndex = 2;
            this.txtPW.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPW_KeyDown_1);
            // 
            // txtID
            // 
            this.txtID._AutoTab = true;
            this.txtID._BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(169)))), ((int)(((byte)(246)))));
            this.txtID._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(237)))), ((int)(((byte)(255)))));
            this.txtID._WaterMarkColor = System.Drawing.Color.Gray;
            this.txtID._WaterMarkText = "";
            this.txtID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtID.Font = new System.Drawing.Font("Noto Sans Mono CJK KR Bold", 15.75F, System.Drawing.FontStyle.Bold);
            this.txtID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.txtID.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.txtID.Location = new System.Drawing.Point(160, 47);
            this.txtID.MaxLength = 20;
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(137, 28);
            this.txtID.TabIndex = 0;
            // 
            // txtCompID
            // 
            this.txtCompID._BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(169)))), ((int)(((byte)(246)))));
            this.txtCompID._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(237)))), ((int)(((byte)(255)))));
            this.txtCompID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCompID.Font = new System.Drawing.Font("Noto Sans Mono CJK KR Bold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtCompID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.txtCompID.Location = new System.Drawing.Point(160, 9);
            this.txtCompID.Mask = "000-00-00000";
            this.txtCompID.Name = "txtCompID";
            this.txtCompID.ResetOnSpace = false;
            this.txtCompID.Size = new System.Drawing.Size(137, 28);
            this.txtCompID.TabIndex = 5;
            this.txtCompID.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // conLabel1
            // 
            this.conLabel1._BorderColor = System.Drawing.Color.Transparent;
            this.conLabel1.AutoSize = true;
            this.conLabel1.BackColor = System.Drawing.Color.Transparent;
            this.conLabel1.Font = new System.Drawing.Font("Noto Sans CJK KR Black", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.conLabel1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.conLabel1.Location = new System.Drawing.Point(99, 15);
            this.conLabel1.Name = "conLabel1";
            this.conLabel1.Size = new System.Drawing.Size(108, 27);
            this.conLabel1.TabIndex = 40;
            this.conLabel1.Text = "■ 로그인 ■";
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 208);
            this.Controls.Add(this.panMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmLogin";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "로그인";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.panMain.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.pnl_check.ResumeLayout(false);
            this.Panel2.ResumeLayout(false);
            this.Panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panMain;
        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.Label lblToday;
        internal System.Windows.Forms.Panel Panel2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Timer tmFocus;
        private Controls.conTextBox txtID;
        private Controls.conMaskedTextBox txtCompID;
        private Controls.conTextBox txtPW;
        private System.Windows.Forms.Panel pnl_check;
        internal System.Windows.Forms.Label Label12;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label label1;
        private Controls.conLabel conLabel1;
    }
}