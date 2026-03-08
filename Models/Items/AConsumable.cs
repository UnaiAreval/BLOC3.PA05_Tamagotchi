using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TamagochiConsole.Models.Items
{
    public abstract class AConsumable : AItem
    {
        private int recover;
        /// <summary>
        /// This function returns the recover value of the consumable. Depending on the item type, the recover value is used in a different stat of the pet.
        /// </summary>
        /// <returns>The value to recover in the pet stat</returns>
        public int GetRecover() => this.recover;
        protected AConsumable(string name, int recover) : base (name)
        {
            this.recover = recover;
        }
        public abstract string GetConsumableType();
    }
}
