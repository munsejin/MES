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
    public partial class frm메탈마스크등록 : Form
    {
        private wnGConstant wConst = new wnGConstant();
        private ComInfo comInfo = new ComInfo();
        Image image;
        string path;

        public frm메탈마스크등록()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            wnDm wDm = new wnDm();
            int rsNum = wDm.Delete_Metal(txt_metalcd.Text.ToString());
            if (rsNum == 0)
            {
                resetSetting();

                MessageBox.Show("성공적으로 삭제하였습니다.");
            }
            else if (rsNum == 1)
            {
                MessageBox.Show("삭제에 실패하였습니다.");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Metal_Logic();
            MetalLoad();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            resetSetting();
        }

        private void MetalLoad()
        {
            if (Common.p_strUserNo == "696-87-00592")
            {

            }
 
            btnDelete.Enabled = false;

            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = null;
                dt = wDm.Metal_List();

                this.dgvMetalList.RowCount = dt.Rows.Count;
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgvMetalList.Rows[i].Cells["METAL_CD"].Value = dt.Rows[i]["METAL_CD"].ToString();                        
                        dgvMetalList.Rows[i].Cells["METAL_MODEL"].Value = dt.Rows[i]["METAL_MODEL"].ToString();
                        dgvMetalList.Rows[i].Cells["METAL_SPEC"].Value = dt.Rows[i]["METAL_SPEC"].ToString();
                        dgvMetalList.Rows[i].Cells["METAL_MAKECUST"].Value = dt.Rows[i]["METAL_MAKECUST"].ToString();
                        dgvMetalList.Rows[i].Cells["METAL_INPUT_DATE"].Value = dt.Rows[i]["METAL_INPUT_DATE"].ToString();
                        dgvMetalList.Rows[i].Cells["METAL_ORDERCUST"].Value = dt.Rows[i]["METAL_ORDERCUST"].ToString();
                        dgvMetalList.Rows[i].Cells["METAL_MAKE_DATE"].Value = dt.Rows[i]["METAL_MAKE_DATE"].ToString();
                        dgvMetalList.Rows[i].Cells["COMMENT"].Value = dt.Rows[i]["COMMENT"].ToString();                    
                    }
                }
                else
                {
                    dgvMetalList.Rows.Clear();
                }
            }
            catch (Exception ex)
            {
            }
        }

        #region fac logic

        private void Metal_Logic()
        {
            try
            {
                if (txt_metalcd.Text.ToString().Equals(""))
                {
                    MessageBox.Show("메탈코드를 입력하시기 바랍니다.");
                    return;
                }
               
                if (txt_modelnm.Text.ToString().Equals(""))
                {
                    MessageBox.Show("모델명을 입력하시기 바랍니다.");
                    return;
                }

                byte[] flow_img;
                int flow_img_size = 0;
                if (path != null && path != "")
                {
                    flow_img = ComInfo.GetImage(path);
                    flow_img_size = flow_img.Length;
                }
                else
                {
                    flow_img = null;
                    flow_img_size = 0;
                }


                if (txt_metalcd.Enabled)
                {
                    string lot_no = dtp_inputdate.Text.ToString().Replace("-", "");
                    lot_no = lot_no.Substring(2).ToString();             

                    wnDm wDm = new wnDm();
                    int rsNum = wDm.Insert_Metal(
                                      txt_metalcd.Text.ToString()                            
                                    , txt_modelnm.Text.ToString()
                                    , dtp_makedate.Text.ToString()
                                    , txt_spec.Text.ToString()
                                    , txt_ordercust.Text.ToString()
                                    , txt_makecust.Text.ToString()
                                    , dtp_inputdate.Text.ToString()
                                    , txt_comment.Text.ToString()     
                                    ,lot_no
                                    );
                    if (rsNum == 0)
                    {
                        resetSetting();
                        MessageBox.Show("성공적으로 등록하였습니다.");
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
                else
                {
                    wnDm wDm = new wnDm();
                    int rsNum = wDm.Update_Metal(
                                      txt_metalcd.Text.ToString()
                                    , txt_modelnm.Text.ToString()
                                    , dtp_makedate.Text.ToString()
                                    , txt_spec.Text.ToString()
                                    , txt_ordercust.Text.ToString()
                                    , txt_makecust.Text.ToString()
                                    , dtp_inputdate.Text.ToString()
                                    , txt_comment.Text.ToString()   
                                    );
                    if (rsNum == 0)
                    {
                        MessageBox.Show("성공적으로 수정하였습니다.");
                    }
                    else if (rsNum == 1)
                        MessageBox.Show("저장에 실패하였습니다");
                    else
                        MessageBox.Show("Exception 에러");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void resetSetting()
        {
            pic_fac_img.Image = null;
            txt_metalcd.Enabled = true;
            txt_metalcd.Text = "";            
            txt_modelnm.Text = "";
            dtp_makedate.Text = DateTime.Now.ToString();
            txt_ordercust.Text = "";            
            txt_makecust.Text = "";
            dtp_inputdate.Text = DateTime.Now.ToString();
            txt_comment.Text = "";

            dgvMetalList.Rows.Clear();

            MetalLoad();

            //pic_fac_img.BackgroundImage = null;

        }

        #endregion fac logic

        private void txt_power_num_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComInfo.onlyNum(sender, e);
        }

        private void txt_pro_capa_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComInfo.onlyNum(sender, e);
        }

        private void txt_acq_price_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComInfo.onlyNum(sender, e);
        }

        private void frm메탈마스크등록_Load(object sender, EventArgs e)
        {
               lbl_title.Tag = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[0] + "$" + wnDm.fn_TitleName(this.Name.ToString()).Split('$')[1]; lbl_title.Text = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[2];
            
            MetalLoad();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pic_logic(pic_fac_img);
        }

        private void pic_logic(PictureBox pic)
        {
            ofd.Filter = "*.png|*.jpg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //이미지 
                image = Image.FromFile(ofd.FileName);
                //이미지 경로 
                path = ofd.FileName;

                string sTxt = path.Substring(path.Length - 3, 3);

                if (sTxt != "jpg" && sTxt != "JPG" && sTxt != "png" && sTxt != "PNG" && sTxt != "pdf" && sTxt != "PDF")
                {
                    MessageBox.Show("이미지 파일만 선택 가능합니다..");
                    return;
                }

                /* 이미지 리사이즈 */
                Image cus_img = ComInfo.pic_resize_logic(pic, image);
                //픽쳐박스에 이미지를 띄운다
                pic.BackgroundImage = cus_img;
            }
        }

        private void dgvMetalList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnNew.PerformClick();

            if (e.RowIndex > -1)
            {
                
                txt_metalcd.Text = dgvMetalList.Rows[e.RowIndex].Cells["METAL_CD"].Value.ToString();
                txt_modelnm.Text = dgvMetalList.Rows[e.RowIndex].Cells["METAL_MODEL"].Value.ToString();
                dtp_makedate.Text = dgvMetalList.Rows[e.RowIndex].Cells["METAL_MAKE_DATE"].Value.ToString();
                txt_ordercust.Text = dgvMetalList.Rows[e.RowIndex].Cells["METAL_ORDERCUST"].Value.ToString();
                txt_makecust.Text = dgvMetalList.Rows[e.RowIndex].Cells["METAL_MAKECUST"].Value.ToString();
                dtp_inputdate.Text = dgvMetalList.Rows[e.RowIndex].Cells["METAL_INPUT_DATE"].Value.ToString();
                txt_comment.Text = dgvMetalList.Rows[e.RowIndex].Cells["COMMENT"].Value.ToString();

                
                txt_metalcd.Enabled = false;

                dgvMetalList.Rows.Clear();

                MetalLoad();

                btnDelete.Enabled = true;

                //pic_fac_img.BackgroundImage = null;
            }
        }

        private void txt_comment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave.Focus();
            }

            else
            {
                return;
            }
        }
    }
}
