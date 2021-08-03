using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork
{
    enum MainMenuOptions
    {
        Login = 1,
        Register,
        Exit
    }
    enum RegisterOptions
    { 
        User = 1,
        Employee,
        Student,
        Back,
        Exit
    }
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
            Console.WriteLine(@$"{(int)MainMenuOptions.Login} -  {MainMenuOptions.Login}
            {Environment.NewLine}{(int)MainMenuOptions.Register} - {MainMenuOptions.Register}
            { Environment.NewLine}{(int)MainMenuOptions.Exit} - {MainMenuOptions.Exit}");

            command = int.Parse(Console.ReadLine());
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
            Console.WriteLine($@"{(int)RegisterOptions.User} - {RegisterOptions.User}
            {Environment.NewLine}{(int)RegisterOptions.Employee} - {RegisterOptions.Employee}
            {Environment.NewLine}{(int)RegisterOptions.Student} - {RegisterOptions.Student}
            {Environment.NewLine}{(int)RegisterOptions.Back} - {RegisterOptions.User}
            {Environment.NewLine}{(int)RegisterOptions.Exit} - {RegisterOptions.Exit}");

            command = int.Parse(Console.ReadLine());
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
