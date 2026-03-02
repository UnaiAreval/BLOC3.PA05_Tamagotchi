using System;
using TamagochiConsole.UI;
using TamagochiConsole.Models.Items;
using TamagochiConsole.Models.Pet;

namespace TamagochiConsole.Models
{
    public class Owner
    {
        private APet? pet;
        private AConsumable[] inventori = new AConsumable[]{ };

        public Owner(APet pet, AConsumable[] inventori)
        {

        }
        public APet? GetPet() => this.pet;
        public void SetPet(APet pet) => this.pet = pet;
        /// <summary>
        /// It gives the list of food that the player have in the inventori
        /// </summary>
        /// <returns>List of Food</returns>
        public Food[] GetConsumableFood()
        {
            int foodAmount = 0;
            foreach (AConsumable item in this.inventori) if (item is Food f) foodAmount++;
            Food[] food = new Food[foodAmount];
            for (int i = 0; i < inventori.Length; i++) if (inventori[i] is Food f) food[i] = (Food)inventori[i];

            return food;
        }
        /// <summary>
        /// It gives the list of medicines that the player have in the inventori
        /// </summary>
        /// <returns>List of Medicine</returns>
        public Medicine[] GetConsumableMedicine()
        {
            int medicineAmount = 0;
            foreach (AConsumable item in this.inventori) if (item is Medicine medicine) medicineAmount++;
            Medicine[] medicines = new Medicine[medicineAmount];
            for (int i = 0; i < inventori.Length; i++) if (inventori[i] is Medicine medicine) medicines[i] = (Medicine)inventori[i];

            return medicines;
        }
        /// <returns>All consumables in the inventori</returns>
        public AConsumable[] GetConsumables() => this.inventori;

        public void Inventori()
        {
            Console.WriteLine(UI_Config.EnglishMenus.MenuTitle);
            switch(ConsoleKeyMenu((UI_Config.EnglishMenus.MenuOption, 'A', "See all and use one of them") + "\n" + (UI_Config.EnglishMenus.MenuOption, 'M', "See medicines.") + "\n" + (UI_Config.EnglishMenus.MenuOption, 'F', "See food."), 'N'))
            {
                case 'A':
                    UseInventoriItem();
                    break;
                case 'M':
                    foreach (Medicine m in GetConsumableMedicine()) Console.WriteLine(m.ToString());
                    break;
                case 'F':
                    foreach (Food f in GetConsumableFood()) Console.WriteLine(f.ToString());
                    break;
                default:
                    Console.WriteLine(UI_Config.EnglishMenus.OptionNoRecognized);
                    break;
            }

        }
        public void UseInventoriItem()
        {
            AConsumable[] consums = GetConsumables();
            string options = "";
            for (int i = 0; i < consums.Length; i++) options += (UI_Config.EnglishMenus.MenuOption, i, $"{consums[i].GetName()} : {consums[i].GetConsumableType()}");
            int consumablePosition = NumericMenu(options, consums.Length);
            if (consumablePosition < consums.Length && consumablePosition >= 0)
            {
                if (consums[consumablePosition] is Medicine medicine) this.pet.Health_IncreaseOrReduce(medicine.GetRecover());
                
                if (this.pet is ALivePet pet)
                {
                    if (consums[consumablePosition] is Medicine m)
                    {
                        pet.CureIllnes(m);
                        return;
                    }
                    if (consums[consumablePosition] is Food food) 
                    {
                        pet.StomechFull_IncreaseOrReduce(food.GetRecover());
                        return;
                    }
                }
            }
            else Console.WriteLine(UI_Config.EnglishMenus.OptionNoRecognized);
            
        }

        /// <summary>
        /// Display a menu that ask the user to press a key depending on which option they want to use
        /// </summary>
        /// <param name="options">A string where must be apearing all the menu options, with the key that the user must press to access that option</param>
        /// <param name="nullOption">The option that do not access any option from the menu</param>
        /// <returns>Char entered by the user</returns>
        private char ConsoleKeyMenu(string options, char nullOption)
        {
            Console.WriteLine(UI_Config.EnglishMenus.MenuTitle, nullOption + $"{options}");
            return Console.ReadKey().KeyChar;
        }
        /// <summary>
        /// Display a menu that ask the user to enter a number depending on which option they want to use
        /// </summary>
        /// <param name="options">A string where must be apearing all the menu options, with the key that the user must press to access that option</param>
        /// <param name="nullOption">The option that do not access any option from the menu</param>
        /// <returns>Number entered by the user</returns>
        private int NumericMenu(string options, int nullOption)
        {
            int num;
            bool correctInput = true;
            Console.Write(UI_Config.EnglishMenus.MenuTitle, nullOption + $"{options}");
            do
            {
                correctInput = Int32.TryParse(Console.ReadLine(), out num);
            } while (correctInput);
            return num;
        }
    }
}
