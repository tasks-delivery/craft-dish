
using Android.App;
using Android.Content;
using Android.Content.PM;
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

    [Activity(Label = "@string/new_dish", Theme = "@style/NoActionBar", ConfigurationChanges = ConfigChanges.Locale, MainLauncher = false, ScreenOrientation = ScreenOrientation.Portrait)]
    public class Dish4View : AppCompatActivity
    {

        private EditText search_field;

        private ImageView search_icon;

        private ImageView close_icon;

        private RecyclerView mRecycleView;

        private RecyclerView.LayoutManager mLayoutManager;

        private Dish4ViewModel dish4ViewModel;

        [Java.Interop.Export("openDish2")]
        public void GoToDish2(View v)
        {
            StartActivity(new Intent(Application.Context, typeof(Dish2View)));
            Finish();
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

        [Java.Interop.Export("openSearch")]
        public void ShownSearchField(View v)
        {
            search_field.Visibility = ViewStates.Visible;
            close_icon.Visibility = ViewStates.Visible;
            search_icon.Visibility = ViewStates.Invisible;
            ShowKeyboard(this, search_field);
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

        [Java.Interop.Export("closeSearch")]
        public void HideSearchField(View v)
        {
            search_field.Visibility = ViewStates.Invisible;
            close_icon.Visibility = ViewStates.Invisible;
            search_icon.Visibility = ViewStates.Visible;
            search_field.Text = "";
            HideKeyboard(this, search_field);
            LoadDishes();
        }

        protected override void OnPause()
        {
            base.OnPause();
            HideKeyboard(this, search_field);
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.activity_dish4);
            search_field = (EditText)FindViewById(Resource.Id.dish4_search_field);
            search_icon = (ImageView)FindViewById(Resource.Id.dish4_search_icon);
            close_icon = (ImageView)FindViewById(Resource.Id.dish4_close_search_icon);
            search_field.Visibility = ViewStates.Invisible;
            close_icon.Visibility = ViewStates.Invisible;
            LoadDishes();
            search_field.TextChanged += SearchDish;
        }

        private void SetUpAdapter(List<Dish> dishes)
        {
            DishAdapter dishAdapter = new DishAdapter(dishes, this);
            mRecycleView = FindViewById<RecyclerView>(Resource.Id.recyclerView);
            mLayoutManager = new LinearLayoutManager(this);
            mRecycleView.SetLayoutManager(mLayoutManager);
            dishAdapter.ItemClick += MAdapter_ItemClick;
            mRecycleView.SetAdapter(dishAdapter);
        }

        private void LoadDishes()
        {
            dish4ViewModel = new Dish4ViewModel();
            if (dish4ViewModel.DishesIsExist() == true)
            {
                SetUpAdapter(dish4ViewModel.LoadDishes());
            }  
        }

        private void SearchDish(object sender, TextChangedEventArgs e)
        {
            SetUpAdapter(dish4ViewModel.SearchDishByName(search_field.Text));
        }
     
        private void MAdapter_ItemClick(object sender, int e)
        {
            var item = dish4ViewModel.SearchDishByName(search_field.Text)[e];
            Intent intent = new Intent(Application.Context, typeof(Dish6View));
            intent.PutExtra("dish_name", item.Name);
            StartActivity(intent);
        }

    }

}         
