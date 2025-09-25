using Firebase.Database;
using Firebase.Database.Query;
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
        public Form1()
        {
            InitializeComponent();
        }
        private void ShowFLQuestionariesUC(object sender, OnboardingEventArgs e)
        {
            Freelancer_questionaries FQ = new Freelancer_questionaries(e.AuthenticatedClient, e.Uid);
            FQ.ProfileSaved += ShowMainDashboard;
            LoadUC(FQ);
        }

        private void ShowMainDashboard(object sender, EventArgs e)
        {
            Dashboards.FreelancersDashboard FD = new Dashboards.FreelancersDashboard();
            LoadUC(FD);           
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
                lr.LoadMainForm += ShowMainDashboard;
                lr.LoadFreelancerQuestionaries += ShowFLQuestionariesUC;
                overlayform.Show();
                lr.Owner = overlayform;
                lr.ShowDialog();
                
            }
            overlayform.Close();
        }

    }
}
