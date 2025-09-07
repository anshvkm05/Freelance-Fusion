using System;
using System.Drawing;
using System.Windows.Forms;

namespace Freelance_Fusion
{
    public partial class landingApplication : UserControl
    {
        public event EventHandler singupbutton;
        public landingApplication()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void modernButton1_Click(object sender, EventArgs e)
        {

        }

        private void modernButton1_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
           
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {

        }
        private void guna2Button5_Click_1(object sender, EventArgs e)
        {
            guna2Button5.FillColor = System.Drawing.Color.FromArgb(51, 43, 1);
            guna2Button4.FillColor = System.Drawing.Color.FromArgb(240, 240, 240);
            guna2Button5.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            guna2Button4.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
        }

        private void guna2Button4_Click_1(object sender, EventArgs e)
        {
            guna2Button4.FillColor = System.Drawing.Color.FromArgb(51, 43, 1);
            guna2Button5.FillColor = System.Drawing.Color.FromArgb(240, 240, 240);
            guna2Button4.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            guna2Button5.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
        }

        private void SignupButton_Click(object sender, EventArgs e)
        {
            singupbutton?.Invoke(this, EventArgs.Empty);
        }
    }
}
