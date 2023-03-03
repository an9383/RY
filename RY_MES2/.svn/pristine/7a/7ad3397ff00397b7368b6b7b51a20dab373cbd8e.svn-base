using DevExpress.Utils.Menu;
using DevExpress.XtraGrid.Menu;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using nsCommon;
using System;
using System.Data;

namespace RY_MES.Forms
{
    public partial class frm_Ticket_His : RY_MES.frm_Base
    {
        public frm_Ticket_His()
        {
            InitializeComponent();
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            _RYMES_DB = _Main._RYMES_DB;

            splitContainerControl1.SplitterPosition = (Height / 4) * 2;
            splitContainerControl2.SplitterPosition = (Width / 4) * 2;

            pnl_Conditions.Visible = true;
            btn_Conditions.Enabled = false;

            btn_Search_Click(null, null);

            ucGridView1.RowClick += GridView_RowClick;
            ucGridView1.PopupMenuShowing += gridView_PopupMenuShowing;
            ucGridView2.PopupMenuShowing += gridView_PopupMenuShowing;
            ucGridView3.PopupMenuShowing += gridView_PopupMenuShowing;
        }

        private void Get_Data_Grid(ucGridControl grid)
        {
            ucGridView view = grid.MainView as ucGridView;
            SplashScreenManager.ShowForm(_Main, typeof(frm_Wait), true, true, false);
            try
            {
                DataTable dt = new DataTable();

                _RYMES_DB._DB_Parameters.Add("@p_To", de_To.Text);
                _RYMES_DB._DB_Parameters.Add("@p_From", de_From.Text);
                _RYMES_DB._DB_Parameters.Add("@p_FA_ID", _Main._User_Info["FA_ID"].ToString());

                string sMsg = _RYMES_DB.GET_DATA("WO_TICKET_HIS_LOAD", ref dt);

                if (string.IsNullOrEmpty(sMsg))
                {
                    grid.DataSource = dt;
                    view.Set_Column_Type("TICKET_START_DATE", ucGridView.Col_Type.DateTime);
                    view.Set_Column_Type("TICKET_END_DATE", ucGridView.Col_Type.DateTime);
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

        private void Get_Data_Grid2(ucGridControl grid, string ticket_id)
        {
            ucGridView view = (grid.MainView as ucGridView);

            SplashScreenManager.ShowForm(_Main, typeof(frm_Wait), true, true, false);
            try
            {
                DataTable dt = new DataTable();
                _RYMES_DB._DB_Parameters.Add("@p_TICKET_ID", ticket_id);
                string sMsg = _RYMES_DB.GET_DATA("WO_DETAIL_LOAD", ref dt);

                if (string.IsNullOrEmpty(sMsg))
                {
                    grid.DataSource = dt;

                    view.Set_Column_Type("WO_START_DATE", ucGridView.Col_Type.DateTime);
                    view.Set_Column_Type("WO_END_DATE", ucGridView.Col_Type.DateTime);
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

                if (view.RowCount > 0)
                {
                    Get_Data_Grid3(gridControl2, ((DataRowView)view.GetFocusedRow()).Row["WO_ID"].ToString());
                }
                else
                {
                    gridControl2.DataSource = null;
                }
            }
        }

        private void Get_Data_Grid3(ucGridControl grid, string wo_id)
        {
            ucGridView view = (grid.MainView as ucGridView);
            view.Columns.Clear();

            SplashScreenManager.ShowForm(_Main, typeof(frm_Wait), true, true, false);
            try
            {
                DataTable dt = new DataTable();

                _RYMES_DB._DB_Parameters.Add("@p_WO_ID", wo_id);
                string sMsg = _RYMES_DB.GET_DATA("WO_WO_WAFER_MASTER_LOAD", ref dt);

                if (string.IsNullOrEmpty(sMsg))
                {
                    
                    grid.DataSource = dt;

                    if (dt.Rows[0]["FA_ID"].ToString() == "CMOS")
                    {
                        view.Link_Column("WAFER_NO", "frm_Wafer_His");
                    }
                    else if (dt.Rows[0]["FA_ID"].ToString() == "TFT" || _Main._User_Info["FA_ID"].ToString() == "TFT")
                    {
                        view.Columns["WAFER_NO"].Caption = "Panel 번호";
                        view.Link_Column("WAFER_NO", "frm_Panel_His_TFT");
                    }
                    else if (dt.Rows[0]["FA_ID"].ToString() == "CSI")
                    {
                        view.Columns["WAFER_NO"].Caption = "Panel/CsI 번호";
                        view.Link_Column("WAFER_NO", "frm_Panel_His_CSI");
                    }
                }
                else
                {
                    grid.DataSource = null;
                }

                view.BestFitColumns();
            }
            finally
            {
                SplashScreenManager.CloseForm(false);
                grid.Focus();
            }
        }

        private void GridView_RowClick(object sender, RowClickEventArgs e)
        {
            GridView view = sender as GridView;

            if (view.FocusedRowHandle > -1)
            {
                Get_Data_Grid2(gridControl1, ((DataRowView)view.GetFocusedRow()).Row["TICKET_ID"].ToString());
            }
        }

        private void ucGridView2_RowClick(object sender, RowClickEventArgs e)
        {
            GridView view = sender as GridView;

            if (view.FocusedRowHandle > -1)
            {
                Get_Data_Grid3(gridControl2, ((DataRowView)view.GetFocusedRow()).Row["WO_ID"].ToString());
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
                    btn_Search_Click(null, null);
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

        private void btn_Search_Click(object sender, EventArgs e)
        {
            Get_Data_Grid(gridControl);
            if (ucGridView1.RowCount > 0)
            {
                Get_Data_Grid2(gridControl1, ((DataRowView)ucGridView1.GetFocusedRow()).Row["TICKET_ID"].ToString());
            }
            else
            {
                gridControl1.DataSource = null;
            }
        }

        private void frm_SizeChanged(object sender, EventArgs e)
        {
            splitContainerControl1.SplitterPosition = (Height / 4) * 2;
            splitContainerControl2.SplitterPosition = (Width / 4) * 2;
        }
    }
}