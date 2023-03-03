using DevExpress.XtraEditors;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VTMonitor.Models;

namespace VTMonitor
{
    public partial class frmOTInsert_Popup : DevExpress.XtraEditors.XtraForm
    {
        clsCode code = new clsCode();
        string query = "";

        string EmpNo = "";
        string EmpName = "";
        public frmOTInsert_Popup()
        {
            InitializeComponent();
        }

        public frmOTInsert_Popup(string _EmpNo, string _EmpName)
        {
            InitializeComponent();

            EmpNo = _EmpNo;
            EmpName = _EmpName; 

            this.Text += string.Format(" ({0} - {1})", EmpNo, EmpName);

            DataView gubunList = code.GetEmployeeWorkTimeOTDef();
            foreach (DataRowView drv in gubunList)
            {
                GubunComboBoxEdit.Properties.Items.Add(drv["Gubun"].ToString());
            }

            StartTimeEdit.EditValue = DateTime.Now;
            EndTimeEdit.EditValue= DateTime.Now;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if ((GubunComboBoxEdit.EditValue ?? "").ToString() == "")
            {
                MessageBox.Show(string.Format("구분 항목을 입력하세요."), "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if ((DateTime)StartTimeEdit.EditValue >= (DateTime)EndTimeEdit.EditValue)
            {
                MessageBox.Show(string.Format("시작 시간이 종료시간보다 크거나 같습니다."), "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            query = string.Format("exec IFRY.dbo.RY_Proc_SaveEmployeeWorkTimeByWM N'{0}', N'{1}', '{2}', '{3}', N'{4}'",
                            EmpNo, (GubunComboBoxEdit.EditValue ?? "").ToString(),
                            ((DateTime)StartTimeEdit.EditValue).ToString("yyyy-MM-dd HH:mm:ss"),
                            ((DateTime)EndTimeEdit.EditValue).ToString("yyyy-MM-dd HH:mm:ss"),
                            txtRemark.Text);
            if (code.ExecuteQry(query))
            {
                MessageBox.Show("저장되었습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }

        }
    }
}