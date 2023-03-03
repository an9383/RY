using DevExpress.Spreadsheet;
using DevExpress.Spreadsheet.Export;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting.Native;
using DevExpress.XtraSpreadsheet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VTMES3_RE.Common;
using VTMES3_RE.IFRYDataSetTableAdapters;
using VTMES3_RE.Models;

namespace VTMES3_RE.View.WorkManager
{
    public partial class frmEmployeeWorkTime : DevExpress.XtraEditors.XtraForm
    {

        string folderName = Application.StartupPath + @"\Templates\WorkTemplate";
        string fileName = "EmployeeWorkTime.xlsx";

        clsWork work = new clsWork();
        string workTimeDefString = "";
        DataView workTimeDefDv = null;

        public frmEmployeeWorkTime()
        {
            InitializeComponent();

            barEditStartDate.EditValue = DateTime.Today.AddDays(1 - DateTime.Today.Day);
            barEditEndDate.EditValue = DateTime.Today.AddMonths(1).AddDays(DateTime.Today.Day * -1);

            employeeWorkTimeBindingSource.AllowNew = false;

            workTimeDefDv = work.GetEmployeeWorkTimeRegularDef();
            workTimeDefString = work.GetEmployeeWorkTimeDefString();

            DataView teamDv = work.GetEmployeeTeamList();
            foreach (DataRowView row in teamDv) 
            {
                teamNameComboBoxEdit.Properties.Items.Add(row["TeamName"]);
            }

            teamNameComboBoxEdit.EditValue = "전체";
        }

        private void frmEmployeeWorkTime_Load(object sender, EventArgs e)
        {
            DisplayData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DisplayData();
        }

