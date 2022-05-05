using FactoryPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern.ConcretesFactory
{// ConcreteFactort 2 
    public class Sansung : ITelemovel
    {
        public INormalPhone SearchNormalPhone()
        {
            return new SansungGuru();
        }

        public ISmartPhone SearchSmartPhone()
        {
            return new SansungGalaxy();
        }
    }
}
