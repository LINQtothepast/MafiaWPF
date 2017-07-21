using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MafiaApplication_WPF_
{
    class TownWatch
    {
        public static string TownWatchNightTime(User passedUser, User sessionUser)
        {
            if (passedUser.UserArmed == true)
            {
                sessionUser.UserKilled = true;
            }
            passedUser.UserVisitedBy = sessionUser.UserName + " ";
            return passedUser.UserVisitedBy;
        }
    }
}
