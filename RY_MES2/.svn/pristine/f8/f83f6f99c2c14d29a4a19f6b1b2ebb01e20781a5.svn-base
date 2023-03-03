using DevExpress.Utils;
using DevExpress.Utils.Menu;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Menu;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraSplashScreen;
using nsCommon;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace RY_MES.Forms
{
    public partial class frm_Check_Sheet_PopUp : frm_Base
    {

        private DataRow _Cell_Info;
        private string _WAFER_NO;

        public frm_Check_Sheet_PopUp(frm_Main frm_Main, DataRow Cell_Info,string WAFER_NO)
        {
            InitializeComponent();
            init_PopUp();
            _Main = frm_Main;
            _RYMES_DB = _Main._RYMES_DB;
            _Cell_Info = Cell_Info;
            _WAFER_NO = WAFER_NO;
            splitContainerControl1.PanelVisibility = SplitPanelVisibility.Panel1;
        }

        private void frm_Load(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(_Main, typeof(frm_Wait), true, true, false);
            try
            {
                Get_Data();
            }
            finally
            {
                //Close Wait Form
                SplashScreenManager.CloseForm(false);
                gridControl.Focus();
            }
        }

        private void Get_Data()
        {
            DataSet ds = new DataSet();
            _RYMES_DB._DB_Parameters.Add("@p_WO_ID", _Cell_Info["WO_ID"]);
            _RYMES_DB._DB_Parameters.Add("@p_OP_ID", _Cell_Info["OP_ID"]);
            _RYMES_DB._DB_Parameters.Add("@p_WAFER_NO", _WAFER_NO);
            _RYMES_DB._DB_Parameters.Add("@p_OP_TYPE", _Cell_Info["OP_TYPE"]);
            _RYMES_DB._DB_Parameters.Add("@p_CREATE_USER", _Cell_Info["WORKER"].ToString() == "" ? _Main._User_Info["USER_CODE"].ToString() : _Cell_Info["WORKER"].ToString());

            string sMsg = _RYMES_DB.GET_DATA("WE_CHECK_SHEET_LOAD", ref ds);
            if (string.IsNullOrEmpty(sMsg))
            {
                gridControl.DataSource = ds.Tables[0];
                ucGridControl1.DataSource = ds.Tables[1];
                //Set_Description((GridView)gridControl.MainView);

                foreach (GridColumn column in gridView.Columns)
                {
                    if (column.FieldName == "CHK_NAME" || column.FieldName == "CHK_PROCESS_NAME" || column.FieldName == "CRITERIA")
                    {
                        column.ColumnEdit = repositoryItemRichTextEdit1;
                    }
                    if (column.FieldName != "VALUE_RESULT_NAME")
                    {
                        column.OptionsColumn.ReadOnly = true;
                    }
                }
            }
            else
            {
                if (sMsg == "Result FirstTable Rows Count is Zero")
                {
                    gridControl.DataSource = ds.Tables[0];
                    ucGridControl1.DataSource = ds.Tables[1];
                    //Set_Description((GridView)gridControl.MainView);
                }
                else
                {
                    MessageBox.Show(sMsg, "DB ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return;
            }

            gridView.BestFitColumns();

            RestoreLayout(this, ucGridView1);
        }

        private void gridView_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            if (e.Column.FieldName == "VALUE_RESULT_NAME")
            {
                if (gridView.GetRowCellValue(e.RowHandle, "INSPECTION_TYPE").ToString() == "CHKECKBOX")
                {
                    e.RepositoryItem = repositoryItemCheckEdit1;
                    gridView.SetRowCellValue(e.RowHandle, e.Column.FieldName, e.CellValue.ToString().Equals("True") ? true : false);
                }
                else
                {
                    e.RepositoryItem = repositoryItemButtonEdit1;
                }
            }
        }

        private void gridView_ColumnWidthChanged(object sender, DevExpress.XtraGrid.Views.Base.ColumnEventArgs e)
        {
            GridView view = (GridView)sender;
            view.SetRowCellValue(0, e.Column, view.GetRowCellValue(0, e.Column));

            //SaveLayout(this, view);
        }

        private void gridView_ColumnPositionChanged(object sender, EventArgs e)
        {
            GridView view = (GridView)((GridColumn)sender).View;
            //SaveLayout(this, view);
        }

     
        private void repositoryItemButtonEdit1_Click(object sender, EventArgs e)
        {
            DataRow gridRow = gridView.GetFocusedDataRow();
            int focus = gridView.FocusedRowHandle;
            int topRowIndex = gridView.TopRowIndex;
            frm_Base frm_Base;
            switch (gridRow["INSPECTION_TYPE"].ToString())
            {
                case "IMAGE":
                    frm_Base = new frm_Check_Sheet_Input_P_PopUp(_Main, _Cell_Info, gridRow);
                    if (DialogResult.OK == frm_Base.ShowDialog())
                    {
                        Get_Data();
                    }
                    break;

                case "RADIO":
                    frm_Base = new frm_Check_Sheet_Input_B_PopUp(_Main, _Cell_Info, gridRow);
                    if (DialogResult.OK == frm_Base.ShowDialog())
                    {
                        Get_Data();
                    }
                    break;

                case "CHECK":
                    frm_Base = new frm_Check_Sheet_Input_B_PopUp(_Main, _Cell_Info, gridRow);
                    if (DialogResult.OK == frm_Base.ShowDialog())
                    {
                        Get_Data();
                    }
                    break;

                case "INT":
                    frm_Base = new frm_Check_Sheet_Input_T_PopUp(_Main, _Cell_Info, gridRow);
                    if (DialogResult.OK == frm_Base.ShowDialog())
                    {
                        Get_Data();
                    }
                    break;

                case "DOUBLE":
                    frm_Base = new frm_Check_Sheet_Input_T_PopUp(_Main, _Cell_Info, gridRow);
                    if (DialogResult.OK == frm_Base.ShowDialog())
                    {
                        Get_Data();
                    }
                    break;

                case "TEXT":
                default:
                    frm_Base = new frm_Check_Sheet_Input_T_PopUp(_Main, _Cell_Info, gridRow);
                    if (DialogResult.OK == frm_Base.ShowDialog())
                    {
                        Get_Data();
                    }
                    break;
            }
            if (focus < gridView.RowCount - 1)
            {
                gridView.FocusedRowHandle = focus + 1;
            }
            else
            {
                gridView.FocusedRowHandle = focus;
            }
            gridView.TopRowIndex = topRowIndex;
        }

        private void gridView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            e.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            if (string.IsNullOrEmpty(gridView.GetRowCellValue(e.RowHandle, "VALUE_RESULT").ToString()))
            {
                if (e.Column.FieldName == "VALUE_RESULT")
                {
                    e.Appearance.BackColor = Color.Red;
                }
            }
            else if (!string.IsNullOrEmpty(gridView.GetRowCellValue(e.RowHandle, "SPEC").ToString()))
            {
                bool spec_out = false;
                string spec = gridView.GetRowCellValue(e.RowHandle, "SPEC").ToString();
                string value = gridView.GetRowCellValue(e.RowHandle, "VALUE_RESULT").ToString();

                if (spec == "0")
                {
                    spec_out = gridView.GetRowCellValue(e.RowHandle, "VALUE_RESULT").ToString() == "0" ? false : true;
                }
                else if (spec.IndexOf(">") >= 0)
                {
                    spec_out = Convert.ToDecimal(value) > Convert.ToDecimal(spec.Replace(">", "")) ? false : true;
                }
                else if (spec.IndexOf("≥") >= 0)
                {
                    spec_out = Convert.ToDecimal(value) >= Convert.ToDecimal(spec.Replace("≥", "")) ? false : true;
                }
                else if (spec.IndexOf("≤") >= 0)
                {
                    spec_out = Convert.ToDecimal(value) <= Convert.ToDecimal(spec.Replace("≤", "")) ? false : true;
                }
                else if (spec.IndexOf("<") >= 0)
                {
                    spec_out = Convert.ToDecimal(value) < Convert.ToDecimal(spec.Replace("<", "")) ? false : true;
                }
                else if (spec.IndexOf("~") >= 0)
                {
                    string[] split = spec.Split('~');

                    spec_out = Convert.ToDecimal(split[0]) <= Convert.ToDecimal(value)
                                && Convert.ToDecimal(value) <= Convert.ToDecimal(split[1]) ? false : true;
                }

                if (e.Column.FieldName == "VALUE_RESULT" && spec_out)
                {
                    e.Appearance.BackColor = Color.Red;
                }
            }
        }

        private void repositoryItemCheckEdit1_CheckedChanged(object sender, EventArgs e)
        {
            CheckEdit checkEdit = sender as CheckEdit;

            DataRow row = gridView.GetDataRow(gridView.FocusedRowHandle);

            string value = checkEdit.Checked.ToString();
            _RYMES_DB._DB_Parameters.Add("@p_VALUE_ID", row["VALUE_ID"]);
            _RYMES_DB._DB_Parameters.Add("@p_VALUE_RESULT", value);
            _RYMES_DB._DB_Parameters.Add("@p_VALUE_RESULT_NAME", value);
            _RYMES_DB._DB_Parameters.Add("@p_CREATE_USER", _Cell_Info["WORKER"].ToString() == "" ? _Main._User_Info["USER_CODE"].ToString() : _Cell_Info["WORKER"].ToString());

            string sMsg = _RYMES_DB.SET_DATA("WE_CHECK_SHEET_MERGE");
            if (string.IsNullOrEmpty(sMsg))
            {
                //MessageBox.Show("Save Success", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(sMsg, "DB ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Get_Data();
        }

        private void gridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "VALUE_RESULT_NAME" && (bool)e.Value)
            {
                gridView.SetRowCellValue(e.RowHandle, "VALUE_RESULT_NAME", false);
            }
            //if (e.Column.FieldName == "VALUE_RESULT_NAME" && (bool)e.Value)
            //    gridView.SetRowCellValue(e.RowHandle, "VALUE_RESULT_NAME", false);
        }

        private void gridView_MouseDown(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            GridHitInfo hitInfo = view.CalcHitInfo(e.Location);
            if (!hitInfo.InRowCell || hitInfo.Column.FieldName != "VALUE_RESULT_NAME")//!(hitInfo.Column.RealColumnEdit is RepositoryItemCheckEdit))
            {
                return;
            }

            view.FocusedColumn = hitInfo.Column;
            view.FocusedRowHandle = hitInfo.RowHandle;
            view.ShowEditor();
            CheckEdit edit = view.ActiveEditor as CheckEdit;
            if (edit == null)
            {
                return;
            }

            edit.Toggle();
            view.CloseEditor(); // call this method if you want to keep the view scrollable using the mouse wheel
            DXMouseEventArgs.GetMouseArgs(e).Handled = true;
        }

        private void repositoryItemButtonEdit1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)32)
            {
                repositoryItemButtonEdit1_Click(sender, null);
            }
        }

        private void gridView_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if ( string.IsNullOrEmpty(_WAFER_NO))
            {
                return;
            }
            GridView view = sender as GridView;
            ucGridControl grid = view.GridControl as ucGridControl;

            DXMenuItem item;

            if (e.Menu == null)
            {
                e.Menu = new GridViewMenu(view);
            }

            item = new DXMenuItem("이력보기", null, Properties.Resources.play_16x16);
            item.Click += (o, args) =>
            {
                splitContainerControl1.PanelVisibility =  SplitPanelVisibility.Both;
            };
            e.Menu.Items.Add(item);
        }
    }
}