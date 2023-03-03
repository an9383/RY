using DevExpress.XtraBars.Navigation;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraTab;
using nsCommon;
using System;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Windows.Forms;

namespace RY_MES
{
    public partial class frm_Main : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public DataRow _User_Info { get; set; }
        public string _IPAddr { get; }
        public string _MacAddr { get; }
        public string _HostName { get; }
        public DbHandle _RYMES_DB { get; set; }

        public DataTable dt_Description;

        public Version version { get; set; }
        public DateTime dtBuild { get; set; }

        public frm_Main()
        {
            InitializeComponent();
            Visible = false;
            SplashScreenManager.ShowForm(this, typeof(frm_Wait), true, true, false);
            try
            {
                version = Assembly.GetExecutingAssembly().GetName().Version;
                //barButtonItem1.Caption = "Ver." + version.ToString();

                if (DB_Connect())
                {
                    _User_Info = null;

                    _HostName = Dns.GetHostName();
                    IPAddress[] addr = Dns.GetHostEntry(_HostName).AddressList;

                    _IPAddr = addr[addr.Length - 1].ToString();
                    _MacAddr = string.Join(":", NetworkInterface.GetAllNetworkInterfaces()[0].GetPhysicalAddress().GetAddressBytes().Select(b => b.ToString("X2")));
                }
                else
                {
                }
            }
            finally
            {
                //Close Wait Form
                SplashScreenManager.CloseForm(false);
            }
        }

