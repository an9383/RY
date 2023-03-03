using DevExpress.Utils.Menu;
using DevExpress.XtraGrid.Menu;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using nsCommon;
using System;
using System.Data;

namespace RY_MES.Forms
{
    public partial class frm_EQUIP_WORKER_HIS : RY_MES.frm_Base
    {
        public frm_EQUIP_WORKER_HIS()
        {
            InitializeComponent();
        }

        public frm_EQUIP_WORKER_HIS(object[] paramArray)
        {
            InitializeComponent();
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            _RYMES_DB = _Main._RYMES_DB;

            //lc_Conditions.Enabled = false;

            //btn_Conditions_Click(null, null);
            //btn_Conditions.Enabled = false;
            Get_Data_Grid(ucGridControl1);
        }

        private void Get_Data_Grid(ucGridControl grid)
        {
            ucGridView view = (grid.MainView as ucGridView);
            grid.Enabled = true;

            SplashScreenManager.ShowForm(_Main, typeof(frm_Wait), true, true, false);
            try
            {
                DataTable dt = new DataTable();

                _RYMES_DB._DB_Parameters.Add("@p_To", de_To.Text);
                _RYMES_DB._DB_Parameters.Add("@p_From", de_From.Text);
                string sMsg = _RYMES_DB.GET_DATA("WE_EQUIP_WORKER_HIS_LOAD", ref dt);
                if (string.IsNullOrEmpty(sMsg))
                {
                    grid.DataSource = dt;
                    view.Set_Column_Type("EW_START_DATE", ucGridView.Col_Type.DateTime);
                    view.Set_Column_Type("EW_END_DATE", ucGridView.Col_Type.DateTime);
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
            DXMenuItem item;

            if (e.Menu == null)
            {
                e.Menu = new GridViewMenu(view);
            }
            item = new DXMenuItem("Refresh", null, Properties.Resources.refresh_16x16);
            item.Click += (o, args) =>
            {
                Get_Data_Grid(ucGridControl1);
            };
            e.Menu.Items.Add(item);

            item = new DXMenuItem("Export", null, Properties.Resources.exporttoxlsx_16x16);
            item.Click += (o, args) =>
            {
                ucGridControl1.Grid_Export();
            };
            e.Menu.Items.Add(item);
        }
    }
}