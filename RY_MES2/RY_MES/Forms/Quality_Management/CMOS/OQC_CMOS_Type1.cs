using DevExpress.XtraReports.UI;
using System;
using System.Data;
using System.Linq;

namespace RY_MES.Forms
{
    public partial class OQC_CMOS_Type1 : DevExpress.XtraReports.UI.XtraReport
    {
        private DataSet _ds;
        private frm_Base frm_Approval_Popup;

        public OQC_CMOS_Type1(params object[] paramArray)
        {
            InitializeComponent();

            _ds = paramArray[0] as DataSet;
            frm_Approval_Popup = paramArray[1] as frm_Base;

            //_ds = ds;

            DataRow dr1 = _ds.Tables[0].Rows[0];

            lbl_MODEL_NAME.Text = dr1["MODEL_NAME"].ToString();
            lbl_PRODUCT_SN.Text = dr1["PRODUCT_SN"].ToString();
            lbl_TEMPLATE_REV.Text = dr1["TEMPLATE_REV"].ToString();
            lbl_APPLY_USER.Text = dr1["APPLY_SIGNATURE"].ToString();
            lbl_APPLY_SIGNATURE.Text = dr1["APPLY_SIGNATURE"].ToString();

            if (_ds.Tables[1].Rows.Count > 0)
            {
                DataRow dr2 = _ds.Tables[1].Rows[0];
                lbl_CREATE_DATE.Text = dr2["CREATE_DATE"].ToString();
                lbl_CREATE_USER.Text = dr2["CREATE_SIGNATURE"].ToString();
                lbl_CREATE_SIGNATURE.Text = dr2["CREATE_SIGNATURE"].ToString();
            }

            DataSource = _ds;
            DataMember = _ds.Tables[1].TableName;

            ExpressionBinding expressionBinding1 = new ExpressionBinding("BeforePrint", "Tag", "[CHK_PROCESS_NAME]");
            ExpressionBinding expressionBinding2 = new ExpressionBinding("BeforePrint", "Tag", "[CHK_PROCESS_NAME] + [CRITERIA]");
            ExpressionBinding expressionBinding3 = new ExpressionBinding("BeforePrint", "Tag", "[CHK_PROCESS_NAME] + [INSPECTION_METHOD]");

            lbl_CHK_PROCESS_NAME.ExpressionBindings.Add(expressionBinding1);
            lbl_CRITERIA.ExpressionBindings.Add(expressionBinding2);
            lbl_INSPECTION_METHOD.ExpressionBindings.Add(expressionBinding3);
        }

        private void xrTableRow7_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_ds.Tables[1].Rows.Count <= 0)
            {
                return;
            }

            int total_size = 2970 - (Convert.ToInt32(TopMargin.HeightF + PageFooter.HeightF));

            object[] array = _ds.Tables[1].Select().Select(x => x["CHK_PROCESS_NAME"]).Distinct().ToArray();
            DataRow[] drs = _ds.Tables[1].Select("CHK_PROCESS_NAME = '" + GetCurrentColumnValue("CHK_PROCESS_NAME").ToString() + "'");

            XRTableRow row = sender as XRTableRow;

            row.HeightF = total_size / array.Length / drs.Length;
            row.Band.HeightF = total_size / array.Length / drs.Length;
                        
            if (GetCurrentColumnValue("CHK_PROCESS_NAME").ToString().Contains("Total Approval"))
            {
                lbl_CRITERIA.Visible = false;
                lbl_INSPECTION_METHOD.Visible = false;
            }
        }
    }
}