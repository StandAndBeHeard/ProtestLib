
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Collections.Generic;

namespace ProtestLib
{
    [Serializable]
    public partial class ErrorLogs : List<ErrorLog>
    {

        #region Constructors
        public ErrorLogs() { }

        public ErrorLogs(DataTable dt)
        {
            foreach (DataRow row in dt.Rows) Add(new ErrorLog(row));
        }
        #endregion

        #region Methods
        public static ErrorLogs Load(string sql, CommandType commandType = CommandType.Text, SqlParameter[] parameters = null)
        {
            return new ErrorLogs(DBHelper.ExecuteQuery(sql, commandType, parameters));
        }

        public static ErrorLogs LoadAll()
        {
            return Load("LoadErrorLogsAll", CommandType.StoredProcedure, null);
        }

        public void SaveAll(bool waitForId = true)
        {
            SqlConnection conn = DBHelper.Connection;
            try
            {
                conn.Open();
                DBHelper.SetContextInfo(conn);
                foreach (ErrorLog errorLog in this)
                {
                    SqlCommand cmd = errorLog.GetSaveCommand(conn);
                    errorLog.Id = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex) { throw ex; }
            finally { conn.Close(); }
        }

        public ErrorLog GetById(int id)
        {
            foreach (ErrorLog errorLog in this) if (errorLog.Id == id) return errorLog;
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
