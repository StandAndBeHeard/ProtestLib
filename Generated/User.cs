using System;
using System.Data;
using System.Data.SqlClient;

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
            set
            {
                _id = value;
                _isIdNull = false;
            }
        }

        public System.String UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                _isUserNameNull = false;
            }
        }

        public System.String Email
        {
            get { return _email; }
            set
            {
                _email = value;
                _isEmailNull = false;
            }
        }

        public System.String PasswordHash
        {
            get { return _passwordHash; }
            set
            {
                _passwordHash = value;
                _isPasswordHashNull = false;
            }
        }

        public System.DateTime RegistrationDate
        {
            get { return _registrationDate; }
            set
            {
                _registrationDate = value;
                _isRegistrationDateNull = false;
            }
        }

        public System.DateTime LastLoginDate
        {
            get { return _lastLoginDate; }
            set
            {
                _lastLoginDate = value;
                _isLastLoginDateNull = false;
            }
        }

        public System.Boolean ContactDemonstrations
        {
            get { return _contactDemonstrations; }
            set
            {
                _contactDemonstrations = value;
                _isContactDemonstrationsNull = false;
            }
        }

        public System.Boolean ContactOther
        {
            get { return _contactOther; }
            set
            {
                _contactOther = value;
                _isContactOtherNull = false;
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

        #region Constructor
        public User()
        {
        }
        #endregion

        #region Methods
        public static User LoadUser(int userId)
        {
            SqlDataAdapter adapter = new SqlDataAdapter("LoadUser", ProtestLib.Global.Connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@Id", userId);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            if (dt.Rows.Count == 0) return null;
            DataRow row = dt.Rows[0];
            return GetUser(row);
        }

        internal static User GetUser(DataRow row)
        {
            User result = new User();
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

            if (row.Table.Columns.Contains("UserName"))
            {
                if (Convert.IsDBNull(row["UserName"]))
                {
                    result._isUserNameNull = true;
                }
                else
                {
                    result._userName = Convert.ToString(row["UserName"]);
                    result._isUserNameNull = false;
                }
            }

            if (row.Table.Columns.Contains("Email"))
            {
                if (Convert.IsDBNull(row["Email"]))
                {
                    result._isEmailNull = true;
                }
                else
                {
                    result._email = Convert.ToString(row["Email"]);
                    result._isEmailNull = false;
                }
            }

            if (row.Table.Columns.Contains("PasswordHash"))
            {
                if (Convert.IsDBNull(row["PasswordHash"]))
                {
                    result._isPasswordHashNull = true;
                }
                else
                {
                    result._passwordHash = Convert.ToString(row["PasswordHash"]);
                    result._isPasswordHashNull = false;
                }
            }

            if (row.Table.Columns.Contains("RegistrationDate"))
            {
                if (Convert.IsDBNull(row["RegistrationDate"]))
                {
                    result._isRegistrationDateNull = true;
                }
                else
                {
                    result._registrationDate = Convert.ToDateTime(row["RegistrationDate"]);
                    result._isRegistrationDateNull = false;
                }
            }

            if (row.Table.Columns.Contains("LastLoginDate"))
            {
                if (Convert.IsDBNull(row["LastLoginDate"]))
                {
                    result._isLastLoginDateNull = true;
                }
                else
                {
                    result._lastLoginDate = Convert.ToDateTime(row["LastLoginDate"]);
                    result._isLastLoginDateNull = false;
                }
            }

            if (row.Table.Columns.Contains("ContactDemonstrations"))
            {
                if (Convert.IsDBNull(row["ContactDemonstrations"]))
                {
                    result._isContactDemonstrationsNull = true;
                }
                else
                {
                    result._contactDemonstrations = Convert.ToBoolean(row["ContactDemonstrations"]);
                    result._isContactDemonstrationsNull = false;
                }
            }

            if (row.Table.Columns.Contains("ContactOther"))
            {
                if (Convert.IsDBNull(row["ContactOther"]))
                {
                    result._isContactOtherNull = true;
                }
                else
                {
                    result._contactOther = Convert.ToBoolean(row["ContactOther"]);
                    result._isContactOtherNull = false;
                }
            }

            return result;
        }

        public static SqlCommand GetSaveCommand(User user, SqlConnection conn)
        {
            SqlCommand cmd = new SqlCommand("SaveUser", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            if (user._isIdNull)
            {
                cmd.Parameters.AddWithValue("@Id", System.DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Id", user._id);
            }

            if (user._isUserNameNull)
            {
                cmd.Parameters.AddWithValue("@UserName", System.DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@UserName", user._userName);
            }

            if (user._isEmailNull)
            {
                cmd.Parameters.AddWithValue("@Email", System.DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Email", user._email);
            }

            if (user._isPasswordHashNull)
            {
                cmd.Parameters.AddWithValue("@PasswordHash", System.DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@PasswordHash", user._passwordHash);
            }

            if (user._isRegistrationDateNull)
            {
                cmd.Parameters.AddWithValue("@RegistrationDate", System.DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@RegistrationDate", user._registrationDate);
            }

            if (user._isLastLoginDateNull)
            {
                cmd.Parameters.AddWithValue("@LastLoginDate", System.DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@LastLoginDate", user._lastLoginDate);
            }

            if (user._isContactDemonstrationsNull)
            {
                cmd.Parameters.AddWithValue("@ContactDemonstrations", System.DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@ContactDemonstrations", user._contactDemonstrations);
            }

            if (user._isContactOtherNull)
            {
                cmd.Parameters.AddWithValue("@ContactOther", System.DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@ContactOther", user._contactOther);
            }

            return cmd;
        }

        public static int SaveUser(User user)
        {
            int result = 0;
            SqlCommand cmd = GetSaveCommand(user, ProtestLib.Global.Connection);
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
            user.Id = result;
            return result;
        }
        public int Save()
        {
            return User.SaveUser(this);
        }

        public static void DeleteUser(int userId)
        {
            SqlCommand cmd = new SqlCommand("DeleteUser", ProtestLib.Global.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", userId);
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
            return Utils.GetPropertyValue<User>(this, propertyName);
        }

        #endregion

    }
}




