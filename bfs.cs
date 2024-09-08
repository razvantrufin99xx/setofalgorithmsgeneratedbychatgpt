using System;
using System.Collections.Generic;

public class GraphBFS
{
    private int vertices;
    private List<int>[] adjList;

    // Constructor
    public GraphBFS(int v)
    {
        vertices = v;
        adjList = new List<int>[v];
        for (int i = 0; i < v; i++)
        {
            adjList[i] = new List<int>();
        }
    }

    // Add an edge to the graph
    public void AddEdge(int v, int w)
    {
        adjList[v].Add(w);
    }

    // BFS traversal from a given source
    public void BFS(int source)
    {
        bool[] visited = new bool[vertices];
        Queue<int> queue = new Queue<int>();

        visited[source] = true;
        queue.Enqueue(source);

        while (queue.Count > 0)
        {
            int v = queue.Dequeue();
            Console.Write(v + " ");

            foreach (var neighbor in adjList[v])
            {
                if (!visited[neighbor])
                {
                    visited[neighbor] = true;
                    queue.Enqueue(neighbor);
                }
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        GraphBFS g = new GraphBFS(4);
        g.AddEdge(0, 1);
        g.AddEdge(0, 2);
        g.AddEdge(1, 2);
        g.AddEdge(2, 0);
        g.AddEdge(2, 3);
        g.AddEdge(3, 3);

        Console.WriteLine("Breadth First Traversal starting from vertex 2:");
        g.BFS(2);
    }
}
