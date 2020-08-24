using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using MES.CLS;
using System.Diagnostics;

namespace MES
{
    public partial class frmLogin : Form
    {
        public bool bRet = false;
        private string sProgFolder = "";
        private string str_id = "";
        private string str_pw = "";

        int cnt = 0;
        #region  Common.sp_code 종류
        //                    테스트계정	100
        //자람푸드	900
        //화인내추럴	200
        //삼성아이앤비	200
        //(주)대양에스엠티	300
        //성연테크	000
        //FT글로벌	000
        //성일화학	200
        //(주)일양웰푸드	700
        //휴텍	000
        //주식회사위더스에프앤비농업회사법인	900
        //강릉최가두부	700
        //이앤씨테크	000
        //윈스텀테크	000
        //LS과학기술원	700
        //이와이엔	900
        //드림아트	800
        //동명가구	800
        //보금	500
        //(주)윈쿨	200
        //씨지엠	100
        //팔도산업	900
        //동명산업	900
        //봉천산업	900
        //그린시티	900
        //미래보빈	500
        //한결크린텍	900
        //건영스프링	000
        //현대기계	300
        //오케이박사	900
        #endregion 
        public frmLogin()
        {
            InitializeComponent();
        }
       
        private void frmLogin_Load(object sender, EventArgs e)
        {
            sProgFolder = Path.GetDirectoryName(System.Environment.GetCommandLineArgs()[0]);

            //this.Width = panMain.Width;
           // this.Height = panMain.Height;
            lblToday.Text = DateTime.Now.ToString("yyyy-MM-dd");

            txtCompID.Text = Properties.Settings.Default.SaupNo; //8098100672 4011152804 / (화인) 1278113487
            Read_CompID();

            tmFocus.Enabled = true;



        }

        public void Read_CompID()
        {
            //Hashtable htDB = new Hashtable();
            //SettingXML sXml = new SettingXML(sProgFolder + "\\" + "settings_company.xml");
            //htDB = sXml.ReadXml();

            //foreach (DictionaryEntry entry in htDB)
            //{
            //    if (entry.Key.ToString().Equals("CompanyNo"))
            //    {
            //        txtCompID.Text = entry.Value.ToString();
            //    }
                
            //}

            txtCompID.Text = Properties.Settings.Default.SaupNo??"";
        }

        public void Save_CompID()
        {
            // 데모용 또는, 관리용 사업자는 저장 안함.
            if (txtCompID.Text == "9999999999" || txtCompID.Text == "0000000000")
            {
                return;
            }

            //Hashtable htDB = new Hashtable();
            //htDB["CompanyNo"] = txtCompID.Text;
          
            //SettingXML sXml = new SettingXML(sProgFolder + "\\" + "settings_company.xml");
            //sXml.WriteXML(htDB);

            Properties.Settings.Default.SaupNo = txtCompID.Text.ToString();
            Properties.Settings.Default.Save();
        }
        
