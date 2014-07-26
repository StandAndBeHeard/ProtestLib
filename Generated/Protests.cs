using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace ProtestLib
{
    [Serializable]
    public partial class Protests : System.Collections.Generic.List<Protest>
    {

        #region Constructor
        public Protests()
        {
        }
        #endregion

        #region Methods
        public static Protests LoadProtests(string sql, System.Data.CommandType commandType, System.Data.SqlClient.SqlParameter[] parameters)
        {
            return Protests.ConvertFromDT(Utils.ExecuteQuery(sql, commandType, parameters));
        }

        public static Protests ConvertFromDT(DataTable dt)
        {
            Protests result = new Protests();
            foreach (DataRow row in dt.Rows)
            {
                result.Add(Protest.GetProtest(row));
            }
            return result;
        }

        public static Protests LoadAllProtests()
        {
            return Protests.LoadProtests("LoadProtestsAll", CommandType.StoredProcedure, null);
        }

        public void SaveAll(bool waitForId = true)
        {
            SqlConnection conn = Global.Connection;
            try
            {
                conn.Open();
                Utils.SetContextInfo(conn);
                foreach (ProtestLib.Protest protest in this)
                {
                    SqlCommand cmd = Protest.GetSaveCommand(protest, conn);
                    protest.Id = Convert.ToInt32(cmd.ExecuteScalar());
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

        public Protest GetProtestById(int protestId)
        {
            foreach (Protest protest in this)
            {
                if (protest.Id == protestId) return protest;
            }
            return null;
        }

        public static Protests LoadProtestsByOrganizerId(System.Int32 organizerId)
        {
            return Protests.LoadProtests("LoadProtestsByOrganizerId", CommandType.StoredProcedure, new SqlParameter[] { new SqlParameter("@OrganizerId", organizerId) });
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

