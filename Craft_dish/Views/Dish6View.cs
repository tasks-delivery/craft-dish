
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Text;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using Craft_dish.Adapters;
using Craft_dish.Models;
using Craft_dish.ViewModels;
using System.Collections.Generic;

namespace Craft_dish.Views
{
    [Activity(Label = "@string/app_name", Theme = "@style/NoActionBar", MainLauncher = false, ScreenOrientation = ScreenOrientation.Portrait)]
    public class Dish6View : AppCompatActivity
    {

        private ImageView dish_photo;

        private RecyclerView mRecycleView;

        private RecyclerView.LayoutManager mLayoutManager;

        private IngredientAdapter ingredientAdapater;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.activity_dish6);
            SetDefaultDishIcon();
            SetUpAdapter(LoadIngredients());
        }

        public void SetUpAdapter(List<Ingredient> ingredients)
        {
            ingredientAdapater = new IngredientAdapter(ingredients, this);
            mRecycleView = FindViewById<RecyclerView>(Resource.Id.dish6_recyclerView);
            mLayoutManager = new LinearLayoutManager(this);
            mRecycleView.SetLayoutManager(mLayoutManager);
            mRecycleView.SetAdapter(ingredientAdapater);
        }

        public List<Ingredient> LoadIngredients()
        {
            List<Ingredient> ingredientList = new List<Ingredient>();
            ingredientList.Add(new Ingredient(){ Name = "Ingredient 1", Weight = "200 grams" });
            ingredientList.Add(new Ingredient(){ Name = "Ingredient 2", Weight = "200 grams" });
            ingredientList.Add(new Ingredient(){ Name = "Ingredient 3", Weight = "200 grams" });
            ingredientList.Add(new Ingredient(){ Name = "Ingredient 4", Weight = "200 grams" });
            ingredientList.Add(new Ingredient(){ Name = "Ingredient 5", Weight = "200 grams" });
            ingredientList.Add(new Ingredient(){ Name = "Ingredient 6", Weight = "200 grams" });
            ingredientList.Add(new Ingredient(){ Name = "Ingredient 7", Weight = "200 grams" });
            ingredientList.Add(new Ingredient(){ Name = "Ingredient 8", Weight = "200 grams" });
            ingredientList.Add(new Ingredient(){ Name = "Ingredient 9", Weight = "200 grams" });
            ingredientList.Add(new Ingredient(){ Name = "Ingredient 10", Weight = "200 grams" });
            ingredientList.Add(new Ingredient(){ Name = "Ingredient 11", Weight = "200 grams" });
            ingredientList.Add(new Ingredient(){ Name = "Ingredient 12", Weight = "200 grams" });
            ingredientList.Add(new Ingredient(){ Name = "Ingredient 13", Weight = "200 grams" });
            ingredientList.Add(new Ingredient(){ Name = "Ingredient 14", Weight = "200 grams" });
            ingredientList.Add(new Ingredient(){ Name = "Ingredient 15", Weight = "200 grams" });
            return ingredientList;
        }
      
        private void SetDefaultDishIcon()
        {
            GradientDrawable gradientDrawable = new GradientDrawable();
            gradientDrawable.SetCornerRadius(200);
            gradientDrawable.SetColor(Color.DarkSlateGray);
            View view = (RelativeLayout)FindViewById(Resource.Id.dish6_photo_icon);
            view.SetBackgroundDrawable(gradientDrawable);
        }

    }
}