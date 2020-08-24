namespace MES.Popup
{
    partial class frmPrint
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrint));
            this.lblMsg = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.btn네이버 = new System.Windows.Forms.Button();
            this.btn구글 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblMsg
            // 
            this.lblMsg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblMsg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMsg.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMsg.ForeColor = System.Drawing.Color.Green;
            this.lblMsg.Location = new System.Drawing.Point(299, 273);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(313, 57);
            this.lblMsg.TabIndex = 272;
            this.lblMsg.Text = "Loading ...";
            this.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMsg.Visible = false;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Location = new System.Drawing.Point(2, 1); this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reportViewer1.Location = new System.Drawing.Point(2, 1);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(907, 602);
            this.reportViewer1.TabIndex = 271;
            // 
            // btn네이버
            // 
            this.btn네이버.BackColor = System.Drawing.Color.Transparent;
            this.btn네이버.FlatAppearance.BorderSize = 0;
            this.btn네이버.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn네이버.Image = global::MES.Properties.Resources.naver;
            this.btn네이버.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn네이버.Location = new System.Drawing.Point(753, 1);
            this.btn네이버.Name = "btn네이버";
            this.btn네이버.Size = new System.Drawing.Size(75, 23);
            this.btn네이버.TabIndex = 274;
            this.btn네이버.Text = "SEND";
            this.btn네이버.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn네이버.UseVisualStyleBackColor = false;
            this.btn네이버.Visible = false;
            this.btn네이버.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn구글
            // 
            this.btn구글.BackColor = System.Drawing.Color.Transparent;
            this.btn구글.FlatAppearance.BorderSize = 0;
            this.btn구글.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn구글.Image = global::MES.Properties.Resources.google;
            this.btn구글.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn구글.Location = new System.Drawing.Point(834, 1);
            this.btn구글.Name = "btn구글";
            this.btn구글.Size = new System.Drawing.Size(75, 23);
            this.btn구글.TabIndex = 273;
            this.btn구글.Text = "SEND";
            this.btn구글.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn구글.UseVisualStyleBackColor = false;
            this.btn구글.Visible = false;
            this.btn구글.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 604);
            this.Controls.Add(this.btn네이버);
            this.Controls.Add(this.btn구글);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "frmPrint";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "출력";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPrint_FormClosing);
            this.Load += new System.EventHandler(this.frmPrint_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPrint_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblMsg;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Button btn구글;
        private System.Windows.Forms.Button btn네이버;
    }
}