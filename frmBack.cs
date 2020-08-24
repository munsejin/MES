using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing.Text;  
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using MES.CLS;
using System.Diagnostics;

using System.Globalization;
using System.IO;
using MES.Animations.Effects;
using MES.Easing;
using System.Collections;


namespace MES
{
    public partial class frmBack : Form
    {
        private IfrmInterface parentFrm = null;
        string today = DateTime.Today.ToString("yyyy-MM-dd");
        Image img = null;
        int timerCount = 0;
        Point txt_alram_Lacation_Temp;
        Size txt_alram_Size_Temp;

        ArrayList alramArr = new ArrayList();

        public frmBack(IfrmInterface pFrm)
        {
            InitializeComponent();
            parentFrm = pFrm;
            txt_alram_Lacation_Temp = txt_alram.Location;
        }


   
        private void frmBack_Load(object sender, EventArgs e)
        {

            String year = DateTime.Now.ToString("yyyy-MM-dd").ToString().Split('-')[0];
            String month = DateTime.Now.ToString("yyyy-MM-dd").ToString().Split('-')[1];

            PrivateFontCollection privateFonts = new PrivateFontCollection();
            this.DoubleBuffered = true;
            pic_banner.BackgroundImageLayout = ImageLayout.Zoom;

            txt_alram_Size_Temp = txt_alram.Size;
            txt_alram_Lacation_Temp = txt_alram.Location;
            
            배너세팅();
            바로가기();
            마지막공지();
            북마크();
            자주사용한메뉴();
            프로그램알람();

            timer2.Interval = 5000;
            timer2.Enabled = true;

        }

