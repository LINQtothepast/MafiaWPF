using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MafiaApplication_WPF_
{
    public class UserCollection
    {
        //list of users
        private static List<User> UserList = new List<User>();

        //add a user
        public static void addUser(string email, string name)
        {
            UserList.Add(new User(email, name, 0, "unset", "alive"));
        }

        //return list of users for use elsewhereC:\Users\Derek\Desktop\MafiaApplication(WPF)\MafiaApplication(WPF)\UserCollection.cs
        public static List<User> ReturnPlayerList()
        {
            return UserList;
        }

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

        //call to print out name and role name of each player
        public static void PrintRoles()
        {
            foreach (var element in UserList)
            {
                Console.WriteLine("Name:{0} Role: {1}",
                    element.UserName.PadRight(15), element.UserRoleName);
            }
        }
    }

}
