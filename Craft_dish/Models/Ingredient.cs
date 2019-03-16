using System;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Realms;

namespace Craft_dish.Models
{
    public class Ingredient : RealmObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Weight { get; set; }
        public string Unit { get; set; }
    }

    public class IngredientViewHolder : RecyclerView.ViewHolder
    {
        public TextView IngredientName { get; set; }
        public TextView IngredientWeight { get; set; }
        public TextView WeightUnit { get; set; }

        public IngredientViewHolder(View itemview, Action<int> listener) : base(itemview)
        {
            IngredientName = itemview.FindViewById<TextView>(Resource.Id.dish6_ingredient_name);
            IngredientWeight = itemview.FindViewById<TextView>(Resource.Id.dish6_ingredient_weight);
            WeightUnit = itemview.FindViewById<TextView>(Resource.Id.dish6_weight_unit);
            itemview.Click += (sender, e) => listener(base.LayoutPosition);
        }

    }

    public class Ingredient1ViewHolder : RecyclerView.ViewHolder
    {
        public TextView IngredientName { get; set; }
        public TextView IngredientWeight { get; set; }
        public TextView WeightUnit { get; set; }
        public CheckBox CheckboxItem { get; set; }
        public bool IsChecked { get; set; }

        public Ingredient1ViewHolder(View itemView, Action<int> listener) : base(itemView)
        {
            IngredientName = itemView.FindViewById<TextView>(Resource.Id.ingredient1_name);
            IngredientWeight = itemView.FindViewById<TextView>(Resource.Id.ingredient1_weight);
            WeightUnit = itemView.FindViewById<TextView>(Resource.Id.ingredient1_weight_unit);
            CheckboxItem = itemView.FindViewById<CheckBox>(Resource.Id.ingredient1_checkbox);
        }

    }

}