using DevExpress.Utils.Drawing.Helpers;
using DevExpress.XtraScheduler;
using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VTEventSchedule.Common;
using VTEventSchedule.Models;

namespace VTEventSchedule
{
    public partial class frmEventManager : DevExpress.XtraEditors.XtraForm
    {
        clsCode code = new clsCode();
        string query = "";
        //clsCamstarCommon camstarCommon = new clsCamstarCommon();

        double TotalNumber = 0;

        public frmEventManager()
        {
            InitializeComponent();

            if (WrGlobal.SQL_SERVER == "10.10.50.61")
            {
                this.Text = this.Text + "(운영)";
            }
            else
            {
                this.Text = this.Text + "(개발)";
            }

        }

        private void frmEventManager_Load(object sender, EventArgs e)
        {
            try
            {
                this.vM_ResourcesTableAdapter.Fill(this.schedulerDataSet.VM_Resources);
                this.vM_AppointmentsTableAdapter.Fill(this.schedulerDataSet.VM_Appointments);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            schedulerControl1.Start = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            schedulerControl1.ActiveViewType = DevExpress.XtraScheduler.SchedulerViewType.Month;
            schedulerControl1.GroupType = DevExpress.XtraScheduler.SchedulerGroupType.Resource;
            schedulerControl1.DayView.TimeIndicatorDisplayOptions.ShowOverAppointment = true;

            this.schedulerDataStorage1.AppointmentsChanged += OnAppointmentChangedInsertedDeleted;
            this.schedulerDataStorage1.AppointmentsInserted += OnAppointmentChangedInsertedDeleted;
            this.schedulerDataStorage1.AppointmentsDeleted += OnAppointmentChangedInsertedDeleted;

            timer1.Enabled = true;
        }

        private void OnAppointmentChangedInsertedDeleted(object sender, PersistentObjectsEventArgs e)
        {
            vM_AppointmentsTableAdapter.Update(schedulerDataSet);
            schedulerDataSet.AcceptChanges();
        }

        private void schedulerControl1_EditAppointmentFormShowing(object sender, AppointmentFormEventArgs e)
        {
            SchedulerControl scheduler = ((SchedulerControl)(sender));
            frmAppointmentCustomEdit form = new frmAppointmentCustomEdit(scheduler, e.Appointment, e.OpenRecurrenceForm);
            try
            {
                e.DialogResult = form.ShowDialog();
                e.Handled = true;
            }
            finally
            {
                form.Dispose();
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            AppointmentBaseCollection appts = schedulerDataStorage1.GetAppointments(DateTime.Now.AddMinutes(-4), DateTime.Now.AddMinutes(4));

            if (appts.Count == 0) return;   //2분전에서 현시각까지 일정이 없으면 리턴

            timer1.Enabled = false;

            DateTime nowTime = DateTime.Now;
            nowTime.AddSeconds(-nowTime.Second);

            string resourceId = "";

            WrGlobal.ErrMessage = "";

            try
            {
                foreach (Appointment appt in appts)
                {       
                    if (appt.Description == "1") 
                    {   // 시작된 일정 종료
                        TimeSpan tspn = DateTime.Now - appt.Start;
                        if (tspn.TotalMinutes < 3 || appt.Start > nowTime || appt.End > nowTime)
                        {   //3분내 시작된거 무시
                            continue;
                        }

                        if (logList.Items.Count > 50)
                        {
                            logList.Items.Clear();
                        }

                        resourceId = appt.ResourceId.ToString();
                        appt.Description = "2";
                        appt.LabelKey = 6;

                        query = string.Format("exec CAMDBsh.RY_VM_Proc_SetReleaseTargetContainer N'{0}', '{1}', '{2}', N'{3}', N'{4}'",
                                            schedulerDataStorage1.Resources.GetResourceById(appt.ResourceId).Caption,
                                            appt.Start.ToString("yyyy-MM-dd HH:mm"),
                                            appt.End.ToString("yyyy-MM-dd HH:mm"),
                                            appt.Subject,
                                            appt.Location);
                        code.ExecuteQry(query);
; 
                        if (WrGlobal.ErrMessage == "")
                        {
                            logList.Items.Insert(0, DateTime.Now.ToString() + " [컨테이너Release] : " + schedulerDataStorage1.Resources.GetResourceById(appt.ResourceId).Caption + " - " + appt.Location);
                        }
                        else
                        {
                            string[] arrMsg = WrGlobal.ErrMessage.TrimStart('|').Split(',');
                            foreach (string msg in arrMsg)
                            {
                                logList.Items.Insert(0, msg);
                            }
                            logList.Items.Insert(0, DateTime.Now.ToString() + " [SetReleaseTargetContainer Error] : " + schedulerDataStorage1.Resources.GetResourceById(appt.ResourceId).Caption + " - " + appt.Location);
                            WrGlobal.ErrMessage = "";
                        }

                        DataView releaseView = code.GetReleaseTargetEmployee("1", schedulerDataStorage1.Resources.GetResourceById(appt.ResourceId).Caption, appt.Subject);
                        if (WrGlobal.ErrMessage != "")
                        {
                            string[] arrMsg = WrGlobal.ErrMessage.TrimStart('|').Split(',');
                            foreach (string msg in arrMsg)
                            {
                                logList.Items.Insert(0, msg);
                            }
                            logList.Items.Insert(0, DateTime.Now.ToString() + " [GetReleaseTargetEmployee Error] : " + schedulerDataStorage1.Resources.GetResourceById(appt.ResourceId).Caption + " - " + appt.Location);
                            WrGlobal.ErrMessage = "";
                        }

                        if (releaseView != null)
                        {
                            foreach (DataRowView item in releaseView)
                            {
                                code.GetNoOpeartionEnd("1", item["EmployeeName"].ToString(), appt.Location);
                            }

                            query = string.Format("Insert Into IFRY.dbo.VM_AppointmentsDetail(ResourceID, ExecDate, Gubun, Bigo) Values({0}, getdate(), '{1}', N'{2}')",
                                                appt.ResourceId, "2", "[일정종료] " + appt.Location);
                            code.ExecuteQry(query);

                            if (WrGlobal.ErrMessage != "")
                            {
                                string[] arrMsg = WrGlobal.ErrMessage.TrimStart('|').Split(',');
                                foreach (string msg in arrMsg)
                                {
                                    logList.Items.Insert(0, msg);
                                }
                                logList.Items.Insert(0, DateTime.Now.ToString() + " [EmployeeRelease Error] : " + query);
                                WrGlobal.ErrMessage = "";
                            }
                        }

                    }
                }

                foreach (Appointment appt in appts)
                {
                    if (appt.Description == "")
                    {   // 일정 시작

                        if (appt.Start > nowTime || appt.Start < nowTime.AddMinutes(-5))
                        {   //3분내 시작된거 무시
                            continue;
                        }

                        if (logList.Items.Count > 50)
                        {
                            logList.Items.Clear();
                        }

                        resourceId = appt.ResourceId.ToString();
                        appt.Description = "1";

                        query = string.Format("exec CAMDBsh.RY_VM_Proc_SetHoldTargetContainer N'{0}', '{1}', N'{2}'",
                                            schedulerDataStorage1.Resources.GetResourceById(appt.ResourceId).Caption,
                                            appt.Start.ToString("yyyy-MM-dd HH:mm"),
                                            appt.Subject);
                        code.ExecuteQry(query);

                        if (WrGlobal.ErrMessage == "")
                        {
                            logList.Items.Insert(0, DateTime.Now.ToString() + " [컨테이너Hold] : " + schedulerDataStorage1.Resources.GetResourceById(appt.ResourceId).Caption + " - " + appt.Subject);
                        }
                        else
                        {
                            string[] arrMsg = WrGlobal.ErrMessage.TrimStart('|').Split(',');
                            foreach (string msg in arrMsg)
                            {
                                logList.Items.Insert(0, msg);
                            }
                            logList.Items.Insert(0, DateTime.Now.ToString() + " [GetHoldTargetContainer Error] : " + schedulerDataStorage1.Resources.GetResourceById(appt.ResourceId).Caption + " - " + appt.Subject);
                            WrGlobal.ErrMessage = "";
                        }

                        DataView holdView = code.GetHoldTargetEmployee("1", schedulerDataStorage1.Resources.GetResourceById(appt.ResourceId).Caption);

                        foreach (DataRowView item in holdView)
                        {
                            code.GetNoOpeartionStart("1", item["EmployeeName"].ToString(), appt.Subject);
                        }

                        query = string.Format("Insert Into IFRY.dbo.VM_AppointmentsDetail(ResourceID, ExecDate, Gubun, Bigo) Values({0}, getdate(), '{1}', N'{2}')",
                                            appt.ResourceId, "1", "[일정시작] " + appt.Subject);
                        code.ExecuteQry(query);

                        if (WrGlobal.ErrMessage != "")
                        {
                            string[] arrMsg = WrGlobal.ErrMessage.TrimStart('|').Split(',');
                            foreach (string msg in arrMsg)
                            {
                                logList.Items.Insert(0, msg);
                            }
                            logList.Items.Insert(0, DateTime.Now.ToString() + " [EmployeeHold Error] : " + query);
                            WrGlobal.ErrMessage = "";
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                logList.Items.Insert(0, DateTime.Now.ToString() + " [Error] : " + ex.Message);
            }

            timer1.Enabled = true;
        }

    }
}
