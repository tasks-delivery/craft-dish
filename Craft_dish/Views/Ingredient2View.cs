﻿using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Content.PM;
using Android.Views;
using Android.Widget;
using System;
using Craft_dish.ViewModels;
using Android.Content;
using Craft_dish.Views;
using Android.Util;

namespace Craft_dish
{
    [Activity(Label = "@string/new_ingredient", Theme = "@style/AppTheme", ConfigurationChanges = ConfigChanges.Locale, MainLauncher = false, ScreenOrientation = ScreenOrientation.Portrait)]
    public class Ingredient2View : AppCompatActivity
    {

        private Spinner weight_unit_spinner;

        private EditText field_name;

        private EditText field_weight;

        private Ingredient2ViewModel ingredient2ViewModel;

        private string weight_unit;

        private string navigateFrom;

        private Intent navigateToIngredient1;

        private string tag = "CRAFT DISH";

        private string dish_name;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.activity_ingredient2);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            dish_name = Intent.GetStringExtra("dish_name");
            field_name = (EditText)FindViewById(Resource.Id.ingredient2_field_ingredient_name);
            field_weight = (EditText)FindViewById(Resource.Id.ingredient2_field_ingredient_weight);
            weight_unit_spinner = FindViewById<Spinner>(Resource.Id.ingredient2_weight_unit_spinner);
            weight_unit_spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            ingredient2ViewModel = new Ingredient2ViewModel();
            NavigateResolver();
        }

        private void NavigateResolver()
        {
            navigateFrom = Intent.GetStringExtra("navigateFrom");
            Log.Info(tag, "Navigate from " + navigateFrom);
            Log.Info(tag, "Dish is " + dish_name);
            switch (navigateFrom)
            {

                case "Ingredient1":
                    navigateToIngredient1 = new Intent(Application.Context, typeof(Ingredient1View));
                    navigateToIngredient1.PutExtra("navigateFrom", "Ingredient2");                
                    break;
     
                case "Ingredient1Add":
                    navigateToIngredient1 = new Intent(Application.Context, typeof(Ingredient1View));
                    navigateToIngredient1.PutExtra("navigateFrom", "Ingredient2Add");
                    navigateToIngredient1.PutExtra("dish_name", dish_name);
                    break;
            }

        }

        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            weight_unit_spinner = (Spinner)sender;
            weight_unit = weight_unit_spinner.GetItemAtPosition(e.Position).ToString();
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            OnBackPressed();
            return true;
        }

        public override void OnBackPressed()
        {
            base.OnBackPressed();
            StartActivity(navigateToIngredient1);
            Finish();
        }

        [Java.Interop.Export("openIngredient1")]
        public void ButtonSaveIngredient(View v)
        {
            if (field_name.Text.Length <= 0 || field_name.Text.Trim() == "")
            {
                field_name.Error = GetString(Resource.String.ingredient_warning1);
            }
            else
            {
                ingredient2ViewModel.SaveIngredient(field_name.Text, field_weight.Text, weight_unit);                            
                StartActivity(navigateToIngredient1);
                Finish();
            }

        }

    }

}