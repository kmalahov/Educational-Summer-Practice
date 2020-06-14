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
            n = Convert.ToInt32(Console.ReadLine());
            while (n != 0)
            {
                k = Convert.ToInt32(Console.ReadLine());
                if (k < 3)
                {
                    d = Convert.ToInt32(Console.ReadLine());
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

    }
}

