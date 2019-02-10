using Android.Content;
using Craft_dish.Models;
using Craft_dish.Services;
using Java.IO;

namespace Craft_dish.ViewModels
{
    public class Dish6ViewModel : BaseDishViewModel
    {

        private DishService dishService;

        private Dish dish;

        private Context mContext;

        public Dish6ViewModel(string dish_name, Context context)
        {
            dishService = new DishService();
            dish = dishService.GetDishByName(dish_name);
            mContext = context;
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