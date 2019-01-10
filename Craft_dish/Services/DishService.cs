using System.Collections.Generic;
using System.Linq;
using Craft_dish.Models;
using Realms;

namespace Craft_dish.Services
{
    class DishService
    {

        private readonly Realm _realm;

        public DishService()
        {
            _realm = Realm.GetInstance();
        }

        public void createDish(string dish_name, string dish_description)
        {
            _realm.Write(() =>
            {
                _realm.Add(new Dish { DishName = dish_name, DishDescription = dish_description });

            });
        }

        public void updateDish()
        {

        }

        public void deleteDish()
        {

        }

        public List<Dish> getAllDishes()
        {
            List<Dish> dishes = _realm.All<Dish>().ToList();
            return dishes;
        }

        public Dish getDishByName(string dish_name)
        {
            Dish resultDish = new Dish();
            foreach (var dish in getAllDishes())
            {
                resultDish = dish;
            }
            return resultDish;
        }

    }
}