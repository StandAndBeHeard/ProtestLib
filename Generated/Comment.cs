using System;
using System.Data;
using System.Data.SqlClient;

namespace ProtestLib
{
    [Serializable]
    public partial class Comment
    {
        #region Declarations
        System.Int32 _id;
        System.String _contentType;
        System.Int32 _contentId;
        System.Int32 _parentId;
        System.Int32 _userId;
        System.String _body;
        System.DateTime _postedDate;
        System.Boolean _active;
        System.String _ipAddress;

        bool _isIdNull = true;
        bool _isContentTypeNull = true;
        bool _isContentIdNull = true;
        bool _isParentIdNull = true;
        bool _isUserIdNull = true;
        bool _isBodyNull = true;
        bool _isPostedDateNull = true;
        bool _isActiveNull = true;
        bool _isIpAddressNull = true;

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

        public System.String ContentType
        {
            get { return _contentType; }
            set
            {
                _contentType = value;
                _isContentTypeNull = false;
            }
        }

        public System.Int32 ContentId
        {
            get { return _contentId; }
            set
            {
                _contentId = value;
                _isContentIdNull = false;
            }
        }

        public System.Int32 ParentId
        {
            get { return _parentId; }
            set
            {
                _parentId = value;
                _isParentIdNull = false;
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

        public System.String Body
        {
            get { return _body; }
            set
            {
                _body = value;
                _isBodyNull = false;
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

        public System.Boolean Active
        {
            get { return _active; }
            set
            {
                _active = value;
                _isActiveNull = false;
            }
        }

        public System.String IpAddress
        {
            get { return _ipAddress; }
            set
            {
                _ipAddress = value;
                _isIpAddressNull = false;
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

        public bool IsContentTypeNull
        {
            get { return _isContentTypeNull; }
            set
            {
                if (!value) throw new Exception("Can not set this property to false");
                _isContentTypeNull = value;
                _contentType = System.String.Empty;
            }
        }

        public bool IsContentIdNull
        {
            get { return _isContentIdNull; }
            set
            {
                if (!value) throw new Exception("Can not set this property to false");
                _isContentIdNull = value;
                _contentId = -1;
            }
        }

        public bool IsParentIdNull
        {
            get { return _isParentIdNull; }
            set
            {
                if (!value) throw new Exception("Can not set this property to false");
                _isParentIdNull = value;
                _parentId = -1;
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

        public bool IsActiveNull
        {
            get { return _isActiveNull; }
            set
            {
                if (!value) throw new Exception("Can not set this property to false");
                _isActiveNull = value;
                _active = false;
            }
        }

        public bool IsIpAddressNull
        {
            get { return _isIpAddressNull; }
            set
            {
                if (!value) throw new Exception("Can not set this property to false");
                _isIpAddressNull = value;
                _ipAddress = System.String.Empty;
            }
        }


        #endregion

        #region Constructor
        public Comment()
        {
        }
        #endregion

        #region Methods
        public static Comment LoadComment(int commentId)
        {
            SqlDataAdapter adapter = new SqlDataAdapter("LoadComment", ProtestLib.Global.Connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@Id", commentId);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            if (dt.Rows.Count == 0) return null;
            DataRow row = dt.Rows[0];
            return GetComment(row);
        }

        internal static Comment GetComment(DataRow row)
        {
            Comment result = new Comment();
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

            if (row.Table.Columns.Contains("ContentType"))
            {
                if (Convert.IsDBNull(row["ContentType"]))
                {
                    result._isContentTypeNull = true;
                }
                else
                {
                    result._contentType = Convert.ToString(row["ContentType"]);
                    result._isContentTypeNull = false;
                }
            }

            if (row.Table.Columns.Contains("ContentId"))
            {
                if (Convert.IsDBNull(row["ContentId"]))
                {
                    result._isContentIdNull = true;
                }
                else
                {
                    result._contentId = Convert.ToInt32(row["ContentId"]);
                    result._isContentIdNull = false;
                }
            }

            if (row.Table.Columns.Contains("ParentId"))
            {
                if (Convert.IsDBNull(row["ParentId"]))
                {
                    result._isParentIdNull = true;
                }
                else
                {
                    result._parentId = Convert.ToInt32(row["ParentId"]);
                    result._isParentIdNull = false;
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

            if (row.Table.Columns.Contains("Active"))
            {
                if (Convert.IsDBNull(row["Active"]))
                {
                    result._isActiveNull = true;
                }
                else
                {
                    result._active = Convert.ToBoolean(row["Active"]);
                    result._isActiveNull = false;
                }
            }

            if (row.Table.Columns.Contains("IpAddress"))
            {
                if (Convert.IsDBNull(row["IpAddress"]))
                {
                    result._isIpAddressNull = true;
                }
                else
                {
                    result._ipAddress = Convert.ToString(row["IpAddress"]);
                    result._isIpAddressNull = false;
                }
            }

            return result;
        }

        public static SqlCommand GetSaveCommand(Comment comment, SqlConnection conn)
        {
            SqlCommand cmd = new SqlCommand("SaveComment", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            if (comment._isIdNull)
            {
                cmd.Parameters.AddWithValue("@Id", System.DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Id", comment._id);
            }

            if (comment._isContentTypeNull)
            {
                cmd.Parameters.AddWithValue("@ContentType", System.DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@ContentType", comment._contentType);
            }

            if (comment._isContentIdNull)
            {
                cmd.Parameters.AddWithValue("@ContentId", System.DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@ContentId", comment._contentId);
            }

            if (comment._isParentIdNull)
            {
                cmd.Parameters.AddWithValue("@ParentId", System.DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@ParentId", comment._parentId);
            }

            if (comment._isUserIdNull)
            {
                cmd.Parameters.AddWithValue("@UserId", System.DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@UserId", comment._userId);
            }

            if (comment._isBodyNull)
            {
                cmd.Parameters.AddWithValue("@Body", System.DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Body", comment._body);
            }

            if (comment._isPostedDateNull)
            {
                cmd.Parameters.AddWithValue("@PostedDate", System.DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@PostedDate", comment._postedDate);
            }

            if (comment._isActiveNull)
            {
                cmd.Parameters.AddWithValue("@Active", System.DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Active", comment._active);
            }

            if (comment._isIpAddressNull)
            {
                cmd.Parameters.AddWithValue("@IpAddress", System.DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@IpAddress", comment._ipAddress);
            }

            return cmd;
        }

        public static int SaveComment(Comment comment)
        {
            int result = 0;
            SqlCommand cmd = GetSaveCommand(comment, ProtestLib.Global.Connection);
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
            comment.Id = result;
            return result;
        }
        public int Save()
        {
            return Comment.SaveComment(this);
        }

        public static void DeleteComment(int commentId)
        {
            SqlCommand cmd = new SqlCommand("DeleteComment", ProtestLib.Global.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", commentId);
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
            return Utils.GetPropertyValue<Comment>(this, propertyName);
        }

        #endregion

    }
}




