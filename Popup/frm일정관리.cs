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
    public partial class frm일정관리 : Form
    {
        private frmBack frmBack;
        private string p;
         private Point mCurrentPosition = new Point(0, 0); //

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
                mCurrentPosition = new Point(-e.X, -e.Y);

        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(
                    this.Location.X + (mCurrentPosition.X + e.X),
                    this.Location.Y + (mCurrentPosition.Y + e.Y));// 마우스의 이동치를 Form Location에 반영한다.
            }
        }
      
        public frm일정관리()
        {
            InitializeComponent();
        }
        public frm일정관리(string p)
        {
            InitializeComponent();
            this.p = p;
        }

        public frm일정관리(frmBack frmBack)
        {
            InitializeComponent();

            // TODO: Complete member initialization
            this.frmBack = frmBack;
        }

        public frm일정관리(MES.frmBack frmBack, string p)
        {
            InitializeComponent();

            // TODO: Complete member initialization
            this.frmBack = frmBack;
            this.p = p;
        }

        private void frm일정관리_Load(object sender, EventArgs e)
        {
            dtp.Value = DateTime.Parse(p.ToString());

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

            this.Close();
        }
        public void insert(String date,String title,String memo )
        {
           
            try
            {
                wnDm wDm = new wnDm();

                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb.AppendLine("	insert  into F_DATES (Title,date,Memo,color) values ('" + title + "','" + date + "','" + memo + "','" + scolor16 + "')");

                SqlCommand sCommand = new SqlCommand(sb.ToString());

                int qResult = wAdo.SqlCommandEtc(sCommand, "insert_RAW_CHK_EXAM_TB");


            }
            catch (Exception e)
            {
                wnLog.writeLog(wnLog.LOG_ERROR, e.Message + " - " + e.ToString());
                Popup.pop오류리포트 msg = new pop오류리포트(e.Message + " - " + e.ToString());
                msg.ShowDialog();
                return;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                insert(dtp.Value.ToString().Substring(0, 10), txt제목.Text ?? "","");
                MessageBox.Show("저장되었습니다.");
                this.DialogResult = DialogResult.OK;
                this.Close();

            }
            catch
            {
                MessageBox.Show("실패하였습니다..");

            }
        }
        Color scolor=Color.Black;
        string scolor16 = "#000000";
        private void button3_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                scolor = cd.Color;
                scolor16 = "#"+(cd.Color.ToArgb() & 0x00FFFFFF).ToString("X6");

                scolor = cd.Color;
                
            }
            button3.BackColor = scolor;
            txt제목.ForeColor = scolor;
            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            DialogResult msgOk = MessageBox.Show(dtp.Value.ToString().Substring(0, 10) + " 일정을 삭제하시겠습니까??", "클리어", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (msgOk == DialogResult.No)
            {
                return;
            }

            clear();
            this.DialogResult = DialogResult.OK;

            this.Close();
           
        }
        private void clear()
        {


            try
            {
                wnDm wDm = new wnDm();

                wnAdo wAdo = new wnAdo();
                StringBuilder sb = new StringBuilder();

                sb.AppendLine("	delete from F_DATES where Date='"+dtp.Value.ToString().Substring(0, 10)+"' ");

                SqlCommand sCommand = new SqlCommand(sb.ToString());

                int qResult = wAdo.SqlCommandEtc(sCommand, "insert_RAW_CHK_EXAM_TB");


            }
            catch (Exception e)
            {
                wnLog.writeLog(wnLog.LOG_ERROR, e.Message + " - " + e.ToString());
                Popup.pop오류리포트 msg = new pop오류리포트(e.Message + " - " + e.ToString());
                msg.ShowDialog();
                return;
            }
        }
    }
}
