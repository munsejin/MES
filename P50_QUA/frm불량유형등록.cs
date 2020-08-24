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

namespace MES.P50_QUA
{
    public partial class frm불량유형등록 : Form
    {
        public frm불량유형등록()
        {
            InitializeComponent();
        }

        private void frm불량유형등록_Load(object sender, EventArgs e)
        {
            lbl_title.Tag = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[0] + "$" + wnDm.fn_TitleName(this.Name.ToString()).Split('$')[1]; lbl_title.Text = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[2];
            
            init_ComboBox();
            chk_list();

            radio_raw.Checked = true;
        }

        #region button logic 

        private void btnNew_Click(object sender, EventArgs e)
        {
            resetSetting();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            chk_logic();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            chk_del();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion button logic


        #region logic 

        private void init_ComboBox()
        {
            ComInfo comInfo = new ComInfo();

            cmb_poor_gubun.Items.Add("전체 검색");
            cmb_poor_gubun.Items.Add("원자재 수입");
            cmb_poor_gubun.Items.Add("공정");
            cmb_poor_gubun.SelectedIndex = 0;
        }

        private void chk_logic() 
        {
            try
            {
                if (txt_poor_nm.Text.ToString().Equals(""))
                {
                    MessageBox.Show("검사항목명을 입력하시기 바랍니다.");
                    return;
                }


                string chk_gbn = ""; // 공정 1 
                if (radio_flow.Checked == true)
                {
                    chk_gbn = "2";
                }
                else
                {
                    chk_gbn = "1";
                }


                if (lbl_chk_gbn.Text != "1")
                {
                    wnDm wDm = new wnDm();
                    int rsNum = wDm.insertPoor(
                                     txt_poor_nm.Text.ToString()
                                    , chk_gbn
                                    , txt_comment.Text.ToString());

                    if (rsNum == 0)
                    {
                        resetSetting();
                        chk_list();
                        MessageBox.Show("성공적으로 등록하였습니다.");
                    }
                    else if (rsNum == 1)
                        MessageBox.Show("저장에 실패하였습니다");
                    else if (rsNum == 2)
                        MessageBox.Show("SQL COMMAND 에러");
                    else if (rsNum == 3)
                        MessageBox.Show("기존 코드가 있으니 \n 다른 코드로 입력 바랍니다.");
                    else if (rsNum == 4)
                        MessageBox.Show("기존 검사순서가 있으니 \n 다른 검사순서로 입력 바랍니다.");
                    else
                        MessageBox.Show("Exception 에러1");
                }
                else 
                {
                    wnDm wDm = new wnDm();
                    int rsNum = wDm.updatePoor(
                                      txt_poor_cd.Text.ToString()
                                    , txt_poor_nm.Text.ToString()
                                    , txt_comment.Text.ToString());

                    if (rsNum == 0)
                    {
                        chk_list();
                        MessageBox.Show("성공적으로 수정하였습니다.");
                    }
                    else if (rsNum == 1)
                        MessageBox.Show("저장에 실패하였습니다");
                    else if (rsNum == 2)
                        MessageBox.Show("SQL COMMAND 에러");
                    else if (rsNum == 3)
                        MessageBox.Show("기존 코드가 있으니 \n 다른 코드로 입력 바랍니다.");
                    else
                        MessageBox.Show("Exception 에러1");
                }
            }
            catch (Exception e) 
            {
                MessageBox.Show("시스템 오류: " + e.ToString());
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(e.Message + " - " + e.ToString());
                msg.ShowDialog();
            }
        }

        private void resetSetting()
        {
            radio_flow.Enabled = true;
            radio_raw.Enabled = true;

            lbl_chk_gbn.Text = "";
            btnDelete.Enabled = false;
            txt_poor_cd.Text = "(자동발급)";
            txt_poor_cd.Enabled = false;
            txt_poor_nm.Text = "";
            txt_comment.Text = "";
        }

        private void chk_list()
        {
            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = null;

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("where 1=1 ");
                if (cmb_poor_gubun.SelectedIndex > 0) 
                {
                    sb.AppendLine("and A.POOR_GUBUN = '" + cmb_poor_gubun.SelectedIndex.ToString() + "' ");
                }
                if (!txt_srch.Text.ToString().Equals(""))
                {
                    sb.AppendLine("and POOR_NM like '%" + txt_srch.Text.ToString() + "%' ");
                }

                dt = wDm.fn_Poor_List(sb.ToString());


                if (dt != null && dt.Rows.Count > 0)
                {
                    lbl_cnt.Text = dt.Rows.Count.ToString();

                    this.dataChkGrid.RowCount = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dataChkGrid.Rows[i].Cells["POOR_CD"].Value = dt.Rows[i]["POOR_CD"].ToString();
                        dataChkGrid.Rows[i].Cells["POOR_NM"].Value = dt.Rows[i]["POOR_NM"].ToString();
                        dataChkGrid.Rows[i].Cells["POOR_GUBUN"].Value = dt.Rows[i]["POOR_GUBUN_NM"].ToString();
                        dataChkGrid.Rows[i].Cells["COMMENT"].Value = dt.Rows[i]["COMMENT"].ToString();
                    }
                }
                else
                {
                    dataChkGrid.Rows.Clear();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("시스템 오류: " + e.ToString());
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(e.Message + " - " + e.ToString());
                msg.ShowDialog();
            }
        }
        #endregion logic

