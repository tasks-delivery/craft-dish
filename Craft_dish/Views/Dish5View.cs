﻿
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Support.V7.App;

namespace Craft_dish.Views
{
    [Activity(Label = "@string/dish_photo", Theme = "@style/AppTheme", MainLauncher = false, ScreenOrientation = ScreenOrientation.Portrait)]
    public class Dish5View : AppCompatActivity
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.activity_dish5);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
        }

    }
}