using DevExpress.XtraReports.UI;
using System.Data;

namespace RY_MES.Forms
{
    public partial class SN_LABEL : DevExpress.XtraReports.UI.XtraReport
    {
        public SN_LABEL(DataTable dt, string Model_Name)
        {
            InitializeComponent();
            dataSet1.Tables.Add(dt.Copy());
            DataMember = dataSet1.Tables[0].TableName;
            xrLabel2.Text = "Model Name : " + Model_Name;
            xrLabel3.ExpressionBindings.AddRange(new ExpressionBinding[] {
            new ExpressionBinding("BeforePrint", "Text","[PRODUCT_SN]")});
        }

        private void xrLabel3_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xrLabel3.Text = "S/N : " + xrLabel3.Text.ToUpper();
        }
    }
}