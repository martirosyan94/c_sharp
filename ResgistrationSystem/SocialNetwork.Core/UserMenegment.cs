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
    public class UserMenegment
    {
        public static List<User> Users { get; set; } = new();
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
        public void RegisterUser(RegisterModel registerModel)
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
                        Console.WriteLine("workplace ");
                        string workplace = Console.ReadLine();
                        userInfo = JsonSerializer.Serialize(new AccountModel(AccountType.Employee,
                                   JsonSerializer.Serialize(new Employee(registerModel.Name, registerModel.Surname, registerModel.Age, registerModel.Email, registerModel.Password, workplace))));
                        sw.WriteLine(userInfo);
                        break;
                }
            }
        }

        public void LoginToSystem(RegisterModel registerModel)
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
                    Console.WriteLine("You have successfully logged in");
                    IsLogined = true;
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

            Console.WriteLine("The username or password is not correct, try again");
        }

        public event EventHandler<User> LoggedIn;
        public void WriteToLog(User user)
        {
            OnLoggedIn(user);
        }

        protected virtual void OnLoggedIn(User user)
        {
            LoggedIn?.Invoke(this, user);
        }
    }
}
