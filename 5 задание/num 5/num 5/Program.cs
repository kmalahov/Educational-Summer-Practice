using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace num_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задание №5 из книги Абрамов С.А., Гнездилова Г.Г., Капустина Е.Н., Селюн М.И. Задачи по программированию. М.: Наука, 1988.\n №692е");
            Console.WriteLine("Дана матрица. Получить самое большое число в определенной области");

            int a;
            do
            {
                CheckInt("Введите размерность матрицы: ", out a);
                if (a < 1) Console.WriteLine("Ошибка ввода! Размер матрицы должен быть целым числом > 1");
            } while (a < 1);
            Random rand = new Random();
            int[,] mas = new int[a, a];
            int max = -11;
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < a; j++)
                {
                    mas[i, j] = rand.Next(-10, 10);
                    Console.Write("{0,4}", mas[i, j]);
                }
                Console.WriteLine();
            }
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < a; j++)
                {
                    if ((i >= j) && (a - 1 >= i + j - 1) || (i <= j) && (a - 1 <= i + j - 1))
                        if (mas[i, j] > max) max = mas[i, j];
                }
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(max);
            Console.ReadLine();
        }

        static void CheckInt(string message, out int res)
        {
            bool check; // отвечает за проверку типа переменной

            Console.Write(message);

            do
            {
                string prior = Console.ReadLine();
                check = Int32.TryParse(prior, out res);
                if (check == false) Console.WriteLine("Неправильный ввод, попробуйте ещё раз.");
            } while (check == false);
        } // Проверка входных данных на соответствие типу Int

    }
}

