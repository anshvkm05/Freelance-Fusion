using Firebase.Database;
using Freelance_Fusion.AllProjectsUCandForm;
using Freelance_Fusion.AllProjectsUCandForm.Freelancer;
using Freelance_Fusion.CardsForClientDashboards;
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
        public FreelancersDashboard(FirebaseClient authenticatedClient, string uid)
        {
            InitializeComponent();
            _authenticatedClient = authenticatedClient;
            _uid = uid;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private async Task LoadRecommendedProjects()
        {
            try
            {
                // 1. Fetch all projects from the top-level 'projects' node.
                // Your Firebase rules allow any authenticated user to read this list.
                var allProjects = await _authenticatedClient
                    .Child("projects")
                    .OnceAsync<ProjectClient>();

                // If there are no projects in the database, do nothing.
                if (allProjects == null || !allProjects.Any())
                {
                    return;
                }

                // 2. Clear any existing cards from the panel.
                flpRecommendedProjects.Controls.Clear();

                // 3. Create a card for each project and add it to the FlowLayoutPanel.
                foreach (var project in allProjects)
                {
                    // Make sure the project data is not null
                    if (project.Object != null)
                    {
                        RecommendedProjectCard card = new RecommendedProjectCard();
                        card.Populate(project.Object);
                        card.CardClicked += OnRecommendedProjectCard_Clicked;
                        flpRecommendedProjects.Controls.Add(card);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load recommended projects: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            await LoadRecommendedProjects();
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
    }
}
