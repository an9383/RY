using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraSplashScreen;
using nsCommon;
using System;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;

namespace RY_MES.Forms
{
    public partial class frm_SPEC_Popup : RY_MES.frm_Base
    {
        public frm_SPEC_Popup(params object[] paramArray)
        {
            TopLevel = true;
            InitializeComponent();
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            _RYMES_DB = _Main._RYMES_DB;

            pnl_Conditions.Visible = false;
            btn_Conditions.Visible = false;

            SET_LookUpEdit_Data(le_PK_ITEM_CODE, "ITEM_MASTER");
            SET_LookUpEdit_Data(le_QC_ITEM_CODE, "ITEM_MASTER");
            SET_LookUpEdit_Data(le_FT_ITEM_CODE, "ITEM_MASTER");

            le_PK_ITEM_CODE.Properties.DisplayMember = "코드";
            le_QC_ITEM_CODE.Properties.DisplayMember = "코드";
            le_FT_ITEM_CODE.Properties.DisplayMember = "코드";
        }

        private void le_EditValueChanged(object sender, EventArgs e)
        {
            if ((sender as SearchLookUpEdit).Name == "le_PK_ITEM_CODE")
            {
                try
                {
                    DataTable dt = new DataTable();

                    string sMsg = _RYMES_DB.GET_DATA("SELECT DISTINCT QC_ITEM_CODE, FT_ITEM_CODE " +
                        "                               FROM SPEC_MASTER " +
                        "                              WHERE ITEM_CODE = '" + le_PK_ITEM_CODE.Text.ToString() + "'", ref dt);
                    if (string.IsNullOrEmpty(sMsg))
                    {
                        le_QC_ITEM_CODE.EditValue = dt.Rows[0]["QC_ITEM_CODE"].ToString();
                        le_FT_ITEM_CODE.EditValue = dt.Rows[0]["FT_ITEM_CODE"].ToString();

                        le_QC_ITEM_CODE.ReadOnly = true;
                        le_FT_ITEM_CODE.ReadOnly = true;
                    }
                    else
                    {
                        le_QC_ITEM_CODE.ReadOnly = false;
                        le_FT_ITEM_CODE.ReadOnly = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Exception Occur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if ((sender as SearchLookUpEdit).Name == "le_QC_ITEM_CODE")
            {
                try
                {
                    DataTable dt = new DataTable();

                    string sMsg = _RYMES_DB.GET_DATA("SELECT DISTINCT FT_ITEM_CODE " +
                        "                               FROM SPEC_MASTER " +
                        "                              WHERE QC_ITEM_CODE = '" + le_QC_ITEM_CODE.Text.ToString() + "'", ref dt);
                    if (string.IsNullOrEmpty(sMsg))
                    {
                        le_FT_ITEM_CODE.EditValue = dt.Rows[0]["FT_ITEM_CODE"].ToString();

                        le_FT_ITEM_CODE.ReadOnly = true;
                    }
                    else
                    {
                        le_FT_ITEM_CODE.ReadOnly = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Exception Occur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


            if (!string.IsNullOrEmpty(le_PK_ITEM_CODE.Text) && !string.IsNullOrEmpty(le_QC_ITEM_CODE.Text) && !string.IsNullOrEmpty(le_FT_ITEM_CODE.Text))
            {
                DataTable dt = new DataTable();

                try
                {
                    _RYMES_DB._DB_Parameters.Add("@p_QC_ITEM_CODE", le_QC_ITEM_CODE.Text);
                    _RYMES_DB._DB_Parameters.Add("@p_FT_ITEM_CODE", le_FT_ITEM_CODE.Text);
                    
                    string sMsg = _RYMES_DB.GET_DATA("QM_DG_SPEC_LIST_LOAD", ref dt);

                    if (string.IsNullOrEmpty(sMsg))
                    {
                        ucGridControl1.DataSource = dt;
                        ucGridView1.CheckBox_Column_Add();
                        ucGridView1.BestFitColumns();

                        ucGridView1.Columns["SPEC"].OptionsColumn.AllowEdit = true;
                        ucGridView1.Columns["SPEC"].OptionsColumn.ReadOnly = false;

                        ucGridView1.Columns["SPEC_DESC"].OptionsColumn.AllowEdit = true;
                        ucGridView1.Columns["SPEC_DESC"].OptionsColumn.ReadOnly = false;
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

        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(le_PK_ITEM_CODE.Text) || string.IsNullOrEmpty(le_QC_ITEM_CODE.Text) || string.IsNullOrEmpty(le_FT_ITEM_CODE.Text))
            {
                MessageBox.Show("PK, QC, FT 품번은 필수 입력 항목입니다.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (ucGridView1.SelectedRowsCount == 0)
            {
                MessageBox.Show("등록하실 spec 을 선택해주세요.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SplashScreenManager.ShowForm(_Main, typeof(frm_Wait), true, true, false);

            DbTransaction trans = _RYMES_DB._Connection.BeginTransaction();
            string sMsg = "";

            try
            {
                _RYMES_DB._DB_Parameters.Add("@p_ITEM_CODE", le_PK_ITEM_CODE.Text);

                sMsg = _RYMES_DB.SET_DATA("QM_DG_SPEC_MASTER_DELETE", ref trans);

                if (string.IsNullOrEmpty(sMsg))
                {
                    int[] selectedRowsHandle = ucGridView1.GetSelectedRows();

                    for (int i = 0; i < selectedRowsHandle.Length; i++)
                    {
                        int rowhandle = selectedRowsHandle[i];
                        DataRow dr = ucGridView1.GetDataRow(rowhandle);

                        _RYMES_DB._DB_Parameters.Add("@p_ITEM_CODE", le_PK_ITEM_CODE.Text);
                        _RYMES_DB._DB_Parameters.Add("@p_QC_ITEM_CODE", le_QC_ITEM_CODE.Text);
                        _RYMES_DB._DB_Parameters.Add("@p_FT_ITEM_CODE", le_FT_ITEM_CODE.Text);
                        _RYMES_DB._DB_Parameters.Add("@p_SPEC_NAME", dr["SPEC_NAME"]);
                        _RYMES_DB._DB_Parameters.Add("@p_SPEC", dr["SPEC"]);
                        _RYMES_DB._DB_Parameters.Add("@p_SPEC_DESC", dr["SPEC_DESC"]);
                        _RYMES_DB._DB_Parameters.Add("@p_CREATE_USER", _Main._User_Info["USER_CODE"]);

                        sMsg = _RYMES_DB.SET_DATA("QM_DG_SPEC_MASTER_MERGE", ref trans);

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
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception Occur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}