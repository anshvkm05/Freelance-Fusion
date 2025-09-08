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
        string email;
        string password;
        public event EventHandler SignupbtnClick;
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
        }
    }
}
