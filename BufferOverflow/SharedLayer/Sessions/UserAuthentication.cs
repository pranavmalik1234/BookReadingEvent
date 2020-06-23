using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLayer.Sessions
{
    public class UserAuthentication
    {
        public static int LoggedInUserId { get; set; }

        /// <summary>
        /// This method assigns userId to the session.
        /// </summary>
        /// <param name="userId"></param>
        public void UserAuthenticate(int userId)
        {
            LoggedInUserId = userId;
        }

        /// <summary>
        /// Signing off change user id to 0.
        /// </summary>
        public void Logout()
        {
            LoggedInUserId = 0;
        }
    }
}