        private void 프로그램알람()
        {
            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = null;
                dt = wDm.select_program_alram();

                alramArr.Clear();
                //cmb_alram.Items.Clear();
                Dictionary<string,string> itemTemp = new Dictionary<string,string>();

                if (dt != null && dt.Rows.Count > 0)
                {
                    if (int.Parse(dt.Rows[0]["NOT_BUY"].ToString()) > 0)
                    {
                        alramArr.Add("   [구매처리 필요] 구매처리되지 않은 입고내역이 존재합니다.");
                        itemTemp.Add("   [구매처리 필요] 구매처리되지 않은 입고내역이 존재합니다.", "P20_ORD.frm원자재입고등록");
                    }
                    if (int.Parse(dt.Rows[0]["JUMUN_WAR"].ToString()) > 0)
                    {
                        if (int.Parse(dt.Rows[0]["JUMUN_OVER"].ToString()) > 0)
                        {
                            alramArr.Add("   [납품일 초과 경고] 일부 수주의 납품요구일이 지났으나 납품되지 않았습니다!!! ");
                            itemTemp.Add("   [납품일 초과 경고] 일부 수주의 납품요구일이 지났으나 납품되지 않았습니다!!! ", "P40_ITM.frm제품출고등록");
                        }
                        else
                        {
                            alramArr.Add("   [납품] 일부 수주의 납품요구일이 다가오고있습니다.");
                            itemTemp.Add("   [납품] 일부 수주의 납품요구일이 다가오고있습니다.", "P10_PLN.frm주문서등록");
                        }
                    }
                    if (int.Parse(dt.Rows[0]["ORDER_WAR"].ToString()) > 0)
                    {
                        if (int.Parse(dt.Rows[0]["ORDER_OVER"].ToString()) > 0)
                        {
                            alramArr.Add("   [입고일 초과 경고] 일부 발주의 입고요청일이 지났으나 입고되지 않았습니다!!! ");
                            itemTemp.Add("   [입고일 초과 경고] 일부 발주의 입고요청일이 지났으나 입고되지 않았습니다!!! ", "P20_ORD.frm발주서등록");
                        }
                        else
                        {
                        }
                    }
                    cmb_alram.DisplayMember = "Key";
                    cmb_alram.ValueMember = "Value";
                    cmb_alram.DataSource = new BindingSource(itemTemp, null);
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        private void 북마크()
        {
            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = null;
                if (Common.p_strUserAdmin.Equals("5")) //권한통제자는 무조건 모든 메뉴 보여줌
                {
                    dt = wDm.selectBookMarkMenu_admin();

                }
                else
                {
                    dt = wDm.selectBookMarkMenu();
                }

                b_grid.Rows.Clear();
                if (dt != null && dt.Rows.Count > 0)
                {
                    b_grid.RowCount = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        b_grid.Rows[i].Cells["B_TOPMENU"].Value = dt.Rows[i]["TopName"].ToString();
                        b_grid.Rows[i].Cells["B_SUBMENU"].Value = dt.Rows[i]["SubName"].ToString();
                        b_grid.Rows[i].Cells["B_SUBMENU"].Tag = dt.Rows[i]["AsmName"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                msg.ShowDialog();
            }
        }

        private void 마지막공지()
        {
            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = wDm.fn_last_Notice();
                if (dt != null && dt.Rows.Count > 0)
                {
                    noti_title.Text = dt.Rows[0]["TITLE"].ToString();
                    noti_comment.Text = dt.Rows[0]["CONTENT"].ToString();
                    noti_time.Text = dt.Rows[0]["INTIME"].ToString();
                    noti_writer.Text = dt.Rows[0]["STAFF_NM"].ToString();
                }
            }
            catch (Exception ex)
            {
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                msg.ShowDialog();
            }

        }
      //  일정관리 
        private void FormatDates()
        {
           //// monthCalendar2.Dates.Clear();
           // try
           // {
           //     DataTable dt = 일정관리();
           //     DateItem[] d = new DateItem[dt.Rows.Count];
           //     d.Initialize();
           //     for (int i = 0; i < dt.Rows.Count; i++)
           //     {
           //         d[i] = new DateItem();

           //         d[i].Date = DateTime.Parse(dt.Rows[i]["date"].ToString());
           //         int argb = Int32.Parse(dt.Rows[i]["color"].ToString().Replace("#", ""), NumberStyles.HexNumber);
           //         d[i].TextColor = Color.FromArgb(argb);
           //         d[i].ImageListIndex = 3;
           //         d[i].Text = dt.Rows[i]["title"].ToString();
           //         d[i].BoldedDate = true;
                   
           //     }


           // //    monthCalendar2.AddDateInfo(d);
           // }
           // catch
           // {
           // }
        }
        /// <summary>
        /// 도입기업 홈페이지를 메인화면에 띄어줌 
        /// 도입기업 홈페이지 미설정, 오류 등 일시 공급기업 홈페이지 띄어줌 
        /// <Common.sp_site> 공급기업 홈페이지</Common.sp_site>  <Common.p_homepage> 도입기업 홈페이지 </Common.p_homepage> 
        /// </summary>
        private void 배너세팅()
        {
            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = new DataTable();
                dt = wDm.fn_Saup_List(Common.p_saupNo);

                if (dt != null && dt.Rows.Count > 0)
                {
                    if (int.Parse(dt.Rows[0]["BANNER_SIZE"].ToString()) > 0)
                    {
                        byte[] rs = (byte[])dt.Rows[0]["SAUP_BANNER"];
                        MemoryStream ms = new MemoryStream(rs);
                        img = Image.FromStream(ms);
                        pic_banner.BackgroundImage = img;
                    }
                }
                else
                {
                }
            }
            catch (Exception e)
            {

            }
        }
        private void frmBack_Resize(object sender, EventArgs e)
        {
            panCenter.Left = this.ClientSize.Width / 2 - panCenter.Width / 2;
            panCenter.Top = this.ClientSize.Height / 2 - panCenter.Height / 2;

            w_home1.Left = this.ClientSize.Width / 2 - panCenter.Width / 2;
            w_home1.Top = this.ClientSize.Height / 2 - panCenter.Height / 2;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            SendKeys.Send("{LEFT}");
            timer1.Enabled = false;
        }



        public DataTable Today_Delivery()
        {
            wnAdo wAdo = new wnAdo();

            StringBuilder sb = new StringBuilder();

            //=================== 작업지시서현황 ======================

            sb.AppendLine("SELECT A.DELIVERY_DATE,B.SPEC , B.ITEM_NM ");
            sb.AppendLine("FROM F_WORK_INST A ");
            sb.AppendLine("LEFT OUTER JOIN N_ITEM_CODE B ON A.ITEM_CD = B.ITEM_CD ");
            sb.AppendLine("WHERE A.DELIVERY_DATE = '" + today + "' ");


            Debug.WriteLine(sb);
            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            
            return wAdo.SqlCommandSelect(sCommand);

        }

        //private void 납기일bind()
        //{

        //    DataTable dt = null;
        //    dt = Today_Delivery();
        //    if (dt != null && dt.Rows.Count > 0)
        //    {
        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {
        //            dgv_today_item.Rows.Add();
        //           // dgv_today_item.Rows[i].Cells["DELIVERY_DATE"].Value = dt.Rows[i]["DELIVERY_DATE"].ToString();
        //            dgv_today_item.Rows[i].Cells["SPEC"].Value = dt.Rows[i]["SPEC"].ToString();
        //            dgv_today_item.Rows[i].Cells["ITEM_NM"].Value = dt.Rows[i]["ITEM_NM"].ToString();
        //        }
        //    }
        //}

        //public DataTable dates()
        //{
        //    wnAdo wAdo = new wnAdo();

        //    StringBuilder sb = new StringBuilder();

        //    //=================== 작업지시서현황 ======================

        //    sb.AppendLine("select * from f_dates ");
         


        //    Debug.WriteLine(sb);
        //    SqlCommand sCommand = new SqlCommand(sb.ToString());
        //    if (sCommand.CommandText.Equals(null))
        //    {
        //        wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
        //        return null;
        //    }

        //    return wAdo.SqlCommandSelect(sCommand);

        //}

        private void 공지bind()
        {

            DataTable dn = null;
            dn = Today_Notice();

            if (dn != null && dn.Rows.Count > 0)
            {
                dgv_notice_grid.RowCount = dn.Rows.Count;
                for (int i = 0; i < dn.Rows.Count; i++)
                {
                      dgv_notice_grid.Rows[i].Cells["TITLE"].Value = dn.Rows[i]["TITLE"].ToString();
                      dgv_notice_grid.Rows[i].Cells["day"].Value = dn.Rows[i]["intime2"].ToString();
                      dgv_notice_grid.Rows[i].Cells["날짜시간"].Value = dn.Rows[i]["intime"].ToString();
                }
            }
        }

        public DataTable Today_Notice()
        {
            wnAdo wAdo = new wnAdo();

            StringBuilder sb = new StringBuilder();                     

            sb.AppendLine("SELECT top 20 SEQ, TITLE, CONTENT, INSTAFF ,substring(intime,0,11) as intime2,intime ");
            sb.AppendLine("FROM N_NOTICE ");
            sb.AppendLine("    order by intime DESC ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }

            return wAdo.SqlCommandSelect(sCommand);
        }


    //    private void 불량율bind(){
    //        DataTable dt불량율 = 불량율();
    //     //   dgv불량율.DataSource = dt불량율;
    //        for (int i = 0; i < dt불량율.Rows.Count; i++)
    //        {
    //            dgv불량율.Rows.Add();
    //            dgv불량율.Rows[i].Cells["NOW제품명"].Value = dt불량율.Rows[i]["제품명"].ToString();
    //            dgv불량율.Rows[i].Cells["NOW규격"].Value = dt불량율.Rows[i]["규격"].ToString();
    //            dgv불량율.Rows[i].Cells["NOW수량"].Value = dt불량율.Rows[i]["수량"].ToString();

    //        }
            
    //        //panCenter.Dock = DockStyle.Fill;
    //        //w_home1.Dock = DockStyle.Fill;

         
    //}

        private DataTable 불량율()
        {
            wnAdo wAdo = new wnAdo();
            StringBuilder sb = new StringBuilder();

            




            //sb.AppendLine("SELECT X.POOR_NM as 불량 ");
            //sb.AppendLine(",convert(int,ISNULL(Z.불량갯수,'0'))AS 불량갯수, ");
            //sb.AppendLine("CASE WHEN ISNULL(CONVERT(DECIMAL(18,2),Z.전체수),'0') = 0 THEN  0  ");
            //sb.AppendLine("ELSE CONVERT(DECIMAL(18,2),(ISNULL(Z.불량갯수,'0')/ ISNULL(Z.전체수,'0'))) ");
            //sb.AppendLine("END 불량율 FROM N_POOR_CODE X ");
            //sb.AppendLine("       LEFT JOIN( ");
            //sb.AppendLine("        select SUM(A.POOR_AMT) AS 불량갯수 ,isnull(B.POOR_NM,'알수없음') as POOR_NM ,SUM(A.F_SUB_AMT) AS 전체수 from F_WORK_FLOW_DETAIL A  ");
            //sb.AppendLine("        FULL OUTER join N_POOR_CODE B  on A.POOR_CD=B.POOR_CD");
            //sb.AppendLine("        RIGHT join N_FLOW_CODE c  on A.FLOW_CD=c.FLOW_CD ");
            //sb.AppendLine("        where A.POOR_AMT>0 ");
            //sb.AppendLine("        GROUP BY B.POOR_NM ");
            //sb.AppendLine("        )Z ON Z.POOR_NM= X.POOR_NM ");
            sb.AppendLine("  select ITEM_NM AS 제품명 ,MaX(item.SPEC) as 규격,MIN(CONVERT(INT,F_SUB_AMT)) as 수량 from F_WORK_FLOW_DETAIL  as A  ");
            sb.AppendLine("inner join N_ITEM_CODE as item on item.ITEM_CD=A.ITEM_CD ");
            sb.AppendLine("  where COMPLETE_YN='Y' and A.F_SUB_DATE=convert(varchar(10), getdate(), 120) ");
    
            sb.AppendLine(" group by ITEM_NM ");

            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);

        }

        private void w_home1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void panCenter_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Click(object sender, EventArgs e)
        {
         
        }

       
        private void Bookmark1_Click(object sender, EventArgs e)
        {
            string sFrmName = ((Button)sender).Tag.ToString();
            string sMnuName = ((Button)sender).Text.ToString();
            parentFrm.sub_Form(sFrmName, sMnuName);
            Debug.WriteLine(sFrmName + "//" + sMnuName);
        }

        

       
       

        private void panel7_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://320.co.kr");      
         
        }

        private void dgv_notice_grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //string sFrmName = dgv_notice_grid.Tag.ToString().Split('/')[0];
            //string sMnuName = dgv_notice_grid.Tag.ToString().Split('/')[1];
            //parentFrm.sub_Form(sFrmName, sMnuName);
            //Debug.WriteLine(dgv_notice_grid.Rows[e.RowIndex].Cells[2].Value.ToString());
            try
            {
                if (e.RowIndex > -1)
                {
                    wnDm wDm = new wnDm();
                    DataTable dt = wDm.select_Notice(dgv_notice_grid.Rows[e.RowIndex].Cells[2].Value.ToString());
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        noti_title.Text = dt.Rows[0]["TITLE"].ToString();
                        noti_comment.Text = dt.Rows[0]["CONTENT"].ToString();
                        noti_time.Text = dt.Rows[0]["INTIME"].ToString();
                        noti_writer.Text = dt.Rows[0]["STAFF_NM"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                msg.ShowDialog();
            }
           
        }

        

        private void frmBack_Enter(object sender, EventArgs e)
        {
            배너세팅();
            
          //  불량율bind();
            공지bind();
          //  납기일bind();
            FormatDates();
           

        }

        private void 일정관리bind()
        {
            DataTable dt = 일정관리();
        }

        private DataTable 일정관리()
        {
          //select title,date from F_DATES


            wnAdo wAdo = new wnAdo();
            StringBuilder sb = new StringBuilder();






            sb.AppendLine("select title,date,isnull(color,'#000000') as color from F_DATES ");
          


            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);

        }

        //private void monthCalendar2_DayDoubleClick(object sender, DayClickEventArgs e)
        //{
            
        //    //Popup.frm일정관리 frm일정관리 = new Popup.frm일정관리(this, e.Date);
        //    //frm일정관리.StartPosition = FormStartPosition.CenterParent;
        //    //DialogResult result = frm일정관리.ShowDialog();

        //    //if (result == DialogResult.OK)                
        //    //{
        //    //    FormatDates();
               
        //    //}
            
        //}

        private void 바로가기()
        {
            Button[] btn_book = new Button[6];

            //pnl_bookmark.Controls.Clear();

            try
            {
                DataTable dt = bookmark();
                if (dt.Rows.Count > 0)
                {


                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        btn_book[i] = new Button();
                        btn_book[i].Size = new Size(189, 198);

                        // 3개 이상이면 2번째 줄로 내려감
                        if (i > 2)//9, 282
                        {
                            btn_book[i].Location = new Point(0 + (192 * (i - 3)), 200);

                        }
                        else
                        {
                            btn_book[i].Location = new Point(0 + (192 * i), 0);

                        }
                        btn_book[i].Show();

                        btn_book[i].BackColor = Color.LightSeaGreen;
                        btn_book[i].FlatStyle = FlatStyle.Flat;
                        btn_book[i].FlatAppearance.BorderSize = 0;
                        btn_book[i].Text = dt.Rows[i]["subName"].ToString();
                        btn_book[i].Tag = dt.Rows[i]["AsmName"].ToString();
                        btn_book[i].ForeColor = Color.White;
                        btn_book[i].Font = new Font("Noto Sans CJK KR Regular", 17, FontStyle.Bold);
                        if (dt.Rows[i]["subName"].ToString().Length > 7)
                        {
                            btn_book[i].Font = new Font("Noto Sans CJK KR Regular", 13, FontStyle.Bold);

                        }
                        btn_book[i].TextAlign = ContentAlignment.BottomCenter;
                        // topid 를 보고 이미지 설정 
                        switch (dt.Rows[i]["topID"].ToString())
                        {

                            case "10":
                                btn_book[i].Image = MES.Properties.Resources.plan;

                                break;
                            case "20":
                                btn_book[i].Image = MES.Properties.Resources.order;

                                break;
                            case "30":
                                btn_book[i].Image = MES.Properties.Resources.work;

                                break;
                            case "40":
                                btn_book[i].Image = MES.Properties.Resources.muchine;

                                break;
                            case "50":
                                btn_book[i].Image = MES.Properties.Resources.qualified;

                                break;
                            case "60":
                                btn_book[i].Image = MES.Properties.Resources.card;

                                break;
                            case "70":
                                btn_book[i].Image = MES.Properties.Resources.statistics;

                                break;
                            case "85":
                                btn_book[i].Image = MES.Properties.Resources.setting;

                                break;
                            case "90":
                                btn_book[i].Image = MES.Properties.Resources.setting;

                                break;
                            default:
                                break;
                        }
                        btn_book[i].TabIndex = i + 1;
                        btn_book[i].Click += new EventHandler(Bookmark1_Click);
                        //pnl_bookmark.Controls.Add(btn_book[i]);

                    }
                    btn_book[dt.Rows.Count] = new Button();
                    btn_book[dt.Rows.Count].Size = new Size(189, 198);

                    if (dt.Rows.Count > 2)//9, 282
                    {
                        btn_book[dt.Rows.Count].Location = new Point(0 + (192 * (dt.Rows.Count - 3)), 200);

                    }
                    else
                    {
                        btn_book[dt.Rows.Count].Location = new Point(0 + (192 * dt.Rows.Count), 0);

                    }

                }
                btn_book[dt.Rows.Count].BackColor = Color.LightSeaGreen;
                btn_book[dt.Rows.Count].FlatStyle = FlatStyle.Flat;
                btn_book[dt.Rows.Count].FlatAppearance.BorderSize = 0;
                btn_book[dt.Rows.Count].Text ="원격 A/S";
                btn_book[dt.Rows.Count].Tag = "원격";

                btn_book[dt.Rows.Count].Image = MES.Properties.Resources.remote;
                btn_book[dt.Rows.Count].ImageAlign = ContentAlignment.TopCenter;
                btn_book[dt.Rows.Count].ForeColor = Color.White;
                btn_book[dt.Rows.Count].Font = new Font("Noto Sans CJK KR Regular", 19, FontStyle.Bold);
                btn_book[dt.Rows.Count].TextAlign = ContentAlignment.BottomCenter;
                btn_book[dt.Rows.Count].TabIndex = dt.Rows.Count + 1;
                btn_book[dt.Rows.Count].Click += new EventHandler(panel7_Click);
                //pnl_bookmark.Controls.Add(btn_book[dt.Rows.Count]);

            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
               
            
        }


        private DataTable bookmark()
        {
            wnAdo wAdo = new wnAdo();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("  select A.TopID,A.SubID,B.AsmName,B.SubName from N_AUTH_SUB  as A  ");
            sb.AppendLine("inner join T_SubMenu as B  on A.TopID=B.TopID and A.SubID=B.SubID ");
            sb.AppendLine("where STAFF_CD='" + Common.p_strStaffNo + "'and A.bookmark='Y'");
            sb.AppendLine("  order by SortNo");

            Debug.WriteLine(sb);
            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);

        }

