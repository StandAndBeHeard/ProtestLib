

using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace ProtestLib
{
	[Serializable]
	public partial class Participant
	{
		#region Declarations
		System.Int32 _id;
		System.Int32 _protestId;
		System.Int32 _userId;
		System.DateTime _dateJoined;

		bool _isIdNull = true;
		bool _isProtestIdNull = true;
		bool _isUserIdNull = true;
		bool _isDateJoinedNull = true;
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
		public System.Int32 UserId
		{
			get { return _userId; }
			set { _userId = value; _isUserIdNull = false; }
		}
		public System.DateTime DateJoined
		{
			get { return _dateJoined; }
			set { _dateJoined = value; _isDateJoinedNull = false; }
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
		public bool IsDateJoinedNull
		{
			get { return _isDateJoinedNull; }
			set
			{
				if (!value) throw new Exception("Can not set this property to false");
				_isDateJoinedNull = value;
				_dateJoined = DateTime.MinValue;
			}
		}
		#endregion

		#region Constructors
		public Participant()
		{
		}

		public Participant(DataRow row)
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
			if (row.Table.Columns.Contains("UserId"))
			{
				if (Convert.IsDBNull(row["UserId"])) this.IsUserIdNull = true;
				else this.UserId = Convert.ToInt32(row["UserId"]);
			}
			if (row.Table.Columns.Contains("DateJoined"))
			{
				if (Convert.IsDBNull(row["DateJoined"])) this.IsDateJoinedNull = true;
				else this.DateJoined = Convert.ToDateTime(row["DateJoined"]);
			}
		}
		#endregion

		#region Methods
		public static Participant Load(string sql, CommandType commandType = CommandType.Text, SqlParameter[] parameters = null)
		{
			Participants participants = Participants.Load(sql, commandType, parameters);
			return (participants.Count == 0) ? null : participants[0];
		}

		public static Participant Load(int id)
		{
			return Load("LoadParticipant", CommandType.StoredProcedure, new SqlParameter[] { new SqlParameter("@Id", id) });
		}

		internal SqlCommand GetSaveCommand(SqlConnection conn)
		{
			SqlCommand cmd = new SqlCommand("SaveParticipant", conn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@Id", (_isIdNull) ? System.DBNull.Value : (object)_id);
			cmd.Parameters.AddWithValue("@ProtestId", (_isProtestIdNull) ? System.DBNull.Value : (object)_protestId);
			cmd.Parameters.AddWithValue("@UserId", (_isUserIdNull) ? System.DBNull.Value : (object)_userId);
			cmd.Parameters.AddWithValue("@DateJoined", (_isDateJoinedNull) ? System.DBNull.Value : (object)_dateJoined);
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
			DBHelper.ExecuteNonQuery("DeleteParticipant", CommandType.StoredProcedure, new SqlParameter[] { new SqlParameter("@Id", id) });
		}

		public object GetPropertyValue(string propertyName)
		{
			return typeof(Participant).GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance).GetValue(this, null);
		}
		#endregion
	}
}
