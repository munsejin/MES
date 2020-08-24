using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MES.CLS;
using MES.Controls;
using System.Diagnostics;
using System.Windows.Forms.DataVisualization.Charting;

namespace MES.P30_SCH
{
    public partial class frm공정진행현황 : Form
    {

        private wnGConstant wConst = new wnGConstant();
        private Rectangle _Retangle;
        private wnDm wDm = new wnDm();
        bool completeFlag = false;
        public int TimerCount;
        public int TimerFirstValue = 61;

        private DateTimePicker[] dtp = new DateTimePicker[12];
        private conDataGridView[] dgv = new conDataGridView[12];
        private Panel[] pnl = new Panel[12];
        private Panel[] chk_pnl = new Panel[12];
        private Button[] btn = new Button[12];
        private Label[] lbl_flow_cd = new Label[12];
        private Label[] lbl_flow_nm = new Label[12];
        private Label[] lbl_flow_seq_array = new Label[12];
        private Label[] lbl_flow_title = new Label[12];
        private string[] lbl_flow_title_temp = new string[12];
        private TextBox[] txt_flow_comment = new TextBox[12];
        private string rowIndexTemp = "";

        private string LotTemp = "";


        private Chart[] 차트 = new Chart[12];


        private int MouseClickIdx = -1;
        private int MouseClickRow = -1;
        private int MouseClickCol = -1;

        private int locationNow = -1;

        private Point pointTemp = Point.Empty;
        wnDm wnDm = new wnDm();
        public int MaxSeq = 0;
        private Label[] lbl_flow_pr_type = new Label[12];
        private Label[] lbl_flow_seq = new Label[12]; //공정코드 순서 값
        private Label[] lbl_item_iden = new Label[12]; //제품식별표
        public String complete_YN = "";
        public static bool p_IsAuth = true;    // 열람권한
        public static bool p_Isrgstr = true;    //등록/수정 권한

        public static bool p_Isdel = true;    // 삭제 권한

        int flow_cnt = 0;//제품 BOM에 저장된 공정 갯수 
        private int max_flow_cnt = 12;

        public frm공정진행현황()
        {
            InitializeComponent();
        }

        private void main_panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm공정진행현황_Load(object sender, EventArgs e)
        {
            lbl_title.Tag = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[0] + "$" + wnDm.fn_TitleName(this.Name.ToString()).Split('$')[1]; lbl_title.Text = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[2];

            flow_p.AutoScroll = true;

            getsetting();

            LoadDataGird();

            InitializeTimer();
        }

        private void InitializeTimer()
        {
            // 타이머당 이벤트 호출 시간 부여 1초 = 1000 
            TimerCount = TimerFirstValue;
            Timer2.Interval = 1000; //카운트다운을 출력하기 위한 타이머 = 1초
            Timer2.Enabled = true;

            LoadRefresh();
        }

        private void LoadRefresh()
        {
            TimerCount = TimerFirstValue;
            LoadDataGird();
            if (!LotTemp.Equals(""))
            {
                for (int i = 0; i < processingGrid.Rows.Count; i++)
                {
                    if (processingGrid.Rows[i].Cells["LOTNO"].Value.ToString().Equals(LotTemp))
                    {
                        refreshFlow(i);
                        break;
                    }
                }
            }
        }  

