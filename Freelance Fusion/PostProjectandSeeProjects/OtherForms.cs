using Firebase.Database;
using Freelance_Fusion.Dashboards;
using Freelance_Fusion.Events;
using Freelance_Fusion.FreelancerClientDetailsEnter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Freelance_Fusion.PostProjectandSeeProjects
{
    public partial class OtherForms : Form
    {
        private readonly FirebaseClient _authenticatedClient;
        private readonly string _uid;
        public OtherForms(FirebaseClient authenticatedClient, string uid)
        {
            InitializeComponent();
            _authenticatedClient = authenticatedClient;
            _uid = uid;
        }
        private void LoadUC(UserControl usercontrol)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(usercontrol);

        }
        private void OtherForms_Load(object sender, EventArgs e)
        {
            ClientDashboard CD = new ClientDashboard(_authenticatedClient, _uid);
            CD.AddProjectClicked += ShowAddProjectUC;
            ShowAddProjectUC(this, new OnboardingEventArgs(_authenticatedClient, _uid));
        }
        private void ShowAddProjectUC(object sender, OnboardingEventArgs e)
        {
            AddProjectClient AP = new AddProjectClient(e.AuthenticatedClient, e.Uid);
            LoadUC(AP);
        }
    }
}
