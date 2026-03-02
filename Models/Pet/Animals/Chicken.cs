using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamagochiConsole.Models.Items;

namespace TamagochiConsole.Models.Pet.Animals
{
    public class Chicken : ALivePet
    {
        private static FoodType[] canEat = { FoodType.Vegetable, FoodType.Bread, FoodType.Seeds };
        public Chicken(string name) : base(name, canEat)
        {
        }
    }
}
