using Firebase.Auth;
using Firebase.Auth.Providers;
using Firebase.Database;
using Firebase.Database.Query;
using Freelance_Fusion.FreelancerClientDetailsEnter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Freelance_Fusion.LoginUsercontorls
{
    public partial class Register : UserControl
    {
        string email;
        string password;
        string confirmPassword;

        // --- CORRECTED HERE: Removed the hidden '\r\n' characters from all strings ---
        private const string FirebaseApiKey = "AIzaSyB0JEuC9PiZle1u7yk2HoyIPNCcUllZjNY"; // Paste your key here
        private const string FirebaseAuthDomain = "freelancefusion-30sep.firebaseapp.com"; // Get this from Firebase Auth settings
        private const string FirebaseDatabaseUrl = "https://freelancefusion-30sep-default-rtdb.firebaseio.com/"; // From Realtime Database

        // --- CORRECTED HERE: The main client object for authentication ---
        private readonly FirebaseAuthClient authClient;
        private readonly FirebaseClient firebaseClient = new FirebaseClient("https://freelancefusion-30sep-default-rtdb.firebaseio.com/");
        public Register()
        {
            InitializeComponent();
            // --- CORRECTED HERE: Use 'FirebaseAuthConfig' and 'FirebaseAuthClient' ---
            var config = new FirebaseAuthConfig
            {
                ApiKey = FirebaseApiKey,
                AuthDomain = FirebaseAuthDomain,
                // The library automatically finds the right providers
                Providers = new FirebaseAuthProvider[]
                {
                    // Add more providers here if you need them
                    new EmailProvider()
                }
            };

            authClient = new FirebaseAuthClient(config);
            firebaseClient = new FirebaseClient(FirebaseDatabaseUrl);
        }
        public event EventHandler SigninbtnClick;

        private void SinginBtn_Click(object sender, EventArgs e)
        {
            SigninbtnClick?.Invoke(this, EventArgs.Empty);
        }
        private bool IsValidEmail(string email)
        {
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }
        private async void RegisterUser_Click(object sender, EventArgs e)
        {
            RegisterUser.Enabled = false; // Disable the button to prevent multiple clicks
            email = EmailTB.Text.Trim();
            password = PassowordTB.Text;
            confirmPassword = RePasswordTB.Text;

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both email and password.");
                return;
            }

            if (!IsValidEmail(email))
            {
                MessageBox.Show("Please enter a valid email address.");
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }

            try
            {
                var authCredential = await authClient.CreateUserWithEmailAndPasswordAsync(email, password);
                string uid = authCredential.User.Uid;
                string token = await authCredential.User.GetIdTokenAsync();

                var authenticatedFirebaseClient = new FirebaseClient(
                    FirebaseDatabaseUrl,
                    new FirebaseOptions { AuthTokenAsyncFactory = () => Task.FromResult(token) }
                );

                var newUserProfile = new UserProfile
                {
                    Email = email,
                    UserType = "Not Set",
                    IsProfileComplete = false
                };

                // --- THE CRITICAL FIX ---
                // We are already authenticated to the root of the database.
                // We only need to specify the path FROM THE ROOT where we want to write.
                // The correct path is "users/{uid}".
                await authenticatedFirebaseClient
                    .Child("users")      // Go to the "users" collection
                    .Child(uid)          // Create a node with the user's unique ID
                    .PutAsync(newUserProfile); // Save the profile object there

                MessageBox.Show("Registration Successful! You can now sign in.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SigninbtnClick?.Invoke(this, EventArgs.Empty);
            }
            catch (FirebaseAuthException ex)
            {
                RegisterUser.Enabled = true; // Disable the button to prevent multiple clicks
                MessageBox.Show($"Registration Failed: {ex.Reason}", "Authentication Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                RegisterUser.Enabled = true; // Disable the button to prevent multiple clicks
                string errorMessage = ex.InnerException?.Message ?? ex.Message;
                MessageBox.Show($"An unexpected error occurred: {errorMessage}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PassowordTB_TextChanged(object sender, EventArgs e)
        {
            string password = PassowordTB.Text;

            // Check for at least one uppercase letter
            if (Regex.IsMatch(password, @"[A-Z]"))
                lblCapital.ForeColor = Color.Green;
            else
                lblCapital.ForeColor = Color.Red;

            // Check for at least 8 characters
            if (password.Length >= 8)
                lbl8char.ForeColor = Color.Green;
            else
                lbl8char.ForeColor = Color.Red;

            // Check for at least one digit
            if (Regex.IsMatch(password, @"\d"))
                lblDigit.ForeColor = Color.Green;
            else
                lblDigit.ForeColor = Color.Red;
        }
        private void PassowordTB_Enter(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }
        private void PassowordTB_Leave(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void RePasswordTB_Leave(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void EmailTB_Leave(object sender, EventArgs e)
        {
            string email = EmailTB.Text.Trim();
            if (!IsValidEmail(email))
            {
                lblInvalidEmail.Visible = true;
                return;
            }
            else
            {
                lblInvalidEmail.Visible = false;
            }
        }

        private void RePasswordTB_TextChanged(object sender, EventArgs e)
        {
            password = PassowordTB.Text;
            confirmPassword = RePasswordTB.Text;
            if (password != confirmPassword)
            {
                lblPasswordNotSame.Visible = true;
                return;
            }
            else
            {
                lblPasswordNotSame.Visible = false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
