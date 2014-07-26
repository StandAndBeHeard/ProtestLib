using System;
using System.Data;
using System.Data.SqlClient;

namespace ProtestLib
{
    [Serializable]
    public partial class Participant
    {
        #region Declarations
        System.Int32 _id;
        System.Int32 _protestId;
        System.Int32 _userId;
        System.DateTime _dateJoined;

        bool _isIdNull = true;
        bool _isProtestIdNull = true;
        bool _isUserIdNull = true;
        bool _isDateJoinedNull = true;

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

        public System.Int32 UserId
        {
            get { return _userId; }
            set
            {
                _userId = value;
                _isUserIdNull = false;
            }
        }

        public System.DateTime DateJoined
        {
            get { return _dateJoined; }
            set
            {
                _dateJoined = value;
                _isDateJoinedNull = false;
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

        public bool IsDateJoinedNull
        {
            get { return _isDateJoinedNull; }
            set
            {
                if (!value) throw new Exception("Can not set this property to false");
                _isDateJoinedNull = value;
                _dateJoined = DateTime.MinValue;
            }
        }


        #endregion

        #region Constructor
        public Participant()
        {
        }
        #endregion

        #region Methods
        public static Participant LoadParticipant(int participantId)
        {
            SqlDataAdapter adapter = new SqlDataAdapter("LoadParticipant", ProtestLib.Global.Connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@Id", participantId);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            if (dt.Rows.Count == 0) return null;
            DataRow row = dt.Rows[0];
            return GetParticipant(row);
        }

        internal static Participant GetParticipant(DataRow row)
        {
            Participant result = new Participant();
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

            if (row.Table.Columns.Contains("DateJoined"))
            {
                if (Convert.IsDBNull(row["DateJoined"]))
                {
                    result._isDateJoinedNull = true;
                }
                else
                {
                    result._dateJoined = Convert.ToDateTime(row["DateJoined"]);
                    result._isDateJoinedNull = false;
                }
            }

            return result;
        }

        public static SqlCommand GetSaveCommand(Participant participant, SqlConnection conn)
        {
            SqlCommand cmd = new SqlCommand("SaveParticipant", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            if (participant._isIdNull)
            {
                cmd.Parameters.AddWithValue("@Id", System.DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Id", participant._id);
            }

            if (participant._isProtestIdNull)
            {
                cmd.Parameters.AddWithValue("@ProtestId", System.DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@ProtestId", participant._protestId);
            }

            if (participant._isUserIdNull)
            {
                cmd.Parameters.AddWithValue("@UserId", System.DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@UserId", participant._userId);
            }

            if (participant._isDateJoinedNull)
            {
                cmd.Parameters.AddWithValue("@DateJoined", System.DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@DateJoined", participant._dateJoined);
            }

            return cmd;
        }

        public static int SaveParticipant(Participant participant)
        {
            int result = 0;
            SqlCommand cmd = GetSaveCommand(participant, ProtestLib.Global.Connection);
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
            participant.Id = result;
            return result;
        }
        public int Save()
        {
            return Participant.SaveParticipant(this);
        }

        public static void DeleteParticipant(int participantId)
        {
            SqlCommand cmd = new SqlCommand("DeleteParticipant", ProtestLib.Global.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", participantId);
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
            return Utils.GetPropertyValue<Participant>(this, propertyName);
        }

        #endregion

    }
}




