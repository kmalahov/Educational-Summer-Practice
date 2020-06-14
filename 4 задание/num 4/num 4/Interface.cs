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
            int Pow;
            do
            {
                Console.Write("Введите степень многочлена: ");
                ok = Int32.TryParse(Console.ReadLine(), out Pow) && Pow >= 0;
                if (!ok)
                    Console.WriteLine("Требуется ввести целое неотрицательное число.");
            } while (!ok);

            // Массив одночленов
            Complex[] Coefs = new Complex[Pow + 2];
            double x, y;

            // Ввод коэффициентов x и y
            do
            {
                Console.Write("Введите коэффициент x: ");
                ok = Double.TryParse(Console.ReadLine(), out x);
                if (!ok)
                    Console.WriteLine("Требуется ввести вещественное число.");
            } while (!ok);
            do
            {
                Console.Write("Введите коэффициент y: ");
                ok = Double.TryParse(Console.ReadLine(), out y);
                if (!ok)
                    Console.WriteLine("Требуется ввести вещественное число.");
            } while (!ok);
            Coefs[0] = new Complex(x, y);

            // Выбор способа ввода коэффициентов
            ConsoleKeyInfo Option;
            do
            {
                Console.Clear();
                Console.WriteLine();

                Console.WriteLine("1 - Сгенерировать случайные коэффициенты");
                Console.WriteLine("2 - Ввести коэффициенты с клавиатуры");
                Option = Console.ReadKey();

                switch (Option.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        RandomCoefs(ref Coefs);
                        ok = false;
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        KeyboardCoefs(ref Coefs);
                        ok = false;
                        break;
                }
            } while (ok);

            Console.Clear();

            return Coefs;
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
            double a, b;

            for (int i = 1; i < Array.Length; i++)
            {
                do
                {
                    Console.Write("Введите коэффициент a{0}: ", i - 1);
                    ok = Double.TryParse(Console.ReadLine(), out a);
                    if (!ok)
                        Console.WriteLine("Требуется ввести вещественное число.");
                } while (!ok);
                do
                {
                    Console.Write("Введите коэффициент b{0}: ", i - 1);
                    ok = Double.TryParse(Console.ReadLine(), out b);
                    if (!ok)
                        Console.WriteLine("Требуется ввести вещественное число.");
                } while (!ok);

                Array[i] = new Complex(a, b);
            }
        }

        // Печать коэффициентов
        public static void PrintCoefs(Complex[] Coefs)
        {
            Console.WriteLine("Коэффициенты x и y:");
            Console.WriteLine("{0}, {1}", Coefs[0].Re, Coefs[0].Im);

            Console.WriteLine("Коэффициенты при реальных частях комплексных членов:");
            for (int i = 1; i < Coefs.Length; i++)
            {
                Console.Write("a{0} = {1}, ", i - 1, Coefs[i].Re);
            }
            Console.WriteLine();

            Console.WriteLine("Коэффициенты при мнимых частях комплексных членов:");
            for (int i = 1; i < Coefs.Length; i++)
            {
                Console.Write("b{0} = {1}, ", i - 1, Coefs[i].Im);
            }
            Console.WriteLine();
        }
    }
}
