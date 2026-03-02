using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TamagochiConsole.Models.Items
{
    public class Medicine : AConsumable
    {
        private Illnes illnesItCure;

        public Illnes GetIllnesItCure() => this.illnesItCure;
        public Medicine(string name, Illnes illnesItCure, int healthRecover) : base (name, healthRecover)
        {
            this.illnesItCure = illnesItCure;
        }
        public override string GetConsumableType() => "Medicine";

        public override string ToString()
        {
            return $"""
                |                              
                | Medicine: {this.GetName()}
                | Used for: {this.GetIllnesItCure()}
                | Health recover = {this.GetRecover()}
                |______________________________
                """;
        }
    }
}
