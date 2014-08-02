
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Collections.Generic;

namespace ProtestLib
{
    [Serializable]
    public partial class PrivateMessages : List<PrivateMessage>
    {

        #region Constructors
        public PrivateMessages() { }

        public PrivateMessages(DataTable dt)
        {
            foreach (DataRow row in dt.Rows) Add(new PrivateMessage(row));
        }
        #endregion

        #region Methods
        public static PrivateMessages Load(string sql, CommandType commandType = CommandType.Text, SqlParameter[] parameters = null)
        {
            return new PrivateMessages(DBHelper.ExecuteQuery(sql, commandType, parameters));
        }

        public static PrivateMessages LoadAll()
        {
            return Load("LoadPrivateMessagesAll", CommandType.StoredProcedure, null);
        }

        public static PrivateMessages LoadByFromId(System.Int32 fromId)
        {
            return Load("LoadPrivateMessagesByFromId", CommandType.StoredProcedure, new SqlParameter[] { new SqlParameter("@FromId", fromId) });
        }

        public static PrivateMessages LoadByToId(System.Int32 toId)
        {
            return Load("LoadPrivateMessagesByToId", CommandType.StoredProcedure, new SqlParameter[] { new SqlParameter("@ToId", toId) });
        }

        public void SaveAll(bool waitForId = true)
        {
            SqlConnection conn = DBHelper.Connection;
            try
            {
                conn.Open();
                DBHelper.SetContextInfo(conn);
                foreach (PrivateMessage privateMessage in this)
                {
                    SqlCommand cmd = privateMessage.GetSaveCommand(conn);
                    privateMessage.Id = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex) { throw ex; }
            finally { conn.Close(); }
        }

        public PrivateMessage GetById(int id)
        {
            foreach (PrivateMessage privateMessage in this) if (privateMessage.Id == id) return privateMessage;
            return null;
        }

        public PrivateMessages GetAllByFromId(System.Int32 fromId)
        {
            PrivateMessages result = new PrivateMessages();
            foreach (PrivateMessage privateMessage in this) if (privateMessage.FromId == fromId) result.Add(privateMessage);
            return result;
        }

        public PrivateMessages GetAllByToId(System.Int32 toId)
        {
            PrivateMessages result = new PrivateMessages();
            foreach (PrivateMessage privateMessage in this) if (privateMessage.ToId == toId) result.Add(privateMessage);
            return result;
        }

        public PrivateMessages Sort(string column, bool desc)
        {
            var sortedList = desc ? this.OrderByDescending(x => x.GetPropertyValue(column)) : this.OrderBy(x => x.GetPropertyValue(column));
            PrivateMessages result = new PrivateMessages();
            foreach (var i in sortedList) { result.Add((PrivateMessage)i); }
            return result;
        }

        #endregion
    }
}
