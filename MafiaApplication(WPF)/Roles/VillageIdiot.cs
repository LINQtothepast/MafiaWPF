using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MafiaApplication_WPF_
{
    class VillageIdiot
    {
        private static string VillageIdiotName;

        public static string VillageIdiotRole(string name)
        {
            VillageIdiotName = name;
            return "Village Idiot";
        }

        public static void SwitchTo()
        {
            while (Game.GameOngoing == true)
            {
                Console.WriteLine("Village Idiot");
                Game.GameOngoing = false;

            }
        }
    }
}
