using Craft_dish.Models;
using Craft_dish.Services;

namespace Craft_dish.ViewModels
{
    public class Dish5ViewModel
    {

        private readonly DishService dishService;

        public Dish5ViewModel()
        {
            dishService = new DishService();
        }

        public void SetDishPhoto(string dish_name, string dish_photo_path)
        {
            Dish dish = dishService.GetDishByName(dish_name);
            dishService.UpdateDishPhoto(dish, dish_photo_path);
        }

    }
}