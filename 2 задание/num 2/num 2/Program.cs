using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace num_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            int count;
            Console.Write("Введите кол-во камешек: ");
            n = vvod();
            if (n % 2 == 0)
            {
                count = (n / 2 - 1);
            }
            else
            {
                count = ((n + 1) / 2 - 1);
            }
            Console.WriteLine($"Количество взятых Вами первым ходом камушков: {count}");            
            while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
        static int vvod()
        {
            int n = 0;
            bool ok = true;
            do
            {
                ok = int.TryParse(Console.ReadLine(), out n);
                if (!ok) Console.WriteLine("Не вверный ввод данных. Введите еще раз: ");
            } while (!ok);
            return n;
        }
    }
}
