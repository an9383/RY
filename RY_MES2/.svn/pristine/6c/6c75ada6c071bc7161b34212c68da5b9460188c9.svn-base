using DevExpress.Utils.Menu;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using nsCommon;
using System;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Windows.Forms;

namespace RY_MES.Forms
{
    public partial class frm_Ticket_Popup : RY_MES.frm_Base
    {
        private DataTable _dt;
        private DataTable dt_TICKET_TYPE;

        public frm_Ticket_Popup(params object[] paramArray)
        {
            TopLevel = true;
            InitializeComponent();

            _dt = paramArray[0] as DataTable;

            ucGridView1.CellValueChanged += GridView_CellValueChanged;

            ucGridView1.OptionsSelection.MultiSelect = true;
            ucGridView1.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CellSelect;

            //ucGridView1.OptionsFind.AlwaysVisible = false;
            //ucGridView1.OptionsView.ShowGroupPanel = false;
            //ucGridView1.OptionsCustomization.AllowFilter = false;
            //ucGridView1.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
            ucGridView1.OptionsCustomization.AllowSort = false;
            ucGridView1.OptionsCustomization.AllowFilter = false;
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            _RYMES_DB = _Main._RYMES_DB;

            pnl_Conditions.Visible = false;
            btn_Conditions.Visible = false;

            dt_ORDER_DATE.EditValue = Convert.ToDateTime(_dt.Rows[0]["U_STADATE"]).ToString("yyyy-MM-dd");

            DataColumn col1 = new DataColumn
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "TICKET_TYPE",
                Caption = "작업구분",
                DefaultValue = "0001"
            };

            _dt.Columns.Add(col1);

            DataColumn col2 = new DataColumn
            {
                DataType = System.Type.GetType("System.Int32"),
                ColumnName = "ORDER_QTY",
                Caption = "지시수량",
                DefaultValue = "0"
            };

            _dt.Columns.Add(col2);

            foreach (DataRow row in _dt.Rows)
            {
                row["ORDER_QTY"] = Convert.ToInt32(row["PLANNEDQTY"].ToString()) - Convert.ToInt32(row["MES_QTY"].ToString());
            }

            gridControl.DataSource = _dt;
            ucGridView view = (gridControl.MainView as ucGridView);
            view.MemoEdit_Column("ITEM_NAME");
            view.MemoEdit_Column("COMMENTS");

            view.Columns["STATUS_NAME"].Caption = "상태";
            view.Columns["TYPE_NAME"].Caption = "타입";
            view.Columns["MES_QTY"].Caption = "작업수량";

            view.Columns["STATUS_NAME"].Visible = false;
            view.Columns["TYPE_NAME"].Visible = false;

            view.Columns["ORDER_QTY"].OptionsColumn.AllowEdit = true;
            view.Columns["ORDER_QTY"].OptionsColumn.ReadOnly = false;
            view.Columns["ORDER_QTY"].OptionsColumn.ShowInExpressionEditor = true;

            view.Columns["ORDER_QTY"].AppearanceCell.BackColor = Color.Salmon;



            RepositoryItemLookUpEdit repo_TICKET_TYPE = new RepositoryItemLookUpEdit();

            _RYMES_DB._DB_Parameters.Add("@p_GROUP_CODE", "TICKET_TYPE");
            string sMsg = _RYMES_DB.GET_DATA("SYS_CODE_LOAD", ref dt_TICKET_TYPE);

            if (string.IsNullOrEmpty(sMsg))
            {
                repo_TICKET_TYPE.DataSource = dt_TICKET_TYPE;
                repo_TICKET_TYPE.ValueMember = dt_TICKET_TYPE.Columns[0].ColumnName;
                repo_TICKET_TYPE.DisplayMember = dt_TICKET_TYPE.Columns[1].ColumnName;
            }

            gridControl.RepositoryItems.Add(repo_TICKET_TYPE);

            view.Columns["TICKET_TYPE"].ColumnEdit = repo_TICKET_TYPE;
            view.Columns["TICKET_TYPE"].OptionsColumn.AllowEdit = true;
            view.Columns["TICKET_TYPE"].OptionsColumn.ReadOnly = false;
            view.Columns["TICKET_TYPE"].OptionsColumn.ShowInExpressionEditor = true;


            view.BestFitColumns();
        }

        private void GridView_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (e.Value == null)
            {
                return;
            }

            GridView view = sender as GridView;

