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
			a1 = Convert.ToDouble(Console.ReadLine());
			a2 = Convert.ToDouble(Console.ReadLine());
			a3 = Convert.ToDouble(Console.ReadLine());
			N = Convert.ToInt32(Console.ReadLine());
			E = Convert.ToDouble(Console.ReadLine());
			if (Math.Abs(a2 - a1) > E)
			{
				++k;
			}
			if (Math.Abs(a3 - a2) > E)
			{
				++k;
			}
			Console.Write("a1 = ");
			Console.Write(a1);
			Console.Write('\n');
			Console.Write("a2 = ");
			Console.Write(a2);
			Console.Write('\n');
			Console.Write("a3 = ");
			Console.Write(a3);
			Console.Write('\n');
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
			Console.Write("count ");  // кол-во удовлетовряющих пар 
			Console.Write(k);
			Console.Read();
			return 0;		
		}
		

	}
}
