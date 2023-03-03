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
    public partial class frm_Panel_His_TFT : RY_MES.frm_Base
    {
        public frm_Panel_His_TFT()
        {
            InitializeComponent();
        }

        public frm_Panel_His_TFT(params object[] paramArray)
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

            ucGridView1.OptionsFind.AlwaysVisible = false;
            ucGridView1.OptionsView.ShowGroupPanel = false;
            ucGridView1.OptionsCustomization.AllowFilter = false;

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
                MessageBox.Show("Info", "Panel No를 입력하세요.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            ucGridView view = (grid.MainView as ucGridView);

            SplashScreenManager.ShowForm(_Main, typeof(frm_Wait), true, true, false);
            try
            {
                DataSet ds = new DataSet();

                _RYMES_DB._DB_Parameters.Add("@p_WAFER_NO", txt_WAFER_NO.Text);

                string sMsg = _RYMES_DB.GET_DATA("PM_IP_PANEL_HIS_TFT_LOAD", ref ds);

                if (string.IsNullOrEmpty(sMsg))
                {
                    grid.DataSource = ds.Tables[0];

                    ucGridControl2.DataSource = ds.Tables[1];

                    if (ucGridView2.Columns["INPUT_QTY"] != null)
                    {
                        ucGridView2.Columns["INPUT_QTY"].Caption = "투입수량";
                    }

                    ucGridView2.Columns["REASON_CODE"].Caption = "부적합코드";
                    ucGridView2.Columns["SUPER_DEFECT_CAUSE"].Caption = "상위부적합코드";

                    ucGridView2.Set_Column_Type("WO_START_DATE", ucGridView.Col_Type.DateTime);
                    ucGridView2.Set_Column_Type("WO_END_DATE", ucGridView.Col_Type.DateTime);
                    
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

    }
}