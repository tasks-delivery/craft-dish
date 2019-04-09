
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using Craft_dish.ViewModels;

namespace Craft_dish.Views
{

    [Activity(Label = "@string/new_dish", Theme = "@style/AppTheme", ConfigurationChanges = ConfigChanges.Locale, MainLauncher = false, ScreenOrientation = ScreenOrientation.Portrait)]
    public class Dish2View : AppCompatActivity
    {

        private EditText field_name;

        private EditText field_description;

        private Dish2ViewModel dish2ViewModel;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.activity_dish2);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            field_name = (EditText)FindViewById(Resource.Id.dish_2_field_dish_name);
            field_description = (EditText)FindViewById(Resource.Id.dish_2_field_dish_description);
            dish2ViewModel = new Dish2ViewModel();
        }       

        protected override void OnStart()
        {
            base.OnStart();
            field_description.SetHorizontallyScrolling(false);
            field_description.SetMaxLines(5);
            field_description.ImeOptions = ImeAction.Done;
        }

        public override void OnBackPressed()
        {
            base.OnBackPressed();
            StartActivity(new Intent(Application.Context, typeof(Dish4View)));
            Finish();
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            OnBackPressed();         
            return true;
        }

        [Java.Interop.Export("openDish3")]
        public void ButtonSaveDish(View v)
        {
            if(dish2ViewModel.DishIsExists(field_name.Text) == true)
            {
                field_name.Error = GetString(Resource.String.dish_warning1);
            }
            else
            {

                if (field_name.Text.Length <= 0 || field_name.Text.Trim() == "")
                {
                    field_name.Error = GetString(Resource.String.dish_warning2);
                }
                else
                {
                    dish2ViewModel.SaveDish(field_name.Text, field_description.Text);
                    Intent intent = new Intent(Application.Context, typeof(Dish3View));
                    intent.PutExtra("dish_name", field_name.Text);
                    StartActivity(intent);
                    Finish();
                }
          
            }
                           
        }

    }

}