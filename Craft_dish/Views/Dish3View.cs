using System;
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
    [Activity(Label = "@string/new_dish", Theme = "@style/NoActionBar", MainLauncher = false)]
    class Dish3View : AppCompatActivity
    {

        private Button btn_skip;

        private Button btn_attach;

        private TextView text1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.activity_dish3);
            btn_attach = (Button)FindViewById(Resource.Id.dish3_btn_attach);
            btn_skip = (Button)FindViewById(Resource.Id.dish3_btn_skip);
            text1 = (TextView)FindViewById(Resource.Id.dish3_text1);          
        }

    }
}