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

namespace MES.A01_TMP
{
    public partial class frm온습도기모니터링 : Form
    {
        wnGConstant wConst = new wnGConstant();
        bool alramFlag = false;
        DataGridViewCellStyle st = new DataGridViewCellStyle();
        public frm온습도기모니터링()
        {
            InitializeComponent();
        }

        private void frm온습도기모니터링_Load(object sender, EventArgs e)
        {

            lbl_start_date.Text = DateTime.Now.ToString("yyyy-MM-dd");
            lbl_end_date.Text = DateTime.Now.ToString("yyyy-MM-dd");
            set_BtnSetDateValue();

            txt_place.TextAlign = HorizontalAlignment.Center;

            ComInfo comInfo = new ComInfo();

            string sqlQuery = "";

            cmb_tmp_loc.ValueMember = "코드";
            cmb_tmp_loc.DisplayMember = "명칭";
            sqlQuery = comInfo.querySensorLoc();
            wConst.ComboBox_Read_ALL(cmb_tmp_loc, sqlQuery);

            cmb_type_gbn.ValueMember = "코드";
            cmb_type_gbn.DisplayMember = "명칭";
            sqlQuery = comInfo.querySensorType();
            wConst.ComboBox_Read_ALL(cmb_type_gbn, sqlQuery);

            grd_setting();

            timer1.Interval = 300000;
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();

            timer2.Tick += new EventHandler(timer2_Tick);
            timer2.Interval = 1000; //스케쥴 간격을 5분으로 준 것이다.
            timer2.Start(); //타이머를 발동시킨다.

            timer3.Tick += new EventHandler(timer3_Tick);
            timer3.Interval = 1000; //스케쥴 간격을 5분으로 준 것이다.

            get_data();
            Print_Sensor_Log();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < dataSensorGrid.Rows.Count; i++)
            {
                if (decimal.Parse(dataSensorGrid.Rows[i].Cells["온도하한"].Value.ToString().Replace(",", "")) > decimal.Parse(dataSensorGrid.Rows[i].Cells[1].Value.ToString().Replace("℃", "")))
                {
                    if (alramFlag)
                    {
                        st.ForeColor = Color.Gold;
                        st.SelectionForeColor = Color.Gold;
                        dataSensorGrid.Rows[i].Cells[1].Style = st;
                    }
                    else
                    {
                        st.ForeColor = Color.FromArgb(253, 91, 83);
                        st.SelectionForeColor = Color.FromArgb(253, 91, 83);
                        dataSensorGrid.Rows[i].Cells[1].Style = st;
                    }
                }
                else if (decimal.Parse(dataSensorGrid.Rows[i].Cells["온도상한"].Value.ToString().Replace(",", "")) < decimal.Parse(dataSensorGrid.Rows[i].Cells[1].Value.ToString().Replace("℃", "")))
                {
                    if (alramFlag)
                    {
                        st.ForeColor = Color.Gold;
                        st.SelectionForeColor = Color.Gold;
                        dataSensorGrid.Rows[i].Cells[1].Style = st;
                    }
                    else
                    {
                        st.ForeColor = Color.FromArgb(253, 91, 83);
                        st.SelectionForeColor = Color.FromArgb(253, 91, 83);
                        dataSensorGrid.Rows[i].Cells[1].Style = st;
                    }
                }

                if (decimal.Parse(dataSensorGrid.Rows[i].Cells["습도하한"].Value.ToString().Replace(",", "")) > decimal.Parse(dataSensorGrid.Rows[i].Cells[2].Value.ToString().Replace("%", "")))
                {
                    if (alramFlag)
                    {
                        st.ForeColor = Color.Gold;
                        st.SelectionForeColor = Color.Gold;
                        dataSensorGrid.Rows[i].Cells[2].Style = st;
                    }
                    else
                    {
                        st.ForeColor = Color.FromArgb(253, 91, 83);
                        st.SelectionForeColor = Color.FromArgb(253, 91, 83);
                        dataSensorGrid.Rows[i].Cells[2].Style = st;
                    }
                }
                else if (decimal.Parse(dataSensorGrid.Rows[i].Cells["습도상한"].Value.ToString().Replace(",", "")) < decimal.Parse(dataSensorGrid.Rows[i].Cells[2].Value.ToString().Replace("%", "")))
                {
                    if (alramFlag)
                    {
                        st.ForeColor = Color.Gold;
                        st.SelectionForeColor = Color.Gold;
                        dataSensorGrid.Rows[i].Cells[2].Style = st;
                    }
                    else
                    {
                        st.ForeColor = Color.FromArgb(253, 91, 83);
                        st.SelectionForeColor = Color.FromArgb(253, 91, 83);
                        dataSensorGrid.Rows[i].Cells[2].Style = st;
                    }
                }
            }
            alramFlag = !alramFlag;
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
                if (Common.p_strPLC_URL.Equals(""))
                {
                    MessageBox.Show("온습도기 데이터 접근정보가 없습니다.");
                    return;
                }
                string result = wnGConstant.Request_Json(Common.p_strPLC_URL);


