using System;
using System.Collections.Generic;
using Craft_dish.Models;
using Craft_dish.Services;

namespace Craft_dish.ViewModels
{
    public class Dish4ViewModel
    {

        private DishService dishService;

        public Dish4ViewModel()
        {
            dishService = new DishService();
        }

        public bool DishesIsExist()
        {
            
            if (LoadDishes().Count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public List<Dish> LoadDishes()
        {
            return dishService.GetAllDishes();
        }

        public List<Dish> SearchDishByName(string dish_name)
        {
            List<Dish> dishes = new List<Dish>();

            if (dish_name.Length != 0)
            {
                for(int i = 0; i < LoadDishes().Count; i++)
                {
                    if (LoadDishes()[i].Name.Contains(dish_name, StringComparison.OrdinalIgnoreCase) == true)
                    {
                        dishes.Add(LoadDishes()[i]);
                    }

                }
                return dishes;
            }
            else
            {
                dishes = dishService.GetAllDishes();
                return dishes; 
            }
                    
        }

    }
}