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

    public partial class ClientQuestionaries : UserControl
    {
        public event EventHandler<OnboardingEventArgs> FreelancerSelectedCQ;
        private readonly FirebaseClient _authenticatedClient;
        private readonly string _uid;
        public event EventHandler<OnboardingEventArgs> ProfileSaved;
        private string firstName;
        private string lastName;
        public ClientQuestionaries(FirebaseClient authenticatedClient, string uid)
        {
            InitializeComponent();
            _authenticatedClient = authenticatedClient;
            _uid = uid;
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void FreelancerBtn_Click(object sender, EventArgs e)
        {
            FreelancerSelectedCQ?.Invoke(this, new OnboardingEventArgs(_authenticatedClient, _uid));
        }

        private async void Submit_Done_Click(object sender, EventArgs e)
        {
            Submit_Done.Enabled = false; // Prevent multiple submissions
            if (FirstNameTB.Text == "")
            {
                firstName = "ClientAnsh";
            }
            else
            {
                firstName = FirstNameTB.Text;
            }
            if (LastNameTB.Text == "")
            {
                lastName = "Maurya";
            }
            else
            {
                lastName = LastNameTB.Text;
            }
            try
            {
                var profileData = new Dictionary<string, object>
                {
                    // Replace with int.Parse(AgeTB.Text)
                    ["ContactEmail"] = "Clientuser@example.com", // Get from form
                    ["UserType"] = "Client", // Replace with EmailTB.Text
                    ["IsProfileComplete"] = true, // Set to true after submission
                    ["FirstName"] = firstName,
                    ["LastName"] = lastName,
                    ["Gender"] = "Male",
                    ["Age"] = int.Parse("34"),
                    ["PhoneNumber"] = "8356824894",
                    ["Companyname"] = "Google",
                    ["CompanyURL"] = "google.com",
                    ["Country"] = "India",
                    ["State"] = "Maharashtra",
                    ["Industry"] = "ITcommerce",

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
                Submit_Done.Enabled = true; // Re-enable the button on error
                MessageBox.Show($"An error occurred while saving your profile: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
