namespace MES.Popup
{
    partial class frm일정관리
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
            this.lbl일자 = new System.Windows.Forms.Label();
            this.lbl간략 = new System.Windows.Forms.Label();
            this.txt제목 = new System.Windows.Forms.TextBox();
            this.dtp = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl일자
            // 
            this.lbl일자.BackColor = System.Drawing.Color.PowderBlue;
            this.lbl일자.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl일자.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl일자.Location = new System.Drawing.Point(7, 2);
            this.lbl일자.Name = "lbl일자";
            this.lbl일자.Size = new System.Drawing.Size(100, 22);
            this.lbl일자.TabIndex = 351;
            this.lbl일자.Text = "일자";
            this.lbl일자.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl간략
            // 
            this.lbl간략.BackColor = System.Drawing.Color.PowderBlue;
            this.lbl간략.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl간략.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl간략.Location = new System.Drawing.Point(7, 37);
            this.lbl간략.Name = "lbl간략";
            this.lbl간략.Size = new System.Drawing.Size(100, 22);
            this.lbl간략.TabIndex = 352;
            this.lbl간략.Text = "표기";
            this.lbl간략.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt제목
            // 
            this.txt제목.Location = new System.Drawing.Point(113, 40);
            this.txt제목.Name = "txt제목";
            this.txt제목.Size = new System.Drawing.Size(89, 21);
            this.txt제목.TabIndex = 354;
            // 
            // dtp
            // 
            this.dtp.Location = new System.Drawing.Point(113, 3);
            this.dtp.Name = "dtp";
            this.dtp.Size = new System.Drawing.Size(169, 21);
            this.dtp.TabIndex = 355;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Gray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(10, 81);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 28);
            this.button1.TabIndex = 358;
            this.button1.Text = "저장";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Gray;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(123, 81);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(89, 28);
            this.button2.TabIndex = 359;
            this.button2.Text = "취소";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Black;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(208, 40);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(95, 23);
            this.button3.TabIndex = 360;
            this.button3.Text = "색상표";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.dtp);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.lbl일자);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.lbl간략);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.txt제목);
            this.panel1.Location = new System.Drawing.Point(0, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(403, 118);
            this.panel1.TabIndex = 361;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Gray;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F);
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(251, 81);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(89, 28);
            this.btnClear.TabIndex = 361;
            this.btnClear.Text = "클리어";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // frm일정관리
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightPink;
            this.ClientSize = new System.Drawing.Size(402, 128);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm일정관리";
            this.Text = "frm일정관리";
            this.Load += new System.EventHandler(this.frm일정관리_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl일자;
        private System.Windows.Forms.Label lbl간략;
        private System.Windows.Forms.TextBox txt제목;
        private System.Windows.Forms.DateTimePicker dtp;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClear;

    }
}