using FactoryPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{//Produto B2
    public class SansungGuru : INormalPhone
    {
        public string ModelSearch()
        {
            return "SansungGuru \n  detalhes";
        }
    }
}
