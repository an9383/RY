using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraReports.UI;
using DevExpress.XtraTab;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace RY_MES.Forms
{
    public partial class frm_Cell_CSI_4Cell : frm_Base
    {
        private DataRow[] _Cell_Infos;
        private DataRow[] _Ticket_Infos;
        private frm_Work_Execution _frm_Work;
      
        /// <summary>
        /// DashBoard 생성자
        /// </summary>
        /// <param name="Main"></param>
        public frm_Cell_CSI_4Cell(frm_Main Main, frm_Work_Execution frm_Work)
        {
            InitializeComponent();
            _Main = Main;
            _RYMES_DB = Main._RYMES_DB;
            _frm_Work = frm_Work;
            

            Set_Description(layoutControl1);
            Set_Description(layoutControl2);
        }

        private void frm_Cell_Load(object sender, EventArgs e)
        {
            pnl_Conditions.Visible = false;
            btn_Conditions.Visible = false;

            labelControl1.Text = Text;

            Get_Data();
        }

        public void Get_Data()
        {
            DataTable table = new DataTable();

            _RYMES_DB._DB_Parameters.Add("@p_EQUIP_ID", Text);
            string sMsg = _RYMES_DB.GET_DATA("WE_EQUIP_INFO_4CELL_LOAD", ref table);
            if (string.IsNullOrEmpty(sMsg))
            {
                _Cell_Infos = new DataRow[table.Rows.Count];
                _Ticket_Infos = new DataRow[table.Rows.Count];

                foreach (DataRow dr in table.Rows)
                {
                    int index = table.Rows.IndexOf(dr);
                    if (index == 0)
                    {
                        lbl_Status.Text = dr["CELL_STATE_NAME"].ToString();
                        lbl_FA_NAME.Text = dr["FA_NAME"].ToString();
                        lbl_OP_NAME.Text = dr["OP_NAME"].ToString();
                        lbl_Status.Text = dr["CELL_STATE_NAME"].ToString();
                        btn_WORKS.Text = dr["WORKS"].ToString();
                        dateEdit1.EditValue = dr["OPEN_TIME"];

                        btn_TICKET_ID0.Enabled = false;
                        btn_TICKET_ID1.Enabled = false;
                        btn_TICKET_ID2.Enabled = false;
                        btn_TICKET_ID3.Enabled = false;
                        btn_OrderComp.Text = dr["OPEN_TIME"].ToString() == ""?"작업시작":"작업완료";
                        dateEdit1.Enabled = dr["OPEN_TIME"].ToString() == "";

                        if (string.IsNullOrEmpty(dr["SHUTDOWN_FLAG"].ToString()))
                        {
                            simpleButton4.Text = "퇴근";
                        }
                        else
                        {
                            simpleButton4.Text = "시간외 근무";
                        }


                        switch (dr["CELL_STATE"].ToString())
                        {
                            case "0001":
                                lbl_Status.AppearanceItemCaption.BackColor = Color.SeaGreen;

                                btn_WORKS.Enabled = true;
                                btn_DownTime.Enabled = true;
                                btn_OrderComp.Enabled = true;

                                break;

                            case "0002":
                                lbl_Status.AppearanceItemCaption.BackColor = Color.Goldenrod;

                                btn_WORKS.Enabled = true;
                                btn_DownTime.Enabled = true;
                                btn_OrderComp.Enabled = dr["OPEN_TIME"].ToString() == "";
                                break;

                            case "0003":
                                lbl_Status.AppearanceItemCaption.BackColor = Color.Black;

                                btn_WORKS.Enabled = true;
                                btn_DownTime.Enabled = false;
                                btn_OrderComp.Enabled = false;
                                break;
                        }
                    }

                    _Cell_Infos[index] = dr;

                    LayoutControl layoutControl = (LayoutControl)layoutControl1.Controls["lc_Cell" + index.ToString()];
                    ucGridControl ucGrid = (layoutControl.Controls["ucGridControl" + index.ToString()] as ucGridControl);

                    if (dr["CELL_STATE"].ToString() =="0002")
                    {
                        layoutControl.Controls["btn_TICKET_ID" + index.ToString()].Enabled = string.IsNullOrEmpty(dr["TICKET_ID"].ToString());
                    }

                    layoutControl.Root.Items[0].Text  = dr["CELL_NAME"].ToString();
                    layoutControl.Controls["btn_TICKET_ID" + index.ToString()].Text = dr["TICKET_ID"].ToString();
                    layoutControl.Controls["btn_TICKET_ID" + index.ToString()].Tag = dr;
                    ucGrid.Tag = dr;

                    if (!string.IsNullOrEmpty(dr["TICKET_ID"].ToString()))
                    {
                        DataTable dt_WT = new DataTable();

                        _RYMES_DB._DB_Parameters.Add("@p_TICKET_ID", dr["TICKET_ID"].ToString());
                        string sMsg_WT = _RYMES_DB.GET_DATA("WE_TICKET_INFO_LOAD", ref dt_WT);
                        if (string.IsNullOrEmpty(sMsg_WT))
                        {
                            _Ticket_Infos[index] = dt_WT.Rows[0];


                            layoutControl.Controls["txt_ORDER_NO" + index.ToString()].Text = _Ticket_Infos[index]["ORDER_NO"].ToString();
                            layoutControl.Controls["txt_ORDER_DATE" + index.ToString()].Text = ((DateTime)_Ticket_Infos[index]["ORDER_DATE"]).ToShortDateString();
                            layoutControl.Controls["txt_ITEM_CODE" + index.ToString()].Text = _Ticket_Infos[index]["ITEM_CODE"].ToString();
                            layoutControl.Controls["txt_ITEM_NAME" + index.ToString()].Text = _Ticket_Infos[index]["ITEM_NAME"].ToString();
                            layoutControl.Controls["txt_ITEM_TYPE" + index.ToString()].Text = _Ticket_Infos[index]["ITEM_TYPE"].ToString();
                            layoutControl.Controls["txt_TICKET_DESC" + index.ToString()].Text = _Ticket_Infos[index]["TICKET_DESC"].ToString();

                            
                            if (!string.IsNullOrEmpty(dr["WO_ID"].ToString()))
                            {
                                DataSet ds_HIS = new DataSet();

                                _RYMES_DB._DB_Parameters.Add("@p_WO_ID", dr["WO_ID"].ToString());
                                string sMsg_HIS = _RYMES_DB.GET_DATA("WE_WORK_HISTORY_4CELL_LOAD", ref ds_HIS);
                                if (string.IsNullOrEmpty(sMsg_HIS))
                                {
                                    
                                    ucGrid.DataSource = ds_HIS.Tables[0];

                                    RestoreLayout(this, (ucGrid.MainView as ucGridView));

                                    if ((ucGrid.MainView as ucGridView).Columns["RUNSHEET"] is null)
                                    {
                                        GridColumn col = (ucGrid.MainView as ucGridView).Columns.AddVisible("RUNSHEET", "");
                                        col.UnboundType = DevExpress.Data.UnboundColumnType.Object;
                                        RepositoryItemButtonEdit repButton = new RepositoryItemButtonEdit
                                        {
                                            Name = "rb1"
                                        };
                                        repButton.ButtonClick += btn_CheckSheet_Click;
                                        repButton.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
                                        repButton.Buttons[0].Kind = ButtonPredefines.Search;

                                        ucGrid.RepositoryItems.Add(repButton);
                                        col.ColumnEdit = repButton;
                                        col.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
                                    }
                                    if ((ucGrid.MainView as ucGridView).Columns["DEFECT"] is null)
                                    {
                                        GridColumn col = (ucGrid.MainView as ucGridView).Columns.AddVisible("DEFECT", "");
                                        col.UnboundType = DevExpress.Data.UnboundColumnType.Object;
                                        RepositoryItemButtonEdit repButton = new RepositoryItemButtonEdit
                                        {
                                            Name = "rb1"
                                        };
                                        repButton.ButtonClick += btn_Defect_Click;
                                        repButton.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
                                        repButton.Buttons[0].Kind = ButtonPredefines.Close;

                                        ucGrid.RepositoryItems.Add(repButton);
                                        col.ColumnEdit = repButton;
                                        col.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
                                    }
                                    if ((ucGrid.MainView as ucGridView).Columns["COMMENT"] is null)
                                    {
                                        GridColumn col = (ucGrid.MainView as ucGridView).Columns.AddVisible("COMMENT", "");
                                        col.UnboundType = DevExpress.Data.UnboundColumnType.Object;
                                        RepositoryItemButtonEdit repButton = new RepositoryItemButtonEdit
                                        {
                                            Name = "rb1"
                                        };
                                        repButton.ButtonClick += repButton_Click;
                                        repButton.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
                                        repButton.Buttons[0].Kind = ButtonPredefines.Ellipsis;

                                        ucGrid.RepositoryItems.Add(repButton);
                                        col.ColumnEdit = repButton;
                                        col.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
                                    }

                                    for (int i = 1; i < (ucGrid.MainView as ucGridView).Columns.Count; i++)
                                    {
                                        if ((ucGrid.MainView as ucGridView).Columns[i].FieldName == "RUNSHEET"
                                                || (ucGrid.MainView as ucGridView).Columns[i].FieldName == "DEFECT"
                                                || (ucGrid.MainView as ucGridView).Columns[i].FieldName == "COMMENT")
                                        {
                                            (ucGrid.MainView as ucGridView).Columns[i].OptionsColumn.AllowEdit = true;
                                            (ucGrid.MainView as ucGridView).Columns[i].OptionsColumn.ReadOnly = false;
                                        }
                                        else
                                        {
                                            (ucGrid.MainView as ucGridView).Columns[i].OptionsColumn.AllowEdit = false;
                                            (ucGrid.MainView as ucGridView).Columns[i].OptionsColumn.ReadOnly = true;
                                        }
                                    }
                                }
                                else
                                {
                                    ucGrid.DataSource = null;
                                    
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
                        _Ticket_Infos[index] = null;

                        layoutControl.Controls["txt_ORDER_NO" + index.ToString()].Text = "";
                        layoutControl.Controls["txt_ORDER_DATE" + index.ToString()].Text = "";
                        layoutControl.Controls["txt_ITEM_CODE" + index.ToString()].Text = "";
                        layoutControl.Controls["txt_ITEM_NAME" + index.ToString()].Text = "";
                        layoutControl.Controls["txt_TICKET_DESC" + index.ToString()].Text = "";
                        (layoutControl.Controls["ucGridControl" + index.ToString()] as ucGridControl).DataSource = null;                        
                    }
                    
                }
            }
            else
            {
                MessageBox.Show(sMsg, "DB ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_Defect_Click(object sender, EventArgs e)
        {
            if (_Cell_Infos[0]["CELL_STATE"].ToString() == "0001")
            {
                Control control = (Control)sender;
                string panel_no = (((ucGridControl)control.Parent).MainView as ucGridView).GetFocusedDataRow()[0].ToString();
                frm_Defect_PopUp frm_Defect_PopUp = new frm_Defect_PopUp(_Main, (DataRow)control.Parent.Tag, panel_no);
                if (DialogResult.OK == frm_Defect_PopUp.ShowDialog())
                {
                }
                Get_Data();
            }
        }

        private void btn_CheckSheet_Click(object sender, EventArgs e)
        {
            
                Control control = (Control)sender;
            string panel_no = (((ucGridControl)control.Parent).MainView as ucGridView).GetFocusedDataRow()[0].ToString();
            frm_Check_Sheet_PopUp frm_Check_Sheet_PopUp = new frm_Check_Sheet_PopUp(_Main, (DataRow)control.Parent.Tag, panel_no);
                if (DialogResult.OK == frm_Check_Sheet_PopUp.ShowDialog())
                {
                }
                Get_Data();
        }
        private void repButton_Click(object sender, ButtonPressedEventArgs e)
        {
            if (_Cell_Infos[0]["CELL_STATE"].ToString() == "0001")
            {
                Control control = (Control)sender;
                string panel_no = (((ucGridControl)control.Parent).MainView as ucGridView).GetFocusedDataRow()[0].ToString();

                string item_type ="";
                foreach (DataRow item in  _Ticket_Infos)
                {
                    if (!(item is null))
                    {
                        if (item["TICKET_ID"].ToString() == ((DataRow)control.Parent.Tag)["TICKET_ID"].ToString())
                        {
                            item_type = item["ITEM_TYPE"].ToString();
                        }
                    }
                }

                
                if (item_type == "TFT")
                {
                    frm_Wafer_His_CSI_PopUp frm_Wafer_His_CSI_PopUp = new frm_Wafer_His_CSI_PopUp(_Main, (DataRow)control.Parent.Tag, panel_no);
                    frm_Wafer_His_CSI_PopUp.ShowDialog();
                }
                else
                {
                    //frm_Wafer_Hist_PopUp frm_Wafer_Hist_PopUp = new frm_Wafer_Hist_PopUp(_Main, (DataRow)control.Parent.Tag, control.Text);
                    frm_Wafer_Hist_PopUp frm_Wafer_Hist_PopUp = new frm_Wafer_Hist_PopUp(_Main, (DataRow)control.Parent.Tag, panel_no);
                    frm_Wafer_Hist_PopUp.ShowDialog();
                }
                Get_Data();
                }
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
            if (_Cell_Infos[0]["CELL_STATE"].ToString() == "0001")
            {
                _RYMES_DB._DB_Parameters.Add("@p_FA_ID", _Cell_Infos[0]["FA_ID"]);
                _RYMES_DB._DB_Parameters.Add("@p_OP_ID", _Cell_Infos[0]["OP_ID"]);
                _RYMES_DB._DB_Parameters.Add("@p_CELL_CODE", _Cell_Infos[0]["CELL_CODE"]);
                _RYMES_DB._DB_Parameters.Add("@p_CREATE_USER", _Cell_Infos[0]["WORKER"].ToString() == "" ? _Main._User_Info["USER_CODE"].ToString() : _Cell_Infos[0]["WORKER"].ToString());

                string sMsg = _RYMES_DB.SET_DATA("WE_CELL_DOWNTIME_4CELL_START");
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
            frm_Cell_DownTime_PopUp frm_Cell_DownTime_PopUp = new frm_Cell_DownTime_PopUp(_Main, _Cell_Infos[0] , true);
            if (DialogResult.OK == frm_Cell_DownTime_PopUp.ShowDialog())
            {
            }
            Get_Data();
        }

        private void btn_OrderComp_Click(object sender, EventArgs e)
        {
            btn_OrderComp.Click -= btn_OrderComp_Click;
            try
            {
                if (_Cell_Infos[0]["OPEN_TIME"].ToString() == "")
                {
                    if (dateEdit1.Text == "")
                    {
                        MessageBox.Show("예상 종료시간이 입력 되지 않았습니다.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }


                    if (string.IsNullOrEmpty(btn_TICKET_ID0.Text) && string.IsNullOrEmpty(btn_TICKET_ID1.Text) && string.IsNullOrEmpty(btn_TICKET_ID2.Text) && string.IsNullOrEmpty(btn_TICKET_ID3.Text))
                    {
                        MessageBox.Show("작업지시가 입력 되지 않았습니다.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (string.IsNullOrEmpty(btn_WORKS.Text))
                    {
                        MessageBox.Show("작업자가 입력 되지 않았습니다.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    _RYMES_DB._DB_Parameters.Add("@p_FA_ID", _Cell_Infos[0]["FA_ID"]);
                    _RYMES_DB._DB_Parameters.Add("@p_OP_ID", _Cell_Infos[0]["OP_ID"]);
                    _RYMES_DB._DB_Parameters.Add("@p_CELL_CODE", _Cell_Infos[0]["CELL_CODE"]);
                    _RYMES_DB._DB_Parameters.Add("@p_OPEN_TIME", dateEdit1.EditValue);
                    _RYMES_DB._DB_Parameters.Add("@p_CREATE_USER", _Cell_Infos[0]["WORKER"].ToString() == "" ? _Main._User_Info["USER_CODE"].ToString() : _Cell_Infos[0]["WORKER"].ToString());


                    string sMsg = _RYMES_DB.SET_DATA("WE_ORDER_START_4CELL");
                    if (string.IsNullOrEmpty(sMsg))
                    {
                        MessageBox.Show("Save Success", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(sMsg, "DB ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                }
                else
                {

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

                    if (DialogResult.Yes == MessageBox.Show("작업을 완료하시겠습니까?", "완료", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {

                        string sHEAT = "F";

                        if (_Cell_Infos[0]["OP_ID"].ToString() == "CSI_DEPO")
                        {
                            DialogResult result = MessageBox.Show("내부 열처리 처리 하시겠습니까?", "Question", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                            if (DialogResult.Yes == result)
                            {
                                sHEAT = "T";
                            }
                            else if (DialogResult.No == result)
                            {
                                sHEAT = "F";
                            }
                            else
                            {
                                return;
                            }

                        }

                        _RYMES_DB._DB_Parameters.Add("@p_FA_ID", _Cell_Infos[0]["FA_ID"]);
                        _RYMES_DB._DB_Parameters.Add("@p_OP_ID", _Cell_Infos[0]["OP_ID"]);
                        _RYMES_DB._DB_Parameters.Add("@p_CELL_CODE", _Cell_Infos[0]["CELL_CODE"]);
                        _RYMES_DB._DB_Parameters.Add("@p_CSI_HEAT", sHEAT);
                        _RYMES_DB._DB_Parameters.Add("@p_CREATE_USER", _Cell_Infos[0]["WORKER"].ToString() == "" ? _Main._User_Info["USER_CODE"].ToString() : _Cell_Infos[0]["WORKER"].ToString());

                        string sMsg = _RYMES_DB.SET_DATA("WE_ORDER_COMPLETE_4CELL");
                        if (string.IsNullOrEmpty(sMsg))
                        {

                            MessageBox.Show("Save Success", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show(sMsg, "DB ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btn_OrderComp.Click += btn_OrderComp_Click;
                Get_Data();
            }
        }

        private void txt_WORKS_Click(object sender, EventArgs e)
        {
            Get_Data();
            //if (!(string.IsNullOrEmpty(_Cell_Info["SHUTDOWN_FLAG"].ToString())))
            //{
            //    MessageBox.Show("계획정지 시간입니다", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            frm_Workers_PopUp frm_Workers_PopUp = new frm_Workers_PopUp(_Main, _Cell_Infos[0], true);
            if (DialogResult.OK == frm_Workers_PopUp.ShowDialog())
            {
            }
            Get_Data();
        }

        private void txt_TICKET_ID_Click(object sender, EventArgs e)
        {
            Get_Data();
            frm_Work_Ticket_4CELL_PopUp frm_Work_Ticket_PopUp = new frm_Work_Ticket_4CELL_PopUp(_Main, (DataRow)(sender as Control).Tag);
            if (DialogResult.OK == frm_Work_Ticket_PopUp.ShowDialog())
            {
            }
            Get_Data();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Visible)
            {
                Get_Data();
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

        private void btn_PRINT_Click(object sender, EventArgs e)
        {
            //DataTable dt = (DataTable)ucGridControl1.DataSource;

            //SN_LABEL sN_LABEL = new SN_LABEL(dt, radioGroup1.EditValue.ToString());

            //ReportPrintTool printTool = new ReportPrintTool(sN_LABEL);
            //printTool.PrintDialog();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            Get_Data();

            //string sql = string.IsNullOrEmpty(_Cell_Info["SHUTDOWN_FLAG"].ToString()) ? "WE_CELL_STATUS_BAK" : "WE_CELL_STATUS_RE";

            //_RYMES_DB._DB_Parameters.Add("@p_CELL_CODE", Text);
            //_RYMES_DB._DB_Parameters.Add("@p_CREATE_USER", _Main._User_Info["USER_CODE"].ToString());

            //string sMsg = _RYMES_DB.SET_DATA(sql);
            //if (string.IsNullOrEmpty(sMsg))
            //{
            //}
            //else
            //{
            //    MessageBox.Show(sMsg, "DB ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            //Get_Data();
        }
    }
}