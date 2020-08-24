using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MES.Controls;
using MES.CLS;
using System.IO;

namespace MES.P30_SCH
{
    public partial class frm도면관리 : Form
    {
        private string ImgPath = "";
        private Image image;
        private byte[] ip;
        private byte[] img;
        private int img_size = 0;
        wnDm wDm = new wnDm();
        ComInfo cominfo = new ComInfo();
        
        public frm도면관리()
        {
            InitializeComponent();
        }
        private void frm도면관리_Load(object sender, EventArgs e)
        {
            resetSetting();
            grid_list();

        }

       
        private void btn_floorPlan_Click(object sender, EventArgs e)
        {
            picLogic();
        }
        private void picLogic()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg;*.jpeg;*.gif;*.bmp;*.png";
            ofd.ShowDialog();


            if (ofd.FileNames.Length > 0)
            {
                foreach (string filename in ofd.FileNames)
                {

                    txtFloorPlanNm.Text = Path.GetFileNameWithoutExtension(filename); //경로빼고 파일명만! 
                    image = Image.FromFile(filename); //이미지
                    ImgPath = filename; //파일경로

                    Image floorPlanImg = ComInfo.pic_resize_logic(pictureBox1, image);
                    pictureBox1.BackgroundImage = floorPlanImg;
                }
            }
            else
            {
                pictureBox1.BackgroundImage = null;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveLogic();
        }

        private void saveLogic()
        {
            try
            {
                if (pictureBox1.BackgroundImage == null)
                {
                    MessageBox.Show("도면사진을 등록해주세요.");
                    return;
                }

                

                if (img_size == 0)
                {
                    if (ImgPath != null && ImgPath != "")
                    {
                        img = ComInfo.GetImage(ImgPath);
                        img_size = img.Length;
                    }
                    else
                    {
                        img = null;
                        img_size = 0;
                    }
                }
                
                

                wnDm wDm = new wnDm();
                if (lbl_gbn.Text.Equals("1")) /*신규등록*/
                {
                    int rsNum = wnDm.floorPlanSave(
                        dtp_input_date.Text,
                        txtFloorPlanNm.Text,
                        img,
                        img_size,
                        Common.p_strStaffNo,
                        txt_comment.Text,
                        "1"); //1은 구분자 1.도면 2.밀시트

                    if (rsNum == 0)
                    {
                        MessageBox.Show("성공적으로 등록하였습니다.");
                        grid_list();
                    }
                    else if (rsNum == 1)
                    {
                        MessageBox.Show("저장에 실패하였습니다.");
                    }
                    else
                    {
                        MessageBox.Show("Exception 에러 ");
                    }

                }

                   
                else if (lbl_gbn.Text.Equals("0")) /*테이블 더블클릭시 -> 수정*/
                {
                    int rsNum = wnDm.floorPlanUpdate(
                        dtp_input_date.Text,
                        txt_input_cd.Text,
                        txtFloorPlanNm.Text,
                        ip,
                        img_size,
                        Common.p_strStaffNo,
                        txt_comment.Text);

                    if (rsNum == 0)
                    {
                        MessageBox.Show("성공적으로 수정하였습니다.");
                        grid_list();
                    }
                    else if (rsNum == 1)
                    {
                        MessageBox.Show("저장에 실패하였습니다.");
                    }
                    else
                    {
                        MessageBox.Show("Exception 에러 ");
                    }
                }

            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            resetSetting();
        }

        private void resetSetting()
        {
            dtp_input_date.Text = DateTime.Now.ToString("yyyy-MM-dd");
            dtp_input_date.Enabled = true;
            dtp_start.Text =  DateTime.Today.AddMonths(-1).ToString("yyyy-MM-dd");
            dtp_end.Text = DateTime.Now.ToString("yyyy-MM-dd");
            txt_input_cd.Text = "INPUT_CD";
            txtFloorPlanNm.Text = "";
            txt_comment.Text = "";
            lbl_gbn.Text = "1";
            pictureBox1.BackgroundImage = null;
            img_size = 0;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grid_list()
        {
            DataTable dt = new DataTable();
            try
            {
                dgv_floorPlan.Rows.Clear();
                dt = wDm.floorPlanList(txt_srch.Text, dtp_start.Text, dtp_end.Text);
                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgv_floorPlan.Rows.Add();
                        dgv_floorPlan.Rows[i].Cells["INPUT_DATE"].Value = dt.Rows[i]["INPUT_DATE"].ToString();
                        dgv_floorPlan.Rows[i].Cells["INPUT_CD"].Value = dt.Rows[i]["INPUT_CD"].ToString();
                        dgv_floorPlan.Rows[i].Cells["FP_NM"].Value = dt.Rows[i]["IMG_NAME"].ToString();

                    }

                }
               
                
            }
            catch (Exception e)
            {
                MessageBox.Show("데이터가 없습니다.");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            grid_list();
        }

        private void txt_srch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(sender,e);
            }

        }

