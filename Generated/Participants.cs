using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace ProtestLib
{
    [Serializable]
    public partial class Participants : System.Collections.Generic.List<Participant>
    {

        #region Constructor
        public Participants()
        {
        }
        #endregion

        #region Methods
        public static Participants LoadParticipants(string sql, System.Data.CommandType commandType, System.Data.SqlClient.SqlParameter[] parameters)
        {
            return Participants.ConvertFromDT(Utils.ExecuteQuery(sql, commandType, parameters));
        }

        public static Participants ConvertFromDT(DataTable dt)
        {
            Participants result = new Participants();
            foreach (DataRow row in dt.Rows)
            {
                result.Add(Participant.GetParticipant(row));
            }
            return result;
        }

        public static Participants LoadAllParticipants()
        {
            return Participants.LoadParticipants("LoadParticipantsAll", CommandType.StoredProcedure, null);
        }

        public void SaveAll(bool waitForId = true)
        {
            SqlConnection conn = Global.Connection;
            try
            {
                conn.Open();
                Utils.SetContextInfo(conn);
                foreach (ProtestLib.Participant participant in this)
                {
                    SqlCommand cmd = Participant.GetSaveCommand(participant, conn);
                    participant.Id = Convert.ToInt32(cmd.ExecuteScalar());
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

        public Participant GetParticipantById(int participantId)
        {
            foreach (Participant participant in this)
            {
                if (participant.Id == participantId) return participant;
            }
            return null;
        }

        public static Participants LoadParticipantsByProtestId(System.Int32 protestId)
        {
            return Participants.LoadParticipants("LoadParticipantsByProtestId", CommandType.StoredProcedure, new SqlParameter[] { new SqlParameter("@ProtestId", protestId) });
        }

        public static Participants LoadParticipantsByUserId(System.Int32 userId)
        {
            return Participants.LoadParticipants("LoadParticipantsByUserId", CommandType.StoredProcedure, new SqlParameter[] { new SqlParameter("@UserId", userId) });
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

