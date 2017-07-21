using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MafiaApplication_WPF_
{
    class Doctor
    {
        public static void DocNightTime(User passedUser, User sessionUser)
        {
            if (passedUser.UserArmed == true)
            {
                sessionUser.UserKilled = true;
            }
            passedUser.UserSaved = true;
            passedUser.UserVisitedBy += sessionUser.UserName + " ";
        }
    }
}
