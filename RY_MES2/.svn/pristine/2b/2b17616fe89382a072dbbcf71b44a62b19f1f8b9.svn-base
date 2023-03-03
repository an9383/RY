using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using nsCommon;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace RY_MES.Forms
{
    public partial class frm_QC_DOC_Approval_Popup : RY_MES.frm_Base
    {
        private string _ticket_id;
        private string _fa_id;
        private string _template_type;

        public frm_QC_DOC_Approval_Popup(params object[] paramArray)
        {
            TopLevel = true;
            InitializeComponent();

            _ticket_id = paramArray[0].ToString();
            _fa_id = paramArray[1].ToString();
            _template_type = paramArray[2].ToString();
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            _RYMES_DB = _Main._RYMES_DB;

            pnl_Conditions.Visible = false;
            btn_Conditions.Visible = false;

            btn_Update.Visible = false;

            Get_Data();
            ucGridView view = (gridControl1.MainView as ucGridView);
            view.RowStyle += gridView_RowStyle;
            view.RowClick += gridView1_RowClick;
        }

        private void Get_Data()
        {
            ucGridView view = (gridControl1.MainView as ucGridView);
            SplashScreenManager.ShowForm(_Main, typeof(frm_Wait), true, true, false);
            try
            {
                DataSet ds = new DataSet();

                _RYMES_DB._DB_Parameters.Add("@p_TICKET_ID", _ticket_id);
                _RYMES_DB._DB_Parameters.Add("@p_FA_ID", _fa_id);
                //_RYMES_DB._DB_Parameters.Add("@p_TEMPLATE_TYPE", _template_type);

                string sMsg = _RYMES_DB.GET_DATA("QM_CA_QC_DOC_REPORT", ref ds);

                if (string.IsNullOrEmpty(sMsg))
                {
                    DataRow dr = ds.Tables[0].Rows[0];

                    lbl_TICKET_ID.Text = dr["TICKET_ID"].ToString();
                    lbl_ITEM_CODE.Text = dr["ITEM_CODE"].ToString();
                    lbl_PLAN_QTY.Text = dr["PLAN_QTY"].ToString();
                    lbl_INPUT_QTY.Text = dr["INPUT_QTY"].ToString();
                    lbl_COMP_QTY.Text = dr["COMP_QTY"].ToString();
                    lbl_DEFECT_QTY.Text = dr["DEFECT_QTY"].ToString();
                    lbl_SCRAP_QTY.Text = dr["SCRAP_QTY"].ToString();

                    gridControl1.DataSource = ds.Tables[1];
                    view.Columns["STATUS"].Visible = false;
                    view.BestFitColumns();

                    if (_fa_id == "TFT")
                    {
                        view.Columns["WAFER_NO"].Caption = "Panel 번호";
                    }
                    else if(_fa_id == "CSI")
                    {
                        view.Columns["WAFER_NO"].Caption = "Panel/CsI 번호";
                    }
                    
                    gridControl3.DataSource = ds.Tables[2];

                    RestoreLayout(this, ucGridView3);

                    if (string.IsNullOrEmpty(dr["CONFIRM_DATE"].ToString()) || string.IsNullOrEmpty(dr["APPLY_DATE"].ToString()))
                    {
                        btn_Update.Visible = true;
                    }

                    if (_template_type == "0001")
                    {
                        btn_Update.Text = "승  인";
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(dr["CONFIRM_DATE"].ToString()))
                        {
                            btn_Update.Text = "검  토";
                        }
                        else
                        {
                            btn_Update.Text = "승  인";
                        }
                    }

                    gridView1_RowClick(view, null);
                }
                else
                {
                    MessageBox.Show(sMsg, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SplashScreenManager.CloseForm(false);
            }
        }

        private void gridView_RowStyle(object sender, RowStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                string status = View.GetRowCellDisplayText(e.RowHandle, View.Columns["STATUS"]);
                if (status == "1")
                {
                    e.Appearance.ForeColor = Color.IndianRed;
                    e.HighPriority = true;
                }
            }
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            DataTable dt = new DataTable();

            GridView view = sender as GridView;

            if (view.SelectedRowsCount < 0)
            {
                if (view.RowCount > 0)
                {
                    view.SelectRow(0);
                }
                else
                {
                    return;
                }
            }

            try
            {
                _RYMES_DB._DB_Parameters.Add("@p_WAFER_NO", (sender as GridView).GetFocusedRowCellValue("WAFER_NO"));
                _RYMES_DB._DB_Parameters.Add("@p_TICKET_ID", _ticket_id);
                _RYMES_DB._DB_Parameters.Add("@p_TEMPLATE_TYPE", _template_type);

                string sMsg = _RYMES_DB.GET_DATA("QM_CA_CHK_VALUE_LOAD", ref dt);

                if (string.IsNullOrEmpty(sMsg))
                {
                    gridControl2.DataSource = dt;

                    ucGridView2.MemoEdit_Column("CHK_PROCESS_NAME");
                    ucGridView2.MemoEdit_Column("CHK_NAME");
                    ucGridView2.MemoEdit_Column("CRITERIA");
                    ucGridView2.MemoEdit_Column("INSPECTION_METHOD");

                    RestoreLayout(this, ucGridView2);
                }
                else
                {
                    MessageBox.Show(sMsg, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(_Main, typeof(frm_Wait), true, true, false);

            try
            {
                _RYMES_DB._DB_Parameters.Add("@p_TICKET_ID", _ticket_id);
                _RYMES_DB._DB_Parameters.Add("@p_TEMPLATE_TYPE", _template_type);

                if (btn_Update.Text == "검  토")
                {
                    if (_Main._User_Info["AUTH_CODE"].ToString() == "4003")
                    {
                        _RYMES_DB._DB_Parameters.Add("@p_CONFIRM_USER", _Main._User_Info["USER_CODE"].ToString());
                    }
                    else
                    {
                        MessageBox.Show("검토 권한이 없습니다.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    
                }
                else if (btn_Update.Text == "승  인")
                {
                    if (_Main._User_Info["AUTH_CODE"].ToString() == "4002"
                        || _Main._User_Info["AUTH_CODE"].ToString() == "1001" || _Main._User_Info["AUTH_CODE"].ToString() == "1002" || _Main._User_Info["AUTH_CODE"].ToString() == "1003")
                    {
                        _RYMES_DB._DB_Parameters.Add("@p_APPLY_USER", _Main._User_Info["USER_CODE"].ToString());
                    }
                    else
                    {
                        MessageBox.Show("승인 권한이 없습니다.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    
                }

                string sMsg = _RYMES_DB.SET_DATA("QM_CA_QC_DOC_HIS_UPDATE");

                SplashScreenManager.CloseForm(false);

                if (string.IsNullOrEmpty(sMsg))
                {
                    MessageBox.Show("Save Success!", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(sMsg, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                SplashScreenManager.CloseForm(false);
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Frm_Load(null, null);
        }
    }
}