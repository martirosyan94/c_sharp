using SocialNetwork.Core;
using System;

namespace SocialNetwork
{
    class MainMenu : IMainMenu
    {
        private bool stop = false;
        private int command;
        private UserMenegment userMenegment;
        private RegisterModel registerModel;
        private LogWriter logWriter;
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
            userMenegment = new UserMenegment();
            logWriter = new LogWriter();
            userMenegment.LoggedIn += logWriter.OnLoggedIn;
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

        public void SignIn()
        {
            while (!userMenegment.IsLogined)
            {
                registerModel = new RegisterModel();
                Console.WriteLine("Enter your username and password");
                registerModel.Email = Console.ReadLine();
                registerModel.Password = Console.ReadLine();
                userMenegment.LoginToSystem(registerModel);
            }

            while (ShowUserOptions(userMenegment.CurrentUser, ref stop)) { }
        }

        public void Register()
        {
            registerModel = new RegisterModel();

            Console.WriteLine($@"{Math.Log((int)RegisterOptions.User, 2)} - {RegisterOptions.User}
            {Environment.NewLine}{Math.Log((int)RegisterOptions.Employee, 2)} - {RegisterOptions.Employee}
            {Environment.NewLine}{Math.Log((int)RegisterOptions.Student, 2)} - {RegisterOptions.Student}
            {Environment.NewLine}{Math.Log((int)RegisterOptions.Back, 2)} - {RegisterOptions.User}
            {Environment.NewLine}{Math.Log((int)RegisterOptions.Exit, 2)} - {RegisterOptions.Exit}");

            command = (int)Math.Pow(2, int.Parse(Console.ReadLine()));
            userMenegment = new();
            RegisterInput();
            switch ((RegisterOptions)command)
            {
                case RegisterOptions.User:
                    registerModel.Type = AccountType.User;
                    userMenegment.RegisterUser(registerModel);
                    Console.WriteLine("Registration sucsessfully completed");
                    break;
                case RegisterOptions.Employee:
                    registerModel.Type = AccountType.Employee;
                    userMenegment.RegisterUser(registerModel);
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
        public void RegisterInput()
        {
            Console.WriteLine("Name");
            registerModel.Name = Console.ReadLine();
            Console.WriteLine("surname");
            registerModel.Surname = Console.ReadLine();
            Console.WriteLine("age");
            registerModel.Age = int.Parse(Console.ReadLine());
            Console.WriteLine("email");
            registerModel.Email = Console.ReadLine();
            Console.WriteLine("passwrod");
            registerModel.Password = Console.ReadLine();
        }

        public bool ShowUserOptions(User user, ref bool stop)
        {
            Console.WriteLine($@"{Math.Log((int)UserOptions.AccountInfo, 2)} - Account Info
            {Environment.NewLine}{Math.Log((int)UserOptions.Back, 2)} - {UserOptions.Back}
            {Environment.NewLine}{Math.Log((int)UserOptions.Exit, 2)} - {UserOptions.Exit}");

            command = (int)Math.Pow(2, int.Parse(Console.ReadLine()));
            switch ((UserOptions)command)
            {
                case UserOptions.AccountInfo:
                    user.AccountInfo();
                    return true;
                case UserOptions.Back:
                    return false;
                case UserOptions.Exit:
                    stop = true;
                    return false;
                default:
                    return true;
            }
        }
    }
}
