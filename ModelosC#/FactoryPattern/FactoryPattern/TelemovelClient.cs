using FactoryPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{//Client
    public class TelemovelClient
    {
         ISmartPhone  smartPhone;
         INormalPhone normalPhone;

        public TelemovelClient(ITelemovel telemovelFactory)
        {
            smartPhone = telemovelFactory.SearchSmartPhone();

            normalPhone = telemovelFactory.SearchNormalPhone();
        }
        public string SearchSmartPhoneDetails()
        {
            return smartPhone.ModelSearch();
        }
        public string SearchNormalPhoneDetails()
        {
            return normalPhone.ModelSearch();
        }
    }
}
