using DevExpress.Utils.Behaviors;
using DevExpress.Utils.DragDrop;
using DevExpress.Utils.Menu;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Menu;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraSplashScreen;
using nsCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace RY_MES.Forms
{
    public partial class frm_Create_Template : RY_MES.frm_Base
    {
        private string _Template_id = "";
        private string _fa_id = "";

        public frm_Create_Template()
        {
            InitializeComponent();
        }

        public frm_Create_Template(params object[] paramArray)
        {
            InitializeComponent();

            _Template_id = paramArray[0].ToString();
            _fa_id = paramArray[1].ToString();

            ucGridView view = (gridControl.MainView as ucGridView);

            behaviorManager1.SetBehaviors(view, new Behavior[] {
            DragDropBehavior.Create(typeof(DevExpress.XtraGrid.Extensions.ColumnViewDragDropSource), true, true, true, dragDropEvents1)});

            behaviorManager1.SetBehaviors(view, new Behavior[] {
            DragDropBehavior.Create(typeof(DevExpress.XtraGrid.Extensions.ColumnViewDragDropSource), true, true, false, dragDropEvents2)});
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            _RYMES_DB = _Main._RYMES_DB;

            lc_Conditions.Visible = false;
            btn_Conditions.Visible = false;

            SET_LookUpEdit_Data(le_TEMPLATE_ID, "TEMPLATE_MASTER");

            splitContainerControl1.SplitterPosition = (Height / 2) * 1;
            splitContainerControl1.PanelVisibility = SplitPanelVisibility.Both;

            Get_Data_Grid(gridControl, _Template_id);
            Get_Data_Grid1(gridControl1);

            (gridControl.MainView as ucGridView).PopupMenuShowing += gridView_PopupMenuShowing;
            (gridControl1.MainView as ucGridView).PopupMenuShowing += gridView_PopupMenuShowing;

            (gridControl.MainView as ucGridView).OptionsSelection.MultiSelect = true;
            (gridControl1.MainView as ucGridView).OptionsSelection.MultiSelect = true;
        }

        public void Get_Data_Grid(ucGridControl grid, string template_id)
        {
            ucGridView view = (grid.MainView as ucGridView);
            DataTable dt = new DataTable();

            _RYMES_DB._DB_Parameters.Add("@p_TEMPLATE_ID", template_id);

            string sMsg = _RYMES_DB.GET_DATA("QM_DG_CHK_TEMPLATE_LOAD", ref dt);

            grid.DataSource = dt;
            view.MemoEdit_Column("CHK_PROCESS_NAME");
            view.MemoEdit_Column("CHK_NAME");
            view.MemoEdit_Column("CRITERIA");
            view.MemoEdit_Column("INSPECTION_METHOD");
            view.MemoEdit_Column("INSPECTION_TYPE_RESULT");

            RestoreLayout(this, (grid.MainView as ucGridView));
        }

        public void Get_Data_Grid1(ucGridControl grid)
        {
            ucGridView view = (grid.MainView as ucGridView);
            DataTable dt = new DataTable();

            _RYMES_DB._DB_Parameters.Add("@p_FA_ID", _fa_id);
            string sMsg = _RYMES_DB.GET_DATA("QM_DG_CHK_TEMPLATE_ADD_LOAD", ref dt);
            if (string.IsNullOrEmpty(sMsg))
            {
                grid.DataSource = dt;
                view.MemoEdit_Column("CHK_PROCESS_NAME");
                view.MemoEdit_Column("CHK_NAME");
                view.MemoEdit_Column("CRITERIA");
                view.MemoEdit_Column("INSPECTION_METHOD");
                view.MemoEdit_Column("INSPECTION_TYPE_RESULT");
            }
            else
            {
                grid.DataSource = null;
            }

            RestoreLayout(this, (grid.MainView as ucGridView));
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
                if (grid == gridControl)
                {
                    le_TEMPLATE_ID.EditValue = null;
                    Get_Data_Grid(grid, _Template_id);
                }
                else if (grid == gridControl1)
                {
                    Get_Data_Grid1(grid);
                }
            };
            e.Menu.Items.Add(item);

            item = new DXMenuItem("Export", null, Properties.Resources.exporttoxlsx_16x16);
            item.Click += (o, args) =>
            {
                grid.Grid_Export();
            };
            e.Menu.Items.Add(item);

            if (e.MenuType == GridMenuType.Row && view.GridControl == gridControl)
            {
                item = new DXMenuItem("Delete", null, Properties.Resources.edit_16x16);
                item.Click += (o, args) =>
                {
                    view.DeleteSelectedRows();
                    ((DataTable)grid.DataSource).AcceptChanges();
                };
                e.Menu.Items.Add(item);
            }
        }

        private void dragDropEvents1_DragDrop(object sender, DragDropEventArgs e)
        {
            GridView targetGrid = e.Target as GridView is null ? (gridControl.MainView as ucGridView) : e.Target as GridView;
            GridView sourceGrid = e.Source as GridView;

            DataTable sourceTable = sourceGrid.GridControl.DataSource as DataTable;
            DataTable targetTable = targetGrid.GridControl.DataSource as DataTable;

            Point hitPoint = targetGrid.GridControl.PointToClient(e.Location);
            GridHitInfo hitInfo = targetGrid.CalcHitInfo(hitPoint);

            int[] sourceHandles = e.GetData<int[]>();

            int targetRowHandle = hitInfo.RowHandle;
            int targetRowIndex = targetGrid.GetDataSourceRowIndex(targetRowHandle);

            targetRowIndex = targetRowIndex < -1 ? targetTable.Rows.Count : targetRowIndex;

            List<DataRow> draggedRows = new List<DataRow>();

            foreach (int sourceHandle in sourceHandles)
            {
                int oldRowIndex = sourceGrid.GetDataSourceRowIndex(sourceHandle);
                DataRow oldRow = sourceTable.Rows[oldRowIndex];

                if (targetGrid != sourceGrid)
                {
                    int duplicatedRows = targetTable.AsEnumerable().Count(row => row.Field<Int64>("CHK_ID") == Convert.ToInt64(oldRow["CHK_ID"]));

                    if (duplicatedRows == 0)
                    {
                        draggedRows.Add(oldRow);
                    }
                }
                else
                {
                    draggedRows.Add(oldRow);
                }
            }

            int newRowIndex;

            switch (e.InsertType)
            {
                case InsertType.Before:
                    newRowIndex = targetRowIndex > sourceHandles[sourceHandles.Length - 1] ? targetRowIndex - 1 : targetRowIndex;
                    for (int i = draggedRows.Count - 1; i >= 0; i--)
                    {
                        DataRow oldRow = draggedRows[i];
                        DataRow newRow = targetTable.NewRow();
                        newRow.ItemArray = oldRow.ItemArray;

                        targetTable.Rows.InsertAt(newRow, targetRowIndex);

                        if (sourceGrid == targetGrid)
                        {
                            sourceTable.Rows.Remove(oldRow);
                        }
                    }
                    break;

                case InsertType.After:
                    for (int i = draggedRows.Count - 1; i >= 0; i--)
                    {
                        DataRow oldRow = draggedRows[i];
                        DataRow newRow = targetTable.NewRow();
                        newRow.ItemArray = oldRow.ItemArray;

                        targetTable.Rows.InsertAt(newRow, targetRowIndex + 1);

                        if (sourceGrid == targetGrid)
                        {
                            sourceTable.Rows.Remove(oldRow);
                        }
                    }
                    break;

                case InsertType.None:
                    for (int i = draggedRows.Count - 1; i >= 0; i--)
                    {
                        DataRow oldRow = draggedRows[i];
                        DataRow newRow = targetTable.NewRow();
                        newRow.ItemArray = oldRow.ItemArray;

                        targetTable.Rows.InsertAt(newRow, targetRowIndex);

                        if (sourceGrid == targetGrid)
                        {
                            sourceTable.Rows.Remove(oldRow);
                        }
                    }
                    break;
            }

            int insertedIndex = targetGrid.GetRowHandle(targetRowIndex);
            targetGrid.FocusedRowHandle = insertedIndex;
            targetGrid.ClearSelection();
            targetGrid.SelectRow(targetGrid.FocusedRowHandle);
            e.Action = DragDropActions.None;
        }

        private void dragDropEvents1_DragOver(object sender, DragOverEventArgs e)
        {
            DragOverGridEventArgs args = DragOverGridEventArgs.GetDragOverGridEventArgs(e);
            e.InsertType = args.InsertType;
            e.InsertIndicatorLocation = args.InsertIndicatorLocation;
            e.Action = args.Action;
            Cursor.Current = args.Cursor;
            args.Handled = true;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            DataTable dt = gridControl.DataSource as DataTable;
            DbTransaction transaction = _RYMES_DB._Connection.BeginTransaction();

            string sMsg = "";

            SplashScreenManager.ShowForm(_Main, typeof(frm_Wait), true, true, false);
            try
            {
                _RYMES_DB._DB_Parameters.Add("@p_TEMPLATE_ID", _Template_id);

                sMsg = _RYMES_DB.SET_DATA("QM_DG_CHK_TEMPLATE_DELETE", ref transaction);

                if (!string.IsNullOrEmpty(sMsg))
                {
                    MessageBox.Show(sMsg, "DB ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    _RYMES_DB._DB_Parameters.Add("@p_TEMPLATE_ID", _Template_id);
                    _RYMES_DB._DB_Parameters.Add("@p_CHK_ID", dt.Rows[i]["CHK_ID"].ToString());
                    _RYMES_DB._DB_Parameters.Add("@p_ORDERBY", i + 1);

                    sMsg = _RYMES_DB.SET_DATA("QM_DG_CHK_TEMPLATE_INSERT", ref transaction);

                    if (!string.IsNullOrEmpty(sMsg))
                    {
                        SplashScreenManager.CloseForm(false);
                        MessageBox.Show(sMsg, "DB ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                transaction.Commit();
                SplashScreenManager.CloseForm(false);
                MessageBox.Show("Save Success!!", "SAVE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                SplashScreenManager.CloseForm(false);
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frm_SizeChanged(object sender, EventArgs e)
        {
            splitContainerControl1.SplitterPosition = (Height / 2) * 1;
        }

        private void le_TEMPLATE_ID_EditValueChanged(object sender, EventArgs e)
        {
            if (le_TEMPLATE_ID.EditValue is null)
            {
                Get_Data_Grid(gridControl, _Template_id);
            }
            else
            {
                Get_Data_Grid(gridControl, le_TEMPLATE_ID.EditValue.ToString());
            }
        }

        private void btn_Item_Update_Click(object sender, EventArgs e)
        {
            if (le_TEMPLATE_ID.EditValue is null)
            {
                MessageBox.Show("변경할 품목들에 연결된 Template id를 선택하세요.");
            }

            if (MessageBox.Show("(" + le_TEMPLATE_ID.EditValue + ")" + le_TEMPLATE_ID.Text + "에 연결된 품목들의 체크시트, 성적서를 모두 " + (Text).Substring(11) + "으로 변경 하시겠습니까?"
                , "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                _RYMES_DB._DB_Parameters.Add("@p_TEMPLATE_ID", _Template_id);
                _RYMES_DB._DB_Parameters.Add("@p_OLD_TEMPLATE_ID", le_TEMPLATE_ID.EditValue);
                _RYMES_DB._DB_Parameters.Add("@p_CREATE_USER", _Main._User_Info["USER_CODE"].ToString());

                string sMsg = _RYMES_DB.SET_DATA("QM_DG_ITEM_TEMPLATE_UPDATE");

                if (string.IsNullOrEmpty(sMsg))
                {
                    MessageBox.Show("Save Success!!", "SAVE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(sMsg, "DB ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }
    }
}