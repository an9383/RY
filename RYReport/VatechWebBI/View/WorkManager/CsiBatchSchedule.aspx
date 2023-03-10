<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CsiBatchSchedule.aspx.cs" Inherits="View_WorkManager_CsiBatchSchedule" %>

<%@ Register Assembly="DevExpress.XtraScheduler.v22.2.Core.Desktop, Version=22.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraScheduler" TagPrefix="cc1" %>
<%@ Register Assembly="DevExpress.Web.ASPxScheduler.v22.2, Version=22.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxScheduler" TagPrefix="dxwschs" %>

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
            overflow: scroll;
        }
    </style>
</head>
<body style="padding-top: 4px;">
    <form id="form1" runat="server">
        <div style="position: absolute; left: 0px; right: 0px; top: 4px; bottom: 0px;">
            <dx:BootstrapScheduler ID="BatchScheduler" runat="server" ClientInstanceName="batchScheduler" ActiveViewType="Month" GroupType="Resource" AppointmentDataSourceID="appointmentSqlDataSource" OnFetchAppointments="BatchScheduler_FetchAppointments" ResourceDataSourceID="resourceSqlDataSource">

<OptionsAppearance UseResourceColorSchemas="True"><ResourceColorSchemas>
<dxwschs:SchedulerColorSchema Cell="255, 244, 188" CellBorder="243, 228, 177" CellBorderDark="234, 208, 152" CellLight="255, 255, 213" CellLightBorder="255, 239, 199" CellLightBorderDark="246, 219, 162" ResourceHeaderBackground="255, 255, 213" ResourceHeaderText="0, 0, 0, 0"></dxwschs:SchedulerColorSchema>
<dxwschs:SchedulerColorSchema Cell="240, 240, 240" CellBorder="160, 160, 160" CellBorderDark="160, 160, 160" CellLight="255, 255, 255" CellLightBorder="160, 160, 160" CellLightBorderDark="160, 160, 160" ResourceHeaderBackground="255, 255, 255" ResourceHeaderText="0, 0, 0, 0"></dxwschs:SchedulerColorSchema>
<dxwschs:SchedulerColorSchema Cell="179, 212, 151" CellBorder="168, 203, 138" CellBorderDark="140, 180, 104" CellLight="213, 236, 188" CellLightBorder="205, 228, 180" CellLightBorderDark="186, 209, 162" ResourceHeaderBackground="213, 236, 188" ResourceHeaderText="0, 0, 0, 0"></dxwschs:SchedulerColorSchema>
<dxwschs:SchedulerColorSchema Cell="139, 158, 191" CellBorder="128, 147, 181" CellBorderDark="97, 116, 152" CellLight="207, 216, 230" CellLightBorder="193, 201, 219" CellLightBorderDark="161, 175, 204" ResourceHeaderBackground="207, 216, 230" ResourceHeaderText="0, 0, 0, 0"></dxwschs:SchedulerColorSchema>
<dxwschs:SchedulerColorSchema Cell="190, 134, 161" CellBorder="180, 124, 149" CellBorderDark="156, 101, 122" CellLight="227, 203, 214" CellLightBorder="218, 189, 199" CellLightBorderDark="197, 163, 171" ResourceHeaderBackground="227, 203, 214" ResourceHeaderText="0, 0, 0, 0"></dxwschs:SchedulerColorSchema>
<dxwschs:SchedulerColorSchema Cell="137, 177, 167" CellBorder="123, 168, 156" CellBorderDark="84, 142, 128" CellLight="193, 214, 209" CellLightBorder="174, 202, 195" CellLightBorderDark="145, 182, 173" ResourceHeaderBackground="193, 214, 209" ResourceHeaderText="0, 0, 0, 0"></dxwschs:SchedulerColorSchema>
<dxwschs:SchedulerColorSchema Cell="247, 180, 127" CellBorder="235, 167, 113" CellBorderDark="202, 131, 71" CellLight="250, 208, 174" CellLightBorder="238, 196, 163" CellLightBorderDark="225, 166, 118" ResourceHeaderBackground="250, 208, 174" ResourceHeaderText="0, 0, 0, 0"></dxwschs:SchedulerColorSchema>
<dxwschs:SchedulerColorSchema Cell="221, 140, 142" CellBorder="210, 129, 131" CellBorderDark="179, 100, 101" CellLight="239, 200, 201" CellLightBorder="233, 187, 189" CellLightBorderDark="222, 164, 166" ResourceHeaderBackground="239, 200, 201" ResourceHeaderText="0, 0, 0, 0"></dxwschs:SchedulerColorSchema>
<dxwschs:SchedulerColorSchema Cell="137, 150, 132" CellBorder="129, 138, 122" CellBorderDark="102, 100, 89" CellLight="208, 216, 203" CellLightBorder="196, 207, 191" CellLightBorderDark="172, 181, 169" ResourceHeaderBackground="208, 216, 203" ResourceHeaderText="0, 0, 0, 0"></dxwschs:SchedulerColorSchema>
<dxwschs:SchedulerColorSchema Cell="0, 199, 200" CellBorder="0, 186, 187" CellBorderDark="0, 151, 153" CellLight="168, 236, 236" CellLightBorder="144, 226, 227" CellLightBorderDark="84, 203, 204" ResourceHeaderBackground="168, 236, 236" ResourceHeaderText="0, 0, 0, 0"></dxwschs:SchedulerColorSchema>
<dxwschs:SchedulerColorSchema Cell="168, 148, 207" CellBorder="155, 136, 194" CellBorderDark="118, 99, 155" CellLight="221, 213, 236" CellLightBorder="210, 199, 230" CellLightBorderDark="185, 169, 216" ResourceHeaderBackground="221, 213, 236" ResourceHeaderText="0, 0, 0, 0"></dxwschs:SchedulerColorSchema>
<dxwschs:SchedulerColorSchema Cell="204, 204, 204" CellBorder="189, 189, 189" CellBorderDark="121, 121, 121" CellLight="230, 230, 230" CellLightBorder="204, 204, 204" CellLightBorderDark="177, 177, 177" ResourceHeaderBackground="230, 230, 230" ResourceHeaderText="0, 0, 0, 0"></dxwschs:SchedulerColorSchema>
</ResourceColorSchemas>
</OptionsAppearance>

                <OptionsEditing AllowAppointmentCopy="None" AllowAppointmentCreate="None" AllowAppointmentDelete="None" AllowAppointmentDrag="None" AllowAppointmentDragBetweenResources="None" AllowAppointmentEdit="None" AllowAppointmentResize="None" AllowDisplayAppointmentDependencyForm="Never" AllowDisplayAppointmentFlyout="False" AllowDisplayAppointmentForm="Never" AllowInplaceEditor="None" />
                <OptionsViewNavigator ShowGotoDateButton="True" ShowTodayButton="True" />

