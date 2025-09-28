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
        public event EventHandler<OnboardingEventArgs> LoadMainForm;
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

                // 👇 Create the FirebaseClient (this line might be the issue)
                _authenticatedClient = new FirebaseClient(
                    FirebaseDatabaseUrl, // Make sure this constant is clean
                    new FirebaseOptions { AuthTokenAsyncFactory = () => Task.FromResult(token) }
                );

                // 👇 Try a simple connection first - just ping the root
                Dictionary<string, object> userProfileData = await _authenticatedClient
                                                            .Child("users")
                                                            .Child(_uid)
                                                            .OnceSingleAsync<Dictionary<string, object>>();

                // Continue with the rest of the logic...
                if (userProfileData == null)
                {
                    MessageBox.Show("User profile not found. Please ensure your profile is set up.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // Optionally, you might direct them to complete their profile here
                    LoadFreelancerQuestionaries?.Invoke(this, new OnboardingEventArgs(_authenticatedClient, _uid));
                    this.Close();
                    return;
                }
                var isProfileCompleteKey = userProfileData.Keys
                                     .FirstOrDefault(k => k.Equals("IsProfileComplete", StringComparison.OrdinalIgnoreCase));

                bool isProfileComplete = false;
                if (isProfileCompleteKey != null)
                {
                    if (userProfileData.TryGetValue(isProfileCompleteKey, out object profileCompleteValue))
                    {
                        try
                        {
                            // Attempt to convert the value to boolean
                            isProfileComplete = Convert.ToBoolean(profileCompleteValue);
                        }
                        catch (Exception ex)
                        {
                            // Handle cases where the data might be stored in a non-boolean format
                            MessageBox.Show($"Warning: 'IsProfileComplete' for user {_uid} has an invalid format. Error: {ex.Message}. Defaulting to false.", "Data Issue", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            isProfileComplete = false;
                        }
                    }
                }
                if (isProfileComplete)
                {
                    LoadMainForm?.Invoke(this, new OnboardingEventArgs(_authenticatedClient, _uid));
                    this.Close();
                }
                else
                {
                    LoadFreelancerQuestionaries?.Invoke(this, new OnboardingEventArgs(_authenticatedClient, _uid));
                    this.Close();
                }

                this.Close();

                // Close this login form

            }
            catch (Exception ex)
            {
                string errorMessage = ex.InnerException?.Message ?? ex.Message;
                MessageBox.Show("An error occurred during login: " + errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
