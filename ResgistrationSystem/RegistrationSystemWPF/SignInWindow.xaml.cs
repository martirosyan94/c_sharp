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
        private RegisterModel _registerModel;
        private UserMenegment _userMenegment;
        private LogWriter _logWriter;
        public SignInWindow()
        {

            InitializeComponent();
        }

        private void SignInClick(object sender, RoutedEventArgs e)
        {
            _userMenegment = new UserMenegment();
            _registerModel = new RegisterModel();
            _logWriter = new LogWriter();
            _userMenegment.LoggedIn += _logWriter.OnLoggedIn;
            _userMenegment.AutorizationFailed += _logWriter.OnAutorizationFailed;

            _registerModel.Email = txtBoxEmail.Text;
            _registerModel.Password = txtBoxPassword.Text;
            _userMenegment.LoginToSystem(_registerModel);

            if (_userMenegment.IsLogined)
            {
                var accountWindow = new AccountWindow(_userMenegment.CurrentUser);
                accountWindow.ShowDialog();
            }
        }
    }
}
