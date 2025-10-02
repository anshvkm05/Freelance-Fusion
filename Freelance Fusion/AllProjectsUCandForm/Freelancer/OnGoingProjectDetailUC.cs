using Firebase.Database;
using Freelance_Fusion.CardsForClientDashboards;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Freelance_Fusion.AllProjectsUCandForm.Freelancer
{
    public partial class OnGoingProjectDetailUC : UserControl
    {
        private readonly FirebaseClient _authenticatedClient;
        private readonly string _freelancerUid;
        private readonly ProjectClient _project;
        private int _progress;
        public OnGoingProjectDetailUC(FirebaseClient authenticatedClient, string freelancerUid, ProjectClient project)
        {
            InitializeComponent();
            _authenticatedClient = authenticatedClient;
            _freelancerUid = freelancerUid;
            _project = project;
            PopulateProjectDetails(project);
        }
        private void PopulateProjectDetails(ProjectClient project)
        {
            _progress = project.Progress;
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
            RTYourPrice.Text = $"{project.FinalPrice:N0}";
            lblProgressPercentage.Text = project.Progress.ToString() + "%";
        }

        private void btnSubmitProject_Click(object sender, EventArgs e)
        {
            if (TBEnterProjectLink == null || string.IsNullOrWhiteSpace(TBEnterProjectLink.Text))
            {
                MessageBox.Show("Enter a valid link to submit your project.", "Error");
                return;
            }
            if (MessageBox.Show("Are you sure you want to mark this project as completed?", "Confirm Completion", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                MessageBox.Show("Project marked as completed!", "Success");
            }
        }

        private void BtnUpdateProgress_Click(object sender, EventArgs e)
        {
        }

        private void BtnUpdateProgress_MouseHover(object sender, EventArgs e)
        {
            lblUpdateProjectProgress.Visible = true;
        }

        private void BtnUpdateProgress_MouseLeave(object sender, EventArgs e)
        {
            lblUpdateProjectProgress.Visible = false;
        }

        private void Add5percenttoProgress_Click(object sender, EventArgs e)
        {
            if ( _progress >= 100 ) return;
            _progress += 5;
            lblProgressPercentage.Text = _progress.ToString() + "%";
        }

        private void Subtract5percenttoProgress_Click(object sender, EventArgs e)
        {
            if ( _progress <= 0 ) return;
            _progress -= 5;
            lblProgressPercentage.Text = _progress.ToString() + "%";
        }
    }
}