        private void btnOK_Click(object sender, EventArgs e)
        {
            //if (Common.p_DisplayWidth < 1920 && Common.p_DisplayHeghit < 1200)
            //{
            //    Common.p_tablet = true;
            //    Debug.WriteLine("tablet_MODE");
            //}
            

            //if (chk테블릿.Checked == true)
            //{
            //    Common.p_tablet = true;

            //}
            //else
            //{

            //    Common.p_tablet = false;

            //}
            if (cnt > 5)
            {
                MessageBox.Show("비밀번호를 분실하신 경우 관리자에게 문의바랍니다.");
                return;
            }
            if (txtCompID.Text.Trim() == "")
            {
                MessageBox.Show("[ 사업자번호 ]를 입력하세요.");
                txtCompID.Focus();
                return;
            }

            if (txtID.Text.Trim() == "")
            {
                MessageBox.Show("[ 아이디 ]를 입력하세요.");
                txtID.Focus();
                cnt++;
                return;
            }

            if (txtPW.Text.Trim() == "")
            {
                MessageBox.Show("[ 암호 ]를 입력하세요.");
                txtPW.Focus();
                cnt++;
                return;
            }



            Common.p_strRoot = "";
            str_id = txtID.Text.Trim();
            str_pw = txtPW.Text.Trim();


            Save_CompID();

            if (txtCompID.Text == "0000000000")
            {
                // 시스템관리자 체크 (개발 완료전까진 보류) 2019-03-26 유정훈
                //get_Root_Check();
            }

            Common.p_strConn = "";
            
            if (get_Comp_Info() == true)
            {
                

                if (Common.p_strRoot == "Y")
                {
                    str_id = "";
                    str_pw = "";

                    // 시스템관리자 : 우선, 데모 사이트 사장 아이디/암호 가져오기.
                    get_ceo_info();
                }

                // 로그인
               
               
                get_Detail();
                if (Common.p_strUserID != "")
                {
                    bRet = true;
                    this.Close();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            bRet = false;
            this.Close();
        }

        private void get_Root_Check()
        {
            SqlConnection dbConn2 = null;
            
            try
            {
                dbConn2 = new SqlConnection(Common.p_sConnCom);
                dbConn2.Open();

                string strSql = " select a.* ";
                strSql += " from T_관리자정보 a ";
                strSql += " where a.관리아이디 = '" + txtID.Text.ToString() + "' ";
                Debug.WriteLine(strSql);
                SqlCommand Cmd2 = new SqlCommand(strSql, dbConn2);
                SqlDataAdapter dAdapter2 = new SqlDataAdapter();
                DataTable dt2 = new DataTable();

                dAdapter2.SelectCommand = Cmd2;
                dAdapter2.Fill(dt2);

                if (dt2 != null && dt2.Rows.Count > 0)
                {
                    for (int i = 0; i < dt2.Rows.Count; i++)
                    {
                        Debug.WriteLine(dt2.Rows[0]["관리암호"].ToString());
                        Debug.WriteLine(txtPW.Text.ToString());
                        Debug.WriteLine(dt2.Rows[0]["관리암호"].ToString());

                    }
                        if (dt2.Rows[0]["관리암호"].ToString() == txtPW.Text.ToString())
                        {
                            Common.p_strRoot = "Y";
                        }
                        else
                        {
                            MessageBox.Show("로그인에 실패헸습니다.");
                            txtPW.Text = "";
                            txtPW.Focus();
                            cnt++;
                        }
                    
                    
                }
                dbConn2.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());

                MessageBox.Show("시스템 접속 중 오류 발생!");
            }
        }

        private bool get_Comp_Info()
        {
            pnl_check.BringToFront();
          
            bool bRet = false;

            SqlConnection dbConn = null;

            try
            {
                dbConn = new SqlConnection(Common.p_sConnCom);
                dbConn.Open();

                string strSql = "";
                strSql += "select COM_LOCATION,COMPANY_NM,A.SP_CODE,B.SP_SITE,A.PACK_GUBUN,C.HOMEPAGE, C.PLC_URL ,C.SAUP_LOGO, ISNULL(C.LOGO_SIZE,0) AS LOGO_SIZE,"
                    +" ISNULL(C.BANNER_SIZE,0) AS BANNER_SIZE, ISNULL(C.SEAL_SIZE,0) AS SEAL_SIZE, C.SAUP_BANNER, C.SAUP_SEAL ";
                strSql += "from T_COMP_LOGIN A ";
                strSql += "left outer join T_SUPPLY_CODE B ";
                strSql += "on A.SP_CODE = B.SP_CODE ";
                strSql += "left join T_SAUP_CODE as C on c.SAUP_NO=A.COM_SAUP_NO ";
                strSql += "where COM_SAUP_NO = '"+txtCompID.Text.Trim()+"'";
                Debug.WriteLine(strSql);
                SqlCommand Cmd = new SqlCommand(strSql, dbConn);
                SqlDataAdapter dAdapter = new SqlDataAdapter();
                DataTable dt = new DataTable();

                dAdapter.SelectCommand = Cmd;
                dAdapter.Fill(dt);

                if (dt != null && dt.Rows.Count > 0)
                {
                    string dbAccount = "";
                    string dbPassword = "";
                    string dbIp = "";

                    string path = System.Windows.Forms.Application.StartupPath + @"\\comdata.property";
                    string[] vals = System.IO.File.ReadAllLines(path);

                    Common.p_loginLocation = dt.Rows[0]["COM_LOCATION"].ToString();

                    for (int i = 0; i < vals.Length; i += 2)
                    {
                        

                        if (vals[i] == "l0OI0OlllllllIl0O0lIl0II00I00IllIIIllIl") dbIp = vals[i + 1];
                    
                        if (vals[i] == "I0OI0OIIIIlllIl0O0lIl0II00I00IllIIIllII") dbAccount = vals[i + 1];
                        if (vals[i] == "I0OI0OIIIIlllIl0O0lIl0II00I00IllIIIllIl") dbPassword = vals[i + 1];
                    }

                    StringBuilder sb = new StringBuilder();
                    //sb.Append("Data Source=" + CryptoConsole.decryptAES256(dbIp) + ";");
                    //sb.Append("Initial Catalog=" + dt.Rows[0]["COM_LOCATION"].ToString() + ";");
                    //sb.Append("User ID=" + CryptoConsole.decryptAES256(dbAccount) + ";");
                    //sb.Append("Password=" + CryptoConsole.decryptAES256(dbPassword) + ";");
                    //sb.Append("Persist Security Info=False;");

                    sb.Append(CryptoConsole.decryptAES256(" SHMXS/nbW3nb32WtKP7UyQ==") + CryptoConsole.decryptAES256(dbIp) + ";");
                    sb.Append(CryptoConsole.decryptAES256("RmROvrqvHBEz4W+R2MJZj+XMwyjHK2heQ6j+h+1dvmI=") + dt.Rows[0]["COM_LOCATION"].ToString() + ";");
                    sb.Append(CryptoConsole.decryptAES256("SweOily3R7qfec36aThiLQ==") + CryptoConsole.decryptAES256(dbAccount) + ";");
                    sb.Append(CryptoConsole.decryptAES256("ryRJIrqhHmw1oth2pPwVGA==") + CryptoConsole.decryptAES256(dbPassword) + ";");
                    sb.Append(CryptoConsole.decryptAES256("vr+jBN7RaeJkjTVxNLV9e/DUuB0QtbcxO0KWS0BEFts="));

                    Common.p_sConn = sb.ToString();

                    /* "DATA SOURCE = 61.75.115.32,1433;" //218.38.14.36 //119.198.73.138
                        + "INITIAL CATALOG = " + dt.Rows[0]["COM_LOCATION"].ToString() + ";"
                        + "PERSIST SECURITY INFO = false;"
                        + "USER ID = sa;"
                        + "PASSWORD =  qhdfla##_135;"; */

                  
                    Common.p_strCompNm = dt.Rows[0]["COMPANY_NM"].ToString();
                    Common.sp_code = dt.Rows[0]["SP_CODE"].ToString();
                    if (dt.Rows[0]["HOMEPAGE"].ToString() != "")
                    {
                        Common.p_homepage = dt.Rows[0]["HOMEPAGE"].ToString();
                    }
                    else
                    {
                        Common.sp_site = dt.Rows[0]["SP_SITE"].ToString();
                        Common.p_homepage = dt.Rows[0]["HOMEPAGE"].ToString();
                    }
                    Common.sp_pack_gubun = dt.Rows[0]["PACK_GUBUN"].ToString();
                    Common.p_saupNo = txtCompID.Text.Trim();
                    Common.p_strPLC_URL = dt.Rows[0]["PLC_URL"].ToString();

                    dbConn = new SqlConnection(Common.p_sConn);
                    dbConn.Open();

                    strSql = "";
                    strSql += "select * ";
                    strSql += "from N_STAFF_CODE ";
                    strSql += "where LOGIN_ID = '" + txtID.Text.Trim() + "' and PW = '" + txtPW.Text.Trim() + "' ";

                    Cmd = new SqlCommand(strSql, dbConn);
                    dAdapter = new SqlDataAdapter();
                    DataTable dt2 = new DataTable();

                    dAdapter.SelectCommand = Cmd;
                    dAdapter.Fill(dt2);

                    if (dt2 != null && dt2.Rows.Count > 0)
                    {
                        Common.p_strStaffNo = dt2.Rows[0]["STAFF_CD"].ToString();
                        Common.p_strStaffPhone = dt2.Rows[0]["PHONE_NUM"].ToString();
                        Common.p_strUserID = dt2.Rows[0]["LOGIN_ID"].ToString();
                        Common.p_strUserName = dt2.Rows[0]["STAFF_NM"].ToString();
                        Common.p_strUserAdmin = dt2.Rows[0]["AUTH_SET"].ToString();
                        Properties.Settings.Default.SaupNo = txtCompID.Text.ToString();
                        Properties.Settings.Default.Save();

                        bool isjang = get_Comp_Info_jang();

                        if (isjang)
                        {
                            //MessageBox.Show("장터지기 연동완료");
                        }

                        if (int.Parse(dt.Rows[0]["BANNER_SIZE"].ToString()) > 0)
                        {
                            byte[] rs = (byte[])dt.Rows[0]["SAUP_BANNER"];
                            MemoryStream ms = new MemoryStream(rs);
                            Image img = Image.FromStream(ms);
                            wnGConstant.insert_banner_with_WaterMark(img);
                        }

                        if (int.Parse(dt.Rows[0]["SEAL_SIZE"].ToString()) > 0)
                        {
                            byte[] rs = (byte[])dt.Rows[0]["SAUP_SEAL"];
                            MemoryStream ms = new MemoryStream(rs);
                            Image img = Image.FromStream(ms);
                            wnGConstant.insert_Logos(img,"seal.png");
                        }

                        if (int.Parse(dt.Rows[0]["LOGO_SIZE"].ToString()) > 0)
                        {
                            byte[] rs = (byte[])dt.Rows[0]["SAUP_LOGO"];
                            MemoryStream ms = new MemoryStream(rs);
                            Image img = Image.FromStream(ms);
                            wnGConstant.insert_Logos(img, "Logo.jpg");
                        }
                  
                        frmMain frm = new frmMain();
                        this.Visible = false;
                        frm.ShowDialog();
                     
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("아이디 혹은 비밀번호가 일치하지 않습니다.");
                        txtPW.Text = "";
                        txtPW.Focus();
                        cnt++;
                    }
                    //if (dt.Rows[0]["사용여부"].ToString() == "Y")
                    //{
                    //    Common.p_strConn = "DATA SOURCE = " + dt.Rows[0]["디비주소"].ToString() + ";"
                    //        + "INITIAL CATALOG = " + dt.Rows[0]["디비명"].ToString() + ";"
                    //        + "PERSIST SECURITY INFO = false;"
                    //        + "USER ID = " + dt.Rows[0]["디비계정"].ToString() + ";"
                    //        + "PASSWORD = " + dt.Rows[0]["디비암호"].ToString() + ";";

                    //    bRet = true;
                    //}
                    //else
                    //{
                    //    MessageBox.Show("해당 사업자는 [사용중지] 상태입니다.");
                    //    txtPW.Text = "";
                    //    txtPW.Focus();
                    //}
                }
                else
                {
                    MessageBox.Show("등록된 사업자가 아닙니다.");
                    txtPW.Text = "";
                    txtPW.Focus();

                }

                dbConn.Close();
            }
            catch (Exception ex)
            {

                //MessageBox.Show(ex.ToString());
                MessageBox.Show("시스템 접속 중 오류 발생!!");
            }
            pnl_check.SendToBack();
          
            return bRet;
        }


        private bool get_Comp_Info_jang()
        {
           
            bool bRet = false;

            SqlConnection dbConn = null;
            try
            {

                dbConn = new SqlConnection(Common.p_sConnCom_jang);
                dbConn.Open();

                string strSql = "";
                strSql += "select A.사업자번호, B.디비주소, B.디비명, B.디비계정, B.디비암호 ";
                strSql += "from T_업체정보 A ";
                strSql += "left outer join T_데이터베이스 B ";
                strSql += "on A.디비순번 = B.디비순번 ";
                strSql += "where 사업자번호 = '" + txtCompID.Text.Trim() + "'";


                SqlCommand Cmd = new SqlCommand(strSql, dbConn);
                SqlDataAdapter dAdapter = new SqlDataAdapter();
                DataTable dt = new DataTable();
                dAdapter.SelectCommand = Cmd;
                dAdapter.Fill(dt);

                if (dt != null && dt.Rows.Count > 0)
                {
                    Common.p_sConn_jang = "DATA SOURCE = " + dt.Rows[0]["디비주소"].ToString() + ";" //183.98.215.16
                        + "INITIAL CATALOG = " + dt.Rows[0]["디비명"].ToString() + ";"
                        + "PERSIST SECURITY INFO = false;"
                        + "USER ID = " + dt.Rows[0]["디비계정"].ToString() + ";"
                        + "PASSWORD = " + dt.Rows[0]["디비암호"].ToString() + ";";

                   


                    dbConn = new SqlConnection(Common.p_sConn_jang);
                    dbConn.Open();

                    strSql = "";
                    strSql += "select * ";
                    strSql += "from T_사용자정보 ";
                    strSql += "where UID = '" + txtID.Text.Trim() + "' and UPW = '" + txtPW.Text.Trim() + "' and 사업자번호 = '" + txtCompID.Text.Trim() + "'";

                    Cmd = new SqlCommand(strSql, dbConn);
                    dAdapter = new SqlDataAdapter();
                    dt = new DataTable();

                    dAdapter.SelectCommand = Cmd;
                    dAdapter.Fill(dt);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        Common.p_strStaffNo_jang = dt.Rows[0]["사원번호"].ToString();
                        return true;
                        
                        
                    }
                    else
                    {
                        return false;
                    }
                    
                }
                else
                {
                    return false;
                }

               // dbConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                MessageBox.Show("시스템 접속 중 오류 발생!!");
            }

            return false;
        }


