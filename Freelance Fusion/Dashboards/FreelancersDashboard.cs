using Firebase.Database;
using Firebase.Database.Query;
using Freelance_Fusion.AllProjectsUCandForm;
using Freelance_Fusion.AllProjectsUCandForm.Freelancer;
using Freelance_Fusion.CardsForClientDashboards;
using Freelance_Fusion.CardsForDashboards;
using Freelance_Fusion.CardsForFreelancerDashboard;
using Freelance_Fusion.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Freelance_Fusion.Dashboards
{
    public partial class FreelancersDashboard : UserControl
    {
        private readonly FirebaseClient _authenticatedClient;
        private readonly string _uid;
        private int _scrollAmount = 0;
        private int _ongoingScrollAmount = 0;
        public FreelancersDashboard(FirebaseClient authenticatedClient, string uid)
        {
            InitializeComponent();
            _authenticatedClient = authenticatedClient;
            _uid = uid;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void OnGoingProjectCard_Clicked(object sender, ProjectEventArgs e)
        {
            if (e.Project == null)
            {
                MessageBox.Show("Cannot open details: project data is missing.", "Error");
                return;
            }
            OnGoingProjectDetailUC Ongoingprojectdetailuc = new OnGoingProjectDetailUC(_authenticatedClient, _uid, e.Project);
            Panel panel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                AutoScroll = true,
                AutoSize = false
            };
            Form detailForm = new Form
            {
                Text = "Project Details",
                Size = new Size(1370, 937),
                StartPosition = FormStartPosition.CenterParent,
                BackColor = Color.White,
                FormBorderStyle = FormBorderStyle.FixedToolWindow,
                MaximizeBox = false,
                MinimizeBox = false
            };
            detailForm.Controls.Add(panel);
            panel.Dock = DockStyle.Fill;

            panel.Controls.Add(Ongoingprojectdetailuc);
            detailForm.ShowDialog();
        }
        private async Task LoadRecommendedProjects()
        {
            try
            {
                // 1. Fetch only projects where the "Status" field is equal to "Open".
                // This is a server-side query and is highly efficient.
                var openProjects = await _authenticatedClient
                    .Child("projects")
                    .OrderBy("Status")
                    .EqualTo("Open")
                    .OnceAsync<ProjectClient>();

                if (openProjects == null || !openProjects.Any())
                {
                    flpRecommendedProjects.Controls.Clear(); // Clear if no projects are found
                    return;
                }

                flpRecommendedProjects.Controls.Clear();
                foreach (var project in openProjects)
                {
                    if (project.Object != null)
                    {
                        RecommendedProjectCard card = new RecommendedProjectCard();
                        card.Populate(project.Object);

                        card.CardClicked += OnRecommendedProjectCard_Clicked;
                        card.WireClickEvents(); // Ensure clicks are registered
                        flpRecommendedProjects.Controls.Add(card);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load recommended projects: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadOngoingProjects()
        {
            try
            {
                flpOngoingProjects.Controls.Clear();

                // 1. Fetch the list of Project IDs from the current freelancer's 'ongoingProjects' node.
                var projectIdsSnapshot = await _authenticatedClient
                    .Child("users")
                    .Child(_uid)
                    .Child("ongoingProjects")
                    .OnceAsync<bool>();

                if (projectIdsSnapshot == null || !projectIdsSnapshot.Any()) return;

                var projectIds = projectIdsSnapshot.Select(p => p.Key).ToList();

                // 2. Fetch the full details for each of those projects in parallel.
                var projectFetchTasks = projectIds.Select(projectId =>
                    _authenticatedClient
                        .Child("projects")
                        .Child(projectId)
                        .OnceSingleAsync<ProjectClient>()
                ).ToList();

                var projects = await Task.WhenAll(projectFetchTasks);

                // 3. Create and add the cards to the 'flpOngoingProjects' panel.
                // We are reusing the same card from the client's dashboard.
                foreach (var project in projects.Where(p => p != null))
                {
                    OnGoingProjectCard card = new OnGoingProjectCard();
                    card.Populate(project);
                    card.CardClicked += OnGoingProjectCard_Clicked; // Reuse the same click handler
                    flpOngoingProjects.Controls.Add(card);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load ongoing projects: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void OnRecommendedProjectCard_Clicked(object sender, ProjectEventArgs e)
        {
            ProjectDetail_Bidding details_biddingUC = new ProjectDetail_Bidding(_authenticatedClient, _uid, e.Project);
            Panel panel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                AutoScroll = true,
                AutoSize = false
            };
            Form detailForm = new Form
            {
                Text = "Project Details",
                Size = new Size(1370, 937),
                StartPosition = FormStartPosition.CenterParent,
                BackColor = Color.White,
                FormBorderStyle = FormBorderStyle.FixedToolWindow,
                MaximizeBox = false,
                MinimizeBox = false
            };
            detailForm.Controls.Add(panel);
            panel.Dock = DockStyle.Fill;
            panel.Controls.Add(details_biddingUC);
            detailForm.ShowDialog();
        }
        private async void FreelancersDashboard_Load(object sender, EventArgs e)
        {
            await Task.WhenAll(LoadRecommendedProjects(), LoadOngoingProjects());
        }

        private void btnRecScrollRight_MouseDown(object sender, MouseEventArgs e)
        {
            var button = sender as Control;
            // You can name your scroll buttons e.g., 'btnRecScrollRight' and 'btnRecScrollLeft'
            _scrollAmount = (button.Name.Contains("Right")) ? 15 : -15;
            scrollTimer.Start(); // Assuming you have a timer named scrollTimer
        }

        private void btnRecScrollRight_MouseUp(object sender, MouseEventArgs e)
        {
            scrollTimer.Stop();
        }

        private void scrollTimer_Tick(object sender, EventArgs e)
        {
            int newPosition = flpRecommendedProjects.AutoScrollPosition.X + _scrollAmount;
            flpRecommendedProjects.AutoScrollPosition = new Point(Math.Abs(newPosition), 0);
        }

        private void OngoingScroll_MouseDown(object sender, MouseEventArgs e)
        {
            var button = sender as Control;
            _ongoingScrollAmount = (button.Name.Contains("Right")) ? 15 : -15;
            ongoingScrollTimer.Start(); // Assuming a timer named 'ongoingScrollTimer'
        }

        private void OngoingScroll_MouseUp(object sender, MouseEventArgs e)
        {
            ongoingScrollTimer.Stop();
        }

        private void ongoingScrollTimer_Tick(object sender, EventArgs e)
        {
            int newPosition = flpOngoingProjects.AutoScrollPosition.X + _ongoingScrollAmount;
            flpOngoingProjects.AutoScrollPosition = new Point(Math.Abs(newPosition), 0);
        }
    }
}
