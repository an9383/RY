﻿using DevExpress.XtraEditors;
using VTEventSchedule.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTEventSchedule.Models
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

        public void ExecuteQry(string _query)
        {
            db.ExecuteQuery(_query);
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

        public DataView GetHoldReason()
        {
            query = string.Format("select HoldReasonName From CAMDBSh.HoldReason order by HoldReasonName");
            return db.GetDataView("ReleaseReason", query);
        }

        public DataView GetReleaseReason()
        {
            query = string.Format("select ReleaseReasonName From CAMDBSh.ReleaseReason order by ReleaseReasonName");
            return db.GetDataView("ReleaseReason", query);
        }

        public DataView GetHoldTargetContainer(string factoryName)
        {
            query = string.Format("exec CAMDBsh.RY_VM_Proc_GetHoldTargetContainer N'{0}'", factoryName);
            return db.GetDataView("Hold", query);
        }

        public DataView GetReleaseTargetContainer(string factoryName, string releaseReasonName)
        {
            query = string.Format("exec CAMDBsh.RY_VM_Proc_GetReleaseTargetContainer N'{0}', N'{1}'", factoryName, releaseReasonName);
            return db.GetDataView("Release", query);
        }

        public DataView GetHoldTargetEmployee(string workType, string factoryName)
        {
            query = string.Format("exec CAMDBsh.RY_VM_Proc_GetHoldTargetEmployee '{0}', N'{1}'", workType, factoryName);
            return db.GetDataView("Hold", query);
        }
        public DataView GetReleaseTargetEmployee(string workType, string factoryName, string holdReasonName)
        {
            query = string.Format("exec CAMDBsh.RY_VM_Proc_GetReleaseTargetEmployee '{0}', N'{1}', N'{2}'", workType, factoryName, holdReasonName);
            return db.GetDataView("Release", query);
        }
    }
}
