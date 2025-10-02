using Firebase.Database;
using Freelance_Fusion.FreelancerClientDetailsEnter;
using System;

namespace Freelance_Fusion.Events
{
    public class LoginCompleteEventArgs : EventArgs
    {
        public FirebaseClient AuthenticatedClient { get; }
        public string Uid { get; }
        public UserProfile UserProfile { get; }

        public LoginCompleteEventArgs(FirebaseClient authenticatedClient, string uid, UserProfile userProfile)
        {
            AuthenticatedClient = authenticatedClient;
            Uid = uid;
            UserProfile = userProfile;
        }
    }
}
