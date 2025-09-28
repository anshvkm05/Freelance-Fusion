using Firebase.Database;
using Firebase.Database.Query;
using Freelance_Fusion.Events;
using Freelance_Fusion.FreelancerClientDetailsEnter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Freelance_Fusion
{
    public partial class Form1 : Form
    {
        private readonly FirebaseClient firebaseClient = new FirebaseClient("https://freelancefusion-30sep-default-rtdb.firebaseio.com/");
        private FirebaseClient _firebaseClient;
        private string _uid;
        private FirebaseClient _authenticatedClient;
        public Form1()
        {
            InitializeComponent();
        }
        private void uidandAuthenticatedClient(object sender, OnboardingEventArgs e)
        {
            _authenticatedClient = e.AuthenticatedClient;
            _uid = e.Uid;
        }
        private void ShowFLQuestionariesUC(object sender, OnboardingEventArgs e)
        {
            Freelancer_questionaries FQ = new Freelancer_questionaries(e.AuthenticatedClient, e.Uid);
            FQ.ProfileSaved += ShowMainDashboard;
            LoadUC(FQ);
            uidandAuthenticatedClient(this, e);
            ShowFormasOverlayFlCt();
        }

        private void ShowFLrQuestionariesUC(object sender, OnboardingEventArgs e)
        {
            Freelancer_questionaries FQ = new Freelancer_questionaries(_authenticatedClient, _uid);
            FQ.ProfileSaved += ShowMainDashboard;
            FQ.ClientSelectedFQ += ShowClientQuestionariesUC;
            LoadUC(FQ);
        }
        private void ShowClientQuestionariesUC(object sender, OnboardingEventArgs e)
        {
            ClientQuestionaries CQ = new ClientQuestionaries(e.AuthenticatedClient, e.Uid);
            CQ.ProfileSaved += ShowClientDashboard;
            CQ.FreelancerSelectedCQ += ShowFLrQuestionariesUC;
            LoadUC(CQ);
        }

        private void ShowMainDashboard(object sender, OnboardingEventArgs e)
        {
            Dashboards.FreelancersDashboard FD = new Dashboards.FreelancersDashboard(e.AuthenticatedClient, e.Uid);
            LoadUC(FD);           
        }
        private void ShowClientDashboard(object sender, OnboardingEventArgs e)
        {
            Dashboards.ClientDashboard CD = new Dashboards.ClientDashboard(e.AuthenticatedClient, e.Uid);
            CD.AddProjectClicked += ShowAddProjectUC;
            LoadUC(CD);
        }

        private void ShowAddProjectUC(object sender, OnboardingEventArgs e)
        {
            PostProjectandSeeProjects.OtherForms AP = new PostProjectandSeeProjects.OtherForms(e.AuthenticatedClient, e.Uid);
            AP.Show();
        }
        private void LoadUC(UserControl usercontrol)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(usercontrol); 
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            landingApplication la = new landingApplication();
            LoadUC(la);
            la.singupbutton += ShowFormasOverlay;
        }
        public void ShowFormasOverlay(object sender, EventArgs e)
        {
            Form overlayform = new Form();
            overlayform.StartPosition = FormStartPosition.Manual;
            overlayform.Opacity = 0.60;
            overlayform.BackColor = Color.Black;
            overlayform.ShowInTaskbar = false;
            overlayform.Size = this.Size;
            overlayform.Location = this.Location;

            using (LoginRegister lr = new LoginRegister())
            {
                lr.LoadMainForm += ShowClientDashboard;
                lr.LoadFreelancerQuestionaries += ShowFLQuestionariesUC;
                overlayform.Show();
                lr.Owner = overlayform;
                lr.ShowDialog();
                
            }
            overlayform.Close();
        }
        public void ShowFormasOverlayFlCt()
        {
            Form overlayform = new Form();
            overlayform.StartPosition = FormStartPosition.Manual;
            overlayform.Opacity = 0.60;
            overlayform.BackColor = Color.Black;
            overlayform.ShowInTaskbar = false;
            overlayform.Size = this.Size;
            overlayform.Location = this.Location;

            using (FreelancerClientDetailsEnter.FreelancerOrClientForm lrf = new FreelancerClientDetailsEnter.FreelancerOrClientForm(_authenticatedClient, _uid))
            {
                // Use lambda to match EventHandler signature
                lrf.ClientSelectedd += ShowClientQuestionariesUC;
                lrf.FreelancerSelectedd += ShowFLrQuestionariesUC;
                overlayform.Show();
                lrf.Owner = overlayform;
                lrf.ShowDialog();
            }
            overlayform.Close();
        }

    }
}
