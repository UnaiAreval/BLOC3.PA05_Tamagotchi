using System;
using TamagochiConsole.UI;
using TamagochiConsole.Models.Items;
using TamagochiConsole.Models.Pet;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TamagochiConsole.Models
{
    public class Owner
    {
        private APet? pet;
        private AItem[] inventori = UI_Config.OwnerInventori.GetInventori();

        public Owner()
        {
            this.pet = null;
        }
        public Owner(APet pet)
        {
            SetPet(pet);
        }
        public APet? GetPet() => this.pet;
        public void SetPet(APet pet) => this.pet = pet;

        /// <summary>
        /// This method search for a saved pet and assign that value to owners pet;
        /// </summary>
        public void RecoverSavedPet()
        {
            this.pet = APet.LoadPet();
        }
        /// <summary>
        /// This method trys to save pets data
        /// </summary>
        public bool SavePet()
        {
            try
            {
                this.GetPet().SavePetsData();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

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
        public AItem[] GetAllItems() => this.inventori;

        public void Inventori()
        {
            

        }
        public void UseInventoriItem()
        {
            AItem[] items = GetAllItems();
            string options = "";
            //for (int i = 0; i < consums.Length; i++) options += (UI_Config.InventoriMenus.MenuOption, i, $"{consums[i].GetName()} : {consums[i].GetConsumableType()}");
            int itemPosition = NumericMenu(options, items.Length);
            if (itemPosition < items.Length && itemPosition >= 0)
            {
                if (items[itemPosition] is Medicine medicine) this.pet.Health_IncreaseOrReduce(medicine.GetRecover());
                
                if (this.pet is ALivePet pet)
                {
                    if (items[itemPosition] is Medicine m)
                    {
                        pet.CureIllnes(m);
                        return;
                    }
                    if (items[itemPosition] is Food food) 
                    {
                        pet.StomechFull_IncreaseOrReduce(food.GetRecover());
                        return;
                    }
                }
            }
            else Console.WriteLine(UI_Config.InventoriMenus.OptionNoRecognized);
            
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
            Console.Write(UI_Config.InventoriMenus.MenuTitle, nullOption + $"{options}");
            do
            {
                correctInput = Int32.TryParse(Console.ReadLine(), out num);
            } while (correctInput);
            return num;
        }
    }
}