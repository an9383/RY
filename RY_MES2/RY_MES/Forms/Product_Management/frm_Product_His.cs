using DevExpress.Utils.Menu;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Menu;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using nsCommon;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace RY_MES.Forms
{
    public partial class frm_Product_His : RY_MES.frm_Base
    {
        public frm_Product_His()
        {
            InitializeComponent();
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            _RYMES_DB = _Main._RYMES_DB;

            splitContainerControl1.SplitterPosition = (Height / 4) * 2;

            pnl_Conditions.Visible = true;
            btn_Conditions.Enabled = false;

            Get_Data_Grid(gridControl);

            
            ucGridView1.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CellSelect;
            ucGridView1.FocusRectStyle = DrawFocusRectStyle.CellFocus;
            ucGridView1.OptionsSelection.EnableAppearanceFocusedCell = true;
            ucGridView1.OptionsSelection.EnableAppearanceFocusedRow = false;
            ucGridView1.Appearance.FocusedCell.BackColor = Color.Lavender;
            ucGridView1.PopupMenuShowing += gridView_PopupMenuShowing;
            ucGridView1.MouseDown += gridView_MouseDown;
            ucGridView1.OptionsView.ShowFooter = true;
        }

        private void Get_Data_Grid(ucGridControl grid)
        {
            ucGridView view = (grid.MainView as ucGridView);
            SplashScreenManager.ShowForm(_Main, typeof(frm_Wait), true, true, false);

            try
            {
                DataTable dt = new DataTable();

                _RYMES_DB._DB_Parameters.Add("@p_To", de_To.Text);
                _RYMES_DB._DB_Parameters.Add("@p_From", de_From.Text);

                string sMsg = _RYMES_DB.GET_DATA("PM_IP_PRODUCT_HIS_LOAD", ref dt);

                if (string.IsNullOrEmpty(sMsg))
                {
                    grid.DataSource = dt;

                    foreach (GridColumn column in view.Columns)
                    {
                        if (column.FieldName != "PM_BIZ" && column.FieldName != "PM_GROUP" && column.FieldName != "PM_MODEL")
                        {
                            column.Summary.Add(DevExpress.Data.SummaryItemType.Sum, column.FieldName, "SUM = {0:d}");
                        }
                    }
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

        private void Get_Data_Grid2(ucGridControl grid, int rowHandle, string field_name)
        {
            ucGridView view = (grid.MainView as ucGridView);

            SplashScreenManager.ShowForm(_Main, typeof(frm_Wait), true, true, false);
            try
            {
                DataTable dt = new DataTable();
                DataRow dr = ucGridView1.GetDataRow(rowHandle);

                _RYMES_DB._DB_Parameters.Add("@p_To", de_To.Text);
                _RYMES_DB._DB_Parameters.Add("@p_From", de_From.Text);
                _RYMES_DB._DB_Parameters.Add("@p_PM_BIZ", dr["PM_BIZ"].ToString());
                _RYMES_DB._DB_Parameters.Add("@p_PM_GROUP", dr["PM_GROUP"].ToString());
                _RYMES_DB._DB_Parameters.Add("@p_PM_MODEL", dr["PM_MODEL"].ToString());
                _RYMES_DB._DB_Parameters.Add("@p_OP_ID", field_name);

                string sMsg = _RYMES_DB.GET_DATA("PM_IP_PRODUCT_HIS_DETAIL_LOAD", ref dt);

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

        private void gridView_MouseDown(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;

            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hitInfo = view.CalcHitInfo(e.Location);
            if (hitInfo.InRowCell)
            {
                int rowHandle = hitInfo.RowHandle;
                string field_name = hitInfo.Column.FieldName;

                if (field_name != "PM_BIZ" && field_name != "PM_GROUP" && field_name != "PM_MODEL" && field_name != "TOTAL")
                {
                    Get_Data_Grid2(gridControl1, rowHandle, field_name);
                }
            }
        }


        private void frm_SizeChanged(object sender, EventArgs e)
        {
            splitContainerControl1.SplitterPosition = (Height / 4) * 2;
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            Get_Data_Grid(gridControl);
        }
    }
}