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
    public partial class frm_Product_Plan : RY_MES.frm_Base
    {
        public frm_Product_Plan()
        {
            InitializeComponent();
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            _RYMES_DB = _Main._RYMES_DB;
            
            pnl_Conditions.Visible = true;
            btn_Conditions.Enabled = false;

            de_From.Text = DateTime.Now.ToShortDateString();
            de_To.Text = DateTime.Now.ToShortDateString();

            btn_Search_Click(null, null);

            ucGridView1.PopupMenuShowing += gridView_PopupMenuShowing;
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

                string sMsg = _RYMES_DB.GET_DATA("PM_IP_PRODUCT_PLAN_LOAD", ref dt);

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

        private void btn_Search_Click(object sender, EventArgs e)
        {
            Get_Data_Grid(ucGridControl1);
        }
    }
}