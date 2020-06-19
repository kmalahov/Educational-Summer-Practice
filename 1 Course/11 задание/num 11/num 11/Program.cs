using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task11
{
    public class Program
    {
        public static void Main()
        {
            Console.Write("Введите зашифрованный сигнал, состоящий из нулей и единиц, которым кратен 3: ");
            var encr = Console.ReadLine();

            try
            {
                Console.WriteLine($"Расшифровка: {Decr(encr)}");
                Console.ReadLine();
            }
            catch (ArgumentException E)
            {
                Console.WriteLine(E.Message);
                Console.ReadLine();
            }           
            
        }

            //дешифровка, get:зашифр, return: расшифр
        public static string Decr(string encr)
        {
            if (encr == null) throw new NullReferenceException();
            if (encr.Length < 3 || encr.Length % 3 != 0) 
                throw new ArgumentException("Кратность сигнала = 3, \n Введите сигнал еще раз");
           
            var strbuild = new StringBuilder();

            for (var i = 2; i < encr.Length; i += 3)
            {
                var n1 = encr[i - 2];
                var n2 = encr[i - 1];
                var n3 = encr[i];

                if (!zerorone(n1) || !zerorone(n2) || !zerorone(n3))
                {
                    throw new ArgumentException("Сигнал должен состоять только из нулей и единиц");
                }

                strbuild.Append(n1 == n2 ? n1.ToString() : n3.ToString());
            }

            return strbuild.ToString();
        }

        
         //Проверка на 0 и 1
        private static bool zerorone(char ch)
        {
            return ch == 48 || ch == 49;
        }
    }
}