using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MafiaApplication_WPF_
{
    class Medium
    {
        private static string MediumName;

        public static string MediumRole(string name)
        {
            MediumName = name;
            return "Medium";
        }

        public static void SwitchTo()
        {
            while (Game.GameOngoing == true)
            {
                Console.WriteLine("Medium");
                Game.GameOngoing = false;

            }
        }
    }
}
