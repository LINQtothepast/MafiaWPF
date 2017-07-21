using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MafiaApplication_WPF_
{
    class TownPsycho
    {
        public static void TownPsychoNightTime(User passedUser, User sessionUser)
        {
            if (passedUser.UserArmed == true)
            {
                sessionUser.UserKilled = true;
            }
            else
            {
                passedUser.UserKilled = true;
            }
            passedUser.UserVisitedBy = sessionUser.UserName + " ";
        }
    }
}
