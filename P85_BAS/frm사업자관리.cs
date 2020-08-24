using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MES.CLS;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Windows.Media.Imaging;


namespace MES.P85_BAS
{
    public partial class frm사업자관리 : Form
    {
        Image image;
        Image bannerimage;
        Image 직인image;
        string path;
        string bannerPath;
        string 직인Path;

        public static bool p_IsAuth = true;    // 열람권한
        public static bool p_Isrgstr = true;    //등록/수정 권한
        wnDm wnDm = new wnDm();
        public static bool p_Isdel = true;    // 삭제 권한
        string saup_no = "";
        public frm사업자관리()
        {
            InitializeComponent();
        }

        private void frm사업자관리_Load(object sender, EventArgs e)
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
            saup_no = Common.p_saupNo;
            txt_saup_no.Text = saup_no.Substring(0, 3) + "-" + saup_no.Substring(3,2)+"-"+saup_no.Substring(5,5);
            saupSetting();
        }

        #region button logic

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (p_Isrgstr)
            {
                if (txt_saup_nm.Text.ToString().Equals(""))
                {
                    MessageBox.Show("사업자명을 입력하시기 바랍니다.");
                }

                txt_flagship.Text = txt_flagship.Text ?? "";

                byte[] saup_img;
                int saup_img_size = 0;
                if (image != null)
                {
                    saup_img = Converter_Image_to_Byte(image);
                    saup_img_size = saup_img.Length;
                }
                else
                {
                    saup_img = null;
                    saup_img_size = 0;
                }

                byte[] banner_img;
                int saup_banner_size = 0;
                if (bannerimage != null)
                {
                    banner_img = Converter_Image_to_Byte(bannerimage);
                    saup_banner_size = banner_img.Length;
                }
                else
                {
                    banner_img = null;
                    saup_banner_size = 0;
                }

                byte[] 직인_img;
                int saup_직인_size = 0;
                if (직인image != null)
                {
                    직인_img = Converter_Image_to_Byte(직인image);
                    saup_직인_size = 직인_img.Length;
                }
                else
                {
                    직인_img = null;
                    saup_직인_size = 0;
                }

                wnDm wDm = new wnDm();
                int rsNum = wDm.updateSaup(
                            saup_no,
                            txt_saup_nm.Text.ToString(),
                            txt_corporate.Text.ToString(),
                            txt_uptae.Text.ToString(),
                            txt_jongmok.Text.ToString(),
                            txt_open_date.Text.ToString(),
                            txt_post_no.Text.ToString(),
                            txt_addr.Text.ToString(),
                            txt_addr2.Text.ToString(),
                            txt_comp_phone.Text.ToString(),
                            txt_fax.Text.ToString(),
                            txt_mg_email.Text.ToString(),
                            txt_mg_phone.Text.ToString(),
                            txt_homepage.Text.ToString(),
                            saup_img,
                            saup_img_size,
                            banner_img,
                            saup_banner_size,
                            직인_img,
                            saup_직인_size,
                            Common.p_strCompNm,
                            txt_owner_nm.Text.ToString(),
                            txt_account.Text.ToString(),
                            txt_account2.Text.ToString(),
                            txt_flagship.Text.ToString()
                            );

                if (rsNum == 0)
                {
                    MessageBox.Show("성공적으로 등록하였습니다.\n이미지파일은 프로그램 재시작 후 적용됩니다.");
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
            else
            {
                MessageBox.Show("권한이 없습니다.");
            }
        }

        public byte[] Converter_Image_to_Byte(Image x)
        {
            ImageConverter _imageConverter = new ImageConverter();
            byte[] xByte = (byte[])_imageConverter.ConvertTo(x, typeof(byte[]));
            return xByte;
        }

        private void btn_file_up_Click(object sender, EventArgs e)
        {
            pic_logic(pic_exam);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion button logic

        #region common logic
        private void saupSetting() 
        {
            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = new DataTable();
                dt = wDm.fn_Saup_List(saup_no);

                if (dt != null && dt.Rows.Count > 0)
                {
                    txt_saup_nm.Text = dt.Rows[0]["COMPANY_NM"].ToString();
                    txt_corporate.Text = dt.Rows[0]["CORPORATE_NO"].ToString();
                    txt_uptae.Text = dt.Rows[0]["UPTAE"].ToString();
                    txt_jongmok.Text = dt.Rows[0]["JONGMOK"].ToString();
                    txt_post_no.Text = dt.Rows[0]["POST_NO"].ToString();
                    txt_addr.Text = dt.Rows[0]["ADDR"].ToString();
                    txt_addr2.Text = dt.Rows[0]["ADDR2"].ToString();
                    txt_open_date.Text = dt.Rows[0]["OPEN_DATE"].ToString();
                    txt_comp_phone.Text = dt.Rows[0]["COMP_PHONE"].ToString();
                    txt_fax.Text = dt.Rows[0]["FAX"].ToString();
                    txt_mg_email.Text = dt.Rows[0]["MANAGER_EMAIL"].ToString();
                    txt_mg_phone.Text = dt.Rows[0]["MANAGER_PHONE"].ToString();
                    txt_homepage.Text = dt.Rows[0]["HOMEPAGE"].ToString();
                    txt_owner_nm.Text = dt.Rows[0]["CEO_NAME"].ToString();
                    txt_account.Text = dt.Rows[0]["ACCOUNT"].ToString();
                    txt_account2.Text = dt.Rows[0]["ACCOUNT2"].ToString();
                    txt_flagship.Text = dt.Rows[0]["FLAGSHIP"].ToString();
                    if (int.Parse(dt.Rows[0]["LOGO_SIZE"].ToString()) > 0)
                    {
                        byte[] rs = (byte[])dt.Rows[0]["SAUP_LOGO"];
                        MemoryStream ms = new MemoryStream(rs);
                        Image img = Image.FromStream(ms);
                        image = img;
                        Image cus_img = ComInfo.pic_resize_logic(pic_exam, img);

                        pic_exam.BackgroundImage = cus_img;
                    }

                    if (int.Parse(dt.Rows[0]["BANNER_SIZE"].ToString()) > 0)
                    {
                        byte[] rs = (byte[])dt.Rows[0]["SAUP_BANNER"];
                        MemoryStream ms = new MemoryStream(rs);
                        Image img = Image.FromStream(ms);
                        bannerimage = img;
                        Image cus_img = ComInfo.pic_resize_logic(pic_banner, img);

                        pic_banner.BackgroundImage = cus_img;
                    }

                    if (int.Parse(dt.Rows[0]["SEAL_SIZE"].ToString()) > 0)
                    {
                        byte[] rs = (byte[])dt.Rows[0]["SAUP_SEAL"];
                        MemoryStream ms = new MemoryStream(rs);
                        Image img = Image.FromStream(ms);
                        직인image = img;
                        Image cus_img = ComInfo.pic_resize_logic(pic_직인, img);

                        pic_직인.BackgroundImage = cus_img;
                    }


                }
                else 
                {
                    txt_saup_nm.Text = Common.p_strCompNm;
                }
            }
            catch (Exception e) 
            {
                Popup.pop오류리포트 msg = new Popup.pop오류리포트(e.Message + " - " + e.ToString());
                msg.ShowDialog();
            }
        }

        private void pic_logic(PictureBox pic)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = "";
            ofd.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //이미지 
                image = Image.FromFile(ofd.FileName);
                //이미지 경로 
                path = ofd.FileName;
                /* 이미지 리사이즈 */
                Image cus_img = ComInfo.pic_resize_logic(pic, image);
                //픽쳐박스에 이미지를 띄운다
                pic.BackgroundImage = cus_img;
            }
            else 
            {
                pic.BackgroundImage = null;
                image = null;

            }
        }

        private void pic_logic_직인(PictureBox pic)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = "";
            ofd.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //이미지 
                직인image = Image.FromFile(ofd.FileName);
                //이미지 경로 
                직인Path = ofd.FileName;
                /* 이미지 리사이즈 */
                Image cus_img = ComInfo.pic_resize_logic(pic, 직인image);
                //픽쳐박스에 이미지를 띄운다
                pic.BackgroundImage = cus_img;
            }
            else
            {
                pic.BackgroundImage = null;
                직인image = null;
            }
        }

        private void pic_logic_banner(PictureBox pic)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = "";
            ofd.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //이미지 
                bannerimage = Image.FromFile(ofd.FileName);
                //이미지 경로 
                bannerPath = ofd.FileName;
                /* 이미지 리사이즈 */
                Image cus_img = ComInfo.pic_resize_logic(pic, bannerimage);
                //픽쳐박스에 이미지를 띄운다
                pic.BackgroundImage = cus_img;
            }
            else
            {
                pic.BackgroundImage = null;
                bannerimage = null;
            }
        }

        

        #endregion common logic

        private void btn우편번호_Click(object sender, EventArgs e)
        {
            MES.Popup.pop우편번호검색 pop우편검색 = new MES.Popup.pop우편번호검색();
            pop우편검색.ShowDialog();
            Debug.WriteLine(pop우편검색.a + pop우편검색.b);

            txt_post_no.Text = pop우편검색.b;
            txt_addr.Text = pop우편검색.a;

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
                    break;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
            return true;
        }

        private void btn_delLogo_Click(object sender, EventArgs e)
        {
            pic_exam.BackgroundImage = null;
            image = null;
        }

        private void btn_banner_up_Click(object sender, EventArgs e)
        {
            pic_logic_banner(pic_banner);
        }

        private void btn_직인_up_Click(object sender, EventArgs e)
        {
            pic_logic_직인(pic_직인);
        }

        private void btn_del_banner_Click(object sender, EventArgs e)
        {
            pic_banner.BackgroundImage = null;
            bannerimage = null;

        }

        private void btn_직인_del_Click(object sender, EventArgs e)
        {
            pic_직인.BackgroundImage = null;
            직인image = null;

        }




    }
}
