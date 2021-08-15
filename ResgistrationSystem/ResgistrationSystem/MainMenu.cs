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
            Console.WriteLine(@$"{Math.Log((int)MainMenuOptions.Login, 2)} -  {MainMenuOptions.Login}
            {Environment.NewLine}{Math.Log((int)MainMenuOptions.Register, 2)} - {MainMenuOptions.Register}
            { Environment.NewLine}{Math.Log((int)MainMenuOptions.Exit, 2)} - {MainMenuOptions.Exit}");

            command = (int)Math.Pow(2, int.Parse(Console.ReadLine()));
            userMenegment = new();
            switch ((MainMenuOptions)command)
            {
                case MainMenuOptions.Login:
                    SignIn();
                    break;
                case MainMenuOptions.Register:
                    Register();
                    break;
                case MainMenuOptions.Exit:
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
            Console.WriteLine($@"{Math.Log((int)RegisterOptions.User,2)} - {RegisterOptions.User}
            {Environment.NewLine}{Math.Log((int)RegisterOptions.Employee, 2)} - {RegisterOptions.Employee}
            {Environment.NewLine}{Math.Log((int)RegisterOptions.Student, 2)} - {RegisterOptions.Student}
            {Environment.NewLine}{Math.Log((int)RegisterOptions.Back, 2)} - {RegisterOptions.User}
            {Environment.NewLine}{Math.Log((int)RegisterOptions.Exit, 2)} - {RegisterOptions.Exit}");

            command = (int)Math.Pow(2, int.Parse(Console.ReadLine()));
            userMenegment = new();
            switch ((RegisterOptions)command)
            {
                case RegisterOptions.User:
                    userMenegment.RegisterUser(AccountType.User);
                    Console.WriteLine("Registration sucsessfully completed");
                    break;
                case RegisterOptions.Employee:
                    userMenegment.RegisterUser(AccountType.Employee);
                    Console.WriteLine("Registration sucsessfully completed");
                    break;
                case RegisterOptions.Student:
                    break;
                case RegisterOptions.Back:
                    break;
                case RegisterOptions.Exit:
                    stop = true;
                    break;
            }
        }
    }
}
