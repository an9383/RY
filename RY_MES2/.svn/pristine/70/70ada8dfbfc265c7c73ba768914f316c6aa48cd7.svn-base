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
    public partial class frm_WIP_Status : RY_MES.frm_Base
    {
        private string wo_status = "";
        private string op_id = "";
        private string pm_biz = "";
        private string pm_group = "";
        private string pm_model = "";
        
        public frm_WIP_Status()
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

                string sMsg = _RYMES_DB.GET_DATA("PM_IP_WIP_STATUS_LOAD", ref dt);

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
            ucGridView view = grid.MainView as ucGridView;

            SplashScreenManager.ShowForm(_Main, typeof(frm_Wait), true, true, false);
            try
            {
                DataTable dt = new DataTable();

                DataRow dr = ucGridView1.GetDataRow(rowHandle);

                pm_biz = dr["PM_BIZ"].ToString();
                pm_group = dr["PM_GROUP"].ToString();
                pm_model = dr["PM_MODEL"].ToString();

                if (field_name.Contains("투입"))
                {
                    wo_status = "0002";
                    op_id = field_name.Substring(0, field_name.Length - 2);
                }
                else if (field_name.Contains("완료"))
                {
                    wo_status = "0004";
                    op_id = field_name.Substring(0, field_name.Length - 2);
                }
                else if (field_name.Contains("PACKING"))
                {
                    wo_status = "0002";
                    op_id = "PK";
                }
                else if (field_name.Contains("CONFIRM") && pm_group == "REWORK")
                {
                    wo_status = "";
                    op_id = "RW";
                }
                else
                {
                    wo_status = "";
                    op_id = "";
                }

                _RYMES_DB._DB_Parameters.Add("@p_PM_BIZ", pm_biz);
                _RYMES_DB._DB_Parameters.Add("@p_PM_GROUP", pm_group);
                _RYMES_DB._DB_Parameters.Add("@p_PM_MODEL", pm_model);
                _RYMES_DB._DB_Parameters.Add("@p_WO_STATUS", wo_status);
                _RYMES_DB._DB_Parameters.Add("@p_OP_ID", op_id);

                string sMsg = _RYMES_DB.GET_DATA("PM_IP_WIP_STATUS_DETAIL_LOAD", ref dt);

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

                _RYMES_DB._DB_Parameters.Add("@p_PM_BIZ", pm_biz);
                _RYMES_DB._DB_Parameters.Add("@p_PM_GROUP", pm_group);
                _RYMES_DB._DB_Parameters.Add("@p_PM_MODEL", pm_model);
                _RYMES_DB._DB_Parameters.Add("@p_WO_STATUS", wo_status);
                _RYMES_DB._DB_Parameters.Add("@p_OP_ID", op_id);
                _RYMES_DB._DB_Parameters.Add("@p_ITEM_CODE", dr["ITEM_CODE"].ToString());
                _RYMES_DB._DB_Parameters.Add("@p_ORDER_NO", dr["ORDER_NO"].ToString());

                string sMsg = _RYMES_DB.GET_DATA("PM_IP_WIP_STATUS_DEETAIL_WAFER_LOAD", ref dt);

                if (string.IsNullOrEmpty(sMsg))
                {
                    grid.DataSource = dt;
                    view.Link_Column("WAFER_NO", "frm_Wafer_His");
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

                if (field_name != "PM_BIZ" && field_name != "PM_GROUP" && field_name != "PM_MODEL" && field_name != "TOTAL")
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