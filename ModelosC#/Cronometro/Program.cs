using System;
using System.Threading;

namespace Stopwatch
{
    class program{
    static void Main(string [] args)
    {
        Menu();
    }
        static void Menu() {
            Console.Clear();
            Console.WriteLine("contar em segundos S 10s = 10 segundos" );
            Console.WriteLine("contar em minutos M 2 m = 2 minutos");
            Console.WriteLine("quanto tempo deseja contar ? ");
            Console.WriteLine("sair da aplicação ");

            string  data = Console.ReadLine().ToLower();
            char type = char.Parse(data.Substring(data.Length-1,1));
            int time = int.Parse(data.Substring(0,data.Length -1 ));
            int multiplier = 1 ;

            if (type == 'm')    multiplier = 60;
            
            if (time == 0 )    System.Environment.Exit(0);
            
            PreStart(time * multiplier);
        }
        static void PreStart(int time)
        {
            Console.WriteLine("ready");
            Thread.Sleep(1000);
            Console.WriteLine("......");
            Thread.Sleep(1000);
            Console.WriteLine("set");
            Thread.Sleep(1000);
            Console.WriteLine("Go ! ");
            Thread.Sleep(100);
            
            Start(time);
        }
    static void Start(int time)
        {
            int currentTime = 0;

            while ( currentTime != time)
            {
               currentTime++;
               Console.Clear();
               Console.WriteLine(currentTime);
               Thread.Sleep(1000);
            } 
            Console.Clear();
            Console.WriteLine("stopwatch finalizado");
            Thread.Sleep(1500); 
            Menu();
        }
    }
}

// criar um regressivo 
// criar uma opção para o usuario 
// criar um temporizador 