        private DataTable allMenu()
        {
            wnAdo wAdo = new wnAdo();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" select A.TopID, A.SubID,A.AsmName,A.SubName from T_SubMenu as A ");
            sb.AppendLine(" where A.VIEW_YN = 'Y' ");
            sb.AppendLine(" order by SortNo ");

            Debug.WriteLine(sb);
            SqlCommand sCommand = new SqlCommand(sb.ToString());
            if (sCommand.CommandText.Equals(null))
            {
                wnLog.writeLog(wnLog.LOG_ERROR, wnLog.LOGSTRING_NO_QUERY);
                return null;
            }
            return wAdo.SqlCommandSelect(sCommand);

        }

        private void frmBack_Activated(object sender, EventArgs e)
        {
            //Debug.WriteLine("생명주기 테스트다 엑티브다 ");
            바로가기();
            마지막공지();
            북마크();
            자주사용한메뉴();
            프로그램알람();
        }

        private void 자주사용한메뉴()
        {
            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = null;
                
                dt = wDm.select_menu_click_log_last20();

                l_grid.Rows.Clear();
                if (dt != null && dt.Rows.Count > 0)
                {
                    l_grid.RowCount = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        l_grid.Rows[i].Cells["No"].Value = (i + 1).ToString();
                        l_grid.Rows[i].Cells["L_TOPMENU"].Value = dt.Rows[i]["TopName"].ToString();
                        l_grid.Rows[i].Cells["L_SUBMENU"].Value = dt.Rows[i]["SubName"].ToString();
                        l_grid.Rows[i].Cells["L_SUBMENU"].Tag = dt.Rows[i]["AsmName"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                msg.ShowDialog();
            }
        }

        private void frmBack_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void btn바로가기_Click(object sender, EventArgs e)
        {
        }

        private void b_grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                frmMain pForm = (frmMain)this.MdiParent;
                pForm.sub_Form(b_grid.Rows[e.RowIndex].Cells["B_SUBMENU"].Tag.ToString(), b_grid.Rows[e.RowIndex].Cells["B_SUBMENU"].Value.ToString());
            }
        }

        private void l_grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                frmMain pForm = (frmMain)this.MdiParent;
                pForm.sub_Form(l_grid.Rows[e.RowIndex].Cells["L_SUBMENU"].Tag.ToString(), l_grid.Rows[e.RowIndex].Cells["L_SUBMENU"].Value.ToString());
            }
        }

        private void pic_banner_SizeChanged(object sender, EventArgs e)
        {
            pic_banner.BackgroundImage = img;
            pic_banner.BackgroundImageLayout = ImageLayout.Zoom;
        }
        //private void menuButton_Click(object sender, EventArgs e)
        //{
        //    string sFrmName = ((Button)sender).Tag.ToString();
        //    string sMnuName = ((Button)sender).Text.ToString();
        //    parentFrm.sub_Form(sFrmName, sMnuName);
        //}
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            Keys key = keyData & ~(Keys.Shift | Keys.Control);
            switch (key)
            {
                case Keys.F5:
                    // 단일키 사용시
                    바로가기();
                    마지막공지();
                    북마크();
                    자주사용한메뉴();
                    프로그램알람();
                    break;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(500);
           // button1.Text = "test";
            //if (conLabel3.Location.Y > 0)
            //{
            //    conLabel3.Animate(new YLocationEffect(), EasingFunctions.QuadEaseIn, 10, 2000, 0, false, 1);
            //}
            //else
            //{
            //    conLabel3.Animate(new YLocationEffect(), EasingFunctions.QuadEaseIn, 5, 2000, 0, false, 1);
            //}
            //conLabel3.Animate(new YLocationEffect(), EasingFunctions.QuadEaseIn, 10, 2000, 0, false, -1);
            //conLabel3.Location = new Point(conLabel3.Location.X, conLabel3.Location.Y + 10);
            Popup.pop오류리포트 msg = new Popup.pop오류리포트();
            msg.ShowDialog();
        }

        private void tim_alram_Tick(object sender, EventArgs e)
        {
            
            //System.Threading.Thread.Sleep(1000);
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            
            Animator.Animate(txt_alram, new ControlFadeEffect(txt_alram), EasingFunctions.Linear, 0, 1000, 0);
            //Animator.Animated -= Animator_Animated;
            Animator.Animated += Animator_Animated;
            Animator.Animate(txt_alram, new ControlFadeEffect(txt_alram), EasingFunctions.Linear, 0, 1000, 0, true);

            
        }

        void Animator_Animated(object sender, Animators.AnimationStatus e)
        {
            if (alramArr.Count > 0)
            {
                if (timerCount > alramArr.Count - 1)
                {
                    timerCount = 0;
                    if (alramArr[timerCount].ToString().Contains("필요")) txt_alram.ForeColor = Color.IndianRed;
                    else if (alramArr[timerCount].ToString().Contains("경고")) txt_alram.ForeColor = Color.IndianRed;
                    else txt_alram.ForeColor = Color.FromArgb(80, 80, 80);
                    txt_alram.Text = alramArr[timerCount].ToString();
                    timerCount++;
                }
                else
                {
                    if (alramArr[timerCount].ToString().Contains("필요")) txt_alram.ForeColor = Color.IndianRed;
                    else if (alramArr[timerCount].ToString().Contains("경고")) txt_alram.ForeColor = Color.IndianRed;
                    else txt_alram.ForeColor = Color.FromArgb(80, 80, 80);
                    txt_alram.Text = alramArr[timerCount].ToString();
                    timerCount++;
                }
            }
            else
            {
                txt_alram.Text = "";
                timerCount = 0;
            }
            Animator.Animated -= Animator_Animated;

            //Animator.Animated -= Animator_Animated;
            //Animator.Animate(txt_alram, new ControlFadeEffect(txt_alram), EasingFunctions.Linear, 0, 1000, 0, true);
        }

        private void txt_alram_Click(object sender, EventArgs e)
        {
            cmb_alram_DropDown();
        }

        private void cmb_alram_DropDown()
        {
            if (cmb_alram.Items.Count > 0)
            {
                cmb_alram.Visible = true;
                cmb_alram.DroppedDown = true;
            }
        }

        private void pnl_alram_Click(object sender, EventArgs e)
        {
            cmb_alram_DropDown();
        }

        private void cmb_alram_DropDownClosed(object sender, EventArgs e)
        {
            cmb_alram.Visible = false;
        }

        private void cmb_alram_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmb_alram.SelectedValue != null && !cmb_alram.SelectedValue.ToString().Equals(""))
            {
                frmMain pForm = (frmMain)this.MdiParent;
                string path = cmb_alram.SelectedValue.ToString();
                DataTable dtTemp = allMenu();
                if (dtTemp != null && dtTemp.Rows.Count > 0)
                {
                    for (int i = 0; i < dtTemp.Rows.Count; i++)
                    {
                        if (dtTemp.Rows[i]["AsmName"].ToString().Equals(path))
                        {
                            pForm.sub_Form(path, dtTemp.Rows[i]["SubName"].ToString());
                            cmb_alram.SelectedIndex = 0;
                            break;
                        }
                    }
                }
                else
                {
                    return;
                }
            }
        }

    }
}
