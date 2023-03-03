//**********************************************************************************************************************
//  Class Name      : clsDbHandle.cs
//  Description     : DB연결
//**********************************************************************************************************************
//  작성일자        : 2013.06
//  작 성 자        : 강병욱
//  최종 수정일     : 2019.08.21
//**********************************************************************************************************************

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Threading;
using System.Windows.Forms;

namespace nsCommon
{
    /// </summary>
    public class DbHandle
    {
        public Dictionary<string, object> _DB_Parameters { get; set; }
        public DbTransaction _Transaction { get; set; }
        private bool _ExecuteFalg { get; set; }
        private DbProviderFactory _Factory { get; set; }
        public DbConnection _Connection { get; set; }
        private DbCommand _Command { get; set; }
        private DbDataAdapter _DataAdapter { get; set; }
        public ConnectionStringSettings _ConnectionStringSettings { get; set; }
        public DbConnectionStringBuilder _DbConnectionStringBuilder { get; set; }

        public DbHandle(string connectionName)
        {
            _ConnectionStringSettings = ConfigurationManager.ConnectionStrings[connectionName];
            _DbConnectionStringBuilder = new DbConnectionStringBuilder
            {
                ConnectionString = _ConnectionStringSettings.ConnectionString
            };

            //documented to return null if it couldn't be found
            if (_ConnectionStringSettings == null)
            {
                throw new ConfigurationErrorsException("Invalid connection name \"" + connectionName + "\"");
            }
            //Get the factory for the given provider (e.g. "System.Data.SqlClient")
            _Factory = DbProviderFactories.GetFactory(_ConnectionStringSettings.ProviderName);

            //Undefined behaviour if GetFactory couldn't find a provider.
            //Defensive test for null factory anyway
            if (_Factory == null)
            {
                throw new Exception("Could not obtain factory for provider \"" + _ConnectionStringSettings.ProviderName + "\"");
            }

            //Have the factory give us the right connection object
            _Connection = _Factory.CreateConnection();

            //Undefined behaviour if CreateConnection failed
            //Defensive test for null connection anyway
            if (_Connection == null)
            {
                throw new Exception("Could not obtain connection from factory");
            }

            //Knowing the connection string, open the connection
            _Connection.ConnectionString = _DbConnectionStringBuilder.ConnectionString;

            //Have the factory give us the right command object
            _Command = _Factory.CreateCommand();

            if (_Command != null)
            {
                _Command.Connection = _Connection;
            }

            //Have the factory give us the right dataAdapter object
            _DataAdapter = _Factory.CreateDataAdapter();

            _DB_Parameters = new Dictionary<string, object>();
            _ExecuteFalg = true;
        }

        /// <summary>
        ///  Connection Open, Command 초기화
        /// </summary>
        /// <returns></returns>
        public string Open()
        {
            if (!string.IsNullOrEmpty(_DbConnectionStringBuilder.ConnectionString))
            {
                try
                {
                    if (_Connection.State != ConnectionState.Open)
                    {
                        _Connection.ConnectionString = _DbConnectionStringBuilder.ConnectionString;
                        _Connection.Open();
                        if (_Command != null)
                        {
                            _Command.Connection = _Connection;
                        }
                    }
                }
                catch (Exception e)
                {
                    return e.Message;
                }
            }
            else
            {
                return "ConnectionString is null";
            }
            return null;
        }

