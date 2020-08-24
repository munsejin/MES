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
    public partial class pop초기재고수정 : Form
    {
        private int iCnt;
        private string strCondition = "";
        
        public string sCode = "";
        public string sName = "";
        public string sStorageCd = "";
        public string sInputDate = "";
        public string sInputCd = "";
        public string sInputSeq = "";
        public string sInputLabelNm = "";
        public string sInputProductGubun = "";
        public string sFrozen_gubun = "";
        public string returnValue = "";


        private int nPageSize = int.Parse(Common.p_PageSize);
        public pop초기재고수정()
        {
            InitializeComponent();
        }

        private void pop초기재고수정_Load(object sender, EventArgs e)
        {
            ComInfo comInfo = new ComInfo();
            string sqlQuery = "";

            txt_input_date.Text = sInputDate;
            txt_input_cd.Text = sInputCd;
            txt_seq.Text = sInputSeq;
            txt_label_nm.Text = sInputLabelNm;

            
        }

        private void bindData()
        {
           
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (txt_updateValue.Text != null && !txt_updateValue.Text.ToString().Equals(""))
            {
                try
                {
                    Decimal.Parse(txt_updateValue.Text);
                    wnDm wDm = new wnDm();

                    string input_date = txt_input_date.Text.ToString();
                    string input_cd = txt_input_cd.Text.ToString();
                    string input_seq = txt_seq.Text.ToString();
                    string label_nm = txt_label_nm.Text.ToString();
                    string Update_amt = txt_updateValue.Text.ToString();


                    if (sInputProductGubun.Equals("1"))
                    {
                        int rsNum = wDm.Update_Raw_Input_Amt(input_date, input_cd, input_seq, Update_amt, sFrozen_gubun);

                        if (rsNum == 0)
                        {
                            MessageBox.Show("성공적으로 수정하였습니다.");
                            returnValue = "1";
                            this.Close();
                        }
                        else if (rsNum == 1)
                        {
                            MessageBox.Show("저장에 실패하였습니다");
                        }
                        else
                        {
                            MessageBox.Show("Exception 에러");
                        }
                    }

                    else if (sInputProductGubun.Equals("2"))
                    {
                        int rsNum = wDm.Update_Item_Input_Amt(input_date, input_cd, input_seq, Update_amt);

                        if (rsNum == 0)
                        {
                            MessageBox.Show("성공적으로 수정하였습니다.");
                            returnValue = "1";
                            this.Close();
                        }
                        else if (rsNum == 1)
                        {
                            MessageBox.Show("저장에 실패하였습니다");
                        }
                        else
                        {
                            MessageBox.Show("Exception 에러");
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("초기 수량 양식이 잘못되었습니다.");
                    return;
                }


            }
        }

        private void txt_updateValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComInfo.onlyNum2(sender, e);
        }
    }
}
