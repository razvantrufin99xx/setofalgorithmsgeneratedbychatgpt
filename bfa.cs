using System;

public class BellmanFordAlgorithm
{
    public class Edge
    {
        public int Source, Destination, Weight;
    }

    private int vertices, edges;
    private Edge[] edgeList;

    // Constructor
    public BellmanFordAlgorithm(int v, int e)
    {
        vertices = v;
        edges = e;
        edgeList = new Edge[e];
        for (int i = 0; i < e; i++)
        {
            edgeList[i] = new Edge();
        }
    }

    // Bellman-Ford Algorithm
    public void BellmanFord(int src)
    {
        int[] dist = new int[vertices];

        // Step 1: Initialize distances from src to all other vertices as INFINITE
        for (int i = 0; i < vertices; i++)
        {
            dist[i] = int.MaxValue;
        }
        dist[src] = 0;

        // Step 2: Relax all edges |V| - 1 times
        for (int i = 1; i < vertices; i++)
        {
            for (int j = 0; j < edges; j++)
            {
                int u = edgeList[j].Source;
                int v = edgeList[j].Destination;
                int weight = edgeList[j].Weight;
                if (dist[u] != int.MaxValue && dist[u] + weight < dist[v])
                {
                    dist[v] = dist[u] + weight;
                }
            }
        }

        // Step 3: Check for negative-weight cycles
        for (int j = 0; j < edges; j++)
        {
            int u = edgeList[j].Source;
            int v = edgeList[j].Destination;
            int weight = edgeList[j].Weight;
            if (dist[u] != int.MaxValue && dist[u] + weight < dist[v])
            {
                Console.WriteLine("Graph contains negative-weight cycle");
                return;
            }
        }

        // Print the calculated shortest distances
        PrintSolution(dist);
    }

    // Utility method to print distances
    private void PrintSolution(int[] dist)
    {
        Console.WriteLine("Vertex Distance from Source");
        for (int i = 0; i < vertices; i++)
        {
            Console.WriteLine(i + "\t\t" + dist[i]);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        int vertices = 5;
        int edges = 8;
        BellmanFordAlgorithm graph = new BellmanFordAlgorithm(vertices, edges);

        graph.edgeList[0].Source = 0;
        graph.edgeList[0].Destination = 1;
        graph.edgeList[0].Weight = -1;

        graph.edgeList[1].Source = 0;
        graph.edgeList[1].Destination = 2;
        graph.edgeList[1].Weight = 4;

        graph.edgeList[2].Source = 1;
        graph.edgeList[2].Destination = 2;
        graph.edgeList[2].Weight = 3;

        graph.edgeList[3].Source = 1;
        graph.edgeList[3].Destination = 3;
        graph.edgeList[3].Weight = 2;

        graph.edgeList[4].Source = 1;
        graph.edgeList[4].Destination = 4;
        graph.edgeList[4].Weight = 2;

        graph.edgeList[5].Source = 3;
        graph.edgeList[5].Destination = 2;
        graph.edgeList[5].Weight = 5;

        graph.edgeList[6].Source = 3;
        graph.edgeList[6].Destination = 1;
        graph.edgeList[6].Weight = 1;

        graph.edgeList[7].Source = 4;
        graph.edgeList[7].Destination = 3;
        graph.edgeList[7].Weight = -3;

        Console.WriteLine("Bellman-Ford Shortest Path:");
        graph.BellmanFord(0);
    }
}
