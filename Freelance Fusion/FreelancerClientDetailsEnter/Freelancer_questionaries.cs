using Firebase.Database;
using Firebase.Database.Query;
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

        // --- Event to signal that the profile has been saved ---
        public event EventHandler ProfileSaved;

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
                // 1. Gather all the data from your textboxes, radio buttons, etc.
                //  (Assuming you have controls named like FirstNameTB, LastNameTB, etc.)
                var profile = new UserProfile
                {
                    FirstName = FirstNameTB.Text, // Replace with FirstNameTB.Text
                    LastName = "Maurya", // Replace with LastNameTB.Text
                    Gender = "Male", // Get from radio buttons
                    Age = 20, // Replace with int.Parse(AgeTB.Text)
                    Email = "ansh@example.com", // Replace with EmailTB.Text
                    PhoneNumber = "1234567890", // Replace with PhoneTB.Text
                    KeywordSkills = "C#, .NET, Firebase".Split(',').Select(s => s.Trim()).ToList(),
                    DetailedSkills = "Building awesome apps".Split('\n').ToList(),
                    Education = "Computer Science", // Replace with EducationTB.Text
                    ShortBio = "A passionate developer.", // Replace with ShortBioTB.Text
                    LongBio = "A very passionate developer.", // Replace with LongBioTB.Text
                    ProjectLinks = "https://github.com".Split('\n').ToList(),

                    // 2. Set the critical fields to complete the onboarding
                    UserType = "Freelancer",
                    IsProfileComplete = true
                };

                // 3. Use the authenticated client to save the completed profile to the database
                await _authenticatedClient
                    .Child("users")
                    .Child(_uid)
                    .PutAsync(profile);

                MessageBox.Show("Profile saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 4. Signal to the parent form that the process is complete
                ProfileSaved?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving your profile: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
