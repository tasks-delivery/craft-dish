using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Views;
using Android.Media;
using static Android.Resource;
using Android.Content;

namespace Craft_dish
{
    [Activity(Label = "@string/app_name", Theme = "@style/NoActionBar", MainLauncher = true)]
    public class Dish1View : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_dish1);
        }
    }
}