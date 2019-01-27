using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Support.V7.App;

namespace Craft_dish.Views
{
    [Activity(Theme = "@style/MyTheme.Splash", MainLauncher = true, NoHistory = true, ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreenView : AppCompatActivity
    {

        //private string[] permissions = { "android.permission.WRITE_EXTERNAL_STORAGE", "android.permission.READ_PHONE_STATE", "android.permission.SYSTEM_ALERT_WINDOW", "android.permission.CAMERA" };   

        private bool back;

        public bool Back { get => back; set => back = value; }

        public override void OnCreate(Bundle bundle, PersistableBundle persistentState)
        {
            base.OnCreate(bundle, persistentState);     
        }

        protected override void OnResume()
        {
            base.OnResume();           
              Task startLoading = new Task(async () => {
                  RunOnUiThread(() => SetContentView(Resource.Layout.activity_splash_screen));
                  //  if (Build.VERSION.SdkInt >= Build.VERSION_CODES.M)
                  //  {
                  //      RequestPermissions(permissions, 200);
                  //
                  //  }
                  //
                  //  var cameraPermission = ContextCompat.CheckSelfPermission(Application.Context, Manifest.Permission.Camera);
                  //  var writeStoragePermission = ContextCompat.CheckSelfPermission(Application.Context, Manifest.Permission.WriteExternalStorage);
                  //  var readStoragePermission = ContextCompat.CheckSelfPermission(Application.Context, Manifest.Permission.ReadExternalStorage);
                  //  while (cameraPermission == Permission.Denied)
                  //  {
                  //      await Task.Delay(1000);
                  //  }
                  //
                  //  while (writeStoragePermission == Permission.Denied)
                  //  {
                  //      await Task.Delay(1000);
                  //  }
                  //
                  //  while (readStoragePermission == Permission.Denied)
                  //  {
                  //      await Task.Delay(1000);
                  //  }
                  await Task.Delay(4000);
                  if (Back == false)
                  {

                      StartActivity(new Intent(Application.Context, typeof(Dish1View)));
                  }
                  else
                  {
                      FinishAffinity();
                  }
              });
            startLoading.Start();
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