using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Enum.TryParse("Wrongcredentials", out AuthStatus myEnum);
            var v1= myEnum;

            switch(myEnum)
            {
                case AuthStatus.NaoAutorizado:
                    Console.WriteLine(AuthStatus.NaoAutorizado.ToString());
                    break;

                case AuthStatus.UserNotExists:
                    Console.WriteLine(AuthStatus.UserNotExists.ToString());
                    break;

                case AuthStatus.UsuarioNaoCadastrao:
                    Console.WriteLine(AuthStatus.UsuarioNaoCadastrao.ToString());
                    break;

                case AuthStatus.Wrongcredentials:
                    Console.WriteLine(AuthStatus.Wrongcredentials.ToString());
                    break;

            }
        }
    }


    enum AuthStatus
    {
        [EnumMember(Value = "1")]
        NaoAutorizado = 1,
        [EnumMember(Value = "2")]
        UsuarioNaoCadastrao = 2,
        [EnumMember(Value = "UserNotExists")]
        UserNotExists = 3,
        [EnumMember(Value = "wrongcredentials")]
        Wrongcredentials = 4,

    }
}
