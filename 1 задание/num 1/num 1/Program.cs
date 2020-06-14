using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace num_1
{
    class Program
    {
        static void Main(string[] args)
        {

            int n, k, d;
            LinkedList<int> s = new LinkedList<int>();
            n = vvod();
            while (n != 0)
            {
                k = vvod();
                if (k < 3)
                {
                    d = vvod();
                    if (k == 1)
                    {
                        s.AddFirst(d);
                    }
                    else
                    {
                        s.AddLast(d);
                    }
                }
                else
                {
                    if (k == 3)
                    {
                        d = s.First.Value;
                        s.RemoveFirst();
                    }
                    else
                    {
                        d = s.Last.Value;
                        s.RemoveLast();
                    }
                    Console.Write(d);
                    Console.Write(' ');
                }
                n--;
            }

            Console.Read();

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