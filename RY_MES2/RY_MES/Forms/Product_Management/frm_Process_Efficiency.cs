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
    public partial class frm_Process_Efficiency : frm_Base
    {
        public frm_Process_Efficiency()
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
            Get_Data_Grid();
        }

        private void Get_Data_Grid()
        {
            SplashScreenManager.ShowForm(_Main, typeof(frm_Wait), true, true, false);
            try
            {
                DataSet ds = new DataSet();

                _RYMES_DB._DB_Parameters.Add("@p_From", de_From.EditValue);
                _RYMES_DB._DB_Parameters.Add("@p_To", de_To.EditValue);
                _RYMES_DB._DB_Parameters.Add("@p_FA_ID", _Main._User_Info["FA_ID"].ToString());

                string sMsg = _RYMES_DB.GET_DATA("PM_PROCESS_EFFICIENCY_LOAD", ref ds);

                if (string.IsNullOrEmpty(sMsg))
                {
                    ucGridControl1.DataSource = ds.Tables[0];
                  

                    RestoreLayout(this, ucGridView1);
                }
                else
                {
                    ucGridControl1.DataSource = null;
                }
            }
            finally
            {
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
                Get_Data_Grid();
            };
            e.Menu.Items.Add(item);

            item = new DXMenuItem("Export", null, Properties.Resources.exporttoxlsx_16x16);
            item.Click += (o, args) =>
            {
                (view.GridControl as ucGridControl).Grid_Export();
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