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
using MES.Controls;
using System.Drawing.Drawing2D;
using System.Diagnostics;
using MES.Popup;

namespace MES.P90_SYS
{
    public partial class frm바로가기설정 : Form
    {
        public frm바로가기설정()
        {
            InitializeComponent();
        }
        private wnGConstant wConst = new wnGConstant();
        public static bool p_IsAuth = true;    // 열람권한
        public static bool p_Isrgstr = true;    //등록/수정 권한
        wnDm wnDm = new wnDm();
        public static bool p_Isdel = true;    // 삭제 권한
        private int m_Items = 0;
        private void frm바로가기설정_Load(object sender, EventArgs e)
        {
            bookmark_list();
            화살표변환(btn_next);
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

            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = null;

                if (Common.p_strUserAdmin.Equals("5")) //권한통제자는 무조건 모든 메뉴 보여줌
                {
                    dt = wDm.fn_TopMenu_List();

                }
                else
                {
                    dt = wDm.fn_TopMenu_Auth_List();
                }

                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int kk = 0; kk < dt.Rows.Count; kk++)
                    {
                        tview_menu.BeginUpdate();
                        tview_menu.Nodes.Add(dt.Rows[kk]["TopName"].ToString());
                        tview_menu.EndUpdate();
                        // Sub Menu 붙이기
                        get_SubMenu_Info(dt.Rows[kk]["TopID"].ToString(), kk);

                    }
                }
            }
            catch
            {
            }

        }
        public void get_SubMenu_Info(string sTopID, int seq)
        {
            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = null;

                if (Common.p_strUserAdmin.Equals("5"))
                {
                    dt = wDm.fn_SubMenu_List(sTopID);
                }
                else
                {
                    dt = wDm.fn_SubMenu_Auth_List(sTopID);

                }

                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int kk = 0; kk < dt.Rows.Count; kk++)
                    {


                        tview_menu.Nodes[seq].Nodes.Add(dt.Rows[kk]["SubName"].ToString());
                    }
                }
            }
            catch (Exception ex){
wnLog.writeLog(wnLog.LOG_ERROR, ex.Message + " - " + ex.ToString());Popup.pop오류리포트 msg = new Popup.pop오류리포트(ex.Message + " - " + ex.ToString());
                msg.ShowDialog();
            }
        }

        private void 화살표변환(Button button)
        {

            Point[] pointArray =
            {
                new Point( 20,  60),
                new Point(140,  60),
                new Point(140,  20),
                new Point(220, 100),
                new Point(140, 180),
                new Point(140, 140),
                new Point( 20, 140)
            };

            GraphicsPath graphicsPath = new GraphicsPath(FillMode.Winding);

            graphicsPath.AddPolygon(pointArray);

            Region region = new Region(graphicsPath);

            button.Region = region;

            button.SetBounds
            (
                button.Location.X,
                button.Location.Y,
                pointArray[3].X + 5,
                pointArray[4].Y + 5
            );
        }



        private void bookmark_list()
        {
            try
            {
                wnDm wDm = new wnDm();
                DataTable dt = null;
                dt = wDm.bookmarkList();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    chkListBox.Items.Add(dt.Rows[i]["SubName"].ToString());

                }


            }
            catch
            {
            }
        }





        private void btn_next_Click(object sender, EventArgs e)
        {



            foreach (TreeNode parents in tview_menu.Nodes)
            {
                if (m_Items >= 6)
                {
                    MessageBox.Show("최대 6까지 추가 가능합니다.");
                    break;

                }
                foreach (TreeNode childNode in parents.Nodes)
                {
                    if (childNode.Checked)
                    {

                        if (m_Items >= 5)
                        {
                            MessageBox.Show("최대 5까지 추가 가능합니다.");
                            break;

                        }
                        else
                        {
                            if (!chkListBox.Items.Contains(childNode.Text))
                            {
                                m_Items++;
                                chkListBox.Items.Add(childNode.Text);
                            }
                            else
                            {
                                MessageBox.Show("추가하려는 " + childNode.Text + "메뉴는 이미 추가되어 있습니다..");
                            }

                        }
                        childNode.Checked = false;
                    }
                }


            }
            


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (p_Isdel)
            {

                try
                {
                    foreach (var item in chkListBox.CheckedItems)
                    {

                        chkListBox.Items.Remove(item);

                        //  MessageBox.Show(ex.ToString());

                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                }

                //Debug.WriteLine(chkListBox.Items.IndexOf(chkListBox.CheckedItems).ToString());
                m_Items = chkListBox.Items.Count;
            }
            else
            {

                MessageBox.Show("권한이 없습니다.");

            }

        }

        private void chkListBox_ControlAdded(object sender, ControlEventArgs e)
        {
            MessageBox.Show("c");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //foreach (var item in chkListBox.Items)
            //{
            //    Debug.WriteLine(item.ToString());


            //}
            if (p_Isrgstr)
            {


                if (MessageBox.Show("선택하신 정보가 저장됩니다", "YesOrNo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        wnDm wDm = new wnDm();
                        DataTable dt = null;
                        wDm.updatebookmark(chkListBox);
                        MessageBox.Show("저장 완료");

                    }
                    catch
                    {

                        MessageBox.Show("저장 실패");

                    }
                }
                else
                {

                }
            }
            else
            {

                MessageBox.Show("권한이 없습니다.");
            }
            
        }
    }
}
