using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Content;
using Android.Content.PM;
using Craft_dish.Views;

namespace Craft_dish
{
    [Activity(Label = "@string/app_name", Theme = "@style/NoActionBar", MainLauncher = false, ScreenOrientation = ScreenOrientation.Portrait)]
    public class Dish1View : AppCompatActivity
    {        

        [Java.Interop.Export("openGitHub")]
        public void Button_OnClick(View v)
        {
            var uri = Android.Net.Uri.Parse("https://github.com/tasks-delivery/craft-dish/issues");
            var intent = new Intent(Intent.ActionView, uri);
            StartActivity(intent);
        }

        [Java.Interop.Export("openDish4")]
        public void GoToDish4(View v)
        {
            StartActivity(new Intent(Application.Context, typeof(Dish4View)));
        }

        [Java.Interop.Export("openIngredient1")]
        public void GoToIngredient1(View v)
        {
            StartActivity(new Intent(Application.Context, typeof(Ingredient1View)));
        }

        public override void OnBackPressed()
        {
            FinishAffinity();
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.activity_dish1);
        }
    }
}