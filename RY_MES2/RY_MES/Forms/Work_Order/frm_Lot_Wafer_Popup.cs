using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using nsCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace RY_MES.Forms
{
    public partial class frm_Lot_Wafer_Popup : RY_MES.frm_Base
    {
        private string lot_no { get; set; }
        private DataTable dt1;
        private DataTable dt2;

        public frm_Lot_Wafer_Popup()
        {
            TopLevel = true;
            InitializeComponent();

            lot_no = "";
            lbl_LOT_NO.Text = "Lot 신규 등록";
        }

        public frm_Lot_Wafer_Popup(params object[] paramArray)
        {
            TopLevel = true;
            InitializeComponent();

            lot_no = paramArray[0].ToString();
            lbl_LOT_NO.Text = lot_no;
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            _RYMES_DB = _Main._RYMES_DB;

            pnl_Conditions.Visible = false;
            btn_Conditions.Visible = false;

            Get_Data_Grid(ucGridControl1);
            Get_Data_Grid1(ucGridControl2);

            ucGridView1.OptionsSelection.MultiSelect = true;
            ucGridView2.OptionsSelection.MultiSelect = true;
        }

        private void Get_Data_Grid(ucGridControl grid)
        {
            ucGridView view = grid.MainView as ucGridView;

            try
            {
                dt1 = new DataTable();

                if (lot_no != null)
                {
                    _RYMES_DB._DB_Parameters.Add("@p_LOT_NO", lot_no);
                }
                string sMsg = _RYMES_DB.GET_DATA("WO_LOT_WAFER_LOAD_POP", ref dt1);

                grid.DataSource = dt1;
                view.BestFitColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Get_Data_Grid1(ucGridControl grid)
        {
            ucGridView view = grid.MainView as ucGridView;

            try
            {
                dt2 = new DataTable();

                string sMsg = _RYMES_DB.GET_DATA("WO_WAFER_MASTER_UNMAPPED_LOAD", ref dt2);

                grid.DataSource = dt2;
                view.BestFitColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Insert_Click(object sender, EventArgs e)
        {
            updateLotWafer(ucGridControl2, ucGridControl1);
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            updateLotWafer(ucGridControl1, ucGridControl2);
        }

        private void updateLotWafer(ucGridControl sourceGrid, ucGridControl targetGrid)
        {
            ucGridView sourceView = (sourceGrid.MainView as ucGridView);
            ucGridView targetView = (targetGrid.MainView as ucGridView);

            if (sourceView.SelectedRowsCount <= 0)
            {
                return;
            }

            DataTable sourceTable = sourceGrid.DataSource as DataTable;
            DataTable targetTable = targetGrid.DataSource as DataTable;

            int[] sourceHandles = sourceView.GetSelectedRows();

            int targetRowHandle = targetView.SelectedRowsCount == 0 ? 0 : targetView.FocusedRowHandle;
            int targetRowIndex = targetView.GetDataSourceRowIndex(targetRowHandle);

            targetRowIndex = targetRowIndex <= 0 ? targetTable.Rows.Count : targetRowIndex + 1;

            List<DataRow> rows = new List<DataRow>();

            foreach (int sourceHandle in sourceHandles)
            {
                int oldRowIndex = sourceView.GetDataSourceRowIndex(sourceHandle);
                DataRow oldRow = sourceTable.Rows[oldRowIndex];
                rows.Add(oldRow);
            }

            for (int i = rows.Count - 1; i >= 0; i--)
            {
                DataRow oldRow = rows[i];
                DataRow newRow = targetTable.NewRow();
                newRow.ItemArray = oldRow.ItemArray;

                targetTable.Rows.InsertAt(newRow, targetRowIndex);
                sourceTable.Rows.Remove(oldRow);
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (ucGridView1.RowCount == 0 && lbl_LOT_NO.Text != "Lot 신규 등록")
            {
                if (MessageBox.Show("Lot과 연결할 wafer 가 없습니다. 해당 Lot을 삭제하시겠습니까?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    == DialogResult.Yes)
                {
                    try
                    {
                        _RYMES_DB._DB_Parameters.Add("@p_LOT_NO", lbl_LOT_NO.Text);
                        string sMs = _RYMES_DB.SET_DATA("WO_LOT_MASTER_DELETE");                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "DB ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    return;
                }
            }

            string sWAFERS = "";
            DataRow[] drs = dt1.Select();

            foreach (DataRow dr in drs)
            {
                sWAFERS += dr["WAFER_NO"].ToString() + ',';
            }

            SplashScreenManager.ShowForm(_Main, typeof(frm_Wait), true, true, false);
            try
            {
                GridView view = ucGridView1;

                _RYMES_DB._DB_Parameters.Add("@p_LOT_NO", lot_no);
                _RYMES_DB._DB_Parameters.Add("@p_WAFER_NOS", sWAFERS);
                _RYMES_DB._DB_Parameters.Add("@p_CREATE_USER", _Main._User_Info["USER_CODE"].ToString());

                string sMsg = _RYMES_DB.SET_DATA("WO_LOT_WAFER_MERGE");

                SplashScreenManager.CloseForm(false);

                if (!string.IsNullOrEmpty(sMsg))
                {
                    MessageBox.Show(sMsg, "DB ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    MessageBox.Show("Save Success", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DialogResult = DialogResult.OK;
                    Close();
                    Dispose();
                }
            }
            catch (Exception ex)
            {
                SplashScreenManager.CloseForm(false);

                MessageBox.Show(ex.ToString(), "DB ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}