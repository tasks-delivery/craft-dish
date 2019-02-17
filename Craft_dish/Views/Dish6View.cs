
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

namespace Craft_dish.Views
{
    [Activity(Label = "@string/app_name", Theme = "@style/NoActionBar", MainLauncher = false, ScreenOrientation = ScreenOrientation.Portrait)]
    public class Dish6View : AppCompatActivity
    {

        private string dish_name;

        private TextView toolbar_dish_name;

        private TextView dish_description;

        private ImageView dish_photo;

        private RelativeLayout dish_icon_container;

        private RecyclerView mRecycleView;

        private RecyclerView.LayoutManager mLayoutManager;

        private IngredientAdapter ingredientAdapater;

        private Dish6ViewModel dish6ViewModel;
       
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.activity_dish6);
            SetDefaultDishIcon();
        }

        protected override void OnStart()
        {
            base.OnStart();
            SetUpAdapter(LoadIngredients());
            dish_name = Intent.GetStringExtra("dish_name");
            dish6ViewModel = new Dish6ViewModel(dish_name, this);
            toolbar_dish_name = (TextView)FindViewById(Resource.Id.dish6_dish_name_text);
            dish_description = (TextView)FindViewById(Resource.Id.dish6_dish_description_text);
            dish_photo = (ImageView)FindViewById(Resource.Id.dish6_photo_image);
            dish_icon_container = (RelativeLayout)FindViewById(Resource.Id.dish6_photo_icon);
            toolbar_dish_name.Text = dish6ViewModel.FindDishName();
            dish_description.Text = dish6ViewModel.FindDishDescription();
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
            intent.PutExtra("dish_name", toolbar_dish_name.Text);
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
            StartActivity(new Intent(Application.Context, typeof(Ingredient1View)));
        }

        [Java.Interop.Export("openIngredient1Remove")]
        public void OpenIngredientListFromRemove(View v)
        {
            StartActivity(new Intent(Application.Context, typeof(Ingredient1View)));
        }

        [Java.Interop.Export("openDish7")]
        public void OpenEditDish(View v)
        {
            Intent intent = new Intent(Application.Context, typeof(Dish7View));
            intent.PutExtra("dish_name", toolbar_dish_name.Text);
            StartActivity(intent);
            Finish();
        }

        public override void OnBackPressed()
        {
            base.OnBackPressed();
            StartActivity(new Intent(Application.Context, typeof(Dish4View)));
            Finish();
        }

        private void SetUpAdapter(List<Ingredient> ingredients)
        {
            ingredientAdapater = new IngredientAdapter(ingredients, this);
            mRecycleView = FindViewById<RecyclerView>(Resource.Id.dish6_recyclerView);
            mLayoutManager = new LinearLayoutManager(this);
            mRecycleView.SetLayoutManager(mLayoutManager);
            mRecycleView.SetAdapter(ingredientAdapater);
        }

        public List<Ingredient> LoadIngredients()
        {
            List<Ingredient> ingredientList = new List<Ingredient>();
            ingredientList.Add(new Ingredient(){ Name = "Ingredient 1", Weight = "200 grams" });
            ingredientList.Add(new Ingredient(){ Name = "Ingredient 2", Weight = "200 grams" });
            ingredientList.Add(new Ingredient(){ Name = "Ingredient 3", Weight = "200 grams" });
            ingredientList.Add(new Ingredient(){ Name = "Ingredient 4", Weight = "200 grams" });
            ingredientList.Add(new Ingredient(){ Name = "Ingredient 5", Weight = "200 grams" });
            ingredientList.Add(new Ingredient(){ Name = "Ingredient 6", Weight = "200 grams" });
            ingredientList.Add(new Ingredient(){ Name = "Ingredient 7", Weight = "200 grams" });
            ingredientList.Add(new Ingredient(){ Name = "Ingredient 8", Weight = "200 grams" });
            ingredientList.Add(new Ingredient(){ Name = "Ingredient 9", Weight = "200 grams" });
            ingredientList.Add(new Ingredient(){ Name = "Ingredient 10", Weight = "200 grams" });
            ingredientList.Add(new Ingredient(){ Name = "Ingredient 11", Weight = "200 grams" });
            ingredientList.Add(new Ingredient(){ Name = "Ingredient 12", Weight = "200 grams" });
            ingredientList.Add(new Ingredient(){ Name = "Ingredient 13", Weight = "200 grams" });
            ingredientList.Add(new Ingredient(){ Name = "Ingredient 14", Weight = "200 grams" });
            ingredientList.Add(new Ingredient(){ Name = "Ingredient 15", Weight = "200 grams" });
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