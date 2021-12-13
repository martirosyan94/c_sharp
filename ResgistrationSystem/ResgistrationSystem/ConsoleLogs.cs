using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork
{
    public class ConsoleLogs : IConsoleLogs
    {
        public void OnLoggedIn(object source, EventArgs args)
        {
            Console.WriteLine("You have successfully logged in");
        }

        public void OnAutorizationFailed(object source, EventArgs args)
        {
            Console.WriteLine("The username or password is not correct, try again");
        }

        public void OnRegisteredEmployee(object source, EventArgs args)
        {
            Console.WriteLine("workplace ");
        }
    }
}
