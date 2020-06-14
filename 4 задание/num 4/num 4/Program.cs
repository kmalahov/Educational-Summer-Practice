using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace num_4
{
    class Program
    {
        static Complex Methgorner(Complex[] cof)
        {
            Complex x = cof[0];
            Complex res = cof[cof.Length - 1];

            for (int i = cof.Length - 1; i > 1; i--)
                res = res * x + cof[i - 1];

            return res;
        }

        static void Main(string[] args)
        {
            // Массив одночленов
            Complex[] arr = Interface.MainMenu();

            // Печать коэффициентов
            Interface.PrintCoefs(arr);

            Console.WriteLine("Значение многочлена при заданных значениях x и y равно {0}", Methgorner(arr));

            Console.WriteLine("Нажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}
