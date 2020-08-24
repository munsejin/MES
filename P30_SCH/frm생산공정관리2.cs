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
    public partial class frm생산공정관리2 : Form
    {

        private wnGConstant wConst = new wnGConstant();
        private Rectangle _Retangle;
        private wnDm wDm = new wnDm();
        bool completeFlag = false;

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
        private DateTimePicker[] dtp_time = new DateTimePicker[12];
        private Button[] btn_Approval = new Button[12];
        private Button[] btn_shadow = new Button[12];
        private TextBox[] txt_flow_comment = new TextBox[12];
        private string rowIndexTemp = "";

        private Label[] lbl_pricessing_amt = new Label[12];
        private TextBox[] txt_pass_amt = new TextBox[12];
        private TextBox[] txt_poor_amt = new TextBox[12];
        private TextBox[] txt_loss_amt = new TextBox[12];
        private Label[] lbl_카드상태 = new Label[12];
        private Panel[] pn_카드 = new Panel[12];
        private DataGridView[] grd_검사기준 = new DataGridView[12];

        private RadioButton[] 합격 = new RadioButton[12];
        private RadioButton[] 불합격 = new RadioButton[12];
        private RadioButton[] 생략 = new RadioButton[12];
        private Button[] btn_검사저장 = new Button[12];

        private Label[] 일자 = new Label[12];
        private Label[] 진행 = new Label[12];
        private Label[] lbl_통과 = new Label[12];
        private Label[] lbl_불량 = new Label[12];
        private Label[] lbl_Loss = new Label[12];
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

        public frm생산공정관리2()
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

        private void frm생산공정관리2_Load(object sender, EventArgs e)
        {
            lbl_title.Tag = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[0] + "$" + wnDm.fn_TitleName(this.Name.ToString()).Split('$')[1]; lbl_title.Text = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[2];

            flow_p.AutoScroll = true;

            getsetting();








            //chart1.Series[0].ChartType = SeriesChartType.StackedColumn;
            //chart1.Series[0].Points.Clear();
            //chart1.Series[0].Points.AddXY("통과", 2000);
            //chart1.Series[0].Points.AddXY("LOSS", 1500);
            //chart1.Series[0].Points.AddXY("불량", 2000);
            //chart1.Series[0].Points[0].Color = Color.Red;

            //Series new_Series = new Series();
            //chart1.Series.Add(new_Series);
            //chart1.Series[1].Points.AddXY("통과", 1500);
            //chart1.Series[1].ChartType = SeriesChartType.StackedColumn;

            //chart1.Series.Add(new Series);
       
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

            btn_Approval[0] = btn_Approval01;
            btn_Approval[1] = btn_Approval02;
            btn_Approval[2] = btn_Approval03;
            btn_Approval[3] = btn_Approval04;
            btn_Approval[4] = btn_Approval05;
            btn_Approval[5] = btn_Approval06;
            btn_Approval[6] = btn_Approval07;
            btn_Approval[7] = btn_Approval08;
            btn_Approval[8] = btn_Approval09;
            btn_Approval[9] = btn_Approval10;
            btn_Approval[10] = btn_Approval11;
            btn_Approval[11] = btn_Approval12;

            btn_shadow[0] = btn_shadow01;
            btn_shadow[1] = btn_shadow02;
            btn_shadow[2] = btn_shadow03;
            btn_shadow[3] = btn_shadow04;
            btn_shadow[4] = btn_shadow05;
            btn_shadow[5] = btn_shadow06;
            btn_shadow[6] = btn_shadow07;
            btn_shadow[7] = btn_shadow08;
            btn_shadow[8] = btn_shadow09;
            btn_shadow[9] = btn_shadow10;
            btn_shadow[10] = btn_shadow11;
            btn_shadow[11] = btn_shadow12;

            lbl_pricessing_amt[0] = lbl_processing_amt01;
            lbl_pricessing_amt[1] = lbl_processing_amt02;
            lbl_pricessing_amt[2] = lbl_processing_amt03;
            lbl_pricessing_amt[3] = lbl_processing_amt04;
            lbl_pricessing_amt[4] = lbl_processing_amt05;
            lbl_pricessing_amt[5] = lbl_processing_amt06;
            lbl_pricessing_amt[6] = lbl_processing_amt07;
            lbl_pricessing_amt[7] = lbl_processing_amt08;
            lbl_pricessing_amt[8] = lbl_processing_amt09;
            lbl_pricessing_amt[9] = lbl_processing_amt10;
            lbl_pricessing_amt[10] = lbl_processing_amt11;
            lbl_pricessing_amt[11] = lbl_processing_amt12;

            txt_pass_amt[0] = txt_pass_amt01;
            txt_pass_amt[1] = txt_pass_amt02;
            txt_pass_amt[2] = txt_pass_amt03;
            txt_pass_amt[3] = txt_pass_amt04;
            txt_pass_amt[4] = txt_pass_amt05;
            txt_pass_amt[5] = txt_pass_amt06;
            txt_pass_amt[6] = txt_pass_amt07;
            txt_pass_amt[7] = txt_pass_amt08;
            txt_pass_amt[8] = txt_pass_amt09;
            txt_pass_amt[9] = txt_pass_amt10;
            txt_pass_amt[10] = txt_pass_amt11;
            txt_pass_amt[11] = txt_pass_amt12;

            txt_poor_amt[0] = txt_poor_amt01;
            txt_poor_amt[1] = txt_poor_amt02;
            txt_poor_amt[2] = txt_poor_amt03;
            txt_poor_amt[3] = txt_poor_amt04;
            txt_poor_amt[4] = txt_poor_amt05;
            txt_poor_amt[5] = txt_poor_amt06;
            txt_poor_amt[6] = txt_poor_amt07;
            txt_poor_amt[7] = txt_poor_amt08;
            txt_poor_amt[8] = txt_poor_amt09;
            txt_poor_amt[9] = txt_poor_amt10;
            txt_poor_amt[10] = txt_poor_amt11;
            txt_poor_amt[11] = txt_poor_amt12;

            txt_loss_amt[0] = txt_loss_amt01;
            txt_loss_amt[1] = txt_loss_amt02;
            txt_loss_amt[2] = txt_loss_amt03;
            txt_loss_amt[3] = txt_loss_amt04;
            txt_loss_amt[4] = txt_loss_amt05;
            txt_loss_amt[5] = txt_loss_amt06;
            txt_loss_amt[6] = txt_loss_amt07;
            txt_loss_amt[7] = txt_loss_amt08;
            txt_loss_amt[8] = txt_loss_amt09;
            txt_loss_amt[9] = txt_loss_amt10;
            txt_loss_amt[10] = txt_loss_amt11;
            txt_loss_amt[11] = txt_loss_amt12;

            dtp_time[0] = dtp_time01;
            dtp_time[1] = dtp_time02;
            dtp_time[2] = dtp_time03;
            dtp_time[3] = dtp_time04;
            dtp_time[4] = dtp_time05;
            dtp_time[5] = dtp_time06;
            dtp_time[6] = dtp_time07;
            dtp_time[7] = dtp_time08;
            dtp_time[8] = dtp_time09;
            dtp_time[9] = dtp_time10;
            dtp_time[10] = dtp_time11;
            dtp_time[11] = dtp_time12;

            pn_카드[0] = pn_카드01;
            pn_카드[1] = pn_카드02;
            pn_카드[2] = pn_카드03;
            pn_카드[3] = pn_카드04;
            pn_카드[4] = pn_카드05;
            pn_카드[5] = pn_카드06;
            pn_카드[6] = pn_카드07;
            pn_카드[7] = pn_카드08;
            pn_카드[8] = pn_카드09;
            pn_카드[9] = pn_카드10;
            pn_카드[10] = pn_카드11;
            pn_카드[11] = pn_카드12;

            lbl_카드상태[0] = lbl_카드상태01;
            lbl_카드상태[1] = lbl_카드상태02;
            lbl_카드상태[2] = lbl_카드상태03;
            lbl_카드상태[3] = lbl_카드상태04;
            lbl_카드상태[4] = lbl_카드상태05;
            lbl_카드상태[5] = lbl_카드상태06;
            lbl_카드상태[6] = lbl_카드상태07;
            lbl_카드상태[7] = lbl_카드상태08;
            lbl_카드상태[8] = lbl_카드상태09;
            lbl_카드상태[9] = lbl_카드상태10;
            lbl_카드상태[10] = lbl_카드상태11;
            lbl_카드상태[11] = lbl_카드상태12;

            grd_검사기준[0] = grd_검사기준01;
            grd_검사기준[1] = grd_검사기준02;
            grd_검사기준[2] = grd_검사기준03;
            grd_검사기준[3] = grd_검사기준04;
            grd_검사기준[4] = grd_검사기준05;
            grd_검사기준[5] = grd_검사기준06;
            grd_검사기준[6] = grd_검사기준07;
            grd_검사기준[7] = grd_검사기준08;
            grd_검사기준[8] = grd_검사기준09;
            grd_검사기준[9] = grd_검사기준10;
            grd_검사기준[10] = grd_검사기준11;
            grd_검사기준[11] = grd_검사기준12;

            btn_검사저장[0] = btn_검사저장01;
            btn_검사저장[1] = btn_검사저장02;
            btn_검사저장[2] = btn_검사저장03;
            btn_검사저장[3] = btn_검사저장04;
            btn_검사저장[4] = btn_검사저장05;
            btn_검사저장[5] = btn_검사저장06;
            btn_검사저장[6] = btn_검사저장07;
            btn_검사저장[7] = btn_검사저장08;
            btn_검사저장[8] = btn_검사저장09;
            btn_검사저장[9] = btn_검사저장10;
            btn_검사저장[10] = btn_검사저장11;
            btn_검사저장[11] = btn_검사저장12;

            일자[0] = 일자01;
            일자[1] = 일자02;
            일자[2] = 일자03;
            일자[3] = 일자04;
            일자[4] = 일자05;
            일자[5] = 일자06;
            일자[6] = 일자07;
            일자[7] = 일자08;
            일자[8] = 일자09;
            일자[9] = 일자10;
            일자[10] = 일자11;
            일자[11] = 일자12;

            진행[0] = 진행01;
            진행[1] = 진행02;
            진행[2] = 진행03;
            진행[3] = 진행04;
            진행[4] = 진행05;
            진행[5] = 진행06;
            진행[6] = 진행07;
            진행[7] = 진행08;
            진행[8] = 진행09;
            진행[9] = 진행10;
            진행[10] = 진행11;
            진행[11] = 진행12;

            lbl_통과[0] = lbl_통과01;
            lbl_통과[1] = lbl_통과02;
            lbl_통과[2] = lbl_통과03;
            lbl_통과[3] = lbl_통과04;
            lbl_통과[4] = lbl_통과05;
            lbl_통과[5] = lbl_통과06;
            lbl_통과[6] = lbl_통과07;
            lbl_통과[7] = lbl_통과08;
            lbl_통과[8] = lbl_통과09;
            lbl_통과[9] = lbl_통과10;
            lbl_통과[10] = lbl_통과11;
            lbl_통과[11] = lbl_통과12;

            lbl_불량[0] = lbl_불량01;
            lbl_불량[1] = lbl_불량02;
            lbl_불량[2] = lbl_불량03;
            lbl_불량[3] = lbl_불량04;
            lbl_불량[4] = lbl_불량05;
            lbl_불량[5] = lbl_불량06;
            lbl_불량[6] = lbl_불량07;
            lbl_불량[7] = lbl_불량08;
            lbl_불량[8] = lbl_불량09;
            lbl_불량[9] = lbl_불량10;
            lbl_불량[10] = lbl_불량11;
            lbl_불량[11] = lbl_불량12;

            lbl_Loss[0] = lbl_Loss01;
            lbl_Loss[1] = lbl_Loss02;
            lbl_Loss[2] = lbl_Loss03;
            lbl_Loss[3] = lbl_Loss04;
            lbl_Loss[4] = lbl_Loss05;
            lbl_Loss[5] = lbl_Loss06;
            lbl_Loss[6] = lbl_Loss07;
            lbl_Loss[7] = lbl_Loss08;
            lbl_Loss[8] = lbl_Loss09;
            lbl_Loss[9] = lbl_Loss10;
            lbl_Loss[10] = lbl_Loss11;
            lbl_Loss[11] = lbl_Loss12;

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
                btn_Approval[i].Click -= new EventHandler(btn_Approval_Click);
                btn_Approval[i].Click += new EventHandler(btn_Approval_Click);
                btn_Approval[i].MouseEnter -= new EventHandler(btn_Approval_MouseEnter);
                btn_Approval[i].MouseEnter += new EventHandler(btn_Approval_MouseEnter);
                btn_Approval[i].MouseLeave -= new EventHandler(btn_Approval_MouseLeave);
                btn_Approval[i].MouseLeave += new EventHandler(btn_Approval_MouseLeave);
                dgv[i].CellClick -= new DataGridViewCellEventHandler(workComp_CellClick);
                dgv[i].CellClick += new DataGridViewCellEventHandler(workComp_CellClick);
                dgv[i].Columns[5].Visible = false;
                dgv[i].Columns[1].Width = 50;
                dgv[i].Columns[2].Width = 100;
                dgv[i].Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv[i].Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv[i].Columns[1].HeaderText = "SEQ";
                dgv[i].Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv[i].Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv[i].Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv[i].Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv[i].Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


                grd_검사기준[i].Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grd_검사기준[i].MouseClick -= new MouseEventHandler(grd_검사기준_MouseClick);
                grd_검사기준[i].MouseClick += new MouseEventHandler(grd_검사기준_MouseClick);

                btn_검사저장[i].Click -= new EventHandler(btn_검사저장_Click);
                btn_검사저장[i].Click += new EventHandler(btn_검사저장_Click);

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

        private void btn_검사저장_Click(object sender, EventArgs e)
        {
            try
            {
                Button btnTemp = (Button)sender;
                int idx = int.Parse(btnTemp.Name.Substring(btnTemp.Name.Length - 2)) - 1;
                decimal poorSum = 0;

                if (lbl_flow_cd[idx].Text == null || lbl_flow_cd[idx].Text.ToString().Equals("") || lbl_flow_cd[idx].Text.ToString().Equals("-"))
                {
                    MessageBox.Show("선처리 공정을 먼저 선택하고 진행하여주십시오.");
                    return;
                }

                try
                {
                    for (int i = 0; i < grd_검사기준[idx].Rows.Count; i++)
                    {
                        if (grd_검사기준[idx].Rows[i].Cells[1].Value == null) grd_검사기준[idx].Rows[i].Cells[1].Value = "0";
                        if (grd_검사기준[idx].Rows[i].Cells[0].Tag == null) continue;
                        else poorSum += decimal.Parse(grd_검사기준[idx].Rows[i].Cells[1].Value.ToString().Replace(",", ""));
                    }
                }
                catch (Exception ex2)
                {
                    MessageBox.Show("수량 입력 값이 잘못되었습니다");
                    return;
                }



                int rsNum = wDm.insert_flow_poor(
                    txt_lot_no.Text
                    , (idx + 1).ToString()
                    , lbl_flow_cd[idx].Text
                    , lbl_flow_seq_array[idx].Text
                    , grd_검사기준[idx]
                    );

                if (rsNum == 0)
                {
                    lbl_카드상태[idx].Text = "(v)";
                    Print_Chk_Card(idx);
                    DialogResult msg = MessageBox.Show("불량 등록 값을 공정에 반영하시겠습니까?", "반영 여부", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (msg == DialogResult.Yes)
                    {
                        txt_poor_amt[idx].Text = poorSum.ToString("#,0.######");
                        txt_pass_amt[idx].Text = (decimal.Parse(lbl_pricessing_amt[idx].Text.ToString().Replace(",","")) - poorSum).ToString("#,0.######");
                    }
                }
                else if (rsNum == 1)
                {
                    MessageBox.Show("저장 중 오류 발생");
                    return;
                }
                else
                {
                    MessageBox.Show("Exception 에러");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception 오류");
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                msg.ShowDialog();
            }
        }

        private void grd_검사기준_MouseClick(object sender, MouseEventArgs e)
        {
            DataGridView dgvTemp = (DataGridView)sender;

            int currentMouseOverRow = dgvTemp.HitTest(e.X, e.Y).RowIndex;
            int currentMouseOverColumn = dgvTemp.HitTest(e.X, e.Y).ColumnIndex;

            

            if (currentMouseOverRow > -1 && currentMouseOverColumn == 0)
            {
                DataTable dt = null;
                int idx = int.Parse(dgvTemp.Name.Substring(dgvTemp.Name.Length - 2)) - 1;
                MouseClickIdx = idx;
                MouseClickRow = currentMouseOverRow;
                MouseClickCol = currentMouseOverColumn;
                if (e.Button == MouseButtons.Right)
                {
                    EventHandler eh = new EventHandler(MenuClick);
                    ContextMenu m = new ContextMenu();

                    dt = wDm.fn_Poor_List(" where 1=1 and A.POOR_GUBUN = '2' ");

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            bool isOntheGrid = false;
                            for (int j = 0; j < grd_검사기준[idx].Rows.Count; j++)
                            {
                                if(grd_검사기준[idx].Rows[j].Tag == null) continue;
                                else if(grd_검사기준[idx].Rows[j].Tag.ToString().Equals(dt.Rows[i]["POOR_CD"].ToString()))
                                {
                                    isOntheGrid = true;
                                }
                            }
                            if (!isOntheGrid)
                            {
                                m.MenuItems.Add(new MenuItem(dt.Rows[i]["POOR_CD"].ToString() + ", " + dt.Rows[i]["POOR_NM"].ToString(), eh));
                            }
                        }
                        m.MenuItems.Add(new MenuItem("직접 입력", eh));
                        m.MenuItems.Add(new MenuItem("행 삭제", eh));
                        dgvTemp.CurrentCell = dgvTemp.Rows[currentMouseOverRow].Cells[currentMouseOverColumn];
                        m.Show(dgvTemp, new Point(e.X, e.Y));
                    }
                }
                else if (dgvTemp.Rows[currentMouseOverRow].Cells[0].Tag == null && e.Button == MouseButtons.Left)
                {
                    EventHandler eh = new EventHandler(MenuClick);
                    ContextMenu m = new ContextMenu();
                    dt = wDm.fn_Poor_List(" where 1=1 and A.POOR_GUBUN = '2' ");

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            bool isOntheGrid = false;
                            for (int j = 0; j < grd_검사기준[idx].Rows.Count; j++)
                            {
                                if (grd_검사기준[idx].Rows[j].Tag == null) continue;
                                else if (grd_검사기준[idx].Rows[j].Tag.ToString().Equals(dt.Rows[i]["POOR_CD"].ToString()))
                                {
                                    isOntheGrid = true;
                                }
                            }
                            if (!isOntheGrid)
                            {
                                m.MenuItems.Add(new MenuItem(dt.Rows[i]["POOR_CD"].ToString() + ", " + dt.Rows[i]["POOR_NM"].ToString(), eh));
                            }
                        }
                        m.MenuItems.Add(new MenuItem("직접 입력", eh));
                        m.MenuItems.Add(new MenuItem("행 삭제", eh));
                        dgvTemp.CurrentCell = dgvTemp.Rows[currentMouseOverRow].Cells[currentMouseOverColumn];
                        m.Show(dgvTemp, new Point(e.X, e.Y));
                    }
                }
            }
        }

        void MenuClick(object obj, EventArgs ea)
        {
            MenuItem mI = (MenuItem)obj;
            String str = mI.Text;

            switch (str)
            {
                case "직접 입력" :
                    grd_검사기준[MouseClickIdx].Rows[MouseClickRow].Cells[0].ReadOnly = false;
                    grd_검사기준[MouseClickIdx].Rows[MouseClickRow].DefaultCellStyle.ForeColor = Color.Black;
                    grd_검사기준[MouseClickIdx].Rows[MouseClickRow].DefaultCellStyle.SelectionForeColor = Color.Black;
                    grd_검사기준[MouseClickIdx].Rows[MouseClickRow].Cells[0].Tag = "self";
                    grd_검사기준[MouseClickIdx].Rows[MouseClickRow].Cells[0].Value = "";

                    break;
                case "행 삭제":
                    if (grd_검사기준[MouseClickIdx].Rows.Count > 1)
                    {
                        grd_검사기준[MouseClickIdx].Rows.RemoveAt(MouseClickRow);
                    }
                    else
                    {
                        grd_검사기준[MouseClickIdx].Rows[MouseClickRow].Cells[0].ReadOnly = true;
                        grd_검사기준[MouseClickIdx].Rows[MouseClickRow].DefaultCellStyle.ForeColor = Color.DarkGray;
                        grd_검사기준[MouseClickIdx].Rows[MouseClickRow].DefaultCellStyle.SelectionForeColor = Color.DarkGray;
                        grd_검사기준[MouseClickIdx].Rows[MouseClickRow].Cells[0].Tag = null;
                        grd_검사기준[MouseClickIdx].Rows[MouseClickRow].Cells[0].Value = "(불량코드 등록)";
                    }
                    break;
                default :
                    for (int i = 0; i < grd_검사기준[MouseClickIdx].Rows.Count; i++)
                    {
                        if (grd_검사기준[MouseClickIdx].Rows[i].Cells[0].Tag == null) continue;
                        else if (grd_검사기준[MouseClickIdx].Rows[i].Cells[0].Tag.ToString().Equals(str.Split(',')[0]))
                        {
                            MessageBox.Show("해당 항목이 이미 리스트에 존재합니다.");
                            return;
                        }
                    }
                    grd_검사기준[MouseClickIdx].Rows[MouseClickRow].Cells[0].ReadOnly = true;
                    grd_검사기준[MouseClickIdx].Rows[MouseClickRow].DefaultCellStyle.ForeColor = Color.Black;
                    grd_검사기준[MouseClickIdx].Rows[MouseClickRow].DefaultCellStyle.SelectionForeColor = Color.Black;
                    grd_검사기준[MouseClickIdx].Rows[MouseClickRow].Cells[0].Tag = str.Split(',')[0];
                    grd_검사기준[MouseClickIdx].Rows[MouseClickRow].Cells[0].Value = str.Split(',')[1].Substring(1);
                    break;
            }

            for (int i = 0; i < grd_검사기준[MouseClickIdx].Rows.Count; i++)
            {
                if (grd_검사기준[MouseClickIdx].Rows[i].Cells[0].Tag == null)
                {
                    break;
                }
                else if (i == grd_검사기준[MouseClickIdx].Rows.Count - 1)
                {
                    grd_검사기준[MouseClickIdx].Rows.Add();
                    grd_검사기준[MouseClickIdx].Rows[grd_검사기준[MouseClickIdx].Rows.Count - 1].Cells[0].ReadOnly = true;
                    grd_검사기준[MouseClickIdx].Rows[grd_검사기준[MouseClickIdx].Rows.Count - 1].DefaultCellStyle.ForeColor = Color.DarkGray;
                    grd_검사기준[MouseClickIdx].Rows[grd_검사기준[MouseClickIdx].Rows.Count - 1].DefaultCellStyle.SelectionForeColor = Color.DarkGray;
                    grd_검사기준[MouseClickIdx].Rows[grd_검사기준[MouseClickIdx].Rows.Count - 1].Cells[0].Value = "(불량코드 등록)";
                    break;
                }
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
            Popup.pop작업지시검색 frm = new Popup.pop작업지시검색();

            frm.ShowDialog();

            if (frm.sCode != "")
            {
                txt_lot_no.Text = frm.dgv.Rows[0].Cells["LOT_NO"].Value.ToString();
                txt_item_nm.Text = frm.dgv.Rows[0].Cells["ITEM_NM"].Value.ToString();
                txt_item_cd.Text = frm.dgv.Rows[0].Cells["ITEM_CD"].Value.ToString();
                txt_spec.Text = frm.dgv.Rows[0].Cells["SPEC"].Value.ToString();
                txt_work_date.Text = frm.dgv.Rows[0].Cells["W_INST_DATE"].Value.ToString();
                if (frm.dgv.Rows[0].Cells["거래처코드"].Value == null) frm.dgv.Rows[0].Cells["거래처코드"].Value = "";
                strCustCD = frm.dgv.Rows[0].Cells["거래처코드"].Value.ToString();
                lbl미완료.Text = frm.dgv.Rows[0].Cells["complete_YN"].Value.ToString();
                txt_inst_amt.Text = (decimal.Parse(frm.dgv.Rows[0].Cells["INST_AMT"].Value.ToString())).ToString("#,0.######");
                txt_char_amt.Text = ("1");
                txt_pack_amt.Text = ("1");

                flow_detail_logic();
            }
            else
            {
                //txt_lot_no.Text = "";   
            }

            frm.Dispose();
            frm = null;
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
                chk_pnl[i].BackColor = Color.WhiteSmoke;
                dgv[i].Rows.Clear();
                lbl_pricessing_amt[i].Enabled = false;
                txt_pass_amt[i].Enabled = false;
                txt_poor_amt[i].Enabled = false;
                txt_loss_amt[i].Enabled = false;
                btn_Approval[i].Enabled = false;
                btn_검사저장[i].Enabled = false;
                btnDelete.Enabled= true;
                pn_카드[i].Enabled = false;
                dtp_time[i].Enabled = false;
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

                lbl_카드상태[i].Text = "( )";
                btn_Approval[i].BackColor = Color.FromArgb(64, 64, 64);
                lbl_flow_title[i].ForeColor = Color.FromArgb(64, 64, 64);
                pn_카드[i].BackColor = Color.FromArgb(64, 64, 64);
                btn_검사저장[i].BackColor = Color.FromArgb(64, 64, 64);
                진행[i].BackColor = Color.FromArgb(64, 64, 64);
                lbl_통과[i].BackColor = Color.FromArgb(64, 64, 64);
                lbl_불량[i].BackColor = Color.FromArgb(64, 64, 64);
                lbl_Loss[i].BackColor = Color.FromArgb(64, 64, 64);
                일자[i].BackColor = Color.FromArgb(64, 64, 64);
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
                        lbl_pricessing_amt[i].Enabled = false;
                        txt_pass_amt[i].Enabled = false;
                        txt_poor_amt[i].Enabled = false;
                        txt_loss_amt[i].Enabled = false;
                        btn_Approval[i].Enabled = false;

                        lbl_pricessing_amt[i].Text = "-";
                        txt_pass_amt[i].Text = "0";
                        txt_poor_amt[i].Text = "0";
                        txt_loss_amt[i].Text = "0";

                        if (!onlyFirstTime)
                        {
                            lbl_flow_cd[firstChoiceTemp].Text = "-";
                            lbl_flow_nm[firstChoiceTemp].Text = "제 " + f_stepTemp + "공정";
                            lbl_flow_title[firstChoiceTemp].Text = "제 " + f_stepTemp + "공정";
                            lbl_flow_title_temp[firstChoiceTemp] = "제 " + f_stepTemp + "공정";
                            txt_flow_comment[firstChoiceTemp].Text = "제 " + f_stepTemp + "공정";
                            lbl_pricessing_amt[firstChoiceTemp].Enabled = false;
                            txt_pass_amt[firstChoiceTemp].Enabled = false;
                            txt_poor_amt[firstChoiceTemp].Enabled = false;
                            txt_loss_amt[firstChoiceTemp].Enabled = false;
                            btn_Approval[firstChoiceTemp].Enabled = false;

                            lbl_pricessing_amt[firstChoiceTemp].Text = "-";
                            txt_pass_amt[firstChoiceTemp].Text = "0";
                            txt_poor_amt[firstChoiceTemp].Text = "0";
                            txt_loss_amt[firstChoiceTemp].Text = "0";
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
                        lbl_pricessing_amt[i].Enabled = false;
                        txt_pass_amt[i].Enabled = false;
                        txt_poor_amt[i].Enabled = false;
                        txt_loss_amt[i].Enabled = false;
                        btn_Approval[i].Enabled = false;

                        lbl_pricessing_amt[i].Text = "-";
                        txt_pass_amt[i].Text = "0";
                        txt_poor_amt[i].Text = "0";
                        txt_loss_amt[i].Text = "0";
                        f_stepTemp = dt.Rows[i]["FLOW_SEQ"].ToString();
                        firstChoiceTemp = i;
                        onlyFirstTime = false;
                    }
                }

                if (lbl미완료.Text.ToString() == "미완료")  //처음 할 때 
                {
                    dgv[0].Rows.Add();
                    //  dgv[0].Rows[0].Cells[1].Value = "1";
                    dgv[0].Rows[0].Cells[0].Value = false;
                    dgv[0].Rows[0].Cells[1].Value = "1";
                    dgv[0].Rows[0].Cells[3].Value = txt_inst_amt.Text;
                    dgv[0].Rows[0].Cells[4].Value = 0;
                    dgv[0].Rows[0].Cells[5].Value = 0;
                    차트[0].Series[0].Points[2].SetValueY(double.Parse(txt_inst_amt.Text));

                    for (int i = 0; i < 12; i++)
                    {
                        차트[i].ChartAreas[0].AxisY.Maximum = double.Parse(txt_inst_amt.Text);
                    }
                }
                else
                {
                    dgvSetting("1");
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
                lbl_pricessing_amt[locationNow].Enabled = false;
                txt_pass_amt[locationNow].Enabled = false;
                txt_poor_amt[locationNow].Enabled = false;
                txt_loss_amt[locationNow].Enabled = false;
                btn_Approval[locationNow].Enabled = false;

                lbl_pricessing_amt[locationNow].Text = "-";
                txt_pass_amt[locationNow].Text = "0";
                txt_poor_amt[locationNow].Text = "0";
                txt_loss_amt[locationNow].Text = "0";

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
                        lbl_pricessing_amt[locationNow + 1].Enabled = false;
                        txt_pass_amt[locationNow + 1].Enabled = false;
                        txt_poor_amt[locationNow + 1].Enabled = false;
                        txt_loss_amt[locationNow + 1].Enabled = false;
                        btn_Approval[locationNow + 1].Enabled = false;

                        lbl_pricessing_amt[locationNow + 1].Text = "-";
                        txt_pass_amt[locationNow + 1].Text = "0";
                        txt_poor_amt[locationNow + 1].Text = "0";
                        txt_loss_amt[locationNow + 1].Text = "0";

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

        private void dgvSetting(string f_step)
        {
            DataTable flow_seq = new DataTable();
            StringBuilder sb = new StringBuilder();

            try  
            {
                //진행중인 (한번 저장한거 다시 불러오는)
                DataTable dt = new DataTable();
                sb.AppendLine(" AND A.LOT_NO = '" + txt_lot_no.Text + "' ");
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
                            decimal sumBeforePass = decimal.Parse(txt_inst_amt.Text.ToString());
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
            if (e.RowIndex > -1)
            {
                conDataGridView grd = (conDataGridView)sender;
                int idx = int.Parse(grd.Name.Substring(grd.Name.Length - 2)) - 1; //그리드뷰 명칭의 끝 가져오기, workComp01 ~ workComp12 까지 지정되어 있음

                switch (grd.Columns[e.ColumnIndex].HeaderText)
                {
                    //case "일자":

                    //    _Retangle = grd.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                    //    dtp[idx].Size = new Size(_Retangle.Width, _Retangle.Height);
                    //    dtp[idx].Location = new Point(_Retangle.X, _Retangle.Y);
                    //    dtp[idx].Visible = true;

                    //    string flow_time = (string)grd.Rows[e.RowIndex].Cells[2].Value;
                    //    if (flow_time != "" && flow_time != null)
                    //    {
                    //        dtp[idx].Text = (string)grd.Rows[e.RowIndex].Cells[2].Value;
                    //    }
                    //    else
                    //    {
                    //        dtp[idx].Text = DateTime.Today.ToString("yyyy-MM-dd");
                    //    }
                    //    break;

                    //default:
                    //    dtp[idx].Visible = false;
                    //    break;
                }

                //lbl_Chk_Title[idx].Text = txt_lot_no.Text +"/" +txt_item_cd.Text +"/" +lbl_flow_cd[idx].Text;
                lbl_flow_title[idx].Text = lbl_flow_title_temp[idx] + " / SUB : " + grd.Rows[e.RowIndex].Cells[1].Value.ToString() +"";

                if (grd.Rows[e.RowIndex].Cells[2].Value == null || grd.Rows[e.RowIndex].Cells[2].Value.ToString().Equals(""))
                {
                    dtp_time[idx].Text = DateTime.Now.ToString("yyyy-MM-dd");
                }
                else
                {
                    try
                    {
                        dtp_time[idx].Text = grd.Rows[e.RowIndex].Cells[2].Value.ToString();
                    }
                    catch (Exception ex2)
                    {
                        dtp_time[idx].Text = DateTime.Now.ToString("yyyy-MM-dd");
                    }
                }

                if (grd.Rows[e.RowIndex].Cells[3].Value == null || grd.Rows[e.RowIndex].Cells[3].Value.ToString().Equals(""))
                {
                    grd.Rows[e.RowIndex].Cells[3].Value = "0";
                }
                if (grd.Rows[e.RowIndex].Cells[4].Value == null || grd.Rows[e.RowIndex].Cells[4].Value.ToString().Equals(""))
                {
                    grd.Rows[e.RowIndex].Cells[4].Value = "0";
                }
                if (grd.Rows[e.RowIndex].Cells[5].Value == null || grd.Rows[e.RowIndex].Cells[5].Value.ToString().Equals(""))
                {
                    grd.Rows[e.RowIndex].Cells[5].Value = "0";
                }

                try
                {
                    lbl_pricessing_amt[idx].Text = (decimal.Parse(grd.Rows[e.RowIndex].Cells[3].Value.ToString()) + decimal.Parse(grd.Rows[e.RowIndex].Cells[4].Value.ToString()) + decimal.Parse(grd.Rows[e.RowIndex].Cells[5].Value.ToString())).ToString("#,0.######");
                }
                catch (Exception ex2)
                {
                    lbl_pricessing_amt[idx].Text = grd.Rows[e.RowIndex].Cells[3].Value.ToString();
                    txt_pass_amt[idx].Text = grd.Rows[e.RowIndex].Cells[3].Value.ToString();
                    txt_poor_amt[idx].Text = grd.Rows[e.RowIndex].Cells[4].Value.ToString();
                    txt_loss_amt[idx].Text = grd.Rows[e.RowIndex].Cells[5].Value.ToString();
                    lbl_flow_seq_array[idx].Text = grd.Rows[e.RowIndex].Cells[1].Value.ToString();

                    //Set_Flow_flag_to_Not_Enabled(idx);
                    //Print_Chk_Card(idx);


                    return;
                }
                txt_pass_amt[idx].Text = grd.Rows[e.RowIndex].Cells[3].Value.ToString();
                txt_poor_amt[idx].Text = grd.Rows[e.RowIndex].Cells[4].Value.ToString();
                txt_loss_amt[idx].Text = grd.Rows[e.RowIndex].Cells[5].Value.ToString();
                lbl_flow_seq_array[idx].Text = grd.Rows[e.RowIndex].Cells[1].Value.ToString();

                if (grd.Rows[e.RowIndex].Cells[0].Value == null || (bool)grd.Rows[e.RowIndex].Cells[0].Value == false)
                {
                    lbl_pricessing_amt[idx].Enabled = true;
                    txt_pass_amt[idx].Enabled = true;
                    txt_poor_amt[idx].Enabled = true;
                    txt_loss_amt[idx].Enabled = true;
                    btn_Approval[idx].Enabled = true;
                    dtp_time[idx].Enabled = true;

                    진행[idx].BackColor = Color.FromArgb(59, 89, 152);
                    lbl_통과[idx].BackColor = Color.FromArgb(59, 89, 152);
                    lbl_불량[idx].BackColor = Color.FromArgb(59, 89, 152);
                    lbl_Loss[idx].BackColor = Color.FromArgb(59, 89, 152);
                    일자[idx].BackColor = Color.FromArgb(59, 89, 152);
                    btn_Approval[idx].BackColor = Color.FromArgb(59, 89, 152);
                    lbl_flow_title[idx].ForeColor = Color.FromArgb(59, 89, 152);


                    pn_카드[idx].Enabled = true;
                    pn_카드[idx].BackColor = Color.FromArgb(59, 89, 152);
                    btn_검사저장[idx].Enabled = true;
                    btn_검사저장[idx].BackColor = Color.FromArgb(59, 89, 152);
                    grd_검사기준[idx].Enabled = true;

                    Print_Chk_Card(idx);

                }
                else
                {
                    Set_Flow_flag_to_Not_Enabled(idx);

                    pn_카드[idx].Enabled = false;
                    pn_카드[idx].BackColor = Color.FromArgb(64,64,64);
                    btn_검사저장[idx].Enabled = false;
                    btn_검사저장[idx].BackColor = Color.FromArgb(64,64,64);
                    grd_검사기준[idx].Enabled = false;

                    Print_Chk_Card(idx);

                    return;
                }
            }
        }

        private void Print_Chk_Card(int idx)
        {
            try
            {
                grd_검사기준[idx].Rows.Clear();

                DataTable dt = wDm.fn_select_flow_chk(txt_lot_no.Text, lbl_flow_cd[idx].Text, lbl_flow_seq_array[idx].Text, (idx+1).ToString());


                if (dt != null && dt.Rows.Count > 0)
                {
                    grd_검사기준[idx].RowCount = dt.Rows.Count;
                    lbl_카드상태[idx].Text = "(v)";
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        grd_검사기준[idx].Rows[i].Cells[0].Tag = dt.Rows[i]["POOR_CD"].ToString();
                        grd_검사기준[idx].Rows[i].Cells[0].Value = dt.Rows[i]["POOR_NM"].ToString();
                        grd_검사기준[idx].Rows[i].Cells[1].Value = decimal.Parse(dt.Rows[i]["POOR_AMT"].ToString()).ToString("#,0.######");
                    }
                    grd_검사기준[idx].Rows.Add();
                    grd_검사기준[idx].Rows[grd_검사기준[idx].Rows.Count - 1].Cells[0].ReadOnly = true;
                    grd_검사기준[idx].Rows[grd_검사기준[idx].Rows.Count - 1].Cells[0].Value = "(불량코드 등록)";
                    grd_검사기준[idx].Rows[grd_검사기준[idx].Rows.Count - 1].DefaultCellStyle.ForeColor = Color.DarkGray;
                    grd_검사기준[idx].Rows[grd_검사기준[idx].Rows.Count - 1].DefaultCellStyle.SelectionForeColor = Color.DarkGray;
                }
                else
                {
                    lbl_카드상태[idx].Text = "( )";
                    grd_검사기준[idx].Rows.Add();
                    grd_검사기준[idx].Rows[grd_검사기준[idx].Rows.Count - 1].Cells[0].ReadOnly = true;
                    grd_검사기준[idx].Rows[grd_검사기준[idx].Rows.Count - 1].Cells[0].Value = "(불량코드 등록)";
                    grd_검사기준[idx].Rows[grd_검사기준[idx].Rows.Count - 1].DefaultCellStyle.ForeColor = Color.DarkGray;
                    grd_검사기준[idx].Rows[grd_검사기준[idx].Rows.Count - 1].DefaultCellStyle.SelectionForeColor = Color.DarkGray;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception 오류발생");
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                msg.ShowDialog();
            }
        }

        private void Set_Flow_flag_to_Not_Enabled(int idx)
        {
            lbl_pricessing_amt[idx].Enabled = false;
            txt_pass_amt[idx].Enabled = false;
            txt_poor_amt[idx].Enabled = false;
            txt_loss_amt[idx].Enabled = false;
            btn_Approval[idx].Enabled = false;
            btn_검사저장[idx].Enabled = false;
            pn_카드[idx].Enabled = false;
            dtp_time[idx].Enabled = false;

            lbl_카드상태[idx].Text = "( )";

            진행[idx].BackColor = Color.FromArgb(64, 64, 64);
            lbl_통과[idx].BackColor = Color.FromArgb(64, 64, 64);
            lbl_불량[idx].BackColor = Color.FromArgb(64, 64, 64);
            lbl_Loss[idx].BackColor = Color.FromArgb(64, 64, 64);
            일자[idx].BackColor = Color.FromArgb(64, 64, 64);

            btn_Approval[idx].BackColor = Color.FromArgb(64, 64, 64);
            lbl_flow_title[idx].ForeColor = Color.FromArgb(64, 64, 64);
            pn_카드[idx].BackColor = Color.FromArgb(64, 64, 64);
            btn_검사저장[idx].BackColor = Color.FromArgb(64, 64, 64);
        }

        private void btn_Approval_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int idx = int.Parse(btn.Name.Substring(btn.Name.Length - 2)) - 1;

            if(lbl_flow_cd[idx].Text == null || lbl_flow_cd[idx].Text.ToString().Equals("") || lbl_flow_cd[idx].Text.ToString().Equals("-"))
            {
                MessageBox.Show("선처리 공정을 먼저 선택하고 진행하여주십시오.");
                return;
            }



            int rowindexTemp = -1;
            for (int i = 0; i < dgv[idx].Rows.Count; i++)
            {
                if (lbl_flow_seq_array[idx].Text.ToString().Equals(dgv[idx].Rows[i].Cells[1].Value.ToString()))
                {
                    rowindexTemp = i;
                }
            }


            dgv[idx].Rows[rowindexTemp].Cells[3].Value = txt_pass_amt[idx].Text.ToString();
            dgv[idx].Rows[rowindexTemp].Cells[4].Value = txt_poor_amt[idx].Text.ToString();
            dgv[idx].Rows[rowindexTemp].Cells[5].Value = txt_loss_amt[idx].Text.ToString();

            decimal processing = 0;
            decimal pass = 0;
            decimal poor = 0;
            decimal loss = 0;
            try
            {
                processing = decimal.Parse(lbl_pricessing_amt[idx].Text.ToString());
                pass = decimal.Parse(txt_pass_amt[idx].Text.ToString());
                poor = decimal.Parse(txt_poor_amt[idx].Text.ToString());
                loss = decimal.Parse(txt_loss_amt[idx].Text.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("수량 입력 양식이 잘못되었습니다.");
                return;
            }

            if (processing < pass + poor + loss)
            {
                MessageBox.Show("통과, 불량, LOSS 수량의 합은 진행수량을 초과할 수 없습니다");
                return;
            }
            if (pass < 0 || poor < 0 || loss < 0)
            {
                MessageBox.Show("음수 입력은 불가능합니다.");
                return;
            }



            dgv[idx].Rows[rowindexTemp].Cells[2].Value = dtp_time[idx].Text.ToString();

            dgv[idx].Rows[rowindexTemp].Cells[0].Value = true;

            rowIndexTemp = dgv[idx].Rows[rowindexTemp].Cells[1].Value.ToString();

            int rsNum = wDm.insert_Work_Flow(
                txt_lot_no.Text
                , txt_item_cd.Text
                , lbl_flow_cd[idx].Text
                , (idx+1).ToString()
                , lbl_flow_seq_array[idx].Text
                , strCustCD
                , dtp_time[idx].Text.ToString()
                , processing.ToString()
                , pass.ToString()
                , poor.ToString()
                , loss.ToString()
                );

            if (rsNum == 0)
            {
                //MessageBox.Show("저장에 성공하였습니다");
                dgv[idx].Rows[rowindexTemp].DefaultCellStyle.BackColor = Color.FromArgb(59, 89, 152);
                dgv[idx].Rows[rowindexTemp].DefaultCellStyle.SelectionBackColor = Color.FromArgb(79, 109, 172);
                dgv[idx].Rows[rowindexTemp].DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
                dgv[idx].Rows[rowindexTemp].DefaultCellStyle.ForeColor = Color.WhiteSmoke;

                Set_Flow_flag_to_Not_Enabled(idx);
                if(dgv[idx+1].Visible)
                {
                    int newRow = -1;
                    for (int i = 0; i < dgv[idx + 1].Rows.Count; i++)
                    {
                        if (dgv[idx + 1].Rows[i].Cells[0].Value == null || (bool)dgv[idx + 1].Rows[i].Cells[0].Value == false)
                        {
                            newRow = i;
                            break;
                        }
                    }
                    if (newRow != -1)
                    {
                        dgv[idx + 1].Rows[newRow].Cells[3].Value = (decimal.Parse(dgv[idx + 1].Rows[newRow].Cells[3].Value.ToString()) + pass).ToString("#,0.######");
                        차트[idx + 1].Series.ResumeUpdates();
                        차트[idx + 1].Series[0].Points[2].SetValueY(decimal.Parse(dgv[idx + 1].Rows[newRow].Cells[3].Value.ToString()) + pass);
                        차트[idx + 1].DataBind();
                        차트[idx + 1].Series.Invalidate();
                        차트[idx + 1].Series.SuspendUpdates();
                    }
                    else
                    {
                        DataGridView nextDgv = dgv[idx + 1];
                        nextDgv.Rows.Add();
                        nextDgv.Rows[nextDgv.Rows.Count - 1].Cells[0].Value = false;
                        nextDgv.Rows[nextDgv.Rows.Count - 1].Cells[1].Value = nextDgv.Rows.Count;
                        nextDgv.Rows[nextDgv.Rows.Count - 1].Cells[2].Value = "";
                        nextDgv.Rows[nextDgv.Rows.Count - 1].Cells[3].Value = pass.ToString("#,0.######");
                        nextDgv.Rows[nextDgv.Rows.Count - 1].Cells[4].Value = "0";
                        nextDgv.Rows[nextDgv.Rows.Count - 1].Cells[5].Value = "0";
                        nextDgv.Rows[nextDgv.Rows.Count - 1].Cells[6].Value = "0";
                        nextDgv.Rows[nextDgv.Rows.Count - 1].DefaultCellStyle.BackColor = Color.FromArgb(64, 64, 64);
                        nextDgv.Rows[nextDgv.Rows.Count - 1].DefaultCellStyle.SelectionBackColor = Color.FromArgb(84, 84, 84);
                        nextDgv.Rows[nextDgv.Rows.Count - 1].DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
                        nextDgv.Rows[nextDgv.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.WhiteSmoke;
                        차트[idx + 1].Series.ResumeUpdates();
                        차트[idx + 1].Series[0].Points[2].SetValueY(pass);
                        차트[idx + 1].DataBind();
                        차트[idx + 1].Series.Invalidate();
                        차트[idx + 1].Series.SuspendUpdates();
                    }
                }

                차트[idx].Series.ResumeUpdates();
                //
                차트[idx].Series[0].ChartType = SeriesChartType.StackedColumn;

                if (int.Parse(lbl_flow_seq_array[idx].Text.ToString()) == 1)
                {
                    차트[idx].Series[차트[idx].Series.Count - 1].BorderWidth = 1;
                    차트[idx].Series[차트[idx].Series.Count - 1].BorderColor = Color.Black;
                    차트[idx].Series[차트[idx].Series.Count - 1].Points[0].SetValueY(pass);
                    차트[idx].Series[차트[idx].Series.Count - 1].Points[1].SetValueY(poor);
                }
                else
                {
                    Series sTemp = new Series("SEQ " + (int.Parse(lbl_flow_seq_array[idx].Text.ToString())));
                    sTemp.ChartType = SeriesChartType.StackedColumn;
                    차트[idx].Series.Add(sTemp);
                    sTemp.BorderWidth = 1;
                    sTemp.BorderColor = Color.Black;
                    차트[idx].Series[차트[idx].Series.Count - 1].BorderWidth = 1;
                    차트[idx].Series[차트[idx].Series.Count - 1].BorderColor = Color.Black;
                    차트[idx].Series[차트[idx].Series.Count - 1].Points.AddXY("통과", pass);
                    차트[idx].Series[차트[idx].Series.Count - 1].Points.AddXY("불량", poor);
                    차트[idx].Series[차트[idx].Series.Count - 1].Points.AddXY("미투입량", 0);
                    //차트[idx].Series[차트[idx].Series.Count - 1].Points.AddXY("LOSS", loss);

                    int r = 0;
                    int g = 0;
                    int b = 0;

                    Color ColorTemp = 차트[idx].Series[차트[idx].Series.Count - 2].Points[0].Color;
                    r = ColorTemp.R + 30;
                    g = ColorTemp.G + 30;
                    b = ColorTemp.B + 30;
                    if (r > 255) r = 255;
                    if (g > 255) g = 255;
                    if (b > 255) b = 255;
                    Color ColorTemp2 = Color.FromArgb(r, g, b);
                    차트[idx].Series[차트[idx].Series.Count - 1].Points[0].Color = ColorTemp2;
                    차트[idx].Series[차트[idx].Series.Count - 1].Color = ColorTemp2;

                    ColorTemp = 차트[idx].Series[차트[idx].Series.Count - 2].Points[1].Color;
                    r = ColorTemp.R + 30;
                    g = ColorTemp.G + 30;
                    b = ColorTemp.B + 30;
                    if (r > 255) r = 255;
                    if (g > 255) g = 255;
                    if (b > 255) b = 255;
                    ColorTemp2 = Color.FromArgb(r, g, b);
                    차트[idx].Series[차트[idx].Series.Count - 1].Points[1].Color = ColorTemp2;
                    //
                }
                차트[idx].DataBind();
                차트[idx].Series.Invalidate();
                차트[idx].Series.SuspendUpdates();

                if (processing - pass - poor - loss > 0)
                {
                    dgv[idx].Rows.Add();
                    dgv[idx].Rows[dgv[idx].Rows.Count - 1].Cells[0].Value = false;
                    dgv[idx].Rows[dgv[idx].Rows.Count - 1].Cells[1].Value = dgv[idx].Rows.Count;
                    dgv[idx].Rows[dgv[idx].Rows.Count - 1].Cells[2].Value = "";
                    dgv[idx].Rows[dgv[idx].Rows.Count - 1].Cells[3].Value = (processing - pass - poor - loss).ToString("#,0.######");
                    dgv[idx].Rows[dgv[idx].Rows.Count - 1].Cells[4].Value = "0";
                    dgv[idx].Rows[dgv[idx].Rows.Count - 1].Cells[5].Value = "0";
                    dgv[idx].Rows[dgv[idx].Rows.Count - 1].Cells[6].Value = "0";
                    dgv[idx].Rows[dgv[idx].Rows.Count - 1].DefaultCellStyle.BackColor = Color.FromArgb(64, 64, 64);
                    dgv[idx].Rows[dgv[idx].Rows.Count - 1].DefaultCellStyle.SelectionBackColor = Color.FromArgb(84, 84, 84);
                    dgv[idx].Rows[dgv[idx].Rows.Count - 1].DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
                    dgv[idx].Rows[dgv[idx].Rows.Count - 1].DefaultCellStyle.ForeColor = Color.WhiteSmoke;
                    차트[idx].Series.ResumeUpdates();
                    차트[idx].Series[0].Points[2].SetValueY(processing - pass - poor - loss);
                    차트[idx].DataBind();
                    차트[idx].Series.Invalidate();
                    차트[idx].Series.SuspendUpdates();
                }
                else
                {
                    차트[idx].Series.ResumeUpdates();
                    차트[idx].Series[0].Points[2].SetValueY(0);
                    차트[idx].DataBind();
                    차트[idx].Series.Invalidate();
                    차트[idx].Series.SuspendUpdates();
                }



                if(IsWorkDone())
                {
                    rsNum = wDm.update_Work_Flow_Complete(txt_lot_no.Text.ToString());
                    if (rsNum == 0)
                    {
                        MessageBox.Show("전체 공정이 완료되었습니다.");
                        lbl미완료.Text = "완료";
                        return;
                    }

                    if (rsNum == 1)
                    {
                        MessageBox.Show("전체 공정이 완료되었으나 작업지시 상태를 '완료' 상태로 수정하는 작업에서 오류가 발생하였습니다.");
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Exception 에러");
                        return;
                    }

                }
            }
            else if (rsNum == 1)
                MessageBox.Show("저장에 실패하였습니다");
            else
                MessageBox.Show("Exception 에러");



            lbl미완료.Text = "진행중";

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
            btn_shadow[idx].BackColor = Color.DimGray;

        }

        private void btn_Approval_MouseEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int idx = int.Parse(btn.Name.Substring(btn.Name.Length - 2)) - 1;

            pointTemp = btn.Location;
            Point point = btn_shadow[idx].Location;
            point = point + new Size(-2, -2);
            btn_shadow[idx].BackColor = Color.Silver;

            btn_Approval[idx].Location = point;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {

                if (lbl미완료.Text == "미완료")
                {
                    MessageBox.Show("저장된 공정 진행내역이 없습니다.(신규)");
                    return;
                }

                ComInfo cominfo = new ComInfo();
                DialogResult dr = MessageBox.Show(txt_lot_no.Text+ " 생산공정의 진행내역을 모두 삭제하시겠습니까? ", "공정 진행내역 삭제", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
               

                if (dr == DialogResult.Yes)
                {
                    int rsNum = wDm.delete_work_flow(
                        txt_lot_no.Text
                        );

                    if (rsNum == 0)
                    {
                        MessageBox.Show("성공적으로 삭제하였습니다.");
                        for (int i = 0; i < chk_pnl.Length; i++) // 11부터 등록 된 공정 수만큼 빼면서 그리드 버튼 판넬 숨김   ex 5개 - 11부터 ~5까지 숨김 
                        {
                            chk_pnl[i].Visible = false;
                            //chk_pnl[i].BackColor = Color.WhiteSmoke;
                        }
                        getsetting();
                    }
                    else if (rsNum == 1)
                    {
                        MessageBox.Show("저장 중 오류 발생");
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Exception 에러");
                        return;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception 오류");
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                msg.ShowDialog();
            }
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
                    break;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
            return true;
        }


    }
}
