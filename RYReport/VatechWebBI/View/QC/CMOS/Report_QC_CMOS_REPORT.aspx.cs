using DevExpress.DashboardCommon;
using DevExpress.Web.Internal;
using DevExpress.XtraCharts;
using DevExpress.XtraReports.Native;
using DevExpress.XtraReports.UI;
using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;

public partial class View_QC_CMOS_Report_QC_CMOS_REPORT : System.Web.UI.Page
{
    protected string pstrReportId = "";
    protected string pstrContainerName = "";
    protected string pstrStepEntryTxnId = "";
    protected string pstrErrMsg = "";
    protected clsDatabase db = new clsDatabase();
    protected string query = "";
    protected DataRowView master = null;

    protected DataSet _ds;

    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Request.QueryString["cmd"] ?? "") != "esig" && (Session["EmpNo"] ?? "").ToString() == "")
        {
            try
            {
                HttpContext.Current.Response.Redirect("~/View/SessionError.aspx");
            }
            catch (ApplicationException)
            {
                HttpContext.Current.Response.RedirectLocation =
                                     System.Web.VirtualPathUtility.ToAbsolute("~/View/SessionError.aspx");
            }
        }

        if (!IsPostBack)
        {

        }

        if ((Request.QueryString["reportid"] ?? "") == "")
        {
            pstrErrMsg = "양식을 가져올수 없습니다.";
            return;
        }

        pstrReportId = Request.QueryString["reportid"] ?? "";
        //pstrReportId = "78";
        //pstrContainerName = "S152OHCCB22-67249";
        //pstrStepEntryTxnId = "400000000004a76a";

        master = IsExistReportItem(pstrReportId);

        if (master == null)
        {
            pstrErrMsg = "양식이 작성되지 않았습니다.";
            return;
        }

        if (master["LayoutData"].ToString() == "")
        {
            pstrErrMsg = "양식이 작성되지 않았습니다.";
            return;
        }

        master["LayoutData"] = master["LayoutData"].ToString().Replace("?<?", "<?");

        XtraReport rpt = new XtraReport();
        using (StreamWriter sw = new StreamWriter(new MemoryStream()))
        {
            sw.Write(master["LayoutData"]);
            sw.Flush();
            rpt.LoadLayoutFromXml(sw.BaseStream);
        }

        foreach (DevExpress.XtraReports.Parameters.Parameter param in rpt.Parameters)
        {
            if (Request.QueryString[param.Name] != null)
            {
                param.Value = Request.QueryString[param.Name];
            }
        }

        query = string.Format("exec CAMDBsh.RY_VR_Proc_CMOS_RunsheetReport '{0}', '{1}'", pstrContainerName, pstrStepEntryTxnId);
        _ds = db.GetDataSet(query);

        DataTable dt = _ds.Tables[0];
        DataTable dt1 = _ds.Tables[1];
        DataTable dt2 = _ds.Tables[2];
        DataTable dt3 = _ds.Tables[3];
        DataTable dt4 = _ds.Tables[4];
        DataTable dt5 = _ds.Tables[5];
        DataTable dt6 = _ds.Tables[6];

        DataRow[] ftRows = dt4.Select("AUTO_YN = 'Y'");

        if (ftRows.Length > 0)
        {
            string[] display_areas = null;
            string display_area = "";

            foreach (DataRow ftRow in ftRows)
            {
                if (dt5.Rows.Count > 0)
                {
                    display_areas = ftRow["DISPLAY_AREA"].ToString().ToUpper().Split('/');
                    display_area = "";

                    foreach (DataRow cmosRow in dt5.Rows)
                    {
                        display_area = display_areas[0].Trim();

                        int col = 0;

                        if (display_area.Length == 1)
                        {
                            char c = display_area[0];
                            col = Convert.ToInt32(c) - 65;
                        }
                        else if (display_area.Length == 2)
                        {
                            char c1 = display_area[0];
                            col = (Convert.ToInt32(c1) - 64) * 26;

                            char c2 = display_area[1];
                            col += Convert.ToInt32(c2) - 65;
                        }
                        ftRow["INSPECTION_RESULT"] = cmosRow[col].ToString();
                    }
                }

                if (dt6.Rows.Count > 0)
                {
                    display_areas = ftRow["DISPLAY_AREA"].ToString().ToUpper().Split('/');
                    display_area = "";

                    foreach (DataRow iosRow in dt6.Rows)
                    {
                        display_area = display_areas[Convert.ToInt32(iosRow["HoGi"]) - 1].Trim();
                        int col = 0;

                        if (display_area.Length == 1)
                        {
                            if (Convert.ToInt32(iosRow["SoonBun"]) != 1) continue; 
                            char c = display_area[0];
                            col = Convert.ToInt32(c) - 65;
                        }
                        else if (display_area.Length == 2)
                        {
                            char c1 = display_area[0];
                            col = (Convert.ToInt32(c1) - 64) * 26;

                            char c2 = display_area[1];
                            col += Convert.ToInt32(c2) - 65;

                            if (col > 26)
                            {   // 순번 : 2 아니면 continue
                                if (Convert.ToInt32(iosRow["SoonBun"]) != 2) continue;
                                col -= 27;
                            }
                            else
                            {   // 순번 : 1 아니면 continue
                                if (Convert.ToInt32(iosRow["SoonBun"]) != 1) continue;
                            }                       
                        }

                        ftRow["INSPECTION_RESULT"] = iosRow[col].ToString();
                    }
                }

                string filter = string.Format("ContainerName = '{0}' and DataCollectionDefName = '{1}' and DataCollectionDefRevision = '{2}' and DataPointName = '{3}'",
                    ftRow["ContainerName"].ToString(), ftRow["DataCollectionDefName"].ToString(), ftRow["DataCollectionDefRevision"].ToString(), ftRow["DataPointName"].ToString());
                DataRow[] dt3Rows = dt3.Select(filter);
                if (dt3Rows.Length > 0)
                {
                    dt3Rows[0]["INSPECTION_RESULT"] = ftRow["INSPECTION_RESULT"];
                }
            }
        }

        if (dt.Rows.Count > 0)
        {
            DataRow dr = dt.Rows[0];
            if (rpt.FindControl("lbl_MODEL_NAME1", true) != null)
                rpt.FindControl("lbl_MODEL_NAME1", true).Text = dr["MODEL_NAME"].ToString() + " Runsheet I";
            if (rpt.FindControl("lbl_MODEL_NAME2", true) != null)
                rpt.FindControl("lbl_MODEL_NAME2", true).Text = dr["MODEL_NAME"].ToString() + " Runsheet II";

            if (rpt.FindControl("lbl_CONFIRM_USER1", true) != null)
                rpt.FindControl("lbl_CONFIRM_USER1", true).Text = dr["CONFIRM_USER"].ToString();
            if (rpt.FindControl("lbl_APPLY_USER1", true) != null)
                rpt.FindControl("lbl_APPLY_USER1", true).Text = dr["APPLY_USER"].ToString();
        }

        _ds.Relations.Add("Relation1", dt1.Columns["WAFER_NO"], dt2.Columns["WAFER_NO"]);

        rpt.DataSource = _ds;
        rpt.DataMember = _ds.Tables[0].TableName;

        if (_ds.Tables[1].Rows.Count == 1)
        {
            ((DetailReportBand)rpt.FindControl("DetailReport", true)).Visible = false;
            ((SubBand)rpt.FindControl("SubBand1", true)).Visible = false;

            ((DetailReportBand)rpt.FindControl("DetailReport3", true)).DataSource = _ds;
            ((DetailReportBand)rpt.FindControl("DetailReport3", true)).DataMember = _ds.Tables[4].TableName;
        }
        else
        {
            ((DetailReportBand)rpt.FindControl("DetailReport", true)).Visible = true;
        }

        ((DetailReportBand)rpt.FindControl("DetailReport", true)).Visible = true;

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

        if (rpt.FindControl("lbl_CHK_PROCESS_NAME1", true) != null)
            rpt.FindControl("lbl_CHK_PROCESS_NAME1", true).ExpressionBindings.Add(expressionbinding1_1);
        if (rpt.FindControl("lbl_CHK_PROCESS_NAME2", true) != null)
            rpt.FindControl("lbl_CHK_PROCESS_NAME2", true).ExpressionBindings.Add(expressionbinding1_2);
        if (rpt.FindControl("lbl_CHK_NAME1", true) != null)
            rpt.FindControl("lbl_CHK_NAME1", true).ExpressionBindings.Add(expressionbinding2_1);
        if (rpt.FindControl("lbl_CHK_NAME2", true) != null)
            rpt.FindControl("lbl_CHK_NAME2", true).ExpressionBindings.Add(expressionbinding2_2);
        if (rpt.FindControl("lbl_CRITERIA1", true) != null)
            rpt.FindControl("lbl_CRITERIA1", true).ExpressionBindings.Add(expressionbinding3_1);
        if (rpt.FindControl("lbl_CRITERIA2", true) != null)
            rpt.FindControl("lbl_CRITERIA2", true).ExpressionBindings.Add(expressionbinding3_2);
        if (rpt.FindControl("lbl_INSPECTION_METHOD1", true) != null)
            rpt.FindControl("lbl_INSPECTION_METHOD1", true).ExpressionBindings.Add(expressionbinding4_1);
        if (rpt.FindControl("lbl_INSPECTION_METHOD2", true) != null)
            rpt.FindControl("lbl_INSPECTION_METHOD2", true).ExpressionBindings.Add(expressionbinding4_2);
        if (rpt.FindControl("lbl_CREATE_USER1", true) != null)
            rpt.FindControl("lbl_CREATE_USER1", true).ExpressionBindings.Add(expressionbinding5_1);
        if (rpt.FindControl("lbl_CREATE_USER2", true) != null)
            rpt.FindControl("lbl_CREATE_USER2", true).ExpressionBindings.Add(expressionbinding5_2);
        if (rpt.FindControl("lbl_CREATE_DATE1", true) != null)
            rpt.FindControl("lbl_CREATE_DATE1", true).ExpressionBindings.Add(expressionbinding6_1);
        if (rpt.FindControl("lbl_CREATE_DATE2", true) != null)
            rpt.FindControl("lbl_CREATE_DATE2", true).ExpressionBindings.Add(expressionbinding6_2);

        rpt.RequestParameters = false;

        WebDocumentViewer.OpenReport(rpt);
    }

    protected DataRowView IsExistReportItem(string reportId)
    {
        query = string.Format("Select * From {0}_ReportDB.dbo.ReportItem Where CorpId = '{0}' and ReportId = {1}",
                        Session["CorpId"], reportId);

        return db.GetDataRecord(query);
    }

}