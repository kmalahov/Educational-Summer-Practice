using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace num_3
{
    class n3
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите координату Х:");
            double x = vvod();
            Console.WriteLine("Введите координату У:");
            double y = vvod();            
            if (y >= 0 && y <= -x && x >= (y - 3) / 2 || y <= 0 && x >= (y - 3) / 2 && y >= (x - 1) / 3)
            {
                Console.Write("Точка входит в заштрихованную область.");
            }
            else
            {
                Console.Write("Точка не входит в заштрихованную область.");
            }
            Console.ReadLine();
        }

        static double vvod()
        {
            double n = 0;
            bool ok = true;
            do
            {
                ok = double.TryParse(Console.ReadLine(), out n);
                if (!ok) Console.WriteLine("Не вверный ввод данных. Введите еще раз: ");
            } while (!ok);
            return n;
        }
    }
}