                System.Net.WebClient wcClient = new System.Net.WebClient();
                JObject data = JObject.Parse(result);

                JArray arr = JArray.Parse(data["datas"].ToString());

                string deviceId = arr[0]["device_id"].ToString();
                JArray sensorArr = JArray.Parse(arr[0]["sensors"].ToString());

                dataSensorGrid.Rows.Clear();
                for (int i = 0; i < sensorArr.Count; i++)
                {
                    JObject itemObj = (JObject)sensorArr[i];
                    bool isOnAlready = false;
                    for (int j = 0; j < dataSensorGrid.Rows.Count; j++)
                    {
                        if ((dataSensorGrid.Rows[j].Cells["컨트롤러ID"].Value != null && dataSensorGrid.Rows[j].Cells["컨트롤러ID"].Value.ToString().Equals(deviceId))
                            && (dataSensorGrid.Rows[j].Cells["하우스"].Value != null && dataSensorGrid.Rows[j].Cells["하우스"].Value.ToString().Equals(itemObj["h_idx"].ToString()))
                            && (dataSensorGrid.Rows[j].Cells["노드"].Value != null && dataSensorGrid.Rows[j].Cells["노드"].Value.ToString().Equals(itemObj["n_idx"].ToString()))
                            && (dataSensorGrid.Rows[j].Cells["채널"].Value != null && dataSensorGrid.Rows[j].Cells["채널"].Value.ToString().Equals(itemObj["channel"].ToString()))
                            )
                        {
                            isOnAlready = true;
                            break;
                        }
                    }

                    if (isOnAlready)
                    {
                        dataSensorGrid.Rows[dataSensorGrid.Rows.Count - 1].Cells[2].Value = itemObj["value"].ToString() +"%";
                        continue;
                    }

                    wnDm wDm = new wnDm();
                    DataTable dt = wDm.fn_select_Sensor_code(deviceId, itemObj["h_idx"].ToString(), itemObj["n_idx"].ToString(), itemObj["channel"].ToString());

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        dataSensorGrid.Rows.Add();

                        dataSensorGrid.Rows[dataSensorGrid.Rows.Count - 1].Height = 120;

                        dataSensorGrid.Rows[dataSensorGrid.Rows.Count - 1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                        //dataSensorGrid.Rows[dataSensorGrid.Rows.Count - 1].DividerHeight = 5;

                        //dataSensorGrid.Columns[dataSensorGrid.Rows.Count - 1].DividerWidth = 5;

                        dataSensorGrid.Rows[dataSensorGrid.Rows.Count - 1].Cells[0].Value = dt.Rows[0]["S_LOC_NM"].ToString()+" : "+dt.Rows[0]["S_NM"].ToString();
                        //dataSensorGrid.Rows[dataSensorGrid.Rows.Count - 1].Cells["설치위치"].Value = dt.Rows[0]["S_LOC_NM"].ToString();
                        //dataSensorGrid.Rows[dataSensorGrid.Rows.Count - 1].Cells["설치위치코드"].Value = dt.Rows[0]["S_LOC_CD"].ToString();
                        dataSensorGrid.Rows[dataSensorGrid.Rows.Count - 1].Cells["온도하한"].Value = decimal.Parse(dt.Rows[0]["TMP_LOW"].ToString()).ToString("#,0.######");
                        dataSensorGrid.Rows[dataSensorGrid.Rows.Count - 1].Cells["온도상한"].Value = decimal.Parse(dt.Rows[0]["TMP_HIGH"].ToString()).ToString("#,0.######");
                        dataSensorGrid.Rows[dataSensorGrid.Rows.Count - 1].Cells["습도하한"].Value = decimal.Parse(dt.Rows[0]["HUMI_LOW"].ToString()).ToString("#,0.######");
                        dataSensorGrid.Rows[dataSensorGrid.Rows.Count - 1].Cells["습도상한"].Value = decimal.Parse(dt.Rows[0]["HUMI_HIGH"].ToString()).ToString("#,0.######");
                        dataSensorGrid.Rows[dataSensorGrid.Rows.Count - 1].Cells["컨트롤러ID"].Value = deviceId;
                        dataSensorGrid.Rows[dataSensorGrid.Rows.Count - 1].Cells["하우스"].Value = itemObj["h_idx"].ToString();
                        dataSensorGrid.Rows[dataSensorGrid.Rows.Count - 1].Cells["노드"].Value = itemObj["n_idx"].ToString();
                        dataSensorGrid.Rows[dataSensorGrid.Rows.Count - 1].Cells["채널"].Value = itemObj["channel"].ToString();
                        dataSensorGrid.Rows[dataSensorGrid.Rows.Count - 1].Cells[1].Value = itemObj["value"].ToString()+"℃";
                        dataSensorGrid.Rows[dataSensorGrid.Rows.Count - 1].DefaultCellStyle.BackColor = Color.FromArgb(24, 48, 76);
                        dataSensorGrid.Rows[dataSensorGrid.Rows.Count - 1].DefaultCellStyle.SelectionBackColor = Color.FromArgb(24, 48, 76);


                        DataGridViewCellStyle style = new DataGridViewCellStyle();
                        style.ForeColor = Color.IndianRed;
                        style.SelectionForeColor = Color.FromArgb(253, 91, 83);
                        dataSensorGrid.Rows[dataSensorGrid.Rows.Count - 1].Cells[1].Style = style;
                        dataSensorGrid.Rows[dataSensorGrid.Rows.Count - 1].Cells[2].Style = style;
                    }
                }

