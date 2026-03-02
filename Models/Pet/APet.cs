using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TamagochiConsole.Models.Pet
{
    public enum Emotion
    {
        Angry, Sad, Happy, Tired, Sick
    }
    public abstract class APet
    {
        private static int maxEnergy = 31;
        private static int maxHealth = 21;

        protected string name;
        /// <summary>
        /// This atribute save the current emotional state of the pet.
        /// <list type="bullet">
        /// <item>The pet just can be happy if it don't have any other emotion.</item>
        /// <item>The other emotions will supose a bad efect.</item>
        /// </list>
        /// </summary>
        protected List<Emotion> emotions;

        //Energy = 31 -> Your pet is good
        //Energy < 31 -> Your pet is tired
        protected int energy;

        //Health = 21 -> Your pet is healthy
        //Health < 21 -> Your pet is sick
        protected int health;
        public void SetName(string name) => this.name = name;
        public string GetName() { return this.name; }

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
        public void Energy_IncreaseOrReduce(int incOrRed) {if (maxEnergy >= energy+incOrRed) energy += incOrRed;}
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
        public void Health_IncreaseOrReduce(int incOrRed)  { if (maxHealth >= this.health + incOrRed) this.health += incOrRed; }
        public void SetHealth(int health){if(maxHealth >= health) this.health = health; }
        public int GetHealth() => this.health;
        /// <summary>
        /// This method returns a text line (string) with all the current emotions names the pet have.
        /// </summary>
        /// <returns>String with all current emotions</returns>
        public string GetEmotion()
        {
            string emotions = "Emotions:";
            foreach (Emotion emotion in this.emotions) emotions += $" {emotion.ToString()},";
            return emotions;
        }
        protected void AddEmotion(Emotion emotion) => this.emotions.Add(emotion);
        protected void RemoveEmotion(Emotion emotion) => this.emotions.Remove(emotion);
        public abstract void ChangeEmotionState();
        public void Rest() => this.energy += 10;
    }
}
