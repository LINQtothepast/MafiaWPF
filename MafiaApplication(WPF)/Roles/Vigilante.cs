using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MafiaApplication_WPF_
{
    class Vigilante
    {
        public static void VigNightTime(User passedUser, User sessionUser)
        {
            if (passedUser.UserArmed == true)
            {
                sessionUser.UserKilled = true;
            }
            else if (passedUser.UserRole != 6 || passedUser.UserRole != 7 || passedUser.UserRole != 8 ||
                passedUser.UserRole != 10 || passedUser.UserRole != 12)
            {
                passedUser.UserKilled = true;
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
