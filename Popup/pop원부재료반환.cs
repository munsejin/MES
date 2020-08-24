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

namespace MES.Popup
{
    public partial class pop원자재반환 : Form
    {
        private wnGConstant wConst = new wnGConstant();
        private ComInfo comInfo = new ComInfo();
        public string item_cd = "";
        public string w_inst_date = "";
        public string w_inst_cd = "";
        public string lot_no = "";
        wnDm wDm = new wnDm();

        private DataGridView del_dgv = new DataGridView();

        public int chk = 0; /* 작업공정완료 후 잔재수정시 chk */

        public pop원자재반환()
        {
            InitializeComponent();
        }

        private void pop원자재반환_Load(object sender, EventArgs e)
        {
            string sqlQuery = "";

            STORAGE_CD.ValueMember = "코드";
            STORAGE_CD.DisplayMember = "명칭";
            sqlQuery = comInfo.queryStorage();
            wConst.ComboBox_Read_NoBlank(STORAGE_CD, sqlQuery);


            del_dgv.AllowUserToAddRows = false;
            del_dgv.Columns.Add("INPUT_DATE", "INPUT_DATE");
            del_dgv.Columns.Add("INPUT_CD", "INPUT_CD");
            del_dgv.Columns.Add("SEQ", "SEQ");




            DataTable dt = new DataTable();

            string sb = " and (A.LOT_NO =" + lot_no + " )";
            //dt = wDm.fn_item_inst_raw_list(sb.ToString());


            dt = wDm.raw_input_lotNo(sb);

            if (chk == 1)
            {
                grid_logic(dt);
            }

        }

        private void grid_logic(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                rs_order_grid.Rows.Clear();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    rs_order_grid.Rows.Add();
                    rs_order_grid.Rows[i].Cells[0].Value = (i + 1).ToString();
                    rs_order_grid.Rows[i].Cells[1].Value = dt.Rows[i]["SPEC"].ToString();
                    rs_order_grid.Rows[i].Cells[2].Value = dt.Rows[i]["TOTAL_AMT"].ToString();
                    rs_order_grid.Rows[i].Cells[3].Value = dt.Rows[i]["STORAGE_CD"].ToString();
                    rs_order_grid.Rows[i].Cells[4].Value = dt.Rows[i]["COMMENT"].ToString();
                    rs_order_grid.Rows[i].Cells["SEQ"].Value = dt.Rows[i]["SEQ"].ToString();
                    txt_input_date.Text = dt.Rows[i]["INPUT_DATE"].ToString();
                    txt_input_cd.Text = dt.Rows[i]["INPUT_CD"].ToString();

                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            if (rs_order_grid.Rows.Count > 0)
            {
                for (int i = 0; i < rs_order_grid.Rows.Count; i++)
                {
                    if (rs_order_grid.Rows[i].Cells["SPEC"].Value == null)
                    {
                        rs_order_grid.Rows[i].Cells.Clear();
                    }
                }
            }
         

            if (rs_order_grid.Rows.Count > 0)
            {
                for (int i = 0; i < rs_order_grid.Rows.Count; i++)
                {
                    if (rs_order_grid.Rows[i].Cells["SPEC"].Value == null || rs_order_grid.Rows[i].Cells["TOTAL_AMT"].Value == null)
                    {
                        MessageBox.Show("규격과 수량을 입력해주세요.");
                        break;
                    }
                }

                if (chk == 0)
                {
                    int rsNum = wDm.returnRmInput(
                w_inst_date//input_date
                , "dregs"// txt_cust_cd
                , "Y"//input_yn
                , rs_order_grid
                ,lot_no
                    );


                    if (rsNum == 0)
                        MessageBox.Show("성공적으로 등록하였습니다.");

                    else if (rsNum == 1)
                        MessageBox.Show("저장에 실패하였습니다");

                    else
                        MessageBox.Show("Exception 에러");
                }
                else if (chk == 1)
                {
                    int rsNum = wDm.update_returnRmInput(
                txt_input_date.Text//input_date
                ,txt_input_cd.Text
                , rs_order_grid
                , lot_no
                , del_dgv
                    );


                    if (rsNum == 0)
                        MessageBox.Show("성공적으로 등록하였습니다.");

                    else if (rsNum == 1)
                        MessageBox.Show("저장에 실패하였습니다");

                    else
                        MessageBox.Show("Exception 에러");
                }
            }
            else
            {
                MessageBox.Show("남은 잔재의 정보를 입력해주세요");
                return;
            }


            




            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_plus_Click(object sender, EventArgs e)
        {
            rs_order_grid.Rows.Add();
        }

        private void btn_minus_Click(object sender, EventArgs e)
        {
            minus_logic(rs_order_grid);
        }
        private void minus_logic(DataGridView dgv)
        {
            if (dgv.Rows.Count > 0)
            {

                if ((string)dgv.SelectedRows[0].Cells["SEQ"].Value != "" && dgv.SelectedRows[0].Cells["SEQ"].Value != null)
                {
                    int cnt = del_dgv.Rows.Count;

                    del_dgv.Rows.Add();

                    del_dgv.Rows[del_dgv.Rows.Count - 1].Cells["INPUT_DATE"].Value = txt_input_date.Text;
                    del_dgv.Rows[del_dgv.Rows.Count - 1].Cells["INPUT_CD"].Value = txt_input_cd.Text;
                    del_dgv.Rows[del_dgv.Rows.Count - 1].Cells["SEQ"].Value = dgv.SelectedRows[0].Cells["SEQ"].Value;
                }


            }
            if (dgv.Rows.Count > 0)
            {
                dgv.Rows.RemoveAt(dgv.SelectedRows[0].Index);
            }
            if (dgv.Rows.Count > 0)
            {
                dgv.CurrentCell = dgv[1, dgv.Rows.Count - 1];
            }
        }
        


    }
}
