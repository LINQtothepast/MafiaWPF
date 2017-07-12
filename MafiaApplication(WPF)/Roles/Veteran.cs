using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MafiaApplication_WPF_
{
    class Veteran
    {
        private static string VeteranName;

        public static string VeteranRole(string name)
        {
            VeteranName = name;
            return "Veteran";
        }

        public static void SwitchTo()
        {
            while (Game.GameOngoing == true)
            {
                Console.WriteLine("Veteran");
                Game.GameOngoing = false;

            }
        }
    }
}
