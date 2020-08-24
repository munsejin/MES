using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MES.CLS;

namespace MES.Popup
{
    public partial class popDatePicker : Form
    {
        public string START_DATE = "";
        public string END_DATE = "";

        public string returnS_date = "";
        public string returnE_date = "";

        private int desiredStartLocationX;
        private int desiredStartLocationY;

        private Button SelectedButtonTemp = null;
      
        public popDatePicker()
        {
            InitializeComponent();
        }

        public popDatePicker(string START_DATE, string END_DATE, int x, int y)
        {
            InitializeComponent();
            this.START_DATE = START_DATE;
            this.END_DATE = END_DATE;
            desiredStartLocationX = x;
            desiredStartLocationY = y;
        }

        private void popDatePicker_Load(object sender, EventArgs e)
        {
            this.SetDesktopLocation(desiredStartLocationX, desiredStartLocationY);

            if (START_DATE.Equals(""))
            {
                START_DATE = DateTime.Now.ToString("yyyy-MM-dd");
                END_DATE = DateTime.Now.ToString("yyyy-MM-dd");
                btn_today.BackColor = Color.FromArgb(27, 113, 189);
                btn_today.ForeColor = Color.WhiteSmoke;
                SelectedButtonTemp = btn_today;
            }
            else
            {
                btn_Custom.BackColor = Color.FromArgb(27, 113, 189);
                btn_Custom.ForeColor = Color.WhiteSmoke;
                SelectedButtonTemp = btn_Custom;
            }
            s_date.Text = START_DATE;
            e_date.Text = END_DATE;
            s_cal.SetDate(DateTime.Parse(START_DATE));
            e_cal.SetDate(DateTime.Parse(END_DATE));

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void s_cal_DateSelected(object sender, DateRangeEventArgs e)
        {
            MonthCalendar Cal = (MonthCalendar)sender;
            if (Cal.SelectionRange.Start == Cal.SelectionRange.End)
            {
                if (Cal.Name.Equals("s_cal"))
                {
                    s_date.Text = s_cal.SelectionStart.ToString("yyyy-MM-dd");
                    e_cal.Enabled = true;
                    e_cal.SetDate(DateTime.Parse(e_date.Text));

                    if (s_cal.SelectionStart > e_cal.SelectionStart)
                    {
                        e_date.Text = s_cal.SelectionStart.ToString("yyyy-MM-dd");
                        e_cal.SetDate(s_cal.SelectionStart);
                    }
                }
                else
                {
                    e_date.Text = e_cal.SelectionStart.ToString("yyyy-MM-dd");
                    s_cal.Enabled = true;
                    s_cal.SetDate(DateTime.Parse(s_date.Text));
                    if (s_cal.SelectionStart > e_cal.SelectionStart)
                    {
                        s_date.Text = e_cal.SelectionStart.ToString("yyyy-MM-dd");
                        s_cal.SetDate(e_cal.SelectionStart);
                    }
                }
            }
            else
            {
                s_date.Text = Cal.SelectionStart.ToString("yyyy-MM-dd");
                e_date.Text = Cal.SelectionEnd.ToString("yyyy-MM-dd");

                if (Cal.Name.Equals("s_cal"))
                {
                    e_cal.SuspendLayout();
                    e_cal.SelectionRange.Start = s_cal.SelectionStart;
                    e_cal.SelectionRange.End = s_cal.SelectionEnd;
                    e_cal.SetDate(DateTime.Parse(e_date.Text.ToString()));
                    e_cal.Update();
                }
                else
                {
                    s_cal.SuspendLayout();
                    s_cal.SelectionRange.Start = e_cal.SelectionStart;
                    s_cal.SelectionRange.End = e_cal.SelectionEnd;
                    s_cal.SetDate(DateTime.Parse(s_date.Text.ToString()));
                    s_cal.Update();
                }
            }
            SelectedButtonTemp.BackColor = Color.White;
            SelectedButtonTemp.ForeColor = SystemColors.WindowFrame;
            btn_Custom.BackColor = Color.FromArgb(27, 113, 189);
            btn_Custom.ForeColor = Color.WhiteSmoke;
            SelectedButtonTemp = btn_Custom;
        }

        private void btn_Date_Click(object sender, EventArgs e)
        {
            Button btnTemp = (Button)sender;
            switch (btnTemp.Name)
            {
                case "btn_today":
                    s_date.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    e_date.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    s_cal.SetDate(DateTime.Now);
                    e_cal.SetDate(DateTime.Now);
                    break;
                case "btn_yester":
                    s_date.Text = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
                    e_date.Text = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
                    s_cal.SetDate(DateTime.Now.AddDays(-1));
                    e_cal.SetDate(DateTime.Now.AddDays(-1));
                    break;
                case "btn_last7":
                    s_date.Text = DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd");
                    e_date.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    s_cal.SetDate(DateTime.Now.AddDays(-7));
                    e_cal.SetDate(DateTime.Now);
                    break;
                case "btn_last30":
                    s_date.Text = DateTime.Now.AddDays(-30).ToString("yyyy-MM-dd");
                    e_date.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    s_cal.SetDate(DateTime.Now.AddDays(-30));
                    e_cal.SetDate(DateTime.Now);
                    break;
                case "btn_thisM":
                    s_date.Text = DateTime.Now.ToString("yyyy-MM-dd").Substring(0, 8) + "01";
                    e_date.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    s_cal.SetDate(DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd").Substring(0,8)+"01"));
                    e_cal.SetDate(DateTime.Now);
                    break;
                case "btn_lastM":
                    DateTime last  = new DateTime(DateTime.Now.Year, DateTime.Now.AddMonths(-1).Month,
                                    DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.AddMonths(-1).Month));
                    s_date.Text = DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd").Substring(0, 8) + "01";
                    e_date.Text = last.ToString("yyyy-MM-dd");
                    s_cal.SetDate(DateTime.Parse(DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd").Substring(0, 8) + "01"));
                    e_cal.SetDate(last);
                    break;
            }
            SelectedButtonTemp.BackColor = Color.White;
            SelectedButtonTemp.ForeColor = SystemColors.WindowFrame;

            btnTemp.BackColor = Color.FromArgb(27, 113, 189);
            btnTemp.ForeColor = Color.WhiteSmoke;

            SelectedButtonTemp = btnTemp;
        }

        private void btn_Apply_Click(object sender, EventArgs e)
        {
            returnS_date = s_date.Text;
            returnE_date = e_date.Text;
            this.Close();
        }


    }
}
