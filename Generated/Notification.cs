

using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace ProtestLib
{
	[Serializable]
	public partial class Notification
	{
		#region Declarations
		System.Int32 _id;
		System.Int32 _userId;
		System.String _title;
		System.String _body;
		System.String _link;
		System.DateTime _creationDate;
		System.DateTime _notificationDate;

		bool _isIdNull = true;
		bool _isUserIdNull = true;
		bool _isTitleNull = true;
		bool _isBodyNull = true;
		bool _isLinkNull = true;
		bool _isCreationDateNull = true;
		bool _isNotificationDateNull = true;
		#endregion

		#region Properties
		public System.Int32 Id
		{
			get { return _id; }
			set { _id = value; _isIdNull = false; }
		}
		public System.Int32 UserId
		{
			get { return _userId; }
			set { _userId = value; _isUserIdNull = false; }
		}
		public System.String Title
		{
			get { return _title; }
			set { _title = value; _isTitleNull = false; }
		}
		public System.String Body
		{
			get { return _body; }
			set { _body = value; _isBodyNull = false; }
		}
		public System.String Link
		{
			get { return _link; }
			set { _link = value; _isLinkNull = false; }
		}
		public System.DateTime CreationDate
		{
			get { return _creationDate; }
			set { _creationDate = value; _isCreationDateNull = false; }
		}
		public System.DateTime NotificationDate
		{
			get { return _notificationDate; }
			set { _notificationDate = value; _isNotificationDateNull = false; }
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
		public bool IsLinkNull
		{
			get { return _isLinkNull; }
			set
			{
				if (!value) throw new Exception("Can not set this property to false");
				_isLinkNull = value;
				_link = System.String.Empty;
			}
		}
		public bool IsCreationDateNull
		{
			get { return _isCreationDateNull; }
			set
			{
				if (!value) throw new Exception("Can not set this property to false");
				_isCreationDateNull = value;
				_creationDate = DateTime.MinValue;
			}
		}
		public bool IsNotificationDateNull
		{
			get { return _isNotificationDateNull; }
			set
			{
				if (!value) throw new Exception("Can not set this property to false");
				_isNotificationDateNull = value;
				_notificationDate = DateTime.MinValue;
			}
		}
		#endregion

		#region Constructors
		public Notification()
		{
		}

		public Notification(DataRow row)
		{
			if (row.Table.Columns.Contains("Id"))
			{
				if (Convert.IsDBNull(row["Id"])) this.IsIdNull = true;
				else this.Id = Convert.ToInt32(row["Id"]);
			}
			if (row.Table.Columns.Contains("UserId"))
			{
				if (Convert.IsDBNull(row["UserId"])) this.IsUserIdNull = true;
				else this.UserId = Convert.ToInt32(row["UserId"]);
			}
			if (row.Table.Columns.Contains("Title"))
			{
				if (Convert.IsDBNull(row["Title"])) this.IsTitleNull = true;
				else this.Title = Convert.ToString(row["Title"]);
			}
			if (row.Table.Columns.Contains("Body"))
			{
				if (Convert.IsDBNull(row["Body"])) this.IsBodyNull = true;
				else this.Body = Convert.ToString(row["Body"]);
			}
			if (row.Table.Columns.Contains("Link"))
			{
				if (Convert.IsDBNull(row["Link"])) this.IsLinkNull = true;
				else this.Link = Convert.ToString(row["Link"]);
			}
			if (row.Table.Columns.Contains("CreationDate"))
			{
				if (Convert.IsDBNull(row["CreationDate"])) this.IsCreationDateNull = true;
				else this.CreationDate = Convert.ToDateTime(row["CreationDate"]);
			}
			if (row.Table.Columns.Contains("NotificationDate"))
			{
				if (Convert.IsDBNull(row["NotificationDate"])) this.IsNotificationDateNull = true;
				else this.NotificationDate = Convert.ToDateTime(row["NotificationDate"]);
			}
		}
		#endregion

		#region Methods
		public static Notification Load(string sql, CommandType commandType = CommandType.Text, SqlParameter[] parameters = null)
		{
			Notifications notifications = Notifications.Load(sql, commandType, parameters);
			return (notifications.Count == 0) ? null : notifications[0];
		}

		public static Notification Load(int id)
		{
			return Load("LoadNotification", CommandType.StoredProcedure, new SqlParameter[] { new SqlParameter("@Id", id) });
		}

		internal SqlCommand GetSaveCommand(SqlConnection conn)
		{
			SqlCommand cmd = new SqlCommand("SaveNotification", conn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@Id", (_isIdNull) ? System.DBNull.Value : (object)_id);
			cmd.Parameters.AddWithValue("@UserId", (_isUserIdNull) ? System.DBNull.Value : (object)_userId);
			cmd.Parameters.AddWithValue("@Title", (_isTitleNull) ? System.DBNull.Value : (object)_title);
			cmd.Parameters.AddWithValue("@Body", (_isBodyNull) ? System.DBNull.Value : (object)_body);
			cmd.Parameters.AddWithValue("@Link", (_isLinkNull) ? System.DBNull.Value : (object)_link);
			cmd.Parameters.AddWithValue("@CreationDate", (_isCreationDateNull) ? System.DBNull.Value : (object)_creationDate);
			cmd.Parameters.AddWithValue("@NotificationDate", (_isNotificationDateNull) ? System.DBNull.Value : (object)_notificationDate);
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
			DBHelper.ExecuteNonQuery("DeleteNotification", CommandType.StoredProcedure, new SqlParameter[] { new SqlParameter("@Id", id) });
		}

		public object GetPropertyValue(string propertyName)
		{
			return typeof(Notification).GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance).GetValue(this, null);
		}
		#endregion
	}
}
