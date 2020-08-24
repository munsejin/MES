namespace MES.Popup
{
    partial class popDatePicker
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
            this.lineShape2 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_Apply = new System.Windows.Forms.Button();
            this.btn_Custom = new System.Windows.Forms.Button();
            this.btn_lastM = new System.Windows.Forms.Button();
            this.btn_thisM = new System.Windows.Forms.Button();
            this.btn_last30 = new System.Windows.Forms.Button();
            this.btn_last7 = new System.Windows.Forms.Button();
            this.btn_yester = new System.Windows.Forms.Button();
            this.btn_today = new System.Windows.Forms.Button();
            this.e_cal = new System.Windows.Forms.MonthCalendar();
            this.e_date = new MES.Controls.conLabel();
            this.s_date = new MES.Controls.conLabel();
            this.s_cal = new System.Windows.Forms.MonthCalendar();
            this.shapeContainer2 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lineShape2
            // 
            this.lineShape2.BorderColor = System.Drawing.Color.Gainsboro;
            this.lineShape2.Name = "lineShape2";
            this.lineShape2.X1 = 240;
            this.lineShape2.X2 = 240;
            this.lineShape2.Y1 = -3;
            this.lineShape2.Y2 = 230;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btn_Cancel);
            this.panel1.Controls.Add(this.btn_Apply);
            this.panel1.Controls.Add(this.btn_Custom);
            this.panel1.Controls.Add(this.btn_lastM);
            this.panel1.Controls.Add(this.btn_thisM);
            this.panel1.Controls.Add(this.btn_last30);
            this.panel1.Controls.Add(this.btn_last7);
            this.panel1.Controls.Add(this.btn_yester);
            this.panel1.Controls.Add(this.btn_today);
            this.panel1.Controls.Add(this.e_cal);
            this.panel1.Controls.Add(this.e_date);
            this.panel1.Controls.Add(this.s_date);
            this.panel1.Controls.Add(this.s_cal);
            this.panel1.Controls.Add(this.shapeContainer2);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(632, 241);
            this.panel1.TabIndex = 7;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.BackColor = System.Drawing.Color.Transparent;
            this.btn_Cancel.FlatAppearance.BorderSize = 0;
            this.btn_Cancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(245)))), ((int)(((byte)(251)))));
            this.btn_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cancel.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Cancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(113)))), ((int)(((byte)(189)))));
            this.btn_Cancel.Location = new System.Drawing.Point(481, 201);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(69, 31);
            this.btn_Cancel.TabIndex = 19;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_Apply
            // 
            this.btn_Apply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(113)))), ((int)(((byte)(189)))));
            this.btn_Apply.FlatAppearance.BorderSize = 0;
            this.btn_Apply.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(245)))), ((int)(((byte)(251)))));
            this.btn_Apply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Apply.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Apply.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_Apply.Location = new System.Drawing.Point(554, 202);
            this.btn_Apply.Name = "btn_Apply";
            this.btn_Apply.Size = new System.Drawing.Size(69, 31);
            this.btn_Apply.TabIndex = 18;
            this.btn_Apply.Text = "Apply";
            this.btn_Apply.UseVisualStyleBackColor = false;
            this.btn_Apply.Click += new System.EventHandler(this.btn_Apply_Click);
            // 
            // btn_Custom
            // 
            this.btn_Custom.BackColor = System.Drawing.Color.White;
            this.btn_Custom.FlatAppearance.BorderSize = 0;
            this.btn_Custom.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(245)))), ((int)(((byte)(251)))));
            this.btn_Custom.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(245)))), ((int)(((byte)(251)))));
            this.btn_Custom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Custom.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 9F);
            this.btn_Custom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_Custom.Location = new System.Drawing.Point(481, 172);
            this.btn_Custom.Name = "btn_Custom";
            this.btn_Custom.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btn_Custom.Size = new System.Drawing.Size(141, 25);
            this.btn_Custom.TabIndex = 17;
            this.btn_Custom.Text = "Custom Range";
            this.btn_Custom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Custom.UseVisualStyleBackColor = false;
            // 
            // btn_lastM
            // 
            this.btn_lastM.BackColor = System.Drawing.Color.White;
            this.btn_lastM.FlatAppearance.BorderSize = 0;
            this.btn_lastM.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(245)))), ((int)(((byte)(251)))));
            this.btn_lastM.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(245)))), ((int)(((byte)(251)))));
            this.btn_lastM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_lastM.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 9F);
            this.btn_lastM.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_lastM.Location = new System.Drawing.Point(481, 145);
            this.btn_lastM.Name = "btn_lastM";
            this.btn_lastM.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btn_lastM.Size = new System.Drawing.Size(141, 25);
            this.btn_lastM.TabIndex = 16;
            this.btn_lastM.Text = "Last Month";
            this.btn_lastM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_lastM.UseVisualStyleBackColor = false;
            this.btn_lastM.Click += new System.EventHandler(this.btn_Date_Click);
            // 
            // btn_thisM
            // 
            this.btn_thisM.BackColor = System.Drawing.Color.White;
            this.btn_thisM.FlatAppearance.BorderSize = 0;
            this.btn_thisM.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(245)))), ((int)(((byte)(251)))));
            this.btn_thisM.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(245)))), ((int)(((byte)(251)))));
            this.btn_thisM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_thisM.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 9F);
            this.btn_thisM.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_thisM.Location = new System.Drawing.Point(481, 118);
            this.btn_thisM.Name = "btn_thisM";
            this.btn_thisM.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btn_thisM.Size = new System.Drawing.Size(141, 25);
            this.btn_thisM.TabIndex = 15;
            this.btn_thisM.Text = "This Month";
            this.btn_thisM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_thisM.UseVisualStyleBackColor = false;
            this.btn_thisM.Click += new System.EventHandler(this.btn_Date_Click);
            // 
            // btn_last30
            // 
            this.btn_last30.BackColor = System.Drawing.Color.White;
            this.btn_last30.FlatAppearance.BorderSize = 0;
            this.btn_last30.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(245)))), ((int)(((byte)(251)))));
            this.btn_last30.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(245)))), ((int)(((byte)(251)))));
            this.btn_last30.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_last30.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 9F);
            this.btn_last30.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_last30.Location = new System.Drawing.Point(481, 91);
            this.btn_last30.Name = "btn_last30";
            this.btn_last30.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btn_last30.Size = new System.Drawing.Size(141, 25);
            this.btn_last30.TabIndex = 14;
            this.btn_last30.Text = "Last 30 Days";
            this.btn_last30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_last30.UseVisualStyleBackColor = false;
            this.btn_last30.Click += new System.EventHandler(this.btn_Date_Click);
            // 
            // btn_last7
            // 
            this.btn_last7.BackColor = System.Drawing.Color.White;
            this.btn_last7.FlatAppearance.BorderSize = 0;
            this.btn_last7.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(245)))), ((int)(((byte)(251)))));
            this.btn_last7.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(245)))), ((int)(((byte)(251)))));
            this.btn_last7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_last7.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 9F);
            this.btn_last7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_last7.Location = new System.Drawing.Point(481, 64);
            this.btn_last7.Name = "btn_last7";
            this.btn_last7.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btn_last7.Size = new System.Drawing.Size(141, 25);
            this.btn_last7.TabIndex = 13;
            this.btn_last7.Text = "Last 7 Days";
            this.btn_last7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_last7.UseVisualStyleBackColor = false;
            this.btn_last7.Click += new System.EventHandler(this.btn_Date_Click);
            // 
            // btn_yester
            // 
            this.btn_yester.BackColor = System.Drawing.Color.White;
            this.btn_yester.FlatAppearance.BorderSize = 0;
            this.btn_yester.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(245)))), ((int)(((byte)(251)))));
            this.btn_yester.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(245)))), ((int)(((byte)(251)))));
            this.btn_yester.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_yester.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 9F);
            this.btn_yester.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_yester.Location = new System.Drawing.Point(481, 37);
            this.btn_yester.Name = "btn_yester";
            this.btn_yester.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btn_yester.Size = new System.Drawing.Size(141, 25);
            this.btn_yester.TabIndex = 12;
            this.btn_yester.Text = "Yesterday";
            this.btn_yester.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_yester.UseVisualStyleBackColor = false;
            this.btn_yester.Click += new System.EventHandler(this.btn_Date_Click);
            // 
            // btn_today
            // 
            this.btn_today.BackColor = System.Drawing.Color.White;
            this.btn_today.FlatAppearance.BorderSize = 0;
            this.btn_today.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(245)))), ((int)(((byte)(251)))));
            this.btn_today.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(245)))), ((int)(((byte)(251)))));
            this.btn_today.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_today.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 9F);
            this.btn_today.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_today.Location = new System.Drawing.Point(481, 10);
            this.btn_today.Name = "btn_today";
            this.btn_today.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btn_today.Size = new System.Drawing.Size(141, 25);
            this.btn_today.TabIndex = 11;
            this.btn_today.Text = "Today";
            this.btn_today.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_today.UseVisualStyleBackColor = false;
            this.btn_today.Click += new System.EventHandler(this.btn_Date_Click);
            // 
            // e_cal
            // 
            this.e_cal.BackColor = System.Drawing.Color.White;
            this.e_cal.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 9F);
            this.e_cal.ForeColor = System.Drawing.Color.LightBlue;
            this.e_cal.Location = new System.Drawing.Point(249, 55);
            this.e_cal.MaxSelectionCount = 9999;
            this.e_cal.Name = "e_cal";
            this.e_cal.ShowToday = false;
            this.e_cal.ShowTodayCircle = false;
            this.e_cal.ShowWeekNumbers = true;
            this.e_cal.TabIndex = 10;
            this.e_cal.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.s_cal_DateSelected);
            // 
            // e_date
            // 
            this.e_date._BorderColor = System.Drawing.Color.Gainsboro;
            this.e_date.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F);
            this.e_date.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.e_date.Location = new System.Drawing.Point(251, 29);
            this.e_date.Name = "e_date";
            this.e_date.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.e_date.Size = new System.Drawing.Size(214, 23);
            this.e_date.TabIndex = 9;
            this.e_date.Text = "2000-01-01";
            this.e_date.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // s_date
            // 
            this.s_date._BorderColor = System.Drawing.Color.Gainsboro;
            this.s_date.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 11F);
            this.s_date.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.s_date.Location = new System.Drawing.Point(13, 29);
            this.s_date.Name = "s_date";
            this.s_date.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.s_date.Size = new System.Drawing.Size(214, 23);
            this.s_date.TabIndex = 8;
            this.s_date.Text = "2000-01-01";
            this.s_date.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // s_cal
            // 
            this.s_cal.BackColor = System.Drawing.Color.White;
            this.s_cal.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 9F);
            this.s_cal.ForeColor = System.Drawing.Color.LightBlue;
            this.s_cal.Location = new System.Drawing.Point(11, 55);
            this.s_cal.MaxSelectionCount = 9999;
            this.s_cal.Name = "s_cal";
            this.s_cal.ShowToday = false;
            this.s_cal.ShowTodayCircle = false;
            this.s_cal.ShowWeekNumbers = true;
            this.s_cal.TabIndex = 7;
            this.s_cal.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.s_cal_DateSelected);
            // 
            // shapeContainer2
            // 
            this.shapeContainer2.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer2.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer2.Name = "shapeContainer2";
            this.shapeContainer2.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape1,
            this.lineShape2});
            this.shapeContainer2.Size = new System.Drawing.Size(630, 239);
            this.shapeContainer2.TabIndex = 0;
            this.shapeContainer2.TabStop = false;
            // 
            // lineShape1
            // 
            this.lineShape1.BorderColor = System.Drawing.Color.Gainsboro;
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 479;
            this.lineShape1.X2 = 480;
            this.lineShape1.Y1 = -1;
            this.lineShape1.Y2 = 231;
            // 
            // popDatePicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(633, 242);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "popDatePicker";
            this.Text = "popDatePicker";
            this.Load += new System.EventHandler(this.popDatePicker_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_today;
        private System.Windows.Forms.MonthCalendar e_cal;
        private Controls.conLabel e_date;
        private Controls.conLabel s_date;
        private System.Windows.Forms.MonthCalendar s_cal;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer2;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_Apply;
        private System.Windows.Forms.Button btn_Custom;
        private System.Windows.Forms.Button btn_lastM;
        private System.Windows.Forms.Button btn_thisM;
        private System.Windows.Forms.Button btn_last30;
        private System.Windows.Forms.Button btn_last7;
        private System.Windows.Forms.Button btn_yester;


    }
}