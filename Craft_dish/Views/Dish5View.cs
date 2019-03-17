using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Provider;
using Android.Runtime;
using Android.Graphics;
using System.IO;
using Android.Support.V7.App;
using Android.Content.PM;
using Craft_dish.ViewModels;
using Android.Views;
using Android.Util;
using Android.Support.V4.Content;
using Android;
using System;

namespace Craft_dish.Views
{
    [Activity(Label = "@string/dish_photo", Theme = "@style/AppTheme", MainLauncher = false, ScreenOrientation = ScreenOrientation.Portrait)]
    public class Dish5View : AppCompatActivity
    {
        private string tag = "CRAFT DISH";

        private ImageView icon_area;

        private string dish_name;

        private string navigation;

        private Dish5ViewModel dish5ViewModel;

        private Android.Net.Uri uri;

        private string photo_path;

        private RelativeLayout btn_camera;

        public static readonly int PickImageId = 1000;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.activity_dish5);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            var btn_share = (RelativeLayout)FindViewById(Resource.Id.dish5_share_icon);
            btn_camera = (RelativeLayout)FindViewById(Resource.Id.dish5_photo_icon);
            icon_area = FindViewById<ImageView>(Resource.Id.dish5_icon_area);
            dish5ViewModel = new Dish5ViewModel();         
            btn_camera.Click += BtnCamera_Click;
            btn_share.Click += OpenGallery;
            dish_name = Intent.GetStringExtra("dish_name");
            navigation = Intent.GetStringExtra("navigation");
        }  

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            Finish();
            return true;
        }

        [Java.Interop.Export("savePhoto")]
        public void SaveDishPhoto(View v)
        {                 
            dish5ViewModel.SetDishPhoto(dish_name, photo_path);          
            Intent intent = null;
            if(navigation == "Dish3")
            {
                intent = new Intent(Application.Context, typeof(Dish4View));
            }
            else
            {
                intent = new Intent(Application.Context, typeof(Dish7View));
                intent.PutExtra("dish_name", dish_name);
            }               
            StartActivity(intent);
            Finish();
        }

        private string GetPathToImage(Android.Net.Uri uri)
        {
            string doc_id = "";
            using (var c1 = ContentResolver.Query(uri, null, null, null, null))
            {
                c1.MoveToFirst();
                string document_id = c1.GetString(0);
                doc_id = document_id.Substring(document_id.LastIndexOf(":") + 1);
            }

            string path = null;

            // The projection contains the columns we want to return in our query.
            string selection = MediaStore.Images.Media.InterfaceConsts.Id + " =? ";
            using (var cursor = ManagedQuery(MediaStore.Images.Media.ExternalContentUri, null, selection, new string[] { doc_id }, null))
            {
                if (cursor == null) return path;
                var columnIndex = cursor.GetColumnIndexOrThrow(MediaStore.Images.Media.InterfaceConsts.Data);
                cursor.MoveToFirst();
                path = cursor.GetString(columnIndex);
            }
            return path;
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
          
            if ((requestCode == PickImageId) && (resultCode == Result.Ok) && (data != null))
            {
                uri = data.Data;               
                Log.Info(tag, GetPathToImage(uri));
                icon_area.SetImageURI(uri);
                photo_path = GetPathToImage(uri);            
            }
            else
            {
                try
                {
                    Bitmap bitmap = (Bitmap)data.Extras.Get("data");
                    icon_area.SetImageBitmap(ExportBitmapAsPNG(bitmap, dish_name));
                }
                catch(NullReferenceException)
                {
                    OnStart();
                }
                
            }
         
        }

        private void OpenGallery(object sender, System.EventArgs e)
        {
            Intent = new Intent();
            Intent.SetType("image/*");
            Intent.SetAction(Intent.ActionGetContent);
            StartActivityForResult(Intent.CreateChooser(Intent, "Select Picture"), PickImageId);
        }

        protected override void OnStart()
        {
            base.OnStart();         
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            if (requestCode == 200)
            {
                if ((grantResults.Length == 1) && (grantResults[0] == Permission.Granted))
                {
                    Intent intent = new Intent(MediaStore.ActionImageCapture);
                    StartActivityForResult(intent, 0);
                }
                else
                {
                    OnStart();
                }
            }
            else
            {
                base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            }
        }

        public void SetPermissions()
        {
            string[] permissions = { "android.permission.CAMERA" };
            RequestPermissions(permissions, 200);
        }

        private void BtnCamera_Click(object sender, System.EventArgs e)
        {
            var cam = ContextCompat.CheckSelfPermission(Application.Context, Manifest.Permission.Camera);
            if (cam == Permission.Denied)
            {
                SetPermissions();
            }
            else
            {
                Intent intent = new Intent(MediaStore.ActionImageCapture);
                StartActivityForResult(intent, 0);
            }
                      
        }

        public Bitmap ExportBitmapAsPNG(Bitmap bitmap, string dish_name)
        {
            string timeStamp = string.Format("{0:HH:mm:ss tt}", DateTime.Now);
            var path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
            var filePath = System.IO.Path.Combine(path,  dish_name + timeStamp + ".png");
            Log.Info(tag, filePath);
            photo_path = filePath;
            var stream = new FileStream(filePath, FileMode.Create);
            bitmap.Compress(Bitmap.CompressFormat.Png, 100, stream);
            stream.Close();
            return bitmap;
        }   

    }
}