using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace nsCommon
{
    public partial class frm_LogIn : XtraForm
    {
        public DbHandle _dbHandle { get; set; }
        public DataRow _User_Info { get; set; }
        public string file_Path { get; set; }
        public bool isSwap { get; set; }
        public string SwapPath { get; set; }

        public frm_LogIn(DbHandle dbHandle)
        {
            InitializeComponent();
            _dbHandle = dbHandle;
        }

        private void frm_LogIn_Load(object sender, EventArgs e)
        {
            txt_UID.Text = clsAppConfiguration.GetAppConfig(AppConfig.USER_ID); 
            if (!string.IsNullOrEmpty(txt_UID.Text))
            {
                ActiveControl = txt_PWD;
                chk_Remember.Checked = true;
            }

            if (Assembly.GetEntryAssembly().Location.IndexOf("_UPDATE.exe") < 0)
            {
                timer1.Enabled = true;

                txt_UID.Enabled = false;
                txt_PWD.Enabled = false;
                btn_Login.Enabled = false;
                chk_Remember.Enabled = false;

                lbl_Error.Text = "Update를 확인중입니다.";
            }
            else
            {
                progressBarControl1.Visible = false;
                UpdateFiles();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int progressBar = (int)progressBarControl1.EditValue + 5;
            progressBarControl1.EditValue = progressBar;

            if (progressBar >= 100)
            {
                timer1.Enabled = false;
                Run_updateFiles();
            }
        }

        private void Run_updateFiles()
        {
            Application.DoEvents();
            UpdateFiles();
            if (isSwap)
            {
                lbl_Error.Text = "Progam을 다시 시작 합니다. 잠시만 기다려 주십시오.";
                Application.DoEvents();
                Thread.Sleep(3000);

                Process.Start(SwapPath);
                Application.Exit();
                return;
            }
            progressBarControl1.Visible = false;
            txt_UID.Enabled = true;
            txt_PWD.Enabled = true;
            btn_Login.Enabled = true;
            chk_Remember.Enabled = true;
            lbl_Error.Text = "";
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(frm_Wait), true, true, false);
            try
            {
                LogIn();
            }
            finally
            {
                SplashScreenManager.CloseForm(false);
            }
        }

        private void LogIn()
        {
            _User_Info = null;
            lbl_Error.Text = "";

            string hashedPassword = Sha256encrypt(txt_PWD.Text.ToUpper());

            if(txt_UID.Text.ToUpper() == "TEST")
            {
                _dbHandle = new DbHandle("DEV_DB");
                _dbHandle._DbConnectionStringBuilder.Add("User ID", "vatech");
                _dbHandle._DbConnectionStringBuilder.Add("Password", "6006deok!@34");
            }


            _dbHandle._DB_Parameters.Add("@p_user_code", txt_UID.Text.ToUpper());
            _dbHandle._DB_Parameters.Add("@p_user_password", hashedPassword);

            DataTable dt = new DataTable();
            string sMsg = _dbHandle.GET_DATA("SYS_LOGIN_CHK", ref dt);
            if (string.IsNullOrEmpty(sMsg))
            {
                if (dt.Rows[0]["LOGIN_YN"].ToString() == "Y")
                {
                    _User_Info = dt.Rows[0];
                    if (chk_Remember.Checked)
                    {
                        clsAppConfiguration.SetAppConfig(AppConfig.USER_ID, txt_UID.Text);
                    }
                    Close();
                    return;
                }
                else
                {
                    lbl_Error.Text = "Password Error";
                }
            }
            else
            {
                if (sMsg == "Result FirstTable Rows Count is Zero")
                {
                    lbl_Error.Text = "User ID Error";
                }
                else
                {
                    MessageBox.Show(sMsg, "DB ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            _User_Info = null;
        }

        private void txt_UID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
            {
                txt_PWD.Focus();
            }
        }

        private void txt_PWD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
            {
                btn_Login_Click(null, null);
            }
        }

        private void frm_LogIn_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_User_Info is null)
            {
                Application.Exit();
            }
        }

        public string Sha256encrypt(string sValue)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(sValue));

                // Convert byte array to a string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void UpdateFiles()
        {
            file_Path = Assembly.GetEntryAssembly().Location;
            isSwap = false;
            FileInfo fhSwap = new FileInfo(file_Path);
            if (file_Path.IndexOf("_UPDATE.exe") < 0)
            {
                Update_Files();
            }
            else
            {
                fhSwap.CopyTo(file_Path.Replace("_UPDATE.exe", ".exe"), true);
            }
        }

        private void Update_Files() 
        {
            string fileNames = Get_Update_Files_FullName();
            try
            {
                DataTable dt = new DataTable();
                string sExMsg = _dbHandle.GET_DATA(@"SELECT FILE_NAME, FILE_PATH, UPDATE_DATE, FILE_DATA FROM PGM_MGT WHERE  FILE_PATH + FILE_NAME  IN (" + fileNames + ")", ref dt);
                if (sExMsg == null || sExMsg == "Result FirstTable Rows Count is Zero")
                {
                    if (dt.Rows.Count > 0)
                    {
                        progressBarControl1.Properties.Maximum = dt.Rows.Count;
                        progressBarControl1.EditValue = 0;
                    }
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string sPath = dt.Rows[i][1].ToString();
                        if (dt.Rows[i]["FILE_PATH"].ToString()[(dt.Rows[i]["FILE_PATH"].ToString().Length - 1)].ToString() != @"\")
                        {
                            sPath = dt.Rows[i]["FILE_PATH"] + @"\";
                        }

                        string fullName = sPath + dt.Rows[i]["FILE_NAME"].ToString();

                        FileInfo fileInfo = new FileInfo(fullName);
                        if (fileInfo.Exists)
                        {
                            if (file_Path == fileInfo.FullName)
                            {
                                fullName = file_Path.Replace(".exe", "_UPDATE.exe");

                                FileInfo fileInfo_config = new FileInfo(file_Path + ".config");
                                fileInfo_config.CopyTo(fileInfo_config.Name.Replace(".exe.config", "_UPDATE.exe.config"), true);

                                SwapPath = fullName;
                                isSwap = true;
                            }
                        }
                        Filehandle fhDown = new Filehandle(fullName, false);

                        byte[] bFile;

                        bFile = (byte[])dt.Rows[i]["FILE_DATA"];
                        fhDown.BinaryToFile(bFile);

                        progressBarControl1.EditValue = i + 1;
                        Application.DoEvents();
                        Thread.Sleep(100);
                    }
                }
                else
                {
                    MessageBox.Show(sExMsg, "DB  Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private string Get_Update_Files_FullName()
        {
            string fileNames = "";
            try
            {
                DataTable dt = new DataTable();
                string sExMsg = _dbHandle.GET_DATA(@"SELECT FILE_NAME, FILE_PATH, UPDATE_DATE FROM PGM_MGT", ref dt);

                if (sExMsg == null || sExMsg == "Result FirstTable Rows Count is Zero")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string sPath = dt.Rows[i]["FILE_PATH"].ToString();
                        if (dt.Rows[i]["FILE_PATH"].ToString()[(dt.Rows[i]["FILE_PATH"].ToString().Length - 1)].ToString() != @"\")
                        {
                            sPath = dt.Rows[i][1] + @"\";
                        }

                        Filehandle fhDown = new Filehandle(sPath + dt.Rows[i]["FILE_NAME"].ToString(), false);
                        if (fhDown._FileInfo.Exists)
                        {
                            if (fhDown._FileInfo.LastWriteTime < DateTime.Parse(dt.Rows[i]["UPDATE_DATE"].ToString()))
                            {
                                fileNames += "'" + dt.Rows[i]["FILE_PATH"].ToString() + dt.Rows[i]["FILE_NAME"].ToString() + "',";
                            }
                        }
                        else
                        {
                            fileNames += "'" + dt.Rows[i]["FILE_PATH"].ToString() + dt.Rows[i]["FILE_NAME"].ToString() + "',";
                        }
                    }

                    fileNames = fileNames != "" ? fileNames.Remove(fileNames.Length - 1) : fileNames;
                    fileNames = string.IsNullOrEmpty(fileNames) ? "''" : fileNames;
                }
                else
                {
                    MessageBox.Show(sExMsg, "DB  Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return fileNames;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return fileNames;
            }
        }
    }
}