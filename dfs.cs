using System;
using System.Collections.Generic;

public class GraphDFS
{
    private int vertices;
    private List<int>[] adjList;

    // Constructor
    public GraphDFS(int v)
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

    // DFS traversal from a given vertex v
    private void DFSUtil(int v, bool[] visited)
    {
        visited[v] = true;
        Console.Write(v + " ");

        foreach (var neighbor in adjList[v])
        {
            if (!visited[neighbor])
            {
                DFSUtil(neighbor, visited);
            }
        }
    }

    public void DFS(int v)
    {
        bool[] visited = new bool[vertices];
        DFSUtil(v, visited);
    }
}

class Program
{
    static void Main(string[] args)
    {
        GraphDFS g = new GraphDFS(4);
        g.AddEdge(0, 1);
        g.AddEdge(0, 2);
        g.AddEdge(1, 2);
        g.AddEdge(2, 0);
        g.AddEdge(2, 3);
        g.AddEdge(3, 3);

        Console.WriteLine("Depth First Traversal starting from vertex 2:");
        g.DFS(2);
    }
}
