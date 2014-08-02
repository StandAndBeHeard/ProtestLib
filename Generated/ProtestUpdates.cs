
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Collections.Generic;

namespace ProtestLib
{
    [Serializable]
    public partial class ProtestUpdates : List<ProtestUpdate>
    {

        #region Constructors
        public ProtestUpdates() { }

        public ProtestUpdates(DataTable dt)
        {
            foreach (DataRow row in dt.Rows) Add(new ProtestUpdate(row));
        }
        #endregion

        #region Methods
        public static ProtestUpdates Load(string sql, CommandType commandType = CommandType.Text, SqlParameter[] parameters = null)
        {
            return new ProtestUpdates(DBHelper.ExecuteQuery(sql, commandType, parameters));
        }

        public static ProtestUpdates LoadAll()
        {
            return Load("LoadProtestUpdatesAll", CommandType.StoredProcedure, null);
        }

        public static ProtestUpdates LoadByProtestId(System.Int32 protestId)
        {
            return Load("LoadProtestUpdatesByProtestId", CommandType.StoredProcedure, new SqlParameter[] { new SqlParameter("@ProtestId", protestId) });
        }

        public void SaveAll(bool waitForId = true)
        {
            SqlConnection conn = DBHelper.Connection;
            try
            {
                conn.Open();
                DBHelper.SetContextInfo(conn);
                foreach (ProtestUpdate protestUpdate in this)
                {
                    SqlCommand cmd = protestUpdate.GetSaveCommand(conn);
                    protestUpdate.Id = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex) { throw ex; }
            finally { conn.Close(); }
        }

        public ProtestUpdate GetById(int id)
        {
            foreach (ProtestUpdate protestUpdate in this) if (protestUpdate.Id == id) return protestUpdate;
            return null;
        }

        public ProtestUpdates GetAllByProtestId(System.Int32 protestId)
        {
            ProtestUpdates result = new ProtestUpdates();
            foreach (ProtestUpdate protestUpdate in this) if (protestUpdate.ProtestId == protestId) result.Add(protestUpdate);
            return result;
        }

        public ProtestUpdates Sort(string column, bool desc)
        {
            var sortedList = desc ? this.OrderByDescending(x => x.GetPropertyValue(column)) : this.OrderBy(x => x.GetPropertyValue(column));
            ProtestUpdates result = new ProtestUpdates();
            foreach (var i in sortedList) { result.Add((ProtestUpdate)i); }
            return result;
        }

        #endregion
    }
}
