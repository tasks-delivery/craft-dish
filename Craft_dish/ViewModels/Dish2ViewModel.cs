using Craft_dish.Services;

namespace Craft_dish.ViewModels
{
    public class Dish2ViewModel
    {

        private readonly DishService dishService;
    
        public Dish2ViewModel()
        {
            dishService = new DishService();
        }

        public void SaveDish(string dish_name, string dish_description)
        {
            dishService.CreateDish(dish_name, dish_description);        
        }

        public bool DishIsExists(string dish_name)
        {
            if(dish_name == dishService.GetDishByName(dish_name).Name)
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