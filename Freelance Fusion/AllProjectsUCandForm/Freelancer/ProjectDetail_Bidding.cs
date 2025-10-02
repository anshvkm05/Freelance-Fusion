using Firebase.Database;
using Firebase.Database.Query;
using Freelance_Fusion.CardsForClientDashboards;
using Freelance_Fusion.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Freelance_Fusion.AllProjectsUCandForm.Freelancer
{
    public partial class ProjectDetail_Bidding : UserControl
    {

        private readonly FirebaseClient _authenticatedClient;
        private readonly string _freelancerUid;
        private readonly ProjectClient _project;
        public ProjectDetail_Bidding(FirebaseClient authenticatedClient, string freelancerUid, ProjectClient project)
        {
            InitializeComponent();
            _authenticatedClient = authenticatedClient;
            _freelancerUid = freelancerUid;
            _project = project;
            PopulateProjectDetails(project);
        }

        private void PopulateProjectDetails(ProjectClient project)
        {
            RTProjectTitle.Text = project.Title;
            ProjectDesRichTB.Text = project.Description; // Brief description

            // Populate Tags
            flpTags.Controls.Clear();
            foreach (var tag in project.KeySkillsTags)
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
            RTDetailProjectDescription.Text = project.DetailedDescription;

            // Format lists with bullet points for clean display
            RTRequiredSkiils.Text = "• " + string.Join("\n• ", project.RequiredSkills);
            RTDeliverables.Text = "• " + string.Join("\n• ", project.Deliverables);

            RTStartDate.Text = $"Start Date: {project.StartDate:dd MMM yyyy}";
            RTDeadline.Text = $"Deadline: {project.Deadline:dd MMM yyyy}";
            RTExpectedPrice.Text = $"{project.ExpectedPrice:N0}";
        }

        private async void btnSubmitBid_Click(object sender, EventArgs e)
        {
            // Basic validation
            if (!double.TryParse(TBEnterBidAmount.Text, out double bidAmount) || string.IsNullOrWhiteSpace(TBTextToBid.Text))
            {
                MessageBox.Show("Please enter a valid bid amount and proposal text.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var newBid = new Bid
            {
                ProjectID = _project.ProjectID,
                FreelancerID = _freelancerUid,
                BidAmount = bidAmount,
                ProposalText = TBTextToBid.Text,
                BidDate = DateTime.UtcNow,
                Status = "Pending"
            };

            try
            {
                // --- FAN-OUT WRITE OPERATION ---
                // 1. Save the bid to the public bids list for that project.
                // We use the freelancer's UID as the key to ensure they can only place one bid.
                await _authenticatedClient
                    .Child("bids")
                    .Child(_project.ProjectID)
                    .Child(_freelancerUid) // Use freelancer's UID as the Bid ID
                    .PutAsync(newBid);

                // 2. Add a reference to this bid under the freelancer's private profile.
                await _authenticatedClient
                    .Child("users")
                    .Child(_freelancerUid)
                    .Child("bidsPlaced")
                    .Child(_project.ProjectID) // Use the project ID as the key
                    .PutAsync(true); // Store a simple boolean value

                MessageBox.Show("Your bid has been placed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to place bid: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ProjectDetail_Bidding_Load(object sender, EventArgs e)
        {
        }
    }
}
