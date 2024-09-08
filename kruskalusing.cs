class Program
{
    static void Main(string[] args)
    {
        // Prim's Algorithm Example
        int[,] graph = {
            { 0, 2, 0, 6, 0 },
            { 2, 0, 3, 8, 5 },
            { 0, 3, 0, 0, 7 },
            { 6, 8, 0, 0, 9 },
            { 0, 5, 7, 9, 0 }
        };

        PrimAlgorithm prim = new PrimAlgorithm(5);
        Console.WriteLine("Prim's Minimum Spanning Tree:");
        prim.PrimMST(graph);

        // Kruskal's Algorithm Example
        KruskalAlgorithm kruskal = new KruskalAlgorithm(4);
        kruskal.AddEdge(0, 1, 10);
        kruskal.AddEdge(0, 2, 6);
        kruskal.AddEdge(0, 3, 5);
        kruskal.AddEdge(1, 3, 15);
        kruskal.AddEdge(2, 3, 4);

        Console.WriteLine("\nKruskal's Minimum Spanning Tree:");
        kruskal.KruskalMST();
    }
}
