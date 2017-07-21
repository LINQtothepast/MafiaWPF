using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MafiaApplication_WPF_
{
    class ConArtist
    {
        public static void ConNightTime(User passedUser, User sessionUser)
        {
            if (passedUser.UserArmed == true)
            {
                sessionUser.UserKilled = true;
            }
            passedUser.UserConned = true;
            passedUser.UserVisitedBy += sessionUser.UserName + " ";

        }
    }
}
