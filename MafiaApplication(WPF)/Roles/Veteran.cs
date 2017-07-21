using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MafiaApplication_WPF_
{
    class Veteran
    {
        private static int armedNights = 0;

        public static void VetNightTime(User sessionUser)
        {
            if (armedNights < 5)
            {
                sessionUser.UserArmed = true;
                armedNights += 1;
            }
        }
    }
}
