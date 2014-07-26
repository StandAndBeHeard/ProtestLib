using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace ProtestLib
{
    [Serializable]
    public partial class ProtestUpdates : System.Collections.Generic.List<ProtestUpdate>
    {

        #region Constructor
        public ProtestUpdates()
        {
        }
        #endregion

        #region Methods
        public static ProtestUpdates LoadProtestUpdates(string sql, System.Data.CommandType commandType, System.Data.SqlClient.SqlParameter[] parameters)
        {
            return ProtestUpdates.ConvertFromDT(Utils.ExecuteQuery(sql, commandType, parameters));
        }

        public static ProtestUpdates ConvertFromDT(DataTable dt)
        {
            ProtestUpdates result = new ProtestUpdates();
            foreach (DataRow row in dt.Rows)
            {
                result.Add(ProtestUpdate.GetProtestUpdate(row));
            }
            return result;
        }

        public static ProtestUpdates LoadAllProtestUpdates()
        {
            return ProtestUpdates.LoadProtestUpdates("LoadProtestUpdatesAll", CommandType.StoredProcedure, null);
        }

        public void SaveAll(bool waitForId = true)
        {
            SqlConnection conn = Global.Connection;
            try
            {
                conn.Open();
                Utils.SetContextInfo(conn);
                foreach (ProtestLib.ProtestUpdate protestUpdate in this)
                {
                    SqlCommand cmd = ProtestUpdate.GetSaveCommand(protestUpdate, conn);
                    protestUpdate.Id = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public ProtestUpdate GetProtestUpdateById(int protestUpdateId)
        {
            foreach (ProtestUpdate protestUpdate in this)
            {
                if (protestUpdate.Id == protestUpdateId) return protestUpdate;
            }
            return null;
        }

        public static ProtestUpdates LoadProtestUpdatesByProtestId(System.Int32 protestId)
        {
            return ProtestUpdates.LoadProtestUpdates("LoadProtestUpdatesByProtestId", CommandType.StoredProcedure, new SqlParameter[] { new SqlParameter("@ProtestId", protestId) });
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

