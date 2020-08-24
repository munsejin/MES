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
    public partial class frm금형사용이력조회 : Form
    {
        public frm금형사용이력조회()
        {
            InitializeComponent();
        }

        private void frm금형사용이력조회_Load(object sender, EventArgs e)
        {
            lbl_title.Tag = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[0] + "$" + wnDm.fn_TitleName(this.Name.ToString()).Split('$')[1]; lbl_title.Text = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[2];
            inst_mold_list();
        }
        private void inst_mold_list()
        {
            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = null;
                dt = wDm.fn_Mold_List("");

                if (dt != null && dt.Rows.Count > 0)
                {
                    this.dataItemGrid.RowCount = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //  dataRawCdGrid.Rows.Add();
                        dataItemGrid.Rows[i].Cells["MOLD_NO"].Value = dt.Rows[i]["MOLD_NO"].ToString();
                        dataItemGrid.Rows[i].Cells["MOLD_NM"].Value = dt.Rows[i]["MOLD_NM"].ToString();
                        dataItemGrid.Rows[i].Cells["WEIGHT"].Value = dt.Rows[i]["WEIGHT"].ToString();
                        dataItemGrid.Rows[i].Cells["MOLD_GUBUN"].Value = dt.Rows[i]["MOLD_GUBUN"].ToString();
                        dataItemGrid.Rows[i].Cells["STORAGE_CD"].Value = dt.Rows[i]["STORAGE_CD"].ToString();
                        dataItemGrid.Rows[i].Cells["STORAGE_NM"].Value = dt.Rows[i]["STORAGE_NM"].ToString();
                        dataItemGrid.Rows[i].Cells["INPUT_DATE"].Value = dt.Rows[i]["INPUT_DATE"].ToString();
                        dataItemGrid.Rows[i].Cells["COMMENT"].Value = dt.Rows[i]["COMMENT"].ToString();
                        if (int.Parse(dt.Rows[i]["INST_MOLD_CNT"].ToString()) > 0)
                        {
                            dataItemGrid.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.Yellow;
                            dataItemGrid.Rows[i].DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Blue;
                        }


                    }
                }
                else
                {
                    dataItemGrid.Rows.Clear();
                }
            }
            catch (Exception e)
            {

            }

        }

        private void dataItemGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = null;
                dt = wDm.fn_Mold_Use("and A.MOLD_CD = '" + dataItemGrid.Rows[e.RowIndex].Cells["MOLD_NO"].Value + "'");

                if (dt != null && dt.Rows.Count > 0)
                {
                    this.grd_mold_sub.RowCount = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //  dataRawCdGrid.Rows.Add();
                        grd_mold_sub.Rows[i].Cells["W_INST_DATE"].Value = dt.Rows[i]["W_INST_DATE"].ToString();
                        grd_mold_sub.Rows[i].Cells["INST_AMT"].Value = dt.Rows[i]["INST_AMT"].ToString();
                        grd_mold_sub.Rows[i].Cells["FLOW_DATE"].Value = dt.Rows[i]["FLOW_DATE"].ToString();
                        grd_mold_sub.Rows[i].Cells["ITEM_CD"].Value = dt.Rows[i]["ITEM_CD"].ToString();
                        grd_mold_sub.Rows[i].Cells["ITEM_NM"].Value = dt.Rows[i]["ITEM_NM"].ToString();
                        grd_mold_sub.Rows[i].Cells["COMPLETE_YN"].Value = dt.Rows[i]["COMPLETE_YN"].ToString() == "N"? "미완료":"완료";
                        //if (dt.Rows[i]["COMPLETE_YN"].ToString() == "N")
                        //{
                        //    grd_mold_sub.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.Yellow;
                        //    grd_mold_sub.Rows[i].DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Blue;
                        //}


                    }
                }
                else
                {
                    dataItemGrid.Rows.Clear();
                }
            }
            catch (Exception x)
            {

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
