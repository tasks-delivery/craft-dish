using System;
using System.Collections.Generic;
using Android.Content;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Craft_dish.Models;

namespace Craft_dish.Adapters
{
    public class IngredientAdapter : RecyclerView.Adapter
    {
        public event EventHandler<int> ItemClick;

        public event EventHandler<int> ItemUnClick;

        private IList<Ingredient> mIngredients;

        private Context mContext;

        private bool state;

        public IList<Ingredient> ingredients { get; set; }

        public IngredientAdapter(IList<Ingredient> ingredients, Context context, bool checkedState)
        {
            mIngredients = ingredients;
            mContext = context;
            state = checkedState;
        } 

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            if (mContext.ToString().Contains("Dish6View") == true)
            {
                View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.dish6_ingredient_list_items, parent, false);
                IngredientViewHolder vh = new IngredientViewHolder(itemView, OnClick);
                return vh;
            }
            else
            {
                View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.ingredient1_list_items, parent, false);
                Ingredient1ViewHolder vh = new Ingredient1ViewHolder(itemView, OnClick);               
                return vh;
            }

        }

        private Dictionary<int, bool> map = new Dictionary<int, bool>();

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
           if (mContext.ToString().Contains("Dish6View") == true)
           {
               IngredientViewHolder vh = holder as IngredientViewHolder;
               vh.IngredientName.Text = mIngredients[position].Name;

                if (mIngredients[position].Weight.Length == 0)
                {
                    vh.IngredientWeight.Text = "";
                    vh.WeightUnit.Text = "";
                }
                else
                {
                    vh.IngredientWeight.Text = mIngredients[position].Weight;
                    vh.WeightUnit.Text = mIngredients[position].Unit;
                }
              
           }
           else
           {
                Ingredient1ViewHolder vh = holder as Ingredient1ViewHolder;
                vh.IngredientName.Text = mIngredients[position].Name;
                vh.CheckboxItem.SetOnCheckedChangeListener(new CheckboxListener(map, position));
                vh.CheckboxItem.Checked = state;
                vh.CheckboxItem.Click += delegate
                {    
                    if (vh.CheckboxItem.Checked == true)
                    {                     
                        OnClick(position);                 
                    }
                    else
                    {                       
                        OnRemove(position);                    
                    }
                };

                if (mIngredients[position].Weight.Length == 0)
               {
                   vh.IngredientWeight.Text = "";
                   vh.WeightUnit.Text = "";
               }
               else
               {
                    vh.IngredientWeight.Text = mIngredients[position].Weight;
                    vh.WeightUnit.Text = mIngredients[position].Unit;
               }

            }

        }

        public class CheckboxListener : Java.Lang.Object, CompoundButton.IOnCheckedChangeListener
        {
            private readonly Dictionary<int, bool> map;
            private int mPosotion;

            public CheckboxListener(Dictionary<int, bool> map, int position)
            {
                this.map = map;
                mPosotion = position;
            }

            public void OnCheckedChanged(CompoundButton buttonView, bool isChecked)
            {
                if (isChecked == true)
                {
                    if (!map.ContainsKey(mPosotion))
                    {
                        map.Add(mPosotion, true);
                        
                    }
                }
                else
                {
                    map.Remove(mPosotion);
                }
            }
        }

        public override int ItemCount
        {
            get { return mIngredients.Count; }
        }

        void OnRemove(int position)
        {
            ItemUnClick?.Invoke(this, position);
        }

        void OnClick(int position)
        {
            ItemClick?.Invoke(this, position);
        }

    }

}

