using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace num_10
{
    class Program
    {

        static void Main(string[] args)
        {
            List<List<string>> graph = LoadGraph();
            List<string> values = LoadValues();

            Console.WriteLine("Значение : Строка матрицы инциденций");
            Print(graph, values);

            if (!IsGraphValid(graph))
            {
                Console.WriteLine("Граф введен некорректно");
                Console.ReadLine();
                return;
            }

            if (graph.Count != values.Count)
            {
                Console.WriteLine("Количество значений не совпадает с количеством вершин");
                Console.ReadKey();
                return;
            }

            Console.Write("Введите значение информационного поля для удаления: ");
            string removingValue = Console.ReadLine();

            graph = RemoveVertexes(removingValue, graph, values);
            Console.WriteLine("\nРезультат:");
            Console.WriteLine("Значение : Строка матрицы инциденций");
            Print(graph, values);

            Console.ReadLine();
        }

        public static List<List<string>> LoadGraph()
        {
            string fileName = "graph.txt";
            List<List<string>> graph = new List<List<string>>();
            string input;

            // Загрузка матрицы инциденций
            try
            {
                using (StreamReader sr = new StreamReader(fileName, System.Text.Encoding.Default))
                {
                    input = sr.ReadToEnd();
                }
            }
            catch
            {
                Console.WriteLine("Не удалось найти файл graph.txt");
                Console.ReadLine();
                return null;
            }

            input = input.Replace("\r", "");
            // Вершины графа
            string[] points = input.Split('\n');

            // Разбиение строк на двумерный массив (матрицу)
            foreach (var p in points)
            {
                List<string> point = new List<string>();
                string[] incidences = p.Split(' ');
                foreach (var incidence in incidences)
                {
                    point.Add(incidence);
                }

                graph.Add(point);
            }

            return graph;
        }

        public static bool IsGraphValid(List<List<string>> matrix)
        {
            if (matrix[0].Count == 0)
            {
                Console.WriteLine("Матрица не имеет значений");
                return false;
            }

            for (int i = 0; i < matrix.Count; i++)
            {
                if (matrix[i].Count != matrix[0].Count)
                {
                    Console.WriteLine("\nМатрица неровная: столбцы матрицы имеют разные длины");
                    return false;
                }

                for (int j = 0; j < matrix[i].Count; j++)
                {
                    if (matrix[i][j] != "1" && matrix[i][j] != "0")
                    {
                        Console.WriteLine("\nМатрица содержит неправильные значения: " + matrix[i][j]);
                        return false;
                    }
                }
            }

            // Проход по столбцам, проверка на наличие ровно двух единиц (ребро связано с двумя вершинами)
            for (int j = 0; j < matrix[0].Count; j++)
            {
                int onesCount = 0;
                for (int i = 0; i < matrix.Count; i++)
                {
                    if (matrix[i][j] == "1")
                    {
                        onesCount++;
                    }
                }

                if (onesCount != 2)
                {
                    Console.WriteLine(
                        $"\nСтолбец №{j + 1} содержит не ровно 2 единицы\nРебро должно быть связано с двумя вершинами");
                    return false;
                }
            }

            return true;
        }

        static List<string> LoadValues()
        {
            string fileName = "values.txt";
            List<string> values = new List<string>();

            string input;

            // Загрузка матрицы инциденций
            try
            {
                using (StreamReader sr = new StreamReader(fileName, System.Text.Encoding.Default))
                {
                    input = sr.ReadToEnd();
                }
            }
            catch
            {
                Console.WriteLine("Не удалось найти файл values.txt");
                Console.ReadLine();
                return null;
            }

            foreach (var t in input.Split(' '))
            {
                values.Add(t);
            }

            return values;
        }

        static void Print(List<List<string>> graph, List<string> values)
        {
            for (int i = 0; i < graph.Count; i++)
            {
                Console.Write(values[i] + " : ");

                foreach (var p in graph[i])
                {
                    Console.Write(p);
                }

                Console.WriteLine();
            }
        }

        // Удаление вершин с заданным информационным полем
        static List<List<string>> RemoveVertexes(string removingValue, List<List<string>> graph, List<string> values)
        {
            List<int> removingVertexes = new List<int>();

            for (int i = 0; i < values.Count; i++)
            {
                if (values[i] == removingValue)
                {
                    removingVertexes.Add(i);
                }
            }

            for (int i = removingVertexes.Count - 1; i >= 0; i--)
            {
                // Удаление информационного поля
                values.RemoveAt(removingVertexes[i]);

                // Удаление ребер
                // Проход по строке матрицы инциденций для вершины, которую удаляем
                for (int j = graph[removingVertexes[i]].Count - 1; j >= 0; j--)
                {
                    // Если в строке матрицы инциденций есть ребро, связанное с удаляемой вершиной
                    if (graph[removingVertexes[i]][j] == "1")
                    {
                        // Удаление ребер, которые соединены с удаляемой вершиной
                        for (int k = 0; k < graph.Count; k++)
                        {
                            // Удаление ребра, которое соединено с удаляемой вершиной
                            graph[k].RemoveAt(j);
                        }
                    }
                }

                // Удаление вершин
                graph.RemoveAt(removingVertexes[i]);
            }

            return graph;
        }
    }
}
