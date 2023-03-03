using DevExpress.DataAccess.Excel;
using DevExpress.SpreadsheetSource;
using DevExpress.Utils.Menu;
using DevExpress.XtraGrid.Menu;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using nsCommon;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace RY_MES.Forms
{
    public partial class frm_FT_Upload : RY_MES.frm_Base
    {
        public frm_FT_Upload()
        {
            InitializeComponent();
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            _RYMES_DB = _Main._RYMES_DB;

            pnl_Conditions.Visible = false;
            btn_Conditions.Visible = false;
        }

        private void Get_Data_Grid(ucGridControl grid)
        {
            ucGridView view = (grid.MainView as ucGridView);
            SplashScreenManager.ShowForm(_Main, typeof(frm_Wait), true, true, false);
            SplashScreenManager.Default.SetWaitFormCaption("입력 대상을 조회하고 있습니다. 잠시만 기다려주세요.");
            try
            {
                DataTable dt = new DataTable();

                string sMsg = _RYMES_DB.GET_DATA("QM_DEFECT_MONITORING_LOAD", ref dt);

                if (string.IsNullOrEmpty(sMsg))
                {
                    grid.DataSource = dt;

                    view.Set_Column_Type("DEFECT_DATE", ucGridView.Col_Type.DateTime);
                }
                else
                {
                    grid.DataSource = null;
                }

                RestoreLayout(this, (grid.MainView as ucGridView));
            }
            finally
            {
                SplashScreenManager.CloseForm(false);
            }
        }

        private void gridView_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            GridView view = sender as GridView;
            DXMenuItem item;

            if (e.Menu == null)
            {
                e.Menu = new GridViewMenu(view);
            }

            item = new DXMenuItem("Export", null, Properties.Resources.exporttoxlsx_16x16);
            item.Click += (o, args) =>
            {
                ucGridControl1.Grid_Export();
            };
            e.Menu.Items.Add(item);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = string.Empty;
                string fileExt = string.Empty;
                OpenFileDialog file = new OpenFileDialog(); //open dialog to choose file
                if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK) //if there is a file choosen by the user
                {
                    filePath = file.FileName; //get the path of the file
                    fileExt = Path.GetExtension(filePath); //get the file extension

                    if (fileExt.CompareTo(".csv") == 0 || fileExt.CompareTo(".xlsx") == 0)
                    {
                        lbl_filePath.Text = filePath;
                    }
                    else
                    {
                        MessageBox.Show("Please choose .csv file only.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error); //custom messageBox to show error
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERROR");
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            string part = "";
            int equip = 1;

            if (rg_PART.EditValue is null)
            {
                MessageBox.Show("파트를 선택해주세요.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                part = rg_PART.EditValue.ToString();
            }

            if (rg_PART.EditValue.ToString() == "IOS" && rg_EQUIP.EditValue is null)
            {
                MessageBox.Show("업로드 할 데이터를 추출한 장비를 선택해주세요.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (rg_PART.EditValue.ToString() == "IOS" && !(rg_EQUIP.EditValue is null))
            {
                equip = Convert.ToInt16(rg_EQUIP.EditValue);
            }

            if (string.IsNullOrEmpty(lbl_filePath.Text))
            {
                MessageBox.Show("업로드 할 데이터 파일을 선택해주세요.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string key = "";
            string keys = "";
            try
            {
                SplashScreenManager.ShowForm(_Main, typeof(frm_Wait), true, true, false);
                RemoveBlankRowsFromCVSFile(lbl_filePath.Text);

                Filehandle fh = new Filehandle(lbl_filePath.Text);

                string[] rows = fh.TextFileReadLine();

                //key (Wafer No or Serial No) 가 있는 col 찾기
                int keyCol = 0;

                string[] cells = rows[0].Split(',');

                for (int i = 0; i < cells.Length; i++)
                {
                    if (cells[i].Trim().Equals("WaferNo") || cells[i].Trim().Equals("Barcode"))
                    {
                        keyCol = i;
                        key = "wafer";
                        break;
                    }
                    else if (cells[i].Trim().Equals("SerialNo"))
                    {
                        keyCol = i;
                        key = "serial";
                        break;
                    }
                }

                //keyCol (Wafer No or Serial No) 뽑기
                int startRow = 1;

                for (int i = 1; i < rows.Length; i++)
                {
                    if (rows.Contains("Spec") || rows.Contains("spec"))
                    {
                        startRow++;
                    }
                    else
                    {
                        keys += rows[i].Split(',')[keyCol].Trim() + ",";
                    }
                }

                progressBarControl1.Properties.Maximum = rows.Length - startRow;
                progressBarControl1.Position = 0;
                labelControl1.Text = progressBarControl1.Position.ToString() + " / " + progressBarControl1.Properties.Maximum.ToString();

                labelControl1.Refresh();

                //wafer_no, value_id, display_area 불러오기
                DataTable dt = new DataTable();

                _RYMES_DB._DB_Parameters.Add("@p_KEY", key);
                _RYMES_DB._DB_Parameters.Add("@p_KEYS", keys);
                string sMsg = _RYMES_DB.GET_DATA("FT_CHK_VALUE_LOAD", ref dt);

                SplashScreenManager.CloseForm(false);

                if (!string.IsNullOrEmpty(sMsg))
                {
                    MessageBox.Show(sMsg, "DB Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string ErrorMsg = "";

                //csv 데이터 돌면서...값 찾아서 하나씩 집어넣기
                for (int i = startRow; i < rows.Length; i++)
                {
                    _RYMES_DB._DB_Parameters.Add("@p_DATA", rows[i]);
                    _RYMES_DB._DB_Parameters.Add("@p_CREATE_USER", _Main._User_Info["USER_CODE"]);
                    _RYMES_DB.SET_DATA("FT_CSV_INSERT");

                    string[] cell = rows[i].Split(',');
                    string key_no = cell[keyCol].Trim();

                    progressBarControl2.Properties.Maximum = dt.Select((key == "wafer" ? "WAFER_NO = '" : "PRODUCT_SN = '") + key_no + "'").Length;
                    progressBarControl2.Position = 0;
                    labelControl2.Text = progressBarControl2.Position.ToString() + " / " + progressBarControl2.Properties.Maximum.ToString();

                    labelControl2.Refresh();
                    progressBarControl2.Refresh();

                    foreach (DataRow dr in dt.Select((key == "wafer" ? "WAFER_NO = '" : "PRODUCT_SN = '") + key_no + "'"))
                    {
                        string[] display_areas = dr["DISPLAY_AREA"].ToString().ToUpper().Split('/');
                        string display_area = display_areas[equip - 1].Trim();     //////////////error

                        int col = 0;

                        if (display_area.Length == 1)
                        {
                            char c = display_area[0];
                            col = Convert.ToInt32(c) - 65;
                        }
                        else if (display_area.Length == 2)
                        {
                            char c1 = display_area[0];
                            col = (Convert.ToInt32(c1) - 64) * 26;

                            char c2 = display_area[1];
                            col += Convert.ToInt32(c2) - 65;
                        }

                        _RYMES_DB._DB_Parameters.Add("@p_VALUE_ID", dr["VALUE_ID"]);
                        _RYMES_DB._DB_Parameters.Add("@p_VALUE_RESULT", cell[col]);
                        _RYMES_DB._DB_Parameters.Add("@p_CREATE_USER", _Main._User_Info["USER_CODE"]);

                        //DataTable tmp = new DataTable();
                        sMsg = _RYMES_DB.SET_DATA("IF_FT_CHK_VALUE_MERGE");

                        if (!string.IsNullOrEmpty(sMsg))
                        {
                            MessageBox.Show(sMsg, "DB Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            ErrorMsg += (key == "wafer" ? "WAFER_NO = '" : "SERIAL_NO = '") + key_no + " / display area : " + display_area + "\n";
                        }
                        progressBarControl2.Position++;
                        labelControl2.Text = progressBarControl2.Position.ToString() + " / " + progressBarControl2.Properties.Maximum.ToString();

                        labelControl2.Refresh();
                        progressBarControl2.Refresh();
                    }

                    progressBarControl1.Position++;
                    labelControl1.Text = progressBarControl1.Position.ToString() + " / " + progressBarControl1.Properties.Maximum.ToString();

                    labelControl1.Refresh();
                    progressBarControl1.Refresh();
                }

                SplashScreenManager.CloseForm(false);

                if (!string.IsNullOrEmpty(ErrorMsg))
                {
                    MessageBox.Show(ErrorMsg, "DB Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                SplashScreenManager.CloseForm(false);
                MessageBox.Show(ex.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(keys))
                {
                    DataTable dt = new DataTable();
                    
                    _RYMES_DB._DB_Parameters.Add("@p_KEY", key);
                    _RYMES_DB._DB_Parameters.Add("@p_KEYS", keys);
                    string sMsg = _RYMES_DB.GET_DATA("FT_SPEC_OUT_CHK_VALUE_LOAD", ref dt);

                    if (string.IsNullOrEmpty(sMsg))
                    {
                        DataTable dt2 = dt.Clone();

                        foreach (DataRow dr in dt.Rows)
                        {
                            if (!string.IsNullOrEmpty(dr["SPEC"].ToString()))
                            {
                                bool spec_out = false;
                                string spec = dr["SPEC"].ToString();
                                string value = dr["VALUE_RESULT"].ToString();

                                if (spec == "0")
                                {
                                    spec_out = value == "0" ? false : true;
                                }
                                else if (spec.IndexOf(">") >= 0)
                                {
                                    spec_out = Convert.ToDecimal(value) > Convert.ToDecimal(spec.Replace(">", "")) ? false : true;
                                }
                                else if (spec.IndexOf("≥") >= 0)
                                {
                                    spec_out = Convert.ToDecimal(value) >= Convert.ToDecimal(spec.Replace("≥", "")) ? false : true;
                                }
                                else if (spec.IndexOf("≤") >= 0)
                                {
                                    spec_out = Convert.ToDecimal(value) <= Convert.ToDecimal(spec.Replace("≤", "")) ? false : true;
                                }
                                else if (spec.IndexOf("<") >= 0)
                                {
                                    spec_out = Convert.ToDecimal(value) < Convert.ToDecimal(spec.Replace("<", "")) ? false : true;
                                }
                                else if (spec.IndexOf("~") >= 0)
                                {
                                    string[] split = spec.Split('~');

                                    spec_out = Convert.ToDecimal(split[0]) <= Convert.ToDecimal(value)
                                                && Convert.ToDecimal(value) <= Convert.ToDecimal(split[1]) ? false : true;
                                }

                                if (spec_out)
                                {
                                    dt2.Rows.Add(dr.ItemArray);
                                }
                            }
                        }

                        ucGridControl2.DataSource = dt2;
                    }
                    else
                    {
                        ucGridControl2.DataSource = null;
                    }
                }
                else
                {
                    ucGridControl2.DataSource = null;
                }
                ucGridView2.BestFitColumns();
            }
        }

        public void RemoveBlankRowsFromCVSFile(string filepath)
        {
            if (filepath == null || filepath.Length == 0)
            {
                throw new ArgumentNullException("filepath");
            }

            if (!File.Exists(filepath))
            {
                throw new FileNotFoundException("Could not find CVS file.", filepath);
            }

            String tempFile = Path.GetTempFileName();

            using (StreamReader reader = new StreamReader(filepath))
            using (StreamWriter writer = new StreamWriter(tempFile))
            {
                String line = null;

                while ((line = reader.ReadLine()) != null)
                {
                    if (!String.IsNullOrWhiteSpace(line.Replace(',', ' ')))
                    {
                        writer.WriteLine(line);
                    }
                }
            }

            File.Delete(filepath);
            File.Move(tempFile, filepath);
        }

        private void rg_PART_EditValueChanged(object sender, EventArgs e)
        {
            if (rg_PART.EditValue.ToString() == "IOS")
            {
                rg_EQUIP.Enabled = true;
            }
            else
            {
                rg_EQUIP.Enabled = false;
            }
        }

        private void control_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Search_Click(null, null);
            }
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_WAFER_NO.Text))
            {
                MessageBox.Show("Info", "조회 할 wafer no를 입력해주세요.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataTable dt = new DataTable();

            try
            {
                _RYMES_DB._DB_Parameters.Add("@p_WAFER_NO", txt_WAFER_NO.Text);
                string sMsg = _RYMES_DB.GET_DATA("FT_WAFER_CHK_VALUE_LOAD", ref dt);

                if (string.IsNullOrEmpty(sMsg))
                {
                    ucGridControl1.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("DB Error", sMsg, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error", ex.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}