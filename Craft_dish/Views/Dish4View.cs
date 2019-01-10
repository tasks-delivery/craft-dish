
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;

namespace Craft_dish.Views
{

    [Activity(Label = "@string/new_dish", Theme = "@style/AppTheme", MainLauncher = false)]
    public class Dish4View : AppCompatActivity
    {

        [Java.Interop.Export("openDish2")]
        public void goToDish2(View v)
        {
            StartActivity(new Intent(Application.Context, typeof(Views.Dish2View)));
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.activity_dish4);
        }

    }
}