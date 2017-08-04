using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace MafiaApplication_WPF_
{
    class Veteran
    {
        private static int armedNights = 0;

        public static void VetNightTime(User sessionUser)
        {
            if (armedNights < 5)
            {
                sessionUser.UserArmed = true;
                armedNights += 1;

                SqlConnection connect;
                string connetionString = null;
                connetionString = ("user id=Derek;" +
                                    "server=localhost;" +
                                    "Trusted_Connection=yes;" +
                                    "database=Test");

                using (connect = new SqlConnection(connetionString))
                {
                    connect.Open();

                    using (SqlCommand cmd =
                    new SqlCommand("UPDATE UserStatus SET Armed=@Armed" +
                    " WHERE Id=@Id", connect))
                    {
                        cmd.Parameters.AddWithValue("@Id", sessionUser.UserID);
                        cmd.Parameters.AddWithValue("@Armed", 1);

                        int rows = cmd.ExecuteNonQuery();
                        connect.Close();
                    }
                }
            }
        }
    }
}
