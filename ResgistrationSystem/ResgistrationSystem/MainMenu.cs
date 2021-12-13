using SocialNetwork.Core;
using System;

namespace SocialNetwork
{
    public class MainMenu : IMainMenu
    {
        private bool stop = false;
        private int command;
        private IUserMenegment _userMenegment;
        private IRegisterModel _registerModel;
        private IConsoleLogs _consoleLogs;

        public MainMenu(IUserMenegment userMenegment, IRegisterModel registerModel, IConsoleLogs consoleLogs)
        {
            _userMenegment = userMenegment;
            _registerModel = registerModel;
            _consoleLogs = consoleLogs;
        }
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
           // _userMenegment = new UserMenegment();
           // _consoleLogs = new ConsoleLogs();
            _userMenegment.LoggedIn += _consoleLogs.OnLoggedIn;
            _userMenegment.AutorizationFailed += _consoleLogs.OnAutorizationFailed;
            _userMenegment.RegisteredEmployee += _consoleLogs.OnRegisteredEmployee;
            switch ((MainMenuOptions)command)
            {
                case MainMenuOptions.Login:
                    SignIn();
                    break;
                case MainMenuOptions.Register:
                    var registerType = ShowRegisterOptions();
                    Register(registerType);
                    break;
                case MainMenuOptions.Exit:
                    stop = true;
                    break;
            }
        }

        public void SignIn()
        {
            while (!_userMenegment.IsLogined)
            {
               // _registerModel = new RegisterModel();
                Console.WriteLine("Enter your username and password");
                _registerModel.Email = Console.ReadLine();
                _registerModel.Password = Console.ReadLine();
                _userMenegment.LoginToSystem(_registerModel);
            }

            while (ShowUserOptions(_userMenegment.CurrentUser, ref stop)) { }
        }
        public int ShowRegisterOptions()
        {
            Console.WriteLine($@"{Math.Log((int)RegisterOptions.User, 2)} - {RegisterOptions.User}
            {Environment.NewLine}{Math.Log((int)RegisterOptions.Employee, 2)} - {RegisterOptions.Employee}
            {Environment.NewLine}{Math.Log((int)RegisterOptions.Student, 2)} - {RegisterOptions.Student}
            {Environment.NewLine}{Math.Log((int)RegisterOptions.Back, 2)} - {RegisterOptions.User}
            {Environment.NewLine}{Math.Log((int)RegisterOptions.Exit, 2)} - {RegisterOptions.Exit}");

            return (int)Math.Pow(2, int.Parse(Console.ReadLine()));
        }
        public void Register(int registerType)
        {
            RegisterInput();
            switch ((RegisterOptions)registerType)
            {
                case RegisterOptions.User:
                    _registerModel.Type = AccountType.User;
                    _userMenegment.RegisterUser(_registerModel);
                    Console.WriteLine("Registration sucsessfully completed");
                    break;
                case RegisterOptions.Employee:
                    _registerModel.Type = AccountType.Employee;
                    _userMenegment.RegisterUser(_registerModel);
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
            _registerModel.Name = Console.ReadLine();
            Console.WriteLine("surname");
            _registerModel.Surname = Console.ReadLine();
            Console.WriteLine("age");
            _registerModel.Age = int.Parse(Console.ReadLine());
            Console.WriteLine("email");
            _registerModel.Email = Console.ReadLine();
            Console.WriteLine("passwrod");
            _registerModel.Password = Console.ReadLine();
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
