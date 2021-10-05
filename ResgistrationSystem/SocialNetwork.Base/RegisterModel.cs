using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core
{
    record RegisterModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public RegisterModel(string name, string surname, int age, string email, string password)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Email = email;
            Password = password;
        }

        void Test()
        {
            var r1 = new RegisterModel("Mukuch", "Hakobyan", 12, "s", "a");
        }
    }
}
