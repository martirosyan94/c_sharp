﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SocialNetwork
{
    class UserMenegment
    {
        public static List<User> Users { get; set; } = new();
        private int command;
        private string fileName = "account_info.json";
        public User CurrentUser { get; private set; }
        public bool IsLogined { get; private set; } = false;
        public UserMenegment()
        {
            if (!File.Exists(fileName))
                File.Create(fileName);

        }
        public void RegisterUser()
        {
            Console.WriteLine("userName");
            string name = Console.ReadLine();
            Console.WriteLine("surname");
            string surName = Console.ReadLine();
            Console.WriteLine("age");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("email");
            string email = Console.ReadLine();
            Console.WriteLine("passwrod");
            string password = Console.ReadLine();

            string userInfo = JsonSerializer.Serialize(new User(name, surName, age, email, password));
            StreamWriter sw = File.AppendText(fileName);
            sw.WriteLine(userInfo);
            sw.Close();

        }

        public void LoginToSystem()
        {
            Console.WriteLine("Enter your username and password");
            string userName = Console.ReadLine();
            string password = Console.ReadLine();
            var allUsers = File.ReadAllLines(fileName);
            for (int i = 0; i < allUsers.Length; i++)
            {
                CurrentUser = JsonSerializer.Deserialize<User>(allUsers[i]);
                if (CurrentUser.Email == userName && CurrentUser.Password == password)
                {
                    Console.WriteLine("You have successfully logged in");
                    IsLogined = true;
                    return;
                }
            }    
               
            // Todo firstordefault first single singleordefault (read, define best one)
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
            Console.WriteLine("1 - Account info " +
                              "\n2 - Back " +
                              "\n3 - Exit");
            command = int.Parse(Console.ReadLine());
            switch (command)
            {
                case 1:
                    user.AccountInfo();
                    return true;
                case 2:
                    return false;
                case 3:
                    stop = true;
                    return false;
                default:
                    return true;
            }
        }

    }
}
