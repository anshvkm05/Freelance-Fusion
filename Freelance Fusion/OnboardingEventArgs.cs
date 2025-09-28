using Firebase.Database;
using System;

namespace Freelance_Fusion.Events
{
    public class OnboardingEventArgs : EventArgs
    {
        public FirebaseClient AuthenticatedClient { get; }
        public string Uid { get; }

        public OnboardingEventArgs(FirebaseClient authenticatedClient, string uid)
        {
            AuthenticatedClient = authenticatedClient;
            Uid = uid;
        }
    }
}
