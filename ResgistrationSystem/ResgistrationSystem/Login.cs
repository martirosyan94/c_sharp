using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork
{
    class Login
    {
        private int command;
        public User CurrentUser { get; private set; }
        public bool IsLogined { get; private set; } = false;
        public void LoginToSystem(List<User> Users)
        {
            Console.WriteLine("Enter your username and password");
            string userName = Console.ReadLine();
            string password = Console.ReadLine();
            // Todo firstordefault first single singleordefault (read, define best one)
            CurrentUser = Users.FirstOrDefault(e => e.Email == userName && e.Password == password);
            if (CurrentUser is not null)
            {
                Console.WriteLine("You have successfully logged in");
                IsLogined = true;
                return;
            }

            Console.WriteLine("The username or password is not correct, try again");
        }

        public  bool ShowUserOptions(User user, ref bool stop)
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
