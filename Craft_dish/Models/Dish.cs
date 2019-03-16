using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Realms;
using System;
using System.Collections.Generic;

namespace Craft_dish.Models
{
    public class Dish : RealmObject
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PhotoPath { get; set; }
        public IList<Ingredient> Ingredients { get; }

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
            itemview.Click += (sender, e) => listener(base.LayoutPosition);
        }
    }

}