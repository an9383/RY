using DevExpress.XtraSplashScreen;
using nsCommon;
using System;
using System.Data;
using System.Windows.Forms;

namespace RY_MES.Forms
{
    public partial class frm_Work_Ticket_4CELL_PopUp : frm_Base
    {
       // private bool changed = false;
        private DataTable table;
        private DataRow _Cell_Info;
        private DataTable dt;

        public frm_Work_Ticket_4CELL_PopUp(frm_Main frm_Main, DataRow Cell_Info)
        {
            InitializeComponent();

            init_PopUp();
            _Main = frm_Main;
            _RYMES_DB = _Main._RYMES_DB;
            _Cell_Info = Cell_Info;

            dt = new DataTable();

            dt.Columns.Add("PANEL_No");
            ucGridControl1.DataSource = dt;

            DataRow dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);

            ucGridView2.Columns[0].OptionsColumn.AllowEdit = true;
            ucGridView2.Columns[0].OptionsColumn.ReadOnly = false;
            ucGridView2.Columns[0].Width = 200;
        }

        private void frm_Load(object sender, EventArgs e)
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
                gridControl.Focus();
            }
        }

        private void Get_Data_Grid()
        {
            table = new DataTable();
            _RYMES_DB._DB_Parameters.Add("@p_FA_ID", _Cell_Info["FA_ID"]);
            _RYMES_DB._DB_Parameters.Add("@p_OP_ID", _Cell_Info["OP_ID"]);
            string sMsg = _RYMES_DB.GET_DATA("WE_TICKET_4CELL_LOAD", ref table);
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

            //(gridControl.MainView as ucGridView).BestFitColumns();

            RestoreLayout(this, (gridControl.MainView as ucGridView));
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
         

            string panels = "";
            int cnt = 0;
            if ((gridControl.MainView as ucGridView).FocusedRowHandle < 0)
            {
                MessageBox.Show("작업지시를 선택해 주십시오", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (ucGridView1.GetFocusedDataRow()["ITEM_TYPE"].ToString() == "TFT")
            {
        
       
                foreach (DataRow dr in dt.Rows)
                {
                   
                    if (dr[0].ToString().Trim().Length > 0)
                    {
                        panels += dr[0].ToString().Trim().ToUpper() + ",";
                        
                        cnt++;
                    }
                }
                if (panels == "")
                {
                    MessageBox.Show("Panel을 입력해 주십시오", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                textEdit1.Text = cnt.ToString();
            }
            else
            {
                if (string.IsNullOrEmpty(textEdit2.Text.ToUpper()))
                {
                    MessageBox.Show("LOT번호를 입력해 주십시오", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if(!CHK_PANEL(textEdit2.Text))
                {
                    return;
                }

                if (textEdit1.Text == "0" || string.IsNullOrEmpty(textEdit1.Text))
                {
                    MessageBox.Show("투입수량을 입력해 주십시오", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                panels = textEdit2.Text.ToUpper();
                cnt = Convert.ToInt32(textEdit1.Text);
            }
            
            //        if(cnt + Convert.ToInt32(ucGridView1.GetFocusedDataRow()["IN_QTY"]) > Convert.ToInt32(ucGridView1.GetFocusedDataRow()["PLAN_QTY"]) || _Cell_Info["OP_ID"] != "CSI_PA1")
            //{
            //    MessageBox.Show("계획수량을 초과합니다.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}


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
            _RYMES_DB._DB_Parameters.Add("@p_PANELS", panels);
            _RYMES_DB._DB_Parameters.Add("@p_IN_QTY", cnt);
            _RYMES_DB._DB_Parameters.Add("@p_ITEM_TYPE", ucGridView1.GetFocusedDataRow()["ITEM_TYPE"].ToString());
            _RYMES_DB._DB_Parameters.Add("@p_CREATE_USER", _Cell_Info["WORKER"].ToString() == "" ? _Main._User_Info["USER_CODE"].ToString() : _Cell_Info["WORKER"].ToString());

            //}
            string sMsg = _RYMES_DB.SET_DATA("WE_ORDER_REGISTRATION");
            if (string.IsNullOrEmpty(sMsg))
            {
                MessageBox.Show("Save Success", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(sMsg, "DB ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //DialogResult = DialogResult.OK;
            Close();
        }
        private void textEdit2_Leave(object sender, EventArgs e)
        {
            //CHK_PANEL(textEdit2.Text, false);
        }

        private void textEdit2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                CHK_PANEL(textEdit2.Text);
            }
        }

        private bool CHK_PANEL(string text)
        {
            text = text.ToUpper();
            DataTable dt = new DataTable();
            _RYMES_DB._DB_Parameters.Add("@p_PANEL_NO", text);
            _RYMES_DB._DB_Parameters.Add("@p_OP_ID", _Cell_Info["OP_ID"].ToString());


            //}
            string Msg = _RYMES_DB.GET_DATA("WE_PANEL_NO_CHK", ref dt);
            if (string.IsNullOrEmpty(Msg))
            {
                string QTY = textEdit1.Text;
                textEdit1.EditValue = dt.Rows[0]["LOT_QTY"];
                textEdit1.Enabled = false;

                if (string.IsNullOrEmpty(dt.Rows[0]["WAFER_STATUS"].ToString()))
                {
                    
                    if (!((ucGridView1.GetFocusedDataRow()["ITEM_TYPE"].ToString() == "TFT" && _Cell_Info["OP_ID"].ToString() == "CSI_MSK")
                    || ucGridView1.GetFocusedDataRow()["ITEM_TYPE"].ToString() != "TFT" && _Cell_Info["OP_ID"].ToString() == "CSI_PLA")
                     || (_Cell_Info["OP_GROUP"].ToString() == "REWORK"))
                    {
                        MessageBox.Show(text + " : 신규 Pannel No 입니다.  다시 확인 바랍니다 ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    
                    else
                    {
                        textEdit1.Text = QTY;
                        textEdit1.Enabled = true;
                    }
                }

                if (!string.IsNullOrEmpty(dt.Rows[0]["FLAG"].ToString()))
                {
                    if (DialogResult.Yes != MessageBox.Show("이미 작업한 Panel No  입니다. \n 작업 하시겠습니까?", "중복작업", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        return false; 
                    }

                }
                if (dt.Rows[0]["WAFER_STATUS"].ToString() == "0003")
                {
                    MessageBox.Show(text + " : 투입 중 인  Pannel No 입니다.  다시 확인 바랍니다 ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (dt.Rows[0]["WAFER_STATUS"].ToString() == "0004")
                {
                    MessageBox.Show(text + " : 부적합 분석 중인 Pannel No 입니다.  다시 확인 바랍니다 ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (dt.Rows[0]["WAFER_STATUS"].ToString() == "0005")
                {
                    MessageBox.Show(text + " : 완료된 Pannel No 입니다.  다시 확인 바랍니다 ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (dt.Rows[0]["WAFER_STATUS"].ToString() == "9999")
                {
                    MessageBox.Show(text + " : 폐기 된 Pannel No 입니다.  다시 확인 바랍니다 ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                
                    MessageBox.Show(Msg, "DB ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                
            }
            return true;
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
            if(e.FocusedRowHandle >= 0)
            {
                if(view.GetFocusedDataRow()["ITEM_TYPE"].ToString() == "TFT")
                {
                    groupControl1.Enabled = false;
                    groupControl2.Enabled = true;
                }
                else
                {
                    groupControl1.Enabled = true;
                    groupControl2.Enabled = false;
                }
            }
        }

        private void ucGridControl1_EditorKeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                int frh = ucGridView2.FocusedRowHandle;
                if (e.KeyChar == (char)22)
                {
                    string[] cs = Clipboard.GetText().Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                   
                    for (int i = 1; i < cs.Length; i++)
                    {
                        if (!string.IsNullOrEmpty(cs[i]))
                        {
                            if (!CHK_PANEL(cs[i]))
                            {
                                return;
                            }
                            DataRow dr = dt.NewRow();
                            dr[0] = cs[i].ToUpper();
                            dt.Rows.InsertAt(dr, frh + i + 1);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ucGridView2_KeyDown(object sender, KeyEventArgs e)
        {
            ucGridView view = (ucGridView)sender;
            int frh = view.FocusedRowHandle;
            if (e.KeyCode == Keys.Delete && frh >= 0)
            {
                if (dt.Rows.Count != 1)
                {
                    dt.Rows.RemoveAt(frh);
                }
                else
                {
                    dt.Rows[0][0] = "";
                }
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if(string.IsNullOrEmpty(view.EditingValue.ToString()))
                {
                    return;
                }
                if (view.IsEditorFocused)
                {
                    if (!CHK_PANEL(view.EditingValue.ToString().ToUpper()))
                    {
                        view.EditingValue = "";
                        return;
                    }
                    else
                    {
                        view.EditingValue = view.EditingValue.ToString().ToUpper();
                    }
                }
                frh = frh < -1 ? -1 : frh;
                DataRow dr = dt.NewRow();
                dt.Rows.InsertAt(dr, frh + 1);
                view.FocusedRowHandle = frh + 1;
            }
        }

       
    }
}