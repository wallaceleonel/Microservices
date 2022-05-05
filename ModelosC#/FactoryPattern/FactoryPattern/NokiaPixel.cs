using FactoryPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{//Produto A1
    public class NokiaPixel : ISmartPhone
    {
        public string ModelSearch()
        {
            return  "especificações do produto";
        }
    }
}
