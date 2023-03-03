using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace RY_MES.Forms
{
    public partial class frm_Check_Sheet_Input_P_PopUp : frm_Base
    {
        private DataRow _Cell_Info;
        private DataRow _Check_Ieem;

        public frm_Check_Sheet_Input_P_PopUp(frm_Main frm_Main, DataRow Cell_Info, DataRow Check_Ieem)
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
            DataTable dt = new DataTable();

            _RYMES_DB._DB_Parameters.Add("@p_FILE_ID", _Check_Ieem["VALUE_RESULT"]);

            string sMsg = _RYMES_DB.SET_DATA("WE_CHK_VALUE_FILE_LOAD", ref dt);

            if (string.IsNullOrEmpty(sMsg))
            {
                if (dt.Rows.Count > 0)
                {
                    MemoryStream ms = new MemoryStream((byte[])dt.Rows[0]["DATA"]);
                    pictureEdit1.Image = Image.FromStream(ms);
                }
            }
            else
            {
                MessageBox.Show(sMsg, "DB ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            byte[] byteImage = (byte[])new ImageConverter().ConvertTo(pictureEdit1.Image, typeof(byte[]));

            _RYMES_DB._DB_Parameters.Add("@p_VALUE_ID", _Check_Ieem["VALUE_ID"]);
            _RYMES_DB._DB_Parameters.Add("@p_VALUE_RESULT", "");
            _RYMES_DB._DB_Parameters.Add("@p_VALUE_RESULT_NAME", "");
            _RYMES_DB._DB_Parameters.Add("@p_CREATE_USER", _Cell_Info["WORKER"].ToString() == "" ? _Main._User_Info["USER_CODE"].ToString() : _Cell_Info["WORKER"].ToString());
            _RYMES_DB._DB_Parameters.Add("@p_IMAGE", byteImage);

            string sMsg = _RYMES_DB.SET_DATA("WE_CHECK_SHEET_MERGE");

            if (string.IsNullOrEmpty(sMsg))
            {
                MessageBox.Show("Save Success", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(sMsg, "DB ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void pictureEdit1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)22)
            {
                pictureEdit1.PasteImage();
            }
        }
    }
}