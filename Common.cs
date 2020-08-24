using MES.CLS;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MES
{
    public class Common
    {
        public static string p_strConn = "";
        public static string p_loginLocation = "";
        public static string p_sConnCom
        {
            get
            {
                string dbAccount = "";
                string dbPassword = "";
                string dbIp = "";
                string dbPort = "";
                string dbSid = "";
                StreamReader sr = null;
                try
                {
                    string path = System.Windows.Forms.Application.StartupPath + @"\\comdata.property";
                    string[] vals = System.IO.File.ReadAllLines(path);


                    for (int i = 0; i < vals.Length; i += 2)
                    {

                        if (vals[i] == "l0OI0OlllllllIl0O0lIl0II00I00IllIIIllIl") dbIp = vals[i + 1];
                        if (vals[i] == "l0OI0OIIIIlllIl0O0lIl0II00I00IllIIllllII") dbSid = vals[i + 1];
                        if (vals[i] == "I0OI0OIIIIlllIl0O0lIl0II00I00IllIIIllII") dbAccount = vals[i + 1];
                        if (vals[i] == "I0OI0OIIIIlllIl0O0lIl0II00I00IllIIIllIl") dbPassword = vals[i + 1];
                      

                        //if (vals[i] == "wm.dbPort") dbPort = vals[i + 1];
                        //if (vals[i] == "wm.guchung") ClsCommon.guchung = vals[i + 1];
                    }

                 

                    StringBuilder connStr = new StringBuilder();
                 
                    connStr.Append(CryptoConsole.decryptAES256(" SHMXS/nbW3nb32WtKP7UyQ==") + CryptoConsole.decryptAES256(dbIp) + ";");
                    connStr.Append(CryptoConsole.decryptAES256("RmROvrqvHBEz4W+R2MJZj+XMwyjHK2heQ6j+h+1dvmI=") + CryptoConsole.decryptAES256(dbSid) + ";");
                    connStr.Append(CryptoConsole.decryptAES256("SweOily3R7qfec36aThiLQ==") + CryptoConsole.decryptAES256(dbAccount) + ";");
                    connStr.Append(CryptoConsole.decryptAES256("ryRJIrqhHmw1oth2pPwVGA==") + CryptoConsole.decryptAES256(dbPassword) + ";");
                    connStr.Append(CryptoConsole.decryptAES256("vr+jBN7RaeJkjTVxNLV9e/DUuB0QtbcxO0KWS0BEFts="));
                    Debug.WriteLine(connStr.ToString());
                    return connStr.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("환결설정 파일 wm.property 로드에 실패하였습니다. " + ex.ToString());
                }
                return null;
            }
        }

        public static string p_sConnCom_jang = "DATA SOURCE = 218.38.14.33,14332;" //183.98.215.16
        + "INITIAL CATALOG = smartSales_Public;"
        + "PERSIST SECURITY INFO = false;"
        + "USER ID = smartUser;"
        + "PASSWORD =  wkdxj2017!@;";


        public static string p_sConn = "";
        public static string p_sConn_jang = "";


        public static string p_strLocation = "";
     //   public static float p_DisplayScale = User_32.getScalingFactor();   //배율 
        public static float p_DisplayHeghit = System.Windows.Forms.SystemInformation.VirtualScreen.Height;  //해상도 Y
        public static float p_DisplayWidth = System.Windows.Forms.SystemInformation.VirtualScreen.Width; // 해상도 X
        
        public static string p_strRoot = "";        // Root 여부
        public static string p_strUserNo = "";     // 사원번호
        public static string p_strStaffNo = "";     // 사원번호
        public static string p_strStaffNo_jang = "";
        public static string p_strStaffPhone = "";        
        public static string p_strUserID = "";      // 사용자아이디
        public static string p_strUserCode = "전주소";      // 사용자코드
        public static string p_strUserMan = "전주소";      // 사용자 USER_MAN
        public static string p_strUserReg = "61";      // 사용자 주민번호
        public static string p_strUserDept = "600";      // 사용자 부서코드
        public static string p_strUserPW = "";      // 사용자암호
        public static string p_strUserName = "홍길동";    // 사용자명
        public static string p_homepage = "";    // 홈페이지



        public static string p_strUserAdmin = "";   // 관리자여부  사용정지  정보조회  자료입력  정보분석   관리통제
        public static string p_saupNo = ""; //사업자번호
        public static string p_strCompNm = "";
        public static Boolean p_tablet = false;// 테블릿 모드
        public static string p_emailID = "";// 이메일아이디
        public static string p_HW = "C";// 컴퓨터인지 ?모바일인지? 

        public static string p_emailPW = "";// 이메일 비밀번호

        public static string sp_code = ""; //공급업체 코드 
        public static string sp_site = ""; //공급업체 사이트 
        public static string sp_pack_gubun = ""; //공급업체 패키지 구분 (1: 통합형, 2: MES)

        public static string p_PageSize = "100";   // 페이지사이즈

        public static string p_strFormatAmount = "#,0"; // 수량 양식.
        public static string p_strFormatUnit = "#,0"; // 단가 양식.
        public static string p_strPLC_URL = ""; // PLC데이터 로드 주소

       

        public static bool isNum(string txt)
        {
            string str = txt.Trim();
            if (!Regex.IsMatch(txt.Trim(), @"^[0-9]+$"))
            {
                return false;
            }
            return true;
        }

        public static bool isNumFloat(string txt)
        {
            string str = txt.Trim();
            try
            {
                float flo = float.Parse(txt.Trim());
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static string GetKeyStringbyKeys(Keys keys)
        {
            switch (keys)
            {
                case Keys.A: return "A";
                case Keys.B: return "B";
                case Keys.C: return "C";
                case Keys.D: return "D";
                case Keys.E: return "E";
                case Keys.F: return "F";
                case Keys.G: return "G";
                case Keys.H: return "H";
                case Keys.I: return "I";
                case Keys.J: return "J";
                case Keys.K: return "K";
                case Keys.L: return "L";
                case Keys.M: return "M";
                case Keys.N: return "N";
                case Keys.O: return "O";
                case Keys.P: return "P";
                case Keys.Q: return "Q";
                case Keys.R: return "R";
                case Keys.S: return "S";
                case Keys.T: return "T";
                case Keys.U: return "U";
                case Keys.V: return "V";
                case Keys.W: return "W";
                case Keys.X: return "X";
                case Keys.Y: return "Y";
                case Keys.Z: return "Z";
                case Keys.Enter: return "~";
                case Keys.Escape: return "{ESC}";
                case Keys.Back: return "{BKSP}";
                case Keys.Pause: return "{BREAK}";
                case Keys.CapsLock: return "{CAPSLOCK}";
                case Keys.Delete: return "{DEL}";
                case Keys.End: return "{END}";
                case Keys.Help: return "{HELP}";
                case Keys.Home: return "{HOME}";
                case Keys.Insert: return "{INSERT}";
                case Keys.PageDown: return "{PGDN}";
                case Keys.PageUp: return "{PGUP}";
                case Keys.PrintScreen: return "{PRTSC}";
                case Keys.Scroll: return "{SCROLLLOCK}";
                case Keys.Tab: return "{TAB}";
                case Keys.F1: return "{F1}";
                case Keys.F2: return "{F2}";
                case Keys.F3: return "{F3}";
                case Keys.F4: return "{F4}";
                case Keys.F5: return "{F5}";
                case Keys.F6: return "{F6}";
                case Keys.F7: return "{F7}";
                case Keys.F8: return "{F8}";
                case Keys.F9: return "{F9}";
                case Keys.F10: return "{F10}";
                case Keys.F11: return "{F11}";
                case Keys.F12: return "{F12}";
                case Keys.Left: return "{LEFT}";
                case Keys.Right: return "{RIGHT}";
                case Keys.Up: return "{UP}";
                case Keys.Down: return "{DOWN}";
                case Keys.Add: return "{ADD}";
                case Keys.Subtract: return "{SUBTRACT}";
                case Keys.Multiply: return "{MULTIPLY}";
                case Keys.Divide: return "{DIVIDE}";
                case Keys.Shift: return "*";
                case Keys.Control: return "^";
                case Keys.Alt: return "%";
                default: return "";
            }
        }

    }
}
