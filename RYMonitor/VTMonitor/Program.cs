using DevExpress.LookAndFeel;
using SmartMES.Common;
using System;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using VTMonitor.Common;

namespace VTMonitor
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            InstalledFontCollection installedFontCollection = new InstalledFontCollection();
            bool isFontInstall = false;
            foreach (FontFamily fontFamily in installedFontCollection.Families)
            {
                if (fontFamily.Name.Equals("Pretendard SemiBold"))
                {
                    isFontInstall = true;
                }
            }

            if (!isFontInstall)
            {
                Shell32.Shell shell = new Shell32.Shell();
                Shell32.Folder fontFolder = shell.NameSpace(0x14);
                fontFolder.CopyHere(Application.StartupPath + @"\Fonts\Pretendard-SemiBold.ttf");
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Mutex mutex = new Mutex(true, "RYMonitor", out bool isExecuted);

            if (isExecuted)
            {
                try
                {
                    //테스트
                    WrGlobal.SQL_SERVER = "VT-MESLOTDB-SVR01";
                    WrGlobal.SQL_Database = "CAMDB";
                    WrGlobal.SQL_Id = "sa";
                    WrGlobal.SQL_Password = "infodba";

                    //운영
                    //WrGlobal.SQL_SERVER = "10.10.50.61";
                    //WrGlobal.SQL_Database = "CAMDB";
                    //WrGlobal.SQL_Id = "Vatech";
                    //WrGlobal.SQL_Password = "Rkddkwl2014!@";

                    Application.Run(new frmEmployeeWork());

                    mutex.ReleaseMutex();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("프로그램이 이미 실행중 입니다.");
                Application.Exit();
            }

        }
    }
}
