using SocialNetwork.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocialNetworkWF
{
    public partial class SignInForm : Form
    {
        private RegisterModel registerModel;
        private UserMenegment userMenegment;
        public SignInForm()
        {
            InitializeComponent();

        }

        private void SignInClick(object sender, EventArgs e)
        {
            userMenegment = new UserMenegment();
            registerModel = new RegisterModel();
            registerModel.Email = txtBoxEmail.Text;
            registerModel.Password = txtBoxPassword.Text;
            userMenegment.LoginToSystem(registerModel);

            if (userMenegment.IsLogined)
            {
                var accountForm = new AccountForm(userMenegment.CurrentUser);
                accountForm.Show();
                Hide();
            }
        }

        private void SignInForm_Load(object sender, EventArgs e)
        {

        }
    }
}
