using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace num_4
{
    class Interface
    {

        // Главное меню, где пользователь вводит степень и выбирает, сгенерировать случайные коэффициенты или ввести их вручную
        public static Complex[] MainMenu()
        {
            // Флаг правильности ввода
            bool ok;

            // Степень многочлена           
            Console.Write("Введите степень многочлена: ");
            int step = vvod2();


            // Массив одночленов
            Complex[] cof = new Complex[step + 2];
            
            Console.Write("Введите коэффициент x: ");
            double x = vvod1();
            Console.Write("Введите коэффициент y: ");
            double y = vvod1();
            cof[0] = new Complex(x, y);

            // Выбор способа ввода коэффициентов
            ConsoleKeyInfo Option;
            //do
           // {
                Console.Clear();
                Console.WriteLine();

                Console.WriteLine("1 - Сгенерировать случайные коэффициенты");
                Console.WriteLine("2 - Ввести коэффициенты с клавиатуры");
                Option = Console.ReadKey();

                switch (Option.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        RandomCoefs(ref cof);
                        ok = false;
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        KeyboardCoefs(ref cof);
                        ok = false;
                        break;
                }
           // } while (ok);

            Console.Clear();

            return cof;
        }

        // Генерация случайных коэффициентов
        static void RandomCoefs(ref Complex[] Array)
        {
            for (int i = 1; i < Array.Length; i++)
                Array[i] = new Complex();
        }

        // Ввод коэффициентов с клавиатуры
        static void KeyboardCoefs(ref Complex[] Array)
        {
            // Флаг правильности ввода
            bool ok;            

            for (int i = 1; i < Array.Length; i++)
            {                
                Console.Write("Введите коэффициент a{0}: ", i - 1);
                double a = vvod1();                

                Console.Write("Введите коэффициент b{0}: ", i - 1);
                double b = vvod1();

                Array[i] = new Complex(a, b);
            }
        }

        // Печать коэффициентов
        public static void PrintCoefs(Complex[] ceof)
        {
            Console.WriteLine("Коэффициенты x и y:");
            Console.WriteLine("{0}, {1}", ceof[0].rel, ceof[0].img);

            Console.WriteLine("Коэффициенты при реальных частях комплексных членов:");
            for (int i = 1; i < ceof.Length; i++)
            {
                Console.Write("a{0} = {1}, ", i - 1, ceof[i].rel);
            }
            Console.WriteLine();

            Console.WriteLine("Коэффициенты при мнимых частях комплексных членов:");
            for (int i = 1; i < ceof.Length; i++)
            {
                Console.Write("b{0} = {1}, ", i - 1, ceof[i].img);
            }
            Console.WriteLine();
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
