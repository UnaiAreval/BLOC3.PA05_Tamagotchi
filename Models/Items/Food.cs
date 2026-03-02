using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TamagochiConsole.Models.Items
{
    public enum FoodType
    {
        Fruit, Vegetable, Meat, Bread, Milk, Candy, Seeds, Fish
    }
    public class Food : AConsumable
    {
        private FoodType foodType;
        public string GetFoodType() => this.foodType.ToString();
        public Food(string name, int hungerRicover, FoodType foodType) : base(name, hungerRicover)
        {
            this.foodType = foodType;
        }
        public override string GetConsumableType() => "Food";
        public override string ToString()
        {
            return $"Dish: {this.GetName()}\n - Ricovers {this.GetRecover()} pets hunger";
        }
    }
}
