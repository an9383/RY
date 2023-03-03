using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using DevExpress.XtraReports.UI;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using nsCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace RY_MES
{
    public partial class frm_Base : XtraForm
    {
        public object[] _Parameters { get; set; }
        public frm_Main _Main = Program._Main;
        public DbHandle _RYMES_DB { get; set; }



        public frm_Base()
        {
            InitializeComponent();

            // Set the value of the double-buffering style bits to true.
            this.SetStyle(ControlStyles.DoubleBuffer |
               ControlStyles.UserPaint |
               ControlStyles.AllPaintingInWmPaint,
               true);
            this.UpdateStyles();

            TopLevel = false;

            DateTime toDay = DateTime.Now;
            de_From.EditValue = new DateTime(toDay.Year, toDay.Month, 1);
            de_To.EditValue = toDay;
        }

        protected void init_PopUp()
        {
            TopLevel = true;
            ControlBox = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            StartPosition = FormStartPosition.CenterParent;
            TopMost = true;
            pnl_Conditions.Visible = false;
            btn_Conditions.Visible = false;
        }

        public object Get_Edit_Control_Value(BaseEdit control)
        {
            return control.EditValue;
        }

        public void Set_Edit_Control(BaseEdit control, object value)
        {
            control.EditValue = value;
        }

        public string SET_LookUpEdit_Data(LookUpEdit lookUpEdit, string Group_Code)
        {
            return SET_LookUpEdit_Data((LookUpEditBase)lookUpEdit, Group_Code, null);
        }

        public string SET_LookUpEdit_Data(LookUpEdit lookUpEdit, string Group_Code, string Option)
        {
            return SET_LookUpEdit_Data((LookUpEditBase)lookUpEdit, Group_Code, Option);
        }

        public string SET_LookUpEdit_Data(GridLookUpEdit gridLookUpEdit, string Group_Code)
        {
            return SET_LookUpEdit_Data((LookUpEditBase)gridLookUpEdit, Group_Code, null);
        }

        public string SET_LookUpEdit_Data(GridLookUpEdit gridLookUpEdit, string Group_Code, string Option)
        {
            return SET_LookUpEdit_Data((LookUpEditBase)gridLookUpEdit, Group_Code, Option);
        }

        public string SET_LookUpEdit_Data(SearchLookUpEdit searchLookUpEdit, string Group_Code)
        {
            return SET_LookUpEdit_Data((LookUpEditBase)searchLookUpEdit, Group_Code, null);
        }

        public string SET_LookUpEdit_Data(SearchLookUpEdit searchLookUpEdit, string Group_Code, string Option)
        {
            return SET_LookUpEdit_Data((LookUpEditBase)searchLookUpEdit, Group_Code, Option);
        }

        public string SET_LookUpEdit_Data(LookUpEditBase lookUpEdit, string Group_Code, string Option)
        {
            DataSet ds_lookup = new DataSet();

            _RYMES_DB._DB_Parameters.Add("@p_GROUP_CODE", Group_Code);
            _RYMES_DB._DB_Parameters.Add("@p_OPTION", _Main._User_Info["FA_ID"].ToString() + "," + Option);

            string sMsg = _RYMES_DB.GET_DATA("SYS_CODE_LOAD", ref ds_lookup);
            if (string.IsNullOrEmpty(sMsg))
            {
                lookUpEdit.Properties.DataSource = ds_lookup.Tables[0];
                lookUpEdit.Properties.ValueMember = ds_lookup.Tables[0].Columns[0].ColumnName;
                int DisplayMember = ds_lookup.Tables[0].Columns.Count == 1 ? 0 : 1;
                lookUpEdit.Properties.DisplayMember = ds_lookup.Tables[0].Columns[DisplayMember].ColumnName;
                return null;
            }
            else
            {
                return sMsg;
            }
        }

        public Dictionary<string, object> Get_Conditions_Params(LayoutControlGroup layoutControl)
        {
            Dictionary<string, object> Params = new Dictionary<string, object>();
            foreach (LayoutControlItem item in layoutControl.Items)
            {
                if (!(item.Control is null))
                {
                    if (!(item.Control is SimpleButton) && item.Control is BaseEdit)
                    {
                        //Params.Add("@p_" + item.Control.Name, Get_Edit_Control_Value((BaseEdit)item.Control));
                        Params.Add("@p_" + item.Control.Name.Substring(item.Control.Name.IndexOf('_') + 1), Get_Edit_Control_Value((BaseEdit)item.Control));
                    }
                }
            }
            return Params;
        }

        public void Tree_Export(TreeList treeList)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Excel (.xlsx)|*.xlsx |Excel (.xls)|*.xls|RichText File (.rtf)|*.rtf |Pdf File (.pdf)|*.pdf |Html File (.html)|*.html";
                saveDialog.FileName = DateTime.Now.ToShortDateString() + "_" + treeList.Text;
                if (saveDialog.ShowDialog() != DialogResult.Cancel)
                {
                    string exportFilePath = saveDialog.FileName;
                    string fileExtenstion = new FileInfo(exportFilePath).Extension;

                    switch (fileExtenstion)
                    {
                        case ".xls":
                            treeList.ExportToXls(exportFilePath);
                            break;

                        case ".xlsx":
                            treeList.ExportToXlsx(exportFilePath);
                            break;

                        case ".rtf":
                            treeList.ExportToRtf(exportFilePath);
                            break;

                        case ".pdf":

                            treeList.AppearancePrint.HeaderPanel.Font = new Font("Arial Unicode MS", treeList.AppearancePrint.HeaderPanel.Font.Size);
                            treeList.AppearancePrint.Row.Font = new Font("Arial Unicode MS", treeList.AppearancePrint.Row.Font.Size);
                            treeList.ExportToPdf(exportFilePath);

                            break;

                        case ".html":

                            treeList.OptionsPrint.AutoWidth = false;
                            treeList.ExportToHtml(exportFilePath);
                            break;

                        default:
                            break;
                    }

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

        // FOR RESTORING
        public void RestoreLayout(frm_Base frm, ucGridView gridView)
        {
            FileInfo fileInfo = new FileInfo(@".\Setting\" + Name + "_" + gridView.GridControl.Name + "_" + gridView.Name + ".xml");
            //FileInfo fileInfo = new FileInfo(@".\Setting\" + frm.Text + "_" + gridView.GridControl.Name + "_" + gridView.Name + ".xml");
            if (fileInfo.Exists)
            {
                gridView.RestoreLayoutFromXml(fileInfo.FullName);
            }
            else
            {
                gridView.BestFitColumns();
                gridView.SaveLayout();
            }
        }

        private void frm_Base_FormClosed(object sender, FormClosedEventArgs e)
        {
            Dispose();
        }

        public void btn_Conditions_Click(object sender, EventArgs e)
        {
            pnl_Conditions.Visible = !pnl_Conditions.Visible;
            if (pnl_Conditions.Visible)
            {
                btn_Conditions.Text = "▲";
            }
            else
            {
                btn_Conditions.Text = "▼";
            }
        }

        private List<Dictionary<string, object>> To_Json_Helper(DataTable dataTable, params string[] Column_Names)
        {
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row;
            foreach (DataRow dr in dataTable.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn col in dataTable.Columns)
                {
                    if (Column_Names is null)
                    {
                        row.Add(col.ColumnName, dr[col]);
                    }
                    else if (!string.IsNullOrEmpty(Array.Find(Column_Names, element => element.Equals(col.ColumnName))))
                    {
                        row.Add(col.ColumnName, dr[col]);
                    }
                }
                rows.Add(row);
            }
            return rows;
        }

        public string To_Json(DataTable dataTable)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();

            return serializer.Serialize(To_Json_Helper(dataTable, null));
        }

        public string To_Json(DataTable dataTable, params string[] Column_Names)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();

            return serializer.Serialize(To_Json_Helper(dataTable, Column_Names));
        }

        public string To_Json(DataSet dataSet)

        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Dictionary<string, List<Dictionary<string, object>>> tables = new Dictionary<string, List<Dictionary<string, object>>>();

            foreach (DataTable dataTable in dataSet.Tables)
            {
                tables.Add(dataTable.TableName, To_Json_Helper(dataTable));
            }
            return serializer.Serialize(tables);
        }

        public void Set_Description(TreeList treeList)
        {
            foreach (TreeListColumn col in treeList.Columns)
            {
                foreach (DataRow row in _Main.dt_Description.Rows)
                {
                    if (row["COLUMN_NAME"].ToString() == col.FieldName)
                    {
                        col.Caption = row["COLUMN_DESCRIPTION"].ToString();
                        break;
                    }
                }
            }
        }

        public void Set_Description(LayoutControl layout)
        {
            foreach (LayoutItem item in layout.Root.Items)
            {
                foreach (DataRow row in _Main.dt_Description.Rows)
                {
                    if (row["COLUMN_NAME"].ToString() == item.Text)
                    {
                        item.Text = row["COLUMN_DESCRIPTION"].ToString();
                        break;
                    }
                }
            }
        }


        public XRControl findControlByName(XtraReport report, string name)
        {
            foreach (XRControl ctrl in report.AllControls<XRControl>())
            {
                if (ctrl.Name == name)
                {
                    return ctrl;
                }
            }
            return null;
        }
    }
}