using DevExpress.Utils.Menu;
using DevExpress.XtraGrid.Menu;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using nsCommon;
using System;
using System.Data;
using System.Windows.Forms;

namespace RY_MES.Forms
{
    public partial class frm_Lot_List : RY_MES.frm_Base
    {
        private string lot_no { get; set; }

        public frm_Lot_List()
        {
            InitializeComponent();
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            _RYMES_DB = _Main._RYMES_DB;

            lc_Conditions.Visible = false;
            pnl_Conditions.Visible = true;
            btn_Conditions.Visible = false;

            btn_Refresh_Click(null, null);

            ucGridView.PopupMenuShowing += gridView_PopupMenuShowing;
            ucGridView1.PopupMenuShowing += gridView_PopupMenuShowing;
            ucGridView2.PopupMenuShowing += gridView_PopupMenuShowing;

            ucGridView.FocusedRowChanged += gridView_FocusedRowChanged;
            ucGridView.DoubleClick += gridView_DoubleClick;
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
                if (grid == gridControl)
                {
                    Get_Data_Grid(grid);
                }
                else if (grid == gridControl1)
                {
                    Get_Data_Grid1(grid, lot_no);
                }
                else
                {
                    Get_Data_Grid2(grid);
                }
            };
            e.Menu.Items.Add(item);

            item = new DXMenuItem("Export", null, Properties.Resources.exporttoxlsx_16x16);
            item.Click += (o, args) =>
            {
                grid.Grid_Export();
            };
            e.Menu.Items.Add(item);
        }

        private void Get_Data_Grid(ucGridControl grid)
        {
            SplashScreenManager.ShowForm(_Main, typeof(frm_Wait), true, true, false);
            try
            {
                ucGridView view = grid.MainView as ucGridView;

                DataTable dt = new DataTable();
                string sMsg = _RYMES_DB.GET_DATA("WO_LOT_MASTER_LOAD", ref dt);

                if (string.IsNullOrEmpty(sMsg))
                {
                    grid.DataSource = dt;
                    view.BestFitColumns();
                }
                else
                {
                    grid.DataSource = null;
                }
            }
            finally
            {
                SplashScreenManager.CloseForm(false);
                gridControl2.Focus();
            }
        }

        private void Get_Data_Grid1(ucGridControl grid, string lot_no)
        {
            SplashScreenManager.ShowForm(_Main, typeof(frm_Wait), true, true, false);
            try
            {
                ucGridView view = grid.MainView as ucGridView;

                DataTable dt = new DataTable();

                _RYMES_DB._DB_Parameters.Add("@p_LOT_NO", lot_no);
                string sMsg = _RYMES_DB.GET_DATA("WO_LOT_WAFER_LOAD", ref dt);

                if (string.IsNullOrEmpty(sMsg))
                {
                    grid.DataSource = dt;
                    view.BestFitColumns();
                }
                else
                {
                    grid.DataSource = null;
                }
            }
            finally
            {
                SplashScreenManager.CloseForm(false);
                gridControl2.Focus();
            }
        }

        private void Get_Data_Grid2(ucGridControl grid)
        {
            SplashScreenManager.ShowForm(_Main, typeof(frm_Wait), true, true, false);
            try
            {
                ucGridView view = grid.MainView as ucGridView;
                DataTable dt = new DataTable();
                string sMsg = _RYMES_DB.GET_DATA("WO_LOT_WAFER_LOAD", ref dt);

                if (string.IsNullOrEmpty(sMsg))
                {
                    grid.DataSource = dt;
                    view.BestFitColumns();

                    view.Link_Column("WAFER_NO", "frm_Wafer_His");
                }
                else
                {
                    grid.DataSource = null;
                }
            }
            finally
            {
                SplashScreenManager.CloseForm(false);
                gridControl2.Focus();
            }
        }

        private void gridView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            ucGridView view = sender as ucGridView;

            if (view.GetFocusedDataRow() is null)
            {
                gridControl1.DataSource = null;
                return;
            }

            try
            {
                lot_no = view.GetRowCellValue(e.FocusedRowHandle, "LOT_NO").ToString();
                Get_Data_Grid1(gridControl1, lot_no);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_CreateLot_Click(object sender, EventArgs e)
        {
            frm_Lot_Wafer_Popup popup = new frm_Lot_Wafer_Popup();

            if (DialogResult.OK == popup.ShowDialog())
            {
                btn_Refresh_Click(null, null);
            }
        }

        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            GridView view = sender as GridView;

            string lot_no = view.GetFocusedRowCellValue("LOT_NO").ToString();
            DataTable dt = new DataTable();

            try
            {
                _RYMES_DB._DB_Parameters.Add("@p_LOT_NO", lot_no);
                string sMsg = _RYMES_DB.GET_DATA("WO_CHK_WAFER_STATUS", ref dt);

                if (string.IsNullOrEmpty(sMsg))
                {
                    if (dt.Rows[0][0].ToString() == "0003")
                    {
                        MessageBox.Show("공정 투입 된 Lot은 수정 할 수 없습니다.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        frm_Lot_Wafer_Popup popup = new frm_Lot_Wafer_Popup(lot_no);

                        if (DialogResult.OK == popup.ShowDialog())
                        {
                            btn_Refresh_Click(null, null);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "DB Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            Get_Data_Grid(gridControl);
            if (ucGridView.RowCount > 0)
            {
                lot_no = ucGridView.GetFocusedRowCellValue("LOT_NO").ToString();
                Get_Data_Grid1(gridControl1, lot_no);
            }
            else
            {
                gridControl1.DataSource = null;
            }
            Get_Data_Grid2(gridControl2);
        }
    }
}