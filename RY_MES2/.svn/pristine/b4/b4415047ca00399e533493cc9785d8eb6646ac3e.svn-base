using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using DevExpress.XtraTab;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace RY_MES.Forms
{
    public partial class frm_Cell : frm_Base
    {
        private DataRow _Cell_Info;
        private DataRow _Ticket_Info;
        private frm_Work_Execution _frm_Work;
        private ucGridView view;
        private DataTable dt_wafer;
        

        /// <summary>
        /// DashBoard 생성자
        /// </summary>
        /// <param name="Main"></param>
        public frm_Cell(frm_Main Main, frm_Work_Execution frm_Work)
        {
            InitializeComponent();
            _Main = Main;
            _RYMES_DB = Main._RYMES_DB;
            _frm_Work = frm_Work;

            view = (ucGridControl1.MainView as ucGridView);

            Set_Description(layoutControl1);
            Set_Description(layoutControl2);
        }

        private void frm_Cell_Load(object sender, EventArgs e)
        {
            pnl_Conditions.Visible = false;
            btn_Conditions.Visible = false;

            view.FocusRectStyle = DrawFocusRectStyle.CellFocus;
            view.OptionsView.ShowGroupPanel = false;
            view.OptionsFind.AlwaysVisible = false;

            view.OptionsCustomization.AllowFilter = false;

            Get_Data();
        }

        public void Get_Data()
        {
            DataTable table = new DataTable();
            bool isFIRST = false;

            _RYMES_DB._DB_Parameters.Add("@p_CELL_CODE", Text);
            string sMsg = _RYMES_DB.GET_DATA("WE_CELL_INFO_LOAD", ref table);
            if (string.IsNullOrEmpty(sMsg))
            {
                _Cell_Info = table.Rows[0];

                labelControl1.Text = _Cell_Info["CELL_NAME"].ToString();

                lbl_Status.Text = _Cell_Info["CELL_STATE_NAME"].ToString();
                lbl_FA_NAME.Text = _Cell_Info["FA_NAME"].ToString();
                lbl_OP_NAME.Text = _Cell_Info["OP_NAME"].ToString();
                lbl_CELL_CODE.Text = _Cell_Info["CELL_CODE"].ToString();
                btn_TICKET_ID.Text = _Cell_Info["TICKET_ID"].ToString();
                txt_WO_ID.Text = _Cell_Info["WO_ID"].ToString();
                btn_WORKS.Text = _Cell_Info["WORKS"].ToString();

                layoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutControlItem13.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

                if (!string.IsNullOrEmpty(btn_TICKET_ID.Text))
                {
                    DataTable dt_WT = new DataTable();

                    _RYMES_DB._DB_Parameters.Add("@p_TICKET_ID", btn_TICKET_ID.Text);
                    string sMsg_WT = _RYMES_DB.GET_DATA("WE_TICKET_INFO_LOAD", ref dt_WT);
                    if (string.IsNullOrEmpty(sMsg_WT))
                    {
                        _Ticket_Info = dt_WT.Rows[0];

                        txt_ORDER_NO.Text = _Ticket_Info["ORDER_NO"].ToString();
                        txt_ORDER_DATE.Text = ((DateTime)_Ticket_Info["ORDER_DATE"]).ToShortDateString();
                        txt_ITEM_CODE.Text = _Ticket_Info["ITEM_CODE"].ToString();
                        txt_ITEM_NAME.Text = _Ticket_Info["ITEM_NAME"].ToString();
                        txt_PLAN_QTY.Text = _Cell_Info["PLAN_QTY"].ToString();
                        txt_COMP_QTY.Text = _Cell_Info["COMP_QTY"].ToString();
                        txt_DEFECT_QTY.Text = _Cell_Info["DEFECT_QTY"].ToString();

                        txt_LOT_QTY.Text = "0";
                        txt_TICKET_DESC.Text = _Ticket_Info["TICKET_DESC"].ToString();

                        isFIRST = _Ticket_Info["FIRST_OP"].ToString() == _Cell_Info["OP_ID"].ToString();

                        if (_Cell_Info["OP_TYPE"].ToString() == "0004")
                        {
                            layoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        }

                        if (!string.IsNullOrEmpty(_Cell_Info["WO_ID"].ToString()))
                        {
                            DataSet ds_HIS = new DataSet();

                            _RYMES_DB._DB_Parameters.Add("@p_WO_ID", _Cell_Info["WO_ID"].ToString());
                            string sMsg_HIS = _RYMES_DB.GET_DATA("WE_WORK_HISTORY_LOAD", ref ds_HIS);
                            if (string.IsNullOrEmpty(sMsg_HIS))
                            {
                                txt_LOT_QTY.Text = ds_HIS.Tables[0].Rows.Count.ToString();
                                ucGridControl1.DataSource = ds_HIS.Tables[0];
                                ucGridControl2.DataSource = ds_HIS.Tables[1];
                                dt_wafer = ds_HIS.Tables[2];

                                RestoreLayout(this, (ucGridControl1.MainView as ucGridView));
                                RestoreLayout(this, (ucGridControl2.MainView as ucGridView));

                                radioGroup1.Properties.Items.Clear();
                                if (!string.IsNullOrEmpty(_Ticket_Info["SN_YN"].ToString()))
                                {
                                    btn_PRINT.Enabled = true;
                                    DataTable dt_MODEL = new DataTable();
                                    _RYMES_DB._DB_Parameters.Add("@p_GROUP_CODE", "ITEM_CODE_MODEL");
                                    _RYMES_DB._DB_Parameters.Add("@p_OPTION", _Ticket_Info["ITEM_CODE"].ToString());

                                    string sMsg_MODEL = _RYMES_DB.GET_DATA("SYS_CODE_LOAD", ref dt_MODEL);
                                    if (string.IsNullOrEmpty(sMsg_MODEL))
                                    {
                                        foreach (DataRow dr in dt_MODEL.Rows)
                                        {
                                            radioGroup1.Properties.Items.Add(new DevExpress.XtraEditors.Controls.RadioGroupItem(dr[0].ToString(), dr[0].ToString()));
                                        }
                                    }
                                }
                                else
                                {
                                    btn_PRINT.Enabled = false;
                                }

                                if ((ucGridControl1.MainView as ucGridView).Columns["COMMENT"] is null)
                                {
                                    GridColumn col = (ucGridControl1.MainView as ucGridView).Columns.AddVisible("COMMENT", "");
                                    col.UnboundType = DevExpress.Data.UnboundColumnType.Object;
                                    RepositoryItemButtonEdit repButton = new RepositoryItemButtonEdit
                                    {
                                        Name = "rb1"
                                    };
                                    repButton.ButtonClick += repButton_Click;
                                    repButton.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
                                    repButton.Buttons[0].Kind = ButtonPredefines.Search;

                                    ucGridControl1.RepositoryItems.Add(repButton);
                                    col.ColumnEdit = repButton;
                                    col.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
                                }

                                for (int i = 1; i < view.Columns.Count; i++)
                                {
                                    if (view.Columns[i].FieldName == "COMMENT")
                                    {
                                        view.Columns[i].OptionsColumn.AllowEdit = true;
                                        view.Columns[i].OptionsColumn.ReadOnly = false;
                                    }
                                    else if (_Cell_Info["OP_TYPE"].ToString() == "0001" || _Cell_Info["OP_TYPE"].ToString() == "0002")
                                    {
                                        view.Columns[i].OptionsColumn.AllowEdit = true;
                                        view.Columns[i].OptionsColumn.ReadOnly = false;
                                        view.Columns[i].ColumnEdit = repositoryItemTextEdit1;
                                    }
                                    else
                                    {
                                        view.Columns[i].OptionsColumn.AllowEdit = false;
                                        view.Columns[i].OptionsColumn.ReadOnly = true;
                                    }
                                }
                            }
                            else
                            {
                                ucGridControl1.DataSource = null;
                                ucGridControl2.DataSource = null;
                                radioGroup1.Properties.Items.Clear();
                                btn_PRINT.Enabled = false;
                                MessageBox.Show(sMsg_HIS, "DB ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(sMsg_WT, "DB ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    _Ticket_Info = null;

                    txt_ORDER_NO.Text = "";
                    txt_ORDER_DATE.Text = "";
                    txt_ITEM_CODE.Text = "";
                    txt_ITEM_NAME.Text = "";
                    txt_TICKET_DESC.Text = "";
                    txt_PLAN_QTY.Text = "";
                    txt_COMP_QTY.Text = "";
                    txt_DEFECT_QTY.Text = "";
                    txt_LOT_QTY.Text = "";

                    isFIRST = false;

                    ucGridControl1.DataSource = null;
                    ucGridControl2.DataSource = null;
                    radioGroup1.Properties.Items.Clear();
                    btn_PRINT.Enabled = false;

                    dt_wafer = null;
                    //gridControl_his.DataSource = null;
                }
                switch (table.Rows[0]["CELL_STATE"].ToString())
                {
                    case "0001":
                        lbl_Status.BackColor = Color.SeaGreen;

                        btn_TICKET_ID.Enabled = false;
                        btn_WORKS.Enabled = true;
                        btn_Defect.Enabled = true;
                        btn_DownTime.Enabled = true;
                        btn_OrderComp.Enabled = true;
                        btn_CheckSheet.Enabled = true;
                        simpleButton7.Enabled = false;
                        simpleButton8.Enabled = false;
                        break;

                    case "0002":
                        lbl_Status.BackColor = Color.Goldenrod;

                        btn_TICKET_ID.Enabled = string.IsNullOrEmpty(btn_TICKET_ID.Text);
                        btn_WORKS.Enabled = true;
                        btn_Defect.Enabled = !string.IsNullOrEmpty(btn_TICKET_ID.Text);
                        btn_DownTime.Enabled = true;
                        btn_OrderComp.Enabled = false;
                        btn_CheckSheet.Enabled = false;
                        simpleButton7.Enabled = false;
                        simpleButton8.Enabled = false;
                        break;

                    case "0003":
                        lbl_Status.BackColor = Color.Black;

                        btn_TICKET_ID.Enabled = false;
                        btn_WORKS.Enabled = true;
                        btn_Defect.Enabled = false;
                        btn_DownTime.Enabled = false;
                        btn_OrderComp.Enabled = false;
                        btn_CheckSheet.Enabled = false;
                        simpleButton7.Enabled = false;
                        simpleButton8.Enabled = false;
                        break;
                }

                if (string.IsNullOrEmpty(_Cell_Info["SHUTDOWN_FLAG"].ToString()))
                {
                    simpleButton4.Text = "퇴근";
                }
                else
                {
                    simpleButton4.Text = "시간외 근무";
                }
            }
            else
            {
                MessageBox.Show(sMsg, "DB ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void repButton_Click(object sender, ButtonPressedEventArgs e)
        {
            string wafer_no = (ucGridControl1.MainView as ucGridView).GetFocusedDataRow()[0].ToString();

            frm_Wafer_Hist_PopUp frm_Wafer_Hist_PopUp = new frm_Wafer_Hist_PopUp(_Main, _Cell_Info, wafer_no);

            frm_Wafer_Hist_PopUp.ShowDialog();
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            _RYMES_DB._DB_Parameters.Add("@p_MACADDR", _Main._MacAddr);
            _RYMES_DB._DB_Parameters.Add("@p_CELL_CODE", Text);
            _RYMES_DB._DB_Parameters.Add("@p_CREATE_USER", _Main._User_Info["USER_CODE"].ToString());

            string sMsg = _RYMES_DB.SET_DATA("WE_CLIENT_CELL_DELETE");
            if (string.IsNullOrEmpty(sMsg))
            {
            }
            else
            {
                MessageBox.Show(sMsg, "DB ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _frm_Work.xtraTabControl1.TabPages.Remove(Tag as XtraTabPage);
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (_Cell_Info["CELL_STATE"].ToString() == "0001")
            {
                _RYMES_DB._DB_Parameters.Add("@p_FA_ID", _Cell_Info["FA_ID"]);
                _RYMES_DB._DB_Parameters.Add("@p_OP_ID", _Cell_Info["OP_ID"]);
                _RYMES_DB._DB_Parameters.Add("@p_CELL_CODE", _Cell_Info["CELL_CODE"]);
                _RYMES_DB._DB_Parameters.Add("@p_CREATE_USER", _Cell_Info["WORKER"].ToString() == "" ? _Main._User_Info["USER_CODE"].ToString() : _Cell_Info["WORKER"].ToString());

                string sMsg = _RYMES_DB.SET_DATA("WE_CELL_DOWNTIME_START");
                if (string.IsNullOrEmpty(sMsg))
                {
                }
                else
                {
                    MessageBox.Show(sMsg, "DB ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            Get_Data();
            frm_Cell_DownTime_PopUp frm_Cell_DownTime_PopUp = new frm_Cell_DownTime_PopUp(_Main, _Cell_Info);
            if (DialogResult.OK == frm_Cell_DownTime_PopUp.ShowDialog())
            {
            }
            Get_Data();
        }

        private void btn_OrderComp_Click(object sender, EventArgs e)
        {
            btn_OrderComp.Click -= btn_OrderComp_Click;
            //if (string.IsNullOrEmpty(btn_TUBE_SN.Text))
            //{
            //    MessageBox.Show("Tube S/N 이 등록 되지 않았습니다.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //if (String.IsNullOrEmpty(_Ticket_Info["PRODUCT_SN"].ToString()) && (_Ticket_Info["SN_OP_ID"].ToString() == _Cell_Info["OP_ID"].ToString()))
            //{
            //    MessageBox.Show(" S/N 이 생성 되지 않았습니다.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            _RYMES_DB._DB_Parameters.Add("@p_FA_ID", _Cell_Info["FA_ID"]);
            _RYMES_DB._DB_Parameters.Add("@p_OP_ID", _Cell_Info["OP_ID"]);
            _RYMES_DB._DB_Parameters.Add("@p_CELL_CODE", _Cell_Info["CELL_CODE"]);
            _RYMES_DB._DB_Parameters.Add("@p_TICKET_ID", _Cell_Info["TICKET_ID"]);
            _RYMES_DB._DB_Parameters.Add("@p_WO_ID", _Cell_Info["WO_ID"]);
            _RYMES_DB._DB_Parameters.Add("@p_COMP_QTY", int.Parse(txt_LOT_QTY.Text));
            _RYMES_DB._DB_Parameters.Add("@p_CREATE_USER", _Cell_Info["WORKER"].ToString() == "" ? _Main._User_Info["USER_CODE"].ToString() : _Cell_Info["WORKER"].ToString());

            string sMsg = _RYMES_DB.SET_DATA("WE_ORDER_COMPLETE");
            if (string.IsNullOrEmpty(sMsg))
            {
                MessageBox.Show("Save Success", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(sMsg, "DB ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Get_Data();
            btn_OrderComp.Click += btn_OrderComp_Click;
        }

        private void txt_WORKS_Click(object sender, EventArgs e)
        {
            Get_Data();
            if (!(string.IsNullOrEmpty(_Cell_Info["SHUTDOWN_FLAG"].ToString())))
            {
                MessageBox.Show("계획정지 시간입니다", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frm_Workers_PopUp frm_Workers_PopUp = new frm_Workers_PopUp(_Main, _Cell_Info);
            if (DialogResult.OK == frm_Workers_PopUp.ShowDialog())
            {
            }
            Get_Data();
        }

        private void txt_TICKET_ID_Click(object sender, EventArgs e)
        {
            Get_Data();
            if (_Cell_Info["CELL_STATE"].ToString() == "0003")
            {
                return;
            }
            frm_Work_Ticket_PopUp frm_Work_Ticket_PopUp = new frm_Work_Ticket_PopUp(_Main, _Cell_Info);
            if (DialogResult.OK == frm_Work_Ticket_PopUp.ShowDialog())
            {
            }
            Get_Data();
        }

        private void txt_TUBE_SN_Click(object sender, EventArgs e)
        {
        }

        private void btn_Defect_Click(object sender, EventArgs e)
        {
            frm_Defect_PopUp frm_Defect_PopUp = new frm_Defect_PopUp(_Main, _Cell_Info);
            if (DialogResult.OK == frm_Defect_PopUp.ShowDialog())
            {
            }
            Get_Data();
        }

        private void btn_CheckSheet_Click(object sender, EventArgs e)
        {
            frm_Check_Sheet_PopUp frm_Check_Sheet_PopUp = new frm_Check_Sheet_PopUp(_Main, _Cell_Info,_Cell_Info["OP_TYPE"].ToString() == "0001" ? null: dt_wafer.Rows[0][0].ToString() );
            if (DialogResult.OK == frm_Check_Sheet_PopUp.ShowDialog())
            {
            }
            Get_Data();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Visible)
            {
                Get_Data();
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
        }

        private void btn_TICKET_ID_EditValueChanged(object sender, EventArgs e)
        {
        }

        private void repositoryItemTextEdit1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)22)
            {
                e.Handled = true;

                IDataObject obj = Clipboard.GetDataObject();
                string[,] Ls_2DArray = null;
                string[] Ls_ColumnNames = GetColumns(view);
                int Li_StartRow = view.FocusedRowHandle;
                int Li_StartCol = GetColumnIndex(view.FocusedColumn.FieldName, Ls_ColumnNames);
                if (obj.GetDataPresent(DataFormats.Text))
                {
                    string Ls_Clipboard = (string)obj.GetData(DataFormats.Text);
                    string[] Ls_Line = Ls_Clipboard.Replace(Environment.NewLine, "\n").Split('\n');
                    string[] Ls_OneLineSample = Ls_Line[0].Split('\t');
                    Ls_2DArray = new string[Ls_Line.Length, Ls_OneLineSample.Length];
                    int Li_EndRow = Math.Min(Li_StartRow + Ls_Line.Length - 1, view.RowCount);
                    int Li_EndCol = Math.Min(Li_StartCol + Ls_OneLineSample.Length, view.Columns.Count);
                    int Li_CntRow = Li_EndRow - Li_StartRow;
                    int Li_CntCol = Li_EndCol - Li_StartCol;
                    for (int Li_Y = 0; Li_Y <= Li_CntRow; Li_Y++)
                    {
                        string[] Ls_OneLine = Ls_Line[Li_Y].Split('\t');
                        if (Ls_OneLine.Length < Li_CntCol)
                        {
                            break;
                        }

                        for (int Li_X = 0; Li_X < Li_CntCol; Li_X++)
                        {
                            try
                            {
                                view.SetRowCellValue(Li_Y + Li_StartRow, GetColumnName(Li_X +
                                              Li_StartCol, Ls_ColumnNames), Ls_OneLine[Li_X].Trim());
                            }
                            catch
                            { }
                        }
                    }
                }
            }
        }

        public string[] GetColumns(GridView P_View)
        {
            string[] Ls_ColumnNames = null;
            Ls_ColumnNames = new string[P_View.Columns.Count];
            for (int i = 0; i < P_View.Columns.Count; i++)
            {
                Ls_ColumnNames[i] = P_View.Columns[i].FieldName;
            }
            return Ls_ColumnNames;
        }

        public int GetColumnIndex(string Ps_ColumnName, string[] Ps_ColumnArray)
        {
            int Li_RET = -1;
            for (int i = 0; i < Ps_ColumnArray.Length; i++)
            {
                if (Ps_ColumnArray[i] == Ps_ColumnName)
                {
                    Li_RET = i;
                    break;
                }
            }
            return Li_RET;
        }

        public string GetColumnName(int Pi_ColumnIndex, string[] Ps_ColumnArray)
        {
            if (Pi_ColumnIndex > Ps_ColumnArray.Length - 1)
            {
                return null;
            }

            return Ps_ColumnArray[Pi_ColumnIndex];
        }

        private void simpleButton3_Click_1(object sender, EventArgs e)
        {
            string sMsg = "";
            for (int i = 0; i < view.RowCount; i++)
            {
                _RYMES_DB._DB_Parameters.Add("@p_WAFER_NO", view.GetRowCellValue(i, "WAFER_NO"));
                _RYMES_DB._DB_Parameters.Add("@p_HIC", view.GetRowCellValue(i, "HIC"));
                _RYMES_DB._DB_Parameters.Add("@p_SCINTILLATOR", view.GetRowCellValue(i, "SCINTILLATOR"));
                _RYMES_DB._DB_Parameters.Add("@p_BOARD", view.GetRowCellValue(i, "BOARD"));
                _RYMES_DB._DB_Parameters.Add("@p_SUBSTRATE", view.GetRowCellValue(i, "SUBSTRATE"));
                _RYMES_DB._DB_Parameters.Add("@p_BUTTING_WAFER", view.GetRowCellValue(i, "BUTTING_WAFER"));
                _RYMES_DB._DB_Parameters.Add("@p_PRODUCT_SN", view.GetRowCellValue(i, "PRODUCT_SN"));
                _RYMES_DB._DB_Parameters.Add("@p_WAFER_DESC", view.GetRowCellValue(i, "WAFER_DESC"));
                _RYMES_DB._DB_Parameters.Add("@p_CREATE_USER", _Cell_Info["WORKER"].ToString() == "" ? _Main._User_Info["USER_CODE"].ToString() : _Cell_Info["WORKER"].ToString());

                sMsg += _RYMES_DB.SET_DATA("WE_WAFER_MASTER_UPDATE");
                if (!string.IsNullOrEmpty(sMsg))
                {
                    MessageBox.Show(sMsg, "DB ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            MessageBox.Show("Save Success", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_PRINT_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)ucGridControl1.DataSource;

            SN_LABEL sN_LABEL = new SN_LABEL(dt, radioGroup1.EditValue.ToString());

            ReportPrintTool printTool = new ReportPrintTool(sN_LABEL);
            printTool.PrintDialog();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            Get_Data();

            string sql = string.IsNullOrEmpty(_Cell_Info["SHUTDOWN_FLAG"].ToString()) ? "WE_CELL_STATUS_BAK" : "WE_CELL_STATUS_RE";

            _RYMES_DB._DB_Parameters.Add("@p_CELL_CODE", Text);
            _RYMES_DB._DB_Parameters.Add("@p_CREATE_USER", _Main._User_Info["USER_CODE"].ToString());

            string sMsg = _RYMES_DB.SET_DATA(sql);
            if (string.IsNullOrEmpty(sMsg))
            {
            }
            else
            {
                MessageBox.Show(sMsg, "DB ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Get_Data();
        }


        private void ucGridView2_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "PRODUCT_SN")
            {
                e.DisplayText = (Convert.ToString(e.Value)).ToUpper();
            }
        }
    }
}