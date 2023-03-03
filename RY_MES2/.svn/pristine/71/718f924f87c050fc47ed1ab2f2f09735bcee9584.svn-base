using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraTab;
using nsCommon;
using System;
using System.Data;
using System.Windows.Forms;

namespace RY_MES.Forms
{
    public partial class frm_Work_Execution : frm_Base
    {
        /// <summary>
        /// DashBoard 생성자
        /// </summary>
        /// <param name="Main"></param>
        public frm_Work_Execution()
        {
            InitializeComponent();
        }

        public frm_Work_Execution(object[] paramArray)
        {
            InitializeComponent();
        }

        private void frm_Work_Execution_Load(object sender, EventArgs e)
        {
            lc_Conditions.Visible = false;
            _RYMES_DB = _Main._RYMES_DB;

            SplashScreenManager.ShowForm(_Main, typeof(frm_Wait), true, true, false);
            try
            {
                SET_LookUpEdit_Data(sle_CELL, "CELL_MASTER");
                Get_Data();
            }
            finally
            {
                //Close Wait Form
                SplashScreenManager.CloseForm(false);
            }
        }

        public void Get_Data()
        {
            DataTable table = new DataTable();

            _RYMES_DB._DB_Parameters.Add("@p_MACADDR", _Main._MacAddr);
            string sMsg = _RYMES_DB.GET_DATA("WE_CELL_REGISTRATION_LOAD", ref table);
            if (string.IsNullOrEmpty(sMsg))
            {
                foreach (DataRow row in table.Rows)
                {
                    Tab_Create(row["CELL_CODE"].ToString());
                }
            }
            else
            {
                if (sMsg != "Result FirstTable Rows Count is Zero")
                {
                    MessageBox.Show(sMsg, "DB ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void sle_CELL_EditValueChanged(object sender, EventArgs e)
        {
            SearchLookUpEdit searchLook = (SearchLookUpEdit)sender;
            if (!(searchLook.EditValue is null))
            {
                foreach (XtraTabPage page in xtraTabControl1.TabPages)
                {
                    if (page.Tag.ToString() == searchLook.EditValue.ToString())
                    {
                        xtraTabControl1.SelectedTabPage = page;
                        return;
                    }
                }

                _RYMES_DB._DB_Parameters.Add("@p_MACADDR", _Main._MacAddr);
                _RYMES_DB._DB_Parameters.Add("@p_CELL_CODE", searchLook.EditValue.ToString());
                _RYMES_DB._DB_Parameters.Add("@p_CREATE_USER", _Main._User_Info["USER_CODE"].ToString());

                string sMsg = _RYMES_DB.SET_DATA("WE_CELL_REGISTRATION");
                if (string.IsNullOrEmpty(sMsg))
                {
                    Tab_Create(searchLook.EditValue.ToString());
                }
                else
                {
                    MessageBox.Show(sMsg, "DB ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Tab_Create(string CELL_CODE)
        {
            SearchLookUpEdit searchLook = sle_CELL;

            XtraTabPage tabPage = xtraTabControl1.TabPages.Add(CELL_CODE);
            tabPage.Tag = CELL_CODE;

            DataTable table = new DataTable();

            _RYMES_DB._DB_Parameters.Add("@p_CELL_CODE", CELL_CODE);
            string sMsg = _RYMES_DB.GET_DATA("WE_CELL_INFO_LOAD", ref table);
            frm_Base frm_Cell = new frm_Base();
            if (table.Rows[0]["OP_TYPE"].ToString() == "0005")
            {
                frm_Cell = new frm_Cell_CSI_4Cell(_Main, this);
                frm_Cell.Text = table.Rows[0]["EQUIP_ID"].ToString();
                tabPage.Text = table.Rows[0]["EQUIP_ID"].ToString();
            }
            else if (table.Rows[0]["FA_ID"].ToString() != "CMOS")
            {
                frm_Cell = new frm_Cell_TFT(_Main, this);
                frm_Cell.Text  = CELL_CODE;
                tabPage.Text = table.Rows[0]["CELL_NAME"].ToString();
            }
            else
            {
                frm_Cell = new frm_Cell(_Main, this);
                frm_Cell.Text = CELL_CODE;
            }
            frm_Cell._RYMES_DB = _RYMES_DB;
            frm_Cell.Dock = DockStyle.Fill;
            frm_Cell.Tag = tabPage;
            frm_Cell.Show();
            tabPage.Controls.Add(frm_Cell);

            xtraTabControl1.SelectedTabPage = tabPage;
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            if (!(xtraTabControl1.SelectedTabPage is null))
            {
                if (!(xtraTabControl1.SelectedTabPage.Tag is null))
                {
                    sle_CELL.EditValue = xtraTabControl1.SelectedTabPage.Tag;
                }
            }
        }
    }
}