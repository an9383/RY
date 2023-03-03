using DevExpress.XtraReports.UI;
using System.Data;

namespace RY_MES.Forms
{
    public partial class OQC_SW_Domestic_Normal : DevExpress.XtraReports.UI.XtraReport
    {
        public OQC_SW_Domestic_Normal(params object[] paramArray)
        {
            InitializeComponent();

            DataSet _ds = paramArray[0] as DataSet;
            //ds_OQC_TFT1.Relations.Add("s123456789",ds_OQC_TFT1.DataTable1.Columns["WAFER_NO"], ds_OQC_TFT1.DataTable2.Columns["WAFER_NO"]);
            foreach (DataRow item in _ds.Tables[1].Rows)
            {
                ds_OQC_TFT1.DataTable1.Rows.Add(item.ItemArray);
            }
            foreach (DataRow item in _ds.Tables[5].Rows)
            {
                ds_OQC_TFT1.DataTable3.Rows.Add(item.ItemArray);
            }

            foreach (DataRow item in _ds.Tables[2].Select("DESC1 = 'CERTIFICATION'"))
            {
                ds_OQC_TFT1.DataTable2.Rows.Add(item.ItemArray);
            }
        }
 
    }
}