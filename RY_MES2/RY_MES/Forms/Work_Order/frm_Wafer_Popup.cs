using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using nsCommon;
using System;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Windows.Forms;

namespace RY_MES.Forms
{
    public partial class frm_Wafer_Popup : RY_MES.frm_Base
    {
        private DataTable dt;
        private string _fa_id = "CMOS";

        public frm_Wafer_Popup(params object[] paramArray)
        {
            TopLevel = true;
            InitializeComponent();
            
            _fa_id = paramArray.Length == 0? _fa_id : paramArray[0].ToString();
            
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            _RYMES_DB = _Main._RYMES_DB;

            pnl_Conditions.Visible = false;
            btn_Conditions.Visible = false;

            dt = new DataTable();
            
            dt.Columns.Add("WAFER_NO");
            if (_fa_id != "CMOS")
            {
                this.Text = "Panel 등록";
                dt.Columns.Add("PRODUCT_SN");
                dt.Columns.Add("WAFER_DESC");
            }

            ucGridControl1.DataSource = dt;

            DataRow dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);


            ucGridView1.Columns["WAFER_NO"].Caption = _fa_id == "CMOS" ? "WAFER 번호": "Panel 번호";

            foreach (GridColumn col in ucGridView1.Columns)
            {
                col.OptionsColumn.AllowEdit = true;
                col.OptionsColumn.ReadOnly = false;
            }


            ucGridControl1.EditorKeyPress += gridControl1_EditorKeyPress;
            ucGridView1.KeyDown += gridView1_KeyDown;

            ucGridView1.OptionsFind.AlwaysVisible = false;
            ucGridView1.OptionsView.ShowGroupPanel = false;
            ucGridView1.OptionsCustomization.AllowFilter = false;
        }

        private void gridControl1_EditorKeyPress(object sender, KeyPressEventArgs e)
        {
            ucGridView view = (sender as ucGridControl).MainView as ucGridView;

            try
            {
                int frh = view.FocusedRowHandle;
                if (e.KeyChar == (char)22)
                {
                    string text = Clipboard.GetText();
                    string[] cs = Clipboard.GetText().Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                    
                    for (int i = 0; i < cs.Length; i++)
                    {
                        DataRow dr = dt.NewRow();
                        string[] cc = cs[i].Split('\t');

                        for (int j = 0; j < cc.Length && j < dt.Columns.Count; j++)
                        {
                            dr[j] = cc[j];
                        }

                        if (i == 0)
                        {
                            dt.Rows[frh].ItemArray = dr.ItemArray;
                        }
                        else
                        {
                            dt.Rows.InsertAt(dr, frh + i);
                        }                        
                    }

                    view.BestFitColumns();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            GridView view = sender as GridView;
            int frh = view.FocusedRowHandle;
            if (e.KeyCode == Keys.Delete && frh >= 0)
            {
                if (dt.Rows.Count != 1)
                {
                    dt.Rows.RemoveAt(frh);
                }
                else
                {
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        dt.Rows[0][i] = "";
                    }                    
                }
            }
            else if (e.KeyCode == Keys.Enter)
            {
                frh = frh < -1 ? -1 : frh;
                DataRow dr = dt.NewRow();
                dt.Rows.InsertAt(dr, frh + 1);
                
                view.FocusedRowHandle = frh + 1;
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(_Main, typeof(frm_Wait), true, true, false);

            DbTransaction trans = _RYMES_DB._Connection.BeginTransaction();

            string sMsg = "";

            try
            {
                for (int i = 0; i < ucGridView1.RowCount; i++)
                {
                    object wafer_no = ucGridView1.GetRowCellValue(i, "WAFER_NO");
                    if (!(wafer_no is null) && !string.IsNullOrWhiteSpace(wafer_no.ToString()))
                    {
                        _RYMES_DB._DB_Parameters.Add("@p_FA_ID", _fa_id);
                        _RYMES_DB._DB_Parameters.Add("@p_WAFER_NO", wafer_no.ToString().Trim());
                        if (_fa_id != "CMOS")
                        {
                            _RYMES_DB._DB_Parameters.Add("@p_PRODUCT_SN", ucGridView1.GetRowCellValue(i, "PRODUCT_SN").ToString().Trim());
                            _RYMES_DB._DB_Parameters.Add("@p_WAFER_DESC", ucGridView1.GetRowCellValue(i, "WAFER_DESC").ToString().Trim());
                        }
                        _RYMES_DB._DB_Parameters.Add("@p_CREATE_USER", _Main._User_Info["USER_CODE"].ToString());

                        sMsg = _RYMES_DB.SET_DATA("WO_WAFER_MASTER_INSERT", ref trans);
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
                SplashScreenManager.CloseForm(false);

                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}