        private void get_ceo_info()
        {
            SqlConnection dbConn2 = null;

            try
            {
                dbConn2 = new SqlConnection(Common.p_strConn);
                dbConn2.Open();

                string strSql = " select top 1 a.* ";
                strSql += " from T_사용자정보 a ";
                strSql += " where a.사업자번호 = '" + txtCompID.Text.Trim() + "' ";
                strSql += "     and a.관리자여부 = 'Y' ";

                SqlCommand Cmd2 = new SqlCommand(strSql, dbConn2);
                SqlDataAdapter dAdapter2 = new SqlDataAdapter();
                DataTable dt2 = new DataTable();

                dAdapter2.SelectCommand = Cmd2;
                dAdapter2.Fill(dt2);

                if (dt2 != null && dt2.Rows.Count > 0)
                {
                    if (dt2.Rows[0]["퇴사여부"].ToString() == "N")
                    {
                        str_id = dt2.Rows[0]["UID"].ToString();
                        str_pw = dt2.Rows[0]["UPW"].ToString();
                    }
                }
                dbConn2.Close();
            }
            catch (Exception ex)
            {
                ////MessageBox.Show(ex.ToString());
                //MessageBox.Show("시스템 접속 중 오류 발생!");
            }
        }

        private void get_Detail()
        {
            SqlConnection dbConn2 = null;

            try
            {
                

                dbConn2 = new SqlConnection(Common.p_strConn);
                dbConn2.Open();

                string strSql = " select a.* ";
                strSql += "     , b.단가수정 ";
                strSql += " from T_사용자정보 a ";
                strSql += "     left outer join T_사용자권한 b on b.사업자번호 = a.사업자번호 and b.사원번호 = a.사원번호 ";
                strSql += " where a.사업자번호 = '" + txtCompID.Text.Trim() + "' ";
                strSql += "     and a.UID = '" + str_id + "' ";

                SqlCommand Cmd2 = new SqlCommand(strSql, dbConn2);
                SqlDataAdapter dAdapter2 = new SqlDataAdapter();
                DataTable dt2 = new DataTable();

                dAdapter2.SelectCommand = Cmd2;
                dAdapter2.Fill(dt2);

                if (dt2 != null && dt2.Rows.Count > 0)
                {
                    if (dt2.Rows[0]["퇴사여부"].ToString() == "N")
                    {
                        if (dt2.Rows[0]["UPW"].ToString() == str_pw)
                        {
                            if (Check_DBConnection(Common.p_strConn) == true)
                            {
                                Common.p_strUserNo = dt2.Rows[0]["사원번호"].ToString();
                                Common.p_strUserID = dt2.Rows[0]["UID"].ToString();
                                Common.p_strUserName = dt2.Rows[0]["사용자명"].ToString();
                                Common.p_strUserAdmin = dt2.Rows[0]["관리자여부"].ToString();
                                //Common.p_strCompID = dt2.Rows[0]["사업자번호"].ToString();

                                //if (Common.p_strUserAdmin == "Y")
                                //{
                                //    Common.p_strUnitMod = "Y";
                                //}
                                //else
                                //{
                                //    if (dt2.Rows[0]["단가수정"].ToString() == "Y")
                                //    {
                                //        Common.p_strUnitMod = "Y";
                                //    }
                                //}

                                Save_CompID();
                            }
                            else
                            {
                                MessageBox.Show("시스템이 준비중이거나, 오류가 있습니다." + "\r\n" + "시스템 공급업체로 문의하세요.");
                                txtPW.Text = "";
                                txtPW.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("로그인에 실패헸습니다.");
                            txtPW.Text = "";
                            txtPW.Focus();
                            cnt++;

                        }
                    }
                    else
                    {
                        MessageBox.Show("로그인에 실패헸습니다.");
                        txtPW.Text = "";
                        txtPW.Focus();
                        cnt++;
                    }
                }
                else
                {
                    MessageBox.Show("로그인에 실패헸습니다.");
                    txtPW.Text = "";
                    txtPW.Focus();
                    cnt++;
                }
                dbConn2.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
                MessageBox.Show("시스템 접속 중 오류 발생!!!");
            }
            btnOK.BackgroundImage = global::MES.Properties.Resources.NN_Button_Primary;

        }

        public bool Check_DBConnection(string sConn)
        {
            try
            {
                using (SqlConnection dbConn = new SqlConnection())
                {
                    dbConn.ConnectionString = sConn;
                    dbConn.Open();
                    dbConn.Close();
                }
            }
            catch (SqlException ex)
            {
                return false;
            }
            return true;
        }

        private void txtPW_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOK_Click(this, null);
            }
        }

