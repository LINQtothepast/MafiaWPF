using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MafiaApplication_WPF_
{
    class Jailor
    {
        public static string JailorName;

        public static string JailorRole(string name)
        {
            JailorName = name;
            return "Jailor";
        }

        public static void SwitchTo()
        {
            while (Game.GameOngoing == true)
            {
                Console.WriteLine("Jailor");
                Game.GameOngoing = false;

            }
        }
    }
}
