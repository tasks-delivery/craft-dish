using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace Craft_dish.Views
{
    [Activity(Theme = "@style/MyTheme.Splash", MainLauncher = true, NoHistory = true)]
    public class SplashScreenView : AppCompatActivity
    {
        public override void OnCreate(Bundle savedInstanceState, PersistableBundle persistentState)
        {
            base.OnCreate(savedInstanceState, persistentState);
        }

        protected override void OnResume()
        {
            base.OnResume();           
              Task startLoading = new Task(async () => {
                  RunOnUiThread(() => SetContentView(Resource.Layout.activity_splash_screen));
                  await Task.Delay(4000);
                  StartActivity(new Intent(Application.Context, typeof(Dish1View)));
              });
              startLoading.Start();
        }

    }
}