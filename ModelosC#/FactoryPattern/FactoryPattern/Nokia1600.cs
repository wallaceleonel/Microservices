using FactoryPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{//Produto B1 
    public class Nokia1600 : INormalPhone
    {
        public string ModelSearch()
        {
            return "Modelo : Nokia 1600\nRAM : NA\nCamera : NA\n";
        }
    }
}
