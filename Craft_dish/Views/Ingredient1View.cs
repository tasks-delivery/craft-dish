
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Text;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;

namespace Craft_dish.Views
{

    [Activity(Label = "@string/new_dish", Theme = "@style/NoActionBar", MainLauncher = false, ScreenOrientation = ScreenOrientation.Portrait)]
    public class Ingredient1View : AppCompatActivity
    {

        private EditText search_field;

        private ImageView search_icon;

        private ImageView close_icon;

        private RecyclerView mRecycleView;

        private RecyclerView.LayoutManager mLayoutManager;

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
            search_field = (EditText)FindViewById(Resource.Id.ingredient1_search_field);
            search_icon = (ImageView)FindViewById(Resource.Id.ingredient1_search_icon);
            close_icon = (ImageView)FindViewById(Resource.Id.ingredient1_close_search_icon);
            search_field.Visibility = ViewStates.Invisible;
            close_icon.Visibility = ViewStates.Invisible;
            search_field.TextChanged += SearchIngredient;
        }

        [Java.Interop.Export("openSearch")]
        public void ShownSearchField(View v)
        {
            search_field.Visibility = ViewStates.Visible;
            close_icon.Visibility = ViewStates.Visible;
            search_icon.Visibility = ViewStates.Invisible;
            ShowKeyboard(this, search_field);
        }

        [Java.Interop.Export("closeSearch")]
        public void HideSearchField(View v)
        {
            search_field.Visibility = ViewStates.Invisible;
            close_icon.Visibility = ViewStates.Invisible;
            search_icon.Visibility = ViewStates.Visible;
            search_field.Text = "";
            HideKeyboard(this, search_field);
        }

        private void SearchIngredient(object sender, TextChangedEventArgs e)
        {
           
        }

        [Java.Interop.Export("back")]
        public void Back(View v)
        {
            OnBackPressed();
        }

    }
}