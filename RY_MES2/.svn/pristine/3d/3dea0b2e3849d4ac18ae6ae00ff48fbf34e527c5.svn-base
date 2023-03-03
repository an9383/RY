using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace RY_MES.Forms
{
    public partial class frm_SN_PopUp : frm_Base
    {
        private DataRow _Ticket_Info;
        private string _Panel_No;

        public frm_SN_PopUp(frm_Main frm_Main, DataRow Ticket_Info, string Panel_No)
        {
            InitializeComponent();

            init_PopUp();
            _Main = frm_Main;
            _RYMES_DB = _Main._RYMES_DB;
            _Panel_No = Panel_No;
            _Ticket_Info = Ticket_Info;

            Text = Panel_No;
        }

        private void frm_Load(object sender, EventArgs e)
        {
            dateEdit1.EditValue = DateTime.Now;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            _RYMES_DB._DB_Parameters.Add("@p_SN"         , textEdit7.Text.ToUpper());
            _RYMES_DB._DB_Parameters.Add("@p_WAFER_NO"   , _Panel_No);
            _RYMES_DB._DB_Parameters.Add("@p_PANEL_ID_IS_SN", _Ticket_Info["PANEL_ID_IS_SN"].ToString());
            _RYMES_DB._DB_Parameters.Add("@p_DELPHI_YN"  , _Ticket_Info["DELPHI_YN"].ToString());
            _RYMES_DB._DB_Parameters.Add("@p_MODEL_GROUP", _Ticket_Info["MODEL_GROUP"].ToString());
            _RYMES_DB._DB_Parameters.Add("@p_SN_MODEL"   , _Ticket_Info["SN_MODEL"].ToString());
            _RYMES_DB._DB_Parameters.Add("@p_PANEL_TYPE" , _Ticket_Info["PANEL_TYPE"].ToString());
            _RYMES_DB._DB_Parameters.Add("@p_REVISION"  , _Ticket_Info["REVISION"].ToString());
            ;

            if (checkEdit1.Checked)
            {
                _RYMES_DB._DB_Parameters.Add("@p_SEQ", -1);
            }
            else if (_Ticket_Info["PANEL_ID_IS_SN"].ToString() == "Y")
            {
                _RYMES_DB._DB_Parameters.Add("@p_SEQ", 0);
            }
            else
            {
                _RYMES_DB._DB_Parameters.Add("@p_SEQ", Convert.ToInt32(textEdit6.Text));

            }

            string sMsg = _RYMES_DB.SET_DATA("WE_SN_UPDATE");
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

        private void dateEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (checkEdit1.Checked)
            {
                return;
            }
            if (_Ticket_Info["PANEL_ID_IS_SN"].ToString() == "Y")
            {
                textEdit7.EditValue = _Panel_No.ToUpper();
                return;
            }

            string YY = string.Format("{0:yy}", dateEdit1.EditValue);
            string W;
            int SEQ;

            CultureInfo cul = CultureInfo.CurrentCulture;

            int weekNum = cul.Calendar.GetWeekOfYear(
                (DateTime)dateEdit1.EditValue,
                CalendarWeekRule.FirstDay,
                DayOfWeek.Sunday);

            W = weekNum.ToString().PadLeft(2, '0');
            W += _Ticket_Info["DELPHI_YN"].ToString() == "Y" ? "G" : "";

            SEQ = _Ticket_Info["MODEL_SEQ"].ToString() == "" ? 1 : (int)_Ticket_Info["MODEL_SEQ"] + 1;

            textEdit1.Text = _Ticket_Info["SN_MODEL"].ToString();
            textEdit2.Text = _Ticket_Info["PANEL_TYPE"].ToString();
            textEdit3.Text = _Ticket_Info["REVISION"].ToString();
            textEdit4.Text = _Ticket_Info["MODEL_GROUP"].ToString() != "SW" ? YY : "";
            textEdit5.Text = _Ticket_Info["MODEL_GROUP"].ToString() != "SW" ? W : "";

            int seq_length = 0;
            if (Int32.TryParse(_Ticket_Info["SEQ_LENGTH"].ToString(), out seq_length))
            {
                textEdit6.Text = SEQ.ToString().PadLeft((int)_Ticket_Info["SEQ_LENGTH"], '0');
            }

            textEdit7.EditValue = (textEdit1.Text + textEdit2.Text + textEdit3.Text + textEdit4.Text + textEdit5.Text + textEdit6.Text).ToUpper();
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            textEdit7.Enabled = checkEdit1.Checked;
        }
    }
}