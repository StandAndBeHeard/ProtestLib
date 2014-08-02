
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Collections.Generic;

namespace ProtestLib
{
    [Serializable]
    public partial class Participants : List<Participant>
    {

        #region Constructors
        public Participants() { }

        public Participants(DataTable dt)
        {
            foreach (DataRow row in dt.Rows) Add(new Participant(row));
        }
        #endregion

        #region Methods
        public static Participants Load(string sql, CommandType commandType = CommandType.Text, SqlParameter[] parameters = null)
        {
            return new Participants(DBHelper.ExecuteQuery(sql, commandType, parameters));
        }

        public static Participants LoadAll()
        {
            return Load("LoadParticipantsAll", CommandType.StoredProcedure, null);
        }

        public static Participants LoadByProtestId(System.Int32 protestId)
        {
            return Load("LoadParticipantsByProtestId", CommandType.StoredProcedure, new SqlParameter[] { new SqlParameter("@ProtestId", protestId) });
        }

        public static Participants LoadByUserId(System.Int32 userId)
        {
            return Load("LoadParticipantsByUserId", CommandType.StoredProcedure, new SqlParameter[] { new SqlParameter("@UserId", userId) });
        }

        public void SaveAll(bool waitForId = true)
        {
            SqlConnection conn = DBHelper.Connection;
            try
            {
                conn.Open();
                DBHelper.SetContextInfo(conn);
                foreach (Participant participant in this)
                {
                    SqlCommand cmd = participant.GetSaveCommand(conn);
                    participant.Id = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex) { throw ex; }
            finally { conn.Close(); }
        }

        public Participant GetById(int id)
        {
            foreach (Participant participant in this) if (participant.Id == id) return participant;
            return null;
        }

        public Participants GetAllByProtestId(System.Int32 protestId)
        {
            Participants result = new Participants();
            foreach (Participant participant in this) if (participant.ProtestId == protestId) result.Add(participant);
            return result;
        }

        public Participants GetAllByUserId(System.Int32 userId)
        {
            Participants result = new Participants();
            foreach (Participant participant in this) if (participant.UserId == userId) result.Add(participant);
            return result;
        }

        public Participants Sort(string column, bool desc)
        {
            var sortedList = desc ? this.OrderByDescending(x => x.GetPropertyValue(column)) : this.OrderBy(x => x.GetPropertyValue(column));
            Participants result = new Participants();
            foreach (var i in sortedList) { result.Add((Participant)i); }
            return result;
        }

        #endregion
    }
}
