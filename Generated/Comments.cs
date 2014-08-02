
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Collections.Generic;

namespace ProtestLib
{
    [Serializable]
    public partial class Comments : List<Comment>
    {

        #region Constructors
        public Comments() { }

        public Comments(DataTable dt)
        {
            foreach (DataRow row in dt.Rows) Add(new Comment(row));
        }
        #endregion

        #region Methods
        public static Comments Load(string sql, CommandType commandType = CommandType.Text, SqlParameter[] parameters = null)
        {
            return new Comments(DBHelper.ExecuteQuery(sql, commandType, parameters));
        }

        public static Comments LoadAll()
        {
            return Load("LoadCommentsAll", CommandType.StoredProcedure, null);
        }

        public static Comments LoadByUserId(System.Int32 userId)
        {
            return Load("LoadCommentsByUserId", CommandType.StoredProcedure, new SqlParameter[] { new SqlParameter("@UserId", userId) });
        }

        public void SaveAll(bool waitForId = true)
        {
            SqlConnection conn = DBHelper.Connection;
            try
            {
                conn.Open();
                DBHelper.SetContextInfo(conn);
                foreach (Comment comment in this)
                {
                    SqlCommand cmd = comment.GetSaveCommand(conn);
                    comment.Id = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex) { throw ex; }
            finally { conn.Close(); }
        }

        public Comment GetById(int id)
        {
            foreach (Comment comment in this) if (comment.Id == id) return comment;
            return null;
        }

        public Comments GetAllByUserId(System.Int32 userId)
        {
            Comments result = new Comments();
            foreach (Comment comment in this) if (comment.UserId == userId) result.Add(comment);
            return result;
        }

        public Comments Sort(string column, bool desc)
        {
            var sortedList = desc ? this.OrderByDescending(x => x.GetPropertyValue(column)) : this.OrderBy(x => x.GetPropertyValue(column));
            Comments result = new Comments();
            foreach (var i in sortedList) { result.Add((Comment)i); }
            return result;
        }

        #endregion
    }
}