            if (view.FocusedColumn.FieldName == "ORDER_QTY")
            {
                int paln_qty = Convert.ToInt32(view.GetFocusedDataRow()["PLANNEDQTY"].ToString());
                int mes_qty = Convert.ToInt16(view.GetFocusedDataRow()["MES_QTY"].ToString());

                if (int.TryParse(view.GetFocusedDataRow()["ORDER_QTY"].ToString(), out int order_qty))
                {
                    if (order_qty > paln_qty - mes_qty || order_qty <= 0)
                    {
                        view.SetRowCellValue(view.FocusedRowHandle, "ORDER_QTY", paln_qty - mes_qty);
                        MessageBox.Show("작업 가능한 지시수량을 입력해주세요.");
                        return;
                    }
                }
                else
                {
                    view.SetRowCellValue(view.FocusedRowHandle, "ORDER_QTY", paln_qty - mes_qty);
                }
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(_Main, typeof(frm_Wait), true, true, false);

            DbTransaction trans = _RYMES_DB._Connection.BeginTransaction();
            GridView view = (gridControl.MainView as ucGridView);

            string sMsg = "";

            for (int i = 0; i < view.RowCount; i++)
            {
                if (view.GetRowCellValue(i, "FA_ID").ToString() == "TFT")
                {
                    for (int j = 0; j < Convert.ToInt32(view.GetRowCellValue(i, "ORDER_QTY")); j++)
                    {
                        _RYMES_DB._DB_Parameters.Add("@p_ORDER_NO", view.GetRowCellValue(i, "DOCENTRY"));
                        _RYMES_DB._DB_Parameters.Add("@p_ORDER_TYPE", view.GetRowCellValue(i, "TYPE"));
                        _RYMES_DB._DB_Parameters.Add("@p_ITEM_CODE", view.GetRowCellValue(i, "ITEMCODE"));
                        _RYMES_DB._DB_Parameters.Add("@p_COUNTRY", view.GetRowCellValue(i, "U_CNTRY"));
                        _RYMES_DB._DB_Parameters.Add("@p_PLAN_QTY", 1);
                        _RYMES_DB._DB_Parameters.Add("@p_TICKET_TYPE", view.GetRowCellValue(i, "TICKET_TYPE"));
                        _RYMES_DB._DB_Parameters.Add("@p_FA_ID", view.GetRowCellValue(i, "FA_ID"));
                        _RYMES_DB._DB_Parameters.Add("@p_TICKET_DESC", me_TICKET_DESC.Text);
                        _RYMES_DB._DB_Parameters.Add("@p_ORDER_DATE", dt_ORDER_DATE.EditValue);
                        _RYMES_DB._DB_Parameters.Add("@p_CREATE_USER", _Main._User_Info["USER_CODE"].ToString());

                        sMsg = _RYMES_DB.SET_DATA("WO_MASTER_INSERT", ref trans);
                        if (!string.IsNullOrEmpty(sMsg))
                        {
                            break;
                        }
                    }
                }
                else
                {
                    _RYMES_DB._DB_Parameters.Add("@p_ORDER_NO", view.GetRowCellValue(i, "DOCENTRY"));
                    _RYMES_DB._DB_Parameters.Add("@p_ORDER_TYPE", view.GetRowCellValue(i, "TYPE"));
                    _RYMES_DB._DB_Parameters.Add("@p_ITEM_CODE", view.GetRowCellValue(i, "ITEMCODE"));
                    _RYMES_DB._DB_Parameters.Add("@p_COUNTRY", view.GetRowCellValue(i, "U_CNTRY"));
                    _RYMES_DB._DB_Parameters.Add("@p_PLAN_QTY", view.GetRowCellValue(i, "ORDER_QTY"));
                    _RYMES_DB._DB_Parameters.Add("@p_TICKET_TYPE", view.GetRowCellValue(i, "TICKET_TYPE"));
                    _RYMES_DB._DB_Parameters.Add("@p_FA_ID", view.GetRowCellValue(i, "FA_ID"));
                    _RYMES_DB._DB_Parameters.Add("@p_TICKET_DESC", me_TICKET_DESC.Text);
                    _RYMES_DB._DB_Parameters.Add("@p_ORDER_DATE", dt_ORDER_DATE.EditValue);
                    _RYMES_DB._DB_Parameters.Add("@p_CREATE_USER", _Main._User_Info["USER_CODE"].ToString());

                    sMsg = _RYMES_DB.SET_DATA("WO_MASTER_INSERT", ref trans);
                    if (!string.IsNullOrEmpty(sMsg))
                    {
                        break;
                    }
                }                
            }
            SplashScreenManager.CloseForm(false);

            if (string.IsNullOrEmpty(sMsg))
            {
                trans.Commit();

                MessageBox.Show("Save Success", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
                Dispose();
            }
            else
            {
                MessageBox.Show(sMsg, "DB ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dt_ORDER_DATE_Enter(object sender, EventArgs e)
        {
            DateEdit edit = sender as DateEdit;

            BeginInvoke(new MethodInvoker(() =>
            {
                edit.SelectionStart = 8;
                edit.SelectionLength = 2;
            }));            
        }

        private void ucGridView1_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            ucGridView view = sender as ucGridView;

            if (e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Row)
            {
                if (e.HitInfo.RowHandle > -1 && e.HitInfo.Column.Name == "colTICKET_TYPE")
                {
                    foreach (DataRow dr in dt_TICKET_TYPE.Rows)
                    {
                        DXMenuItem item = new DXMenuItem(dr["코드명"].ToString());
                        item.Click += (o, args) => {

                            foreach (int rowHandle in view.GetSelectedRows())
                            {
                                view.SetRowCellValue(rowHandle, view.VisibleColumns[e.HitInfo.Column.VisibleIndex], dr["코드"].ToString());
                            }
                        };
                        e.Menu.Items.Add(item);

                    }


                }
            }
        }
    }
}