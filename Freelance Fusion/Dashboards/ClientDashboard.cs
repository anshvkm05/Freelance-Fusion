using Firebase.Database;
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
                // 1. Fetch all projects from the 'projects' node
                var allProjects = await _authenticatedClient
                    .Child("projects")
                    .OnceAsync<CardsForClientDashboards.ProjectClient>();

                // 2. Filter the projects to show only those posted by the current client
                var myProjects = allProjects
                    .Where(p => p.Object.ClientID == _uid)
                    .ToList();

                // 3. Clear any existing cards
                flpOngoingProjects.Controls.Clear();

                // 4. Create and populate a card for each project
                foreach (var project in myProjects)
                {
                    OnGoingProjectCard card = new OnGoingProjectCard();
                    card.Populate(project.Object);
                    flpOngoingProjects.Controls.Add(card);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load projects: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
    }
}
