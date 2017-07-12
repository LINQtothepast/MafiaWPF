using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MafiaApplication_WPF_
{
    class RabbleRouser
    {
        private static string RabbleRouserName;

        public static string RabbleRouserRole(string name)
        {
            RabbleRouserName = name;
            return "Rabble-Rouser";
        }

        public static void SwitchTo()
        {
            while (Game.GameOngoing == true)
            {
                Console.WriteLine("RabbleRouser");
                Game.GameOngoing = false;

            }
        }
    }
}
