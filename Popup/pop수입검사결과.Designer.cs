namespace MES.Popup
{
    partial class pop수입검사결과
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
            this.btn_Y = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_N = new System.Windows.Forms.Button();
            this.non_pass_amt = new MES.Controls.conTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pass_amt = new MES.Controls.conTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chk_amt = new MES.Controls.conTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chk_date = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl일자
            // 
            this.lbl일자.BackColor = System.Drawing.Color.PowderBlue;
            this.lbl일자.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F);
            this.lbl일자.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl일자.Location = new System.Drawing.Point(7, 3);
            this.lbl일자.Name = "lbl일자";
            this.lbl일자.Size = new System.Drawing.Size(100, 22);
            this.lbl일자.TabIndex = 351;
            this.lbl일자.Text = "검사기준일";
            this.lbl일자.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_Y
            // 
            this.btn_Y.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_Y.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Y.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F);
            this.btn_Y.ForeColor = System.Drawing.Color.White;
            this.btn_Y.Location = new System.Drawing.Point(18, 111);
            this.btn_Y.Name = "btn_Y";
            this.btn_Y.Size = new System.Drawing.Size(89, 28);
            this.btn_Y.TabIndex = 358;
            this.btn_Y.Text = "합격(v)";
            this.btn_Y.UseVisualStyleBackColor = false;
            this.btn_Y.Click += new System.EventHandler(this.btn_Y_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackColor = System.Drawing.Color.Gray;
            this.btn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancel.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F);
            this.btn_cancel.ForeColor = System.Drawing.Color.White;
            this.btn_cancel.Location = new System.Drawing.Point(67, 144);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(89, 28);
            this.btn_cancel.TabIndex = 359;
            this.btn_cancel.Text = "취소";
            this.btn_cancel.UseVisualStyleBackColor = false;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btn_N);
            this.panel1.Controls.Add(this.non_pass_amt);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.pass_amt);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.chk_amt);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.chk_date);
            this.panel1.Controls.Add(this.lbl일자);
            this.panel1.Controls.Add(this.btn_cancel);
            this.panel1.Controls.Add(this.btn_Y);
            this.panel1.Location = new System.Drawing.Point(3, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(223, 181);
            this.panel1.TabIndex = 361;
            // 
            // btn_N
            // 
            this.btn_N.BackColor = System.Drawing.Color.Crimson;
            this.btn_N.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_N.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F);
            this.btn_N.ForeColor = System.Drawing.Color.White;
            this.btn_N.Location = new System.Drawing.Point(113, 111);
            this.btn_N.Name = "btn_N";
            this.btn_N.Size = new System.Drawing.Size(89, 28);
            this.btn_N.TabIndex = 402;
            this.btn_N.Text = "불합격(x)";
            this.btn_N.UseVisualStyleBackColor = false;
            this.btn_N.Click += new System.EventHandler(this.btn_N_Click);
            // 
            // non_pass_amt
            // 
            this.non_pass_amt._AutoTab = true;
            this.non_pass_amt._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.non_pass_amt._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.non_pass_amt._WaterMarkColor = System.Drawing.Color.Gray;
            this.non_pass_amt._WaterMarkText = "";
            this.non_pass_amt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.non_pass_amt.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.non_pass_amt.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.non_pass_amt.Location = new System.Drawing.Point(116, 82);
            this.non_pass_amt.MaxLength = 100;
            this.non_pass_amt.Name = "non_pass_amt";
            this.non_pass_amt.Size = new System.Drawing.Size(96, 22);
            this.non_pass_amt.TabIndex = 401;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Crimson;
            this.label3.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F);
            this.label3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Location = new System.Drawing.Point(7, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 22);
            this.label3.TabIndex = 400;
            this.label3.Text = "불합격수량";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pass_amt
            // 
            this.pass_amt._AutoTab = true;
            this.pass_amt._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.pass_amt._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pass_amt._WaterMarkColor = System.Drawing.Color.Gray;
            this.pass_amt._WaterMarkText = "";
            this.pass_amt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pass_amt.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.pass_amt.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.pass_amt.Location = new System.Drawing.Point(116, 56);
            this.pass_amt.MaxLength = 100;
            this.pass_amt.Name = "pass_amt";
            this.pass_amt.Size = new System.Drawing.Size(96, 22);
            this.pass_amt.TabIndex = 399;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.SteelBlue;
            this.label2.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F);
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(7, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 22);
            this.label2.TabIndex = 398;
            this.label2.Text = "통과수량";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chk_amt
            // 
            this.chk_amt._AutoTab = true;
            this.chk_amt._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.chk_amt._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.chk_amt._WaterMarkColor = System.Drawing.Color.Gray;
            this.chk_amt._WaterMarkText = "";
            this.chk_amt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chk_amt.Enabled = false;
            this.chk_amt.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chk_amt.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.chk_amt.Location = new System.Drawing.Point(116, 29);
            this.chk_amt.MaxLength = 100;
            this.chk_amt.Name = "chk_amt";
            this.chk_amt.Size = new System.Drawing.Size(96, 22);
            this.chk_amt.TabIndex = 397;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.PowderBlue;
            this.label1.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(7, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 22);
            this.label1.TabIndex = 363;
            this.label1.Text = "검사수량";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chk_date
            // 
            this.chk_date.Checked = false;
            this.chk_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.chk_date.Location = new System.Drawing.Point(116, 4);
            this.chk_date.Name = "chk_date";
            this.chk_date.Size = new System.Drawing.Size(96, 21);
            this.chk_date.TabIndex = 362;
            this.chk_date.Value = new System.DateTime(2018, 10, 8, 0, 0, 0, 0);
            // 
            // pop수입검사결과
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(229, 189);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "pop수입검사결과";
            this.Text = "pop수입검사결과";
            this.Load += new System.EventHandler(this.pop수입검사결과_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl일자;
        private System.Windows.Forms.Button btn_Y;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker chk_date;
        private Controls.conTextBox non_pass_amt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        public Controls.conTextBox chk_amt;
        private System.Windows.Forms.Button btn_N;
        private Controls.conTextBox pass_amt;

    }
}