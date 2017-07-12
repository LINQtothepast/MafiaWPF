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

        //constructor
        public User(string email, string name, int role, string roleName, string status)
        {
            UserEmail = email;
            UserName = name;
            UserRole = role;
            UserRoleName = roleName;
            UserStatus = status;
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
    }
}
