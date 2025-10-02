using Freelance_Fusion.Events;
using Freelance_Fusion.FreelancerClientDetailsEnter;
using Freelance_Fusion.Models;
using System;
using System.Windows.Forms;

namespace Freelance_Fusion.AllProjectsUCandForm.Client
{
    public partial class BiddersUC : UserControl
    {
        private Bid _bid;
        private UserProfile _freelancerProfile;
        public event EventHandler<BidEventArgs> AcceptBidClicked;
        public BiddersUC()
        {
            InitializeComponent();
        }
        public void Populate(Bid bid, UserProfile freelancerProfile)
        {
            _bid = bid;
            _freelancerProfile = freelancerProfile;

            // Assuming you have controls with these names in your BiddersUC designer
            TBFreelancerName.Text = $"{freelancerProfile.FirstName} {freelancerProfile.LastName}";
            RTBidAmount.Text = $"Rs. {bid.BidAmount:N0}";
            RTProposalText.Text = bid.ProposalText;
            // You would also load the freelancer's profile picture here
            // e.g., picFreelancer.ImageLocation = freelancerProfile.ProfilePictureUrl;
        }

        private void BtnBidAccept_Click(object sender, EventArgs e)
        {
            if (_bid != null)
            {
                AcceptBidClicked?.Invoke(this, new BidEventArgs(_bid));
            }
        }
    }
}
