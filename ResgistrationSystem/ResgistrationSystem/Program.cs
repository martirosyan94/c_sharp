using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SocialNetwork
{
    class Program
    {

        static void Main(string[] args)
        {
            var container = ContainerConfig.Configure();
            var scope = container.BeginLifetimeScope();
            try
            {

                var app = scope.Resolve<IApplication>();
                app.Run();
            }
            finally
            {
                scope.Dispose();
            }
            //using (var scope = container.BeginLifetimeScope())
            //{
            //    var app = scope.Resolve<IApplication>();
            //    app.Run();
            //}
        }        
    }
}
