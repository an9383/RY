using DevExpress.Xpo.DB.Helpers;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Filtering;
using DevExpress.XtraSplashScreen;
using System;
using System.Data;
using System.Windows.Forms;
using VTMES3_RE.Common;
namespace VTMES3_RE.View.WorkManager
{
    public partial class frm_Wafer_His_CSI_PopUp : DevExpress.XtraEditors.XtraForm
    {
        private string _Wafer_no = "";
        string _query = "";
        Database db = new Database();

        public frm_Wafer_His_CSI_PopUp()
        {
            InitializeComponent();
        }

        private void frmWaferHisCSIPopUp_Load(object sender, EventArgs e)
        {
            try
            {
                Get_Description();
                SET_LookUpEdit_Data(cellSearch, "CELL_MASTER", null);
                SET_LookUpEdit_Data(lookUpEdit1, "HIS_CODE", null);

            }
            finally
            {
                //Close Wait Form
                //SplashScreenManager.CloseForm(false);
                ucGridControl1.Focus();
            }
        }


        public void Get_Description()
        {
            _query = string.Format("Select * From IFRY.dbo.MES2_v_DESCRIPTION");
            WrGlobal.dt_Description = db.GetDataView("COL_DESCRIPTION", _query);
        }

        private void SET_LookUpEdit_Data(LookUpEditBase lookUpEdit, string Group_Code, string Option)
        {
            _query = string.Format("exec IFRY.dbo.MES2_SYS_CODE_LOAD '{0}', ''", Group_Code);
            lookUpEdit.Properties.DataSource = db.GetDataView("SYS_CODE_LOAD", _query);
            lookUpEdit.Properties.DisplayMember = "코드명";
            lookUpEdit.Properties.ValueMember = "코드";
        }


        private void Get_Data_Grid()
        {
            panelControl3.Controls.Clear();

            _query = string.Format("exec IFRY.dbo.MES2_WE_WAFER_HIS_LOAD '{0}'", _Wafer_no);

            DataView dv = db.GetDataView("WE_WAFER_HIS_LOAD", _query);
            ucGridControl1.DataSource = dv;
            ucGridView1.BestFitColumns();

            foreach (DataRowView drv in dv)
            {
                if (drv["HIS_CODE"].ToString() == "L")
                {
                    string[] sLocation = drv["HIS_DESC"].ToString().Split(',');
                    if (sLocation.Length == 2)
                    {
                        int x;
                        int y;
                        if (int.TryParse(sLocation[0], out x) && int.TryParse(sLocation[1], out y))
                        {
                            LabelControl label = new LabelControl
                            {
                                Location = new System.Drawing.Point(x, y),
                                Name = "labelControl1",
                                Size = new System.Drawing.Size(6, 14),
                                TabIndex = 0,
                                Text = drv["SEQ"].ToString(),
                                Tag = drv["SEQ"],
                                Font = new System.Drawing.Font("Tahoma", 12F)
                            };
                            label.MouseDown += label_MouseDown;
                            panelControl3.Controls.Add(label);
                        }
                    }
                }
            }

        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (_Wafer_no == "") return;

            if (lookUpEdit1.EditValue is null)
            {
                MessageBox.Show(" 구분이 선택되지 않았습니다.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _query = string.Format("exec IFRY.dbo.MES2_WE_WAFER_HIS_INSERT '{0}', '{1}', N'{2}', '{3}', '{4}'"
                                    , _Wafer_no
                                    , lookUpEdit1.EditValue
                                    , textBox1.Text
                                    , cellSearch.EditValue
                                    , WrGlobal.LoginID);

            if (db.ExecuteQuery(_query))
            {
                MessageBox.Show("Save Success", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Save Error", "DB ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //DialogResult = DialogResult.OK;
            //Close();

            Get_Data_Grid();
        }

        private void panelControl3_MouseDown(object sender, MouseEventArgs e)
        {
            if (_Wafer_no == "") return;

            if (e.Button == MouseButtons.Left)
            {
                if (DialogResult.Yes == MessageBox.Show("저장 하시겠습니까?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    _query = string.Format("exec IFRY.dbo.MES2_WE_WAFER_HIS_INSERT '{0}', '{1}', '{2}', '{3}', '{4}'"
                                        , _Wafer_no
                                        , "L"
                                        , (e.X - 6).ToString() + "," + (e.Y - 10).ToString()
                                        , cellSearch.EditValue
                                        , WrGlobal.LoginID);

                    if (db.ExecuteQuery(_query))
                    {
                        MessageBox.Show("Save Success", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Save Error", "DB ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    Get_Data_Grid();
                }
            }
        }

        private void label_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (DialogResult.Yes == MessageBox.Show("삭제 하시겠습니까?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    _query = string.Format("exec IFRY.dbo.MES2_WE_WAFER_HIS_DELETE '{0}', {1}, '{2}'"
                                        , _Wafer_no
                                        , Convert.ToInt32((sender as Control).Tag)
                                        , WrGlobal.LoginID);

                    if (db.ExecuteQuery(_query))
                    {
                        //MessageBox.Show("Save Success", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Delete Error", "DB ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    Get_Data_Grid();
                }
            }
        }

        private void waferNoText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                _Wafer_no = waferNoText.Text;
                Get_Data_Grid();
            }
        }
    }
}