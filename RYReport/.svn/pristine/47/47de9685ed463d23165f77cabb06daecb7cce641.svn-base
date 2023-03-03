using DevExpress.XtraReports.Native;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;

public partial class View_QC_CMOS_Report_OQC_IOS_HI : System.Web.UI.Page
{
    protected string pstrReportName = "";
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

        if ((Request.QueryString["TEMPLATE_FORM"] ?? "") == "")
        {
            pstrErrMsg = "레포트를 가져올수 없습니다.(TEMPLATE_FORM 없음)";
            return;
        }

        pstrReportName = Request.QueryString["TEMPLATE_FORM"] ?? "";
        pstrContainerName = Request.QueryString["ContainerName"] ?? "";
        pstrStepEntryTxnId = Request.QueryString["StepEntryTxnId"] ?? "";

        //pstrReportId = "58";
        //pstrContainerName = "RYOQ-test20221118001";
        //pstrStepEntryTxnId = "";

        master = IsExistReportItem(pstrReportName);

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

        query = string.Format("exec CAMDBsh.RY_VR_Proc_CMOS_OQCReport '{0}', '{1}'", pstrContainerName, pstrStepEntryTxnId);
        _ds = db.GetDataSet(query);

        DataRow dr1 = _ds.Tables[0].Rows[0];
        if (rpt.FindControl("lbl_ApprovalDate", true) != null)
            rpt.FindControl("lbl_ApprovalDate", true).Text = dr1["APPLY_DATE"].ToString();
        if (rpt.FindControl("lbl_ApprovalUser", true) != null)
            rpt.FindControl("lbl_ApprovalUser", true).Text = dr1["APPLY_SIGNATURE"].ToString();

        if (_ds.Tables[1].Rows.Count > 0)
        {
            DataRow dr2 = _ds.Tables[1].Rows[0];
            if (rpt.FindControl("lbl_CreateDate1", true) != null)
                rpt.FindControl("lbl_CreateDate1", true).Text = dr2["CREATE_DATE"].ToString();
            if (rpt.FindControl("lbl_CreateDate2", true) != null)
                rpt.FindControl("lbl_CreateDate2", true).Text = dr2["CREATE_DATE"].ToString();

            if (rpt.FindControl("lbl_CreateUser1", true) != null)
                rpt.FindControl("lbl_CreateUser1", true).Text = dr2["CREATE_SIGNATURE"].ToString();
            if (rpt.FindControl("lbl_CreateUser2", true) != null)
                rpt.FindControl("lbl_CreateUser2", true).Text = dr2["CREATE_SIGNATURE"].ToString();
        }

        if (rpt.FindControl("lbl_SN", true) != null)
            rpt.FindControl("lbl_SN", true).Text = dr1["PRODUCT_SN"].ToString();

        string qcDocID = dr1["OQC_DOC_ID"].ToString();

