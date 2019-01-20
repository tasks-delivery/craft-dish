using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Craft_dish.Models;

namespace Craft_dish.Adapters
{
    public class DishAdapter : RecyclerView.Adapter
    {

        public event EventHandler<int> ItemClick;

        private List<Dish> mDishes;

        public DishAdapter(List<Dish> dishes)
        {

            mDishes = dishes;
   
        }

        public override int ItemCount
        {
            get { return mDishes.Count; }
        }
        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            DishViewHolder vh = holder as DishViewHolder;
            vh.DishPhoto.SetImageResource(mDishes[position].DishPhoto);
            vh.DishName.Text = mDishes[position].DishName;
            vh.DishDescription.Text = mDishes[position].DishDescription;
        }
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.dish4_list_items, parent, false);
            DishViewHolder vh = new DishViewHolder(itemView, OnClick);
            return vh;
        }
        private void OnClick(int obj)
        {
            if (ItemClick != null)
                ItemClick(this, obj);
        }

    }
}