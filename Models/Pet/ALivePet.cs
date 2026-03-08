using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamagochiConsole.Models.Items;

namespace TamagochiConsole.Models.Pet
{
    /// <summary>
    /// This kind of pet can eat and get ill
    /// </summary>
    public abstract class ALivePet: APet
    {
        private static int maxStomechCapacity = 100;

        protected int stomechFull;
        protected List<IllnesData> medicHistori = new List<IllnesData> { };
        protected FoodType[] whatCanEat;
        protected ALivePet(string name, FoodType[] whatCanEat) : base(name) 
        {
            this.stomechFull = maxStomechCapacity;
            this.whatCanEat = whatCanEat;
        }

        public override void ChangeEmotionState()
        {
            if (health > 20 && stomechFull > 50 && energy > 30) 
            {
                emotions = new List<Emotion> { Emotion.Happy };
                return;
            }
            RemoveEmotion(Emotion.Happy);
            if (stomechFull <= 50) AddEmotion(Emotion.Angry);
            if (health <= 20) AddEmotion(Emotion.Sick);
            if (energy <= 30) AddEmotion(Emotion.Tired);
        }
        public string GetWhatCanEat()
        {
            string whatCanEat = $"{this.name} can eat: ";
            foreach (FoodType ft in this.whatCanEat) whatCanEat += $"\n - {ft.ToString()}";
            return whatCanEat;
        }
        public string GetMedicData()
        {
            string medicHistori = $"{this.name}s medic information: ";
            if (this.medicHistori.Count == 0) medicHistori += "Empty";
            else
            {
                medicHistori += "\n \n | _________________________";
                foreach (IllnesData medicData in this.medicHistori)
                {
                    medicHistori += medicData.ToString() + "\n";
                }
            }

            medicHistori += $"\n \n {this.GetWhatCanEat()}";
            return medicHistori;
        }
        /// <summary>
        /// Method that gives an illnes to the pet (it gets sick). If the pet already have four illnes (five with the new one) it dies. If pet already had or have that illnes it will not be added.
        /// </summary>
        /// <param name="illnes">The new illnes that the pet gets</param>
        /// <returns><list type="bullet">
        /// <item>It dies -> true</item>
        /// <item>It lives -> false</item>
        /// </list></returns>
        public bool GotIllnes(Illnes illnes)
        {
            int illnesNoCured = 0;
            foreach (IllnesData currentIllnes in this.medicHistori)
            {
                if (currentIllnes.GetIllnes() == illnes.ToString()) return false;//Bowth if the pet have or had an illnes, this pet can not get that illnes again

                if (currentIllnes.GetDateWhenRecover() == null) illnesNoCured++;
            }

            if (illnesNoCured == 5)//four illness, five adding the new one
            {
                return true;
            }

            SetHealth(100-(20/5*illnesNoCured));
            ChangeEmotionState();
            this.medicHistori.Add(new IllnesData(illnes));
            return false;
        }

        /// <summary>
        /// This method cure an illnes of the pet if the medicine can be used for that illnes. Otherwise, the medicine will be used, but not affect.
        /// </summary>
        /// <param name="medicine">Medicine to cure an Illnes of the pet</param>
        public void CureIllnes(Medicine medicine)
        {
            for(int i = 0; i < this.medicHistori.Count; i++)
            {
                if (medicine.GetIllnesItCure().ToString() == this.medicHistori[i].GetIllnes() && this.medicHistori[i].GetDateWhenRecover() != null)
                {
                    this.medicHistori[i].CureIt();
                    this.Health_IncreaseOrReduce(medicine.GetRecover());
                    return;
                }

            }
        }
        /// <summary>  
        /// This method increase or reduce the pet sthomech fullnes value:
        /// <list type="bullet">
        /// <item>If you use a positive value the sthomech full increase</item>
        /// <item>If you use a negative value the sthomech full decrease</item>
        /// </list>
        /// </summary> 
        /// <returns></returns>  
        public void StomechFull_IncreaseOrReduce(int incOrRed) => this.stomechFull += incOrRed;
        public int GetStomechFullnes() => this.stomechFull;
        public void SetStomechFullnes(int stomechFull) => this.stomechFull = stomechFull;
    }
}
