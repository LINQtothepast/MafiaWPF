﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace MafiaApplication_WPF_
{
    class Doctor
    {
        public static void DocNightTime(User passedUser, User sessionUser)
        {


            bool isUserArmed = false;
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
                SqlCommand command = new SqlCommand("Select Armed, VisitedBy FROM [UserStatus] WHERE ID=@ID", connect);
                command.Parameters.AddWithValue("@ID", passedUser.UserID);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        isUserArmed = Convert.ToBoolean(reader["Armed"]);
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

                //set passedUser to be saved and visitedBy
                using (SqlCommand cmd =
                new SqlCommand("UPDATE UserStatus SET Saved=@Saved, VisitedBy=@VisitedBy" +
                " WHERE Id=@Id", connect))
                {
                    cmd.Parameters.AddWithValue("@Id", passedUser.UserID);
                    cmd.Parameters.AddWithValue("@Saved", 1);
                    cmd.Parameters.AddWithValue("@VisitedBy", retVisitedBy);

                    int rows = cmd.ExecuteNonQuery();
                }

                passedUser.UserSaved = true;
                passedUser.UserVisitedBy += sessionUser.UserName + " ";

                connect.Close();
            }
        }
    }
}
