using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace num_7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Все последовательности состоящии из цифр 1, 2, 3, 4, 5");

            for (int i = 1; i < 6; i++)
                for (int j = 1; j < 6; j++)
                {
                    if (j != i)
                    {
                        for (int k = 1; k < 6; k++)
                            if (k != i && k != j)
                            {
                                for (int l = 1; l < 6; l++)
                                    if (l != i && l != j && l != k)
                                    {
                                        for (int m = 1; m < 6; m++)
                                            if (m != i && m != j && m != k && m != l)
                                            {
                                                Console.WriteLine("{0}{1}{2}{3}{4}", i, j, k, l, m);
                                            }
                                    }
                            }
                    }
                }
            Console.ReadLine();
        }
    }
}
