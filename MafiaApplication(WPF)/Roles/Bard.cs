using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace MafiaApplication_WPF_
{
    class Bard
    {
        public static void BardNightTime(User passedUser, User sessionUser)
        {
            SqlConnection connect;
            string retVisitedBy = "";
            string connetionString = null;
            connetionString = ("user id=Derek;" +
                                "server=localhost;" +
                                "Trusted_Connection=yes;" +
                                "database=Test");

            using (connect = new SqlConnection(connetionString))
            {
                connect.Open();

                //if the user is a vet then update armed to not armed
                if (passedUser.UserRole == 13)
                {
                    passedUser.UserArmed = false;
                    using (SqlCommand cmd =
                    new SqlCommand("UPDATE UserStatus SET Armed=@Armed" +
                    " WHERE Id=@Id", connect))
                    {
                        cmd.Parameters.AddWithValue("@Id", passedUser.UserID);
                        cmd.Parameters.AddWithValue("@Armed", 0);

                        int rows = cmd.ExecuteNonQuery();
                    }
                }

                //read visitedBy so that it is properly updated
                SqlCommand command = new SqlCommand("Select visitedby FROM [UserStatus] WHERE ID=@ID", connect);
                command.Parameters.AddWithValue("@ID", passedUser.UserID);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        retVisitedBy = reader["VisitedBy"].ToString();
                    }
                }

                retVisitedBy += (" " + sessionUser.UserName);

                passedUser.UserBlocked = true;
                passedUser.UserVisitedBy += sessionUser.UserName + " ";
                using (SqlCommand cmd =
                new SqlCommand("UPDATE UserStatus SET Blocked=@Blocked, VisitedBy=@VisitedBy" +
                " WHERE Id=@Id", connect))
                {
                    cmd.Parameters.AddWithValue("@Id", passedUser.UserID);
                    cmd.Parameters.AddWithValue("@Blocked", 1);
                    cmd.Parameters.AddWithValue("@VisitedBy", retVisitedBy);

                    int rows = cmd.ExecuteNonQuery();
                }

                connect.Close();
            }            
        }
    }
}
