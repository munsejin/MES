namespace MES.Popup
{
    partial class pop오류리포트
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_intime = new MES.Controls.conTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_saup_nm = new MES.Controls.conTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmb_error_gubun = new MES.Controls.conComboBox();
            this.txt_error_report = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_input = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(316, 33);
            this.panel2.TabIndex = 108;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SpoqaHanSans-Bold", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.IndianRed;
            this.label1.Location = new System.Drawing.Point(10, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 28);
            this.label1.TabIndex = 96;
            this.label1.Text = "오류 리포트";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "거래처코드";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 120;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "거래처명";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 220;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "사업자번호";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "업태";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 80;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "종목";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 80;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "거래처담당자명";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 120;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "전화번호";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 140;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "담당사원";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 140;
            // 
            // txt_intime
            // 
            this.txt_intime._AutoTab = true;
            this.txt_intime._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.txt_intime._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txt_intime._WaterMarkColor = System.Drawing.Color.Gray;
            this.txt_intime._WaterMarkText = "";
            this.txt_intime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_intime.Enabled = false;
            this.txt_intime.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_intime.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.txt_intime.Location = new System.Drawing.Point(90, 45);
            this.txt_intime.MaxLength = 20;
            this.txt_intime.Name = "txt_intime";
            this.txt_intime.Size = new System.Drawing.Size(216, 22);
            this.txt_intime.TabIndex = 419;
            this.txt_intime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.IndianRed;
            this.label13.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(9, 45);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(77, 23);
            this.label13.TabIndex = 420;
            this.label13.Text = "등록일시";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.IndianRed;
            this.label2.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(9, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 23);
            this.label2.TabIndex = 423;
            this.label2.Text = "사업자";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_saup_nm
            // 
            this.txt_saup_nm._AutoTab = true;
            this.txt_saup_nm._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.txt_saup_nm._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txt_saup_nm._WaterMarkColor = System.Drawing.Color.Gray;
            this.txt_saup_nm._WaterMarkText = "";
            this.txt_saup_nm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_saup_nm.Enabled = false;
            this.txt_saup_nm.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_saup_nm.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.txt_saup_nm.Location = new System.Drawing.Point(90, 77);
            this.txt_saup_nm.MaxLength = 20;
            this.txt_saup_nm.Name = "txt_saup_nm";
            this.txt_saup_nm.Size = new System.Drawing.Size(216, 22);
            this.txt_saup_nm.TabIndex = 424;
            this.txt_saup_nm.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.IndianRed;
            this.label4.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(9, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 30);
            this.label4.TabIndex = 427;
            this.label4.Text = "구분";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmb_error_gubun
            // 
            this.cmb_error_gubun._BorderColor = System.Drawing.Color.Transparent;
            this.cmb_error_gubun._FocusedBackColor = System.Drawing.Color.White;
            this.cmb_error_gubun.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cmb_error_gubun.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F);
            this.cmb_error_gubun.FormattingEnabled = true;
            this.cmb_error_gubun.Location = new System.Drawing.Point(90, 107);
            this.cmb_error_gubun.Name = "cmb_error_gubun";
            this.cmb_error_gubun.Size = new System.Drawing.Size(216, 30);
            this.cmb_error_gubun.TabIndex = 428;
            // 
            // txt_error_report
            // 
            this.txt_error_report.Location = new System.Drawing.Point(9, 169);
            this.txt_error_report.Multiline = true;
            this.txt_error_report.Name = "txt_error_report";
            this.txt_error_report.Size = new System.Drawing.Size(297, 251);
            this.txt_error_report.TabIndex = 429;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.IndianRed;
            this.label3.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(9, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(297, 23);
            this.label3.TabIndex = 430;
            this.label3.Text = "오류 내용 및 개선 요청사항";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(3, 422);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(311, 69);
            this.label5.TabIndex = 431;
            this.label5.Text = "오류 발생 페이지, 어떤 작업을 수행하였는지를 상세하게 작성하여 주시면 프로그램 개선에 큰 도움이 됩니다. 감사합니다.";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_input
            // 
            this.btn_input.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.btn_input.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_input.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Bold);
            this.btn_input.ForeColor = System.Drawing.Color.IndianRed;
            this.btn_input.Location = new System.Drawing.Point(9, 499);
            this.btn_input.Name = "btn_input";
            this.btn_input.Size = new System.Drawing.Size(297, 48);
            this.btn_input.TabIndex = 432;
            this.btn_input.Text = "작성 완료 및 전송";
            this.btn_input.UseVisualStyleBackColor = true;
            this.btn_input.Click += new System.EventHandler(this.btn_input_Click);
            // 
            // pop오류리포트
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 557);
            this.Controls.Add(this.btn_input);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_error_report);
            this.Controls.Add(this.cmb_error_gubun);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_saup_nm);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_intime);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "pop오류리포트";
            this.ShowIcon = false;
            this.Text = "Error Report";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.pop오류리포트_FormClosing);
            this.Load += new System.EventHandler(this.pop오류리포트_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.Label label1;
        private Controls.conTextBox txt_intime;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label2;
        private Controls.conTextBox txt_saup_nm;
        private System.Windows.Forms.Label label4;
        private Controls.conComboBox cmb_error_gubun;
        private System.Windows.Forms.TextBox txt_error_report;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_input;

    }
}