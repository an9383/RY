using DevExpress.Utils.Menu;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Menu;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using nsCommon;
using System;
using System.Data;
using System.Windows.Forms;

namespace RY_MES.Forms
{
    public partial class frm_ITEM_Master : RY_MES.frm_Base
    {
        public frm_ITEM_Master()
        {
            InitializeComponent();
        }

        public frm_ITEM_Master(object[] paramArray)
        {
            InitializeComponent();
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            _RYMES_DB = _Main._RYMES_DB;

            lc_Conditions.Enabled = false;
            btn_Conditions_Click(null, null);
            btn_Conditions.Enabled = false;
            
            ucGridView1.PopupMenuShowing += gridView_PopupMenuShowing;

            Get_Data_Grid(ucGridControl1);
            Set_Description(lc_edit);
        }

        private void Get_Data_Grid(ucGridControl grid)
        {
            ucGridView view = (grid.MainView as ucGridView);

            splitContainerControl1.PanelVisibility = SplitPanelVisibility.Panel1;
            ucGridControl1.Enabled = true;

            SplashScreenManager.ShowForm(_Main, typeof(frm_Wait), true, true, false);
            try
            {
                DataTable dt = new DataTable();
                string sMsg = _RYMES_DB.GET_DATA("BI_PI_ITEM_MASTER_LOAD", ref dt);
                if (string.IsNullOrEmpty(sMsg))
                {
                    grid.DataSource = dt;

                    view.MemoEdit_Column("ITEM_NAME");
                    view.MemoEdit_Column("ITEM_SPEC");
                    view.Link_Column("MODEL_CODE", "frm_MODEL_Master");
                    view.Link_Column("RT_ID", "frm_OPRT_Master");
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

            if (e.MenuType == GridMenuType.Row)
            {
                item = new DXMenuItem("Edit", null, Properties.Resources.edit_16x16);
                item.Click += (o, args) =>
                {
                    SHOW_EDIT(view, o);
                };
                e.Menu.Items.Add(item);
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

        private void SHOW_EDIT(GridView gridView, object sender)
        {
            splitContainerControl1.SplitterPosition = (Width / 4) * 3;
            splitContainerControl1.PanelVisibility = SplitPanelVisibility.Both;

            gridView.GridControl.Enabled = false;

            DXMenuItem menu = (DXMenuItem)sender;
            Root.Text = menu.Caption;

            DataRow dataRow = ((DataRowView)gridView.GetFocusedRow()).Row;

            SET_LookUpEdit_Data(le_ITEM_GROUP, "ITEM_GROUP");
            SET_LookUpEdit_Data(le_MODEL_CODE, "MODEL_MASTER");
            SET_LookUpEdit_Data(le_RT_ID, "RT_MASTER");
            SET_LookUpEdit_Data(le_QC_DOC_ID, "TEMPLATE_MASTER_OPTION", "0001");
            SET_LookUpEdit_Data(le_OQC_DOC_ID, "TEMPLATE_MASTER_OPTION", "0002");

            DataSet ds_lookup = new DataSet();
                      

            string sMsg = _RYMES_DB.GET_DATA("BI_PI_PM_CODE_LOAD", ref ds_lookup);
            if (string.IsNullOrEmpty(sMsg))
            {
                cb_PM_BIZ.Properties.Items.Clear();
                cb_PM_GROUP.Properties.Items.Clear();
                cb_PM_MODEL.Properties.Items.Clear();
                cb_ITEM_TYPE.Properties.Items.Clear();

                foreach (DataRow dr in ds_lookup.Tables[0].Rows)
                {
                    cb_PM_BIZ.Properties.Items.Add(dr["PM_BIZ"]);
                }

                foreach (DataRow dr in ds_lookup.Tables[1].Rows)
                {
                    cb_PM_GROUP.Properties.Items.Add(dr["PM_GROUP"]);
                }

                foreach (DataRow dr in ds_lookup.Tables[2].Rows)
                {
                    cb_PM_MODEL.Properties.Items.Add(dr["PM_MODEL"]);
                }

                foreach (DataRow dr in ds_lookup.Tables[3].Rows)
                {
                    cb_ITEM_TYPE.Properties.Items.Add(dr["ITEM_TYPE"]);
                }
            }

            txt_ITEM_CODE.Text = dataRow["ITEM_CODE"].ToString();
            txt_ITEM_NAME.Text = dataRow["ITEM_NAME"].ToString();
            txt_ITEM_SPEC.Text = dataRow["ITEM_SPEC"].ToString();
            le_ITEM_GROUP.EditValue = dataRow["ITEM_GROUP"].ToString();
            le_MODEL_CODE.EditValue = dataRow["MODEL_CODE"].ToString();
            cb_PM_BIZ.EditValue = dataRow["PM_BIZ"].ToString();
            cb_PM_GROUP.EditValue = dataRow["PM_GROUP"].ToString();
            cb_PM_MODEL.EditValue = dataRow["PM_MODEL"].ToString();
            cb_ITEM_TYPE.EditValue = dataRow["ITEM_TYPE"].ToString();
            le_RT_ID.EditValue = dataRow["RT_ID"].ToString();
            le_QC_DOC_ID.EditValue = dataRow["QC_DOC_ID"].ToString();
            le_OQC_DOC_ID.EditValue = dataRow["OQC_DOC_ID"].ToString();
            txt_STD_DOC_LINK.Text = dataRow["STD_DOC_LINK"].ToString();
            txt_OQC_STD_DOC_LINK.Text = dataRow["OQC_STD_DOC_LINK"].ToString();
            rb_FT_AUTO_YN.EditValue = string.IsNullOrEmpty(dataRow["FT_AUTO_YN"].ToString()) ? "N" : dataRow["FT_AUTO_YN"].ToString();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(cb_PM_BIZ.EditValue.ToString()) && !cb_PM_BIZ.Properties.Items.Contains(cb_PM_BIZ.EditValue))
            {
                if (MessageBox.Show(cb_PM_BIZ.EditValue + "를 PM_BIZ로 신규 등록 하시겠습니까?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                {
                    return;
                }
            }

            if (!string.IsNullOrEmpty(cb_PM_GROUP.EditValue.ToString()) && !cb_PM_GROUP.Properties.Items.Contains(cb_PM_GROUP.EditValue))
            {
                if (MessageBox.Show(cb_PM_GROUP.EditValue + "를 PM_GROUP으로 신규 등록 하시겠습니까?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                {
                    return;
                }
            }

            if (!string.IsNullOrEmpty(cb_PM_MODEL.EditValue.ToString()) && !cb_PM_MODEL.Properties.Items.Contains(cb_PM_MODEL.EditValue))
            {
                if (MessageBox.Show(cb_PM_MODEL.EditValue + "를 PM_MODEL로 신규 등록 하시겠습니까?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                {
                    return;
                }
            }

            if (!string.IsNullOrEmpty(cb_ITEM_TYPE.EditValue.ToString()) && !cb_ITEM_TYPE.Properties.Items.Contains(cb_ITEM_TYPE.EditValue))
            {
                if (MessageBox.Show(cb_ITEM_TYPE.EditValue + "를 ITEM_TYPE로 신규 등록 하시겠습니까?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                {
                    return;
                }
            }

            try
            {
                _RYMES_DB._DB_Parameters = Get_Conditions_Params(lc_edit.Root);
                _RYMES_DB._DB_Parameters.Add("@p_CREATE_USER", _Main._User_Info["USER_CODE"].ToString());

                string sMsg = _RYMES_DB.SET_DATA("BI_PI_ITEM_MASTER_MERGE");
                if (string.IsNullOrEmpty(sMsg))
                {
                    MessageBox.Show("Save Success", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Get_Data_Grid(ucGridControl1);
                }
                else
                {
                    MessageBox.Show(sMsg, "DB ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            splitContainerControl1.PanelVisibility = SplitPanelVisibility.Panel1;
            ucGridControl1.Enabled = true;
        }

        private void frm_SizeChanged(object sender, EventArgs e)
        {
            splitContainerControl1.SplitterPosition = (Width / 4) * 3;
        }
    }
}