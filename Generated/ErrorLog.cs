using System;
using System.Data;
using System.Data.SqlClient;

namespace ProtestLib
{
    [Serializable]
    public partial class ErrorLog
    {
        #region Declarations
        System.Int32 _id;
        System.DateTime _errorDate;
        System.String _url;
        System.String _errorMessage;
        System.String _additionalInfo;

        bool _isIdNull = true;
        bool _isErrorDateNull = true;
        bool _isUrlNull = true;
        bool _isErrorMessageNull = true;
        bool _isAdditionalInfoNull = true;

        #endregion

        #region Properties
        public System.Int32 Id
        {
            get { return _id; }
            set
            {
                _id = value;
                _isIdNull = false;
            }
        }

        public System.DateTime ErrorDate
        {
            get { return _errorDate; }
            set
            {
                _errorDate = value;
                _isErrorDateNull = false;
            }
        }

        public System.String Url
        {
            get { return _url; }
            set
            {
                _url = value;
                _isUrlNull = false;
            }
        }

        public System.String ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                _isErrorMessageNull = false;
            }
        }

        public System.String AdditionalInfo
        {
            get { return _additionalInfo; }
            set
            {
                _additionalInfo = value;
                _isAdditionalInfoNull = false;
            }
        }


        public bool IsIdNull
        {
            get { return _isIdNull; }
            set
            {
                if (!value) throw new Exception("Can not set this property to false");
                _isIdNull = value;
                _id = -1;
            }
        }

        public bool IsErrorDateNull
        {
            get { return _isErrorDateNull; }
            set
            {
                if (!value) throw new Exception("Can not set this property to false");
                _isErrorDateNull = value;
                _errorDate = DateTime.MinValue;
            }
        }

        public bool IsUrlNull
        {
            get { return _isUrlNull; }
            set
            {
                if (!value) throw new Exception("Can not set this property to false");
                _isUrlNull = value;
                _url = System.String.Empty;
            }
        }

        public bool IsErrorMessageNull
        {
            get { return _isErrorMessageNull; }
            set
            {
                if (!value) throw new Exception("Can not set this property to false");
                _isErrorMessageNull = value;
                _errorMessage = System.String.Empty;
            }
        }

        public bool IsAdditionalInfoNull
        {
            get { return _isAdditionalInfoNull; }
            set
            {
                if (!value) throw new Exception("Can not set this property to false");
                _isAdditionalInfoNull = value;
                _additionalInfo = System.String.Empty;
            }
        }


        #endregion

        #region Constructor
        public ErrorLog()
        {
        }
        #endregion

        #region Methods
        public static ErrorLog LoadErrorLog(int errorLogId)
        {
            SqlDataAdapter adapter = new SqlDataAdapter("LoadErrorLog", ProtestLib.Global.Connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@Id", errorLogId);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            if (dt.Rows.Count == 0) return null;
            DataRow row = dt.Rows[0];
            return GetErrorLog(row);
        }

        internal static ErrorLog GetErrorLog(DataRow row)
        {
            ErrorLog result = new ErrorLog();
            if (row.Table.Columns.Contains("Id"))
            {
                if (Convert.IsDBNull(row["Id"]))
                {
                    result._isIdNull = true;
                }
                else
                {
                    result._id = Convert.ToInt32(row["Id"]);
                    result._isIdNull = false;
                }
            }

            if (row.Table.Columns.Contains("ErrorDate"))
            {
                if (Convert.IsDBNull(row["ErrorDate"]))
                {
                    result._isErrorDateNull = true;
                }
                else
                {
                    result._errorDate = Convert.ToDateTime(row["ErrorDate"]);
                    result._isErrorDateNull = false;
                }
            }

            if (row.Table.Columns.Contains("Url"))
            {
                if (Convert.IsDBNull(row["Url"]))
                {
                    result._isUrlNull = true;
                }
                else
                {
                    result._url = Convert.ToString(row["Url"]);
                    result._isUrlNull = false;
                }
            }

            if (row.Table.Columns.Contains("ErrorMessage"))
            {
                if (Convert.IsDBNull(row["ErrorMessage"]))
                {
                    result._isErrorMessageNull = true;
                }
                else
                {
                    result._errorMessage = Convert.ToString(row["ErrorMessage"]);
                    result._isErrorMessageNull = false;
                }
            }

            if (row.Table.Columns.Contains("AdditionalInfo"))
            {
                if (Convert.IsDBNull(row["AdditionalInfo"]))
                {
                    result._isAdditionalInfoNull = true;
                }
                else
                {
                    result._additionalInfo = Convert.ToString(row["AdditionalInfo"]);
                    result._isAdditionalInfoNull = false;
                }
            }

            return result;
        }

        public static SqlCommand GetSaveCommand(ErrorLog errorLog, SqlConnection conn)
        {
            SqlCommand cmd = new SqlCommand("SaveErrorLog", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            if (errorLog._isIdNull)
            {
                cmd.Parameters.AddWithValue("@Id", System.DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Id", errorLog._id);
            }

            if (errorLog._isErrorDateNull)
            {
                cmd.Parameters.AddWithValue("@ErrorDate", System.DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@ErrorDate", errorLog._errorDate);
            }

            if (errorLog._isUrlNull)
            {
                cmd.Parameters.AddWithValue("@Url", System.DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Url", errorLog._url);
            }

            if (errorLog._isErrorMessageNull)
            {
                cmd.Parameters.AddWithValue("@ErrorMessage", System.DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@ErrorMessage", errorLog._errorMessage);
            }

            if (errorLog._isAdditionalInfoNull)
            {
                cmd.Parameters.AddWithValue("@AdditionalInfo", System.DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@AdditionalInfo", errorLog._additionalInfo);
            }

            return cmd;
        }

        public static int SaveErrorLog(ErrorLog errorLog)
        {
            int result = 0;
            SqlCommand cmd = GetSaveCommand(errorLog, ProtestLib.Global.Connection);
            cmd.Connection.Open();
            try
            {
                Utils.SetContextInfo(cmd.Connection);
                result = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }
            errorLog.Id = result;
            return result;
        }
        public int Save()
        {
            return ErrorLog.SaveErrorLog(this);
        }

        public static void DeleteErrorLog(int errorLogId)
        {
            SqlCommand cmd = new SqlCommand("DeleteErrorLog", ProtestLib.Global.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", errorLogId);
            cmd.Connection.Open();
            try
            {
                Utils.SetContextInfo(cmd.Connection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }
        }

        public object GetPropertyValue(string propertyName)
        {
            return Utils.GetPropertyValue<ErrorLog>(this, propertyName);
        }

        #endregion

    }
}




