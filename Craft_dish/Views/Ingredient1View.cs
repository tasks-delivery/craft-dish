﻿
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Text;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using Craft_dish.Adapters;
using Craft_dish.Models;
using Craft_dish.ViewModels;
using System;
using System.Collections.Generic;

namespace Craft_dish.Views
{

    [Activity(Label = "@string/new_dish", Theme = "@style/NoActionBar", ConfigurationChanges = ConfigChanges.Locale, MainLauncher = false, ScreenOrientation = ScreenOrientation.Portrait)]
    public class Ingredient1View : AppCompatActivity
    {

        private EditText search_field;

        private ImageView search_icon;

        private ImageView close_icon;

        private Ingredient1ViewModel ingredient1ViewModel;

        private IngredientAdapter ingredientAdapter;

        private RelativeLayout checkbox_menu;

        private List<Ingredient> ingredients;

        private List<Ingredient> ingredientsAddList;

        private List<Ingredient> ingredientsRemovedList;

        private Button add_ingredient_button;

        private Button select_all_button;

        private Button cancel_button;

        private FloatingActionButton floating_add_ingredient_button;

        private string navigateFrom;

        private Intent navigateToIngredient2;

        private string dish_name;

        private bool searchState;

        protected override void OnPause()
        {
            base.OnPause();
            HideKeyboard(this, search_field);
        }

        private static void HideKeyboard(Activity activity, View pView)
        {
            InputMethodManager inputMethodManager = activity.GetSystemService(InputMethodService) as InputMethodManager;
            inputMethodManager.HideSoftInputFromWindow(pView.WindowToken, HideSoftInputFlags.None);
        }

        private static void ShowKeyboard(Activity activity, View pView)
        {
            pView.RequestFocus();
            InputMethodManager inputMethodManager = activity.GetSystemService(InputMethodService) as InputMethodManager;
            inputMethodManager.ShowSoftInput(pView, ShowFlags.Forced);
            inputMethodManager.ToggleSoftInput(ShowFlags.Forced, HideSoftInputFlags.ImplicitOnly);
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.activity_ingredient1);
            ingredient1ViewModel = new Ingredient1ViewModel();
            dish_name = Intent.GetStringExtra("dish_name");
            search_field = (EditText)FindViewById(Resource.Id.ingredient1_search_field);
            search_icon = (ImageView)FindViewById(Resource.Id.ingredient1_search_icon);
            close_icon = (ImageView)FindViewById(Resource.Id.ingredient1_close_search_icon);
            checkbox_menu = (RelativeLayout)FindViewById(Resource.Id.ingredient1_checkbox_menu);
            add_ingredient_button = (Button)FindViewById(Resource.Id.ingredient1_add_button);
            floating_add_ingredient_button= (FloatingActionButton)FindViewById(Resource.Id.fab);
            select_all_button = (Button)FindViewById(Resource.Id.ingredient1_select_all_btn);
            cancel_button = (Button)FindViewById(Resource.Id.ingredient1_cancel_btn);
            search_field.TextChanged += SearchIngredient;
            search_field.Visibility = ViewStates.Invisible;
            close_icon.Visibility = ViewStates.Invisible;
            checkbox_menu.Visibility = ViewStates.Gone;            
            ingredients = new List<Ingredient>();         
        }

        private void NavigateResolverForIngredient2()
        {
            LoadIngredients();
            ingredientsAddList = new List<Ingredient>();
            navigateToIngredient2 = new Intent(Application.Context, typeof(Ingredient2View));
        }

        private void PutExtraForIngredient1()
        {
            NavigateResolverForIngredient2();
            add_ingredient_button.Visibility = ViewStates.Gone;
            navigateToIngredient2.PutExtra("navigateFrom", "Ingredient1");
        }

