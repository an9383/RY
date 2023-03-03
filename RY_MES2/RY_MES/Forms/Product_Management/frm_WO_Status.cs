using DevExpress.Utils.Menu;
using DevExpress.XtraGrid.Menu;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using nsCommon;
using System;
using System.Data;
using System.Windows.Forms;

namespace RY_MES.Forms
{
    public partial class frm_WO_Status : RY_MES.frm_Base
    {
        public frm_WO_Status()
        {
            InitializeComponent();
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            _RYMES_DB = _Main._RYMES_DB;

            pnl_Conditions.Visible = true;
            btn_Conditions.Enabled = false;

            btn_Search_Click(null, null);

            ucGridView1.PopupMenuShowing += gridView_PopupMenuShowing;
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            Get_Data_Grid(gridControl);
        }

        private void Get_Data_Grid(ucGridControl grid)
        {
            ucGridView view = (grid.MainView as ucGridView);
            SplashScreenManager.ShowForm(_Main, typeof(frm_Wait), true, true, false);
            try
            {
                DataTable dt = new DataTable();

                _RYMES_DB._DB_Parameters.Add("@p_From", de_From.EditValue);
                _RYMES_DB._DB_Parameters.Add("@p_To", de_To.EditValue);
                _RYMES_DB._DB_Parameters.Add("@p_FA_ID", _Main._User_Info["FA_ID"].ToString());

                string sMsg = _RYMES_DB.GET_DATA("PM_IP_WO_MASTER_LOAD", ref dt);

                if (string.IsNullOrEmpty(sMsg))
                {
                    grid.DataSource = dt;

                    view.MemoEdit_Column("ITEM_NAME");
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
                gridControl.Focus();
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

        private void control_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Search_Click(null, null);
            }
        }
    }
}