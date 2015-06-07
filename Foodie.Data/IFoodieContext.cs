using Foodie.Data.Entity;
using Foodie.Data.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Data.Repo
{
    public interface IFoodieContext
    {
        IRepository<Food> Foods { get; }
    }
}
