using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using nsCommon;
using System;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Windows.Forms;

namespace RY_MES.Forms
{
    public partial class frm_WO_Popup : RY_MES.frm_Base
    {
        private DataTable _dt;

        public frm_WO_Popup(params object[] paramArray)
        {
            TopLevel = true;
            InitializeComponent();

            _dt = paramArray[0] as DataTable;
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            _RYMES_DB = _Main._RYMES_DB;

            pnl_Conditions.Visible = false;
            btn_Conditions.Visible = false;

            dt_PLAN_DATE.EditValue = DateTime.Now.ToString("yyyy-MM-dd");

            gridControl.DataSource = _dt;

            ucGridView1.Columns["PLAN_DATE"].AppearanceCell.BackColor = Color.Salmon;

            RestoreLayout(this, ucGridView1);
        }
                
        private void btn_Save_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(_Main, typeof(frm_Wait), true, true, false);

            DbTransaction trans = _RYMES_DB._Connection.BeginTransaction();
            GridView view = ucGridView1;

            string sMsg = "";

            for (int i = 0; i < view.RowCount; i++)
            {
                _RYMES_DB._DB_Parameters.Add("@p_WO_ID", view.GetRowCellValue(i, "WO_ID"));
                _RYMES_DB._DB_Parameters.Add("@p_PLAN_DATE", dt_PLAN_DATE.EditValue);
                _RYMES_DB._DB_Parameters.Add("@p_CREATE_USER", _Main._User_Info["USER_CODE"].ToString());

                sMsg = _RYMES_DB.SET_DATA("WO_WO_MASTER_UPDATE", ref trans);

                if (!string.IsNullOrEmpty(sMsg))
                {
                    break;
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

        private void dt_PLAN_DATE_Enter(object sender, EventArgs e)
        {
            DateEdit edit = sender as DateEdit;

            BeginInvoke(new MethodInvoker(() =>
            {
                edit.SelectionStart = 8;
                edit.SelectionLength = 2;
            }));
        }
    }
}