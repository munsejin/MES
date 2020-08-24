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
    public partial class frm금형등록 : Form
    {
        bool iNCk = true;

        public frm금형등록()
        {
            InitializeComponent();
        }



        private void btnSave_Click(object sender, EventArgs e)
        {


            int rsNum = 3;
               //if (lbl_user_gbn.Text != "1")
            if (iNCk)
            {
                wnDm wDm = new wnDm();
                rsNum = wDm.insertMold(txt_mold_num.Text.ToString()
                    , txt_mold_nm.Text.ToString()
                    , txt_weight.Text.ToString()
                    , cmb_gubun.SelectedValue.ToString()
                    , cmb_storage.SelectedValue.ToString()
                    , dtp_start_date.Text.ToString()
                    , "" ); 

                
            }
            else
            {
                wnDm wDm = new wnDm();
                rsNum = wDm.updateMold(txt_mold_num.Text.ToString()
                    , txt_mold_nm.Text.ToString()
                    , txt_weight.Text.ToString()
                    , cmb_storage.SelectedValue.ToString()
                    , cmb_gubun.SelectedValue.ToString()
                    , dtp_start_date.Text.ToString()
                    , "");

     
            }

            if (rsNum == 0)
            {
                MessageBox.Show("성공적으로 등록하였습니다.");
            }
            else if (rsNum == 1)
                MessageBox.Show("저장에 실패하였습니다");
       
            else
                MessageBox.Show("Exception 에러1");

            moldList();
            reset();

        }

        private void frm금형등록_Load(object sender, EventArgs e)
        {
                        lbl_title.Tag = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[0] + "$" + wnDm.fn_TitleName(this.Name.ToString()).Split('$')[1]; lbl_title.Text = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[2];

                        cmbDataBinding();
                        moldList();

      
        }

        private void cmbDataBinding()
        {
            ComInfo comInfo = new ComInfo();
            wnGConstant wConst = new wnGConstant();
            string sqlQuery = "";
            cmb_storage.ValueMember = "코드";
            cmb_storage.DisplayMember = "명칭";
            sqlQuery = comInfo.queryStorage();
            wConst.ComboBox_Read_Blank(cmb_storage, sqlQuery);



            cmb_gubun.ValueMember = "코드";
            cmb_gubun.DisplayMember = "명칭";
            sqlQuery = comInfo.queryLCode("310");
            wConst.ComboBox_Read_Blank(cmb_gubun, sqlQuery);
        }




        private void moldList()
        {
            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = null;
                dt = wDm.fn_Mold_List("");

                if (dt != null && dt.Rows.Count > 0)
                {
                    this.dataRawCdGrid.RowCount = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                      //  dataRawCdGrid.Rows.Add();
                        dataRawCdGrid.Rows[i].Cells["MOLD_NO"].Value = dt.Rows[i]["MOLD_NO"].ToString();
                        dataRawCdGrid.Rows[i].Cells["MOLD_NM"].Value = dt.Rows[i]["MOLD_NM"].ToString();
                        dataRawCdGrid.Rows[i].Cells["WEIGHT"].Value = dt.Rows[i]["WEIGHT"].ToString();
                        dataRawCdGrid.Rows[i].Cells["MOLD_GUBUN"].Value = dt.Rows[i]["MOLD_GUBUN"].ToString();
                        dataRawCdGrid.Rows[i].Cells["STORAGE_CD"].Value = dt.Rows[i]["STORAGE_CD"].ToString();
                        dataRawCdGrid.Rows[i].Cells["STORAGE_NM"].Value = dt.Rows[i]["STORAGE_NM"].ToString();
                        dataRawCdGrid.Rows[i].Cells["INPUT_DATE"].Value = dt.Rows[i]["INPUT_DATE"].ToString();
                        dataRawCdGrid.Rows[i].Cells["COMMENT"].Value = dt.Rows[i]["COMMENT"].ToString();
                        if (int.Parse(dt.Rows[i]["INST_MOLD_CNT"].ToString()) > 0)
                        {
                            dataRawCdGrid.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.Yellow;
                            dataRawCdGrid.Rows[i].DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Blue;
                        }
             

                    }
                }
                else
                {
                    dataRawCdGrid.Rows.Clear();
                }
            }
            catch (Exception e)
            {

            }

        }

        private void delete()
        {
            wnDm wDm = new wnDm();

            int rsNum = wDm.deleteMold(txt_mold_num.Text.ToString());
            if (rsNum == 0)
            {
                reset();
                moldList();
                MessageBox.Show("성공적으로 삭제하였습니다.");
            }
            else if (rsNum == 1)
            {
                MessageBox.Show("삭제에 실패하였습니다.");
            }
        }


        private void reset()
        {
            txt_mold_num.Text = "";
            txt_mold_nm.Text = "";
            txt_weight.Text = "";
            if(cmb_storage.Items.Count > 0 )
                cmb_storage.SelectedIndex = 0;
            if(cmb_gubun.Items.Count > 0)
                cmb_gubun.SelectedIndex = 0;
            dtp_start_date.Text = DateTime.Now.ToString("yyyy-MM-dd");

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            delete();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataRawCdGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            txt_mold_num.Text = dataRawCdGrid.Rows[e.RowIndex].Cells["MOLD_NO"].Value.ToString();
            txt_mold_nm.Text = dataRawCdGrid.Rows[e.RowIndex].Cells["MOLD_NM"].Value.ToString();
            txt_weight.Text = dataRawCdGrid.Rows[e.RowIndex].Cells["WEIGHT"].Value.ToString();
            cmb_storage.SelectedValue = dataRawCdGrid.Rows[e.RowIndex].Cells["MOLD_GUBUN"].Value.ToString();
            cmb_gubun.SelectedValue = dataRawCdGrid.Rows[e.RowIndex].Cells["MOLD_GUBUN"].Value.ToString();
            dtp_start_date.Text = dataRawCdGrid.Rows[e.RowIndex].Cells["INPUT_DATE"].Value.ToString();
        }

        private void dataRawCdGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
