using DevExpress.Utils.Menu;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Menu;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using nsCommon;
using System;
using System.Data;

namespace RY_MES.Forms
{
    public partial class frm_CHK_Template : RY_MES.frm_Base
    {
        public frm_CHK_Template()
        {
            InitializeComponent();
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            _RYMES_DB = _Main._RYMES_DB;

            splitContainerControl1.PanelVisibility = SplitPanelVisibility.Both;
            splitContainerControl1.SplitterPosition = Height / 2;

            lc_Conditions.Visible = false;
            btn_Conditions.Visible = false;

            btn_Refresh_Click(null, null);

            (gridControl.MainView as ucGridView).RowClick += gridView_RowClick;
            (gridControl.MainView as ucGridView).PopupMenuShowing += gridView_PopupMenuShowing;
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(_Main, typeof(frm_Wait), true, true, false);
            try
            {
                Get_Data_Grid(gridControl);

                string template_id = (gridControl.MainView as ucGridView).GetFocusedDataRow()["TEMPLATE_ID"].ToString();
                Get_Data_Grid1(gridControl1, template_id);
            }
            finally
            {
                //Close Wait Form
                SplashScreenManager.CloseForm(false);
                gridControl.Focus();
            }
        }

        public void Get_Data_Grid(ucGridControl grid)
        {
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

        public void Get_Data_Grid1(ucGridControl grid, string template_id)
        {
            ucGridView view = (grid.MainView as ucGridView);
            DataTable dt = new DataTable();

            _RYMES_DB._DB_Parameters.Add("@p_TEMPLATE_ID", template_id);

            string sMsg = _RYMES_DB.GET_DATA("QM_DG_CHK_TEMPLATE_LOAD", ref dt);

            if (string.IsNullOrEmpty(sMsg))
            {
                grid.DataSource = dt;
                view.MemoEdit_Column("CHK_PROCESS_NAME");
                view.MemoEdit_Column("CHK_NAME");
                view.MemoEdit_Column("CRITERIA");
            }
            else
            {
                grid.DataSource = null;
            }

            RestoreLayout(this, (grid.MainView as ucGridView));
        }

        private void gridView_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            SplashScreenManager.ShowForm(_Main, typeof(frm_Wait), true, true, false);
            try
            {
                GridView view = sender as GridView;

                if (view.FocusedRowHandle > -1)
                {
                    Get_Data_Grid1(gridControl1, view.GetFocusedDataRow()["TEMPLATE_ID"].ToString());
                }
            }
            finally
            {
                //Close Wait Form
                SplashScreenManager.CloseForm(false);
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

            item = new DXMenuItem("Export", null, Properties.Resources.exporttoxlsx_16x16);
            item.Click += (o, args) =>
            {
                gridControl.Grid_Export();
            };
            e.Menu.Items.Add(item);
        }

        private void frm_SizeChanged(object sender, EventArgs e)
        {
            splitContainerControl1.PanelVisibility = SplitPanelVisibility.Both;
            splitContainerControl1.SplitterPosition = Height / 2;
        }
    }
}