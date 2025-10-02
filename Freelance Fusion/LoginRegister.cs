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
        private const string FirebaseDatabaseUrl = "https://freelancefusion-30sep-default-rtdb.firebaseio.com/";
        private FirebaseClient _authenticatedClient;
        private string _uid;
        public event EventHandler<LoginCompleteEventArgs> LoginComplete;
        public event EventHandler<OnboardingEventArgs> StartOnboarding;
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

                // Fetch the user's profile directly as a UserProfile object.
                var userProfile = await _authenticatedClient
                    .Child("users")
                    .Child(_uid)
                    .OnceSingleAsync<UserProfile>();

                // If profile is complete, signal the main form to load the correct dashboard.
                if (userProfile != null && userProfile.IsProfileComplete)
                {
                    LoginComplete?.Invoke(this, new LoginCompleteEventArgs(_authenticatedClient, _uid, userProfile));
                    this.Close();
                }
                else // Otherwise, start the onboarding process.
                {
                    StartOnboarding?.Invoke(this, new OnboardingEventArgs(_authenticatedClient, _uid));
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
            ClientOrFreelancer clientOrFreelancer = new ClientOrFreelancer(_authenticatedClient, _uid); // No longer needs parameters
            LoadUC(clientOrFreelancer);

            clientOrFreelancer.FreelancerSelected += OnFreelancerSelected;
            //clientOrFreelancer.ClientSelected += OnClientSelected; // You would add this for the client flow
        }
        private void LoginRegister_Load(object sender, EventArgs e)
        {
            ShowLoginForm();
        }
        private void ShowLoginForm(object sender = null, EventArgs e = null)
        {
            Login lg = new Login();
            lg.SignupbtnClick += ShowSignupForm;
            lg.LoginSuccessful += LoginControl_LoginSuccessful;
            LoadUC(lg);
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
            this.Close();
        }
    }
}
