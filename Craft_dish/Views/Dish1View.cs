﻿using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Content;

namespace Craft_dish
{
    [Activity(Label = "@string/app_name", Theme = "@style/NoActionBar", MainLauncher = false)]
    public class Dish1View : AppCompatActivity
    {

        [Java.Interop.Export("openGitHub")]
        public void button_OnClick(View v)
        {
            var uri = Android.Net.Uri.Parse("https://github.com/tasks-delivery/craft-dish/issues");
            var intent = new Intent(Intent.ActionView, uri);
            StartActivity(intent);
        }

        [Java.Interop.Export("openDish4")]
        public void goToDish4(View v)
        {
            StartActivity(new Intent(Application.Context, typeof(Views.Dish4View)));        
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