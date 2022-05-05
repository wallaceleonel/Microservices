using FactoryPattern.ConcretesFactory;
using FactoryPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ITelemovel nokiaTelemovel = new Nokia();
            TelemovelClient nokiaClient = new TelemovelClient(nokiaTelemovel);

            Console.WriteLine("----------------NOKIA---------------");
            Console.WriteLine(nokiaClient.SearchNormalPhoneDetails());
            Console.WriteLine(nokiaClient.SearchSmartPhoneDetails());

            ITelemovel sansungTelemovel = new Sansung();
            TelemovelClient sansungClient = new TelemovelClient(sansungTelemovel);

            Console.WriteLine("----------------SANSUNG---------------");
            Console.WriteLine(sansungClient.SearchNormalPhoneDetails());
            Console.WriteLine(sansungClient.SearchSmartPhoneDetails());

            Console.ReadKey();
        }
    }
}