        /// <summary>
        /// Connection을 Close하고 Connection을 null로 만든다.
        /// </summary>
        /// <returns></returns>
        public string Close()
        {
            try
            {
                if (_Connection != null)
                {
                    if (_Connection.State == ConnectionState.Open)
                    {
                        _Connection.Close();
                    }

                    _Connection.Dispose();
                    _Connection = null;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return null;
        }

        public string GET_DATA(string Query, ref DataTable dt)
        {
            DataSet ds = new DataSet();
            string sMsg = GET_DATA(Query, ref ds);
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return sMsg;
        }

        public string GET_DATA(string Query, Dictionary<string, object> DB_Parameters, ref DataTable dt)
        {
            DataSet ds = new DataSet();
            _DB_Parameters = DB_Parameters;
            string sMsg = GET_DATA(Query, ref ds);
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }

            return sMsg;
        }

        public string GET_DATA(string Query, Dictionary<string, object> DB_Parameters, ref DataSet ds)
        {
            _DB_Parameters = DB_Parameters;
            return GET_DATA(Query, ref ds);
        }

        /// <summary>
        /// SP,DT반환형
        /// </summary>
        /// <param name="Query">쿼리</param>
        /// <param name="ds">DataSet</param>
        /// <returns></returns>
        public string GET_DATA(string Query, ref DataSet ds)
        {
            _Command = _Connection.CreateCommand();
            _Command.CommandText = Query;

            try
            {
                Open();
                Set_Parameters();
                _DataAdapter.SelectCommand = _Command;
                _DataAdapter.Fill(ds); //데이터셋에 채움
                if (ds.Tables.Count == 0)
                {
                    return "Result Tables Count is Zero";
                }
                else if (ds.Tables[0].Rows.Count < 1)
                {
                    return "Result FirstTable Rows Count is Zero";
                }

                _ExecuteFalg = true;
                return null;
            }
            catch (Exception e)
            {
                _ExecuteFalg = true;
                return DB_Exception(e.Message);
            }
        }

        /// <summary>
        /// 단일트랜잭션,String반환형
        /// </summary>
        /// <param name="Query">쿼리</param>
        /// <returns>String결과값(NG일경우 에러값)</returns>
        public string SET_DATA(string Query)
        {
            DataSet ds = new DataSet();
            return SET_DATA(Query, ref ds);
        }

        public string SET_DATA(string Query, ref DataTable dt)
        {
            DataSet ds = new DataSet();
            string sMsg = SET_DATA(Query, ref ds);
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return sMsg;
        }

        public string SET_DATA(string Query, Dictionary<string, object> DB_Parameters)
        {
            DataSet ds = new DataSet();
            _DB_Parameters = DB_Parameters;
            return SET_DATA(Query, ref ds);
        }

        public string SET_DATA(string Query, Dictionary<string, object> DB_Parameters, ref DataTable dt)
        {
            DataSet ds = new DataSet();
            _DB_Parameters = DB_Parameters;
            string sMsg = SET_DATA(Query, ref ds);
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return sMsg;
        }

        public string SET_DATA(string Query, Dictionary<string, object> DB_Parameters, ref DataSet ds)
        {
            _DB_Parameters = DB_Parameters;
            return SET_DATA(Query, ref ds);
        }

        /// <summary>
        /// 단일트랜잭션,String반환형
        /// </summary>
        /// <param name="Query">쿼리</param>
        /// <param name="ds">DataSet</param>
        /// <returns>String결과값(NG일경우 에러값)</returns>
        public string SET_DATA(string Query, ref DataSet ds)
        {
            if (!_ExecuteFalg)
            {
                Thread.Sleep(10);
            }
            _ExecuteFalg = false;
            _Command = _Connection.CreateCommand();
            _Command.CommandText = Query;

            if (ds is null)
            {
                ds = new DataSet();
            }

            string str_rtn = null;

            try
            {
                Open();
                Set_Parameters();
                _Transaction = _Connection.BeginTransaction();
                _Command.Transaction = _Transaction;
                _DataAdapter.SelectCommand = _Command;
                _DataAdapter.Fill(ds); //데이터셋에 채움

                _Transaction.Commit();
            }
            catch (Exception e)
            {
                _Transaction.Rollback();
                str_rtn = DB_Exception(e.Message);
            }
            finally
            {
                _Transaction = null;
                _ExecuteFalg = true;
            }
            return str_rtn;
        }

        /// <summary>
        /// 다중트랜잭션,String반환형
        /// </summary>
        /// <param name="Query">프로시져명</param>
        /// <param name="trans">연결할 트랜잭션</param>
        /// <returns>String결과값(NG일경우 에러값)</returns>
        public string SET_DATA(string Query, ref DbTransaction _trans)
        {
            DataSet ds = new DataSet();
            return SET_DATA(Query, ref ds, ref _trans);
        }

        public string SET_DATA(string Query, ref DataTable dt, ref DbTransaction _trans)
        {
            DataSet ds = new DataSet();
            string sMsg = SET_DATA(Query, ref ds, ref _trans);
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return sMsg;
        }

        public string SET_DATA(string Query, Dictionary<string, object> DB_Parameters, ref DbTransaction _trans)
        {
            DataSet ds = new DataSet();
            _DB_Parameters = DB_Parameters;
            return SET_DATA(Query, ref ds, ref _trans);
        }

        public string SET_DATA(string Query, Dictionary<string, object> DB_Parameters, ref DataTable dt, ref DbTransaction _trans)
        {
            DataSet ds = new DataSet();
            _DB_Parameters = DB_Parameters;
            string sMsg = SET_DATA(Query, ref ds, ref _trans);
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return sMsg;
        }

        public string SET_DATA(string Query, Dictionary<string, object> DB_Parameters, ref DataSet ds, ref DbTransaction _trans)
        {
            _DB_Parameters = DB_Parameters;
            return SET_DATA(Query, ref ds, ref _trans);
        }

        public string SET_DATA(string Query, ref DataSet ds, ref DbTransaction _trans)
        {
            if (!_ExecuteFalg)
            {
                Thread.Sleep(10);
            }
            _ExecuteFalg = false;
            _Command = _Connection.CreateCommand();
            _Command.CommandText = Query;

            string str_rtn = null;

            try
            {
                if (_trans != null)
                {
                    _Command.Transaction = _trans;
                }

                Open();
                Set_Parameters();
                _DataAdapter.SelectCommand = _Command;
                _DataAdapter.Fill(ds); //데이터셋에 채움
            }
            catch (Exception e)
            {
                if (_trans != null)
                {
                    _trans.Rollback();
                }

                str_rtn = DB_Exception(e.Message);
            }
            return str_rtn;
        }

        public void Set_Parameters()
        {
            _Command.Parameters.Clear();

            foreach (KeyValuePair<string, object> item in _DB_Parameters)
            {
                DbParameter parameter = _Command.CreateParameter();
                parameter.ParameterName = item.Key.ToString();

                if ((item.Value ?? "").GetType().Namespace == "System")
                {
                    parameter.Value = item.Value;
                    _Command.Parameters.Add(parameter);
                }
                else
                {
                    _Command.Parameters.Add(item.Value);
                }
            }

            if (_Command.CommandText.ToUpper().Substring(0, 6) != "SELECT" &&
                        _Command.CommandText.ToUpper().Substring(0, 6) != "UPDATE" &&
                        _Command.CommandText.ToUpper().Substring(0, 6) != "INSERT" &&
                        _Command.CommandText.ToUpper().Substring(0, 6) != "DELETE" &&
                        _Command.CommandText.ToUpper().Substring(0, 6) != "MERGE " &&
                        _Command.CommandText.ToUpper().Substring(0, 6) != "DECLAR")
            {
                _Command.CommandType = CommandType.StoredProcedure;
            }
            //연결제한시간
            _Command.CommandTimeout = 600;

            _DB_Parameters.Clear();
        }

        public string getParameterNames()
        {
            string sParameters = "";
            foreach (DbParameter parameter in _Command.Parameters)
            {
                sParameters += parameter.ParameterName;
            }
            return sParameters;
        }

        public string getParameterStrings()
        {
            string sParameters = "";
            foreach (DbParameter parameter in _Command.Parameters)
            {
                sParameters += parameter.ParameterName + " : " + parameter.Value + " ; "; ;
            }
            return sParameters;
        }

        public string DB_Exception(string Error_Message)
        {
            Error_Message = "[DataBase Exception] " + Environment.NewLine +
                       "\t SQL : " + _Command.CommandText + Environment.NewLine +
                       "\t Parameter : " + getParameterStrings() + Environment.NewLine +
                       Error_Message;

            Write_LOG(Error_Message, true);

            return Error_Message;
        }

        public void Write_LOG(string Log_String)
        {
            Write_LOG(Log_String, false);
        }

        public void Write_LOG(string Log_String, bool IsError)
        {
            string FileName = "";
            string DirectoryName = "";
            if (IsError)
            {
                DirectoryName = "ERROR_LOG";
            }
            else
            {
                DirectoryName = "LOG";
            }
            Filehandle _FH_LOG;
            FileName = Application.StartupPath + "\\" + DirectoryName + "\\LOG_" + DateTime.Now.ToString("yyyyMMdd") + ".TXT";

            _FH_LOG = new Filehandle(FileName, false);
            if (_FH_LOG._FileInfo.Exists == true)
            {
                _FH_LOG.TextFileWriteAppend("[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffffff") + "] \t" + Log_String);
            }
            else
            {
                _FH_LOG.TextFileWriteCreate("[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffffff") + "] \t" + Log_String, FileName);
            }
        }
    }
}