using DevExpress.Utils.Menu;
using DevExpress.XtraGrid.Menu;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using nsCommon;
using System;
using System.Data;
using System.Windows.Forms;
using static RY_MES.ucGridControl;

namespace RY_MES.Forms
{
    public partial class frm_Wafer_His : RY_MES.frm_Base
    {
        public frm_Wafer_His()
        {
            InitializeComponent();
        }

        public frm_Wafer_His(params object[] paramArray)
        {
            InitializeComponent();
            txt_WAFER_NO.Text = paramArray[0].ToString();
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            _RYMES_DB = _Main._RYMES_DB;

            pnl_Conditions.Visible = true;
            lc_Conditions.Visible = false;
            btn_Conditions.Enabled = false;

            ucGridView1.PopupMenuShowing += gridView_PopupMenuShowing;
            ucGridView2.PopupMenuShowing += gridView_PopupMenuShowing;

            if (!string.IsNullOrEmpty(txt_WAFER_NO.Text))
            {
                btn_Search_Click(null, null);
            }
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            Get_Data_Grid1(ucGridControl1);
        }

        private void Get_Data_Grid1(ucGridControl grid)
        {
            if (String.IsNullOrEmpty(txt_WAFER_NO.Text))
            {
                MessageBox.Show("Info", "Wafer No를 입력하세요.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            ucGridView view = (grid.MainView as ucGridView);

            SplashScreenManager.ShowForm(_Main, typeof(frm_Wait), true, true, false);
            try
            {
                DataTable dt = new DataTable();

                _RYMES_DB._DB_Parameters.Add("@p_WAFER_NO", txt_WAFER_NO.Text);

                string sMsg = _RYMES_DB.GET_DATA("PM_IP_WAFER_HIS_LOAD", ref dt);

                if (string.IsNullOrEmpty(sMsg))
                {
                    grid.DataSource = dt;

                
                    ucGridView1_RowClick(null, null);
                }
                else
                {
                    grid.DataSource = null;
                    ucGridControl2.DataSource = null;
                }

                RestoreLayout(this, view);
            }
            finally
            {
                SplashScreenManager.CloseForm(false);
                grid.Focus();
            }
        }

        private void Get_Data_Grid2(ucGridControl grid, string wafer_no)
        {
            ucGridView view = grid.MainView as ucGridView;

            SplashScreenManager.ShowForm(_Main, typeof(frm_Wait), true, true, false);
            try
            {
                DataTable dt = new DataTable();

                _RYMES_DB._DB_Parameters.Add("@p_WAFER_NO", wafer_no);

                string sMsg = _RYMES_DB.GET_DATA("PM_IP_WAFER_HIS_DETAIL_LOAD", ref dt);

                if (string.IsNullOrEmpty(sMsg))
                {
                    grid.DataSource = dt;

                    view.Columns["REASON_CODE"].Caption = "부적합코드";
                    view.Columns["SUPER_DEFECT_CAUSE"].Caption = "상위부적합코드";
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
                Get_Data_Grid1(grid);
            };
            e.Menu.Items.Add(item);

            item = new DXMenuItem("Export", null, Properties.Resources.exporttoxlsx_16x16);
            item.Click += (o, args) =>
            {
                grid.Grid_Export();
            };
            e.Menu.Items.Add(item);
        }

        private void control_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Search_Click(null, null);
            }
        }

        private void ucGridView1_RowClick(object sender, RowClickEventArgs e)
        {
            GridView view = ucGridView1;

            if (view.FocusedRowHandle > -1)
            {
                Get_Data_Grid2(ucGridControl2, ((DataRowView)view.GetFocusedRow()).Row["WAFER_NO"].ToString());
            }
        }        
    }
}