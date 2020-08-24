using MES.CLS;
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

namespace MES.H70_자동기록관리
{
    public partial class frm설비카운트기준등록 : Form
    {
        private bool bData = false;
        private int iCnt;
        private string strValue;

        private wnGConstant wConst = new wnGConstant();
        private wnAdo wAdo = new wnAdo();



        public frm설비카운트기준등록()
        {
            InitializeComponent();
        }

        private void frm설비카운트기준등록_Load(object sender, EventArgs e)
        {
            lbl_title.Tag = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[0] + "$" + wnDm.fn_TitleName(this.Name.ToString()).Split('$')[1]; lbl_title.Text = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[2];
            lbl_input_gubun.Text = "";
            init_ComboBox();
            selectGrid();
        }

        private void selectGrid()
        {
            try
            {

                wnDm wDm = new wnDm();
                DataTable dt = wDm.select_Counter_code();
                GridRecord.Rows.Clear();
                if (dt != null && dt.Rows.Count > 0)
                {
                    GridRecord.RowCount = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        GridRecord.Rows[i].Cells["설비코드"].Value = dt.Rows[i]["M_CODE"].ToString();
                        GridRecord.Rows[i].Cells["설비명"].Value = dt.Rows[i]["M_NAME"].ToString();
                        GridRecord.Rows[i].Cells["설비위치"].Value = dt.Rows[i]["LOC_NM"].ToString();
                        GridRecord.Rows[i].Cells["설비위치코드"].Value = dt.Rows[i]["LOC_CD"].ToString();
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("리스트 조회 중 오류발생");
                return;
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                wnDm wDm= new wnDm();
                string loc = "";
                if(cmb_tmp_loc.SelectedIndex != 0)
                {
                    loc = cmb_tmp_loc.SelectedValue.ToString();
                }

                if (!lbl_input_gubun.Text.ToString().Equals("1"))
                {

                    int rsNum = wDm.insert_counter_code(
                        txtCode.Text.ToString()
                        , txtName.Text.ToString()
                        , loc
                        );
                    if(rsNum == 0){
                        MessageBox.Show("성공적으로 등록하였습니다.");
                        lbl_input_gubun.Text = "1";
                        selectGrid();
                        return;
                    }else if(rsNum == 1){
                        MessageBox.Show("저장에 실패하였습니다.");
                        return;
                    }else{
                        MessageBox.Show("sql Exception");
                        return;
                    }
                }
                else
                {
                    int rsNum = wDm.Update_counter_code(
                        txtCode.Text.ToString()
                        , txtName.Text.ToString()
                        , loc
                        );
                    if (rsNum == 0)
                    {
                        MessageBox.Show("성공적으로 수정하였습니다.");
                        lbl_input_gubun.Text = "1";
                        selectGrid();
                        return;
                    }
                    else if (rsNum == 1)
                    {
                        MessageBox.Show("수정에 실패하였습니다.");
                        return;
                    }
                    else
                    {
                        MessageBox.Show("sql Exception");
                        return;
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXception 오류 발생");
                return;

            }
        }

        
        private void init_ComboBox()
        {
            ComInfo comInfo = new ComInfo();

            string sqlQuery = "";

            cmb_tmp_loc.ValueMember = "코드";
            cmb_tmp_loc.DisplayMember = "명칭";
            sqlQuery = comInfo.querySensorLoc();
            wConst.ComboBox_Read_Blank(cmb_tmp_loc, sqlQuery);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            resetSetting();
        }

        private void resetSetting()
        {
            txtCode.Text = "";
            txtCode.Enabled = true;
            btnDelete.Enabled = false;
            txtName.Text = "";
            cmb_tmp_loc.SelectedIndex = 0;
            lbl_input_gubun.Text = "";

        }

        private void GridRecord_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                btnDelete.Enabled = true;
                txtCode.Text = GridRecord.Rows[e.RowIndex].Cells["설비코드"].Value.ToString();
                txtName.Text = GridRecord.Rows[e.RowIndex].Cells["설비명"].Value.ToString();
                if (!GridRecord.Rows[e.RowIndex].Cells["설비위치코드"].Value.ToString().Equals(""))
                {
                    cmb_tmp_loc.SelectedValue = GridRecord.Rows[e.RowIndex].Cells["설비위치코드"].Value.ToString();
                }
                lbl_input_gubun.Text = "1";
                txtCode.Enabled = false;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                wnDm wDm = new wnDm();
                int rsNum = wDm.delete_counter_code(txtCode.Text.ToString());
                if (rsNum == 0)
                {
                    MessageBox.Show("성공적으로 삭제하였습니다");
                    resetSetting();
                    selectGrid();
                    return;
                }
                else if (rsNum == 1)
                {
                    MessageBox.Show("저장에 실패하였습니다");
                    return;
                }
                else
                {
                    MessageBox.Show("Exception 오류");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excpetion 오류");
                return;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        




    }
}
