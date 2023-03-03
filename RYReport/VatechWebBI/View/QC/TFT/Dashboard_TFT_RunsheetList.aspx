﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Dashboard_TFT_RunsheetList.aspx.cs" Inherits="View_QC_TFT_Dashboard_TFT_RunsheetList" %>

<%@ Register Assembly="DevExpress.Dashboard.v22.1.Web.WebForms, Version=22.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.DashboardWeb" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0, minimal-ui" />
    <title></title>
    <link href="../../assets/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link href="../../framestyle.css" rel="stylesheet" type="text/css" />

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
            user-select: text;
        }

        .dx-row-lines {
            user-select: text !important;
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

        var colorSchemeIcon = '<svg id="colorSchemeIcon" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24"><defs><style>.dx_gray{fill:#7b7b7b;}</style></defs><path class="dx_gray" d="M12,3a9,9,0,0,0,0,18c7,0,1.35-3.13,3-5,1.4-1.59,6,4,6-4A9,9,0,0,0,12,3ZM5,10a2,2,0,1,1,2,2A2,2,0,0,1,5,10Zm3,7a2,2,0,1,1,2-2A2,2,0,0,1,8,17Zm3-8a2,2,0,1,1,2-2A2,2,0,0,1,11,9Zm5,1a2,2,0,1,1,2-2A2,2,0,0,1,16,10Z" /></svg>';

        var ZoomIcon = '<svg version="1.1" id="svgZoom" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" x="0px" y="0px" '
            + 'viewBox="0 0 32 32" style="enable-background:new 0 0 32 32;" xml:space="preserve"> '
            + '<style type="text/css"> '
            + '.Black{fill:#727272;} '
            + '</style> '
            + '<path class="Black" d="M29.7,27.3l-7.9-7.9c1.3-1.8,2.1-4,2.1-6.5c0-6.1-4.9-11-11-11C6.9,2,2,6.9,2,13s4.9,11,11,11 '
            + 'c2.4,0,4.6-0.8,6.5-2.1l7.9,7.9c0.3,0.3,0.9,0.3,1.2,0l1.2-1.2C30.1,28.2,30.1,27.6,29.7,27.3z M4,13c0-5,4-9,9-9c5,0,9,4,9,9 '
            + 's-4,9-9,9C8,22,4,18,4,13z"/> '
            + '</svg>';

        var devTheme = "light";


        function NotReload() {
            if ((event.ctrlKey == true && (event.keyCode == 78 || event.keyCode == 82)) || (event.keyCode == 116)) {
                event.keyCode = 0;
                event.cancelBubble = true;
                event.returnValue = false;
            }
        }
        document.onkeydown = NotReload;

        function onBeforeRender(sender, args) {
            DevExpress.Dashboard.ResourceManager.setLocalizationMessages(
                { 'DashboardStringId.ParametersFormCaption': '검색 조건' }
            );

            devTheme = getCookie("ry_devTheme")

            var sheet = document.createElement('style')

            sheet.innerHTML = ".dx-dashboard-title-toolbar .dx-item-content.dx-toolbar-item-content { font-size: 22px; font-weight: bold; color: darkslateblue; } ";
            sheet.innerHTML += ".dx-dashboard-caption-toolbar .dx-toolbar-item { font-size: 16px; font-weight: bold; color: royalblue; }";
            sheet.innerHTML += ".dx-datagrid-headers { color: white; background-color: steelblue; }";
            sheet.innerHTML += ".dx-pivotgrid .dx-pivotgrid-horizontal-headers td { color: white; background-color: steelblue; }";
            document.head.appendChild(sheet);

            DevExpress.Dashboard.ResourceManager.registerIcon(colorSchemeIcon);
            DevExpress.Dashboard.ResourceManager.registerIcon(ZoomIcon);
            DevExpress.Dashboard.ResourceManager.registerIcon(BO_Report);
        }


        var itemsRequireClick;
        function onItemCaptionToolbarUpdated(sender, args) {
            if (itemsRequireClick[args.ItemName]) {
                var item = args.Options.actionItems.filter(function (item) { return item.name === "multiselection" })[0];
                if (!!item) {
                    item.checked = true;
                    item.click();
                }
                itemsRequireClick[args.ItemName] = false;
            }
        }

        function onItemWidgetCreated(sender, args) {
            if (args.ItemName == "gridDashboardItem1") {
                var grid = args.GetWidget();
                grid.columnOption("StepEntryTxnId", {
                    visible: false
                });
            }

            if (!itemsRequireClick[args.ItemName]) {
                itemsRequireClick[args.ItemName] = true;
                sender.UpdateItemCaptionToolbar(args.ItemName);
            }
        }

        function onItemWidgetUpdated(sender, args) {
            if (args.ItemName == "gridDashboardItem1") {
                var grid = args.GetWidget();
                grid.columnOption("StepEntryTxnId", {
                    visible: false
                });
            }
        }

        function onDashboardInitialized(sender, args) {
            if (cmd != 'main' && webDashboard.GetParameters().GetParameterList().length > 0)
                webDashboard.ShowParametersDialog();

            itemsRequireClick = sender.GetDashboardControl().dashboard().items()
                .map(function (value) {
                    return { item: value.componentName(), isClickRequire: false }
                })
                .reduce(function (map, obj) {
                    map[obj.item] = obj.isClickRequire;
                    return map;
                }, {});
        }

        function onDashboardTitleToolbarUpdated(sender, args) {

            var items = args.Options.actionItems;
            addItem(items, "customReportIcon", OpenPop_Runsheet, "성적서 보기");

            var colorSchemaList = {
                "light": "Light",
                "dark": "Dark",
            };

            var paremetersItem = args.Options.actionItems.find(item => item.name === "parameters");
            if (paremetersItem)
                paremetersItem.icon = "svgZoom";

            args.Options.actionItems.unshift({
                type: "menu",
                icon: "colorSchemeIcon",
                hint: "Theme",
                menu: {
                    items: Object.keys(colorSchemaList).map(function (key) { return colorSchemaList[key] }),
                    type: 'list',
                    selectionMode: 'single',
                    selectedItems: [colorSchemaList["light"]],
                    itemClick: function (data, element, index) {
                        var newTheme = Object.keys(colorSchemaList)[index];

                        if (devTheme == newTheme) return;

                        setCookie("ry_devTheme", newTheme, 7);
                        saveToUrl("colorSchema", newTheme);
                        location.reload();
                    },
                    itemTemplate: function (itemData, itemIndex, itemElement) {
                        let theme = Object.keys(colorSchemaList)[itemIndex];
                        let container = document.createElement('div');
                        container.classList.add('dx-dashboard-flex-parent');

                        let imageDiv = document.createElement('div');
                        let colorScheme = theme.split(".")[0];
                        let sizeScheme = theme.split(".")[1];
                        let themeClass = 'dx-dashboard-' + colorScheme;
                        imageDiv.classList.add('dx-dashboard-fixed');
                        imageDiv.classList.add('dx-dashboard-circle');
                        imageDiv.classList.add(themeClass);
                        if (sizeScheme === 'compact') {
                            imageDiv.classList.add("dx-dashboard-compact");
                        }

                        container.appendChild(imageDiv);

                        let textDiv = document.createElement('div');
                        textDiv.innerText = colorSchemaList[theme];
                        container.appendChild(textDiv);

                        return container;
                    }
                }
            });
        }

        function getCookie(cookie_name) {
            var x, y;
            var val = document.cookie.split(';');

            for (var i = 0; i < val.length; i++) {
                x = val[i].substr(0, val[i].indexOf('='));
                y = val[i].substr(val[i].indexOf('=') + 1);
                x = x.replace(/^\s+|\s+$/g, ''); // 앞과 뒤의 공백 제거하기
                if (x == cookie_name) {
                    return unescape(y); // unescape로 디코딩 후 값 리턴
                }
            }
        }

        function setCookie(cookie_name, value, days) {
            var exdate = new Date();
            exdate.setDate(exdate.getDate() + days);
            // 설정 일수만큼 현재시간에 만료값으로 지정

            var cookie_value = escape(value) + ((days == null) ? '' : ';    expires=' + exdate.toUTCString());
            document.cookie = cookie_name + '=' + cookie_value;
        }

        function saveToUrl(key, value) {
            var uri = location.href;
            var newUrl = this.replaceUrlValue(uri, key, value);
            if (newUrl) {
                if (newUrl.length > 2000) {
                    newUrl = this.replaceUrlValue(uri, key, null);
                }
                history.replaceState({}, "", newUrl);
            }
        }

        function replaceUrlValue(uri, key, value) {
            var re = new RegExp("([?&])" + key + "=.*?(&|$)", "i");
            var separator = uri.indexOf('?') !== -1 ? "&" : "?";
            var newParameterValue = value ? key + "=" + encodeURIComponent(value) : "";
            var newUrl;
            if (uri.match(re)) {
                var separator = !!newParameterValue ? '$1' : "";
                newUrl = uri.replace(re, separator + newParameterValue + '$2');
            }
            else if (!!newParameterValue) {
                newUrl = uri + separator + newParameterValue;
            }
            return newUrl;
        }

        function addItem(items, iconID, eventHandler, hintText) {
            items.unshift({
                type: "button",
                icon: iconID,
                hint: hintText,
                click: function () { eventHandler.call(); }
            });
        }


       function OpenPop_Runsheet() {      
            const arrKey = ['ContainerName', 'StepEntryTxnId', 'ITEM_TYPE'];

            var urlParam = "";
            var itemType = "";


            var selectTuple = webDashboard.GetCurrentSelection("gridDashboardItem1");

            if (selectTuple.length == 0) {
                alertify.alert("선택된 항목이 없습니다.");
                return;
            }

            var axisPoint = selectTuple[selectTuple.length - 1].GetAxisPoint();
            $.each(axisPoint.GetDimensions(), function (_, dimension) {
                const found = arrKey.find(v => v == dimension.DataMember);
                if (found != undefined) {
                    if (found == "ITEM_TYPE") {
                        itemType = axisPoint.GetDimensionValue(dimension.Id).GetValue();
                    }
                    else {
                        urlParam += "&" + found + "=" + axisPoint.GetDimensionValue(dimension.Id).GetValue();
                    }
                    
                }
            })
            
            var url = "";
            if (itemType == "SW") {
                url = "Report_QC_TFT_SW_REPORT.aspx?reportid=74" + urlParam;

            }
            else {
                url = "Report_QC_TFT_REPORT.aspx?reportid=73" + urlParam;
            }

            var win = window.open(url, "_blank", "toolbar=no,scrollbars=yes,resizable=yes,top=100,left=200,width=900,height=700");
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
                    ItemWidgetUpdated="onItemWidgetUpdated"
                    ItemCaptionToolbarUpdated="onItemCaptionToolbarUpdated"
                    DashboardTitleToolbarUpdated="onDashboardTitleToolbarUpdated"></ClientSideEvents>

                <BackendOptions Uri=""></BackendOptions>

                <DataRequestOptions ItemDataRequestMode="Auto" ItemDataLoadingMode="Always"></DataRequestOptions>
            </dx:ASPxDashboard>
        </div>
    </form>

    <!-- jQuery  -->
    <script src="../../assets/js/bootstrap.bundle.min.js"></script>
    <script src="../../assets/js/jquery.slimscroll.js"></script>
    <script src="../../assets/js/waves.min.js"></script>

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
    <script src="../../../plugins/alertify/js/alertify.js"></script>
</body>
</html>
