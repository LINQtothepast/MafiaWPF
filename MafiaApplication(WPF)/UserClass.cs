using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MafiaApplication_WPF_
{
    public class User
    {
        //attributes
        private string userEmail;
        private string userName;
        private int userRole;
        private string userRoleName;
        private string userStatus;
        private string userJailed;
        private int userLynchNominationVotes;
        private int userLynchVotes;

        //constructor
        public User(string email, string name, int role, string roleName, string status,
            string jailed, int nomVotes, int votes)
        {
            UserEmail = email;
            UserName = name;
            UserRole = role;
            UserRoleName = roleName;
            UserStatus = status;
            UserJailed = jailed;
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
        public string UserStatus
        {
            get { return userStatus; }
            set { userStatus = value; }
        }
        public string UserJailed
        {
            get { return userJailed; }
            set { userJailed = value; }
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
