﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace Craft_dish.Views
{

    [Activity(Label = "@string/new_dish", Theme = "@style/AppTheme", MainLauncher = false)]
    public class Dish4View : AppCompatActivity
    {


        [Java.Interop.Export("openDish2")]
        public void goToDish2(View v)
        {
            StartActivity(new Intent(Application.Context, typeof(Views.Dish2View)));
        }

        protected override void OnCreate(Bundle savedInstanseState)
        {
            base.OnCreate(savedInstanseState);
            SetContentView(Resource.Layout.activity_dish4);
        }

    }
}