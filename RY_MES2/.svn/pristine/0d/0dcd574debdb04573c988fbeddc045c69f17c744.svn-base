using DevExpress.Utils.Menu;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Menu;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Data;
using System.Windows.Forms;

namespace RY_MES.Forms
{
    public partial class frm_SPEC_Master : RY_MES.frm_Base
    {
        public frm_SPEC_Master()
        {
            InitializeComponent();
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            _RYMES_DB = _Main._RYMES_DB;

            lc_Conditions.Enabled = false;
            splitContainerControl1.PanelVisibility = SplitPanelVisibility.Panel1;
            splitContainerControl1.SplitterPosition = (Width / 4) * 3;

            //btn_Conditions_Click(null, null);
            btn_Conditions.Enabled = false;

            Get_Data_Grid(gridControl);
            ucGridView view = (gridControl.MainView as ucGridView);
            view.PopupMenuShowing += gridView_PopupMenuShowing;

            Set_Description(lc_edit);
        }

        public void Get_Data_Grid(ucGridControl grid)
        {
            ucGridView view = (gridControl.MainView as ucGridView);

            splitContainerControl1.PanelVisibility = SplitPanelVisibility.Panel1;
            gridControl.Enabled = true;
            DataTable dt = new DataTable();

            string sMsg = _RYMES_DB.GET_DATA("QM_DG_SPEC_MASTER_LOAD", ref dt);
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

        private void SHOW_EDIT(GridView view, object sender)
        {
            splitContainerControl1.SplitterPosition = (Width / 4) * 3;
            splitContainerControl1.PanelVisibility = SplitPanelVisibility.Both;
            view.GridControl.Enabled = false;

            DXMenuItem menu = (DXMenuItem)sender;
            Root.Text = menu.Caption;

            if (menu.Caption == "Add")
            {
                txt_ITEM_CODE.EditValue = null;
                txt_FT_ITEM_CODE.Text = "";
                txt_QC_ITEM_CODE.Text = "";
                txt_SPEC_NAME.Text = "";
                txt_SPEC.Text = "";
                txt_SPEC_DESC.Text = "";

                txt_ITEM_CODE.Enabled = true;
                txt_SPEC_NAME.Enabled = true;

                lc_Delete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            else
            {
                DataRow dataRow = ((DataRowView)view.GetFocusedRow()).Row;

                txt_ITEM_CODE.EditValue = dataRow["ITEM_CODE"].ToString();
                txt_FT_ITEM_CODE.Text = dataRow["FT_ITEM_CODE"].ToString();
                txt_QC_ITEM_CODE.Text = dataRow["QC_ITEM_CODE"].ToString();
                txt_SPEC_NAME.Text = dataRow["SPEC_NAME"].ToString();
                txt_SPEC.Text = dataRow["SPEC"].ToString();
                txt_SPEC_DESC.Text = dataRow["SPEC_DESC"].ToString();

                txt_ITEM_CODE.Enabled = false;
                txt_SPEC_NAME.Enabled = false;

                lc_Delete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_ITEM_CODE.Text) || string.IsNullOrEmpty(txt_SPEC_NAME.Text))
            {
                MessageBox.Show("품목코드, SPEC명은 필수 입력 값입니다.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                _RYMES_DB._DB_Parameters = Get_Conditions_Params(lc_edit.Root);
                _RYMES_DB._DB_Parameters.Add("@p_CREATE_USER", _Main._User_Info["USER_CODE"].ToString());

                string sMsg = _RYMES_DB.SET_DATA("QM_DG_SPEC_MASTER_MERGE");
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

        private void btn_Back_Click(object sender, EventArgs e)
        {
            splitContainerControl1.PanelVisibility = SplitPanelVisibility.Panel1;
            gridControl.Enabled = true;
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            SimpleButton btn = sender as SimpleButton;

            if (DialogResult.OK == MessageBox.Show(btn.Text + "  (" + txt_ITEM_CODE.Text.ToString() + ") " + txt_SPEC_NAME.Text.ToString() + " ?", btn.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            {
                try
                {
                    _RYMES_DB._DB_Parameters.Add("@p_ITEM_CODE", txt_ITEM_CODE.Text.ToString());
                    _RYMES_DB._DB_Parameters.Add("@p_SPEC_NAME", txt_SPEC_NAME.Text.ToString());
                    _RYMES_DB._DB_Parameters.Add("@p_CREATE_USER", _Main._User_Info["USER_CODE"].ToString());

                    string sMsg = _RYMES_DB.SET_DATA("QM_DG_SPEC_MASTER_DELETE");
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

        private void frm_SizeChanged(object sender, EventArgs e)
        {
            splitContainerControl1.SplitterPosition = (Width / 4) * 3;
        }

        private void RegistSpec_Click(object sender, EventArgs e)
        {
            frm_SPEC_Popup popup = new frm_SPEC_Popup();

            if (DialogResult.OK == popup.ShowDialog())
            {
                Get_Data_Grid(gridControl);
            }
        }
    }
}