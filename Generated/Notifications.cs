
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Collections.Generic;

namespace ProtestLib
{
    [Serializable]
    public partial class Notifications : List<Notification>
    {

        #region Constructors
        public Notifications() { }

        public Notifications(DataTable dt)
        {
            foreach (DataRow row in dt.Rows) Add(new Notification(row));
        }
        #endregion

        #region Methods
        public static Notifications Load(string sql, CommandType commandType = CommandType.Text, SqlParameter[] parameters = null)
        {
            return new Notifications(DBHelper.ExecuteQuery(sql, commandType, parameters));
        }

        public static Notifications LoadAll()
        {
            return Load("LoadNotificationsAll", CommandType.StoredProcedure, null);
        }

        public static Notifications LoadByUserId(System.Int32 userId)
        {
            return Load("LoadNotificationsByUserId", CommandType.StoredProcedure, new SqlParameter[] { new SqlParameter("@UserId", userId) });
        }

        public void SaveAll(bool waitForId = true)
        {
            SqlConnection conn = DBHelper.Connection;
            try
            {
                conn.Open();
                DBHelper.SetContextInfo(conn);
                foreach (Notification notification in this)
                {
                    SqlCommand cmd = notification.GetSaveCommand(conn);
                    notification.Id = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex) { throw ex; }
            finally { conn.Close(); }
        }

        public Notification GetById(int id)
        {
            foreach (Notification notification in this) if (notification.Id == id) return notification;
            return null;
        }

        public Notifications GetAllByUserId(System.Int32 userId)
        {
            Notifications result = new Notifications();
            foreach (Notification notification in this) if (notification.UserId == userId) result.Add(notification);
            return result;
        }

        public Notifications Sort(string column, bool desc)
        {
            var sortedList = desc ? this.OrderByDescending(x => x.GetPropertyValue(column)) : this.OrderBy(x => x.GetPropertyValue(column));
            Notifications result = new Notifications();
            foreach (var i in sortedList) { result.Add((Notification)i); }
            return result;
        }

        #endregion
    }
}
