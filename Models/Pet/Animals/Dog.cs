using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamagochiConsole.Models.Items;

namespace TamagochiConsole.Models.Pet.Animals
{
    public enum Race
    {

    }
    public class Dog : ALivePet
    {
        private static FoodType[] canEat = { FoodType.Meat };
        private Race race;
        public Dog(string name, Race race) : base(name, canEat)
        {
            this.race = race;
        }
    }
}
