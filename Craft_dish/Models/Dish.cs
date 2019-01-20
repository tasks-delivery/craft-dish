using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Realms;
using System;

namespace Craft_dish.Models
{
    public class Dish : RealmObject
    {

        public int DishId { get; set; }
        public string DishName { get; set; }
        public string DishDescription { get; set; }
        public int DishPhoto { get; set; }

    }

    public class DishViewHolder : RecyclerView.ViewHolder
    {
        public ImageView DishPhoto { get; set; }
        public TextView DishName { get; set; }
        public TextView DishDescription { get; set; }
        public DishViewHolder(View itemview, Action<int> listener) : base(itemview)
        {
            DishPhoto = itemview.FindViewById<ImageView>(Resource.Id.dish4_dish_image);
            DishName = itemview.FindViewById<TextView>(Resource.Id.dish4_dish_name);
            DishDescription = itemview.FindViewById<TextView>(Resource.Id.dish4_dish_description);
            itemview.Click += (sender, e) => listener(base.Position);
        }
    }

}