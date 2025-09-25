using Firebase.Database;
using Firebase.Database.Query;
using Freelance_Fusion.Events;
using Freelance_Fusion.FreelancerClientDetailsEnter;
using Freelance_Fusion.LoginUsercontorls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Freelance_Fusion
{
    public partial class LoginRegister : Form
    {
        private readonly FirebaseClient firebaseClient = new FirebaseClient("https://freelancefusion-30sep-default-rtdb.firebaseio.com/");
        private const string FirebaseDatabaseUrl = "https://freelancefusion-30sep-default-rtdb.firebaseio.com/";
        private FirebaseClient _authenticatedClient;
        private string _uid;
        public event EventHandler LoadMainForm;
        public event EventHandler<OnboardingEventArgs> LoadFreelancerQuestionaries;
        public LoginRegister()
        {
            InitializeComponent();
        }
        private void LoadUC(UserControl usercontrol)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(usercontrol);
        }
        private async void LoginControl_LoginSuccessful(object sender, LoginEventArgs e)
        {
            try
            {
                _uid = e.User.Uid;
                string token = await e.User.GetIdTokenAsync();
                _authenticatedClient = new FirebaseClient(
                    "https://freelancefusion-30sep-default-rtdb.firebaseio.com/",
                    new FirebaseOptions { AuthTokenAsyncFactory = () => Task.FromResult(token) }
                );

                var userProfileData = await _authenticatedClient.Child("users").Child(_uid).OnceAsync<UserProfile>();
                var userProfile = userProfileData.FirstOrDefault()?.Object;

                if (userProfile == null || !userProfile.IsProfileComplete)
                {
                    // If profile is incomplete, show the role selection screen
                    ClientorfreelancerLoad();
                }
                else
                {
                    // Profile is complete, close and load the dashboard
                    LoadMainForm?.Invoke(this, EventArgs.Empty);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                string errorMessage = ex.InnerException?.Message ?? ex.Message;
                MessageBox.Show("An error occurred while checking your profile: " + errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClientorfreelancerLoad()
        {
            ClientOrFreelancer clientOrFreelancer = new ClientOrFreelancer(); // No longer needs parameters
            LoadUC(clientOrFreelancer);
            // The handler is now more specific
            clientOrFreelancer.FreelancerSelected += OnFreelancerSelected;
            // clientOrFreelancer.ClientSelected += OnClientSelected; // You would add this for the client flow
        }
        private void LoginRegister_Load(object sender, EventArgs e)
        {
            LoginUsercontorls.Login lg = new LoginUsercontorls.Login();
            lg.SignupbtnClick += ShowSignupForm; 
            LoadUC(lg);
            lg.LoginSuccessful += LoginControl_LoginSuccessful; // This event should tell you to close the login form and load the main dashboard.
        }
        private void ShowSignupForm(object sender, EventArgs e)
        {
            LoginUsercontorls.Register su = new LoginUsercontorls.Register();
            LoadUC(su);
            su.SigninbtnClick += LoginRegister_Load;
        }
        private void open_CLientorFreelaner(object sender, EventArgs e)
        {
        }
        private void OnFreelancerSelected(object sender, EventArgs e)
        {
            // Raise the event to tell Form1 to open the questionnaire, PASSING THE DATA.
            LoadFreelancerQuestionaries?.Invoke(this, new OnboardingEventArgs(_authenticatedClient, _uid));
            // Now, close this form.
            this.Close();
        }
    }
}
