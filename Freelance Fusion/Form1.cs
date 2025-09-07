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
        public Form1()
        {
            InitializeComponent();
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
