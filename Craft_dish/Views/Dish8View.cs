
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Support.V7.App;

namespace Craft_dish.Views
{

    [Activity(Label = "@string/new_dish", Theme = "@style/NoActionBar", MainLauncher = false, ScreenOrientation = ScreenOrientation.Portrait)]
    public class Dish8View : AppCompatActivity
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.activity_dish8);
        }

    }

}