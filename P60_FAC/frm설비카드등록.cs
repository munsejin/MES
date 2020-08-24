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

namespace MES.P60_FAC
{
    public partial class frm설비카드등록 : Form
    {
        public static bool p_IsAuth = true;    // 열람권한
        public static bool p_Isrgstr = true;    //등록/수정 권한
        public static bool p_Isdel = true;    // 삭제 권한
        wnDm wnDm = new wnDm();

        private wnGConstant wConst = new wnGConstant();
        private ComInfo comInfo = new ComInfo();
        Image image;
        string path;
        private bool[] right = new bool[2];

        public frm설비카드등록()
        {
            InitializeComponent();
            init_ComboBox();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void init_ComboBox()
        {
            ComInfo comInfo = new ComInfo();
            string sqlQuery = "";

            cmb_mainten.ValueMember = "코드";
            cmb_mainten.DisplayMember = "명칭";
            sqlQuery = comInfo.queryCode("800");
            wConst.ComboBox_Read_Blank(cmb_mainten, sqlQuery);

            cmb_dept.ValueMember = "코드";
            cmb_dept.DisplayMember = "명칭";
            sqlQuery = comInfo.queryDept();
            wConst.ComboBox_Read_Blank(cmb_dept, sqlQuery);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Popup.pop설비검색 frm = new Popup.pop설비검색();

            //frm.sUsedYN = sUsedYN;
            frm.ShowDialog();

            if (frm.dt.Rows.Count > 0)
            {
                DataTable dt = new DataTable();
                dt = frm.dt;
                btnDelete.Enabled = true;
                lbl_fac_gbn.Text = "1";
                //txt_fac_cd.Enabled = false;
                //txt_fac_cd.Text = dt.Rows[0]["FAC_CD"].ToString();
                //txt_fac_nm.Text = dt.Rows[0]["FAC_NM"].ToString();
                //txt_model_nm.Text = dt.Rows[0]["MODEL_NM"].ToString();
                //txt_spec.Text = dt.Rows[0]["SPEC"].ToString();
                //txt_manu_comp.Text = dt.Rows[0]["MANU_COMPANY"].ToString();
                //acq_date.Text = dt.Rows[0]["ACQ_DATE"].ToString();
                //txt_acq_price.Text = dt.Rows[0]["ACQ_PRICE"].ToString();
                //cmb_dept.SelectedValue = dt.Rows[0]["DEPT_CD"].ToString();
                //txt_used.Text = dt.Rows[0]["USED"].ToString();
                //txt_pro_capa.Text = dt.Rows[0]["PRO_CAPA"].ToString();
                //txt_power_num.Text = dt.Rows[0]["POWER_NUMBER"].ToString();
                //cmb_mainten.SelectedValue = dt.Rows[0]["MAINTEN_CLASS"].ToString();
            }
            else 
            {

            }

            frm.Dispose();
            frm = null;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            resetSetting();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (right[0])
            {
                Metal_Logic();
                MetalLoad();
            }

          
        }

        private void MetalLoad()
        {

            btnDelete.Enabled = false;
 
   
            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = null;
                dt = wDm.Fac_Grid_List();

                this.dgvMetalList.RowCount = dt.Rows.Count;
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgvMetalList.Rows[i].Cells["FAC_CD"].Value = dt.Rows[i]["FAC_CD"].ToString();
                        dgvMetalList.Rows[i].Cells["FAC_NM"].Value = dt.Rows[i]["FAC_NM"].ToString();
                        dgvMetalList.Rows[i].Cells["MODEL_NM"].Value = dt.Rows[i]["MODEL_NM"].ToString();
                        dgvMetalList.Rows[i].Cells["SPEC"].Value = dt.Rows[i]["SPEC"].ToString();
                        dgvMetalList.Rows[i].Cells["MANU_COMPANY"].Value = dt.Rows[i]["MANU_COMPANY"].ToString();
                        dgvMetalList.Rows[i].Cells["ACQ_PRICE"].Value = dt.Rows[i]["ACQ_PRICE"].ToString();
                        dgvMetalList.Rows[i].Cells["ACQ_DATE"].Value = dt.Rows[i]["ACQ_DATE"].ToString();
                        dgvMetalList.Rows[i].Cells["PRO_CAPA"].Value = dt.Rows[i]["PRODUCE_AMT"].ToString();
                        dgvMetalList.Rows[i].Cells["MAINTEN_CLASS"].Value = dt.Rows[i]["MAINTEN_CLASS"].ToString();
                        dgvMetalList.Rows[i].Cells["COMMENT"].Value = dt.Rows[i]["COMMENT"].ToString();
                        dgvMetalList.Rows[i].Cells["CHECK_CYCLE"].Value = dt.Rows[i]["CHECK_CYCLE"].ToString();
                        dgvMetalList.Rows[i].Cells["POWER_NUMBER"].Value = dt.Rows[i]["POWER_NUMBER"].ToString();
                        dgvMetalList.Rows[i].Cells["AMOUNT"].Value = dt.Rows[i]["AMOUNT"].ToString();
                       
                        dgvMetalList.Rows[i].Cells["PRODUCE_AMT"].Value = dt.Rows[i]["PRODUCE_AMT"].ToString();
                        
                       
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

        byte[] flow_img;
        int flow_img_size = 0;
        private void Metal_Logic()
        {
            try
            {
                if (txt_faccd.Text.ToString().Equals(""))
                {
                    MessageBox.Show("관리번호를 입력하시기 바랍니다.");
                    return;
                }

                if (txt_facnm.Text.ToString().Equals(""))
                {
                    MessageBox.Show("제품명을 입력하시기 바랍니다.");
                    return;
                }

                if (txt_sn.Text.ToString().Equals(""))
                {
                    MessageBox.Show("장비S/N을 입력하시기 바랍니다.");
                    return;
                }

               
              
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


                if (txt_price.Text.ToString()==""|txt_price.Text.ToString()==null)
                {
                    txt_price.Text = "0";
                }

                if (txt_amount.Text.ToString() == "" | txt_amount.Text.ToString() == null)
                {
                    txt_amount.Text = "0";
                }

                if (txt_faccd.Enabled)
                {
                    wnDm wDm = new wnDm();
                    int rsNum = wDm.InsertFac(
                                      txt_faccd.Text.ToString()
                                    , txt_facnm.Text.ToString()
                                    , txt_sn.Text.ToString()
                                    , txt_spec.Text.ToString()
                                    , int.Parse(txt_amount.Text.ToString().Replace(",", ""))
                                    , dtp_makedate.Text.ToString()
                                    , dtp_buydate.Text.ToString()
                                    , int.Parse(txt_price.Text.ToString().Replace(",",""))                                   
                                    , txt_makecust.Text.ToString()
                                    , txt_comment.Text.ToString()
                                    , txt생산능력.Text.ToString().Replace(",", "")
                                    , cmb_mainten.SelectedValue.ToString().Replace(",", "")
                                    , flow_img
                                    , flow_img_size
                                    , txt마력.Text.ToString().Replace(",", "")
                                    , txt점검주기.Text.ToString().Replace(",", "")
                                    , cmb_dept.SelectedValue.ToString()
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
                    if (!right[1])
                    {
                        MessageBox.Show("권한이없습니다.");
                        return;
                    }
                    wnDm wDm = new wnDm();
                    int rsNum = wDm.UpdateFac(
                                      txt_faccd.Text.ToString()
                                    , txt_facnm.Text.ToString()
                                    , txt_sn.Text.ToString()
                                    , txt_spec.Text.ToString()
                                    , int.Parse(txt_amount.Text.ToString())
                                    , dtp_makedate.Text.ToString()
                                    , dtp_buydate.Text.ToString()
                                    , int.Parse(txt_price.Text.ToString())
                                    , txt_makecust.Text.ToString()
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

            Image Image = null;
            txt_faccd.Enabled = true;

            txt_faccd.Text = "";
            txt_facnm.Text = "";
            txt_sn.Text = "";
            txt_spec.Text = "";
            txt_amount.Text = "0";
            dtp_makedate.Text = DateTime.Now.ToString();
            dtp_buydate.Text = DateTime.Now.ToString();
            txt_price.Text = "0";
            txt_makecust.Text = "";
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (right[1])
            {
                wnDm wDm = new wnDm();
                int rsNum = wDm.DeleteFac(txt_faccd.Text.ToString());
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
            else
            {
                MessageBox.Show("권한이 없습니다.");
                return;
            }
        }

        private void frm설비카드등록_Load(object sender, EventArgs e)
        {
            MetalLoad();
               lbl_title.Tag = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[0] + "$" + wnDm.fn_TitleName(this.Name.ToString()).Split('$')[1]; lbl_title.Text = wnDm.fn_TitleName(this.Name.ToString()).Split('$')[2];
               right = wConst.btnRight(lbl_title.Tag.ToString());

        }

        private void dgvMetalList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnNew.PerformClick();
            
            if (e.RowIndex > -1)
            {                            
                txt_faccd.Text = dgvMetalList.Rows[e.RowIndex].Cells["FAC_CD"].Value.ToString();
                txt_facnm.Text = dgvMetalList.Rows[e.RowIndex].Cells["FAC_NM"].Value.ToString();
                txt_sn.Text = dgvMetalList.Rows[e.RowIndex].Cells["MODEL_NM"].Value.ToString();
                txt_spec.Text = dgvMetalList.Rows[e.RowIndex].Cells["SPEC"].Value.ToString();
                txt_amount.Text = dgvMetalList.Rows[e.RowIndex].Cells["PRO_CAPA"].Value.ToString();
                dtp_makedate.Text = dgvMetalList.Rows[e.RowIndex].Cells["ACQ_DATE"].Value.ToString();
                cmb_mainten.SelectedValue = dgvMetalList.Rows[e.RowIndex].Cells["MAINTEN_CLASS"].Value.ToString();
                txt_price.Text = dgvMetalList.Rows[e.RowIndex].Cells["ACQ_PRICE"].Value.ToString();
                txt_makecust.Text = dgvMetalList.Rows[e.RowIndex].Cells["MANU_COMPANY"].Value.ToString();
                txt_comment.Text = dgvMetalList.Rows[e.RowIndex].Cells["COMMENT"].Value.ToString();
                txt마력.Text = dgvMetalList.Rows[e.RowIndex].Cells["POWER_NUMBER"].Value.ToString();
                txt생산능력.Text = dgvMetalList.Rows[e.RowIndex].Cells["PRODUCE_AMT"].Value.ToString();
                txt점검주기.Text = dgvMetalList.Rows[e.RowIndex].Cells["CHECK_CYCLE"].Value.ToString();



               

                txt_faccd.Enabled = false;
                dgvMetalList.Rows.Clear();

                MetalLoad();

                btnDelete.Enabled = true;

                //pic_fac_img.BackgroundImage = null;
            }
        }


        private byte[] StringToByte(string str) { byte[] StrByte = Encoding.UTF8.GetBytes(str); return StrByte; }


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
