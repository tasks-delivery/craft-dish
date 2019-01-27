using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Craft_dish.Models;
using Craft_dish.Services;

namespace Craft_dish.ViewModels
{
    public class Dish5ViewModel
    {

        private DishService dishService;

        public Dish5ViewModel()
        {
            dishService = new DishService();
        }

        public void SetDishPhoto(string dish_name, string dish_photo_path)
        {
            Dish dish = dishService.GetDishByName(dish_name);
            dishService.UpdateDish(dish, dish_photo_path);
        }

    }
}