using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MafiaApplication_WPF_
{
    class TownPsycho
    {
        private static string TownPsychoName;

        public static string TownPsychoRole(string name)
        {
            TownPsychoName = name;
            return "Town Psycho";
        }
        public static void SwitchTo()
        {
            while (Game.GameOngoing == true)
            {
                Console.WriteLine("Town Psycho");
                Game.GameOngoing = false;

            }
        }
    }
}
