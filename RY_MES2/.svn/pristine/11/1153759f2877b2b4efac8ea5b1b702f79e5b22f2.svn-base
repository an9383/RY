using DevExpress.Utils.Menu;
using DevExpress.XtraGrid.Menu;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraTreeList;
using nsCommon;
using System;
using System.Data;
using System.Windows.Forms;

namespace RY_MES.Forms
{
    public partial class frm_Auth_Detail : frm_Base
    {
        private DataTable dt_Menu { get; set; }

        private string auth_code = null;

        public frm_Auth_Detail()
        {
            InitializeComponent();
        }

        public frm_Auth_Detail(params object[] paramArray)
        {
            InitializeComponent();
            auth_code = paramArray[0].ToString();
        }

        private void frm_Load(object sender, EventArgs e)
        {
            _RYMES_DB = _Main._RYMES_DB;

            lc_Conditions.Enabled = false;
            splitContainerControl1.SplitterPosition = (Width / 4) * 2;

            (gridControl.MainView as ucGridView).FocusedRowChanged += gridView_FocusedRowChanged;

            Get_Data_Grid(gridControl);

            if (auth_code != null)
            {
                (gridControl.MainView as ucGridView).FocusedRowHandle = (gridControl.MainView as ucGridView).LocateByValue("AUTH_CODE", auth_code);
            }

            (gridControl.MainView as ucGridView).PopupMenuShowing += gridView_PopupMenuShowing;
        }

        public void Get_Data_Grid(ucGridControl grid)
        {
            gridControl.Enabled = true;

            DataTable dt = new DataTable();

            try
            {
                string sMsg = _RYMES_DB.GET_DATA("SM_AM_AUTH_MASTER_LOAD", ref dt);
                if (string.IsNullOrEmpty(sMsg))
                {
                    gridControl.DataSource = dt;
                }
                else
                {
                    gridControl.DataSource = null;
                }

                RestoreLayout(this, (grid.MainView as ucGridView));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Get_Data_Tree(TreeList treeList, string auth_code)
        {
            DataTable dt = new DataTable();

            try
            {
                _RYMES_DB._DB_Parameters.Add("@p_AUTH_CODE", auth_code);

                string sMsg = _RYMES_DB.GET_DATA("SM_AM_AUTH_DETAIL_LOAD", ref dt);
                if (string.IsNullOrEmpty(sMsg))
                {
                    treeList.DataSource = dt;
                    Set_Description(treeList1);
                    treeList.KeyFieldName = "MENU_CODE";
                    treeList.ParentFieldName = "SUPER_MENU_CODE";
                    treeList.Columns["AUTH_DB"].Visible = false;
                    treeList.ExpandAll();
                    treeList.BestFitColumns();
                }
                else
                {
                    treeList1.DataSource = null;
                }

                dt_Menu = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            item = new DXMenuItem("Refresh", null, Properties.Resources.refresh_16x16);
            item.Click += (o, args) =>
            {
                Get_Data_Grid(gridControl);
            };
            e.Menu.Items.Add(item);
        }

        private void frm_Auth_Detail_SizeChanged(object sender, EventArgs e)
        {
            splitContainerControl1.SplitterPosition = (Width / 4) * 2;
        }

        private void gridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GridView view = (GridView)sender;
            Get_Data_Tree(treeList1, view.GetRowCellValue(e.FocusedRowHandle, "AUTH_CODE").ToString());
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            string sMENUS = "";
            DataRow[] drs = dt_Menu.Select("AUTH = 'True' OR AUTH IS NULL");

            foreach (DataRow dr in drs)
            {
                sMENUS += dr["MENU_CODE"].ToString() + ',';
            }

            SplashScreenManager.ShowForm(_Main, typeof(frm_Wait), true, true, false);
            try
            {
                GridView view = (gridControl.MainView as ucGridView);

                _RYMES_DB._DB_Parameters.Add("@p_AUTH_CODE", view.GetRowCellValue(view.FocusedRowHandle, "AUTH_CODE"));
                _RYMES_DB._DB_Parameters.Add("@p_MENU_CODES", sMENUS);
                _RYMES_DB._DB_Parameters.Add("@p_CREATE_USER", _Main._User_Info["USER_CODE"].ToString());

                string sMsg = _RYMES_DB.SET_DATA("SM_AM_AUTH_DETAIL_MERGE_STRING");

                SplashScreenManager.CloseForm(false);

                if (!string.IsNullOrEmpty(sMsg))
                {
                    MessageBox.Show(sMsg, "DB ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    MessageBox.Show("Save Success", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Get_Data_Grid(gridControl);
                }
            }
            catch (Exception ex)
            {
                SplashScreenManager.CloseForm(false);

                MessageBox.Show(ex.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}