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

namespace Freelance_Fusion.FreelancerClientDetailsEnter
{
    public partial class ClientOrFreelancer : UserControl
    {
        // --- Private fields to store the essential data ---
        public event EventHandler FreelancerSelected;
        public event EventHandler ClientSelected;

        // --- THE FIX: A new constructor that accepts the required data ---
        public ClientOrFreelancer()
        {
            InitializeComponent();
        }

        private void FreelancerPictureBox_Click(object sender, EventArgs e)
        {
            FreelancerSelected?.Invoke(this, EventArgs.Empty);
        }

        private void ClientPictureBox_Click(object sender, EventArgs e)
        {
            ClientSelected?.Invoke(this, EventArgs.Empty);
        }
        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {
            FreelancerSelected?.Invoke(this, EventArgs.Empty);
        }
        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            ClientSelected?.Invoke(this, EventArgs.Empty);
        }
    }
}
