using System;
using Craft_dish.Services;

namespace Craft_dish.ViewModels
{
    public class Dish2ViewModel
    {

        private DishService dishService;
    
        public Dish2ViewModel()
        {
            dishService = new DishService();
        }

        public void saveDish(string dish_name, string dish_description)
        {
            dishService.createDish(dish_name, dish_description);        
        }

        public bool dishIsExists(String dish_name)
        {
            if(dish_name == dishService.getDishByName(dish_name).DishName)
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