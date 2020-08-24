using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace MES
{
    static class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Process[] procs = Process.GetProcessesByName("MES");
            // 두번 이상 실행되었을 때 처리할 내용을 작성합니다.

            if (procs.Length > 1)
            {
                DialogResult DR=MessageBox.Show("프로그램이 이미 실행되고 있습니다.\n 그래도 실행하시겠습니까???.","중복확인",MessageBoxButtons.YesNo);

                if (DR == DialogResult.No)
                {
                    return;

                }
                else
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                   
                    Application.Run(new frmLogin());
                

                }
            }
            
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                // Application.Run(new frmMain());
                Application.Run(new frmLogin());
                //Application.Run(new P90_SYS.Form1());
            }

            
        }
    }
}
