using Craft_dish.Models;
using Craft_dish.Services;
using Java.IO;

namespace Craft_dish.ViewModels
{
    public class Dish7ViewModel : BaseDishViewModel
    {

        private readonly DishService dishService;

        private readonly Dish dish;

        public Dish7ViewModel(string dish_name)
        {
            dishService = new DishService();
            dish = dishService.GetDishByName(dish_name);
        }

        public void SaveDish(string old_dish_name, string dish_name, string dish_description)
        {
            Dish oldDish = dishService.GetDishByName(old_dish_name);
            dishService.UpdateDish(oldDish, dish_name, dish_description);
        }

        public bool DishIsExists(string dish_name)
        {
            if (dish_name == dishService.GetDishByName(dish_name).Name)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string FindDishName()
        {
            return dish.Name;
        }

        public string FindDishDescription()
        {
            return dish.Description;
        }

        public File GetDishPhoto()
        {
            return FindDishPhoto(dish.PhotoPath);
        }

        public void RemoveDish(string dish_name)
        {
            dishService.DeleteDish(dish);
        }

    }

}