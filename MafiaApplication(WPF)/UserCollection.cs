using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MafiaApplication_WPF_
{
    public class UserCollection
    {
        //list of users
        private static List<User> UserList = new List<User>();
        //private static List<User> fifteenPlayerList = new List<User>();

        //add a user
        public static void addUser(string email, string name)
        {
            UserList.Add(new User(email, name, 0, "unset", false, false, false, false, false, false,
                false, "", false, false, false, 0, 0));
        }

        //add player to fifteen player list
        public static void addPlayer(User temp)
        {
            UserList.Add(temp);
        }

        //return a user
        /*public static User ReturnAUser(string sessionUser)
        {
            User temp = UserList[0];

            var tempList =
                from player in UserList
                where player.UserName == sessionUser
                select player;

            

            if (tempList == null)
            {
                MessageBox.Show("error");
            }
            return temp;
        }
        */

        //return list of users for use elsewhere
        public static List<User> ReturnUserList()
        {
            return UserList;
        }

        //return list of fifteen players for use elsewhere
        //public static List<User> ReturnPlayerList()
        //{
        //    return fifteenPlayerList;
        //}

        //check username to see if it is valid

        public static bool checkCredentials(string passedUser)
        {
            bool valid = false;

            foreach (var element in UserList)
            {
                if (element.UserName == passedUser)
                {
                    valid = true;
                }
            }

            return valid;
        }
    
        //assign random role integer numbers from 1 to number of players
        public static void AssignRoles()
        {
            Random r = new Random();
            for (int i = UserList.Count; i > 1; i--)
            {
                int k = r.Next(i);
                User temp = UserList[k];
                UserList[k] = UserList[i - 1];
                UserList[i - 1] = temp;
            }

            int newRole = 1;
            foreach (var element in UserList)
            {
                element.UserRole = newRole;
                newRole++;
            }
        }

        //randomize the list for game integrity purposes
        public static List<User> RandomizeList(List<User> PlayersList)
        {
        Random r = new Random();
            for (int i = PlayersList.Count; i > 1; i--)
            {
                int k = r.Next(i);
                User temp = PlayersList[k];
                PlayersList[k] = PlayersList[i - 1];
                PlayersList[i - 1] = temp;
            }
            return PlayersList;
        }

        //use switch statement to set a string based on role int
        public static void ChangeRoleName()
        {
            foreach (var element in UserList)
            {
                switch (element.UserRole)
                {
                    case 1:
                        element.UserRoleName = "Sheriff";
                        break;
                    case 2:
                        element.UserRoleName = "Doctor";
                        break;
                    case 3:
                        element.UserRoleName = "Investigator";
                        break;
                    case 4:
                        element.UserRoleName = "Jailor";
                        break;
                    case 5:
                        element.UserRoleName = "Medium";
                        break;
                    case 6:
                        element.UserRoleName = "Godfather";
                        break;
                    case 7:
                        element.UserRoleName = "Con Artist";
                        break;
                    case 8:
                        element.UserRoleName = "Consigliere";
                        break;
                    case 9:
                        element.UserRoleName = "Rabble-Rouser";
                        break;
                    case 10:
                        element.UserRoleName = "Village Idiot";
                        break;
                    case 11:
                        element.UserRoleName = "Bard";
                        break;
                    case 12:
                        element.UserRoleName = "Town Psycho";
                        break;
                    case 13:
                        element.UserRoleName = "Veteran";
                        break;
                    case 14:
                        element.UserRoleName = "Vigilante";
                        break;
                    case 15:
                        element.UserRoleName = "Town Watch";
                        break;
                }
            }
        }
    }
}