        private void dataChkGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridView dgv = dataChkGrid;
                int idx = e.RowIndex;
                btnDelete.Enabled = true;
                lbl_chk_gbn.Text = "1";
                txt_poor_cd.Enabled = false;

                radio_flow.Enabled = false;
                radio_raw.Enabled = false;
                try
                {
                    if (dgv.Rows[idx].Cells["POOR_GUBUN"].Value.ToString().Equals("공정"))
                    { //공정
                        radio_flow.Checked = true;
                        radio_raw.Checked = false;
                    }
                    else if (dgv.Rows[idx].Cells["POOR_GUBUN"].Value.ToString().Equals("원자재 수입"))
                    { //제품
                        radio_flow.Checked = false;
                        radio_raw.Checked = true;
                    }

                    txt_poor_cd.Text = dgv.Rows[idx].Cells["POOR_CD"].Value.ToString();
                    txt_poor_nm.Text = dgv.Rows[idx].Cells["POOR_NM"].Value.ToString();
                    txt_comment.Text = dgv.Rows[idx].Cells["COMMENT"].Value.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("시스템 오류: " + ex.ToString());
                    Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                    msg.ShowDialog();
                }
            }
        }

        private void chk_del()
        {
            string chk_gbn = ""; // 공정검사 1 , 제품검사 2 , 원자재수입검사 3
            if (radio_flow.Checked == true)
            {
                chk_gbn = "2";
            }
            else 
            {
                chk_gbn = "1";
            }

            wnDm wDm = new wnDm();
            int rsNum = wDm.deletePoor(txt_poor_cd.Text.ToString(), chk_gbn);
            if (rsNum == 0)
            {
                resetSetting();

                chk_list();
                MessageBox.Show("성공적으로 삭제하였습니다.");
            }
            else if (rsNum == 1)
            {
                MessageBox.Show("삭제에 실패하였습니다.");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            chk_list();
        }

        private void txt_chk_ord_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComInfo.onlyNum(sender, e);
        }

        private void dataChkGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            Keys key = keyData & ~(Keys.Shift | Keys.Control);
            switch (key)
            {
                case Keys.W:
                    // 조합키 사용 시
                    if ((keyData & Keys.Control) != 0)
                    {
                        this.Close();
                    }
                    else return base.ProcessCmdKey(ref msg, keyData);
                    break;
                case Keys.S:
                    // 조합키 사용 시
                    if ((keyData & Keys.Control) != 0)
                    {
                        btnSave.PerformClick();
                    }
                    else return base.ProcessCmdKey(ref msg, keyData);
                    break;
                case Keys.F5:
                    // 단일키 사용시
                    btnNew.PerformClick();
                    break;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
            return true;
        }

    }
}
