using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SocialNetwork
{
    class UserMenegment
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
        public void RegisterUser(AccountType accountType)
        {
            Console.WriteLine("UserName");
            string name = Console.ReadLine();
            Console.WriteLine("surname");
            string surName = Console.ReadLine();
            Console.WriteLine("age");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("email");
            string email = Console.ReadLine();
            Console.WriteLine("passwrod");
            string password = Console.ReadLine();

            using (StreamWriter sw = new(_fileName, append : true))
            {
                string userInfo;
                switch (accountType)
                {
                    case AccountType.User:
                        userInfo = JsonSerializer.Serialize(new AccountModel(AccountType.User,
                                   JsonSerializer.Serialize(new User(name, surName, age, email, password))));
                        sw.WriteLine(userInfo);
                        break;
                    case AccountType.Employee:
                        Console.WriteLine("workplace ");
                        string workplace = Console.ReadLine();
                        userInfo = JsonSerializer.Serialize(new AccountModel(AccountType.Employee,
                                   JsonSerializer.Serialize(new Employee(name, surName, age, email, password, workplace))));
                        sw.WriteLine(userInfo);
                        break;
                }
            }
        }

        public void LoginToSystem()
        {
            Console.WriteLine("Enter your username and password");
            string userName = Console.ReadLine();
            string password = Console.ReadLine();
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
                
                if (CurrentUser.Email == userName && CurrentUser.Password == password)
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

        public bool ShowUserOptions(User user, ref bool stop)
        {
            Console.WriteLine($@"{Math.Log((int)UserOptions.AccountInfo,2)} - Account Info
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
