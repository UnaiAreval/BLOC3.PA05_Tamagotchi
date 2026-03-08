using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TamagochiConsole.Models.Items
{
    public abstract class AItem
    {
        private string name;
        public string GetName() => this.name;
        public AItem(string name)
        {
            this.name = name;
        }
    }
}
