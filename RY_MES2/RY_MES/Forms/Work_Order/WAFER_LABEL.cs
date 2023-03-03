using DevExpress.XtraReports.UI;
using System.Data;

namespace RY_MES.Forms
{
    public partial class WAFER_LABEL : DevExpress.XtraReports.UI.XtraReport
    {
        public WAFER_LABEL(DataTable dt)
        {
            InitializeComponent();
            dataSet1.Tables.Add(dt.Copy());
            DataMember = dataSet1.Tables[0].TableName;

            xrLabel1.ExpressionBindings.AddRange(new ExpressionBinding[] {
            new ExpressionBinding("BeforePrint", "Text","[WAFER_NO]")});

            xrBarCode1.ExpressionBindings.AddRange(new ExpressionBinding[] {
            new ExpressionBinding("BeforePrint", "Text","[WAFER_NO]")});
        }

        private void xrBarCode1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xrBarCode1.Text = xrBarCode1.Text.ToUpper();
        }
    }
}