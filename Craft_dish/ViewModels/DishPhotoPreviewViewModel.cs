using Craft_dish.Models;
using Craft_dish.Services;
using Java.IO;

namespace Craft_dish.ViewModels
{
    public class DishPhotoPreviewViewModel : BaseDishViewModel
    {

        private readonly Dish dish;

        public DishPhotoPreviewViewModel(string dish_name)
        {
            DishService dishService = new DishService();
            dish = dishService.GetDishByName(dish_name);
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