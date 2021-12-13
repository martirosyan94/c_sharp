using Autofac;
using SocialNetwork.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork
{
    public static class ContainerConfig
    {
        public static IContainer Configure() 
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Application>().As<IApplication> ();
            
            builder.RegisterType<UserMenegment>().As<IUserMenegment> ();
            builder.RegisterType<RegisterModel>().As<IRegisterModel> ();
            builder.RegisterType<ConsoleLogs>().As<IConsoleLogs> ();
            builder.RegisterType<MainMenu>().As<IMainMenu> ();
            //builder.RegisterType<MainMenu>().As<IMainMenu> ();

            return builder.Build();
        }

    }
}
