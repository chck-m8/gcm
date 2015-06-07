using Autofac;
using Foodie.Data;
using Foodie.Data.Entity;
using Foodie.Data.Repo;
using Foodie.Main.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Main.Config
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Food>().As<IEntity>();
            builder.RegisterType<FoodieContext>().As<IFoodieContext>();
            builder.RegisterType<Application>().As<IApplication>();
            builder.RegisterType<MealTaker>().As<IOutput>();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>));

            return builder.Build();
        }
    }
}
