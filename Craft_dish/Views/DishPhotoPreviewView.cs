using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Content.PM;
using Craft_dish.ViewModels;
using Android.Widget;
using Square.Picasso;
using Android.Content;
using Craft_dish.Views;
using Android.Views;

namespace Craft_dish
{
    [Activity(Label = "@string/app_name", Theme = "@style/NoActionBar", MainLauncher = false, ScreenOrientation = ScreenOrientation.Portrait)]
    public class DishPhotoPreviewView : AppCompatActivity
    {

        private DishPhotoPreviewViewModel dishPhotoPreviewViewModel;

        private ImageView dish_photo;

        private string dish_name;

        private TextView text_photo_not_found;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.activity_dish_photo_preview);
            text_photo_not_found = (TextView)FindViewById(Resource.Id.dish_preview_text1);
            text_photo_not_found.Visibility = ViewStates.Invisible;
        }

        public override void OnBackPressed()
        {
            base.OnBackPressed();
            Intent intent = new Intent(Application.Context, typeof(Dish6View));
            intent.PutExtra("dish_name", dish_name);
            StartActivity(intent);
            Finish();
        }

        protected override void OnStart()
        {
            base.OnStart();
            dish_name = Intent.GetStringExtra("dish_name");
            dishPhotoPreviewViewModel = new DishPhotoPreviewViewModel(dish_name, this);
            dish_photo = (ImageView)FindViewById(Resource.Id.dish_preview_icon);
            if (dishPhotoPreviewViewModel.getDishPhoto() != null)
            {
                dish_photo.Background = null;
                Picasso.With(this)
                        .Load(dishPhotoPreviewViewModel.getDishPhoto()).Into(dish_photo);
            }
            else
            {
                text_photo_not_found.Visibility = ViewStates.Visible;
            }

        }

    }

}