using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;


namespace MafiaApplication_WPF_
{
    class Sheriff
    {
        public static string SheriffNightTime(User passedUser, User sessionUser)
        {
            string result = "";
            sessionUser.UserVisitedBy = passedUser.UserName;
            if (passedUser.UserArmed == true)
            {
                sessionUser.UserKilled = true;
            }
            if (passedUser.UserConned == true)
            {
                return "Mafia";
            }
            switch (passedUser.UserRole)
            {
                //'Mafia', 'Villager', 'Town Psycho', or 'Village Idiot'
                case 1: case 2: case 3: case 4: case 5: case 6: case 9: case 11: case 13: case 14: case 15:
                    result = "Villager";
                    break;
                case 7: case 8:
                    result = "Mafia";
                    break;
                case 12:
                    result = "Town Psycho";
                    break;
                case 10:
                    result = "Village Idiot";
                    break;
            }
            return result;
        }
    }
    
}
