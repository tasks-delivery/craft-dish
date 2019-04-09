
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Craft_dish.Adapters;
using Craft_dish.Models;
using Craft_dish.ViewModels;
using JP.Wasabeef.PicassoTransformations;
using Square.Picasso;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Craft_dish.Views
{
    [Activity(Label = "@string/app_name", Theme = "@style/NoActionBar", ConfigurationChanges = ConfigChanges.Locale, MainLauncher = false, ScreenOrientation = ScreenOrientation.Portrait)]
    public class Dish6View : AppCompatActivity
    {

        private string dish_name;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.activity_dish6);
            SetDefaultDishIcon();
        }

        private string FieldDecorator(string field)
        {
            string fieldValue = Regex.Replace(field, @"\n", " ");
            return fieldValue;
        }

        protected override void OnStart()
        {
            base.OnStart();
           
            dish_name = Intent.GetStringExtra("dish_name");
            SetUpAdapter(LoadIngredients());
            Dish6ViewModel dish6ViewModel = new Dish6ViewModel(dish_name);
            TextView toolbar_dish_name = (TextView)FindViewById(Resource.Id.dish6_dish_name_text);
            TextView dish_description = (TextView)FindViewById(Resource.Id.dish6_dish_description_text);
            ImageView dish_photo = (ImageView)FindViewById(Resource.Id.dish6_photo_image);
            RelativeLayout dish_icon_container = (RelativeLayout)FindViewById(Resource.Id.dish6_photo_icon);

            toolbar_dish_name.Text = FieldDecorator(dish_name);
            dish_description.Text = FieldDecorator(dish6ViewModel.FindDishDescription());
            if (dish6ViewModel.getDishPhoto() != null)
            {
                dish_photo.Background = null;
                dish_icon_container.Background = null;
                dish_icon_container.LayoutParameters.Width = 500;
                dish_icon_container.LayoutParameters.Height = 500;               
                Picasso.With(this)
                       .Load(dish6ViewModel.getDishPhoto()).CenterCrop().Resize(500, 500)
                       .Transform(new RoundedCornersTransformation(350, 0)).Into(dish_photo);
                dish_photo.Click += OpenDishPhotoPreview;
            }

        }

        private void OpenDishPhotoPreview(object sender, System.EventArgs e)
        {
            Intent intent = new Intent(Application.Context, typeof(DishPhotoPreviewView));
            intent.PutExtra("dish_name", dish_name);
            StartActivity(intent);
            Finish();
        }

        [Java.Interop.Export("back")]
        public void Back(View v)
        {
            OnBackPressed();
        }

        [Java.Interop.Export("openIngredient1Add")]
        public void OpenIngredientListFromAdd(View v)
        {
            Intent intent = new Intent(Application.Context, typeof(Ingredient1View));
            intent.PutExtra("navigateFrom", "Dish6Add");
            intent.PutExtra("dish_name", dish_name);
            StartActivity(intent);
        }

        [Java.Interop.Export("openIngredient1Remove")]
        public void OpenIngredientListFromRemove(View v)
        {
            Intent intent = new Intent(Application.Context, typeof(Ingredient1View));
            intent.PutExtra("navigateFrom", "Dish6Remove");
            intent.PutExtra("dish_name", dish_name);
            StartActivity(intent);
        }

        [Java.Interop.Export("openDish7")]
        public void OpenEditDish(View v)
        {
            Intent intent = new Intent(Application.Context, typeof(Dish7View));
            intent.PutExtra("dish_name", dish_name);
            StartActivity(intent);
            Finish();
        }

        public override void OnBackPressed()
        {
            base.OnBackPressed();
            StartActivity(new Intent(Application.Context, typeof(Dish4View)));
            Finish();
        }

        private void SetUpAdapter(IList<Ingredient> ingredients)
        {
            IngredientAdapter ingredientAdapater = new IngredientAdapter(ingredients, this, false);
            RecyclerView mRecycleView = FindViewById<RecyclerView>(Resource.Id.dish6_recyclerView);
            RecyclerView.LayoutManager mLayoutManager = new LinearLayoutManager(this);
            mRecycleView.SetLayoutManager(mLayoutManager);
            mRecycleView.SetAdapter(ingredientAdapater);
        }

        public IList<Ingredient> LoadIngredients()
        {
            Dish6ViewModel dish6ViewModel = new Dish6ViewModel(dish_name);
            IList<Ingredient> ingredientList = dish6ViewModel.LoadDishIngredients(dish_name);
            return ingredientList;
        }
      
        private void SetDefaultDishIcon()
        {
            GradientDrawable gradientDrawable = new GradientDrawable();
            gradientDrawable.SetCornerRadius(200);
            gradientDrawable.SetColor(Color.DarkSlateGray);
            View view = (RelativeLayout)FindViewById(Resource.Id.dish6_photo_icon);
            view.SetBackgroundDrawable(gradientDrawable);      
        }

    }
}