<OptionsViewVisibleInterval>
<OptionsCalendar AppointmentDatesHighlightMode="Labels"></OptionsCalendar>
</OptionsViewVisibleInterval>

                <Storage>
                    <Appointments AutoRetrieveId="true">
                        <Mappings AppointmentId="ID_KEY" Start="BATCH_DATE" End="BATCH_DATE" Subject="CSI_BATCH"
                            Description="Special_Note" Location="Special_Note" ResourceId="DEPONAME" />
                    </Appointments>
                    <Resources>
                        <Mappings ResourceId="DEPONAME" Caption="DEPONAME" />
                    </Resources>
                </Storage>
                <Views>
                    <DayView ResourcesPerPage="3" ShowWorkTimeOnly="true">
                        <WorkTime Start="0:00" End="23:59" />
<TimeRulers>
<cc1:TimeRuler></cc1:TimeRuler>
</TimeRulers>
                    </DayView>
                    <WorkWeekView ResourcesPerPage="2" Enabled="False">
                        <TimeRulers>
<cc1:TimeRuler></cc1:TimeRuler>
</TimeRulers>
                    </WorkWeekView>
                    <FullWeekView ResourcesPerPage="2">
                        <TimeRulers>
<cc1:TimeRuler></cc1:TimeRuler>
</TimeRulers>
                    </FullWeekView>
                    <WeekView ResourcesPerPage="2">
                    </WeekView>
                    <MonthView ResourcesPerPage="1">
                        <AppointmentDisplayOptions EndTimeVisibility="Never" StartTimeVisibility="Never" />
                    </MonthView>
                    <TimelineView ResourcesPerPage="7" IntervalCount="7">
                        <CellAutoHeightOptions Mode="FitToContent" />
                    </TimelineView>
                    <AgendaView ScrollAreaHeight="600" Enabled="False">
                    </AgendaView>
                </Views>
                <OptionsBehavior ShowFloatingActionButton="False" ShowRemindersForm="False" ShowViewNavigatorGotoDateButton="True" />
            </dx:BootstrapScheduler>
        </div>
    </form>
    <asp:SqlDataSource ID="appointmentSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:CamdbConnectionString %>"
        SelectCommand="Select *, Case When DAY_NIGHT = N'야간' then DEPO + N'(야)' else DEPO end DEPONAME From IFRY.dbo.CsI_Batch_Plan Where BATCH_DATE Between @startTime and @endTime">
        <SelectParameters>
            <asp:Parameter Name="startTime" Type="DateTime" />
            <asp:Parameter Name="endTime" Type="DateTime" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="resourceSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:CamdbConnectionString %>"
        SelectCommand="Select * From IFRY.dbo.CsI_Batch_Plan_Depo Order by SortOrder"></asp:SqlDataSource>
    <!-- jQuery  -->
    <script src="../assets/js/bootstrap.bundle.min.js"></script>
    <script src="../assets/js/jquery.slimscroll.js"></script>
    <script src="../assets/js/waves.min.js"></script>

    <script type="text/javascript">
        $(window).on('load', onLoad);

        function onLoad() {
            isLoad = true;
            if (errMsg != "") {
                alertify.alert(errMsg);
                errMsg = "";
            }
        }
    </script>

    <!-- Alertify js -->
    <script src="../../plugins/alertify/js/alertify.js"></script>
</body>
</html>
