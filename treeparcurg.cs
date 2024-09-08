using System;
using System.Collections.Generic;

public class PrimAlgorithm
{
    private int vertices;

    // Constructor
    public PrimAlgorithm(int v)
    {
        vertices = v;
    }

    // Method to find the minimum spanning tree using Prim's Algorithm
    public void PrimMST(int[,] graph)
    {
        // Array to store constructed MST
        int[] parent = new int[vertices];

        // Key values used to pick minimum weight edge in cut
        int[] key = new int[vertices];

        // To represent set of vertices not yet included in MST
        bool[] mstSet = new bool[vertices];

        // Initialize all keys as INFINITE
        for (int i = 0; i < vertices; i++)
        {
            key[i] = int.MaxValue;
            mstSet[i] = false;
        }

        // Always include the first vertex in MST.
        key[0] = 0;
        parent[0] = -1; // First node is always the root of MST

        // The MST will have vertices vertices
        for (int count = 0; count < vertices - 1; count++)
        {
            // Pick the minimum key vertex from the set of vertices
            // not yet included in MST
            int u = MinKey(key, mstSet);

            // Add the picked vertex to the MST Set
            mstSet[u] = true;

            // Update key value and parent index of the adjacent vertices
            // of the picked vertex. Consider only those vertices which are
            // not yet included in MST
            for (int v = 0; v < vertices; v++)
            {
                // graph[u,v] is non zero only for adjacent vertices of u
                // mstSet[v] is false for vertices not yet included in MST
                // Update the key only if graph[u,v] is smaller than key[v]
                if (graph[u, v] != 0 && mstSet[v] == false && graph[u, v] < key[v])
                {
                    parent[v] = u;
                    key[v] = graph[u, v];
                }
            }
        }

        // Print the constructed MST
        PrintMST(parent, graph);
    }

    // A utility function to find the vertex with minimum key value,
    // from the set of vertices not yet included in MST
    private int MinKey(int[] key, bool[] mstSet)
    {
        int min = int.MaxValue, minIndex = -1;

        for (int v = 0; v < vertices; v++)
        {
            if (mstSet[v] == false && key[v] < min)
            {
                min = key[v];
                minIndex = v;
            }
        }

        return minIndex;
    }

    // Function to print the constructed MST
    private void PrintMST(int[] parent, int[,] graph)
    {
        Console.WriteLine("Edge \tWeight");
        for (int i = 1; i < vertices; i++)
        {
            Console.WriteLine(parent[i] + " - " + i + "\t" + graph[i, parent[i]]);
        }
    }
}
