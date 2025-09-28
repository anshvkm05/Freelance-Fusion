using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freelance_Fusion.LoginUsercontorls
{
    // A custom event argument class to pass the authenticated user's data
    public class LoginEventArgs : EventArgs
    {
        public User User { get; }
        public LoginEventArgs(User user)
        {
            User = user;
        }
    }
}
