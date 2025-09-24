using Firebase.Database;
using Firebase.Database.Query;
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
        public Form1()
        {
            InitializeComponent();
        }
        private void ShowLoginControl()
        {
            LoginUsercontorls.Login lg = new LoginUsercontorls.Login();
            lg.LoginSuccessful += LoginControl_LoginSuccessful;
        }

        private async void LoginControl_LoginSuccessful(object sender, LoginUsercontorls.LoginEventArgs e)
        {
            // The UID is the unique key for the user in the database.
            string uid = e.User.LocalId;

            // Check Firebase to see if the user's profile exists and is complete.
            var userProfile = await firebaseClient
                .Child("users") // This is the top-level collection for all users
                .Child(uid)     // Get the specific user by their ID
                .OnceSingleAsync<UserProfile>();

            // If the profile doesn't exist or is marked as incomplete...
            if (userProfile == null || !userProfile.IsProfileComplete)
            {
                // ...start the onboarding process.
                ShowUserTypeSelection(uid, e.User.Email);
            }
            else
            {
                // The user's profile is complete, so show the main dashboard.
                //ShowDashboard();
            }
        }

        private void ShowUserTypeSelection(string uid, string email)
        {
            using (ClientOrFreelancer choiceform = new ClientOrFreelancer())
            {
                string userType = choiceform.SelectedUserType;
                if (userType == "Freelancer")
                {
                    Freelancer_questionaries fq = new Freelancer_questionaries();
                    LoadUC(fq);
                }
                else if (userType == "Client")
                {
                    ClientQuestionaries cq = new ClientQuestionaries();
                    LoadUC(cq);
                }
            }

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
                overlayform.Show();
                lr.Owner = overlayform;

                lr.ShowDialog();
            }

            overlayform.Close();
        }

    }
}
