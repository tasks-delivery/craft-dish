using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace Craft_dish.Views
{

    [Activity(Label = "@string/new_dish", Theme = "@style/AppTheme", MainLauncher = false)]
    public class Dish2View : AppCompatActivity
    {

        private EditText field_name;

        private TextInputLayout text1_container;

        protected override void OnCreate(Bundle savedInstanseState)
        {
            base.OnCreate(savedInstanseState);
            SetContentView(Resource.Layout.activity_dish2);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            text1_container = (TextInputLayout)FindViewById(Resource.Id.text_container_1);
            field_name = (EditText)FindViewById(Resource.Id.dish_2_field_dish_name);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {   
            Finish();          
            return true;
        }

        [Java.Interop.Export("openDish4")]
        public void buttonSaveDish(View v)
        {
            showError();
        }

        private void showError()
        {            
            field_name.Error = GetString(Resource.String.dish_warning1);
        }

    }
}