using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TamagochiConsole.Models.Items;
using TamagochiConsole.Models.Pet.Animals;
using TamagochiConsole.UI;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TamagochiConsole.Models.Pet
{
    public enum Emotion
    {
        Angry, Sad, Happy, Tired, Sick
    }
    public abstract class APet
    {
        private static int maxEnergy = 100;
        private static int maxTiredEnergy = 30;
        private static int maxHealth = 100;
        private static int maxSickHealth = 20;

        protected string name;
        /// <summary>
        /// This atribute save the current emotional state of the pet.
        /// <list type="bullet">
        /// <item>The pet just can be happy if it don't have any other emotion.</item>
        /// <item>The other emotions will supose a bad efect.</item>
        /// </list>
        /// </summary>
        protected List<Emotion> emotions;

        //Energy >= 31 -> Your pet is good
        //Energy < 31 -> Your pet is tired
        protected int energy;
     
        //Health >= 21 -> Your pet is healthy
        //Health < 21 -> Your pet is sick
        protected int health;
        public void SetName(string name) => this.name = name;
        public string GetName() => this.name;

        protected APet(string name)
        {
            SetName(name);
            this.emotions = new List<Emotion> { Emotion.Happy };
            SetEnergy(maxEnergy);
            SetHealth(maxHealth);
        }

        /// <summary>  
        /// This method increase or reduce the pet energys value:
        /// <list type="bullet">
        /// <item>If you use a positive value the energy increase</item>
        /// <item>If you use a negative value the energy decrease</item>
        /// </list>
        /// </summary> 
        /// <returns></returns>  
        public void Energy_IncreaseOrReduce(int incOrRed) {if (maxEnergy >= energy+incOrRed || 0 >= energy+incOrRed) energy += incOrRed;}
        public void SetEnergy(int energy) { if (maxEnergy >= energy) this.energy = energy; }
        public int GetEnergy() => this.energy;
        /// <summary>  
        /// This method increase or reduce the pet healths value:
        /// <list type="bullet">
        /// <item>If you use a positive value the health increase</item>
        /// <item>If you use a negative value the health decrease</item>
        /// </list>
        /// </summary> 
        /// <returns></returns>  
        public void Health_IncreaseOrReduce(int incOrRed)  { if (maxHealth >= this.health + incOrRed || 0 >= health+incOrRed) this.health += incOrRed; }
        public void SetHealth(int health){if(maxHealth >= health) this.health = health; }
        public int GetHealth() => this.health;
        /// <summary>
        /// This method returns a text line (string) with all the current emotions names the pet have.
        /// </summary>
        /// <returns>String with all current emotions</returns>
        public string GetEmotions()
        {
            string emotions = "Emotions: ";
            if (this.emotions.Contains(Emotion.Happy)) return emotions + UI_Config.PetTypesAndEmotions.Happy;
            foreach (Emotion em in this.emotions)
            {
                switch (em)
                {
                    case Emotion.Angry:
                        emotions += UI_Config.PetTypesAndEmotions.Angry;
                        break;

                    case Emotion.Sad:
                        emotions += UI_Config.PetTypesAndEmotions.Sad;
                        break;
                    case Emotion.Tired:
                        emotions += UI_Config.PetTypesAndEmotions.Tired;
                        break;
                    case Emotion.Sick:
                        emotions += UI_Config.PetTypesAndEmotions.Sick;
                        break;
                    default:
                        emotions += UI_Config.PetTypesAndEmotions.NoRecognised;
                        break;
                }
            }
            return emotions;
        }
        protected void AddEmotion(Emotion emotion) => this.emotions.Add(emotion);
        protected void RemoveEmotion(Emotion emotion) => this.emotions.Remove(emotion);
        public abstract void ChangeEmotionState();
        public void Rest()
        {
            if (this.GetEnergy() == maxEnergy)
            {
                Console.WriteLine(UI_Config.PetMenu.Msg_PetRecoveredEnergy);
                return; 
            }
            string z = "z";
            string dot = ".";
            for (int i = 0; i < 3; i++)
            {
                if (this.GetEnergy() + 10 > maxEnergy) 
                {
                    this.SetEnergy(maxEnergy);
                    Console.WriteLine(UI_Config.PetMenu.Msg_PetRecoveredEnergy);
                    return;
                }
                else if (this.GetEnergy() < maxEnergy)
                {
                    Console.WriteLine(UI_Config.PetMenu.Msg_PetResting + dot);
                    Console.WriteLine(z);
                    this.Energy_IncreaseOrReduce(10); 
                }
                Thread.Sleep(300);
                z += "z";
                dot += ".";
            }
            Console.WriteLine(this.GetEnergy() > maxTiredEnergy ? UI_Config.PetMenu.Msg_PetRecoveredEnergy : UI_Config.PetMenu.Msg_PetStealTired);
        }

        public override string ToString()
        {
            string name = $"{this.GetName()} is a ";
            if (this is ALivePet a)
            {
                if (a is Dog d) name += UI_Config.PetTypesAndEmotions.Dog;
                else if (a is Cat c) name += UI_Config.PetTypesAndEmotions.Cat;
                else if (a is Chicken ch) name += UI_Config.PetTypesAndEmotions.Chicken;
            }
            return name + "\n \n" + this.GetEmotions();
        }
        /// <summary>
        /// This method prints the specific data of the pet.
        /// </summary>
        public abstract void PrintPetsData();


        /// <summary>
        /// This method search for a saved pet and assign that value to owners pet;
        /// </summary>
        public static APet? LoadPet()
        {
            try
            { 
                APet pet = new Dog("Manolete", Race.Bulldog);
                return pet;
            }
            catch (Exception e)
            {
                Console.WriteLine(UI_Config.PetMenu.NoPet);
            }
            return null;
        }
        /// <summary>
        /// This method trys to save pets data
        /// </summary>
        public abstract void SavePetsData();
    }
}
