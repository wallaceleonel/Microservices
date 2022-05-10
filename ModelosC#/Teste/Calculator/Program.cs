using System;

namespace Calculator {
    
    class Program {
        static void Main ( string[] args)
        {
          Menu();
        }
    
        static void Menu()
        {
            Console.Clear();

            Console.WriteLine("bem vindo a calculadora, o que deseja fazer ?");
            Console.WriteLine("1- soma");
            Console.WriteLine("2- subtração");
            Console.WriteLine("3- multiplicação");
            Console.WriteLine("4- divisão");
            Console.WriteLine("5- sair");
            Console.WriteLine("-----------------");

            Console.WriteLine("selecione uma opção");
            short res = short.Parse(Console.ReadLine());

            switch(res)
            {
                case 1: Soma();break;
                case 2: Subtracao();break;
                case 3: Multiplicacao();break;
                case 4: Divisao();break;
                case 5: System.Environment.Exit(0);break;
                default: Menu();break;
            }
        }
        static void Soma()
        {
            Console.Clear();
            
            Console.WriteLine("Primeiro valor :");
            
            float v1 = float.Parse(Console.ReadLine());
            
            Console.WriteLine("Segundo valor :");
            
            float v2 = float.Parse(Console.ReadLine());
            
            Console.WriteLine("");
            
            float resultado = v1 + v2 ;
            
            Console.WriteLine("O resultado da soma é :  " + resultado );
            
            Console.WriteLine($"O resultado da soma é :  {resultado}");
            
            Console.WriteLine($"O resultado da soma é :  {v1 + v2 }");

            Console.ReadKey();
            Menu();
        }
    
        static void Subtracao()

        {
            Console.Clear();

            Console.WriteLine("Primeiro valor :");
            float v1 = float.Parse(Console.ReadLine());

            Console.WriteLine("");
            
            Console.WriteLine("Segundo valor :");
            float v2 = float.Parse(Console.ReadLine());

            Console.WriteLine("");

            float resultado = v1 - v2;
            Console.WriteLine($" O resultado da subtração  é :{resultado}");

            Console.ReadKey();
            Menu();
         }
        static void  Multiplicacao()
        {
            Console.Clear();

            Console.WriteLine("Primeiro valor : ");
            float v1 = float.Parse(Console.ReadLine());

            Console.WriteLine("");

            Console.WriteLine("Segundo valor : ");
            float v2 = float.Parse(Console.ReadLine());

            Console.WriteLine("");

            float resultado = v1 * v2;
            Console.WriteLine($"O resultado da multiplicacção é :{resultado}");

            Console.ReadKey();
            Menu();
        }
        static void Divisao()
        {
            Console.Clear();
            Console.WriteLine("Primeiro valor : ");
            float v1 = float.Parse(Console.ReadLine());

            Console.WriteLine("");

            Console.WriteLine("Segundo valor :");
            float v2 = float.Parse(Console.ReadLine());

            Console.WriteLine("");

            float resultado = v1 / v2 ;
            Console.WriteLine($"O resultado da divisão é :{resultado} ");

            Console.ReadKey();
            Menu();
        }
        enum DiasDaSemana
        {
            Segunda,
            Terça,
            Quarta,
            Quinta,
            Sexta,
            Sabádo,
            Domingo
        }
        static void DiaSemana()
        {
            int DiaSemana = (int)DiasDaSemana.Domingo;
            //var DiaSemana = DiasDaSemana.Segunda
            Console.WriteLine($"Hoje o dia é :{DiaSemana} ");
        }            
    }    
}

