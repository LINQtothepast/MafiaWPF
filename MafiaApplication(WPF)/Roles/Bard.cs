using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MafiaApplication_WPF_
{
    class Bard
    {
        public static string BardName;

        public static string BardRole(string name)
        {
            BardName = name;
            return "Bard";
        }

        public static void SwitchTo()
        {
            while (Game.GameOngoing == true)
            {
                Game.GameOngoing = false;

            }
        }
    }
}
