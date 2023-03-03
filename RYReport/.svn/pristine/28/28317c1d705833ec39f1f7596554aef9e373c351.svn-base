using DevExpress.XtraReports.Native;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;

public partial class View_QC_TFT_Report_QC_TFT_REPORT : System.Web.UI.Page
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
        pstrContainerName = Request.QueryString["ContainerName"] ?? "";
        pstrStepEntryTxnId = Request.QueryString["StepEntryTxnId"] ?? "";

        //pstrReportId = "73";
        //pstrContainerName = "RYOQ-test20221118001";
        //pstrStepEntryTxnId = "";

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