using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MES.CLS;

namespace MES.Popup
{
    public partial class pop유통기한등록 : Form
    {
        //  sql 잠시 저장
        //select CONVERT(nvarchar(10),dateadd(mm,(select EXPRT_COUNT from N_EXPRT_DATE),MF_DATE),120) as MF_DATE from F_RAW_MEAT_DETAIL
        private wnGConstant wConst = new wnGConstant();
       

        public pop유통기한등록()
        {
            InitializeComponent();
        }

        private void pop유통기한등록_Load(object sender, EventArgs e)
        {
            init_ComboBox();
        }

        private void init_ComboBox()
        {
            ComInfo comInfo = new ComInfo();
            string sqlQuery = "";

            cmb_exprt_gubun.ValueMember = "코드";
            cmb_exprt_gubun.DisplayMember = "명칭";
            sqlQuery = comInfo.queryUsedYn(); //사용여부검색
            wConst.ComboBox_Read_NoBlank(cmb_exprt_gubun, sqlQuery);
            
        }

        private void bindData()
        {
            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = null;
                //dt = wDm.fn_MANCODE_List_pop(strCondition);

                

            }
            catch (Exception ex){
wnLog.writeLog(wnLog.LOG_ERROR, ex.Message + " - " + ex.ToString());Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                msg.ShowDialog();
            }
        }

       

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void tmClose_Tick(object sender, EventArgs e)
        {
            tmClose.Enabled = false;
            this.Close();
        }

        

       

        

      

    }
}
