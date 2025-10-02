using Freelance_Fusion.Models;
using System;

namespace Freelance_Fusion.Events
{
    public class BidEventArgs : EventArgs
    {
        public Bid Bid { get; }

        public BidEventArgs(Bid bid)
        {
            Bid = bid;
        }
    }
}
