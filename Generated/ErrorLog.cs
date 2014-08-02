

using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

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
			set { _id = value; _isIdNull = false; }
		}
		public System.DateTime ErrorDate
		{
			get { return _errorDate; }
			set { _errorDate = value; _isErrorDateNull = false; }
		}
		public System.String Url
		{
			get { return _url; }
			set { _url = value; _isUrlNull = false; }
		}
		public System.String ErrorMessage
		{
			get { return _errorMessage; }
			set { _errorMessage = value; _isErrorMessageNull = false; }
		}
		public System.String AdditionalInfo
		{
			get { return _additionalInfo; }
			set { _additionalInfo = value; _isAdditionalInfoNull = false; }
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

		#region Constructors
		public ErrorLog()
		{
		}

		public ErrorLog(DataRow row)
		{
			if (row.Table.Columns.Contains("Id"))
			{
				if (Convert.IsDBNull(row["Id"])) this.IsIdNull = true;
				else this.Id = Convert.ToInt32(row["Id"]);
			}
			if (row.Table.Columns.Contains("ErrorDate"))
			{
				if (Convert.IsDBNull(row["ErrorDate"])) this.IsErrorDateNull = true;
				else this.ErrorDate = Convert.ToDateTime(row["ErrorDate"]);
			}
			if (row.Table.Columns.Contains("Url"))
			{
				if (Convert.IsDBNull(row["Url"])) this.IsUrlNull = true;
				else this.Url = Convert.ToString(row["Url"]);
			}
			if (row.Table.Columns.Contains("ErrorMessage"))
			{
				if (Convert.IsDBNull(row["ErrorMessage"])) this.IsErrorMessageNull = true;
				else this.ErrorMessage = Convert.ToString(row["ErrorMessage"]);
			}
			if (row.Table.Columns.Contains("AdditionalInfo"))
			{
				if (Convert.IsDBNull(row["AdditionalInfo"])) this.IsAdditionalInfoNull = true;
				else this.AdditionalInfo = Convert.ToString(row["AdditionalInfo"]);
			}
		}
		#endregion

		#region Methods
		public static ErrorLog Load(string sql, CommandType commandType = CommandType.Text, SqlParameter[] parameters = null)
		{
			ErrorLogs errorLogs = ErrorLogs.Load(sql, commandType, parameters);
			return (errorLogs.Count == 0) ? null : errorLogs[0];
		}

		public static ErrorLog Load(int id)
		{
			return Load("LoadErrorLog", CommandType.StoredProcedure, new SqlParameter[] { new SqlParameter("@Id", id) });
		}

		internal SqlCommand GetSaveCommand(SqlConnection conn)
		{
			SqlCommand cmd = new SqlCommand("SaveErrorLog", conn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@Id", (_isIdNull) ? System.DBNull.Value : (object)_id);
			cmd.Parameters.AddWithValue("@ErrorDate", (_isErrorDateNull) ? System.DBNull.Value : (object)_errorDate);
			cmd.Parameters.AddWithValue("@Url", (_isUrlNull) ? System.DBNull.Value : (object)_url);
			cmd.Parameters.AddWithValue("@ErrorMessage", (_isErrorMessageNull) ? System.DBNull.Value : (object)_errorMessage);
			cmd.Parameters.AddWithValue("@AdditionalInfo", (_isAdditionalInfoNull) ? System.DBNull.Value : (object)_additionalInfo);
			return cmd;
		}

		public int Save()
		{
			SqlCommand cmd = GetSaveCommand(DBHelper.Connection);
			cmd.Connection.Open();
			try
			{
				DBHelper.SetContextInfo(cmd.Connection);
				Id = Convert.ToInt32(cmd.ExecuteScalar());
			}
			catch (Exception ex) { throw ex; }
			finally { cmd.Connection.Close(); }
			return Id;
		}

		public static void Delete(int id)
		{
			DBHelper.ExecuteNonQuery("DeleteErrorLog", CommandType.StoredProcedure, new SqlParameter[] { new SqlParameter("@Id", id) });
		}

		public object GetPropertyValue(string propertyName)
		{
			return typeof(ErrorLog).GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance).GetValue(this, null);
		}
		#endregion
	}
}
