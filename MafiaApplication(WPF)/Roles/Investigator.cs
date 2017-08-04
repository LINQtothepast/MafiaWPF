using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace MafiaApplication_WPF_
{
    class Investigator
    {
        public static string InvNightTime(User passedUser, User sessionUser)
        {
            bool isUserArmed = false;
            bool isUserConned = false;
            string result = "";
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
                SqlCommand command = new SqlCommand("Select Conned, Armed, VisitedBy FROM [UserStatus] WHERE ID=@ID", connect);
                command.Parameters.AddWithValue("@ID", passedUser.UserID);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        isUserConned = Convert.ToBoolean(reader["Conned"]);
                        isUserArmed = Convert.ToBoolean(reader["Armed"]);
                        retVisitedBy = reader["VisitedBy"].ToString();
                    }
                }
                retVisitedBy += (" " + sessionUser.UserName);

                //if the passed user is armed then kill the investigator
                if (isUserArmed == true)
                {
                    using (SqlCommand cmd =
                    new SqlCommand("UPDATE UserStatus SET Killed=@Killed" +
                    " WHERE Id=@Id", connect))
                    {
                        cmd.Parameters.AddWithValue("@Id", sessionUser.UserID);
                        cmd.Parameters.AddWithValue("@Killed", 1);

                        int rows = cmd.ExecuteNonQuery();
                    }
                    sessionUser.UserKilled = true;
                }
                if (isUserConned == true)
                    return "Consigliere, Medium, Rabble-Rouser";
                switch (passedUser.UserRole)
                {
                    //groupings are
                    //1. Godfather, Jailor, and Village Idiot (4, 6, 10)
                    //2. Con Artist, Vigilante, Doctor (2, 7, 14)
                    //3. Consigliere, Medium, Rabble-Rouser (5, 8, 9)
                    //4. Town Psycho, Bard, Town Watch (11, 12, 15)
                    //5. Sheriff, Investigator, Veteran (1, 3, 13)
                    case 4:
                    case 6:
                    case 10:
                        result = "Godfather, Jailor, and Village Idiot";
                        break;
                    case 2:
                    case 7:
                    case 14:
                        result = "Con Artist, Vigilante, Doctor";
                        break;
                    case 5:
                    case 8:
                    case 9:
                        result = "Consigliere, Medium, Rabble-Rouser";
                        break;
                    case 11:
                    case 12:
                    case 15:
                        result = "Town Psycho, Bard, Town Watch";
                        break;
                    case 1:
                    case 3:
                    case 13:
                        result = "Sheriff, Investigator, Veteran";
                        break;
                }

                //set passedUser visitedBy
                using (SqlCommand cmd =
                new SqlCommand("UPDATE UserStatus SET Conned=@Conned, VisitedBy=@VisitedBy" +
                " WHERE Id=@Id", connect))
                {
                    cmd.Parameters.AddWithValue("@Id", passedUser.UserID);
                    cmd.Parameters.AddWithValue("@VisitedBy", retVisitedBy);

                    int rows = cmd.ExecuteNonQuery();
                }
                connect.Close();
            }
            passedUser.UserVisitedBy += sessionUser.UserName + " ";
           
            return result;
        }
    }
}
