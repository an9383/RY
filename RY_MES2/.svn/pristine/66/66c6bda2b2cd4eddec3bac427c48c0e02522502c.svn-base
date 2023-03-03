using DevExpress.XtraReports.UI;
using System.Data;

namespace RY_MES.Forms
{
    public partial class SupplyPartList_GE : DevExpress.XtraReports.UI.XtraReport
    {
        public SupplyPartList_GE(params object[] paramArray)
        {
            InitializeComponent();


            DataSet _ds = paramArray[0] as DataSet;

            foreach (DataRow item in _ds.Tables[1].Rows)
            {
                ds_OQC_TFT1.DataTable1.Rows.Add(item.ItemArray);
            }

            foreach (DataRow item in _ds.Tables[4].Rows)
            {
                ds_OQC_TFT1.DataTable3.Rows.Add(item.ItemArray);
            }

            foreach (DataRow item in _ds.Tables[2].Select("DESC1 = 'SUPPLY'"))
            {
                ds_OQC_TFT1.DataTable2.Rows.Add(item.ItemArray);
            }

        }

    }
}