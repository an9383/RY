﻿using Camstar.XMLClient.API;
using DevExpress.CodeParser;
using DevExpress.XtraReports.Serialization;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VTMES3_RE.Common
{
    public class CamstarCommon
    {
        csiClient gClient = new csiClient();
        csiConnection gConnection = null;
        csiSession gSession = null;
        csiDocument gDocument = null;
        csiService gService = null;
        string gStrSessionID = "";

        string gHost = WrGlobal.Camstar_Host;
        int gPort = WrGlobal.Camstar_Port;

        CamstarMessage camMessage = new CamstarMessage();

        public bool IsExecuting = false;

        public CamstarCommon()
        {
            try
            {
                gConnection = gClient.createConnection(gHost, gPort);
                //gSession = gConnection.createSession(gUserName, gPassword, gSessionID.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Camstar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CreateDocumentandService(string documentName, string serviceName)
        {
            if (documentName.Length > 0)
            {
                gSession.removeDocument(documentName);
            }

            if (gService != null)
            {
                gService = null;
            }

            gDocument = gSession.createDocument(documentName);

            if (serviceName.Length > 0)
            {
                gService = gDocument.createService(serviceName);
            }
        }

        public void PrintDoc(string strDoc, bool isInputDoc)
        {
            string strDocFileName = "";
            string path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            if (isInputDoc)
            {
                strDocFileName = "inputDoc.xml";
            }
            else
            {
                strDocFileName = "responseDoc.xml";
            }

            if (File.Exists(path + "\\" + strDocFileName))
            {
                File.Delete(path + "\\" + strDocFileName);
            }

            File.WriteAllText(path + "\\" + strDocFileName, strDoc, Encoding.Default);
        }

        private void ErrorsCheck(csiDocument ResponseDocument)
        {
            csiExceptionData csiexceptiondata;

            if (ResponseDocument.checkErrors())
            {
                camMessage.Result = false;
                csiexceptiondata = ResponseDocument.exceptionData();
                camMessage.Message = "Severity: " + csiexceptiondata.getSeverity() + " Description: " + csiexceptiondata.getDescription();
            }
            else
            {
                camMessage.Result = true;
                camMessage.Message = "성공!";
            }
        }

        public string CreateSession()
        {
            try
            {
                gStrSessionID = Guid.NewGuid().ToString();
                gSession = gConnection.createSession(WrGlobal.Camstar_UserName, WrGlobal.Camstar_Password, gStrSessionID);

                return "";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string DestroySession()
        {
            try
            {
                gConnection.removeSession(gStrSessionID);

                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public void DestroyConnection()
        {
            gConnection.removeSession(gStrSessionID);
            gClient.removeConnection(gHost, gPort);
        }

        #region Role Function
        public CamstarMessage RoleDelete(string employeeName, int idx)
        {
            csiDocument ResponseDocument = null;
            csiObject InputData = null;
            csiObject InputData2 = null;
            csiSubentity ObjectChanges = null;
            csiNamedSubentityList Roles = null;

            try
            {
                CreateDocumentandService("EmployeeMaintTrans", "EmployeeMaint");

                InputData = gService.inputData();
                InputData.namedObjectField("ObjectToChange").setRef(employeeName);

                gService.perform("Load");

                InputData2 = gService.inputData();

                ObjectChanges = InputData2.subentityField("ObjectChanges");
                Roles = ObjectChanges.namedSubentityList("Roles");

                Roles.deleteItemByIndex(idx);

                gService.setExecute();
                gService.requestData().requestField("CompletionMsg");

                PrintDoc(gDocument.asXML(), true);
                ResponseDocument = gDocument.submit();
                PrintDoc(ResponseDocument.asXML(), false);
                ErrorsCheck(ResponseDocument);
            }
            catch (Exception ex)
            {
                camMessage.Result = false;
                camMessage.Message = ex.Message;
            }

            return camMessage;
        }

        public CamstarMessage RoleAdd(string employeename, string roleName)
        {
            csiDocument ResponseDocument = null;
            csiObject InputData = null;
            csiObject InputData2 = null;
            csiSubentity ObjectChanges = null;
            csiSubentity Members = null;

            try
            {
                CreateDocumentandService("EmployeeMaintTrans", "EmployeeMaint");

                InputData = gService.inputData();
                InputData.namedObjectField("ObjectToChange").setRef(employeename);

                gService.perform("Load");

                InputData2 = gService.inputData();

                ObjectChanges = InputData2.subentityField("ObjectChanges");
                Members = ObjectChanges.subentityList("Roles").appendItem();
                Members.namedObjectField("Role").setRef(roleName);
                Members.dataField("PropagateToChildOrgs").setValue(false.ToString());

                gService.setExecute();
                gService.requestData().requestField("CompletionMsg");

                PrintDoc(gDocument.asXML(), true);
                ResponseDocument = gDocument.submit();
                PrintDoc(ResponseDocument.asXML(), false);
                ErrorsCheck(ResponseDocument);
            }
            catch (Exception ex)
            {
                camMessage.Result = false;
                camMessage.Message = ex.Message;
            }

            return camMessage;
        }
        #endregion

        #region Modeling Import
        // Modeling UDCD Value
        public int UserDataCollectDef_ValueDataPoint(DataTable table)
        {
            int successCnt = 0;

            csiDocument ResponseDocument = null;            
            csiObject InputData1 = null;
            csiObject InputData2 = null;            
            csiSubentity ObjectChanges = null;
            csiSubentityList DataPoints = null;
            csiSubentity listItem = null;            

            try
            {
                CreateSession();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "세션 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

            try
            {
                foreach (DataRow dr in table.Rows)
                {
                    // Set Service Type
                    CreateDocumentandService("UserDataCollectionDefMaintDoc", "UserDataCollectionDefMaint");

                    //Set InputData 1
                    InputData1 = gService.inputData();
                    InputData1.dataField("SyncName").setValue(dr["User Data Name"].ToString());
                    InputData1.dataField("SyncRevision").setValue(dr["Revision"].ToString());

                    // Set eventName
                    gService.perform("Sync");
                    //gService.perform("NEW")

                    //' Set InputData2
                    InputData2 = gService.inputData();

                    //' Set ObjectChanges
                    ObjectChanges = InputData2.subentityField("ObjectChanges");
                    ObjectChanges.dataField("FilterTags").setValue(dr["Filter Tags"].ToString());
                    ObjectChanges.dataField("Name").setValue(dr["User Data Name"].ToString());
                    ObjectChanges.dataField("Revision").setValue(dr["Revision"].ToString());
                    ObjectChanges.dataField("DataPointLayout").setValue(dr["DataPointLayout"].ToString());

                    //' Set Data Points
                    DataPoints = ObjectChanges.subentityList("DataPoints");

                    //' Set ListItem Loop
                    listItem = DataPoints.appendItem();
                    listItem.setObjectType("ValueDataPointChanges");
                    listItem.dataField("Name").setValue(dr["Name"].ToString());
                    listItem.dataField("RowPosition").setValue(dr["RowPosition"].ToString());
                    listItem.dataField("ColumnPosition").setValue(dr["ColumnPosition"].ToString());
                    listItem.dataField("DataType").setValue(dr["DataType"].ToString());
                    if (dr["DataType"].ToString() == "7")
                    {
                        listItem.dataField("BooleanTrue").setValue(dr["BooleanTrue"].ToString());
                        listItem.dataField("BooleanFalse").setValue(dr["BooleanFalse"].ToString());
                    }
                    listItem.dataField("IsRequired").setValue(dr["IsRequired"].ToString());
                    listItem.dataField("LowerLimit").setValue(dr["LowerLimit"].ToString());
                    listItem.dataField("UpperLimit").setValue(dr["UpperLimit"].ToString());
                    listItem.dataField("IsLimitOverrideAllowed").setValue(dr["IsLimitOverrideAllowed"].ToString());
                    listItem.dataField("MapToUserAttribute").setValue(dr["MapToUserAttribute"].ToString());
                    listItem.dataField("AttributeName").setValue(dr["AttributeName"].ToString());

                    // Service Excute and request Completion Msg
                    gService.setExecute();
                    gService.requestData().requestField("CompletionMsg");

                    // Print XML Dcoument
                    PrintDoc(gDocument.asXML(), true);
                    ResponseDocument = gDocument.submit();
                    PrintDoc(ResponseDocument.asXML(), false);
                    ErrorsCheck(ResponseDocument);

                    dr.BeginEdit();
                    if (camMessage.Result)
                    {
                        csiService csiservice = ResponseDocument.getService();
                        //if (csiservice != null && (dr["Container"] ?? "").ToString() == "Auto")
                        if (csiservice != null)
                        {
                            csiDataField csidatafield = (csiDataField)csiservice.responseData().getResponseFieldByName("CompletionMsg");
                            //dr["Container"] = csidatafield.getValue().Split(new char[] { ' ' })[0].Trim();
                        }
                        successCnt++;
                    }
                    else
                    {
                        //dr["Container"] = "";
                    }
                    dr["Result"] = camMessage.Message;
                    dr["BoolResult"] = camMessage.Result;
                    dr.EndEdit();
                }
            }
            catch(Exception ex)
            {
                camMessage.Result = false;
                camMessage.Message = ex.Message;
            }

            DestroySession();

            return successCnt;
        }

        // Modeling UDCD Object
        public int UserDataCollectDef_ObjectDataPoint(DataTable table)
        {
            int successCnt = 0;

            csiDocument ResponseDocument = null;
            csiObject InputData1 = null;
            csiObject InputData2 = null;
            csiSubentity ObjectChanges = null;
            csiSubentityList DataPoints = null;
            csiSubentity listItem = null;
            csiNamedSubentity ObjectGroup = null;

            try
            {
                CreateSession();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "세션 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

            try
            {
                foreach (DataRow dr in table.Rows)
                {
                    // Set Service Type
                    CreateDocumentandService("UserDataCollectionDefMaintDoc", "UserDataCollectionDefMaint");

                    //Set InputData 1
                    InputData1 = gService.inputData();
                    InputData1.dataField("SyncName").setValue(dr["User Data Name"].ToString());
                    InputData1.dataField("SyncRevision").setValue(dr["Revision"].ToString());

                    // Set eventName
                    gService.perform("Sync");
                    //gService.perform("NEW")

                    //' Set InputData2
                    InputData2 = gService.inputData();

                    //' Set ObjectChanges
                    ObjectChanges = InputData2.subentityField("ObjectChanges");
                    ObjectChanges.dataField("FilterTags").setValue(dr["Filter Tags"].ToString());
                    ObjectChanges.dataField("DataPointLayout").setValue(dr["DataPointLayout"].ToString());

                    //' Set Data Points
                    DataPoints = ObjectChanges.subentityList("DataPoints");

                    //' Set ListItem Loop
                    listItem = DataPoints.appendItem();
                    listItem.setObjectType("ObjectDataPointChanges");
                    listItem.dataField("Name").setValue(dr["Name"].ToString());
                    listItem.dataField("RowPosition").setValue(dr["RowPosition"].ToString());
                    listItem.dataField("ColumnPosition").setValue(dr["ColumnPosition"].ToString());
                    listItem.dataField("DataType").setValue(dr["DataType"].ToString());
                    listItem.dataField("IsRequired").setValue(dr["IsRequired"].ToString());
                    listItem.dataField("DisplayMode").setValue(dr["DisplayMode"].ToString());
                    ObjectGroup = listItem.namedSubentityField("ObjectGroup");
                    ObjectGroup.setObjectType("NamedObjectGroup");
                    ObjectGroup.setName(dr["ObjectGroup"].ToString());
                    listItem.dataField("ObjectSelValType").setValue(dr["ObjectSelValType"].ToString());
                    listItem.dataField("ObjectType").setValue("5330");
                    ObjectChanges.dataField("Name").setValue(dr["User Data Name"].ToString());
                    ObjectChanges.dataField("Revision").setValue(dr["Revision"].ToString());

                    // Service Excute and request Completion Msg
                    gService.setExecute();
                    gService.requestData().requestField("CompletionMsg");

                    // Print XML Dcoument
                    PrintDoc(gDocument.asXML(), true);
                    ResponseDocument = gDocument.submit();
                    PrintDoc(ResponseDocument.asXML(), false);
                    ErrorsCheck(ResponseDocument);

                    dr.BeginEdit();
                    if (camMessage.Result)
                    {
                        csiService csiservice = ResponseDocument.getService();
                        //if (csiservice != null && (dr["Container"] ?? "").ToString() == "Auto")
                            if (csiservice != null)
                            {
                            csiDataField csidatafield = (csiDataField)csiservice.responseData().getResponseFieldByName("CompletionMsg");
                            //dr["Container"] = csidatafield.getValue().Split(new char[] { ' ' })[0].Trim();
                        }
                        successCnt++;
                    }
                    else
                    {
                        //dr["Container"] = "";
                    }
                    dr["Result"] = camMessage.Message;
                    dr["BoolResult"] = camMessage.Result;
                    dr.EndEdit();
                }
            }
            catch (Exception ex)
            {
                camMessage.Result = false;
                camMessage.Message = ex.Message;
            }

            DestroySession();

            return successCnt;
        }

        public int UserDataCollectDef_ResourceDataPoint(DataTable table)
        {
            int successCnt = 0;

            csiDocument ResponseDocument = null;
            csiObject InputData1 = null;
            csiObject InputData2 = null;
            csiSubentity ObjectChanges = null;
            csiSubentityList DataPoints = null;
            csiSubentity listItem = null;
            csiNamedSubentity ObjectGroup = null;

            try
            {
                CreateSession();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "세션 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

            try
            {
                foreach (DataRow dr in table.Rows)
                {
                    // Set Service Type
                    CreateDocumentandService("UserDataCollectionDefMaintDoc", "UserDataCollectionDefMaint");

                    //Set InputData 1
                    InputData1 = gService.inputData();
                    InputData1.dataField("SyncName").setValue(dr["User Data Name"].ToString());
                    InputData1.dataField("SyncRevision").setValue(dr["Revision"].ToString());

                    // Set eventName
                    gService.perform("Sync");
                    //gService.perform("NEW")

                    //' Set InputData2
                    InputData2 = gService.inputData();

                    //' Set ObjectChanges
                    ObjectChanges = InputData2.subentityField("ObjectChanges");
                    ObjectChanges.dataField("FilterTags").setValue(dr["Filter Tags"].ToString());
                    ObjectChanges.dataField("DataPointLayout").setValue(dr["DataPointLayout"].ToString());

                    //' Set Data Points
                    DataPoints = ObjectChanges.subentityList("DataPoints");

                    //' Set ListItem Loop
                    listItem = DataPoints.appendItem();
                    listItem.setObjectType("ObjectDataPointChanges");
                    listItem.dataField("Name").setValue(dr["Name"].ToString());
                    listItem.dataField("RowPosition").setValue(dr["RowPosition"].ToString());
                    listItem.dataField("ColumnPosition").setValue(dr["ColumnPosition"].ToString());
                    listItem.dataField("DataType").setValue(dr["DataType"].ToString());
                    listItem.dataField("IsRequired").setValue(dr["IsRequired"].ToString());
                    listItem.dataField("DisplayMode").setValue(dr["DisplayMode"].ToString());
                    ObjectGroup = listItem.namedSubentityField("ObjectGroup");
                    //ObjectGroup.setObjectType("NamedObjectGroup");
                    ObjectGroup.setObjectType("ResourceGroup");
                    ObjectGroup.setName(dr["ObjectGroup"].ToString());
                    listItem.dataField("ObjectSelValType").setValue(dr["ObjectSelValType"].ToString());
                    listItem.dataField("ObjectType").setValue("5350");
                    ObjectChanges.dataField("Name").setValue(dr["User Data Name"].ToString());
                    ObjectChanges.dataField("Revision").setValue(dr["Revision"].ToString());

                    // Service Excute and request Completion Msg
                    gService.setExecute();
                    gService.requestData().requestField("CompletionMsg");

                    // Print XML Dcoument
                    PrintDoc(gDocument.asXML(), true);
                    ResponseDocument = gDocument.submit();
                    PrintDoc(ResponseDocument.asXML(), false);
                    ErrorsCheck(ResponseDocument);

                    dr.BeginEdit();
                    if (camMessage.Result)
                    {
                        csiService csiservice = ResponseDocument.getService();
                        //if (csiservice != null && (dr["Container"] ?? "").ToString() == "Auto")
                        if (csiservice != null)
                        {
                            csiDataField csidatafield = (csiDataField)csiservice.responseData().getResponseFieldByName("CompletionMsg");
                            //dr["Container"] = csidatafield.getValue().Split(new char[] { ' ' })[0].Trim();
                        }
                        successCnt++;
                    }
                    else
                    {
                        //dr["Container"] = "";
                    }
                    dr["Result"] = camMessage.Message;
                    dr["BoolResult"] = camMessage.Result;
                    dr.EndEdit();
                }
            }
            catch (Exception ex)
            {
                camMessage.Result = false;
                camMessage.Message = ex.Message;
            }

            DestroySession();

            return successCnt;
        }

        #endregion

        #region Container Function

        public int ContainerStart(DataTable table)
        {
            int successCnt = 0;

            csiDocument ResponseDocument = null;
            csiObject InputData = null;
            csiSubentity Details = null;
            csiSubentity CurrentStatusDetails = null;

            try
            {
                CreateSession();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "세션 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

            try
            {
                foreach (DataRow dr in table.Rows)
                {
                    // Set Service Type
                    CreateDocumentandService("StartDoc", "Start");

                    // Set Input Data
                    InputData = gService.inputData();

                    //Set CurrentStatusDetails
                    CurrentStatusDetails = InputData.subentityField("CurrentStatusDetails");
                    if (dr["Workflow Rev"].ToString() == "")
                    {
                        CurrentStatusDetails.revisionedObjectField("Workflow").setRef((dr["Workflow"] ?? "").ToString(), "", true);
                    }
                    else
                    {
                        CurrentStatusDetails.revisionedObjectField("Workflow").setRef((dr["Workflow"] ?? "").ToString(), (dr["Workflow Rev"] ?? "").ToString(), true);
                    }

                    // Set Start Details
                    Details = InputData.subentityField("Details");

                    //Set Auto Container Name
                    if ((dr["Container"] ?? "").ToString() == "Auto")
                    {
                        Details.dataField("AutoNumber").setValue("True");
                        Details.dataField("IsContainer").setValue("True");
                    }
                    else
                    {
                        Details.dataField("ContainerName").setValue((dr["Container"] ?? "").ToString());
                    }

                    // Set Start Element
                    Details.namedObjectField("Owner").setRef((dr["Owner"] ?? "").ToString());
                    Details.dataField("Qty").setValue((dr["Qty"] ?? "0").ToString());
                    Details.namedObjectField("StartReason").setRef((dr["StartReason"] ?? "").ToString());
                    Details.namedObjectField("UOM").setRef((dr["UOM"] ?? "").ToString());
                    Details.namedObjectField("Level").setRef((dr["Level"] ?? "").ToString());
                    Details.namedObjectField("PriorityCode").setRef((dr["PriorityCode"] ?? "").ToString());
                    Details.namedObjectField("MfgOrder").setRef((dr["MfgOrder"] ?? "").ToString());
                    if (dr["Product Rev"].ToString() == "")
                    {
                        Details.revisionedObjectField("Product").setRef((dr["Product"] ?? "").ToString(), "", true);
                    }
                    else
                    {
                        Details.revisionedObjectField("Product").setRef((dr["Product"] ?? "").ToString(), (dr["Product Rev"] ?? "").ToString(), true);

                    }
                    Details.dataField("ContainerComment").setValue((dr["Comments"] ?? "").ToString());

                    // Set Factory 
                    InputData.namedObjectField("Factory").setRef((dr["Factory"] ?? "").ToString());

                    // Service Excute and request Completion Msg
                    gService.setExecute();
                    gService.requestData().requestField("CompletionMsg");

                    // Print XMl Dcoument
                    PrintDoc(gDocument.asXML(), true);
                    ResponseDocument = gDocument.submit();
                    PrintDoc(ResponseDocument.asXML(), false);

                    ErrorsCheck(ResponseDocument);

                    dr.BeginEdit();
                    if (camMessage.Result)
                    {
                        csiService csiservice = ResponseDocument.getService();
                        if (csiservice != null && (dr["Container"] ?? "").ToString() == "Auto")
                        {
                            csiDataField csidatafield = (csiDataField)csiservice.responseData().getResponseFieldByName("CompletionMsg");
                            dr["Container"] = csidatafield.getValue().Split(new char[] { ' ' })[0].Trim();
                        }
                        successCnt++;
                    }
                    else
                    {
                        dr["Container"] = "";
                    }
                    dr["Result"] = camMessage.Message;
                    dr["BoolResult"] = camMessage.Result;
                    dr.EndEdit();
                }
            }
            catch (Exception ex)
            {
                camMessage.Result = false;
                camMessage.Message = ex.Message;
            }

            DestroySession();

            return successCnt;
        }

        public int StartTwoLevel(DataTable table)
        {
            int successCnt = 0;

            csiDocument ResponseDocument = null;
            csiObject InputData = null;
            csiSubentity Details = null;
            csiSubentity CurrentStatusDetails = null;
            csiSubentity ChildContainers = null;

            try
            {
                CreateSession();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "세션 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

            try
            {
                foreach (DataRow dr in table.Rows)
                {
                    // Set Service Type
                    CreateDocumentandService("StartDoc", "Start");

                    // Set Input Data
                    InputData = gService.inputData();

                    // Set CurrentStatusDetails
                    CurrentStatusDetails = InputData.subentityField("CurrentStatusDetails");
                    if (dr["Workflow Rev"].ToString() == "")
                    {
                        CurrentStatusDetails.revisionedObjectField("Workflow").setRef((dr["Workflow"] ?? "").ToString(), "", true);
                    }
                    else
                    {
                        CurrentStatusDetails.revisionedObjectField("Workflow").setRef((dr["Workflow"] ?? "").ToString(), (dr["Workflow Rev"] ?? "").ToString(), true);

                    }

                    // Set Start Details
                    Details = InputData.subentityField("Details");

                    // Set Container Details
                    if ((dr["Container"] ?? "").ToString() == "Auto")
                    {
                        Details.dataField("AutoNumber").setValue("True");
                    }
                    else
                    {
                        Details.dataField("ContainerName").setValue((dr["Container"] ?? "").ToString());
                    }
                    Details.namedObjectField("Level").setRef((dr["Level"] ?? "").ToString());
                    Details.namedObjectField("Owner").setRef((dr["Owner"] ?? "").ToString());
                    Details.namedObjectField("StartReason").setRef((dr["StartReason"] ?? "").ToString());
                    Details.namedObjectField("MfgOrder").setRef((dr["MfgOrder"] ?? "").ToString());
                    if (dr["Product Rev"].ToString() == "")
                    {
                        Details.revisionedObjectField("Product").setRef((dr["Product"] ?? "").ToString(), "", true);
                    }
                    else
                    {
                        Details.revisionedObjectField("Product").setRef((dr["Product"] ?? "").ToString(), (dr["Product Rev"] ?? "").ToString(), true);

                    }
                    Details.namedObjectField("PriorityCode").setRef((dr["PriorityCode"] ?? "").ToString());
                    Details.dataField("ContainerComment").setValue((dr["Comments"] ?? "").ToString());

                    InputData.namedObjectField("Factory").setRef((dr["Factory"] ?? "").ToString());

                    // Set Child Container info
                    Details.dataField("ChildAutoNumber").setValue("True");
                    Details.dataField("ChildCount").setValue((dr["ChildCount"] ?? "0").ToString());
                    Details.dataField("DefaultChildQty").setValue((dr["ChildQty"] ?? "0").ToString());

                    // Set CildContainers 
                    Int32 ChildCount = Int32.Parse((dr["ChildCount"]).ToString());
                    ;

                    for (int i = 1; i <= ChildCount; i++)
                    {
                        ChildContainers = Details.subentityList("ChildContainers").appendItem();
                        ChildContainers.dataField("ContainerName").setValue("");
                        ChildContainers.namedObjectField("Level").setRef((dr["ChildLevel"] ?? "").ToString());
                        ChildContainers.dataField("Qty").setValue((dr["ChildQty"] ?? "0").ToString());
                        ChildContainers.namedObjectField("UOM").setRef((dr["ChildUOM"] ?? "").ToString());
                    }

                    // Service Excute and request Completion Msg
                    gService.setExecute();
                    gService.requestData().requestField("CompletionMsg");
                    gService.requestData().requestField("ACEMessage");
                    gService.requestData().requestField("ACEStatus");

                    // Print XMl Dcoument
                    PrintDoc(gDocument.asXML(), true);
                    ResponseDocument = gDocument.submit();
                    PrintDoc(ResponseDocument.asXML(), false);

                    ErrorsCheck(ResponseDocument);

                    dr.BeginEdit();
                    if (camMessage.Result)
                    {
                        csiService csiservice = ResponseDocument.getService();
                        if (csiservice != null && (dr["Container"] ?? "").ToString() == "Auto")
                        {
                            csiDataField csidatafield = (csiDataField)csiservice.responseData().getResponseFieldByName("CompletionMsg");
                            dr["Container"] = csidatafield.getValue().Split(new char[] { ' ' })[0].Trim();
                        }
                        successCnt++;
                    }
                    else
                    {
                        dr["Container"] = "";
                    }

                    dr["Result"] = camMessage.Message;
                    dr["BoolResult"] = camMessage.Result;
                    dr.EndEdit();
                }
            }
            catch (Exception ex)
            {
                camMessage.Result = false;
                camMessage.Message = ex.Message;
            }

            DestroySession();

            return successCnt;
        }

        public int PrintContainerLabel(DataTable table)
        {
            int successCnt = 0;

            csiDocument ResponseDocument = null;
            csiObject InputData = null;

            try
            {
                CreateSession();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "세션 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

            try
            {
                foreach (DataRow dr in table.Rows)
                {
                    // Set Service Type
                    CreateDocumentandService("PrintContainerLabelDoc", "PrintContainerLabel");

                    // Set Input Data
                    InputData = gService.inputData();
                    InputData.namedObjectField("Container").setRef((dr["Container"] ?? "").ToString());
                    InputData.dataField("LabelCount").setValue((dr["Label Count"] ?? "").ToString());

                    if (dr["Printer Label Rev"].ToString() == "")
                    {
                        InputData.revisionedObjectField("PrinterLabelDefinition").setRef((dr["Printer Label Definition"] ?? "").ToString(), "", true);
                    }
                    else
                    {
                        InputData.revisionedObjectField("PrinterLabelDefinition").setRef((dr["Printer Label Definition"] ?? "").ToString(), (dr["Printer Label Rev"] ?? "").ToString(), true);
                    }
                    InputData.namedObjectField("PrintQueue").setRef((dr["Print Queue"] ?? "").ToString());
                    InputData.namedObjectField("TaskContainer").setRef((dr["Container"] ?? "").ToString());

                    // Service Excute and request Completion Msg
                    gService.setExecute();
                    gService.requestData().requestField("CompletionMsg");

                    // Print XMl Dcoument
                    PrintDoc(gDocument.asXML(), true);
                    ResponseDocument = gDocument.submit();
                    PrintDoc(ResponseDocument.asXML(), false);

                    ErrorsCheck(ResponseDocument);

                    dr.BeginEdit();
                    if (camMessage.Result)
                    {
                        csiService csiservice = ResponseDocument.getService();
                        if (csiservice != null && (dr["Container"] ?? "").ToString() == "Auto")
                        {
                            csiDataField csidatafield = (csiDataField)csiservice.responseData().getResponseFieldByName("CompletionMsg");
                            dr["Container"] = csidatafield.getValue().Split(new char[] { ' ' })[0].Trim();
                        }
                        successCnt++;
                    }
                    else
                    {
                        dr["Container"] = "";
                    }

                    dr["Result"] = camMessage.Message;
                    dr["BoolResult"] = camMessage.Result;
                    dr.EndEdit();
                }
            }
            catch (Exception ex)
            {
                camMessage.Result = false;
                camMessage.Message = ex.Message;
            }

            DestroySession();

            return successCnt;
        }

        public CamstarMessage ContainerHoldLoop(string containerName, string holdReasonName)
        {
            csiDocument ResponseDocument = null;
            csiObject InputData = null;

            try
            {
                CreateDocumentandService("HoldDoc", "Hold");

                InputData = gService.inputData();

                InputData.namedObjectField("Container").setRef(containerName);
                InputData.namedObjectField("HoldReason").setRef(holdReasonName);

                gService.setExecute();
                gService.requestData().requestField("CompletionMsg");

                PrintDoc(gDocument.asXML(), true);
                ResponseDocument = gDocument.submit();
                PrintDoc(ResponseDocument.asXML(), false);

                ErrorsCheck(ResponseDocument);
            }
            catch (Exception ex)
            {
                camMessage.Result = false;
                camMessage.Message = ex.Message;
            }

            return camMessage;
        }

        public CamstarMessage ContainerReleaseLoop(string containerName, string releaseReasonName)
        {
            csiDocument ResponseDocument = null;
            csiObject InputData = null;

            try
            {
                CreateDocumentandService("ReleaseDoc", "Release");

                InputData = gService.inputData();

                InputData.namedObjectField("Container").setRef(containerName);
                InputData.namedObjectField("ReleaseReason").setRef(releaseReasonName);

                gService.setExecute();
                gService.requestData().requestField("CompletionMsg");

                PrintDoc(gDocument.asXML(), true);
                ResponseDocument = gDocument.submit();
                PrintDoc(ResponseDocument.asXML(), false);

                ErrorsCheck(ResponseDocument);
            }
            catch (Exception ex)
            {
                camMessage.Result = false;
                camMessage.Message = ex.Message;
            }

            return camMessage;
        }

        #endregion

        #region RY_ExcuteTask
        public int WorkStart(string taskListName, string resourceName, DataTable table, bool isSessionCreate = true)
        {
            int successCnt = 0;

            csiDocument ResponseDocument = null;
            csiObject InputData = null;
            csiNamedSubentity CalledByTransactionTask;
            csiParentInfo TaskList = null;

            try
            {
                if (isSessionCreate)
                {
                    CreateSession();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "세션 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

            try
            {
                foreach (DataRow dr in table.Rows)
                {
                    // Set Service Type
                    CreateDocumentandService("MoveInDoc", "MoveIn");

                    // Set Input Data
                    InputData = gService.inputData();

                    //Set Called By Transaction Task
                    CalledByTransactionTask = InputData.namedSubentityField("CalledByTransactionTask");
                    CalledByTransactionTask.setName("작업시작");
                    CalledByTransactionTask.setObjectType("InstructionItem");
                    TaskList = CalledByTransactionTask.parentInfo();
                    TaskList.setRevisionedObjectRef(taskListName, "", true);

                    InputData.dataField("ClearLocation").setValue("False");
                    InputData.namedObjectField("Container").setRef((dr["Container"] ?? "").ToString());
                    InputData.namedObjectField("Resource").setRef(resourceName);
                    InputData.namedObjectField("TaskContainer").setRef((dr["Container"] ?? "").ToString());

                    // Service Excute and request Completion Msg
                    gService.setExecute();
                    gService.requestData().requestField("CompletionMsg");
                    gService.requestData().requestField("ACEMessage");
                    gService.requestData().requestField("ACEStatus");

                    // Print XMl Dcoument
                    PrintDoc(gDocument.asXML(), true);
                    ResponseDocument = gDocument.submit();
                    PrintDoc(ResponseDocument.asXML(), false);

                    ErrorsCheck(ResponseDocument);

                    dr.BeginEdit();
                    dr["StartResult"] = camMessage.Message;
                    dr["StartBoolResult"] = camMessage.Result;
                    dr.EndEdit();
                }
            }
            catch (Exception ex)
            {
                camMessage.Result = false;
                camMessage.Message = ex.Message;
            }

            if (isSessionCreate)
            {
                DestroySession();
            }

            return successCnt;
        }

        public int ComboBoxTask(DataTable table)
        {
            int successCnt = 0;

            csiDocument ResponseDocument;
            csiObject InputData;
            csiRevisionedObject DataCollectionDef;
            csiSubentity ParametricData;
            csiSubentityList DataPointDetails;
            csiSubentity listItem;
            csiNamedSubentity DataPoint;
            csiParentInfo DataPointParentInfo;
            csiNamedSubentity NDOValue;
            csiNamedSubentity Task;
            csiParentInfo TaskParentInfo;
            csiRevisionedObject TaskList;

            try
            {
                CreateSession();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "세션 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

            try
            {
                foreach (DataRow dr in table.Rows)
                {
                    // Set Service Type
                    CreateDocumentandService("ExecuteTaskDoc", "ExecuteTask");

                    // Set Input Data
                    InputData = gService.inputData();
                    InputData.namedObjectField("Container").setRef((dr["Container"] ?? "").ToString());

                    // Set Data Collection Def
                    DataCollectionDef = InputData.revisionedObjectField("DataCollectionDef");
                    DataCollectionDef.setObjectType("UserDataCollectionDef");
                    DataCollectionDef.setRef((dr["UDC"] ?? "").ToString(), "", true);

                    // Set Prametric Data
                    ParametricData = InputData.subentityField("ParametricData");
                    ParametricData.createObject("DataPointSummary");
                    DataPointDetails = ParametricData.subentityList("DataPointDetails");

                    // Set listItem Loop (반복해야하는 부분)
                    listItem = DataPointDetails.appendItem();
                    listItem.setObjectType("DataPointDetails");
                    DataPoint = listItem.namedSubentityField("DataPoint");
                    DataPoint.setName((dr["Task Name"] ?? "").ToString());
                    DataPointParentInfo = DataPoint.parentInfo();
                    DataPointParentInfo.setObjectType("UserDataCollectionDef");
                    DataPointParentInfo.setRevisionedObjectRef((dr["UDC"] ?? "").ToString(), "", true);
                    listItem.dataField("DataType").setValue("5"); // 선택형 Task의 경우 Data Type 5로 고정
                    NDOValue = listItem.namedSubentityField("NDOValue");
                    NDOValue.setName((dr["구분"] ?? "").ToString());
                    NDOValue.setObjectType("NamedObjectGroup");

                    // Set Task
                    Task = InputData.namedSubentityField("Task");
                    Task.setName("Data1"); // 실행하는 Task의 이름
                    TaskParentInfo = Task.parentInfo();
                    TaskParentInfo.setObjectType("TaskList");
                    DataPointParentInfo.setRevisionedObjectRef((dr["UDC"] ?? "").ToString(), "", true);

                    // Set Task List
                    TaskList = InputData.revisionedObjectField("TaskList");
                    TaskList.setObjectType("TaskList");
                    TaskList.setRef((dr["UDC"] ?? "").ToString(), "", true);


                    // Service Excute and request Completion Msg
                    gService.setExecute();
                    gService.requestData().requestField("CompletionMsg");
                    gService.requestData().requestField("ACEMessage");
                    gService.requestData().requestField("ACEStatus");

                    // Print XMl Dcoument
                    PrintDoc(gDocument.asXML(), true);
                    ResponseDocument = gDocument.submit();
                    PrintDoc(ResponseDocument.asXML(), false);

                    ErrorsCheck(ResponseDocument);

                    dr.BeginEdit();
                    if (camMessage.Result)
                    {
                        csiService csiservice = ResponseDocument.getService();
                        if (csiservice != null && (dr["Container"] ?? "").ToString() == "Auto")
                        {
                            csiDataField csidatafield = (csiDataField)csiservice.responseData().getResponseFieldByName("CompletionMsg");
                            dr["Container"] = csidatafield.getValue().Split(new char[] { ' ' })[0].Trim();
                        }
                        successCnt++;
                    }
                    else
                    {
                        dr["Container"] = "";
                    }
                    dr["Result"] = camMessage.Message;
                    dr["BoolResult"] = camMessage.Result;
                    dr.EndEdit();
                }
            }
            catch (Exception ex)
            {
                camMessage.Result = false;
                camMessage.Message = ex.Message;
            }

            DestroySession();

            return successCnt;
        }

        public int KeyInTask(DataTable table)
        {
            int successCnt = 0;

            csiDocument ResponseDocument;
            csiObject InputData;
            csiRevisionedObject DataCollectionDef;
            csiSubentity ParametricData;
            csiSubentityList DataPointDetails;
            csiSubentity listItem;
            csiNamedSubentity DataPoint;
            csiParentInfo DataPointParentInfo;
            //csiNamedSubentity NDOValue;
            csiNamedSubentity Task;
            csiParentInfo TaskParentInfo;
            csiRevisionedObject TaskList;

            try
            {
                CreateSession();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "세션 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

            try
            {
                foreach (DataRow dr in table.Rows)
                {
                    // Set Service Type
                    CreateDocumentandService("ExecuteTaskDoc", "ExecuteTask");

                    // Set Input Data
                    InputData = gService.inputData();
                    InputData.namedObjectField("Container").setRef((dr["Container"] ?? "").ToString());

                    // Set Data Collection Def
                    DataCollectionDef = InputData.revisionedObjectField("DataCollectionDef");
                    DataCollectionDef.setObjectType("UserDataCollectionDef");
                    DataCollectionDef.setRef((dr["UDC"] ?? "").ToString(), "", true);

                    // Set Prametric Data
                    ParametricData = InputData.subentityField("ParametricData");
                    ParametricData.createObject("DataPointSummary");
                    DataPointDetails = ParametricData.subentityList("DataPointDetails");

                    // Set listItem Loop (반복해야하는 부분)
                    listItem = DataPointDetails.appendItem();
                    listItem.setObjectType("DataPointDetails");
                    DataPoint = listItem.namedSubentityField("DataPoint");
                    DataPoint.setName("Setting 두께");
                    DataPointParentInfo = DataPoint.parentInfo();
                    DataPointParentInfo.setObjectType("UserDataCollectionDef");
                    DataPointParentInfo.setRevisionedObjectRef((dr["UDC"] ?? "").ToString(), "", true);
                    listItem.dataField("DataType").setValue("1"); // 1 : int, 4 : string, 9 : decimal
                    listItem.dataField("DataValue").setValue((dr["Setting 두께"] ?? "").ToString()); // 선택형 Task의 경우 Data Type 5로 고정

                    // Set Task
                    Task = InputData.namedSubentityField("Task");
                    Task.setName("Setting 두께"); // 실행하는 Task의 이름
                    TaskParentInfo = Task.parentInfo();
                    TaskParentInfo.setObjectType("TaskList");
                    DataPointParentInfo.setRevisionedObjectRef((dr["UDC"] ?? "").ToString(), "", true);

                    // Set Task List
                    TaskList = InputData.revisionedObjectField("TaskList");
                    TaskList.setObjectType("TaskList");
                    TaskList.setRef((dr["UDC"] ?? "").ToString(), "", true);


                    // Service Excute and request Completion Msg
                    gService.setExecute();
                    gService.requestData().requestField("CompletionMsg");
                    gService.requestData().requestField("ACEMessage");
                    gService.requestData().requestField("ACEStatus");

                    // Print XMl Dcoument
                    PrintDoc(gDocument.asXML(), true);
                    ResponseDocument = gDocument.submit();
                    PrintDoc(ResponseDocument.asXML(), false);

                    ErrorsCheck(ResponseDocument);

                    dr.BeginEdit();
                    if (camMessage.Result)
                    {
                        csiService csiservice = ResponseDocument.getService();
                        if (csiservice != null && (dr["Container"] ?? "").ToString() == "Auto")
                        {
                            csiDataField csidatafield = (csiDataField)csiservice.responseData().getResponseFieldByName("CompletionMsg");
                            dr["Container"] = csidatafield.getValue().Split(new char[] { ' ' })[0].Trim();
                        }
                        successCnt++;
                    }
                    else
                    {
                        dr["Container"] = "";
                    }
                    dr["Result"] = camMessage.Message;
                    dr["BoolResult"] = camMessage.Result;
                    dr.EndEdit();
                }
            }
            catch (Exception ex)
            {
                camMessage.Result = false;
                camMessage.Message = ex.Message;
            }

            DestroySession();

            return successCnt;
        }

        public int ExecuteTaskByUDC(string taskListName, string taskItemName, string dataCollectionName, DataTable table, DataView collectionView, bool isSessionCreate = true)
        {
            int successCnt = 0;

            csiDocument ResponseDocument;
            csiObject InputData;
            csiRevisionedObject DataCollectionDef;
            csiSubentity ParametricData;
            csiSubentityList DataPointDetails;
            csiSubentity listItem;
            csiNamedSubentity DataPoint;
            csiParentInfo DataPointParentInfo;
            csiNamedSubentity NDOValue;
            csiNamedSubentity Task;
            csiParentInfo TaskParentInfo;
            csiRevisionedObject TaskList;

            try
            {
                if (isSessionCreate)
                {
                    CreateSession();
                }      
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "세션 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

            try
            {
                foreach (DataRow dr in table.Rows)
                {
                    // Set Service Type
                    CreateDocumentandService("ExecuteTaskDoc", "ExecuteTask");

                    // Set Input Data
                    InputData = gService.inputData();
                    InputData.namedObjectField("Container").setRef((dr["Container"] ?? "").ToString());

                    // Set Data Collection Def
                    DataCollectionDef = InputData.revisionedObjectField("DataCollectionDef");
                    DataCollectionDef.setObjectType("UserDataCollectionDef");
                    DataCollectionDef.setRef(dataCollectionName, "", true);

                    // Set Prametric Data
                    ParametricData = InputData.subentityField("ParametricData");
                    ParametricData.createObject("DataPointSummary");
                    DataPointDetails = ParametricData.subentityList("DataPointDetails");

                    foreach (DataRowView drv in collectionView)
                    {
                        if (dr[drv["DataPointName"].ToString()].ToString() == "") continue;

                        listItem = DataPointDetails.appendItem();
                        listItem.setObjectType("DataPointDetails");
                        DataPoint = listItem.namedSubentityField("DataPoint");
                        DataPoint.setName(drv["DataPointName"].ToString());
                        DataPointParentInfo = DataPoint.parentInfo();
                        DataPointParentInfo.setObjectType("UserDataCollectionDef");
                        DataPointParentInfo.setRevisionedObjectRef(dataCollectionName, "", true);
                        listItem.dataField("DataType").setValue(drv["DataType"].ToString()); 

                        if (drv["DataType"].ToString() == "5" && drv["NamedObjectGroupName"].ToString() != "")
                        {
                            NDOValue = listItem.namedSubentityField("NDOValue");
                            NDOValue.setName(dr[drv["DataPointName"].ToString()].ToString());
                            NDOValue.setObjectType("NamedObjectGroup");
                        }
                        else
                        {
                            listItem.dataField("DataValue").setValue(dr[drv["DataPointName"].ToString()].ToString());
                        }
                    }


                    // Set Task
                    Task = InputData.namedSubentityField("Task");
                    Task.setName(taskItemName); // 실행하는 Task의 이름
                    TaskParentInfo = Task.parentInfo();
                    TaskParentInfo.setObjectType("TaskList");
                    TaskParentInfo.setRevisionedObjectRef(taskListName, "", true);

                    // Set Task List
                    TaskList = InputData.revisionedObjectField("TaskList");
                    TaskList.setObjectType("TaskList");
                    TaskList.setRef(taskListName, "", true);

                    // Service Excute and request Completion Msg
                    gService.setExecute();
                    gService.requestData().requestField("CompletionMsg");
                    gService.requestData().requestField("ACEMessage");
                    gService.requestData().requestField("ACEStatus");

                    // Print XMl Dcoument
                    PrintDoc(gDocument.asXML(), true);
                    ResponseDocument = gDocument.submit();
                    PrintDoc(ResponseDocument.asXML(), false);

                    ErrorsCheck(ResponseDocument);

                    dr.BeginEdit();
                    dr["TaskResult"] = camMessage.Message;
                    dr["TaskBoolResult"] = camMessage.Result;
                    dr.EndEdit();
                }
            }
            catch (Exception ex)
            {
                camMessage.Result = false;
                camMessage.Message = ex.Message;
            }

            if (isSessionCreate)
            {
                DestroySession();
            }

            return successCnt;
        }

        public int WorkFinishByUDC(string taskListName, string resourceName, DataTable table, bool isSessionCreate = true)
        {
            int successCnt = 0;

            csiDocument ResponseDocument = null;
            csiObject InputData = null;
            csiNamedSubentity Task;
            csiParentInfo TaskParentInfo = null;
            csiRevisionedObject TaskList;

            try
            {
                if (isSessionCreate)
                {
                    CreateSession();
                }      
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "세션 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

            try
            {
                foreach (DataRow dr in table.Rows)
                {
                    if (dr["TaskBoolResult"].ToString() == "False" || dr["TaskBoolResult"].ToString() == "") continue;

                    // Set Service Type
                    CreateDocumentandService("ExecuteTaskDoc", "ExecuteTask");

                    // Set Input Data
                    InputData = gService.inputData();
                    InputData.namedObjectField("Container").setRef((dr["Container"] ?? "").ToString());

                    // Set Task
                    Task = InputData.namedSubentityField("Task");
                    Task.setName("작업종료");
                    TaskParentInfo = Task.parentInfo();
                    TaskParentInfo.setObjectType("TaskList");
                    TaskParentInfo.setRevisionedObjectRef(taskListName, "", true);

                    // Set Task List
                    TaskList = InputData.revisionedObjectField("TaskList");
                    TaskList.setObjectType("TaskList");
                    TaskList.setRef(taskListName, "", true);

                    // Service Excute and request Completion Msg
                    gService.setExecute();
                    gService.requestData().requestField("CompletionMsg");
                    gService.requestData().requestField("ACEMessage");
                    gService.requestData().requestField("ACEStatus");

                    // Print XMl Dcoument
                    PrintDoc(gDocument.asXML(), true);
                    ResponseDocument = gDocument.submit();
                    PrintDoc(ResponseDocument.asXML(), false);

                    ErrorsCheck(ResponseDocument);

                    dr.BeginEdit();
                    dr["EndResult"] = camMessage.Message;
                    dr["EndBoolResult"] = camMessage.Result;
                    dr.EndEdit();
                }
            }
            catch (Exception ex)
            {
                camMessage.Result = false;
                camMessage.Message = ex.Message;
            }

            if (isSessionCreate)
            {
                DestroySession();
            }
 
            return successCnt;
        }

        public string[] ExecuteTaskPassFail(string taskListName, string Container, string True_False, bool isSessionCreate)
        {
            csiDocument ResponseDocument = null;
            csiObject InputData = null;
            csiNamedSubentity Task;
            csiParentInfo TaskParentInfo = null;
            csiRevisionedObject TaskList;
            string[] ArrMessage = { "", "" };

            try
            {
                if (isSessionCreate)
                {
                    CreateSession();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "세션 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // 결과 값을 배열에 넣어서 Return
                ArrMessage[0] = "세션 오류";
                return ArrMessage;
            }

            try
            {
                // Set Service Type
                CreateDocumentandService("ExecuteTaskDoc", "ExecuteTask");

                // Set Input Data
                InputData = gService.inputData();
                InputData.namedObjectField("Container").setRef( Container );

                // Set Pass
                InputData.dataField("Pass").setValue( True_False );

                // Set Task
                Task = InputData.namedSubentityField("Task");
                Task.setName("Pass/Fail");
                TaskParentInfo = Task.parentInfo();
                TaskParentInfo.setObjectType("TaskList");
                TaskParentInfo.setRevisionedObjectRef(taskListName, "", true);

                // Set Task List
                TaskList = InputData.revisionedObjectField("TaskList");
                TaskList.setObjectType("TaskList");
                TaskList.setRef(taskListName, "", true);

                // Service Excute and request Completion Msg
                gService.setExecute();
                gService.requestData().requestField("CompletionMsg");
                gService.requestData().requestField("ACEMessage");
                gService.requestData().requestField("ACEStatus");

                // Print XMl Dcoument
                PrintDoc(gDocument.asXML(), true);
                ResponseDocument = gDocument.submit();
                PrintDoc(ResponseDocument.asXML(), false);

                ErrorsCheck(ResponseDocument);

                // 결과 값을 배열에 넣어서 Return
                ArrMessage[0] = camMessage.Result.ToString();
                ArrMessage[1] = camMessage.Message;

                //dr.BeginEdit();
                //dr["EndResult"] = camMessage.Message;
                //dr["EndBoolResult"] = camMessage.Result;
                //dr.EndEdit();
                //}
            }
            catch (Exception ex)
            {
                camMessage.Result = false;
                camMessage.Message = ex.Message;

                // 결과 값을 배열에 넣어서 Return
                ArrMessage[0] = "false";
                ArrMessage[1] = ex.Message;
            }

            if (isSessionCreate)
            {
                DestroySession();
            }

            return ArrMessage;
        }

        public int NextWorkByUDC(string taskListName, string resourceName, DataTable table, bool isSessionCreate = true)
        {
            int successCnt = 0;

            csiDocument ResponseDocument = null;
            csiObject InputData = null;
            csiNamedSubentity CalledByTransactionTask;
            csiParentInfo TaskList = null;

            try
            {
                if (isSessionCreate)
                {
                    CreateSession();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "세션 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

            try
            {
                foreach (DataRow dr in table.Rows)
                {
                    if (dr["TaskBoolResult"].ToString() == "False" || dr["TaskBoolResult"].ToString() == "") continue;
                    if (dr["EndBoolResult"].ToString() == "False" || dr["EndBoolResult"].ToString() == "") continue;

                    // Set Service Type
                    CreateDocumentandService("MoveStdDoc", "MoveStd");

                    // Set Input Data
                    InputData = gService.inputData();

                    //Set Called By Transaction Task
                    CalledByTransactionTask = InputData.namedSubentityField("CalledByTransactionTask");
                    CalledByTransactionTask.setName("다음공정으로");
                    CalledByTransactionTask.setObjectType("InstructionItem");
                    TaskList = CalledByTransactionTask.parentInfo();
                    TaskList.setRevisionedObjectRef(taskListName, "", true);

                    //InputData.dataField("ClearLocation").setValue("false");
                    InputData.namedObjectField("Container").setRef((dr["Container"] ?? "").ToString());
                    InputData.namedObjectField("Resource").setRef(resourceName);
                    InputData.namedObjectField("TaskContainer").setRef((dr["Container"] ?? "").ToString());

                    // Service Excute and request Completion Msg
                    gService.setExecute();
                    gService.requestData().requestField("CompletionMsg");
                    gService.requestData().requestField("ACEMessage");
                    gService.requestData().requestField("ACEStatus");

                    // Print XMl Dcoument
                    PrintDoc(gDocument.asXML(), true);
                    ResponseDocument = gDocument.submit();
                    PrintDoc(ResponseDocument.asXML(), false);

                    ErrorsCheck(ResponseDocument);

                    dr.BeginEdit();
                    dr["MoveStdResult"] = camMessage.Message;
                    dr["MoveStdBoolResult"] = camMessage.Result;
                    dr.EndEdit();
                }
            }
            catch (Exception ex)
            {
                camMessage.Result = false;
                camMessage.Message = ex.Message;
            }

            if (isSessionCreate)
            {
                DestroySession();
            }

            return successCnt;
        }

        #endregion

    }
}
