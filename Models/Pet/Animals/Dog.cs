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
        Rottweilerm, Dalmata, Bulldog
    }
    public class Dog : ALivePet
    {
        private static FoodType[] canEat = { FoodType.Meat };
        private Race race;
        public Dog(string name, Race race) : base(name, canEat)
        {
            this.race = race;
        }

        public Race GetRace() => this.race;
        public override void PrintPetsData()
        {
            Console.WriteLine($"""
                {base.ToString()}
                It's from the race: {this.GetRace().ToString()}

                {this.GetWhatCanEat()}
                """);
        }

        public override void SavePetsData()
        {
            try
            {
                using (TextWriter tw = new StreamWriter("..\\SavedFiles\\savedPet.txt"))
                {

                    tw.WriteLine(string.Format("Type: 'D' - Name: {0} - Race: {1}", this.GetName(), this.GetRace().ToString()), this.GetEnergy(), this.GetHealth(), this.GetStomechFullnes(), this.GetEmotions());
                }
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
