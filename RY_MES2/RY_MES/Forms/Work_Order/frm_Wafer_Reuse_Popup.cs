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
    public partial class frm_Wafer_Reuse_Popup : RY_MES.frm_Base
    {
        private DataTable dt;

        private string _fa_id = "";
        private string _wafer_no = "";
        public frm_Wafer_Reuse_Popup(params object[] paramArray)
        {
            TopLevel = true;
            InitializeComponent();

            _fa_id = paramArray[0].ToString();
            _wafer_no = paramArray[1].ToString();
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            _RYMES_DB = _Main._RYMES_DB;

            pnl_Conditions.Visible = false;
            btn_Conditions.Visible = false;

            txt_WAFER_NO.Text = _wafer_no;

            Get_Data(_wafer_no);

            ucGridView1.OptionsFind.AlwaysVisible = false;
            ucGridView1.OptionsCustomization.AllowFilter = false;
        }

        private void Get_Data(string wafer_no)
        {
            try
            {
                _RYMES_DB._DB_Parameters.Add("@p_FA_ID", _fa_id);
                _RYMES_DB._DB_Parameters.Add("@p_WAFER_NO", wafer_no);

                string sMsg = _RYMES_DB.GET_DATA("WO_REUSE_WAFER_LOAD", ref dt);

                if (string.IsNullOrEmpty(sMsg))
                {
                    dt.Columns.Add("RESULT", typeof(string));

                    RepositoryItemRadioGroup repositoryItemRadioGroup = new RepositoryItemRadioGroup();
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

                    repositoryItemRadioGroup.Items.Add(item1);
                    repositoryItemRadioGroup.Items.Add(item2);
                    repositoryItemRadioGroup.Name = "repositoryItemRadioGroup";

                    ucGridControl1.RepositoryItems.Add(repositoryItemRadioGroup);
                                       
                    ucGridControl1.DataSource = dt;

                    ucGridView1.Columns["RESULT"].Visible = true;
                    ucGridView1.Columns["RESULT"].OptionsColumn.AllowEdit = true;
                    ucGridView1.Columns["RESULT"].OptionsColumn.ReadOnly = false;
                    ucGridView1.Columns["RESULT"].Width = 150;
                    ucGridView1.Columns["RESULT"].Name = "RESULT";
                    ucGridView1.Columns["RESULT"].ColumnEdit = repositoryItemRadioGroup;
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
            ucGridView view = ucGridView1;

            for (int i = 0; i < view.RowCount; i++)
            {
                if (view.GetRowCellValue(i, "RESULT") is null || string.IsNullOrEmpty(view.GetRowCellValue(i, "RESULT").ToString()))
                {
                    MessageBox.Show("Wafer 조치 결과를 입력해주세요.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            SplashScreenManager.ShowForm(_Main, typeof(frm_Wait), true, true, false);

            string result_msg = "";
            DbTransaction trans = _RYMES_DB._Connection.BeginTransaction();

            try
            {
                for (int i = 0; i < view.RowCount; i++)
                {
                    DataRow dr = view.GetDataRow(i);

                    _RYMES_DB._DB_Parameters.Add("@p_FA_ID", _fa_id);
                    _RYMES_DB._DB_Parameters.Add("@p_WAFER_NO", dr["WAFER_NO"].ToString());
                    _RYMES_DB._DB_Parameters.Add("@p_RESULT", dr["RESULT"].ToString());
                    _RYMES_DB._DB_Parameters.Add("@p_CREATE_USER", _Main._User_Info["USER_CODE"].ToString());

                    string sMsg = _RYMES_DB.SET_DATA("WO_REUSE_WAFER_UPDATE", ref trans);

                    if (!string.IsNullOrEmpty(sMsg))
                    {
                        SplashScreenManager.CloseForm(false);
                        MessageBox.Show(sMsg, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        result_msg += "\nWafer No : " + dr["WAFER_NO"].ToString() + " / Wafer 상태 : " + dr["Result"].ToString() ;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            trans.Commit();
            MessageBox.Show("Wafer상태를 변경했습니다.\n" + result_msg, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

            DialogResult = DialogResult.OK;
            Close();
            Dispose();
        }
    }
}