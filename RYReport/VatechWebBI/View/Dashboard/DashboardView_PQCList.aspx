﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DashboardView_PQCList.aspx.cs" Inherits="View_Dashboard_DashboardView_PQCList" %>

<%@ Register assembly="DevExpress.Dashboard.v22.2.Web.WebForms, Version=22.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.DashboardWeb" tagprefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0, minimal-ui" />
    <title></title>
    <link href="../assets/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link href="../framestyle.css" rel="stylesheet" type="text/css" />

    <style>
        html, body {
            margin: 0;
            height: 100%;
            overflow: hidden;
        }

        .dx-dashboard-viewer .dx-datagrid-rowsview .dx-selection > td, .dx-dashboard-viewer .dx-datagrid-rowsview .dx-selection.dx-row:hover > td {
            background-color: lightblue !important;
            color: black !important;
        }

        .dx-data-row {  
            user-select:text;  
        }  
        .dx-row-lines {  
            user-select:text!important;  
        }

    </style>
    <script type="text/javascript">

        var BO_Report = '<svg id="customReportIcon" height="24px" width="24px" version="1.1" id="Layer_1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" x="0px" y="0px" '
            + 'viewBox = "0 0 32 32" style = "enable-background:new 0 0 32 32;" xml: space="preserve" >'
            + '<style type="text/css"> '
            + '.Blue{fill:#1177D7;} '
            + '.Yellow{fill:#FFB115;} '
            + '.Red{fill:#D11C1C;} '
            + '.Green{fill:#039C23;} '
            + '.Black{fill:#727272;} '
            + '.White{fill:#FFFFFF;} '
            + '.st0{opacity:0.5;} '
            + '.st1{opacity:0.75;} '
            + '.st2{display:none;} '
            + '.st3{display:inline;fill:#FFB115;} '
            + '.st4{display:inline;} '
            + '.st5{display:inline;opacity:0.75;} '
            + '.st6{display:inline;opacity:0.5;} '
            + '.st7{display:inline;fill:#039C23;} '
            + '.st8{display:inline;fill:#D11C1C;} '
            + '.st9{display:inline;fill:#1177D7;} '
            + '.st10{display:inline;fill:#FFFFFF;} '
            + '</style> '
            + '<g id="Report"> '
            + '<path class="Yellow" d="M27,4h-3v22H8V4H5C4.4,4,4,4.4,4,5v24c0,0.6,0.4,1,1,1h22c0.6,0,1-0.4,1-1V5C28,4.4,27.6,4,27,4z"/> '
            + '<path class="Black" d="M20,4V3c0-0.6-0.4-1-1-1h-6c-0.6,0-1,0.4-1,1v1h-2v4h3h6h3V4H20z"/> '
            + '<g class="st1"> '
            + '<path class="Black" d="M10,20h12v2H10V20z M10,12h12v2H10V12z M10,16h12v2H10V16z"/> '
            + '</g> '
            + '</g>'
            + '</svg > ';

        function NotReload() {
            if ((event.ctrlKey == true && (event.keyCode == 78 || event.keyCode == 82)) || (event.keyCode == 116)) {
                event.keyCode = 0;
                event.cancelBubble = true;
                event.returnValue = false;
            }
        }
        document.onkeydown = NotReload;

        function onBeforeRender(sender, args) {
            //DevExpress.Dashboard.ResourceManager.setLocalizationMessages(
            //    { 'DashboardStringId.ParametersFormCaption': '검색 조건' }
            //);

            var sheet = document.createElement('style')
            sheet.innerHTML = ".dx-dashboard-title-toolbar .dx-item-content.dx-toolbar-item-content { font-size: 22px; font-weight: bold; color: darkslateblue; } ";
            sheet.innerHTML += ".dx-dashboard-caption-toolbar .dx-toolbar-item { font-size: 16px; font-weight: bold; color: royalblue; }";
            sheet.innerHTML += ".dx-datagrid-headers { color: white; background-color: steelblue; }";
            sheet.innerHTML += ".dx-pivotgrid .dx-pivotgrid-horizontal-headers td { color: white; background-color: steelblue; }";
            document.head.appendChild(sheet); 

            DevExpress.Dashboard.ResourceManager.registerIcon(BO_Report);




        }
        //타이틀바에 버튼 추가
        function onDashboardTitleToolbarUpdated(sender, args) {
            var items = args.Options.actionItems;
            addItem(items, "customReportIcon", OpenPop_PQC, "성적서 보기");
        }

        var itemsRequireClick;
        //아이템바에 버튼 추가
        function onItemCaptionToolbarUpdated(sender, args) {
            //var items = args.Options.actionItems;
            //addItem(items, "customReportIcon", OpenPop_PQC, "성적서 보기");
        }

        function onItemWidgetCreated(sender, args) {
            //if (args.ItemName == "gridDashboardItem1") {
            //    var grid = args.GetWidget();
            //    grid.option({
            //        /*selection: { mode: 'multiple' }*/
            //        selection: { mode: 'single' }
            //    });
            //}
            if (!itemsRequireClick[args.ItemName]) {
                itemsRequireClick[args.ItemName] = true;
                sender.UpdateItemCaptionToolbar(args.ItemName);
            }
        }

        function onDashboardInitialized(sender, args) {
            itemsRequireClick = sender.GetDashboardControl().dashboard().items()
                .map(function (value) {
                    return { item: value.componentName(), isClickRequire: false }
                })
                .reduce(function (map, obj) {
                    map[obj.item] = obj.isClickRequire;
                    return map;
                }, {});
        } 

        function addItem(items, iconID, eventHandler, hintText) {
            items.unshift({
                type: "button",
                icon: iconID,
                hint: hintText,
                click: function () { eventHandler.call(); }
            });
        }

        function OpenPop_PQC() {      
            const arrKey = ['ContainerName', 'StepEntryTxnId'];

            var urlParam = "&WorkFlowStepName=PQC";
            var selectTuple = webDashboard.GetCurrentSelection("gridDashboardItem1");

            if (selectTuple.length == 0) {
                alertify.alert("선택된 항목이 없습니다.");
                return;
            }

            var axisPoint = selectTuple[selectTuple.length - 1].GetAxisPoint();
            $.each(axisPoint.GetDimensions(), function (_, dimension) {
                const found = arrKey.find(v => v == dimension.DataMember);
                if (found != undefined) {
                    urlParam += "&" + found + "=" + axisPoint.GetDimensionValue(dimension.Id).GetValue();
                }
            })
            
            var url = "../ReportView.aspx?reportid=14" + urlParam;
            var win = window.open(url, "_blank", "toolbar=no,scrollbars=yes,resizable=yes,top=100,left=200,width=900,height=700");
        }

        function onItemMasterFilterStateChanged(sender, args) {
            if (args.ItemName == "gridDashboardItem1") {
                var dashboardParameterDialogExtension = sender.GetDashboardControl().findExtension('dashboardParameterDialog');
                var parameters = dashboardParameterDialogExtension.getParameters();
                var parameter1 = parameters.getParameterByName("pProductFamilyName");
                var parameter2 = parameters.getParameterByName("pSapCode");
                parameter1.setValue(args.Values[0][1]);
            }
            if (args.ItemName == "gridDashboardItem2") {
                var dashboardParameterDialogExtension = sender.GetDashboardControl().findExtension('dashboardParameterDialog');
                var parameters = dashboardParameterDialogExtension.getParameters();
                var parameter2 = parameters.getParameterByName("pSapCode");
                parameter2.setValue(args.Values[0][1]);
            }

            //UserTest(sender, args);
        }



    </script>
