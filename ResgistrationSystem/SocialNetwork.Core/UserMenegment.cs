using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using SocialNetwork.Core;

namespace SocialNetwork.Core
{
    public class UserEventArgs : EventArgs
    {
        public User CurrentUser { get; set; }
    }
    public class UserMenegment : IUserMenegment
    {
        private int command;
        private static readonly IConfiguration _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        private string _fileName = string.Empty;
        public User CurrentUser { get; private set; }
        public bool IsLogined { get; private set; } = false;
        public UserMenegment()
        {
            _fileName = _configuration.GetSection("FileName:accountInfo").Value;
            if (!File.Exists(_fileName))
            {
                File.Create(_fileName);
            }

        }

        /// <summary>
        /// Gets type of user.
        /// 1 - User, 2 - Employee, 3 - Student
        /// </summary>
        /// <param name="type"></param>
        public void RegisterUser(IRegisterModel registerModel)
        {
            using (StreamWriter sw = new(_fileName, append: true))
            {
                string userInfo;
                switch (registerModel.Type)
                {
                    case AccountType.User:
                        userInfo = JsonSerializer.Serialize(new AccountModel(AccountType.User,
                                   JsonSerializer.Serialize(new User(registerModel.Name, registerModel.Surname, registerModel.Age, registerModel.Email, registerModel.Password))));
                        sw.WriteLine(userInfo);
                        break;
                    case AccountType.Employee:
                        OnRegisteredEmployee();
                        string workplace = Console.ReadLine();
                        userInfo = JsonSerializer.Serialize(new AccountModel(AccountType.Employee,
                                   JsonSerializer.Serialize(new Employee(registerModel.Name, registerModel.Surname, registerModel.Age, registerModel.Email, registerModel.Password, workplace))));
                        sw.WriteLine(userInfo);
                        break;
                }
            }
        }

        public void LoginToSystem(IRegisterModel registerModel)
        {
            var allUsers = File.ReadAllLines(_fileName);
            AccountModel accountModel;
            for (int i = 0; i < allUsers.Length; i++)
            {
                accountModel = JsonSerializer.Deserialize<AccountModel>(allUsers[i]);
                switch (accountModel.Type)
                {
                    case AccountType.User:
                        CurrentUser = JsonSerializer.Deserialize<User>(accountModel.Model);
                        break;
                    case AccountType.Employee:
                        CurrentUser = JsonSerializer.Deserialize<Employee>(accountModel.Model);
                        break;
                }

                if (CurrentUser.Email == registerModel.Email && CurrentUser.Password == registerModel.Password)
                {
                    OnLoggedIn();
                    IsLogined = true;
                    //OnLoggedIn(CurrentUser);
                    return;
                }
            }

            // Todo firstordefault first single singleordefault (read, define best one)
            // Todo pass function
            /*           CurrentUser = Users.FirstOrDefault(e => e.Email == userName && e.Password == password);
                       if (CurrentUser is not null)
                       {
                           Console.WriteLine("You have successfully logged in");
                           IsLogined = true;
                           return;
                       } */
            OnAutorizationFailed();
        }

        public event EventHandler LoggedIn;
        public event EventHandler AutorizationFailed;
        public event EventHandler RegisteredEmployee;

        protected virtual void OnLoggedIn()
        {
            LoggedIn?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnAutorizationFailed()
        {
            AutorizationFailed?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnRegisteredEmployee()
        {
            RegisteredEmployee?.Invoke(this, EventArgs.Empty);
        }


    }
}
