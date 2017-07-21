using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace MafiaApplication_WPF_
{
    public class User
    {
        //attributes
        //all bool values are default false
        private string userEmail;
        private string userName;
        private int userRole;
        private string userRoleName;
        private bool userStatus;    //true = dead,      false = alive
        private bool userBlocked;   //true = blocked,   false = not blocked
        private bool userConned;    //true = conned,    false = not conned
        private bool userSaved;     //true = saved,     false = not saved
        private bool userKilled;    //true = killed,    false = not killed
        private bool userArmed;     //true = armed,     false = not armed
        private bool userRoleActive;//true = active at night, false = not active
        private string userVisitedBy;
        private bool userWin;       //true = win,       false = lose
        private bool userHasNomVoted;  //true = has voted, false = has not voted
        private bool userHasVoted;  //true = has voted, false = has not voted
        private int userLynchNominationVotes;
        private int userLynchVotes;

        //constructor
        public User(string email, string name, int role, string roleName, bool status,
            bool blocked, bool conned, bool saved, bool killed, bool armed, bool roleActive,
            string visitedBy, bool win, bool hasNomVoted, bool hasVoted, int nomVotes, int votes)
        {
            UserEmail = email;
            UserName = name;
            UserRole = role;
            UserRoleName = roleName;
            UserStatus = status;
            UserBlocked = blocked;
            UserConned = conned;
            UserSaved = saved;
            UserKilled = killed;
            UserArmed = armed;
            UserRoleActive = roleActive;
            UserVisitedBy = visitedBy;
            UserWin = win;
            UserHasNomVoted = hasNomVoted;
            UserHasVoted = hasVoted;
            UserLynchNominationVotes = nomVotes;
            UserLynchVotes = votes;
        }

        //properties
        public string UserEmail
        {
            get { return userEmail; }
            set { userEmail = value; }
        }
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        public int UserRole
        {
            get { return userRole; }
            set { userRole = value; }
        }
        public string UserRoleName
        {
            get { return userRoleName; }
            set { userRoleName = value; }
        }
        public bool UserStatus
        {
            get { return userStatus; }
            set { userStatus = value; }
        }
        public bool UserBlocked
        {
            get { return userBlocked; }
            set { userBlocked = value; }
        }
        public bool UserConned
        {
            get { return userConned; }
            set { userConned = value; }
        }
        public bool UserSaved
        {
            get { return userSaved; }
            set { userSaved = value; }
        }
        public bool UserKilled
        {
            get { return userKilled; }
            set { userKilled = value; }
        }
        public bool UserArmed       {
            get { return userArmed; }
            set { userArmed = value; }
        }
        public bool UserRoleActive
        {
            get { return userRoleActive; }
            set { userRoleActive = value; }
        }
        public string UserVisitedBy
        {
            get { return userVisitedBy; }
            set { userVisitedBy = value; }
        }
        public bool UserWin
        {
            get { return userWin; }
            set { userWin = value; }
        }
        public bool UserHasNomVoted
        {
            get { return userHasNomVoted; }
            set { userHasNomVoted = value; }
        }
        public bool UserHasVoted
        {
            get { return userHasVoted; }
            set { userHasVoted = value; }
        }
        public int UserLynchNominationVotes
        {
            get { return userLynchNominationVotes; }
            set { userLynchNominationVotes = value; }
        }
        public int UserLynchVotes
        {
            get { return userLynchVotes; }
            set { userLynchVotes = value; }
        }
    }
}
