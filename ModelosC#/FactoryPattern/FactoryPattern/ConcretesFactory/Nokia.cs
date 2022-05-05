using FactoryPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern.ConcretesFactory
{// ConcreteFactory 1 
    public class Nokia : ITelemovel
    {
        public INormalPhone SearchNormalPhone()
        {
            return new Nokia1600();
        }

        public ISmartPhone SearchSmartPhone()
        {
            return new NokiaPixel();
        }
    }
}
