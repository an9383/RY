﻿using DevExpress.XtraEditors;
using SmartMES.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTMonitor.Models
{
    public class clsCode
    {
        Database db = new Database();
        string query = "";

        #region IDisposable Support
        private bool disposedValue = false; // 중복 호출을 검색하려면

        ~clsCode()
        {
            this.Dispose(false);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 관리되는 상태(관리되는 개체)를 삭제합니다.
                }

                // TODO: 관리되지 않는 리소스(관리되지 않는 개체)를 해제하고 아래의 종료자를 재정의합니다.
                // TODO: 큰 필드를 null로 설정합니다.
                db.Dispose();
                db = null;

                disposedValue = true;
            }
        }

        // TODO: 위의 Dispose(bool disposing)에 관리되지 않는 리소스를 해제하는 코드가 포함되어 있는 경우에만 종료자를 재정의합니다.
        // ~WrCategories()
        // {
        //   // 이 코드를 변경하지 마세요. 위의 Dispose(bool disposing)에 정리 코드를 입력하세요.
        //   Dispose(false);
        // }

        // 삭제 가능한 패턴을 올바르게 구현하기 위해 추가된 코드입니다.
        public void Dispose()
        {
            // 이 코드를 변경하지 마세요. 위의 Dispose(bool disposing)에 정리 코드를 입력하세요.
            Dispose(true);
            // TODO: 위의 종료자가 재정의된 경우 다음 코드 줄의 주석 처리를 제거합니다.
            // GC.SuppressFinalize(this);
        }
        #endregion

        public bool ExecuteQry(string _query)
        {
            return db.ExecuteQuery(_query);
        }
        public DataView GetFilterTags()
        {
            query = string.Format("select FactoryName 명칭, FactoryId 코드 From CAMDBsh.Factory Where FactoryName = 'Rayence'");
            return db.GetDataView("사업부", query);
        }

        public DataView GetEmployeeByFilter(string factoryId)
        {
            query = string.Format("select Employee.EmployeeName 코드, Employee.FullName 명칭 "
                            + "From CAMDBsh.Employee Inner Join CAMDBsh.SessionValues on Employee.EmployeeId = SessionValues.EmployeeId where SessionValues.FactoryId = '{0}'", factoryId);
            return db.GetDataView("작업자", query);
        }

        public DataRowView GetNowWorkTimeByContainer(string containerName)
        {
            query = string.Format("exec CAMDBSh.RY_VM_Proc_GetNowWorkTimeByContainer N'{0}'", containerName);
            return db.GetDataRecord(query);
        }

        public DataRowView GetNoOpeartionTimeByEmployee(string employeeName)
        {
            query = string.Format("exec CAMDBSh.RY_VM_Proc_GetNoOpeartionTimeByEmployee N'{0}'", employeeName);
            return db.GetDataRecord(query);
        }

        public DataRowView GetNoOpeartionStart(string workType, string employeeName, string reason)
        {
            query = string.Format("exec CAMDBSh.RY_VM_Proc_SetNoOperation '{0}', '0', N'{1}', N'{2}'", workType, employeeName, reason);
            return db.GetDataRecord(query);
        }

        public DataRowView GetNoOpeartionEnd(string workType, string employeeName, string reason)
        {
            query = string.Format("exec CAMDBSh.RY_VM_Proc_SetNoOperation '{0}', '1', N'{1}', N'{2}'", workType, employeeName, reason);
            return db.GetDataRecord(query);
        }

        public DataView GetReleaseReason()
        {
            query = string.Format("select ReleaseReasonName From CAMDBsh.ReleaseReason order by ReleaseReasonName");
            return db.GetDataView("ReleaseReason", query);
        }

        // 공장에 대한 사용자 팀리스트(전체 불포함)
        public DataView GetEmployeeTeamList()
        {
            query = string.Format("exec CAMDBsh.RY_VR_Proc_Common_EmployeeTeamList N'{0}', '0'", WrGlobal.FactoryName);

            return db.GetDataView("EmployeeTeamList", query);
        }

        // 공장, 팀에 대한 사용자 리스트 (전체 불포함)
        public DataView GetEmployeeListByTeam(string teamName)
        {
            query = string.Format("exec CAMDBsh.RY_VR_Proc_Common_EmployeeListByTeam N'{0}', N'{1}', '0'", WrGlobal.FactoryName, teamName);

            return db.GetDataView("EmployeeList", query);
        }

        public DataView GetEmployeeWorkTimeOTDef()
        {
            query = string.Format("Select Gubun, StartTime, WorkHour From IFRY.dbo.EmployeeWorkTimeDef Where RegularYn = 'N'");

            return db.GetDataView("EmployeeWorkTimeRegularDef", query);
        }

        public DataView GetWorkingContainerByEmployee(string employeeName)
        {
            query = string.Format("exec CAMDBsh.RY_VM_Proc_GetWorkingContainerByEmployee '{0}'", employeeName);

            return db.GetDataView("WorkingContainerByEmployee", query);
        }

    }
}