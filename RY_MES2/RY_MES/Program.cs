using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace RY_MES
{
    internal static class Program
    {
        public static frm_Main _Main { get; set; }
        public static string PGM_Name { get; set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.SetCompatibleTextRenderingDefault(false);
            FileInfo fileInfo = new FileInfo(Assembly.GetEntryAssembly().Location);
            PGM_Name = "RY_MES";

            if (fileInfo.Name.IndexOf("_UPDATE.exe") > 0)
            {
                PGM_Name = "RY_MES_UPDATE";
            }

            PGM_Name = "RY_MES_UPDATE";

            Mutex mutex = new Mutex(true, PGM_Name, out bool isExecuted);

            if (isExecuted)
            {
                Application.SetCompatibleTextRenderingDefault(false);

                _Main = new frm_Main();
                Application.Run(_Main);
                mutex.ReleaseMutex();
            }
            else
            { 
                MessageBox.Show("ERROR_PROGRAM_IS_RUNNING");
                Application.Exit();
            }
        }
    }
}