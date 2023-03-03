﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BomTracking.aspx.cs" Inherits="View_Dashboard_BomTracking" %>

<%@ Register assembly="DevExpress.Dashboard.v22.1.Web.WebForms, Version=22.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.DashboardWeb" tagprefix="dx" %>

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
		
		#colorSchemeIcon .dx_gray {
			fill: currentColor;
		}

		.dx-dashboard-circle {
			width: 20px;
			height: 20px;
			box-shadow: rgba(0,0,0,0.35) 0 1px 3px;
			border: solid 4px;
			border-radius: 50%;
			margin-right: 15px;
			margin-top: 5px;
			margin-bottom: 5px;
		}

		.dx-dashboard-light {
			background-color: #337ab7;
			border-color: #ffffff;
		}
		.dx-dashboard-dark {
			background-color: #1ca8dd;
			border-color: #363640;
		}
		.dx-dashboard-carmine {
			background-color: #f05b41;
			border-color: #ffffff;
		}
		.dx-dashboard-greenmist {
			background-color: #3cbab2;
			border-color: #f5f5f5;
		}
		.dx-dashboard-softblue {
			background-color: #7ab8eb;
			border-color: #ffffff;
		}
		.dx-dashboard-darkmoon {
			background-color: #3debd3;
			border-color: #465672;
		}
		.dx-dashboard-darkviolet {
			background-color: #9c63ff;
			border-color: #17171f;
		}
		.dx-dashboard-light-blue {
			background-color: #dbe9fd;
			border-color: #ffffff;
		}
		.dx-dashboard-light-green {
			background-color: #ddfddb;
			border-color: #ffffff;
		}
		.dx-dashboard-dark-blue {
			background-color: #579ADD;
			border-color: #363640;
		}

		.dx-dashboard-material-blue-light {
			background-color: #03a9f4;
			border-color: #fff;
		}
		.dx-dashboard-material-lime-light {
			background-color: #cddc39;
			border-color: #fff;
		}
		.dx-dashboard-material-orange-light {
			background-color: #ff5722;
			border-color: #fff;
		}
		.dx-dashboard-material-purple-light {
			background-color: #9c27b0;
			border-color: #fff;
		}
		.dx-dashboard-material-teal-light {
			background-color: #009688;
			border-color: #fff;
		}

		.dx-dashboard-material-blue-dark {
			background-color: #03a9f4;
			border-color: #363640;
		}
		.dx-dashboard-material-lime-dark {
			background-color: #cddc39;
			border-color: #363640;
		}
		.dx-dashboard-material-orange-dark {
			background-color: #ff5722;
			border-color: #363640;
		}
		.dx-dashboard-material-purple-dark {
			background-color: #9c27b0;
			border-color: #363640;
		}
		.dx-dashboard-material-teal-dark {
			background-color: #009688;
			border-color: #363640;
		}

		.dx-dashboard-compact {
			width: 16px;
			height: 16px;
			margin-right: 18px;
			margin-top: 7px;
			margin-bottom: 7px;
			margin-left: 2px;
		}
		.dx-dashboard-themechooser-item {
			padding-left: 10px;
			min-width: 150px;
		}

    </style>
    <script type="text/javascript">

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
            if (args.ItemName == "gridDashboardItem2") {
                var grid = args.GetWidget();
                grid.columnOption("Seq", {
                    visible: false
                });
            }

            if (args.ItemName == "gridDashboardItem1") {
                var grid = args.GetWidget();
                grid.columnOption("ProductId", {
                    visible: false
                });
            }

            if (!itemsRequireClick[args.ItemName]) {
                itemsRequireClick[args.ItemName] = true;
                sender.UpdateItemCaptionToolbar(args.ItemName);
            }
        }

        function onItemWidgetUpdated(sender, args) {
            if (args.ItemName == "gridDashboardItem2") {
                var grid = args.GetWidget();
                grid.columnOption("Seq", {
                    visible: false
                });
            }

            if (args.ItemName == "gridDashboardItem1") {
                var grid = args.GetWidget();
                grid.columnOption("ProductId", {
                    visible: false
                });
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

        function onDashboardTitleToolbarUpdated(sender, args) {
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

        function onItemMasterFilterStateChanged(sender, args) {
            if (args.ItemName == "gridDashboardItem1") {
                var dashboardParameterDialogExtension = sender.GetDashboardControl().findExtension('dashboardParameterDialog');
                var parameters = dashboardParameterDialogExtension.getParameters();
                var parameter1 = parameters.getParameterByName("pProductId");
                parameter1.setValue(args.Values[0][5]);
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
                    ItemWidgetUpdated="onItemWidgetUpdated"
                    ItemCaptionToolbarUpdated="onItemCaptionToolbarUpdated" 
                    DashboardTitleToolbarUpdated="onDashboardTitleToolbarUpdated" 
                    ItemMasterFilterStateChanged="onItemMasterFilterStateChanged">
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
    <script src="../../Script/Users.js"></script>
</body>
</html>

