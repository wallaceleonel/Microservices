using FactoryPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{//Produto A2
    public class SansungGalaxy : ISmartPhone
    {
        public string ModelSearch()
        {
            return "detalhes do produto";
        }
    }
}
