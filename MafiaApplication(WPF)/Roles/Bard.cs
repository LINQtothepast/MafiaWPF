using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MafiaApplication_WPF_
{
    class Bard
    {
        public static void BardNightTime(User passedUser, User sessionUser)
        {
            if (passedUser.UserRole == 13)
            {
                passedUser.UserArmed = false;
            }
            passedUser.UserBlocked = true;
            passedUser.UserVisitedBy += sessionUser.UserName + " ";
        }
    }
}
