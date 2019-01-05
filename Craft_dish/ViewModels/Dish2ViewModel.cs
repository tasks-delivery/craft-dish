using System;
using System.Linq;
using Craft_dish.Models;
using Realms;

namespace Craft_dish.ViewModels
{
    public class Dish2ViewModel
    {
        private readonly Realm _realm;
    
        public Dish2ViewModel()
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

        public Dish getDishByName(string dish_name)
        {
            Dish test = new Dish();        
            var dishes = _realm.All<Dish>().Where(d => d.DishName == dish_name);
            foreach (var dish in dishes)
            {
                test = dish;
            }
            return test;
        }

        public bool dishIsExists(String dish_name)
        {
            if(dish_name == getDishByName(dish_name).DishName)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}