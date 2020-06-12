using System.Collections.Generic;
using System.Linq;
using Craft_dish.Models;
using Realms;

namespace Craft_dish.Services
{
    public class DishService : BaseService
    {

        private readonly Realm _realm;

        public DishService()
        {
            _realm = GetDbInstance();
        }

        public void CreateDish(string dish_name, string dish_description)
        {
            _realm.Write(() =>
            {
                _realm.Add(new Dish { Name = dish_name, Description = dish_description, PhotoPath = "" });
            });
        }

        public void UpdateDishPhoto(Dish dish, string photo_path)
        {
            _realm.Write(() =>
            {
                dish.PhotoPath = photo_path;
            });
        }

        public void UpdateDish(Dish dish, string name, string description)
        {
            _realm.Write(() =>
            {
                dish.Name = name;
                dish.Description = description;
            });
        }

        public void DeleteDish(Dish dish_name)
        {
            using (var transaction = _realm.BeginWrite())
            {
                _realm.Remove(dish_name);
                transaction.Commit();
            }
        }

        public List<Dish> GetAllDishes()
        {
            List<Dish> dishes = _realm.All<Dish>().ToList();
            return dishes;
        }

        public List<Dish> GetDishesByNameContent(string dish_name)
        {
            List<Dish> dishes = _realm.All<Dish>().Where(item => item.Name.StartsWith(dish_name)).ToList();    
            return dishes;
        }

        public Dish GetDishByName(string dish_name)
        {
            Dish resultDish = new Dish();
            foreach (var dish in GetAllDishes())
            {
                if (dish.Name == dish_name)
                {
                    resultDish = dish;
                }
                
            }
            return resultDish;
        }

        public void AddIngredientToDish(string dish_name, Ingredient ingredient)
        {
            Dish dish = GetDishByName(dish_name);
            _realm.Write(() =>
            {
                dish.Ingredients.Add(ingredient);
            });           
        }

        public void RemoveIngredientFromDish(string dish_name, Ingredient ingredient)
        {
            Dish dish = GetDishByName(dish_name);
            _realm.Write(() =>
            {
                dish.Ingredients.Remove(ingredient);
            });
        }

        public IList<Ingredient> GetAllDishIngredients(string dish_name)
        {
            Dish dish = GetDishByName(dish_name);
            return dish.Ingredients;
        }

    }
}