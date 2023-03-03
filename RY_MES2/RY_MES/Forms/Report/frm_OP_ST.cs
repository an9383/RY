using DevExpress.Utils.Menu;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Menu;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using nsCommon;
using System;
using System.Data;
using System.Windows.Forms;

namespace RY_MES.Forms
{
    public partial class frm_OP_ST : RY_MES.frm_Base
    {
        public frm_OP_ST()
        {
            InitializeComponent();
        }

        public frm_OP_ST(params object[] paramArray)
        {
            InitializeComponent();
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            _RYMES_DB = _Main._RYMES_DB;


            

            ucGridView1.PopupMenuShowing += gridView_PopupMenuShowing;
            
            Get_Data_Grid(ucGridControl1);
        }

        private void Get_Data_Grid(ucGridControl grid)
        {
            ucGridView view = grid.MainView as ucGridView;
            grid.Enabled = true;

            SplashScreenManager.ShowForm(_Main, typeof(frm_Wait), true, true, false);
            try
            {
                DataTable dt = new DataTable();

                _RYMES_DB._DB_Parameters.Add("@p_To", de_To.Text);
                _RYMES_DB._DB_Parameters.Add("@p_From", de_From.Text);

                string sMsg = _RYMES_DB.GET_DATA("RP_OP_ST_LOAD", ref dt);
                if (string.IsNullOrEmpty(sMsg))
                {
                    grid.DataSource = dt;

                    view.Set_Column_Type("기준ST", ucGridView.Col_Type.Numeric, "2");
                    view.Set_Column_Type("ST", ucGridView.Col_Type.Numeric, "2");
                    view.Set_Column_Type("WO_START_DATE", ucGridView.Col_Type.DateTime);
                    view.Set_Column_Type("WO_END_DATE", ucGridView.Col_Type.DateTime);
                    view.Set_Column_Type("RUN_TIME", ucGridView.Col_Type.Numeric, "2");

                    view.Set_Column_Type("DOWN_TIME", ucGridView.Col_Type.Numeric, "2");

                    if (_Main._User_Info["FA_ID"].ToString() == "TFT")
                    {
                        view.Link_Column("WAFER_NO", "frm_Panel_His_TFT");
                    }
                    else if (_Main._User_Info["FA_ID"].ToString() == "CSI")
                    {
                        view.Link_Column("WAFER_NO", "frm_Panel_His_CSI");
                    }
                    else
                    {
                        view.Link_Column("WAFER_NO", "frm_Wafer_His");
                    }
                }
                else
                {
                    grid.DataSource = null;
                }
                
                RestoreLayout(this, view);
                ucGridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
                 new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "", null, "")});
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

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            ucGridView1.GroupCount = 0;
            ucGridView1.Columns["ITEM_GROUP"].Group();
            ucGridView1.Columns["OP_NAME"].Group();
            ucGridView1.Columns["ITEM_CODE"].Group();
            ucGridView1.Columns["TIME"].Group();
            ucGridView1.ExpandAllGroups();
            ucGridView1.SetGroupLevelExpanded(3, false, true);
        }
    }
}