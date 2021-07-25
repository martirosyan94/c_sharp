using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork
{
    class Registration
    {
        public static User RegisterUser() {
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

            return new User(name, surName, age, email, password);
        }
    }
}
