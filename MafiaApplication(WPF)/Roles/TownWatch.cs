using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MafiaApplication_WPF_
{
    class TownWatch
    { 
        private static string TownWatchName;

        public static string TownWatchRole(string name)
        {
            TownWatchName = name;
            return "Town Watch";
        }

        public static void SwitchTo()
        {
            while (Game.GameOngoing == true)
            {
                Console.WriteLine("Town Watch");
                Game.GameOngoing = false;

            }
        }
    }
}
