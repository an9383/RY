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
    public partial class frm_Defect_Monitoring : RY_MES.frm_Base
    {
        int[] p_handles;
        public frm_Defect_Monitoring()
        {
            InitializeComponent();
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            _RYMES_DB = _Main._RYMES_DB;

            pnl_Conditions.Visible = false;
            btn_Conditions.Visible = false;

            Get_Data_Grid(gridControl);

            ucGridView1.PopupMenuShowing += gridView_PopupMenuShowing;
        }

        private void Get_Data_Grid(ucGridControl grid)
        {
            ucGridView view = (grid.MainView as ucGridView);
            SplashScreenManager.ShowForm(_Main, typeof(frm_Wait), true, true, false);
            try
            {
                DataTable dt = new DataTable();
                string sMsg = _RYMES_DB.GET_DATA("QM_DEFECT_MONITORING_LOAD", ref dt);

                if (string.IsNullOrEmpty(sMsg))
                {
                    grid.DataSource = dt;

                    view.Set_Column_Type("DEFECT_DATE", ucGridView.Col_Type.DateTime);
                    view.MemoEdit_Column("ITEM_NAME");
                    view.MemoEdit_Column("DEFECT_NOTES");

                    view.Columns["SUPER_REASON_CODE"].Caption = "상위부적합명";
                    view.Columns["REASON_CODE"].Caption = "부적합명";
                }
                else
                {
                    grid.DataSource = null;
                }

                RestoreLayout(this, view);

            }
            finally
            {
                p_handles = null;
                SplashScreenManager.CloseForm(false);
                gridControl.Focus();
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
                Get_Data_Grid(gridControl);
            };
            e.Menu.Items.Add(item);

            item = new DXMenuItem("Export", null, Properties.Resources.exporttoxlsx_16x16);
            item.Click += (o, args) =>
            {
                gridControl.Grid_Export();
            };
            e.Menu.Items.Add(item);
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {

            int[] row_hanbles = ucGridView1.GetSelectedRows();
  
            if (row_hanbles.Length > 0)
            {
                List<int> defect_ids = new List<int>();
                foreach (int row_hanble in row_hanbles)
                {
                    defect_ids.Add(Convert.ToInt32( ucGridView1.GetRowCellValue(row_hanble, "DEFECT_ID")));
                }                    

                frm_Defect_Monitoring_Popup popup = new frm_Defect_Monitoring_Popup(defect_ids);

                if (DialogResult.OK == popup.ShowDialog())
                {
                    Get_Data_Grid(gridControl);
                }
            }
            
        }

        private void ucGridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            int[] handles = ucGridView1.GetSelectedRows();
            if (handles.Length > 1 )
            {
                foreach (int handle in handles)
                {
                    if( ucGridView1.GetRowCellValue(handles[0], "WO_ID").ToString() != ucGridView1.GetRowCellValue(handle, "WO_ID").ToString())
                    {
                        set_p_handles();
                        MessageBox.Show("작업지시가 다릅니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (ucGridView1.GetRowCellValue(handles[0], "REASON_CODE").ToString() != ucGridView1.GetRowCellValue(handle, "REASON_CODE").ToString())
                    {
                        set_p_handles();
                        MessageBox.Show("부적합 현상이 다릅니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (ucGridView1.GetRowCellValue(handles[0], "DEFECT_SN").ToString() != ucGridView1.GetRowCellValue(handle, "DEFECT_SN").ToString())
                    {
                        set_p_handles();
                        MessageBox.Show("S/N이 다릅니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                }
            }
            p_handles = handles;

        }

        private void set_p_handles()
        {
            ucGridView1.SelectionChanged -= ucGridView1_SelectionChanged;
            ucGridView1.ClearSelection();
            foreach (int item in p_handles)
            {
                ucGridView1.SelectRow(item);
            }
            ucGridView1.SelectionChanged += ucGridView1_SelectionChanged;
        }
    }
}