        private void DisplayData()
        {
            this.employeeWorkTimeTableAdapter.FillByList(this.iFRYDataSet.EmployeeWorkTime, (DateTime)barEditStartDate.EditValue, ((DateTime)barEditEndDate.EditValue).AddDays(1), 
                                    (teamNameComboBoxEdit.EditValue ?? "전체").ToString(), (employeeNameSearchLookUpEdit.EditValue ?? "전체").ToString());

            DataView dv = (DataView)employeeWorkTimeBindingSource.List;
            dv.Table.Columns["ID_KEY"].SetOrdinal(0);
            dv.Table.Columns["TeamName"].SetOrdinal(1);
            dv.Table.Columns["FullName"].SetOrdinal(2);
            dv.Table.Columns["EmployeeName"].SetOrdinal(3);
            dv.Table.Columns["Gubun"].SetOrdinal(4);
            dv.Table.Columns["StartTime"].SetOrdinal(5);
            dv.Table.Columns["EndTime"].SetOrdinal(6);
            dv.Table.Columns["Remark"].SetOrdinal(7);
            dv.Table.Columns["CreId"].SetOrdinal(8);
            dv.Table.Columns["CreDt"].SetOrdinal(9);
            dv.Table.Columns["ModId"].SetOrdinal(10);
            dv.Table.Columns["ModDt"].SetOrdinal(11);

            dv.Table.Columns["TeamName"].ReadOnly = true;
            dv.Table.Columns["FullName"].ReadOnly = true;
            dv.Table.Columns["CreId"].ReadOnly = true;
            dv.Table.Columns["CreDt"].ReadOnly = true;
            dv.Table.Columns["ModId"].ReadOnly = true;
            dv.Table.Columns["ModDt"].ReadOnly = true;

            //excelSheetControl.CreateNewDocument();
            //var externalDSOptions = new ExternalDataSourceOptions();
            //externalDSOptions.ImportHeaders = true;
            //excelSheetControl.Document.Worksheets[0].DataBindings.BindTableToDataSource(employeeWorkTimeBindingSource, 0, 0, externalDSOptions);
            IWorkbook workbook = excelSheetControl.Document;
            workbook.LoadDocument(folderName + "\\" + fileName);
            Worksheet worksheet = workbook.Worksheets[0];

            worksheet.DataBindings.BindTableToDataSource(employeeWorkTimeBindingSource, 0, 0);
            worksheet.FreezeColumns(2);

            //excelSheetControl.Document.Worksheets[0].GetDataRange().AutoFitColumns();
            CellRange comboBoxRange = excelSheetControl.Document.Worksheets[0]["[Gubun]"];

            excelSheetControl.Document.Worksheets[0].CustomCellInplaceEditors.Add(comboBoxRange, CustomCellInplaceEditorType.ComboBox, workTimeDefString);
        }
        // 저장
        private void cmdSave_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            try
            {
                this.Validate();

                if (excelSheetControl.IsCellEditorActive)
                {
                    excelSheetControl.CloseCellEditor(CellEditorEnterValueMode.ActiveCell);
                }

                DataView dv = (DataView)employeeWorkTimeBindingSource.List;
                dv.Table.Columns["CreId"].ReadOnly = false;
                dv.Table.Columns["CreDt"].ReadOnly = false;
                dv.Table.Columns["ModId"].ReadOnly = false;
                dv.Table.Columns["ModDt"].ReadOnly = false;

                foreach (DataRowView drv in employeeWorkTimeBindingSource.List)
                {
                    if (drv.Row.RowState == DataRowState.Added)
                    {
                        drv["CreId"] = WrGlobal.LoginID;
                        drv["CreDt"] = DateTime.Now;
                    }
                    else if (drv.Row.RowState == DataRowState.Modified)
                    {
                        drv["ModId"] = WrGlobal.LoginID;
                        drv["ModDt"] = DateTime.Now;
                    }
                }

                CellRange range = excelSheetControl.Document.Worksheets[0].GetDataRange();
                DataTable excelTable = excelSheetControl.Document.Worksheets[0].CreateDataTable(range, true);
                excelTable.TableName = "SaveTable";

                DataTableExporter exporter = excelSheetControl.Document.Worksheets[0].CreateDataTableExporter(range, excelTable, true);
                exporter.Options.ConvertEmptyCells = true;
                exporter.Options.DefaultCellValueToColumnTypeConverter.EmptyCellValue = 0;
                exporter.Options.DefaultCellValueToColumnTypeConverter.SkipErrorValues = true;

                exporter.CellValueConversionError += exporter_CellValueConversionError;
                exporter.Export();

                foreach (DataRow row in excelTable.Rows)
                {
                    if ((row["EmployeeName"] ?? "").ToString() == "")
                    {
                        MessageBox.Show(string.Format("EmployeeName : 필수 입력 항목입니다."), "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if ((row["Gubun"] ?? "").ToString() == "")
                    {
                        MessageBox.Show(string.Format("Gubun : 필수 입력 항목입니다."), "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (("," + workTimeDefString).IndexOf("," + row["Gubun"].ToString()) < 0)
                    {
                        MessageBox.Show(string.Format("Gubun : 정의되지 않은 값이 입력되었습니다."), "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (Convert.ToDateTime(row["StartTime"]).Year == 1899)
                    {
                        MessageBox.Show(string.Format("StartTime : 필수 입력 항목입니다."), "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (Convert.ToDateTime(row["EndTime"]).Year == 1899)
                    {
                        MessageBox.Show(string.Format("EndTime : 필수 입력 항목입니다."), "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                employeeWorkTimeBindingSource.EndEdit();

                dv.Table.Columns["CreId"].ReadOnly = true;
                dv.Table.Columns["CreDt"].ReadOnly = true;
                dv.Table.Columns["ModId"].ReadOnly = true;
                dv.Table.Columns["ModDt"].ReadOnly = true;

                employeeWorkTimeTableAdapter.Update(iFRYDataSet.EmployeeWorkTime);

                DataRow[] newRows = excelTable.Select("ID_KEY IS NULL OR ID_KEY = 0");

                foreach (DataRow row in newRows)
                {



                    employeeWorkTimeTableAdapter.Insert((row["EmployeeName"] ?? "").ToString(), (row["Gubun"] ?? "").ToString(),
                                                                        Convert.ToDateTime(row["StartTime"]), Convert.ToDateTime(row["EndTime"]),
                                                                        (row["Remark"] ?? "").ToString(),
                                                                        WrGlobal.LoginID, DateTime.Now, null, null);
                }

                MessageBox.Show("근무 시간이 저장되었습니다.", "저장", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DisplayData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // 닫기
        private void cmdClose_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            this.Close();
        }

        private void exporter_CellValueConversionError(object sender, CellValueConversionErrorEventArgs e)
        {
            DataTableExporter exporter = sender as DataTableExporter;
            CellValueToColumnTypeConverter defaultToColumnTypeConverter = exporter != null ? exporter.Options.DefaultCellValueToColumnTypeConverter : null;
            if (e.DataColumn.DataType == typeof(Double) && e.CellValue.IsText)
            {
                object newDataTableValue = CellValue.Empty;
                ConversionResult isConverted = defaultToColumnTypeConverter.Convert(e.Cell, e.CellValue, e.DataColumn.DataType, out newDataTableValue);
                e.DataTableValue = newDataTableValue;
                e.Action = isConverted == ConversionResult.Success ? DataTableExporterAction.Continue : DataTableExporterAction.SkipRow;
            }
        }

        private void excelSheetControl_CellValueChanged(object sender, SpreadsheetCellEventArgs e)
        {
            if (e.Cell.ColumnIndex == 4)
            {
                workTimeDefDv.RowFilter = string.Format("Gubun = '{0}'", e.Value.ToString());

                if (workTimeDefDv.Count > 0)
                {
                    if (e.Worksheet.Cells[e.RowIndex, e.ColumnIndex + 1].DisplayText == "")
                    {
                        e.Worksheet.Cells[e.RowIndex, e.ColumnIndex + 1].Value = DateTime.Today.AddHours(((DateTime)workTimeDefDv[0]["StartTime"]).Hour).AddMinutes(((DateTime)workTimeDefDv[0]["StartTime"]).Minute);
                        e.Worksheet.Cells[e.RowIndex, e.ColumnIndex + 2].Value = DateTime.Today.AddHours(((DateTime)workTimeDefDv[0]["StartTime"]).Hour + (int)workTimeDefDv[0]["WorkHour"]).AddMinutes(((DateTime)workTimeDefDv[0]["StartTime"]).Minute);
                    }
                }

                workTimeDefDv.RowFilter = "";
            }
        }

        private void teamNameComboBoxEdit_SelectedValueChanged(object sender, EventArgs e)
        {
            employeeNameSearchLookUpEdit.Properties.DataSource = work.GetEmployeeListByTeam((teamNameComboBoxEdit.EditValue ?? "전체").ToString());
            employeeNameSearchLookUpEdit.Properties.DisplayMember = "FullName";
            employeeNameSearchLookUpEdit.Properties.ValueMember = "EmployeeName";
            employeeNameSearchLookUpEdit.EditValue = "전체";
        }
    }
}