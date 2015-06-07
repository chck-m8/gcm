using Foodie.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foodie.Data;
using Foodie.Data.Entity;
using Foodie.Data.Repo;

namespace Foodie.Data
{
    public class FoodieContext : IFoodieContext
    {
        private readonly IRepository<Food> _foodRepository;

        public IRepository<Food> Foods { get { return _foodRepository; } }

        public FoodieContext()
        {
            _foodRepository = new Repository<Food>();
            Seed();
        }
        private void Seed()
        {
            _foodRepository.Add(new Food() { Name = "Eggs", DishType = DishType.Entree, TimeOfDay = TimeOfDay.Morning, AllowMultiples = false });
            _foodRepository.Add(new Food() { Name = "Toast", DishType = DishType.Side, TimeOfDay = TimeOfDay.Morning, AllowMultiples = false });
            _foodRepository.Add(new Food() { Name = "Coffee", DishType = DishType.Drink, TimeOfDay = TimeOfDay.Morning, AllowMultiples = true });
            _foodRepository.Add(new Food() { Name = "Steak", DishType = DishType.Entree, TimeOfDay = TimeOfDay.Night, AllowMultiples = false });
            _foodRepository.Add(new Food() { Name = "Potatoes", DishType = DishType.Side, TimeOfDay = TimeOfDay.Night, AllowMultiples = true });
            _foodRepository.Add(new Food() { Name = "Wine", DishType = DishType.Drink, TimeOfDay = TimeOfDay.Night, AllowMultiples = false });
            _foodRepository.Add(new Food() { Name = "Cake", DishType = DishType.Dessert, TimeOfDay = TimeOfDay.Night, AllowMultiples = false });
        }
    }
}
