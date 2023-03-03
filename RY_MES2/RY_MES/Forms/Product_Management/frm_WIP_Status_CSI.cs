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
    public partial class frm_WIP_Status_CSI : RY_MES.frm_Base
    {
        private string wo_status = "";
        private string op_group = "";
        private string item_type = "";
        private string item_spec = "";
        
        public frm_WIP_Status_CSI()
        {
            InitializeComponent();
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            _RYMES_DB = _Main._RYMES_DB;

            splitContainerControl1.SplitterPosition = (Height / 4) * 2;
            splitContainerControl2.SplitterPosition = (Width / 4) * 2;

            pnl_Conditions.Visible = false;
            btn_Conditions.Enabled = false;

            Get_Data_Grid(gridControl);

            ucGridView1.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CellSelect;
            ucGridView1.FocusRectStyle = DrawFocusRectStyle.CellFocus;
            ucGridView1.OptionsSelection.EnableAppearanceFocusedCell = true;
            ucGridView1.OptionsSelection.EnableAppearanceFocusedRow = false;
            ucGridView1.Appearance.FocusedCell.BackColor = Color.Lavender;
            ucGridView1.OptionsView.ShowFooter = true;

            ucGridView1.PopupMenuShowing += gridView_PopupMenuShowing;
            ucGridView2.PopupMenuShowing += gridView_PopupMenuShowing;
            ucGridView3.PopupMenuShowing += gridView_PopupMenuShowing;
            ucGridView1.MouseDown += gridView_MouseDown;

        }

        private void Get_Data_Grid(ucGridControl grid)
        {
            ucGridView view = grid.MainView as ucGridView;

            SplashScreenManager.ShowForm(_Main, typeof(frm_Wait), true, true, false);
            try
            {
                DataTable dt = new DataTable();

                string sMsg = _RYMES_DB.GET_DATA("PM_IP_WIP_STATUS_CSI_LOAD", ref dt);

                if (string.IsNullOrEmpty(sMsg))
                {
                    grid.DataSource = dt;

                    foreach (GridColumn column in (grid.MainView as ucGridView).Columns)
                    {
                        if (column.FieldName != "ITEM_TYPE" && column.FieldName != "ITEM_SPEC")
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
            ucGridView view = grid.MainView as ucGridView;

            SplashScreenManager.ShowForm(_Main, typeof(frm_Wait), true, true, false);
            try
            {
                DataTable dt = new DataTable();

                DataRow dr = ucGridView1.GetDataRow(rowHandle);

                item_type = dr["ITEM_TYPE"].ToString();
                item_spec = dr["ITEM_SPEC"].ToString();

                if (field_name.Contains("투입"))
                {
                    wo_status = "0002";
                    op_group = field_name.Substring(0, field_name.Length - 2);
                }
                else if (field_name.Contains("완료"))
                {
                    wo_status = "0004";
                    op_group = field_name.Substring(0, field_name.Length - 2);
                }
                else if (field_name.Contains("PACKING"))
                {
                    wo_status = "0002";
                    op_group = "PK";
                }
                else if (field_name.Contains("CONFIRM") && item_spec== "REWORK ITEM CODE")
                {
                    wo_status = "";
                    op_group = "REWORK";
                }
                else
                {
                    wo_status = "";
                    op_group = "";
                }

                _RYMES_DB._DB_Parameters.Add("@p_ITEM_TYPE", item_type);
                _RYMES_DB._DB_Parameters.Add("@p_ITEM_SPEC", item_spec);
                _RYMES_DB._DB_Parameters.Add("@p_WO_STATUS", wo_status);
                _RYMES_DB._DB_Parameters.Add("@p_OP_GROUP", op_group);

                string sMsg = _RYMES_DB.GET_DATA("PM_IP_WIP_STATUS_DETAIL_CSI_LOAD", ref dt);

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
                Get_Data_Grid3(gridControl2);
            }
        }

        private void Get_Data_Grid3(ucGridControl grid)
        {
            if (ucGridView2.FocusedRowHandle < 0)
            {
                grid.DataSource = null;
                return;
            }

            DataRow dr = ucGridView2.GetFocusedDataRow();

            ucGridView view = grid.MainView as ucGridView;

            SplashScreenManager.ShowForm(_Main, typeof(frm_Wait), true, true, false);
            try
            {
                DataTable dt = new DataTable();

                _RYMES_DB._DB_Parameters.Add("@p_ITEM_TYPE", item_type);
                _RYMES_DB._DB_Parameters.Add("@p_ITEM_SPEC", item_spec);
                _RYMES_DB._DB_Parameters.Add("@p_WO_STATUS", wo_status);
                _RYMES_DB._DB_Parameters.Add("@p_OP_GROUP", op_group);
                _RYMES_DB._DB_Parameters.Add("@p_ITEM_CODE", dr["ITEM_CODE"].ToString());
                _RYMES_DB._DB_Parameters.Add("@p_ORDER_NO", dr["ORDER_NO"].ToString());
                _RYMES_DB._DB_Parameters.Add("@p_OP_NAME", dr["OP_NAME"].ToString());

                string sMsg = _RYMES_DB.GET_DATA("PM_IP_WIP_STATUS_DEETAIL_WAFER_CSI_LOAD", ref dt);

                if (string.IsNullOrEmpty(sMsg))
                {
                    grid.DataSource = dt;
                    view.Link_Column("WAFER_NO", "frm_Panel_His_CSI");
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
            ucGridView view = sender as ucGridView;
            ucGridControl grid = view.GridControl as ucGridControl;

            DXMenuItem item;

            if (e.Menu == null)
            {
                e.Menu = new GridViewMenu(view);
            }

            if (grid.Name == "gridControl")
            {
                item = new DXMenuItem("Refresh", null, Properties.Resources.refresh_16x16);
                item.Click += (o, args) =>
                {
                    Get_Data_Grid(grid);
                };
                e.Menu.Items.Add(item);
            }

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

                if (field_name != "ITEM_TYPE" && field_name != "ITEM_SPEC" && field_name != "TOTAL")
                {
                    Get_Data_Grid2(gridControl1, rowHandle, field_name);
                }
                else
                {
                    gridControl1.DataSource = null;
                    gridControl2.DataSource = null;
                }
            }
        }

        private void frm_SizeChanged(object sender, EventArgs e)
        {
            splitContainerControl1.SplitterPosition = (Height / 4) * 2;
            splitContainerControl2.SplitterPosition = (Width / 4) * 2;
        }

        private void ucGridView2_RowClick(object sender, RowClickEventArgs e)
        {
            Get_Data_Grid3(gridControl2);
        }
    }
}