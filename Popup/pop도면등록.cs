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
using System.IO;

namespace MES.Popup
{
    public partial class pop도면등록 : Form
    {
        private Image image;
        private Image cus_img;
        private int cnt = 0;
        private string path;
        public Image Main_image;
        private string pic_name;
        public DataGridView del_dgv_picture = new DataGridView();
        public string lbl_item_gbn = "";

        wnDm wDm = new wnDm();

        public pop도면등록()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgv_fac_picture_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.ColumnIndex == 2)
            {
                ofd.Filter = "*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    //이미지 
                    image = Image.FromFile(ofd.FileName);
                    //이미지 경로 
                    path = ofd.FileName;
                    pic_name = Path.GetFileNameWithoutExtension(ofd.FileName);
                    /* 이미지 리사이즈 */
                    Image cus_img = pic_resize_logic(dgv_picture, image);

                    byte[] img;
                    int img_size = 0;
                    if (path != null && path != "")
                    {
                        dgv_picture.Rows[e.RowIndex].Height = 194;
                        dgv_picture.Columns[e.ColumnIndex - 1].Width = 300;
                        dgv_picture.Rows[e.RowIndex].Cells["PICTURE"].Value = cus_img;
                        dgv_picture.Rows[e.RowIndex].Cells["IMG_NAME"].Value = pic_name;

                       
                        img = ComInfo.GetImage(path);
                        img_size = img.Length;

                       // MessageBox.Show(img_size.ToString());
                        dgv_picture.Rows[e.RowIndex].Cells["IMG_SIZE"].Value = img_size;
                        dgv_picture.Rows[e.RowIndex].Cells["PIC_PATH"].Value = img;
                    }
                    else
                    {
                        dgv_picture.Rows[e.RowIndex].Cells["PICTURE"].Value = null;
                        img_size = 0;
                    }



                }

            }
        }

        private Image pic_resize_logic(DataGridView dgv_fac_picture, Image image)
        {
            cus_img = new Bitmap(300, 194, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            using (Graphics g = Graphics.FromImage(cus_img))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.DrawImage(image,
                    new RectangleF(0, 0, 300, 194),
                    new RectangleF(new PointF(0, 0), image.Size), GraphicsUnit.Pixel);
            }
            return cus_img;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            picSave_logic(dgv_picture);

            this.Close();
        }
        private void picSave_logic(DataGridView dgv_picture)
        {

            if (dgv_picture.Rows.Count > 0)
            {
                int cnt = 0;
                int grid_cnt = dgv_picture.Rows.Count;

                for (int i = 0; i < grid_cnt; i++)
                {
                    //마지막 행에 설비사진이 없을때 가 없을 경우 제거
                    Image fac_pic = (Image)dgv_picture.Rows[i - cnt].Cells["PICTURE"].Value;
                    if (fac_pic == null)
                    {
                        dgv_picture.Rows.RemoveAt(i - cnt);
                        cnt++;
                    }
                }
            }
            else if (dgv_picture.Rows.Count == 0)
            {
                //MessageBox.Show("도면을 하나 이상 등록해주세요.");
                //return;
            }

        }

        private void btn_plus_Click(object sender, EventArgs e)
        {
            dgv_picture.Rows.Add();
            //dgv_picture.CurrentCell = dgv_picture[1, dgv_picture.Rows.Count - 1];
        }

        private void btn_minus_Click(object sender, EventArgs e)
        {
            minus_logic(dgv_picture);
        }

        private void minus_logic(DataGridView dgv)
        {

            try
            {
                if (dgv.Rows.Count > 0)
                {
                    //MessageBox.Show(dgv_picture.Rows[0].Cells["SEQ"].Value.ToString());
                    if (dgv.SelectedRows[0].Cells["SEQ"].Value != null && dgv.SelectedRows[0].Cells["SEQ"].Value.ToString() != "")
                    {
                        del_dgv_picture.Rows.Add();
                        del_dgv_picture.Rows[del_dgv_picture.Rows.Count - 1].Cells["INPUT_CD"].Value = dgv.SelectedRows[0].Cells["SEQ"].Value;
                        del_dgv_picture.Rows[del_dgv_picture.Rows.Count - 1].Cells["INPUT_DATE"].Value = dgv.SelectedRows[0].Cells["INPUT_DATE"].Value;
                    }
                    dgv.Rows.RemoveAt(dgv.SelectedRows[0].Index);
                }

                if (dgv.Rows.Count > 0)
                {
                    dgv.CurrentCell = dgv[1, dgv.Rows.Count - 1];
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.ToString());
            }
           
        }

        private void pop도면등록_Load(object sender, EventArgs e)
        {

            del_dgv_picture.AllowUserToAddRows = false;
            del_dgv_picture.Columns.Add("INPUT_DATE", "INPUT_DATE");
            del_dgv_picture.Columns.Add("INPUT_CD", "INPUT_CD");

            if (lbl_item_gbn == "1" && del_dgv_picture.Rows.Count == 0) { selectLogic(); };
        }
        private void selectLogic()
        {
            try
            {

                DataTable dt = null;
                dt = wDm.SelectFloorPlan(item_cd.Text);

                if (dt != null && dt.Rows.Count > 0)
                {
                    this.dgv_picture.RowCount = dt.Rows.Count;

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgv_picture.Rows[i].Cells["IMG_NAME"].Value = dt.Rows[i]["IMG_NAME"].ToString();
                        dgv_picture.Rows[i].Cells["SEQ"].Value = dt.Rows[i]["INPUT_CD"].ToString();
                        dgv_picture.Rows[i].Cells["INPUT_DATE"].Value = dt.Rows[i]["INPUT_DATE"].ToString();
                        dgv_picture.Rows[i].Cells[2].Value = "사진추가";


                        byte[] ip = (byte[])dt.Rows[i]["IMG"];
                        Image a = ByteImg(ip);
                        Image cus_img = pic_resize_logic(dgv_picture, a);
                        dgv_picture.Rows[i].Height = 194;
                        dgv_picture.Columns[1].Width = 300;


                        //dgv_picture.Rows[i].Cells["IMG_SIZE"].Value = "0";
                        dgv_picture.Rows[i].Cells["PICTURE"].Value = cus_img;
                        dgv_picture.Rows[i].Cells["IMG_SIZE"].Value = dt.Rows[i]["IMG_PATH"].ToString();
                        dgv_picture.Rows[i].Cells["PIC_PATH"].Value = ip;

                        //dgv_picture.Rows[e.RowIndex].Cells["PIC_PATH"].Value = img;
                    }

                }

                else
                {
                    //MessageBox.Show("데이터가 없습니다");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public Image ByteImg(byte[] b)
        {
            ImageConverter imgcvt = new ImageConverter();
            Image img = (Image)imgcvt.ConvertFrom(b);
            return img;
        }

        
    }
}