        private void LoadDataGird()
        {
            try
            {

                DataTable dt = wDm.fn_select_processing_flow();
                if (dt != null && dt.Rows.Count > 0)
                {
                    processingGrid.Rows.Clear();
                    processingGrid.RowCount = dt.Rows.Count;

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        processingGrid.Rows[i].Cells["지시일자"].Value = dt.Rows[i]["INST_DATE"].ToString();
                        processingGrid.Rows[i].Cells["납품요구일"].Value = dt.Rows[i]["DELI_DATE"].ToString();
                        processingGrid.Rows[i].Cells["제품명"].Value = dt.Rows[i]["ITEM_NM"].ToString();
                        processingGrid.Rows[i].Cells["LOTNO"].Value = dt.Rows[i]["LOT_NO"].ToString();
                        processingGrid.Rows[i].Cells["공정수"].Value = dt.Rows[i]["FLOW_COUNT"].ToString();
                        processingGrid.Rows[i].Cells["지시수량"].Value = decimal.Parse(dt.Rows[i]["INST_AMT"].ToString()).ToString("#,0.######");
                        processingGrid.Rows[i].Cells["생산수량"].Value = decimal.Parse(dt.Rows[i]["INPUT_AMT"].ToString()).ToString("#,0.######");
                        processingGrid.Rows[i].Cells["생산완료율"].Value = decimal.Parse(dt.Rows[i]["INPUT_PER"].ToString()).ToString("#,0.######")+"%";
                        processingGrid.Rows[i].Cells["ITEM_CD"].Value = dt.Rows[i]["ITEM_CD"].ToString();

                        DataGridViewCellStyle Style = new DataGridViewCellStyle();

                        if (decimal.Parse(dt.Rows[i]["INPUT_PER"].ToString()) <= 40)
                        {
                            Style.ForeColor = Color.FromArgb(255, 0, 0);
                            Style.SelectionForeColor = Color.FromArgb(255, 0, 0);
                            Style.Font = new Font("Noto Sans CJK KR Regular", 10, FontStyle.Bold);
                        }
                        else if (decimal.Parse(dt.Rows[i]["INPUT_PER"].ToString()) <= 60)
                        {
                            Style.ForeColor = Color.FromArgb(112, 173, 71);
                            Style.SelectionForeColor = Color.FromArgb(112, 173, 71);
                            Style.Font = new Font("Noto Sans CJK KR Regular", 10, FontStyle.Bold);
                        }
                        else if (decimal.Parse(dt.Rows[i]["INPUT_PER"].ToString()) <= 80)
                        {
                            Style.ForeColor = Color.FromArgb(157, 195, 230);
                            Style.SelectionForeColor = Color.FromArgb(157, 195, 230);
                            Style.Font = new Font("Noto Sans CJK KR Regular", 10, FontStyle.Bold);
                        }
                        else
                        {
                            Style.ForeColor = Color.FromArgb(91,155,213);
                            Style.SelectionForeColor = Color.FromArgb(91, 155, 213);
                            Style.Font = new Font("Noto Sans CJK KR Regular", 10, FontStyle.Bold);
                        }
                        processingGrid.Rows[i].Cells["생산완료율"].Style = Style;



                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception 오류 발생");
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                msg.ShowDialog();
            }

        }

        private void getsetting()
        {
            lbl_flow_cd[0] = lbl_flow_cd_01;
            lbl_flow_cd[1] = lbl_flow_cd_02;
            lbl_flow_cd[2] = lbl_flow_cd_03;
            lbl_flow_cd[3] = lbl_flow_cd_04;
            lbl_flow_cd[4] = lbl_flow_cd_05;
            lbl_flow_cd[5] = lbl_flow_cd_06;
            lbl_flow_cd[6] = lbl_flow_cd_07;
            lbl_flow_cd[7] = lbl_flow_cd_08;
            lbl_flow_cd[8] = lbl_flow_cd_09;
            lbl_flow_cd[9] = lbl_flow_cd_10;
            lbl_flow_cd[10] = lbl_flow_cd_11;
            lbl_flow_cd[11] = lbl_flow_cd_12;

            lbl_flow_nm[0] = lbl_flow_nm_01;
            lbl_flow_nm[1] = lbl_flow_nm_02;
            lbl_flow_nm[2] = lbl_flow_nm_03;
            lbl_flow_nm[3] = lbl_flow_nm_04;
            lbl_flow_nm[4] = lbl_flow_nm_05;
            lbl_flow_nm[5] = lbl_flow_nm_06;
            lbl_flow_nm[6] = lbl_flow_nm_07;
            lbl_flow_nm[7] = lbl_flow_nm_07;
            lbl_flow_nm[8] = lbl_flow_nm_09;
            lbl_flow_nm[9] = lbl_flow_nm_10;
            lbl_flow_nm[10] = lbl_flow_nm_11;
            lbl_flow_nm[11] = lbl_flow_nm_12;

            //lbl_flow_seq_array[0] = lbl_Chk_Title01;
            //lbl_flow_seq_array[1] = lbl_Chk_Title02;
            //lbl_flow_seq_array[2] = lbl_Chk_Title03;
            //lbl_flow_seq_array[3] = lbl_Chk_Title04;
            //lbl_flow_seq_array[4] = lbl_Chk_Title05;
            //lbl_flow_seq_array[5] = lbl_Chk_Title06;
            //lbl_flow_seq_array[6] = lbl_Chk_Title07;
            //lbl_flow_seq_array[7] = lbl_Chk_Title08;
            //lbl_flow_seq_array[8] = lbl_Chk_Title09;
            //lbl_flow_seq_array[9] = lbl_Chk_Title10;
            //lbl_flow_seq_array[10] = lbl_Chk_Title11;
            //lbl_flow_seq_array[11] = lbl_Chk_Title12;

            pnl[0] = panel_comp_01;
            pnl[1] = panel_comp_02;
            pnl[2] = panel_comp_03;
            pnl[3] = panel_comp_04;
            pnl[4] = panel_comp_05;
            pnl[5] = panel_comp_06;
            pnl[6] = panel_comp_07;
            pnl[7] = panel_comp_08;
            pnl[8] = panel_comp_09;
            pnl[9] = panel_comp_10;
            pnl[10] = panel_comp_11;
            pnl[11] = panel_comp_12;

            dgv[0] = workComp01;
            dgv[1] = workComp02;
            dgv[2] = workComp03;
            dgv[3] = workComp04;
            dgv[4] = workComp05;
            dgv[5] = workComp06;
            dgv[6] = workComp07;
            dgv[7] = workComp08;
            dgv[8] = workComp09;
            dgv[9] = workComp10;
            dgv[10] = workComp11;
            dgv[11] = workComp12;

            //btn[0] = btn_comp_01;
            //btn[1] = btn_comp_02;
            //btn[2] = btn_comp_03;
            //btn[3] = btn_comp_04;
            //btn[4] = btn_comp_05;
            //btn[5] = btn_comp_06;
            //btn[6] = btn_comp_07;
            //btn[7] = btn_comp_08;
            //btn[8] = btn_comp_09;
            //btn[9] = btn_comp_10;
            //btn[10] = btn_comp_11;
            //btn[11] = btn_comp_12;

            chk_pnl[0] = flow_panel01;
            chk_pnl[1] = flow_panel02;
            chk_pnl[2] = flow_panel03;
            chk_pnl[3] = flow_panel04;
            chk_pnl[4] = flow_panel05;
            chk_pnl[5] = flow_panel06;
            chk_pnl[6] = flow_panel07;
            chk_pnl[7] = flow_panel08;
            chk_pnl[8] = flow_panel09;
            chk_pnl[9] = flow_panel10;
            chk_pnl[10] =flow_panel11;
            chk_pnl[11] = flow_panel12;

            lbl_flow_title[0] = lbl_flow_title01;
            lbl_flow_title[1] = lbl_flow_title02;
            lbl_flow_title[2] = lbl_flow_title03;
            lbl_flow_title[3] = lbl_flow_title04;
            lbl_flow_title[4] = lbl_flow_title05;
            lbl_flow_title[5] = lbl_flow_title06;
            lbl_flow_title[6] = lbl_flow_title07;
            lbl_flow_title[7] = lbl_flow_title08;
            lbl_flow_title[8] = lbl_flow_title09;
            lbl_flow_title[9] = lbl_flow_title10;
            lbl_flow_title[10] = lbl_flow_title11;
            lbl_flow_title[11] = lbl_flow_title12;

            txt_flow_comment[0] = lbl_flow_comment01;
            txt_flow_comment[1] = lbl_flow_comment02;
            txt_flow_comment[2] = lbl_flow_comment03;
            txt_flow_comment[3] = lbl_flow_comment04;
            txt_flow_comment[4] = lbl_flow_comment05;
            txt_flow_comment[5] = lbl_flow_comment06;
            txt_flow_comment[6] = lbl_flow_comment07;
            txt_flow_comment[7] = lbl_flow_comment08;
            txt_flow_comment[8] = lbl_flow_comment09;
            txt_flow_comment[9] = lbl_flow_comment10;
            txt_flow_comment[10] = lbl_flow_comment11;
            txt_flow_comment[11] = lbl_flow_comment12;

            차트[0] = chart1;
            차트[1] = chart2;
            차트[2] = chart3;
            차트[3] = chart4;
            차트[4] = chart5;
            차트[5] = chart6;
            차트[6] = chart7;
            차트[7] = chart8;
            차트[8] = chart9;
            차트[9] = chart10;
            차트[10] = chart11;
            차트[11] = chart12;

            lbl_flow_seq_array[0] = lbl_flow_seq01;
            lbl_flow_seq_array[1] = lbl_flow_seq02;
            lbl_flow_seq_array[2] = lbl_flow_seq03;
            lbl_flow_seq_array[3] = lbl_flow_seq04;
            lbl_flow_seq_array[4] = lbl_flow_seq05;
            lbl_flow_seq_array[5] = lbl_flow_seq06;
            lbl_flow_seq_array[6] = lbl_flow_seq07;
            lbl_flow_seq_array[7] = lbl_flow_seq08;
            lbl_flow_seq_array[8] = lbl_flow_seq09;
            lbl_flow_seq_array[9] = lbl_flow_seq10;
            lbl_flow_seq_array[10] = lbl_flow_seq11;
            lbl_flow_seq_array[11] = lbl_flow_seq12;

            for (int i = 0; i < 12; i++)
            {

                dtp[i] = new DateTimePicker();
                dtp[i].Value = DateTime.Now;
                this.dgv[i].Controls.Add(dtp[i]);
                dtp[i].Visible = false;
                dtp[i].Name = "FLOW_DATE" + (i + 1).ToString("00");
                dtp[i].Format = DateTimePickerFormat.Custom;
                dtp[i].TextChanged += new EventHandler(dtp_TextChange);

                dgv[i].CellClick += new DataGridViewCellEventHandler(workComp_CellClick);
                dgv[i].Columns[5].Visible = false;

                dgv[i].Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv[i].Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv[i].Columns[1].HeaderText = "SEQ";
                dgv[i].Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv[i].Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv[i].Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv[i].Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv[i].Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv[i].Columns[1].Width = 50;
                dgv[i].Columns[2].Width = 100;



                차트[i].Series[0].Name = "SEQ 1";
                차트[i].Series[0].BorderColor = Color.Black;
                차트[i].Series[0].BorderWidth = 1;
                차트[i].Series[0].Points.AddXY("통과", 0);
                차트[i].Series[0].Points.AddXY("불량", 0);
                차트[i].Series[0].Points.AddXY("미투입량", 0);
                //차트[i].Series[0].Points.AddXY("LOSS", 0);
                차트[i].Legends[0].Font = new Font("Noto Sans CJK KR Regular", 8, FontStyle.Bold);
                차트[i].Visible = false;
            }
        }



        private void scroll_right(object sender, EventArgs e)
        {
            int change = flow_p.HorizontalScroll.Value + 294;
            flow_p.AutoScrollPosition = new Point(change, 0);
        }

        private void scroll_left(object sender, EventArgs e)
        {
            int change = flow_p.HorizontalScroll.Value - 294;
            flow_p.AutoScrollPosition = new Point(change, 0);
        }

        private void dtp_TextChange(object sender, EventArgs e)
        {
            DateTimePicker dtp = (DateTimePicker)sender;
            int idx = int.Parse(dtp.Name.Substring(dtp.Name.Length - 2)) - 1; //그리드뷰 명칭의 끝 가져오기, workComp01 ~ workComp09 까지 지정되어 있음
            //MessageBox.Show(dgv[idx].Text.ToString());
            dgv[idx].CurrentCell.Value = dtp.Text.ToString();

            //grd.CurrentCell.Value = dtp[idx].Text.ToString();
        }

        String strCustCD = null; 
        private void btn_work_srch_Click(object sender, EventArgs e)
        {
        }

        private void flow_detail_logic()
        {
            // 클리어 
            for (int i = 0; i < 12; i++)
            {
                dgv[i].Visible = true;
                pnl[i].Visible = true;
                //btn[i].Visible = true;
                chk_pnl[i].Visible = true;
                dgv[i].Rows.Clear();
                btnDelete.Enabled= true;
                차트[i].Controls.Clear();

                차트[i].Visible = true;
                차트[i].ChartAreas.Clear();
                차트[i].Series.Clear();
                차트[i].Series.Add("SEQ 1");
                차트[i].ChartAreas.Add("SEQ 1");
                차트[i].Series[0].BorderWidth = 1;
                차트[i].Series[0].BorderColor = Color.Black;
                차트[i].Series[0].Points.AddXY("통과", 0);
                차트[i].Series[0].Points.AddXY("불량", 0);
                차트[i].Series[0].Points.AddXY("미투입량", 0);
                //차트[i].Series[0].Points.AddXY("LOSS", 0);

                차트[i].Series[0].Points[2].Color = Color.FromArgb(64, 64, 64);
                차트[i].Series[0].Points[0].Color = Color.FromArgb(59, 89, 152);
                차트[i].Series[0].Color = Color.FromArgb(59, 89, 152);
                차트[i].Series[0].Points[1].Color = Color.FromArgb(156,14,14);
                //차트[i].Series[0].Points[3].Color = Color.Yellow;

                lbl_flow_title[i].ForeColor = Color.FromArgb(64, 64, 64);
            }

            DataTable dt = new DataTable();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" where A.ITEM_CD = '" + txt_item_cd.Text.ToString() + "' ");
            sb.AppendLine(" and B.FLOW_INSERT_YN = 'Y' ");
            dt = wnDm.fn_Item_Flow_List(sb.ToString());
            flow_cnt = dt.Rows.Count;  //제품 BOM에 저장된 공정 갯수 
            if (dt.Rows.Count > 0)
            {
                for (int i = 11; i >= dt.Rows.Count; i--) // 11부터 등록 된 공정 수만큼 빼면서 그리드 버튼 판넬 숨김   ex 5개 - 11부터 ~5까지 숨김 
                {
                    chk_pnl[i].Visible = false;
                }

                string f_stepTemp = "-1";
                bool onlyFirstTime = false;
                int firstChoiceTemp = -1;
                for (int i = 0; i < dt.Rows.Count; i++)  // 첫번째 공정부터 공정수만큼 그리드에 공정명 공정 코드 부여해줌  ex 5개-  0부터 4그리드까지 
                {
                    if (f_stepTemp.Equals(dt.Rows[i]["FLOW_SEQ"].ToString()))
                    {
                        lbl_flow_cd[i].Text = "-";
                        lbl_flow_nm[i].Text = "제 " + f_stepTemp + "공정";
                        lbl_flow_title[i].Text = "제 " + f_stepTemp + "공정";
                        lbl_flow_title_temp[i] = "제 " + f_stepTemp + "공정";
                        txt_flow_comment[i].Text = "제 " + f_stepTemp + "공정";

                        if (!onlyFirstTime)
                        {
                            lbl_flow_cd[firstChoiceTemp].Text = "-";
                            lbl_flow_nm[firstChoiceTemp].Text = "제 " + f_stepTemp + "공정";
                            lbl_flow_title[firstChoiceTemp].Text = "제 " + f_stepTemp + "공정";
                            lbl_flow_title_temp[firstChoiceTemp] = "제 " + f_stepTemp + "공정";
                            txt_flow_comment[firstChoiceTemp].Text = "제 " + f_stepTemp + "공정";
                            FlowLayoutPanel buttonPanel = new FlowLayoutPanel();
                            buttonPanel.AutoScroll = true;
                            buttonPanel.FlowDirection = FlowDirection.TopDown;
                            buttonPanel.WrapContents = false;


                            StringBuilder sb2 = new StringBuilder();
                            sb2.AppendLine(" where A.ITEM_CD = '" + txt_item_cd.Text.ToString() + "' ");
                            sb2.AppendLine(" and B.FLOW_INSERT_YN = 'Y' ");
                            sb2.AppendLine(" and A.FLOW_SEQ = '" + dt.Rows[i]["FLOW_SEQ"].ToString() + "' ");
                            DataTable dt2 = wnDm.fn_Item_Flow_List(sb2.ToString());

                            if (dt2 == null || dt2.Rows.Count < 1)
                            {
                                MessageBox.Show("데이터 로드 중 오류발생");
                                return;
                            }

                            Label choiceLabel = new Label();
                            choiceLabel.Text = "선처리 공정 선택";
                            choiceLabel.Size = new System.Drawing.Size(245, 33);
                            choiceLabel.TextAlign = ContentAlignment.MiddleCenter;
                            choiceLabel.Font = new Font("맑은고딕", 15, FontStyle.Bold);
                            buttonPanel.Controls.Add(choiceLabel);

                            for (int j = 0; j < dt2.Rows.Count; j++)
                            {
                                Button btnTemp = new Button();
                                btnTemp.Size = new System.Drawing.Size(buttonPanel.Width - 10, 33);
                                btnTemp.Left = (buttonPanel.ClientSize.Width - btnTemp.Width) / 2;
                                btnTemp.Top = (buttonPanel.ClientSize.Height - btnTemp.Height) / 2;
                                btnTemp.Text = dt2.Rows[j]["FLOW_NM"].ToString();
                                btnTemp.Tag = dt2.Rows[j]["FLOW_CD"].ToString();
                                buttonPanel.Controls.Add(btnTemp);
                                btnTemp.Anchor = AnchorStyles.None;
                                btnTemp.Click += new EventHandler(choiceButton_onClick);
                            }

                            buttonPanel.Dock = DockStyle.Fill;
                            차트[firstChoiceTemp].Controls.Add(buttonPanel);
                            onlyFirstTime = true;

                            chk_pnl[i].BackColor = Color.FromArgb(64, 64, 64);
                            lbl_flow_title[i].ForeColor = Color.DarkGray;

                            Panel waitingPanel = new Panel();
                            Label waitingLabel = new Label();
                            waitingLabel.Text = "선택 대기";
                            waitingLabel.Size = new System.Drawing.Size(245, 33);
                            waitingLabel.TextAlign = ContentAlignment.MiddleCenter;
                            waitingLabel.Font = new Font("맑은고딕", 20, FontStyle.Bold);
                            waitingPanel.Dock = DockStyle.Fill;
                            waitingPanel.BackColor = Color.FromArgb(64, 64, 64);
                            waitingLabel.ForeColor = Color.DarkGray;
                            waitingPanel.Controls.Add(waitingLabel);
                            차트[i].Controls.Add(waitingPanel);

                        }
                        else
                        {
                            chk_pnl[i].BackColor = Color.FromArgb(64, 64, 64);
                            lbl_flow_title[i].ForeColor = Color.DarkGray;

                            Panel waitingPanel = new Panel();
                            Label waitingLabel = new Label();
                            waitingLabel.Text = "선택 대기";
                            waitingLabel.Size = new System.Drawing.Size(245, 33);
                            waitingLabel.TextAlign = ContentAlignment.MiddleCenter;
                            waitingLabel.Font = new Font("맑은고딕", 20, FontStyle.Bold);
                            waitingPanel.Dock = DockStyle.Fill;
                            waitingPanel.BackColor = Color.FromArgb(64, 64, 64);
                            waitingLabel.ForeColor = Color.DarkGray;
                            waitingPanel.Controls.Add(waitingLabel);
                            차트[i].Controls.Add(waitingPanel);
                        }

                    }
                    else
                    {
                        lbl_flow_cd[i].Text = dt.Rows[i]["FLOW_CD"].ToString();
                        lbl_flow_nm[i].Text = dt.Rows[i]["FLOW_NM"].ToString();
                        lbl_flow_title[i].Text = dt.Rows[i]["FLOW_NM"].ToString();
                        lbl_flow_title_temp[i] = dt.Rows[i]["FLOW_NM"].ToString();
                        txt_flow_comment[i].Text = dt.Rows[i]["FLOW_COMMENT"].ToString();
                        f_stepTemp = dt.Rows[i]["FLOW_SEQ"].ToString();
                        firstChoiceTemp = i;
                        onlyFirstTime = false;
                    }
                }
            }
            else
            {
                MessageBox.Show("제품 BOM에 공정이 등록 되어 있지 않습니다. 공정을 등록해주세요");
            }
        }

