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
    public partial class frm_QC_DOC_Approval_TFT : RY_MES.frm_Base
    {
        private string _TEMPLATE_TYPE = "0001";

        public frm_QC_DOC_Approval_TFT()
        {
            InitializeComponent();
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            _RYMES_DB = _Main._RYMES_DB;

            pnl_Conditions.Visible = true;
            btn_Conditions.Visible = false;

            Get_Data_Grid(gridControl);

            ucGridView1.PopupMenuShowing += gridView_PopupMenuShowing;
            ucGridView1.DoubleClick += gridView_DoubleClick;
        }

        private void Get_Data_Grid(ucGridControl grid)
        {
            SplashScreenManager.ShowForm(_Main, typeof(frm_Wait), true, true, false);
            try
            {
                DataTable dt = new DataTable();

                _RYMES_DB._DB_Parameters.Add("@p_To", de_To.Text);
                _RYMES_DB._DB_Parameters.Add("@p_From", de_From.Text);
                _RYMES_DB._DB_Parameters.Add("@p_TEMPLATE_TYPE", _TEMPLATE_TYPE);
                _RYMES_DB._DB_Parameters.Add("@p_FA_ID", "TFT");

                string sMsg = _RYMES_DB.GET_DATA("QM_CA_QC_DOC_APPROVE_LOAD", ref dt);

                if (string.IsNullOrEmpty(sMsg))
                {
                    grid.DataSource = dt;
                }
                else
                {
                    grid.DataSource = null;
                }

                RestoreLayout(this, (grid.MainView as ucGridView));
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

        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            GridView view = sender as GridView;
            view.SelectRow(view.FocusedRowHandle);

            if (view.FocusedRowHandle > -1)
            {
                DataRow dr = view.GetFocusedDataRow();
                string ticket_id = dr["TICKET_ID"].ToString();
                string template_type = "0001";
                string panel_no = dr["PANEL_NO"].ToString();

                frm_QC_DOC_Approval_Popup_TFT popup = new frm_QC_DOC_Approval_Popup_TFT(ticket_id, template_type, panel_no);
                
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

        private void btn_Apply_Click(object sender, EventArgs e)
        {
            if (ucGridView1.SelectedRowsCount <= 0)
            {
                MessageBox.Show("승인할 런시트를 선택해주세요.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string _ticket_ids = "";
            foreach (int rowHandle in ucGridView1.GetSelectedRows())
            {
                if (!string.IsNullOrEmpty(ucGridView1.GetRowCellValue(rowHandle, "APPLY_DATE").ToString()))
                {
                    MessageBox.Show("기승인 된 런시트는 재승인 할 수 없습니다.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                _ticket_ids += ucGridView1.GetRowCellValue(rowHandle, "TICKET_ID").ToString() + ",";
            }

            if (_Main._User_Info["AUTH_CODE"].ToString() != "1002")
            {
                MessageBox.Show("승인 권한이 없습니다.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                _RYMES_DB._DB_Parameters.Add("@p_TICKET_IDs", _ticket_ids);
                _RYMES_DB._DB_Parameters.Add("@p_TEMPLATE_TYPE", _TEMPLATE_TYPE);
                _RYMES_DB._DB_Parameters.Add("@p_APPLY_USER", _Main._User_Info["USER_CODE"].ToString());

                string sMsg = _RYMES_DB.SET_DATA("QM_CA_QC_DOC_HIS_UPDATE");

                SplashScreenManager.CloseForm(false);

                if (string.IsNullOrEmpty(sMsg))
                {
                    MessageBox.Show("Save Success!", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Get_Data_Grid(gridControl);
                }
                else
                {
                    MessageBox.Show(sMsg, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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