using DevExpress.Utils.Menu;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Menu;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Data;
using System.Windows.Forms;

namespace RY_MES.Forms
{
    public partial class frm_CHK_Master : RY_MES.frm_Base
    {
        public frm_CHK_Master()
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
            gridControl.Enabled = true;
            DataTable dt = new DataTable();

            _RYMES_DB._DB_Parameters.Add("@p_FA_ID", _Main._User_Info["FA_ID"].ToString());
            string sMsg = _RYMES_DB.GET_DATA("QM_DG_CHK_MASTER_LOAD", ref dt);
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

            string fa_id = _Main._User_Info["FA_ID"].ToString();
            SET_LookUpEdit_Data(le_FA_ID, "FA_MASTER");
            SET_LookUpEdit_Data(le_INSPECTION_TYPE, "INSPECTION_TYPE");
            SET_LookUpEdit_Data(le_INSPECTION_TYPE_RESULT, "INSPECT_TYPE_RESULT");

            if (menu.Caption == "Add")
            {
                txt_CHK_ID.EditValue = null;
                le_FA_ID.EditValue = fa_id == "*" ? null : fa_id;
                le_OP_ID.EditValue = null;
                me_CHK_PROCESS_NAME.Text = "";
                me_CHK_NAME.Text = "";
                me_CRITERIA.Text = "";
                me_INSPECTION_METHOD.Text = "";
                le_INSPECTION_TYPE.EditValue = null;
                le_INSPECTION_TYPE_RESULT.EditValue = null;
                txt_INSPECTION_DEFAULT_VALUE.Text = "";
                txt_DISPLAY_AREA.Text = "";
                txt_INSPECTION_UNIT.Text = "";
                txt_DESC1.Text = "";
                IF_NAME.Text = "";
                txt_SPEC_NAME.Text = "";
                rg_AUTO_YN.EditValue = "N";

                if (fa_id == "*")
                {
                    le_FA_ID.Enabled = true;
                    le_OP_ID.Properties.DataSource = null;
                }
                else
                {
                    le_FA_ID.Enabled = false;
                    SET_LookUpEdit_Data(le_OP_ID, "OP_MASTER", fa_id);
                }

                lc_Delete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            else
            {
                DataRow dataRow = ((DataRowView)view.GetFocusedRow()).Row;

                if (fa_id != "*")
                {
                    SET_LookUpEdit_Data(le_OP_ID, "OP_MASTER", fa_id);
                }
                txt_CHK_ID.EditValue = dataRow["CHK_ID"].ToString();
                le_FA_ID.EditValue = dataRow["FA_ID"].ToString();
                le_OP_ID.EditValue = dataRow["OP_ID"].ToString();
                me_CHK_PROCESS_NAME.Text = dataRow["CHK_PROCESS_NAME"].ToString();
                me_CHK_NAME.Text = dataRow["CHK_NAME"].ToString();
                me_CRITERIA.Text = dataRow["CRITERIA"].ToString();
                me_INSPECTION_METHOD.Text = dataRow["INSPECTION_METHOD"].ToString();
                le_INSPECTION_TYPE.EditValue = dataRow["INSPECTION_TYPE"].ToString();
                le_INSPECTION_TYPE_RESULT.EditValue = dataRow["INSPECTION_TYPE_RESULT"].ToString();
                txt_INSPECTION_DEFAULT_VALUE.Text = dataRow["INSPECTION_DEFAULT_VALUE"].ToString();
                txt_DISPLAY_AREA.Text = dataRow["DISPLAY_AREA"].ToString();
                txt_INSPECTION_UNIT.Text = dataRow["INSPECTION_UNIT"].ToString();
                txt_DESC1.Text = dataRow["DESC1"].ToString();
                IF_NAME.Text = dataRow["IF_NAME"].ToString();
                txt_SPEC_NAME.Text = dataRow["SPEC_NAME"].ToString();
                rg_AUTO_YN.EditValue = dataRow["AUTO_YN"].ToString() == "" ? "N" : dataRow["AUTO_YN"].ToString();

                lc_Delete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

                btn_Delete.Text = dataRow["DELETE_USER"].ToString() == "" ? "Delete" : "Restore";
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (le_FA_ID.EditValue is null || le_OP_ID.EditValue is null || string.IsNullOrWhiteSpace(me_CHK_PROCESS_NAME.Text) )
            {
                MessageBox.Show("공정코드, 검사그룹은 필수 입력 값입니다.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (le_INSPECTION_TYPE.EditValue.ToString() == "RADIO" && le_INSPECTION_TYPE_RESULT.EditValue is null)
            {
                MessageBox.Show("검사결과목록값을 선택해주세요.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (rg_AUTO_YN.EditValue is null)
            {
                rg_AUTO_YN.EditValue = "N";
            }

            try
            {
                _RYMES_DB._DB_Parameters = Get_Conditions_Params(lc_edit.Root);
                _RYMES_DB._DB_Parameters.Add("@p_CREATE_USER", _Main._User_Info["USER_CODE"].ToString());

                string sMsg = _RYMES_DB.SET_DATA("QM_DG_CHK_MASTER_MERGE");
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

            if (DialogResult.OK == MessageBox.Show(btn.Text + "  (" + txt_CHK_ID.Text.ToString() + ") " + me_CHK_NAME.Text.ToString() + " ?", btn.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            {
                try
                {
                    _RYMES_DB._DB_Parameters.Add("@p_CHK_ID", txt_CHK_ID.Text.ToString());
                    _RYMES_DB._DB_Parameters.Add("@p_CREATE_USER", _Main._User_Info["USER_CODE"].ToString());

                    string sMsg = _RYMES_DB.SET_DATA("QM_DG_CHK_MASTER_DELETE");
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

        private void le_FA_ID_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit le = sender as LookUpEdit;

            if (le.EditValue is null)
            {
                le.Properties.DataSource = null;
            }
            else
            {
                SET_LookUpEdit_Data(le_OP_ID, "OP_MASTER", le.EditValue.ToString());
            }
        }
    }
}