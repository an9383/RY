using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using nsCommon;
using System;
using System.Data;
using System.Windows.Forms;

namespace RY_MES.Forms
{
    public partial class frm_Wafer_His_CSI_PopUp : frm_Base
    {
        private DataRow _Cell_Info;
        private string _Wafer_no;

        public frm_Wafer_His_CSI_PopUp(frm_Main frm_Main, DataRow Cell_Info, string Wafer_no)
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
            panelControl3.Controls.Clear();
           DataTable dt = new DataTable();
            _RYMES_DB._DB_Parameters.Add("@p_WAFER_NO", _Wafer_no);
            string sMsg = _RYMES_DB.GET_DATA("WE_WAFER_HIS_LOAD", ref dt);
            if (string.IsNullOrEmpty(sMsg))
            {
                ucGridControl1.DataSource = dt;

                foreach (DataRow dr in dt.Rows)
                {
                    if(dr["HIS_CODE"].ToString() == "L")
                    {
                        string[] sLocation = dr["HIS_DESC"].ToString().Split(',');
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
                                    Text = dr["SEQ"].ToString(),
                                    Tag = dr["SEQ"],
                                    Font = new System.Drawing.Font("Tahoma", 12F)
                                };
                                label.MouseDown += label_MouseDown;
                                panelControl3.Controls.Add(label);
                            }
                        }
                    }
                }
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

        private void panelControl3_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (DialogResult.Yes == MessageBox.Show("저장 하시겠습니까?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    _RYMES_DB._DB_Parameters.Add("@p_WAFER_NO", _Wafer_no);
                    _RYMES_DB._DB_Parameters.Add("@p_HIS_CODE", "L");
                    _RYMES_DB._DB_Parameters.Add("@p_HIS_DESC", (e.X - 6).ToString() + "," + (e.Y - 10).ToString());
                    _RYMES_DB._DB_Parameters.Add("@p_CELL_CODE", _Cell_Info["CELL_CODE"]);
                    _RYMES_DB._DB_Parameters.Add("@p_CREATE_USER", _Cell_Info["WORKER"].ToString() == "" ? _Main._User_Info["USER_CODE"].ToString() : _Cell_Info["WORKER"].ToString());

                    string sMsg = _RYMES_DB.SET_DATA("WE_WAFER_HIS_INSERT");
                    if (string.IsNullOrEmpty(sMsg))
                    {
                        //MessageBox.Show("Save Success", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(sMsg, "DB ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    Get_Data_Grid();
                }
            }

        }

        private void label_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                if (DialogResult.Yes == MessageBox.Show("삭제 하시겠습니까?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    _RYMES_DB._DB_Parameters.Add("@p_WAFER_NO", _Wafer_no);
                    _RYMES_DB._DB_Parameters.Add("@p_SEQ", Convert.ToInt32((sender as Control).Tag));
                    _RYMES_DB._DB_Parameters.Add("@p_CREATE_USER", _Cell_Info["WORKER"].ToString() == "" ? _Main._User_Info["USER_CODE"].ToString() : _Cell_Info["WORKER"].ToString());

                    string sMsg = _RYMES_DB.SET_DATA("WE_WAFER_HIS_DELETE");
                    if (string.IsNullOrEmpty(sMsg))
                    {
                        //MessageBox.Show("Save Success", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(sMsg, "DB ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    Get_Data_Grid();
                }
            }
        }
    }
}