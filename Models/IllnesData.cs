using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamagochiConsole.Models.Items;

namespace TamagochiConsole.Models
{
    public enum Illnes
    {
        Cov19, Malaria, Lupus, BlackPlague
    }
    public class IllnesData
    {
        private Illnes illnes;
        private DateTime dateWhenGotSick;
        private DateTime? dateWhenRecover;

        /// <returns>Illnes name</returns>
        public string GetIllnes() => this.illnes.ToString();
        public string GetDateWhenGotSick() => $"{DateTime.Parse(this.dateWhenGotSick.ToString()).Day}/{DateTime.Parse(this.dateWhenGotSick.ToString()).Month}/{DateTime.Parse(this.dateWhenGotSick.ToString()).Year}";
        public string GetDateWhenRecover()
        {
            if (this.dateWhenRecover == null) return $"Your pet is not recovered of {GetIllnes()}";
            return $"{DateTime.Parse(this.dateWhenRecover.ToString()).Day}/{DateTime.Parse(this.dateWhenRecover.ToString()).Month}/{DateTime.Parse(this.dateWhenRecover.ToString()).Year}";
        }
        public IllnesData(Illnes illnes)
        {
            this.illnes = illnes;
            this.dateWhenGotSick = DateTime.Now;
        }
        /// <summary>
        /// Set the acutal time as the date when the pet recovered
        /// </summary>
        public void CureIt() => this.dateWhenRecover = DateTime.Now; 
        
        public override string ToString()
        {
            if (dateWhenRecover != null)
            {
                return $"""
                    | Illnes: {this.illnes}
                    |   -> Date detected: << {dateWhenGotSick} >>
                    |   -> Date recovered: << {dateWhenRecover} >>
                    """;
            }

            return $"""
                | Illnes: {this.illnes}
                |   -> Date detected: << {dateWhenGotSick} >>
                """;
        }
    }
}
