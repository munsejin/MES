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
    public partial class frm설비메탈관리 : Form
    {
        public frm설비메탈관리()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm설비메탈관리_Load(object sender, EventArgs e)
        {
            FacGridList("");
            
            MetalGridList("");
          
            lbl_title.Text =wnDm.fn_TitleName(this.Name.ToString()).Split('/')[2];
            lbl_title.Tag = wnDm.fn_TitleName(this.Name.ToString()).Split('/')[0] + "/" + wnDm.fn_TitleName(this.Name.ToString()).Split('/')[1];
            

        }

        private void FacGridList(string condition)
        {
            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = null;
                dt = wDm.Fac_Grid_List(condition);

                this.dgv_FaclList.RowCount = dt.Rows.Count;
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgv_FaclList.Rows[i].Cells["FAC_CD"].Value = dt.Rows[i]["FAC_CD"].ToString();
                        dgv_FaclList.Rows[i].Cells["FAC_NM"].Value = dt.Rows[i]["FAC_NM"].ToString();
                        dgv_FaclList.Rows[i].Cells["MODEL_NM"].Value = dt.Rows[i]["MODEL_NM"].ToString();
                        dgv_FaclList.Rows[i].Cells["SPEC"].Value = dt.Rows[i]["SPEC"].ToString();
                        dgv_FaclList.Rows[i].Cells["MANU_COMPANY"].Value = dt.Rows[i]["MAKE_CUST"].ToString();
                        dgv_FaclList.Rows[i].Cells["ACQ_PRICE"].Value = dt.Rows[i]["ACQ_PRICE"].ToString();
                        dgv_FaclList.Rows[i].Cells["ACQ_DATE"].Value = dt.Rows[i]["INPUT_DATE"].ToString();
                        dgv_FaclList.Rows[i].Cells["PRO_CAPA"].Value = dt.Rows[i]["AMOUNT"].ToString();
                        dgv_FaclList.Rows[i].Cells["MAINTEN_CLASS"].Value = dt.Rows[i]["BUY_DATE"].ToString();
                        dgv_FaclList.Rows[i].Cells["COMMENT"].Value = dt.Rows[i]["COMMENT"].ToString();

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

        private void MetalGridList(string condition)
        {
            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = null;
                dt = wDm.Metal_List(condition);

                this.dgv_MetalList.RowCount = dt.Rows.Count;
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgv_MetalList.Rows[i].Cells["METAL_CD"].Value = dt.Rows[i]["METAL_CD"].ToString();
                        dgv_MetalList.Rows[i].Cells["METAL_MODEL"].Value = dt.Rows[i]["METAL_MODEL"].ToString();
                        dgv_MetalList.Rows[i].Cells["METAL_SPEC"].Value = dt.Rows[i]["METAL_SPEC"].ToString();
                        dgv_MetalList.Rows[i].Cells["METAL_MAKECUST"].Value = dt.Rows[i]["METAL_MAKECUST"].ToString();
                        dgv_MetalList.Rows[i].Cells["METAL_INPUT_DATE"].Value = dt.Rows[i]["METAL_INPUT_DATE"].ToString();
                        dgv_MetalList.Rows[i].Cells["METAL_ORDERCUST"].Value = dt.Rows[i]["METAL_ORDERCUST"].ToString();
                        dgv_MetalList.Rows[i].Cells["METAL_MAKE_DATE"].Value = dt.Rows[i]["METAL_MAKE_DATE"].ToString();
                        dgv_MetalList.Rows[i].Cells["METAL_COMMENT"].Value = dt.Rows[i]["COMMENT"].ToString();
                    }
                }
                else
                {
                    dgv_MetalList.Rows.Clear();
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

        private void btn_metalsrch_Click(object sender, EventArgs e)
        {
            if (txt_metalnm.Text != "" && txt_metalnm.Text != null)
            {
                MetalGridList(txt_metalnm.Text);
            }
            else
            {
                MetalGridList("");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgv_MetalList.Rows.Clear();
            dgv_FaclList.Rows.Clear();
        }
    }
}
