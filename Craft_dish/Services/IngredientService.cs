using System.Collections.Generic;
using System.Linq;
using Craft_dish.Models;
using Realms;

namespace Craft_dish.Services
{
    class IngredientService
    {

        private readonly Realm _realm;

        public IngredientService()
        {
            _realm = Realm.GetInstance();
        }

        public void CreateIngredient(string ingredient_name, string ingredient_weight, string weight_unit)
        {
            _realm.Write(() =>
            {
                _realm.Add(new Ingredient { Name = ingredient_name, Weight = ingredient_weight, Unit = weight_unit });
            });
        }

        public List<Ingredient> GetAllIngredients()
        {
            List<Ingredient> ingredients = _realm.All<Ingredient>().ToList();
            return ingredients;
        }

        public void DeleteIngredient(Ingredient ingredient_name)
        {
            using (var transaction = _realm.BeginWrite())
            {
                _realm.Remove(ingredient_name);
                transaction.Commit();
            }
        }

        public List<Ingredient> GetIngredientsByNameContent(string ingredient_name)
        {
            List<Ingredient> ingredients = _realm.All<Ingredient>().Where(item => item.Name.StartsWith(ingredient_name)).ToList();
            return ingredients;
        }

        public Ingredient GetIngredientByName(string ingredient_name)
        {
            Ingredient resultIngredient = new Ingredient();
            foreach (var ingredient in GetAllIngredients())
            {
                if (ingredient.Name == ingredient_name)
                {
                    resultIngredient = ingredient;
                }

            }
            return resultIngredient;
        }

    }
}