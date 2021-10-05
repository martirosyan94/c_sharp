using SocialNetwork.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RegistrationSystemWPF
{
    /// <summary>
    /// Interaction logic for SignInWindow.xaml
    /// </summary>
    public partial class SignInWindow : Window
    {
        private RegisterModel registerModel;
        private UserMenegment userMenegment;
        public SignInWindow()
        {

            InitializeComponent();
        }

        private void SignInClick(object sender, RoutedEventArgs e)
        {
            userMenegment = new UserMenegment();
            registerModel = new RegisterModel();
            registerModel.Email = txtBoxEmail.Text;
            registerModel.Password = txtBoxPassword.Text;
            userMenegment.LoginToSystem(registerModel);

            if (userMenegment.IsLogined)
            {
                var accountWindow = new AccountWindow(userMenegment.CurrentUser);
                accountWindow.ShowDialog();
            }
        }
    }
}
