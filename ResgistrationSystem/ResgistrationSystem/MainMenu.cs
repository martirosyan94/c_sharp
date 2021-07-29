using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork
{
    class MainMenu
    {
        private bool stop = false;
        private int command;
        private UserMenegment userMenegment;
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
            userMenegment = new();
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
            while (!userMenegment.IsLogined) 
            {
                userMenegment.LoginToSystem();
            }
            while (userMenegment.ShowUserOptions(userMenegment.CurrentUser, ref stop)) { }
        }

        private void Register()
        {
            userMenegment.RegisterUser();
            Console.WriteLine("Registration sucsessfully completed");
        }
    }
}
