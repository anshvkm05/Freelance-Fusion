using Firebase.Database;
using Firebase.Database.Query;
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

        private async void btnSubmitProject_Click(object sender, EventArgs e)
        {
            if (_progress < 100)
            {
                MessageBox.Show("You can only submit the project when the progress is 100%.", "Update Progress First", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(TBEnterProjectLink.Text))
            {
                MessageBox.Show("Please enter a valid link to submit your project.", "Link Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Are you sure you want to submit this project for review?", "Confirm Submission", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    // Update the project's status and add the submission link
                    await _authenticatedClient
                        .Child("projects")
                        .Child(_project.ProjectID)
                        .PatchAsync(new
                        {
                            Status = "Submitted", // A new status for client review
                            SubmissionLink = TBEnterProjectLink.Text
                        });

                    // --- FAN-OUT: Move the project from 'ongoing' to 'completed' for the freelancer ---
                    // 1. Remove the reference from the ongoing projects list
                    await _authenticatedClient
                        .Child("users")
                        .Child(_freelancerUid)
                        .Child("ongoingProjects")
                        .Child(_project.ProjectID)
                        .DeleteAsync();

                    // 2. Add a reference to the completed projects list
                    await _authenticatedClient
                        .Child("users")
                        .Child(_freelancerUid)
                        .Child("completedProjects")
                        .Child(_project.ProjectID)
                        .PutAsync(true);

                    MessageBox.Show("Project submitted successfully for client review!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // You might want to close the form here or disable the buttons
                    btnSubmitProject.Enabled = false;
                    BtnUpdateProgress.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to submit project: {ex.Message}", "Error");
                }
            }
        }

        private async void BtnUpdateProgress_Click(object sender, EventArgs e)
        {
            try
            {
                // Use PatchAsync to update only the 'Progress' field in the database
                await _authenticatedClient
                    .Child("projects")
                    .Child(_project.ProjectID)
                    .PatchAsync(new { Progress = _progress });

                // Update the original project object so the UI is consistent if they re-open it
                _project.Progress = _progress;

                MessageBox.Show("Progress updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to update progress: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Revert the local change if the database update fails
                lblProgressPercentage.Text = _project.Progress.ToString() + "%";
                _progress = _project.Progress;
            }
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
            _progress = Math.Min(100, _progress + 5); // Ensure it doesn't exceed 100
            lblProgressPercentage.Text = _progress.ToString() + "%";
        }

        private void Subtract5percenttoProgress_Click(object sender, EventArgs e)
        {
            if ( _progress <= 0 ) return;
            _progress = Math.Max(0, _progress - 5); // Ensure it doesn't go below 0
            lblProgressPercentage.Text = _progress.ToString() + "%";
        }
    }
}