        private void choiceButton_onClick(object sender, EventArgs e)
        {
            Button btnTemp = (Button)sender;
            //MessageBox.Show(btnTemp.Parent.Parent.Name);

            for (int i = 0; i < 12; i++)
            {
                if (차트[i] == btnTemp.Parent.Parent)
                {
                    locationNow = i;
                    break;
                }
            }

            wnDm wDm = new wnDm();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" where A.ITEM_CD = '" + txt_item_cd.Text.ToString() + "' ");
            sb.AppendLine(" and B.FLOW_INSERT_YN = 'Y' ");
            sb.AppendLine(" and A.FLOW_CD = '" + btnTemp.Tag.ToString() + "' ");
            DataTable dt = wDm.fn_Item_Flow_List(sb.ToString());

            if (dt == null || dt.Rows.Count < 1)
            {
                MessageBox.Show("데이터 로드 중 오류발생");
                return;
            }
            else
            {
                lbl_flow_cd[locationNow].Text = dt.Rows[0]["FLOW_CD"].ToString();
                lbl_flow_nm[locationNow].Text = dt.Rows[0]["FLOW_NM"].ToString();
                lbl_flow_title[locationNow].Text = dt.Rows[0]["FLOW_NM"].ToString();
                lbl_flow_title_temp[locationNow] = dt.Rows[0]["FLOW_NM"].ToString();
                txt_flow_comment[locationNow].Text = dt.Rows[0]["FLOW_COMMENT"].ToString();

                btnTemp.Parent.Controls[btnTemp.TabIndex].Visible = false;

                chk_pnl[locationNow + 1].BackColor = Color.WhiteSmoke;
                lbl_flow_title[locationNow + 1].ForeColor = Color.FromArgb(64,64,64);

                int visibleCount = 0;
                int visibleIndex = -1;
                for (int i = 0; i < btnTemp.Parent.Controls.Count; i++)
                {
                    if (btnTemp.Parent.Controls[i].Visible)
                    {
                        visibleCount++;
                        visibleIndex = i;
                    }
                }
                차트[locationNow + 1].Controls[0].Visible = false;

                if (visibleCount < 3)
                {
                    StringBuilder sb2 = new StringBuilder();
                    sb2.AppendLine(" where A.ITEM_CD = '" + txt_item_cd.Text.ToString() + "' ");
                    sb2.AppendLine(" and B.FLOW_INSERT_YN = 'Y' ");
                    sb2.AppendLine(" and A.FLOW_CD = '" + btnTemp.Parent.Controls[visibleIndex].Tag.ToString() + "' ");
                    DataTable dt2 = wDm.fn_Item_Flow_List(sb2.ToString());

                    if (dt2 == null || dt2.Rows.Count < 1)
                    {
                        MessageBox.Show("데이터 로드 중 오류발생");
                        return;
                    }
                    else
                    {
                        lbl_flow_cd[locationNow+1].Text = dt2.Rows[0]["FLOW_CD"].ToString();
                        lbl_flow_nm[locationNow + 1].Text = dt2.Rows[0]["FLOW_NM"].ToString();
                        lbl_flow_title[locationNow + 1].Text = dt2.Rows[0]["FLOW_NM"].ToString();
                        lbl_flow_title_temp[locationNow + 1] = dt2.Rows[0]["FLOW_NM"].ToString();
                        txt_flow_comment[locationNow + 1].Text = dt2.Rows[0]["FLOW_COMMENT"].ToString();

                        btnTemp.Parent.Controls[btnTemp.TabIndex].Visible = false;
                        차트[locationNow].Controls.Clear();
                    }
                }
                else
                {
                    차트[locationNow + 1].Controls.Add(btnTemp.Parent);
                }
            }

            
            //MessageBox.Show(locationNow+"");


            
        }

