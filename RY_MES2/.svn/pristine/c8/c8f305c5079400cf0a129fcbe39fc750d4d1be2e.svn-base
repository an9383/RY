using RY_MES.Forms.Quality_Management.TFT;
using System.Data;

namespace RY_MES.Forms
{
    public partial class Performance_OSKO : DevExpress.XtraReports.UI.XtraReport
    {
        public Performance_OSKO(params object[] paramArray)
        {
            InitializeComponent();

            DataSet _ds = paramArray[0] as DataSet;

            foreach (DataRow item in _ds.Tables[1].Rows)
            {
                ds_OQC_TFT1.DataTable1.Rows.Add(item.ItemArray);
            }

            foreach (DataRow item in _ds.Tables[3].Select("CHK_PROCESS_NAME <> 'Offset performance'"))
            {
                ds_OQC_TFT1.DataTable3.Rows.Add(item.ItemArray);
            }

            foreach (DataRow item in _ds.Tables[2].Select("DESC1 = 'PERFORMANCE' AND CHK_PROCESS_NAME <> 'Offset performance'"))
            {
                ds_OQC_TFT1.DataTable2.Rows.Add(item.ItemArray);
            }

            DataSource = ds_OQC_TFT1;
        }
    }
}