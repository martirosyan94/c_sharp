using SocialNetwork.Core;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace RegistrationSystemWPF
{
    /// <summary>
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        private UserMenegment _userMenegment;
        private RegisterModel _registerModel;
        private LogWriter _logWriter;
        public RegistrationPage()
        {
            InitializeComponent();
            FillAccountTypeComboBox();
            _userMenegment = new UserMenegment();
            _registerModel = new RegisterModel();
            _logWriter = new LogWriter();
            _userMenegment.RegisteredEmployee += _logWriter.OnRegisteredEmployee;
        }
        private void FillAccountTypeComboBox()
        {
            //cbBoxAccountType.Items.AddRange(Enum.GetNames(typeof(AccountType)));
            Enum.GetNames(typeof(AccountType)).ToList().ForEach(item => cbBoxAccountType.Items.Add(item));
        }
        private void ButtonBack(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.ShowDialog();
            //var mainWindow = new MainWindow();
            //this.Content = mainWindow;
        }

        private void ButtonRegister(object sender, RoutedEventArgs e)
        {
            _registerModel.Name = txtBoxName.Text;
            _registerModel.Surname = txtBoxSurname.Text;
            _registerModel.Age = int.Parse(txtBoxAge.Text);
            _registerModel.Email = txtBoxEmail.Text;
            _registerModel.Password = txtBoxPassword.Text;
            //TODO improve
            _registerModel.Type = (AccountType)Enum.Parse(typeof(AccountType), cbBoxAccountType.SelectedItem.ToString());
            _userMenegment.RegisterUser(_registerModel);

        }
    }
}
