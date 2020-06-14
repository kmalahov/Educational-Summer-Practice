using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace num_6
{
    class Program
    {
		public static double rec()
		{
			return  1 * a3 / 3 + 1 * a2 / 2 + 2 * a1 / 3;		
		}

		public static double a1, a2, a3, a4, E;
		static int Main()
		{
			
			int N;
			int k = 0;
			Console.Write("Введите a1: ");
			a1 = vvod1();
			Console.Write("Введите a2: ");
			a2 = vvod1();
			Console.Write("Введите a3: ");
			a3 = vvod1();
			Console.Write("Введите N: ");
			N = vvod2();
			Console.Write("Введите E: ");
			E = vvod1();
			if (Math.Abs(a2 - a1) > E)
			{
				++k;
			}
			if (Math.Abs(a3 - a2) > E)
			{
				++k;
			}
			Console.WriteLine($"a1 = {a1}");
			Console.WriteLine($"a2 = {a2}");
			Console.WriteLine($"a3 = {a3}");
			for (int i = 4; i <= N; ++i)
			{
				a4 = rec();
				a1 = a2;
				a2 = a3;
				a3 = a4;
				if (Math.Abs(a3 - a2) > E)
				{
					++k;
				}
				Console.Write("a");
				Console.Write(i);
				Console.Write(" = ");
				Console.Write(a3);
				Console.Write("\n");
			}
			Console.Write($"Количество удовлетворяющих пар: {k}"); 
			Console.Read();
			return 0;		
		}
		//Проверка ввода
		static double vvod1()
		{
			double n = 0;
			bool ok = true;
			do
			{
				ok = double.TryParse(Console.ReadLine(), out n);
				if (!ok) Console.WriteLine("Требуется ввести вещественное число.");
			} while (!ok);
			return n;
		}
		static int vvod2()
		{
			int n = 0;
			bool ok = true;
			do
			{
				ok = int.TryParse(Console.ReadLine(), out n);
				if (!ok) Console.WriteLine("Требуется ввести целое число.");
			} while (!ok);
			return n;
		}


	}
}
