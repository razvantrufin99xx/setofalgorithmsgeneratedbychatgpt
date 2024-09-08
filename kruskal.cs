using System;
using System.Collections.Generic;

public class KruskalAlgorithm
{
    public class Edge : IComparable<Edge>
    {
        public int Source, Destination, Weight;

        // Comparator function used for sorting edges based on their weight
        public int CompareTo(Edge other)
        {
            return this.Weight.CompareTo(other.Weight);
        }
    }

    public class Subset
    {
        public int Parent;
        public int Rank;
    }

    private int vertices;
    private List<Edge> edges;

    // Constructor
    public KruskalAlgorithm(int v)
    {
        vertices = v;
        edges = new List<Edge>();
    }

    // Add edges to the graph
    public void AddEdge(int u, int v, int w)
    {
        Edge edge = new Edge { Source = u, Destination = v, Weight = w };
        edges.Add(edge);
    }

    // Function to find the subset of an element i
    private int Find(Subset[] subsets, int i)
    {
        if (subsets[i].Parent != i)
        {
            subsets[i].Parent = Find(subsets, subsets[i].Parent);
        }
        return subsets[i].Parent;
    }

    // Function that does union of two sets of x and y
    private void Union(Subset[] subsets, int x, int y)
    {
        int xRoot = Find(subsets, x);
        int yRoot = Find(subsets, y);

        if (subsets[xRoot].Rank < subsets[yRoot].Rank)
        {
            subsets[xRoot].Parent = yRoot;
        }
        else if (subsets[xRoot].Rank > subsets[yRoot].Rank)
        {
            subsets[yRoot].Parent = xRoot;
        }
        else
        {
            subsets[yRoot].Parent = xRoot;
            subsets[xRoot].Rank++;
        }
    }

    // Function to find and print MST using Kruskal's algorithm
    public void KruskalMST()
    {
        // Sort all edges in increasing order of their weight
        edges.Sort();

        // Allocate memory for creating V subsets
        Subset[] subsets = new Subset[vertices];
        for (int i = 0; i < vertices; ++i)
        {
            subsets[i] = new Subset { Parent = i, Rank = 0 };
        }

        List<Edge> result = new List<Edge>(); // To store the final MST

        // Number of edges to be taken is V-1
        int e = 0; // Initialize result
        int i = 0; // Index variable for sorted edges

        // While the MST doesn't have V-1 edges
        while (e < vertices - 1)
        {
            // Pick the smallest edge and increment the index
            Edge nextEdge = edges[i++];
            int x = Find(subsets, nextEdge.Source);
            int y = Find(subsets, nextEdge.Destination);

            // If including this edge doesn't cause a cycle
            if (x != y)
            {
                result.Add(nextEdge);
                e++;
                Union(subsets, x, y);
            }
        }

        // Print the final MST
        Console.WriteLine("Edge \tWeight");
        foreach (var edge in result)
        {
            Console.WriteLine(edge.Source + " - " + edge.Destination + "\t" + edge.Weight);
        }
    }
}
