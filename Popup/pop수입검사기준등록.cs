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
    public partial class pop수입검사기준등록 : Form
    {

        wnGConstant wConst = new wnGConstant();

        public string s_CHK_CD = "";
        public string s_CHK_NM = "";
        public string s_DEFAULT = "";
        public string s_TOOLS = "";
        public string s_TIME = "";
        public string s_POOR_CD = "";
        public string s_POOR_NM = "";

        public pop수입검사기준등록()
        {
            InitializeComponent();
        }

        private void pop수입검사기준등록_Load(object sender, EventArgs e)
        {
            //lbl_title.Tag = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[0] + "$" + wnDm.fn_TitleName(this.Name.ToString()).Split('$')[1]; lbl_title.Text = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[2];
            
            init_ComboBox();
            chk_list();
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

            string sqlQuery = "";

            cmb_poor.ValueMember = "코드";
            cmb_poor.DisplayMember = "명칭";
            sqlQuery = comInfo.queryRawPoor();
            wConst.ComboBox_Read_Blank(cmb_poor, sqlQuery);

        }

        private void chk_logic() 
        {
            try
            {
                if (txt_chk_nm.Text.ToString().Equals(""))
                {
                    MessageBox.Show("검사항목명을 입력하시기 바랍니다.");
                    return;
                }


                if (cmb_poor.SelectedIndex == 0)
                {
                    MessageBox.Show("불량 유형을 선택하여 주십시오.");
                    return;
                }

                if (txt_pass_value.Text == null) txt_pass_value.Text = "";
                if (txt_chk_tool.Text == null) txt_chk_tool.Text = "";
                if (txt_chk_time.Text == null) txt_chk_time.Text = "";

                if (lbl_chk_gbn.Text != "1")
                {
                    


                    wnDm wDm = new wnDm();

                    DataTable dt = wDm.newRawChkCode();

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        txt_chk_cd.Text = dt.Rows[0]["NEW_RC"].ToString();
                    }
                    else { MessageBox.Show("오류발생"); return; };

                    int rsNum = wDm.insertRawChk_Stan(
                                     txt_chk_nm.Text.ToString()
                                    , txt_pass_value.Text.ToString()
                                    , txt_chk_tool.Text.ToString()
                                    , txt_chk_time.Text.ToString()
                                    , cmb_poor.SelectedValue.ToString()
                                    );

                    if (rsNum == 0)
                    {
                        MessageBox.Show("성공적으로 등록하였습니다.");

                        s_POOR_NM = cmb_poor.GetItemText(cmb_poor.SelectedItem);
                        s_POOR_CD = cmb_poor.SelectedValue.ToString();
                        s_CHK_CD = txt_chk_cd.Text;
                        s_CHK_NM = txt_chk_nm.Text;
                        s_DEFAULT = txt_pass_value.Text;
                        s_TOOLS = txt_chk_tool.Text;
                        s_TIME = txt_chk_time.Text;
                        this.Close();
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
                    int rsNum = wDm.updateRawChk_Stan(
                                      txt_chk_cd.Text.ToString()
                                    , txt_chk_nm.Text.ToString()
                                    , txt_pass_value.Text.ToString()
                                    , txt_chk_tool.Text.ToString()
                                    , txt_chk_time.Text.ToString()
                                    , cmb_poor.SelectedValue.ToString()
                                    );

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
            btnDelete.Enabled = false;
            txt_chk_cd.Text = "(자동발급)";
            txt_chk_cd.Enabled = false;
            txt_chk_nm.Text = "";
            txt_pass_value.Text = "";
            txt_chk_time.Text = "";
            txt_chk_tool.Text = "";
            lbl_chk_gbn.Text = "";
            cmb_poor.SelectedIndex = 0;

        }

        private void chk_list()
        {
            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = null;

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("where 1=1 ");
                if (!txt_srch.Text.ToString().Equals(""))
                {
                    sb.AppendLine("and CHK_NM like '%" + txt_srch.Text.ToString() + "%' ");
                }

                dt = wDm.fn_RawChkStan_List(sb.ToString());


                if (dt != null && dt.Rows.Count > 0)
                {
                    lbl_cnt.Text = dt.Rows.Count.ToString();

                    this.dataChkGrid.RowCount = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dataChkGrid.Rows[i].Cells["CHK_CD"].Value = dt.Rows[i]["CHK_CD"].ToString();
                        dataChkGrid.Rows[i].Cells["CHK_NM"].Value = dt.Rows[i]["CHK_NM"].ToString();
                        dataChkGrid.Rows[i].Cells["PASS_VALUE"].Value = dt.Rows[i]["PASS_VALUE"].ToString();
                        dataChkGrid.Rows[i].Cells["CHK_TOOL"].Value = dt.Rows[i]["CHK_TOOL"].ToString();
                        dataChkGrid.Rows[i].Cells["CHK_TIME"].Value = dt.Rows[i]["CHK_TIME"].ToString();
                        dataChkGrid.Rows[i].Cells["POOR_CD"].Value = dt.Rows[i]["POOR_CD"].ToString();
                        dataChkGrid.Rows[i].Cells["POOR_NM"].Value = dt.Rows[i]["POOR_NM"].ToString();
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
                lbl_chk_gbn.Text = "1";
                btnDelete.Enabled = true;

                txt_chk_cd.Text = dataChkGrid.Rows[e.RowIndex].Cells["CHK_CD"].Value.ToString();
                txt_chk_nm.Text = dataChkGrid.Rows[e.RowIndex].Cells["CHK_NM"].Value.ToString();
                txt_pass_value.Text = dataChkGrid.Rows[e.RowIndex].Cells["PASS_VALUE"].Value.ToString();
                txt_chk_tool.Text = dataChkGrid.Rows[e.RowIndex].Cells["CHK_TOOL"].Value.ToString();
                txt_chk_time.Text = dataChkGrid.Rows[e.RowIndex].Cells["CHK_TIME"].Value.ToString();
                cmb_poor.SelectedValue = dataChkGrid.Rows[e.RowIndex].Cells["POOR_CD"].Value.ToString();

            }
        }

        private void chk_del()
        {
            wnDm wDm = new wnDm();
            int rsNum = wDm.delete_RawChk_Stan(txt_chk_cd.Text.ToString());
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