        private void dgv_floorPlan_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            lbl_gbn.Text = "0";
            dtp_input_date.Enabled = false;
            DataTable dt = new DataTable();
            try
            {
                dt = wDm.SelectFloorPlan(dgv_floorPlan.Rows[e.RowIndex].Cells["INPUT_DATE"].Value.ToString(), dgv_floorPlan.Rows[e.RowIndex].Cells["INPUT_CD"].Value.ToString());

                dtp_input_date.Text = dgv_floorPlan.Rows[e.RowIndex].Cells["INPUT_DATE"].Value.ToString();
                txt_input_cd.Text = dgv_floorPlan.Rows[e.RowIndex].Cells["INPUT_CD"].Value.ToString();
                txtFloorPlanNm.Text = dt.Rows[0]["IMG_NAME"].ToString();
                txt_comment.Text = dt.Rows[0]["COMMENT"].ToString();
                img_size = int.Parse(dt.Rows[0]["IMG_PATH"].ToString());
                
                if (dt.Rows[0]["IMG"] != null && !dt.Rows[0]["IMG"].ToString().Equals(""))
                        {
                            ip = (byte[])dt.Rows[0]["IMG"];

                            Image img = null;
                           
                            if (ip.Length < 2)
                            {
                                pictureBox1.BackgroundImage = null;
                               
                            }
                            else
                            {
                                Image a = ByteImg(ip);

                                img = ComInfo.pic_resize_logic(pictureBox1, a);
                                pictureBox1.BackgroundImage = img;
                            }
                          
                        }

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public Image ByteImg(byte[] b)
        {
            ImageConverter imgcvt = new ImageConverter();
            Image img = (Image)imgcvt.ConvertFrom(b);
            return img;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (!txt_input_cd.Text.Equals("INPUT_CD"))
                {
                    int rsNum = wDm.floorPlanDelete(dtp_input_date.Text,txt_input_cd.Text);

                    if (rsNum == 0)
                    {
                        MessageBox.Show("성공적으로 삭제하였습니다.");
                        grid_list();
                        resetSetting();
                    }
                    else if (rsNum == 1)
                    {
                        MessageBox.Show("삭제에 실패하였습니다.");
                    }
                    else
                    {
                        MessageBox.Show("Exception 에러 ");
                    }
                }
                else
                {
                    MessageBox.Show("삭제할 도면을 선택하세요.");
                    return;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString() + "Exception 에러");
            }
        }

        private void lbl_gbn_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbl_title_Click(object sender, EventArgs e)
        {

        }

        private void dgv_floorPlan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void txt_input_cd_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txt_comment_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtp_input_date_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lbl_stor_nm2_Click(object sender, EventArgs e)
        {

        }

        private void txtFloorPlanNm_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dtp_end_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtp_start_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txt_srch_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
