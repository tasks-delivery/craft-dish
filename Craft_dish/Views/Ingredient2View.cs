using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Content.PM;

namespace Craft_dish
{
    [Activity(Label = "@string/app_name", Theme = "@style/NoActionBar", MainLauncher = false, ScreenOrientation = ScreenOrientation.Portrait)]
    public class Ingredient2View : AppCompatActivity
    {        

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.activity_ingredient2);
        }

    }

}