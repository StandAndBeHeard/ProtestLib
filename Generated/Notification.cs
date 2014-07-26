using System;
using System.Data;
using System.Data.SqlClient;

namespace ProtestLib
{
    [Serializable]
    public partial class Notification
    {
        #region Declarations
        System.Int32 _id;
        System.Int32 _userId;
        System.String _title;
        System.String _body;
        System.String _link;
        System.DateTime _creationDate;
        System.DateTime _notificationDate;

        bool _isIdNull = true;
        bool _isUserIdNull = true;
        bool _isTitleNull = true;
        bool _isBodyNull = true;
        bool _isLinkNull = true;
        bool _isCreationDateNull = true;
        bool _isNotificationDateNull = true;

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

        public System.Int32 UserId
        {
            get { return _userId; }
            set
            {
                _userId = value;
                _isUserIdNull = false;
            }
        }

        public System.String Title
        {
            get { return _title; }
            set
            {
                _title = value;
                _isTitleNull = false;
            }
        }

        public System.String Body
        {
            get { return _body; }
            set
            {
                _body = value;
                _isBodyNull = false;
            }
        }

        public System.String Link
        {
            get { return _link; }
            set
            {
                _link = value;
                _isLinkNull = false;
            }
        }

        public System.DateTime CreationDate
        {
            get { return _creationDate; }
            set
            {
                _creationDate = value;
                _isCreationDateNull = false;
            }
        }

        public System.DateTime NotificationDate
        {
            get { return _notificationDate; }
            set
            {
                _notificationDate = value;
                _isNotificationDateNull = false;
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

        public bool IsUserIdNull
        {
            get { return _isUserIdNull; }
            set
            {
                if (!value) throw new Exception("Can not set this property to false");
                _isUserIdNull = value;
                _userId = -1;
            }
        }

        public bool IsTitleNull
        {
            get { return _isTitleNull; }
            set
            {
                if (!value) throw new Exception("Can not set this property to false");
                _isTitleNull = value;
                _title = System.String.Empty;
            }
        }

        public bool IsBodyNull
        {
            get { return _isBodyNull; }
            set
            {
                if (!value) throw new Exception("Can not set this property to false");
                _isBodyNull = value;
                _body = System.String.Empty;
            }
        }

        public bool IsLinkNull
        {
            get { return _isLinkNull; }
            set
            {
                if (!value) throw new Exception("Can not set this property to false");
                _isLinkNull = value;
                _link = System.String.Empty;
            }
        }

        public bool IsCreationDateNull
        {
            get { return _isCreationDateNull; }
            set
            {
                if (!value) throw new Exception("Can not set this property to false");
                _isCreationDateNull = value;
                _creationDate = DateTime.MinValue;
            }
        }

        public bool IsNotificationDateNull
        {
            get { return _isNotificationDateNull; }
            set
            {
                if (!value) throw new Exception("Can not set this property to false");
                _isNotificationDateNull = value;
                _notificationDate = DateTime.MinValue;
            }
        }


        #endregion

        #region Constructor
        public Notification()
        {
        }
        #endregion

        #region Methods
        public static Notification LoadNotification(int notificationId)
        {
            SqlDataAdapter adapter = new SqlDataAdapter("LoadNotification", ProtestLib.Global.Connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@Id", notificationId);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            if (dt.Rows.Count == 0) return null;
            DataRow row = dt.Rows[0];
            return GetNotification(row);
        }

        internal static Notification GetNotification(DataRow row)
        {
            Notification result = new Notification();
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

            if (row.Table.Columns.Contains("UserId"))
            {
                if (Convert.IsDBNull(row["UserId"]))
                {
                    result._isUserIdNull = true;
                }
                else
                {
                    result._userId = Convert.ToInt32(row["UserId"]);
                    result._isUserIdNull = false;
                }
            }

            if (row.Table.Columns.Contains("Title"))
            {
                if (Convert.IsDBNull(row["Title"]))
                {
                    result._isTitleNull = true;
                }
                else
                {
                    result._title = Convert.ToString(row["Title"]);
                    result._isTitleNull = false;
                }
            }

            if (row.Table.Columns.Contains("Body"))
            {
                if (Convert.IsDBNull(row["Body"]))
                {
                    result._isBodyNull = true;
                }
                else
                {
                    result._body = Convert.ToString(row["Body"]);
                    result._isBodyNull = false;
                }
            }

            if (row.Table.Columns.Contains("Link"))
            {
                if (Convert.IsDBNull(row["Link"]))
                {
                    result._isLinkNull = true;
                }
                else
                {
                    result._link = Convert.ToString(row["Link"]);
                    result._isLinkNull = false;
                }
            }

            if (row.Table.Columns.Contains("CreationDate"))
            {
                if (Convert.IsDBNull(row["CreationDate"]))
                {
                    result._isCreationDateNull = true;
                }
                else
                {
                    result._creationDate = Convert.ToDateTime(row["CreationDate"]);
                    result._isCreationDateNull = false;
                }
            }

            if (row.Table.Columns.Contains("NotificationDate"))
            {
                if (Convert.IsDBNull(row["NotificationDate"]))
                {
                    result._isNotificationDateNull = true;
                }
                else
                {
                    result._notificationDate = Convert.ToDateTime(row["NotificationDate"]);
                    result._isNotificationDateNull = false;
                }
            }

            return result;
        }

        public static SqlCommand GetSaveCommand(Notification notification, SqlConnection conn)
        {
            SqlCommand cmd = new SqlCommand("SaveNotification", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            if (notification._isIdNull)
            {
                cmd.Parameters.AddWithValue("@Id", System.DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Id", notification._id);
            }

            if (notification._isUserIdNull)
            {
                cmd.Parameters.AddWithValue("@UserId", System.DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@UserId", notification._userId);
            }

            if (notification._isTitleNull)
            {
                cmd.Parameters.AddWithValue("@Title", System.DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Title", notification._title);
            }

            if (notification._isBodyNull)
            {
                cmd.Parameters.AddWithValue("@Body", System.DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Body", notification._body);
            }

            if (notification._isLinkNull)
            {
                cmd.Parameters.AddWithValue("@Link", System.DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Link", notification._link);
            }

            if (notification._isCreationDateNull)
            {
                cmd.Parameters.AddWithValue("@CreationDate", System.DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@CreationDate", notification._creationDate);
            }

            if (notification._isNotificationDateNull)
            {
                cmd.Parameters.AddWithValue("@NotificationDate", System.DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@NotificationDate", notification._notificationDate);
            }

            return cmd;
        }

        public static int SaveNotification(Notification notification)
        {
            int result = 0;
            SqlCommand cmd = GetSaveCommand(notification, ProtestLib.Global.Connection);
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
            notification.Id = result;
            return result;
        }
        public int Save()
        {
            return Notification.SaveNotification(this);
        }

        public static void DeleteNotification(int notificationId)
        {
            SqlCommand cmd = new SqlCommand("DeleteNotification", ProtestLib.Global.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", notificationId);
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
            return Utils.GetPropertyValue<Notification>(this, propertyName);
        }

        #endregion

    }
}




