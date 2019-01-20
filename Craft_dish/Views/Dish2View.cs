﻿
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Text;
using Android.Views;
using Android.Widget;
using Craft_dish.ViewModels;

namespace Craft_dish.Views
{

    [Activity(Label = "@string/new_dish", Theme = "@style/AppTheme", MainLauncher = false)]
    public class Dish2View : AppCompatActivity
    {

        private EditText field_name;

        private EditText field_description;

        private TextInputLayout text1_container;

        private Dish2ViewModel dish2ViewModel;

        private Button btn_save;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.activity_dish2);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            text1_container = (TextInputLayout)FindViewById(Resource.Id.text_container_1);
            field_name = (EditText)FindViewById(Resource.Id.dish_2_field_dish_name);
            field_description = (EditText)FindViewById(Resource.Id.dish_2_field_dish_description);
            btn_save = (Button)FindViewById(Resource.Id.dish_2_btn_save);
            dish2ViewModel = new Dish2ViewModel();
            btn_save.Enabled = false;
            field_name.TextChanged += OnTextChanged;
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (field_name.Text.Length <= 0)
            {
                btn_save.Enabled = false;
            }
            else
            {
                btn_save.Enabled = true;
            }
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {   
            Finish();          
            return true;
        }

        [Java.Interop.Export("openDish3")]
        public void ButtonSaveDish(View v)
        {
            if(dish2ViewModel.dishIsExists(field_name.Text) == true)
            {
                ShowError();
            }
            else
            {
                dish2ViewModel.saveDish(field_name.Text, field_description.Text);
                StartActivity(new Intent(Application.Context, typeof(Views.Dish3View)));
                Finish();
            }
                           
        }

        private void ShowError()
        {            
            field_name.Error = GetString(Resource.String.dish_warning1);
        }

    }
}