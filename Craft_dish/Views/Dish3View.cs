
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace Craft_dish.Views
{
    [Activity(Label = "@string/new_dish", Theme = "@style/NoActionBar", ConfigurationChanges = ConfigChanges.Locale, MainLauncher = false, ScreenOrientation = ScreenOrientation.Portrait)]
    class Dish3View : AppCompatActivity
    {

        private Button btn_skip;

        private Button btn_attach;

        private string dish_name;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.activity_dish3);
            btn_attach = (Button)FindViewById(Resource.Id.dish3_btn_attach);
            btn_skip = (Button)FindViewById(Resource.Id.dish3_btn_skip);            
            dish_name = Intent.GetStringExtra("dish_name");
        }

        protected override void OnStart()
        {
            base.OnStart();
            if(Resources.Configuration.Locale.Language == "ru")
            {
                btn_skip.Visibility = ViewStates.Gone;
                btn_attach.Visibility = ViewStates.Gone;
            }          
        }

        [Java.Interop.Export("openDish4")]
        public void goToDish4(View v)
        {
            StartActivity(new Intent(Application.Context, typeof(Dish4View)));
        }

        [Java.Interop.Export("openDish5")]
        public void goToDish5(View v)
        {
            Intent intent = new Intent(Application.Context, typeof(Dish5View));
            intent.PutExtra("dish_name", dish_name);
            intent.PutExtra("navigation", "Dish3");
            StartActivity(intent);
        }

    }
}