﻿using System.Threading;
using System.Threading.Tasks;
using Android;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Support.V4.Content;
using Android.Support.V7.App;

namespace Craft_dish.Views
{
    [Activity(Theme = "@style/MyTheme.Splash", MainLauncher = true, ConfigurationChanges = ConfigChanges.Locale, NoHistory = true, ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreenView : AppCompatActivity
    {

        private CancellationTokenSource tokenSource;

        private CancellationToken cancellationToken;

        private bool back;

        public bool Back { get => back; set => back = value; }

        public override void OnCreate(Bundle bundle, PersistableBundle persistentState)
        {
            base.OnCreate(bundle, persistentState);            
            SetPermissions();
        }

        public void SetPermissions()
        {
            string[] permissions = 
                {
                "android.permission.WRITE_EXTERNAL_STORAGE",
                "android.permission.READ_PHONE_STATE",
                "android.permission.SYSTEM_ALERT_WINDOW"
                };             
            RequestPermissions(permissions, 200);
        }

        protected override void OnResume()
        {
            base.OnResume();
            tokenSource = new CancellationTokenSource();
            Task startLoading = new Task(async () =>
           {
               cancellationToken.ThrowIfCancellationRequested();
               RunOnUiThread(() => SetContentView(Resource.Layout.activity_splash_screen));     
               await Task.Delay(4000);
               if (Back == false)
               {
                    StartActivity(new Intent(Application.Context, typeof(Dish1View)));    
               }
               else
               {
                   FinishAffinity();
               }
           }, tokenSource.Token);

            var phoneStorage = ContextCompat.CheckSelfPermission(Application.Context, Manifest.Permission.ReadExternalStorage);
            if (phoneStorage != Permission.Denied)
            {
                startLoading.Start();
            }
            else
            {
                tokenSource.Cancel();
                tokenSource.Dispose();
                SetPermissions();
            }        
        }       

        public override void OnBackPressed()
        {            
            base.OnBackPressed();           
            Back = true;
            Back.ToString();
            FinishAffinity();
        }

    }
}