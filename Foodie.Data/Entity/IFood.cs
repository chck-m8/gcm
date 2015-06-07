using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foodie.Data.Common;

namespace Foodie.Data.Entity
{
    public interface IFood
    {
        string Name { get; }
        DishType DishType { get; }
        TimeOfDay TimeOfDay { get; }
        bool AllowMultiples { get; }
    }
}
