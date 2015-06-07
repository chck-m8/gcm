using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Foodie.Data.Repo;
using Foodie.Main.Config;
using Foodie.Main.Interface;


namespace Foodie.Main
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var container = ContainerConfig.Configure();
                using (var scope = container.BeginLifetimeScope())
                {
                    var app = scope.Resolve<IApplication>();
                    app.Run();
                }
            }catch{
                Console.WriteLine("An error has occurred.");
            }
        }
    }
}
