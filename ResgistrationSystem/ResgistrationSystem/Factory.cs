using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork
{
    class Factory
    {
        private bool stop = false;
        private int command;
        private List<User> users = new();
        public void Start()
        {
            while (!stop)
                ShowMainOptions();
        }
        private void ShowMainOptions()
        {
            Console.WriteLine("1 - Login " +
                              "\n2 - Registration " +
                              "\n3 - Exit");
            command = int.Parse(Console.ReadLine());
            switch (command)
            {
                case 1:
                    SignIn();
                    break;
                case 2:
                    Register();
                    break;
                case 3:
                    stop = true;
                    break;
            }
        }

        private void SignIn()
        {
            Login login = new();
            while (!login.IsLogined) 
            {
                login.LoginToSystem(users);
            }
            while (login.ShowUserOptions(login.CurrentUser, ref stop)) { }
        }

        private void Register()
        {
            users.Add(Registration.RegisterUser());
            Console.WriteLine("Registration sucsessfully completed");
        }
    }
}
