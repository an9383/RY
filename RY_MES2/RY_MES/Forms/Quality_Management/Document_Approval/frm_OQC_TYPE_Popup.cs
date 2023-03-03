using DevExpress.XtraReports.UI;
using DevExpress.XtraSplashScreen;
using nsCommon;
using System;
using System.Data;
using System.Reflection;
using System.Windows.Forms;

namespace RY_MES.Forms
{
    public partial class frm_OQC_TYPE_Popup : RY_MES.frm_Base
    {
        public DataSet ds;
        private string _wafer_no = "";

        public frm_OQC_TYPE_Popup(params object[] paramArray)
        {
            TopLevel = true;
            InitializeComponent();

            if (paramArray[0] != null)
            {
                _wafer_no = paramArray[0].ToString();
            }

            ucGridView1.OptionsFind.AlwaysVisible = false;
            ucGridControl1.EmbeddedNavigator.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.None;
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            _RYMES_DB = _Main._RYMES_DB;

            pnl_Conditions.Visible = false;
            btn_Conditions.Visible = false;

            try
            {
                DataTable dt = new DataTable();

                _RYMES_DB._DB_Parameters.Add("@p_WAFER_NO", _wafer_no);
                string sMsg = _RYMES_DB.GET_DATA("QM_CA_OQC_TYPE_LOAD", ref dt);

                if (string.IsNullOrEmpty(sMsg))
                {
                    ucGridControl1.DataSource = dt;

                    ucGridView1.CheckBox_Column_Add();
                    ucGridView1.Columns["OQC_TYPE"].Caption = "성적서 타입";
                    ucGridView1.Columns["DESC1"].Visible = false;
                    ucGridView1.BestFitColumns();
                }
                else
                {
                    MessageBox.Show(sMsg, "Occur Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Occur Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                this.Dispose();
            }

        }

        private void btn_Load_Click(object sender, EventArgs e)
        {
            if (ucGridView1.SelectedRowsCount < 1)
            {
                MessageBox.Show("1개 이상의 성적서 양식을 선택해주세요.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string oqc_types = "";

            int[] selectedRowsHandle = ucGridView1.GetSelectedRows();
            for (int i = 0; i < selectedRowsHandle.Length; i++)
            {
                int rowhandle = selectedRowsHandle[i];
                DataRow dr = ucGridView1.GetDataRow(rowhandle);

                oqc_types += dr["DESC1"].ToString() + ',';
            }

            frm_OQC_DOC_List_TFT frm_OQC_DOC_List_TFT = (frm_OQC_DOC_List_TFT)Owner;

            frm_OQC_DOC_List_TFT._oqc_types = oqc_types;
            this.DialogResult = DialogResult.OK;
            this.Close();
            this.Dispose();

        }
    }
}