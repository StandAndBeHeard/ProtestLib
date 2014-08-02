

using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace ProtestLib
{
	[Serializable]
	public partial class User
	{
		#region Declarations
		System.Int32 _id;
		System.String _userName;
		System.String _email;
		System.String _passwordHash;
		System.DateTime _registrationDate;
		System.DateTime _lastLoginDate;
		System.Boolean _contactDemonstrations;
		System.Boolean _contactOther;

		bool _isIdNull = true;
		bool _isUserNameNull = true;
		bool _isEmailNull = true;
		bool _isPasswordHashNull = true;
		bool _isRegistrationDateNull = true;
		bool _isLastLoginDateNull = true;
		bool _isContactDemonstrationsNull = true;
		bool _isContactOtherNull = true;
		#endregion

		#region Properties
		public System.Int32 Id
		{
			get { return _id; }
			set { _id = value; _isIdNull = false; }
		}
		public System.String UserName
		{
			get { return _userName; }
			set { _userName = value; _isUserNameNull = false; }
		}
		public System.String Email
		{
			get { return _email; }
			set { _email = value; _isEmailNull = false; }
		}
		public System.String PasswordHash
		{
			get { return _passwordHash; }
			set { _passwordHash = value; _isPasswordHashNull = false; }
		}
		public System.DateTime RegistrationDate
		{
			get { return _registrationDate; }
			set { _registrationDate = value; _isRegistrationDateNull = false; }
		}
		public System.DateTime LastLoginDate
		{
			get { return _lastLoginDate; }
			set { _lastLoginDate = value; _isLastLoginDateNull = false; }
		}
		public System.Boolean ContactDemonstrations
		{
			get { return _contactDemonstrations; }
			set { _contactDemonstrations = value; _isContactDemonstrationsNull = false; }
		}
		public System.Boolean ContactOther
		{
			get { return _contactOther; }
			set { _contactOther = value; _isContactOtherNull = false; }
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
		public bool IsUserNameNull
		{
			get { return _isUserNameNull; }
			set
			{
				if (!value) throw new Exception("Can not set this property to false");
				_isUserNameNull = value;
				_userName = System.String.Empty;
			}
		}
		public bool IsEmailNull
		{
			get { return _isEmailNull; }
			set
			{
				if (!value) throw new Exception("Can not set this property to false");
				_isEmailNull = value;
				_email = System.String.Empty;
			}
		}
		public bool IsPasswordHashNull
		{
			get { return _isPasswordHashNull; }
			set
			{
				if (!value) throw new Exception("Can not set this property to false");
				_isPasswordHashNull = value;
				_passwordHash = System.String.Empty;
			}
		}
		public bool IsRegistrationDateNull
		{
			get { return _isRegistrationDateNull; }
			set
			{
				if (!value) throw new Exception("Can not set this property to false");
				_isRegistrationDateNull = value;
				_registrationDate = DateTime.MinValue;
			}
		}
		public bool IsLastLoginDateNull
		{
			get { return _isLastLoginDateNull; }
			set
			{
				if (!value) throw new Exception("Can not set this property to false");
				_isLastLoginDateNull = value;
				_lastLoginDate = DateTime.MinValue;
			}
		}
		public bool IsContactDemonstrationsNull
		{
			get { return _isContactDemonstrationsNull; }
			set
			{
				if (!value) throw new Exception("Can not set this property to false");
				_isContactDemonstrationsNull = value;
				_contactDemonstrations = false;
			}
		}
		public bool IsContactOtherNull
		{
			get { return _isContactOtherNull; }
			set
			{
				if (!value) throw new Exception("Can not set this property to false");
				_isContactOtherNull = value;
				_contactOther = false;
			}
		}
		#endregion

		#region Constructors
		public User()
		{
		}

		public User(DataRow row)
		{
			if (row.Table.Columns.Contains("Id"))
			{
				if (Convert.IsDBNull(row["Id"])) this.IsIdNull = true;
				else this.Id = Convert.ToInt32(row["Id"]);
			}
			if (row.Table.Columns.Contains("UserName"))
			{
				if (Convert.IsDBNull(row["UserName"])) this.IsUserNameNull = true;
				else this.UserName = Convert.ToString(row["UserName"]);
			}
			if (row.Table.Columns.Contains("Email"))
			{
				if (Convert.IsDBNull(row["Email"])) this.IsEmailNull = true;
				else this.Email = Convert.ToString(row["Email"]);
			}
			if (row.Table.Columns.Contains("PasswordHash"))
			{
				if (Convert.IsDBNull(row["PasswordHash"])) this.IsPasswordHashNull = true;
				else this.PasswordHash = Convert.ToString(row["PasswordHash"]);
			}
			if (row.Table.Columns.Contains("RegistrationDate"))
			{
				if (Convert.IsDBNull(row["RegistrationDate"])) this.IsRegistrationDateNull = true;
				else this.RegistrationDate = Convert.ToDateTime(row["RegistrationDate"]);
			}
			if (row.Table.Columns.Contains("LastLoginDate"))
			{
				if (Convert.IsDBNull(row["LastLoginDate"])) this.IsLastLoginDateNull = true;
				else this.LastLoginDate = Convert.ToDateTime(row["LastLoginDate"]);
			}
			if (row.Table.Columns.Contains("ContactDemonstrations"))
			{
				if (Convert.IsDBNull(row["ContactDemonstrations"])) this.IsContactDemonstrationsNull = true;
				else this.ContactDemonstrations = Convert.ToBoolean(row["ContactDemonstrations"]);
			}
			if (row.Table.Columns.Contains("ContactOther"))
			{
				if (Convert.IsDBNull(row["ContactOther"])) this.IsContactOtherNull = true;
				else this.ContactOther = Convert.ToBoolean(row["ContactOther"]);
			}
		}
		#endregion

		#region Methods
		public static User Load(string sql, CommandType commandType = CommandType.Text, SqlParameter[] parameters = null)
		{
			Users users = Users.Load(sql, commandType, parameters);
			return (users.Count == 0) ? null : users[0];
		}

		public static User Load(int id)
		{
			return Load("LoadUser", CommandType.StoredProcedure, new SqlParameter[] { new SqlParameter("@Id", id) });
		}

		internal SqlCommand GetSaveCommand(SqlConnection conn)
		{
			SqlCommand cmd = new SqlCommand("SaveUser", conn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@Id", (_isIdNull) ? System.DBNull.Value : (object)_id);
			cmd.Parameters.AddWithValue("@UserName", (_isUserNameNull) ? System.DBNull.Value : (object)_userName);
			cmd.Parameters.AddWithValue("@Email", (_isEmailNull) ? System.DBNull.Value : (object)_email);
			cmd.Parameters.AddWithValue("@PasswordHash", (_isPasswordHashNull) ? System.DBNull.Value : (object)_passwordHash);
			cmd.Parameters.AddWithValue("@RegistrationDate", (_isRegistrationDateNull) ? System.DBNull.Value : (object)_registrationDate);
			cmd.Parameters.AddWithValue("@LastLoginDate", (_isLastLoginDateNull) ? System.DBNull.Value : (object)_lastLoginDate);
			cmd.Parameters.AddWithValue("@ContactDemonstrations", (_isContactDemonstrationsNull) ? System.DBNull.Value : (object)_contactDemonstrations);
			cmd.Parameters.AddWithValue("@ContactOther", (_isContactOtherNull) ? System.DBNull.Value : (object)_contactOther);
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
			DBHelper.ExecuteNonQuery("DeleteUser", CommandType.StoredProcedure, new SqlParameter[] { new SqlParameter("@Id", id) });
		}

		public object GetPropertyValue(string propertyName)
		{
			return typeof(User).GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance).GetValue(this, null);
		}
		#endregion
	}
}
