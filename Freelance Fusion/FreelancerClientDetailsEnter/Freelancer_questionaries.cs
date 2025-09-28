using Firebase.Database;
using Firebase.Database.Query;
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
    public partial class Freelancer_questionaries : UserControl
    {
        private readonly FirebaseClient _authenticatedClient;
        private readonly string _uid;
        public event EventHandler<OnboardingEventArgs> ClientSelectedFQ;

        // --- Event to signal that the profile has been saved ---
        public event EventHandler<OnboardingEventArgs> ProfileSaved;

        // --- THE FIX: A new constructor that accepts the required data ---
        public Freelancer_questionaries(FirebaseClient authenticatedClient, string uid)
        {
            InitializeComponent();
            _authenticatedClient = authenticatedClient;
            _uid = uid;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void EmailTB_TextChanged(object sender, EventArgs e)
        {

        }

        private async void Submit_Done_Click(object sender, EventArgs e)
        {
            try
            {
                var profileData = new Dictionary<string, object>
                {
                    // The vlaues are preset for testing pusposes, it will get Replace with respective testboxes values
                    ["ContactEmail"] = "user@example.com", // Get from form
                    ["UserType"] = "Freelancer", // Replace with EmailTB.Text
                    ["IsProfileComplete"] = true, // Set to true after submission
                    ["FirstName"] = "Ansh",
                    ["LastName"] = "Maurya",
                    ["Gender"] = "Male",
                    ["Age"] = int.Parse("12"),
                    ["PhoneNumber"] = "8356824894",
                    ["KeywordSkills"] = new List<string> { "Skill1", "Skill2" }, // Get from form
                    ["DetailedSkills"] = new List<string> { "Detail1", "Detail2" }, // Get from form
                    ["Education"] = "BSC",
                    ["ShortBio"] = "I am a freelacner helping people with their projects",
                    ["LongBio"] = "A freelancer working with clients to complete there project with the best accracy ",
                    ["ProjectLinks"] = new List<string> { "https://youtube.com" } // Get from form
                };

                // 3. Use the authenticated client to save the completed profile to the database
                await _authenticatedClient
                    .Child("users")
                    .Child(_uid)
                    .PutAsync(profileData);

                MessageBox.Show("Profile saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 4. Signal to the parent form that the process is complete
                ProfileSaved?.Invoke(this, new OnboardingEventArgs(_authenticatedClient, _uid));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving your profile: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClientBtn_Click(object sender, EventArgs e)
        {
            ClientSelectedFQ?.Invoke(this, new OnboardingEventArgs(_authenticatedClient, _uid));
        }
    }
}
