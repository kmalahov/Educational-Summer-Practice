using System;
using System.Collections.Generic;

// Программа на C ++ для поиска точек сочленения в неориентированном графе



// Класс, представляющий неориентированный граф

public class Graph

{

	private int V; // Количество вершин

	private List<int>[] adj; // Динамический массив списков смежности


	// Рекурсивная функция, которая находит точки сочленения с использованием обхода DFS
	// u -> вершина, которую нужно посетить затем
	// посещения [] -> сохраняет путь посещенных вершин
	// disc [] -> Хранит время обнаружения посещенных вершин
	// parent [] -> Сохраняет родительские вершины в дереве DFS
	// ap [] -> Сохранить точки сочленения

	
	private int APUtil_time = 0;

	private void APUtil(int u, bool[] visited, int[] disc, int[] low, int[] parent, bool[] ap)

	{

		// Для простоты используется статическая переменная, мы можем избежать использования статической

		// переменная путем передачи указателя.



		// Количество детей в DFS Tree

		int children = 0;



		// Пометить текущий узел как посещенный

		visited[u] = true;



		// Инициализация времени обнаружения и низкого значения

		disc[u] = low[u] = ++APUtil_time;



		// Проходим все вершины, прилегающие к этому

		List<int>.Enumerator i;

		for (i = adj[u].GetEnumerator(); i.MoveNext();)

		{

			int v = i.Current; // v текущий соседний с вами



			// Если v еще не посещено, то сделайте его дочерним для вас

			// в дереве DFS и повторяем за ним

			if (!visited[v])

			{

				children++;

				parent[v] = u;

				APUtil(v, visited, disc, low, parent, ap);



				// Проверяем, имеет ли поддерево с корнем v соединение с

				// один из предков тебя

				low[u] = Math.Min(low[u], low[v]);



				// u - точка сочленения в следующих случаях



				// (1) u является корнем дерева DFS и имеет двух или более детей.

				if (parent[u] == DefineConstants.NIL && children > 1)
				{

					ap[u] = true;
				}



				// (2) Если u не является корнем и младшее значение одного из его дочерних элементов больше

				// чем значение открытия для вас.

				if (parent[u] != DefineConstants.NIL && low[v] >= disc[u])
				{

					ap[u] = true;
				}

			}



			// Обновление низкого значения u для вызовов родительской функции.

			else if (v != parent[u])
			{

				low[u] = Math.Min(low[u], disc[v]);
			}

		}

	}


	public Graph(int V)

	{

		this.V = V;

		List<int> adj = new List<int>(V);		

	}

	public void addEdge(int v, int w)

	{
		adj[v].Add(w);
		//adj[v].AddLast(w);
		adj[w].Add(v);
		//adj[w].AddLast(v); // Примечание: график не ориентирован

	}


	// Функция для обхода DFS. Он использует рекурсивную функцию APUtil ()

	public void AP()

	{

		// Пометить все вершины как не посещенные

		bool[] visited = new bool[V];

		int[] disc = new int[V];

		int[] low = new int[V];

		int[] parent = new int[V];

		bool[] ap = new bool[V]; // Для сохранения точек сочленения



		// Инициализируем родительский и посещенный, и ap (точки артикуляции) массивы

		for (int i = 0; i < V; i++)

		{

			parent[i] = DefineConstants.NIL;

			visited[i] = false;

			ap[i] = false;

		}



		// Вызываем рекурсивную вспомогательную функцию для поиска точек сочленения

		// в дереве DFS с корнем из вершины 'i'

		for (int i = 0; i < V; i++)
		{

			if (visited[i] == false)
			{

				APUtil(i, visited, disc, low, parent, ap);
			}
		}



		// Теперь ap [] содержит точки сочленения, печатаем их

		for (int i = 0; i < V; i++)
		{

			if (ap[i] == true)
			{

				Console.Write(i);
				Console.Write(" ");
			}
		}

	}

}

public static class GlobalMembers
{
	// Программа драйвера для проверки вышеуказанной функции

	static int Main()

	{

		// Создание графиков, приведенных на диаграммах выше

		Console.Write("\nArticulation points in first graph \n");

		Graph g1 = new Graph(5);

		g1.addEdge(1, 0);

		g1.addEdge(0, 2);

		g1.addEdge(2, 1);

		g1.addEdge(0, 3);

		g1.addEdge(3, 4);

		g1.AP();



		Console.Write("\nArticulation points in second graph \n");

		Graph g2 = new Graph(4);

		g2.addEdge(0, 1);

		g2.addEdge(1, 2);

		g2.addEdge(2, 3);

		g2.AP();



		Console.Write("\nArticulation points in third graph \n");

		Graph g3 = new Graph(7);

		g3.addEdge(0, 1);

		g3.addEdge(1, 2);

		g3.addEdge(2, 0);

		g3.addEdge(1, 3);

		g3.addEdge(1, 4);

		g3.addEdge(1, 6);

		g3.addEdge(3, 5);

		g3.addEdge(4, 5);

		g3.AP();



		return 0;

	}
}

internal static class DefineConstants
{
	public const int NIL = -1;
}
