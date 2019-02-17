using Android.Content;
using Craft_dish.Models;
using Craft_dish.Services;
using Java.IO;

namespace Craft_dish.ViewModels
{
    public class DishPhotoPreviewViewModel : BaseDishViewModel
    {

        private DishService dishService;

        private Dish dish;

        private Context mContext;

        public DishPhotoPreviewViewModel(string dish_name, Context context)
        {
            dishService = new DishService();
            dish = dishService.GetDishByName(dish_name);
            mContext = context;
        }

        public string FindDishName()
        {
            return dish.Name;
        }

        public File getDishPhoto()
        {
            return FindDishPhoto(dish.PhotoPath);
        }

    }
}