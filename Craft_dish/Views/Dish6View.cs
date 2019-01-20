
using Android.App;
using Android.OS;
using Android.Support.V7.App;

namespace Craft_dish.Views
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = false)]
    public class Dish6View : AppCompatActivity
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.activity_dish6);
        }

    }
}