        private bool DB_Connect()
        {
            _RYMES_DB = new DbHandle("RYMES_DB");
            _RYMES_DB._DbConnectionStringBuilder.Add("User ID", "vatech");
            _RYMES_DB._DbConnectionStringBuilder.Add("Password", "6006deok!@34");

            if (_RYMES_DB._Connection == null || _RYMES_DB._Connection.State != ConnectionState.Open)
            {
                //_RYMES_DB._ConnectionStringSettings.ConnectionString.

                string Error_Message = _RYMES_DB.Open();
                if (Error_Message == null)
                {
                    return true;
                }
                else
                {
                    //DB 접속 Error 처리 ( MSG BOX, LOG )
                    MessageBox.Show(Error_Message, "DB ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //frm_Base.Write_LOG("[DB_FAILED]" + Environment.NewLine + Error_Message, true);

                    return false;
                }
            }
            return false;
        }

        private void frm_Main_Load(object sender, EventArgs e)
        {
            init_Form();

            frm_LogIn LogIn = new frm_LogIn(_RYMES_DB);
            LogIn.ShowDialog();

            _User_Info = LogIn._User_Info;
            _RYMES_DB = LogIn._dbHandle;

            if (_User_Info == null)
            {
                Application.Exit();
                APP_HISTORY_INSERT("LOGIN FAIL");
                return;
            }
            APP_HISTORY_INSERT("LOGIN");
            Get_Description();
            Set_Menu("");
            Visible = true;

            Chaild_Load("frm_DashBoard");

        }

        private void init_Form()
        {
            _User_Info = null;
            if (accordionControl1.Elements.Count > 0)
            {
                accordionControl1.Elements.Clear();
            }
        }

        public void Get_Description()
        {
            string sMsg = _RYMES_DB.GET_DATA("SELECT * FROM v_DESCRIPTION", ref dt_Description);
            if (!string.IsNullOrEmpty(sMsg))
            {
                MessageBox.Show(sMsg, "DB ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Set_Menu(string MENU_CODE)
        {
            Set_Menu(MENU_CODE, null);
        }

        public void Set_Menu(string MENU_CODE, AccordionControlElement _accordionControlElement)
        {
            DataSet ds = new DataSet();

            _RYMES_DB._DB_Parameters.Add("@p_auth", _User_Info["AUTH_CODE"].ToString());
            _RYMES_DB._DB_Parameters.Add("@p_super", MENU_CODE);
            string sMsg = _RYMES_DB.GET_DATA("SYS_MENU_LOAD", ref ds);
            if (string.IsNullOrEmpty(sMsg))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    AccordionControlElement accordionControlElement = new AccordionControlElement
                    {
                        Expanded = false,
                        Name = dr["MENU_CODE"].ToString(),
                        Text = dr["MENU_NAME"].ToString(),
                        Tag = dr["MENU_URL"].ToString() 
                    };

                    if (int.Parse(dr["SUBCNT"].ToString()) == 0)
                    {
                        accordionControlElement.Style = ElementStyle.Item;
                        accordionControlElement.Click += (sender, e) => Chaild_Load((AccordionControlElement)sender);
                    }
                    else
                    {
                        Set_Menu(dr["MENU_CODE"].ToString(), accordionControlElement);
                    }

                    if (string.IsNullOrEmpty(MENU_CODE))
                    {
                        accordionControl1.Elements.Add(accordionControlElement);
                        accordionControlElement.ImageOptions.Image = null;
                    }
                    else
                    {
                        _accordionControlElement.Elements.Add(accordionControlElement);
                    }
                }
            }
            else
            {
                MessageBox.Show(sMsg, "DB ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Chaild_Load(string formName)
        {
            Chaild_Load(Get_AccordionControlElement(accordionControl1.Elements, formName));
        }

        public void Chaild_Load(string formName, params object[] paramArray)
        {
            Chaild_Load(Get_AccordionControlElement(accordionControl1.Elements, formName), paramArray);
        }

        private AccordionControlElement Get_AccordionControlElement(AccordionControlElementCollection elements, string formName)
        {
            foreach (AccordionControlElement _accordionControlElement in elements)
            {
                if (_accordionControlElement.Elements.Count > 0)
                {
                    AccordionControlElement accordionControlElement = Get_AccordionControlElement(_accordionControlElement.Elements, formName);
                    if (!(accordionControlElement is null))
                    {
                        return accordionControlElement;
                    }
                }
                else
                {
                    if (_accordionControlElement.Tag.ToString() == formName)
                    {
                        return _accordionControlElement;
                    }
                }
            }

            return null;
        }

        public void Chaild_Load(AccordionControlElement accordionControlElement)
        {
            Chaild_Load(accordionControlElement, null);
        }

        public void Chaild_Load(AccordionControlElement accordionControlElement, params object[] paramArray)
        {
            Type type = Type.GetType(GetType().Namespace + ".Forms." + accordionControlElement.Tag.ToString() + "," + Assembly.GetExecutingAssembly().GetName().Name);
            if (!(type is null))
            {
                frm_Base frm = (frm_Base)Activator.CreateInstance(type, paramArray);
                if (!(frm is null))
                {
                    Dock = DockStyle.Fill;
                    frm.Name = "tp_" + accordionControlElement.Name;
                    frm.Text = accordionControlElement.Text;
                    frm.Tag = accordionControlElement.Tag;

                    Chaild_Load(frm);
                }
                else
                {
                    MessageBox.Show("Null or Not Mapping Menu", "MENU ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Null or Not Mapping Menu", "MENU ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Chaild_Load(frm_Base frm)
        {
            SplashScreenManager.ShowForm(this, typeof(frm_Wait), true, true, false);
            try
            {
                foreach (XtraTabPage TabPage in xtraTabControl1.TabPages)
                {
                    if (TabPage.Name == "tp_" + frm.Text)
                    {
                        xtraTabControl1.TabPages.Remove(TabPage);
                        TabPage.Dispose();
                        break;
                    }
                }

                XtraTabPage xtraTabPage = new XtraTabPage
                {
                    Name = "tp_" + frm.Text,
                    Text = frm.Text,
                    Tag = frm.Name
                };

                xtraTabControl1.TabPages.Add(xtraTabPage);
                xtraTabControl1.SelectedTabPage = xtraTabPage;
                xtraTabControl1.TabPages.Move(0, xtraTabPage);

                DevExpress.XtraEditors.PanelControl panelControl = new DevExpress.XtraEditors.PanelControl
                {
                    Dock = DockStyle.Fill,
                    Name = "pnl_" + frm.Text,
                    TabIndex = 0
                };

                xtraTabPage.Controls.Add(panelControl);

                // Assembly cuasm = Assembly.GetExecutingAssembly();
                if (!(frm is null))
                {
                    panelControl.Visible = false;
                    panelControl.Controls.Add(frm);
                    frm.Dock = DockStyle.Fill;
                    frm.Show();
                    panelControl.Visible = true;
                }
                else
                {
                    SplashScreenManager.CloseForm(false);
                    MessageBox.Show("Null or Not Mapping Menu", "MENU ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    xtraTabControl1.TabPages.Remove(xtraTabControl1.SelectedTabPage);
                }
            }
            finally
            {
                //Close Wait Form
                SplashScreenManager.CloseForm(false);
            }
        }

        public void xtraTabControl1_CloseButtonClick(object sender, EventArgs e)
        {
            if (xtraTabControl1.TabPages.Count > 1)
            {
                xtraTabControl1.TabPages.Remove(xtraTabControl1.SelectedTabPage);
            }
            xtraTabControl1.SelectedTabPage = xtraTabControl1.TabPages[0];
        }

        private void frm_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (DialogResult.OK != MessageBox.Show("Are you sure you want to exit the application?", "Exit", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
                {
                    e.Cancel = true;
                    return;
                }
            }
            if (_RYMES_DB._Connection.State == ConnectionState.Open)
            {
                APP_HISTORY_INSERT(e.CloseReason.ToString());
            }
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            if (!(e.Page is null))
            {
                APP_HISTORY_INSERT(e.Page.Text);
                xtraTabControl1.TabPages.Move(0, e.Page);
            }
        }

        private void APP_HISTORY_INSERT(string HIS_GUBUN)
        {
            _RYMES_DB._DB_Parameters.Add("@p_user_code", _User_Info is null ? "" : _User_Info["USER_CODE"].ToString().ToUpper());
            _RYMES_DB._DB_Parameters.Add("@p_his_gubun", HIS_GUBUN);
            _RYMES_DB._DB_Parameters.Add("@p_his_ipaddr", _IPAddr);
            _RYMES_DB._DB_Parameters.Add("@p_his_macaddr", _MacAddr);

            string sMsg = _RYMES_DB.SET_DATA("SYS_APP_HISTORY_INSERT");
            if (string.IsNullOrEmpty(sMsg))
            {
                return;
            }
            else
            {
                MessageBox.Show(sMsg, "DB ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}