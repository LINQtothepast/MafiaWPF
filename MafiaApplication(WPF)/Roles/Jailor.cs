using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MafiaApplication_WPF_
{
    class Jailor
    {
        public static void JailorNightTime(User passedUser, User sessionUser)
        {
            if (passedUser.UserArmed == true)
            {
                sessionUser.UserKilled = true;
            }
            passedUser.UserBlocked = true;
            passedUser.UserVisitedBy += sessionUser.UserName + " ";
        }
    }
}
