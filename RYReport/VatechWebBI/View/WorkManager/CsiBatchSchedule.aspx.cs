﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_WorkManager_CsiBatchSchedule : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BatchScheduler.Start = DateTime.Today.AddDays((DateTime.Today.Day - 1) * -1);
        }  
    }

    protected void BatchScheduler_FetchAppointments(object sender, DevExpress.XtraScheduler.FetchAppointmentsEventArgs e)
    {
        appointmentSqlDataSource.SelectParameters["startTime"].DefaultValue = e.Interval.Start.ToString();
        appointmentSqlDataSource.SelectParameters["endTime"].DefaultValue = e.Interval.End.ToString();
        e.ForceReloadAppointments = true;
    }

}