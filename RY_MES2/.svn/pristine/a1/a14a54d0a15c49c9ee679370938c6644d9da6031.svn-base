using DevExpress.Utils.Menu;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Menu;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout.Utils;
using System;
using System.Data;
using System.Windows.Forms;

namespace RY_MES.Forms
{
    public partial class frm_Template_Master : RY_MES.frm_Base
    {
        public frm_Template_Master()
        {
            InitializeComponent();
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            _RYMES_DB = _Main._RYMES_DB;

            lc_Conditions.Enabled = false;
            splitContainerControl1.PanelVisibility = SplitPanelVisibility.Panel1;
            splitContainerControl1.SplitterPosition = (Width / 4) * 3;

            btn_Conditions_Click(null, null);
            btn_Conditions.Enabled = false;

            Get_Data_Grid(gridControl);
            (gridControl.MainView as ucGridView).PopupMenuShowing += gridView_PopupMenuShowing;

            Set_Description(lc_edit);
        }

        public void Get_Data_Grid(ucGridControl grid)
        {
            splitContainerControl1.PanelVisibility = SplitPanelVisibility.Panel1;
            grid.Enabled = true;
            DataTable dt = new DataTable();

            _RYMES_DB._DB_Parameters.Add("@p_FA_ID", _Main._User_Info["FA_ID"].ToString());

            string sMsg = _RYMES_DB.GET_DATA("QM_DG_TEMPLATE_MASTER_LOAD", ref dt);
            if (string.IsNullOrEmpty(sMsg))
            {
                grid.DataSource = dt;
            }
            else
            {
                grid.DataSource = null;
            }

            RestoreLayout(this, (grid.MainView as ucGridView));
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

            SET_LookUpEdit_Data(le_TEMPLATE_TYPE, "TEMPLATE_TYPE");
            SET_LookUpEdit_Data(le_OLD_TEMPLATE_ID, "TEMPLATE_MASTER");
            SET_LookUpEdit_Data(le_FA_ID, "FA_MASTER");

            DataRow dataRow = ((DataRowView)view.GetFocusedRow()).Row;
            string fa_id = _Main._User_Info["FA_ID"].ToString();
            if (menu.Caption == "Add")
            {
                txt_TEMPLATE_ID.Text = "";
                le_FA_ID.EditValue = fa_id == "*" ? null : fa_id;
                le_TEMPLATE_TYPE.EditValue = dataRow["TEMPLATE_TYPE_CODE"].ToString();
                me_TEMPLATE_NAME.Text = "";
                me_TEMPLATE_FORM.Text = "";
                me_TEMPLATE_DESC.Text = "";
                txt_TEMPLATE_REV.Text = "";
                le_OLD_TEMPLATE_ID.EditValue = null;

                if (fa_id == "*")
                {
                    le_FA_ID.Enabled = true;
                }
                else
                {
                    le_FA_ID.Enabled = false;
                }

                le_TEMPLATE_TYPE.Enabled = true;

                lc_ChangeChk.Visibility = LayoutVisibility.Never;
                lc_Delete.Visibility = LayoutVisibility.Never;
            }
            else
            {
                txt_TEMPLATE_ID.Text = dataRow["TEMPLATE_ID"].ToString();
                le_FA_ID.EditValue = dataRow["FA_ID"].ToString();
                le_TEMPLATE_TYPE.EditValue = dataRow["TEMPLATE_TYPE_CODE"].ToString();
                me_TEMPLATE_NAME.Text = dataRow["TEMPLATE_NAME"].ToString();
                me_TEMPLATE_FORM.Text = dataRow["TEMPLATE_FORM"].ToString();
                me_TEMPLATE_DESC.Text = dataRow["TEMPLATE_DESC"].ToString();
                txt_TEMPLATE_REV.Text = dataRow["TEMPLATE_REV"].ToString();
                le_OLD_TEMPLATE_ID.EditValue = dataRow["OLD_TEMPLATE_ID"].ToString();

                le_FA_ID.Enabled = false;
                le_TEMPLATE_TYPE.Enabled = false;

                DataTable dt = new DataTable();
                _RYMES_DB._DB_Parameters.Add("@p_TEMPLATE_ID", txt_TEMPLATE_ID.Text);
                string sMsg = _RYMES_DB.SET_DATA("QM_DG_ITEM_TEMPLATE_CHK", ref dt);
                if (string.IsNullOrEmpty(sMsg))
                {
                    if (dt.Rows[0][0].ToString() == "NON EXISTS" && dataRow["DELETE_DATE"].ToString() == "")
                    {
                        lc_ChangeChk.Visibility = LayoutVisibility.Always;
                    }
                    else
                    {
                        lc_ChangeChk.Visibility = LayoutVisibility.Never;
                    }
                }
                else
                {
                    lc_ChangeChk.Visibility = LayoutVisibility.Never;
                }

                lc_Delete.Visibility = LayoutVisibility.Always;

                btn_Delete.Text = dataRow["DELETE_USER"].ToString() == "" ? "Delete" : "Restore";
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (le_FA_ID.EditValue is null || le_TEMPLATE_TYPE.EditValue is null || string.IsNullOrWhiteSpace(me_TEMPLATE_NAME.Text))
            {
                MessageBox.Show("공장아이디, 템플릿유형, 템플릿명은 필수 입력 값입니다.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DataTable dt = new DataTable();

                _RYMES_DB._DB_Parameters = Get_Conditions_Params(lc_edit.Root);
                _RYMES_DB._DB_Parameters.Add("@p_CREATE_USER", _Main._User_Info["USER_CODE"].ToString());

                string sMsg = _RYMES_DB.SET_DATA("QM_DG_TEMPLATE_MASTER_MERGE", ref dt);
                if (string.IsNullOrEmpty(sMsg))
                {
                    MessageBox.Show("Save Success", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Get_Data_Grid(gridControl);

                    if (Root.Text == "Add")
                    {
                        string template_id = dt.Rows[0]["TEMPLATE_ID"].ToString();
                        string fa_id = le_FA_ID.EditValue.ToString();
                        frm_Create_Template frm_Create_Template = new frm_Create_Template(template_id, fa_id)
                        {
                            Text = "Template : (" + dt.Rows[0]["TEMPLATE_ID"].ToString() + ")" + dt.Rows[0]["TEMPLATE_NAME"]
                        };

                        _Main.Chaild_Load(frm_Create_Template);
                    }
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

            if (DialogResult.OK == MessageBox.Show(btn.Text + "  (" + txt_TEMPLATE_ID.Text.ToString() + ") " + me_TEMPLATE_DESC.Text.ToString() + " ?", btn.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            {
                try
                {
                    _RYMES_DB._DB_Parameters.Add("@p_TEMPLATE_ID", txt_TEMPLATE_ID.Text.ToString());
                    _RYMES_DB._DB_Parameters.Add("@p_CREATE_USER", _Main._User_Info["USER_CODE"].ToString());

                    string sMsg = _RYMES_DB.SET_DATA("QM_DG_TEMPLATE_MASTER_DELETE");
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

        private void btn_ChangeChk_Click(object sender, EventArgs e)
        {
            frm_Create_Template frm_Create_Template = new frm_Create_Template(txt_TEMPLATE_ID.Text, le_FA_ID.EditValue)
            {
                Text = "(" + txt_TEMPLATE_ID.Text + ") " + me_TEMPLATE_NAME.Text
            };
            _Main.Chaild_Load(frm_Create_Template);

            Get_Data_Grid(gridControl);
        }
    }
}