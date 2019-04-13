using System;
using System.Collections.Generic;
using Craft_dish.Models;
using Craft_dish.Services;

namespace Craft_dish.ViewModels
{
    public class Ingredient1ViewModel
    {

        private readonly IngredientService ingredientService;

        private readonly DishService dishService;

        public Ingredient1ViewModel()
        {
            ingredientService = new IngredientService();
            dishService = new DishService();
        }

        public IList<Ingredient> LoadDishIngredients(string dish_name)
        {
            return dishService.GetAllDishIngredients(dish_name);
        }

        public void RemoveDishIngredients(string dish_name, List<Ingredient> ingredients)
        {
            for (int i = 0; i < ingredients.Count; i++)
            {
                dishService.RemoveIngredientFromDish(dish_name, ingredients[i]);
            }
        }

        public void RemoveIngredients(List<Ingredient> ingredients)
        {   
            for (int i = ingredients.Count - 1; i > -1; i--)
            {
                ingredientService.DeleteIngredient(ingredients[i]);
                ingredients.RemoveAt(i);
            }           
        }

        public void AddIngredients(string dish_name, List<Ingredient> ingredients)
        {
            for (int i = 0; i < ingredients.Count; i++)
            {
                dishService.AddIngredientToDish(dish_name, ingredients[i]);
            }
        }

        public List<Ingredient> LoadIngredients()
        {
            return ingredientService.GetAllIngredients();
        }

        public List<Ingredient> SearchIngredientByName(string ingredient_name)
        {
            List<Ingredient> ingredients = new List<Ingredient>();
            List<Ingredient> allIngredients = LoadIngredients();
            if (ingredient_name.Length != 0)
            {
                for (int i = 0; i < allIngredients.Count; i++)
                {
                    if (allIngredients[i].Name.Contains(ingredient_name, StringComparison.OrdinalIgnoreCase) == true)
                    {
                        ingredients.Add(allIngredients[i]);
                    }
                }
                return ingredients;
            }
            else
            {
                ingredients = ingredientService.GetAllIngredients();
                return ingredients;
            }
        }

        public List<Ingredient> SearchDishIngredientByName(string dish_name, string ingredient_name)
        {
            List<Ingredient> ingredients = new List<Ingredient>();
            IList<Ingredient> dishIngredients = LoadDishIngredients(dish_name);
            if (ingredient_name.Length != 0)
            {               
                for (int i = 0; i < dishIngredients.Count; i++)
                {
                    if (dishIngredients[i].Name.Contains(ingredient_name, StringComparison.OrdinalIgnoreCase) == true)
                    {
                        ingredients.Add(dishIngredients[i]);
                    }
                }
                return ingredients;
            }
            else
            {
                for(int i = 0; i < dishIngredients.Count; i++)
                {
                    ingredients.Add(dishIngredients[i]);
                }
                return ingredients;
            }

        }

    }
}