using Craft_dish.Services;

namespace Craft_dish.ViewModels
{
    public class Ingredient2ViewModel
    {

        private readonly IngredientService ingredientService;

        public Ingredient2ViewModel()
        {
            ingredientService = new IngredientService();
        }

        public void SaveIngredient(string ingredient_name, string ingredient_weight, string weight_unit)
        {
            ingredientService.CreateIngredient(ingredient_name, ingredient_weight, weight_unit);
        }

    }

}