        private void PutExtraForIngredient1FromAddedScreen()
        {
            NavigateResolverForIngredient2();
            add_ingredient_button.Visibility = ViewStates.Visible;
            navigateToIngredient2.PutExtra("navigateFrom", "Ingredient1Add");
            navigateToIngredient2.PutExtra("dish_name", dish_name);
        }

        private void NavigateResolver()
        {
            navigateFrom = Intent.GetStringExtra("navigateFrom");
            switch (navigateFrom)
            {            
                case "Dish1" :
                    PutExtraForIngredient1();
                    break;

                case "Ingredient2":
                    PutExtraForIngredient1();
                    break;

                case "Dish6Add":
                    PutExtraForIngredient1FromAddedScreen();
                    break;             

                case "Ingredient2Add":             
                    PutExtraForIngredient1FromAddedScreen();
                    break;

                case "Dish6Remove":
                    ingredientsRemovedList = new List<Ingredient>();
                    navigateToIngredient2 = new Intent(Application.Context, typeof(Ingredient2View));
                    add_ingredient_button.Visibility = ViewStates.Gone;
                    floating_add_ingredient_button.Visibility = ViewStates.Gone;
                    IList<Ingredient> dishIngredients = ingredient1ViewModel.LoadDishIngredients(dish_name);
                    ingredientAdapter = new IngredientAdapter(dishIngredients, this, false);
                    SetUpAdapter(ingredientAdapter);
                    navigateToIngredient2.PutExtra("navigateFrom", "Ingredient1Remove");
                    break;

                default:
                    throw new InvalidOperationException("Unexpected value = " + navigateFrom);
            }
     
        }

        [Java.Interop.Export("openSearch")]
        public void ShownSearchField(View v)
        {
            search_field.Visibility = ViewStates.Visible;
            close_icon.Visibility = ViewStates.Visible;
            search_icon.Visibility = ViewStates.Invisible;
            ShowKeyboard(this, search_field);       
        }

        private void HideSearchElements()
        {
            search_field.Visibility = ViewStates.Invisible;
            close_icon.Visibility = ViewStates.Invisible;
            search_icon.Visibility = ViewStates.Visible;
            search_field.Text = "";
            HideKeyboard(this, search_field);
            NavigateResolver();
            checkbox_menu.Visibility = ViewStates.Gone;
        }

        [Java.Interop.Export("closeSearch")]
        public void HideSearchField(View v)
        {
            HideSearchElements();
        }

        [Java.Interop.Export("openIngredient2")]
        public void GoToIngredient2(View v)
        {
            StartActivity(navigateToIngredient2);
            Finish();
        }

        private void SearchResolver()
        {
            if (navigateFrom == "Dish6Remove")
            {
                ingredients = ingredient1ViewModel.SearchDishIngredientByName(dish_name, search_field.Text);
                ingredientAdapter = new IngredientAdapter(ingredients, this, false);
            }
            else
            {
                ingredients = ingredient1ViewModel.SearchIngredientByName(search_field.Text);
                ingredientAdapter = new IngredientAdapter(ingredients, this, false);
            }
        }

        private void SearchIngredient(object sender, TextChangedEventArgs e)
        {
            SearchResolver();
            searchState = true;
            SetUpAdapter(ingredientAdapter);
        }

