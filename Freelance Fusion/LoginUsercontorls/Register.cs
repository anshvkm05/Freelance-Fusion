using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Freelance_Fusion.LoginUsercontorls
{
    public partial class Register : UserControl
    {
        public Register()
        {
            InitializeComponent();
        }
        public event EventHandler SigninbtnClick;

        private void SinginBtn_Click(object sender, EventArgs e)
        {
            SigninbtnClick?.Invoke(this, EventArgs.Empty);
        }
    }
}
