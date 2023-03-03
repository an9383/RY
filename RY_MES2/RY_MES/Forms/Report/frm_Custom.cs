using DevExpress.Utils.Menu;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Menu;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using nsCommon;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace RY_MES.Forms
{
    public partial class frm_Custom : frm_Base
    {
        public frm_Custom()
        {
            InitializeComponent();
        }

        public frm_Custom(object[] paramArray)
        {
            InitializeComponent();
        }

        private void frm_Load(object sender, EventArgs e)
        {
            _RYMES_DB = _Main._RYMES_DB;
            btn_Conditions_Click(null, null);
            btn_Conditions.Enabled = false;

            btn_Search_Click(null, null);
            Set_Description(lc_edit);
        }

        public void Get_Data_Grid()
        {
            splitContainerControl1.PanelVisibility = SplitPanelVisibility.Panel1;
            ucGridControl1.Enabled = true;

            DataTable table = new DataTable();

            string sMsg = _RYMES_DB.GET_DATA("RP_CUSTOM_LOAD", ref table);
            if (string.IsNullOrEmpty(sMsg))
            {
                ucGridControl1.DataSource = table;
            }
            else
            {
                ucGridControl1.DataSource = null;
                MessageBox.Show(sMsg, "DB ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ucGridView1.BestFitColumns();

            //  RestoreLayout(this, gridView);

            memoEdit1.Text = ucGridView1.GetRowCellValue(0, "QUERY").ToString();
        }

        private void SHOW_EDIT(GridView gridView, object sender)
        {
            splitContainerControl1.SplitterPosition = (Width / 4) * 3;
            splitContainerControl1.PanelVisibility = SplitPanelVisibility.Both;
            gridView.GridControl.Enabled = false;

            DXMenuItem menu = (DXMenuItem)sender;

            Root.Text = menu.Caption;

            if (menu.Caption == "Add")
            {
                txt_SQL_NAME.Text = "";
                txt_QUERY.Text = "";

                lci_Delete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            else
            {
                DataRow dataRow = ((DataRowView)gridView.GetFocusedRow()).Row;

                txt_IDX.Text = dataRow["IDX"].ToString();
                txt_SQL_NAME.Text = dataRow["SQL_NAME"].ToString();
                txt_QUERY.Text = dataRow["QUERY"].ToString();

                lci_Delete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                btn_Delete.Text = dataRow["DELETE_USER"].ToString() == "" ? "Delete" : "Restore";
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            _RYMES_DB._DB_Parameters = Get_Conditions_Params(lc_edit.Root);
            _RYMES_DB._DB_Parameters.Add("@p_CREATE_USER", _Main._User_Info["USER_CODE"].ToString());

            string sMsg = _RYMES_DB.SET_DATA("RP_CUSTOM_MERGE");
            if (string.IsNullOrEmpty(sMsg))
            {
                MessageBox.Show("Save Success", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(sMsg, "DB ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            btn_Search_Click(null, null);
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            //if (DialogResult.OK == MessageBox.Show(((SimpleButton)sender).Text + "  " + txt_CELL_CODE.Text + " ?", ((SimpleButton)sender).Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            //{
            //    _VTMES_DB._DB_Parameters.Add("@p_FA_ID", lue_FA_ID.EditValue);
            //    _VTMES_DB._DB_Parameters.Add("@p_OP_ID", lue_OP_ID.EditValue);
            //    _VTMES_DB._DB_Parameters.Add("@p_CELL_CODE", txt_CELL_CODE.Text);
            //    _VTMES_DB._DB_Parameters.Add("@p_CREATE_USER", _Main._drUser_Info["USER_CODE"].ToString());

            //    string sMsg = _VTMES_DB.SET_DATA("BI_FI_CELL_MASTER_DELETE");
            //    if (string.IsNullOrEmpty(sMsg))
            //    {
            //        MessageBox.Show("Success", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //    else
            //    {
            //        MessageBox.Show(sMsg, "DB ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }

            //    btn_Search_Click(null, null);
            //}
        }

        private void gridView_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            ucGridView view = (ucGridView)sender;
            if (e.MenuType == GridMenuType.Row)
            {
                DXMenuItem item;

                if (view == ucGridView1)
                {
                    item = new DXMenuItem("Add", null, Properties.Resources.add_16x16);
                    item.Click += (o, args) => { SHOW_EDIT(ucGridView1, o); };
                    e.Menu.Items.Add(item);

                    item = new DXMenuItem("Edit", null, Properties.Resources.edit_16x16);
                    item.Click += (o, args) =>
                    {
                        if (view.GetSelectedRows().Length > 0)
                        {
                            SHOW_EDIT(ucGridView1, o);
                        }
                    };
                    e.Menu.Items.Add(item);

                    item = new DXMenuItem("Refresh", null, Properties.Resources.refresh_16x16);
                    item.Click += (o, args) => { btn_Search_Click(null, null); };
                    item.BeginGroup = true;
                    e.Menu.Items.Add(item);
                }

                item = new DXMenuItem("Export", null, Properties.Resources.exporttoxlsx_16x16);
                item.Click += (o, args) => { ((ucGridControl)view.GridControl).Grid_Export(); };
                item.BeginGroup = true;
                e.Menu.Items.Add(item);
            }
            if (e.MenuType == GridMenuType.User)
            {
                if (view == ucGridView1)
                {
                    if (e.Menu == null)
                    {
                        e.Menu = new GridViewMenu(view);
                    }
                    DXMenuItem item;

                    item = new DXMenuItem("Add", null, Properties.Resources.add_16x16);
                    item.Click += (o, args) => { SHOW_EDIT(view, o); };
                    e.Menu.Items.Add(item);

                    item = new DXMenuItem("Refresh", null, Properties.Resources.refresh_16x16);
                    item.Click += (o, args) => { btn_Search_Click(null, null); };
                    item.BeginGroup = true;
                    e.Menu.Items.Add(item);
                }
            }
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(_Main, typeof(frm_Wait), true, true, false);
            try
            {
                Get_Data_Grid();
            }
            finally
            {
                //Close Wait Form
                SplashScreenManager.CloseForm(false);
                ucGridControl1.Focus();
            }
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            btn_Search_Click(null, null);
        }

        private void gridView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (ucGridView1.GetRowCellValue(e.RowHandle, "DELETE_USER").ToString() != "")
            {
                e.Appearance.ForeColor = Color.LightGray;
            }
        }

        private void frm_SizeChanged(object sender, EventArgs e)
        {
            splitContainerControl1.SplitterPosition = (Width / 4) * 3;
        }

        private void gridView_RowClick(object sender, RowClickEventArgs e)
        {
            memoEdit1.Text = ucGridView1.GetRowCellValue(e.RowHandle, "QUERY").ToString();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            ucGridView2.Columns.Clear();

            DataTable table = new DataTable();

            string sMsg = _RYMES_DB.GET_DATA(memoEdit1.Text, ref table);
            if (string.IsNullOrEmpty(sMsg))
            {
                ucGridControl2.DataSource = table;
            }
            else
            {
                ucGridControl2.DataSource = null;
                MessageBox.Show(sMsg, "DB ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ucGridView2.BestFitColumns();
        }
    }
}