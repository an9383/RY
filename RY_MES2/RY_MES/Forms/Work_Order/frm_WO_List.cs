using DevExpress.Utils.Menu;
using DevExpress.XtraGrid.Menu;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using nsCommon;
using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;

namespace RY_MES.Forms
{
    public partial class frm_WO_List : RY_MES.frm_Base
    {
        public frm_WO_List()
        {
            InitializeComponent();
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            _RYMES_DB = _Main._RYMES_DB;

            pnl_Conditions.Visible = true;
            btn_Conditions.Enabled = false;

            Get_Data_Grid(gridControl);

            ucGridView1.PopupMenuShowing += gridView_PopupMenuShowing;
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

        private void Get_Data_Grid(ucGridControl grid)
        {
            ucGridView view = grid.MainView as ucGridView;

            SplashScreenManager.ShowForm(_Main, typeof(frm_Wait), true, true, false);
            try
            {
                DataTable dt = new DataTable();

                _RYMES_DB._DB_Parameters.Add("@p_To", de_To.Text);
                _RYMES_DB._DB_Parameters.Add("@p_From", de_From.Text);

                string sMsg = _RYMES_DB.GET_DATA("WO_MASTER_LOAD", ref dt);

                if (string.IsNullOrEmpty(sMsg))
                {
                    grid.DataSource = dt;

                    view.MemoEdit_Column("ITEM_NAME");
                    view.MemoEdit_Column("COMMENTS");


                    view.Columns["STATUS_NAME"].Caption = "상태";
                    view.Columns["TYPE_NAME"].Caption = "타입";
                    view.Columns["MES_QTY"].Caption = "작업수량";

                    view.Columns["STATUS"].Visible = false;
                    view.Columns["TYPE"].Visible = false;
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

        private void btn_CreateWO_Click(object sender, EventArgs e)
        {
            GridView view = ucGridView1;

            if (view.SelectedRowsCount > 0)
            {
                DataTable dt = view.GetDataRow(view.GetSelectedRows()[0]).Table.Clone();
                ArrayList rows = new ArrayList();

                int[] selectedRowsHandle = view.GetSelectedRows();
                for (int i = 0; i < selectedRowsHandle.Length; i++)
                {
                    int rowhandle = selectedRowsHandle[i];

                    DataRow row = dt.NewRow();
                    row.ItemArray = view.GetDataRow(rowhandle).ItemArray;
                    dt.Rows.Add(row);
                }

                frm_Ticket_Popup popup = new frm_Ticket_Popup(dt);

                if (DialogResult.OK == popup.ShowDialog())
                {
                    Get_Data_Grid(gridControl);
                }
            }
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            Get_Data_Grid(gridControl);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(_Main, typeof(frm_Wait), true, true, false);
            
            string msg = _RYMES_DB.SET_DATA("IF_FROM_RY_MES");

             SplashScreenManager.CloseForm(false);
            Get_Data_Grid(gridControl);
        }
    }
}