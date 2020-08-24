using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MES.CLS;
using MES.Controls;
using MES.Popup;

namespace MES.P85_BAS
{
    public partial class frm기초코드등록_New : Form
    {
        private wnGConstant wConst = new wnGConstant();
        public static bool p_IsAuth = true;    // 열람권한
        public static bool p_Isrgstr = true;    //등록/수정 권한
        wnDm wnDm = new wnDm();
        public static bool p_Isdel = true;    // 삭제 권한

        DataTable dt = null;
        string strTable;

        bool NewSave = true; // true = 저장 , false = 수정

        public frm기초코드등록_New()
        {
            InitializeComponent();
        }

        private void frm기로코드등록_New_Load(object sender, EventArgs e)
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

            btnDelete.Enabled = false;

            foreach (Control ctrl in this.pnlMain.Controls)
            {
                if (ctrl is Button)
                {
                    ctrl.Click += new EventHandler(btnClick);
                }

            }
            btnUnit.PerformClick();

            this.ActiveControl = txtCode; ;
            txtCode.Focus();
        }



        private void btnClick(object sender, EventArgs e)
        {
            try
            {
                btnDelete.Enabled = false;
                txtCode.ReadOnly = false;
                grdType.Rows.Clear();
                grdType.Refresh();

                btnOff();

                Button btnselect = sender as Button;
                btnselect.BackColor = Color.White;
                strTable = btnselect.Tag.ToString();
                BasicgrdList(strTable, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnOff()
        {
            foreach (Control ctrl in this.pnlMain.Controls)
            {
                if (ctrl is Button)
                {
                    ctrl.BackColor = Color.Gainsboro;
                }
            }
            txtoff();
        }
        //텍스트 초기화
        private void txtoff()
        {
            txtCode.ReadOnly = false;
            foreach (Control ctrl in pnlMain.Controls)
            {
                if (ctrl is TextBox)
                {
                    ctrl.Text = "";
                }
            }
            txtSearch.Text = "";
            txtCode.Focus();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                btnDelete.Enabled = false;
                NewSave = true;

                txtoff();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool duplicate = false;

                if (NewSave)
                {
                    if (txtCode.Text != null && txtCode.Text != "")
                    {
                        for (int i = 0; i < grdType.Rows.Count; i++)
                        {
                            if (txtCode.Text == grdType.Rows[i].Cells["code"].Value.ToString())
                            {
                                duplicate = true;
                                break;
                            }
                        }
                        if (!duplicate) // 코드 중복 확인
                        {

                            if (MessageBox.Show("저장하시겠습니까?", "저장확인", MessageBoxButtons.OKCancel) == DialogResult.OK)
                            {
                                try
                                {
                                    wnDm.insertBasicCd(strTable, txtCode.Text.ToString(), txtName.Text.ToString(), txtCmt.Text.ToString());
                                    BasicgrdList(strTable, null);
                                    MessageBox.Show("저장되었습니다.");

                                    NewSave = true;
                                    txtoff();
                                    btnDelete.Enabled = false;

                                }
                                catch (Exception ex)
                                {
                                    wnLog.writeLog(wnLog.LOG_ERROR, ex.Message + "-" + ex.ToString());
                                    MessageBox.Show("저장하지 못하였습니다.");
                                }
                            }

                        }
                        else
                        {
                            MessageBox.Show("코드는 중복될 수 없습니다.");
                            txtCode.Clear();
                            txtCode.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("코드를 작성해주세요.");
                    }
                }
                else
                {
                    // lhj - 2019.12.16 수정확인
                    if (MessageBox.Show("수정하시겠습니까?", "수정확인", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        try
                        {
                            wnDm.updateBasicCd(strTable, txtCode.Text.ToString(), txtName.Text.ToString(), txtCmt.Text.ToString());
                            BasicgrdList(strTable, null);
                            MessageBox.Show("수정되었습니다.");

                            NewSave = true;
                            txtoff();
                            btnDelete.Enabled = false;
                        }
                        catch (Exception ex)
                        {
                            wnLog.writeLog(wnLog.LOG_ERROR, ex.Message + "-" + ex.ToString());
                            MessageBox.Show("수정하지 못하였습니다.");
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        private void BasicgrdList(string strTable, string condition)
        {
            dt = wnDm.dtBasicCd(strTable, condition);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                grdType.Rows.Add();
                grdType.Rows[i].Cells["code"].Value = dt.Rows[i]["코드"].ToString();
                grdType.Rows[i].Cells["name"].Value = dt.Rows[i]["명칭"].ToString();
                grdType.Rows[i].Cells["comment"].Value = dt.Rows[i]["비고"].ToString();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
             BasicgrdList(strTable, txtSearch.Text.ToString());
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("삭제하시겠습니까?", "삭제확인", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    wnDm.deleteBasicCd(strTable, txtCode.Text);
                    BasicgrdList(strTable, null);
                    NewSave = true;
                    txtoff();
                    btnDelete.Enabled = false;
                    BasicgrdList(strTable, null);
                    MessageBox.Show("삭제되었습니다.");
                }
                catch (Exception ex)
                {
                    wnLog.writeLog(wnLog.LOG_ERROR, ex.Message + "-" + ex.ToString());
                    MessageBox.Show("삭제하지 못하였습니다.");
                }
            }
            else
            {
                return;
            }
        }

        private void grdType_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView grdtemp = sender as DataGridView;
            if (e.RowIndex < 0)
            {
                return;
            }
            else
            {
                txtCode.Text = grdtemp.Rows[e.RowIndex].Cells["code"].Value.ToString();
                txtName.Text = grdtemp.Rows[e.RowIndex].Cells["name"].Value.ToString();
                txtCmt.Text = grdtemp.Rows[e.RowIndex].Cells["comment"].Value.ToString();
            }

            btnDelete.Enabled = true;
        }



        private void txtCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComInfo.onlyNum(sender, e);
        }
    }
}
