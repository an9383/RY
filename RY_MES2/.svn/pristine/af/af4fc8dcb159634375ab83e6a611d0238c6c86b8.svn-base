using DevExpress.XtraReports.UI;
using System.Data;

namespace RY_MES.Forms
{
    public partial class QC_CMOS_REPORT : DevExpress.XtraReports.UI.XtraReport
    {
        private DataSet _ds;

        public QC_CMOS_REPORT(DataSet ds)
        {
            InitializeComponent();

            _ds = ds;

            //DataSource = _ds;
            //DataMember = _ds.Tables[0].TableName;

            DataTable dt = _ds.Tables[0];
            DataTable dt1 = _ds.Tables[1];
            DataTable dt2 = _ds.Tables[2];
            DataTable dt3 = _ds.Tables[3];

            DataRow dr = dt.Rows[0];

            lbl_MODEL_NAME1.Text = dr["MODEL_NAME"].ToString() + " Runsheet I";
            lbl_MODEL_NAME2.Text = dr["MODEL_NAME"].ToString() + " Runsheet II";
            //lbl_CONFIRM_USER.Text = dr["CONFIRM_USER"].ToString();
            //lbl_CONFIRM_DATE.Text = dr["CONFIRM_DATE"].ToString();
            //lbl_APPLY_USER.Text = dr["APPLY_USER"].ToString();
            //lbl_APPLY_DATE.Text = dr["APPLY_DATE"].ToString();

            lbl_CONFIRM_USER1.Text = dr["CONFIRM_USER"].ToString();
            lbl_APPLY_USER1.Text = dr["APPLY_USER"].ToString();

            _ds.Relations.Add("Relation1", dt1.Columns["WAFER_NO"], dt2.Columns["WAFER_NO"]);

            DataSource = _ds;
            DataMember = _ds.Tables[0].TableName;

            //DetailReport.Visible = false;
            //SubBand1.Visible = false;

            //DetailReport3.DataSource = _ds;
            //DetailReport3.DataMember = _ds.Tables[4].TableName;

            if (_ds.Tables[1].Rows.Count == 1)
            {
                DetailReport.Visible = false;
                SubBand1.Visible = false;

                DetailReport3.DataSource = _ds;
                DetailReport3.DataMember = _ds.Tables[4].TableName;
            }
            else
            {
                DetailReport.Visible = true;
            }

            ExpressionBinding expressionbinding1_1 = new ExpressionBinding("BeforePrint", "Tag", "[CHK_PROCESS_NAME]");
            ExpressionBinding expressionbinding2_1 = new ExpressionBinding("BeforePrint", "Tag", "[CHK_PROCESS_NAME] + [CHK_NAME]");
            ExpressionBinding expressionbinding3_1 = new ExpressionBinding("BeforePrint", "Tag", "[CHK_PROCESS_NAME] + [CHK_NAME] + [CRITERIA]");
            ExpressionBinding expressionbinding4_1 = new ExpressionBinding("BeforePrint", "Tag", "[CHK_PROCESS_NAME] + [CHK_NAME] + [CRITERIA]+ [INSPECTION_METHOD]");
            ExpressionBinding expressionbinding5_1 = new ExpressionBinding("BeforePrint", "Tag", "[OP_NAME] + [CREATE_USER]");
            ExpressionBinding expressionbinding6_1 = new ExpressionBinding("BeforePrint", "Tag", "[OP_NAME] + [CREATE_USER] + [CREATE_DATE]");

            ExpressionBinding expressionbinding1_2 = new ExpressionBinding("BeforePrint", "Tag", "[CHK_PROCESS_NAME]");
            ExpressionBinding expressionbinding2_2 = new ExpressionBinding("BeforePrint", "Tag", "[CHK_PROCESS_NAME] + [CHK_NAME]");
            ExpressionBinding expressionbinding3_2 = new ExpressionBinding("BeforePrint", "Tag", "[CHK_PROCESS_NAME] + [CHK_NAME] + [CRITERIA]");
            ExpressionBinding expressionbinding4_2 = new ExpressionBinding("BeforePrint", "Tag", "[CHK_PROCESS_NAME] + [CHK_NAME] + [CRITERIA]+ [INSPECTION_METHOD]");
            ExpressionBinding expressionbinding5_2 = new ExpressionBinding("BeforePrint", "Tag", "[OP_NAME] + [CREATE_USER]");
            ExpressionBinding expressionbinding6_2 = new ExpressionBinding("BeforePrint", "Tag", "[OP_NAME] + [CREATE_USER] + [CREATE_DATE]");

            lbl_CHK_PROCESS_NAME1.ExpressionBindings.Add(expressionbinding1_1);
            lbl_CHK_PROCESS_NAME2.ExpressionBindings.Add(expressionbinding1_2);
            lbl_CHK_NAME1.ExpressionBindings.Add(expressionbinding2_1);
            lbl_CHK_NAME2.ExpressionBindings.Add(expressionbinding2_2);
            lbl_CRITERIA1.ExpressionBindings.Add(expressionbinding3_1);
            lbl_CRITERIA2.ExpressionBindings.Add(expressionbinding3_2);
            lbl_INSPECTION_METHOD1.ExpressionBindings.Add(expressionbinding4_1);
            lbl_INSPECTION_METHOD2.ExpressionBindings.Add(expressionbinding4_2);
            lbl_CREATE_USER1.ExpressionBindings.Add(expressionbinding5_1);
            lbl_CREATE_USER2.ExpressionBindings.Add(expressionbinding5_2);
            lbl_CREATE_DATE1.ExpressionBindings.Add(expressionbinding6_1);
            lbl_CREATE_DATE2.ExpressionBindings.Add(expressionbinding6_2);
        }

        private void xrTableRow_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //int total_size = 2970 - (Convert.ToInt32(TopMargin.HeightF + PageFooter.HeightF));

            //Object[] array = _ds.Tables[0].Select().Select(x => x["CHK_PROCESS_NAME"]).Distinct().ToArray();
            //DataRow[] drs = _ds.Tables[0].Select("CHK_PROCESS_NAME = '" + GetCurrentColumnValue("CHK_PROCESS_NAME").ToString() + "'");

            //XRTableRow row = sender as XRTableRow;

            //row.HeightF =  (float) (total_size / array.Length / drs.Length);
            //row.Band.HeightF = (float)(total_size / array.Length / drs.Length);

            //if (GetCurrentColumnValue("CHK_PROCESS_NAME").ToString().Contains("Total Approval"))
            //{
            //    lbl_CRITERIA.Visible = false;
            //    lbl_INSPECTION_METHOD.Visible = false;
            //}
        }
    }
}