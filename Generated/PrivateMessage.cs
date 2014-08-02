

using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace ProtestLib
{
	[Serializable]
	public partial class PrivateMessage
	{
		#region Declarations
		System.Int32 _id;
		System.Int32 _fromId;
		System.Int32 _toId;
		System.String _title;

		bool _isIdNull = true;
		bool _isFromIdNull = true;
		bool _isToIdNull = true;
		bool _isTitleNull = true;
		#endregion

		#region Properties
		public System.Int32 Id
		{
			get { return _id; }
			set { _id = value; _isIdNull = false; }
		}
		public System.Int32 FromId
		{
			get { return _fromId; }
			set { _fromId = value; _isFromIdNull = false; }
		}
		public System.Int32 ToId
		{
			get { return _toId; }
			set { _toId = value; _isToIdNull = false; }
		}
		public System.String Title
		{
			get { return _title; }
			set { _title = value; _isTitleNull = false; }
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
		public bool IsFromIdNull
		{
			get { return _isFromIdNull; }
			set
			{
				if (!value) throw new Exception("Can not set this property to false");
				_isFromIdNull = value;
				_fromId = -1;
			}
		}
		public bool IsToIdNull
		{
			get { return _isToIdNull; }
			set
			{
				if (!value) throw new Exception("Can not set this property to false");
				_isToIdNull = value;
				_toId = -1;
			}
		}
		public bool IsTitleNull
		{
			get { return _isTitleNull; }
			set
			{
				if (!value) throw new Exception("Can not set this property to false");
				_isTitleNull = value;
				_title = System.String.Empty;
			}
		}
		#endregion

		#region Constructors
		public PrivateMessage()
		{
		}

		public PrivateMessage(DataRow row)
		{
			if (row.Table.Columns.Contains("Id"))
			{
				if (Convert.IsDBNull(row["Id"])) this.IsIdNull = true;
				else this.Id = Convert.ToInt32(row["Id"]);
			}
			if (row.Table.Columns.Contains("FromId"))
			{
				if (Convert.IsDBNull(row["FromId"])) this.IsFromIdNull = true;
				else this.FromId = Convert.ToInt32(row["FromId"]);
			}
			if (row.Table.Columns.Contains("ToId"))
			{
				if (Convert.IsDBNull(row["ToId"])) this.IsToIdNull = true;
				else this.ToId = Convert.ToInt32(row["ToId"]);
			}
			if (row.Table.Columns.Contains("Title"))
			{
				if (Convert.IsDBNull(row["Title"])) this.IsTitleNull = true;
				else this.Title = Convert.ToString(row["Title"]);
			}
		}
		#endregion

		#region Methods
		public static PrivateMessage Load(string sql, CommandType commandType = CommandType.Text, SqlParameter[] parameters = null)
		{
			PrivateMessages privateMessages = PrivateMessages.Load(sql, commandType, parameters);
			return (privateMessages.Count == 0) ? null : privateMessages[0];
		}

		public static PrivateMessage Load(int id)
		{
			return Load("LoadPrivateMessage", CommandType.StoredProcedure, new SqlParameter[] { new SqlParameter("@Id", id) });
		}

		internal SqlCommand GetSaveCommand(SqlConnection conn)
		{
			SqlCommand cmd = new SqlCommand("SavePrivateMessage", conn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@Id", (_isIdNull) ? System.DBNull.Value : (object)_id);
			cmd.Parameters.AddWithValue("@FromId", (_isFromIdNull) ? System.DBNull.Value : (object)_fromId);
			cmd.Parameters.AddWithValue("@ToId", (_isToIdNull) ? System.DBNull.Value : (object)_toId);
			cmd.Parameters.AddWithValue("@Title", (_isTitleNull) ? System.DBNull.Value : (object)_title);
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
			DBHelper.ExecuteNonQuery("DeletePrivateMessage", CommandType.StoredProcedure, new SqlParameter[] { new SqlParameter("@Id", id) });
		}

		public object GetPropertyValue(string propertyName)
		{
			return typeof(PrivateMessage).GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance).GetValue(this, null);
		}
		#endregion
	}
}
