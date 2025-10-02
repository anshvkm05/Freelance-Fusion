using Firebase.Database;
using Firebase.Database.Query;
using Freelance_Fusion.AllProjectsUCandForm;
using Freelance_Fusion.CardsForClientDashboards;
using Freelance_Fusion.CardsForDashboards;
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
    public partial class ClientDashboard : UserControl
    {
        private readonly FirebaseClient _authenticatedClient;
        private readonly string _uid;
        private int _scrollAmount = 0;
        public event EventHandler<OnboardingEventArgs> AddProjectClicked;
        public ClientDashboard(FirebaseClient authenticatedClient, string uid)
        {
            InitializeComponent();
            _authenticatedClient = authenticatedClient;
            _uid = uid;
        }

        private void AddProject_Click(object sender, EventArgs e)
        {
            AddProjectClicked?.Invoke(this, new OnboardingEventArgs(_authenticatedClient, _uid));
        }

        private async Task LoadOngoingProjects()
        {
            try
            {
                flpOngoingProjects.Controls.Clear();

                // 1. Fetch the list of Project IDs from the current user's profile.
                // This is a very small and fast query that only gets the keys.
                var projectIdsSnapshot = await _authenticatedClient
                    .Child("users")
                    .Child(_uid)
                    .Child("postedProjects")
                    .OnceAsync<bool>(); // We don't care about the value, just the key

                // If the user has not posted any projects, the node will be null or empty.
                if (projectIdsSnapshot == null || !projectIdsSnapshot.Any())
                {
                    // Optionally, display a message or an "Add Project" prompt in the panel.
                    return;
                }

                var projectIds = projectIdsSnapshot.Select(p => p.Key).ToList();

                // 2. Create a list of tasks to fetch the full details for each project in parallel.
                var projectFetchTasks = projectIds.Select(projectId =>
                    _authenticatedClient
                       .Child("projects")
                       .Child(projectId)
                       .OnceSingleAsync<ProjectClient>()
                ).ToList();

                // 3. Wait for all the individual project fetches to complete.
                var projects = await Task.WhenAll(projectFetchTasks);

                // 4. Now that all data is fetched, create and add the cards.
                foreach (var project in projects.Where(p => p != null))
                {
                    OnGoingProjectCard card = new OnGoingProjectCard();
                    card.Populate(project);
                    card.CardClicked += OnProjectCard_Clicked;
                    flpOngoingProjects.Controls.Add(card);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load projects: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void OnProjectCard_Clicked(object sender, ProjectEventArgs e)
        {
            if (e.Project == null)
            {
                MessageBox.Show("Cannot open details: project data is missing.", "Error");
                return;
            }
            ProjectDetailUC detailUC = new ProjectDetailUC(_authenticatedClient, e.Project);
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

            panel.Controls.Add(detailUC);
            detailForm.ShowDialog();
        }
        private void ScrollOPBtn2_MouseDown(object sender, MouseEventArgs e)
        {
            var button = sender as Control;
            _scrollAmount = (button.Name == "btnScrollRight") ? 15 : -15;
            ScrollTimer.Start();
        }

        private void ScrollOPBtn2_MouseUp(object sender, MouseEventArgs e)
        {
            ScrollTimer.Stop();
        }

        private void ScrollTimer_Tick(object sender, EventArgs e)
        {
            int newPosition = flpOngoingProjects.AutoScrollPosition.X + _scrollAmount;
            flpOngoingProjects.AutoScrollPosition = new Point(Math.Abs(newPosition), 0);
        }

        private async void ClientDashboard_Load(object sender, EventArgs e)
        {
            await LoadOngoingProjects();
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            ClientDashboard_Load(this, e);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Profile_Click(object sender, EventArgs e)
        {
        }
    }
}
