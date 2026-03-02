using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamagochiConsole.Models.Items;

namespace TamagochiConsole.Models.Pet.Animals
{
    public enum FurColor
    {
        TigerGrey, Grey, Black, White, Orange, TigerOrange, Brown, Beish
    }
    public class Cat : ALivePet
    {
        private static FoodType[] canEat = { FoodType.Fish, FoodType.Meat, FoodType.Milk };
        private FurColor[] furColors;
        public Cat(string name, FurColor[] furColors) : base(name, canEat)
        {
            this.furColors = furColors;
        }
    }
}
