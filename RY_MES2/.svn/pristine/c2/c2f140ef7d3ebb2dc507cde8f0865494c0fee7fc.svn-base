using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraSplashScreen;
using nsCommon;
using System;
using System.Data;
using System.Windows.Forms;

namespace RY_MES.Forms
{
    public partial class frm_Workers_PopUp : frm_Base
    {
        private bool changed = false;
        private DataTable table;
        private DataRow _Cell_Info;
        bool _isEQUIP = false;

        public frm_Workers_PopUp(frm_Main frm_Main, DataRow Cell_Info)
        {
            InitializeComponent();

            init_PopUp();

            _Main = frm_Main;
            _RYMES_DB = _Main._RYMES_DB;
            _Cell_Info = Cell_Info;
            
        }
        public frm_Workers_PopUp(frm_Main frm_Main, DataRow Cell_Info,bool isEQUIP)
        {
            InitializeComponent();

            init_PopUp();

            _Main = frm_Main;
            _RYMES_DB = _Main._RYMES_DB;
            _Cell_Info = Cell_Info;
            _isEQUIP = isEQUIP;
        }

        private void frm_Load(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(_Main, typeof(frm_Wait), true, true, false);
            try
            {
                SET_LookUpEdit_Data(sle_USER, "USER_MASTER_WORKER");
                Get_Data_Grid();
            }
            finally
            {
                //Close Wait Form
                SplashScreenManager.CloseForm(false);
                gridControl.Focus();
            }
        }

        private void Get_Data_Grid()
        {
            table = new DataTable();
            _RYMES_DB._DB_Parameters.Add("@p_CELL_CODE", _Cell_Info["CELL_CODE"]);
            string sMsg = _RYMES_DB.GET_DATA("WE_CELL_WORKERS_LOAD", ref table);
            if (string.IsNullOrEmpty(sMsg))
            {
                gridControl.DataSource = table;
                foreach (GridColumn item in (gridControl.MainView as ucGridView).Columns)
                {
                    item.OptionsColumn.AllowEdit = false;
                    item.OptionsColumn.ReadOnly = true;
                }

                if ((gridControl.MainView as ucGridView).Columns["제거"] is null)
                {
                    GridColumn col = (gridControl.MainView as ucGridView).Columns.AddVisible("제거", "");
                    col.UnboundType = DevExpress.Data.UnboundColumnType.Object;
                    RepositoryItemButtonEdit repButton = new RepositoryItemButtonEdit
                    {
                        Name = "rb1"
                    };
                    repButton.ButtonClick += repButton_Click;
                    repButton.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
                    repButton.Buttons[0].Kind = ButtonPredefines.Delete;

                    gridControl.RepositoryItems.Add(repButton);
                    col.ColumnEdit = repButton;
                    col.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
                }

                //Set_Description(gridView);
            }
            else
            {
                if (sMsg == "Result FirstTable Rows Count is Zero")
                {
                    gridControl.DataSource = table;
                }
                else
                {
                    MessageBox.Show(sMsg, "DB ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return;
            }

            (gridControl.MainView as ucGridView).BestFitColumns();

            RestoreLayout(this, (gridControl.MainView as ucGridView));
        }

        private void repButton_Click(object sender, ButtonPressedEventArgs e)
        {
            if (table.Rows.Count == 1 && _Cell_Info["TICKET_ID"].ToString() != "")
            {
                MessageBox.Show("실행중인 작업에서 작업자를 모두 지울수 없습니다.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            (gridControl.MainView as ucGridView).DeleteSelectedRows();
            table.AcceptChanges();
            changed = true;
        }

        private void gridControl_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                if (table.Rows.Count == 1 && _Cell_Info["TICKET_ID"].ToString() != "")
                {
                    MessageBox.Show("실행중인 작업에서 작업자를 모두 지울수 없습니다.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                (gridControl.MainView as ucGridView).DeleteSelectedRows();
                e.Handled = true;
                table.AcceptChanges();
                changed = true;
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (changed)
            {
                string USER_CODES = "";
                for (int i = 0; i < ucGridView1.RowCount; i++)
                {
                    USER_CODES += ucGridView1.GetRowCellValue(i, "USER_CODE").ToString() + ",";
                }



                _RYMES_DB._DB_Parameters.Add("@p_CELL_CODE", _Cell_Info["CELL_CODE"]);
                _RYMES_DB._DB_Parameters.Add("@p_USER_CODES", USER_CODES);
                _RYMES_DB._DB_Parameters.Add("@p_CREATE_USER", _Cell_Info["WORKER"].ToString() == "" ? _Main._User_Info["USER_CODE"].ToString() : _Cell_Info["WORKER"].ToString());

                string sSQL = "";
                if(_isEQUIP)
                {
                    sSQL = "WE_CELL_WORKERS_4CELL_UPDATE";
                }
                else
                {
                    sSQL = "WE_CELL_WORKERS_UPDATE";
                }

                string sMsg = _RYMES_DB.SET_DATA(sSQL);
                if (string.IsNullOrEmpty(sMsg))
                {
                    MessageBox.Show("Save Success", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(sMsg, "DB ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                DialogResult = DialogResult.OK;              
            }
            Close();
        }

        private void sle_USER_EditValueChanged(object sender, EventArgs e)
        {
            if (sle_USER.EditValue is null)
            {
                return;
            }

            foreach (DataRow row in table.Rows)
            {
                if (row["USER_CODE"].ToString() == sle_USER.EditValue.ToString())
                {
                    return;
                }
            }

            DataRow dr = table.NewRow();
            dr["USER_CODE"] = sle_USER.EditValue.ToString();
            dr["USER_NAME"] = sle_USER.Text;
            table.Rows.Add(dr);
            changed = true;
        }
    }
}