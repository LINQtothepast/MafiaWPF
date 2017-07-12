using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MafiaApplication_WPF_
{
    class Consigliere
    {
        public static string ConsigliereName;

        public static string ConsigliereRole(string name)
        {
            ConsigliereName = name;
            return "Consigliere";
        }
        public static void SwitchTo()
        {
            while (Game.GameOngoing == true)
            {
                Console.WriteLine("Consigliere");
                Game.GameOngoing = false;

            }
        }
    }
}