        if (qcDocID.Equals("173") || qcDocID.Equals("174"))
        {
            if (rpt.FindControl("lbl_ProductName", true) != null)
                rpt.FindControl("lbl_ProductName", true).Text = "■Medical  □Veterinary" + rpt.FindControl("lbl_ProductName", true).Text;
            if (rpt.FindControl("lbl_ModelName2", true) != null)
                rpt.FindControl("lbl_ModelName2", true).Text = "■ IOS-U10IF  □ IOS-U15IF  □ IOS-U20IF";
            if (rpt.FindControl("lbl_Version", true) != null)
                rpt.FindControl("lbl_Version", true).Text = "■ 1.0   □ 1.5   □ 2.0";
        }
        else if (qcDocID.Equals("175") || qcDocID.Equals("176"))
        {
            if (rpt.FindControl("lbl_ProductName", true) != null)
                rpt.FindControl("lbl_ProductName", true).Text = "■Medical  □Veterinary" + rpt.FindControl("lbl_ProductName", true).Text;
            if (rpt.FindControl("lbl_ModelName2", true) != null)
                rpt.FindControl("lbl_ModelName2", true).Text = "□ IOS-U10IF  ■ IOS-U15IF  □ IOS-U20IF";
            if (rpt.FindControl("lbl_Version", true) != null)
                rpt.FindControl("lbl_Version", true).Text = "□ 1.0   ■ 1.5   □ 2.0";
        }
        else if (qcDocID.Equals("177") || qcDocID.Equals("178"))
        {
            if (rpt.FindControl("lbl_ProductName", true) != null)
                rpt.FindControl("lbl_ProductName", true).Text = "■Medical  □Veterinary" + rpt.FindControl("lbl_ProductName", true).Text;
            if (rpt.FindControl("lbl_ModelName2", true) != null)
                rpt.FindControl("lbl_ModelName2", true).Text = "□ IOS-U10IF  □ IOS-U15IF  ■ IOS-U20IF";
            if (rpt.FindControl("lbl_Version", true) != null)
                rpt.FindControl("lbl_Version", true).Text = "□ 1.0   □ 1.5   ■ 2.0";
        }
        else if (qcDocID.Equals("179"))
        {
            if (rpt.FindControl("lbl_ProductName", true) != null)
                rpt.FindControl("lbl_ProductName", true).Text = "□Medical  ■Veterinary" + rpt.FindControl("lbl_ProductName", true).Text;
            if (rpt.FindControl("lbl_ModelName2", true) != null)
                rpt.FindControl("lbl_ModelName2", true).Text = "■ IOS-U10VF  □ IOS-U15VF  □ IOS-U20VF";
            if (rpt.FindControl("lbl_Version", true) != null)
                rpt.FindControl("lbl_Version", true).Text = "■ 1.0   □ 1.5   □ 2.0";
        }
        else if (qcDocID.Equals("180"))
        {
            if (rpt.FindControl("lbl_ProductName", true) != null)
                rpt.FindControl("lbl_ProductName", true).Text = "□Medical  ■Veterinary" + rpt.FindControl("lbl_ProductName", true).Text;
            if (rpt.FindControl("lbl_ModelName2", true) != null)
                rpt.FindControl("lbl_ModelName2", true).Text = "□ IOS-U10VF  ■ IOS-U15VF  □ IOS-U20VF";
            if (rpt.FindControl("lbl_Version", true) != null)
                rpt.FindControl("lbl_Version", true).Text = "□ 1.0   ■ 1.5   □ 2.0";
        }
        else if (qcDocID.Equals("181"))
        {
            if (rpt.FindControl("lbl_ProductName", true) != null)
                rpt.FindControl("lbl_ProductName", true).Text = "□Medical  ■Veterinary" + rpt.FindControl("lbl_ProductName", true).Text;
            if (rpt.FindControl("lbl_ModelName2", true) != null)
                rpt.FindControl("lbl_ModelName2", true).Text = "□ IOS-U10VF  □ IOS-U15VF  ■ IOS-U20VF";
            if (rpt.FindControl("lbl_Version", true) != null)
                rpt.FindControl("lbl_Version", true).Text = "□ 1.0   □ 1.5   ■ 2.0";
        }

        DataRow[] resolutions = _ds.Tables[1].Select("CHK_ID IN (1165, 1167, 1168)");
        if (resolutions.Length > 0)
        {
            if (rpt.FindControl("lbl_Resolution", true) != null)
                rpt.FindControl("lbl_Resolution", true).Text = resolutions[0]["CRITERIA"].ToString();
            if (rpt.FindControl("lbl_Resolution_Value", true) != null)
                rpt.FindControl("lbl_Resolution_Value", true).Text = resolutions[0]["INSPECTION_RESULT"].ToString();
        }

        DataRow[] sws = _ds.Tables[1].Select("CHK_ID IN (1538)");
        if (sws.Length > 0)
        {
            if (rpt.FindControl("lbl_SW_Value", true) != null)
                rpt.FindControl("lbl_SW_Value", true).Text = sws[0]["INSPECTION_VALUE"].ToString();
        }

        foreach (DataRow row in _ds.Tables[1].Rows)
        {
            string lbl_name = "lbl_" + row["CHK_ID"].ToString();

            if (rpt.FindControl(lbl_name, true) != null)
                rpt.FindControl(lbl_name, true).Text = row["INSPECTION_RESULT"].ToString();
        }

        rpt.RequestParameters = false;

        WebDocumentViewer.OpenReport(rpt);
    }

    protected DataRowView IsExistReportItem(string reportName)
    {
        query = string.Format("Select * From {0}_ReportDB.dbo.ReportItem Where CorpId = '{0}' and ReportName = '{1}'",
                        Session["CorpId"], reportName);

        return db.GetDataRecord(query);
    }
}