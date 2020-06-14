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
            Console.Write("Введите кол-во камушек: ");
            n = Convert.ToInt32(Console.ReadLine());
            if (n % 2 == 0)
            {
                count = (n / 2 - 1);
            }
            else
            {
                count = ((n + 1) / 2 - 1);
            }
            Console.WriteLine($"Количество взятых Вами первым ходом камушков: {count}");
            //Console.ReadLine();
            
            while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
