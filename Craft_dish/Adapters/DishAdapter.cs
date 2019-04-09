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
    public class DishAdapter : RecyclerView.Adapter
    {

        public event EventHandler<int> ItemClick;

        private List<Dish> mDishes;

        private Context mContext;

        public DishAdapter(List<Dish> dishes, Context context)
        {
            mDishes = dishes;
            mContext = context;          
        }

        public override int ItemCount
        {
            get { return mDishes.Count; }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            DishViewHolder vh = holder as DishViewHolder;           
            string path = mDishes[position].PhotoPath;         
            if (path != null && path != "")
            {
                File imgFile = new File(path);
                if (imgFile.Exists())
                {       
                    Picasso.With(mContext)
                           .Load(imgFile).CenterCrop().Resize(130, 130)
                           .Transform(new RoundedCornersTransformation(100, 0)).Into(vh.DishPhoto);
                }
                else
                {
                    Picasso.With(mContext)
                             .Load(Resource.Drawable.icon_not_found).CenterCrop().Resize(130, 130)
                             .Transform(new RoundedCornersTransformation(100, 0)).Into(vh.DishPhoto);
                }
                
            }
            else
            {             
                Picasso.With(mContext)
                               .Load(Resource.Drawable.icon_not_found).CenterCrop().Resize(130, 130)
                               .Transform(new RoundedCornersTransformation(100, 0)).Into(vh.DishPhoto);
            }
            vh.DishName.Text = mDishes[position].Name;
            vh.DishDescription.Text = mDishes[position].Description;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.dish4_list_items, parent, false);
            DishViewHolder vh = new DishViewHolder(itemView, OnClick);        
            return vh;
        }

        private void OnClick(int obj)
        {
            ItemClick?.Invoke(this, obj);
        }     

    }

}