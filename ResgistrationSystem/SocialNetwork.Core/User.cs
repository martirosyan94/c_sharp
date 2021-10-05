using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.Core
{
    public class User
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public User(string name, string surname, int age, string email, string password)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Email = email;
            Password = password;
        }

        public virtual void AccountInfo() 
        {
            Console.WriteLine(Name + " " + Surname);
        }
            
    }
}
