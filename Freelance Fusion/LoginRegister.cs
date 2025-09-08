using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Freelance_Fusion
{
    public partial class LoginRegister : Form
    {
        public LoginRegister()
        {
            InitializeComponent();
        }
        private void LoadUC(UserControl usercontrol)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(usercontrol);
        }

        private void LoginRegister_Load(object sender, EventArgs e)
        {
            LoginUsercontorls.Login lg = new LoginUsercontorls.Login();
            LoadUC(lg);
            lg.SignupbtnClick += ShowSignupForm;
        }
        private void ShowSignupForm(object sender, EventArgs e)
        {
            LoginUsercontorls.Register su = new LoginUsercontorls.Register();
            LoadUC(su);
            su.SigninbtnClick += LoginRegister_Load;
        }
    }
}
