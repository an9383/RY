using DevExpress.Utils.Menu;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Menu;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using nsCommon;
using System;
using System.Data;
using System.Windows.Forms;

namespace RY_MES.Forms
{
    public partial class frm_USER_Master : frm_Base
    {
        public frm_USER_Master()
        {
            InitializeComponent();
        }

        public frm_USER_Master(object[] paramArray)
        {
            InitializeComponent();
        }

        private void frm_Load(object sender, EventArgs e)
        {
            _RYMES_DB = _Main._RYMES_DB;

            splitContainerControl1.PanelVisibility = SplitPanelVisibility.Panel1;

            btn_Conditions_Click(null, null);
            btn_Conditions.Enabled = false;

            btn_Search_Click(null, null);
            Set_Description(lc_edit);

            ucGridView1.PopupMenuShowing += gridView_PopupMenuShowing;
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(_Main, typeof(frm_Wait), true, true, false);
            try
            {
                Get_Data_Grid();
            }
            finally
            {
                SplashScreenManager.CloseForm(false);
                ucGridControl1.Focus();
            }
        }

        public void Get_Data_Grid()
        {
            splitContainerControl1.PanelVisibility = SplitPanelVisibility.Panel1;
            ucGridControl1.Enabled = true;

            DataTable table = new DataTable();

            string sMsg = _RYMES_DB.GET_DATA("SM_USER_MASTER_LOAD", ref table);
            if (string.IsNullOrEmpty(sMsg))
            {
                ucGridControl1.DataSource = table;
                ucGridView1.Columns["DEPT"].Group();
            }
            else
            {
                ucGridControl1.DataSource = null;
            }

            RestoreLayout(this, ucGridView1);
        }

        private void gridView_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            GridView view = (GridView)sender;
            ucGridControl grid = view.GridControl as ucGridControl;
            if (e.MenuType == GridMenuType.Row)
            {
                DXMenuItem item;

                item = new DXMenuItem("Add", null);
                item.Click += (o, args) => { SHOW_EDIT(view, o); };
                e.Menu.Items.Add(item);

                item = new DXMenuItem("Edit", null);
                item.Click += (o, args) =>
                {
                    if (view.GetSelectedRows().Length > 0)
                    {
                        SHOW_EDIT(view, o);
                    }
                };
                e.Menu.Items.Add(item);

                item = new DXMenuItem("Refresh", null);
                item.Click += (o, args) => { btn_Search_Click(null, null); };
                item.BeginGroup = true;
                e.Menu.Items.Add(item);

                item = new DXMenuItem("Export", null);
                item.Click += (o, args) => { grid.Grid_Export(); };
                item.BeginGroup = true;
                e.Menu.Items.Add(item);
            }
            if (e.MenuType == GridMenuType.User)
            {
                if (e.Menu == null)
                {
                    e.Menu = new GridViewMenu(view);
                }
                DXMenuItem item;

                item = new DXMenuItem("Add", null);
                item.Click += (o, args) => { SHOW_EDIT(view, o); };
                e.Menu.Items.Add(item);

                item = new DXMenuItem("Refresh", null);
                item.Click += (o, args) => { btn_Search_Click(null, null); };
                item.BeginGroup = true;
                e.Menu.Items.Add(item);
            }
        }

