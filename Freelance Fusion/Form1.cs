using Firebase.Database;
using Firebase.Database.Query;
using Freelance_Fusion.Dashboards;
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
            la.singupbutton += ShowLoginRegisterOverlay;
        }

        private void OnLoginComplete_ShowDashboard(object sender, LoginCompleteEventArgs e)
        {
            // Read the UserType from the profile and load the correct dashboard.
            if (e.UserProfile.UserType == "Client")
            {
                ClientDashboard cd = new ClientDashboard(e.AuthenticatedClient, e.Uid);
                cd.AddProjectClicked += OnStartOnboarding_ShowQuestionnaire; // Reuse onboarding for adding projects
                LoadUC(cd);
            }
            else if (e.UserProfile.UserType == "Freelancer")
            {
                FreelancersDashboard fd = new FreelancersDashboard(e.AuthenticatedClient, e.Uid);
                LoadUC(fd);
            }
            else
            {
                // Fallback for safety, though it shouldn't be reached with a complete profile.
                MessageBox.Show("User role not determined. Please complete your profile.", "Profile Incomplete");
                OnStartOnboarding_ShowQuestionnaire(sender, new OnboardingEventArgs(e.AuthenticatedClient, e.Uid));
            }
        }
        private void OnStartOnboarding_ShowQuestionnaire(object sender, OnboardingEventArgs e)
        {
            // You can now create your FreelancerOrClientForm here,
            // passing it the authenticated client and UID to continue the onboarding flow.
            using (FreelancerOrClientForm choiceForm = new FreelancerOrClientForm(e.AuthenticatedClient, e.Uid))
            {
                // Subscribe to the events that come from the choice form
                choiceForm.FreelancerSelectedd += ShowFreelancerQuestionnaire;
                choiceForm.ClientSelectedd += ShowClientQuestionnaire;
                choiceForm.ShowDialog();
            }
        }
        private async void OnProfileSaved_FetchProfileAndShowDashboard(object sender, OnboardingEventArgs e)
        {
            try
            {
                // 1. After the profile is saved, we need to fetch the complete data.
                var userProfile = await e.AuthenticatedClient
                    .Child("users")
                    .Child(e.Uid)
                    .OnceSingleAsync<UserProfile>();

                // 2. Now that we have the complete profile, we can create the correct EventArgs.
                var loginArgs = new LoginCompleteEventArgs(e.AuthenticatedClient, e.Uid, userProfile);

                // 3. Finally, call the main dashboard logic with the correct data.
                OnLoginComplete_ShowDashboard(this, loginArgs);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load dashboard after saving profile: " + ex.Message);
            }
        }
        private void ShowFreelancerQuestionnaire(object sender, OnboardingEventArgs e)
        {
            Freelancer_questionaries fq = new Freelancer_questionaries(e.AuthenticatedClient, e.Uid);
            fq.ProfileSaved += OnProfileSaved_FetchProfileAndShowDashboard; // After saving, go to dashboard
            LoadUC(fq);
        }

        private void ShowClientQuestionnaire(object sender, OnboardingEventArgs e)
        {
            ClientQuestionaries cq = new ClientQuestionaries(e.AuthenticatedClient, e.Uid);
            cq.ProfileSaved += OnProfileSaved_FetchProfileAndShowDashboard; // After saving, go to dashboard
            LoadUC(cq);
        }
        public void ShowLoginRegisterOverlay(object sender, EventArgs e)
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
                lr.LoginComplete += OnLoginComplete_ShowDashboard;
                lr.StartOnboarding += OnStartOnboarding_ShowQuestionnaire;
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
