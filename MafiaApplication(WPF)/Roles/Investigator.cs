using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MafiaApplication_WPF_
{
    class Investigator
    {
        public static string InvestigatorName;

        public static string InvestigatorRole(string name)
        {
            InvestigatorName = name;
            return "Investigator";
        }

        public static void SwitchTo()
        {
            while (Game.GameOngoing == true)
            {
                Console.WriteLine("Investigator");
                Game.GameOngoing = false;

            }
        }
    }
}
