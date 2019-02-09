using Android.Content;
using Craft_dish.Models;
using Craft_dish.Services;
using Java.IO;

namespace Craft_dish.ViewModels
{
    public class Dish7ViewModel : BaseDishViewModel
    {

        private DishService dishService;

        private Dish dish;

        private Context mContext;

        public Dish7ViewModel(string dish_name, Context context)
        {
            dishService = new DishService();
            dish = dishService.GetDishByName(dish_name);
            mContext = context;
        }

        public void saveDish(string old_dish_name, string dish_name, string dish_description)
        {
            Dish dish = dishService.GetDishByName(old_dish_name);
            dishService.UpdateDish(dish, dish_name, dish_description);
        }

        public bool dishIsExists(string dish_name)
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

        public File getDishPhoto()
        {
            return FindDishPhoto(dish.PhotoPath);
        }

    }

}