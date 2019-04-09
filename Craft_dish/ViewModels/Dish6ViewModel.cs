using Craft_dish.Models;
using Craft_dish.Services;
using Java.IO;
using System.Collections.Generic;

namespace Craft_dish.ViewModels
{
    public class Dish6ViewModel : BaseDishViewModel
    {

        private readonly DishService dishService;

        private readonly Dish dish;

        public Dish6ViewModel(string dish_name)
        {
            dishService = new DishService();
            dish = dishService.GetDishByName(dish_name);
        }

        public IList<Ingredient> LoadDishIngredients(string dish_name)
        {
            IList<Ingredient> ingDish = dishService.GetAllDishIngredients(dish_name);     
            return ingDish;
        }

        public string FindDishName()
        {
            return dish.Name;
        }

        public string FindDishDescription()
        {
            return dish.Description;
        }

        public File getDishPhoto()
        {      
            return FindDishPhoto(dish.PhotoPath);
        }

    }

}