using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace ProtestLib
{
    [Serializable]
    public partial class Notifications : System.Collections.Generic.List<Notification>
    {

        #region Constructor
        public Notifications()
        {
        }
        #endregion

        #region Methods
        public static Notifications LoadNotifications(string sql, System.Data.CommandType commandType, System.Data.SqlClient.SqlParameter[] parameters)
        {
            return Notifications.ConvertFromDT(Utils.ExecuteQuery(sql, commandType, parameters));
        }

        public static Notifications ConvertFromDT(DataTable dt)
        {
            Notifications result = new Notifications();
            foreach (DataRow row in dt.Rows)
            {
                result.Add(Notification.GetNotification(row));
            }
            return result;
        }

        public static Notifications LoadAllNotifications()
        {
            return Notifications.LoadNotifications("LoadNotificationsAll", CommandType.StoredProcedure, null);
        }

        public void SaveAll(bool waitForId = true)
        {
            SqlConnection conn = Global.Connection;
            try
            {
                conn.Open();
                Utils.SetContextInfo(conn);
                foreach (ProtestLib.Notification notification in this)
                {
                    SqlCommand cmd = Notification.GetSaveCommand(notification, conn);
                    notification.Id = Convert.ToInt32(cmd.ExecuteScalar());
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

        public Notification GetNotificationById(int notificationId)
        {
            foreach (Notification notification in this)
            {
                if (notification.Id == notificationId) return notification;
            }
            return null;
        }

        public static Notifications LoadNotificationsByUserId(System.Int32 userId)
        {
            return Notifications.LoadNotifications("LoadNotificationsByUserId", CommandType.StoredProcedure, new SqlParameter[] { new SqlParameter("@UserId", userId) });
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

