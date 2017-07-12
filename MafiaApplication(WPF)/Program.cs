using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MafiaForConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string currentUser = "null";
            bool x = false;

            UserCollection.addUser("a", "Derek");
            UserCollection.addUser("b", "Tara");
            UserCollection.addUser("c", "Rowan");
            UserCollection.addUser("d", "Elsie");
            UserCollection.addUser("e", "Mike");
            UserCollection.addUser("f", "Krista");
            UserCollection.addUser("g", "Tom");
            UserCollection.addUser("h", "Fran");
            UserCollection.addUser("i", "Austin");
            UserCollection.addUser("j", "Tanner");

            List<User> AllUsers = new List<User>();
            AllUsers = UserCollection.ReturnPlayerList();

            string choice;
            string tempEmail;
            string tempUser;

            Console.WriteLine("Would you like to (1) use existing user or (2) register?");
            choice = (Console.ReadLine());
            try
            {
                if (choice == "2")
                {
                    Console.WriteLine("Enter your email");
                    tempEmail = Console.ReadLine();
                    Console.WriteLine("Enter your name");
                    tempUser = Console.ReadLine();
                    UserCollection.addUser(tempEmail, tempUser);
                }
                else if (choice == "1") { }
            }
            catch
            {
                Console.WriteLine("Would you like to (1) use existing user or (2) register?");
            }
            
            AllUsers = UserCollection.ReturnPlayerList();

            while (x == false)
            {
                Console.WriteLine("What is your username?");
                currentUser = Console.ReadLine();
                foreach (var element in AllUsers)
                {
                    if (currentUser == element.UserName)
                    {
                        x = true;
                        break;
                    }
                }
            }

            Console.WriteLine(currentUser);

            Console.WriteLine();

            UserCollection.AssignRoles();
            UserCollection.ChangeRoleName();
            UserCollection.PrintRoles();

            Game.SetUsersForGame();
            Game.GameStart(currentUser);

        }
    }
}
