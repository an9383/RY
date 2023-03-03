using DevExpress.XtraReports.UI;
using System.Data;

namespace RY_MES.Forms
{
    public partial class QC_CSI_REPORT : DevExpress.XtraReports.UI.XtraReport
    {
        public QC_CSI_REPORT(DataSet ds)
        {
            InitializeComponent();

            DataSet _ds = ds;

            foreach (DataRow item in _ds.Tables[1].Rows)
            {
                ds_QC_CSI1.DataTable1.Rows.Add(item.ItemArray);
            }

            foreach (DataRow item in _ds.Tables[2].Rows)
            {
                ds_QC_CSI1.DataTable2.Rows.Add(item.ItemArray);
            }

            foreach (DataRow item in _ds.Tables[3].Rows)
            {
                ds_QC_CSI1.DataTable3.Rows.Add(item.ItemArray);
            }

            DataSource = ds_QC_CSI1;


            ExpressionBinding expressionBinding1 = new ExpressionBinding("BeforePrint", "Tag", "[WO_ID] + [OP_NAME] + [CHK_PROCESS_NAME]");
            ExpressionBinding expressionBinding2 = new ExpressionBinding("BeforePrint", "Tag", "[WO_ID] + [OP_NAME] + [EQUIP_NAME]");
            ExpressionBinding expressionBinding3 = new ExpressionBinding("BeforePrint", "Tag", "[WO_ID] + [OP_NAME] + [UPDATE_USER]");
            ExpressionBinding expressionBinding4 = new ExpressionBinding("BeforePrint", "Tag", "[WO_ID] + [OP_NAME] + [WO_START_DATE] + [WO_END_DATE]");
            ExpressionBinding expressionBinding5 = new ExpressionBinding("BeforePrint", "Tag", "[WO_ID]");


            lbl_CHK_PROCESS_NAME.ExpressionBindings.Add(expressionBinding1);
            lbl_EQUIP_NAME.ExpressionBindings.Add(expressionBinding2);
            lbl_UPDATE_USER.ExpressionBindings.Add(expressionBinding3);
            lbl_DATE.ExpressionBindings.Add(expressionBinding4);

            lbl_INPUT_QTY.ExpressionBindings.Add(expressionBinding5);
            lbl_COMP_QTY.ExpressionBindings.Add(expressionBinding5);
            lbl_DEFECT_QTY.ExpressionBindings.Add(expressionBinding5);
        }

    }
}