using DevExpress.Utils.Menu;
using DevExpress.XtraGrid.Menu;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using DevExpress.XtraSplashScreen;
using nsCommon;
using System;
using System.Data;
using System.Windows.Forms;

namespace RY_MES.Forms
{
    public partial class frm_Panel_List_TFT : RY_MES.frm_Base
    {
        private string fa_id = "TFT";

        public frm_Panel_List_TFT()
        {
            InitializeComponent();
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            _RYMES_DB = _Main._RYMES_DB;

            lc_Conditions.Visible = false;
            pnl_Conditions.Visible = true;
            btn_Conditions.Visible = false;

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

                _RYMES_DB._DB_Parameters.Add("@p_FA_ID", fa_id);
                string sMsg = _RYMES_DB.GET_DATA("WO_WAFER_MASTER_LOAD", ref dt);

                if (string.IsNullOrEmpty(sMsg))
                {
                    grid.DataSource = dt;

                    view.CheckBox_Column_Add();

                    view.Columns["WAFER_NO"].Caption = "Panel 번호";
                    view.Columns["WAFER_STATUS"].Caption = "Panel 상태";

                    view.Link_Column("WAFER_NO", "frm_Panel_His_TFT");
                }
                else
                {
                    grid.DataSource = null;
                }

                view.BestFitColumns();
            }
            finally
            {
                SplashScreenManager.CloseForm(false);
                grid.Focus();
            }
        }

        private void btn_Out_Click(object sender, EventArgs e)
        {
            GridView view = ucGridView1;

            if (view.SelectedRowsCount > 0)
            {
                if (MessageBox.Show("총 " + view.SelectedRowsCount + "개의 panel을 마감하시겠습니까?", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SplashScreenManager.ShowForm(_Main, typeof(frm_Wait), true, true, false);

                    try
                    {
                        string sWafer = "";
                        int[] selectedRowsHandle = view.GetSelectedRows();

                        for (int i = 0; i < selectedRowsHandle.Length; i++)
                        {
                            int rowhandle = selectedRowsHandle[i];
                            DataRow dr = view.GetDataRow(rowhandle);

                            sWafer += dr["WAFER_NO"].ToString() + ',';
                        }

                        _RYMES_DB._DB_Parameters.Add("@p_FA_ID", fa_id);
                        _RYMES_DB._DB_Parameters.Add("@p_WAFERS", sWafer);
                        _RYMES_DB._DB_Parameters.Add("@p_CREATE_USER", _Main._User_Info["USER_CODE"].ToString());

                        string sMsg = _RYMES_DB.SET_DATA("WO_WAFER_MASTER_COMPLETE");

                        SplashScreenManager.CloseForm(false);

                        if (string.IsNullOrEmpty(sMsg))
                        {
                            MessageBox.Show("Success", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Get_Data_Grid(gridControl);
                        }
                        else
                        {
                            MessageBox.Show(sMsg, "DB ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        SplashScreenManager.CloseForm(false);
                        MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btn_Reuse_Click(object sender, EventArgs e)
        {
            GridView view = ucGridView1;

            if (view.SelectedRowsCount != 1)
            {
                MessageBox.Show("재사용할 Panel을 한 개 선택해주세요.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (view.GetRowCellValue(view.GetSelectedRows()[0], "WAFER_STATUS_CODE").ToString() != "0005")
            {
                MessageBox.Show("Panel 상태가 실적등록인 Panel만 재투입 가능합니다.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            SplashScreenManager.ShowForm(_Main, typeof(frm_Wait), true, true, false);

            try
            {
                string wafer_no = view.GetFocusedDataRow()["WAFER_NO"].ToString();

                _RYMES_DB._DB_Parameters.Add("@p_FA_ID", fa_id);
                _RYMES_DB._DB_Parameters.Add("@p_WAFER_NO", wafer_no);
                _RYMES_DB._DB_Parameters.Add("@p_RESULT", "rework");
                _RYMES_DB._DB_Parameters.Add("@p_CREATE_USER", _Main._User_Info["USER_CODE"].ToString());

                string sMsg = _RYMES_DB.SET_DATA("WO_REUSE_WAFER_UPDATE");

                if (!string.IsNullOrEmpty(sMsg))
                {
                    SplashScreenManager.CloseForm(false);
                    MessageBox.Show(sMsg, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    SplashScreenManager.CloseForm(false);
                    return;
                }
                else
                {
                    SplashScreenManager.CloseForm(false);
                    MessageBox.Show("Panel : " + wafer_no + " 을 재투입 가능한 상태로 변경했습니다.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Get_Data_Grid(gridControl);
                }
            }
            catch (Exception ex)
            {
                SplashScreenManager.CloseForm(false);
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btn_Regist_Click(object sender, EventArgs e)
        {
            frm_Wafer_Popup popup = new frm_Wafer_Popup("TFT");

            if (DialogResult.OK == popup.ShowDialog())
            {
                Get_Data_Grid(gridControl);
            }
        }
    }
}