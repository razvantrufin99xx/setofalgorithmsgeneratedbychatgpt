using System;

class FloydWarshall
{
    static int INF = 99999;

    public static void Main()
    {
        int[,] graph = {
            {0, 3, INF, 5},
            {2, 0, INF, 4},
            {INF, 1, 0, INF},
            {INF, INF, 2, 0}
        };

        int verticesCount = graph.GetLength(0);
        FloydWarshallAlgorithm(graph, verticesCount);
    }

    public static void FloydWarshallAlgorithm(int[,] graph, int verticesCount)
    {
        int[,] dist = new int[verticesCount, verticesCount];

        // Initialize the solution matrix same as input graph matrix
        for (int i = 0; i < verticesCount; i++)
            for (int j = 0; j < verticesCount; j++)
                dist[i, j] = graph[i, j];

        // Add all vertices one by one to the set of intermediate vertices
        for (int k = 0; k < verticesCount; k++)
        {
            for (int i = 0; i < verticesCount; i++)
            {
                for (int j = 0; j < verticesCount; j++)
                {
                    if (dist[i, j] > dist[i, k] + dist[k, j])
                        dist[i, j] = dist[i, k] + dist[k, j];
                }
            }
        }

        PrintSolution(dist, verticesCount);
    }

    public static void PrintSolution(int[,] dist, int verticesCount)
    {
        Console.WriteLine("The following matrix shows the shortest distances between every pair of vertices:");
        for (int i = 0; i < verticesCount; i++)
        {
            for (int j = 0; j < verticesCount; j++)
            {
                if (dist[i, j] == INF)
                    Console.Write("INF ");
                else
                    Console.Write(dist[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}
