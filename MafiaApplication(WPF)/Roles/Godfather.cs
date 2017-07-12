using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MafiaApplication_WPF_
{
    class Godfather
    {
        public static string GodfatherName;

        public static string GodfatherRole(string name)
        {
            GodfatherName = name;
            return "Godfather";
        }

        public static void SwitchTo()
        {
            while (Game.GameOngoing == true)
            {
                Console.WriteLine("Godfather");
                Game.GameOngoing = false;

            }
        }
    }
}
