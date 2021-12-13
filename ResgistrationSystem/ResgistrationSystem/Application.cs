using SocialNetwork.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork
{
    public class Application : IApplication
    {
        IMainMenu _mainMenu;
        public Application(IMainMenu mainMenu)
        {
            _mainMenu = mainMenu;
        }

        public void Run()
        {
            _mainMenu.Start();
        }
    }
}
