using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Content.PM;
using Android.Views;
using Android.Widget;
using System;

namespace Craft_dish
{
    [Activity(Label = "@string/new_ingredient", Theme = "@style/AppTheme", MainLauncher = false, ScreenOrientation = ScreenOrientation.Portrait)]
    public class Ingredient2View : AppCompatActivity
    {

        private Spinner weight_unit_spinner;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.activity_ingredient2);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            weight_unit_spinner = FindViewById<Spinner>(Resource.Id.ingredient2_weight_unit_spinner);
            weight_unit_spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
        }    

        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            weight_unit_spinner = (Spinner)sender;            
            string toast = string.Format("The weight is {0}", weight_unit_spinner.GetItemAtPosition(e.Position));
            //Toast.MakeText(this, toast, ToastLength.Long).Show();
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            OnBackPressed();
            return true;
        }

    }

}