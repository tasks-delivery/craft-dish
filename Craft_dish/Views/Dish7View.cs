
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Support.V7.App;

namespace Craft_dish.Views
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = false, ScreenOrientation = ScreenOrientation.Portrait)]
    public class Dish7View : AppCompatActivity
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.activity_dish7);
        }

    }
}