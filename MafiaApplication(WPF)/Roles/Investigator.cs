using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MafiaApplication_WPF_
{
    class Investigator
    {
        public static string InvNightTime(User passedUser, User sessionUser)
        {
            string result = "";
            passedUser.UserVisitedBy += sessionUser.UserName + " ";
            if (passedUser.UserArmed == true)
            {
                sessionUser.UserKilled = true;
            }
            if (passedUser.UserConned == true)
                return "Consigliere, Medium, Rabble-Rouser";
            switch (passedUser.UserRole)
            {
                //groupings are
                //1. Godfather, Jailor, and Village Idiot (4, 6, 10)
                //2. Con Artist, Vigilante, Doctor (2, 7, 14)
                //3. Consigliere, Medium, Rabble-Rouser (5, 8, 9)
                //4. Town Psycho, Bard, Town Watch (11, 12, 15)
                //5. Sheriff, Investigator, Veteran (1, 3, 13)
                case 4: case 6: case 10:
                    result = "Godfather, Jailor, and Village Idiot";
                    break;
                case 2: case 7: case 14:
                    result = "Con Artist, Vigilante, Doctor";
                    break;
                case 5: case 8: case 9:
                    result = "Consigliere, Medium, Rabble-Rouser";
                    break;
                case 11: case 12: case 15:
                    result = "Town Psycho, Bard, Town Watch";
                    break;
                case 1: case 3: case 13:
                    result = "Sheriff, Investigator, Veteran";
                    break;
            }
            return result;
        }
    }
}