        private void dgvSetting( string txt_lot_no, string txt_inst_amt)
        {
            DataTable flow_seq = new DataTable();
            StringBuilder sb = new StringBuilder();

            try  
            {
                //진행중인 (한번 저장한거 다시 불러오는)
                DataTable dt = new DataTable();
                sb.AppendLine(" AND A.LOT_NO = '" + txt_lot_no + "' ");
                dt = wnDm.fn_Work_Flow_Detail(sb.ToString());

                if (dt != null && dt.Rows.Count > -1)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        int idx = int.Parse(dt.Rows[i]["F_STEP"].ToString()) - 1;

                        DataGridView dgvTemp = dgv[idx];

                        dgvTemp.Rows.Add();

                        decimal pass = decimal.Parse(dt.Rows[i]["F_SUB_AMT"].ToString());
                        decimal poor = decimal.Parse(dt.Rows[i]["POOR_AMT"].ToString());
                        decimal loss = decimal.Parse(dt.Rows[i]["LOSS"].ToString());
                        decimal remain = decimal.Parse(dt.Rows[i]["INPUT_AMT"].ToString()) - decimal.Parse(dt.Rows[i]["F_SUB_AMT"].ToString());

                        dgvTemp.Rows[dgvTemp.Rows.Count - 1].Cells[0].Value = true;
                        dgvTemp.Rows[dgvTemp.Rows.Count - 1].Cells[1].Value = dt.Rows[i]["LOT_SUB"].ToString();
                        dgvTemp.Rows[dgvTemp.Rows.Count - 1].Cells[2].Value = dt.Rows[i]["F_SUB_DATE"].ToString();
                        dgvTemp.Rows[dgvTemp.Rows.Count - 1].Cells[3].Value = pass.ToString("#,0.######");
                        dgvTemp.Rows[dgvTemp.Rows.Count - 1].Cells[4].Value = poor.ToString("#,0.######");
                        dgvTemp.Rows[dgvTemp.Rows.Count - 1].Cells[5].Value = loss.ToString("#,0.######");
                        dgvTemp.Rows[dgvTemp.Rows.Count - 1].Cells[6].Value = remain.ToString("#,0.######");



                        dgvTemp.Rows[dgvTemp.Rows.Count - 1].DefaultCellStyle.BackColor = Color.FromArgb(59, 89, 152);
                        dgvTemp.Rows[dgvTemp.Rows.Count - 1].DefaultCellStyle.SelectionBackColor = Color.FromArgb(79, 109, 172);
                        dgvTemp.Rows[dgvTemp.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.WhiteSmoke;
                        dgvTemp.Rows[dgvTemp.Rows.Count - 1].DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;

                        if (차트[idx].Controls.Count == 1)
                        {
                            for (int k = 1; k < 차트[idx].Controls[0].Controls.Count; k++)
                            {
                                if (차트[idx].Controls[0].Controls[k].Tag.ToString().Equals(dt.Rows[i]["FLOW_CD"].ToString()) && 차트[idx].Controls[0].Controls[k].Visible == true)
                                {
                                    Button btnTemp = (Button)차트[idx].Controls[0].Controls[k];
                                    btnTemp.PerformClick();
                                    break;
                                }
                            }
                        }
                        else if(차트[idx].Controls.Count == 2)
                        {
                            for (int k = 1; k < 차트[idx].Controls[1].Controls.Count; k++)
                            {
                                if (차트[idx].Controls[1].Controls[k].Tag.ToString().Equals(dt.Rows[i]["FLOW_CD"].ToString()) && 차트[idx].Controls[1].Controls[k].Visible == true)
                                {
                                    Button btnTemp = (Button)차트[idx].Controls[1].Controls[k];
                                    btnTemp.PerformClick();
                                    break;
                                }
                            }
                        }

                        if (dgvTemp.Rows.Count - 1 == 0)
                        {
                            차트[idx].Series[0].Points[0].SetValueY(pass);
                            차트[idx].Series[0].Points[1].SetValueY(poor);
                            //차트[idx].Series[0].Points[3].SetValueY(loss);
                        }
                        else
                        {
                            차트[idx].Series[0].ChartType = SeriesChartType.StackedColumn;
                            Series sTemp = new Series("SEQ " + dgvTemp.Rows.Count);
                            sTemp.ChartType = SeriesChartType.StackedColumn;
                            차트[idx].Series.Add(sTemp);
                            sTemp.BorderWidth = 1;
                            sTemp.BorderColor = Color.Black;
                            Console.WriteLine(차트[idx].Series.Count + "");
                            차트[idx].Series[차트[idx].Series.Count - 1].Points.AddXY("통과", pass);
                            차트[idx].Series[차트[idx].Series.Count - 1].Points.AddXY("불량", poor);
                            차트[idx].Series[차트[idx].Series.Count - 1].Points.AddXY("미투입량", 0);
                            //차트[idx].Series[차트[idx].Series.Count - 1].Points.AddXY("LOSS", loss);

                            int r = 0;
                            int g = 0;
                            int b = 0;

                            Color ColorTemp = 차트[idx].Series[차트[idx].Series.Count-2].Points[0].Color;
                            r = ColorTemp.R + 30;
                            g = ColorTemp.G + 30;
                            b = ColorTemp.B + 30;
                            if (r > 255) r = 255;
                            if (g > 255) g = 255;
                            if (b > 255) b = 255;
                            Color ColorTemp2 = Color.FromArgb(r,g,b);
                            차트[idx].Series[차트[idx].Series.Count - 1].Points[0].Color = ColorTemp2;
                            차트[idx].Series[차트[idx].Series.Count - 1].Color = ColorTemp2;

                            ColorTemp = 차트[idx].Series[차트[idx].Series.Count - 2].Points[1].Color;
                            r = ColorTemp.R + 30;
                            g = ColorTemp.G + 30;
                            b = ColorTemp.B + 30;
                            if (r > 255) r = 255;
                            if (g > 255) g = 255;
                            if (b > 255) b = 255;
                            ColorTemp2 = Color.FromArgb(r,g,b);
                            차트[idx].Series[차트[idx].Series.Count - 1].Points[1].Color = ColorTemp2;

                            //ColorTemp = 차트[idx].Series[차트[idx].Series.Count - 2].Points[3].Color;
                            //r = ColorTemp.R + 30;
                            //g = ColorTemp.G + 30;
                            //b = ColorTemp.B + 30;
                            //if (r > 255) r = 255;
                            //if (g > 255) g = 255;
                            //if (b > 255) b = 255;
                            //ColorTemp2 = Color.FromArgb(r,g,b);
                            //차트[idx].Series[차트[idx].Series.Count - 1].Points[3].Color = ColorTemp2;
                        }
                    }

                    //뒤에서부터 넘어온것들 추가


                    for (int i = 11; i >= 0; i--)
                    {
                        if (dgv[i].Visible && i > 0)
                        {
                            decimal sumBeforePass = 0;
                            decimal sumCurrentPass = 0;
                            decimal sumRemainAmt = 0;
                            for (int j = 0; j < dgv[i - 1].Rows.Count; j++)
                            {
                                if (dgv[i - 1].Rows[j].Cells[0].Value == null) dgv[i - 1].Rows[j].Cells[0].Value = false;
                                if ((bool)dgv[i - 1].Rows[j].Cells[0].Value)
                                {
                                    sumBeforePass += decimal.Parse(dgv[i - 1].Rows[j].Cells[3].Value.ToString().Replace(",", ""));
                                }
                            }

                            for (int j = 0; j < dgv[i].Rows.Count; j++)
                            {
                                if (dgv[i].Rows[j].Cells[0].Value == null) dgv[i].Rows[j].Cells[0].Value = false;
                                if ((bool)dgv[i].Rows[j].Cells[0].Value)
                                {
                                    sumCurrentPass += decimal.Parse(dgv[i].Rows[j].Cells[3].Value.ToString().Replace(",", ""));
                                    sumCurrentPass += decimal.Parse(dgv[i].Rows[j].Cells[4].Value.ToString().Replace(",", ""));
                                    sumCurrentPass += decimal.Parse(dgv[i].Rows[j].Cells[5].Value.ToString().Replace(",", ""));
                                }
                            }

                            sumRemainAmt = sumBeforePass - sumCurrentPass;


                            if (sumRemainAmt > 0)
                            {
                                차트[i].Series[0].Points[2].SetValueY(sumRemainAmt);
                                차트[i].Series[0].Points[2].Color = Color.FromArgb(64, 64, 64);

                                dgv[i].Rows.Add();
                                dgv[i].Rows[dgv[i].Rows.Count-1].Cells[0].Value = false;
                                dgv[i].Rows[dgv[i].Rows.Count-1].Cells[1].Value = dgv[i].Rows.Count;
                                dgv[i].Rows[dgv[i].Rows.Count-1].Cells[2].Value = "";
                                dgv[i].Rows[dgv[i].Rows.Count-1].Cells[3].Value = sumRemainAmt.ToString("#,0.######");
                                dgv[i].Rows[dgv[i].Rows.Count-1].Cells[4].Value = "0";
                                dgv[i].Rows[dgv[i].Rows.Count-1].Cells[5].Value = "0";
                                dgv[i].Rows[dgv[i].Rows.Count-1].Cells[6].Value = "0";

                                dgv[i].Rows[dgv[i].Rows.Count - 1].DefaultCellStyle.BackColor = Color.FromArgb(64,64,64);
                                dgv[i].Rows[dgv[i].Rows.Count - 1].DefaultCellStyle.SelectionBackColor = Color.FromArgb(84, 84, 84);
                                dgv[i].Rows[dgv[i].Rows.Count - 1].DefaultCellStyle.ForeColor = Color.WhiteSmoke;
                                dgv[i].Rows[dgv[i].Rows.Count - 1].DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;

                            }
                        }
                        else if (dgv[i].Visible && i == 0)
                        {
                            decimal sumBeforePass = decimal.Parse(txt_inst_amt);
                            decimal sumCurrentPass = 0;
                            decimal sumRemainAmt = 0;
                            for (int j = 0; j < dgv[i].Rows.Count; j++)
                            {
                                if (dgv[i].Rows[j].Cells[0].Value == null) dgv[i].Rows[j].Cells[0].Value = false;
                                if ((bool)dgv[i].Rows[j].Cells[0].Value)
                                {
                                    sumCurrentPass += decimal.Parse(dgv[i].Rows[j].Cells[3].Value.ToString().Replace(",", ""));
                                    sumCurrentPass += decimal.Parse(dgv[i].Rows[j].Cells[4].Value.ToString().Replace(",", ""));
                                    sumCurrentPass += decimal.Parse(dgv[i].Rows[j].Cells[5].Value.ToString().Replace(",", ""));
                                }
                            }
                            sumRemainAmt = sumBeforePass - sumCurrentPass;
                            if (sumRemainAmt > 0)
                            {
                                차트[i].Series[0].Points[2].SetValueY(sumRemainAmt);
                                차트[i].Series[0].Points[2].Color = Color.FromArgb(64, 64, 64);

                                dgv[i].Rows.Add();
                                dgv[i].Rows[dgv[i].Rows.Count - 1].Cells[0].Value = false;
                                dgv[i].Rows[dgv[i].Rows.Count - 1].Cells[1].Value = dgv[i].Rows.Count;
                                dgv[i].Rows[dgv[i].Rows.Count - 1].Cells[2].Value = "";
                                dgv[i].Rows[dgv[i].Rows.Count - 1].Cells[3].Value = sumRemainAmt.ToString("#,0.######");
                                dgv[i].Rows[dgv[i].Rows.Count - 1].Cells[4].Value = "0";
                                dgv[i].Rows[dgv[i].Rows.Count - 1].Cells[5].Value = "0";
                                dgv[i].Rows[dgv[i].Rows.Count - 1].Cells[6].Value = "0";
                                dgv[i].Rows[dgv[i].Rows.Count - 1].DefaultCellStyle.BackColor = Color.FromArgb(64, 64, 64);
                                dgv[i].Rows[dgv[i].Rows.Count - 1].DefaultCellStyle.SelectionBackColor = Color.FromArgb(84, 84, 84);
                                dgv[i].Rows[dgv[i].Rows.Count - 1].DefaultCellStyle.ForeColor = Color.WhiteSmoke;
                                dgv[i].Rows[dgv[i].Rows.Count - 1].DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
                            }

                        }


                    }

                    




                }



            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                MessageBox.Show(ex.ToString());
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                msg.ShowDialog();
            }
            //첫번째 공정에 리스트 뿌려주자 


        }

        private void workComp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

   

        private void Set_Flow_flag_to_Not_Enabled(int idx)
        {
            lbl_flow_title[idx].ForeColor = Color.FromArgb(64, 64, 64);
        }
        

        

        private bool IsWorkDone()
        {
            for (int i = 0; i < 12; i++)
            {
                if (dgv[i].Visible)
                {
                    for (int j = 0; j < dgv[i].Rows.Count; j++)
                    {
                        if (dgv[i].Rows[j].Cells[0].Value == null || (bool)dgv[i].Rows[j].Cells[0].Value == false)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private void btn_Approval_MouseDown(object sender, MouseEventArgs e)
        {
            //Button btn = (Button)sender;
            //int idx = int.Parse(btn.Name.Substring(btn.Name.Length - 2)) - 1;

            //pointTemp = btn.Location;
            //Point point = btn_shadow[idx].Location;
            //point = point + new Size(-2,-2);
            //btn_shadow[idx].BackColor = Color.Silver;

            //btn_Approval[idx].Location = point;

        }


        private void btn_Approval_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int idx = int.Parse(btn.Name.Substring(btn.Name.Length - 2)) - 1;

            btn.Location = pointTemp;

        }

        private void btn_Approval_MouseEnter(object sender, EventArgs e)
        {

        }

        private void processingGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            LotTemp = processingGrid.Rows[e.RowIndex].Cells["LOTNO"].Value.ToString();

            LoadRefresh();

        }

        private void refreshFlow(int i)
        {
            txt_item_cd.Text = processingGrid.Rows[i].Cells["ITEM_CD"].Value.ToString();
            flow_detail_logic();
            dgvSetting(processingGrid.Rows[i].Cells["LOTNO"].Value.ToString(), processingGrid.Rows[i].Cells["지시수량"].Value.ToString());
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
                    LoadRefresh();
                    break;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
            return true;
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            lbl_TimeNow.Text = DateTime.Now.ToString("yyyy.MM.dd    HH:mm:ss");
            if (LotTemp.Equals(""))
            {
                label1.Text = "공정 선택 안됨";
            }
            else
            {
                label1.Text = "1분마다 자동 업데이트";
            }


            if (!label1.Text.ToString().Equals("1분마다 자동 업데이트"))
            {
                TimerCount = TimerFirstValue;
            }
            else if (lbl_timer_count.Text.Equals("1"))
            {
                lbl_timer_count.ForeColor = Color.Black;
                LoadRefresh();
            }
            else if (TimerCount <= 11)
            {
                lbl_timer_count.ForeColor = Color.Red;
            }
            lbl_timer_count.Text = (--TimerCount).ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LoadRefresh();

        }

    }
}
