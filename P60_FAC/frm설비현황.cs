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
    public partial class frm설비현황 : Form
    {
        public static bool p_IsAuth = true;    // 열람권한
        public static bool p_Isrgstr = true;    //등록/수정 권한
        public static bool p_Isdel = true;    // 삭제 권한
        wnDm wnDm = new wnDm();
        private wnGConstant wConst = new wnGConstant();
        private ComInfo comInfo = new ComInfo();
        public frm설비현황()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            dgv_FaclList.Rows.Clear();
        }

        private void frm설비현황_Load(object sender, EventArgs e)
        {
            lbl_title.Tag = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[0] + "$" + wnDm.fn_TitleName(this.Name.ToString()).Split('$')[1]; lbl_title.Text = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[2];
            if (Common.p_strUserAdmin != "5")
            {
                DataTable dtcheck = wnDm.fn_auth_check(lbl_title.Tag.ToString().Split('$')[0], lbl_title.Tag.ToString().Split('$')[1]);
                p_IsAuth = dtcheck.Rows[0]["auth_yn"].ToString() == "Y" ? true : false;
                p_Isrgstr = dtcheck.Rows[0]["rgstr_yn"].ToString() == "Y" ? true : false;
                p_Isdel = dtcheck.Rows[0]["del_yn"].ToString() == "Y" ? true : false;
                try
                {
                    if (!p_IsAuth)
                    {
                        this.BeginInvoke(new MethodInvoker(Close));
                        /// MessageBox.Show("권한이없습니다.");
                    }

                }
                catch (Exception ex)
                {
                }
            }

            init_ComboBox();

            FacGridList("");


        }
        private void init_ComboBox()
        {
           
            string sqlQuery = "";

           



        
        }
        private void FacGridList(string condition)
        {
            try
            {
               
                DataTable dt = null;
                dt = wnDm.Fac_Grid_List(condition);

                this.dgv_FaclList.RowCount = dt.Rows.Count;
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgv_FaclList.Rows[i].Cells["FAC_CD"].Value = dt.Rows[i]["FAC_CD"].ToString();
                        dgv_FaclList.Rows[i].Cells["FAC_NM"].Value = dt.Rows[i]["FAC_NM"].ToString();
                        dgv_FaclList.Rows[i].Cells["MODEL_NM"].Value = dt.Rows[i]["MODEL_NM"].ToString();
                        dgv_FaclList.Rows[i].Cells["SPEC"].Value = dt.Rows[i]["SPEC"].ToString();
                        dgv_FaclList.Rows[i].Cells["MANU_COMPANY"].Value = dt.Rows[i]["MANU_COMPANY"].ToString();
                        dgv_FaclList.Rows[i].Cells["ACQ_PRICE"].Value = dt.Rows[i]["ACQ_PRICE"].ToString();
                        dgv_FaclList.Rows[i].Cells["ACQ_DATE"].Value = dt.Rows[i]["ACQ_DATE"].ToString();
                        dgv_FaclList.Rows[i].Cells["PRO_CAPA"].Value = dt.Rows[i]["AMOUNT"].ToString();
                        dgv_FaclList.Rows[i].Cells["CHECK_CYCLE"].Value = dt.Rows[i]["CHECK_CYCLE"].ToString();
                       
                        dgv_FaclList.Rows[i].Cells["COMMENT"].Value = dt.Rows[i]["COMMENT"].ToString();
                        dgv_FaclList.Rows[i].Cells["사용여부"].Value = dt.Rows[i]["USED"].ToString();

                        if (dt.Rows[i]["USED"].ToString()=="Y")
                        {
                             dgv_FaclList.Rows[i].Cells["사용여부"].Value="사용중";
                        }
                        else if (dt.Rows[i]["USED"].ToString()=="N")
                        {
                            dgv_FaclList.Rows[i].Cells["사용여부"].Value = "사용안함";
                        }

                        dgv_FaclList.Rows[i].Cells["최근검사일"].Value = DateTime.Parse(dt.Rows[i]["dateInspc"].ToString());

                        int int점검주기=int.Parse(dgv_FaclList.Rows[i].Cells["CHECK_CYCLE"].Value.ToString())*7;

                       dgv_FaclList.Rows[i].Cells["점검예정일"].Value= DateTime.Parse(dgv_FaclList.Rows[i].Cells["최근검사일"].Value.ToString()).AddDays(int점검주기);
                    }
                }
                else
                {
                    dgv_FaclList.Rows.Clear();
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void btn_facsrch_Click(object sender, EventArgs e)
        {
            if (txt_facnm.Text != "" && txt_facnm.Text != null)
            {
                FacGridList(txt_facnm.Text);
            }
            else
            {
                FacGridList("");
            }
        }

        private void txt_facnm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_facsrch.Focus();
            }

            else
            {
                return;
            }
        }
        /// <summary>
        ///  셀 컨텐츠를 눌렀을때 
        ///  버튼을 눌렀을때 반응하게 하기위해  버튼컬럼으로 다운케스팅함
        /// </summary>
        /// <param name="sender"> 데이터 그리드 ->(다운케스팅) 데이터그리드버튼 </param>
        /// <param name="e"></param>
        private void dgv_FaclList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                if (dgv_FaclList.Rows[e.RowIndex].Cells["사용여부"].Value.ToString() == "사용중")
                {
                    dgv_FaclList.Rows[e.RowIndex].Cells["사용여부"].Value = "사용안함";
                }
                else if (dgv_FaclList.Rows[e.RowIndex].Cells["사용여부"].Value.ToString() == "사용안함")
                {
                    dgv_FaclList.Rows[e.RowIndex].Cells["사용여부"].Value = "사용중";
                }
                wnDm.update_FAC_USED(dgv_FaclList.Rows[e.RowIndex].Cells["FAC_CD"].Value.ToString(), dgv_FaclList.Rows[e.RowIndex].Cells["사용여부"].Value.ToString());

            }
        }
    }
}