        private void tmFocus_Tick(object sender, EventArgs e)
        {
            tmFocus.Enabled = false;

            if (txtCompID.Text.Length == 10)
            {
                txtID.Focus();
            }
            if (txtID.Text.Length > 0)
            {
                txtPW.Focus();
            }
        }

        private void txtPW_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;

                btnOK_Click(this, null);
            }
        }

        private void Label6_Click(object sender, EventArgs e)
        {
            get_Root_Check();
        }

        private void btnOK_MouseEnter(object sender, EventArgs e)
        {
            btnOK.Image = global::MES.Properties.Resources.NN_Login_Button_hover;
            btnOK.ForeColor = Color.White;
        }

        private void btnOK_MouseLeave(object sender, EventArgs e)
        {
            btnOK.Image = global::MES.Properties.Resources.NN_Button_Primary;
            btnOK.ForeColor = Color.FromArgb(38, 153, 251);
        }

        private void btnOK_MouseDown(object sender, MouseEventArgs e)
        {
            btnOK.Image = global::MES.Properties.Resources.NN_Login_Button_pressed;
            btnOK.ForeColor = Color.White;
        }

        private void btnOK_MouseUp(object sender, MouseEventArgs e)
        {
            btnOK.Image = global::MES.Properties.Resources.NN_Login_Button_hover;
            btnOK.ForeColor = Color.White;
        }

        private void btnClose_MouseDown(object sender, MouseEventArgs e)
        {
            btnClose.Image = global::MES.Properties.Resources.NNN_login_canclle_button_pressed;
            btnClose.ForeColor = Color.White;

        }

        private void btnClose_MouseEnter(object sender, EventArgs e)
        {
            btnClose.Image = global::MES.Properties.Resources.NNN_login_canclle_button_hover;
            btnClose.ForeColor = Color.White;

        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            btnClose.Image = global::MES.Properties.Resources.NNN_login_canclle_button;
            btnClose.ForeColor = Color.FromArgb(64, 64, 64);
        }

        private void btnClose_MouseUp(object sender, MouseEventArgs e)
        {
            btnClose.Image = global::MES.Properties.Resources.NNN_login_canclle_button_hover;
            btnClose.ForeColor = Color.White;
        }

    }
}