        private void SetUpAdapter(IngredientAdapter ingredientAdapter)
        {
            RecyclerView recyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);
            RecyclerView.LayoutManager mLayoutManager = new LinearLayoutManager(this);
            recyclerView.SetLayoutManager(mLayoutManager);
            ingredientAdapter.ItemClick += OnItemClick;
            ingredientAdapter.ItemUnClick += OnItemRemove;
            recyclerView.SetAdapter(ingredientAdapter);         
        }

        private void LoadIngredients()
        {
            ingredients = ingredient1ViewModel.LoadIngredients();
            ingredientAdapter = new IngredientAdapter(ingredients, this, false);
            SetUpAdapter(ingredientAdapter);
        }

        [Java.Interop.Export("back")]
        public void Back(View v)
        {
            OnBackPressed();
        }

        public override void OnBackPressed()
        {
            base.OnBackPressed();
            StartActivity(new Intent(Application.Context, typeof(Dish1View)));
            Finish();
        }

        [Java.Interop.Export("removeIngredients")]
        public void RemoveIngredient(View v)
        {
            if (navigateFrom == "Dish6Remove")
            {
                ingredient1ViewModel.RemoveDishIngredients(dish_name, ingredientsRemovedList);
            }
            else
            {
                ingredient1ViewModel.RemoveIngredients(ingredientsAddList);               
            }
            checkbox_menu.Visibility = ViewStates.Gone;

            if(searchState == false)
            {
                NavigateResolver();
            }
            else
            {
                SearchResolver();
                SetUpAdapter(ingredientAdapter);
            }
        }

        [Java.Interop.Export("addIngredients")]
        public void AddIngredient(View v)
        {
            ingredient1ViewModel.AddIngredients(dish_name, ingredientsAddList);
            checkbox_menu.Visibility = ViewStates.Gone;
            Intent intent = new Intent(Application.Context, typeof(Dish6View));
            intent.PutExtra("dish_name", dish_name);
            StartActivity(intent);
        }

        private void SelectAllBtnListener()
        {
            select_all_button.Click += (sender, e) => {
                if (navigateFrom == "Dish6Remove")
                {
                    IList<Ingredient> dishIngredients = ingredient1ViewModel.LoadDishIngredients(dish_name);
                    ingredientsRemovedList.Clear();
                    for (int i = 0; i < dishIngredients.Count; i++)
                    {
                        OnItemClick(sender, i);
                    }
                    ingredientAdapter = new IngredientAdapter(dishIngredients, this, true);
                    SetUpAdapter(ingredientAdapter);
                }
                else
                {
                    ingredientsAddList.Clear();
                    for (int i = 0; i < ingredients.Count; i++)
                    {
                        OnItemClick(sender, i);
                    }
                    ingredientAdapter = new IngredientAdapter(ingredients, this, true);
                    SetUpAdapter(ingredientAdapter);
                }
            };
        }

        private void CancelBtnListener()
        {
            cancel_button.Click += (sender, e) => {
                for (int i = 0; i < ingredients.Count; i++)
                {
                    OnItemRemove(sender, i);
                }
                ingredients = ingredient1ViewModel.LoadIngredients();
                ingredientAdapter = new IngredientAdapter(ingredients, this, false);
                SetUpAdapter(ingredientAdapter);
                checkbox_menu.Visibility = ViewStates.Gone;
            };
        }

        protected override void OnStart()
        {
            base.OnStart();
            NavigateResolver();
            SelectAllBtnListener();
            CancelBtnListener();
        }

        void OnItemRemove(object sender, int position)
        {
            if (navigateFrom == "Dish6Remove")
            {
                IList<Ingredient> dishIngredients = ingredient1ViewModel.LoadDishIngredients(dish_name);
                Ingredient ingredient = dishIngredients[position];
                ingredientsRemovedList.Remove(ingredient);
            }
            else
            {
                Ingredient ingredient = ingredient1ViewModel.SearchIngredientByName(search_field.Text)[position];
                ingredientsAddList.Remove(ingredient);
            }
        }

        void OnItemClick(object sender, int position)
        {
            checkbox_menu.Visibility = ViewStates.Visible;
            if (navigateFrom == "Dish6Remove")
            {
                IList<Ingredient> dishIngredients = ingredient1ViewModel.LoadDishIngredients(dish_name);
                Ingredient ingredient = dishIngredients[position];        
                ingredientsRemovedList.Add(ingredient);
            }
            else
            {
                Ingredient ingredient = ingredient1ViewModel.SearchIngredientByName(search_field.Text)[position];
                ingredientsAddList.Add(ingredient);           
            }

        }

    }
}