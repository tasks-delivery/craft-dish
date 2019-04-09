using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Content;
using Android.Content.PM;
using Craft_dish.Views;
using Android.Widget;

namespace Craft_dish
{
    [Activity(Label = "@string/app_name", Theme = "@style/NoActionBar", MainLauncher = false, ConfigurationChanges = ConfigChanges.Locale, ScreenOrientation = ScreenOrientation.Portrait)]
    public class Dish1View : AppCompatActivity
    {
        private static Context context;

        [Java.Interop.Export("openGitHub")]
        public static void Button_OnClick(View v)
        {
            var uri = Android.Net.Uri.Parse("https://github.com/tasks-delivery/craft-dish/issues");
            var intent = new Intent(Intent.ActionView, uri);
            context.StartActivity(intent);
        }

        [Java.Interop.Export("openDish4")]
        public static void GoToDish4(View v)
        {
            context.StartActivity(new Intent(context, typeof(Dish4View)));
        }

        [Java.Interop.Export("openIngredient1")]
        public static void GoToIngredient1(View v)
        {
            Intent intent = new Intent(Application.Context, typeof(Ingredient1View));
            intent.PutExtra("navigateFrom", "Dish1");
            context.StartActivity(intent);
        }

        public override void OnBackPressed()
        {
            FinishAffinity();
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.activity_dish1);
            TextView ingredients_btn = (TextView)FindViewById(Resource.Id.dish1_ingredients_btn);
            context = this;
        }

    }
}