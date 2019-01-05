using Realms;

namespace Craft_dish.Models
{
    public class Dish : RealmObject
    {

        public int DishId { get; set; }
        public string DishName { get; set; }
        public string DishDescription { get; set; }

    }

}