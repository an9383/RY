using DevExpress.Utils.Menu;
using DevExpress.XtraGrid.Menu;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using nsCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace RY_MES.Forms
{
    public partial class frm_Defect_Monitoring_His : RY_MES.frm_Base
    {
        private string defect_id = "";

        public frm_Defect_Monitoring_His()
        {
            InitializeComponent();
        }

        public frm_Defect_Monitoring_His(params object[] paramArray)
        {
            InitializeComponent();
            defect_id = paramArray[0].ToString();
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            _RYMES_DB = _Main._RYMES_DB;

            btn_Conditions.Visible = false;

            Get_Data_Grid(gridControl);

            ucGridView1.PopupMenuShowing += gridView_PopupMenuShowing;
            ucGridView1.FindFilterText = defect_id;
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
                _RYMES_DB._DB_Parameters.Add("@p_ALL_DATE", chk_ALL_DATE.Checked.ToString());

                string sMsg = _RYMES_DB.GET_DATA("QM_DEFECT_MASTER_LOAD", ref dt);

                if (string.IsNullOrEmpty(sMsg))
                {
                    grid.DataSource = dt;

                    view.Set_Column_Type("DEFECT_DATE", ucGridView.Col_Type.DateTime);

                    view.MemoEdit_Column("ITEM_NAME");
                    view.MemoEdit_Column("DEFECT_NOTES");
                    view.MemoEdit_Column("DEFECT_RESULT_NOTES");

                    view.Columns["DEFECT_CAUSE"].Visible = false;
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
            Get_Data_Grid(gridControl);
        }

        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            GridView view = sender as GridView;

            if (view.FocusedRowHandle > -1)
            {

                List<int> defect_ids = new List<int>();

                defect_ids.Add(Convert.ToInt32(ucGridView1.GetRowCellValue(view.FocusedRowHandle, "DEFECT_ID")));

                frm_Defect_Monitoring_Popup popup = new frm_Defect_Monitoring_Popup(defect_ids);

                if (DialogResult.OK == popup.ShowDialog())
                {
                    Get_Data_Grid(gridControl);
                }
            }
        }
    }
}