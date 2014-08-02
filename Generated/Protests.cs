
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Collections.Generic;

namespace ProtestLib
{
    [Serializable]
    public partial class Protests : List<Protest>
    {

        #region Constructors
        public Protests() { }

        public Protests(DataTable dt)
        {
            foreach (DataRow row in dt.Rows) Add(new Protest(row));
        }
        #endregion

        #region Methods
        public static Protests Load(string sql, CommandType commandType = CommandType.Text, SqlParameter[] parameters = null)
        {
            return new Protests(DBHelper.ExecuteQuery(sql, commandType, parameters));
        }

        public static Protests LoadAll()
        {
            return Load("LoadProtestsAll", CommandType.StoredProcedure, null);
        }

        public static Protests LoadByOrganizerId(System.Int32 organizerId)
        {
            return Load("LoadProtestsByOrganizerId", CommandType.StoredProcedure, new SqlParameter[] { new SqlParameter("@OrganizerId", organizerId) });
        }

        public void SaveAll(bool waitForId = true)
        {
            SqlConnection conn = DBHelper.Connection;
            try
            {
                conn.Open();
                DBHelper.SetContextInfo(conn);
                foreach (Protest protest in this)
                {
                    SqlCommand cmd = protest.GetSaveCommand(conn);
                    protest.Id = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex) { throw ex; }
            finally { conn.Close(); }
        }

        public Protest GetById(int id)
        {
            foreach (Protest protest in this) if (protest.Id == id) return protest;
            return null;
        }

        public Protests GetAllByOrganizerId(System.Int32 organizerId)
        {
            Protests result = new Protests();
            foreach (Protest protest in this) if (protest.OrganizerId == organizerId) result.Add(protest);
            return result;
        }

        public Protests Sort(string column, bool desc)
        {
            var sortedList = desc ? this.OrderByDescending(x => x.GetPropertyValue(column)) : this.OrderBy(x => x.GetPropertyValue(column));
            Protests result = new Protests();
            foreach (var i in sortedList) { result.Add((Protest)i); }
            return result;
        }

        #endregion
    }
}
