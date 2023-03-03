using DevExpress.XtraSplashScreen;
using nsCommon;
using System;
using System.Data;
using System.Windows.Forms;

namespace RY_MES.Forms
{
    public partial class frm_Work_Ticket_PopUp : frm_Base
    {
       // private bool changed = false;
        private DataTable table;
        private DataRow _Cell_Info;

        public frm_Work_Ticket_PopUp(frm_Main frm_Main, DataRow Cell_Info)
        {
            InitializeComponent();

            init_PopUp();
            _Main = frm_Main;
            _RYMES_DB = _Main._RYMES_DB;
            _Cell_Info = Cell_Info;

            //if(Cell_Info["OP_ID"].ToString() == "QC")
            //{
            //    ucGridView1.Layout -= ucGridView1.gridView_Layout;
            //    gridControl.DataSourceChanged -= gridControl.ucGridContral_DataSourceChanged;
            //}
        }

        private void frm_Load(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(_Main, typeof(frm_Wait), true, true, false);
            try
            {
                SET_LookUpEdit_Data(sle_Wafer, _Cell_Info["OP_TYPE"].ToString() == "0001"  ? "LOT_WAFER" : "WAFER_LIST", _Cell_Info["OP_ID"].ToString());

                sle_Wafer.EditValue = null;
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
            _RYMES_DB._DB_Parameters.Add("@p_FA_ID", _Cell_Info["FA_ID"]);
            _RYMES_DB._DB_Parameters.Add("@p_OP_ID", _Cell_Info["OP_ID"]);
            string sMsg = _RYMES_DB.GET_DATA("WE_TICKET_LOAD", ref table);
            if (string.IsNullOrEmpty(sMsg))
            {
                gridControl.DataSource = table;
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

            RestoreLayout(this, (gridControl.MainView as ucGridView));

            //(gridControl.MainView as ucGridView).BestFitColumns();
            //if (_Cell_Info["OP_ID"].ToString() != "QC")
            //{
            //    RestoreLayout(this, (gridControl.MainView as ucGridView));
            //}
            //else
            //{

            //    ucGridView1.BestFitColumns();
            //}
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            //if (_Cell_Info["OP_ID"].ToString() == "QC")
            //{
            //    if (DialogResult.OK == MessageBox.Show("다음 작업을 시작 합니다" + "\n" +
            //                                           "PO : " + (gridControl.MainView as ucGridView).GetFocusedRowCellValue("PO") + "\n" +
            //                                           "WAFER : " + sle_Wafer.Text
            //                                            , "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning))
            //    {

            //    }
            //    else
            //    {
            //        return;
            //    }
            //}

            if ((gridControl.MainView as ucGridView).FocusedRowHandle < 0)
            {
                MessageBox.Show("작업지시를 선택해 주십시오", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //(gridControl.MainView as ucGridView)
            if ((gridControl.MainView as ucGridView).GetFocusedRowCellValue("WO_STATUS").ToString() == "0001")
            {
                if (sle_Wafer.EditValue is null)
                {
                    MessageBox.Show("Lot을 선택해 주십시오", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if ((gridControl.MainView as ucGridView).GetFocusedRowCellValue("WO_STATUS").ToString() != "0001")
            {
                if (!(sle_Wafer.EditValue is null))
                {
                    MessageBox.Show("이미 시작된 작업은 LOT 변경이 불가 합니다", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    sle_Wafer.EditValue = null;
                    return;
                }
            }

            if ((_Cell_Info["OP_TYPE"].ToString() == "0001"))
            {
                int qty = int.Parse(sle_Wafer.Text.Split('[')[1].Replace("]", ""));
                int plan = int.Parse((gridControl.MainView as ucGridView).GetFocusedRowCellValue("PLAN_QTY").ToString());
                if (plan < qty)
                {
                    MessageBox.Show("Lot수량이 계획수량보다 큽니다", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            //if ((gridControl.MainView as ucGridView).GetFocusedRowCellValue("WO_STATUS").ToString() == "0004")
            //{
            //    if (DialogResult.Yes == MessageBox.Show("공정내 재작업 작업지시를 생성 하시겠습니까?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            //    {
            //        _RYMES_DB._DB_Parameters.Add("@p_WO_ID", (gridControl.MainView as ucGridView).GetFocusedRowCellValue("WO_ID"));
            //        _RYMES_DB._DB_Parameters.Add("@p_CELL_CODE", _Cell_Info["CELL_CODE"]);
            //        _RYMES_DB._DB_Parameters.Add("@p_CREATE_USER", _Cell_Info["WORKER"].ToString() == "" ? _Main._User_Info["USER_CODE"].ToString() : _Cell_Info["WORKER"].ToString());

            //        sSQL = "WE_RE_ORDER_START";
            //    }
            //    else
            //    {
            //        return;
            //    }
            //}
            //else
            //{
            _RYMES_DB._DB_Parameters.Add("@p_FA_ID", _Cell_Info["FA_ID"]);
            _RYMES_DB._DB_Parameters.Add("@p_OP_ID", _Cell_Info["OP_ID"]);
            _RYMES_DB._DB_Parameters.Add("@p_CELL_CODE", _Cell_Info["CELL_CODE"]);
            _RYMES_DB._DB_Parameters.Add("@p_TICKET_ID", (gridControl.MainView as ucGridView).GetFocusedRowCellValue("TICKET_ID"));
            _RYMES_DB._DB_Parameters.Add("@p_WO_ID", (gridControl.MainView as ucGridView).GetFocusedRowCellValue("WO_ID"));
            _RYMES_DB._DB_Parameters.Add("@p_WO_STATUS", (gridControl.MainView as ucGridView).GetFocusedRowCellValue("WO_STATUS"));
            _RYMES_DB._DB_Parameters.Add("@p_LOT", sle_Wafer.EditValue);
            _RYMES_DB._DB_Parameters.Add("@p_CREATE_USER", _Cell_Info["WORKER"].ToString() == "" ? _Main._User_Info["USER_CODE"].ToString() : _Cell_Info["WORKER"].ToString());

            //}
            string sMsg = _RYMES_DB.SET_DATA("WE_ORDER_START");
            if (string.IsNullOrEmpty(sMsg))
            {
                MessageBox.Show("Save Success", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(sMsg, "DB ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void ucGridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "PLAN_QTY")
            {
                e.Appearance.BackColor = System.Drawing.Color.Lime;
            }
        }
    }
}