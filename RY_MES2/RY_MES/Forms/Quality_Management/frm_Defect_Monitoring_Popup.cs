using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraSplashScreen;
using nsCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;

namespace RY_MES.Forms
{
    public partial class frm_Defect_Monitoring_Popup : RY_MES.frm_Base
    {
        private DataTable dt;
        private List<int> _defect_ids;
        private string _fa_id = "";
        private bool _input = false;
        private RepositoryItemRadioGroup repositoryItemRadioGroup;

        public frm_Defect_Monitoring_Popup(params object[] paramArray)
        {
            TopLevel = true;
            InitializeComponent();

            _defect_ids = (List<int>)paramArray[0];
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            _RYMES_DB = _Main._RYMES_DB;

            pnl_Conditions.Visible = false;
            btn_Conditions.Visible = false;

            txt_DEFECT_ID.Text = _defect_ids[0] + (_defect_ids.Count > 1 ? "외 " + (_defect_ids.Count - 1) + "건"    : "") ;

            ucGridView1.OptionsFind.AlwaysVisible = false;
            ucGridView1.OptionsView.ShowGroupPanel = false;
            ucGridView1.OptionsCustomization.AllowFilter = false;
            //ucGridView1.colum

            Get_Data(_defect_ids[0].ToString());

            SET_LookUpEdit_Data(le_SUPER_DEFECT_CAUSE, "REASON_SUPER_CAUSE_MASTER", txt_FA_ID.Text);
            SET_LookUpEdit_Data(le_SUPER_REASON_CODE, "REASON_SUPER_STATE_MASTER", txt_FA_ID.Text);

            ucGridView view = (gridControl1.MainView as ucGridView);

            repositoryItemRadioGroup = new RepositoryItemRadioGroup();
            RadioGroupItem item1 = new RadioGroupItem
            {
                Value = "scrap",
                Description = "Scrap"
            };

            RadioGroupItem item2 = new RadioGroupItem
            {
                Value = "rework",
                Description = "Rework"
            };

            RadioGroupItem item3 = new RadioGroupItem
            {
                Value = "RMA",
                Description = "RMA"
            };


            repositoryItemRadioGroup.Items.Add(item1);
            repositoryItemRadioGroup.Items.Add(item2);
            repositoryItemRadioGroup.Items.Add(item3);
            repositoryItemRadioGroup.Name = "repositoryItemRadioGroup";

            gridControl1.RepositoryItems.Add(repositoryItemRadioGroup);

            //view.Columns["Result"].Visible = true;
            view.Columns["Result"].OptionsColumn.AllowEdit = true;
            view.Columns["Result"].OptionsColumn.ReadOnly = false;
            view.Columns["Result"].Width = 200;
            view.Columns["Result"].Name = "RESULT";
            view.Columns["Result"].ColumnEdit = repositoryItemRadioGroup;

            
            //GridColumn col1 = new GridColumn();
            //col1.FieldName = "RESULT";
            //col1.Caption = "조치 결과";
            //col1.Name = "RESULT";
            //col1.Visible = true;
            //col1.ColumnEdit = repositoryItemRadioGroup;
            //col1.Width = 150;
            //view.Columns.Add(col1);
        }

