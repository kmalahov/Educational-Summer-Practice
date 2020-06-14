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
            Console.WriteLine("Задание №3 из книги Абрамов С.А., Гнездилова Г.Г., Капустина Е.Н., Селюн М.И. Задачи по программированию. М.: Наука, 1988.\n 59и \n Проверить точку на принадлежность области");
            Console.WriteLine("Введите координату Х:");
            double x = TakeNumber();
            Console.WriteLine("Введите координату У:");
            double y = TakeNumber();
            //if ((y <= 1) && (-1 <= y) && (x <= 1) && (-2 <= x))
            //{
            //    if (!((x>0)&&(y>0)))
            //    {
            //        if(!(x>-1))
            //    }
            //}
            //bool answer;
            //answer = (y <= 1) && (-1 <= y) && (x <= 1) && (-2 <= x);
            //if (answer)
            //    Console.WriteLine("Ваша точка принадлежит отрезку!");
            //else Console.WriteLine("Ваша точка не принадлежит отрезку(");
            


            //double x;
            //double y;
            //x = double.Parse(ConsoleInput.ReadToWhiteSpace(true));
            //y = double.Parse(ConsoleInput.ReadToWhiteSpace(true));
            if (y >= 0 && y <= -x && x >= (y - 3) / 2 || y <= 0 && x >= (y - 3) / 2 && y >= (x - 1) / 3)
            {
                Console.Write("Точка входит в заштрихованную область.");
            }
            else
            {
                Console.Write("Точка не входит в заштрихованную область.");
            }
            
            Console.WriteLine("Нажмите Enter...");
            Console.ReadLine();
        }

        static double TakeNumber()
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
