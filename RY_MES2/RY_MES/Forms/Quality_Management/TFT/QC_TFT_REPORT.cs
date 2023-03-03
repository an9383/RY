using DevExpress.XtraReports.UI;
using System.Data;

namespace RY_MES.Forms
{
    public partial class QC_TFT_REPORT : DevExpress.XtraReports.UI.XtraReport
    {
        public QC_TFT_REPORT(DataSet ds)
        {
            InitializeComponent();

            DataSet _ds = ds;

            foreach (DataRow item in _ds.Tables[1].Rows)
            {
                ds_QC_TFT1.DataTable1.Rows.Add(item.ItemArray);
            }

            foreach (DataRow item in _ds.Tables[2].Rows)
            {
                ds_QC_TFT1.DataTable2.Rows.Add(item.ItemArray);
            }

            DataSource = ds_QC_TFT1;


            ExpressionBinding expressionbinding1 = new ExpressionBinding("BeforePrint", "Tag", "[OP_NAME] + [EQUIP_NAME]");
            ExpressionBinding expressionbinding2 = new ExpressionBinding("BeforePrint", "Tag", "[OP_NAME] + [CHK_PROCESS_NAME]");
            ExpressionBinding expressionbinding3 = new ExpressionBinding("BeforePrint", "Tag", "[OP_NAME] + [INSPECTION_METHOD]");
            ExpressionBinding expressionbinding4 = new ExpressionBinding("BeforePrint", "Tag", "[OP_NAME] + [UPDATE_USER]");
            ExpressionBinding expressionbinding5 = new ExpressionBinding("BeforePrint", "Tag", "[OP_NAME] + [WO_END_DATE]");

            lbl_EQUIP_NAME.ExpressionBindings.Add(expressionbinding1);
            lbl_CHK_PROCESS_NAME.ExpressionBindings.Add(expressionbinding2);
            lbl_INSPECTION_METHOD.ExpressionBindings.Add(expressionbinding3);
            lbl_CREATE_USER.ExpressionBindings.Add(expressionbinding4);
            lbl_CREATE_DATE.ExpressionBindings.Add(expressionbinding5);
        }

    }
}