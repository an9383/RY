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
    public partial class frm_ST_Master : RY_MES.frm_Base
    {
        public frm_ST_Master()
        {
            InitializeComponent();
        }

        public frm_ST_Master(object[] paramArray)
        {
            InitializeComponent();
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            _RYMES_DB = _Main._RYMES_DB;

            lc_Conditions.Enabled = false;
            btn_Conditions_Click(null, null);
            btn_Conditions.Enabled = false;

            Get_Data_Grid(gridControl);
            Set_Description(lc_edit);
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

                _RYMES_DB._DB_Parameters.Add("@p_FA_ID", _Main._User_Info["FA_ID"].ToString());
                string sMsg = _RYMES_DB.GET_DATA("BI_PI_ST_MASTER_LOAD", ref dt);
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

        private void SHOW_EDIT(GridView view, object sender)
        {
            splitContainerControl1.SplitterPosition = (Width / 4) * 3;
            splitContainerControl1.PanelVisibility = SplitPanelVisibility.Both;

            view.GridControl.Enabled = false;

            DXMenuItem menu = (DXMenuItem)sender;
            Root.Text = menu.Caption;
            
            SET_LookUpEdit_Data(le_FA_ID, "FA_MASTER");
            SET_LookUpEdit_Data(le_OP_ID, "OP_MASTER");

            SET_LookUpEdit_Data(le_ITEM_CODE, "ITEM_MASTER");

            DataRow dataRow = ((DataRowView)view.GetFocusedRow()).Row;

            le_FA_ID.EditValue = dataRow["FA_ID"].ToString();
            le_OP_ID.EditValue = dataRow["OP_ID"].ToString();
            le_ITEM_CODE.EditValue = dataRow["ITEM_CODE"].ToString();
            txt_ST1.Text = dataRow["ST1"].ToString();
            txt_ST2.Text = dataRow["ST2"].ToString();

            le_FA_ID.Enabled = false;
            le_OP_ID.Enabled = false;
            le_ITEM_CODE.Enabled = false;            
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (le_FA_ID.EditValue is null || le_OP_ID.EditValue is null || le_ITEM_CODE.EditValue is null)
            {
                MessageBox.Show("공장아이디, 공정아이디, 품목코드는 필수 입력 값입니다.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            txt_ST1.Text = String.IsNullOrEmpty(txt_ST1.Text)? "0" : txt_ST1.Text;
            txt_ST2.Text = String.IsNullOrEmpty(txt_ST2.Text) ? "0" : txt_ST2.Text;
            
            try
            {
                _RYMES_DB._DB_Parameters = Get_Conditions_Params(lc_edit.Root);
                _RYMES_DB._DB_Parameters.Add("@p_CREATE_USER", _Main._User_Info["USER_CODE"].ToString());

                string sMsg = _RYMES_DB.SET_DATA("BI_PI_ST_MASTER_MERGE");
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