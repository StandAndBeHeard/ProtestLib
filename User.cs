using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace ProtestLib
{
    public partial class User
    {
        public static User Load(string userName, string email)
        {
            Users users = Users.Load("SELECT * FROM Users WHERE ( LOWER(Username)=@UserName OR LOWER(Email)=@Email)", CommandType.Text, new SqlParameter[] { new SqlParameter("@Username", userName.ToLower()), new SqlParameter("@Email", email.ToLower()) });
            return (users.Count > 0) ? users[0] : null;
        }

        public static User Load(string userName, string email, string password)
        {
            string passwordHash = Utils.HashAndSalt(password);
            Users users = Users.Load("SELECT * FROM Users WHERE ( LOWER(Username)=@UserName OR LOWER(Email)=@Email) AND PasswordHash=@PasswordHash", CommandType.Text, new SqlParameter[] { new SqlParameter("@Username", userName.ToLower()), new SqlParameter("@Email", email.ToLower()), new SqlParameter("@PasswordHash", passwordHash) });
            return (users.Count>0) ? users[0] : null;
        }


    }
}
