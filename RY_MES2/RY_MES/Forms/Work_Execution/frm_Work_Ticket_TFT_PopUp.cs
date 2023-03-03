using DevExpress.XtraSplashScreen;
using nsCommon;
using System;
using System.Data;
using System.Windows.Forms;

namespace RY_MES.Forms
{
    public partial class frm_Work_Ticket_TFT_PopUp : frm_Base
    {
       // private bool changed = false;
        private DataTable table;
        private DataRow _Cell_Info;

        public frm_Work_Ticket_TFT_PopUp(frm_Main frm_Main, DataRow Cell_Info)
        {
            InitializeComponent();

            init_PopUp();
            _Main = frm_Main;
            _RYMES_DB = _Main._RYMES_DB;
            _Cell_Info = Cell_Info;
        }

        private void frm_Load(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(_Main, typeof(frm_Wait), true, true, false);
            try
            {
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
                    return;
                }
                
            }

            //(gridControl.MainView as ucGridView).BestFitColumns();

            RestoreLayout(this, (gridControl.MainView as ucGridView));
            ucGridView1_FocusedRowChanged((gridControl.MainView as ucGridView), new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs(0, 0));
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

            if (string.IsNullOrEmpty(sle_Wafer.Text))
            {
                    MessageBox.Show("Pannel No를 입력해 주십시오.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
            }

            sle_Wafer.Text = sle_Wafer.Text.ToUpper();
            DataTable dt = new DataTable();

            _RYMES_DB._DB_Parameters.Add("@p_PANEL_NO", sle_Wafer.EditValue);
            _RYMES_DB._DB_Parameters.Add("@p_OP_ID", _Cell_Info["OP_ID"].ToString());

            //}
            string Msg = _RYMES_DB.GET_DATA("WE_PANEL_NO_CHK", ref dt);
            if (!string.IsNullOrEmpty(Msg))
            {
                
                MessageBox.Show(Msg, "DB ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
                
            }
            else
            {
                if (string.IsNullOrEmpty(dt.Rows[0]["WAFER_STATUS"].ToString()))
                {
                    if (!((ucGridView1.GetFocusedDataRow()["ITEM_TYPE"].ToString() == "TFT" && _Cell_Info["OP_ID"].ToString() == "CSI_MSK")
                        || (ucGridView1.GetFocusedDataRow()["ITEM_TYPE"].ToString() != "TFT" && _Cell_Info["OP_ID"].ToString() == "CSI_PLA")
                        //|| (ucGridView1.GetFocusedDataRow()["ITEM_TYPE"].ToString() == "Cutting" && _Cell_Info["OP_ID"].ToString() == "TFT_CUTTING")
                        //|| (ucGridView1.GetFocusedDataRow()["ITEM_TYPE"].ToString() != "Cutting" && _Cell_Info["OP_ID"].ToString() == "TFT_LAMI")
                        || (_Cell_Info["OP_ID"].ToString() == "TFT_LAMI")
                        || (_Cell_Info["OP_GROUP"].ToString() == "SW" && _Cell_Info["OP_ID"].ToString() == "TFT_SW_BUN_CD")
                        || (_Cell_Info["OP_GROUP"].ToString() == "REWORK")
                        || (_Cell_Info["OP_GROUP"].ToString() == "SUB")
                        ))
                    {

                        MessageBox.Show(sle_Wafer.Text + " : 신규 Pannel No 입니다.  다시 확인 바랍니다 ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                if (!string.IsNullOrEmpty(dt.Rows[0]["FLAG"].ToString()))
                {
                    if(DialogResult.Yes != MessageBox.Show("이미 작업한 Panel No  입니다. \n 작업 하시겠습니까?","중복작업",MessageBoxButtons.YesNo,MessageBoxIcon.Question))
                    {
                        return;
                    }
                    
                }
                if (dt.Rows[0]["WAFER_STATUS"].ToString() == "0003")
                {
                    MessageBox.Show(sle_Wafer.Text + " : 투입 중 인  Pannel No 입니다.  다시 확인 바랍니다 ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (dt.Rows[0]["WAFER_STATUS"].ToString() == "0004")
                {
                    MessageBox.Show(sle_Wafer.Text + " : 부적합 분석 중인 Pannel No 입니다.  다시 확인 바랍니다 ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (dt.Rows[0]["WAFER_STATUS"].ToString() == "0005")
                {
                    MessageBox.Show(sle_Wafer.Text + " : 완료된 Pannel No 입니다.  다시 확인 바랍니다 ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (dt.Rows[0]["WAFER_STATUS"].ToString() == "9999")
                {
                    MessageBox.Show(sle_Wafer.Text + " : 폐기 된 Pannel No 입니다.  다시 확인 바랍니다 ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

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

        private void ucGridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            ucGridView view = (ucGridView)sender;
            if (e.FocusedRowHandle >= 0 && !(view.GetFocusedDataRow() is null))
            {
                if (view.GetFocusedDataRow()["ITEM_TYPE"].ToString() == "SW")
                {
                    sle_Wafer.Enabled = false;
                    sle_Wafer.Text = view.GetFocusedDataRow()["TICKET_ID"].ToString();
                }
                else
                {
                    sle_Wafer.Enabled = true;
                    sle_Wafer.Text = "";
                }
            }
        }

    }
}