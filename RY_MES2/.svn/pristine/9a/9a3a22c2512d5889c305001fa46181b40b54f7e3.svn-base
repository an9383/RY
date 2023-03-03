using DevExpress.XtraSplashScreen;
using nsCommon;
using System;
using System.Data;
using System.Windows.Forms;

namespace RY_MES.Forms
{
    public partial class frm_Wafer_Hist_PopUp : frm_Base
    {
        private DataRow _Cell_Info;
        private string _Wafer_no;

        public frm_Wafer_Hist_PopUp(frm_Main frm_Main, DataRow Cell_Info, string Wafer_no)
        {
            InitializeComponent();

            init_PopUp();

            _Main = frm_Main;
            _RYMES_DB = _Main._RYMES_DB;
            _Cell_Info = Cell_Info;
            _Wafer_no = Wafer_no;
        }

        private void frm_Load(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(_Main, typeof(frm_Wait), true, true, false);
            try
            {
                SET_LookUpEdit_Data(lookUpEdit1, "HIS_CODE");
                Get_Data_Grid();
            }
            finally
            {
                //Close Wait Form
                SplashScreenManager.CloseForm(false);
                ucGridControl1.Focus();
            }
        }

        private void Get_Data_Grid()
        {
            DataTable dt = new DataTable();
            _RYMES_DB._DB_Parameters.Add("@p_WAFER_NO", _Wafer_no);
            string sMsg = _RYMES_DB.GET_DATA("WE_WAFER_HIS_LOAD", ref dt);
            if (string.IsNullOrEmpty(sMsg))
            {
                ucGridControl1.DataSource = dt;
            }
            else
            {
                if (sMsg == "Result FirstTable Rows Count is Zero")
                {
                    ucGridControl1.DataSource = dt;
                }
                else
                {
                    MessageBox.Show(sMsg, "DB ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return;
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (lookUpEdit1.EditValue is null)
            {
                MessageBox.Show(" 구분이 선택되지 않았습니다.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _RYMES_DB._DB_Parameters.Add("@p_WAFER_NO", _Wafer_no);
            _RYMES_DB._DB_Parameters.Add("@p_HIS_CODE", lookUpEdit1.EditValue);
            _RYMES_DB._DB_Parameters.Add("@p_HIS_DESC", textBox1.Text);
            _RYMES_DB._DB_Parameters.Add("@p_CELL_CODE", _Cell_Info["CELL_CODE"]);
            _RYMES_DB._DB_Parameters.Add("@p_CREATE_USER", _Cell_Info["WORKER"].ToString() == "" ? _Main._User_Info["USER_CODE"].ToString() : _Cell_Info["WORKER"].ToString());

            string sMsg = _RYMES_DB.SET_DATA("WE_WAFER_HIS_INSERT");
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
    }
}