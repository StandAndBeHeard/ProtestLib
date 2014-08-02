

using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace ProtestLib
{
	[Serializable]
	public partial class ProtestUpdate
	{
		#region Declarations
		System.Int32 _id;
		System.Int32 _protestId;
		System.DateTime _postedDate;
		System.String _body;

		bool _isIdNull = true;
		bool _isProtestIdNull = true;
		bool _isPostedDateNull = true;
		bool _isBodyNull = true;
		#endregion

		#region Properties
		public System.Int32 Id
		{
			get { return _id; }
			set { _id = value; _isIdNull = false; }
		}
		public System.Int32 ProtestId
		{
			get { return _protestId; }
			set { _protestId = value; _isProtestIdNull = false; }
		}
		public System.DateTime PostedDate
		{
			get { return _postedDate; }
			set { _postedDate = value; _isPostedDateNull = false; }
		}
		public System.String Body
		{
			get { return _body; }
			set { _body = value; _isBodyNull = false; }
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
		public bool IsProtestIdNull
		{
			get { return _isProtestIdNull; }
			set
			{
				if (!value) throw new Exception("Can not set this property to false");
				_isProtestIdNull = value;
				_protestId = -1;
			}
		}
		public bool IsPostedDateNull
		{
			get { return _isPostedDateNull; }
			set
			{
				if (!value) throw new Exception("Can not set this property to false");
				_isPostedDateNull = value;
				_postedDate = DateTime.MinValue;
			}
		}
		public bool IsBodyNull
		{
			get { return _isBodyNull; }
			set
			{
				if (!value) throw new Exception("Can not set this property to false");
				_isBodyNull = value;
				_body = System.String.Empty;
			}
		}
		#endregion

		#region Constructors
		public ProtestUpdate()
		{
		}

		public ProtestUpdate(DataRow row)
		{
			if (row.Table.Columns.Contains("Id"))
			{
				if (Convert.IsDBNull(row["Id"])) this.IsIdNull = true;
				else this.Id = Convert.ToInt32(row["Id"]);
			}
			if (row.Table.Columns.Contains("ProtestId"))
			{
				if (Convert.IsDBNull(row["ProtestId"])) this.IsProtestIdNull = true;
				else this.ProtestId = Convert.ToInt32(row["ProtestId"]);
			}
			if (row.Table.Columns.Contains("PostedDate"))
			{
				if (Convert.IsDBNull(row["PostedDate"])) this.IsPostedDateNull = true;
				else this.PostedDate = Convert.ToDateTime(row["PostedDate"]);
			}
			if (row.Table.Columns.Contains("Body"))
			{
				if (Convert.IsDBNull(row["Body"])) this.IsBodyNull = true;
				else this.Body = Convert.ToString(row["Body"]);
			}
		}
		#endregion

		#region Methods
		public static ProtestUpdate Load(string sql, CommandType commandType = CommandType.Text, SqlParameter[] parameters = null)
		{
			ProtestUpdates protestUpdates = ProtestUpdates.Load(sql, commandType, parameters);
			return (protestUpdates.Count == 0) ? null : protestUpdates[0];
		}

		public static ProtestUpdate Load(int id)
		{
			return Load("LoadProtestUpdate", CommandType.StoredProcedure, new SqlParameter[] { new SqlParameter("@Id", id) });
		}

		internal SqlCommand GetSaveCommand(SqlConnection conn)
		{
			SqlCommand cmd = new SqlCommand("SaveProtestUpdate", conn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@Id", (_isIdNull) ? System.DBNull.Value : (object)_id);
			cmd.Parameters.AddWithValue("@ProtestId", (_isProtestIdNull) ? System.DBNull.Value : (object)_protestId);
			cmd.Parameters.AddWithValue("@PostedDate", (_isPostedDateNull) ? System.DBNull.Value : (object)_postedDate);
			cmd.Parameters.AddWithValue("@Body", (_isBodyNull) ? System.DBNull.Value : (object)_body);
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
			DBHelper.ExecuteNonQuery("DeleteProtestUpdate", CommandType.StoredProcedure, new SqlParameter[] { new SqlParameter("@Id", id) });
		}

		public object GetPropertyValue(string propertyName)
		{
			return typeof(ProtestUpdate).GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance).GetValue(this, null);
		}
		#endregion
	}
}