        private void SHOW_EDIT(GridView gridView, object sender)
        {
            splitContainerControl1.SplitterPosition = (Width / 4) * 3;
            splitContainerControl1.PanelVisibility = SplitPanelVisibility.Both;

            gridView.GridControl.Enabled = false;

            SET_LookUpEdit_Data(lg_DEPT_CODE, "DEPT_MASTER");
            SET_LookUpEdit_Data(lg_AUTH_CODE, "AUTH_MASTER");

            DXMenuItem menu = (DXMenuItem)sender;

            Root.Text = menu.Caption;

            if (menu.Caption == "Add")
            {
                txt_USER_CODE.Text = "";
                txt_USER_NAME.Text = "";
                lg_DEPT_CODE.EditValue = null;
                lg_AUTH_CODE.EditValue = null;
                txt_EMAIL_ADDR.Text = "";
                txt_CELL_PHONE.Text = "";
                txt_OFFICE_PHONE.Text = "";
                txt_COMPANY_CODE.Text = "";
                txt_DESC1.Text = "";
                txt_DESC2.Text = "";

                txt_USER_CODE.Enabled = true;
                txt_USER_NAME.Enabled = true;
                lg_DEPT_CODE.Enabled = true;
                txt_EMAIL_ADDR.Enabled = true;
                txt_CELL_PHONE.Enabled = true;
                txt_OFFICE_PHONE.Enabled = true;
                txt_COMPANY_CODE.Enabled = true;

                btn_Delete.Visible = false;
                btn_Reset.Visible = false;
            }
            else
            {
                DataRow dataRow = ((DataRowView)gridView.GetFocusedRow()).Row;

                txt_USER_CODE.Text = dataRow["USER_CODE"].ToString().Trim();
                txt_USER_NAME.Text = dataRow["USER_NAME"].ToString();
                lg_DEPT_CODE.EditValue = dataRow["DEPT_CODE"].ToString();
                lg_AUTH_CODE.EditValue = dataRow["AUTH_CODE"].ToString();
                txt_EMAIL_ADDR.Text = dataRow["EMAIL_ADDR"].ToString();
                txt_CELL_PHONE.Text = dataRow["CELL_PHONE"].ToString();
                txt_OFFICE_PHONE.Text = dataRow["OFFICE_PHONE"].ToString();
                txt_COMPANY_CODE.Text = dataRow["COMPANY_CODE"].ToString();
                txt_DESC1.Text = dataRow["DESC1"].ToString();
                txt_DESC2.Text = dataRow["DESC2"].ToString();

                txt_USER_CODE.Enabled = false;
                txt_USER_NAME.Enabled = false;
                lg_DEPT_CODE.Enabled = false;
                txt_EMAIL_ADDR.Enabled = false;
                txt_CELL_PHONE.Enabled = false;
                txt_OFFICE_PHONE.Enabled = false;
                txt_COMPANY_CODE.Enabled = false;

                btn_Delete.Visible = true;
                btn_Reset.Visible = true;
                btn_Delete.Text = dataRow["DELETE_USER"].ToString() == "" ? "Delete" : "Restore";
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == MessageBox.Show(((SimpleButton)sender).Text + "  " + txt_USER_NAME.Text + " ?", ((SimpleButton)sender).Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            {
                _RYMES_DB._DB_Parameters.Add("@p_USER_CODE", txt_USER_CODE.Text);
                _RYMES_DB._DB_Parameters.Add("@p_CREATE_USER", _Main._User_Info["USER_CODE"].ToString());
                ;
                string sMsg = _RYMES_DB.SET_DATA("SM_USER_MASTER_DELETE");
                if (string.IsNullOrEmpty(sMsg))
                {
                    MessageBox.Show("Success", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(sMsg, "DB ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                btn_Search_Click(null, null);
            }
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            btn_Search_Click(null, null);
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == MessageBox.Show(" Password Reset " + txt_USER_NAME.Text + " ?", "Password Reset", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            {
                _RYMES_DB._DB_Parameters.Add("@p_USER_CODE", txt_USER_CODE.Text);
                _RYMES_DB._DB_Parameters.Add("@p_CREATE_USER", _Main._User_Info["USER_CODE"].ToString());

                string sMsg = _RYMES_DB.SET_DATA("SM_USER_MASTER_RESET");
                if (string.IsNullOrEmpty(sMsg))
                {
                    MessageBox.Show("Save Success", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(sMsg, "DB ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                btn_Search_Click(null, null);
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            _RYMES_DB._DB_Parameters = Get_Conditions_Params(lc_edit.Root);
            _RYMES_DB._DB_Parameters.Add("@p_CREATE_USER", _Main._User_Info["USER_CODE"].ToString());

            string sMsg = _RYMES_DB.SET_DATA("SM_USER_MASTER_MERGE");
            if (string.IsNullOrEmpty(sMsg))
            {
                MessageBox.Show("Save Success", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(sMsg, "DB ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            btn_Search_Click(null, null);
        }

        private void frm_SizeChanged(object sender, EventArgs e)
        {
            splitContainerControl1.SplitterPosition = (Width / 4) * 3;
        }
    }
}