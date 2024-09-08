using System;
using System.Collections.Generic;

public class DijkstraAlgorithm
{
    private int vertices;

    // Constructor
    public DijkstraAlgorithm(int v)
    {
        vertices = v;
    }

    // Find the vertex with the minimum distance value
    private int MinDistance(int[] dist, bool[] sptSet)
    {
        int min = int.MaxValue, minIndex = -1;

        for (int v = 0; v < vertices; v++)
        {
            if (sptSet[v] == false && dist[v] <= min)
            {
                min = dist[v];
                minIndex = v;
            }
        }

        return minIndex;
    }

    // Print the constructed distance array
    private void PrintSolution(int[] dist)
    {
        Console.WriteLine("Vertex \t Distance from Source");
        for (int i = 0; i < vertices; i++)
        {
            Console.WriteLine(i + " \t " + dist[i]);
        }
    }

    // Implement Dijkstra's Algorithm
    public void Dijkstra(int[,] graph, int src)
    {
        int[] dist = new int[vertices]; // Output array to hold the shortest distances
        bool[] sptSet = new bool[vertices]; // Set to keep track of vertices included in the shortest path tree

        // Initialize all distances as INFINITE and sptSet[] as false
        for (int i = 0; i < vertices; i++)
        {
            dist[i] = int.MaxValue;
            sptSet[i] = false;
        }

        // Distance of the source vertex from itself is always 0
        dist[src] = 0;

        for (int count = 0; count < vertices - 1; count++)
        {
            // Pick the minimum distance vertex from the set of vertices not yet processed
            int u = MinDistance(dist, sptSet);

            // Mark the picked vertex as processed
            sptSet[u] = true;

            // Update dist value of the adjacent vertices of the picked vertex
            for (int v = 0; v < vertices; v++)
            {
                if (!sptSet[v] && graph[u, v] != 0 && dist[u] != int.MaxValue && dist[u] + graph[u, v] < dist[v])
                {
                    dist[v] = dist[u] + graph[u, v];
                }
            }
        }

        // Print the constructed distance array
        PrintSolution(dist);
    }
}

class Program
{
    static void Main(string[] args)
    {
        int[,] graph = {
            { 0, 10, 0, 0, 0, 0 },
            { 10, 0, 5, 0, 0, 0 },
            { 0, 5, 0, 20, 0, 0 },
            { 0, 0, 20, 0, 15, 30 },
            { 0, 0, 0, 15, 0, 10 },
            { 0, 0, 0, 30, 10, 0 }
        };

        DijkstraAlgorithm dijkstra = new DijkstraAlgorithm(6);
        Console.WriteLine("Dijkstra's Shortest Path:");
        dijkstra.Dijkstra(graph, 0);
    }
}
