﻿using System.Collections.Generic;
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

        public void CreateDish(string dish_name, string dish_description)
        {
            _realm.Write(() =>
            {
                _realm.Add(new Dish { DishName = dish_name, DishDescription = dish_description, DishPhoto = Resource.Drawable.icon_not_found });

            });
        }

        public void UpdateDish()
        {

        }

        public void DeleteDish()
        {

        }

        public List<Dish> GetAllDishes()
        {
            List<Dish> dishes = _realm.All<Dish>().ToList();
            return dishes;
        }

        public List<Dish> GetDishesByNameContent(string dish_name)
        {
            List<Dish> dishes = _realm.All<Dish>().Where(item => item.DishName.StartsWith(dish_name)).ToList();    
            return dishes;
        }

        public Dish GetDishByName(string dish_name)
        {
            Dish resultDish = new Dish();
            foreach (var dish in GetAllDishes())
            {
                resultDish = dish;
            }
            return resultDish;
        }

    }
}