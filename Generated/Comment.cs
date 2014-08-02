

using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace ProtestLib
{
	[Serializable]
	public partial class Comment
	{
		#region Declarations
		System.Int32 _id;
		System.String _contentType;
		System.Int32 _contentId;
		System.Int32 _parentId;
		System.Int32 _userId;
		System.String _body;
		System.DateTime _postedDate;
		System.Boolean _active;
		System.String _ipAddress;

		bool _isIdNull = true;
		bool _isContentTypeNull = true;
		bool _isContentIdNull = true;
		bool _isParentIdNull = true;
		bool _isUserIdNull = true;
		bool _isBodyNull = true;
		bool _isPostedDateNull = true;
		bool _isActiveNull = true;
		bool _isIpAddressNull = true;
		#endregion

		#region Properties
		public System.Int32 Id
		{
			get { return _id; }
			set { _id = value; _isIdNull = false; }
		}
		public System.String ContentType
		{
			get { return _contentType; }
			set { _contentType = value; _isContentTypeNull = false; }
		}
		public System.Int32 ContentId
		{
			get { return _contentId; }
			set { _contentId = value; _isContentIdNull = false; }
		}
		public System.Int32 ParentId
		{
			get { return _parentId; }
			set { _parentId = value; _isParentIdNull = false; }
		}
		public System.Int32 UserId
		{
			get { return _userId; }
			set { _userId = value; _isUserIdNull = false; }
		}
		public System.String Body
		{
			get { return _body; }
			set { _body = value; _isBodyNull = false; }
		}
		public System.DateTime PostedDate
		{
			get { return _postedDate; }
			set { _postedDate = value; _isPostedDateNull = false; }
		}
		public System.Boolean Active
		{
			get { return _active; }
			set { _active = value; _isActiveNull = false; }
		}
		public System.String IpAddress
		{
			get { return _ipAddress; }
			set { _ipAddress = value; _isIpAddressNull = false; }
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
		public bool IsContentTypeNull
		{
			get { return _isContentTypeNull; }
			set
			{
				if (!value) throw new Exception("Can not set this property to false");
				_isContentTypeNull = value;
				_contentType = System.String.Empty;
			}
		}
		public bool IsContentIdNull
		{
			get { return _isContentIdNull; }
			set
			{
				if (!value) throw new Exception("Can not set this property to false");
				_isContentIdNull = value;
				_contentId = -1;
			}
		}
		public bool IsParentIdNull
		{
			get { return _isParentIdNull; }
			set
			{
				if (!value) throw new Exception("Can not set this property to false");
				_isParentIdNull = value;
				_parentId = -1;
			}
		}
		public bool IsUserIdNull
		{
			get { return _isUserIdNull; }
			set
			{
				if (!value) throw new Exception("Can not set this property to false");
				_isUserIdNull = value;
				_userId = -1;
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
		public bool IsActiveNull
		{
			get { return _isActiveNull; }
			set
			{
				if (!value) throw new Exception("Can not set this property to false");
				_isActiveNull = value;
				_active = false;
			}
		}
		public bool IsIpAddressNull
		{
			get { return _isIpAddressNull; }
			set
			{
				if (!value) throw new Exception("Can not set this property to false");
				_isIpAddressNull = value;
				_ipAddress = System.String.Empty;
			}
		}
		#endregion

		#region Constructors
		public Comment()
		{
		}

		public Comment(DataRow row)
		{
			if (row.Table.Columns.Contains("Id"))
			{
				if (Convert.IsDBNull(row["Id"])) this.IsIdNull = true;
				else this.Id = Convert.ToInt32(row["Id"]);
			}
			if (row.Table.Columns.Contains("ContentType"))
			{
				if (Convert.IsDBNull(row["ContentType"])) this.IsContentTypeNull = true;
				else this.ContentType = Convert.ToString(row["ContentType"]);
			}
			if (row.Table.Columns.Contains("ContentId"))
			{
				if (Convert.IsDBNull(row["ContentId"])) this.IsContentIdNull = true;
				else this.ContentId = Convert.ToInt32(row["ContentId"]);
			}
			if (row.Table.Columns.Contains("ParentId"))
			{
				if (Convert.IsDBNull(row["ParentId"])) this.IsParentIdNull = true;
				else this.ParentId = Convert.ToInt32(row["ParentId"]);
			}
			if (row.Table.Columns.Contains("UserId"))
			{
				if (Convert.IsDBNull(row["UserId"])) this.IsUserIdNull = true;
				else this.UserId = Convert.ToInt32(row["UserId"]);
			}
			if (row.Table.Columns.Contains("Body"))
			{
				if (Convert.IsDBNull(row["Body"])) this.IsBodyNull = true;
				else this.Body = Convert.ToString(row["Body"]);
			}
			if (row.Table.Columns.Contains("PostedDate"))
			{
				if (Convert.IsDBNull(row["PostedDate"])) this.IsPostedDateNull = true;
				else this.PostedDate = Convert.ToDateTime(row["PostedDate"]);
			}
			if (row.Table.Columns.Contains("Active"))
			{
				if (Convert.IsDBNull(row["Active"])) this.IsActiveNull = true;
				else this.Active = Convert.ToBoolean(row["Active"]);
			}
			if (row.Table.Columns.Contains("IpAddress"))
			{
				if (Convert.IsDBNull(row["IpAddress"])) this.IsIpAddressNull = true;
				else this.IpAddress = Convert.ToString(row["IpAddress"]);
			}
		}
		#endregion

		#region Methods
		public static Comment Load(string sql, CommandType commandType = CommandType.Text, SqlParameter[] parameters = null)
		{
			Comments comments = Comments.Load(sql, commandType, parameters);
			return (comments.Count == 0) ? null : comments[0];
		}

		public static Comment Load(int id)
		{
			return Load("LoadComment", CommandType.StoredProcedure, new SqlParameter[] { new SqlParameter("@Id", id) });
		}

		internal SqlCommand GetSaveCommand(SqlConnection conn)
		{
			SqlCommand cmd = new SqlCommand("SaveComment", conn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@Id", (_isIdNull) ? System.DBNull.Value : (object)_id);
			cmd.Parameters.AddWithValue("@ContentType", (_isContentTypeNull) ? System.DBNull.Value : (object)_contentType);
			cmd.Parameters.AddWithValue("@ContentId", (_isContentIdNull) ? System.DBNull.Value : (object)_contentId);
			cmd.Parameters.AddWithValue("@ParentId", (_isParentIdNull) ? System.DBNull.Value : (object)_parentId);
			cmd.Parameters.AddWithValue("@UserId", (_isUserIdNull) ? System.DBNull.Value : (object)_userId);
			cmd.Parameters.AddWithValue("@Body", (_isBodyNull) ? System.DBNull.Value : (object)_body);
			cmd.Parameters.AddWithValue("@PostedDate", (_isPostedDateNull) ? System.DBNull.Value : (object)_postedDate);
			cmd.Parameters.AddWithValue("@Active", (_isActiveNull) ? System.DBNull.Value : (object)_active);
			cmd.Parameters.AddWithValue("@IpAddress", (_isIpAddressNull) ? System.DBNull.Value : (object)_ipAddress);
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
			DBHelper.ExecuteNonQuery("DeleteComment", CommandType.StoredProcedure, new SqlParameter[] { new SqlParameter("@Id", id) });
		}

		public object GetPropertyValue(string propertyName)
		{
			return typeof(Comment).GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance).GetValue(this, null);
		}
		#endregion
	}
}
