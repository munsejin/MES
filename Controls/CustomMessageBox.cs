using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;





namespace MES.Controls
{
    class CustomMessageBox
    {
        #region 후킹 델리게이트 - HookDelegate(hookCode, wordParameter, longParameter)



        /// <summary>

        /// 후킹 델리게이트

        /// </summary>

        /// <param name="hookCode">후킹 코드</param>

        /// <param name="wordParameter">WORD 매개 변수</param>

        /// <param name="longParameter">LONG 매개 변수</param>

        /// <returns>처리 결과</returns>

        private delegate int HookDelegate(int hookCode, IntPtr wordParameter, IntPtr longParameter);



        #endregion



        //////////////////////////////////////////////////////////////////////////////////////////////////// Import

        ////////////////////////////////////////////////////////////////////////////////////////// Static

        //////////////////////////////////////////////////////////////////////////////// Private



        #region 확장 윈도우 후킹 설정하기 - SetWindowsHookEx(hookCode, hookDelegate, moduleHandle, threadID);



        /// <summary>

        /// 확장 윈도우 후킹 설정하기

        /// </summary>

        /// <param name="hookCode">후킹 코드</param>

        /// <param name="hookDelegate">후킹 델리게이트</param>

        /// <param name="moduleHandle">모듈 핸들</param>

        /// <param name="threadID">스레드 ID</param>

        /// <returns>처리 결과</returns>

        [DllImport("user32.dll", SetLastError = true)]

        private static extern IntPtr SetWindowsHookEx(int hookCode, HookDelegate hookDelegate, IntPtr moduleHandle,

            uint threadID);



        #endregion

        #region 확장 윈도우 후킹 해제하기 - UnhookWindowsHookEx(hookHandle)



        /// <summary>

        /// 확장 윈도우 후킹 해제하기

        /// </summary>

        /// <param name="hookHandle">후킹 핸들</param>

        /// <returns>처리 결과</returns>

        [DllImport("user32.dll")]

        private static extern bool UnhookWindowsHookEx(IntPtr hookHandle);



        #endregion

        #region 확장 다음 후킹 호출하기 - CallNextHookEx(hookHandle, hookCode, wordParameter, longParameter)



        /// <summary>

        /// 확장 다음 후킹 호출하기

        /// </summary>

        /// <param name="hookHandle">후킹 핸들</param>

        /// <param name="hookCode">후킹 코드</param>

        /// <param name="wordParameter">WORD 매개 변수</param>

        /// <param name="longParameter">LONG 매개 변수</param>

        /// <returns>처리 결과</returns>

        [DllImport("user32.dll")]

        private static extern int CallNextHookEx(IntPtr hookHandle, int hookCode, IntPtr wordParameter,

            IntPtr longParameter);



        #endregion

        #region 대화 상자 항목 구하기 - GetDlgItem(dialogHandle, dialogResult)



        /// <summary>

        /// 대화 상자 항목 구하기

        /// </summary>

        /// <param name="dialogHandle">대화 상자 핸들</param>

        /// <param name="dialogResult">대화 상자 결과</param>

        /// <returns>대화 상자 항목 핸들</returns>

        [DllImport("user32.dll")]

        private static extern IntPtr GetDlgItem(IntPtr dialogHandle, DialogResult dialogResult);



        #endregion

        #region 대화 상자 항목 텍스트 설정하기 - SetDlgItemText(dialogHandle, dialogResult, text)



        /// <summary>

        /// 대화 상자 항목 텍스트 설정하기

        /// </summary>

        /// <param name="dialogHandle">대화 상자 핸들</param>

        /// <param name="dialogResult">대화 상자 결과</param>

        /// <param name="text">텍스트</param>

        /// <returns>처리 결과</returns>

        [DllImport("user32.dll")]

        private static extern bool SetDlgItemText(IntPtr dialogHandle, DialogResult dialogResult, string text);



        #endregion

        #region 현재 스레드 ID 구하기 - GetCurrentThreadId()



        /// <summary>

        /// 현재 스레드 ID 구하기

        /// </summary>

        /// <returns>현재 스레드 ID</returns>

        [DllImport("kernel32.dll")]

        private static extern uint GetCurrentThreadId();



        #endregion


        //////////////////////////////////////////////////////////////////////////////// Private



        #region Field



        /// <summary>

        /// 후킹 핸들

        /// </summary>

        private static IntPtr _hookHandle;



        /// <summary>

        /// 예 텍스트

        /// </summary>

        private static string _yesText;



        /// <summary>

        /// 아니오 텍스트

        /// </summary>

        private static string _noText;



        /// <summary>

        /// 취소 텍스트

        /// </summary>

        private static string _cancelText;



        #endregion



        //////////////////////////////////////////////////////////////////////////////////////////////////// Method

        ////////////////////////////////////////////////////////////////////////////////////////// Static




        //////////////////////////////////////////////////////////////////////////////// Public



        #region 보여주기 - Show(message, caption, yesText, noText, cancelText)



        /// <summary>

        /// 보여주기

        /// </summary>

        /// <param name="message">메시지</param>

        /// <param name="caption">제목</param>

        /// <param name="yesText">예 텍스트</param>

        /// <param name="noText">아니오 텍스트</param>

        /// <param name="cancelText">취소 텍스트</param>

        /// <returns>다이얼로그 결과</returns>

        public static DialogResult Show(string message, string caption, string yesText, string noText,

            string cancelText)
        {

            _yesText = yesText;

            _noText = noText;

            _cancelText = cancelText;



            _hookHandle = SetWindowsHookEx(5, new HookDelegate(ProcessHook), IntPtr.Zero, GetCurrentThreadId());



            return MessageBox.Show(message, caption, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

        }



        #endregion



        //////////////////////////////////////////////////////////////////////////////// Private



        #region 후킹 처리하기 - ProcessHook(hookCode, wordParameter, longParameter)



        /// <summary>

        /// 후킹 처리하기

        /// </summary>

        /// <param name="hookCode">후킹 코드</param>

        /// <param name="wordParameter">WORD 매개 변수</param>

        /// <param name="longParameter">LONG 매개 변수</param>

        /// <returns>처리 결과</returns>

        private static int ProcessHook(int hookCode, IntPtr wordParameter, IntPtr longParameter)
        {

            IntPtr childWindowHandle;



            if (hookCode == 5)
            {

                childWindowHandle = wordParameter;



                if (GetDlgItem(childWindowHandle, DialogResult.Yes) != null)
                {

                    SetDlgItemText(childWindowHandle, DialogResult.Yes, _yesText);

                }



                if (GetDlgItem(childWindowHandle, DialogResult.No) != null)
                {

                    SetDlgItemText(childWindowHandle, DialogResult.No, _noText);

                }



                if (GetDlgItem(childWindowHandle, DialogResult.Cancel) != null)
                {

                    SetDlgItemText(childWindowHandle, DialogResult.Cancel, _cancelText);

                }



                UnhookWindowsHookEx(_hookHandle);

            }

            else
            {

                CallNextHookEx(_hookHandle, hookCode, wordParameter, longParameter);

            }



            return 0;

        }



        #endregion

    }




}

    

