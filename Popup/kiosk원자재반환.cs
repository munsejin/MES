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
using MES.CLS;

namespace MES.Popup
{
    public partial class kiosk원자재반환 : Form
    {
        conTextNumber focuseText = new conTextNumber();
        private wnGConstant wConst = new wnGConstant();
        private ComInfo comInfo = new ComInfo();

        private List<Button> myButtons = new List<Button>();  // 버튼을 담을 리스트 생성
        private int cntBtn = 0;  // 현재 화면에 동적 생성한 버튼 수 초기화 

        private string storage_nm = "";

        public kiosk원자재반환()
        {
            InitializeComponent();
        }
        private void kiosk원자재반환_Load(object sender, EventArgs e)
        {
            string sqlQuery = "";
            int rowCount = 0;
            cmb_storage_nm.ValueMember = "명칭";
            cmb_storage_nm.DisplayMember = "코드";

            sqlQuery = comInfo.queryRawStorage();
            wConst.ComboBox_Read_NoBlank(cmb_storage_nm, sqlQuery);

            rowCount = cmb_storage_nm.Items.Count;
            btn_storage(rowCount);
            
        }

        private void btn_storage(int rowCount)
        {
            int rowC = rowCount;
            if (rowC < 6)
            {
                cmb_storage_nm.Visible = false; 
                for (int i = 0; i < rowC; i++)
                {

                    myButtons.Add(new Button());
                    myButtons[i].Location = new Point(100 + 200 * i, 100);
                    myButtons[i].Width = 200;
                    myButtons[i].Height = 500;
                    myButtons[i].FlatStyle = FlatStyle.Popup;
                    myButtons[i].BackColor = Color.AliceBlue;
                    myButtons[i].Name = "myButton" + i.ToString();

                    cmb_storage_nm.SelectedIndex = i;
                    myButtons[i].Text = cmb_storage_nm.SelectedValue.ToString();

                    myButtons[i].UseVisualStyleBackColor = true;
                    myButtons[i].Tag = cmb_storage_nm.SelectedValue.ToString();
                    myButtons[i].Click += new EventHandler(btnClick);
                    btn_panel.Controls.Add(myButtons[i]);


                }

            }
            else
            {
                cmb_storage_nm.Visible = true; 
            }

        }
        // 버튼 클릭 이벤트 처리기
        void btnClick(object sender, EventArgs e)
        {
            Button btn = sender as Button;  // 현재 버튼 객체
            storage_nm = btn.Text;
            //insert 원자재입고 페이지

        }

        private void btn_1_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            focuseText.Text += btn.Text.ToString();
            focuseText.Focus();
        }

        private void btn_ac_Click(object sender, EventArgs e)
        {
            focuseText.Text = "";
            focuseText.Focus();
        }

        private void txt_w_Click(object sender, EventArgs e)
        {
            텍스트포커스(sender,e);
        }
        private void 텍스트포커스(object sender, EventArgs e)
        {
            focuseText = sender as conTextNumber;
        }

        private void btn_save_Click(object sender, EventArgs e) /*원자재_INPUT*/
        {
            inputLogic();
        }

        private void inputLogic()
        {


            if (txt_w.Text.ToString().Equals(""))
            {
                MessageBox.Show("잔재의 가로를 입력해주세요.");
                return;
            }
            if (txt_h.Text.ToString().Equals(""))
            {
                MessageBox.Show("잔재의 세로를 입력해주세요.");
                return;
            }

            string spec = txt_t.Text + "*" + txt_w.Text.Replace(",", "") + "*" + txt_h.Text.Replace(",", "");

        
                wnDm wDm = new wnDm();


                int rsNum = wDm.insertRawInput(spec);
                       

                if (rsNum == 0)
                {
                   
                        MessageBox.Show("성공적으로 등록하였습니다.");
                
                }
                else if (rsNum == 1)
                {
                    MessageBox.Show("저장에 실패하였습니다");
                }
                else if (rsNum == 2)
                {
                    MessageBox.Show("조건 검사 중 에러");
                }
                else if (rsNum == 3)
                {
                    MessageBox.Show("발주수량보다 초과 입력 하셨습니다. \n 확인 후 다시 저장 하시기 바랍니다.");
                }
                else
                    MessageBox.Show("Exception 에러");
            
           
        }

     
    }
}
