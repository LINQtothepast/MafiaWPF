using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MafiaApplication_WPF_
{
    class Vigilante
    {
        private static string VigilanteName;

        public static string VigilanteRole(string name)
        {
            VigilanteName = name;
            return "Vigilante";
        }

        public static void SwitchTo()
        {
            while (Game.GameOngoing == true)
            {
                Console.WriteLine("Vigilante");
                Game.GameOngoing = false;

            }
        }
    }
}
