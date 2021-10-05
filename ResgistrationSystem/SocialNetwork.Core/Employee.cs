using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core
{
    class Employee : User
    {
        public string Workplace { get; set; }

        public Employee(string name, string surname, int age, 
            string email, string password, string workPlace) 
            : base(name, surname, age, email, password)
        {
            Workplace = workPlace;
        }

        public override void AccountInfo()
        {
            Console.WriteLine(Name + " " + Surname + " " + Workplace);
        }
    }
}
