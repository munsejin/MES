using MES.CLS;
using MES.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MES.H30_납품관리
{
    public partial class frm매출관리 : Form
    {
        private wnGConstant wConst = new wnGConstant();

        public static bool p_IsAuth = true;    // 열람권한
        public static bool p_Isrgstr = true;    //등록/수정 권한
        public static bool p_Isdel = true;    // 삭제 권한
        wnDm wnDm = new wnDm();
        String str거래처코드 = "";
        String str계산서발행 = "Y";
        String str주문일자 = "";
        String str주문번호 = "";

        String str배송일자 = "";
        String str배송번호 = "";


        public frm매출관리()
        {
            InitializeComponent();
        }

        public void bind주문내역()
        {
            DataTable dt = wnDm.fn_매출주문_List("");

            //sb.AppendLine(" select ");
            //sb.AppendLine(" A.ORD_DATE ");
            //sb.AppendLine(" ,A.ORD_NUM ");
            //sb.AppendLine(" ,A.ORD_INPUT ");
            //sb.AppendLine(" ,A.ORD_TIME");
            //sb.AppendLine(" ,A.STAFF_CD ");
            //sb.AppendLine(",C.STAFF_NM ");
            //sb.AppendLine(" ,A.CUST_CD ");
            //sb.AppendLine(" ,B.CUST_NM ");
            //sb.AppendLine(" ,A.DELIVERY_CD");
            //sb.AppendLine(" ,D.STAFF_NM as DELIVERY_NM");
            //sb.AppendLine(" ,A.STORAGE_CD ");
            //sb.AppendLine(" ,f.STORAGE_NM ");
            //sb.AppendLine("  ,A.VAT_CD");
            //sb.AppendLine("  ,G.S_CODE_NM as VAT_NM");
            //sb.AppendLine("  ,A.COMMENT");
            //sb.AppendLine("   ,A.SALE_STATE");
            //sb.AppendLine("    ,H.S_CODE_NM as SALE_STATE_NM");
            dgv주문내역.Rows.Clear();
            if (dt.Rows.Count>0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dgv주문내역.Rows.Add();
                    dgv주문내역.Rows[i].Cells["ODR_DATE"].Value = dt.Rows[i]["ORD_DATE"].ToString();
                    dgv주문내역.Rows[i].Cells["ODR_CD"].Value = dt.Rows[i]["ORD_NUM"].ToString();
                    dgv주문내역.Rows[i].Cells["O전표상태"].Value = dt.Rows[i]["SALE_STATE_NM"].ToString();
                    dgv주문내역.Rows[i].Cells["거래처"].Value = dt.Rows[i]["CUST_NM"].ToString();
                    dgv주문내역.Rows[i].Cells["거래처코드"].Value = dt.Rows[i]["CUST_CD"].ToString();
                    dgv주문내역.Rows[i].Cells["거래처코드"].Value = dt.Rows[i]["CUST_CD"].ToString();
                    dgv주문내역.Rows[i].Cells["O_배송사원"].Value = dt.Rows[i]["DELIVERY_NM"].ToString();
                    dgv주문내역.Rows[i].Cells["O_전표상태코드"].Value = dt.Rows[i]["SALE_STATE"].ToString();
                    dgv주문내역.Rows[i].Cells["O_창고코드"].Value = dt.Rows[i]["STORAGE_CD"].ToString();
                    dgv주문내역.Rows[i].Cells["O_창고"].Value = dt.Rows[i]["STORAGE_NM"].ToString();
                    dgv주문내역.Rows[i].Cells["부가세"].Value = dt.Rows[i]["VAT_NM"].ToString();
                    dgv주문내역.Rows[i].Cells["부가세코드"].Value = dt.Rows[i]["VAT_CD"].ToString();
                    dgv주문내역.Rows[i].Cells["배송일자"].Value = dt.Rows[i]["DELIVERY_DATE"].ToString();
                    dgv주문내역.Rows[i].Cells["배송사원코드"].Value = dt.Rows[i]["DELIVERY_STAFF_CD"].ToString();

                    dgv주문내역.Rows[i].Cells["배송코드"].Value = dt.Rows[i]["DELIVERY_CD"].ToString();
                }
            }
        }
        Button[] Txtbtn = new Button[2];

        public void addButton(conTextBox TextBox, int type)
        {
            Txtbtn[type] = new Button();
            TextBox.Controls.Add(Txtbtn[type]);
            Txtbtn[type].FlatStyle = FlatStyle.Flat;
            Txtbtn[type].FlatAppearance.BorderSize = 0;
            Txtbtn[type].FlatAppearance.MouseDownBackColor = Color.Transparent;
            Txtbtn[type].SetBounds(TextBox.Size.Width - 19, 1, 18, TextBox.Size.Height - 2);
            Txtbtn[type].Text = "▼";
            Txtbtn[type].TabStop = false;
            Txtbtn[type].Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 4, FontStyle.Bold);

            switch (type)
            {
                case 0:
                    Txtbtn[type].Click += new EventHandler(btnCustSrch_Click);

                    break;
               

                default:
                    break;
            }
            Txtbtn[type].Show();
        }


        //최초 실행 
        private void frm매출관리_Load(object sender, EventArgs e)
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
            start_date.Value = DateTime.Now.AddDays(-7);
            end_date.Value = DateTime.Now;
            txt시간.Text = DateTime.Now.ToString("HHmmss");
            addButton(txt_cust_nm, 0);
            init_ComboBox();
            resetting();
            bind주문내역();
            bind_dgv매출();

        }




        /// <summary>
        /// 거래처 검색하는 메소드  
        /// </summary>
        /// <param name="sender">텍스트박스 안에 콤보박스처럼 생긴 </param>
        /// <param name="e">클릭시 </param>
        private void btnCustSrch_Click(object sender, EventArgs e)
        {
            Popup.pop거래처검색 거래처검색 = new Popup.pop거래처검색();
            거래처검색.ShowDialog();
            str거래처코드 = 거래처검색.sCode;
           txt_cust_nm.Text= 거래처검색.sName;
        }

        private void txt_cust_nm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                Txtbtn[0].PerformClick();
            }
        }

        private void init_ComboBox()
        {
            ComInfo comInfo = new ComInfo();
            string sqlQuery = "";


            //tax
            cbo부가세.ValueMember = "코드";
            cbo부가세.DisplayMember = "명칭";
            sqlQuery = comInfo.queryTax();
            wConst.ComboBox_Read_NoBlank(cbo부가세, sqlQuery);




            ////배송사원
            //cbo배송사원.ValueMember = "코드";
            //cbo배송사원.DisplayMember = "명칭";
            //sqlQuery = comInfo.queryStaff();
            //wConst.ComboBox_Read_NoBlank(cbo배송사원, sqlQuery);


            //창고
            cbo창고.ValueMember = "코드";
            cbo창고.DisplayMember = "명칭";
            sqlQuery = comInfo.queryStorage();
            wConst.ComboBox_Read_NoBlank(cbo창고, sqlQuery);


            //담당사원
            cbo담당사원.ValueMember = "코드";
            cbo담당사원.DisplayMember = "명칭";
            sqlQuery = comInfo.queryStaff();
            wConst.ComboBox_Read_NoBlank(cbo담당사원, sqlQuery);


            매출구분.DataSource = wnDm.매출구분();
            매출구분.ValueMember = "코드";
            매출구분.DisplayMember = "명칭";



            O_부가세.DataSource = wnDm.부가세구분();
            O_부가세.ValueMember = "코드";
            O_부가세.DisplayMember = "명칭";


            O_과세.DataSource = wnDm.과세구분();
            O_과세.ValueMember = "코드";
            O_과세.DisplayMember = "명칭";

            cbo전표상태.ValueMember = "코드";
            cbo전표상태.DisplayMember = "명칭";
            sqlQuery = comInfo.queryCode("640");
            wConst.ComboBox_Read_NoBlank(cbo전표상태, sqlQuery);
            
        }
       

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
        private void dgv주문내역_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {

                //dgv주문내역.Rows[i].Cells["ODR_DATE"].Value = dt.Rows[i]["ORD_DATE"].ToString();
                //dgv주문내역.Rows[i].Cells["ODR_CD"].Value = dt.Rows[i]["ORD_NUM"].ToString();
                //dgv주문내역.Rows[i].Cells["O전표상태"].Value = dt.Rows[i]["SALE_STATE_NM"].ToString();
                //dgv주문내역.Rows[i].Cells["거래처"].Value = dt.Rows[i]["CUST_NM"].ToString();
                //dgv주문내역.Rows[i].Cells["거래처코드"].Value = dt.Rows[i]["CUST_CD"].ToString();
                //dgv주문내역.Rows[i].Cells["거래처코드"].Value = dt.Rows[i]["CUST_CD"].ToString();
                //dgv주문내역.Rows[i].Cells["O_배송사원"].Value = dt.Rows[i]["DELIVERY_NM"].ToString();
                //dgv주문내역.Rows[i].Cells["O_전표상태코드"].Value = dt.Rows[i]["SALE_STATE"].ToString();
                //dgv주문내역.Rows[i].Cells["O_창고코드"].Value = dt.Rows[i]["STORAGE_CD"].ToString();
                //dgv주문내역.Rows[i].Cells["O_창고"].Value = dt.Rows[i]["STORAGE_NM"].ToString();
                //dgv주문내역.Rows[i].Cells["부가세"].Value = dt.Rows[i]["VAT_NM"].ToString();
                //dgv주문내역.Rows[i].Cells["부가세코드"].Value = dt.Rows[i]["VAT_CD"].ToString();
                
                str주문일자 = dgv주문내역.Rows[e.RowIndex].Cells["ODR_DATE"].Value.ToString();
                str주문번호 = dgv주문내역.Rows[e.RowIndex].Cells["ODR_CD"].Value.ToString();

                str배송일자 = dgv주문내역.Rows[e.RowIndex].Cells["배송일자"].Value.ToString();
                str배송번호 = dgv주문내역.Rows[e.RowIndex].Cells["배송코드"].Value.ToString();
                cbo창고.SelectedValue = dgv주문내역.Rows[e.RowIndex].Cells["O_창고코드"].Value.ToString();
              
                cbo부가세.SelectedValue = dgv주문내역.Rows[e.RowIndex].Cells["부가세코드"].Value.ToString();
                str거래처코드= dgv주문내역.Rows[e.RowIndex].Cells["거래처코드"].Value.ToString();
                txt_cust_nm.Text = dgv주문내역.Rows[e.RowIndex].Cells["거래처"].Value.ToString();
                
                dgv제품.Rows.Clear();
                DataTable dt = wnDm.fn_배송항목_List(" where A.ORD_DATE='" + dgv주문내역.Rows[e.RowIndex].Cells["ODR_DATE"].Value.ToString() + "' and ORD_NUM='" + dgv주문내역.Rows[e.RowIndex].Cells["ODR_CD"].Value.ToString() + "'");


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dgv제품.Rows.Add();
                    dgv제품.Rows[i].Cells["제품명"].Value = dt.Rows[i]["ITEM_NM"].ToString();
                    dgv제품.Rows[i].Cells["규격"].Value = dt.Rows[i]["SPEC"].ToString();
                    dgv제품.Rows[i].Cells["O_UNIT_NM"].Value = dt.Rows[i]["UNIT_NM"].ToString();
                    dgv제품.Rows[i].Cells["O_UNIT_CD"].Value = dt.Rows[i]["UNIT_CD"].ToString();
                   
                    dgv제품.Rows[i].Cells["규격"].Value = dt.Rows[i]["SPEC"].ToString();

                    dgv제품.Rows[i].Cells["O_NO"].Value = dt.Rows[i]["ORD_SEQ"].ToString();
                    dgv제품.Rows[i].Cells["O_ITEM_CD"].Value = dt.Rows[i]["ITEM_CD"].ToString();

                  
                    dgv제품.Rows[i].Cells["최종매출일"].Value = DateTime.Parse(dt.Rows[i]["LAST_DATE"].ToString());
                    dgv제품.Rows[i].Cells["비고"].Value = dt.Rows[i]["COMMENT"].ToString();
                    dgv제품.Rows[i].Cells["매출구분"].Value = dt.Rows[i]["SALE_GB"].ToString();
                    dgv제품.Rows[i].Cells["O_주문번호"].Value = dt.Rows[i]["ORD_NUM"].ToString();
                    dgv제품.Rows[i].Cells["O_주문일자"].Value = dt.Rows[i]["ORD_DATE"].ToString();



                    dgv제품.Rows[i].Cells["수량"].Value = (decimal.Parse(dt.Rows[i]["ORD_QTY"].ToString())).ToString("#,0.######");
                    dgv제품.Rows[i].Cells["단가"].Value = (decimal.Parse(dt.Rows[i]["ORD_PRICE"].ToString())).ToString("#,0.######");
                    dgv제품.Rows[i].Cells["금액"].Value = (decimal.Parse(dt.Rows[i]["ORD_AMT"].ToString())).ToString("#,0.######");
                    dgv제품.Rows[i].Cells["O_부가세"].Value = "1";
                    dgv제품.Rows[i].Cells["O_과세"].Value = "1";
                }
            }
        }

        private void rdo계산서발행_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo계산서발행.Checked)
            {
                lbl발행일자.Visible = true;
                dtp발행일자.Visible = true;
                str계산서발행 = "Y";
            }
        }

        private void rdo계산서미발행_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo계산서미발행.Checked)
            {
                lbl발행일자.Visible = false;
                dtp발행일자.Visible = false;
                str계산서발행 = "N";

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("선택하신 정보가 저장됩니다", "YesOrNo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (p_Isrgstr)
                {
                    매출등록저장();
                    bind주문내역();
                    bind_dgv매출();
                }
                else
                {
                    MessageBox.Show("권한이 없습니다.");
                }
            }
            else
            {
            }
        }
        private void 매출등록저장()
        {
            txt시간.Text = DateTime.Now.ToString("HHmmss");
            if (lbl_out_gbn.Text == "")
            {
                try
                {
                    if (거래처코드.ToString().Equals(""))
                    {
                        MessageBox.Show("거래처를 선택하시기 바랍니다.");
                        return;
                    }








                    wnDm wDm = new wnDm();
                    int rsNum = wDm.insert매출등록(
                       txt_매출일자.Value.ToString().Substring(0, 10)
                      , str거래처코드
                      , cbo담당사원.SelectedValue.ToString()
                  
                    , cbo창고.SelectedValue.ToString()
                    , cbo부가세.SelectedValue.ToString()
                    , txt_comment.Text
                    , str계산서발행
                    , dtp발행일자.Value.ToString().Substring(0, 10)
                    , cbo전표상태.SelectedValue.ToString()
                    ,str주문일자
                    ,str주문번호
                    ,str배송일자
                    ,str배송번호
                    
                  

                    , dgv제품
                        );

                    if (rsNum == 0)
                    {

                        MessageBox.Show("성공적으로 등록하였습니다.");
                    }
                    else if (rsNum == 1)
                        MessageBox.Show("저장에 실패하였습니다");
                    else if (rsNum == 2)
                        MessageBox.Show("SQL COMMAND 에러");
                    else if (rsNum == 3)
                        MessageBox.Show("기존 코드가 존재하므로 \n 다른 코드로 입력 바랍니다.");
                    else
                        MessageBox.Show("Exception 에러");


                }
                catch (Exception e)
                {
                    Popup.pop오류리포트 msg = new Popup.pop오류리포트(e.Message+" - "+e.ToString()); msg.ShowDialog();
                }
            }
            else if (lbl_out_gbn.Text == "1")
            {
                    wnDm wDm = new wnDm();

                    int rsNum = wDm.update매출등록(
                           txt_매출일자.Value.ToString().Substring(0, 10)
                           , txt매출번호.Text
                          , cbo담당사원.SelectedValue.ToString()

                          , str거래처코드

                        , cbo창고.SelectedValue.ToString()
                        , cbo부가세.SelectedValue.ToString()
                        , cbo전표상태.SelectedValue.ToString()
                        , txt_comment.Text
                         , dgv제품
                         , txt시간.Text
                        , str계산서발행
                        , dtp발행일자.Value.ToString().Substring(0, 10)
                        );
                    if (rsNum == 0)
                    {

                        MessageBox.Show("성공적으로 등록하였습니다.");
                    }
                    else if (rsNum == 1)
                        MessageBox.Show("저장에 실패하였습니다");
                    else if (rsNum == 2)
                        MessageBox.Show("SQL COMMAND 에러");
                    else if (rsNum == 3)
                        MessageBox.Show("기존 코드가 존재하므로 \n 다른 코드로 입력 바랍니다.");
                    else
                        MessageBox.Show("Exception 에러");
                 
            }
          
      
        }

        private void btnSrch_Click(object sender, EventArgs e)
        {
            bind_dgv매출();
        }


        private void bind_dgv매출()
        {
            dgv매출.Rows.Clear();

            string condition = "and  A.SALE_DATE>='" + start_date.Value.ToString().Substring(0, 10) + "' and  A.SALE_DATE<='" + end_date.Value.ToString().Substring(0, 10) + "' ";
            DataTable dt = wnDm.매출리스트(condition);


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dgv매출.Rows.Add();
                dgv매출.Rows[i].Cells["M_매출일자"].Value = dt.Rows[i]["SALE_DATE"].ToString();
                dgv매출.Rows[i].Cells["M_매출번호"].Value = dt.Rows[i]["SALE_NUM"].ToString();
                dgv매출.Rows[i].Cells["M_주문일자"].Value = dt.Rows[i]["ORDER_DATE"].ToString();
                dgv매출.Rows[i].Cells["M_거래처코드"].Value = dt.Rows[i]["CUST_CD"].ToString();
                dgv매출.Rows[i].Cells["M_거래처"].Value = dt.Rows[i]["CUST_NM"].ToString();
                dgv매출.Rows[i].Cells["M_계산서발행여부"].Value = dt.Rows[i]["BILL_YN"].ToString();
                dgv매출.Rows[i].Cells["M_담당사원코드"].Value = dt.Rows[i]["STAFF_CD"].ToString();
                dgv매출.Rows[i].Cells["M_부가세코드"].Value = dt.Rows[i]["VAT_CD"].ToString();
                dgv매출.Rows[i].Cells["M_발행일자"].Value = dt.Rows[i]["BILL_DATE"].ToString();
                dgv매출.Rows[i].Cells["M_비고"].Value = dt.Rows[i]["COMMENT"].ToString();
               

            }


        }

        private void cbo전표상태_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo전표상태.SelectedValue=="1")
            {
                
            }
        }

        private void dgv매출_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                btnDelete.Enabled = true;
                lbl_out_gbn.Text = "1";

                cbo부가세.SelectedValue = dgv매출.Rows[e.RowIndex].Cells["M_부가세코드"].Value.ToString();
                cbo담당사원.SelectedValue = dgv매출.Rows[e.RowIndex].Cells["M_담당사원코드"].Value.ToString();
                txt_매출일자.Value = DateTime.Parse(dgv매출.Rows[e.RowIndex].Cells["M_매출일자"].Value.ToString());
                txt매출번호.Text = dgv매출.Rows[e.RowIndex].Cells["M_매출번호"].Value.ToString();
                txt_cust_nm.Text = dgv매출.Rows[e.RowIndex].Cells["M_거래처"].Value.ToString();
                str거래처코드 = dgv매출.Rows[e.RowIndex].Cells["M_거래처코드"].Value.ToString();

                switch (dgv매출.Rows[e.RowIndex].Cells["M_계산서발행여부"].Value.ToString())
                {
                    case "1":
                        rdo계산서발행.Checked = true;
                        txt_매출일자.Value = DateTime.Parse(dgv매출.Rows[e.RowIndex].Cells["M_발행일자"].Value.ToString());
                        break;
                    case "2":
                        rdo계산서미발행.Checked = true;

                        break;
                    default:
                        break;


                }

                txt_comment.Text = dgv매출.Rows[e.RowIndex].Cells["M_비고"].Value.ToString();
            }
            bind_매출등록_D();
        }


        private void bind_매출등록_D()
        {
            dgv제품.Rows.Clear();
            wnDm wDm = new wnDm();
            DataTable dt = null;
            dt = wDm.매출_제품리스트("where A.SALE_DATE = '" + txt_매출일자.Text.ToString() + "' and A.SALE_NUM = '" + txt매출번호.Text.ToString() + "' ");

            this.dgv제품.RowCount = dt.Rows.Count;
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dgv제품.Rows[i].Cells["규격"].Value = dt.Rows[i]["SPEC"].ToString();
                    dgv제품.Rows[i].Cells["O_NO"].Value = dt.Rows[i]["SALE_SEQ"].ToString();
                    dgv제품.Rows[i].Cells["O_ITEM_CD"].Value = dt.Rows[i]["ITEM_CD"].ToString();
                    dgv제품.Rows[i].Cells["제품명"].Value = dt.Rows[i]["ITEM_NM"].ToString();
                    dgv제품.Rows[i].Cells["O_UNIT_CD"].Value = dt.Rows[i]["UNIT_CD"].ToString();
                    dgv제품.Rows[i].Cells["O_UNIT_NM"].Value = dt.Rows[i]["UNIT_NM"].ToString();
                    dgv제품.Rows[i].Cells["최종매출일"].Value = DateTime.Parse(dt.Rows[i]["LAST_DATE"].ToString());
                    dgv제품.Rows[i].Cells["비고"].Value = dt.Rows[i]["COMMENT"].ToString();
                    dgv제품.Rows[i].Cells["매출구분"].Value = dt.Rows[i]["SALE_GB"].ToString();
                    dgv제품.Rows[i].Cells["O_부가세"].Value = dt.Rows[i]["VAT_GB"].ToString();
                    dgv제품.Rows[i].Cells["O_과세"].Value = dt.Rows[i]["TAX_GB"].ToString();
                    dgv제품.Rows[i].Cells["O_주문일자"].Value = dt.Rows[i]["ORD_DATE"].ToString();
                    dgv제품.Rows[i].Cells["O_주문번호"].Value = dt.Rows[i]["ORD_NUM"].ToString();

                    dgv제품.Rows[i].Cells["TOTAL_AMT"].Value = (decimal.Parse(dt.Rows[i]["SALE_QTY"].ToString())).ToString("#,0.######");
                    dgv제품.Rows[i].Cells["PRICE"].Value = (decimal.Parse(dt.Rows[i]["SALE_PRICE"].ToString())).ToString("#,0.######");
                    dgv제품.Rows[i].Cells["TOTAL_MONEY"].Value = (decimal.Parse(dt.Rows[i]["SALE_AMT"].ToString())).ToString("#,0.######");
                }
            }


        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            resetting();
        }

        private void resetting()
        {
            lbl_out_gbn.Text = "";
            txt_매출일자.Value = DateTime.Now;
            txt시간.Text = DateTime.Now.ToString("HHmmss");
            txt매출번호.Text = "";
            txt입력방식.Text = Common.p_HW;
            txt_cust_nm.Text = "";
            str거래처코드 = "";
            txt_comment.Text = "";

            btnDelete.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("선택하신 정보가 삭제됩니다", "YesOrNo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                if (p_Isrgstr)
                {
                    try
                    {
                        int rsNum = 2;
                        wnDm wdm = new wnDm();
                        rsNum = wnDm.매출등록삭제(txt_매출일자.Value.ToString().Substring(0, 10), txt매출번호.Text);

                        if (rsNum == 0)
                        {

                            resetting();


                        }
                        else if (rsNum == 1)
                            MessageBox.Show("삭제에 실패하였습니다");
                        else
                            MessageBox.Show("Exception 에러");
                    }

                    catch (Exception e2)
                    {
                        MessageBox.Show("시스템 에러: " + e2.Message.ToString());
                    }


                }
                else
                {
                    MessageBox.Show("권한이 없습니다.");
                }
            }
            else
            {
            }


           
        }

    }
}
