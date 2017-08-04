using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Data.SqlClient;

namespace MafiaApplication_WPF_
{
    class Sheriff
    {
        public static string SheriffNightTime(User passedUser, User sessionUser)
        {
            string result = "";
            bool isUserArmed = false;
            bool isUserConned = false;
            string retVisitedBy = "";
            SqlConnection connect;
            string connetionString = null;
            connetionString = ("user id=Derek;" +
                                "server=localhost;" +
                                "Trusted_Connection=yes;" +
                                "database=Test");

            using (connect = new SqlConnection(connetionString))
            {
                connect.Open();

                //read if the passed User is Armed and get their VisitedBy
                SqlCommand command = new SqlCommand("Select Armed, Conned, VisitedBy FROM [UserStatus] WHERE ID=@ID", connect);
                command.Parameters.AddWithValue("@ID", passedUser.UserID);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        isUserArmed = Convert.ToBoolean(reader["Armed"]);
                        isUserConned = Convert.ToBoolean(reader["Conned"]);
                        retVisitedBy = reader["VisitedBy"].ToString();
                    }
                }
                retVisitedBy += (" " + sessionUser.UserName);

                //if the passedUser is a vet and armed then sessionUser is killed
                if (isUserArmed == true)
                {
                    sessionUser.UserKilled = true;
                    using (SqlCommand cmd =
                    new SqlCommand("UPDATE UserStatus SET Killed=@Killed" +
                    " WHERE Id=@Id", connect))
                    {
                        cmd.Parameters.AddWithValue("@Id", sessionUser.UserID);
                        cmd.Parameters.AddWithValue("@Killed", 1);

                        int rows = cmd.ExecuteNonQuery();
                    }
                }

                //set visitedBy of passedUser
                using (SqlCommand cmd =
                new SqlCommand("UPDATE UserStatus SET Conned=@Conned, VisitedBy=@VisitedBy" +
                " WHERE Id=@Id", connect))
                {
                    cmd.Parameters.AddWithValue("@Id", passedUser.UserID);
                    cmd.Parameters.AddWithValue("@VisitedBy", retVisitedBy);

                    int rows = cmd.ExecuteNonQuery();
                }

                passedUser.UserConned = true;
                passedUser.UserVisitedBy += sessionUser.UserName + " ";

                if (isUserConned == true)
                {
                    return "Mafia";
                }

                switch (passedUser.UserRole)
                {
                    //'Mafia', 'Villager', 'Town Psycho', or 'Village Idiot'
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                    case 6:
                    case 9:
                    case 11:
                    case 13:
                    case 14:
                    case 15:
                        result = "Villager";
                        break;
                    case 7:
                    case 8:
                        result = "Mafia";
                        break;
                    case 12:
                        result = "Town Psycho";
                        break;
                    case 10:
                        result = "Village Idiot";
                        break;
                }
                connect.Close();
            }
            return result;
        }
    }
    
}
