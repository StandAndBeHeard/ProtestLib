using System;
using System.Data;
using System.Data.SqlClient;

namespace ProtestLib
{
    [Serializable]
    public partial class ProtestUpdate
    {
        #region Declarations
        System.Int32 _id;
        System.Int32 _protestId;
        System.DateTime _postedDate;
        System.String _body;

        bool _isIdNull = true;
        bool _isProtestIdNull = true;
        bool _isPostedDateNull = true;
        bool _isBodyNull = true;

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

        public System.Int32 ProtestId
        {
            get { return _protestId; }
            set
            {
                _protestId = value;
                _isProtestIdNull = false;
            }
        }

        public System.DateTime PostedDate
        {
            get { return _postedDate; }
            set
            {
                _postedDate = value;
                _isPostedDateNull = false;
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

        public bool IsProtestIdNull
        {
            get { return _isProtestIdNull; }
            set
            {
                if (!value) throw new Exception("Can not set this property to false");
                _isProtestIdNull = value;
                _protestId = -1;
            }
        }

        public bool IsPostedDateNull
        {
            get { return _isPostedDateNull; }
            set
            {
                if (!value) throw new Exception("Can not set this property to false");
                _isPostedDateNull = value;
                _postedDate = DateTime.MinValue;
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


        #endregion

        #region Constructor
        public ProtestUpdate()
        {
        }
        #endregion

        #region Methods
        public static ProtestUpdate LoadProtestUpdate(int protestUpdateId)
        {
            SqlDataAdapter adapter = new SqlDataAdapter("LoadProtestUpdate", ProtestLib.Global.Connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@Id", protestUpdateId);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            if (dt.Rows.Count == 0) return null;
            DataRow row = dt.Rows[0];
            return GetProtestUpdate(row);
        }

        internal static ProtestUpdate GetProtestUpdate(DataRow row)
        {
            ProtestUpdate result = new ProtestUpdate();
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

            if (row.Table.Columns.Contains("ProtestId"))
            {
                if (Convert.IsDBNull(row["ProtestId"]))
                {
                    result._isProtestIdNull = true;
                }
                else
                {
                    result._protestId = Convert.ToInt32(row["ProtestId"]);
                    result._isProtestIdNull = false;
                }
            }

            if (row.Table.Columns.Contains("PostedDate"))
            {
                if (Convert.IsDBNull(row["PostedDate"]))
                {
                    result._isPostedDateNull = true;
                }
                else
                {
                    result._postedDate = Convert.ToDateTime(row["PostedDate"]);
                    result._isPostedDateNull = false;
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

            return result;
        }

        public static SqlCommand GetSaveCommand(ProtestUpdate protestUpdate, SqlConnection conn)
        {
            SqlCommand cmd = new SqlCommand("SaveProtestUpdate", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            if (protestUpdate._isIdNull)
            {
                cmd.Parameters.AddWithValue("@Id", System.DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Id", protestUpdate._id);
            }

            if (protestUpdate._isProtestIdNull)
            {
                cmd.Parameters.AddWithValue("@ProtestId", System.DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@ProtestId", protestUpdate._protestId);
            }

            if (protestUpdate._isPostedDateNull)
            {
                cmd.Parameters.AddWithValue("@PostedDate", System.DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@PostedDate", protestUpdate._postedDate);
            }

            if (protestUpdate._isBodyNull)
            {
                cmd.Parameters.AddWithValue("@Body", System.DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Body", protestUpdate._body);
            }

            return cmd;
        }

        public static int SaveProtestUpdate(ProtestUpdate protestUpdate)
        {
            int result = 0;
            SqlCommand cmd = GetSaveCommand(protestUpdate, ProtestLib.Global.Connection);
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
            protestUpdate.Id = result;
            return result;
        }
        public int Save()
        {
            return ProtestUpdate.SaveProtestUpdate(this);
        }

        public static void DeleteProtestUpdate(int protestUpdateId)
        {
            SqlCommand cmd = new SqlCommand("DeleteProtestUpdate", ProtestLib.Global.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", protestUpdateId);
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
            return Utils.GetPropertyValue<ProtestUpdate>(this, propertyName);
        }

        #endregion

    }
}




