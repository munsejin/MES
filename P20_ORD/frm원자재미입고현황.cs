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

namespace MES.P20_ORD
{
    public partial class frm원자재미입고현황 : Form
    {
        public frm원자재미입고현황()
        {
            InitializeComponent();
        }
        wnDm wnDm= new wnDm();
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
                public static bool p_IsAuth = true;    // 열람권한
        public static bool p_Isrgstr = true;    //등록/수정 권한

        public static bool p_Isdel = true;    // 삭제 권한
        private void frm원자재미입고현황_Load(object sender, EventArgs e)
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
            grdCellSetting();
        }

        private void init_ComboBox()
        {
            cmb_cd_srch.Items.Add("전체 검색");
            cmb_cd_srch.Items.Add("코드별 검색");
            cmb_cd_srch.Items.Add("원자재명 검색");
            cmb_cd_srch.Items.Add("규격 검색");
            cmb_cd_srch.SelectedIndex = 0;
        }

        private void grdCellSetting()
        {
            ComInfo comInfo = new ComInfo();
            comInfo.grdCellSetting(dgv_mipgo_list);   

            //for (int i = 0; i < rawStockGrid.ColumnCount; i++)
            //{
            //    rawStockGrid.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //    rawStockGrid.Columns[i].ReadOnly = true;
            //}

            //for (int i = 0; i < rawDetailGrid.ColumnCount; i++) 
            //{
            //    rawDetailGrid.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //    rawDetailGrid.Columns[i].ReadOnly = true;
            //}
        }

        public void grdCellSetting(DataGridView dgv)
        {
            for (int i = 0; i < dgv.ColumnCount; i++)
            {
                dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.Columns[i].ReadOnly = true;
            }
        }

        public void dgv_list()
        {
            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = null;
                dt = wDm.fn_mipgo_List("where A.ITEM_NM LIKE '%" + txt_srch.Text.ToString() + "%' ");

                this.dgv_mipgo_list.RowCount = dt.Rows.Count;
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgv_mipgo_list.Rows[i].Cells["RAW_MAT_CD"].Value = dt.Rows[i]["RAW_MAT_CD"].ToString();
                        dgv_mipgo_list.Rows[i].Cells["RAW_MAT_NM"].Value = dt.Rows[i]["RAW_MAT_NM"].ToString();
                        dgv_mipgo_list.Rows[i].Cells["SPEC"].Value = dt.Rows[i]["SPEC"].ToString();
                        dgv_mipgo_list.Rows[i].Cells["AMT"].Value = dt.Rows[i]["TOTAL_AMT"].ToString();
                        dgv_mipgo_list.Rows[i].Cells["MIPGO_AMT"].Value = dt.Rows[i]["CURR_AMT"].ToString();
                    }
                }
                else
                {
                    dgv_mipgo_list.Rows.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("시스템 오류" + ex.ToString());
            }

        }
    }
}
