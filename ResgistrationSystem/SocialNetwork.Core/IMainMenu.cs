using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core
{
   public interface IMainMenu
    {
        void SignIn();
        void Register(int registerType);
        void Start();
    }
}
