namespace MES.Popup
{
    partial class pop초기재고수정
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pop초기재고수정));
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_input_date = new MES.Controls.conTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_input_cd = new MES.Controls.conTextBox();
            this.txt_seq = new MES.Controls.conTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_label_nm = new MES.Controls.conTextBox();
            this.conTextBox1 = new MES.Controls.conTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_updateValue = new MES.Controls.conTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btnExit);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(345, 33);
            this.panel2.TabIndex = 108;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SpoqaHanSans-Bold", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.label1.Location = new System.Drawing.Point(12, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 28);
            this.label1.TabIndex = 96;
            this.label1.Text = "입고 수량수정";
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnExit.Location = new System.Drawing.Point(196, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(137, 29);
            this.btnExit.TabIndex = 2;
            this.btnExit.TabStop = false;
            this.btnExit.Tag = "종료";
            this.btnExit.Text = "저장 후 닫기(&W)";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
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
            // txt_input_date
            // 
            this.txt_input_date._AutoTab = true;
            this.txt_input_date._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.txt_input_date._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txt_input_date._WaterMarkColor = System.Drawing.Color.Gray;
            this.txt_input_date._WaterMarkText = "";
            this.txt_input_date.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_input_date.Enabled = false;
            this.txt_input_date.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_input_date.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.txt_input_date.Location = new System.Drawing.Point(103, 38);
            this.txt_input_date.MaxLength = 20;
            this.txt_input_date.Name = "txt_input_date";
            this.txt_input_date.Size = new System.Drawing.Size(112, 22);
            this.txt_input_date.TabIndex = 419;
            this.txt_input_date.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.label13.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(22, 38);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(77, 23);
            this.label13.TabIndex = 420;
            this.label13.Text = "입고정보";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_input_cd
            // 
            this.txt_input_cd._AutoTab = true;
            this.txt_input_cd._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.txt_input_cd._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txt_input_cd._WaterMarkColor = System.Drawing.Color.Gray;
            this.txt_input_cd._WaterMarkText = "";
            this.txt_input_cd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_input_cd.Enabled = false;
            this.txt_input_cd.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_input_cd.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.txt_input_cd.Location = new System.Drawing.Point(221, 38);
            this.txt_input_cd.MaxLength = 20;
            this.txt_input_cd.Name = "txt_input_cd";
            this.txt_input_cd.Size = new System.Drawing.Size(46, 22);
            this.txt_input_cd.TabIndex = 421;
            this.txt_input_cd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_seq
            // 
            this.txt_seq._AutoTab = true;
            this.txt_seq._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.txt_seq._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txt_seq._WaterMarkColor = System.Drawing.Color.Gray;
            this.txt_seq._WaterMarkText = "";
            this.txt_seq.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_seq.Enabled = false;
            this.txt_seq.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_seq.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.txt_seq.Location = new System.Drawing.Point(273, 38);
            this.txt_seq.MaxLength = 20;
            this.txt_seq.Name = "txt_seq";
            this.txt_seq.Size = new System.Drawing.Size(46, 22);
            this.txt_seq.TabIndex = 422;
            this.txt_seq.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.label2.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(22, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 23);
            this.label2.TabIndex = 423;
            this.label2.Text = "품목명";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_label_nm
            // 
            this.txt_label_nm._AutoTab = true;
            this.txt_label_nm._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.txt_label_nm._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txt_label_nm._WaterMarkColor = System.Drawing.Color.Gray;
            this.txt_label_nm._WaterMarkText = "";
            this.txt_label_nm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_label_nm.Enabled = false;
            this.txt_label_nm.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_label_nm.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.txt_label_nm.Location = new System.Drawing.Point(103, 68);
            this.txt_label_nm.MaxLength = 20;
            this.txt_label_nm.Name = "txt_label_nm";
            this.txt_label_nm.Size = new System.Drawing.Size(216, 22);
            this.txt_label_nm.TabIndex = 424;
            this.txt_label_nm.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // conTextBox1
            // 
            this.conTextBox1._AutoTab = true;
            this.conTextBox1._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.conTextBox1._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.conTextBox1._WaterMarkColor = System.Drawing.Color.Gray;
            this.conTextBox1._WaterMarkText = "";
            this.conTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.conTextBox1.Enabled = false;
            this.conTextBox1.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.conTextBox1.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.conTextBox1.Location = new System.Drawing.Point(103, 91);
            this.conTextBox1.MaxLength = 20;
            this.conTextBox1.Name = "conTextBox1";
            this.conTextBox1.Size = new System.Drawing.Size(216, 22);
            this.conTextBox1.TabIndex = 426;
            this.conTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.conTextBox1.Visible = false;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.CadetBlue;
            this.label3.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(22, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 23);
            this.label3.TabIndex = 425;
            this.label3.Text = "품목명";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3.Visible = false;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            this.label4.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(22, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 23);
            this.label4.TabIndex = 425;
            this.label4.Text = "수정수량";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_updateValue
            // 
            this.txt_updateValue._AutoTab = true;
            this.txt_updateValue._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.txt_updateValue._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txt_updateValue._WaterMarkColor = System.Drawing.Color.Gray;
            this.txt_updateValue._WaterMarkText = "";
            this.txt_updateValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_updateValue.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_updateValue.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.txt_updateValue.Location = new System.Drawing.Point(103, 98);
            this.txt_updateValue.MaxLength = 20;
            this.txt_updateValue.Name = "txt_updateValue";
            this.txt_updateValue.Size = new System.Drawing.Size(216, 22);
            this.txt_updateValue.TabIndex = 426;
            this.txt_updateValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_updateValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_updateValue_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(48, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(249, 12);
            this.label5.TabIndex = 427;
            this.label5.Text = "입고 당시의 수량을 수정 값으로 변경합니다. ";
            // 
            // pop초기재고수정
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 145);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_updateValue);
            this.Controls.Add(this.conTextBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_label_nm);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_seq);
            this.Controls.Add(this.txt_input_cd);
            this.Controls.Add(this.txt_input_date);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "pop초기재고수정";
            this.ShowIcon = false;
            this.Text = "초기 재고수정";
            this.Load += new System.EventHandler(this.pop초기재고수정_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.Label label1;
        private Controls.conTextBox txt_input_date;
        private System.Windows.Forms.Label label13;
        private Controls.conTextBox txt_input_cd;
        private Controls.conTextBox txt_seq;
        private System.Windows.Forms.Label label2;
        private Controls.conTextBox txt_label_nm;
        private Controls.conTextBox conTextBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private Controls.conTextBox txt_updateValue;
        private System.Windows.Forms.Label label5;

    }
}