</head>
<body style="padding-top: 4px;">
    <form id="form1" runat="server">
        <div style="position: absolute; left: 0px; right: 0px; top: 4px; bottom: 0px;">
            <dx:ASPxDashboard ID="WebDashboard" runat="server" ClientInstanceName="webDashboard" WorkingMode="ViewerOnly" OnConfigureDataConnection="WebDashboard_ConfigureDataConnection" Height="100%" ClientIDMode="Static" CanCreateNewJsonDataSource="False" DashboardId="" DashboardState="" DisableHttpHandlerValidation="False" Width="100%">
                <PdfExportOptions FontInfo-GdiCharSet="1" FontInfo-Name="돋움" FontInfo-UseCustomFontInfo="True" />
                <ClientSideEvents DashboardInitialized="onDashboardInitialized" 
                    BeforeRender="onBeforeRender" 
                    ItemWidgetCreated="onItemWidgetCreated" 
                    ItemCaptionToolbarUpdated="onItemCaptionToolbarUpdated"
                    DashboardTitleToolbarUpdated="onDashboardTitleToolbarUpdated" ItemMasterFilterStateChanged="onItemMasterFilterStateChanged">
                </ClientSideEvents>

                <BackendOptions Uri=""></BackendOptions>

                <DataRequestOptions ItemDataRequestMode="Auto" ItemDataLoadingMode="Always"></DataRequestOptions>
            </dx:ASPxDashboard>
        </div>
    </form>

    <!-- jQuery  -->
    <script src="../assets/js/bootstrap.bundle.min.js"></script>
    <script src="../assets/js/jquery.slimscroll.js"></script>
    <script src="../assets/js/waves.min.js"></script>

    <script type="text/javascript">

        var cmd = "<%=pstrCmd%>";
        var menuId = "<%=pstrMenuId%>";
        var errMsg = "<%=pstrErrMsg%>";
        var isLoad = false;

        $(window).on('load', onLoad);

        function onLoad() {
            isLoad = true;
            if (errMsg != "") {
                alertify.alert(errMsg);
                errMsg = "";
            }
        }

        function SetParametersDialog(msg) {
            if (isLoad) {
                webDashboard.HideParametersDialog();
            }
        }

    </script>

    <!-- Alertify js -->
    <script src="../../plugins/alertify/js/alertify.js"></script>
</body>
</html>

