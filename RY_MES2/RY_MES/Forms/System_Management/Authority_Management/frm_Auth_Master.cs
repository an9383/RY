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
    public partial class frm_Auth_Master : RY_MES.frm_Base
    {
        public frm_Auth_Master()
        {
            InitializeComponent();
        }

        public frm_Auth_Master(object[] paramArray)
        {
            InitializeComponent();
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            _RYMES_DB = _Main._RYMES_DB;

            lc_Conditions.Enabled = false;
            splitContainerControl1.PanelVisibility = SplitPanelVisibility.Panel1;
            (gridControl.MainView as ucGridView).PopupMenuShowing += gridView_PopupMenuShowing;

            btn_Conditions_Click(null, null);
            btn_Conditions.Enabled = false;
            Get_Data_Grid(gridControl);
            Set_Description(lc_edit);
        }

        private void Get_Data_Grid(ucGridControl grid)
        {
            ucGridView view = (grid.MainView as ucGridView);
            splitContainerControl1.PanelVisibility = SplitPanelVisibility.Panel1;
            grid.Enabled = true;

            SplashScreenManager.ShowForm(_Main, typeof(frm_Wait), true, true, false);
            try
            {
                DataTable dt = new DataTable();
                string sMsg = _RYMES_DB.GET_DATA("SM_AM_AUTH_MASTER_LOAD", ref dt);
                if (string.IsNullOrEmpty(sMsg))
                {
                    grid.DataSource = dt;
                    view.Link_Column("AUTH_CODE", "frm_Auth_Detail");
                }
                else
                {
                    grid.DataSource = null;
                }

                RestoreLayout(this, (grid.MainView as ucGridView));
            }
            finally
            {
                SplashScreenManager.CloseForm(false);
                grid.Focus();
            }
        }

        private void gridView_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            GridView view = sender as GridView;
            DXMenuItem item;

            if (e.Menu == null)
            {
                e.Menu = new GridViewMenu(view);
            }

            item = new DXMenuItem("Add", null, Properties.Resources.add_16x16);
            item.Click += (o, args) =>
            {
                SHOW_EDIT(view, o);
            };
            e.Menu.Items.Add(item);

            item = new DXMenuItem("Refresh", null, Properties.Resources.refresh_16x16);
            item.Click += (o, args) =>
            {
                Get_Data_Grid(gridControl);
            };
            e.Menu.Items.Add(item);

            item = new DXMenuItem("Export", null, Properties.Resources.exporttoxlsx_16x16);
            item.Click += (o, args) =>
            {
                gridControl.Grid_Export();
            };
            e.Menu.Items.Add(item);

            if (e.MenuType == GridMenuType.Row)
            {
                item = new DXMenuItem("Edit", null, Properties.Resources.edit_16x16);
                item.Click += (o, args) =>
                {
                    SHOW_EDIT(view, o);
                };
                e.Menu.Items.Add(item);
            }
        }

        private void SHOW_EDIT(GridView gridView, object sender)
        {
            splitContainerControl1.SplitterPosition = (Width / 4) * 3;
            splitContainerControl1.PanelVisibility = SplitPanelVisibility.Both;
            gridView.GridControl.Enabled = false;

            DXMenuItem menu = (DXMenuItem)sender;

            Root.Text = menu.Caption;

            if (menu.Caption == "Add")
            {
                txt_AUTH_CODE.Text = "";
                txt_AUTH_NAME.Text = "";
                txt_AUTH_DESC.Text = "";
                txt_ORDERBY.Text = "";
                txt_DESC1.Text = "";
                txt_DESC2.Text = "";

                txt_AUTH_CODE.Enabled = true;
                btn_Delete.Visible = false;
            }
            else
            {
                DataRow dataRow = ((DataRowView)gridView.GetFocusedRow()).Row;

                txt_AUTH_CODE.Text = dataRow["AUTH_CODE"].ToString();
                txt_AUTH_NAME.Text = dataRow["AUTH_NAME"].ToString();
                txt_AUTH_DESC.Text = dataRow["AUTH_DESC"].ToString();
                txt_ORDERBY.Text = dataRow["ORDERBY"].ToString();
                txt_DESC1.Text = dataRow["DESC1"].ToString();
                txt_DESC2.Text = dataRow["DESC2"].ToString();

                txt_AUTH_CODE.Enabled = false;
                btn_Delete.Visible = true;
                btn_Delete.Text = dataRow["DELETE_USER"].ToString() == "" ? "Delete" : "Restore";
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                _RYMES_DB._DB_Parameters = Get_Conditions_Params(lc_edit.Root);
                _RYMES_DB._DB_Parameters.Add("@p_CREATE_USER", _Main._User_Info["USER_CODE"].ToString());

                string sMsg = _RYMES_DB.SET_DATA("SM_AM_AUTH_MASTER_MERGE");
                if (string.IsNullOrEmpty(sMsg))
                {
                    MessageBox.Show("Save Success", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Get_Data_Grid(gridControl);
                }
                else
                {
                    MessageBox.Show(sMsg, "DB ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            SimpleButton btn = sender as SimpleButton;

            if (DialogResult.OK == MessageBox.Show(btn.Text + "  " + txt_AUTH_NAME.Text + " ?", btn.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            {
                DataRow dr = ((DataRowView)(gridControl.MainView as ucGridView).GetFocusedRow()).Row;

                try
                {
                    _RYMES_DB._DB_Parameters.Add("@p_AUTH_CODE", dr["AUTH_CODE"].ToString());
                    _RYMES_DB._DB_Parameters.Add("@p_ORDERBY", dr["ORDERBY"].ToString());
                    _RYMES_DB._DB_Parameters.Add("@p_CREATE_USER", _Main._User_Info["USER_CODE"].ToString());

                    string sMsg = _RYMES_DB.SET_DATA("SM_AM_AUTH_MASTER_DELETE");
                    if (string.IsNullOrEmpty(sMsg))
                    {
                        MessageBox.Show("Success", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(sMsg, "DB ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                finally
                {
                    Get_Data_Grid(gridControl);
                }
            }
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            splitContainerControl1.PanelVisibility = SplitPanelVisibility.Panel1;
            gridControl.Enabled = true;
        }

        private void frm_SizeChanged(object sender, EventArgs e)
        {
            splitContainerControl1.SplitterPosition = (Width / 4) * 3;
        }
    }
}