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
    public partial class RegistrationForm : Form
    {
        private UserMenegment userMenegment;
        private RegisterModel registerModel;
        public RegistrationForm()
        {
            InitializeComponent();
            FillAccountTypeComboBox();
        }

        private void FillAccountTypeComboBox()
        {
            cbBoxAccountType.Items.AddRange(Enum.GetNames(typeof(AccountType)));
        }

        private void RegisterClick(object sender, EventArgs e)
        {
            userMenegment = new UserMenegment();
            registerModel = new RegisterModel();

            registerModel.Name = txtBoxName.Text;
            registerModel.Surname = txtBoxSurname.Text;
            registerModel.Age = int.Parse(txtBoxAge.Text);
            registerModel.Email = txtBoxEmal.Text;
            registerModel.Password = txtBoxPassword.Text;
            //TODO improve
            registerModel.Type = (AccountType)Enum.Parse(typeof(AccountType), cbBoxAccountType.SelectedItem.ToString());

            userMenegment.RegisterUser(registerModel);
            Close();

        }

    }
}
