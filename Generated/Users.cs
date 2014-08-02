
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Collections.Generic;

namespace ProtestLib
{
    [Serializable]
    public partial class Users : List<User>
    {

        #region Constructors
        public Users() { }

        public Users(DataTable dt)
        {
            foreach (DataRow row in dt.Rows) Add(new User(row));
        }
        #endregion

        #region Methods
        public static Users Load(string sql, CommandType commandType = CommandType.Text, SqlParameter[] parameters = null)
        {
            return new Users(DBHelper.ExecuteQuery(sql, commandType, parameters));
        }

        public static Users LoadAll()
        {
            return Load("LoadUsersAll", CommandType.StoredProcedure, null);
        }

        public void SaveAll(bool waitForId = true)
        {
            SqlConnection conn = DBHelper.Connection;
            try
            {
                conn.Open();
                DBHelper.SetContextInfo(conn);
                foreach (User user in this)
                {
                    SqlCommand cmd = user.GetSaveCommand(conn);
                    user.Id = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex) { throw ex; }
            finally { conn.Close(); }
        }

        public User GetById(int id)
        {
            foreach (User user in this) if (user.Id == id) return user;
            return null;
        }

        public Users Sort(string column, bool desc)
        {
            var sortedList = desc ? this.OrderByDescending(x => x.GetPropertyValue(column)) : this.OrderBy(x => x.GetPropertyValue(column));
            Users result = new Users();
            foreach (var i in sortedList) { result.Add((User)i); }
            return result;
        }

        #endregion
    }
}
