
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Support.V7.App;
using Android.Text;
using Android.Views;
using Android.Widget;
using Craft_dish.ViewModels;

namespace Craft_dish.Views
{
    [Activity(Label = "@string/edit_dish", Theme = "@style/AppTheme", MainLauncher = false, ScreenOrientation = ScreenOrientation.Portrait)]
    public class Dish7View : AppCompatActivity
    {

        private string dish_name;

        private EditText field_description;

        private EditText field_name;

        private Dish7ViewModel dish7ViewModel;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.activity_dish7);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);          
            dish_name = Intent.GetStringExtra("dish_name");
            dish7ViewModel = new Dish7ViewModel(dish_name, this);
            field_description = (EditText)FindViewById(Resource.Id.dish_7_field_dish_description);
            field_name = (EditText)FindViewById(Resource.Id.dish_7_field_dish_name);
            field_description.Text = dish7ViewModel.FindDishDescription();
            field_name.Text = dish7ViewModel.FindDishName();
        }

        [Java.Interop.Export("openDish8")]
        public void ButtonSaveDish(View v)
        {
            if (dish7ViewModel.dishIsExists(field_name.Text) == true)
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
                    dish7ViewModel.saveDish(dish_name, field_name.Text, field_description.Text);
                    Intent intent = new Intent(Application.Context, typeof(Dish8View));
                    StartActivity(intent);
                    Finish();
                }
               
            }

        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            OnBackPressed();
            Finish();
            return true;
        }

        public override void OnBackPressed()
        {
            base.OnBackPressed();
            Intent intent = new Intent(Application.Context, typeof(Dish6View));
            intent.PutExtra("dish_name", dish_name);
            StartActivity(intent);
            Finish();
        }

        [Java.Interop.Export("openDish5")]
        public void goToDish5(View v)
        {
            Intent intent = new Intent(Application.Context, typeof(Dish5View));
            intent.PutExtra("dish_name", dish_name);
            intent.PutExtra("navigation", "Dish7");
            StartActivity(intent);
        }

        [Java.Interop.Export("openDishWarning1")]
        public void goToDishWarning1(View v)
        {
            new Android.App.AlertDialog.Builder(this)
                .SetPositiveButton("btn1", (sender, args) =>
                {
                    // User pressed yes
                })
                .SetNegativeButton("btn2", (sender, args) =>
                {
                    // User pressed no 
                })
                .SetMessage("Dish warning 1")
                .SetTitle("Error")
                .Show();
            //Intent intent = new Intent(Application.Context, typeof(Dish5View));
            //intent.PutExtra("dish_name", dish_name);
            //intent.PutExtra("navigation", "Dish7");
            //StartActivity(intent);
        }

    }
}