                chk_lowHigh();
            }
            catch (Exception e)
            {
                MessageBox.Show("시스템 오류: " + e.ToString());
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(e.Message + " - " + e.ToString());
                msg.ShowDialog();
            }
        }

        private void chk_lowHigh()
        {
            for (int i = 0; i < dataSensorGrid.Rows.Count; i++)
            {
                if (decimal.Parse(dataSensorGrid.Rows[i].Cells["온도하한"].Value.ToString().Replace(",", "")) > decimal.Parse(dataSensorGrid.Rows[i].Cells[1].Value.ToString().Replace("℃", "")))
                {
                    timer3.Start();
                    return;
                }
                else if (decimal.Parse(dataSensorGrid.Rows[i].Cells["온도상한"].Value.ToString().Replace(",", "")) < decimal.Parse(dataSensorGrid.Rows[i].Cells[1].Value.ToString().Replace("℃", "")))
                {
                    timer3.Start();
                    return;
                }
                else if (decimal.Parse(dataSensorGrid.Rows[i].Cells["습도하한"].Value.ToString().Replace(",", "")) > decimal.Parse(dataSensorGrid.Rows[i].Cells[2].Value.ToString().Replace("%", "")))
                {
                    timer3.Start();
                    return;
                }
                else if (decimal.Parse(dataSensorGrid.Rows[i].Cells["습도상한"].Value.ToString().Replace(",", "")) < decimal.Parse(dataSensorGrid.Rows[i].Cells[2].Value.ToString().Replace("%", "")))
                {
                    timer3.Start();
                    return;
                }
            }
            timer3.Stop();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
           // timer1.Interval = 300000; //스케쥴 간격을 5분으로 준 것이다.
           // timer1.Start(); //타이머를 발동시킨다.
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
                sb.AppendLine(" and SUBSTRING(A.INTIME,0,11) >= '" + lbl_start_date.Text + "' and SUBSTRING(A.INTIME,0,11) <= '" + lbl_end_date.Text + "' ");

                if (!chk_all.Checked)
                {
                    sb.AppendLine(" and   (case when A.S_TYPE = '1' then  ");
                    sb.AppendLine("   case when N.TMP_HIGH+2 < A.value or N.TMP_LOW-2 > A.value then '위험'  ");
                    sb.AppendLine("        else case when N.TMP_HIGH < A.value or  N.TMP_LOW > A.value then '주의' ");
                    sb.AppendLine("                 else '정상' end  ");
                    sb.AppendLine("        end ");
                    sb.AppendLine("   else case when N.HUMI_HIGH+2 < A.value or N.HUMI_LOW-2 > A.value then '위험'  ");
                    sb.AppendLine("        else case when N.HUMI_HIGH < A.value or N.HUMI_LOW > A.value then '주의' ");
                    sb.AppendLine("                 else '정상' end  ");
                    sb.AppendLine("        end ");
                    sb.AppendLine("   end ) != '정상' ");
                }

                if (cmb_tmp_loc.SelectedIndex != 0)
                {
                    sb.AppendLine(" and N.S_LOC_CD = '"+cmb_tmp_loc.SelectedValue.ToString()+"'   ");
                }

                if (cmb_type_gbn.SelectedIndex != 0)
                {
                    sb.AppendLine(" and A.S_TYPE = '" + cmb_type_gbn.SelectedValue.ToString() + "'   ");
                }

                dt = wDm.fn_select_Sensor_list(sb.ToString());
                dataSensorLogGrid.Rows.Clear();

                if (dt != null && dt.Rows.Count > 0)
                {
                    dataSensorLogGrid.RowCount = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dataSensorLogGrid.Rows[i].Cells["설치위치"].Value = dt.Rows[i]["설치위치"].ToString();
                        dataSensorLogGrid.Rows[i].Cells["센서명칭"].Value = dt.Rows[i]["센서명칭"].ToString();
                        dataSensorLogGrid.Rows[i].Cells["입력시간"].Value = dt.Rows[i]["입력시간"].ToString().Substring(0, 10) + " " + dt.Rows[i]["입력시간"].ToString().Substring(10);
                        dataSensorLogGrid.Rows[i].Cells["데이터구분"].Value = dt.Rows[i]["데이터구분"].ToString();
                        dataSensorLogGrid.Rows[i].Cells["하한"].Value = decimal.Parse(dt.Rows[i]["하한"].ToString()).ToString("#,0.######");
                        dataSensorLogGrid.Rows[i].Cells["상한"].Value = decimal.Parse(dt.Rows[i]["상한"].ToString()).ToString("#,0.######");
                        dataSensorLogGrid.Rows[i].Cells["입력값"].Value = decimal.Parse(dt.Rows[i]["입력값"].ToString()).ToString("#,0.######");
                        dataSensorLogGrid.Rows[i].Cells["상태"].Value = dt.Rows[i]["상태"].ToString();

                        if (!dataSensorLogGrid.Rows[i].Cells["상태"].Value.ToString().Equals("정상"))
                        {
                            DataGridViewCellStyle st = new DataGridViewCellStyle();
                            if (dataSensorLogGrid.Rows[i].Cells["상태"].Value.ToString().Equals("주의"))
                            {
                                st.BackColor = Color.Orange;
                                st.SelectionBackColor = Color.Orange;
                                dataSensorLogGrid.Rows[i].Cells["상태"].Style = st;
                            }
                            else
                            {
                                st.BackColor = Color.FromArgb(253, 91, 83);
                                st.SelectionBackColor = Color.FromArgb(253, 91, 83);
                                st.ForeColor = Color.WhiteSmoke;
                                st.SelectionForeColor = Color.WhiteSmoke;
                                dataSensorLogGrid.Rows[i].Cells["상태"].Style = st;
                            }
                        }
                        

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
