using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MafiaApplication_WPF_
{
    class ConArtist
    {
        public static string ConArtistName;

        public static string ConArtistRole(string name)
        {
            ConArtistName = name;
            return "Con Artist";
        }

        public static void SwitchTo()
        {
            while (Game.GameOngoing == true)
            {
                Console.WriteLine("ConArtist");
                Game.GameOngoing = false;

            }
        }
    }
}
