using Firebase.Auth;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Freelance_Fusion.LoginUsercontorls
{
    public partial class Login : UserControl
    {
        // --- These must be the SAME as in your Register.cs file ---
        private const string FirebaseApiKey = "AIzaSyB0JEuC9PiZle1u7yk2HoyIPNCcUllZjNY"; // Paste your key here
        private const string FirebaseAuthDomain = "freelancefusion-30sep.firebaseapp.com"; // Get this from Firebase Auth settings

        // --- The main client object for authentication ---
        private readonly FirebaseAuthClient authClient;

        // --- Events to communicate with the main form ---
        public event EventHandler SignupbtnClick;
        public event EventHandler LoginSuccessful; // Event to notify the form on successful login

        string email;
        string password;
        public Login()
        {
            InitializeComponent();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Singupbtn_Click(object sender, EventArgs e)
        {
            Singupbtn.FillColor = System.Drawing.Color.FromArgb(51, 43, 1);
            SinginBtn.FillColor = System.Drawing.Color.FromArgb(240, 240, 240);
            Singupbtn.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            SinginBtn.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);

            SignupbtnClick?.Invoke(this, EventArgs.Empty);
        }

        private void SinginBtn_Click(object sender, EventArgs e)
        {
            SinginBtn.FillColor = System.Drawing.Color.FromArgb(51, 43, 1);
            Singupbtn.FillColor = System.Drawing.Color.FromArgb(240, 240, 240);
            SinginBtn.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            Singupbtn.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
        }

        private async void loginbutton_Click(object sender, EventArgs e)
        {
            email = EmailTB.Text.Trim();
            password = PassowordTB.Text;

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both email and password.");
                return;
            }

            try
            {
                // --- THIS IS THE CORE FIREBASE LOGIN CALL ---
                // It sends the email and password to Firebase for verification.
                var userCredential = await authClient.SignInWithEmailAndPasswordAsync(email, password);

                // If the call above succeeds, the user is logged in.
                MessageBox.Show($"Welcome back!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // --- Notify the main form that login was a success ---
                LoginSuccessful?.Invoke(this, EventArgs.Empty);
            }
            catch (FirebaseAuthException ex)
            {
                // This will catch specific Firebase errors.
                // For example, if the reason is "WrongPassword" or "UserNotFound".
                MessageBox.Show($"Login Failed: {ex.Reason}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // This catches other general errors (e.g., no internet connection).
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
