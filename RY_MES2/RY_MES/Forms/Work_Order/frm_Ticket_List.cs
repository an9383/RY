using DevExpress.Utils.Menu;
using DevExpress.XtraGrid.Menu;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using nsCommon;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace RY_MES.Forms
{
    public partial class frm_Ticket_List : RY_MES.frm_Base
    {
        private bool isRunning = false;

        public frm_Ticket_List()
        {
            InitializeComponent();
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            _RYMES_DB = _Main._RYMES_DB;

            splitContainerControl1.SplitterPosition = (Height / 4) * 2;

            pnl_Conditions.Visible = true;
            btn_Conditions.Enabled = false;

            btn_Search_Click(null, null);

            ucGridView1.RowClick += GridView_RowClick;
            ucGridView1.PopupMenuShowing += gridView_PopupMenuShowing;
            ucGridView2.PopupMenuShowing += gridView_PopupMenuShowing;
            ucGridView4.PopupMenuShowing += gridView_PopupMenuShowing;
            ucGridView1.SelectionChanged += gridView_SelectionChanged;
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

                string sMsg = _RYMES_DB.GET_DATA("WO_TICKET_LOAD", ref dt);

                if (string.IsNullOrEmpty(sMsg))
                {
                    grid.DataSource = dt;

                    view.MemoEdit_Column("ITEM_NAME");
                    view.CheckBox_Column_Add();

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
            ucGridView view = grid.MainView as ucGridView;

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

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            GridView view = ucGridView1;

            if (view.SelectedRowsCount > 0)
            {
                if (MessageBox.Show("총 " + view.SelectedRowsCount + "개의 작업지시를 삭제하시겠습니까?", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SplashScreenManager.ShowForm(_Main, typeof(frm_Wait), true, true, false);

                    try
                    {
                        string sTicket = "";
                        int[] selectedRowsHandle = view.GetSelectedRows();

                        for (int i = 0; i < selectedRowsHandle.Length; i++)
                        {
                            int rowhandle = selectedRowsHandle[i];
                            DataRow dr = view.GetDataRow(rowhandle);

                            sTicket += dr["TICKET_ID"].ToString() + ',';
                        }

                        _RYMES_DB._DB_Parameters.Add("@p_TICKETS", sTicket);
                        _RYMES_DB._DB_Parameters.Add("@p_CREATE_USER", _Main._User_Info["USER_CODE"].ToString());

                        string sMsg = _RYMES_DB.SET_DATA("WO_TICKET_DELETE");

                        SplashScreenManager.CloseForm(false);

                        if (string.IsNullOrEmpty(sMsg))
                        {
                            MessageBox.Show("Success", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btn_Search_Click(null, null);
                        }
                        else
                        {
                            MessageBox.Show(sMsg, "DB ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        SplashScreenManager.CloseForm(false);
                        MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btn_Complete_Click(object sender, EventArgs e)
        {
            GridView view = ucGridView1;

            if (view.SelectedRowsCount > 0)
            {
                if (MessageBox.Show("총 " + view.SelectedRowsCount + "개의 작업지시를 마감하시겠습니까?", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SplashScreenManager.ShowForm(_Main, typeof(frm_Wait), true, true, false);

                    try
                    {
                        string sTicket = "";
                        int[] selectedRowsHandle = view.GetSelectedRows();

                        for (int i = 0; i < selectedRowsHandle.Length; i++)
                        {
                            int rowhandle = selectedRowsHandle[i];
                            DataRow dr = view.GetDataRow(rowhandle);

                            sTicket += dr["TICKET_ID"].ToString() + ',';
                        }

                        _RYMES_DB._DB_Parameters.Add("@p_TICKETS", sTicket);
                        _RYMES_DB._DB_Parameters.Add("@p_CREATE_USER", _Main._User_Info["USER_CODE"].ToString());

                        string sMsg = _RYMES_DB.SET_DATA("WO_TICKET_COMPLETE");

                        SplashScreenManager.CloseForm(false);

                        if (string.IsNullOrEmpty(sMsg))
                        {
                            MessageBox.Show("Success", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btn_Search_Click(null, null);
                        }
                        else
                        {
                            MessageBox.Show(sMsg, "DB ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        SplashScreenManager.CloseForm(false);
                        MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void gridView_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if (isRunning)
            {
                return;
            }

            isRunning = true;
            GridView View = sender as GridView;
            if (e.Action == CollectionChangeAction.Add && View.IsGroupRow(e.ControllerRow))
            {
                View.UnselectRow(e.ControllerRow);
            }
            if (e.Action == CollectionChangeAction.Refresh && View.SelectedRowsCount > 0)
            {
                View.BeginSelection();
                foreach (int Row in View.GetSelectedRows())
                {
                    if (View.IsGroupRow(Row))
                    {
                        View.UnselectRow(Row);
                    }
                }
                View.EndSelection();
            }
            isRunning = false;
        }

        private void frm_SizeChanged(object sender, EventArgs e)
        {
            splitContainerControl1.SplitterPosition = (Height / 4) * 2;
            splitContainerControl2.SplitterPosition = (Width / 4) * 2;
        }
    }
}