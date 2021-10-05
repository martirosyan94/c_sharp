using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SocialNetwork.Core;

namespace SocialNetworkWF
{
    public partial class AccountForm : Form
    {
        public AccountForm(User user)
        {
            InitializeComponent();
            setAccountInfo(user);
        }

        private void setAccountInfo(User user)
        {
            lblName.Text = user.Name;
            lblSurname.Text = user.Surname;
        }
    }
}
