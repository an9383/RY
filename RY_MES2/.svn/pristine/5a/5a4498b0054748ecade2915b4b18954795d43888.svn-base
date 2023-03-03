using DevExpress.Utils.Menu;
using DevExpress.XtraCharts;
using DevExpress.XtraGrid.Menu;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Data;

namespace RY_MES.Forms
{
    public partial class frm_FT_DATA : RY_MES.frm_Base
    {
        public frm_FT_DATA()
        {
            InitializeComponent();
        }

        public frm_FT_DATA(object[] paramArray)
        {
            InitializeComponent();
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            _RYMES_DB = _Main._RYMES_DB;

            DataTable dt = new DataTable();
            _RYMES_DB._DB_Parameters.Add("@p_GROUP_CODE", "MODEL_MASTER");
            _RYMES_DB._DB_Parameters.Add("@p_OPTION ", "CMOS");

            string sMsg = _RYMES_DB.GET_DATA("SYS_CODE_LOAD", ref dt);

            if (string.IsNullOrEmpty(sMsg))
            {
                ucGridControl1.DataSource = dt;
            }
            else
            {
                ucGridControl1.DataSource = null;
                ucGridControl2.DataSource = null;
                ucGridControl3.DataSource = null;
            }
            RestoreLayout(this, ucGridView1);

            ucGridView3.PopupMenuShowing += gridView_PopupMenuShowing;
        }

        private void ucGridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            string Model_code = ucGridView1.GetRowCellValue(e.FocusedRowHandle, "코드").ToString();

            DataTable dt = new DataTable();
            _RYMES_DB._DB_Parameters.Add("@p_MODEL_CODE", Model_code);
            string sMsg = _RYMES_DB.GET_DATA("RP_FT_DATA_LOAD", ref dt);

            if (string.IsNullOrEmpty(sMsg))
            {
                ucGridView2.Tag = dt;

                DataTable dt_model = dt.Copy();
                dt_model.Columns.Remove("WAFER_NO");
                dt_model.Columns.Remove("HIC");
                dt_model.Columns.Remove("SCINTILLATOR");
                dt_model.Columns.Remove("BOARD");
                dt_model.Columns.Remove("VALUE_RESULT");
                dt_model.Columns.Remove("CREATE_DATE");
                dt_model.Columns.Remove("X");
                dt_model.Columns.Remove("Y");

                dt_model = dt_model.DefaultView.ToTable(true);
                ucGridControl2.DataSource = dt_model;
                ucGridView2.CheckBox_Column_Add();
            }
            else
            {
                ucGridControl2.DataSource = null;
                ucGridControl3.DataSource = null;
            }

            RestoreLayout(this, ucGridView2);
        }

        private void ucGridView2_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            DataTable dt_chk = ((DataTable)ucGridView2.Tag).Copy();
            string Y = "";
            foreach (int RowHandle in ucGridView2.GetSelectedRows())
            {
                Y += "'" + ucGridView2.GetRowCellValue(RowHandle, "CHK_PROCESS_NAME").ToString() + "/" + ucGridView2.GetRowCellValue(RowHandle, "CHK_NAME").ToString() + "',";
            }
            Y += "''";

            if (dt_chk.Select("Y IN (" + Y + ")").Length > 0)
            {
                dt_chk = dt_chk.Select("Y IN (" + Y + ")").CopyToDataTable();
                SetLineChartData(chartControl1, ViewType.Line, dt_chk);

                ucGridControl3.DataSource = dt_chk;
            }
            RestoreLayout(this, ucGridView3);
        }

        private void SetLineChartData(ChartControl chart, ViewType viewType, DataTable dt)
        {
            Dictionary<string, Series> seriesList = new Dictionary<string, Series>();
            chart.Series.Clear();
            foreach (DataRow row in dt.Rows)
            {
                if (!(row["VALUE_RESULT"] is DBNull))
                {
                    string y = row["Y"].ToString();
                    string x = row["X"].ToString();

                    if (decimal.TryParse(row["VALUE_RESULT"].ToString(), out decimal qty))
                    {
                        if (seriesList.TryGetValue(y, out Series series) == false)
                        {
                            seriesList.Add(y, series = new Series(y, viewType));

                            //Label 표시
                            series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;

                            chart.Series.Add(series);
                        }

                        //SeriesPoint 생성
                        SeriesPoint point = new SeriesPoint(x, qty);
                        series.Points.Add(point);
                    }
                }
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
                (view.GridControl as ucGridControl).Grid_Export();
            };
            e.Menu.Items.Add(item);
        }

    }
}