using DevExpress.Utils.Menu;
using DevExpress.XtraGrid.Menu;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraReports.UI;
using DevExpress.XtraSplashScreen;
using nsCommon;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace RY_MES.Forms
{
    public partial class frm_QC_DOC_List : RY_MES.frm_Base
    {
        private string _template_type = "0001";
        private bool _CorS;

        public frm_QC_DOC_List()
        {
            InitializeComponent();
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            _RYMES_DB = _Main._RYMES_DB;

            pnl_Conditions.Visible = true;
            btn_Conditions.Visible = false;

            Get_Data_Grid(gridControl);
            
            ucGridView1.PopupMenuShowing += gridView_PopupMenuShowing;
            ucGridView1.MouseDown += gridView_MouseDown;
            ucGridView1.DoubleClick += gridView_DoubleClick;
            ucGridView1.KeyDown += ucGridView1_KeyDown;
            ucGridView1.KeyUp += ucGridView1_KeyUp;
        }

        private void Get_Data_Grid(ucGridControl grid)
        {
            ucGridView view = grid.MainView as ucGridView;

            SplashScreenManager.ShowForm(_Main, typeof(frm_Wait), true, true, false);
            try
            {
                DataTable dt = new DataTable();

                _RYMES_DB._DB_Parameters.Add("@p_To", de_To.Text);
                _RYMES_DB._DB_Parameters.Add("@p_From", de_From.Text);
                _RYMES_DB._DB_Parameters.Add("@p_TEMPLATE_TYPE", _template_type);

                string sMsg = _RYMES_DB.GET_DATA("QM_CA_QC_DOC_LIST_LOAD", ref dt);

                if (string.IsNullOrEmpty(sMsg))
                {
                    grid.DataSource = dt;
                    view.CheckBox_Column_Add();
                }
                else
                {
                    grid.DataSource = null;
                }

                RestoreLayout(this, view);
            }
            finally
            {
                SplashScreenManager.CloseForm(false);
                grid.Focus();
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

            item = new DXMenuItem("Refresh", null, Properties.Resources.refresh_16x16);
            item.Click += (o, args) =>
            {
                Get_Data_Grid(gridControl);
            };
            e.Menu.Items.Add(item);

            item = new DXMenuItem("Export", null, Properties.Resources.exporttoxlsx_16x16);
            item.Click += (o, args) =>
            {
                gridControl.Grid_Export();
            };
            e.Menu.Items.Add(item);
        }

        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            GridView view = sender as GridView;
            view.SelectRow(view.FocusedRowHandle);

            if (view.FocusedRowHandle > -1)
            {
                DataRow dr = view.GetFocusedDataRow();
                string ticket_id = dr["TICKET_ID"].ToString();
                string fa_id = dr["FA_ID"].ToString();
                string template_type = _template_type;
                string wafer_no = dr["WAFER_NO"].ToString();

                frm_Approval_Popup popup = new frm_Approval_Popup(ticket_id, fa_id, template_type, wafer_no);

                popup.ShowDialog();
                Get_Data_Grid(gridControl);
            }
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            Get_Data_Grid(gridControl);
        }

        private void btn_PDF_Download_Click(object sender, EventArgs e)
        {
            ucGridView view = ucGridView1;

            if (view.SelectedRowsCount <= 0)
            {
                MessageBox.Show("다운로드하실 런시트를 선택해주세요.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            SplashScreenManager.ShowForm(_Main, typeof(frm_Wait), true, true, false);
            try
            {
                XtraReport report = new XtraReport();

                foreach (int rowHandle in view.GetSelectedRows())
                {
                    DataRow dr = view.GetDataRow(rowHandle);
                    DataSet ds = new DataSet();
                    _RYMES_DB._DB_Parameters.Add("@p_TICKET_ID", dr["TICKET_ID"]);
                    _RYMES_DB._DB_Parameters.Add("@p_TEMPLATE_TYPE", "0001");
                    _RYMES_DB._DB_Parameters.Add("@p_WAFER_NO", dr["WAFER_NO"]);

           
                    string sMsg = _RYMES_DB.GET_DATA("QM_CA_QC_PRODUCT_REPORT" + "_" + dr["FA_ID"].ToString(), ref ds);

                    if (!string.IsNullOrEmpty(sMsg))
                    {
                        MessageBox.Show("DB Error", sMsg, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    XtraReport report_temp = null;

                    if (dr["FA_ID"].ToString() == "CMOS")
                    {
                        report_temp = new QC_CMOS_REPORT(ds);
                        
                    }
                    else if (dr["FA_ID"].ToString() == "TFT")
                    {
                        report_temp = new QC_TFT_REPORT(ds);
                    }
                    else if (dr["FA_ID"].ToString() == "CSI")
                    {
                        report_temp = new QC_CSI_REPORT(ds);
                    }

                    if (report_temp != null)
                    {
                        report_temp.CreateDocument();
                        report.ModifyDocument(x =>
                        {
                            x.AddPages(report_temp.Pages);
                        });
                    }                    
                }

                if (report.Pages.Count > 0)
                {
                    using (SaveFileDialog saveDialog = new SaveFileDialog())
                    {
                        saveDialog.Filter = "Pdf File (.pdf)|*.pdf ";
                        saveDialog.FileName = DateTime.Now.ToShortDateString() + "_" + gridControl.Text;

                        if (saveDialog.ShowDialog() != DialogResult.Cancel)
                        {
                            string exportFilePath = saveDialog.FileName;
                            string fileExtenstion = new FileInfo(exportFilePath).Extension;

                            report.ExportToPdf(exportFilePath);

                            if (File.Exists(exportFilePath))
                            {
                                try
                                {
                                    //Try to open the file and let windows decide how to open it.
                                    System.Diagnostics.Process.Start(exportFilePath);
                                }
                                catch
                                {
                                    string msg = "The file could not be opened." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                                    MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                string msg = "The file could not be saved." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                                MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("출력 가능한 런시트가 없습니다.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "DB Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SplashScreenManager.CloseForm(false);
            }
        }


        private void ucGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            _CorS = e.Shift || e.Control;
        }
        private void ucGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            _CorS = e.Shift || e.Control;
        }

        private void gridView_MouseDown(object sender, MouseEventArgs e)
        {
            GridHitInfo info = (sender as GridView).CalcHitInfo(e.Location);

            if (!(info.Column is null) && info.Column.Caption != "Selection" && !_CorS)
            {
                GridView view = sender as GridView;
                view.ClearSelection();
            }
        }
    }
}