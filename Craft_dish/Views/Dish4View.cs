
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace Craft_dish.Views
{

    [Activity(Label = "@string/new_dish", Theme = "@style/NoActionBar", MainLauncher = false)]
    public class Dish4View : AppCompatActivity
    {

        private EditText search_field;

        private ImageView search_icon;

        private ImageView close_icon;

        private Toolbar toolbar;

        [Java.Interop.Export("openDish2")]
        public void GoToDish2(View v)
        {
            StartActivity(new Intent(Application.Context, typeof(Views.Dish2View)));
        }

        [Java.Interop.Export("openSearch")]
        public void ShownSearchField(View v)
        {
            search_field.Visibility = ViewStates.Visible;
            close_icon.Visibility = ViewStates.Visible;
            search_icon.Visibility = ViewStates.Invisible;
        }

        [Java.Interop.Export("back")]
        public void Back(View v)
        {
            OnBackPressed();
        }

        [Java.Interop.Export("closeSearch")]
        public void HideSearchField(View v)
        {
            search_field.Visibility = ViewStates.Invisible;
            close_icon.Visibility = ViewStates.Invisible;
            search_icon.Visibility = ViewStates.Visible;
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
        }
   
    }
}