using System;

namespace SocialNetwork.Core
{
    public class LogWriter
    {
        public void OnLoggedIn(object source, UserEventArgs args)
        {
            Console.WriteLine("LogWriter: Writing currentuser info to the log!!! Name:" + args.CurrentUser.Name );
        }
    }
}
