using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace ProtestLib
{
    [Serializable]
    public partial class PrivateMessages : System.Collections.Generic.List<PrivateMessage>
    {

        #region Constructor
        public PrivateMessages()
        {
        }
        #endregion

        #region Methods
        public static PrivateMessages LoadPrivateMessages(string sql, System.Data.CommandType commandType, System.Data.SqlClient.SqlParameter[] parameters)
        {
            return PrivateMessages.ConvertFromDT(Utils.ExecuteQuery(sql, commandType, parameters));
        }

        public static PrivateMessages ConvertFromDT(DataTable dt)
        {
            PrivateMessages result = new PrivateMessages();
            foreach (DataRow row in dt.Rows)
            {
                result.Add(PrivateMessage.GetPrivateMessage(row));
            }
            return result;
        }

        public static PrivateMessages LoadAllPrivateMessages()
        {
            return PrivateMessages.LoadPrivateMessages("LoadPrivateMessagesAll", CommandType.StoredProcedure, null);
        }

        public void SaveAll(bool waitForId = true)
        {
            SqlConnection conn = Global.Connection;
            try
            {
                conn.Open();
                Utils.SetContextInfo(conn);
                foreach (ProtestLib.PrivateMessage privateMessage in this)
                {
                    SqlCommand cmd = PrivateMessage.GetSaveCommand(privateMessage, conn);
                    privateMessage.Id = Convert.ToInt32(cmd.ExecuteScalar());
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

        public PrivateMessage GetPrivateMessageById(int privateMessageId)
        {
            foreach (PrivateMessage privateMessage in this)
            {
                if (privateMessage.Id == privateMessageId) return privateMessage;
            }
            return null;
        }

        public static PrivateMessages LoadPrivateMessagesByFromId(System.Int32 fromId)
        {
            return PrivateMessages.LoadPrivateMessages("LoadPrivateMessagesByFromId", CommandType.StoredProcedure, new SqlParameter[] { new SqlParameter("@FromId", fromId) });
        }

        public static PrivateMessages LoadPrivateMessagesByToId(System.Int32 toId)
        {
            return PrivateMessages.LoadPrivateMessages("LoadPrivateMessagesByToId", CommandType.StoredProcedure, new SqlParameter[] { new SqlParameter("@ToId", toId) });
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

