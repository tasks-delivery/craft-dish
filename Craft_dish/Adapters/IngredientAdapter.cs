using System;
using System.Collections.Generic;
using Android.Content;
using Android.Support.V7.Widget;
using Android.Views;
using Craft_dish.Models;
using Java.IO;
using JP.Wasabeef.PicassoTransformations;
using Square.Picasso;

namespace Craft_dish.Adapters
{
    public class IngredientAdapter : RecyclerView.Adapter
    {
        public event EventHandler<int> ItemClick;

        private List<Ingredient> mIngredients;

        private Context mContext;

        public IngredientAdapter(List<Ingredient> ingredients, Context context)
        {
            mIngredients = ingredients;
            mContext = context;
        }

        public override int ItemCount
        {
            get { return mIngredients.Count; }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            IngredientViewHolder vh = holder as IngredientViewHolder;  
            vh.IngredientName.Text = mIngredients[position].Name;
            vh.IngredientWeight.Text = mIngredients[position].Weight;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.dish6_ingredient_list_items, parent, false);
            IngredientViewHolder vh = new IngredientViewHolder(itemView, OnClick);
            return vh;
        }

        private void OnClick(int obj)
        {
            if (ItemClick != null)
                ItemClick(this, obj);
        }
    }
}