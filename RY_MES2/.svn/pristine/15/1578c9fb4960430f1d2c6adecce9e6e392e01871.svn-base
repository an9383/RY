using System;
using System.Data;
using System.Windows.Forms;

namespace RY_MES.Forms
{
    public partial class frm_Check_Sheet_Input_T_PopUp : frm_Base
    {
        private DataRow _Cell_Info;
        private DataRow _Check_Ieem;

        public frm_Check_Sheet_Input_T_PopUp(frm_Main frm_Main, DataRow Cell_Info, DataRow Check_Ieem)
        {
            InitializeComponent();

            init_PopUp();
            _Main = frm_Main;
            _RYMES_DB = _Main._RYMES_DB;
            _Cell_Info = Cell_Info;
            _Check_Ieem = Check_Ieem;

            Text = Check_Ieem["CHK_NAME"].ToString();
        }

        private void frm_Load(object sender, EventArgs e)
        {
            if (_Check_Ieem["INSPECTION_TYPE"].ToString() == "INT")
            {
                txt_VALUE_RESULT_NAME.Properties.Mask.EditMask = "d";
                txt_VALUE_RESULT_NAME.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            }

            if (_Check_Ieem["INSPECTION_TYPE"].ToString() == "DOUBLE")
            {
                txt_VALUE_RESULT_NAME.Properties.Mask.EditMask = "n";
                txt_VALUE_RESULT_NAME.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            }
            if (_Check_Ieem["INSPECTION_TYPE"].ToString() == "DOUBLE3")
            {
                txt_VALUE_RESULT_NAME.Properties.Mask.EditMask = "n3";
                txt_VALUE_RESULT_NAME.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            }

            txt_VALUE_RESULT_NAME.ImeMode = ImeMode.Alpha;
            txt_VALUE_RESULT_NAME.Focus();
            txt_VALUE_RESULT_NAME.EditValue = _Check_Ieem["VALUE_RESULT"].ToString();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if ((_Check_Ieem["INSPECTION_TYPE"].ToString() == "INT" || _Check_Ieem["INSPECTION_TYPE"].ToString() == "DOUBLE") && txt_VALUE_RESULT_NAME.EditValue.ToString() == "")
            {
                txt_VALUE_RESULT_NAME.EditValue = "0";
            }

            _RYMES_DB._DB_Parameters.Add("@p_VALUE_ID", _Check_Ieem["VALUE_ID"]);
            _RYMES_DB._DB_Parameters.Add("@p_VALUE_RESULT", txt_VALUE_RESULT_NAME.EditValue);
            _RYMES_DB._DB_Parameters.Add("@p_VALUE_RESULT_NAME", txt_VALUE_RESULT_NAME.EditValue);
            _RYMES_DB._DB_Parameters.Add("@p_CREATE_USER", _Cell_Info["WORKER"].ToString() == "" ? _Main._User_Info["USER_CODE"].ToString() : _Cell_Info["WORKER"].ToString());

            string sMsg = _RYMES_DB.SET_DATA("WE_CHECK_SHEET_MERGE");
            if (string.IsNullOrEmpty(sMsg))
            {
                //MessageBox.Show("Save Success", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(sMsg, "DB ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void txt_VALUE_RESULT_NAME_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btn_Save_Click(null, null);
            }
        }
    }
}