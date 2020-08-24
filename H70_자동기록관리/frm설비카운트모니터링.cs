using MES.CLS;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MES.H70_자동기록관리
{
    public partial class frm설비카운트모니터링 : Form
    {
        wnGConstant wConst = new wnGConstant();
        bool alramFlag = false;
        DataGridViewCellStyle st = new DataGridViewCellStyle();

        bool garaFlag = false;
        bool endFlag = false;

        public frm설비카운트모니터링()
        {
            InitializeComponent();
        }

        private void frm설비카운트모니터링_Load(object sender, EventArgs e)
        {
            lbl_title.Tag = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[0] + "$" + wnDm.fn_TitleName(this.Name.ToString()).Split('$')[1]; lbl_title.Text = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[2];
            txt_place.Text = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[2] + " 현황";
            lbl_start_date.Text = DateTime.Now.ToString("yyyy-MM-dd");
            lbl_end_date.Text = DateTime.Now.ToString("yyyy-MM-dd");
            set_BtnSetDateValue();

            grd_setting();

            txt_place.TextAlign = HorizontalAlignment.Left;

            ComInfo comInfo = new ComInfo();

            string sqlQuery = "";

            cmb_tmp_loc.ValueMember = "코드";
            cmb_tmp_loc.DisplayMember = "명칭";
            sqlQuery = comInfo.querySensorLoc();
            wConst.ComboBox_Read_ALL(cmb_tmp_loc, sqlQuery);

            timer1.Interval = 1000;
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();

            timer2.Tick += new EventHandler(timer2_Tick);
            timer2.Interval = 1000; //스케쥴 간격을 5분으로 준 것이다.
            timer2.Start(); //타이머를 발동시킨다.

            //timer3.Tick += new EventHandler(timer3_Tick);
            //timer3.Interval = 1000; //스케쥴 간격을 5분으로 준 것이다.

            timer4.Tick += new EventHandler(timer4_Tick);
            timer4.Interval = 3500; //스케쥴 간격을 5분으로 준 것이다.
            timer4.Start(); //타이머를 발동시킨다.

            Print_Sensor_Log();
            get_data();
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            try
            {
                if (garaFlag)
                {
                    wnDm wDm = new wnDm();
                    if (!endFlag)
                    {
                        wDm.fn_insert_gara_new(DateTime.Now.ToString("yyyy-MM-dd"));
                    }
                    else
                    {
                        wDm.fn_insert_gara_end(DateTime.Now.ToString("yyyy-MM-dd"));
                        garaFlag = false;
                        endFlag = false;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        
        private void grd_setting()
        {
            dataSensorGrid.Rows.Clear();

            this.dataSensorGrid.ColumnHeadersDefaultCellStyle.Font = new Font("Noto Sans CJK KR Regular", 40, FontStyle.Bold);
            this.dataSensorGrid.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            this.dataSensorGrid.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            this.dataSensorGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
        }
        //데이터값 넣어주는 메소드

        private void get_data()
        {
            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = wDm.fn_Select_Inter_Count_Monitor();

                if (dt != null && dt.Rows.Count > 0)
                {
                    dataSensorGrid.RowCount = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dataSensorGrid.Rows[i].Height = 120;
                        dataSensorGrid.Rows[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dataSensorGrid.Rows[i].Cells["GUBUN"].Value = dt.Rows[i]["M_NAME"].ToString();
                        dataSensorGrid.Rows[i].Cells["COUNT"].Value = dt.Rows[i]["COUNT"].ToString();
                        dataSensorGrid.Rows[i].Cells["START_TIME"].Value = dt.Rows[i]["START_TIME"].ToString();
                        dataSensorGrid.Rows[i].Cells["END_TIME"].Value = dt.Rows[i]["END_TIME"].ToString();
                        dataSensorGrid.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(24, 48, 76);
                        dataSensorGrid.Rows[i].DefaultCellStyle.SelectionBackColor = Color.FromArgb(24, 48, 76);
                        DataGridViewCellStyle style = new DataGridViewCellStyle();
                        style.ForeColor = Color.IndianRed;
                        style.SelectionForeColor = Color.FromArgb(253, 91, 83);
                        dataSensorGrid.Rows[i].Cells[1].Style = style;
                    }
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("시스템 오류: " + e.ToString());
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(e.Message + " - " + e.ToString());
                msg.ShowDialog();
            }
        }

        

        private void timer1_Tick(object sender, EventArgs e)
        {
            get_data();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            txt_time.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            Keys key = keyData & ~(Keys.Shift | Keys.Control);
            switch (key)
            {
                case Keys.W:
                    // 조합키 사용 시
                    if ((keyData & Keys.Control) != 0)
                    {
                        this.Close();
                    }
                    else return base.ProcessCmdKey(ref msg, keyData);
                    break;
                case Keys.S:
                    // 조합키 사용 시
                    if ((keyData & Keys.Control) != 0)
                    {
                    }
                    else return base.ProcessCmdKey(ref msg, keyData);
                    break;
                case Keys.F5:
                    // 단일키 사용시
                    get_data();
                    Print_Sensor_Log();
                    break;
                case Keys.F9:
                    // 단일키 사용시
                    garaFlag = true;
                    break;
                case Keys.F10:
                    // 단일키 사용시
                    if (garaFlag)
                    {
                        endFlag = true;
                    }
                    break;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
            return true;
        }


        private void btn_SetDate_MouseClick(object sender, MouseEventArgs e)
        {
            Button btnTemp = (Button)sender;
            Popup.popDatePicker msg = new Popup.popDatePicker(lbl_start_date.Text, lbl_end_date.Text, Cursor.Position.X, Cursor.Position.Y);
            //msg.StartPosition = FormStartPosition.
            msg.Location = new Point(btnTemp.Location.X + btnTemp.Width + 7, btnTemp.Location.Y + 152);
            msg.ShowDialog();

            if (!msg.returnS_date.Equals(""))
            {
                lbl_start_date.Text = msg.returnS_date;
                lbl_end_date.Text = msg.returnE_date;
                set_BtnSetDateValue();
                Print_Sensor_Log();
            }
        }

        private void set_BtnSetDateValue()
        {
            btn_SetDate.Text = lbl_start_date.Text + " - " + lbl_end_date.Text + " ▼";
        }

        private void dataSensorGrid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if ((e.PaintParts & DataGridViewPaintParts.ContentForeground) != 0 && e.FormattedValue != null && e.FormattedValue.ToString().Length > 0
                && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var cellText = e.FormattedValue.ToString();
                for (var fontSize = 72; fontSize >= 1; fontSize--)
                {
                    var font = new Font(e.CellStyle.Font.FontFamily, fontSize, e.CellStyle.Font.Style);
                    var textSize = TextRenderer.MeasureText(cellText, font);
                    //var textSize = e.Graphics.MeasureString(cellText, font); 
                    
                    //MessageBox.Show("t:w"+textSize.Width+" c:w"+ e.CellBounds.Width +" t:h"+ textSize.Height +" c:h"+ e.CellBounds.Height);
                    if (textSize.Width < e.CellBounds.Width && textSize.Height < e.CellBounds.Height)
                    {
                        font = new Font(e.CellStyle.Font.FontFamily, fontSize - 1, e.CellStyle.Font.Style);
                        e.CellStyle.Font = font;
                        e.Paint(e.ClipBounds, e.PaintParts);
                        e.Handled = true;
                        break;
                    }
                }
            }
        }

        private void Print_Sensor_Log()
        {
            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = null;

                StringBuilder sb = new StringBuilder();
                sb.AppendLine(" and A.INTER_DATE >= '" + lbl_start_date.Text.ToString() + "' and A.INTER_DATE <= '" + lbl_end_date.Text.ToString() + "'  ");
                dt = wDm.fn_Select_Inter_Count(sb.ToString());

                dataSensorLogGrid.Rows.Clear();

                if (dt != null && dt.Rows.Count > 0)
                {
                    dataSensorLogGrid.RowCount = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dataSensorLogGrid.Rows[i].Cells["입력일자"].Value = dt.Rows[i]["INTER_DATE"].ToString();
                        dataSensorLogGrid.Rows[i].Cells["입력번호"].Value = dt.Rows[i]["INTER_CD"].ToString();
                        dataSensorLogGrid.Rows[i].Cells["입력시간"].Value = dt.Rows[i]["INTER_TIME"].ToString();
                        dataSensorLogGrid.Rows[i].Cells["시작시간"].Value = dt.Rows[i]["START_TIME"].ToString();
                        dataSensorLogGrid.Rows[i].Cells["종료시간"].Value = dt.Rows[i]["END_TIME"].ToString();
                        dataSensorLogGrid.Rows[i].Cells["설비코드"].Value = dt.Rows[i]["M_CODE"].ToString();
                        dataSensorLogGrid.Rows[i].Cells["설비명"].Value = dt.Rows[i]["M_NAME"].ToString();
                        dataSensorLogGrid.Rows[i].Cells["설비위치"].Value = dt.Rows[i]["LOC_NM"].ToString();
                        dataSensorLogGrid.Rows[i].Cells["카운트"].Value = decimal.Parse(dt.Rows[i]["COUNT"].ToString()).ToString("#,0.######");
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("온습도 센서 조회 시 오류 발생");
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                msg.ShowDialog();
                return;
            }


        }

        private void btnCustSrch_Click(object sender, EventArgs e)
        {
            Print_Sensor_Log();
        }

        private void btn출력_Click(object sender, EventArgs e)
        {
            btn출력.Enabled = false;

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Save as Excel File";
            sfd.Filter = "Excel 통합 문서 (*.xlsx)|*.xlsx|Excel 97 - 2003 통합문서(*.xls)|*.xls";
            if (lbl_start_date.Text.ToString().Equals(lbl_end_date.Text.ToString()))
            {
                sfd.FileName = lbl_start_date.Text + " 온습도기 현황";
            }
            else
            {
                sfd.FileName = lbl_start_date.Text + " ~ " + lbl_end_date.Text + " 온습도기 현황";
            }
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                lblMsg.Visible = true;
                Application.DoEvents();
                wnGConstant.dataGridView_ExportToExcel_Temp(sfd.FileName, dataSensorLogGrid);
                lblMsg.Visible = false;
                MessageBox.Show("엑셀 출력이 완료되었습니다");
            }




            btn출력.Enabled = true;
        }

        private void lbl_title_Click(object sender, EventArgs e)
        {

        }

        

    }
}
