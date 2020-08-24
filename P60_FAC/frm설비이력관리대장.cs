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

namespace MES.P60_FAC
{
    public partial class frm설비이력관리대장 : Form
    {
        private wnGConstant wConst = new wnGConstant();
        public static bool p_IsAuth = true;    // 열람권한
        public static bool p_Isrgstr = true;    //등록/수정 권한
        wnDm wnDm = new wnDm();
        public static bool p_Isdel = true;    // 삭제 권한       
        string condtition = "";

        public frm설비이력관리대장()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm설비이력관리대장_Load(object sender, EventArgs e)
        {
               lbl_title.Tag = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[0] + "$" + wnDm.fn_TitleName(this.Name.ToString()).Split('$')[1]; lbl_title.Text = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[2];

               init_ComboBox();

               FacChk_List("");
        }

        private void init_ComboBox()
        {
            ComInfo comInfo = new ComInfo();
            string sqlQuery = "";

            cmb_facnm.ValueMember = "코드";
            cmb_facnm.DisplayMember = "명칭";
            sqlQuery = comInfo.queryFac();
            wConst.ComboBox_Read_Blank(cmb_facnm, sqlQuery);
        }

        private void FacChk_List(string condition)
        {           
            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = null;
                dt = wDm.Fac_Chk_List(condition);

                this.dgv_FacList.RowCount = dt.Rows.Count;
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgv_FacList.Rows[i].Cells["FIX_DATE"].Value = dt.Rows[i]["FIX_DATE"].ToString();
                        dgv_FacList.Rows[i].Cells["FIX_TIME"].Value = dt.Rows[i]["FIX_TIME"].ToString();
                        //dgv_FacList.Rows[i].Cells["FIX_GUBUN"].Value = dt.Rows[i]["FIX_GUBUN"].ToString();
                        dgv_FacList.Rows[i].Cells["FIX_CUST"].Value = dt.Rows[i]["FIX_CUST"].ToString();
                        dgv_FacList.Rows[i].Cells["STAFF_NM"].Value = dt.Rows[i]["STAFF_NM"].ToString();
                        dgv_FacList.Rows[i].Cells["FIX_REPORT"].Value = dt.Rows[i]["FIX_REPORT"].ToString();

                        if (dt.Rows[i]["FIX_GUBUN"].ToString().Equals("1"))
                        {
                            dgv_FacList.Rows[i].Cells["FIX_GUBUN"].Value = "정기점검";
                        }
                        else 
                        {
                            dgv_FacList.Rows[i].Cells["FIX_GUBUN"].Value = "수리조치";
                        }
                    }
                }
                else
                {
                    dgv_FacList.Rows.Clear();
                }
            }
            catch (Exception ex)
            {
            }


        }

        

        private void cmb_facnm_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            FacChk_List("WHERE A.FIX_DATE >= '" + dtp_sDate.Text.ToString() + "' AND A.FIX_DATE <= '" + dtp_eDate.Text.ToString() + "' AND A.FAC_CD = '" + cmb_facnm.ValueMember + "' ");

        }
    }
}
