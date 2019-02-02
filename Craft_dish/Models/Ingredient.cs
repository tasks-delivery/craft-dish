using System;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace Craft_dish.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Weight { get; set; }
    }

    public class IngredientViewHolder : RecyclerView.ViewHolder
    {
        public TextView IngredientName { get; set; }
        public TextView IngredientWeight { get; set; }

        public IngredientViewHolder(View itemview, Action<int> listener) : base(itemview)
        {
            IngredientName = itemview.FindViewById<TextView>(Resource.Id.dish6_ingredient_name);
            IngredientWeight = itemview.FindViewById<TextView>(Resource.Id.dish6_ingredient_weight);
            itemview.Click += (sender, e) => listener(base.Position);
        }
    }

}