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
    public partial class frm_OP_Master : RY_MES.frm_Base
    {
        private string op_id = null;

        public frm_OP_Master()
        {
            InitializeComponent();
        }

        public frm_OP_Master(params object[] paramArray)
        {
            InitializeComponent();
            op_id = paramArray[0].ToString();
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            _RYMES_DB = _Main._RYMES_DB;

            lc_Conditions.Enabled = false;
            splitContainerControl1.PanelVisibility = SplitPanelVisibility.Panel1;

            btn_Conditions_Click(null, null);
            btn_Conditions.Enabled = false;

            Get_Data_Grid(gridControl);
            Set_Description(lc_edit);

            ucGridView1.FindFilterText = op_id;
            ucGridView1.PopupMenuShowing += gridView_PopupMenuShowing;
        }

        private void Get_Data_Grid(ucGridControl grid)
        {
            ucGridView view = grid.MainView as ucGridView;

            splitContainerControl1.PanelVisibility = SplitPanelVisibility.Panel1;
            grid.Enabled = true;

            SplashScreenManager.ShowForm(_Main, typeof(frm_Wait), true, true, false);
            try
            {
                DataTable dt = new DataTable();
                string sMsg = _RYMES_DB.GET_DATA("BI_FI_OP_MASTER_LOAD", ref dt);
                if (string.IsNullOrEmpty(sMsg))
                {
                    grid.DataSource = dt;
                }
                else
                {
                    grid.DataSource = null;
                }

                RestoreLayout(this, view);
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
            ucGridControl grid = view.GridControl as ucGridControl;

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

            if (e.MenuType == GridMenuType.Row)
            {
                item = new DXMenuItem("Edit", null, Properties.Resources.edit_16x16);
                item.Click += (o, args) =>
                {
                    SHOW_EDIT(view, o);
                };
                e.Menu.Items.Add(item);
            }

            item = new DXMenuItem("Refresh", null, Properties.Resources.refresh_16x16);
            item.Click += (o, args) =>
            {
                Get_Data_Grid(grid);
            };
            e.Menu.Items.Add(item);

            item = new DXMenuItem("Export", null, Properties.Resources.exporttoxlsx_16x16);
            item.Click += (o, args) =>
            {
                grid.Grid_Export();
            };
            e.Menu.Items.Add(item);
        }

        private void SHOW_EDIT(GridView gridView, object sender)
        {
            splitContainerControl1.SplitterPosition = (Width / 4) * 3;
            splitContainerControl1.PanelVisibility = SplitPanelVisibility.Both;
            gridView.GridControl.Enabled = false;

            DXMenuItem menu = (DXMenuItem)sender;
            Root.Text = menu.Caption;

            DataRow dataRow = ((DataRowView)gridView.GetFocusedRow()).Row;
            SET_LookUpEdit_Data(le_FA_ID, "FA_MASTER");
            SET_LookUpEdit_Data(le_OP_TYPE, "OP_TYPE");

            if (menu.Caption == "Add")
            {
                le_FA_ID.EditValue = dataRow["FA_ID"].ToString();
                txt_OP_ID.Text = "";
                txt_OP_NAME.Text = "";
                txt_OP_DESC.Text = "";
                le_OP_TYPE.EditValue = dataRow["OP_TYPE"].ToString();
                rbg_PLAN_DATE_TYPE.EditValue = "T";
                txt_ORDERBY.Text = "";

                le_FA_ID.Enabled = true;
                txt_OP_ID.Enabled = true;

                layoutControlItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            else
            {
                le_FA_ID.EditValue = dataRow["FA_ID"].ToString();
                txt_OP_ID.Text = dataRow["OP_ID"].ToString();
                txt_OP_NAME.Text = dataRow["OP_NAME"].ToString();
                txt_OP_DESC.Text = dataRow["OP_DESC"].ToString();
                le_OP_TYPE.EditValue = dataRow["OP_TYPE"].ToString();
                rbg_PLAN_DATE_TYPE.EditValue = dataRow["PLAN_DATE_TYPE"].ToString();
                txt_ORDERBY.Text = dataRow["ORDERBY"].ToString();

                le_FA_ID.Enabled = false;
                txt_OP_ID.Enabled = false;

                layoutControlItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                btn_Delete.Text = dataRow["DELETE_USER"].ToString() == "" ? "Delete" : "Restore";
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                _RYMES_DB._DB_Parameters = Get_Conditions_Params(lc_edit.Root);
                _RYMES_DB._DB_Parameters.Add("@p_CREATE_USER", _Main._User_Info["USER_CODE"].ToString());

                string sMsg = _RYMES_DB.SET_DATA("BI_FI_OP_MASTER_MERGE");
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

            if (DialogResult.OK == MessageBox.Show(btn.Text + "  " + txt_OP_NAME.Text + " ?", btn.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            {
                try
                {
                    _RYMES_DB._DB_Parameters.Add("@p_FA_ID", le_FA_ID.EditValue.ToString());
                    _RYMES_DB._DB_Parameters.Add("@p_OP_ID", txt_OP_ID.Text);
                    _RYMES_DB._DB_Parameters.Add("@p_CREATE_USER", _Main._User_Info["USER_CODE"].ToString());

                    string sMsg = _RYMES_DB.SET_DATA("BI_FI_OP_MASTER_DELETE");
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