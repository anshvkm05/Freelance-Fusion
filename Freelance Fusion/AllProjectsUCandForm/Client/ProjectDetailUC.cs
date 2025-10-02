using Freelance_Fusion.CardsForClientDashboards;
using System;
using System.Collections.Generic;
using Firebase.Database;
using Firebase.Database.Query;
using Freelance_Fusion.AllProjectsUCandForm.Client;
using Freelance_Fusion.Events;
using Freelance_Fusion.FreelancerClientDetailsEnter;
using Freelance_Fusion.Models;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Freelance_Fusion.AllProjectsUCandForm
{
    public partial class ProjectDetailUC : UserControl
    {
        private readonly FirebaseClient _authenticatedClient;
        private readonly ProjectClient _project;
        public ProjectDetailUC(FirebaseClient authenticatedClient, CardsForClientDashboards.ProjectClient project)
        {
            InitializeComponent();
            _authenticatedClient = authenticatedClient;
            _project = project;
        }

        private void PopulateDetails()
        {
            RTProjectTitle.Text = _project.Title;
            ProjectDesRichTB.Text = _project.Description; // Brief description

            // Populate Tags
            flpTags.Controls.Clear();
            foreach (var tag in _project.KeySkillsTags)
            {
                Label tagLabel = new Label
                {
                    Text = tag,
                    AutoSize = true,
                    BackColor = Color.FromArgb(224, 224, 224),
                    ForeColor = Color.FromArgb(64, 64, 64),
                    Margin = new Padding(3),
                    Padding = new Padding(5, 3, 5, 3),
                    Font = new Font("Segoe UI", 8F)
                };
                flpTags.Controls.Add(tagLabel);
            }

            // --- CORRECTED DATA BINDING ---
            // Now we use the new properties from the updated ProjectClient model.
            RTDetailProjectDescription.Text = _project.DetailedDescription;

            // Format lists with bullet points for clean display
            RTRequiredSkiils.Text = "• " + string.Join("\n• ", _project.RequiredSkills);
            RTDeliverables.Text = "• " + string.Join("\n• ", _project.Deliverables);

            RTStartDate.Text = $"Start Date: {_project.StartDate:dd MMM yyyy}";
            RTDeadline.Text = $"Deadline: {_project.Deadline:dd MMM yyyy}";
            RTExpectedPrice.Text = $"{_project.ExpectedPrice:N0}";
            progressBar.Text = _project.Progress.ToString() + "%";
        }
        private async Task LoadBids()
        {
            try
            {
                flpBids.Controls.Clear();

                // 1. Fetch all bids for this specific project.
                var bidsSnapshot = await _authenticatedClient
                    .Child("bids")
                    .Child(_project.ProjectID)
                    .OnceAsync<Bid>();

                if (bidsSnapshot == null || !bidsSnapshot.Any())
                {
                    // Optionally, show a label saying "No bids yet."
                    return;
                }

                // 2. For each bid, we also need to fetch the profile of the freelancer who placed it.
                foreach (var bidItem in bidsSnapshot)
                {
                    var bid = bidItem.Object;
                    if (bid == null) continue;

                    // Fetch the freelancer's profile from the 'users' node
                    var freelancerProfile = await _authenticatedClient
                        .Child("users")
                        .Child(bid.FreelancerID)
                        .OnceSingleAsync<UserProfile>();

                    if (freelancerProfile != null)
                    {
                        // 3. Create, populate, and display the BiddersUC.
                        BiddersUC bidCard = new BiddersUC();
                        bidCard.Populate(bid, freelancerProfile);
                        bidCard.AcceptBidClicked += OnAcceptBid_Clicked; // Handle the accept click
                        flpBids.Controls.Add(bidCard);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load bids: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void OnAcceptBid_Clicked(object sender, BidEventArgs e)
        {
            var selectedBid = e.Bid;
            var result = MessageBox.Show($"Are you sure you want to accept the bid from {selectedBid.FreelancerID} for Rs. {selectedBid.BidAmount:N0}?",
                                         "Confirm Bid Acceptance", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // --- FAN-OUT WRITE OPERATION ---

                    // 1. Update the project's status and assign the freelancer.
                    await _authenticatedClient
                        .Child("projects")
                        .Child(selectedBid.ProjectID)
                        .PatchAsync(new
                        {
                            Status = "In Progress",
                            AcceptedFreelancerID = selectedBid.FreelancerID,
                            FinalPrice = selectedBid.BidAmount
                        });

                    // 2. Update the winning bid's status.
                    await _authenticatedClient
                        .Child("bids")
                        .Child(selectedBid.ProjectID)
                        .Child(selectedBid.FreelancerID)
                        .PatchAsync(new { Status = "Accepted" });

                    // 3. Add the project to the freelancer's 'ongoingProjects' list for efficient fetching.
                    await _authenticatedClient
                        .Child("users")
                        .Child(selectedBid.FreelancerID)
                        .Child("ongoingProjects")
                        .Child(selectedBid.ProjectID)
                        .PutAsync(true);


                    // 4. Loop through all other bids for this project and update their status to "Rejected".
                    var allBids = await _authenticatedClient.Child("bids").Child(selectedBid.ProjectID).OnceAsync<Bid>();
                    foreach (var bid in allBids)
                    {
                        if (bid.Key != selectedBid.FreelancerID)
                        {
                            await _authenticatedClient.Child("bids").Child(selectedBid.ProjectID).Child(bid.Key).PatchAsync(new { Status = "Rejected" });
                        }
                    }

                    MessageBox.Show("Bid accepted successfully! The project is now in progress.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Refresh the bids to reflect the "Accepted" status
                    await LoadBids();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to accept bid: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ProjectDesRichTB_TextChanged(object sender, EventArgs e)
        {

        }

        private void flpTags_Paint(object sender, PaintEventArgs e)
        {

        }

        private void RTDetailProjectDescription_TextChanged(object sender, EventArgs e)
        {

        }

        private void RTRequiredSkiils_TextChanged(object sender, EventArgs e)
        {

        }

        private void RTStartDate_TextChanged(object sender, EventArgs e)
        {

        }

        private void RTDeadline_TextChanged(object sender, EventArgs e)
        {

        }

        private void RTReviews_TextChanged(object sender, EventArgs e)
        {

        }

        private void RTDeliverables_TextChanged(object sender, EventArgs e)
        {

        }

        private void RTExpectedPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void RTAveragePrice_TextChanged(object sender, EventArgs e)
        {

        }

        private async void ProjectDetailUC_Load(object sender, EventArgs e)
        {
            PopulateDetails();
            await LoadBids();
        }
    }
}