        private void Get_Data(string defect_id)
        {
            DataSet ds = new DataSet();

            try
            {
                _RYMES_DB._DB_Parameters.Add("@p_DEFECT_ID", defect_id);
                string sMsg = _RYMES_DB.GET_DATA("QM_DEFECT_MONITORING_LOAD", ref ds);

                if (string.IsNullOrEmpty(sMsg))
                {
                    DataRow dr = ds.Tables[0].Rows[0];

                    txt_WO_ID.Text = dr["WO_ID"].ToString();
                    txt_DEFECT_SN.Text = dr["DEFECT_SN"].ToString();
                    txt_FA_ID.Text = dr["FA_ID"].ToString();
                    txt_ITEM_TYPE.Text = dr["ITEM_TYPE"].ToString();
                    txt_MODEL_NAME.Text = dr["MODEL_NAME"].ToString();
                    txt_ITEM_CODE.Text = dr["ITEM_CODE"].ToString();
                    txt_ITEM_NAME.Text = dr["ITEM_NAME"].ToString();
                    txt_OP_NAME.Text = dr["OP_NAME"].ToString();
                    txt_DEFECT_DATE.Text = dr["DEFECT_DATE"].ToString();
                    txt_CREATE_USER.Text = dr["CREATE_USER"].ToString();
                    txt_DEFECT_RESULT.Text = dr["DEFECT_RESULT"].ToString();
                    le_SUPER_REASON_CODE.EditValue = dr["SUPER_REASON_CODE"].ToString();
                    //SET_LookUpEdit_Data(le_REASON_CODE, "REASON_STATE_MASTER", le_SUPER_REASON_CODE.EditValue.ToString());
                    le_REASON_CODE.EditValue = dr["REASON_CODE"].ToString();
                    me_DEFECT_NOTES.Text = dr["DEFECT_NOTES"].ToString();

                    le_SUPER_DEFECT_CAUSE.EditValue = dr["SUPER_DEFECT_CAUSE"].ToString();
                    le_DEFECT_CAUSE.EditValue = dr["DEFECT_CAUSE"].ToString();
                    me_DEFECT_RESULT_NOTES.Text = dr["DEFECT_RESULT_NOTES"].ToString();

                  
                    _input = string.IsNullOrEmpty(le_DEFECT_CAUSE.Text.ToString());


                    dt = ds.Tables[1];
                    dt.Columns.Add("Result", typeof(string));
                    gridControl1.DataSource = ds.Tables[1];
                    ucGridView1.Columns["HIS_DESC"].Visible = false;
                    ucGridView1.Columns["WAFER_NO"].Width = 150;
                    ucGridView1.BestFitColumns();

                    for (int i = 0; i < ucGridView1.RowCount; i++)
                    {
                        ucGridView1.SetRowCellValue(i, "Result", ucGridView1.GetRowCellValue(i, "HIS_DESC").ToString());
                    }
                    
                    le_SUPER_REASON_CODE.Enabled = _input;
                    le_REASON_CODE.Enabled = _input;
                    //le_SUPER_DEFECT_CAUSE.Enabled = _input;
                    //le_DEFECT_CAUSE.Enabled = _input;
                    //me_DEFECT_RESULT_NOTES.Enabled = _input;
                    ucGridView1.OptionsBehavior.Editable = _input;
                    //btn_Save.Visible = _input;

                    
                    
                  
                    

                    if (dr["DEFECT_RESULT"].ToString() == "즉조치")
                    {
                        ucGridView1.Columns["Result"].Visible = false;
                        ucGridView1.Set_Column_Type("Result", ucGridView.Col_Type.Invisible);
                    }
                                    
                    if (txt_FA_ID.Text == "TFT")
                    {
                        if (txt_ITEM_TYPE.Text == "SW")
                        {
                            ucGridView1.Columns["WAFER_NO"].Caption = "MainboardSN";
                        }
                        else
                        {
                            ucGridView1.Columns["WAFER_NO"].Caption = "Panel No";
                        }
                    }
                    else if (txt_FA_ID.Text == "CSI")
                    {
                        if (txt_ITEM_TYPE.Text == "TFT")
                        {
                            ucGridView1.Columns["WAFER_NO"].Caption = "Panel No";
                        }
                        else
                        {
                            ucGridView1.Columns["WAFER_NO"].Caption = "Plate No";
                        }
                    }
                }
                else
                {
                    MessageBox.Show(sMsg, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception Occur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            ucGridView view = (gridControl1.MainView as ucGridView);
            if (le_DEFECT_CAUSE.EditValue is null)
            {
                MessageBox.Show("원인 코드를 입력해주세요.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (view.RowCount == 0)
            {
                if (txt_FA_ID.Text == "CMOS")
                {
                    MessageBox.Show("Wafer 조치 결과를 입력해주세요.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    MessageBox.Show("Panel 또는 Csi 조치 결과를 입력해주세요.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            for (int i = 0; i < view.RowCount; i++)
            {
                if (view.GetRowCellValue(i, "Result") is null || string.IsNullOrEmpty(view.GetRowCellValue(i, "Result").ToString()))
                {
                    MessageBox.Show("Wafer 조치 결과를 입력해주세요.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            SplashScreenManager.ShowForm(_Main, typeof(frm_Wait), true, true, false);

            DbTransaction trans = _RYMES_DB._Connection.BeginTransaction();

            try
            {
                foreach (int _defect_id in _defect_ids)
                {
                    _RYMES_DB._DB_Parameters.Add("@p_DEFECT_ID", _defect_id);
                    _RYMES_DB._DB_Parameters.Add("@p_REASON_CODE", le_REASON_CODE.EditValue);
                    _RYMES_DB._DB_Parameters.Add("@p_DEFECT_CAUSE", le_DEFECT_CAUSE.EditValue);
                    _RYMES_DB._DB_Parameters.Add("@p_DEFECT_RESULT_NOTES", me_DEFECT_RESULT_NOTES.Text);
                    _RYMES_DB._DB_Parameters.Add("@p_CREATE_USER", _Main._User_Info["USER_CODE"].ToString());

                    string sMsg = _RYMES_DB.SET_DATA("QM_DEFECT_MASTER_UPDATE", ref trans);

                    if (string.IsNullOrEmpty(sMsg))
                    {
                        //처음 원인코드를 입력한 경우만 wafer 상태 변경, 이후 수정 시 wafer 상태 변경하지 않음
                        if (_input)
                        {
                            for (int i = 0; i < view.RowCount; i++)
                            {
                                DataRow dr = view.GetDataRow(i);

                                _RYMES_DB._DB_Parameters.Add("@p_DEFECT_ID", _defect_id);
                                _RYMES_DB._DB_Parameters.Add("@p_WAFER_NO", dr["WAFER_NO"].ToString());
                                _RYMES_DB._DB_Parameters.Add("@p_RESULT", dr["Result"].ToString());
                                _RYMES_DB._DB_Parameters.Add("@p_CREATE_USER", _Main._User_Info["USER_CODE"].ToString());

                                sMsg = _RYMES_DB.SET_DATA("QM_DEFECT_WAFER_UPDATE", ref trans);

                                SplashScreenManager.CloseForm(false);

                                if (!string.IsNullOrEmpty(sMsg))
                                {
                                    MessageBox.Show(sMsg, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                        }
                    }
                    else
                    {
                        SplashScreenManager.CloseForm(false);
                        MessageBox.Show(sMsg, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }           
            }
            catch (Exception ex)
            {
                SplashScreenManager.CloseForm(false);
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            trans.Commit();
            MessageBox.Show("부적합 조치 결과가 정상 등록되었습니다.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

            DialogResult = DialogResult.OK;
            Close();
            Dispose();
        }

        private void le_EditValueChanging(object sender, ChangingEventArgs e)
        {
            LookUpEdit le = sender as LookUpEdit;

            if (e.OldValue != e.NewValue)
            {
                if (le.Name == le_SUPER_DEFECT_CAUSE.Name)
                {
                    SET_LookUpEdit_Data(le_DEFECT_CAUSE, "REASON_CAUSE_MASTER", e.NewValue.ToString());
                }
                else if (le.Name == le_SUPER_REASON_CODE.Name)
                {
                    SET_LookUpEdit_Data(le_REASON_CODE, "REASON_STATE_MASTER", e.NewValue.ToString());
                }

                //DataTable ds_lookup1 = new DataTable();
                //_RYMES_DB._DB_Parameters.Add("@p_SUPER_REASON_CODE", e.NewValue);
                //string sMsg = _RYMES_DB.GET_DATA("QM_CAUSE_REASON_LOAD", ref ds_lookup1);
                //if (string.IsNullOrEmpty(sMsg))
                //{
                //    le_DEFECT_CAUSE.Properties.DataSource = ds_lookup1;
                //    le_DEFECT_CAUSE.Properties.ValueMember = ds_lookup1.Columns[0].ColumnName;
                //    int DisplayMember = ds_lookup1.Columns.Count == 1 ? 0 : 1;
                //    le_DEFECT_CAUSE.Properties.DisplayMember = ds_lookup1.Columns[DisplayMember].ColumnName;
                //}

                //le_DEFECT_CAUSE.EditValue = null;
            }
        }
    }
}