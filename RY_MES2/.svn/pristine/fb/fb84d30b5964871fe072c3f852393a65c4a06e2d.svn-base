using DevExpress.Utils.Menu;
using DevExpress.XtraGrid.Menu;
using DevExpress.XtraSplashScreen;
using nsCommon;
using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace RY_MES.Forms
{
    public partial class frm_WO_Plan_Management : RY_MES.frm_Base
    {
        public frm_WO_Plan_Management()
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

        private void Get_Data_Grid(ucGridControl grid)
        {
            ucGridView view = grid.MainView as ucGridView;

            SplashScreenManager.ShowForm(_Main, typeof(frm_Wait), true, true, false);
            try
            {
                DataTable dt = new DataTable();

                _RYMES_DB._DB_Parameters.Add("@p_To", de_To.Text);
                _RYMES_DB._DB_Parameters.Add("@p_From", de_From.Text);

                string sMsg = _RYMES_DB.GET_DATA("WO_WO_MASTER_LOAD", ref dt);

                if (string.IsNullOrEmpty(sMsg))
                {
                    grid.DataSource = dt;
                    view.CheckBox_Column_Add();
                    view.Columns["PLAN_DATE"].AppearanceCell.BackColor = Color.Salmon;
                    view.MemoEdit_Column("ITEM_NAME");
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
            ucGridView view = sender as ucGridView;
            ucGridControl grid = view.GridControl as ucGridControl;

            DXMenuItem item;

            if (e.Menu == null)
            {
                e.Menu = new GridViewMenu(view);
            }

            item = new DXMenuItem("Refresh", null, Properties.Resources.refresh_16x16);
            item.Click += (o, args) =>
            {
                btn_Search_Click(null, null);
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

        private void btn_Update_Click(object sender, EventArgs e)
        {
            if (ucGridView1.SelectedRowsCount > 0)
            {
                DataTable dt = ucGridView1.GetDataRow(ucGridView1.GetSelectedRows()[0]).Table.Clone();
                ArrayList rows = new ArrayList();

                int[] selectedRowsHandle = ucGridView1.GetSelectedRows();
                for (int i = 0; i < selectedRowsHandle.Length; i++)
                {
                    int rowhandle = selectedRowsHandle[i];

                    DataRow row = dt.NewRow();
                    row.ItemArray = ucGridView1.GetDataRow(rowhandle).ItemArray;
                    dt.Rows.Add(row);
                }

                frm_WO_Popup popup = new frm_WO_Popup(dt);

                if (popup.ShowDialog() == DialogResult.OK)
                {
                    Get_Data_Grid(ucGridControl1);
                }
            }
        }
    }
}