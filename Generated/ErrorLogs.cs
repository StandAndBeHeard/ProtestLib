using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace ProtestLib
{
    [Serializable]
    public partial class ErrorLogs : System.Collections.Generic.List<ErrorLog>
    {

        #region Constructor
        public ErrorLogs()
        {
        }
        #endregion

        #region Methods
        public static ErrorLogs LoadErrorLogs(string sql, System.Data.CommandType commandType, System.Data.SqlClient.SqlParameter[] parameters)
        {
            return ErrorLogs.ConvertFromDT(Utils.ExecuteQuery(sql, commandType, parameters));
        }

        public static ErrorLogs ConvertFromDT(DataTable dt)
        {
            ErrorLogs result = new ErrorLogs();
            foreach (DataRow row in dt.Rows)
            {
                result.Add(ErrorLog.GetErrorLog(row));
            }
            return result;
        }

        public static ErrorLogs LoadAllErrorLogs()
        {
            return ErrorLogs.LoadErrorLogs("LoadErrorLogsAll", CommandType.StoredProcedure, null);
        }

        public void SaveAll(bool waitForId = true)
        {
            SqlConnection conn = Global.Connection;
            try
            {
                conn.Open();
                Utils.SetContextInfo(conn);
                foreach (ProtestLib.ErrorLog errorLog in this)
                {
                    SqlCommand cmd = ErrorLog.GetSaveCommand(errorLog, conn);
                    errorLog.Id = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public ErrorLog GetErrorLogById(int errorLogId)
        {
            foreach (ErrorLog errorLog in this)
            {
                if (errorLog.Id == errorLogId) return errorLog;
            }
            return null;
        }


        public ErrorLogs Sort(string column, bool desc)
        {
            var sortedList = desc ? this.OrderByDescending(x => x.GetPropertyValue(column)) : this.OrderBy(x => x.GetPropertyValue(column));
            ErrorLogs result = new ErrorLogs();
            foreach (var i in sortedList) { result.Add((ErrorLog)i); }
            return result;
        }

        #endregion


    }
}

