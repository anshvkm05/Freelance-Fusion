using Firebase.Database;
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

namespace Freelance_Fusion.FreelancerClientDetailsEnter
{
    public partial class ClientOrFreelancer : UserControl
    {
        private FirebaseClient _authenticatedClient;
        private string _uid;
        // --- Private fields to store the essential data ---
        public event EventHandler<OnboardingEventArgs> FreelancerSelected;
        public event EventHandler<OnboardingEventArgs> ClientSelected;

        // --- THE FIX: A new constructor that accepts the required data ---
        public ClientOrFreelancer(FirebaseClient authenticatedClient, string uid)
        {
            InitializeComponent();
            _authenticatedClient = authenticatedClient;
            _uid = uid;
        }

        private void FreelancerPictureBox_Click(object sender, EventArgs e)
        {
            FreelancerSelected?.Invoke(this, new OnboardingEventArgs(_authenticatedClient, _uid));
            MessageBox.Show("Freelancer Selected");
        }

        private void ClientPictureBox_Click(object sender, EventArgs e)
        {
            ClientSelected?.Invoke(this, new OnboardingEventArgs(_authenticatedClient, _uid));
            MessageBox.Show("Client Selected");
        }
        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {
            FreelancerSelected?.Invoke(this, new OnboardingEventArgs(_authenticatedClient, _uid));
            MessageBox.Show("Freelancer Selected");
        }
        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            ClientSelected?.Invoke(this, new OnboardingEventArgs(_authenticatedClient, _uid));
            MessageBox.Show("Client Selected");
        }
    }
}
