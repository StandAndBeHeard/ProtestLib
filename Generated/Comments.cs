using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace ProtestLib
{
    [Serializable]
    public partial class Comments : System.Collections.Generic.List<Comment>
    {

        #region Constructor
        public Comments()
        {
        }
        #endregion

        #region Methods
        public static Comments LoadComments(string sql, System.Data.CommandType commandType, System.Data.SqlClient.SqlParameter[] parameters)
        {
            return Comments.ConvertFromDT(Utils.ExecuteQuery(sql, commandType, parameters));
        }

        public static Comments ConvertFromDT(DataTable dt)
        {
            Comments result = new Comments();
            foreach (DataRow row in dt.Rows)
            {
                result.Add(Comment.GetComment(row));
            }
            return result;
        }

        public static Comments LoadAllComments()
        {
            return Comments.LoadComments("LoadCommentsAll", CommandType.StoredProcedure, null);
        }

        public void SaveAll(bool waitForId = true)
        {
            SqlConnection conn = Global.Connection;
            try
            {
                conn.Open();
                Utils.SetContextInfo(conn);
                foreach (ProtestLib.Comment comment in this)
                {
                    SqlCommand cmd = Comment.GetSaveCommand(comment, conn);
                    comment.Id = Convert.ToInt32(cmd.ExecuteScalar());
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

        public Comment GetCommentById(int commentId)
        {
            foreach (Comment comment in this)
            {
                if (comment.Id == commentId) return comment;
            }
            return null;
        }

        public static Comments LoadCommentsByUserId(System.Int32 userId)
        {
            return Comments.LoadComments("LoadCommentsByUserId", CommandType.StoredProcedure, new SqlParameter[] { new SqlParameter("@UserId", userId) });
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

