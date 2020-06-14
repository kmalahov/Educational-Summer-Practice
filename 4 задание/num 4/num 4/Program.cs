using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace num_4
{
    class Program
    {
        static Complex Gorner(Complex[] Coefs)
        {
            Complex X = Coefs[0];
            Complex Result = Coefs[Coefs.Length - 1];

            for (int i = Coefs.Length - 1; i > 1; i--)
                Result = Result * X + Coefs[i - 1];

            return Result;
        }

        static void Main(string[] args)
        {
            // Массив одночленов
            Complex[] Array = Interface.MainMenu();

            // Печать коэффициентов
            Interface.PrintCoefs(Array);

            Console.WriteLine("Значение многочлена при заданных значениях x и y равно {0}", Gorner(Array));

            Console.WriteLine("Нажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}
