using System;

namespace Freelance_Fusion.Models
{
    public class Bid
    {
        public string BidID { get; set; } // The unique ID of this bid
        public string ProjectID { get; set; } // The project this bid is for
        public string FreelancerID { get; set; } // The UID of the freelancer who made the bid
        public double BidAmount { get; set; }
        public string ProposalText { get; set; }
        public DateTime BidDate { get; set; }
        public string Status { get; set; } // e.g., "Pending", "Accepted", "Rejected"
    }
}
