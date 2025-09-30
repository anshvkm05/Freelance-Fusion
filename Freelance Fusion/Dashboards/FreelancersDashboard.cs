using Firebase.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Freelance_Fusion.Dashboards
{
    public partial class FreelancersDashboard : UserControl
    {
        private readonly FirebaseClient _authenticatedClient;
        private readonly string _uid;
        public FreelancersDashboard(FirebaseClient authenticatedClient, string uid)
        {
            InitializeComponent();
            _authenticatedClient = authenticatedClient;
            _uid = uid;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
