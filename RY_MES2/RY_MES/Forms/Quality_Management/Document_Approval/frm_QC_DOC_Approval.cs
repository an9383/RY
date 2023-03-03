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
    public partial class frm_QC_DOC_Approval : RY_MES.frm_Base
    {
        private string _TEMPLATE_TYPE = "0001";

        public frm_QC_DOC_Approval()
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
                string fa_id = dr["FA_ID"].ToString();
                string template_type = "0001";

                frm_QC_DOC_Approval_Popup popup = new frm_QC_DOC_Approval_Popup(ticket_id, fa_id, template_type);

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
    }
}