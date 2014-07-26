using System;
using System.Data;
using System.Data.SqlClient;

namespace ProtestLib
{
    [Serializable]
    public partial class PrivateMessage
    {
        #region Declarations
        System.Int32 _id;
        System.Int32 _fromId;
        System.Int32 _toId;
        System.String _title;

        bool _isIdNull = true;
        bool _isFromIdNull = true;
        bool _isToIdNull = true;
        bool _isTitleNull = true;

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

        public System.Int32 FromId
        {
            get { return _fromId; }
            set
            {
                _fromId = value;
                _isFromIdNull = false;
            }
        }

        public System.Int32 ToId
        {
            get { return _toId; }
            set
            {
                _toId = value;
                _isToIdNull = false;
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

        public bool IsFromIdNull
        {
            get { return _isFromIdNull; }
            set
            {
                if (!value) throw new Exception("Can not set this property to false");
                _isFromIdNull = value;
                _fromId = -1;
            }
        }

        public bool IsToIdNull
        {
            get { return _isToIdNull; }
            set
            {
                if (!value) throw new Exception("Can not set this property to false");
                _isToIdNull = value;
                _toId = -1;
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


        #endregion

        #region Constructor
        public PrivateMessage()
        {
        }
        #endregion

        #region Methods
        public static PrivateMessage LoadPrivateMessage(int privateMessageId)
        {
            SqlDataAdapter adapter = new SqlDataAdapter("LoadPrivateMessage", ProtestLib.Global.Connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@Id", privateMessageId);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            if (dt.Rows.Count == 0) return null;
            DataRow row = dt.Rows[0];
            return GetPrivateMessage(row);
        }

        internal static PrivateMessage GetPrivateMessage(DataRow row)
        {
            PrivateMessage result = new PrivateMessage();
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

            if (row.Table.Columns.Contains("FromId"))
            {
                if (Convert.IsDBNull(row["FromId"]))
                {
                    result._isFromIdNull = true;
                }
                else
                {
                    result._fromId = Convert.ToInt32(row["FromId"]);
                    result._isFromIdNull = false;
                }
            }

            if (row.Table.Columns.Contains("ToId"))
            {
                if (Convert.IsDBNull(row["ToId"]))
                {
                    result._isToIdNull = true;
                }
                else
                {
                    result._toId = Convert.ToInt32(row["ToId"]);
                    result._isToIdNull = false;
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

            return result;
        }

        public static SqlCommand GetSaveCommand(PrivateMessage privateMessage, SqlConnection conn)
        {
            SqlCommand cmd = new SqlCommand("SavePrivateMessage", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            if (privateMessage._isIdNull)
            {
                cmd.Parameters.AddWithValue("@Id", System.DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Id", privateMessage._id);
            }

            if (privateMessage._isFromIdNull)
            {
                cmd.Parameters.AddWithValue("@FromId", System.DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@FromId", privateMessage._fromId);
            }

            if (privateMessage._isToIdNull)
            {
                cmd.Parameters.AddWithValue("@ToId", System.DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@ToId", privateMessage._toId);
            }

            if (privateMessage._isTitleNull)
            {
                cmd.Parameters.AddWithValue("@Title", System.DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Title", privateMessage._title);
            }

            return cmd;
        }

        public static int SavePrivateMessage(PrivateMessage privateMessage)
        {
            int result = 0;
            SqlCommand cmd = GetSaveCommand(privateMessage, ProtestLib.Global.Connection);
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
            privateMessage.Id = result;
            return result;
        }
        public int Save()
        {
            return PrivateMessage.SavePrivateMessage(this);
        }

        public static void DeletePrivateMessage(int privateMessageId)
        {
            SqlCommand cmd = new SqlCommand("DeletePrivateMessage", ProtestLib.Global.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", privateMessageId);
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
            return Utils.GetPropertyValue<PrivateMessage>(this, propertyName);
        }

        #endregion

    }
}




