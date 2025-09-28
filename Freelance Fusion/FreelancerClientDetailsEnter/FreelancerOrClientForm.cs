using Firebase.Database;
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
    public partial class FreelancerOrClientForm : Form
    {
        private FirebaseClient _authenticatedClient;
        private string _uid;
        public event EventHandler<OnboardingEventArgs> FreelancerSelectedd;
        public event EventHandler<OnboardingEventArgs> ClientSelectedd;
        public FreelancerOrClientForm(FirebaseClient authenticatedClient, string uid)
        {
            InitializeComponent();
            _authenticatedClient = authenticatedClient;
            _uid = uid;
        }
        public void OpenFreelancerOrClientForm()
        {
            ClientOrFreelancer cf  = new ClientOrFreelancer(_authenticatedClient, _uid);
            LoadUC(cf);
            cf.FreelancerSelected += ShowFreelancerQuestionaries;
            cf.ClientSelected += ShowClientQuestionaries;
        }
        private void LoadUC(UserControl usercontrol)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(usercontrol);
        }
        private void ShowFreelancerQuestionaries(object sender, EventArgs e)
        {
            FreelancerSelectedd?.Invoke(this, new OnboardingEventArgs(_authenticatedClient, _uid));
            this.Close();
        }

        private void ShowClientQuestionaries(object sender, EventArgs e)
        {
            ClientSelectedd?.Invoke(this, new OnboardingEventArgs(_authenticatedClient, _uid));
            this.Close();
        }

        private void FreelancerOrClientForm_Load(object sender, EventArgs e)
        {
            OpenFreelancerOrClientForm();
        }
    }
}
