using MES.CLS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MES.P30_SCH
{
    public partial class frm생산모니터링 : Form
    {
        public frm생산모니터링()
        {
            
            InitializeComponent();
        }
        wnDm wDm = new wnDm();
        private wnGConstant wConst = new wnGConstant();
        wnAdo wAdo = new wnAdo();
        public int TimerCount;
        public int TimerFirstValue = 61;
        private void frm생산모니터링_Load(object sender, EventArgs e)
        {
            lbl_title.Tag = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[0] + "$" + wnDm.fn_TitleName(this.Name.ToString()).Split('$')[1]; lbl_title.Text = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[2];
          

            start_date.Value = DateTime.Now;
            end_date.Value = DateTime.Now;
            InitializeTimer();
            
        }


        private void InitializeTimer()
        {
            // 타이머당 이벤트 호출 시간 부여 1초 = 1000 
            TimerCount = TimerFirstValue;
            Timer2.Interval = 1000; //카운트다운을 출력하기 위한 타이머 = 1초
            Timer2.Enabled = true;

            bind생산모니터링();
        }  
        String condition = "";
        private void bind생산모니터링()
        {
            DataTable dt = null;
            condition = "and substring(A.INTIME,0,12)>='" + start_date.Value.ToString().Substring(0, 10) + "' and substring(A.INTIME,0,12)<='" + end_date.Value.ToString().Substring(0, 10) + "'";
            dt = wDm.fn_생산모니터링(condition);

            TimerCount = TimerFirstValue;


            if (dt != null && dt.Rows.Count > 0)
            {
                dgv재고.RowCount = dt.Rows.Count;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dgv재고.Rows[i].Cells["ITEM_NM"].Value = dt.Rows[i]["ITEM_NM"].ToString();
                    dgv재고.Rows[i].Cells["SPEC"].Value = dt.Rows[i]["SPEC"].ToString();
                    //   dgv재고.Rows[i].Cells["창고명"].Value = dt.Rows[i]["STORAGE_CD"].ToString();
                    dgv재고.Rows[i].Cells["STAFF_NM"].Value = dt.Rows[i]["WORKER_NM"].ToString();
                    dgv재고.Rows[i].Cells["INPUT_AMT"].Value = decimal.Parse(dt.Rows[i]["CURR_AMT"].ToString()).ToString("#,0.######");
                    dgv재고.Rows[i].Cells["LOT_NO"].Value = dt.Rows[i]["LOT_NO"].ToString();
                    dgv재고.Rows[i].Cells["LOT_SUB"].Value = dt.Rows[i]["LOT_SUB"].ToString();
                    dgv재고.Rows[i].Cells["CUST_NM"].Value = dt.Rows[i]["CUST_NM"].ToString();
                    
                }
            }

        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            lbl_title.Text = Common.p_strCompNm + "   생산 모니터링     " + DateTime.Now.ToString("yyyy.MM.dd    HH:mm:ss");
            if (lbl_timer_count.Text.Equals("1"))
            {
                lbl_timer_count.ForeColor = Color.Black;
                bind생산모니터링();
            }
            else if (TimerCount <= 11)
            {
                lbl_timer_count.ForeColor = Color.Red;
            }
            lbl_timer_count.Text = (--TimerCount).ToString();
        }

        private void btnSrch_Click(object sender, EventArgs e)
        {
            bind생산모니터링();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
