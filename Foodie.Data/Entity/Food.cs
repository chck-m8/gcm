using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foodie.Data.Common;
using Foodie.Data.Repo;

namespace Foodie.Data.Entity
{
    public class Food : IFood, IEntity
    {
        public string Name { get; set; }
        public DishType DishType { get; set; }
        public TimeOfDay TimeOfDay { get; set; }
        public bool AllowMultiples { get; set; }
    }
}
